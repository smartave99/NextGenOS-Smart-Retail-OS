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
	' Token: 0x0200001F RID: 31
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSet1")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSet1
		Inherits DataSet

		' Token: 0x060007B5 RID: 1973 RVA: 0x0009FF94 File Offset: 0x0009E194
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

		' Token: 0x060007B6 RID: 1974 RVA: 0x0009FFEC File Offset: 0x0009E1EC
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
						MyBase.Tables.Add(New DataSet1.DataTable1DataTable(dataSet.Tables("DataTable1")))
					End If
					Dim flag4 As Boolean = dataSet.Tables("GetQr") IsNot Nothing
					If flag4 Then
						MyBase.Tables.Add(New DataSet1.GetQrDataTable(dataSet.Tables("GetQr")))
					End If
					Dim flag5 As Boolean = dataSet.Tables("CustomerQr") IsNot Nothing
					If flag5 Then
						MyBase.Tables.Add(New DataSet1.CustomerQrDataTable(dataSet.Tables("CustomerQr")))
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

		' Token: 0x170003C0 RID: 960
		' (get) Token: 0x060007B7 RID: 1975 RVA: 0x000A01FC File Offset: 0x0009E3FC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As DataSet1.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x170003C1 RID: 961
		' (get) Token: 0x060007B8 RID: 1976 RVA: 0x000A0214 File Offset: 0x0009E414
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property GetQr As DataSet1.GetQrDataTable
			Get
				Return Me.tableGetQr
			End Get
		End Property

		' Token: 0x170003C2 RID: 962
		' (get) Token: 0x060007B9 RID: 1977 RVA: 0x000A022C File Offset: 0x0009E42C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property CustomerQr As DataSet1.CustomerQrDataTable
			Get
				Return Me.tableCustomerQr
			End Get
		End Property

		' Token: 0x170003C3 RID: 963
		' (get) Token: 0x060007BA RID: 1978 RVA: 0x000A0244 File Offset: 0x0009E444
		' (set) Token: 0x060007BB RID: 1979 RVA: 0x0000A270 File Offset: 0x00008470
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

		' Token: 0x170003C4 RID: 964
		' (get) Token: 0x060007BC RID: 1980 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x170003C5 RID: 965
		' (get) Token: 0x060007BD RID: 1981 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x060007BE RID: 1982 RVA: 0x0000A27A File Offset: 0x0000847A
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x060007BF RID: 1983 RVA: 0x000A028C File Offset: 0x0009E48C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSet As DataSet1 = CType(MyBase.Clone(), DataSet1)
			dataSet.InitVars()
			dataSet.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSet
		End Function

		' Token: 0x060007C0 RID: 1984 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x060007C1 RID: 1985 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x060007C2 RID: 1986 RVA: 0x000A02D4 File Offset: 0x0009E4D4
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
					MyBase.Tables.Add(New DataSet1.DataTable1DataTable(dataSet.Tables("DataTable1")))
				End If
				Dim flag3 As Boolean = dataSet.Tables("GetQr") IsNot Nothing
				If flag3 Then
					MyBase.Tables.Add(New DataSet1.GetQrDataTable(dataSet.Tables("GetQr")))
				End If
				Dim flag4 As Boolean = dataSet.Tables("CustomerQr") IsNot Nothing
				If flag4 Then
					MyBase.Tables.Add(New DataSet1.CustomerQrDataTable(dataSet.Tables("CustomerQr")))
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

		' Token: 0x060007C3 RID: 1987 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x060007C4 RID: 1988 RVA: 0x0000A292 File Offset: 0x00008492
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x060007C5 RID: 1989 RVA: 0x000A0468 File Offset: 0x0009E668
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), DataSet1.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
			Me.tableGetQr = CType(MyBase.Tables("GetQr"), DataSet1.GetQrDataTable)
			If initTable Then
				Dim flag2 As Boolean = Me.tableGetQr IsNot Nothing
				If flag2 Then
					Me.tableGetQr.InitVars()
				End If
			End If
			Me.tableCustomerQr = CType(MyBase.Tables("CustomerQr"), DataSet1.CustomerQrDataTable)
			If initTable Then
				Dim flag3 As Boolean = Me.tableCustomerQr IsNot Nothing
				If flag3 Then
					Me.tableCustomerQr.InitVars()
				End If
			End If
		End Sub

		' Token: 0x060007C6 RID: 1990 RVA: 0x000A0534 File Offset: 0x0009E734
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSet1"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSet1.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New DataSet1.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
			Me.tableGetQr = New DataSet1.GetQrDataTable()
			MyBase.Tables.Add(Me.tableGetQr)
			Me.tableCustomerQr = New DataSet1.CustomerQrDataTable()
			MyBase.Tables.Add(Me.tableCustomerQr)
		End Sub

		' Token: 0x060007C7 RID: 1991 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x060007C8 RID: 1992 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeGetQr() As Boolean
			Return False
		End Function

		' Token: 0x060007C9 RID: 1993 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeCustomerQr() As Boolean
			Return False
		End Function

		' Token: 0x060007CA RID: 1994 RVA: 0x000A05D0 File Offset: 0x0009E7D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x060007CB RID: 1995 RVA: 0x000A05F4 File Offset: 0x0009E7F4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSet As DataSet1 = New DataSet1()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSet.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSet.GetSchemaSerializable()
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

		' Token: 0x040002E1 RID: 737
		Private tableDataTable1 As DataSet1.DataTable1DataTable

		' Token: 0x040002E2 RID: 738
		Private tableGetQr As DataSet1.GetQrDataTable

		' Token: 0x040002E3 RID: 739
		Private tableCustomerQr As DataSet1.CustomerQrDataTable

		' Token: 0x040002E4 RID: 740
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x02000020 RID: 32
		' (Invoke) Token: 0x060007CF RID: 1999
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As DataSet1.DataTable1RowChangeEvent)

		' Token: 0x02000021 RID: 33
		' (Invoke) Token: 0x060007D3 RID: 2003
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub GetQrRowChangeEventHandler(sender As Object, e As DataSet1.GetQrRowChangeEvent)

		' Token: 0x02000022 RID: 34
		' (Invoke) Token: 0x060007D7 RID: 2007
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub CustomerQrRowChangeEventHandler(sender As Object, e As DataSet1.CustomerQrRowChangeEvent)

		' Token: 0x02000023 RID: 35
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of DataSet1.DataTable1Row)

			' Token: 0x060007D8 RID: 2008 RVA: 0x0000A29D File Offset: 0x0000849D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x060007D9 RID: 2009 RVA: 0x000A0788 File Offset: 0x0009E988
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

			' Token: 0x060007DA RID: 2010 RVA: 0x0000A2C8 File Offset: 0x000084C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x170003C6 RID: 966
			' (get) Token: 0x060007DB RID: 2011 RVA: 0x000A0854 File Offset: 0x0009EA54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property imgColumn As DataColumn
				Get
					Return Me.columnimg
				End Get
			End Property

			' Token: 0x170003C7 RID: 967
			' (get) Token: 0x060007DC RID: 2012 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x170003C8 RID: 968
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSet1.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), DataSet1.DataTable1Row)
				End Get
			End Property

			' Token: 0x14000001 RID: 1
			' (add) Token: 0x060007DE RID: 2014 RVA: 0x000A08B0 File Offset: 0x0009EAB0
			' (remove) Token: 0x060007DF RID: 2015 RVA: 0x000A08E8 File Offset: 0x0009EAE8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As DataSet1.DataTable1RowChangeEventHandler

			' Token: 0x14000002 RID: 2
			' (add) Token: 0x060007E0 RID: 2016 RVA: 0x000A0920 File Offset: 0x0009EB20
			' (remove) Token: 0x060007E1 RID: 2017 RVA: 0x000A0958 File Offset: 0x0009EB58
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As DataSet1.DataTable1RowChangeEventHandler

			' Token: 0x14000003 RID: 3
			' (add) Token: 0x060007E2 RID: 2018 RVA: 0x000A0990 File Offset: 0x0009EB90
			' (remove) Token: 0x060007E3 RID: 2019 RVA: 0x000A09C8 File Offset: 0x0009EBC8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As DataSet1.DataTable1RowChangeEventHandler

			' Token: 0x14000004 RID: 4
			' (add) Token: 0x060007E4 RID: 2020 RVA: 0x000A0A00 File Offset: 0x0009EC00
			' (remove) Token: 0x060007E5 RID: 2021 RVA: 0x000A0A38 File Offset: 0x0009EC38
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As DataSet1.DataTable1RowChangeEventHandler

			' Token: 0x060007E6 RID: 2022 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As DataSet1.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x060007E7 RID: 2023 RVA: 0x000A0A70 File Offset: 0x0009EC70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(img As Byte()) As DataSet1.DataTable1Row
				Dim dataTable1Row As DataSet1.DataTable1Row = CType(MyBase.NewRow(), DataSet1.DataTable1Row)
				Dim array As Object() = New Object() { img }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x060007E8 RID: 2024 RVA: 0x000A0AB0 File Offset: 0x0009ECB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As DataSet1.DataTable1DataTable = CType(MyBase.Clone(), DataSet1.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x060007E9 RID: 2025 RVA: 0x000A0AD8 File Offset: 0x0009ECD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSet1.DataTable1DataTable()
			End Function

			' Token: 0x060007EA RID: 2026 RVA: 0x0000A2EB File Offset: 0x000084EB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnimg = MyBase.Columns("img")
			End Sub

			' Token: 0x060007EB RID: 2027 RVA: 0x0000A304 File Offset: 0x00008504
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnimg = New DataColumn("img", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnimg)
			End Sub

			' Token: 0x060007EC RID: 2028 RVA: 0x000A0AF0 File Offset: 0x0009ECF0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As DataSet1.DataTable1Row
				Return CType(MyBase.NewRow(), DataSet1.DataTable1Row)
			End Function

			' Token: 0x060007ED RID: 2029 RVA: 0x000A0B10 File Offset: 0x0009ED10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSet1.DataTable1Row(builder)
			End Function

			' Token: 0x060007EE RID: 2030 RVA: 0x000A0B28 File Offset: 0x0009ED28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSet1.DataTable1Row)
			End Function

			' Token: 0x060007EF RID: 2031 RVA: 0x000A0B44 File Offset: 0x0009ED44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As DataSet1.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New DataSet1.DataTable1RowChangeEvent(CType(e.Row, DataSet1.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x060007F0 RID: 2032 RVA: 0x000A0B94 File Offset: 0x0009ED94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As DataSet1.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New DataSet1.DataTable1RowChangeEvent(CType(e.Row, DataSet1.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x060007F1 RID: 2033 RVA: 0x000A0BE4 File Offset: 0x0009EDE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As DataSet1.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New DataSet1.DataTable1RowChangeEvent(CType(e.Row, DataSet1.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x060007F2 RID: 2034 RVA: 0x000A0C34 File Offset: 0x0009EE34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As DataSet1.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New DataSet1.DataTable1RowChangeEvent(CType(e.Row, DataSet1.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x060007F3 RID: 2035 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As DataSet1.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x060007F4 RID: 2036 RVA: 0x000A0C84 File Offset: 0x0009EE84
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSet As DataSet1 = New DataSet1()
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
				xmlSchemaAttribute.FixedValue = dataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSet.GetSchemaSerializable()
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

			' Token: 0x040002E5 RID: 741
			Private columnimg As DataColumn
		End Class

		' Token: 0x02000024 RID: 36
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class GetQrDataTable
			Inherits TypedTableBase(Of DataSet1.GetQrRow)

			' Token: 0x060007F5 RID: 2037 RVA: 0x0000A345 File Offset: 0x00008545
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "GetQr"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x060007F6 RID: 2038 RVA: 0x000A0ED8 File Offset: 0x0009F0D8
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

			' Token: 0x060007F7 RID: 2039 RVA: 0x0000A370 File Offset: 0x00008570
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x170003C9 RID: 969
			' (get) Token: 0x060007F8 RID: 2040 RVA: 0x000A0FA4 File Offset: 0x0009F1A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GiftCodeQrColumn As DataColumn
				Get
					Return Me.columnGiftCodeQr
				End Get
			End Property

			' Token: 0x170003CA RID: 970
			' (get) Token: 0x060007F9 RID: 2041 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x170003CB RID: 971
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSet1.GetQrRow
				Get
					Return CType(MyBase.Rows(index), DataSet1.GetQrRow)
				End Get
			End Property

			' Token: 0x14000005 RID: 5
			' (add) Token: 0x060007FB RID: 2043 RVA: 0x000A0FE0 File Offset: 0x0009F1E0
			' (remove) Token: 0x060007FC RID: 2044 RVA: 0x000A1018 File Offset: 0x0009F218
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event GetQrRowChanging As DataSet1.GetQrRowChangeEventHandler

			' Token: 0x14000006 RID: 6
			' (add) Token: 0x060007FD RID: 2045 RVA: 0x000A1050 File Offset: 0x0009F250
			' (remove) Token: 0x060007FE RID: 2046 RVA: 0x000A1088 File Offset: 0x0009F288
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event GetQrRowChanged As DataSet1.GetQrRowChangeEventHandler

			' Token: 0x14000007 RID: 7
			' (add) Token: 0x060007FF RID: 2047 RVA: 0x000A10C0 File Offset: 0x0009F2C0
			' (remove) Token: 0x06000800 RID: 2048 RVA: 0x000A10F8 File Offset: 0x0009F2F8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event GetQrRowDeleting As DataSet1.GetQrRowChangeEventHandler

			' Token: 0x14000008 RID: 8
			' (add) Token: 0x06000801 RID: 2049 RVA: 0x000A1130 File Offset: 0x0009F330
			' (remove) Token: 0x06000802 RID: 2050 RVA: 0x000A1168 File Offset: 0x0009F368
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event GetQrRowDeleted As DataSet1.GetQrRowChangeEventHandler

			' Token: 0x06000803 RID: 2051 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddGetQrRow(row As DataSet1.GetQrRow)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x06000804 RID: 2052 RVA: 0x000A11A0 File Offset: 0x0009F3A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddGetQrRow(GiftCodeQr As Byte()) As DataSet1.GetQrRow
				Dim getQrRow As DataSet1.GetQrRow = CType(MyBase.NewRow(), DataSet1.GetQrRow)
				Dim array As Object() = New Object() { GiftCodeQr }
				getQrRow.ItemArray = array
				MyBase.Rows.Add(getQrRow)
				Return getQrRow
			End Function

			' Token: 0x06000805 RID: 2053 RVA: 0x000A11E0 File Offset: 0x0009F3E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim getQrDataTable As DataSet1.GetQrDataTable = CType(MyBase.Clone(), DataSet1.GetQrDataTable)
				getQrDataTable.InitVars()
				Return getQrDataTable
			End Function

			' Token: 0x06000806 RID: 2054 RVA: 0x000A1208 File Offset: 0x0009F408
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSet1.GetQrDataTable()
			End Function

			' Token: 0x06000807 RID: 2055 RVA: 0x0000A383 File Offset: 0x00008583
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnGiftCodeQr = MyBase.Columns("GiftCodeQr")
			End Sub

			' Token: 0x06000808 RID: 2056 RVA: 0x0000A39C File Offset: 0x0000859C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnGiftCodeQr = New DataColumn("GiftCodeQr", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGiftCodeQr)
			End Sub

			' Token: 0x06000809 RID: 2057 RVA: 0x000A1220 File Offset: 0x0009F420
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewGetQrRow() As DataSet1.GetQrRow
				Return CType(MyBase.NewRow(), DataSet1.GetQrRow)
			End Function

			' Token: 0x0600080A RID: 2058 RVA: 0x000A1240 File Offset: 0x0009F440
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSet1.GetQrRow(builder)
			End Function

			' Token: 0x0600080B RID: 2059 RVA: 0x000A1258 File Offset: 0x0009F458
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSet1.GetQrRow)
			End Function

			' Token: 0x0600080C RID: 2060 RVA: 0x000A1274 File Offset: 0x0009F474
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.GetQrRowChangedEvent IsNot Nothing
				If flag Then
					Dim getQrRowChangedEvent As DataSet1.GetQrRowChangeEventHandler = Me.GetQrRowChangedEvent
					If getQrRowChangedEvent IsNot Nothing Then
						getQrRowChangedEvent(Me, New DataSet1.GetQrRowChangeEvent(CType(e.Row, DataSet1.GetQrRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600080D RID: 2061 RVA: 0x000A12C4 File Offset: 0x0009F4C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.GetQrRowChangingEvent IsNot Nothing
				If flag Then
					Dim getQrRowChangingEvent As DataSet1.GetQrRowChangeEventHandler = Me.GetQrRowChangingEvent
					If getQrRowChangingEvent IsNot Nothing Then
						getQrRowChangingEvent(Me, New DataSet1.GetQrRowChangeEvent(CType(e.Row, DataSet1.GetQrRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600080E RID: 2062 RVA: 0x000A1314 File Offset: 0x0009F514
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.GetQrRowDeletedEvent IsNot Nothing
				If flag Then
					Dim getQrRowDeletedEvent As DataSet1.GetQrRowChangeEventHandler = Me.GetQrRowDeletedEvent
					If getQrRowDeletedEvent IsNot Nothing Then
						getQrRowDeletedEvent(Me, New DataSet1.GetQrRowChangeEvent(CType(e.Row, DataSet1.GetQrRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600080F RID: 2063 RVA: 0x000A1364 File Offset: 0x0009F564
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.GetQrRowDeletingEvent IsNot Nothing
				If flag Then
					Dim getQrRowDeletingEvent As DataSet1.GetQrRowChangeEventHandler = Me.GetQrRowDeletingEvent
					If getQrRowDeletingEvent IsNot Nothing Then
						getQrRowDeletingEvent(Me, New DataSet1.GetQrRowChangeEvent(CType(e.Row, DataSet1.GetQrRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000810 RID: 2064 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveGetQrRow(row As DataSet1.GetQrRow)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x06000811 RID: 2065 RVA: 0x000A13B4 File Offset: 0x0009F5B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSet As DataSet1 = New DataSet1()
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
				xmlSchemaAttribute.FixedValue = dataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "GetQrDataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSet.GetSchemaSerializable()
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

			' Token: 0x040002EA RID: 746
			Private columnGiftCodeQr As DataColumn
		End Class

		' Token: 0x02000025 RID: 37
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class CustomerQrDataTable
			Inherits TypedTableBase(Of DataSet1.CustomerQrRow)

			' Token: 0x06000812 RID: 2066 RVA: 0x0000A3CD File Offset: 0x000085CD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "CustomerQr"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x06000813 RID: 2067 RVA: 0x000A1608 File Offset: 0x0009F808
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

			' Token: 0x06000814 RID: 2068 RVA: 0x0000A3F8 File Offset: 0x000085F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x170003CC RID: 972
			' (get) Token: 0x06000815 RID: 2069 RVA: 0x000A16D4 File Offset: 0x0009F8D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QrCustomerColumn As DataColumn
				Get
					Return Me.columnQrCustomer
				End Get
			End Property

			' Token: 0x170003CD RID: 973
			' (get) Token: 0x06000816 RID: 2070 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x170003CE RID: 974
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSet1.CustomerQrRow
				Get
					Return CType(MyBase.Rows(index), DataSet1.CustomerQrRow)
				End Get
			End Property

			' Token: 0x14000009 RID: 9
			' (add) Token: 0x06000818 RID: 2072 RVA: 0x000A1710 File Offset: 0x0009F910
			' (remove) Token: 0x06000819 RID: 2073 RVA: 0x000A1748 File Offset: 0x0009F948
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event CustomerQrRowChanging As DataSet1.CustomerQrRowChangeEventHandler

			' Token: 0x1400000A RID: 10
			' (add) Token: 0x0600081A RID: 2074 RVA: 0x000A1780 File Offset: 0x0009F980
			' (remove) Token: 0x0600081B RID: 2075 RVA: 0x000A17B8 File Offset: 0x0009F9B8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event CustomerQrRowChanged As DataSet1.CustomerQrRowChangeEventHandler

			' Token: 0x1400000B RID: 11
			' (add) Token: 0x0600081C RID: 2076 RVA: 0x000A17F0 File Offset: 0x0009F9F0
			' (remove) Token: 0x0600081D RID: 2077 RVA: 0x000A1828 File Offset: 0x0009FA28
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event CustomerQrRowDeleting As DataSet1.CustomerQrRowChangeEventHandler

			' Token: 0x1400000C RID: 12
			' (add) Token: 0x0600081E RID: 2078 RVA: 0x000A1860 File Offset: 0x0009FA60
			' (remove) Token: 0x0600081F RID: 2079 RVA: 0x000A1898 File Offset: 0x0009FA98
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event CustomerQrRowDeleted As DataSet1.CustomerQrRowChangeEventHandler

			' Token: 0x06000820 RID: 2080 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddCustomerQrRow(row As DataSet1.CustomerQrRow)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x06000821 RID: 2081 RVA: 0x000A18D0 File Offset: 0x0009FAD0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddCustomerQrRow(QrCustomer As Byte()) As DataSet1.CustomerQrRow
				Dim customerQrRow As DataSet1.CustomerQrRow = CType(MyBase.NewRow(), DataSet1.CustomerQrRow)
				Dim array As Object() = New Object() { QrCustomer }
				customerQrRow.ItemArray = array
				MyBase.Rows.Add(customerQrRow)
				Return customerQrRow
			End Function

			' Token: 0x06000822 RID: 2082 RVA: 0x000A1910 File Offset: 0x0009FB10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim customerQrDataTable As DataSet1.CustomerQrDataTable = CType(MyBase.Clone(), DataSet1.CustomerQrDataTable)
				customerQrDataTable.InitVars()
				Return customerQrDataTable
			End Function

			' Token: 0x06000823 RID: 2083 RVA: 0x000A1938 File Offset: 0x0009FB38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSet1.CustomerQrDataTable()
			End Function

			' Token: 0x06000824 RID: 2084 RVA: 0x0000A40B File Offset: 0x0000860B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnQrCustomer = MyBase.Columns("QrCustomer")
			End Sub

			' Token: 0x06000825 RID: 2085 RVA: 0x000A1950 File Offset: 0x0009FB50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnQrCustomer = New DataColumn("QrCustomer", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQrCustomer)
				Me.columnQrCustomer.Caption = "GiftCodeQr"
			End Sub

			' Token: 0x06000826 RID: 2086 RVA: 0x000A19A0 File Offset: 0x0009FBA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewCustomerQrRow() As DataSet1.CustomerQrRow
				Return CType(MyBase.NewRow(), DataSet1.CustomerQrRow)
			End Function

			' Token: 0x06000827 RID: 2087 RVA: 0x000A19C0 File Offset: 0x0009FBC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSet1.CustomerQrRow(builder)
			End Function

			' Token: 0x06000828 RID: 2088 RVA: 0x000A19D8 File Offset: 0x0009FBD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSet1.CustomerQrRow)
			End Function

			' Token: 0x06000829 RID: 2089 RVA: 0x000A19F4 File Offset: 0x0009FBF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.CustomerQrRowChangedEvent IsNot Nothing
				If flag Then
					Dim customerQrRowChangedEvent As DataSet1.CustomerQrRowChangeEventHandler = Me.CustomerQrRowChangedEvent
					If customerQrRowChangedEvent IsNot Nothing Then
						customerQrRowChangedEvent(Me, New DataSet1.CustomerQrRowChangeEvent(CType(e.Row, DataSet1.CustomerQrRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600082A RID: 2090 RVA: 0x000A1A44 File Offset: 0x0009FC44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.CustomerQrRowChangingEvent IsNot Nothing
				If flag Then
					Dim customerQrRowChangingEvent As DataSet1.CustomerQrRowChangeEventHandler = Me.CustomerQrRowChangingEvent
					If customerQrRowChangingEvent IsNot Nothing Then
						customerQrRowChangingEvent(Me, New DataSet1.CustomerQrRowChangeEvent(CType(e.Row, DataSet1.CustomerQrRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600082B RID: 2091 RVA: 0x000A1A94 File Offset: 0x0009FC94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.CustomerQrRowDeletedEvent IsNot Nothing
				If flag Then
					Dim customerQrRowDeletedEvent As DataSet1.CustomerQrRowChangeEventHandler = Me.CustomerQrRowDeletedEvent
					If customerQrRowDeletedEvent IsNot Nothing Then
						customerQrRowDeletedEvent(Me, New DataSet1.CustomerQrRowChangeEvent(CType(e.Row, DataSet1.CustomerQrRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600082C RID: 2092 RVA: 0x000A1AE4 File Offset: 0x0009FCE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.CustomerQrRowDeletingEvent IsNot Nothing
				If flag Then
					Dim customerQrRowDeletingEvent As DataSet1.CustomerQrRowChangeEventHandler = Me.CustomerQrRowDeletingEvent
					If customerQrRowDeletingEvent IsNot Nothing Then
						customerQrRowDeletingEvent(Me, New DataSet1.CustomerQrRowChangeEvent(CType(e.Row, DataSet1.CustomerQrRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600082D RID: 2093 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveCustomerQrRow(row As DataSet1.CustomerQrRow)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600082E RID: 2094 RVA: 0x000A1B34 File Offset: 0x0009FD34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSet As DataSet1 = New DataSet1()
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
				xmlSchemaAttribute.FixedValue = dataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "CustomerQrDataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSet.GetSchemaSerializable()
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

			' Token: 0x040002EF RID: 751
			Private columnQrCustomer As DataColumn
		End Class

		' Token: 0x02000026 RID: 38
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x0600082F RID: 2095 RVA: 0x0000A424 File Offset: 0x00008624
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, DataSet1.DataTable1DataTable)
			End Sub

			' Token: 0x170003CF RID: 975
			' (get) Token: 0x06000830 RID: 2096 RVA: 0x000A1D88 File Offset: 0x0009FF88
			' (set) Token: 0x06000831 RID: 2097 RVA: 0x0000A440 File Offset: 0x00008640
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property img As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable1.imgColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'img' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable1.imgColumn) = value
				End Set
			End Property

			' Token: 0x06000832 RID: 2098 RVA: 0x000A1DD8 File Offset: 0x0009FFD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsimgNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.imgColumn)
			End Function

			' Token: 0x06000833 RID: 2099 RVA: 0x0000A456 File Offset: 0x00008656
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetimgNull()
				MyBase.Item(Me.tableDataTable1.imgColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040002F4 RID: 756
			Private tableDataTable1 As DataSet1.DataTable1DataTable
		End Class

		' Token: 0x02000027 RID: 39
		Public Class GetQrRow
			Inherits DataRow

			' Token: 0x06000834 RID: 2100 RVA: 0x0000A475 File Offset: 0x00008675
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableGetQr = CType(MyBase.Table, DataSet1.GetQrDataTable)
			End Sub

			' Token: 0x170003D0 RID: 976
			' (get) Token: 0x06000835 RID: 2101 RVA: 0x000A1DFC File Offset: 0x0009FFFC
			' (set) Token: 0x06000836 RID: 2102 RVA: 0x0000A491 File Offset: 0x00008691
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GiftCodeQr As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableGetQr.GiftCodeQrColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GiftCodeQr' in table 'GetQr' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableGetQr.GiftCodeQrColumn) = value
				End Set
			End Property

			' Token: 0x06000837 RID: 2103 RVA: 0x000A1E4C File Offset: 0x000A004C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGiftCodeQrNull() As Boolean
				Return MyBase.IsNull(Me.tableGetQr.GiftCodeQrColumn)
			End Function

			' Token: 0x06000838 RID: 2104 RVA: 0x0000A4A7 File Offset: 0x000086A7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGiftCodeQrNull()
				MyBase.Item(Me.tableGetQr.GiftCodeQrColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040002F5 RID: 757
			Private tableGetQr As DataSet1.GetQrDataTable
		End Class

		' Token: 0x02000028 RID: 40
		Public Class CustomerQrRow
			Inherits DataRow

			' Token: 0x06000839 RID: 2105 RVA: 0x0000A4C6 File Offset: 0x000086C6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableCustomerQr = CType(MyBase.Table, DataSet1.CustomerQrDataTable)
			End Sub

			' Token: 0x170003D1 RID: 977
			' (get) Token: 0x0600083A RID: 2106 RVA: 0x000A1E70 File Offset: 0x000A0070
			' (set) Token: 0x0600083B RID: 2107 RVA: 0x0000A4E2 File Offset: 0x000086E2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property QrCustomer As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableCustomerQr.QrCustomerColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'QrCustomer' in table 'CustomerQr' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableCustomerQr.QrCustomerColumn) = value
				End Set
			End Property

			' Token: 0x0600083C RID: 2108 RVA: 0x000A1EC0 File Offset: 0x000A00C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQrCustomerNull() As Boolean
				Return MyBase.IsNull(Me.tableCustomerQr.QrCustomerColumn)
			End Function

			' Token: 0x0600083D RID: 2109 RVA: 0x0000A4F8 File Offset: 0x000086F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQrCustomerNull()
				MyBase.Item(Me.tableCustomerQr.QrCustomerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040002F6 RID: 758
			Private tableCustomerQr As DataSet1.CustomerQrDataTable
		End Class

		' Token: 0x02000029 RID: 41
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600083E RID: 2110 RVA: 0x0000A517 File Offset: 0x00008717
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSet1.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x170003D2 RID: 978
			' (get) Token: 0x0600083F RID: 2111 RVA: 0x000A1EE4 File Offset: 0x000A00E4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSet1.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x170003D3 RID: 979
			' (get) Token: 0x06000840 RID: 2112 RVA: 0x000A1EFC File Offset: 0x000A00FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040002F7 RID: 759
			Private eventRow As DataSet1.DataTable1Row

			' Token: 0x040002F8 RID: 760
			Private eventAction As DataRowAction
		End Class

		' Token: 0x0200002A RID: 42
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class GetQrRowChangeEvent
			Inherits EventArgs

			' Token: 0x06000841 RID: 2113 RVA: 0x0000A52F File Offset: 0x0000872F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSet1.GetQrRow, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x170003D4 RID: 980
			' (get) Token: 0x06000842 RID: 2114 RVA: 0x000A1F14 File Offset: 0x000A0114
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSet1.GetQrRow
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x170003D5 RID: 981
			' (get) Token: 0x06000843 RID: 2115 RVA: 0x000A1F2C File Offset: 0x000A012C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040002F9 RID: 761
			Private eventRow As DataSet1.GetQrRow

			' Token: 0x040002FA RID: 762
			Private eventAction As DataRowAction
		End Class

		' Token: 0x0200002B RID: 43
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class CustomerQrRowChangeEvent
			Inherits EventArgs

			' Token: 0x06000844 RID: 2116 RVA: 0x0000A547 File Offset: 0x00008747
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSet1.CustomerQrRow, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x170003D6 RID: 982
			' (get) Token: 0x06000845 RID: 2117 RVA: 0x000A1F44 File Offset: 0x000A0144
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSet1.CustomerQrRow
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x170003D7 RID: 983
			' (get) Token: 0x06000846 RID: 2118 RVA: 0x000A1F5C File Offset: 0x000A015C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040002FB RID: 763
			Private eventRow As DataSet1.CustomerQrRow

			' Token: 0x040002FC RID: 764
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
