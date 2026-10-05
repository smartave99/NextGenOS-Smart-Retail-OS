Imports System

Namespace BillPoint
	' Token: 0x0200001A RID: 26
	Public Class ChequeLayoutInfo
		' Token: 0x170003AD RID: 941
		' (get) Token: 0x06000774 RID: 1908 RVA: 0x0009E6B4 File Offset: 0x0009C8B4
		' (set) Token: 0x06000775 RID: 1909 RVA: 0x0000A186 File Offset: 0x00008386
		Public Property PCode As String
			Get
				Return Me._PCode
			End Get
			Set(value As String)
				Me._PCode = value
			End Set
		End Property

		' Token: 0x170003AE RID: 942
		' (get) Token: 0x06000776 RID: 1910 RVA: 0x0009E6CC File Offset: 0x0009C8CC
		' (set) Token: 0x06000777 RID: 1911 RVA: 0x0000A190 File Offset: 0x00008390
		Public Property ProductName As String
			Get
				Return Me._ProductName
			End Get
			Set(value As String)
				Me._ProductName = value
			End Set
		End Property

		' Token: 0x170003AF RID: 943
		' (get) Token: 0x06000778 RID: 1912 RVA: 0x0009E6E4 File Offset: 0x0009C8E4
		' (set) Token: 0x06000779 RID: 1913 RVA: 0x0000A19A File Offset: 0x0000839A
		Public Property Category As String
			Get
				Return Me._Category
			End Get
			Set(value As String)
				Me._Category = value
			End Set
		End Property

		' Token: 0x170003B0 RID: 944
		' (get) Token: 0x0600077A RID: 1914 RVA: 0x0009E6FC File Offset: 0x0009C8FC
		' (set) Token: 0x0600077B RID: 1915 RVA: 0x0000A1A4 File Offset: 0x000083A4
		Public Property Barcode As String
			Get
				Return Me._Barcode
			End Get
			Set(value As String)
				Me._Barcode = value
			End Set
		End Property

		' Token: 0x170003B1 RID: 945
		' (get) Token: 0x0600077C RID: 1916 RVA: 0x0009E714 File Offset: 0x0009C914
		' (set) Token: 0x0600077D RID: 1917 RVA: 0x0000A1AE File Offset: 0x000083AE
		Public Property AvlQty As Decimal
			Get
				Return Me._AvlQty
			End Get
			Set(value As Decimal)
				Me._AvlQty = value
			End Set
		End Property

		' Token: 0x170003B2 RID: 946
		' (get) Token: 0x0600077E RID: 1918 RVA: 0x0009E72C File Offset: 0x0009C92C
		' (set) Token: 0x0600077F RID: 1919 RVA: 0x0000A1B8 File Offset: 0x000083B8
		Public Property NoCopy As Integer
			Get
				Return Me._NoCopy
			End Get
			Set(value As Integer)
				Me._NoCopy = value
			End Set
		End Property

		' Token: 0x170003B3 RID: 947
		' (get) Token: 0x06000780 RID: 1920 RVA: 0x0009E744 File Offset: 0x0009C944
		' (set) Token: 0x06000781 RID: 1921 RVA: 0x0000A1C2 File Offset: 0x000083C2
		Public Property PartNo As String
			Get
				Return Me._PartNo
			End Get
			Set(value As String)
				Me._PartNo = value
			End Set
		End Property

		' Token: 0x170003B4 RID: 948
		' (get) Token: 0x06000782 RID: 1922 RVA: 0x0009E75C File Offset: 0x0009C95C
		' (set) Token: 0x06000783 RID: 1923 RVA: 0x0000A1CC File Offset: 0x000083CC
		Public Property HSNC As String
			Get
				Return Me._HSNC
			End Get
			Set(value As String)
				Me._HSNC = value
			End Set
		End Property

		' Token: 0x170003B5 RID: 949
		' (get) Token: 0x06000784 RID: 1924 RVA: 0x0009E774 File Offset: 0x0009C974
		' (set) Token: 0x06000785 RID: 1925 RVA: 0x0000A1D6 File Offset: 0x000083D6
		Public Property MRP As Decimal
			Get
				Return Me._MRP
			End Get
			Set(value As Decimal)
				Me._MRP = value
			End Set
		End Property

		' Token: 0x170003B6 RID: 950
		' (get) Token: 0x06000786 RID: 1926 RVA: 0x0009E78C File Offset: 0x0009C98C
		' (set) Token: 0x06000787 RID: 1927 RVA: 0x0000A1E0 File Offset: 0x000083E0
		Public Property SalePrice As Decimal
			Get
				Return Me._SalePrice
			End Get
			Set(value As Decimal)
				Me._SalePrice = value
			End Set
		End Property

		' Token: 0x170003B7 RID: 951
		' (get) Token: 0x06000788 RID: 1928 RVA: 0x0009E7A4 File Offset: 0x0009C9A4
		' (set) Token: 0x06000789 RID: 1929 RVA: 0x0000A1EA File Offset: 0x000083EA
		Public Property WholesalePrice As Decimal
			Get
				Return Me._WholesalePrice
			End Get
			Set(value As Decimal)
				Me._WholesalePrice = value
			End Set
		End Property

		' Token: 0x170003B8 RID: 952
		' (get) Token: 0x0600078A RID: 1930 RVA: 0x0009E7BC File Offset: 0x0009C9BC
		' (set) Token: 0x0600078B RID: 1931 RVA: 0x0000A1F4 File Offset: 0x000083F4
		Public Property Batch As String
			Get
				Return Me._Batch
			End Get
			Set(value As String)
				Me._Batch = value
			End Set
		End Property

		' Token: 0x170003B9 RID: 953
		' (get) Token: 0x0600078C RID: 1932 RVA: 0x0009E7D4 File Offset: 0x0009C9D4
		' (set) Token: 0x0600078D RID: 1933 RVA: 0x0000A1FE File Offset: 0x000083FE
		Public Property Mfg As String
			Get
				Return Me._Mfg
			End Get
			Set(value As String)
				Me._Mfg = value
			End Set
		End Property

		' Token: 0x170003BA RID: 954
		' (get) Token: 0x0600078E RID: 1934 RVA: 0x0009E7EC File Offset: 0x0009C9EC
		' (set) Token: 0x0600078F RID: 1935 RVA: 0x0000A208 File Offset: 0x00008408
		Public Property Exp As String
			Get
				Return Me._Exp
			End Get
			Set(value As String)
				Me._Exp = value
			End Set
		End Property

		' Token: 0x170003BB RID: 955
		' (get) Token: 0x06000790 RID: 1936 RVA: 0x0009E804 File Offset: 0x0009CA04
		' (set) Token: 0x06000791 RID: 1937 RVA: 0x0000A212 File Offset: 0x00008412
		Public Property Size As String
			Get
				Return Me._Size
			End Get
			Set(value As String)
				Me._Size = value
			End Set
		End Property

		' Token: 0x170003BC RID: 956
		' (get) Token: 0x06000792 RID: 1938 RVA: 0x0009E81C File Offset: 0x0009CA1C
		' (set) Token: 0x06000793 RID: 1939 RVA: 0x0000A21C File Offset: 0x0000841C
		Public Property Colour As String
			Get
				Return Me._Colour
			End Get
			Set(value As String)
				Me._Colour = value
			End Set
		End Property

		' Token: 0x170003BD RID: 957
		' (get) Token: 0x06000794 RID: 1940 RVA: 0x0009E834 File Offset: 0x0009CA34
		' (set) Token: 0x06000795 RID: 1941 RVA: 0x0000A226 File Offset: 0x00008426
		Public Property GST As String
			Get
				Return Me._GST
			End Get
			Set(value As String)
				Me._GST = value
			End Set
		End Property

		' Token: 0x170003BE RID: 958
		' (get) Token: 0x06000796 RID: 1942 RVA: 0x0009E84C File Offset: 0x0009CA4C
		' (set) Token: 0x06000797 RID: 1943 RVA: 0x0000A230 File Offset: 0x00008430
		Public Property PurInv As String
			Get
				Return Me._PurInv
			End Get
			Set(value As String)
				Me._PurInv = value
			End Set
		End Property

		' Token: 0x170003BF RID: 959
		' (get) Token: 0x06000798 RID: 1944 RVA: 0x0009E864 File Offset: 0x0009CA64
		' (set) Token: 0x06000799 RID: 1945 RVA: 0x0000A23A File Offset: 0x0000843A
		Public Property QrBarcode As Boolean
			Get
				Return Me._QrBarcode
			End Get
			Set(value As Boolean)
				Me._QrBarcode = value
			End Set
		End Property

		' Token: 0x040002CB RID: 715
		Private _PCode As String

		' Token: 0x040002CC RID: 716
		Private _ProductName As String

		' Token: 0x040002CD RID: 717
		Private _Category As String

		' Token: 0x040002CE RID: 718
		Private _Barcode As String

		' Token: 0x040002CF RID: 719
		Private _AvlQty As Decimal

		' Token: 0x040002D0 RID: 720
		Private _NoCopy As Integer

		' Token: 0x040002D1 RID: 721
		Private _PartNo As String

		' Token: 0x040002D2 RID: 722
		Private _HSNC As String

		' Token: 0x040002D3 RID: 723
		Private _MRP As Decimal

		' Token: 0x040002D4 RID: 724
		Private _SalePrice As Decimal

		' Token: 0x040002D5 RID: 725
		Private _WholesalePrice As Decimal

		' Token: 0x040002D6 RID: 726
		Private _Batch As String

		' Token: 0x040002D7 RID: 727
		Private _Mfg As String

		' Token: 0x040002D8 RID: 728
		Private _Exp As String

		' Token: 0x040002D9 RID: 729
		Private _Size As String

		' Token: 0x040002DA RID: 730
		Private _Colour As String

		' Token: 0x040002DB RID: 731
		Private _GST As String

		' Token: 0x040002DC RID: 732
		Private _PurInv As String

		' Token: 0x040002DD RID: 733
		Private _QrBarcode As Boolean
	End Class
End Namespace
