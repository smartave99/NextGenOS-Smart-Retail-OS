using System;

namespace DevNetWP.Models
{
	// Token: 0x02000005 RID: 5
	internal class modelwebhook
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000020E8 File Offset: 0x000002E8
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000020F0 File Offset: 0x000002F0
		public string Status { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000020F9 File Offset: 0x000002F9
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002101 File Offset: 0x00000301
		public string Message { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000210A File Offset: 0x0000030A
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002112 File Offset: 0x00000312
		public string Result { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000211B File Offset: 0x0000031B
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002123 File Offset: 0x00000323
		public string instance_id { get; set; }
	}
}
