using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NAudio.Mixer;
using NAudio.Wave;

namespace DevNetSR.Extension
{
	// Token: 0x0200000C RID: 12
	public class AudioRecorder : IAudioRecorder
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000034 RID: 52 RVA: 0x00003BA8 File Offset: 0x00001DA8
		// (remove) Token: 0x06000035 RID: 53 RVA: 0x00003BE0 File Offset: 0x00001DE0
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler Stopped = delegate
		{
		};

		// Token: 0x06000036 RID: 54 RVA: 0x00003C18 File Offset: 0x00001E18
		public AudioRecorder()
		{
			this.sampleAggregator = new SampleAggregator();
			this.RecordingFormat = new WaveFormat(44100, 1);
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00003C80 File Offset: 0x00001E80
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00003C98 File Offset: 0x00001E98
		public WaveFormat RecordingFormat
		{
			get
			{
				return this.recordingFormat;
			}
			set
			{
				this.recordingFormat = value;
				this.sampleAggregator.NotificationCount = value.SampleRate / 10;
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003CB8 File Offset: 0x00001EB8
		public void BeginMonitoring(int recordingDevice)
		{
			bool flag = this.recordingState > RecordingState.Stopped;
			if (flag)
			{
				throw new InvalidOperationException("Can't begin monitoring while we are in this state: " + this.recordingState.ToString());
			}
			this.waveIn = new WaveIn();
			this.waveIn.DeviceNumber = recordingDevice;
			this.waveIn.DataAvailable += this.OnDataAvailable;
			this.waveIn.RecordingStopped += this.OnRecordingStopped;
			this.waveIn.WaveFormat = this.recordingFormat;
			this.waveIn.StartRecording();
			this.TryGetVolumeControl();
			this.recordingState = RecordingState.Monitoring;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003D69 File Offset: 0x00001F69
		private void OnRecordingStopped(object sender, StoppedEventArgs e)
		{
			this.recordingState = RecordingState.Stopped;
			this.writer.Dispose();
			this.Stopped(this, EventArgs.Empty);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003D94 File Offset: 0x00001F94
		public void BeginRecording(string waveFileName)
		{
			bool flag = this.recordingState != RecordingState.Monitoring;
			if (flag)
			{
				throw new InvalidOperationException("Can't begin recording while we are in this state: " + this.recordingState.ToString());
			}
			this.writer = new WaveFileWriter(waveFileName, this.recordingFormat);
			this.recordingState = RecordingState.Recording;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003DF0 File Offset: 0x00001FF0
		public void Stop()
		{
			bool flag = this.recordingState == RecordingState.Recording;
			if (flag)
			{
				this.recordingState = RecordingState.RequestedStop;
				this.waveIn.StopRecording();
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003E20 File Offset: 0x00002020
		private void TryGetVolumeControl()
		{
			int waveInDeviceNumber = this.waveIn.DeviceNumber;
			bool flag = Environment.OSVersion.Version.Major >= 6;
			if (flag)
			{
				MixerLine mixerLine = this.waveIn.GetMixerLine();
				foreach (MixerControl control3 in mixerLine.Controls)
				{
					bool flag2 = control3.ControlType == MixerControlType.Volume;
					if (flag2)
					{
						this.volumeControl = control3 as UnsignedMixerControl;
						this.MicrophoneLevel = this.desiredVolume;
						break;
					}
				}
			}
			else
			{
				Mixer mixer = new Mixer(waveInDeviceNumber);
				foreach (MixerLine destination in mixer.Destinations.Where<MixerLine>((MixerLine d) => d.ComponentType == MixerLineComponentType.DestinationWaveIn))
				{
					foreach (MixerLine source2 in destination.Sources.Where<MixerLine>((MixerLine source) => source.ComponentType == MixerLineComponentType.SourceMicrophone))
					{
						using (IEnumerator<MixerControl> enumerator4 = source2.Controls.Where<MixerControl>((MixerControl control) => control.ControlType == MixerControlType.Volume).GetEnumerator())
						{
							if (enumerator4.MoveNext())
							{
								MixerControl control2 = enumerator4.Current;
								this.volumeControl = control2 as UnsignedMixerControl;
								this.MicrophoneLevel = this.desiredVolume;
							}
						}
					}
				}
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00004030 File Offset: 0x00002230
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00004048 File Offset: 0x00002248
		public double MicrophoneLevel
		{
			get
			{
				return this.desiredVolume;
			}
			set
			{
				this.desiredVolume = value;
				bool flag = this.volumeControl != null;
				if (flag)
				{
					this.volumeControl.Percent = value;
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000040 RID: 64 RVA: 0x0000407C File Offset: 0x0000227C
		public SampleAggregator SampleAggregator
		{
			get
			{
				return this.sampleAggregator;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00004094 File Offset: 0x00002294
		public RecordingState RecordingState
		{
			get
			{
				return this.recordingState;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000040AC File Offset: 0x000022AC
		public TimeSpan RecordedTime
		{
			get
			{
				bool flag = this.writer == null;
				TimeSpan timeSpan;
				if (flag)
				{
					timeSpan = TimeSpan.Zero;
				}
				else
				{
					timeSpan = TimeSpan.FromSeconds((double)this.writer.Length / (double)this.writer.WaveFormat.AverageBytesPerSecond);
				}
				return timeSpan;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000040F8 File Offset: 0x000022F8
		private void OnDataAvailable(object sender, WaveInEventArgs e)
		{
			byte[] buffer = e.Buffer;
			int bytesRecorded = e.BytesRecorded;
			this.WriteToFile(buffer, bytesRecorded);
			for (int index = 0; index < e.BytesRecorded; index += 2)
			{
				short sample = (short)(((int)buffer[index + 1] << 8) | (int)buffer[index]);
				float sample2 = (float)sample / 32768f;
				this.sampleAggregator.Add(sample2);
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000415C File Offset: 0x0000235C
		private void WriteToFile(byte[] buffer, int bytesRecorded)
		{
			long maxFileLength = (long)(this.recordingFormat.AverageBytesPerSecond * 60);
			bool flag = this.recordingState == RecordingState.Recording || this.recordingState == RecordingState.RequestedStop;
			if (flag)
			{
				int toWrite = (int)Math.Min(maxFileLength - this.writer.Length, (long)bytesRecorded);
				bool flag2 = toWrite > 0;
				if (flag2)
				{
					this.writer.Write(buffer, 0, bytesRecorded);
				}
				else
				{
					this.Stop();
				}
			}
		}

		// Token: 0x04000025 RID: 37
		private WaveIn waveIn;

		// Token: 0x04000026 RID: 38
		private SampleAggregator sampleAggregator;

		// Token: 0x04000027 RID: 39
		private UnsignedMixerControl volumeControl;

		// Token: 0x04000028 RID: 40
		private double desiredVolume = 100.0;

		// Token: 0x04000029 RID: 41
		private RecordingState recordingState;

		// Token: 0x0400002A RID: 42
		private WaveFileWriter writer;

		// Token: 0x0400002B RID: 43
		private WaveFormat recordingFormat;
	}
}
