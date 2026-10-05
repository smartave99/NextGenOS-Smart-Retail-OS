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
	' Token: 0x0200028D RID: 653
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSetLedgerBook")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSetLedgerBook
		Inherits DataSet

		' Token: 0x0600A6FF RID: 42751 RVA: 0x00700E58 File Offset: 0x006FF058
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

		' Token: 0x0600A700 RID: 42752 RVA: 0x00700EB0 File Offset: 0x006FF0B0
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
						MyBase.Tables.Add(New DataSetLedgerBook.Table1DataTable(dataSet.Tables("Table1")))
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

		' Token: 0x170040CE RID: 16590
		' (get) Token: 0x0600A701 RID: 42753 RVA: 0x00701044 File Offset: 0x006FF244
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property Table1 As DataSetLedgerBook.Table1DataTable
			Get
				Return Me.tableTable1
			End Get
		End Property

		' Token: 0x170040CF RID: 16591
		' (get) Token: 0x0600A702 RID: 42754 RVA: 0x0070105C File Offset: 0x006FF25C
		' (set) Token: 0x0600A703 RID: 42755 RVA: 0x0004DFDC File Offset: 0x0004C1DC
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

		' Token: 0x170040D0 RID: 16592
		' (get) Token: 0x0600A704 RID: 42756 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x170040D1 RID: 16593
		' (get) Token: 0x0600A705 RID: 42757 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x0600A706 RID: 42758 RVA: 0x0004DFE6 File Offset: 0x0004C1E6
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x0600A707 RID: 42759 RVA: 0x00701074 File Offset: 0x006FF274
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSetLedgerBook As DataSetLedgerBook = CType(MyBase.Clone(), DataSetLedgerBook)
			dataSetLedgerBook.InitVars()
			dataSetLedgerBook.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSetLedgerBook
		End Function

		' Token: 0x0600A708 RID: 42760 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x0600A709 RID: 42761 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x0600A70A RID: 42762 RVA: 0x007010A8 File Offset: 0x006FF2A8
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
					MyBase.Tables.Add(New DataSetLedgerBook.Table1DataTable(dataSet.Tables("Table1")))
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

		' Token: 0x0600A70B RID: 42763 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x0600A70C RID: 42764 RVA: 0x0004DFFE File Offset: 0x0004C1FE
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x0600A70D RID: 42765 RVA: 0x0070118C File Offset: 0x006FF38C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableTable1 = CType(MyBase.Tables("Table1"), DataSetLedgerBook.Table1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableTable1 IsNot Nothing
				If flag Then
					Me.tableTable1.InitVars()
				End If
			End If
		End Sub

		' Token: 0x0600A70E RID: 42766 RVA: 0x007011D8 File Offset: 0x006FF3D8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSetLedgerBook"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSetLedgerBook.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableTable1 = New DataSetLedgerBook.Table1DataTable()
			MyBase.Tables.Add(Me.tableTable1)
		End Sub

		' Token: 0x0600A70F RID: 42767 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeTable1() As Boolean
			Return False
		End Function

		' Token: 0x0600A710 RID: 42768 RVA: 0x00701238 File Offset: 0x006FF438
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x0600A711 RID: 42769 RVA: 0x0070125C File Offset: 0x006FF45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSetLedgerBook As DataSetLedgerBook = New DataSetLedgerBook()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSetLedgerBook.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSetLedgerBook.GetSchemaSerializable()
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

		' Token: 0x040045B1 RID: 17841
		Private tableTable1 As DataSetLedgerBook.Table1DataTable

		' Token: 0x040045B2 RID: 17842
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x0200028E RID: 654
		' (Invoke) Token: 0x0600A715 RID: 42773
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub Table1RowChangeEventHandler(sender As Object, e As DataSetLedgerBook.Table1RowChangeEvent)

		' Token: 0x0200028F RID: 655
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class Table1DataTable
			Inherits TypedTableBase(Of DataSetLedgerBook.Table1Row)

			' Token: 0x0600A716 RID: 42774 RVA: 0x0004E009 File Offset: 0x0004C209
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "Table1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600A717 RID: 42775 RVA: 0x007013F0 File Offset: 0x006FF5F0
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

			' Token: 0x0600A718 RID: 42776 RVA: 0x0004E034 File Offset: 0x0004C234
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x170040D2 RID: 16594
			' (get) Token: 0x0600A719 RID: 42777 RVA: 0x007014BC File Offset: 0x006FF6BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DateColumn As DataColumn
				Get
					Return Me.columnDate
				End Get
			End Property

			' Token: 0x170040D3 RID: 16595
			' (get) Token: 0x0600A71A RID: 42778 RVA: 0x007014D4 File Offset: 0x006FF6D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property NameColumn As DataColumn
				Get
					Return Me.columnName
				End Get
			End Property

			' Token: 0x170040D4 RID: 16596
			' (get) Token: 0x0600A71B RID: 42779 RVA: 0x007014EC File Offset: 0x006FF6EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property LedgerNoColumn As DataColumn
				Get
					Return Me.columnLedgerNo
				End Get
			End Property

			' Token: 0x170040D5 RID: 16597
			' (get) Token: 0x0600A71C RID: 42780 RVA: 0x00701504 File Offset: 0x006FF704
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property LabelColumn As DataColumn
				Get
					Return Me.columnLabel
				End Get
			End Property

			' Token: 0x170040D6 RID: 16598
			' (get) Token: 0x0600A71D RID: 42781 RVA: 0x0070151C File Offset: 0x006FF71C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CreditColumn As DataColumn
				Get
					Return Me.columnCredit
				End Get
			End Property

			' Token: 0x170040D7 RID: 16599
			' (get) Token: 0x0600A71E RID: 42782 RVA: 0x00701534 File Offset: 0x006FF734
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DebitColumn As DataColumn
				Get
					Return Me.columnDebit
				End Get
			End Property

			' Token: 0x170040D8 RID: 16600
			' (get) Token: 0x0600A71F RID: 42783 RVA: 0x0070154C File Offset: 0x006FF74C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RemarksColumn As DataColumn
				Get
					Return Me.columnRemarks
				End Get
			End Property

			' Token: 0x170040D9 RID: 16601
			' (get) Token: 0x0600A720 RID: 42784 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x170040DA RID: 16602
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetLedgerBook.Table1Row
				Get
					Return CType(MyBase.Rows(index), DataSetLedgerBook.Table1Row)
				End Get
			End Property

			' Token: 0x1400004C RID: 76
			' (add) Token: 0x0600A722 RID: 42786 RVA: 0x00701588 File Offset: 0x006FF788
			' (remove) Token: 0x0600A723 RID: 42787 RVA: 0x007015C0 File Offset: 0x006FF7C0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event Table1RowChanging As DataSetLedgerBook.Table1RowChangeEventHandler

			' Token: 0x1400004D RID: 77
			' (add) Token: 0x0600A724 RID: 42788 RVA: 0x007015F8 File Offset: 0x006FF7F8
			' (remove) Token: 0x0600A725 RID: 42789 RVA: 0x00701630 File Offset: 0x006FF830
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event Table1RowChanged As DataSetLedgerBook.Table1RowChangeEventHandler

			' Token: 0x1400004E RID: 78
			' (add) Token: 0x0600A726 RID: 42790 RVA: 0x00701668 File Offset: 0x006FF868
			' (remove) Token: 0x0600A727 RID: 42791 RVA: 0x007016A0 File Offset: 0x006FF8A0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event Table1RowDeleting As DataSetLedgerBook.Table1RowChangeEventHandler

			' Token: 0x1400004F RID: 79
			' (add) Token: 0x0600A728 RID: 42792 RVA: 0x007016D8 File Offset: 0x006FF8D8
			' (remove) Token: 0x0600A729 RID: 42793 RVA: 0x00701710 File Offset: 0x006FF910
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event Table1RowDeleted As DataSetLedgerBook.Table1RowChangeEventHandler

			' Token: 0x0600A72A RID: 42794 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddTable1Row(row As DataSetLedgerBook.Table1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600A72B RID: 42795 RVA: 0x00701748 File Offset: 0x006FF948
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddTable1Row(_Date As DateTime, Name As String, LedgerNo As String, Label As String, Credit As String, Debit As String, Remarks As String) As DataSetLedgerBook.Table1Row
				Dim table1Row As DataSetLedgerBook.Table1Row = CType(MyBase.NewRow(), DataSetLedgerBook.Table1Row)
				Dim array As Object() = New Object() { _Date, Name, LedgerNo, Label, Credit, Debit, Remarks }
				table1Row.ItemArray = array
				MyBase.Rows.Add(table1Row)
				Return table1Row
			End Function

			' Token: 0x0600A72C RID: 42796 RVA: 0x007017A8 File Offset: 0x006FF9A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim table1DataTable As DataSetLedgerBook.Table1DataTable = CType(MyBase.Clone(), DataSetLedgerBook.Table1DataTable)
				table1DataTable.InitVars()
				Return table1DataTable
			End Function

			' Token: 0x0600A72D RID: 42797 RVA: 0x007017D0 File Offset: 0x006FF9D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetLedgerBook.Table1DataTable()
			End Function

			' Token: 0x0600A72E RID: 42798 RVA: 0x007017E8 File Offset: 0x006FF9E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnDate = MyBase.Columns("Date")
				Me.columnName = MyBase.Columns("Name")
				Me.columnLedgerNo = MyBase.Columns("LedgerNo")
				Me.columnLabel = MyBase.Columns("Label")
				Me.columnCredit = MyBase.Columns("Credit")
				Me.columnDebit = MyBase.Columns("Debit")
				Me.columnRemarks = MyBase.Columns("Remarks")
			End Sub

			' Token: 0x0600A72F RID: 42799 RVA: 0x00701890 File Offset: 0x006FFA90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnDate = New DataColumn("Date", GetType(DateTime), Nothing, MappingType.Element)
				Me.columnDate.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "DateColumn")
				Me.columnDate.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnDate")
				Me.columnDate.ExtendedProperties.Add("Generator_UserColumnName", "Date")
				MyBase.Columns.Add(Me.columnDate)
				Me.columnName = New DataColumn("Name", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnName)
				Me.columnLedgerNo = New DataColumn("LedgerNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnLedgerNo)
				Me.columnLabel = New DataColumn("Label", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnLabel)
				Me.columnCredit = New DataColumn("Credit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCredit)
				Me.columnDebit = New DataColumn("Debit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDebit)
				Me.columnRemarks = New DataColumn("Remarks", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRemarks)
			End Sub

			' Token: 0x0600A730 RID: 42800 RVA: 0x00701A34 File Offset: 0x006FFC34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewTable1Row() As DataSetLedgerBook.Table1Row
				Return CType(MyBase.NewRow(), DataSetLedgerBook.Table1Row)
			End Function

			' Token: 0x0600A731 RID: 42801 RVA: 0x00701A54 File Offset: 0x006FFC54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetLedgerBook.Table1Row(builder)
			End Function

			' Token: 0x0600A732 RID: 42802 RVA: 0x00701A6C File Offset: 0x006FFC6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetLedgerBook.Table1Row)
			End Function

			' Token: 0x0600A733 RID: 42803 RVA: 0x00701A88 File Offset: 0x006FFC88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.Table1RowChangedEvent IsNot Nothing
				If flag Then
					Dim table1RowChangedEvent As DataSetLedgerBook.Table1RowChangeEventHandler = Me.Table1RowChangedEvent
					If table1RowChangedEvent IsNot Nothing Then
						table1RowChangedEvent(Me, New DataSetLedgerBook.Table1RowChangeEvent(CType(e.Row, DataSetLedgerBook.Table1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A734 RID: 42804 RVA: 0x00701AD8 File Offset: 0x006FFCD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.Table1RowChangingEvent IsNot Nothing
				If flag Then
					Dim table1RowChangingEvent As DataSetLedgerBook.Table1RowChangeEventHandler = Me.Table1RowChangingEvent
					If table1RowChangingEvent IsNot Nothing Then
						table1RowChangingEvent(Me, New DataSetLedgerBook.Table1RowChangeEvent(CType(e.Row, DataSetLedgerBook.Table1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A735 RID: 42805 RVA: 0x00701B28 File Offset: 0x006FFD28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.Table1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim table1RowDeletedEvent As DataSetLedgerBook.Table1RowChangeEventHandler = Me.Table1RowDeletedEvent
					If table1RowDeletedEvent IsNot Nothing Then
						table1RowDeletedEvent(Me, New DataSetLedgerBook.Table1RowChangeEvent(CType(e.Row, DataSetLedgerBook.Table1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A736 RID: 42806 RVA: 0x00701B78 File Offset: 0x006FFD78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.Table1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim table1RowDeletingEvent As DataSetLedgerBook.Table1RowChangeEventHandler = Me.Table1RowDeletingEvent
					If table1RowDeletingEvent IsNot Nothing Then
						table1RowDeletingEvent(Me, New DataSetLedgerBook.Table1RowChangeEvent(CType(e.Row, DataSetLedgerBook.Table1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A737 RID: 42807 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveTable1Row(row As DataSetLedgerBook.Table1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600A738 RID: 42808 RVA: 0x00701BC8 File Offset: 0x006FFDC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetLedgerBook As DataSetLedgerBook = New DataSetLedgerBook()
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
				xmlSchemaAttribute.FixedValue = dataSetLedgerBook.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "Table1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetLedgerBook.GetSchemaSerializable()
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

			' Token: 0x040045B3 RID: 17843
			Private columnDate As DataColumn

			' Token: 0x040045B4 RID: 17844
			Private columnName As DataColumn

			' Token: 0x040045B5 RID: 17845
			Private columnLedgerNo As DataColumn

			' Token: 0x040045B6 RID: 17846
			Private columnLabel As DataColumn

			' Token: 0x040045B7 RID: 17847
			Private columnCredit As DataColumn

			' Token: 0x040045B8 RID: 17848
			Private columnDebit As DataColumn

			' Token: 0x040045B9 RID: 17849
			Private columnRemarks As DataColumn
		End Class

		' Token: 0x02000290 RID: 656
		Public Class Table1Row
			Inherits DataRow

			' Token: 0x0600A739 RID: 42809 RVA: 0x0004E047 File Offset: 0x0004C247
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableTable1 = CType(MyBase.Table, DataSetLedgerBook.Table1DataTable)
			End Sub

			' Token: 0x170040DB RID: 16603
			' (get) Token: 0x0600A73A RID: 42810 RVA: 0x00701E1C File Offset: 0x0070001C
			' (set) Token: 0x0600A73B RID: 42811 RVA: 0x0004E063 File Offset: 0x0004C263
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property _Date As DateTime
				Get
					Dim dateTime As DateTime
					Try
						dateTime = Conversions.ToDate(MyBase.Item(Me.tableTable1.DateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Date' in table 'Table1' is DBNull.", ex)
					End Try
					Return dateTime
				End Get
				Set(value As DateTime)
					MyBase.Item(Me.tableTable1.DateColumn) = value
				End Set
			End Property

			' Token: 0x170040DC RID: 16604
			' (get) Token: 0x0600A73C RID: 42812 RVA: 0x00701E6C File Offset: 0x0070006C
			' (set) Token: 0x0600A73D RID: 42813 RVA: 0x0004E07E File Offset: 0x0004C27E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Name As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableTable1.NameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Name' in table 'Table1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableTable1.NameColumn) = value
				End Set
			End Property

			' Token: 0x170040DD RID: 16605
			' (get) Token: 0x0600A73E RID: 42814 RVA: 0x00701EBC File Offset: 0x007000BC
			' (set) Token: 0x0600A73F RID: 42815 RVA: 0x0004E094 File Offset: 0x0004C294
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property LedgerNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableTable1.LedgerNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'LedgerNo' in table 'Table1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableTable1.LedgerNoColumn) = value
				End Set
			End Property

			' Token: 0x170040DE RID: 16606
			' (get) Token: 0x0600A740 RID: 42816 RVA: 0x00701F0C File Offset: 0x0070010C
			' (set) Token: 0x0600A741 RID: 42817 RVA: 0x0004E0AA File Offset: 0x0004C2AA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Label As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableTable1.LabelColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Label' in table 'Table1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableTable1.LabelColumn) = value
				End Set
			End Property

			' Token: 0x170040DF RID: 16607
			' (get) Token: 0x0600A742 RID: 42818 RVA: 0x00701F5C File Offset: 0x0070015C
			' (set) Token: 0x0600A743 RID: 42819 RVA: 0x0004E0C0 File Offset: 0x0004C2C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Credit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableTable1.CreditColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Credit' in table 'Table1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableTable1.CreditColumn) = value
				End Set
			End Property

			' Token: 0x170040E0 RID: 16608
			' (get) Token: 0x0600A744 RID: 42820 RVA: 0x00701FAC File Offset: 0x007001AC
			' (set) Token: 0x0600A745 RID: 42821 RVA: 0x0004E0D6 File Offset: 0x0004C2D6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Debit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableTable1.DebitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Debit' in table 'Table1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableTable1.DebitColumn) = value
				End Set
			End Property

			' Token: 0x170040E1 RID: 16609
			' (get) Token: 0x0600A746 RID: 42822 RVA: 0x00701FFC File Offset: 0x007001FC
			' (set) Token: 0x0600A747 RID: 42823 RVA: 0x0004E0EC File Offset: 0x0004C2EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Remarks As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableTable1.RemarksColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Remarks' in table 'Table1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableTable1.RemarksColumn) = value
				End Set
			End Property

			' Token: 0x0600A748 RID: 42824 RVA: 0x0070204C File Offset: 0x0070024C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function Is_DateNull() As Boolean
				Return MyBase.IsNull(Me.tableTable1.DateColumn)
			End Function

			' Token: 0x0600A749 RID: 42825 RVA: 0x0004E102 File Offset: 0x0004C302
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub Set_DateNull()
				MyBase.Item(Me.tableTable1.DateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A74A RID: 42826 RVA: 0x00702070 File Offset: 0x00700270
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsNameNull() As Boolean
				Return MyBase.IsNull(Me.tableTable1.NameColumn)
			End Function

			' Token: 0x0600A74B RID: 42827 RVA: 0x0004E121 File Offset: 0x0004C321
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetNameNull()
				MyBase.Item(Me.tableTable1.NameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A74C RID: 42828 RVA: 0x00702094 File Offset: 0x00700294
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsLedgerNoNull() As Boolean
				Return MyBase.IsNull(Me.tableTable1.LedgerNoColumn)
			End Function

			' Token: 0x0600A74D RID: 42829 RVA: 0x0004E140 File Offset: 0x0004C340
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetLedgerNoNull()
				MyBase.Item(Me.tableTable1.LedgerNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A74E RID: 42830 RVA: 0x007020B8 File Offset: 0x007002B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsLabelNull() As Boolean
				Return MyBase.IsNull(Me.tableTable1.LabelColumn)
			End Function

			' Token: 0x0600A74F RID: 42831 RVA: 0x0004E15F File Offset: 0x0004C35F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetLabelNull()
				MyBase.Item(Me.tableTable1.LabelColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A750 RID: 42832 RVA: 0x007020DC File Offset: 0x007002DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCreditNull() As Boolean
				Return MyBase.IsNull(Me.tableTable1.CreditColumn)
			End Function

			' Token: 0x0600A751 RID: 42833 RVA: 0x0004E17E File Offset: 0x0004C37E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCreditNull()
				MyBase.Item(Me.tableTable1.CreditColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A752 RID: 42834 RVA: 0x00702100 File Offset: 0x00700300
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDebitNull() As Boolean
				Return MyBase.IsNull(Me.tableTable1.DebitColumn)
			End Function

			' Token: 0x0600A753 RID: 42835 RVA: 0x0004E19D File Offset: 0x0004C39D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDebitNull()
				MyBase.Item(Me.tableTable1.DebitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A754 RID: 42836 RVA: 0x00702124 File Offset: 0x00700324
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRemarksNull() As Boolean
				Return MyBase.IsNull(Me.tableTable1.RemarksColumn)
			End Function

			' Token: 0x0600A755 RID: 42837 RVA: 0x0004E1BC File Offset: 0x0004C3BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRemarksNull()
				MyBase.Item(Me.tableTable1.RemarksColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040045BE RID: 17854
			Private tableTable1 As DataSetLedgerBook.Table1DataTable
		End Class

		' Token: 0x02000291 RID: 657
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class Table1RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600A756 RID: 42838 RVA: 0x0004E1DB File Offset: 0x0004C3DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetLedgerBook.Table1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x170040E2 RID: 16610
			' (get) Token: 0x0600A757 RID: 42839 RVA: 0x00702148 File Offset: 0x00700348
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetLedgerBook.Table1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x170040E3 RID: 16611
			' (get) Token: 0x0600A758 RID: 42840 RVA: 0x00702160 File Offset: 0x00700360
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040045BF RID: 17855
			Private eventRow As DataSetLedgerBook.Table1Row

			' Token: 0x040045C0 RID: 17856
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
