using System;
using System.Diagnostics;

namespace DevNetSR.Extension
{
	// Token: 0x02000010 RID: 16
	public class MaxSampleEventArgs : EventArgs
	{
		// Token: 0x0600005B RID: 91 RVA: 0x000043C2 File Offset: 0x000025C2
		[DebuggerStepThrough]
		public MaxSampleEventArgs(float minValue, float maxValue)
		{
			this.MaxSample = maxValue;
			this.MinSample = minValue;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005C RID: 92 RVA: 0x000043DC File Offset: 0x000025DC
		// (set) Token: 0x0600005D RID: 93 RVA: 0x000043E4 File Offset: 0x000025E4
		public float MaxSample { get; private set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600005E RID: 94 RVA: 0x000043ED File Offset: 0x000025ED
		// (set) Token: 0x0600005F RID: 95 RVA: 0x000043F5 File Offset: 0x000025F5
		public float MinSample { get; private set; }
	}
}
