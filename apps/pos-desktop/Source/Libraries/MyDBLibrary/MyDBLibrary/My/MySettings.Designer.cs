using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace MyDBLibrary.My
{
	// Token: 0x02000006 RID: 6
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal sealed partial class MySettings : ApplicationSettingsBase
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002184 File Offset: 0x00000384
		public static MySettings Default
		{
			get
			{
				return MySettings.defaultInstance;
			}
		}

		// Token: 0x04000007 RID: 7
		private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());
	}
}
