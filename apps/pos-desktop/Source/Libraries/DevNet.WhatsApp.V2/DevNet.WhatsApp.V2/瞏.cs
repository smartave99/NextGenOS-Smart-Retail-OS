using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

// Token: 0x02000032 RID: 50
internal sealed class 瞏 : MulticastDelegate
{
	// Token: 0x06000104 RID: 260
	public extern 瞏(object, IntPtr);

	// Token: 0x06000105 RID: 261
	public extern IAsyncResult BeginInvoke(IntPtr, AsyncCallback, object);

	// Token: 0x06000106 RID: 262
	public extern void EndInvoke(IAsyncResult);

	// Token: 0x06000107 RID: 263
	public extern DialogResult Invoke(string, string, MessageBoxButtons, MessageBoxIcon);

	// Token: 0x06000108 RID: 264 RVA: 0x000032D8 File Offset: 0x000014D8
	[MethodImpl(MethodImplOptions.NoInlining)]
	static 瞏()
	{
		{FE3C441D-DF9D-407b-917D-0B4471A8296C}.dau(49);
	}

	// Token: 0x040000A3 RID: 163
	internal static 瞏 GwEAAA==;
}
