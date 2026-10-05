using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

// Token: 0x02000013 RID: 19
[SecuritySafeCritical]
internal class <AgileDotNetRT>
{
	// Token: 0x06000069 RID: 105 RVA: 0x000029CC File Offset: 0x00000BCC
	internal static string oRM=(string A_0)
	{
		Hashtable hashtable;
		瞲.hwAAAA==(hashtable = <AgileDotNetRT>.sc);
		string text;
		try
		{
			if (瞳.ggAAAA==%(<AgileDotNetRT>.sc, A_0))
			{
				text = (string)瞴.gwAAAA==%(<AgileDotNetRT>.sc, A_0);
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < A_0.Length; i++)
				{
					瞶.hgAAAA==%(stringBuilder, 瞵.cgAAAA==((int)(A_0[i] ^ (char)<AgileDotNetRT>.pRM=[i % <AgileDotNetRT>.pRM=.Length])));
				}
				瞷.hAAAAA==%(<AgileDotNetRT>.sc, A_0, 瞀.EAAAAA==%(stringBuilder));
				text = 瞀.EAAAAA==%(stringBuilder);
			}
		}
		finally
		{
			瞲.iAAAAA==(hashtable);
		}
		return text;
	}

	// Token: 0x0600006A RID: 106
	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern IntPtr LoadLibraryA(string);

	// Token: 0x0600006B RID: 107
	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern IntPtr GetProcAddress(IntPtr, string);

	// Token: 0x0600006C RID: 108
	[DllImport("AgileDotNetRT.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern int _Initialize(IntPtr);

	// Token: 0x0600006D RID: 109
	[DllImport("AgileDotNetRT64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern int _Initialize64(IntPtr);

	// Token: 0x0600006E RID: 110
	[DllImport("AgileDotNetRT.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern void _AtExit();

	// Token: 0x0600006F RID: 111
	[DllImport("AgileDotNetRT64.dll", CharSet = CharSet.Ansi, EntryPoint = "_AtExit", ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern void _AtExit64();

	// Token: 0x06000070 RID: 112 RVA: 0x00002B14 File Offset: 0x00000D14
	internal static IntPtr Load()
	{
		Type type;
		瞲.hwAAAA==(type = 瞸.EwAAAA==(typeof(<AgileDotNetRT>).TypeHandle));
		IntPtr intPtr;
		try
		{
			try
			{
				WindowsImpersonationContext windowsImpersonationContext = WindowsIdentity.Impersonate(IntPtr.Zero);
				Assembly assembly = 瞕.IQAAAA==();
				string text;
				string text2;
				if (瞹.rQAAAA==() == 4)
				{
					text = "2fc97f5f-3e69-4b65-af69-da0b34c3aeba";
					text2 = "AgileDotNetRT";
				}
				else
				{
					text = "3446e979-b5e9-4c55-8448-aeb3ef41df91";
					text2 = "AgileDotNetRT64";
				}
				Stream manifestResourceStream = assembly.GetManifestResourceStream(text);
				GZipStream gzipStream = new GZipStream(manifestResourceStream, CompressionMode.Decompress);
				BinaryReader binaryReader = new BinaryReader(gzipStream);
				byte[] array = 瞻.ogAAAA==%(binaryReader, 瞺.owAAAA==%(binaryReader));
				string text3 = 瞜.VQAAAA==("{0}{1}\\", 瞨.ZgAAAA==(), text);
				瞟.awAAAA==(text3);
				string text4 = 瞑.UgAAAA==(text3, text2, ".dll");
				if (!睾.XAAAAA==(text4))
				{
					FileStream fileStream = 瞼.XwAAAA==(text4);
					瞽.HQAAAA==%(fileStream, array, 0, array.Length);
					瞅.HgAAAA==%(fileStream);
					FileSystemAccessRule fileSystemAccessRule = new FileSystemAccessRule(new SecurityIdentifier("S-1-1-0"), FileSystemRights.ReadAndExecute, AccessControlType.Allow);
					FileSecurity fileSecurity = 瞾.YAAAAA==(text4);
					瞤.fAAAAA==%(fileSecurity, fileSystemAccessRule);
					瞿.YQAAAA==(text4, fileSecurity);
				}
				intPtr = <AgileDotNetRT>.LoadLibraryA(text4);
			}
			finally
			{
				WindowsImpersonationContext windowsImpersonationContext;
				windowsImpersonationContext.Undo();
			}
		}
		finally
		{
			瞲.iAAAAA==(type);
		}
		return intPtr;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00002CC8 File Offset: 0x00000EC8
	internal static int InitializeThroughDelegate(IntPtr A_0)
	{
		IntPtr intPtr = <AgileDotNetRT>.Load();
		IntPtr procAddress = <AgileDotNetRT>.GetProcAddress(intPtr, "_Initialize");
		InitializeDelegate initializeDelegate = (InitializeDelegate)矀.rwAAAA==(procAddress, 瞸.EwAAAA==(typeof(InitializeDelegate).TypeHandle));
		return initializeDelegate(A_0);
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00002D10 File Offset: 0x00000F10
	internal static int InitializeThroughDelegate64(IntPtr A_0)
	{
		IntPtr intPtr = <AgileDotNetRT>.Load();
		IntPtr procAddress = <AgileDotNetRT>.GetProcAddress(intPtr, "_Initialize64");
		InitializeDelegate initializeDelegate = (InitializeDelegate)矀.rwAAAA==(procAddress, 瞸.EwAAAA==(typeof(InitializeDelegate).TypeHandle));
		return initializeDelegate(A_0);
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00002D58 File Offset: 0x00000F58
	internal static void ExitThroughDelegate()
	{
		IntPtr intPtr = <AgileDotNetRT>.Load();
		IntPtr procAddress = <AgileDotNetRT>.GetProcAddress(intPtr, "_AtExit");
		ExitDelegate exitDelegate = (ExitDelegate)矀.rwAAAA==(procAddress, 瞸.EwAAAA==(typeof(ExitDelegate).TypeHandle));
		exitDelegate();
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00002DA0 File Offset: 0x00000FA0
	internal static void ExitThroughDelegate64()
	{
		IntPtr intPtr = <AgileDotNetRT>.Load();
		IntPtr procAddress = <AgileDotNetRT>.GetProcAddress(intPtr, "_AtExit64");
		ExitDelegate exitDelegate = (ExitDelegate)矀.rwAAAA==(procAddress, 瞸.EwAAAA==(typeof(ExitDelegate).TypeHandle));
		exitDelegate();
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00002DE8 File Offset: 0x00000FE8
	internal static void DomainUnload(object A_0, EventArgs A_1)
	{
		if (瞹.rQAAAA==() == 4)
		{
			<AgileDotNetRT>.ExitThroughDelegate();
			return;
		}
		<AgileDotNetRT>.ExitThroughDelegate64();
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00002E04 File Offset: 0x00001004
	internal static void Initialize()
	{
		if (!<AgileDotNetRT>.inited)
		{
			RuntimeMethodHandle runtimeMethodHandle = 矃.tQAAAA==%(矂.tAAAAA==%(矁.swAAAA==%(new StackTrace(), 0)));
			if (((瞹.rQAAAA==() != 4) ? <AgileDotNetRT>.InitializeThroughDelegate64(runtimeMethodHandle.Value) : <AgileDotNetRT>.InitializeThroughDelegate(runtimeMethodHandle.Value)) == 1)
			{
				矅.jAAAAA==%(矄.igAAAA==(), new EventHandler(<AgileDotNetRT>.DomainUnload));
			}
			<AgileDotNetRT>.inited = true;
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00002E94 File Offset: 0x00001094
	internal static void PostInitialize()
	{
	}

	// Token: 0x0400006D RID: 109
	private static byte[] pRM= = new byte[]
	{
		124, 123, 164, 239, 228, 184, 195, 126, 149, 47,
		217, 116, 68, 157, 178, 124, 193, 189, 154, 106,
		41, 23, 207, 34, 118, 166, 141, 40, 29, 183,
		184, 70, 11, 66, 109, 179, 237, 114, 210, 130,
		23, 178, 19, 244, 179, 149, 155, 31, 25, 227,
		5, 248, 235, 218, 122, 101, 171, 130, 121, 62,
		43, 155, 97, 220, 118, 147, 105, 1, 47, 253,
		141, 79, 234, 24, 83, 117, 4, 217, 110, 223,
		11, 109, 14, 56, 178, 190, 89, 48, 199, 7,
		7, 107, 247, 148, 87, 122, 81, 53, 126, 31,
		44, 153, 238, 26, 85, 181, 14, 211, 135, 4,
		97, 208
	};

	// Token: 0x0400006E RID: 110
	private static Hashtable sc = new Hashtable();

	// Token: 0x0400006F RID: 111
	private static bool inited;

	// Token: 0x04000070 RID: 112
	private static Assembly runtimeAssembly;
}
