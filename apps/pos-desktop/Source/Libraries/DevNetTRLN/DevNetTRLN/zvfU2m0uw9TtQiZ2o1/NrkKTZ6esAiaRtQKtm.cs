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
using O697GMKec98yc8lkodB;
using oAfU4TcdBynedNsN70W;
using S5UDxdc93uEZVyI0wyl;

namespace zvfU2m0uw9TtQiZ2o1
{
	// Token: 0x0200000E RID: 14
	internal class NrkKTZ6esAiaRtQKtm
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00002774 File Offset: 0x00000974
		[MethodImpl(MethodImplOptions.NoInlining)]
		static NrkKTZ6esAiaRtQKtm()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000028E8 File Offset: 0x00000AE8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Xq0ADxmt8N()
		{
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000028EC File Offset: 0x00000AEC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] EU7LXDVCS(object \u0020)
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
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num6, num7, num8, num9, 0U, 7, 1U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num9, num6, num7, num8, 1U, 12, 2U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num8, num9, num6, num7, 2U, 17, 3U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num7, num8, num9, num6, 3U, 22, 4U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num6, num7, num8, num9, 4U, 7, 5U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num9, num6, num7, num8, 5U, 12, 6U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num8, num9, num6, num7, 6U, 17, 7U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num7, num8, num9, num6, 7U, 22, 8U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num6, num7, num8, num9, 8U, 7, 9U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num9, num6, num7, num8, 9U, 12, 10U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num8, num9, num6, num7, 10U, 17, 11U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num7, num8, num9, num6, 11U, 22, 12U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num6, num7, num8, num9, 12U, 7, 13U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num9, num6, num7, num8, 13U, 12, 14U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num8, num9, num6, num7, 14U, 17, 15U, array);
				NrkKTZ6esAiaRtQKtm.mBQZ3RDP4(ref num7, num8, num9, num6, 15U, 22, 16U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num6, num7, num8, num9, 1U, 5, 17U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num9, num6, num7, num8, 6U, 9, 18U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num8, num9, num6, num7, 11U, 14, 19U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num7, num8, num9, num6, 0U, 20, 20U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num6, num7, num8, num9, 5U, 5, 21U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num9, num6, num7, num8, 10U, 9, 22U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num8, num9, num6, num7, 15U, 14, 23U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num7, num8, num9, num6, 4U, 20, 24U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num6, num7, num8, num9, 9U, 5, 25U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num9, num6, num7, num8, 14U, 9, 26U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num8, num9, num6, num7, 3U, 14, 27U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num7, num8, num9, num6, 8U, 20, 28U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num6, num7, num8, num9, 13U, 5, 29U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num9, num6, num7, num8, 2U, 9, 30U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num8, num9, num6, num7, 7U, 14, 31U, array);
				NrkKTZ6esAiaRtQKtm.cXMOX4YWn(ref num7, num8, num9, num6, 12U, 20, 32U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num6, num7, num8, num9, 5U, 4, 33U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num9, num6, num7, num8, 8U, 11, 34U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num8, num9, num6, num7, 11U, 16, 35U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num7, num8, num9, num6, 14U, 23, 36U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num6, num7, num8, num9, 1U, 4, 37U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num9, num6, num7, num8, 4U, 11, 38U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num8, num9, num6, num7, 7U, 16, 39U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num7, num8, num9, num6, 10U, 23, 40U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num6, num7, num8, num9, 13U, 4, 41U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num9, num6, num7, num8, 0U, 11, 42U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num8, num9, num6, num7, 3U, 16, 43U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num7, num8, num9, num6, 6U, 23, 44U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num6, num7, num8, num9, 9U, 4, 45U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num9, num6, num7, num8, 12U, 11, 46U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num8, num9, num6, num7, 15U, 16, 47U, array);
				NrkKTZ6esAiaRtQKtm.H0E4reAE6(ref num7, num8, num9, num6, 2U, 23, 48U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num6, num7, num8, num9, 0U, 6, 49U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num9, num6, num7, num8, 7U, 10, 50U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num8, num9, num6, num7, 14U, 15, 51U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num7, num8, num9, num6, 5U, 21, 52U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num6, num7, num8, num9, 12U, 6, 53U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num9, num6, num7, num8, 3U, 10, 54U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num8, num9, num6, num7, 10U, 15, 55U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num7, num8, num9, num6, 1U, 21, 56U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num6, num7, num8, num9, 8U, 6, 57U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num9, num6, num7, num8, 15U, 10, 58U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num8, num9, num6, num7, 6U, 15, 59U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num7, num8, num9, num6, 13U, 21, 60U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num6, num7, num8, num9, 4U, 6, 61U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num9, num6, num7, num8, 11U, 10, 62U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num8, num9, num6, num7, 2U, 15, 63U, array);
				NrkKTZ6esAiaRtQKtm.jqwm6rRGX(ref num7, num8, num9, num6, 9U, 21, 64U, array);
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

		// Token: 0x06000056 RID: 86 RVA: 0x00002F50 File Offset: 0x00001150
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void mBQZ3RDP4(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += NrkKTZ6esAiaRtQKtm.At8Gxuw6m(\u0020 + ((\u0020 & \u0020) | (~\u0020 & \u0020)) + \u0020[(int)\u0020] + NrkKTZ6esAiaRtQKtm.oXmw2Nmjw0[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002F7C File Offset: 0x0000117C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void cXMOX4YWn(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += NrkKTZ6esAiaRtQKtm.At8Gxuw6m(\u0020 + ((\u0020 & \u0020) | (\u0020 & ~\u0020)) + \u0020[(int)\u0020] + NrkKTZ6esAiaRtQKtm.oXmw2Nmjw0[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002FA8 File Offset: 0x000011A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void H0E4reAE6(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += NrkKTZ6esAiaRtQKtm.At8Gxuw6m(\u0020 + (\u0020 ^ \u0020 ^ \u0020) + \u0020[(int)\u0020] + NrkKTZ6esAiaRtQKtm.oXmw2Nmjw0[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002FD0 File Offset: 0x000011D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void jqwm6rRGX(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += NrkKTZ6esAiaRtQKtm.At8Gxuw6m(\u0020 + (\u0020 ^ (\u0020 | ~\u0020)) + \u0020[(int)\u0020] + NrkKTZ6esAiaRtQKtm.oXmw2Nmjw0[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002FF8 File Offset: 0x000011F8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static uint At8Gxuw6m(uint \u0020, ushort \u0020)
		{
			return (\u0020 >> (int)(32 - \u0020)) | (\u0020 << (int)\u0020);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000300C File Offset: 0x0000120C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool kJqBecf70()
		{
			if (!NrkKTZ6esAiaRtQKtm.AFKw9vVh37)
			{
				NrkKTZ6esAiaRtQKtm.tuczNtYgI();
				NrkKTZ6esAiaRtQKtm.AFKw9vVh37 = true;
			}
			return NrkKTZ6esAiaRtQKtm.brdwR8QLaQ;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003028 File Offset: 0x00001228
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal NrkKTZ6esAiaRtQKtm()
		{
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003030 File Offset: 0x00001230
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void L5D15aBm0(byte[] \u0020, byte[] \u0020, byte[] \u0020)
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
				uint num13 = 199912980U;
				uint num14 = 1037969119U;
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
			NrkKTZ6esAiaRtQKtm.DDgwLikQMX = array;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003360 File Offset: 0x00001560
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static SymmetricAlgorithm mtoJHUs35()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (NrkKTZ6esAiaRtQKtm.kJqBecf70())
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

		// Token: 0x0600005F RID: 95 RVA: 0x000033F4 File Offset: 0x000015F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void tuczNtYgI()
		{
			try
			{
				new MD5CryptoServiceProvider();
			}
			catch
			{
				NrkKTZ6esAiaRtQKtm.brdwR8QLaQ = true;
				return;
			}
			try
			{
				NrkKTZ6esAiaRtQKtm.brdwR8QLaQ = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000344C File Offset: 0x0000164C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] pPgwtAgkaN(object \u0020)
		{
			if (!NrkKTZ6esAiaRtQKtm.kJqBecf70())
			{
				return new MD5CryptoServiceProvider().ComputeHash(\u0020);
			}
			return NrkKTZ6esAiaRtQKtm.EU7LXDVCS(\u0020);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000346C File Offset: 0x0000166C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void YXlwwMjCRW(object \u0020, object \u0020, uint \u0020, object \u0020)
		{
			while (\u0020 > 0U)
			{
				int num = ((\u0020 > (uint)\u0020.Length) ? \u0020.Length : ((int)\u0020));
				\u0020.Read(\u0020, 0, num);
				NrkKTZ6esAiaRtQKtm.L7nwcvaBU8(\u0020, \u0020, 0, num);
				\u0020 -= (uint)num;
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000034B0 File Offset: 0x000016B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void L7nwcvaBU8(object \u0020, object \u0020, int \u0020, int \u0020)
		{
			\u0020.TransformBlock(\u0020, \u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000034C0 File Offset: 0x000016C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint VlDwKDvViJ(uint \u0020, int \u0020, long \u0020, object \u0020)
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

		// Token: 0x06000064 RID: 100 RVA: 0x00003528 File Offset: 0x00001728
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void nrrwPPmfu9(RuntimeTypeHandle \u0020)
		{
			try
			{
				Type typeFromHandle = Type.GetTypeFromHandle(\u0020);
				if (NrkKTZ6esAiaRtQKtm.IAqwH0mMp0 == null)
				{
					object siawFGs41E = NrkKTZ6esAiaRtQKtm.SIAwFGs41E;
					lock (siawFGs41E)
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						BinaryReader binaryReader = new BinaryReader(typeof(NrkKTZ6esAiaRtQKtm).Assembly.GetManifestResourceStream("vsee0nDgGJOkCJQYHr.Ab3nhDUVyTkCZTPPxB"));
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
								uint num11 = 199912980U;
								uint num12 = 1037969119U;
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
							NrkKTZ6esAiaRtQKtm.z2G3P3cj94OxNl7aFlt z2G3P3cj94OxNl7aFlt = new NrkKTZ6esAiaRtQKtm.z2G3P3cj94OxNl7aFlt(new MemoryStream(array));
							for (int l = 0; l < num21; l++)
							{
								int num22 = z2G3P3cj94OxNl7aFlt.WUYcv0B5FB();
								int num23 = z2G3P3cj94OxNl7aFlt.WUYcv0B5FB();
								dictionary.Add(num22, num23);
							}
							z2G3P3cj94OxNl7aFlt.SQDcVAMfNH();
						}
						NrkKTZ6esAiaRtQKtm.IAqwH0mMp0 = dictionary;
					}
				}
				FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
				for (int m = 0; m < fields.Length; m++)
				{
					try
					{
						FieldInfo fieldInfo = fields[m];
						int metadataToken = fieldInfo.MetadataToken;
						int num24 = NrkKTZ6esAiaRtQKtm.IAqwH0mMp0[metadataToken];
						bool flag2 = (num24 & 1073741824) > 0;
						num24 &= 1073741823;
						MethodInfo methodInfo = (MethodInfo)typeof(NrkKTZ6esAiaRtQKtm).Module.ResolveMethod(num24, typeFromHandle.GetGenericArguments(), new Type[0]);
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

		// Token: 0x06000065 RID: 101 RVA: 0x00003B7C File Offset: 0x00001D7C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void th2weCGEkm()
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003B80 File Offset: 0x00001D80
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void PSJwuHKskP(object \u0020, int \u0020)
		{
			Kv4kIBKslnJP3ZGVH8H.kUyKUUOV6v(0, new object[] { \u0020, \u0020 }, null);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003BC0 File Offset: 0x00001DC0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string GbswnLL2fA(int \u0020)
		{
			if (NrkKTZ6esAiaRtQKtm.DDgwLikQMX.Length == 0)
			{
				NrkKTZ6esAiaRtQKtm.zeqw6a4CXF = new List<string>();
				NrkKTZ6esAiaRtQKtm.QfJw0E3We3 = new List<int>();
				NrkKTZ6esAiaRtQKtm.PSJwuHKskP(NrkKTZ6esAiaRtQKtm.EONwWqrt4G.GetManifestResourceStream("LjEeMSwlNkkQ89Xkg4.9ZLmoQc5Sh1Itx90v4"), \u0020);
			}
			if (NrkKTZ6esAiaRtQKtm.Xb3wdD2H2L < 75)
			{
				if (NrkKTZ6esAiaRtQKtm.EONwWqrt4G != new StackFrame(1).GetMethod().DeclaringType.Assembly)
				{
					throw new Exception();
				}
				NrkKTZ6esAiaRtQKtm.Xb3wdD2H2L++;
			}
			object obj = NrkKTZ6esAiaRtQKtm.z3ZwhvSwlS;
			lock (obj)
			{
				int num = BitConverter.ToInt32(NrkKTZ6esAiaRtQKtm.DDgwLikQMX, \u0020);
				if (num < NrkKTZ6esAiaRtQKtm.QfJw0E3We3.Count && NrkKTZ6esAiaRtQKtm.QfJw0E3We3[num] == \u0020)
				{
					return NrkKTZ6esAiaRtQKtm.zeqw6a4CXF[num];
				}
				try
				{
					HVH9hrc2y21U31AG4bl.FQsAUKBwJZ();
					byte[] array = new byte[num];
					Array.Copy(NrkKTZ6esAiaRtQKtm.DDgwLikQMX, \u0020 + 4, array, 0, num);
					string @string = Encoding.Unicode.GetString(array, 0, array.Length);
					NrkKTZ6esAiaRtQKtm.zeqw6a4CXF.Add(@string);
					NrkKTZ6esAiaRtQKtm.QfJw0E3We3.Add(\u0020);
					Array.Copy(BitConverter.GetBytes(NrkKTZ6esAiaRtQKtm.zeqw6a4CXF.Count - 1), 0, NrkKTZ6esAiaRtQKtm.DDgwLikQMX, \u0020, 4);
					return @string;
				}
				catch
				{
				}
			}
			return "";
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003D38 File Offset: 0x00001F38
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string cDFwDfie7W(object \u0020)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(\u0020);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003D68 File Offset: 0x00001F68
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint wUTwUWMQ5Z(IntPtr \u0020, IntPtr \u0020, IntPtr \u0020, [MarshalAs(UnmanagedType.U4)] uint \u0020, IntPtr \u0020, ref uint \u0020)
		{
			IntPtr intPtr = \u0020;
			if (NrkKTZ6esAiaRtQKtm.olCwkV4YYa)
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
			object obj = NrkKTZ6esAiaRtQKtm.jfacnvmZfm[num];
			if (obj == null)
			{
				return NrkKTZ6esAiaRtQKtm.q54cwIo8a7(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv gwgifTc71BJOaot4wBv = (NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv)obj;
			IntPtr intPtr2 = Marshal.AllocCoTaskMem(gwgifTc71BJOaot4wBv.tTpcpXCpSj.Length);
			Marshal.Copy(gwgifTc71BJOaot4wBv.tTpcpXCpSj, 0, intPtr2, gwgifTc71BJOaot4wBv.tTpcpXCpSj.Length);
			if (gwgifTc71BJOaot4wBv.Xo1cXJIe5g)
			{
				\u0020 = intPtr2;
				\u0020 = (uint)gwgifTc71BJOaot4wBv.tTpcpXCpSj.Length;
				NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(\u0020, gwgifTc71BJOaot4wBv.tTpcpXCpSj.Length, 64, ref NrkKTZ6esAiaRtQKtm.rKxcsM4Dd5);
				return 0U;
			}
			Marshal.WriteIntPtr(intPtr, IntPtr.Size * 2, intPtr2);
			Marshal.WriteInt32(intPtr, IntPtr.Size * 3, gwgifTc71BJOaot4wBv.tTpcpXCpSj.Length);
			uint num2 = 0U;
			if (\u0020 != 216669565U || NrkKTZ6esAiaRtQKtm.IsTcucsPBl)
			{
				num2 = NrkKTZ6esAiaRtQKtm.q54cwIo8a7(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			else
			{
				NrkKTZ6esAiaRtQKtm.IsTcucsPBl = true;
			}
			return num2;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003E9C File Offset: 0x0000209C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int an4wIw85MY()
		{
			return 5;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003EA0 File Offset: 0x000020A0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void b8IwfoN8eX()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003ED0 File Offset: 0x000020D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Delegate AEDwYFMMVx(IntPtr \u0020, Type \u0020)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[] { \u0020, \u0020 });
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003F30 File Offset: 0x00002130
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe static void aPowiPKDJv()
		{
			int num = 613;
			for (;;)
			{
				int num2 = num;
				byte[] array;
				int num3;
				byte[] array2;
				uint num4;
				int num6;
				NrkKTZ6esAiaRtQKtm.z2G3P3cj94OxNl7aFlt z2G3P3cj94OxNl7aFlt;
				int num9;
				IntPtr intPtr2;
				byte[] array7;
				int num15;
				byte[] array9;
				long num16;
				byte[] array11;
				byte[] array13;
				byte[] array14;
				int num21;
				byte[] array15;
				string text2;
				uint num29;
				uint num36;
				long num37;
				byte[] array18;
				int num40;
				CryptoStream cryptoStream;
				IntPtr intPtr4;
				long num41;
				IntPtr intPtr5;
				IntPtr intPtr6;
				IntPtr zero;
				int num53;
				IntPtr intPtr8;
				int num56;
				int num57;
				int num64;
				IntPtr intPtr9;
				byte* ptr2;
				uint num66;
				for (;;)
				{
					uint num5;
					byte[] array3;
					int num7;
					IntPtr intPtr;
					int num8;
					int num10;
					byte[] array5;
					int num11;
					int num12;
					byte[] array6;
					int num13;
					uint num14;
					byte[] array8;
					byte[] array10;
					int num17;
					byte[] array12;
					IntPtr intPtr3;
					bool flag;
					Process process;
					byte[] array16;
					int num30;
					int num33;
					long num38;
					int num44;
					uint num49;
					int num50;
					IntPtr intPtr7;
					int num51;
					int num52;
					int num54;
					int num55;
					switch (num2)
					{
					case 0:
						goto IL_4C6E;
					case 1:
						array[19] = 34 + 124;
						num2 = 25;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 92;
							continue;
						}
						continue;
					case 2:
						num3 = 176 + 51;
						num2 = 65;
						continue;
					case 3:
						num4 = (uint)(((int)array2[(int)(num5 + 3U)] << 24) | ((int)array2[(int)(num5 + 2U)] << 16) | ((int)array2[(int)(num5 + 1U)] << 8) | (int)array2[(int)num5]);
						num2 = 339;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 158;
							continue;
						}
						continue;
					case 4:
						num6 = 220 - 73;
						num2 = 191;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 541;
							continue;
						}
						continue;
					case 5:
					{
						byte[] array4;
						array3 = array4;
						num2 = 335;
						continue;
					}
					case 6:
						num6 = 14 + 83;
						num2 = 78;
						continue;
					case 7:
						num7 = NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
						num2 = 460;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 155;
							continue;
						}
						continue;
					case 8:
						goto IL_3B86;
					case 9:
						NrkKTZ6esAiaRtQKtm.vGlcKhef2Q = intPtr.ToInt64();
						num2 = 539;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 131;
							continue;
						}
						continue;
					case 10:
						num8 = 0;
						num2 = 648;
						continue;
					case 11:
						if (num9 != num10 - 1)
						{
							goto IL_43DF;
						}
						num2 = 238;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 282;
							continue;
						}
						continue;
					case 12:
						if (!NrkKTZ6esAiaRtQKtm.X1MbDfAV6Tb9X5LjeRw(NrkKTZ6esAiaRtQKtm.q1OhXhAvXckCB9JX66w("System.Reflection.ReflectionContext", false), null))
						{
							goto IL_1792;
						}
						num2 = 5;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 96;
							continue;
						}
						continue;
					case 13:
					{
						object obj = NrkKTZ6esAiaRtQKtm.Igb1607waF2i6Ek6LiS();
						NrkKTZ6esAiaRtQKtm.a0FMdP7cl1hiDLSScVn(obj, CipherMode.CBC);
						ICryptoTransform cryptoTransform = NrkKTZ6esAiaRtQKtm.pOpTxL7Kas9WLC0stE9(obj, array2, array5);
						num2 = 136;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 510;
							continue;
						}
						continue;
					}
					case 14:
						num3 = 106 + 124;
						num2 = 630;
						continue;
					case 15:
						goto IL_244C;
					case 16:
						num6 = 113 + 102;
						num2 = 353;
						continue;
					case 17:
						if (NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(intPtr2, num11 * 4, 4, ref num12) != 0)
						{
							num2 = 580;
							continue;
						}
						goto IL_0CB6;
					case 18:
						array6[num13 + 2] = (byte)((num14 & 16711680U) >> 16);
						num2 = 66;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 322;
							continue;
						}
						continue;
					case 19:
						if (!NrkKTZ6esAiaRtQKtm.CbxZs27pIWcaU4iABVk(NrkKTZ6esAiaRtQKtm.SqVCLY7Xb5VkF0I5ceo(NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm).TypeHandle).Assembly), null))
						{
							goto Block_65;
						}
						goto IL_2DB7;
					case 20:
						num3 = 66 + 20;
						num2 = 341;
						continue;
					case 21:
						array7[num15] = array8[0];
						num2 = 459;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 303;
							continue;
						}
						continue;
					case 22:
						if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() == 4)
						{
							num2 = 531;
							continue;
						}
						goto IL_62C0;
					case 23:
						num7 = NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
						num2 = 209;
						continue;
					case 24:
						array[14] = 109 + 79;
						num2 = 553;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 651;
							continue;
						}
						continue;
					case 25:
						goto IL_1BBC;
					case 26:
						array7[num15 + 7] = array8[7];
						num2 = 466;
						continue;
					case 27:
						goto IL_5350;
					case 28:
						array9[6] = 239 - 79;
						num2 = 204;
						continue;
					case 29:
						array5 = array9;
						num2 = 59;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 49;
							continue;
						}
						continue;
					case 30:
						num3 = 64 + 55;
						num2 = 139;
						continue;
					case 31:
						num16 = 0L;
						num2 = 401;
						continue;
					case 32:
						if ((array10 = array11) != null)
						{
							num2 = 643;
							continue;
						}
						goto IL_2BB6;
					case 33:
						array9[13] = (byte)num3;
						num2 = 130;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 111;
							continue;
						}
						continue;
					case 34:
						goto IL_5E87;
					case 35:
						num3 = 135 - 51;
						num2 = 51;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 68;
							continue;
						}
						continue;
					case 36:
						goto IL_0EE6;
					case 37:
						array9[9] = 24 + 124;
						num2 = 288;
						continue;
					case 38:
						array[26] = (byte)num6;
						num2 = 355;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 31;
							continue;
						}
						continue;
					case 39:
						if (num17 != 4)
						{
							goto IL_1518;
						}
						num2 = 13;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 40:
						goto IL_3BBB;
					case 41:
						array[28] = 133 + 64;
						num2 = 380;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 642;
							continue;
						}
						continue;
					case 42:
						array9[4] = 68 + 51;
						num2 = 470;
						continue;
					case 43:
						num9 = 0;
						num2 = 450;
						continue;
					case 44:
					{
						uint num18;
						if (num18 == 4109628145U)
						{
							num2 = 301;
							continue;
						}
						goto IL_3AF0;
					}
					case 45:
						goto IL_588E;
					case 46:
						goto IL_50E4;
					case 47:
						array9[1] = 39 + 110;
						num2 = 60;
						continue;
					case 48:
						array[14] = (byte)num6;
						num2 = 24;
						continue;
					case 49:
						array[24] = (byte)num6;
						num2 = 6;
						continue;
					case 50:
						array[21] = 88 + 2;
						num2 = 329;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 122;
							continue;
						}
						continue;
					case 51:
					{
						string text = NrkKTZ6esAiaRtQKtm.xeGQ6B7aDT9HUfX8g49(NrkKTZ6esAiaRtQKtm.om84eC7o9qiyESD4q6O(), array12);
						num2 = 569;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 497;
							continue;
						}
						continue;
					}
					case 52:
						goto IL_3203;
					case 53:
						goto IL_0E68;
					case 54:
						array[26] = (byte)num6;
						num2 = 309;
						continue;
					case 55:
						goto IL_1E93;
					case 56:
						array[7] = (byte)num6;
						num2 = 500;
						continue;
					case 57:
						array[3] = (byte)num6;
						num2 = 229;
						continue;
					case 58:
						array7[num15 + 3] = array13[3];
						num2 = 360;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 496;
							continue;
						}
						continue;
					case 59:
						NrkKTZ6esAiaRtQKtm.vAjeWpAOuh3HSdWlUax(array5);
						num2 = 120;
						continue;
					case 60:
						num3 = 237 - 79;
						num2 = 275;
						continue;
					case 61:
						array9[10] = (byte)num3;
						num2 = 635;
						continue;
					case 62:
						goto IL_3D38;
					case 63:
						num6 = 105 + 98;
						num2 = 636;
						continue;
					case 64:
						array[17] = (byte)num6;
						num2 = 490;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 639;
							continue;
						}
						continue;
					case 65:
						array9[5] = (byte)num3;
						num2 = 345;
						continue;
					case 66:
						num6 = 66 + 20;
						num2 = 56;
						continue;
					case 67:
						array14[5] = 116;
						num2 = 523;
						continue;
					case 68:
						array9[11] = (byte)num3;
						num2 = 91;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 107;
							continue;
						}
						continue;
					case 69:
						array9[3] = 5 + 82;
						num2 = 60;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 473;
							continue;
						}
						continue;
					case 70:
						array9[0] = 140 + 92;
						num2 = 47;
						continue;
					case 71:
						goto IL_6231;
					case 72:
						try
						{
							for (;;)
							{
								IL_4068:
								IEnumerator enumerator;
								if (NrkKTZ6esAiaRtQKtm.FNolyTAFH7yE1u3RYcI(enumerator))
								{
									goto IL_3FE5;
								}
								int num19 = 2;
								ProcessModule processModule;
								for (;;)
								{
									IL_3EED:
									Version version2;
									Version version3;
									switch (num19)
									{
									case 0:
										goto IL_400C;
									case 1:
										goto IL_3FFD;
									case 2:
										goto IL_40B6;
									case 3:
										break;
									case 4:
									{
										Version version = new Version(4, 0, 30319, 17921);
										num19 = 0;
										if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
										{
											num19 = 0;
											continue;
										}
										continue;
									}
									case 5:
									{
										Version version;
										if (!NrkKTZ6esAiaRtQKtm.wBoLRGAHm8ZlmLXUVa6(version2, version))
										{
											num19 = 7;
											continue;
										}
										goto IL_407E;
									}
									case 6:
										goto IL_4068;
									case 7:
										goto IL_4024;
									case 8:
										goto IL_3F99;
									case 9:
										if (!NrkKTZ6esAiaRtQKtm.PNRPUNA84FW3jGVUk9S(NrkKTZ6esAiaRtQKtm.DHdG92ASWeOae0yvhdN(NrkKTZ6esAiaRtQKtm.EWaLtRAg4QbrftSwNiX(processModule)), "clrjit.dll"))
										{
											num19 = 8;
											continue;
										}
										break;
									case 10:
										goto IL_3FE5;
									case 11:
										goto IL_407E;
									case 12:
										version3 = new Version(4, 0, 30319, 17020);
										num19 = 4;
										if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
										{
											num19 = 4;
											continue;
										}
										continue;
									default:
										goto IL_400C;
									}
									version2 = new Version(NrkKTZ6esAiaRtQKtm.dbdghlAWx5v0IRVWvRx(NrkKTZ6esAiaRtQKtm.TE6qIqAk33v0uBRcUar(processModule)), NrkKTZ6esAiaRtQKtm.glAcntA2920XxjWCob8(NrkKTZ6esAiaRtQKtm.TE6qIqAk33v0uBRcUar(processModule)), NrkKTZ6esAiaRtQKtm.Cyx4ghA9xeU1w10FIlV(NrkKTZ6esAiaRtQKtm.TE6qIqAk33v0uBRcUar(processModule)), NrkKTZ6esAiaRtQKtm.HaMA5FARhWVpfuEU4lv(NrkKTZ6esAiaRtQKtm.TE6qIqAk33v0uBRcUar(processModule)));
									num19 = 12;
									continue;
									IL_400C:
									if (NrkKTZ6esAiaRtQKtm.oG0CQfA3KKZcVfUyhFS(version2, version3))
									{
										num19 = 5;
										continue;
									}
									break;
									IL_407E:
									NrkKTZ6esAiaRtQKtm.olCwkV4YYa = true;
									num19 = 1;
									if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
									{
										num19 = 0;
									}
								}
								IL_3F99:
								IL_4024:
								continue;
								IL_3FE5:
								processModule = (ProcessModule)NrkKTZ6esAiaRtQKtm.nR0cYyAQ4K3Z4tVVWq2(enumerator);
								num19 = 9;
								goto IL_3EED;
							}
							IL_3FFD:
							IL_40B6:
							goto IL_1792;
						}
						finally
						{
							IEnumerator enumerator;
							IDisposable disposable = enumerator as IDisposable;
							int num20 = 0;
							if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
							{
								num20 = 0;
							}
							for (;;)
							{
								switch (num20)
								{
								case 1:
									goto IL_40FC;
								case 2:
									goto IL_412C;
								case 3:
									goto IL_413D;
								}
								if (disposable == null)
								{
									num20 = 1;
									if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
									{
										num20 = 1;
										continue;
									}
									continue;
								}
								IL_412C:
								NrkKTZ6esAiaRtQKtm.jsv1mEAdkunBYUkM1Rn(disposable);
								num20 = 3;
							}
							IL_40FC:
							IL_413D:;
						}
						goto IL_4158;
					case 73:
						NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(intPtr3, 4, num12, ref num12);
						num2 = 551;
						continue;
					case 74:
						num6 = 184 - 61;
						num2 = 199;
						continue;
					case 75:
						goto IL_215D;
					case 76:
						goto IL_0AEB;
					case 77:
						array9[14] = (byte)num3;
						num2 = 163;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 66;
							continue;
						}
						continue;
					case 78:
						array[24] = (byte)num6;
						num2 = 403;
						continue;
					case 79:
						array[21] = (byte)num6;
						num2 = 41;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 518;
							continue;
						}
						continue;
					case 80:
						array[8] = (byte)num6;
						num2 = 376;
						continue;
					case 81:
					{
						NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv gwgifTc71BJOaot4wBv;
						gwgifTc71BJOaot4wBv.Xo1cXJIe5g = flag;
						num2 = 475;
						continue;
					}
					case 82:
						goto IL_0CB6;
					case 83:
						NrkKTZ6esAiaRtQKtm.ylUcPYTQiJ = NrkKTZ6esAiaRtQKtm.IsN7ON7rELBVWuoirRc(NrkKTZ6esAiaRtQKtm.vGlcKhef2Q);
						num2 = 497;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 78;
							continue;
						}
						continue;
					case 84:
						return;
					case 85:
						goto IL_1F2B;
					case 86:
						array7[num21 + 2] = array13[2];
						num2 = 436;
						continue;
					case 87:
						goto IL_58C3;
					case 88:
						array7[num15 + 6] = array15[6];
						num2 = 71;
						continue;
					case 89:
						goto IL_18AD;
					case 90:
						array6[num13 + 1] = (byte)((num14 & 65280U) >> 8);
						num2 = 18;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 6;
							continue;
						}
						continue;
					case 91:
						array[17] = (byte)num6;
						num2 = 118;
						continue;
					case 92:
						array[19] = 92 + 31;
						num2 = 481;
						continue;
					case 93:
						try
						{
							IEnumerator enumerator = NrkKTZ6esAiaRtQKtm.AeUd07Aq77qVf9OujI1(NrkKTZ6esAiaRtQKtm.t01rQPAboeDYqJbyrI6(process));
							int num22 = 0;
							if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
							{
								num22 = 0;
							}
							switch (num22)
							{
							default:
								try
								{
									for (;;)
									{
										IL_342C:
										if (NrkKTZ6esAiaRtQKtm.FNolyTAFH7yE1u3RYcI(enumerator))
										{
											goto IL_3404;
										}
										int num23 = 3;
										ProcessModule processModule2;
										for (;;)
										{
											IL_331C:
											switch (num23)
											{
											case 0:
												goto IL_33BD;
											case 1:
												break;
											case 2:
												goto IL_3442;
											case 3:
												goto IL_347E;
											case 4:
												goto IL_3455;
											case 5:
												goto IL_334E;
											case 6:
												goto IL_3404;
											case 7:
												goto IL_342C;
											case 8:
											{
												long num24 = num16;
												intPtr = NrkKTZ6esAiaRtQKtm.t2bLlNAXi1DAdbdhun3(processModule2);
												if (num24 > intPtr.ToInt64() + (long)NrkKTZ6esAiaRtQKtm.Jwf9vx77V1xBvv0MOll(processModule2))
												{
													num23 = 4;
													continue;
												}
												goto IL_342C;
											}
											case 9:
												NrkKTZ6esAiaRtQKtm.M6gF7iAMHtHL3jGtWkK();
												num23 = 2;
												if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
												{
													num23 = 2;
													continue;
												}
												continue;
											default:
												goto IL_33BD;
											}
											IL_336D:
											long num25 = num16;
											intPtr = NrkKTZ6esAiaRtQKtm.t2bLlNAXi1DAdbdhun3(processModule2);
											if (num25 >= intPtr.ToInt64())
											{
												num23 = 8;
												if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
												{
													num23 = 6;
													continue;
												}
												continue;
											}
											IL_3455:
											if (NrkKTZ6esAiaRtQKtm.CbxZs27pIWcaU4iABVk(NrkKTZ6esAiaRtQKtm.SqVCLY7Xb5VkF0I5ceo(NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm).TypeHandle).Assembly), null))
											{
												num23 = 9;
												continue;
											}
											break;
											IL_33BD:
											if (NrkKTZ6esAiaRtQKtm.PNRPUNA84FW3jGVUk9S(NrkKTZ6esAiaRtQKtm.EWaLtRAg4QbrftSwNiX(processModule2), text2))
											{
												goto IL_336D;
											}
											num23 = 5;
										}
										IL_334E:
										continue;
										IL_3404:
										processModule2 = (ProcessModule)NrkKTZ6esAiaRtQKtm.nR0cYyAQ4K3Z4tVVWq2(enumerator);
										num23 = 0;
										if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
										{
											num23 = 0;
											goto IL_331C;
										}
										goto IL_331C;
									}
									IL_3442:
									return;
									IL_347E:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num26 = 2;
									int num27 = num26;
									for (;;)
									{
										switch (num27)
										{
										default:
											NrkKTZ6esAiaRtQKtm.jsv1mEAdkunBYUkM1Rn(disposable);
											num27 = 1;
											if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
											{
												num27 = 1;
											}
											break;
										case 1:
											goto IL_34F6;
										case 2:
											if (disposable == null)
											{
												goto IL_34F6;
											}
											num27 = 0;
											if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
											{
												num27 = 0;
											}
											break;
										}
									}
									IL_34F6:;
								}
								break;
							case 1:
								break;
							}
							goto IL_1CD8;
						}
						catch
						{
							int num28 = 0;
							if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
							{
								num28 = 0;
							}
							switch (num28)
							{
							default:
								goto IL_1CD8;
							}
						}
						goto IL_3556;
					case 94:
						array5[9] = array16[4];
						num2 = 271;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 577;
							continue;
						}
						continue;
					case 95:
						flag = true;
						num2 = 649;
						continue;
					case 96:
					{
						IEnumerator enumerator = NrkKTZ6esAiaRtQKtm.AeUd07Aq77qVf9OujI1(NrkKTZ6esAiaRtQKtm.t01rQPAboeDYqJbyrI6(NrkKTZ6esAiaRtQKtm.VMwD0dAALomuQFfWUgL()));
						num2 = 72;
						continue;
					}
					case 97:
						num29 = 0U;
						num2 = 264;
						continue;
					case 98:
						array[1] = (byte)num6;
						num2 = 390;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 410;
							continue;
						}
						continue;
					case 99:
						array[10] = (byte)num6;
						num2 = 607;
						continue;
					case 100:
					{
						NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv gwgifTc71BJOaot4wBv2 = default(NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv);
						num2 = 368;
						continue;
					}
					case 101:
						array14[4] = 105;
						num2 = 67;
						continue;
					case 102:
						array[7] = (byte)num6;
						num2 = 425;
						continue;
					case 103:
						num6 = 223 - 74;
						num2 = 141;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 193;
							continue;
						}
						continue;
					case 104:
						num6 = 186 - 62;
						num2 = 494;
						continue;
					case 105:
						break;
					case 106:
						goto IL_1298;
					case 107:
						array9[12] = 199 - 66;
						num2 = 175;
						continue;
					case 108:
						array9[7] = 10 + 64;
						num2 = 141;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 555;
							continue;
						}
						continue;
					case 109:
						if (num30 <= 0)
						{
							goto IL_21D2;
						}
						num2 = 126;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 73;
							continue;
						}
						continue;
					case 110:
						array9[13] = 48 + 96;
						num2 = 387;
						continue;
					case 111:
						array[4] = (byte)num6;
						num2 = 16;
						continue;
					case 112:
						array14[7] = 100;
						num2 = 168;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 181;
							continue;
						}
						continue;
					case 113:
						NrkKTZ6esAiaRtQKtm.M6gF7iAMHtHL3jGtWkK();
						num2 = 212;
						continue;
					case 114:
						array9[7] = (byte)num3;
						num2 = 108;
						continue;
					case 115:
						try
						{
							IEnumerator enumerator = NrkKTZ6esAiaRtQKtm.AeUd07Aq77qVf9OujI1(NrkKTZ6esAiaRtQKtm.t01rQPAboeDYqJbyrI6(process));
							int num31 = 0;
							if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
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
										IL_4E8B:
										if (NrkKTZ6esAiaRtQKtm.FNolyTAFH7yE1u3RYcI(enumerator))
										{
											goto IL_4E6E;
										}
										int num32 = 0;
										if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
										{
											num32 = 0;
										}
										for (;;)
										{
											IL_4E2F:
											switch (num32)
											{
											case 1:
												goto IL_4E6E;
											case 3:
												if (intPtr.ToInt64() == NrkKTZ6esAiaRtQKtm.vGlcKhef2Q)
												{
													num32 = 5;
													continue;
												}
												goto IL_4E8B;
											case 4:
												goto IL_4E8B;
											case 5:
												num33 = 0;
												num32 = 2;
												if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
												{
													num32 = 0;
													continue;
												}
												continue;
											}
											goto Block_320;
										}
										IL_4E6E:
										intPtr = NrkKTZ6esAiaRtQKtm.t2bLlNAXi1DAdbdhun3((ProcessModule)NrkKTZ6esAiaRtQKtm.nR0cYyAQ4K3Z4tVVWq2(enumerator));
										num32 = 3;
										goto IL_4E2F;
									}
									Block_320:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num34 = 1;
									if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
									{
										num34 = 1;
									}
									for (;;)
									{
										switch (num34)
										{
										case 1:
											if (disposable == null)
											{
												num34 = 2;
												continue;
											}
											break;
										case 2:
											goto IL_4F32;
										case 3:
											goto IL_4F72;
										}
										NrkKTZ6esAiaRtQKtm.jsv1mEAdkunBYUkM1Rn(disposable);
										num34 = 2;
										if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
										{
											num34 = 3;
										}
									}
									IL_4F32:
									IL_4F72:;
								}
								break;
							}
							goto IL_249C;
						}
						catch
						{
							int num35 = 0;
							if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
							{
								num35 = 0;
							}
							switch (num35)
							{
							default:
								goto IL_249C;
							}
						}
						goto IL_4FDE;
					case 116:
						num6 = 111 + 55;
						num2 = 336;
						continue;
					case 117:
						num6 = 190 - 63;
						num2 = 568;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 435;
							continue;
						}
						continue;
					case 118:
						array[18] = 178 - 59;
						num2 = 344;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 467;
							continue;
						}
						continue;
					case 119:
						num6 = 136 - 45;
						num2 = 641;
						continue;
					case 120:
						array16 = NrkKTZ6esAiaRtQKtm.xVb6HbAmwLmNZr2ORAq(NrkKTZ6esAiaRtQKtm.tFKydDA4VY7rk2m8iEN(NrkKTZ6esAiaRtQKtm.EONwWqrt4G));
						num2 = 143;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 620;
							continue;
						}
						continue;
					case 121:
						goto IL_63C0;
					case 122:
						array7[num21 + 3] = array15[3];
						num2 = 236;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 203;
							continue;
						}
						continue;
					case 123:
						array9[0] = 32 + 36;
						num2 = 596;
						continue;
					case 124:
						goto IL_44AD;
					case 125:
						array[27] = (byte)num6;
						num2 = 357;
						continue;
					case 126:
						num36 += num4;
						num2 = 7;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 548;
							continue;
						}
						continue;
					case 127:
						array[12] = 137 - 69;
						num2 = 208;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 99;
							continue;
						}
						continue;
					case 128:
						array[11] = 14 - 11;
						num2 = 237;
						continue;
					case 129:
						array5[5] = array16[2];
						num2 = 12;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 245;
							continue;
						}
						continue;
					case 130:
						array9[13] = 63 + 117;
						num2 = 192;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 247;
							continue;
						}
						continue;
					case 131:
						array7[num21 + 3] = array8[3];
						num2 = 406;
						continue;
					case 132:
						goto IL_3C85;
					case 133:
						num3 = 245 - 81;
						num2 = 77;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 134:
						array[30] = 109 - 0;
						num2 = 223;
						continue;
					case 135:
						array[5] = (byte)num6;
						num2 = 244;
						continue;
					case 136:
						array[31] = (byte)num6;
						num2 = 33;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 189;
							continue;
						}
						continue;
					case 137:
						array[8] = (byte)num6;
						num2 = 74;
						continue;
					case 138:
						array[5] = (byte)num6;
						num2 = 154;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 156;
							continue;
						}
						continue;
					case 139:
						array9[13] = (byte)num3;
						num2 = 629;
						continue;
					case 140:
						array12[1] = 101;
						num2 = 207;
						continue;
					case 141:
						goto IL_24BC;
					case 142:
						NrkKTZ6esAiaRtQKtm.PbontVAE7QLbRKOoYw9(new IntPtr((void*)(&num37)), 0, 0);
						num2 = 479;
						continue;
					case 143:
						if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() != 4)
						{
							num2 = 159;
							continue;
						}
						goto IL_43F0;
					case 144:
						array14[0] = 109;
						num2 = 316;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 582;
							continue;
						}
						continue;
					case 145:
						array[28] = (byte)num6;
						num2 = 41;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 9;
							continue;
						}
						continue;
					case 146:
					{
						uint num18 = 4059231220U;
						num2 = 163;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 285;
							continue;
						}
						continue;
					}
					case 147:
						array[18] = (byte)num6;
						num2 = 637;
						continue;
					case 148:
						array[9] = 217 - 72;
						num2 = 232;
						continue;
					case 149:
						array[16] = 163 - 94;
						num2 = 16;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 225;
							continue;
						}
						continue;
					case 150:
						NrkKTZ6esAiaRtQKtm.zPT0TU78e0Sy8C0psPM(NrkKTZ6esAiaRtQKtm.rShspo7S7lnxvP14FZr(NrkKTZ6esAiaRtQKtm.rB2rgR7jW080wPr00Qs(NrkKTZ6esAiaRtQKtm.R3TccymhsI)));
						num2 = 452;
						continue;
					case 151:
						array9[2] = 42 + 41;
						num2 = 621;
						continue;
					case 152:
						array7[num21 + 1] = array8[1];
						num2 = 338;
						continue;
					case 153:
						num6 = 206 - 68;
						num2 = 80;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 44;
							continue;
						}
						continue;
					case 154:
						array9 = new byte[16];
						num2 = 263;
						continue;
					case 155:
						num6 = 20 + 72;
						num2 = 14;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 54;
							continue;
						}
						continue;
					case 156:
						array[6] = 10 + 64;
						num2 = 276;
						continue;
					case 157:
						num6 = 204 - 68;
						num2 = 302;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 371;
							continue;
						}
						continue;
					case 158:
						NrkKTZ6esAiaRtQKtm.NurcL0ANH498TQAqJh3(new byte[1], 0, NrkKTZ6esAiaRtQKtm.ahl7lBAxFgBEoa4DKBN(8), 1);
						num2 = 552;
						continue;
					case 159:
					{
						byte[] array17 = new byte[40];
						NrkKTZ6esAiaRtQKtm.s0BEXW7k7aRXEGSyObx(array17, fieldof(<PrivateImplementationDetails>{42BEE363-006E-4CC6-8E6F-037BFE8EA111}.0E448EF5E5E60630BDDB19388CB6378436E3C65D03DD66DA7C6EBFF563BD857A).FieldHandle);
						array18 = array17;
						num2 = 477;
						continue;
					}
					case 160:
						array9[5] = (byte)num3;
						num2 = 2;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 161:
						num6 = 88 + 81;
						num2 = 99;
						continue;
					case 162:
						array7[num15 + 7] = array13[7];
						num2 = 346;
						continue;
					case 163:
						array9[14] = 204 - 68;
						num2 = 203;
						continue;
					case 164:
						num3 = 235 - 78;
						num2 = 595;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 548;
							continue;
						}
						continue;
					case 165:
						array14[0] = 99;
						num2 = 570;
						continue;
					case 166:
						array11 = array6;
						num2 = 554;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 440;
							continue;
						}
						continue;
					case 167:
						NrkKTZ6esAiaRtQKtm.R3TccymhsI = new NrkKTZ6esAiaRtQKtm.Ul6C5Wc5dVDuS4vTZwm(NrkKTZ6esAiaRtQKtm.wUTwUWMQ5Z);
						num2 = 652;
						continue;
					case 168:
						goto IL_1C87;
					case 169:
						num38 = intPtr.ToInt64();
						num2 = 26;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 268;
							continue;
						}
						continue;
					case 170:
					{
						int num39 = NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt) - num33;
						num2 = 304;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 303;
							continue;
						}
						continue;
					}
					case 171:
						num40 = array2.Length / 4;
						num2 = 270;
						continue;
					case 172:
						num6 = 78 + 114;
						num2 = 644;
						continue;
					case 173:
						array14[7] = 116;
						num2 = 575;
						continue;
					case 174:
						num6 = 113 + 50;
						num2 = 135;
						continue;
					case 175:
						array9[12] = 191 - 63;
						num2 = 468;
						continue;
					case 176:
						goto IL_49BD;
					case 177:
						array7[num21 + 1] = array15[1];
						num2 = 305;
						continue;
					case 178:
						num6 = 105 + 100;
						num2 = 137;
						continue;
					case 179:
						NrkKTZ6esAiaRtQKtm.soYsgQA06V8yehpT14e(NrkKTZ6esAiaRtQKtm.cX6V89A67Bf1WQBFq6o(z2G3P3cj94OxNl7aFlt), 0L);
						num2 = 514;
						continue;
					case 180:
						array[20] = 51 + 10;
						num2 = 108;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 325;
							continue;
						}
						continue;
					case 181:
						array14[8] = 108;
						num2 = 41;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 454;
							continue;
						}
						continue;
					case 182:
						num6 = 221 - 73;
						num2 = 348;
						continue;
					case 183:
					{
						MemoryStream memoryStream = new MemoryStream();
						ICryptoTransform cryptoTransform;
						cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
						byte[] array4;
						NrkKTZ6esAiaRtQKtm.WfL0FF7PFl1bDhck6RM(cryptoStream, array4, 0, array4.Length);
						NrkKTZ6esAiaRtQKtm.OtgQxj7TKCQpLkrBeEs(cryptoStream);
						array11 = NrkKTZ6esAiaRtQKtm.oTZhuI7lK78h2uhYKdA(memoryStream);
						NrkKTZ6esAiaRtQKtm.kb80KtAGwvVKBEPLSp8(array5, 0, array5.Length);
						NrkKTZ6esAiaRtQKtm.RWSOey7sGwvsHJfIcl9(memoryStream);
						num2 = 405;
						continue;
					}
					case 184:
						num6 = 245 - 81;
						num2 = 334;
						continue;
					case 185:
						array9[9] = (byte)num3;
						num2 = 252;
						continue;
					case 186:
						num13 = num9 * 4;
						num2 = 611;
						continue;
					case 187:
						goto IL_3715;
					case 188:
						goto IL_469F;
					case 189:
						goto IL_6082;
					case 190:
						goto IL_19F3;
					case 191:
						array = new byte[32];
						num2 = 217;
						continue;
					case 192:
						array7[num15 + 1] = array15[1];
						num2 = 168;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 428;
							continue;
						}
						continue;
					case 193:
						array[18] = (byte)num6;
						num2 = 54;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 522;
							continue;
						}
						continue;
					case 194:
					{
						byte[] array4 = NrkKTZ6esAiaRtQKtm.bPw9SSAZ5q9nT1ixgmo(z2G3P3cj94OxNl7aFlt, (int)NrkKTZ6esAiaRtQKtm.WxT56pALYLZvOtSnxXs(NrkKTZ6esAiaRtQKtm.cX6V89A67Bf1WQBFq6o(z2G3P3cj94OxNl7aFlt)));
						num2 = 155;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 191;
							continue;
						}
						continue;
					}
					case 195:
						num6 = 207 - 69;
						num2 = 457;
						continue;
					case 196:
						if (NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(intPtr4, 4, 4, ref num12) == 0)
						{
							goto Block_240;
						}
						goto IL_17B2;
					case 197:
						array9[9] = 119 + 16;
						num2 = 297;
						continue;
					case 198:
						num6 = 215 - 71;
						num2 = 145;
						continue;
					case 199:
						array[8] = (byte)num6;
						num2 = 153;
						continue;
					case 200:
						goto IL_17B2;
					case 201:
						num8++;
						num2 = 453;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 174;
							continue;
						}
						continue;
					case 202:
						num3 = 118 + 69;
						num2 = 565;
						continue;
					case 203:
						num3 = 126 + 120;
						num2 = 576;
						continue;
					case 204:
						num3 = 129 - 43;
						num2 = 222;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 199;
							continue;
						}
						continue;
					case 205:
						array9[3] = (byte)num3;
						num2 = 417;
						continue;
					case 206:
						goto IL_0CA3;
					case 207:
						array12[2] = 116;
						num2 = 411;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 385;
							continue;
						}
						continue;
					case 208:
						array[13] = 241 - 80;
						num2 = 295;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 27;
							continue;
						}
						continue;
					case 209:
						num17 = NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
						num2 = 39;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 7;
							continue;
						}
						continue;
					case 210:
						goto IL_21D2;
					case 211:
						array[0] = 163 - 54;
						num2 = 356;
						continue;
					case 212:
						return;
					case 213:
						array14 = new byte[10];
						num2 = 165;
						continue;
					case 214:
						goto IL_23F2;
					case 215:
						num3 = 146 - 48;
						num2 = 231;
						continue;
					case 216:
						num6 = 26 + 72;
						num2 = 359;
						continue;
					case 217:
						num6 = 129 - 43;
						num2 = 221;
						continue;
					case 218:
						array[17] = (byte)num6;
						num2 = 253;
						continue;
					case 219:
						array[24] = (byte)num6;
						num2 = 63;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 1;
							continue;
						}
						continue;
					case 220:
					{
						int num42;
						NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(new IntPtr(num41), NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12(), 64, ref num42);
						num2 = 8;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 8;
							continue;
						}
						continue;
					}
					case 221:
						array[0] = (byte)num6;
						num2 = 286;
						continue;
					case 222:
						array9[6] = (byte)num3;
						num2 = 292;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 115;
							continue;
						}
						continue;
					case 223:
						num6 = 58 + 19;
						num2 = 654;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 482;
							continue;
						}
						continue;
					case 224:
						num3 = 243 - 81;
						num2 = 402;
						continue;
					case 225:
						goto IL_13AF;
					case 226:
						goto IL_14B7;
					case 227:
						array[6] = (byte)num6;
						num2 = 10;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 66;
							continue;
						}
						continue;
					case 228:
						array9[14] = 136 - 45;
						num2 = 77;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 133;
							continue;
						}
						continue;
					case 229:
						array[3] = 162 - 54;
						num2 = 615;
						continue;
					case 230:
						goto IL_4FDE;
					case 231:
						array9[3] = (byte)num3;
						num2 = 69;
						continue;
					case 232:
						array[9] = 125 - 15;
						num2 = 161;
						continue;
					case 233:
						array14[5] = 106;
						num2 = 369;
						continue;
					case 234:
						goto IL_25CA;
					case 235:
						array7[num15 + 2] = array8[2];
						num2 = 469;
						continue;
					case 236:
						num21 = 23;
						num2 = 562;
						continue;
					case 237:
						array[12] = 115 + 57;
						num2 = 500;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 638;
							continue;
						}
						continue;
					case 238:
						goto IL_43F0;
					case 239:
						goto IL_30AD;
					case 240:
						array[7] = 45 + 77;
						num2 = 526;
						continue;
					case 241:
						array[11] = 63 + 117;
						num2 = 511;
						continue;
					case 242:
						array9[2] = 94 + 10;
						num2 = 151;
						continue;
					case 243:
						array[20] = (byte)num6;
						num2 = 50;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 2;
							continue;
						}
						continue;
					case 244:
						num6 = 56 + 27;
						num2 = 535;
						continue;
					case 245:
						array5[7] = array16[3];
						num2 = 94;
						continue;
					case 246:
						goto IL_3A74;
					case 247:
						array9[13] = 106 - 0;
						num2 = 228;
						continue;
					case 248:
						goto IL_1204;
					case 249:
						goto IL_218B;
					case 250:
						goto IL_58C3;
					case 251:
						goto IL_2BB6;
					case 252:
						array9[10] = 234 - 78;
						num2 = 463;
						continue;
					case 253:
						goto IL_1088;
					case 254:
						num6 = 164 - 54;
						num2 = 259;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 414;
							continue;
						}
						continue;
					case 255:
						array9[4] = (byte)num3;
						num2 = 476;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 1;
							continue;
						}
						continue;
					case 256:
						array[13] = (byte)num6;
						num2 = 268;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 427;
							continue;
						}
						continue;
					case 257:
					{
						int num43 = NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
						num2 = 351;
						continue;
					}
					case 258:
						goto IL_0CA3;
					case 259:
						goto IL_215D;
					case 260:
						goto IL_0EF8;
					case 261:
						array7[num21] = array15[0];
						num2 = 24;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 177;
							continue;
						}
						continue;
					case 262:
						num6 = 177 - 59;
						num2 = 125;
						continue;
					case 263:
						num3 = 129 - 43;
						num2 = 182;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 324;
							continue;
						}
						continue;
					case 264:
						if (num30 > 0)
						{
							goto Block_189;
						}
						goto IL_42A1;
					case 265:
						num44++;
						num2 = 408;
						continue;
					case 266:
						array9[5] = 92 + 78;
						num2 = 491;
						continue;
					case 267:
						try
						{
							NrkKTZ6esAiaRtQKtm.q54cwIo8a7 = (NrkKTZ6esAiaRtQKtm.Ul6C5Wc5dVDuS4vTZwm)NrkKTZ6esAiaRtQKtm.HZDmWp7CGAH1eQ5PJAZ(new IntPtr(num16), NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm.Ul6C5Wc5dVDuS4vTZwm).TypeHandle));
							int num45 = 0;
							if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
							{
								num45 = 0;
							}
							switch (num45)
							{
							default:
								goto IL_5350;
							}
						}
						catch
						{
							int num46 = 1;
							if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
							{
								num46 = 1;
							}
							switch (num46)
							{
							case 1:
								try
								{
									Delegate @delegate = NrkKTZ6esAiaRtQKtm.HZDmWp7CGAH1eQ5PJAZ(new IntPtr(num16), NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm.Ul6C5Wc5dVDuS4vTZwm).TypeHandle));
									int num47 = 0;
									if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
									{
										num47 = 0;
									}
									for (;;)
									{
										switch (num47)
										{
										default:
											NrkKTZ6esAiaRtQKtm.q54cwIo8a7 = (NrkKTZ6esAiaRtQKtm.Ul6C5Wc5dVDuS4vTZwm)NrkKTZ6esAiaRtQKtm.LUkGW87MQOprq1SRgH7(NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm.Ul6C5Wc5dVDuS4vTZwm).TypeHandle), NrkKTZ6esAiaRtQKtm.rB2rgR7jW080wPr00Qs(@delegate));
											num47 = 1;
											if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
											{
												num47 = 1;
											}
											break;
										case 1:
											goto IL_4B36;
										}
									}
									IL_4B36:;
								}
								catch
								{
									int num48 = 0;
									if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
									{
										num48 = 0;
									}
									switch (num48)
									{
									}
								}
								break;
							}
							goto IL_5350;
						}
						goto IL_4BA6;
					case 268:
						num12 = 0;
						num2 = 552;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 626;
							continue;
						}
						continue;
					case 269:
						array12[4] = 105;
						num2 = 489;
						continue;
					case 270:
						num36 = 0U;
						num2 = 350;
						continue;
					case 271:
						NrkKTZ6esAiaRtQKtm.a3d2Ey7eugDdcg6n1Zc(z2G3P3cj94OxNl7aFlt);
						num2 = 7;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 7;
							continue;
						}
						continue;
					case 272:
						NrkKTZ6esAiaRtQKtm.iqPLMBAaPQJPxSdboai(new IntPtr((void*)(&num37)), 0, IntPtr.Zero);
						num2 = 142;
						continue;
					case 273:
						array[3] = 238 - 79;
						num2 = 546;
						continue;
					case 274:
						goto IL_258B;
					case 275:
						array9[1] = (byte)num3;
						num2 = 14;
						continue;
					case 276:
						array[6] = 158 - 52;
						num2 = 273;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 516;
							continue;
						}
						continue;
					case 277:
						goto IL_1471;
					case 278:
					{
						NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv gwgifTc71BJOaot4wBv2;
						gwgifTc71BJOaot4wBv2.Xo1cXJIe5g = false;
						num2 = 471;
						continue;
					}
					case 279:
						array[22] = (byte)num6;
						num2 = 331;
						continue;
					case 280:
						goto IL_4BD9;
					case 281:
						array9[12] = (byte)num3;
						num2 = 110;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 70;
							continue;
						}
						continue;
					case 282:
						if (num30 > 0)
						{
							num2 = 76;
							continue;
						}
						goto IL_43DF;
					case 283:
						array5[15] = array16[7];
						num2 = 524;
						continue;
					case 284:
						intPtr5 = NrkKTZ6esAiaRtQKtm.cTaiIg7ncphORkW2iWc(56U, 1, (uint)NrkKTZ6esAiaRtQKtm.HCkIck7uPWSbnyHfQb2(NrkKTZ6esAiaRtQKtm.VMwD0dAALomuQFfWUgL()));
						num2 = 332;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 40;
							continue;
						}
						continue;
					case 285:
						num37 = 0L;
						num2 = 314;
						continue;
					case 286:
						num6 = 215 - 71;
						num2 = 624;
						continue;
					case 287:
						goto IL_5389;
					case 288:
						num3 = 36 + 40;
						num2 = 633;
						continue;
					case 289:
						intPtr6 = NrkKTZ6esAiaRtQKtm.yYt8op7AZgfCeUG8RAy(NrkKTZ6esAiaRtQKtm.R3TccymhsI);
						num2 = 31;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 290:
						goto IL_5389;
					case 291:
						NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(intPtr2, num11 * 4, num12, ref num12);
						num2 = 125;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 176;
							continue;
						}
						continue;
					case 292:
						num3 = 50 + 101;
						num2 = 0;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 293:
						num10 = array3.Length / 4;
						num2 = 431;
						continue;
					case 294:
						goto IL_26B2;
					case 295:
						goto IL_5F6C;
					case 296:
						goto IL_2DF4;
					case 297:
						num3 = 45 + 77;
						num2 = 393;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 598;
							continue;
						}
						continue;
					case 298:
						goto IL_218B;
					case 299:
						goto IL_4701;
					case 300:
						goto IL_0D1A;
					case 301:
						if (NrkKTZ6esAiaRtQKtm.eoYHxUAju60iXCXL07k(NrkKTZ6esAiaRtQKtm.YylhEwApRea97cCN5SE(NrkKTZ6esAiaRtQKtm.t2bLlNAXi1DAdbdhun3(NrkKTZ6esAiaRtQKtm.jDV8PfA7G5hSXOkDBMd(NrkKTZ6esAiaRtQKtm.VMwD0dAALomuQFfWUgL())), "__", 10U), IntPtr.Zero))
						{
							num2 = 616;
							continue;
						}
						goto IL_0EA4;
					case 302:
						array[15] = 112 + 23;
						num2 = 184;
						continue;
					case 303:
						array7[num15 + 6] = array8[6];
						num2 = 10;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 26;
							continue;
						}
						continue;
					case 304:
						goto IL_4BA6;
					case 305:
						array7[num21 + 2] = array15[2];
						num2 = 122;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 79;
							continue;
						}
						continue;
					case 306:
						goto IL_5004;
					case 307:
						goto IL_3715;
					case 308:
						array13 = null;
						num2 = 501;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 196;
							continue;
						}
						continue;
					case 309:
						num6 = 207 + 25;
						num2 = 421;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 504;
							continue;
						}
						continue;
					case 310:
						array[9] = (byte)num6;
						num2 = 558;
						continue;
					case 311:
						num6 = 88 + 45;
						num2 = 248;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 480;
							continue;
						}
						continue;
					case 312:
						if (NrkKTZ6esAiaRtQKtm.HAko2oAJ9roDT1GpQSM(NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm).TypeHandle).Assembly) != null)
						{
							goto IL_4158;
						}
						num2 = 198;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 590;
							continue;
						}
						continue;
					case 313:
						array[9] = 178 - 59;
						num2 = 619;
						continue;
					case 314:
						NrkKTZ6esAiaRtQKtm.NgIR2pAiCMiFmnyf72J(new IntPtr((void*)(&num37)), 0);
						num2 = 372;
						continue;
					case 315:
						array9[2] = (byte)num3;
						num2 = 215;
						continue;
					case 316:
						goto IL_2B9A;
					case 317:
						return;
					case 318:
						goto IL_43DF;
					case 319:
						array[13] = (byte)num6;
						num2 = 21;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 25;
							continue;
						}
						continue;
					case 320:
						num29 = (uint)(((int)array3[(int)(num5 + 3U)] << 24) | ((int)array3[(int)(num5 + 2U)] << 16) | ((int)array3[(int)(num5 + 1U)] << 8) | (int)array3[(int)num5]);
						num2 = 628;
						continue;
					case 321:
						array14[11] = 108;
						num2 = 426;
						continue;
					case 322:
						array6[num13 + 3] = (byte)((num14 & 4278190080U) >> 24);
						num2 = 214;
						continue;
					case 323:
						goto IL_0EA4;
					case 324:
						array9[0] = (byte)num3;
						num2 = 567;
						continue;
					case 325:
						num6 = 208 - 69;
						num2 = 472;
						continue;
					case 326:
					{
						NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv gwgifTc71BJOaot4wBv = default(NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv);
						num2 = 597;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 552;
							continue;
						}
						continue;
					}
					case 327:
						goto IL_238B;
					case 328:
						num6 = 108 + 9;
						num2 = 506;
						continue;
					case 329:
						num6 = 181 - 60;
						num2 = 79;
						continue;
					case 330:
						array[4] = (byte)num6;
						num2 = 423;
						continue;
					case 331:
						goto IL_0D62;
					case 332:
						if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() == 4)
						{
							goto Block_81;
						}
						goto IL_4C86;
					case 333:
						array7[num15 + 5] = array13[5];
						num2 = 238;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 610;
							continue;
						}
						continue;
					case 334:
						array[16] = (byte)num6;
						num2 = 415;
						continue;
					case 335:
						num30 = array3.Length % 4;
						num2 = 293;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 143;
							continue;
						}
						continue;
					case 336:
						array[10] = (byte)num6;
						num2 = 12;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 280;
							continue;
						}
						continue;
					case 337:
						num6 = 138 - 46;
						num2 = 418;
						continue;
					case 338:
						array7[num21 + 2] = array8[2];
						num2 = 131;
						continue;
					case 339:
						num49 = 255U;
						num2 = 364;
						continue;
					case 340:
						array9[15] = (byte)num3;
						num2 = 53;
						continue;
					case 341:
						array9[8] = (byte)num3;
						num2 = 46;
						continue;
					case 342:
						array7[num21 + 1] = array13[1];
						num2 = 86;
						continue;
					case 343:
						array7[num15 + 4] = array8[4];
						num2 = 478;
						continue;
					case 344:
						goto IL_2BC4;
					case 345:
						num3 = 210 - 70;
						num2 = 294;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 388;
							continue;
						}
						continue;
					case 346:
						goto IL_5195;
					case 347:
						num6 = 204 + 19;
						num2 = 219;
						continue;
					case 348:
						array[1] = (byte)num6;
						num2 = 653;
						continue;
					case 349:
						array12[0] = 103;
						num2 = 140;
						continue;
					case 350:
						num4 = 0U;
						num2 = 97;
						continue;
					case 351:
					{
						int num43;
						intPtr2 = new IntPtr(NrkKTZ6esAiaRtQKtm.uTPct1V3IL + (long)num43 - (long)num33);
						num2 = 593;
						continue;
					}
					case 352:
						if (NrkKTZ6esAiaRtQKtm.HAko2oAJ9roDT1GpQSM(NrkKTZ6esAiaRtQKtm.EONwWqrt4G) != null)
						{
							num2 = 553;
							continue;
						}
						goto IL_48B3;
					case 353:
						array[4] = (byte)num6;
						num2 = 517;
						continue;
					case 354:
						goto IL_0EF8;
					case 355:
						array[26] = 129 - 43;
						num2 = 583;
						continue;
					case 356:
						array[0] = 61 - 29;
						num2 = 182;
						continue;
					case 357:
						array[27] = 156 - 52;
						num2 = 310;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 557;
							continue;
						}
						continue;
					case 358:
						goto IL_505B;
					case 359:
						array[29] = (byte)num6;
						num2 = 311;
						continue;
					case 360:
						NrkKTZ6esAiaRtQKtm.su6cTWoWXk = false;
						num2 = 220;
						continue;
					case 361:
						NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(intPtr3, 4, 8, ref num12);
						num2 = 646;
						continue;
					case 362:
						array[14] = 79 + 117;
						num2 = 210;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 434;
							continue;
						}
						continue;
					case 363:
						array[27] = 138 - 46;
						num2 = 274;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 270;
							continue;
						}
						continue;
					case 364:
						num50 = 0;
						num2 = 444;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 235;
							continue;
						}
						continue;
					case 365:
						array15 = NrkKTZ6esAiaRtQKtm.o8NS2u7QF5MriGfVhfx(num16);
						num2 = 33;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 287;
							continue;
						}
						continue;
					case 366:
						goto IL_3728;
					case 367:
						NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
						num2 = 203;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 358;
							continue;
						}
						continue;
					case 368:
					{
						NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv gwgifTc71BJOaot4wBv2;
						gwgifTc71BJOaot4wBv2.tTpcpXCpSj = new byte[] { 42 };
						num2 = 278;
						continue;
					}
					case 369:
						array14[6] = 105;
						num2 = 173;
						continue;
					case 370:
						array13 = NrkKTZ6esAiaRtQKtm.RlmWDN7DYA2g2ldoppl(intPtr6.ToInt32());
						num2 = 587;
						continue;
					case 371:
						goto IL_1C6B;
					case 372:
						NrkKTZ6esAiaRtQKtm.nsU4BIArpqQJYiVyVDT(new IntPtr((void*)(&num37)), 0);
						num2 = 226;
						continue;
					case 373:
						num41 = (long)NrkKTZ6esAiaRtQKtm.TY5MGi7NAV7Qk8aLO8O(intPtr7);
						num2 = 206;
						continue;
					case 374:
						array[3] = 40 + 92;
						num2 = 507;
						continue;
					case 375:
						array[7] = (byte)num6;
						num2 = 240;
						continue;
					case 376:
						num6 = 101 + 34;
						num2 = 455;
						continue;
					case 377:
						num49 <<= 8;
						num2 = 547;
						continue;
					case 378:
						array[23] = 153 - 107;
						num2 = 561;
						continue;
					case 379:
						goto IL_42A1;
					case 380:
						num51 = 0;
						num2 = 187;
						continue;
					case 381:
						array7[num15 + 4] = array15[4];
						num2 = 566;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 159;
							continue;
						}
						continue;
					case 382:
						array[22] = 78 + 44;
						num2 = 172;
						continue;
					case 383:
						array[2] = 31 + 116;
						num2 = 532;
						continue;
					case 384:
						num6 = 222 - 74;
						num2 = 19;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 49;
							continue;
						}
						continue;
					case 385:
						array[7] = (byte)num6;
						num2 = 416;
						continue;
					case 386:
						num3 = 128 + 114;
						num2 = 119;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 185;
							continue;
						}
						continue;
					case 387:
						array9[13] = 158 - 52;
						num2 = 30;
						continue;
					case 388:
						goto IL_3117;
					case 389:
						array[10] = 32 + 95;
						num2 = 20;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 116;
							continue;
						}
						continue;
					case 390:
						array9[8] = (byte)num3;
						num2 = 137;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 197;
							continue;
						}
						continue;
					case 391:
						array[20] = (byte)num6;
						num2 = 600;
						continue;
					case 392:
						goto IL_36E7;
					case 393:
						zero = IntPtr.Zero;
						num2 = 287;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 509;
							continue;
						}
						continue;
					case 394:
						array7[num15 + 3] = array15[3];
						num2 = 212;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 381;
							continue;
						}
						continue;
					case 395:
						goto IL_3556;
					case 396:
						goto IL_1CD8;
					case 397:
						array[7] = (byte)num6;
						num2 = 440;
						continue;
					case 398:
						array9[8] = (byte)num3;
						num2 = 20;
						continue;
					case 399:
						goto IL_3178;
					case 400:
						NrkKTZ6esAiaRtQKtm.jfacnvmZfm = new Hashtable(NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt) + 1);
						num2 = 100;
						continue;
					case 401:
						if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() == 4)
						{
							num2 = 589;
							continue;
						}
						goto IL_1F74;
					case 402:
						array9[12] = (byte)num3;
						num2 = 141;
						continue;
					case 403:
						array[24] = 203 - 67;
						num2 = 299;
						continue;
					case 404:
						return;
					case 405:
						goto IL_47EE;
					case 406:
						num21 = 16;
						num2 = 102;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 261;
							continue;
						}
						continue;
					case 407:
						goto IL_3A74;
					case 408:
						break;
					case 409:
						array[15] = 14 + 63;
						num2 = 302;
						continue;
					case 410:
						num6 = 125 - 106;
						num2 = 508;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 173;
							continue;
						}
						continue;
					case 411:
						array12[3] = 74;
						num2 = 269;
						continue;
					case 412:
						goto IL_51B1;
					case 413:
						array[0] = 155 - 51;
						num2 = 211;
						continue;
					case 414:
						array[28] = (byte)num6;
						num2 = 198;
						continue;
					case 415:
						array[16] = 167 - 55;
						num2 = 42;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 157;
							continue;
						}
						continue;
					case 416:
						num6 = 160 + 36;
						num2 = 397;
						continue;
					case 417:
						array9[3] = 65 - 63;
						num2 = 27;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 42;
							continue;
						}
						continue;
					case 418:
						array[25] = (byte)num6;
						num2 = 594;
						continue;
					case 419:
						num41 = 0L;
						num2 = 357;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 634;
							continue;
						}
						continue;
					case 420:
						num3 = 181 - 60;
						num2 = 398;
						continue;
					case 421:
						intPtr = NrkKTZ6esAiaRtQKtm.sONikbA1kGOZM4BwJPe(NrkKTZ6esAiaRtQKtm.pt7FwFABNqYx7nA7aRa(NrkKTZ6esAiaRtQKtm.EONwWqrt4G)[0]);
						num2 = 439;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 608;
							continue;
						}
						continue;
					case 422:
						num3 = 29 + 35;
						num2 = 205;
						continue;
					case 423:
						num6 = 119 - 20;
						num2 = 520;
						continue;
					case 424:
						goto IL_48B3;
					case 425:
						num6 = 142 - 47;
						num2 = 375;
						continue;
					case 426:
						text2 = NrkKTZ6esAiaRtQKtm.xeGQ6B7aDT9HUfX8g49(NrkKTZ6esAiaRtQKtm.om84eC7o9qiyESD4q6O(), array14);
						num2 = 640;
						continue;
					case 427:
						num6 = 66 + 86;
						num2 = 585;
						continue;
					case 428:
						array7[num15 + 2] = array15[2];
						num2 = 394;
						continue;
					case 429:
						array14[2] = 114;
						num2 = 281;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 536;
							continue;
						}
						continue;
					case 430:
						goto IL_41C5;
					case 431:
						array6 = new byte[array3.Length];
						num2 = 171;
						continue;
					case 432:
						array9[6] = 79 + 56;
						num2 = 458;
						continue;
					case 433:
						goto IL_23F2;
					case 434:
						num6 = 99 + 36;
						num2 = 48;
						continue;
					case 435:
						array6[num13] = (byte)(num14 & 255U);
						num2 = 90;
						continue;
					case 436:
						array7[num21 + 3] = array13[3];
						num2 = 344;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 249;
							continue;
						}
						continue;
					case 437:
						goto IL_25CA;
					case 438:
						array8 = null;
						num2 = 22;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 439:
						array[2] = 109 + 82;
						num2 = 34;
						continue;
					case 440:
						num6 = 116 + 114;
						num2 = 316;
						continue;
					case 441:
						goto IL_5446;
					case 442:
						NrkKTZ6esAiaRtQKtm.uTPct1V3IL = intPtr.ToInt64();
						num2 = 393;
						continue;
					case 443:
						goto IL_1F74;
					case 444:
						if (num9 != num10 - 1)
						{
							goto IL_21D2;
						}
						num2 = 47;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 109;
							continue;
						}
						continue;
					case 445:
						NrkKTZ6esAiaRtQKtm.W08NeB7gwum3YPVO8JZ(NrkKTZ6esAiaRtQKtm.R3TccymhsI);
						num2 = 150;
						continue;
					case 446:
						NrkKTZ6esAiaRtQKtm.M6gF7iAMHtHL3jGtWkK();
						num2 = 404;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 81;
							continue;
						}
						continue;
					case 447:
					{
						int num42 = 0;
						num2 = 19;
						continue;
					}
					case 448:
						goto IL_2A66;
					case 449:
						num6 = 51 + 60;
						num2 = 34;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 38;
							continue;
						}
						continue;
					case 450:
						goto IL_2DF4;
					case 451:
						array7[num15] = array13[0];
						num2 = 465;
						continue;
					case 452:
						array18 = null;
						num2 = 143;
						continue;
					case 453:
						goto IL_14A4;
					case 454:
						array14[9] = 108;
						num2 = 159;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 464;
							continue;
						}
						continue;
					case 455:
						array[8] = (byte)num6;
						num2 = 542;
						continue;
					case 456:
						array7[num21] = array8[0];
						num2 = 152;
						continue;
					case 457:
						array[26] = (byte)num6;
						num2 = 86;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 155;
							continue;
						}
						continue;
					case 458:
						num3 = 25 + 21;
						num2 = 114;
						continue;
					case 459:
						array7[num15 + 1] = array8[1];
						num2 = 75;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 235;
							continue;
						}
						continue;
					case 460:
						num17 = NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
						num2 = 498;
						continue;
					case 461:
						array[29] = 29 + 21;
						num2 = 104;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 29;
							continue;
						}
						continue;
					case 462:
						array9[10] = (byte)num3;
						num2 = 164;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 83;
							continue;
						}
						continue;
					case 463:
						num3 = 215 - 71;
						num2 = 61;
						continue;
					case 464:
						goto IL_29D2;
					case 465:
						array7[num15 + 1] = array13[1];
						num2 = 592;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 209;
							continue;
						}
						continue;
					case 466:
						num15 = 18;
						num2 = 493;
						continue;
					case 467:
						array[18] = 11 + 8;
						num2 = 81;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 103;
							continue;
						}
						continue;
					case 468:
						array9[12] = 28 + 89;
						num2 = 224;
						continue;
					case 469:
						array7[num15 + 3] = array8[3];
						num2 = 343;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 298;
							continue;
						}
						continue;
					case 470:
						num3 = 251 - 83;
						num2 = 255;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 74;
							continue;
						}
						continue;
					case 471:
					{
						NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv gwgifTc71BJOaot4wBv2;
						NrkKTZ6esAiaRtQKtm.Lb9IjS7Y2wBLZwCItyj(NrkKTZ6esAiaRtQKtm.jfacnvmZfm, 0L, gwgifTc71BJOaot4wBv2);
						num2 = 573;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 455;
							continue;
						}
						continue;
					}
					case 472:
						array[20] = (byte)num6;
						num2 = 300;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 54;
							continue;
						}
						continue;
					case 473:
						array9[3] = 201 - 67;
						num2 = 213;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 422;
							continue;
						}
						continue;
					case 474:
						goto IL_1969;
					case 475:
					{
						NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv gwgifTc71BJOaot4wBv;
						int num39;
						NrkKTZ6esAiaRtQKtm.Lb9IjS7Y2wBLZwCItyj(NrkKTZ6esAiaRtQKtm.jfacnvmZfm, num38 + (long)num39, gwgifTc71BJOaot4wBv);
						num2 = 87;
						continue;
					}
					case 476:
						array9[4] = 135 + 116;
						num2 = 266;
						continue;
					case 477:
						goto IL_1F2B;
					case 478:
						array7[num15 + 5] = array8[5];
						num2 = 303;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 191;
							continue;
						}
						continue;
					case 479:
						NrkKTZ6esAiaRtQKtm.OmltT0ACi6yStnw8hVE(new IntPtr((void*)(&num37)), 0, 0L);
						num2 = 158;
						continue;
					case 480:
						array[29] = (byte)num6;
						num2 = 603;
						continue;
					case 481:
						array[19] = 148 - 27;
						num2 = 180;
						continue;
					case 482:
						array[12] = 248 - 82;
						num2 = 127;
						continue;
					case 483:
						num6 = 90 + 76;
						num2 = 602;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 176;
							continue;
						}
						continue;
					case 484:
						goto IL_4C86;
					case 485:
						num6 = 92 + 58;
						num2 = 136;
						continue;
					case 486:
						goto IL_2E17;
					case 487:
						goto IL_3DD0;
					case 488:
						goto IL_1792;
					case 489:
						array12[5] = 116;
						num2 = 51;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 28;
							continue;
						}
						continue;
					case 490:
						goto IL_50B8;
					case 491:
						num3 = 14 + 113;
						num2 = 160;
						continue;
					case 492:
						num29 <<= 8;
						num2 = 338;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 412;
							continue;
						}
						continue;
					case 493:
						array7[num15] = array15[0];
						num2 = 192;
						continue;
					case 494:
						goto IL_0BD6;
					case 495:
						goto IL_3D38;
					case 496:
						array7[num15 + 4] = array13[4];
						num2 = 44;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 333;
							continue;
						}
						continue;
					case 497:
						goto IL_6096;
					case 498:
						goto IL_1518;
					case 499:
						intPtr5 = IntPtr.Zero;
						num2 = 284;
						continue;
					case 500:
						goto IL_21E0;
					case 501:
						array15 = null;
						num2 = 438;
						continue;
					case 502:
						goto IL_58B6;
					case 503:
						NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(intPtr4, 4, 8, ref num12);
						num2 = 200;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 172;
							continue;
						}
						continue;
					case 504:
						array[26] = (byte)num6;
						num2 = 363;
						continue;
					case 505:
						num6 = 25 - 21;
						num2 = 138;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 24;
							continue;
						}
						continue;
					case 506:
						array[23] = (byte)num6;
						num2 = 378;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 26;
							continue;
						}
						continue;
					case 507:
						num6 = 150 - 50;
						num2 = 74;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 111;
							continue;
						}
						continue;
					case 508:
						goto IL_0C05;
					case 509:
						num44 = 0;
						num2 = 105;
						continue;
					case 510:
						NrkKTZ6esAiaRtQKtm.kb80KtAGwvVKBEPLSp8(array2, 0, array2.Length);
						num2 = 139;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 183;
							continue;
						}
						continue;
					case 511:
						array[11] = 247 - 82;
						num2 = 115;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 128;
							continue;
						}
						continue;
					case 512:
						array[30] = 144 - 48;
						num2 = 134;
						continue;
					case 513:
						array10 = null;
						num2 = 327;
						continue;
					case 514:
						intPtr = NrkKTZ6esAiaRtQKtm.sONikbA1kGOZM4BwJPe(NrkKTZ6esAiaRtQKtm.pt7FwFABNqYx7nA7aRa(NrkKTZ6esAiaRtQKtm.EONwWqrt4G)[0]);
						num2 = 169;
						continue;
					case 515:
						num6 = 152 - 50;
						num2 = 319;
						continue;
					case 516:
						num6 = 122 - 53;
						num2 = 227;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 77;
							continue;
						}
						continue;
					case 517:
						num6 = 217 - 72;
						num2 = 330;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 284;
							continue;
						}
						continue;
					case 518:
						array[21] = 154 + 53;
						num2 = 101;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 230;
							continue;
						}
						continue;
					case 519:
						array5[13] = array16[6];
						num2 = 283;
						continue;
					case 520:
						array[4] = (byte)num6;
						num2 = 559;
						continue;
					case 521:
						num6 = 51 + 107;
						num2 = 98;
						continue;
					case 522:
						num6 = 108 + 63;
						num2 = 147;
						continue;
					case 523:
						array14[6] = 46;
						num2 = 112;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 66;
							continue;
						}
						continue;
					case 524:
						NrkKTZ6esAiaRtQKtm.kb80KtAGwvVKBEPLSp8(array16, 0, array16.Length);
						num2 = 525;
						continue;
					case 525:
						goto IL_58B6;
					case 526:
						num6 = 24 + 124;
						num2 = 385;
						continue;
					case 527:
						array9[7] = (byte)num3;
						num2 = 11;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 420;
							continue;
						}
						continue;
					case 528:
						num6 = 7 + 26;
						num2 = 391;
						continue;
					case 529:
						NrkKTZ6esAiaRtQKtm.soYsgQA06V8yehpT14e(NrkKTZ6esAiaRtQKtm.cX6V89A67Bf1WQBFq6o(z2G3P3cj94OxNl7aFlt), 0L);
						num2 = 194;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 21;
							continue;
						}
						continue;
					case 530:
					{
						byte[] array19 = NrkKTZ6esAiaRtQKtm.bPw9SSAZ5q9nT1ixgmo(z2G3P3cj94OxNl7aFlt, num52);
						num2 = 326;
						continue;
					}
					case 531:
						array8 = NrkKTZ6esAiaRtQKtm.RlmWDN7DYA2g2ldoppl(NrkKTZ6esAiaRtQKtm.sxAceygjwi.ToInt32());
						num2 = 0;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 370;
							continue;
						}
						continue;
					case 532:
						array[2] = 12 + 5;
						num2 = 439;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 404;
							continue;
						}
						continue;
					case 533:
						num53++;
						num2 = 234;
						continue;
					case 534:
						goto IL_52BD;
					case 535:
						goto IL_51F4;
					case 536:
						array14[3] = 106;
						num2 = 101;
						continue;
					case 537:
						array[2] = 42 + 41;
						num2 = 345;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 383;
							continue;
						}
						continue;
					case 538:
						goto IL_4958;
					case 539:
						if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() != 4)
						{
							goto IL_6096;
						}
						num2 = 75;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 83;
							continue;
						}
						continue;
					case 540:
						array[30] = 16 + 39;
						num2 = 512;
						continue;
					case 541:
						array[31] = (byte)num6;
						num2 = 485;
						continue;
					case 542:
						goto IL_0F58;
					case 543:
						intPtr8 = NrkKTZ6esAiaRtQKtm.gFMwo4Do5h(text2);
						num2 = 15;
						continue;
					case 544:
						array[15] = 36 + 21;
						num2 = 409;
						continue;
					case 545:
						array[10] = (byte)num6;
						num2 = 389;
						continue;
					case 546:
						array[3] = 116 + 104;
						num2 = 374;
						continue;
					case 547:
						num50 += 8;
						num2 = 142;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 392;
							continue;
						}
						continue;
					case 548:
						num29 = 0U;
						num2 = 10;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 5;
							continue;
						}
						continue;
					case 549:
						if (NrkKTZ6esAiaRtQKtm.xxCwpa7EnAW9uF1Urdf(intPtr8, IntPtr.Zero))
						{
							num2 = 213;
							continue;
						}
						goto IL_244C;
					case 550:
						num54++;
						num2 = 495;
						continue;
					case 551:
						num55++;
						num2 = 407;
						continue;
					case 552:
						NrkKTZ6esAiaRtQKtm.X1xyDLA5knE0rStlILy();
						num2 = 25;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 44;
							continue;
						}
						continue;
					case 553:
						if (NrkKTZ6esAiaRtQKtm.YUQeeEAzFNmVXdNrG5P(NrkKTZ6esAiaRtQKtm.HAko2oAJ9roDT1GpQSM(NrkKTZ6esAiaRtQKtm.EONwWqrt4G)) == 0)
						{
							num2 = 424;
							continue;
						}
						goto IL_469F;
					case 554:
						num56 = array11.Length / 8;
						num2 = 14;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 32;
							continue;
						}
						continue;
					case 555:
						num3 = 204 + 31;
						num2 = 527;
						continue;
					case 556:
						array[14] = (byte)num6;
						num2 = 544;
						continue;
					case 557:
						array[27] = 149 - 124;
						num2 = 254;
						continue;
					case 558:
						array[9] = 63 + 120;
						num2 = 148;
						continue;
					case 559:
						array[5] = 176 - 58;
						num2 = 174;
						continue;
					case 560:
						array5[3] = array16[1];
						num2 = 129;
						continue;
					case 561:
						array[24] = 119 + 23;
						num2 = 384;
						continue;
					case 562:
						array7[num21] = array13[0];
						num2 = 342;
						continue;
					case 563:
						array[2] = 17 + 49;
						num2 = 119;
						continue;
					case 564:
						num57++;
						num2 = 459;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 534;
							continue;
						}
						continue;
					case 565:
						array9[15] = (byte)num3;
						num2 = 463;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 632;
							continue;
						}
						continue;
					case 566:
						array7[num15 + 5] = array15[5];
						num2 = 59;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 88;
							continue;
						}
						continue;
					case 567:
						array9[0] = 87 + 109;
						num2 = 123;
						continue;
					case 568:
						array[27] = (byte)num6;
						num2 = 262;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 157;
							continue;
						}
						continue;
					case 569:
					{
						string text;
						intPtr7 = NrkKTZ6esAiaRtQKtm.P36WUp7xL7tEY9PfvN3((NrkKTZ6esAiaRtQKtm.JiI8PscAVd3LhanEOj8)NrkKTZ6esAiaRtQKtm.HZDmWp7CGAH1eQ5PJAZ(NrkKTZ6esAiaRtQKtm.SFcwa04LUg(intPtr8, text), NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm.JiI8PscAVd3LhanEOj8).TypeHandle)));
						num2 = 419;
						continue;
					}
					case 570:
						array14[1] = 108;
						num2 = 429;
						continue;
					case 571:
						goto IL_58B6;
					case 572:
						goto IL_29EE;
					case 573:
						flag = false;
						num2 = 34;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 250;
							continue;
						}
						continue;
					case 574:
						goto IL_4158;
					case 575:
						array14[8] = 46;
						num2 = 609;
						continue;
					case 576:
						array9[14] = (byte)num3;
						num2 = 202;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 74;
							continue;
						}
						continue;
					case 577:
						array5[11] = array16[5];
						num2 = 519;
						continue;
					case 578:
						goto IL_2DB7;
					case 579:
						array[27] = (byte)num6;
						num2 = 117;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 98;
							continue;
						}
						continue;
					case 580:
						goto IL_2E17;
					case 581:
						try
						{
							object obj2 = NrkKTZ6esAiaRtQKtm.IR0iba7qAibGIe7tUBj(NrkKTZ6esAiaRtQKtm.X7hct17bRWrVutPdIIx(NrkKTZ6esAiaRtQKtm.TNZN137VWPuWvHajrMx(NrkKTZ6esAiaRtQKtm.U7Q7dh7vgTSwf23vjjj(NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm).TypeHandle).Assembly))).GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), NrkKTZ6esAiaRtQKtm.TNZN137VWPuWvHajrMx(NrkKTZ6esAiaRtQKtm.U7Q7dh7vgTSwf23vjjj(NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm).TypeHandle).Assembly)));
							int num58 = 17;
							for (;;)
							{
								MemoryStream memoryStream2;
								switch (num58)
								{
								case 0:
									goto IL_5B2E;
								case 1:
									goto IL_5D68;
								case 2:
									try
									{
										byte[] array20;
										if ((array10 = array20) == null)
										{
											goto IL_5C14;
										}
										int num59 = 4;
										if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
										{
											num59 = 6;
										}
										byte* ptr;
										for (;;)
										{
											IL_5BDF:
											switch (num59)
											{
											case 1:
												goto IL_5C58;
											case 2:
												goto IL_5C58;
											case 3:
												goto IL_5C14;
											case 4:
												goto IL_5CA0;
											case 5:
												goto IL_5CA0;
											case 6:
												if (array10.Length != 0)
												{
													int num60 = 4;
													num59 = num60;
													continue;
												}
												goto IL_5C14;
											}
											break;
											IL_5C58:
											uint num61;
											NrkKTZ6esAiaRtQKtm.R3TccymhsI(new IntPtr((void*)ptr), new IntPtr((void*)ptr), new IntPtr((void*)ptr), 216669565U, new IntPtr((void*)ptr), ref num61);
											num59 = 0;
											if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
											{
												num59 = 0;
												continue;
											}
											continue;
											IL_5CA0:
											ptr = &array10[0];
											num59 = 2;
											if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
											{
												num59 = 1;
											}
										}
										goto IL_5E46;
										IL_5C14:
										ptr = null;
										num59 = 1;
										if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
										{
											num59 = 1;
											goto IL_5BDF;
										}
										goto IL_5BDF;
									}
									finally
									{
										array10 = null;
										int num62 = 0;
										if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
										{
											num62 = 0;
										}
										switch (num62)
										{
										}
									}
									goto IL_5D14;
								case 3:
									NrkKTZ6esAiaRtQKtm.WfL0FF7PFl1bDhck6RM(memoryStream2, new byte[NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12()], 0, NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12());
									num58 = 18;
									continue;
								case 4:
									NrkKTZ6esAiaRtQKtm.sxAceygjwi = (IntPtr)obj2;
									num58 = 1;
									if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
									{
										num58 = 0;
										continue;
									}
									continue;
								case 5:
									if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() == 4)
									{
										num58 = 6;
										continue;
									}
									goto IL_5ACE;
								case 6:
									NrkKTZ6esAiaRtQKtm.WfL0FF7PFl1bDhck6RM(memoryStream2, NrkKTZ6esAiaRtQKtm.RlmWDN7DYA2g2ldoppl(NrkKTZ6esAiaRtQKtm.sxAceygjwi.ToInt32()), 0, 4);
									num58 = 8;
									if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
									{
										num58 = 0;
										continue;
									}
									continue;
								case 7:
									break;
								case 8:
									goto IL_5DDD;
								case 9:
									break;
								case 10:
									goto IL_5E46;
								case 11:
								{
									byte[] array20 = NrkKTZ6esAiaRtQKtm.oTZhuI7lK78h2uhYKdA(memoryStream2);
									num58 = 0;
									if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
									{
										num58 = 0;
										continue;
									}
									continue;
								}
								case 12:
									NrkKTZ6esAiaRtQKtm.WfL0FF7PFl1bDhck6RM(memoryStream2, new byte[NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12()], 0, NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12());
									num58 = 5;
									if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
									{
										num58 = 4;
										continue;
									}
									continue;
								case 13:
								{
									uint num61 = 0U;
									num58 = 2;
									continue;
								}
								case 14:
									goto IL_5DDD;
								case 15:
									goto IL_5ACE;
								case 16:
									goto IL_5D2A;
								case 17:
									goto IL_5D14;
								case 18:
									NrkKTZ6esAiaRtQKtm.soYsgQA06V8yehpT14e(memoryStream2, 0L);
									num58 = 11;
									if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
									{
										num58 = 0;
										continue;
									}
									continue;
								default:
									goto IL_5B2E;
								}
								memoryStream2 = new MemoryStream();
								num58 = 12;
								continue;
								IL_5ACE:
								NrkKTZ6esAiaRtQKtm.WfL0FF7PFl1bDhck6RM(memoryStream2, NrkKTZ6esAiaRtQKtm.o8NS2u7QF5MriGfVhfx(NrkKTZ6esAiaRtQKtm.sxAceygjwi.ToInt64()), 0, 8);
								num58 = 14;
								if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
								{
									num58 = 13;
									continue;
								}
								continue;
								IL_5B2E:
								NrkKTZ6esAiaRtQKtm.RWSOey7sGwvsHJfIcl9(memoryStream2);
								num58 = 9;
								if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
								{
									num58 = 13;
									continue;
								}
								continue;
								IL_5D14:
								if (obj2 is IntPtr)
								{
									num58 = 4;
									continue;
								}
								goto IL_5D68;
								IL_5D2A:
								NrkKTZ6esAiaRtQKtm.sxAceygjwi = (IntPtr)NrkKTZ6esAiaRtQKtm.IR0iba7qAibGIe7tUBj(obj2.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), obj2);
								num58 = 9;
								if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
								{
									num58 = 9;
									continue;
								}
								continue;
								IL_5D68:
								if (NrkKTZ6esAiaRtQKtm.PNRPUNA84FW3jGVUk9S(obj2.GetType().ToString(), "System.Reflection.RuntimeModule"))
								{
									goto IL_5D2A;
								}
								num58 = 7;
								if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
								{
									num58 = 5;
									continue;
								}
								continue;
								IL_5DDD:
								NrkKTZ6esAiaRtQKtm.WfL0FF7PFl1bDhck6RM(memoryStream2, new byte[NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12()], 0, NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12());
								num58 = 3;
								if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
								{
									num58 = 1;
								}
							}
							IL_5E46:
							goto IL_1471;
						}
						catch
						{
							int num63 = 0;
							if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
							{
								num63 = 0;
							}
							switch (num63)
							{
							default:
								goto IL_1471;
							}
						}
						goto IL_5E87;
					case 582:
						array14[1] = 115;
						num2 = 586;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 293;
							continue;
						}
						continue;
					case 583:
						array[26] = 123 + 53;
						num2 = 195;
						continue;
					case 584:
						array14[4] = 114;
						num2 = 233;
						continue;
					case 585:
						array[13] = (byte)num6;
						num2 = 614;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 433;
							continue;
						}
						continue;
					case 586:
						goto IL_19B9;
					case 587:
						array15 = NrkKTZ6esAiaRtQKtm.RlmWDN7DYA2g2ldoppl(NrkKTZ6esAiaRtQKtm.IsN7ON7rELBVWuoirRc(num16));
						num2 = 290;
						continue;
					case 588:
						array[29] = (byte)num6;
						num2 = 461;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 61;
							continue;
						}
						continue;
					case 589:
						goto IL_1000;
					case 590:
						goto IL_2093;
					case 591:
						array[12] = (byte)num6;
						num2 = 482;
						continue;
					case 592:
						array7[num15 + 2] = array13[2];
						num2 = 14;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 58;
							continue;
						}
						continue;
					case 593:
						num11 = NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
						num2 = 17;
						continue;
					case 594:
						array[25] = 86 + 78;
						num2 = 483;
						continue;
					case 595:
						array9[11] = (byte)num3;
						num2 = 239;
						continue;
					case 596:
						array9[0] = 145 - 48;
						num2 = 70;
						continue;
					case 597:
					{
						NrkKTZ6esAiaRtQKtm.GWGIfTc71BJOaot4wBv gwgifTc71BJOaot4wBv;
						byte[] array19;
						gwgifTc71BJOaot4wBv.tTpcpXCpSj = array19;
						num2 = 81;
						continue;
					}
					case 598:
						array9[9] = (byte)num3;
						num2 = 37;
						continue;
					case 599:
						num51++;
						num2 = 132;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 307;
							continue;
						}
						continue;
					case 600:
						num6 = 198 - 92;
						num2 = 146;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 243;
							continue;
						}
						continue;
					case 601:
						array14[10] = 108;
						num2 = 321;
						continue;
					case 602:
						array[25] = (byte)num6;
						num2 = 449;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 384;
							continue;
						}
						continue;
					case 603:
						array[29] = 185 + 10;
						num2 = 106;
						continue;
					case 604:
						array[13] = (byte)num6;
						num2 = 515;
						continue;
					case 605:
						goto IL_62C0;
					case 606:
						num15 = 30;
						num2 = 451;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 263;
							continue;
						}
						continue;
					case 607:
						num6 = 48 + 96;
						num2 = 545;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 254;
							continue;
						}
						continue;
					case 608:
						NrkKTZ6esAiaRtQKtm.rI5wzot0B9 = intPtr.ToInt32();
						num2 = 484;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 362;
							continue;
						}
						continue;
					case 609:
						array14[9] = 100;
						num2 = 601;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 596;
							continue;
						}
						continue;
					case 610:
						array7[num15 + 6] = array13[6];
						num2 = 162;
						continue;
					case 611:
						num5 = (uint)(num64 * 4);
						num2 = 3;
						continue;
					case 612:
						goto IL_18AD;
					case 613:
						if (NrkKTZ6esAiaRtQKtm.MOtw1c8j4K)
						{
							num2 = 612;
							continue;
						}
						goto IL_5181;
					case 614:
						num6 = 139 - 46;
						num2 = 604;
						continue;
					case 615:
						array[3] = 32 + 68;
						num2 = 273;
						continue;
					case 616:
						goto IL_3AF0;
					case 617:
						goto IL_6262;
					case 618:
						if (NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(intPtr3, 4, 4, ref num12) != 0)
						{
							goto IL_2BD3;
						}
						num2 = 361;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 16;
							continue;
						}
						continue;
					case 619:
						num6 = 199 - 66;
						num2 = 310;
						continue;
					case 620:
						if (array16 == null)
						{
							num2 = 502;
							continue;
						}
						goto IL_1C87;
					case 621:
						num3 = 57 - 31;
						num2 = 315;
						continue;
					case 622:
						goto IL_5181;
					case 623:
					{
						int num42;
						NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(new IntPtr(num41), NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12(), num42, ref num42);
						num2 = 89;
						continue;
					}
					case 624:
						array[0] = (byte)num6;
						num2 = 413;
						continue;
					case 625:
						num10++;
						num2 = 274;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 379;
							continue;
						}
						continue;
					case 626:
						num33 = 0;
						num2 = 352;
						continue;
					case 627:
						NrkKTZ6esAiaRtQKtm.zPT0TU78e0Sy8C0psPM(NrkKTZ6esAiaRtQKtm.rShspo7S7lnxvP14FZr(NrkKTZ6esAiaRtQKtm.rB2rgR7jW080wPr00Qs(NrkKTZ6esAiaRtQKtm.q54cwIo8a7)));
						num2 = 79;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 445;
							continue;
						}
						continue;
					case 628:
						goto IL_3C85;
					case 629:
						num3 = 196 - 65;
						num2 = 33;
						continue;
					case 630:
						array9[1] = (byte)num3;
						num2 = 23;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 631;
							continue;
						}
						continue;
					case 631:
						array9[1] = 42 - 17;
						num2 = 242;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 111;
							continue;
						}
						continue;
					case 632:
						num3 = 112 + 112;
						num2 = 145;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 340;
							continue;
						}
						continue;
					case 633:
						array9[9] = (byte)num3;
						num2 = 135;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 386;
							continue;
						}
						continue;
					case 634:
						if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() == 4)
						{
							num2 = 373;
							continue;
						}
						goto IL_5446;
					case 635:
						num3 = 216 - 104;
						num2 = 462;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 444;
							continue;
						}
						continue;
					case 636:
						array[25] = (byte)num6;
						num2 = 337;
						continue;
					case 637:
						array[19] = 39 + 27;
						num2 = 0;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 1;
							continue;
						}
						continue;
					case 638:
						num6 = 51 + 120;
						num2 = 591;
						continue;
					case 639:
						num6 = 12 + 115;
						num2 = 218;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 59;
							continue;
						}
						continue;
					case 640:
						goto IL_297D;
					case 641:
						array[2] = (byte)num6;
						num2 = 537;
						continue;
					case 642:
						num6 = 15 + 88;
						num2 = 588;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
						{
							num2 = 513;
							continue;
						}
						continue;
					case 643:
						if (array10.Length != 0)
						{
							goto IL_41C5;
						}
						num2 = 23;
						if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 251;
							continue;
						}
						continue;
					case 644:
						array[22] = (byte)num6;
						num2 = 54;
						if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
						{
							num2 = 55;
							continue;
						}
						continue;
					case 645:
						goto IL_2271;
					case 646:
						goto IL_2BD3;
					case 647:
						goto IL_2093;
					case 648:
						goto IL_14A4;
					case 649:
						goto IL_23DF;
					case 650:
						array14[3] = 111;
						num2 = 584;
						continue;
					case 651:
						num6 = 64 - 35;
						num2 = 556;
						continue;
					case 652:
						intPtr6 = IntPtr.Zero;
						num2 = 289;
						continue;
					case 653:
						array[1] = 165 - 55;
						num2 = 521;
						continue;
					case 654:
						array[31] = (byte)num6;
						num2 = 4;
						if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
						{
							num2 = 1;
							continue;
						}
						continue;
					case 655:
						goto IL_2D49;
					case 656:
						goto IL_249C;
					case 657:
						goto IL_49BD;
					default:
						goto IL_4C6E;
					}
					if (num44 >= num7)
					{
						num2 = 657;
						continue;
					}
					goto IL_29EE;
					IL_0CA3:
					NrkKTZ6esAiaRtQKtm.NgIR2pAiCMiFmnyf72J(intPtr7, 0);
					num2 = 167;
					continue;
					IL_0CB6:
					NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(intPtr2, num11 * 4, 8, ref num12);
					num2 = 486;
					continue;
					IL_0EA4:
					NrkKTZ6esAiaRtQKtm.M6gF7iAMHtHL3jGtWkK();
					num2 = 317;
					continue;
					IL_0EE6:
					if (num8 > 0)
					{
						num2 = 492;
						continue;
					}
					goto IL_51B1;
					IL_14A4:
					if (num8 >= num30)
					{
						num2 = 132;
						continue;
					}
					goto IL_0EE6;
					IL_0EF8:
					NrkKTZ6esAiaRtQKtm.WcUwNLZDMS(intPtr4, 4, num12, ref num12);
					num2 = 265;
					if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
					{
						num2 = 16;
						continue;
					}
					continue;
					IL_1471:
					NrkKTZ6esAiaRtQKtm.W08NeB7gwum3YPVO8JZ(NrkKTZ6esAiaRtQKtm.q54cwIo8a7);
					num2 = 627;
					continue;
					IL_1518:
					if (num17 != 1)
					{
						num55 = 0;
						num2 = 246;
						continue;
					}
					num2 = 453;
					if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
					{
						num2 = 499;
						continue;
					}
					continue;
					IL_1792:
					z2G3P3cj94OxNl7aFlt = new NrkKTZ6esAiaRtQKtm.z2G3P3cj94OxNl7aFlt(NrkKTZ6esAiaRtQKtm.f1xkMYAhWLkLJHpAMEt(NrkKTZ6esAiaRtQKtm.EONwWqrt4G, "yhJsZXsgW5SGcNA35B.ZQ1RP7ek1A2jSaFYAc"));
					num2 = 529;
					continue;
					IL_3AF0:
					if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() != 4)
					{
						goto IL_1792;
					}
					num2 = 12;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
					{
						num2 = 0;
						continue;
					}
					continue;
					IL_17B2:
					if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() != 4)
					{
						goto IL_1204;
					}
					num2 = 395;
					if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
					{
						num2 = 220;
						continue;
					}
					continue;
					IL_18AD:
					NrkKTZ6esAiaRtQKtm.M6gF7iAMHtHL3jGtWkK();
					num2 = 84;
					continue;
					IL_1C87:
					if (array16.Length != 0)
					{
						goto IL_4958;
					}
					num2 = 35;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 571;
						continue;
					}
					continue;
					IL_1CD8:
					num2 = 115;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
					{
						num2 = 80;
						continue;
					}
					continue;
					IL_1F2B:
					intPtr9 = NrkKTZ6esAiaRtQKtm.JasRoU7WM3OxerMND1a(IntPtr.Zero, (uint)array18.Length, 4096U, 64U);
					num2 = 45;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
					{
						num2 = 29;
						continue;
					}
					continue;
					IL_2093:
					num2 = 432;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 581;
						continue;
					}
					continue;
					IL_4158:
					if (NrkKTZ6esAiaRtQKtm.YUQeeEAzFNmVXdNrG5P(NrkKTZ6esAiaRtQKtm.HAko2oAJ9roDT1GpQSM(NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm).TypeHandle).Assembly)) > 0)
					{
						num2 = 446;
						continue;
					}
					goto IL_2093;
					IL_2DB7:
					if (NrkKTZ6esAiaRtQKtm.AU9p6y7yr6Lu0oDLMrM(NrkKTZ6esAiaRtQKtm.SqVCLY7Xb5VkF0I5ceo(NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm).TypeHandle).Assembly)).Length == 2)
					{
						num2 = 312;
						continue;
					}
					goto IL_2093;
					IL_215D:
					num57 = 0;
					num2 = 399;
					continue;
					IL_218B:
					process = NrkKTZ6esAiaRtQKtm.VMwD0dAALomuQFfWUgL();
					num2 = 93;
					if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
					{
						num2 = 52;
						continue;
					}
					continue;
					IL_21D2:
					num5 = (uint)num13;
					num2 = 190;
					continue;
					IL_23DF:
					num52 = NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
					num2 = 530;
					continue;
					IL_4BA6:
					int num65 = NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
					flag = false;
					if (num65 >= 1879048192)
					{
						num2 = 95;
						continue;
					}
					goto IL_23DF;
					IL_23F2:
					num9++;
					num2 = 168;
					if (NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
					{
						num2 = 296;
						continue;
					}
					continue;
					IL_244C:
					array12 = new byte[6];
					num2 = 349;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
					{
						num2 = 228;
						continue;
					}
					continue;
					IL_249C:
					NrkKTZ6esAiaRtQKtm.q54cwIo8a7 = null;
					num2 = 267;
					if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
					{
						num2 = 236;
						continue;
					}
					continue;
					IL_25CA:
					if (num53 >= num11)
					{
						num2 = 291;
						continue;
					}
					goto IL_5004;
					IL_29EE:
					intPtr4 = new IntPtr(NrkKTZ6esAiaRtQKtm.uTPct1V3IL + (long)NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt) - (long)num33);
					num2 = 196;
					continue;
					IL_2A66:
					if (num51 > 0)
					{
						num2 = 377;
						continue;
					}
					goto IL_36E7;
					IL_3715:
					if (num51 >= num30)
					{
						num2 = 433;
						continue;
					}
					goto IL_2A66;
					IL_2BB6:
					ptr2 = null;
					num2 = 75;
					continue;
					IL_2BD3:
					NrkKTZ6esAiaRtQKtm.rM2vEJ7IPv5eFBpHTC2(intPtr3, NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt));
					num2 = 73;
					continue;
					IL_2D49:
					intPtr = NrkKTZ6esAiaRtQKtm.sONikbA1kGOZM4BwJPe(NrkKTZ6esAiaRtQKtm.pt7FwFABNqYx7nA7aRa(NrkKTZ6esAiaRtQKtm.f0qxki7i1KmK92XBYXC(typeof(NrkKTZ6esAiaRtQKtm).TypeHandle).Assembly)[0]);
					num2 = 9;
					continue;
					IL_58C3:
					if (NrkKTZ6esAiaRtQKtm.dh81ZR7U1qZay2cRRm2(NrkKTZ6esAiaRtQKtm.cX6V89A67Bf1WQBFq6o(z2G3P3cj94OxNl7aFlt)) >= NrkKTZ6esAiaRtQKtm.WxT56pALYLZvOtSnxXs(NrkKTZ6esAiaRtQKtm.cX6V89A67Bf1WQBFq6o(z2G3P3cj94OxNl7aFlt)) - 1L)
					{
						goto IL_2D49;
					}
					num2 = 116;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 170;
						continue;
					}
					continue;
					IL_2DF4:
					if (num9 < num10)
					{
						goto IL_3728;
					}
					num2 = 94;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 166;
						continue;
					}
					continue;
					IL_2E17:
					num53 = 0;
					num2 = 437;
					continue;
					IL_3203:
					array2[num54] ^= array5[num54];
					num2 = 550;
					if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
					{
						num2 = 382;
						continue;
					}
					continue;
					IL_3D38:
					if (num54 >= array5.Length)
					{
						num2 = 5;
						continue;
					}
					goto IL_3203;
					IL_3556:
					NrkKTZ6esAiaRtQKtm.RRWwxiXd80(intPtr5, intPtr4, NrkKTZ6esAiaRtQKtm.RlmWDN7DYA2g2ldoppl(NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt)), 4U, out zero);
					num2 = 222;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 354;
						continue;
					}
					continue;
					IL_36E7:
					array6[num13 + num51] = (byte)((num66 & num49) >> num50);
					num2 = 307;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 599;
						continue;
					}
					continue;
					IL_3A74:
					if (num55 >= num7)
					{
						num2 = 400;
						continue;
					}
					goto IL_44AD;
					IL_3C85:
					num36 = num36;
					num2 = 294;
					continue;
					IL_41C5:
					ptr2 = &array10[0];
					num2 = 259;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() != null)
					{
						num2 = 231;
						continue;
					}
					continue;
					IL_42A1:
					num5 = 0U;
					num2 = 43;
					continue;
					IL_43DF:
					num14 = num36 ^ num29;
					num2 = 435;
					continue;
					IL_43F0:
					byte[] array21 = new byte[30];
					NrkKTZ6esAiaRtQKtm.s0BEXW7k7aRXEGSyObx(array21, fieldof(<PrivateImplementationDetails>{42BEE363-006E-4CC6-8E6F-037BFE8EA111}.D5B7247C497788CF0031CEB06E3DF77A45FEF59F1E49633DC7159816D64759B5).FieldHandle);
					array18 = array21;
					num2 = 32;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 85;
						continue;
					}
					continue;
					IL_44AD:
					intPtr3 = new IntPtr(num38 + (long)NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt) - (long)num33);
					num2 = 618;
					continue;
					IL_469F:
					NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
					num2 = 367;
					continue;
					IL_48B3:
					num33 = 7680;
					num2 = 155;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 188;
						continue;
					}
					continue;
					IL_4958:
					array5[1] = array16[0];
					num2 = 560;
					continue;
					IL_49BD:
					if (NrkKTZ6esAiaRtQKtm.dh81ZR7U1qZay2cRRm2(NrkKTZ6esAiaRtQKtm.cX6V89A67Bf1WQBFq6o(z2G3P3cj94OxNl7aFlt)) >= NrkKTZ6esAiaRtQKtm.WxT56pALYLZvOtSnxXs(NrkKTZ6esAiaRtQKtm.cX6V89A67Bf1WQBFq6o(z2G3P3cj94OxNl7aFlt)) - 1L)
					{
						goto IL_6262;
					}
					num2 = 117;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 257;
						continue;
					}
					continue;
					IL_4C6E:
					array9[6] = (byte)num3;
					num2 = 432;
					continue;
					IL_4C86:
					intPtr = NrkKTZ6esAiaRtQKtm.sONikbA1kGOZM4BwJPe(NrkKTZ6esAiaRtQKtm.pt7FwFABNqYx7nA7aRa(NrkKTZ6esAiaRtQKtm.EONwWqrt4G)[0]);
					num2 = 442;
					continue;
					IL_4FDE:
					num6 = 13 + 89;
					num2 = 279;
					continue;
					IL_51B1:
					num29 |= (uint)array3[array3.Length - (1 + num8)];
					num2 = 135;
					if (NrkKTZ6esAiaRtQKtm.u2wkrUAYl5PylGHuZeq() == null)
					{
						num2 = 201;
						continue;
					}
					continue;
					IL_5350:
					IntPtr zero2 = IntPtr.Zero;
					num2 = 447;
					continue;
					IL_5389:
					if (NrkKTZ6esAiaRtQKtm.tsELLcAykqxyiAPRG12() != 4)
					{
						goto IL_50B8;
					}
					num2 = 487;
					if (!NrkKTZ6esAiaRtQKtm.OX8TAPAf1KgVr5PIp0X())
					{
						num2 = 395;
						continue;
					}
					continue;
					IL_5446:
					num41 = NrkKTZ6esAiaRtQKtm.Y6ODh675aEtC7A9qgiF(intPtr7);
					num2 = 258;
					continue;
					IL_58B6:
					num54 = 0;
					num2 = 62;
					continue;
					IL_5E87:
					num6 = 73 + 29;
					num2 = 57;
					continue;
					IL_62C0:
					array8 = NrkKTZ6esAiaRtQKtm.o8NS2u7QF5MriGfVhfx(NrkKTZ6esAiaRtQKtm.sxAceygjwi.ToInt64());
					num2 = 474;
				}
				IL_0AEB:
				num66 = num36 ^ num29;
				num = 380;
				continue;
				IL_0BD6:
				array[29] = (byte)num6;
				num = 216;
				continue;
				IL_0C05:
				array[1] = (byte)num6;
				num = 563;
				continue;
				IL_0D1A:
				array[20] = 188 - 62;
				num = 528;
				continue;
				IL_0D62:
				array[22] = 155 - 51;
				num = 382;
				continue;
				IL_0E68:
				num3 = 102 + 62;
				num = 645;
				continue;
				IL_0F58:
				array[9] = 243 - 81;
				num = 313;
				continue;
				IL_1000:
				num16 = (long)NrkKTZ6esAiaRtQKtm.TY5MGi7NAV7Qk8aLO8O(new IntPtr(num41));
				num = 298;
				continue;
				IL_1088:
				num6 = 230 + 14;
				num = 91;
				continue;
				IL_1204:
				NrkKTZ6esAiaRtQKtm.RRWwxiXd80(intPtr5, intPtr4, NrkKTZ6esAiaRtQKtm.RlmWDN7DYA2g2ldoppl(NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt)), 4U, out zero);
				num = 260;
				continue;
				IL_1298:
				array[30] = 127 - 42;
				num = 540;
				continue;
				IL_13AF:
				array[17] = 96 + 55;
				num = 121;
				continue;
				IL_14B7:
				NrkKTZ6esAiaRtQKtm.qFHqZtAo8wwjiEjWaXH(new IntPtr((void*)(&num37)), 0);
				num = 272;
				continue;
				IL_1969:
				array13 = NrkKTZ6esAiaRtQKtm.o8NS2u7QF5MriGfVhfx(intPtr6.ToInt64());
				num = 365;
				continue;
				IL_19B9:
				array14[2] = 99;
				num = 650;
				continue;
				IL_19F3:
				num36 += num4;
				num = 320;
				continue;
				IL_1BBC:
				array[13] = 197 + 29;
				num = 362;
				continue;
				IL_1C6B:
				array[16] = (byte)num6;
				num = 149;
				continue;
				Block_65:
				num = 647;
				continue;
				IL_1E93:
				array[23] = 84 + 14;
				num = 328;
				continue;
				IL_1F74:
				num16 = NrkKTZ6esAiaRtQKtm.Y6ODh675aEtC7A9qgiF(new IntPtr(num41));
				num = 249;
				continue;
				IL_21E0:
				num6 = 74 + 75;
				num = 102;
				continue;
				IL_2271:
				array9[15] = (byte)num3;
				num = 29;
				continue;
				IL_238B:
				z2G3P3cj94OxNl7aFlt = new NrkKTZ6esAiaRtQKtm.z2G3P3cj94OxNl7aFlt(new MemoryStream(array11));
				num = 179;
				continue;
				Block_81:
				num = 421;
				continue;
				IL_24BC:
				num3 = 122 - 81;
				num = 281;
				continue;
				IL_258B:
				num6 = 18 + 106;
				num = 579;
				continue;
				IL_26B2:
				uint num67 = num36;
				uint num68 = num36;
				uint num69 = 199912980U;
				uint num70 = 1037969119U;
				uint num71 = num68;
				uint num72 = (num69 - 1533389235U) ^ num70;
				uint num73 = 247370422U - 2046298795U + num69;
				num69 = num72 - num72 + 298300572U;
				uint num74 = num70 & 252645135U;
				uint num75 = num70 & 4042322160U;
				num74 = ((num74 >> 4) | (num75 << 4)) + num72;
				num70 = (num70 >> 9) | (num70 << 23);
				ulong num76 = (ulong)(num72 * 725730688U);
				num76 |= 1UL;
				num71 = (uint)((ulong)(num71 * num71) % num76);
				num71 ^= num71 << 3;
				num71 += num69;
				num71 ^= num71 << 1;
				num71 += num70;
				num71 ^= num71 >> 19;
				num71 += num71;
				num71 = (((num70 << 11) - num73) ^ num69) - num71;
				num36 = num67 + (uint)num71;
				num = 11;
				continue;
				IL_297D:
				intPtr8 = IntPtr.Zero;
				num = 549;
				continue;
				IL_29D2:
				text2 = NrkKTZ6esAiaRtQKtm.xeGQ6B7aDT9HUfX8g49(NrkKTZ6esAiaRtQKtm.om84eC7o9qiyESD4q6O(), array14);
				num = 543;
				continue;
				IL_2B9A:
				array[8] = (byte)num6;
				num = 178;
				continue;
				IL_30AD:
				array9[11] = 104 + 113;
				num = 35;
				continue;
				IL_3117:
				array9[6] = (byte)num3;
				num = 28;
				continue;
				IL_3728:
				num64 = num9 % num40;
				num = 186;
				continue;
				IL_3B86:
				NrkKTZ6esAiaRtQKtm.aqpsQR72XRWjLuYWdPS(new IntPtr(num41), intPtr9);
				num = 623;
				continue;
				IL_3BBB:
				*(long*)(ptr2 + num57 * 8) ^= 1120191066L;
				num = 564;
				continue;
				IL_52BD:
				if (num57 >= num56)
				{
					num = 513;
					continue;
				}
				goto IL_3BBB;
				IL_3178:
				goto IL_52BD;
				IL_3DD0:
				num21 = 9;
				num = 456;
				continue;
				Block_189:
				num = 625;
				continue;
				IL_4701:
				array[24] = 197 - 65;
				num = 347;
				continue;
				IL_47EE:
				NrkKTZ6esAiaRtQKtm.RWSOey7sGwvsHJfIcl9(cryptoStream);
				num = 271;
				continue;
				IL_4BD9:
				array[11] = 196 - 65;
				num = 241;
				continue;
				IL_5004:
				NrkKTZ6esAiaRtQKtm.rM2vEJ7IPv5eFBpHTC2(new IntPtr(intPtr2.ToInt64() + (long)(num53 * 4)), NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt));
				num = 533;
				continue;
				IL_505B:
				NrkKTZ6esAiaRtQKtm.fBcWdy7tASTkjorZRgC(z2G3P3cj94OxNl7aFlt);
				num = 23;
				continue;
				IL_50B8:
				num15 = 2;
				num = 21;
				continue;
				IL_50E4:
				num3 = 71 + 74;
				num = 390;
				continue;
				IL_5181:
				NrkKTZ6esAiaRtQKtm.MOtw1c8j4K = true;
				num = 146;
				continue;
				IL_5195:
				NrkKTZ6esAiaRtQKtm.NurcL0ANH498TQAqJh3(array7, 0, intPtr9, array7.Length);
				num = 360;
				continue;
				IL_2BC4:
				goto IL_5195;
				IL_51F4:
				array[5] = (byte)num6;
				num = 505;
				continue;
				Block_240:
				num = 503;
				continue;
				IL_588E:
				array7 = array18;
				num = 308;
				continue;
				IL_5F6C:
				num6 = 156 - 52;
				num = 256;
				continue;
				IL_6082:
				array2 = array;
				num = 154;
				continue;
				IL_6096:
				array14 = new byte[12];
				num = 144;
				continue;
				IL_6231:
				array7[num15 + 7] = array15[7];
				num = 606;
				continue;
				IL_6262:
				NrkKTZ6esAiaRtQKtm.h2Ukn87fe3uNyHCxlII(intPtr5);
				num = 113;
				continue;
				IL_63C0:
				num6 = 106 + 60;
				num = 64;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000A410 File Offset: 0x00008610
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object BLVwrk7UEB(object \u0020)
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

		// Token: 0x0600006F RID: 111
		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr gFMwo4Do5h(string \u0020);

		// Token: 0x06000070 RID: 112
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		public static extern IntPtr SFcwa04LUg(IntPtr \u0020, string \u0020);

		// Token: 0x06000071 RID: 113 RVA: 0x0000A540 File Offset: 0x00008740
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr jmjwEc2Gl5(IntPtr \u0020, object \u0020, uint \u0020)
		{
			if (NrkKTZ6esAiaRtQKtm.i2vcDNj80L == null)
			{
				NrkKTZ6esAiaRtQKtm.i2vcDNj80L = (NrkKTZ6esAiaRtQKtm.JqfLnscqZoHx9q1yDde)Marshal.GetDelegateForFunctionPointer(NrkKTZ6esAiaRtQKtm.SFcwa04LUg(NrkKTZ6esAiaRtQKtm.xTuFFuFOZ(), "Find ".Trim() + "ResourceA"), typeof(NrkKTZ6esAiaRtQKtm.JqfLnscqZoHx9q1yDde));
			}
			return NrkKTZ6esAiaRtQKtm.i2vcDNj80L(\u0020, \u0020, \u0020);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000A59C File Offset: 0x0000879C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr wUQwCCVmfo(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			if (NrkKTZ6esAiaRtQKtm.U6BcUopiIF == null)
			{
				NrkKTZ6esAiaRtQKtm.U6BcUopiIF = (NrkKTZ6esAiaRtQKtm.S1t15GcQdLFEYiBbfL5)Marshal.GetDelegateForFunctionPointer(NrkKTZ6esAiaRtQKtm.SFcwa04LUg(NrkKTZ6esAiaRtQKtm.xTuFFuFOZ(), "Virtual ".Trim() + "Alloc"), typeof(NrkKTZ6esAiaRtQKtm.S1t15GcQdLFEYiBbfL5));
			}
			return NrkKTZ6esAiaRtQKtm.U6BcUopiIF(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000A5F8 File Offset: 0x000087F8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int RRWwxiXd80(IntPtr \u0020, IntPtr \u0020, [In] [Out] byte[] \u0020, uint \u0020, out IntPtr \u0020)
		{
			if (NrkKTZ6esAiaRtQKtm.DNpcIFBlvg == null)
			{
				NrkKTZ6esAiaRtQKtm.DNpcIFBlvg = (NrkKTZ6esAiaRtQKtm.B86GEbcghrdiERHPCsU)Marshal.GetDelegateForFunctionPointer(NrkKTZ6esAiaRtQKtm.SFcwa04LUg(NrkKTZ6esAiaRtQKtm.xTuFFuFOZ(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(NrkKTZ6esAiaRtQKtm.B86GEbcghrdiERHPCsU));
			}
			return NrkKTZ6esAiaRtQKtm.DNpcIFBlvg(\u0020, \u0020, \u0020, \u0020, out \u0020);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000A660 File Offset: 0x00008860
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int WcUwNLZDMS(IntPtr \u0020, int \u0020, int \u0020, ref int \u0020)
		{
			if (NrkKTZ6esAiaRtQKtm.WhVcf346tL == null)
			{
				NrkKTZ6esAiaRtQKtm.WhVcf346tL = (NrkKTZ6esAiaRtQKtm.ytHTiIcSRDIsgpYi5t8)Marshal.GetDelegateForFunctionPointer(NrkKTZ6esAiaRtQKtm.SFcwa04LUg(NrkKTZ6esAiaRtQKtm.xTuFFuFOZ(), "Virtual ".Trim() + "Protect"), typeof(NrkKTZ6esAiaRtQKtm.ytHTiIcSRDIsgpYi5t8));
			}
			return NrkKTZ6esAiaRtQKtm.WhVcf346tL(\u0020, \u0020, \u0020, ref \u0020);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000A6BC File Offset: 0x000088BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr OpJw5jKVRP(uint \u0020, int \u0020, uint \u0020)
		{
			if (NrkKTZ6esAiaRtQKtm.F9tcYCj4He == null)
			{
				NrkKTZ6esAiaRtQKtm.F9tcYCj4He = (NrkKTZ6esAiaRtQKtm.J09AX6c8sB35qp117MA)Marshal.GetDelegateForFunctionPointer(NrkKTZ6esAiaRtQKtm.SFcwa04LUg(NrkKTZ6esAiaRtQKtm.xTuFFuFOZ(), "Open ".Trim() + "Process"), typeof(NrkKTZ6esAiaRtQKtm.J09AX6c8sB35qp117MA));
			}
			return NrkKTZ6esAiaRtQKtm.F9tcYCj4He(\u0020, \u0020, \u0020);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000A718 File Offset: 0x00008918
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int FSQwAgd080(IntPtr \u0020)
		{
			if (NrkKTZ6esAiaRtQKtm.pk5citB7GF == null)
			{
				NrkKTZ6esAiaRtQKtm.pk5citB7GF = (NrkKTZ6esAiaRtQKtm.fx4aL4ckqCyDx5FvTU3)Marshal.GetDelegateForFunctionPointer(NrkKTZ6esAiaRtQKtm.SFcwa04LUg(NrkKTZ6esAiaRtQKtm.xTuFFuFOZ(), "Close ".Trim() + "Handle"), typeof(NrkKTZ6esAiaRtQKtm.fx4aL4ckqCyDx5FvTU3));
			}
			return NrkKTZ6esAiaRtQKtm.pk5citB7GF(\u0020);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000A774 File Offset: 0x00008974
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr xTuFFuFOZ()
		{
			if (NrkKTZ6esAiaRtQKtm.DK5crh597r == IntPtr.Zero)
			{
				NrkKTZ6esAiaRtQKtm.DK5crh597r = NrkKTZ6esAiaRtQKtm.gFMwo4Do5h("kernel ".Trim() + "32.dll");
			}
			return NrkKTZ6esAiaRtQKtm.DK5crh597r;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000A7B0 File Offset: 0x000089B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] r9ew7gda5R(object \u0020)
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

		// Token: 0x06000079 RID: 121 RVA: 0x0000A81C File Offset: 0x00008A1C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Stream Q8LwXXoPCZ()
		{
			return new MemoryStream();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000A824 File Offset: 0x00008A24
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] jsTwpCUcJH(object \u0020)
		{
			return ((MemoryStream)\u0020).ToArray();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000A834 File Offset: 0x00008A34
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] w1uwj8W9RI(object \u0020)
		{
			Stream stream = NrkKTZ6esAiaRtQKtm.Q8LwXXoPCZ();
			SymmetricAlgorithm symmetricAlgorithm = NrkKTZ6esAiaRtQKtm.mtoJHUs35();
			symmetricAlgorithm.Key = new byte[]
			{
				197, 18, 79, 135, 99, 129, 71, 24, 203, 112,
				230, 100, 125, 187, 254, 90, 128, 225, 32, 186,
				185, 207, 150, 212, 173, 249, 108, 34, 189, 75,
				106, 132
			};
			symmetricAlgorithm.IV = new byte[]
			{
				63, 34, 112, 249, 220, 152, 81, 58, 176, 24,
				70, 196, 47, 74, 162, 54
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(\u0020, 0, \u0020.Length);
			cryptoStream.Close();
			byte[] array = NrkKTZ6esAiaRtQKtm.jsTwpCUcJH(stream);
			HVH9hrc2y21U31AG4bl.FQsAUKBwJZ();
			return array;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000A8A8 File Offset: 0x00008AA8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] Cs2wMPtE3Z()
		{
			return null;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000A8B8 File Offset: 0x00008AB8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] w8QwyOXVVU()
		{
			return null;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000A8C8 File Offset: 0x00008AC8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] ss3wv2U0B1()
		{
			int length = "{11111-22222-20001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000A8E8 File Offset: 0x00008AE8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] cwDwVheatm()
		{
			int length = "{11111-22222-20001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000A908 File Offset: 0x00008B08
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] jd0wbF4Onx()
		{
			return null;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000A918 File Offset: 0x00008B18
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] EyWwqNQ3TH()
		{
			return null;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000A928 File Offset: 0x00008B28
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] QkewQo1J99()
		{
			int length = "{11111-22222-40001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000A948 File Offset: 0x00008B48
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] A85wgl6Ow1()
		{
			int length = "{11111-22222-40001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000A968 File Offset: 0x00008B68
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] ruxwSUa5G8()
		{
			return null;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000A978 File Offset: 0x00008B78
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] cp5w89bw0g()
		{
			return null;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000A988 File Offset: 0x00008B88
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object vKg2lwn0nvkKrsgaBU5(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000A994 File Offset: 0x00008B94
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void DB5dpEnLPYcwOOoZrgS(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000A9A4 File Offset: 0x00008BA4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long DZJtNZnZ8XZipCcTAo0(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000A9B0 File Offset: 0x00008BB0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object hG5cF3nOQ1wMoEPEcxc(object A_0, int \u0020)
		{
			return A_0.PMIcMuk1XT(\u0020);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000A9C0 File Offset: 0x00008BC0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void WZI27Fn4gZ0rtwNTWCW(object A_0)
		{
			A_0.SQDcVAMfNH();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000A9CC File Offset: 0x00008BCC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void wyDnQYnm065xhXBQ4E0(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000A9D8 File Offset: 0x00008BD8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object IY4oaTnGo7ECK3B0I6A(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000A9E4 File Offset: 0x00008BE4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object zhulrdnBDOe38Z3UmNp(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000A9F0 File Offset: 0x00008BF0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object lZifCjn12Z3OMJdoY1B()
		{
			return NrkKTZ6esAiaRtQKtm.mtoJHUs35();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000A9F8 File Offset: 0x00008BF8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Ad02HPnJ77EUpibW2Vy(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000AA08 File Offset: 0x00008C08
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AuYyy5nzJ4gKe9UAIuV(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000AA1C File Offset: 0x00008C1C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object xYIV7nDtMY6AtcXA99y()
		{
			return NrkKTZ6esAiaRtQKtm.Q8LwXXoPCZ();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000AA24 File Offset: 0x00008C24
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void EAaJcLDwO26kNLFiBZm(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000AA3C File Offset: 0x00008C3C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void o7rUh9DcRbQ0fDGOoQ7(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000AA48 File Offset: 0x00008C48
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object ts9mdMDKU2bSPQLShgF(object A_0)
		{
			return NrkKTZ6esAiaRtQKtm.jsTwpCUcJH(A_0);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000AA54 File Offset: 0x00008C54
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void BDpr7rDPXnX1oCKi2up(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000AA60 File Offset: 0x00008C60
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object hTZKK3DTYCOXsD1yFh5(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000AA6C File Offset: 0x00008C6C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool dOQIZEDlAW0HeQvRUul(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000AA7C File Offset: 0x00008C7C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool EVwHnanh2SOc0Yo9kTr()
		{
			return null == null;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000AA84 File Offset: 0x00008C84
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AKVfJTn6QSiINVYWYAK()
		{
			return null;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000AA88 File Offset: 0x00008C88
		static int iqrQw5AIQRtaIHqOjtS()
		{
			return 1;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000AA8C File Offset: 0x00008C8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr NgIR2pAiCMiFmnyf72J(IntPtr A_0, int A_1)
		{
			return Marshal.ReadIntPtr(A_0, A_1);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000AA9C File Offset: 0x00008C9C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int nsU4BIArpqQJYiVyVDT(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt32(A_0, A_1);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000AAAC File Offset: 0x00008CAC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long qFHqZtAo8wwjiEjWaXH(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt64(A_0, A_1);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000AABC File Offset: 0x00008CBC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void iqPLMBAaPQJPxSdboai(IntPtr A_0, int A_1, IntPtr A_2)
		{
			Marshal.WriteIntPtr(A_0, A_1, A_2);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000AAD0 File Offset: 0x00008CD0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void PbontVAE7QLbRKOoYw9(IntPtr A_0, int A_1, int A_2)
		{
			Marshal.WriteInt32(A_0, A_1, A_2);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000AAE4 File Offset: 0x00008CE4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void OmltT0ACi6yStnw8hVE(IntPtr A_0, int A_1, long A_2)
		{
			Marshal.WriteInt64(A_0, A_1, A_2);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000AAF8 File Offset: 0x00008CF8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr ahl7lBAxFgBEoa4DKBN(int A_0)
		{
			return Marshal.AllocCoTaskMem(A_0);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000AB04 File Offset: 0x00008D04
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void NurcL0ANH498TQAqJh3(object A_0, int A_1, IntPtr A_2, int A_3)
		{
			Marshal.Copy(A_0, A_1, A_2, A_3);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000AB1C File Offset: 0x00008D1C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void X1xyDLA5knE0rStlILy()
		{
			NrkKTZ6esAiaRtQKtm.b8IwfoN8eX();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000AB24 File Offset: 0x00008D24
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object VMwD0dAALomuQFfWUgL()
		{
			return Process.GetCurrentProcess();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000AB2C File Offset: 0x00008D2C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object jDV8PfA7G5hSXOkDBMd(object A_0)
		{
			return A_0.MainModule;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000AB38 File Offset: 0x00008D38
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr t2bLlNAXi1DAdbdhun3(object A_0)
		{
			return A_0.BaseAddress;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000AB44 File Offset: 0x00008D44
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr YylhEwApRea97cCN5SE(IntPtr \u0020, object A_1, uint \u0020)
		{
			return NrkKTZ6esAiaRtQKtm.jmjwEc2Gl5(\u0020, A_1, \u0020);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000AB58 File Offset: 0x00008D58
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool eoYHxUAju60iXCXL07k(IntPtr A_0, IntPtr A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000AB68 File Offset: 0x00008D68
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void M6gF7iAMHtHL3jGtWkK()
		{
			HVH9hrc2y21U31AG4bl.FQsAUKBwJZ();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000AB70 File Offset: 0x00008D70
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int tsELLcAykqxyiAPRG12()
		{
			return IntPtr.Size;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000AB78 File Offset: 0x00008D78
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type q1OhXhAvXckCB9JX66w(object A_0, bool A_1)
		{
			return Type.GetType(A_0, A_1);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000AB88 File Offset: 0x00008D88
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool X1MbDfAV6Tb9X5LjeRw(Type A_0, Type A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000AB98 File Offset: 0x00008D98
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object t01rQPAboeDYqJbyrI6(object A_0)
		{
			return A_0.Modules;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AeUd07Aq77qVf9OujI1(object A_0)
		{
			return A_0.GetEnumerator();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000ABB0 File Offset: 0x00008DB0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object nR0cYyAQ4K3Z4tVVWq2(object A_0)
		{
			return ((IEnumerator)A_0).Current;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000ABBC File Offset: 0x00008DBC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object EWaLtRAg4QbrftSwNiX(object A_0)
		{
			return A_0.ModuleName;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000ABC8 File Offset: 0x00008DC8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object DHdG92ASWeOae0yvhdN(object A_0)
		{
			return A_0.ToLower();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000ABD4 File Offset: 0x00008DD4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool PNRPUNA84FW3jGVUk9S(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000ABE4 File Offset: 0x00008DE4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object TE6qIqAk33v0uBRcUar(object A_0)
		{
			return A_0.FileVersionInfo;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000ABF0 File Offset: 0x00008DF0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int dbdghlAWx5v0IRVWvRx(object A_0)
		{
			return A_0.ProductMajorPart;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000ABFC File Offset: 0x00008DFC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int glAcntA2920XxjWCob8(object A_0)
		{
			return A_0.ProductMinorPart;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000AC08 File Offset: 0x00008E08
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int Cyx4ghA9xeU1w10FIlV(object A_0)
		{
			return A_0.ProductBuildPart;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000AC14 File Offset: 0x00008E14
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int HaMA5FARhWVpfuEU4lv(object A_0)
		{
			return A_0.ProductPrivatePart;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000AC20 File Offset: 0x00008E20
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool oG0CQfA3KKZcVfUyhFS(object A_0, object A_1)
		{
			return A_0 >= A_1;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000AC30 File Offset: 0x00008E30
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool wBoLRGAHm8ZlmLXUVa6(object A_0, object A_1)
		{
			return A_0 < A_1;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000AC40 File Offset: 0x00008E40
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool FNolyTAFH7yE1u3RYcI(object A_0)
		{
			return ((IEnumerator)A_0).MoveNext();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000AC4C File Offset: 0x00008E4C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void jsv1mEAdkunBYUkM1Rn(object A_0)
		{
			((IDisposable)A_0).Dispose();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000AC58 File Offset: 0x00008E58
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object f1xkMYAhWLkLJHpAMEt(object A_0, object A_1)
		{
			return A_0.GetManifestResourceStream(A_1);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000AC68 File Offset: 0x00008E68
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object cX6V89A67Bf1WQBFq6o(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000AC74 File Offset: 0x00008E74
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void soYsgQA06V8yehpT14e(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000AC84 File Offset: 0x00008E84
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long WxT56pALYLZvOtSnxXs(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000AC90 File Offset: 0x00008E90
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object bPw9SSAZ5q9nT1ixgmo(object A_0, int \u0020)
		{
			return A_0.PMIcMuk1XT(\u0020);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000ACA0 File Offset: 0x00008EA0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void vAjeWpAOuh3HSdWlUax(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000ACAC File Offset: 0x00008EAC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object tFKydDA4VY7rk2m8iEN(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000ACB8 File Offset: 0x00008EB8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object xVb6HbAmwLmNZr2ORAq(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000ACC4 File Offset: 0x00008EC4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void kb80KtAGwvVKBEPLSp8(object A_0, int A_1, int A_2)
		{
			Array.Clear(A_0, A_1, A_2);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000ACD8 File Offset: 0x00008ED8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object pt7FwFABNqYx7nA7aRa(object A_0)
		{
			return A_0.GetModules();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000ACE4 File Offset: 0x00008EE4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr sONikbA1kGOZM4BwJPe(object A_0)
		{
			return Marshal.GetHINSTANCE(A_0);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000ACF0 File Offset: 0x00008EF0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object HAko2oAJ9roDT1GpQSM(object A_0)
		{
			return A_0.Location;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000ACFC File Offset: 0x00008EFC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int YUQeeEAzFNmVXdNrG5P(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000AD08 File Offset: 0x00008F08
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int fBcWdy7tASTkjorZRgC(object A_0)
		{
			return A_0.WUYcv0B5FB();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000AD14 File Offset: 0x00008F14
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Igb1607waF2i6Ek6LiS()
		{
			return NrkKTZ6esAiaRtQKtm.mtoJHUs35();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000AD1C File Offset: 0x00008F1C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void a0FMdP7cl1hiDLSScVn(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000AD2C File Offset: 0x00008F2C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object pOpTxL7Kas9WLC0stE9(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000AD40 File Offset: 0x00008F40
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void WfL0FF7PFl1bDhck6RM(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000AD58 File Offset: 0x00008F58
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void OtgQxj7TKCQpLkrBeEs(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000AD64 File Offset: 0x00008F64
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object oTZhuI7lK78h2uhYKdA(object A_0)
		{
			return A_0.ToArray();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000AD70 File Offset: 0x00008F70
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void RWSOey7sGwvsHJfIcl9(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000AD7C File Offset: 0x00008F7C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void a3d2Ey7eugDdcg6n1Zc(object A_0)
		{
			A_0.SQDcVAMfNH();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000AD88 File Offset: 0x00008F88
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int HCkIck7uPWSbnyHfQb2(object A_0)
		{
			return A_0.Id;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000AD94 File Offset: 0x00008F94
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr cTaiIg7ncphORkW2iWc(uint \u0020, int \u0020, uint \u0020)
		{
			return NrkKTZ6esAiaRtQKtm.OpJw5jKVRP(\u0020, \u0020, \u0020);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000ADA8 File Offset: 0x00008FA8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object RlmWDN7DYA2g2ldoppl(int A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000ADB4 File Offset: 0x00008FB4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long dh81ZR7U1qZay2cRRm2(object A_0)
		{
			return A_0.Position;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000ADC0 File Offset: 0x00008FC0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void rM2vEJ7IPv5eFBpHTC2(IntPtr A_0, int A_1)
		{
			Marshal.WriteInt32(A_0, A_1);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000ADD0 File Offset: 0x00008FD0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int h2Ukn87fe3uNyHCxlII(IntPtr \u0020)
		{
			return NrkKTZ6esAiaRtQKtm.FSQwAgd080(\u0020);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000ADDC File Offset: 0x00008FDC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Lb9IjS7Y2wBLZwCItyj(object A_0, object A_1, object A_2)
		{
			A_0.Add(A_1, A_2);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000ADF0 File Offset: 0x00008FF0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type f0qxki7i1KmK92XBYXC(RuntimeTypeHandle A_0)
		{
			return Type.GetTypeFromHandle(A_0);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000ADFC File Offset: 0x00008FFC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int IsN7ON7rELBVWuoirRc(long A_0)
		{
			return Convert.ToInt32(A_0);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000AE08 File Offset: 0x00009008
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object om84eC7o9qiyESD4q6O()
		{
			return Encoding.UTF8;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000AE10 File Offset: 0x00009010
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object xeGQ6B7aDT9HUfX8g49(object A_0, object A_1)
		{
			return A_0.GetString(A_1);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000AE20 File Offset: 0x00009020
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool xxCwpa7EnAW9uF1Urdf(IntPtr A_0, IntPtr A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000AE30 File Offset: 0x00009030
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object HZDmWp7CGAH1eQ5PJAZ(IntPtr \u0020, Type \u0020)
		{
			return NrkKTZ6esAiaRtQKtm.AEDwYFMMVx(\u0020, \u0020);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000AE40 File Offset: 0x00009040
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr P36WUp7xL7tEY9PfvN3(object A_0)
		{
			return A_0();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000AE4C File Offset: 0x0000904C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int TY5MGi7NAV7Qk8aLO8O(IntPtr A_0)
		{
			return Marshal.ReadInt32(A_0);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000AE58 File Offset: 0x00009058
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long Y6ODh675aEtC7A9qgiF(IntPtr A_0)
		{
			return Marshal.ReadInt64(A_0);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000AE64 File Offset: 0x00009064
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr yYt8op7AZgfCeUG8RAy(object A_0)
		{
			return Marshal.GetFunctionPointerForDelegate(A_0);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000AE70 File Offset: 0x00009070
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int Jwf9vx77V1xBvv0MOll(object A_0)
		{
			return A_0.ModuleMemorySize;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000AE7C File Offset: 0x0000907C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object SqVCLY7Xb5VkF0I5ceo(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000AE88 File Offset: 0x00009088
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool CbxZs27pIWcaU4iABVk(object A_0, object A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000AE98 File Offset: 0x00009098
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object rB2rgR7jW080wPr00Qs(object A_0)
		{
			return A_0.Method;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000AEA4 File Offset: 0x000090A4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object LUkGW87MQOprq1SRgH7(Type A_0, object A_1)
		{
			return Delegate.CreateDelegate(A_0, A_1);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000AEB4 File Offset: 0x000090B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AU9p6y7yr6Lu0oDLMrM(object A_0)
		{
			return A_0.GetParameters();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000AEC0 File Offset: 0x000090C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object U7Q7dh7vgTSwf23vjjj(object A_0)
		{
			return A_0.ManifestModule;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000AECC File Offset: 0x000090CC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ModuleHandle TNZN137VWPuWvHajrMx(object A_0)
		{
			return A_0.ModuleHandle;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000AED8 File Offset: 0x000090D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type X7hct17bRWrVutPdIIx(object A_0)
		{
			return A_0.GetType();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000AEE4 File Offset: 0x000090E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object IR0iba7qAibGIe7tUBj(object A_0, object A_1)
		{
			return A_0.GetValue(A_1);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000AEF4 File Offset: 0x000090F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object o8NS2u7QF5MriGfVhfx(long A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000AF00 File Offset: 0x00009100
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void W08NeB7gwum3YPVO8JZ(object A_0)
		{
			RuntimeHelpers.PrepareDelegate(A_0);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000AF0C File Offset: 0x0000910C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static RuntimeMethodHandle rShspo7S7lnxvP14FZr(object A_0)
		{
			return A_0.MethodHandle;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000AF18 File Offset: 0x00009118
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void zPT0TU78e0Sy8C0psPM(RuntimeMethodHandle A_0)
		{
			RuntimeHelpers.PrepareMethod(A_0);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000AF24 File Offset: 0x00009124
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void s0BEXW7k7aRXEGSyObx(object A_0, RuntimeFieldHandle A_1)
		{
			RuntimeHelpers.InitializeArray(A_0, A_1);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000AF34 File Offset: 0x00009134
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr JasRoU7WM3OxerMND1a(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			return NrkKTZ6esAiaRtQKtm.wUQwCCVmfo(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000AF4C File Offset: 0x0000914C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void aqpsQR72XRWjLuYWdPS(IntPtr A_0, IntPtr A_1)
		{
			Marshal.WriteIntPtr(A_0, A_1);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000AF5C File Offset: 0x0000915C
		internal static bool OX8TAPAf1KgVr5PIp0X()
		{
			return null == null;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000AF64 File Offset: 0x00009164
		internal static object u2wkrUAYl5PylGHuZeq()
		{
			return null;
		}

		// Token: 0x04000017 RID: 23
		internal static object sM7w3EQyJU = null;

		// Token: 0x04000018 RID: 24
		private static object z3ZwhvSwlS = new object();

		// Token: 0x04000019 RID: 25
		private static List<int> QfJw0E3We3 = null;

		// Token: 0x0400001A RID: 26
		private static IntPtr qJwwOfpnIk = IntPtr.Zero;

		// Token: 0x0400001B RID: 27
		[NrkKTZ6esAiaRtQKtm.tvdGpIcaDsJhinrRh5s(typeof(NrkKTZ6esAiaRtQKtm.tvdGpIcaDsJhinrRh5s.GjIsbRcE9aZaknto1Am<object>[]))]
		private static bool IsTcucsPBl = false;

		// Token: 0x0400001C RID: 28
		internal static object jfacnvmZfm = new Hashtable();

		// Token: 0x0400001D RID: 29
		private static object DNpcIFBlvg = null;

		// Token: 0x0400001E RID: 30
		private static object F9tcYCj4He = null;

		// Token: 0x0400001F RID: 31
		private static int Xb3wdD2H2L = 0;

		// Token: 0x04000020 RID: 32
		private static bool MOtw1c8j4K = false;

		// Token: 0x04000021 RID: 33
		private static Dictionary<int, int> IAqwH0mMp0 = null;

		// Token: 0x04000022 RID: 34
		private static object SIAwFGs41E = new object();

		// Token: 0x04000023 RID: 35
		private static object oXmw2Nmjw0 = new uint[]
		{
			3614090360U, 3905402710U, 606105819U, 3250441966U, 4118548399U, 1200080426U, 2821735955U, 4249261313U, 1770035416U, 2336552879U,
			4294925233U, 2304563134U, 1804603682U, 4254626195U, 2792965006U, 1236535329U, 4129170786U, 3225465664U, 643717713U, 3921069994U,
			3593408605U, 38016083U, 3634488961U, 3889429448U, 568446438U, 3275163606U, 4107603335U, 1163531501U, 2850285829U, 4243563512U,
			1735328473U, 2368359562U, 4294588738U, 2272392833U, 1839030562U, 4259657740U, 2763975236U, 1272893353U, 4139469664U, 3200236656U,
			681279174U, 3936430074U, 3572445317U, 76029189U, 3654602809U, 3873151461U, 530742520U, 3299628645U, 4096336452U, 1126891415U,
			2878612391U, 4237533241U, 1700485571U, 2399980690U, 4293915773U, 2240044497U, 1873313359U, 4264355552U, 2734768916U, 1309151649U,
			4149444226U, 3174756917U, 718787259U, 3951481745U
		};

		// Token: 0x04000024 RID: 36
		private static int rI5wzot0B9 = 0;

		// Token: 0x04000025 RID: 37
		internal static object EONwWqrt4G = typeof(NrkKTZ6esAiaRtQKtm).Assembly;

		// Token: 0x04000026 RID: 38
		internal static object q54cwIo8a7 = null;

		// Token: 0x04000027 RID: 39
		private static object rO4wmv5N31 = new string[0];

		// Token: 0x04000028 RID: 40
		private static object F29wGdXHrg = new int[0];

		// Token: 0x04000029 RID: 41
		private static object pk5citB7GF = null;

		// Token: 0x0400002A RID: 42
		private static bool su6cTWoWXk = false;

		// Token: 0x0400002B RID: 43
		private static List<string> zeqw6a4CXF = null;

		// Token: 0x0400002C RID: 44
		private static object DDgwLikQMX = new byte[0];

		// Token: 0x0400002D RID: 45
		private static int G7KwBYA9q2 = 1;

		// Token: 0x0400002E RID: 46
		private static long uTPct1V3IL = 0L;

		// Token: 0x0400002F RID: 47
		private static IntPtr YQMw4jXnYG = IntPtr.Zero;

		// Token: 0x04000030 RID: 48
		private static bool AFKw9vVh37 = false;

		// Token: 0x04000031 RID: 49
		private static int ylUcPYTQiJ = 0;

		// Token: 0x04000032 RID: 50
		private static bool brdwR8QLaQ = false;

		// Token: 0x04000033 RID: 51
		private static object WhVcf346tL = null;

		// Token: 0x04000034 RID: 52
		internal static object R3TccymhsI = null;

		// Token: 0x04000035 RID: 53
		private static bool JGccld2QCA = false;

		// Token: 0x04000036 RID: 54
		private static object HyZwZdGkZ5 = new byte[0];

		// Token: 0x04000037 RID: 55
		private static long vGlcKhef2Q = 0L;

		// Token: 0x04000038 RID: 56
		private static IntPtr DK5crh597r = IntPtr.Zero;

		// Token: 0x04000039 RID: 57
		private static object nVLwJCCtOZ = new SortedList();

		// Token: 0x0400003A RID: 58
		private static int rKxcsM4Dd5 = 0;

		// Token: 0x0400003B RID: 59
		private static bool olCwkV4YYa = false;

		// Token: 0x0400003C RID: 60
		private static IntPtr sxAceygjwi = IntPtr.Zero;

		// Token: 0x0400003D RID: 61
		private static object i2vcDNj80L = null;

		// Token: 0x0400003E RID: 62
		private static object U6BcUopiIF = null;

		// Token: 0x0200000F RID: 15
		private sealed class QEBRLQcoqJA9tsAfDaN : MulticastDelegate
		{
			// Token: 0x060000F6 RID: 246
			public extern QEBRLQcoqJA9tsAfDaN(object \u0020, IntPtr \u0020);

			// Token: 0x060000F7 RID: 247
			public extern void Invoke(object o);

			// Token: 0x060000F8 RID: 248
			public extern IAsyncResult BeginInvoke(object o, AsyncCallback callback, object @object);

			// Token: 0x060000F9 RID: 249
			public extern void EndInvoke(IAsyncResult result);

			// Token: 0x060000FA RID: 250 RVA: 0x0000AF68 File Offset: 0x00009168
			static QEBRLQcoqJA9tsAfDaN()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x02000010 RID: 16
		internal class tvdGpIcaDsJhinrRh5s : Attribute
		{
			// Token: 0x060000FB RID: 251 RVA: 0x0000AF70 File Offset: 0x00009170
			[MethodImpl(MethodImplOptions.NoInlining)]
			public tvdGpIcaDsJhinrRh5s(object \u0020)
			{
			}

			// Token: 0x060000FC RID: 252 RVA: 0x0000AF78 File Offset: 0x00009178
			static tvdGpIcaDsJhinrRh5s()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}

			// Token: 0x02000011 RID: 17
			internal class GjIsbRcE9aZaknto1Am<joj78ocCbNpX7ZO3ekC>
			{
				// Token: 0x060000FD RID: 253 RVA: 0x0000AF80 File Offset: 0x00009180
				[MethodImpl(MethodImplOptions.NoInlining)]
				public GjIsbRcE9aZaknto1Am()
				{
				}

				// Token: 0x060000FE RID: 254 RVA: 0x0000AF90 File Offset: 0x00009190
				[MethodImpl(MethodImplOptions.NoInlining)]
				static GjIsbRcE9aZaknto1Am()
				{
					NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
					gKqvKlcFEyIdCMHN7kB.VtK79na5bE();
				}

				// Token: 0x060000FF RID: 255 RVA: 0x0000AF9C File Offset: 0x0000919C
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool sgMWjqiQvJofwXTie9P()
				{
					return true;
				}

				// Token: 0x06000100 RID: 256 RVA: 0x0000AFA4 File Offset: 0x000091A4
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static object Ln9MF7igmv0X05ZbehC()
				{
					return null;
				}

				// Token: 0x0400003F RID: 63
				internal static object HvZxZliqm2kGF4R9TEV;
			}
		}

		// Token: 0x02000012 RID: 18
		internal class zV4PE3cxoRgQ9skj735
		{
			// Token: 0x06000101 RID: 257 RVA: 0x0000AFAC File Offset: 0x000091AC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static string ieRcNZ6JoM(object \u0020, object \u0020)
			{
				return null;
			}

			// Token: 0x06000102 RID: 258 RVA: 0x0000AFBC File Offset: 0x000091BC
			[MethodImpl(MethodImplOptions.NoInlining)]
			public zV4PE3cxoRgQ9skj735()
			{
			}

			// Token: 0x06000103 RID: 259 RVA: 0x0000AFC4 File Offset: 0x000091C4
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object KkZqnliWVD6Uy7dijXE(object A_0, object A_1)
			{
				return null;
			}

			// Token: 0x06000104 RID: 260 RVA: 0x0000AFCC File Offset: 0x000091CC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void lKrLjsi2EMee7UJMkJI(object A_0, RuntimeFieldHandle A_1)
			{
			}

			// Token: 0x06000105 RID: 261 RVA: 0x0000AFD4 File Offset: 0x000091D4
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object Bd81fKi9m9I59KXnosO()
			{
				return null;
			}

			// Token: 0x06000106 RID: 262 RVA: 0x0000AFDC File Offset: 0x000091DC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object ci2umiiRXcjVM304PC6(object A_0)
			{
				return null;
			}

			// Token: 0x06000107 RID: 263 RVA: 0x0000AFE4 File Offset: 0x000091E4
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object gNIdZfi3B5A80dsW9R6()
			{
				return null;
			}

			// Token: 0x06000108 RID: 264 RVA: 0x0000AFEC File Offset: 0x000091EC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void XnVVayiH7KLykBNqkIT(object A_0, object A_1)
			{
			}

			// Token: 0x06000109 RID: 265 RVA: 0x0000AFF4 File Offset: 0x000091F4
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object c5hNlSiFVTN0Kl8RXSG(object A_0)
			{
				return null;
			}

			// Token: 0x0600010A RID: 266 RVA: 0x0000AFFC File Offset: 0x000091FC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void UYfMfVidvSfFTJCtb2C(object A_0, object A_1, int A_2, int A_3)
			{
			}

			// Token: 0x0600010B RID: 267 RVA: 0x0000B004 File Offset: 0x00009204
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void OrgyFwihTpxi5i18esU(object A_0)
			{
			}

			// Token: 0x0600010C RID: 268 RVA: 0x0000B00C File Offset: 0x0000920C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object uZ7b8Oi6O3gbNMcIRWS(object A_0)
			{
				return null;
			}

			// Token: 0x0600010D RID: 269 RVA: 0x0000B014 File Offset: 0x00009214
			static zV4PE3cxoRgQ9skj735()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x02000013 RID: 19
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal sealed class Ul6C5Wc5dVDuS4vTZwm : MulticastDelegate
		{
			// Token: 0x0600010E RID: 270
			public extern Ul6C5Wc5dVDuS4vTZwm(object \u0020, IntPtr \u0020);

			// Token: 0x0600010F RID: 271
			public extern uint Invoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

			// Token: 0x06000110 RID: 272
			public extern IAsyncResult BeginInvoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode, AsyncCallback callback, object @object);

			// Token: 0x06000111 RID: 273
			public extern uint EndInvoke(ref uint nativeSizeOfCode, IAsyncResult result);

			// Token: 0x06000112 RID: 274 RVA: 0x0000B01C File Offset: 0x0000921C
			static Ul6C5Wc5dVDuS4vTZwm()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x02000014 RID: 20
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class JiI8PscAVd3LhanEOj8 : MulticastDelegate
		{
			// Token: 0x06000113 RID: 275
			public extern JiI8PscAVd3LhanEOj8(object \u0020, IntPtr \u0020);

			// Token: 0x06000114 RID: 276
			public extern IntPtr Invoke();

			// Token: 0x06000115 RID: 277
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x06000116 RID: 278
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000117 RID: 279 RVA: 0x0000B024 File Offset: 0x00009224
			static JiI8PscAVd3LhanEOj8()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x02000015 RID: 21
		internal struct GWGIfTc71BJOaot4wBv
		{
			// Token: 0x04000040 RID: 64
			internal bool Xo1cXJIe5g;

			// Token: 0x04000041 RID: 65
			internal byte[] tTpcpXCpSj;
		}

		// Token: 0x02000016 RID: 22
		internal class z2G3P3cj94OxNl7aFlt
		{
			// Token: 0x06000118 RID: 280 RVA: 0x0000B02C File Offset: 0x0000922C
			[MethodImpl(MethodImplOptions.NoInlining)]
			public z2G3P3cj94OxNl7aFlt(Stream \u0020)
			{
				this.FPXcbMZPLd = new BinaryReader(\u0020);
			}

			// Token: 0x06000119 RID: 281 RVA: 0x0000B040 File Offset: 0x00009240
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal Stream nW4lBacjpc()
			{
				return NrkKTZ6esAiaRtQKtm.z2G3P3cj94OxNl7aFlt.HDc4wOiGSHGBuD1mWFd(this.FPXcbMZPLd);
			}

			// Token: 0x0600011A RID: 282 RVA: 0x0000B050 File Offset: 0x00009250
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal byte[] PMIcMuk1XT(int \u0020)
			{
				return this.FPXcbMZPLd.ReadBytes(\u0020);
			}

			// Token: 0x0600011B RID: 283 RVA: 0x0000B060 File Offset: 0x00009260
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int FgMcypMwNm(byte[] \u0020, int \u0020, int \u0020)
			{
				return NrkKTZ6esAiaRtQKtm.z2G3P3cj94OxNl7aFlt.g95IkFiBjHpcpHAZhfN(this.FPXcbMZPLd, \u0020, \u0020, \u0020);
			}

			// Token: 0x0600011C RID: 284 RVA: 0x0000B070 File Offset: 0x00009270
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int WUYcv0B5FB()
			{
				return NrkKTZ6esAiaRtQKtm.z2G3P3cj94OxNl7aFlt.y5KlQJi1FApv7rA99Lb(this.FPXcbMZPLd);
			}

			// Token: 0x0600011D RID: 285 RVA: 0x0000B080 File Offset: 0x00009280
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void SQDcVAMfNH()
			{
				this.FPXcbMZPLd.Close();
			}

			// Token: 0x0600011E RID: 286 RVA: 0x0000B090 File Offset: 0x00009290
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object HDc4wOiGSHGBuD1mWFd(object A_0)
			{
				return A_0.BaseStream;
			}

			// Token: 0x0600011F RID: 287 RVA: 0x0000B09C File Offset: 0x0000929C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static int g95IkFiBjHpcpHAZhfN(object A_0, object A_1, int A_2, int A_3)
			{
				return A_0.Read(A_1, A_2, A_3);
			}

			// Token: 0x06000120 RID: 288 RVA: 0x0000B0B4 File Offset: 0x000092B4
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static int y5KlQJi1FApv7rA99Lb(object A_0)
			{
				return A_0.ReadInt32();
			}

			// Token: 0x06000121 RID: 289 RVA: 0x0000B0C0 File Offset: 0x000092C0
			static z2G3P3cj94OxNl7aFlt()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}

			// Token: 0x04000042 RID: 66
			private object FPXcbMZPLd;
		}

		// Token: 0x02000017 RID: 23
		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private sealed class JqfLnscqZoHx9q1yDde : MulticastDelegate
		{
			// Token: 0x06000122 RID: 290
			public extern JqfLnscqZoHx9q1yDde(object \u0020, IntPtr \u0020);

			// Token: 0x06000123 RID: 291
			public extern IntPtr Invoke(IntPtr hModule, string lpName, uint lpType);

			// Token: 0x06000124 RID: 292
			public extern IAsyncResult BeginInvoke(IntPtr hModule, string lpName, uint lpType, AsyncCallback callback, object @object);

			// Token: 0x06000125 RID: 293
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000126 RID: 294 RVA: 0x0000B0C8 File Offset: 0x000092C8
			static JqfLnscqZoHx9q1yDde()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x02000018 RID: 24
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class S1t15GcQdLFEYiBbfL5 : MulticastDelegate
		{
			// Token: 0x06000127 RID: 295
			public extern S1t15GcQdLFEYiBbfL5(object \u0020, IntPtr \u0020);

			// Token: 0x06000128 RID: 296
			public extern IntPtr Invoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x06000129 RID: 297
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect, AsyncCallback callback, object @object);

			// Token: 0x0600012A RID: 298
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600012B RID: 299 RVA: 0x0000B0D0 File Offset: 0x000092D0
			static S1t15GcQdLFEYiBbfL5()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x02000019 RID: 25
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class B86GEbcghrdiERHPCsU : MulticastDelegate
		{
			// Token: 0x0600012C RID: 300
			public extern B86GEbcghrdiERHPCsU(object \u0020, IntPtr \u0020);

			// Token: 0x0600012D RID: 301
			public extern int Invoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

			// Token: 0x0600012E RID: 302
			public extern IAsyncResult BeginInvoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten, AsyncCallback callback, object @object);

			// Token: 0x0600012F RID: 303
			public extern int EndInvoke(out IntPtr lpNumberOfBytesWritten, IAsyncResult result);

			// Token: 0x06000130 RID: 304 RVA: 0x0000B0D8 File Offset: 0x000092D8
			static B86GEbcghrdiERHPCsU()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x0200001A RID: 26
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class ytHTiIcSRDIsgpYi5t8 : MulticastDelegate
		{
			// Token: 0x06000131 RID: 305
			public extern ytHTiIcSRDIsgpYi5t8(object \u0020, IntPtr \u0020);

			// Token: 0x06000132 RID: 306
			public extern int Invoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

			// Token: 0x06000133 RID: 307
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect, AsyncCallback callback, object @object);

			// Token: 0x06000134 RID: 308
			public extern int EndInvoke(ref int lpflOldProtect, IAsyncResult result);

			// Token: 0x06000135 RID: 309 RVA: 0x0000B0E0 File Offset: 0x000092E0
			static ytHTiIcSRDIsgpYi5t8()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x0200001B RID: 27
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class J09AX6c8sB35qp117MA : MulticastDelegate
		{
			// Token: 0x06000136 RID: 310
			public extern J09AX6c8sB35qp117MA(object \u0020, IntPtr \u0020);

			// Token: 0x06000137 RID: 311
			public extern IntPtr Invoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x06000138 RID: 312
			public extern IAsyncResult BeginInvoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId, AsyncCallback callback, object @object);

			// Token: 0x06000139 RID: 313
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600013A RID: 314 RVA: 0x0000B0E8 File Offset: 0x000092E8
			static J09AX6c8sB35qp117MA()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x0200001C RID: 28
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class fx4aL4ckqCyDx5FvTU3 : MulticastDelegate
		{
			// Token: 0x0600013B RID: 315
			public extern fx4aL4ckqCyDx5FvTU3(object \u0020, IntPtr \u0020);

			// Token: 0x0600013C RID: 316
			public extern int Invoke(IntPtr ptr);

			// Token: 0x0600013D RID: 317
			public extern IAsyncResult BeginInvoke(IntPtr ptr, AsyncCallback callback, object @object);

			// Token: 0x0600013E RID: 318
			public extern int EndInvoke(IAsyncResult result);

			// Token: 0x0600013F RID: 319 RVA: 0x0000B0F0 File Offset: 0x000092F0
			static fx4aL4ckqCyDx5FvTU3()
			{
				NrkKTZ6esAiaRtQKtm.aPowiPKDJv();
			}
		}

		// Token: 0x0200001D RID: 29
		[Flags]
		private enum gE2b6kcW0BxgoU5JxJC
		{

		}
	}
}
