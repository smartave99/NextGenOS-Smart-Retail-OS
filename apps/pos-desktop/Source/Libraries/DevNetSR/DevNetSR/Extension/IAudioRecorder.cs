using System;
using NAudio.Wave;

namespace DevNetSR.Extension
{
	// Token: 0x0200000D RID: 13
	public interface IAudioRecorder
	{
		// Token: 0x06000045 RID: 69
		void BeginMonitoring(int recordingDevice);

		// Token: 0x06000046 RID: 70
		void BeginRecording(string path);

		// Token: 0x06000047 RID: 71
		void Stop();

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000048 RID: 72
		// (set) Token: 0x06000049 RID: 73
		double MicrophoneLevel { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004A RID: 74
		RecordingState RecordingState { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004B RID: 75
		SampleAggregator SampleAggregator { get; }

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600004C RID: 76
		// (remove) Token: 0x0600004D RID: 77
		event EventHandler Stopped;

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600004E RID: 78
		// (set) Token: 0x0600004F RID: 79
		WaveFormat RecordingFormat { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000050 RID: 80
		TimeSpan RecordedTime { get; }
	}
}
