using System;
using System.Runtime.CompilerServices;

// Token: 0x02000017 RID: 23
internal sealed class InitializeDelegate : MulticastDelegate
{
	// Token: 0x0600007F RID: 127
	[MethodImpl(MethodImplOptions.NoInlining, MethodCodeType = MethodCodeType.Runtime)]
	public extern InitializeDelegate(object, IntPtr);

	// Token: 0x06000080 RID: 128
	[MethodImpl(MethodImplOptions.NoInlining, MethodCodeType = MethodCodeType.Runtime)]
	public extern IAsyncResult BeginInvoke(IntPtr, AsyncCallback, object);

	// Token: 0x06000081 RID: 129
	[MethodImpl(MethodImplOptions.NoInlining, MethodCodeType = MethodCodeType.Runtime)]
	public extern void EndInvoke(IAsyncResult);

	// Token: 0x06000082 RID: 130
	[MethodImpl(MethodImplOptions.NoInlining, MethodCodeType = MethodCodeType.Runtime)]
	public extern int Invoke(IntPtr);

	// Token: 0x06000083 RID: 131 RVA: 0x00002F4C File Offset: 0x0000114C
	[MethodImpl(MethodImplOptions.NoInlining)]
	static InitializeDelegate()
	{
		<AgileDotNetRT>.Initialize();
		<AgileDotNetRT>.PostInitialize();
	}
}
