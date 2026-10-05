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
	' Token: 0x02000499 RID: 1177
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSetLoyaltyCard")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSetLoyaltyCard
		Inherits DataSet

		' Token: 0x0600EACC RID: 60108 RVA: 0x008DBE28 File Offset: 0x008DA028
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

		' Token: 0x0600EACD RID: 60109 RVA: 0x008DBE80 File Offset: 0x008DA080
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
						MyBase.Tables.Add(New DataSetLoyaltyCard.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x17005A32 RID: 23090
		' (get) Token: 0x0600EACE RID: 60110 RVA: 0x008DC014 File Offset: 0x008DA214
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As DataSetLoyaltyCard.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x17005A33 RID: 23091
		' (get) Token: 0x0600EACF RID: 60111 RVA: 0x008DC02C File Offset: 0x008DA22C
		' (set) Token: 0x0600EAD0 RID: 60112 RVA: 0x00066E41 File Offset: 0x00065041
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

		' Token: 0x17005A34 RID: 23092
		' (get) Token: 0x0600EAD1 RID: 60113 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x17005A35 RID: 23093
		' (get) Token: 0x0600EAD2 RID: 60114 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x0600EAD3 RID: 60115 RVA: 0x00066E4B File Offset: 0x0006504B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x0600EAD4 RID: 60116 RVA: 0x008DC044 File Offset: 0x008DA244
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSetLoyaltyCard As DataSetLoyaltyCard = CType(MyBase.Clone(), DataSetLoyaltyCard)
			dataSetLoyaltyCard.InitVars()
			dataSetLoyaltyCard.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSetLoyaltyCard
		End Function

		' Token: 0x0600EAD5 RID: 60117 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x0600EAD6 RID: 60118 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x0600EAD7 RID: 60119 RVA: 0x008DC078 File Offset: 0x008DA278
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
					MyBase.Tables.Add(New DataSetLoyaltyCard.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x0600EAD8 RID: 60120 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x0600EAD9 RID: 60121 RVA: 0x00066E63 File Offset: 0x00065063
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x0600EADA RID: 60122 RVA: 0x008DC15C File Offset: 0x008DA35C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), DataSetLoyaltyCard.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
		End Sub

		' Token: 0x0600EADB RID: 60123 RVA: 0x008DC1A8 File Offset: 0x008DA3A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSetLoyaltyCard"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSetLoyaltyCard.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New DataSetLoyaltyCard.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
		End Sub

		' Token: 0x0600EADC RID: 60124 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x0600EADD RID: 60125 RVA: 0x008DC208 File Offset: 0x008DA408
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x0600EADE RID: 60126 RVA: 0x008DC22C File Offset: 0x008DA42C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSetLoyaltyCard As DataSetLoyaltyCard = New DataSetLoyaltyCard()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSetLoyaltyCard.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSetLoyaltyCard.GetSchemaSerializable()
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

		' Token: 0x040059CE RID: 22990
		Private tableDataTable1 As DataSetLoyaltyCard.DataTable1DataTable

		' Token: 0x040059CF RID: 22991
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x0200049A RID: 1178
		' (Invoke) Token: 0x0600EAE2 RID: 60130
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As DataSetLoyaltyCard.DataTable1RowChangeEvent)

		' Token: 0x0200049B RID: 1179
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of DataSetLoyaltyCard.DataTable1Row)

			' Token: 0x0600EAE3 RID: 60131 RVA: 0x00066E6E File Offset: 0x0006506E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600EAE4 RID: 60132 RVA: 0x008DC3C0 File Offset: 0x008DA5C0
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

			' Token: 0x0600EAE5 RID: 60133 RVA: 0x00066E99 File Offset: 0x00065099
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17005A36 RID: 23094
			' (get) Token: 0x0600EAE6 RID: 60134 RVA: 0x008DC48C File Offset: 0x008DA68C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CustomerIDColumn As DataColumn
				Get
					Return Me.columnCustomerID
				End Get
			End Property

			' Token: 0x17005A37 RID: 23095
			' (get) Token: 0x0600EAE7 RID: 60135 RVA: 0x008DC4A4 File Offset: 0x008DA6A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property NameColumn As DataColumn
				Get
					Return Me.columnName
				End Get
			End Property

			' Token: 0x17005A38 RID: 23096
			' (get) Token: 0x0600EAE8 RID: 60136 RVA: 0x008DC4BC File Offset: 0x008DA6BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AddressColumn As DataColumn
				Get
					Return Me.columnAddress
				End Get
			End Property

			' Token: 0x17005A39 RID: 23097
			' (get) Token: 0x0600EAE9 RID: 60137 RVA: 0x008DC4D4 File Offset: 0x008DA6D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ContactNoColumn As DataColumn
				Get
					Return Me.columnContactNo
				End Get
			End Property

			' Token: 0x17005A3A RID: 23098
			' (get) Token: 0x0600EAEA RID: 60138 RVA: 0x008DC4EC File Offset: 0x008DA6EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Column5Column As DataColumn
				Get
					Return Me.columnColumn5
				End Get
			End Property

			' Token: 0x17005A3B RID: 23099
			' (get) Token: 0x0600EAEB RID: 60139 RVA: 0x008DC504 File Offset: 0x008DA704
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Column6Column As DataColumn
				Get
					Return Me.columnColumn6
				End Get
			End Property

			' Token: 0x17005A3C RID: 23100
			' (get) Token: 0x0600EAEC RID: 60140 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17005A3D RID: 23101
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetLoyaltyCard.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), DataSetLoyaltyCard.DataTable1Row)
				End Get
			End Property

			' Token: 0x14000120 RID: 288
			' (add) Token: 0x0600EAEE RID: 60142 RVA: 0x008DC540 File Offset: 0x008DA740
			' (remove) Token: 0x0600EAEF RID: 60143 RVA: 0x008DC578 File Offset: 0x008DA778
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As DataSetLoyaltyCard.DataTable1RowChangeEventHandler

			' Token: 0x14000121 RID: 289
			' (add) Token: 0x0600EAF0 RID: 60144 RVA: 0x008DC5B0 File Offset: 0x008DA7B0
			' (remove) Token: 0x0600EAF1 RID: 60145 RVA: 0x008DC5E8 File Offset: 0x008DA7E8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As DataSetLoyaltyCard.DataTable1RowChangeEventHandler

			' Token: 0x14000122 RID: 290
			' (add) Token: 0x0600EAF2 RID: 60146 RVA: 0x008DC620 File Offset: 0x008DA820
			' (remove) Token: 0x0600EAF3 RID: 60147 RVA: 0x008DC658 File Offset: 0x008DA858
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As DataSetLoyaltyCard.DataTable1RowChangeEventHandler

			' Token: 0x14000123 RID: 291
			' (add) Token: 0x0600EAF4 RID: 60148 RVA: 0x008DC690 File Offset: 0x008DA890
			' (remove) Token: 0x0600EAF5 RID: 60149 RVA: 0x008DC6C8 File Offset: 0x008DA8C8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As DataSetLoyaltyCard.DataTable1RowChangeEventHandler

			' Token: 0x0600EAF6 RID: 60150 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As DataSetLoyaltyCard.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600EAF7 RID: 60151 RVA: 0x008DC700 File Offset: 0x008DA900
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(CustomerID As String, Name As String, Address As String, ContactNo As String, Column5 As String, Column6 As String) As DataSetLoyaltyCard.DataTable1Row
				Dim dataTable1Row As DataSetLoyaltyCard.DataTable1Row = CType(MyBase.NewRow(), DataSetLoyaltyCard.DataTable1Row)
				Dim array As Object() = New Object() { CustomerID, Name, Address, ContactNo, Column5, Column6 }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x0600EAF8 RID: 60152 RVA: 0x008DC758 File Offset: 0x008DA958
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As DataSetLoyaltyCard.DataTable1DataTable = CType(MyBase.Clone(), DataSetLoyaltyCard.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x0600EAF9 RID: 60153 RVA: 0x008DC780 File Offset: 0x008DA980
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetLoyaltyCard.DataTable1DataTable()
			End Function

			' Token: 0x0600EAFA RID: 60154 RVA: 0x008DC798 File Offset: 0x008DA998
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnCustomerID = MyBase.Columns("CustomerID")
				Me.columnName = MyBase.Columns("Name")
				Me.columnAddress = MyBase.Columns("Address")
				Me.columnContactNo = MyBase.Columns("ContactNo")
				Me.columnColumn5 = MyBase.Columns("Column5")
				Me.columnColumn6 = MyBase.Columns("Column6")
			End Sub

			' Token: 0x0600EAFB RID: 60155 RVA: 0x008DC82C File Offset: 0x008DAA2C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnCustomerID = New DataColumn("CustomerID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCustomerID)
				Me.columnName = New DataColumn("Name", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnName)
				Me.columnAddress = New DataColumn("Address", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAddress)
				Me.columnContactNo = New DataColumn("ContactNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnContactNo)
				Me.columnColumn5 = New DataColumn("Column5", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnColumn5)
				Me.columnColumn6 = New DataColumn("Column6", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnColumn6)
			End Sub

			' Token: 0x0600EAFC RID: 60156 RVA: 0x008DC950 File Offset: 0x008DAB50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As DataSetLoyaltyCard.DataTable1Row
				Return CType(MyBase.NewRow(), DataSetLoyaltyCard.DataTable1Row)
			End Function

			' Token: 0x0600EAFD RID: 60157 RVA: 0x008DC970 File Offset: 0x008DAB70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetLoyaltyCard.DataTable1Row(builder)
			End Function

			' Token: 0x0600EAFE RID: 60158 RVA: 0x008DC988 File Offset: 0x008DAB88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetLoyaltyCard.DataTable1Row)
			End Function

			' Token: 0x0600EAFF RID: 60159 RVA: 0x008DC9A4 File Offset: 0x008DABA4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As DataSetLoyaltyCard.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New DataSetLoyaltyCard.DataTable1RowChangeEvent(CType(e.Row, DataSetLoyaltyCard.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EB00 RID: 60160 RVA: 0x008DC9F4 File Offset: 0x008DABF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As DataSetLoyaltyCard.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New DataSetLoyaltyCard.DataTable1RowChangeEvent(CType(e.Row, DataSetLoyaltyCard.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EB01 RID: 60161 RVA: 0x008DCA44 File Offset: 0x008DAC44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As DataSetLoyaltyCard.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New DataSetLoyaltyCard.DataTable1RowChangeEvent(CType(e.Row, DataSetLoyaltyCard.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EB02 RID: 60162 RVA: 0x008DCA94 File Offset: 0x008DAC94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As DataSetLoyaltyCard.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New DataSetLoyaltyCard.DataTable1RowChangeEvent(CType(e.Row, DataSetLoyaltyCard.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EB03 RID: 60163 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As DataSetLoyaltyCard.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600EB04 RID: 60164 RVA: 0x008DCAE4 File Offset: 0x008DACE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetLoyaltyCard As DataSetLoyaltyCard = New DataSetLoyaltyCard()
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
				xmlSchemaAttribute.FixedValue = dataSetLoyaltyCard.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetLoyaltyCard.GetSchemaSerializable()
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

			' Token: 0x040059D0 RID: 22992
			Private columnCustomerID As DataColumn

			' Token: 0x040059D1 RID: 22993
			Private columnName As DataColumn

			' Token: 0x040059D2 RID: 22994
			Private columnAddress As DataColumn

			' Token: 0x040059D3 RID: 22995
			Private columnContactNo As DataColumn

			' Token: 0x040059D4 RID: 22996
			Private columnColumn5 As DataColumn

			' Token: 0x040059D5 RID: 22997
			Private columnColumn6 As DataColumn
		End Class

		' Token: 0x0200049C RID: 1180
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x0600EB05 RID: 60165 RVA: 0x00066EAC File Offset: 0x000650AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, DataSetLoyaltyCard.DataTable1DataTable)
			End Sub

			' Token: 0x17005A3E RID: 23102
			' (get) Token: 0x0600EB06 RID: 60166 RVA: 0x008DCD38 File Offset: 0x008DAF38
			' (set) Token: 0x0600EB07 RID: 60167 RVA: 0x00066EC8 File Offset: 0x000650C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CustomerID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CustomerIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CustomerID' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CustomerIDColumn) = value
				End Set
			End Property

			' Token: 0x17005A3F RID: 23103
			' (get) Token: 0x0600EB08 RID: 60168 RVA: 0x008DCD88 File Offset: 0x008DAF88
			' (set) Token: 0x0600EB09 RID: 60169 RVA: 0x00066EDE File Offset: 0x000650DE
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

			' Token: 0x17005A40 RID: 23104
			' (get) Token: 0x0600EB0A RID: 60170 RVA: 0x008DCDD8 File Offset: 0x008DAFD8
			' (set) Token: 0x0600EB0B RID: 60171 RVA: 0x00066EF4 File Offset: 0x000650F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Address As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.AddressColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Address' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.AddressColumn) = value
				End Set
			End Property

			' Token: 0x17005A41 RID: 23105
			' (get) Token: 0x0600EB0C RID: 60172 RVA: 0x008DCE28 File Offset: 0x008DB028
			' (set) Token: 0x0600EB0D RID: 60173 RVA: 0x00066F0A File Offset: 0x0006510A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ContactNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.ContactNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ContactNo' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.ContactNoColumn) = value
				End Set
			End Property

			' Token: 0x17005A42 RID: 23106
			' (get) Token: 0x0600EB0E RID: 60174 RVA: 0x008DCE78 File Offset: 0x008DB078
			' (set) Token: 0x0600EB0F RID: 60175 RVA: 0x00066F20 File Offset: 0x00065120
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Column5 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.Column5Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Column5' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.Column5Column) = value
				End Set
			End Property

			' Token: 0x17005A43 RID: 23107
			' (get) Token: 0x0600EB10 RID: 60176 RVA: 0x008DCEC8 File Offset: 0x008DB0C8
			' (set) Token: 0x0600EB11 RID: 60177 RVA: 0x00066F36 File Offset: 0x00065136
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Column6 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.Column6Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Column6' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.Column6Column) = value
				End Set
			End Property

			' Token: 0x0600EB12 RID: 60178 RVA: 0x008DCF18 File Offset: 0x008DB118
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCustomerIDNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CustomerIDColumn)
			End Function

			' Token: 0x0600EB13 RID: 60179 RVA: 0x00066F4C File Offset: 0x0006514C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCustomerIDNull()
				MyBase.Item(Me.tableDataTable1.CustomerIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB14 RID: 60180 RVA: 0x008DCF3C File Offset: 0x008DB13C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.NameColumn)
			End Function

			' Token: 0x0600EB15 RID: 60181 RVA: 0x00066F6B File Offset: 0x0006516B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetNameNull()
				MyBase.Item(Me.tableDataTable1.NameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB16 RID: 60182 RVA: 0x008DCF60 File Offset: 0x008DB160
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAddressNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.AddressColumn)
			End Function

			' Token: 0x0600EB17 RID: 60183 RVA: 0x00066F8A File Offset: 0x0006518A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAddressNull()
				MyBase.Item(Me.tableDataTable1.AddressColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB18 RID: 60184 RVA: 0x008DCF84 File Offset: 0x008DB184
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsContactNoNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ContactNoColumn)
			End Function

			' Token: 0x0600EB19 RID: 60185 RVA: 0x00066FA9 File Offset: 0x000651A9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetContactNoNull()
				MyBase.Item(Me.tableDataTable1.ContactNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB1A RID: 60186 RVA: 0x008DCFA8 File Offset: 0x008DB1A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsColumn5Null() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.Column5Column)
			End Function

			' Token: 0x0600EB1B RID: 60187 RVA: 0x00066FC8 File Offset: 0x000651C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetColumn5Null()
				MyBase.Item(Me.tableDataTable1.Column5Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB1C RID: 60188 RVA: 0x008DCFCC File Offset: 0x008DB1CC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsColumn6Null() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.Column6Column)
			End Function

			' Token: 0x0600EB1D RID: 60189 RVA: 0x00066FE7 File Offset: 0x000651E7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetColumn6Null()
				MyBase.Item(Me.tableDataTable1.Column6Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040059DA RID: 23002
			Private tableDataTable1 As DataSetLoyaltyCard.DataTable1DataTable
		End Class

		' Token: 0x0200049D RID: 1181
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600EB1E RID: 60190 RVA: 0x00067006 File Offset: 0x00065206
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetLoyaltyCard.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17005A44 RID: 23108
			' (get) Token: 0x0600EB1F RID: 60191 RVA: 0x008DCFF0 File Offset: 0x008DB1F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetLoyaltyCard.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17005A45 RID: 23109
			' (get) Token: 0x0600EB20 RID: 60192 RVA: 0x008DD008 File Offset: 0x008DB208
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040059DB RID: 23003
			Private eventRow As DataSetLoyaltyCard.DataTable1Row

			' Token: 0x040059DC RID: 23004
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
