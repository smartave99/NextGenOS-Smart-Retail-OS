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
using s1A8ZyM9ktJqKeBLMri;
using U4Pe9KMCa0o49GDNo9Y;
using yDAOk6MUKT9ReD8KRRC;

namespace OOtEyhLrBlJkJWIAxM
{
	// Token: 0x0200000A RID: 10
	internal class sdwn9hocwBVuZe0IsL
	{
		// Token: 0x0600004B RID: 75 RVA: 0x000028BC File Offset: 0x00000ABC
		[MethodImpl(MethodImplOptions.NoInlining)]
		static sdwn9hocwBVuZe0IsL()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002A30 File Offset: 0x00000C30
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void iDyBwVBD9Q()
		{
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002A34 File Offset: 0x00000C34
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] SST5IpCUN(object \u0020)
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
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num6, num7, num8, num9, 0U, 7, 1U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num9, num6, num7, num8, 1U, 12, 2U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num8, num9, num6, num7, 2U, 17, 3U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num7, num8, num9, num6, 3U, 22, 4U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num6, num7, num8, num9, 4U, 7, 5U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num9, num6, num7, num8, 5U, 12, 6U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num8, num9, num6, num7, 6U, 17, 7U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num7, num8, num9, num6, 7U, 22, 8U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num6, num7, num8, num9, 8U, 7, 9U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num9, num6, num7, num8, 9U, 12, 10U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num8, num9, num6, num7, 10U, 17, 11U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num7, num8, num9, num6, 11U, 22, 12U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num6, num7, num8, num9, 12U, 7, 13U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num9, num6, num7, num8, 13U, 12, 14U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num8, num9, num6, num7, 14U, 17, 15U, array);
				sdwn9hocwBVuZe0IsL.KvYRr8RFZ(ref num7, num8, num9, num6, 15U, 22, 16U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num6, num7, num8, num9, 1U, 5, 17U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num9, num6, num7, num8, 6U, 9, 18U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num8, num9, num6, num7, 11U, 14, 19U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num7, num8, num9, num6, 0U, 20, 20U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num6, num7, num8, num9, 5U, 5, 21U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num9, num6, num7, num8, 10U, 9, 22U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num8, num9, num6, num7, 15U, 14, 23U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num7, num8, num9, num6, 4U, 20, 24U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num6, num7, num8, num9, 9U, 5, 25U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num9, num6, num7, num8, 14U, 9, 26U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num8, num9, num6, num7, 3U, 14, 27U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num7, num8, num9, num6, 8U, 20, 28U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num6, num7, num8, num9, 13U, 5, 29U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num9, num6, num7, num8, 2U, 9, 30U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num8, num9, num6, num7, 7U, 14, 31U, array);
				sdwn9hocwBVuZe0IsL.wNcx9GEgf(ref num7, num8, num9, num6, 12U, 20, 32U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num6, num7, num8, num9, 5U, 4, 33U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num9, num6, num7, num8, 8U, 11, 34U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num8, num9, num6, num7, 11U, 16, 35U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num7, num8, num9, num6, 14U, 23, 36U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num6, num7, num8, num9, 1U, 4, 37U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num9, num6, num7, num8, 4U, 11, 38U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num8, num9, num6, num7, 7U, 16, 39U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num7, num8, num9, num6, 10U, 23, 40U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num6, num7, num8, num9, 13U, 4, 41U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num9, num6, num7, num8, 0U, 11, 42U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num8, num9, num6, num7, 3U, 16, 43U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num7, num8, num9, num6, 6U, 23, 44U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num6, num7, num8, num9, 9U, 4, 45U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num9, num6, num7, num8, 12U, 11, 46U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num8, num9, num6, num7, 15U, 16, 47U, array);
				sdwn9hocwBVuZe0IsL.VAgyX3luS(ref num7, num8, num9, num6, 2U, 23, 48U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num6, num7, num8, num9, 0U, 6, 49U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num9, num6, num7, num8, 7U, 10, 50U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num8, num9, num6, num7, 14U, 15, 51U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num7, num8, num9, num6, 5U, 21, 52U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num6, num7, num8, num9, 12U, 6, 53U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num9, num6, num7, num8, 3U, 10, 54U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num8, num9, num6, num7, 10U, 15, 55U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num7, num8, num9, num6, 1U, 21, 56U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num6, num7, num8, num9, 8U, 6, 57U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num9, num6, num7, num8, 15U, 10, 58U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num8, num9, num6, num7, 6U, 15, 59U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num7, num8, num9, num6, 13U, 21, 60U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num6, num7, num8, num9, 4U, 6, 61U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num9, num6, num7, num8, 11U, 10, 62U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num8, num9, num6, num7, 2U, 15, 63U, array);
				sdwn9hocwBVuZe0IsL.CtPiXW41E(ref num7, num8, num9, num6, 9U, 21, 64U, array);
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

