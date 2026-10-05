using System;

namespace DevNetLM.Models
{
	// Token: 0x02000004 RID: 4
	internal class HardDrive
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000025CC File Offset: 0x000007CC
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000025E4 File Offset: 0x000007E4
		public string Model
		{
			get
			{
				return this.model;
			}
			set
			{
				this.model = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000025F0 File Offset: 0x000007F0
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002608 File Offset: 0x00000808
		public string Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002614 File Offset: 0x00000814
		// (set) Token: 0x06000010 RID: 16 RVA: 0x0000262C File Offset: 0x0000082C
		public string SerialNo
		{
			get
			{
				return this.serialNo;
			}
			set
			{
				this.serialNo = value;
			}
		}

		// Token: 0x04000003 RID: 3
		private string model = null;

		// Token: 0x04000004 RID: 4
		private string type = null;

		// Token: 0x04000005 RID: 5
		private string serialNo = null;
	}
}
