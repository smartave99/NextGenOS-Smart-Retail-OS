using System;
using System.Runtime.CompilerServices;

// Token: 0x02000018 RID: 24
internal sealed class ExitDelegate : MulticastDelegate
{
	// Token: 0x06000084 RID: 132
	[MethodImpl(MethodImplOptions.NoInlining, MethodCodeType = MethodCodeType.Runtime)]
	public extern ExitDelegate(object);

	// Token: 0x06000085 RID: 133
	[MethodImpl(MethodImplOptions.NoInlining, MethodCodeType = MethodCodeType.Runtime)]
	public extern IAsyncResult BeginInvoke(AsyncCallback, object);

	// Token: 0x06000086 RID: 134
	[MethodImpl(MethodImplOptions.NoInlining, MethodCodeType = MethodCodeType.Runtime)]
	public extern void EndInvoke(IAsyncResult);

	// Token: 0x06000087 RID: 135
	[MethodImpl(MethodImplOptions.NoInlining, MethodCodeType = MethodCodeType.Runtime)]
	public extern void Invoke();

	// Token: 0x06000088 RID: 136 RVA: 0x00002F58 File Offset: 0x00001158
	[MethodImpl(MethodImplOptions.NoInlining)]
	static ExitDelegate()
	{
		<AgileDotNetRT>.Initialize();
		<AgileDotNetRT>.PostInitialize();
	}
}
