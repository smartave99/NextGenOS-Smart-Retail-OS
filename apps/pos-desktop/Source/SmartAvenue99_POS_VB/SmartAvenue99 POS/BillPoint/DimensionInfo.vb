Imports System

Namespace BillPoint
	' Token: 0x02000014 RID: 20
	Public Class DimensionInfo
		' Token: 0x170002DF RID: 735
		' (get) Token: 0x060004DF RID: 1247 RVA: 0x00087A88 File Offset: 0x00085C88
		' (set) Token: 0x060004E0 RID: 1248 RVA: 0x00009425 File Offset: 0x00007625
		Public Property DimensionId As Decimal
			Get
				Return Me._dimensionId
			End Get
			Set(value As Decimal)
				Me._dimensionId = value
			End Set
		End Property

		' Token: 0x170002E0 RID: 736
		' (get) Token: 0x060004E1 RID: 1249 RVA: 0x00087AA0 File Offset: 0x00085CA0
		' (set) Token: 0x060004E2 RID: 1250 RVA: 0x0000942F File Offset: 0x0000762F
		Public Property LayoutId As Decimal
			Get
				Return Me._layoutId
			End Get
			Set(value As Decimal)
				Me._layoutId = value
			End Set
		End Property

		' Token: 0x170002E1 RID: 737
		' (get) Token: 0x060004E3 RID: 1251 RVA: 0x00087AB8 File Offset: 0x00085CB8
		' (set) Token: 0x060004E4 RID: 1252 RVA: 0x00009439 File Offset: 0x00007639
		Public Property FieldId As Decimal
			Get
				Return Me._fieldId
			End Get
			Set(value As Decimal)
				Me._fieldId = value
			End Set
		End Property

		' Token: 0x170002E2 RID: 738
		' (get) Token: 0x060004E5 RID: 1253 RVA: 0x00087AD0 File Offset: 0x00085CD0
		' (set) Token: 0x060004E6 RID: 1254 RVA: 0x00009443 File Offset: 0x00007643
		Public Property XAxis As Single
			Get
				Return Me._xAxis
			End Get
			Set(value As Single)
				Me._xAxis = value
			End Set
		End Property

		' Token: 0x170002E3 RID: 739
		' (get) Token: 0x060004E7 RID: 1255 RVA: 0x00087AE8 File Offset: 0x00085CE8
		' (set) Token: 0x060004E8 RID: 1256 RVA: 0x0000944D File Offset: 0x0000764D
		Public Property YAxis As Single
			Get
				Return Me._yAxis
			End Get
			Set(value As Single)
				Me._yAxis = value
			End Set
		End Property

		' Token: 0x170002E4 RID: 740
		' (get) Token: 0x060004E9 RID: 1257 RVA: 0x00087B00 File Offset: 0x00085D00
		' (set) Token: 0x060004EA RID: 1258 RVA: 0x00009457 File Offset: 0x00007657
		Public Property Width As Single
			Get
				Return Me._width
			End Get
			Set(value As Single)
				Me._width = value
			End Set
		End Property

		' Token: 0x170002E5 RID: 741
		' (get) Token: 0x060004EB RID: 1259 RVA: 0x00087B18 File Offset: 0x00085D18
		' (set) Token: 0x060004EC RID: 1260 RVA: 0x00009461 File Offset: 0x00007661
		Public Property Height As Single
			Get
				Return Me._height
			End Get
			Set(value As Single)
				Me._height = value
			End Set
		End Property

		' Token: 0x040001D5 RID: 469
		Private _dimensionId As Decimal

		' Token: 0x040001D6 RID: 470
		Private _layoutId As Decimal

		' Token: 0x040001D7 RID: 471
		Private _fieldId As Decimal

		' Token: 0x040001D8 RID: 472
		Private _xAxis As Single

		' Token: 0x040001D9 RID: 473
		Private _yAxis As Single

		' Token: 0x040001DA RID: 474
		Private _width As Single

		' Token: 0x040001DB RID: 475
		Private _height As Single
	End Class
End Namespace
