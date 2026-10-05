using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using D0JYxJUujHVU5enxais;
using Rnd1ngUURAwCjrKdp9G;
using uTxoSRnrE4dgibcUtLE;

namespace xyIvZO4FEX709x1mTfd
{
	// Token: 0x02000014 RID: 20
	internal class dEVOB24MC4I6IS6wh5O
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00002B10 File Offset: 0x00000D10
		[MethodImpl(MethodImplOptions.NoInlining)]
		static dEVOB24MC4I6IS6wh5O()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00002C84 File Offset: 0x00000E84
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void kQduVb4aQd()
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00002C88 File Offset: 0x00000E88
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] hmb4cKcuyY(object \u0020)
		{
			uint[] array = new uint[16];
			uint num = (uint)((448 - \u0020.Length * 8 % 512 + 512) % 512);
			if (num == 0U)
			{
				num = 512U;
			}
			uint num2 = (uint)((long)\u0020.Length + (long)((ulong)(num / 8U)) + 8L);
			ulong num3 = (ulong)((long)\u0020.Length * 8L);
			byte[] array2 = new byte[num2];
			for (int i = 0; i < \u0020.Length; i++)
			{
				array2[i] = \u0020[i];
			}
			byte[] array3 = array2;
			int num4 = \u0020.Length;
			array3[num4] |= 128;
			for (int j = 8; j > 0; j--)
			{
				array2[(int)(checked((IntPtr)(unchecked((ulong)num2 - (ulong)((long)j)))))] = (byte)((num3 >> (8 - j) * 8) & 255UL);
			}
			uint num5 = (uint)(array2.Length * 8 / 32);
			uint num6 = 1732584193U;
			uint num7 = 4023233417U;
			uint num8 = 2562383102U;
			uint num9 = 271733878U;
			for (uint num10 = 0U; num10 < num5 / 16U; num10 += 1U)
			{
				uint num11 = num10 << 6;
				for (uint num12 = 0U; num12 < 61U; num12 += 4U)
				{
					array[(int)(num12 >> 2)] = (uint)(((int)array2[(int)(num11 + (num12 + 3U))] << 24) | ((int)array2[(int)(num11 + (num12 + 2U))] << 16) | ((int)array2[(int)(num11 + (num12 + 1U))] << 8) | (int)array2[(int)(num11 + num12)]);
				}
				uint num13 = num6;
				uint num14 = num7;
				uint num15 = num8;
				uint num16 = num9;
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num6, num7, num8, num9, 0U, 7, 1U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num9, num6, num7, num8, 1U, 12, 2U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num8, num9, num6, num7, 2U, 17, 3U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num7, num8, num9, num6, 3U, 22, 4U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num6, num7, num8, num9, 4U, 7, 5U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num9, num6, num7, num8, 5U, 12, 6U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num8, num9, num6, num7, 6U, 17, 7U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num7, num8, num9, num6, 7U, 22, 8U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num6, num7, num8, num9, 8U, 7, 9U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num9, num6, num7, num8, 9U, 12, 10U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num8, num9, num6, num7, 10U, 17, 11U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num7, num8, num9, num6, 11U, 22, 12U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num6, num7, num8, num9, 12U, 7, 13U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num9, num6, num7, num8, 13U, 12, 14U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num8, num9, num6, num7, 14U, 17, 15U, array);
				dEVOB24MC4I6IS6wh5O.w9M4Yx9uxM(ref num7, num8, num9, num6, 15U, 22, 16U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num6, num7, num8, num9, 1U, 5, 17U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num9, num6, num7, num8, 6U, 9, 18U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num8, num9, num6, num7, 11U, 14, 19U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num7, num8, num9, num6, 0U, 20, 20U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num6, num7, num8, num9, 5U, 5, 21U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num9, num6, num7, num8, 10U, 9, 22U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num8, num9, num6, num7, 15U, 14, 23U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num7, num8, num9, num6, 4U, 20, 24U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num6, num7, num8, num9, 9U, 5, 25U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num9, num6, num7, num8, 14U, 9, 26U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num8, num9, num6, num7, 3U, 14, 27U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num7, num8, num9, num6, 8U, 20, 28U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num6, num7, num8, num9, 13U, 5, 29U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num9, num6, num7, num8, 2U, 9, 30U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num8, num9, num6, num7, 7U, 14, 31U, array);
				dEVOB24MC4I6IS6wh5O.Xv94J03Kjn(ref num7, num8, num9, num6, 12U, 20, 32U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num6, num7, num8, num9, 5U, 4, 33U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num9, num6, num7, num8, 8U, 11, 34U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num8, num9, num6, num7, 11U, 16, 35U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num7, num8, num9, num6, 14U, 23, 36U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num6, num7, num8, num9, 1U, 4, 37U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num9, num6, num7, num8, 4U, 11, 38U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num8, num9, num6, num7, 7U, 16, 39U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num7, num8, num9, num6, 10U, 23, 40U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num6, num7, num8, num9, 13U, 4, 41U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num9, num6, num7, num8, 0U, 11, 42U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num8, num9, num6, num7, 3U, 16, 43U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num7, num8, num9, num6, 6U, 23, 44U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num6, num7, num8, num9, 9U, 4, 45U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num9, num6, num7, num8, 12U, 11, 46U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num8, num9, num6, num7, 15U, 16, 47U, array);
				dEVOB24MC4I6IS6wh5O.kUs4DWVAvx(ref num7, num8, num9, num6, 2U, 23, 48U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num6, num7, num8, num9, 0U, 6, 49U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num9, num6, num7, num8, 7U, 10, 50U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num8, num9, num6, num7, 14U, 15, 51U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num7, num8, num9, num6, 5U, 21, 52U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num6, num7, num8, num9, 12U, 6, 53U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num9, num6, num7, num8, 3U, 10, 54U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num8, num9, num6, num7, 10U, 15, 55U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num7, num8, num9, num6, 1U, 21, 56U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num6, num7, num8, num9, 8U, 6, 57U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num9, num6, num7, num8, 15U, 10, 58U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num8, num9, num6, num7, 6U, 15, 59U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num7, num8, num9, num6, 13U, 21, 60U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num6, num7, num8, num9, 4U, 6, 61U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num9, num6, num7, num8, 11U, 10, 62U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num8, num9, num6, num7, 2U, 15, 63U, array);
				dEVOB24MC4I6IS6wh5O.HxK4Z8vH6w(ref num7, num8, num9, num6, 9U, 21, 64U, array);
				num6 += num13;
				num7 += num14;
				num8 += num15;
				num9 += num16;
			}
			byte[] array4 = new byte[16];
			Array.Copy(BitConverter.GetBytes(num6), 0, array4, 0, 4);
			Array.Copy(BitConverter.GetBytes(num7), 0, array4, 4, 4);
			Array.Copy(BitConverter.GetBytes(num8), 0, array4, 8, 4);
			Array.Copy(BitConverter.GetBytes(num9), 0, array4, 12, 4);
			return array4;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000032EC File Offset: 0x000014EC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void w9M4Yx9uxM(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += dEVOB24MC4I6IS6wh5O.Im241VYAse(\u0020 + ((\u0020 & \u0020) | (~\u0020 & \u0020)) + \u0020[(int)\u0020] + dEVOB24MC4I6IS6wh5O.oyN4NfGvUm[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003318 File Offset: 0x00001518
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void Xv94J03Kjn(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += dEVOB24MC4I6IS6wh5O.Im241VYAse(\u0020 + ((\u0020 & \u0020) | (\u0020 & ~\u0020)) + \u0020[(int)\u0020] + dEVOB24MC4I6IS6wh5O.oyN4NfGvUm[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003344 File Offset: 0x00001544
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void kUs4DWVAvx(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += dEVOB24MC4I6IS6wh5O.Im241VYAse(\u0020 + (\u0020 ^ \u0020 ^ \u0020) + \u0020[(int)\u0020] + dEVOB24MC4I6IS6wh5O.oyN4NfGvUm[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000336C File Offset: 0x0000156C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void HxK4Z8vH6w(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += dEVOB24MC4I6IS6wh5O.Im241VYAse(\u0020 + (\u0020 ^ (\u0020 | ~\u0020)) + \u0020[(int)\u0020] + dEVOB24MC4I6IS6wh5O.oyN4NfGvUm[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003394 File Offset: 0x00001594
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static uint Im241VYAse(uint \u0020, ushort \u0020)
		{
			return (\u0020 >> (int)(32 - \u0020)) | (\u0020 << (int)\u0020);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000033A8 File Offset: 0x000015A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Vk34GGnq8g()
		{
			if (!dEVOB24MC4I6IS6wh5O.UPG4r4N2o8)
			{
				dEVOB24MC4I6IS6wh5O.Lcd4QkoGwv();
				dEVOB24MC4I6IS6wh5O.UPG4r4N2o8 = true;
			}
			return dEVOB24MC4I6IS6wh5O.wP24zdkeww;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000033C4 File Offset: 0x000015C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal dEVOB24MC4I6IS6wh5O()
		{
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000033CC File Offset: 0x000015CC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void WgQ4aZEIps(byte[] \u0020, byte[] \u0020, byte[] \u0020)
		{
			int num = \u0020.Length % 4;
			int num2 = \u0020.Length / 4;
			byte[] array = new byte[\u0020.Length];
			int num3 = \u0020.Length / 4;
			uint num4 = 0U;
			if (num > 0)
			{
				num2++;
			}
			for (int i = 0; i < num2; i++)
			{
				int num5 = i % num3;
				int num6 = i * 4;
				uint num7 = (uint)(num5 * 4);
				uint num8 = (uint)(((int)\u0020[(int)(num7 + 3U)] << 24) | ((int)\u0020[(int)(num7 + 2U)] << 16) | ((int)\u0020[(int)(num7 + 1U)] << 8) | (int)\u0020[(int)num7]);
				uint num9 = 255U;
				int num10 = 0;
				uint num11;
				if (i == num2 - 1 && num > 0)
				{
					num11 = 0U;
					num4 += num8;
					for (int j = 0; j < num; j++)
					{
						if (j > 0)
						{
							num11 <<= 8;
						}
						num11 |= (uint)\u0020[\u0020.Length - (1 + j)];
					}
				}
				else
				{
					num4 += num8;
					num7 = (uint)num6;
					num11 = (uint)(((int)\u0020[(int)(num7 + 3U)] << 24) | ((int)\u0020[(int)(num7 + 2U)] << 16) | ((int)\u0020[(int)(num7 + 1U)] << 8) | (int)\u0020[(int)num7]);
				}
				uint num12 = num4;
				uint num13 = 1060955256U;
				uint num14 = 1818282927U;
				uint num15 = num12;
				uint num16 = (num13 - 1533389235U) ^ num14;
				uint num17 = 247370422U - 2046298795U + num13;
				num13 = num16 - num16 + 298300572U;
				uint num18 = num14 & 252645135U;
				uint num19 = num14 & 4042322160U;
				num18 = ((num18 >> 4) | (num19 << 4)) + num16;
				num14 = (num14 >> 9) | (num14 << 23);
				ulong num20 = (ulong)(num16 * 725730688U);
				num20 |= 1UL;
				num15 = (uint)((ulong)(num15 * num15) % num20);
				num15 ^= num15 << 3;
				num15 += num13;
				num15 ^= num15 << 1;
				num15 += num14;
				num15 ^= num15 >> 19;
				num15 += num15;
				num15 = (((num14 << 11) - num17) ^ num13) - num15;
				num4 = num12 + (uint)num15;
				if (i == num2 - 1 && num > 0)
				{
					uint num21 = num4 ^ num11;
					for (int k = 0; k < num; k++)
					{
						if (k > 0)
						{
							num9 <<= 8;
							num10 += 8;
						}
						array[num6 + k] = (byte)((num21 & num9) >> num10);
					}
				}
				else
				{
					uint num22 = num4 ^ num11;
					array[num6] = (byte)(num22 & 255U);
					array[num6 + 1] = (byte)((num22 & 65280U) >> 8);
					array[num6 + 2] = (byte)((num22 & 16711680U) >> 16);
					array[num6 + 3] = (byte)((num22 & 4278190080U) >> 24);
				}
			}
			dEVOB24MC4I6IS6wh5O.zEvncZ5nsp = array;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000036FC File Offset: 0x000018FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static SymmetricAlgorithm iEX4xSluhd()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (dEVOB24MC4I6IS6wh5O.Vk34GGnq8g())
			{
				symmetricAlgorithm = new AesCryptoServiceProvider();
			}
			else
			{
				try
				{
					symmetricAlgorithm = new RijndaelManaged();
				}
				catch
				{
					try
					{
						symmetricAlgorithm = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
					}
					catch
					{
						symmetricAlgorithm = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
					}
				}
			}
			return symmetricAlgorithm;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003790 File Offset: 0x00001990
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Lcd4QkoGwv()
		{
			try
			{
				new MD5CryptoServiceProvider();
			}
			catch
			{
				dEVOB24MC4I6IS6wh5O.wP24zdkeww = true;
				return;
			}
			try
			{
				dEVOB24MC4I6IS6wh5O.wP24zdkeww = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000037E8 File Offset: 0x000019E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] hpj4fanfvP(object \u0020)
		{
			if (!dEVOB24MC4I6IS6wh5O.Vk34GGnq8g())
			{
				return new MD5CryptoServiceProvider().ComputeHash(\u0020);
			}
			return dEVOB24MC4I6IS6wh5O.hmb4cKcuyY(\u0020);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003808 File Offset: 0x00001A08
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void lHg4li76Tb(object \u0020, object \u0020, uint \u0020, object \u0020)
		{
			while (\u0020 > 0U)
			{
				int num = ((\u0020 > (uint)\u0020.Length) ? \u0020.Length : ((int)\u0020));
				\u0020.Read(\u0020, 0, num);
				dEVOB24MC4I6IS6wh5O.aYT46WyB9P(\u0020, \u0020, 0, num);
				\u0020 -= (uint)num;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000384C File Offset: 0x00001A4C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void aYT46WyB9P(object \u0020, object \u0020, int \u0020, int \u0020)
		{
			\u0020.TransformBlock(\u0020, \u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000385C File Offset: 0x00001A5C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint o1P453fi3l(uint \u0020, int \u0020, long \u0020, object \u0020)
		{
			for (int i = 0; i < \u0020; i++)
			{
				\u0020.BaseStream.Position = \u0020 + (long)(i * 40 + 8);
				uint num = \u0020.ReadUInt32();
				uint num2 = \u0020.ReadUInt32();
				\u0020.ReadUInt32();
				uint num3 = \u0020.ReadUInt32();
				if (num2 <= \u0020 && \u0020 < num2 + num)
				{
					return num3 + \u0020 - num2;
				}
			}
			return 0U;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000038C4 File Offset: 0x00001AC4
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void VAd47einnx(RuntimeTypeHandle \u0020)
		{
			try
			{
				Type typeFromHandle = Type.GetTypeFromHandle(\u0020);
				if (dEVOB24MC4I6IS6wh5O.VfDn42EJL2 == null)
				{
					object obj = dEVOB24MC4I6IS6wh5O.awXnnFpTO1;
					lock (obj)
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						BinaryReader binaryReader = new BinaryReader(typeof(dEVOB24MC4I6IS6wh5O).Assembly.GetManifestResourceStream("rFQb1TZEfSiRSiQQJ9.BFBFZt1TKc8xPHYRkr"));
						binaryReader.BaseStream.Position = 0L;
						byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
						binaryReader.Close();
						if (array.Length != 0)
						{
							int num = array.Length % 4;
							int num2 = array.Length / 4;
							byte[] array2 = new byte[array.Length];
							uint num3 = 0U;
							if (num > 0)
							{
								num2++;
							}
							for (int i = 0; i < num2; i++)
							{
								int num4 = i * 4;
								uint num5 = 255U;
								int num6 = 0;
								uint num7;
								if (i == num2 - 1 && num > 0)
								{
									num7 = 0U;
									for (int j = 0; j < num; j++)
									{
										if (j > 0)
										{
											num7 <<= 8;
										}
										num7 |= (uint)array[array.Length - (1 + j)];
									}
								}
								else
								{
									uint num8 = (uint)num4;
									num7 = (uint)(((int)array[(int)(num8 + 3U)] << 24) | ((int)array[(int)(num8 + 2U)] << 16) | ((int)array[(int)(num8 + 1U)] << 8) | (int)array[(int)num8]);
								}
								num3 = num3;
								uint num9 = num3;
								uint num10 = num3;
								uint num11 = 1060955256U;
								uint num12 = 1818282927U;
								uint num13 = num10;
								uint num14 = (num11 - 1533389235U) ^ num12;
								uint num15 = 247370422U - 2046298795U + num11;
								num11 = num14 - num14 + 298300572U;
								uint num16 = num12 & 252645135U;
								uint num17 = num12 & 4042322160U;
								num16 = ((num16 >> 4) | (num17 << 4)) + num14;
								num12 = (num12 >> 9) | (num12 << 23);
								ulong num18 = (ulong)(num14 * 725730688U);
								num18 |= 1UL;
								num13 = (uint)((ulong)(num13 * num13) % num18);
								num13 ^= num13 << 3;
								num13 += num11;
								num13 ^= num13 << 1;
								num13 += num12;
								num13 ^= num13 >> 19;
								num13 += num13;
								num13 = (((num12 << 11) - num15) ^ num11) - num13;
								num3 = num9 + (uint)num13;
								if (i == num2 - 1 && num > 0)
								{
									uint num19 = num3 ^ num7;
									for (int k = 0; k < num; k++)
									{
										if (k > 0)
										{
											num5 <<= 8;
											num6 += 8;
										}
										array2[num4 + k] = (byte)((num19 & num5) >> num6);
									}
								}
								else
								{
									uint num20 = num3 ^ num7;
									array2[num4] = (byte)(num20 & 255U);
									array2[num4 + 1] = (byte)((num20 & 65280U) >> 8);
									array2[num4 + 2] = (byte)((num20 & 16711680U) >> 16);
									array2[num4 + 3] = (byte)((num20 & 4278190080U) >> 24);
								}
							}
							array = array2;
							int num21 = array.Length / 8;
							dEVOB24MC4I6IS6wh5O.ws9cK3nmMI5Apir6GGZ ws9cK3nmMI5Apir6GGZ = new dEVOB24MC4I6IS6wh5O.ws9cK3nmMI5Apir6GGZ(new MemoryStream(array));
							for (int l = 0; l < num21; l++)
							{
								int num22 = ws9cK3nmMI5Apir6GGZ.Cy5nLK82se();
								int num23 = ws9cK3nmMI5Apir6GGZ.Cy5nLK82se();
								dictionary.Add(num22, num23);
							}
							ws9cK3nmMI5Apir6GGZ.z0Pnh77E3F();
						}
						dEVOB24MC4I6IS6wh5O.VfDn42EJL2 = dictionary;
					}
				}
				FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
				for (int m = 0; m < fields.Length; m++)
				{
					try
					{
						FieldInfo fieldInfo = fields[m];
						int metadataToken = fieldInfo.MetadataToken;
						int num24 = dEVOB24MC4I6IS6wh5O.VfDn42EJL2[metadataToken];
						bool flag2 = (num24 & 1073741824) > 0;
						num24 &= 1073741823;
						MethodInfo methodInfo = (MethodInfo)typeof(dEVOB24MC4I6IS6wh5O).Module.ResolveMethod(num24, typeFromHandle.GetGenericArguments(), new Type[0]);
						if (methodInfo.IsStatic)
						{
							fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
						}
						else
						{
							ParameterInfo[] parameters = methodInfo.GetParameters();
							int num25 = parameters.Length + 1;
							Type[] array3 = new Type[num25];
							if (methodInfo.DeclaringType.IsValueType)
							{
								array3[0] = methodInfo.DeclaringType.MakeByRefType();
							}
							else
							{
								array3[0] = typeof(object);
							}
							for (int n = 0; n < parameters.Length; n++)
							{
								array3[n + 1] = parameters[n].ParameterType;
							}
							DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array3, typeFromHandle, true);
							ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
							for (int num26 = 0; num26 < num25; num26++)
							{
								switch (num26)
								{
								case 0:
									ilgenerator.Emit(OpCodes.Ldarg_0);
									break;
								case 1:
									ilgenerator.Emit(OpCodes.Ldarg_1);
									break;
								case 2:
									ilgenerator.Emit(OpCodes.Ldarg_2);
									break;
								case 3:
									ilgenerator.Emit(OpCodes.Ldarg_3);
									break;
								default:
									ilgenerator.Emit(OpCodes.Ldarg_S, num26);
									break;
								}
							}
							ilgenerator.Emit(OpCodes.Tailcall);
							ilgenerator.Emit(flag2 ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
							ilgenerator.Emit(OpCodes.Ret);
							fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
						}
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003F18 File Offset: 0x00002118
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void u7d4um1DBw()
		{
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003F1C File Offset: 0x0000211C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void l6s4TKTFcp(object \u0020, int \u0020)
		{
			aTxJb7UeuA5qByylK4E.nCPUHO8ORB(0, new object[] { \u0020, \u0020 }, null);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003F5C File Offset: 0x0000215C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string wBH4sOWL2Y(int \u0020)
		{
			if (dEVOB24MC4I6IS6wh5O.zEvncZ5nsp.Length == 0)
			{
				dEVOB24MC4I6IS6wh5O.bFGnMP4CLQ = new List<string>();
				dEVOB24MC4I6IS6wh5O.FvTnF6GUQX = new List<int>();
				dEVOB24MC4I6IS6wh5O.l6s4TKTFcp(dEVOB24MC4I6IS6wh5O.Vlk4EuyGno.GetManifestResourceStream("kaqXAd47Ui7WEfBbto.BaOWZOnOOHm1Z0J25q"), \u0020);
			}
			if (dEVOB24MC4I6IS6wh5O.ukpnUQa1Br < 75)
			{
				if (dEVOB24MC4I6IS6wh5O.Vlk4EuyGno != new StackFrame(1).GetMethod().DeclaringType.Assembly)
				{
					throw new Exception();
				}
				dEVOB24MC4I6IS6wh5O.ukpnUQa1Br++;
			}
			object naMn9yLRnX = dEVOB24MC4I6IS6wh5O.NaMn9yLRnX;
			lock (naMn9yLRnX)
			{
				int num = BitConverter.ToInt32(dEVOB24MC4I6IS6wh5O.zEvncZ5nsp, \u0020);
				if (num < dEVOB24MC4I6IS6wh5O.FvTnF6GUQX.Count && dEVOB24MC4I6IS6wh5O.FvTnF6GUQX[num] == \u0020)
				{
					return dEVOB24MC4I6IS6wh5O.bFGnMP4CLQ[num];
				}
				try
				{
					va9CPUnNBvtHv0t2JTs.hCMutNHB4P();
					byte[] array = new byte[num];
					Array.Copy(dEVOB24MC4I6IS6wh5O.zEvncZ5nsp, \u0020 + 4, array, 0, num);
					string @string = Encoding.Unicode.GetString(array, 0, array.Length);
					dEVOB24MC4I6IS6wh5O.bFGnMP4CLQ.Add(@string);
					dEVOB24MC4I6IS6wh5O.FvTnF6GUQX.Add(\u0020);
					Array.Copy(BitConverter.GetBytes(dEVOB24MC4I6IS6wh5O.bFGnMP4CLQ.Count - 1), 0, dEVOB24MC4I6IS6wh5O.zEvncZ5nsp, \u0020, 4);
					return @string;
				}
				catch
				{
				}
			}
			return "";
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000040D4 File Offset: 0x000022D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string u8I4qN6ugW(object \u0020)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(\u0020);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004104 File Offset: 0x00002304
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint Eng4HkZo1a(IntPtr \u0020, IntPtr \u0020, IntPtr \u0020, [MarshalAs(UnmanagedType.U4)] uint \u0020, IntPtr \u0020, ref uint \u0020)
		{
			IntPtr intPtr = \u0020;
			if (dEVOB24MC4I6IS6wh5O.p7D4iQQwKi)
			{
				intPtr = \u0020;
			}
			long num;
			if (IntPtr.Size == 4)
			{
				num = (long)Marshal.ReadInt32(intPtr, IntPtr.Size * 2);
			}
			else
			{
				num = Marshal.ReadInt64(intPtr, IntPtr.Size * 2);
			}
			object obj = dEVOB24MC4I6IS6wh5O.z8hnsiSJh4[num];
			if (obj == null)
			{
				return dEVOB24MC4I6IS6wh5O.cmZnlGbI42(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			dEVOB24MC4I6IS6wh5O.jN4RUZntgB1ECTUw7wi jN4RUZntgB1ECTUw7wi = (dEVOB24MC4I6IS6wh5O.jN4RUZntgB1ECTUw7wi)obj;
			IntPtr intPtr2 = Marshal.AllocCoTaskMem(jN4RUZntgB1ECTUw7wi.QacnKmKFnR.Length);
			Marshal.Copy(jN4RUZntgB1ECTUw7wi.QacnKmKFnR, 0, intPtr2, jN4RUZntgB1ECTUw7wi.QacnKmKFnR.Length);
			if (jN4RUZntgB1ECTUw7wi.MFUnoCMNU0)
			{
				\u0020 = intPtr2;
				\u0020 = (uint)jN4RUZntgB1ECTUw7wi.QacnKmKFnR.Length;
				dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(\u0020, jN4RUZntgB1ECTUw7wi.QacnKmKFnR.Length, 64, ref dEVOB24MC4I6IS6wh5O.cqIneghAdf);
				return 0U;
			}
			Marshal.WriteIntPtr(intPtr, IntPtr.Size * 2, intPtr2);
			Marshal.WriteInt32(intPtr, IntPtr.Size * 3, jN4RUZntgB1ECTUw7wi.QacnKmKFnR.Length);
			uint num2 = 0U;
			if (\u0020 != 216669565U || dEVOB24MC4I6IS6wh5O.Hk5nT4wT3C)
			{
				num2 = dEVOB24MC4I6IS6wh5O.cmZnlGbI42(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			else
			{
				dEVOB24MC4I6IS6wh5O.Hk5nT4wT3C = true;
			}
			return num2;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004238 File Offset: 0x00002438
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int Fah4Sq3XmA()
		{
			return 5;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000423C File Offset: 0x0000243C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void tkv4pc88M8()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000426C File Offset: 0x0000246C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Delegate xmV4gtFpt9(IntPtr \u0020, Type \u0020)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[] { \u0020, \u0020 });
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000042CC File Offset: 0x000024CC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe static void o7j4AZHa79()
		{
			int num = 348;
			for (;;)
			{
				int num2 = num;
				byte[] array;
				byte[] array2;
				int num14;
				byte[] array3;
				dEVOB24MC4I6IS6wh5O.ws9cK3nmMI5Apir6GGZ ws9cK3nmMI5Apir6GGZ;
				byte[] array4;
				int num16;
				int num19;
				int num20;
				byte[] array6;
				byte[] array10;
				byte[] array11;
				IntPtr intPtr;
				dEVOB24MC4I6IS6wh5O.jN4RUZntgB1ECTUw7wi jN4RUZntgB1ECTUw7wi;
				int num25;
				int num34;
				byte[] array17;
				byte[] array18;
				long num40;
				int num50;
				int num51;
				IntPtr intPtr5;
				long num64;
				dEVOB24MC4I6IS6wh5O.jN4RUZntgB1ECTUw7wi jN4RUZntgB1ECTUw7wi2;
				int num68;
				IntPtr intPtr8;
				int num77;
				IntPtr intPtr9;
				for (;;)
				{
					uint num4;
					byte[] array5;
					int num17;
					uint num18;
					byte[] array7;
					byte[] array8;
					int num21;
					uint num22;
					int num24;
					uint num27;
					uint num26;
					int num28;
					byte[] array14;
					int num29;
					int num30;
					Process process;
					IEnumerator enumerator;
					int num37;
					byte[] array16;
					IntPtr intPtr4;
					int num38;
					int num39;
					long num45;
					int num49;
					IntPtr intPtr6;
					IntPtr zero;
					byte[] array20;
					IntPtr intPtr7;
					long num61;
					int num62;
					int num67;
					uint num66;
					int num69;
					int num74;
					int num75;
					int num76;
					switch (num2)
					{
					case 0:
						goto IL_0BAC;
					case 1:
						array[11] = 205 + 6;
						num2 = 113;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 147;
							continue;
						}
						continue;
					case 2:
						array[5] = 167 - 55;
						num2 = 46;
						continue;
					case 3:
						goto IL_5230;
					case 4:
						if (dEVOB24MC4I6IS6wh5O.DlTKVoTSO60tWCGRRdq(dEVOB24MC4I6IS6wh5O.GiIYJUTHroCKRWJfsb7(dEVOB24MC4I6IS6wh5O.Vlk4EuyGno)) != 0)
						{
							goto Block_244;
						}
						goto IL_5C38;
					case 5:
					{
						uint num3 = num4;
						uint num5 = num4;
						uint num6 = 1060955256U;
						uint num7 = 1818282927U;
						uint num8 = num5;
						uint num9 = (num6 - 1533389235U) ^ num7;
						uint num10 = 247370422U - 2046298795U + num6;
						num6 = num9 - num9 + 298300572U;
						uint num11 = num7 & 252645135U;
						uint num12 = num7 & 4042322160U;
						num11 = ((num11 >> 4) | (num12 << 4)) + num9;
						num7 = (num7 >> 9) | (num7 << 23);
						ulong num13 = (ulong)(num9 * 725730688U);
						num13 |= 1UL;
						num8 = (uint)((ulong)(num8 * num8) % num13);
						num8 ^= num8 << 3;
						num8 += num6;
						num8 ^= num8 << 1;
						num8 += num7;
						num8 ^= num8 >> 19;
						num8 += num8;
						num8 = (((num7 << 11) - num10) ^ num6) - num8;
						num4 = num3 + (uint)num8;
						num2 = 380;
						continue;
					}
					case 6:
						array2[num14] = array3[0];
						num2 = 385;
						continue;
					case 7:
					{
						int num15 = dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
						bool flag = false;
						if (num15 < 1879048192)
						{
							goto IL_3E6A;
						}
						num2 = 44;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 77;
							continue;
						}
						continue;
					}
					case 8:
						goto IL_409B;
					case 9:
						array4[7] = (byte)num16;
						num2 = 96;
						continue;
					case 10:
						num4 = 0U;
						num2 = 455;
						continue;
					case 11:
						array5[num17 + 1] = (byte)((num18 & 65280U) >> 8);
						num2 = 203;
						continue;
					case 12:
						array2[num19] = array3[0];
						num2 = 413;
						continue;
					case 13:
						array4[2] = (byte)num16;
						num2 = 505;
						continue;
					case 14:
						array[20] = (byte)num20;
						num2 = 274;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 560;
							continue;
						}
						continue;
					case 15:
						array6[2] = 99;
						num2 = 384;
						continue;
					case 16:
						array[21] = (byte)num20;
						num2 = 432;
						continue;
					case 17:
						dEVOB24MC4I6IS6wh5O.rjJVyhsFF1nYV6ymRr7(dEVOB24MC4I6IS6wh5O.XfUn6Dk1g0);
						num2 = 40;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 298;
							continue;
						}
						continue;
					case 18:
						array[30] = (byte)num20;
						num2 = 250;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 261;
							continue;
						}
						continue;
					case 19:
						array7[15] = array8[7];
						num2 = 564;
						continue;
					case 20:
						array4[8] = 44 + 32;
						num2 = 216;
						continue;
					case 21:
						goto IL_4CF2;
					case 22:
					{
						byte[] array9 = dEVOB24MC4I6IS6wh5O.eRD5EwTWKtPCExT9D1F(ws9cK3nmMI5Apir6GGZ, (int)dEVOB24MC4I6IS6wh5O.n08DHyT7pRQZeOUHlRu(dEVOB24MC4I6IS6wh5O.fLH4E4T6n6yJKXfH971(ws9cK3nmMI5Apir6GGZ)));
						num2 = 262;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 436;
							continue;
						}
						continue;
					}
					case 23:
						array4[7] = 31 + 90;
						num2 = 257;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 240;
							continue;
						}
						continue;
					case 24:
						array4[13] = (byte)num16;
						num2 = 266;
						continue;
					case 25:
						goto IL_5580;
					case 26:
						goto IL_3066;
					case 27:
						array5 = new byte[array10.Length];
						num2 = 174;
						continue;
					case 28:
						array2[num19 + 6] = array11[6];
						num2 = 56;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 386;
							continue;
						}
						continue;
					case 29:
						array7[11] = array8[5];
						num2 = 374;
						continue;
					case 30:
						intPtr = dEVOB24MC4I6IS6wh5O.y814LCTqksuM9DM9hf9(dEVOB24MC4I6IS6wh5O.h7gmRlTseLATrmB6CV8(dEVOB24MC4I6IS6wh5O.Vlk4EuyGno)[0]);
						num2 = 314;
						continue;
					case 31:
						goto IL_12E5;
					case 32:
						array[7] = (byte)num20;
						num2 = 555;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 497;
							continue;
						}
						continue;
					case 33:
						array[2] = (byte)num20;
						num2 = 470;
						continue;
					case 34:
						array4[2] = (byte)num16;
						num2 = 139;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 35:
						goto IL_4792;
					case 36:
						goto IL_5262;
					case 37:
						array[26] = (byte)num20;
						num2 = 496;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 384;
							continue;
						}
						continue;
					case 38:
						array4[0] = 172 - 57;
						num2 = 74;
						continue;
					case 39:
						array[27] = 167 - 55;
						num2 = 551;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 629;
							continue;
						}
						continue;
					case 40:
						goto IL_21A7;
					case 41:
					{
						string text;
						IntPtr intPtr2 = dEVOB24MC4I6IS6wh5O.z9L4j6VkPR(text);
						num2 = 441;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 246;
							continue;
						}
						continue;
					}
					case 42:
						num20 = 81 + 46;
						num2 = 482;
						continue;
					case 43:
						num21 = 0;
						num2 = 113;
						continue;
					case 44:
						goto IL_0C48;
					case 45:
						num16 = 143 + 30;
						num2 = 301;
						continue;
					case 46:
						num20 = 105 + 20;
						num2 = 13;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 211;
							continue;
						}
						continue;
					case 47:
						array[20] = (byte)num20;
						num2 = 581;
						continue;
					case 48:
						array[3] = 138 - 94;
						num2 = 36;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 54;
							continue;
						}
						continue;
					case 49:
						goto IL_0ACF;
					case 50:
						goto IL_4FB9;
					case 51:
						if (array8 == null)
						{
							goto IL_5230;
						}
						num2 = 173;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 382;
							continue;
						}
						continue;
					case 52:
						if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() == 4)
						{
							num2 = 595;
							continue;
						}
						goto IL_0EA8;
					case 53:
						return;
					case 54:
						array[4] = 69 + 3;
						num2 = 146;
						continue;
					case 55:
						array4[7] = (byte)num16;
						num2 = 9;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 23;
							continue;
						}
						continue;
					case 56:
						array[11] = (byte)num20;
						num2 = 1;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 57:
						array2[num14] = array11[0];
						num2 = 579;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 511;
							continue;
						}
						continue;
					case 58:
						num22 = 255U;
						num2 = 43;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 43;
							continue;
						}
						continue;
					case 59:
						dEVOB24MC4I6IS6wh5O.S8GsQ3TytJ5tjgKMTx3(array7);
						num2 = 406;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 364;
							continue;
						}
						continue;
					case 60:
						goto IL_0EA8;
					case 61:
						array[18] = 62 + 53;
						num2 = 534;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 20;
							continue;
						}
						continue;
					case 62:
						goto IL_4186;
					case 63:
						goto IL_0EF8;
					case 64:
						goto IL_3066;
					case 65:
						array[14] = 185 - 61;
						num2 = 280;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 198;
							continue;
						}
						continue;
					case 66:
						array[13] = 142 - 47;
						num2 = 492;
						continue;
					case 67:
					{
						MemoryStream memoryStream = new MemoryStream();
						ICryptoTransform cryptoTransform;
						CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
						byte[] array9;
						dEVOB24MC4I6IS6wh5O.FFNwPrTjV9Q6cfJq2uk(cryptoStream, array9, 0, array9.Length);
						dEVOB24MC4I6IS6wh5O.zqhoYBTvyOGjdsexM3a(cryptoStream);
						byte[] array12 = dEVOB24MC4I6IS6wh5O.JgbKPlTOKBRTCGbTwNH(memoryStream);
						dEVOB24MC4I6IS6wh5O.ICg4YnTTsacr9O4RysL(array7, 0, array7.Length);
						dEVOB24MC4I6IS6wh5O.bGrOGvTRD5AGPPSo255(memoryStream);
						num2 = 346;
						continue;
					}
					case 68:
						goto IL_0C48;
					case 69:
					{
						uint num23;
						num4 += num23;
						num2 = 528;
						continue;
					}
					case 70:
						goto IL_2AC8;
					case 71:
						goto IL_47AE;
					case 72:
						array2[num19 + 5] = array11[5];
						num2 = 28;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 19;
							continue;
						}
						continue;
					case 73:
						array[27] = 16 + 2;
						num2 = 224;
						continue;
					case 74:
						num16 = 12 + 88;
						num2 = 402;
						continue;
					case 75:
						array[24] = (byte)num20;
						num2 = 633;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 79;
							continue;
						}
						continue;
					case 76:
						num20 = 101 + 65;
						num2 = 37;
						continue;
					case 77:
					{
						bool flag = true;
						num2 = 440;
						continue;
					}
					case 78:
						array2[num19 + 6] = array3[6];
						num2 = 228;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 230;
							continue;
						}
						continue;
					case 79:
						array4 = new byte[16];
						num2 = 22;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 38;
							continue;
						}
						continue;
					case 80:
					{
						byte[] array12;
						ws9cK3nmMI5Apir6GGZ = new dEVOB24MC4I6IS6wh5O.ws9cK3nmMI5Apir6GGZ(new MemoryStream(array12));
						num2 = 448;
						continue;
					}
					case 81:
						array[18] = 45 + 51;
						num2 = 231;
						continue;
					case 82:
						num24 = dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
						num2 = 220;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 124;
							continue;
						}
						continue;
					case 83:
					{
						byte[] array13;
						jN4RUZntgB1ECTUw7wi.QacnKmKFnR = array13;
						num2 = 268;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 257;
							continue;
						}
						continue;
					}
					case 84:
						num20 = 152 - 50;
						num2 = 56;
						continue;
					case 85:
						goto IL_12E5;
					case 86:
						array[9] = 63 + 41;
						num2 = 137;
						continue;
					case 87:
						array[25] = (byte)num20;
						num2 = 40;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 527;
							continue;
						}
						continue;
					case 88:
						num25 = 0;
						num2 = 614;
						continue;
					case 89:
						array4[14] = 46 + 68;
						num2 = 49;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 619;
							continue;
						}
						continue;
					case 90:
						goto IL_25A3;
					case 91:
						goto IL_0B24;
					case 92:
						goto IL_51A9;
					case 93:
						array4[9] = (byte)num16;
						num2 = 426;
						continue;
					case 94:
						array[27] = (byte)num20;
						num2 = 452;
						continue;
					case 95:
						num20 = 153 - 51;
						num2 = 535;
						continue;
					case 96:
						array4[8] = 73 + 29;
						num2 = 20;
						continue;
					case 97:
						goto IL_5185;
					case 98:
						num26 = num4 ^ num27;
						num2 = 552;
						continue;
					case 99:
						intPtr = dEVOB24MC4I6IS6wh5O.y814LCTqksuM9DM9hf9(dEVOB24MC4I6IS6wh5O.h7gmRlTseLATrmB6CV8(dEVOB24MC4I6IS6wh5O.Vlk4EuyGno)[0]);
						num2 = 368;
						continue;
					case 100:
						array2[num19 + 2] = array3[2];
						num2 = 320;
						continue;
					case 101:
						goto IL_37CC;
					case 102:
						num28++;
						num2 = 227;
						continue;
					case 103:
						num20 = 100 + 6;
						num2 = 34;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 49;
							continue;
						}
						continue;
					case 104:
					{
						string text = dEVOB24MC4I6IS6wh5O.jBV6WUTh67VKmPcVQbx(dEVOB24MC4I6IS6wh5O.k3JFp7TLKuY0pCZM5VR(), array6);
						num2 = 41;
						continue;
					}
					case 105:
						num20 = 26 + 44;
						num2 = 491;
						continue;
					case 106:
						goto IL_10F0;
					case 107:
						goto IL_1960;
					case 108:
						goto IL_5230;
					case 109:
						goto IL_10F0;
					case 110:
						num16 = 102 + 76;
						num2 = 349;
						continue;
					case 111:
						num20 = 30 + 25;
						num2 = 32;
						continue;
					case 112:
						array14[1] = 101;
						num2 = 459;
						continue;
					case 113:
						if (num29 == num30 - 1)
						{
							num2 = 621;
							continue;
						}
						goto IL_1F8C;
					case 114:
						try
						{
							enumerator = dEVOB24MC4I6IS6wh5O.mpXwZwT9BESV7F8DNe9(dEVOB24MC4I6IS6wh5O.NHfV1TTU8Q9mRribLDx(process));
							int num31 = 1;
							if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
							{
								num31 = 1;
							}
							switch (num31)
							{
							case 1:
								try
								{
									for (;;)
									{
										IL_4551:
										if (dEVOB24MC4I6IS6wh5O.GVRLfXTQ2g2ZWe3IuCs(enumerator))
										{
											goto IL_4527;
										}
										int num32 = 0;
										if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
										{
											num32 = 0;
										}
										for (;;)
										{
											IL_44E6:
											switch (num32)
											{
											case 1:
												goto IL_4551;
											case 2:
												goto IL_4527;
											case 3:
												if (intPtr.ToInt64() == dEVOB24MC4I6IS6wh5O.Wuhn5TiYrT)
												{
													int num33 = 4;
													num32 = num33;
													continue;
												}
												goto IL_4551;
											case 4:
												num34 = 0;
												num32 = 5;
												continue;
											}
											goto Block_334;
										}
										IL_4527:
										intPtr = dEVOB24MC4I6IS6wh5O.nAsCfYuE4PRuCXYIwm4((ProcessModule)dEVOB24MC4I6IS6wh5O.fFFY0PTMaov82muq7F0(enumerator));
										num32 = 3;
										goto IL_44E6;
									}
									Block_334:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num35 = 1;
									if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
									{
										num35 = 1;
									}
									for (;;)
									{
										switch (num35)
										{
										case 1:
											if (disposable != null)
											{
												num35 = 2;
												if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
												{
													num35 = 2;
													continue;
												}
												continue;
											}
											break;
										case 2:
											dEVOB24MC4I6IS6wh5O.z4gDu0TfjJ4n5eTjiqJ(disposable);
											num35 = 0;
											if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
											{
												num35 = 0;
												continue;
											}
											continue;
										}
										break;
									}
								}
								break;
							}
							goto IL_5464;
						}
						catch
						{
							int num36 = 0;
							if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
							{
								num36 = 0;
							}
							switch (num36)
							{
							default:
								goto IL_5464;
							}
						}
						goto IL_4676;
					case 115:
						array2[num19 + 3] = array11[3];
						num2 = 362;
						continue;
					case 116:
						array4[9] = (byte)num16;
						num2 = 140;
						continue;
					case 117:
						goto IL_0F99;
					case 118:
						array7[7] = array8[3];
						num2 = 287;
						continue;
					case 119:
						array[10] = (byte)num20;
						num2 = 499;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 267;
							continue;
						}
						continue;
					case 120:
						array2[num19 + 5] = array3[5];
						num2 = 78;
						continue;
					case 121:
						array4[10] = 47 + 123;
						num2 = 310;
						continue;
					case 122:
						num20 = 194 - 64;
						num2 = 126;
						continue;
					case 123:
						num16 = 182 - 60;
						num2 = 128;
						continue;
					case 124:
						num20 = 43 - 24;
						num2 = 371;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 213;
							continue;
						}
						continue;
					case 125:
					{
						IntPtr intPtr3 = IntPtr.Zero;
						num2 = 407;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 563;
							continue;
						}
						continue;
					}
					case 126:
						array[3] = (byte)num20;
						num2 = 96;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 185;
							continue;
						}
						continue;
					case 127:
						array[18] = (byte)num20;
						num2 = 299;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 8;
							continue;
						}
						continue;
					case 128:
						array4[15] = (byte)num16;
						num2 = 577;
						continue;
					case 129:
						goto IL_5464;
					case 130:
						array2[num19 + 1] = array11[1];
						num2 = 631;
						continue;
					case 131:
						array11 = null;
						num2 = 573;
						continue;
					case 132:
						array4[14] = 96 - 10;
						num2 = 112;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 590;
							continue;
						}
						continue;
					case 133:
						array6[9] = 108;
						num2 = 104;
						continue;
					case 134:
						num20 = 41 + 95;
						num2 = 87;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 18;
							continue;
						}
						continue;
					case 135:
						array4[1] = 120 + 40;
						num2 = 617;
						continue;
					case 136:
						goto IL_4D01;
					case 137:
						array[9] = 171 - 57;
						num2 = 221;
						continue;
					case 138:
						array[16] = (byte)num20;
						num2 = 91;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 623;
							continue;
						}
						continue;
					case 139:
						array4[2] = 217 - 72;
						num2 = 263;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 212;
							continue;
						}
						continue;
					case 140:
						array4[10] = 172 - 57;
						num2 = 121;
						continue;
					case 141:
						goto IL_1993;
					case 142:
						goto IL_3BE6;
					case 143:
						goto IL_505B;
					case 144:
						goto IL_5F32;
					case 145:
						num37++;
						num2 = 414;
						continue;
					case 146:
						num20 = 28 + 49;
						num2 = 214;
						continue;
					case 147:
						num20 = 122 + 110;
						num2 = 166;
						continue;
					case 148:
						array[21] = (byte)num20;
						num2 = 273;
						continue;
					case 149:
					{
						byte[] array15 = new byte[40];
						dEVOB24MC4I6IS6wh5O.qZ32RosJbk5LPPTkmyp(array15, fieldof(<PrivateImplementationDetails>{65B6CF8C-BEEE-4E67-B251-3CC183A8F712}.0E448EF5E5E60630BDDB19388CB6378436E3C65D03DD66DA7C6EBFF563BD857A).FieldHandle);
						array16 = array15;
						num2 = 28;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 591;
							continue;
						}
						continue;
					}
					case 150:
						array2[num19 + 1] = array17[1];
						num2 = 25;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 8;
							continue;
						}
						continue;
					case 151:
						goto IL_2D10;
					case 152:
						num16 = 67 + 72;
						num2 = 9;
						continue;
					case 153:
						array4[12] = 48 + 10;
						num2 = 361;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 355;
							continue;
						}
						continue;
					case 154:
						goto IL_42B8;
					case 155:
						if (dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(intPtr4, 4, 4, ref num25) == 0)
						{
							num2 = 417;
							continue;
						}
						goto IL_119F;
					case 156:
						num20 = 214 - 71;
						num2 = 369;
						continue;
					case 157:
						array[16] = (byte)num20;
						num2 = 513;
						continue;
					case 158:
					{
						uint num23;
						num4 += num23;
						num2 = 314;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 605;
							continue;
						}
						continue;
					}
					case 159:
						goto IL_4052;
					case 160:
						goto IL_5A19;
					case 161:
						array2[num14 + 1] = array17[1];
						num2 = 153;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 464;
							continue;
						}
						continue;
					case 162:
						array4[5] = (byte)num16;
						num2 = 609;
						continue;
					case 163:
						array[12] = 115 + 82;
						num2 = 289;
						continue;
					case 164:
						array[24] = 19 + 64;
						num2 = 243;
						continue;
					case 165:
						num38++;
						num2 = 425;
						continue;
					case 166:
						goto IL_4289;
					case 167:
						array[6] = (byte)num20;
						num2 = 40;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 1;
							continue;
						}
						continue;
					case 168:
						num20 = 215 - 71;
						num2 = 212;
						continue;
					case 169:
						array4[4] = (byte)num16;
						num2 = 432;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 532;
							continue;
						}
						continue;
					case 170:
						array6[7] = 100;
						num2 = 186;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 118;
							continue;
						}
						continue;
					case 171:
						num27 <<= 8;
						num2 = 144;
						continue;
					case 172:
						num16 = 40 + 58;
						num2 = 501;
						continue;
					case 173:
						dEVOB24MC4I6IS6wh5O.z8hnsiSJh4 = new Hashtable(dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ) + 1);
						num2 = 151;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 6;
							continue;
						}
						continue;
					case 174:
						num39 = array18.Length / 4;
						num2 = 10;
						continue;
					case 175:
						array[12] = (byte)num20;
						num2 = 231;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 245;
							continue;
						}
						continue;
					case 176:
						array[28] = 198 + 50;
						num2 = 92;
						continue;
					case 177:
						array14[5] = 116;
						num2 = 215;
						continue;
					case 178:
						dEVOB24MC4I6IS6wh5O.qTDsy4uhV0PAkMIqevL(new IntPtr((void*)(&num40)), 0, IntPtr.Zero);
						num2 = 355;
						continue;
					case 179:
						array[26] = (byte)num20;
						num2 = 39;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 26;
							continue;
						}
						continue;
					case 180:
					{
						uint num41 = 4059231220U;
						num2 = 300;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 599;
							continue;
						}
						continue;
					}
					case 181:
						try
						{
							enumerator = dEVOB24MC4I6IS6wh5O.mpXwZwT9BESV7F8DNe9(dEVOB24MC4I6IS6wh5O.NHfV1TTU8Q9mRribLDx(process));
							int num42 = 0;
							if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
							{
								num42 = 0;
							}
							switch (num42)
							{
							default:
								try
								{
									for (;;)
									{
										if (dEVOB24MC4I6IS6wh5O.GVRLfXTQ2g2ZWe3IuCs(enumerator))
										{
											goto IL_23D9;
										}
										int num43 = 1;
										if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
										{
											num43 = 0;
										}
										ProcessModule processModule;
										for (;;)
										{
											IL_2345:
											switch (num43)
											{
											case 1:
												goto IL_24C3;
											case 3:
											{
												long num44 = num45;
												intPtr = dEVOB24MC4I6IS6wh5O.nAsCfYuE4PRuCXYIwm4(processModule);
												if (num44 >= intPtr.ToInt64())
												{
													num43 = 5;
													continue;
												}
												goto IL_2450;
											}
											case 4:
												goto IL_239D;
											case 5:
											{
												long num46 = num45;
												intPtr = dEVOB24MC4I6IS6wh5O.nAsCfYuE4PRuCXYIwm4(processModule);
												if (num46 > intPtr.ToInt64() + (long)dEVOB24MC4I6IS6wh5O.YCBEptTiORjOfVTNeaH(processModule))
												{
													num43 = 8;
													if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
													{
														num43 = 6;
														continue;
													}
													continue;
												}
												break;
											}
											case 6:
											{
												string text;
												if (dEVOB24MC4I6IS6wh5O.Qmma6BTYepWE60fPdMQ(dEVOB24MC4I6IS6wh5O.kI27F6TFaocOGcmKd7s(processModule), text))
												{
													num43 = 3;
													continue;
												}
												break;
											}
											case 7:
												goto IL_23D9;
											case 8:
												goto IL_2450;
											case 9:
												goto IL_2410;
											}
											break;
											IL_239D:
											dEVOB24MC4I6IS6wh5O.kie0wuuzqbvHuU6ZqOt();
											num43 = 5;
											if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
											{
												num43 = 9;
												continue;
											}
											continue;
											IL_2450:
											if (dEVOB24MC4I6IS6wh5O.zVVDFaTNeU5XmdyvcId(dEVOB24MC4I6IS6wh5O.KiRYstTEXQJfVSY6BR5(dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O).TypeHandle).Assembly), null))
											{
												goto IL_239D;
											}
											num43 = 0;
											if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
											{
												num43 = 0;
											}
										}
										continue;
										IL_23D9:
										processModule = (ProcessModule)dEVOB24MC4I6IS6wh5O.fFFY0PTMaov82muq7F0(enumerator);
										num43 = 2;
										if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
										{
											num43 = 6;
											goto IL_2345;
										}
										goto IL_2345;
									}
									IL_2410:
									return;
									IL_24C3:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num47 = 0;
									if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
									{
										num47 = 1;
									}
									for (;;)
									{
										switch (num47)
										{
										case 1:
											if (disposable == null)
											{
												goto IL_2537;
											}
											num47 = 0;
											if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
											{
												num47 = 0;
												continue;
											}
											continue;
										case 2:
											goto IL_2537;
										}
										dEVOB24MC4I6IS6wh5O.z4gDu0TfjJ4n5eTjiqJ(disposable);
										num47 = 2;
									}
									IL_2537:;
								}
								break;
							case 1:
								break;
							}
							goto IL_5E7F;
						}
						catch
						{
							int num48 = 0;
							if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
							{
								num48 = 0;
							}
							switch (num48)
							{
							default:
								goto IL_5E7F;
							}
						}
						goto IL_25A3;
					case 182:
						array[21] = 14 + 24;
						num2 = 493;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 20;
							continue;
						}
						continue;
					case 183:
						num20 = 158 - 79;
						num2 = 321;
						continue;
					case 184:
						num16 = 30 + 25;
						num2 = 15;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 55;
							continue;
						}
						continue;
					case 185:
						num20 = 188 - 62;
						num2 = 207;
						continue;
					case 186:
						array6[8] = 108;
						num2 = 133;
						continue;
					case 187:
						goto IL_34E5;
					case 188:
						array[23] = (byte)num20;
						num2 = 164;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 32;
							continue;
						}
						continue;
					case 189:
						num20 = 214 - 71;
						num2 = 423;
						continue;
					case 190:
						goto IL_59D0;
					case 191:
						array[23] = 248 - 82;
						num2 = 356;
						continue;
					case 192:
						num20 = 155 + 76;
						num2 = 616;
						continue;
					case 193:
						array2[num19 + 5] = array17[5];
						num2 = 216;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 601;
							continue;
						}
						continue;
					case 194:
						num20 = 106 + 102;
						num2 = 175;
						continue;
					case 195:
						num14 = 9;
						num2 = 215;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 234;
							continue;
						}
						continue;
					case 196:
					{
						byte[] array13 = dEVOB24MC4I6IS6wh5O.eRD5EwTWKtPCExT9D1F(ws9cK3nmMI5Apir6GGZ, num49);
						num2 = 393;
						continue;
					}
					case 197:
						array[19] = (byte)num20;
						num2 = 200;
						continue;
					case 198:
						array4[7] = 81 + 46;
						num2 = 184;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 163;
							continue;
						}
						continue;
					case 199:
						array[29] = 81 + 94;
						num2 = 444;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 393;
							continue;
						}
						continue;
					case 200:
						array[19] = 211 - 70;
						num2 = 618;
						continue;
					case 201:
					{
						bool flag = false;
						num2 = 31;
						continue;
					}
					case 202:
						array[15] = 83 + 89;
						num2 = 115;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 233;
							continue;
						}
						continue;
					case 203:
						array5[num17 + 2] = (byte)((num18 & 16711680U) >> 16);
						num2 = 267;
						continue;
					case 204:
						goto IL_2046;
					case 205:
						num16 = 253 - 84;
						num2 = 93;
						continue;
					case 206:
						array6[10] = 108;
						num2 = 260;
						continue;
					case 207:
						array[3] = (byte)num20;
						num2 = 48;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 42;
							continue;
						}
						continue;
					case 208:
						dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
						num2 = 424;
						continue;
					case 209:
						num16 = 167 - 55;
						num2 = 162;
						continue;
					case 210:
						array2 = array16;
						num2 = 131;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 104;
							continue;
						}
						continue;
					case 211:
						array[5] = (byte)num20;
						num2 = 628;
						continue;
					case 212:
						array[22] = (byte)num20;
						num2 = 315;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 283;
							continue;
						}
						continue;
					case 213:
						num50 = dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
						num2 = 447;
						continue;
					case 214:
						array[4] = (byte)num20;
						num2 = 192;
						continue;
					case 215:
					{
						string text2 = dEVOB24MC4I6IS6wh5O.jBV6WUTh67VKmPcVQbx(dEVOB24MC4I6IS6wh5O.k3JFp7TLKuY0pCZM5VR(), array14);
						num2 = 313;
						continue;
					}
					case 216:
						array4[8] = 48 + 83;
						num2 = 500;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 142;
							continue;
						}
						continue;
					case 217:
						num20 = 189 - 63;
						num2 = 331;
						continue;
					case 218:
						dEVOB24MC4I6IS6wh5O.zsj6seTCZ6yIpnmfrkR(ws9cK3nmMI5Apir6GGZ);
						num2 = 498;
						continue;
					case 219:
						array4[0] = (byte)num16;
						num2 = 370;
						continue;
					case 220:
						if (num24 == 4)
						{
							num2 = 457;
							continue;
						}
						goto IL_3835;
					case 221:
						num20 = 116 + 10;
						num2 = 350;
						continue;
					case 222:
						array4[9] = 189 - 63;
						num2 = 458;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 536;
							continue;
						}
						continue;
					case 223:
						goto IL_3362;
					case 224:
						goto IL_1F63;
					case 225:
						if (!dEVOB24MC4I6IS6wh5O.MwQnWwTn1ub8gUfK9Yc(dEVOB24MC4I6IS6wh5O.jLMpmHT47dreQduKL5U("System.Reflection.ReflectionContext", false), null))
						{
							goto Block_19;
						}
						goto IL_59D0;
					case 226:
						num20 = 24 + 110;
						num2 = 18;
						continue;
					case 227:
						goto IL_0DDB;
					case 228:
						num20 = 217 - 72;
						num2 = 33;
						continue;
					case 229:
						num51++;
						num2 = 615;
						continue;
					case 230:
						array2[num19 + 7] = array3[7];
						num2 = 396;
						continue;
					case 231:
						array[18] = 4 + 2;
						num2 = 193;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 391;
							continue;
						}
						continue;
					case 232:
						num20 = 37 + 70;
						num2 = 138;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 296;
							continue;
						}
						continue;
					case 233:
						goto IL_0CCF;
					case 234:
						array2[num14] = array17[0];
						num2 = 161;
						continue;
					case 235:
						array[8] = 0 + 40;
						num2 = 357;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 412;
							continue;
						}
						continue;
					case 236:
						dEVOB24MC4I6IS6wh5O.XfUn6Dk1g0 = new dEVOB24MC4I6IS6wh5O.Emi0oknINGwWNmyCUnP(dEVOB24MC4I6IS6wh5O.Eng4HkZo1a);
						num2 = 125;
						continue;
					case 237:
						array[17] = (byte)num20;
						num2 = 598;
						continue;
					case 238:
						array[12] = 202 - 67;
						num2 = 163;
						continue;
					case 239:
						goto IL_25B2;
					case 240:
						num16 = 169 + 63;
						num2 = 219;
						continue;
					case 241:
						goto IL_2A89;
					case 242:
						goto IL_47C1;
					case 243:
						array[24] = 157 - 52;
						num2 = 303;
						continue;
					case 244:
						goto IL_0B6B;
					case 245:
						array[12] = 136 - 45;
						num2 = 238;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 156;
							continue;
						}
						continue;
					case 246:
						array6[4] = 114;
						num2 = 523;
						continue;
					case 247:
						num20 = 153 - 51;
						num2 = 550;
						continue;
					case 248:
						dEVOB24MC4I6IS6wh5O.TXH4Ck5rPu(intPtr5, intPtr6, dEVOB24MC4I6IS6wh5O.Dckv5pTVPyqLl6nrh0b(dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ)), 4U, out zero);
						num2 = 466;
						continue;
					case 249:
						goto IL_4F07;
					case 250:
						array4[12] = 159 - 82;
						num2 = 129;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 638;
							continue;
						}
						continue;
					case 251:
						array17 = null;
						num2 = 54;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 565;
							continue;
						}
						continue;
					case 252:
						array4[1] = (byte)num16;
						num2 = 135;
						continue;
					case 253:
						array2[num19] = array17[0];
						num2 = 150;
						continue;
					case 254:
						dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(intPtr4, 4, num25, ref num25);
						num2 = 102;
						continue;
					case 255:
						array2[num19 + 4] = array3[4];
						num2 = 120;
						continue;
					case 256:
						array[1] = 17 + 14;
						num2 = 156;
						continue;
					case 257:
						array4[7] = 166 - 55;
						num2 = 48;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 152;
							continue;
						}
						continue;
					case 258:
						num16 = 211 + 20;
						num2 = 116;
						continue;
					case 259:
						goto IL_3946;
					case 260:
						array6[11] = 108;
						num2 = 411;
						continue;
					case 261:
						array[30] = 83 + 66;
						num2 = 538;
						continue;
					case 262:
						array4[11] = (byte)num16;
						num2 = 427;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 61;
							continue;
						}
						continue;
					case 263:
						array4[2] = 73 + 35;
						num2 = 0;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 264:
						try
						{
							for (;;)
							{
								IL_5897:
								if (dEVOB24MC4I6IS6wh5O.GVRLfXTQ2g2ZWe3IuCs(enumerator))
								{
									goto IL_585A;
								}
								int num52 = 11;
								ProcessModule processModule2;
								for (;;)
								{
									IL_5706:
									Version version;
									switch (num52)
									{
									case 1:
									{
										Version version2;
										if (dEVOB24MC4I6IS6wh5O.q1KO3xTxjbLgMllusYs(version, version2))
										{
											num52 = 6;
											continue;
										}
										goto IL_5897;
									}
									case 2:
									{
										Version version2 = new Version(4, 0, 30319, 17921);
										num52 = 8;
										continue;
									}
									case 3:
										if (!dEVOB24MC4I6IS6wh5O.Qmma6BTYepWE60fPdMQ(dEVOB24MC4I6IS6wh5O.bILV7DTcheBIZptmRla(dEVOB24MC4I6IS6wh5O.kI27F6TFaocOGcmKd7s(processModule2)), "clrjit.dll"))
										{
											num52 = 5;
											continue;
										}
										goto IL_5760;
									case 4:
									{
										Version version3 = new Version(4, 0, 30319, 17020);
										num52 = 2;
										if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
										{
											num52 = 2;
											continue;
										}
										continue;
									}
									case 5:
										goto IL_583B;
									case 6:
										dEVOB24MC4I6IS6wh5O.p7D4iQQwKi = true;
										num52 = 0;
										if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
										{
											num52 = 0;
											continue;
										}
										continue;
									case 7:
										goto IL_5897;
									case 8:
									{
										Version version3;
										if (!dEVOB24MC4I6IS6wh5O.IatKOtTaqjS5dybHKiw(version, version3))
										{
											goto IL_5897;
										}
										num52 = 1;
										if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
										{
											num52 = 1;
											continue;
										}
										continue;
									}
									case 9:
										goto IL_5760;
									case 10:
										goto IL_585A;
									}
									goto Block_347;
									IL_5760:
									version = new Version(dEVOB24MC4I6IS6wh5O.qRdJNJTD5eCVRgXQhHQ(dEVOB24MC4I6IS6wh5O.tZh6SrTJTUucksYywb0(processModule2)), dEVOB24MC4I6IS6wh5O.VvGSpGTZUAh6DA3CrVp(dEVOB24MC4I6IS6wh5O.tZh6SrTJTUucksYywb0(processModule2)), dEVOB24MC4I6IS6wh5O.Y3PkwgT1n06QiHgC0FV(dEVOB24MC4I6IS6wh5O.tZh6SrTJTUucksYywb0(processModule2)), dEVOB24MC4I6IS6wh5O.PwdxjJTGTSkSJtWbPf4(dEVOB24MC4I6IS6wh5O.tZh6SrTJTUucksYywb0(processModule2)));
									num52 = 4;
									if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
									{
										num52 = 0;
									}
								}
								IL_583B:
								continue;
								IL_585A:
								processModule2 = (ProcessModule)dEVOB24MC4I6IS6wh5O.fFFY0PTMaov82muq7F0(enumerator);
								num52 = 3;
								goto IL_5706;
							}
							Block_347:
							goto IL_4473;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							int num53 = 1;
							if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
							{
								num53 = 1;
							}
							for (;;)
							{
								switch (num53)
								{
								case 1:
									if (disposable != null)
									{
										goto IL_5921;
									}
									num53 = 2;
									if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
									{
										num53 = 0;
										continue;
									}
									continue;
								case 3:
									goto IL_5921;
								}
								break;
								IL_5921:
								dEVOB24MC4I6IS6wh5O.z4gDu0TfjJ4n5eTjiqJ(disposable);
								num53 = 0;
								if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
								{
									num53 = 0;
								}
							}
						}
						goto IL_596E;
					case 265:
						dEVOB24MC4I6IS6wh5O.kie0wuuzqbvHuU6ZqOt();
						num2 = 524;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 385;
							continue;
						}
						continue;
					case 266:
						goto IL_1718;
					case 267:
						array5[num17 + 3] = (byte)((num18 & 4278190080U) >> 24);
						num2 = 160;
						continue;
					case 268:
					{
						bool flag;
						jN4RUZntgB1ECTUw7wi.MFUnoCMNU0 = flag;
						num2 = 586;
						continue;
					}
					case 269:
						dEVOB24MC4I6IS6wh5O.nwCBw1uLEr2NFIoLQP7(new IntPtr((void*)(&num40)), 0);
						num2 = 178;
						continue;
					case 270:
						array[9] = (byte)num20;
						num2 = 217;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 202;
							continue;
						}
						continue;
					case 271:
						num20 = 160 + 55;
						num2 = 456;
						continue;
					case 272:
						array[0] = 237 + 1;
						num2 = 473;
						continue;
					case 273:
						goto IL_599D;
					case 274:
						array6[6] = 46;
						num2 = 117;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 170;
							continue;
						}
						continue;
					case 275:
						goto IL_2090;
					case 276:
						goto IL_4473;
					case 277:
						array4[6] = 156 - 52;
						num2 = 45;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 35;
							continue;
						}
						continue;
					case 278:
						num45 = 0L;
						num2 = 360;
						continue;
					case 279:
						try
						{
							object obj = dEVOB24MC4I6IS6wh5O.TSoo5qs9ilf64uaD292(dEVOB24MC4I6IS6wh5O.RUqn4CsUlRmkaNApD08(dEVOB24MC4I6IS6wh5O.niPqLHsnIKP7NVOiYs5(dEVOB24MC4I6IS6wh5O.XgMV0ps4jdLo4oZoPpA(dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O).TypeHandle).Assembly))).GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), dEVOB24MC4I6IS6wh5O.niPqLHsnIKP7NVOiYs5(dEVOB24MC4I6IS6wh5O.XgMV0ps4jdLo4oZoPpA(dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O).TypeHandle).Assembly)));
							int num54 = 5;
							uint num56;
							byte[] array19;
							for (;;)
							{
								MemoryStream memoryStream2;
								switch (num54)
								{
								case 1:
									dEVOB24MC4I6IS6wh5O.hl6nusJDq3 = (IntPtr)obj;
									num54 = 9;
									continue;
								case 2:
								{
									dEVOB24MC4I6IS6wh5O.bGrOGvTRD5AGPPSo255(memoryStream2);
									int num55 = 15;
									num54 = num55;
									continue;
								}
								case 3:
									dEVOB24MC4I6IS6wh5O.oKuNBYT5QjVa1NM4Q1L(memoryStream2, 0L);
									num54 = 16;
									if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
									{
										num54 = 3;
										continue;
									}
									continue;
								case 4:
									if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() == 4)
									{
										num54 = 6;
										continue;
									}
									goto IL_1CCF;
								case 5:
									if (!(obj is IntPtr))
									{
										goto IL_1D8A;
									}
									num54 = 0;
									if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
									{
										num54 = 1;
										continue;
									}
									continue;
								case 6:
									dEVOB24MC4I6IS6wh5O.FFNwPrTjV9Q6cfJq2uk(memoryStream2, dEVOB24MC4I6IS6wh5O.Dckv5pTVPyqLl6nrh0b(dEVOB24MC4I6IS6wh5O.hl6nusJDq3.ToInt32()), 0, 4);
									num54 = 14;
									continue;
								case 7:
									goto IL_1F22;
								case 8:
									dEVOB24MC4I6IS6wh5O.FFNwPrTjV9Q6cfJq2uk(memoryStream2, new byte[dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd()], 0, dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd());
									num54 = 3;
									if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
									{
										num54 = 3;
										continue;
									}
									continue;
								case 9:
									goto IL_1D8A;
								case 10:
									goto IL_1D69;
								case 11:
									goto IL_1C8F;
								case 12:
									dEVOB24MC4I6IS6wh5O.FFNwPrTjV9Q6cfJq2uk(memoryStream2, new byte[dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd()], 0, dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd());
									num54 = 4;
									continue;
								case 13:
									goto IL_1CCF;
								case 14:
									goto IL_1D69;
								case 15:
									num56 = 0U;
									num54 = 0;
									if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
									{
										num54 = 0;
										continue;
									}
									continue;
								case 16:
									array19 = dEVOB24MC4I6IS6wh5O.JgbKPlTOKBRTCGbTwNH(memoryStream2);
									num54 = 2;
									continue;
								case 17:
									dEVOB24MC4I6IS6wh5O.hl6nusJDq3 = (IntPtr)dEVOB24MC4I6IS6wh5O.TSoo5qs9ilf64uaD292(obj.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), obj);
									num54 = 11;
									continue;
								}
								break;
								IL_1C8F:
								memoryStream2 = new MemoryStream();
								num54 = 12;
								if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
								{
									num54 = 2;
									continue;
								}
								continue;
								IL_1D8A:
								if (dEVOB24MC4I6IS6wh5O.Qmma6BTYepWE60fPdMQ(obj.GetType().ToString(), "System.Reflection.RuntimeModule"))
								{
									num54 = 17;
									continue;
								}
								goto IL_1C8F;
								IL_1CCF:
								dEVOB24MC4I6IS6wh5O.FFNwPrTjV9Q6cfJq2uk(memoryStream2, dEVOB24MC4I6IS6wh5O.QFxfwHsMTxuHNRGrihT(dEVOB24MC4I6IS6wh5O.hl6nusJDq3.ToInt64()), 0, 8);
								num54 = 10;
								continue;
								IL_1D69:
								dEVOB24MC4I6IS6wh5O.FFNwPrTjV9Q6cfJq2uk(memoryStream2, new byte[dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd()], 0, dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd());
								num54 = 8;
							}
							try
							{
								if ((array20 = array19) == null)
								{
									goto IL_1E76;
								}
								int num57 = 0;
								if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
								{
									num57 = 0;
								}
								byte* ptr;
								for (;;)
								{
									IL_1DF9:
									switch (num57)
									{
									case 0:
										goto IL_1EBC;
									case 1:
										goto IL_1ED3;
									case 2:
										goto IL_1EA3;
									case 3:
										goto IL_1E1F;
									case 4:
										goto IL_1E1F;
									case 5:
										goto IL_1EA3;
									case 6:
										goto IL_1E76;
									default:
										goto IL_1EBC;
									}
									IL_1DF5:
									int num58;
									num57 = num58;
									continue;
									IL_1EA3:
									ptr = &array20[0];
									num58 = 4;
									goto IL_1DF5;
									IL_1E1F:
									dEVOB24MC4I6IS6wh5O.XfUn6Dk1g0(new IntPtr((void*)ptr), new IntPtr((void*)ptr), new IntPtr((void*)ptr), 216669565U, new IntPtr((void*)ptr), ref num56);
									num57 = 1;
									if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
									{
										num57 = 1;
										continue;
									}
									continue;
									IL_1EBC:
									if (array20.Length != 0)
									{
										num58 = 5;
										goto IL_1DF5;
									}
									goto IL_1E76;
								}
								IL_1ED3:
								goto IL_1F22;
								IL_1E76:
								ptr = null;
								num57 = 3;
								goto IL_1DF9;
							}
							finally
							{
								array20 = null;
								int num59 = 0;
								if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
								{
									num59 = 0;
								}
								switch (num59)
								{
								}
							}
							IL_1F22:
							goto IL_5185;
						}
						catch
						{
							int num60 = 0;
							if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
							{
								num60 = 0;
							}
							switch (num60)
							{
							default:
								goto IL_5185;
							}
						}
						goto IL_1F63;
					case 280:
						num20 = 170 + 46;
						num2 = 28;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 50;
							continue;
						}
						continue;
					case 281:
						goto IL_3043;
					case 282:
						goto IL_5A19;
					case 283:
						goto IL_3F3D;
					case 284:
						if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() != 4)
						{
							num2 = 149;
							continue;
						}
						goto IL_10C2;
					case 285:
						num20 = 115 + 20;
						num2 = 9;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 16;
							continue;
						}
						continue;
					case 286:
						goto IL_40BC;
					case 287:
						array7[9] = array8[4];
						num2 = 29;
						continue;
					case 288:
						dEVOB24MC4I6IS6wh5O.OU12drsYiMS3E4GpePJ(dEVOB24MC4I6IS6wh5O.E3hm5ssc8jJ7LmX2Jje(dEVOB24MC4I6IS6wh5O.knFr7STr9mijWavbLMN(dEVOB24MC4I6IS6wh5O.cmZnlGbI42)));
						num2 = 17;
						continue;
					case 289:
						array[13] = 172 - 57;
						num2 = 343;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 119;
							continue;
						}
						continue;
					case 290:
						array2[num14 + 3] = array11[3];
						num2 = 341;
						continue;
					case 291:
						array[16] = (byte)num20;
						num2 = 39;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 322;
							continue;
						}
						continue;
					case 292:
						array2[num14 + 3] = array17[3];
						num2 = 91;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 59;
							continue;
						}
						continue;
					case 293:
						num16 = 192 - 64;
						num2 = 262;
						continue;
					case 294:
						goto IL_0EF8;
					case 295:
						array[31] = (byte)num20;
						num2 = 271;
						continue;
					case 296:
						array[2] = (byte)num20;
						num2 = 472;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 168;
							continue;
						}
						continue;
					case 297:
						array4[4] = (byte)num16;
						num2 = 110;
						continue;
					case 298:
						dEVOB24MC4I6IS6wh5O.OU12drsYiMS3E4GpePJ(dEVOB24MC4I6IS6wh5O.E3hm5ssc8jJ7LmX2Jje(dEVOB24MC4I6IS6wh5O.knFr7STr9mijWavbLMN(dEVOB24MC4I6IS6wh5O.XfUn6Dk1g0)));
						num2 = 540;
						continue;
					case 299:
						num20 = 246 - 82;
						num2 = 197;
						continue;
					case 300:
						array[8] = (byte)num20;
						num2 = 136;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 465;
							continue;
						}
						continue;
					case 301:
						array4[6] = (byte)num16;
						num2 = 198;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 3;
							continue;
						}
						continue;
					case 302:
						num20 = 113 + 30;
						num2 = 167;
						continue;
					case 303:
						num20 = 129 - 43;
						num2 = 75;
						continue;
					case 304:
						array[18] = (byte)num20;
						num2 = 61;
						continue;
					case 305:
						goto IL_5442;
					case 306:
						array4[13] = 68 + 99;
						num2 = 172;
						continue;
					case 307:
						goto IL_523D;
					case 308:
						array7[5] = array8[2];
						num2 = 41;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 118;
							continue;
						}
						continue;
					case 309:
						goto IL_3447;
					case 310:
						array4[10] = 105 - 78;
						num2 = 596;
						continue;
					case 311:
						num16 = 154 - 51;
						num2 = 517;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 600;
							continue;
						}
						continue;
					case 312:
						array7 = array4;
						num2 = 59;
						continue;
					case 313:
					{
						IntPtr intPtr2;
						string text2;
						intPtr7 = dEVOB24MC4I6IS6wh5O.ItwNX4TX2ErN7NnZTKC((dEVOB24MC4I6IS6wh5O.cYuP8tnVqkj17XJil8R)dEVOB24MC4I6IS6wh5O.OlIPchT3qG9LqUvcUAa(dEVOB24MC4I6IS6wh5O.hbM4vZQqmj(intPtr2, text2), dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O.cYuP8tnVqkj17XJil8R).TypeHandle)));
						num2 = 160;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 383;
							continue;
						}
						continue;
					}
					case 314:
						num61 = intPtr.ToInt64();
						num2 = 41;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 88;
							continue;
						}
						continue;
					case 315:
						array[22] = 155 + 99;
						num2 = 191;
						continue;
					case 316:
						dEVOB24MC4I6IS6wh5O.oKuNBYT5QjVa1NM4Q1L(dEVOB24MC4I6IS6wh5O.fLH4E4T6n6yJKXfH971(ws9cK3nmMI5Apir6GGZ), 0L);
						num2 = 22;
						continue;
					case 317:
						array[16] = (byte)num20;
						num2 = 514;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 491;
							continue;
						}
						continue;
					case 318:
						array4[12] = (byte)num16;
						num2 = 153;
						continue;
					case 319:
						goto IL_4C1A;
					case 320:
						array2[num19 + 3] = array3[3];
						num2 = 255;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 42;
							continue;
						}
						continue;
					case 321:
						array[25] = (byte)num20;
						num2 = 241;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 597;
							continue;
						}
						continue;
					case 322:
						num20 = 14 + 113;
						num2 = 138;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 105;
							continue;
						}
						continue;
					case 323:
						num20 = 199 - 66;
						num2 = 295;
						continue;
					case 324:
						goto IL_50D2;
					case 325:
						if (dEVOB24MC4I6IS6wh5O.GiIYJUTHroCKRWJfsb7(dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O).TypeHandle).Assembly) != null)
						{
							num2 = 376;
							continue;
						}
						goto IL_4303;
					case 326:
						num20 = 134 + 72;
						num2 = 197;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 342;
							continue;
						}
						continue;
					case 327:
						goto IL_523D;
					case 328:
						array6[1] = 115;
						num2 = 15;
						continue;
					case 329:
					{
						byte[] array12;
						num62 = array12.Length / 8;
						num2 = 378;
						continue;
					}
					case 330:
						array[28] = (byte)num20;
						num2 = 578;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 24;
							continue;
						}
						continue;
					case 331:
						array[9] = (byte)num20;
						num2 = 105;
						continue;
					case 332:
						array4[13] = (byte)num16;
						num2 = 311;
						continue;
					case 333:
						if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() == 4)
						{
							num2 = 580;
							continue;
						}
						goto IL_50AF;
					case 334:
						goto IL_4336;
					case 335:
						array[10] = 179 - 64;
						num2 = 636;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 422;
							continue;
						}
						continue;
					case 336:
						array[5] = (byte)num20;
						num2 = 625;
						continue;
					case 337:
					{
						int num63 = dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
						num2 = 635;
						continue;
					}
					case 338:
						goto IL_2D9F;
					case 339:
						num38 = 0;
						num2 = 71;
						continue;
					case 340:
						dEVOB24MC4I6IS6wh5O.txuoH5uw1AFH2bswllb(new IntPtr((void*)(&num40)), 0);
						num2 = 419;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 495;
							continue;
						}
						continue;
					case 341:
						goto IL_1791;
					case 342:
						array[30] = (byte)num20;
						num2 = 418;
						continue;
					case 343:
						array[13] = 180 - 60;
						num2 = 66;
						continue;
					case 344:
						array[1] = 14 + 120;
						num2 = 232;
						continue;
					case 345:
						if (dEVOB24MC4I6IS6wh5O.HnOnyhurnTRGX8YElP6(dEVOB24MC4I6IS6wh5O.OO9ifTuNGbcHG9PukpF(dEVOB24MC4I6IS6wh5O.nAsCfYuE4PRuCXYIwm4(dEVOB24MC4I6IS6wh5O.ryGUNjuibfJKERJPuOE(dEVOB24MC4I6IS6wh5O.CYPJPkudABcUkQv9WD4())), "__", 10U), IntPtr.Zero))
						{
							goto IL_12C0;
						}
						num2 = 400;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 231;
							continue;
						}
						continue;
					case 346:
					{
						CryptoStream cryptoStream;
						dEVOB24MC4I6IS6wh5O.bGrOGvTRD5AGPPSo255(cryptoStream);
						num2 = 218;
						continue;
					}
					case 347:
						dEVOB24MC4I6IS6wh5O.HUYnam2Txx = true;
						num2 = 80;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 180;
							continue;
						}
						continue;
					case 348:
						if (!dEVOB24MC4I6IS6wh5O.HUYnam2Txx)
						{
							num2 = 347;
							continue;
						}
						goto IL_3BE6;
					case 349:
						array4[4] = (byte)num16;
						num2 = 209;
						continue;
					case 350:
						array[9] = (byte)num20;
						num2 = 364;
						continue;
					case 351:
						array4[15] = (byte)num16;
						num2 = 123;
						continue;
					case 352:
						array20 = null;
						num2 = 56;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 80;
							continue;
						}
						continue;
					case 353:
						array[6] = (byte)num20;
						num2 = 42;
						continue;
					case 354:
						array[26] = 68 + 64;
						num2 = 76;
						continue;
					case 355:
						dEVOB24MC4I6IS6wh5O.xrJAoku21r9KI7DPZKu(new IntPtr((void*)(&num40)), 0, 0);
						num2 = 340;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 531;
							continue;
						}
						continue;
					case 356:
						array[23] = 148 - 49;
						num2 = 542;
						continue;
					case 357:
						array2[num19 + 7] = array17[7];
						num2 = 478;
						continue;
					case 358:
					{
						int num65;
						dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(new IntPtr(num64), dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd(), num65, ref num65);
						num2 = 132;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 142;
							continue;
						}
						continue;
					}
					case 359:
						num16 = 236 - 78;
						num2 = 318;
						continue;
					case 360:
						if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() == 4)
						{
							num2 = 445;
							continue;
						}
						goto IL_5C69;
					case 361:
						num16 = 202 - 67;
						num2 = 403;
						continue;
					case 362:
						array2[num19 + 4] = array11[4];
						num2 = 72;
						continue;
					case 363:
						dEVOB24MC4I6IS6wh5O.f0PxycTm2ZWFo91IHPX(dEVOB24MC4I6IS6wh5O.z8hnsiSJh4, 0L, jN4RUZntgB1ECTUw7wi2);
						num2 = 201;
						continue;
					case 364:
						array[10] = 207 - 69;
						num2 = 484;
						continue;
					case 365:
						if (dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(intPtr6, 4, 4, ref num25) == 0)
						{
							goto IL_4336;
						}
						num2 = 223;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 7;
							continue;
						}
						continue;
					case 366:
						array[13] = (byte)num20;
						num2 = 392;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 166;
							continue;
						}
						continue;
					case 367:
						array4[5] = 170 - 56;
						num2 = 592;
						continue;
					case 368:
						dEVOB24MC4I6IS6wh5O.XBDnQJD9re = intPtr.ToInt32();
						num2 = 259;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 172;
							continue;
						}
						continue;
					case 369:
						array[1] = (byte)num20;
						num2 = 344;
						continue;
					case 370:
						array4[1] = 254 - 84;
						num2 = 117;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 56;
							continue;
						}
						continue;
					case 371:
						array[16] = (byte)num20;
						num2 = 624;
						continue;
					case 372:
						goto IL_35B0;
					case 373:
						num20 = 154 - 51;
						num2 = 421;
						continue;
					case 374:
						array7[13] = array8[6];
						num2 = 19;
						continue;
					case 375:
						array4[13] = (byte)num16;
						num2 = 486;
						continue;
					case 376:
						if (dEVOB24MC4I6IS6wh5O.DlTKVoTSO60tWCGRRdq(dEVOB24MC4I6IS6wh5O.GiIYJUTHroCKRWJfsb7(dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O).TypeHandle).Assembly)) > 0)
						{
							num2 = 593;
							continue;
						}
						goto IL_4303;
					case 377:
						array6[1] = 108;
						num2 = 463;
						continue;
					case 378:
					{
						byte[] array12;
						if ((array20 = array12) == null)
						{
							num2 = 62;
							continue;
						}
						goto IL_3043;
					}
					case 379:
						array[0] = 88 + 72;
						num2 = 529;
						continue;
					case 380:
						if (num29 != num30 - 1)
						{
							goto IL_409B;
						}
						num2 = 587;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 22;
							continue;
						}
						continue;
					case 381:
						num14 = 23;
						num2 = 30;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 57;
							continue;
						}
						continue;
					case 382:
						if (array8.Length != 0)
						{
							goto IL_40BC;
						}
						num2 = 61;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 108;
							continue;
						}
						continue;
					case 383:
						num64 = 0L;
						num2 = 333;
						continue;
					case 384:
						array6[3] = 111;
						num2 = 246;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 27;
							continue;
						}
						continue;
					case 385:
						array2[num14 + 1] = array3[1];
						num2 = 141;
						continue;
					case 386:
						array2[num19 + 7] = array11[7];
						num2 = 35;
						continue;
					case 387:
						num20 = 92 + 71;
						num2 = 47;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 388:
						if (dEVOB24MC4I6IS6wh5O.GiIYJUTHroCKRWJfsb7(dEVOB24MC4I6IS6wh5O.Vlk4EuyGno) != null)
						{
							goto Block_108;
						}
						goto IL_5C38;
					case 389:
						num66 = (uint)(num67 * 4);
						num2 = 439;
						continue;
					case 390:
						array4[11] = (byte)num16;
						num2 = 293;
						continue;
					case 391:
						num20 = 210 - 70;
						num2 = 304;
						continue;
					case 392:
						array[13] = 138 - 110;
						num2 = 373;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 24;
							continue;
						}
						continue;
					case 393:
						goto IL_6034;
					case 394:
					{
						IntPtr intPtr2;
						if (!dEVOB24MC4I6IS6wh5O.sfyw4eT2ps5Fov0cmx5(intPtr2, IntPtr.Zero))
						{
							num2 = 404;
							continue;
						}
						goto IL_4B55;
					}
					case 395:
					{
						byte[] array12 = array5;
						num2 = 329;
						continue;
					}
					case 396:
						goto IL_29EF;
					case 397:
						if (num68 > 0)
						{
							num2 = 549;
							continue;
						}
						goto IL_0DCE;
					case 398:
						array7[3] = array8[1];
						num2 = 308;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 299;
							continue;
						}
						continue;
					case 399:
					{
						int num65 = 0;
						num2 = 522;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 417;
							continue;
						}
						continue;
					}
					case 400:
						dEVOB24MC4I6IS6wh5O.kie0wuuzqbvHuU6ZqOt();
						num2 = 576;
						continue;
					case 401:
						goto IL_29BF;
					case 402:
						array4[0] = (byte)num16;
						num2 = 640;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 113;
							continue;
						}
						continue;
					case 403:
						array4[12] = (byte)num16;
						num2 = 250;
						continue;
					case 404:
						goto IL_4770;
					case 405:
						goto IL_25B2;
					case 406:
						array8 = dEVOB24MC4I6IS6wh5O.D04YuNTuWfNKy85thnm(dEVOB24MC4I6IS6wh5O.t9rk2qTe92uxa0VA8a1(dEVOB24MC4I6IS6wh5O.Vlk4EuyGno));
						num2 = 51;
						continue;
					case 407:
						array6[4] = 105;
						num2 = 283;
						continue;
					case 408:
						goto IL_0DDB;
					case 409:
						array4[11] = 132 - 42;
						num2 = 626;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 379;
							continue;
						}
						continue;
					case 410:
						num22 <<= 8;
						num2 = 294;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 588;
							continue;
						}
						continue;
					case 411:
					{
						string text = dEVOB24MC4I6IS6wh5O.jBV6WUTh67VKmPcVQbx(dEVOB24MC4I6IS6wh5O.k3JFp7TLKuY0pCZM5VR(), array6);
						num2 = 515;
						continue;
					}
					case 412:
						array[8] = 72 + 78;
						num2 = 518;
						continue;
					case 413:
						array2[num19 + 1] = array3[1];
						num2 = 100;
						continue;
					case 414:
						goto IL_138D;
					case 415:
						goto IL_5B7B;
					case 416:
					{
						uint num41;
						if (num41 == 4109628145U)
						{
							num2 = 345;
							continue;
						}
						goto IL_12C0;
					}
					case 417:
						dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(intPtr4, 4, 8, ref num25);
						num2 = 443;
						continue;
					case 418:
						array[31] = 1 + 104;
						num2 = 323;
						continue;
					case 419:
						array[17] = 87 + 69;
						num2 = 554;
						continue;
					case 420:
						goto IL_211E;
					case 421:
						array[14] = (byte)num20;
						num2 = 569;
						continue;
					case 422:
						num29 = 0;
						num2 = 570;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 290;
							continue;
						}
						continue;
					case 423:
						array[2] = (byte)num20;
						num2 = 509;
						continue;
					case 424:
						num69 = dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
						num2 = 82;
						continue;
					case 425:
						goto IL_47AE;
					case 426:
						array4[9] = 156 - 52;
						num2 = 258;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 112;
							continue;
						}
						continue;
					case 427:
						array4[11] = 201 - 67;
						num2 = 409;
						continue;
					case 428:
						array[25] = (byte)num20;
						num2 = 183;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 2;
							continue;
						}
						continue;
					case 429:
						dEVOB24MC4I6IS6wh5O.TWc53BuBVyXyGXWOd2G(new byte[1], 0, dEVOB24MC4I6IS6wh5O.cJFiuNuX2yIoUpS6NlZ(8), 1);
						num2 = 319;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 80;
							continue;
						}
						continue;
					case 430:
						array6[0] = 109;
						num2 = 328;
						continue;
					case 431:
						array14[4] = 105;
						num2 = 177;
						continue;
					case 432:
						num20 = 181 - 107;
						num2 = 148;
						continue;
					case 433:
						try
						{
							dEVOB24MC4I6IS6wh5O.cmZnlGbI42 = (dEVOB24MC4I6IS6wh5O.Emi0oknINGwWNmyCUnP)dEVOB24MC4I6IS6wh5O.OlIPchT3qG9LqUvcUAa(new IntPtr(num45), dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O.Emi0oknINGwWNmyCUnP).TypeHandle));
							int num70 = 0;
							if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
							{
								num70 = 0;
							}
							switch (num70)
							{
							default:
								goto IL_4842;
							}
						}
						catch
						{
							int num71 = 0;
							if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
							{
								num71 = 0;
							}
							switch (num71)
							{
							default:
								try
								{
									Delegate @delegate = dEVOB24MC4I6IS6wh5O.OlIPchT3qG9LqUvcUAa(new IntPtr(num45), dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O.Emi0oknINGwWNmyCUnP).TypeHandle));
									int num72 = 0;
									if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
									{
										num72 = 0;
									}
									for (;;)
									{
										switch (num72)
										{
										default:
											dEVOB24MC4I6IS6wh5O.cmZnlGbI42 = (dEVOB24MC4I6IS6wh5O.Emi0oknINGwWNmyCUnP)dEVOB24MC4I6IS6wh5O.FCZKPfTzn2YtX6Stl5Y(dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O.Emi0oknINGwWNmyCUnP).TypeHandle), dEVOB24MC4I6IS6wh5O.knFr7STr9mijWavbLMN(@delegate));
											num72 = 1;
											if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
											{
												num72 = 1;
											}
											break;
										case 1:
											goto IL_295F;
										}
									}
									IL_295F:;
								}
								catch
								{
									int num73 = 0;
									if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
									{
										num73 = 0;
									}
									switch (num73)
									{
									}
								}
								break;
							case 1:
								break;
							}
							goto IL_4842;
						}
						goto IL_29BF;
					case 434:
						goto IL_3362;
					case 435:
						intPtr5 = IntPtr.Zero;
						num2 = 511;
						continue;
					case 436:
						array = new byte[32];
						num2 = 520;
						continue;
					case 437:
						num16 = 25 + 3;
						num2 = 118;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 420;
							continue;
						}
						continue;
					case 438:
					{
						IntPtr intPtr3;
						array11 = dEVOB24MC4I6IS6wh5O.Dckv5pTVPyqLl6nrh0b(intPtr3.ToInt32());
						num2 = 477;
						continue;
					}
					case 439:
					{
						uint num23 = (uint)(((int)array18[(int)(num66 + 3U)] << 24) | ((int)array18[(int)(num66 + 2U)] << 16) | ((int)array18[(int)(num66 + 1U)] << 8) | (int)array18[(int)num66]);
						num2 = 58;
						continue;
					}
					case 440:
						goto IL_3E6A;
					case 441:
						goto IL_4770;
					case 442:
						array2[num19 + 4] = array17[4];
						num2 = 179;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 193;
							continue;
						}
						continue;
					case 443:
						goto IL_119F;
					case 444:
						goto IL_133C;
					case 445:
						num45 = (long)dEVOB24MC4I6IS6wh5O.djmM0NTBqdaiLQfYYUq(new IntPtr(num64));
						num2 = 63;
						continue;
					case 446:
						array[8] = 138 + 80;
						num2 = 504;
						continue;
					case 447:
						if (dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(intPtr8, num50 * 4, 4, ref num25) == 0)
						{
							num2 = 585;
							continue;
						}
						break;
					case 448:
						dEVOB24MC4I6IS6wh5O.oKuNBYT5QjVa1NM4Q1L(dEVOB24MC4I6IS6wh5O.fLH4E4T6n6yJKXfH971(ws9cK3nmMI5Apir6GGZ), 0L);
						num2 = 30;
						continue;
					case 449:
						array4[6] = 170 - 56;
						num2 = 606;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 21;
							continue;
						}
						continue;
					case 450:
						array4[3] = 40 + 94;
						num2 = 613;
						continue;
					case 451:
						goto IL_4763;
					case 452:
						num20 = 152 - 50;
						num2 = 330;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 103;
							continue;
						}
						continue;
					case 453:
						array[2] = (byte)num20;
						num2 = 189;
						continue;
					case 454:
						dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
						num2 = 208;
						continue;
					case 455:
					{
						uint num23 = 0U;
						num2 = 461;
						continue;
					}
					case 456:
						array[31] = (byte)num20;
						num2 = 584;
						continue;
					case 457:
					{
						object obj2 = dEVOB24MC4I6IS6wh5O.tH2ateTgoiobI3YZD4e();
						dEVOB24MC4I6IS6wh5O.nyQQYtTAKL0mujoPutO(obj2, CipherMode.CBC);
						ICryptoTransform cryptoTransform = dEVOB24MC4I6IS6wh5O.RU4PrQTPMqT49AQb15q(obj2, array18, array7);
						num2 = 118;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 136;
							continue;
						}
						continue;
					}
					case 458:
					{
						IntPtr intPtr3;
						array11 = dEVOB24MC4I6IS6wh5O.QFxfwHsMTxuHNRGrihT(intPtr3.ToInt64());
						num2 = 551;
						continue;
					}
					case 459:
						array14[2] = 116;
						num2 = 630;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 590;
							continue;
						}
						continue;
					case 460:
						if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() == 4)
						{
							num2 = 99;
							continue;
						}
						goto IL_3946;
					case 461:
						num27 = 0U;
						num2 = 397;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 286;
							continue;
						}
						continue;
					case 462:
						goto IL_4842;
					case 463:
						array6[2] = 114;
						num2 = 223;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 566;
							continue;
						}
						continue;
					case 464:
						array2[num14 + 2] = array17[2];
						num2 = 142;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 292;
							continue;
						}
						continue;
					case 465:
						array[8] = 158 - 52;
						num2 = 446;
						continue;
					case 466:
						goto IL_2AC8;
					case 467:
						goto IL_5E7F;
					case 468:
						num20 = 55 + 80;
						num2 = 317;
						continue;
					case 469:
						array[10] = (byte)num20;
						num2 = 335;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 11;
							continue;
						}
						continue;
					case 470:
						num20 = 200 - 66;
						num2 = 453;
						continue;
					case 471:
						num74++;
						num2 = 230;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 488;
							continue;
						}
						continue;
					case 472:
						array[2] = 248 - 82;
						num2 = 228;
						continue;
					case 473:
						array[1] = 243 - 81;
						num2 = 256;
						continue;
					case 474:
						jN4RUZntgB1ECTUw7wi2.QacnKmKFnR = new byte[] { 42 };
						num2 = 490;
						continue;
					case 475:
						array[29] = (byte)num20;
						num2 = 103;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 25;
							continue;
						}
						continue;
					case 476:
						array2[num19] = array11[0];
						num2 = 130;
						continue;
					case 477:
						array3 = dEVOB24MC4I6IS6wh5O.Dckv5pTVPyqLl6nrh0b(dEVOB24MC4I6IS6wh5O.AlStJHT0X4Tk7vhedQZ(num45));
						num2 = 327;
						continue;
					case 478:
						num19 = 18;
						num2 = 12;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 4;
							continue;
						}
						continue;
					case 479:
						goto IL_5635;
					case 480:
						goto IL_3835;
					case 481:
						goto IL_4E4D;
					case 482:
						goto IL_604A;
					case 483:
						array[7] = (byte)num20;
						num2 = 235;
						continue;
					case 484:
						num20 = 86 + 47;
						num2 = 208;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 611;
							continue;
						}
						continue;
					case 485:
						array2[num19 + 3] = array17[3];
						num2 = 442;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 199;
							continue;
						}
						continue;
					case 486:
						num16 = 228 - 76;
						num2 = 508;
						continue;
					case 487:
						array6[0] = 99;
						num2 = 377;
						continue;
					case 488:
						goto IL_0B6B;
					case 489:
						goto IL_5442;
					case 490:
						jN4RUZntgB1ECTUw7wi2.MFUnoCMNU0 = false;
						num2 = 363;
						continue;
					case 491:
						array[9] = (byte)num20;
						num2 = 86;
						continue;
					case 492:
						num20 = 235 - 78;
						num2 = 366;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 277;
							continue;
						}
						continue;
					case 493:
						array[21] = 148 - 49;
						num2 = 285;
						continue;
					case 494:
						array[15] = 37 - 1;
						num2 = 468;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 66;
							continue;
						}
						continue;
					case 495:
						dEVOB24MC4I6IS6wh5O.GcMwuru08txgJpb8oql(new IntPtr((void*)(&num40)), 0);
						num2 = 269;
						continue;
					case 496:
						num20 = 155 + 97;
						num2 = 179;
						continue;
					case 497:
						goto IL_138D;
					case 498:
						num69 = dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
						num2 = 52;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 543;
							continue;
						}
						continue;
					case 499:
						num20 = 201 - 67;
						num2 = 469;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 412;
							continue;
						}
						continue;
					case 500:
						array4[8] = 87 + 83;
						num2 = 222;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 150;
							continue;
						}
						continue;
					case 501:
						array4[14] = (byte)num16;
						num2 = 89;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 80;
							continue;
						}
						continue;
					case 502:
						dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(intPtr8, num50 * 4, num25, ref num25);
						num2 = 106;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 28;
							continue;
						}
						continue;
					case 503:
						array4[14] = (byte)num16;
						num2 = 132;
						continue;
					case 504:
						num20 = 83 + 83;
						num2 = 270;
						continue;
					case 505:
						array4[3] = 194 - 64;
						num2 = 440;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 545;
							continue;
						}
						continue;
					case 506:
						array6[9] = 100;
						num2 = 206;
						continue;
					case 507:
						array[0] = (byte)num20;
						num2 = 272;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 81;
							continue;
						}
						continue;
					case 508:
						array4[13] = (byte)num16;
						num2 = 634;
						continue;
					case 509:
						array[2] = 144 + 17;
						num2 = 122;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 57;
							continue;
						}
						continue;
					case 510:
					{
						int num65;
						dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(new IntPtr(num64), dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd(), 64, ref num65);
						num2 = 608;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 70;
							continue;
						}
						continue;
					}
					case 511:
						intPtr5 = dEVOB24MC4I6IS6wh5O.RwMw5FTISKUsGdxgYyt(56U, 1, (uint)dEVOB24MC4I6IS6wh5O.ttj8utTk0uw7Eh69PAG(dEVOB24MC4I6IS6wh5O.CYPJPkudABcUkQv9WD4()));
						num2 = 15;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 460;
							continue;
						}
						continue;
					case 512:
						goto IL_4B55;
					case 513:
						num20 = 30 + 18;
						num2 = 572;
						continue;
					case 514:
						num20 = 79 + 89;
						num2 = 291;
						continue;
					case 515:
					{
						IntPtr intPtr2 = IntPtr.Zero;
						num2 = 394;
						continue;
					}
					case 516:
						num16 = 45 + 119;
						num2 = 34;
						continue;
					case 517:
						goto IL_5E16;
					case 518:
						num20 = 29 + 19;
						num2 = 300;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 264;
							continue;
						}
						continue;
					case 519:
					{
						byte[] array9;
						array10 = array9;
						num2 = 241;
						continue;
					}
					case 520:
						num20 = 45 + 105;
						num2 = 582;
						continue;
					case 521:
						dEVOB24MC4I6IS6wh5O.b17nfTTmm4 = intPtr.ToInt64();
						num2 = 205;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 526;
							continue;
						}
						continue;
					case 522:
						if (dEVOB24MC4I6IS6wh5O.zVVDFaTNeU5XmdyvcId(dEVOB24MC4I6IS6wh5O.KiRYstTEXQJfVSY6BR5(dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O).TypeHandle).Assembly), null))
						{
							num2 = 537;
							continue;
						}
						goto IL_4303;
					case 523:
						array6[5] = 106;
						num2 = 548;
						continue;
					case 524:
						return;
					case 525:
						array2[num14 + 2] = array11[2];
						num2 = 164;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 290;
							continue;
						}
						continue;
					case 526:
						zero = IntPtr.Zero;
						num2 = 602;
						continue;
					case 527:
						num20 = 64 + 124;
						num2 = 428;
						continue;
					case 528:
						num27 = (uint)(((int)array10[(int)(num66 + 3U)] << 24) | ((int)array10[(int)(num66 + 2U)] << 16) | ((int)array10[(int)(num66 + 1U)] << 8) | (int)array10[(int)num66]);
						num2 = 372;
						continue;
					case 529:
						num20 = 143 - 47;
						num2 = 507;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 202;
							continue;
						}
						continue;
					case 530:
						num75++;
						num2 = 143;
						continue;
					case 531:
						goto IL_3BAA;
					case 532:
						num16 = 28 + 49;
						num2 = 210;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 297;
							continue;
						}
						continue;
					case 533:
						return;
					case 534:
						num20 = 102 + 117;
						num2 = 127;
						continue;
					case 535:
						array[21] = (byte)num20;
						num2 = 182;
						continue;
					case 536:
						goto IL_5FD3;
					case 537:
						if (dEVOB24MC4I6IS6wh5O.v44ixxsbiEdPPWHCBxe(dEVOB24MC4I6IS6wh5O.KiRYstTEXQJfVSY6BR5(dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O).TypeHandle).Assembly)).Length != 2)
						{
							goto IL_4303;
						}
						num2 = 325;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 281;
							continue;
						}
						continue;
					case 538:
						array[30] = 237 - 79;
						num2 = 326;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 142;
							continue;
						}
						continue;
					case 539:
						array4[9] = 123 + 63;
						num2 = 205;
						continue;
					case 540:
						array16 = null;
						num2 = 284;
						continue;
					case 541:
						goto IL_35E7;
					case 542:
						array[23] = 244 - 81;
						num2 = 415;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 239;
							continue;
						}
						continue;
					case 543:
						num24 = dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
						num2 = 480;
						continue;
					case 544:
						array14[0] = 103;
						num2 = 112;
						continue;
					case 545:
						array4[3] = 188 - 62;
						num2 = 450;
						continue;
					case 546:
						num20 = 78 + 53;
						num2 = 119;
						continue;
					case 547:
						goto IL_50AF;
					case 548:
						array6[6] = 105;
						num2 = 165;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 187;
							continue;
						}
						continue;
					case 549:
						num30++;
						num2 = 607;
						continue;
					case 550:
						array[21] = (byte)num20;
						num2 = 40;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 95;
							continue;
						}
						continue;
					case 551:
						array3 = dEVOB24MC4I6IS6wh5O.QFxfwHsMTxuHNRGrihT(num45);
						num2 = 307;
						continue;
					case 552:
						num74 = 0;
						num2 = 244;
						continue;
					case 553:
						goto IL_4888;
					case 554:
						array[18] = 201 - 67;
						num2 = 81;
						continue;
					case 555:
						num20 = 187 + 31;
						num2 = 483;
						continue;
					case 556:
						array6[8] = 46;
						num2 = 506;
						continue;
					case 557:
						goto IL_5C38;
					case 558:
						goto IL_596E;
					case 559:
						goto IL_4186;
					case 560:
						array[20] = 67 - 7;
						num2 = 247;
						continue;
					case 561:
						goto IL_4473;
					case 562:
						goto IL_35B0;
					case 563:
					{
						IntPtr intPtr3 = dEVOB24MC4I6IS6wh5O.E0T8krTdijxsNK8iJZa(dEVOB24MC4I6IS6wh5O.XfUn6Dk1g0);
						num2 = 278;
						continue;
					}
					case 564:
						dEVOB24MC4I6IS6wh5O.ICg4YnTTsacr9O4RysL(array8, 0, array8.Length);
						num2 = 3;
						continue;
					case 565:
						if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() != 4)
						{
							goto IL_42B8;
						}
						num2 = 296;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 575;
							continue;
						}
						continue;
					case 566:
						array6[3] = 106;
						num2 = 407;
						continue;
					case 567:
						array4[12] = 122 + 110;
						num2 = 347;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 359;
							continue;
						}
						continue;
					case 568:
						dEVOB24MC4I6IS6wh5O.Wuhn5TiYrT = intPtr.ToInt64();
						num2 = 52;
						continue;
					case 569:
						array[14] = 174 - 58;
						num2 = 65;
						continue;
					case 570:
						goto IL_4888;
					case 571:
						dEVOB24MC4I6IS6wh5O.WrXnWSmHC2 = false;
						num2 = 417;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 510;
							continue;
						}
						continue;
					case 572:
						array[16] = (byte)num20;
						num2 = 120;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 124;
							continue;
						}
						continue;
					case 573:
						array3 = null;
						num2 = 251;
						continue;
					case 574:
						num76++;
						num2 = 47;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 64;
							continue;
						}
						continue;
					case 575:
						array17 = dEVOB24MC4I6IS6wh5O.Dckv5pTVPyqLl6nrh0b(dEVOB24MC4I6IS6wh5O.hl6nusJDq3.ToInt32());
						num2 = 438;
						continue;
					case 576:
						return;
					case 577:
						num16 = 61 + 79;
						num2 = 637;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 320;
							continue;
						}
						continue;
					case 578:
						num20 = 211 - 70;
						num2 = 61;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 481;
							continue;
						}
						continue;
					case 579:
						goto IL_3B56;
					case 580:
						num64 = (long)dEVOB24MC4I6IS6wh5O.djmM0NTBqdaiLQfYYUq(intPtr7);
						num2 = 54;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 68;
							continue;
						}
						continue;
					case 581:
						num20 = 83 + 76;
						num2 = 1;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 14;
							continue;
						}
						continue;
					case 582:
						array[0] = (byte)num20;
						num2 = 379;
						continue;
					case 583:
						goto IL_18B4;
					case 584:
						array18 = array;
						num2 = 79;
						continue;
					case 585:
						goto IL_145B;
					case 586:
						dEVOB24MC4I6IS6wh5O.f0PxycTm2ZWFo91IHPX(dEVOB24MC4I6IS6wh5O.z8hnsiSJh4, num61 + (long)num77, jN4RUZntgB1ECTUw7wi);
						num2 = 85;
						continue;
					case 587:
						if (num68 <= 0)
						{
							goto IL_409B;
						}
						num2 = 98;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 84;
							continue;
						}
						continue;
					case 588:
						num21 += 8;
						num2 = 249;
						continue;
					case 589:
						array[28] = 172 - 57;
						num2 = 145;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 176;
							continue;
						}
						continue;
					case 590:
						num16 = 126 - 42;
						num2 = 202;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 351;
							continue;
						}
						continue;
					case 591:
						goto IL_47C1;
					case 592:
						num16 = 168 - 123;
						num2 = 517;
						continue;
					case 593:
						dEVOB24MC4I6IS6wh5O.kie0wuuzqbvHuU6ZqOt();
						num2 = 533;
						continue;
					case 594:
						array[6] = 114 + 114;
						num2 = 302;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 255;
							continue;
						}
						continue;
					case 595:
						dEVOB24MC4I6IS6wh5O.HV1n7I6yHa = dEVOB24MC4I6IS6wh5O.AlStJHT0X4Tk7vhedQZ(dEVOB24MC4I6IS6wh5O.Wuhn5TiYrT);
						num2 = 60;
						continue;
					case 596:
						num16 = 209 - 69;
						num2 = 313;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 390;
							continue;
						}
						continue;
					case 597:
						array[26] = 171 - 57;
						num2 = 354;
						continue;
					case 598:
						array[17] = 181 - 60;
						num2 = 419;
						continue;
					case 599:
						num40 = 0L;
						num2 = 340;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 105;
							continue;
						}
						continue;
					case 600:
						array4[13] = (byte)num16;
						num2 = 306;
						continue;
					case 601:
						goto IL_2DC2;
					case 602:
						num37 = 0;
						num2 = 497;
						continue;
					case 603:
						array2[num14 + 3] = array3[3];
						num2 = 381;
						continue;
					case 604:
						goto IL_505B;
					case 605:
						num27 = 0U;
						num2 = 224;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 339;
							continue;
						}
						continue;
					case 606:
						array4[6] = 114 + 46;
						num2 = 277;
						continue;
					case 607:
						goto IL_0DCE;
					case 608:
						goto IL_1F9A;
					case 609:
						array4[5] = 105 + 20;
						num2 = 437;
						continue;
					case 610:
						goto IL_515E;
					case 611:
						array[10] = (byte)num20;
						num2 = 546;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 261;
							continue;
						}
						continue;
					case 612:
						array5[num17] = (byte)(num18 & 255U);
						num2 = 11;
						continue;
					case 613:
						goto IL_61BB;
					case 614:
						num34 = 0;
						num2 = 388;
						continue;
					case 615:
						goto IL_36A6;
					case 616:
						array[4] = (byte)num20;
						num2 = 2;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 1;
							continue;
						}
						continue;
					case 617:
						array4[1] = 50 - 37;
						num2 = 516;
						continue;
					case 618:
						array[19] = 87 - 5;
						num2 = 387;
						continue;
					case 619:
						num16 = 217 - 72;
						num2 = 503;
						continue;
					case 620:
						goto IL_10C2;
					case 621:
						if (num68 > 0)
						{
							num2 = 158;
							continue;
						}
						goto IL_1F8C;
					case 622:
						goto IL_5C69;
					case 623:
						num20 = 143 - 47;
						num2 = 157;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 28;
							continue;
						}
						continue;
					case 624:
						num20 = 97 + 72;
						num2 = 237;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 48;
							continue;
						}
						continue;
					case 625:
						array[6] = 119 + 43;
						num2 = 558;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 527;
							continue;
						}
						continue;
					case 626:
						goto IL_60C6;
					case 627:
						num30 = array10.Length / 4;
						num2 = 27;
						continue;
					case 628:
						num20 = 179 + 25;
						num2 = 319;
						if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 336;
							continue;
						}
						continue;
					case 629:
						array[27] = 90 + 77;
						num2 = 73;
						continue;
					case 630:
						array14[3] = 74;
						num2 = 431;
						continue;
					case 631:
						goto IL_3CF5;
					case 632:
						num20 = 168 + 81;
						num2 = 188;
						if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
						{
							num2 = 91;
							continue;
						}
						continue;
					case 633:
						array[24] = 169 + 73;
						num2 = 134;
						continue;
					case 634:
						num16 = 239 - 79;
						num2 = 332;
						continue;
					case 635:
					{
						int num63;
						intPtr8 = new IntPtr(dEVOB24MC4I6IS6wh5O.b17nfTTmm4 + (long)num63 - (long)num34);
						num2 = 112;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
						{
							num2 = 213;
							continue;
						}
						continue;
					}
					case 636:
						array[11] = 201 - 67;
						num2 = 84;
						continue;
					case 637:
						goto IL_4676;
					case 638:
						num16 = 45 + 1;
						num2 = 24;
						if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
						{
							num2 = 7;
							continue;
						}
						continue;
					case 639:
						break;
					case 640:
						array4[0] = 11 + 17;
						num2 = 240;
						continue;
					case 641:
						num17 = num29 * 4;
						num2 = 389;
						continue;
					case 642:
						goto IL_1F8C;
					default:
						goto IL_0BAC;
					}
					num76 = 0;
					num2 = 26;
					continue;
					IL_0B6B:
					if (num74 >= num68)
					{
						num2 = 282;
						continue;
					}
					goto IL_3447;
					IL_0BAC:
					num16 = 203 + 17;
					num2 = 6;
					if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 13;
						continue;
					}
					continue;
					IL_0C48:
					dEVOB24MC4I6IS6wh5O.txuoH5uw1AFH2bswllb(intPtr7, 0);
					num2 = 6;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 236;
						continue;
					}
					continue;
					IL_0DCE:
					num66 = 0U;
					num2 = 422;
					continue;
					IL_0DDB:
					if (num28 < num69)
					{
						goto IL_29BF;
					}
					num2 = 12;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 173;
						continue;
					}
					continue;
					IL_0EA8:
					array6 = new byte[12];
					num2 = 430;
					continue;
					IL_0EF8:
					process = dEVOB24MC4I6IS6wh5O.CYPJPkudABcUkQv9WD4();
					num2 = 53;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 181;
						continue;
					}
					continue;
					IL_10C2:
					byte[] array21 = new byte[30];
					dEVOB24MC4I6IS6wh5O.qZ32RosJbk5LPPTkmyp(array21, fieldof(<PrivateImplementationDetails>{65B6CF8C-BEEE-4E67-B251-3CC183A8F712}.D5B7247C497788CF0031CEB06E3DF77A45FEF59F1E49633DC7159816D64759B5).FieldHandle);
					array16 = array21;
					num2 = 153;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 242;
						continue;
					}
					continue;
					IL_10F0:
					if (dEVOB24MC4I6IS6wh5O.AARf8QTtBX8o5DkbT9Y(dEVOB24MC4I6IS6wh5O.fLH4E4T6n6yJKXfH971(ws9cK3nmMI5Apir6GGZ)) < dEVOB24MC4I6IS6wh5O.n08DHyT7pRQZeOUHlRu(dEVOB24MC4I6IS6wh5O.fLH4E4T6n6yJKXfH971(ws9cK3nmMI5Apir6GGZ)) - 1L)
					{
						num2 = 337;
						continue;
					}
					goto IL_50D2;
					IL_119F:
					dEVOB24MC4I6IS6wh5O.ckGk4LToXTHpjeGOPxT(intPtr4, dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ));
					num2 = 254;
					continue;
					IL_12C0:
					if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() != 4)
					{
						goto IL_4473;
					}
					num2 = 225;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
					{
						num2 = 61;
						continue;
					}
					continue;
					IL_12E5:
					if (dEVOB24MC4I6IS6wh5O.AARf8QTtBX8o5DkbT9Y(dEVOB24MC4I6IS6wh5O.fLH4E4T6n6yJKXfH971(ws9cK3nmMI5Apir6GGZ)) < dEVOB24MC4I6IS6wh5O.n08DHyT7pRQZeOUHlRu(dEVOB24MC4I6IS6wh5O.fLH4E4T6n6yJKXfH971(ws9cK3nmMI5Apir6GGZ)) - 1L)
					{
						num2 = 159;
						continue;
					}
					goto IL_515E;
					IL_138D:
					if (num37 < num69)
					{
						goto IL_5262;
					}
					num2 = 6;
					if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 109;
						continue;
					}
					continue;
					IL_1960:
					dEVOB24MC4I6IS6wh5O.TXH4Ck5rPu(intPtr5, intPtr6, dEVOB24MC4I6IS6wh5O.Dckv5pTVPyqLl6nrh0b(dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ)), 4U, out zero);
					num2 = 17;
					if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 70;
						continue;
					}
					continue;
					IL_3362:
					if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() == 4)
					{
						num2 = 248;
						continue;
					}
					goto IL_1960;
					IL_1F63:
					num20 = 162 - 90;
					num2 = 5;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 94;
						continue;
					}
					continue;
					IL_1F8C:
					num66 = (uint)num17;
					num2 = 69;
					continue;
					IL_2046:
					num67 = num29 % num39;
					num2 = 641;
					if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 45;
						continue;
					}
					continue;
					IL_4888:
					if (num29 >= num30)
					{
						num2 = 395;
						continue;
					}
					goto IL_2046;
					IL_2090:
					if (num38 <= 0)
					{
						goto IL_5F32;
					}
					num2 = 171;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
					{
						num2 = 4;
						continue;
					}
					continue;
					IL_47AE:
					if (num38 >= num68)
					{
						num2 = 562;
						continue;
					}
					goto IL_2090;
					IL_3835:
					if (num24 == 1)
					{
						num2 = 435;
						continue;
					}
					num28 = 0;
					num2 = 408;
					continue;
					IL_25B2:
					byte* ptr2 = &array20[0];
					num2 = 363;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 583;
						continue;
					}
					continue;
					IL_29BF:
					intPtr4 = new IntPtr(num61 + (long)dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ) - (long)num34);
					num2 = 155;
					if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 50;
						continue;
					}
					continue;
					IL_2AC8:
					dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(intPtr6, 4, num25, ref num25);
					num2 = 98;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 145;
						continue;
					}
					continue;
					IL_3043:
					if (array20.Length == 0)
					{
						goto IL_4186;
					}
					num2 = 113;
					if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 405;
						continue;
					}
					continue;
					IL_3066:
					if (num76 >= num50)
					{
						num2 = 502;
						continue;
					}
					goto IL_35E7;
					IL_3447:
					if (num74 <= 0)
					{
						goto IL_4F07;
					}
					num2 = 396;
					if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 410;
						continue;
					}
					continue;
					IL_35B0:
					num4 = num4;
					num2 = 5;
					continue;
					IL_35E7:
					dEVOB24MC4I6IS6wh5O.ckGk4LToXTHpjeGOPxT(new IntPtr(intPtr8.ToInt64() + (long)(num76 * 4)), dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ));
					num2 = 574;
					if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 447;
						continue;
					}
					continue;
					IL_36A6:
					if (num51 >= num62)
					{
						num2 = 352;
						continue;
					}
					goto IL_37CC;
					IL_25A3:
					goto IL_36A6;
					IL_37CC:
					*(long*)(ptr2 + num51 * 8) ^= 1374805551L;
					num2 = 229;
					continue;
					IL_3BE6:
					dEVOB24MC4I6IS6wh5O.kie0wuuzqbvHuU6ZqOt();
					num2 = 30;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 53;
						continue;
					}
					continue;
					IL_3E6A:
					num49 = dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
					num2 = 196;
					continue;
					IL_409B:
					num18 = num4 ^ num27;
					num2 = 612;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
					{
						num2 = 189;
						continue;
					}
					continue;
					IL_40BC:
					array7[1] = array8[0];
					num2 = 398;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
					{
						num2 = 68;
						continue;
					}
					continue;
					IL_4186:
					ptr2 = null;
					num2 = 21;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 21;
						continue;
					}
					continue;
					IL_42B8:
					array17 = dEVOB24MC4I6IS6wh5O.QFxfwHsMTxuHNRGrihT(dEVOB24MC4I6IS6wh5O.hl6nusJDq3.ToInt64());
					num2 = 458;
					continue;
					IL_4303:
					num2 = 279;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
					{
						num2 = 124;
						continue;
					}
					continue;
					IL_4336:
					dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(intPtr6, 4, 8, ref num25);
					num2 = 376;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 434;
						continue;
					}
					continue;
					IL_4473:
					ws9cK3nmMI5Apir6GGZ = new dEVOB24MC4I6IS6wh5O.ws9cK3nmMI5Apir6GGZ(dEVOB24MC4I6IS6wh5O.NdSPiKTlLY6Cq3eesen(dEVOB24MC4I6IS6wh5O.Vlk4EuyGno, "ErjMaKcRCbZ89WBCC8.h9085wY5KYnFsoOy1r"));
					num2 = 316;
					continue;
					IL_4676:
					array4[15] = (byte)num16;
					num2 = 63;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 338;
						continue;
					}
					continue;
					IL_4763:
					num19 = 2;
					num2 = 253;
					continue;
					IL_523D:
					if (dEVOB24MC4I6IS6wh5O.bGedDFTb37GmK5xiLTd() != 4)
					{
						goto IL_4763;
					}
					num2 = 2;
					if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 195;
						continue;
					}
					continue;
					IL_4770:
					array14 = new byte[6];
					num2 = 407;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 544;
						continue;
					}
					continue;
					IL_47C1:
					intPtr9 = dEVOB24MC4I6IS6wh5O.vEKylesDpJQZcEQM6Vn(IntPtr.Zero, (uint)array16.Length, 4096U, 64U);
					num2 = 210;
					if (!dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 29;
						continue;
					}
					continue;
					IL_4842:
					IntPtr zero2 = IntPtr.Zero;
					num2 = 399;
					continue;
					IL_4B55:
					array6 = new byte[10];
					num2 = 487;
					continue;
					IL_4F07:
					array5[num17 + num74] = (byte)((num26 & num22) >> num21);
					num2 = 294;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 471;
						continue;
					}
					continue;
					IL_505B:
					if (num75 >= array7.Length)
					{
						num2 = 519;
						continue;
					}
					goto IL_5635;
					IL_50AF:
					num64 = dEVOB24MC4I6IS6wh5O.R2WAG8T8RbTmpdvftmw(intPtr7);
					num2 = 7;
					if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 44;
						continue;
					}
					continue;
					IL_515E:
					intPtr = dEVOB24MC4I6IS6wh5O.y814LCTqksuM9DM9hf9(dEVOB24MC4I6IS6wh5O.h7gmRlTseLATrmB6CV8(dEVOB24MC4I6IS6wh5O.Yyyvk5TwtrunOgd0omR(typeof(dEVOB24MC4I6IS6wh5O).TypeHandle).Assembly)[0]);
					num2 = 568;
					continue;
					IL_5185:
					dEVOB24MC4I6IS6wh5O.rjJVyhsFF1nYV6ymRr7(dEVOB24MC4I6IS6wh5O.cmZnlGbI42);
					num2 = 57;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 288;
						continue;
					}
					continue;
					IL_5230:
					num75 = 0;
					num2 = 604;
					continue;
					IL_5262:
					intPtr6 = new IntPtr(dEVOB24MC4I6IS6wh5O.b17nfTTmm4 + (long)dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ) - (long)num34);
					num2 = 365;
					continue;
					IL_5442:
					dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ);
					num2 = 454;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
					{
						num2 = 91;
						continue;
					}
					continue;
					IL_5635:
					array18[num75] ^= array7[num75];
					num2 = 525;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 530;
						continue;
					}
					continue;
					IL_596E:
					array[6] = 123 + 31;
					num2 = 594;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
					{
						num2 = 395;
						continue;
					}
					continue;
					IL_59D0:
					enumerator = dEVOB24MC4I6IS6wh5O.mpXwZwT9BESV7F8DNe9(dEVOB24MC4I6IS6wh5O.NHfV1TTU8Q9mRribLDx(dEVOB24MC4I6IS6wh5O.CYPJPkudABcUkQv9WD4()));
					num2 = 264;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() != null)
					{
						num2 = 135;
						continue;
					}
					continue;
					IL_5A19:
					num29++;
					num2 = 553;
					continue;
					IL_5C38:
					num34 = 7680;
					num2 = 106;
					if (dEVOB24MC4I6IS6wh5O.VxGXXYum3fMlyJmbbHJ() == null)
					{
						num2 = 305;
						continue;
					}
					continue;
					IL_5C69:
					num45 = dEVOB24MC4I6IS6wh5O.R2WAG8T8RbTmpdvftmw(new IntPtr(num64));
					num2 = 66;
					if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 294;
						continue;
					}
					continue;
					IL_5E7F:
					num2 = 43;
					if (dEVOB24MC4I6IS6wh5O.ahwms6uKS3xG1M7rnPg())
					{
						num2 = 114;
						continue;
					}
					continue;
					IL_5F32:
					num27 |= (uint)array10[array10.Length - (1 + num38)];
					num2 = 165;
				}
				IL_0ACF:
				array[29] = (byte)num20;
				num = 199;
				continue;
				IL_0B24:
				num14 = 16;
				num = 6;
				continue;
				IL_0CCF:
				array[15] = 231 - 77;
				num = 494;
				continue;
				Block_19:
				num = 276;
				continue;
				IL_0F99:
				num16 = 14 + 51;
				num = 252;
				continue;
				IL_133C:
				array[29] = 141 - 105;
				num = 226;
				continue;
				IL_145B:
				dEVOB24MC4I6IS6wh5O.Foe4kWxPMn(intPtr8, num50 * 4, 8, ref num25);
				num = 639;
				continue;
				IL_1718:
				num16 = 243 - 81;
				num = 375;
				continue;
				IL_18B4:
				num51 = 0;
				num = 90;
				continue;
				IL_4CF2:
				goto IL_18B4;
				IL_1993:
				array2[num14 + 2] = array3[2];
				num = 603;
				continue;
				IL_1F9A:
				dEVOB24MC4I6IS6wh5O.qU1jc8sZegyZxx2PTkr(new IntPtr(num64), intPtr9);
				num = 358;
				continue;
				IL_211E:
				array4[5] = (byte)num16;
				num = 367;
				continue;
				IL_21A7:
				num20 = 187 + 30;
				num = 353;
				continue;
				IL_29EF:
				num19 = 30;
				num = 476;
				continue;
				IL_2A89:
				num68 = array10.Length % 4;
				num = 627;
				continue;
				IL_2D10:
				jN4RUZntgB1ECTUw7wi2 = default(dEVOB24MC4I6IS6wh5O.jN4RUZntgB1ECTUw7wi);
				num = 474;
				continue;
				Block_108:
				num = 4;
				continue;
				IL_2D9F:
				array4[15] = 56 + 89;
				num = 312;
				continue;
				IL_2DC2:
				array2[num19 + 6] = array17[6];
				num = 357;
				continue;
				IL_34E5:
				array6[7] = 116;
				num = 556;
				continue;
				IL_3946:
				intPtr = dEVOB24MC4I6IS6wh5O.y814LCTqksuM9DM9hf9(dEVOB24MC4I6IS6wh5O.h7gmRlTseLATrmB6CV8(dEVOB24MC4I6IS6wh5O.Vlk4EuyGno)[0]);
				num = 521;
				continue;
				IL_3B56:
				array2[num14 + 1] = array11[1];
				num = 525;
				continue;
				IL_3BAA:
				dEVOB24MC4I6IS6wh5O.xV4PfEu3pBNZX2UHtXY(new IntPtr((void*)(&num40)), 0, 0L);
				num = 429;
				continue;
				IL_3CF5:
				array2[num19 + 2] = array11[2];
				num = 115;
				continue;
				IL_3F3D:
				array6[5] = 116;
				num = 274;
				continue;
				IL_4052:
				num77 = dEVOB24MC4I6IS6wh5O.ooAYmhTpgTTaNXnMjVB(ws9cK3nmMI5Apir6GGZ) - num34;
				num = 7;
				continue;
				IL_4289:
				array[12] = (byte)num20;
				num = 194;
				continue;
				IL_4792:
				dEVOB24MC4I6IS6wh5O.TWc53BuBVyXyGXWOd2G(array2, 0, intPtr9, array2.Length);
				num = 571;
				continue;
				IL_1791:
				goto IL_4792;
				IL_4C1A:
				dEVOB24MC4I6IS6wh5O.nuIX2Au8G302Z4RjEMI();
				num = 416;
				continue;
				IL_4D01:
				dEVOB24MC4I6IS6wh5O.ICg4YnTTsacr9O4RysL(array18, 0, array18.Length);
				num = 67;
				continue;
				IL_4E4D:
				array[28] = (byte)num20;
				num = 589;
				continue;
				IL_4FB9:
				array[14] = (byte)num20;
				num = 202;
				continue;
				IL_50D2:
				dEVOB24MC4I6IS6wh5O.jQxlBITKiZyS8UiA8qI(intPtr5);
				num = 265;
				continue;
				IL_51A9:
				num20 = 73 + 12;
				num = 475;
				continue;
				IL_5464:
				dEVOB24MC4I6IS6wh5O.cmZnlGbI42 = null;
				num = 433;
				continue;
				Block_244:
				num = 489;
				continue;
				IL_5580:
				array2[num19 + 2] = array17[2];
				num = 485;
				continue;
				IL_599D:
				array[22] = 206 - 68;
				num = 168;
				continue;
				IL_5B7B:
				array[23] = 66 + 100;
				num = 632;
				continue;
				IL_5E16:
				array4[5] = (byte)num16;
				num = 449;
				continue;
				IL_5FD3:
				array4[9] = 152 - 50;
				num = 539;
				continue;
				IL_6034:
				jN4RUZntgB1ECTUw7wi = default(dEVOB24MC4I6IS6wh5O.jN4RUZntgB1ECTUw7wi);
				num = 83;
				continue;
				IL_604A:
				array[7] = (byte)num20;
				num = 111;
				continue;
				IL_60C6:
				array4[12] = 131 - 43;
				num = 567;
				continue;
				IL_61BB:
				num16 = 69 + 3;
				num = 169;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000A5B4 File Offset: 0x000087B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object FSi4PAsBHQ(object \u0020)
		{
			try
			{
				if (File.Exists(((Assembly)\u0020).Location))
				{
					return ((Assembly)\u0020).Location;
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(((Assembly)\u0020).GetName().CodeBase.ToString().Replace("file:///", "")))
				{
					return ((Assembly)\u0020).GetName().CodeBase.ToString().Replace("file:///", "");
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(\u0020.GetType().GetProperty("Location").GetValue(\u0020, new object[0])
					.ToString()))
				{
					return \u0020.GetType().GetProperty("Location").GetValue(\u0020, new object[0])
						.ToString();
				}
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x060000C7 RID: 199
		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr z9L4j6VkPR(string \u0020);

		// Token: 0x060000C8 RID: 200
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		public static extern IntPtr hbM4vZQqmj(IntPtr \u0020, string \u0020);

		// Token: 0x060000C9 RID: 201 RVA: 0x0000A6E4 File Offset: 0x000088E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr Wbw4O7E5GG(IntPtr \u0020, object \u0020, uint \u0020)
		{
			if (dEVOB24MC4I6IS6wh5O.hgfnqOUHR0 == null)
			{
				dEVOB24MC4I6IS6wh5O.hgfnqOUHR0 = (dEVOB24MC4I6IS6wh5O.FPtM6Kn3y2Er4H8simZ)Marshal.GetDelegateForFunctionPointer(dEVOB24MC4I6IS6wh5O.hbM4vZQqmj(dEVOB24MC4I6IS6wh5O.xTuFFuFOZ(), "Find ".Trim() + "ResourceA"), typeof(dEVOB24MC4I6IS6wh5O.FPtM6Kn3y2Er4H8simZ));
			}
			return dEVOB24MC4I6IS6wh5O.hgfnqOUHR0(\u0020, \u0020, \u0020);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000A740 File Offset: 0x00008940
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr GUw4RWBl0F(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			if (dEVOB24MC4I6IS6wh5O.yIZnHc4krX == null)
			{
				dEVOB24MC4I6IS6wh5O.yIZnHc4krX = (dEVOB24MC4I6IS6wh5O.Arg54nnX2QE6ar98yWc)Marshal.GetDelegateForFunctionPointer(dEVOB24MC4I6IS6wh5O.hbM4vZQqmj(dEVOB24MC4I6IS6wh5O.xTuFFuFOZ(), "Virtual ".Trim() + "Alloc"), typeof(dEVOB24MC4I6IS6wh5O.Arg54nnX2QE6ar98yWc));
			}
			return dEVOB24MC4I6IS6wh5O.yIZnHc4krX(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000A79C File Offset: 0x0000899C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int TXH4Ck5rPu(IntPtr \u0020, IntPtr \u0020, [In] [Out] byte[] \u0020, uint \u0020, out IntPtr \u0020)
		{
			if (dEVOB24MC4I6IS6wh5O.M2wnS0pJC2 == null)
			{
				dEVOB24MC4I6IS6wh5O.M2wnS0pJC2 = (dEVOB24MC4I6IS6wh5O.KiM826nBuyJfvu0fGLe)Marshal.GetDelegateForFunctionPointer(dEVOB24MC4I6IS6wh5O.hbM4vZQqmj(dEVOB24MC4I6IS6wh5O.xTuFFuFOZ(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(dEVOB24MC4I6IS6wh5O.KiM826nBuyJfvu0fGLe));
			}
			return dEVOB24MC4I6IS6wh5O.M2wnS0pJC2(\u0020, \u0020, \u0020, \u0020, out \u0020);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000A804 File Offset: 0x00008A04
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int Foe4kWxPMn(IntPtr \u0020, int \u0020, int \u0020, ref int \u0020)
		{
			if (dEVOB24MC4I6IS6wh5O.jb5npOHLpm == null)
			{
				dEVOB24MC4I6IS6wh5O.jb5npOHLpm = (dEVOB24MC4I6IS6wh5O.r7NALRn8JyD3vpS9OlP)Marshal.GetDelegateForFunctionPointer(dEVOB24MC4I6IS6wh5O.hbM4vZQqmj(dEVOB24MC4I6IS6wh5O.xTuFFuFOZ(), "Virtual ".Trim() + "Protect"), typeof(dEVOB24MC4I6IS6wh5O.r7NALRn8JyD3vpS9OlP));
			}
			return dEVOB24MC4I6IS6wh5O.jb5npOHLpm(\u0020, \u0020, \u0020, ref \u0020);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000A860 File Offset: 0x00008A60
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr rVk4IyKfPZ(uint \u0020, int \u0020, uint \u0020)
		{
			if (dEVOB24MC4I6IS6wh5O.rgBngb5YYc == null)
			{
				dEVOB24MC4I6IS6wh5O.rgBngb5YYc = (dEVOB24MC4I6IS6wh5O.tjTLyNnd4nqyV1NpCpU)Marshal.GetDelegateForFunctionPointer(dEVOB24MC4I6IS6wh5O.hbM4vZQqmj(dEVOB24MC4I6IS6wh5O.xTuFFuFOZ(), "Open ".Trim() + "Process"), typeof(dEVOB24MC4I6IS6wh5O.tjTLyNnd4nqyV1NpCpU));
			}
			return dEVOB24MC4I6IS6wh5O.rgBngb5YYc(\u0020, \u0020, \u0020);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000A8BC File Offset: 0x00008ABC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int sH74VqiHhq(IntPtr \u0020)
		{
			if (dEVOB24MC4I6IS6wh5O.plinAkpBZd == null)
			{
				dEVOB24MC4I6IS6wh5O.plinAkpBZd = (dEVOB24MC4I6IS6wh5O.SUE4l5niQD7TvrP1nlp)Marshal.GetDelegateForFunctionPointer(dEVOB24MC4I6IS6wh5O.hbM4vZQqmj(dEVOB24MC4I6IS6wh5O.xTuFFuFOZ(), "Close ".Trim() + "Handle"), typeof(dEVOB24MC4I6IS6wh5O.SUE4l5niQD7TvrP1nlp));
			}
			return dEVOB24MC4I6IS6wh5O.plinAkpBZd(\u0020);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000A918 File Offset: 0x00008B18
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr xTuFFuFOZ()
		{
			if (dEVOB24MC4I6IS6wh5O.zCCnPbPELo == IntPtr.Zero)
			{
				dEVOB24MC4I6IS6wh5O.zCCnPbPELo = dEVOB24MC4I6IS6wh5O.z9L4j6VkPR("kernel ".Trim() + "32.dll");
			}
			return dEVOB24MC4I6IS6wh5O.zCCnPbPELo;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000A954 File Offset: 0x00008B54
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] NTr4tn2sVe(object \u0020)
		{
			byte[] array;
			using (FileStream fileStream = new FileStream(\u0020, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				int num = 0;
				int i = (int)fileStream.Length;
				array = new byte[i];
				while (i > 0)
				{
					int num2 = fileStream.Read(array, num, i);
					num += num2;
					i -= num2;
				}
			}
			return array;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000A9C0 File Offset: 0x00008BC0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Stream vv84oGsPbI()
		{
			return new MemoryStream();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000A9C8 File Offset: 0x00008BC8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] s1U4KTdmgC(object \u0020)
		{
			return ((MemoryStream)\u0020).ToArray();
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000A9D8 File Offset: 0x00008BD8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] WDr4mov74v(object \u0020)
		{
			Stream stream = dEVOB24MC4I6IS6wh5O.vv84oGsPbI();
			SymmetricAlgorithm symmetricAlgorithm = dEVOB24MC4I6IS6wh5O.iEX4xSluhd();
			symmetricAlgorithm.Key = new byte[]
			{
				76, 211, 38, 217, 219, 116, 162, 36, 204, 170,
				6, 152, 83, 210, 114, 31, 200, 25, 218, 254,
				169, 109, 73, 134, 25, 48, 241, 131, 103, 251,
				111, 156
			};
			symmetricAlgorithm.IV = new byte[]
			{
				177, 175, 252, 118, 43, 21, 163, 182, 243, 78,
				176, 72, 236, 141, 195, 40
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(\u0020, 0, \u0020.Length);
			cryptoStream.Close();
			byte[] array = dEVOB24MC4I6IS6wh5O.s1U4KTdmgC(stream);
			va9CPUnNBvtHv0t2JTs.hCMutNHB4P();
			return array;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000AA4C File Offset: 0x00008C4C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] ETP4woloAY()
		{
			return null;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000AA5C File Offset: 0x00008C5C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] bHN407QECP()
		{
			return null;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000AA6C File Offset: 0x00008C6C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] oc34LcOBs5()
		{
			int length = "{11111-22222-20001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000AA8C File Offset: 0x00008C8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] bpV4hGaiN1()
		{
			int length = "{11111-22222-20001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000AAAC File Offset: 0x00008CAC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] Tq0422gkWO()
		{
			return null;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000AABC File Offset: 0x00008CBC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] wMa436ljKa()
		{
			return null;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000AACC File Offset: 0x00008CCC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] R8C4XKES34()
		{
			int length = "{11111-22222-40001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000AAEC File Offset: 0x00008CEC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] Rht4Bl5Ay0()
		{
			int length = "{11111-22222-40001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000AB0C File Offset: 0x00008D0C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] MRQ48Djfyl()
		{
			return null;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000AB1C File Offset: 0x00008D1C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] oH74dRCR3x()
		{
			return null;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000AB2C File Offset: 0x00008D2C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object TC36QtZFUXHP5HeIyZb(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000AB38 File Offset: 0x00008D38
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void cF0y8BZcDYgbVtbKnse(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000AB48 File Offset: 0x00008D48
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long K2yvoyZYoo1umZGC5xm(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000AB54 File Offset: 0x00008D54
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object CAsohUZJYV1A1hYCXxm(object A_0, int \u0020)
		{
			return A_0.CRrnwbQjvl(\u0020);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000AB64 File Offset: 0x00008D64
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void DnRUtkZD8Dba3GeJWQe(object A_0)
		{
			A_0.z0Pnh77E3F();
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000AB70 File Offset: 0x00008D70
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void NVYM7KZZQPDjboo3Zw4(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000AB7C File Offset: 0x00008D7C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Xp06EPZ1rNXFw04pyQB(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000AB88 File Offset: 0x00008D88
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object jbf3UOZGRt8yGGjpXHP(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000AB94 File Offset: 0x00008D94
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object yUtrEsZaqxAMDqUR1Hb()
		{
			return dEVOB24MC4I6IS6wh5O.iEX4xSluhd();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000AB9C File Offset: 0x00008D9C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void bQ06mlZx85oW1JGFi0w(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000ABAC File Offset: 0x00008DAC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object CF2BTEZQCco6AOC5Brg(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000ABC0 File Offset: 0x00008DC0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object kYkIXLZf4vMKKUCIQdS()
		{
			return dEVOB24MC4I6IS6wh5O.vv84oGsPbI();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000ABC8 File Offset: 0x00008DC8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void M71wgUZlKTJyQBQUfmk(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000ABE0 File Offset: 0x00008DE0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void QfR7YYZ6w9lH6YHebTr(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000ABEC File Offset: 0x00008DEC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Bkc8PLZ5mriaNPrdyli(object A_0)
		{
			return dEVOB24MC4I6IS6wh5O.s1U4KTdmgC(A_0);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000ABF8 File Offset: 0x00008DF8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void DDBD0yZ7Hi0K4C4gPjI(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000AC04 File Offset: 0x00008E04
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object c17CXKZWW70DLVyySJw(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000AC10 File Offset: 0x00008E10
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Xyy4QoZy2JfKKV9Zebd(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000AC20 File Offset: 0x00008E20
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool PrOFhWZ9YbKSbVrvlLx()
		{
			return null == null;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000AC28 File Offset: 0x00008E28
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object X8SBLWZMZ4UGXYcKYBS()
		{
			return null;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000AC2C File Offset: 0x00008E2C
		static int NKsP7xuojxxH1iqsc6Z()
		{
			return 1;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000AC30 File Offset: 0x00008E30
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr txuoH5uw1AFH2bswllb(IntPtr A_0, int A_1)
		{
			return Marshal.ReadIntPtr(A_0, A_1);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000AC40 File Offset: 0x00008E40
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int GcMwuru08txgJpb8oql(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt32(A_0, A_1);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000AC50 File Offset: 0x00008E50
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long nwCBw1uLEr2NFIoLQP7(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt64(A_0, A_1);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000AC60 File Offset: 0x00008E60
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void qTDsy4uhV0PAkMIqevL(IntPtr A_0, int A_1, IntPtr A_2)
		{
			Marshal.WriteIntPtr(A_0, A_1, A_2);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000AC74 File Offset: 0x00008E74
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void xrJAoku21r9KI7DPZKu(IntPtr A_0, int A_1, int A_2)
		{
			Marshal.WriteInt32(A_0, A_1, A_2);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000AC88 File Offset: 0x00008E88
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void xV4PfEu3pBNZX2UHtXY(IntPtr A_0, int A_1, long A_2)
		{
			Marshal.WriteInt64(A_0, A_1, A_2);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000AC9C File Offset: 0x00008E9C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr cJFiuNuX2yIoUpS6NlZ(int A_0)
		{
			return Marshal.AllocCoTaskMem(A_0);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000ACA8 File Offset: 0x00008EA8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void TWc53BuBVyXyGXWOd2G(object A_0, int A_1, IntPtr A_2, int A_3)
		{
			Marshal.Copy(A_0, A_1, A_2, A_3);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000ACC0 File Offset: 0x00008EC0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void nuIX2Au8G302Z4RjEMI()
		{
			dEVOB24MC4I6IS6wh5O.tkv4pc88M8();
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000ACC8 File Offset: 0x00008EC8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object CYPJPkudABcUkQv9WD4()
		{
			return Process.GetCurrentProcess();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000ACD0 File Offset: 0x00008ED0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object ryGUNjuibfJKERJPuOE(object A_0)
		{
			return A_0.MainModule;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000ACDC File Offset: 0x00008EDC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr nAsCfYuE4PRuCXYIwm4(object A_0)
		{
			return A_0.BaseAddress;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000ACE8 File Offset: 0x00008EE8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr OO9ifTuNGbcHG9PukpF(IntPtr \u0020, object A_1, uint \u0020)
		{
			return dEVOB24MC4I6IS6wh5O.Wbw4O7E5GG(\u0020, A_1, \u0020);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000ACFC File Offset: 0x00008EFC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool HnOnyhurnTRGX8YElP6(IntPtr A_0, IntPtr A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000AD0C File Offset: 0x00008F0C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void kie0wuuzqbvHuU6ZqOt()
		{
			va9CPUnNBvtHv0t2JTs.hCMutNHB4P();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000AD14 File Offset: 0x00008F14
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int bGedDFTb37GmK5xiLTd()
		{
			return IntPtr.Size;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000AD1C File Offset: 0x00008F1C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type jLMpmHT47dreQduKL5U(object A_0, bool A_1)
		{
			return Type.GetType(A_0, A_1);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000AD2C File Offset: 0x00008F2C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool MwQnWwTn1ub8gUfK9Yc(Type A_0, Type A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000AD3C File Offset: 0x00008F3C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object NHfV1TTU8Q9mRribLDx(object A_0)
		{
			return A_0.Modules;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000AD48 File Offset: 0x00008F48
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object mpXwZwT9BESV7F8DNe9(object A_0)
		{
			return A_0.GetEnumerator();
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000AD54 File Offset: 0x00008F54
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object fFFY0PTMaov82muq7F0(object A_0)
		{
			return ((IEnumerator)A_0).Current;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000AD60 File Offset: 0x00008F60
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object kI27F6TFaocOGcmKd7s(object A_0)
		{
			return A_0.ModuleName;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000AD6C File Offset: 0x00008F6C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object bILV7DTcheBIZptmRla(object A_0)
		{
			return A_0.ToLower();
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000AD78 File Offset: 0x00008F78
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Qmma6BTYepWE60fPdMQ(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000AD88 File Offset: 0x00008F88
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object tZh6SrTJTUucksYywb0(object A_0)
		{
			return A_0.FileVersionInfo;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000AD94 File Offset: 0x00008F94
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int qRdJNJTD5eCVRgXQhHQ(object A_0)
		{
			return A_0.ProductMajorPart;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000ADA0 File Offset: 0x00008FA0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int VvGSpGTZUAh6DA3CrVp(object A_0)
		{
			return A_0.ProductMinorPart;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000ADAC File Offset: 0x00008FAC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int Y3PkwgT1n06QiHgC0FV(object A_0)
		{
			return A_0.ProductBuildPart;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000ADB8 File Offset: 0x00008FB8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int PwdxjJTGTSkSJtWbPf4(object A_0)
		{
			return A_0.ProductPrivatePart;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000ADC4 File Offset: 0x00008FC4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool IatKOtTaqjS5dybHKiw(object A_0, object A_1)
		{
			return A_0 >= A_1;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000ADD4 File Offset: 0x00008FD4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool q1KO3xTxjbLgMllusYs(object A_0, object A_1)
		{
			return A_0 < A_1;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000ADE4 File Offset: 0x00008FE4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool GVRLfXTQ2g2ZWe3IuCs(object A_0)
		{
			return ((IEnumerator)A_0).MoveNext();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000ADF0 File Offset: 0x00008FF0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void z4gDu0TfjJ4n5eTjiqJ(object A_0)
		{
			((IDisposable)A_0).Dispose();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000ADFC File Offset: 0x00008FFC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object NdSPiKTlLY6Cq3eesen(object A_0, object A_1)
		{
			return A_0.GetManifestResourceStream(A_1);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000AE0C File Offset: 0x0000900C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object fLH4E4T6n6yJKXfH971(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000AE18 File Offset: 0x00009018
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void oKuNBYT5QjVa1NM4Q1L(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000AE28 File Offset: 0x00009028
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long n08DHyT7pRQZeOUHlRu(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000AE34 File Offset: 0x00009034
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object eRD5EwTWKtPCExT9D1F(object A_0, int \u0020)
		{
			return A_0.CRrnwbQjvl(\u0020);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000AE44 File Offset: 0x00009044
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void S8GsQ3TytJ5tjgKMTx3(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000AE50 File Offset: 0x00009050
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object t9rk2qTe92uxa0VA8a1(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000AE5C File Offset: 0x0000905C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object D04YuNTuWfNKy85thnm(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000AE68 File Offset: 0x00009068
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ICg4YnTTsacr9O4RysL(object A_0, int A_1, int A_2)
		{
			Array.Clear(A_0, A_1, A_2);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000AE7C File Offset: 0x0000907C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object h7gmRlTseLATrmB6CV8(object A_0)
		{
			return A_0.GetModules();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000AE88 File Offset: 0x00009088
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr y814LCTqksuM9DM9hf9(object A_0)
		{
			return Marshal.GetHINSTANCE(A_0);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000AE94 File Offset: 0x00009094
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object GiIYJUTHroCKRWJfsb7(object A_0)
		{
			return A_0.Location;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000AEA0 File Offset: 0x000090A0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int DlTKVoTSO60tWCGRRdq(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000AEAC File Offset: 0x000090AC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int ooAYmhTpgTTaNXnMjVB(object A_0)
		{
			return A_0.Cy5nLK82se();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000AEB8 File Offset: 0x000090B8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object tH2ateTgoiobI3YZD4e()
		{
			return dEVOB24MC4I6IS6wh5O.iEX4xSluhd();
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000AEC0 File Offset: 0x000090C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void nyQQYtTAKL0mujoPutO(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000AED0 File Offset: 0x000090D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object RU4PrQTPMqT49AQb15q(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000AEE4 File Offset: 0x000090E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void FFNwPrTjV9Q6cfJq2uk(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000AEFC File Offset: 0x000090FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void zqhoYBTvyOGjdsexM3a(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000AF08 File Offset: 0x00009108
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object JgbKPlTOKBRTCGbTwNH(object A_0)
		{
			return A_0.ToArray();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000AF14 File Offset: 0x00009114
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void bGrOGvTRD5AGPPSo255(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000AF20 File Offset: 0x00009120
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void zsj6seTCZ6yIpnmfrkR(object A_0)
		{
			A_0.z0Pnh77E3F();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000AF2C File Offset: 0x0000912C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int ttj8utTk0uw7Eh69PAG(object A_0)
		{
			return A_0.Id;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000AF38 File Offset: 0x00009138
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr RwMw5FTISKUsGdxgYyt(uint \u0020, int \u0020, uint \u0020)
		{
			return dEVOB24MC4I6IS6wh5O.rVk4IyKfPZ(\u0020, \u0020, \u0020);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000AF4C File Offset: 0x0000914C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Dckv5pTVPyqLl6nrh0b(int A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000AF58 File Offset: 0x00009158
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long AARf8QTtBX8o5DkbT9Y(object A_0)
		{
			return A_0.Position;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000AF64 File Offset: 0x00009164
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ckGk4LToXTHpjeGOPxT(IntPtr A_0, int A_1)
		{
			Marshal.WriteInt32(A_0, A_1);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000AF74 File Offset: 0x00009174
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int jQxlBITKiZyS8UiA8qI(IntPtr \u0020)
		{
			return dEVOB24MC4I6IS6wh5O.sH74VqiHhq(\u0020);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000AF80 File Offset: 0x00009180
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void f0PxycTm2ZWFo91IHPX(object A_0, object A_1, object A_2)
		{
			A_0.Add(A_1, A_2);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000AF94 File Offset: 0x00009194
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type Yyyvk5TwtrunOgd0omR(RuntimeTypeHandle A_0)
		{
			return Type.GetTypeFromHandle(A_0);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000AFA0 File Offset: 0x000091A0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int AlStJHT0X4Tk7vhedQZ(long A_0)
		{
			return Convert.ToInt32(A_0);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000AFAC File Offset: 0x000091AC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object k3JFp7TLKuY0pCZM5VR()
		{
			return Encoding.UTF8;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000AFB4 File Offset: 0x000091B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object jBV6WUTh67VKmPcVQbx(object A_0, object A_1)
		{
			return A_0.GetString(A_1);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000AFC4 File Offset: 0x000091C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool sfyw4eT2ps5Fov0cmx5(IntPtr A_0, IntPtr A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000AFD4 File Offset: 0x000091D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object OlIPchT3qG9LqUvcUAa(IntPtr \u0020, Type \u0020)
		{
			return dEVOB24MC4I6IS6wh5O.xmV4gtFpt9(\u0020, \u0020);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000AFE4 File Offset: 0x000091E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr ItwNX4TX2ErN7NnZTKC(object A_0)
		{
			return A_0();
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000AFF0 File Offset: 0x000091F0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int djmM0NTBqdaiLQfYYUq(IntPtr A_0)
		{
			return Marshal.ReadInt32(A_0);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000AFFC File Offset: 0x000091FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long R2WAG8T8RbTmpdvftmw(IntPtr A_0)
		{
			return Marshal.ReadInt64(A_0);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000B008 File Offset: 0x00009208
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr E0T8krTdijxsNK8iJZa(object A_0)
		{
			return Marshal.GetFunctionPointerForDelegate(A_0);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000B014 File Offset: 0x00009214
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int YCBEptTiORjOfVTNeaH(object A_0)
		{
			return A_0.ModuleMemorySize;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000B020 File Offset: 0x00009220
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object KiRYstTEXQJfVSY6BR5(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000B02C File Offset: 0x0000922C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool zVVDFaTNeU5XmdyvcId(object A_0, object A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000B03C File Offset: 0x0000923C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object knFr7STr9mijWavbLMN(object A_0)
		{
			return A_0.Method;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000B048 File Offset: 0x00009248
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object FCZKPfTzn2YtX6Stl5Y(Type A_0, object A_1)
		{
			return Delegate.CreateDelegate(A_0, A_1);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000B058 File Offset: 0x00009258
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object v44ixxsbiEdPPWHCBxe(object A_0)
		{
			return A_0.GetParameters();
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000B064 File Offset: 0x00009264
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object XgMV0ps4jdLo4oZoPpA(object A_0)
		{
			return A_0.ManifestModule;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000B070 File Offset: 0x00009270
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ModuleHandle niPqLHsnIKP7NVOiYs5(object A_0)
		{
			return A_0.ModuleHandle;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000B07C File Offset: 0x0000927C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type RUqn4CsUlRmkaNApD08(object A_0)
		{
			return A_0.GetType();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000B088 File Offset: 0x00009288
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object TSoo5qs9ilf64uaD292(object A_0, object A_1)
		{
			return A_0.GetValue(A_1);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000B098 File Offset: 0x00009298
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object QFxfwHsMTxuHNRGrihT(long A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000B0A4 File Offset: 0x000092A4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void rjJVyhsFF1nYV6ymRr7(object A_0)
		{
			RuntimeHelpers.PrepareDelegate(A_0);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000B0B0 File Offset: 0x000092B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static RuntimeMethodHandle E3hm5ssc8jJ7LmX2Jje(object A_0)
		{
			return A_0.MethodHandle;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000B0BC File Offset: 0x000092BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void OU12drsYiMS3E4GpePJ(RuntimeMethodHandle A_0)
		{
			RuntimeHelpers.PrepareMethod(A_0);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000B0C8 File Offset: 0x000092C8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void qZ32RosJbk5LPPTkmyp(object A_0, RuntimeFieldHandle A_1)
		{
			RuntimeHelpers.InitializeArray(A_0, A_1);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000B0D8 File Offset: 0x000092D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr vEKylesDpJQZcEQM6Vn(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			return dEVOB24MC4I6IS6wh5O.GUw4RWBl0F(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000B0F0 File Offset: 0x000092F0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void qU1jc8sZegyZxx2PTkr(IntPtr A_0, IntPtr A_1)
		{
			Marshal.WriteIntPtr(A_0, A_1);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000B100 File Offset: 0x00009300
		internal static bool ahwms6uKS3xG1M7rnPg()
		{
			return null == null;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000B108 File Offset: 0x00009308
		internal static object VxGXXYum3fMlyJmbbHJ()
		{
			return null;
		}

		// Token: 0x04000039 RID: 57
		private static IntPtr rBinJXF3Nm = IntPtr.Zero;

		// Token: 0x0400003A RID: 58
		private static object qaln18htlA = new int[0];

		// Token: 0x0400003B RID: 59
		private static IntPtr hl6nusJDq3 = IntPtr.Zero;

		// Token: 0x0400003C RID: 60
		private static object j89nZjkl5y = new string[0];

		// Token: 0x0400003D RID: 61
		private static bool p7D4iQQwKi = false;

		// Token: 0x0400003E RID: 62
		internal static object cmZnlGbI42 = null;

		// Token: 0x0400003F RID: 63
		internal static object XfUn6Dk1g0 = null;

		// Token: 0x04000040 RID: 64
		private static List<string> bFGnMP4CLQ = null;

		// Token: 0x04000041 RID: 65
		private static object UgWnxvYDrY = new SortedList();

		// Token: 0x04000042 RID: 66
		private static int ukpnUQa1Br = 0;

		// Token: 0x04000043 RID: 67
		internal static object Vlk4EuyGno = typeof(dEVOB24MC4I6IS6wh5O).Assembly;

		// Token: 0x04000044 RID: 68
		private static IntPtr zCCnPbPELo = IntPtr.Zero;

		// Token: 0x04000045 RID: 69
		private static object NaMn9yLRnX = new object();

		// Token: 0x04000046 RID: 70
		private static int HV1n7I6yHa = 0;

		// Token: 0x04000047 RID: 71
		private static object M2wnS0pJC2 = null;

		// Token: 0x04000048 RID: 72
		private static object zEvncZ5nsp = new byte[0];

		// Token: 0x04000049 RID: 73
		private static bool wP24zdkeww = false;

		// Token: 0x0400004A RID: 74
		private static object jb5npOHLpm = null;

		// Token: 0x0400004B RID: 75
		private static bool YiFny0vC29 = false;

		// Token: 0x0400004C RID: 76
		private static object rgBngb5YYc = null;

		// Token: 0x0400004D RID: 77
		internal static object bvQnbfIMi4 = null;

		// Token: 0x0400004E RID: 78
		[dEVOB24MC4I6IS6wh5O.Oi8rcxnvk56abxmYVd2(typeof(dEVOB24MC4I6IS6wh5O.Oi8rcxnvk56abxmYVd2.t7xmufnOhFadD6cxvUK<object>[]))]
		private static bool Hk5nT4wT3C = false;

		// Token: 0x0400004F RID: 79
		private static List<int> FvTnF6GUQX = null;

		// Token: 0x04000050 RID: 80
		private static bool WrXnWSmHC2 = false;

		// Token: 0x04000051 RID: 81
		private static long Wuhn5TiYrT = 0L;

		// Token: 0x04000052 RID: 82
		private static bool UPG4r4N2o8 = false;

		// Token: 0x04000053 RID: 83
		private static object plinAkpBZd = null;

		// Token: 0x04000054 RID: 84
		private static object yIZnHc4krX = null;

		// Token: 0x04000055 RID: 85
		private static bool HUYnam2Txx = false;

		// Token: 0x04000056 RID: 86
		private static object oyN4NfGvUm = new uint[]
		{
			3614090360U, 3905402710U, 606105819U, 3250441966U, 4118548399U, 1200080426U, 2821735955U, 4249261313U, 1770035416U, 2336552879U,
			4294925233U, 2304563134U, 1804603682U, 4254626195U, 2792965006U, 1236535329U, 4129170786U, 3225465664U, 643717713U, 3921069994U,
			3593408605U, 38016083U, 3634488961U, 3889429448U, 568446438U, 3275163606U, 4107603335U, 1163531501U, 2850285829U, 4243563512U,
			1735328473U, 2368359562U, 4294588738U, 2272392833U, 1839030562U, 4259657740U, 2763975236U, 1272893353U, 4139469664U, 3200236656U,
			681279174U, 3936430074U, 3572445317U, 76029189U, 3654602809U, 3873151461U, 530742520U, 3299628645U, 4096336452U, 1126891415U,
			2878612391U, 4237533241U, 1700485571U, 2399980690U, 4293915773U, 2240044497U, 1873313359U, 4264355552U, 2734768916U, 1309151649U,
			4149444226U, 3174756917U, 718787259U, 3951481745U
		};

		// Token: 0x04000057 RID: 87
		private static object awXnnFpTO1 = new object();

		// Token: 0x04000058 RID: 88
		private static int XBDnQJD9re = 0;

		// Token: 0x04000059 RID: 89
		private static int eFfnGcK6lG = 1;

		// Token: 0x0400005A RID: 90
		private static object hgfnqOUHR0 = null;

		// Token: 0x0400005B RID: 91
		private static int cqIneghAdf = 0;

		// Token: 0x0400005C RID: 92
		private static object KqonYwQv2N = new byte[0];

		// Token: 0x0400005D RID: 93
		private static long b17nfTTmm4 = 0L;

		// Token: 0x0400005E RID: 94
		private static Dictionary<int, int> VfDn42EJL2 = null;

		// Token: 0x0400005F RID: 95
		internal static object z8hnsiSJh4 = new Hashtable();

		// Token: 0x04000060 RID: 96
		private static IntPtr iignD5kYfj = IntPtr.Zero;

		// Token: 0x02000015 RID: 21
		private sealed class haNZtFnjToyY3X9L9PY : MulticastDelegate
		{
			// Token: 0x0600014E RID: 334
			public extern haNZtFnjToyY3X9L9PY(object \u0020, IntPtr \u0020);

			// Token: 0x0600014F RID: 335
			public extern void Invoke(object o);

			// Token: 0x06000150 RID: 336
			public extern IAsyncResult BeginInvoke(object o, AsyncCallback callback, object @object);

			// Token: 0x06000151 RID: 337
			public extern void EndInvoke(IAsyncResult result);

			// Token: 0x06000152 RID: 338 RVA: 0x0000B10C File Offset: 0x0000930C
			static haNZtFnjToyY3X9L9PY()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x02000016 RID: 22
		internal class Oi8rcxnvk56abxmYVd2 : Attribute
		{
			// Token: 0x06000153 RID: 339 RVA: 0x0000B114 File Offset: 0x00009314
			[MethodImpl(MethodImplOptions.NoInlining)]
			public Oi8rcxnvk56abxmYVd2(object \u0020)
			{
			}

			// Token: 0x06000154 RID: 340 RVA: 0x0000B11C File Offset: 0x0000931C
			static Oi8rcxnvk56abxmYVd2()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}

			// Token: 0x02000017 RID: 23
			internal class t7xmufnOhFadD6cxvUK<Pp6qqgnRwUSoFsmL8Xd>
			{
				// Token: 0x06000155 RID: 341 RVA: 0x0000B124 File Offset: 0x00009324
				[MethodImpl(MethodImplOptions.NoInlining)]
				public t7xmufnOhFadD6cxvUK()
				{
				}

				// Token: 0x06000156 RID: 342 RVA: 0x0000B134 File Offset: 0x00009334
				[MethodImpl(MethodImplOptions.NoInlining)]
				static t7xmufnOhFadD6cxvUK()
				{
					dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
					COurHEUn76OJbUlkk9L.jgds18nSeT();
				}

				// Token: 0x06000157 RID: 343 RVA: 0x0000B140 File Offset: 0x00009340
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool fSmg20fa5tqao73P56C()
				{
					return true;
				}

				// Token: 0x06000158 RID: 344 RVA: 0x0000B148 File Offset: 0x00009348
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static object aE1Sw4fxvr2Z00nXTgQ()
				{
					return null;
				}

				// Token: 0x04000061 RID: 97
				internal static object LLDUyXfGVKRRPqBpbkM;
			}
		}

		// Token: 0x02000018 RID: 24
		internal class CJQLtPnCdyhGrDvy1RH
		{
			// Token: 0x06000159 RID: 345 RVA: 0x0000B150 File Offset: 0x00009350
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static string gk7nkOWHhD(object \u0020, object \u0020)
			{
				return null;
			}

			// Token: 0x0600015A RID: 346 RVA: 0x0000B160 File Offset: 0x00009360
			[MethodImpl(MethodImplOptions.NoInlining)]
			public CJQLtPnCdyhGrDvy1RH()
			{
			}

			// Token: 0x0600015B RID: 347 RVA: 0x0000B168 File Offset: 0x00009368
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void XDmv4of6ODH56Dc1j0c(object A_0, RuntimeFieldHandle A_1)
			{
			}

			// Token: 0x0600015C RID: 348 RVA: 0x0000B170 File Offset: 0x00009370
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object QtvklRf5mQRT6RXms10()
			{
				return null;
			}

			// Token: 0x0600015D RID: 349 RVA: 0x0000B178 File Offset: 0x00009378
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object RQsqb5f7jrnlYSGk5OB(object A_0, object A_1)
			{
				return null;
			}

			// Token: 0x0600015E RID: 350 RVA: 0x0000B180 File Offset: 0x00009380
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object ghurAZfWtgmimxlnDlA(object A_0)
			{
				return null;
			}

			// Token: 0x0600015F RID: 351 RVA: 0x0000B188 File Offset: 0x00009388
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object uHXCFAfyekMrv9VGgtf()
			{
				return null;
			}

			// Token: 0x06000160 RID: 352 RVA: 0x0000B190 File Offset: 0x00009390
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void efm57MfeW9fkSM85Yci(object A_0, object A_1)
			{
			}

			// Token: 0x06000161 RID: 353 RVA: 0x0000B198 File Offset: 0x00009398
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void ck2miOfuG8Rwn1x2Nn7(object A_0, object A_1)
			{
			}

			// Token: 0x06000162 RID: 354 RVA: 0x0000B1A0 File Offset: 0x000093A0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object Gj1v06fTxYZKKIQ1Qo0(object A_0)
			{
				return null;
			}

			// Token: 0x06000163 RID: 355 RVA: 0x0000B1A8 File Offset: 0x000093A8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void SNcxIDfs16YRA7Zj2e5(object A_0, object A_1, int A_2, int A_3)
			{
			}

			// Token: 0x06000164 RID: 356 RVA: 0x0000B1B0 File Offset: 0x000093B0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void uRyNGbfqFFy9yxXcjPE(object A_0)
			{
			}

			// Token: 0x06000165 RID: 357 RVA: 0x0000B1B8 File Offset: 0x000093B8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object K3v0mJfHDl0LuetJTMH(object A_0)
			{
				return null;
			}

			// Token: 0x06000166 RID: 358 RVA: 0x0000B1C0 File Offset: 0x000093C0
			static CJQLtPnCdyhGrDvy1RH()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x02000019 RID: 25
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal sealed class Emi0oknINGwWNmyCUnP : MulticastDelegate
		{
			// Token: 0x06000167 RID: 359
			public extern Emi0oknINGwWNmyCUnP(object \u0020, IntPtr \u0020);

			// Token: 0x06000168 RID: 360
			public extern uint Invoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

			// Token: 0x06000169 RID: 361
			public extern IAsyncResult BeginInvoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode, AsyncCallback callback, object @object);

			// Token: 0x0600016A RID: 362
			public extern uint EndInvoke(ref uint nativeSizeOfCode, IAsyncResult result);

			// Token: 0x0600016B RID: 363 RVA: 0x0000B1C8 File Offset: 0x000093C8
			static Emi0oknINGwWNmyCUnP()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x0200001A RID: 26
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class cYuP8tnVqkj17XJil8R : MulticastDelegate
		{
			// Token: 0x0600016C RID: 364
			public extern cYuP8tnVqkj17XJil8R(object \u0020, IntPtr \u0020);

			// Token: 0x0600016D RID: 365
			public extern IntPtr Invoke();

			// Token: 0x0600016E RID: 366
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x0600016F RID: 367
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000170 RID: 368 RVA: 0x0000B1D0 File Offset: 0x000093D0
			static cYuP8tnVqkj17XJil8R()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x0200001B RID: 27
		internal struct jN4RUZntgB1ECTUw7wi
		{
			// Token: 0x04000062 RID: 98
			internal bool MFUnoCMNU0;

			// Token: 0x04000063 RID: 99
			internal byte[] QacnKmKFnR;
		}

		// Token: 0x0200001C RID: 28
		internal class ws9cK3nmMI5Apir6GGZ
		{
			// Token: 0x06000171 RID: 369 RVA: 0x0000B1D8 File Offset: 0x000093D8
			[MethodImpl(MethodImplOptions.NoInlining)]
			public ws9cK3nmMI5Apir6GGZ(Stream \u0020)
			{
				this.YQsn2iiBZW = new BinaryReader(\u0020);
			}

			// Token: 0x06000172 RID: 370 RVA: 0x0000B1EC File Offset: 0x000093EC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal Stream nW4lBacjpc()
			{
				return this.YQsn2iiBZW.BaseStream;
			}

			// Token: 0x06000173 RID: 371 RVA: 0x0000B1FC File Offset: 0x000093FC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal byte[] CRrnwbQjvl(int \u0020)
			{
				return dEVOB24MC4I6IS6wh5O.ws9cK3nmMI5Apir6GGZ.Yo3mcLfvKHPhWbYu6mk(this.YQsn2iiBZW, \u0020);
			}

			// Token: 0x06000174 RID: 372 RVA: 0x0000B20C File Offset: 0x0000940C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int ME7n055giK(byte[] \u0020, int \u0020, int \u0020)
			{
				return this.YQsn2iiBZW.Read(\u0020, \u0020, \u0020);
			}

			// Token: 0x06000175 RID: 373 RVA: 0x0000B21C File Offset: 0x0000941C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int Cy5nLK82se()
			{
				return this.YQsn2iiBZW.ReadInt32();
			}

			// Token: 0x06000176 RID: 374 RVA: 0x0000B22C File Offset: 0x0000942C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void z0Pnh77E3F()
			{
				dEVOB24MC4I6IS6wh5O.ws9cK3nmMI5Apir6GGZ.cRLdlHfO6lJEggZXcbe(this.YQsn2iiBZW);
			}

			// Token: 0x06000177 RID: 375 RVA: 0x0000B23C File Offset: 0x0000943C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object Yo3mcLfvKHPhWbYu6mk(object A_0, int A_1)
			{
				return A_0.ReadBytes(A_1);
			}

			// Token: 0x06000178 RID: 376 RVA: 0x0000B24C File Offset: 0x0000944C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void cRLdlHfO6lJEggZXcbe(object A_0)
			{
				A_0.Close();
			}

			// Token: 0x06000179 RID: 377 RVA: 0x0000B258 File Offset: 0x00009458
			static ws9cK3nmMI5Apir6GGZ()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}

			// Token: 0x04000064 RID: 100
			private object YQsn2iiBZW;
		}

		// Token: 0x0200001D RID: 29
		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private sealed class FPtM6Kn3y2Er4H8simZ : MulticastDelegate
		{
			// Token: 0x0600017A RID: 378
			public extern FPtM6Kn3y2Er4H8simZ(object \u0020, IntPtr \u0020);

			// Token: 0x0600017B RID: 379
			public extern IntPtr Invoke(IntPtr hModule, string lpName, uint lpType);

			// Token: 0x0600017C RID: 380
			public extern IAsyncResult BeginInvoke(IntPtr hModule, string lpName, uint lpType, AsyncCallback callback, object @object);

			// Token: 0x0600017D RID: 381
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600017E RID: 382 RVA: 0x0000B260 File Offset: 0x00009460
			static FPtM6Kn3y2Er4H8simZ()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x0200001E RID: 30
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class Arg54nnX2QE6ar98yWc : MulticastDelegate
		{
			// Token: 0x0600017F RID: 383
			public extern Arg54nnX2QE6ar98yWc(object \u0020, IntPtr \u0020);

			// Token: 0x06000180 RID: 384
			public extern IntPtr Invoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x06000181 RID: 385
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect, AsyncCallback callback, object @object);

			// Token: 0x06000182 RID: 386
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000183 RID: 387 RVA: 0x0000B268 File Offset: 0x00009468
			static Arg54nnX2QE6ar98yWc()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x0200001F RID: 31
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class KiM826nBuyJfvu0fGLe : MulticastDelegate
		{
			// Token: 0x06000184 RID: 388
			public extern KiM826nBuyJfvu0fGLe(object \u0020, IntPtr \u0020);

			// Token: 0x06000185 RID: 389
			public extern int Invoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

			// Token: 0x06000186 RID: 390
			public extern IAsyncResult BeginInvoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten, AsyncCallback callback, object @object);

			// Token: 0x06000187 RID: 391
			public extern int EndInvoke(out IntPtr lpNumberOfBytesWritten, IAsyncResult result);

			// Token: 0x06000188 RID: 392 RVA: 0x0000B270 File Offset: 0x00009470
			static KiM826nBuyJfvu0fGLe()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x02000020 RID: 32
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class r7NALRn8JyD3vpS9OlP : MulticastDelegate
		{
			// Token: 0x06000189 RID: 393
			public extern r7NALRn8JyD3vpS9OlP(object \u0020, IntPtr \u0020);

			// Token: 0x0600018A RID: 394
			public extern int Invoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

			// Token: 0x0600018B RID: 395
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect, AsyncCallback callback, object @object);

			// Token: 0x0600018C RID: 396
			public extern int EndInvoke(ref int lpflOldProtect, IAsyncResult result);

			// Token: 0x0600018D RID: 397 RVA: 0x0000B278 File Offset: 0x00009478
			static r7NALRn8JyD3vpS9OlP()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x02000021 RID: 33
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class tjTLyNnd4nqyV1NpCpU : MulticastDelegate
		{
			// Token: 0x0600018E RID: 398
			public extern tjTLyNnd4nqyV1NpCpU(object \u0020, IntPtr \u0020);

			// Token: 0x0600018F RID: 399
			public extern IntPtr Invoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x06000190 RID: 400
			public extern IAsyncResult BeginInvoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId, AsyncCallback callback, object @object);

			// Token: 0x06000191 RID: 401
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000192 RID: 402 RVA: 0x0000B280 File Offset: 0x00009480
			static tjTLyNnd4nqyV1NpCpU()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x02000022 RID: 34
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class SUE4l5niQD7TvrP1nlp : MulticastDelegate
		{
			// Token: 0x06000193 RID: 403
			public extern SUE4l5niQD7TvrP1nlp(object \u0020, IntPtr \u0020);

			// Token: 0x06000194 RID: 404
			public extern int Invoke(IntPtr ptr);

			// Token: 0x06000195 RID: 405
			public extern IAsyncResult BeginInvoke(IntPtr ptr, AsyncCallback callback, object @object);

			// Token: 0x06000196 RID: 406
			public extern int EndInvoke(IAsyncResult result);

			// Token: 0x06000197 RID: 407 RVA: 0x0000B288 File Offset: 0x00009488
			static SUE4l5niQD7TvrP1nlp()
			{
				dEVOB24MC4I6IS6wh5O.o7j4AZHa79();
			}
		}

		// Token: 0x02000023 RID: 35
		[Flags]
		private enum fQndpsnEYb2xwuWpCu8
		{

		}
	}
}
