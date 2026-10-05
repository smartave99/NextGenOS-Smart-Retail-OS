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
	' Token: 0x0200048F RID: 1167
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSetGSTSale")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSetGSTSale
		Inherits DataSet

		' Token: 0x0600EA09 RID: 59913 RVA: 0x008D9588 File Offset: 0x008D7788
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

		' Token: 0x0600EA0A RID: 59914 RVA: 0x008D95E0 File Offset: 0x008D77E0
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
						MyBase.Tables.Add(New DataSetGSTSale.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x17005A00 RID: 23040
		' (get) Token: 0x0600EA0B RID: 59915 RVA: 0x008D9774 File Offset: 0x008D7974
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As DataSetGSTSale.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x17005A01 RID: 23041
		' (get) Token: 0x0600EA0C RID: 59916 RVA: 0x008D978C File Offset: 0x008D798C
		' (set) Token: 0x0600EA0D RID: 59917 RVA: 0x0006697E File Offset: 0x00064B7E
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

		' Token: 0x17005A02 RID: 23042
		' (get) Token: 0x0600EA0E RID: 59918 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x17005A03 RID: 23043
		' (get) Token: 0x0600EA0F RID: 59919 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x0600EA10 RID: 59920 RVA: 0x00066988 File Offset: 0x00064B88
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x0600EA11 RID: 59921 RVA: 0x008D97A4 File Offset: 0x008D79A4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSetGSTSale As DataSetGSTSale = CType(MyBase.Clone(), DataSetGSTSale)
			dataSetGSTSale.InitVars()
			dataSetGSTSale.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSetGSTSale
		End Function

		' Token: 0x0600EA12 RID: 59922 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x0600EA13 RID: 59923 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x0600EA14 RID: 59924 RVA: 0x008D97D8 File Offset: 0x008D79D8
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
					MyBase.Tables.Add(New DataSetGSTSale.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x0600EA15 RID: 59925 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x0600EA16 RID: 59926 RVA: 0x000669A0 File Offset: 0x00064BA0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x0600EA17 RID: 59927 RVA: 0x008D98BC File Offset: 0x008D7ABC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), DataSetGSTSale.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
		End Sub

		' Token: 0x0600EA18 RID: 59928 RVA: 0x008D9908 File Offset: 0x008D7B08
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSetGSTSale"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSetGSTSale.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New DataSetGSTSale.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
		End Sub

		' Token: 0x0600EA19 RID: 59929 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x0600EA1A RID: 59930 RVA: 0x008D9968 File Offset: 0x008D7B68
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x0600EA1B RID: 59931 RVA: 0x008D998C File Offset: 0x008D7B8C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSetGSTSale As DataSetGSTSale = New DataSetGSTSale()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSetGSTSale.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSetGSTSale.GetSchemaSerializable()
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

		' Token: 0x040059AB RID: 22955
		Private tableDataTable1 As DataSetGSTSale.DataTable1DataTable

		' Token: 0x040059AC RID: 22956
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x02000490 RID: 1168
		' (Invoke) Token: 0x0600EA1F RID: 59935
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As DataSetGSTSale.DataTable1RowChangeEvent)

		' Token: 0x02000491 RID: 1169
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of DataSetGSTSale.DataTable1Row)

			' Token: 0x0600EA20 RID: 59936 RVA: 0x000669AB File Offset: 0x00064BAB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600EA21 RID: 59937 RVA: 0x008D9B20 File Offset: 0x008D7D20
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

			' Token: 0x0600EA22 RID: 59938 RVA: 0x000669D6 File Offset: 0x00064BD6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17005A04 RID: 23044
			' (get) Token: 0x0600EA23 RID: 59939 RVA: 0x008D9BEC File Offset: 0x008D7DEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BillNoColumn As DataColumn
				Get
					Return Me.columnBillNo
				End Get
			End Property

			' Token: 0x17005A05 RID: 23045
			' (get) Token: 0x0600EA24 RID: 59940 RVA: 0x008D9C04 File Offset: 0x008D7E04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DateColumn As DataColumn
				Get
					Return Me.columnDate
				End Get
			End Property

			' Token: 0x17005A06 RID: 23046
			' (get) Token: 0x0600EA25 RID: 59941 RVA: 0x008D9C1C File Offset: 0x008D7E1C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CNameColumn As DataColumn
				Get
					Return Me.columnCName
				End Get
			End Property

			' Token: 0x17005A07 RID: 23047
			' (get) Token: 0x0600EA26 RID: 59942 RVA: 0x008D9C34 File Offset: 0x008D7E34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GSTINColumn As DataColumn
				Get
					Return Me.columnGSTIN
				End Get
			End Property

			' Token: 0x17005A08 RID: 23048
			' (get) Token: 0x0600EA27 RID: 59943 RVA: 0x008D9C4C File Offset: 0x008D7E4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BillAmtColumn As DataColumn
				Get
					Return Me.columnBillAmt
				End Get
			End Property

			' Token: 0x17005A09 RID: 23049
			' (get) Token: 0x0600EA28 RID: 59944 RVA: 0x008D9C64 File Offset: 0x008D7E64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TxblAmtColumn As DataColumn
				Get
					Return Me.columnTxblAmt
				End Get
			End Property

			' Token: 0x17005A0A RID: 23050
			' (get) Token: 0x0600EA29 RID: 59945 RVA: 0x008D9C7C File Offset: 0x008D7E7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTAmtColumn As DataColumn
				Get
					Return Me.columnCGSTAmt
				End Get
			End Property

			' Token: 0x17005A0B RID: 23051
			' (get) Token: 0x0600EA2A RID: 59946 RVA: 0x008D9C94 File Offset: 0x008D7E94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTAmtColumn As DataColumn
				Get
					Return Me.columnSGSTAmt
				End Get
			End Property

			' Token: 0x17005A0C RID: 23052
			' (get) Token: 0x0600EA2B RID: 59947 RVA: 0x008D9CAC File Offset: 0x008D7EAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTAmtColumn As DataColumn
				Get
					Return Me.columnIGSTAmt
				End Get
			End Property

			' Token: 0x17005A0D RID: 23053
			' (get) Token: 0x0600EA2C RID: 59948 RVA: 0x008D9CC4 File Offset: 0x008D7EC4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSAmtColumn As DataColumn
				Get
					Return Me.columnCESSAmt
				End Get
			End Property

			' Token: 0x17005A0E RID: 23054
			' (get) Token: 0x0600EA2D RID: 59949 RVA: 0x008D9CDC File Offset: 0x008D7EDC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property OtherAmtColumn As DataColumn
				Get
					Return Me.columnOtherAmt
				End Get
			End Property

			' Token: 0x17005A0F RID: 23055
			' (get) Token: 0x0600EA2E RID: 59950 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17005A10 RID: 23056
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetGSTSale.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), DataSetGSTSale.DataTable1Row)
				End Get
			End Property

			' Token: 0x14000118 RID: 280
			' (add) Token: 0x0600EA30 RID: 59952 RVA: 0x008D9D18 File Offset: 0x008D7F18
			' (remove) Token: 0x0600EA31 RID: 59953 RVA: 0x008D9D50 File Offset: 0x008D7F50
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As DataSetGSTSale.DataTable1RowChangeEventHandler

			' Token: 0x14000119 RID: 281
			' (add) Token: 0x0600EA32 RID: 59954 RVA: 0x008D9D88 File Offset: 0x008D7F88
			' (remove) Token: 0x0600EA33 RID: 59955 RVA: 0x008D9DC0 File Offset: 0x008D7FC0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As DataSetGSTSale.DataTable1RowChangeEventHandler

			' Token: 0x1400011A RID: 282
			' (add) Token: 0x0600EA34 RID: 59956 RVA: 0x008D9DF8 File Offset: 0x008D7FF8
			' (remove) Token: 0x0600EA35 RID: 59957 RVA: 0x008D9E30 File Offset: 0x008D8030
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As DataSetGSTSale.DataTable1RowChangeEventHandler

			' Token: 0x1400011B RID: 283
			' (add) Token: 0x0600EA36 RID: 59958 RVA: 0x008D9E68 File Offset: 0x008D8068
			' (remove) Token: 0x0600EA37 RID: 59959 RVA: 0x008D9EA0 File Offset: 0x008D80A0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As DataSetGSTSale.DataTable1RowChangeEventHandler

			' Token: 0x0600EA38 RID: 59960 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As DataSetGSTSale.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600EA39 RID: 59961 RVA: 0x008D9ED8 File Offset: 0x008D80D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(BillNo As String, _Date As String, CName As String, GSTIN As String, BillAmt As String, TxblAmt As String, CGSTAmt As String, SGSTAmt As String, IGSTAmt As String, CESSAmt As String, OtherAmt As String) As DataSetGSTSale.DataTable1Row
				Dim dataTable1Row As DataSetGSTSale.DataTable1Row = CType(MyBase.NewRow(), DataSetGSTSale.DataTable1Row)
				Dim array As Object() = New Object() { BillNo, _Date, CName, GSTIN, BillAmt, TxblAmt, CGSTAmt, SGSTAmt, IGSTAmt, CESSAmt, OtherAmt }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x0600EA3A RID: 59962 RVA: 0x008D9F4C File Offset: 0x008D814C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As DataSetGSTSale.DataTable1DataTable = CType(MyBase.Clone(), DataSetGSTSale.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x0600EA3B RID: 59963 RVA: 0x008D9F74 File Offset: 0x008D8174
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetGSTSale.DataTable1DataTable()
			End Function

			' Token: 0x0600EA3C RID: 59964 RVA: 0x008D9F8C File Offset: 0x008D818C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnBillNo = MyBase.Columns("BillNo")
				Me.columnDate = MyBase.Columns("Date")
				Me.columnCName = MyBase.Columns("CName")
				Me.columnGSTIN = MyBase.Columns("GSTIN")
				Me.columnBillAmt = MyBase.Columns("BillAmt")
				Me.columnTxblAmt = MyBase.Columns("TxblAmt")
				Me.columnCGSTAmt = MyBase.Columns("CGSTAmt")
				Me.columnSGSTAmt = MyBase.Columns("SGSTAmt")
				Me.columnIGSTAmt = MyBase.Columns("IGSTAmt")
				Me.columnCESSAmt = MyBase.Columns("CESSAmt")
				Me.columnOtherAmt = MyBase.Columns("OtherAmt")
			End Sub

			' Token: 0x0600EA3D RID: 59965 RVA: 0x008DA08C File Offset: 0x008D828C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnBillNo = New DataColumn("BillNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBillNo)
				Me.columnDate = New DataColumn("Date", GetType(String), Nothing, MappingType.Element)
				Me.columnDate.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "DateColumn")
				Me.columnDate.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnDate")
				Me.columnDate.ExtendedProperties.Add("Generator_UserColumnName", "Date")
				MyBase.Columns.Add(Me.columnDate)
				Me.columnCName = New DataColumn("CName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCName)
				Me.columnGSTIN = New DataColumn("GSTIN", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGSTIN)
				Me.columnBillAmt = New DataColumn("BillAmt", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBillAmt)
				Me.columnTxblAmt = New DataColumn("TxblAmt", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTxblAmt)
				Me.columnCGSTAmt = New DataColumn("CGSTAmt", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGSTAmt)
				Me.columnSGSTAmt = New DataColumn("SGSTAmt", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGSTAmt)
				Me.columnIGSTAmt = New DataColumn("IGSTAmt", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGSTAmt)
				Me.columnCESSAmt = New DataColumn("CESSAmt", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESSAmt)
				Me.columnOtherAmt = New DataColumn("OtherAmt", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnOtherAmt)
			End Sub

			' Token: 0x0600EA3E RID: 59966 RVA: 0x008DA2E8 File Offset: 0x008D84E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As DataSetGSTSale.DataTable1Row
				Return CType(MyBase.NewRow(), DataSetGSTSale.DataTable1Row)
			End Function

			' Token: 0x0600EA3F RID: 59967 RVA: 0x008DA308 File Offset: 0x008D8508
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetGSTSale.DataTable1Row(builder)
			End Function

			' Token: 0x0600EA40 RID: 59968 RVA: 0x008DA320 File Offset: 0x008D8520
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetGSTSale.DataTable1Row)
			End Function

			' Token: 0x0600EA41 RID: 59969 RVA: 0x008DA33C File Offset: 0x008D853C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As DataSetGSTSale.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New DataSetGSTSale.DataTable1RowChangeEvent(CType(e.Row, DataSetGSTSale.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EA42 RID: 59970 RVA: 0x008DA38C File Offset: 0x008D858C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As DataSetGSTSale.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New DataSetGSTSale.DataTable1RowChangeEvent(CType(e.Row, DataSetGSTSale.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EA43 RID: 59971 RVA: 0x008DA3DC File Offset: 0x008D85DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As DataSetGSTSale.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New DataSetGSTSale.DataTable1RowChangeEvent(CType(e.Row, DataSetGSTSale.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EA44 RID: 59972 RVA: 0x008DA42C File Offset: 0x008D862C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As DataSetGSTSale.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New DataSetGSTSale.DataTable1RowChangeEvent(CType(e.Row, DataSetGSTSale.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EA45 RID: 59973 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As DataSetGSTSale.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600EA46 RID: 59974 RVA: 0x008DA47C File Offset: 0x008D867C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetGSTSale As DataSetGSTSale = New DataSetGSTSale()
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
				xmlSchemaAttribute.FixedValue = dataSetGSTSale.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetGSTSale.GetSchemaSerializable()
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

			' Token: 0x040059AD RID: 22957
			Private columnBillNo As DataColumn

			' Token: 0x040059AE RID: 22958
			Private columnDate As DataColumn

			' Token: 0x040059AF RID: 22959
			Private columnCName As DataColumn

			' Token: 0x040059B0 RID: 22960
			Private columnGSTIN As DataColumn

			' Token: 0x040059B1 RID: 22961
			Private columnBillAmt As DataColumn

			' Token: 0x040059B2 RID: 22962
			Private columnTxblAmt As DataColumn

			' Token: 0x040059B3 RID: 22963
			Private columnCGSTAmt As DataColumn

			' Token: 0x040059B4 RID: 22964
			Private columnSGSTAmt As DataColumn

			' Token: 0x040059B5 RID: 22965
			Private columnIGSTAmt As DataColumn

			' Token: 0x040059B6 RID: 22966
			Private columnCESSAmt As DataColumn

			' Token: 0x040059B7 RID: 22967
			Private columnOtherAmt As DataColumn
		End Class

		' Token: 0x02000492 RID: 1170
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x0600EA47 RID: 59975 RVA: 0x000669E9 File Offset: 0x00064BE9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, DataSetGSTSale.DataTable1DataTable)
			End Sub

			' Token: 0x17005A11 RID: 23057
			' (get) Token: 0x0600EA48 RID: 59976 RVA: 0x008DA6D0 File Offset: 0x008D88D0
			' (set) Token: 0x0600EA49 RID: 59977 RVA: 0x00066A05 File Offset: 0x00064C05
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property BillNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.BillNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'BillNo' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.BillNoColumn) = value
				End Set
			End Property

			' Token: 0x17005A12 RID: 23058
			' (get) Token: 0x0600EA4A RID: 59978 RVA: 0x008DA720 File Offset: 0x008D8920
			' (set) Token: 0x0600EA4B RID: 59979 RVA: 0x00066A1B File Offset: 0x00064C1B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property _Date As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.DateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Date' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.DateColumn) = value
				End Set
			End Property

			' Token: 0x17005A13 RID: 23059
			' (get) Token: 0x0600EA4C RID: 59980 RVA: 0x008DA770 File Offset: 0x008D8970
			' (set) Token: 0x0600EA4D RID: 59981 RVA: 0x00066A31 File Offset: 0x00064C31
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CName' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CNameColumn) = value
				End Set
			End Property

			' Token: 0x17005A14 RID: 23060
			' (get) Token: 0x0600EA4E RID: 59982 RVA: 0x008DA7C0 File Offset: 0x008D89C0
			' (set) Token: 0x0600EA4F RID: 59983 RVA: 0x00066A47 File Offset: 0x00064C47
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GSTIN As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.GSTINColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GSTIN' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.GSTINColumn) = value
				End Set
			End Property

			' Token: 0x17005A15 RID: 23061
			' (get) Token: 0x0600EA50 RID: 59984 RVA: 0x008DA810 File Offset: 0x008D8A10
			' (set) Token: 0x0600EA51 RID: 59985 RVA: 0x00066A5D File Offset: 0x00064C5D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property BillAmt As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.BillAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'BillAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.BillAmtColumn) = value
				End Set
			End Property

			' Token: 0x17005A16 RID: 23062
			' (get) Token: 0x0600EA52 RID: 59986 RVA: 0x008DA860 File Offset: 0x008D8A60
			' (set) Token: 0x0600EA53 RID: 59987 RVA: 0x00066A73 File Offset: 0x00064C73
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TxblAmt As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.TxblAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TxblAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.TxblAmtColumn) = value
				End Set
			End Property

			' Token: 0x17005A17 RID: 23063
			' (get) Token: 0x0600EA54 RID: 59988 RVA: 0x008DA8B0 File Offset: 0x008D8AB0
			' (set) Token: 0x0600EA55 RID: 59989 RVA: 0x00066A89 File Offset: 0x00064C89
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGSTAmt As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CGSTAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGSTAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CGSTAmtColumn) = value
				End Set
			End Property

			' Token: 0x17005A18 RID: 23064
			' (get) Token: 0x0600EA56 RID: 59990 RVA: 0x008DA900 File Offset: 0x008D8B00
			' (set) Token: 0x0600EA57 RID: 59991 RVA: 0x00066A9F File Offset: 0x00064C9F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGSTAmt As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.SGSTAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGSTAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.SGSTAmtColumn) = value
				End Set
			End Property

			' Token: 0x17005A19 RID: 23065
			' (get) Token: 0x0600EA58 RID: 59992 RVA: 0x008DA950 File Offset: 0x008D8B50
			' (set) Token: 0x0600EA59 RID: 59993 RVA: 0x00066AB5 File Offset: 0x00064CB5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGSTAmt As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.IGSTAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGSTAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.IGSTAmtColumn) = value
				End Set
			End Property

			' Token: 0x17005A1A RID: 23066
			' (get) Token: 0x0600EA5A RID: 59994 RVA: 0x008DA9A0 File Offset: 0x008D8BA0
			' (set) Token: 0x0600EA5B RID: 59995 RVA: 0x00066ACB File Offset: 0x00064CCB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESSAmt As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CESSAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESSAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CESSAmtColumn) = value
				End Set
			End Property

			' Token: 0x17005A1B RID: 23067
			' (get) Token: 0x0600EA5C RID: 59996 RVA: 0x008DA9F0 File Offset: 0x008D8BF0
			' (set) Token: 0x0600EA5D RID: 59997 RVA: 0x00066AE1 File Offset: 0x00064CE1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property OtherAmt As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.OtherAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'OtherAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.OtherAmtColumn) = value
				End Set
			End Property

			' Token: 0x0600EA5E RID: 59998 RVA: 0x008DAA40 File Offset: 0x008D8C40
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBillNoNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.BillNoColumn)
			End Function

			' Token: 0x0600EA5F RID: 59999 RVA: 0x00066AF7 File Offset: 0x00064CF7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBillNoNull()
				MyBase.Item(Me.tableDataTable1.BillNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA60 RID: 60000 RVA: 0x008DAA64 File Offset: 0x008D8C64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function Is_DateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.DateColumn)
			End Function

			' Token: 0x0600EA61 RID: 60001 RVA: 0x00066B16 File Offset: 0x00064D16
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub Set_DateNull()
				MyBase.Item(Me.tableDataTable1.DateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA62 RID: 60002 RVA: 0x008DAA88 File Offset: 0x008D8C88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CNameColumn)
			End Function

			' Token: 0x0600EA63 RID: 60003 RVA: 0x00066B35 File Offset: 0x00064D35
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCNameNull()
				MyBase.Item(Me.tableDataTable1.CNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA64 RID: 60004 RVA: 0x008DAAAC File Offset: 0x008D8CAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGSTINNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.GSTINColumn)
			End Function

			' Token: 0x0600EA65 RID: 60005 RVA: 0x00066B54 File Offset: 0x00064D54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGSTINNull()
				MyBase.Item(Me.tableDataTable1.GSTINColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA66 RID: 60006 RVA: 0x008DAAD0 File Offset: 0x008D8CD0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBillAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.BillAmtColumn)
			End Function

			' Token: 0x0600EA67 RID: 60007 RVA: 0x00066B73 File Offset: 0x00064D73
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBillAmtNull()
				MyBase.Item(Me.tableDataTable1.BillAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA68 RID: 60008 RVA: 0x008DAAF4 File Offset: 0x008D8CF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTxblAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.TxblAmtColumn)
			End Function

			' Token: 0x0600EA69 RID: 60009 RVA: 0x00066B92 File Offset: 0x00064D92
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTxblAmtNull()
				MyBase.Item(Me.tableDataTable1.TxblAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA6A RID: 60010 RVA: 0x008DAB18 File Offset: 0x008D8D18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CGSTAmtColumn)
			End Function

			' Token: 0x0600EA6B RID: 60011 RVA: 0x00066BB1 File Offset: 0x00064DB1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTAmtNull()
				MyBase.Item(Me.tableDataTable1.CGSTAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA6C RID: 60012 RVA: 0x008DAB3C File Offset: 0x008D8D3C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.SGSTAmtColumn)
			End Function

			' Token: 0x0600EA6D RID: 60013 RVA: 0x00066BD0 File Offset: 0x00064DD0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTAmtNull()
				MyBase.Item(Me.tableDataTable1.SGSTAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA6E RID: 60014 RVA: 0x008DAB60 File Offset: 0x008D8D60
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.IGSTAmtColumn)
			End Function

			' Token: 0x0600EA6F RID: 60015 RVA: 0x00066BEF File Offset: 0x00064DEF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTAmtNull()
				MyBase.Item(Me.tableDataTable1.IGSTAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA70 RID: 60016 RVA: 0x008DAB84 File Offset: 0x008D8D84
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CESSAmtColumn)
			End Function

			' Token: 0x0600EA71 RID: 60017 RVA: 0x00066C0E File Offset: 0x00064E0E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSAmtNull()
				MyBase.Item(Me.tableDataTable1.CESSAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EA72 RID: 60018 RVA: 0x008DABA8 File Offset: 0x008D8DA8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsOtherAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.OtherAmtColumn)
			End Function

			' Token: 0x0600EA73 RID: 60019 RVA: 0x00066C2D File Offset: 0x00064E2D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetOtherAmtNull()
				MyBase.Item(Me.tableDataTable1.OtherAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040059BC RID: 22972
			Private tableDataTable1 As DataSetGSTSale.DataTable1DataTable
		End Class

		' Token: 0x02000493 RID: 1171
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600EA74 RID: 60020 RVA: 0x00066C4C File Offset: 0x00064E4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetGSTSale.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17005A1C RID: 23068
			' (get) Token: 0x0600EA75 RID: 60021 RVA: 0x008DABCC File Offset: 0x008D8DCC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetGSTSale.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17005A1D RID: 23069
			' (get) Token: 0x0600EA76 RID: 60022 RVA: 0x008DABE4 File Offset: 0x008D8DE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040059BD RID: 22973
			Private eventRow As DataSetGSTSale.DataTable1Row

			' Token: 0x040059BE RID: 22974
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
