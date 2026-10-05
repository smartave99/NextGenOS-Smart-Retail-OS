using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevNetSR.Extension;
using DevNetSR.Properties;

namespace DevNetSR
{
	// Token: 0x02000002 RID: 2
	public partial class Configuration : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static string defaultLanguage()
		{
			string resp = Utilities.ReadConfiguration();
			return (resp != null) ? resp : Languages.Data.First<KeyValuePair<string, string>>().Key;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002080 File Offset: 0x00000280
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ClassStyle |= 131072;
				return cp;
			}
		}

		// Token: 0x06000003 RID: 3
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x06000004 RID: 4 RVA: 0x000020B0 File Offset: 0x000002B0
		public Configuration()
		{
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Configuration.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020FE File Offset: 0x000002FE
		private void Configuration_Load(object sender, EventArgs e)
		{
			this.cBoxLanguages.DataSource = Languages.Data.Keys.ToList<string>();
			this.cBoxLanguages.Text = Utilities.ReadConfiguration();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000212D File Offset: 0x0000032D
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002138 File Offset: 0x00000338
		private void btnSave_Click(object sender, EventArgs e)
		{
			bool flag = Utilities.SaveConfiguration(this.cBoxLanguages.Text);
			if (flag)
			{
				MessageBox.Show("Success", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show("Failed", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			base.Close();
		}

		// Token: 0x04000001 RID: 1
		private const int CS_DROPSHADOW = 131072;
	}
}
