Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint.My.Resources
	' Token: 0x0200000F RID: 15
	<GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")>
	<DebuggerNonUserCode()>
	<CompilerGenerated()>
	<HideModuleName()>
	Friend Module Resources
		' Token: 0x170001A1 RID: 417
		' (get) Token: 0x06000362 RID: 866 RVA: 0x00081498 File Offset: 0x0007F698
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		Friend ReadOnly Property ResourceManager As ResourceManager
			Get
				Dim flag As Boolean = Object.ReferenceEquals(Resources.resourceMan, Nothing)
				If flag Then
					Dim resMgr As ResourceManager = New ResourceManager("BillPoint.Resources", GetType(Resources).Assembly)
					Resources.resourceMan = resMgr
				End If
				Return Resources.resourceMan
			End Get
		End Property

		' Token: 0x170001A2 RID: 418
		' (get) Token: 0x06000363 RID: 867 RVA: 0x000814E0 File Offset: 0x0007F6E0
		' (set) Token: 0x06000364 RID: 868 RVA: 0x0000914A File Offset: 0x0000734A
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		Friend Property Culture As CultureInfo
			Get
				Return Resources.resourceCulture
			End Get
			Set(value As CultureInfo)
				Resources.resourceCulture = value
			End Set
		End Property

		' Token: 0x170001A3 RID: 419
		' (get) Token: 0x06000365 RID: 869 RVA: 0x000814F8 File Offset: 0x0007F6F8
		Friend ReadOnly Property _0x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("0x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001A4 RID: 420
		' (get) Token: 0x06000366 RID: 870 RVA: 0x0008152C File Offset: 0x0007F72C
		Friend ReadOnly Property _1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001A5 RID: 421
		' (get) Token: 0x06000367 RID: 871 RVA: 0x00081560 File Offset: 0x0007F760
		Friend ReadOnly Property _1__16_ As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("1 (16)", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001A6 RID: 422
		' (get) Token: 0x06000368 RID: 872 RVA: 0x00081594 File Offset: 0x0007F794
		Friend ReadOnly Property _11 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("11", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001A7 RID: 423
		' (get) Token: 0x06000369 RID: 873 RVA: 0x000815C8 File Offset: 0x0007F7C8
		Friend ReadOnly Property _12 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("12", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001A8 RID: 424
		' (get) Token: 0x0600036A RID: 874 RVA: 0x000815FC File Offset: 0x0007F7FC
		Friend ReadOnly Property _13 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("13", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001A9 RID: 425
		' (get) Token: 0x0600036B RID: 875 RVA: 0x00081630 File Offset: 0x0007F830
		Friend ReadOnly Property _1x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("1x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001AA RID: 426
		' (get) Token: 0x0600036C RID: 876 RVA: 0x00081664 File Offset: 0x0007F864
		Friend ReadOnly Property _2 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001AB RID: 427
		' (get) Token: 0x0600036D RID: 877 RVA: 0x00081698 File Offset: 0x0007F898
		Friend ReadOnly Property _2023_Bill_Summary_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Bill Summary copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001AC RID: 428
		' (get) Token: 0x0600036E RID: 878 RVA: 0x000816CC File Offset: 0x0007F8CC
		Friend ReadOnly Property _2023_Cash_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Cash copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001AD RID: 429
		' (get) Token: 0x0600036F RID: 879 RVA: 0x00081700 File Offset: 0x0007F900
		Friend ReadOnly Property _2023_Coupon_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Coupon copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001AE RID: 430
		' (get) Token: 0x06000370 RID: 880 RVA: 0x00081734 File Offset: 0x0007F934
		Friend ReadOnly Property _2023_Credi_Customer_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Credi Customer copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001AF RID: 431
		' (get) Token: 0x06000371 RID: 881 RVA: 0x00081768 File Offset: 0x0007F968
		Friend ReadOnly Property _2023_Credit_Card_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Credit Card copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B0 RID: 432
		' (get) Token: 0x06000372 RID: 882 RVA: 0x0008179C File Offset: 0x0007F99C
		Friend ReadOnly Property _2023_Debit_Card_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Debit Card copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B1 RID: 433
		' (get) Token: 0x06000373 RID: 883 RVA: 0x000817D0 File Offset: 0x0007F9D0
		Friend ReadOnly Property _2023_Get_QR_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Get QR copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B2 RID: 434
		' (get) Token: 0x06000374 RID: 884 RVA: 0x00081804 File Offset: 0x0007FA04
		Friend ReadOnly Property _2023_Gift_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Gift copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B3 RID: 435
		' (get) Token: 0x06000375 RID: 885 RVA: 0x00081838 File Offset: 0x0007FA38
		Friend ReadOnly Property _2023_Loyalty_Card_Discount_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Loyalty Card Discount copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B4 RID: 436
		' (get) Token: 0x06000376 RID: 886 RVA: 0x0008186C File Offset: 0x0007FA6C
		Friend ReadOnly Property _2023_Loyalty_Card_Discount_copy1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Loyalty Card Discount copy1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B5 RID: 437
		' (get) Token: 0x06000377 RID: 887 RVA: 0x000818A0 File Offset: 0x0007FAA0
		Friend ReadOnly Property _2023_Sale_2_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Sale 2 copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B6 RID: 438
		' (get) Token: 0x06000378 RID: 888 RVA: 0x000818D4 File Offset: 0x0007FAD4
		Friend ReadOnly Property _2023_UP_QR_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_UP-QR copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B7 RID: 439
		' (get) Token: 0x06000379 RID: 889 RVA: 0x00081908 File Offset: 0x0007FB08
		Friend ReadOnly Property _2023_Wallet_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2023_Wallet copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B8 RID: 440
		' (get) Token: 0x0600037A RID: 890 RVA: 0x0008193C File Offset: 0x0007FB3C
		Friend ReadOnly Property _2x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("2x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001B9 RID: 441
		' (get) Token: 0x0600037B RID: 891 RVA: 0x00081970 File Offset: 0x0007FB70
		Friend ReadOnly Property _3x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("3x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001BA RID: 442
		' (get) Token: 0x0600037C RID: 892 RVA: 0x000819A4 File Offset: 0x0007FBA4
		Friend ReadOnly Property _4x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("4x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001BB RID: 443
		' (get) Token: 0x0600037D RID: 893 RVA: 0x000819D8 File Offset: 0x0007FBD8
		Friend ReadOnly Property _4x1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("4x1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001BC RID: 444
		' (get) Token: 0x0600037E RID: 894 RVA: 0x00081A0C File Offset: 0x0007FC0C
		Friend ReadOnly Property _4x2 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("4x2", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001BD RID: 445
		' (get) Token: 0x0600037F RID: 895 RVA: 0x00081A40 File Offset: 0x0007FC40
		Friend ReadOnly Property _5278658 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("5278658", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001BE RID: 446
		' (get) Token: 0x06000380 RID: 896 RVA: 0x00081A74 File Offset: 0x0007FC74
		Friend ReadOnly Property _5x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("5x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001BF RID: 447
		' (get) Token: 0x06000381 RID: 897 RVA: 0x00081AA8 File Offset: 0x0007FCA8
		Friend ReadOnly Property _6x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("6x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C0 RID: 448
		' (get) Token: 0x06000382 RID: 898 RVA: 0x00081ADC File Offset: 0x0007FCDC
		Friend ReadOnly Property _7x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("7x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C1 RID: 449
		' (get) Token: 0x06000383 RID: 899 RVA: 0x00081B10 File Offset: 0x0007FD10
		Friend ReadOnly Property _8x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("8x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C2 RID: 450
		' (get) Token: 0x06000384 RID: 900 RVA: 0x00081B44 File Offset: 0x0007FD44
		Friend ReadOnly Property _9 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("9", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C3 RID: 451
		' (get) Token: 0x06000385 RID: 901 RVA: 0x00081B78 File Offset: 0x0007FD78
		Friend ReadOnly Property _91 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("91", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C4 RID: 452
		' (get) Token: 0x06000386 RID: 902 RVA: 0x00081BAC File Offset: 0x0007FDAC
		Friend ReadOnly Property _911 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("911", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C5 RID: 453
		' (get) Token: 0x06000387 RID: 903 RVA: 0x00081BE0 File Offset: 0x0007FDE0
		Friend ReadOnly Property _9x As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("9x", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C6 RID: 454
		' (get) Token: 0x06000388 RID: 904 RVA: 0x00081C14 File Offset: 0x0007FE14
		Friend ReadOnly Property _VARIANT As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("VARIANT", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C7 RID: 455
		' (get) Token: 0x06000389 RID: 905 RVA: 0x00081C48 File Offset: 0x0007FE48
		Friend ReadOnly Property Action_Security_ChangePassword_32x32 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Action_Security_ChangePassword_32x32", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C8 RID: 456
		' (get) Token: 0x0600038A RID: 906 RVA: 0x00081C7C File Offset: 0x0007FE7C
		Friend ReadOnly Property Actions_user_group_new_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Actions-user-group-new-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001C9 RID: 457
		' (get) Token: 0x0600038B RID: 907 RVA: 0x00081CB0 File Offset: 0x0007FEB0
		Friend ReadOnly Property Activate As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Activate", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001CA RID: 458
		' (get) Token: 0x0600038C RID: 908 RVA: 0x00081CE4 File Offset: 0x0007FEE4
		Friend ReadOnly Property Add_Product_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Add Product copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001CB RID: 459
		' (get) Token: 0x0600038D RID: 909 RVA: 0x00081D18 File Offset: 0x0007FF18
		Friend ReadOnly Property add_stock As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("add stock", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001CC RID: 460
		' (get) Token: 0x0600038E RID: 910 RVA: 0x00081D4C File Offset: 0x0007FF4C
		Friend ReadOnly Property AddFile_32x32 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("AddFile_32x32", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001CD RID: 461
		' (get) Token: 0x0600038F RID: 911 RVA: 0x00081D80 File Offset: 0x0007FF80
		Friend ReadOnly Property Admin_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Admin-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001CE RID: 462
		' (get) Token: 0x06000390 RID: 912 RVA: 0x00081DB4 File Offset: 0x0007FFB4
		Friend ReadOnly Property Al_Masafi_5_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Al Masafi 5 copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001CF RID: 463
		' (get) Token: 0x06000391 RID: 913 RVA: 0x00081DE8 File Offset: 0x0007FFE8
		Friend ReadOnly Property AlMasafi As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("AlMasafi", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D0 RID: 464
		' (get) Token: 0x06000392 RID: 914 RVA: 0x00081E1C File Offset: 0x0008001C
		Friend ReadOnly Property Apply_16x16 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Apply_16x16", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D1 RID: 465
		' (get) Token: 0x06000393 RID: 915 RVA: 0x00081E50 File Offset: 0x00080050
		Friend ReadOnly Property background_screen As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("background screen", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D2 RID: 466
		' (get) Token: 0x06000394 RID: 916 RVA: 0x00081E84 File Offset: 0x00080084
		Friend ReadOnly Property BARCODE_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("BARCODE_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D3 RID: 467
		' (get) Token: 0x06000395 RID: 917 RVA: 0x00081EB8 File Offset: 0x000800B8
		Friend ReadOnly Property basket_full_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("basket-full-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D4 RID: 468
		' (get) Token: 0x06000396 RID: 918 RVA: 0x00081EEC File Offset: 0x000800EC
		Friend ReadOnly Property BBtn As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("BBtn", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D5 RID: 469
		' (get) Token: 0x06000397 RID: 919 RVA: 0x00081F20 File Offset: 0x00080120
		Friend ReadOnly Property BILL_PREVIEW As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("BILL PREVIEW", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D6 RID: 470
		' (get) Token: 0x06000398 RID: 920 RVA: 0x00081F54 File Offset: 0x00080154
		Friend ReadOnly Property BILL_SUMMARY As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("BILL SUMMARY", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D7 RID: 471
		' (get) Token: 0x06000399 RID: 921 RVA: 0x00081F88 File Offset: 0x00080188
		Friend ReadOnly Property Bill_Summary_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Bill Summary copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D8 RID: 472
		' (get) Token: 0x0600039A RID: 922 RVA: 0x00081FBC File Offset: 0x000801BC
		Friend ReadOnly Property Billing As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Billing", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001D9 RID: 473
		' (get) Token: 0x0600039B RID: 923 RVA: 0x00081FF0 File Offset: 0x000801F0
		Friend ReadOnly Property Billing_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Billing-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001DA RID: 474
		' (get) Token: 0x0600039C RID: 924 RVA: 0x00082024 File Offset: 0x00080224
		Friend ReadOnly Property BlueL As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("BlueL", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001DB RID: 475
		' (get) Token: 0x0600039D RID: 925 RVA: 0x00082058 File Offset: 0x00080258
		Friend ReadOnly Property BrBtn As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("BrBtn", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001DC RID: 476
		' (get) Token: 0x0600039E RID: 926 RVA: 0x0008208C File Offset: 0x0008028C
		Friend ReadOnly Property Bring_to_Purchase_Entry As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Bring to Purchase Entry", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001DD RID: 477
		' (get) Token: 0x0600039F RID: 927 RVA: 0x000820C0 File Offset: 0x000802C0
		Friend ReadOnly Property Bulk_Edit_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Bulk Edit copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001DE RID: 478
		' (get) Token: 0x060003A0 RID: 928 RVA: 0x000820F4 File Offset: 0x000802F4
		Friend ReadOnly Property Bulk_Image_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Bulk Image copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001DF RID: 479
		' (get) Token: 0x060003A1 RID: 929 RVA: 0x00082128 File Offset: 0x00080328
		Friend ReadOnly Property BULK_IMAGE_UPDATE_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("BULK IMAGE UPDATE_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E0 RID: 480
		' (get) Token: 0x060003A2 RID: 930 RVA: 0x0008215C File Offset: 0x0008035C
		Friend ReadOnly Property Button_Close_icon__1_ As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Button-Close-icon (1)", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E1 RID: 481
		' (get) Token: 0x060003A3 RID: 931 RVA: 0x00082190 File Offset: 0x00080390
		Friend ReadOnly Property Button_Delete_icon1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Button-Delete-icon1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E2 RID: 482
		' (get) Token: 0x060003A4 RID: 932 RVA: 0x000821C4 File Offset: 0x000803C4
		Friend ReadOnly Property Button_Delete_icon11 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Button-Delete-icon11", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E3 RID: 483
		' (get) Token: 0x060003A5 RID: 933 RVA: 0x000821F8 File Offset: 0x000803F8
		Friend ReadOnly Property c1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("c1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E4 RID: 484
		' (get) Token: 0x060003A6 RID: 934 RVA: 0x0008222C File Offset: 0x0008042C
		Friend ReadOnly Property calc As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("calc", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E5 RID: 485
		' (get) Token: 0x060003A7 RID: 935 RVA: 0x00082260 File Offset: 0x00080460
		Friend ReadOnly Property cancel_512 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("cancel-512", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E6 RID: 486
		' (get) Token: 0x060003A8 RID: 936 RVA: 0x00082294 File Offset: 0x00080494
		Friend ReadOnly Property CART__1_ As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("CART (1)", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E7 RID: 487
		' (get) Token: 0x060003A9 RID: 937 RVA: 0x000822C8 File Offset: 0x000804C8
		Friend ReadOnly Property CASH As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("CASH", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E8 RID: 488
		' (get) Token: 0x060003AA RID: 938 RVA: 0x000822FC File Offset: 0x000804FC
		Friend ReadOnly Property Cash_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Cash copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001E9 RID: 489
		' (get) Token: 0x060003AB RID: 939 RVA: 0x00082330 File Offset: 0x00080530
		Friend ReadOnly Property CASH1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("CASH1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001EA RID: 490
		' (get) Token: 0x060003AC RID: 940 RVA: 0x00082364 File Offset: 0x00080564
		Friend ReadOnly Property Category_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Category copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001EB RID: 491
		' (get) Token: 0x060003AD RID: 941 RVA: 0x00082398 File Offset: 0x00080598
		Friend ReadOnly Property CATEGORY_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("CATEGORY_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001EC RID: 492
		' (get) Token: 0x060003AE RID: 942 RVA: 0x000823CC File Offset: 0x000805CC
		Friend ReadOnly Property Close_32x32 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Close_32x32", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001ED RID: 493
		' (get) Token: 0x060003AF RID: 943 RVA: 0x00082400 File Offset: 0x00080600
		Friend ReadOnly Property Close_32x321 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Close_32x321", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001EE RID: 494
		' (get) Token: 0x060003B0 RID: 944 RVA: 0x00082434 File Offset: 0x00080634
		Friend ReadOnly Property Company1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Company1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001EF RID: 495
		' (get) Token: 0x060003B1 RID: 945 RVA: 0x00082468 File Offset: 0x00080668
		Friend ReadOnly Property Compose_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Compose copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F0 RID: 496
		' (get) Token: 0x060003B2 RID: 946 RVA: 0x0008249C File Offset: 0x0008069C
		Friend ReadOnly Property COUPON As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("COUPON", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F1 RID: 497
		' (get) Token: 0x060003B3 RID: 947 RVA: 0x000824D0 File Offset: 0x000806D0
		Friend ReadOnly Property Coupon_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Coupon copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F2 RID: 498
		' (get) Token: 0x060003B4 RID: 948 RVA: 0x00082504 File Offset: 0x00080704
		Friend ReadOnly Property Coupon_copy1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Coupon copy1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F3 RID: 499
		' (get) Token: 0x060003B5 RID: 949 RVA: 0x00082538 File Offset: 0x00080738
		Friend ReadOnly Property Coupon_copy2 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Coupon copy2", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F4 RID: 500
		' (get) Token: 0x060003B6 RID: 950 RVA: 0x0008256C File Offset: 0x0008076C
		Friend ReadOnly Property Coupon_copy3 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Coupon copy3", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F5 RID: 501
		' (get) Token: 0x060003B7 RID: 951 RVA: 0x000825A0 File Offset: 0x000807A0
		Friend ReadOnly Property Credi_Customer_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Credi Customer copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F6 RID: 502
		' (get) Token: 0x060003B8 RID: 952 RVA: 0x000825D4 File Offset: 0x000807D4
		Friend ReadOnly Property CREDIT_CARD As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("CREDIT CARD", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F7 RID: 503
		' (get) Token: 0x060003B9 RID: 953 RVA: 0x00082608 File Offset: 0x00080808
		Friend ReadOnly Property Credit_Card_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Credit Card copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F8 RID: 504
		' (get) Token: 0x060003BA RID: 954 RVA: 0x0008263C File Offset: 0x0008083C
		Friend ReadOnly Property CREDIT_CUS As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("CREDIT CUS", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001F9 RID: 505
		' (get) Token: 0x060003BB RID: 955 RVA: 0x00082670 File Offset: 0x00080870
		Friend ReadOnly Property CREDITPAY As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("CREDITPAY", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001FA RID: 506
		' (get) Token: 0x060003BC RID: 956 RVA: 0x000826A4 File Offset: 0x000808A4
		Friend ReadOnly Property Customer_Format As Byte()
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Customer_Format", Resources.resourceCulture))
				Return CType(objectValue, Byte())
			End Get
		End Property

		' Token: 0x170001FB RID: 507
		' (get) Token: 0x060003BD RID: 957 RVA: 0x000826D8 File Offset: 0x000808D8
		Friend ReadOnly Property Database As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Database", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001FC RID: 508
		' (get) Token: 0x060003BE RID: 958 RVA: 0x0008270C File Offset: 0x0008090C
		Friend ReadOnly Property Database_Active_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Database-Active-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001FD RID: 509
		' (get) Token: 0x060003BF RID: 959 RVA: 0x00082740 File Offset: 0x00080940
		Friend ReadOnly Property Database_Active_icon1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Database-Active-icon1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001FE RID: 510
		' (get) Token: 0x060003C0 RID: 960 RVA: 0x00082774 File Offset: 0x00080974
		Friend ReadOnly Property DEBIT_CARD As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("DEBIT CARD", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170001FF RID: 511
		' (get) Token: 0x060003C1 RID: 961 RVA: 0x000827A8 File Offset: 0x000809A8
		Friend ReadOnly Property Debit_Card_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Debit Card copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000200 RID: 512
		' (get) Token: 0x060003C2 RID: 962 RVA: 0x000827DC File Offset: 0x000809DC
		Friend ReadOnly Property Delete_32x32 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Delete_32x32", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000201 RID: 513
		' (get) Token: 0x060003C3 RID: 963 RVA: 0x00082810 File Offset: 0x00080A10
		Friend ReadOnly Property Delete_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Delete copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000202 RID: 514
		' (get) Token: 0x060003C4 RID: 964 RVA: 0x00082844 File Offset: 0x00080A44
		Friend ReadOnly Property Delete_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Delete copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000203 RID: 515
		' (get) Token: 0x060003C5 RID: 965 RVA: 0x00082878 File Offset: 0x00080A78
		Friend ReadOnly Property Delete_copy1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Delete copy1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000204 RID: 516
		' (get) Token: 0x060003C6 RID: 966 RVA: 0x000828AC File Offset: 0x00080AAC
		Friend ReadOnly Property Delete_copy2 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Delete copy2", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000205 RID: 517
		' (get) Token: 0x060003C7 RID: 967 RVA: 0x000828E0 File Offset: 0x00080AE0
		Friend ReadOnly Property DELETE_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("DELETE_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000206 RID: 518
		' (get) Token: 0x060003C8 RID: 968 RVA: 0x00082914 File Offset: 0x00080B14
		Friend ReadOnly Property Document As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Document", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000207 RID: 519
		' (get) Token: 0x060003C9 RID: 969 RVA: 0x00082948 File Offset: 0x00080B48
		Friend ReadOnly Property E_mail_Login_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("E-mail Login copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000208 RID: 520
		' (get) Token: 0x060003CA RID: 970 RVA: 0x0008297C File Offset: 0x00080B7C
		Friend ReadOnly Property E_way_Bill_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("E-way Bill copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000209 RID: 521
		' (get) Token: 0x060003CB RID: 971 RVA: 0x000829B0 File Offset: 0x00080BB0
		Friend ReadOnly Property edit As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("edit", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700020A RID: 522
		' (get) Token: 0x060003CC RID: 972 RVA: 0x000829E4 File Offset: 0x00080BE4
		Friend ReadOnly Property edit_file_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("edit-file-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700020B RID: 523
		' (get) Token: 0x060003CD RID: 973 RVA: 0x00082A18 File Offset: 0x00080C18
		Friend ReadOnly Property Edit_File_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Edit File_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700020C RID: 524
		' (get) Token: 0x060003CE RID: 974 RVA: 0x00082A4C File Offset: 0x00080C4C
		Friend ReadOnly Property Edit_File_pr1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Edit File_pr1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700020D RID: 525
		' (get) Token: 0x060003CF RID: 975 RVA: 0x00082A80 File Offset: 0x00080C80
		Friend ReadOnly Property Entypo_d83d_0__512 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Entypo_d83d(0)_512", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700020E RID: 526
		' (get) Token: 0x060003D0 RID: 976 RVA: 0x00082AB4 File Offset: 0x00080CB4
		Friend ReadOnly Property Entypo_e731_0__512 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Entypo_e731(0)_512", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700020F RID: 527
		' (get) Token: 0x060003D1 RID: 977 RVA: 0x00082AE8 File Offset: 0x00080CE8
		Friend ReadOnly Property Estimate_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Estimate copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000210 RID: 528
		' (get) Token: 0x060003D2 RID: 978 RVA: 0x00082B1C File Offset: 0x00080D1C
		Friend ReadOnly Property Estimate_copy1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Estimate copy1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000211 RID: 529
		' (get) Token: 0x060003D3 RID: 979 RVA: 0x00082B50 File Offset: 0x00080D50
		Friend ReadOnly Property Excel_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Excel-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000212 RID: 530
		' (get) Token: 0x060003D4 RID: 980 RVA: 0x00082B84 File Offset: 0x00080D84
		Friend ReadOnly Property Export_Excel_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Export Excel copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000213 RID: 531
		' (get) Token: 0x060003D5 RID: 981 RVA: 0x00082BB8 File Offset: 0x00080DB8
		Friend ReadOnly Property export_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("export_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000214 RID: 532
		' (get) Token: 0x060003D6 RID: 982 RVA: 0x00082BEC File Offset: 0x00080DEC
		Friend ReadOnly Property Extract_Data_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Extract Data copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000215 RID: 533
		' (get) Token: 0x060003D7 RID: 983 RVA: 0x00082C20 File Offset: 0x00080E20
		Friend ReadOnly Property fevicon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("fevicon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000216 RID: 534
		' (get) Token: 0x060003D8 RID: 984 RVA: 0x00082C54 File Offset: 0x00080E54
		Friend ReadOnly Property find_customer As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("find customer", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000217 RID: 535
		' (get) Token: 0x060003D9 RID: 985 RVA: 0x00082C88 File Offset: 0x00080E88
		Friend ReadOnly Property GBtn As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("GBtn", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000218 RID: 536
		' (get) Token: 0x060003DA RID: 986 RVA: 0x00082CBC File Offset: 0x00080EBC
		Friend ReadOnly Property Get_QR_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Get QR copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000219 RID: 537
		' (get) Token: 0x060003DB RID: 987 RVA: 0x00082CF0 File Offset: 0x00080EF0
		Friend ReadOnly Property GIFT As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("GIFT", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700021A RID: 538
		' (get) Token: 0x060003DC RID: 988 RVA: 0x00082D24 File Offset: 0x00080F24
		Friend ReadOnly Property Gift_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Gift copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700021B RID: 539
		' (get) Token: 0x060003DD RID: 989 RVA: 0x00082D58 File Offset: 0x00080F58
		Friend ReadOnly Property GiftCard As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("GiftCard", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700021C RID: 540
		' (get) Token: 0x060003DE RID: 990 RVA: 0x00082D8C File Offset: 0x00080F8C
		Friend ReadOnly Property gorila As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("gorila", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700021D RID: 541
		' (get) Token: 0x060003DF RID: 991 RVA: 0x00082DC0 File Offset: 0x00080FC0
		Friend ReadOnly Property GreenL As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("GreenL", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700021E RID: 542
		' (get) Token: 0x060003E0 RID: 992 RVA: 0x00082DF4 File Offset: 0x00080FF4
		Friend ReadOnly Property HHSoftTech As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("HHSoftTech", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700021F RID: 543
		' (get) Token: 0x060003E1 RID: 993 RVA: 0x00082E28 File Offset: 0x00081028
		Friend ReadOnly Property Hold_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Hold copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000220 RID: 544
		' (get) Token: 0x060003E2 RID: 994 RVA: 0x00082E5C File Offset: 0x0008105C
		Friend ReadOnly Property Hotels_B_512 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Hotels_B-512", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000221 RID: 545
		' (get) Token: 0x060003E3 RID: 995 RVA: 0x00082E90 File Offset: 0x00081090
		Friend ReadOnly Property Import_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Import copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000222 RID: 546
		' (get) Token: 0x060003E4 RID: 996 RVA: 0x00082EC4 File Offset: 0x000810C4
		Friend ReadOnly Property IMPORT_EXCEL_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("IMPORT EXCEL_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000223 RID: 547
		' (get) Token: 0x060003E5 RID: 997 RVA: 0x00082EF8 File Offset: 0x000810F8
		Friend ReadOnly Property Inbox_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Inbox copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000224 RID: 548
		' (get) Token: 0x060003E6 RID: 998 RVA: 0x00082F2C File Offset: 0x0008112C
		Friend ReadOnly Property Inventory_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Inventory-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000225 RID: 549
		' (get) Token: 0x060003E7 RID: 999 RVA: 0x00082F60 File Offset: 0x00081160
		Friend ReadOnly Property keyboard_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("keyboard-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000226 RID: 550
		' (get) Token: 0x060003E8 RID: 1000 RVA: 0x00082F94 File Offset: 0x00081194
		Friend ReadOnly Property keyboard_icon__1_ As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("keyboard-icon (1)", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000227 RID: 551
		' (get) Token: 0x060003E9 RID: 1001 RVA: 0x00082FC8 File Offset: 0x000811C8
		Friend ReadOnly Property loading As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("loading", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000228 RID: 552
		' (get) Token: 0x060003EA RID: 1002 RVA: 0x00082FFC File Offset: 0x000811FC
		Friend ReadOnly Property log_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("log-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000229 RID: 553
		' (get) Token: 0x060003EB RID: 1003 RVA: 0x00083030 File Offset: 0x00081230
		Friend ReadOnly Property Log_Out_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Log-Out-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700022A RID: 554
		' (get) Token: 0x060003EC RID: 1004 RVA: 0x00083064 File Offset: 0x00081264
		Friend ReadOnly Property login_512 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("login-512", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700022B RID: 555
		' (get) Token: 0x060003ED RID: 1005 RVA: 0x00083098 File Offset: 0x00081298
		Friend ReadOnly Property login_icon__1_ As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("login_icon (1)", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700022C RID: 556
		' (get) Token: 0x060003EE RID: 1006 RVA: 0x000830CC File Offset: 0x000812CC
		Friend ReadOnly Property login3 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("login3", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700022D RID: 557
		' (get) Token: 0x060003EF RID: 1007 RVA: 0x00083100 File Offset: 0x00081300
		Friend ReadOnly Property Logo As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Logo", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700022E RID: 558
		' (get) Token: 0x060003F0 RID: 1008 RVA: 0x00083134 File Offset: 0x00081334
		Friend ReadOnly Property logod As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("logod", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700022F RID: 559
		' (get) Token: 0x060003F1 RID: 1009 RVA: 0x00083168 File Offset: 0x00081368
		Friend ReadOnly Property logod1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("logod1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000230 RID: 560
		' (get) Token: 0x060003F2 RID: 1010 RVA: 0x0008319C File Offset: 0x0008139C
		Friend ReadOnly Property logod2 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("logod2", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000231 RID: 561
		' (get) Token: 0x060003F3 RID: 1011 RVA: 0x000831D0 File Offset: 0x000813D0
		Friend ReadOnly Property logoRetail As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("logoRetail", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000232 RID: 562
		' (get) Token: 0x060003F4 RID: 1012 RVA: 0x00083204 File Offset: 0x00081404
		Friend ReadOnly Property logout As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("logout", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000233 RID: 563
		' (get) Token: 0x060003F5 RID: 1013 RVA: 0x00083238 File Offset: 0x00081438
		Friend ReadOnly Property Logout_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Logout copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000234 RID: 564
		' (get) Token: 0x060003F6 RID: 1014 RVA: 0x0008326C File Offset: 0x0008146C
		Friend ReadOnly Property Logs As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Logs", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000235 RID: 565
		' (get) Token: 0x060003F7 RID: 1015 RVA: 0x000832A0 File Offset: 0x000814A0
		Friend ReadOnly Property Loyalty_Card_Discount_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Loyalty Card Discount copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000236 RID: 566
		' (get) Token: 0x060003F8 RID: 1016 RVA: 0x000832D4 File Offset: 0x000814D4
		Friend ReadOnly Property mas_inventory_system As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("mas-inventory-system", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000237 RID: 567
		' (get) Token: 0x060003F9 RID: 1017 RVA: 0x00083308 File Offset: 0x00081508
		Friend ReadOnly Property Maximise_32X32 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Maximise-32X32", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000238 RID: 568
		' (get) Token: 0x060003FA RID: 1018 RVA: 0x0008333C File Offset: 0x0008153C
		Friend ReadOnly Property messages_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("messages-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000239 RID: 569
		' (get) Token: 0x060003FB RID: 1019 RVA: 0x00083370 File Offset: 0x00081570
		Friend ReadOnly Property Minus_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Minus_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700023A RID: 570
		' (get) Token: 0x060003FC RID: 1020 RVA: 0x000833A4 File Offset: 0x000815A4
		Friend ReadOnly Property mmm As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("mmm", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700023B RID: 571
		' (get) Token: 0x060003FD RID: 1021 RVA: 0x000833D8 File Offset: 0x000815D8
		Friend ReadOnly Property ModernXP_09_Keyboard_icon__1_1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("ModernXP-09-Keyboard-icon (1)1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700023C RID: 572
		' (get) Token: 0x060003FE RID: 1022 RVA: 0x0008340C File Offset: 0x0008160C
		Friend ReadOnly Property money_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("money-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700023D RID: 573
		' (get) Token: 0x060003FF RID: 1023 RVA: 0x00083440 File Offset: 0x00081640
		Friend ReadOnly Property MoneyLeaf As Byte()
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("MoneyLeaf", Resources.resourceCulture))
				Return CType(objectValue, Byte())
			End Get
		End Property

		' Token: 0x1700023E RID: 574
		' (get) Token: 0x06000400 RID: 1024 RVA: 0x00083474 File Offset: 0x00081674
		Friend ReadOnly Property mpage As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("mpage", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700023F RID: 575
		' (get) Token: 0x06000401 RID: 1025 RVA: 0x000834A8 File Offset: 0x000816A8
		Friend ReadOnly Property Mreport As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Mreport", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000240 RID: 576
		' (get) Token: 0x06000402 RID: 1026 RVA: 0x000834DC File Offset: 0x000816DC
		Friend ReadOnly Property New_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("New copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000241 RID: 577
		' (get) Token: 0x06000403 RID: 1027 RVA: 0x00083510 File Offset: 0x00081710
		Friend ReadOnly Property New_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("New copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000242 RID: 578
		' (get) Token: 0x06000404 RID: 1028 RVA: 0x00083544 File Offset: 0x00081744
		Friend ReadOnly Property New_copy1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("New copy1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000243 RID: 579
		' (get) Token: 0x06000405 RID: 1029 RVA: 0x00083578 File Offset: 0x00081778
		Friend ReadOnly Property new_customers As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("new customers", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000244 RID: 580
		' (get) Token: 0x06000406 RID: 1030 RVA: 0x000835AC File Offset: 0x000817AC
		Friend ReadOnly Property NEW_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NEW_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000245 RID: 581
		' (get) Token: 0x06000407 RID: 1031 RVA: 0x000835E0 File Offset: 0x000817E0
		Friend ReadOnly Property New_Product_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("New Product copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000246 RID: 582
		' (get) Token: 0x06000408 RID: 1032 RVA: 0x00083614 File Offset: 0x00081814
		Friend ReadOnly Property NEW_PRODUCT_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NEW PRODUCT_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000247 RID: 583
		' (get) Token: 0x06000409 RID: 1033 RVA: 0x00083648 File Offset: 0x00081848
		Friend ReadOnly Property NEW_RECORD_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NEW RECORD_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000248 RID: 584
		' (get) Token: 0x0600040A RID: 1034 RVA: 0x0008367C File Offset: 0x0008187C
		Friend ReadOnly Property NewBlue As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NewBlue", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000249 RID: 585
		' (get) Token: 0x0600040B RID: 1035 RVA: 0x000836B0 File Offset: 0x000818B0
		Friend ReadOnly Property NewBrown As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NewBrown", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700024A RID: 586
		' (get) Token: 0x0600040C RID: 1036 RVA: 0x000836E4 File Offset: 0x000818E4
		Friend ReadOnly Property NewGreen As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NewGreen", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700024B RID: 587
		' (get) Token: 0x0600040D RID: 1037 RVA: 0x00083718 File Offset: 0x00081918
		Friend ReadOnly Property NewPink As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NewPink", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700024C RID: 588
		' (get) Token: 0x0600040E RID: 1038 RVA: 0x0008374C File Offset: 0x0008194C
		Friend ReadOnly Property NewRed As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NewRed", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700024D RID: 589
		' (get) Token: 0x0600040F RID: 1039 RVA: 0x00083780 File Offset: 0x00081980
		Friend ReadOnly Property NewSky As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NewSky", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700024E RID: 590
		' (get) Token: 0x06000410 RID: 1040 RVA: 0x000837B4 File Offset: 0x000819B4
		Friend ReadOnly Property NewViolate As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("NewViolate", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700024F RID: 591
		' (get) Token: 0x06000411 RID: 1041 RVA: 0x000837E8 File Offset: 0x000819E8
		Friend ReadOnly Property Next_16x16 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Next_16x16", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000250 RID: 592
		' (get) Token: 0x06000412 RID: 1042 RVA: 0x0008381C File Offset: 0x00081A1C
		Friend ReadOnly Property Noimage As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Noimage", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000251 RID: 593
		' (get) Token: 0x06000413 RID: 1043 RVA: 0x00083850 File Offset: 0x00081A50
		Friend ReadOnly Property Nologo As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Nologo", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000252 RID: 594
		' (get) Token: 0x06000414 RID: 1044 RVA: 0x00083884 File Offset: 0x00081A84
		Friend ReadOnly Property OBtn As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("OBtn", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000253 RID: 595
		' (get) Token: 0x06000415 RID: 1045 RVA: 0x000838B8 File Offset: 0x00081AB8
		Friend ReadOnly Property offer As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("offer", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000254 RID: 596
		' (get) Token: 0x06000416 RID: 1046 RVA: 0x000838EC File Offset: 0x00081AEC
		Friend ReadOnly Property Old_Bill_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Old Bill copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000255 RID: 597
		' (get) Token: 0x06000417 RID: 1047 RVA: 0x00083920 File Offset: 0x00081B20
		Friend ReadOnly Property Old_Purchase_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Old Purchase copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000256 RID: 598
		' (get) Token: 0x06000418 RID: 1048 RVA: 0x00083954 File Offset: 0x00081B54
		Friend ReadOnly Property Online_Order_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Online Order copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000257 RID: 599
		' (get) Token: 0x06000419 RID: 1049 RVA: 0x00083988 File Offset: 0x00081B88
		Friend ReadOnly Property OPStock_Format As Byte()
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("OPStock_Format", Resources.resourceCulture))
				Return CType(objectValue, Byte())
			End Get
		End Property

		' Token: 0x17000258 RID: 600
		' (get) Token: 0x0600041A RID: 1050 RVA: 0x000839BC File Offset: 0x00081BBC
		Friend ReadOnly Property p12 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("p12", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000259 RID: 601
		' (get) Token: 0x0600041B RID: 1051 RVA: 0x000839F0 File Offset: 0x00081BF0
		Friend ReadOnly Property packages__2_ As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("packages (2)", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700025A RID: 602
		' (get) Token: 0x0600041C RID: 1052 RVA: 0x00083A24 File Offset: 0x00081C24
		Friend ReadOnly Property Pay_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Pay copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700025B RID: 603
		' (get) Token: 0x0600041D RID: 1053 RVA: 0x00083A58 File Offset: 0x00081C58
		Friend ReadOnly Property Pay_copy1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Pay copy1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700025C RID: 604
		' (get) Token: 0x0600041E RID: 1054 RVA: 0x00083A8C File Offset: 0x00081C8C
		Friend ReadOnly Property Pay_copy2 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Pay copy2", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700025D RID: 605
		' (get) Token: 0x0600041F RID: 1055 RVA: 0x00083AC0 File Offset: 0x00081CC0
		Friend ReadOnly Property Payment As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Payment", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700025E RID: 606
		' (get) Token: 0x06000420 RID: 1056 RVA: 0x00083AF4 File Offset: 0x00081CF4
		Friend ReadOnly Property payment_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("payment-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700025F RID: 607
		' (get) Token: 0x06000421 RID: 1057 RVA: 0x00083B28 File Offset: 0x00081D28
		Friend ReadOnly Property PBtn As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("PBtn", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000260 RID: 608
		' (get) Token: 0x06000422 RID: 1058 RVA: 0x00083B5C File Offset: 0x00081D5C
		Friend ReadOnly Property photo As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("photo", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000261 RID: 609
		' (get) Token: 0x06000423 RID: 1059 RVA: 0x00083B90 File Offset: 0x00081D90
		Friend ReadOnly Property Plus_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Plus_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000262 RID: 610
		' (get) Token: 0x06000424 RID: 1060 RVA: 0x00083BC4 File Offset: 0x00081DC4
		Friend ReadOnly Property Plus_pr1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Plus_pr1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000263 RID: 611
		' (get) Token: 0x06000425 RID: 1061 RVA: 0x00083BF8 File Offset: 0x00081DF8
		Friend ReadOnly Property PNG As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("PNG", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000264 RID: 612
		' (get) Token: 0x06000426 RID: 1062 RVA: 0x00083C2C File Offset: 0x00081E2C
		Friend ReadOnly Property Print_Barcode_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Print Barcode copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000265 RID: 613
		' (get) Token: 0x06000427 RID: 1063 RVA: 0x00083C60 File Offset: 0x00081E60
		Friend ReadOnly Property PRINT_BARCODE_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("PRINT BARCODE_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000266 RID: 614
		' (get) Token: 0x06000428 RID: 1064 RVA: 0x00083C94 File Offset: 0x00081E94
		Friend ReadOnly Property Print_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Print copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000267 RID: 615
		' (get) Token: 0x06000429 RID: 1065 RVA: 0x00083CC8 File Offset: 0x00081EC8
		Friend ReadOnly Property Print_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Print copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000268 RID: 616
		' (get) Token: 0x0600042A RID: 1066 RVA: 0x00083CFC File Offset: 0x00081EFC
		Friend ReadOnly Property Print_copy1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Print copy1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000269 RID: 617
		' (get) Token: 0x0600042B RID: 1067 RVA: 0x00083D30 File Offset: 0x00081F30
		Friend ReadOnly Property PRINT_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("PRINT_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700026A RID: 618
		' (get) Token: 0x0600042C RID: 1068 RVA: 0x00083D64 File Offset: 0x00081F64
		Friend ReadOnly Property Product As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Product", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700026B RID: 619
		' (get) Token: 0x0600042D RID: 1069 RVA: 0x00083D98 File Offset: 0x00081F98
		Friend ReadOnly Property product_bulk_edit_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("product bulk edit_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700026C RID: 620
		' (get) Token: 0x0600042E RID: 1070 RVA: 0x00083DCC File Offset: 0x00081FCC
		Friend ReadOnly Property Product_Format As Byte()
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Product_Format", Resources.resourceCulture))
				Return CType(objectValue, Byte())
			End Get
		End Property

		' Token: 0x1700026D RID: 621
		' (get) Token: 0x0600042F RID: 1071 RVA: 0x00083E00 File Offset: 0x00082000
		Friend ReadOnly Property product_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("product-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700026E RID: 622
		' (get) Token: 0x06000430 RID: 1072 RVA: 0x00083E34 File Offset: 0x00082034
		Friend ReadOnly Property product_sales_report_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("product-sales-report-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700026F RID: 623
		' (get) Token: 0x06000431 RID: 1073 RVA: 0x00083E68 File Offset: 0x00082068
		Friend ReadOnly Property Product_Setting_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Product Setting copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000270 RID: 624
		' (get) Token: 0x06000432 RID: 1074 RVA: 0x00083E9C File Offset: 0x0008209C
		Friend ReadOnly Property PRODUCT_SETTING_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("PRODUCT SETTING_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000271 RID: 625
		' (get) Token: 0x06000433 RID: 1075 RVA: 0x00083ED0 File Offset: 0x000820D0
		Friend ReadOnly Property Programming_Minimize_Window_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Programming-Minimize-Window-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000272 RID: 626
		' (get) Token: 0x06000434 RID: 1076 RVA: 0x00083F04 File Offset: 0x00082104
		Friend ReadOnly Property Purchase As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Purchase", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000273 RID: 627
		' (get) Token: 0x06000435 RID: 1077 RVA: 0x00083F38 File Offset: 0x00082138
		Friend ReadOnly Property Purchase_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Purchase copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000274 RID: 628
		' (get) Token: 0x06000436 RID: 1078 RVA: 0x00083F6C File Offset: 0x0008216C
		Friend ReadOnly Property Purchase_Order_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Purchase Order copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000275 RID: 629
		' (get) Token: 0x06000437 RID: 1079 RVA: 0x00083FA0 File Offset: 0x000821A0
		Friend ReadOnly Property PURCHASE_ORDER_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("PURCHASE ORDER_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000276 RID: 630
		' (get) Token: 0x06000438 RID: 1080 RVA: 0x00083FD4 File Offset: 0x000821D4
		Friend ReadOnly Property QR As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("QR", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000277 RID: 631
		' (get) Token: 0x06000439 RID: 1081 RVA: 0x00084008 File Offset: 0x00082208
		Friend ReadOnly Property Quick_Pay_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Quick Pay copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000278 RID: 632
		' (get) Token: 0x0600043A RID: 1082 RVA: 0x0008403C File Offset: 0x0008223C
		Friend ReadOnly Property Quotation As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Quotation", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000279 RID: 633
		' (get) Token: 0x0600043B RID: 1083 RVA: 0x00084070 File Offset: 0x00082270
		Friend ReadOnly Property quotation_256 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("quotation 256", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700027A RID: 634
		' (get) Token: 0x0600043C RID: 1084 RVA: 0x000840A4 File Offset: 0x000822A4
		Friend ReadOnly Property Quotation_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Quotation copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700027B RID: 635
		' (get) Token: 0x0600043D RID: 1085 RVA: 0x000840D8 File Offset: 0x000822D8
		Friend ReadOnly Property RBtn As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("RBtn", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700027C RID: 636
		' (get) Token: 0x0600043E RID: 1086 RVA: 0x0008410C File Offset: 0x0008230C
		Friend ReadOnly Property rdg As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("rdg", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700027D RID: 637
		' (get) Token: 0x0600043F RID: 1087 RVA: 0x00084140 File Offset: 0x00082340
		Friend ReadOnly Property RECEIPT_PRINTER As Byte()
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("RECEIPT_PRINTER", Resources.resourceCulture))
				Return CType(objectValue, Byte())
			End Get
		End Property

		' Token: 0x1700027E RID: 638
		' (get) Token: 0x06000440 RID: 1088 RVA: 0x00084174 File Offset: 0x00082374
		Friend ReadOnly Property record_512 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("record_512", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700027F RID: 639
		' (get) Token: 0x06000441 RID: 1089 RVA: 0x000841A8 File Offset: 0x000823A8
		Friend ReadOnly Property RedL As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("RedL", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000280 RID: 640
		' (get) Token: 0x06000442 RID: 1090 RVA: 0x000841DC File Offset: 0x000823DC
		Friend ReadOnly Property report_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("report-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000281 RID: 641
		' (get) Token: 0x06000443 RID: 1091 RVA: 0x00084210 File Offset: 0x00082410
		Friend ReadOnly Property reports As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("reports", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000282 RID: 642
		' (get) Token: 0x06000444 RID: 1092 RVA: 0x00084244 File Offset: 0x00082444
		Friend ReadOnly Property reports1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("reports1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000283 RID: 643
		' (get) Token: 0x06000445 RID: 1093 RVA: 0x00084278 File Offset: 0x00082478
		Friend ReadOnly Property Reset_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Reset copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000284 RID: 644
		' (get) Token: 0x06000446 RID: 1094 RVA: 0x000842AC File Offset: 0x000824AC
		Friend ReadOnly Property reset_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("reset_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000285 RID: 645
		' (get) Token: 0x06000447 RID: 1095 RVA: 0x000842E0 File Offset: 0x000824E0
		Friend ReadOnly Property RESET_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("RESET_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000286 RID: 646
		' (get) Token: 0x06000448 RID: 1096 RVA: 0x00084314 File Offset: 0x00082514
		Friend ReadOnly Property Reset2_32x32 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Reset2_32x32", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000287 RID: 647
		' (get) Token: 0x06000449 RID: 1097 RVA: 0x00084348 File Offset: 0x00082548
		Friend ReadOnly Property Restart_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Restart_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000288 RID: 648
		' (get) Token: 0x0600044A RID: 1098 RVA: 0x0008437C File Offset: 0x0008257C
		Friend ReadOnly Property Rubic_POS_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Rubic POS copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000289 RID: 649
		' (get) Token: 0x0600044B RID: 1099 RVA: 0x000843B0 File Offset: 0x000825B0
		Friend ReadOnly Property Sale_2_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Sale 2 copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700028A RID: 650
		' (get) Token: 0x0600044C RID: 1100 RVA: 0x000843E4 File Offset: 0x000825E4
		Friend ReadOnly Property Sale_POS_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Sale POS copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700028B RID: 651
		' (get) Token: 0x0600044D RID: 1101 RVA: 0x00084418 File Offset: 0x00082618
		Friend ReadOnly Property SALES___F12 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SALES - F12", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700028C RID: 652
		' (get) Token: 0x0600044E RID: 1102 RVA: 0x0008444C File Offset: 0x0008264C
		Friend ReadOnly Property Salesman As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Salesman", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700028D RID: 653
		' (get) Token: 0x0600044F RID: 1103 RVA: 0x00084480 File Offset: 0x00082680
		Friend ReadOnly Property Salesman_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Salesman copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700028E RID: 654
		' (get) Token: 0x06000450 RID: 1104 RVA: 0x000844B4 File Offset: 0x000826B4
		Friend ReadOnly Property Salesman_Format As Byte()
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Salesman_Format", Resources.resourceCulture))
				Return CType(objectValue, Byte())
			End Get
		End Property

		' Token: 0x1700028F RID: 655
		' (get) Token: 0x06000451 RID: 1105 RVA: 0x000844E8 File Offset: 0x000826E8
		Friend ReadOnly Property Save_32x32 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Save_32x32", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000290 RID: 656
		' (get) Token: 0x06000452 RID: 1106 RVA: 0x0008451C File Offset: 0x0008271C
		Friend ReadOnly Property Save_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Save copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000291 RID: 657
		' (get) Token: 0x06000453 RID: 1107 RVA: 0x00084550 File Offset: 0x00082750
		Friend ReadOnly Property SAVE_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SAVE_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000292 RID: 658
		' (get) Token: 0x06000454 RID: 1108 RVA: 0x00084584 File Offset: 0x00082784
		Friend ReadOnly Property SBtn As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SBtn", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000293 RID: 659
		' (get) Token: 0x06000455 RID: 1109 RVA: 0x000845B8 File Offset: 0x000827B8
		Friend ReadOnly Property search_invoice As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("search invoice", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000294 RID: 660
		' (get) Token: 0x06000456 RID: 1110 RVA: 0x000845EC File Offset: 0x000827EC
		Friend ReadOnly Property Send_Mail_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Send Mail copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000295 RID: 661
		' (get) Token: 0x06000457 RID: 1111 RVA: 0x00084620 File Offset: 0x00082820
		Friend ReadOnly Property service_256 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("service 256", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000296 RID: 662
		' (get) Token: 0x06000458 RID: 1112 RVA: 0x00084654 File Offset: 0x00082854
		Friend ReadOnly Property Set_Default_copy_1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Set Default copy 1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000297 RID: 663
		' (get) Token: 0x06000459 RID: 1113 RVA: 0x00084688 File Offset: 0x00082888
		Friend ReadOnly Property set_default_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("set default_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000298 RID: 664
		' (get) Token: 0x0600045A RID: 1114 RVA: 0x000846BC File Offset: 0x000828BC
		Friend ReadOnly Property Settings_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Settings copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000299 RID: 665
		' (get) Token: 0x0600045B RID: 1115 RVA: 0x000846F0 File Offset: 0x000828F0
		Friend ReadOnly Property settings_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("settings_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700029A RID: 666
		' (get) Token: 0x0600045C RID: 1116 RVA: 0x00084724 File Offset: 0x00082924
		Friend ReadOnly Property Show_All_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Show All copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700029B RID: 667
		' (get) Token: 0x0600045D RID: 1117 RVA: 0x00084758 File Offset: 0x00082958
		Friend ReadOnly Property SHOW_ALL_P1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SHOW ALL_P1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700029C RID: 668
		' (get) Token: 0x0600045E RID: 1118 RVA: 0x0008478C File Offset: 0x0008298C
		Friend ReadOnly Property SHOW_ALL_P11 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SHOW ALL_P11", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700029D RID: 669
		' (get) Token: 0x0600045F RID: 1119 RVA: 0x000847C0 File Offset: 0x000829C0
		Friend ReadOnly Property SHOW_ALL_P12 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SHOW ALL_P12", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700029E RID: 670
		' (get) Token: 0x06000460 RID: 1120 RVA: 0x000847F4 File Offset: 0x000829F4
		Friend ReadOnly Property SMS As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SMS", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700029F RID: 671
		' (get) Token: 0x06000461 RID: 1121 RVA: 0x00084828 File Offset: 0x00082A28
		Friend ReadOnly Property splash As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("splash", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002A0 RID: 672
		' (get) Token: 0x06000462 RID: 1122 RVA: 0x0008485C File Offset: 0x00082A5C
		Friend ReadOnly Property stock_in_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("stock in icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002A1 RID: 673
		' (get) Token: 0x06000463 RID: 1123 RVA: 0x00084890 File Offset: 0x00082A90
		Friend ReadOnly Property Stocks_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Stocks-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002A2 RID: 674
		' (get) Token: 0x06000464 RID: 1124 RVA: 0x000848C4 File Offset: 0x00082AC4
		Friend ReadOnly Property SUB_CATEGORY As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SUB CATEGORY", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002A3 RID: 675
		' (get) Token: 0x06000465 RID: 1125 RVA: 0x000848F8 File Offset: 0x00082AF8
		Friend ReadOnly Property Sub_Category_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Sub Category copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002A4 RID: 676
		' (get) Token: 0x06000466 RID: 1126 RVA: 0x0008492C File Offset: 0x00082B2C
		Friend ReadOnly Property Summary As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Summary", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002A5 RID: 677
		' (get) Token: 0x06000467 RID: 1127 RVA: 0x00084960 File Offset: 0x00082B60
		Friend ReadOnly Property supplier As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("supplier", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002A6 RID: 678
		' (get) Token: 0x06000468 RID: 1128 RVA: 0x00084994 File Offset: 0x00082B94
		Friend ReadOnly Property Supplier_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Supplier copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002A7 RID: 679
		' (get) Token: 0x06000469 RID: 1129 RVA: 0x000849C8 File Offset: 0x00082BC8
		Friend ReadOnly Property Supplier_Format As Byte()
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Supplier_Format", Resources.resourceCulture))
				Return CType(objectValue, Byte())
			End Get
		End Property

		' Token: 0x170002A8 RID: 680
		' (get) Token: 0x0600046A RID: 1130 RVA: 0x000849FC File Offset: 0x00082BFC
		Friend ReadOnly Property SUPPLIER_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SUPPLIER_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002A9 RID: 681
		' (get) Token: 0x0600046B RID: 1131 RVA: 0x00084A30 File Offset: 0x00082C30
		Friend ReadOnly Property SUPPLIER_pr1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("SUPPLIER_pr1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002AA RID: 682
		' (get) Token: 0x0600046C RID: 1132 RVA: 0x00084A64 File Offset: 0x00082C64
		Friend ReadOnly Property Unhold_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Unhold copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002AB RID: 683
		' (get) Token: 0x0600046D RID: 1133 RVA: 0x00084A98 File Offset: 0x00082C98
		Friend ReadOnly Property UP_QR_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("UP-QR copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002AC RID: 684
		' (get) Token: 0x0600046E RID: 1134 RVA: 0x00084ACC File Offset: 0x00082CCC
		Friend ReadOnly Property Update_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Update copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002AD RID: 685
		' (get) Token: 0x0600046F RID: 1135 RVA: 0x00084B00 File Offset: 0x00082D00
		Friend ReadOnly Property Update_copy_a1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Update copy-a1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002AE RID: 686
		' (get) Token: 0x06000470 RID: 1136 RVA: 0x00084B34 File Offset: 0x00082D34
		Friend ReadOnly Property UPDATE_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("UPDATE_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002AF RID: 687
		' (get) Token: 0x06000471 RID: 1137 RVA: 0x00084B68 File Offset: 0x00082D68
		Friend ReadOnly Property Updaten1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Updaten1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B0 RID: 688
		' (get) Token: 0x06000472 RID: 1138 RVA: 0x00084B9C File Offset: 0x00082D9C
		Friend ReadOnly Property UpdateOrange As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("UpdateOrange", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B1 RID: 689
		' (get) Token: 0x06000473 RID: 1139 RVA: 0x00084BD0 File Offset: 0x00082DD0
		Friend ReadOnly Property upipay As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("upipay", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B2 RID: 690
		' (get) Token: 0x06000474 RID: 1140 RVA: 0x00084C04 File Offset: 0x00082E04
		Friend ReadOnly Property Upload_File_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Upload File copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B3 RID: 691
		' (get) Token: 0x06000475 RID: 1141 RVA: 0x00084C38 File Offset: 0x00082E38
		Friend ReadOnly Property User_Group_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("User-Group-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B4 RID: 692
		' (get) Token: 0x06000476 RID: 1142 RVA: 0x00084C6C File Offset: 0x00082E6C
		Friend ReadOnly Property User_Interface_Restore_Window_icon__1_ As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("User-Interface-Restore-Window-icon (1)", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B5 RID: 693
		' (get) Token: 0x06000477 RID: 1143 RVA: 0x00084CA0 File Offset: 0x00082EA0
		Friend ReadOnly Property user_regestration As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("user regestration", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B6 RID: 694
		' (get) Token: 0x06000478 RID: 1144 RVA: 0x00084CD4 File Offset: 0x00082ED4
		Friend ReadOnly Property Users_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Users-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B7 RID: 695
		' (get) Token: 0x06000479 RID: 1145 RVA: 0x00084D08 File Offset: 0x00082F08
		Friend ReadOnly Property Utilities_icon As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Utilities-icon", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B8 RID: 696
		' (get) Token: 0x0600047A RID: 1146 RVA: 0x00084D3C File Offset: 0x00082F3C
		Friend ReadOnly Property VBtn As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("VBtn", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002B9 RID: 697
		' (get) Token: 0x0600047B RID: 1147 RVA: 0x00084D70 File Offset: 0x00082F70
		Friend ReadOnly Property VIEW_OLD_PURCHASE_pr As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("VIEW OLD PURCHASE_pr", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002BA RID: 698
		' (get) Token: 0x0600047C RID: 1148 RVA: 0x00084DA4 File Offset: 0x00082FA4
		Friend ReadOnly Property Voucher As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Voucher", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002BB RID: 699
		' (get) Token: 0x0600047D RID: 1149 RVA: 0x00084DD8 File Offset: 0x00082FD8
		Friend ReadOnly Property WALLET As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("WALLET", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002BC RID: 700
		' (get) Token: 0x0600047E RID: 1150 RVA: 0x00084E0C File Offset: 0x0008300C
		Friend ReadOnly Property Wallet_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Wallet copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002BD RID: 701
		' (get) Token: 0x0600047F RID: 1151 RVA: 0x00084E40 File Offset: 0x00083040
		Friend ReadOnly Property WALLET1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("WALLET1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002BE RID: 702
		' (get) Token: 0x06000480 RID: 1152 RVA: 0x00084E74 File Offset: 0x00083074
		Friend ReadOnly Property warehouse_illu_01 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("warehouse_illu_01", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002BF RID: 703
		' (get) Token: 0x06000481 RID: 1153 RVA: 0x00084EA8 File Offset: 0x000830A8
		Friend ReadOnly Property Weighing_Scale_copy As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Weighing Scale copy", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002C0 RID: 704
		' (get) Token: 0x06000482 RID: 1154 RVA: 0x00084EDC File Offset: 0x000830DC
		Friend ReadOnly Property Weighing_Scale_copy1 As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Weighing Scale copy1", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x170002C1 RID: 705
		' (get) Token: 0x06000483 RID: 1155 RVA: 0x00084F10 File Offset: 0x00083110
		Friend ReadOnly Property Xx As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Xx", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x040001A2 RID: 418
		Private resourceMan As ResourceManager

		' Token: 0x040001A3 RID: 419
		Private resourceCulture As CultureInfo
	End Module
End Namespace
