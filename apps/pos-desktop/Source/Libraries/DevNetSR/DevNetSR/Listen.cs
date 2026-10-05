using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevNetSR.Extension;
using DevNetSR.Properties;
using Google.Cloud.Speech.V1;
using NAudio.Wave;

namespace DevNetSR
{
	// Token: 0x02000004 RID: 4
	public partial class Listen : Form
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000031B0 File Offset: 0x000013B0
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ClassStyle |= 131072;
				return cp;
			}
		}

		// Token: 0x0600000C RID: 12
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x0600000D RID: 13 RVA: 0x000031E0 File Offset: 0x000013E0
		public Listen()
		{
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Listen.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00003280 File Offset: 0x00001480
		private void FrmApp_Load(object sender, EventArgs e)
		{
			Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.GetFullPath("voice-recognition-credentials.json"));
			bool flag = WaveIn.DeviceCount < 1;
			if (flag)
			{
				MessageBox.Show("No microphone!");
				base.Close();
			}
			this.audioRecorder.SampleAggregator.MaximumCalculated += this.OnRecorderMaximumCalculated;
			for (int i = 0; i < WaveIn.DeviceCount; i++)
			{
				this.recordingDevices.Add(WaveIn.GetCapabilities(i).ProductName);
			}
			this.waveSource = new WaveIn();
			this.waveSource.WaveFormat = new WaveFormat(this.sampleRate, 1);
			this.waveSource.DataAvailable += this.waveSource_DataAvailable;
			this.cacheDir = Path.Combine(Path.GetTempPath(), "DevNetSR Cache");
			Directory.CreateDirectory(this.cacheDir);
			this.cache = Path.Combine(this.cacheDir, "cache.wav");
			while (!Utilities.IsFileReady(this.cache))
			{
				this.cache = Path.Combine(this.cacheDir, "cache-" + Utilities.RandomString(6) + ".wav");
			}
			this.waveFile = new WaveFileWriter(this.cache, this.waveSource.WaveFormat);
			this.audioRecorder.BeginMonitoring(0);
			this.waveSource.StartRecording();
			this.breaker.Enabled = true;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003404 File Offset: 0x00001604
		private void waveSource_DataAvailable(object sender, WaveInEventArgs e)
		{
			bool flag = this.waveFile != null;
			if (flag)
			{
				this.waveFile.Write(e.Buffer, 0, e.BytesRecorded);
				this.waveFile.Flush();
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00003448 File Offset: 0x00001648
		private void OnRecorderMaximumCalculated(object sender, MaxSampleEventArgs e)
		{
			float peak = Math.Max(e.MaxSample, Math.Abs(e.MinSample));
			peak *= 100f;
			this.pBarAmplitude.Value = (int)peak;
			bool flag = (int)peak < this.minAmplitude || this.minAmplitude == 0;
			if (flag)
			{
				this.minAmplitude = (int)peak;
			}
			bool flag2 = (int)peak > this.maxAmplitude || this.maxAmplitude == 0;
			if (flag2)
			{
				this.maxAmplitude = (int)peak;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000034CC File Offset: 0x000016CC
		private async void Listen_MouseDown(object sender, MouseEventArgs e)
		{
			this.lblMsg.Text = "Processing";
			this.waveSource.StopRecording();
			this.waveSource.Dispose();
			this.waveFile.Dispose();
			this.audioRecorder.Stop();
			this.breaker.Enabled = false;
			RecognitionConfig config = new RecognitionConfig
			{
				Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
				SampleRateHertz = this.sampleRate,
				LanguageCode = Languages.Data[Configuration.defaultLanguage()]
			};
			List<string> data = new List<string>();
			SpeechClient speech = SpeechClient.Create();
			try
			{
				RecognitionAudio recognitionAudio = await RecognitionAudio.FromFileAsync(this.cache);
				RecognitionAudio audio = recognitionAudio;
				recognitionAudio = null;
				RecognizeResponse response = speech.Recognize(config, audio, null);
				foreach (SpeechRecognitionResult result in response.Results)
				{
					foreach (SpeechRecognitionAlternative alternative in result.Alternatives)
					{
						data.Add(alternative.Transcript);
					}
				}
				audio = null;
				response = null;
			}
			catch
			{
			}
			this.Result = string.Join(" ", data);
			base.Close();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003513 File Offset: 0x00001713
		private void lblMsg_Click(object sender, EventArgs e)
		{
			this.Listen_MouseDown(sender, null);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000351F File Offset: 0x0000171F
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Listen_MouseDown(sender, null);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000352B File Offset: 0x0000172B
		private void pBarAmplitude_Click(object sender, EventArgs e)
		{
			this.Listen_MouseDown(sender, null);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003538 File Offset: 0x00001738
		private void breaker_Tick(object sender, EventArgs e)
		{
			bool flag = (double)this.pBarAmplitude.Value < (double)(this.maxAmplitude - this.minAmplitude) * 0.1 || this.pBarAmplitude.Value < 10;
			if (flag)
			{
				bool flag2 = this.counter > 1000 / this.breaker.Interval;
				if (flag2)
				{
					this.Listen_MouseDown(sender, null);
				}
				this.counter++;
			}
			else
			{
				this.counter = 0;
			}
		}

		// Token: 0x0400000C RID: 12
		private int sampleRate = 16000;

		// Token: 0x0400000D RID: 13
		private List<string> recordingDevices = new List<string>();

		// Token: 0x0400000E RID: 14
		private AudioRecorder audioRecorder = new AudioRecorder();

		// Token: 0x0400000F RID: 15
		private WaveIn waveSource = null;

		// Token: 0x04000010 RID: 16
		public WaveFileWriter waveFile = null;

		// Token: 0x04000011 RID: 17
		private string cache;

		// Token: 0x04000012 RID: 18
		private string cacheDir;

		// Token: 0x04000013 RID: 19
		private int minAmplitude = 0;

		// Token: 0x04000014 RID: 20
		private int maxAmplitude = 0;

		// Token: 0x04000015 RID: 21
		public string Result = "";

		// Token: 0x04000016 RID: 22
		private const int CS_DROPSHADOW = 131072;

		// Token: 0x04000017 RID: 23
		private int counter = 0;
	}
}
