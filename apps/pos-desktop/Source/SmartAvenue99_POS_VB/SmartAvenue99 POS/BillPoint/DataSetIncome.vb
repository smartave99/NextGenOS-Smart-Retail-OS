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
	' Token: 0x02000494 RID: 1172
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSetIncome")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSetIncome
		Inherits DataSet

		' Token: 0x0600EA77 RID: 60023 RVA: 0x008DABFC File Offset: 0x008D8DFC
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

		' Token: 0x0600EA78 RID: 60024 RVA: 0x008DAC54 File Offset: 0x008D8E54
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
						MyBase.Tables.Add(New DataSetIncome.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x17005A1E RID: 23070
		' (get) Token: 0x0600EA79 RID: 60025 RVA: 0x008DADE8 File Offset: 0x008D8FE8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As DataSetIncome.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x17005A1F RID: 23071
		' (get) Token: 0x0600EA7A RID: 60026 RVA: 0x008DAE00 File Offset: 0x008D9000
		' (set) Token: 0x0600EA7B RID: 60027 RVA: 0x00066C64 File Offset: 0x00064E64
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

		' Token: 0x17005A20 RID: 23072
		' (get) Token: 0x0600EA7C RID: 60028 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x17005A21 RID: 23073
		' (get) Token: 0x0600EA7D RID: 60029 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x0600EA7E RID: 60030 RVA: 0x00066C6E File Offset: 0x00064E6E
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x0600EA7F RID: 60031 RVA: 0x008DAE18 File Offset: 0x008D9018
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSetIncome As DataSetIncome = CType(MyBase.Clone(), DataSetIncome)
			dataSetIncome.InitVars()
			dataSetIncome.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSetIncome
		End Function

		' Token: 0x0600EA80 RID: 60032 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x0600EA81 RID: 60033 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x0600EA82 RID: 60034 RVA: 0x008DAE4C File Offset: 0x008D904C
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
					MyBase.Tables.Add(New DataSetIncome.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x0600EA83 RID: 60035 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x0600EA84 RID: 60036 RVA: 0x00066C86 File Offset: 0x00064E86
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x0600EA85 RID: 60037 RVA: 0x008DAF30 File Offset: 0x008D9130
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), DataSetIncome.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
		End Sub

		' Token: 0x0600EA86 RID: 60038 RVA: 0x008DAF7C File Offset: 0x008D917C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSetIncome"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSetIncome.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New DataSetIncome.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
		End Sub

		' Token: 0x0600EA87 RID: 60039 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x0600EA88 RID: 60040 RVA: 0x008DAFDC File Offset: 0x008D91DC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x0600EA89 RID: 60041 RVA: 0x008DB000 File Offset: 0x008D9200
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSetIncome As DataSetIncome = New DataSetIncome()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSetIncome.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSetIncome.GetSchemaSerializable()
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

		' Token: 0x040059BF RID: 22975
		Private tableDataTable1 As DataSetIncome.DataTable1DataTable

		' Token: 0x040059C0 RID: 22976
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x02000495 RID: 1173
		' (Invoke) Token: 0x0600EA8D RID: 60045
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As DataSetIncome.DataTable1RowChangeEvent)

		' Token: 0x02000496 RID: 1174
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of DataSetIncome.DataTable1Row)

			' Token: 0x0600EA8E RID: 60046 RVA: 0x00066C91 File Offset: 0x00064E91
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600EA8F RID: 60047 RVA: 0x008DB194 File Offset: 0x008D9394
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

			' Token: 0x0600EA90 RID: 60048 RVA: 0x00066CBC File Offset: 0x00064EBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17005A22 RID: 23074
			' (get) Token: 0x0600EA91 RID: 60049 RVA: 0x008DB260 File Offset: 0x008D9460
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Income_IDColumn As DataColumn
				Get
					Return Me.columnIncome_ID
				End Get
			End Property

			' Token: 0x17005A23 RID: 23075
			' (get) Token: 0x0600EA92 RID: 60050 RVA: 0x008DB278 File Offset: 0x008D9478
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property _Income_No_Column As DataColumn
				Get
					Return Me._columnIncome_No_
				End Get
			End Property

			' Token: 0x17005A24 RID: 23076
			' (get) Token: 0x0600EA93 RID: 60051 RVA: 0x008DB290 File Offset: 0x008D9490
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Income_DateColumn As DataColumn
				Get
					Return Me.columnIncome_Date
				End Get
			End Property

			' Token: 0x17005A25 RID: 23077
			' (get) Token: 0x0600EA94 RID: 60052 RVA: 0x008DB2A8 File Offset: 0x008D94A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property NameColumn As DataColumn
				Get
					Return Me.columnName
				End Get
			End Property

			' Token: 0x17005A26 RID: 23078
			' (get) Token: 0x0600EA95 RID: 60053 RVA: 0x008DB2C0 File Offset: 0x008D94C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DetailsColumn As DataColumn
				Get
					Return Me.columnDetails
				End Get
			End Property

			' Token: 0x17005A27 RID: 23079
			' (get) Token: 0x0600EA96 RID: 60054 RVA: 0x008DB2D8 File Offset: 0x008D94D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Grand_TotalColumn As DataColumn
				Get
					Return Me.columnGrand_Total
				End Get
			End Property

			' Token: 0x17005A28 RID: 23080
			' (get) Token: 0x0600EA97 RID: 60055 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17005A29 RID: 23081
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetIncome.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), DataSetIncome.DataTable1Row)
				End Get
			End Property

			' Token: 0x1400011C RID: 284
			' (add) Token: 0x0600EA99 RID: 60057 RVA: 0x008DB314 File Offset: 0x008D9514
			' (remove) Token: 0x0600EA9A RID: 60058 RVA: 0x008DB34C File Offset: 0x008D954C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As DataSetIncome.DataTable1RowChangeEventHandler

			' Token: 0x1400011D RID: 285
			' (add) Token: 0x0600EA9B RID: 60059 RVA: 0x008DB384 File Offset: 0x008D9584
			' (remove) Token: 0x0600EA9C RID: 60060 RVA: 0x008DB3BC File Offset: 0x008D95BC
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As DataSetIncome.DataTable1RowChangeEventHandler

			' Token: 0x1400011E RID: 286
			' (add) Token: 0x0600EA9D RID: 60061 RVA: 0x008DB3F4 File Offset: 0x008D95F4
			' (remove) Token: 0x0600EA9E RID: 60062 RVA: 0x008DB42C File Offset: 0x008D962C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As DataSetIncome.DataTable1RowChangeEventHandler

			' Token: 0x1400011F RID: 287
			' (add) Token: 0x0600EA9F RID: 60063 RVA: 0x008DB464 File Offset: 0x008D9664
			' (remove) Token: 0x0600EAA0 RID: 60064 RVA: 0x008DB49C File Offset: 0x008D969C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As DataSetIncome.DataTable1RowChangeEventHandler

			' Token: 0x0600EAA1 RID: 60065 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As DataSetIncome.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600EAA2 RID: 60066 RVA: 0x008DB4D4 File Offset: 0x008D96D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(Income_ID As String, _Income_No_ As String, Income_Date As String, Name As String, Details As String, Grand_Total As String) As DataSetIncome.DataTable1Row
				Dim dataTable1Row As DataSetIncome.DataTable1Row = CType(MyBase.NewRow(), DataSetIncome.DataTable1Row)
				Dim array As Object() = New Object() { Income_ID, _Income_No_, Income_Date, Name, Details, Grand_Total }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x0600EAA3 RID: 60067 RVA: 0x008DB52C File Offset: 0x008D972C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As DataSetIncome.DataTable1DataTable = CType(MyBase.Clone(), DataSetIncome.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x0600EAA4 RID: 60068 RVA: 0x008DB554 File Offset: 0x008D9754
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetIncome.DataTable1DataTable()
			End Function

			' Token: 0x0600EAA5 RID: 60069 RVA: 0x008DB56C File Offset: 0x008D976C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnIncome_ID = MyBase.Columns("Income ID")
				Me._columnIncome_No_ = MyBase.Columns("Income No.")
				Me.columnIncome_Date = MyBase.Columns("Income Date")
				Me.columnName = MyBase.Columns("Name")
				Me.columnDetails = MyBase.Columns("Details")
				Me.columnGrand_Total = MyBase.Columns("Grand Total")
			End Sub

			' Token: 0x0600EAA6 RID: 60070 RVA: 0x008DB600 File Offset: 0x008D9800
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnIncome_ID = New DataColumn("Income ID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIncome_ID)
				Me._columnIncome_No_ = New DataColumn("Income No.", GetType(String), Nothing, MappingType.Element)
				Me._columnIncome_No_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnIncome_No_")
				Me._columnIncome_No_.ExtendedProperties.Add("Generator_UserColumnName", "Income No.")
				MyBase.Columns.Add(Me._columnIncome_No_)
				Me.columnIncome_Date = New DataColumn("Income Date", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIncome_Date)
				Me.columnName = New DataColumn("Name", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnName)
				Me.columnDetails = New DataColumn("Details", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDetails)
				Me.columnGrand_Total = New DataColumn("Grand Total", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGrand_Total)
			End Sub

			' Token: 0x0600EAA7 RID: 60071 RVA: 0x008DB758 File Offset: 0x008D9958
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As DataSetIncome.DataTable1Row
				Return CType(MyBase.NewRow(), DataSetIncome.DataTable1Row)
			End Function

			' Token: 0x0600EAA8 RID: 60072 RVA: 0x008DB778 File Offset: 0x008D9978
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetIncome.DataTable1Row(builder)
			End Function

			' Token: 0x0600EAA9 RID: 60073 RVA: 0x008DB790 File Offset: 0x008D9990
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetIncome.DataTable1Row)
			End Function

			' Token: 0x0600EAAA RID: 60074 RVA: 0x008DB7AC File Offset: 0x008D99AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As DataSetIncome.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New DataSetIncome.DataTable1RowChangeEvent(CType(e.Row, DataSetIncome.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EAAB RID: 60075 RVA: 0x008DB7FC File Offset: 0x008D99FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As DataSetIncome.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New DataSetIncome.DataTable1RowChangeEvent(CType(e.Row, DataSetIncome.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EAAC RID: 60076 RVA: 0x008DB84C File Offset: 0x008D9A4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As DataSetIncome.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New DataSetIncome.DataTable1RowChangeEvent(CType(e.Row, DataSetIncome.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EAAD RID: 60077 RVA: 0x008DB89C File Offset: 0x008D9A9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As DataSetIncome.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New DataSetIncome.DataTable1RowChangeEvent(CType(e.Row, DataSetIncome.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EAAE RID: 60078 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As DataSetIncome.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600EAAF RID: 60079 RVA: 0x008DB8EC File Offset: 0x008D9AEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetIncome As DataSetIncome = New DataSetIncome()
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
				xmlSchemaAttribute.FixedValue = dataSetIncome.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetIncome.GetSchemaSerializable()
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

			' Token: 0x040059C1 RID: 22977
			Private columnIncome_ID As DataColumn

			' Token: 0x040059C2 RID: 22978
			Private _columnIncome_No_ As DataColumn

			' Token: 0x040059C3 RID: 22979
			Private columnIncome_Date As DataColumn

			' Token: 0x040059C4 RID: 22980
			Private columnName As DataColumn

			' Token: 0x040059C5 RID: 22981
			Private columnDetails As DataColumn

			' Token: 0x040059C6 RID: 22982
			Private columnGrand_Total As DataColumn
		End Class

		' Token: 0x02000497 RID: 1175
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x0600EAB0 RID: 60080 RVA: 0x00066CCF File Offset: 0x00064ECF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, DataSetIncome.DataTable1DataTable)
			End Sub

			' Token: 0x17005A2A RID: 23082
			' (get) Token: 0x0600EAB1 RID: 60081 RVA: 0x008DBB40 File Offset: 0x008D9D40
			' (set) Token: 0x0600EAB2 RID: 60082 RVA: 0x00066CEB File Offset: 0x00064EEB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Income_ID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.Income_IDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Income ID' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.Income_IDColumn) = value
				End Set
			End Property

			' Token: 0x17005A2B RID: 23083
			' (get) Token: 0x0600EAB3 RID: 60083 RVA: 0x008DBB90 File Offset: 0x008D9D90
			' (set) Token: 0x0600EAB4 RID: 60084 RVA: 0x00066D01 File Offset: 0x00064F01
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property _Income_No_ As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1._Income_No_Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Income No.' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1._Income_No_Column) = value
				End Set
			End Property

			' Token: 0x17005A2C RID: 23084
			' (get) Token: 0x0600EAB5 RID: 60085 RVA: 0x008DBBE0 File Offset: 0x008D9DE0
			' (set) Token: 0x0600EAB6 RID: 60086 RVA: 0x00066D17 File Offset: 0x00064F17
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Income_Date As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.Income_DateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Income Date' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.Income_DateColumn) = value
				End Set
			End Property

			' Token: 0x17005A2D RID: 23085
			' (get) Token: 0x0600EAB7 RID: 60087 RVA: 0x008DBC30 File Offset: 0x008D9E30
			' (set) Token: 0x0600EAB8 RID: 60088 RVA: 0x00066D2D File Offset: 0x00064F2D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Name As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.NameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Name' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.NameColumn) = value
				End Set
			End Property

			' Token: 0x17005A2E RID: 23086
			' (get) Token: 0x0600EAB9 RID: 60089 RVA: 0x008DBC80 File Offset: 0x008D9E80
			' (set) Token: 0x0600EABA RID: 60090 RVA: 0x00066D43 File Offset: 0x00064F43
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Details As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.DetailsColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Details' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.DetailsColumn) = value
				End Set
			End Property

			' Token: 0x17005A2F RID: 23087
			' (get) Token: 0x0600EABB RID: 60091 RVA: 0x008DBCD0 File Offset: 0x008D9ED0
			' (set) Token: 0x0600EABC RID: 60092 RVA: 0x00066D59 File Offset: 0x00064F59
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Grand_Total As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.Grand_TotalColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Grand Total' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.Grand_TotalColumn) = value
				End Set
			End Property

			' Token: 0x0600EABD RID: 60093 RVA: 0x008DBD20 File Offset: 0x008D9F20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIncome_IDNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.Income_IDColumn)
			End Function

			' Token: 0x0600EABE RID: 60094 RVA: 0x00066D6F File Offset: 0x00064F6F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIncome_IDNull()
				MyBase.Item(Me.tableDataTable1.Income_IDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EABF RID: 60095 RVA: 0x008DBD44 File Offset: 0x008D9F44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function Is_Income_No_Null() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1._Income_No_Column)
			End Function

			' Token: 0x0600EAC0 RID: 60096 RVA: 0x00066D8E File Offset: 0x00064F8E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub Set_Income_No_Null()
				MyBase.Item(Me.tableDataTable1._Income_No_Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EAC1 RID: 60097 RVA: 0x008DBD68 File Offset: 0x008D9F68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIncome_DateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.Income_DateColumn)
			End Function

			' Token: 0x0600EAC2 RID: 60098 RVA: 0x00066DAD File Offset: 0x00064FAD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIncome_DateNull()
				MyBase.Item(Me.tableDataTable1.Income_DateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EAC3 RID: 60099 RVA: 0x008DBD8C File Offset: 0x008D9F8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.NameColumn)
			End Function

			' Token: 0x0600EAC4 RID: 60100 RVA: 0x00066DCC File Offset: 0x00064FCC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetNameNull()
				MyBase.Item(Me.tableDataTable1.NameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EAC5 RID: 60101 RVA: 0x008DBDB0 File Offset: 0x008D9FB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDetailsNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.DetailsColumn)
			End Function

			' Token: 0x0600EAC6 RID: 60102 RVA: 0x00066DEB File Offset: 0x00064FEB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDetailsNull()
				MyBase.Item(Me.tableDataTable1.DetailsColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EAC7 RID: 60103 RVA: 0x008DBDD4 File Offset: 0x008D9FD4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGrand_TotalNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.Grand_TotalColumn)
			End Function

			' Token: 0x0600EAC8 RID: 60104 RVA: 0x00066E0A File Offset: 0x0006500A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGrand_TotalNull()
				MyBase.Item(Me.tableDataTable1.Grand_TotalColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040059CB RID: 22987
			Private tableDataTable1 As DataSetIncome.DataTable1DataTable
		End Class

		' Token: 0x02000498 RID: 1176
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600EAC9 RID: 60105 RVA: 0x00066E29 File Offset: 0x00065029
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetIncome.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17005A30 RID: 23088
			' (get) Token: 0x0600EACA RID: 60106 RVA: 0x008DBDF8 File Offset: 0x008D9FF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetIncome.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17005A31 RID: 23089
			' (get) Token: 0x0600EACB RID: 60107 RVA: 0x008DBE10 File Offset: 0x008DA010
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040059CC RID: 22988
			Private eventRow As DataSetIncome.DataTable1Row

			' Token: 0x040059CD RID: 22989
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
