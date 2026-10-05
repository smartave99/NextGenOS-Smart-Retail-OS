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
	' Token: 0x0200002C RID: 44
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSetBarcode")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSetBarcode
		Inherits DataSet

		' Token: 0x06000847 RID: 2119 RVA: 0x000A1F74 File Offset: 0x000A0174
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

		' Token: 0x06000848 RID: 2120 RVA: 0x000A1FCC File Offset: 0x000A01CC
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
						MyBase.Tables.Add(New DataSetBarcode.DataTable1DataTable(dataSet.Tables("DataTable1")))
					End If
					Dim flag4 As Boolean = dataSet.Tables("P_Transfer") IsNot Nothing
					If flag4 Then
						MyBase.Tables.Add(New DataSetBarcode.P_TransferDataTable(dataSet.Tables("P_Transfer")))
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

		' Token: 0x170003D8 RID: 984
		' (get) Token: 0x06000849 RID: 2121 RVA: 0x000A21A0 File Offset: 0x000A03A0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As DataSetBarcode.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x170003D9 RID: 985
		' (get) Token: 0x0600084A RID: 2122 RVA: 0x000A21B8 File Offset: 0x000A03B8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property P_Transfer As DataSetBarcode.P_TransferDataTable
			Get
				Return Me.tableP_Transfer
			End Get
		End Property

		' Token: 0x170003DA RID: 986
		' (get) Token: 0x0600084B RID: 2123 RVA: 0x000A21D0 File Offset: 0x000A03D0
		' (set) Token: 0x0600084C RID: 2124 RVA: 0x0000A55F File Offset: 0x0000875F
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

		' Token: 0x170003DB RID: 987
		' (get) Token: 0x0600084D RID: 2125 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x170003DC RID: 988
		' (get) Token: 0x0600084E RID: 2126 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x0600084F RID: 2127 RVA: 0x0000A569 File Offset: 0x00008769
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x06000850 RID: 2128 RVA: 0x000A21E8 File Offset: 0x000A03E8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSetBarcode As DataSetBarcode = CType(MyBase.Clone(), DataSetBarcode)
			dataSetBarcode.InitVars()
			dataSetBarcode.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSetBarcode
		End Function

		' Token: 0x06000851 RID: 2129 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x06000852 RID: 2130 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x06000853 RID: 2131 RVA: 0x000A221C File Offset: 0x000A041C
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
					MyBase.Tables.Add(New DataSetBarcode.DataTable1DataTable(dataSet.Tables("DataTable1")))
				End If
				Dim flag3 As Boolean = dataSet.Tables("P_Transfer") IsNot Nothing
				If flag3 Then
					MyBase.Tables.Add(New DataSetBarcode.P_TransferDataTable(dataSet.Tables("P_Transfer")))
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

		' Token: 0x06000854 RID: 2132 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x06000855 RID: 2133 RVA: 0x0000A581 File Offset: 0x00008781
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x06000856 RID: 2134 RVA: 0x000A2338 File Offset: 0x000A0538
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), DataSetBarcode.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
			Me.tableP_Transfer = CType(MyBase.Tables("P_Transfer"), DataSetBarcode.P_TransferDataTable)
			If initTable Then
				Dim flag2 As Boolean = Me.tableP_Transfer IsNot Nothing
				If flag2 Then
					Me.tableP_Transfer.InitVars()
				End If
			End If
		End Sub

		' Token: 0x06000857 RID: 2135 RVA: 0x000A23C0 File Offset: 0x000A05C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSetBarcode"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSetBarcode.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New DataSetBarcode.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
			Me.tableP_Transfer = New DataSetBarcode.P_TransferDataTable()
			MyBase.Tables.Add(Me.tableP_Transfer)
		End Sub

		' Token: 0x06000858 RID: 2136 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x06000859 RID: 2137 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeP_Transfer() As Boolean
			Return False
		End Function

		' Token: 0x0600085A RID: 2138 RVA: 0x000A243C File Offset: 0x000A063C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x0600085B RID: 2139 RVA: 0x000A2460 File Offset: 0x000A0660
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSetBarcode As DataSetBarcode = New DataSetBarcode()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSetBarcode.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSetBarcode.GetSchemaSerializable()
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

		' Token: 0x040002FD RID: 765
		Private tableDataTable1 As DataSetBarcode.DataTable1DataTable

		' Token: 0x040002FE RID: 766
		Private tableP_Transfer As DataSetBarcode.P_TransferDataTable

		' Token: 0x040002FF RID: 767
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x0200002D RID: 45
		' (Invoke) Token: 0x0600085F RID: 2143
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As DataSetBarcode.DataTable1RowChangeEvent)

		' Token: 0x0200002E RID: 46
		' (Invoke) Token: 0x06000863 RID: 2147
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub P_TransferRowChangeEventHandler(sender As Object, e As DataSetBarcode.P_TransferRowChangeEvent)

		' Token: 0x0200002F RID: 47
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of DataSetBarcode.DataTable1Row)

			' Token: 0x06000864 RID: 2148 RVA: 0x0000A58C File Offset: 0x0000878C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x06000865 RID: 2149 RVA: 0x000A25F4 File Offset: 0x000A07F4
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

			' Token: 0x06000866 RID: 2150 RVA: 0x0000A5B7 File Offset: 0x000087B7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x170003DD RID: 989
			' (get) Token: 0x06000867 RID: 2151 RVA: 0x000A26C0 File Offset: 0x000A08C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductNameColumn As DataColumn
				Get
					Return Me.columnProductName
				End Get
			End Property

			' Token: 0x170003DE RID: 990
			' (get) Token: 0x06000868 RID: 2152 RVA: 0x000A26D8 File Offset: 0x000A08D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x170003DF RID: 991
			' (get) Token: 0x06000869 RID: 2153 RVA: 0x000A26F0 File Offset: 0x000A08F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DescriptionColumn As DataColumn
				Get
					Return Me.columnDescription
				End Get
			End Property

			' Token: 0x170003E0 RID: 992
			' (get) Token: 0x0600086A RID: 2154 RVA: 0x000A2708 File Offset: 0x000A0908
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SellingPriceColumn As DataColumn
				Get
					Return Me.columnSellingPrice
				End Get
			End Property

			' Token: 0x170003E1 RID: 993
			' (get) Token: 0x0600086B RID: 2155 RVA: 0x000A2720 File Offset: 0x000A0920
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CostPriceColumn As DataColumn
				Get
					Return Me.columnCostPrice
				End Get
			End Property

			' Token: 0x170003E2 RID: 994
			' (get) Token: 0x0600086C RID: 2156 RVA: 0x000A2738 File Offset: 0x000A0938
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ReorderPointColumn As DataColumn
				Get
					Return Me.columnReorderPoint
				End Get
			End Property

			' Token: 0x170003E3 RID: 995
			' (get) Token: 0x0600086D RID: 2157 RVA: 0x000A2750 File Offset: 0x000A0950
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MRPColumn As DataColumn
				Get
					Return Me.columnMRP
				End Get
			End Property

			' Token: 0x170003E4 RID: 996
			' (get) Token: 0x0600086E RID: 2158 RVA: 0x000A2768 File Offset: 0x000A0968
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCodeColumn As DataColumn
				Get
					Return Me.columnHSNCode
				End Get
			End Property

			' Token: 0x170003E5 RID: 997
			' (get) Token: 0x0600086F RID: 2159 RVA: 0x000A2780 File Offset: 0x000A0980
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PartNoColumn As DataColumn
				Get
					Return Me.columnPartNo
				End Get
			End Property

			' Token: 0x170003E6 RID: 998
			' (get) Token: 0x06000870 RID: 2160 RVA: 0x000A2798 File Offset: 0x000A0998
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountColumn As DataColumn
				Get
					Return Me.columnDiscount
				End Get
			End Property

			' Token: 0x170003E7 RID: 999
			' (get) Token: 0x06000871 RID: 2161 RVA: 0x000A27B0 File Offset: 0x000A09B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTColumn As DataColumn
				Get
					Return Me.columnCGST
				End Get
			End Property

			' Token: 0x170003E8 RID: 1000
			' (get) Token: 0x06000872 RID: 2162 RVA: 0x000A27C8 File Offset: 0x000A09C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductCodeColumn As DataColumn
				Get
					Return Me.columnProductCode
				End Get
			End Property

			' Token: 0x170003E9 RID: 1001
			' (get) Token: 0x06000873 RID: 2163 RVA: 0x000A27E0 File Offset: 0x000A09E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CBarcodeColumn As DataColumn
				Get
					Return Me.columnCBarcode
				End Get
			End Property

			' Token: 0x170003EA RID: 1002
			' (get) Token: 0x06000874 RID: 2164 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x170003EB RID: 1003
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetBarcode.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), DataSetBarcode.DataTable1Row)
				End Get
			End Property

			' Token: 0x1400000D RID: 13
			' (add) Token: 0x06000876 RID: 2166 RVA: 0x000A281C File Offset: 0x000A0A1C
			' (remove) Token: 0x06000877 RID: 2167 RVA: 0x000A2854 File Offset: 0x000A0A54
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As DataSetBarcode.DataTable1RowChangeEventHandler

			' Token: 0x1400000E RID: 14
			' (add) Token: 0x06000878 RID: 2168 RVA: 0x000A288C File Offset: 0x000A0A8C
			' (remove) Token: 0x06000879 RID: 2169 RVA: 0x000A28C4 File Offset: 0x000A0AC4
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As DataSetBarcode.DataTable1RowChangeEventHandler

			' Token: 0x1400000F RID: 15
			' (add) Token: 0x0600087A RID: 2170 RVA: 0x000A28FC File Offset: 0x000A0AFC
			' (remove) Token: 0x0600087B RID: 2171 RVA: 0x000A2934 File Offset: 0x000A0B34
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As DataSetBarcode.DataTable1RowChangeEventHandler

			' Token: 0x14000010 RID: 16
			' (add) Token: 0x0600087C RID: 2172 RVA: 0x000A296C File Offset: 0x000A0B6C
			' (remove) Token: 0x0600087D RID: 2173 RVA: 0x000A29A4 File Offset: 0x000A0BA4
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As DataSetBarcode.DataTable1RowChangeEventHandler

			' Token: 0x0600087E RID: 2174 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As DataSetBarcode.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600087F RID: 2175 RVA: 0x000A29DC File Offset: 0x000A0BDC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(ProductName As String, Barcode As String, Description As String, SellingPrice As String, CostPrice As String, ReorderPoint As String, MRP As String, HSNCode As String, PartNo As String, Discount As String, CGST As String, ProductCode As String, CBarcode As String) As DataSetBarcode.DataTable1Row
				Dim dataTable1Row As DataSetBarcode.DataTable1Row = CType(MyBase.NewRow(), DataSetBarcode.DataTable1Row)
				Dim array As Object() = New Object() { ProductName, Barcode, Description, SellingPrice, CostPrice, ReorderPoint, MRP, HSNCode, PartNo, Discount, CGST, ProductCode, CBarcode }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x06000880 RID: 2176 RVA: 0x000A2A5C File Offset: 0x000A0C5C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As DataSetBarcode.DataTable1DataTable = CType(MyBase.Clone(), DataSetBarcode.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x06000881 RID: 2177 RVA: 0x000A2A84 File Offset: 0x000A0C84
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetBarcode.DataTable1DataTable()
			End Function

			' Token: 0x06000882 RID: 2178 RVA: 0x000A2A9C File Offset: 0x000A0C9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnProductName = MyBase.Columns("ProductName")
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnDescription = MyBase.Columns("Description")
				Me.columnSellingPrice = MyBase.Columns("SellingPrice")
				Me.columnCostPrice = MyBase.Columns("CostPrice")
				Me.columnReorderPoint = MyBase.Columns("ReorderPoint")
				Me.columnMRP = MyBase.Columns("MRP")
				Me.columnHSNCode = MyBase.Columns("HSNCode")
				Me.columnPartNo = MyBase.Columns("PartNo")
				Me.columnDiscount = MyBase.Columns("Discount")
				Me.columnCGST = MyBase.Columns("CGST")
				Me.columnProductCode = MyBase.Columns("ProductCode")
				Me.columnCBarcode = MyBase.Columns("CBarcode")
			End Sub

			' Token: 0x06000883 RID: 2179 RVA: 0x000A2BC8 File Offset: 0x000A0DC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnProductName = New DataColumn("ProductName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductName)
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnDescription = New DataColumn("Description", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDescription)
				Me.columnSellingPrice = New DataColumn("SellingPrice", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSellingPrice)
				Me.columnCostPrice = New DataColumn("CostPrice", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCostPrice)
				Me.columnReorderPoint = New DataColumn("ReorderPoint", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnReorderPoint)
				Me.columnMRP = New DataColumn("MRP", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMRP)
				Me.columnHSNCode = New DataColumn("HSNCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnHSNCode)
				Me.columnPartNo = New DataColumn("PartNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPartNo)
				Me.columnDiscount = New DataColumn("Discount", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscount)
				Me.columnCGST = New DataColumn("CGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGST)
				Me.columnProductCode = New DataColumn("ProductCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductCode)
				Me.columnCBarcode = New DataColumn("CBarcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCBarcode)
			End Sub

			' Token: 0x06000884 RID: 2180 RVA: 0x000A2E2C File Offset: 0x000A102C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As DataSetBarcode.DataTable1Row
				Return CType(MyBase.NewRow(), DataSetBarcode.DataTable1Row)
			End Function

			' Token: 0x06000885 RID: 2181 RVA: 0x000A2E4C File Offset: 0x000A104C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetBarcode.DataTable1Row(builder)
			End Function

			' Token: 0x06000886 RID: 2182 RVA: 0x000A2E64 File Offset: 0x000A1064
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetBarcode.DataTable1Row)
			End Function

			' Token: 0x06000887 RID: 2183 RVA: 0x000A2E80 File Offset: 0x000A1080
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As DataSetBarcode.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New DataSetBarcode.DataTable1RowChangeEvent(CType(e.Row, DataSetBarcode.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000888 RID: 2184 RVA: 0x000A2ED0 File Offset: 0x000A10D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As DataSetBarcode.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New DataSetBarcode.DataTable1RowChangeEvent(CType(e.Row, DataSetBarcode.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000889 RID: 2185 RVA: 0x000A2F20 File Offset: 0x000A1120
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As DataSetBarcode.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New DataSetBarcode.DataTable1RowChangeEvent(CType(e.Row, DataSetBarcode.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600088A RID: 2186 RVA: 0x000A2F70 File Offset: 0x000A1170
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As DataSetBarcode.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New DataSetBarcode.DataTable1RowChangeEvent(CType(e.Row, DataSetBarcode.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600088B RID: 2187 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As DataSetBarcode.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600088C RID: 2188 RVA: 0x000A2FC0 File Offset: 0x000A11C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetBarcode As DataSetBarcode = New DataSetBarcode()
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
				xmlSchemaAttribute.FixedValue = dataSetBarcode.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetBarcode.GetSchemaSerializable()
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

			' Token: 0x04000300 RID: 768
			Private columnProductName As DataColumn

			' Token: 0x04000301 RID: 769
			Private columnBarcode As DataColumn

			' Token: 0x04000302 RID: 770
			Private columnDescription As DataColumn

			' Token: 0x04000303 RID: 771
			Private columnSellingPrice As DataColumn

			' Token: 0x04000304 RID: 772
			Private columnCostPrice As DataColumn

			' Token: 0x04000305 RID: 773
			Private columnReorderPoint As DataColumn

			' Token: 0x04000306 RID: 774
			Private columnMRP As DataColumn

			' Token: 0x04000307 RID: 775
			Private columnHSNCode As DataColumn

			' Token: 0x04000308 RID: 776
			Private columnPartNo As DataColumn

			' Token: 0x04000309 RID: 777
			Private columnDiscount As DataColumn

			' Token: 0x0400030A RID: 778
			Private columnCGST As DataColumn

			' Token: 0x0400030B RID: 779
			Private columnProductCode As DataColumn

			' Token: 0x0400030C RID: 780
			Private columnCBarcode As DataColumn
		End Class

		' Token: 0x02000030 RID: 48
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class P_TransferDataTable
			Inherits TypedTableBase(Of DataSetBarcode.P_TransferRow)

			' Token: 0x0600088D RID: 2189 RVA: 0x0000A5CA File Offset: 0x000087CA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "P_Transfer"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600088E RID: 2190 RVA: 0x000A3214 File Offset: 0x000A1414
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

			' Token: 0x0600088F RID: 2191 RVA: 0x0000A5F5 File Offset: 0x000087F5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x170003EC RID: 1004
			' (get) Token: 0x06000890 RID: 2192 RVA: 0x000A32E0 File Offset: 0x000A14E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IDColumn As DataColumn
				Get
					Return Me.columnID
				End Get
			End Property

			' Token: 0x170003ED RID: 1005
			' (get) Token: 0x06000891 RID: 2193 RVA: 0x000A32F8 File Offset: 0x000A14F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductCodeColumn As DataColumn
				Get
					Return Me.columnProductCode
				End Get
			End Property

			' Token: 0x170003EE RID: 1006
			' (get) Token: 0x06000892 RID: 2194 RVA: 0x000A3310 File Offset: 0x000A1510
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x170003EF RID: 1007
			' (get) Token: 0x06000893 RID: 2195 RVA: 0x000A3328 File Offset: 0x000A1528
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductnameColumn As DataColumn
				Get
					Return Me.columnProductname
				End Get
			End Property

			' Token: 0x170003F0 RID: 1008
			' (get) Token: 0x06000894 RID: 2196 RVA: 0x000A3340 File Offset: 0x000A1540
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCodeColumn As DataColumn
				Get
					Return Me.columnHSNCode
				End Get
			End Property

			' Token: 0x170003F1 RID: 1009
			' (get) Token: 0x06000895 RID: 2197 RVA: 0x000A3358 File Offset: 0x000A1558
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PartNoColumn As DataColumn
				Get
					Return Me.columnPartNo
				End Get
			End Property

			' Token: 0x170003F2 RID: 1010
			' (get) Token: 0x06000896 RID: 2198 RVA: 0x000A3370 File Offset: 0x000A1570
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DescriptionColumn As DataColumn
				Get
					Return Me.columnDescription
				End Get
			End Property

			' Token: 0x170003F3 RID: 1011
			' (get) Token: 0x06000897 RID: 2199 RVA: 0x000A3388 File Offset: 0x000A1588
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CostPriceColumn As DataColumn
				Get
					Return Me.columnCostPrice
				End Get
			End Property

			' Token: 0x170003F4 RID: 1012
			' (get) Token: 0x06000898 RID: 2200 RVA: 0x000A33A0 File Offset: 0x000A15A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MRPColumn As DataColumn
				Get
					Return Me.columnMRP
				End Get
			End Property

			' Token: 0x170003F5 RID: 1013
			' (get) Token: 0x06000899 RID: 2201 RVA: 0x000A33B8 File Offset: 0x000A15B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SellingPriceColumn As DataColumn
				Get
					Return Me.columnSellingPrice
				End Get
			End Property

			' Token: 0x170003F6 RID: 1014
			' (get) Token: 0x0600089A RID: 2202 RVA: 0x000A33D0 File Offset: 0x000A15D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ReorderPointColumn As DataColumn
				Get
					Return Me.columnReorderPoint
				End Get
			End Property

			' Token: 0x170003F7 RID: 1015
			' (get) Token: 0x0600089B RID: 2203 RVA: 0x000A33E8 File Offset: 0x000A15E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountColumn As DataColumn
				Get
					Return Me.columnDiscount
				End Get
			End Property

			' Token: 0x170003F8 RID: 1016
			' (get) Token: 0x0600089C RID: 2204 RVA: 0x000A3400 File Offset: 0x000A1600
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTColumn As DataColumn
				Get
					Return Me.columnCGST
				End Get
			End Property

			' Token: 0x170003F9 RID: 1017
			' (get) Token: 0x0600089D RID: 2205 RVA: 0x000A3418 File Offset: 0x000A1618
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTColumn As DataColumn
				Get
					Return Me.columnSGST
				End Get
			End Property

			' Token: 0x170003FA RID: 1018
			' (get) Token: 0x0600089E RID: 2206 RVA: 0x000A3430 File Offset: 0x000A1630
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSColumn As DataColumn
				Get
					Return Me.columnCESS
				End Get
			End Property

			' Token: 0x170003FB RID: 1019
			' (get) Token: 0x0600089F RID: 2207 RVA: 0x000A3448 File Offset: 0x000A1648
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PurchaseUnitColumn As DataColumn
				Get
					Return Me.columnPurchaseUnit
				End Get
			End Property

			' Token: 0x170003FC RID: 1020
			' (get) Token: 0x060008A0 RID: 2208 RVA: 0x000A3460 File Offset: 0x000A1660
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalesunitColumn As DataColumn
				Get
					Return Me.columnSalesunit
				End Get
			End Property

			' Token: 0x170003FD RID: 1021
			' (get) Token: 0x060008A1 RID: 2209 RVA: 0x000A3478 File Offset: 0x000A1678
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalesAltUnitColumn As DataColumn
				Get
					Return Me.columnSalesAltUnit
				End Get
			End Property

			' Token: 0x170003FE RID: 1022
			' (get) Token: 0x060008A2 RID: 2210 RVA: 0x000A3490 File Offset: 0x000A1690
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ConvColumn As DataColumn
				Get
					Return Me.columnConv
				End Get
			End Property

			' Token: 0x170003FF RID: 1023
			' (get) Token: 0x060008A3 RID: 2211 RVA: 0x000A34A8 File Offset: 0x000A16A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MinStockColumn As DataColumn
				Get
					Return Me.columnMinStock
				End Get
			End Property

			' Token: 0x17000400 RID: 1024
			' (get) Token: 0x060008A4 RID: 2212 RVA: 0x000A34C0 File Offset: 0x000A16C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GDownColumn As DataColumn
				Get
					Return Me.columnGDown
				End Get
			End Property

			' Token: 0x17000401 RID: 1025
			' (get) Token: 0x060008A5 RID: 2213 RVA: 0x000A34D8 File Offset: 0x000A16D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RackColumn As DataColumn
				Get
					Return Me.columnRack
				End Get
			End Property

			' Token: 0x17000402 RID: 1026
			' (get) Token: 0x060008A6 RID: 2214 RVA: 0x000A34F0 File Offset: 0x000A16F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DefQtyColumn As DataColumn
				Get
					Return Me.columnDefQty
				End Get
			End Property

			' Token: 0x17000403 RID: 1027
			' (get) Token: 0x060008A7 RID: 2215 RVA: 0x000A3508 File Offset: 0x000A1708
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PPriceColumn As DataColumn
				Get
					Return Me.columnPPrice
				End Get
			End Property

			' Token: 0x17000404 RID: 1028
			' (get) Token: 0x060008A8 RID: 2216 RVA: 0x000A3520 File Offset: 0x000A1720
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Temp_StockMRPColumn As DataColumn
				Get
					Return Me.columnTemp_StockMRP
				End Get
			End Property

			' Token: 0x17000405 RID: 1029
			' (get) Token: 0x060008A9 RID: 2217 RVA: 0x000A3538 File Offset: 0x000A1738
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SPriceColumn As DataColumn
				Get
					Return Me.columnSPrice
				End Get
			End Property

			' Token: 0x17000406 RID: 1030
			' (get) Token: 0x060008AA RID: 2218 RVA: 0x000A3550 File Offset: 0x000A1750
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property WPriceColumn As DataColumn
				Get
					Return Me.columnWPrice
				End Get
			End Property

			' Token: 0x17000407 RID: 1031
			' (get) Token: 0x060008AB RID: 2219 RVA: 0x000A3568 File Offset: 0x000A1768
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BatchColumn As DataColumn
				Get
					Return Me.columnBatch
				End Get
			End Property

			' Token: 0x17000408 RID: 1032
			' (get) Token: 0x060008AC RID: 2220 RVA: 0x000A3580 File Offset: 0x000A1780
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MfgdateColumn As DataColumn
				Get
					Return Me.columnMfgdate
				End Get
			End Property

			' Token: 0x17000409 RID: 1033
			' (get) Token: 0x060008AD RID: 2221 RVA: 0x000A3598 File Offset: 0x000A1798
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ExpdateColumn As DataColumn
				Get
					Return Me.columnExpdate
				End Get
			End Property

			' Token: 0x1700040A RID: 1034
			' (get) Token: 0x060008AE RID: 2222 RVA: 0x000A35B0 File Offset: 0x000A17B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ColourColumn As DataColumn
				Get
					Return Me.columnColour
				End Get
			End Property

			' Token: 0x1700040B RID: 1035
			' (get) Token: 0x060008AF RID: 2223 RVA: 0x000A35C8 File Offset: 0x000A17C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SizeColumn As DataColumn
				Get
					Return Me.columnSize
				End Get
			End Property

			' Token: 0x1700040C RID: 1036
			' (get) Token: 0x060008B0 RID: 2224 RVA: 0x000A35E0 File Offset: 0x000A17E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IMEI1Column As DataColumn
				Get
					Return Me.columnIMEI1
				End Get
			End Property

			' Token: 0x1700040D RID: 1037
			' (get) Token: 0x060008B1 RID: 2225 RVA: 0x000A35F8 File Offset: 0x000A17F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IMEI2Column As DataColumn
				Get
					Return Me.columnIMEI2
				End Get
			End Property

			' Token: 0x1700040E RID: 1038
			' (get) Token: 0x060008B2 RID: 2226 RVA: 0x000A3610 File Offset: 0x000A1810
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property StatusColumn As DataColumn
				Get
					Return Me.columnStatus
				End Get
			End Property

			' Token: 0x1700040F RID: 1039
			' (get) Token: 0x060008B3 RID: 2227 RVA: 0x000A3628 File Offset: 0x000A1828
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QrBarcodeColumn As DataColumn
				Get
					Return Me.columnQrBarcode
				End Get
			End Property

			' Token: 0x17000410 RID: 1040
			' (get) Token: 0x060008B4 RID: 2228 RVA: 0x000A3640 File Offset: 0x000A1840
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SuplNameColumn As DataColumn
				Get
					Return Me.columnSuplName
				End Get
			End Property

			' Token: 0x17000411 RID: 1041
			' (get) Token: 0x060008B5 RID: 2229 RVA: 0x000A3658 File Offset: 0x000A1858
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TocknNoColumn As DataColumn
				Get
					Return Me.columnTocknNo
				End Get
			End Property

			' Token: 0x17000412 RID: 1042
			' (get) Token: 0x060008B6 RID: 2230 RVA: 0x000A3670 File Offset: 0x000A1870
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PIDColumn As DataColumn
				Get
					Return Me.columnPID
				End Get
			End Property

			' Token: 0x17000413 RID: 1043
			' (get) Token: 0x060008B7 RID: 2231 RVA: 0x000A3688 File Offset: 0x000A1888
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PStatusColumn As DataColumn
				Get
					Return Me.columnPStatus
				End Get
			End Property

			' Token: 0x17000414 RID: 1044
			' (get) Token: 0x060008B8 RID: 2232 RVA: 0x000A36A0 File Offset: 0x000A18A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property T_QtyColumn As DataColumn
				Get
					Return Me.columnT_Qty
				End Get
			End Property

			' Token: 0x17000415 RID: 1045
			' (get) Token: 0x060008B9 RID: 2233 RVA: 0x000A36B8 File Offset: 0x000A18B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PAdminColumn As DataColumn
				Get
					Return Me.columnPAdmin
				End Get
			End Property

			' Token: 0x17000416 RID: 1046
			' (get) Token: 0x060008BA RID: 2234 RVA: 0x000A36D0 File Offset: 0x000A18D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PBranchFromColumn As DataColumn
				Get
					Return Me.columnPBranchFrom
				End Get
			End Property

			' Token: 0x17000417 RID: 1047
			' (get) Token: 0x060008BB RID: 2235 RVA: 0x000A36E8 File Offset: 0x000A18E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PBranchToColumn As DataColumn
				Get
					Return Me.columnPBranchTo
				End Get
			End Property

			' Token: 0x17000418 RID: 1048
			' (get) Token: 0x060008BC RID: 2236 RVA: 0x000A3700 File Offset: 0x000A1900
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RemarksColumn As DataColumn
				Get
					Return Me.columnRemarks
				End Get
			End Property

			' Token: 0x17000419 RID: 1049
			' (get) Token: 0x060008BD RID: 2237 RVA: 0x000A3718 File Offset: 0x000A1918
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PostDateColumn As DataColumn
				Get
					Return Me.columnPostDate
				End Get
			End Property

			' Token: 0x1700041A RID: 1050
			' (get) Token: 0x060008BE RID: 2238 RVA: 0x000A3730 File Offset: 0x000A1930
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property branchcodeColumn As DataColumn
				Get
					Return Me.columnbranchcode
				End Get
			End Property

			' Token: 0x1700041B RID: 1051
			' (get) Token: 0x060008BF RID: 2239 RVA: 0x000A3748 File Offset: 0x000A1948
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CategoryColumn As DataColumn
				Get
					Return Me.columnCategory
				End Get
			End Property

			' Token: 0x1700041C RID: 1052
			' (get) Token: 0x060008C0 RID: 2240 RVA: 0x000A3760 File Offset: 0x000A1960
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SubCategoryNameColumn As DataColumn
				Get
					Return Me.columnSubCategoryName
				End Get
			End Property

			' Token: 0x1700041D RID: 1053
			' (get) Token: 0x060008C1 RID: 2241 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x1700041E RID: 1054
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetBarcode.P_TransferRow
				Get
					Return CType(MyBase.Rows(index), DataSetBarcode.P_TransferRow)
				End Get
			End Property

			' Token: 0x14000011 RID: 17
			' (add) Token: 0x060008C3 RID: 2243 RVA: 0x000A379C File Offset: 0x000A199C
			' (remove) Token: 0x060008C4 RID: 2244 RVA: 0x000A37D4 File Offset: 0x000A19D4
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event P_TransferRowChanging As DataSetBarcode.P_TransferRowChangeEventHandler

			' Token: 0x14000012 RID: 18
			' (add) Token: 0x060008C5 RID: 2245 RVA: 0x000A380C File Offset: 0x000A1A0C
			' (remove) Token: 0x060008C6 RID: 2246 RVA: 0x000A3844 File Offset: 0x000A1A44
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event P_TransferRowChanged As DataSetBarcode.P_TransferRowChangeEventHandler

			' Token: 0x14000013 RID: 19
			' (add) Token: 0x060008C7 RID: 2247 RVA: 0x000A387C File Offset: 0x000A1A7C
			' (remove) Token: 0x060008C8 RID: 2248 RVA: 0x000A38B4 File Offset: 0x000A1AB4
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event P_TransferRowDeleting As DataSetBarcode.P_TransferRowChangeEventHandler

			' Token: 0x14000014 RID: 20
			' (add) Token: 0x060008C9 RID: 2249 RVA: 0x000A38EC File Offset: 0x000A1AEC
			' (remove) Token: 0x060008CA RID: 2250 RVA: 0x000A3924 File Offset: 0x000A1B24
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event P_TransferRowDeleted As DataSetBarcode.P_TransferRowChangeEventHandler

			' Token: 0x060008CB RID: 2251 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddP_TransferRow(row As DataSetBarcode.P_TransferRow)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x060008CC RID: 2252 RVA: 0x000A395C File Offset: 0x000A1B5C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddP_TransferRow(ID As String, ProductCode As String, Barcode As String, Productname As String, HSNCode As String, PartNo As String, Description As String, CostPrice As Double, MRP As Double, SellingPrice As Double, ReorderPoint As Double, Discount As Double, CGST As Double, SGST As Double, CESS As Double, PurchaseUnit As String, Salesunit As String, SalesAltUnit As String, Conv As String, MinStock As String, GDown As String, Rack As String, DefQty As Double, PPrice As Double, Temp_StockMRP As Double, SPrice As Double, WPrice As Double, Batch As String, Mfgdate As String, Expdate As String, Colour As String, Size As String, IMEI1 As String, IMEI2 As String, Status As String, QrBarcode As Byte(), SuplName As String, TocknNo As String, PID As String, PStatus As String, T_Qty As Double, PAdmin As String, PBranchFrom As String, PBranchTo As String, Remarks As String, PostDate As String, branchcode As String, Category As String, SubCategoryName As String) As DataSetBarcode.P_TransferRow
				Dim p_TransferRow As DataSetBarcode.P_TransferRow = CType(MyBase.NewRow(), DataSetBarcode.P_TransferRow)
				Dim array As Object() = New Object() { ID, ProductCode, Barcode, Productname, HSNCode, PartNo, Description, CostPrice, MRP, SellingPrice, ReorderPoint, Discount, CGST, SGST, CESS, PurchaseUnit, Salesunit, SalesAltUnit, Conv, MinStock, GDown, Rack, DefQty, PPrice, Temp_StockMRP, SPrice, WPrice, Batch, Mfgdate, Expdate, Colour, Size, IMEI1, IMEI2, Status, QrBarcode, SuplName, TocknNo, PID, PStatus, T_Qty, PAdmin, PBranchFrom, PBranchTo, Remarks, PostDate, branchcode, Category, SubCategoryName }
				p_TransferRow.ItemArray = array
				MyBase.Rows.Add(p_TransferRow)
				Return p_TransferRow
			End Function

			' Token: 0x060008CD RID: 2253 RVA: 0x000A3AF8 File Offset: 0x000A1CF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim p_TransferDataTable As DataSetBarcode.P_TransferDataTable = CType(MyBase.Clone(), DataSetBarcode.P_TransferDataTable)
				p_TransferDataTable.InitVars()
				Return p_TransferDataTable
			End Function

			' Token: 0x060008CE RID: 2254 RVA: 0x000A3B20 File Offset: 0x000A1D20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetBarcode.P_TransferDataTable()
			End Function

			' Token: 0x060008CF RID: 2255 RVA: 0x000A3B38 File Offset: 0x000A1D38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnID = MyBase.Columns("ID")
				Me.columnProductCode = MyBase.Columns("ProductCode")
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnProductname = MyBase.Columns("Productname")
				Me.columnHSNCode = MyBase.Columns("HSNCode")
				Me.columnPartNo = MyBase.Columns("PartNo")
				Me.columnDescription = MyBase.Columns("Description")
				Me.columnCostPrice = MyBase.Columns("CostPrice")
				Me.columnMRP = MyBase.Columns("MRP")
				Me.columnSellingPrice = MyBase.Columns("SellingPrice")
				Me.columnReorderPoint = MyBase.Columns("ReorderPoint")
				Me.columnDiscount = MyBase.Columns("Discount")
				Me.columnCGST = MyBase.Columns("CGST")
				Me.columnSGST = MyBase.Columns("SGST")
				Me.columnCESS = MyBase.Columns("CESS")
				Me.columnPurchaseUnit = MyBase.Columns("PurchaseUnit")
				Me.columnSalesunit = MyBase.Columns("Salesunit")
				Me.columnSalesAltUnit = MyBase.Columns("SalesAltUnit")
				Me.columnConv = MyBase.Columns("Conv")
				Me.columnMinStock = MyBase.Columns("MinStock")
				Me.columnGDown = MyBase.Columns("GDown")
				Me.columnRack = MyBase.Columns("Rack")
				Me.columnDefQty = MyBase.Columns("DefQty")
				Me.columnPPrice = MyBase.Columns("PPrice")
				Me.columnTemp_StockMRP = MyBase.Columns("Temp_StockMRP")
				Me.columnSPrice = MyBase.Columns("SPrice")
				Me.columnWPrice = MyBase.Columns("WPrice")
				Me.columnBatch = MyBase.Columns("Batch")
				Me.columnMfgdate = MyBase.Columns("Mfgdate")
				Me.columnExpdate = MyBase.Columns("Expdate")
				Me.columnColour = MyBase.Columns("Colour")
				Me.columnSize = MyBase.Columns("Size")
				Me.columnIMEI1 = MyBase.Columns("IMEI1")
				Me.columnIMEI2 = MyBase.Columns("IMEI2")
				Me.columnStatus = MyBase.Columns("Status")
				Me.columnQrBarcode = MyBase.Columns("QrBarcode")
				Me.columnSuplName = MyBase.Columns("SuplName")
				Me.columnTocknNo = MyBase.Columns("TocknNo")
				Me.columnPID = MyBase.Columns("PID")
				Me.columnPStatus = MyBase.Columns("PStatus")
				Me.columnT_Qty = MyBase.Columns("T_Qty")
				Me.columnPAdmin = MyBase.Columns("PAdmin")
				Me.columnPBranchFrom = MyBase.Columns("PBranchFrom")
				Me.columnPBranchTo = MyBase.Columns("PBranchTo")
				Me.columnRemarks = MyBase.Columns("Remarks")
				Me.columnPostDate = MyBase.Columns("PostDate")
				Me.columnbranchcode = MyBase.Columns("branchcode")
				Me.columnCategory = MyBase.Columns("Category")
				Me.columnSubCategoryName = MyBase.Columns("SubCategoryName")
			End Sub

			' Token: 0x060008D0 RID: 2256 RVA: 0x000A3F7C File Offset: 0x000A217C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnID = New DataColumn("ID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnID)
				Me.columnProductCode = New DataColumn("ProductCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductCode)
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnProductname = New DataColumn("Productname", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductname)
				Me.columnHSNCode = New DataColumn("HSNCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnHSNCode)
				Me.columnPartNo = New DataColumn("PartNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPartNo)
				Me.columnDescription = New DataColumn("Description", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDescription)
				Me.columnCostPrice = New DataColumn("CostPrice", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCostPrice)
				Me.columnMRP = New DataColumn("MRP", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMRP)
				Me.columnSellingPrice = New DataColumn("SellingPrice", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSellingPrice)
				Me.columnReorderPoint = New DataColumn("ReorderPoint", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnReorderPoint)
				Me.columnDiscount = New DataColumn("Discount", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscount)
				Me.columnCGST = New DataColumn("CGST", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGST)
				Me.columnSGST = New DataColumn("SGST", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGST)
				Me.columnCESS = New DataColumn("CESS", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESS)
				Me.columnPurchaseUnit = New DataColumn("PurchaseUnit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPurchaseUnit)
				Me.columnSalesunit = New DataColumn("Salesunit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSalesunit)
				Me.columnSalesAltUnit = New DataColumn("SalesAltUnit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSalesAltUnit)
				Me.columnConv = New DataColumn("Conv", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnConv)
				Me.columnMinStock = New DataColumn("MinStock", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMinStock)
				Me.columnGDown = New DataColumn("GDown", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGDown)
				Me.columnRack = New DataColumn("Rack", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRack)
				Me.columnDefQty = New DataColumn("DefQty", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDefQty)
				Me.columnPPrice = New DataColumn("PPrice", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPPrice)
				Me.columnTemp_StockMRP = New DataColumn("Temp_StockMRP", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTemp_StockMRP)
				Me.columnSPrice = New DataColumn("SPrice", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSPrice)
				Me.columnWPrice = New DataColumn("WPrice", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnWPrice)
				Me.columnBatch = New DataColumn("Batch", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBatch)
				Me.columnMfgdate = New DataColumn("Mfgdate", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMfgdate)
				Me.columnExpdate = New DataColumn("Expdate", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnExpdate)
				Me.columnColour = New DataColumn("Colour", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnColour)
				Me.columnSize = New DataColumn("Size", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSize)
				Me.columnIMEI1 = New DataColumn("IMEI1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIMEI1)
				Me.columnIMEI2 = New DataColumn("IMEI2", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIMEI2)
				Me.columnStatus = New DataColumn("Status", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnStatus)
				Me.columnQrBarcode = New DataColumn("QrBarcode", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQrBarcode)
				Me.columnSuplName = New DataColumn("SuplName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSuplName)
				Me.columnTocknNo = New DataColumn("TocknNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTocknNo)
				Me.columnPID = New DataColumn("PID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPID)
				Me.columnPStatus = New DataColumn("PStatus", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPStatus)
				Me.columnT_Qty = New DataColumn("T_Qty", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnT_Qty)
				Me.columnPAdmin = New DataColumn("PAdmin", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPAdmin)
				Me.columnPBranchFrom = New DataColumn("PBranchFrom", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPBranchFrom)
				Me.columnPBranchTo = New DataColumn("PBranchTo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPBranchTo)
				Me.columnRemarks = New DataColumn("Remarks", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRemarks)
				Me.columnPostDate = New DataColumn("PostDate", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPostDate)
				Me.columnbranchcode = New DataColumn("branchcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnbranchcode)
				Me.columnCategory = New DataColumn("Category", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCategory)
				Me.columnSubCategoryName = New DataColumn("SubCategoryName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSubCategoryName)
			End Sub

			' Token: 0x060008D1 RID: 2257 RVA: 0x000A4858 File Offset: 0x000A2A58
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewP_TransferRow() As DataSetBarcode.P_TransferRow
				Return CType(MyBase.NewRow(), DataSetBarcode.P_TransferRow)
			End Function

			' Token: 0x060008D2 RID: 2258 RVA: 0x000A4878 File Offset: 0x000A2A78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetBarcode.P_TransferRow(builder)
			End Function

			' Token: 0x060008D3 RID: 2259 RVA: 0x000A4890 File Offset: 0x000A2A90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetBarcode.P_TransferRow)
			End Function

			' Token: 0x060008D4 RID: 2260 RVA: 0x000A48AC File Offset: 0x000A2AAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.P_TransferRowChangedEvent IsNot Nothing
				If flag Then
					Dim p_TransferRowChangedEvent As DataSetBarcode.P_TransferRowChangeEventHandler = Me.P_TransferRowChangedEvent
					If p_TransferRowChangedEvent IsNot Nothing Then
						p_TransferRowChangedEvent(Me, New DataSetBarcode.P_TransferRowChangeEvent(CType(e.Row, DataSetBarcode.P_TransferRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x060008D5 RID: 2261 RVA: 0x000A48FC File Offset: 0x000A2AFC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.P_TransferRowChangingEvent IsNot Nothing
				If flag Then
					Dim p_TransferRowChangingEvent As DataSetBarcode.P_TransferRowChangeEventHandler = Me.P_TransferRowChangingEvent
					If p_TransferRowChangingEvent IsNot Nothing Then
						p_TransferRowChangingEvent(Me, New DataSetBarcode.P_TransferRowChangeEvent(CType(e.Row, DataSetBarcode.P_TransferRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x060008D6 RID: 2262 RVA: 0x000A494C File Offset: 0x000A2B4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.P_TransferRowDeletedEvent IsNot Nothing
				If flag Then
					Dim p_TransferRowDeletedEvent As DataSetBarcode.P_TransferRowChangeEventHandler = Me.P_TransferRowDeletedEvent
					If p_TransferRowDeletedEvent IsNot Nothing Then
						p_TransferRowDeletedEvent(Me, New DataSetBarcode.P_TransferRowChangeEvent(CType(e.Row, DataSetBarcode.P_TransferRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x060008D7 RID: 2263 RVA: 0x000A499C File Offset: 0x000A2B9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.P_TransferRowDeletingEvent IsNot Nothing
				If flag Then
					Dim p_TransferRowDeletingEvent As DataSetBarcode.P_TransferRowChangeEventHandler = Me.P_TransferRowDeletingEvent
					If p_TransferRowDeletingEvent IsNot Nothing Then
						p_TransferRowDeletingEvent(Me, New DataSetBarcode.P_TransferRowChangeEvent(CType(e.Row, DataSetBarcode.P_TransferRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x060008D8 RID: 2264 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveP_TransferRow(row As DataSetBarcode.P_TransferRow)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x060008D9 RID: 2265 RVA: 0x000A49EC File Offset: 0x000A2BEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetBarcode As DataSetBarcode = New DataSetBarcode()
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
				xmlSchemaAttribute.FixedValue = dataSetBarcode.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "P_TransferDataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetBarcode.GetSchemaSerializable()
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

			' Token: 0x04000311 RID: 785
			Private columnID As DataColumn

			' Token: 0x04000312 RID: 786
			Private columnProductCode As DataColumn

			' Token: 0x04000313 RID: 787
			Private columnBarcode As DataColumn

			' Token: 0x04000314 RID: 788
			Private columnProductname As DataColumn

			' Token: 0x04000315 RID: 789
			Private columnHSNCode As DataColumn

			' Token: 0x04000316 RID: 790
			Private columnPartNo As DataColumn

			' Token: 0x04000317 RID: 791
			Private columnDescription As DataColumn

			' Token: 0x04000318 RID: 792
			Private columnCostPrice As DataColumn

			' Token: 0x04000319 RID: 793
			Private columnMRP As DataColumn

			' Token: 0x0400031A RID: 794
			Private columnSellingPrice As DataColumn

			' Token: 0x0400031B RID: 795
			Private columnReorderPoint As DataColumn

			' Token: 0x0400031C RID: 796
			Private columnDiscount As DataColumn

			' Token: 0x0400031D RID: 797
			Private columnCGST As DataColumn

			' Token: 0x0400031E RID: 798
			Private columnSGST As DataColumn

			' Token: 0x0400031F RID: 799
			Private columnCESS As DataColumn

			' Token: 0x04000320 RID: 800
			Private columnPurchaseUnit As DataColumn

			' Token: 0x04000321 RID: 801
			Private columnSalesunit As DataColumn

			' Token: 0x04000322 RID: 802
			Private columnSalesAltUnit As DataColumn

			' Token: 0x04000323 RID: 803
			Private columnConv As DataColumn

			' Token: 0x04000324 RID: 804
			Private columnMinStock As DataColumn

			' Token: 0x04000325 RID: 805
			Private columnGDown As DataColumn

			' Token: 0x04000326 RID: 806
			Private columnRack As DataColumn

			' Token: 0x04000327 RID: 807
			Private columnDefQty As DataColumn

			' Token: 0x04000328 RID: 808
			Private columnPPrice As DataColumn

			' Token: 0x04000329 RID: 809
			Private columnTemp_StockMRP As DataColumn

			' Token: 0x0400032A RID: 810
			Private columnSPrice As DataColumn

			' Token: 0x0400032B RID: 811
			Private columnWPrice As DataColumn

			' Token: 0x0400032C RID: 812
			Private columnBatch As DataColumn

			' Token: 0x0400032D RID: 813
			Private columnMfgdate As DataColumn

			' Token: 0x0400032E RID: 814
			Private columnExpdate As DataColumn

			' Token: 0x0400032F RID: 815
			Private columnColour As DataColumn

			' Token: 0x04000330 RID: 816
			Private columnSize As DataColumn

			' Token: 0x04000331 RID: 817
			Private columnIMEI1 As DataColumn

			' Token: 0x04000332 RID: 818
			Private columnIMEI2 As DataColumn

			' Token: 0x04000333 RID: 819
			Private columnStatus As DataColumn

			' Token: 0x04000334 RID: 820
			Private columnQrBarcode As DataColumn

			' Token: 0x04000335 RID: 821
			Private columnSuplName As DataColumn

			' Token: 0x04000336 RID: 822
			Private columnTocknNo As DataColumn

			' Token: 0x04000337 RID: 823
			Private columnPID As DataColumn

			' Token: 0x04000338 RID: 824
			Private columnPStatus As DataColumn

			' Token: 0x04000339 RID: 825
			Private columnT_Qty As DataColumn

			' Token: 0x0400033A RID: 826
			Private columnPAdmin As DataColumn

			' Token: 0x0400033B RID: 827
			Private columnPBranchFrom As DataColumn

			' Token: 0x0400033C RID: 828
			Private columnPBranchTo As DataColumn

			' Token: 0x0400033D RID: 829
			Private columnRemarks As DataColumn

			' Token: 0x0400033E RID: 830
			Private columnPostDate As DataColumn

			' Token: 0x0400033F RID: 831
			Private columnbranchcode As DataColumn

			' Token: 0x04000340 RID: 832
			Private columnCategory As DataColumn

			' Token: 0x04000341 RID: 833
			Private columnSubCategoryName As DataColumn
		End Class

		' Token: 0x02000031 RID: 49
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x060008DA RID: 2266 RVA: 0x0000A608 File Offset: 0x00008808
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, DataSetBarcode.DataTable1DataTable)
			End Sub

			' Token: 0x1700041F RID: 1055
			' (get) Token: 0x060008DB RID: 2267 RVA: 0x000A4C40 File Offset: 0x000A2E40
			' (set) Token: 0x060008DC RID: 2268 RVA: 0x0000A624 File Offset: 0x00008824
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

			' Token: 0x17000420 RID: 1056
			' (get) Token: 0x060008DD RID: 2269 RVA: 0x000A4C90 File Offset: 0x000A2E90
			' (set) Token: 0x060008DE RID: 2270 RVA: 0x0000A63A File Offset: 0x0000883A
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

			' Token: 0x17000421 RID: 1057
			' (get) Token: 0x060008DF RID: 2271 RVA: 0x000A4CE0 File Offset: 0x000A2EE0
			' (set) Token: 0x060008E0 RID: 2272 RVA: 0x0000A650 File Offset: 0x00008850
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Description As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.DescriptionColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Description' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.DescriptionColumn) = value
				End Set
			End Property

			' Token: 0x17000422 RID: 1058
			' (get) Token: 0x060008E1 RID: 2273 RVA: 0x000A4D30 File Offset: 0x000A2F30
			' (set) Token: 0x060008E2 RID: 2274 RVA: 0x0000A666 File Offset: 0x00008866
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SellingPrice As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.SellingPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SellingPrice' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.SellingPriceColumn) = value
				End Set
			End Property

			' Token: 0x17000423 RID: 1059
			' (get) Token: 0x060008E3 RID: 2275 RVA: 0x000A4D80 File Offset: 0x000A2F80
			' (set) Token: 0x060008E4 RID: 2276 RVA: 0x0000A67C File Offset: 0x0000887C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CostPrice As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CostPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CostPrice' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CostPriceColumn) = value
				End Set
			End Property

			' Token: 0x17000424 RID: 1060
			' (get) Token: 0x060008E5 RID: 2277 RVA: 0x000A4DD0 File Offset: 0x000A2FD0
			' (set) Token: 0x060008E6 RID: 2278 RVA: 0x0000A692 File Offset: 0x00008892
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ReorderPoint As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.ReorderPointColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ReorderPoint' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.ReorderPointColumn) = value
				End Set
			End Property

			' Token: 0x17000425 RID: 1061
			' (get) Token: 0x060008E7 RID: 2279 RVA: 0x000A4E20 File Offset: 0x000A3020
			' (set) Token: 0x060008E8 RID: 2280 RVA: 0x0000A6A8 File Offset: 0x000088A8
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

			' Token: 0x17000426 RID: 1062
			' (get) Token: 0x060008E9 RID: 2281 RVA: 0x000A4E70 File Offset: 0x000A3070
			' (set) Token: 0x060008EA RID: 2282 RVA: 0x0000A6BE File Offset: 0x000088BE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property HSNCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.HSNCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'HSNCode' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.HSNCodeColumn) = value
				End Set
			End Property

			' Token: 0x17000427 RID: 1063
			' (get) Token: 0x060008EB RID: 2283 RVA: 0x000A4EC0 File Offset: 0x000A30C0
			' (set) Token: 0x060008EC RID: 2284 RVA: 0x0000A6D4 File Offset: 0x000088D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PartNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.PartNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PartNo' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.PartNoColumn) = value
				End Set
			End Property

			' Token: 0x17000428 RID: 1064
			' (get) Token: 0x060008ED RID: 2285 RVA: 0x000A4F10 File Offset: 0x000A3110
			' (set) Token: 0x060008EE RID: 2286 RVA: 0x0000A6EA File Offset: 0x000088EA
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

			' Token: 0x17000429 RID: 1065
			' (get) Token: 0x060008EF RID: 2287 RVA: 0x000A4F60 File Offset: 0x000A3160
			' (set) Token: 0x060008F0 RID: 2288 RVA: 0x0000A700 File Offset: 0x00008900
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGST' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CGSTColumn) = value
				End Set
			End Property

			' Token: 0x1700042A RID: 1066
			' (get) Token: 0x060008F1 RID: 2289 RVA: 0x000A4FB0 File Offset: 0x000A31B0
			' (set) Token: 0x060008F2 RID: 2290 RVA: 0x0000A716 File Offset: 0x00008916
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

			' Token: 0x1700042B RID: 1067
			' (get) Token: 0x060008F3 RID: 2291 RVA: 0x000A5000 File Offset: 0x000A3200
			' (set) Token: 0x060008F4 RID: 2292 RVA: 0x0000A72C File Offset: 0x0000892C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CBarcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CBarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CBarcode' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CBarcodeColumn) = value
				End Set
			End Property

			' Token: 0x060008F5 RID: 2293 RVA: 0x000A5050 File Offset: 0x000A3250
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ProductNameColumn)
			End Function

			' Token: 0x060008F6 RID: 2294 RVA: 0x0000A742 File Offset: 0x00008942
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductNameNull()
				MyBase.Item(Me.tableDataTable1.ProductNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060008F7 RID: 2295 RVA: 0x000A5074 File Offset: 0x000A3274
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.BarcodeColumn)
			End Function

			' Token: 0x060008F8 RID: 2296 RVA: 0x0000A761 File Offset: 0x00008961
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableDataTable1.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060008F9 RID: 2297 RVA: 0x000A5098 File Offset: 0x000A3298
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDescriptionNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.DescriptionColumn)
			End Function

			' Token: 0x060008FA RID: 2298 RVA: 0x0000A780 File Offset: 0x00008980
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDescriptionNull()
				MyBase.Item(Me.tableDataTable1.DescriptionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060008FB RID: 2299 RVA: 0x000A50BC File Offset: 0x000A32BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSellingPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.SellingPriceColumn)
			End Function

			' Token: 0x060008FC RID: 2300 RVA: 0x0000A79F File Offset: 0x0000899F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSellingPriceNull()
				MyBase.Item(Me.tableDataTable1.SellingPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060008FD RID: 2301 RVA: 0x000A50E0 File Offset: 0x000A32E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCostPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CostPriceColumn)
			End Function

			' Token: 0x060008FE RID: 2302 RVA: 0x0000A7BE File Offset: 0x000089BE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCostPriceNull()
				MyBase.Item(Me.tableDataTable1.CostPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060008FF RID: 2303 RVA: 0x000A5104 File Offset: 0x000A3304
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsReorderPointNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ReorderPointColumn)
			End Function

			' Token: 0x06000900 RID: 2304 RVA: 0x0000A7DD File Offset: 0x000089DD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetReorderPointNull()
				MyBase.Item(Me.tableDataTable1.ReorderPointColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000901 RID: 2305 RVA: 0x000A5128 File Offset: 0x000A3328
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.MRPColumn)
			End Function

			' Token: 0x06000902 RID: 2306 RVA: 0x0000A7FC File Offset: 0x000089FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMRPNull()
				MyBase.Item(Me.tableDataTable1.MRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000903 RID: 2307 RVA: 0x000A514C File Offset: 0x000A334C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.HSNCodeColumn)
			End Function

			' Token: 0x06000904 RID: 2308 RVA: 0x0000A81B File Offset: 0x00008A1B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCodeNull()
				MyBase.Item(Me.tableDataTable1.HSNCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000905 RID: 2309 RVA: 0x000A5170 File Offset: 0x000A3370
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPartNoNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PartNoColumn)
			End Function

			' Token: 0x06000906 RID: 2310 RVA: 0x0000A83A File Offset: 0x00008A3A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPartNoNull()
				MyBase.Item(Me.tableDataTable1.PartNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000907 RID: 2311 RVA: 0x000A5194 File Offset: 0x000A3394
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.DiscountColumn)
			End Function

			' Token: 0x06000908 RID: 2312 RVA: 0x0000A859 File Offset: 0x00008A59
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountNull()
				MyBase.Item(Me.tableDataTable1.DiscountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000909 RID: 2313 RVA: 0x000A51B8 File Offset: 0x000A33B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CGSTColumn)
			End Function

			' Token: 0x0600090A RID: 2314 RVA: 0x0000A878 File Offset: 0x00008A78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTNull()
				MyBase.Item(Me.tableDataTable1.CGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600090B RID: 2315 RVA: 0x000A51DC File Offset: 0x000A33DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ProductCodeColumn)
			End Function

			' Token: 0x0600090C RID: 2316 RVA: 0x0000A897 File Offset: 0x00008A97
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductCodeNull()
				MyBase.Item(Me.tableDataTable1.ProductCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600090D RID: 2317 RVA: 0x000A5200 File Offset: 0x000A3400
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CBarcodeColumn)
			End Function

			' Token: 0x0600090E RID: 2318 RVA: 0x0000A8B6 File Offset: 0x00008AB6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCBarcodeNull()
				MyBase.Item(Me.tableDataTable1.CBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x04000346 RID: 838
			Private tableDataTable1 As DataSetBarcode.DataTable1DataTable
		End Class

		' Token: 0x02000032 RID: 50
		Public Class P_TransferRow
			Inherits DataRow

			' Token: 0x0600090F RID: 2319 RVA: 0x0000A8D5 File Offset: 0x00008AD5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableP_Transfer = CType(MyBase.Table, DataSetBarcode.P_TransferDataTable)
			End Sub

			' Token: 0x1700042C RID: 1068
			' (get) Token: 0x06000910 RID: 2320 RVA: 0x000A5224 File Offset: 0x000A3424
			' (set) Token: 0x06000911 RID: 2321 RVA: 0x0000A8F1 File Offset: 0x00008AF1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.IDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ID' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.IDColumn) = value
				End Set
			End Property

			' Token: 0x1700042D RID: 1069
			' (get) Token: 0x06000912 RID: 2322 RVA: 0x000A5274 File Offset: 0x000A3474
			' (set) Token: 0x06000913 RID: 2323 RVA: 0x0000A907 File Offset: 0x00008B07
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.ProductCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductCode' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.ProductCodeColumn) = value
				End Set
			End Property

			' Token: 0x1700042E RID: 1070
			' (get) Token: 0x06000914 RID: 2324 RVA: 0x000A52C4 File Offset: 0x000A34C4
			' (set) Token: 0x06000915 RID: 2325 RVA: 0x0000A91D File Offset: 0x00008B1D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Barcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.BarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Barcode' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.BarcodeColumn) = value
				End Set
			End Property

			' Token: 0x1700042F RID: 1071
			' (get) Token: 0x06000916 RID: 2326 RVA: 0x000A5314 File Offset: 0x000A3514
			' (set) Token: 0x06000917 RID: 2327 RVA: 0x0000A933 File Offset: 0x00008B33
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Productname As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.ProductnameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Productname' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.ProductnameColumn) = value
				End Set
			End Property

			' Token: 0x17000430 RID: 1072
			' (get) Token: 0x06000918 RID: 2328 RVA: 0x000A5364 File Offset: 0x000A3564
			' (set) Token: 0x06000919 RID: 2329 RVA: 0x0000A949 File Offset: 0x00008B49
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property HSNCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.HSNCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'HSNCode' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.HSNCodeColumn) = value
				End Set
			End Property

			' Token: 0x17000431 RID: 1073
			' (get) Token: 0x0600091A RID: 2330 RVA: 0x000A53B4 File Offset: 0x000A35B4
			' (set) Token: 0x0600091B RID: 2331 RVA: 0x0000A95F File Offset: 0x00008B5F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PartNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.PartNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PartNo' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.PartNoColumn) = value
				End Set
			End Property

			' Token: 0x17000432 RID: 1074
			' (get) Token: 0x0600091C RID: 2332 RVA: 0x000A5404 File Offset: 0x000A3604
			' (set) Token: 0x0600091D RID: 2333 RVA: 0x0000A975 File Offset: 0x00008B75
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Description As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.DescriptionColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Description' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.DescriptionColumn) = value
				End Set
			End Property

			' Token: 0x17000433 RID: 1075
			' (get) Token: 0x0600091E RID: 2334 RVA: 0x000A5454 File Offset: 0x000A3654
			' (set) Token: 0x0600091F RID: 2335 RVA: 0x0000A98B File Offset: 0x00008B8B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CostPrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.CostPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CostPrice' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.CostPriceColumn) = value
				End Set
			End Property

			' Token: 0x17000434 RID: 1076
			' (get) Token: 0x06000920 RID: 2336 RVA: 0x000A54A4 File Offset: 0x000A36A4
			' (set) Token: 0x06000921 RID: 2337 RVA: 0x0000A9A6 File Offset: 0x00008BA6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MRP As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.MRPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MRP' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.MRPColumn) = value
				End Set
			End Property

			' Token: 0x17000435 RID: 1077
			' (get) Token: 0x06000922 RID: 2338 RVA: 0x000A54F4 File Offset: 0x000A36F4
			' (set) Token: 0x06000923 RID: 2339 RVA: 0x0000A9C1 File Offset: 0x00008BC1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SellingPrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.SellingPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SellingPrice' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.SellingPriceColumn) = value
				End Set
			End Property

			' Token: 0x17000436 RID: 1078
			' (get) Token: 0x06000924 RID: 2340 RVA: 0x000A5544 File Offset: 0x000A3744
			' (set) Token: 0x06000925 RID: 2341 RVA: 0x0000A9DC File Offset: 0x00008BDC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ReorderPoint As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.ReorderPointColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ReorderPoint' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.ReorderPointColumn) = value
				End Set
			End Property

			' Token: 0x17000437 RID: 1079
			' (get) Token: 0x06000926 RID: 2342 RVA: 0x000A5594 File Offset: 0x000A3794
			' (set) Token: 0x06000927 RID: 2343 RVA: 0x0000A9F7 File Offset: 0x00008BF7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Discount As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.DiscountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Discount' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.DiscountColumn) = value
				End Set
			End Property

			' Token: 0x17000438 RID: 1080
			' (get) Token: 0x06000928 RID: 2344 RVA: 0x000A55E4 File Offset: 0x000A37E4
			' (set) Token: 0x06000929 RID: 2345 RVA: 0x0000AA12 File Offset: 0x00008C12
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGST As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.CGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGST' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.CGSTColumn) = value
				End Set
			End Property

			' Token: 0x17000439 RID: 1081
			' (get) Token: 0x0600092A RID: 2346 RVA: 0x000A5634 File Offset: 0x000A3834
			' (set) Token: 0x0600092B RID: 2347 RVA: 0x0000AA2D File Offset: 0x00008C2D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGST As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.SGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGST' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.SGSTColumn) = value
				End Set
			End Property

			' Token: 0x1700043A RID: 1082
			' (get) Token: 0x0600092C RID: 2348 RVA: 0x000A5684 File Offset: 0x000A3884
			' (set) Token: 0x0600092D RID: 2349 RVA: 0x0000AA48 File Offset: 0x00008C48
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESS As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.CESSColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESS' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.CESSColumn) = value
				End Set
			End Property

			' Token: 0x1700043B RID: 1083
			' (get) Token: 0x0600092E RID: 2350 RVA: 0x000A56D4 File Offset: 0x000A38D4
			' (set) Token: 0x0600092F RID: 2351 RVA: 0x0000AA63 File Offset: 0x00008C63
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PurchaseUnit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.PurchaseUnitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PurchaseUnit' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.PurchaseUnitColumn) = value
				End Set
			End Property

			' Token: 0x1700043C RID: 1084
			' (get) Token: 0x06000930 RID: 2352 RVA: 0x000A5724 File Offset: 0x000A3924
			' (set) Token: 0x06000931 RID: 2353 RVA: 0x0000AA79 File Offset: 0x00008C79
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Salesunit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.SalesunitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Salesunit' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.SalesunitColumn) = value
				End Set
			End Property

			' Token: 0x1700043D RID: 1085
			' (get) Token: 0x06000932 RID: 2354 RVA: 0x000A5774 File Offset: 0x000A3974
			' (set) Token: 0x06000933 RID: 2355 RVA: 0x0000AA8F File Offset: 0x00008C8F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SalesAltUnit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.SalesAltUnitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SalesAltUnit' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.SalesAltUnitColumn) = value
				End Set
			End Property

			' Token: 0x1700043E RID: 1086
			' (get) Token: 0x06000934 RID: 2356 RVA: 0x000A57C4 File Offset: 0x000A39C4
			' (set) Token: 0x06000935 RID: 2357 RVA: 0x0000AAA5 File Offset: 0x00008CA5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Conv As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.ConvColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Conv' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.ConvColumn) = value
				End Set
			End Property

			' Token: 0x1700043F RID: 1087
			' (get) Token: 0x06000936 RID: 2358 RVA: 0x000A5814 File Offset: 0x000A3A14
			' (set) Token: 0x06000937 RID: 2359 RVA: 0x0000AABB File Offset: 0x00008CBB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MinStock As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.MinStockColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MinStock' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.MinStockColumn) = value
				End Set
			End Property

			' Token: 0x17000440 RID: 1088
			' (get) Token: 0x06000938 RID: 2360 RVA: 0x000A5864 File Offset: 0x000A3A64
			' (set) Token: 0x06000939 RID: 2361 RVA: 0x0000AAD1 File Offset: 0x00008CD1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GDown As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.GDownColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GDown' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.GDownColumn) = value
				End Set
			End Property

			' Token: 0x17000441 RID: 1089
			' (get) Token: 0x0600093A RID: 2362 RVA: 0x000A58B4 File Offset: 0x000A3AB4
			' (set) Token: 0x0600093B RID: 2363 RVA: 0x0000AAE7 File Offset: 0x00008CE7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Rack As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.RackColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Rack' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.RackColumn) = value
				End Set
			End Property

			' Token: 0x17000442 RID: 1090
			' (get) Token: 0x0600093C RID: 2364 RVA: 0x000A5904 File Offset: 0x000A3B04
			' (set) Token: 0x0600093D RID: 2365 RVA: 0x0000AAFD File Offset: 0x00008CFD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property DefQty As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.DefQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'DefQty' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.DefQtyColumn) = value
				End Set
			End Property

			' Token: 0x17000443 RID: 1091
			' (get) Token: 0x0600093E RID: 2366 RVA: 0x000A5954 File Offset: 0x000A3B54
			' (set) Token: 0x0600093F RID: 2367 RVA: 0x0000AB18 File Offset: 0x00008D18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PPrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.PPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PPrice' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.PPriceColumn) = value
				End Set
			End Property

			' Token: 0x17000444 RID: 1092
			' (get) Token: 0x06000940 RID: 2368 RVA: 0x000A59A4 File Offset: 0x000A3BA4
			' (set) Token: 0x06000941 RID: 2369 RVA: 0x0000AB33 File Offset: 0x00008D33
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Temp_StockMRP As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.Temp_StockMRPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Temp_StockMRP' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.Temp_StockMRPColumn) = value
				End Set
			End Property

			' Token: 0x17000445 RID: 1093
			' (get) Token: 0x06000942 RID: 2370 RVA: 0x000A59F4 File Offset: 0x000A3BF4
			' (set) Token: 0x06000943 RID: 2371 RVA: 0x0000AB4E File Offset: 0x00008D4E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SPrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.SPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SPrice' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.SPriceColumn) = value
				End Set
			End Property

			' Token: 0x17000446 RID: 1094
			' (get) Token: 0x06000944 RID: 2372 RVA: 0x000A5A44 File Offset: 0x000A3C44
			' (set) Token: 0x06000945 RID: 2373 RVA: 0x0000AB69 File Offset: 0x00008D69
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property WPrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.WPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'WPrice' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.WPriceColumn) = value
				End Set
			End Property

			' Token: 0x17000447 RID: 1095
			' (get) Token: 0x06000946 RID: 2374 RVA: 0x000A5A94 File Offset: 0x000A3C94
			' (set) Token: 0x06000947 RID: 2375 RVA: 0x0000AB84 File Offset: 0x00008D84
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Batch As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.BatchColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Batch' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.BatchColumn) = value
				End Set
			End Property

			' Token: 0x17000448 RID: 1096
			' (get) Token: 0x06000948 RID: 2376 RVA: 0x000A5AE4 File Offset: 0x000A3CE4
			' (set) Token: 0x06000949 RID: 2377 RVA: 0x0000AB9A File Offset: 0x00008D9A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Mfgdate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.MfgdateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Mfgdate' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.MfgdateColumn) = value
				End Set
			End Property

			' Token: 0x17000449 RID: 1097
			' (get) Token: 0x0600094A RID: 2378 RVA: 0x000A5B34 File Offset: 0x000A3D34
			' (set) Token: 0x0600094B RID: 2379 RVA: 0x0000ABB0 File Offset: 0x00008DB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Expdate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.ExpdateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Expdate' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.ExpdateColumn) = value
				End Set
			End Property

			' Token: 0x1700044A RID: 1098
			' (get) Token: 0x0600094C RID: 2380 RVA: 0x000A5B84 File Offset: 0x000A3D84
			' (set) Token: 0x0600094D RID: 2381 RVA: 0x0000ABC6 File Offset: 0x00008DC6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Colour As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.ColourColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Colour' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.ColourColumn) = value
				End Set
			End Property

			' Token: 0x1700044B RID: 1099
			' (get) Token: 0x0600094E RID: 2382 RVA: 0x000A5BD4 File Offset: 0x000A3DD4
			' (set) Token: 0x0600094F RID: 2383 RVA: 0x0000ABDC File Offset: 0x00008DDC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Size As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.SizeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Size' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.SizeColumn) = value
				End Set
			End Property

			' Token: 0x1700044C RID: 1100
			' (get) Token: 0x06000950 RID: 2384 RVA: 0x000A5C24 File Offset: 0x000A3E24
			' (set) Token: 0x06000951 RID: 2385 RVA: 0x0000ABF2 File Offset: 0x00008DF2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IMEI1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.IMEI1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IMEI1' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.IMEI1Column) = value
				End Set
			End Property

			' Token: 0x1700044D RID: 1101
			' (get) Token: 0x06000952 RID: 2386 RVA: 0x000A5C74 File Offset: 0x000A3E74
			' (set) Token: 0x06000953 RID: 2387 RVA: 0x0000AC08 File Offset: 0x00008E08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IMEI2 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.IMEI2Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IMEI2' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.IMEI2Column) = value
				End Set
			End Property

			' Token: 0x1700044E RID: 1102
			' (get) Token: 0x06000954 RID: 2388 RVA: 0x000A5CC4 File Offset: 0x000A3EC4
			' (set) Token: 0x06000955 RID: 2389 RVA: 0x0000AC1E File Offset: 0x00008E1E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Status As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.StatusColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Status' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.StatusColumn) = value
				End Set
			End Property

			' Token: 0x1700044F RID: 1103
			' (get) Token: 0x06000956 RID: 2390 RVA: 0x000A5D14 File Offset: 0x000A3F14
			' (set) Token: 0x06000957 RID: 2391 RVA: 0x0000AC34 File Offset: 0x00008E34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property QrBarcode As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableP_Transfer.QrBarcodeColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'QrBarcode' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableP_Transfer.QrBarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17000450 RID: 1104
			' (get) Token: 0x06000958 RID: 2392 RVA: 0x000A5D64 File Offset: 0x000A3F64
			' (set) Token: 0x06000959 RID: 2393 RVA: 0x0000AC4A File Offset: 0x00008E4A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SuplName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.SuplNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SuplName' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.SuplNameColumn) = value
				End Set
			End Property

			' Token: 0x17000451 RID: 1105
			' (get) Token: 0x0600095A RID: 2394 RVA: 0x000A5DB4 File Offset: 0x000A3FB4
			' (set) Token: 0x0600095B RID: 2395 RVA: 0x0000AC60 File Offset: 0x00008E60
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TocknNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.TocknNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TocknNo' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.TocknNoColumn) = value
				End Set
			End Property

			' Token: 0x17000452 RID: 1106
			' (get) Token: 0x0600095C RID: 2396 RVA: 0x000A5E04 File Offset: 0x000A4004
			' (set) Token: 0x0600095D RID: 2397 RVA: 0x0000AC76 File Offset: 0x00008E76
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.PIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PID' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.PIDColumn) = value
				End Set
			End Property

			' Token: 0x17000453 RID: 1107
			' (get) Token: 0x0600095E RID: 2398 RVA: 0x000A5E54 File Offset: 0x000A4054
			' (set) Token: 0x0600095F RID: 2399 RVA: 0x0000AC8C File Offset: 0x00008E8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PStatus As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.PStatusColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PStatus' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.PStatusColumn) = value
				End Set
			End Property

			' Token: 0x17000454 RID: 1108
			' (get) Token: 0x06000960 RID: 2400 RVA: 0x000A5EA4 File Offset: 0x000A40A4
			' (set) Token: 0x06000961 RID: 2401 RVA: 0x0000ACA2 File Offset: 0x00008EA2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property T_Qty As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableP_Transfer.T_QtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'T_Qty' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableP_Transfer.T_QtyColumn) = value
				End Set
			End Property

			' Token: 0x17000455 RID: 1109
			' (get) Token: 0x06000962 RID: 2402 RVA: 0x000A5EF4 File Offset: 0x000A40F4
			' (set) Token: 0x06000963 RID: 2403 RVA: 0x0000ACBD File Offset: 0x00008EBD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PAdmin As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.PAdminColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PAdmin' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.PAdminColumn) = value
				End Set
			End Property

			' Token: 0x17000456 RID: 1110
			' (get) Token: 0x06000964 RID: 2404 RVA: 0x000A5F44 File Offset: 0x000A4144
			' (set) Token: 0x06000965 RID: 2405 RVA: 0x0000ACD3 File Offset: 0x00008ED3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PBranchFrom As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.PBranchFromColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PBranchFrom' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.PBranchFromColumn) = value
				End Set
			End Property

			' Token: 0x17000457 RID: 1111
			' (get) Token: 0x06000966 RID: 2406 RVA: 0x000A5F94 File Offset: 0x000A4194
			' (set) Token: 0x06000967 RID: 2407 RVA: 0x0000ACE9 File Offset: 0x00008EE9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PBranchTo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.PBranchToColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PBranchTo' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.PBranchToColumn) = value
				End Set
			End Property

			' Token: 0x17000458 RID: 1112
			' (get) Token: 0x06000968 RID: 2408 RVA: 0x000A5FE4 File Offset: 0x000A41E4
			' (set) Token: 0x06000969 RID: 2409 RVA: 0x0000ACFF File Offset: 0x00008EFF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Remarks As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.RemarksColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Remarks' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.RemarksColumn) = value
				End Set
			End Property

			' Token: 0x17000459 RID: 1113
			' (get) Token: 0x0600096A RID: 2410 RVA: 0x000A6034 File Offset: 0x000A4234
			' (set) Token: 0x0600096B RID: 2411 RVA: 0x0000AD15 File Offset: 0x00008F15
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PostDate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.PostDateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PostDate' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.PostDateColumn) = value
				End Set
			End Property

			' Token: 0x1700045A RID: 1114
			' (get) Token: 0x0600096C RID: 2412 RVA: 0x000A6084 File Offset: 0x000A4284
			' (set) Token: 0x0600096D RID: 2413 RVA: 0x0000AD2B File Offset: 0x00008F2B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property branchcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.branchcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'branchcode' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.branchcodeColumn) = value
				End Set
			End Property

			' Token: 0x1700045B RID: 1115
			' (get) Token: 0x0600096E RID: 2414 RVA: 0x000A60D4 File Offset: 0x000A42D4
			' (set) Token: 0x0600096F RID: 2415 RVA: 0x0000AD41 File Offset: 0x00008F41
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Category As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.CategoryColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Category' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.CategoryColumn) = value
				End Set
			End Property

			' Token: 0x1700045C RID: 1116
			' (get) Token: 0x06000970 RID: 2416 RVA: 0x000A6124 File Offset: 0x000A4324
			' (set) Token: 0x06000971 RID: 2417 RVA: 0x0000AD57 File Offset: 0x00008F57
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SubCategoryName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.SubCategoryNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SubCategoryName' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.SubCategoryNameColumn) = value
				End Set
			End Property

			' Token: 0x06000972 RID: 2418 RVA: 0x000A6174 File Offset: 0x000A4374
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIDNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.IDColumn)
			End Function

			' Token: 0x06000973 RID: 2419 RVA: 0x0000AD6D File Offset: 0x00008F6D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIDNull()
				MyBase.Item(Me.tableP_Transfer.IDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000974 RID: 2420 RVA: 0x000A6198 File Offset: 0x000A4398
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ProductCodeColumn)
			End Function

			' Token: 0x06000975 RID: 2421 RVA: 0x0000AD8C File Offset: 0x00008F8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductCodeNull()
				MyBase.Item(Me.tableP_Transfer.ProductCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000976 RID: 2422 RVA: 0x000A61BC File Offset: 0x000A43BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.BarcodeColumn)
			End Function

			' Token: 0x06000977 RID: 2423 RVA: 0x0000ADAB File Offset: 0x00008FAB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableP_Transfer.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000978 RID: 2424 RVA: 0x000A61E0 File Offset: 0x000A43E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductnameNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ProductnameColumn)
			End Function

			' Token: 0x06000979 RID: 2425 RVA: 0x0000ADCA File Offset: 0x00008FCA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductnameNull()
				MyBase.Item(Me.tableP_Transfer.ProductnameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600097A RID: 2426 RVA: 0x000A6204 File Offset: 0x000A4404
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.HSNCodeColumn)
			End Function

			' Token: 0x0600097B RID: 2427 RVA: 0x0000ADE9 File Offset: 0x00008FE9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCodeNull()
				MyBase.Item(Me.tableP_Transfer.HSNCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600097C RID: 2428 RVA: 0x000A6228 File Offset: 0x000A4428
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPartNoNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PartNoColumn)
			End Function

			' Token: 0x0600097D RID: 2429 RVA: 0x0000AE08 File Offset: 0x00009008
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPartNoNull()
				MyBase.Item(Me.tableP_Transfer.PartNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600097E RID: 2430 RVA: 0x000A624C File Offset: 0x000A444C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDescriptionNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.DescriptionColumn)
			End Function

			' Token: 0x0600097F RID: 2431 RVA: 0x0000AE27 File Offset: 0x00009027
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDescriptionNull()
				MyBase.Item(Me.tableP_Transfer.DescriptionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000980 RID: 2432 RVA: 0x000A6270 File Offset: 0x000A4470
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCostPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.CostPriceColumn)
			End Function

			' Token: 0x06000981 RID: 2433 RVA: 0x0000AE46 File Offset: 0x00009046
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCostPriceNull()
				MyBase.Item(Me.tableP_Transfer.CostPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000982 RID: 2434 RVA: 0x000A6294 File Offset: 0x000A4494
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.MRPColumn)
			End Function

			' Token: 0x06000983 RID: 2435 RVA: 0x0000AE65 File Offset: 0x00009065
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMRPNull()
				MyBase.Item(Me.tableP_Transfer.MRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000984 RID: 2436 RVA: 0x000A62B8 File Offset: 0x000A44B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSellingPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SellingPriceColumn)
			End Function

			' Token: 0x06000985 RID: 2437 RVA: 0x0000AE84 File Offset: 0x00009084
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSellingPriceNull()
				MyBase.Item(Me.tableP_Transfer.SellingPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000986 RID: 2438 RVA: 0x000A62DC File Offset: 0x000A44DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsReorderPointNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ReorderPointColumn)
			End Function

			' Token: 0x06000987 RID: 2439 RVA: 0x0000AEA3 File Offset: 0x000090A3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetReorderPointNull()
				MyBase.Item(Me.tableP_Transfer.ReorderPointColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000988 RID: 2440 RVA: 0x000A6300 File Offset: 0x000A4500
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.DiscountColumn)
			End Function

			' Token: 0x06000989 RID: 2441 RVA: 0x0000AEC2 File Offset: 0x000090C2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountNull()
				MyBase.Item(Me.tableP_Transfer.DiscountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600098A RID: 2442 RVA: 0x000A6324 File Offset: 0x000A4524
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.CGSTColumn)
			End Function

			' Token: 0x0600098B RID: 2443 RVA: 0x0000AEE1 File Offset: 0x000090E1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTNull()
				MyBase.Item(Me.tableP_Transfer.CGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600098C RID: 2444 RVA: 0x000A6348 File Offset: 0x000A4548
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SGSTColumn)
			End Function

			' Token: 0x0600098D RID: 2445 RVA: 0x0000AF00 File Offset: 0x00009100
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTNull()
				MyBase.Item(Me.tableP_Transfer.SGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600098E RID: 2446 RVA: 0x000A636C File Offset: 0x000A456C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.CESSColumn)
			End Function

			' Token: 0x0600098F RID: 2447 RVA: 0x0000AF1F File Offset: 0x0000911F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSNull()
				MyBase.Item(Me.tableP_Transfer.CESSColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000990 RID: 2448 RVA: 0x000A6390 File Offset: 0x000A4590
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPurchaseUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PurchaseUnitColumn)
			End Function

			' Token: 0x06000991 RID: 2449 RVA: 0x0000AF3E File Offset: 0x0000913E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPurchaseUnitNull()
				MyBase.Item(Me.tableP_Transfer.PurchaseUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000992 RID: 2450 RVA: 0x000A63B4 File Offset: 0x000A45B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalesunitNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SalesunitColumn)
			End Function

			' Token: 0x06000993 RID: 2451 RVA: 0x0000AF5D File Offset: 0x0000915D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalesunitNull()
				MyBase.Item(Me.tableP_Transfer.SalesunitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000994 RID: 2452 RVA: 0x000A63D8 File Offset: 0x000A45D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalesAltUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SalesAltUnitColumn)
			End Function

			' Token: 0x06000995 RID: 2453 RVA: 0x0000AF7C File Offset: 0x0000917C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalesAltUnitNull()
				MyBase.Item(Me.tableP_Transfer.SalesAltUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000996 RID: 2454 RVA: 0x000A63FC File Offset: 0x000A45FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsConvNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ConvColumn)
			End Function

			' Token: 0x06000997 RID: 2455 RVA: 0x0000AF9B File Offset: 0x0000919B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetConvNull()
				MyBase.Item(Me.tableP_Transfer.ConvColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000998 RID: 2456 RVA: 0x000A6420 File Offset: 0x000A4620
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMinStockNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.MinStockColumn)
			End Function

			' Token: 0x06000999 RID: 2457 RVA: 0x0000AFBA File Offset: 0x000091BA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMinStockNull()
				MyBase.Item(Me.tableP_Transfer.MinStockColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600099A RID: 2458 RVA: 0x000A6444 File Offset: 0x000A4644
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGDownNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.GDownColumn)
			End Function

			' Token: 0x0600099B RID: 2459 RVA: 0x0000AFD9 File Offset: 0x000091D9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGDownNull()
				MyBase.Item(Me.tableP_Transfer.GDownColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600099C RID: 2460 RVA: 0x000A6468 File Offset: 0x000A4668
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRackNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.RackColumn)
			End Function

			' Token: 0x0600099D RID: 2461 RVA: 0x0000AFF8 File Offset: 0x000091F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRackNull()
				MyBase.Item(Me.tableP_Transfer.RackColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600099E RID: 2462 RVA: 0x000A648C File Offset: 0x000A468C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDefQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.DefQtyColumn)
			End Function

			' Token: 0x0600099F RID: 2463 RVA: 0x0000B017 File Offset: 0x00009217
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDefQtyNull()
				MyBase.Item(Me.tableP_Transfer.DefQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009A0 RID: 2464 RVA: 0x000A64B0 File Offset: 0x000A46B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PPriceColumn)
			End Function

			' Token: 0x060009A1 RID: 2465 RVA: 0x0000B036 File Offset: 0x00009236
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPPriceNull()
				MyBase.Item(Me.tableP_Transfer.PPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009A2 RID: 2466 RVA: 0x000A64D4 File Offset: 0x000A46D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTemp_StockMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.Temp_StockMRPColumn)
			End Function

			' Token: 0x060009A3 RID: 2467 RVA: 0x0000B055 File Offset: 0x00009255
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTemp_StockMRPNull()
				MyBase.Item(Me.tableP_Transfer.Temp_StockMRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009A4 RID: 2468 RVA: 0x000A64F8 File Offset: 0x000A46F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SPriceColumn)
			End Function

			' Token: 0x060009A5 RID: 2469 RVA: 0x0000B074 File Offset: 0x00009274
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSPriceNull()
				MyBase.Item(Me.tableP_Transfer.SPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009A6 RID: 2470 RVA: 0x000A651C File Offset: 0x000A471C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsWPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.WPriceColumn)
			End Function

			' Token: 0x060009A7 RID: 2471 RVA: 0x0000B093 File Offset: 0x00009293
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetWPriceNull()
				MyBase.Item(Me.tableP_Transfer.WPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009A8 RID: 2472 RVA: 0x000A6540 File Offset: 0x000A4740
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBatchNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.BatchColumn)
			End Function

			' Token: 0x060009A9 RID: 2473 RVA: 0x0000B0B2 File Offset: 0x000092B2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBatchNull()
				MyBase.Item(Me.tableP_Transfer.BatchColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009AA RID: 2474 RVA: 0x000A6564 File Offset: 0x000A4764
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMfgdateNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.MfgdateColumn)
			End Function

			' Token: 0x060009AB RID: 2475 RVA: 0x0000B0D1 File Offset: 0x000092D1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMfgdateNull()
				MyBase.Item(Me.tableP_Transfer.MfgdateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009AC RID: 2476 RVA: 0x000A6588 File Offset: 0x000A4788
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsExpdateNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ExpdateColumn)
			End Function

			' Token: 0x060009AD RID: 2477 RVA: 0x0000B0F0 File Offset: 0x000092F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetExpdateNull()
				MyBase.Item(Me.tableP_Transfer.ExpdateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009AE RID: 2478 RVA: 0x000A65AC File Offset: 0x000A47AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsColourNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ColourColumn)
			End Function

			' Token: 0x060009AF RID: 2479 RVA: 0x0000B10F File Offset: 0x0000930F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetColourNull()
				MyBase.Item(Me.tableP_Transfer.ColourColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009B0 RID: 2480 RVA: 0x000A65D0 File Offset: 0x000A47D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSizeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SizeColumn)
			End Function

			' Token: 0x060009B1 RID: 2481 RVA: 0x0000B12E File Offset: 0x0000932E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSizeNull()
				MyBase.Item(Me.tableP_Transfer.SizeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009B2 RID: 2482 RVA: 0x000A65F4 File Offset: 0x000A47F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIMEI1Null() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.IMEI1Column)
			End Function

			' Token: 0x060009B3 RID: 2483 RVA: 0x0000B14D File Offset: 0x0000934D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIMEI1Null()
				MyBase.Item(Me.tableP_Transfer.IMEI1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009B4 RID: 2484 RVA: 0x000A6618 File Offset: 0x000A4818
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIMEI2Null() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.IMEI2Column)
			End Function

			' Token: 0x060009B5 RID: 2485 RVA: 0x0000B16C File Offset: 0x0000936C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIMEI2Null()
				MyBase.Item(Me.tableP_Transfer.IMEI2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009B6 RID: 2486 RVA: 0x000A663C File Offset: 0x000A483C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsStatusNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.StatusColumn)
			End Function

			' Token: 0x060009B7 RID: 2487 RVA: 0x0000B18B File Offset: 0x0000938B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetStatusNull()
				MyBase.Item(Me.tableP_Transfer.StatusColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009B8 RID: 2488 RVA: 0x000A6660 File Offset: 0x000A4860
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQrBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.QrBarcodeColumn)
			End Function

			' Token: 0x060009B9 RID: 2489 RVA: 0x0000B1AA File Offset: 0x000093AA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQrBarcodeNull()
				MyBase.Item(Me.tableP_Transfer.QrBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009BA RID: 2490 RVA: 0x000A6684 File Offset: 0x000A4884
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSuplNameNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SuplNameColumn)
			End Function

			' Token: 0x060009BB RID: 2491 RVA: 0x0000B1C9 File Offset: 0x000093C9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSuplNameNull()
				MyBase.Item(Me.tableP_Transfer.SuplNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009BC RID: 2492 RVA: 0x000A66A8 File Offset: 0x000A48A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTocknNoNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.TocknNoColumn)
			End Function

			' Token: 0x060009BD RID: 2493 RVA: 0x0000B1E8 File Offset: 0x000093E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTocknNoNull()
				MyBase.Item(Me.tableP_Transfer.TocknNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009BE RID: 2494 RVA: 0x000A66CC File Offset: 0x000A48CC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPIDNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PIDColumn)
			End Function

			' Token: 0x060009BF RID: 2495 RVA: 0x0000B207 File Offset: 0x00009407
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPIDNull()
				MyBase.Item(Me.tableP_Transfer.PIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009C0 RID: 2496 RVA: 0x000A66F0 File Offset: 0x000A48F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPStatusNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PStatusColumn)
			End Function

			' Token: 0x060009C1 RID: 2497 RVA: 0x0000B226 File Offset: 0x00009426
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPStatusNull()
				MyBase.Item(Me.tableP_Transfer.PStatusColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009C2 RID: 2498 RVA: 0x000A6714 File Offset: 0x000A4914
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsT_QtyNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.T_QtyColumn)
			End Function

			' Token: 0x060009C3 RID: 2499 RVA: 0x0000B245 File Offset: 0x00009445
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetT_QtyNull()
				MyBase.Item(Me.tableP_Transfer.T_QtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009C4 RID: 2500 RVA: 0x000A6738 File Offset: 0x000A4938
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPAdminNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PAdminColumn)
			End Function

			' Token: 0x060009C5 RID: 2501 RVA: 0x0000B264 File Offset: 0x00009464
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPAdminNull()
				MyBase.Item(Me.tableP_Transfer.PAdminColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009C6 RID: 2502 RVA: 0x000A675C File Offset: 0x000A495C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPBranchFromNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PBranchFromColumn)
			End Function

			' Token: 0x060009C7 RID: 2503 RVA: 0x0000B283 File Offset: 0x00009483
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPBranchFromNull()
				MyBase.Item(Me.tableP_Transfer.PBranchFromColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009C8 RID: 2504 RVA: 0x000A6780 File Offset: 0x000A4980
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPBranchToNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PBranchToColumn)
			End Function

			' Token: 0x060009C9 RID: 2505 RVA: 0x0000B2A2 File Offset: 0x000094A2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPBranchToNull()
				MyBase.Item(Me.tableP_Transfer.PBranchToColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009CA RID: 2506 RVA: 0x000A67A4 File Offset: 0x000A49A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRemarksNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.RemarksColumn)
			End Function

			' Token: 0x060009CB RID: 2507 RVA: 0x0000B2C1 File Offset: 0x000094C1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRemarksNull()
				MyBase.Item(Me.tableP_Transfer.RemarksColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009CC RID: 2508 RVA: 0x000A67C8 File Offset: 0x000A49C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPostDateNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PostDateColumn)
			End Function

			' Token: 0x060009CD RID: 2509 RVA: 0x0000B2E0 File Offset: 0x000094E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPostDateNull()
				MyBase.Item(Me.tableP_Transfer.PostDateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009CE RID: 2510 RVA: 0x000A67EC File Offset: 0x000A49EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsbranchcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.branchcodeColumn)
			End Function

			' Token: 0x060009CF RID: 2511 RVA: 0x0000B2FF File Offset: 0x000094FF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetbranchcodeNull()
				MyBase.Item(Me.tableP_Transfer.branchcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009D0 RID: 2512 RVA: 0x000A6810 File Offset: 0x000A4A10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCategoryNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.CategoryColumn)
			End Function

			' Token: 0x060009D1 RID: 2513 RVA: 0x0000B31E File Offset: 0x0000951E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCategoryNull()
				MyBase.Item(Me.tableP_Transfer.CategoryColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x060009D2 RID: 2514 RVA: 0x000A6834 File Offset: 0x000A4A34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSubCategoryNameNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SubCategoryNameColumn)
			End Function

			' Token: 0x060009D3 RID: 2515 RVA: 0x0000B33D File Offset: 0x0000953D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSubCategoryNameNull()
				MyBase.Item(Me.tableP_Transfer.SubCategoryNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x04000347 RID: 839
			Private tableP_Transfer As DataSetBarcode.P_TransferDataTable
		End Class

		' Token: 0x02000033 RID: 51
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x060009D4 RID: 2516 RVA: 0x0000B35C File Offset: 0x0000955C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetBarcode.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x1700045D RID: 1117
			' (get) Token: 0x060009D5 RID: 2517 RVA: 0x000A6858 File Offset: 0x000A4A58
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetBarcode.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x1700045E RID: 1118
			' (get) Token: 0x060009D6 RID: 2518 RVA: 0x000A6870 File Offset: 0x000A4A70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x04000348 RID: 840
			Private eventRow As DataSetBarcode.DataTable1Row

			' Token: 0x04000349 RID: 841
			Private eventAction As DataRowAction
		End Class

		' Token: 0x02000034 RID: 52
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class P_TransferRowChangeEvent
			Inherits EventArgs

			' Token: 0x060009D7 RID: 2519 RVA: 0x0000B374 File Offset: 0x00009574
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetBarcode.P_TransferRow, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x1700045F RID: 1119
			' (get) Token: 0x060009D8 RID: 2520 RVA: 0x000A6888 File Offset: 0x000A4A88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetBarcode.P_TransferRow
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17000460 RID: 1120
			' (get) Token: 0x060009D9 RID: 2521 RVA: 0x000A68A0 File Offset: 0x000A4AA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x0400034A RID: 842
			Private eventRow As DataSetBarcode.P_TransferRow

			' Token: 0x0400034B RID: 843
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
