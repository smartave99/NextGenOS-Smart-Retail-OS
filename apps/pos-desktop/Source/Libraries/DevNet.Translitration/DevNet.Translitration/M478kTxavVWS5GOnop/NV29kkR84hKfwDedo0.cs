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
using e5gGvcMgYEDbOJH3lmX;
using TJ44hrMLX5KL8KiqLol;
using Uo4BWjMcbt1fOLBMNBU;

namespace M478kTxavVWS5GOnop
{
	// Token: 0x0200000D RID: 13
	internal class NV29kkR84hKfwDedo0
	{
		// Token: 0x06000055 RID: 85 RVA: 0x000027A0 File Offset: 0x000009A0
		[MethodImpl(MethodImplOptions.NoInlining)]
		static NV29kkR84hKfwDedo0()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002914 File Offset: 0x00000B14
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MNXBHeDMcm()
		{
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002918 File Offset: 0x00000B18
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] dEDypappJ(object \u0020)
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
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num6, num7, num8, num9, 0U, 7, 1U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num9, num6, num7, num8, 1U, 12, 2U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num8, num9, num6, num7, 2U, 17, 3U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num7, num8, num9, num6, 3U, 22, 4U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num6, num7, num8, num9, 4U, 7, 5U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num9, num6, num7, num8, 5U, 12, 6U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num8, num9, num6, num7, 6U, 17, 7U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num7, num8, num9, num6, 7U, 22, 8U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num6, num7, num8, num9, 8U, 7, 9U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num9, num6, num7, num8, 9U, 12, 10U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num8, num9, num6, num7, 10U, 17, 11U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num7, num8, num9, num6, 11U, 22, 12U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num6, num7, num8, num9, 12U, 7, 13U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num9, num6, num7, num8, 13U, 12, 14U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num8, num9, num6, num7, 14U, 17, 15U, array);
				NV29kkR84hKfwDedo0.Jy7i80rQY(ref num7, num8, num9, num6, 15U, 22, 16U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num6, num7, num8, num9, 1U, 5, 17U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num9, num6, num7, num8, 6U, 9, 18U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num8, num9, num6, num7, 11U, 14, 19U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num7, num8, num9, num6, 0U, 20, 20U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num6, num7, num8, num9, 5U, 5, 21U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num9, num6, num7, num8, 10U, 9, 22U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num8, num9, num6, num7, 15U, 14, 23U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num7, num8, num9, num6, 4U, 20, 24U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num6, num7, num8, num9, 9U, 5, 25U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num9, num6, num7, num8, 14U, 9, 26U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num8, num9, num6, num7, 3U, 14, 27U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num7, num8, num9, num6, 8U, 20, 28U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num6, num7, num8, num9, 13U, 5, 29U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num9, num6, num7, num8, 2U, 9, 30U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num8, num9, num6, num7, 7U, 14, 31U, array);
				NV29kkR84hKfwDedo0.fmdWoc4Bp(ref num7, num8, num9, num6, 12U, 20, 32U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num6, num7, num8, num9, 5U, 4, 33U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num9, num6, num7, num8, 8U, 11, 34U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num8, num9, num6, num7, 11U, 16, 35U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num7, num8, num9, num6, 14U, 23, 36U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num6, num7, num8, num9, 1U, 4, 37U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num9, num6, num7, num8, 4U, 11, 38U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num8, num9, num6, num7, 7U, 16, 39U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num7, num8, num9, num6, 10U, 23, 40U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num6, num7, num8, num9, 13U, 4, 41U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num9, num6, num7, num8, 0U, 11, 42U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num8, num9, num6, num7, 3U, 16, 43U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num7, num8, num9, num6, 6U, 23, 44U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num6, num7, num8, num9, 9U, 4, 45U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num9, num6, num7, num8, 12U, 11, 46U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num8, num9, num6, num7, 15U, 16, 47U, array);
				NV29kkR84hKfwDedo0.U4utl1PLW(ref num7, num8, num9, num6, 2U, 23, 48U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num6, num7, num8, num9, 0U, 6, 49U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num9, num6, num7, num8, 7U, 10, 50U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num8, num9, num6, num7, 14U, 15, 51U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num7, num8, num9, num6, 5U, 21, 52U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num6, num7, num8, num9, 12U, 6, 53U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num9, num6, num7, num8, 3U, 10, 54U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num8, num9, num6, num7, 10U, 15, 55U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num7, num8, num9, num6, 1U, 21, 56U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num6, num7, num8, num9, 8U, 6, 57U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num9, num6, num7, num8, 15U, 10, 58U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num8, num9, num6, num7, 6U, 15, 59U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num7, num8, num9, num6, 13U, 21, 60U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num6, num7, num8, num9, 4U, 6, 61U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num9, num6, num7, num8, 11U, 10, 62U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num8, num9, num6, num7, 2U, 15, 63U, array);
				NV29kkR84hKfwDedo0.UIn8XhggU(ref num7, num8, num9, num6, 9U, 21, 64U, array);
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