		// Token: 0x0600004E RID: 78 RVA: 0x00003098 File Offset: 0x00001298
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void KvYRr8RFZ(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += sdwn9hocwBVuZe0IsL.fVgWCfjBd(\u0020 + ((\u0020 & \u0020) | (~\u0020 & \u0020)) + \u0020[(int)\u0020] + sdwn9hocwBVuZe0IsL.xcvYXOkYis[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000030C4 File Offset: 0x000012C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void wNcx9GEgf(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += sdwn9hocwBVuZe0IsL.fVgWCfjBd(\u0020 + ((\u0020 & \u0020) | (\u0020 & ~\u0020)) + \u0020[(int)\u0020] + sdwn9hocwBVuZe0IsL.xcvYXOkYis[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000030F0 File Offset: 0x000012F0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void VAgyX3luS(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += sdwn9hocwBVuZe0IsL.fVgWCfjBd(\u0020 + (\u0020 ^ \u0020 ^ \u0020) + \u0020[(int)\u0020] + sdwn9hocwBVuZe0IsL.xcvYXOkYis[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003118 File Offset: 0x00001318
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void CtPiXW41E(ref uint \u0020, uint \u0020, uint \u0020, uint \u0020, uint \u0020, ushort \u0020, uint \u0020, object \u0020)
		{
			\u0020 += sdwn9hocwBVuZe0IsL.fVgWCfjBd(\u0020 + (\u0020 ^ (\u0020 | ~\u0020)) + \u0020[(int)\u0020] + sdwn9hocwBVuZe0IsL.xcvYXOkYis[(int)(\u0020 - 1U)], \u0020);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003140 File Offset: 0x00001340
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static uint fVgWCfjBd(uint \u0020, ushort \u0020)
		{
			return (\u0020 >> (int)(32 - \u0020)) | (\u0020 << (int)\u0020);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003154 File Offset: 0x00001354
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool F7rtH56xU()
		{
			if (!sdwn9hocwBVuZe0IsL.UNFY92yQ4x)
			{
				sdwn9hocwBVuZe0IsL.n4Mnvk3qH();
				sdwn9hocwBVuZe0IsL.UNFY92yQ4x = true;
			}
			return sdwn9hocwBVuZe0IsL.PteYSIYDHW;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003170 File Offset: 0x00001370
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal sdwn9hocwBVuZe0IsL()
		{
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003178 File Offset: 0x00001378
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Ce682TXFu(byte[] \u0020, byte[] \u0020, byte[] \u0020)
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
			sdwn9hocwBVuZe0IsL.PMAY5HYFCx = array;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000034FC File Offset: 0x000016FC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static SymmetricAlgorithm mrRFYAAan()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (sdwn9hocwBVuZe0IsL.F7rtH56xU())
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

		// Token: 0x06000057 RID: 87 RVA: 0x00003590 File Offset: 0x00001790
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void n4Mnvk3qH()
		{
			try
			{
				new MD5CryptoServiceProvider();
			}
			catch
			{
				sdwn9hocwBVuZe0IsL.PteYSIYDHW = true;
				return;
			}
			try
			{
				sdwn9hocwBVuZe0IsL.PteYSIYDHW = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000035E8 File Offset: 0x000017E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] nuyjL0947(object \u0020)
		{
			if (!sdwn9hocwBVuZe0IsL.F7rtH56xU())
			{
				return new MD5CryptoServiceProvider().ComputeHash(\u0020);
			}
			return sdwn9hocwBVuZe0IsL.SST5IpCUN(\u0020);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003608 File Offset: 0x00001808
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void cAbaayt4b(object \u0020, object \u0020, uint \u0020, object \u0020)
		{
			while (\u0020 > 0U)
			{
				int num = ((\u0020 > (uint)\u0020.Length) ? \u0020.Length : ((int)\u0020));
				\u0020.Read(\u0020, 0, num);
				sdwn9hocwBVuZe0IsL.O6UPBg5Hu(\u0020, \u0020, 0, num);
				\u0020 -= (uint)num;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000364C File Offset: 0x0000184C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void O6UPBg5Hu(object \u0020, object \u0020, int \u0020, int \u0020)
		{
			\u0020.TransformBlock(\u0020, \u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000365C File Offset: 0x0000185C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint kDk1xKidL(uint \u0020, int \u0020, long \u0020, object \u0020)
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

		// Token: 0x0600005C RID: 92 RVA: 0x000036C4 File Offset: 0x000018C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Uk3V9MMbt(RuntimeTypeHandle \u0020)
		{
			try
			{
				Type typeFromHandle = Type.GetTypeFromHandle(\u0020);
				if (sdwn9hocwBVuZe0IsL.WZ5YglEGcJ == null)
				{
					object obj = sdwn9hocwBVuZe0IsL.rbjYwmDvOe;
					lock (obj)
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						BinaryReader binaryReader = new BinaryReader(typeof(sdwn9hocwBVuZe0IsL).Assembly.GetManifestResourceStream("k39M532UNSSWmUOLD4.x2lTXAfhWQphoCZyUm"));
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
							sdwn9hocwBVuZe0IsL.MCRQrIMElFcjUmhrYwF mcrqrIMElFcjUmhrYwF = new sdwn9hocwBVuZe0IsL.MCRQrIMElFcjUmhrYwF(new MemoryStream(array));
							for (int l = 0; l < num20; l++)
							{
								int num21 = mcrqrIMElFcjUmhrYwF.oqiMvIw9LD();
								int num22 = mcrqrIMElFcjUmhrYwF.oqiMvIw9LD();
								dictionary.Add(num21, num22);
							}
							mcrqrIMElFcjUmhrYwF.jMOMb8BjZg();
						}
						sdwn9hocwBVuZe0IsL.WZ5YglEGcJ = dictionary;
					}
				}
				FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
				for (int m = 0; m < fields.Length; m++)
				{
					try
					{
						FieldInfo fieldInfo = fields[m];
						int metadataToken = fieldInfo.MetadataToken;
						int num23 = sdwn9hocwBVuZe0IsL.WZ5YglEGcJ[metadataToken];
						bool flag2 = (num23 & 1073741824) > 0;
						num23 &= 1073741823;
						MethodInfo methodInfo = (MethodInfo)typeof(sdwn9hocwBVuZe0IsL).Module.ResolveMethod(num23, typeFromHandle.GetGenericArguments(), new Type[0]);
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

		// Token: 0x0600005D RID: 93 RVA: 0x00003D70 File Offset: 0x00001F70
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void CTTCKAARS()
		{
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003D74 File Offset: 0x00001F74
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void UMUK29U4E(object \u0020, int \u0020)
		{
			b769XnMDrH7eDivLKZu.JxKMAnCO4m(0, new object[] { \u0020, \u0020 }, null);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003DB4 File Offset: 0x00001FB4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string PMBZBhVTY(int \u0020)
		{
			if (sdwn9hocwBVuZe0IsL.PMAY5HYFCx.Length == 0)
			{
				sdwn9hocwBVuZe0IsL.k59YobwKZb = new List<string>();
				sdwn9hocwBVuZe0IsL.GYkYL5BFGT = new List<int>();
				sdwn9hocwBVuZe0IsL.UMUK29U4E(sdwn9hocwBVuZe0IsL.HW2YQnV3Hp.GetManifestResourceStream("sHn9akYDnRaYYXXuRu.LW7g5uMNZo3i64BPDj"), \u0020);
			}
			if (sdwn9hocwBVuZe0IsL.UjiYUuHuXa < 75)
			{
				if (sdwn9hocwBVuZe0IsL.HW2YQnV3Hp != new StackFrame(1).GetMethod().DeclaringType.Assembly)
				{
					throw new Exception();
				}
				sdwn9hocwBVuZe0IsL.UjiYUuHuXa++;
			}
			object w9jY0YjL4q = sdwn9hocwBVuZe0IsL.W9jY0YjL4q;
			lock (w9jY0YjL4q)
			{
				int num = BitConverter.ToInt32(sdwn9hocwBVuZe0IsL.PMAY5HYFCx, \u0020);
				if (num < sdwn9hocwBVuZe0IsL.GYkYL5BFGT.Count && sdwn9hocwBVuZe0IsL.GYkYL5BFGT[num] == \u0020)
				{
					return sdwn9hocwBVuZe0IsL.k59YobwKZb[num];
				}
				try
				{
					q8C8UxMXBu3qF3m8192.wF6BUtFUUD();
					byte[] array = new byte[num];
					Array.Copy(sdwn9hocwBVuZe0IsL.PMAY5HYFCx, \u0020 + 4, array, 0, num);
					string @string = Encoding.Unicode.GetString(array, 0, array.Length);
					sdwn9hocwBVuZe0IsL.k59YobwKZb.Add(@string);
					sdwn9hocwBVuZe0IsL.GYkYL5BFGT.Add(\u0020);
					Array.Copy(BitConverter.GetBytes(sdwn9hocwBVuZe0IsL.k59YobwKZb.Count - 1), 0, sdwn9hocwBVuZe0IsL.PMAY5HYFCx, \u0020, 4);
					return @string;
				}
				catch
				{
				}
			}
			return "";
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003F2C File Offset: 0x0000212C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string hcicCmNJY(object \u0020)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(\u0020);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003F5C File Offset: 0x0000215C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint O8wAQ1EkQ(IntPtr \u0020, IntPtr \u0020, IntPtr \u0020, [MarshalAs(UnmanagedType.U4)] uint \u0020, IntPtr \u0020, ref uint \u0020)
		{
			IntPtr intPtr = \u0020;
			if (sdwn9hocwBVuZe0IsL.f2FYe0cg8x)
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
			object obj = sdwn9hocwBVuZe0IsL.bThYZMo80t[num];
			if (obj == null)
			{
				return sdwn9hocwBVuZe0IsL.jtsYaqmqlL(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA fRw86wMffvVYO8Ce8dA = (sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA)obj;
			IntPtr intPtr2 = Marshal.AllocCoTaskMem(fRw86wMffvVYO8Ce8dA.coEMOgfFUM.Length);
			Marshal.Copy(fRw86wMffvVYO8Ce8dA.coEMOgfFUM, 0, intPtr2, fRw86wMffvVYO8Ce8dA.coEMOgfFUM.Length);
			if (fRw86wMffvVYO8Ce8dA.OlHMhVQ03F)
			{
				\u0020 = intPtr2;
				\u0020 = (uint)fRw86wMffvVYO8Ce8dA.coEMOgfFUM.Length;
				sdwn9hocwBVuZe0IsL.kfkY6lTjH7(\u0020, fRw86wMffvVYO8Ce8dA.coEMOgfFUM.Length, 64, ref sdwn9hocwBVuZe0IsL.RRRYDXeRAd);
				return 0U;
			}
			Marshal.WriteIntPtr(intPtr, IntPtr.Size * 2, intPtr2);
			Marshal.WriteInt32(intPtr, IntPtr.Size * 3, fRw86wMffvVYO8Ce8dA.coEMOgfFUM.Length);
			uint num2 = 0U;
			if (\u0020 != 216669565U || sdwn9hocwBVuZe0IsL.ibcYKY6AJa)
			{
				num2 = sdwn9hocwBVuZe0IsL.jtsYaqmqlL(\u0020, \u0020, \u0020, \u0020, \u0020, ref \u0020);
			}
			else
			{
				sdwn9hocwBVuZe0IsL.ibcYKY6AJa = true;
			}
			return num2;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004090 File Offset: 0x00002290
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int nbZzmjOl0()
		{
			return 5;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004094 File Offset: 0x00002294
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void y0kY3ct6CB()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000040C4 File Offset: 0x000022C4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Delegate MIeYYR7YZD(IntPtr \u0020, Type \u0020)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[] { \u0020, \u0020 });
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004124 File Offset: 0x00002324
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe static void K2lYMhew6a()
		{
			int num = 389;
			for (;;)
			{
				int num2 = num;
				byte[] array;
				int num3;
				byte[] array2;
				int num4;
				byte[] array3;
				int num5;
				byte[] array4;
				sdwn9hocwBVuZe0IsL.MCRQrIMElFcjUmhrYwF mcrqrIMElFcjUmhrYwF;
				long num6;
				int num8;
				byte[] array9;
				int num16;
				byte[] array10;
				uint num17;
				byte[] array11;
				uint num19;
				int num30;
				IntPtr intPtr6;
				long num36;
				uint num37;
				int num43;
				int num60;
				int num75;
				int num76;
				uint num77;
				IntPtr intPtr9;
				for (;;)
				{
					byte[] array6;
					byte[] array7;
					int num7;
					IntPtr intPtr;
					Process process;
					IEnumerator enumerator;
					long num12;
					IntPtr intPtr2;
					byte[] array8;
					byte[] array13;
					IntPtr intPtr3;
					byte[] array15;
					byte[] array14;
					IntPtr zero;
					int num18;
					int num20;
					int num21;
					uint num25;
					int num27;
					int num26;
					int num28;
					uint num29;
					int num32;
					byte[] array16;
					int num33;
					long num34;
					int num35;
					byte[] array18;
					IntPtr intPtr7;
					int num38;
					int num39;
					int num40;
					int num42;
					int num44;
					IntPtr intPtr8;
					int num61;
					switch (num2)
					{
					case 0:
						goto IL_2280;
					case 1:
						array[22] = (byte)num3;
						num2 = 484;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 36;
							continue;
						}
						continue;
					case 2:
						num3 = 151 - 120;
						num2 = 136;
						continue;
					case 3:
						goto IL_5829;
					case 4:
						array2[6] = (byte)num4;
						num2 = 467;
						continue;
					case 5:
						array3[num5 + 5] = array4[5];
						num2 = 47;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 73;
							continue;
						}
						continue;
					case 6:
						goto IL_294A;
					case 7:
						array2[9] = 120 + 34;
						num2 = 72;
						continue;
					case 8:
						array2[7] = (byte)num4;
						num2 = 559;
						continue;
					case 9:
						array[27] = 141 - 47;
						num2 = 404;
						continue;
					case 10:
					{
						byte[] array5 = sdwn9hocwBVuZe0IsL.X8ZSdOehycuDZmVCmrk(mcrqrIMElFcjUmhrYwF, (int)sdwn9hocwBVuZe0IsL.Pjgqnmefo4pM513HYvv(sdwn9hocwBVuZe0IsL.jURbFbelkILPa80E2mT(mcrqrIMElFcjUmhrYwF)));
						num2 = 107;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 41;
							continue;
						}
						continue;
					}
					case 11:
						array[0] = (byte)num3;
						num2 = 132;
						continue;
					case 12:
						goto IL_5324;
					case 13:
						array2[6] = (byte)num4;
						num2 = 141;
						continue;
					case 14:
						sdwn9hocwBVuZe0IsL.pRkoReByHuVNAMGRPif(new IntPtr((void*)(&num6)), 0, IntPtr.Zero);
						num2 = 556;
						continue;
					case 15:
					{
						object obj = sdwn9hocwBVuZe0IsL.qaTrUweJmdgqvpCHX5N();
						sdwn9hocwBVuZe0IsL.abPE3beGjrDgK5KVsZ4(obj, CipherMode.CBC);
						ICryptoTransform cryptoTransform = sdwn9hocwBVuZe0IsL.m4FmGmeBm2XZRl3PBpg(obj, array6, array7);
						num2 = 505;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 244;
							continue;
						}
						continue;
					}
					case 16:
					{
						CryptoStream cryptoStream;
						sdwn9hocwBVuZe0IsL.qtF5O3e9A9STqlf4Xj7(cryptoStream);
						num2 = 49;
						continue;
					}
					case 17:
						if (num7 == 4)
						{
							num2 = 15;
							continue;
						}
						goto IL_603A;
					case 18:
						array2[14] = (byte)num4;
						num2 = 586;
						continue;
					case 19:
						num3 = 177 - 59;
						num2 = 214;
						continue;
					case 20:
						goto IL_2C9F;
					case 21:
						num3 = 92 + 67;
						num2 = 501;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 77;
							continue;
						}
						continue;
					case 22:
						array[19] = 18 + 75;
						num2 = 279;
						continue;
					case 23:
						array2[6] = (byte)num4;
						num2 = 89;
						continue;
					case 24:
						sdwn9hocwBVuZe0IsL.kfkY6lTjH7(intPtr, 4, num8, ref num8);
						num2 = 178;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 39;
							continue;
						}
						continue;
					case 25:
						sdwn9hocwBVuZe0IsL.O0CDQGBVv1lf3joLys9();
						num2 = 28;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 52;
							continue;
						}
						continue;
					case 26:
						try
						{
							enumerator = sdwn9hocwBVuZe0IsL.pJPGysBK5rm4P6gKahV(sdwn9hocwBVuZe0IsL.BAF30YBC93yXgHK0cYx(process));
							int num9 = 0;
							if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
							{
								num9 = 0;
							}
							switch (num9)
							{
							default:
								try
								{
									for (;;)
									{
										IL_268A:
										if (sdwn9hocwBVuZe0IsL.gd4ZMoe4EVg4wQIfHqe(enumerator))
										{
											goto IL_2593;
										}
										int num10 = 4;
										ProcessModule processModule;
										for (;;)
										{
											IL_2552:
											switch (num10)
											{
											case 1:
												goto IL_268A;
											case 2:
												goto IL_25BB;
											case 3:
											{
												long num11 = num12;
												intPtr2 = sdwn9hocwBVuZe0IsL.fUMoR1BarEYFYHARIpI(processModule);
												if (num11 > intPtr2.ToInt64() + (long)sdwn9hocwBVuZe0IsL.T9ucbYej3R8wFsWqxe0(processModule))
												{
													num10 = 9;
													continue;
												}
												goto IL_268A;
											}
											case 4:
												goto IL_26A0;
											case 5:
											{
												string text;
												if (sdwn9hocwBVuZe0IsL.qeK7fOBzMi5Lu01n5xb(sdwn9hocwBVuZe0IsL.QIwGTPBcZTGF7jsNan0(processModule), text))
												{
													num10 = 7;
													continue;
												}
												goto IL_268A;
											}
											case 6:
												goto IL_2593;
											case 7:
											{
												long num13 = num12;
												intPtr2 = sdwn9hocwBVuZe0IsL.fUMoR1BarEYFYHARIpI(processModule);
												if (num13 >= intPtr2.ToInt64())
												{
													num10 = 3;
													continue;
												}
												goto IL_2661;
											}
											case 8:
												goto IL_25DA;
											case 9:
												goto IL_2661;
											}
											IL_2584:
											sdwn9hocwBVuZe0IsL.O0CDQGBVv1lf3joLys9();
											num10 = 8;
											continue;
											IL_2661:
											if (sdwn9hocwBVuZe0IsL.lus8xWeP4wwsS9aie3w(sdwn9hocwBVuZe0IsL.hgkh8Qeai0cY7tT4mcB(sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL).TypeHandle).Assembly), null))
											{
												goto IL_2584;
											}
											num10 = 2;
										}
										IL_25BB:
										continue;
										IL_2593:
										processModule = (ProcessModule)sdwn9hocwBVuZe0IsL.wgGkeABZsoCmUcVnuHt(enumerator);
										num10 = 5;
										if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
										{
											num10 = 4;
											goto IL_2552;
										}
										goto IL_2552;
									}
									IL_25DA:
									return;
									IL_26A0:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num14 = 1;
									if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
									{
										num14 = 1;
									}
									for (;;)
									{
										switch (num14)
										{
										default:
											sdwn9hocwBVuZe0IsL.s3UL5memStMP0xeBqVX(disposable);
											num14 = 2;
											if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
											{
												num14 = 2;
											}
											break;
										case 1:
											if (disposable == null)
											{
												goto IL_2724;
											}
											num14 = 0;
											if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
											{
												num14 = 0;
											}
											break;
										case 2:
											goto IL_2724;
										}
									}
									IL_2724:;
								}
								break;
							case 1:
								break;
							}
							goto IL_24A0;
						}
						catch
						{
							int num15 = 0;
							if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
							{
								num15 = 0;
							}
							switch (num15)
							{
							default:
								goto IL_24A0;
							}
						}
						goto IL_2780;
					case 27:
						array2[2] = 171 + 18;
						num2 = 75;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 127;
							continue;
						}
						continue;
					case 28:
						array2[8] = 34 + 76;
						num2 = 658;
						continue;
					case 29:
						array[25] = 50 + 50;
						num2 = 297;
						continue;
					case 30:
						array[11] = (byte)num3;
						num2 = 438;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 353;
							continue;
						}
						continue;
					case 31:
						array[12] = (byte)num3;
						num2 = 49;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 535;
							continue;
						}
						continue;
					case 32:
						num4 = 11 + 49;
						num2 = 604;
						continue;
					case 33:
						array8[0] = 103;
						num2 = 262;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 309;
							continue;
						}
						continue;
					case 34:
						goto IL_4199;
					case 35:
						sdwn9hocwBVuZe0IsL.RkEK8yezpBpgCjkLhmd(sdwn9hocwBVuZe0IsL.udjMDHeAPOLc2oKruLL(sdwn9hocwBVuZe0IsL.tbCD4be1gBOsWCMtiNg(sdwn9hocwBVuZe0IsL.YBSYPhtPcy)));
						num2 = 612;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 450;
							continue;
						}
						continue;
					case 36:
						array2[7] = 51 + 47;
						num2 = 590;
						continue;
					case 37:
						goto IL_2C3F;
					case 38:
						num3 = 39 + 90;
						num2 = 577;
						continue;
					case 39:
						num3 = 112 + 67;
						num2 = 659;
						continue;
					case 40:
						num3 = 12 + 83;
						num2 = 190;
						continue;
					case 41:
						num4 = 23 + 88;
						num2 = 18;
						continue;
					case 42:
						array2[3] = (byte)num4;
						num2 = 299;
						continue;
					case 43:
						if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() == 4)
						{
							goto Block_226;
						}
						goto IL_0E16;
					case 44:
						array2[1] = 254 - 84;
						num2 = 187;
						continue;
					case 45:
						array3[num5 + 7] = array9[7];
						num2 = 636;
						continue;
					case 46:
						goto IL_2211;
					case 47:
						sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
						num2 = 290;
						continue;
					case 48:
						array3[num16] = array10[0];
						num2 = 578;
						continue;
					case 49:
						sdwn9hocwBVuZe0IsL.PXLLc2eSMZn9b2u341w(mcrqrIMElFcjUmhrYwF);
						num2 = 544;
						continue;
					case 50:
						num17 <<= 8;
						num2 = 609;
						continue;
					case 51:
					{
						string text = sdwn9hocwBVuZe0IsL.Jeo9xfey3kU58du2Htn(sdwn9hocwBVuZe0IsL.RC0qqAexyyowQr6Uw8c(), array11);
						num2 = 331;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 625;
							continue;
						}
						continue;
					}
					case 52:
						return;
					case 53:
					{
						byte[] array12;
						mcrqrIMElFcjUmhrYwF = new sdwn9hocwBVuZe0IsL.MCRQrIMElFcjUmhrYwF(new MemoryStream(array12));
						num2 = 549;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 324;
							continue;
						}
						continue;
					}
					case 54:
						num3 = 2 + 38;
						num2 = 208;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 323;
							continue;
						}
						continue;
					case 55:
						goto IL_3E3A;
					case 56:
						array11[6] = 105;
						num2 = 153;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 529;
							continue;
						}
						continue;
					case 57:
						num3 = 73 + 16;
						num2 = 395;
						continue;
					case 58:
						array[30] = (byte)num3;
						num2 = 235;
						continue;
					case 59:
						goto IL_4C6C;
					case 60:
						goto IL_5DDE;
					case 61:
						goto IL_604C;
					case 62:
						goto IL_5D7A;
					case 63:
						goto IL_1C56;
					case 64:
						sdwn9hocwBVuZe0IsL.usJQyrB864bv0Wsds9J(new byte[1], 0, sdwn9hocwBVuZe0IsL.JKgAMCBtmGCGQOwORHb(8), 1);
						num2 = 96;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 150;
							continue;
						}
						continue;
					case 65:
						array3[num5 + 3] = array10[3];
						num2 = 135;
						continue;
					case 66:
						array13 = sdwn9hocwBVuZe0IsL.glFDQpeHW89BUcqc0Wq(sdwn9hocwBVuZe0IsL.E8AFoNeEfNt8tL7Wyft(sdwn9hocwBVuZe0IsL.HW2YQnV3Hp));
						num2 = 212;
						continue;
					case 67:
						num4 = 190 - 63;
						num2 = 483;
						continue;
					case 68:
						array6 = array;
						num2 = 454;
						continue;
					case 69:
						array[28] = 130 - 43;
						num2 = 457;
						continue;
					case 70:
						array[13] = 23 + 88;
						num2 = 61;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 10;
							continue;
						}
						continue;
					case 71:
						goto IL_4ACB;
					case 72:
						array2[9] = 129 - 116;
						num2 = 203;
						continue;
					case 73:
						array3[num5 + 6] = array4[6];
						num2 = 557;
						continue;
					case 74:
						intPtr3 = sdwn9hocwBVuZe0IsL.JNG7nUegMRGdARyWT8e(56U, 1, (uint)sdwn9hocwBVuZe0IsL.ldRmiXeulLDvJwAa6Ej(sdwn9hocwBVuZe0IsL.z04QVgBnBcbRh9bFvpm()));
						num2 = 286;
						continue;
					case 75:
						num4 = 47 + 97;
						num2 = 0;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 8;
							continue;
						}
						continue;
					case 76:
						array[9] = (byte)num3;
						num2 = 632;
						continue;
					case 77:
						goto IL_429E;
					case 78:
						array[29] = 113 + 118;
						num2 = 119;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 199;
							continue;
						}
						continue;
					case 79:
						num3 = 67 + 107;
						num2 = 126;
						continue;
					case 80:
						if (sdwn9hocwBVuZe0IsL.AhsQsKedAUaWx5O73vT(sdwn9hocwBVuZe0IsL.HW2YQnV3Hp) == null)
						{
							num2 = 498;
							continue;
						}
						goto IL_5324;
					case 81:
						num16 = 9;
						num2 = 543;
						continue;
					case 82:
						num3 = 161 + 5;
						num2 = 375;
						continue;
					case 83:
						goto IL_2BF9;
					case 84:
						num8 = 0;
						num2 = 173;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 95;
							continue;
						}
						continue;
					case 85:
						array[7] = 178 - 59;
						num2 = 475;
						continue;
					case 86:
						array[8] = (byte)num3;
						num2 = 366;
						continue;
					case 87:
						if (!sdwn9hocwBVuZe0IsL.LdUJbWB1gc9nmnedTSe(sdwn9hocwBVuZe0IsL.qDDCTiBPkMbepdU7DLh(sdwn9hocwBVuZe0IsL.fUMoR1BarEYFYHARIpI(sdwn9hocwBVuZe0IsL.zYGaRlBjwgA2DCnlE9D(sdwn9hocwBVuZe0IsL.z04QVgBnBcbRh9bFvpm())), "__", 10U), IntPtr.Zero))
						{
							num2 = 121;
							continue;
						}
						goto IL_44D5;
					case 88:
						num4 = 27 + 83;
						num2 = 224;
						continue;
					case 89:
						array2[6] = 241 - 80;
						num2 = 145;
						continue;
					case 90:
						array14 = new byte[array15.Length];
						num2 = 585;
						continue;
					case 91:
						array8[4] = 105;
						num2 = 434;
						continue;
					case 92:
						array2[10] = (byte)num4;
						num2 = 342;
						continue;
					case 93:
						goto IL_3F2F;
					case 94:
						goto IL_500D;
					case 95:
						goto IL_480C;
					case 96:
						goto IL_3C88;
					case 97:
						array[27] = (byte)num3;
						num2 = 284;
						continue;
					case 98:
						goto IL_20DB;
					case 99:
						zero = IntPtr.Zero;
						num2 = 570;
						continue;
					case 100:
						array2[11] = (byte)num4;
						num2 = 88;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 20;
							continue;
						}
						continue;
					case 101:
						num18 = 0;
						num2 = 390;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 464;
							continue;
						}
						continue;
					case 102:
						goto IL_4ACB;
					case 103:
						num3 = 252 - 84;
						num2 = 176;
						continue;
					case 104:
						array8[2] = 116;
						num2 = 440;
						continue;
					case 105:
						array[12] = 245 - 81;
						num2 = 370;
						continue;
					case 106:
						array[28] = (byte)num3;
						num2 = 69;
						continue;
					case 107:
						array = new byte[32];
						num2 = 539;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 497;
							continue;
						}
						continue;
					case 108:
						goto IL_654E;
					case 109:
						array[6] = (byte)num3;
						num2 = 353;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 565;
							continue;
						}
						continue;
					case 110:
						array11[2] = 114;
						num2 = 322;
						continue;
					case 111:
						goto IL_5157;
					case 112:
						goto IL_40C2;
					case 113:
						goto IL_19C9;
					case 114:
						array2[13] = 166 - 55;
						num2 = 617;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 247;
							continue;
						}
						continue;
					case 115:
						num3 = 206 - 89;
						num2 = 117;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 20;
							continue;
						}
						continue;
					case 116:
					{
						IntPtr intPtr4;
						if (!sdwn9hocwBVuZe0IsL.OaPl1Qeihdp0boqGGJd(intPtr4, IntPtr.Zero))
						{
							goto IL_3C88;
						}
						num2 = 533;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 234;
							continue;
						}
						continue;
					}
					case 117:
						goto IL_464C;
					case 118:
						array[26] = 70 + 6;
						num2 = 299;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 431;
							continue;
						}
						continue;
					case 119:
						num3 = 47 + 107;
						num2 = 140;
						continue;
					case 120:
						num4 = 176 + 24;
						num2 = 4;
						continue;
					case 121:
						sdwn9hocwBVuZe0IsL.O0CDQGBVv1lf3joLys9();
						num2 = 288;
						continue;
					case 122:
						array3[num16 + 3] = array4[3];
						num2 = 430;
						continue;
					case 123:
						num19 = (uint)(num20 * 4);
						num2 = 36;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 134;
							continue;
						}
						continue;
					case 124:
						num4 = 228 - 76;
						num2 = 340;
						continue;
					case 125:
						array[8] = (byte)num3;
						num2 = 398;
						continue;
					case 126:
						array[26] = (byte)num3;
						num2 = 497;
						continue;
					case 127:
						array2[3] = 39 + 122;
						num2 = 12;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 339;
							continue;
						}
						continue;
					case 128:
						num21 = sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
						num2 = 415;
						continue;
					case 129:
						array3[num5 + 6] = array10[6];
						num2 = 92;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 209;
							continue;
						}
						continue;
					case 130:
					{
						uint num22;
						if (num22 == 4109628145U)
						{
							num2 = 87;
							continue;
						}
						goto IL_44D5;
					}
					case 131:
					{
						int num23 = sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
						bool flag = false;
						if (num23 < 1879048192)
						{
							goto IL_19C9;
						}
						num2 = 136;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 293;
							continue;
						}
						continue;
					}
					case 132:
						num3 = 58 + 47;
						num2 = 411;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 58;
							continue;
						}
						continue;
					case 133:
						goto IL_2EC7;
					case 134:
					{
						uint num24 = (uint)(((int)array6[(int)(num19 + 3U)] << 24) | ((int)array6[(int)(num19 + 2U)] << 16) | ((int)array6[(int)(num19 + 1U)] << 8) | (int)array6[(int)num19]);
						num2 = 311;
						continue;
					}
					case 135:
						array3[num5 + 4] = array10[4];
						num2 = 294;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 164;
							continue;
						}
						continue;
					case 136:
						array[14] = (byte)num3;
						num2 = 118;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 555;
							continue;
						}
						continue;
					case 137:
						array7[3] = array13[1];
						num2 = 548;
						continue;
					case 138:
						array2[4] = (byte)num4;
						num2 = 32;
						continue;
					case 139:
						num4 = 61 + 124;
						num2 = 425;
						continue;
					case 140:
						array[9] = (byte)num3;
						num2 = 219;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 242;
							continue;
						}
						continue;
					case 141:
						num4 = 218 - 72;
						num2 = 427;
						continue;
					case 142:
						goto IL_2857;
					case 143:
						goto IL_3E27;
					case 144:
						sdwn9hocwBVuZe0IsL.NN0rEIecj3u3GYQ6O5f(sdwn9hocwBVuZe0IsL.YBSYPhtPcy);
						num2 = 35;
						continue;
					case 145:
						num4 = 65 + 28;
						num2 = 12;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 13;
							continue;
						}
						continue;
					case 146:
						goto IL_6131;
					case 147:
						goto IL_153C;
					case 148:
						goto IL_29EB;
					case 149:
						intPtr2 = sdwn9hocwBVuZe0IsL.vN3AFbebjZI4eDrctoc(sdwn9hocwBVuZe0IsL.nIUhuxevLRfZNLqP2eg(sdwn9hocwBVuZe0IsL.HW2YQnV3Hp)[0]);
						num2 = 468;
						continue;
					case 150:
						sdwn9hocwBVuZe0IsL.HcdGlfBFBiYJ7htS7w9();
						num2 = 130;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 61;
							continue;
						}
						continue;
					case 151:
						num3 = 68 + 116;
						num2 = 253;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 177;
							continue;
						}
						continue;
					case 152:
						array2[11] = 124 + 113;
						num2 = 599;
						continue;
					case 153:
						num25 <<= 8;
						num2 = 48;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 170;
							continue;
						}
						continue;
					case 154:
						array[5] = 137 - 45;
						num2 = 195;
						continue;
					case 155:
					{
						sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA fRw86wMffvVYO8Ce8dA;
						fRw86wMffvVYO8Ce8dA.coEMOgfFUM = new byte[] { 42 };
						num2 = 159;
						continue;
					}
					case 156:
						array2[10] = 243 - 81;
						num2 = 634;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 501;
							continue;
						}
						continue;
					case 157:
						array11[0] = 109;
						num2 = 560;
						continue;
					case 158:
						num26 = num27 * 4;
						num2 = 123;
						continue;
					case 159:
					{
						sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA fRw86wMffvVYO8Ce8dA;
						fRw86wMffvVYO8Ce8dA.OlHMhVQ03F = false;
						num2 = 622;
						continue;
					}
					case 160:
						goto IL_1438;
					case 161:
						sdwn9hocwBVuZe0IsL.RkEK8yezpBpgCjkLhmd(sdwn9hocwBVuZe0IsL.udjMDHeAPOLc2oKruLL(sdwn9hocwBVuZe0IsL.tbCD4be1gBOsWCMtiNg(sdwn9hocwBVuZe0IsL.jtsYaqmqlL)));
						num2 = 144;
						continue;
					case 162:
						array[0] = 106 + 77;
						num2 = 241;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 119;
							continue;
						}
						continue;
					case 163:
						array11[1] = 108;
						num2 = 110;
						continue;
					case 164:
						goto IL_13A2;
					case 165:
					{
						string text = sdwn9hocwBVuZe0IsL.Jeo9xfey3kU58du2Htn(sdwn9hocwBVuZe0IsL.RC0qqAexyyowQr6Uw8c(), array11);
						num2 = 482;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 43;
							continue;
						}
						continue;
					}
					case 166:
						goto IL_3CCA;
					case 167:
						goto IL_24A0;
					case 168:
						num4 = 135 - 45;
						num2 = 595;
						continue;
					case 169:
						goto IL_21B8;
					case 170:
						num28 += 8;
						num2 = 402;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 504;
							continue;
						}
						continue;
					case 171:
					{
						MemoryStream memoryStream = new MemoryStream();
						ICryptoTransform cryptoTransform;
						CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
						byte[] array5;
						sdwn9hocwBVuZe0IsL.kO66GQeeo0dvUDuELlE(cryptoStream, array5, 0, array5.Length);
						sdwn9hocwBVuZe0IsL.zsGVBHeQ5k3XfICp0le(cryptoStream);
						byte[] array12 = sdwn9hocwBVuZe0IsL.O2spJveXJMoW6IZWxnM(memoryStream);
						sdwn9hocwBVuZe0IsL.DTM3PaesamGskiR7JUf(array7, 0, array7.Length);
						sdwn9hocwBVuZe0IsL.qtF5O3e9A9STqlf4Xj7(memoryStream);
						num2 = 16;
						continue;
					}
					case 172:
						array14[num26 + 1] = (byte)((num29 & 65280U) >> 8);
						num2 = 526;
						continue;
					case 173:
						num30 = 0;
						num2 = 80;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 77;
							continue;
						}
						continue;
					case 174:
						array[11] = 27 + 83;
						num2 = 134;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 291;
							continue;
						}
						continue;
					case 175:
					{
						int num31 = sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
						num2 = 233;
						continue;
					}
					case 176:
						array[3] = (byte)num3;
						num2 = 40;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 16;
							continue;
						}
						continue;
					case 177:
						num4 = 198 - 66;
						num2 = 49;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 100;
							continue;
						}
						continue;
					case 178:
						num32++;
						num2 = 133;
						continue;
					case 179:
						array[23] = 9 + 44;
						num2 = 188;
						continue;
					case 180:
						sdwn9hocwBVuZe0IsL.O0CDQGBVv1lf3joLys9();
						num2 = 34;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 319;
							continue;
						}
						continue;
					case 181:
						goto IL_3970;
					case 182:
						array2[0] = 121 + 94;
						num2 = 320;
						continue;
					case 183:
						array[5] = 54 - 2;
						num2 = 39;
						continue;
					case 184:
						num3 = 130 - 55;
						num2 = 337;
						continue;
					case 185:
						num3 = 111 + 18;
						num2 = 512;
						continue;
					case 186:
						goto IL_2BF9;
					case 187:
						num4 = 55 + 10;
						num2 = 423;
						continue;
					case 188:
						array[23] = 136 - 45;
						num2 = 95;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 115;
							continue;
						}
						continue;
					case 189:
					{
						byte[] array12;
						if ((array16 = array12) != null)
						{
							goto IL_3113;
						}
						num2 = 72;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 83;
							continue;
						}
						continue;
					}
					case 190:
						array[3] = (byte)num3;
						num2 = 432;
						continue;
					case 191:
						sdwn9hocwBVuZe0IsL.YiOXRZBRdTAidDyFE1K(new IntPtr((void*)(&num6)), 0);
						num2 = 521;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 111;
							continue;
						}
						continue;
					case 192:
						goto IL_17B7;
					case 193:
						goto IL_1308;
					case 194:
						num4 = 37 + 107;
						num2 = 42;
						continue;
					case 195:
						num3 = 62 + 119;
						num2 = 447;
						continue;
					case 196:
						goto IL_1608;
					case 197:
						array[19] = (byte)num3;
						num2 = 0;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 433;
							continue;
						}
						continue;
					case 198:
					{
						IntPtr intPtr5 = IntPtr.Zero;
						num2 = 418;
						continue;
					}
					case 199:
						array[29] = 105 + 107;
						num2 = 527;
						continue;
					case 200:
						array[21] = 116 + 115;
						num2 = 399;
						continue;
					case 201:
						array2[13] = (byte)num4;
						num2 = 338;
						continue;
					case 202:
						array3[num5 + 4] = array4[4];
						num2 = 5;
						continue;
					case 203:
						array2[10] = 174 - 58;
						num2 = 315;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 271;
							continue;
						}
						continue;
					case 204:
						if (num33 > 0)
						{
							num2 = 350;
							continue;
						}
						goto IL_35CF;
					case 205:
						array11[11] = 108;
						num2 = 165;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 79;
							continue;
						}
						continue;
					case 206:
						array[7] = 211 - 101;
						num2 = 470;
						continue;
					case 207:
						array2[8] = (byte)num4;
						num2 = 392;
						continue;
					case 208:
						array[10] = 177 + 70;
						num2 = 174;
						continue;
					case 209:
						array3[num5 + 7] = array10[7];
						num2 = 536;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 276;
							continue;
						}
						continue;
					case 210:
						sdwn9hocwBVuZe0IsL.kfkY6lTjH7(intPtr, 4, 8, ref num8);
						num2 = 453;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 375;
							continue;
						}
						continue;
					case 211:
						num3 = 146 + 74;
						num2 = 58;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 48;
							continue;
						}
						continue;
					case 212:
						if (array13 != null)
						{
							num2 = 302;
							continue;
						}
						goto IL_3E3A;
					case 213:
						goto IL_5FD1;
					case 214:
						array[16] = (byte)num3;
						num2 = 166;
						continue;
					case 215:
						array[15] = (byte)num3;
						num2 = 15;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 184;
							continue;
						}
						continue;
					case 216:
						array2[2] = 174 - 58;
						num2 = 593;
						continue;
					case 217:
						array[29] = 241 - 80;
						num2 = 490;
						continue;
					case 218:
						array[17] = (byte)num3;
						num2 = 408;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 353;
							continue;
						}
						continue;
					case 219:
						array2[14] = (byte)num4;
						num2 = 139;
						continue;
					case 220:
						num3 = 125 - 41;
						num2 = 1;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 1;
							continue;
						}
						continue;
					case 221:
						array[26] = (byte)num3;
						num2 = 54;
						continue;
					case 222:
						num3 = 34 + 116;
						num2 = 237;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 654;
							continue;
						}
						continue;
					case 223:
						array[18] = 37 + 80;
						num2 = 358;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 122;
							continue;
						}
						continue;
					case 224:
						array2[11] = (byte)num4;
						num2 = 152;
						continue;
					case 225:
						num4 = 87 - 48;
						num2 = 613;
						continue;
					case 226:
						num4 = 132 - 97;
						num2 = 460;
						continue;
					case 227:
						array[14] = 113 + 38;
						num2 = 0;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 228:
						if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() == 4)
						{
							num2 = 537;
							continue;
						}
						goto IL_203D;
					case 229:
						num34 = intPtr2.ToInt64();
						num2 = 60;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 84;
							continue;
						}
						continue;
					case 230:
						num3 = 254 - 84;
						num2 = 346;
						continue;
					case 231:
						array[1] = 113 - 68;
						num2 = 74;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 270;
							continue;
						}
						continue;
					case 232:
						num4 = 127 - 42;
						num2 = 23;
						continue;
					case 233:
					{
						int num31;
						intPtr6 = new IntPtr(sdwn9hocwBVuZe0IsL.RdKYjGBxn6 + (long)num31 - (long)num30);
						num2 = 583;
						continue;
					}
					case 234:
						num3 = 0 + 43;
						num2 = 566;
						continue;
					case 235:
						array[31] = 130 - 43;
						num2 = 545;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 151;
							continue;
						}
						continue;
					case 236:
						array[30] = (byte)num3;
						num2 = 348;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 183;
							continue;
						}
						continue;
					case 237:
						goto IL_55EF;
					case 238:
						array[3] = 147 - 49;
						num2 = 558;
						continue;
					case 239:
						goto IL_57A9;
					case 240:
						goto IL_55EF;
					case 241:
						num3 = 107 + 124;
						num2 = 656;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 551;
							continue;
						}
						continue;
					case 242:
						num3 = 156 - 52;
						num2 = 76;
						continue;
					case 243:
						array[19] = 198 - 118;
						num2 = 630;
						continue;
					case 244:
						goto IL_185D;
					case 245:
						array11[5] = 116;
						num2 = 59;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 381;
							continue;
						}
						continue;
					case 246:
						array[16] = 155 + 95;
						num2 = 213;
						continue;
					case 247:
						array[18] = (byte)num3;
						num2 = 21;
						continue;
					case 248:
						if (num27 == num35 - 1)
						{
							num2 = 655;
							continue;
						}
						goto IL_2C3F;
					case 249:
						array[9] = (byte)num3;
						num2 = 387;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 574;
							continue;
						}
						continue;
					case 250:
						goto IL_11BF;
					case 251:
						array2[15] = 76 - 38;
						num2 = 627;
						continue;
					case 252:
						array[27] = 72 + 120;
						num2 = 506;
						continue;
					case 253:
						array[7] = (byte)num3;
						num2 = 206;
						continue;
					case 254:
						array[31] = (byte)num3;
						num2 = 330;
						continue;
					case 255:
						goto IL_0EE1;
					case 256:
						goto IL_2DD0;
					case 257:
						goto IL_1E08;
					case 258:
						num4 = 199 - 66;
						num2 = 192;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 334;
							continue;
						}
						continue;
					case 259:
						array[29] = (byte)num3;
						num2 = 67;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 78;
							continue;
						}
						continue;
					case 260:
						goto IL_4C6C;
					case 261:
						num3 = 135 - 45;
						num2 = 106;
						continue;
					case 262:
						array11[9] = 108;
						num2 = 51;
						continue;
					case 263:
						if (!sdwn9hocwBVuZe0IsL.lus8xWeP4wwsS9aie3w(sdwn9hocwBVuZe0IsL.hgkh8Qeai0cY7tT4mcB(sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL).TypeHandle).Assembly), null))
						{
							goto IL_480C;
						}
						num2 = 154;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 349;
							continue;
						}
						continue;
					case 264:
						num4 = 233 - 77;
						num2 = 650;
						continue;
					case 265:
						num3 = 111 - 37;
						num2 = 180;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 663;
							continue;
						}
						continue;
					case 266:
						goto IL_3E3A;
					case 267:
						array7[15] = array13[7];
						num2 = 463;
						continue;
					case 268:
						num17 = 0U;
						num2 = 101;
						continue;
					case 269:
						if (num27 == num35 - 1)
						{
							num2 = 204;
							continue;
						}
						goto IL_35CF;
					case 270:
						array[2] = 139 - 46;
						num2 = 84;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 573;
							continue;
						}
						continue;
					case 271:
						array[14] = (byte)num3;
						num2 = 2;
						continue;
					case 272:
						goto IL_615D;
					case 273:
						goto IL_22E1;
					case 274:
						array11[4] = 105;
						num2 = 245;
						continue;
					case 275:
						break;
					case 276:
					{
						sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA fRw86wMffvVYO8Ce8dA = default(sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA);
						num2 = 13;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 155;
							continue;
						}
						continue;
					}
					case 277:
						array16 = null;
						num2 = 13;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 53;
							continue;
						}
						continue;
					case 278:
						goto IL_3F0C;
					case 279:
						goto IL_1880;
					case 280:
						goto IL_1C3D;
					case 281:
						array[0] = (byte)num3;
						num2 = 469;
						continue;
					case 282:
						array3[num16 + 2] = array4[2];
						num2 = 122;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 36;
							continue;
						}
						continue;
					case 283:
						num3 = 34 + 76;
						num2 = 125;
						continue;
					case 284:
						array[27] = 110 + 67;
						num2 = 9;
						continue;
					case 285:
						sdwn9hocwBVuZe0IsL.PrCen7e2rQhm9FsvsPd(sdwn9hocwBVuZe0IsL.jURbFbelkILPa80E2mT(mcrqrIMElFcjUmhrYwF), 0L);
						num2 = 10;
						continue;
					case 286:
						if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() == 4)
						{
							num2 = 149;
							continue;
						}
						goto IL_5117;
					case 287:
						goto IL_3943;
					case 288:
						return;
					case 289:
						goto IL_2BD8;
					case 290:
						sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
						num2 = 17;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 128;
							continue;
						}
						continue;
					case 291:
						num3 = 124 + 113;
						num2 = 542;
						continue;
					case 292:
						if (sdwn9hocwBVuZe0IsL.kfkY6lTjH7(intPtr, 4, 4, ref num8) == 0)
						{
							num2 = 210;
							continue;
						}
						goto IL_300B;
					case 293:
					{
						bool flag = true;
						num2 = 113;
						continue;
					}
					case 294:
						array3[num5 + 5] = array10[5];
						num2 = 129;
						continue;
					case 295:
					{
						bool flag = false;
						num2 = 532;
						continue;
					}
					case 296:
						array11[2] = 99;
						num2 = 638;
						continue;
					case 297:
						num3 = 190 - 63;
						num2 = 327;
						continue;
					case 298:
						num17 = 0U;
						num2 = 514;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 69;
							continue;
						}
						continue;
					case 299:
						num4 = 112 + 46;
						num2 = 481;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 154;
							continue;
						}
						continue;
					case 300:
						goto IL_203D;
					case 301:
						num4 = 108 - 45;
						num2 = 45;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 567;
							continue;
						}
						continue;
					case 302:
						if (array13.Length != 0)
						{
							goto IL_1308;
						}
						num2 = 55;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 303:
						array10 = sdwn9hocwBVuZe0IsL.Io7SUgeZdmkO97TgOU3(num12);
						num2 = 551;
						continue;
					case 304:
					{
						byte[] array17 = new byte[40];
						sdwn9hocwBVuZe0IsL.OHnouCQ3EPpQkPJBPHA(array17, fieldof(<PrivateImplementationDetails>{00DEC971-B8D4-43E3-9526-3C9CB75F1393}.0E448EF5E5E60630BDDB19388CB6378436E3C65D03DD66DA7C6EBFF563BD857A).FieldHandle);
						array18 = array17;
						num2 = 289;
						continue;
					}
					case 305:
						num36 = 0L;
						num2 = 480;
						continue;
					case 306:
					{
						uint num24;
						num37 += num24;
						num2 = 522;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 493;
							continue;
						}
						continue;
					}
					case 307:
						array2[2] = 234 - 78;
						num2 = 216;
						continue;
					case 308:
						array7[7] = array13[3];
						num2 = 516;
						continue;
					case 309:
						array8[1] = 101;
						num2 = 8;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 104;
							continue;
						}
						continue;
					case 310:
					{
						IntPtr intPtr5;
						array9 = sdwn9hocwBVuZe0IsL.hGiFBMewVG7RMY5H2rQ(intPtr5.ToInt32());
						num2 = 251;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 520;
							continue;
						}
						continue;
					}
					case 311:
						num25 = 255U;
						num2 = 345;
						continue;
					case 312:
					{
						IntPtr intPtr4;
						string text2;
						intPtr7 = sdwn9hocwBVuZe0IsL.UiDn3xetknskpp8DQMD((sdwn9hocwBVuZe0IsL.Jr52UqM2IsP0CX1iOrf)sdwn9hocwBVuZe0IsL.ifxG6meWJAWC1yDMXjs(sdwn9hocwBVuZe0IsL.QgfYrwI9HI(intPtr4, text2), sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL.Jr52UqM2IsP0CX1iOrf).TypeHandle)));
						num2 = 281;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 305;
							continue;
						}
						continue;
					}
					case 313:
						array4 = null;
						num2 = 143;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 649;
							continue;
						}
						continue;
					case 314:
						array[3] = 44 + 7;
						num2 = 34;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 238;
							continue;
						}
						continue;
					case 315:
						array2[10] = 173 - 57;
						num2 = 50;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 156;
							continue;
						}
						continue;
					case 316:
						array[7] = 48 + 4;
						num2 = 85;
						continue;
					case 317:
						num3 = 193 - 64;
						num2 = 160;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 215;
							continue;
						}
						continue;
					case 318:
						array[13] = 41 + 42;
						num2 = 230;
						continue;
					case 319:
						return;
					case 320:
						array2[0] = 174 - 58;
						num2 = 278;
						continue;
					case 321:
						num38++;
						num2 = 409;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 393;
							continue;
						}
						continue;
					case 322:
						array11[3] = 106;
						num2 = 274;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 109;
							continue;
						}
						continue;
					case 323:
						array[26] = (byte)num3;
						num2 = 629;
						continue;
					case 324:
						array2[3] = (byte)num4;
						num2 = 6;
						continue;
					case 325:
						goto IL_3113;
					case 326:
						goto IL_340E;
					case 327:
						array[25] = (byte)num3;
						num2 = 38;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 25;
							continue;
						}
						continue;
					case 328:
						sdwn9hocwBVuZe0IsL.vFXYVfycYb = sdwn9hocwBVuZe0IsL.KGfdodeRpp5M8anOQGi(sdwn9hocwBVuZe0IsL.yqoY1uWEql);
						num2 = 401;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 279;
							continue;
						}
						continue;
					case 329:
						if (!sdwn9hocwBVuZe0IsL.nmlsmVBDLKdcTBFeLAm(sdwn9hocwBVuZe0IsL.ndMbA6B76kJiamrFDRG("System.Reflection.ReflectionContext", false), null))
						{
							num2 = 147;
							continue;
						}
						goto IL_3AA7;
					case 330:
						array[31] = 190 + 13;
						num2 = 68;
						continue;
					case 331:
					{
						sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA fRw86wMffvVYO8Ce8dA2 = default(sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA);
						num2 = 493;
						continue;
					}
					case 332:
						goto IL_5CE8;
					case 333:
						array2[12] = (byte)num4;
						num2 = 600;
						continue;
					case 334:
						goto IL_2E14;
					case 335:
						array3 = array18;
						num2 = 581;
						continue;
					case 336:
						array[10] = (byte)num3;
						num2 = 576;
						continue;
					case 337:
						array[15] = (byte)num3;
						num2 = 19;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 16;
							continue;
						}
						continue;
					case 338:
						num4 = 65 + 103;
						num2 = 618;
						continue;
					case 339:
						num4 = 12 + 83;
						num2 = 324;
						continue;
					case 340:
						array2[5] = (byte)num4;
						num2 = 361;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 205;
							continue;
						}
						continue;
					case 341:
						num39++;
						num2 = 413;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 368;
							continue;
						}
						continue;
					case 342:
						goto IL_4869;
					case 343:
						num4 = 103 + 39;
						num2 = 591;
						continue;
					case 344:
						array2[9] = (byte)num4;
						num2 = 7;
						continue;
					case 345:
						num28 = 0;
						num2 = 269;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 243;
							continue;
						}
						continue;
					case 346:
						array[13] = (byte)num3;
						num2 = 523;
						continue;
					case 347:
						goto IL_3F2F;
					case 348:
						array[30] = 249 - 83;
						num2 = 79;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 211;
							continue;
						}
						continue;
					case 349:
						if (sdwn9hocwBVuZe0IsL.F3jqNVepVy6F2QeWKi4(sdwn9hocwBVuZe0IsL.hgkh8Qeai0cY7tT4mcB(sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL).TypeHandle).Assembly)).Length == 2)
						{
							num2 = 452;
							continue;
						}
						goto IL_480C;
					case 350:
					{
						uint num24;
						num37 += num24;
						num2 = 268;
						continue;
					}
					case 351:
						num3 = 252 - 84;
						num2 = 531;
						continue;
					case 352:
						num3 = 103 + 33;
						num2 = 515;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 621;
							continue;
						}
						continue;
					case 353:
						goto IL_4B30;
					case 354:
						num40++;
						num2 = 131;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 240;
							continue;
						}
						continue;
					case 355:
						sdwn9hocwBVuZe0IsL.Q8lv7eBWHN4MEpxyc3V(new IntPtr((void*)(&num6)), 0, 0L);
						num2 = 6;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 64;
							continue;
						}
						continue;
					case 356:
						array2[5] = 211 - 70;
						num2 = 439;
						continue;
					case 357:
						array11[10] = 108;
						num2 = 205;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 9;
							continue;
						}
						continue;
					case 358:
						array[18] = 191 - 63;
						num2 = 154;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 563;
							continue;
						}
						continue;
					case 359:
						array3[num5] = array9[0];
						num2 = 477;
						continue;
					case 360:
						num4 = 136 + 32;
						num2 = 138;
						continue;
					case 361:
						array2[5] = 167 - 55;
						num2 = 356;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 168;
							continue;
						}
						continue;
					case 362:
						num38 = 0;
						num2 = 623;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 453;
							continue;
						}
						continue;
					case 363:
					{
						int num41;
						sdwn9hocwBVuZe0IsL.kfkY6lTjH7(new IntPtr(num36), sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs(), num41, ref num41);
						num2 = 122;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 143;
							continue;
						}
						continue;
					}
					case 364:
						goto IL_45CF;
					case 365:
						goto IL_3496;
					case 366:
						array[8] = 47 + 95;
						num2 = 222;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 184;
							continue;
						}
						continue;
					case 367:
					{
						IntPtr intPtr5;
						array9 = sdwn9hocwBVuZe0IsL.Io7SUgeZdmkO97TgOU3(intPtr5.ToInt64());
						num2 = 303;
						continue;
					}
					case 368:
						goto IL_2811;
					case 369:
						num27 = 0;
						num2 = 396;
						continue;
					case 370:
						num3 = 124 + 89;
						num2 = 31;
						continue;
					case 371:
						num35 = array15.Length / 4;
						num2 = 90;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 40;
							continue;
						}
						continue;
					case 372:
					{
						byte[] array19 = sdwn9hocwBVuZe0IsL.X8ZSdOehycuDZmVCmrk(mcrqrIMElFcjUmhrYwF, num42);
						num2 = 331;
						continue;
					}
					case 373:
						array2[12] = 166 - 55;
						num2 = 226;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 86;
							continue;
						}
						continue;
					case 374:
						sdwn9hocwBVuZe0IsL.YBSYPhtPcy = new sdwn9hocwBVuZe0IsL.K0CWWhMlGjd9LcqDtVJ(sdwn9hocwBVuZe0IsL.O8wAQ1EkQ);
						num2 = 15;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 198;
							continue;
						}
						continue;
					case 375:
						array[20] = (byte)num3;
						num2 = 200;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 168;
							continue;
						}
						continue;
					case 376:
						num5 = 18;
						num2 = 428;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 95;
							continue;
						}
						continue;
					case 377:
						sdwn9hocwBVuZe0IsL.kfkY6lTjH7(intPtr6, num43 * 4, num8, ref num8);
						num2 = 59;
						continue;
					case 378:
						array[4] = 134 + 32;
						num2 = 492;
						continue;
					case 379:
						goto IL_18B2;
					case 380:
					{
						byte[] array12;
						num44 = array12.Length / 8;
						num2 = 185;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 189;
							continue;
						}
						continue;
					}
					case 381:
						goto IL_5DF3;
					case 382:
						array[25] = 161 + 83;
						num2 = 79;
						continue;
					case 383:
						num3 = 159 - 53;
						num2 = 8;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 30;
							continue;
						}
						continue;
					case 384:
					{
						int num41;
						sdwn9hocwBVuZe0IsL.kfkY6lTjH7(new IntPtr(num36), sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs(), 64, ref num41);
						num2 = 29;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 112;
							continue;
						}
						continue;
					}
					case 385:
					{
						byte[] array5;
						array15 = array5;
						num2 = 333;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 624;
							continue;
						}
						continue;
					}
					case 386:
						array3[num16 + 1] = array4[1];
						num2 = 282;
						continue;
					case 387:
						array[27] = 97 + 37;
						num2 = 261;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 59;
							continue;
						}
						continue;
					case 388:
						goto IL_1004;
					case 389:
						if (sdwn9hocwBVuZe0IsL.K8VY81bt0R)
						{
							num2 = 388;
							continue;
						}
						goto IL_1E40;
					case 390:
						array3[num5 + 3] = array9[3];
						num2 = 582;
						continue;
					case 391:
						array[19] = (byte)num3;
						num2 = 243;
						continue;
					case 392:
						num4 = 200 - 66;
						num2 = 344;
						continue;
					case 393:
						array7[13] = array13[6];
						num2 = 267;
						continue;
					case 394:
						array3[num5 + 1] = array10[1];
						num2 = 631;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 485;
							continue;
						}
						continue;
					case 395:
						array[23] = (byte)num3;
						num2 = 123;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 179;
							continue;
						}
						continue;
					case 396:
						goto IL_279F;
					case 397:
						goto IL_3970;
					case 398:
						goto IL_2780;
					case 399:
						array[21] = 8 + 86;
						num2 = 163;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 234;
							continue;
						}
						continue;
					case 400:
						array10 = null;
						num2 = 313;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 163;
							continue;
						}
						continue;
					case 401:
						goto IL_0E16;
					case 402:
						array[15] = (byte)num3;
						num2 = 26;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 317;
							continue;
						}
						continue;
					case 403:
						array3[num16 + 1] = array9[1];
						num2 = 651;
						continue;
					case 404:
						num3 = 39 + 59;
						num2 = 550;
						continue;
					case 405:
						array[5] = 99 + 60;
						num2 = 351;
						continue;
					case 406:
						num3 = 155 - 51;
						num2 = 564;
						continue;
					case 407:
						num12 = 0L;
						num2 = 228;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 175;
							continue;
						}
						continue;
					case 408:
						array[17] = 219 - 73;
						num2 = 519;
						continue;
					case 409:
						goto IL_1E1D;
					case 410:
						sdwn9hocwBVuZe0IsL.q0orPgB5JZTCdkyAsx9(new IntPtr((void*)(&num6)), 0);
						num2 = 78;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 191;
							continue;
						}
						continue;
					case 411:
						array[0] = (byte)num3;
						num2 = 662;
						continue;
					case 412:
						num3 = 33 + 94;
						num2 = 363;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 489;
							continue;
						}
						continue;
					case 413:
						goto IL_615D;
					case 414:
						array[29] = (byte)num3;
						num2 = 478;
						continue;
					case 415:
						num7 = sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
						num2 = 16;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 17;
							continue;
						}
						continue;
					case 416:
					{
						uint num22 = 4059231220U;
						num2 = 479;
						continue;
					}
					case 417:
						goto IL_279F;
					case 418:
					{
						IntPtr intPtr5 = sdwn9hocwBVuZe0IsL.R333Tnenjeh9fWeyOND(sdwn9hocwBVuZe0IsL.YBSYPhtPcy);
						num2 = 249;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 407;
							continue;
						}
						continue;
					}
					case 419:
						goto IL_3BA8;
					case 420:
						num3 = 76 + 4;
						num2 = 197;
						continue;
					case 421:
						array7[11] = array13[5];
						num2 = 393;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 257;
							continue;
						}
						continue;
					case 422:
						num18++;
						num2 = 610;
						continue;
					case 423:
						array2[1] = (byte)num4;
						num2 = 301;
						continue;
					case 424:
						array2[2] = (byte)num4;
						num2 = 231;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 473;
							continue;
						}
						continue;
					case 425:
						array2[15] = (byte)num4;
						num2 = 168;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 40;
							continue;
						}
						continue;
					case 426:
						array[24] = 63 + 23;
						num2 = 494;
						continue;
					case 427:
						array2[6] = (byte)num4;
						num2 = 120;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 35;
							continue;
						}
						continue;
					case 428:
						array3[num5] = array10[0];
						num2 = 394;
						continue;
					case 429:
						array3[num16 + 2] = array10[2];
						num2 = 530;
						continue;
					case 430:
						num16 = 16;
						num2 = 48;
						continue;
					case 431:
						array[26] = 30 + 121;
						num2 = 252;
						continue;
					case 432:
						array[3] = 31 + 18;
						num2 = 314;
						continue;
					case 433:
						array[19] = 101 + 75;
						num2 = 406;
						continue;
					case 434:
						array8[5] = 116;
						num2 = 653;
						continue;
					case 435:
						goto IL_11BF;
					case 436:
						num3 = 161 - 53;
						num2 = 140;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 247;
							continue;
						}
						continue;
					case 437:
						array2[15] = 38 + 121;
						num2 = 237;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 251;
							continue;
						}
						continue;
					case 438:
						array[11] = 83 + 108;
						num2 = 79;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 580;
							continue;
						}
						continue;
					case 439:
						array2[5] = 194 + 12;
						num2 = 17;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 67;
							continue;
						}
						continue;
					case 440:
						array8[3] = 74;
						num2 = 91;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 25;
							continue;
						}
						continue;
					case 441:
						goto IL_60A7;
					case 442:
					{
						uint num24 = 0U;
						num2 = 33;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 298;
							continue;
						}
						continue;
					}
					case 443:
						num3 = 200 - 66;
						num2 = 86;
						continue;
					case 444:
						array2[0] = 145 - 48;
						num2 = 182;
						continue;
					case 445:
						array3[num5] = array4[0];
						num2 = 528;
						continue;
					case 446:
						array[22] = (byte)num3;
						num2 = 20;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 265;
							continue;
						}
						continue;
					case 447:
						array[5] = (byte)num3;
						num2 = 183;
						continue;
					case 448:
						goto IL_2BD8;
					case 449:
						goto IL_2EC7;
					case 450:
						goto IL_5770;
					case 451:
						sdwn9hocwBVuZe0IsL.ourYmRHfMP(intPtr3, intPtr8, sdwn9hocwBVuZe0IsL.hGiFBMewVG7RMY5H2rQ(sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF)), 4U, out zero);
						num2 = 456;
						continue;
					case 452:
						if (sdwn9hocwBVuZe0IsL.AhsQsKedAUaWx5O73vT(sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL).TypeHandle).Assembly) != null)
						{
							goto IL_3943;
						}
						num2 = 95;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 22;
							continue;
						}
						continue;
					case 453:
						goto IL_300B;
					case 454:
						array2 = new byte[16];
						num2 = 444;
						continue;
					case 455:
						try
						{
							enumerator = sdwn9hocwBVuZe0IsL.pJPGysBK5rm4P6gKahV(sdwn9hocwBVuZe0IsL.BAF30YBC93yXgHK0cYx(process));
							int num45 = 1;
							if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
							{
								num45 = 1;
							}
							switch (num45)
							{
							case 1:
								try
								{
									for (;;)
									{
										if (sdwn9hocwBVuZe0IsL.gd4ZMoe4EVg4wQIfHqe(enumerator))
										{
											goto IL_1B16;
										}
										int num46 = 1;
										if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
										{
											num46 = 1;
										}
										for (;;)
										{
											IL_1AC1:
											switch (num46)
											{
											case 1:
												goto IL_1B6D;
											case 2:
												goto IL_1B16;
											case 3:
												num30 = 0;
												num46 = 5;
												continue;
											case 4:
												if (intPtr2.ToInt64() == sdwn9hocwBVuZe0IsL.yqoY1uWEql)
												{
													num46 = 3;
													continue;
												}
												break;
											case 5:
												goto IL_1B33;
											}
											break;
										}
										continue;
										IL_1B16:
										intPtr2 = sdwn9hocwBVuZe0IsL.fUMoR1BarEYFYHARIpI((ProcessModule)sdwn9hocwBVuZe0IsL.wgGkeABZsoCmUcVnuHt(enumerator));
										num46 = 4;
										goto IL_1AC1;
									}
									IL_1B33:
									IL_1B6D:;
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									int num47 = 1;
									if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
									{
										num47 = 0;
									}
									for (;;)
									{
										switch (num47)
										{
										default:
											sdwn9hocwBVuZe0IsL.s3UL5memStMP0xeBqVX(disposable);
											num47 = 2;
											break;
										case 1:
											if (disposable == null)
											{
												goto IL_1BE1;
											}
											num47 = 0;
											if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
											{
												num47 = 0;
											}
											break;
										case 2:
											goto IL_1BE1;
										}
									}
									IL_1BE1:;
								}
								break;
							}
							goto IL_4B30;
						}
						catch
						{
							int num48 = 0;
							if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
							{
								num48 = 0;
							}
							switch (num48)
							{
							default:
								goto IL_4B30;
							}
						}
						goto IL_1C3D;
					case 456:
						goto IL_27EA;
					case 457:
						num3 = 35 + 24;
						num2 = 648;
						continue;
					case 458:
						array3[num5 + 2] = array4[2];
						num2 = 465;
						continue;
					case 459:
						sdwn9hocwBVuZe0IsL.bThYZMo80t = new Hashtable(sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF) + 1);
						num2 = 201;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 276;
							continue;
						}
						continue;
					case 460:
						array2[12] = (byte)num4;
						num2 = 392;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 561;
							continue;
						}
						continue;
					case 461:
						array[12] = (byte)num3;
						num2 = 212;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 517;
							continue;
						}
						continue;
					case 462:
						array11[8] = 108;
						num2 = 39;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 262;
							continue;
						}
						continue;
					case 463:
						sdwn9hocwBVuZe0IsL.DTM3PaesamGskiR7JUf(array13, 0, array13.Length);
						num2 = 266;
						continue;
					case 464:
						goto IL_3B95;
					case 465:
						array3[num5 + 3] = array4[3];
						num2 = 202;
						continue;
					case 466:
						array3[num5 + 2] = array9[2];
						num2 = 390;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 269;
							continue;
						}
						continue;
					case 467:
						num4 = 48 + 4;
						num2 = 660;
						continue;
					case 468:
						sdwn9hocwBVuZe0IsL.CGsYnJ67gx = intPtr2.ToInt32();
						num2 = 645;
						continue;
					case 469:
						num3 = 251 - 83;
						num2 = 11;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 470:
						num3 = 76 + 120;
						num2 = 450;
						continue;
					case 471:
						goto IL_3AA7;
					case 472:
						num3 = 141 - 47;
						num2 = 446;
						continue;
					case 473:
						array2[2] = 27 + 25;
						num2 = 27;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 13;
							continue;
						}
						continue;
					case 474:
						goto IL_2B2A;
					case 475:
						array[7] = 101 + 79;
						num2 = 151;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 125;
							continue;
						}
						continue;
					case 476:
						array[23] = 158 - 52;
						num2 = 57;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 19;
							continue;
						}
						continue;
					case 477:
						array3[num5 + 1] = array9[1];
						num2 = 28;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 466;
							continue;
						}
						continue;
					case 478:
						array[29] = 114 + 58;
						num2 = 217;
						continue;
					case 479:
						num6 = 0L;
						num2 = 410;
						continue;
					case 480:
						if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() == 4)
						{
							num2 = 607;
							continue;
						}
						goto IL_22E1;
					case 481:
						array2[4] = (byte)num4;
						num2 = 343;
						continue;
					case 482:
					{
						IntPtr intPtr4 = IntPtr.Zero;
						num2 = 116;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 108;
							continue;
						}
						continue;
					}
					case 483:
						array2[6] = (byte)num4;
						num2 = 232;
						continue;
					case 484:
						array[22] = 68 + 65;
						num2 = 472;
						continue;
					case 485:
						array[2] = 152 + 1;
						num2 = 103;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 95;
							continue;
						}
						continue;
					case 486:
						array[11] = 129 - 50;
						num2 = 105;
						continue;
					case 487:
						array[21] = 166 - 55;
						num2 = 594;
						continue;
					case 488:
						try
						{
							object obj2 = sdwn9hocwBVuZe0IsL.sVb0wMeKEiBZw8NqvMA(sdwn9hocwBVuZe0IsL.KLcFtveCY4dvy04d8Fa(sdwn9hocwBVuZe0IsL.YTHsGmeDtWQWEf2DvJG(sdwn9hocwBVuZe0IsL.K3JCrbe77g2py7yZggm(sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL).TypeHandle).Assembly))).GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), sdwn9hocwBVuZe0IsL.YTHsGmeDtWQWEf2DvJG(sdwn9hocwBVuZe0IsL.K3JCrbe77g2py7yZggm(sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL).TypeHandle).Assembly)));
							int num49 = 17;
							for (;;)
							{
								int num50;
								uint num53;
								MemoryStream memoryStream2;
								switch (num49)
								{
								case 0:
									goto IL_5A8E;
								case 1:
									goto IL_5AC2;
								case 2:
									goto IL_5C7E;
								case 3:
									if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() != 4)
									{
										goto IL_5A5C;
									}
									num50 = 7;
									break;
								case 4:
									try
									{
										byte[] array20;
										if ((array16 = array20) == null)
										{
											goto IL_5BA9;
										}
										int num51 = 4;
										byte* ptr;
										for (;;)
										{
											IL_5B3F:
											switch (num51)
											{
											case 1:
												goto IL_5BFD;
											case 2:
												goto IL_5B61;
											case 3:
												goto IL_5BA9;
											case 4:
												if (array16.Length == 0)
												{
													int num52 = 3;
													num51 = num52;
													continue;
												}
												goto IL_5BFD;
											case 5:
												goto IL_5B61;
											}
											break;
											IL_5B61:
											sdwn9hocwBVuZe0IsL.YBSYPhtPcy(new IntPtr((void*)ptr), new IntPtr((void*)ptr), new IntPtr((void*)ptr), 216669565U, new IntPtr((void*)ptr), ref num53);
											num51 = 0;
											if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
											{
												num51 = 0;
												continue;
											}
											continue;
											IL_5BFD:
											ptr = &array16[0];
											num51 = 1;
											if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
											{
												num51 = 2;
											}
										}
										goto IL_5C7E;
										IL_5BA9:
										ptr = null;
										num51 = 1;
										if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
										{
											num51 = 5;
											goto IL_5B3F;
										}
										goto IL_5B3F;
									}
									finally
									{
										array16 = null;
										int num54 = 0;
										if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
										{
											num54 = 0;
										}
										switch (num54)
										{
										}
									}
									goto IL_5C71;
								case 5:
									sdwn9hocwBVuZe0IsL.kO66GQeeo0dvUDuELlE(memoryStream2, new byte[sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs()], 0, sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs());
									num49 = 12;
									continue;
								case 6:
									goto IL_5AEB;
								case 7:
									sdwn9hocwBVuZe0IsL.kO66GQeeo0dvUDuELlE(memoryStream2, sdwn9hocwBVuZe0IsL.hGiFBMewVG7RMY5H2rQ(sdwn9hocwBVuZe0IsL.uT6YCBSbyl.ToInt32()), 0, 4);
									num49 = 13;
									continue;
								case 8:
									sdwn9hocwBVuZe0IsL.qtF5O3e9A9STqlf4Xj7(memoryStream2);
									num49 = 9;
									continue;
								case 9:
									goto IL_5C71;
								case 10:
								{
									byte[] array20 = sdwn9hocwBVuZe0IsL.O2spJveXJMoW6IZWxnM(memoryStream2);
									num49 = 8;
									continue;
								}
								case 11:
									sdwn9hocwBVuZe0IsL.uT6YCBSbyl = (IntPtr)sdwn9hocwBVuZe0IsL.sVb0wMeKEiBZw8NqvMA(obj2.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), obj2);
									num49 = 2;
									if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
									{
										num49 = 14;
										continue;
									}
									continue;
								case 12:
									sdwn9hocwBVuZe0IsL.PrCen7e2rQhm9FsvsPd(memoryStream2, 0L);
									num49 = 10;
									continue;
								case 13:
									goto IL_5AEB;
								case 14:
									goto IL_597B;
								case 15:
									sdwn9hocwBVuZe0IsL.uT6YCBSbyl = (IntPtr)obj2;
									num49 = 0;
									if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
									{
										num49 = 1;
										continue;
									}
									continue;
								case 16:
									goto IL_5A5C;
								case 17:
									if (obj2 is IntPtr)
									{
										num49 = 15;
										continue;
									}
									goto IL_5AC2;
								default:
									goto IL_5A8E;
								}
								IL_58F2:
								num49 = num50;
								continue;
								IL_597B:
								memoryStream2 = new MemoryStream();
								num49 = 0;
								if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
								{
									num49 = 0;
									continue;
								}
								continue;
								IL_5AC2:
								if (sdwn9hocwBVuZe0IsL.qeK7fOBzMi5Lu01n5xb(obj2.GetType().ToString(), "System.Reflection.RuntimeModule"))
								{
									num50 = 11;
									goto IL_58F2;
								}
								goto IL_597B;
								IL_5A5C:
								sdwn9hocwBVuZe0IsL.kO66GQeeo0dvUDuELlE(memoryStream2, sdwn9hocwBVuZe0IsL.Io7SUgeZdmkO97TgOU3(sdwn9hocwBVuZe0IsL.uT6YCBSbyl.ToInt64()), 0, 8);
								num49 = 3;
								if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
								{
									num49 = 6;
									continue;
								}
								continue;
								IL_5A8E:
								sdwn9hocwBVuZe0IsL.kO66GQeeo0dvUDuELlE(memoryStream2, new byte[sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs()], 0, sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs());
								num49 = 3;
								continue;
								IL_5C71:
								num53 = 0U;
								num49 = 4;
								continue;
								IL_5AEB:
								sdwn9hocwBVuZe0IsL.kO66GQeeo0dvUDuELlE(memoryStream2, new byte[sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs()], 0, sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs());
								num50 = 5;
								goto IL_58F2;
							}
							IL_5C7E:
							goto IL_1438;
						}
						catch
						{
							int num55 = 0;
							if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
							{
								num55 = 0;
							}
							switch (num55)
							{
							default:
								goto IL_1438;
							}
						}
						goto IL_5CCF;
					case 489:
						array[2] = (byte)num3;
						num2 = 499;
						continue;
					case 490:
						num3 = 36 + 26;
						num2 = 259;
						continue;
					case 491:
						array3[num5 + 5] = array9[5];
						num2 = 612;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 639;
							continue;
						}
						continue;
					case 492:
						num3 = 11 + 49;
						num2 = 364;
						continue;
					case 493:
					{
						sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA fRw86wMffvVYO8Ce8dA2;
						byte[] array19;
						fRw86wMffvVYO8Ce8dA2.coEMOgfFUM = array19;
						num2 = 406;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 602;
							continue;
						}
						continue;
					}
					case 494:
						goto IL_3E47;
					case 495:
						goto IL_185D;
					case 496:
						array11[0] = 99;
						num2 = 163;
						continue;
					case 497:
						num3 = 165 - 55;
						num2 = 220;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 221;
							continue;
						}
						continue;
					case 498:
						goto IL_4199;
					case 499:
						array[2] = 25 + 18;
						num2 = 485;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 426;
							continue;
						}
						continue;
					case 500:
						array14[num26] = (byte)(num29 & 255U);
						num2 = 1;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 172;
							continue;
						}
						continue;
					case 501:
						array[18] = (byte)num3;
						num2 = 223;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 204;
							continue;
						}
						continue;
					case 502:
						num4 = 151 - 50;
						num2 = 201;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 146;
							continue;
						}
						continue;
					case 503:
						num3 = 228 - 76;
						num2 = 414;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 368;
							continue;
						}
						continue;
					case 504:
						goto IL_2391;
					case 505:
						sdwn9hocwBVuZe0IsL.DTM3PaesamGskiR7JUf(array6, 0, array6.Length);
						num2 = 171;
						continue;
					case 506:
						num3 = 92 + 32;
						num2 = 97;
						continue;
					case 507:
						goto IL_17B7;
					case 508:
						goto IL_2C9F;
					case 509:
						goto IL_3E6A;
					case 510:
						array[26] = (byte)num3;
						num2 = 118;
						continue;
					case 511:
						num4 = 60 - 44;
						num2 = 207;
						continue;
					case 512:
						array[20] = (byte)num3;
						num2 = 74;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 82;
							continue;
						}
						continue;
					case 513:
						goto IL_3901;
					case 514:
						if (num33 <= 0)
						{
							goto IL_5157;
						}
						num2 = 352;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 637;
							continue;
						}
						continue;
					case 515:
						array2[3] = 171 - 57;
						num2 = 194;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 187;
							continue;
						}
						continue;
					case 516:
						array7[9] = array13[4];
						num2 = 421;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 282;
							continue;
						}
						continue;
					case 517:
						num3 = 19 + 0;
						num2 = 635;
						continue;
					case 518:
					{
						int num41 = 0;
						num2 = 263;
						continue;
					}
					case 519:
						array[17] = 151 - 68;
						num2 = 436;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 4;
							continue;
						}
						continue;
					case 520:
						array10 = sdwn9hocwBVuZe0IsL.hGiFBMewVG7RMY5H2rQ(sdwn9hocwBVuZe0IsL.KGfdodeRpp5M8anOQGi(num12));
						num2 = 509;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 234;
							continue;
						}
						continue;
					case 521:
						goto IL_5FEE;
					case 522:
						num17 = (uint)(((int)array15[(int)(num19 + 3U)] << 24) | ((int)array15[(int)(num19 + 2U)] << 16) | ((int)array15[(int)(num19 + 1U)] << 8) | (int)array15[(int)num19]);
						num2 = 620;
						continue;
					case 523:
						array[13] = 43 + 86;
						num2 = 96;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 227;
							continue;
						}
						continue;
					case 524:
						try
						{
							sdwn9hocwBVuZe0IsL.jtsYaqmqlL = (sdwn9hocwBVuZe0IsL.K0CWWhMlGjd9LcqDtVJ)sdwn9hocwBVuZe0IsL.ifxG6meWJAWC1yDMXjs(new IntPtr(num12), sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL.K0CWWhMlGjd9LcqDtVJ).TypeHandle));
							int num56 = 0;
							if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
							{
								num56 = 0;
							}
							switch (num56)
							{
							default:
								goto IL_2DD0;
							}
						}
						catch
						{
							int num57 = 0;
							if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
							{
								num57 = 0;
							}
							switch (num57)
							{
							default:
								try
								{
									Delegate @delegate = sdwn9hocwBVuZe0IsL.ifxG6meWJAWC1yDMXjs(new IntPtr(num12), sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL.K0CWWhMlGjd9LcqDtVJ).TypeHandle));
									int num58 = 1;
									if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
									{
										num58 = 0;
									}
									for (;;)
									{
										switch (num58)
										{
										case 1:
											sdwn9hocwBVuZe0IsL.jtsYaqmqlL = (sdwn9hocwBVuZe0IsL.K0CWWhMlGjd9LcqDtVJ)sdwn9hocwBVuZe0IsL.x6BvDWeVgaCl6NIoCsf(sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL.K0CWWhMlGjd9LcqDtVJ).TypeHandle), sdwn9hocwBVuZe0IsL.tbCD4be1gBOsWCMtiNg(@delegate));
											num58 = 0;
											if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
											{
												num58 = 0;
												continue;
											}
											continue;
										}
										break;
									}
								}
								catch
								{
									int num59 = 0;
									if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
									{
										num59 = 0;
									}
									switch (num59)
									{
									}
								}
								break;
							case 1:
								break;
							}
							goto IL_2DD0;
						}
						goto IL_0D83;
					case 525:
						array2[7] = 246 - 82;
						num2 = 46;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 75;
							continue;
						}
						continue;
					case 526:
						array14[num26 + 2] = (byte)((num29 & 16711680U) >> 16);
						num2 = 326;
						continue;
					case 527:
						num3 = 150 - 50;
						num2 = 236;
						continue;
					case 528:
						array3[num5 + 1] = array4[1];
						num2 = 458;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 31;
							continue;
						}
						continue;
					case 529:
						array11[7] = 116;
						num2 = 293;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 633;
							continue;
						}
						continue;
					case 530:
						goto IL_4E26;
					case 531:
						goto IL_30F7;
					case 532:
						goto IL_21B8;
					case 533:
						array11 = new byte[10];
						num2 = 94;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 496;
							continue;
						}
						continue;
					case 534:
						array[1] = 55 + 10;
						num2 = 231;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 200;
							continue;
						}
						continue;
					case 535:
						array[12] = 25 + 62;
						num2 = 352;
						continue;
					case 536:
						num5 = 30;
						num2 = 359;
						continue;
					case 537:
						num12 = (long)sdwn9hocwBVuZe0IsL.tGJE7Ke8t0nxYGsFxfu(new IntPtr(num36));
						num2 = 435;
						continue;
					case 538:
						array[4] = 177 - 59;
						num2 = 378;
						continue;
					case 539:
						goto IL_5CCF;
					case 540:
						goto IL_0DAB;
					case 541:
						num4 = 108 + 105;
						num2 = 148;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 333;
							continue;
						}
						continue;
					case 542:
						array[11] = (byte)num3;
						num2 = 383;
						continue;
					case 543:
						array3[num16] = array4[0];
						num2 = 386;
						continue;
					case 544:
						num21 = sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
						num2 = 661;
						continue;
					case 545:
						array[31] = 112 + 43;
						num2 = 584;
						continue;
					case 546:
						goto IL_0F0F;
					case 547:
						sdwn9hocwBVuZe0IsL.yqoY1uWEql = intPtr2.ToInt64();
						num2 = 43;
						continue;
					case 548:
						array7[5] = array13[2];
						num2 = 308;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 45;
							continue;
						}
						continue;
					case 549:
						sdwn9hocwBVuZe0IsL.PrCen7e2rQhm9FsvsPd(sdwn9hocwBVuZe0IsL.jURbFbelkILPa80E2mT(mcrqrIMElFcjUmhrYwF), 0L);
						num2 = 598;
						continue;
					case 550:
						array[27] = (byte)num3;
						num2 = 387;
						continue;
					case 551:
						goto IL_3E6A;
					case 552:
						array11[7] = 100;
						num2 = 313;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 462;
							continue;
						}
						continue;
					case 553:
						return;
					case 554:
						goto IL_145C;
					case 555:
						num3 = 240 - 80;
						num2 = 402;
						continue;
					case 556:
						sdwn9hocwBVuZe0IsL.Jg7GoqBifc14fetnAkM(new IntPtr((void*)(&num6)), 0, 0);
						num2 = 346;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 355;
							continue;
						}
						continue;
					case 557:
						array3[num5 + 7] = array4[7];
						num2 = 264;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 376;
							continue;
						}
						continue;
					case 558:
						array[3] = 209 - 112;
						num2 = 652;
						continue;
					case 559:
						array2[8] = 250 - 83;
						num2 = 28;
						continue;
					case 560:
						array11[1] = 115;
						num2 = 296;
						continue;
					case 561:
						array2[13] = 217 - 72;
						num2 = 502;
						continue;
					case 562:
						sdwn9hocwBVuZe0IsL.RdKYjGBxn6 = intPtr2.ToInt64();
						num2 = 99;
						continue;
					case 563:
						goto IL_3999;
					case 564:
						array[19] = (byte)num3;
						num2 = 22;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 14;
							continue;
						}
						continue;
					case 565:
						array[6] = 94 - 90;
						num2 = 513;
						continue;
					case 566:
						array[21] = (byte)num3;
						num2 = 487;
						continue;
					case 567:
						array2[1] = (byte)num4;
						num2 = 307;
						continue;
					case 568:
						array2[8] = 241 - 80;
						num2 = 511;
						continue;
					case 569:
						goto IL_35CF;
					case 570:
						num60 = 0;
						num2 = 495;
						continue;
					case 571:
					{
						byte[] array12 = array14;
						num2 = 380;
						continue;
					}
					case 572:
						if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() != 4)
						{
							num2 = 304;
							continue;
						}
						goto IL_2211;
					case 573:
						array[2] = 70 + 47;
						num2 = 412;
						continue;
					case 574:
						num3 = 48 + 112;
						num2 = 336;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 302;
							continue;
						}
						continue;
					case 575:
						array[11] = (byte)num3;
						num2 = 245;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 486;
							continue;
						}
						continue;
					case 576:
						array[10] = 183 - 61;
						num2 = 208;
						continue;
					case 577:
						goto IL_2484;
					case 578:
						array3[num16 + 1] = array10[1];
						num2 = 429;
						continue;
					case 579:
						num3 = 28 + 36;
						num2 = 109;
						continue;
					case 580:
						num3 = 87 + 12;
						num2 = 540;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 575;
							continue;
						}
						continue;
					case 581:
						array9 = null;
						num2 = 400;
						continue;
					case 582:
						array3[num5 + 4] = array9[4];
						num2 = 491;
						continue;
					case 583:
						num43 = sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
						num2 = 619;
						continue;
					case 584:
						num3 = 56 + 112;
						num2 = 254;
						continue;
					case 585:
						num61 = array6.Length / 4;
						num2 = 540;
						continue;
					case 586:
						array2[14] = 133 - 44;
						num2 = 646;
						continue;
					case 587:
						num16 = 23;
						num2 = 130;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 332;
							continue;
						}
						continue;
					case 588:
						goto IL_603A;
					case 589:
						sdwn9hocwBVuZe0IsL.qXbZ7XeOLHXdIkJVLLN(array7);
						num2 = 66;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 66;
							continue;
						}
						continue;
					case 590:
						array2[7] = 79 + 47;
						num2 = 118;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 525;
							continue;
						}
						continue;
					case 591:
						goto IL_0D83;
					case 592:
						array2[3] = (byte)num4;
						num2 = 515;
						continue;
					case 593:
						num4 = 160 - 53;
						num2 = 424;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 185;
							continue;
						}
						continue;
					case 594:
						array[21] = 185 + 17;
						num2 = 220;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 30;
							continue;
						}
						continue;
					case 595:
						array2[15] = (byte)num4;
						num2 = 437;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 60;
							continue;
						}
						continue;
					case 596:
						array3[num16 + 3] = array9[3];
						num2 = 330;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 419;
							continue;
						}
						continue;
					case 597:
						num3 = 98 + 36;
						num2 = 461;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 399;
							continue;
						}
						continue;
					case 598:
						intPtr2 = sdwn9hocwBVuZe0IsL.vN3AFbebjZI4eDrctoc(sdwn9hocwBVuZe0IsL.nIUhuxevLRfZNLqP2eg(sdwn9hocwBVuZe0IsL.HW2YQnV3Hp)[0]);
						num2 = 229;
						continue;
					case 599:
						array2[11] = 108 - 8;
						num2 = 105;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 264;
							continue;
						}
						continue;
					case 600:
						array2[12] = 137 - 45;
						num2 = 373;
						continue;
					case 601:
					{
						uint num62 = num37;
						uint num63 = num37;
						uint num64 = 785396777U;
						uint num65 = 851326108U;
						uint num66 = num63;
						uint num67 = 1950741206U;
						uint num68 = 443419207U;
						uint num69 = ((num65 >> 6) | (num65 << 26)) ^ num67;
						uint num70 = num69 & 252645135U;
						num69 &= 4042322160U;
						num65 = (num69 >> 4) | (num70 << 4);
						num66 -= num67;
						num66 = 33939422U * (num66 & 63U) - (num66 >> 6);
						num64 = 62797463U * (num64 & 63U) - (num64 >> 6);
						num65 = 34753U * num65 + num67;
						num69 = num67 & 252645135U;
						num70 = num67 & 4042322160U;
						num69 = ((num69 >> 4) | (num70 << 4)) + num65;
						num67 = (num67 >> 14) | (num67 << 18);
						num68 ^= num65;
						num66 ^= num66 << 3;
						num66 += num64;
						num66 ^= num66 << 25;
						num66 += num67;
						num66 ^= num66 >> 23;
						num66 += num68;
						num66 = (((num66 << 3) - num64) ^ num64) + num66;
						num37 = num62 + (uint)num66;
						num2 = 248;
						continue;
					}
					case 602:
					{
						bool flag;
						sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA fRw86wMffvVYO8Ce8dA2;
						fRw86wMffvVYO8Ce8dA2.OlHMhVQ03F = flag;
						num2 = 626;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 461;
							continue;
						}
						continue;
					}
					case 603:
						goto IL_1E40;
					case 604:
						array2[5] = (byte)num4;
						num2 = 124;
						continue;
					case 605:
						intPtr3 = IntPtr.Zero;
						num2 = 74;
						continue;
					case 606:
						try
						{
							for (;;)
							{
								IL_32A2:
								if (sdwn9hocwBVuZe0IsL.gd4ZMoe4EVg4wQIfHqe(enumerator))
								{
									goto IL_328A;
								}
								int num71 = 9;
								ProcessModule processModule2;
								for (;;)
								{
									IL_3190:
									Version version;
									Version version2;
									int num72;
									switch (num71)
									{
									case 1:
										version = new Version(4, 0, 30319, 17921);
										num71 = 5;
										continue;
									case 2:
										goto IL_324F;
									case 3:
										goto IL_32A2;
									case 4:
										goto IL_328A;
									case 5:
									{
										Version version3;
										if (!sdwn9hocwBVuZe0IsL.sx1MUnerEa05pv5Eh8q(version2, version3))
										{
											num72 = 12;
											goto IL_318C;
										}
										goto IL_330D;
									}
									case 6:
										goto IL_3325;
									case 7:
										goto IL_3344;
									case 8:
										goto IL_320E;
									case 10:
										goto IL_330D;
									case 11:
										if (!sdwn9hocwBVuZe0IsL.qeK7fOBzMi5Lu01n5xb(sdwn9hocwBVuZe0IsL.f6uNemBAUkd7lWXrGt7(sdwn9hocwBVuZe0IsL.QIwGTPBcZTGF7jsNan0(processModule2)), "clrjit.dll"))
										{
											num72 = 6;
											goto IL_318C;
										}
										goto IL_320E;
									case 12:
										goto IL_32FE;
									case 13:
									{
										Version version3 = new Version(4, 0, 30319, 17020);
										num71 = 1;
										if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
										{
											num71 = 1;
											continue;
										}
										continue;
									}
									}
									goto Block_336;
									IL_318C:
									num71 = num72;
									continue;
									IL_320E:
									version2 = new Version(sdwn9hocwBVuZe0IsL.xc0grBeY0SnFgH91xoe(sdwn9hocwBVuZe0IsL.NxuiMye3ygVEwCpjSX8(processModule2)), sdwn9hocwBVuZe0IsL.VAp4MIeM7nBTKQCHM5w(sdwn9hocwBVuZe0IsL.NxuiMye3ygVEwCpjSX8(processModule2)), sdwn9hocwBVuZe0IsL.hytIxgekEwV19UJTfKM(sdwn9hocwBVuZe0IsL.NxuiMye3ygVEwCpjSX8(processModule2)), sdwn9hocwBVuZe0IsL.VncFcHeTLxAH3VeSTwg(sdwn9hocwBVuZe0IsL.NxuiMye3ygVEwCpjSX8(processModule2)));
									num71 = 13;
									continue;
									IL_330D:
									if (!sdwn9hocwBVuZe0IsL.FIvcAseqOeTyrkN2oRg(version2, version))
									{
										num71 = 2;
										continue;
									}
									IL_3344:
									sdwn9hocwBVuZe0IsL.f2FYe0cg8x = true;
									num71 = 0;
									if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
									{
										num71 = 0;
									}
								}
								IL_324F:
								IL_32FE:
								IL_3325:
								continue;
								IL_328A:
								processModule2 = (ProcessModule)sdwn9hocwBVuZe0IsL.wgGkeABZsoCmUcVnuHt(enumerator);
								num71 = 11;
								goto IL_3190;
							}
							Block_336:
							goto IL_153C;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							int num73 = 2;
							int num74 = num73;
							for (;;)
							{
								switch (num74)
								{
								default:
									goto IL_339E;
								case 1:
									goto IL_33F3;
								case 2:
									if (disposable == null)
									{
										num74 = 0;
										if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
										{
											num74 = 0;
											continue;
										}
										continue;
									}
									break;
								case 3:
									break;
								}
								sdwn9hocwBVuZe0IsL.s3UL5memStMP0xeBqVX(disposable);
								num74 = 0;
								if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
								{
									num74 = 1;
								}
							}
							IL_339E:
							IL_33F3:;
						}
						goto IL_340E;
					case 607:
						num36 = (long)sdwn9hocwBVuZe0IsL.tGJE7Ke8t0nxYGsFxfu(intPtr7);
						num2 = 508;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 373;
							continue;
						}
						continue;
					case 608:
						array11[5] = 106;
						num2 = 56;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 30;
							continue;
						}
						continue;
					case 609:
						goto IL_3BD0;
					case 610:
						goto IL_3B95;
					case 611:
						goto IL_19A3;
					case 612:
						array18 = null;
						num2 = 368;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 572;
							continue;
						}
						continue;
					case 613:
						array2[0] = (byte)num4;
						num2 = 44;
						continue;
					case 614:
						goto IL_27EA;
					case 615:
						goto IL_18B2;
					case 616:
						goto IL_153C;
					case 617:
						num4 = 207 + 0;
						num2 = 642;
						continue;
					case 618:
						array2[13] = (byte)num4;
						num2 = 258;
						continue;
					case 619:
						if (sdwn9hocwBVuZe0IsL.kfkY6lTjH7(intPtr6, num43 * 4, 4, ref num8) != 0)
						{
							num2 = 71;
							continue;
						}
						goto IL_1C56;
					case 620:
						goto IL_2811;
					case 621:
						array[12] = (byte)num3;
						num2 = 597;
						continue;
					case 622:
					{
						sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA fRw86wMffvVYO8Ce8dA;
						sdwn9hocwBVuZe0IsL.H7XyrFeLU1WAdDboo8d(sdwn9hocwBVuZe0IsL.bThYZMo80t, 0L, fRw86wMffvVYO8Ce8dA);
						num2 = 295;
						continue;
					}
					case 623:
						goto IL_1E1D;
					case 624:
						num33 = array15.Length % 4;
						num2 = 371;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 155;
							continue;
						}
						continue;
					case 625:
					{
						string text;
						IntPtr intPtr4 = sdwn9hocwBVuZe0IsL.GA9YTLIgTb(text);
						num2 = 96;
						continue;
					}
					case 626:
					{
						sdwn9hocwBVuZe0IsL.fRw86wMffvVYO8Ce8dA fRw86wMffvVYO8Ce8dA2;
						sdwn9hocwBVuZe0IsL.H7XyrFeLU1WAdDboo8d(sdwn9hocwBVuZe0IsL.bThYZMo80t, num34 + (long)num75, fRw86wMffvVYO8Ce8dA2);
						num2 = 169;
						continue;
					}
					case 627:
						array7 = array2;
						num2 = 589;
						continue;
					case 628:
						array[8] = 57 + 44;
						num2 = 224;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 443;
							continue;
						}
						continue;
					case 629:
						num3 = 171 - 57;
						num2 = 510;
						continue;
					case 630:
						array[20] = 136 - 45;
						num2 = 185;
						continue;
					case 631:
						array3[num5 + 2] = array10[2];
						num2 = 65;
						continue;
					case 632:
						num3 = 126 + 89;
						num2 = 249;
						continue;
					case 633:
						array11[8] = 46;
						num2 = 643;
						continue;
					case 634:
						num4 = 68 + 120;
						num2 = 92;
						continue;
					case 635:
						array[13] = (byte)num3;
						num2 = 70;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 30;
							continue;
						}
						continue;
					case 636:
						goto IL_3BA8;
					case 637:
						num35++;
						num2 = 111;
						continue;
					case 638:
						goto IL_29D7;
					case 639:
						goto IL_53D9;
					case 640:
						array11[4] = 114;
						num2 = 608;
						continue;
					case 641:
						array2[11] = (byte)num4;
						num2 = 177;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 117;
							continue;
						}
						continue;
					case 642:
						array2[13] = (byte)num4;
						num2 = 41;
						continue;
					case 643:
						array11[9] = 100;
						num2 = 357;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 31;
							continue;
						}
						continue;
					case 644:
						if (sdwn9hocwBVuZe0IsL.kfkY6lTjH7(intPtr8, 4, 4, ref num8) != 0)
						{
							goto IL_654E;
						}
						num2 = 265;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 657;
							continue;
						}
						continue;
					case 645:
						goto IL_5117;
					case 646:
						num4 = 118 - 41;
						num2 = 219;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 205;
							continue;
						}
						continue;
					case 647:
						goto IL_2F8A;
					case 648:
						array[28] = (byte)num3;
						num2 = 365;
						continue;
					case 649:
						if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() == 4)
						{
							num2 = 554;
							continue;
						}
						goto IL_5D7A;
					case 650:
						array2[12] = (byte)num4;
						num2 = 541;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 503;
							continue;
						}
						continue;
					case 651:
						array3[num16 + 2] = array9[2];
						num2 = 596;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 63;
							continue;
						}
						continue;
					case 652:
						array[4] = 3 + 103;
						num2 = 538;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 183;
							continue;
						}
						continue;
					case 653:
					{
						string text2 = sdwn9hocwBVuZe0IsL.Jeo9xfey3kU58du2Htn(sdwn9hocwBVuZe0IsL.RC0qqAexyyowQr6Uw8c(), array8);
						num2 = 312;
						continue;
					}
					case 654:
						array[9] = (byte)num3;
						num2 = 119;
						continue;
					case 655:
						if (num33 <= 0)
						{
							goto IL_2C3F;
						}
						num2 = 257;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 130;
							continue;
						}
						continue;
					case 656:
						array[1] = (byte)num3;
						num2 = 534;
						continue;
					case 657:
						sdwn9hocwBVuZe0IsL.kfkY6lTjH7(intPtr8, 4, 8, ref num8);
						num2 = 108;
						continue;
					case 658:
						array2[8] = 234 - 78;
						num2 = 568;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
						{
							num2 = 0;
							continue;
						}
						continue;
					case 659:
						array[6] = (byte)num3;
						num2 = 579;
						continue;
					case 660:
						array2[7] = (byte)num4;
						num2 = 20;
						if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 36;
							continue;
						}
						continue;
					case 661:
						num7 = sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
						num2 = 588;
						continue;
					case 662:
						array[0] = 122 + 48;
						num2 = 162;
						continue;
					case 663:
						array[22] = (byte)num3;
						num2 = 476;
						if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
						{
							num2 = 403;
							continue;
						}
						continue;
					default:
						goto IL_2280;
					}
					IL_0AF0:
					sdwn9hocwBVuZe0IsL.ML2Xhne0E3pUPWjioKg(new IntPtr(intPtr6.ToInt64() + (long)(num39 * 4)), sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF));
					num2 = 341;
					if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 140;
						continue;
					}
					continue;
					IL_615D:
					if (num39 >= num43)
					{
						num2 = 377;
						continue;
					}
					goto IL_0AF0;
					IL_0D83:
					array2[4] = (byte)num4;
					num2 = 360;
					if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 143;
						continue;
					}
					continue;
					IL_0E16:
					array11 = new byte[12];
					num2 = 50;
					if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 157;
						continue;
					}
					continue;
					IL_11BF:
					process = sdwn9hocwBVuZe0IsL.z04QVgBnBcbRh9bFvpm();
					num2 = 26;
					continue;
					IL_1308:
					array7[1] = array13[0];
					num2 = 137;
					continue;
					IL_13A2:
					intPtr = new IntPtr(num34 + (long)sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF) - (long)num30);
					num2 = 292;
					continue;
					IL_2EC7:
					if (num32 < num21)
					{
						goto IL_13A2;
					}
					num2 = 459;
					if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 365;
						continue;
					}
					continue;
					IL_1438:
					sdwn9hocwBVuZe0IsL.NN0rEIecj3u3GYQ6O5f(sdwn9hocwBVuZe0IsL.jtsYaqmqlL);
					num2 = 46;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
					{
						num2 = 161;
						continue;
					}
					continue;
					IL_153C:
					mcrqrIMElFcjUmhrYwF = new sdwn9hocwBVuZe0IsL.MCRQrIMElFcjUmhrYwF(sdwn9hocwBVuZe0IsL.n8h9xNe6IYA9jQ1yHIf(sdwn9hocwBVuZe0IsL.HW2YQnV3Hp, "A7fEuW4QrENafl8wmB.H2S79imn3ld0M56x3O"));
					num2 = 285;
					continue;
					IL_44D5:
					if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() != 4)
					{
						goto IL_153C;
					}
					num2 = 181;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
					{
						num2 = 329;
						continue;
					}
					continue;
					IL_1608:
					sdwn9hocwBVuZe0IsL.ourYmRHfMP(intPtr3, intPtr8, sdwn9hocwBVuZe0IsL.hGiFBMewVG7RMY5H2rQ(sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF)), 4U, out zero);
					num2 = 614;
					continue;
					IL_654E:
					if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() != 4)
					{
						goto IL_1608;
					}
					num2 = 451;
					if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 159;
						continue;
					}
					continue;
					IL_17B7:
					if (num76 < num44)
					{
						goto IL_29EB;
					}
					num2 = 277;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
					{
						num2 = 57;
						continue;
					}
					continue;
					IL_185D:
					if (num60 < num21)
					{
						goto IL_429E;
					}
					num2 = 260;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
					{
						num2 = 168;
						continue;
					}
					continue;
					IL_18B2:
					sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
					num2 = 47;
					continue;
					IL_19A3:
					num20 = num27 % num61;
					num2 = 158;
					continue;
					IL_279F:
					if (num27 < num35)
					{
						goto IL_19A3;
					}
					num2 = 571;
					if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 57;
						continue;
					}
					continue;
					IL_19C9:
					num42 = sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF);
					num2 = 152;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
					{
						num2 = 372;
						continue;
					}
					continue;
					IL_1C3D:
					num3 = 207 + 19;
					num2 = 647;
					continue;
					IL_1E1D:
					if (num38 < num33)
					{
						goto IL_0EE1;
					}
					num2 = 104;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
					{
						num2 = 397;
						continue;
					}
					continue;
					IL_1E40:
					sdwn9hocwBVuZe0IsL.K8VY81bt0R = true;
					num2 = 370;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
					{
						num2 = 416;
						continue;
					}
					continue;
					IL_203D:
					num12 = sdwn9hocwBVuZe0IsL.jWrQgBeFlKX9rFnw8y6(new IntPtr(num36));
					num2 = 250;
					continue;
					IL_21B8:
					if (sdwn9hocwBVuZe0IsL.cpkSGeeUJMK5lyCyPHZ(sdwn9hocwBVuZe0IsL.jURbFbelkILPa80E2mT(mcrqrIMElFcjUmhrYwF)) < sdwn9hocwBVuZe0IsL.Pjgqnmefo4pM513HYvv(sdwn9hocwBVuZe0IsL.jURbFbelkILPa80E2mT(mcrqrIMElFcjUmhrYwF)) - 1L)
					{
						num2 = 3;
						continue;
					}
					goto IL_57A9;
					IL_2211:
					byte[] array21 = new byte[30];
					sdwn9hocwBVuZe0IsL.OHnouCQ3EPpQkPJBPHA(array21, fieldof(<PrivateImplementationDetails>{00DEC971-B8D4-43E3-9526-3C9CB75F1393}.D5B7247C497788CF0031CEB06E3DF77A45FEF59F1E49633DC7159816D64759B5).FieldHandle);
					array18 = array21;
					num2 = 448;
					continue;
					IL_2280:
					num3 = 165 - 55;
					num2 = 271;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
					{
						num2 = 134;
						continue;
					}
					continue;
					IL_22E1:
					num36 = sdwn9hocwBVuZe0IsL.jWrQgBeFlKX9rFnw8y6(intPtr7);
					num2 = 20;
					if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 20;
						continue;
					}
					continue;
					IL_2391:
					array14[num26 + num38] = (byte)((num77 & num25) >> num28);
					num2 = 321;
					continue;
					IL_0EE1:
					if (num38 > 0)
					{
						goto Block_14;
					}
					goto IL_2391;
					IL_24A0:
					num2 = 455;
					continue;
					IL_2780:
					array[8] = 105 + 79;
					num2 = 628;
					continue;
					IL_27EA:
					sdwn9hocwBVuZe0IsL.kfkY6lTjH7(intPtr8, 4, num8, ref num8);
					num2 = 441;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
					{
						num2 = 88;
						continue;
					}
					continue;
					IL_2811:
					num37 = num37;
					num2 = 601;
					continue;
					IL_2857:
					if (num18 > 0)
					{
						num2 = 50;
						continue;
					}
					goto IL_3BD0;
					IL_3B95:
					if (num18 >= num33)
					{
						num2 = 368;
						continue;
					}
					goto IL_2857;
					IL_29EB:
					byte* ptr2;
					*(long*)(ptr2 + num76 * 8) ^= 328719144L;
					num2 = 98;
					continue;
					IL_2B2A:
					array6[num40] ^= array7[num40];
					num2 = 354;
					continue;
					IL_55EF:
					if (num40 < array7.Length)
					{
						goto IL_2B2A;
					}
					num2 = 385;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
					{
						num2 = 309;
						continue;
					}
					continue;
					IL_2BD8:
					intPtr9 = sdwn9hocwBVuZe0IsL.auVitJQYg62M4yliQIL(IntPtr.Zero, (uint)array18.Length, 4096U, 64U);
					num2 = 335;
					continue;
					IL_2BF9:
					ptr2 = null;
					num2 = 81;
					if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 347;
						continue;
					}
					continue;
					IL_2C3F:
					num29 = num37 ^ num17;
					num2 = 500;
					continue;
					IL_2C9F:
					sdwn9hocwBVuZe0IsL.q0orPgB5JZTCdkyAsx9(intPtr7, 0);
					num2 = 374;
					continue;
					IL_2DD0:
					IntPtr zero2 = IntPtr.Zero;
					num2 = 518;
					continue;
					IL_300B:
					sdwn9hocwBVuZe0IsL.ML2Xhne0E3pUPWjioKg(intPtr, sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF));
					num2 = 24;
					if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 11;
						continue;
					}
					continue;
					IL_3113:
					if (array16.Length == 0)
					{
						num2 = 186;
						continue;
					}
					goto IL_5DDE;
					IL_340E:
					array14[num26 + 3] = (byte)((num29 & 4278190080U) >> 24);
					num2 = 181;
					continue;
					IL_35CF:
					num19 = (uint)num26;
					num2 = 306;
					continue;
					IL_3970:
					num27++;
					num2 = 417;
					continue;
					IL_3AA7:
					enumerator = sdwn9hocwBVuZe0IsL.pJPGysBK5rm4P6gKahV(sdwn9hocwBVuZe0IsL.BAF30YBC93yXgHK0cYx(sdwn9hocwBVuZe0IsL.z04QVgBnBcbRh9bFvpm()));
					num2 = 606;
					continue;
					IL_3BA8:
					sdwn9hocwBVuZe0IsL.usJQyrB864bv0Wsds9J(array3, 0, intPtr9, array3.Length);
					num2 = 541;
					if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 546;
						continue;
					}
					continue;
					IL_3BD0:
					num17 |= (uint)array15[array15.Length - (1 + num18)];
					num2 = 422;
					if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 9;
						continue;
					}
					continue;
					IL_3C88:
					array8 = new byte[6];
					num2 = 33;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
					{
						num2 = 33;
						continue;
					}
					continue;
					IL_3E3A:
					num40 = 0;
					num2 = 237;
					continue;
					IL_3E6A:
					if (sdwn9hocwBVuZe0IsL.ILcTVBBpBKd3Mbi5lrs() == 4)
					{
						num2 = 81;
						continue;
					}
					goto IL_6131;
					IL_3F2F:
					num76 = 0;
					num2 = 507;
					continue;
					IL_4199:
					num30 = 7680;
					num2 = 615;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() != null)
					{
						num2 = 99;
						continue;
					}
					continue;
					IL_5324:
					if (sdwn9hocwBVuZe0IsL.kYAIbUeIUaH9GFmrBit(sdwn9hocwBVuZe0IsL.AhsQsKedAUaWx5O73vT(sdwn9hocwBVuZe0IsL.HW2YQnV3Hp)) != 0)
					{
						num2 = 379;
						continue;
					}
					goto IL_4199;
					IL_429E:
					intPtr8 = new IntPtr(sdwn9hocwBVuZe0IsL.RdKYjGBxn6 + (long)sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF) - (long)num30);
					num2 = 644;
					continue;
					IL_480C:
					num2 = 147;
					if (sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 488;
						continue;
					}
					continue;
					IL_3943:
					if (sdwn9hocwBVuZe0IsL.kYAIbUeIUaH9GFmrBit(sdwn9hocwBVuZe0IsL.AhsQsKedAUaWx5O73vT(sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL).TypeHandle).Assembly)) > 0)
					{
						goto Block_151;
					}
					goto IL_480C;
					IL_4ACB:
					num39 = 0;
					num2 = 272;
					continue;
					IL_4B30:
					sdwn9hocwBVuZe0IsL.jtsYaqmqlL = null;
					num2 = 58;
					if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
					{
						num2 = 524;
						continue;
					}
					continue;
					IL_4C6C:
					if (sdwn9hocwBVuZe0IsL.cpkSGeeUJMK5lyCyPHZ(sdwn9hocwBVuZe0IsL.jURbFbelkILPa80E2mT(mcrqrIMElFcjUmhrYwF)) < sdwn9hocwBVuZe0IsL.Pjgqnmefo4pM513HYvv(sdwn9hocwBVuZe0IsL.jURbFbelkILPa80E2mT(mcrqrIMElFcjUmhrYwF)) - 1L)
					{
						num2 = 2;
						if (sdwn9hocwBVuZe0IsL.JBVpFdBL3Mo3Pl5pBav() == null)
						{
							num2 = 175;
							continue;
						}
						continue;
					}
					IL_500D:
					sdwn9hocwBVuZe0IsL.IKHAW7eoSGl0UNtbeE7(intPtr3);
					num2 = 180;
					if (!sdwn9hocwBVuZe0IsL.E3ZXS6BocuZl7JNHULC())
					{
						num2 = 34;
						continue;
					}
					continue;
					IL_5117:
					intPtr2 = sdwn9hocwBVuZe0IsL.vN3AFbebjZI4eDrctoc(sdwn9hocwBVuZe0IsL.nIUhuxevLRfZNLqP2eg(sdwn9hocwBVuZe0IsL.HW2YQnV3Hp)[0]);
					num2 = 562;
					continue;
					IL_57A9:
					intPtr2 = sdwn9hocwBVuZe0IsL.vN3AFbebjZI4eDrctoc(sdwn9hocwBVuZe0IsL.nIUhuxevLRfZNLqP2eg(sdwn9hocwBVuZe0IsL.RUMg1De5mfncGrtk7dC(typeof(sdwn9hocwBVuZe0IsL).TypeHandle).Assembly)[0]);
					num2 = 547;
					continue;
					IL_5CCF:
					num3 = 145 - 48;
					num2 = 281;
					continue;
					IL_5D7A:
					array4 = sdwn9hocwBVuZe0IsL.Io7SUgeZdmkO97TgOU3(sdwn9hocwBVuZe0IsL.uT6YCBSbyl.ToInt64());
					num2 = 367;
					continue;
					IL_5DDE:
					ptr2 = &array16[0];
					num2 = 93;
					continue;
					IL_603A:
					if (num7 == 1)
					{
						num2 = 605;
						continue;
					}
					num32 = 0;
					num2 = 449;
					continue;
					IL_6131:
					num5 = 2;
					num2 = 445;
				}
				IL_0DAB:
				num37 = 0U;
				num = 442;
				continue;
				Block_14:
				num = 153;
				continue;
				IL_0F0F:
				sdwn9hocwBVuZe0IsL.WB2YpT3TWI = false;
				num = 384;
				continue;
				IL_145C:
				array4 = sdwn9hocwBVuZe0IsL.hGiFBMewVG7RMY5H2rQ(sdwn9hocwBVuZe0IsL.uT6YCBSbyl.ToInt32());
				num = 310;
				continue;
				IL_1880:
				num3 = 61 + 66;
				num = 391;
				continue;
				IL_1C56:
				sdwn9hocwBVuZe0IsL.kfkY6lTjH7(intPtr6, num43 * 4, 8, ref num8);
				num = 102;
				continue;
				IL_1E08:
				num77 = num37 ^ num17;
				num = 362;
				continue;
				IL_20DB:
				num76++;
				num = 192;
				continue;
				IL_2484:
				array[25] = (byte)num3;
				num = 382;
				continue;
				IL_294A:
				num4 = 31 + 18;
				num = 592;
				continue;
				IL_29D7:
				array11[3] = 111;
				num = 640;
				continue;
				IL_2E14:
				array2[13] = (byte)num4;
				num = 114;
				continue;
				IL_2F8A:
				array[24] = (byte)num3;
				num = 29;
				continue;
				IL_30F7:
				array[5] = (byte)num3;
				num = 154;
				continue;
				IL_3496:
				array[28] = 194 - 83;
				num = 503;
				continue;
				IL_3901:
				array[7] = 150 - 50;
				num = 316;
				continue;
				Block_151:
				num = 25;
				continue;
				IL_3999:
				array[18] = 131 - 50;
				num = 420;
				continue;
				IL_3CCA:
				array[16] = 121 + 41;
				num = 246;
				continue;
				IL_3E27:
				sdwn9hocwBVuZe0IsL.O0CDQGBVv1lf3joLys9();
				num = 553;
				continue;
				IL_1004:
				goto IL_3E27;
				IL_3E47:
				array[24] = 184 - 61;
				num = 280;
				continue;
				IL_3F0C:
				array2[0] = 122 + 48;
				num = 225;
				continue;
				IL_40C2:
				sdwn9hocwBVuZe0IsL.H8cQyKQMrdPtvSTk51Z(new IntPtr(num36), intPtr9);
				num = 363;
				continue;
				IL_45CF:
				array[5] = (byte)num3;
				num = 405;
				continue;
				IL_464C:
				array[23] = (byte)num3;
				num = 426;
				continue;
				IL_4869:
				num4 = 112 + 117;
				num = 641;
				continue;
				IL_4E26:
				array3[num16 + 3] = array10[3];
				num = 587;
				continue;
				Block_226:
				num = 328;
				continue;
				IL_5157:
				num19 = 0U;
				num = 369;
				continue;
				IL_53D9:
				array3[num5 + 6] = array9[6];
				num = 45;
				continue;
				IL_5770:
				array[8] = (byte)num3;
				num = 283;
				continue;
				IL_5829:
				num75 = sdwn9hocwBVuZe0IsL.xvLdQIeNuQrd3wa7mLG(mcrqrIMElFcjUmhrYwF) - num30;
				num = 131;
				continue;
				IL_5CE8:
				array3[num16] = array9[0];
				num = 403;
				continue;
				IL_5DF3:
				array11[6] = 46;
				num = 552;
				continue;
				IL_5FD1:
				num3 = 247 - 82;
				num = 218;
				continue;
				IL_5FEE:
				sdwn9hocwBVuZe0IsL.siwaJIBxtRmswljLJFb(new IntPtr((void*)(&num6)), 0);
				num = 14;
				continue;
				IL_604C:
				array[13] = 133 - 44;
				num = 318;
				continue;
				IL_60A7:
				num60++;
				num = 244;
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000A780 File Offset: 0x00008980
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object sWPYkxO0d7(object \u0020)
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

		// Token: 0x06000067 RID: 103
		[DllImport("kernel32", EntryPoint = "LoadLibrary")]
		public static extern IntPtr GA9YTLIgTb(string \u0020);

		// Token: 0x06000068 RID: 104
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		public static extern IntPtr QgfYrwI9HI(IntPtr \u0020, string \u0020);

		// Token: 0x06000069 RID: 105 RVA: 0x0000A8B0 File Offset: 0x00008AB0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr TZLYqNTvZf(IntPtr \u0020, object \u0020, uint \u0020)
		{
			if (sdwn9hocwBVuZe0IsL.QouYcd6qMq == null)
			{
				sdwn9hocwBVuZe0IsL.QouYcd6qMq = (sdwn9hocwBVuZe0IsL.WNZO20MIfpZ2DDCI4LQ)Marshal.GetDelegateForFunctionPointer(sdwn9hocwBVuZe0IsL.QgfYrwI9HI(sdwn9hocwBVuZe0IsL.xTuFFuFOZ(), "Find ".Trim() + "ResourceA"), typeof(sdwn9hocwBVuZe0IsL.WNZO20MIfpZ2DDCI4LQ));
			}
			return sdwn9hocwBVuZe0IsL.QouYcd6qMq(\u0020, \u0020, \u0020);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000A90C File Offset: 0x00008B0C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr d6FY4im0K8(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			if (sdwn9hocwBVuZe0IsL.ShLYAsssgr == null)
			{
				sdwn9hocwBVuZe0IsL.ShLYAsssgr = (sdwn9hocwBVuZe0IsL.rtf8yfMNiDKYrfAbwqV)Marshal.GetDelegateForFunctionPointer(sdwn9hocwBVuZe0IsL.QgfYrwI9HI(sdwn9hocwBVuZe0IsL.xTuFFuFOZ(), "Virtual ".Trim() + "Alloc"), typeof(sdwn9hocwBVuZe0IsL.rtf8yfMNiDKYrfAbwqV));
			}
			return sdwn9hocwBVuZe0IsL.ShLYAsssgr(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000A968 File Offset: 0x00008B68
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int ourYmRHfMP(IntPtr \u0020, IntPtr \u0020, [In] [Out] byte[] \u0020, uint \u0020, out IntPtr \u0020)
		{
			if (sdwn9hocwBVuZe0IsL.hYPYzGuBMe == null)
			{
				sdwn9hocwBVuZe0IsL.hYPYzGuBMe = (sdwn9hocwBVuZe0IsL.foVJYOMJi2t8eEnRA1b)Marshal.GetDelegateForFunctionPointer(sdwn9hocwBVuZe0IsL.QgfYrwI9HI(sdwn9hocwBVuZe0IsL.xTuFFuFOZ(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(sdwn9hocwBVuZe0IsL.foVJYOMJi2t8eEnRA1b));
			}
			return sdwn9hocwBVuZe0IsL.hYPYzGuBMe(\u0020, \u0020, \u0020, \u0020, out \u0020);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000A9D0 File Offset: 0x00008BD0
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int kfkY6lTjH7(IntPtr \u0020, int \u0020, int \u0020, ref int \u0020)
		{
			if (sdwn9hocwBVuZe0IsL.tVBM3KAemR == null)
			{
				sdwn9hocwBVuZe0IsL.tVBM3KAemR = (sdwn9hocwBVuZe0IsL.HmAJoPMGsgrVylB6Dpe)Marshal.GetDelegateForFunctionPointer(sdwn9hocwBVuZe0IsL.QgfYrwI9HI(sdwn9hocwBVuZe0IsL.xTuFFuFOZ(), "Virtual ".Trim() + "Protect"), typeof(sdwn9hocwBVuZe0IsL.HmAJoPMGsgrVylB6Dpe));
			}
			return sdwn9hocwBVuZe0IsL.tVBM3KAemR(\u0020, \u0020, \u0020, ref \u0020);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000AA2C File Offset: 0x00008C2C
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr L5MYlgA352(uint \u0020, int \u0020, uint \u0020)
		{
			if (sdwn9hocwBVuZe0IsL.DCmMYmNqRX == null)
			{
				sdwn9hocwBVuZe0IsL.DCmMYmNqRX = (sdwn9hocwBVuZe0IsL.Ct161RMBoYLcX58Vao3)Marshal.GetDelegateForFunctionPointer(sdwn9hocwBVuZe0IsL.QgfYrwI9HI(sdwn9hocwBVuZe0IsL.xTuFFuFOZ(), "Open ".Trim() + "Process"), typeof(sdwn9hocwBVuZe0IsL.Ct161RMBoYLcX58Vao3));
			}
			return sdwn9hocwBVuZe0IsL.DCmMYmNqRX(\u0020, \u0020, \u0020);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000AA88 File Offset: 0x00008C88
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int FcsY2xRp8t(IntPtr \u0020)
		{
			if (sdwn9hocwBVuZe0IsL.fIGMMLMdJK == null)
			{
				sdwn9hocwBVuZe0IsL.fIGMMLMdJK = (sdwn9hocwBVuZe0IsL.sRAVG8MeaCnv2CQ0bst)Marshal.GetDelegateForFunctionPointer(sdwn9hocwBVuZe0IsL.QgfYrwI9HI(sdwn9hocwBVuZe0IsL.xTuFFuFOZ(), "Close ".Trim() + "Handle"), typeof(sdwn9hocwBVuZe0IsL.sRAVG8MeaCnv2CQ0bst));
			}
			return sdwn9hocwBVuZe0IsL.fIGMMLMdJK(\u0020);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000AAE4 File Offset: 0x00008CE4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IntPtr xTuFFuFOZ()
		{
			if (sdwn9hocwBVuZe0IsL.u9kMkXEcwN == IntPtr.Zero)
			{
				sdwn9hocwBVuZe0IsL.u9kMkXEcwN = sdwn9hocwBVuZe0IsL.GA9YTLIgTb("kernel ".Trim() + "32.dll");
			}
			return sdwn9hocwBVuZe0IsL.u9kMkXEcwN;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000AB20 File Offset: 0x00008D20
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] zMQYfpXkDr(object \u0020)
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

		// Token: 0x06000071 RID: 113 RVA: 0x0000AB8C File Offset: 0x00008D8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Stream y0fYhEwiQD()
		{
			return new MemoryStream();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000AB94 File Offset: 0x00008D94
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] B0yYOjYN7K(object \u0020)
		{
			return ((MemoryStream)\u0020).ToArray();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] JK1YEyaFvy(object \u0020)
		{
			Stream stream = sdwn9hocwBVuZe0IsL.y0fYhEwiQD();
			SymmetricAlgorithm symmetricAlgorithm = sdwn9hocwBVuZe0IsL.mrRFYAAan();
			symmetricAlgorithm.Key = new byte[]
			{
				182, 206, 130, 160, 68, 13, 0, 187, 18, 23,
				123, 224, 203, 53, 202, 247, 71, 93, 130, 252,
				193, 137, 151, 8, 1, 69, 104, 146, 71, 150,
				134, 223
			};
			symmetricAlgorithm.IV = new byte[]
			{
				4, 25, 74, 192, 109, 162, 225, 1, 216, 39,
				243, 253, 66, 232, 139, 143
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(\u0020, 0, \u0020.Length);
			cryptoStream.Close();
			byte[] array = sdwn9hocwBVuZe0IsL.B0yYOjYN7K(stream);
			q8C8UxMXBu3qF3m8192.wF6BUtFUUD();
			return array;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000AC18 File Offset: 0x00008E18
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] k3cYHnBOwT()
		{
			return null;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000AC28 File Offset: 0x00008E28
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] KaYYsrPfeW()
		{
			return null;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000AC38 File Offset: 0x00008E38
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] QNLYvpCl7C()
		{
			int length = "{11111-22222-20001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000AC58 File Offset: 0x00008E58
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] GYgYb5iTbN()
		{
			int length = "{11111-22222-20001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000AC78 File Offset: 0x00008E78
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] Em0YdeKN63()
		{
			return null;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000AC88 File Offset: 0x00008E88
		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] wMyYIFPUje()
		{
			return null;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000AC98 File Offset: 0x00008E98
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] ILKYNasY07()
		{
			int length = "{11111-22222-40001-00001}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000ACB8 File Offset: 0x00008EB8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] bLyYJdyvSq()
		{
			int length = "{11111-22222-40001-00002}".Length;
			return new byte[] { 1, 2 };
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000ACD8 File Offset: 0x00008ED8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] ndKYGrtHah()
		{
			return null;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000ACE8 File Offset: 0x00008EE8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] cXAYB3qACl()
		{
			return null;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000ACF8 File Offset: 0x00008EF8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object PE0nkKlRNpExCA5VLsN(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000AD04 File Offset: 0x00008F04
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void q9I0bLlxuuGEBnaaXLl(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000AD14 File Offset: 0x00008F14
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long Tk9q6llyIQG9dlsQ4JT(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000AD20 File Offset: 0x00008F20
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object sKoJcGlivVWVe1mqG7i(object A_0, int \u0020)
		{
			return A_0.bfWMH19ZNT(\u0020);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000AD30 File Offset: 0x00008F30
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void YtpDfblWYKVReu24xkm(object A_0)
		{
			A_0.jMOMb8BjZg();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000AD3C File Offset: 0x00008F3C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Uax8Ocltlj1JBLxoFEF(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000AD48 File Offset: 0x00008F48
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object F019GBl89uiOApuVuTu(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000AD54 File Offset: 0x00008F54
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object qZ1SwSlFP8fUMCQHTyi(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000AD60 File Offset: 0x00008F60
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object l1UVjVln4PYLYH2KtxB()
		{
			return sdwn9hocwBVuZe0IsL.mrRFYAAan();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000AD68 File Offset: 0x00008F68
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void c4rhKYlj254V8KjBNPV(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000AD78 File Offset: 0x00008F78
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object KB3Kbpla4sl0Rquq461(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000AD8C File Offset: 0x00008F8C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object caI6H2lPTJmH0Gha3Yp()
		{
			return sdwn9hocwBVuZe0IsL.y0fYhEwiQD();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000AD94 File Offset: 0x00008F94
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Qr1hO0l1ACXA00Q17AX(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000ADAC File Offset: 0x00008FAC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void uPnw3ulVUbgTullnLTo(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000ADB8 File Offset: 0x00008FB8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object wGIxwMlp1NsiyUFb34a(object A_0)
		{
			return sdwn9hocwBVuZe0IsL.B0yYOjYN7K(A_0);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000ADC4 File Offset: 0x00008FC4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void D6De8el7pPAsZoPWcgt(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000ADD0 File Offset: 0x00008FD0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object rqraailDEve8InqyYEc(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000ADDC File Offset: 0x00008FDC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool jhlclxlCCHjTupj1YRC(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000ADEC File Offset: 0x00008FEC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool PtIcPLlLqZbYdkgcHZ1()
		{
			return null == null;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000ADF4 File Offset: 0x00008FF4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object ar9ubVl516hqSd1i3XC()
		{
			return null;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000ADF8 File Offset: 0x00008FF8
		static int r5FO4RB0ee7B2gAQxd0()
		{
			return 1;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000ADFC File Offset: 0x00008FFC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr q0orPgB5JZTCdkyAsx9(IntPtr A_0, int A_1)
		{
			return Marshal.ReadIntPtr(A_0, A_1);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000AE0C File Offset: 0x0000900C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int YiOXRZBRdTAidDyFE1K(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt32(A_0, A_1);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000AE1C File Offset: 0x0000901C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long siwaJIBxtRmswljLJFb(IntPtr A_0, int A_1)
		{
			return Marshal.ReadInt64(A_0, A_1);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000AE2C File Offset: 0x0000902C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void pRkoReByHuVNAMGRPif(IntPtr A_0, int A_1, IntPtr A_2)
		{
			Marshal.WriteIntPtr(A_0, A_1, A_2);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000AE40 File Offset: 0x00009040
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Jg7GoqBifc14fetnAkM(IntPtr A_0, int A_1, int A_2)
		{
			Marshal.WriteInt32(A_0, A_1, A_2);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000AE54 File Offset: 0x00009054
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Q8lv7eBWHN4MEpxyc3V(IntPtr A_0, int A_1, long A_2)
		{
			Marshal.WriteInt64(A_0, A_1, A_2);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000AE68 File Offset: 0x00009068
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr JKgAMCBtmGCGQOwORHb(int A_0)
		{
			return Marshal.AllocCoTaskMem(A_0);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000AE74 File Offset: 0x00009074
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void usJQyrB864bv0Wsds9J(object A_0, int A_1, IntPtr A_2, int A_3)
		{
			Marshal.Copy(A_0, A_1, A_2, A_3);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000AE8C File Offset: 0x0000908C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void HcdGlfBFBiYJ7htS7w9()
		{
			sdwn9hocwBVuZe0IsL.y0kY3ct6CB();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000AE94 File Offset: 0x00009094
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object z04QVgBnBcbRh9bFvpm()
		{
			return Process.GetCurrentProcess();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000AE9C File Offset: 0x0000909C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object zYGaRlBjwgA2DCnlE9D(object A_0)
		{
			return A_0.MainModule;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000AEA8 File Offset: 0x000090A8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr fUMoR1BarEYFYHARIpI(object A_0)
		{
			return A_0.BaseAddress;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000AEB4 File Offset: 0x000090B4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr qDDCTiBPkMbepdU7DLh(IntPtr \u0020, object A_1, uint \u0020)
		{
			return sdwn9hocwBVuZe0IsL.TZLYqNTvZf(\u0020, A_1, \u0020);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000AEC8 File Offset: 0x000090C8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool LdUJbWB1gc9nmnedTSe(IntPtr A_0, IntPtr A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000AED8 File Offset: 0x000090D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void O0CDQGBVv1lf3joLys9()
		{
			q8C8UxMXBu3qF3m8192.wF6BUtFUUD();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000AEE0 File Offset: 0x000090E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int ILcTVBBpBKd3Mbi5lrs()
		{
			return IntPtr.Size;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000AEE8 File Offset: 0x000090E8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type ndMbA6B76kJiamrFDRG(object A_0, bool A_1)
		{
			return Type.GetType(A_0, A_1);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000AEF8 File Offset: 0x000090F8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool nmlsmVBDLKdcTBFeLAm(Type A_0, Type A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000AF08 File Offset: 0x00009108
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object BAF30YBC93yXgHK0cYx(object A_0)
		{
			return A_0.Modules;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000AF14 File Offset: 0x00009114
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object pJPGysBK5rm4P6gKahV(object A_0)
		{
			return A_0.GetEnumerator();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000AF20 File Offset: 0x00009120
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object wgGkeABZsoCmUcVnuHt(object A_0)
		{
			return ((IEnumerator)A_0).Current;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000AF2C File Offset: 0x0000912C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object QIwGTPBcZTGF7jsNan0(object A_0)
		{
			return A_0.ModuleName;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000AF38 File Offset: 0x00009138
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object f6uNemBAUkd7lWXrGt7(object A_0)
		{
			return A_0.ToLower();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000AF44 File Offset: 0x00009144
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool qeK7fOBzMi5Lu01n5xb(object A_0, object A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000AF54 File Offset: 0x00009154
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object NxuiMye3ygVEwCpjSX8(object A_0)
		{
			return A_0.FileVersionInfo;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000AF60 File Offset: 0x00009160
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int xc0grBeY0SnFgH91xoe(object A_0)
		{
			return A_0.ProductMajorPart;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000AF6C File Offset: 0x0000916C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int VAp4MIeM7nBTKQCHM5w(object A_0)
		{
			return A_0.ProductMinorPart;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000AF78 File Offset: 0x00009178
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int hytIxgekEwV19UJTfKM(object A_0)
		{
			return A_0.ProductBuildPart;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000AF84 File Offset: 0x00009184
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int VncFcHeTLxAH3VeSTwg(object A_0)
		{
			return A_0.ProductPrivatePart;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000AF90 File Offset: 0x00009190
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool sx1MUnerEa05pv5Eh8q(object A_0, object A_1)
		{
			return A_0 >= A_1;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000AFA0 File Offset: 0x000091A0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool FIvcAseqOeTyrkN2oRg(object A_0, object A_1)
		{
			return A_0 < A_1;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000AFB0 File Offset: 0x000091B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool gd4ZMoe4EVg4wQIfHqe(object A_0)
		{
			return ((IEnumerator)A_0).MoveNext();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000AFBC File Offset: 0x000091BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void s3UL5memStMP0xeBqVX(object A_0)
		{
			((IDisposable)A_0).Dispose();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000AFC8 File Offset: 0x000091C8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object n8h9xNe6IYA9jQ1yHIf(object A_0, object A_1)
		{
			return A_0.GetManifestResourceStream(A_1);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000AFD8 File Offset: 0x000091D8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object jURbFbelkILPa80E2mT(object A_0)
		{
			return A_0.nW4lBacjpc();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000AFE4 File Offset: 0x000091E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void PrCen7e2rQhm9FsvsPd(object A_0, long A_1)
		{
			A_0.Position = A_1;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000AFF4 File Offset: 0x000091F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long Pjgqnmefo4pM513HYvv(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000B000 File Offset: 0x00009200
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object X8ZSdOehycuDZmVCmrk(object A_0, int \u0020)
		{
			return A_0.bfWMH19ZNT(\u0020);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000B010 File Offset: 0x00009210
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void qXbZ7XeOLHXdIkJVLLN(object A_0)
		{
			Array.Reverse(A_0);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000B01C File Offset: 0x0000921C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object E8AFoNeEfNt8tL7Wyft(object A_0)
		{
			return A_0.GetName();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000B028 File Offset: 0x00009228
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object glFDQpeHW89BUcqc0Wq(object A_0)
		{
			return A_0.GetPublicKeyToken();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000B034 File Offset: 0x00009234
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void DTM3PaesamGskiR7JUf(object A_0, int A_1, int A_2)
		{
			Array.Clear(A_0, A_1, A_2);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000B048 File Offset: 0x00009248
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object nIUhuxevLRfZNLqP2eg(object A_0)
		{
			return A_0.GetModules();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000B054 File Offset: 0x00009254
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr vN3AFbebjZI4eDrctoc(object A_0)
		{
			return Marshal.GetHINSTANCE(A_0);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000B060 File Offset: 0x00009260
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object AhsQsKedAUaWx5O73vT(object A_0)
		{
			return A_0.Location;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000B06C File Offset: 0x0000926C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int kYAIbUeIUaH9GFmrBit(object A_0)
		{
			return A_0.Length;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000B078 File Offset: 0x00009278
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int xvLdQIeNuQrd3wa7mLG(object A_0)
		{
			return A_0.oqiMvIw9LD();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000B084 File Offset: 0x00009284
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object qaTrUweJmdgqvpCHX5N()
		{
			return sdwn9hocwBVuZe0IsL.mrRFYAAan();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000B08C File Offset: 0x0000928C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void abPE3beGjrDgK5KVsZ4(object A_0, CipherMode A_1)
		{
			A_0.Mode = A_1;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000B09C File Offset: 0x0000929C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object m4FmGmeBm2XZRl3PBpg(object A_0, object A_1, object A_2)
		{
			return A_0.CreateDecryptor(A_1, A_2);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000B0B0 File Offset: 0x000092B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void kO66GQeeo0dvUDuELlE(object A_0, object A_1, int A_2, int A_3)
		{
			A_0.Write(A_1, A_2, A_3);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000B0C8 File Offset: 0x000092C8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void zsGVBHeQ5k3XfICp0le(object A_0)
		{
			A_0.FlushFinalBlock();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000B0D4 File Offset: 0x000092D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object O2spJveXJMoW6IZWxnM(object A_0)
		{
			return A_0.ToArray();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000B0E0 File Offset: 0x000092E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void qtF5O3e9A9STqlf4Xj7(object A_0)
		{
			A_0.Close();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000B0EC File Offset: 0x000092EC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void PXLLc2eSMZn9b2u341w(object A_0)
		{
			A_0.jMOMb8BjZg();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000B0F8 File Offset: 0x000092F8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int ldRmiXeulLDvJwAa6Ej(object A_0)
		{
			return A_0.Id;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000B104 File Offset: 0x00009304
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr JNG7nUegMRGdARyWT8e(uint \u0020, int \u0020, uint \u0020)
		{
			return sdwn9hocwBVuZe0IsL.L5MYlgA352(\u0020, \u0020, \u0020);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000B118 File Offset: 0x00009318
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object hGiFBMewVG7RMY5H2rQ(int A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000B124 File Offset: 0x00009324
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long cpkSGeeUJMK5lyCyPHZ(object A_0)
		{
			return A_0.Position;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000B130 File Offset: 0x00009330
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ML2Xhne0E3pUPWjioKg(IntPtr A_0, int A_1)
		{
			Marshal.WriteInt32(A_0, A_1);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000B140 File Offset: 0x00009340
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int IKHAW7eoSGl0UNtbeE7(IntPtr \u0020)
		{
			return sdwn9hocwBVuZe0IsL.FcsY2xRp8t(\u0020);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000B14C File Offset: 0x0000934C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void H7XyrFeLU1WAdDboo8d(object A_0, object A_1, object A_2)
		{
			A_0.Add(A_1, A_2);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000B160 File Offset: 0x00009360
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type RUMg1De5mfncGrtk7dC(RuntimeTypeHandle A_0)
		{
			return Type.GetTypeFromHandle(A_0);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000B16C File Offset: 0x0000936C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int KGfdodeRpp5M8anOQGi(long A_0)
		{
			return Convert.ToInt32(A_0);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000B178 File Offset: 0x00009378
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object RC0qqAexyyowQr6Uw8c()
		{
			return Encoding.UTF8;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000B180 File Offset: 0x00009380
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Jeo9xfey3kU58du2Htn(object A_0, object A_1)
		{
			return A_0.GetString(A_1);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000B190 File Offset: 0x00009390
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool OaPl1Qeihdp0boqGGJd(IntPtr A_0, IntPtr A_1)
		{
			return A_0 == A_1;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000B1A0 File Offset: 0x000093A0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object ifxG6meWJAWC1yDMXjs(IntPtr \u0020, Type \u0020)
		{
			return sdwn9hocwBVuZe0IsL.MIeYYR7YZD(\u0020, \u0020);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000B1B0 File Offset: 0x000093B0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr UiDn3xetknskpp8DQMD(object A_0)
		{
			return A_0();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000B1BC File Offset: 0x000093BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int tGJE7Ke8t0nxYGsFxfu(IntPtr A_0)
		{
			return Marshal.ReadInt32(A_0);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000B1C8 File Offset: 0x000093C8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static long jWrQgBeFlKX9rFnw8y6(IntPtr A_0)
		{
			return Marshal.ReadInt64(A_0);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000B1D4 File Offset: 0x000093D4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr R333Tnenjeh9fWeyOND(object A_0)
		{
			return Marshal.GetFunctionPointerForDelegate(A_0);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000B1E0 File Offset: 0x000093E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int T9ucbYej3R8wFsWqxe0(object A_0)
		{
			return A_0.ModuleMemorySize;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000B1EC File Offset: 0x000093EC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object hgkh8Qeai0cY7tT4mcB(object A_0)
		{
			return A_0.EntryPoint;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000B1F8 File Offset: 0x000093F8
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool lus8xWeP4wwsS9aie3w(object A_0, object A_1)
		{
			return A_0 != A_1;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000B208 File Offset: 0x00009408
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object tbCD4be1gBOsWCMtiNg(object A_0)
		{
			return A_0.Method;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000B214 File Offset: 0x00009414
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object x6BvDWeVgaCl6NIoCsf(Type A_0, object A_1)
		{
			return Delegate.CreateDelegate(A_0, A_1);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000B224 File Offset: 0x00009424
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object F3jqNVepVy6F2QeWKi4(object A_0)
		{
			return A_0.GetParameters();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000B230 File Offset: 0x00009430
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object K3JCrbe77g2py7yZggm(object A_0)
		{
			return A_0.ManifestModule;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000B23C File Offset: 0x0000943C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ModuleHandle YTHsGmeDtWQWEf2DvJG(object A_0)
		{
			return A_0.ModuleHandle;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000B248 File Offset: 0x00009448
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type KLcFtveCY4dvy04d8Fa(object A_0)
		{
			return A_0.GetType();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000B254 File Offset: 0x00009454
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object sVb0wMeKEiBZw8NqvMA(object A_0, object A_1)
		{
			return A_0.GetValue(A_1);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000B264 File Offset: 0x00009464
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Io7SUgeZdmkO97TgOU3(long A_0)
		{
			return BitConverter.GetBytes(A_0);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000B270 File Offset: 0x00009470
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void NN0rEIecj3u3GYQ6O5f(object A_0)
		{
			RuntimeHelpers.PrepareDelegate(A_0);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000B27C File Offset: 0x0000947C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static RuntimeMethodHandle udjMDHeAPOLc2oKruLL(object A_0)
		{
			return A_0.MethodHandle;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000B288 File Offset: 0x00009488
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void RkEK8yezpBpgCjkLhmd(RuntimeMethodHandle A_0)
		{
			RuntimeHelpers.PrepareMethod(A_0);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000B294 File Offset: 0x00009494
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void OHnouCQ3EPpQkPJBPHA(object A_0, RuntimeFieldHandle A_1)
		{
			RuntimeHelpers.InitializeArray(A_0, A_1);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000B2A4 File Offset: 0x000094A4
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr auVitJQYg62M4yliQIL(IntPtr \u0020, uint \u0020, uint \u0020, uint \u0020)
		{
			return sdwn9hocwBVuZe0IsL.d6FY4im0K8(\u0020, \u0020, \u0020, \u0020);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000B2BC File Offset: 0x000094BC
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void H8cQyKQMrdPtvSTk51Z(IntPtr A_0, IntPtr A_1)
		{
			Marshal.WriteIntPtr(A_0, A_1);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000B2CC File Offset: 0x000094CC
		internal static bool E3ZXS6BocuZl7JNHULC()
		{
			return null == null;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000B2D4 File Offset: 0x000094D4
		internal static object JBVpFdBL3Mo3Pl5pBav()
		{
			return null;
		}

		// Token: 0x04000016 RID: 22
		private static object PMAY5HYFCx = new byte[0];

		// Token: 0x04000017 RID: 23
		private static object QOAYF8pZeZ = new SortedList();

		// Token: 0x04000018 RID: 24
		private static bool BImY7QOSmF = false;

		// Token: 0x04000019 RID: 25
		private static IntPtr uT6YCBSbyl = IntPtr.Zero;

		// Token: 0x0400001A RID: 26
		private static object DCmMYmNqRX = null;

		// Token: 0x0400001B RID: 27
		private static List<string> k59YobwKZb = null;

		// Token: 0x0400001C RID: 28
		private static object fIGMMLMdJK = null;

		// Token: 0x0400001D RID: 29
		private static object rbjYwmDvOe = new object();

		// Token: 0x0400001E RID: 30
		private static int cEFYtnVvMS = 1;

		// Token: 0x0400001F RID: 31
		internal static object jcvYuQm2RO = null;

		// Token: 0x04000020 RID: 32
		private static int RRRYDXeRAd = 0;

		// Token: 0x04000021 RID: 33
		private static int CGsYnJ67gx = 0;

		// Token: 0x04000022 RID: 34
		private static object ShLYAsssgr = null;

		// Token: 0x04000023 RID: 35
		private static IntPtr cLlYyQMUNZ = IntPtr.Zero;

		// Token: 0x04000024 RID: 36
		internal static object jtsYaqmqlL = null;

		// Token: 0x04000025 RID: 37
		private static IntPtr ADSYxovVKZ = IntPtr.Zero;

		// Token: 0x04000026 RID: 38
		private static bool K8VY81bt0R = false;

		// Token: 0x04000027 RID: 39
		private static long yqoY1uWEql = 0L;

		// Token: 0x04000028 RID: 40
		private static long RdKYjGBxn6 = 0L;

		// Token: 0x04000029 RID: 41
		internal static object HW2YQnV3Hp = typeof(sdwn9hocwBVuZe0IsL).Assembly;

		// Token: 0x0400002A RID: 42
		internal static object bThYZMo80t = new Hashtable();

		// Token: 0x0400002B RID: 43
		private static int vFXYVfycYb = 0;

		// Token: 0x0400002C RID: 44
		private static int UjiYUuHuXa = 0;

		// Token: 0x0400002D RID: 45
		private static object vNOYReAsND = new byte[0];

		// Token: 0x0400002E RID: 46
		private static object W9jY0YjL4q = new object();

		// Token: 0x0400002F RID: 47
		private static object BPBYWv6gZJ = new int[0];

		// Token: 0x04000030 RID: 48
		private static object tVBM3KAemR = null;

		// Token: 0x04000031 RID: 49
		private static bool UNFY92yQ4x = false;

		// Token: 0x04000032 RID: 50
		private static object v8dYiJqXg0 = new string[0];

		// Token: 0x04000033 RID: 51
		private static Dictionary<int, int> WZ5YglEGcJ = null;

		// Token: 0x04000034 RID: 52
		private static object QouYcd6qMq = null;

		// Token: 0x04000035 RID: 53
		private static IntPtr u9kMkXEcwN = IntPtr.Zero;

		// Token: 0x04000036 RID: 54
		private static bool WB2YpT3TWI = false;

		// Token: 0x04000037 RID: 55
		private static bool f2FYe0cg8x = false;

		// Token: 0x04000038 RID: 56
		private static object xcvYXOkYis = new uint[]
		{
			3614090360U, 3905402710U, 606105819U, 3250441966U, 4118548399U, 1200080426U, 2821735955U, 4249261313U, 1770035416U, 2336552879U,
			4294925233U, 2304563134U, 1804603682U, 4254626195U, 2792965006U, 1236535329U, 4129170786U, 3225465664U, 643717713U, 3921069994U,
			3593408605U, 38016083U, 3634488961U, 3889429448U, 568446438U, 3275163606U, 4107603335U, 1163531501U, 2850285829U, 4243563512U,
			1735328473U, 2368359562U, 4294588738U, 2272392833U, 1839030562U, 4259657740U, 2763975236U, 1272893353U, 4139469664U, 3200236656U,
			681279174U, 3936430074U, 3572445317U, 76029189U, 3654602809U, 3873151461U, 530742520U, 3299628645U, 4096336452U, 1126891415U,
			2878612391U, 4237533241U, 1700485571U, 2399980690U, 4293915773U, 2240044497U, 1873313359U, 4264355552U, 2734768916U, 1309151649U,
			4149444226U, 3174756917U, 718787259U, 3951481745U
		};

		// Token: 0x04000039 RID: 57
		internal static object YBSYPhtPcy = null;

		// Token: 0x0400003A RID: 58
		private static bool PteYSIYDHW = false;

		// Token: 0x0400003B RID: 59
		private static object hYPYzGuBMe = null;

		// Token: 0x0400003C RID: 60
		[sdwn9hocwBVuZe0IsL.uyeeKGMr794smK85bsN(typeof(sdwn9hocwBVuZe0IsL.uyeeKGMr794smK85bsN.KlrhOjMqR8wr99J7sAl<object>[]))]
		private static bool ibcYKY6AJa = false;

		// Token: 0x0400003D RID: 61
		private static List<int> GYkYL5BFGT = null;

		// Token: 0x0200000B RID: 11
		private sealed class netv6EMTYjdmvksA6js : MulticastDelegate
		{
			// Token: 0x060000EE RID: 238
			public extern netv6EMTYjdmvksA6js(object \u0020, IntPtr \u0020);

			// Token: 0x060000EF RID: 239
			public extern void Invoke(object o);

			// Token: 0x060000F0 RID: 240
			public extern IAsyncResult BeginInvoke(object o, AsyncCallback callback, object @object);

			// Token: 0x060000F1 RID: 241
			public extern void EndInvoke(IAsyncResult result);

			// Token: 0x060000F2 RID: 242 RVA: 0x0000B2D8 File Offset: 0x000094D8
			static netv6EMTYjdmvksA6js()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x0200000C RID: 12
		internal class uyeeKGMr794smK85bsN : Attribute
		{
			// Token: 0x060000F3 RID: 243 RVA: 0x0000B2E0 File Offset: 0x000094E0
			[MethodImpl(MethodImplOptions.NoInlining)]
			public uyeeKGMr794smK85bsN(object \u0020)
			{
			}

			// Token: 0x060000F4 RID: 244 RVA: 0x0000B2E8 File Offset: 0x000094E8
			static uyeeKGMr794smK85bsN()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}

			// Token: 0x0200000D RID: 13
			internal class KlrhOjMqR8wr99J7sAl<XFn2o5M4cOk0HT4OoQm>
			{
				// Token: 0x060000F5 RID: 245 RVA: 0x0000B2F0 File Offset: 0x000094F0
				[MethodImpl(MethodImplOptions.NoInlining)]
				public KlrhOjMqR8wr99J7sAl()
				{
				}

				// Token: 0x060000F6 RID: 246 RVA: 0x0000B300 File Offset: 0x00009500
				[MethodImpl(MethodImplOptions.NoInlining)]
				static KlrhOjMqR8wr99J7sAl()
				{
					sdwn9hocwBVuZe0IsL.K2lYMhew6a();
					yk8DB4Mw7hLgRvWNhtu.AAbQkLp5mw();
				}

				// Token: 0x060000F7 RID: 247 RVA: 0x0000B30C File Offset: 0x0000950C
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool MScOxlsO88rk36cqQYF()
				{
					return true;
				}

				// Token: 0x060000F8 RID: 248 RVA: 0x0000B314 File Offset: 0x00009514
				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static object lwRxtTsEGyr42xLPmwq()
				{
					return null;
				}

				// Token: 0x0400003E RID: 62
				private static object Py2fKQsh2gKCpXfg49M;
			}
		}

		// Token: 0x0200000E RID: 14
		internal class wbVAfVMmqUxU4ZmHDSX
		{
			// Token: 0x060000F9 RID: 249 RVA: 0x0000B31C File Offset: 0x0000951C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static string rioM6L3I7K(object \u0020, object \u0020)
			{
				return null;
			}

			// Token: 0x060000FA RID: 250 RVA: 0x0000B32C File Offset: 0x0000952C
			[MethodImpl(MethodImplOptions.NoInlining)]
			public wbVAfVMmqUxU4ZmHDSX()
			{
			}

			// Token: 0x060000FB RID: 251 RVA: 0x0000B334 File Offset: 0x00009534
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object Byb8L2sbkr4dE5d800X()
			{
				return null;
			}

			// Token: 0x060000FC RID: 252 RVA: 0x0000B33C File Offset: 0x0000953C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object H3x7rUsdj9UAgpI9K96(object A_0, object A_1)
			{
				return null;
			}

			// Token: 0x060000FD RID: 253 RVA: 0x0000B344 File Offset: 0x00009544
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void TVvp2ksIHaBdUTkmnJ7(object A_0, RuntimeFieldHandle A_1)
			{
			}

			// Token: 0x060000FE RID: 254 RVA: 0x0000B34C File Offset: 0x0000954C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object cUAOOWsN3Q1oTlfTInj(object A_0)
			{
				return null;
			}

			// Token: 0x060000FF RID: 255 RVA: 0x0000B354 File Offset: 0x00009554
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void dW6tJksJ4aC57lYF4hQ(object A_0, object A_1)
			{
			}

			// Token: 0x06000100 RID: 256 RVA: 0x0000B35C File Offset: 0x0000955C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void kkqlLysG56p5ddX4YIA(object A_0, object A_1)
			{
			}

			// Token: 0x06000101 RID: 257 RVA: 0x0000B364 File Offset: 0x00009564
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object q403FVsBtYNQMI3oSuA(object A_0)
			{
				return null;
			}

			// Token: 0x06000102 RID: 258 RVA: 0x0000B36C File Offset: 0x0000956C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void eLe28xsedPN5rbFJFBp(object A_0)
			{
			}

			// Token: 0x06000103 RID: 259 RVA: 0x0000B374 File Offset: 0x00009574
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object J2XVwFsQr6HfyboPuQ4(object A_0)
			{
				return null;
			}

			// Token: 0x06000104 RID: 260 RVA: 0x0000B37C File Offset: 0x0000957C
			static wbVAfVMmqUxU4ZmHDSX()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x0200000F RID: 15
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal sealed class K0CWWhMlGjd9LcqDtVJ : MulticastDelegate
		{
			// Token: 0x06000105 RID: 261
			public extern K0CWWhMlGjd9LcqDtVJ(object \u0020, IntPtr \u0020);

			// Token: 0x06000106 RID: 262
			public extern uint Invoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

			// Token: 0x06000107 RID: 263
			public extern IAsyncResult BeginInvoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode, AsyncCallback callback, object @object);

			// Token: 0x06000108 RID: 264
			public extern uint EndInvoke(ref uint nativeSizeOfCode, IAsyncResult result);

			// Token: 0x06000109 RID: 265 RVA: 0x0000B384 File Offset: 0x00009584
			static K0CWWhMlGjd9LcqDtVJ()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x02000010 RID: 16
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class Jr52UqM2IsP0CX1iOrf : MulticastDelegate
		{
			// Token: 0x0600010A RID: 266
			public extern Jr52UqM2IsP0CX1iOrf(object \u0020, IntPtr \u0020);

			// Token: 0x0600010B RID: 267
			public extern IntPtr Invoke();

			// Token: 0x0600010C RID: 268
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x0600010D RID: 269
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600010E RID: 270 RVA: 0x0000B38C File Offset: 0x0000958C
			static Jr52UqM2IsP0CX1iOrf()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x02000011 RID: 17
		internal struct fRw86wMffvVYO8Ce8dA
		{
			// Token: 0x0400003F RID: 63
			internal bool OlHMhVQ03F;

			// Token: 0x04000040 RID: 64
			internal byte[] coEMOgfFUM;
		}

		// Token: 0x02000012 RID: 18
		internal class MCRQrIMElFcjUmhrYwF
		{
			// Token: 0x0600010F RID: 271 RVA: 0x0000B394 File Offset: 0x00009594
			[MethodImpl(MethodImplOptions.NoInlining)]
			public MCRQrIMElFcjUmhrYwF(Stream \u0020)
			{
				this.umaMdTx54w = new BinaryReader(\u0020);
			}

			// Token: 0x06000110 RID: 272 RVA: 0x0000B3B0 File Offset: 0x000095B0
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal Stream nW4lBacjpc()
			{
				return this.umaMdTx54w.BaseStream;
			}

			// Token: 0x06000111 RID: 273 RVA: 0x0000B3C4 File Offset: 0x000095C4
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal byte[] bfWMH19ZNT(int \u0020)
			{
				return sdwn9hocwBVuZe0IsL.MCRQrIMElFcjUmhrYwF.DiIyJFsUQ8WRFAB3CFP(this.umaMdTx54w, \u0020);
			}

			// Token: 0x06000112 RID: 274 RVA: 0x0000B3DC File Offset: 0x000095DC
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int wqSMsuwx02(byte[] \u0020, int \u0020, int \u0020)
			{
				return this.umaMdTx54w.Read(\u0020, \u0020, \u0020);
			}

			// Token: 0x06000113 RID: 275 RVA: 0x0000B3F4 File Offset: 0x000095F4
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int oqiMvIw9LD()
			{
				return sdwn9hocwBVuZe0IsL.MCRQrIMElFcjUmhrYwF.KWscFEs08wous5grkuh(this.umaMdTx54w);
			}

			// Token: 0x06000114 RID: 276 RVA: 0x0000B408 File Offset: 0x00009608
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void jMOMb8BjZg()
			{
				this.umaMdTx54w.Close();
			}

			// Token: 0x06000115 RID: 277 RVA: 0x0000B41C File Offset: 0x0000961C
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static object DiIyJFsUQ8WRFAB3CFP(object A_0, int A_1)
			{
				return A_0.ReadBytes(A_1);
			}

			// Token: 0x06000116 RID: 278 RVA: 0x0000B434 File Offset: 0x00009634
			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static int KWscFEs08wous5grkuh(object A_0)
			{
				return A_0.ReadInt32();
			}

			// Token: 0x06000117 RID: 279 RVA: 0x0000B448 File Offset: 0x00009648
			static MCRQrIMElFcjUmhrYwF()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}

			// Token: 0x04000041 RID: 65
			private object umaMdTx54w;
		}

		// Token: 0x02000013 RID: 19
		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private sealed class WNZO20MIfpZ2DDCI4LQ : MulticastDelegate
		{
			// Token: 0x06000118 RID: 280
			public extern WNZO20MIfpZ2DDCI4LQ(object \u0020, IntPtr \u0020);

			// Token: 0x06000119 RID: 281
			public extern IntPtr Invoke(IntPtr hModule, string lpName, uint lpType);

			// Token: 0x0600011A RID: 282
			public extern IAsyncResult BeginInvoke(IntPtr hModule, string lpName, uint lpType, AsyncCallback callback, object @object);

			// Token: 0x0600011B RID: 283
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x0600011C RID: 284 RVA: 0x0000B450 File Offset: 0x00009650
			static WNZO20MIfpZ2DDCI4LQ()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x02000014 RID: 20
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class rtf8yfMNiDKYrfAbwqV : MulticastDelegate
		{
			// Token: 0x0600011D RID: 285
			public extern rtf8yfMNiDKYrfAbwqV(object \u0020, IntPtr \u0020);

			// Token: 0x0600011E RID: 286
			public extern IntPtr Invoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x0600011F RID: 287
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect, AsyncCallback callback, object @object);

			// Token: 0x06000120 RID: 288
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000121 RID: 289 RVA: 0x0000B458 File Offset: 0x00009658
			static rtf8yfMNiDKYrfAbwqV()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x02000015 RID: 21
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class foVJYOMJi2t8eEnRA1b : MulticastDelegate
		{
			// Token: 0x06000122 RID: 290
			public extern foVJYOMJi2t8eEnRA1b(object \u0020, IntPtr \u0020);

			// Token: 0x06000123 RID: 291
			public extern int Invoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

			// Token: 0x06000124 RID: 292
			public extern IAsyncResult BeginInvoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten, AsyncCallback callback, object @object);

			// Token: 0x06000125 RID: 293
			public extern int EndInvoke(out IntPtr lpNumberOfBytesWritten, IAsyncResult result);

			// Token: 0x06000126 RID: 294 RVA: 0x0000B460 File Offset: 0x00009660
			static foVJYOMJi2t8eEnRA1b()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x02000016 RID: 22
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class HmAJoPMGsgrVylB6Dpe : MulticastDelegate
		{
			// Token: 0x06000127 RID: 295
			public extern HmAJoPMGsgrVylB6Dpe(object \u0020, IntPtr \u0020);

			// Token: 0x06000128 RID: 296
			public extern int Invoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

			// Token: 0x06000129 RID: 297
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect, AsyncCallback callback, object @object);

			// Token: 0x0600012A RID: 298
			public extern int EndInvoke(ref int lpflOldProtect, IAsyncResult result);

			// Token: 0x0600012B RID: 299 RVA: 0x0000B468 File Offset: 0x00009668
			static HmAJoPMGsgrVylB6Dpe()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x02000017 RID: 23
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class Ct161RMBoYLcX58Vao3 : MulticastDelegate
		{
			// Token: 0x0600012C RID: 300
			public extern Ct161RMBoYLcX58Vao3(object \u0020, IntPtr \u0020);

			// Token: 0x0600012D RID: 301
			public extern IntPtr Invoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x0600012E RID: 302
			public extern IAsyncResult BeginInvoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId, AsyncCallback callback, object @object);

			// Token: 0x0600012F RID: 303
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000130 RID: 304 RVA: 0x0000B470 File Offset: 0x00009670
			static Ct161RMBoYLcX58Vao3()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x02000018 RID: 24
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class sRAVG8MeaCnv2CQ0bst : MulticastDelegate
		{
			// Token: 0x06000131 RID: 305
			public extern sRAVG8MeaCnv2CQ0bst(object \u0020, IntPtr \u0020);

			// Token: 0x06000132 RID: 306
			public extern int Invoke(IntPtr ptr);

			// Token: 0x06000133 RID: 307
			public extern IAsyncResult BeginInvoke(IntPtr ptr, AsyncCallback callback, object @object);

			// Token: 0x06000134 RID: 308
			public extern int EndInvoke(IAsyncResult result);

			// Token: 0x06000135 RID: 309 RVA: 0x0000B478 File Offset: 0x00009678
			static sRAVG8MeaCnv2CQ0bst()
			{
				sdwn9hocwBVuZe0IsL.K2lYMhew6a();
			}
		}

		// Token: 0x02000019 RID: 25
		[Flags]
		private enum GiLnjpMQfIeCAY8NZMd
		{

		}
	}
}
