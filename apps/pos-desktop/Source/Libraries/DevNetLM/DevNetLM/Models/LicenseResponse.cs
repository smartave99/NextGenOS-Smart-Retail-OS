using System;

namespace DevNetLM.Models
{
	// Token: 0x02000007 RID: 7
	public class LicenseResponse
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000280F File Offset: 0x00000A0F
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00002817 File Offset: 0x00000A17
		public LicenseData LicenseData { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002820 File Offset: 0x00000A20
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00002828 File Offset: 0x00000A28
		public string Message { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002831 File Offset: 0x00000A31
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002839 File Offset: 0x00000A39
		public bool ShowActivation { get; set; }
	}
}