		// Token: 0x06000058 RID: 88 RVA: 0x00002F7C File Offset: 0x0000117C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void Jy7i80rQY(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += NV29kkR84hKfwDedo0.jksFiIUrA(\u0020 + ((\u0020 & \u0020) | (~\u0020 & \u0020)) + \u0020[(int)\u0020] + NV29kkR84hKfwDedo0.sqwYud5iUi[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002FA8 File Offset: 0x000011A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void fmdWoc4Bp(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += NV29kkR84hKfwDedo0.jksFiIUrA(\u0020 + ((\u0020 & \u0020) | (\u0020 & ~\u0020)) + \u0020[(int)\u0020] + NV29kkR84hKfwDedo0.sqwYud5iUi[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002FD4 File Offset: 0x000011D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void U4utl1PLW(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += NV29kkR84hKfwDedo0.jksFiIUrA(\u0020 + (\u0020 ^ \u0020 ^ \u0020) + \u0020[(int)\u0020] + NV29kkR84hKfwDedo0.sqwYud5iUi[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002FFC File Offset: 0x000011FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void UIn8XhggU(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += NV29kkR84hKfwDedo0.jksFiIUrA(\u0020 + (\u0020 ^ (\u0020 | ~\u0020)) + \u0020[(int)\u0020] + NV29kkR84hKfwDedo0.sqwYud5iUi[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003024 File Offset: 0x00001224
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static uint jksFiIUrA(uint \u0020, ushort \u0020)
		{
			return (\u0020 >> (int)(32 - \u0020)) | (\u0020 << (int)\u0020);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003038 File Offset: 0x00001238
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool j1MnifJ0S()
		{
			if (!NV29kkR84hKfwDedo0.BBvYgs6tiJ)
			{
				NV29kkR84hKfwDedo0.kI2Pg2FYE();
				NV29kkR84hKfwDedo0.BBvYgs6tiJ = true;
			}
			return NV29kkR84hKfwDedo0.bhCYwKH1el;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003054 File Offset: 0x00001254
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal NV29kkR84hKfwDedo0()
		{
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000305C File Offset: 0x0000125C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MvojYPpyp(byte[] \u0020, byte[] \u0020, byte[] \u0020)
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
			NV29kkR84hKfwDedo0.rCKYyMx94B = array;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000033E0 File Offset: 0x000015E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static SymmetricAlgorithm Ua7aL4Mon()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (NV29kkR84hKfwDedo0.j1MnifJ0S())
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

		// Token: 0x06000061 RID: 97 RVA: 0x00003474 File Offset: 0x00001674
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void kI2Pg2FYE()
		{
			try
			{
				new MD5CryptoServiceProvider();
			}
			catch
			{
				NV29kkR84hKfwDedo0.bhCYwKH1el = true;
				return;
			}
			try
			{
				NV29kkR84hKfwDedo0.bhCYwKH1el = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000034CC File Offset: 0x000016CC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] n7L1EX8GN(object \u0020)
		{
			if (!NV29kkR84hKfwDedo0.j1MnifJ0S())
			{
				return new MD5CryptoServiceProvider().ComputeHash(\u0020);
			}
			return NV29kkR84hKfwDedo0.dEDypappJ(\u0020);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000034EC File Offset: 0x000016EC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void POeVFNRRs(object \u0020, object \u0020, uint \u0020, object \u0020)
		{
			while (\u0020 > 0U)
			{
				int num = ((\u0020 > (uint)\u0020.Length) ? \u0020.Length : ((int)\u0020));
				\u0020.Read(\u0020, 0, num);
				NV29kkR84hKfwDedo0.OoupSDMbP(\u0020, \u0020, 0, num);
				\u0020 -= (uint)num;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003530 File Offset: 0x00001730
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void OoupSDMbP(object \u0020, object \u0020, int \u0020, int \u0020)
		{
			\u0020.TransformBlock(\u0020, \u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003540 File Offset: 0x00001740
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint cEm7i0fiY(uint \u0020, int \u0020, long \u0020, object \u0020)
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

		// Token: 0x06000066 RID: 102 RVA: 0x000035A8 File Offset: 0x000017A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void rbsDVPQwv(RuntimeTypeHandle \u0020)
		{
			try
			{
				Type typeFromHandle = Type.GetTypeFromHandle(\u0020);
				if (NV29kkR84hKfwDedo0.KnoY0GmwNk == null)
				{
					object obj = NV29kkR84hKfwDedo0.v8AYoynKm1;
					lock (obj)
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						BinaryReader binaryReader = new BinaryReader(typeof(NV29kkR84hKfwDedo0).Assembly.GetManifestResourceStream("ABR6CW2Y7hV5DmisJX.fZd3W1fyMCWEkrajir"));
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
							NV29kkR84hKfwDedo0.WQOm9MMvIW0bAgnHNWb wqom9MMvIW0bAgnHNWb = new NV29kkR84hKfwDedo0.WQOm9MMvIW0bAgnHNWb(new MemoryStream(array));
							for (int l = 0; l < num20; l++)
							{
								int num21 = wqom9MMvIW0bAgnHNWb.t6pMIY1ZoG();
								int num22 = wqom9MMvIW0bAgnHNWb.t6pMIY1ZoG();
								dictionary.Add(num21, num22);
							}
							wqom9MMvIW0bAgnHNWb.GnKMNiUoYk();
						}
						NV29kkR84hKfwDedo0.KnoY0GmwNk = dictionary;
					}
				}
				FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
				for (int m = 0; m < fields.Length; m++)
				{
					try
					{
						FieldInfo fieldInfo = fields[m];
						int metadataToken = fieldInfo.MetadataToken;
						int num23 = NV29kkR84hKfwDedo0.KnoY0GmwNk[metadataToken];
						bool flag2 = (num23 & 1073741824) > 0;
						num23 &= 1073741823;
						MethodInfo methodInfo = (MethodInfo)typeof(NV29kkR84hKfwDedo0).Module.ResolveMethod(num23, typeFromHandle.GetGenericArguments(), new Type[0]);
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

		// Token: 0x06000067 RID: 103 RVA: 0x00003C54 File Offset: 0x00001E54
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void oiXcqmDTV()
		{
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003C58 File Offset: 0x00001E58
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void C4kAKgS5L(object \u0020, int \u0020)
		{
			ceOwKYMZsUyf7rgxwdx.u1EkYHABIY(0, new object[] { \u0020, \u0020 }, null);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003C98 File Offset: 0x00001E98
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string W5QzgGlKc(int \u0020)
		{
			if (NV29kkR84hKfwDedo0.rCKYyMx94B.Length == 0)
			{
				NV29kkR84hKfwDedo0.r0tYReV3Zf = new List<string>();
				NV29kkR84hKfwDedo0.PclYx2u4Rs = new List<int>();
				NV29kkR84hKfwDedo0.C4kAKgS5L(NV29kkR84hKfwDedo0.PnsYSsCB1h.GetManifestResourceStream("XAnnZUYUKM1cL8HA7f.UgVTOHMQdnbRLuvecm"), \u0020);
			}
			if (NV29kkR84hKfwDedo0.G4dYLeR4kf < 75)
			{
				if (NV29kkR84hKfwDedo0.PnsYSsCB1h != new StackFrame(1).GetMethod().DeclaringType.Assembly)
				{
					throw new Exception();
				}
				NV29kkR84hKfwDedo0.G4dYLeR4kf++;
			}
			object ygXY58VLBJ = NV29kkR84hKfwDedo0.YgXY58VLBJ;
			lock (ygXY58VLBJ)
			{
				int num = BitConverter.ToInt32(NV29kkR84hKfwDedo0.rCKYyMx94B, \u0020);
				if (num < NV29kkR84hKfwDedo0.PclYx2u4Rs.Count && NV29kkR84hKfwDedo0.PclYx2u4Rs[num] == \u0020)
				{
					return NV29kkR84hKfwDedo0.r0tYReV3Zf[num];
				}
				try
				{
					Tk6GAUMu8Ylww9ieaCO.zdrBsQTXFV();
					byte[] array = new byte[num];
					Array.Copy(NV29kkR84hKfwDedo0.rCKYyMx94B, \u0020 + 4, array, 0, num);
					string @string = Encoding.Unicode.GetString(array, 0, array.Length);
					NV29kkR84hKfwDedo0.r0tYReV3Zf.Add(@string);
					NV29kkR84hKfwDedo0.PclYx2u4Rs.Add(\u0020);
					Array.Copy(BitConverter.GetBytes(NV29kkR84hKfwDedo0.r0tYReV3Zf.Count - 1), 0, NV29kkR84hKfwDedo0.rCKYyMx94B, \u0020, 4);
					return @string;
				}
				catch
				{
				}
			}
			return "";
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003E10 File Offset: 0x00002010
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string MHEY3CafDO(object \u0020)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(\u0020);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003E40 File Offset: 0x00002040
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint yCvYYgCuTk(IntPtr \u0020, IntPtr \u0020, IntPtr \u0020, [MarshalAs(UnmanagedType.U4)] uint \u0020, IntPtr \u0020, ref uint \u0020)
		{
			IntPtr intPtr = \u0020;
			if (NV29kkR84hKfwDedo0.c6jY9EuCV0)
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
			object obj = NV29kkR84hKfwDedo0.rO9Yzeurhb[num];
			if (obj == null)
			{
				return NV29kkR84hKfwDedo0.cD4YVHlDx5(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			NV29kkR84hKfwDedo0.udXKr1MEiU6cGbsjG68 udXKr1MEiU6cGbsjG = (NV29kkR84hKfwDedo0.udXKr1MEiU6cGbsjG68)obj;
			IntPtr intPtr2 = Marshal.AllocCoTaskMem(udXKr1MEiU6cGbsjG.JykMsC4DBr.Length);
			Marshal.Copy(udXKr1MEiU6cGbsjG.JykMsC4DBr, 0, intPtr2, udXKr1MEiU6cGbsjG.JykMsC4DBr.Length);
			if (udXKr1MEiU6cGbsjG.qiXMH0usd7)
			{
				\u0020 = intPtr2;
				\u0020 = (uint)udXKr1MEiU6cGbsjG.JykMsC4DBr.Length;
				NV29kkR84hKfwDedo0.vhIYfXd2ZB(\u0020, udXKr1MEiU6cGbsjG.JykMsC4DBr.Length, 64, ref NV29kkR84hKfwDedo0.pVgYZOIQsI);
				return 0U;
			}
			Marshal.WriteIntPtr(intPtr, IntPtr.Size * 2, intPtr2);
			Marshal.WriteInt32(intPtr, IntPtr.Size * 3, udXKr1MEiU6cGbsjG.JykMsC4DBr.Length);
			uint num2 = 0U;
			if (\u0020 != 216669565U || NV29kkR84hKfwDedo0.udbYADrdX4)
			{
				num2 = NV29kkR84hKfwDedo0.cD4YVHlDx5(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			else
			{
				NV29kkR84hKfwDedo0.udbYADrdX4 = true;
			}
			return num2;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003F74 File Offset: 0x00002174
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int t0xYMwlvRO()
		{
			return 5;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003F78 File Offset: 0x00002178
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void fWdYkX5efK()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003FA8 File Offset: 0x000021A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Delegate xpnYT4R9bG(IntPtr \u0020, Type \u0020)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[] { \u0020, \u0020 });
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00004008 File Offset: 0x00002208
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe static void sVRYrckA7s()
		{
			int num = 578;
			for (;;)
			{
				int num2 = num;
				int num3;
				byte[] array;
				int num4;
				byte[] array2;
				int num5;
				byte[] array3;
				int num6;
				byte[] array4;
				int num7;
				byte[] array8;
				byte[] array9;
				NV29kkR84hKfwDedo0.WQOm9MMvIW0bAgnHNWb wqom9MMvIW0bAgnHNWb;
				uint num10;
				int num11;
				byte[] array12;
				long num12;
				byte[] array14;
				uint num17;
				IntPtr intPtr4;
				long num18;
				long num20;
				NV29kkR84hKfwDedo0.udXKr1MEiU6cGbsjG68 udXKr1MEiU6cGbsjG;
				uint num22;
				uint num24;
				int num28;
				long num30;
				IntPtr intPtr8;
				int num32;
				int num34;
				IEnumerator enumerator;
				int num38;
				int num55;
				int num54;
				uint num76;
				int num78;
				for (;;)
				{
					IntPtr intPtr;
					byte[] array5;
					byte[] array6;
					byte[] array10;
					byte[] array11;
					IntPtr intPtr2;
					int num9;
					int num15;
					int num16;
					IntPtr intPtr5;
					IntPtr intPtr6;
					IntPtr zero;
					int num19;
					int num21;
					int num23;
					IntPtr intPtr7;
					int num25;
					int num26;
					int num29;
					int num31;
					byte[] array15;
					byte[] array16;
					int num33;
					byte[] array17;
					int num37;
					int num39;
					Process process;
					byte[] array19;
					int num53;
					IntPtr intPtr9;
					int num70;
					uint num75;
					int num77;
					switch (num2)
					{
					case 0:
						goto IL_5711;
					case 1:
						num3 = 91 + 14;
						num2 = 232;
						continue;
					case 2:
						array[8] = (byte)num4;
						num2 = 237;
						continue;
					case 3:
						goto IL_6AA3;
					case 4:
						goto IL_3132;
					case 5:
						array2[10] = (byte)num5;
						num2 = 239;
						continue;
					case 6:
						array[15] = (byte)num4;
						num2 = 319;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 237;
							continue;
						}
						continue;
					case 7:
						array2[31] = (byte)num3;
						num2 = 304;
						continue;
					case 8:
						array2[6] = 223 - 74;
						num2 = 543;
						continue;
					case 9:
						goto IL_1D49;
					case 10:
						num4 = 231 - 77;
						num2 = 175;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 475;
							continue;
						}
						continue;
					case 11:
						num5 = 132 - 44;
						num2 = 63;
						continue;
					case 12:
						if (!NV29kkR84hKfwDedo0.zDPtfCewCw5I3eiIbSv(NV29kkR84hKfwDedo0.lHbm01egpO2khojuxj1(NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0).TypeHandle).Assembly), null))
						{
							num2 = 623;
							continue;
						}
						goto IL_57C1;
					case 13:
						num3 = 114 - 45;
						num2 = 181;
						continue;
					case 14:
						array2[0] = 165 - 55;
						num2 = 390;
						continue;
					case 15:
						goto IL_3469;
					case 16:
						array2[26] = 121 - 18;
						num2 = 119;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 530;
							continue;
						}
						continue;
					case 17:
						array[15] = 143 - 47;
						num2 = 512;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 151;
							continue;
						}
						continue;
					case 18:
						array2[7] = (byte)num5;
						num2 = 128;
						continue;
					case 19:
						array3[num6 + 3] = array4[3];
						num2 = 455;
						continue;
					case 20:
						goto IL_44EE;
					case 21:
						goto IL_1201;
					case 22:
						goto IL_3DE5;
					case 23:
						array2[13] = 251 - 83;
						num2 = 141;
						continue;
					case 24:
						array[12] = (byte)num7;
						num2 = 536;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 36;
							continue;
						}
						continue;
					case 25:
						goto IL_2CD2;
					case 26:
						NV29kkR84hKfwDedo0.efiY7MM34Y = intPtr.ToInt64();
						num2 = 408;
						continue;
					case 27:
						num5 = 53 + 35;
						num2 = 319;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 424;
							continue;
						}
						continue;
					case 28:
						array5 = NV29kkR84hKfwDedo0.oVT1gvBzS2TtPWByUgB(NV29kkR84hKfwDedo0.KAMGk0BAZGjyi6HAj0E(NV29kkR84hKfwDedo0.PnsYSsCB1h));
						num2 = 599;
						continue;
					case 29:
						NV29kkR84hKfwDedo0.Q41duwBc418TjocwOgd(array6);
						num2 = 28;
						continue;
					case 30:
					{
						MemoryStream memoryStream = new MemoryStream();
						ICryptoTransform cryptoTransform;
						CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
						byte[] array7;
						NV29kkR84hKfwDedo0.An3V2ve6hq9Mo8Kki6V(cryptoStream, array7, 0, array7.Length);
						NV29kkR84hKfwDedo0.imUswKelUohq4cw0kkq(cryptoStream);
						array8 = NV29kkR84hKfwDedo0.rhu9kde2X1hktYTI6AW(memoryStream);
						NV29kkR84hKfwDedo0.FTLcMBe3L8LaLNABOIG(array6, 0, array6.Length);
						NV29kkR84hKfwDedo0.vyF9KiefMuilBGRY0nw(memoryStream);
						num2 = 435;
						continue;
					}
					case 31:
						array9[0] = 109;
						num2 = 348;
						continue;
					case 32:
					{
						int num8 = NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
						bool flag = false;
						if (num8 < 1879048192)
						{
							goto IL_610A;
						}
						num2 = 195;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 654;
							continue;
						}
						continue;
					}
					case 33:
						array10 = array2;
						num2 = 353;
						continue;
					case 34:
						array3[num6 + 2] = array11[2];
						num2 = 472;
						continue;
					case 35:
					{
						IntPtr intPtr3;
						string text;
						intPtr2 = NV29kkR84hKfwDedo0.z45h7beQtcUgckMEHJo((NV29kkR84hKfwDedo0.pAQb2TMORSfDb7oCbkk)NV29kkR84hKfwDedo0.di5JKxee35TmJLDSxMP(NV29kkR84hKfwDedo0.aBoYm1TqD1(intPtr3, text), NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0.pAQb2TMORSfDb7oCbkk).TypeHandle)));
						num2 = 468;
						continue;
					}
					case 36:
						num9 = 0;
						num2 = 320;
						continue;
					case 37:
						if (NV29kkR84hKfwDedo0.H8DAVqB55nxcQI7fdwM(NV29kkR84hKfwDedo0.LnOPKuBLT5uq2lkhud7("System.Reflection.ReflectionContext", false), null))
						{
							num2 = 636;
							continue;
						}
						goto IL_3730;
					case 38:
						array2[8] = 138 - 46;
						num2 = 311;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 242;
							continue;
						}
						continue;
					case 39:
						num10 = 0U;
						num2 = 176;
						continue;
					case 40:
						array2[2] = 124 + 6;
						num2 = 219;
						continue;
					case 41:
						goto IL_49A9;
					case 42:
						num3 = 7 + 62;
						num2 = 107;
						continue;
					case 43:
						array[14] = 124 + 119;
						num2 = 222;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 466;
							continue;
						}
						continue;
					case 44:
						goto IL_600D;
					case 45:
						goto IL_53AB;
					case 46:
						array2[23] = 222 - 74;
						num2 = 664;
						continue;
					case 47:
						array3[num11] = array12[0];
						num2 = 305;
						continue;
					case 48:
						array11 = null;
						num2 = 0;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 49:
					{
						string text2 = NV29kkR84hKfwDedo0.w5xsXoeGeMwQ6SGatFB(NV29kkR84hKfwDedo0.EJ7R5reJQHUUstQqiTN(), array9);
						num2 = 161;
						continue;
					}
					case 50:
						goto IL_66CE;
					case 51:
						goto IL_5982;
					case 52:
						array9[4] = 114;
						num2 = 589;
						continue;
					case 53:
						array2[24] = 120 + 65;
						num2 = 384;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 62;
							continue;
						}
						continue;
					case 54:
					{
						int num13;
						NV29kkR84hKfwDedo0.vhIYfXd2ZB(new IntPtr(num12), NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t(), num13, ref num13);
						num2 = 83;
						continue;
					}
					case 55:
						num4 = 223 - 74;
						num2 = 124;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 233;
							continue;
						}
						continue;
					case 56:
						return;
					case 57:
						array2[10] = 1 + 56;
						num2 = 158;
						continue;
					case 58:
						array2[31] = (byte)num3;
						num2 = 699;
						continue;
					case 59:
						array2[21] = (byte)num3;
						num2 = 64;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 76;
							continue;
						}
						continue;
					case 60:
						goto IL_1921;
					case 61:
					{
						uint num14 = 0U;
						num2 = 665;
						continue;
					}
					case 62:
						array2[17] = (byte)num5;
						num2 = 273;
						continue;
					case 63:
						array2[12] = (byte)num5;
						num2 = 463;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 407;
							continue;
						}
						continue;
					case 64:
						array9[0] = 99;
						num2 = 201;
						continue;
					case 65:
					{
						byte[] array13 = NV29kkR84hKfwDedo0.nFTgWTBZhyTFSceD2E9(wqom9MMvIW0bAgnHNWb, num15);
						num2 = 508;
						continue;
					}
					case 66:
						array2[3] = 224 - 74;
						num2 = 204;
						continue;
					case 67:
						array6[11] = array5[5];
						num2 = 325;
						continue;
					case 68:
						num4 = 208 - 69;
						num2 = 3;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 69:
						num3 = 198 - 66;
						num2 = 386;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 485;
							continue;
						}
						continue;
					case 70:
						array2[12] = 231 - 77;
						num2 = 11;
						continue;
					case 71:
						array14[num16 + 2] = (byte)((num17 & 16711680U) >> 16);
						num2 = 310;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 242;
							continue;
						}
						continue;
					case 72:
						num4 = 113 + 71;
						num2 = 167;
						continue;
					case 73:
						array2[25] = (byte)num3;
						num2 = 147;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 62;
							continue;
						}
						continue;
					case 74:
						goto IL_5DE8;
					case 75:
						array12 = NV29kkR84hKfwDedo0.LmZyF6eHOitsNhnTNQK(intPtr4.ToInt32());
						num2 = 560;
						continue;
					case 76:
						array2[22] = 196 - 65;
						num2 = 647;
						continue;
					case 77:
						array2[18] = (byte)num3;
						num2 = 41;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 5;
							continue;
						}
						continue;
					case 78:
						num5 = 232 - 77;
						num2 = 675;
						continue;
					case 79:
						goto IL_18EB;
					case 80:
						NV29kkR84hKfwDedo0.rltY2KkjPv(intPtr5, intPtr6, NV29kkR84hKfwDedo0.LmZyF6eHOitsNhnTNQK(NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb)), 4U, out zero);
						num2 = 676;
						continue;
					case 81:
						NV29kkR84hKfwDedo0.kLlJXLBBkyl3BavcAXt(new IntPtr((void*)(&num18)), 0, 0);
						num2 = 413;
						continue;
					case 82:
						goto IL_2A7D;
					case 83:
						goto IL_4F0A;
					case 84:
						goto IL_449E;
					case 85:
						NV29kkR84hKfwDedo0.Ad7B0KeiiYtGS0V0Q34(NV29kkR84hKfwDedo0.JHUYpFPJpm);
						num2 = 544;
						continue;
					case 86:
						num5 = 108 + 35;
						num2 = 192;
						continue;
					case 87:
						num4 = 86 + 42;
						num2 = 151;
						continue;
					case 88:
						goto IL_0DD6;
					case 89:
						num19++;
						num2 = 22;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 16;
							continue;
						}
						continue;
					case 90:
						goto IL_5569;
					case 91:
						array[6] = (byte)num4;
						num2 = 576;
						continue;
					case 92:
						num5 = 137 - 45;
						num2 = 18;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 16;
							continue;
						}
						continue;
					case 93:
						array9[2] = 99;
						num2 = 263;
						continue;
					case 94:
						array2[12] = (byte)num5;
						num2 = 69;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 27;
							continue;
						}
						continue;
					case 95:
						array2[14] = 87 + 90;
						num2 = 56;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 243;
							continue;
						}
						continue;
					case 96:
						array2[3] = (byte)num3;
						num2 = 108;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 83;
							continue;
						}
						continue;
					case 97:
						array4 = NV29kkR84hKfwDedo0.HlD1j2eyKm4OSmPkDsZ(num20);
						num2 = 602;
						continue;
					case 98:
						NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
						num2 = 414;
						continue;
					case 99:
						goto IL_38FD;
					case 100:
						goto IL_307B;
					case 101:
						array2[14] = 59 + 81;
						num2 = 522;
						continue;
					case 102:
						array2[8] = (byte)num3;
						num2 = 496;
						continue;
					case 103:
						array9[8] = 108;
						num2 = 170;
						continue;
					case 104:
						array2[1] = 228 - 76;
						num2 = 584;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 149;
							continue;
						}
						continue;
					case 105:
						array3[num6 + 7] = array12[7];
						num2 = 9;
						continue;
					case 106:
						array2[1] = (byte)num5;
						num2 = 702;
						continue;
					case 107:
						array2[28] = (byte)num3;
						num2 = 523;
						continue;
					case 108:
						num5 = 231 - 77;
						num2 = 619;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 682;
							continue;
						}
						continue;
					case 109:
						goto IL_449E;
					case 110:
					{
						bool flag;
						udXKr1MEiU6cGbsjG.qiXMH0usd7 = flag;
						num2 = 81;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 677;
							continue;
						}
						continue;
					}
					case 111:
						intPtr4 = IntPtr.Zero;
						num2 = 46;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 294;
							continue;
						}
						continue;
					case 112:
						array3[num6 + 6] = array11[6];
						num2 = 564;
						continue;
					case 113:
						array[11] = (byte)num7;
						num2 = 72;
						continue;
					case 114:
						array3[num6 + 4] = array11[4];
						num2 = 698;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 599;
							continue;
						}
						continue;
					case 115:
						goto IL_2B1B;
					case 116:
						array[0] = (byte)num4;
						num2 = 504;
						continue;
					case 117:
						if (num21 == num19 - 1)
						{
							num2 = 309;
							continue;
						}
						goto IL_3E61;
					case 118:
						array2[31] = (byte)num3;
						num2 = 33;
						continue;
					case 119:
						num7 = 70 + 11;
						num2 = 610;
						continue;
					case 120:
						goto IL_23A2;
					case 121:
						goto IL_6504;
					case 122:
						goto IL_5C9E;
					case 123:
						goto IL_12D9;
					case 124:
						if (num21 == num19 - 1)
						{
							num2 = 224;
							continue;
						}
						goto IL_50C1;
					case 125:
						array14[num16 + 1] = (byte)((num17 & 65280U) >> 8);
						num2 = 71;
						continue;
					case 126:
						goto IL_3730;
					case 127:
						array[15] = 199 - 66;
						num2 = 215;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 282;
							continue;
						}
						continue;
					case 128:
						num3 = 149 + 88;
						num2 = 403;
						continue;
					case 129:
						array2[20] = (byte)num5;
						num2 = 196;
						continue;
					case 130:
						array2[2] = 22 + 75;
						num2 = 206;
						continue;
					case 131:
						goto IL_3013;
					case 132:
						array[13] = 81 + 70;
						num2 = 2;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 262;
							continue;
						}
						continue;
					case 133:
						array2[8] = (byte)num3;
						num2 = 326;
						continue;
					case 134:
						array3[num11 + 2] = array11[2];
						num2 = 268;
						continue;
					case 135:
						goto IL_368B;
					case 136:
						num3 = 135 - 45;
						num2 = 1;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 657;
							continue;
						}
						continue;
					case 137:
						NV29kkR84hKfwDedo0.FTLcMBe3L8LaLNABOIG(array5, 0, array5.Length);
						num2 = 360;
						continue;
					case 138:
						goto IL_2E90;
					case 139:
						goto IL_3CDB;
					case 140:
						goto IL_610A;
					case 141:
						array2[13] = 42 + 74;
						num2 = 166;
						continue;
					case 142:
						num22 = (uint)(num23 * 4);
						num2 = 361;
						continue;
					case 143:
						NV29kkR84hKfwDedo0.eZyerlenkhFFEuNNGM5(new IntPtr(num12), intPtr7);
						num2 = 54;
						continue;
					case 144:
						num3 = 72 + 25;
						num2 = 162;
						continue;
					case 145:
						goto IL_543A;
					case 146:
						goto IL_4B3D;
					case 147:
						array2[25] = 189 - 63;
						num2 = 598;
						continue;
					case 148:
						array[5] = 169 - 56;
						num2 = 429;
						continue;
					case 149:
						goto IL_4EE5;
					case 150:
						array[10] = (byte)num4;
						num2 = 280;
						continue;
					case 151:
						array[9] = (byte)num4;
						num2 = 90;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 11;
							continue;
						}
						continue;
					case 152:
						num3 = 226 - 75;
						num2 = 180;
						continue;
					case 153:
						array[3] = (byte)num4;
						num2 = 587;
						continue;
					case 154:
						goto IL_1F9C;
					case 155:
						array2[27] = 144 - 48;
						num2 = 666;
						continue;
					case 156:
					{
						uint num14;
						num24 += num14;
						num2 = 39;
						continue;
					}
					case 157:
						goto IL_4997;
					case 158:
						array2[10] = 239 - 79;
						num2 = 394;
						continue;
					case 159:
						array3[num6 + 1] = array12[1];
						num2 = 48;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 540;
							continue;
						}
						continue;
					case 160:
						array2[4] = 56 - 29;
						num2 = 595;
						continue;
					case 161:
					{
						IntPtr intPtr3 = IntPtr.Zero;
						num2 = 132;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 251;
							continue;
						}
						continue;
					}
					case 162:
						array2[19] = (byte)num3;
						num2 = 164;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 182;
							continue;
						}
						continue;
					case 163:
						goto IL_5994;
					case 164:
						goto IL_5396;
					case 165:
						goto IL_3E61;
					case 166:
						array2[13] = 234 - 78;
						num2 = 187;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 683;
							continue;
						}
						continue;
					case 167:
						array[11] = (byte)num4;
						num2 = 658;
						continue;
					case 168:
						num24 = 0U;
						num2 = 61;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 17;
							continue;
						}
						continue;
					case 169:
						num3 = 182 - 60;
						num2 = 179;
						continue;
					case 170:
						array9[9] = 108;
						num2 = 266;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 421;
							continue;
						}
						continue;
					case 171:
						goto IL_3D20;
					case 172:
						num5 = 229 - 76;
						num2 = 652;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 19;
							continue;
						}
						continue;
					case 173:
						array2[8] = (byte)num3;
						num2 = 265;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 670;
							continue;
						}
						continue;
					case 174:
						goto IL_50F5;
					case 175:
						if (num25 <= 0)
						{
							goto IL_3DE5;
						}
						num2 = 89;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 52;
							continue;
						}
						continue;
					case 176:
						num26 = 0;
						num2 = 614;
						continue;
					case 177:
						goto IL_50C1;
					case 178:
						num3 = 123 - 58;
						num2 = 230;
						continue;
					case 179:
						array2[30] = (byte)num3;
						num2 = 467;
						continue;
					case 180:
						array2[26] = (byte)num3;
						num2 = 399;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 695;
							continue;
						}
						continue;
					case 181:
						array2[27] = (byte)num3;
						num2 = 643;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 300;
							continue;
						}
						continue;
					case 182:
						array2[19] = 41 + 36;
						num2 = 338;
						continue;
					case 183:
						array2[14] = (byte)num3;
						num2 = 242;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 214;
							continue;
						}
						continue;
					case 184:
						num5 = 132 - 84;
						num2 = 371;
						continue;
					case 185:
						goto IL_3132;
					case 186:
						goto IL_2D11;
					case 187:
						num11 = 16;
						num2 = 412;
						continue;
					case 188:
						array2[30] = 143 - 118;
						num2 = 3;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 45;
							continue;
						}
						continue;
					case 189:
						array2[2] = (byte)num3;
						num2 = 667;
						continue;
					case 190:
					{
						uint num27 = 4059231220U;
						num2 = 416;
						continue;
					}
					case 191:
						NV29kkR84hKfwDedo0.Vh8LjjB0aQhRdutmqwL();
						num2 = 549;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 603;
							continue;
						}
						continue;
					case 192:
						array2[20] = (byte)num5;
						num2 = 302;
						continue;
					case 193:
						num28 = 0;
						num2 = 345;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 575;
							continue;
						}
						continue;
					case 194:
					{
						int num13 = 0;
						num2 = 12;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 10;
							continue;
						}
						continue;
					}
					case 195:
						num7 = 84 + 11;
						num2 = 617;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 6;
							continue;
						}
						continue;
					case 196:
						array2[20] = 103 + 88;
						num2 = 25;
						continue;
					case 197:
						num29++;
						num2 = 240;
						continue;
					case 198:
						array[13] = (byte)num4;
						num2 = 548;
						continue;
					case 199:
						num30 = intPtr.ToInt64();
						num2 = 193;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 193;
							continue;
						}
						continue;
					case 200:
					{
						NV29kkR84hKfwDedo0.udXKr1MEiU6cGbsjG68 udXKr1MEiU6cGbsjG2;
						NV29kkR84hKfwDedo0.OIsub6edCIGG1XSUgtN(NV29kkR84hKfwDedo0.rO9Yzeurhb, 0L, udXKr1MEiU6cGbsjG2);
						num2 = 507;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 169;
							continue;
						}
						continue;
					}
					case 201:
						array9[1] = 108;
						num2 = 377;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 76;
							continue;
						}
						continue;
					case 202:
						array[2] = 252 - 84;
						num2 = 391;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 265;
							continue;
						}
						continue;
					case 203:
						goto IL_2B53;
					case 204:
						array2[3] = 220 + 0;
						num2 = 262;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 506;
							continue;
						}
						continue;
					case 205:
						num5 = 30 + 113;
						num2 = 19;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 94;
							continue;
						}
						continue;
					case 206:
						num5 = 252 - 84;
						num2 = 418;
						continue;
					case 207:
						array2[31] = (byte)num3;
						num2 = 198;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 525;
							continue;
						}
						continue;
					case 208:
						num7 = 118 - 105;
						num2 = 551;
						continue;
					case 209:
						goto IL_3CA1;
					case 210:
						array2[23] = (byte)num5;
						num2 = 570;
						continue;
					case 211:
						goto IL_5321;
					case 212:
						NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
						num2 = 98;
						continue;
					case 213:
						num31++;
						num2 = 109;
						continue;
					case 214:
						array2[25] = (byte)num5;
						num2 = 288;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 672;
							continue;
						}
						continue;
					case 215:
						goto IL_627A;
					case 216:
						num5 = 217 - 72;
						num2 = 267;
						continue;
					case 217:
						num10 = (uint)(((int)array15[(int)(num22 + 3U)] << 24) | ((int)array15[(int)(num22 + 2U)] << 16) | ((int)array15[(int)(num22 + 1U)] << 8) | (int)array15[(int)num22]);
						num2 = 79;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 76;
							continue;
						}
						continue;
					case 218:
						array2[15] = 211 - 101;
						num2 = 633;
						continue;
					case 219:
						num3 = 109 - 2;
						num2 = 189;
						continue;
					case 220:
						array3[num6 + 5] = array4[5];
						num2 = 440;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 148;
							continue;
						}
						continue;
					case 221:
						array14[num16] = (byte)(num17 & 255U);
						num2 = 4;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 125;
							continue;
						}
						continue;
					case 222:
						array16[0] = 103;
						num2 = 390;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 608;
							continue;
						}
						continue;
					case 223:
						array2[4] = 210 - 70;
						num2 = 517;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 150;
							continue;
						}
						continue;
					case 224:
						if (num25 > 0)
						{
							num2 = 656;
							continue;
						}
						goto IL_50C1;
					case 225:
						array2[20] = (byte)num3;
						num2 = 1;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 226:
						goto IL_18A0;
					case 227:
						num3 = 213 - 71;
						num2 = 582;
						continue;
					case 228:
						array2[17] = 117 + 114;
						num2 = 605;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 618;
							continue;
						}
						continue;
					case 229:
						array[13] = (byte)num7;
						num2 = 284;
						continue;
					case 230:
						array2[5] = (byte)num3;
						num2 = 3;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 8;
							continue;
						}
						continue;
					case 231:
						array2[1] = (byte)num5;
						num2 = 104;
						continue;
					case 232:
						array2[21] = (byte)num3;
						num2 = 327;
						continue;
					case 233:
						array[5] = (byte)num4;
						num2 = 253;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 128;
							continue;
						}
						continue;
					case 234:
						array2[29] = 52 + 89;
						num2 = 216;
						continue;
					case 235:
						goto IL_41AA;
					case 236:
						goto IL_1D2E;
					case 237:
						num7 = 62 + 17;
						num2 = 483;
						continue;
					case 238:
						num5 = 121 + 36;
						num2 = 289;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 431;
							continue;
						}
						continue;
					case 239:
						goto IL_3423;
					case 240:
						goto IL_4EE5;
					case 241:
						array[7] = (byte)num4;
						num2 = 226;
						continue;
					case 242:
						goto IL_5759;
					case 243:
						goto IL_1C3C;
					case 244:
						NV29kkR84hKfwDedo0.vGTsdrBCTxgM8tOE9Dx(NV29kkR84hKfwDedo0.F5rEPABDYpV4Wm4VXpd(wqom9MMvIW0bAgnHNWb), 0L);
						num2 = 328;
						continue;
					case 245:
						NV29kkR84hKfwDedo0.Uv6YPkQloy = intPtr.ToInt32();
						num2 = 300;
						continue;
					case 246:
						array2[12] = (byte)num5;
						num2 = 205;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 186;
							continue;
						}
						continue;
					case 247:
						array[12] = (byte)num7;
						num2 = 71;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 132;
							continue;
						}
						continue;
					case 248:
						goto IL_413E;
					case 249:
						goto IL_5FB4;
					case 250:
						array[14] = (byte)num7;
						num2 = 283;
						continue;
					case 251:
					{
						IntPtr intPtr3;
						if (NV29kkR84hKfwDedo0.gURZGweBpJ6YfNlAQyf(intPtr3, IntPtr.Zero))
						{
							goto IL_4FC0;
						}
						num2 = 7;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 20;
							continue;
						}
						continue;
					}
					case 252:
						goto IL_619D;
					case 253:
						num4 = 35 + 119;
						num2 = 573;
						continue;
					case 254:
						if (NV29kkR84hKfwDedo0.IshPQTeTFYGGDl6H0Xk(NV29kkR84hKfwDedo0.hmuUEvekZajpTdxmcgx(NV29kkR84hKfwDedo0.PnsYSsCB1h)) != 0)
						{
							num2 = 365;
							continue;
						}
						goto IL_2443;
					case 255:
						array[1] = 3 + 99;
						num2 = 119;
						continue;
					case 256:
						array2[28] = 33 + 77;
						num2 = 42;
						continue;
					case 257:
						num3 = 135 + 20;
						num2 = 373;
						continue;
					case 258:
						num25 = array15.Length % 4;
						num2 = 499;
						continue;
					case 259:
						num5 = 164 - 54;
						num2 = 312;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 622;
							continue;
						}
						continue;
					case 260:
						num4 = 109 + 82;
						num2 = 15;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 556;
							continue;
						}
						continue;
					case 261:
						goto IL_57C1;
					case 262:
						array[13] = 118 + 36;
						num2 = 458;
						continue;
					case 263:
						array9[3] = 111;
						num2 = 52;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 16;
							continue;
						}
						continue;
					case 264:
						if (NV29kkR84hKfwDedo0.vhIYfXd2ZB(intPtr8, num32 * 4, 4, ref num28) == 0)
						{
							goto IL_29EE;
						}
						num2 = 490;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 218;
							continue;
						}
						continue;
					case 265:
						num33 = NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
						num2 = 516;
						continue;
					case 266:
						array2[0] = 101 + 117;
						num2 = 514;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 382;
							continue;
						}
						continue;
					case 267:
						goto IL_0EAB;
					case 268:
						array3[num11 + 3] = array11[3];
						num2 = 187;
						continue;
					case 269:
						goto IL_118B;
					case 270:
						num7 = 88 + 15;
						num2 = 591;
						continue;
					case 271:
						array2[9] = (byte)num3;
						num2 = 277;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 307;
							continue;
						}
						continue;
					case 272:
						goto IL_1D49;
					case 273:
						array2[17] = 194 - 118;
						num2 = 296;
						continue;
					case 274:
						goto IL_69F5;
					case 275:
						array2[30] = 112 + 67;
						num2 = 169;
						continue;
					case 276:
						NV29kkR84hKfwDedo0.ipQSYsBNTvcanaI9B0j(new IntPtr((void*)(&num18)), 0);
						num2 = 444;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 411;
							continue;
						}
						continue;
					case 277:
						num3 = 146 + 8;
						num2 = 59;
						continue;
					case 278:
						num4 = 88 - 30;
						num2 = 198;
						continue;
					case 279:
						num4 = 247 - 82;
						num2 = 116;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 96;
							continue;
						}
						continue;
					case 280:
						num4 = 73 - 5;
						num2 = 86;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 473;
							continue;
						}
						continue;
					case 281:
						num4 = 52 + 37;
						num2 = 593;
						continue;
					case 282:
						array[15] = 243 - 81;
						num2 = 395;
						continue;
					case 283:
						array[14] = 156 + 63;
						num2 = 127;
						continue;
					case 284:
						num7 = 195 - 65;
						num2 = 275;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 428;
							continue;
						}
						continue;
					case 285:
					{
						string text2;
						IntPtr intPtr3 = NV29kkR84hKfwDedo0.YP0Y4BW9l9(text2);
						num2 = 484;
						continue;
					}
					case 286:
						goto IL_369E;
					case 287:
						array3[num6 + 1] = array11[1];
						num2 = 4;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 34;
							continue;
						}
						continue;
					case 288:
						array2[11] = 117 + 30;
						num2 = 374;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 309;
							continue;
						}
						continue;
					case 289:
						goto IL_396F;
					case 290:
						num3 = 172 - 57;
						num2 = 367;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 539;
							continue;
						}
						continue;
					case 291:
						array9[9] = 100;
						num2 = 694;
						continue;
					case 292:
						goto IL_2B1B;
					case 293:
						goto IL_495F;
					case 294:
						goto IL_1DDB;
					case 295:
						array2[11] = 150 + 11;
						num2 = 60;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 70;
							continue;
						}
						continue;
					case 296:
						array2[18] = 211 - 70;
						num2 = 27;
						continue;
					case 297:
						array2[24] = 71 + 1;
						num2 = 3;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 53;
							continue;
						}
						continue;
					case 298:
						num34 = NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
						num2 = 286;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 251;
							continue;
						}
						continue;
					case 299:
						NV29kkR84hKfwDedo0.JHUYpFPJpm = new NV29kkR84hKfwDedo0.l1T8AmMhyV3o44qdUZy(NV29kkR84hKfwDedo0.yCvYYgCuTk);
						num2 = 111;
						continue;
					case 300:
						goto IL_296B;
					case 301:
						num7 = 87 + 13;
						num2 = 113;
						continue;
					case 302:
						num5 = 24 + 57;
						num2 = 129;
						continue;
					case 303:
						array9[6] = 46;
						num2 = 549;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 567;
							continue;
						}
						continue;
					case 304:
						num3 = 4 + 102;
						num2 = 207;
						continue;
					case 305:
						array3[num11 + 1] = array12[1];
						num2 = 594;
						continue;
					case 306:
						goto IL_5031;
					case 307:
						array2[9] = 36 + 123;
						num2 = 184;
						continue;
					case 308:
						goto IL_3145;
					case 309:
						if (num25 > 0)
						{
							goto Block_231;
						}
						goto IL_3E61;
					case 310:
						array14[num16 + 3] = (byte)((num17 & 4278190080U) >> 24);
						num2 = 253;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 292;
							continue;
						}
						continue;
					case 311:
						array2[8] = 159 - 53;
						num2 = 345;
						continue;
					case 312:
						num5 = 116 + 68;
						num2 = 345;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 400;
							continue;
						}
						continue;
					case 313:
						array[1] = (byte)num4;
						num2 = 202;
						continue;
					case 314:
						goto IL_3092;
					case 315:
						NV29kkR84hKfwDedo0.QNv1gXetZHO8XIJf8Uu(NV29kkR84hKfwDedo0.ypWn96eWqOMZxsqJ318(NV29kkR84hKfwDedo0.CZa5bReUy7QZPCi3EAS(NV29kkR84hKfwDedo0.cD4YVHlDx5)));
						num2 = 85;
						continue;
					case 316:
						array2[28] = 51 + 47;
						num2 = 19;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 256;
							continue;
						}
						continue;
					case 317:
						num3 = 67 + 114;
						num2 = 533;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 609;
							continue;
						}
						continue;
					case 318:
						goto IL_386A;
					case 319:
						array[15] = 189 - 63;
						num2 = 17;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 4;
							continue;
						}
						continue;
					case 320:
						goto IL_368B;
					case 321:
						goto IL_4D0B;
					case 322:
						num7 = 138 - 46;
						num2 = 366;
						continue;
					case 323:
						array6[3] = array5[1];
						num2 = 535;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 79;
							continue;
						}
						continue;
					case 324:
					{
						NV29kkR84hKfwDedo0.udXKr1MEiU6cGbsjG68 udXKr1MEiU6cGbsjG2 = default(NV29kkR84hKfwDedo0.udXKr1MEiU6cGbsjG68);
						num2 = 437;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 394;
							continue;
						}
						continue;
					}
					case 325:
						array6[13] = array5[6];
						num2 = 383;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 389;
							continue;
						}
						continue;
					case 326:
						num3 = 182 - 78;
						num2 = 173;
						continue;
					case 327:
						num3 = 193 - 64;
						num2 = 385;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 521;
							continue;
						}
						continue;
					case 328:
						intPtr = NV29kkR84hKfwDedo0.JHID6LeMEj0q7akLDSR(NV29kkR84hKfwDedo0.SoYtpTeYnmfQnAd617X(NV29kkR84hKfwDedo0.PnsYSsCB1h)[0]);
						num2 = 199;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 5;
							continue;
						}
						continue;
					case 329:
						goto IL_29EE;
					case 330:
						goto IL_4F97;
					case 331:
						array[2] = (byte)num4;
						num2 = 464;
						continue;
					case 332:
						goto IL_41AA;
					case 333:
						goto IL_3C05;
					case 334:
						goto IL_61EB;
					case 335:
						array3[num6] = array4[0];
						num2 = 443;
						continue;
					case 336:
						array2[28] = 35 + 116;
						num2 = 427;
						continue;
					case 337:
						array[1] = 163 - 54;
						num2 = 10;
						continue;
					case 338:
						array2[19] = 39 + 118;
						num2 = 638;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 326;
							continue;
						}
						continue;
					case 339:
						array3[num6 + 2] = array4[2];
						num2 = 19;
						continue;
					case 340:
						goto IL_19E4;
					case 341:
						num3 = 51 + 74;
						num2 = 29;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 73;
							continue;
						}
						continue;
					case 342:
						array12 = null;
						num2 = 125;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 131;
							continue;
						}
						continue;
					case 343:
						array3[num11 + 1] = array11[1];
						num2 = 134;
						continue;
					case 344:
						goto IL_2E90;
					case 345:
						num3 = 8 + 69;
						num2 = 22;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 102;
							continue;
						}
						continue;
					case 346:
						NV29kkR84hKfwDedo0.fK7Y1hjYYs = intPtr.ToInt64();
						num2 = 493;
						continue;
					case 347:
						array16[2] = 116;
						num2 = 586;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 208;
							continue;
						}
						continue;
					case 348:
						goto IL_6396;
					case 349:
						array[14] = (byte)num7;
						num2 = 14;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 43;
							continue;
						}
						continue;
					case 350:
						num4 = 187 - 102;
						num2 = 74;
						continue;
					case 351:
						array2[21] = (byte)num3;
						num2 = 423;
						continue;
					case 352:
						array[3] = 67 - 61;
						num2 = 518;
						continue;
					case 353:
						array = new byte[16];
						num2 = 411;
						continue;
					case 354:
						array6 = array;
						num2 = 29;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 29;
							continue;
						}
						continue;
					case 355:
						array[4] = (byte)num4;
						num2 = 625;
						continue;
					case 356:
						array[8] = (byte)num7;
						num2 = 689;
						continue;
					case 357:
						goto IL_2A99;
					case 358:
						array2[6] = 42 + 63;
						num2 = 198;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 541;
							continue;
						}
						continue;
					case 359:
						goto IL_5E5C;
					case 360:
						goto IL_1A4C;
					case 361:
					{
						uint num14 = (uint)(((int)array10[(int)(num22 + 3U)] << 24) | ((int)array10[(int)(num22 + 2U)] << 16) | ((int)array10[(int)(num22 + 1U)] << 8) | (int)array10[(int)num22]);
						num2 = 451;
						continue;
					}
					case 362:
						try
						{
							for (;;)
							{
								IL_478C:
								if (NV29kkR84hKfwDedo0.torpQrBV8jJowlu5Wt6(enumerator))
								{
									goto IL_4764;
								}
								int num35 = 11;
								ProcessModule processModule;
								for (;;)
								{
									IL_472A:
									switch (num35)
									{
									case 0:
										goto IL_48BB;
									case 1:
									{
										Version version;
										Version version2;
										if (NV29kkR84hKfwDedo0.X4XiJaBPtf6ZA8OOshn(version, version2))
										{
											num35 = 8;
											continue;
										}
										goto IL_478C;
									}
									case 2:
										break;
									case 3:
									{
										Version version2 = new Version(4, 0, 30319, 17020);
										num35 = 10;
										continue;
									}
									case 4:
										goto IL_480C;
									case 5:
										goto IL_4764;
									case 6:
										goto IL_4833;
									case 7:
										goto IL_478C;
									case 8:
									{
										Version version;
										Version version3;
										if (!NV29kkR84hKfwDedo0.lj3SSxB1P12VehOyKFy(version, version3))
										{
											num35 = 4;
											if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
											{
												num35 = 2;
												continue;
											}
											continue;
										}
										break;
									}
									case 9:
									{
										Version version = new Version(NV29kkR84hKfwDedo0.r5hpJpBF83ooHImyy2C(NV29kkR84hKfwDedo0.FO1nMoB85Mo36cpBfXN(processModule)), NV29kkR84hKfwDedo0.aYgLZeBnKXhAyxl9cco(NV29kkR84hKfwDedo0.FO1nMoB85Mo36cpBfXN(processModule)), NV29kkR84hKfwDedo0.gNqcINBjJjHf2ejxbAx(NV29kkR84hKfwDedo0.FO1nMoB85Mo36cpBfXN(processModule)), NV29kkR84hKfwDedo0.EMrf9OBaSl9eMurOvVe(NV29kkR84hKfwDedo0.FO1nMoB85Mo36cpBfXN(processModule)));
										num35 = 0;
										if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
										{
											num35 = 3;
											continue;
										}
										continue;
									}
									case 10:
									{
										Version version3 = new Version(4, 0, 30319, 17921);
										num35 = 1;
										if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
										{
											num35 = 0;
											continue;
										}
										continue;
									}
									case 11:
										goto IL_48E0;
									default:
										goto IL_48BB;
									}
									NV29kkR84hKfwDedo0.c6jY9EuCV0 = true;
									num35 = 6;
									if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
									{
										num35 = 6;
										continue;
									}
									continue;
									IL_48BB:
									if (!NV29kkR84hKfwDedo0.tCxyy1BtA9kP4ainTSh(NV29kkR84hKfwDedo0.JnQ0NPBW9AXAjOJrPHI(NV29kkR84hKfwDedo0.Iqox8WBido9wGw5OwMJ(processModule)), "clrjit.dll"))
									{
										break;
									}
									num35 = 9;
								}
								IL_480C:
								continue;
								IL_4764:
								processModule = (ProcessModule)NV29kkR84hKfwDedo0.McNfFQBys3F6yTNXWUD(enumerator);
								num35 = 0;
								if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
								{
									num35 = 0;
									goto IL_472A;
								}
								goto IL_472A;
							}
							IL_4833:
							IL_48E0:
							goto IL_3730;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							int num36 = 2;
							for (;;)
							{
								switch (num36)
								{
								case 1:
									goto IL_4954;
								case 2:
									if (disposable == null)
									{
										goto IL_4954;
									}
									num36 = 0;
									if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
									{
										num36 = 0;
										continue;
									}
									continue;
								}
								NV29kkR84hKfwDedo0.PfZfcEBp90mPiaZ1KkX(disposable);
								num36 = 1;
								if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
								{
									num36 = 0;
								}
							}
							IL_4954:;
						}
						goto IL_495F;
					case 363:
						array3[num6 + 4] = array12[4];
						num2 = 109;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 590;
							continue;
						}
						continue;
					case 364:
						array14 = new byte[array15.Length];
						num2 = 84;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 420;
							continue;
						}
						continue;
					case 365:
						goto IL_5FB4;
					case 366:
						array[12] = (byte)num7;
						num2 = 68;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 203;
							continue;
						}
						continue;
					case 367:
						if ((array17 = array8) != null)
						{
							goto IL_4BEA;
						}
						num2 = 529;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 470;
							continue;
						}
						continue;
					case 368:
						goto IL_108D;
					case 369:
						array2[10] = 143 - 47;
						num2 = 20;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 57;
							continue;
						}
						continue;
					case 370:
						num32 = NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
						num2 = 264;
						continue;
					case 371:
						goto IL_2427;
					case 372:
						num11 = 9;
						num2 = 474;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 569;
							continue;
						}
						continue;
					case 373:
						array2[24] = (byte)num3;
						num2 = 340;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 515;
							continue;
						}
						continue;
					case 374:
						num5 = 52 + 37;
						num2 = 487;
						continue;
					case 375:
						goto IL_3F44;
					case 376:
						num20 = (long)NV29kkR84hKfwDedo0.F5NM5peXLC6s49pnp3W(new IntPtr(num12));
						num2 = 218;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 289;
							continue;
						}
						continue;
					case 377:
						goto IL_5661;
					case 378:
						array[8] = (byte)num7;
						num2 = 415;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 268;
							continue;
						}
						continue;
					case 379:
						num37++;
						num2 = 332;
						continue;
					case 380:
						NV29kkR84hKfwDedo0.rO9Yzeurhb = new Hashtable(NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb) + 1);
						num2 = 324;
						continue;
					case 381:
						num5 = 71 + 61;
						num2 = 557;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 481;
							continue;
						}
						continue;
					case 382:
						array2[31] = 76 + 19;
						num2 = 209;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 601;
							continue;
						}
						continue;
					case 383:
						array9[8] = 46;
						num2 = 291;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 233;
							continue;
						}
						continue;
					case 384:
						array2[24] = 243 - 81;
						num2 = 478;
						continue;
					case 385:
						goto IL_18EB;
					case 386:
						goto IL_1F9C;
					case 387:
						goto IL_5F6E;
					case 388:
						NV29kkR84hKfwDedo0.vhIYfXd2ZB(intPtr8, num32 * 4, num28, ref num28);
						num2 = 562;
						continue;
					case 389:
						array6[15] = array5[7];
						num2 = 137;
						continue;
					case 390:
						array2[0] = 115 + 55;
						num2 = 266;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 228;
							continue;
						}
						continue;
					case 391:
						array[2] = 254 - 84;
						num2 = 441;
						continue;
					case 392:
						array2[19] = (byte)num5;
						num2 = 460;
						continue;
					case 393:
						num33 = NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
						num2 = 705;
						continue;
					case 394:
						num5 = 214 - 71;
						num2 = 3;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 5;
							continue;
						}
						continue;
					case 395:
						num4 = 110 + 23;
						num2 = 6;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 396:
						num4 = 81 + 69;
						num2 = 93;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 153;
							continue;
						}
						continue;
					case 397:
						array[9] = (byte)num4;
						num2 = 581;
						continue;
					case 398:
						num9++;
						num2 = 135;
						continue;
					case 399:
						num5 = 229 - 76;
						num2 = 549;
						continue;
					case 400:
						array2[25] = (byte)num5;
						num2 = 69;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 341;
							continue;
						}
						continue;
					case 401:
						array2[16] = (byte)num5;
						num2 = 269;
						continue;
					case 402:
						num5 = 137 + 34;
						num2 = 106;
						continue;
					case 403:
						array2[7] = (byte)num3;
						num2 = 38;
						continue;
					case 404:
						goto IL_4D30;
					case 405:
						intPtr5 = IntPtr.Zero;
						num2 = 144;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 481;
							continue;
						}
						continue;
					case 406:
						num5 = 160 - 93;
						num2 = 425;
						continue;
					case 407:
						break;
					case 408:
						if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() == 4)
						{
							num2 = 550;
							continue;
						}
						goto IL_1B93;
					case 409:
						NV29kkR84hKfwDedo0.vhIYfXd2ZB(intPtr6, 4, 8, ref num28);
						num2 = 534;
						continue;
					case 410:
						array2[14] = 190 - 63;
						num2 = 505;
						continue;
					case 411:
						goto IL_1C5F;
					case 412:
						goto IL_2329;
					case 413:
						NV29kkR84hKfwDedo0.t7ysJHBePkjjxMqmUpu(new IntPtr((void*)(&num18)), 0, 0L);
						num2 = 417;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 400;
							continue;
						}
						continue;
					case 414:
						num38 = NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
						num2 = 265;
						continue;
					case 415:
						goto IL_256C;
					case 416:
						num18 = 0L;
						num2 = 248;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 101;
							continue;
						}
						continue;
					case 417:
						NV29kkR84hKfwDedo0.DhW367BXUowLGtjdKhD(new byte[1], 0, NV29kkR84hKfwDedo0.p0Pp9IBQgKU5F6R37Wh(8), 1);
						num2 = 170;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 621;
							continue;
						}
						continue;
					case 418:
						goto IL_5E40;
					case 419:
						if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() != 4)
						{
							goto IL_3526;
						}
						num2 = 148;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 376;
							continue;
						}
						continue;
					case 420:
						num39 = array10.Length / 4;
						num2 = 168;
						continue;
					case 421:
					{
						string text2 = NV29kkR84hKfwDedo0.w5xsXoeGeMwQ6SGatFB(NV29kkR84hKfwDedo0.EJ7R5reJQHUUstQqiTN(), array9);
						num2 = 23;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 285;
							continue;
						}
						continue;
					}
					case 422:
						array2[10] = (byte)num5;
						num2 = 288;
						continue;
					case 423:
						array2[21] = 54 + 63;
						num2 = 277;
						continue;
					case 424:
						array2[18] = (byte)num5;
						num2 = 479;
						continue;
					case 425:
						array2[12] = (byte)num5;
						num2 = 23;
						continue;
					case 426:
						if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() == 4)
						{
							num2 = 661;
							continue;
						}
						goto IL_188D;
					case 427:
						array2[29] = 32 + 34;
						num2 = 234;
						continue;
					case 428:
						array[13] = (byte)num7;
						num2 = 520;
						continue;
					case 429:
						array[5] = 86 + 47;
						num2 = 318;
						continue;
					case 430:
						array[7] = (byte)num7;
						num2 = 671;
						continue;
					case 431:
						array2[4] = (byte)num5;
						num2 = 160;
						continue;
					case 432:
						goto IL_2814;
					case 433:
						array2[15] = (byte)num3;
						num2 = 555;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 46;
							continue;
						}
						continue;
					case 434:
						try
						{
							enumerator = NV29kkR84hKfwDedo0.TSnkDcBx17MYw0rFeLg(NV29kkR84hKfwDedo0.vtnGXdBRCk1dm0Xhujo(process));
							int num40 = 1;
							if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
							{
								num40 = 1;
							}
							switch (num40)
							{
							case 1:
								try
								{
									for (;;)
									{
										IL_0C93:
										if (NV29kkR84hKfwDedo0.torpQrBV8jJowlu5Wt6(enumerator))
										{
											goto IL_0CB8;
										}
										int num41 = 8;
										ProcessModule processModule2;
										for (;;)
										{
											IL_0BA4:
											switch (num41)
											{
											case 1:
												goto IL_0CB8;
											case 2:
												goto IL_0CD0;
											case 3:
												goto IL_0C93;
											case 4:
											{
												string text2;
												if (!NV29kkR84hKfwDedo0.tCxyy1BtA9kP4ainTSh(NV29kkR84hKfwDedo0.Iqox8WBido9wGw5OwMJ(processModule2), text2))
												{
													goto IL_0C93;
												}
												num41 = 1;
												if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
												{
													num41 = 6;
													continue;
												}
												continue;
											}
											case 5:
											{
												long num42 = num20;
												intPtr = NV29kkR84hKfwDedo0.nbACg9BgZPN48gusEQn(processModule2);
												if (num42 <= intPtr.ToInt64() + (long)NV29kkR84hKfwDedo0.B4oCWpeudHWwiFHujEl(processModule2))
												{
													goto IL_0C93;
												}
												num41 = 0;
												if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
												{
													num41 = 0;
													continue;
												}
												continue;
											}
											case 6:
											{
												long num43 = num20;
												intPtr = NV29kkR84hKfwDedo0.nbACg9BgZPN48gusEQn(processModule2);
												if (num43 >= intPtr.ToInt64())
												{
													num41 = 5;
													if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
													{
														num41 = 3;
														continue;
													}
													continue;
												}
												break;
											}
											case 7:
												NV29kkR84hKfwDedo0.Vh8LjjB0aQhRdutmqwL();
												num41 = 2;
												continue;
											case 8:
												goto IL_0CDF;
											}
											if (!NV29kkR84hKfwDedo0.zDPtfCewCw5I3eiIbSv(NV29kkR84hKfwDedo0.lHbm01egpO2khojuxj1(NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0).TypeHandle).Assembly), null))
											{
												goto IL_0C93;
											}
											num41 = 7;
										}
										IL_0CB8:
										processModule2 = (ProcessModule)NV29kkR84hKfwDedo0.McNfFQBys3F6yTNXWUD(enumerator);
										num41 = 4;
										goto IL_0BA4;
									}
									IL_0CD0:
									return;
									IL_0CDF:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num44 = 1;
									if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
									{
										num44 = 0;
									}
									for (;;)
									{
										switch (num44)
										{
										case 1:
											if (disposable == null)
											{
												int num45 = 3;
												num44 = num45;
												continue;
											}
											break;
										case 2:
											goto IL_0D6A;
										case 3:
											goto IL_0D25;
										}
										NV29kkR84hKfwDedo0.PfZfcEBp90mPiaZ1KkX(disposable);
										num44 = 2;
									}
									IL_0D25:
									IL_0D6A:;
								}
								break;
							}
							goto IL_3469;
						}
						catch
						{
							int num46 = 0;
							if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
							{
								num46 = 0;
							}
							switch (num46)
							{
							default:
								goto IL_3469;
							}
						}
						goto IL_0DD6;
					case 435:
					{
						CryptoStream cryptoStream;
						NV29kkR84hKfwDedo0.vyF9KiefMuilBGRY0nw(cryptoStream);
						num2 = 559;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 267;
							continue;
						}
						continue;
					}
					case 436:
						goto IL_5E23;
					case 437:
					{
						NV29kkR84hKfwDedo0.udXKr1MEiU6cGbsjG68 udXKr1MEiU6cGbsjG2;
						udXKr1MEiU6cGbsjG2.JykMsC4DBr = new byte[] { 42 };
						num2 = 600;
						continue;
					}
					case 438:
						array[0] = (byte)num4;
						num2 = 279;
						continue;
					case 439:
						goto IL_188D;
					case 440:
						array3[num6 + 6] = array4[6];
						num2 = 186;
						continue;
					case 441:
						num4 = 107 + 2;
						num2 = 331;
						continue;
					case 442:
						array2[13] = 137 - 22;
						num2 = 95;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 93;
							continue;
						}
						continue;
					case 443:
						array3[num6 + 1] = array4[1];
						num2 = 339;
						continue;
					case 444:
						NV29kkR84hKfwDedo0.oAF4gLBJHXCPoUqUxtO(new IntPtr((void*)(&num18)), 0);
						num2 = 632;
						continue;
					case 445:
						array2[16] = 254 - 84;
						num2 = 452;
						continue;
					case 446:
						array2[26] = 98 + 110;
						num2 = 152;
						continue;
					case 447:
						num7 = 207 - 69;
						num2 = 356;
						continue;
					case 448:
						array6[9] = array5[4];
						num2 = 67;
						continue;
					case 449:
						goto IL_3AB6;
					case 450:
						goto IL_38FD;
					case 451:
						goto IL_3AFE;
					case 452:
						array2[16] = 135 - 119;
						num2 = 268;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 290;
							continue;
						}
						continue;
					case 453:
					{
						byte[] array18 = new byte[40];
						NV29kkR84hKfwDedo0.X1B4M5e8SBgmcuBdnhH(array18, fieldof(<PrivateImplementationDetails>{DD2913A0-494D-4B07-931B-14A029D7A590}.0E448EF5E5E60630BDDB19388CB6378436E3C65D03DD66DA7C6EBFF563BD857A).FieldHandle);
						array19 = array18;
						num2 = 450;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 288;
							continue;
						}
						continue;
					}
					case 454:
						try
						{
							object obj = NV29kkR84hKfwDedo0.cMtbJ7exWSYAsDt3UY7(NV29kkR84hKfwDedo0.O0LTNseR1uoZM7rIVdu(NV29kkR84hKfwDedo0.yfOL4ne5E4w3cfaOG1C(NV29kkR84hKfwDedo0.EvhQHceLhsTmkMkqFWr(NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0).TypeHandle).Assembly))).GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), NV29kkR84hKfwDedo0.yfOL4ne5E4w3cfaOG1C(NV29kkR84hKfwDedo0.EvhQHceLhsTmkMkqFWr(NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0).TypeHandle).Assembly)));
							int num47 = 9;
							uint num48;
							byte[] array20;
							for (;;)
							{
								MemoryStream memoryStream2;
								switch (num47)
								{
								case 0:
									goto IL_14EE;
								case 1:
									NV29kkR84hKfwDedo0.vGTsdrBCTxgM8tOE9Dx(memoryStream2, 0L);
									num47 = 4;
									continue;
								case 2:
									goto IL_15BA;
								case 3:
									num48 = 0U;
									num47 = 12;
									continue;
								case 4:
									array20 = NV29kkR84hKfwDedo0.rhu9kde2X1hktYTI6AW(memoryStream2);
									num47 = 0;
									if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
									{
										num47 = 6;
										continue;
									}
									continue;
								case 5:
									if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() == 4)
									{
										num47 = 3;
										if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
										{
											num47 = 13;
											continue;
										}
										continue;
									}
									break;
								case 6:
									NV29kkR84hKfwDedo0.vyF9KiefMuilBGRY0nw(memoryStream2);
									num47 = 3;
									continue;
								case 7:
									goto IL_15FF;
								case 8:
									NV29kkR84hKfwDedo0.a0dYctZEET = (IntPtr)obj;
									num47 = 11;
									continue;
								case 9:
									if (obj is IntPtr)
									{
										num47 = 8;
										continue;
									}
									goto IL_1520;
								case 10:
									NV29kkR84hKfwDedo0.An3V2ve6hq9Mo8Kki6V(memoryStream2, new byte[NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t()], 0, NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t());
									num47 = 0;
									if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
									{
										num47 = 1;
										continue;
									}
									continue;
								case 11:
									goto IL_1520;
								case 12:
									goto IL_1620;
								case 13:
									NV29kkR84hKfwDedo0.An3V2ve6hq9Mo8Kki6V(memoryStream2, NV29kkR84hKfwDedo0.LmZyF6eHOitsNhnTNQK(NV29kkR84hKfwDedo0.a0dYctZEET.ToInt32()), 0, 4);
									num47 = 0;
									if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
									{
										num47 = 7;
										continue;
									}
									continue;
								case 14:
									goto IL_15FF;
								case 15:
									NV29kkR84hKfwDedo0.An3V2ve6hq9Mo8Kki6V(memoryStream2, new byte[NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t()], 0, NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t());
									num47 = 5;
									if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
									{
										num47 = 2;
										continue;
									}
									continue;
								case 16:
									break;
								case 17:
									goto IL_176A;
								default:
									goto IL_14EE;
								}
								NV29kkR84hKfwDedo0.An3V2ve6hq9Mo8Kki6V(memoryStream2, NV29kkR84hKfwDedo0.HlD1j2eyKm4OSmPkDsZ(NV29kkR84hKfwDedo0.a0dYctZEET.ToInt64()), 0, 8);
								num47 = 14;
								continue;
								IL_14EE:
								NV29kkR84hKfwDedo0.a0dYctZEET = (IntPtr)NV29kkR84hKfwDedo0.cMtbJ7exWSYAsDt3UY7(obj.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), obj);
								int num49 = 2;
								num47 = num49;
								continue;
								IL_1520:
								if (NV29kkR84hKfwDedo0.tCxyy1BtA9kP4ainTSh(obj.GetType().ToString(), "System.Reflection.RuntimeModule"))
								{
									num47 = 0;
									if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
									{
										num47 = 0;
										continue;
									}
									continue;
								}
								IL_15BA:
								memoryStream2 = new MemoryStream();
								num47 = 15;
								continue;
								IL_15FF:
								NV29kkR84hKfwDedo0.An3V2ve6hq9Mo8Kki6V(memoryStream2, new byte[NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t()], 0, NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t());
								num47 = 10;
							}
							IL_1620:
							try
							{
								if ((array17 = array20) == null)
								{
									goto IL_1694;
								}
								int num50 = 1;
								if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
								{
									num50 = 0;
								}
								byte* ptr;
								for (;;)
								{
									IL_1649:
									switch (num50)
									{
									case 1:
										if (array17.Length != 0)
										{
											num50 = 3;
											continue;
										}
										goto IL_1694;
									case 2:
										goto IL_171B;
									case 4:
										goto IL_16B1;
									case 5:
										goto IL_16B1;
									case 6:
										goto IL_1694;
									}
									ptr = &array17[0];
									num50 = 4;
									if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
									{
										num50 = 1;
										continue;
									}
									continue;
									IL_16B1:
									NV29kkR84hKfwDedo0.JHUYpFPJpm(new IntPtr((void*)ptr), new IntPtr((void*)ptr), new IntPtr((void*)ptr), 216669565U, new IntPtr((void*)ptr), ref num48);
									num50 = 2;
								}
								IL_171B:
								goto IL_176A;
								IL_1694:
								ptr = null;
								num50 = 5;
								goto IL_1649;
							}
							finally
							{
								array17 = null;
								int num51 = 0;
								if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
								{
									num51 = 0;
								}
								switch (num51)
								{
								}
							}
							IL_176A:
							goto IL_3CDB;
						}
						catch
						{
							int num52 = 0;
							if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
							{
								num52 = 0;
							}
							switch (num52)
							{
							default:
								goto IL_3CDB;
							}
						}
						goto IL_17AF;
					case 455:
						goto IL_5CD2;
					case 456:
						goto IL_1271;
					case 457:
						goto IL_3526;
					case 458:
						num7 = 254 - 84;
						num2 = 229;
						continue;
					case 459:
						num7 = 61 + 105;
						num2 = 430;
						continue;
					case 460:
						array2[19] = 47 + 102;
						num2 = 144;
						continue;
					case 461:
						array3 = array19;
						num2 = 342;
						continue;
					case 462:
						return;
					case 463:
						num5 = 90 + 87;
						num2 = 246;
						continue;
					case 464:
						num7 = 119 + 41;
						num2 = 477;
						continue;
					case 465:
						goto IL_1A4C;
					case 466:
						num7 = 172 - 57;
						num2 = 230;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 250;
							continue;
						}
						continue;
					case 467:
						num5 = 25 + 90;
						num2 = 82;
						continue;
					case 468:
						goto IL_200E;
					case 469:
						intPtr = NV29kkR84hKfwDedo0.JHID6LeMEj0q7akLDSR(NV29kkR84hKfwDedo0.SoYtpTeYnmfQnAd617X(NV29kkR84hKfwDedo0.PnsYSsCB1h)[0]);
						num2 = 245;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 137;
							continue;
						}
						continue;
					case 470:
						NV29kkR84hKfwDedo0.vGTsdrBCTxgM8tOE9Dx(NV29kkR84hKfwDedo0.F5rEPABDYpV4Wm4VXpd(wqom9MMvIW0bAgnHNWb), 0L);
						num2 = 616;
						continue;
					case 471:
						num3 = 254 - 84;
						num2 = 433;
						continue;
					case 472:
						array3[num6 + 3] = array11[3];
						num2 = 114;
						continue;
					case 473:
						goto IL_6577;
					case 474:
						array3[num11 + 3] = array4[3];
						num2 = 51;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 121;
							continue;
						}
						continue;
					case 475:
						array[1] = (byte)num4;
						num2 = 580;
						continue;
					case 476:
						num6 = 30;
						num2 = 462;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 510;
							continue;
						}
						continue;
					case 477:
						goto IL_578E;
					case 478:
						array2[24] = 174 - 58;
						num2 = 220;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 257;
							continue;
						}
						continue;
					case 479:
						num5 = 112 + 62;
						num2 = 680;
						continue;
					case 480:
						goto IL_4B3D;
					case 481:
						intPtr5 = NV29kkR84hKfwDedo0.zvb3EXeEMBIlUi5y0WA(56U, 1, (uint)NV29kkR84hKfwDedo0.XugcUheOsaYLtoDonZE(NV29kkR84hKfwDedo0.Xyy5WCBS56dSm5dsppq()));
						num2 = 531;
						continue;
					case 482:
						array[11] = 42 + 74;
						num2 = 208;
						continue;
					case 483:
						array[8] = (byte)num7;
						num2 = 533;
						continue;
					case 484:
						goto IL_44EE;
					case 485:
						goto IL_2519;
					case 486:
					{
						uint num27;
						if (num27 == 4109628145U)
						{
							goto Block_169;
						}
						goto IL_5070;
					}
					case 487:
						goto IL_21A5;
					case 488:
						num3 = 221 - 73;
						num2 = 351;
						continue;
					case 489:
						num4 = 102 + 56;
						num2 = 150;
						continue;
					case 490:
						goto IL_19E4;
					case 491:
						array9[4] = 105;
						num2 = 626;
						continue;
					case 492:
						num3 = 14 + 66;
						num2 = 57;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 77;
							continue;
						}
						continue;
					case 493:
						zero = IntPtr.Zero;
						num2 = 36;
						continue;
					case 494:
						num4 = 245 - 81;
						num2 = 438;
						continue;
					case 495:
						array3[num6 + 3] = array12[3];
						num2 = 363;
						continue;
					case 496:
						num3 = 189 - 63;
						num2 = 38;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 133;
							continue;
						}
						continue;
					case 497:
						array2[0] = 81 + 21;
						num2 = 14;
						continue;
					case 498:
						num53 += 8;
						num2 = 211;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 387;
							continue;
						}
						continue;
					case 499:
						num19 = array15.Length / 4;
						num2 = 364;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 193;
							continue;
						}
						continue;
					case 500:
						if (NV29kkR84hKfwDedo0.hmuUEvekZajpTdxmcgx(NV29kkR84hKfwDedo0.PnsYSsCB1h) != null)
						{
							num2 = 254;
							continue;
						}
						goto IL_2443;
					case 501:
						goto IL_4695;
					case 502:
						goto IL_2443;
					case 503:
						goto IL_1BF8;
					case 504:
						array[0] = 249 + 2;
						num2 = 255;
						continue;
					case 505:
						array2[14] = 12 + 64;
						num2 = 101;
						continue;
					case 506:
						array2[4] = 197 - 65;
						num2 = 368;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 17;
							continue;
						}
						continue;
					case 507:
					{
						bool flag = false;
						num2 = 565;
						continue;
					}
					case 508:
						udXKr1MEiU6cGbsjG = default(NV29kkR84hKfwDedo0.udXKr1MEiU6cGbsjG68);
						num2 = 651;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 32;
							continue;
						}
						continue;
					case 509:
						goto IL_17AF;
					case 510:
						array3[num6] = array12[0];
						num2 = 16;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 159;
							continue;
						}
						continue;
					case 511:
						num54 = NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb) - num55;
						num2 = 9;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 32;
							continue;
						}
						continue;
					case 512:
						num7 = 241 + 12;
						num2 = 663;
						continue;
					case 513:
					{
						string text = NV29kkR84hKfwDedo0.w5xsXoeGeMwQ6SGatFB(NV29kkR84hKfwDedo0.EJ7R5reJQHUUstQqiTN(), array16);
						num2 = 35;
						continue;
					}
					case 514:
						num5 = 134 - 44;
						num2 = 231;
						continue;
					case 515:
						goto IL_4481;
					case 516:
						if (num33 == 4)
						{
							num2 = 688;
							continue;
						}
						goto IL_3EDF;
					case 517:
						num5 = 167 - 55;
						num2 = 641;
						continue;
					case 518:
						array[4] = 160 - 53;
						num2 = 528;
						continue;
					case 519:
						if (!NV29kkR84hKfwDedo0.Ul3kaoBUTAigb4787Bf(NV29kkR84hKfwDedo0.FgdekUBwqGrBF5rdFqL(NV29kkR84hKfwDedo0.nbACg9BgZPN48gusEQn(NV29kkR84hKfwDedo0.ir8GTiBuxWCWb61ldRP(NV29kkR84hKfwDedo0.Xyy5WCBS56dSm5dsppq())), "__", 10U), IntPtr.Zero))
						{
							num2 = 191;
							continue;
						}
						goto IL_5070;
					case 520:
						array[13] = 230 - 76;
						num2 = 278;
						continue;
					case 521:
						array2[21] = (byte)num3;
						num2 = 488;
						continue;
					case 522:
						num3 = 78 + 57;
						num2 = 183;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 96;
							continue;
						}
						continue;
					case 523:
						num3 = 119 + 5;
						num2 = 545;
						continue;
					case 524:
					{
						uint num14;
						num24 += num14;
						num2 = 215;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 217;
							continue;
						}
						continue;
					}
					case 525:
						num3 = 154 - 51;
						num2 = 261;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 526;
							continue;
						}
						continue;
					case 526:
						array2[31] = (byte)num3;
						num2 = 157;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 382;
							continue;
						}
						continue;
					case 527:
						array9[7] = 116;
						num2 = 383;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 214;
							continue;
						}
						continue;
					case 528:
						num7 = 162 - 54;
						num2 = 259;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 596;
							continue;
						}
						continue;
					case 529:
						goto IL_1271;
					case 530:
						num5 = 236 - 78;
						num2 = 635;
						continue;
					case 531:
						if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() == 4)
						{
							num2 = 469;
							continue;
						}
						goto IL_296B;
					case 532:
						array3[num6 + 6] = array12[6];
						num2 = 105;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 104;
							continue;
						}
						continue;
					case 533:
						num7 = 169 + 1;
						num2 = 378;
						continue;
					case 534:
						goto IL_4C51;
					case 535:
						array6[5] = array5[2];
						num2 = 224;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 650;
							continue;
						}
						continue;
					case 536:
						array[12] = 100 + 62;
						num2 = 322;
						continue;
					case 537:
						array3[num11 + 2] = array4[2];
						num2 = 107;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 474;
							continue;
						}
						continue;
					case 538:
						num4 = 80 + 87;
						num2 = 673;
						continue;
					case 539:
						goto IL_12BD;
					case 540:
						array3[num6 + 2] = array12[2];
						num2 = 495;
						continue;
					case 541:
						array2[6] = 161 - 86;
						num2 = 627;
						continue;
					case 542:
						array2[5] = 119 + 54;
						num2 = 178;
						continue;
					case 543:
						goto IL_2D37;
					case 544:
						NV29kkR84hKfwDedo0.QNv1gXetZHO8XIJf8Uu(NV29kkR84hKfwDedo0.ypWn96eWqOMZxsqJ318(NV29kkR84hKfwDedo0.CZa5bReUy7QZPCi3EAS(NV29kkR84hKfwDedo0.JHUYpFPJpm)));
						num2 = 642;
						continue;
					case 545:
						array2[28] = (byte)num3;
						num2 = 336;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 117;
							continue;
						}
						continue;
					case 546:
						goto IL_4FC0;
					case 547:
						array17 = null;
						num2 = 696;
						continue;
					case 548:
						num7 = 86 + 89;
						num2 = 349;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 14;
							continue;
						}
						continue;
					case 549:
						array2[22] = (byte)num5;
						num2 = 317;
						continue;
					case 550:
						NV29kkR84hKfwDedo0.sbvYD1SKkd = NV29kkR84hKfwDedo0.nnMPGReNglJyDBWdJsv(NV29kkR84hKfwDedo0.efiY7MM34Y);
						num2 = 415;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 653;
							continue;
						}
						continue;
					case 551:
						array[11] = (byte)num7;
						num2 = 29;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 68;
							continue;
						}
						continue;
					case 552:
						array[7] = (byte)num7;
						num2 = 447;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 303;
							continue;
						}
						continue;
					case 553:
						goto IL_3111;
					case 554:
						goto IL_3E9E;
					case 555:
						num3 = 67 + 69;
						num2 = 26;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 597;
							continue;
						}
						continue;
					case 556:
						array[4] = (byte)num4;
						num2 = 664;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 687;
							continue;
						}
						continue;
					case 557:
						array2[29] = (byte)num5;
						num2 = 423;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 660;
							continue;
						}
						continue;
					case 558:
						num7 = 72 + 68;
						num2 = 1;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 24;
							continue;
						}
						continue;
					case 559:
						NV29kkR84hKfwDedo0.pNijJ5ehFXFqVGjPNxp(wqom9MMvIW0bAgnHNWb);
						num2 = 100;
						continue;
					case 560:
						array4 = NV29kkR84hKfwDedo0.LmZyF6eHOitsNhnTNQK(NV29kkR84hKfwDedo0.nnMPGReNglJyDBWdJsv(num20));
						num2 = 123;
						continue;
					case 561:
						goto IL_2F7F;
					case 562:
						goto IL_3CA1;
					case 563:
						array3[num6] = array11[0];
						num2 = 183;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 287;
							continue;
						}
						continue;
					case 564:
						array3[num6 + 7] = array11[7];
						num2 = 685;
						continue;
					case 565:
						goto IL_50F5;
					case 566:
						num21 = 0;
						num2 = 480;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 333;
							continue;
						}
						continue;
					case 567:
						array9[7] = 100;
						num2 = 103;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 20;
							continue;
						}
						continue;
					case 568:
						num16 = num21 * 4;
						num2 = 142;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 74;
							continue;
						}
						continue;
					case 569:
						array3[num11] = array11[0];
						num2 = 343;
						continue;
					case 570:
						num5 = 148 - 49;
						num2 = 701;
						continue;
					case 571:
						array16[4] = 105;
						num2 = 679;
						continue;
					case 572:
						if (NV29kkR84hKfwDedo0.vhIYfXd2ZB(intPtr6, 4, 4, ref num28) == 0)
						{
							num2 = 409;
							continue;
						}
						goto IL_4C51;
					case 573:
						array[5] = (byte)num4;
						num2 = 93;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 148;
							continue;
						}
						continue;
					case 574:
						goto IL_5256;
					case 575:
						num55 = 0;
						num2 = 70;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 500;
							continue;
						}
						continue;
					case 576:
						num4 = 242 - 80;
						num2 = 18;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 241;
							continue;
						}
						continue;
					case 577:
						NV29kkR84hKfwDedo0.i6hYjTo8lV = true;
						num2 = 186;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 190;
							continue;
						}
						continue;
					case 578:
						if (!NV29kkR84hKfwDedo0.i6hYjTo8lV)
						{
							goto Block_134;
						}
						goto IL_4F0A;
					case 579:
						array2[1] = 56 + 48;
						num2 = 402;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 379;
							continue;
						}
						continue;
					case 580:
						num4 = 148 - 75;
						num2 = 313;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 191;
							continue;
						}
						continue;
					case 581:
						array[9] = 171 + 30;
						num2 = 281;
						continue;
					case 582:
						array2[11] = (byte)num3;
						num2 = 295;
						continue;
					case 583:
						return;
					case 584:
						array2[1] = 197 - 65;
						num2 = 579;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 33;
							continue;
						}
						continue;
					case 585:
						num53 = 0;
						num2 = 117;
						continue;
					case 586:
						array16[3] = 74;
						num2 = 571;
						continue;
					case 587:
						num7 = 224 - 74;
						num2 = 686;
						continue;
					case 588:
						NV29kkR84hKfwDedo0.yHIYC1bbBE = false;
						num2 = 678;
						continue;
					case 589:
						array9[5] = 106;
						num2 = 293;
						continue;
					case 590:
						array3[num6 + 5] = array12[5];
						num2 = 532;
						continue;
					case 591:
						array[6] = (byte)num7;
						num2 = 671;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 697;
							continue;
						}
						continue;
					case 592:
						goto IL_4BEA;
					case 593:
						array[10] = (byte)num4;
						num2 = 195;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 89;
							continue;
						}
						continue;
					case 594:
						array3[num11 + 2] = array12[2];
						num2 = 574;
						continue;
					case 595:
						array2[5] = 210 - 70;
						num2 = 542;
						continue;
					case 596:
						array[4] = (byte)num7;
						num2 = 260;
						continue;
					case 597:
						array2[15] = (byte)num3;
						num2 = 218;
						continue;
					case 598:
						array2[25] = 122 - 95;
						num2 = 74;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 446;
							continue;
						}
						continue;
					case 599:
						if (array5 == null)
						{
							num2 = 465;
							continue;
						}
						goto IL_5982;
					case 600:
					{
						NV29kkR84hKfwDedo0.udXKr1MEiU6cGbsjG68 udXKr1MEiU6cGbsjG2;
						udXKr1MEiU6cGbsjG2.qiXMH0usd7 = false;
						num2 = 200;
						continue;
					}
					case 601:
						num3 = 179 - 59;
						num2 = 14;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 58;
							continue;
						}
						continue;
					case 602:
						goto IL_12D9;
					case 603:
						return;
					case 604:
						num37 = 0;
						num2 = 235;
						continue;
					case 605:
						array2[27] = (byte)num3;
						num2 = 13;
						continue;
					case 606:
					{
						uint num56 = num24;
						uint num57 = num24;
						uint num58 = 785396777U;
						uint num59 = 851326108U;
						uint num60 = num57;
						uint num61 = 1950741206U;
						uint num62 = 443419207U;
						uint num63 = ((num59 >> 6) | (num59 << 26)) ^ num61;
						uint num64 = num63 & 252645135U;
						num63 &= 4042322160U;
						num59 = (num63 >> 4) | (num64 << 4);
						num60 -= num61;
						num60 = 33939422U * (num60 & 63U) - (num60 >> 6);
						num58 = 62797463U * (num58 & 63U) - (num58 >> 6);
						num59 = 34753U * num59 + num61;
						num63 = num61 & 252645135U;
						num64 = num61 & 4042322160U;
						num63 = ((num63 >> 4) | (num64 << 4)) + num59;
						num61 = (num61 >> 14) | (num61 << 18);
						num62 ^= num59;
						num60 ^= num60 << 3;
						num60 += num58;
						num60 ^= num60 << 25;
						num60 += num61;
						num60 ^= num60 >> 23;
						num60 += num62;
						num60 = (((num60 << 3) - num58) ^ num58) + num60;
						num24 = num56 + (uint)num60;
						num2 = 124;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 21;
							continue;
						}
						continue;
					}
					case 607:
						goto IL_5297;
					case 608:
						array16[1] = 101;
						num2 = 347;
						continue;
					case 609:
						array2[22] = (byte)num3;
						num2 = 46;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 13;
							continue;
						}
						continue;
					case 610:
						array[1] = (byte)num7;
						num2 = 444;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 693;
							continue;
						}
						continue;
					case 611:
						array9[3] = 106;
						num2 = 491;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 16;
							continue;
						}
						continue;
					case 612:
						try
						{
							enumerator = NV29kkR84hKfwDedo0.TSnkDcBx17MYw0rFeLg(NV29kkR84hKfwDedo0.vtnGXdBRCk1dm0Xhujo(process));
							int num65 = 0;
							if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
							{
								num65 = 0;
							}
							switch (num65)
							{
							default:
								try
								{
									for (;;)
									{
										IL_32DD:
										if (NV29kkR84hKfwDedo0.torpQrBV8jJowlu5Wt6(enumerator))
										{
											goto IL_3304;
										}
										int num66 = 4;
										int num67 = num66;
										for (;;)
										{
											IL_3290:
											switch (num67)
											{
											case 1:
												if (intPtr.ToInt64() != NV29kkR84hKfwDedo0.efiY7MM34Y)
												{
													goto IL_32DD;
												}
												num67 = 0;
												if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
												{
													num67 = 0;
													continue;
												}
												continue;
											case 2:
												goto IL_3304;
											case 3:
												goto IL_32DD;
											case 4:
												goto IL_3340;
											case 5:
												goto IL_3331;
											}
											num55 = 0;
											num67 = 5;
										}
										IL_3304:
										intPtr = NV29kkR84hKfwDedo0.nbACg9BgZPN48gusEQn((ProcessModule)NV29kkR84hKfwDedo0.McNfFQBys3F6yTNXWUD(enumerator));
										num67 = 1;
										if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
										{
											num67 = 1;
											goto IL_3290;
										}
										goto IL_3290;
									}
									IL_3331:
									IL_3340:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num68 = 0;
									if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
									{
										num68 = 0;
									}
									for (;;)
									{
										switch (num68)
										{
										case 0:
											goto IL_33A6;
										case 1:
											goto IL_3386;
										case 2:
											goto IL_33C7;
										case 3:
											break;
										default:
											goto IL_33A6;
										}
										IL_3395:
										NV29kkR84hKfwDedo0.PfZfcEBp90mPiaZ1KkX(disposable);
										num68 = 2;
										continue;
										IL_33A6:
										if (disposable != null)
										{
											goto IL_3395;
										}
										num68 = 1;
										if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
										{
											num68 = 1;
										}
									}
									IL_3386:
									IL_33C7:;
								}
								break;
							case 1:
								break;
							}
							goto IL_69F5;
						}
						catch
						{
							int num69 = 0;
							if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
							{
								num69 = 0;
							}
							switch (num69)
							{
							default:
								goto IL_69F5;
							}
						}
						goto IL_3423;
					case 613:
						NV29kkR84hKfwDedo0.vhIYfXd2ZB(intPtr9, 4, num28, ref num28);
						num2 = 375;
						continue;
					case 614:
						goto IL_2A99;
					case 615:
						array2 = new byte[32];
						num2 = 497;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 466;
							continue;
						}
						continue;
					case 616:
					{
						byte[] array7 = NV29kkR84hKfwDedo0.nFTgWTBZhyTFSceD2E9(wqom9MMvIW0bAgnHNWb, (int)NV29kkR84hKfwDedo0.BuBJGlBK8Z1Dl0yH18r(NV29kkR84hKfwDedo0.F5rEPABDYpV4Wm4VXpd(wqom9MMvIW0bAgnHNWb)));
						num2 = 615;
						continue;
					}
					case 617:
						array[10] = (byte)num7;
						num2 = 489;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 138;
							continue;
						}
						continue;
					case 618:
						num5 = 239 - 79;
						num2 = 554;
						continue;
					case 619:
						num10 <<= 8;
						num2 = 503;
						continue;
					case 620:
						array2[15] = (byte)num3;
						num2 = 471;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 462;
							continue;
						}
						continue;
					case 621:
						NV29kkR84hKfwDedo0.NT0k37B9VyaqkZFNsky();
						num2 = 486;
						continue;
					case 622:
						array2[26] = (byte)num5;
						num2 = 16;
						continue;
					case 623:
						goto IL_1D2E;
					case 624:
					{
						byte[] array7;
						array15 = array7;
						num2 = 258;
						continue;
					}
					case 625:
						num4 = 122 + 58;
						num2 = 681;
						continue;
					case 626:
						array9[5] = 116;
						num2 = 303;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 64;
							continue;
						}
						continue;
					case 627:
						array2[7] = 86 + 63;
						num2 = 92;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 85;
							continue;
						}
						continue;
					case 628:
						goto IL_5B63;
					case 629:
						array[11] = 16 + 121;
						num2 = 482;
						continue;
					case 630:
						if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() == 4)
						{
							goto IL_20EF;
						}
						num2 = 453;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 64;
							continue;
						}
						continue;
					case 631:
						goto IL_20EF;
					case 632:
						NV29kkR84hKfwDedo0.Ak7QPXBGdAD8AhTtxLZ(new IntPtr((void*)(&num18)), 0, IntPtr.Zero);
						num2 = 81;
						continue;
					case 633:
						num5 = 30 + 108;
						num2 = 401;
						continue;
					case 634:
						array[6] = (byte)num4;
						num2 = 270;
						continue;
					case 635:
						array2[27] = (byte)num5;
						num2 = 155;
						continue;
					case 636:
						goto IL_1E91;
					case 637:
						goto IL_3887;
					case 638:
						num5 = 24 - 0;
						num2 = 215;
						continue;
					case 639:
						num70++;
						num2 = 253;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 386;
							continue;
						}
						continue;
					case 640:
						array3[num11 + 1] = array4[1];
						num2 = 537;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 428;
							continue;
						}
						continue;
					case 641:
						array2[4] = (byte)num5;
						num2 = 238;
						continue;
					case 642:
						array19 = null;
						num2 = 630;
						continue;
					case 643:
						array2[28] = 206 - 68;
						num2 = 316;
						continue;
					case 644:
						goto IL_5ABF;
					case 645:
						try
						{
							NV29kkR84hKfwDedo0.cD4YVHlDx5 = (NV29kkR84hKfwDedo0.l1T8AmMhyV3o44qdUZy)NV29kkR84hKfwDedo0.di5JKxee35TmJLDSxMP(new IntPtr(num20), NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0.l1T8AmMhyV3o44qdUZy).TypeHandle));
							int num71 = 0;
							if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
							{
								num71 = 0;
							}
							switch (num71)
							{
							default:
								goto IL_61EB;
							}
						}
						catch
						{
							int num72 = 0;
							if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
							{
								num72 = 0;
							}
							switch (num72)
							{
							default:
								try
								{
									Delegate @delegate = NV29kkR84hKfwDedo0.di5JKxee35TmJLDSxMP(new IntPtr(num20), NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0.l1T8AmMhyV3o44qdUZy).TypeHandle));
									int num73 = 1;
									if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
									{
										num73 = 1;
									}
									for (;;)
									{
										switch (num73)
										{
										case 1:
											NV29kkR84hKfwDedo0.cD4YVHlDx5 = (NV29kkR84hKfwDedo0.l1T8AmMhyV3o44qdUZy)NV29kkR84hKfwDedo0.iOHNaQe0Z6N9LTPj6B2(NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0.l1T8AmMhyV3o44qdUZy).TypeHandle), NV29kkR84hKfwDedo0.CZa5bReUy7QZPCi3EAS(@delegate));
											num73 = 0;
											if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
											{
												num73 = 0;
												continue;
											}
											continue;
										}
										break;
									}
								}
								catch
								{
									int num74 = 0;
									if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
									{
										num74 = 0;
									}
									switch (num74)
									{
									}
								}
								break;
							case 1:
								break;
							}
							goto IL_61EB;
						}
						goto IL_4695;
					case 646:
						array11 = NV29kkR84hKfwDedo0.LmZyF6eHOitsNhnTNQK(NV29kkR84hKfwDedo0.a0dYctZEET.ToInt32());
						num2 = 75;
						continue;
					case 647:
						num5 = 78 + 110;
						num2 = 23;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 88;
							continue;
						}
						continue;
					case 648:
						goto IL_1A4C;
					case 649:
						num4 = 137 - 45;
						num2 = 634;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 262;
							continue;
						}
						continue;
					case 650:
						array6[7] = array5[3];
						num2 = 230;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 448;
							continue;
						}
						continue;
					case 651:
					{
						byte[] array13;
						udXKr1MEiU6cGbsjG.JykMsC4DBr = array13;
						num2 = 110;
						continue;
					}
					case 652:
						array2[30] = (byte)num5;
						num2 = 275;
						continue;
					case 653:
						goto IL_1B93;
					case 654:
					{
						bool flag = true;
						num2 = 140;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 66;
							continue;
						}
						continue;
					}
					case 655:
						goto IL_23A2;
					case 656:
						num75 = num24 ^ num10;
						num2 = 604;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 474;
							continue;
						}
						continue;
					case 657:
						array2[17] = (byte)num3;
						num2 = 228;
						continue;
					case 658:
						array[11] = 182 - 60;
						num2 = 629;
						continue;
					case 659:
						if (NV29kkR84hKfwDedo0.vhIYfXd2ZB(intPtr9, 4, 4, ref num28) != 0)
						{
							num2 = 344;
							if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
							{
								num2 = 222;
								continue;
							}
							continue;
						}
						break;
					case 660:
						array2[29] = 107 + 37;
						num2 = 45;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 172;
							continue;
						}
						continue;
					case 661:
						num12 = (long)NV29kkR84hKfwDedo0.F5NM5peXLC6s49pnp3W(intPtr2);
						num2 = 655;
						continue;
					case 662:
						array[3] = 224 - 74;
						num2 = 337;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 396;
							continue;
						}
						continue;
					case 663:
						array[15] = (byte)num7;
						num2 = 110;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
						{
							num2 = 354;
							continue;
						}
						continue;
					case 664:
						array2[23] = 154 - 51;
						num2 = 276;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 691;
							continue;
						}
						continue;
					case 665:
						num10 = 0U;
						num2 = 165;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 175;
							continue;
						}
						continue;
					case 666:
						num3 = 89 + 74;
						num2 = 605;
						continue;
					case 667:
						num3 = 119 + 41;
						num2 = 96;
						continue;
					case 668:
						num26++;
						num2 = 357;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 158;
							continue;
						}
						continue;
					case 669:
						NV29kkR84hKfwDedo0.Vh8LjjB0aQhRdutmqwL();
						num2 = 462;
						continue;
					case 670:
						num3 = 245 - 81;
						num2 = 271;
						continue;
					case 671:
						num7 = 210 - 109;
						num2 = 552;
						continue;
					case 672:
						array2[25] = 65 + 48;
						num2 = 312;
						continue;
					case 673:
						array[12] = (byte)num4;
						num2 = 558;
						continue;
					case 674:
						NV29kkR84hKfwDedo0.FTLcMBe3L8LaLNABOIG(array10, 0, array10.Length);
						num2 = 30;
						continue;
					case 675:
						array2[26] = (byte)num5;
						num2 = 259;
						continue;
					case 676:
						goto IL_66CE;
					case 677:
						goto IL_2E51;
					case 678:
					{
						int num13;
						NV29kkR84hKfwDedo0.vhIYfXd2ZB(new IntPtr(num12), NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t(), 64, ref num13);
						num2 = 143;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 29;
							continue;
						}
						continue;
					}
					case 679:
						array16[5] = 116;
						num2 = 140;
						if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 513;
							continue;
						}
						continue;
					case 680:
						array2[18] = (byte)num5;
						num2 = 628;
						continue;
					case 681:
						array[5] = (byte)num4;
						num2 = 55;
						continue;
					case 682:
						array2[3] = (byte)num5;
						num2 = 66;
						continue;
					case 683:
						array2[13] = 208 - 69;
						num2 = 442;
						continue;
					case 684:
						goto IL_5E23;
					case 685:
						num6 = 18;
						num2 = 335;
						continue;
					case 686:
						array[3] = (byte)num7;
						num2 = 509;
						if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
						{
							num2 = 442;
							continue;
						}
						continue;
					case 687:
						num4 = 150 - 119;
						num2 = 355;
						continue;
					case 688:
					{
						object obj2 = NV29kkR84hKfwDedo0.dESGYEeq5lDMDAQl71E();
						NV29kkR84hKfwDedo0.GtFHwje4ZNHYEX8ysGc(obj2, CipherMode.CBC);
						ICryptoTransform cryptoTransform = NV29kkR84hKfwDedo0.KW3DpHemoQf2D4wRxvF(obj2, array10, array6);
						num2 = 674;
						continue;
					}
					case 689:
						num4 = 123 + 31;
						num2 = 2;
						continue;
					case 690:
						num76 <<= 8;
						num2 = 498;
						continue;
					case 691:
						goto IL_4F27;
					case 692:
						goto IL_396F;
					case 693:
						array[1] = 48 + 23;
						num2 = 337;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 174;
							continue;
						}
						continue;
					case 694:
						array9[10] = 108;
						num2 = 164;
						continue;
					case 695:
						array2[26] = 243 - 81;
						num2 = 78;
						continue;
					case 696:
						wqom9MMvIW0bAgnHNWb = new NV29kkR84hKfwDedo0.WQOm9MMvIW0bAgnHNWb(new MemoryStream(array8));
						num2 = 244;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 31;
							continue;
						}
						continue;
					case 697:
						goto IL_11CB;
					case 698:
						array3[num6 + 5] = array11[5];
						num2 = 112;
						continue;
					case 699:
						num3 = 118 + 74;
						num2 = 118;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 101;
							continue;
						}
						continue;
					case 700:
						array12 = NV29kkR84hKfwDedo0.HlD1j2eyKm4OSmPkDsZ(intPtr4.ToInt64());
						num2 = 97;
						continue;
					case 701:
						array2[24] = (byte)num5;
						num2 = 297;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 103;
							continue;
						}
						continue;
					case 702:
						array2[2] = 146 - 48;
						num2 = 130;
						continue;
					case 703:
						num77 = array8.Length / 8;
						num2 = 367;
						continue;
					case 704:
						if (NV29kkR84hKfwDedo0.hmuUEvekZajpTdxmcgx(NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0).TypeHandle).Assembly) == null)
						{
							num2 = 236;
							continue;
						}
						goto IL_4F97;
					case 705:
						goto IL_3EDF;
					case 706:
						array[0] = (byte)num4;
						num2 = 494;
						if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
						{
							num2 = 469;
							continue;
						}
						continue;
					default:
						goto IL_5711;
					}
					NV29kkR84hKfwDedo0.vhIYfXd2ZB(intPtr9, 4, 8, ref num28);
					num2 = 138;
					continue;
					IL_1201:
					byte* ptr2;
					*(long*)(ptr2 + num70 * 8) ^= 2076983238L;
					num2 = 639;
					continue;
					IL_1F9C:
					if (num70 >= num77)
					{
						num2 = 547;
						continue;
					}
					goto IL_1201;
					IL_1271:
					ptr2 = null;
					num2 = 375;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 436;
						continue;
					}
					continue;
					IL_12D9:
					if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() != 4)
					{
						goto IL_4D0B;
					}
					num2 = 327;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 372;
						continue;
					}
					continue;
					IL_17AF:
					array[3] = 210 - 70;
					num2 = 68;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 352;
						continue;
					}
					continue;
					IL_188D:
					num12 = NV29kkR84hKfwDedo0.dupglre90uDwgkl3Mn6(intPtr2);
					num2 = 120;
					continue;
					IL_18EB:
					num24 = num24;
					num2 = 349;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 606;
						continue;
					}
					continue;
					IL_1921:
					intPtr = NV29kkR84hKfwDedo0.JHID6LeMEj0q7akLDSR(NV29kkR84hKfwDedo0.SoYtpTeYnmfQnAd617X(NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0).TypeHandle).Assembly)[0]);
					num2 = 26;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
					{
						num2 = 26;
						continue;
					}
					continue;
					IL_50F5:
					if (NV29kkR84hKfwDedo0.gMmq4ceseRog0s0TZ99(NV29kkR84hKfwDedo0.F5rEPABDYpV4Wm4VXpd(wqom9MMvIW0bAgnHNWb)) >= NV29kkR84hKfwDedo0.BuBJGlBK8Z1Dl0yH18r(NV29kkR84hKfwDedo0.F5rEPABDYpV4Wm4VXpd(wqom9MMvIW0bAgnHNWb)) - 1L)
					{
						goto IL_1921;
					}
					num2 = 313;
					if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 511;
						continue;
					}
					continue;
					IL_19E4:
					num31 = 0;
					num2 = 58;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 84;
						continue;
					}
					continue;
					IL_1A4C:
					num29 = 0;
					num2 = 149;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 111;
						continue;
					}
					continue;
					IL_1BF8:
					num10 |= (uint)array15[array15.Length - (1 + num26)];
					num2 = 668;
					continue;
					IL_4997:
					if (num26 > 0)
					{
						num2 = 619;
						continue;
					}
					goto IL_1BF8;
					IL_2A99:
					if (num26 < num25)
					{
						goto IL_4997;
					}
					num2 = 19;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 385;
						continue;
					}
					continue;
					IL_1D2E:
					num2 = 18;
					if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 454;
						continue;
					}
					continue;
					IL_57C1:
					if (NV29kkR84hKfwDedo0.iYxMP3eo0RSht5en4jX(NV29kkR84hKfwDedo0.lHbm01egpO2khojuxj1(NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0).TypeHandle).Assembly)).Length == 2)
					{
						goto Block_232;
					}
					goto IL_1D2E;
					IL_4F97:
					if (NV29kkR84hKfwDedo0.IshPQTeTFYGGDl6H0Xk(NV29kkR84hKfwDedo0.hmuUEvekZajpTdxmcgx(NV29kkR84hKfwDedo0.f5JtsYeIXbZjyeYCUto(typeof(NV29kkR84hKfwDedo0).TypeHandle).Assembly)) > 0)
					{
						num2 = 669;
						continue;
					}
					goto IL_1D2E;
					IL_1D49:
					NV29kkR84hKfwDedo0.DhW367BXUowLGtjdKhD(array3, 0, intPtr7, array3.Length);
					num2 = 314;
					if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 588;
						continue;
					}
					continue;
					IL_20EF:
					byte[] array21 = new byte[30];
					NV29kkR84hKfwDedo0.X1B4M5e8SBgmcuBdnhH(array21, fieldof(<PrivateImplementationDetails>{DD2913A0-494D-4B07-931B-14A029D7A590}.D5B7247C497788CF0031CEB06E3DF77A45FEF59F1E49633DC7159816D64759B5).FieldHandle);
					array19 = array21;
					num2 = 99;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 71;
						continue;
					}
					continue;
					IL_23A2:
					NV29kkR84hKfwDedo0.q3ANinBIN6RLS8DIqJ6(intPtr2, 0);
					num2 = 299;
					continue;
					IL_2443:
					num55 = 7680;
					num2 = 249;
					continue;
					IL_2814:
					NV29kkR84hKfwDedo0.sGAOI5ebqRQBV8vO5fj(intPtr5);
					num2 = 333;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 157;
						continue;
					}
					continue;
					IL_3CA1:
					if (NV29kkR84hKfwDedo0.gMmq4ceseRog0s0TZ99(NV29kkR84hKfwDedo0.F5rEPABDYpV4Wm4VXpd(wqom9MMvIW0bAgnHNWb)) >= NV29kkR84hKfwDedo0.BuBJGlBK8Z1Dl0yH18r(NV29kkR84hKfwDedo0.F5rEPABDYpV4Wm4VXpd(wqom9MMvIW0bAgnHNWb)) - 1L)
					{
						goto IL_2814;
					}
					num2 = 298;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 45;
						continue;
					}
					continue;
					IL_296B:
					intPtr = NV29kkR84hKfwDedo0.JHID6LeMEj0q7akLDSR(NV29kkR84hKfwDedo0.SoYtpTeYnmfQnAd617X(NV29kkR84hKfwDedo0.PnsYSsCB1h)[0]);
					num2 = 346;
					continue;
					IL_2B1B:
					num21++;
					num2 = 146;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 32;
						continue;
					}
					continue;
					IL_2E90:
					NV29kkR84hKfwDedo0.BZKuhLevCWlEWefVsp8(intPtr9, NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb));
					num2 = 402;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 613;
						continue;
					}
					continue;
					IL_3092:
					if (num37 > 0)
					{
						num2 = 690;
						continue;
					}
					goto IL_5F6E;
					IL_41AA:
					if (num37 >= num25)
					{
						num2 = 115;
						continue;
					}
					goto IL_3092;
					IL_3111:
					num23 = num21 % num39;
					num2 = 568;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
					{
						num2 = 500;
						continue;
					}
					continue;
					IL_4B3D:
					if (num21 >= num19)
					{
						num2 = 561;
						continue;
					}
					goto IL_3111;
					IL_3132:
					if (num78 >= num38)
					{
						num2 = 380;
						continue;
					}
					IL_3145:
					intPtr9 = new IntPtr(num30 + (long)NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb) - (long)num55);
					num2 = 448;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 659;
						continue;
					}
					continue;
					IL_3469:
					num2 = 612;
					continue;
					IL_3526:
					num20 = NV29kkR84hKfwDedo0.dupglre90uDwgkl3Mn6(new IntPtr(num12));
					num2 = 692;
					continue;
					IL_368B:
					if (num9 >= num38)
					{
						num2 = 209;
						continue;
					}
					goto IL_3AB6;
					IL_3730:
					wqom9MMvIW0bAgnHNWb = new NV29kkR84hKfwDedo0.WQOm9MMvIW0bAgnHNWb(NV29kkR84hKfwDedo0.HmuGjkB7Qt11CXeJXmR(NV29kkR84hKfwDedo0.PnsYSsCB1h, "KhjIgy43cRvuigjHpB.OepeVAmV4TfsTCN8vV"));
					num2 = 470;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 380;
						continue;
					}
					continue;
					IL_5070:
					if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() == 4)
					{
						num2 = 37;
						continue;
					}
					goto IL_3730;
					IL_38FD:
					intPtr7 = NV29kkR84hKfwDedo0.Cfvv0ceFWaYB4iIe77j(IntPtr.Zero, (uint)array19.Length, 4096U, 64U);
					num2 = 461;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 278;
						continue;
					}
					continue;
					IL_396F:
					process = NV29kkR84hKfwDedo0.Xyy5WCBS56dSm5dsppq();
					num2 = 434;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 299;
						continue;
					}
					continue;
					IL_3AB6:
					intPtr6 = new IntPtr(NV29kkR84hKfwDedo0.fK7Y1hjYYs + (long)NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb) - (long)num55);
					num2 = 572;
					continue;
					IL_3CDB:
					NV29kkR84hKfwDedo0.Ad7B0KeiiYtGS0V0Q34(NV29kkR84hKfwDedo0.cD4YVHlDx5);
					num2 = 106;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 315;
						continue;
					}
					continue;
					IL_3E61:
					num22 = (uint)num16;
					num2 = 524;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 95;
						continue;
					}
					continue;
					IL_3EDF:
					if (num33 == 1)
					{
						num2 = 405;
						continue;
					}
					num78 = 0;
					num2 = 1;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 4;
						continue;
					}
					continue;
					IL_449E:
					if (num31 >= num32)
					{
						num2 = 388;
						continue;
					}
					goto IL_543A;
					IL_44EE:
					array16 = new byte[6];
					num2 = 222;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 49;
						continue;
					}
					continue;
					IL_4695:
					num5 = 95 + 61;
					num2 = 62;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
					{
						num2 = 56;
						continue;
					}
					continue;
					IL_495F:
					array9[6] = 105;
					num2 = 527;
					continue;
					IL_4BEA:
					if (array17.Length != 0)
					{
						goto IL_5031;
					}
					num2 = 456;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 176;
						continue;
					}
					continue;
					IL_4D0B:
					num6 = 2;
					num2 = 563;
					continue;
					IL_4EE5:
					if (num29 < array6.Length)
					{
						goto IL_5E5C;
					}
					num2 = 349;
					if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 624;
						continue;
					}
					continue;
					IL_4F0A:
					NV29kkR84hKfwDedo0.Vh8LjjB0aQhRdutmqwL();
					num2 = 56;
					continue;
					IL_4FC0:
					array9 = new byte[10];
					num2 = 64;
					continue;
					IL_5031:
					ptr2 = &array17[0];
					num2 = 684;
					continue;
					IL_5321:
					array11 = NV29kkR84hKfwDedo0.HlD1j2eyKm4OSmPkDsZ(NV29kkR84hKfwDedo0.a0dYctZEET.ToInt64());
					num2 = 700;
					continue;
					IL_5711:
					if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() == 4)
					{
						num2 = 646;
						continue;
					}
					goto IL_5321;
					IL_543A:
					NV29kkR84hKfwDedo0.BZKuhLevCWlEWefVsp8(new IntPtr(intPtr8.ToInt64() + (long)(num31 * 4)), NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb));
					num2 = 213;
					continue;
					IL_5982:
					if (array5.Length == 0)
					{
						num2 = 648;
						continue;
					}
					goto IL_619D;
					IL_5994:
					NV29kkR84hKfwDedo0.rltY2KkjPv(intPtr5, intPtr6, NV29kkR84hKfwDedo0.LmZyF6eHOitsNhnTNQK(NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb)), 4U, out zero);
					num2 = 50;
					continue;
					IL_4C51:
					if (NV29kkR84hKfwDedo0.J9uZYxBo59JhCDIlI0t() == 4)
					{
						goto Block_194;
					}
					goto IL_5994;
					IL_5E23:
					num70 = 0;
					num2 = 154;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
					{
						num2 = 48;
						continue;
					}
					continue;
					IL_5E5C:
					array10[num29] ^= array6[num29];
					num2 = 197;
					continue;
					IL_5F6E:
					array14[num16 + num37] = (byte)((num75 & num76) >> num53);
					num2 = 365;
					if (NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 379;
						continue;
					}
					continue;
					IL_5FB4:
					NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
					num2 = 212;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() != null)
					{
						num2 = 174;
						continue;
					}
					continue;
					IL_610A:
					num15 = NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
					num2 = 65;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 2;
						continue;
					}
					continue;
					IL_619D:
					array6[1] = array5[0];
					num2 = 323;
					continue;
					IL_61EB:
					IntPtr zero2 = IntPtr.Zero;
					num2 = 123;
					if (NV29kkR84hKfwDedo0.B1V885BddT5burRHU90() == null)
					{
						num2 = 194;
						continue;
					}
					continue;
					IL_66CE:
					NV29kkR84hKfwDedo0.vhIYfXd2ZB(intPtr6, 4, num28, ref num28);
					num2 = 398;
					continue;
					IL_69F5:
					NV29kkR84hKfwDedo0.cD4YVHlDx5 = null;
					num2 = 645;
					if (!NV29kkR84hKfwDedo0.QTMJkHBbZk4xFbWC4LT())
					{
						num2 = 619;
					}
				}
				IL_0DD6:
				array2[22] = (byte)num5;
				num = 399;
				continue;
				IL_0EAB:
				array2[29] = (byte)num5;
				num = 381;
				continue;
				IL_108D:
				array2[4] = 224 - 74;
				num = 223;
				continue;
				IL_118B:
				num3 = 217 - 72;
				num = 122;
				continue;
				IL_11CB:
				num4 = 126 - 100;
				num = 91;
				continue;
				IL_12BD:
				array2[17] = (byte)num3;
				num = 136;
				continue;
				IL_18A0:
				array[7] = 197 - 65;
				num = 459;
				continue;
				IL_1B93:
				array9 = new byte[12];
				num = 31;
				continue;
				IL_1C3C:
				array2[14] = 68 + 62;
				num = 410;
				continue;
				IL_1C5F:
				array[0] = 209 - 69;
				num = 404;
				continue;
				IL_1DDB:
				intPtr4 = NV29kkR84hKfwDedo0.cd08oSeSvSpTKx0Dq9W(NV29kkR84hKfwDedo0.JHUYpFPJpm);
				num = 637;
				continue;
				IL_1E91:
				enumerator = NV29kkR84hKfwDedo0.TSnkDcBx17MYw0rFeLg(NV29kkR84hKfwDedo0.vtnGXdBRCk1dm0Xhujo(NV29kkR84hKfwDedo0.Xyy5WCBS56dSm5dsppq()));
				num = 362;
				continue;
				IL_200E:
				num12 = 0L;
				num = 426;
				continue;
				IL_21A5:
				array2[11] = (byte)num5;
				num = 227;
				continue;
				IL_2329:
				array3[num11] = array4[0];
				num = 640;
				continue;
				IL_2427:
				array2[9] = (byte)num5;
				num = 369;
				continue;
				IL_2519:
				array2[12] = (byte)num3;
				num = 406;
				continue;
				IL_256C:
				array[9] = 74 + 109;
				num = 87;
				continue;
				IL_29EE:
				NV29kkR84hKfwDedo0.vhIYfXd2ZB(intPtr8, num32 * 4, 8, ref num28);
				num = 340;
				continue;
				IL_2A7D:
				array2[30] = (byte)num5;
				num = 188;
				continue;
				IL_2B53:
				num7 = 201 + 25;
				num = 247;
				continue;
				IL_2CD2:
				num5 = 60 + 111;
				num = 607;
				continue;
				IL_2D11:
				array3[num6 + 7] = array4[7];
				num = 476;
				continue;
				IL_2D37:
				array2[6] = 35 + 119;
				num = 358;
				continue;
				IL_2E51:
				NV29kkR84hKfwDedo0.OIsub6edCIGG1XSUgtN(NV29kkR84hKfwDedo0.rO9Yzeurhb, num30 + (long)num54, udXKr1MEiU6cGbsjG);
				num = 174;
				continue;
				IL_2F7F:
				array8 = array14;
				num = 703;
				continue;
				IL_3013:
				array4 = null;
				num = 48;
				continue;
				IL_307B:
				num38 = NV29kkR84hKfwDedo0.r4Z69GereDnjUFUvKFN(wqom9MMvIW0bAgnHNWb);
				num = 393;
				continue;
				IL_3423:
				num5 = 162 + 55;
				num = 422;
				continue;
				IL_369E:
				intPtr8 = new IntPtr(NV29kkR84hKfwDedo0.fK7Y1hjYYs + (long)num34 - (long)num55);
				num = 370;
				continue;
				IL_386A:
				num7 = 99 - 63;
				num = 44;
				continue;
				IL_3887:
				num20 = 0L;
				num = 419;
				continue;
				IL_3AFE:
				num76 = 255U;
				num = 585;
				continue;
				Block_134:
				num = 577;
				continue;
				IL_3C05:
				NV29kkR84hKfwDedo0.Vh8LjjB0aQhRdutmqwL();
				num = 583;
				continue;
				IL_3D20:
				num3 = 102 - 89;
				num = 225;
				continue;
				IL_3DE5:
				num22 = 0U;
				num = 566;
				continue;
				IL_3E9E:
				array2[17] = (byte)num5;
				num = 501;
				continue;
				IL_3F44:
				num78++;
				num = 185;
				continue;
				IL_413E:
				NV29kkR84hKfwDedo0.q3ANinBIN6RLS8DIqJ6(new IntPtr((void*)(&num18)), 0);
				num = 276;
				continue;
				Block_169:
				num = 519;
				continue;
				IL_4481:
				num5 = 171 - 57;
				num = 214;
				continue;
				IL_49A9:
				array2[18] = 53 + 72;
				num = 644;
				continue;
				Block_194:
				num = 80;
				continue;
				IL_4D30:
				num4 = 77 + 38;
				num = 706;
				continue;
				IL_4F27:
				num5 = 85 - 48;
				num = 210;
				continue;
				IL_50C1:
				num17 = num24 ^ num10;
				num = 221;
				continue;
				IL_5256:
				array3[num11 + 3] = array12[3];
				num = 272;
				continue;
				IL_5297:
				array2[20] = (byte)num5;
				num = 171;
				continue;
				IL_5396:
				array9[11] = 108;
				num = 49;
				continue;
				IL_53AB:
				num3 = 2 + 69;
				num = 7;
				continue;
				IL_5569:
				num4 = 119 + 117;
				num = 397;
				continue;
				IL_5661:
				array9[2] = 114;
				num = 611;
				continue;
				Block_231:
				num = 156;
				continue;
				IL_5759:
				num3 = 163 - 54;
				num = 620;
				continue;
				IL_578E:
				array[2] = (byte)num7;
				num = 350;
				continue;
				Block_232:
				num = 704;
				continue;
				IL_5ABF:
				num5 = 17 + 18;
				num = 392;
				continue;
				IL_5B63:
				array2[18] = 247 - 82;
				num = 492;
				continue;
				IL_5C9E:
				array2[16] = (byte)num3;
				num = 445;
				continue;
				IL_5CD2:
				array3[num6 + 4] = array4[4];
				num = 220;
				continue;
				IL_5DE8:
				array[2] = (byte)num4;
				num = 662;
				continue;
				IL_5E40:
				array2[2] = (byte)num5;
				num = 40;
				continue;
				IL_600D:
				array[5] = (byte)num7;
				num = 649;
				continue;
				IL_627A:
				array2[19] = (byte)num5;
				num = 86;
				continue;
				IL_6396:
				array9[1] = 115;
				num = 93;
				continue;
				IL_6504:
				num11 = 23;
				num = 47;
				continue;
				IL_6577:
				array[10] = (byte)num4;
				num = 301;
				continue;
				IL_6AA3:
				array[12] = (byte)num4;
				num = 538;
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000AC14 File Offset: 0x00008E14
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object brEYqVLVBR(object \u0020)
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

		// Token: 0x06000071 RID: 113
		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr YP0Y4BW9l9(string \u0020);

		// Token: 0x06000072 RID: 114
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		public static extern IntPtr aBoYm1TqD1(IntPtr \u0020, string \u0020);

		// Token: 0x06000073 RID: 115 RVA: 0x0000AD44 File Offset: 0x00008F44
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr JcIY6mH0AQ(IntPtr \u0020, object \u0020, uint \u0020)
		{
			if (NV29kkR84hKfwDedo0.KqdM3dlqhd == null)
			{
				NV29kkR84hKfwDedo0.KqdM3dlqhd = (NV29kkR84hKfwDedo0.IKfFhZMGS8qEk9unvW2)Marshal.GetDelegateForFunctionPointer(NV29kkR84hKfwDedo0.aBoYm1TqD1(NV29kkR84hKfwDedo0.xTuFFuFOZ(), "Find ".Trim() + "ResourceA"), typeof(NV29kkR84hKfwDedo0.IKfFhZMGS8qEk9unvW2));
			}
			return NV29kkR84hKfwDedo0.KqdM3dlqhd(\u0020, \u0020, \u0020);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000ADA0 File Offset: 0x00008FA0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr hxbYlUe9h8(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			if (NV29kkR84hKfwDedo0.qU1MYWl34o == null)
			{
				NV29kkR84hKfwDedo0.qU1MYWl34o = (NV29kkR84hKfwDedo0.wqX7eiMBLLOKHRkntF0)Marshal.GetDelegateForFunctionPointer(NV29kkR84hKfwDedo0.aBoYm1TqD1(NV29kkR84hKfwDedo0.xTuFFuFOZ(), "Virtual ".Trim() + "Alloc"), typeof(NV29kkR84hKfwDedo0.wqX7eiMBLLOKHRkntF0));
			}
			return NV29kkR84hKfwDedo0.qU1MYWl34o(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000ADFC File Offset: 0x00008FFC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int rltY2KkjPv(IntPtr \u0020, IntPtr \u0020, [In] [Out] byte[] \u0020, uint \u0020, out IntPtr \u0020)
		{
			if (NV29kkR84hKfwDedo0.WKIMM3xdpB == null)
			{
				NV29kkR84hKfwDedo0.WKIMM3xdpB = (NV29kkR84hKfwDedo0.qy3d1vMe3CrYdclWyfD)Marshal.GetDelegateForFunctionPointer(NV29kkR84hKfwDedo0.aBoYm1TqD1(NV29kkR84hKfwDedo0.xTuFFuFOZ(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(NV29kkR84hKfwDedo0.qy3d1vMe3CrYdclWyfD));
			}
			return NV29kkR84hKfwDedo0.WKIMM3xdpB(\u0020, \u0020, \u0020, \u0020, out \u0020);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000AE64 File Offset: 0x00009064
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int vhIYfXd2ZB(IntPtr \u0020, int \u0020, int \u0020, ref int \u0020)
		{
			if (NV29kkR84hKfwDedo0.IoGMk1JnJw == null)
			{
				NV29kkR84hKfwDedo0.IoGMk1JnJw = (NV29kkR84hKfwDedo0.kxaIVNMQN4mJIKgv3Dk)Marshal.GetDelegateForFunctionPointer(NV29kkR84hKfwDedo0.aBoYm1TqD1(NV29kkR84hKfwDedo0.xTuFFuFOZ(), "Virtual ".Trim() + "Protect"), typeof(NV29kkR84hKfwDedo0.kxaIVNMQN4mJIKgv3Dk));
			}
			return NV29kkR84hKfwDedo0.IoGMk1JnJw(\u0020, \u0020, \u0020, ref \u0020);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000AEC0 File Offset: 0x000090C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr oGpYh5URZP(uint \u0020, int \u0020, uint \u0020)
		{
			if (NV29kkR84hKfwDedo0.PEkMTJIdK9 == null)
			{
				NV29kkR84hKfwDedo0.PEkMTJIdK9 = (NV29kkR84hKfwDedo0.lpq3OsMX17Vxw4kn6qo)Marshal.GetDelegateForFunctionPointer(NV29kkR84hKfwDedo0.aBoYm1TqD1(NV29kkR84hKfwDedo0.xTuFFuFOZ(), "Open ".Trim() + "Process"), typeof(NV29kkR84hKfwDedo0.lpq3OsMX17Vxw4kn6qo));
			}
			return NV29kkR84hKfwDedo0.PEkMTJIdK9(\u0020, \u0020, \u0020);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000AF1C File Offset: 0x0000911C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int snCYOh9jNX(IntPtr \u0020)
		{
			if (NV29kkR84hKfwDedo0.vMNMrMOON8 == null)
			{
				NV29kkR84hKfwDedo0.vMNMrMOON8 = (NV29kkR84hKfwDedo0.ekCjpyM9xWGE1wvqOnM)Marshal.GetDelegateForFunctionPointer(NV29kkR84hKfwDedo0.aBoYm1TqD1(NV29kkR84hKfwDedo0.xTuFFuFOZ(), "Close ".Trim() + "Handle"), typeof(NV29kkR84hKfwDedo0.ekCjpyM9xWGE1wvqOnM));
			}
			return NV29kkR84hKfwDedo0.vMNMrMOON8(\u0020);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000AF78 File Offset: 0x00009178
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr xTuFFuFOZ()
		{
			if (NV29kkR84hKfwDedo0.MrfMqJlgQn == IntPtr.Zero)
			{
				NV29kkR84hKfwDedo0.MrfMqJlgQn = NV29kkR84hKfwDedo0.YP0Y4BW9l9("kernel ".Trim() + "32.dll");
			}
			return NV29kkR84hKfwDedo0.MrfMqJlgQn;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000AFB4 File Offset: 0x000091B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] XCUYETO2hK(object \u0020)
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

		// Token: 0x0600007B RID: 123 RVA: 0x0000B020 File Offset: 0x00009220
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Stream QR5YHI7F3C()
		{
			return new MemoryStream();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000B028 File Offset: 0x00009228
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] HOyYshOvIv(object \u0020)
		{
			return ((MemoryStream)\u0020).ToArray();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000B038 File Offset: 0x00009238
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] auoYvp2aW1(object \u0020)
		{
			Stream stream = NV29kkR84hKfwDedo0.QR5YHI7F3C();
			SymmetricAlgorithm symmetricAlgorithm = NV29kkR84hKfwDedo0.Ua7aL4Mon();
			symmetricAlgorithm.Key = new byte[]
			{
				143, 254, 39, 64, 153, 72, 246, 214, 239, 81,
				250, 244, 28, 1, 224, 131, 82, 245, 172, 87,
				96, 26, 137, 109, 221, 20, 130, 236, 33, 49,
				182, 43
			};
			symmetricAlgorithm.IV = new byte[]
			{
				103, 96, 105, 205, 166, 81, 233, 199, 156, 102,
				37, 87, 70, 202, 171, 196
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(\u0020, 0, \u0020.Length);
			cryptoStream.Close();
			byte[] array = NV29kkR84hKfwDedo0.HOyYshOvIv(stream);
			Tk6GAUMu8Ylww9ieaCO.zdrBsQTXFV();
			return array;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000B0AC File Offset: 0x000092AC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] mvVYbHUutQ()
		{
			return null;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000B0BC File Offset: 0x000092BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] bdLYdgPu9a()
		{
			return null;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000B0CC File Offset: 0x000092CC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] gl7YIua1tG()
		{
			int length = "{11111-22222-20001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000B0EC File Offset: 0x000092EC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] JhhYNPtSgi()
		{
			int length = "{11111-22222-20001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000B10C File Offset: 0x0000930C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] whSYJ5FRSO()
		{
			return null;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000B11C File Offset: 0x0000931C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] VOkYGyie9B()
		{
			return null;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000B12C File Offset: 0x0000932C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] AHvYBgPJkT()
		{
			int length = "{11111-22222-40001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000B14C File Offset: 0x0000934C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] am6YeoVHRM()
		{
			int length = "{11111-22222-40001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000B16C File Offset: 0x0000936C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] b9fYQtaxkZ()
		{
			return null;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000B17C File Offset: 0x0000937C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] x61YXbaycW()
		{
			return null;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000B18C File Offset: 0x0000938C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object SO2DwclxNEomexMX5YR(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000B198 File Offset: 0x00009398
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void evr66qlyuYa39MBEEbB(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000B1A8 File Offset: 0x000093A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long I0qnarlipbK5VQGxAlG(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000B1B4 File Offset: 0x000093B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object WSr1BblWo5kW1bLRnHs(object A_0, int \u0020)
		{
			return A_0.zELMbs2fZi(\u0020);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000B1C4 File Offset: 0x000093C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void AkEuvbltSVJZIHxEkEP(object A_0)
		{
			A_0.GnKMNiUoYk();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000B1D0 File Offset: 0x000093D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void hlHPaOl83Bbpyb49VVW(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000B1DC File Offset: 0x000093DC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AGTTTAlFGSfmeh3Cr7V(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000B1E8 File Offset: 0x000093E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object osGjNMlnGybYQhUO4yE(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000B1F4 File Offset: 0x000093F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object jTvkr7ljITZIKhCMkpo()
		{
			return NV29kkR84hKfwDedo0.Ua7aL4Mon();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000B1FC File Offset: 0x000093FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void BQ0OkXladlWp73AEW74(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000B20C File Offset: 0x0000940C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object zrgbgnlPoQIlsMsHDoP(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000B220 File Offset: 0x00009420
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object LqVY24l1Fwg7f5cQiUU()
		{
			return NV29kkR84hKfwDedo0.QR5YHI7F3C();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000B228 File Offset: 0x00009428
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void dJLe5tlVe4h1H0ZKr7k(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000B240 File Offset: 0x00009440
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void UCGKnQlpDsfMawGRcl8(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000B24C File Offset: 0x0000944C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object jVOpq4l7FJelftcjyjg(object A_0)
		{
			return NV29kkR84hKfwDedo0.HOyYshOvIv(A_0);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000B258 File Offset: 0x00009458
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void cYccwSlDlTSwiLKPejf(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000B264 File Offset: 0x00009464
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object MJjgJwlCTDqUrBUwb6K(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000B270 File Offset: 0x00009470
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool exkvCblKEirgKdOa61r(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000B280 File Offset: 0x00009480
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool h5Wr0ll5gBVgmXBvmrr()
		{
			return null == null;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000B288 File Offset: 0x00009488
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object A15Ws4lRh0ahW4RywoL()
		{
			return null;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000B28C File Offset: 0x0000948C
		static int MIB2WmBvVXMjurrgj6d()
		{
			return 1;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000B290 File Offset: 0x00009490
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr q3ANinBIN6RLS8DIqJ6(IntPtr A_0, int A_1)
		{
			return Marshal.ReadIntPtr(A_0, A_1);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000B2A0 File Offset: 0x000094A0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int ipQSYsBNTvcanaI9B0j(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt32(A_0, A_1);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000B2B0 File Offset: 0x000094B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long oAF4gLBJHXCPoUqUxtO(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt64(A_0, A_1);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000B2C0 File Offset: 0x000094C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Ak7QPXBGdAD8AhTtxLZ(IntPtr A_0, int A_1, IntPtr A_2)
		{
			Marshal.WriteIntPtr(A_0, A_1, A_2);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000B2D4 File Offset: 0x000094D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void kLlJXLBBkyl3BavcAXt(IntPtr A_0, int A_1, int A_2)
		{
			Marshal.WriteInt32(A_0, A_1, A_2);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000B2E8 File Offset: 0x000094E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void t7ysJHBePkjjxMqmUpu(IntPtr A_0, int A_1, long A_2)
		{
			Marshal.WriteInt64(A_0, A_1, A_2);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000B2FC File Offset: 0x000094FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr p0Pp9IBQgKU5F6R37Wh(int A_0)
		{
			return Marshal.AllocCoTaskMem(A_0);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000B308 File Offset: 0x00009508
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void DhW367BXUowLGtjdKhD(object A_0, int A_1, IntPtr A_2, int A_3)
		{
			Marshal.Copy(A_0, A_1, A_2, A_3);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000B320 File Offset: 0x00009520
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void NT0k37B9VyaqkZFNsky()
		{
			NV29kkR84hKfwDedo0.fWdYkX5efK();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000B328 File Offset: 0x00009528
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Xyy5WCBS56dSm5dsppq()
		{
			return Process.GetCurrentProcess();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000B330 File Offset: 0x00009530
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object ir8GTiBuxWCWb61ldRP(object A_0)
		{
			return A_0.MainModule;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000B33C File Offset: 0x0000953C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr nbACg9BgZPN48gusEQn(object A_0)
		{
			return A_0.BaseAddress;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000B348 File Offset: 0x00009548
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr FgdekUBwqGrBF5rdFqL(IntPtr \u0020, object A_1, uint \u0020)
		{
			return NV29kkR84hKfwDedo0.JcIY6mH0AQ(\u0020, A_1, \u0020);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000B35C File Offset: 0x0000955C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Ul3kaoBUTAigb4787Bf(IntPtr A_0, IntPtr A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000B36C File Offset: 0x0000956C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Vh8LjjB0aQhRdutmqwL()
		{
			Tk6GAUMu8Ylww9ieaCO.zdrBsQTXFV();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000B374 File Offset: 0x00009574
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int J9uZYxBo59JhCDIlI0t()
		{
			return IntPtr.Size;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000B37C File Offset: 0x0000957C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type LnOPKuBLT5uq2lkhud7(object A_0, bool A_1)
		{
			return Type.GetType(A_0, A_1);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000B38C File Offset: 0x0000958C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool H8DAVqB55nxcQI7fdwM(Type A_0, Type A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000B39C File Offset: 0x0000959C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object vtnGXdBRCk1dm0Xhujo(object A_0)
		{
			return A_0.Modules;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000B3A8 File Offset: 0x000095A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object TSnkDcBx17MYw0rFeLg(object A_0)
		{
			return A_0.GetEnumerator();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000B3B4 File Offset: 0x000095B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object McNfFQBys3F6yTNXWUD(object A_0)
		{
			return ((IEnumerator)A_0).Current;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000B3C0 File Offset: 0x000095C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Iqox8WBido9wGw5OwMJ(object A_0)
		{
			return A_0.ModuleName;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000B3CC File Offset: 0x000095CC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object JnQ0NPBW9AXAjOJrPHI(object A_0)
		{
			return A_0.ToLower();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000B3D8 File Offset: 0x000095D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool tCxyy1BtA9kP4ainTSh(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000B3E8 File Offset: 0x000095E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object FO1nMoB85Mo36cpBfXN(object A_0)
		{
			return A_0.FileVersionInfo;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000B3F4 File Offset: 0x000095F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int r5hpJpBF83ooHImyy2C(object A_0)
		{
			return A_0.ProductMajorPart;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000B400 File Offset: 0x00009600
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int aYgLZeBnKXhAyxl9cco(object A_0)
		{
			return A_0.ProductMinorPart;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000B40C File Offset: 0x0000960C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int gNqcINBjJjHf2ejxbAx(object A_0)
		{
			return A_0.ProductBuildPart;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000B418 File Offset: 0x00009618
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int EMrf9OBaSl9eMurOvVe(object A_0)
		{
			return A_0.ProductPrivatePart;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000B424 File Offset: 0x00009624
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool X4XiJaBPtf6ZA8OOshn(object A_0, object A_1)
		{
			return A_0 >= A_1;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000B434 File Offset: 0x00009634
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool lj3SSxB1P12VehOyKFy(object A_0, object A_1)
		{
			return A_0 < A_1;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000B444 File Offset: 0x00009644
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool torpQrBV8jJowlu5Wt6(object A_0)
		{
			return ((IEnumerator)A_0).MoveNext();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000B450 File Offset: 0x00009650
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void PfZfcEBp90mPiaZ1KkX(object A_0)
		{
			((IDisposable)A_0).Dispose();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000B45C File Offset: 0x0000965C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object HmuGjkB7Qt11CXeJXmR(object A_0, object A_1)
		{
			return A_0.GetManifestResourceStream(A_1);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000B46C File Offset: 0x0000966C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object F5rEPABDYpV4Wm4VXpd(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000B478 File Offset: 0x00009678
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void vGTsdrBCTxgM8tOE9Dx(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000B488 File Offset: 0x00009688
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long BuBJGlBK8Z1Dl0yH18r(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000B494 File Offset: 0x00009694
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object nFTgWTBZhyTFSceD2E9(object A_0, int \u0020)
		{
			return A_0.zELMbs2fZi(\u0020);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000B4A4 File Offset: 0x000096A4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Q41duwBc418TjocwOgd(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000B4B0 File Offset: 0x000096B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object KAMGk0BAZGjyi6HAj0E(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000B4BC File Offset: 0x000096BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object oVT1gvBzS2TtPWByUgB(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000B4C8 File Offset: 0x000096C8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void FTLcMBe3L8LaLNABOIG(object A_0, int A_1, int A_2)
		{
			Array.Clear(A_0, A_1, A_2);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000B4DC File Offset: 0x000096DC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object SoYtpTeYnmfQnAd617X(object A_0)
		{
			return A_0.GetModules();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000B4E8 File Offset: 0x000096E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr JHID6LeMEj0q7akLDSR(object A_0)
		{
			return Marshal.GetHINSTANCE(A_0);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000B4F4 File Offset: 0x000096F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object hmuUEvekZajpTdxmcgx(object A_0)
		{
			return A_0.Location;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000B500 File Offset: 0x00009700
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int IshPQTeTFYGGDl6H0Xk(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000B50C File Offset: 0x0000970C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int r4Z69GereDnjUFUvKFN(object A_0)
		{
			return A_0.t6pMIY1ZoG();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000B518 File Offset: 0x00009718
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object dESGYEeq5lDMDAQl71E()
		{
			return NV29kkR84hKfwDedo0.Ua7aL4Mon();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000B520 File Offset: 0x00009720
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void GtFHwje4ZNHYEX8ysGc(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000B530 File Offset: 0x00009730
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object KW3DpHemoQf2D4wRxvF(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000B544 File Offset: 0x00009744
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void An3V2ve6hq9Mo8Kki6V(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000B55C File Offset: 0x0000975C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void imUswKelUohq4cw0kkq(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000B568 File Offset: 0x00009768
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object rhu9kde2X1hktYTI6AW(object A_0)
		{
			return A_0.ToArray();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000B574 File Offset: 0x00009774
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void vyF9KiefMuilBGRY0nw(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000B580 File Offset: 0x00009780
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void pNijJ5ehFXFqVGjPNxp(object A_0)
		{
			A_0.GnKMNiUoYk();
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000B58C File Offset: 0x0000978C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int XugcUheOsaYLtoDonZE(object A_0)
		{
			return A_0.Id;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000B598 File Offset: 0x00009798
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr zvb3EXeEMBIlUi5y0WA(uint \u0020, int \u0020, uint \u0020)
		{
			return NV29kkR84hKfwDedo0.oGpYh5URZP(\u0020, \u0020, \u0020);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000B5AC File Offset: 0x000097AC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object LmZyF6eHOitsNhnTNQK(int A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000B5B8 File Offset: 0x000097B8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long gMmq4ceseRog0s0TZ99(object A_0)
		{
			return A_0.Position;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000B5C4 File Offset: 0x000097C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void BZKuhLevCWlEWefVsp8(IntPtr A_0, int A_1)
		{
			Marshal.WriteInt32(A_0, A_1);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000B5D4 File Offset: 0x000097D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int sGAOI5ebqRQBV8vO5fj(IntPtr \u0020)
		{
			return NV29kkR84hKfwDedo0.snCYOh9jNX(\u0020);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000B5E0 File Offset: 0x000097E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void OIsub6edCIGG1XSUgtN(object A_0, object A_1, object A_2)
		{
			A_0.Add(A_1, A_2);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000B5F4 File Offset: 0x000097F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type f5JtsYeIXbZjyeYCUto(RuntimeTypeHandle A_0)
		{
			return Type.GetTypeFromHandle(A_0);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000B600 File Offset: 0x00009800
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int nnMPGReNglJyDBWdJsv(long A_0)
		{
			return Convert.ToInt32(A_0);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000B60C File Offset: 0x0000980C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object EJ7R5reJQHUUstQqiTN()
		{
			return Encoding.UTF8;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000B614 File Offset: 0x00009814
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object w5xsXoeGeMwQ6SGatFB(object A_0, object A_1)
		{
			return A_0.GetString(A_1);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000B624 File Offset: 0x00009824
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool gURZGweBpJ6YfNlAQyf(IntPtr A_0, IntPtr A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000B634 File Offset: 0x00009834
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object di5JKxee35TmJLDSxMP(IntPtr \u0020, Type \u0020)
		{
			return NV29kkR84hKfwDedo0.xpnYT4R9bG(\u0020, \u0020);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000B644 File Offset: 0x00009844
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr z45h7beQtcUgckMEHJo(object A_0)
		{
			return A_0();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000B650 File Offset: 0x00009850
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int F5NM5peXLC6s49pnp3W(IntPtr A_0)
		{
			return Marshal.ReadInt32(A_0);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000B65C File Offset: 0x0000985C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long dupglre90uDwgkl3Mn6(IntPtr A_0)
		{
			return Marshal.ReadInt64(A_0);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000B668 File Offset: 0x00009868
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr cd08oSeSvSpTKx0Dq9W(object A_0)
		{
			return Marshal.GetFunctionPointerForDelegate(A_0);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000B674 File Offset: 0x00009874
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int B4oCWpeudHWwiFHujEl(object A_0)
		{
			return A_0.ModuleMemorySize;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000B680 File Offset: 0x00009880
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object lHbm01egpO2khojuxj1(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000B68C File Offset: 0x0000988C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool zDPtfCewCw5I3eiIbSv(object A_0, object A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000B69C File Offset: 0x0000989C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object CZa5bReUy7QZPCi3EAS(object A_0)
		{
			return A_0.Method;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000B6A8 File Offset: 0x000098A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object iOHNaQe0Z6N9LTPj6B2(Type A_0, object A_1)
		{
			return Delegate.CreateDelegate(A_0, A_1);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000B6B8 File Offset: 0x000098B8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object iYxMP3eo0RSht5en4jX(object A_0)
		{
			return A_0.GetParameters();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000B6C4 File Offset: 0x000098C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object EvhQHceLhsTmkMkqFWr(object A_0)
		{
			return A_0.ManifestModule;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000B6D0 File Offset: 0x000098D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ModuleHandle yfOL4ne5E4w3cfaOG1C(object A_0)
		{
			return A_0.ModuleHandle;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000B6DC File Offset: 0x000098DC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type O0LTNseR1uoZM7rIVdu(object A_0)
		{
			return A_0.GetType();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000B6E8 File Offset: 0x000098E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object cMtbJ7exWSYAsDt3UY7(object A_0, object A_1)
		{
			return A_0.GetValue(A_1);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000B6F8 File Offset: 0x000098F8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object HlD1j2eyKm4OSmPkDsZ(long A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000B704 File Offset: 0x00009904
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Ad7B0KeiiYtGS0V0Q34(object A_0)
		{
			RuntimeHelpers.PrepareDelegate(A_0);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000B710 File Offset: 0x00009910
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static RuntimeMethodHandle ypWn96eWqOMZxsqJ318(object A_0)
		{
			return A_0.MethodHandle;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000B71C File Offset: 0x0000991C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void QNv1gXetZHO8XIJf8Uu(RuntimeMethodHandle A_0)
		{
			RuntimeHelpers.PrepareMethod(A_0);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000B728 File Offset: 0x00009928
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void X1B4M5e8SBgmcuBdnhH(object A_0, RuntimeFieldHandle A_1)
		{
			RuntimeHelpers.InitializeArray(A_0, A_1);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000B738 File Offset: 0x00009938
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr Cfvv0ceFWaYB4iIe77j(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			return NV29kkR84hKfwDedo0.hxbYlUe9h8(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000B750 File Offset: 0x00009950
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void eZyerlenkhFFEuNNGM5(IntPtr A_0, IntPtr A_1)
		{
			Marshal.WriteIntPtr(A_0, A_1);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000B760 File Offset: 0x00009960
		internal static bool QTMJkHBbZk4xFbWC4LT()
		{
			return null == null;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000B768 File Offset: 0x00009968
		internal static object B1V885BddT5burRHU90()
		{
			return null;
		}

		// Token: 0x04000035 RID: 53
		private static bool bhCYwKH1el = false;

		// Token: 0x04000036 RID: 54
		private static int zWZYngtEOi = 1;

		// Token: 0x04000037 RID: 55
		private static int pVgYZOIQsI = 0;

		// Token: 0x04000038 RID: 56
		[NV29kkR84hKfwDedo0.cf1k6uMmypfOxcGHtDG(typeof(NV29kkR84hKfwDedo0.cf1k6uMmypfOxcGHtDG.g4AGk8M621JUAspxcGV<object>[]))]
		private static bool udbYADrdX4 = false;

		// Token: 0x04000039 RID: 57
		internal static object rO9Yzeurhb = new Hashtable();

		// Token: 0x0400003A RID: 58
		private static IntPtr Y97YW9SJ86 = IntPtr.Zero;

		// Token: 0x0400003B RID: 59
		private static object YgXY58VLBJ = new object();

		// Token: 0x0400003C RID: 60
		private static IntPtr a0dYctZEET = IntPtr.Zero;

		// Token: 0x0400003D RID: 61
		private static object PEkMTJIdK9 = null;

		// Token: 0x0400003E RID: 62
		private static List<int> PclYx2u4Rs = null;

		// Token: 0x0400003F RID: 63
		private static object sqwYud5iUi = new uint[]
		{
			3614090360U, 3905402710U, 606105819U, 3250441966U, 4118548399U, 1200080426U, 2821735955U, 4249261313U, 1770035416U, 2336552879U,
			4294925233U, 2304563134U, 1804603682U, 4254626195U, 2792965006U, 1236535329U, 4129170786U, 3225465664U, 643717713U, 3921069994U,
			3593408605U, 38016083U, 3634488961U, 3889429448U, 568446438U, 3275163606U, 4107603335U, 1163531501U, 2850285829U, 4243563512U,
			1735328473U, 2368359562U, 4294588738U, 2272392833U, 1839030562U, 4259657740U, 2763975236U, 1272893353U, 4139469664U, 3200236656U,
			681279174U, 3936430074U, 3572445317U, 76029189U, 3654602809U, 3873151461U, 530742520U, 3299628645U, 4096336452U, 1126891415U,
			2878612391U, 4237533241U, 1700485571U, 2399980690U, 4293915773U, 2240044497U, 1873313359U, 4264355552U, 2734768916U, 1309151649U,
			4149444226U, 3174756917U, 718787259U, 3951481745U
		};

		// Token: 0x04000040 RID: 64
		private static object rCKYyMx94B = new byte[0];

		// Token: 0x04000041 RID: 65
		private static IntPtr OlEYtkCTbe = IntPtr.Zero;

		// Token: 0x04000042 RID: 66
		private static bool BBvYgs6tiJ = false;

		// Token: 0x04000043 RID: 67
		private static object kDvYinvXKE = new byte[0];

		// Token: 0x04000044 RID: 68
		private static bool yHIYC1bbBE = false;

		// Token: 0x04000045 RID: 69
		private static object KqdM3dlqhd = null;

		// Token: 0x04000046 RID: 70
		private static object qU1MYWl34o = null;

		// Token: 0x04000047 RID: 71
		private static object IoGMk1JnJw = null;

		// Token: 0x04000048 RID: 72
		private static int G4dYLeR4kf = 0;

		// Token: 0x04000049 RID: 73
		internal static object PnsYSsCB1h = typeof(NV29kkR84hKfwDedo0).Assembly;

		// Token: 0x0400004A RID: 74
		private static bool H4EYKQCEjl = false;

		// Token: 0x0400004B RID: 75
		private static object T7YYasqpbo = new SortedList();

		// Token: 0x0400004C RID: 76
		internal static object SraYUvEIT6 = null;

		// Token: 0x0400004D RID: 77
		private static IntPtr MrfMqJlgQn = IntPtr.Zero;

		// Token: 0x0400004E RID: 78
		internal static object JHUYpFPJpm = null;

		// Token: 0x0400004F RID: 79
		private static long efiY7MM34Y = 0L;

		// Token: 0x04000050 RID: 80
		private static object gT6YFflskn = new int[0];

		// Token: 0x04000051 RID: 81
		private static List<string> r0tYReV3Zf = null;

		// Token: 0x04000052 RID: 82
		internal static object cD4YVHlDx5 = null;

		// Token: 0x04000053 RID: 83
		private static object v8AYoynKm1 = new object();

		// Token: 0x04000054 RID: 84
		private static object vMNMrMOON8 = null;

		// Token: 0x04000055 RID: 85
		private static object fnxY8FLlPX = new string[0];

		// Token: 0x04000056 RID: 86
		private static Dictionary<int, int> KnoY0GmwNk = null;

		// Token: 0x04000057 RID: 87
		private static int sbvYD1SKkd = 0;

		// Token: 0x04000058 RID: 88
		private static long fK7Y1hjYYs = 0L;

		// Token: 0x04000059 RID: 89
		private static bool i6hYjTo8lV = false;

		// Token: 0x0400005A RID: 90
		private static bool c6jY9EuCV0 = false;

		// Token: 0x0400005B RID: 91
		private static object WKIMM3xdpB = null;

		// Token: 0x0400005C RID: 92
		private static int Uv6YPkQloy = 0;

		// Token: 0x0200000E RID: 14
		private sealed class oim2cMM4VIZK0P9jHSU : MulticastDelegate
		{
			// Token: 0x060000F8 RID: 248
			public extern oim2cMM4VIZK0P9jHSU(object \u0020, IntPtr \u0020);

			// Token: 0x060000F9 RID: 249
			public extern void Invoke(object o);

			// Token: 0x060000FA RID: 250
			public extern IAsyncResult BeginInvoke(object o, AsyncCallback callback, object @object);

			// Token: 0x060000FB RID: 251
			public extern void EndInvoke(IAsyncResult result);

			// Token: 0x060000FC RID: 252 RVA: 0x0000B76C File Offset: 0x0000996C
			static oim2cMM4VIZK0P9jHSU()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x0200000F RID: 15
		internal class cf1k6uMmypfOxcGHtDG : Attribute
		{
			// Token: 0x060000FD RID: 253 RVA: 0x0000B774 File Offset: 0x00009974
			[MethodImpl(MethodImplOptions.NoInlining)]
			public cf1k6uMmypfOxcGHtDG(object \u0020)
			{
			}

			// Token: 0x060000FE RID: 254 RVA: 0x0000B77C File Offset: 0x0000997C
			static cf1k6uMmypfOxcGHtDG()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}

			// Token: 0x02000010 RID: 16
			internal class g4AGk8M621JUAspxcGV<Y3cSC1MlusrnO57ab55>
			{
				// Token: 0x060000FF RID: 255 RVA: 0x0000B784 File Offset: 0x00009984
				[MethodImpl(MethodImplOptions.NoInlining)]
				public g4AGk8M621JUAspxcGV()
				{
				}

				// Token: 0x06000100 RID: 256 RVA: 0x0000B794 File Offset: 0x00009994
				[MethodImpl(MethodImplOptions.NoInlining)]
				static g4AGk8M621JUAspxcGV()
				{
					NV29kkR84hKfwDedo0.sVRYrckA7s();
					qcORXVMoXZFyEtfhfCf.jlpejSOFft();
				}

				// Token: 0x06000101 RID: 257 RVA: 0x0000B7A0 File Offset: 0x000099A0
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool OI9cDjHCLg3vYJ5jOxs()
				{
					return true;
				}

				// Token: 0x06000102 RID: 258 RVA: 0x0000B7A8 File Offset: 0x000099A8
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static object KAh6P6HKp8DMj35fvKG()
				{
					return null;
				}

				// Token: 0x0400005D RID: 93
				internal static object Me4w2EHDyWjPvWqdXWS;
			}
		}

		// Token: 0x02000011 RID: 17
		internal class M3eZLxM2mbcsTSW9wrU
		{
			// Token: 0x06000103 RID: 259 RVA: 0x0000B7B0 File Offset: 0x000099B0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static string DnmMfJGHIW(object \u0020, object \u0020)
			{
				return null;
			}

			// Token: 0x06000104 RID: 260 RVA: 0x0000B7C0 File Offset: 0x000099C0
			[MethodImpl(MethodImplOptions.NoInlining)]
			public M3eZLxM2mbcsTSW9wrU()
			{
			}

			// Token: 0x06000105 RID: 261 RVA: 0x0000B7C8 File Offset: 0x000099C8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object OT8ODKHzMI0WeFvjlZv()
			{
				return null;
			}

			// Token: 0x06000106 RID: 262 RVA: 0x0000B7D0 File Offset: 0x000099D0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object h7b6bHs3B5R6xbWVwou(object A_0, object A_1)
			{
				return null;
			}

			// Token: 0x06000107 RID: 263 RVA: 0x0000B7D8 File Offset: 0x000099D8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void NCN5njsYy1KEIvjtU0p(object A_0, RuntimeFieldHandle A_1)
			{
			}

			// Token: 0x06000108 RID: 264 RVA: 0x0000B7E0 File Offset: 0x000099E0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object pefuQGsMieSFRcXXY7f(object A_0)
			{
				return null;
			}

			// Token: 0x06000109 RID: 265 RVA: 0x0000B7E8 File Offset: 0x000099E8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object Nql7VSskxrCqtQbwMBp()
			{
				return null;
			}

			// Token: 0x0600010A RID: 266 RVA: 0x0000B7F0 File Offset: 0x000099F0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void ifFpTOsTnhw8SOxoHSA(object A_0, object A_1)
			{
			}

			// Token: 0x0600010B RID: 267 RVA: 0x0000B7F8 File Offset: 0x000099F8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void eXX6SYsrnQ1hedBWwYl(object A_0, object A_1)
			{
			}

			// Token: 0x0600010C RID: 268 RVA: 0x0000B800 File Offset: 0x00009A00
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object XrM9JBsq0jUa6fsH0rU(object A_0)
			{
				return null;
			}

			// Token: 0x0600010D RID: 269 RVA: 0x0000B808 File Offset: 0x00009A08
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void yCM2yMs47vq2yrAY8d9(object A_0, object A_1, int A_2, int A_3)
			{
			}

			// Token: 0x0600010E RID: 270 RVA: 0x0000B810 File Offset: 0x00009A10
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void PVwv4dsm6qm7bEV5rKO(object A_0)
			{
			}

			// Token: 0x0600010F RID: 271 RVA: 0x0000B818 File Offset: 0x00009A18
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object P9jLDns6eT6826fHmni(object A_0)
			{
				return null;
			}

			// Token: 0x06000110 RID: 272 RVA: 0x0000B820 File Offset: 0x00009A20
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object aj0dvcslsCEM9PUoJd0(object A_0)
			{
				return null;
			}

			// Token: 0x06000111 RID: 273 RVA: 0x0000B828 File Offset: 0x00009A28
			static M3eZLxM2mbcsTSW9wrU()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x02000012 RID: 18
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal sealed class l1T8AmMhyV3o44qdUZy : MulticastDelegate
		{
			// Token: 0x06000112 RID: 274
			public extern l1T8AmMhyV3o44qdUZy(object \u0020, IntPtr \u0020);

			// Token: 0x06000113 RID: 275
			public extern uint Invoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

			// Token: 0x06000114 RID: 276
			public extern IAsyncResult BeginInvoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode, AsyncCallback callback, object @object);

			// Token: 0x06000115 RID: 277
			public extern uint EndInvoke(ref uint nativeSizeOfCode, IAsyncResult result);

			// Token: 0x06000116 RID: 278 RVA: 0x0000B830 File Offset: 0x00009A30
			static l1T8AmMhyV3o44qdUZy()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x02000013 RID: 19
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class pAQb2TMORSfDb7oCbkk : MulticastDelegate
		{
			// Token: 0x06000117 RID: 279
			public extern pAQb2TMORSfDb7oCbkk(object \u0020, IntPtr \u0020);

			// Token: 0x06000118 RID: 280
			public extern IntPtr Invoke();

			// Token: 0x06000119 RID: 281
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x0600011A RID: 282
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600011B RID: 283 RVA: 0x0000B838 File Offset: 0x00009A38
			static pAQb2TMORSfDb7oCbkk()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x02000014 RID: 20
		internal struct udXKr1MEiU6cGbsjG68
		{
			// Token: 0x0400005E RID: 94
			internal bool qiXMH0usd7;

			// Token: 0x0400005F RID: 95
			internal byte[] JykMsC4DBr;
		}

		// Token: 0x02000015 RID: 21
		internal class WQOm9MMvIW0bAgnHNWb
		{
			// Token: 0x0600011C RID: 284 RVA: 0x0000B840 File Offset: 0x00009A40
			[MethodImpl(MethodImplOptions.NoInlining)]
			public WQOm9MMvIW0bAgnHNWb(Stream \u0020)
			{
				this.SSZMJ2SRbu = new BinaryReader(\u0020);
			}

			// Token: 0x0600011D RID: 285 RVA: 0x0000B85C File Offset: 0x00009A5C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal Stream nW4lBacjpc()
			{
				return NV29kkR84hKfwDedo0.WQOm9MMvIW0bAgnHNWb.ODISg2ssKlxUEmZAg5h(this.SSZMJ2SRbu);
			}

			// Token: 0x0600011E RID: 286 RVA: 0x0000B870 File Offset: 0x00009A70
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal byte[] zELMbs2fZi(int \u0020)
			{
				return this.SSZMJ2SRbu.ReadBytes(\u0020);
			}

			// Token: 0x0600011F RID: 287 RVA: 0x0000B888 File Offset: 0x00009A88
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int XdlMdGeB1y(byte[] \u0020, int \u0020, int \u0020)
			{
				return NV29kkR84hKfwDedo0.WQOm9MMvIW0bAgnHNWb.DfDaw3svFgkTQCZu62t(this.SSZMJ2SRbu, \u0020, \u0020, \u0020);
			}

			// Token: 0x06000120 RID: 288 RVA: 0x0000B8A0 File Offset: 0x00009AA0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int t6pMIY1ZoG()
			{
				return NV29kkR84hKfwDedo0.WQOm9MMvIW0bAgnHNWb.NUxqh4sbI2lCuGHMlwf(this.SSZMJ2SRbu);
			}

			// Token: 0x06000121 RID: 289 RVA: 0x0000B8B4 File Offset: 0x00009AB4
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void GnKMNiUoYk()
			{
				NV29kkR84hKfwDedo0.WQOm9MMvIW0bAgnHNWb.VyGusisd2ROhkLHETVK(this.SSZMJ2SRbu);
			}

			// Token: 0x06000122 RID: 290 RVA: 0x0000B8C8 File Offset: 0x00009AC8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object ODISg2ssKlxUEmZAg5h(object A_0)
			{
				return A_0.BaseStream;
			}

			// Token: 0x06000123 RID: 291 RVA: 0x0000B8DC File Offset: 0x00009ADC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static int DfDaw3svFgkTQCZu62t(object A_0, object A_1, int A_2, int A_3)
			{
				return A_0.Read(A_1, A_2, A_3);
			}

			// Token: 0x06000124 RID: 292 RVA: 0x0000B8FC File Offset: 0x00009AFC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static int NUxqh4sbI2lCuGHMlwf(object A_0)
			{
				return A_0.ReadInt32();
			}

			// Token: 0x06000125 RID: 293 RVA: 0x0000B910 File Offset: 0x00009B10
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void VyGusisd2ROhkLHETVK(object A_0)
			{
				A_0.Close();
			}

			// Token: 0x06000126 RID: 294 RVA: 0x0000B924 File Offset: 0x00009B24
			static WQOm9MMvIW0bAgnHNWb()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}

			// Token: 0x04000060 RID: 96
			private object SSZMJ2SRbu;
		}

		// Token: 0x02000016 RID: 22
		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private sealed class IKfFhZMGS8qEk9unvW2 : MulticastDelegate
		{
			// Token: 0x06000127 RID: 295
			public extern IKfFhZMGS8qEk9unvW2(object \u0020, IntPtr \u0020);

			// Token: 0x06000128 RID: 296
			public extern IntPtr Invoke(IntPtr hModule, string lpName, uint lpType);

			// Token: 0x06000129 RID: 297
			public extern IAsyncResult BeginInvoke(IntPtr hModule, string lpName, uint lpType, AsyncCallback callback, object @object);

			// Token: 0x0600012A RID: 298
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600012B RID: 299 RVA: 0x0000B92C File Offset: 0x00009B2C
			static IKfFhZMGS8qEk9unvW2()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x02000017 RID: 23
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class wqX7eiMBLLOKHRkntF0 : MulticastDelegate
		{
			// Token: 0x0600012C RID: 300
			public extern wqX7eiMBLLOKHRkntF0(object \u0020, IntPtr \u0020);

			// Token: 0x0600012D RID: 301
			public extern IntPtr Invoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x0600012E RID: 302
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect, AsyncCallback callback, object @object);

			// Token: 0x0600012F RID: 303
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000130 RID: 304 RVA: 0x0000B934 File Offset: 0x00009B34
			static wqX7eiMBLLOKHRkntF0()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x02000018 RID: 24
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class qy3d1vMe3CrYdclWyfD : MulticastDelegate
		{
			// Token: 0x06000131 RID: 305
			public extern qy3d1vMe3CrYdclWyfD(object \u0020, IntPtr \u0020);

			// Token: 0x06000132 RID: 306
			public extern int Invoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

			// Token: 0x06000133 RID: 307
			public extern IAsyncResult BeginInvoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten, AsyncCallback callback, object @object);

			// Token: 0x06000134 RID: 308
			public extern int EndInvoke(out IntPtr lpNumberOfBytesWritten, IAsyncResult result);

			// Token: 0x06000135 RID: 309 RVA: 0x0000B93C File Offset: 0x00009B3C
			static qy3d1vMe3CrYdclWyfD()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x02000019 RID: 25
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class kxaIVNMQN4mJIKgv3Dk : MulticastDelegate
		{
			// Token: 0x06000136 RID: 310
			public extern kxaIVNMQN4mJIKgv3Dk(object \u0020, IntPtr \u0020);

			// Token: 0x06000137 RID: 311
			public extern int Invoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

			// Token: 0x06000138 RID: 312
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect, AsyncCallback callback, object @object);

			// Token: 0x06000139 RID: 313
			public extern int EndInvoke(ref int lpflOldProtect, IAsyncResult result);

			// Token: 0x0600013A RID: 314 RVA: 0x0000B944 File Offset: 0x00009B44
			static kxaIVNMQN4mJIKgv3Dk()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x0200001A RID: 26
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class lpq3OsMX17Vxw4kn6qo : MulticastDelegate
		{
			// Token: 0x0600013B RID: 315
			public extern lpq3OsMX17Vxw4kn6qo(object \u0020, IntPtr \u0020);

			// Token: 0x0600013C RID: 316
			public extern IntPtr Invoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x0600013D RID: 317
			public extern IAsyncResult BeginInvoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId, AsyncCallback callback, object @object);

			// Token: 0x0600013E RID: 318
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600013F RID: 319 RVA: 0x0000B94C File Offset: 0x00009B4C
			static lpq3OsMX17Vxw4kn6qo()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x0200001B RID: 27
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class ekCjpyM9xWGE1wvqOnM : MulticastDelegate
		{
			// Token: 0x06000140 RID: 320
			public extern ekCjpyM9xWGE1wvqOnM(object \u0020, IntPtr \u0020);

			// Token: 0x06000141 RID: 321
			public extern int Invoke(IntPtr ptr);

			// Token: 0x06000142 RID: 322
			public extern IAsyncResult BeginInvoke(IntPtr ptr, AsyncCallback callback, object @object);

			// Token: 0x06000143 RID: 323
			public extern int EndInvoke(IAsyncResult result);

			// Token: 0x06000144 RID: 324 RVA: 0x0000B954 File Offset: 0x00009B54
			static ekCjpyM9xWGE1wvqOnM()
			{
				NV29kkR84hKfwDedo0.sVRYrckA7s();
			}
		}

		// Token: 0x0200001C RID: 28
		[Flags]
		private enum wr4RYYMSMoEnRXfJgYb
		{

		}
	}
}
