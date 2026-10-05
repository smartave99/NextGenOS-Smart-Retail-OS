using System;
using System.Reflection;
using System.Reflection.Emit;

// Token: 0x02000019 RID: 25
public class {FE3C441D-DF9D-407b-917D-0B4471A8296C}
{
	// Token: 0x0600008A RID: 138 RVA: 0x00002F88 File Offset: 0x00001188
	[Obfuscation]
	public static void dau(int proxyDelegateTypeToken)
	{
		Type typeFromHandle;
		try
		{
			typeFromHandle = Type.GetTypeFromHandle({FE3C441D-DF9D-407b-917D-0B4471A8296C}.GDs=.ResolveTypeHandle(33554433 + proxyDelegateTypeToken));
		}
		catch
		{
			return;
		}
		FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
		int i = 0;
		while (i < fields.Length)
		{
			FieldInfo fieldInfo = fields[i];
			string text = fieldInfo.Name;
			bool flag = false;
			if (text.EndsWith("%"))
			{
				flag = true;
				text = text.TrimEnd(new char[] { '%' });
			}
			uint num = BitConverter.ToUInt32(Convert.FromBase64String(text), 0);
			MethodInfo methodInfo;
			try
			{
				methodInfo = (MethodInfo)MethodBase.GetMethodFromHandle({FE3C441D-DF9D-407b-917D-0B4471A8296C}.GDs=.ResolveMethodHandle((int)(num + 167772161U)));
			}
			catch
			{
				goto IL_01CE;
			}
			goto IL_009B;
			IL_01CE:
			i++;
			continue;
			IL_009B:
			Delegate @delegate;
			if (methodInfo.IsStatic)
			{
				try
				{
					@delegate = Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo);
					goto IL_01BF;
				}
				catch (Exception)
				{
					goto IL_01CE;
				}
			}
			ParameterInfo[] parameters = methodInfo.GetParameters();
			int num2 = parameters.Length + 1;
			Type[] array = new Type[num2];
			array[0] = typeof(object);
			for (int j = 1; j < num2; j++)
			{
				array[j] = parameters[j - 1].ParameterType;
			}
			DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array, typeFromHandle, true);
			ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
			ilgenerator.Emit(OpCodes.Ldarg_0);
			if (num2 > 1)
			{
				ilgenerator.Emit(OpCodes.Ldarg_1);
			}
			if (num2 > 2)
			{
				ilgenerator.Emit(OpCodes.Ldarg_2);
			}
			if (num2 > 3)
			{
				ilgenerator.Emit(OpCodes.Ldarg_3);
			}
			if (num2 > 4)
			{
				for (int k = 4; k < num2; k++)
				{
					ilgenerator.Emit(OpCodes.Ldarg_S, k);
				}
			}
			ilgenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
			ilgenerator.Emit(OpCodes.Ret);
			try
			{
				@delegate = dynamicMethod.CreateDelegate(typeFromHandle);
			}
			catch (Exception)
			{
				goto IL_01CE;
			}
			IL_01BF:
			try
			{
				fieldInfo.SetValue(null, @delegate);
			}
			catch
			{
			}
			goto IL_01CE;
		}
	}

	// Token: 0x04000074 RID: 116
	private static ModuleHandle GDs= = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;

	// Token: 0x04000075 RID: 117
	public static string TypeName = "{FE3C441D-DF9D-407b-917D-0B4471A8296C}";
}
