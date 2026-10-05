using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DevNetSR.Properties
{
	// Token: 0x02000005 RID: 5
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00003978 File Offset: 0x00001B78
		internal Resources()
		{
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00003984 File Offset: 0x00001B84
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager temp = new ResourceManager("DevNetSR.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = temp;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000039CC File Offset: 0x00001BCC
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000039E3 File Offset: 0x00001BE3
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000039EC File Offset: 0x00001BEC
		internal static Bitmap config_icon
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("config-icon", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00003A1C File Offset: 0x00001C1C
		internal static Bitmap devstroop_bg_o25
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("devstroop_bg_o25", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00003A4C File Offset: 0x00001C4C
		internal static Bitmap devstroop_full_292x60_vectorized
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("devstroop_full_292x60_vectorized", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00003A7C File Offset: 0x00001C7C
		internal static Bitmap Google_mic_svg
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("Google_mic.svg", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00003AAC File Offset: 0x00001CAC
		internal static Bitmap language
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("language", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00003ADC File Offset: 0x00001CDC
		internal static Bitmap made_with_love_vectorized
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("made-with-love_vectorized", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x0400001D RID: 29
		private static ResourceManager resourceMan;

		// Token: 0x0400001E RID: 30
		private static CultureInfo resourceCulture;
	}
}
