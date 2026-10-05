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
	' Token: 0x02000323 RID: 803
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSetCatalogue")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSetCatalogue
		Inherits DataSet

		' Token: 0x0600BD51 RID: 48465 RVA: 0x007903C8 File Offset: 0x0078E5C8
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

		' Token: 0x0600BD52 RID: 48466 RVA: 0x00790420 File Offset: 0x0078E620
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
						MyBase.Tables.Add(New DataSetCatalogue.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x17004B7C RID: 19324
		' (get) Token: 0x0600BD53 RID: 48467 RVA: 0x007905B4 File Offset: 0x0078E7B4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As DataSetCatalogue.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x17004B7D RID: 19325
		' (get) Token: 0x0600BD54 RID: 48468 RVA: 0x007905CC File Offset: 0x0078E7CC
		' (set) Token: 0x0600BD55 RID: 48469 RVA: 0x0005499F File Offset: 0x00052B9F
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

		' Token: 0x17004B7E RID: 19326
		' (get) Token: 0x0600BD56 RID: 48470 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x17004B7F RID: 19327
		' (get) Token: 0x0600BD57 RID: 48471 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x0600BD58 RID: 48472 RVA: 0x000549A9 File Offset: 0x00052BA9
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x0600BD59 RID: 48473 RVA: 0x007905E4 File Offset: 0x0078E7E4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSetCatalogue As DataSetCatalogue = CType(MyBase.Clone(), DataSetCatalogue)
			dataSetCatalogue.InitVars()
			dataSetCatalogue.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSetCatalogue
		End Function

		' Token: 0x0600BD5A RID: 48474 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x0600BD5B RID: 48475 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x0600BD5C RID: 48476 RVA: 0x00790618 File Offset: 0x0078E818
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
					MyBase.Tables.Add(New DataSetCatalogue.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x0600BD5D RID: 48477 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x0600BD5E RID: 48478 RVA: 0x000549C1 File Offset: 0x00052BC1
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x0600BD5F RID: 48479 RVA: 0x007906FC File Offset: 0x0078E8FC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), DataSetCatalogue.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
		End Sub

		' Token: 0x0600BD60 RID: 48480 RVA: 0x00790748 File Offset: 0x0078E948
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSetCatalogue"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSetCatalogue.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New DataSetCatalogue.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
		End Sub

		' Token: 0x0600BD61 RID: 48481 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x0600BD62 RID: 48482 RVA: 0x007907A8 File Offset: 0x0078E9A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x0600BD63 RID: 48483 RVA: 0x007907CC File Offset: 0x0078E9CC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSetCatalogue As DataSetCatalogue = New DataSetCatalogue()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSetCatalogue.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSetCatalogue.GetSchemaSerializable()
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

		' Token: 0x04004C00 RID: 19456
		Private tableDataTable1 As DataSetCatalogue.DataTable1DataTable

		' Token: 0x04004C01 RID: 19457
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x02000324 RID: 804
		' (Invoke) Token: 0x0600BD67 RID: 48487
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As DataSetCatalogue.DataTable1RowChangeEvent)

		' Token: 0x02000325 RID: 805
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of DataSetCatalogue.DataTable1Row)

			' Token: 0x0600BD68 RID: 48488 RVA: 0x000549CC File Offset: 0x00052BCC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600BD69 RID: 48489 RVA: 0x00790960 File Offset: 0x0078EB60
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

			' Token: 0x0600BD6A RID: 48490 RVA: 0x000549F7 File Offset: 0x00052BF7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17004B80 RID: 19328
			' (get) Token: 0x0600BD6B RID: 48491 RVA: 0x00790A2C File Offset: 0x0078EC2C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PIDColumn As DataColumn
				Get
					Return Me.columnPID
				End Get
			End Property

			' Token: 0x17004B81 RID: 19329
			' (get) Token: 0x0600BD6C RID: 48492 RVA: 0x00790A44 File Offset: 0x0078EC44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductCodeColumn As DataColumn
				Get
					Return Me.columnProductCode
				End Get
			End Property

			' Token: 0x17004B82 RID: 19330
			' (get) Token: 0x0600BD6D RID: 48493 RVA: 0x00790A5C File Offset: 0x0078EC5C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductNameColumn As DataColumn
				Get
					Return Me.columnProductName
				End Get
			End Property

			' Token: 0x17004B83 RID: 19331
			' (get) Token: 0x0600BD6E RID: 48494 RVA: 0x00790A74 File Offset: 0x0078EC74
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x17004B84 RID: 19332
			' (get) Token: 0x0600BD6F RID: 48495 RVA: 0x00790A8C File Offset: 0x0078EC8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MRPColumn As DataColumn
				Get
					Return Me.columnMRP
				End Get
			End Property

			' Token: 0x17004B85 RID: 19333
			' (get) Token: 0x0600BD70 RID: 48496 RVA: 0x00790AA4 File Offset: 0x0078ECA4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RSalePriceColumn As DataColumn
				Get
					Return Me.columnRSalePrice
				End Get
			End Property

			' Token: 0x17004B86 RID: 19334
			' (get) Token: 0x0600BD71 RID: 48497 RVA: 0x00790ABC File Offset: 0x0078ECBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountColumn As DataColumn
				Get
					Return Me.columnDiscount
				End Get
			End Property

			' Token: 0x17004B87 RID: 19335
			' (get) Token: 0x0600BD72 RID: 48498 RVA: 0x00790AD4 File Offset: 0x0078ECD4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property StatusColumn As DataColumn
				Get
					Return Me.columnStatus
				End Get
			End Property

			' Token: 0x17004B88 RID: 19336
			' (get) Token: 0x0600BD73 RID: 48499 RVA: 0x00790AEC File Offset: 0x0078ECEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PhotoColumn As DataColumn
				Get
					Return Me.columnPhoto
				End Get
			End Property

			' Token: 0x17004B89 RID: 19337
			' (get) Token: 0x0600BD74 RID: 48500 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17004B8A RID: 19338
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetCatalogue.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), DataSetCatalogue.DataTable1Row)
				End Get
			End Property

			' Token: 0x14000050 RID: 80
			' (add) Token: 0x0600BD76 RID: 48502 RVA: 0x00790B28 File Offset: 0x0078ED28
			' (remove) Token: 0x0600BD77 RID: 48503 RVA: 0x00790B60 File Offset: 0x0078ED60
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As DataSetCatalogue.DataTable1RowChangeEventHandler

			' Token: 0x14000051 RID: 81
			' (add) Token: 0x0600BD78 RID: 48504 RVA: 0x00790B98 File Offset: 0x0078ED98
			' (remove) Token: 0x0600BD79 RID: 48505 RVA: 0x00790BD0 File Offset: 0x0078EDD0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As DataSetCatalogue.DataTable1RowChangeEventHandler

			' Token: 0x14000052 RID: 82
			' (add) Token: 0x0600BD7A RID: 48506 RVA: 0x00790C08 File Offset: 0x0078EE08
			' (remove) Token: 0x0600BD7B RID: 48507 RVA: 0x00790C40 File Offset: 0x0078EE40
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As DataSetCatalogue.DataTable1RowChangeEventHandler

			' Token: 0x14000053 RID: 83
			' (add) Token: 0x0600BD7C RID: 48508 RVA: 0x00790C78 File Offset: 0x0078EE78
			' (remove) Token: 0x0600BD7D RID: 48509 RVA: 0x00790CB0 File Offset: 0x0078EEB0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As DataSetCatalogue.DataTable1RowChangeEventHandler

			' Token: 0x0600BD7E RID: 48510 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As DataSetCatalogue.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600BD7F RID: 48511 RVA: 0x00790CE8 File Offset: 0x0078EEE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(PID As String, ProductCode As String, ProductName As String, Barcode As String, MRP As String, RSalePrice As String, Discount As String, Status As String, Photo As Byte()) As DataSetCatalogue.DataTable1Row
				Dim dataTable1Row As DataSetCatalogue.DataTable1Row = CType(MyBase.NewRow(), DataSetCatalogue.DataTable1Row)
				Dim array As Object() = New Object() { PID, ProductCode, ProductName, Barcode, MRP, RSalePrice, Discount, Status, Photo }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x0600BD80 RID: 48512 RVA: 0x00790D50 File Offset: 0x0078EF50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As DataSetCatalogue.DataTable1DataTable = CType(MyBase.Clone(), DataSetCatalogue.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x0600BD81 RID: 48513 RVA: 0x00790D78 File Offset: 0x0078EF78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetCatalogue.DataTable1DataTable()
			End Function

			' Token: 0x0600BD82 RID: 48514 RVA: 0x00790D90 File Offset: 0x0078EF90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnPID = MyBase.Columns("PID")
				Me.columnProductCode = MyBase.Columns("ProductCode")
				Me.columnProductName = MyBase.Columns("ProductName")
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnMRP = MyBase.Columns("MRP")
				Me.columnRSalePrice = MyBase.Columns("RSalePrice")
				Me.columnDiscount = MyBase.Columns("Discount")
				Me.columnStatus = MyBase.Columns("Status")
				Me.columnPhoto = MyBase.Columns("Photo")
			End Sub

			' Token: 0x0600BD83 RID: 48515 RVA: 0x00790E64 File Offset: 0x0078F064
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnPID = New DataColumn("PID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPID)
				Me.columnProductCode = New DataColumn("ProductCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductCode)
				Me.columnProductName = New DataColumn("ProductName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductName)
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnMRP = New DataColumn("MRP", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMRP)
				Me.columnRSalePrice = New DataColumn("RSalePrice", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRSalePrice)
				Me.columnDiscount = New DataColumn("Discount", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscount)
				Me.columnStatus = New DataColumn("Status", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnStatus)
				Me.columnPhoto = New DataColumn("Photo", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPhoto)
			End Sub

			' Token: 0x0600BD84 RID: 48516 RVA: 0x00791010 File Offset: 0x0078F210
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As DataSetCatalogue.DataTable1Row
				Return CType(MyBase.NewRow(), DataSetCatalogue.DataTable1Row)
			End Function

			' Token: 0x0600BD85 RID: 48517 RVA: 0x00791030 File Offset: 0x0078F230
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetCatalogue.DataTable1Row(builder)
			End Function

			' Token: 0x0600BD86 RID: 48518 RVA: 0x00791048 File Offset: 0x0078F248
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetCatalogue.DataTable1Row)
			End Function

			' Token: 0x0600BD87 RID: 48519 RVA: 0x00791064 File Offset: 0x0078F264
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As DataSetCatalogue.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New DataSetCatalogue.DataTable1RowChangeEvent(CType(e.Row, DataSetCatalogue.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600BD88 RID: 48520 RVA: 0x007910B4 File Offset: 0x0078F2B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As DataSetCatalogue.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New DataSetCatalogue.DataTable1RowChangeEvent(CType(e.Row, DataSetCatalogue.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600BD89 RID: 48521 RVA: 0x00791104 File Offset: 0x0078F304
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As DataSetCatalogue.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New DataSetCatalogue.DataTable1RowChangeEvent(CType(e.Row, DataSetCatalogue.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600BD8A RID: 48522 RVA: 0x00791154 File Offset: 0x0078F354
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As DataSetCatalogue.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New DataSetCatalogue.DataTable1RowChangeEvent(CType(e.Row, DataSetCatalogue.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600BD8B RID: 48523 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As DataSetCatalogue.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600BD8C RID: 48524 RVA: 0x007911A4 File Offset: 0x0078F3A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetCatalogue As DataSetCatalogue = New DataSetCatalogue()
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
				xmlSchemaAttribute.FixedValue = dataSetCatalogue.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetCatalogue.GetSchemaSerializable()
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

			' Token: 0x04004C02 RID: 19458
			Private columnPID As DataColumn

			' Token: 0x04004C03 RID: 19459
			Private columnProductCode As DataColumn

			' Token: 0x04004C04 RID: 19460
			Private columnProductName As DataColumn

			' Token: 0x04004C05 RID: 19461
			Private columnBarcode As DataColumn

			' Token: 0x04004C06 RID: 19462
			Private columnMRP As DataColumn

			' Token: 0x04004C07 RID: 19463
			Private columnRSalePrice As DataColumn

			' Token: 0x04004C08 RID: 19464
			Private columnDiscount As DataColumn

			' Token: 0x04004C09 RID: 19465
			Private columnStatus As DataColumn

			' Token: 0x04004C0A RID: 19466
			Private columnPhoto As DataColumn
		End Class

		' Token: 0x02000326 RID: 806
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x0600BD8D RID: 48525 RVA: 0x00054A0A File Offset: 0x00052C0A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, DataSetCatalogue.DataTable1DataTable)
			End Sub

			' Token: 0x17004B8B RID: 19339
			' (get) Token: 0x0600BD8E RID: 48526 RVA: 0x007913F8 File Offset: 0x0078F5F8
			' (set) Token: 0x0600BD8F RID: 48527 RVA: 0x00054A26 File Offset: 0x00052C26
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.PIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PID' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.PIDColumn) = value
				End Set
			End Property

			' Token: 0x17004B8C RID: 19340
			' (get) Token: 0x0600BD90 RID: 48528 RVA: 0x00791448 File Offset: 0x0078F648
			' (set) Token: 0x0600BD91 RID: 48529 RVA: 0x00054A3C File Offset: 0x00052C3C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.ProductCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductCode' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.ProductCodeColumn) = value
				End Set
			End Property

			' Token: 0x17004B8D RID: 19341
			' (get) Token: 0x0600BD92 RID: 48530 RVA: 0x00791498 File Offset: 0x0078F698
			' (set) Token: 0x0600BD93 RID: 48531 RVA: 0x00054A52 File Offset: 0x00052C52
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.ProductNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductName' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.ProductNameColumn) = value
				End Set
			End Property

			' Token: 0x17004B8E RID: 19342
			' (get) Token: 0x0600BD94 RID: 48532 RVA: 0x007914E8 File Offset: 0x0078F6E8
			' (set) Token: 0x0600BD95 RID: 48533 RVA: 0x00054A68 File Offset: 0x00052C68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Barcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.BarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Barcode' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.BarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17004B8F RID: 19343
			' (get) Token: 0x0600BD96 RID: 48534 RVA: 0x00791538 File Offset: 0x0078F738
			' (set) Token: 0x0600BD97 RID: 48535 RVA: 0x00054A7E File Offset: 0x00052C7E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MRP As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.MRPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MRP' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.MRPColumn) = value
				End Set
			End Property

			' Token: 0x17004B90 RID: 19344
			' (get) Token: 0x0600BD98 RID: 48536 RVA: 0x00791588 File Offset: 0x0078F788
			' (set) Token: 0x0600BD99 RID: 48537 RVA: 0x00054A94 File Offset: 0x00052C94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property RSalePrice As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.RSalePriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'RSalePrice' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.RSalePriceColumn) = value
				End Set
			End Property

			' Token: 0x17004B91 RID: 19345
			' (get) Token: 0x0600BD9A RID: 48538 RVA: 0x007915D8 File Offset: 0x0078F7D8
			' (set) Token: 0x0600BD9B RID: 48539 RVA: 0x00054AAA File Offset: 0x00052CAA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Discount As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.DiscountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Discount' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.DiscountColumn) = value
				End Set
			End Property

			' Token: 0x17004B92 RID: 19346
			' (get) Token: 0x0600BD9C RID: 48540 RVA: 0x00791628 File Offset: 0x0078F828
			' (set) Token: 0x0600BD9D RID: 48541 RVA: 0x00054AC0 File Offset: 0x00052CC0
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

			' Token: 0x17004B93 RID: 19347
			' (get) Token: 0x0600BD9E RID: 48542 RVA: 0x00791678 File Offset: 0x0078F878
			' (set) Token: 0x0600BD9F RID: 48543 RVA: 0x00054AD6 File Offset: 0x00052CD6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Photo As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable1.PhotoColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Photo' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable1.PhotoColumn) = value
				End Set
			End Property

			' Token: 0x0600BDA0 RID: 48544 RVA: 0x007916C8 File Offset: 0x0078F8C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPIDNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PIDColumn)
			End Function

			' Token: 0x0600BDA1 RID: 48545 RVA: 0x00054AEC File Offset: 0x00052CEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPIDNull()
				MyBase.Item(Me.tableDataTable1.PIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600BDA2 RID: 48546 RVA: 0x007916EC File Offset: 0x0078F8EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ProductCodeColumn)
			End Function

			' Token: 0x0600BDA3 RID: 48547 RVA: 0x00054B0B File Offset: 0x00052D0B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductCodeNull()
				MyBase.Item(Me.tableDataTable1.ProductCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600BDA4 RID: 48548 RVA: 0x00791710 File Offset: 0x0078F910
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ProductNameColumn)
			End Function

			' Token: 0x0600BDA5 RID: 48549 RVA: 0x00054B2A File Offset: 0x00052D2A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductNameNull()
				MyBase.Item(Me.tableDataTable1.ProductNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600BDA6 RID: 48550 RVA: 0x00791734 File Offset: 0x0078F934
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.BarcodeColumn)
			End Function

			' Token: 0x0600BDA7 RID: 48551 RVA: 0x00054B49 File Offset: 0x00052D49
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableDataTable1.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600BDA8 RID: 48552 RVA: 0x00791758 File Offset: 0x0078F958
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.MRPColumn)
			End Function

			' Token: 0x0600BDA9 RID: 48553 RVA: 0x00054B68 File Offset: 0x00052D68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMRPNull()
				MyBase.Item(Me.tableDataTable1.MRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600BDAA RID: 48554 RVA: 0x0079177C File Offset: 0x0078F97C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRSalePriceNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.RSalePriceColumn)
			End Function

			' Token: 0x0600BDAB RID: 48555 RVA: 0x00054B87 File Offset: 0x00052D87
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRSalePriceNull()
				MyBase.Item(Me.tableDataTable1.RSalePriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600BDAC RID: 48556 RVA: 0x007917A0 File Offset: 0x0078F9A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.DiscountColumn)
			End Function

			' Token: 0x0600BDAD RID: 48557 RVA: 0x00054BA6 File Offset: 0x00052DA6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountNull()
				MyBase.Item(Me.tableDataTable1.DiscountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600BDAE RID: 48558 RVA: 0x007917C4 File Offset: 0x0078F9C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsStatusNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.StatusColumn)
			End Function

			' Token: 0x0600BDAF RID: 48559 RVA: 0x00054BC5 File Offset: 0x00052DC5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetStatusNull()
				MyBase.Item(Me.tableDataTable1.StatusColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600BDB0 RID: 48560 RVA: 0x007917E8 File Offset: 0x0078F9E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPhotoNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PhotoColumn)
			End Function

			' Token: 0x0600BDB1 RID: 48561 RVA: 0x00054BE4 File Offset: 0x00052DE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPhotoNull()
				MyBase.Item(Me.tableDataTable1.PhotoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x04004C0F RID: 19471
			Private tableDataTable1 As DataSetCatalogue.DataTable1DataTable
		End Class

		' Token: 0x02000327 RID: 807
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600BDB2 RID: 48562 RVA: 0x00054C03 File Offset: 0x00052E03
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetCatalogue.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17004B94 RID: 19348
			' (get) Token: 0x0600BDB3 RID: 48563 RVA: 0x0079180C File Offset: 0x0078FA0C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetCatalogue.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17004B95 RID: 19349
			' (get) Token: 0x0600BDB4 RID: 48564 RVA: 0x00791824 File Offset: 0x0078FA24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x04004C10 RID: 19472
			Private eventRow As DataSetCatalogue.DataTable1Row

			' Token: 0x04004C11 RID: 19473
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
