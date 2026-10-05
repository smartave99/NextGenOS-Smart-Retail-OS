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
using pojG8skr8O7xbw7Ltjm;
using X8MmbBM8l3XjvFQgdkV;
using xWILlLMxFMOwJ1j8eSG;

namespace V5dt4GjAxJtQ8r73kl
{
	// Token: 0x02000016 RID: 22
	internal class oZWYtLnJnekp0ELgSU
	{
		// Token: 0x060000BC RID: 188 RVA: 0x00002BFC File Offset: 0x00000DFC
		[MethodImpl(MethodImplOptions.NoInlining)]
		static oZWYtLnJnekp0ELgSU()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00002D70 File Offset: 0x00000F70
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SOaeABKIHV()
		{
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00002D74 File Offset: 0x00000F74
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] gNDa4Np6w(object \u0020)
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
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num6, num7, num8, num9, 0U, 7, 1U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num9, num6, num7, num8, 1U, 12, 2U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num8, num9, num6, num7, 2U, 17, 3U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num7, num8, num9, num6, 3U, 22, 4U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num6, num7, num8, num9, 4U, 7, 5U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num9, num6, num7, num8, 5U, 12, 6U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num8, num9, num6, num7, 6U, 17, 7U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num7, num8, num9, num6, 7U, 22, 8U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num6, num7, num8, num9, 8U, 7, 9U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num9, num6, num7, num8, 9U, 12, 10U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num8, num9, num6, num7, 10U, 17, 11U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num7, num8, num9, num6, 11U, 22, 12U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num6, num7, num8, num9, 12U, 7, 13U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num9, num6, num7, num8, 13U, 12, 14U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num8, num9, num6, num7, 14U, 17, 15U, array);
				oZWYtLnJnekp0ELgSU.lb8PrJgeu(ref num7, num8, num9, num6, 15U, 22, 16U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num6, num7, num8, num9, 1U, 5, 17U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num9, num6, num7, num8, 6U, 9, 18U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num8, num9, num6, num7, 11U, 14, 19U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num7, num8, num9, num6, 0U, 20, 20U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num6, num7, num8, num9, 5U, 5, 21U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num9, num6, num7, num8, 10U, 9, 22U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num8, num9, num6, num7, 15U, 14, 23U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num7, num8, num9, num6, 4U, 20, 24U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num6, num7, num8, num9, 9U, 5, 25U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num9, num6, num7, num8, 14U, 9, 26U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num8, num9, num6, num7, 3U, 14, 27U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num7, num8, num9, num6, 8U, 20, 28U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num6, num7, num8, num9, 13U, 5, 29U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num9, num6, num7, num8, 2U, 9, 30U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num8, num9, num6, num7, 7U, 14, 31U, array);
				oZWYtLnJnekp0ELgSU.xv31lE6nC(ref num7, num8, num9, num6, 12U, 20, 32U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num6, num7, num8, num9, 5U, 4, 33U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num9, num6, num7, num8, 8U, 11, 34U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num8, num9, num6, num7, 11U, 16, 35U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num7, num8, num9, num6, 14U, 23, 36U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num6, num7, num8, num9, 1U, 4, 37U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num9, num6, num7, num8, 4U, 11, 38U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num8, num9, num6, num7, 7U, 16, 39U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num7, num8, num9, num6, 10U, 23, 40U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num6, num7, num8, num9, 13U, 4, 41U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num9, num6, num7, num8, 0U, 11, 42U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num8, num9, num6, num7, 3U, 16, 43U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num7, num8, num9, num6, 6U, 23, 44U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num6, num7, num8, num9, 9U, 4, 45U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num9, num6, num7, num8, 12U, 11, 46U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num8, num9, num6, num7, 15U, 16, 47U, array);
				oZWYtLnJnekp0ELgSU.UpiV76Grt(ref num7, num8, num9, num6, 2U, 23, 48U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num6, num7, num8, num9, 0U, 6, 49U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num9, num6, num7, num8, 7U, 10, 50U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num8, num9, num6, num7, 14U, 15, 51U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num7, num8, num9, num6, 5U, 21, 52U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num6, num7, num8, num9, 12U, 6, 53U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num9, num6, num7, num8, 3U, 10, 54U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num8, num9, num6, num7, 10U, 15, 55U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num7, num8, num9, num6, 1U, 21, 56U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num6, num7, num8, num9, 8U, 6, 57U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num9, num6, num7, num8, 15U, 10, 58U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num8, num9, num6, num7, 6U, 15, 59U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num7, num8, num9, num6, 13U, 21, 60U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num6, num7, num8, num9, 4U, 6, 61U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num9, num6, num7, num8, 11U, 10, 62U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num8, num9, num6, num7, 2U, 15, 63U, array);
				oZWYtLnJnekp0ELgSU.D6cpTjGlK(ref num7, num8, num9, num6, 9U, 21, 64U, array);
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

