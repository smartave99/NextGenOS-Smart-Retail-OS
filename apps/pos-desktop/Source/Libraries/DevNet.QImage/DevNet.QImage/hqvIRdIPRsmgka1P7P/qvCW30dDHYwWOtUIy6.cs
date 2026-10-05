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
using D1ePlpMxEkaWKPtfglF;
using Lh0jGUMvDwts40NLUFU;
using RFBuAZMhKHEl8APN2gU;

namespace hqvIRdIPRsmgka1P7P
{
	// Token: 0x02000009 RID: 9
	internal class qvCW30dDHYwWOtUIy6
	{
		// Token: 0x06000033 RID: 51 RVA: 0x000024EC File Offset: 0x000006EC
		[MethodImpl(MethodImplOptions.NoInlining)]
		static qvCW30dDHYwWOtUIy6()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002660 File Offset: 0x00000860
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void eMyJa9JVbw()
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002664 File Offset: 0x00000864
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] nkRNScPlc(object \u0020)
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
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num6, num7, num8, num9, 0U, 7, 1U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num9, num6, num7, num8, 1U, 12, 2U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num8, num9, num6, num7, 2U, 17, 3U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num7, num8, num9, num6, 3U, 22, 4U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num6, num7, num8, num9, 4U, 7, 5U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num9, num6, num7, num8, 5U, 12, 6U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num8, num9, num6, num7, 6U, 17, 7U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num7, num8, num9, num6, 7U, 22, 8U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num6, num7, num8, num9, 8U, 7, 9U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num9, num6, num7, num8, 9U, 12, 10U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num8, num9, num6, num7, 10U, 17, 11U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num7, num8, num9, num6, 11U, 22, 12U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num6, num7, num8, num9, 12U, 7, 13U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num9, num6, num7, num8, 13U, 12, 14U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num8, num9, num6, num7, 14U, 17, 15U, array);
				qvCW30dDHYwWOtUIy6.ftJJvlx1F(ref num7, num8, num9, num6, 15U, 22, 16U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num6, num7, num8, num9, 1U, 5, 17U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num9, num6, num7, num8, 6U, 9, 18U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num8, num9, num6, num7, 11U, 14, 19U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num7, num8, num9, num6, 0U, 20, 20U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num6, num7, num8, num9, 5U, 5, 21U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num9, num6, num7, num8, 10U, 9, 22U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num8, num9, num6, num7, 15U, 14, 23U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num7, num8, num9, num6, 4U, 20, 24U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num6, num7, num8, num9, 9U, 5, 25U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num9, num6, num7, num8, 14U, 9, 26U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num8, num9, num6, num7, 3U, 14, 27U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num7, num8, num9, num6, 8U, 20, 28U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num6, num7, num8, num9, 13U, 5, 29U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num9, num6, num7, num8, 2U, 9, 30U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num8, num9, num6, num7, 7U, 14, 31U, array);
				qvCW30dDHYwWOtUIy6.SXFGqjheD(ref num7, num8, num9, num6, 12U, 20, 32U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num6, num7, num8, num9, 5U, 4, 33U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num9, num6, num7, num8, 8U, 11, 34U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num8, num9, num6, num7, 11U, 16, 35U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num7, num8, num9, num6, 14U, 23, 36U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num6, num7, num8, num9, 1U, 4, 37U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num9, num6, num7, num8, 4U, 11, 38U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num8, num9, num6, num7, 7U, 16, 39U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num7, num8, num9, num6, 10U, 23, 40U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num6, num7, num8, num9, 13U, 4, 41U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num9, num6, num7, num8, 0U, 11, 42U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num8, num9, num6, num7, 3U, 16, 43U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num7, num8, num9, num6, 6U, 23, 44U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num6, num7, num8, num9, 9U, 4, 45U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num9, num6, num7, num8, 12U, 11, 46U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num8, num9, num6, num7, 15U, 16, 47U, array);
				qvCW30dDHYwWOtUIy6.hJ2Bw5RjH(ref num7, num8, num9, num6, 2U, 23, 48U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num6, num7, num8, num9, 0U, 6, 49U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num9, num6, num7, num8, 7U, 10, 50U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num8, num9, num6, num7, 14U, 15, 51U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num7, num8, num9, num6, 5U, 21, 52U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num6, num7, num8, num9, 12U, 6, 53U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num9, num6, num7, num8, 3U, 10, 54U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num8, num9, num6, num7, 10U, 15, 55U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num7, num8, num9, num6, 1U, 21, 56U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num6, num7, num8, num9, 8U, 6, 57U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num9, num6, num7, num8, 15U, 10, 58U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num8, num9, num6, num7, 6U, 15, 59U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num7, num8, num9, num6, 13U, 21, 60U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num6, num7, num8, num9, 4U, 6, 61U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num9, num6, num7, num8, 11U, 10, 62U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num8, num9, num6, num7, 2U, 15, 63U, array);
				qvCW30dDHYwWOtUIy6.jq2e3wZ97(ref num7, num8, num9, num6, 9U, 21, 64U, array);
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

		// Token: 0x06000036 RID: 54 RVA: 0x00002CC8 File Offset: 0x00000EC8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ftJJvlx1F(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += qvCW30dDHYwWOtUIy6.zpPQ86AFY(\u0020 + ((\u0020 & \u0020) | (~\u0020 & \u0020)) + \u0020[(int)\u0020] + qvCW30dDHYwWOtUIy6.CJYYfyWmEs[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002CF4 File Offset: 0x00000EF4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void SXFGqjheD(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += qvCW30dDHYwWOtUIy6.zpPQ86AFY(\u0020 + ((\u0020 & \u0020) | (\u0020 & ~\u0020)) + \u0020[(int)\u0020] + qvCW30dDHYwWOtUIy6.CJYYfyWmEs[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002D20 File Offset: 0x00000F20
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void hJ2Bw5RjH(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += qvCW30dDHYwWOtUIy6.zpPQ86AFY(\u0020 + (\u0020 ^ \u0020 ^ \u0020) + \u0020[(int)\u0020] + qvCW30dDHYwWOtUIy6.CJYYfyWmEs[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002D48 File Offset: 0x00000F48
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void jq2e3wZ97(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += qvCW30dDHYwWOtUIy6.zpPQ86AFY(\u0020 + (\u0020 ^ (\u0020 | ~\u0020)) + \u0020[(int)\u0020] + qvCW30dDHYwWOtUIy6.CJYYfyWmEs[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002D70 File Offset: 0x00000F70
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static uint zpPQ86AFY(uint \u0020, ushort \u0020)
		{
			return (\u0020 >> (int)(32 - \u0020)) | (\u0020 << (int)\u0020);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002D84 File Offset: 0x00000F84
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool FyTXDZhlZ()
		{
			if (!qvCW30dDHYwWOtUIy6.AqyYhkP5Gn)
			{
				qvCW30dDHYwWOtUIy6.XPbuxbH8g();
				qvCW30dDHYwWOtUIy6.AqyYhkP5Gn = true;
			}
			return qvCW30dDHYwWOtUIy6.UG7YO2C5GZ;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002DA0 File Offset: 0x00000FA0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal qvCW30dDHYwWOtUIy6()
		{
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002DA8 File Offset: 0x00000FA8
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void HJv9pZrsr(byte[] \u0020, byte[] \u0020, byte[] \u0020)
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
			qvCW30dDHYwWOtUIy6.TBeYN5LFa3 = array;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000312C File Offset: 0x0000132C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static SymmetricAlgorithm GeeSLbWP6()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (qvCW30dDHYwWOtUIy6.FyTXDZhlZ())
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

		// Token: 0x0600003F RID: 63 RVA: 0x000031C0 File Offset: 0x000013C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void XPbuxbH8g()
		{
			try
			{
				new MD5CryptoServiceProvider();
			}
			catch
			{
				qvCW30dDHYwWOtUIy6.UG7YO2C5GZ = true;
				return;
			}
			try
			{
				qvCW30dDHYwWOtUIy6.UG7YO2C5GZ = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003218 File Offset: 0x00001418
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] c0XgguJt6(object \u0020)
		{
			if (!qvCW30dDHYwWOtUIy6.FyTXDZhlZ())
			{
				return new MD5CryptoServiceProvider().ComputeHash(\u0020);
			}
			return qvCW30dDHYwWOtUIy6.nkRNScPlc(\u0020);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003238 File Offset: 0x00001438
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void zouwWvwt1(object \u0020, object \u0020, uint \u0020, object \u0020)
		{
			while (\u0020 > 0U)
			{
				int num = ((\u0020 > (uint)\u0020.Length) ? \u0020.Length : ((int)\u0020));
				\u0020.Read(\u0020, 0, num);
				qvCW30dDHYwWOtUIy6.QnHUHXuSJ(\u0020, \u0020, 0, num);
				\u0020 -= (uint)num;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000327C File Offset: 0x0000147C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void QnHUHXuSJ(object \u0020, object \u0020, int \u0020, int \u0020)
		{
			\u0020.TransformBlock(\u0020, \u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000328C File Offset: 0x0000148C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint yHn0GNQKC(uint \u0020, int \u0020, long \u0020, object \u0020)
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

		// Token: 0x06000044 RID: 68 RVA: 0x000032F4 File Offset: 0x000014F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void A3doItwA2(RuntimeTypeHandle \u0020)
		{
			try
			{
				Type typeFromHandle = Type.GetTypeFromHandle(\u0020);
				if (qvCW30dDHYwWOtUIy6.sJdYH5f0IP == null)
				{
					object fl9YsOPJPq = qvCW30dDHYwWOtUIy6.FL9YsOPJPq;
					lock (fl9YsOPJPq)
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						BinaryReader binaryReader = new BinaryReader(typeof(qvCW30dDHYwWOtUIy6).Assembly.GetManifestResourceStream("0yqpub2Q9oYpNKyur9.XUDKYufm5ad9uIA1G4"));
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
							qvCW30dDHYwWOtUIy6.fh1hmAYzyWp7H1O7Q9k fh1hmAYzyWp7H1O7Q9k = new qvCW30dDHYwWOtUIy6.fh1hmAYzyWp7H1O7Q9k(new MemoryStream(array));
							for (int l = 0; l < num20; l++)
							{
								int num21 = fh1hmAYzyWp7H1O7Q9k.qwyMMHdChH();
								int num22 = fh1hmAYzyWp7H1O7Q9k.qwyMMHdChH();
								dictionary.Add(num21, num22);
							}
							fh1hmAYzyWp7H1O7Q9k.Wm2MkI9cYb();
						}
						qvCW30dDHYwWOtUIy6.sJdYH5f0IP = dictionary;
					}
				}
				FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
				for (int m = 0; m < fields.Length; m++)
				{
					try
					{
						FieldInfo fieldInfo = fields[m];
						int metadataToken = fieldInfo.MetadataToken;
						int num23 = qvCW30dDHYwWOtUIy6.sJdYH5f0IP[metadataToken];
						bool flag2 = (num23 & 1073741824) > 0;
						num23 &= 1073741823;
						MethodInfo methodInfo = (MethodInfo)typeof(qvCW30dDHYwWOtUIy6).Module.ResolveMethod(num23, typeFromHandle.GetGenericArguments(), new Type[0]);
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

		// Token: 0x06000045 RID: 69 RVA: 0x000039A0 File Offset: 0x00001BA0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void R53xBHkCI()
		{
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000039A4 File Offset: 0x00001BA4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void BPbypFY7D(object \u0020, int \u0020)
		{
			vhILP2MREs6PoGMjdHQ.KuXMtyiaBn(0, new object[] { \u0020, \u0020 }, null);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000039E4 File Offset: 0x00001BE4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string FQSiEQSCW(int \u0020)
		{
			if (qvCW30dDHYwWOtUIy6.TBeYN5LFa3.Length == 0)
			{
				qvCW30dDHYwWOtUIy6.y07YdwruMc = new List<string>();
				qvCW30dDHYwWOtUIy6.mYCYIhCEKN = new List<int>();
				qvCW30dDHYwWOtUIy6.BPbypFY7D(qvCW30dDHYwWOtUIy6.dllY2vEloY.GetManifestResourceStream("yMNjHaYmWIlGx6gT2G.EZqwKpM6e8K56BZGDt"), \u0020);
			}
			if (qvCW30dDHYwWOtUIy6.U4xYvd7pUg < 75)
			{
				if (qvCW30dDHYwWOtUIy6.dllY2vEloY != new StackFrame(1).GetMethod().DeclaringType.Assembly)
				{
					throw new Exception();
				}
				qvCW30dDHYwWOtUIy6.U4xYvd7pUg++;
			}
			object qmyybXbxMh = qvCW30dDHYwWOtUIy6.QMYYbXbxMh;
			lock (qmyybXbxMh)
			{
				int num = BitConverter.ToInt32(qvCW30dDHYwWOtUIy6.TBeYN5LFa3, \u0020);
				if (num < qvCW30dDHYwWOtUIy6.mYCYIhCEKN.Count && qvCW30dDHYwWOtUIy6.mYCYIhCEKN[num] == \u0020)
				{
					return qvCW30dDHYwWOtUIy6.y07YdwruMc[num];
				}
				try
				{
					PUJl6HMfyNoASU7yHDb.U5IJPevrmx();
					byte[] array = new byte[num];
					Array.Copy(qvCW30dDHYwWOtUIy6.TBeYN5LFa3, \u0020 + 4, array, 0, num);
					string @string = Encoding.Unicode.GetString(array, 0, array.Length);
					qvCW30dDHYwWOtUIy6.y07YdwruMc.Add(@string);
					qvCW30dDHYwWOtUIy6.mYCYIhCEKN.Add(\u0020);
					Array.Copy(BitConverter.GetBytes(qvCW30dDHYwWOtUIy6.y07YdwruMc.Count - 1), 0, qvCW30dDHYwWOtUIy6.TBeYN5LFa3, \u0020, 4);
					return @string;
				}
				catch
				{
				}
			}
			return "";
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003B5C File Offset: 0x00001D5C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string GWCWRyZMe(object \u0020)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(\u0020);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003B8C File Offset: 0x00001D8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint WBXtIxN2j(IntPtr \u0020, IntPtr \u0020, IntPtr \u0020, [MarshalAs(UnmanagedType.U4)] uint \u0020, IntPtr \u0020, ref uint \u0020)
		{
			IntPtr intPtr = \u0020;
			if (qvCW30dDHYwWOtUIy6.cs2YlU7n3i)
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
			object obj = qvCW30dDHYwWOtUIy6.oBEYiiMK8Z[num];
			if (obj == null)
			{
				return qvCW30dDHYwWOtUIy6.CATYwKdgRT(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			qvCW30dDHYwWOtUIy6.FrX3D7YZMOMqCdWreZ6 frX3D7YZMOMqCdWreZ = (qvCW30dDHYwWOtUIy6.FrX3D7YZMOMqCdWreZ6)obj;
			IntPtr intPtr2 = Marshal.AllocCoTaskMem(frX3D7YZMOMqCdWreZ.yMZYAWkgc8.Length);
			Marshal.Copy(frX3D7YZMOMqCdWreZ.yMZYAWkgc8, 0, intPtr2, frX3D7YZMOMqCdWreZ.yMZYAWkgc8.Length);
			if (frX3D7YZMOMqCdWreZ.FTXYcopS1m)
			{
				\u0020 = intPtr2;
				\u0020 = (uint)frX3D7YZMOMqCdWreZ.yMZYAWkgc8.Length;
				qvCW30dDHYwWOtUIy6.fY7DsrDOt(\u0020, frX3D7YZMOMqCdWreZ.yMZYAWkgc8.Length, 64, ref qvCW30dDHYwWOtUIy6.eCQYRaTWH4);
				return 0U;
			}
			Marshal.WriteIntPtr(intPtr, IntPtr.Size * 2, intPtr2);
			Marshal.WriteInt32(intPtr, IntPtr.Size * 3, frX3D7YZMOMqCdWreZ.yMZYAWkgc8.Length);
			uint num2 = 0U;
			if (\u0020 != 216669565U || qvCW30dDHYwWOtUIy6.rUqYySGtYK)
			{
				num2 = qvCW30dDHYwWOtUIy6.CATYwKdgRT(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			else
			{
				qvCW30dDHYwWOtUIy6.rUqYySGtYK = true;
			}
			return num2;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003CC0 File Offset: 0x00001EC0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int a218U6OLV()
		{
			return 5;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003CC4 File Offset: 0x00001EC4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ek2FhCoNN()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003CF4 File Offset: 0x00001EF4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Delegate S8GnlcCdU(IntPtr \u0020, Type \u0020)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[] { \u0020, \u0020 });
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003D54 File Offset: 0x00001F54
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe static void fkYjhgZND()
		{
			int num = 275;
			for (;;)
			{
				int num2 = num;
				long num3;
				byte[] array;
				int num4;
				byte[] array2;
				int num5;
				byte[] array4;
				int num7;
				byte[] array5;
				qvCW30dDHYwWOtUIy6.fh1hmAYzyWp7H1O7Q9k fh1hmAYzyWp7H1O7Q9k;
				int num8;
				byte[] array7;
				byte[] array8;
				int num9;
				byte[] array9;
				int num11;
				byte[] array10;
				IntPtr intPtr3;
				qvCW30dDHYwWOtUIy6.FrX3D7YZMOMqCdWreZ6 frX3D7YZMOMqCdWreZ;
				byte[] array11;
				byte[] array12;
				byte[] array13;
				int num16;
				byte[] array15;
				IntPtr intPtr6;
				long num23;
				uint num26;
				long num27;
				ICryptoTransform cryptoTransform;
				int num29;
				qvCW30dDHYwWOtUIy6.FrX3D7YZMOMqCdWreZ6 frX3D7YZMOMqCdWreZ2;
				int num30;
				uint num31;
				int num48;
				uint num49;
				uint num61;
				IntPtr intPtr9;
				for (;;)
				{
					IntPtr intPtr;
					int num6;
					IntPtr intPtr2;
					int num10;
					int num13;
					long num14;
					uint num17;
					int num18;
					int num19;
					byte[] array14;
					IntPtr intPtr5;
					int num22;
					int num24;
					int num25;
					int num28;
					uint num32;
					int num33;
					int num34;
					Process process;
					IntPtr intPtr8;
					IntPtr zero;
					byte[] array19;
					int num42;
					int num56;
					int num62;
					int num63;
					uint num64;
					int num65;
					int num66;
					int num68;
					switch (num2)
					{
					case 0:
						goto IL_3B16;
					case 1:
						goto IL_3B02;
					case 2:
						goto IL_2C72;
					case 3:
						qvCW30dDHYwWOtUIy6.zCIt99Jc1e32c70pTJV(new IntPtr((void*)(&num3)), 0, 0L);
						num2 = 36;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 53;
							continue;
						}
						continue;
					case 4:
						array[27] = (byte)num4;
						num2 = 185;
						continue;
					case 5:
					{
						byte[] array3;
						array2[num5 + 6] = array3[6];
						num2 = 261;
						continue;
					}
					case 6:
						array4[2] = 114;
						num2 = 31;
						continue;
					case 7:
						array[8] = 93 - 12;
						num2 = 431;
						continue;
					case 8:
						goto IL_202D;
					case 9:
						if (qvCW30dDHYwWOtUIy6.fY7DsrDOt(intPtr, 4, 4, ref num6) != 0)
						{
							goto IL_1680;
						}
						num2 = 578;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 422;
							continue;
						}
						continue;
					case 10:
						qvCW30dDHYwWOtUIy6.qM8gP3GqsirqxOaQyQS();
						num2 = 545;
						continue;
					case 11:
						array[28] = (byte)num7;
						num2 = 248;
						continue;
					case 12:
						array5 = qvCW30dDHYwWOtUIy6.TBGib5GaoRbOwonU4x7(qvCW30dDHYwWOtUIy6.Ri9YxOlYeL.ToInt32());
						num2 = 85;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 243;
							continue;
						}
						continue;
					case 13:
						goto IL_228A;
					case 14:
					{
						byte[] array6 = qvCW30dDHYwWOtUIy6.AoWimXG9OLHGUJZiN4k(fh1hmAYzyWp7H1O7Q9k, (int)qvCW30dDHYwWOtUIy6.fEWrHoGXap74qUqtuNp(qvCW30dDHYwWOtUIy6.tBC9xdGeqmBi7Dijkaj(fh1hmAYzyWp7H1O7Q9k)));
						num2 = 29;
						continue;
					}
					case 15:
					{
						byte[] array3;
						array2[num8 + 3] = array3[3];
						num2 = 371;
						continue;
					}
					case 16:
					{
						byte[] array3 = null;
						num2 = 626;
						continue;
					}
					case 17:
						array[10] = 145 - 48;
						num2 = 329;
						continue;
					case 18:
						array7[7] = 56 + 73;
						num2 = 528;
						continue;
					case 19:
						goto IL_5D42;
					case 20:
						array[5] = 73 + 124;
						num2 = 317;
						continue;
					case 21:
						array2[num5 + 6] = array8[6];
						num2 = 146;
						continue;
					case 22:
						num7 = 155 - 51;
						num2 = 332;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 246;
							continue;
						}
						continue;
					case 23:
						qvCW30dDHYwWOtUIy6.fY7DsrDOt(intPtr2, 4, 8, ref num6);
						num2 = 110;
						continue;
					case 24:
						num9 = 181 - 60;
						num2 = 61;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 410;
							continue;
						}
						continue;
					case 25:
						goto IL_5E60;
					case 26:
						array[18] = 243 - 81;
						num2 = 395;
						continue;
					case 27:
						num10 = array9.Length / 4;
						num2 = 461;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 332;
							continue;
						}
						continue;
					case 28:
						array7[14] = 65 + 93;
						num2 = 297;
						continue;
					case 29:
						goto IL_1725;
					case 30:
						array7[8] = (byte)num11;
						num2 = 463;
						continue;
					case 31:
						array4[3] = 106;
						num2 = 125;
						continue;
					case 32:
						goto IL_0D64;
					case 33:
						array[6] = 50 + 40;
						num2 = 491;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 547;
							continue;
						}
						continue;
					case 34:
						goto IL_219B;
					case 35:
						goto IL_23ED;
					case 36:
						array[2] = (byte)num7;
						num2 = 176;
						continue;
					case 37:
						array7[12] = (byte)num9;
						num2 = 24;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 16;
							continue;
						}
						continue;
					case 38:
						array4[7] = 116;
						num2 = 508;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 37;
							continue;
						}
						continue;
					case 39:
						array10[3] = 74;
						num2 = 95;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 94;
							continue;
						}
						continue;
					case 40:
						array7[3] = (byte)num11;
						num2 = 335;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 477;
							continue;
						}
						continue;
					case 41:
						array[26] = 86 + 104;
						num2 = 534;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 338;
							continue;
						}
						continue;
					case 42:
						num4 = 15 + 105;
						num2 = 166;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 68;
							continue;
						}
						continue;
					case 43:
						num4 = 7 + 109;
						num2 = 98;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 158;
							continue;
						}
						continue;
					case 44:
					{
						uint num12 = 4059231220U;
						num2 = 394;
						continue;
					}
					case 45:
						goto IL_30BA;
					case 46:
						array[1] = 16 + 119;
						num2 = 171;
						continue;
					case 47:
						intPtr3 = qvCW30dDHYwWOtUIy6.RfgZntG0ktbc0Jukiql(qvCW30dDHYwWOtUIy6.EhTlEjGU346V3fEYcTO(qvCW30dDHYwWOtUIy6.dllY2vEloY)[0]);
						num2 = 470;
						continue;
					case 48:
						num13 += 8;
						num2 = 320;
						continue;
					case 49:
						goto IL_5909;
					case 50:
						array2[num8 + 1] = array8[1];
						num2 = 60;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 106;
							continue;
						}
						continue;
					case 51:
						frX3D7YZMOMqCdWreZ = default(qvCW30dDHYwWOtUIy6.FrX3D7YZMOMqCdWreZ6);
						num2 = 509;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 6;
							continue;
						}
						continue;
					case 52:
						goto IL_3753;
					case 53:
						qvCW30dDHYwWOtUIy6.gUk62wJzVCx5TxpXjRZ(new byte[1], 0, qvCW30dDHYwWOtUIy6.d6jirSJAIRb0tZhRYXq(8), 1);
						num2 = 391;
						continue;
					case 54:
						goto IL_4E07;
					case 55:
						goto IL_429B;
					case 56:
						num14 = 0L;
						num2 = 116;
						continue;
					case 57:
						num5 = 18;
						num2 = 572;
						continue;
					case 58:
						array7[15] = 28 + 13;
						num2 = 126;
						continue;
					case 59:
					{
						IntPtr intPtr4;
						if (!qvCW30dDHYwWOtUIy6.aFyLxdGZcjEJCP7D4Kv(intPtr4, IntPtr.Zero))
						{
							goto IL_45F0;
						}
						num2 = 127;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 215;
							continue;
						}
						continue;
					}
					case 60:
					{
						byte[] array6;
						array11 = array6;
						num2 = 177;
						continue;
					}
					case 61:
						num7 = 46 + 34;
						num2 = 348;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 23;
							continue;
						}
						continue;
					case 62:
						array[28] = (byte)num7;
						num2 = 307;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 505;
							continue;
						}
						continue;
					case 63:
						array[26] = (byte)num4;
						num2 = 316;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 74;
							continue;
						}
						continue;
					case 64:
						array12[1] = array13[0];
						num2 = 180;
						continue;
					case 65:
					{
						byte[] array3;
						array2[num5 + 2] = array3[2];
						num2 = 554;
						continue;
					}
					case 66:
						goto IL_56CE;
					case 67:
						if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() != 4)
						{
							goto IL_0C23;
						}
						num2 = 12;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 1;
							continue;
						}
						continue;
					case 68:
						goto IL_5080;
					case 69:
					{
						byte[] array3;
						array2[num8 + 1] = array3[1];
						num2 = 133;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 328;
							continue;
						}
						continue;
					}
					case 70:
						goto IL_1E4A;
					case 71:
						num4 = 110 + 54;
						num2 = 558;
						continue;
					case 72:
						array7[0] = 223 - 74;
						num2 = 165;
						continue;
					case 73:
						array[14] = 249 - 83;
						num2 = 483;
						continue;
					case 74:
					{
						int num15 = qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
						num2 = 181;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 123;
							continue;
						}
						continue;
					}
					case 75:
						num7 = 165 + 44;
						num2 = 295;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 441;
							continue;
						}
						continue;
					case 76:
						array7[10] = 40 + 33;
						num2 = 372;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 467;
							continue;
						}
						continue;
					case 77:
						num4 = 204 - 68;
						num2 = 382;
						continue;
					case 78:
						goto IL_5E60;
					case 79:
						array[19] = (byte)num4;
						num2 = 153;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 8;
							continue;
						}
						continue;
					case 80:
						array[19] = (byte)num7;
						num2 = 559;
						continue;
					case 81:
						array[0] = 21 + 14;
						num2 = 451;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 59;
							continue;
						}
						continue;
					case 82:
						goto IL_223A;
					case 83:
						array4[1] = 115;
						num2 = 600;
						continue;
					case 84:
					{
						IntPtr intPtr4 = IntPtr.Zero;
						num2 = 59;
						continue;
					}
					case 85:
						array[20] = (byte)num7;
						num2 = 22;
						continue;
					case 86:
						num4 = 5 + 15;
						num2 = 197;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 177;
							continue;
						}
						continue;
					case 87:
						num16++;
						num2 = 109;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 28;
							continue;
						}
						continue;
					case 88:
						array[14] = (byte)num7;
						num2 = 75;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 6;
							continue;
						}
						continue;
					case 89:
						array7[15] = (byte)num11;
						num2 = 610;
						continue;
					case 90:
						array4[10] = 108;
						num2 = 459;
						continue;
					case 91:
						goto IL_45CD;
					case 92:
						array10[1] = 101;
						num2 = 55;
						continue;
					case 93:
						goto IL_5909;
					case 94:
						num4 = 106 + 72;
						num2 = 618;
						continue;
					case 95:
						array10[4] = 105;
						num2 = 98;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 48;
							continue;
						}
						continue;
					case 96:
						goto IL_5D75;
					case 97:
						array[3] = (byte)num4;
						num2 = 511;
						continue;
					case 98:
						array10[5] = 116;
						num2 = 154;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 538;
							continue;
						}
						continue;
					case 99:
						array7[15] = 43 + 29;
						num2 = 58;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 31;
							continue;
						}
						continue;
					case 100:
						array[6] = 26 + 56;
						num2 = 33;
						continue;
					case 101:
						array[4] = 41 + 48;
						num2 = 35;
						continue;
					case 102:
						goto IL_129F;
					case 103:
						num4 = 67 + 123;
						num2 = 426;
						continue;
					case 104:
						array[14] = (byte)num4;
						num2 = 59;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 73;
							continue;
						}
						continue;
					case 105:
						array[9] = 30 + 116;
						num2 = 97;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 423;
							continue;
						}
						continue;
					case 106:
						array2[num8 + 2] = array8[2];
						num2 = 340;
						continue;
					case 107:
						num11 = 26 + 56;
						num2 = 233;
						continue;
					case 108:
						array[21] = (byte)num4;
						num2 = 429;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 395;
							continue;
						}
						continue;
					case 109:
						goto IL_6101;
					case 110:
						goto IL_2A65;
					case 111:
						num11 = 188 - 62;
						num2 = 359;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 101;
							continue;
						}
						continue;
					case 112:
						goto IL_2008;
					case 113:
						goto IL_177F;
					case 114:
						goto IL_0C94;
					case 115:
						array7[12] = (byte)num9;
						num2 = 332;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 373;
							continue;
						}
						continue;
					case 116:
						if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() == 4)
						{
							num2 = 452;
							continue;
						}
						goto IL_2F4F;
					case 117:
						qvCW30dDHYwWOtUIy6.lgOYUS6yUH = new qvCW30dDHYwWOtUIy6.ipKfv4YCBHm4wmIbaZn(qvCW30dDHYwWOtUIy6.WBXtIxN2j);
						num2 = 407;
						continue;
					case 118:
						array7[13] = (byte)num9;
						num2 = 136;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 144;
							continue;
						}
						continue;
					case 119:
						array[17] = 154 - 53;
						num2 = 26;
						continue;
					case 120:
						array7 = new byte[16];
						num2 = 72;
						continue;
					case 121:
						array[9] = 63 + 92;
						num2 = 189;
						continue;
					case 122:
						num17 <<= 8;
						num2 = 95;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 364;
							continue;
						}
						continue;
					case 123:
						goto IL_2656;
					case 124:
						num7 = 167 - 55;
						num2 = 138;
						continue;
					case 125:
						array4[4] = 105;
						num2 = 635;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 410;
							continue;
						}
						continue;
					case 126:
						num11 = 143 + 36;
						num2 = 83;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 89;
							continue;
						}
						continue;
					case 127:
						if (array13 != null)
						{
							goto Block_112;
						}
						goto IL_2668;
					case 128:
						array7[4] = 151 + 56;
						num2 = 490;
						continue;
					case 129:
						qvCW30dDHYwWOtUIy6.M0YiB0BhHTIgyZHvFJ9(qvCW30dDHYwWOtUIy6.lgOYUS6yUH);
						num2 = 330;
						continue;
					case 130:
						goto IL_44BD;
					case 131:
						num7 = 136 - 45;
						num2 = 532;
						continue;
					case 132:
						if (qvCW30dDHYwWOtUIy6.fY7DsrDOt(intPtr2, 4, 4, ref num6) != 0)
						{
							goto IL_2A65;
						}
						num2 = 23;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 10;
							continue;
						}
						continue;
					case 133:
					{
						byte[] array3;
						array2[num5 + 4] = array3[4];
						num2 = 178;
						continue;
					}
					case 134:
						num9 = 159 + 11;
						num2 = 60;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 214;
							continue;
						}
						continue;
					case 135:
						goto IL_2F67;
					case 136:
						num11 = 53 + 16;
						num2 = 449;
						continue;
					case 137:
						num18 = 0;
						num2 = 350;
						continue;
					case 138:
						array[3] = (byte)num7;
						num2 = 613;
						continue;
					case 139:
						array7[6] = 168 - 56;
						num2 = 304;
						continue;
					case 140:
						array7[10] = 238 - 79;
						num2 = 174;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 69;
							continue;
						}
						continue;
					case 141:
						num19++;
						num2 = 421;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 360;
							continue;
						}
						continue;
					case 142:
						num17 = 0U;
						num2 = 623;
						continue;
					case 143:
						qvCW30dDHYwWOtUIy6.VOaY0shBjx = intPtr3.ToInt64();
						num2 = 601;
						continue;
					case 144:
						num11 = 234 - 78;
						num2 = 266;
						continue;
					case 145:
						array7[14] = 124 + 14;
						num2 = 134;
						continue;
					case 146:
						array2[num5 + 7] = array8[7];
						num2 = 68;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 93;
							continue;
						}
						continue;
					case 147:
						array7[12] = 221 - 73;
						num2 = 288;
						continue;
					case 148:
						array[25] = (byte)num7;
						num2 = 254;
						continue;
					case 149:
						if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() != 4)
						{
							num2 = 300;
							continue;
						}
						goto IL_1B25;
					case 150:
						array[22] = 207 - 69;
						num2 = 594;
						continue;
					case 151:
						num9 = 72 + 43;
						num2 = 401;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 162;
							continue;
						}
						continue;
					case 152:
						goto IL_0F21;
					case 153:
						num7 = 213 - 71;
						num2 = 32;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 85;
							continue;
						}
						continue;
					case 154:
						num11 = 210 - 70;
						num2 = 18;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 30;
							continue;
						}
						continue;
					case 155:
						array14 = null;
						num2 = 149;
						continue;
					case 156:
						array7[1] = (byte)num11;
						num2 = 492;
						continue;
					case 157:
						goto IL_4E81;
					case 158:
						array[8] = (byte)num4;
						num2 = 386;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 479;
							continue;
						}
						continue;
					case 159:
						array2 = array14;
						num2 = 269;
						continue;
					case 160:
					{
						IntPtr intPtr4;
						string text;
						intPtr5 = qvCW30dDHYwWOtUIy6.XWi2ETGAlHq1UMp3VRN((qvCW30dDHYwWOtUIy6.urvwbDYKRHr2nFerJh6)qvCW30dDHYwWOtUIy6.wn5AFCGcfc8yjINTqCZ(qvCW30dDHYwWOtUIy6.OZt1aWanO(intPtr4, text), qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6.urvwbDYKRHr2nFerJh6).TypeHandle)));
						num2 = 346;
						continue;
					}
					case 161:
						goto IL_54CA;
					case 162:
						try
						{
							for (;;)
							{
								IEnumerator enumerator;
								if (qvCW30dDHYwWOtUIy6.p3pYGVGJGpGSnWZnm6a(enumerator))
								{
									goto IL_344E;
								}
								int num20 = 2;
								ProcessModule processModule;
								for (;;)
								{
									IL_32FD:
									switch (num20)
									{
									case 1:
									{
										Version version = new Version(4, 0, 30319, 17921);
										num20 = 5;
										continue;
									}
									case 2:
										goto IL_34A3;
									case 3:
									{
										Version version2 = new Version(4, 0, 30319, 17020);
										num20 = 1;
										if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
										{
											num20 = 0;
											continue;
										}
										continue;
									}
									case 4:
									{
										Version version;
										Version version3;
										if (qvCW30dDHYwWOtUIy6.ld5DHPGNE6VnNiPBK83(version3, version))
										{
											goto IL_339A;
										}
										num20 = 0;
										if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
										{
											num20 = 0;
											continue;
										}
										continue;
									}
									case 5:
									{
										Version version2;
										Version version3;
										if (qvCW30dDHYwWOtUIy6.FGQsk9GIXb1QDtoJZsL(version3, version2))
										{
											num20 = 4;
											continue;
										}
										break;
									}
									case 6:
										goto IL_33FE;
									case 8:
									{
										Version version3 = new Version(qvCW30dDHYwWOtUIy6.pt54hEGs2YV72ugHbYc(qvCW30dDHYwWOtUIy6.JdoUWDGHXrukpkaghGP(processModule)), qvCW30dDHYwWOtUIy6.dojPqxGv33supZDCH8N(qvCW30dDHYwWOtUIy6.JdoUWDGHXrukpkaghGP(processModule)), qvCW30dDHYwWOtUIy6.sHSjP9GbwCu3koEqOym(qvCW30dDHYwWOtUIy6.JdoUWDGHXrukpkaghGP(processModule)), qvCW30dDHYwWOtUIy6.KTqHUpGdjL5oSU762Qq(qvCW30dDHYwWOtUIy6.JdoUWDGHXrukpkaghGP(processModule)));
										num20 = 3;
										continue;
									}
									case 9:
										goto IL_339A;
									case 10:
										if (qvCW30dDHYwWOtUIy6.eyeXweGEIAJ2ASO259X(qvCW30dDHYwWOtUIy6.Kiq4M3GOiOoDEDEZinT(qvCW30dDHYwWOtUIy6.wUvoH8GhMM4PS4HUyWs(processModule)), "clrjit.dll"))
										{
											num20 = 8;
											continue;
										}
										break;
									case 11:
										goto IL_344E;
									}
									break;
									IL_339A:
									qvCW30dDHYwWOtUIy6.cs2YlU7n3i = true;
									num20 = 6;
								}
								continue;
								IL_344E:
								processModule = (ProcessModule)qvCW30dDHYwWOtUIy6.F4LJLTGfCn9GpN8DQQp(enumerator);
								num20 = 2;
								if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
								{
									num20 = 10;
									goto IL_32FD;
								}
								goto IL_32FD;
							}
							IL_33FE:
							IL_34A3:
							goto IL_56CE;
						}
						finally
						{
							IEnumerator enumerator;
							IDisposable disposable = enumerator as IDisposable;
							int num21 = 1;
							if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
							{
								num21 = 0;
							}
							for (;;)
							{
								switch (num21)
								{
								case 1:
									if (disposable == null)
									{
										num21 = 0;
										if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
										{
											num21 = 2;
											continue;
										}
										continue;
									}
									break;
								case 2:
									goto IL_34E9;
								case 3:
									goto IL_353A;
								}
								qvCW30dDHYwWOtUIy6.kSsP84GGVZm1pRcgkcP(disposable);
								num21 = 3;
							}
							IL_34E9:
							IL_353A:;
						}
						goto IL_3545;
					case 163:
						goto IL_12AC;
					case 164:
						goto IL_4564;
					case 165:
						array7[0] = 199 - 66;
						num2 = 581;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 120;
							continue;
						}
						continue;
					case 166:
						array[23] = (byte)num4;
						num2 = 232;
						continue;
					case 167:
						array7[11] = (byte)num11;
						num2 = 298;
						continue;
					case 168:
						num7 = 16 + 23;
						num2 = 415;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 291;
							continue;
						}
						continue;
					case 169:
						num17 = 0U;
						num2 = 258;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 39;
							continue;
						}
						continue;
					case 170:
						array7[0] = 177 + 66;
						num2 = 419;
						continue;
					case 171:
						array[1] = 96 + 107;
						num2 = 90;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 540;
							continue;
						}
						continue;
					case 172:
						array12[13] = array13[6];
						num2 = 91;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 379;
							continue;
						}
						continue;
					case 173:
						array7[3] = 118 + 38;
						num2 = 605;
						continue;
					case 174:
						array7[10] = 213 + 13;
						num2 = 580;
						continue;
					case 175:
						array15 = new byte[array11.Length];
						num2 = 26;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 27;
							continue;
						}
						continue;
					case 176:
						array[2] = 235 - 78;
						num2 = 71;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 43;
							continue;
						}
						continue;
					case 177:
						goto IL_4454;
					case 178:
					{
						byte[] array3;
						array2[num5 + 5] = array3[5];
						num2 = 4;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 5;
							continue;
						}
						continue;
					}
					case 179:
						array7[8] = (byte)num11;
						num2 = 107;
						continue;
					case 180:
						goto IL_3840;
					case 181:
					{
						int num15;
						intPtr6 = new IntPtr(qvCW30dDHYwWOtUIy6.m4oYg3B07I + (long)num15 - (long)num22);
						num2 = 318;
						continue;
					}
					case 182:
						array12[5] = array13[2];
						num2 = 211;
						continue;
					case 183:
						num23 = intPtr3.ToInt64();
						num2 = 466;
						continue;
					case 184:
						array[9] = (byte)num7;
						num2 = 52;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 105;
							continue;
						}
						continue;
					case 185:
						num4 = 134 - 44;
						num2 = 319;
						continue;
					case 186:
						if (num24 != num25 - 1)
						{
							goto IL_1A97;
						}
						num2 = 334;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 456;
							continue;
						}
						continue;
					case 187:
						array4[1] = 108;
						num2 = 6;
						continue;
					case 188:
						goto IL_2D88;
					case 189:
						num7 = 24 + 55;
						num2 = 47;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 184;
							continue;
						}
						continue;
					case 190:
						qvCW30dDHYwWOtUIy6.bRP9VfGFr1tojq3jx34(fh1hmAYzyWp7H1O7Q9k);
						num2 = 625;
						continue;
					case 191:
						array2[num5] = array8[0];
						num2 = 453;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 232;
							continue;
						}
						continue;
					case 192:
						array[15] = (byte)num4;
						num2 = 280;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 325;
							continue;
						}
						continue;
					case 193:
						goto IL_287A;
					case 194:
						goto IL_5D42;
					case 195:
						array[16] = 157 - 52;
						num2 = 228;
						continue;
					case 196:
						num4 = 122 + 81;
						num2 = 108;
						continue;
					case 197:
						goto IL_2B24;
					case 198:
						num4 = 131 + 113;
						num2 = 55;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 79;
							continue;
						}
						continue;
					case 199:
						num7 = 5 + 123;
						num2 = 472;
						continue;
					case 200:
						array[2] = 110 + 56;
						num2 = 263;
						continue;
					case 201:
						goto IL_0AC8;
					case 202:
						array[24] = 125 - 73;
						num2 = 117;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 349;
							continue;
						}
						continue;
					case 203:
						goto IL_2322;
					case 204:
						num26 = 255U;
						num2 = 376;
						continue;
					case 205:
						array4[9] = 100;
						num2 = 36;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 90;
							continue;
						}
						continue;
					case 206:
						array[21] = (byte)num7;
						num2 = 150;
						continue;
					case 207:
						goto IL_1A66;
					case 208:
						array[21] = 177 - 59;
						num2 = 631;
						continue;
					case 209:
						goto IL_61A9;
					case 210:
						num9 = 52 - 7;
						num2 = 324;
						continue;
					case 211:
						array12[7] = array13[3];
						num2 = 393;
						continue;
					case 212:
						num27 = (long)qvCW30dDHYwWOtUIy6.A0kQ1rGz3RiEXIem8Pn(intPtr5);
						num2 = 78;
						continue;
					case 213:
						array[27] = (byte)num4;
						num2 = 221;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 214:
						array7[14] = (byte)num9;
						num2 = 72;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 99;
							continue;
						}
						continue;
					case 215:
						array4 = new byte[10];
						num2 = 617;
						continue;
					case 216:
						num11 = 53 - 53;
						num2 = 40;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 11;
							continue;
						}
						continue;
					case 217:
						num4 = 225 + 25;
						num2 = 408;
						continue;
					case 218:
						num24 = 0;
						num2 = 306;
						continue;
					case 219:
						qvCW30dDHYwWOtUIy6.cLkJSJJDmOVCfaxv0w6(new IntPtr((void*)(&num3)), 0);
						num2 = 45;
						continue;
					case 220:
						goto IL_6101;
					case 221:
						num4 = 201 - 67;
						num2 = 4;
						continue;
					case 222:
						array4[7] = 100;
						num2 = 1;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 0;
							continue;
						}
						continue;
					case 223:
						goto IL_4EF6;
					case 224:
						goto IL_127C;
					case 225:
						num4 = 205 - 68;
						num2 = 414;
						continue;
					case 226:
						array[4] = (byte)num7;
						num2 = 292;
						continue;
					case 227:
						array7[7] = 142 - 47;
						num2 = 247;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 120;
							continue;
						}
						continue;
					case 228:
						num7 = 53 + 68;
						num2 = 541;
						continue;
					case 229:
						if (qvCW30dDHYwWOtUIy6.IhnWNKGotbLGdq1Bfgh(qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6).TypeHandle).Assembly) != null)
						{
							goto IL_2519;
						}
						num2 = 43;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 52;
							continue;
						}
						continue;
					case 230:
						goto IL_1E11;
					case 231:
						array[11] = (byte)num7;
						num2 = 77;
						continue;
					case 232:
						array[23] = 160 + 68;
						num2 = 155;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 262;
							continue;
						}
						continue;
					case 233:
						goto IL_1F2E;
					case 234:
						qvCW30dDHYwWOtUIy6.fY7DsrDOt(intPtr6, num28 * 4, num6, ref num6);
						num2 = 419;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 440;
							continue;
						}
						continue;
					case 235:
						goto IL_581C;
					case 236:
						num4 = 87 + 61;
						num2 = 560;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 122;
							continue;
						}
						continue;
					case 237:
						array[30] = 166 - 55;
						num2 = 86;
						continue;
					case 238:
						array7[5] = 130 - 84;
						num2 = 305;
						continue;
					case 239:
					{
						MemoryStream memoryStream = new MemoryStream();
						CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
						byte[] array6;
						qvCW30dDHYwWOtUIy6.ePpuydGiJulvLOL2abK(cryptoStream, array6, 0, array6.Length);
						qvCW30dDHYwWOtUIy6.gixmv2GWmhVbHCyCWij(cryptoStream);
						byte[] array16 = qvCW30dDHYwWOtUIy6.TrBynwGt33EAsUXKDWt(memoryStream);
						qvCW30dDHYwWOtUIy6.GXO1SIGwJ6Xso2MQrqv(array12, 0, array12.Length);
						qvCW30dDHYwWOtUIy6.XAkX9LG8QMrbuwFsbGD(memoryStream);
						num2 = 589;
						continue;
					}
					case 240:
						array7[0] = (byte)num11;
						num2 = 170;
						continue;
					case 241:
						goto IL_4FBE;
					case 242:
						num29 = qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k) - num22;
						num2 = 586;
						continue;
					case 243:
					{
						IntPtr intPtr7;
						array8 = qvCW30dDHYwWOtUIy6.TBGib5GaoRbOwonU4x7(intPtr7.ToInt32());
						num2 = 480;
						continue;
					}
					case 244:
						qvCW30dDHYwWOtUIy6.GXO1SIGwJ6Xso2MQrqv(array9, 0, array9.Length);
						num2 = 239;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 104;
							continue;
						}
						continue;
					case 245:
						array[12] = (byte)num7;
						num2 = 131;
						continue;
					case 246:
					{
						byte[] array16 = array15;
						num2 = 574;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 247;
							continue;
						}
						continue;
					}
					case 247:
						num11 = 209 - 69;
						num2 = 291;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 569;
							continue;
						}
						continue;
					case 248:
						array[28] = 129 - 43;
						num2 = 485;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 10;
							continue;
						}
						continue;
					case 249:
						array[24] = (byte)num4;
						num2 = 210;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 387;
							continue;
						}
						continue;
					case 250:
						break;
					case 251:
						array2[num5 + 6] = array5[6];
						num2 = 537;
						continue;
					case 252:
						goto IL_4304;
					case 253:
						goto IL_1D20;
					case 254:
						num4 = 235 - 78;
						num2 = 428;
						continue;
					case 255:
						array[16] = 91 + 12;
						num2 = 236;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 100;
							continue;
						}
						continue;
					case 256:
						goto IL_2668;
					case 257:
					{
						byte[] array17;
						frX3D7YZMOMqCdWreZ2.yMZYAWkgc8 = array17;
						num2 = 402;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 518;
							continue;
						}
						continue;
					}
					case 258:
						if (num30 <= 0)
						{
							goto IL_61A9;
						}
						num2 = 369;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 454;
							continue;
						}
						continue;
					case 259:
						array7[2] = 22 + 96;
						num2 = 276;
						continue;
					case 260:
						num31 = (uint)(((int)array9[(int)(num32 + 3U)] << 24) | ((int)array9[(int)(num32 + 2U)] << 16) | ((int)array9[(int)(num32 + 1U)] << 8) | (int)array9[(int)num32]);
						num2 = 204;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 70;
							continue;
						}
						continue;
					case 261:
					{
						byte[] array3;
						array2[num5 + 7] = array3[7];
						num2 = 351;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 196;
							continue;
						}
						continue;
					}
					case 262:
						num4 = 125 - 41;
						num2 = 249;
						continue;
					case 263:
						array[2] = 53 + 113;
						num2 = 124;
						continue;
					case 264:
						array4[6] = 46;
						num2 = 222;
						continue;
					case 265:
						num33 = 0;
						num2 = 561;
						continue;
					case 266:
						array7[14] = (byte)num11;
						num2 = 28;
						continue;
					case 267:
						array[20] = (byte)num7;
						num2 = 283;
						continue;
					case 268:
						goto IL_303B;
					case 269:
						array8 = null;
						num2 = 16;
						continue;
					case 270:
						goto IL_3050;
					case 271:
						qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
						num2 = 579;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 187;
							continue;
						}
						continue;
					case 272:
						array[19] = (byte)num7;
						num2 = 198;
						continue;
					case 273:
						num32 = (uint)(num34 * 4);
						num2 = 260;
						continue;
					case 274:
						goto IL_27C2;
					case 275:
						if (!qvCW30dDHYwWOtUIy6.e1JY9epcUF)
						{
							num2 = 274;
							continue;
						}
						goto IL_5D13;
					case 276:
						array7[2] = 174 - 107;
						num2 = 173;
						continue;
					case 277:
						num7 = 62 + 121;
						num2 = 62;
						continue;
					case 278:
						array2[num8 + 3] = array5[3];
						num2 = 140;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 582;
							continue;
						}
						continue;
					case 279:
						num7 = 17 + 1;
						num2 = 82;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 148;
							continue;
						}
						continue;
					case 280:
						try
						{
							IEnumerator enumerator = qvCW30dDHYwWOtUIy6.PRmqfpG2HdmrJijNqA6(qvCW30dDHYwWOtUIy6.IWje7fGlcnmLcNXUAy4(process));
							int num35 = 0;
							if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
							{
								num35 = 0;
							}
							switch (num35)
							{
							default:
								try
								{
									for (;;)
									{
										IL_5AD1:
										if (qvCW30dDHYwWOtUIy6.p3pYGVGJGpGSnWZnm6a(enumerator))
										{
											goto IL_5BAD;
										}
										int num36 = 7;
										ProcessModule processModule2;
										for (;;)
										{
											IL_5A9B:
											switch (num36)
											{
											case 1:
												goto IL_5B9E;
											case 2:
												goto IL_5B8F;
											case 3:
												goto IL_5B37;
											case 4:
												goto IL_5AD1;
											case 5:
												goto IL_5B56;
											case 6:
											{
												string text2;
												if (!qvCW30dDHYwWOtUIy6.eyeXweGEIAJ2ASO259X(qvCW30dDHYwWOtUIy6.wUvoH8GhMM4PS4HUyWs(processModule2), text2))
												{
													int num37 = 3;
													num36 = num37;
													continue;
												}
												break;
											}
											case 7:
												goto IL_5C20;
											case 8:
												goto IL_5B18;
											case 9:
												goto IL_5BAD;
											case 10:
											{
												long num38 = num14;
												intPtr3 = qvCW30dDHYwWOtUIy6.PfrLytGk5nh2v7cnFZs(processModule2);
												if (num38 > intPtr3.ToInt64() + (long)qvCW30dDHYwWOtUIy6.Bnb9EqBMpOq9eQapGNS(processModule2))
												{
													num36 = 5;
													continue;
												}
												goto IL_5AD1;
											}
											}
											long num39 = num14;
											intPtr3 = qvCW30dDHYwWOtUIy6.PfrLytGk5nh2v7cnFZs(processModule2);
											if (num39 < intPtr3.ToInt64())
											{
												goto IL_5B56;
											}
											num36 = 4;
											if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
											{
												num36 = 10;
												continue;
											}
											continue;
											IL_5B18:
											qvCW30dDHYwWOtUIy6.qM8gP3GqsirqxOaQyQS();
											num36 = 0;
											if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
											{
												num36 = 2;
												continue;
											}
											continue;
											IL_5B56:
											if (qvCW30dDHYwWOtUIy6.P9jwknBTulW14oNAiRJ(qvCW30dDHYwWOtUIy6.gD8QkRBk7P6TfgscGT9(qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6).TypeHandle).Assembly), null))
											{
												goto IL_5B18;
											}
											num36 = 0;
											if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
											{
												num36 = 1;
											}
										}
										IL_5B37:
										IL_5B9E:
										continue;
										IL_5BAD:
										processModule2 = (ProcessModule)qvCW30dDHYwWOtUIy6.F4LJLTGfCn9GpN8DQQp(enumerator);
										num36 = 1;
										if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
										{
											num36 = 6;
											goto IL_5A9B;
										}
										goto IL_5A9B;
									}
									IL_5B8F:
									return;
									IL_5C20:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num40 = 2;
									if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
									{
										num40 = 3;
									}
									for (;;)
									{
										switch (num40)
										{
										case 1:
											goto IL_5C87;
										case 2:
											goto IL_5CB7;
										case 3:
											if (disposable == null)
											{
												num40 = 1;
												if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
												{
													num40 = 1;
													continue;
												}
												continue;
											}
											break;
										}
										qvCW30dDHYwWOtUIy6.kSsP84GGVZm1pRcgkcP(disposable);
										num40 = 2;
									}
									IL_5C87:
									IL_5CB7:;
								}
								break;
							case 1:
								break;
							}
							goto IL_2C95;
						}
						catch
						{
							int num41 = 0;
							if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
							{
								num41 = 0;
							}
							switch (num41)
							{
							default:
								goto IL_2C95;
							}
						}
						goto IL_5D13;
					case 281:
						array[26] = (byte)num7;
						num2 = 471;
						continue;
					case 282:
						num4 = 60 + 114;
						num2 = 575;
						continue;
					case 283:
						array[20] = 163 - 54;
						num2 = 427;
						continue;
					case 284:
						qvCW30dDHYwWOtUIy6.kwP7v5gmp(intPtr8, intPtr, qvCW30dDHYwWOtUIy6.TBGib5GaoRbOwonU4x7(qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k)), 4U, out zero);
						num2 = 368;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 494;
							continue;
						}
						continue;
					case 285:
						frX3D7YZMOMqCdWreZ2 = default(qvCW30dDHYwWOtUIy6.FrX3D7YZMOMqCdWreZ6);
						num2 = 155;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 257;
							continue;
						}
						continue;
					case 286:
					{
						IntPtr intPtr7 = qvCW30dDHYwWOtUIy6.qolTG4BYUcaYu7AHhRI(qvCW30dDHYwWOtUIy6.lgOYUS6yUH);
						num2 = 11;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 56;
							continue;
						}
						continue;
					}
					case 287:
					{
						byte[] array3;
						array2[num8] = array3[0];
						num2 = 69;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 30;
							continue;
						}
						continue;
					}
					case 288:
						goto IL_3231;
					case 289:
						array13 = qvCW30dDHYwWOtUIy6.UJFokTGgJ0ToWN9ywdr(qvCW30dDHYwWOtUIy6.KYvSNqGutbDelNYfXgk(qvCW30dDHYwWOtUIy6.dllY2vEloY));
						num2 = 127;
						continue;
					case 290:
						array[25] = (byte)num7;
						num2 = 52;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 279;
							continue;
						}
						continue;
					case 291:
					{
						byte[] array16;
						fh1hmAYzyWp7H1O7Q9k = new qvCW30dDHYwWOtUIy6.fh1hmAYzyWp7H1O7Q9k(new MemoryStream(array16));
						num2 = 500;
						continue;
					}
					case 292:
						goto IL_569F;
					case 293:
						goto IL_3A8D;
					case 294:
						goto IL_1D0B;
					case 295:
						array[29] = (byte)num7;
						num2 = 103;
						continue;
					case 296:
					{
						bool flag = true;
						num2 = 32;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 18;
							continue;
						}
						continue;
					}
					case 297:
						num9 = 80 + 47;
						num2 = 353;
						continue;
					case 298:
						goto IL_4E64;
					case 299:
						goto IL_42D8;
					case 300:
					{
						byte[] array18 = new byte[40];
						qvCW30dDHYwWOtUIy6.X1fHUdBHSKFrhcdmW8l(array18, fieldof(<PrivateImplementationDetails>{CE0036D9-13C9-42F7-99A4-10AB39C8B015}.0E448EF5E5E60630BDDB19388CB6378436E3C65D03DD66DA7C6EBFF563BD857A).FieldHandle);
						array14 = array18;
						num2 = 182;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 253;
							continue;
						}
						continue;
					}
					case 301:
						num25 = array11.Length / 4;
						num2 = 130;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 175;
							continue;
						}
						continue;
					case 302:
						array19 = null;
						num2 = 291;
						continue;
					case 303:
						array2[num5 + 5] = array8[5];
						num2 = 9;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 21;
							continue;
						}
						continue;
					case 304:
						num11 = 87 + 91;
						num2 = 235;
						continue;
					case 305:
						num9 = 126 - 42;
						num2 = 189;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 525;
							continue;
						}
						continue;
					case 306:
						goto IL_1D5E;
					case 307:
						num7 = 94 + 35;
						num2 = 544;
						continue;
					case 308:
						if (qvCW30dDHYwWOtUIy6.fY7DsrDOt(intPtr6, num28 * 4, 4, ref num6) != 0)
						{
							goto IL_4649;
						}
						num2 = 314;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 280;
							continue;
						}
						continue;
					case 309:
						goto IL_2C95;
					case 310:
						array4[5] = 106;
						num2 = 604;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 331;
							continue;
						}
						continue;
					case 311:
						num7 = 45 + 70;
						num2 = 584;
						continue;
					case 312:
						goto IL_22C1;
					case 313:
						num42 = qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
						num2 = 388;
						continue;
					case 314:
						qvCW30dDHYwWOtUIy6.fY7DsrDOt(intPtr6, num28 * 4, 8, ref num6);
						num2 = 365;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 169;
							continue;
						}
						continue;
					case 315:
						array[12] = 154 - 51;
						num2 = 90;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 217;
							continue;
						}
						continue;
					case 316:
						num7 = 157 - 93;
						num2 = 207;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 281;
							continue;
						}
						continue;
					case 317:
						num7 = 53 + 81;
						num2 = 0;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 318:
						num28 = qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
						num2 = 308;
						continue;
					case 319:
						array[27] = (byte)num4;
						num2 = 412;
						continue;
					case 320:
						goto IL_1414;
					case 321:
						array2[num5 + 3] = array8[3];
						num2 = 474;
						continue;
					case 322:
						goto IL_3D3B;
					case 323:
					{
						int num43;
						qvCW30dDHYwWOtUIy6.fY7DsrDOt(new IntPtr(num27), qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B(), num43, ref num43);
						num2 = 484;
						continue;
					}
					case 324:
						array7[11] = (byte)num9;
						num2 = 147;
						continue;
					case 325:
						array[15] = 76 + 105;
						num2 = 341;
						continue;
					case 326:
						goto IL_0FA9;
					case 327:
						if (qvCW30dDHYwWOtUIy6.Bb4xfNGr2sxAJDCqyek(qvCW30dDHYwWOtUIy6.edqCJNGT3SHliq9mGEh(qvCW30dDHYwWOtUIy6.PfrLytGk5nh2v7cnFZs(qvCW30dDHYwWOtUIy6.yFVUB0GM1IJMpNFCH1g(qvCW30dDHYwWOtUIy6.l5vTxwGYisGB1necjhn())), "__", 10U), IntPtr.Zero))
						{
							num2 = 268;
							continue;
						}
						goto IL_560C;
					case 328:
					{
						byte[] array3;
						array2[num8 + 2] = array3[2];
						num2 = 15;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 6;
							continue;
						}
						continue;
					}
					case 329:
						array[10] = 91 + 109;
						num2 = 389;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 577;
							continue;
						}
						continue;
					case 330:
						goto IL_4627;
					case 331:
						goto IL_45F0;
					case 332:
						array[20] = (byte)num7;
						num2 = 336;
						continue;
					case 333:
						num7 = 134 - 44;
						num2 = 80;
						continue;
					case 334:
						goto IL_1B25;
					case 335:
						qvCW30dDHYwWOtUIy6.PiUtbOGSik3gcAg4IAJ(array12);
						num2 = 188;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 289;
							continue;
						}
						continue;
					case 336:
						num7 = 199 - 66;
						num2 = 28;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 267;
							continue;
						}
						continue;
					case 337:
						num9 = 244 - 81;
						num2 = 409;
						continue;
					case 338:
						array[27] = (byte)num7;
						num2 = 536;
						continue;
					case 339:
						array[29] = 178 - 59;
						num2 = 447;
						continue;
					case 340:
						array2[num8 + 3] = array8[3];
						num2 = 49;
						continue;
					case 341:
						num4 = 153 - 41;
						num2 = 11;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 201;
							continue;
						}
						continue;
					case 342:
						intPtr8 = qvCW30dDHYwWOtUIy6.m5nhVoGjtAdCSlQNrly(56U, 1, (uint)qvCW30dDHYwWOtUIy6.YUqSDdGnWBVeu2IEOE3(qvCW30dDHYwWOtUIy6.l5vTxwGYisGB1necjhn()));
						num2 = 207;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 171;
							continue;
						}
						continue;
					case 343:
						goto IL_1461;
					case 344:
						goto IL_314C;
					case 345:
						try
						{
							qvCW30dDHYwWOtUIy6.CATYwKdgRT = (qvCW30dDHYwWOtUIy6.ipKfv4YCBHm4wmIbaZn)qvCW30dDHYwWOtUIy6.wn5AFCGcfc8yjINTqCZ(new IntPtr(num14), qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6.ipKfv4YCBHm4wmIbaZn).TypeHandle));
							int num44 = 0;
							if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
							{
								num44 = 0;
							}
							switch (num44)
							{
							default:
								goto IL_104C;
							}
						}
						catch
						{
							int num45 = 1;
							if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
							{
								num45 = 0;
							}
							switch (num45)
							{
							case 1:
								try
								{
									Delegate @delegate = qvCW30dDHYwWOtUIy6.wn5AFCGcfc8yjINTqCZ(new IntPtr(num14), qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6.ipKfv4YCBHm4wmIbaZn).TypeHandle));
									int num46 = 0;
									if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
									{
										num46 = 0;
									}
									for (;;)
									{
										switch (num46)
										{
										default:
											qvCW30dDHYwWOtUIy6.CATYwKdgRT = (qvCW30dDHYwWOtUIy6.ipKfv4YCBHm4wmIbaZn)qvCW30dDHYwWOtUIy6.IHVxlmBq2YCIMeHEovO(qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6.ipKfv4YCBHm4wmIbaZn).TypeHandle), qvCW30dDHYwWOtUIy6.DoUvKDBrhmNRrob74ll(@delegate));
											num46 = 1;
											if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
											{
												num46 = 1;
											}
											break;
										case 1:
											goto IL_36A4;
										}
									}
									IL_36A4:;
								}
								catch
								{
									int num47 = 0;
									if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
									{
										num47 = 0;
									}
									switch (num47)
									{
									}
								}
								break;
							}
							goto IL_104C;
						}
						goto IL_3704;
					case 346:
						num27 = 0L;
						num2 = 366;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 299;
							continue;
						}
						continue;
					case 347:
						intPtr8 = IntPtr.Zero;
						num2 = 342;
						continue;
					case 348:
						array[31] = (byte)num7;
						num2 = 293;
						continue;
					case 349:
						num7 = 13 + 89;
						num2 = 290;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 133;
							continue;
						}
						continue;
					case 350:
						goto IL_4EF6;
					case 351:
						num5 = 30;
						num2 = 104;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 191;
							continue;
						}
						continue;
					case 352:
						goto IL_2188;
					case 353:
						goto IL_3545;
					case 354:
						zero = IntPtr.Zero;
						num2 = 72;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 265;
							continue;
						}
						continue;
					case 355:
						array2[num8] = array8[0];
						num2 = 50;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 38;
							continue;
						}
						continue;
					case 356:
						array[28] = (byte)num4;
						num2 = 27;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 522;
							continue;
						}
						continue;
					case 357:
						goto IL_3704;
					case 358:
						num7 = 168 - 56;
						num2 = 478;
						continue;
					case 359:
						array7[10] = (byte)num11;
						num2 = 76;
						continue;
					case 360:
						goto IL_6068;
					case 361:
						goto IL_1F80;
					case 362:
						qvCW30dDHYwWOtUIy6.qM8gP3GqsirqxOaQyQS();
						num2 = 432;
						continue;
					case 363:
						qvCW30dDHYwWOtUIy6.BGBgHYJ7W2OtsKmXbtt(new IntPtr((void*)(&num3)), 0);
						num2 = 219;
						continue;
					case 364:
						goto IL_4D6A;
					case 365:
						goto IL_4649;
					case 366:
						if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() != 4)
						{
							goto IL_58B4;
						}
						num2 = 212;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 33;
							continue;
						}
						continue;
					case 367:
						array7[13] = 199 - 66;
						num2 = 622;
						continue;
					case 368:
						array4[3] = 111;
						num2 = 375;
						continue;
					case 369:
						array15[num48 + 1] = (byte)((num49 & 65280U) >> 8);
						num2 = 252;
						continue;
					case 370:
						intPtr3 = qvCW30dDHYwWOtUIy6.RfgZntG0ktbc0Jukiql(qvCW30dDHYwWOtUIy6.EhTlEjGU346V3fEYcTO(qvCW30dDHYwWOtUIy6.dllY2vEloY)[0]);
						num2 = 183;
						continue;
					case 371:
						num8 = 23;
						num2 = 355;
						continue;
					case 372:
					{
						byte[] array16;
						if ((array19 = array16) != null)
						{
							num2 = 482;
							continue;
						}
						goto IL_243F;
					}
					case 373:
						num9 = 208 - 118;
						num2 = 37;
						continue;
					case 374:
						return;
					case 375:
						array4[4] = 114;
						num2 = 310;
						continue;
					case 376:
						num13 = 0;
						num2 = 512;
						continue;
					case 377:
						array7[7] = 119 + 51;
						num2 = 227;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 1;
							continue;
						}
						continue;
					case 378:
						if (qvCW30dDHYwWOtUIy6.P9jwknBTulW14oNAiRJ(qvCW30dDHYwWOtUIy6.gD8QkRBk7P6TfgscGT9(qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6).TypeHandle).Assembly), null))
						{
							num2 = 615;
							continue;
						}
						goto IL_3753;
					case 379:
						goto IL_4B35;
					case 380:
						try
						{
							object obj = qvCW30dDHYwWOtUIy6.RQ3xVkB2ZMJR8joPTUN(qvCW30dDHYwWOtUIy6.SSHl4YBlLIirKkp82SY(qvCW30dDHYwWOtUIy6.xuRKXtB6IXUlflCeTQa(qvCW30dDHYwWOtUIy6.sVYp1IBmS5khsV5sXPU(qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6).TypeHandle).Assembly))).GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), qvCW30dDHYwWOtUIy6.xuRKXtB6IXUlflCeTQa(qvCW30dDHYwWOtUIy6.sVYp1IBmS5khsV5sXPU(qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6).TypeHandle).Assembly)));
							int num50 = 12;
							for (;;)
							{
								MemoryStream memoryStream2;
								switch (num50)
								{
								case 0:
									goto IL_4795;
								case 1:
									qvCW30dDHYwWOtUIy6.ePpuydGiJulvLOL2abK(memoryStream2, qvCW30dDHYwWOtUIy6.TBGib5GaoRbOwonU4x7(qvCW30dDHYwWOtUIy6.Ri9YxOlYeL.ToInt32()), 0, 4);
									num50 = 7;
									continue;
								case 2:
									try
									{
										byte[] array20;
										if ((array19 = array20) == null)
										{
											goto IL_48F3;
										}
										int num51 = 0;
										if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
										{
											num51 = 0;
										}
										byte* ptr;
										for (;;)
										{
											IL_481F:
											switch (num51)
											{
											case 0:
												goto IL_48E0;
											case 1:
												break;
											case 2:
												goto IL_4898;
											case 3:
												goto IL_4898;
											case 4:
												goto IL_4911;
											case 5:
												break;
											case 6:
												goto IL_48F3;
											default:
												goto IL_48E0;
											}
											ptr = &array19[0];
											num51 = 0;
											if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
											{
												num51 = 2;
												continue;
											}
											continue;
											IL_4898:
											uint num52;
											qvCW30dDHYwWOtUIy6.lgOYUS6yUH(new IntPtr((void*)ptr), new IntPtr((void*)ptr), new IntPtr((void*)ptr), 216669565U, new IntPtr((void*)ptr), ref num52);
											num51 = 3;
											if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
											{
												num51 = 4;
												continue;
											}
											continue;
											IL_48E0:
											if (array19.Length == 0)
											{
												goto IL_48F3;
											}
											num51 = 5;
										}
										IL_4911:
										goto IL_4AF0;
										IL_48F3:
										ptr = null;
										num51 = 1;
										if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
										{
											num51 = 3;
											goto IL_481F;
										}
										goto IL_481F;
									}
									finally
									{
										array19 = null;
										int num53 = 0;
										if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
										{
											num53 = 0;
										}
										switch (num53)
										{
										}
									}
									goto IL_4960;
								case 3:
									if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() == 4)
									{
										num50 = 0;
										if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
										{
											num50 = 1;
											continue;
										}
										continue;
									}
									break;
								case 4:
									goto IL_4A22;
								case 5:
									goto IL_4A01;
								case 6:
								{
									byte[] array20 = qvCW30dDHYwWOtUIy6.TrBynwGt33EAsUXKDWt(memoryStream2);
									num50 = 14;
									if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
									{
										num50 = 0;
										continue;
									}
									continue;
								}
								case 7:
									goto IL_4A22;
								case 8:
									goto IL_4AF0;
								case 9:
									goto IL_4960;
								case 10:
									qvCW30dDHYwWOtUIy6.Ri9YxOlYeL = (IntPtr)obj;
									num50 = 16;
									continue;
								case 11:
								{
									qvCW30dDHYwWOtUIy6.ePpuydGiJulvLOL2abK(memoryStream2, new byte[qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B()], 0, qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B());
									int num54 = 3;
									num50 = num54;
									continue;
								}
								case 12:
									if (!(obj is IntPtr))
									{
										goto IL_4A43;
									}
									num50 = 10;
									if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
									{
										num50 = 4;
										continue;
									}
									continue;
								case 13:
									break;
								case 14:
									qvCW30dDHYwWOtUIy6.XAkX9LG8QMrbuwFsbGD(memoryStream2);
									num50 = 15;
									continue;
								case 15:
								{
									uint num52 = 0U;
									num50 = 0;
									if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
									{
										num50 = 2;
										continue;
									}
									continue;
								}
								case 16:
									goto IL_4A43;
								case 17:
									qvCW30dDHYwWOtUIy6.ePpuydGiJulvLOL2abK(memoryStream2, new byte[qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B()], 0, qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B());
									num50 = 9;
									continue;
								default:
									goto IL_4795;
								}
								qvCW30dDHYwWOtUIy6.ePpuydGiJulvLOL2abK(memoryStream2, qvCW30dDHYwWOtUIy6.DJPkEdBf8mOWYs1AlRN(qvCW30dDHYwWOtUIy6.Ri9YxOlYeL.ToInt64()), 0, 8);
								num50 = 4;
								if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
								{
									num50 = 1;
									continue;
								}
								continue;
								IL_4795:
								qvCW30dDHYwWOtUIy6.Ri9YxOlYeL = (IntPtr)qvCW30dDHYwWOtUIy6.RQ3xVkB2ZMJR8joPTUN(obj.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), obj);
								num50 = 1;
								if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
								{
									num50 = 5;
									continue;
								}
								continue;
								IL_4960:
								qvCW30dDHYwWOtUIy6.prqp8lGQPx5LS7fHwD4(memoryStream2, 0L);
								num50 = 6;
								continue;
								IL_4A01:
								memoryStream2 = new MemoryStream();
								num50 = 5;
								if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
								{
									num50 = 11;
									continue;
								}
								continue;
								IL_4A43:
								if (!qvCW30dDHYwWOtUIy6.eyeXweGEIAJ2ASO259X(obj.GetType().ToString(), "System.Reflection.RuntimeModule"))
								{
									goto IL_4A01;
								}
								num50 = 0;
								if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
								{
									num50 = 0;
									continue;
								}
								continue;
								IL_4A22:
								qvCW30dDHYwWOtUIy6.ePpuydGiJulvLOL2abK(memoryStream2, new byte[qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B()], 0, qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B());
								num50 = 17;
							}
							IL_4AF0:
							goto IL_529A;
						}
						catch
						{
							int num55 = 0;
							if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
							{
								num55 = 0;
							}
							switch (num55)
							{
							default:
								goto IL_529A;
							}
						}
						goto IL_4B35;
					case 381:
					{
						IEnumerator enumerator = qvCW30dDHYwWOtUIy6.PRmqfpG2HdmrJijNqA6(qvCW30dDHYwWOtUIy6.IWje7fGlcnmLcNXUAy4(qvCW30dDHYwWOtUIy6.l5vTxwGYisGB1necjhn()));
						num2 = 162;
						continue;
					}
					case 382:
						array[11] = (byte)num4;
						num2 = 457;
						continue;
					case 383:
						goto IL_560C;
					case 384:
					{
						uint num12;
						if (num12 == 4109628145U)
						{
							num2 = 327;
							continue;
						}
						goto IL_303B;
					}
					case 385:
						array[11] = (byte)num7;
						num2 = 486;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 366;
							continue;
						}
						continue;
					case 386:
					{
						string text2;
						IntPtr intPtr4 = qvCW30dDHYwWOtUIy6.YWfP2ZK1H(text2);
						num2 = 331;
						continue;
					}
					case 387:
						array[24] = 200 - 66;
						num2 = 50;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 398;
							continue;
						}
						continue;
					case 388:
						num56 = qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
						num2 = 488;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 132;
							continue;
						}
						continue;
					case 389:
						goto IL_1CE6;
					case 390:
					{
						IntPtr intPtr7;
						array8 = qvCW30dDHYwWOtUIy6.DJPkEdBf8mOWYs1AlRN(intPtr7.ToInt64());
						num2 = 546;
						continue;
					}
					case 391:
						qvCW30dDHYwWOtUIy6.SVwWTwG31ns8ercPprV();
						num2 = 384;
						continue;
					case 392:
						num7 = 40 + 33;
						num2 = 602;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 81;
							continue;
						}
						continue;
					case 393:
						array12[9] = array13[4];
						num2 = 627;
						continue;
					case 394:
						num3 = 0L;
						num2 = 363;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 32;
							continue;
						}
						continue;
					case 395:
						array[18] = 214 - 71;
						num2 = 106;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 203;
							continue;
						}
						continue;
					case 396:
						array[11] = 106 + 80;
						num2 = 20;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 94;
							continue;
						}
						continue;
					case 397:
						array7[4] = 113 + 110;
						num2 = 128;
						continue;
					case 398:
						num7 = 84 + 20;
						num2 = 465;
						continue;
					case 399:
						array[29] = (byte)num7;
						num2 = 237;
						continue;
					case 400:
						num7 = 40 + 58;
						num2 = 533;
						continue;
					case 401:
						array7[2] = (byte)num9;
						num2 = 53;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 136;
							continue;
						}
						continue;
					case 402:
						array4[0] = 109;
						num2 = 83;
						continue;
					case 403:
						goto IL_1DC6;
					case 404:
						goto IL_40E1;
					case 405:
						goto IL_4564;
					case 406:
						qvCW30dDHYwWOtUIy6.fY7DsrDOt(intPtr2, 4, num6, ref num6);
						num2 = 576;
						continue;
					case 407:
					{
						IntPtr intPtr7 = IntPtr.Zero;
						num2 = 271;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 286;
							continue;
						}
						continue;
					}
					case 408:
						array[12] = (byte)num4;
						num2 = 96;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 82;
							continue;
						}
						continue;
					case 409:
						array7[9] = (byte)num9;
						num2 = 598;
						continue;
					case 410:
						array7[13] = (byte)num9;
						num2 = 550;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 66;
							continue;
						}
						continue;
					case 411:
						num7 = 12 + 120;
						num2 = 338;
						continue;
					case 412:
						array[27] = 178 + 38;
						num2 = 16;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 277;
							continue;
						}
						continue;
					case 413:
						goto IL_5E9C;
					case 414:
						array[26] = (byte)num4;
						num2 = 41;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 7;
							continue;
						}
						continue;
					case 415:
						array[5] = (byte)num7;
						num2 = 12;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 20;
							continue;
						}
						continue;
					case 416:
						goto IL_2C72;
					case 417:
						if (array13.Length != 0)
						{
							goto Block_214;
						}
						goto IL_2668;
					case 418:
						goto IL_13CD;
					case 419:
						array7[1] = 69 + 4;
						num2 = 593;
						continue;
					case 420:
						num7 = 44 - 18;
						num2 = 634;
						continue;
					case 421:
						goto IL_290C;
					case 422:
						qvCW30dDHYwWOtUIy6.GXO1SIGwJ6Xso2MQrqv(array13, 0, array13.Length);
						num2 = 256;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 74;
							continue;
						}
						continue;
					case 423:
						array[10] = 104 + 54;
						num2 = 17;
						continue;
					case 424:
					{
						string text2 = qvCW30dDHYwWOtUIy6.tWRLbiGKpo2EdX8Mdpv(qvCW30dDHYwWOtUIy6.WtOnYhGCjVxbcexDd6y(), array4);
						num2 = 386;
						continue;
					}
					case 425:
						goto IL_2188;
					case 426:
						array[29] = (byte)num4;
						num2 = 144;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 339;
							continue;
						}
						continue;
					case 427:
						array[20] = 130 + 110;
						num2 = 358;
						continue;
					case 428:
						array[25] = (byte)num4;
						num2 = 315;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 516;
							continue;
						}
						continue;
					case 429:
						num4 = 176 - 58;
						num2 = 513;
						continue;
					case 430:
						array2[num5] = array5[0];
						num2 = 565;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 536;
							continue;
						}
						continue;
					case 431:
						num7 = 240 - 80;
						num2 = 152;
						continue;
					case 432:
						return;
					case 433:
						num48 = num24 * 4;
						num2 = 19;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 273;
							continue;
						}
						continue;
					case 434:
						qvCW30dDHYwWOtUIy6.prqp8lGQPx5LS7fHwD4(qvCW30dDHYwWOtUIy6.tBC9xdGeqmBi7Dijkaj(fh1hmAYzyWp7H1O7Q9k), 0L);
						num2 = 14;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 4;
							continue;
						}
						continue;
					case 435:
						array7[8] = 177 - 59;
						num2 = 506;
						continue;
					case 436:
						array7[11] = (byte)num11;
						num2 = 16;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 210;
							continue;
						}
						continue;
					case 437:
						array2[num5 + 3] = array5[3];
						num2 = 491;
						continue;
					case 438:
						qvCW30dDHYwWOtUIy6.O4wMPbJZu2A1L4gwxdD(new IntPtr((void*)(&num3)), 0, 0);
						num2 = 3;
						continue;
					case 439:
						goto IL_1106;
					case 440:
						goto IL_5E9C;
					case 441:
						array[14] = (byte)num7;
						num2 = 34;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 587;
							continue;
						}
						continue;
					case 442:
						qvCW30dDHYwWOtUIy6.SrxMqBJKpY8sFdSnL3O(new IntPtr((void*)(&num3)), 0, IntPtr.Zero);
						num2 = 219;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 438;
							continue;
						}
						continue;
					case 443:
						num33++;
						num2 = 636;
						continue;
					case 444:
						array15[num48] = (byte)(num49 & 255U);
						num2 = 369;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 364;
							continue;
						}
						continue;
					case 445:
						goto IL_243F;
					case 446:
						goto IL_4666;
					case 447:
						num7 = 136 + 116;
						num2 = 399;
						continue;
					case 448:
						array[7] = 152 + 8;
						num2 = 43;
						continue;
					case 449:
						array7[2] = (byte)num11;
						num2 = 259;
						continue;
					case 450:
						try
						{
							IEnumerator enumerator = qvCW30dDHYwWOtUIy6.PRmqfpG2HdmrJijNqA6(qvCW30dDHYwWOtUIy6.IWje7fGlcnmLcNXUAy4(process));
							int num57 = 1;
							if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
							{
								num57 = 1;
							}
							switch (num57)
							{
							case 1:
								try
								{
									for (;;)
									{
										IL_3930:
										if (qvCW30dDHYwWOtUIy6.p3pYGVGJGpGSnWZnm6a(enumerator))
										{
											goto IL_3913;
										}
										int num58 = 0;
										if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
										{
											num58 = 0;
										}
										for (;;)
										{
											IL_38F1:
											switch (num58)
											{
											case 1:
												num22 = 0;
												num58 = 2;
												continue;
											case 3:
												goto IL_3930;
											case 4:
												goto IL_3913;
											case 5:
												if (intPtr3.ToInt64() != qvCW30dDHYwWOtUIy6.VOaY0shBjx)
												{
													goto IL_3930;
												}
												num58 = 0;
												if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
												{
													num58 = 1;
													continue;
												}
												continue;
											}
											goto Block_305;
										}
										IL_3913:
										intPtr3 = qvCW30dDHYwWOtUIy6.PfrLytGk5nh2v7cnFZs((ProcessModule)qvCW30dDHYwWOtUIy6.F4LJLTGfCn9GpN8DQQp(enumerator));
										num58 = 5;
										goto IL_38F1;
									}
									Block_305:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num59 = 1;
									if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
									{
										num59 = 0;
									}
									for (;;)
									{
										switch (num59)
										{
										case 1:
											if (disposable == null)
											{
												goto IL_3A31;
											}
											num59 = 0;
											if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
											{
												num59 = 0;
												continue;
											}
											continue;
										case 2:
											goto IL_3A31;
										}
										qvCW30dDHYwWOtUIy6.kSsP84GGVZm1pRcgkcP(disposable);
										num59 = 1;
										if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
										{
											num59 = 2;
										}
									}
									IL_3A31:;
								}
								break;
							}
							goto IL_4666;
						}
						catch
						{
							int num60 = 0;
							if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
							{
								num60 = 0;
							}
							switch (num60)
							{
							default:
								goto IL_4666;
							}
						}
						goto IL_3A8D;
					case 451:
						num7 = 158 - 52;
						num2 = 246;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 566;
							continue;
						}
						continue;
					case 452:
						num14 = (long)qvCW30dDHYwWOtUIy6.A0kQ1rGz3RiEXIem8Pn(new IntPtr(num27));
						num2 = 322;
						continue;
					case 453:
						array2[num5 + 1] = array8[1];
						num2 = 312;
						continue;
					case 454:
						num25++;
						num2 = 209;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 140;
							continue;
						}
						continue;
					case 455:
						num7 = 79 + 65;
						num2 = 30;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 295;
							continue;
						}
						continue;
					case 456:
						if (num30 > 0)
						{
							num2 = 563;
							continue;
						}
						goto IL_1A97;
					case 457:
						num7 = 83 + 1;
						num2 = 385;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 187;
							continue;
						}
						continue;
					case 458:
						array[7] = 97 + 80;
						num2 = 630;
						continue;
					case 459:
						array4[11] = 108;
						num2 = 493;
						continue;
					case 460:
						array[4] = 126 - 42;
						num2 = 101;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 74;
							continue;
						}
						continue;
					case 461:
						num61 = 0U;
						num2 = 181;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 481;
							continue;
						}
						continue;
					case 462:
						array2[num8 + 2] = array5[2];
						num2 = 278;
						continue;
					case 463:
						num11 = 201 - 67;
						num2 = 179;
						continue;
					case 464:
						array7[9] = 71 + 80;
						num2 = 111;
						continue;
					case 465:
						array[24] = (byte)num7;
						num2 = 585;
						continue;
					case 466:
						num6 = 0;
						num2 = 611;
						continue;
					case 467:
						array7[10] = 176 - 58;
						num2 = 140;
						continue;
					case 468:
						if (qvCW30dDHYwWOtUIy6.IhnWNKGotbLGdq1Bfgh(qvCW30dDHYwWOtUIy6.dllY2vEloY) == null)
						{
							num2 = 405;
							continue;
						}
						goto IL_0DEF;
					case 469:
						goto IL_52F0;
					case 470:
						qvCW30dDHYwWOtUIy6.h1GYuAP0Jq = intPtr3.ToInt32();
						num2 = 193;
						continue;
					case 471:
						num4 = 92 + 81;
						num2 = 70;
						continue;
					case 472:
						array[31] = (byte)num7;
						num2 = 357;
						continue;
					case 473:
						goto IL_104C;
					case 474:
						array2[num5 + 4] = array8[4];
						num2 = 34;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 303;
							continue;
						}
						continue;
					case 475:
						goto IL_2B40;
					case 476:
						array[23] = 141 - 47;
						num2 = 42;
						continue;
					case 477:
						goto IL_3CB2;
					case 478:
						array[21] = (byte)num7;
						num2 = 196;
						continue;
					case 479:
						array[8] = 170 - 56;
						num2 = 498;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 384;
							continue;
						}
						continue;
					case 480:
					{
						byte[] array3 = qvCW30dDHYwWOtUIy6.TBGib5GaoRbOwonU4x7(qvCW30dDHYwWOtUIy6.zt1L45GDOvWDYVPBs5Y(num14));
						num2 = 8;
						continue;
					}
					case 481:
						num31 = 0U;
						num2 = 68;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 169;
							continue;
						}
						continue;
					case 482:
						if (array19.Length != 0)
						{
							goto IL_4FBE;
						}
						num2 = 445;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 21;
							continue;
						}
						continue;
					case 483:
						num7 = 123 + 26;
						num2 = 88;
						continue;
					case 484:
						goto IL_5D13;
					case 485:
						num4 = 152 + 70;
						num2 = 326;
						continue;
					case 486:
						array[11] = 2 + 65;
						num2 = 396;
						continue;
					case 487:
						goto IL_0DEF;
					case 488:
						if (num56 != 4)
						{
							goto IL_53C2;
						}
						num2 = 323;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 389;
							continue;
						}
						continue;
					case 489:
						array[30] = 234 - 78;
						num2 = 568;
						continue;
					case 490:
						array7[5] = 92 + 40;
						num2 = 529;
						continue;
					case 491:
						array2[num5 + 4] = array5[4];
						num2 = 116;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 130;
							continue;
						}
						continue;
					case 492:
						array7[1] = 132 - 100;
						num2 = 151;
						continue;
					case 493:
					{
						string text2 = qvCW30dDHYwWOtUIy6.tWRLbiGKpo2EdX8Mdpv(qvCW30dDHYwWOtUIy6.WtOnYhGCjVxbcexDd6y(), array4);
						num2 = 84;
						continue;
					}
					case 494:
						goto IL_1F80;
					case 495:
						goto IL_1D0B;
					case 496:
						num17 = (uint)(((int)array11[(int)(num32 + 3U)] << 24) | ((int)array11[(int)(num32 + 2U)] << 16) | ((int)array11[(int)(num32 + 1U)] << 8) | (int)array11[(int)num32]);
						num2 = 469;
						continue;
					case 497:
						array[30] = 136 - 118;
						num2 = 61;
						continue;
					case 498:
						goto IL_211F;
					case 499:
						if (qvCW30dDHYwWOtUIy6.df2Ho4G6MQ1p3qjNdAU(qvCW30dDHYwWOtUIy6.ShN7HgGmEHKOya6l49A("System.Reflection.ReflectionContext", false), null))
						{
							num2 = 381;
							continue;
						}
						goto IL_56CE;
					case 500:
						qvCW30dDHYwWOtUIy6.prqp8lGQPx5LS7fHwD4(qvCW30dDHYwWOtUIy6.tBC9xdGeqmBi7Dijkaj(fh1hmAYzyWp7H1O7Q9k), 0L);
						num2 = 370;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 131;
							continue;
						}
						continue;
					case 501:
						num61 += num31;
						num2 = 142;
						continue;
					case 502:
					{
						bool flag = false;
						num2 = 163;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 50;
							continue;
						}
						continue;
					}
					case 503:
						goto IL_1D20;
					case 504:
						goto IL_58B4;
					case 505:
						num4 = 60 + 94;
						num2 = 548;
						continue;
					case 506:
						goto IL_23CA;
					case 507:
						qvCW30dDHYwWOtUIy6.m4oYg3B07I = intPtr3.ToInt64();
						num2 = 354;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 275;
							continue;
						}
						continue;
					case 508:
						array4[8] = 46;
						num2 = 205;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 85;
							continue;
						}
						continue;
					case 509:
						frX3D7YZMOMqCdWreZ.yMZYAWkgc8 = new byte[] { 42 };
						num2 = 112;
						continue;
					case 510:
						num7 = 178 - 59;
						num2 = 110;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 553;
							continue;
						}
						continue;
					case 511:
						array[3] = 61 + 84;
						num2 = 460;
						continue;
					case 512:
						if (num24 == num25 - 1)
						{
							goto Block_199;
						}
						goto IL_3050;
					case 513:
						array[21] = (byte)num4;
						num2 = 91;
						continue;
					case 514:
					{
						byte[] array3;
						array2[num5 + 1] = array3[1];
						num2 = 65;
						continue;
					}
					case 515:
						array[0] = 129 - 43;
						num2 = 188;
						continue;
					case 516:
						array[25] = 143 - 93;
						num2 = 225;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 67;
							continue;
						}
						continue;
					case 517:
						goto IL_52F0;
					case 518:
					{
						bool flag;
						frX3D7YZMOMqCdWreZ2.FTXYcopS1m = flag;
						num2 = 114;
						continue;
					}
					case 519:
						array7[6] = 169 - 62;
						num2 = 377;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 66;
							continue;
						}
						continue;
					case 520:
						array[13] = 101 + 74;
						num2 = 360;
						continue;
					case 521:
						return;
					case 522:
						num7 = 211 - 70;
						num2 = 4;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 11;
							continue;
						}
						continue;
					case 523:
					{
						int num43;
						qvCW30dDHYwWOtUIy6.fY7DsrDOt(new IntPtr(num27), qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B(), 64, ref num43);
						num2 = 230;
						continue;
					}
					case 524:
						array[30] = (byte)num7;
						num2 = 497;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 62;
							continue;
						}
						continue;
					case 525:
						array7[6] = (byte)num9;
						num2 = 139;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 53;
							continue;
						}
						continue;
					case 526:
						goto IL_529A;
					case 527:
						goto IL_6031;
					case 528:
						array7[8] = 211 - 70;
						num2 = 154;
						continue;
					case 529:
						array7[5] = 163 - 54;
						num2 = 238;
						continue;
					case 530:
						goto IL_290C;
					case 531:
					{
						byte[] array17 = qvCW30dDHYwWOtUIy6.AoWimXG9OLHGUJZiN4k(fh1hmAYzyWp7H1O7Q9k, num62);
						num2 = 285;
						continue;
					}
					case 532:
						array[12] = (byte)num7;
						num2 = 570;
						continue;
					case 533:
						array[17] = (byte)num7;
						num2 = 311;
						continue;
					case 534:
						num4 = 105 + 94;
						num2 = 63;
						continue;
					case 535:
						num4 = 190 - 73;
						num2 = 606;
						continue;
					case 536:
						num4 = 162 - 54;
						num2 = 213;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 179;
							continue;
						}
						continue;
					case 537:
						array2[num5 + 7] = array5[7];
						num2 = 57;
						continue;
					case 538:
					{
						string text = qvCW30dDHYwWOtUIy6.tWRLbiGKpo2EdX8Mdpv(qvCW30dDHYwWOtUIy6.WtOnYhGCjVxbcexDd6y(), array10);
						num2 = 155;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 160;
							continue;
						}
						continue;
					}
					case 539:
						qvCW30dDHYwWOtUIy6.q9lBpfGpdiMMpDRP2Tq(qvCW30dDHYwWOtUIy6.oBEYiiMK8Z, 0L, frX3D7YZMOMqCdWreZ);
						num2 = 502;
						continue;
					case 540:
						array[1] = 55 + 79;
						num2 = 418;
						continue;
					case 541:
						array[16] = (byte)num7;
						num2 = 255;
						continue;
					case 542:
						array4[9] = 108;
						num2 = 424;
						continue;
					case 543:
						goto IL_16C9;
					case 544:
						array[0] = (byte)num7;
						num2 = 81;
						continue;
					case 545:
						return;
					case 546:
					{
						byte[] array3 = qvCW30dDHYwWOtUIy6.DJPkEdBf8mOWYs1AlRN(num14);
						num2 = 502;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 619;
							continue;
						}
						continue;
					}
					case 547:
						array[6] = 244 - 81;
						num2 = 609;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 181;
							continue;
						}
						continue;
					case 548:
						array[28] = (byte)num4;
						num2 = 608;
						continue;
					case 549:
						num63++;
						num2 = 425;
						continue;
					case 550:
						num11 = 19 + 109;
						num2 = 34;
						continue;
					case 551:
						array2[num8 + 1] = array5[1];
						num2 = 462;
						continue;
					case 552:
						array[13] = 139 - 46;
						num2 = 520;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 481;
							continue;
						}
						continue;
					case 553:
						array[5] = (byte)num7;
						num2 = 168;
						continue;
					case 554:
					{
						byte[] array3;
						array2[num5 + 3] = array3[3];
						num2 = 133;
						continue;
					}
					case 555:
						goto IL_12AC;
					case 556:
						if (num30 > 0)
						{
							num2 = 501;
							continue;
						}
						goto IL_3050;
					case 557:
						goto IL_53C2;
					case 558:
						array[2] = (byte)num4;
						num2 = 200;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 19;
							continue;
						}
						continue;
					case 559:
						num7 = 84 + 9;
						num2 = 272;
						continue;
					case 560:
						array[16] = (byte)num4;
						num2 = 420;
						continue;
					case 561:
						goto IL_37A6;
					case 562:
						array[17] = 89 + 112;
						num2 = 119;
						continue;
					case 563:
						num64 = num61 ^ num17;
						num2 = 137;
						continue;
					case 564:
						goto IL_1D5E;
					case 565:
						array2[num5 + 1] = array5[1];
						num2 = 629;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 366;
							continue;
						}
						continue;
					case 566:
						array[0] = (byte)num7;
						num2 = 515;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 11;
							continue;
						}
						continue;
					case 567:
						goto IL_1A97;
					case 568:
						num7 = 69 + 90;
						num2 = 524;
						continue;
					case 569:
						array7[7] = (byte)num11;
						num2 = 18;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 18;
							continue;
						}
						continue;
					case 570:
						array[12] = 43 + 29;
						num2 = 315;
						continue;
					case 571:
						goto IL_2F4F;
					case 572:
					{
						byte[] array3;
						array2[num5] = array3[0];
						num2 = 514;
						continue;
					}
					case 573:
						goto IL_5080;
					case 574:
					{
						byte[] array16;
						num65 = array16.Length / 8;
						num2 = 372;
						continue;
					}
					case 575:
						array[17] = (byte)num4;
						num2 = 562;
						continue;
					case 576:
						num66++;
						num2 = 210;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 416;
							continue;
						}
						continue;
					case 577:
						num7 = 199 - 66;
						num2 = 65;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 231;
							continue;
						}
						continue;
					case 578:
						qvCW30dDHYwWOtUIy6.fY7DsrDOt(intPtr, 4, 8, ref num6);
						num2 = 41;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 583;
							continue;
						}
						continue;
					case 579:
						qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
						num2 = 313;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 172;
							continue;
						}
						continue;
					case 580:
						num11 = 87 + 62;
						num2 = 167;
						continue;
					case 581:
						num11 = 139 - 46;
						num2 = 240;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 130;
							continue;
						}
						continue;
					case 582:
						num8 = 16;
						num2 = 287;
						continue;
					case 583:
						goto IL_1680;
					case 584:
						array[17] = (byte)num7;
						num2 = 282;
						continue;
					case 585:
						array[24] = 70 + 67;
						num2 = 202;
						continue;
					case 586:
					{
						int num67 = qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
						bool flag = false;
						if (num67 >= 1879048192)
						{
							num2 = 296;
							continue;
						}
						goto IL_0D64;
					}
					case 587:
						num4 = 171 - 57;
						num2 = 192;
						continue;
					case 588:
						num9 = 105 + 83;
						num2 = 118;
						continue;
					case 589:
					{
						CryptoStream cryptoStream;
						qvCW30dDHYwWOtUIy6.XAkX9LG8QMrbuwFsbGD(cryptoStream);
						num2 = 190;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 117;
							continue;
						}
						continue;
					}
					case 590:
					{
						int num43 = 0;
						num2 = 378;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 185;
							continue;
						}
						continue;
					}
					case 591:
						array[5] = (byte)num7;
						num2 = 510;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 127;
							continue;
						}
						continue;
					case 592:
						num56 = qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
						num2 = 557;
						continue;
					case 593:
						num11 = 131 - 43;
						num2 = 156;
						continue;
					case 594:
						array[22] = 236 - 78;
						num2 = 113;
						continue;
					case 595:
						num68++;
						num2 = 495;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 51;
							continue;
						}
						continue;
					case 596:
						goto IL_1695;
					case 597:
						goto IL_31E2;
					case 598:
						array7[9] = 51 + 97;
						num2 = 464;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 353;
							continue;
						}
						continue;
					case 599:
						goto IL_5F97;
					case 600:
						array4[2] = 99;
						num2 = 368;
						continue;
					case 601:
						if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() == 4)
						{
							num2 = 157;
							continue;
						}
						goto IL_127C;
					case 602:
						array[7] = (byte)num7;
						num2 = 448;
						continue;
					case 603:
						array2[num8] = array5[0];
						num2 = 551;
						continue;
					case 604:
						array4[6] = 105;
						num2 = 38;
						continue;
					case 605:
						num11 = 209 - 69;
						num2 = 561;
						if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 620;
							continue;
						}
						continue;
					case 606:
						array[5] = (byte)num4;
						num2 = 100;
						continue;
					case 607:
						qvCW30dDHYwWOtUIy6.Qg8YLYXP71 = false;
						num2 = 523;
						continue;
					case 608:
						num4 = 240 - 80;
						num2 = 356;
						continue;
					case 609:
						array[6] = 96 - 22;
						num2 = 458;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 177;
							continue;
						}
						continue;
					case 610:
						array12 = array7;
						num2 = 301;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 335;
							continue;
						}
						continue;
					case 611:
						num22 = 0;
						num2 = 468;
						continue;
					case 612:
						goto IL_449B;
					case 613:
						num4 = 163 - 54;
						num2 = 97;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 22;
							continue;
						}
						continue;
					case 614:
						array[1] = 43 + 44;
						num2 = 46;
						continue;
					case 615:
						if (qvCW30dDHYwWOtUIy6.MWwfebB4dPL1EnsO0B5(qvCW30dDHYwWOtUIy6.gD8QkRBk7P6TfgscGT9(qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6).TypeHandle).Assembly)).Length == 2)
						{
							num2 = 229;
							continue;
						}
						goto IL_3753;
					case 616:
						num18++;
						num2 = 223;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 95;
							continue;
						}
						continue;
					case 617:
						array4[0] = 99;
						num2 = 187;
						continue;
					case 618:
						array[11] = (byte)num4;
						num2 = 639;
						if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
						{
							num2 = 540;
							continue;
						}
						continue;
					case 619:
						goto IL_202D;
					case 620:
						goto IL_4217;
					case 621:
						goto IL_609A;
					case 622:
						array7[13] = 204 - 68;
						num2 = 588;
						continue;
					case 623:
						num19 = 0;
						num2 = 530;
						continue;
					case 624:
						goto IL_2519;
					case 625:
						num42 = qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
						num2 = 592;
						continue;
					case 626:
						array5 = null;
						num2 = 67;
						continue;
					case 627:
						goto IL_2833;
					case 628:
					{
						uint num69 = num61;
						uint num70 = num61;
						uint num71 = 785396777U;
						uint num72 = 851326108U;
						uint num73 = num70;
						uint num74 = 1950741206U;
						uint num75 = 443419207U;
						uint num76 = ((num72 >> 6) | (num72 << 26)) ^ num74;
						uint num77 = num76 & 252645135U;
						num76 &= 4042322160U;
						num72 = (num76 >> 4) | (num77 << 4);
						num73 -= num74;
						num73 = 33939422U * (num73 & 63U) - (num73 >> 6);
						num71 = 62797463U * (num71 & 63U) - (num71 >> 6);
						num72 = 34753U * num72 + num74;
						num76 = num74 & 252645135U;
						num77 = num74 & 4042322160U;
						num76 = ((num76 >> 4) | (num77 << 4)) + num72;
						num74 = (num74 >> 14) | (num74 << 18);
						num75 ^= num72;
						num73 ^= num73 << 3;
						num73 += num71;
						num73 ^= num73 << 25;
						num73 += num74;
						num73 ^= num73 >> 23;
						num73 += num75;
						num73 = (((num73 << 3) - num71) ^ num71) + num73;
						num61 = num69 + (uint)num73;
						num2 = 186;
						continue;
					}
					case 629:
						array2[num5 + 2] = array5[2];
						num2 = 437;
						continue;
					case 630:
						array[7] = 188 - 62;
						num2 = 392;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
						{
							num2 = 131;
							continue;
						}
						continue;
					case 631:
						num7 = 199 - 120;
						num2 = 206;
						continue;
					case 632:
						goto IL_0C23;
					case 633:
						num7 = 159 - 53;
						num2 = 36;
						continue;
					case 634:
						array[16] = (byte)num7;
						num2 = 400;
						continue;
					case 635:
						array4[5] = 116;
						num2 = 264;
						continue;
					case 636:
						goto IL_37A6;
					case 637:
						array[1] = (byte)num4;
						num2 = 614;
						continue;
					case 638:
						goto IL_3D3B;
					case 639:
						num7 = 140 - 46;
						num2 = 37;
						if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
						{
							num2 = 245;
							continue;
						}
						continue;
					case 640:
						num4 = 100 + 117;
						num2 = 637;
						continue;
					default:
						goto IL_3B16;
					}
					IL_0AA5:
					intPtr = new IntPtr(qvCW30dDHYwWOtUIy6.m4oYg3B07I + (long)qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k) - (long)num22);
					num2 = 9;
					continue;
					IL_37A6:
					if (num33 >= num42)
					{
						goto Block_146;
					}
					goto IL_0AA5;
					IL_0C23:
					array5 = qvCW30dDHYwWOtUIy6.DJPkEdBf8mOWYs1AlRN(qvCW30dDHYwWOtUIy6.Ri9YxOlYeL.ToInt64());
					num2 = 390;
					continue;
					IL_0D64:
					num62 = qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
					num2 = 306;
					if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 531;
						continue;
					}
					continue;
					IL_0DEF:
					if (qvCW30dDHYwWOtUIy6.S3s8ccGLFG9DHRaQp6m(qvCW30dDHYwWOtUIy6.IhnWNKGotbLGdq1Bfgh(qvCW30dDHYwWOtUIy6.dllY2vEloY)) != 0)
					{
						goto IL_223A;
					}
					num2 = 164;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
					{
						num2 = 78;
						continue;
					}
					continue;
					IL_104C:
					IntPtr zero2 = IntPtr.Zero;
					num2 = 590;
					continue;
					IL_127C:
					array4 = new byte[12];
					num2 = 83;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
					{
						num2 = 402;
						continue;
					}
					continue;
					IL_129F:
					num5 = 2;
					num2 = 430;
					continue;
					IL_202D:
					if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() == 4)
					{
						num2 = 135;
						continue;
					}
					goto IL_129F;
					IL_12AC:
					if (qvCW30dDHYwWOtUIy6.sca8nUGPxhQwO6fGr64(qvCW30dDHYwWOtUIy6.tBC9xdGeqmBi7Dijkaj(fh1hmAYzyWp7H1O7Q9k)) >= qvCW30dDHYwWOtUIy6.fEWrHoGXap74qUqtuNp(qvCW30dDHYwWOtUIy6.tBC9xdGeqmBi7Dijkaj(fh1hmAYzyWp7H1O7Q9k)) - 1L)
					{
						goto IL_6031;
					}
					num2 = 242;
					if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 148;
						continue;
					}
					continue;
					IL_1414:
					array15[num48 + num18] = (byte)((num64 & num26) >> num13);
					num2 = 151;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
					{
						num2 = 616;
						continue;
					}
					continue;
					IL_2656:
					if (num18 > 0)
					{
						num2 = 404;
						continue;
					}
					goto IL_1414;
					IL_4EF6:
					if (num18 < num30)
					{
						goto IL_2656;
					}
					num2 = 188;
					if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 194;
						continue;
					}
					continue;
					IL_1461:
					byte* ptr2;
					*(long*)(ptr2 + num63 * 8) ^= 1460438480L;
					num2 = 549;
					continue;
					IL_2188:
					if (num63 >= num65)
					{
						num2 = 302;
						continue;
					}
					goto IL_1461;
					IL_1680:
					if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() == 4)
					{
						num2 = 284;
						continue;
					}
					IL_16C9:
					qvCW30dDHYwWOtUIy6.kwP7v5gmp(intPtr8, intPtr, qvCW30dDHYwWOtUIy6.TBGib5GaoRbOwonU4x7(qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k)), 4U, out zero);
					num2 = 361;
					continue;
					IL_1A97:
					num49 = num61 ^ num17;
					num2 = 444;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
					{
						num2 = 217;
						continue;
					}
					continue;
					IL_1B25:
					byte[] array21 = new byte[30];
					qvCW30dDHYwWOtUIy6.X1fHUdBHSKFrhcdmW8l(array21, fieldof(<PrivateImplementationDetails>{CE0036D9-13C9-42F7-99A4-10AB39C8B015}.D5B7247C497788CF0031CEB06E3DF77A45FEF59F1E49633DC7159816D64759B5).FieldHandle);
					array14 = array21;
					num2 = 503;
					continue;
					IL_1D0B:
					if (num68 >= array12.Length)
					{
						num2 = 60;
						continue;
					}
					goto IL_5F97;
					IL_1D20:
					intPtr9 = qvCW30dDHYwWOtUIy6.DLW278BspiNP2tuXRsE(IntPtr.Zero, (uint)array14.Length, 4096U, 64U);
					num2 = 159;
					continue;
					IL_1D5E:
					if (num24 >= num25)
					{
						num2 = 246;
						continue;
					}
					goto IL_228A;
					IL_1F80:
					qvCW30dDHYwWOtUIy6.fY7DsrDOt(intPtr, 4, num6, ref num6);
					num2 = 443;
					continue;
					IL_223A:
					qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k);
					num2 = 271;
					continue;
					IL_228A:
					num34 = num24 % num10;
					num2 = 433;
					continue;
					IL_243F:
					ptr2 = null;
					num2 = 68;
					continue;
					IL_2519:
					if (qvCW30dDHYwWOtUIy6.S3s8ccGLFG9DHRaQp6m(qvCW30dDHYwWOtUIy6.IhnWNKGotbLGdq1Bfgh(qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6).TypeHandle).Assembly)) <= 0)
					{
						goto IL_3753;
					}
					num2 = 2;
					if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 10;
						continue;
					}
					continue;
					IL_2668:
					num68 = 0;
					num2 = 294;
					continue;
					IL_290C:
					if (num19 >= num30)
					{
						num2 = 517;
						continue;
					}
					goto IL_54CA;
					IL_2A65:
					qvCW30dDHYwWOtUIy6.IPryaXG15kkE9Vinrjb(intPtr2, qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k));
					num2 = 406;
					continue;
					IL_2C72:
					if (num66 < num42)
					{
						goto IL_314C;
					}
					num2 = 457;
					if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 597;
						continue;
					}
					continue;
					IL_2C95:
					num2 = 450;
					continue;
					IL_2F4F:
					num14 = qvCW30dDHYwWOtUIy6.fnjuFLB3kjROTTdSjE2(new IntPtr(num27));
					num2 = 638;
					continue;
					IL_303B:
					if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() == 4)
					{
						num2 = 499;
						continue;
					}
					goto IL_56CE;
					IL_3050:
					num32 = (uint)num48;
					num2 = 621;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
					{
						num2 = 53;
						continue;
					}
					continue;
					IL_314C:
					intPtr2 = new IntPtr(num23 + (long)qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k) - (long)num22);
					num2 = 132;
					if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 67;
						continue;
					}
					continue;
					IL_3545:
					array7[14] = (byte)num9;
					num2 = 145;
					continue;
					IL_3704:
					array[31] = 54 - 28;
					num2 = 54;
					if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 20;
						continue;
					}
					continue;
					IL_3753:
					num2 = 380;
					continue;
					IL_3A8D:
					array[31] = 188 - 62;
					num2 = 199;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
					{
						num2 = 61;
						continue;
					}
					continue;
					IL_3B16:
					array[5] = (byte)num7;
					num2 = 535;
					continue;
					IL_3D3B:
					process = qvCW30dDHYwWOtUIy6.l5vTxwGYisGB1necjhn();
					num2 = 192;
					if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 280;
						continue;
					}
					continue;
					IL_449B:
					qvCW30dDHYwWOtUIy6.da7WpYGVKvkVnrSSnB6(intPtr8);
					num2 = 160;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
					{
						num2 = 362;
						continue;
					}
					continue;
					IL_5E9C:
					if (qvCW30dDHYwWOtUIy6.sca8nUGPxhQwO6fGr64(qvCW30dDHYwWOtUIy6.tBC9xdGeqmBi7Dijkaj(fh1hmAYzyWp7H1O7Q9k)) >= qvCW30dDHYwWOtUIy6.fEWrHoGXap74qUqtuNp(qvCW30dDHYwWOtUIy6.tBC9xdGeqmBi7Dijkaj(fh1hmAYzyWp7H1O7Q9k)) - 1L)
					{
						goto IL_449B;
					}
					num2 = 74;
					if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 4;
						continue;
					}
					continue;
					IL_4564:
					num22 = 7680;
					num2 = 82;
					continue;
					IL_45F0:
					array10 = new byte[6];
					num2 = 596;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
					{
						num2 = 217;
						continue;
					}
					continue;
					IL_4649:
					num16 = 0;
					num2 = 169;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
					{
						num2 = 220;
						continue;
					}
					continue;
					IL_4666:
					qvCW30dDHYwWOtUIy6.CATYwKdgRT = null;
					num2 = 140;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
					{
						num2 = 345;
						continue;
					}
					continue;
					IL_4B35:
					array12[15] = array13[7];
					num2 = 422;
					continue;
					IL_4D6A:
					num17 |= (uint)array11[array11.Length - (1 + num19)];
					num2 = 141;
					continue;
					IL_54CA:
					if (num19 > 0)
					{
						num2 = 122;
						continue;
					}
					goto IL_4D6A;
					IL_4FBE:
					ptr2 = &array19[0];
					num2 = 573;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() != null)
					{
						num2 = 215;
						continue;
					}
					continue;
					IL_5080:
					num63 = 0;
					num2 = 352;
					continue;
					IL_529A:
					qvCW30dDHYwWOtUIy6.M0YiB0BhHTIgyZHvFJ9(qvCW30dDHYwWOtUIy6.CATYwKdgRT);
					num2 = 475;
					continue;
					IL_52F0:
					num61 = num61;
					num2 = 628;
					continue;
					IL_53C2:
					if (num56 == 1)
					{
						num2 = 347;
						continue;
					}
					num66 = 0;
					num2 = 2;
					if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 1;
						continue;
					}
					continue;
					IL_560C:
					qvCW30dDHYwWOtUIy6.qM8gP3GqsirqxOaQyQS();
					num2 = 521;
					continue;
					IL_56CE:
					fh1hmAYzyWp7H1O7Q9k = new qvCW30dDHYwWOtUIy6.fh1hmAYzyWp7H1O7Q9k(qvCW30dDHYwWOtUIy6.AT1nAFGBPbhsMSnrSm1(qvCW30dDHYwWOtUIy6.dllY2vEloY, "Z3VdSH4T9XgGNBa0UJ.P2suUYmkZ21xoZ6WsF"));
					num2 = 63;
					if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 434;
						continue;
					}
					continue;
					IL_58B4:
					num27 = qvCW30dDHYwWOtUIy6.fnjuFLB3kjROTTdSjE2(intPtr5);
					num2 = 25;
					if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 8;
						continue;
					}
					continue;
					IL_5909:
					qvCW30dDHYwWOtUIy6.gUk62wJzVCx5TxpXjRZ(array2, 0, intPtr9, array2.Length);
					num2 = 607;
					continue;
					IL_5D13:
					qvCW30dDHYwWOtUIy6.qM8gP3GqsirqxOaQyQS();
					num2 = 11;
					if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 374;
						continue;
					}
					continue;
					IL_5D42:
					num24++;
					num2 = 29;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
					{
						num2 = 564;
						continue;
					}
					continue;
					IL_5E60:
					qvCW30dDHYwWOtUIy6.BGBgHYJ7W2OtsKmXbtt(intPtr5, 0);
					num2 = 117;
					continue;
					IL_5F97:
					array9[num68] ^= array12[num68];
					num2 = 595;
					if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 372;
						continue;
					}
					continue;
					IL_6031:
					intPtr3 = qvCW30dDHYwWOtUIy6.RfgZntG0ktbc0Jukiql(qvCW30dDHYwWOtUIy6.EhTlEjGU346V3fEYcTO(qvCW30dDHYwWOtUIy6.UQqQwgG7TbSPs3p1aLg(typeof(qvCW30dDHYwWOtUIy6).TypeHandle).Assembly)[0]);
					num2 = 83;
					if (qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 143;
						continue;
					}
					continue;
					IL_6101:
					if (num16 < num28)
					{
						goto IL_42D8;
					}
					num2 = 128;
					if (qvCW30dDHYwWOtUIy6.XpLQdhJptbrg1uPYIA3() == null)
					{
						num2 = 234;
						continue;
					}
					continue;
					IL_61A9:
					num32 = 0U;
					num2 = 218;
					if (!qvCW30dDHYwWOtUIy6.LGaMxMJV2ZhfakkcDU8())
					{
						num2 = 143;
					}
				}
				IL_0AC8:
				array[15] = (byte)num4;
				num = 195;
				continue;
				IL_0C94:
				qvCW30dDHYwWOtUIy6.q9lBpfGpdiMMpDRP2Tq(qvCW30dDHYwWOtUIy6.oBEYiiMK8Z, num23 + (long)num29, frX3D7YZMOMqCdWreZ2);
				num = 555;
				continue;
				IL_0F21:
				array[9] = (byte)num7;
				num = 121;
				continue;
				IL_0FA9:
				array[28] = (byte)num4;
				num = 455;
				continue;
				IL_1106:
				array15[num48 + 3] = (byte)((num49 & 4278190080U) >> 24);
				num = 19;
				continue;
				IL_13CD:
				array[2] = 38 + 46;
				num = 633;
				continue;
				IL_1695:
				array10[0] = 103;
				num = 92;
				continue;
				IL_1725:
				array = new byte[32];
				num = 307;
				continue;
				IL_177F:
				array[22] = 160 - 53;
				num = 403;
				continue;
				IL_1A66:
				if (qvCW30dDHYwWOtUIy6.oT63duG47BSyvmlvi5B() == 4)
				{
					num = 47;
					continue;
				}
				goto IL_287A;
				IL_1CE6:
				object obj2 = qvCW30dDHYwWOtUIy6.P38gxLGRNb8LFOjH26T();
				qvCW30dDHYwWOtUIy6.nKD2AqGxDs9d6RfjavV(obj2, CipherMode.CBC);
				cryptoTransform = qvCW30dDHYwWOtUIy6.jp5ybdGyNwa7AqcAyhF(obj2, array9, array12);
				num = 244;
				continue;
				IL_1DC6:
				array[22] = 166 + 88;
				num = 476;
				continue;
				IL_1E11:
				qvCW30dDHYwWOtUIy6.yggh0mBv0qFkcoI5wUF(new IntPtr(num27), intPtr9);
				num = 323;
				continue;
				IL_1E4A:
				array[27] = (byte)num4;
				num = 411;
				continue;
				IL_1F2E:
				array7[8] = (byte)num11;
				num = 435;
				continue;
				IL_2008:
				frX3D7YZMOMqCdWreZ.FTXYcopS1m = false;
				num = 539;
				continue;
				IL_211F:
				array[8] = 189 - 63;
				num = 7;
				continue;
				IL_219B:
				array7[13] = (byte)num11;
				num = 367;
				continue;
				IL_22C1:
				array2[num5 + 2] = array8[2];
				num = 321;
				continue;
				IL_2322:
				array[18] = 41 - 18;
				num = 333;
				continue;
				IL_23CA:
				array7[8] = 148 - 40;
				num = 337;
				continue;
				IL_23ED:
				num7 = 159 + 91;
				num = 226;
				continue;
				IL_27C2:
				qvCW30dDHYwWOtUIy6.e1JY9epcUF = true;
				num = 44;
				continue;
				IL_2833:
				array12[11] = array13[5];
				num = 172;
				continue;
				IL_287A:
				intPtr3 = qvCW30dDHYwWOtUIy6.RfgZntG0ktbc0Jukiql(qvCW30dDHYwWOtUIy6.EhTlEjGU346V3fEYcTO(qvCW30dDHYwWOtUIy6.dllY2vEloY)[0]);
				num = 507;
				continue;
				IL_2B24:
				array[30] = (byte)num4;
				num = 489;
				continue;
				IL_2B40:
				qvCW30dDHYwWOtUIy6.CNkN4mBEKZZnBoLFGDy(qvCW30dDHYwWOtUIy6.CdUGgcBO4C0pIEsWwOC(qvCW30dDHYwWOtUIy6.DoUvKDBrhmNRrob74ll(qvCW30dDHYwWOtUIy6.CATYwKdgRT)));
				num = 129;
				continue;
				Block_112:
				num = 417;
				continue;
				IL_2D88:
				array[0] = 172 + 58;
				num = 640;
				continue;
				IL_2F67:
				num8 = 9;
				num = 603;
				continue;
				IL_30BA:
				qvCW30dDHYwWOtUIy6.HyIpmMJCdL66NXta1PE(new IntPtr((void*)(&num3)), 0);
				num = 442;
				continue;
				IL_31E2:
				qvCW30dDHYwWOtUIy6.oBEYiiMK8Z = new Hashtable(qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k) + 1);
				num = 51;
				continue;
				IL_3231:
				num9 = 24 + 55;
				num = 115;
				continue;
				Block_146:
				num = 413;
				continue;
				IL_3840:
				array12[3] = array13[1];
				num = 182;
				continue;
				IL_3B02:
				array4[8] = 108;
				num = 542;
				continue;
				IL_3CB2:
				array7[4] = 14 + 110;
				num = 397;
				continue;
				IL_40E1:
				num26 <<= 8;
				num = 48;
				continue;
				IL_4217:
				array7[3] = (byte)num11;
				num = 216;
				continue;
				IL_429B:
				array10[2] = 116;
				num = 39;
				continue;
				IL_42D8:
				qvCW30dDHYwWOtUIy6.IPryaXG15kkE9Vinrjb(new IntPtr(intPtr6.ToInt64() + (long)(num16 * 4)), qvCW30dDHYwWOtUIy6.KD94pSG5Z6gAEsXsLGh(fh1hmAYzyWp7H1O7Q9k));
				num = 87;
				continue;
				IL_4304:
				array15[num48 + 2] = (byte)((num49 & 16711680U) >> 16);
				num = 439;
				continue;
				IL_4454:
				num30 = array11.Length % 4;
				num = 301;
				continue;
				IL_44BD:
				array2[num5 + 5] = array5[5];
				num = 251;
				continue;
				IL_45CD:
				array[21] = 182 - 60;
				num = 208;
				continue;
				IL_4627:
				qvCW30dDHYwWOtUIy6.CNkN4mBEKZZnBoLFGDy(qvCW30dDHYwWOtUIy6.CdUGgcBO4C0pIEsWwOC(qvCW30dDHYwWOtUIy6.DoUvKDBrhmNRrob74ll(qvCW30dDHYwWOtUIy6.lgOYUS6yUH)));
				num = 155;
				continue;
				Block_199:
				num = 556;
				continue;
				IL_4E07:
				array9 = array;
				num = 120;
				continue;
				IL_4E64:
				num11 = 195 - 65;
				num = 436;
				continue;
				IL_4E81:
				qvCW30dDHYwWOtUIy6.SfoYoljwZB = qvCW30dDHYwWOtUIy6.zt1L45GDOvWDYVPBs5Y(qvCW30dDHYwWOtUIy6.VOaY0shBjx);
				num = 224;
				continue;
				Block_214:
				num = 64;
				continue;
				IL_569F:
				num7 = 177 - 59;
				num = 591;
				continue;
				IL_581C:
				array7[6] = (byte)num11;
				num = 519;
				continue;
				IL_5D75:
				array[13] = 200 - 66;
				num = 552;
				continue;
				IL_6068:
				num4 = 108 + 30;
				num = 104;
				continue;
				IL_609A:
				num61 += num31;
				num = 496;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000A0AC File Offset: 0x000082AC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object ROGadlY1H(object \u0020)
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

		// Token: 0x0600004F RID: 79
		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr YWfP2ZK1H(string \u0020);

		// Token: 0x06000050 RID: 80
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		public static extern IntPtr OZt1aWanO(IntPtr \u0020, string \u0020);

		// Token: 0x06000051 RID: 81 RVA: 0x0000A1DC File Offset: 0x000083DC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr I88Vbml7q(IntPtr \u0020, object \u0020, uint \u0020)
		{
			if (qvCW30dDHYwWOtUIy6.VFnYWBsIGh == null)
			{
				qvCW30dDHYwWOtUIy6.VFnYWBsIGh = (qvCW30dDHYwWOtUIy6.WLv7jOMrxGK9hdPsiE5)Marshal.GetDelegateForFunctionPointer(qvCW30dDHYwWOtUIy6.OZt1aWanO(qvCW30dDHYwWOtUIy6.xTuFFuFOZ(), "Find ".Trim() + "ResourceA"), typeof(qvCW30dDHYwWOtUIy6.WLv7jOMrxGK9hdPsiE5));
			}
			return qvCW30dDHYwWOtUIy6.VFnYWBsIGh(\u0020, \u0020, \u0020);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000A238 File Offset: 0x00008438
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr RT3pIFfYd(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			if (qvCW30dDHYwWOtUIy6.dChYtULENX == null)
			{
				qvCW30dDHYwWOtUIy6.dChYtULENX = (qvCW30dDHYwWOtUIy6.OuS3lZMqodAfQgQVfHQ)Marshal.GetDelegateForFunctionPointer(qvCW30dDHYwWOtUIy6.OZt1aWanO(qvCW30dDHYwWOtUIy6.xTuFFuFOZ(), "Virtual ".Trim() + "Alloc"), typeof(qvCW30dDHYwWOtUIy6.OuS3lZMqodAfQgQVfHQ));
			}
			return qvCW30dDHYwWOtUIy6.dChYtULENX(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000A294 File Offset: 0x00008494
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int kwP7v5gmp(IntPtr \u0020, IntPtr \u0020, [In] [Out] byte[] \u0020, uint \u0020, out IntPtr \u0020)
		{
			if (qvCW30dDHYwWOtUIy6.P5dY8K1VM8 == null)
			{
				qvCW30dDHYwWOtUIy6.P5dY8K1VM8 = (qvCW30dDHYwWOtUIy6.tKTvDRM4spXEKTlEQmd)Marshal.GetDelegateForFunctionPointer(qvCW30dDHYwWOtUIy6.OZt1aWanO(qvCW30dDHYwWOtUIy6.xTuFFuFOZ(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(qvCW30dDHYwWOtUIy6.tKTvDRM4spXEKTlEQmd));
			}
			return qvCW30dDHYwWOtUIy6.P5dY8K1VM8(\u0020, \u0020, \u0020, \u0020, out \u0020);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000A2FC File Offset: 0x000084FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int fY7DsrDOt(IntPtr \u0020, int \u0020, int \u0020, ref int \u0020)
		{
			if (qvCW30dDHYwWOtUIy6.uLJYFTniA7 == null)
			{
				qvCW30dDHYwWOtUIy6.uLJYFTniA7 = (qvCW30dDHYwWOtUIy6.nxbMZOMmL3OhUNukW8q)Marshal.GetDelegateForFunctionPointer(qvCW30dDHYwWOtUIy6.OZt1aWanO(qvCW30dDHYwWOtUIy6.xTuFFuFOZ(), "Virtual ".Trim() + "Protect"), typeof(qvCW30dDHYwWOtUIy6.nxbMZOMmL3OhUNukW8q));
			}
			return qvCW30dDHYwWOtUIy6.uLJYFTniA7(\u0020, \u0020, \u0020, ref \u0020);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000A358 File Offset: 0x00008558
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr idOCGrHyh(uint \u0020, int \u0020, uint \u0020)
		{
			if (qvCW30dDHYwWOtUIy6.LZPYnfbEee == null)
			{
				qvCW30dDHYwWOtUIy6.LZPYnfbEee = (qvCW30dDHYwWOtUIy6.E5l3BOM6Zd3Fx1VjLqC)Marshal.GetDelegateForFunctionPointer(qvCW30dDHYwWOtUIy6.OZt1aWanO(qvCW30dDHYwWOtUIy6.xTuFFuFOZ(), "Open ".Trim() + "Process"), typeof(qvCW30dDHYwWOtUIy6.E5l3BOM6Zd3Fx1VjLqC));
			}
			return qvCW30dDHYwWOtUIy6.LZPYnfbEee(\u0020, \u0020, \u0020);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000A3B4 File Offset: 0x000085B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int AqGK2BXRj(IntPtr \u0020)
		{
			if (qvCW30dDHYwWOtUIy6.sgBYj8e840 == null)
			{
				qvCW30dDHYwWOtUIy6.sgBYj8e840 = (qvCW30dDHYwWOtUIy6.fURur6MluHkO2ql8UY6)Marshal.GetDelegateForFunctionPointer(qvCW30dDHYwWOtUIy6.OZt1aWanO(qvCW30dDHYwWOtUIy6.xTuFFuFOZ(), "Close ".Trim() + "Handle"), typeof(qvCW30dDHYwWOtUIy6.fURur6MluHkO2ql8UY6));
			}
			return qvCW30dDHYwWOtUIy6.sgBYj8e840(\u0020);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000A410 File Offset: 0x00008610
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr xTuFFuFOZ()
		{
			if (qvCW30dDHYwWOtUIy6.VvnYawYc27 == IntPtr.Zero)
			{
				qvCW30dDHYwWOtUIy6.VvnYawYc27 = qvCW30dDHYwWOtUIy6.YWfP2ZK1H("kernel ".Trim() + "32.dll");
			}
			return qvCW30dDHYwWOtUIy6.VvnYawYc27;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000A44C File Offset: 0x0000864C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] R8lZhuIDy(object \u0020)
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

		// Token: 0x06000059 RID: 89 RVA: 0x0000A4B8 File Offset: 0x000086B8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Stream HKEcbdZ8U()
		{
			return new MemoryStream();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000A4C0 File Offset: 0x000086C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] FOXA3YLCU(object \u0020)
		{
			return ((MemoryStream)\u0020).ToArray();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000A4D0 File Offset: 0x000086D0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] x9yzlLA8p(object \u0020)
		{
			Stream stream = qvCW30dDHYwWOtUIy6.HKEcbdZ8U();
			SymmetricAlgorithm symmetricAlgorithm = qvCW30dDHYwWOtUIy6.GeeSLbWP6();
			symmetricAlgorithm.Key = new byte[]
			{
				115, 8, 52, 196, 203, 84, 34, 14, 244, 173,
				171, 99, 26, 97, 91, 101, 3, 184, 92, 175,
				15, 92, 237, 54, 6, 69, 218, 163, 70, 121,
				137, 60
			};
			symmetricAlgorithm.IV = new byte[]
			{
				48, 87, 247, 121, 130, 6, 251, 127, 42, 53,
				165, 91, 236, 218, 12, 225
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(\u0020, 0, \u0020.Length);
			cryptoStream.Close();
			byte[] array = qvCW30dDHYwWOtUIy6.FOXA3YLCU(stream);
			PUJl6HMfyNoASU7yHDb.U5IJPevrmx();
			return array;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000A544 File Offset: 0x00008744
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] xTWY3SsPVK()
		{
			return null;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000A554 File Offset: 0x00008754
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] yIbYYmvgRm()
		{
			return null;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000A564 File Offset: 0x00008764
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] hv9YMGHUbQ()
		{
			int length = "{11111-22222-20001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000A584 File Offset: 0x00008784
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] oGHYkFI8bb()
		{
			int length = "{11111-22222-20001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000A5A4 File Offset: 0x000087A4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] N8bYTq7RAC()
		{
			return null;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000A5B4 File Offset: 0x000087B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] yUTYr0tGTb()
		{
			return null;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000A5C4 File Offset: 0x000087C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] aWcYquPU3b()
		{
			int length = "{11111-22222-40001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000A5E4 File Offset: 0x000087E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] QqOY4NVjZI()
		{
			int length = "{11111-22222-40001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000A604 File Offset: 0x00008804
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] XBNYmsRF39()
		{
			return null;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000A614 File Offset: 0x00008814
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] P6bY6SZMYj()
		{
			return null;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000A624 File Offset: 0x00008824
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object LfklnElIsRhooXxkWdi(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000A630 File Offset: 0x00008830
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Iw34B3lN4S3WhV1qH6D(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000A640 File Offset: 0x00008840
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long gmymuKlJDbqqluNR9Tn(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000A64C File Offset: 0x0000884C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object rsuCeylGmxDoSchD0no(object A_0, int \u0020)
		{
			return A_0.uImM3UQYql(\u0020);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000A65C File Offset: 0x0000885C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void mKIxerlBmKo8sCDAiyG(object A_0)
		{
			A_0.Wm2MkI9cYb();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000A668 File Offset: 0x00008868
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void PUv5CJlePxDT7YNitDy(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000A674 File Offset: 0x00008874
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object ABGEpylQOa8DWB2iico(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000A680 File Offset: 0x00008880
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object bthfGqlXGNsUaHCG0fA(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000A68C File Offset: 0x0000888C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object FDsu9el9C0B3YWDvrMO()
		{
			return qvCW30dDHYwWOtUIy6.GeeSLbWP6();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000A694 File Offset: 0x00008894
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Y6BHDslSkBa7eDTjodR(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000A6A4 File Offset: 0x000088A4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object J5m88GluGext5QcHDDT(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000A6B8 File Offset: 0x000088B8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object kBsrrslg9DSEu0OYvxA()
		{
			return qvCW30dDHYwWOtUIy6.HKEcbdZ8U();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000A6C0 File Offset: 0x000088C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void sj5OcilwxeUicoPFX1e(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000A6D8 File Offset: 0x000088D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void o5YU5UlUFUsPCrtktKO(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000A6E4 File Offset: 0x000088E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Js5RFHl0OH5hc8TaetU(object A_0)
		{
			return qvCW30dDHYwWOtUIy6.FOXA3YLCU(A_0);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000A6F0 File Offset: 0x000088F0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void dgD333lo288dHofWbUB(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000A6FC File Offset: 0x000088FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object wYkX0nlLJV8YWVQWkW7(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000A708 File Offset: 0x00008908
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool W13blal5EM8fQCSiJcf(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000A718 File Offset: 0x00008918
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool ypWm2YlbNmvgtVF73wP()
		{
			return null == null;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000A720 File Offset: 0x00008920
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object bHvDX2ld40V66PHt9Sp()
		{
			return null;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000A724 File Offset: 0x00008924
		static int TjcvJDJ16ELbTw3yZQ9()
		{
			return 1;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000A728 File Offset: 0x00008928
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr BGBgHYJ7W2OtsKmXbtt(IntPtr A_0, int A_1)
		{
			return Marshal.ReadIntPtr(A_0, A_1);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000A738 File Offset: 0x00008938
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int cLkJSJJDmOVCfaxv0w6(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt32(A_0, A_1);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000A748 File Offset: 0x00008948
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long HyIpmMJCdL66NXta1PE(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt64(A_0, A_1);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000A758 File Offset: 0x00008958
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void SrxMqBJKpY8sFdSnL3O(IntPtr A_0, int A_1, IntPtr A_2)
		{
			Marshal.WriteIntPtr(A_0, A_1, A_2);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000A76C File Offset: 0x0000896C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void O4wMPbJZu2A1L4gwxdD(IntPtr A_0, int A_1, int A_2)
		{
			Marshal.WriteInt32(A_0, A_1, A_2);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000A780 File Offset: 0x00008980
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void zCIt99Jc1e32c70pTJV(IntPtr A_0, int A_1, long A_2)
		{
			Marshal.WriteInt64(A_0, A_1, A_2);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000A794 File Offset: 0x00008994
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr d6jirSJAIRb0tZhRYXq(int A_0)
		{
			return Marshal.AllocCoTaskMem(A_0);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000A7A0 File Offset: 0x000089A0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void gUk62wJzVCx5TxpXjRZ(object A_0, int A_1, IntPtr A_2, int A_3)
		{
			Marshal.Copy(A_0, A_1, A_2, A_3);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000A7B8 File Offset: 0x000089B8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void SVwWTwG31ns8ercPprV()
		{
			qvCW30dDHYwWOtUIy6.ek2FhCoNN();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000A7C0 File Offset: 0x000089C0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object l5vTxwGYisGB1necjhn()
		{
			return Process.GetCurrentProcess();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000A7C8 File Offset: 0x000089C8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object yFVUB0GM1IJMpNFCH1g(object A_0)
		{
			return A_0.MainModule;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000A7D4 File Offset: 0x000089D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr PfrLytGk5nh2v7cnFZs(object A_0)
		{
			return A_0.BaseAddress;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000A7E0 File Offset: 0x000089E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr edqCJNGT3SHliq9mGEh(IntPtr \u0020, object A_1, uint \u0020)
		{
			return qvCW30dDHYwWOtUIy6.I88Vbml7q(\u0020, A_1, \u0020);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000A7F4 File Offset: 0x000089F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Bb4xfNGr2sxAJDCqyek(IntPtr A_0, IntPtr A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000A804 File Offset: 0x00008A04
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void qM8gP3GqsirqxOaQyQS()
		{
			PUJl6HMfyNoASU7yHDb.U5IJPevrmx();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000A80C File Offset: 0x00008A0C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int oT63duG47BSyvmlvi5B()
		{
			return IntPtr.Size;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000A814 File Offset: 0x00008A14
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type ShN7HgGmEHKOya6l49A(object A_0, bool A_1)
		{
			return Type.GetType(A_0, A_1);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000A824 File Offset: 0x00008A24
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool df2Ho4G6MQ1p3qjNdAU(Type A_0, Type A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000A834 File Offset: 0x00008A34
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object IWje7fGlcnmLcNXUAy4(object A_0)
		{
			return A_0.Modules;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000A840 File Offset: 0x00008A40
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object PRmqfpG2HdmrJijNqA6(object A_0)
		{
			return A_0.GetEnumerator();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000A84C File Offset: 0x00008A4C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object F4LJLTGfCn9GpN8DQQp(object A_0)
		{
			return ((IEnumerator)A_0).Current;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000A858 File Offset: 0x00008A58
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object wUvoH8GhMM4PS4HUyWs(object A_0)
		{
			return A_0.ModuleName;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000A864 File Offset: 0x00008A64
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Kiq4M3GOiOoDEDEZinT(object A_0)
		{
			return A_0.ToLower();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000A870 File Offset: 0x00008A70
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool eyeXweGEIAJ2ASO259X(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000A880 File Offset: 0x00008A80
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object JdoUWDGHXrukpkaghGP(object A_0)
		{
			return A_0.FileVersionInfo;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000A88C File Offset: 0x00008A8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int pt54hEGs2YV72ugHbYc(object A_0)
		{
			return A_0.ProductMajorPart;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000A898 File Offset: 0x00008A98
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int dojPqxGv33supZDCH8N(object A_0)
		{
			return A_0.ProductMinorPart;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000A8A4 File Offset: 0x00008AA4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int sHSjP9GbwCu3koEqOym(object A_0)
		{
			return A_0.ProductBuildPart;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000A8B0 File Offset: 0x00008AB0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int KTqHUpGdjL5oSU762Qq(object A_0)
		{
			return A_0.ProductPrivatePart;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000A8BC File Offset: 0x00008ABC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool FGQsk9GIXb1QDtoJZsL(object A_0, object A_1)
		{
			return A_0 >= A_1;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000A8CC File Offset: 0x00008ACC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool ld5DHPGNE6VnNiPBK83(object A_0, object A_1)
		{
			return A_0 < A_1;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000A8DC File Offset: 0x00008ADC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool p3pYGVGJGpGSnWZnm6a(object A_0)
		{
			return ((IEnumerator)A_0).MoveNext();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000A8E8 File Offset: 0x00008AE8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void kSsP84GGVZm1pRcgkcP(object A_0)
		{
			((IDisposable)A_0).Dispose();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000A8F4 File Offset: 0x00008AF4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AT1nAFGBPbhsMSnrSm1(object A_0, object A_1)
		{
			return A_0.GetManifestResourceStream(A_1);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000A904 File Offset: 0x00008B04
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object tBC9xdGeqmBi7Dijkaj(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000A910 File Offset: 0x00008B10
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void prqp8lGQPx5LS7fHwD4(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000A920 File Offset: 0x00008B20
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long fEWrHoGXap74qUqtuNp(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000A92C File Offset: 0x00008B2C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AoWimXG9OLHGUJZiN4k(object A_0, int \u0020)
		{
			return A_0.uImM3UQYql(\u0020);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000A93C File Offset: 0x00008B3C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void PiUtbOGSik3gcAg4IAJ(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000A948 File Offset: 0x00008B48
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object KYvSNqGutbDelNYfXgk(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000A954 File Offset: 0x00008B54
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object UJFokTGgJ0ToWN9ywdr(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000A960 File Offset: 0x00008B60
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void GXO1SIGwJ6Xso2MQrqv(object A_0, int A_1, int A_2)
		{
			Array.Clear(A_0, A_1, A_2);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000A974 File Offset: 0x00008B74
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object EhTlEjGU346V3fEYcTO(object A_0)
		{
			return A_0.GetModules();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000A980 File Offset: 0x00008B80
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr RfgZntG0ktbc0Jukiql(object A_0)
		{
			return Marshal.GetHINSTANCE(A_0);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000A98C File Offset: 0x00008B8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object IhnWNKGotbLGdq1Bfgh(object A_0)
		{
			return A_0.Location;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000A998 File Offset: 0x00008B98
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int S3s8ccGLFG9DHRaQp6m(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000A9A4 File Offset: 0x00008BA4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int KD94pSG5Z6gAEsXsLGh(object A_0)
		{
			return A_0.qwyMMHdChH();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000A9B0 File Offset: 0x00008BB0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object P38gxLGRNb8LFOjH26T()
		{
			return qvCW30dDHYwWOtUIy6.GeeSLbWP6();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000A9B8 File Offset: 0x00008BB8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void nKD2AqGxDs9d6RfjavV(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000A9C8 File Offset: 0x00008BC8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object jp5ybdGyNwa7AqcAyhF(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000A9DC File Offset: 0x00008BDC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ePpuydGiJulvLOL2abK(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000A9F4 File Offset: 0x00008BF4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void gixmv2GWmhVbHCyCWij(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000AA00 File Offset: 0x00008C00
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object TrBynwGt33EAsUXKDWt(object A_0)
		{
			return A_0.ToArray();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000AA0C File Offset: 0x00008C0C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void XAkX9LG8QMrbuwFsbGD(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000AA18 File Offset: 0x00008C18
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void bRP9VfGFr1tojq3jx34(object A_0)
		{
			A_0.Wm2MkI9cYb();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000AA24 File Offset: 0x00008C24
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int YUqSDdGnWBVeu2IEOE3(object A_0)
		{
			return A_0.Id;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000AA30 File Offset: 0x00008C30
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr m5nhVoGjtAdCSlQNrly(uint \u0020, int \u0020, uint \u0020)
		{
			return qvCW30dDHYwWOtUIy6.idOCGrHyh(\u0020, \u0020, \u0020);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000AA44 File Offset: 0x00008C44
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object TBGib5GaoRbOwonU4x7(int A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000AA50 File Offset: 0x00008C50
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long sca8nUGPxhQwO6fGr64(object A_0)
		{
			return A_0.Position;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000AA5C File Offset: 0x00008C5C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void IPryaXG15kkE9Vinrjb(IntPtr A_0, int A_1)
		{
			Marshal.WriteInt32(A_0, A_1);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000AA6C File Offset: 0x00008C6C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int da7WpYGVKvkVnrSSnB6(IntPtr \u0020)
		{
			return qvCW30dDHYwWOtUIy6.AqGK2BXRj(\u0020);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000AA78 File Offset: 0x00008C78
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void q9lBpfGpdiMMpDRP2Tq(object A_0, object A_1, object A_2)
		{
			A_0.Add(A_1, A_2);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000AA8C File Offset: 0x00008C8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type UQqQwgG7TbSPs3p1aLg(RuntimeTypeHandle A_0)
		{
			return Type.GetTypeFromHandle(A_0);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000AA98 File Offset: 0x00008C98
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int zt1L45GDOvWDYVPBs5Y(long A_0)
		{
			return Convert.ToInt32(A_0);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000AAA4 File Offset: 0x00008CA4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object WtOnYhGCjVxbcexDd6y()
		{
			return Encoding.UTF8;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000AAAC File Offset: 0x00008CAC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object tWRLbiGKpo2EdX8Mdpv(object A_0, object A_1)
		{
			return A_0.GetString(A_1);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000AABC File Offset: 0x00008CBC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool aFyLxdGZcjEJCP7D4Kv(IntPtr A_0, IntPtr A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000AACC File Offset: 0x00008CCC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object wn5AFCGcfc8yjINTqCZ(IntPtr \u0020, Type \u0020)
		{
			return qvCW30dDHYwWOtUIy6.S8GnlcCdU(\u0020, \u0020);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000AADC File Offset: 0x00008CDC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr XWi2ETGAlHq1UMp3VRN(object A_0)
		{
			return A_0();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000AAE8 File Offset: 0x00008CE8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int A0kQ1rGz3RiEXIem8Pn(IntPtr A_0)
		{
			return Marshal.ReadInt32(A_0);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000AAF4 File Offset: 0x00008CF4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long fnjuFLB3kjROTTdSjE2(IntPtr A_0)
		{
			return Marshal.ReadInt64(A_0);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000AB00 File Offset: 0x00008D00
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr qolTG4BYUcaYu7AHhRI(object A_0)
		{
			return Marshal.GetFunctionPointerForDelegate(A_0);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000AB0C File Offset: 0x00008D0C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int Bnb9EqBMpOq9eQapGNS(object A_0)
		{
			return A_0.ModuleMemorySize;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000AB18 File Offset: 0x00008D18
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object gD8QkRBk7P6TfgscGT9(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000AB24 File Offset: 0x00008D24
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool P9jwknBTulW14oNAiRJ(object A_0, object A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000AB34 File Offset: 0x00008D34
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object DoUvKDBrhmNRrob74ll(object A_0)
		{
			return A_0.Method;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000AB40 File Offset: 0x00008D40
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object IHVxlmBq2YCIMeHEovO(Type A_0, object A_1)
		{
			return Delegate.CreateDelegate(A_0, A_1);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000AB50 File Offset: 0x00008D50
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object MWwfebB4dPL1EnsO0B5(object A_0)
		{
			return A_0.GetParameters();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000AB5C File Offset: 0x00008D5C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object sVYp1IBmS5khsV5sXPU(object A_0)
		{
			return A_0.ManifestModule;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000AB68 File Offset: 0x00008D68
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ModuleHandle xuRKXtB6IXUlflCeTQa(object A_0)
		{
			return A_0.ModuleHandle;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000AB74 File Offset: 0x00008D74
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type SSHl4YBlLIirKkp82SY(object A_0)
		{
			return A_0.GetType();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000AB80 File Offset: 0x00008D80
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object RQ3xVkB2ZMJR8joPTUN(object A_0, object A_1)
		{
			return A_0.GetValue(A_1);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000AB90 File Offset: 0x00008D90
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object DJPkEdBf8mOWYs1AlRN(long A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000AB9C File Offset: 0x00008D9C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void M0YiB0BhHTIgyZHvFJ9(object A_0)
		{
			RuntimeHelpers.PrepareDelegate(A_0);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000ABA8 File Offset: 0x00008DA8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static RuntimeMethodHandle CdUGgcBO4C0pIEsWwOC(object A_0)
		{
			return A_0.MethodHandle;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000ABB4 File Offset: 0x00008DB4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void CNkN4mBEKZZnBoLFGDy(RuntimeMethodHandle A_0)
		{
			RuntimeHelpers.PrepareMethod(A_0);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000ABC0 File Offset: 0x00008DC0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void X1fHUdBHSKFrhcdmW8l(object A_0, RuntimeFieldHandle A_1)
		{
			RuntimeHelpers.InitializeArray(A_0, A_1);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000ABD0 File Offset: 0x00008DD0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr DLW278BspiNP2tuXRsE(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			return qvCW30dDHYwWOtUIy6.RT3pIFfYd(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000ABE8 File Offset: 0x00008DE8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void yggh0mBv0qFkcoI5wUF(IntPtr A_0, IntPtr A_1)
		{
			Marshal.WriteIntPtr(A_0, A_1);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000ABF8 File Offset: 0x00008DF8
		internal static bool LGaMxMJV2ZhfakkcDU8()
		{
			return null == null;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000AC00 File Offset: 0x00008E00
		internal static object XpLQdhJptbrg1uPYIA3()
		{
			return null;
		}

		// Token: 0x04000023 RID: 35
		private static object QMYYbXbxMh = new object();

		// Token: 0x04000024 RID: 36
		private static IntPtr ywUYB2dbn2 = IntPtr.Zero;

		// Token: 0x04000025 RID: 37
		private static int lPaYXuuYD1 = 1;

		// Token: 0x04000026 RID: 38
		private static object GPsYSxGP6s = new SortedList();

		// Token: 0x04000027 RID: 39
		private static bool Qg8YLYXP71 = false;

		// Token: 0x04000028 RID: 40
		private static IntPtr VvnYawYc27 = IntPtr.Zero;

		// Token: 0x04000029 RID: 41
		private static int SfoYoljwZB = 0;

		// Token: 0x0400002A RID: 42
		private static object FL9YsOPJPq = new object();

		// Token: 0x0400002B RID: 43
		private static Dictionary<int, int> sJdYH5f0IP = null;

		// Token: 0x0400002C RID: 44
		internal static object lgOYUS6yUH = null;

		// Token: 0x0400002D RID: 45
		private static bool cs2YlU7n3i = false;

		// Token: 0x0400002E RID: 46
		private static object sgBYj8e840 = null;

		// Token: 0x0400002F RID: 47
		private static int h1GYuAP0Jq = 0;

		// Token: 0x04000030 RID: 48
		private static object LZPYnfbEee = null;

		// Token: 0x04000031 RID: 49
		private static bool AqyYhkP5Gn = false;

		// Token: 0x04000032 RID: 50
		private static object b1EYewQYlF = new string[0];

		// Token: 0x04000033 RID: 51
		internal static object dllY2vEloY = typeof(qvCW30dDHYwWOtUIy6).Assembly;

		// Token: 0x04000034 RID: 52
		private static object dChYtULENX = null;

		// Token: 0x04000035 RID: 53
		private static int eCQYRaTWH4 = 0;

		// Token: 0x04000036 RID: 54
		private static List<int> mYCYIhCEKN = null;

		// Token: 0x04000037 RID: 55
		private static bool UG7YO2C5GZ = false;

		// Token: 0x04000038 RID: 56
		private static bool SsSY5jg3Xu = false;

		// Token: 0x04000039 RID: 57
		internal static object oBEYiiMK8Z = new Hashtable();

		// Token: 0x0400003A RID: 58
		internal static object BSjYEA4Eqs = null;

		// Token: 0x0400003B RID: 59
		private static object KPcYJYgpSQ = new byte[0];

		// Token: 0x0400003C RID: 60
		private static object P5dY8K1VM8 = null;

		// Token: 0x0400003D RID: 61
		private static List<string> y07YdwruMc = null;

		// Token: 0x0400003E RID: 62
		private static object TBeYN5LFa3 = new byte[0];

		// Token: 0x0400003F RID: 63
		private static object LP4YQsFg56 = new int[0];

		// Token: 0x04000040 RID: 64
		private static long m4oYg3B07I = 0L;

		// Token: 0x04000041 RID: 65
		private static int U4xYvd7pUg = 0;

		// Token: 0x04000042 RID: 66
		private static object VFnYWBsIGh = null;

		// Token: 0x04000043 RID: 67
		private static IntPtr GLUYGKlNO3 = IntPtr.Zero;

		// Token: 0x04000044 RID: 68
		private static bool e1JY9epcUF = false;

		// Token: 0x04000045 RID: 69
		private static object uLJYFTniA7 = null;

		// Token: 0x04000046 RID: 70
		private static IntPtr Ri9YxOlYeL = IntPtr.Zero;

		// Token: 0x04000047 RID: 71
		private static object CJYYfyWmEs = new uint[]
		{
			3614090360U, 3905402710U, 606105819U, 3250441966U, 4118548399U, 1200080426U, 2821735955U, 4249261313U, 1770035416U, 2336552879U,
			4294925233U, 2304563134U, 1804603682U, 4254626195U, 2792965006U, 1236535329U, 4129170786U, 3225465664U, 643717713U, 3921069994U,
			3593408605U, 38016083U, 3634488961U, 3889429448U, 568446438U, 3275163606U, 4107603335U, 1163531501U, 2850285829U, 4243563512U,
			1735328473U, 2368359562U, 4294588738U, 2272392833U, 1839030562U, 4259657740U, 2763975236U, 1272893353U, 4139469664U, 3200236656U,
			681279174U, 3936430074U, 3572445317U, 76029189U, 3654602809U, 3873151461U, 530742520U, 3299628645U, 4096336452U, 1126891415U,
			2878612391U, 4237533241U, 1700485571U, 2399980690U, 4293915773U, 2240044497U, 1873313359U, 4264355552U, 2734768916U, 1309151649U,
			4149444226U, 3174756917U, 718787259U, 3951481745U
		};

		// Token: 0x04000048 RID: 72
		private static long VOaY0shBjx = 0L;

		// Token: 0x04000049 RID: 73
		[qvCW30dDHYwWOtUIy6.Fy5l5oY1DXWJQB5eiG1(typeof(qvCW30dDHYwWOtUIy6.Fy5l5oY1DXWJQB5eiG1.lN4SpgYVVgVKojXTl3G<object>[]))]
		private static bool rUqYySGtYK = false;

		// Token: 0x0400004A RID: 74
		internal static object CATYwKdgRT = null;

		// Token: 0x0200000A RID: 10
		private sealed class FOVsPDYPrrW6a9uJBaI : MulticastDelegate
		{
			// Token: 0x060000D6 RID: 214
			public extern FOVsPDYPrrW6a9uJBaI(object \u0020, IntPtr \u0020);

			// Token: 0x060000D7 RID: 215
			public extern void Invoke(object o);

			// Token: 0x060000D8 RID: 216
			public extern IAsyncResult BeginInvoke(object o, AsyncCallback callback, object @object);

			// Token: 0x060000D9 RID: 217
			public extern void EndInvoke(IAsyncResult result);

			// Token: 0x060000DA RID: 218 RVA: 0x0000AC04 File Offset: 0x00008E04
			static FOVsPDYPrrW6a9uJBaI()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x0200000B RID: 11
		internal class Fy5l5oY1DXWJQB5eiG1 : Attribute
		{
			// Token: 0x060000DB RID: 219 RVA: 0x0000AC0C File Offset: 0x00008E0C
			[MethodImpl(MethodImplOptions.NoInlining)]
			public Fy5l5oY1DXWJQB5eiG1(object \u0020)
			{
			}

			// Token: 0x060000DC RID: 220 RVA: 0x0000AC14 File Offset: 0x00008E14
			static Fy5l5oY1DXWJQB5eiG1()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}

			// Token: 0x0200000C RID: 12
			internal class lN4SpgYVVgVKojXTl3G<wIlfAeYpl9CIOK0cW9i>
			{
				// Token: 0x060000DD RID: 221 RVA: 0x0000AC1C File Offset: 0x00008E1C
				[MethodImpl(MethodImplOptions.NoInlining)]
				public lN4SpgYVVgVKojXTl3G()
				{
				}

				// Token: 0x060000DE RID: 222 RVA: 0x0000AC2C File Offset: 0x00008E2C
				[MethodImpl(MethodImplOptions.NoInlining)]
				static lN4SpgYVVgVKojXTl3G()
				{
					qvCW30dDHYwWOtUIy6.fkYjhgZND();
					HOZT9MMstpchNdZiTSe.nnJBbXpc0a();
				}

				// Token: 0x060000DF RID: 223 RVA: 0x0000AC38 File Offset: 0x00008E38
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool Me82xUESLwGwm7LPCqx()
				{
					return true;
				}

				// Token: 0x060000E0 RID: 224 RVA: 0x0000AC40 File Offset: 0x00008E40
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static object XcQRI9EuCIugvdB2mtp()
				{
					return null;
				}

				// Token: 0x0400004B RID: 75
				private static object vwk6QKE9eYjoWv9iZff;
			}
		}

		// Token: 0x0200000D RID: 13
		internal class WesXa1Y7PSJrXwfGZmK
		{
			// Token: 0x060000E1 RID: 225 RVA: 0x0000AC48 File Offset: 0x00008E48
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static string GCfYD7lysq(object \u0020, object \u0020)
			{
				return null;
			}

			// Token: 0x060000E2 RID: 226 RVA: 0x0000AC58 File Offset: 0x00008E58
			[MethodImpl(MethodImplOptions.NoInlining)]
			public WesXa1Y7PSJrXwfGZmK()
			{
			}

			// Token: 0x060000E3 RID: 227 RVA: 0x0000AC60 File Offset: 0x00008E60
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object veLgwTE0opFmTynDHBU()
			{
				return null;
			}

			// Token: 0x060000E4 RID: 228 RVA: 0x0000AC68 File Offset: 0x00008E68
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object EUjUMPEoodgIrHL2pai(object A_0, object A_1)
			{
				return null;
			}

			// Token: 0x060000E5 RID: 229 RVA: 0x0000AC70 File Offset: 0x00008E70
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void TTKPabELKYo1wfK4K2Y(object A_0, RuntimeFieldHandle A_1)
			{
			}

			// Token: 0x060000E6 RID: 230 RVA: 0x0000AC78 File Offset: 0x00008E78
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object Vs6FPiE5AEhIRijPV7I(object A_0)
			{
				return null;
			}

			// Token: 0x060000E7 RID: 231 RVA: 0x0000AC80 File Offset: 0x00008E80
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object c4TlBlER3wXFTEY03t6()
			{
				return null;
			}

			// Token: 0x060000E8 RID: 232 RVA: 0x0000AC88 File Offset: 0x00008E88
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void oH6NTUEx7xSh69Gd7tt(object A_0, object A_1)
			{
			}

			// Token: 0x060000E9 RID: 233 RVA: 0x0000AC90 File Offset: 0x00008E90
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void fiaaxAEyV0WIm12F8Go(object A_0, object A_1, int A_2, int A_3)
			{
			}

			// Token: 0x060000EA RID: 234 RVA: 0x0000AC98 File Offset: 0x00008E98
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void QleI46EiTHIu328JImH(object A_0)
			{
			}

			// Token: 0x060000EB RID: 235 RVA: 0x0000ACA0 File Offset: 0x00008EA0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object vVkGDjEWkHFkL9X7pBw(object A_0)
			{
				return null;
			}

			// Token: 0x060000EC RID: 236 RVA: 0x0000ACA8 File Offset: 0x00008EA8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object LuvRItEtitutn1FTydp(object A_0)
			{
				return null;
			}

			// Token: 0x060000ED RID: 237 RVA: 0x0000ACB0 File Offset: 0x00008EB0
			static WesXa1Y7PSJrXwfGZmK()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x0200000E RID: 14
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal sealed class ipKfv4YCBHm4wmIbaZn : MulticastDelegate
		{
			// Token: 0x060000EE RID: 238
			public extern ipKfv4YCBHm4wmIbaZn(object \u0020, IntPtr \u0020);

			// Token: 0x060000EF RID: 239
			public extern uint Invoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

			// Token: 0x060000F0 RID: 240
			public extern IAsyncResult BeginInvoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode, AsyncCallback callback, object @object);

			// Token: 0x060000F1 RID: 241
			public extern uint EndInvoke(ref uint nativeSizeOfCode, IAsyncResult result);

			// Token: 0x060000F2 RID: 242 RVA: 0x0000ACB8 File Offset: 0x00008EB8
			static ipKfv4YCBHm4wmIbaZn()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x0200000F RID: 15
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class urvwbDYKRHr2nFerJh6 : MulticastDelegate
		{
			// Token: 0x060000F3 RID: 243
			public extern urvwbDYKRHr2nFerJh6(object \u0020, IntPtr \u0020);

			// Token: 0x060000F4 RID: 244
			public extern IntPtr Invoke();

			// Token: 0x060000F5 RID: 245
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x060000F6 RID: 246
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x060000F7 RID: 247 RVA: 0x0000ACC0 File Offset: 0x00008EC0
			static urvwbDYKRHr2nFerJh6()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x02000010 RID: 16
		internal struct FrX3D7YZMOMqCdWreZ6
		{
			// Token: 0x0400004C RID: 76
			internal bool FTXYcopS1m;

			// Token: 0x0400004D RID: 77
			internal byte[] yMZYAWkgc8;
		}

		// Token: 0x02000011 RID: 17
		internal class fh1hmAYzyWp7H1O7Q9k
		{
			// Token: 0x060000F8 RID: 248 RVA: 0x0000ACC8 File Offset: 0x00008EC8
			[MethodImpl(MethodImplOptions.NoInlining)]
			public fh1hmAYzyWp7H1O7Q9k(Stream \u0020)
			{
				this.wykMTVphaW = new BinaryReader(\u0020);
			}

			// Token: 0x060000F9 RID: 249 RVA: 0x0000ACE4 File Offset: 0x00008EE4
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal Stream nW4lBacjpc()
			{
				return qvCW30dDHYwWOtUIy6.fh1hmAYzyWp7H1O7Q9k.tbLLeAE1Oqc4Lte6p88(this.wykMTVphaW);
			}

			// Token: 0x060000FA RID: 250 RVA: 0x0000ACF8 File Offset: 0x00008EF8
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal byte[] uImM3UQYql(int \u0020)
			{
				return this.wykMTVphaW.ReadBytes(\u0020);
			}

			// Token: 0x060000FB RID: 251 RVA: 0x0000AD10 File Offset: 0x00008F10
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int IHGMYsrpqE(byte[] \u0020, int \u0020, int \u0020)
			{
				return qvCW30dDHYwWOtUIy6.fh1hmAYzyWp7H1O7Q9k.zFteNqEVYVT3DX1UjKt(this.wykMTVphaW, \u0020, \u0020, \u0020);
			}

			// Token: 0x060000FC RID: 252 RVA: 0x0000AD28 File Offset: 0x00008F28
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int qwyMMHdChH()
			{
				return qvCW30dDHYwWOtUIy6.fh1hmAYzyWp7H1O7Q9k.ONPADxEpZPj492t1vfL(this.wykMTVphaW);
			}

			// Token: 0x060000FD RID: 253 RVA: 0x0000AD3C File Offset: 0x00008F3C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void Wm2MkI9cYb()
			{
				this.wykMTVphaW.Close();
			}

			// Token: 0x060000FE RID: 254 RVA: 0x0000AD50 File Offset: 0x00008F50
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object tbLLeAE1Oqc4Lte6p88(object A_0)
			{
				return A_0.BaseStream;
			}

			// Token: 0x060000FF RID: 255 RVA: 0x0000AD64 File Offset: 0x00008F64
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static int zFteNqEVYVT3DX1UjKt(object A_0, object A_1, int A_2, int A_3)
			{
				return A_0.Read(A_1, A_2, A_3);
			}

			// Token: 0x06000100 RID: 256 RVA: 0x0000AD84 File Offset: 0x00008F84
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static int ONPADxEpZPj492t1vfL(object A_0)
			{
				return A_0.ReadInt32();
			}

			// Token: 0x06000101 RID: 257 RVA: 0x0000AD98 File Offset: 0x00008F98
			static fh1hmAYzyWp7H1O7Q9k()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}

			// Token: 0x0400004E RID: 78
			private object wykMTVphaW;
		}

		// Token: 0x02000012 RID: 18
		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private sealed class WLv7jOMrxGK9hdPsiE5 : MulticastDelegate
		{
			// Token: 0x06000102 RID: 258
			public extern WLv7jOMrxGK9hdPsiE5(object \u0020, IntPtr \u0020);

			// Token: 0x06000103 RID: 259
			public extern IntPtr Invoke(IntPtr hModule, string lpName, uint lpType);

			// Token: 0x06000104 RID: 260
			public extern IAsyncResult BeginInvoke(IntPtr hModule, string lpName, uint lpType, AsyncCallback callback, object @object);

			// Token: 0x06000105 RID: 261
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000106 RID: 262 RVA: 0x0000ADA0 File Offset: 0x00008FA0
			static WLv7jOMrxGK9hdPsiE5()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x02000013 RID: 19
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class OuS3lZMqodAfQgQVfHQ : MulticastDelegate
		{
			// Token: 0x06000107 RID: 263
			public extern OuS3lZMqodAfQgQVfHQ(object \u0020, IntPtr \u0020);

			// Token: 0x06000108 RID: 264
			public extern IntPtr Invoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x06000109 RID: 265
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect, AsyncCallback callback, object @object);

			// Token: 0x0600010A RID: 266
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600010B RID: 267 RVA: 0x0000ADA8 File Offset: 0x00008FA8
			static OuS3lZMqodAfQgQVfHQ()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x02000014 RID: 20
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class tKTvDRM4spXEKTlEQmd : MulticastDelegate
		{
			// Token: 0x0600010C RID: 268
			public extern tKTvDRM4spXEKTlEQmd(object \u0020, IntPtr \u0020);

			// Token: 0x0600010D RID: 269
			public extern int Invoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

			// Token: 0x0600010E RID: 270
			public extern IAsyncResult BeginInvoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten, AsyncCallback callback, object @object);

			// Token: 0x0600010F RID: 271
			public extern int EndInvoke(out IntPtr lpNumberOfBytesWritten, IAsyncResult result);

			// Token: 0x06000110 RID: 272 RVA: 0x0000ADB0 File Offset: 0x00008FB0
			static tKTvDRM4spXEKTlEQmd()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x02000015 RID: 21
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class nxbMZOMmL3OhUNukW8q : MulticastDelegate
		{
			// Token: 0x06000111 RID: 273
			public extern nxbMZOMmL3OhUNukW8q(object \u0020, IntPtr \u0020);

			// Token: 0x06000112 RID: 274
			public extern int Invoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

			// Token: 0x06000113 RID: 275
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect, AsyncCallback callback, object @object);

			// Token: 0x06000114 RID: 276
			public extern int EndInvoke(ref int lpflOldProtect, IAsyncResult result);

			// Token: 0x06000115 RID: 277 RVA: 0x0000ADB8 File Offset: 0x00008FB8
			static nxbMZOMmL3OhUNukW8q()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x02000016 RID: 22
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class E5l3BOM6Zd3Fx1VjLqC : MulticastDelegate
		{
			// Token: 0x06000116 RID: 278
			public extern E5l3BOM6Zd3Fx1VjLqC(object \u0020, IntPtr \u0020);

			// Token: 0x06000117 RID: 279
			public extern IntPtr Invoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x06000118 RID: 280
			public extern IAsyncResult BeginInvoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId, AsyncCallback callback, object @object);

			// Token: 0x06000119 RID: 281
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600011A RID: 282 RVA: 0x0000ADC0 File Offset: 0x00008FC0
			static E5l3BOM6Zd3Fx1VjLqC()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x02000017 RID: 23
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class fURur6MluHkO2ql8UY6 : MulticastDelegate
		{
			// Token: 0x0600011B RID: 283
			public extern fURur6MluHkO2ql8UY6(object \u0020, IntPtr \u0020);

			// Token: 0x0600011C RID: 284
			public extern int Invoke(IntPtr ptr);

			// Token: 0x0600011D RID: 285
			public extern IAsyncResult BeginInvoke(IntPtr ptr, AsyncCallback callback, object @object);

			// Token: 0x0600011E RID: 286
			public extern int EndInvoke(IAsyncResult result);

			// Token: 0x0600011F RID: 287 RVA: 0x0000ADC8 File Offset: 0x00008FC8
			static fURur6MluHkO2ql8UY6()
			{
				qvCW30dDHYwWOtUIy6.fkYjhgZND();
			}
		}

		// Token: 0x02000018 RID: 24
		[Flags]
		private enum zg0FCrM2skogluNbcFG
		{

		}
	}
}
