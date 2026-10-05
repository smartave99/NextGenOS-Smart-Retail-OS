using System;
using System.Diagnostics;

namespace DevNetSR.Extension
{
	// Token: 0x0200000F RID: 15
	public class SampleAggregator
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000051 RID: 81 RVA: 0x000041D0 File Offset: 0x000023D0
		// (remove) Token: 0x06000052 RID: 82 RVA: 0x00004208 File Offset: 0x00002408
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<MaxSampleEventArgs> MaximumCalculated;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000053 RID: 83 RVA: 0x00004240 File Offset: 0x00002440
		// (remove) Token: 0x06000054 RID: 84 RVA: 0x00004278 File Offset: 0x00002478
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler Restart = delegate
		{
		};

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000055 RID: 85 RVA: 0x000042AD File Offset: 0x000024AD
		// (set) Token: 0x06000056 RID: 86 RVA: 0x000042B5 File Offset: 0x000024B5
		public int NotificationCount { get; set; }

		// Token: 0x06000057 RID: 87 RVA: 0x000042BE File Offset: 0x000024BE
		public void RaiseRestart()
		{
			this.Restart(this, EventArgs.Empty);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000042D4 File Offset: 0x000024D4
		private void Reset()
		{
			this.count = 0;
			this.maxValue = (this.minValue = 0f);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004300 File Offset: 0x00002500
		public void Add(float value)
		{
			this.maxValue = Math.Max(this.maxValue, value);
			this.minValue = Math.Min(this.minValue, value);
			this.count++;
			bool flag = this.count >= this.NotificationCount && this.NotificationCount > 0;
			if (flag)
			{
				bool flag2 = this.MaximumCalculated != null;
				if (flag2)
				{
					this.MaximumCalculated(this, new MaxSampleEventArgs(this.minValue, this.maxValue));
				}
				this.Reset();
			}
		}

		// Token: 0x04000034 RID: 52
		private float maxValue;

		// Token: 0x04000035 RID: 53
		private float minValue;

		// Token: 0x04000037 RID: 55
		private int count;
	}
}