		// Token: 0x060000BF RID: 191 RVA: 0x000033D8 File Offset: 0x000015D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void lb8PrJgeu(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += oZWYtLnJnekp0ELgSU.cI07w6MJM(\u0020 + ((\u0020 & \u0020) | (~\u0020 & \u0020)) + \u0020[(int)\u0020] + oZWYtLnJnekp0ELgSU.btvYRYpJUl[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003404 File Offset: 0x00001604
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void xv31lE6nC(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += oZWYtLnJnekp0ELgSU.cI07w6MJM(\u0020 + ((\u0020 & \u0020) | (\u0020 & ~\u0020)) + \u0020[(int)\u0020] + oZWYtLnJnekp0ELgSU.btvYRYpJUl[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003430 File Offset: 0x00001630
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void UpiV76Grt(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += oZWYtLnJnekp0ELgSU.cI07w6MJM(\u0020 + (\u0020 ^ \u0020 ^ \u0020) + \u0020[(int)\u0020] + oZWYtLnJnekp0ELgSU.btvYRYpJUl[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003458 File Offset: 0x00001658
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void D6cpTjGlK(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += oZWYtLnJnekp0ELgSU.cI07w6MJM(\u0020 + (\u0020 ^ (\u0020 | ~\u0020)) + \u0020[(int)\u0020] + oZWYtLnJnekp0ELgSU.btvYRYpJUl[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003480 File Offset: 0x00001680
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static uint cI07w6MJM(uint \u0020, ushort \u0020)
		{
			return (\u0020 >> (int)(32 - \u0020)) | (\u0020 << (int)\u0020);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003494 File Offset: 0x00001694
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Xj7D2h71R()
		{
			if (!oZWYtLnJnekp0ELgSU.uV3Yxuhq6X)
			{
				oZWYtLnJnekp0ELgSU.RVMZNbd8i();
				oZWYtLnJnekp0ELgSU.uV3Yxuhq6X = true;
			}
			return oZWYtLnJnekp0ELgSU.SyOYycHVpR;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000034B0 File Offset: 0x000016B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal oZWYtLnJnekp0ELgSU()
		{
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000034B8 File Offset: 0x000016B8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void TwOCKAKrC(byte[] \u0020, byte[] \u0020, byte[] \u0020)
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
				uint num13 = 785396777U;
				uint num14 = 851326108U;
				uint num15 = num12;
				uint num16 = 1950741206U;
				uint num17 = 443419207U;
				uint num18 = ((num14 >> 6) | (num14 << 26)) ^ num16;
				uint num19 = num18 & 252645135U;
				num18 &= 4042322160U;
				num14 = (num18 >> 4) | (num19 << 4);
				num15 -= num16;
				num15 = 33939422U * (num15 & 63U) - (num15 >> 6);
				num13 = 62797463U * (num13 & 63U) - (num13 >> 6);
				num14 = 34753U * num14 + num16;
				num18 = num16 & 252645135U;
				num19 = num16 & 4042322160U;
				num18 = ((num18 >> 4) | (num19 << 4)) + num14;
				num16 = (num16 >> 14) | (num16 << 18);
				num17 ^= num14;
				num15 ^= num15 << 3;
				num15 += num13;
				num15 ^= num15 << 25;
				num15 += num16;
				num15 ^= num15 >> 23;
				num15 += num17;
				num15 = (((num15 << 3) - num13) ^ num13) + num15;
				num4 = num12 + (uint)num15;
				if (i == num2 - 1 && num > 0)
				{
					uint num20 = num4 ^ num11;
					for (int k = 0; k < num; k++)
					{
						if (k > 0)
						{
							num9 <<= 8;
							num10 += 8;
						}
						array[num6 + k] = (byte)((num20 & num9) >> num10);
					}
				}
				else
				{
					uint num21 = num4 ^ num11;
					array[num6] = (byte)(num21 & 255U);
					array[num6 + 1] = (byte)((num21 & 65280U) >> 8);
					array[num6 + 2] = (byte)((num21 & 16711680U) >> 16);
					array[num6 + 3] = (byte)((num21 & 4278190080U) >> 24);
				}
			}
			oZWYtLnJnekp0ELgSU.rXpYaMu1Ka = array;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000383C File Offset: 0x00001A3C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static SymmetricAlgorithm FVLK318Py()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (oZWYtLnJnekp0ELgSU.Xj7D2h71R())
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

		// Token: 0x060000C8 RID: 200 RVA: 0x000038D0 File Offset: 0x00001AD0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void RVMZNbd8i()
		{
			try
			{
				new MD5CryptoServiceProvider();
			}
			catch
			{
				oZWYtLnJnekp0ELgSU.SyOYycHVpR = true;
				return;
			}
			try
			{
				oZWYtLnJnekp0ELgSU.SyOYycHVpR = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003928 File Offset: 0x00001B28
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] CYxcMx3Al(object \u0020)
		{
			if (!oZWYtLnJnekp0ELgSU.Xj7D2h71R())
			{
				return new MD5CryptoServiceProvider().ComputeHash(\u0020);
			}
			return oZWYtLnJnekp0ELgSU.gNDa4Np6w(\u0020);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00003948 File Offset: 0x00001B48
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void xobAyYZt2(object \u0020, object \u0020, uint \u0020, object \u0020)
		{
			while (\u0020 > 0U)
			{
				int num = ((\u0020 > (uint)\u0020.Length) ? \u0020.Length : ((int)\u0020));
				\u0020.Read(\u0020, 0, num);
				oZWYtLnJnekp0ELgSU.gy1zQY42w(\u0020, \u0020, 0, num);
				\u0020 -= (uint)num;
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000398C File Offset: 0x00001B8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void gy1zQY42w(object \u0020, object \u0020, int \u0020, int \u0020)
		{
			\u0020.TransformBlock(\u0020, \u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000399C File Offset: 0x00001B9C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint GjSY35YKfu(uint \u0020, int \u0020, long \u0020, object \u0020)
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

		// Token: 0x060000CD RID: 205 RVA: 0x00003A04 File Offset: 0x00001C04
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void OJnYYnDwII(RuntimeTypeHandle \u0020)
		{
			try
			{
				Type typeFromHandle = Type.GetTypeFromHandle(\u0020);
				if (oZWYtLnJnekp0ELgSU.cKCYWo8dF4 == null)
				{
					object hggytoHC = oZWYtLnJnekp0ELgSU.HGGYtoHC67;
					lock (hggytoHC)
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						BinaryReader binaryReader = new BinaryReader(typeof(oZWYtLnJnekp0ELgSU).Assembly.GetManifestResourceStream("nkmBm22TvK0yIaLb8x.WF8MTxfVn37HvGJurB"));
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
								uint num11 = 785396777U;
								uint num12 = 851326108U;
								uint num13 = num10;
								uint num14 = 1950741206U;
								uint num15 = 443419207U;
								uint num16 = ((num12 >> 6) | (num12 << 26)) ^ num14;
								uint num17 = num16 & 252645135U;
								num16 &= 4042322160U;
								num12 = (num16 >> 4) | (num17 << 4);
								num13 -= num14;
								num13 = 33939422U * (num13 & 63U) - (num13 >> 6);
								num11 = 62797463U * (num11 & 63U) - (num11 >> 6);
								num12 = 34753U * num12 + num14;
								num16 = num14 & 252645135U;
								num17 = num14 & 4042322160U;
								num16 = ((num16 >> 4) | (num17 << 4)) + num12;
								num14 = (num14 >> 14) | (num14 << 18);
								num15 ^= num12;
								num13 ^= num13 << 3;
								num13 += num11;
								num13 ^= num13 << 25;
								num13 += num14;
								num13 ^= num13 >> 23;
								num13 += num15;
								num13 = (((num13 << 3) - num11) ^ num11) + num13;
								num3 = num9 + (uint)num13;
								if (i == num2 - 1 && num > 0)
								{
									uint num18 = num3 ^ num7;
									for (int k = 0; k < num; k++)
									{
										if (k > 0)
										{
											num5 <<= 8;
											num6 += 8;
										}
										array2[num4 + k] = (byte)((num18 & num5) >> num6);
									}
								}
								else
								{
									uint num19 = num3 ^ num7;
									array2[num4] = (byte)(num19 & 255U);
									array2[num4 + 1] = (byte)((num19 & 65280U) >> 8);
									array2[num4 + 2] = (byte)((num19 & 16711680U) >> 16);
									array2[num4 + 3] = (byte)((num19 & 4278190080U) >> 24);
								}
							}
							array = array2;
							int num20 = array.Length / 8;
							oZWYtLnJnekp0ELgSU.oWeebDMeI9rsA7EJwLV oWeebDMeI9rsA7EJwLV = new oZWYtLnJnekp0ELgSU.oWeebDMeI9rsA7EJwLV(new MemoryStream(array));
							for (int l = 0; l < num20; l++)
							{
								int num21 = oWeebDMeI9rsA7EJwLV.QfbM9kBllF();
								int num22 = oWeebDMeI9rsA7EJwLV.QfbM9kBllF();
								dictionary.Add(num21, num22);
							}
							oWeebDMeI9rsA7EJwLV.Tw3MSokxej();
						}
						oZWYtLnJnekp0ELgSU.cKCYWo8dF4 = dictionary;
					}
				}
				FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
				for (int m = 0; m < fields.Length; m++)
				{
					try
					{
						FieldInfo fieldInfo = fields[m];
						int metadataToken = fieldInfo.MetadataToken;
						int num23 = oZWYtLnJnekp0ELgSU.cKCYWo8dF4[metadataToken];
						bool flag2 = (num23 & 1073741824) > 0;
						num23 &= 1073741823;
						MethodInfo methodInfo = (MethodInfo)typeof(oZWYtLnJnekp0ELgSU).Module.ResolveMethod(num23, typeFromHandle.GetGenericArguments(), new Type[0]);
						if (methodInfo.IsStatic)
						{
							fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
						}
						else
						{
							ParameterInfo[] parameters = methodInfo.GetParameters();
							int num24 = parameters.Length + 1;
							Type[] array3 = new Type[num24];
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
							for (int num25 = 0; num25 < num24; num25++)
							{
								switch (num25)
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
									ilgenerator.Emit(OpCodes.Ldarg_S, num25);
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

		// Token: 0x060000CE RID: 206 RVA: 0x000040B0 File Offset: 0x000022B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void VVtYre0hPZ()
		{
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000040B4 File Offset: 0x000022B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void NgBYq1MxvA(object \u0020, int \u0020)
		{
			eqXhVxkTYfaVg1k0jP5.x3kk6GUyyO(0, new object[] { \u0020, \u0020 }, null);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000040F4 File Offset: 0x000022F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string osxY4VP7OF(int \u0020)
		{
			if (oZWYtLnJnekp0ELgSU.rXpYaMu1Ka.Length == 0)
			{
				oZWYtLnJnekp0ELgSU.BdWYng0lb9 = new List<string>();
				oZWYtLnJnekp0ELgSU.SnTYja92mn = new List<int>();
				oZWYtLnJnekp0ELgSU.NgBYq1MxvA(oZWYtLnJnekp0ELgSU.ki5Y5BFlNm.GetManifestResourceStream("AZn271Y3jVHhMoLG06.uJQ0UeMZWv2HhPMd9p"), \u0020);
			}
			if (oZWYtLnJnekp0ELgSU.UNbY8h2NGl < 75)
			{
				if (oZWYtLnJnekp0ELgSU.ki5Y5BFlNm != new StackFrame(1).GetMethod().DeclaringType.Assembly)
				{
					throw new Exception();
				}
				oZWYtLnJnekp0ELgSU.UNbY8h2NGl++;
			}
			object obj = oZWYtLnJnekp0ELgSU.tE7YFycIs9;
			lock (obj)
			{
				int num = BitConverter.ToInt32(oZWYtLnJnekp0ELgSU.rXpYaMu1Ka, \u0020);
				if (num < oZWYtLnJnekp0ELgSU.SnTYja92mn.Count && oZWYtLnJnekp0ELgSU.SnTYja92mn[num] == \u0020)
				{
					return oZWYtLnJnekp0ELgSU.BdWYng0lb9[num];
				}
				try
				{
					pKt2MEMR018TcR688bs.SivezbFhwV();
					byte[] array = new byte[num];
					Array.Copy(oZWYtLnJnekp0ELgSU.rXpYaMu1Ka, \u0020 + 4, array, 0, num);
					string @string = Encoding.Unicode.GetString(array, 0, array.Length);
					oZWYtLnJnekp0ELgSU.BdWYng0lb9.Add(@string);
					oZWYtLnJnekp0ELgSU.SnTYja92mn.Add(\u0020);
					Array.Copy(BitConverter.GetBytes(oZWYtLnJnekp0ELgSU.BdWYng0lb9.Count - 1), 0, oZWYtLnJnekp0ELgSU.rXpYaMu1Ka, \u0020, 4);
					return @string;
				}
				catch
				{
				}
			}
			return "";
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000426C File Offset: 0x0000246C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string ByyYmDR3NL(object \u0020)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(\u0020);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000429C File Offset: 0x0000249C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint SFKY6QlB41(IntPtr \u0020, IntPtr \u0020, IntPtr \u0020, [MarshalAs(UnmanagedType.U4)] uint \u0020, IntPtr \u0020, ref uint \u0020)
		{
			IntPtr intPtr = \u0020;
			if (oZWYtLnJnekp0ELgSU.AwMYLIYgO4)
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
			object obj = oZWYtLnJnekp0ELgSU.VLmM43P3iS[num];
			if (obj == null)
			{
				return oZWYtLnJnekp0ELgSU.Kj9YASOMso(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			oZWYtLnJnekp0ELgSU.YlecR5MJ2SYSVCIgjmG ylecR5MJ2SYSVCIgjmG = (oZWYtLnJnekp0ELgSU.YlecR5MJ2SYSVCIgjmG)obj;
			IntPtr intPtr2 = Marshal.AllocCoTaskMem(ylecR5MJ2SYSVCIgjmG.ODwMBLqmrQ.Length);
			Marshal.Copy(ylecR5MJ2SYSVCIgjmG.ODwMBLqmrQ, 0, intPtr2, ylecR5MJ2SYSVCIgjmG.ODwMBLqmrQ.Length);
			if (ylecR5MJ2SYSVCIgjmG.JTxMG0kiQa)
			{
				\u0020 = intPtr2;
				\u0020 = (uint)ylecR5MJ2SYSVCIgjmG.ODwMBLqmrQ.Length;
				oZWYtLnJnekp0ELgSU.JnsYd79dMK(\u0020, ylecR5MJ2SYSVCIgjmG.ODwMBLqmrQ.Length, 64, ref oZWYtLnJnekp0ELgSU.YCeMTWwe0B);
				return 0U;
			}
			Marshal.WriteIntPtr(intPtr, IntPtr.Size * 2, intPtr2);
			Marshal.WriteInt32(intPtr, IntPtr.Size * 3, ylecR5MJ2SYSVCIgjmG.ODwMBLqmrQ.Length);
			uint num2 = 0U;
			if (\u0020 != 216669565U || oZWYtLnJnekp0ELgSU.whiMqrb3YG)
			{
				num2 = oZWYtLnJnekp0ELgSU.Kj9YASOMso(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			else
			{
				oZWYtLnJnekp0ELgSU.whiMqrb3YG = true;
			}
			return num2;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000043D0 File Offset: 0x000025D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int zaFYlBVN2c()
		{
			return 5;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000043D4 File Offset: 0x000025D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void BitY2E0xKT()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004404 File Offset: 0x00002604
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Delegate XY7Yf19lCP(IntPtr \u0020, Type \u0020)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[] { \u0020, \u0020 });
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004464 File Offset: 0x00002664
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe static void CYCYhuJZ5j()
		{
			int num = 221;
			for (;;)
			{
				int num2 = num;
				int num3;
				byte[] array;
				byte[] array2;
				byte[] array3;
				int num4;
				byte[] array4;
				int num5;
				byte[] array5;
				oZWYtLnJnekp0ELgSU.oWeebDMeI9rsA7EJwLV oWeebDMeI9rsA7EJwLV;
				IntPtr intPtr;
				int num6;
				uint num9;
				byte[] array9;
				byte[] array10;
				int num11;
				byte[] array11;
				int num16;
				byte[] array12;
				IntPtr intPtr7;
				long num18;
				int num36;
				int num37;
				oZWYtLnJnekp0ELgSU.YlecR5MJ2SYSVCIgjmG ylecR5MJ2SYSVCIgjmG2;
				string text2;
				int num73;
				for (;;)
				{
					byte[] array6;
					int num7;
					int num8;
					byte[] array8;
					IntPtr intPtr2;
					long num12;
					IntPtr intPtr3;
					uint num13;
					int num14;
					int num15;
					IntPtr intPtr4;
					int num17;
					IntPtr intPtr5;
					IntPtr zero;
					int num20;
					byte[] array14;
					uint num21;
					byte[] array15;
					uint num22;
					IntPtr intPtr8;
					int num24;
					int num25;
					long num26;
					byte[] array16;
					int num27;
					uint num32;
					int num33;
					uint num34;
					Process process;
					IEnumerator enumerator;
					long num42;
					int num53;
					IntPtr intPtr9;
					int num54;
					int num62;
					int num63;
					int num64;
					int num65;
					int num66;
					switch (num2)
					{
					case 0:
						goto IL_484B;
					case 1:
						num3 = 136 - 45;
						num2 = 294;
						continue;
					case 2:
					{
						oZWYtLnJnekp0ELgSU.YlecR5MJ2SYSVCIgjmG ylecR5MJ2SYSVCIgjmG;
						oZWYtLnJnekp0ELgSU.sL4sZQXM3Z0pAfHxyvG(oZWYtLnJnekp0ELgSU.VLmM43P3iS, 0L, ylecR5MJ2SYSVCIgjmG);
						num2 = 6;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 660;
							continue;
						}
						continue;
					}
					case 3:
						array[15] = (byte)num3;
						num2 = 531;
						continue;
					case 4:
						array[21] = (byte)num3;
						num2 = 145;
						continue;
					case 5:
						array2[5] = 116;
						num2 = 48;
						continue;
					case 6:
						array[0] = 209 + 30;
						num2 = 371;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 583;
							continue;
						}
						continue;
					case 7:
						goto IL_2A69;
					case 8:
						array3[3] = (byte)num4;
						num2 = 114;
						continue;
					case 9:
						array4[num5 + 2] = array5[2];
						num2 = 629;
						continue;
					case 10:
						array3[10] = (byte)num4;
						num2 = 557;
						continue;
					case 11:
						array[2] = 165 - 86;
						num2 = 404;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 83;
							continue;
						}
						continue;
					case 12:
						array[27] = (byte)num3;
						num2 = 282;
						continue;
					case 13:
						array2[6] = 105;
						num2 = 236;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 663;
							continue;
						}
						continue;
					case 14:
						goto IL_30FB;
					case 15:
						oZWYtLnJnekp0ELgSU.PR7JhDQ5j7vT2yiEsGw(oZWYtLnJnekp0ELgSU.xp7d2OQLpbQAsqwkJTc(oWeebDMeI9rsA7EJwLV), 0L);
						num2 = 345;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 34;
							continue;
						}
						continue;
					case 16:
						goto IL_6601;
					case 17:
						goto IL_453F;
					case 18:
						intPtr = oZWYtLnJnekp0ELgSU.umAsRJQFLIQlkZeSB5J(oZWYtLnJnekp0ELgSU.M03gMJQ84vK9fEtj2td(oZWYtLnJnekp0ELgSU.ki5Y5BFlNm)[0]);
						num2 = 192;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 610;
							continue;
						}
						continue;
					case 19:
						num6 = 23;
						num2 = 445;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 112;
							continue;
						}
						continue;
					case 20:
						num7 = array6.Length / 4;
						num2 = 108;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 229;
							continue;
						}
						continue;
					case 21:
					{
						byte[] array7;
						num8 = array7.Length / 8;
						num2 = 167;
						continue;
					}
					case 22:
						array3[4] = 177 - 59;
						num2 = 171;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 88;
							continue;
						}
						continue;
					case 23:
						array[25] = 153 + 56;
						num2 = 315;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 207;
							continue;
						}
						continue;
					case 24:
						num3 = 135 - 45;
						num2 = 515;
						continue;
					case 25:
						num3 = 203 + 48;
						num2 = 419;
						continue;
					case 26:
						array8[5] = 116;
						num2 = 105;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 18;
							continue;
						}
						continue;
					case 27:
						array3[5] = (byte)num4;
						num2 = 42;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 30;
							continue;
						}
						continue;
					case 28:
						num4 = 79 - 25;
						num2 = 469;
						continue;
					case 29:
						array3[6] = (byte)num4;
						num2 = 55;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 31;
							continue;
						}
						continue;
					case 30:
					{
						uint num10;
						num9 += num10;
						num2 = 559;
						continue;
					}
					case 31:
						intPtr2 = IntPtr.Zero;
						num2 = 149;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 215;
							continue;
						}
						continue;
					case 32:
						array3[9] = (byte)num4;
						num2 = 616;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 409;
							continue;
						}
						continue;
					case 33:
					{
						object obj = oZWYtLnJnekp0ELgSU.qj3SLhQPWSNSG8JLIec();
						oZWYtLnJnekp0ELgSU.oaISi7Q1dtW2LVR0h9R(obj, CipherMode.CBC);
						ICryptoTransform cryptoTransform = oZWYtLnJnekp0ELgSU.vQWfnSQV7Ovsg54Ya6j(obj, array9, array10);
						num2 = 403;
						continue;
					}
					case 34:
						array[3] = (byte)num3;
						num2 = 487;
						continue;
					case 35:
						goto IL_37EF;
					case 36:
						num11 = oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
						num2 = 685;
						continue;
					case 37:
						array11 = null;
						num2 = 491;
						continue;
					case 38:
						array[22] = (byte)num3;
						num2 = 182;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 381;
							continue;
						}
						continue;
					case 39:
						num4 = 30 + 56;
						num2 = 271;
						continue;
					case 40:
						array[31] = 119 + 111;
						num2 = 64;
						continue;
					case 41:
						goto IL_29E0;
					case 42:
						num4 = 88 + 55;
						num2 = 328;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 156;
							continue;
						}
						continue;
					case 43:
						oZWYtLnJnekp0ELgSU.bqIcOAX9ALsQMmdBt12(new IntPtr(num12), intPtr3);
						num2 = 602;
						continue;
					case 44:
						array8[4] = 105;
						num2 = 26;
						continue;
					case 45:
						goto IL_417F;
					case 46:
						array[8] = 87 + 5;
						num2 = 316;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 31;
							continue;
						}
						continue;
					case 47:
					{
						uint num10 = (uint)(((int)array9[(int)(num13 + 3U)] << 24) | ((int)array9[(int)(num13 + 2U)] << 16) | ((int)array9[(int)(num13 + 1U)] << 8) | (int)array9[(int)num13]);
						num2 = 114;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 270;
							continue;
						}
						continue;
					}
					case 48:
						array2[6] = 46;
						num2 = 666;
						continue;
					case 49:
						if (num14 <= 0)
						{
							goto IL_19EF;
						}
						num2 = 123;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 129;
							continue;
						}
						continue;
					case 50:
						goto IL_5C9C;
					case 51:
						num3 = 213 - 71;
						num2 = 144;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 281;
							continue;
						}
						continue;
					case 52:
						num15++;
						num2 = 45;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 85;
							continue;
						}
						continue;
					case 53:
						array[19] = 117 + 48;
						num2 = 246;
						continue;
					case 54:
						array2[4] = 114;
						num2 = 335;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 341;
							continue;
						}
						continue;
					case 55:
						array3[6] = 152 + 66;
						num2 = 396;
						continue;
					case 56:
						num3 = 33 + 71;
						num2 = 82;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 257;
							continue;
						}
						continue;
					case 57:
						array[10] = 0 + 21;
						num2 = 108;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 268;
							continue;
						}
						continue;
					case 58:
						array[17] = (byte)num3;
						num2 = 594;
						continue;
					case 59:
						array10 = array3;
						num2 = 272;
						continue;
					case 60:
						num3 = 139 + 22;
						num2 = 211;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 363;
							continue;
						}
						continue;
					case 61:
						if (num14 <= 0)
						{
							goto IL_18EF;
						}
						num2 = 188;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 241;
							continue;
						}
						continue;
					case 62:
						array4[num5 + 6] = array11[6];
						num2 = 333;
						continue;
					case 63:
						array[28] = 76 + 81;
						num2 = 352;
						continue;
					case 64:
						array9 = array;
						num2 = 98;
						continue;
					case 65:
						goto IL_4A43;
					case 66:
						if (oZWYtLnJnekp0ELgSU.JnsYd79dMK(intPtr4, num16 * 4, 4, ref num17) != 0)
						{
							goto IL_612D;
						}
						num2 = 474;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 141;
							continue;
						}
						continue;
					case 67:
						array[1] = (byte)num3;
						num2 = 108;
						continue;
					case 68:
						goto IL_5D49;
					case 69:
						oZWYtLnJnekp0ELgSU.R937gUXexb85NuDudZY(oZWYtLnJnekp0ELgSU.PlmylpXBVnLlJDSN2Za(oZWYtLnJnekp0ELgSU.MA67YLXHFXV8OSJpWRM(oZWYtLnJnekp0ELgSU.Kj9YASOMso)));
						num2 = 285;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 480;
							continue;
						}
						continue;
					case 70:
						array3[8] = (byte)num4;
						num2 = 176;
						continue;
					case 71:
						array4[num6 + 2] = array5[2];
						num2 = 614;
						continue;
					case 72:
						num3 = 37 + 101;
						num2 = 405;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 104;
							continue;
						}
						continue;
					case 73:
						array[4] = (byte)num3;
						num2 = 121;
						continue;
					case 74:
						goto IL_28F7;
					case 75:
						array[26] = 100 + 109;
						num2 = 552;
						continue;
					case 76:
						array4[num6] = array12[0];
						num2 = 203;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 178;
							continue;
						}
						continue;
					case 77:
						oZWYtLnJnekp0ELgSU.JnsYd79dMK(intPtr5, 4, 8, ref num17);
						num2 = 142;
						continue;
					case 78:
						goto IL_16BF;
					case 79:
					{
						byte[] array13;
						oZWYtLnJnekp0ELgSU.L69GjhQthsqeKgw4iYs(array13, 0, array13.Length);
						num2 = 93;
						continue;
					}
					case 80:
						goto IL_49A2;
					case 81:
						goto IL_395E;
					case 82:
					{
						byte[] array13;
						if (array13 == null)
						{
							goto IL_4E57;
						}
						num2 = 55;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 624;
							continue;
						}
						continue;
					}
					case 83:
						oZWYtLnJnekp0ELgSU.viCMM2NYad = false;
						num2 = 674;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 186;
							continue;
						}
						continue;
					case 84:
						array[13] = (byte)num3;
						num2 = 386;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 467;
							continue;
						}
						continue;
					case 85:
						goto IL_1636;
					case 86:
						array3[9] = 55 + 102;
						num2 = 9;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 208;
							continue;
						}
						continue;
					case 87:
						array[7] = 213 - 71;
						num2 = 533;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 24;
							continue;
						}
						continue;
					case 88:
						num3 = 171 - 57;
						num2 = 347;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 517;
							continue;
						}
						continue;
					case 89:
						array[18] = (byte)num3;
						num2 = 620;
						continue;
					case 90:
						num3 = 148 + 36;
						num2 = 449;
						continue;
					case 91:
						array4[num5 + 2] = array12[2];
						num2 = 136;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 88;
							continue;
						}
						continue;
					case 92:
						array[0] = (byte)num3;
						num2 = 476;
						continue;
					case 93:
						goto IL_4E57;
					case 94:
						array[8] = 211 - 70;
						num2 = 209;
						continue;
					case 95:
						array8[0] = 103;
						num2 = 173;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 630;
							continue;
						}
						continue;
					case 96:
					{
						byte[] array13 = oZWYtLnJnekp0ELgSU.mCa58RQWvQ5aVo8YpoY(oZWYtLnJnekp0ELgSU.vIRJZFQiow2rqJbm1nd(oZWYtLnJnekp0ELgSU.ki5Y5BFlNm));
						num2 = 79;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 82;
							continue;
						}
						continue;
					}
					case 97:
						num3 = 67 + 86;
						num2 = 223;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 291;
							continue;
						}
						continue;
					case 98:
						array3 = new byte[16];
						num2 = 363;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 649;
							continue;
						}
						continue;
					case 99:
						oZWYtLnJnekp0ELgSU.rP28VlQ2LqGWuC8Gbn7();
						num2 = 5;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 139;
							continue;
						}
						continue;
					case 100:
						array[19] = (byte)num3;
						num2 = 53;
						continue;
					case 101:
					{
						IntPtr intPtr6;
						array11 = oZWYtLnJnekp0ELgSU.oTgX9FXJFsmwfn6SRRA(intPtr6.ToInt64());
						num2 = 400;
						continue;
					}
					case 102:
						array[15] = 103 + 23;
						num2 = 89;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 382;
							continue;
						}
						continue;
					case 103:
						num3 = 2 + 58;
						num2 = 316;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 432;
							continue;
						}
						continue;
					case 104:
						array[23] = 116 + 74;
						num2 = 334;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 402;
							continue;
						}
						continue;
					case 105:
					{
						string text = oZWYtLnJnekp0ELgSU.buT7IbXqGXGFDTT2oMO(oZWYtLnJnekp0ELgSU.zppr0JXrRnwOBtYWdkN(), array8);
						num2 = 190;
						continue;
					}
					case 106:
						array[23] = (byte)num3;
						num2 = 156;
						continue;
					case 107:
						num17 = 0;
						num2 = 117;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 123;
							continue;
						}
						continue;
					case 108:
						array[1] = 202 - 67;
						num2 = 502;
						continue;
					case 109:
						num3 = 34 + 3;
						num2 = 58;
						continue;
					case 110:
						goto IL_3CA9;
					case 111:
						if (!oZWYtLnJnekp0ELgSU.VTKbLyX4u3NyclY6GPK(intPtr7, IntPtr.Zero))
						{
							num2 = 585;
							continue;
						}
						goto IL_49A2;
					case 112:
						num4 = 91 + 64;
						num2 = 262;
						continue;
					case 113:
						goto IL_21B4;
					case 114:
						num4 = 46 + 108;
						num2 = 219;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 194;
							continue;
						}
						continue;
					case 115:
						array4[num6] = array5[0];
						num2 = 648;
						continue;
					case 116:
						oZWYtLnJnekp0ELgSU.eWOYblZENf(intPtr2, intPtr5, oZWYtLnJnekp0ELgSU.gRef9VQAeQd4D7wQjsc(oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV)), 4U, out zero);
						num2 = 421;
						continue;
					case 117:
						array[16] = (byte)num3;
						num2 = 679;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 57;
							continue;
						}
						continue;
					case 118:
						goto IL_4D71;
					case 119:
						goto IL_612D;
					case 120:
						num4 = 51 + 113;
						num2 = 430;
						continue;
					case 121:
						array[4] = 232 - 77;
						num2 = 79;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 639;
							continue;
						}
						continue;
					case 122:
						num18 = 0L;
						num2 = 82;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 310;
							continue;
						}
						continue;
					case 123:
						goto IL_0E92;
					case 124:
						num4 = 116 + 18;
						num2 = 359;
						continue;
					case 125:
						array3[0] = 125 - 75;
						num2 = 397;
						continue;
					case 126:
						array[15] = (byte)num3;
						num2 = 605;
						continue;
					case 127:
						if (oZWYtLnJnekp0ELgSU.HfOnSyQna8wgnIWGO3Q(oZWYtLnJnekp0ELgSU.ki5Y5BFlNm) != null)
						{
							goto IL_3CA9;
						}
						num2 = 181;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 82;
							continue;
						}
						continue;
					case 128:
					{
						uint num10;
						num9 += num10;
						num2 = 618;
						continue;
					}
					case 129:
						num7++;
						num2 = 417;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 528;
							continue;
						}
						continue;
					case 130:
						array2[1] = 108;
						num2 = 621;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 634;
							continue;
						}
						continue;
					case 131:
						array[16] = 24 + 92;
						num2 = 299;
						continue;
					case 132:
						goto IL_0C56;
					case 133:
						num3 = 29 - 4;
						num2 = 138;
						continue;
					case 134:
						num3 = 114 + 50;
						num2 = 273;
						continue;
					case 135:
						num3 = 109 + 97;
						num2 = 619;
						continue;
					case 136:
						array4[num5 + 3] = array12[3];
						num2 = 686;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 438;
							continue;
						}
						continue;
					case 137:
						goto IL_4F60;
					case 138:
						array[4] = (byte)num3;
						num2 = 17;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 7;
							continue;
						}
						continue;
					case 139:
					{
						uint num19;
						if (num19 == 4109628145U)
						{
							num2 = 595;
							continue;
						}
						goto IL_5055;
					}
					case 140:
						goto IL_2194;
					case 141:
						num4 = 53 + 75;
						num2 = 376;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 4;
							continue;
						}
						continue;
					case 142:
						goto IL_40AB;
					case 143:
						array[27] = (byte)num3;
						num2 = 687;
						continue;
					case 144:
						array3[4] = 86 + 87;
						num2 = 22;
						continue;
					case 145:
						array[21] = 86 - 29;
						num2 = 97;
						continue;
					case 146:
						goto IL_2F3D;
					case 147:
						num3 = 86 + 98;
						num2 = 331;
						continue;
					case 148:
						goto IL_3EF6;
					case 149:
						goto IL_3E8D;
					case 150:
						goto IL_54B2;
					case 151:
						num20++;
						num2 = 204;
						continue;
					case 152:
						num3 = 111 + 101;
						num2 = 84;
						continue;
					case 153:
						goto IL_324A;
					case 154:
						array[25] = (byte)num3;
						num2 = 509;
						continue;
					case 155:
						num4 = 84 + 116;
						num2 = 357;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 129;
							continue;
						}
						continue;
					case 156:
						num3 = 111 + 91;
						num2 = 546;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 9;
							continue;
						}
						continue;
					case 157:
						num4 = 149 + 6;
						num2 = 208;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 258;
							continue;
						}
						continue;
					case 158:
						num3 = 30 + 89;
						num2 = 464;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 375;
							continue;
						}
						continue;
					case 159:
						goto IL_13D6;
					case 160:
						array[26] = (byte)num3;
						num2 = 523;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 118;
							continue;
						}
						continue;
					case 161:
						array[20] = 16 + 19;
						num2 = 72;
						continue;
					case 162:
						goto IL_63C0;
					case 163:
						array[18] = (byte)num3;
						num2 = 455;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 437;
							continue;
						}
						continue;
					case 164:
						num3 = 179 - 59;
						num2 = 592;
						continue;
					case 165:
						oZWYtLnJnekp0ELgSU.A2XYzl0jMH = new oZWYtLnJnekp0ELgSU.ETwrgTMIr1cxYXE0vNU(oZWYtLnJnekp0ELgSU.SFKY6QlB41);
						num2 = 330;
						continue;
					case 166:
						array3[3] = 217 - 72;
						num2 = 493;
						continue;
					case 167:
					{
						byte[] array7;
						if ((array14 = array7) != null)
						{
							goto IL_5F80;
						}
						num2 = 548;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 177;
							continue;
						}
						continue;
					}
					case 168:
						num4 = 197 - 93;
						num2 = 549;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 301;
							continue;
						}
						continue;
					case 169:
						goto IL_3E8D;
					case 170:
						num3 = 125 - 119;
						num2 = 308;
						continue;
					case 171:
						array3[4] = 83 - 9;
						num2 = 25;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 511;
							continue;
						}
						continue;
					case 172:
						goto IL_1503;
					case 173:
						oZWYtLnJnekp0ELgSU.ne4hKdQswTIUPaHP1bS();
						num2 = 362;
						continue;
					case 174:
						goto IL_4D3E;
					case 175:
						goto IL_63C0;
					case 176:
						num4 = 37 + 97;
						num2 = 56;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 590;
							continue;
						}
						continue;
					case 177:
						num21 <<= 8;
						num2 = 237;
						continue;
					case 178:
					{
						oZWYtLnJnekp0ELgSU.YlecR5MJ2SYSVCIgjmG ylecR5MJ2SYSVCIgjmG;
						ylecR5MJ2SYSVCIgjmG.ODwMBLqmrQ = new byte[] { 42 };
						num2 = 495;
						continue;
					}
					case 179:
						array4 = array15;
						num2 = 37;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 27;
							continue;
						}
						continue;
					case 180:
						array2[10] = 108;
						num2 = 86;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 199;
							continue;
						}
						continue;
					case 181:
						goto IL_381E;
					case 182:
						array3[2] = 225 - 75;
						num2 = 658;
						continue;
					case 183:
						goto IL_67FB;
					case 184:
						num3 = 154 - 51;
						num2 = 191;
						continue;
					case 185:
						goto IL_0C73;
					case 186:
						array[22] = 204 - 68;
						num2 = 36;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 148;
							continue;
						}
						continue;
					case 187:
						goto IL_3C97;
					case 188:
						num22 = 0U;
						num2 = 49;
						continue;
					case 189:
						goto IL_3D04;
					case 190:
					{
						string text;
						intPtr8 = oZWYtLnJnekp0ELgSU.XLGAvvX6x2a2AsfLKyl((oZWYtLnJnekp0ELgSU.Yt3sXLMNFhiGlDlQbl5)oZWYtLnJnekp0ELgSU.W6I7wsXm2pucHbXEQqk(oZWYtLnJnekp0ELgSU.BuhYHmeams(intPtr7, text), oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU.Yt3sXLMNFhiGlDlQbl5).TypeHandle)));
						num2 = 680;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 232;
							continue;
						}
						continue;
					}
					case 191:
						array[11] = (byte)num3;
						num2 = 307;
						continue;
					case 192:
					{
						int num23 = oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
						num2 = 300;
						continue;
					}
					case 193:
						goto IL_66B6;
					case 194:
						if (num24 != num7 - 1)
						{
							goto IL_16BF;
						}
						num2 = 266;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 101;
							continue;
						}
						continue;
					case 195:
						array3[10] = (byte)num4;
						num2 = 427;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 239;
							continue;
						}
						continue;
					case 196:
						goto IL_30FB;
					case 197:
						return;
					case 198:
						array3[10] = (byte)num4;
						num2 = 458;
						continue;
					case 199:
						array2[11] = 108;
						num2 = 189;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 231;
							continue;
						}
						continue;
					case 200:
						array[30] = 118 + 20;
						num2 = 164;
						continue;
					case 201:
						array[8] = 178 - 59;
						num2 = 588;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 606;
							continue;
						}
						continue;
					case 202:
						array4[num5] = array12[0];
						num2 = 573;
						continue;
					case 203:
						array4[num6 + 1] = array12[1];
						num2 = 646;
						continue;
					case 204:
						goto IL_2630;
					case 205:
						num25 = array9.Length / 4;
						num2 = 383;
						continue;
					case 206:
						array15 = null;
						num2 = 607;
						continue;
					case 207:
						goto IL_4CC9;
					case 208:
						num4 = 190 - 63;
						num2 = 198;
						continue;
					case 209:
						array[8] = 132 - 44;
						num2 = 21;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 46;
							continue;
						}
						continue;
					case 210:
						array[0] = 225 - 75;
						num2 = 4;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 6;
							continue;
						}
						continue;
					case 211:
						goto IL_65BC;
					case 212:
						goto IL_54B2;
					case 213:
						goto IL_4271;
					case 214:
						array[2] = 215 - 71;
						num2 = 236;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 3;
							continue;
						}
						continue;
					case 215:
						intPtr2 = oZWYtLnJnekp0ELgSU.bpwIlGQchPfwu1pxpwN(56U, 1, (uint)oZWYtLnJnekp0ELgSU.C5FeAWQZVGTK2BTtGBD(oZWYtLnJnekp0ELgSU.eAIITKQfcsMe7IrWquf()));
						num2 = 555;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 136;
							continue;
						}
						continue;
					case 216:
						zero = IntPtr.Zero;
						num2 = 234;
						continue;
					case 217:
						array4[num6 + 3] = array11[3];
						num2 = 162;
						continue;
					case 218:
						array[14] = (byte)num3;
						num2 = 526;
						continue;
					case 219:
						array3[3] = (byte)num4;
						num2 = 168;
						continue;
					case 220:
						goto IL_1691;
					case 221:
						if (oZWYtLnJnekp0ELgSU.QD5YClnG2O)
						{
							num2 = 220;
							continue;
						}
						goto IL_1503;
					case 222:
						goto IL_2256;
					case 223:
						array[26] = (byte)num3;
						num2 = 232;
						continue;
					case 224:
						num4 = 172 - 57;
						num2 = 250;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 40;
							continue;
						}
						continue;
					case 225:
						array5 = oZWYtLnJnekp0ELgSU.gRef9VQAeQd4D7wQjsc(oZWYtLnJnekp0ELgSU.z53HdeXTO3eHgOyHUaZ(num26));
						num2 = 483;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 95;
							continue;
						}
						continue;
					case 226:
						goto IL_57A8;
					case 227:
						num3 = 117 + 108;
						num2 = 73;
						continue;
					case 228:
						goto IL_29E0;
					case 229:
						array16 = new byte[array6.Length];
						num2 = 205;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 40;
							continue;
						}
						continue;
					case 230:
						array[28] = 188 - 62;
						num2 = 211;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 411;
							continue;
						}
						continue;
					case 231:
						goto IL_3BDE;
					case 232:
						num3 = 234 - 78;
						num2 = 97;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 143;
							continue;
						}
						continue;
					case 233:
						array3[11] = (byte)num4;
						num2 = 306;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 473;
							continue;
						}
						continue;
					case 234:
						num20 = 0;
						num2 = 311;
						continue;
					case 235:
						array[17] = 84 + 12;
						num2 = 70;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 109;
							continue;
						}
						continue;
					case 236:
						num3 = 222 - 74;
						num2 = 389;
						continue;
					case 237:
						num27 += 8;
						num2 = 367;
						continue;
					case 238:
						try
						{
							oZWYtLnJnekp0ELgSU.Kj9YASOMso = (oZWYtLnJnekp0ELgSU.ETwrgTMIr1cxYXE0vNU)oZWYtLnJnekp0ELgSU.W6I7wsXm2pucHbXEQqk(new IntPtr(num26), oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU.ETwrgTMIr1cxYXE0vNU).TypeHandle));
							int num28 = 0;
							if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
							{
								num28 = 0;
							}
							switch (num28)
							{
							default:
								goto IL_395E;
							}
						}
						catch
						{
							int num29 = 0;
							if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
							{
								num29 = 0;
							}
							switch (num29)
							{
							default:
								try
								{
									Delegate @delegate = oZWYtLnJnekp0ELgSU.W6I7wsXm2pucHbXEQqk(new IntPtr(num26), oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU.ETwrgTMIr1cxYXE0vNU).TypeHandle));
									int num30 = 0;
									if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
									{
										num30 = 0;
									}
									for (;;)
									{
										switch (num30)
										{
										default:
											oZWYtLnJnekp0ELgSU.Kj9YASOMso = (oZWYtLnJnekp0ELgSU.ETwrgTMIr1cxYXE0vNU)oZWYtLnJnekp0ELgSU.XKTvU3Xse1Gr8pMnV5J(oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU.ETwrgTMIr1cxYXE0vNU).TypeHandle), oZWYtLnJnekp0ELgSU.MA67YLXHFXV8OSJpWRM(@delegate));
											num30 = 1;
											if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
											{
												num30 = 1;
											}
											break;
										case 1:
											goto IL_4B5D;
										}
									}
									IL_4B5D:;
								}
								catch
								{
									int num31 = 0;
									if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
									{
										num31 = 0;
									}
									switch (num31)
									{
									}
								}
								break;
							case 1:
								break;
							}
							goto IL_395E;
						}
						goto IL_4BBD;
					case 239:
						array[9] = 152 - 50;
						num2 = 441;
						continue;
					case 240:
						array2[3] = 111;
						num2 = 54;
						continue;
					case 241:
						num32 = num9 ^ num22;
						num2 = 636;
						continue;
					case 242:
						array4[num6 + 1] = array11[1];
						num2 = 378;
						continue;
					case 243:
						goto IL_628F;
					case 244:
					{
						MemoryStream memoryStream = new MemoryStream();
						ICryptoTransform cryptoTransform;
						CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
						byte[] array17;
						oZWYtLnJnekp0ELgSU.DicMpcQpwdnZEt8MyfJ(cryptoStream, array17, 0, array17.Length);
						oZWYtLnJnekp0ELgSU.H7DOYwQ78lPBNY8kF6J(cryptoStream);
						byte[] array7 = oZWYtLnJnekp0ELgSU.Od45OoQDwY08cUtXpSq(memoryStream);
						oZWYtLnJnekp0ELgSU.L69GjhQthsqeKgw4iYs(array10, 0, array10.Length);
						oZWYtLnJnekp0ELgSU.Te126rQCDhb9w4wT09q(memoryStream);
						num2 = 287;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 9;
							continue;
						}
						continue;
					}
					case 245:
						goto IL_3C1F;
					case 246:
						array[19] = 132 - 44;
						num2 = 313;
						continue;
					case 247:
						if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() == 4)
						{
							goto Block_50;
						}
						goto IL_1CD2;
					case 248:
						array2[9] = 108;
						num2 = 519;
						continue;
					case 249:
						num4 = 159 - 53;
						num2 = 70;
						continue;
					case 250:
						array3[13] = (byte)num4;
						num2 = 5;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 393;
							continue;
						}
						continue;
					case 251:
					{
						byte[] array18 = new byte[40];
						oZWYtLnJnekp0ELgSU.rRyfZGXQc95B3Tc1KAi(array18, fieldof(<PrivateImplementationDetails>{E90D0D7C-D1D4-4CF5-9E25-441B34CF0F34}.0E448EF5E5E60630BDDB19388CB6378436E3C65D03DD66DA7C6EBFF563BD857A).FieldHandle);
						array15 = array18;
						num2 = 253;
						continue;
					}
					case 252:
						goto IL_1636;
					case 253:
						goto IL_4D71;
					case 254:
						array[6] = (byte)num3;
						num2 = 139;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 466;
							continue;
						}
						continue;
					case 255:
						goto IL_0C73;
					case 256:
						break;
					case 257:
						array[18] = (byte)num3;
						num2 = 506;
						continue;
					case 258:
						array3[10] = (byte)num4;
						num2 = 417;
						continue;
					case 259:
						array2[4] = 105;
						num2 = 5;
						continue;
					case 260:
						goto IL_2194;
					case 261:
						num3 = 193 - 64;
						num2 = 100;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 70;
							continue;
						}
						continue;
					case 262:
						array3[12] = (byte)num4;
						num2 = 554;
						continue;
					case 263:
						array4[num6 + 3] = array12[3];
						num2 = 500;
						continue;
					case 264:
						array16[num33 + 1] = (byte)((num34 & 65280U) >> 8);
						num2 = 563;
						continue;
					case 265:
					{
						bool flag = true;
						num2 = 292;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 384;
							continue;
						}
						continue;
					}
					case 266:
						if (num14 > 0)
						{
							num2 = 128;
							continue;
						}
						goto IL_16BF;
					case 267:
						goto IL_1C4A;
					case 268:
						num3 = 101 - 46;
						num2 = 439;
						continue;
					case 269:
					{
						byte[] array13;
						array10[7] = array13[3];
						num2 = 662;
						continue;
					}
					case 270:
						num21 = 255U;
						num2 = 580;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 211;
							continue;
						}
						continue;
					case 271:
						array3[1] = (byte)num4;
						num2 = 673;
						continue;
					case 272:
						oZWYtLnJnekp0ELgSU.IH8wUHQyU5ZZTPkQ45A(array10);
						num2 = 96;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 83;
							continue;
						}
						continue;
					case 273:
						array[29] = (byte)num3;
						num2 = 375;
						continue;
					case 274:
						array[2] = (byte)num3;
						num2 = 681;
						continue;
					case 275:
						goto IL_59F1;
					case 276:
						oZWYtLnJnekp0ELgSU.QBpYcRPHGA = intPtr.ToInt64();
						num2 = 216;
						continue;
					case 277:
					{
						int num35 = oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
						bool flag = false;
						if (num35 >= 1879048192)
						{
							num2 = 265;
							continue;
						}
						goto IL_627C;
					}
					case 278:
						goto IL_4DE5;
					case 279:
					{
						byte[] array7;
						oWeebDMeI9rsA7EJwLV = new oZWYtLnJnekp0ELgSU.oWeebDMeI9rsA7EJwLV(new MemoryStream(array7));
						num2 = 15;
						continue;
					}
					case 280:
						oZWYtLnJnekp0ELgSU.JnsYd79dMK(intPtr4, num16 * 4, num17, ref num17);
						num2 = 584;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 283;
							continue;
						}
						continue;
					case 281:
						array[12] = (byte)num3;
						num2 = 343;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 239;
							continue;
						}
						continue;
					case 282:
						array[27] = 174 + 74;
						num2 = 63;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 38;
							continue;
						}
						continue;
					case 283:
						goto IL_0FC6;
					case 284:
						array3[11] = (byte)num4;
						num2 = 499;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 221;
							continue;
						}
						continue;
					case 285:
						array4[num5 + 3] = array11[3];
						num2 = 628;
						continue;
					case 286:
						num24 = 0;
						num2 = 541;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 183;
							continue;
						}
						continue;
					case 287:
					{
						CryptoStream cryptoStream;
						oZWYtLnJnekp0ELgSU.Te126rQCDhb9w4wT09q(cryptoStream);
						num2 = 304;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 292;
							continue;
						}
						continue;
					}
					case 288:
						goto IL_58BD;
					case 289:
						array[0] = 203 - 67;
						num2 = 399;
						continue;
					case 290:
						array[21] = (byte)num3;
						num2 = 317;
						continue;
					case 291:
						array[22] = (byte)num3;
						num2 = 186;
						continue;
					case 292:
						oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
						num2 = 657;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 141;
							continue;
						}
						continue;
					case 293:
						goto IL_578C;
					case 294:
						array[7] = (byte)num3;
						num2 = 87;
						continue;
					case 295:
						array16[num33 + 3] = (byte)((num34 & 4278190080U) >> 24);
						num2 = 485;
						continue;
					case 296:
						num3 = 236 - 78;
						num2 = 274;
						continue;
					case 297:
						array12 = oZWYtLnJnekp0ELgSU.gRef9VQAeQd4D7wQjsc(oZWYtLnJnekp0ELgSU.TAgMrYXt1M.ToInt32());
						num2 = 371;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 235;
							continue;
						}
						continue;
					case 298:
						goto IL_18EF;
					case 299:
						num3 = 99 + 17;
						num2 = 444;
						continue;
					case 300:
					{
						int num23;
						intPtr4 = new IntPtr(oZWYtLnJnekp0ELgSU.QBpYcRPHGA + (long)num23 - (long)num36);
						num2 = 478;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 461;
							continue;
						}
						continue;
					}
					case 301:
						goto IL_5470;
					case 302:
						array3[2] = 71 + 101;
						num2 = 86;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 166;
							continue;
						}
						continue;
					case 303:
						num3 = 126 - 42;
						num2 = 431;
						continue;
					case 304:
						oZWYtLnJnekp0ELgSU.k9HiNLQKfITmH4ZQtif(oWeebDMeI9rsA7EJwLV);
						num2 = 36;
						continue;
					case 305:
						goto IL_48D3;
					case 306:
						num3 = 62 + 80;
						num2 = 475;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 637;
							continue;
						}
						continue;
					case 307:
						array[11] = 143 - 120;
						num2 = 336;
						continue;
					case 308:
						goto IL_1439;
					case 309:
					{
						uint num10 = 0U;
						num2 = 188;
						continue;
					}
					case 310:
						oZWYtLnJnekp0ELgSU.ilo7hpQk0gNF4ZLXB6H(new IntPtr((void*)(&num18)), 0);
						num2 = 482;
						continue;
					case 311:
						goto IL_2630;
					case 312:
						array2[1] = 115;
						num2 = 387;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 292;
							continue;
						}
						continue;
					case 313:
						num3 = 41 + 110;
						num2 = 207;
						continue;
					case 314:
						array[28] = (byte)num3;
						num2 = 134;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 74;
							continue;
						}
						continue;
					case 315:
						array[26] = 114 + 70;
						num2 = 35;
						continue;
					case 316:
						array[8] = 4 + 26;
						num2 = 201;
						continue;
					case 317:
						array[21] = 146 - 48;
						num2 = 522;
						continue;
					case 318:
						array[30] = 200 - 66;
						num2 = 200;
						continue;
					case 319:
						num37++;
						num2 = 392;
						continue;
					case 320:
						array[24] = 82 + 9;
						num2 = 366;
						continue;
					case 321:
						try
						{
							enumerator = oZWYtLnJnekp0ELgSU.fipoe2QNqIyphcFRYUc(oZWYtLnJnekp0ELgSU.smvxgRQItn5ZfWHZjYQ(process));
							int num38 = 1;
							if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
							{
								num38 = 1;
							}
							switch (num38)
							{
							case 1:
								try
								{
									for (;;)
									{
										IL_52B6:
										if (oZWYtLnJnekp0ELgSU.BptMIOQUoVcvlur76Rd(enumerator))
										{
											goto IL_526E;
										}
										int num39 = 3;
										if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
										{
											num39 = 5;
										}
										for (;;)
										{
											IL_522F:
											switch (num39)
											{
											case 1:
												goto IL_52B6;
											case 2:
												num36 = 0;
												num39 = 0;
												if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
												{
													num39 = 0;
													continue;
												}
												continue;
											case 3:
												if (intPtr.ToInt64() == oZWYtLnJnekp0ELgSU.xfTM3KUtTX)
												{
													num39 = 2;
													continue;
												}
												goto IL_52B6;
											case 4:
												goto IL_526E;
											}
											goto Block_377;
										}
										IL_526E:
										intPtr = oZWYtLnJnekp0ELgSU.R8N09wQOaa5hM3yM0Ov((ProcessModule)oZWYtLnJnekp0ELgSU.wyTelKQJW2CUetvkIWe(enumerator));
										num39 = 2;
										if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
										{
											num39 = 3;
											goto IL_522F;
										}
										goto IL_522F;
									}
									Block_377:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num40 = 1;
									if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
									{
										num40 = 1;
									}
									for (;;)
									{
										switch (num40)
										{
										case 1:
											if (disposable == null)
											{
												num40 = 2;
												continue;
											}
											goto IL_5371;
										case 3:
											goto IL_5371;
										}
										break;
										IL_5371:
										oZWYtLnJnekp0ELgSU.tvbFWDQ0x5RHshJZQpc(disposable);
										num40 = 0;
										if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
										{
											num40 = 0;
										}
									}
								}
								break;
							}
							goto IL_4DE5;
						}
						catch
						{
							int num41 = 0;
							if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
							{
								num41 = 0;
							}
							switch (num41)
							{
							default:
								goto IL_4DE5;
							}
						}
						goto IL_53EE;
					case 322:
						if (oZWYtLnJnekp0ELgSU.HfOnSyQna8wgnIWGO3Q(oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU).TypeHandle).Assembly) == null)
						{
							goto Block_284;
						}
						goto IL_2F3D;
					case 323:
						array[15] = 44 + 65;
						num2 = 102;
						continue;
					case 324:
						array3[10] = (byte)num4;
						num2 = 508;
						continue;
					case 325:
						num4 = 139 - 46;
						num2 = 550;
						continue;
					case 326:
						array4[num5 + 4] = array5[4];
						num2 = 6;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 50;
							continue;
						}
						continue;
					case 327:
						goto IL_37B8;
					case 328:
						array3[5] = (byte)num4;
						num2 = 348;
						continue;
					case 329:
					{
						int num43;
						oZWYtLnJnekp0ELgSU.sL4sZQXM3Z0pAfHxyvG(oZWYtLnJnekp0ELgSU.VLmM43P3iS, num42 + (long)num43, ylecR5MJ2SYSVCIgjmG2);
						num2 = 149;
						continue;
					}
					case 330:
					{
						IntPtr intPtr6 = IntPtr.Zero;
						num2 = 593;
						continue;
					}
					case 331:
						array[24] = (byte)num3;
						num2 = 571;
						continue;
					case 332:
						num3 = 39 + 107;
						num2 = 161;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 327;
							continue;
						}
						continue;
					case 333:
						array4[num5 + 7] = array11[7];
						num2 = 175;
						continue;
					case 334:
						array[20] = (byte)num3;
						num2 = 158;
						continue;
					case 335:
						array[5] = 205 - 68;
						num2 = 342;
						continue;
					case 336:
						num3 = 160 - 53;
						num2 = 388;
						continue;
					case 337:
					{
						oZWYtLnJnekp0ELgSU.YlecR5MJ2SYSVCIgjmG ylecR5MJ2SYSVCIgjmG = default(oZWYtLnJnekp0ELgSU.YlecR5MJ2SYSVCIgjmG);
						num2 = 178;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 173;
							continue;
						}
						continue;
					}
					case 338:
						array4[num5 + 7] = array12[7];
						num2 = 612;
						continue;
					case 339:
						array2[9] = 100;
						num2 = 180;
						continue;
					case 340:
						num4 = 2 + 47;
						num2 = 383;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 451;
							continue;
						}
						continue;
					case 341:
						array2[5] = 106;
						num2 = 13;
						continue;
					case 342:
						num3 = 172 - 57;
						num2 = 568;
						continue;
					case 343:
						num3 = 220 - 73;
						num2 = 470;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 430;
							continue;
						}
						continue;
					case 344:
					{
						byte[] array13;
						array10[5] = array13[2];
						num2 = 215;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 269;
							continue;
						}
						continue;
					}
					case 345:
						goto IL_49B5;
					case 346:
						oZWYtLnJnekp0ELgSU.zL2X9YQlUSiDnxJtqP3(new byte[1], 0, oZWYtLnJnekp0ELgSU.anwaBnQ6xSNZEQPccdF(8), 1);
						num2 = 99;
						continue;
					case 347:
						num6 = 9;
						num2 = 76;
						continue;
					case 348:
						num4 = 119 + 88;
						num2 = 668;
						continue;
					case 349:
						num33 = num24 * 4;
						num2 = 383;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 529;
							continue;
						}
						continue;
					case 350:
					{
						uint num19 = 4059231220U;
						num2 = 122;
						continue;
					}
					case 351:
						goto IL_6581;
					case 352:
						num3 = 64 + 78;
						num2 = 308;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 361;
							continue;
						}
						continue;
					case 353:
						num14 = array6.Length % 4;
						num2 = 20;
						continue;
					case 354:
					{
						uint num44 = num9;
						uint num45 = num9;
						uint num46 = 785396777U;
						uint num47 = 851326108U;
						uint num48 = num45;
						uint num49 = 1950741206U;
						uint num50 = 443419207U;
						uint num51 = ((num47 >> 6) | (num47 << 26)) ^ num49;
						uint num52 = num51 & 252645135U;
						num51 &= 4042322160U;
						num47 = (num51 >> 4) | (num52 << 4);
						num48 -= num49;
						num48 = 33939422U * (num48 & 63U) - (num48 >> 6);
						num46 = 62797463U * (num46 & 63U) - (num46 >> 6);
						num47 = 34753U * num47 + num49;
						num51 = num49 & 252645135U;
						num52 = num49 & 4042322160U;
						num51 = ((num51 >> 4) | (num52 << 4)) + num47;
						num49 = (num49 >> 14) | (num49 << 18);
						num50 ^= num47;
						num48 ^= num48 << 3;
						num48 += num46;
						num48 ^= num48 << 25;
						num48 += num49;
						num48 ^= num48 >> 23;
						num48 += num50;
						num48 = (((num48 << 3) - num46) ^ num46) + num48;
						num9 = num44 + (uint)num48;
						num2 = 581;
						continue;
					}
					case 355:
						array4[num5 + 7] = array5[7];
						num2 = 479;
						continue;
					case 356:
						array3[12] = 52 + 32;
						num2 = 247;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 498;
							continue;
						}
						continue;
					case 357:
						array3[11] = (byte)num4;
						num2 = 120;
						continue;
					case 358:
						num3 = 16 + 1;
						num2 = 677;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 128;
							continue;
						}
						continue;
					case 359:
						array3[12] = (byte)num4;
						num2 = 356;
						continue;
					case 360:
						if (!oZWYtLnJnekp0ELgSU.S94vhMXEg5E3gERjXy6(oZWYtLnJnekp0ELgSU.USrQDbXOHrTD8bGIt9i(oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU).TypeHandle).Assembly), null))
						{
							num2 = 41;
							continue;
						}
						goto IL_6581;
					case 361:
						array[28] = (byte)num3;
						num2 = 604;
						continue;
					case 362:
						return;
					case 363:
						array[19] = (byte)num3;
						num2 = 503;
						continue;
					case 364:
						goto IL_25ED;
					case 365:
						num3 = 237 - 79;
						num2 = 290;
						continue;
					case 366:
						array[24] = 156 - 52;
						num2 = 73;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 170;
							continue;
						}
						continue;
					case 367:
						goto IL_4DA2;
					case 368:
						array3[6] = (byte)num4;
						num2 = 372;
						continue;
					case 369:
					{
						byte[] array13;
						array10[3] = array13[1];
						num2 = 344;
						continue;
					}
					case 370:
						array12 = null;
						num2 = 371;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 609;
							continue;
						}
						continue;
					case 371:
					{
						IntPtr intPtr6;
						array11 = oZWYtLnJnekp0ELgSU.gRef9VQAeQd4D7wQjsc(intPtr6.ToInt32());
						num2 = 225;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 92;
							continue;
						}
						continue;
					}
					case 372:
						num4 = 239 - 79;
						num2 = 29;
						continue;
					case 373:
						array[2] = 93 + 30;
						num2 = 9;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 11;
							continue;
						}
						continue;
					case 374:
						array3[0] = 243 - 81;
						num2 = 125;
						continue;
					case 375:
						num3 = 201 - 67;
						num2 = 7;
						continue;
					case 376:
						array3[15] = (byte)num4;
						num2 = 94;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 407;
							continue;
						}
						continue;
					case 377:
						num53++;
						num2 = 213;
						continue;
					case 378:
						array4[num6 + 2] = array11[2];
						num2 = 144;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 217;
							continue;
						}
						continue;
					case 379:
						oZWYtLnJnekp0ELgSU.VLmM43P3iS = new Hashtable(oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV) + 1);
						num2 = 182;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 337;
							continue;
						}
						continue;
					case 380:
						oZWYtLnJnekp0ELgSU.JnsYd79dMK(intPtr9, 4, num17, ref num17);
						num2 = 486;
						continue;
					case 381:
						num3 = 237 - 79;
						num2 = 106;
						continue;
					case 382:
						num3 = 37 - 22;
						num2 = 664;
						continue;
					case 383:
						num9 = 0U;
						num2 = 309;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 122;
							continue;
						}
						continue;
					case 384:
						goto IL_627C;
					case 385:
						if (num54 != 4)
						{
							goto IL_3C97;
						}
						num2 = 7;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 33;
							continue;
						}
						continue;
					case 386:
						num3 = 55 + 121;
						num2 = 587;
						continue;
					case 387:
						array2[2] = 99;
						num2 = 240;
						continue;
					case 388:
						array[12] = (byte)num3;
						num2 = 51;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 41;
							continue;
						}
						continue;
					case 389:
						array[2] = (byte)num3;
						num2 = 296;
						continue;
					case 390:
						goto IL_331E;
					case 391:
						num4 = 58 + 116;
						num2 = 654;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 351;
							continue;
						}
						continue;
					case 392:
						goto IL_48D3;
					case 393:
						num4 = 8 + 44;
						num2 = 505;
						continue;
					case 394:
						array[25] = (byte)num3;
						num2 = 23;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 19;
							continue;
						}
						continue;
					case 395:
						num3 = 38 + 103;
						num2 = 37;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 38;
							continue;
						}
						continue;
					case 396:
						num4 = 131 - 43;
						num2 = 374;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 448;
							continue;
						}
						continue;
					case 397:
						array3[1] = 153 - 51;
						num2 = 10;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 39;
							continue;
						}
						continue;
					case 398:
						array3[15] = (byte)num4;
						num2 = 325;
						continue;
					case 399:
						goto IL_3CD7;
					case 400:
						array5 = oZWYtLnJnekp0ELgSU.oTgX9FXJFsmwfn6SRRA(num26);
						num2 = 545;
						continue;
					case 401:
						oZWYtLnJnekp0ELgSU.PR7JhDQ5j7vT2yiEsGw(oZWYtLnJnekp0ELgSU.xp7d2OQLpbQAsqwkJTc(oWeebDMeI9rsA7EJwLV), 0L);
						num2 = 408;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 408;
							continue;
						}
						continue;
					case 402:
						array[23] = 149 - 49;
						num2 = 147;
						continue;
					case 403:
						oZWYtLnJnekp0ELgSU.L69GjhQthsqeKgw4iYs(array9, 0, array9.Length);
						num2 = 244;
						continue;
					case 404:
						num3 = 0 + 50;
						num2 = 91;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 564;
							continue;
						}
						continue;
					case 405:
						array[20] = (byte)num3;
						num2 = 365;
						continue;
					case 406:
						array[14] = (byte)num3;
						num2 = 543;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 642;
							continue;
						}
						continue;
					case 407:
						num4 = 51 + 111;
						num2 = 64;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 398;
							continue;
						}
						continue;
					case 408:
					{
						byte[] array17 = oZWYtLnJnekp0ELgSU.IiVWu8QxvFjIoIlC4nW(oWeebDMeI9rsA7EJwLV, (int)oZWYtLnJnekp0ELgSU.p3F2aKQRVpe8Q3uAjL4(oZWYtLnJnekp0ELgSU.xp7d2OQLpbQAsqwkJTc(oWeebDMeI9rsA7EJwLV)));
						num2 = 58;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 460;
							continue;
						}
						continue;
					}
					case 409:
					{
						byte[] array7 = array16;
						num2 = 21;
						continue;
					}
					case 410:
						num3 = 88 - 88;
						num2 = 647;
						continue;
					case 411:
						goto IL_5949;
					case 412:
						num3 = 114 + 99;
						num2 = 406;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 376;
							continue;
						}
						continue;
					case 413:
						if (oZWYtLnJnekp0ELgSU.kmkOApQdwc4vlBZTstf(oZWYtLnJnekp0ELgSU.SGJe3QQbWgwGyrJsaXp("System.Reflection.ReflectionContext", false), null))
						{
							goto IL_6601;
						}
						num2 = 78;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 140;
							continue;
						}
						continue;
					case 414:
						array2[0] = 109;
						num2 = 312;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 240;
							continue;
						}
						continue;
					case 415:
						goto IL_204C;
					case 416:
						goto IL_1B82;
					case 417:
						num4 = 216 - 72;
						num2 = 284;
						continue;
					case 418:
						num3 = 97 + 13;
						num2 = 537;
						continue;
					case 419:
						array[13] = (byte)num3;
						num2 = 412;
						continue;
					case 420:
						array4[num5] = array11[0];
						num2 = 222;
						continue;
					case 421:
						goto IL_103B;
					case 422:
						array3[0] = (byte)num4;
						num2 = 374;
						continue;
					case 423:
						num4 = 168 - 56;
						num2 = 434;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 404;
							continue;
						}
						continue;
					case 424:
						if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() == 4)
						{
							num2 = 538;
							continue;
						}
						goto IL_41F3;
					case 425:
						array[10] = 42 + 116;
						num2 = 282;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 303;
							continue;
						}
						continue;
					case 426:
						num12 = (long)oZWYtLnJnekp0ELgSU.SVOrhpXlkncaUKPOcfb(intPtr8);
						num2 = 512;
						continue;
					case 427:
						num4 = 64 + 36;
						num2 = 10;
						continue;
					case 428:
						array3[14] = 16 - 7;
						num2 = 177;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 391;
							continue;
						}
						continue;
					case 429:
						num3 = 6 + 83;
						num2 = 484;
						continue;
					case 430:
						array3[11] = (byte)num4;
						num2 = 112;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 52;
							continue;
						}
						continue;
					case 431:
						array[10] = (byte)num3;
						num2 = 669;
						continue;
					case 432:
						array[12] = (byte)num3;
						num2 = 88;
						continue;
					case 433:
						try
						{
							enumerator = oZWYtLnJnekp0ELgSU.fipoe2QNqIyphcFRYUc(oZWYtLnJnekp0ELgSU.smvxgRQItn5ZfWHZjYQ(process));
							int num55 = 0;
							if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
							{
								num55 = 0;
							}
							switch (num55)
							{
							default:
								try
								{
									for (;;)
									{
										IL_2B33:
										if (oZWYtLnJnekp0ELgSU.BptMIOQUoVcvlur76Rd(enumerator))
										{
											goto IL_2B59;
										}
										int num56 = 1;
										if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
										{
											num56 = 0;
										}
										ProcessModule processModule;
										for (;;)
										{
											IL_2B01:
											switch (num56)
											{
											case 1:
												goto IL_2C53;
											case 2:
											{
												long num57 = num26;
												intPtr = oZWYtLnJnekp0ELgSU.R8N09wQOaa5hM3yM0Ov(processModule);
												if (num57 > intPtr.ToInt64() + (long)oZWYtLnJnekp0ELgSU.O4k0rTXhih2wNyZutCy(processModule))
												{
													num56 = 3;
													continue;
												}
												goto IL_2B33;
											}
											case 3:
												goto IL_2B81;
											case 4:
												goto IL_2BB9;
											case 5:
												oZWYtLnJnekp0ELgSU.ne4hKdQswTIUPaHP1bS();
												num56 = 2;
												if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
												{
													num56 = 4;
													continue;
												}
												continue;
											case 6:
												goto IL_2BE9;
											case 7:
												goto IL_2B33;
											case 8:
												if (!oZWYtLnJnekp0ELgSU.FYxv7UQeKhJw0o8qVkb(oZWYtLnJnekp0ELgSU.NnCryBQGV8TIhGGqsZl(processModule), text2))
												{
													int num58 = 9;
													num56 = num58;
													continue;
												}
												goto IL_2BE9;
											case 9:
												goto IL_2BAA;
											}
											goto Block_308;
											IL_2B81:
											if (oZWYtLnJnekp0ELgSU.S94vhMXEg5E3gERjXy6(oZWYtLnJnekp0ELgSU.USrQDbXOHrTD8bGIt9i(oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU).TypeHandle).Assembly), null))
											{
												num56 = 5;
												continue;
											}
											break;
											IL_2BE9:
											long num59 = num26;
											intPtr = oZWYtLnJnekp0ELgSU.R8N09wQOaa5hM3yM0Ov(processModule);
											if (num59 < intPtr.ToInt64())
											{
												goto IL_2B81;
											}
											num56 = 2;
										}
										IL_2BAA:
										continue;
										Block_308:
										IL_2B59:
										processModule = (ProcessModule)oZWYtLnJnekp0ELgSU.wyTelKQJW2CUetvkIWe(enumerator);
										num56 = 3;
										if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
										{
											num56 = 8;
											goto IL_2B01;
										}
										goto IL_2B01;
									}
									IL_2BB9:
									return;
									IL_2C53:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num60 = 3;
									for (;;)
									{
										switch (num60)
										{
										case 1:
											goto IL_2CBB;
										case 2:
											goto IL_2CDA;
										case 3:
											if (disposable == null)
											{
												num60 = 1;
												if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
												{
													num60 = 1;
													continue;
												}
												continue;
											}
											break;
										}
										oZWYtLnJnekp0ELgSU.tvbFWDQ0x5RHshJZQpc(disposable);
										num60 = 2;
									}
									IL_2CBB:
									IL_2CDA:;
								}
								break;
							case 1:
								break;
							}
							goto IL_4507;
						}
						catch
						{
							int num61 = 0;
							if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
							{
								num61 = 0;
							}
							switch (num61)
							{
							default:
								goto IL_4507;
							}
						}
						goto IL_2D46;
					case 434:
						array3[8] = (byte)num4;
						num2 = 249;
						continue;
					case 435:
					{
						byte[] array13;
						array10[11] = array13[5];
						num2 = 501;
						continue;
					}
					case 436:
						array[2] = (byte)num3;
						num2 = 373;
						continue;
					case 437:
						num3 = 70 - 47;
						num2 = 254;
						continue;
					case 438:
						goto IL_1D69;
					case 439:
						array[10] = (byte)num3;
						num2 = 488;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 57;
							continue;
						}
						continue;
					case 440:
						goto IL_24DF;
					case 441:
						array[9] = 74 + 91;
						num2 = 459;
						continue;
					case 442:
						array2[8] = 108;
						num2 = 248;
						continue;
					case 443:
						goto IL_281A;
					case 444:
						array[16] = (byte)num3;
						num2 = 358;
						continue;
					case 445:
						goto IL_690B;
					case 446:
						goto IL_30E0;
					case 447:
						goto IL_5519;
					case 448:
						array3[7] = (byte)num4;
						num2 = 292;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 463;
							continue;
						}
						continue;
					case 449:
						array[7] = (byte)num3;
						num2 = 94;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 82;
							continue;
						}
						continue;
					case 450:
						array3[15] = 173 - 120;
						num2 = 59;
						continue;
					case 451:
						array3[9] = (byte)num4;
						num2 = 86;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 67;
							continue;
						}
						continue;
					case 452:
						goto IL_21B4;
					case 453:
						array2[3] = 106;
						num2 = 259;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 132;
							continue;
						}
						continue;
					case 454:
					{
						byte[] array19 = oZWYtLnJnekp0ELgSU.IiVWu8QxvFjIoIlC4nW(oWeebDMeI9rsA7EJwLV, num62);
						num2 = 556;
						continue;
					}
					case 455:
						num3 = 209 + 9;
						num2 = 397;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 518;
							continue;
						}
						continue;
					case 456:
						oZWYtLnJnekp0ELgSU.XlTYoWQqRKNRO0iopcF(new IntPtr((void*)(&num18)), 0, IntPtr.Zero);
						num2 = 443;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 35;
							continue;
						}
						continue;
					case 457:
						num3 = 212 - 70;
						num2 = 494;
						continue;
					case 458:
						num4 = 11 + 40;
						num2 = 324;
						continue;
					case 459:
						array[10] = 156 - 52;
						num2 = 425;
						continue;
					case 460:
						goto IL_0CEE;
					case 461:
					{
						byte[] array19;
						ylecR5MJ2SYSVCIgjmG2.ODwMBLqmrQ = array19;
						num2 = 513;
						continue;
					}
					case 462:
						array3[13] = 67 - 17;
						num2 = 598;
						continue;
					case 463:
						array3[7] = 238 - 79;
						num2 = 20;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 627;
							continue;
						}
						continue;
					case 464:
						goto IL_4BBD;
					case 465:
						num3 = 156 - 52;
						num2 = 126;
						continue;
					case 466:
						array[7] = 14 + 62;
						num2 = 1;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 1;
							continue;
						}
						continue;
					case 467:
						num3 = 120 + 74;
						num2 = 676;
						continue;
					case 468:
						goto IL_2787;
					case 469:
						array3[7] = (byte)num4;
						num2 = 423;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 270;
							continue;
						}
						continue;
					case 470:
						array[12] = (byte)num3;
						num2 = 103;
						continue;
					case 471:
						num22 <<= 8;
						num2 = 299;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 446;
							continue;
						}
						continue;
					case 472:
						array3[8] = 81 - 13;
						num2 = 449;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 551;
							continue;
						}
						continue;
					case 473:
						goto IL_64FD;
					case 474:
						oZWYtLnJnekp0ELgSU.JnsYd79dMK(intPtr4, num16 * 4, 8, ref num17);
						num2 = 119;
						continue;
					case 475:
						num3 = 103 + 7;
						num2 = 62;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 160;
							continue;
						}
						continue;
					case 476:
						num3 = 56 + 97;
						num2 = 644;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 261;
							continue;
						}
						continue;
					case 477:
						array3[12] = 141 - 21;
						num2 = 224;
						continue;
					case 478:
						goto IL_3DF1;
					case 479:
						num5 = 30;
						num2 = 420;
						continue;
					case 480:
						oZWYtLnJnekp0ELgSU.Ya5yBNXGRhSsmL2bf5v(oZWYtLnJnekp0ELgSU.A2XYzl0jMH);
						num2 = 566;
						continue;
					case 481:
						num4 = 93 + 34;
						num2 = 8;
						continue;
					case 482:
						oZWYtLnJnekp0ELgSU.aqaylRQTrd9kf58j4r6(new IntPtr((void*)(&num18)), 0);
						num2 = 438;
						continue;
					case 483:
						goto IL_637F;
					case 484:
						goto IL_661C;
					case 485:
						break;
					case 486:
						num63++;
						num2 = 588;
						continue;
					case 487:
						array[3] = 217 - 72;
						num2 = 293;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 539;
							continue;
						}
						continue;
					case 488:
						num3 = 133 - 44;
						num2 = 567;
						continue;
					case 489:
					{
						int num43 = oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV) - num36;
						num2 = 277;
						continue;
					}
					case 490:
						goto IL_5681;
					case 491:
						array5 = null;
						num2 = 338;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 370;
							continue;
						}
						continue;
					case 492:
						array3[13] = 250 - 83;
						num2 = 462;
						continue;
					case 493:
						array3[3] = 99 + 87;
						num2 = 481;
						continue;
					case 494:
						array[13] = (byte)num3;
						num2 = 46;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 152;
							continue;
						}
						continue;
					case 495:
					{
						oZWYtLnJnekp0ELgSU.YlecR5MJ2SYSVCIgjmG ylecR5MJ2SYSVCIgjmG;
						ylecR5MJ2SYSVCIgjmG.JTxMG0kiQa = false;
						num2 = 2;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 0;
							continue;
						}
						continue;
					}
					case 496:
						goto IL_44E8;
					case 497:
						goto IL_5B54;
					case 498:
						array3[12] = 20 + 0;
						num2 = 477;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 244;
							continue;
						}
						continue;
					case 499:
						array3[11] = 206 - 68;
						num2 = 690;
						continue;
					case 500:
						num6 = 16;
						num2 = 115;
						continue;
					case 501:
					{
						byte[] array13;
						array10[13] = array13[6];
						num2 = 661;
						continue;
					}
					case 502:
						num3 = 120 - 95;
						num2 = 540;
						continue;
					case 503:
						num3 = 225 - 75;
						num2 = 334;
						continue;
					case 504:
						array[6] = (byte)num3;
						num2 = 24;
						continue;
					case 505:
						array3[13] = (byte)num4;
						num2 = 492;
						continue;
					case 506:
						goto IL_4BE2;
					case 507:
						goto IL_5BED;
					case 508:
						num4 = 10 + 66;
						num2 = 103;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 195;
							continue;
						}
						continue;
					case 509:
						num3 = 235 - 78;
						num2 = 13;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 394;
							continue;
						}
						continue;
					case 510:
						array8[2] = 116;
						num2 = 615;
						continue;
					case 511:
						num4 = 180 - 60;
						num2 = 27;
						continue;
					case 512:
						goto IL_6045;
					case 513:
					{
						bool flag;
						ylecR5MJ2SYSVCIgjmG2.JTxMG0kiQa = flag;
						num2 = 329;
						continue;
					}
					case 514:
						array3[14] = 220 - 73;
						num2 = 428;
						continue;
					case 515:
						array[6] = (byte)num3;
						num2 = 553;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 154;
							continue;
						}
						continue;
					case 516:
						goto IL_103B;
					case 517:
						array[12] = (byte)num3;
						num2 = 520;
						continue;
					case 518:
						array[18] = (byte)num3;
						num2 = 261;
						continue;
					case 519:
						text2 = oZWYtLnJnekp0ELgSU.buT7IbXqGXGFDTT2oMO(oZWYtLnJnekp0ELgSU.zppr0JXrRnwOBtYWdkN(), array2);
						num2 = 314;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 468;
							continue;
						}
						continue;
					case 520:
						array[12] = 123 - 53;
						num2 = 457;
						continue;
					case 521:
						goto IL_40D4;
					case 522:
						num3 = 186 - 62;
						num2 = 4;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 1;
							continue;
						}
						continue;
					case 523:
						array[26] = 245 - 81;
						num2 = 75;
						continue;
					case 524:
						goto IL_6196;
					case 525:
					{
						byte[] array13;
						array10[1] = array13[0];
						num2 = 369;
						continue;
					}
					case 526:
						array[14] = 184 + 31;
						num2 = 465;
						continue;
					case 527:
						goto IL_381E;
					case 528:
						goto IL_19EF;
					case 529:
						num13 = (uint)(num64 * 4);
						num2 = 28;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 47;
							continue;
						}
						continue;
					case 530:
						array16[num33] = (byte)(num34 & 255U);
						num2 = 264;
						continue;
					case 531:
						num3 = 118 + 27;
						num2 = 507;
						continue;
					case 532:
						if (oZWYtLnJnekp0ELgSU.JnsYd79dMK(intPtr9, 4, 4, ref num17) == 0)
						{
							goto IL_66B6;
						}
						num2 = 625;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 105;
							continue;
						}
						continue;
					case 533:
						goto IL_53EE;
					case 534:
						goto IL_6323;
					case 535:
						goto IL_21D7;
					case 536:
						array4[num5] = array5[0];
						num2 = 263;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 578;
							continue;
						}
						continue;
					case 537:
						array[6] = (byte)num3;
						num2 = 378;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 572;
							continue;
						}
						continue;
					case 538:
						num26 = (long)oZWYtLnJnekp0ELgSU.SVOrhpXlkncaUKPOcfb(new IntPtr(num12));
						num2 = 150;
						continue;
					case 539:
						array[3] = 194 - 64;
						num2 = 410;
						continue;
					case 540:
						array[1] = (byte)num3;
						num2 = 214;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 160;
							continue;
						}
						continue;
					case 541:
						goto IL_331E;
					case 542:
						array[30] = 21 + 115;
						num2 = 570;
						continue;
					case 543:
						array[23] = (byte)num3;
						num2 = 20;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 104;
							continue;
						}
						continue;
					case 544:
						array14 = null;
						num2 = 113;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 279;
							continue;
						}
						continue;
					case 545:
						goto IL_637F;
					case 546:
						array[23] = (byte)num3;
						num2 = 43;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 608;
							continue;
						}
						continue;
					case 547:
						array4[num5 + 6] = array5[6];
						num2 = 355;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 152;
							continue;
						}
						continue;
					case 548:
						goto IL_5B54;
					case 549:
						array3[3] = (byte)num4;
						num2 = 144;
						continue;
					case 550:
						array3[15] = (byte)num4;
						num2 = 450;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 84;
							continue;
						}
						continue;
					case 551:
						num4 = 199 - 66;
						num2 = 32;
						continue;
					case 552:
						num3 = 162 + 52;
						num2 = 223;
						continue;
					case 553:
						array[6] = 244 - 81;
						num2 = 437;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 255;
							continue;
						}
						continue;
					case 554:
						array3[12] = 163 - 54;
						num2 = 124;
						continue;
					case 555:
						if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() == 4)
						{
							num2 = 18;
							continue;
						}
						goto IL_1943;
					case 556:
						goto IL_5E14;
					case 557:
						num4 = 211 - 70;
						num2 = 231;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 682;
							continue;
						}
						continue;
					case 558:
					{
						byte[] array17;
						array6 = array17;
						num2 = 353;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 95;
							continue;
						}
						continue;
					}
					case 559:
						num22 = (uint)(((int)array6[(int)(num13 + 3U)] << 24) | ((int)array6[(int)(num13 + 2U)] << 16) | ((int)array6[(int)(num13 + 1U)] << 8) | (int)array6[(int)num13]);
						num2 = 447;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 139;
							continue;
						}
						continue;
					case 560:
						goto IL_265C;
					case 561:
						goto IL_1943;
					case 562:
						array[26] = (byte)num3;
						num2 = 475;
						continue;
					case 563:
						array16[num33 + 2] = (byte)((num34 & 16711680U) >> 16);
						num2 = 295;
						continue;
					case 564:
						array[3] = (byte)num3;
						num2 = 623;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 388;
							continue;
						}
						continue;
					case 565:
						num4 = 56 + 103;
						num2 = 368;
						continue;
					case 566:
						oZWYtLnJnekp0ELgSU.R937gUXexb85NuDudZY(oZWYtLnJnekp0ELgSU.PlmylpXBVnLlJDSN2Za(oZWYtLnJnekp0ELgSU.MA67YLXHFXV8OSJpWRM(oZWYtLnJnekp0ELgSU.A2XYzl0jMH)));
						num2 = 206;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 50;
							continue;
						}
						continue;
					case 567:
						array[11] = (byte)num3;
						num2 = 184;
						continue;
					case 568:
						array[5] = (byte)num3;
						num2 = 104;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 332;
							continue;
						}
						continue;
					case 569:
						if (oZWYtLnJnekp0ELgSU.JnsYd79dMK(intPtr5, 4, 4, ref num17) == 0)
						{
							num2 = 77;
							continue;
						}
						goto IL_40AB;
					case 570:
						array[31] = 104 + 17;
						num2 = 582;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 294;
							continue;
						}
						continue;
					case 571:
						num3 = 127 - 42;
						num2 = 211;
						continue;
					case 572:
						num3 = 199 - 66;
						num2 = 388;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 504;
							continue;
						}
						continue;
					case 573:
						array4[num5 + 1] = array12[1];
						num2 = 91;
						continue;
					case 574:
						num65++;
						num2 = 452;
						continue;
					case 575:
						num3 = 6 + 29;
						num2 = 117;
						continue;
					case 576:
						num66 = 0;
						num2 = 243;
						continue;
					case 577:
						num3 = 45 + 111;
						num2 = 3;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 12;
							continue;
						}
						continue;
					case 578:
						array4[num5 + 1] = array5[1];
						num2 = 9;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 4;
							continue;
						}
						continue;
					case 579:
						oZWYtLnJnekp0ELgSU.hACMYVikmk = oZWYtLnJnekp0ELgSU.z53HdeXTO3eHgOyHUaZ(oZWYtLnJnekp0ELgSU.xfTM3KUtTX);
						num2 = 226;
						continue;
					case 580:
						num27 = 0;
						num2 = 194;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 38;
							continue;
						}
						continue;
					case 581:
						if (num24 != num7 - 1)
						{
							goto IL_18EF;
						}
						num2 = 1;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 61;
							continue;
						}
						continue;
					case 582:
						num3 = 246 - 82;
						num2 = 84;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 597;
							continue;
						}
						continue;
					case 583:
						num3 = 77 + 75;
						num2 = 67;
						continue;
					case 584:
						goto IL_40D4;
					case 585:
						goto IL_28F7;
					case 586:
						goto IL_1CD2;
					case 587:
						array[0] = (byte)num3;
						num2 = 289;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 2;
							continue;
						}
						continue;
					case 588:
						goto IL_13D6;
					case 589:
						goto IL_5F80;
					case 590:
						array3[8] = (byte)num4;
						num2 = 215;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 472;
							continue;
						}
						continue;
					case 591:
						goto IL_2EF8;
					case 592:
						array[30] = (byte)num3;
						num2 = 115;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 542;
							continue;
						}
						continue;
					case 593:
					{
						IntPtr intPtr6 = oZWYtLnJnekp0ELgSU.Tk3Y1MXf8CVQeFgxrst(oZWYtLnJnekp0ELgSU.A2XYzl0jMH);
						num2 = 0;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					}
					case 594:
						num3 = 144 - 34;
						num2 = 275;
						continue;
					case 595:
						if (!oZWYtLnJnekp0ELgSU.E3UTKpQHJJi4Xj4Ti5U(oZWYtLnJnekp0ELgSU.pGjmj2QE08YunNtF4ax(oZWYtLnJnekp0ELgSU.R8N09wQOaa5hM3yM0Ov(oZWYtLnJnekp0ELgSU.zN2iPGQhv83Ex4VEWU2(oZWYtLnJnekp0ELgSU.eAIITKQfcsMe7IrWquf())), "__", 10U), IntPtr.Zero))
						{
							num2 = 596;
							continue;
						}
						goto IL_5055;
					case 596:
						oZWYtLnJnekp0ELgSU.ne4hKdQswTIUPaHP1bS();
						num2 = 635;
						continue;
					case 597:
						array[31] = (byte)num3;
						num2 = 40;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 14;
							continue;
						}
						continue;
					case 598:
						array3[14] = 23 + 85;
						num2 = 245;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 514;
							continue;
						}
						continue;
					case 599:
						num4 = 203 - 67;
						num2 = 293;
						continue;
					case 600:
						try
						{
							object obj2 = oZWYtLnJnekp0ELgSU.aVgCi2XNiaMgaU3uUnA(oZWYtLnJnekp0ELgSU.SaLkHYXIUBMrjj3htJO(oZWYtLnJnekp0ELgSU.RcMBnJXdRsDiKQ22qF9(oZWYtLnJnekp0ELgSU.ShE46sXbmaRQgWQMwLb(oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU).TypeHandle).Assembly))).GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), oZWYtLnJnekp0ELgSU.RcMBnJXdRsDiKQ22qF9(oZWYtLnJnekp0ELgSU.ShE46sXbmaRQgWQMwLb(oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU).TypeHandle).Assembly)));
							int num67 = 8;
							for (;;)
							{
								MemoryStream memoryStream2;
								int num71;
								switch (num67)
								{
								case 0:
									goto IL_36F6;
								case 1:
								{
									uint num68 = 0U;
									num67 = 6;
									continue;
								}
								case 2:
									goto IL_3777;
								case 3:
									oZWYtLnJnekp0ELgSU.DicMpcQpwdnZEt8MyfJ(memoryStream2, new byte[oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ()], 0, oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ());
									num67 = 6;
									if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
									{
										num67 = 15;
										continue;
									}
									continue;
								case 4:
									goto IL_33FA;
								case 5:
									oZWYtLnJnekp0ELgSU.TAgMrYXt1M = (IntPtr)oZWYtLnJnekp0ELgSU.aVgCi2XNiaMgaU3uUnA(obj2.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), obj2);
									num67 = 0;
									if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
									{
										num67 = 0;
										continue;
									}
									continue;
								case 6:
									try
									{
										byte[] array20;
										if ((array14 = array20) == null)
										{
											goto IL_35A0;
										}
										int num69 = 2;
										byte* ptr;
										for (;;)
										{
											IL_357E:
											switch (num69)
											{
											case 1:
												goto IL_35A0;
											case 2:
												if (array14.Length == 0)
												{
													num69 = 1;
													if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
													{
														num69 = 0;
														continue;
													}
													continue;
												}
												break;
											case 3:
												goto IL_3615;
											case 4:
												goto IL_3615;
											case 5:
												goto IL_365D;
											}
											ptr = &array14[0];
											num69 = 3;
											if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
											{
												num69 = 3;
												continue;
											}
											continue;
											IL_3615:
											uint num68;
											oZWYtLnJnekp0ELgSU.A2XYzl0jMH(new IntPtr((void*)ptr), new IntPtr((void*)ptr), new IntPtr((void*)ptr), 216669565U, new IntPtr((void*)ptr), ref num68);
											num69 = 5;
											if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
											{
												num69 = 5;
											}
										}
										IL_365D:
										goto IL_3777;
										IL_35A0:
										ptr = null;
										num69 = 4;
										goto IL_357E;
									}
									finally
									{
										array14 = null;
										int num70 = 0;
										if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
										{
											num70 = 0;
										}
										switch (num70)
										{
										}
									}
									goto IL_369C;
								case 7:
									oZWYtLnJnekp0ELgSU.DicMpcQpwdnZEt8MyfJ(memoryStream2, oZWYtLnJnekp0ELgSU.gRef9VQAeQd4D7wQjsc(oZWYtLnJnekp0ELgSU.TAgMrYXt1M.ToInt32()), 0, 4);
									num71 = 9;
									break;
								case 8:
									if (!(obj2 is IntPtr))
									{
										num67 = 17;
										continue;
									}
									goto IL_372D;
								case 9:
									goto IL_33FA;
								case 10:
									oZWYtLnJnekp0ELgSU.PR7JhDQ5j7vT2yiEsGw(memoryStream2, 0L);
									num67 = 7;
									if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
									{
										num67 = 12;
										continue;
									}
									continue;
								case 11:
									goto IL_36BE;
								case 12:
								{
									byte[] array20 = oZWYtLnJnekp0ELgSU.Od45OoQDwY08cUtXpSq(memoryStream2);
									num67 = 18;
									continue;
								}
								case 13:
									goto IL_372D;
								case 14:
									oZWYtLnJnekp0ELgSU.DicMpcQpwdnZEt8MyfJ(memoryStream2, new byte[oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ()], 0, oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ());
									num67 = 10;
									if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
									{
										num67 = 10;
										continue;
									}
									continue;
								case 15:
									if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() != 4)
									{
										goto IL_369C;
									}
									num67 = 7;
									if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
									{
										num67 = 4;
										continue;
									}
									continue;
								case 16:
									goto IL_369C;
								case 17:
									goto IL_36BE;
								case 18:
									oZWYtLnJnekp0ELgSU.Te126rQCDhb9w4wT09q(memoryStream2);
									num67 = 1;
									if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
									{
										num67 = 1;
										continue;
									}
									continue;
								default:
									goto IL_36F6;
								}
								IL_33A0:
								num67 = num71;
								continue;
								IL_33FA:
								oZWYtLnJnekp0ELgSU.DicMpcQpwdnZEt8MyfJ(memoryStream2, new byte[oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ()], 0, oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ());
								num67 = 14;
								if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
								{
									num67 = 12;
									continue;
								}
								continue;
								IL_369C:
								oZWYtLnJnekp0ELgSU.DicMpcQpwdnZEt8MyfJ(memoryStream2, oZWYtLnJnekp0ELgSU.oTgX9FXJFsmwfn6SRRA(oZWYtLnJnekp0ELgSU.TAgMrYXt1M.ToInt64()), 0, 8);
								num67 = 4;
								continue;
								IL_36F6:
								memoryStream2 = new MemoryStream();
								num67 = 3;
								if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
								{
									num67 = 2;
									continue;
								}
								continue;
								IL_36BE:
								if (oZWYtLnJnekp0ELgSU.FYxv7UQeKhJw0o8qVkb(obj2.GetType().ToString(), "System.Reflection.RuntimeModule"))
								{
									num71 = 5;
									goto IL_33A0;
								}
								goto IL_36F6;
								IL_372D:
								oZWYtLnJnekp0ELgSU.TAgMrYXt1M = (IntPtr)obj2;
								num67 = 11;
							}
							IL_3777:
							goto IL_1910;
						}
						catch
						{
							int num72 = 0;
							if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
							{
								num72 = 0;
							}
							switch (num72)
							{
							default:
								goto IL_1910;
							}
						}
						goto IL_37B8;
					case 601:
						array[22] = (byte)num3;
						num2 = 395;
						continue;
					case 602:
						oZWYtLnJnekp0ELgSU.JnsYd79dMK(new IntPtr(num12), oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ(), num73, ref num73);
						num2 = 611;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 104;
							continue;
						}
						continue;
					case 603:
						array4[num5 + 6] = array12[6];
						num2 = 338;
						continue;
					case 604:
						array[28] = 210 - 70;
						num2 = 230;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 132;
							continue;
						}
						continue;
					case 605:
						num3 = 174 - 58;
						num2 = 2;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 3;
							continue;
						}
						continue;
					case 606:
						array[8] = 121 - 31;
						num2 = 678;
						continue;
					case 607:
						if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() != 4)
						{
							num2 = 251;
							continue;
						}
						goto IL_1C4A;
					case 608:
						num3 = 128 - 42;
						num2 = 543;
						continue;
					case 609:
						if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() == 4)
						{
							num2 = 297;
							continue;
						}
						goto IL_1AB7;
					case 610:
						oZWYtLnJnekp0ELgSU.GJBYZM4sKa = intPtr.ToInt32();
						num2 = 237;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 561;
							continue;
						}
						continue;
					case 611:
						goto IL_1691;
					case 612:
						num5 = 18;
						num2 = 536;
						continue;
					case 613:
						num4 = 240 - 117;
						num2 = 41;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 153;
							continue;
						}
						continue;
					case 614:
						array4[num6 + 3] = array5[3];
						num2 = 19;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 615:
						array8[3] = 74;
						num2 = 44;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 11;
							continue;
						}
						continue;
					case 616:
						array3[9] = 10 + 35;
						num2 = 340;
						continue;
					case 617:
						return;
					case 618:
						num22 = 0U;
						num2 = 55;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 576;
							continue;
						}
						continue;
					case 619:
						array[30] = (byte)num3;
						num2 = 318;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 141;
							continue;
						}
						continue;
					case 620:
						array[18] = 135 - 45;
						num2 = 56;
						continue;
					case 621:
						goto IL_4271;
					case 622:
						goto IL_1910;
					case 623:
						num3 = 38 + 53;
						num2 = 34;
						continue;
					case 624:
					{
						byte[] array13;
						if (array13.Length != 0)
						{
							num2 = 525;
							continue;
						}
						goto IL_4E57;
					}
					case 625:
						goto IL_28C7;
					case 626:
						array[27] = 48 + 118;
						num2 = 577;
						continue;
					case 627:
						num4 = 235 - 78;
						num2 = 645;
						continue;
					case 628:
						goto IL_1894;
					case 629:
						array4[num5 + 3] = array5[3];
						num2 = 326;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 85;
							continue;
						}
						continue;
					case 630:
						array8[1] = 101;
						num2 = 510;
						continue;
					case 631:
						num54 = oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
						num2 = 385;
						continue;
					case 632:
						goto IL_0FC6;
					case 633:
						num66++;
						num2 = 640;
						continue;
					case 634:
						array2[2] = 114;
						num2 = 202;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 453;
							continue;
						}
						continue;
					case 635:
						return;
					case 636:
						num15 = 0;
						num2 = 252;
						continue;
					case 637:
						array[27] = (byte)num3;
						num2 = 626;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 283;
							continue;
						}
						continue;
					case 638:
						goto IL_41F3;
					case 639:
						array[4] = 110 + 66;
						num2 = 429;
						continue;
					case 640:
						goto IL_628F;
					case 641:
						goto IL_4507;
					case 642:
						num3 = 221 - 73;
						num2 = 218;
						continue;
					case 643:
						goto IL_10C3;
					case 644:
						array[0] = (byte)num3;
						num2 = 210;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 645:
						array3[7] = (byte)num4;
						num2 = 28;
						continue;
					case 646:
						array4[num6 + 2] = array12[2];
						num2 = 263;
						continue;
					case 647:
						array[3] = (byte)num3;
						num2 = 227;
						continue;
					case 648:
						array4[num6 + 1] = array5[1];
						num2 = 71;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 62;
							continue;
						}
						continue;
					case 649:
						num4 = 182 - 60;
						num2 = 29;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 422;
							continue;
						}
						continue;
					case 650:
						array[13] = (byte)num3;
						num2 = 25;
						continue;
					case 651:
						array[20] = 132 - 44;
						num2 = 161;
						continue;
					case 652:
						goto IL_2D46;
					case 653:
						goto IL_1AB7;
					case 654:
						array3[15] = (byte)num4;
						num2 = 141;
						continue;
					case 655:
						array[24] = 66 + 43;
						num2 = 320;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 9;
							continue;
						}
						continue;
					case 656:
						oZWYtLnJnekp0ELgSU.MWK9VjQm7ZCw5QmRIiY(new IntPtr((void*)(&num18)), 0, 0L);
						num2 = 346;
						continue;
					case 657:
						oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
						num2 = 535;
						continue;
					case 658:
						array3[2] = 204 - 68;
						num2 = 599;
						continue;
					case 659:
						goto IL_28C7;
					case 660:
					{
						bool flag = false;
						num2 = 169;
						continue;
					}
					case 661:
					{
						byte[] array13;
						array10[15] = array13[7];
						num2 = 79;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 34;
							continue;
						}
						continue;
					}
					case 662:
					{
						byte[] array13;
						array10[9] = array13[4];
						num2 = 435;
						continue;
					}
					case 663:
						array2[7] = 116;
						num2 = 667;
						continue;
					case 664:
						array[15] = (byte)num3;
						num2 = 131;
						continue;
					case 665:
						goto IL_3C42;
					case 666:
						array2[7] = 100;
						num2 = 442;
						continue;
					case 667:
						array2[8] = 46;
						num2 = 339;
						continue;
					case 668:
						array3[5] = (byte)num4;
						num2 = 613;
						continue;
					case 669:
						array[10] = 32 + 102;
						num2 = 57;
						continue;
					case 670:
						oZWYtLnJnekp0ELgSU.ne4hKdQswTIUPaHP1bS();
						num2 = 90;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 197;
							continue;
						}
						continue;
					case 671:
						try
						{
							for (;;)
							{
								IL_3A48:
								if (oZWYtLnJnekp0ELgSU.BptMIOQUoVcvlur76Rd(enumerator))
								{
									goto IL_3A30;
								}
								int num74 = 3;
								ProcessModule processModule2;
								for (;;)
								{
									IL_39B1:
									Version version2;
									Version version3;
									switch (num74)
									{
									case 0:
										goto IL_3B22;
									case 1:
										goto IL_3A5E;
									case 2:
										if (!oZWYtLnJnekp0ELgSU.FYxv7UQeKhJw0o8qVkb(oZWYtLnJnekp0ELgSU.bWeV1hQBrwNHoEePHPo(oZWYtLnJnekp0ELgSU.NnCryBQGV8TIhGGqsZl(processModule2)), "clrjit.dll"))
										{
											num74 = 4;
											continue;
										}
										break;
									case 3:
										goto IL_3B4F;
									case 4:
										goto IL_3B0F;
									case 5:
									{
										Version version = new Version(4, 0, 30319, 17020);
										num74 = 0;
										if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
										{
											num74 = 0;
											continue;
										}
										continue;
									}
									case 6:
										if (oZWYtLnJnekp0ELgSU.GitQGYQwar8caGEHe3H(version2, version3))
										{
											num74 = 10;
											continue;
										}
										goto IL_3A48;
									case 7:
										goto IL_3A30;
									case 8:
										goto IL_3A48;
									case 9:
										break;
									case 10:
										oZWYtLnJnekp0ELgSU.AwMYLIYgO4 = true;
										num74 = 0;
										if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
										{
											num74 = 1;
											continue;
										}
										continue;
									case 11:
									{
										Version version;
										if (oZWYtLnJnekp0ELgSU.dncso1QgO1OInyecB4B(version2, version))
										{
											num74 = 6;
											continue;
										}
										goto IL_3A48;
									}
									default:
										goto IL_3B22;
									}
									version2 = new Version(oZWYtLnJnekp0ELgSU.AjD1vpQXCI8XGNQV85u(oZWYtLnJnekp0ELgSU.W4Zfa7QQrq1IOWe9sGC(processModule2)), oZWYtLnJnekp0ELgSU.zttBxHQ9AifJvCV0BEh(oZWYtLnJnekp0ELgSU.W4Zfa7QQrq1IOWe9sGC(processModule2)), oZWYtLnJnekp0ELgSU.wWbhWEQSVKZ8LEGGDbb(oZWYtLnJnekp0ELgSU.W4Zfa7QQrq1IOWe9sGC(processModule2)), oZWYtLnJnekp0ELgSU.lFYf5WQu8mikFAaT5fJ(oZWYtLnJnekp0ELgSU.W4Zfa7QQrq1IOWe9sGC(processModule2)));
									num74 = 5;
									continue;
									IL_3B22:
									version3 = new Version(4, 0, 30319, 17921);
									num74 = 8;
									if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
									{
										num74 = 11;
									}
								}
								IL_3B0F:
								continue;
								IL_3A30:
								processModule2 = (ProcessModule)oZWYtLnJnekp0ELgSU.wyTelKQJW2CUetvkIWe(enumerator);
								num74 = 2;
								goto IL_39B1;
							}
							IL_3A5E:
							IL_3B4F:
							goto IL_2194;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							int num75 = 0;
							if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
							{
								num75 = 0;
							}
							for (;;)
							{
								switch (num75)
								{
								case 1:
									goto IL_3BD3;
								case 2:
									oZWYtLnJnekp0ELgSU.tvbFWDQ0x5RHshJZQpc(disposable);
									num75 = 1;
									if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
									{
										num75 = 1;
										continue;
									}
									continue;
								}
								if (disposable == null)
								{
									break;
								}
								num75 = 2;
								if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
								{
									num75 = 1;
								}
							}
							IL_3BD3:;
						}
						goto IL_3BDE;
					case 672:
						num3 = 96 + 78;
						num2 = 89;
						continue;
					case 673:
						goto IL_4380;
					case 674:
						oZWYtLnJnekp0ELgSU.JnsYd79dMK(new IntPtr(num12), oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ(), 64, ref num73);
						num2 = 43;
						continue;
					case 675:
						goto IL_6045;
					case 676:
						array[13] = (byte)num3;
						num2 = 340;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 416;
							continue;
						}
						continue;
					case 677:
						array[16] = (byte)num3;
						num2 = 575;
						continue;
					case 678:
						goto IL_1E67;
					case 679:
						array[16] = 57 + 93;
						num2 = 301;
						continue;
					case 680:
						num12 = 0L;
						num2 = 236;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
						{
							num2 = 247;
							continue;
						}
						continue;
					case 681:
						num3 = 238 - 79;
						num2 = 436;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 212;
							continue;
						}
						continue;
					case 682:
						array3[10] = (byte)num4;
						num2 = 33;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 157;
							continue;
						}
						continue;
					case 683:
						array[25] = 109 + 51;
						num2 = 132;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 106;
							continue;
						}
						continue;
					case 684:
						num42 = intPtr.ToInt64();
						num2 = 107;
						if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
						{
							num2 = 43;
							continue;
						}
						continue;
					case 685:
						num54 = oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
						num2 = 187;
						continue;
					case 686:
						array4[num5 + 4] = array12[4];
						num2 = 440;
						if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 98;
							continue;
						}
						continue;
					case 687:
						array[27] = 216 - 72;
						num2 = 290;
						if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
						{
							num2 = 306;
							continue;
						}
						continue;
					case 688:
						oZWYtLnJnekp0ELgSU.xfTM3KUtTX = intPtr.ToInt64();
						num2 = 652;
						continue;
					case 689:
						goto IL_6570;
					case 690:
						num4 = 26 + 70;
						num2 = 233;
						continue;
					default:
						goto IL_484B;
					}
					num24++;
					num2 = 390;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 325;
						continue;
					}
					continue;
					IL_0C73:
					byte* ptr2 = &array14[0];
					num2 = 196;
					continue;
					IL_0FC6:
					oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
					num2 = 230;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
					{
						num2 = 292;
						continue;
					}
					continue;
					IL_103B:
					oZWYtLnJnekp0ELgSU.JnsYd79dMK(intPtr5, 4, num17, ref num17);
					num2 = 151;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 34;
						continue;
					}
					continue;
					IL_10C3:
					if (num15 > 0)
					{
						num2 = 177;
						continue;
					}
					goto IL_4DA2;
					IL_1636:
					if (num15 >= num14)
					{
						num2 = 256;
						continue;
					}
					goto IL_10C3;
					IL_13D6:
					if (num63 < num11)
					{
						goto IL_4F60;
					}
					num2 = 5;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
					{
						num2 = 379;
						continue;
					}
					continue;
					IL_1503:
					oZWYtLnJnekp0ELgSU.QD5YClnG2O = true;
					num2 = 350;
					continue;
					IL_1691:
					oZWYtLnJnekp0ELgSU.ne4hKdQswTIUPaHP1bS();
					num2 = 617;
					continue;
					IL_16BF:
					num13 = (uint)num33;
					num2 = 30;
					continue;
					IL_18EF:
					num34 = num9 ^ num22;
					num2 = 530;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
					{
						num2 = 83;
						continue;
					}
					continue;
					IL_1910:
					oZWYtLnJnekp0ELgSU.Ya5yBNXGRhSsmL2bf5v(oZWYtLnJnekp0ELgSU.Kj9YASOMso);
					num2 = 69;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 26;
						continue;
					}
					continue;
					IL_1943:
					intPtr = oZWYtLnJnekp0ELgSU.umAsRJQFLIQlkZeSB5J(oZWYtLnJnekp0ELgSU.M03gMJQ84vK9fEtj2td(oZWYtLnJnekp0ELgSU.ki5Y5BFlNm)[0]);
					num2 = 276;
					continue;
					IL_19EF:
					num13 = 0U;
					num2 = 286;
					continue;
					IL_1AB7:
					array12 = oZWYtLnJnekp0ELgSU.oTgX9FXJFsmwfn6SRRA(oZWYtLnJnekp0ELgSU.TAgMrYXt1M.ToInt64());
					num2 = 63;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
					{
						num2 = 101;
						continue;
					}
					continue;
					IL_1C4A:
					byte[] array21 = new byte[30];
					oZWYtLnJnekp0ELgSU.rRyfZGXQc95B3Tc1KAi(array21, fieldof(<PrivateImplementationDetails>{E90D0D7C-D1D4-4CF5-9E25-441B34CF0F34}.D5B7247C497788CF0031CEB06E3DF77A45FEF59F1E49633DC7159816D64759B5).FieldHandle);
					array15 = array21;
					num2 = 118;
					continue;
					IL_1CD2:
					num12 = oZWYtLnJnekp0ELgSU.V8qgufX2Mlt62AcCWEG(intPtr8);
					num2 = 675;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 519;
						continue;
					}
					continue;
					IL_204C:
					oZWYtLnJnekp0ELgSU.wCENTOXYFMrMJZiMrUP(intPtr2);
					num2 = 173;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
					{
						num2 = 119;
						continue;
					}
					continue;
					IL_40D4:
					if (oZWYtLnJnekp0ELgSU.iNrxEmQzOOdwsZe1gy8(oZWYtLnJnekp0ELgSU.xp7d2OQLpbQAsqwkJTc(oWeebDMeI9rsA7EJwLV)) < oZWYtLnJnekp0ELgSU.p3F2aKQRVpe8Q3uAjL4(oZWYtLnJnekp0ELgSU.xp7d2OQLpbQAsqwkJTc(oWeebDMeI9rsA7EJwLV)) - 1L)
					{
						num2 = 192;
						continue;
					}
					goto IL_204C;
					IL_2194:
					oWeebDMeI9rsA7EJwLV = new oZWYtLnJnekp0ELgSU.oWeebDMeI9rsA7EJwLV(oZWYtLnJnekp0ELgSU.rZwrknQoSa9poIFfC4j(oZWYtLnJnekp0ELgSU.ki5Y5BFlNm, "9VyWlb4gXNZmDPF3j9.75Xob8mu4aP4UDPA7t"));
					num2 = 401;
					continue;
					IL_5055:
					if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() != 4)
					{
						goto IL_2194;
					}
					num2 = 413;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
					{
						num2 = 332;
						continue;
					}
					continue;
					IL_21B4:
					if (num65 < num8)
					{
						goto IL_3C42;
					}
					num2 = 544;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 1;
						continue;
					}
					continue;
					IL_2630:
					if (num20 >= num11)
					{
						num2 = 521;
						continue;
					}
					goto IL_3D04;
					IL_265C:
					oZWYtLnJnekp0ELgSU.LJp8rIX3dItYDlDsbtq(new IntPtr(intPtr4.ToInt64() + (long)(num53 * 4)), oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV));
					num2 = 377;
					continue;
					IL_4271:
					if (num53 >= num16)
					{
						goto Block_180;
					}
					goto IL_265C;
					IL_28C7:
					oZWYtLnJnekp0ELgSU.LJp8rIX3dItYDlDsbtq(intPtr9, oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV));
					num2 = 380;
					continue;
					IL_28F7:
					array8 = new byte[6];
					num2 = 95;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
					{
						num2 = 50;
						continue;
					}
					continue;
					IL_29E0:
					num2 = 118;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
					{
						num2 = 600;
						continue;
					}
					continue;
					IL_6581:
					if (oZWYtLnJnekp0ELgSU.CVjD7eXvPLuVqZrUQfs(oZWYtLnJnekp0ELgSU.USrQDbXOHrTD8bGIt9i(oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU).TypeHandle).Assembly)).Length != 2)
					{
						goto IL_29E0;
					}
					num2 = 270;
					if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 322;
						continue;
					}
					continue;
					IL_2F3D:
					if (oZWYtLnJnekp0ELgSU.RgObpeQj09HD0waBBSy(oZWYtLnJnekp0ELgSU.HfOnSyQna8wgnIWGO3Q(oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU).TypeHandle).Assembly)) <= 0)
					{
						goto IL_29E0;
					}
					num2 = 670;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 623;
						continue;
					}
					continue;
					IL_2D46:
					if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() == 4)
					{
						num2 = 579;
						continue;
					}
					goto IL_57A8;
					IL_2EF8:
					oZWYtLnJnekp0ELgSU.eWOYblZENf(intPtr2, intPtr5, oZWYtLnJnekp0ELgSU.gRef9VQAeQd4D7wQjsc(oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV)), 4U, out zero);
					num2 = 516;
					continue;
					IL_40AB:
					if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() == 4)
					{
						goto Block_173;
					}
					goto IL_2EF8;
					IL_30E0:
					num22 |= (uint)array6[array6.Length - (1 + num66)];
					num2 = 633;
					continue;
					IL_67FB:
					if (num66 > 0)
					{
						num2 = 471;
						continue;
					}
					goto IL_30E0;
					IL_628F:
					if (num66 < num14)
					{
						goto IL_67FB;
					}
					num2 = 288;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 265;
						continue;
					}
					continue;
					IL_30FB:
					num65 = 0;
					num2 = 113;
					continue;
					IL_331E:
					if (num24 < num7)
					{
						goto IL_417F;
					}
					num2 = 90;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
					{
						num2 = 409;
						continue;
					}
					continue;
					IL_37B8:
					array[5] = (byte)num3;
					num2 = 418;
					continue;
					IL_381E:
					num36 = 7680;
					num2 = 283;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
					{
						num2 = 234;
						continue;
					}
					continue;
					IL_3CA9:
					if (oZWYtLnJnekp0ELgSU.RgObpeQj09HD0waBBSy(oZWYtLnJnekp0ELgSU.HfOnSyQna8wgnIWGO3Q(oZWYtLnJnekp0ELgSU.ki5Y5BFlNm)) == 0)
					{
						goto IL_381E;
					}
					num2 = 632;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 328;
						continue;
					}
					continue;
					IL_395E:
					IntPtr zero2 = IntPtr.Zero;
					num2 = 689;
					continue;
					IL_3BDE:
					text2 = oZWYtLnJnekp0ELgSU.buT7IbXqGXGFDTT2oMO(oZWYtLnJnekp0ELgSU.zppr0JXrRnwOBtYWdkN(), array2);
					num2 = 174;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
					{
						num2 = 130;
						continue;
					}
					continue;
					IL_3C42:
					*(long*)(ptr2 + num65 * 8) ^= 1935026652L;
					num2 = 574;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() != null)
					{
						num2 = 469;
						continue;
					}
					continue;
					IL_3C97:
					if (num54 == 1)
					{
						num2 = 31;
						continue;
					}
					num63 = 0;
					num2 = 159;
					continue;
					IL_3D04:
					intPtr5 = new IntPtr(oZWYtLnJnekp0ELgSU.QBpYcRPHGA + (long)oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV) - (long)num36);
					num2 = 569;
					continue;
					IL_3E8D:
					if (oZWYtLnJnekp0ELgSU.iNrxEmQzOOdwsZe1gy8(oZWYtLnJnekp0ELgSU.xp7d2OQLpbQAsqwkJTc(oWeebDMeI9rsA7EJwLV)) < oZWYtLnJnekp0ELgSU.p3F2aKQRVpe8Q3uAjL4(oZWYtLnJnekp0ELgSU.xp7d2OQLpbQAsqwkJTc(oWeebDMeI9rsA7EJwLV)) - 1L)
					{
						num2 = 489;
						continue;
					}
					goto IL_5D49;
					IL_417F:
					num64 = num24 % num25;
					num2 = 349;
					continue;
					IL_41F3:
					num26 = oZWYtLnJnekp0ELgSU.V8qgufX2Mlt62AcCWEG(new IntPtr(num12));
					num2 = 37;
					if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 212;
						continue;
					}
					continue;
					IL_4507:
					num2 = 321;
					continue;
					IL_484B:
					num26 = 0L;
					num2 = 424;
					continue;
					IL_48D3:
					if (num37 >= array10.Length)
					{
						num2 = 558;
						continue;
					}
					goto IL_44E8;
					IL_49A2:
					array2 = new byte[10];
					num2 = 65;
					continue;
					IL_4BBD:
					array[20] = (byte)num3;
					num2 = 651;
					continue;
					IL_4D71:
					intPtr3 = oZWYtLnJnekp0ELgSU.AckCWQXXvRLi2pjfjX3(IntPtr.Zero, (uint)array15.Length, 4096U, 64U);
					num2 = 179;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 35;
						continue;
					}
					continue;
					IL_4DA2:
					array16[num33 + num15] = (byte)((num32 & num21) >> num27);
					num2 = 52;
					continue;
					IL_4DE5:
					oZWYtLnJnekp0ELgSU.Kj9YASOMso = null;
					num2 = 238;
					continue;
					IL_4E57:
					num37 = 0;
					num2 = 305;
					continue;
					IL_4F60:
					intPtr9 = new IntPtr(num42 + (long)oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV) - (long)num36);
					num2 = 42;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
					{
						num2 = 532;
						continue;
					}
					continue;
					IL_53EE:
					array[7] = 66 + 75;
					num2 = 90;
					continue;
					IL_54B2:
					process = oZWYtLnJnekp0ELgSU.eAIITKQfcsMe7IrWquf();
					num2 = 433;
					continue;
					IL_57A8:
					array2 = new byte[12];
					num2 = 414;
					continue;
					IL_5B54:
					ptr2 = null;
					num2 = 3;
					if (oZWYtLnJnekp0ELgSU.DxgfoaQMwal4F0shy8d() == null)
					{
						num2 = 14;
						continue;
					}
					continue;
					IL_5F80:
					if (array14.Length == 0)
					{
						goto IL_5B54;
					}
					num2 = 255;
					if (!oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 245;
						continue;
					}
					continue;
					IL_6045:
					oZWYtLnJnekp0ELgSU.ilo7hpQk0gNF4ZLXB6H(intPtr8, 0);
					num2 = 165;
					continue;
					IL_612D:
					num53 = 0;
					num2 = 621;
					continue;
					IL_6196:
					num5 = 2;
					num2 = 105;
					if (oZWYtLnJnekp0ELgSU.y0DfKAQYhhxKCC5dy7T())
					{
						num2 = 202;
						continue;
					}
					continue;
					IL_637F:
					if (oZWYtLnJnekp0ELgSU.OYQ3fkQvdJ91utOnpJJ() == 4)
					{
						num2 = 347;
						continue;
					}
					goto IL_6196;
					IL_627C:
					num62 = oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
					num2 = 454;
					continue;
					IL_63C0:
					oZWYtLnJnekp0ELgSU.zL2X9YQlUSiDnxJtqP3(array4, 0, intPtr3, array4.Length);
					num2 = 83;
					continue;
					IL_6601:
					enumerator = oZWYtLnJnekp0ELgSU.fipoe2QNqIyphcFRYUc(oZWYtLnJnekp0ELgSU.smvxgRQItn5ZfWHZjYQ(oZWYtLnJnekp0ELgSU.eAIITKQfcsMe7IrWquf()));
					num2 = 671;
					continue;
					IL_66B6:
					oZWYtLnJnekp0ELgSU.JnsYd79dMK(intPtr9, 4, 8, ref num17);
					num2 = 659;
				}
				IL_0C56:
				num3 = 228 - 76;
				num = 154;
				continue;
				IL_0CEE:
				array = new byte[32];
				num = 386;
				continue;
				IL_0E92:
				num36 = 0;
				num = 127;
				continue;
				IL_1439:
				array[24] = (byte)num3;
				num = 683;
				continue;
				IL_1894:
				array4[num5 + 4] = array11[4];
				num = 534;
				continue;
				Block_50:
				num = 426;
				continue;
				IL_1B82:
				num3 = 227 - 75;
				num = 650;
				continue;
				IL_1D69:
				oZWYtLnJnekp0ELgSU.Xumqd9QrQ3IZBxTuOOp(new IntPtr((void*)(&num18)), 0);
				num = 456;
				continue;
				IL_1E67:
				array[9] = 252 - 84;
				num = 490;
				continue;
				IL_21D7:
				num11 = oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
				num = 631;
				continue;
				IL_2256:
				array4[num5 + 1] = array11[1];
				num = 364;
				continue;
				IL_24DF:
				array4[num5 + 5] = array12[5];
				num = 603;
				continue;
				IL_25ED:
				array4[num5 + 2] = array11[2];
				num = 285;
				continue;
				IL_2787:
				intPtr7 = oZWYtLnJnekp0ELgSU.fT7YEH5Cwe(text2);
				num = 74;
				continue;
				IL_281A:
				oZWYtLnJnekp0ELgSU.QurMInQ4surwrnifqI5(new IntPtr((void*)(&num18)), 0, 0);
				num = 656;
				continue;
				IL_2A69:
				array[29] = (byte)num3;
				num = 245;
				continue;
				IL_324A:
				array3[5] = (byte)num4;
				num = 565;
				continue;
				IL_37EF:
				num3 = 80 + 8;
				num = 562;
				continue;
				IL_3C1F:
				array[29] = 29 - 18;
				num = 135;
				continue;
				IL_3CD7:
				num3 = 27 + 89;
				num = 92;
				continue;
				IL_3DF1:
				num16 = oZWYtLnJnekp0ELgSU.tcJLxsQakgwvBRn2QFK(oWeebDMeI9rsA7EJwLV);
				num = 66;
				continue;
				IL_3EF6:
				num3 = 161 - 53;
				num = 601;
				continue;
				Block_173:
				num = 116;
				continue;
				Block_180:
				num = 280;
				continue;
				IL_4380:
				array3[1] = 77 + 97;
				num = 182;
				continue;
				IL_44E8:
				array9[num37] ^= array10[num37];
				num = 319;
				continue;
				IL_453F:
				array[5] = 150 - 50;
				num = 335;
				continue;
				IL_49B5:
				intPtr = oZWYtLnJnekp0ELgSU.umAsRJQFLIQlkZeSB5J(oZWYtLnJnekp0ELgSU.M03gMJQ84vK9fEtj2td(oZWYtLnJnekp0ELgSU.ki5Y5BFlNm)[0]);
				num = 684;
				continue;
				IL_4A43:
				array2[0] = 99;
				num = 130;
				continue;
				IL_4BE2:
				num3 = 183 - 61;
				num = 163;
				continue;
				IL_4CC9:
				array[19] = (byte)num3;
				num = 60;
				continue;
				IL_4D3E:
				intPtr7 = IntPtr.Zero;
				num = 111;
				continue;
				IL_5470:
				array[16] = 146 + 12;
				num = 235;
				continue;
				IL_5519:
				num9 = num9;
				num = 354;
				continue;
				IL_58BD:
				goto IL_5519;
				IL_5681:
				array[9] = 116 + 27;
				num = 239;
				continue;
				IL_578C:
				array3[2] = (byte)num4;
				num = 302;
				continue;
				IL_5949:
				num3 = 186 + 14;
				num = 314;
				continue;
				IL_59F1:
				array[17] = (byte)num3;
				num = 672;
				continue;
				IL_5BED:
				array[15] = (byte)num3;
				num = 323;
				continue;
				IL_5C9C:
				array4[num5 + 5] = array5[5];
				num = 547;
				continue;
				IL_5D49:
				intPtr = oZWYtLnJnekp0ELgSU.umAsRJQFLIQlkZeSB5J(oZWYtLnJnekp0ELgSU.M03gMJQ84vK9fEtj2td(oZWYtLnJnekp0ELgSU.YN6xQiXk1jyvKGI9lSH(typeof(oZWYtLnJnekp0ELgSU).TypeHandle).Assembly)[0]);
				num = 688;
				continue;
				IL_5E14:
				ylecR5MJ2SYSVCIgjmG2 = default(oZWYtLnJnekp0ELgSU.YlecR5MJ2SYSVCIgjmG);
				num = 461;
				continue;
				IL_6323:
				array4[num5 + 5] = array11[5];
				num = 62;
				continue;
				Block_284:
				num = 228;
				continue;
				IL_64FD:
				array3[11] = 31 + 8;
				num = 155;
				continue;
				IL_6570:
				num73 = 0;
				num = 360;
				continue;
				IL_65BC:
				array[24] = (byte)num3;
				num = 655;
				continue;
				IL_661C:
				array[4] = (byte)num3;
				num = 133;
				continue;
				IL_690B:
				array4[num6] = array11[0];
				num = 242;
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000AEC4 File Offset: 0x000090C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object lGEYOw9t2H(object \u0020)
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

		// Token: 0x060000D8 RID: 216
		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr fT7YEH5Cwe(string \u0020);

		// Token: 0x060000D9 RID: 217
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		public static extern IntPtr BuhYHmeams(IntPtr \u0020, string \u0020);

		// Token: 0x060000DA RID: 218 RVA: 0x0000AFF4 File Offset: 0x000091F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr BasYsRkBnO(IntPtr \u0020, object \u0020, uint \u0020)
		{
			if (oZWYtLnJnekp0ELgSU.AmKMmtBZMn == null)
			{
				oZWYtLnJnekp0ELgSU.AmKMmtBZMn = (oZWYtLnJnekp0ELgSU.QarH42MgRuD8vkfA7n7)Marshal.GetDelegateForFunctionPointer(oZWYtLnJnekp0ELgSU.BuhYHmeams(oZWYtLnJnekp0ELgSU.xTuFFuFOZ(), "Find ".Trim() + "ResourceA"), typeof(oZWYtLnJnekp0ELgSU.QarH42MgRuD8vkfA7n7));
			}
			return oZWYtLnJnekp0ELgSU.AmKMmtBZMn(\u0020, \u0020, \u0020);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000B050 File Offset: 0x00009250
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr vBWYvbByFf(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			if (oZWYtLnJnekp0ELgSU.GnVM6tNrkP == null)
			{
				oZWYtLnJnekp0ELgSU.GnVM6tNrkP = (oZWYtLnJnekp0ELgSU.XktqdYMwYPEh2q8bmGl)Marshal.GetDelegateForFunctionPointer(oZWYtLnJnekp0ELgSU.BuhYHmeams(oZWYtLnJnekp0ELgSU.xTuFFuFOZ(), "Virtual ".Trim() + "Alloc"), typeof(oZWYtLnJnekp0ELgSU.XktqdYMwYPEh2q8bmGl));
			}
			return oZWYtLnJnekp0ELgSU.GnVM6tNrkP(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000B0AC File Offset: 0x000092AC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int eWOYblZENf(IntPtr \u0020, IntPtr \u0020, [In] [Out] byte[] \u0020, uint \u0020, out IntPtr \u0020)
		{
			if (oZWYtLnJnekp0ELgSU.MgKMlYFDMg == null)
			{
				oZWYtLnJnekp0ELgSU.MgKMlYFDMg = (oZWYtLnJnekp0ELgSU.YIUvVIMUPk8Y6X7LrpX)Marshal.GetDelegateForFunctionPointer(oZWYtLnJnekp0ELgSU.BuhYHmeams(oZWYtLnJnekp0ELgSU.xTuFFuFOZ(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(oZWYtLnJnekp0ELgSU.YIUvVIMUPk8Y6X7LrpX));
			}
			return oZWYtLnJnekp0ELgSU.MgKMlYFDMg(\u0020, \u0020, \u0020, \u0020, out \u0020);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000B114 File Offset: 0x00009314
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int JnsYd79dMK(IntPtr \u0020, int \u0020, int \u0020, ref int \u0020)
		{
			if (oZWYtLnJnekp0ELgSU.jubM2F7r0j == null)
			{
				oZWYtLnJnekp0ELgSU.jubM2F7r0j = (oZWYtLnJnekp0ELgSU.le6lwNM0EMEVreNAZmC)Marshal.GetDelegateForFunctionPointer(oZWYtLnJnekp0ELgSU.BuhYHmeams(oZWYtLnJnekp0ELgSU.xTuFFuFOZ(), "Virtual ".Trim() + "Protect"), typeof(oZWYtLnJnekp0ELgSU.le6lwNM0EMEVreNAZmC));
			}
			return oZWYtLnJnekp0ELgSU.jubM2F7r0j(\u0020, \u0020, \u0020, ref \u0020);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000B170 File Offset: 0x00009370
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr MMtYIag8H3(uint \u0020, int \u0020, uint \u0020)
		{
			if (oZWYtLnJnekp0ELgSU.JNOMfpGtow == null)
			{
				oZWYtLnJnekp0ELgSU.JNOMfpGtow = (oZWYtLnJnekp0ELgSU.YRg3LkMopxqehLM7Vxp)Marshal.GetDelegateForFunctionPointer(oZWYtLnJnekp0ELgSU.BuhYHmeams(oZWYtLnJnekp0ELgSU.xTuFFuFOZ(), "Open ".Trim() + "Process"), typeof(oZWYtLnJnekp0ELgSU.YRg3LkMopxqehLM7Vxp));
			}
			return oZWYtLnJnekp0ELgSU.JNOMfpGtow(\u0020, \u0020, \u0020);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000B1CC File Offset: 0x000093CC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int uuKYNUGOJp(IntPtr \u0020)
		{
			if (oZWYtLnJnekp0ELgSU.a3FMh8hvwK == null)
			{
				oZWYtLnJnekp0ELgSU.a3FMh8hvwK = (oZWYtLnJnekp0ELgSU.JNx1DNMLWJI7vceZpV3)Marshal.GetDelegateForFunctionPointer(oZWYtLnJnekp0ELgSU.BuhYHmeams(oZWYtLnJnekp0ELgSU.xTuFFuFOZ(), "Close ".Trim() + "Handle"), typeof(oZWYtLnJnekp0ELgSU.JNx1DNMLWJI7vceZpV3));
			}
			return oZWYtLnJnekp0ELgSU.a3FMh8hvwK(\u0020);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000B228 File Offset: 0x00009428
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr xTuFFuFOZ()
		{
			if (oZWYtLnJnekp0ELgSU.Y2dMOpvjeZ == IntPtr.Zero)
			{
				oZWYtLnJnekp0ELgSU.Y2dMOpvjeZ = oZWYtLnJnekp0ELgSU.fT7YEH5Cwe("kernel ".Trim() + "32.dll");
			}
			return oZWYtLnJnekp0ELgSU.Y2dMOpvjeZ;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000B264 File Offset: 0x00009464
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] A5wYJJbwUe(object \u0020)
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

		// Token: 0x060000E2 RID: 226 RVA: 0x0000B2D0 File Offset: 0x000094D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Stream GnrYGjOdxJ()
		{
			return new MemoryStream();
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000B2D8 File Offset: 0x000094D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] c9EYBpOg8Q(object \u0020)
		{
			return ((MemoryStream)\u0020).ToArray();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000B2E8 File Offset: 0x000094E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] vVZYewEeW9(object \u0020)
		{
			Stream stream = oZWYtLnJnekp0ELgSU.GnrYGjOdxJ();
			SymmetricAlgorithm symmetricAlgorithm = oZWYtLnJnekp0ELgSU.FVLK318Py();
			symmetricAlgorithm.Key = new byte[]
			{
				155, 128, 127, 41, 212, 94, 178, 37, 237, 246,
				182, 33, 48, 38, 168, 163, 63, 76, 14, 100,
				49, 122, 190, 238, 142, 234, 119, 140, 53, 246,
				139, 143
			};
			symmetricAlgorithm.IV = new byte[]
			{
				6, 35, 217, 138, 213, 238, 107, 203, 76, 252,
				56, 188, 71, 78, 224, 106
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(\u0020, 0, \u0020.Length);
			cryptoStream.Close();
			byte[] array = oZWYtLnJnekp0ELgSU.c9EYBpOg8Q(stream);
			pKt2MEMR018TcR688bs.SivezbFhwV();
			return array;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000B35C File Offset: 0x0000955C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] dLDYQBhdvV()
		{
			return null;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000B36C File Offset: 0x0000956C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] fT6YXbPWup()
		{
			return null;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000B37C File Offset: 0x0000957C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] ArPY9CROQa()
		{
			int length = "{11111-22222-20001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000B39C File Offset: 0x0000959C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] R2QYSpO4LJ()
		{
			int length = "{11111-22222-20001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000B3BC File Offset: 0x000095BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] ty6YuYhwmx()
		{
			return null;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000B3CC File Offset: 0x000095CC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] PXgYgg0foO()
		{
			return null;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000B3DC File Offset: 0x000095DC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] TINYwOPAxf()
		{
			int length = "{11111-22222-40001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000B3FC File Offset: 0x000095FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] uy2YU9Gc4h()
		{
			int length = "{11111-22222-40001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000B41C File Offset: 0x0000961C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] w33Y0lffsh()
		{
			return null;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000B42C File Offset: 0x0000962C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] hFLYo0r5LT()
		{
			return null;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000B43C File Offset: 0x0000963C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AbKICkljYL7DXJT31S9(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000B448 File Offset: 0x00009648
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ii9lZWlaAulRHRQRAui(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000B458 File Offset: 0x00009658
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long TSknVDlPGC1mGtZQvrE(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000B464 File Offset: 0x00009664
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object h97Sidl17KchwJ492Sk(object A_0, int \u0020)
		{
			return A_0.SBtMQ6ucUs(\u0020);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000B474 File Offset: 0x00009674
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void adPh0qlVXS5twj85APi(object A_0)
		{
			A_0.Tw3MSokxej();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000B480 File Offset: 0x00009680
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void mTNrgclpEIPhTp5G4n2(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000B48C File Offset: 0x0000968C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object NSiaXxl7UHEf3NluXeC(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000B498 File Offset: 0x00009698
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object VTF7dPlDvM1SCIFRywY(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000B4A4 File Offset: 0x000096A4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object T0SmPmlCORUlhZG5TRm()
		{
			return oZWYtLnJnekp0ELgSU.FVLK318Py();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000B4AC File Offset: 0x000096AC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void gAqgnWlKFej82aAtxnv(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000B4BC File Offset: 0x000096BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object cxTGfIlZZfCLiPp4QiR(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000B4D0 File Offset: 0x000096D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object vlcj6glcK4Gus2JDLAf()
		{
			return oZWYtLnJnekp0ELgSU.GnrYGjOdxJ();
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000B4D8 File Offset: 0x000096D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void x8QbA1lAsV6KaKy5QQg(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000B4F0 File Offset: 0x000096F0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void fkhQeAlzQYWdcmhsdUu(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000B4FC File Offset: 0x000096FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object pYEJEk23AnOpNfnEU7V(object A_0)
		{
			return oZWYtLnJnekp0ELgSU.c9EYBpOg8Q(A_0);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000B508 File Offset: 0x00009708
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void vlHqKA2YhnD8HdsxCNC(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000B514 File Offset: 0x00009714
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object mB44gN2MY3lNcu2WIuZ(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000B520 File Offset: 0x00009720
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool GX9qEM2ksxso2PPsejJ(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000B530 File Offset: 0x00009730
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool AckLYXlF8IuF0x3SCjB()
		{
			return null == null;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000B538 File Offset: 0x00009738
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object SdDZQGlnCeiyRu5Ksag()
		{
			return null;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000B53C File Offset: 0x0000973C
		static int mGMtN1Q3R68hIHoHiEe()
		{
			return 1;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000B540 File Offset: 0x00009740
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr ilo7hpQk0gNF4ZLXB6H(IntPtr A_0, int A_1)
		{
			return Marshal.ReadIntPtr(A_0, A_1);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000B550 File Offset: 0x00009750
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int aqaylRQTrd9kf58j4r6(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt32(A_0, A_1);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000B560 File Offset: 0x00009760
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long Xumqd9QrQ3IZBxTuOOp(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt64(A_0, A_1);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000B570 File Offset: 0x00009770
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void XlTYoWQqRKNRO0iopcF(IntPtr A_0, int A_1, IntPtr A_2)
		{
			Marshal.WriteIntPtr(A_0, A_1, A_2);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000B584 File Offset: 0x00009784
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void QurMInQ4surwrnifqI5(IntPtr A_0, int A_1, int A_2)
		{
			Marshal.WriteInt32(A_0, A_1, A_2);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000B598 File Offset: 0x00009798
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void MWK9VjQm7ZCw5QmRIiY(IntPtr A_0, int A_1, long A_2)
		{
			Marshal.WriteInt64(A_0, A_1, A_2);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000B5AC File Offset: 0x000097AC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr anwaBnQ6xSNZEQPccdF(int A_0)
		{
			return Marshal.AllocCoTaskMem(A_0);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000B5B8 File Offset: 0x000097B8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void zL2X9YQlUSiDnxJtqP3(object A_0, int A_1, IntPtr A_2, int A_3)
		{
			Marshal.Copy(A_0, A_1, A_2, A_3);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000B5D0 File Offset: 0x000097D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void rP28VlQ2LqGWuC8Gbn7()
		{
			oZWYtLnJnekp0ELgSU.BitY2E0xKT();
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000B5D8 File Offset: 0x000097D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object eAIITKQfcsMe7IrWquf()
		{
			return Process.GetCurrentProcess();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000B5E0 File Offset: 0x000097E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object zN2iPGQhv83Ex4VEWU2(object A_0)
		{
			return A_0.MainModule;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000B5EC File Offset: 0x000097EC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr R8N09wQOaa5hM3yM0Ov(object A_0)
		{
			return A_0.BaseAddress;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000B5F8 File Offset: 0x000097F8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr pGjmj2QE08YunNtF4ax(IntPtr \u0020, object A_1, uint \u0020)
		{
			return oZWYtLnJnekp0ELgSU.BasYsRkBnO(\u0020, A_1, \u0020);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000B60C File Offset: 0x0000980C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool E3UTKpQHJJi4Xj4Ti5U(IntPtr A_0, IntPtr A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000B61C File Offset: 0x0000981C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ne4hKdQswTIUPaHP1bS()
		{
			pKt2MEMR018TcR688bs.SivezbFhwV();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000B624 File Offset: 0x00009824
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int OYQ3fkQvdJ91utOnpJJ()
		{
			return IntPtr.Size;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000B62C File Offset: 0x0000982C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type SGJe3QQbWgwGyrJsaXp(object A_0, bool A_1)
		{
			return Type.GetType(A_0, A_1);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000B63C File Offset: 0x0000983C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool kmkOApQdwc4vlBZTstf(Type A_0, Type A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000B64C File Offset: 0x0000984C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object smvxgRQItn5ZfWHZjYQ(object A_0)
		{
			return A_0.Modules;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000B658 File Offset: 0x00009858
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object fipoe2QNqIyphcFRYUc(object A_0)
		{
			return A_0.GetEnumerator();
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000B664 File Offset: 0x00009864
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object wyTelKQJW2CUetvkIWe(object A_0)
		{
			return ((IEnumerator)A_0).Current;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000B670 File Offset: 0x00009870
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object NnCryBQGV8TIhGGqsZl(object A_0)
		{
			return A_0.ModuleName;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000B67C File Offset: 0x0000987C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object bWeV1hQBrwNHoEePHPo(object A_0)
		{
			return A_0.ToLower();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000B688 File Offset: 0x00009888
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool FYxv7UQeKhJw0o8qVkb(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000B698 File Offset: 0x00009898
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object W4Zfa7QQrq1IOWe9sGC(object A_0)
		{
			return A_0.FileVersionInfo;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000B6A4 File Offset: 0x000098A4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int AjD1vpQXCI8XGNQV85u(object A_0)
		{
			return A_0.ProductMajorPart;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000B6B0 File Offset: 0x000098B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int zttBxHQ9AifJvCV0BEh(object A_0)
		{
			return A_0.ProductMinorPart;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000B6BC File Offset: 0x000098BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int wWbhWEQSVKZ8LEGGDbb(object A_0)
		{
			return A_0.ProductBuildPart;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000B6C8 File Offset: 0x000098C8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int lFYf5WQu8mikFAaT5fJ(object A_0)
		{
			return A_0.ProductPrivatePart;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000B6D4 File Offset: 0x000098D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool dncso1QgO1OInyecB4B(object A_0, object A_1)
		{
			return A_0 >= A_1;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000B6E4 File Offset: 0x000098E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool GitQGYQwar8caGEHe3H(object A_0, object A_1)
		{
			return A_0 < A_1;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000B6F4 File Offset: 0x000098F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool BptMIOQUoVcvlur76Rd(object A_0)
		{
			return ((IEnumerator)A_0).MoveNext();
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000B700 File Offset: 0x00009900
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void tvbFWDQ0x5RHshJZQpc(object A_0)
		{
			((IDisposable)A_0).Dispose();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000B70C File Offset: 0x0000990C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object rZwrknQoSa9poIFfC4j(object A_0, object A_1)
		{
			return A_0.GetManifestResourceStream(A_1);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000B71C File Offset: 0x0000991C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object xp7d2OQLpbQAsqwkJTc(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000B728 File Offset: 0x00009928
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void PR7JhDQ5j7vT2yiEsGw(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000B738 File Offset: 0x00009938
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long p3F2aKQRVpe8Q3uAjL4(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000B744 File Offset: 0x00009944
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object IiVWu8QxvFjIoIlC4nW(object A_0, int \u0020)
		{
			return A_0.SBtMQ6ucUs(\u0020);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000B754 File Offset: 0x00009954
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void IH8wUHQyU5ZZTPkQ45A(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000B760 File Offset: 0x00009960
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object vIRJZFQiow2rqJbm1nd(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000B76C File Offset: 0x0000996C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object mCa58RQWvQ5aVo8YpoY(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000B778 File Offset: 0x00009978
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void L69GjhQthsqeKgw4iYs(object A_0, int A_1, int A_2)
		{
			Array.Clear(A_0, A_1, A_2);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000B78C File Offset: 0x0000998C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object M03gMJQ84vK9fEtj2td(object A_0)
		{
			return A_0.GetModules();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000B798 File Offset: 0x00009998
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr umAsRJQFLIQlkZeSB5J(object A_0)
		{
			return Marshal.GetHINSTANCE(A_0);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000B7A4 File Offset: 0x000099A4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object HfOnSyQna8wgnIWGO3Q(object A_0)
		{
			return A_0.Location;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000B7B0 File Offset: 0x000099B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int RgObpeQj09HD0waBBSy(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000B7BC File Offset: 0x000099BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int tcJLxsQakgwvBRn2QFK(object A_0)
		{
			return A_0.QfbM9kBllF();
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000B7C8 File Offset: 0x000099C8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object qj3SLhQPWSNSG8JLIec()
		{
			return oZWYtLnJnekp0ELgSU.FVLK318Py();
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000B7D0 File Offset: 0x000099D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void oaISi7Q1dtW2LVR0h9R(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000B7E0 File Offset: 0x000099E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object vQWfnSQV7Ovsg54Ya6j(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000B7F4 File Offset: 0x000099F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void DicMpcQpwdnZEt8MyfJ(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000B80C File Offset: 0x00009A0C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void H7DOYwQ78lPBNY8kF6J(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000B818 File Offset: 0x00009A18
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Od45OoQDwY08cUtXpSq(object A_0)
		{
			return A_0.ToArray();
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000B824 File Offset: 0x00009A24
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Te126rQCDhb9w4wT09q(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000B830 File Offset: 0x00009A30
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void k9HiNLQKfITmH4ZQtif(object A_0)
		{
			A_0.Tw3MSokxej();
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000B83C File Offset: 0x00009A3C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int C5FeAWQZVGTK2BTtGBD(object A_0)
		{
			return A_0.Id;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000B848 File Offset: 0x00009A48
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr bpwIlGQchPfwu1pxpwN(uint \u0020, int \u0020, uint \u0020)
		{
			return oZWYtLnJnekp0ELgSU.MMtYIag8H3(\u0020, \u0020, \u0020);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000B85C File Offset: 0x00009A5C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object gRef9VQAeQd4D7wQjsc(int A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000B868 File Offset: 0x00009A68
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long iNrxEmQzOOdwsZe1gy8(object A_0)
		{
			return A_0.Position;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000B874 File Offset: 0x00009A74
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void LJp8rIX3dItYDlDsbtq(IntPtr A_0, int A_1)
		{
			Marshal.WriteInt32(A_0, A_1);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000B884 File Offset: 0x00009A84
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int wCENTOXYFMrMJZiMrUP(IntPtr \u0020)
		{
			return oZWYtLnJnekp0ELgSU.uuKYNUGOJp(\u0020);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000B890 File Offset: 0x00009A90
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void sL4sZQXM3Z0pAfHxyvG(object A_0, object A_1, object A_2)
		{
			A_0.Add(A_1, A_2);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000B8A4 File Offset: 0x00009AA4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type YN6xQiXk1jyvKGI9lSH(RuntimeTypeHandle A_0)
		{
			return Type.GetTypeFromHandle(A_0);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000B8B0 File Offset: 0x00009AB0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int z53HdeXTO3eHgOyHUaZ(long A_0)
		{
			return Convert.ToInt32(A_0);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000B8BC File Offset: 0x00009ABC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object zppr0JXrRnwOBtYWdkN()
		{
			return Encoding.UTF8;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000B8C4 File Offset: 0x00009AC4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object buT7IbXqGXGFDTT2oMO(object A_0, object A_1)
		{
			return A_0.GetString(A_1);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000B8D4 File Offset: 0x00009AD4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool VTKbLyX4u3NyclY6GPK(IntPtr A_0, IntPtr A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000B8E4 File Offset: 0x00009AE4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object W6I7wsXm2pucHbXEQqk(IntPtr \u0020, Type \u0020)
		{
			return oZWYtLnJnekp0ELgSU.XY7Yf19lCP(\u0020, \u0020);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000B8F4 File Offset: 0x00009AF4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr XLGAvvX6x2a2AsfLKyl(object A_0)
		{
			return A_0();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000B900 File Offset: 0x00009B00
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int SVOrhpXlkncaUKPOcfb(IntPtr A_0)
		{
			return Marshal.ReadInt32(A_0);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000B90C File Offset: 0x00009B0C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long V8qgufX2Mlt62AcCWEG(IntPtr A_0)
		{
			return Marshal.ReadInt64(A_0);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000B918 File Offset: 0x00009B18
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr Tk3Y1MXf8CVQeFgxrst(object A_0)
		{
			return Marshal.GetFunctionPointerForDelegate(A_0);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000B924 File Offset: 0x00009B24
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int O4k0rTXhih2wNyZutCy(object A_0)
		{
			return A_0.ModuleMemorySize;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000B930 File Offset: 0x00009B30
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object USrQDbXOHrTD8bGIt9i(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000B93C File Offset: 0x00009B3C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool S94vhMXEg5E3gERjXy6(object A_0, object A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000B94C File Offset: 0x00009B4C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object MA67YLXHFXV8OSJpWRM(object A_0)
		{
			return A_0.Method;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000B958 File Offset: 0x00009B58
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object XKTvU3Xse1Gr8pMnV5J(Type A_0, object A_1)
		{
			return Delegate.CreateDelegate(A_0, A_1);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000B968 File Offset: 0x00009B68
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object CVjD7eXvPLuVqZrUQfs(object A_0)
		{
			return A_0.GetParameters();
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000B974 File Offset: 0x00009B74
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object ShE46sXbmaRQgWQMwLb(object A_0)
		{
			return A_0.ManifestModule;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000B980 File Offset: 0x00009B80
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ModuleHandle RcMBnJXdRsDiKQ22qF9(object A_0)
		{
			return A_0.ModuleHandle;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000B98C File Offset: 0x00009B8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type SaLkHYXIUBMrjj3htJO(object A_0)
		{
			return A_0.GetType();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000B998 File Offset: 0x00009B98
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object aVgCi2XNiaMgaU3uUnA(object A_0, object A_1)
		{
			return A_0.GetValue(A_1);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000B9A8 File Offset: 0x00009BA8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object oTgX9FXJFsmwfn6SRRA(long A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000B9B4 File Offset: 0x00009BB4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Ya5yBNXGRhSsmL2bf5v(object A_0)
		{
			RuntimeHelpers.PrepareDelegate(A_0);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000B9C0 File Offset: 0x00009BC0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static RuntimeMethodHandle PlmylpXBVnLlJDSN2Za(object A_0)
		{
			return A_0.MethodHandle;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000B9CC File Offset: 0x00009BCC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void R937gUXexb85NuDudZY(RuntimeMethodHandle A_0)
		{
			RuntimeHelpers.PrepareMethod(A_0);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000B9D8 File Offset: 0x00009BD8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void rRyfZGXQc95B3Tc1KAi(object A_0, RuntimeFieldHandle A_1)
		{
			RuntimeHelpers.InitializeArray(A_0, A_1);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000B9E8 File Offset: 0x00009BE8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr AckCWQXXvRLi2pjfjX3(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			return oZWYtLnJnekp0ELgSU.vBWYvbByFf(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000BA00 File Offset: 0x00009C00
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void bqIcOAX9ALsQMmdBt12(IntPtr A_0, IntPtr A_1)
		{
			Marshal.WriteIntPtr(A_0, A_1);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000BA10 File Offset: 0x00009C10
		internal static bool y0DfKAQYhhxKCC5dy7T()
		{
			return null == null;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000BA18 File Offset: 0x00009C18
		internal static object DxgfoaQMwal4F0shy8d()
		{
			return null;
		}

		// Token: 0x0400008F RID: 143
		private static bool AwMYLIYgO4 = false;

		// Token: 0x04000090 RID: 144
		private static List<string> BdWYng0lb9 = null;

		// Token: 0x04000091 RID: 145
		private static List<int> SnTYja92mn = null;

		// Token: 0x04000092 RID: 146
		private static bool QD5YClnG2O = false;

		// Token: 0x04000093 RID: 147
		private static long xfTM3KUtTX = 0L;

		// Token: 0x04000094 RID: 148
		private static bool c6fMkVN6HI = false;

		// Token: 0x04000095 RID: 149
		[oZWYtLnJnekp0ELgSU.Wv9HhHMHVkbsjseBi6G(typeof(oZWYtLnJnekp0ELgSU.Wv9HhHMHVkbsjseBi6G.HSJdIjMsBSGuYgddGBU<object>[]))]
		private static bool whiMqrb3YG = false;

		// Token: 0x04000096 RID: 150
		private static object AmKMmtBZMn = null;

		// Token: 0x04000097 RID: 151
		private static object MgKMlYFDMg = null;

		// Token: 0x04000098 RID: 152
		private static long QBpYcRPHGA = 0L;

		// Token: 0x04000099 RID: 153
		private static Dictionary<int, int> cKCYWo8dF4 = null;

		// Token: 0x0400009A RID: 154
		private static object EyNYP323Z4 = new byte[0];

		// Token: 0x0400009B RID: 155
		private static object a3FMh8hvwK = null;

		// Token: 0x0400009C RID: 156
		private static IntPtr TAgMrYXt1M = IntPtr.Zero;

		// Token: 0x0400009D RID: 157
		private static object HGGYtoHC67 = new object();

		// Token: 0x0400009E RID: 158
		private static int YCeMTWwe0B = 0;

		// Token: 0x0400009F RID: 159
		private static object jubM2F7r0j = null;

		// Token: 0x040000A0 RID: 160
		private static IntPtr oMCY1pTL3S = IntPtr.Zero;

		// Token: 0x040000A1 RID: 161
		private static IntPtr XvhYVx245T = IntPtr.Zero;

		// Token: 0x040000A2 RID: 162
		private static int lOMYD57sN1 = 1;

		// Token: 0x040000A3 RID: 163
		private static object rXpYaMu1Ka = new byte[0];

		// Token: 0x040000A4 RID: 164
		internal static object hbjYi16PU5 = null;

		// Token: 0x040000A5 RID: 165
		private static object A9aYpftrZJ = new string[0];

		// Token: 0x040000A6 RID: 166
		private static int GJBYZM4sKa = 0;

		// Token: 0x040000A7 RID: 167
		private static object RoRYKrF3Ut = new SortedList();

		// Token: 0x040000A8 RID: 168
		internal static object Kj9YASOMso = null;

		// Token: 0x040000A9 RID: 169
		private static object DDTY7NoTHy = new int[0];

		// Token: 0x040000AA RID: 170
		private static object btvYRYpJUl = new uint[]
		{
			3614090360U, 3905402710U, 606105819U, 3250441966U, 4118548399U, 1200080426U, 2821735955U, 4249261313U, 1770035416U, 2336552879U,
			4294925233U, 2304563134U, 1804603682U, 4254626195U, 2792965006U, 1236535329U, 4129170786U, 3225465664U, 643717713U, 3921069994U,
			3593408605U, 38016083U, 3634488961U, 3889429448U, 568446438U, 3275163606U, 4107603335U, 1163531501U, 2850285829U, 4243563512U,
			1735328473U, 2368359562U, 4294588738U, 2272392833U, 1839030562U, 4259657740U, 2763975236U, 1272893353U, 4139469664U, 3200236656U,
			681279174U, 3936430074U, 3572445317U, 76029189U, 3654602809U, 3873151461U, 530742520U, 3299628645U, 4096336452U, 1126891415U,
			2878612391U, 4237533241U, 1700485571U, 2399980690U, 4293915773U, 2240044497U, 1873313359U, 4264355552U, 2734768916U, 1309151649U,
			4149444226U, 3174756917U, 718787259U, 3951481745U
		};

		// Token: 0x040000AB RID: 171
		internal static object VLmM43P3iS = new Hashtable();

		// Token: 0x040000AC RID: 172
		private static IntPtr Y2dMOpvjeZ = IntPtr.Zero;

		// Token: 0x040000AD RID: 173
		internal static object ki5Y5BFlNm = typeof(oZWYtLnJnekp0ELgSU).Assembly;

		// Token: 0x040000AE RID: 174
		private static object JNOMfpGtow = null;

		// Token: 0x040000AF RID: 175
		private static bool SyOYycHVpR = false;

		// Token: 0x040000B0 RID: 176
		private static object GnVM6tNrkP = null;

		// Token: 0x040000B1 RID: 177
		private static bool uV3Yxuhq6X = false;

		// Token: 0x040000B2 RID: 178
		private static bool viCMM2NYad = false;

		// Token: 0x040000B3 RID: 179
		private static int UNbY8h2NGl = 0;

		// Token: 0x040000B4 RID: 180
		private static object tE7YFycIs9 = new object();

		// Token: 0x040000B5 RID: 181
		private static int hACMYVikmk = 0;

		// Token: 0x040000B6 RID: 182
		internal static object A2XYzl0jMH = null;

		// Token: 0x02000017 RID: 23
		private sealed class bD4I1dMEqtjLu7jv8Lw : MulticastDelegate
		{
			// Token: 0x0600015F RID: 351
			public extern bD4I1dMEqtjLu7jv8Lw(object \u0020, IntPtr \u0020);

			// Token: 0x06000160 RID: 352
			public extern void Invoke(object o);

			// Token: 0x06000161 RID: 353
			public extern IAsyncResult BeginInvoke(object o, AsyncCallback callback, object @object);

			// Token: 0x06000162 RID: 354
			public extern void EndInvoke(IAsyncResult result);

			// Token: 0x06000163 RID: 355 RVA: 0x0000BA1C File Offset: 0x00009C1C
			static bD4I1dMEqtjLu7jv8Lw()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x02000018 RID: 24
		internal class Wv9HhHMHVkbsjseBi6G : Attribute
		{
			// Token: 0x06000164 RID: 356 RVA: 0x0000BA24 File Offset: 0x00009C24
			[MethodImpl(MethodImplOptions.NoInlining)]
			public Wv9HhHMHVkbsjseBi6G(object \u0020)
			{
			}

			// Token: 0x06000165 RID: 357 RVA: 0x0000BA2C File Offset: 0x00009C2C
			static Wv9HhHMHVkbsjseBi6G()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}

			// Token: 0x02000019 RID: 25
			internal class HSJdIjMsBSGuYgddGBU<yVVeKCMvETGIihO8TLe>
			{
				// Token: 0x06000166 RID: 358 RVA: 0x0000BA34 File Offset: 0x00009C34
				[MethodImpl(MethodImplOptions.NoInlining)]
				public HSJdIjMsBSGuYgddGBU()
				{
				}

				// Token: 0x06000167 RID: 359 RVA: 0x0000BA44 File Offset: 0x00009C44
				[MethodImpl(MethodImplOptions.NoInlining)]
				static HSJdIjMsBSGuYgddGBU()
				{
					oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
					caJ9WyMt94Ld5cmGZMO.WqIXSNr12m();
				}

				// Token: 0x06000168 RID: 360 RVA: 0x0000BA50 File Offset: 0x00009C50
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool K0jQJ7vi8usddPMniSj()
				{
					return true;
				}

				// Token: 0x06000169 RID: 361 RVA: 0x0000BA58 File Offset: 0x00009C58
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static object XYEGQOvWb2P5sRZTX7R()
				{
					return null;
				}

				// Token: 0x040000B7 RID: 183
				private static object zcRm7lvyYg9K4H572k6;
			}
		}

		// Token: 0x0200001A RID: 26
		internal class NCJrrjMbxwqSeEV0ZUv
		{
			// Token: 0x0600016A RID: 362 RVA: 0x0000BA60 File Offset: 0x00009C60
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static string CoBMdGACCA(object \u0020, object \u0020)
			{
				return null;
			}

			// Token: 0x0600016B RID: 363 RVA: 0x0000BA70 File Offset: 0x00009C70
			[MethodImpl(MethodImplOptions.NoInlining)]
			public NCJrrjMbxwqSeEV0ZUv()
			{
			}

			// Token: 0x0600016C RID: 364 RVA: 0x0000BA78 File Offset: 0x00009C78
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object ntLVt9vnckQY3bQsW4D()
			{
				return null;
			}

			// Token: 0x0600016D RID: 365 RVA: 0x0000BA80 File Offset: 0x00009C80
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object l9Xr6SvjWKDcmRdDY3H(object A_0, object A_1)
			{
				return null;
			}

			// Token: 0x0600016E RID: 366 RVA: 0x0000BA88 File Offset: 0x00009C88
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void mCn8vZvaHwyfJrWCAo8(object A_0, RuntimeFieldHandle A_1)
			{
			}

			// Token: 0x0600016F RID: 367 RVA: 0x0000BA90 File Offset: 0x00009C90
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object JgKtUwvPNZkfROLDiyo(object A_0)
			{
				return null;
			}

			// Token: 0x06000170 RID: 368 RVA: 0x0000BA98 File Offset: 0x00009C98
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object A4Wn3fv1WyO9jd9JxVM()
			{
				return null;
			}

			// Token: 0x06000171 RID: 369 RVA: 0x0000BAA0 File Offset: 0x00009CA0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void zoioAgvVPEcZl8N9N0C(object A_0, object A_1)
			{
			}

			// Token: 0x06000172 RID: 370 RVA: 0x0000BAA8 File Offset: 0x00009CA8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object KBOGERvpiHTISQuPhoH(object A_0)
			{
				return null;
			}

			// Token: 0x06000173 RID: 371 RVA: 0x0000BAB0 File Offset: 0x00009CB0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void NWpr5Jv7dagtCYsVyJ8(object A_0, object A_1, int A_2, int A_3)
			{
			}

			// Token: 0x06000174 RID: 372 RVA: 0x0000BAB8 File Offset: 0x00009CB8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void OiMElSvD0EIhXVp2epJ(object A_0)
			{
			}

			// Token: 0x06000175 RID: 373 RVA: 0x0000BAC0 File Offset: 0x00009CC0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object V7a9csvCk6peEEdCRRI(object A_0)
			{
				return null;
			}

			// Token: 0x06000176 RID: 374 RVA: 0x0000BAC8 File Offset: 0x00009CC8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object SJuFKAvKG7X1vVMZaZc(object A_0)
			{
				return null;
			}

			// Token: 0x06000177 RID: 375 RVA: 0x0000BAD0 File Offset: 0x00009CD0
			static NCJrrjMbxwqSeEV0ZUv()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x0200001B RID: 27
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal sealed class ETwrgTMIr1cxYXE0vNU : MulticastDelegate
		{
			// Token: 0x06000178 RID: 376
			public extern ETwrgTMIr1cxYXE0vNU(object \u0020, IntPtr \u0020);

			// Token: 0x06000179 RID: 377
			public extern uint Invoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

			// Token: 0x0600017A RID: 378
			public extern IAsyncResult BeginInvoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode, AsyncCallback callback, object @object);

			// Token: 0x0600017B RID: 379
			public extern uint EndInvoke(ref uint nativeSizeOfCode, IAsyncResult result);

			// Token: 0x0600017C RID: 380 RVA: 0x0000BAD8 File Offset: 0x00009CD8
			static ETwrgTMIr1cxYXE0vNU()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x0200001C RID: 28
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class Yt3sXLMNFhiGlDlQbl5 : MulticastDelegate
		{
			// Token: 0x0600017D RID: 381
			public extern Yt3sXLMNFhiGlDlQbl5(object \u0020, IntPtr \u0020);

			// Token: 0x0600017E RID: 382
			public extern IntPtr Invoke();

			// Token: 0x0600017F RID: 383
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x06000180 RID: 384
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000181 RID: 385 RVA: 0x0000BAE0 File Offset: 0x00009CE0
			static Yt3sXLMNFhiGlDlQbl5()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x0200001D RID: 29
		internal struct YlecR5MJ2SYSVCIgjmG
		{
			// Token: 0x040000B8 RID: 184
			internal bool JTxMG0kiQa;

			// Token: 0x040000B9 RID: 185
			internal byte[] ODwMBLqmrQ;
		}

		// Token: 0x0200001E RID: 30
		internal class oWeebDMeI9rsA7EJwLV
		{
			// Token: 0x06000182 RID: 386 RVA: 0x0000BAE8 File Offset: 0x00009CE8
			[MethodImpl(MethodImplOptions.NoInlining)]
			public oWeebDMeI9rsA7EJwLV(Stream \u0020)
			{
				this.HHFMuGX1tE = new BinaryReader(\u0020);
			}

			// Token: 0x06000183 RID: 387 RVA: 0x0000BB04 File Offset: 0x00009D04
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal Stream nW4lBacjpc()
			{
				return oZWYtLnJnekp0ELgSU.oWeebDMeI9rsA7EJwLV.flXYIhbMGKVODJ1ZHUl(this.HHFMuGX1tE);
			}

			// Token: 0x06000184 RID: 388 RVA: 0x0000BB18 File Offset: 0x00009D18
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal byte[] SBtMQ6ucUs(int \u0020)
			{
				return oZWYtLnJnekp0ELgSU.oWeebDMeI9rsA7EJwLV.DJTVTEbk0wCvUMlTgh1(this.HHFMuGX1tE, \u0020);
			}

			// Token: 0x06000185 RID: 389 RVA: 0x0000BB30 File Offset: 0x00009D30
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int xVtMXuc68E(byte[] \u0020, int \u0020, int \u0020)
			{
				return this.HHFMuGX1tE.Read(\u0020, \u0020, \u0020);
			}

			// Token: 0x06000186 RID: 390 RVA: 0x0000BB48 File Offset: 0x00009D48
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int QfbM9kBllF()
			{
				return oZWYtLnJnekp0ELgSU.oWeebDMeI9rsA7EJwLV.hXTrCGbTtBerMF7RqUW(this.HHFMuGX1tE);
			}

			// Token: 0x06000187 RID: 391 RVA: 0x0000BB5C File Offset: 0x00009D5C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void Tw3MSokxej()
			{
				oZWYtLnJnekp0ELgSU.oWeebDMeI9rsA7EJwLV.qSRPnqbrve3QBCoYSeF(this.HHFMuGX1tE);
			}

			// Token: 0x06000188 RID: 392 RVA: 0x0000BB70 File Offset: 0x00009D70
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object flXYIhbMGKVODJ1ZHUl(object A_0)
			{
				return A_0.BaseStream;
			}

			// Token: 0x06000189 RID: 393 RVA: 0x0000BB84 File Offset: 0x00009D84
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object DJTVTEbk0wCvUMlTgh1(object A_0, int A_1)
			{
				return A_0.ReadBytes(A_1);
			}

			// Token: 0x0600018A RID: 394 RVA: 0x0000BB9C File Offset: 0x00009D9C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static int hXTrCGbTtBerMF7RqUW(object A_0)
			{
				return A_0.ReadInt32();
			}

			// Token: 0x0600018B RID: 395 RVA: 0x0000BBB0 File Offset: 0x00009DB0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void qSRPnqbrve3QBCoYSeF(object A_0)
			{
				A_0.Close();
			}

			// Token: 0x0600018C RID: 396 RVA: 0x0000BBC4 File Offset: 0x00009DC4
			static oWeebDMeI9rsA7EJwLV()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}

			// Token: 0x040000BA RID: 186
			private object HHFMuGX1tE;
		}

		// Token: 0x0200001F RID: 31
		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private sealed class QarH42MgRuD8vkfA7n7 : MulticastDelegate
		{
			// Token: 0x0600018D RID: 397
			public extern QarH42MgRuD8vkfA7n7(object \u0020, IntPtr \u0020);

			// Token: 0x0600018E RID: 398
			public extern IntPtr Invoke(IntPtr hModule, string lpName, uint lpType);

			// Token: 0x0600018F RID: 399
			public extern IAsyncResult BeginInvoke(IntPtr hModule, string lpName, uint lpType, AsyncCallback callback, object @object);

			// Token: 0x06000190 RID: 400
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000191 RID: 401 RVA: 0x0000BBCC File Offset: 0x00009DCC
			static QarH42MgRuD8vkfA7n7()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x02000020 RID: 32
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class XktqdYMwYPEh2q8bmGl : MulticastDelegate
		{
			// Token: 0x06000192 RID: 402
			public extern XktqdYMwYPEh2q8bmGl(object \u0020, IntPtr \u0020);

			// Token: 0x06000193 RID: 403
			public extern IntPtr Invoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x06000194 RID: 404
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect, AsyncCallback callback, object @object);

			// Token: 0x06000195 RID: 405
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000196 RID: 406 RVA: 0x0000BBD4 File Offset: 0x00009DD4
			static XktqdYMwYPEh2q8bmGl()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x02000021 RID: 33
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class YIUvVIMUPk8Y6X7LrpX : MulticastDelegate
		{
			// Token: 0x06000197 RID: 407
			public extern YIUvVIMUPk8Y6X7LrpX(object \u0020, IntPtr \u0020);

			// Token: 0x06000198 RID: 408
			public extern int Invoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

			// Token: 0x06000199 RID: 409
			public extern IAsyncResult BeginInvoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten, AsyncCallback callback, object @object);

			// Token: 0x0600019A RID: 410
			public extern int EndInvoke(out IntPtr lpNumberOfBytesWritten, IAsyncResult result);

			// Token: 0x0600019B RID: 411 RVA: 0x0000BBDC File Offset: 0x00009DDC
			static YIUvVIMUPk8Y6X7LrpX()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x02000022 RID: 34
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class le6lwNM0EMEVreNAZmC : MulticastDelegate
		{
			// Token: 0x0600019C RID: 412
			public extern le6lwNM0EMEVreNAZmC(object \u0020, IntPtr \u0020);

			// Token: 0x0600019D RID: 413
			public extern int Invoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

			// Token: 0x0600019E RID: 414
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect, AsyncCallback callback, object @object);

			// Token: 0x0600019F RID: 415
			public extern int EndInvoke(ref int lpflOldProtect, IAsyncResult result);

			// Token: 0x060001A0 RID: 416 RVA: 0x0000BBE4 File Offset: 0x00009DE4
			static le6lwNM0EMEVreNAZmC()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x02000023 RID: 35
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class YRg3LkMopxqehLM7Vxp : MulticastDelegate
		{
			// Token: 0x060001A1 RID: 417
			public extern YRg3LkMopxqehLM7Vxp(object \u0020, IntPtr \u0020);

			// Token: 0x060001A2 RID: 418
			public extern IntPtr Invoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x060001A3 RID: 419
			public extern IAsyncResult BeginInvoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId, AsyncCallback callback, object @object);

			// Token: 0x060001A4 RID: 420
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x060001A5 RID: 421 RVA: 0x0000BBEC File Offset: 0x00009DEC
			static YRg3LkMopxqehLM7Vxp()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x02000024 RID: 36
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class JNx1DNMLWJI7vceZpV3 : MulticastDelegate
		{
			// Token: 0x060001A6 RID: 422
			public extern JNx1DNMLWJI7vceZpV3(object \u0020, IntPtr \u0020);

			// Token: 0x060001A7 RID: 423
			public extern int Invoke(IntPtr ptr);

			// Token: 0x060001A8 RID: 424
			public extern IAsyncResult BeginInvoke(IntPtr ptr, AsyncCallback callback, object @object);

			// Token: 0x060001A9 RID: 425
			public extern int EndInvoke(IAsyncResult result);

			// Token: 0x060001AA RID: 426 RVA: 0x0000BBF4 File Offset: 0x00009DF4
			static JNx1DNMLWJI7vceZpV3()
			{
				oZWYtLnJnekp0ELgSU.CYCYhuJZ5j();
			}
		}

		// Token: 0x02000025 RID: 37
		[Flags]
		private enum SpHl5NM5ZgenCpujq9J
		{

		}
	}
}
