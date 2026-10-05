Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000035 RID: 53
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSetGiftCard")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSetGiftCard
		Inherits DataSet

		' Token: 0x060009DA RID: 2522 RVA: 0x000A68B8 File Offset: 0x000A4AB8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me._schemaSerializationMode = SchemaSerializationMode.IncludeSchema
			MyBase.BeginInit()
			Me.InitClass()
			Dim collectionChangeEventHandler As CollectionChangeEventHandler = AddressOf Me.SchemaChanged
			AddHandler MyBase.Tables.CollectionChanged, collectionChangeEventHandler
			AddHandler MyBase.Relations.CollectionChanged, collectionChangeEventHandler
			MyBase.EndInit()
		End Sub

		' Token: 0x060009DB RID: 2523 RVA: 0x000A6910 File Offset: 0x000A4B10
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Sub New(info As SerializationInfo, context As StreamingContext)
			MyBase.New(info, context, False)
			Me._schemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Dim flag As Boolean = MyBase.IsBinarySerialized(info, context)
			If flag Then
				Me.InitVars(False)
				Dim collectionChangeEventHandler As CollectionChangeEventHandler = AddressOf Me.SchemaChanged
				AddHandler Me.Tables.CollectionChanged, collectionChangeEventHandler
				AddHandler Me.Relations.CollectionChanged, collectionChangeEventHandler
			Else
				Dim text As String = Conversions.ToString(info.GetValue("XmlSchema", GetType(String)))
				Dim flag2 As Boolean = MyBase.DetermineSchemaSerializationMode(info, context) = SchemaSerializationMode.IncludeSchema
				If flag2 Then
					Dim dataSet As DataSet = New DataSet()
					dataSet.ReadXmlSchema(New XmlTextReader(New StringReader(text)))
					Dim flag3 As Boolean = dataSet.Tables("DataTable1") IsNot Nothing
					If flag3 Then
						MyBase.Tables.Add(New DataSetGiftCard.DataTable1DataTable(dataSet.Tables("DataTable1")))
					End If
					MyBase.DataSetName = dataSet.DataSetName
					MyBase.Prefix = dataSet.Prefix
					MyBase.[Namespace] = dataSet.[Namespace]
					MyBase.Locale = dataSet.Locale
					MyBase.CaseSensitive = dataSet.CaseSensitive
					MyBase.EnforceConstraints = dataSet.EnforceConstraints
					MyBase.Merge(dataSet, False, MissingSchemaAction.Add)
					Me.InitVars()
				Else
					MyBase.ReadXmlSchema(New XmlTextReader(New StringReader(text)))
				End If
				MyBase.GetSerializationData(info, context)
				Dim collectionChangeEventHandler2 As CollectionChangeEventHandler = AddressOf Me.SchemaChanged
				AddHandler MyBase.Tables.CollectionChanged, collectionChangeEventHandler2
				AddHandler Me.Relations.CollectionChanged, collectionChangeEventHandler2
			End If
		End Sub

		' Token: 0x17000461 RID: 1121
		' (get) Token: 0x060009DC RID: 2524 RVA: 0x000A6AA4 File Offset: 0x000A4CA4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As DataSetGiftCard.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x17000462 RID: 1122
		' (get) Token: 0x060009DD RID: 2525 RVA: 0x000A6ABC File Offset: 0x000A4CBC
		' (set) Token: 0x060009DE RID: 2526 RVA: 0x0000B38C File Offset: 0x0000958C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(True)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
		Public Overrides Property SchemaSerializationMode As SchemaSerializationMode
			Get
				Return Me._schemaSerializationMode
			End Get
			Set(value As SchemaSerializationMode)
				Me._schemaSerializationMode = value
			End Set
		End Property

		' Token: 0x17000463 RID: 1123
		' (get) Token: 0x060009DF RID: 2527 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x17000464 RID: 1124
		' (get) Token: 0x060009E0 RID: 2528 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x060009E1 RID: 2529 RVA: 0x0000B396 File Offset: 0x00009596
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x060009E2 RID: 2530 RVA: 0x000A6AD4 File Offset: 0x000A4CD4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSetGiftCard As DataSetGiftCard = CType(MyBase.Clone(), DataSetGiftCard)
			dataSetGiftCard.InitVars()
			dataSetGiftCard.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSetGiftCard
		End Function

		' Token: 0x060009E3 RID: 2531 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x060009E4 RID: 2532 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x060009E5 RID: 2533 RVA: 0x000A6B08 File Offset: 0x000A4D08
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub ReadXmlSerializable(reader As XmlReader)
			Dim flag As Boolean = MyBase.DetermineSchemaSerializationMode(reader) = SchemaSerializationMode.IncludeSchema
			If flag Then
				Me.Reset()
				Dim dataSet As DataSet = New DataSet()
				dataSet.ReadXml(reader)
				Dim flag2 As Boolean = dataSet.Tables("DataTable1") IsNot Nothing
				If flag2 Then
					MyBase.Tables.Add(New DataSetGiftCard.DataTable1DataTable(dataSet.Tables("DataTable1")))
				End If
				MyBase.DataSetName = dataSet.DataSetName
				MyBase.Prefix = dataSet.Prefix
				MyBase.[Namespace] = dataSet.[Namespace]
				MyBase.Locale = dataSet.Locale
				MyBase.CaseSensitive = dataSet.CaseSensitive
				MyBase.EnforceConstraints = dataSet.EnforceConstraints
				MyBase.Merge(dataSet, False, MissingSchemaAction.Add)
				Me.InitVars()
			Else
				MyBase.ReadXml(reader)
				Me.InitVars()
			End If
		End Sub

		' Token: 0x060009E6 RID: 2534 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x060009E7 RID: 2535 RVA: 0x0000B3AE File Offset: 0x000095AE
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x060009E8 RID: 2536 RVA: 0x000A6BEC File Offset: 0x000A4DEC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), DataSetGiftCard.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
		End Sub

		' Token: 0x060009E9 RID: 2537 RVA: 0x000A6C38 File Offset: 0x000A4E38
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSetGiftCard"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSetGiftCard.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New DataSetGiftCard.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
		End Sub

		' Token: 0x060009EA RID: 2538 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x060009EB RID: 2539 RVA: 0x000A6C98 File Offset: 0x000A4E98
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x060009EC RID: 2540 RVA: 0x000A6CBC File Offset: 0x000A4EBC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSetGiftCard As DataSetGiftCard = New DataSetGiftCard()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSetGiftCard.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSetGiftCard.GetSchemaSerializable()
			Dim flag As Boolean = xs.Contains(schemaSerializable.TargetNamespace)
			If flag Then
				Dim memoryStream As MemoryStream = New MemoryStream()
				Dim memoryStream2 As MemoryStream = New MemoryStream()
				Try
					schemaSerializable.Write(memoryStream)
					For Each obj As Object In xs.Schemas(schemaSerializable.TargetNamespace)
						Dim xmlSchema As XmlSchema = CType(obj, XmlSchema)
						memoryStream2.SetLength(0L)
						xmlSchema.Write(memoryStream2)
						Dim flag2 As Boolean = memoryStream.Length = memoryStream2.Length
						If flag2 Then
							memoryStream.Position = 0L
							memoryStream2.Position = 0L
							While memoryStream.Position <> memoryStream.Length AndAlso memoryStream.ReadByte() = memoryStream2.ReadByte()
							End While
							Dim flag3 As Boolean = memoryStream.Position = memoryStream.Length
							If flag3 Then
								Return xmlSchemaComplexType
							End If
						End If
					Next
				Finally
					Dim flag4 As Boolean = memoryStream IsNot Nothing
					If flag4 Then
						memoryStream.Close()
					End If
					Dim flag5 As Boolean = memoryStream2 IsNot Nothing
					If flag5 Then
						memoryStream2.Close()
					End If
				End Try
			End If
			xs.Add(schemaSerializable)
			Return xmlSchemaComplexType
		End Function

		' Token: 0x0400034C RID: 844
		Private tableDataTable1 As DataSetGiftCard.DataTable1DataTable

		' Token: 0x0400034D RID: 845
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x02000036 RID: 54
		' (Invoke) Token: 0x060009F0 RID: 2544
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As DataSetGiftCard.DataTable1RowChangeEvent)

		' Token: 0x02000037 RID: 55
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of DataSetGiftCard.DataTable1Row)

			' Token: 0x060009F1 RID: 2545 RVA: 0x0000B3B9 File Offset: 0x000095B9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x060009F2 RID: 2546 RVA: 0x000A6E50 File Offset: 0x000A5050
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(table As DataTable)
				MyBase.TableName = table.TableName
				Dim flag As Boolean = table.CaseSensitive <> table.DataSet.CaseSensitive
				If flag Then
					MyBase.CaseSensitive = table.CaseSensitive
				End If
				Dim flag2 As Boolean = Operators.CompareString(table.Locale.ToString(), table.DataSet.Locale.ToString(), False) <> 0
				If flag2 Then
					MyBase.Locale = table.Locale
				End If
				Dim flag3 As Boolean = Operators.CompareString(table.[Namespace], table.DataSet.[Namespace], False) <> 0
				If flag3 Then
					MyBase.[Namespace] = table.[Namespace]
				End If
				MyBase.Prefix = table.Prefix
				MyBase.MinimumCapacity = table.MinimumCapacity
			End Sub

			' Token: 0x060009F3 RID: 2547 RVA: 0x0000B3E4 File Offset: 0x000095E4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17000465 RID: 1125
			' (get) Token: 0x060009F4 RID: 2548 RVA: 0x000A6F1C File Offset: 0x000A511C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CIDColumn As DataColumn
				Get
					Return Me.columnCID
				End Get
			End Property

			' Token: 0x17000466 RID: 1126
			' (get) Token: 0x060009F5 RID: 2549 RVA: 0x000A6F34 File Offset: 0x000A5134
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CustIDColumn As DataColumn
				Get
					Return Me.columnCustID
				End Get
			End Property

			' Token: 0x17000467 RID: 1127
			' (get) Token: 0x060009F6 RID: 2550 RVA: 0x000A6F4C File Offset: 0x000A514C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CustNameColumn As DataColumn
				Get
					Return Me.columnCustName
				End Get
			End Property

			' Token: 0x17000468 RID: 1128
			' (get) Token: 0x060009F7 RID: 2551 RVA: 0x000A6F64 File Offset: 0x000A5164
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property InvNoColumn As DataColumn
				Get
					Return Me.columnInvNo
				End Get
			End Property

			' Token: 0x17000469 RID: 1129
			' (get) Token: 0x060009F8 RID: 2552 RVA: 0x000A6F7C File Offset: 0x000A517C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property InvDateColumn As DataColumn
				Get
					Return Me.columnInvDate
				End Get
			End Property

			' Token: 0x1700046A RID: 1130
			' (get) Token: 0x060009F9 RID: 2553 RVA: 0x000A6F94 File Offset: 0x000A5194
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BillAmtColumn As DataColumn
				Get
					Return Me.columnBillAmt
				End Get
			End Property

			' Token: 0x1700046B RID: 1131
			' (get) Token: 0x060009FA RID: 2554 RVA: 0x000A6FAC File Offset: 0x000A51AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GiftCodeColumn As DataColumn
				Get
					Return Me.columnGiftCode
				End Get
			End Property

			' Token: 0x1700046C RID: 1132
			' (get) Token: 0x060009FB RID: 2555 RVA: 0x000A6FC4 File Offset: 0x000A51C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GiftAmtColumn As DataColumn
				Get
					Return Me.columnGiftAmt
				End Get
			End Property

			' Token: 0x1700046D RID: 1133
			' (get) Token: 0x060009FC RID: 2556 RVA: 0x000A6FDC File Offset: 0x000A51DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ValidfromColumn As DataColumn
				Get
					Return Me.columnValidfrom
				End Get
			End Property

			' Token: 0x1700046E RID: 1134
			' (get) Token: 0x060009FD RID: 2557 RVA: 0x000A6FF4 File Offset: 0x000A51F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ValidtoColumn As DataColumn
				Get
					Return Me.columnValidto
				End Get
			End Property

			' Token: 0x1700046F RID: 1135
			' (get) Token: 0x060009FE RID: 2558 RVA: 0x000A700C File Offset: 0x000A520C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property StatusColumn As DataColumn
				Get
					Return Me.columnStatus
				End Get
			End Property

			' Token: 0x17000470 RID: 1136
			' (get) Token: 0x060009FF RID: 2559 RVA: 0x000A7024 File Offset: 0x000A5224
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ContactColumn As DataColumn
				Get
					Return Me.columnContact
				End Get
			End Property

			' Token: 0x17000471 RID: 1137
			' (get) Token: 0x06000A00 RID: 2560 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17000472 RID: 1138
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetGiftCard.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), DataSetGiftCard.DataTable1Row)
				End Get
			End Property

			' Token: 0x14000015 RID: 21
			' (add) Token: 0x06000A02 RID: 2562 RVA: 0x000A7060 File Offset: 0x000A5260
			' (remove) Token: 0x06000A03 RID: 2563 RVA: 0x000A7098 File Offset: 0x000A5298
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As DataSetGiftCard.DataTable1RowChangeEventHandler

			' Token: 0x14000016 RID: 22
			' (add) Token: 0x06000A04 RID: 2564 RVA: 0x000A70D0 File Offset: 0x000A52D0
			' (remove) Token: 0x06000A05 RID: 2565 RVA: 0x000A7108 File Offset: 0x000A5308
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As DataSetGiftCard.DataTable1RowChangeEventHandler

			' Token: 0x14000017 RID: 23
			' (add) Token: 0x06000A06 RID: 2566 RVA: 0x000A7140 File Offset: 0x000A5340
			' (remove) Token: 0x06000A07 RID: 2567 RVA: 0x000A7178 File Offset: 0x000A5378
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As DataSetGiftCard.DataTable1RowChangeEventHandler

			' Token: 0x14000018 RID: 24
			' (add) Token: 0x06000A08 RID: 2568 RVA: 0x000A71B0 File Offset: 0x000A53B0
			' (remove) Token: 0x06000A09 RID: 2569 RVA: 0x000A71E8 File Offset: 0x000A53E8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As DataSetGiftCard.DataTable1RowChangeEventHandler

			' Token: 0x06000A0A RID: 2570 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As DataSetGiftCard.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x06000A0B RID: 2571 RVA: 0x000A7220 File Offset: 0x000A5420
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(CID As Integer, CustID As String, CustName As String, InvNo As String, InvDate As DateTime, BillAmt As Decimal, GiftCode As String, GiftAmt As Decimal, Validfrom As DateTime, Validto As DateTime, Status As String, Contact As String) As DataSetGiftCard.DataTable1Row
				Dim dataTable1Row As DataSetGiftCard.DataTable1Row = CType(MyBase.NewRow(), DataSetGiftCard.DataTable1Row)
				Dim array As Object() = New Object() { CID, CustID, CustName, InvNo, InvDate, BillAmt, GiftCode, GiftAmt, Validfrom, Validto, Status, Contact }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x06000A0C RID: 2572 RVA: 0x000A72B8 File Offset: 0x000A54B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As DataSetGiftCard.DataTable1DataTable = CType(MyBase.Clone(), DataSetGiftCard.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x06000A0D RID: 2573 RVA: 0x000A72E0 File Offset: 0x000A54E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetGiftCard.DataTable1DataTable()
			End Function

			' Token: 0x06000A0E RID: 2574 RVA: 0x000A72F8 File Offset: 0x000A54F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnCID = MyBase.Columns("CID")
				Me.columnCustID = MyBase.Columns("CustID")
				Me.columnCustName = MyBase.Columns("CustName")
				Me.columnInvNo = MyBase.Columns("InvNo")
				Me.columnInvDate = MyBase.Columns("InvDate")
				Me.columnBillAmt = MyBase.Columns("BillAmt")
				Me.columnGiftCode = MyBase.Columns("GiftCode")
				Me.columnGiftAmt = MyBase.Columns("GiftAmt")
				Me.columnValidfrom = MyBase.Columns("Validfrom")
				Me.columnValidto = MyBase.Columns("Validto")
				Me.columnStatus = MyBase.Columns("Status")
				Me.columnContact = MyBase.Columns("Contact")
			End Sub

			' Token: 0x06000A0F RID: 2575 RVA: 0x000A7410 File Offset: 0x000A5610
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnCID = New DataColumn("CID", GetType(Integer), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCID)
				Me.columnCustID = New DataColumn("CustID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCustID)
				Me.columnCustName = New DataColumn("CustName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCustName)
				Me.columnInvNo = New DataColumn("InvNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnInvNo)
				Me.columnInvDate = New DataColumn("InvDate", GetType(DateTime), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnInvDate)
				Me.columnBillAmt = New DataColumn("BillAmt", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBillAmt)
				Me.columnGiftCode = New DataColumn("GiftCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGiftCode)
				Me.columnGiftAmt = New DataColumn("GiftAmt", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGiftAmt)
				Me.columnValidfrom = New DataColumn("Validfrom", GetType(DateTime), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnValidfrom)
				Me.columnValidto = New DataColumn("Validto", GetType(DateTime), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnValidto)
				Me.columnStatus = New DataColumn("Status", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnStatus)
				Me.columnContact = New DataColumn("Contact", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnContact)
			End Sub

			' Token: 0x06000A10 RID: 2576 RVA: 0x000A7648 File Offset: 0x000A5848
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As DataSetGiftCard.DataTable1Row
				Return CType(MyBase.NewRow(), DataSetGiftCard.DataTable1Row)
			End Function

			' Token: 0x06000A11 RID: 2577 RVA: 0x000A7668 File Offset: 0x000A5868
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetGiftCard.DataTable1Row(builder)
			End Function

			' Token: 0x06000A12 RID: 2578 RVA: 0x000A7680 File Offset: 0x000A5880
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetGiftCard.DataTable1Row)
			End Function

			' Token: 0x06000A13 RID: 2579 RVA: 0x000A769C File Offset: 0x000A589C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As DataSetGiftCard.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New DataSetGiftCard.DataTable1RowChangeEvent(CType(e.Row, DataSetGiftCard.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000A14 RID: 2580 RVA: 0x000A76EC File Offset: 0x000A58EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As DataSetGiftCard.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New DataSetGiftCard.DataTable1RowChangeEvent(CType(e.Row, DataSetGiftCard.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000A15 RID: 2581 RVA: 0x000A773C File Offset: 0x000A593C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As DataSetGiftCard.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New DataSetGiftCard.DataTable1RowChangeEvent(CType(e.Row, DataSetGiftCard.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000A16 RID: 2582 RVA: 0x000A778C File Offset: 0x000A598C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As DataSetGiftCard.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New DataSetGiftCard.DataTable1RowChangeEvent(CType(e.Row, DataSetGiftCard.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000A17 RID: 2583 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As DataSetGiftCard.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x06000A18 RID: 2584 RVA: 0x000A77DC File Offset: 0x000A59DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetGiftCard As DataSetGiftCard = New DataSetGiftCard()
				Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
				xmlSchemaAny.[Namespace] = "http://www.w3.org/2001/XMLSchema"
				xmlSchemaAny.MinOccurs = 0D
				xmlSchemaAny.MaxOccurs = Decimal.MaxValue
				xmlSchemaAny.ProcessContents = XmlSchemaContentProcessing.Lax
				xmlSchemaSequence.Items.Add(xmlSchemaAny)
				Dim xmlSchemaAny2 As XmlSchemaAny = New XmlSchemaAny()
				xmlSchemaAny2.[Namespace] = "urn:schemas-microsoft-com:xml-diffgram-v1"
				xmlSchemaAny2.MinOccurs = 1D
				xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax
				xmlSchemaSequence.Items.Add(xmlSchemaAny2)
				Dim xmlSchemaAttribute As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute.Name = "namespace"
				xmlSchemaAttribute.FixedValue = dataSetGiftCard.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetGiftCard.GetSchemaSerializable()
				Dim flag As Boolean = xs.Contains(schemaSerializable.TargetNamespace)
				If flag Then
					Dim memoryStream As MemoryStream = New MemoryStream()
					Dim memoryStream2 As MemoryStream = New MemoryStream()
					Try
						schemaSerializable.Write(memoryStream)
						For Each obj As Object In xs.Schemas(schemaSerializable.TargetNamespace)
							Dim xmlSchema As XmlSchema = CType(obj, XmlSchema)
							memoryStream2.SetLength(0L)
							xmlSchema.Write(memoryStream2)
							Dim flag2 As Boolean = memoryStream.Length = memoryStream2.Length
							If flag2 Then
								memoryStream.Position = 0L
								memoryStream2.Position = 0L
								While memoryStream.Position <> memoryStream.Length AndAlso memoryStream.ReadByte() = memoryStream2.ReadByte()
								End While
								Dim flag3 As Boolean = memoryStream.Position = memoryStream.Length
								If flag3 Then
									Return xmlSchemaComplexType
								End If
							End If
						Next
					Finally
						Dim flag4 As Boolean = memoryStream IsNot Nothing
						If flag4 Then
							memoryStream.Close()
						End If
						Dim flag5 As Boolean = memoryStream2 IsNot Nothing
						If flag5 Then
							memoryStream2.Close()
						End If
					End Try
				End If
				xs.Add(schemaSerializable)
				Return xmlSchemaComplexType
			End Function

			' Token: 0x0400034E RID: 846
			Private columnCID As DataColumn

			' Token: 0x0400034F RID: 847
			Private columnCustID As DataColumn

			' Token: 0x04000350 RID: 848
			Private columnCustName As DataColumn

			' Token: 0x04000351 RID: 849
			Private columnInvNo As DataColumn

			' Token: 0x04000352 RID: 850
			Private columnInvDate As DataColumn

			' Token: 0x04000353 RID: 851
			Private columnBillAmt As DataColumn

			' Token: 0x04000354 RID: 852
			Private columnGiftCode As DataColumn

			' Token: 0x04000355 RID: 853
			Private columnGiftAmt As DataColumn

			' Token: 0x04000356 RID: 854
			Private columnValidfrom As DataColumn

			' Token: 0x04000357 RID: 855
			Private columnValidto As DataColumn

			' Token: 0x04000358 RID: 856
			Private columnStatus As DataColumn

			' Token: 0x04000359 RID: 857
			Private columnContact As DataColumn
		End Class

		' Token: 0x02000038 RID: 56
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x06000A19 RID: 2585 RVA: 0x0000B3F7 File Offset: 0x000095F7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, DataSetGiftCard.DataTable1DataTable)
			End Sub

			' Token: 0x17000473 RID: 1139
			' (get) Token: 0x06000A1A RID: 2586 RVA: 0x000A7A30 File Offset: 0x000A5C30
			' (set) Token: 0x06000A1B RID: 2587 RVA: 0x0000B413 File Offset: 0x00009613
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CID As Integer
				Get
					Dim num As Integer
					Try
						num = Conversions.ToInteger(MyBase.Item(Me.tableDataTable1.CIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CID' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Integer)
					MyBase.Item(Me.tableDataTable1.CIDColumn) = value
				End Set
			End Property

			' Token: 0x17000474 RID: 1140
			' (get) Token: 0x06000A1C RID: 2588 RVA: 0x000A7A80 File Offset: 0x000A5C80
			' (set) Token: 0x06000A1D RID: 2589 RVA: 0x0000B42E File Offset: 0x0000962E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CustID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CustIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CustID' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CustIDColumn) = value
				End Set
			End Property

			' Token: 0x17000475 RID: 1141
			' (get) Token: 0x06000A1E RID: 2590 RVA: 0x000A7AD0 File Offset: 0x000A5CD0
			' (set) Token: 0x06000A1F RID: 2591 RVA: 0x0000B444 File Offset: 0x00009644
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CustName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CustNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CustName' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CustNameColumn) = value
				End Set
			End Property

			' Token: 0x17000476 RID: 1142
			' (get) Token: 0x06000A20 RID: 2592 RVA: 0x000A7B20 File Offset: 0x000A5D20
			' (set) Token: 0x06000A21 RID: 2593 RVA: 0x0000B45A File Offset: 0x0000965A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property InvNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.InvNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'InvNo' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.InvNoColumn) = value
				End Set
			End Property

			' Token: 0x17000477 RID: 1143
			' (get) Token: 0x06000A22 RID: 2594 RVA: 0x000A7B70 File Offset: 0x000A5D70
			' (set) Token: 0x06000A23 RID: 2595 RVA: 0x0000B470 File Offset: 0x00009670
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property InvDate As DateTime
				Get
					Dim dateTime As DateTime
					Try
						dateTime = Conversions.ToDate(MyBase.Item(Me.tableDataTable1.InvDateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'InvDate' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return dateTime
				End Get
				Set(value As DateTime)
					MyBase.Item(Me.tableDataTable1.InvDateColumn) = value
				End Set
			End Property

			' Token: 0x17000478 RID: 1144
			' (get) Token: 0x06000A24 RID: 2596 RVA: 0x000A7BC0 File Offset: 0x000A5DC0
			' (set) Token: 0x06000A25 RID: 2597 RVA: 0x0000B48B File Offset: 0x0000968B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property BillAmt As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableDataTable1.BillAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'BillAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableDataTable1.BillAmtColumn) = value
				End Set
			End Property

			' Token: 0x17000479 RID: 1145
			' (get) Token: 0x06000A26 RID: 2598 RVA: 0x000A7C10 File Offset: 0x000A5E10
			' (set) Token: 0x06000A27 RID: 2599 RVA: 0x0000B4A6 File Offset: 0x000096A6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GiftCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.GiftCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GiftCode' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.GiftCodeColumn) = value
				End Set
			End Property

			' Token: 0x1700047A RID: 1146
			' (get) Token: 0x06000A28 RID: 2600 RVA: 0x000A7C60 File Offset: 0x000A5E60
			' (set) Token: 0x06000A29 RID: 2601 RVA: 0x0000B4BC File Offset: 0x000096BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GiftAmt As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableDataTable1.GiftAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GiftAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableDataTable1.GiftAmtColumn) = value
				End Set
			End Property

			' Token: 0x1700047B RID: 1147
			' (get) Token: 0x06000A2A RID: 2602 RVA: 0x000A7CB0 File Offset: 0x000A5EB0
			' (set) Token: 0x06000A2B RID: 2603 RVA: 0x0000B4D7 File Offset: 0x000096D7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Validfrom As DateTime
				Get
					Dim dateTime As DateTime
					Try
						dateTime = Conversions.ToDate(MyBase.Item(Me.tableDataTable1.ValidfromColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Validfrom' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return dateTime
				End Get
				Set(value As DateTime)
					MyBase.Item(Me.tableDataTable1.ValidfromColumn) = value
				End Set
			End Property

			' Token: 0x1700047C RID: 1148
			' (get) Token: 0x06000A2C RID: 2604 RVA: 0x000A7D00 File Offset: 0x000A5F00
			' (set) Token: 0x06000A2D RID: 2605 RVA: 0x0000B4F2 File Offset: 0x000096F2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Validto As DateTime
				Get
					Dim dateTime As DateTime
					Try
						dateTime = Conversions.ToDate(MyBase.Item(Me.tableDataTable1.ValidtoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Validto' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return dateTime
				End Get
				Set(value As DateTime)
					MyBase.Item(Me.tableDataTable1.ValidtoColumn) = value
				End Set
			End Property

			' Token: 0x1700047D RID: 1149
			' (get) Token: 0x06000A2E RID: 2606 RVA: 0x000A7D50 File Offset: 0x000A5F50
			' (set) Token: 0x06000A2F RID: 2607 RVA: 0x0000B50D File Offset: 0x0000970D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Status As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.StatusColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Status' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.StatusColumn) = value
				End Set
			End Property

			' Token: 0x1700047E RID: 1150
			' (get) Token: 0x06000A30 RID: 2608 RVA: 0x000A7DA0 File Offset: 0x000A5FA0
			' (set) Token: 0x06000A31 RID: 2609 RVA: 0x0000B523 File Offset: 0x00009723
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Contact As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.ContactColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Contact' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.ContactColumn) = value
				End Set
			End Property

			' Token: 0x06000A32 RID: 2610 RVA: 0x000A7DF0 File Offset: 0x000A5FF0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCIDNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CIDColumn)
			End Function

			' Token: 0x06000A33 RID: 2611 RVA: 0x0000B539 File Offset: 0x00009739
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCIDNull()
				MyBase.Item(Me.tableDataTable1.CIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A34 RID: 2612 RVA: 0x000A7E14 File Offset: 0x000A6014
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCustIDNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CustIDColumn)
			End Function

			' Token: 0x06000A35 RID: 2613 RVA: 0x0000B558 File Offset: 0x00009758
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCustIDNull()
				MyBase.Item(Me.tableDataTable1.CustIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A36 RID: 2614 RVA: 0x000A7E38 File Offset: 0x000A6038
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCustNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CustNameColumn)
			End Function

			' Token: 0x06000A37 RID: 2615 RVA: 0x0000B577 File Offset: 0x00009777
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCustNameNull()
				MyBase.Item(Me.tableDataTable1.CustNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A38 RID: 2616 RVA: 0x000A7E5C File Offset: 0x000A605C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsInvNoNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.InvNoColumn)
			End Function

			' Token: 0x06000A39 RID: 2617 RVA: 0x0000B596 File Offset: 0x00009796
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetInvNoNull()
				MyBase.Item(Me.tableDataTable1.InvNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A3A RID: 2618 RVA: 0x000A7E80 File Offset: 0x000A6080
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsInvDateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.InvDateColumn)
			End Function

			' Token: 0x06000A3B RID: 2619 RVA: 0x0000B5B5 File Offset: 0x000097B5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetInvDateNull()
				MyBase.Item(Me.tableDataTable1.InvDateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A3C RID: 2620 RVA: 0x000A7EA4 File Offset: 0x000A60A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBillAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.BillAmtColumn)
			End Function

			' Token: 0x06000A3D RID: 2621 RVA: 0x0000B5D4 File Offset: 0x000097D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBillAmtNull()
				MyBase.Item(Me.tableDataTable1.BillAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A3E RID: 2622 RVA: 0x000A7EC8 File Offset: 0x000A60C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGiftCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.GiftCodeColumn)
			End Function

			' Token: 0x06000A3F RID: 2623 RVA: 0x0000B5F3 File Offset: 0x000097F3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGiftCodeNull()
				MyBase.Item(Me.tableDataTable1.GiftCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A40 RID: 2624 RVA: 0x000A7EEC File Offset: 0x000A60EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGiftAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.GiftAmtColumn)
			End Function

			' Token: 0x06000A41 RID: 2625 RVA: 0x0000B612 File Offset: 0x00009812
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGiftAmtNull()
				MyBase.Item(Me.tableDataTable1.GiftAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A42 RID: 2626 RVA: 0x000A7F10 File Offset: 0x000A6110
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsValidfromNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ValidfromColumn)
			End Function

			' Token: 0x06000A43 RID: 2627 RVA: 0x0000B631 File Offset: 0x00009831
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetValidfromNull()
				MyBase.Item(Me.tableDataTable1.ValidfromColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A44 RID: 2628 RVA: 0x000A7F34 File Offset: 0x000A6134
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsValidtoNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ValidtoColumn)
			End Function

			' Token: 0x06000A45 RID: 2629 RVA: 0x0000B650 File Offset: 0x00009850
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetValidtoNull()
				MyBase.Item(Me.tableDataTable1.ValidtoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A46 RID: 2630 RVA: 0x000A7F58 File Offset: 0x000A6158
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsStatusNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.StatusColumn)
			End Function

			' Token: 0x06000A47 RID: 2631 RVA: 0x0000B66F File Offset: 0x0000986F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetStatusNull()
				MyBase.Item(Me.tableDataTable1.StatusColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000A48 RID: 2632 RVA: 0x000A7F7C File Offset: 0x000A617C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsContactNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ContactColumn)
			End Function

			' Token: 0x06000A49 RID: 2633 RVA: 0x0000B68E File Offset: 0x0000988E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetContactNull()
				MyBase.Item(Me.tableDataTable1.ContactColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0400035E RID: 862
			Private tableDataTable1 As DataSetGiftCard.DataTable1DataTable
		End Class

		' Token: 0x02000039 RID: 57
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x06000A4A RID: 2634 RVA: 0x0000B6AD File Offset: 0x000098AD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetGiftCard.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x1700047F RID: 1151
			' (get) Token: 0x06000A4B RID: 2635 RVA: 0x000A7FA0 File Offset: 0x000A61A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetGiftCard.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17000480 RID: 1152
			' (get) Token: 0x06000A4C RID: 2636 RVA: 0x000A7FB8 File Offset: 0x000A61B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x0400035F RID: 863
			Private eventRow As DataSetGiftCard.DataTable1Row

			' Token: 0x04000360 RID: 864
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
