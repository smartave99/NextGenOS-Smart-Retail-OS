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
	' Token: 0x02000043 RID: 67
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("NewDataSet")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class NewDataSet
		Inherits DataSet

		' Token: 0x06000BF0 RID: 3056 RVA: 0x000ACC0C File Offset: 0x000AAE0C
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

		' Token: 0x06000BF1 RID: 3057 RVA: 0x000ACC64 File Offset: 0x000AAE64
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
					Dim flag3 As Boolean = dataSet.Tables("Table1") IsNot Nothing
					If flag3 Then
						MyBase.Tables.Add(New NewDataSet.Table1DataTable(dataSet.Tables("Table1")))
					End If
					Dim flag4 As Boolean = dataSet.Tables("MeargeData") IsNot Nothing
					If flag4 Then
						MyBase.Tables.Add(New NewDataSet.MeargeDataDataTable(dataSet.Tables("MeargeData")))
					End If
					Dim flag5 As Boolean = dataSet.Tables("Company") IsNot Nothing
					If flag5 Then
						MyBase.Tables.Add(New NewDataSet.CompanyDataTable(dataSet.Tables("Company")))
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

		' Token: 0x17000510 RID: 1296
		' (get) Token: 0x06000BF2 RID: 3058 RVA: 0x000ACE74 File Offset: 0x000AB074
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property Table1 As NewDataSet.Table1DataTable
			Get
				Return Me.tableTable1
			End Get
		End Property

		' Token: 0x17000511 RID: 1297
		' (get) Token: 0x06000BF3 RID: 3059 RVA: 0x000ACE8C File Offset: 0x000AB08C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property MeargeData As NewDataSet.MeargeDataDataTable
			Get
				Return Me.tableMeargeData
			End Get
		End Property

		' Token: 0x17000512 RID: 1298
		' (get) Token: 0x06000BF4 RID: 3060 RVA: 0x000ACEA4 File Offset: 0x000AB0A4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property Company As NewDataSet.CompanyDataTable
			Get
				Return Me.tableCompany
			End Get
		End Property

		' Token: 0x17000513 RID: 1299
		' (get) Token: 0x06000BF5 RID: 3061 RVA: 0x000ACEBC File Offset: 0x000AB0BC
		' (set) Token: 0x06000BF6 RID: 3062 RVA: 0x0000C58A File Offset: 0x0000A78A
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

		' Token: 0x17000514 RID: 1300
		' (get) Token: 0x06000BF7 RID: 3063 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x17000515 RID: 1301
		' (get) Token: 0x06000BF8 RID: 3064 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x06000BF9 RID: 3065 RVA: 0x0000C594 File Offset: 0x0000A794
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x06000BFA RID: 3066 RVA: 0x000ACED4 File Offset: 0x000AB0D4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim newDataSet As NewDataSet = CType(MyBase.Clone(), NewDataSet)
			newDataSet.InitVars()
			newDataSet.SchemaSerializationMode = Me.SchemaSerializationMode
			Return newDataSet
		End Function

		' Token: 0x06000BFB RID: 3067 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x06000BFC RID: 3068 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x06000BFD RID: 3069 RVA: 0x000ACF08 File Offset: 0x000AB108
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub ReadXmlSerializable(reader As XmlReader)
			Dim flag As Boolean = MyBase.DetermineSchemaSerializationMode(reader) = SchemaSerializationMode.IncludeSchema
			If flag Then
				Me.Reset()
				Dim dataSet As DataSet = New DataSet()
				dataSet.ReadXml(reader)
				Dim flag2 As Boolean = dataSet.Tables("Table1") IsNot Nothing
				If flag2 Then
					MyBase.Tables.Add(New NewDataSet.Table1DataTable(dataSet.Tables("Table1")))
				End If
				Dim flag3 As Boolean = dataSet.Tables("MeargeData") IsNot Nothing
				If flag3 Then
					MyBase.Tables.Add(New NewDataSet.MeargeDataDataTable(dataSet.Tables("MeargeData")))
				End If
				Dim flag4 As Boolean = dataSet.Tables("Company") IsNot Nothing
				If flag4 Then
					MyBase.Tables.Add(New NewDataSet.CompanyDataTable(dataSet.Tables("Company")))
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

		' Token: 0x06000BFE RID: 3070 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x06000BFF RID: 3071 RVA: 0x0000C5AC File Offset: 0x0000A7AC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x06000C00 RID: 3072 RVA: 0x000AD060 File Offset: 0x000AB260
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableTable1 = CType(MyBase.Tables("Table1"), NewDataSet.Table1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableTable1 IsNot Nothing
				If flag Then
					Me.tableTable1.InitVars()
				End If
			End If
			Me.tableMeargeData = CType(MyBase.Tables("MeargeData"), NewDataSet.MeargeDataDataTable)
			If initTable Then
				Dim flag2 As Boolean = Me.tableMeargeData IsNot Nothing
				If flag2 Then
					Me.tableMeargeData.InitVars()
				End If
			End If
			Me.tableCompany = CType(MyBase.Tables("Company"), NewDataSet.CompanyDataTable)
			If initTable Then
				Dim flag3 As Boolean = Me.tableCompany IsNot Nothing
				If flag3 Then
					Me.tableCompany.InitVars()
				End If
			End If
		End Sub

		' Token: 0x06000C01 RID: 3073 RVA: 0x000AD12C File Offset: 0x000AB32C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "NewDataSet"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/NewDataSet.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableTable1 = New NewDataSet.Table1DataTable()
			MyBase.Tables.Add(Me.tableTable1)
			Me.tableMeargeData = New NewDataSet.MeargeDataDataTable()
			MyBase.Tables.Add(Me.tableMeargeData)
			Me.tableCompany = New NewDataSet.CompanyDataTable()
			MyBase.Tables.Add(Me.tableCompany)
		End Sub

		' Token: 0x06000C02 RID: 3074 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeTable1() As Boolean
			Return False
		End Function

		' Token: 0x06000C03 RID: 3075 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeMeargeData() As Boolean
			Return False
		End Function

		' Token: 0x06000C04 RID: 3076 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeCompany() As Boolean
			Return False
		End Function

		' Token: 0x06000C05 RID: 3077 RVA: 0x000AD1C8 File Offset: 0x000AB3C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x06000C06 RID: 3078 RVA: 0x000AD1EC File Offset: 0x000AB3EC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim newDataSet As NewDataSet = New NewDataSet()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = newDataSet.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = newDataSet.GetSchemaSerializable()
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

		' Token: 0x040003B3 RID: 947
		Private tableTable1 As NewDataSet.Table1DataTable

		' Token: 0x040003B4 RID: 948
		Private tableMeargeData As NewDataSet.MeargeDataDataTable

		' Token: 0x040003B5 RID: 949
		Private tableCompany As NewDataSet.CompanyDataTable

		' Token: 0x040003B6 RID: 950
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x02000044 RID: 68
		' (Invoke) Token: 0x06000C0A RID: 3082
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub Table1RowChangeEventHandler(sender As Object, e As NewDataSet.Table1RowChangeEvent)

		' Token: 0x02000045 RID: 69
		' (Invoke) Token: 0x06000C0E RID: 3086
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub MeargeDataRowChangeEventHandler(sender As Object, e As NewDataSet.MeargeDataRowChangeEvent)

		' Token: 0x02000046 RID: 70
		' (Invoke) Token: 0x06000C12 RID: 3090
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub CompanyRowChangeEventHandler(sender As Object, e As NewDataSet.CompanyRowChangeEvent)

		' Token: 0x02000047 RID: 71
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class Table1DataTable
			Inherits TypedTableBase(Of NewDataSet.Table1Row)

			' Token: 0x06000C13 RID: 3091 RVA: 0x0000C5B7 File Offset: 0x0000A7B7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "Table1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x06000C14 RID: 3092 RVA: 0x000AD380 File Offset: 0x000AB580
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

			' Token: 0x06000C15 RID: 3093 RVA: 0x0000C5E2 File Offset: 0x0000A7E2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17000516 RID: 1302
			' (get) Token: 0x06000C16 RID: 3094 RVA: 0x000AD44C File Offset: 0x000AB64C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property YearColumn As DataColumn
				Get
					Return Me.columnYear
				End Get
			End Property

			' Token: 0x17000517 RID: 1303
			' (get) Token: 0x06000C17 RID: 3095 RVA: 0x000AD464 File Offset: 0x000AB664
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GrandTotalColumn As DataColumn
				Get
					Return Me.columnGrandTotal
				End Get
			End Property

			' Token: 0x17000518 RID: 1304
			' (get) Token: 0x06000C18 RID: 3096 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17000519 RID: 1305
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As NewDataSet.Table1Row
				Get
					Return CType(MyBase.Rows(index), NewDataSet.Table1Row)
				End Get
			End Property

			' Token: 0x14000021 RID: 33
			' (add) Token: 0x06000C1A RID: 3098 RVA: 0x000AD4A0 File Offset: 0x000AB6A0
			' (remove) Token: 0x06000C1B RID: 3099 RVA: 0x000AD4D8 File Offset: 0x000AB6D8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event Table1RowChanging As NewDataSet.Table1RowChangeEventHandler

			' Token: 0x14000022 RID: 34
			' (add) Token: 0x06000C1C RID: 3100 RVA: 0x000AD510 File Offset: 0x000AB710
			' (remove) Token: 0x06000C1D RID: 3101 RVA: 0x000AD548 File Offset: 0x000AB748
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event Table1RowChanged As NewDataSet.Table1RowChangeEventHandler

			' Token: 0x14000023 RID: 35
			' (add) Token: 0x06000C1E RID: 3102 RVA: 0x000AD580 File Offset: 0x000AB780
			' (remove) Token: 0x06000C1F RID: 3103 RVA: 0x000AD5B8 File Offset: 0x000AB7B8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event Table1RowDeleting As NewDataSet.Table1RowChangeEventHandler

			' Token: 0x14000024 RID: 36
			' (add) Token: 0x06000C20 RID: 3104 RVA: 0x000AD5F0 File Offset: 0x000AB7F0
			' (remove) Token: 0x06000C21 RID: 3105 RVA: 0x000AD628 File Offset: 0x000AB828
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event Table1RowDeleted As NewDataSet.Table1RowChangeEventHandler

			' Token: 0x06000C22 RID: 3106 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddTable1Row(row As NewDataSet.Table1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x06000C23 RID: 3107 RVA: 0x000AD660 File Offset: 0x000AB860
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddTable1Row(Year As String, GrandTotal As Decimal) As NewDataSet.Table1Row
				Dim table1Row As NewDataSet.Table1Row = CType(MyBase.NewRow(), NewDataSet.Table1Row)
				Dim array As Object() = New Object() { Year, GrandTotal }
				table1Row.ItemArray = array
				MyBase.Rows.Add(table1Row)
				Return table1Row
			End Function

			' Token: 0x06000C24 RID: 3108 RVA: 0x000AD6A8 File Offset: 0x000AB8A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim table1DataTable As NewDataSet.Table1DataTable = CType(MyBase.Clone(), NewDataSet.Table1DataTable)
				table1DataTable.InitVars()
				Return table1DataTable
			End Function

			' Token: 0x06000C25 RID: 3109 RVA: 0x000AD6D0 File Offset: 0x000AB8D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New NewDataSet.Table1DataTable()
			End Function

			' Token: 0x06000C26 RID: 3110 RVA: 0x0000C5F5 File Offset: 0x0000A7F5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnYear = MyBase.Columns("Year")
				Me.columnGrandTotal = MyBase.Columns("GrandTotal")
			End Sub

			' Token: 0x06000C27 RID: 3111 RVA: 0x000AD6E8 File Offset: 0x000AB8E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnYear = New DataColumn("Year", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnYear)
				Me.columnGrandTotal = New DataColumn("GrandTotal", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGrandTotal)
			End Sub

			' Token: 0x06000C28 RID: 3112 RVA: 0x000AD754 File Offset: 0x000AB954
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewTable1Row() As NewDataSet.Table1Row
				Return CType(MyBase.NewRow(), NewDataSet.Table1Row)
			End Function

			' Token: 0x06000C29 RID: 3113 RVA: 0x000AD774 File Offset: 0x000AB974
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New NewDataSet.Table1Row(builder)
			End Function

			' Token: 0x06000C2A RID: 3114 RVA: 0x000AD78C File Offset: 0x000AB98C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(NewDataSet.Table1Row)
			End Function

			' Token: 0x06000C2B RID: 3115 RVA: 0x000AD7A8 File Offset: 0x000AB9A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.Table1RowChangedEvent IsNot Nothing
				If flag Then
					Dim table1RowChangedEvent As NewDataSet.Table1RowChangeEventHandler = Me.Table1RowChangedEvent
					If table1RowChangedEvent IsNot Nothing Then
						table1RowChangedEvent(Me, New NewDataSet.Table1RowChangeEvent(CType(e.Row, NewDataSet.Table1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000C2C RID: 3116 RVA: 0x000AD7F8 File Offset: 0x000AB9F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.Table1RowChangingEvent IsNot Nothing
				If flag Then
					Dim table1RowChangingEvent As NewDataSet.Table1RowChangeEventHandler = Me.Table1RowChangingEvent
					If table1RowChangingEvent IsNot Nothing Then
						table1RowChangingEvent(Me, New NewDataSet.Table1RowChangeEvent(CType(e.Row, NewDataSet.Table1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000C2D RID: 3117 RVA: 0x000AD848 File Offset: 0x000ABA48
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.Table1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim table1RowDeletedEvent As NewDataSet.Table1RowChangeEventHandler = Me.Table1RowDeletedEvent
					If table1RowDeletedEvent IsNot Nothing Then
						table1RowDeletedEvent(Me, New NewDataSet.Table1RowChangeEvent(CType(e.Row, NewDataSet.Table1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000C2E RID: 3118 RVA: 0x000AD898 File Offset: 0x000ABA98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.Table1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim table1RowDeletingEvent As NewDataSet.Table1RowChangeEventHandler = Me.Table1RowDeletingEvent
					If table1RowDeletingEvent IsNot Nothing Then
						table1RowDeletingEvent(Me, New NewDataSet.Table1RowChangeEvent(CType(e.Row, NewDataSet.Table1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000C2F RID: 3119 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveTable1Row(row As NewDataSet.Table1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x06000C30 RID: 3120 RVA: 0x000AD8E8 File Offset: 0x000ABAE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim newDataSet As NewDataSet = New NewDataSet()
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
				xmlSchemaAttribute.FixedValue = newDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "Table1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = newDataSet.GetSchemaSerializable()
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

			' Token: 0x040003B7 RID: 951
			Private columnYear As DataColumn

			' Token: 0x040003B8 RID: 952
			Private columnGrandTotal As DataColumn
		End Class

		' Token: 0x02000048 RID: 72
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class MeargeDataDataTable
			Inherits TypedTableBase(Of NewDataSet.MeargeDataRow)

			' Token: 0x06000C31 RID: 3121 RVA: 0x0000C624 File Offset: 0x0000A824
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "MeargeData"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x06000C32 RID: 3122 RVA: 0x000ADB3C File Offset: 0x000ABD3C
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

			' Token: 0x06000C33 RID: 3123 RVA: 0x0000C64F File Offset: 0x0000A84F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x1700051A RID: 1306
			' (get) Token: 0x06000C34 RID: 3124 RVA: 0x000ADC08 File Offset: 0x000ABE08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ByCashColumn As DataColumn
				Get
					Return Me.columnByCash
				End Get
			End Property

			' Token: 0x1700051B RID: 1307
			' (get) Token: 0x06000C35 RID: 3125 RVA: 0x000ADC20 File Offset: 0x000ABE20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ByReturnColumn As DataColumn
				Get
					Return Me.columnByReturn
				End Get
			End Property

			' Token: 0x1700051C RID: 1308
			' (get) Token: 0x06000C36 RID: 3126 RVA: 0x000ADC38 File Offset: 0x000ABE38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ByCredit_DebitCardColumn As DataColumn
				Get
					Return Me.columnByCredit_DebitCard
				End Get
			End Property

			' Token: 0x1700051D RID: 1309
			' (get) Token: 0x06000C37 RID: 3127 RVA: 0x000ADC50 File Offset: 0x000ABE50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PaymentModeColumn As DataColumn
				Get
					Return Me.columnPaymentMode
				End Get
			End Property

			' Token: 0x1700051E RID: 1310
			' (get) Token: 0x06000C38 RID: 3128 RVA: 0x000ADC68 File Offset: 0x000ABE68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property OperatorColumn As DataColumn
				Get
					Return Me.columnOperator
				End Get
			End Property

			' Token: 0x1700051F RID: 1311
			' (get) Token: 0x06000C39 RID: 3129 RVA: 0x000ADC80 File Offset: 0x000ABE80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Inv_IDColumn As DataColumn
				Get
					Return Me.columnInv_ID
				End Get
			End Property

			' Token: 0x17000520 RID: 1312
			' (get) Token: 0x06000C3A RID: 3130 RVA: 0x000ADC98 File Offset: 0x000ABE98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property InvoiceNoColumn As DataColumn
				Get
					Return Me.columnInvoiceNo
				End Get
			End Property

			' Token: 0x17000521 RID: 1313
			' (get) Token: 0x06000C3B RID: 3131 RVA: 0x000ADCB0 File Offset: 0x000ABEB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property InvoiceDateColumn As DataColumn
				Get
					Return Me.columnInvoiceDate
				End Get
			End Property

			' Token: 0x17000522 RID: 1314
			' (get) Token: 0x06000C3C RID: 3132 RVA: 0x000ADCC8 File Offset: 0x000ABEC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TaxTypeColumn As DataColumn
				Get
					Return Me.columnTaxType
				End Get
			End Property

			' Token: 0x17000523 RID: 1315
			' (get) Token: 0x06000C3D RID: 3133 RVA: 0x000ADCE0 File Offset: 0x000ABEE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Customer_IDColumn As DataColumn
				Get
					Return Me.columnCustomer_ID
				End Get
			End Property

			' Token: 0x17000524 RID: 1316
			' (get) Token: 0x06000C3E RID: 3134 RVA: 0x000ADCF8 File Offset: 0x000ABEF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalesmanIDColumn As DataColumn
				Get
					Return Me.columnSalesmanID
				End Get
			End Property

			' Token: 0x17000525 RID: 1317
			' (get) Token: 0x06000C3F RID: 3135 RVA: 0x000ADD10 File Offset: 0x000ABF10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SubTotalColumn As DataColumn
				Get
					Return Me.columnSubTotal
				End Get
			End Property

			' Token: 0x17000526 RID: 1318
			' (get) Token: 0x06000C40 RID: 3136 RVA: 0x000ADD28 File Offset: 0x000ABF28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTColumn As DataColumn
				Get
					Return Me.columnCGST
				End Get
			End Property

			' Token: 0x17000527 RID: 1319
			' (get) Token: 0x06000C41 RID: 3137 RVA: 0x000ADD40 File Offset: 0x000ABF40
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTColumn As DataColumn
				Get
					Return Me.columnSGST
				End Get
			End Property

			' Token: 0x17000528 RID: 1320
			' (get) Token: 0x06000C42 RID: 3138 RVA: 0x000ADD58 File Offset: 0x000ABF58
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTColumn As DataColumn
				Get
					Return Me.columnIGST
				End Get
			End Property

			' Token: 0x17000529 RID: 1321
			' (get) Token: 0x06000C43 RID: 3139 RVA: 0x000ADD70 File Offset: 0x000ABF70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSColumn As DataColumn
				Get
					Return Me.columnCESS
				End Get
			End Property

			' Token: 0x1700052A RID: 1322
			' (get) Token: 0x06000C44 RID: 3140 RVA: 0x000ADD88 File Offset: 0x000ABF88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GrandTotalColumn As DataColumn
				Get
					Return Me.columnGrandTotal
				End Get
			End Property

			' Token: 0x1700052B RID: 1323
			' (get) Token: 0x06000C45 RID: 3141 RVA: 0x000ADDA0 File Offset: 0x000ABFA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TotalPaidColumn As DataColumn
				Get
					Return Me.columnTotalPaid
				End Get
			End Property

			' Token: 0x1700052C RID: 1324
			' (get) Token: 0x06000C46 RID: 3142 RVA: 0x000ADDB8 File Offset: 0x000ABFB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BalanceColumn As DataColumn
				Get
					Return Me.columnBalance
				End Get
			End Property

			' Token: 0x1700052D RID: 1325
			' (get) Token: 0x06000C47 RID: 3143 RVA: 0x000ADDD0 File Offset: 0x000ABFD0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property FreightChargesColumn As DataColumn
				Get
					Return Me.columnFreightCharges
				End Get
			End Property

			' Token: 0x1700052E RID: 1326
			' (get) Token: 0x06000C48 RID: 3144 RVA: 0x000ADDE8 File Offset: 0x000ABFE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property OtherChargesColumn As DataColumn
				Get
					Return Me.columnOtherCharges
				End Get
			End Property

			' Token: 0x1700052F RID: 1327
			' (get) Token: 0x06000C49 RID: 3145 RVA: 0x000ADE00 File Offset: 0x000AC000
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TotalColumn As DataColumn
				Get
					Return Me.columnTotal
				End Get
			End Property

			' Token: 0x17000530 RID: 1328
			' (get) Token: 0x06000C4A RID: 3146 RVA: 0x000ADE18 File Offset: 0x000AC018
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RoundOffColumn As DataColumn
				Get
					Return Me.columnRoundOff
				End Get
			End Property

			' Token: 0x17000531 RID: 1329
			' (get) Token: 0x06000C4B RID: 3147 RVA: 0x000ADE30 File Offset: 0x000AC030
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RemarksColumn As DataColumn
				Get
					Return Me.columnRemarks
				End Get
			End Property

			' Token: 0x17000532 RID: 1330
			' (get) Token: 0x06000C4C RID: 3148 RVA: 0x000ADE48 File Offset: 0x000AC048
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IPo_IDColumn As DataColumn
				Get
					Return Me.columnIPo_ID
				End Get
			End Property

			' Token: 0x17000533 RID: 1331
			' (get) Token: 0x06000C4D RID: 3149 RVA: 0x000ADE60 File Offset: 0x000AC060
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property InvoiceIDColumn As DataColumn
				Get
					Return Me.columnInvoiceID
				End Get
			End Property

			' Token: 0x17000534 RID: 1332
			' (get) Token: 0x06000C4E RID: 3150 RVA: 0x000ADE78 File Offset: 0x000AC078
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductIDColumn As DataColumn
				Get
					Return Me.columnProductID
				End Get
			End Property

			' Token: 0x17000535 RID: 1333
			' (get) Token: 0x06000C4F RID: 3151 RVA: 0x000ADE90 File Offset: 0x000AC090
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x17000536 RID: 1334
			' (get) Token: 0x06000C50 RID: 3152 RVA: 0x000ADEA8 File Offset: 0x000AC0A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalesRateColumn As DataColumn
				Get
					Return Me.columnSalesRate
				End Get
			End Property

			' Token: 0x17000537 RID: 1335
			' (get) Token: 0x06000C51 RID: 3153 RVA: 0x000ADEC0 File Offset: 0x000AC0C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QtyColumn As DataColumn
				Get
					Return Me.columnQty
				End Get
			End Property

			' Token: 0x17000538 RID: 1336
			' (get) Token: 0x06000C52 RID: 3154 RVA: 0x000ADED8 File Offset: 0x000AC0D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountPerColumn As DataColumn
				Get
					Return Me.columnDiscountPer
				End Get
			End Property

			' Token: 0x17000539 RID: 1337
			' (get) Token: 0x06000C53 RID: 3155 RVA: 0x000ADEF0 File Offset: 0x000AC0F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountColumn As DataColumn
				Get
					Return Me.columnDiscount
				End Get
			End Property

			' Token: 0x1700053A RID: 1338
			' (get) Token: 0x06000C54 RID: 3156 RVA: 0x000ADF08 File Offset: 0x000AC108
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTPerColumn As DataColumn
				Get
					Return Me.columnCGSTPer
				End Get
			End Property

			' Token: 0x1700053B RID: 1339
			' (get) Token: 0x06000C55 RID: 3157 RVA: 0x000ADF20 File Offset: 0x000AC120
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTAmtColumn As DataColumn
				Get
					Return Me.columnCGSTAmt
				End Get
			End Property

			' Token: 0x1700053C RID: 1340
			' (get) Token: 0x06000C56 RID: 3158 RVA: 0x000ADF38 File Offset: 0x000AC138
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTPerColumn As DataColumn
				Get
					Return Me.columnSGSTPer
				End Get
			End Property

			' Token: 0x1700053D RID: 1341
			' (get) Token: 0x06000C57 RID: 3159 RVA: 0x000ADF50 File Offset: 0x000AC150
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTAmtColumn As DataColumn
				Get
					Return Me.columnSGSTAmt
				End Get
			End Property

			' Token: 0x1700053E RID: 1342
			' (get) Token: 0x06000C58 RID: 3160 RVA: 0x000ADF68 File Offset: 0x000AC168
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTPerColumn As DataColumn
				Get
					Return Me.columnIGSTPer
				End Get
			End Property

			' Token: 0x1700053F RID: 1343
			' (get) Token: 0x06000C59 RID: 3161 RVA: 0x000ADF80 File Offset: 0x000AC180
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTAmtColumn As DataColumn
				Get
					Return Me.columnIGSTAmt
				End Get
			End Property

			' Token: 0x17000540 RID: 1344
			' (get) Token: 0x06000C5A RID: 3162 RVA: 0x000ADF98 File Offset: 0x000AC198
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSPerColumn As DataColumn
				Get
					Return Me.columnCESSPer
				End Get
			End Property

			' Token: 0x17000541 RID: 1345
			' (get) Token: 0x06000C5B RID: 3163 RVA: 0x000ADFB0 File Offset: 0x000AC1B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSAmtColumn As DataColumn
				Get
					Return Me.columnCESSAmt
				End Get
			End Property

			' Token: 0x17000542 RID: 1346
			' (get) Token: 0x06000C5C RID: 3164 RVA: 0x000ADFC8 File Offset: 0x000AC1C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TotalAmountColumn As DataColumn
				Get
					Return Me.columnTotalAmount
				End Get
			End Property

			' Token: 0x17000543 RID: 1347
			' (get) Token: 0x06000C5D RID: 3165 RVA: 0x000ADFE0 File Offset: 0x000AC1E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PurchaseRateColumn As DataColumn
				Get
					Return Me.columnPurchaseRate
				End Get
			End Property

			' Token: 0x17000544 RID: 1348
			' (get) Token: 0x06000C5E RID: 3166 RVA: 0x000ADFF8 File Offset: 0x000AC1F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MarginColumn As DataColumn
				Get
					Return Me.columnMargin
				End Get
			End Property

			' Token: 0x17000545 RID: 1349
			' (get) Token: 0x06000C5F RID: 3167 RVA: 0x000AE010 File Offset: 0x000AC210
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PIDColumn As DataColumn
				Get
					Return Me.columnPID
				End Get
			End Property

			' Token: 0x17000546 RID: 1350
			' (get) Token: 0x06000C60 RID: 3168 RVA: 0x000AE028 File Offset: 0x000AC228
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductCodeColumn As DataColumn
				Get
					Return Me.columnProductCode
				End Get
			End Property

			' Token: 0x17000547 RID: 1351
			' (get) Token: 0x06000C61 RID: 3169 RVA: 0x000AE040 File Offset: 0x000AC240
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductNameColumn As DataColumn
				Get
					Return Me.columnProductName
				End Get
			End Property

			' Token: 0x17000548 RID: 1352
			' (get) Token: 0x06000C62 RID: 3170 RVA: 0x000AE058 File Offset: 0x000AC258
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SubCategoryIDColumn As DataColumn
				Get
					Return Me.columnSubCategoryID
				End Get
			End Property

			' Token: 0x17000549 RID: 1353
			' (get) Token: 0x06000C63 RID: 3171 RVA: 0x000AE070 File Offset: 0x000AC270
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCodeColumn As DataColumn
				Get
					Return Me.columnHSNCode
				End Get
			End Property

			' Token: 0x1700054A RID: 1354
			' (get) Token: 0x06000C64 RID: 3172 RVA: 0x000AE088 File Offset: 0x000AC288
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PartNoColumn As DataColumn
				Get
					Return Me.columnPartNo
				End Get
			End Property

			' Token: 0x1700054B RID: 1355
			' (get) Token: 0x06000C65 RID: 3173 RVA: 0x000AE0A0 File Offset: 0x000AC2A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DescriptionColumn As DataColumn
				Get
					Return Me.columnDescription
				End Get
			End Property

			' Token: 0x1700054C RID: 1356
			' (get) Token: 0x06000C66 RID: 3174 RVA: 0x000AE0B8 File Offset: 0x000AC2B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CostPriceColumn As DataColumn
				Get
					Return Me.columnCostPrice
				End Get
			End Property

			' Token: 0x1700054D RID: 1357
			' (get) Token: 0x06000C67 RID: 3175 RVA: 0x000AE0D0 File Offset: 0x000AC2D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SellingPriceColumn As DataColumn
				Get
					Return Me.columnSellingPrice
				End Get
			End Property

			' Token: 0x1700054E RID: 1358
			' (get) Token: 0x06000C68 RID: 3176 RVA: 0x000AE0E8 File Offset: 0x000AC2E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountPColumn As DataColumn
				Get
					Return Me.columnDiscountP
				End Get
			End Property

			' Token: 0x1700054F RID: 1359
			' (get) Token: 0x06000C69 RID: 3177 RVA: 0x000AE100 File Offset: 0x000AC300
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTPColumn As DataColumn
				Get
					Return Me.columnCGSTP
				End Get
			End Property

			' Token: 0x17000550 RID: 1360
			' (get) Token: 0x06000C6A RID: 3178 RVA: 0x000AE118 File Offset: 0x000AC318
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTPColumn As DataColumn
				Get
					Return Me.columnSGSTP
				End Get
			End Property

			' Token: 0x17000551 RID: 1361
			' (get) Token: 0x06000C6B RID: 3179 RVA: 0x000AE130 File Offset: 0x000AC330
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSPColumn As DataColumn
				Get
					Return Me.columnCESSP
				End Get
			End Property

			' Token: 0x17000552 RID: 1362
			' (get) Token: 0x06000C6C RID: 3180 RVA: 0x000AE148 File Offset: 0x000AC348
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodePColumn As DataColumn
				Get
					Return Me.columnBarcodeP
				End Get
			End Property

			' Token: 0x17000553 RID: 1363
			' (get) Token: 0x06000C6D RID: 3181 RVA: 0x000AE160 File Offset: 0x000AC360
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ReorderPointColumn As DataColumn
				Get
					Return Me.columnReorderPoint
				End Get
			End Property

			' Token: 0x17000554 RID: 1364
			' (get) Token: 0x06000C6E RID: 3182 RVA: 0x000AE178 File Offset: 0x000AC378
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property OpeningStockColumn As DataColumn
				Get
					Return Me.columnOpeningStock
				End Get
			End Property

			' Token: 0x17000555 RID: 1365
			' (get) Token: 0x06000C6F RID: 3183 RVA: 0x000AE190 File Offset: 0x000AC390
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PurchaseUnitColumn As DataColumn
				Get
					Return Me.columnPurchaseUnit
				End Get
			End Property

			' Token: 0x17000556 RID: 1366
			' (get) Token: 0x06000C70 RID: 3184 RVA: 0x000AE1A8 File Offset: 0x000AC3A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalesUnitColumn As DataColumn
				Get
					Return Me.columnSalesUnit
				End Get
			End Property

			' Token: 0x17000557 RID: 1367
			' (get) Token: 0x06000C71 RID: 3185 RVA: 0x000AE1C0 File Offset: 0x000AC3C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IDColumn As DataColumn
				Get
					Return Me.columnID
				End Get
			End Property

			' Token: 0x17000558 RID: 1368
			' (get) Token: 0x06000C72 RID: 3186 RVA: 0x000AE1D8 File Offset: 0x000AC3D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CustomerIDColumn As DataColumn
				Get
					Return Me.columnCustomerID
				End Get
			End Property

			' Token: 0x17000559 RID: 1369
			' (get) Token: 0x06000C73 RID: 3187 RVA: 0x000AE1F0 File Offset: 0x000AC3F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property NameColumn As DataColumn
				Get
					Return Me.columnName
				End Get
			End Property

			' Token: 0x1700055A RID: 1370
			' (get) Token: 0x06000C74 RID: 3188 RVA: 0x000AE208 File Offset: 0x000AC408
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AddressColumn As DataColumn
				Get
					Return Me.columnAddress
				End Get
			End Property

			' Token: 0x1700055B RID: 1371
			' (get) Token: 0x06000C75 RID: 3189 RVA: 0x000AE220 File Offset: 0x000AC420
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GSTINColumn As DataColumn
				Get
					Return Me.columnGSTIN
				End Get
			End Property

			' Token: 0x1700055C RID: 1372
			' (get) Token: 0x06000C76 RID: 3190 RVA: 0x000AE238 File Offset: 0x000AC438
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property StateColumn As DataColumn
				Get
					Return Me.columnState
				End Get
			End Property

			' Token: 0x1700055D RID: 1373
			' (get) Token: 0x06000C77 RID: 3191 RVA: 0x000AE250 File Offset: 0x000AC450
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ZipCodeColumn As DataColumn
				Get
					Return Me.columnZipCode
				End Get
			End Property

			' Token: 0x1700055E RID: 1374
			' (get) Token: 0x06000C78 RID: 3192 RVA: 0x000AE268 File Offset: 0x000AC468
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ContactNoColumn As DataColumn
				Get
					Return Me.columnContactNo
				End Get
			End Property

			' Token: 0x1700055F RID: 1375
			' (get) Token: 0x06000C79 RID: 3193 RVA: 0x000AE280 File Offset: 0x000AC480
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property EmailIDColumn As DataColumn
				Get
					Return Me.columnEmailID
				End Get
			End Property

			' Token: 0x17000560 RID: 1376
			' (get) Token: 0x06000C7A RID: 3194 RVA: 0x000AE298 File Offset: 0x000AC498
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RemarksCColumn As DataColumn
				Get
					Return Me.columnRemarksC
				End Get
			End Property

			' Token: 0x17000561 RID: 1377
			' (get) Token: 0x06000C7B RID: 3195 RVA: 0x000AE2B0 File Offset: 0x000AC4B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AccountNumberColumn As DataColumn
				Get
					Return Me.columnAccountNumber
				End Get
			End Property

			' Token: 0x17000562 RID: 1378
			' (get) Token: 0x06000C7C RID: 3196 RVA: 0x000AE2C8 File Offset: 0x000AC4C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AccountNameColumn As DataColumn
				Get
					Return Me.columnAccountName
				End Get
			End Property

			' Token: 0x17000563 RID: 1379
			' (get) Token: 0x06000C7D RID: 3197 RVA: 0x000AE2E0 File Offset: 0x000AC4E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BankColumn As DataColumn
				Get
					Return Me.columnBank
				End Get
			End Property

			' Token: 0x17000564 RID: 1380
			' (get) Token: 0x06000C7E RID: 3198 RVA: 0x000AE2F8 File Offset: 0x000AC4F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BranchColumn As DataColumn
				Get
					Return Me.columnBranch
				End Get
			End Property

			' Token: 0x17000565 RID: 1381
			' (get) Token: 0x06000C7F RID: 3199 RVA: 0x000AE310 File Offset: 0x000AC510
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IFSCCodeColumn As DataColumn
				Get
					Return Me.columnIFSCCode
				End Get
			End Property

			' Token: 0x17000566 RID: 1382
			' (get) Token: 0x06000C80 RID: 3200 RVA: 0x000AE328 File Offset: 0x000AC528
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PANColumn As DataColumn
				Get
					Return Me.columnPAN
				End Get
			End Property

			' Token: 0x17000567 RID: 1383
			' (get) Token: 0x06000C81 RID: 3201 RVA: 0x000AE340 File Offset: 0x000AC540
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CINColumn As DataColumn
				Get
					Return Me.columnCIN
				End Get
			End Property

			' Token: 0x17000568 RID: 1384
			' (get) Token: 0x06000C82 RID: 3202 RVA: 0x000AE358 File Offset: 0x000AC558
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property WriteOffAmountColumn As DataColumn
				Get
					Return Me.columnWriteOffAmount
				End Get
			End Property

			' Token: 0x17000569 RID: 1385
			' (get) Token: 0x06000C83 RID: 3203 RVA: 0x000AE370 File Offset: 0x000AC570
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CreditBalanceColumn As DataColumn
				Get
					Return Me.columnCreditBalance
				End Get
			End Property

			' Token: 0x1700056A RID: 1386
			' (get) Token: 0x06000C84 RID: 3204 RVA: 0x000AE388 File Offset: 0x000AC588
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PaytmColumn As DataColumn
				Get
					Return Me.columnPaytm
				End Get
			End Property

			' Token: 0x1700056B RID: 1387
			' (get) Token: 0x06000C85 RID: 3205 RVA: 0x000AE3A0 File Offset: 0x000AC5A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GpayColumn As DataColumn
				Get
					Return Me.columnGpay
				End Get
			End Property

			' Token: 0x1700056C RID: 1388
			' (get) Token: 0x06000C86 RID: 3206 RVA: 0x000AE3B8 File Offset: 0x000AC5B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PhonePayColumn As DataColumn
				Get
					Return Me.columnPhonePay
				End Get
			End Property

			' Token: 0x1700056D RID: 1389
			' (get) Token: 0x06000C87 RID: 3207 RVA: 0x000AE3D0 File Offset: 0x000AC5D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property OnlineOtherPayColumn As DataColumn
				Get
					Return Me.columnOnlineOtherPay
				End Get
			End Property

			' Token: 0x1700056E RID: 1390
			' (get) Token: 0x06000C88 RID: 3208 RVA: 0x000AE3E8 File Offset: 0x000AC5E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property EMIENOColumn As DataColumn
				Get
					Return Me.columnEMIENO
				End Get
			End Property

			' Token: 0x1700056F RID: 1391
			' (get) Token: 0x06000C89 RID: 3209 RVA: 0x000AE400 File Offset: 0x000AC600
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property EMIBARCODEColumn As DataColumn
				Get
					Return Me.columnEMIBARCODE
				End Get
			End Property

			' Token: 0x17000570 RID: 1392
			' (get) Token: 0x06000C8A RID: 3210 RVA: 0x000AE418 File Offset: 0x000AC618
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property EMIPIDColumn As DataColumn
				Get
					Return Me.columnEMIPID
				End Get
			End Property

			' Token: 0x17000571 RID: 1393
			' (get) Token: 0x06000C8B RID: 3211 RVA: 0x000AE430 File Offset: 0x000AC630
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property EMIENO1Column As DataColumn
				Get
					Return Me.columnEMIENO1
				End Get
			End Property

			' Token: 0x17000572 RID: 1394
			' (get) Token: 0x06000C8C RID: 3212 RVA: 0x000AE448 File Offset: 0x000AC648
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MDateColumn As DataColumn
				Get
					Return Me.columnMDate
				End Get
			End Property

			' Token: 0x17000573 RID: 1395
			' (get) Token: 0x06000C8D RID: 3213 RVA: 0x000AE460 File Offset: 0x000AC660
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property EDateColumn As DataColumn
				Get
					Return Me.columnEDate
				End Get
			End Property

			' Token: 0x17000574 RID: 1396
			' (get) Token: 0x06000C8E RID: 3214 RVA: 0x000AE478 File Offset: 0x000AC678
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property POtherLanguageColumn As DataColumn
				Get
					Return Me.columnPOtherLanguage
				End Get
			End Property

			' Token: 0x17000575 RID: 1397
			' (get) Token: 0x06000C8F RID: 3215 RVA: 0x000AE490 File Offset: 0x000AC690
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AB1Column As DataColumn
				Get
					Return Me.columnAB1
				End Get
			End Property

			' Token: 0x17000576 RID: 1398
			' (get) Token: 0x06000C90 RID: 3216 RVA: 0x000AE4A8 File Offset: 0x000AC6A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AB2Column As DataColumn
				Get
					Return Me.columnAB2
				End Get
			End Property

			' Token: 0x17000577 RID: 1399
			' (get) Token: 0x06000C91 RID: 3217 RVA: 0x000AE4C0 File Offset: 0x000AC6C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AB3Column As DataColumn
				Get
					Return Me.columnAB3
				End Get
			End Property

			' Token: 0x17000578 RID: 1400
			' (get) Token: 0x06000C92 RID: 3218 RVA: 0x000AE4D8 File Offset: 0x000AC6D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AB4Column As DataColumn
				Get
					Return Me.columnAB4
				End Get
			End Property

			' Token: 0x17000579 RID: 1401
			' (get) Token: 0x06000C93 RID: 3219 RVA: 0x000AE4F0 File Offset: 0x000AC6F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AB5Column As DataColumn
				Get
					Return Me.columnAB5
				End Get
			End Property

			' Token: 0x1700057A RID: 1402
			' (get) Token: 0x06000C94 RID: 3220 RVA: 0x000AE508 File Offset: 0x000AC708
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AB6Column As DataColumn
				Get
					Return Me.columnAB6
				End Get
			End Property

			' Token: 0x1700057B RID: 1403
			' (get) Token: 0x06000C95 RID: 3221 RVA: 0x000AE520 File Offset: 0x000AC720
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AB7Column As DataColumn
				Get
					Return Me.columnAB7
				End Get
			End Property

			' Token: 0x1700057C RID: 1404
			' (get) Token: 0x06000C96 RID: 3222 RVA: 0x000AE538 File Offset: 0x000AC738
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AB8Column As DataColumn
				Get
					Return Me.columnAB8
				End Get
			End Property

			' Token: 0x1700057D RID: 1405
			' (get) Token: 0x06000C97 RID: 3223 RVA: 0x000AE550 File Offset: 0x000AC750
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AB9Column As DataColumn
				Get
					Return Me.columnAB9
				End Get
			End Property

			' Token: 0x1700057E RID: 1406
			' (get) Token: 0x06000C98 RID: 3224 RVA: 0x000AE568 File Offset: 0x000AC768
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property X1Column As DataColumn
				Get
					Return Me.columnX1
				End Get
			End Property

			' Token: 0x1700057F RID: 1407
			' (get) Token: 0x06000C99 RID: 3225 RVA: 0x000AE580 File Offset: 0x000AC780
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property X2Column As DataColumn
				Get
					Return Me.columnX2
				End Get
			End Property

			' Token: 0x17000580 RID: 1408
			' (get) Token: 0x06000C9A RID: 3226 RVA: 0x000AE598 File Offset: 0x000AC798
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property X3Column As DataColumn
				Get
					Return Me.columnX3
				End Get
			End Property

			' Token: 0x17000581 RID: 1409
			' (get) Token: 0x06000C9B RID: 3227 RVA: 0x000AE5B0 File Offset: 0x000AC7B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property X4Column As DataColumn
				Get
					Return Me.columnX4
				End Get
			End Property

			' Token: 0x17000582 RID: 1410
			' (get) Token: 0x06000C9C RID: 3228 RVA: 0x000AE5C8 File Offset: 0x000AC7C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property X5Column As DataColumn
				Get
					Return Me.columnX5
				End Get
			End Property

			' Token: 0x17000583 RID: 1411
			' (get) Token: 0x06000C9D RID: 3229 RVA: 0x000AE5E0 File Offset: 0x000AC7E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property X6Column As DataColumn
				Get
					Return Me.columnX6
				End Get
			End Property

			' Token: 0x17000584 RID: 1412
			' (get) Token: 0x06000C9E RID: 3230 RVA: 0x000AE5F8 File Offset: 0x000AC7F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property X7Column As DataColumn
				Get
					Return Me.columnX7
				End Get
			End Property

			' Token: 0x17000585 RID: 1413
			' (get) Token: 0x06000C9F RID: 3231 RVA: 0x000AE610 File Offset: 0x000AC810
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property X8Column As DataColumn
				Get
					Return Me.columnX8
				End Get
			End Property

			' Token: 0x17000586 RID: 1414
			' (get) Token: 0x06000CA0 RID: 3232 RVA: 0x000AE628 File Offset: 0x000AC828
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property X9Column As DataColumn
				Get
					Return Me.columnX9
				End Get
			End Property

			' Token: 0x17000587 RID: 1415
			' (get) Token: 0x06000CA1 RID: 3233 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17000588 RID: 1416
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As NewDataSet.MeargeDataRow
				Get
					Return CType(MyBase.Rows(index), NewDataSet.MeargeDataRow)
				End Get
			End Property

			' Token: 0x14000025 RID: 37
			' (add) Token: 0x06000CA3 RID: 3235 RVA: 0x000AE664 File Offset: 0x000AC864
			' (remove) Token: 0x06000CA4 RID: 3236 RVA: 0x000AE69C File Offset: 0x000AC89C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event MeargeDataRowChanging As NewDataSet.MeargeDataRowChangeEventHandler

			' Token: 0x14000026 RID: 38
			' (add) Token: 0x06000CA5 RID: 3237 RVA: 0x000AE6D4 File Offset: 0x000AC8D4
			' (remove) Token: 0x06000CA6 RID: 3238 RVA: 0x000AE70C File Offset: 0x000AC90C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event MeargeDataRowChanged As NewDataSet.MeargeDataRowChangeEventHandler

			' Token: 0x14000027 RID: 39
			' (add) Token: 0x06000CA7 RID: 3239 RVA: 0x000AE744 File Offset: 0x000AC944
			' (remove) Token: 0x06000CA8 RID: 3240 RVA: 0x000AE77C File Offset: 0x000AC97C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event MeargeDataRowDeleting As NewDataSet.MeargeDataRowChangeEventHandler

			' Token: 0x14000028 RID: 40
			' (add) Token: 0x06000CA9 RID: 3241 RVA: 0x000AE7B4 File Offset: 0x000AC9B4
			' (remove) Token: 0x06000CAA RID: 3242 RVA: 0x000AE7EC File Offset: 0x000AC9EC
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event MeargeDataRowDeleted As NewDataSet.MeargeDataRowChangeEventHandler

			' Token: 0x06000CAB RID: 3243 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddMeargeDataRow(row As NewDataSet.MeargeDataRow)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x06000CAC RID: 3244 RVA: 0x000AE824 File Offset: 0x000ACA24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddMeargeDataRow(ByCash As String, ByReturn As String, ByCredit_DebitCard As String, PaymentMode As String, _Operator As String, Inv_ID As String, InvoiceNo As String, InvoiceDate As DateTime, TaxType As String, Customer_ID As String, SalesmanID As String, SubTotal As String, CGST As String, SGST As String, IGST As String, CESS As String, GrandTotal As Decimal, TotalPaid As String, Balance As String, FreightCharges As String, OtherCharges As String, Total As String, RoundOff As String, Remarks As String, IPo_ID As String, InvoiceID As String, ProductID As String, Barcode As String, SalesRate As Double, Qty As Double, DiscountPer As Double, Discount As Decimal, CGSTPer As Double, CGSTAmt As Double, SGSTPer As Double, SGSTAmt As Double, IGSTPer As Double, IGSTAmt As Double, CESSPer As Double, CESSAmt As Double, TotalAmount As Double, PurchaseRate As Double, Margin As Double, PID As String, ProductCode As String, ProductName As String, SubCategoryID As String, HSNCode As String, PartNo As String, Description As String, CostPrice As Double, SellingPrice As Double, DiscountP As Double, CGSTP As Double, SGSTP As Double, CESSP As Double, BarcodeP As String, ReorderPoint As String, OpeningStock As String, PurchaseUnit As String, SalesUnit As String, ID As String, CustomerID As String, Name As String, Address As String, GSTIN As String, State As String, ZipCode As String, ContactNo As String, EmailID As String, RemarksC As String, AccountNumber As String, AccountName As String, Bank As String, Branch As String, IFSCCode As String, PAN As String, CIN As String, WriteOffAmount As Double, CreditBalance As Double, Paytm As Double, Gpay As Double, PhonePay As Double, OnlineOtherPay As Double, EMIENO As String, EMIBARCODE As String, EMIPID As String, EMIENO1 As String, MDate As String, EDate As String, POtherLanguage As String, AB1 As String, AB2 As String, AB3 As String, AB4 As String, AB5 As String, AB6 As String, AB7 As String, AB8 As String, AB9 As String, X1 As String, X2 As String, X3 As String, X4 As String, X5 As String, X6 As String, X7 As String, X8 As String, X9 As String) As NewDataSet.MeargeDataRow
				Dim meargeDataRow As NewDataSet.MeargeDataRow = CType(MyBase.NewRow(), NewDataSet.MeargeDataRow)
				Dim array As Object() = New Object() { ByCash, ByReturn, ByCredit_DebitCard, PaymentMode, _Operator, Inv_ID, InvoiceNo, InvoiceDate, TaxType, Customer_ID, SalesmanID, SubTotal, CGST, SGST, IGST, CESS, GrandTotal, TotalPaid, Balance, FreightCharges, OtherCharges, Total, RoundOff, Remarks, IPo_ID, InvoiceID, ProductID, Barcode, SalesRate, Qty, DiscountPer, Discount, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount, PurchaseRate, Margin, PID, ProductCode, ProductName, SubCategoryID, HSNCode, PartNo, Description, CostPrice, SellingPrice, DiscountP, CGSTP, SGSTP, CESSP, BarcodeP, ReorderPoint, OpeningStock, PurchaseUnit, SalesUnit, ID, CustomerID, Name, Address, GSTIN, State, ZipCode, ContactNo, EmailID, RemarksC, AccountNumber, AccountName, Bank, Branch, IFSCCode, PAN, CIN, WriteOffAmount, CreditBalance, Paytm, Gpay, PhonePay, OnlineOtherPay, EMIENO, EMIBARCODE, EMIPID, EMIENO1, MDate, EDate, POtherLanguage, AB1, AB2, AB3, AB4, AB5, AB6, AB7, AB8, AB9, X1, X2, X3, X4, X5, X6, X7, X8, X9 }
				meargeDataRow.ItemArray = array
				MyBase.Rows.Add(meargeDataRow)
				Return meargeDataRow
			End Function

			' Token: 0x06000CAD RID: 3245 RVA: 0x000AEB74 File Offset: 0x000ACD74
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim meargeDataDataTable As NewDataSet.MeargeDataDataTable = CType(MyBase.Clone(), NewDataSet.MeargeDataDataTable)
				meargeDataDataTable.InitVars()
				Return meargeDataDataTable
			End Function

			' Token: 0x06000CAE RID: 3246 RVA: 0x000AEB9C File Offset: 0x000ACD9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New NewDataSet.MeargeDataDataTable()
			End Function

			' Token: 0x06000CAF RID: 3247 RVA: 0x000AEBB4 File Offset: 0x000ACDB4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnByCash = MyBase.Columns("ByCash")
				Me.columnByReturn = MyBase.Columns("ByReturn")
				Me.columnByCredit_DebitCard = MyBase.Columns("ByCredit_DebitCard")
				Me.columnPaymentMode = MyBase.Columns("PaymentMode")
				Me.columnOperator = MyBase.Columns("Operator")
				Me.columnInv_ID = MyBase.Columns("Inv_ID")
				Me.columnInvoiceNo = MyBase.Columns("InvoiceNo")
				Me.columnInvoiceDate = MyBase.Columns("InvoiceDate")
				Me.columnTaxType = MyBase.Columns("TaxType")
				Me.columnCustomer_ID = MyBase.Columns("Customer_ID")
				Me.columnSalesmanID = MyBase.Columns("SalesmanID")
				Me.columnSubTotal = MyBase.Columns("SubTotal")
				Me.columnCGST = MyBase.Columns("CGST")
				Me.columnSGST = MyBase.Columns("SGST")
				Me.columnIGST = MyBase.Columns("IGST")
				Me.columnCESS = MyBase.Columns("CESS")
				Me.columnGrandTotal = MyBase.Columns("GrandTotal")
				Me.columnTotalPaid = MyBase.Columns("TotalPaid")
				Me.columnBalance = MyBase.Columns("Balance")
				Me.columnFreightCharges = MyBase.Columns("FreightCharges")
				Me.columnOtherCharges = MyBase.Columns("OtherCharges")
				Me.columnTotal = MyBase.Columns("Total")
				Me.columnRoundOff = MyBase.Columns("RoundOff")
				Me.columnRemarks = MyBase.Columns("Remarks")
				Me.columnIPo_ID = MyBase.Columns("IPo_ID")
				Me.columnInvoiceID = MyBase.Columns("InvoiceID")
				Me.columnProductID = MyBase.Columns("ProductID")
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnSalesRate = MyBase.Columns("SalesRate")
				Me.columnQty = MyBase.Columns("Qty")
				Me.columnDiscountPer = MyBase.Columns("DiscountPer")
				Me.columnDiscount = MyBase.Columns("Discount")
				Me.columnCGSTPer = MyBase.Columns("CGSTPer")
				Me.columnCGSTAmt = MyBase.Columns("CGSTAmt")
				Me.columnSGSTPer = MyBase.Columns("SGSTPer")
				Me.columnSGSTAmt = MyBase.Columns("SGSTAmt")
				Me.columnIGSTPer = MyBase.Columns("IGSTPer")
				Me.columnIGSTAmt = MyBase.Columns("IGSTAmt")
				Me.columnCESSPer = MyBase.Columns("CESSPer")
				Me.columnCESSAmt = MyBase.Columns("CESSAmt")
				Me.columnTotalAmount = MyBase.Columns("TotalAmount")
				Me.columnPurchaseRate = MyBase.Columns("PurchaseRate")
				Me.columnMargin = MyBase.Columns("Margin")
				Me.columnPID = MyBase.Columns("PID")
				Me.columnProductCode = MyBase.Columns("ProductCode")
				Me.columnProductName = MyBase.Columns("ProductName")
				Me.columnSubCategoryID = MyBase.Columns("SubCategoryID")
				Me.columnHSNCode = MyBase.Columns("HSNCode")
				Me.columnPartNo = MyBase.Columns("PartNo")
				Me.columnDescription = MyBase.Columns("Description")
				Me.columnCostPrice = MyBase.Columns("CostPrice")
				Me.columnSellingPrice = MyBase.Columns("SellingPrice")
				Me.columnDiscountP = MyBase.Columns("DiscountP")
				Me.columnCGSTP = MyBase.Columns("CGSTP")
				Me.columnSGSTP = MyBase.Columns("SGSTP")
				Me.columnCESSP = MyBase.Columns("CESSP")
				Me.columnBarcodeP = MyBase.Columns("BarcodeP")
				Me.columnReorderPoint = MyBase.Columns("ReorderPoint")
				Me.columnOpeningStock = MyBase.Columns("OpeningStock")
				Me.columnPurchaseUnit = MyBase.Columns("PurchaseUnit")
				Me.columnSalesUnit = MyBase.Columns("SalesUnit")
				Me.columnID = MyBase.Columns("ID")
				Me.columnCustomerID = MyBase.Columns("CustomerID")
				Me.columnName = MyBase.Columns("Name")
				Me.columnAddress = MyBase.Columns("Address")
				Me.columnGSTIN = MyBase.Columns("GSTIN")
				Me.columnState = MyBase.Columns("State")
				Me.columnZipCode = MyBase.Columns("ZipCode")
				Me.columnContactNo = MyBase.Columns("ContactNo")
				Me.columnEmailID = MyBase.Columns("EmailID")
				Me.columnRemarksC = MyBase.Columns("RemarksC")
				Me.columnAccountNumber = MyBase.Columns("AccountNumber")
				Me.columnAccountName = MyBase.Columns("AccountName")
				Me.columnBank = MyBase.Columns("Bank")
				Me.columnBranch = MyBase.Columns("Branch")
				Me.columnIFSCCode = MyBase.Columns("IFSCCode")
				Me.columnPAN = MyBase.Columns("PAN")
				Me.columnCIN = MyBase.Columns("CIN")
				Me.columnWriteOffAmount = MyBase.Columns("WriteOffAmount")
				Me.columnCreditBalance = MyBase.Columns("CreditBalance")
				Me.columnPaytm = MyBase.Columns("Paytm")
				Me.columnGpay = MyBase.Columns("Gpay")
				Me.columnPhonePay = MyBase.Columns("PhonePay")
				Me.columnOnlineOtherPay = MyBase.Columns("OnlineOtherPay")
				Me.columnEMIENO = MyBase.Columns("EMIENO")
				Me.columnEMIBARCODE = MyBase.Columns("EMIBARCODE")
				Me.columnEMIPID = MyBase.Columns("EMIPID")
				Me.columnEMIENO1 = MyBase.Columns("EMIENO1")
				Me.columnMDate = MyBase.Columns("MDate")
				Me.columnEDate = MyBase.Columns("EDate")
				Me.columnPOtherLanguage = MyBase.Columns("POtherLanguage")
				Me.columnAB1 = MyBase.Columns("AB1")
				Me.columnAB2 = MyBase.Columns("AB2")
				Me.columnAB3 = MyBase.Columns("AB3")
				Me.columnAB4 = MyBase.Columns("AB4")
				Me.columnAB5 = MyBase.Columns("AB5")
				Me.columnAB6 = MyBase.Columns("AB6")
				Me.columnAB7 = MyBase.Columns("AB7")
				Me.columnAB8 = MyBase.Columns("AB8")
				Me.columnAB9 = MyBase.Columns("AB9")
				Me.columnX1 = MyBase.Columns("X1")
				Me.columnX2 = MyBase.Columns("X2")
				Me.columnX3 = MyBase.Columns("X3")
				Me.columnX4 = MyBase.Columns("X4")
				Me.columnX5 = MyBase.Columns("X5")
				Me.columnX6 = MyBase.Columns("X6")
				Me.columnX7 = MyBase.Columns("X7")
				Me.columnX8 = MyBase.Columns("X8")
				Me.columnX9 = MyBase.Columns("X9")
			End Sub

			' Token: 0x06000CB0 RID: 3248 RVA: 0x000AF520 File Offset: 0x000AD720
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnByCash = New DataColumn("ByCash", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnByCash)
				Me.columnByReturn = New DataColumn("ByReturn", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnByReturn)
				Me.columnByCredit_DebitCard = New DataColumn("ByCredit_DebitCard", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnByCredit_DebitCard)
				Me.columnPaymentMode = New DataColumn("PaymentMode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPaymentMode)
				Me.columnOperator = New DataColumn("Operator", GetType(String), Nothing, MappingType.Element)
				Me.columnOperator.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "OperatorColumn")
				Me.columnOperator.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnOperator")
				Me.columnOperator.ExtendedProperties.Add("Generator_UserColumnName", "Operator")
				MyBase.Columns.Add(Me.columnOperator)
				Me.columnInv_ID = New DataColumn("Inv_ID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnInv_ID)
				Me.columnInvoiceNo = New DataColumn("InvoiceNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnInvoiceNo)
				Me.columnInvoiceDate = New DataColumn("InvoiceDate", GetType(DateTime), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnInvoiceDate)
				Me.columnTaxType = New DataColumn("TaxType", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTaxType)
				Me.columnCustomer_ID = New DataColumn("Customer_ID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCustomer_ID)
				Me.columnSalesmanID = New DataColumn("SalesmanID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSalesmanID)
				Me.columnSubTotal = New DataColumn("SubTotal", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSubTotal)
				Me.columnCGST = New DataColumn("CGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGST)
				Me.columnSGST = New DataColumn("SGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGST)
				Me.columnIGST = New DataColumn("IGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGST)
				Me.columnCESS = New DataColumn("CESS", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESS)
				Me.columnGrandTotal = New DataColumn("GrandTotal", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGrandTotal)
				Me.columnTotalPaid = New DataColumn("TotalPaid", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTotalPaid)
				Me.columnBalance = New DataColumn("Balance", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBalance)
				Me.columnFreightCharges = New DataColumn("FreightCharges", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnFreightCharges)
				Me.columnOtherCharges = New DataColumn("OtherCharges", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnOtherCharges)
				Me.columnTotal = New DataColumn("Total", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTotal)
				Me.columnRoundOff = New DataColumn("RoundOff", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRoundOff)
				Me.columnRemarks = New DataColumn("Remarks", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRemarks)
				Me.columnIPo_ID = New DataColumn("IPo_ID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIPo_ID)
				Me.columnInvoiceID = New DataColumn("InvoiceID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnInvoiceID)
				Me.columnProductID = New DataColumn("ProductID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductID)
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnSalesRate = New DataColumn("SalesRate", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSalesRate)
				Me.columnQty = New DataColumn("Qty", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQty)
				Me.columnDiscountPer = New DataColumn("DiscountPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscountPer)
				Me.columnDiscount = New DataColumn("Discount", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscount)
				Me.columnCGSTPer = New DataColumn("CGSTPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGSTPer)
				Me.columnCGSTAmt = New DataColumn("CGSTAmt", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGSTAmt)
				Me.columnSGSTPer = New DataColumn("SGSTPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGSTPer)
				Me.columnSGSTAmt = New DataColumn("SGSTAmt", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGSTAmt)
				Me.columnIGSTPer = New DataColumn("IGSTPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGSTPer)
				Me.columnIGSTAmt = New DataColumn("IGSTAmt", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGSTAmt)
				Me.columnCESSPer = New DataColumn("CESSPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESSPer)
				Me.columnCESSAmt = New DataColumn("CESSAmt", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESSAmt)
				Me.columnTotalAmount = New DataColumn("TotalAmount", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTotalAmount)
				Me.columnPurchaseRate = New DataColumn("PurchaseRate", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPurchaseRate)
				Me.columnMargin = New DataColumn("Margin", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMargin)
				Me.columnPID = New DataColumn("PID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPID)
				Me.columnProductCode = New DataColumn("ProductCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductCode)
				Me.columnProductName = New DataColumn("ProductName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductName)
				Me.columnSubCategoryID = New DataColumn("SubCategoryID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSubCategoryID)
				Me.columnHSNCode = New DataColumn("HSNCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnHSNCode)
				Me.columnPartNo = New DataColumn("PartNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPartNo)
				Me.columnDescription = New DataColumn("Description", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDescription)
				Me.columnCostPrice = New DataColumn("CostPrice", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCostPrice)
				Me.columnSellingPrice = New DataColumn("SellingPrice", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSellingPrice)
				Me.columnDiscountP = New DataColumn("DiscountP", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscountP)
				Me.columnCGSTP = New DataColumn("CGSTP", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGSTP)
				Me.columnSGSTP = New DataColumn("SGSTP", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGSTP)
				Me.columnCESSP = New DataColumn("CESSP", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESSP)
				Me.columnBarcodeP = New DataColumn("BarcodeP", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcodeP)
				Me.columnReorderPoint = New DataColumn("ReorderPoint", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnReorderPoint)
				Me.columnOpeningStock = New DataColumn("OpeningStock", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnOpeningStock)
				Me.columnPurchaseUnit = New DataColumn("PurchaseUnit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPurchaseUnit)
				Me.columnSalesUnit = New DataColumn("SalesUnit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSalesUnit)
				Me.columnID = New DataColumn("ID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnID)
				Me.columnCustomerID = New DataColumn("CustomerID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCustomerID)
				Me.columnName = New DataColumn("Name", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnName)
				Me.columnAddress = New DataColumn("Address", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAddress)
				Me.columnGSTIN = New DataColumn("GSTIN", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGSTIN)
				Me.columnState = New DataColumn("State", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnState)
				Me.columnZipCode = New DataColumn("ZipCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZipCode)
				Me.columnContactNo = New DataColumn("ContactNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnContactNo)
				Me.columnEmailID = New DataColumn("EmailID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnEmailID)
				Me.columnRemarksC = New DataColumn("RemarksC", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRemarksC)
				Me.columnAccountNumber = New DataColumn("AccountNumber", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAccountNumber)
				Me.columnAccountName = New DataColumn("AccountName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAccountName)
				Me.columnBank = New DataColumn("Bank", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBank)
				Me.columnBranch = New DataColumn("Branch", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBranch)
				Me.columnIFSCCode = New DataColumn("IFSCCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIFSCCode)
				Me.columnPAN = New DataColumn("PAN", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPAN)
				Me.columnCIN = New DataColumn("CIN", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCIN)
				Me.columnWriteOffAmount = New DataColumn("WriteOffAmount", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnWriteOffAmount)
				Me.columnCreditBalance = New DataColumn("CreditBalance", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCreditBalance)
				Me.columnPaytm = New DataColumn("Paytm", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPaytm)
				Me.columnGpay = New DataColumn("Gpay", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGpay)
				Me.columnPhonePay = New DataColumn("PhonePay", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPhonePay)
				Me.columnOnlineOtherPay = New DataColumn("OnlineOtherPay", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnOnlineOtherPay)
				Me.columnEMIENO = New DataColumn("EMIENO", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnEMIENO)
				Me.columnEMIBARCODE = New DataColumn("EMIBARCODE", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnEMIBARCODE)
				Me.columnEMIPID = New DataColumn("EMIPID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnEMIPID)
				Me.columnEMIENO1 = New DataColumn("EMIENO1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnEMIENO1)
				Me.columnMDate = New DataColumn("MDate", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMDate)
				Me.columnEDate = New DataColumn("EDate", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnEDate)
				Me.columnPOtherLanguage = New DataColumn("POtherLanguage", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPOtherLanguage)
				Me.columnAB1 = New DataColumn("AB1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAB1)
				Me.columnAB2 = New DataColumn("AB2", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAB2)
				Me.columnAB3 = New DataColumn("AB3", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAB3)
				Me.columnAB4 = New DataColumn("AB4", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAB4)
				Me.columnAB5 = New DataColumn("AB5", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAB5)
				Me.columnAB6 = New DataColumn("AB6", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAB6)
				Me.columnAB7 = New DataColumn("AB7", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAB7)
				Me.columnAB8 = New DataColumn("AB8", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAB8)
				Me.columnAB9 = New DataColumn("AB9", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAB9)
				Me.columnX1 = New DataColumn("X1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX1)
				Me.columnX2 = New DataColumn("X2", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX2)
				Me.columnX3 = New DataColumn("X3", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX3)
				Me.columnX4 = New DataColumn("X4", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX4)
				Me.columnX5 = New DataColumn("X5", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX5)
				Me.columnX6 = New DataColumn("X6", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX6)
				Me.columnX7 = New DataColumn("X7", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX7)
				Me.columnX8 = New DataColumn("X8", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX8)
				Me.columnX9 = New DataColumn("X9", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX9)
			End Sub

			' Token: 0x06000CB1 RID: 3249 RVA: 0x000B0918 File Offset: 0x000AEB18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewMeargeDataRow() As NewDataSet.MeargeDataRow
				Return CType(MyBase.NewRow(), NewDataSet.MeargeDataRow)
			End Function

			' Token: 0x06000CB2 RID: 3250 RVA: 0x000B0938 File Offset: 0x000AEB38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New NewDataSet.MeargeDataRow(builder)
			End Function

			' Token: 0x06000CB3 RID: 3251 RVA: 0x000B0950 File Offset: 0x000AEB50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(NewDataSet.MeargeDataRow)
			End Function

			' Token: 0x06000CB4 RID: 3252 RVA: 0x000B096C File Offset: 0x000AEB6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.MeargeDataRowChangedEvent IsNot Nothing
				If flag Then
					Dim meargeDataRowChangedEvent As NewDataSet.MeargeDataRowChangeEventHandler = Me.MeargeDataRowChangedEvent
					If meargeDataRowChangedEvent IsNot Nothing Then
						meargeDataRowChangedEvent(Me, New NewDataSet.MeargeDataRowChangeEvent(CType(e.Row, NewDataSet.MeargeDataRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000CB5 RID: 3253 RVA: 0x000B09BC File Offset: 0x000AEBBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.MeargeDataRowChangingEvent IsNot Nothing
				If flag Then
					Dim meargeDataRowChangingEvent As NewDataSet.MeargeDataRowChangeEventHandler = Me.MeargeDataRowChangingEvent
					If meargeDataRowChangingEvent IsNot Nothing Then
						meargeDataRowChangingEvent(Me, New NewDataSet.MeargeDataRowChangeEvent(CType(e.Row, NewDataSet.MeargeDataRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000CB6 RID: 3254 RVA: 0x000B0A0C File Offset: 0x000AEC0C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.MeargeDataRowDeletedEvent IsNot Nothing
				If flag Then
					Dim meargeDataRowDeletedEvent As NewDataSet.MeargeDataRowChangeEventHandler = Me.MeargeDataRowDeletedEvent
					If meargeDataRowDeletedEvent IsNot Nothing Then
						meargeDataRowDeletedEvent(Me, New NewDataSet.MeargeDataRowChangeEvent(CType(e.Row, NewDataSet.MeargeDataRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000CB7 RID: 3255 RVA: 0x000B0A5C File Offset: 0x000AEC5C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.MeargeDataRowDeletingEvent IsNot Nothing
				If flag Then
					Dim meargeDataRowDeletingEvent As NewDataSet.MeargeDataRowChangeEventHandler = Me.MeargeDataRowDeletingEvent
					If meargeDataRowDeletingEvent IsNot Nothing Then
						meargeDataRowDeletingEvent(Me, New NewDataSet.MeargeDataRowChangeEvent(CType(e.Row, NewDataSet.MeargeDataRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000CB8 RID: 3256 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveMeargeDataRow(row As NewDataSet.MeargeDataRow)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x06000CB9 RID: 3257 RVA: 0x000B0AAC File Offset: 0x000AECAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim newDataSet As NewDataSet = New NewDataSet()
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
				xmlSchemaAttribute.FixedValue = newDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "MeargeDataDataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = newDataSet.GetSchemaSerializable()
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

			' Token: 0x040003BD RID: 957
			Private columnByCash As DataColumn

			' Token: 0x040003BE RID: 958
			Private columnByReturn As DataColumn

			' Token: 0x040003BF RID: 959
			Private columnByCredit_DebitCard As DataColumn

			' Token: 0x040003C0 RID: 960
			Private columnPaymentMode As DataColumn

			' Token: 0x040003C1 RID: 961
			Private columnOperator As DataColumn

			' Token: 0x040003C2 RID: 962
			Private columnInv_ID As DataColumn

			' Token: 0x040003C3 RID: 963
			Private columnInvoiceNo As DataColumn

			' Token: 0x040003C4 RID: 964
			Private columnInvoiceDate As DataColumn

			' Token: 0x040003C5 RID: 965
			Private columnTaxType As DataColumn

			' Token: 0x040003C6 RID: 966
			Private columnCustomer_ID As DataColumn

			' Token: 0x040003C7 RID: 967
			Private columnSalesmanID As DataColumn

			' Token: 0x040003C8 RID: 968
			Private columnSubTotal As DataColumn

			' Token: 0x040003C9 RID: 969
			Private columnCGST As DataColumn

			' Token: 0x040003CA RID: 970
			Private columnSGST As DataColumn

			' Token: 0x040003CB RID: 971
			Private columnIGST As DataColumn

			' Token: 0x040003CC RID: 972
			Private columnCESS As DataColumn

			' Token: 0x040003CD RID: 973
			Private columnGrandTotal As DataColumn

			' Token: 0x040003CE RID: 974
			Private columnTotalPaid As DataColumn

			' Token: 0x040003CF RID: 975
			Private columnBalance As DataColumn

			' Token: 0x040003D0 RID: 976
			Private columnFreightCharges As DataColumn

			' Token: 0x040003D1 RID: 977
			Private columnOtherCharges As DataColumn

			' Token: 0x040003D2 RID: 978
			Private columnTotal As DataColumn

			' Token: 0x040003D3 RID: 979
			Private columnRoundOff As DataColumn

			' Token: 0x040003D4 RID: 980
			Private columnRemarks As DataColumn

			' Token: 0x040003D5 RID: 981
			Private columnIPo_ID As DataColumn

			' Token: 0x040003D6 RID: 982
			Private columnInvoiceID As DataColumn

			' Token: 0x040003D7 RID: 983
			Private columnProductID As DataColumn

			' Token: 0x040003D8 RID: 984
			Private columnBarcode As DataColumn

			' Token: 0x040003D9 RID: 985
			Private columnSalesRate As DataColumn

			' Token: 0x040003DA RID: 986
			Private columnQty As DataColumn

			' Token: 0x040003DB RID: 987
			Private columnDiscountPer As DataColumn

			' Token: 0x040003DC RID: 988
			Private columnDiscount As DataColumn

			' Token: 0x040003DD RID: 989
			Private columnCGSTPer As DataColumn

			' Token: 0x040003DE RID: 990
			Private columnCGSTAmt As DataColumn

			' Token: 0x040003DF RID: 991
			Private columnSGSTPer As DataColumn

			' Token: 0x040003E0 RID: 992
			Private columnSGSTAmt As DataColumn

			' Token: 0x040003E1 RID: 993
			Private columnIGSTPer As DataColumn

			' Token: 0x040003E2 RID: 994
			Private columnIGSTAmt As DataColumn

			' Token: 0x040003E3 RID: 995
			Private columnCESSPer As DataColumn

			' Token: 0x040003E4 RID: 996
			Private columnCESSAmt As DataColumn

			' Token: 0x040003E5 RID: 997
			Private columnTotalAmount As DataColumn

			' Token: 0x040003E6 RID: 998
			Private columnPurchaseRate As DataColumn

			' Token: 0x040003E7 RID: 999
			Private columnMargin As DataColumn

			' Token: 0x040003E8 RID: 1000
			Private columnPID As DataColumn

			' Token: 0x040003E9 RID: 1001
			Private columnProductCode As DataColumn

			' Token: 0x040003EA RID: 1002
			Private columnProductName As DataColumn

			' Token: 0x040003EB RID: 1003
			Private columnSubCategoryID As DataColumn

			' Token: 0x040003EC RID: 1004
			Private columnHSNCode As DataColumn

			' Token: 0x040003ED RID: 1005
			Private columnPartNo As DataColumn

			' Token: 0x040003EE RID: 1006
			Private columnDescription As DataColumn

			' Token: 0x040003EF RID: 1007
			Private columnCostPrice As DataColumn

			' Token: 0x040003F0 RID: 1008
			Private columnSellingPrice As DataColumn

			' Token: 0x040003F1 RID: 1009
			Private columnDiscountP As DataColumn

			' Token: 0x040003F2 RID: 1010
			Private columnCGSTP As DataColumn

			' Token: 0x040003F3 RID: 1011
			Private columnSGSTP As DataColumn

			' Token: 0x040003F4 RID: 1012
			Private columnCESSP As DataColumn

			' Token: 0x040003F5 RID: 1013
			Private columnBarcodeP As DataColumn

			' Token: 0x040003F6 RID: 1014
			Private columnReorderPoint As DataColumn

			' Token: 0x040003F7 RID: 1015
			Private columnOpeningStock As DataColumn

			' Token: 0x040003F8 RID: 1016
			Private columnPurchaseUnit As DataColumn

			' Token: 0x040003F9 RID: 1017
			Private columnSalesUnit As DataColumn

			' Token: 0x040003FA RID: 1018
			Private columnID As DataColumn

			' Token: 0x040003FB RID: 1019
			Private columnCustomerID As DataColumn

			' Token: 0x040003FC RID: 1020
			Private columnName As DataColumn

			' Token: 0x040003FD RID: 1021
			Private columnAddress As DataColumn

			' Token: 0x040003FE RID: 1022
			Private columnGSTIN As DataColumn

			' Token: 0x040003FF RID: 1023
			Private columnState As DataColumn

			' Token: 0x04000400 RID: 1024
			Private columnZipCode As DataColumn

			' Token: 0x04000401 RID: 1025
			Private columnContactNo As DataColumn

			' Token: 0x04000402 RID: 1026
			Private columnEmailID As DataColumn

			' Token: 0x04000403 RID: 1027
			Private columnRemarksC As DataColumn

			' Token: 0x04000404 RID: 1028
			Private columnAccountNumber As DataColumn

			' Token: 0x04000405 RID: 1029
			Private columnAccountName As DataColumn

			' Token: 0x04000406 RID: 1030
			Private columnBank As DataColumn

			' Token: 0x04000407 RID: 1031
			Private columnBranch As DataColumn

			' Token: 0x04000408 RID: 1032
			Private columnIFSCCode As DataColumn

			' Token: 0x04000409 RID: 1033
			Private columnPAN As DataColumn

			' Token: 0x0400040A RID: 1034
			Private columnCIN As DataColumn

			' Token: 0x0400040B RID: 1035
			Private columnWriteOffAmount As DataColumn

			' Token: 0x0400040C RID: 1036
			Private columnCreditBalance As DataColumn

			' Token: 0x0400040D RID: 1037
			Private columnPaytm As DataColumn

			' Token: 0x0400040E RID: 1038
			Private columnGpay As DataColumn

			' Token: 0x0400040F RID: 1039
			Private columnPhonePay As DataColumn

			' Token: 0x04000410 RID: 1040
			Private columnOnlineOtherPay As DataColumn

			' Token: 0x04000411 RID: 1041
			Private columnEMIENO As DataColumn

			' Token: 0x04000412 RID: 1042
			Private columnEMIBARCODE As DataColumn

			' Token: 0x04000413 RID: 1043
			Private columnEMIPID As DataColumn

			' Token: 0x04000414 RID: 1044
			Private columnEMIENO1 As DataColumn

			' Token: 0x04000415 RID: 1045
			Private columnMDate As DataColumn

			' Token: 0x04000416 RID: 1046
			Private columnEDate As DataColumn

			' Token: 0x04000417 RID: 1047
			Private columnPOtherLanguage As DataColumn

			' Token: 0x04000418 RID: 1048
			Private columnAB1 As DataColumn

			' Token: 0x04000419 RID: 1049
			Private columnAB2 As DataColumn

			' Token: 0x0400041A RID: 1050
			Private columnAB3 As DataColumn

			' Token: 0x0400041B RID: 1051
			Private columnAB4 As DataColumn

			' Token: 0x0400041C RID: 1052
			Private columnAB5 As DataColumn

			' Token: 0x0400041D RID: 1053
			Private columnAB6 As DataColumn

			' Token: 0x0400041E RID: 1054
			Private columnAB7 As DataColumn

			' Token: 0x0400041F RID: 1055
			Private columnAB8 As DataColumn

			' Token: 0x04000420 RID: 1056
			Private columnAB9 As DataColumn

			' Token: 0x04000421 RID: 1057
			Private columnX1 As DataColumn

			' Token: 0x04000422 RID: 1058
			Private columnX2 As DataColumn

			' Token: 0x04000423 RID: 1059
			Private columnX3 As DataColumn

			' Token: 0x04000424 RID: 1060
			Private columnX4 As DataColumn

			' Token: 0x04000425 RID: 1061
			Private columnX5 As DataColumn

			' Token: 0x04000426 RID: 1062
			Private columnX6 As DataColumn

			' Token: 0x04000427 RID: 1063
			Private columnX7 As DataColumn

			' Token: 0x04000428 RID: 1064
			Private columnX8 As DataColumn

			' Token: 0x04000429 RID: 1065
			Private columnX9 As DataColumn
		End Class

		' Token: 0x02000049 RID: 73
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class CompanyDataTable
			Inherits TypedTableBase(Of NewDataSet.CompanyRow)

			' Token: 0x06000CBA RID: 3258 RVA: 0x0000C662 File Offset: 0x0000A862
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "Company"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x06000CBB RID: 3259 RVA: 0x000B0D00 File Offset: 0x000AEF00
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

			' Token: 0x06000CBC RID: 3260 RVA: 0x0000C68D File Offset: 0x0000A88D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17000589 RID: 1417
			' (get) Token: 0x06000CBD RID: 3261 RVA: 0x000B0DCC File Offset: 0x000AEFCC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CompanyNameColumn As DataColumn
				Get
					Return Me.columnCompanyName
				End Get
			End Property

			' Token: 0x1700058A RID: 1418
			' (get) Token: 0x06000CBE RID: 3262 RVA: 0x000B0DE4 File Offset: 0x000AEFE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AddressColumn As DataColumn
				Get
					Return Me.columnAddress
				End Get
			End Property

			' Token: 0x1700058B RID: 1419
			' (get) Token: 0x06000CBF RID: 3263 RVA: 0x000B0DFC File Offset: 0x000AEFFC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property StateColumn As DataColumn
				Get
					Return Me.columnState
				End Get
			End Property

			' Token: 0x1700058C RID: 1420
			' (get) Token: 0x06000CC0 RID: 3264 RVA: 0x000B0E14 File Offset: 0x000AF014
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ContactNoColumn As DataColumn
				Get
					Return Me.columnContactNo
				End Get
			End Property

			' Token: 0x1700058D RID: 1421
			' (get) Token: 0x06000CC1 RID: 3265 RVA: 0x000B0E2C File Offset: 0x000AF02C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property EmailIDColumn As DataColumn
				Get
					Return Me.columnEmailID
				End Get
			End Property

			' Token: 0x1700058E RID: 1422
			' (get) Token: 0x06000CC2 RID: 3266 RVA: 0x000B0E44 File Offset: 0x000AF044
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property LogoColumn As DataColumn
				Get
					Return Me.columnLogo
				End Get
			End Property

			' Token: 0x1700058F RID: 1423
			' (get) Token: 0x06000CC3 RID: 3267 RVA: 0x000B0E5C File Offset: 0x000AF05C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GSTINColumn As DataColumn
				Get
					Return Me.columnGSTIN
				End Get
			End Property

			' Token: 0x17000590 RID: 1424
			' (get) Token: 0x06000CC4 RID: 3268 RVA: 0x000B0E74 File Offset: 0x000AF074
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CINColumn As DataColumn
				Get
					Return Me.columnCIN
				End Get
			End Property

			' Token: 0x17000591 RID: 1425
			' (get) Token: 0x06000CC5 RID: 3269 RVA: 0x000B0E8C File Offset: 0x000AF08C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MaxWriteOffAmountColumn As DataColumn
				Get
					Return Me.columnMaxWriteOffAmount
				End Get
			End Property

			' Token: 0x17000592 RID: 1426
			' (get) Token: 0x06000CC6 RID: 3270 RVA: 0x000B0EA4 File Offset: 0x000AF0A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Percentage_PerRsColumn As DataColumn
				Get
					Return Me.columnPercentage_PerRs
				End Get
			End Property

			' Token: 0x17000593 RID: 1427
			' (get) Token: 0x06000CC7 RID: 3271 RVA: 0x000B0EBC File Offset: 0x000AF0BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Terms1Column As DataColumn
				Get
					Return Me.columnTerms1
				End Get
			End Property

			' Token: 0x17000594 RID: 1428
			' (get) Token: 0x06000CC8 RID: 3272 RVA: 0x000B0ED4 File Offset: 0x000AF0D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Terms2Column As DataColumn
				Get
					Return Me.columnTerms2
				End Get
			End Property

			' Token: 0x17000595 RID: 1429
			' (get) Token: 0x06000CC9 RID: 3273 RVA: 0x000B0EEC File Offset: 0x000AF0EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Terms3Column As DataColumn
				Get
					Return Me.columnTerms3
				End Get
			End Property

			' Token: 0x17000596 RID: 1430
			' (get) Token: 0x06000CCA RID: 3274 RVA: 0x000B0F04 File Offset: 0x000AF104
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BillCodeColumn As DataColumn
				Get
					Return Me.columnBillCode
				End Get
			End Property

			' Token: 0x17000597 RID: 1431
			' (get) Token: 0x06000CCB RID: 3275 RVA: 0x000B0F1C File Offset: 0x000AF11C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Round_OffColumn As DataColumn
				Get
					Return Me.columnRound_Off
				End Get
			End Property

			' Token: 0x17000598 RID: 1432
			' (get) Token: 0x06000CCC RID: 3276 RVA: 0x000B0F34 File Offset: 0x000AF134
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BankInfo1Column As DataColumn
				Get
					Return Me.columnBankInfo1
				End Get
			End Property

			' Token: 0x17000599 RID: 1433
			' (get) Token: 0x06000CCD RID: 3277 RVA: 0x000B0F4C File Offset: 0x000AF14C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BankInfo2Column As DataColumn
				Get
					Return Me.columnBankInfo2
				End Get
			End Property

			' Token: 0x1700059A RID: 1434
			' (get) Token: 0x06000CCE RID: 3278 RVA: 0x000B0F64 File Offset: 0x000AF164
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property VersionColumn As DataColumn
				Get
					Return Me.columnVersion
				End Get
			End Property

			' Token: 0x1700059B RID: 1435
			' (get) Token: 0x06000CCF RID: 3279 RVA: 0x000B0F7C File Offset: 0x000AF17C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Z1Column As DataColumn
				Get
					Return Me.columnZ1
				End Get
			End Property

			' Token: 0x1700059C RID: 1436
			' (get) Token: 0x06000CD0 RID: 3280 RVA: 0x000B0F94 File Offset: 0x000AF194
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Z2Column As DataColumn
				Get
					Return Me.columnZ2
				End Get
			End Property

			' Token: 0x1700059D RID: 1437
			' (get) Token: 0x06000CD1 RID: 3281 RVA: 0x000B0FAC File Offset: 0x000AF1AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Z3Column As DataColumn
				Get
					Return Me.columnZ3
				End Get
			End Property

			' Token: 0x1700059E RID: 1438
			' (get) Token: 0x06000CD2 RID: 3282 RVA: 0x000B0FC4 File Offset: 0x000AF1C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Z4Column As DataColumn
				Get
					Return Me.columnZ4
				End Get
			End Property

			' Token: 0x1700059F RID: 1439
			' (get) Token: 0x06000CD3 RID: 3283 RVA: 0x000B0FDC File Offset: 0x000AF1DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Z5Column As DataColumn
				Get
					Return Me.columnZ5
				End Get
			End Property

			' Token: 0x170005A0 RID: 1440
			' (get) Token: 0x06000CD4 RID: 3284 RVA: 0x000B0FF4 File Offset: 0x000AF1F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Z6Column As DataColumn
				Get
					Return Me.columnZ6
				End Get
			End Property

			' Token: 0x170005A1 RID: 1441
			' (get) Token: 0x06000CD5 RID: 3285 RVA: 0x000B100C File Offset: 0x000AF20C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Z7Column As DataColumn
				Get
					Return Me.columnZ7
				End Get
			End Property

			' Token: 0x170005A2 RID: 1442
			' (get) Token: 0x06000CD6 RID: 3286 RVA: 0x000B1024 File Offset: 0x000AF224
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Z8Column As DataColumn
				Get
					Return Me.columnZ8
				End Get
			End Property

			' Token: 0x170005A3 RID: 1443
			' (get) Token: 0x06000CD7 RID: 3287 RVA: 0x000B103C File Offset: 0x000AF23C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Z9Column As DataColumn
				Get
					Return Me.columnZ9
				End Get
			End Property

			' Token: 0x170005A4 RID: 1444
			' (get) Token: 0x06000CD8 RID: 3288 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x170005A5 RID: 1445
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As NewDataSet.CompanyRow
				Get
					Return CType(MyBase.Rows(index), NewDataSet.CompanyRow)
				End Get
			End Property

			' Token: 0x14000029 RID: 41
			' (add) Token: 0x06000CDA RID: 3290 RVA: 0x000B1078 File Offset: 0x000AF278
			' (remove) Token: 0x06000CDB RID: 3291 RVA: 0x000B10B0 File Offset: 0x000AF2B0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event CompanyRowChanging As NewDataSet.CompanyRowChangeEventHandler

			' Token: 0x1400002A RID: 42
			' (add) Token: 0x06000CDC RID: 3292 RVA: 0x000B10E8 File Offset: 0x000AF2E8
			' (remove) Token: 0x06000CDD RID: 3293 RVA: 0x000B1120 File Offset: 0x000AF320
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event CompanyRowChanged As NewDataSet.CompanyRowChangeEventHandler

			' Token: 0x1400002B RID: 43
			' (add) Token: 0x06000CDE RID: 3294 RVA: 0x000B1158 File Offset: 0x000AF358
			' (remove) Token: 0x06000CDF RID: 3295 RVA: 0x000B1190 File Offset: 0x000AF390
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event CompanyRowDeleting As NewDataSet.CompanyRowChangeEventHandler

			' Token: 0x1400002C RID: 44
			' (add) Token: 0x06000CE0 RID: 3296 RVA: 0x000B11C8 File Offset: 0x000AF3C8
			' (remove) Token: 0x06000CE1 RID: 3297 RVA: 0x000B1200 File Offset: 0x000AF400
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event CompanyRowDeleted As NewDataSet.CompanyRowChangeEventHandler

			' Token: 0x06000CE2 RID: 3298 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddCompanyRow(row As NewDataSet.CompanyRow)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x06000CE3 RID: 3299 RVA: 0x000B1238 File Offset: 0x000AF438
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddCompanyRow(CompanyName As String, Address As String, State As String, ContactNo As String, EmailID As String, Logo As Byte(), GSTIN As String, CIN As String, MaxWriteOffAmount As String, Percentage_PerRs As String, Terms1 As String, Terms2 As String, Terms3 As String, BillCode As String, Round_Off As String, BankInfo1 As String, BankInfo2 As String, Version As String, Z1 As String, Z2 As String, Z3 As String, Z4 As String, Z5 As String, Z6 As String, Z7 As String, Z8 As String, Z9 As String) As NewDataSet.CompanyRow
				Dim companyRow As NewDataSet.CompanyRow = CType(MyBase.NewRow(), NewDataSet.CompanyRow)
				Dim array As Object() = New Object() { CompanyName, Address, State, ContactNo, EmailID, Logo, GSTIN, CIN, MaxWriteOffAmount, Percentage_PerRs, Terms1, Terms2, Terms3, BillCode, Round_Off, BankInfo1, BankInfo2, Version, Z1, Z2, Z3, Z4, Z5, Z6, Z7, Z8, Z9 }
				companyRow.ItemArray = array
				MyBase.Rows.Add(companyRow)
				Return companyRow
			End Function

			' Token: 0x06000CE4 RID: 3300 RVA: 0x000B130C File Offset: 0x000AF50C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim companyDataTable As NewDataSet.CompanyDataTable = CType(MyBase.Clone(), NewDataSet.CompanyDataTable)
				companyDataTable.InitVars()
				Return companyDataTable
			End Function

			' Token: 0x06000CE5 RID: 3301 RVA: 0x000B1334 File Offset: 0x000AF534
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New NewDataSet.CompanyDataTable()
			End Function

			' Token: 0x06000CE6 RID: 3302 RVA: 0x000B134C File Offset: 0x000AF54C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnCompanyName = MyBase.Columns("CompanyName")
				Me.columnAddress = MyBase.Columns("Address")
				Me.columnState = MyBase.Columns("State")
				Me.columnContactNo = MyBase.Columns("ContactNo")
				Me.columnEmailID = MyBase.Columns("EmailID")
				Me.columnLogo = MyBase.Columns("Logo")
				Me.columnGSTIN = MyBase.Columns("GSTIN")
				Me.columnCIN = MyBase.Columns("CIN")
				Me.columnMaxWriteOffAmount = MyBase.Columns("MaxWriteOffAmount")
				Me.columnPercentage_PerRs = MyBase.Columns("Percentage_PerRs")
				Me.columnTerms1 = MyBase.Columns("Terms1")
				Me.columnTerms2 = MyBase.Columns("Terms2")
				Me.columnTerms3 = MyBase.Columns("Terms3")
				Me.columnBillCode = MyBase.Columns("BillCode")
				Me.columnRound_Off = MyBase.Columns("Round_Off")
				Me.columnBankInfo1 = MyBase.Columns("BankInfo1")
				Me.columnBankInfo2 = MyBase.Columns("BankInfo2")
				Me.columnVersion = MyBase.Columns("Version")
				Me.columnZ1 = MyBase.Columns("Z1")
				Me.columnZ2 = MyBase.Columns("Z2")
				Me.columnZ3 = MyBase.Columns("Z3")
				Me.columnZ4 = MyBase.Columns("Z4")
				Me.columnZ5 = MyBase.Columns("Z5")
				Me.columnZ6 = MyBase.Columns("Z6")
				Me.columnZ7 = MyBase.Columns("Z7")
				Me.columnZ8 = MyBase.Columns("Z8")
				Me.columnZ9 = MyBase.Columns("Z9")
			End Sub

			' Token: 0x06000CE7 RID: 3303 RVA: 0x000B15AC File Offset: 0x000AF7AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnCompanyName = New DataColumn("CompanyName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCompanyName)
				Me.columnAddress = New DataColumn("Address", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAddress)
				Me.columnState = New DataColumn("State", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnState)
				Me.columnContactNo = New DataColumn("ContactNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnContactNo)
				Me.columnEmailID = New DataColumn("EmailID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnEmailID)
				Me.columnLogo = New DataColumn("Logo", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnLogo)
				Me.columnGSTIN = New DataColumn("GSTIN", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGSTIN)
				Me.columnCIN = New DataColumn("CIN", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCIN)
				Me.columnMaxWriteOffAmount = New DataColumn("MaxWriteOffAmount", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMaxWriteOffAmount)
				Me.columnPercentage_PerRs = New DataColumn("Percentage_PerRs", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPercentage_PerRs)
				Me.columnTerms1 = New DataColumn("Terms1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTerms1)
				Me.columnTerms2 = New DataColumn("Terms2", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTerms2)
				Me.columnTerms3 = New DataColumn("Terms3", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTerms3)
				Me.columnBillCode = New DataColumn("BillCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBillCode)
				Me.columnRound_Off = New DataColumn("Round_Off", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRound_Off)
				Me.columnBankInfo1 = New DataColumn("BankInfo1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBankInfo1)
				Me.columnBankInfo2 = New DataColumn("BankInfo2", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBankInfo2)
				Me.columnVersion = New DataColumn("Version", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnVersion)
				Me.columnZ1 = New DataColumn("Z1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ1)
				Me.columnZ2 = New DataColumn("Z2", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ2)
				Me.columnZ3 = New DataColumn("Z3", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ3)
				Me.columnZ4 = New DataColumn("Z4", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ4)
				Me.columnZ5 = New DataColumn("Z5", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ5)
				Me.columnZ6 = New DataColumn("Z6", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ6)
				Me.columnZ7 = New DataColumn("Z7", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ7)
				Me.columnZ8 = New DataColumn("Z8", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ8)
				Me.columnZ9 = New DataColumn("Z9", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ9)
			End Sub

			' Token: 0x06000CE8 RID: 3304 RVA: 0x000B1A94 File Offset: 0x000AFC94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewCompanyRow() As NewDataSet.CompanyRow
				Return CType(MyBase.NewRow(), NewDataSet.CompanyRow)
			End Function

			' Token: 0x06000CE9 RID: 3305 RVA: 0x000B1AB4 File Offset: 0x000AFCB4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New NewDataSet.CompanyRow(builder)
			End Function

			' Token: 0x06000CEA RID: 3306 RVA: 0x000B1ACC File Offset: 0x000AFCCC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(NewDataSet.CompanyRow)
			End Function

			' Token: 0x06000CEB RID: 3307 RVA: 0x000B1AE8 File Offset: 0x000AFCE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.CompanyRowChangedEvent IsNot Nothing
				If flag Then
					Dim companyRowChangedEvent As NewDataSet.CompanyRowChangeEventHandler = Me.CompanyRowChangedEvent
					If companyRowChangedEvent IsNot Nothing Then
						companyRowChangedEvent(Me, New NewDataSet.CompanyRowChangeEvent(CType(e.Row, NewDataSet.CompanyRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000CEC RID: 3308 RVA: 0x000B1B38 File Offset: 0x000AFD38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.CompanyRowChangingEvent IsNot Nothing
				If flag Then
					Dim companyRowChangingEvent As NewDataSet.CompanyRowChangeEventHandler = Me.CompanyRowChangingEvent
					If companyRowChangingEvent IsNot Nothing Then
						companyRowChangingEvent(Me, New NewDataSet.CompanyRowChangeEvent(CType(e.Row, NewDataSet.CompanyRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000CED RID: 3309 RVA: 0x000B1B88 File Offset: 0x000AFD88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.CompanyRowDeletedEvent IsNot Nothing
				If flag Then
					Dim companyRowDeletedEvent As NewDataSet.CompanyRowChangeEventHandler = Me.CompanyRowDeletedEvent
					If companyRowDeletedEvent IsNot Nothing Then
						companyRowDeletedEvent(Me, New NewDataSet.CompanyRowChangeEvent(CType(e.Row, NewDataSet.CompanyRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000CEE RID: 3310 RVA: 0x000B1BD8 File Offset: 0x000AFDD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.CompanyRowDeletingEvent IsNot Nothing
				If flag Then
					Dim companyRowDeletingEvent As NewDataSet.CompanyRowChangeEventHandler = Me.CompanyRowDeletingEvent
					If companyRowDeletingEvent IsNot Nothing Then
						companyRowDeletingEvent(Me, New NewDataSet.CompanyRowChangeEvent(CType(e.Row, NewDataSet.CompanyRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000CEF RID: 3311 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveCompanyRow(row As NewDataSet.CompanyRow)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x06000CF0 RID: 3312 RVA: 0x000B1C28 File Offset: 0x000AFE28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim newDataSet As NewDataSet = New NewDataSet()
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
				xmlSchemaAttribute.FixedValue = newDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "CompanyDataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = newDataSet.GetSchemaSerializable()
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

			' Token: 0x0400042E RID: 1070
			Private columnCompanyName As DataColumn

			' Token: 0x0400042F RID: 1071
			Private columnAddress As DataColumn

			' Token: 0x04000430 RID: 1072
			Private columnState As DataColumn

			' Token: 0x04000431 RID: 1073
			Private columnContactNo As DataColumn

			' Token: 0x04000432 RID: 1074
			Private columnEmailID As DataColumn

			' Token: 0x04000433 RID: 1075
			Private columnLogo As DataColumn

			' Token: 0x04000434 RID: 1076
			Private columnGSTIN As DataColumn

			' Token: 0x04000435 RID: 1077
			Private columnCIN As DataColumn

			' Token: 0x04000436 RID: 1078
			Private columnMaxWriteOffAmount As DataColumn

			' Token: 0x04000437 RID: 1079
			Private columnPercentage_PerRs As DataColumn

			' Token: 0x04000438 RID: 1080
			Private columnTerms1 As DataColumn

			' Token: 0x04000439 RID: 1081
			Private columnTerms2 As DataColumn

			' Token: 0x0400043A RID: 1082
			Private columnTerms3 As DataColumn

			' Token: 0x0400043B RID: 1083
			Private columnBillCode As DataColumn

			' Token: 0x0400043C RID: 1084
			Private columnRound_Off As DataColumn

			' Token: 0x0400043D RID: 1085
			Private columnBankInfo1 As DataColumn

			' Token: 0x0400043E RID: 1086
			Private columnBankInfo2 As DataColumn

			' Token: 0x0400043F RID: 1087
			Private columnVersion As DataColumn

			' Token: 0x04000440 RID: 1088
			Private columnZ1 As DataColumn

			' Token: 0x04000441 RID: 1089
			Private columnZ2 As DataColumn

			' Token: 0x04000442 RID: 1090
			Private columnZ3 As DataColumn

			' Token: 0x04000443 RID: 1091
			Private columnZ4 As DataColumn

			' Token: 0x04000444 RID: 1092
			Private columnZ5 As DataColumn

			' Token: 0x04000445 RID: 1093
			Private columnZ6 As DataColumn

			' Token: 0x04000446 RID: 1094
			Private columnZ7 As DataColumn

			' Token: 0x04000447 RID: 1095
			Private columnZ8 As DataColumn

			' Token: 0x04000448 RID: 1096
			Private columnZ9 As DataColumn
		End Class

		' Token: 0x0200004A RID: 74
		Public Class Table1Row
			Inherits DataRow

			' Token: 0x06000CF1 RID: 3313 RVA: 0x0000C6A0 File Offset: 0x0000A8A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableTable1 = CType(MyBase.Table, NewDataSet.Table1DataTable)
			End Sub

			' Token: 0x170005A6 RID: 1446
			' (get) Token: 0x06000CF2 RID: 3314 RVA: 0x000B1E7C File Offset: 0x000B007C
			' (set) Token: 0x06000CF3 RID: 3315 RVA: 0x0000C6BC File Offset: 0x0000A8BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Year As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableTable1.YearColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Year' in table 'Table1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableTable1.YearColumn) = value
				End Set
			End Property

			' Token: 0x170005A7 RID: 1447
			' (get) Token: 0x06000CF4 RID: 3316 RVA: 0x000B1ECC File Offset: 0x000B00CC
			' (set) Token: 0x06000CF5 RID: 3317 RVA: 0x0000C6D2 File Offset: 0x0000A8D2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GrandTotal As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableTable1.GrandTotalColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GrandTotal' in table 'Table1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableTable1.GrandTotalColumn) = value
				End Set
			End Property

			' Token: 0x06000CF6 RID: 3318 RVA: 0x000B1F1C File Offset: 0x000B011C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsYearNull() As Boolean
				Return MyBase.IsNull(Me.tableTable1.YearColumn)
			End Function

			' Token: 0x06000CF7 RID: 3319 RVA: 0x0000C6ED File Offset: 0x0000A8ED
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetYearNull()
				MyBase.Item(Me.tableTable1.YearColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000CF8 RID: 3320 RVA: 0x000B1F40 File Offset: 0x000B0140
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGrandTotalNull() As Boolean
				Return MyBase.IsNull(Me.tableTable1.GrandTotalColumn)
			End Function

			' Token: 0x06000CF9 RID: 3321 RVA: 0x0000C70C File Offset: 0x0000A90C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGrandTotalNull()
				MyBase.Item(Me.tableTable1.GrandTotalColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0400044D RID: 1101
			Private tableTable1 As NewDataSet.Table1DataTable
		End Class

		' Token: 0x0200004B RID: 75
		Public Class MeargeDataRow
			Inherits DataRow

			' Token: 0x06000CFA RID: 3322 RVA: 0x0000C72B File Offset: 0x0000A92B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableMeargeData = CType(MyBase.Table, NewDataSet.MeargeDataDataTable)
			End Sub

			' Token: 0x170005A8 RID: 1448
			' (get) Token: 0x06000CFB RID: 3323 RVA: 0x000B1F64 File Offset: 0x000B0164
			' (set) Token: 0x06000CFC RID: 3324 RVA: 0x0000C747 File Offset: 0x0000A947
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ByCash As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.ByCashColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ByCash' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.ByCashColumn) = value
				End Set
			End Property

			' Token: 0x170005A9 RID: 1449
			' (get) Token: 0x06000CFD RID: 3325 RVA: 0x000B1FB4 File Offset: 0x000B01B4
			' (set) Token: 0x06000CFE RID: 3326 RVA: 0x0000C75D File Offset: 0x0000A95D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ByReturn As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.ByReturnColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ByReturn' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.ByReturnColumn) = value
				End Set
			End Property

			' Token: 0x170005AA RID: 1450
			' (get) Token: 0x06000CFF RID: 3327 RVA: 0x000B2004 File Offset: 0x000B0204
			' (set) Token: 0x06000D00 RID: 3328 RVA: 0x0000C773 File Offset: 0x0000A973
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ByCredit_DebitCard As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.ByCredit_DebitCardColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ByCredit_DebitCard' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.ByCredit_DebitCardColumn) = value
				End Set
			End Property

			' Token: 0x170005AB RID: 1451
			' (get) Token: 0x06000D01 RID: 3329 RVA: 0x000B2054 File Offset: 0x000B0254
			' (set) Token: 0x06000D02 RID: 3330 RVA: 0x0000C789 File Offset: 0x0000A989
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PaymentMode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.PaymentModeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PaymentMode' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.PaymentModeColumn) = value
				End Set
			End Property

			' Token: 0x170005AC RID: 1452
			' (get) Token: 0x06000D03 RID: 3331 RVA: 0x000B20A4 File Offset: 0x000B02A4
			' (set) Token: 0x06000D04 RID: 3332 RVA: 0x0000C79F File Offset: 0x0000A99F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property _Operator As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.OperatorColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Operator' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.OperatorColumn) = value
				End Set
			End Property

			' Token: 0x170005AD RID: 1453
			' (get) Token: 0x06000D05 RID: 3333 RVA: 0x000B20F4 File Offset: 0x000B02F4
			' (set) Token: 0x06000D06 RID: 3334 RVA: 0x0000C7B5 File Offset: 0x0000A9B5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Inv_ID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.Inv_IDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Inv_ID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.Inv_IDColumn) = value
				End Set
			End Property

			' Token: 0x170005AE RID: 1454
			' (get) Token: 0x06000D07 RID: 3335 RVA: 0x000B2144 File Offset: 0x000B0344
			' (set) Token: 0x06000D08 RID: 3336 RVA: 0x0000C7CB File Offset: 0x0000A9CB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property InvoiceNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.InvoiceNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'InvoiceNo' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.InvoiceNoColumn) = value
				End Set
			End Property

			' Token: 0x170005AF RID: 1455
			' (get) Token: 0x06000D09 RID: 3337 RVA: 0x000B2194 File Offset: 0x000B0394
			' (set) Token: 0x06000D0A RID: 3338 RVA: 0x0000C7E1 File Offset: 0x0000A9E1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property InvoiceDate As DateTime
				Get
					Dim dateTime As DateTime
					Try
						dateTime = Conversions.ToDate(MyBase.Item(Me.tableMeargeData.InvoiceDateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'InvoiceDate' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return dateTime
				End Get
				Set(value As DateTime)
					MyBase.Item(Me.tableMeargeData.InvoiceDateColumn) = value
				End Set
			End Property

			' Token: 0x170005B0 RID: 1456
			' (get) Token: 0x06000D0B RID: 3339 RVA: 0x000B21E4 File Offset: 0x000B03E4
			' (set) Token: 0x06000D0C RID: 3340 RVA: 0x0000C7FC File Offset: 0x0000A9FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TaxType As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.TaxTypeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TaxType' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.TaxTypeColumn) = value
				End Set
			End Property

			' Token: 0x170005B1 RID: 1457
			' (get) Token: 0x06000D0D RID: 3341 RVA: 0x000B2234 File Offset: 0x000B0434
			' (set) Token: 0x06000D0E RID: 3342 RVA: 0x0000C812 File Offset: 0x0000AA12
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Customer_ID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.Customer_IDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Customer_ID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.Customer_IDColumn) = value
				End Set
			End Property

			' Token: 0x170005B2 RID: 1458
			' (get) Token: 0x06000D0F RID: 3343 RVA: 0x000B2284 File Offset: 0x000B0484
			' (set) Token: 0x06000D10 RID: 3344 RVA: 0x0000C828 File Offset: 0x0000AA28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SalesmanID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.SalesmanIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SalesmanID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.SalesmanIDColumn) = value
				End Set
			End Property

			' Token: 0x170005B3 RID: 1459
			' (get) Token: 0x06000D11 RID: 3345 RVA: 0x000B22D4 File Offset: 0x000B04D4
			' (set) Token: 0x06000D12 RID: 3346 RVA: 0x0000C83E File Offset: 0x0000AA3E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SubTotal As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.SubTotalColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SubTotal' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.SubTotalColumn) = value
				End Set
			End Property

			' Token: 0x170005B4 RID: 1460
			' (get) Token: 0x06000D13 RID: 3347 RVA: 0x000B2324 File Offset: 0x000B0524
			' (set) Token: 0x06000D14 RID: 3348 RVA: 0x0000C854 File Offset: 0x0000AA54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.CGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGST' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.CGSTColumn) = value
				End Set
			End Property

			' Token: 0x170005B5 RID: 1461
			' (get) Token: 0x06000D15 RID: 3349 RVA: 0x000B2374 File Offset: 0x000B0574
			' (set) Token: 0x06000D16 RID: 3350 RVA: 0x0000C86A File Offset: 0x0000AA6A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.SGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGST' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.SGSTColumn) = value
				End Set
			End Property

			' Token: 0x170005B6 RID: 1462
			' (get) Token: 0x06000D17 RID: 3351 RVA: 0x000B23C4 File Offset: 0x000B05C4
			' (set) Token: 0x06000D18 RID: 3352 RVA: 0x0000C880 File Offset: 0x0000AA80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.IGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGST' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.IGSTColumn) = value
				End Set
			End Property

			' Token: 0x170005B7 RID: 1463
			' (get) Token: 0x06000D19 RID: 3353 RVA: 0x000B2414 File Offset: 0x000B0614
			' (set) Token: 0x06000D1A RID: 3354 RVA: 0x0000C896 File Offset: 0x0000AA96
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESS As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.CESSColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESS' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.CESSColumn) = value
				End Set
			End Property

			' Token: 0x170005B8 RID: 1464
			' (get) Token: 0x06000D1B RID: 3355 RVA: 0x000B2464 File Offset: 0x000B0664
			' (set) Token: 0x06000D1C RID: 3356 RVA: 0x0000C8AC File Offset: 0x0000AAAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GrandTotal As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableMeargeData.GrandTotalColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GrandTotal' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableMeargeData.GrandTotalColumn) = value
				End Set
			End Property

			' Token: 0x170005B9 RID: 1465
			' (get) Token: 0x06000D1D RID: 3357 RVA: 0x000B24B4 File Offset: 0x000B06B4
			' (set) Token: 0x06000D1E RID: 3358 RVA: 0x0000C8C7 File Offset: 0x0000AAC7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TotalPaid As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.TotalPaidColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TotalPaid' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.TotalPaidColumn) = value
				End Set
			End Property

			' Token: 0x170005BA RID: 1466
			' (get) Token: 0x06000D1F RID: 3359 RVA: 0x000B2504 File Offset: 0x000B0704
			' (set) Token: 0x06000D20 RID: 3360 RVA: 0x0000C8DD File Offset: 0x0000AADD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Balance As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.BalanceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Balance' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.BalanceColumn) = value
				End Set
			End Property

			' Token: 0x170005BB RID: 1467
			' (get) Token: 0x06000D21 RID: 3361 RVA: 0x000B2554 File Offset: 0x000B0754
			' (set) Token: 0x06000D22 RID: 3362 RVA: 0x0000C8F3 File Offset: 0x0000AAF3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property FreightCharges As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.FreightChargesColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'FreightCharges' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.FreightChargesColumn) = value
				End Set
			End Property

			' Token: 0x170005BC RID: 1468
			' (get) Token: 0x06000D23 RID: 3363 RVA: 0x000B25A4 File Offset: 0x000B07A4
			' (set) Token: 0x06000D24 RID: 3364 RVA: 0x0000C909 File Offset: 0x0000AB09
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property OtherCharges As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.OtherChargesColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'OtherCharges' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.OtherChargesColumn) = value
				End Set
			End Property

			' Token: 0x170005BD RID: 1469
			' (get) Token: 0x06000D25 RID: 3365 RVA: 0x000B25F4 File Offset: 0x000B07F4
			' (set) Token: 0x06000D26 RID: 3366 RVA: 0x0000C91F File Offset: 0x0000AB1F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Total As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.TotalColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Total' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.TotalColumn) = value
				End Set
			End Property

			' Token: 0x170005BE RID: 1470
			' (get) Token: 0x06000D27 RID: 3367 RVA: 0x000B2644 File Offset: 0x000B0844
			' (set) Token: 0x06000D28 RID: 3368 RVA: 0x0000C935 File Offset: 0x0000AB35
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property RoundOff As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.RoundOffColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'RoundOff' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.RoundOffColumn) = value
				End Set
			End Property

			' Token: 0x170005BF RID: 1471
			' (get) Token: 0x06000D29 RID: 3369 RVA: 0x000B2694 File Offset: 0x000B0894
			' (set) Token: 0x06000D2A RID: 3370 RVA: 0x0000C94B File Offset: 0x0000AB4B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Remarks As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.RemarksColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Remarks' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.RemarksColumn) = value
				End Set
			End Property

			' Token: 0x170005C0 RID: 1472
			' (get) Token: 0x06000D2B RID: 3371 RVA: 0x000B26E4 File Offset: 0x000B08E4
			' (set) Token: 0x06000D2C RID: 3372 RVA: 0x0000C961 File Offset: 0x0000AB61
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IPo_ID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.IPo_IDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IPo_ID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.IPo_IDColumn) = value
				End Set
			End Property

			' Token: 0x170005C1 RID: 1473
			' (get) Token: 0x06000D2D RID: 3373 RVA: 0x000B2734 File Offset: 0x000B0934
			' (set) Token: 0x06000D2E RID: 3374 RVA: 0x0000C977 File Offset: 0x0000AB77
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property InvoiceID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.InvoiceIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'InvoiceID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.InvoiceIDColumn) = value
				End Set
			End Property

			' Token: 0x170005C2 RID: 1474
			' (get) Token: 0x06000D2F RID: 3375 RVA: 0x000B2784 File Offset: 0x000B0984
			' (set) Token: 0x06000D30 RID: 3376 RVA: 0x0000C98D File Offset: 0x0000AB8D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.ProductIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.ProductIDColumn) = value
				End Set
			End Property

			' Token: 0x170005C3 RID: 1475
			' (get) Token: 0x06000D31 RID: 3377 RVA: 0x000B27D4 File Offset: 0x000B09D4
			' (set) Token: 0x06000D32 RID: 3378 RVA: 0x0000C9A3 File Offset: 0x0000ABA3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Barcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.BarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Barcode' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.BarcodeColumn) = value
				End Set
			End Property

			' Token: 0x170005C4 RID: 1476
			' (get) Token: 0x06000D33 RID: 3379 RVA: 0x000B2824 File Offset: 0x000B0A24
			' (set) Token: 0x06000D34 RID: 3380 RVA: 0x0000C9B9 File Offset: 0x0000ABB9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SalesRate As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.SalesRateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SalesRate' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.SalesRateColumn) = value
				End Set
			End Property

			' Token: 0x170005C5 RID: 1477
			' (get) Token: 0x06000D35 RID: 3381 RVA: 0x000B2874 File Offset: 0x000B0A74
			' (set) Token: 0x06000D36 RID: 3382 RVA: 0x0000C9D4 File Offset: 0x0000ABD4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Qty As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.QtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Qty' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.QtyColumn) = value
				End Set
			End Property

			' Token: 0x170005C6 RID: 1478
			' (get) Token: 0x06000D37 RID: 3383 RVA: 0x000B28C4 File Offset: 0x000B0AC4
			' (set) Token: 0x06000D38 RID: 3384 RVA: 0x0000C9EF File Offset: 0x0000ABEF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property DiscountPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.DiscountPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'DiscountPer' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.DiscountPerColumn) = value
				End Set
			End Property

			' Token: 0x170005C7 RID: 1479
			' (get) Token: 0x06000D39 RID: 3385 RVA: 0x000B2914 File Offset: 0x000B0B14
			' (set) Token: 0x06000D3A RID: 3386 RVA: 0x0000CA0A File Offset: 0x0000AC0A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Discount As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableMeargeData.DiscountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Discount' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableMeargeData.DiscountColumn) = value
				End Set
			End Property

			' Token: 0x170005C8 RID: 1480
			' (get) Token: 0x06000D3B RID: 3387 RVA: 0x000B2964 File Offset: 0x000B0B64
			' (set) Token: 0x06000D3C RID: 3388 RVA: 0x0000CA25 File Offset: 0x0000AC25
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGSTPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.CGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGSTPer' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.CGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x170005C9 RID: 1481
			' (get) Token: 0x06000D3D RID: 3389 RVA: 0x000B29B4 File Offset: 0x000B0BB4
			' (set) Token: 0x06000D3E RID: 3390 RVA: 0x0000CA40 File Offset: 0x0000AC40
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGSTAmt As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.CGSTAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGSTAmt' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.CGSTAmtColumn) = value
				End Set
			End Property

			' Token: 0x170005CA RID: 1482
			' (get) Token: 0x06000D3F RID: 3391 RVA: 0x000B2A04 File Offset: 0x000B0C04
			' (set) Token: 0x06000D40 RID: 3392 RVA: 0x0000CA5B File Offset: 0x0000AC5B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGSTPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.SGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGSTPer' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.SGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x170005CB RID: 1483
			' (get) Token: 0x06000D41 RID: 3393 RVA: 0x000B2A54 File Offset: 0x000B0C54
			' (set) Token: 0x06000D42 RID: 3394 RVA: 0x0000CA76 File Offset: 0x0000AC76
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGSTAmt As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.SGSTAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGSTAmt' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.SGSTAmtColumn) = value
				End Set
			End Property

			' Token: 0x170005CC RID: 1484
			' (get) Token: 0x06000D43 RID: 3395 RVA: 0x000B2AA4 File Offset: 0x000B0CA4
			' (set) Token: 0x06000D44 RID: 3396 RVA: 0x0000CA91 File Offset: 0x0000AC91
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGSTPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.IGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGSTPer' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.IGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x170005CD RID: 1485
			' (get) Token: 0x06000D45 RID: 3397 RVA: 0x000B2AF4 File Offset: 0x000B0CF4
			' (set) Token: 0x06000D46 RID: 3398 RVA: 0x0000CAAC File Offset: 0x0000ACAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGSTAmt As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.IGSTAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGSTAmt' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.IGSTAmtColumn) = value
				End Set
			End Property

			' Token: 0x170005CE RID: 1486
			' (get) Token: 0x06000D47 RID: 3399 RVA: 0x000B2B44 File Offset: 0x000B0D44
			' (set) Token: 0x06000D48 RID: 3400 RVA: 0x0000CAC7 File Offset: 0x0000ACC7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESSPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.CESSPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESSPer' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.CESSPerColumn) = value
				End Set
			End Property

			' Token: 0x170005CF RID: 1487
			' (get) Token: 0x06000D49 RID: 3401 RVA: 0x000B2B94 File Offset: 0x000B0D94
			' (set) Token: 0x06000D4A RID: 3402 RVA: 0x0000CAE2 File Offset: 0x0000ACE2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESSAmt As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.CESSAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESSAmt' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.CESSAmtColumn) = value
				End Set
			End Property

			' Token: 0x170005D0 RID: 1488
			' (get) Token: 0x06000D4B RID: 3403 RVA: 0x000B2BE4 File Offset: 0x000B0DE4
			' (set) Token: 0x06000D4C RID: 3404 RVA: 0x0000CAFD File Offset: 0x0000ACFD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TotalAmount As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.TotalAmountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TotalAmount' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.TotalAmountColumn) = value
				End Set
			End Property

			' Token: 0x170005D1 RID: 1489
			' (get) Token: 0x06000D4D RID: 3405 RVA: 0x000B2C34 File Offset: 0x000B0E34
			' (set) Token: 0x06000D4E RID: 3406 RVA: 0x0000CB18 File Offset: 0x0000AD18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PurchaseRate As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.PurchaseRateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PurchaseRate' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.PurchaseRateColumn) = value
				End Set
			End Property

			' Token: 0x170005D2 RID: 1490
			' (get) Token: 0x06000D4F RID: 3407 RVA: 0x000B2C84 File Offset: 0x000B0E84
			' (set) Token: 0x06000D50 RID: 3408 RVA: 0x0000CB33 File Offset: 0x0000AD33
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Margin As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.MarginColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Margin' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.MarginColumn) = value
				End Set
			End Property

			' Token: 0x170005D3 RID: 1491
			' (get) Token: 0x06000D51 RID: 3409 RVA: 0x000B2CD4 File Offset: 0x000B0ED4
			' (set) Token: 0x06000D52 RID: 3410 RVA: 0x0000CB4E File Offset: 0x0000AD4E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.PIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.PIDColumn) = value
				End Set
			End Property

			' Token: 0x170005D4 RID: 1492
			' (get) Token: 0x06000D53 RID: 3411 RVA: 0x000B2D24 File Offset: 0x000B0F24
			' (set) Token: 0x06000D54 RID: 3412 RVA: 0x0000CB64 File Offset: 0x0000AD64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.ProductCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductCode' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.ProductCodeColumn) = value
				End Set
			End Property

			' Token: 0x170005D5 RID: 1493
			' (get) Token: 0x06000D55 RID: 3413 RVA: 0x000B2D74 File Offset: 0x000B0F74
			' (set) Token: 0x06000D56 RID: 3414 RVA: 0x0000CB7A File Offset: 0x0000AD7A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.ProductNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductName' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.ProductNameColumn) = value
				End Set
			End Property

			' Token: 0x170005D6 RID: 1494
			' (get) Token: 0x06000D57 RID: 3415 RVA: 0x000B2DC4 File Offset: 0x000B0FC4
			' (set) Token: 0x06000D58 RID: 3416 RVA: 0x0000CB90 File Offset: 0x0000AD90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SubCategoryID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.SubCategoryIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SubCategoryID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.SubCategoryIDColumn) = value
				End Set
			End Property

			' Token: 0x170005D7 RID: 1495
			' (get) Token: 0x06000D59 RID: 3417 RVA: 0x000B2E14 File Offset: 0x000B1014
			' (set) Token: 0x06000D5A RID: 3418 RVA: 0x0000CBA6 File Offset: 0x0000ADA6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property HSNCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.HSNCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'HSNCode' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.HSNCodeColumn) = value
				End Set
			End Property

			' Token: 0x170005D8 RID: 1496
			' (get) Token: 0x06000D5B RID: 3419 RVA: 0x000B2E64 File Offset: 0x000B1064
			' (set) Token: 0x06000D5C RID: 3420 RVA: 0x0000CBBC File Offset: 0x0000ADBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PartNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.PartNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PartNo' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.PartNoColumn) = value
				End Set
			End Property

			' Token: 0x170005D9 RID: 1497
			' (get) Token: 0x06000D5D RID: 3421 RVA: 0x000B2EB4 File Offset: 0x000B10B4
			' (set) Token: 0x06000D5E RID: 3422 RVA: 0x0000CBD2 File Offset: 0x0000ADD2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Description As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.DescriptionColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Description' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.DescriptionColumn) = value
				End Set
			End Property

			' Token: 0x170005DA RID: 1498
			' (get) Token: 0x06000D5F RID: 3423 RVA: 0x000B2F04 File Offset: 0x000B1104
			' (set) Token: 0x06000D60 RID: 3424 RVA: 0x0000CBE8 File Offset: 0x0000ADE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CostPrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.CostPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CostPrice' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.CostPriceColumn) = value
				End Set
			End Property

			' Token: 0x170005DB RID: 1499
			' (get) Token: 0x06000D61 RID: 3425 RVA: 0x000B2F54 File Offset: 0x000B1154
			' (set) Token: 0x06000D62 RID: 3426 RVA: 0x0000CC03 File Offset: 0x0000AE03
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SellingPrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.SellingPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SellingPrice' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.SellingPriceColumn) = value
				End Set
			End Property

			' Token: 0x170005DC RID: 1500
			' (get) Token: 0x06000D63 RID: 3427 RVA: 0x000B2FA4 File Offset: 0x000B11A4
			' (set) Token: 0x06000D64 RID: 3428 RVA: 0x0000CC1E File Offset: 0x0000AE1E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property DiscountP As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.DiscountPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'DiscountP' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.DiscountPColumn) = value
				End Set
			End Property

			' Token: 0x170005DD RID: 1501
			' (get) Token: 0x06000D65 RID: 3429 RVA: 0x000B2FF4 File Offset: 0x000B11F4
			' (set) Token: 0x06000D66 RID: 3430 RVA: 0x0000CC39 File Offset: 0x0000AE39
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGSTP As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.CGSTPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGSTP' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.CGSTPColumn) = value
				End Set
			End Property

			' Token: 0x170005DE RID: 1502
			' (get) Token: 0x06000D67 RID: 3431 RVA: 0x000B3044 File Offset: 0x000B1244
			' (set) Token: 0x06000D68 RID: 3432 RVA: 0x0000CC54 File Offset: 0x0000AE54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGSTP As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.SGSTPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGSTP' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.SGSTPColumn) = value
				End Set
			End Property

			' Token: 0x170005DF RID: 1503
			' (get) Token: 0x06000D69 RID: 3433 RVA: 0x000B3094 File Offset: 0x000B1294
			' (set) Token: 0x06000D6A RID: 3434 RVA: 0x0000CC6F File Offset: 0x0000AE6F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESSP As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.CESSPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESSP' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.CESSPColumn) = value
				End Set
			End Property

			' Token: 0x170005E0 RID: 1504
			' (get) Token: 0x06000D6B RID: 3435 RVA: 0x000B30E4 File Offset: 0x000B12E4
			' (set) Token: 0x06000D6C RID: 3436 RVA: 0x0000CC8A File Offset: 0x0000AE8A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property BarcodeP As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.BarcodePColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'BarcodeP' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.BarcodePColumn) = value
				End Set
			End Property

			' Token: 0x170005E1 RID: 1505
			' (get) Token: 0x06000D6D RID: 3437 RVA: 0x000B3134 File Offset: 0x000B1334
			' (set) Token: 0x06000D6E RID: 3438 RVA: 0x0000CCA0 File Offset: 0x0000AEA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ReorderPoint As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.ReorderPointColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ReorderPoint' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.ReorderPointColumn) = value
				End Set
			End Property

			' Token: 0x170005E2 RID: 1506
			' (get) Token: 0x06000D6F RID: 3439 RVA: 0x000B3184 File Offset: 0x000B1384
			' (set) Token: 0x06000D70 RID: 3440 RVA: 0x0000CCB6 File Offset: 0x0000AEB6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property OpeningStock As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.OpeningStockColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'OpeningStock' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.OpeningStockColumn) = value
				End Set
			End Property

			' Token: 0x170005E3 RID: 1507
			' (get) Token: 0x06000D71 RID: 3441 RVA: 0x000B31D4 File Offset: 0x000B13D4
			' (set) Token: 0x06000D72 RID: 3442 RVA: 0x0000CCCC File Offset: 0x0000AECC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PurchaseUnit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.PurchaseUnitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PurchaseUnit' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.PurchaseUnitColumn) = value
				End Set
			End Property

			' Token: 0x170005E4 RID: 1508
			' (get) Token: 0x06000D73 RID: 3443 RVA: 0x000B3224 File Offset: 0x000B1424
			' (set) Token: 0x06000D74 RID: 3444 RVA: 0x0000CCE2 File Offset: 0x0000AEE2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SalesUnit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.SalesUnitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SalesUnit' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.SalesUnitColumn) = value
				End Set
			End Property

			' Token: 0x170005E5 RID: 1509
			' (get) Token: 0x06000D75 RID: 3445 RVA: 0x000B3274 File Offset: 0x000B1474
			' (set) Token: 0x06000D76 RID: 3446 RVA: 0x0000CCF8 File Offset: 0x0000AEF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.IDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.IDColumn) = value
				End Set
			End Property

			' Token: 0x170005E6 RID: 1510
			' (get) Token: 0x06000D77 RID: 3447 RVA: 0x000B32C4 File Offset: 0x000B14C4
			' (set) Token: 0x06000D78 RID: 3448 RVA: 0x0000CD0E File Offset: 0x0000AF0E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CustomerID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.CustomerIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CustomerID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.CustomerIDColumn) = value
				End Set
			End Property

			' Token: 0x170005E7 RID: 1511
			' (get) Token: 0x06000D79 RID: 3449 RVA: 0x000B3314 File Offset: 0x000B1514
			' (set) Token: 0x06000D7A RID: 3450 RVA: 0x0000CD24 File Offset: 0x0000AF24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Name As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.NameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Name' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.NameColumn) = value
				End Set
			End Property

			' Token: 0x170005E8 RID: 1512
			' (get) Token: 0x06000D7B RID: 3451 RVA: 0x000B3364 File Offset: 0x000B1564
			' (set) Token: 0x06000D7C RID: 3452 RVA: 0x0000CD3A File Offset: 0x0000AF3A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Address As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AddressColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Address' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AddressColumn) = value
				End Set
			End Property

			' Token: 0x170005E9 RID: 1513
			' (get) Token: 0x06000D7D RID: 3453 RVA: 0x000B33B4 File Offset: 0x000B15B4
			' (set) Token: 0x06000D7E RID: 3454 RVA: 0x0000CD50 File Offset: 0x0000AF50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GSTIN As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.GSTINColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GSTIN' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.GSTINColumn) = value
				End Set
			End Property

			' Token: 0x170005EA RID: 1514
			' (get) Token: 0x06000D7F RID: 3455 RVA: 0x000B3404 File Offset: 0x000B1604
			' (set) Token: 0x06000D80 RID: 3456 RVA: 0x0000CD66 File Offset: 0x0000AF66
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property State As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.StateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'State' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.StateColumn) = value
				End Set
			End Property

			' Token: 0x170005EB RID: 1515
			' (get) Token: 0x06000D81 RID: 3457 RVA: 0x000B3454 File Offset: 0x000B1654
			' (set) Token: 0x06000D82 RID: 3458 RVA: 0x0000CD7C File Offset: 0x0000AF7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ZipCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.ZipCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ZipCode' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.ZipCodeColumn) = value
				End Set
			End Property

			' Token: 0x170005EC RID: 1516
			' (get) Token: 0x06000D83 RID: 3459 RVA: 0x000B34A4 File Offset: 0x000B16A4
			' (set) Token: 0x06000D84 RID: 3460 RVA: 0x0000CD92 File Offset: 0x0000AF92
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ContactNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.ContactNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ContactNo' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.ContactNoColumn) = value
				End Set
			End Property

			' Token: 0x170005ED RID: 1517
			' (get) Token: 0x06000D85 RID: 3461 RVA: 0x000B34F4 File Offset: 0x000B16F4
			' (set) Token: 0x06000D86 RID: 3462 RVA: 0x0000CDA8 File Offset: 0x0000AFA8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property EmailID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.EmailIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'EmailID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.EmailIDColumn) = value
				End Set
			End Property

			' Token: 0x170005EE RID: 1518
			' (get) Token: 0x06000D87 RID: 3463 RVA: 0x000B3544 File Offset: 0x000B1744
			' (set) Token: 0x06000D88 RID: 3464 RVA: 0x0000CDBE File Offset: 0x0000AFBE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property RemarksC As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.RemarksCColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'RemarksC' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.RemarksCColumn) = value
				End Set
			End Property

			' Token: 0x170005EF RID: 1519
			' (get) Token: 0x06000D89 RID: 3465 RVA: 0x000B3594 File Offset: 0x000B1794
			' (set) Token: 0x06000D8A RID: 3466 RVA: 0x0000CDD4 File Offset: 0x0000AFD4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AccountNumber As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AccountNumberColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AccountNumber' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AccountNumberColumn) = value
				End Set
			End Property

			' Token: 0x170005F0 RID: 1520
			' (get) Token: 0x06000D8B RID: 3467 RVA: 0x000B35E4 File Offset: 0x000B17E4
			' (set) Token: 0x06000D8C RID: 3468 RVA: 0x0000CDEA File Offset: 0x0000AFEA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AccountName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AccountNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AccountName' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AccountNameColumn) = value
				End Set
			End Property

			' Token: 0x170005F1 RID: 1521
			' (get) Token: 0x06000D8D RID: 3469 RVA: 0x000B3634 File Offset: 0x000B1834
			' (set) Token: 0x06000D8E RID: 3470 RVA: 0x0000CE00 File Offset: 0x0000B000
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Bank As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.BankColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Bank' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.BankColumn) = value
				End Set
			End Property

			' Token: 0x170005F2 RID: 1522
			' (get) Token: 0x06000D8F RID: 3471 RVA: 0x000B3684 File Offset: 0x000B1884
			' (set) Token: 0x06000D90 RID: 3472 RVA: 0x0000CE16 File Offset: 0x0000B016
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Branch As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.BranchColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Branch' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.BranchColumn) = value
				End Set
			End Property

			' Token: 0x170005F3 RID: 1523
			' (get) Token: 0x06000D91 RID: 3473 RVA: 0x000B36D4 File Offset: 0x000B18D4
			' (set) Token: 0x06000D92 RID: 3474 RVA: 0x0000CE2C File Offset: 0x0000B02C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IFSCCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.IFSCCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IFSCCode' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.IFSCCodeColumn) = value
				End Set
			End Property

			' Token: 0x170005F4 RID: 1524
			' (get) Token: 0x06000D93 RID: 3475 RVA: 0x000B3724 File Offset: 0x000B1924
			' (set) Token: 0x06000D94 RID: 3476 RVA: 0x0000CE42 File Offset: 0x0000B042
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PAN As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.PANColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PAN' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.PANColumn) = value
				End Set
			End Property

			' Token: 0x170005F5 RID: 1525
			' (get) Token: 0x06000D95 RID: 3477 RVA: 0x000B3774 File Offset: 0x000B1974
			' (set) Token: 0x06000D96 RID: 3478 RVA: 0x0000CE58 File Offset: 0x0000B058
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CIN As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.CINColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CIN' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.CINColumn) = value
				End Set
			End Property

			' Token: 0x170005F6 RID: 1526
			' (get) Token: 0x06000D97 RID: 3479 RVA: 0x000B37C4 File Offset: 0x000B19C4
			' (set) Token: 0x06000D98 RID: 3480 RVA: 0x0000CE6E File Offset: 0x0000B06E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property WriteOffAmount As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.WriteOffAmountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'WriteOffAmount' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.WriteOffAmountColumn) = value
				End Set
			End Property

			' Token: 0x170005F7 RID: 1527
			' (get) Token: 0x06000D99 RID: 3481 RVA: 0x000B3814 File Offset: 0x000B1A14
			' (set) Token: 0x06000D9A RID: 3482 RVA: 0x0000CE89 File Offset: 0x0000B089
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CreditBalance As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.CreditBalanceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CreditBalance' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.CreditBalanceColumn) = value
				End Set
			End Property

			' Token: 0x170005F8 RID: 1528
			' (get) Token: 0x06000D9B RID: 3483 RVA: 0x000B3864 File Offset: 0x000B1A64
			' (set) Token: 0x06000D9C RID: 3484 RVA: 0x0000CEA4 File Offset: 0x0000B0A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Paytm As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.PaytmColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Paytm' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.PaytmColumn) = value
				End Set
			End Property

			' Token: 0x170005F9 RID: 1529
			' (get) Token: 0x06000D9D RID: 3485 RVA: 0x000B38B4 File Offset: 0x000B1AB4
			' (set) Token: 0x06000D9E RID: 3486 RVA: 0x0000CEBF File Offset: 0x0000B0BF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Gpay As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.GpayColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Gpay' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.GpayColumn) = value
				End Set
			End Property

			' Token: 0x170005FA RID: 1530
			' (get) Token: 0x06000D9F RID: 3487 RVA: 0x000B3904 File Offset: 0x000B1B04
			' (set) Token: 0x06000DA0 RID: 3488 RVA: 0x0000CEDA File Offset: 0x0000B0DA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PhonePay As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.PhonePayColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PhonePay' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.PhonePayColumn) = value
				End Set
			End Property

			' Token: 0x170005FB RID: 1531
			' (get) Token: 0x06000DA1 RID: 3489 RVA: 0x000B3954 File Offset: 0x000B1B54
			' (set) Token: 0x06000DA2 RID: 3490 RVA: 0x0000CEF5 File Offset: 0x0000B0F5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property OnlineOtherPay As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableMeargeData.OnlineOtherPayColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'OnlineOtherPay' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableMeargeData.OnlineOtherPayColumn) = value
				End Set
			End Property

			' Token: 0x170005FC RID: 1532
			' (get) Token: 0x06000DA3 RID: 3491 RVA: 0x000B39A4 File Offset: 0x000B1BA4
			' (set) Token: 0x06000DA4 RID: 3492 RVA: 0x0000CF10 File Offset: 0x0000B110
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property EMIENO As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.EMIENOColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'EMIENO' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.EMIENOColumn) = value
				End Set
			End Property

			' Token: 0x170005FD RID: 1533
			' (get) Token: 0x06000DA5 RID: 3493 RVA: 0x000B39F4 File Offset: 0x000B1BF4
			' (set) Token: 0x06000DA6 RID: 3494 RVA: 0x0000CF26 File Offset: 0x0000B126
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property EMIBARCODE As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.EMIBARCODEColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'EMIBARCODE' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.EMIBARCODEColumn) = value
				End Set
			End Property

			' Token: 0x170005FE RID: 1534
			' (get) Token: 0x06000DA7 RID: 3495 RVA: 0x000B3A44 File Offset: 0x000B1C44
			' (set) Token: 0x06000DA8 RID: 3496 RVA: 0x0000CF3C File Offset: 0x0000B13C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property EMIPID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.EMIPIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'EMIPID' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.EMIPIDColumn) = value
				End Set
			End Property

			' Token: 0x170005FF RID: 1535
			' (get) Token: 0x06000DA9 RID: 3497 RVA: 0x000B3A94 File Offset: 0x000B1C94
			' (set) Token: 0x06000DAA RID: 3498 RVA: 0x0000CF52 File Offset: 0x0000B152
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property EMIENO1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.EMIENO1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'EMIENO1' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.EMIENO1Column) = value
				End Set
			End Property

			' Token: 0x17000600 RID: 1536
			' (get) Token: 0x06000DAB RID: 3499 RVA: 0x000B3AE4 File Offset: 0x000B1CE4
			' (set) Token: 0x06000DAC RID: 3500 RVA: 0x0000CF68 File Offset: 0x0000B168
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MDate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.MDateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MDate' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.MDateColumn) = value
				End Set
			End Property

			' Token: 0x17000601 RID: 1537
			' (get) Token: 0x06000DAD RID: 3501 RVA: 0x000B3B34 File Offset: 0x000B1D34
			' (set) Token: 0x06000DAE RID: 3502 RVA: 0x0000CF7E File Offset: 0x0000B17E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property EDate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.EDateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'EDate' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.EDateColumn) = value
				End Set
			End Property

			' Token: 0x17000602 RID: 1538
			' (get) Token: 0x06000DAF RID: 3503 RVA: 0x000B3B84 File Offset: 0x000B1D84
			' (set) Token: 0x06000DB0 RID: 3504 RVA: 0x0000CF94 File Offset: 0x0000B194
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property POtherLanguage As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.POtherLanguageColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'POtherLanguage' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.POtherLanguageColumn) = value
				End Set
			End Property

			' Token: 0x17000603 RID: 1539
			' (get) Token: 0x06000DB1 RID: 3505 RVA: 0x000B3BD4 File Offset: 0x000B1DD4
			' (set) Token: 0x06000DB2 RID: 3506 RVA: 0x0000CFAA File Offset: 0x0000B1AA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AB1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AB1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AB1' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AB1Column) = value
				End Set
			End Property

			' Token: 0x17000604 RID: 1540
			' (get) Token: 0x06000DB3 RID: 3507 RVA: 0x000B3C24 File Offset: 0x000B1E24
			' (set) Token: 0x06000DB4 RID: 3508 RVA: 0x0000CFC0 File Offset: 0x0000B1C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AB2 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AB2Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AB2' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AB2Column) = value
				End Set
			End Property

			' Token: 0x17000605 RID: 1541
			' (get) Token: 0x06000DB5 RID: 3509 RVA: 0x000B3C74 File Offset: 0x000B1E74
			' (set) Token: 0x06000DB6 RID: 3510 RVA: 0x0000CFD6 File Offset: 0x0000B1D6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AB3 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AB3Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AB3' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AB3Column) = value
				End Set
			End Property

			' Token: 0x17000606 RID: 1542
			' (get) Token: 0x06000DB7 RID: 3511 RVA: 0x000B3CC4 File Offset: 0x000B1EC4
			' (set) Token: 0x06000DB8 RID: 3512 RVA: 0x0000CFEC File Offset: 0x0000B1EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AB4 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AB4Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AB4' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AB4Column) = value
				End Set
			End Property

			' Token: 0x17000607 RID: 1543
			' (get) Token: 0x06000DB9 RID: 3513 RVA: 0x000B3D14 File Offset: 0x000B1F14
			' (set) Token: 0x06000DBA RID: 3514 RVA: 0x0000D002 File Offset: 0x0000B202
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AB5 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AB5Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AB5' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AB5Column) = value
				End Set
			End Property

			' Token: 0x17000608 RID: 1544
			' (get) Token: 0x06000DBB RID: 3515 RVA: 0x000B3D64 File Offset: 0x000B1F64
			' (set) Token: 0x06000DBC RID: 3516 RVA: 0x0000D018 File Offset: 0x0000B218
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AB6 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AB6Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AB6' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AB6Column) = value
				End Set
			End Property

			' Token: 0x17000609 RID: 1545
			' (get) Token: 0x06000DBD RID: 3517 RVA: 0x000B3DB4 File Offset: 0x000B1FB4
			' (set) Token: 0x06000DBE RID: 3518 RVA: 0x0000D02E File Offset: 0x0000B22E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AB7 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AB7Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AB7' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AB7Column) = value
				End Set
			End Property

			' Token: 0x1700060A RID: 1546
			' (get) Token: 0x06000DBF RID: 3519 RVA: 0x000B3E04 File Offset: 0x000B2004
			' (set) Token: 0x06000DC0 RID: 3520 RVA: 0x0000D044 File Offset: 0x0000B244
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AB8 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AB8Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AB8' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AB8Column) = value
				End Set
			End Property

			' Token: 0x1700060B RID: 1547
			' (get) Token: 0x06000DC1 RID: 3521 RVA: 0x000B3E54 File Offset: 0x000B2054
			' (set) Token: 0x06000DC2 RID: 3522 RVA: 0x0000D05A File Offset: 0x0000B25A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AB9 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.AB9Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AB9' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.AB9Column) = value
				End Set
			End Property

			' Token: 0x1700060C RID: 1548
			' (get) Token: 0x06000DC3 RID: 3523 RVA: 0x000B3EA4 File Offset: 0x000B20A4
			' (set) Token: 0x06000DC4 RID: 3524 RVA: 0x0000D070 File Offset: 0x0000B270
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.X1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X1' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.X1Column) = value
				End Set
			End Property

			' Token: 0x1700060D RID: 1549
			' (get) Token: 0x06000DC5 RID: 3525 RVA: 0x000B3EF4 File Offset: 0x000B20F4
			' (set) Token: 0x06000DC6 RID: 3526 RVA: 0x0000D086 File Offset: 0x0000B286
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X2 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.X2Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X2' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.X2Column) = value
				End Set
			End Property

			' Token: 0x1700060E RID: 1550
			' (get) Token: 0x06000DC7 RID: 3527 RVA: 0x000B3F44 File Offset: 0x000B2144
			' (set) Token: 0x06000DC8 RID: 3528 RVA: 0x0000D09C File Offset: 0x0000B29C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X3 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.X3Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X3' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.X3Column) = value
				End Set
			End Property

			' Token: 0x1700060F RID: 1551
			' (get) Token: 0x06000DC9 RID: 3529 RVA: 0x000B3F94 File Offset: 0x000B2194
			' (set) Token: 0x06000DCA RID: 3530 RVA: 0x0000D0B2 File Offset: 0x0000B2B2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X4 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.X4Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X4' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.X4Column) = value
				End Set
			End Property

			' Token: 0x17000610 RID: 1552
			' (get) Token: 0x06000DCB RID: 3531 RVA: 0x000B3FE4 File Offset: 0x000B21E4
			' (set) Token: 0x06000DCC RID: 3532 RVA: 0x0000D0C8 File Offset: 0x0000B2C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X5 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.X5Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X5' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.X5Column) = value
				End Set
			End Property

			' Token: 0x17000611 RID: 1553
			' (get) Token: 0x06000DCD RID: 3533 RVA: 0x000B4034 File Offset: 0x000B2234
			' (set) Token: 0x06000DCE RID: 3534 RVA: 0x0000D0DE File Offset: 0x0000B2DE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X6 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.X6Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X6' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.X6Column) = value
				End Set
			End Property

			' Token: 0x17000612 RID: 1554
			' (get) Token: 0x06000DCF RID: 3535 RVA: 0x000B4084 File Offset: 0x000B2284
			' (set) Token: 0x06000DD0 RID: 3536 RVA: 0x0000D0F4 File Offset: 0x0000B2F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X7 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.X7Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X7' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.X7Column) = value
				End Set
			End Property

			' Token: 0x17000613 RID: 1555
			' (get) Token: 0x06000DD1 RID: 3537 RVA: 0x000B40D4 File Offset: 0x000B22D4
			' (set) Token: 0x06000DD2 RID: 3538 RVA: 0x0000D10A File Offset: 0x0000B30A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X8 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.X8Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X8' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.X8Column) = value
				End Set
			End Property

			' Token: 0x17000614 RID: 1556
			' (get) Token: 0x06000DD3 RID: 3539 RVA: 0x000B4124 File Offset: 0x000B2324
			' (set) Token: 0x06000DD4 RID: 3540 RVA: 0x0000D120 File Offset: 0x0000B320
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X9 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableMeargeData.X9Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X9' in table 'MeargeData' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableMeargeData.X9Column) = value
				End Set
			End Property

			' Token: 0x06000DD5 RID: 3541 RVA: 0x000B4174 File Offset: 0x000B2374
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsByCashNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.ByCashColumn)
			End Function

			' Token: 0x06000DD6 RID: 3542 RVA: 0x0000D136 File Offset: 0x0000B336
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetByCashNull()
				MyBase.Item(Me.tableMeargeData.ByCashColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DD7 RID: 3543 RVA: 0x000B4198 File Offset: 0x000B2398
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsByReturnNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.ByReturnColumn)
			End Function

			' Token: 0x06000DD8 RID: 3544 RVA: 0x0000D155 File Offset: 0x0000B355
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetByReturnNull()
				MyBase.Item(Me.tableMeargeData.ByReturnColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DD9 RID: 3545 RVA: 0x000B41BC File Offset: 0x000B23BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsByCredit_DebitCardNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.ByCredit_DebitCardColumn)
			End Function

			' Token: 0x06000DDA RID: 3546 RVA: 0x0000D174 File Offset: 0x0000B374
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetByCredit_DebitCardNull()
				MyBase.Item(Me.tableMeargeData.ByCredit_DebitCardColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DDB RID: 3547 RVA: 0x000B41E0 File Offset: 0x000B23E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPaymentModeNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.PaymentModeColumn)
			End Function

			' Token: 0x06000DDC RID: 3548 RVA: 0x0000D193 File Offset: 0x0000B393
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPaymentModeNull()
				MyBase.Item(Me.tableMeargeData.PaymentModeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DDD RID: 3549 RVA: 0x000B4204 File Offset: 0x000B2404
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function Is_OperatorNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.OperatorColumn)
			End Function

			' Token: 0x06000DDE RID: 3550 RVA: 0x0000D1B2 File Offset: 0x0000B3B2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub Set_OperatorNull()
				MyBase.Item(Me.tableMeargeData.OperatorColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DDF RID: 3551 RVA: 0x000B4228 File Offset: 0x000B2428
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsInv_IDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.Inv_IDColumn)
			End Function

			' Token: 0x06000DE0 RID: 3552 RVA: 0x0000D1D1 File Offset: 0x0000B3D1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetInv_IDNull()
				MyBase.Item(Me.tableMeargeData.Inv_IDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DE1 RID: 3553 RVA: 0x000B424C File Offset: 0x000B244C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsInvoiceNoNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.InvoiceNoColumn)
			End Function

			' Token: 0x06000DE2 RID: 3554 RVA: 0x0000D1F0 File Offset: 0x0000B3F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetInvoiceNoNull()
				MyBase.Item(Me.tableMeargeData.InvoiceNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DE3 RID: 3555 RVA: 0x000B4270 File Offset: 0x000B2470
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsInvoiceDateNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.InvoiceDateColumn)
			End Function

			' Token: 0x06000DE4 RID: 3556 RVA: 0x0000D20F File Offset: 0x0000B40F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetInvoiceDateNull()
				MyBase.Item(Me.tableMeargeData.InvoiceDateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DE5 RID: 3557 RVA: 0x000B4294 File Offset: 0x000B2494
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTaxTypeNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.TaxTypeColumn)
			End Function

			' Token: 0x06000DE6 RID: 3558 RVA: 0x0000D22E File Offset: 0x0000B42E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTaxTypeNull()
				MyBase.Item(Me.tableMeargeData.TaxTypeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DE7 RID: 3559 RVA: 0x000B42B8 File Offset: 0x000B24B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCustomer_IDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.Customer_IDColumn)
			End Function

			' Token: 0x06000DE8 RID: 3560 RVA: 0x0000D24D File Offset: 0x0000B44D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCustomer_IDNull()
				MyBase.Item(Me.tableMeargeData.Customer_IDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DE9 RID: 3561 RVA: 0x000B42DC File Offset: 0x000B24DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalesmanIDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SalesmanIDColumn)
			End Function

			' Token: 0x06000DEA RID: 3562 RVA: 0x0000D26C File Offset: 0x0000B46C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalesmanIDNull()
				MyBase.Item(Me.tableMeargeData.SalesmanIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DEB RID: 3563 RVA: 0x000B4300 File Offset: 0x000B2500
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSubTotalNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SubTotalColumn)
			End Function

			' Token: 0x06000DEC RID: 3564 RVA: 0x0000D28B File Offset: 0x0000B48B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSubTotalNull()
				MyBase.Item(Me.tableMeargeData.SubTotalColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DED RID: 3565 RVA: 0x000B4324 File Offset: 0x000B2524
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CGSTColumn)
			End Function

			' Token: 0x06000DEE RID: 3566 RVA: 0x0000D2AA File Offset: 0x0000B4AA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTNull()
				MyBase.Item(Me.tableMeargeData.CGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DEF RID: 3567 RVA: 0x000B4348 File Offset: 0x000B2548
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SGSTColumn)
			End Function

			' Token: 0x06000DF0 RID: 3568 RVA: 0x0000D2C9 File Offset: 0x0000B4C9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTNull()
				MyBase.Item(Me.tableMeargeData.SGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DF1 RID: 3569 RVA: 0x000B436C File Offset: 0x000B256C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.IGSTColumn)
			End Function

			' Token: 0x06000DF2 RID: 3570 RVA: 0x0000D2E8 File Offset: 0x0000B4E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTNull()
				MyBase.Item(Me.tableMeargeData.IGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DF3 RID: 3571 RVA: 0x000B4390 File Offset: 0x000B2590
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CESSColumn)
			End Function

			' Token: 0x06000DF4 RID: 3572 RVA: 0x0000D307 File Offset: 0x0000B507
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSNull()
				MyBase.Item(Me.tableMeargeData.CESSColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DF5 RID: 3573 RVA: 0x000B43B4 File Offset: 0x000B25B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGrandTotalNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.GrandTotalColumn)
			End Function

			' Token: 0x06000DF6 RID: 3574 RVA: 0x0000D326 File Offset: 0x0000B526
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGrandTotalNull()
				MyBase.Item(Me.tableMeargeData.GrandTotalColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DF7 RID: 3575 RVA: 0x000B43D8 File Offset: 0x000B25D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTotalPaidNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.TotalPaidColumn)
			End Function

			' Token: 0x06000DF8 RID: 3576 RVA: 0x0000D345 File Offset: 0x0000B545
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTotalPaidNull()
				MyBase.Item(Me.tableMeargeData.TotalPaidColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DF9 RID: 3577 RVA: 0x000B43FC File Offset: 0x000B25FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBalanceNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.BalanceColumn)
			End Function

			' Token: 0x06000DFA RID: 3578 RVA: 0x0000D364 File Offset: 0x0000B564
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBalanceNull()
				MyBase.Item(Me.tableMeargeData.BalanceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DFB RID: 3579 RVA: 0x000B4420 File Offset: 0x000B2620
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsFreightChargesNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.FreightChargesColumn)
			End Function

			' Token: 0x06000DFC RID: 3580 RVA: 0x0000D383 File Offset: 0x0000B583
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetFreightChargesNull()
				MyBase.Item(Me.tableMeargeData.FreightChargesColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DFD RID: 3581 RVA: 0x000B4444 File Offset: 0x000B2644
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsOtherChargesNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.OtherChargesColumn)
			End Function

			' Token: 0x06000DFE RID: 3582 RVA: 0x0000D3A2 File Offset: 0x0000B5A2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetOtherChargesNull()
				MyBase.Item(Me.tableMeargeData.OtherChargesColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000DFF RID: 3583 RVA: 0x000B4468 File Offset: 0x000B2668
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTotalNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.TotalColumn)
			End Function

			' Token: 0x06000E00 RID: 3584 RVA: 0x0000D3C1 File Offset: 0x0000B5C1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTotalNull()
				MyBase.Item(Me.tableMeargeData.TotalColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E01 RID: 3585 RVA: 0x000B448C File Offset: 0x000B268C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRoundOffNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.RoundOffColumn)
			End Function

			' Token: 0x06000E02 RID: 3586 RVA: 0x0000D3E0 File Offset: 0x0000B5E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRoundOffNull()
				MyBase.Item(Me.tableMeargeData.RoundOffColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E03 RID: 3587 RVA: 0x000B44B0 File Offset: 0x000B26B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRemarksNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.RemarksColumn)
			End Function

			' Token: 0x06000E04 RID: 3588 RVA: 0x0000D3FF File Offset: 0x0000B5FF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRemarksNull()
				MyBase.Item(Me.tableMeargeData.RemarksColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E05 RID: 3589 RVA: 0x000B44D4 File Offset: 0x000B26D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIPo_IDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.IPo_IDColumn)
			End Function

			' Token: 0x06000E06 RID: 3590 RVA: 0x0000D41E File Offset: 0x0000B61E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIPo_IDNull()
				MyBase.Item(Me.tableMeargeData.IPo_IDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E07 RID: 3591 RVA: 0x000B44F8 File Offset: 0x000B26F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsInvoiceIDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.InvoiceIDColumn)
			End Function

			' Token: 0x06000E08 RID: 3592 RVA: 0x0000D43D File Offset: 0x0000B63D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetInvoiceIDNull()
				MyBase.Item(Me.tableMeargeData.InvoiceIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E09 RID: 3593 RVA: 0x000B451C File Offset: 0x000B271C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductIDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.ProductIDColumn)
			End Function

			' Token: 0x06000E0A RID: 3594 RVA: 0x0000D45C File Offset: 0x0000B65C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductIDNull()
				MyBase.Item(Me.tableMeargeData.ProductIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E0B RID: 3595 RVA: 0x000B4540 File Offset: 0x000B2740
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.BarcodeColumn)
			End Function

			' Token: 0x06000E0C RID: 3596 RVA: 0x0000D47B File Offset: 0x0000B67B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableMeargeData.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E0D RID: 3597 RVA: 0x000B4564 File Offset: 0x000B2764
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalesRateNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SalesRateColumn)
			End Function

			' Token: 0x06000E0E RID: 3598 RVA: 0x0000D49A File Offset: 0x0000B69A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalesRateNull()
				MyBase.Item(Me.tableMeargeData.SalesRateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E0F RID: 3599 RVA: 0x000B4588 File Offset: 0x000B2788
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.QtyColumn)
			End Function

			' Token: 0x06000E10 RID: 3600 RVA: 0x0000D4B9 File Offset: 0x0000B6B9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQtyNull()
				MyBase.Item(Me.tableMeargeData.QtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E11 RID: 3601 RVA: 0x000B45AC File Offset: 0x000B27AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountPerNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.DiscountPerColumn)
			End Function

			' Token: 0x06000E12 RID: 3602 RVA: 0x0000D4D8 File Offset: 0x0000B6D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountPerNull()
				MyBase.Item(Me.tableMeargeData.DiscountPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E13 RID: 3603 RVA: 0x000B45D0 File Offset: 0x000B27D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.DiscountColumn)
			End Function

			' Token: 0x06000E14 RID: 3604 RVA: 0x0000D4F7 File Offset: 0x0000B6F7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountNull()
				MyBase.Item(Me.tableMeargeData.DiscountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E15 RID: 3605 RVA: 0x000B45F4 File Offset: 0x000B27F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CGSTPerColumn)
			End Function

			' Token: 0x06000E16 RID: 3606 RVA: 0x0000D516 File Offset: 0x0000B716
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTPerNull()
				MyBase.Item(Me.tableMeargeData.CGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E17 RID: 3607 RVA: 0x000B4618 File Offset: 0x000B2818
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CGSTAmtColumn)
			End Function

			' Token: 0x06000E18 RID: 3608 RVA: 0x0000D535 File Offset: 0x0000B735
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTAmtNull()
				MyBase.Item(Me.tableMeargeData.CGSTAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E19 RID: 3609 RVA: 0x000B463C File Offset: 0x000B283C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SGSTPerColumn)
			End Function

			' Token: 0x06000E1A RID: 3610 RVA: 0x0000D554 File Offset: 0x0000B754
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTPerNull()
				MyBase.Item(Me.tableMeargeData.SGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E1B RID: 3611 RVA: 0x000B4660 File Offset: 0x000B2860
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SGSTAmtColumn)
			End Function

			' Token: 0x06000E1C RID: 3612 RVA: 0x0000D573 File Offset: 0x0000B773
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTAmtNull()
				MyBase.Item(Me.tableMeargeData.SGSTAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E1D RID: 3613 RVA: 0x000B4684 File Offset: 0x000B2884
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.IGSTPerColumn)
			End Function

			' Token: 0x06000E1E RID: 3614 RVA: 0x0000D592 File Offset: 0x0000B792
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTPerNull()
				MyBase.Item(Me.tableMeargeData.IGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E1F RID: 3615 RVA: 0x000B46A8 File Offset: 0x000B28A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.IGSTAmtColumn)
			End Function

			' Token: 0x06000E20 RID: 3616 RVA: 0x0000D5B1 File Offset: 0x0000B7B1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTAmtNull()
				MyBase.Item(Me.tableMeargeData.IGSTAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E21 RID: 3617 RVA: 0x000B46CC File Offset: 0x000B28CC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSPerNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CESSPerColumn)
			End Function

			' Token: 0x06000E22 RID: 3618 RVA: 0x0000D5D0 File Offset: 0x0000B7D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSPerNull()
				MyBase.Item(Me.tableMeargeData.CESSPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E23 RID: 3619 RVA: 0x000B46F0 File Offset: 0x000B28F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CESSAmtColumn)
			End Function

			' Token: 0x06000E24 RID: 3620 RVA: 0x0000D5EF File Offset: 0x0000B7EF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSAmtNull()
				MyBase.Item(Me.tableMeargeData.CESSAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E25 RID: 3621 RVA: 0x000B4714 File Offset: 0x000B2914
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTotalAmountNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.TotalAmountColumn)
			End Function

			' Token: 0x06000E26 RID: 3622 RVA: 0x0000D60E File Offset: 0x0000B80E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTotalAmountNull()
				MyBase.Item(Me.tableMeargeData.TotalAmountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E27 RID: 3623 RVA: 0x000B4738 File Offset: 0x000B2938
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPurchaseRateNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.PurchaseRateColumn)
			End Function

			' Token: 0x06000E28 RID: 3624 RVA: 0x0000D62D File Offset: 0x0000B82D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPurchaseRateNull()
				MyBase.Item(Me.tableMeargeData.PurchaseRateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E29 RID: 3625 RVA: 0x000B475C File Offset: 0x000B295C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMarginNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.MarginColumn)
			End Function

			' Token: 0x06000E2A RID: 3626 RVA: 0x0000D64C File Offset: 0x0000B84C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMarginNull()
				MyBase.Item(Me.tableMeargeData.MarginColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E2B RID: 3627 RVA: 0x000B4780 File Offset: 0x000B2980
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPIDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.PIDColumn)
			End Function

			' Token: 0x06000E2C RID: 3628 RVA: 0x0000D66B File Offset: 0x0000B86B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPIDNull()
				MyBase.Item(Me.tableMeargeData.PIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E2D RID: 3629 RVA: 0x000B47A4 File Offset: 0x000B29A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.ProductCodeColumn)
			End Function

			' Token: 0x06000E2E RID: 3630 RVA: 0x0000D68A File Offset: 0x0000B88A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductCodeNull()
				MyBase.Item(Me.tableMeargeData.ProductCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E2F RID: 3631 RVA: 0x000B47C8 File Offset: 0x000B29C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductNameNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.ProductNameColumn)
			End Function

			' Token: 0x06000E30 RID: 3632 RVA: 0x0000D6A9 File Offset: 0x0000B8A9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductNameNull()
				MyBase.Item(Me.tableMeargeData.ProductNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E31 RID: 3633 RVA: 0x000B47EC File Offset: 0x000B29EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSubCategoryIDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SubCategoryIDColumn)
			End Function

			' Token: 0x06000E32 RID: 3634 RVA: 0x0000D6C8 File Offset: 0x0000B8C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSubCategoryIDNull()
				MyBase.Item(Me.tableMeargeData.SubCategoryIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E33 RID: 3635 RVA: 0x000B4810 File Offset: 0x000B2A10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.HSNCodeColumn)
			End Function

			' Token: 0x06000E34 RID: 3636 RVA: 0x0000D6E7 File Offset: 0x0000B8E7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCodeNull()
				MyBase.Item(Me.tableMeargeData.HSNCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E35 RID: 3637 RVA: 0x000B4834 File Offset: 0x000B2A34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPartNoNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.PartNoColumn)
			End Function

			' Token: 0x06000E36 RID: 3638 RVA: 0x0000D706 File Offset: 0x0000B906
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPartNoNull()
				MyBase.Item(Me.tableMeargeData.PartNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E37 RID: 3639 RVA: 0x000B4858 File Offset: 0x000B2A58
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDescriptionNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.DescriptionColumn)
			End Function

			' Token: 0x06000E38 RID: 3640 RVA: 0x0000D725 File Offset: 0x0000B925
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDescriptionNull()
				MyBase.Item(Me.tableMeargeData.DescriptionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E39 RID: 3641 RVA: 0x000B487C File Offset: 0x000B2A7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCostPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CostPriceColumn)
			End Function

			' Token: 0x06000E3A RID: 3642 RVA: 0x0000D744 File Offset: 0x0000B944
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCostPriceNull()
				MyBase.Item(Me.tableMeargeData.CostPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E3B RID: 3643 RVA: 0x000B48A0 File Offset: 0x000B2AA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSellingPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SellingPriceColumn)
			End Function

			' Token: 0x06000E3C RID: 3644 RVA: 0x0000D763 File Offset: 0x0000B963
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSellingPriceNull()
				MyBase.Item(Me.tableMeargeData.SellingPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E3D RID: 3645 RVA: 0x000B48C4 File Offset: 0x000B2AC4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountPNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.DiscountPColumn)
			End Function

			' Token: 0x06000E3E RID: 3646 RVA: 0x0000D782 File Offset: 0x0000B982
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountPNull()
				MyBase.Item(Me.tableMeargeData.DiscountPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E3F RID: 3647 RVA: 0x000B48E8 File Offset: 0x000B2AE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTPNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CGSTPColumn)
			End Function

			' Token: 0x06000E40 RID: 3648 RVA: 0x0000D7A1 File Offset: 0x0000B9A1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTPNull()
				MyBase.Item(Me.tableMeargeData.CGSTPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E41 RID: 3649 RVA: 0x000B490C File Offset: 0x000B2B0C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTPNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SGSTPColumn)
			End Function

			' Token: 0x06000E42 RID: 3650 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTPNull()
				MyBase.Item(Me.tableMeargeData.SGSTPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E43 RID: 3651 RVA: 0x000B4930 File Offset: 0x000B2B30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSPNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CESSPColumn)
			End Function

			' Token: 0x06000E44 RID: 3652 RVA: 0x0000D7DF File Offset: 0x0000B9DF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSPNull()
				MyBase.Item(Me.tableMeargeData.CESSPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E45 RID: 3653 RVA: 0x000B4954 File Offset: 0x000B2B54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodePNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.BarcodePColumn)
			End Function

			' Token: 0x06000E46 RID: 3654 RVA: 0x0000D7FE File Offset: 0x0000B9FE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodePNull()
				MyBase.Item(Me.tableMeargeData.BarcodePColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E47 RID: 3655 RVA: 0x000B4978 File Offset: 0x000B2B78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsReorderPointNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.ReorderPointColumn)
			End Function

			' Token: 0x06000E48 RID: 3656 RVA: 0x0000D81D File Offset: 0x0000BA1D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetReorderPointNull()
				MyBase.Item(Me.tableMeargeData.ReorderPointColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E49 RID: 3657 RVA: 0x000B499C File Offset: 0x000B2B9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsOpeningStockNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.OpeningStockColumn)
			End Function

			' Token: 0x06000E4A RID: 3658 RVA: 0x0000D83C File Offset: 0x0000BA3C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetOpeningStockNull()
				MyBase.Item(Me.tableMeargeData.OpeningStockColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E4B RID: 3659 RVA: 0x000B49C0 File Offset: 0x000B2BC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPurchaseUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.PurchaseUnitColumn)
			End Function

			' Token: 0x06000E4C RID: 3660 RVA: 0x0000D85B File Offset: 0x0000BA5B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPurchaseUnitNull()
				MyBase.Item(Me.tableMeargeData.PurchaseUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E4D RID: 3661 RVA: 0x000B49E4 File Offset: 0x000B2BE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalesUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.SalesUnitColumn)
			End Function

			' Token: 0x06000E4E RID: 3662 RVA: 0x0000D87A File Offset: 0x0000BA7A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalesUnitNull()
				MyBase.Item(Me.tableMeargeData.SalesUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E4F RID: 3663 RVA: 0x000B4A08 File Offset: 0x000B2C08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.IDColumn)
			End Function

			' Token: 0x06000E50 RID: 3664 RVA: 0x0000D899 File Offset: 0x0000BA99
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIDNull()
				MyBase.Item(Me.tableMeargeData.IDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E51 RID: 3665 RVA: 0x000B4A2C File Offset: 0x000B2C2C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCustomerIDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CustomerIDColumn)
			End Function

			' Token: 0x06000E52 RID: 3666 RVA: 0x0000D8B8 File Offset: 0x0000BAB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCustomerIDNull()
				MyBase.Item(Me.tableMeargeData.CustomerIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E53 RID: 3667 RVA: 0x000B4A50 File Offset: 0x000B2C50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsNameNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.NameColumn)
			End Function

			' Token: 0x06000E54 RID: 3668 RVA: 0x0000D8D7 File Offset: 0x0000BAD7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetNameNull()
				MyBase.Item(Me.tableMeargeData.NameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E55 RID: 3669 RVA: 0x000B4A74 File Offset: 0x000B2C74
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAddressNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AddressColumn)
			End Function

			' Token: 0x06000E56 RID: 3670 RVA: 0x0000D8F6 File Offset: 0x0000BAF6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAddressNull()
				MyBase.Item(Me.tableMeargeData.AddressColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E57 RID: 3671 RVA: 0x000B4A98 File Offset: 0x000B2C98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGSTINNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.GSTINColumn)
			End Function

			' Token: 0x06000E58 RID: 3672 RVA: 0x0000D915 File Offset: 0x0000BB15
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGSTINNull()
				MyBase.Item(Me.tableMeargeData.GSTINColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E59 RID: 3673 RVA: 0x000B4ABC File Offset: 0x000B2CBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsStateNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.StateColumn)
			End Function

			' Token: 0x06000E5A RID: 3674 RVA: 0x0000D934 File Offset: 0x0000BB34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetStateNull()
				MyBase.Item(Me.tableMeargeData.StateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E5B RID: 3675 RVA: 0x000B4AE0 File Offset: 0x000B2CE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZipCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.ZipCodeColumn)
			End Function

			' Token: 0x06000E5C RID: 3676 RVA: 0x0000D953 File Offset: 0x0000BB53
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZipCodeNull()
				MyBase.Item(Me.tableMeargeData.ZipCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E5D RID: 3677 RVA: 0x000B4B04 File Offset: 0x000B2D04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsContactNoNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.ContactNoColumn)
			End Function

			' Token: 0x06000E5E RID: 3678 RVA: 0x0000D972 File Offset: 0x0000BB72
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetContactNoNull()
				MyBase.Item(Me.tableMeargeData.ContactNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E5F RID: 3679 RVA: 0x000B4B28 File Offset: 0x000B2D28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsEmailIDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.EmailIDColumn)
			End Function

			' Token: 0x06000E60 RID: 3680 RVA: 0x0000D991 File Offset: 0x0000BB91
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetEmailIDNull()
				MyBase.Item(Me.tableMeargeData.EmailIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E61 RID: 3681 RVA: 0x000B4B4C File Offset: 0x000B2D4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRemarksCNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.RemarksCColumn)
			End Function

			' Token: 0x06000E62 RID: 3682 RVA: 0x0000D9B0 File Offset: 0x0000BBB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRemarksCNull()
				MyBase.Item(Me.tableMeargeData.RemarksCColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E63 RID: 3683 RVA: 0x000B4B70 File Offset: 0x000B2D70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAccountNumberNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AccountNumberColumn)
			End Function

			' Token: 0x06000E64 RID: 3684 RVA: 0x0000D9CF File Offset: 0x0000BBCF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAccountNumberNull()
				MyBase.Item(Me.tableMeargeData.AccountNumberColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E65 RID: 3685 RVA: 0x000B4B94 File Offset: 0x000B2D94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAccountNameNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AccountNameColumn)
			End Function

			' Token: 0x06000E66 RID: 3686 RVA: 0x0000D9EE File Offset: 0x0000BBEE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAccountNameNull()
				MyBase.Item(Me.tableMeargeData.AccountNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E67 RID: 3687 RVA: 0x000B4BB8 File Offset: 0x000B2DB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBankNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.BankColumn)
			End Function

			' Token: 0x06000E68 RID: 3688 RVA: 0x0000DA0D File Offset: 0x0000BC0D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBankNull()
				MyBase.Item(Me.tableMeargeData.BankColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E69 RID: 3689 RVA: 0x000B4BDC File Offset: 0x000B2DDC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBranchNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.BranchColumn)
			End Function

			' Token: 0x06000E6A RID: 3690 RVA: 0x0000DA2C File Offset: 0x0000BC2C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBranchNull()
				MyBase.Item(Me.tableMeargeData.BranchColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E6B RID: 3691 RVA: 0x000B4C00 File Offset: 0x000B2E00
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIFSCCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.IFSCCodeColumn)
			End Function

			' Token: 0x06000E6C RID: 3692 RVA: 0x0000DA4B File Offset: 0x0000BC4B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIFSCCodeNull()
				MyBase.Item(Me.tableMeargeData.IFSCCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E6D RID: 3693 RVA: 0x000B4C24 File Offset: 0x000B2E24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPANNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.PANColumn)
			End Function

			' Token: 0x06000E6E RID: 3694 RVA: 0x0000DA6A File Offset: 0x0000BC6A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPANNull()
				MyBase.Item(Me.tableMeargeData.PANColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E6F RID: 3695 RVA: 0x000B4C48 File Offset: 0x000B2E48
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCINNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CINColumn)
			End Function

			' Token: 0x06000E70 RID: 3696 RVA: 0x0000DA89 File Offset: 0x0000BC89
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCINNull()
				MyBase.Item(Me.tableMeargeData.CINColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E71 RID: 3697 RVA: 0x000B4C6C File Offset: 0x000B2E6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsWriteOffAmountNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.WriteOffAmountColumn)
			End Function

			' Token: 0x06000E72 RID: 3698 RVA: 0x0000DAA8 File Offset: 0x0000BCA8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetWriteOffAmountNull()
				MyBase.Item(Me.tableMeargeData.WriteOffAmountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E73 RID: 3699 RVA: 0x000B4C90 File Offset: 0x000B2E90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCreditBalanceNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.CreditBalanceColumn)
			End Function

			' Token: 0x06000E74 RID: 3700 RVA: 0x0000DAC7 File Offset: 0x0000BCC7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCreditBalanceNull()
				MyBase.Item(Me.tableMeargeData.CreditBalanceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E75 RID: 3701 RVA: 0x000B4CB4 File Offset: 0x000B2EB4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPaytmNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.PaytmColumn)
			End Function

			' Token: 0x06000E76 RID: 3702 RVA: 0x0000DAE6 File Offset: 0x0000BCE6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPaytmNull()
				MyBase.Item(Me.tableMeargeData.PaytmColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E77 RID: 3703 RVA: 0x000B4CD8 File Offset: 0x000B2ED8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGpayNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.GpayColumn)
			End Function

			' Token: 0x06000E78 RID: 3704 RVA: 0x0000DB05 File Offset: 0x0000BD05
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGpayNull()
				MyBase.Item(Me.tableMeargeData.GpayColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E79 RID: 3705 RVA: 0x000B4CFC File Offset: 0x000B2EFC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPhonePayNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.PhonePayColumn)
			End Function

			' Token: 0x06000E7A RID: 3706 RVA: 0x0000DB24 File Offset: 0x0000BD24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPhonePayNull()
				MyBase.Item(Me.tableMeargeData.PhonePayColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E7B RID: 3707 RVA: 0x000B4D20 File Offset: 0x000B2F20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsOnlineOtherPayNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.OnlineOtherPayColumn)
			End Function

			' Token: 0x06000E7C RID: 3708 RVA: 0x0000DB43 File Offset: 0x0000BD43
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetOnlineOtherPayNull()
				MyBase.Item(Me.tableMeargeData.OnlineOtherPayColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E7D RID: 3709 RVA: 0x000B4D44 File Offset: 0x000B2F44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsEMIENONull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.EMIENOColumn)
			End Function

			' Token: 0x06000E7E RID: 3710 RVA: 0x0000DB62 File Offset: 0x0000BD62
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetEMIENONull()
				MyBase.Item(Me.tableMeargeData.EMIENOColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E7F RID: 3711 RVA: 0x000B4D68 File Offset: 0x000B2F68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsEMIBARCODENull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.EMIBARCODEColumn)
			End Function

			' Token: 0x06000E80 RID: 3712 RVA: 0x0000DB81 File Offset: 0x0000BD81
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetEMIBARCODENull()
				MyBase.Item(Me.tableMeargeData.EMIBARCODEColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E81 RID: 3713 RVA: 0x000B4D8C File Offset: 0x000B2F8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsEMIPIDNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.EMIPIDColumn)
			End Function

			' Token: 0x06000E82 RID: 3714 RVA: 0x0000DBA0 File Offset: 0x0000BDA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetEMIPIDNull()
				MyBase.Item(Me.tableMeargeData.EMIPIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E83 RID: 3715 RVA: 0x000B4DB0 File Offset: 0x000B2FB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsEMIENO1Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.EMIENO1Column)
			End Function

			' Token: 0x06000E84 RID: 3716 RVA: 0x0000DBBF File Offset: 0x0000BDBF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetEMIENO1Null()
				MyBase.Item(Me.tableMeargeData.EMIENO1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E85 RID: 3717 RVA: 0x000B4DD4 File Offset: 0x000B2FD4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMDateNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.MDateColumn)
			End Function

			' Token: 0x06000E86 RID: 3718 RVA: 0x0000DBDE File Offset: 0x0000BDDE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMDateNull()
				MyBase.Item(Me.tableMeargeData.MDateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E87 RID: 3719 RVA: 0x000B4DF8 File Offset: 0x000B2FF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsEDateNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.EDateColumn)
			End Function

			' Token: 0x06000E88 RID: 3720 RVA: 0x0000DBFD File Offset: 0x0000BDFD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetEDateNull()
				MyBase.Item(Me.tableMeargeData.EDateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E89 RID: 3721 RVA: 0x000B4E1C File Offset: 0x000B301C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPOtherLanguageNull() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.POtherLanguageColumn)
			End Function

			' Token: 0x06000E8A RID: 3722 RVA: 0x0000DC1C File Offset: 0x0000BE1C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPOtherLanguageNull()
				MyBase.Item(Me.tableMeargeData.POtherLanguageColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E8B RID: 3723 RVA: 0x000B4E40 File Offset: 0x000B3040
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAB1Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AB1Column)
			End Function

			' Token: 0x06000E8C RID: 3724 RVA: 0x0000DC3B File Offset: 0x0000BE3B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAB1Null()
				MyBase.Item(Me.tableMeargeData.AB1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E8D RID: 3725 RVA: 0x000B4E64 File Offset: 0x000B3064
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAB2Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AB2Column)
			End Function

			' Token: 0x06000E8E RID: 3726 RVA: 0x0000DC5A File Offset: 0x0000BE5A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAB2Null()
				MyBase.Item(Me.tableMeargeData.AB2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E8F RID: 3727 RVA: 0x000B4E88 File Offset: 0x000B3088
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAB3Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AB3Column)
			End Function

			' Token: 0x06000E90 RID: 3728 RVA: 0x0000DC79 File Offset: 0x0000BE79
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAB3Null()
				MyBase.Item(Me.tableMeargeData.AB3Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E91 RID: 3729 RVA: 0x000B4EAC File Offset: 0x000B30AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAB4Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AB4Column)
			End Function

			' Token: 0x06000E92 RID: 3730 RVA: 0x0000DC98 File Offset: 0x0000BE98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAB4Null()
				MyBase.Item(Me.tableMeargeData.AB4Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E93 RID: 3731 RVA: 0x000B4ED0 File Offset: 0x000B30D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAB5Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AB5Column)
			End Function

			' Token: 0x06000E94 RID: 3732 RVA: 0x0000DCB7 File Offset: 0x0000BEB7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAB5Null()
				MyBase.Item(Me.tableMeargeData.AB5Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E95 RID: 3733 RVA: 0x000B4EF4 File Offset: 0x000B30F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAB6Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AB6Column)
			End Function

			' Token: 0x06000E96 RID: 3734 RVA: 0x0000DCD6 File Offset: 0x0000BED6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAB6Null()
				MyBase.Item(Me.tableMeargeData.AB6Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E97 RID: 3735 RVA: 0x000B4F18 File Offset: 0x000B3118
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAB7Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AB7Column)
			End Function

			' Token: 0x06000E98 RID: 3736 RVA: 0x0000DCF5 File Offset: 0x0000BEF5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAB7Null()
				MyBase.Item(Me.tableMeargeData.AB7Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E99 RID: 3737 RVA: 0x000B4F3C File Offset: 0x000B313C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAB8Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AB8Column)
			End Function

			' Token: 0x06000E9A RID: 3738 RVA: 0x0000DD14 File Offset: 0x0000BF14
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAB8Null()
				MyBase.Item(Me.tableMeargeData.AB8Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E9B RID: 3739 RVA: 0x000B4F60 File Offset: 0x000B3160
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAB9Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.AB9Column)
			End Function

			' Token: 0x06000E9C RID: 3740 RVA: 0x0000DD33 File Offset: 0x0000BF33
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAB9Null()
				MyBase.Item(Me.tableMeargeData.AB9Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E9D RID: 3741 RVA: 0x000B4F84 File Offset: 0x000B3184
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsX1Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.X1Column)
			End Function

			' Token: 0x06000E9E RID: 3742 RVA: 0x0000DD52 File Offset: 0x0000BF52
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetX1Null()
				MyBase.Item(Me.tableMeargeData.X1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000E9F RID: 3743 RVA: 0x000B4FA8 File Offset: 0x000B31A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsX2Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.X2Column)
			End Function

			' Token: 0x06000EA0 RID: 3744 RVA: 0x0000DD71 File Offset: 0x0000BF71
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetX2Null()
				MyBase.Item(Me.tableMeargeData.X2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EA1 RID: 3745 RVA: 0x000B4FCC File Offset: 0x000B31CC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsX3Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.X3Column)
			End Function

			' Token: 0x06000EA2 RID: 3746 RVA: 0x0000DD90 File Offset: 0x0000BF90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetX3Null()
				MyBase.Item(Me.tableMeargeData.X3Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EA3 RID: 3747 RVA: 0x000B4FF0 File Offset: 0x000B31F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsX4Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.X4Column)
			End Function

			' Token: 0x06000EA4 RID: 3748 RVA: 0x0000DDAF File Offset: 0x0000BFAF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetX4Null()
				MyBase.Item(Me.tableMeargeData.X4Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EA5 RID: 3749 RVA: 0x000B5014 File Offset: 0x000B3214
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsX5Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.X5Column)
			End Function

			' Token: 0x06000EA6 RID: 3750 RVA: 0x0000DDCE File Offset: 0x0000BFCE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetX5Null()
				MyBase.Item(Me.tableMeargeData.X5Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EA7 RID: 3751 RVA: 0x000B5038 File Offset: 0x000B3238
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsX6Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.X6Column)
			End Function

			' Token: 0x06000EA8 RID: 3752 RVA: 0x0000DDED File Offset: 0x0000BFED
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetX6Null()
				MyBase.Item(Me.tableMeargeData.X6Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EA9 RID: 3753 RVA: 0x000B505C File Offset: 0x000B325C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsX7Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.X7Column)
			End Function

			' Token: 0x06000EAA RID: 3754 RVA: 0x0000DE0C File Offset: 0x0000C00C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetX7Null()
				MyBase.Item(Me.tableMeargeData.X7Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EAB RID: 3755 RVA: 0x000B5080 File Offset: 0x000B3280
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsX8Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.X8Column)
			End Function

			' Token: 0x06000EAC RID: 3756 RVA: 0x0000DE2B File Offset: 0x0000C02B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetX8Null()
				MyBase.Item(Me.tableMeargeData.X8Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EAD RID: 3757 RVA: 0x000B50A4 File Offset: 0x000B32A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsX9Null() As Boolean
				Return MyBase.IsNull(Me.tableMeargeData.X9Column)
			End Function

			' Token: 0x06000EAE RID: 3758 RVA: 0x0000DE4A File Offset: 0x0000C04A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetX9Null()
				MyBase.Item(Me.tableMeargeData.X9Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0400044E RID: 1102
			Private tableMeargeData As NewDataSet.MeargeDataDataTable
		End Class

		' Token: 0x0200004C RID: 76
		Public Class CompanyRow
			Inherits DataRow

			' Token: 0x06000EAF RID: 3759 RVA: 0x0000DE69 File Offset: 0x0000C069
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableCompany = CType(MyBase.Table, NewDataSet.CompanyDataTable)
			End Sub

			' Token: 0x17000615 RID: 1557
			' (get) Token: 0x06000EB0 RID: 3760 RVA: 0x000B50C8 File Offset: 0x000B32C8
			' (set) Token: 0x06000EB1 RID: 3761 RVA: 0x0000DE85 File Offset: 0x0000C085
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CompanyName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.CompanyNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CompanyName' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.CompanyNameColumn) = value
				End Set
			End Property

			' Token: 0x17000616 RID: 1558
			' (get) Token: 0x06000EB2 RID: 3762 RVA: 0x000B5118 File Offset: 0x000B3318
			' (set) Token: 0x06000EB3 RID: 3763 RVA: 0x0000DE9B File Offset: 0x0000C09B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Address As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.AddressColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Address' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.AddressColumn) = value
				End Set
			End Property

			' Token: 0x17000617 RID: 1559
			' (get) Token: 0x06000EB4 RID: 3764 RVA: 0x000B5168 File Offset: 0x000B3368
			' (set) Token: 0x06000EB5 RID: 3765 RVA: 0x0000DEB1 File Offset: 0x0000C0B1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property State As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.StateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'State' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.StateColumn) = value
				End Set
			End Property

			' Token: 0x17000618 RID: 1560
			' (get) Token: 0x06000EB6 RID: 3766 RVA: 0x000B51B8 File Offset: 0x000B33B8
			' (set) Token: 0x06000EB7 RID: 3767 RVA: 0x0000DEC7 File Offset: 0x0000C0C7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ContactNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.ContactNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ContactNo' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.ContactNoColumn) = value
				End Set
			End Property

			' Token: 0x17000619 RID: 1561
			' (get) Token: 0x06000EB8 RID: 3768 RVA: 0x000B5208 File Offset: 0x000B3408
			' (set) Token: 0x06000EB9 RID: 3769 RVA: 0x0000DEDD File Offset: 0x0000C0DD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property EmailID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.EmailIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'EmailID' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.EmailIDColumn) = value
				End Set
			End Property

			' Token: 0x1700061A RID: 1562
			' (get) Token: 0x06000EBA RID: 3770 RVA: 0x000B5258 File Offset: 0x000B3458
			' (set) Token: 0x06000EBB RID: 3771 RVA: 0x0000DEF3 File Offset: 0x0000C0F3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Logo As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableCompany.LogoColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Logo' in table 'Company' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableCompany.LogoColumn) = value
				End Set
			End Property

			' Token: 0x1700061B RID: 1563
			' (get) Token: 0x06000EBC RID: 3772 RVA: 0x000B52A8 File Offset: 0x000B34A8
			' (set) Token: 0x06000EBD RID: 3773 RVA: 0x0000DF09 File Offset: 0x0000C109
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GSTIN As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.GSTINColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GSTIN' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.GSTINColumn) = value
				End Set
			End Property

			' Token: 0x1700061C RID: 1564
			' (get) Token: 0x06000EBE RID: 3774 RVA: 0x000B52F8 File Offset: 0x000B34F8
			' (set) Token: 0x06000EBF RID: 3775 RVA: 0x0000DF1F File Offset: 0x0000C11F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CIN As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.CINColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CIN' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.CINColumn) = value
				End Set
			End Property

			' Token: 0x1700061D RID: 1565
			' (get) Token: 0x06000EC0 RID: 3776 RVA: 0x000B5348 File Offset: 0x000B3548
			' (set) Token: 0x06000EC1 RID: 3777 RVA: 0x0000DF35 File Offset: 0x0000C135
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MaxWriteOffAmount As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.MaxWriteOffAmountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MaxWriteOffAmount' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.MaxWriteOffAmountColumn) = value
				End Set
			End Property

			' Token: 0x1700061E RID: 1566
			' (get) Token: 0x06000EC2 RID: 3778 RVA: 0x000B5398 File Offset: 0x000B3598
			' (set) Token: 0x06000EC3 RID: 3779 RVA: 0x0000DF4B File Offset: 0x0000C14B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Percentage_PerRs As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Percentage_PerRsColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Percentage_PerRs' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Percentage_PerRsColumn) = value
				End Set
			End Property

			' Token: 0x1700061F RID: 1567
			' (get) Token: 0x06000EC4 RID: 3780 RVA: 0x000B53E8 File Offset: 0x000B35E8
			' (set) Token: 0x06000EC5 RID: 3781 RVA: 0x0000DF61 File Offset: 0x0000C161
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Terms1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Terms1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Terms1' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Terms1Column) = value
				End Set
			End Property

			' Token: 0x17000620 RID: 1568
			' (get) Token: 0x06000EC6 RID: 3782 RVA: 0x000B5438 File Offset: 0x000B3638
			' (set) Token: 0x06000EC7 RID: 3783 RVA: 0x0000DF77 File Offset: 0x0000C177
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Terms2 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Terms2Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Terms2' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Terms2Column) = value
				End Set
			End Property

			' Token: 0x17000621 RID: 1569
			' (get) Token: 0x06000EC8 RID: 3784 RVA: 0x000B5488 File Offset: 0x000B3688
			' (set) Token: 0x06000EC9 RID: 3785 RVA: 0x0000DF8D File Offset: 0x0000C18D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Terms3 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Terms3Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Terms3' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Terms3Column) = value
				End Set
			End Property

			' Token: 0x17000622 RID: 1570
			' (get) Token: 0x06000ECA RID: 3786 RVA: 0x000B54D8 File Offset: 0x000B36D8
			' (set) Token: 0x06000ECB RID: 3787 RVA: 0x0000DFA3 File Offset: 0x0000C1A3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property BillCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.BillCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'BillCode' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.BillCodeColumn) = value
				End Set
			End Property

			' Token: 0x17000623 RID: 1571
			' (get) Token: 0x06000ECC RID: 3788 RVA: 0x000B5528 File Offset: 0x000B3728
			' (set) Token: 0x06000ECD RID: 3789 RVA: 0x0000DFB9 File Offset: 0x0000C1B9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Round_Off As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Round_OffColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Round_Off' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Round_OffColumn) = value
				End Set
			End Property

			' Token: 0x17000624 RID: 1572
			' (get) Token: 0x06000ECE RID: 3790 RVA: 0x000B5578 File Offset: 0x000B3778
			' (set) Token: 0x06000ECF RID: 3791 RVA: 0x0000DFCF File Offset: 0x0000C1CF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property BankInfo1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.BankInfo1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'BankInfo1' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.BankInfo1Column) = value
				End Set
			End Property

			' Token: 0x17000625 RID: 1573
			' (get) Token: 0x06000ED0 RID: 3792 RVA: 0x000B55C8 File Offset: 0x000B37C8
			' (set) Token: 0x06000ED1 RID: 3793 RVA: 0x0000DFE5 File Offset: 0x0000C1E5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property BankInfo2 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.BankInfo2Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'BankInfo2' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.BankInfo2Column) = value
				End Set
			End Property

			' Token: 0x17000626 RID: 1574
			' (get) Token: 0x06000ED2 RID: 3794 RVA: 0x000B5618 File Offset: 0x000B3818
			' (set) Token: 0x06000ED3 RID: 3795 RVA: 0x0000DFFB File Offset: 0x0000C1FB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Version As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.VersionColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Version' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.VersionColumn) = value
				End Set
			End Property

			' Token: 0x17000627 RID: 1575
			' (get) Token: 0x06000ED4 RID: 3796 RVA: 0x000B5668 File Offset: 0x000B3868
			' (set) Token: 0x06000ED5 RID: 3797 RVA: 0x0000E011 File Offset: 0x0000C211
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Z1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z1' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Z1Column) = value
				End Set
			End Property

			' Token: 0x17000628 RID: 1576
			' (get) Token: 0x06000ED6 RID: 3798 RVA: 0x000B56B8 File Offset: 0x000B38B8
			' (set) Token: 0x06000ED7 RID: 3799 RVA: 0x0000E027 File Offset: 0x0000C227
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z2 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Z2Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z2' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Z2Column) = value
				End Set
			End Property

			' Token: 0x17000629 RID: 1577
			' (get) Token: 0x06000ED8 RID: 3800 RVA: 0x000B5708 File Offset: 0x000B3908
			' (set) Token: 0x06000ED9 RID: 3801 RVA: 0x0000E03D File Offset: 0x0000C23D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z3 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Z3Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z3' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Z3Column) = value
				End Set
			End Property

			' Token: 0x1700062A RID: 1578
			' (get) Token: 0x06000EDA RID: 3802 RVA: 0x000B5758 File Offset: 0x000B3958
			' (set) Token: 0x06000EDB RID: 3803 RVA: 0x0000E053 File Offset: 0x0000C253
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z4 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Z4Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z4' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Z4Column) = value
				End Set
			End Property

			' Token: 0x1700062B RID: 1579
			' (get) Token: 0x06000EDC RID: 3804 RVA: 0x000B57A8 File Offset: 0x000B39A8
			' (set) Token: 0x06000EDD RID: 3805 RVA: 0x0000E069 File Offset: 0x0000C269
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z5 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Z5Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z5' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Z5Column) = value
				End Set
			End Property

			' Token: 0x1700062C RID: 1580
			' (get) Token: 0x06000EDE RID: 3806 RVA: 0x000B57F8 File Offset: 0x000B39F8
			' (set) Token: 0x06000EDF RID: 3807 RVA: 0x0000E07F File Offset: 0x0000C27F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z6 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Z6Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z6' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Z6Column) = value
				End Set
			End Property

			' Token: 0x1700062D RID: 1581
			' (get) Token: 0x06000EE0 RID: 3808 RVA: 0x000B5848 File Offset: 0x000B3A48
			' (set) Token: 0x06000EE1 RID: 3809 RVA: 0x0000E095 File Offset: 0x0000C295
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z7 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Z7Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z7' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Z7Column) = value
				End Set
			End Property

			' Token: 0x1700062E RID: 1582
			' (get) Token: 0x06000EE2 RID: 3810 RVA: 0x000B5898 File Offset: 0x000B3A98
			' (set) Token: 0x06000EE3 RID: 3811 RVA: 0x0000E0AB File Offset: 0x0000C2AB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z8 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Z8Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z8' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Z8Column) = value
				End Set
			End Property

			' Token: 0x1700062F RID: 1583
			' (get) Token: 0x06000EE4 RID: 3812 RVA: 0x000B58E8 File Offset: 0x000B3AE8
			' (set) Token: 0x06000EE5 RID: 3813 RVA: 0x0000E0C1 File Offset: 0x0000C2C1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z9 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableCompany.Z9Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z9' in table 'Company' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableCompany.Z9Column) = value
				End Set
			End Property

			' Token: 0x06000EE6 RID: 3814 RVA: 0x000B5938 File Offset: 0x000B3B38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCompanyNameNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.CompanyNameColumn)
			End Function

			' Token: 0x06000EE7 RID: 3815 RVA: 0x0000E0D7 File Offset: 0x0000C2D7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCompanyNameNull()
				MyBase.Item(Me.tableCompany.CompanyNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EE8 RID: 3816 RVA: 0x000B595C File Offset: 0x000B3B5C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAddressNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.AddressColumn)
			End Function

			' Token: 0x06000EE9 RID: 3817 RVA: 0x0000E0F6 File Offset: 0x0000C2F6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAddressNull()
				MyBase.Item(Me.tableCompany.AddressColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EEA RID: 3818 RVA: 0x000B5980 File Offset: 0x000B3B80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsStateNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.StateColumn)
			End Function

			' Token: 0x06000EEB RID: 3819 RVA: 0x0000E115 File Offset: 0x0000C315
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetStateNull()
				MyBase.Item(Me.tableCompany.StateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EEC RID: 3820 RVA: 0x000B59A4 File Offset: 0x000B3BA4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsContactNoNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.ContactNoColumn)
			End Function

			' Token: 0x06000EED RID: 3821 RVA: 0x0000E134 File Offset: 0x0000C334
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetContactNoNull()
				MyBase.Item(Me.tableCompany.ContactNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EEE RID: 3822 RVA: 0x000B59C8 File Offset: 0x000B3BC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsEmailIDNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.EmailIDColumn)
			End Function

			' Token: 0x06000EEF RID: 3823 RVA: 0x0000E153 File Offset: 0x0000C353
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetEmailIDNull()
				MyBase.Item(Me.tableCompany.EmailIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EF0 RID: 3824 RVA: 0x000B59EC File Offset: 0x000B3BEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsLogoNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.LogoColumn)
			End Function

			' Token: 0x06000EF1 RID: 3825 RVA: 0x0000E172 File Offset: 0x0000C372
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetLogoNull()
				MyBase.Item(Me.tableCompany.LogoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EF2 RID: 3826 RVA: 0x000B5A10 File Offset: 0x000B3C10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGSTINNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.GSTINColumn)
			End Function

			' Token: 0x06000EF3 RID: 3827 RVA: 0x0000E191 File Offset: 0x0000C391
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGSTINNull()
				MyBase.Item(Me.tableCompany.GSTINColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EF4 RID: 3828 RVA: 0x000B5A34 File Offset: 0x000B3C34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCINNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.CINColumn)
			End Function

			' Token: 0x06000EF5 RID: 3829 RVA: 0x0000E1B0 File Offset: 0x0000C3B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCINNull()
				MyBase.Item(Me.tableCompany.CINColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EF6 RID: 3830 RVA: 0x000B5A58 File Offset: 0x000B3C58
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMaxWriteOffAmountNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.MaxWriteOffAmountColumn)
			End Function

			' Token: 0x06000EF7 RID: 3831 RVA: 0x0000E1CF File Offset: 0x0000C3CF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMaxWriteOffAmountNull()
				MyBase.Item(Me.tableCompany.MaxWriteOffAmountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EF8 RID: 3832 RVA: 0x000B5A7C File Offset: 0x000B3C7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPercentage_PerRsNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Percentage_PerRsColumn)
			End Function

			' Token: 0x06000EF9 RID: 3833 RVA: 0x0000E1EE File Offset: 0x0000C3EE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPercentage_PerRsNull()
				MyBase.Item(Me.tableCompany.Percentage_PerRsColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EFA RID: 3834 RVA: 0x000B5AA0 File Offset: 0x000B3CA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTerms1Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Terms1Column)
			End Function

			' Token: 0x06000EFB RID: 3835 RVA: 0x0000E20D File Offset: 0x0000C40D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTerms1Null()
				MyBase.Item(Me.tableCompany.Terms1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EFC RID: 3836 RVA: 0x000B5AC4 File Offset: 0x000B3CC4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTerms2Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Terms2Column)
			End Function

			' Token: 0x06000EFD RID: 3837 RVA: 0x0000E22C File Offset: 0x0000C42C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTerms2Null()
				MyBase.Item(Me.tableCompany.Terms2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000EFE RID: 3838 RVA: 0x000B5AE8 File Offset: 0x000B3CE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTerms3Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Terms3Column)
			End Function

			' Token: 0x06000EFF RID: 3839 RVA: 0x0000E24B File Offset: 0x0000C44B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTerms3Null()
				MyBase.Item(Me.tableCompany.Terms3Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F00 RID: 3840 RVA: 0x000B5B0C File Offset: 0x000B3D0C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBillCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.BillCodeColumn)
			End Function

			' Token: 0x06000F01 RID: 3841 RVA: 0x0000E26A File Offset: 0x0000C46A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBillCodeNull()
				MyBase.Item(Me.tableCompany.BillCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F02 RID: 3842 RVA: 0x000B5B30 File Offset: 0x000B3D30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRound_OffNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Round_OffColumn)
			End Function

			' Token: 0x06000F03 RID: 3843 RVA: 0x0000E289 File Offset: 0x0000C489
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRound_OffNull()
				MyBase.Item(Me.tableCompany.Round_OffColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F04 RID: 3844 RVA: 0x000B5B54 File Offset: 0x000B3D54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBankInfo1Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.BankInfo1Column)
			End Function

			' Token: 0x06000F05 RID: 3845 RVA: 0x0000E2A8 File Offset: 0x0000C4A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBankInfo1Null()
				MyBase.Item(Me.tableCompany.BankInfo1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F06 RID: 3846 RVA: 0x000B5B78 File Offset: 0x000B3D78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBankInfo2Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.BankInfo2Column)
			End Function

			' Token: 0x06000F07 RID: 3847 RVA: 0x0000E2C7 File Offset: 0x0000C4C7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBankInfo2Null()
				MyBase.Item(Me.tableCompany.BankInfo2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F08 RID: 3848 RVA: 0x000B5B9C File Offset: 0x000B3D9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsVersionNull() As Boolean
				Return MyBase.IsNull(Me.tableCompany.VersionColumn)
			End Function

			' Token: 0x06000F09 RID: 3849 RVA: 0x0000E2E6 File Offset: 0x0000C4E6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetVersionNull()
				MyBase.Item(Me.tableCompany.VersionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F0A RID: 3850 RVA: 0x000B5BC0 File Offset: 0x000B3DC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZ1Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Z1Column)
			End Function

			' Token: 0x06000F0B RID: 3851 RVA: 0x0000E305 File Offset: 0x0000C505
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZ1Null()
				MyBase.Item(Me.tableCompany.Z1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F0C RID: 3852 RVA: 0x000B5BE4 File Offset: 0x000B3DE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZ2Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Z2Column)
			End Function

			' Token: 0x06000F0D RID: 3853 RVA: 0x0000E324 File Offset: 0x0000C524
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZ2Null()
				MyBase.Item(Me.tableCompany.Z2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F0E RID: 3854 RVA: 0x000B5C08 File Offset: 0x000B3E08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZ3Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Z3Column)
			End Function

			' Token: 0x06000F0F RID: 3855 RVA: 0x0000E343 File Offset: 0x0000C543
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZ3Null()
				MyBase.Item(Me.tableCompany.Z3Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F10 RID: 3856 RVA: 0x000B5C2C File Offset: 0x000B3E2C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZ4Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Z4Column)
			End Function

			' Token: 0x06000F11 RID: 3857 RVA: 0x0000E362 File Offset: 0x0000C562
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZ4Null()
				MyBase.Item(Me.tableCompany.Z4Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F12 RID: 3858 RVA: 0x000B5C50 File Offset: 0x000B3E50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZ5Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Z5Column)
			End Function

			' Token: 0x06000F13 RID: 3859 RVA: 0x0000E381 File Offset: 0x0000C581
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZ5Null()
				MyBase.Item(Me.tableCompany.Z5Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F14 RID: 3860 RVA: 0x000B5C74 File Offset: 0x000B3E74
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZ6Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Z6Column)
			End Function

			' Token: 0x06000F15 RID: 3861 RVA: 0x0000E3A0 File Offset: 0x0000C5A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZ6Null()
				MyBase.Item(Me.tableCompany.Z6Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F16 RID: 3862 RVA: 0x000B5C98 File Offset: 0x000B3E98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZ7Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Z7Column)
			End Function

			' Token: 0x06000F17 RID: 3863 RVA: 0x0000E3BF File Offset: 0x0000C5BF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZ7Null()
				MyBase.Item(Me.tableCompany.Z7Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F18 RID: 3864 RVA: 0x000B5CBC File Offset: 0x000B3EBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZ8Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Z8Column)
			End Function

			' Token: 0x06000F19 RID: 3865 RVA: 0x0000E3DE File Offset: 0x0000C5DE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZ8Null()
				MyBase.Item(Me.tableCompany.Z8Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000F1A RID: 3866 RVA: 0x000B5CE0 File Offset: 0x000B3EE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZ9Null() As Boolean
				Return MyBase.IsNull(Me.tableCompany.Z9Column)
			End Function

			' Token: 0x06000F1B RID: 3867 RVA: 0x0000E3FD File Offset: 0x0000C5FD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZ9Null()
				MyBase.Item(Me.tableCompany.Z9Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0400044F RID: 1103
			Private tableCompany As NewDataSet.CompanyDataTable
		End Class

		' Token: 0x0200004D RID: 77
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class Table1RowChangeEvent
			Inherits EventArgs

			' Token: 0x06000F1C RID: 3868 RVA: 0x0000E41C File Offset: 0x0000C61C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As NewDataSet.Table1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17000630 RID: 1584
			' (get) Token: 0x06000F1D RID: 3869 RVA: 0x000B5D04 File Offset: 0x000B3F04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As NewDataSet.Table1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17000631 RID: 1585
			' (get) Token: 0x06000F1E RID: 3870 RVA: 0x000B5D1C File Offset: 0x000B3F1C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x04000450 RID: 1104
			Private eventRow As NewDataSet.Table1Row

			' Token: 0x04000451 RID: 1105
			Private eventAction As DataRowAction
		End Class

		' Token: 0x0200004E RID: 78
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class MeargeDataRowChangeEvent
			Inherits EventArgs

			' Token: 0x06000F1F RID: 3871 RVA: 0x0000E434 File Offset: 0x0000C634
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As NewDataSet.MeargeDataRow, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17000632 RID: 1586
			' (get) Token: 0x06000F20 RID: 3872 RVA: 0x000B5D34 File Offset: 0x000B3F34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As NewDataSet.MeargeDataRow
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17000633 RID: 1587
			' (get) Token: 0x06000F21 RID: 3873 RVA: 0x000B5D4C File Offset: 0x000B3F4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x04000452 RID: 1106
			Private eventRow As NewDataSet.MeargeDataRow

			' Token: 0x04000453 RID: 1107
			Private eventAction As DataRowAction
		End Class

		' Token: 0x0200004F RID: 79
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class CompanyRowChangeEvent
			Inherits EventArgs

			' Token: 0x06000F22 RID: 3874 RVA: 0x0000E44C File Offset: 0x0000C64C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As NewDataSet.CompanyRow, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17000634 RID: 1588
			' (get) Token: 0x06000F23 RID: 3875 RVA: 0x000B5D64 File Offset: 0x000B3F64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As NewDataSet.CompanyRow
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17000635 RID: 1589
			' (get) Token: 0x06000F24 RID: 3876 RVA: 0x000B5D7C File Offset: 0x000B3F7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x04000454 RID: 1108
			Private eventRow As NewDataSet.CompanyRow

			' Token: 0x04000455 RID: 1109
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
