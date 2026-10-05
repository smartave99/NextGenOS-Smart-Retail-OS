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
	' Token: 0x0200003A RID: 58
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSetPOSPrint")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSetPOSPrint
		Inherits DataSet

		' Token: 0x06000A4D RID: 2637 RVA: 0x000A7FD0 File Offset: 0x000A61D0
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

		' Token: 0x06000A4E RID: 2638 RVA: 0x000A8028 File Offset: 0x000A6228
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
						MyBase.Tables.Add(New DataSetPOSPrint.DataTable1DataTable(dataSet.Tables("DataTable1")))
					End If
					Dim flag4 As Boolean = dataSet.Tables("DataPurchaseReturn") IsNot Nothing
					If flag4 Then
						MyBase.Tables.Add(New DataSetPOSPrint.DataPurchaseReturnDataTable(dataSet.Tables("DataPurchaseReturn")))
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

		' Token: 0x17000481 RID: 1153
		' (get) Token: 0x06000A4F RID: 2639 RVA: 0x000A81FC File Offset: 0x000A63FC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As DataSetPOSPrint.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x17000482 RID: 1154
		' (get) Token: 0x06000A50 RID: 2640 RVA: 0x000A8214 File Offset: 0x000A6414
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataPurchaseReturn As DataSetPOSPrint.DataPurchaseReturnDataTable
			Get
				Return Me.tableDataPurchaseReturn
			End Get
		End Property

		' Token: 0x17000483 RID: 1155
		' (get) Token: 0x06000A51 RID: 2641 RVA: 0x000A822C File Offset: 0x000A642C
		' (set) Token: 0x06000A52 RID: 2642 RVA: 0x0000B6C5 File Offset: 0x000098C5
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

		' Token: 0x17000484 RID: 1156
		' (get) Token: 0x06000A53 RID: 2643 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x17000485 RID: 1157
		' (get) Token: 0x06000A54 RID: 2644 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x06000A55 RID: 2645 RVA: 0x0000B6CF File Offset: 0x000098CF
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x06000A56 RID: 2646 RVA: 0x000A8244 File Offset: 0x000A6444
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSetPOSPrint As DataSetPOSPrint = CType(MyBase.Clone(), DataSetPOSPrint)
			dataSetPOSPrint.InitVars()
			dataSetPOSPrint.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSetPOSPrint
		End Function

		' Token: 0x06000A57 RID: 2647 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x06000A58 RID: 2648 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x06000A59 RID: 2649 RVA: 0x000A8278 File Offset: 0x000A6478
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
					MyBase.Tables.Add(New DataSetPOSPrint.DataTable1DataTable(dataSet.Tables("DataTable1")))
				End If
				Dim flag3 As Boolean = dataSet.Tables("DataPurchaseReturn") IsNot Nothing
				If flag3 Then
					MyBase.Tables.Add(New DataSetPOSPrint.DataPurchaseReturnDataTable(dataSet.Tables("DataPurchaseReturn")))
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

		' Token: 0x06000A5A RID: 2650 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x06000A5B RID: 2651 RVA: 0x0000B6E7 File Offset: 0x000098E7
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x06000A5C RID: 2652 RVA: 0x000A8394 File Offset: 0x000A6594
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), DataSetPOSPrint.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
			Me.tableDataPurchaseReturn = CType(MyBase.Tables("DataPurchaseReturn"), DataSetPOSPrint.DataPurchaseReturnDataTable)
			If initTable Then
				Dim flag2 As Boolean = Me.tableDataPurchaseReturn IsNot Nothing
				If flag2 Then
					Me.tableDataPurchaseReturn.InitVars()
				End If
			End If
		End Sub

		' Token: 0x06000A5D RID: 2653 RVA: 0x000A841C File Offset: 0x000A661C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSetPOSPrint"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSetPOSPrint.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New DataSetPOSPrint.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
			Me.tableDataPurchaseReturn = New DataSetPOSPrint.DataPurchaseReturnDataTable()
			MyBase.Tables.Add(Me.tableDataPurchaseReturn)
		End Sub

		' Token: 0x06000A5E RID: 2654 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x06000A5F RID: 2655 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataPurchaseReturn() As Boolean
			Return False
		End Function

		' Token: 0x06000A60 RID: 2656 RVA: 0x000A8498 File Offset: 0x000A6698
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x06000A61 RID: 2657 RVA: 0x000A84BC File Offset: 0x000A66BC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSetPOSPrint As DataSetPOSPrint = New DataSetPOSPrint()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSetPOSPrint.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSetPOSPrint.GetSchemaSerializable()
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

		' Token: 0x04000361 RID: 865
		Private tableDataTable1 As DataSetPOSPrint.DataTable1DataTable

		' Token: 0x04000362 RID: 866
		Private tableDataPurchaseReturn As DataSetPOSPrint.DataPurchaseReturnDataTable

		' Token: 0x04000363 RID: 867
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x0200003B RID: 59
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of DataSetPOSPrint.DataTable1Row)

			' Token: 0x06000A62 RID: 2658 RVA: 0x00009E98 File Offset: 0x00008098
			Private Sub DataTable1DataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs)
			End Sub

			' Token: 0x06000A63 RID: 2659 RVA: 0x0000B6F2 File Offset: 0x000098F2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				AddHandler MyBase.ColumnChanging, AddressOf Me.DataTable1DataTable_ColumnChanging
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x06000A64 RID: 2660 RVA: 0x000A8650 File Offset: 0x000A6850
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(table As DataTable)
				AddHandler MyBase.ColumnChanging, AddressOf Me.DataTable1DataTable_ColumnChanging
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

			' Token: 0x06000A65 RID: 2661 RVA: 0x0000B730 File Offset: 0x00009930
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				AddHandler MyBase.ColumnChanging, AddressOf Me.DataTable1DataTable_ColumnChanging
				Me.InitVars()
			End Sub

			' Token: 0x17000486 RID: 1158
			' (get) Token: 0x06000A66 RID: 2662 RVA: 0x000A872C File Offset: 0x000A692C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PIDColumn As DataColumn
				Get
					Return Me.columnPID
				End Get
			End Property

			' Token: 0x17000487 RID: 1159
			' (get) Token: 0x06000A67 RID: 2663 RVA: 0x000A8744 File Offset: 0x000A6944
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductNameColumn As DataColumn
				Get
					Return Me.columnProductName
				End Get
			End Property

			' Token: 0x17000488 RID: 1160
			' (get) Token: 0x06000A68 RID: 2664 RVA: 0x000A875C File Offset: 0x000A695C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCColumn As DataColumn
				Get
					Return Me.columnHSNC
				End Get
			End Property

			' Token: 0x17000489 RID: 1161
			' (get) Token: 0x06000A69 RID: 2665 RVA: 0x000A8774 File Offset: 0x000A6974
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MainQtyColumn As DataColumn
				Get
					Return Me.columnMainQty
				End Get
			End Property

			' Token: 0x1700048A RID: 1162
			' (get) Token: 0x06000A6A RID: 2666 RVA: 0x000A878C File Offset: 0x000A698C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AltQtyColumn As DataColumn
				Get
					Return Me.columnAltQty
				End Get
			End Property

			' Token: 0x1700048B RID: 1163
			' (get) Token: 0x06000A6B RID: 2667 RVA: 0x000A87A4 File Offset: 0x000A69A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MRPColumn As DataColumn
				Get
					Return Me.columnMRP
				End Get
			End Property

			' Token: 0x1700048C RID: 1164
			' (get) Token: 0x06000A6C RID: 2668 RVA: 0x000A87BC File Offset: 0x000A69BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RateColumn As DataColumn
				Get
					Return Me.columnRate
				End Get
			End Property

			' Token: 0x1700048D RID: 1165
			' (get) Token: 0x06000A6D RID: 2669 RVA: 0x000A87D4 File Offset: 0x000A69D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TotalColumn As DataColumn
				Get
					Return Me.columnTotal
				End Get
			End Property

			' Token: 0x1700048E RID: 1166
			' (get) Token: 0x06000A6E RID: 2670 RVA: 0x000A87EC File Offset: 0x000A69EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscPerColumn As DataColumn
				Get
					Return Me.columnDiscPer
				End Get
			End Property

			' Token: 0x1700048F RID: 1167
			' (get) Token: 0x06000A6F RID: 2671 RVA: 0x000A8804 File Offset: 0x000A6A04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscColumn As DataColumn
				Get
					Return Me.columnDisc
				End Get
			End Property

			' Token: 0x17000490 RID: 1168
			' (get) Token: 0x06000A70 RID: 2672 RVA: 0x000A881C File Offset: 0x000A6A1C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TaxableAmtColumn As DataColumn
				Get
					Return Me.columnTaxableAmt
				End Get
			End Property

			' Token: 0x17000491 RID: 1169
			' (get) Token: 0x06000A71 RID: 2673 RVA: 0x000A8834 File Offset: 0x000A6A34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTPerColumn As DataColumn
				Get
					Return Me.columnCGSTPer
				End Get
			End Property

			' Token: 0x17000492 RID: 1170
			' (get) Token: 0x06000A72 RID: 2674 RVA: 0x000A884C File Offset: 0x000A6A4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTColumn As DataColumn
				Get
					Return Me.columnCGST
				End Get
			End Property

			' Token: 0x17000493 RID: 1171
			' (get) Token: 0x06000A73 RID: 2675 RVA: 0x000A8864 File Offset: 0x000A6A64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTPerColumn As DataColumn
				Get
					Return Me.columnSGSTPer
				End Get
			End Property

			' Token: 0x17000494 RID: 1172
			' (get) Token: 0x06000A74 RID: 2676 RVA: 0x000A887C File Offset: 0x000A6A7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTColumn As DataColumn
				Get
					Return Me.columnSGST
				End Get
			End Property

			' Token: 0x17000495 RID: 1173
			' (get) Token: 0x06000A75 RID: 2677 RVA: 0x000A8894 File Offset: 0x000A6A94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTPerColumn As DataColumn
				Get
					Return Me.columnIGSTPer
				End Get
			End Property

			' Token: 0x17000496 RID: 1174
			' (get) Token: 0x06000A76 RID: 2678 RVA: 0x000A88AC File Offset: 0x000A6AAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTColumn As DataColumn
				Get
					Return Me.columnIGST
				End Get
			End Property

			' Token: 0x17000497 RID: 1175
			' (get) Token: 0x06000A77 RID: 2679 RVA: 0x000A88C4 File Offset: 0x000A6AC4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSPerColumn As DataColumn
				Get
					Return Me.columnCESSPer
				End Get
			End Property

			' Token: 0x17000498 RID: 1176
			' (get) Token: 0x06000A78 RID: 2680 RVA: 0x000A88DC File Offset: 0x000A6ADC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSColumn As DataColumn
				Get
					Return Me.columnCESS
				End Get
			End Property

			' Token: 0x17000499 RID: 1177
			' (get) Token: 0x06000A79 RID: 2681 RVA: 0x000A88F4 File Offset: 0x000A6AF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AmountColumn As DataColumn
				Get
					Return Me.columnAmount
				End Get
			End Property

			' Token: 0x1700049A RID: 1178
			' (get) Token: 0x06000A7A RID: 2682 RVA: 0x000A890C File Offset: 0x000A6B0C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x1700049B RID: 1179
			' (get) Token: 0x06000A7B RID: 2683 RVA: 0x000A8924 File Offset: 0x000A6B24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PurchaseRateColumn As DataColumn
				Get
					Return Me.columnPurchaseRate
				End Get
			End Property

			' Token: 0x1700049C RID: 1180
			' (get) Token: 0x06000A7C RID: 2684 RVA: 0x000A893C File Offset: 0x000A6B3C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MarginColumn As DataColumn
				Get
					Return Me.columnMargin
				End Get
			End Property

			' Token: 0x1700049D RID: 1181
			' (get) Token: 0x06000A7D RID: 2685 RVA: 0x000A8954 File Offset: 0x000A6B54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DescriptionColumn As DataColumn
				Get
					Return Me.columnDescription
				End Get
			End Property

			' Token: 0x1700049E RID: 1182
			' (get) Token: 0x06000A7E RID: 2686 RVA: 0x000A896C File Offset: 0x000A6B6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IM1Column As DataColumn
				Get
					Return Me.columnIM1
				End Get
			End Property

			' Token: 0x1700049F RID: 1183
			' (get) Token: 0x06000A7F RID: 2687 RVA: 0x000A8984 File Offset: 0x000A6B84
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IM2Column As DataColumn
				Get
					Return Me.columnIM2
				End Get
			End Property

			' Token: 0x170004A0 RID: 1184
			' (get) Token: 0x06000A80 RID: 2688 RVA: 0x000A899C File Offset: 0x000A6B9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AltUnitColumn As DataColumn
				Get
					Return Me.columnAltUnit
				End Get
			End Property

			' Token: 0x170004A1 RID: 1185
			' (get) Token: 0x06000A81 RID: 2689 RVA: 0x000A89B4 File Offset: 0x000A6BB4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MainUnitColumn As DataColumn
				Get
					Return Me.columnMainUnit
				End Get
			End Property

			' Token: 0x170004A2 RID: 1186
			' (get) Token: 0x06000A82 RID: 2690 RVA: 0x000A89CC File Offset: 0x000A6BCC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property FreeQtyColumn As DataColumn
				Get
					Return Me.columnFreeQty
				End Get
			End Property

			' Token: 0x170004A3 RID: 1187
			' (get) Token: 0x06000A83 RID: 2691 RVA: 0x000A89E4 File Offset: 0x000A6BE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SizeColumn As DataColumn
				Get
					Return Me.columnSize
				End Get
			End Property

			' Token: 0x170004A4 RID: 1188
			' (get) Token: 0x06000A84 RID: 2692 RVA: 0x000A89FC File Offset: 0x000A6BFC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ColourColumn As DataColumn
				Get
					Return Me.columnColour
				End Get
			End Property

			' Token: 0x170004A5 RID: 1189
			' (get) Token: 0x06000A85 RID: 2693 RVA: 0x000A8A14 File Offset: 0x000A6C14
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BatchColumn As DataColumn
				Get
					Return Me.columnBatch
				End Get
			End Property

			' Token: 0x170004A6 RID: 1190
			' (get) Token: 0x06000A86 RID: 2694 RVA: 0x000A8A2C File Offset: 0x000A6C2C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MfgColumn As DataColumn
				Get
					Return Me.columnMfg
				End Get
			End Property

			' Token: 0x170004A7 RID: 1191
			' (get) Token: 0x06000A87 RID: 2695 RVA: 0x000A8A44 File Offset: 0x000A6C44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ExpColumn As DataColumn
				Get
					Return Me.columnExp
				End Get
			End Property

			' Token: 0x170004A8 RID: 1192
			' (get) Token: 0x06000A88 RID: 2696 RVA: 0x000A8A5C File Offset: 0x000A6C5C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property InfoColumn As DataColumn
				Get
					Return Me.columnInfo
				End Get
			End Property

			' Token: 0x170004A9 RID: 1193
			' (get) Token: 0x06000A89 RID: 2697 RVA: 0x000A8A74 File Offset: 0x000A6C74
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Info1Column As DataColumn
				Get
					Return Me.columnInfo1
				End Get
			End Property

			' Token: 0x170004AA RID: 1194
			' (get) Token: 0x06000A8A RID: 2698 RVA: 0x000A8A8C File Offset: 0x000A6C8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property XColumn As DataColumn
				Get
					Return Me.columnX
				End Get
			End Property

			' Token: 0x170004AB RID: 1195
			' (get) Token: 0x06000A8B RID: 2699 RVA: 0x000A8AA4 File Offset: 0x000A6CA4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property YColumn As DataColumn
				Get
					Return Me.columnY
				End Get
			End Property

			' Token: 0x170004AC RID: 1196
			' (get) Token: 0x06000A8C RID: 2700 RVA: 0x000A8ABC File Offset: 0x000A6CBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ZColumn As DataColumn
				Get
					Return Me.columnZ
				End Get
			End Property

			' Token: 0x170004AD RID: 1197
			' (get) Token: 0x06000A8D RID: 2701 RVA: 0x000A8AD4 File Offset: 0x000A6CD4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property picColumn As DataColumn
				Get
					Return Me.columnpic
				End Get
			End Property

			' Token: 0x170004AE RID: 1198
			' (get) Token: 0x06000A8E RID: 2702 RVA: 0x000A8AEC File Offset: 0x000A6CEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TotalLoyalityPointsColumn As DataColumn
				Get
					Return Me.columnTotalLoyalityPoints
				End Get
			End Property

			' Token: 0x170004AF RID: 1199
			' (get) Token: 0x06000A8F RID: 2703 RVA: 0x000A8B04 File Offset: 0x000A6D04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property LoyalityReedemPointsColumn As DataColumn
				Get
					Return Me.columnLoyalityReedemPoints
				End Get
			End Property

			' Token: 0x170004B0 RID: 1200
			' (get) Token: 0x06000A90 RID: 2704 RVA: 0x000A8B1C File Offset: 0x000A6D1C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property LoyalityReedemAmtColumn As DataColumn
				Get
					Return Me.columnLoyalityReedemAmt
				End Get
			End Property

			' Token: 0x170004B1 RID: 1201
			' (get) Token: 0x06000A91 RID: 2705 RVA: 0x000A8B34 File Offset: 0x000A6D34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property LoyalityBalanceColumn As DataColumn
				Get
					Return Me.columnLoyalityBalance
				End Get
			End Property

			' Token: 0x170004B2 RID: 1202
			' (get) Token: 0x06000A92 RID: 2706 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x170004B3 RID: 1203
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetPOSPrint.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), DataSetPOSPrint.DataTable1Row)
				End Get
			End Property

			' Token: 0x14000019 RID: 25
			' (add) Token: 0x06000A94 RID: 2708 RVA: 0x000A8B70 File Offset: 0x000A6D70
			' (remove) Token: 0x06000A95 RID: 2709 RVA: 0x000A8BA8 File Offset: 0x000A6DA8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As DataSetPOSPrint.DataTable1RowChangeEventHandler

			' Token: 0x1400001A RID: 26
			' (add) Token: 0x06000A96 RID: 2710 RVA: 0x000A8BE0 File Offset: 0x000A6DE0
			' (remove) Token: 0x06000A97 RID: 2711 RVA: 0x000A8C18 File Offset: 0x000A6E18
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As DataSetPOSPrint.DataTable1RowChangeEventHandler

			' Token: 0x1400001B RID: 27
			' (add) Token: 0x06000A98 RID: 2712 RVA: 0x000A8C50 File Offset: 0x000A6E50
			' (remove) Token: 0x06000A99 RID: 2713 RVA: 0x000A8C88 File Offset: 0x000A6E88
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As DataSetPOSPrint.DataTable1RowChangeEventHandler

			' Token: 0x1400001C RID: 28
			' (add) Token: 0x06000A9A RID: 2714 RVA: 0x000A8CC0 File Offset: 0x000A6EC0
			' (remove) Token: 0x06000A9B RID: 2715 RVA: 0x000A8CF8 File Offset: 0x000A6EF8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As DataSetPOSPrint.DataTable1RowChangeEventHandler

			' Token: 0x06000A9C RID: 2716 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As DataSetPOSPrint.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x06000A9D RID: 2717 RVA: 0x000A8D30 File Offset: 0x000A6F30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(PID As String, ProductName As String, HSNC As String, MainQty As String, AltQty As String, MRP As String, Rate As String, Total As String, DiscPer As String, Disc As String, TaxableAmt As String, CGSTPer As String, CGST As String, SGSTPer As String, SGST As String, IGSTPer As String, IGST As String, CESSPer As String, CESS As String, Amount As String, Barcode As String, PurchaseRate As String, Margin As String, Description As String, IM1 As String, IM2 As String, AltUnit As String, MainUnit As String, FreeQty As String, Size As String, Colour As String, Batch As String, Mfg As String, Exp As String, Info As String, Info1 As String, X As String, Y As String, Z As String, pic As Byte(), TotalLoyalityPoints As Decimal, LoyalityReedemPoints As Decimal, LoyalityReedemAmt As Decimal, LoyalityBalance As Decimal) As DataSetPOSPrint.DataTable1Row
				Dim dataTable1Row As DataSetPOSPrint.DataTable1Row = CType(MyBase.NewRow(), DataSetPOSPrint.DataTable1Row)
				Dim array As Object() = New Object() { PID, ProductName, HSNC, MainQty, AltQty, MRP, Rate, Total, DiscPer, Disc, TaxableAmt, CGSTPer, CGST, SGSTPer, SGST, IGSTPer, IGST, CESSPer, CESS, Amount, Barcode, PurchaseRate, Margin, Description, IM1, IM2, AltUnit, MainUnit, FreeQty, Size, Colour, Batch, Mfg, Exp, Info, Info1, X, Y, Z, pic, TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, LoyalityBalance }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x06000A9E RID: 2718 RVA: 0x000A8E7C File Offset: 0x000A707C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As DataSetPOSPrint.DataTable1DataTable = CType(MyBase.Clone(), DataSetPOSPrint.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x06000A9F RID: 2719 RVA: 0x000A8EA4 File Offset: 0x000A70A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetPOSPrint.DataTable1DataTable()
			End Function

			' Token: 0x06000AA0 RID: 2720 RVA: 0x000A8EBC File Offset: 0x000A70BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnPID = MyBase.Columns("PID")
				Me.columnProductName = MyBase.Columns("ProductName")
				Me.columnHSNC = MyBase.Columns("HSNC")
				Me.columnMainQty = MyBase.Columns("MainQty")
				Me.columnAltQty = MyBase.Columns("AltQty")
				Me.columnMRP = MyBase.Columns("MRP")
				Me.columnRate = MyBase.Columns("Rate")
				Me.columnTotal = MyBase.Columns("Total")
				Me.columnDiscPer = MyBase.Columns("DiscPer")
				Me.columnDisc = MyBase.Columns("Disc")
				Me.columnTaxableAmt = MyBase.Columns("TaxableAmt")
				Me.columnCGSTPer = MyBase.Columns("CGSTPer")
				Me.columnCGST = MyBase.Columns("CGST")
				Me.columnSGSTPer = MyBase.Columns("SGSTPer")
				Me.columnSGST = MyBase.Columns("SGST")
				Me.columnIGSTPer = MyBase.Columns("IGSTPer")
				Me.columnIGST = MyBase.Columns("IGST")
				Me.columnCESSPer = MyBase.Columns("CESSPer")
				Me.columnCESS = MyBase.Columns("CESS")
				Me.columnAmount = MyBase.Columns("Amount")
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnPurchaseRate = MyBase.Columns("PurchaseRate")
				Me.columnMargin = MyBase.Columns("Margin")
				Me.columnDescription = MyBase.Columns("Description")
				Me.columnIM1 = MyBase.Columns("IM1")
				Me.columnIM2 = MyBase.Columns("IM2")
				Me.columnAltUnit = MyBase.Columns("AltUnit")
				Me.columnMainUnit = MyBase.Columns("MainUnit")
				Me.columnFreeQty = MyBase.Columns("FreeQty")
				Me.columnSize = MyBase.Columns("Size")
				Me.columnColour = MyBase.Columns("Colour")
				Me.columnBatch = MyBase.Columns("Batch")
				Me.columnMfg = MyBase.Columns("Mfg")
				Me.columnExp = MyBase.Columns("Exp")
				Me.columnInfo = MyBase.Columns("Info")
				Me.columnInfo1 = MyBase.Columns("Info1")
				Me.columnX = MyBase.Columns("X")
				Me.columnY = MyBase.Columns("Y")
				Me.columnZ = MyBase.Columns("Z")
				Me.columnpic = MyBase.Columns("Pic")
				Me.columnTotalLoyalityPoints = MyBase.Columns("TotalLoyalityPoints")
				Me.columnLoyalityReedemPoints = MyBase.Columns("LoyalityReedemPoints")
				Me.columnLoyalityReedemAmt = MyBase.Columns("LoyalityReedemAmt")
				Me.columnLoyalityBalance = MyBase.Columns("LoyalityBalance")
			End Sub

			' Token: 0x06000AA1 RID: 2721 RVA: 0x000A9294 File Offset: 0x000A7494
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnPID = New DataColumn("PID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPID)
				Me.columnProductName = New DataColumn("ProductName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductName)
				Me.columnHSNC = New DataColumn("HSNC", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnHSNC)
				Me.columnMainQty = New DataColumn("MainQty", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMainQty)
				Me.columnAltQty = New DataColumn("AltQty", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAltQty)
				Me.columnMRP = New DataColumn("MRP", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMRP)
				Me.columnRate = New DataColumn("Rate", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRate)
				Me.columnTotal = New DataColumn("Total", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTotal)
				Me.columnDiscPer = New DataColumn("DiscPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscPer)
				Me.columnDisc = New DataColumn("Disc", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDisc)
				Me.columnTaxableAmt = New DataColumn("TaxableAmt", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTaxableAmt)
				Me.columnCGSTPer = New DataColumn("CGSTPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGSTPer)
				Me.columnCGST = New DataColumn("CGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGST)
				Me.columnSGSTPer = New DataColumn("SGSTPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGSTPer)
				Me.columnSGST = New DataColumn("SGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGST)
				Me.columnIGSTPer = New DataColumn("IGSTPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGSTPer)
				Me.columnIGST = New DataColumn("IGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGST)
				Me.columnCESSPer = New DataColumn("CESSPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESSPer)
				Me.columnCESS = New DataColumn("CESS", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESS)
				Me.columnAmount = New DataColumn("Amount", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAmount)
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnPurchaseRate = New DataColumn("PurchaseRate", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPurchaseRate)
				Me.columnMargin = New DataColumn("Margin", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMargin)
				Me.columnDescription = New DataColumn("Description", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDescription)
				Me.columnIM1 = New DataColumn("IM1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIM1)
				Me.columnIM2 = New DataColumn("IM2", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIM2)
				Me.columnAltUnit = New DataColumn("AltUnit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAltUnit)
				Me.columnMainUnit = New DataColumn("MainUnit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMainUnit)
				Me.columnFreeQty = New DataColumn("FreeQty", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnFreeQty)
				Me.columnSize = New DataColumn("Size", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSize)
				Me.columnColour = New DataColumn("Colour", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnColour)
				Me.columnBatch = New DataColumn("Batch", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBatch)
				Me.columnMfg = New DataColumn("Mfg", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMfg)
				Me.columnExp = New DataColumn("Exp", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnExp)
				Me.columnInfo = New DataColumn("Info", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnInfo)
				Me.columnInfo1 = New DataColumn("Info1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnInfo1)
				Me.columnX = New DataColumn("X", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnX)
				Me.columnY = New DataColumn("Y", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnY)
				Me.columnZ = New DataColumn("Z", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnZ)
				Me.columnpic = New DataColumn("Pic", GetType(Byte()), Nothing, MappingType.Element)
				Me.columnpic.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "pic")
				Me.columnpic.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "picColumn")
				Me.columnpic.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnpic")
				Me.columnpic.ExtendedProperties.Add("Generator_UserColumnName", "Pic")
				MyBase.Columns.Add(Me.columnpic)
				Me.columnTotalLoyalityPoints = New DataColumn("TotalLoyalityPoints", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTotalLoyalityPoints)
				Me.columnLoyalityReedemPoints = New DataColumn("LoyalityReedemPoints", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnLoyalityReedemPoints)
				Me.columnLoyalityReedemAmt = New DataColumn("LoyalityReedemAmt", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnLoyalityReedemAmt)
				Me.columnLoyalityBalance = New DataColumn("LoyalityBalance", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnLoyalityBalance)
			End Sub

			' Token: 0x06000AA2 RID: 2722 RVA: 0x000A9AF8 File Offset: 0x000A7CF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As DataSetPOSPrint.DataTable1Row
				Return CType(MyBase.NewRow(), DataSetPOSPrint.DataTable1Row)
			End Function

			' Token: 0x06000AA3 RID: 2723 RVA: 0x000A9B18 File Offset: 0x000A7D18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetPOSPrint.DataTable1Row(builder)
			End Function

			' Token: 0x06000AA4 RID: 2724 RVA: 0x000A9B30 File Offset: 0x000A7D30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetPOSPrint.DataTable1Row)
			End Function

			' Token: 0x06000AA5 RID: 2725 RVA: 0x000A9B4C File Offset: 0x000A7D4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As DataSetPOSPrint.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New DataSetPOSPrint.DataTable1RowChangeEvent(CType(e.Row, DataSetPOSPrint.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000AA6 RID: 2726 RVA: 0x000A9B9C File Offset: 0x000A7D9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As DataSetPOSPrint.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New DataSetPOSPrint.DataTable1RowChangeEvent(CType(e.Row, DataSetPOSPrint.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000AA7 RID: 2727 RVA: 0x000A9BEC File Offset: 0x000A7DEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As DataSetPOSPrint.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New DataSetPOSPrint.DataTable1RowChangeEvent(CType(e.Row, DataSetPOSPrint.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000AA8 RID: 2728 RVA: 0x000A9C3C File Offset: 0x000A7E3C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As DataSetPOSPrint.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New DataSetPOSPrint.DataTable1RowChangeEvent(CType(e.Row, DataSetPOSPrint.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000AA9 RID: 2729 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As DataSetPOSPrint.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x06000AAA RID: 2730 RVA: 0x000A9C8C File Offset: 0x000A7E8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetPOSPrint As DataSetPOSPrint = New DataSetPOSPrint()
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
				xmlSchemaAttribute.FixedValue = dataSetPOSPrint.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetPOSPrint.GetSchemaSerializable()
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

			' Token: 0x04000364 RID: 868
			Private columnPID As DataColumn

			' Token: 0x04000365 RID: 869
			Private columnProductName As DataColumn

			' Token: 0x04000366 RID: 870
			Private columnHSNC As DataColumn

			' Token: 0x04000367 RID: 871
			Private columnMainQty As DataColumn

			' Token: 0x04000368 RID: 872
			Private columnAltQty As DataColumn

			' Token: 0x04000369 RID: 873
			Private columnMRP As DataColumn

			' Token: 0x0400036A RID: 874
			Private columnRate As DataColumn

			' Token: 0x0400036B RID: 875
			Private columnTotal As DataColumn

			' Token: 0x0400036C RID: 876
			Private columnDiscPer As DataColumn

			' Token: 0x0400036D RID: 877
			Private columnDisc As DataColumn

			' Token: 0x0400036E RID: 878
			Private columnTaxableAmt As DataColumn

			' Token: 0x0400036F RID: 879
			Private columnCGSTPer As DataColumn

			' Token: 0x04000370 RID: 880
			Private columnCGST As DataColumn

			' Token: 0x04000371 RID: 881
			Private columnSGSTPer As DataColumn

			' Token: 0x04000372 RID: 882
			Private columnSGST As DataColumn

			' Token: 0x04000373 RID: 883
			Private columnIGSTPer As DataColumn

			' Token: 0x04000374 RID: 884
			Private columnIGST As DataColumn

			' Token: 0x04000375 RID: 885
			Private columnCESSPer As DataColumn

			' Token: 0x04000376 RID: 886
			Private columnCESS As DataColumn

			' Token: 0x04000377 RID: 887
			Private columnAmount As DataColumn

			' Token: 0x04000378 RID: 888
			Private columnBarcode As DataColumn

			' Token: 0x04000379 RID: 889
			Private columnPurchaseRate As DataColumn

			' Token: 0x0400037A RID: 890
			Private columnMargin As DataColumn

			' Token: 0x0400037B RID: 891
			Private columnDescription As DataColumn

			' Token: 0x0400037C RID: 892
			Private columnIM1 As DataColumn

			' Token: 0x0400037D RID: 893
			Private columnIM2 As DataColumn

			' Token: 0x0400037E RID: 894
			Private columnAltUnit As DataColumn

			' Token: 0x0400037F RID: 895
			Private columnMainUnit As DataColumn

			' Token: 0x04000380 RID: 896
			Private columnFreeQty As DataColumn

			' Token: 0x04000381 RID: 897
			Private columnSize As DataColumn

			' Token: 0x04000382 RID: 898
			Private columnColour As DataColumn

			' Token: 0x04000383 RID: 899
			Private columnBatch As DataColumn

			' Token: 0x04000384 RID: 900
			Private columnMfg As DataColumn

			' Token: 0x04000385 RID: 901
			Private columnExp As DataColumn

			' Token: 0x04000386 RID: 902
			Private columnInfo As DataColumn

			' Token: 0x04000387 RID: 903
			Private columnInfo1 As DataColumn

			' Token: 0x04000388 RID: 904
			Private columnX As DataColumn

			' Token: 0x04000389 RID: 905
			Private columnY As DataColumn

			' Token: 0x0400038A RID: 906
			Private columnZ As DataColumn

			' Token: 0x0400038B RID: 907
			Private columnpic As DataColumn

			' Token: 0x0400038C RID: 908
			Private columnTotalLoyalityPoints As DataColumn

			' Token: 0x0400038D RID: 909
			Private columnLoyalityReedemPoints As DataColumn

			' Token: 0x0400038E RID: 910
			Private columnLoyalityReedemAmt As DataColumn

			' Token: 0x0400038F RID: 911
			Private columnLoyalityBalance As DataColumn
		End Class

		' Token: 0x0200003C RID: 60
		' (Invoke) Token: 0x06000AAE RID: 2734
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As DataSetPOSPrint.DataTable1RowChangeEvent)

		' Token: 0x0200003D RID: 61
		' (Invoke) Token: 0x06000AB2 RID: 2738
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataPurchaseReturnRowChangeEventHandler(sender As Object, e As DataSetPOSPrint.DataPurchaseReturnRowChangeEvent)

		' Token: 0x0200003E RID: 62
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataPurchaseReturnDataTable
			Inherits TypedTableBase(Of DataSetPOSPrint.DataPurchaseReturnRow)

			' Token: 0x06000AB3 RID: 2739 RVA: 0x0000B756 File Offset: 0x00009956
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataPurchaseReturn"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x06000AB4 RID: 2740 RVA: 0x000A9EE0 File Offset: 0x000A80E0
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

			' Token: 0x06000AB5 RID: 2741 RVA: 0x0000B781 File Offset: 0x00009981
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x170004B4 RID: 1204
			' (get) Token: 0x06000AB6 RID: 2742 RVA: 0x000A9FAC File Offset: 0x000A81AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PIDColumn As DataColumn
				Get
					Return Me.columnPID
				End Get
			End Property

			' Token: 0x170004B5 RID: 1205
			' (get) Token: 0x06000AB7 RID: 2743 RVA: 0x000A9FC4 File Offset: 0x000A81C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductNameColumn As DataColumn
				Get
					Return Me.columnProductName
				End Get
			End Property

			' Token: 0x170004B6 RID: 1206
			' (get) Token: 0x06000AB8 RID: 2744 RVA: 0x000A9FDC File Offset: 0x000A81DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCColumn As DataColumn
				Get
					Return Me.columnHSNC
				End Get
			End Property

			' Token: 0x170004B7 RID: 1207
			' (get) Token: 0x06000AB9 RID: 2745 RVA: 0x000A9FF4 File Offset: 0x000A81F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QtyColumn As DataColumn
				Get
					Return Me.columnQty
				End Get
			End Property

			' Token: 0x170004B8 RID: 1208
			' (get) Token: 0x06000ABA RID: 2746 RVA: 0x000AA00C File Offset: 0x000A820C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MRPColumn As DataColumn
				Get
					Return Me.columnMRP
				End Get
			End Property

			' Token: 0x170004B9 RID: 1209
			' (get) Token: 0x06000ABB RID: 2747 RVA: 0x000AA024 File Offset: 0x000A8224
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RateColumn As DataColumn
				Get
					Return Me.columnRate
				End Get
			End Property

			' Token: 0x170004BA RID: 1210
			' (get) Token: 0x06000ABC RID: 2748 RVA: 0x000AA03C File Offset: 0x000A823C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscPerColumn As DataColumn
				Get
					Return Me.columnDiscPer
				End Get
			End Property

			' Token: 0x170004BB RID: 1211
			' (get) Token: 0x06000ABD RID: 2749 RVA: 0x000AA054 File Offset: 0x000A8254
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscColumn As DataColumn
				Get
					Return Me.columnDisc
				End Get
			End Property

			' Token: 0x170004BC RID: 1212
			' (get) Token: 0x06000ABE RID: 2750 RVA: 0x000AA06C File Offset: 0x000A826C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TaxableAmtColumn As DataColumn
				Get
					Return Me.columnTaxableAmt
				End Get
			End Property

			' Token: 0x170004BD RID: 1213
			' (get) Token: 0x06000ABF RID: 2751 RVA: 0x000AA084 File Offset: 0x000A8284
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTPerColumn As DataColumn
				Get
					Return Me.columnCGSTPer
				End Get
			End Property

			' Token: 0x170004BE RID: 1214
			' (get) Token: 0x06000AC0 RID: 2752 RVA: 0x000AA09C File Offset: 0x000A829C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTColumn As DataColumn
				Get
					Return Me.columnCGST
				End Get
			End Property

			' Token: 0x170004BF RID: 1215
			' (get) Token: 0x06000AC1 RID: 2753 RVA: 0x000AA0B4 File Offset: 0x000A82B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTPerColumn As DataColumn
				Get
					Return Me.columnSGSTPer
				End Get
			End Property

			' Token: 0x170004C0 RID: 1216
			' (get) Token: 0x06000AC2 RID: 2754 RVA: 0x000AA0CC File Offset: 0x000A82CC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTColumn As DataColumn
				Get
					Return Me.columnSGST
				End Get
			End Property

			' Token: 0x170004C1 RID: 1217
			' (get) Token: 0x06000AC3 RID: 2755 RVA: 0x000AA0E4 File Offset: 0x000A82E4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTPerColumn As DataColumn
				Get
					Return Me.columnIGSTPer
				End Get
			End Property

			' Token: 0x170004C2 RID: 1218
			' (get) Token: 0x06000AC4 RID: 2756 RVA: 0x000AA0FC File Offset: 0x000A82FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTColumn As DataColumn
				Get
					Return Me.columnIGST
				End Get
			End Property

			' Token: 0x170004C3 RID: 1219
			' (get) Token: 0x06000AC5 RID: 2757 RVA: 0x000AA114 File Offset: 0x000A8314
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSPerColumn As DataColumn
				Get
					Return Me.columnCESSPer
				End Get
			End Property

			' Token: 0x170004C4 RID: 1220
			' (get) Token: 0x06000AC6 RID: 2758 RVA: 0x000AA12C File Offset: 0x000A832C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSColumn As DataColumn
				Get
					Return Me.columnCESS
				End Get
			End Property

			' Token: 0x170004C5 RID: 1221
			' (get) Token: 0x06000AC7 RID: 2759 RVA: 0x000AA144 File Offset: 0x000A8344
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AmountColumn As DataColumn
				Get
					Return Me.columnAmount
				End Get
			End Property

			' Token: 0x170004C6 RID: 1222
			' (get) Token: 0x06000AC8 RID: 2760 RVA: 0x000AA15C File Offset: 0x000A835C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x170004C7 RID: 1223
			' (get) Token: 0x06000AC9 RID: 2761 RVA: 0x000AA174 File Offset: 0x000A8374
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ReturnQtyColumn As DataColumn
				Get
					Return Me.columnReturnQty
				End Get
			End Property

			' Token: 0x170004C8 RID: 1224
			' (get) Token: 0x06000ACA RID: 2762 RVA: 0x000AA18C File Offset: 0x000A838C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PurchaseTaxTypeColumn As DataColumn
				Get
					Return Me.columnPurchaseTaxType
				End Get
			End Property

			' Token: 0x170004C9 RID: 1225
			' (get) Token: 0x06000ACB RID: 2763 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x170004CA RID: 1226
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetPOSPrint.DataPurchaseReturnRow
				Get
					Return CType(MyBase.Rows(index), DataSetPOSPrint.DataPurchaseReturnRow)
				End Get
			End Property

			' Token: 0x1400001D RID: 29
			' (add) Token: 0x06000ACD RID: 2765 RVA: 0x000AA1C8 File Offset: 0x000A83C8
			' (remove) Token: 0x06000ACE RID: 2766 RVA: 0x000AA200 File Offset: 0x000A8400
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataPurchaseReturnRowChanging As DataSetPOSPrint.DataPurchaseReturnRowChangeEventHandler

			' Token: 0x1400001E RID: 30
			' (add) Token: 0x06000ACF RID: 2767 RVA: 0x000AA238 File Offset: 0x000A8438
			' (remove) Token: 0x06000AD0 RID: 2768 RVA: 0x000AA270 File Offset: 0x000A8470
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataPurchaseReturnRowChanged As DataSetPOSPrint.DataPurchaseReturnRowChangeEventHandler

			' Token: 0x1400001F RID: 31
			' (add) Token: 0x06000AD1 RID: 2769 RVA: 0x000AA2A8 File Offset: 0x000A84A8
			' (remove) Token: 0x06000AD2 RID: 2770 RVA: 0x000AA2E0 File Offset: 0x000A84E0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataPurchaseReturnRowDeleting As DataSetPOSPrint.DataPurchaseReturnRowChangeEventHandler

			' Token: 0x14000020 RID: 32
			' (add) Token: 0x06000AD3 RID: 2771 RVA: 0x000AA318 File Offset: 0x000A8518
			' (remove) Token: 0x06000AD4 RID: 2772 RVA: 0x000AA350 File Offset: 0x000A8550
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataPurchaseReturnRowDeleted As DataSetPOSPrint.DataPurchaseReturnRowChangeEventHandler

			' Token: 0x06000AD5 RID: 2773 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataPurchaseReturnRow(row As DataSetPOSPrint.DataPurchaseReturnRow)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x06000AD6 RID: 2774 RVA: 0x000AA388 File Offset: 0x000A8588
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataPurchaseReturnRow(PID As String, ProductName As String, HSNC As String, Qty As Decimal, MRP As String, Rate As String, DiscPer As String, Disc As String, TaxableAmt As String, CGSTPer As String, CGST As String, SGSTPer As String, SGST As String, IGSTPer As String, IGST As String, CESSPer As String, CESS As String, Amount As String, Barcode As String, ReturnQty As String, PurchaseTaxType As String) As DataSetPOSPrint.DataPurchaseReturnRow
				Dim dataPurchaseReturnRow As DataSetPOSPrint.DataPurchaseReturnRow = CType(MyBase.NewRow(), DataSetPOSPrint.DataPurchaseReturnRow)
				Dim array As Object() = New Object() { PID, ProductName, HSNC, Qty, MRP, Rate, DiscPer, Disc, TaxableAmt, CGSTPer, CGST, SGSTPer, SGST, IGSTPer, IGST, CESSPer, CESS, Amount, Barcode, ReturnQty, PurchaseTaxType }
				dataPurchaseReturnRow.ItemArray = array
				MyBase.Rows.Add(dataPurchaseReturnRow)
				Return dataPurchaseReturnRow
			End Function

			' Token: 0x06000AD7 RID: 2775 RVA: 0x000AA43C File Offset: 0x000A863C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataPurchaseReturnDataTable As DataSetPOSPrint.DataPurchaseReturnDataTable = CType(MyBase.Clone(), DataSetPOSPrint.DataPurchaseReturnDataTable)
				dataPurchaseReturnDataTable.InitVars()
				Return dataPurchaseReturnDataTable
			End Function

			' Token: 0x06000AD8 RID: 2776 RVA: 0x000AA464 File Offset: 0x000A8664
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetPOSPrint.DataPurchaseReturnDataTable()
			End Function

			' Token: 0x06000AD9 RID: 2777 RVA: 0x000AA47C File Offset: 0x000A867C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnPID = MyBase.Columns("PID")
				Me.columnProductName = MyBase.Columns("ProductName")
				Me.columnHSNC = MyBase.Columns("HSNC")
				Me.columnQty = MyBase.Columns("Qty")
				Me.columnMRP = MyBase.Columns("MRP")
				Me.columnRate = MyBase.Columns("Rate")
				Me.columnDiscPer = MyBase.Columns("DiscPer")
				Me.columnDisc = MyBase.Columns("Disc")
				Me.columnTaxableAmt = MyBase.Columns("TaxableAmt")
				Me.columnCGSTPer = MyBase.Columns("CGSTPer")
				Me.columnCGST = MyBase.Columns("CGST")
				Me.columnSGSTPer = MyBase.Columns("SGSTPer")
				Me.columnSGST = MyBase.Columns("SGST")
				Me.columnIGSTPer = MyBase.Columns("IGSTPer")
				Me.columnIGST = MyBase.Columns("IGST")
				Me.columnCESSPer = MyBase.Columns("CESSPer")
				Me.columnCESS = MyBase.Columns("CESS")
				Me.columnAmount = MyBase.Columns("Amount")
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnReturnQty = MyBase.Columns("ReturnQty")
				Me.columnPurchaseTaxType = MyBase.Columns("PurchaseTaxType")
			End Sub

			' Token: 0x06000ADA RID: 2778 RVA: 0x000AA658 File Offset: 0x000A8858
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnPID = New DataColumn("PID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPID)
				Me.columnProductName = New DataColumn("ProductName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductName)
				Me.columnHSNC = New DataColumn("HSNC", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnHSNC)
				Me.columnQty = New DataColumn("Qty", GetType(Decimal), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQty)
				Me.columnMRP = New DataColumn("MRP", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMRP)
				Me.columnRate = New DataColumn("Rate", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRate)
				Me.columnDiscPer = New DataColumn("DiscPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscPer)
				Me.columnDisc = New DataColumn("Disc", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDisc)
				Me.columnTaxableAmt = New DataColumn("TaxableAmt", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTaxableAmt)
				Me.columnCGSTPer = New DataColumn("CGSTPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGSTPer)
				Me.columnCGST = New DataColumn("CGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGST)
				Me.columnSGSTPer = New DataColumn("SGSTPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGSTPer)
				Me.columnSGST = New DataColumn("SGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGST)
				Me.columnIGSTPer = New DataColumn("IGSTPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGSTPer)
				Me.columnIGST = New DataColumn("IGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGST)
				Me.columnCESSPer = New DataColumn("CESSPer", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESSPer)
				Me.columnCESS = New DataColumn("CESS", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESS)
				Me.columnAmount = New DataColumn("Amount", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAmount)
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnReturnQty = New DataColumn("ReturnQty", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnReturnQty)
				Me.columnPurchaseTaxType = New DataColumn("PurchaseTaxType", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPurchaseTaxType)
				Me.columnReturnQty.Caption = "PurchaseRate"
				Me.columnPurchaseTaxType.Caption = "Margin"
			End Sub

			' Token: 0x06000ADB RID: 2779 RVA: 0x000AAA50 File Offset: 0x000A8C50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataPurchaseReturnRow() As DataSetPOSPrint.DataPurchaseReturnRow
				Return CType(MyBase.NewRow(), DataSetPOSPrint.DataPurchaseReturnRow)
			End Function

			' Token: 0x06000ADC RID: 2780 RVA: 0x000AAA70 File Offset: 0x000A8C70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetPOSPrint.DataPurchaseReturnRow(builder)
			End Function

			' Token: 0x06000ADD RID: 2781 RVA: 0x000AAA88 File Offset: 0x000A8C88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetPOSPrint.DataPurchaseReturnRow)
			End Function

			' Token: 0x06000ADE RID: 2782 RVA: 0x000AAAA4 File Offset: 0x000A8CA4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataPurchaseReturnRowChangedEvent IsNot Nothing
				If flag Then
					Dim dataPurchaseReturnRowChangedEvent As DataSetPOSPrint.DataPurchaseReturnRowChangeEventHandler = Me.DataPurchaseReturnRowChangedEvent
					If dataPurchaseReturnRowChangedEvent IsNot Nothing Then
						dataPurchaseReturnRowChangedEvent(Me, New DataSetPOSPrint.DataPurchaseReturnRowChangeEvent(CType(e.Row, DataSetPOSPrint.DataPurchaseReturnRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000ADF RID: 2783 RVA: 0x000AAAF4 File Offset: 0x000A8CF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataPurchaseReturnRowChangingEvent IsNot Nothing
				If flag Then
					Dim dataPurchaseReturnRowChangingEvent As DataSetPOSPrint.DataPurchaseReturnRowChangeEventHandler = Me.DataPurchaseReturnRowChangingEvent
					If dataPurchaseReturnRowChangingEvent IsNot Nothing Then
						dataPurchaseReturnRowChangingEvent(Me, New DataSetPOSPrint.DataPurchaseReturnRowChangeEvent(CType(e.Row, DataSetPOSPrint.DataPurchaseReturnRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000AE0 RID: 2784 RVA: 0x000AAB44 File Offset: 0x000A8D44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataPurchaseReturnRowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataPurchaseReturnRowDeletedEvent As DataSetPOSPrint.DataPurchaseReturnRowChangeEventHandler = Me.DataPurchaseReturnRowDeletedEvent
					If dataPurchaseReturnRowDeletedEvent IsNot Nothing Then
						dataPurchaseReturnRowDeletedEvent(Me, New DataSetPOSPrint.DataPurchaseReturnRowChangeEvent(CType(e.Row, DataSetPOSPrint.DataPurchaseReturnRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000AE1 RID: 2785 RVA: 0x000AAB94 File Offset: 0x000A8D94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataPurchaseReturnRowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataPurchaseReturnRowDeletingEvent As DataSetPOSPrint.DataPurchaseReturnRowChangeEventHandler = Me.DataPurchaseReturnRowDeletingEvent
					If dataPurchaseReturnRowDeletingEvent IsNot Nothing Then
						dataPurchaseReturnRowDeletingEvent(Me, New DataSetPOSPrint.DataPurchaseReturnRowChangeEvent(CType(e.Row, DataSetPOSPrint.DataPurchaseReturnRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x06000AE2 RID: 2786 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataPurchaseReturnRow(row As DataSetPOSPrint.DataPurchaseReturnRow)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x06000AE3 RID: 2787 RVA: 0x000AABE4 File Offset: 0x000A8DE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetPOSPrint As DataSetPOSPrint = New DataSetPOSPrint()
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
				xmlSchemaAttribute.FixedValue = dataSetPOSPrint.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataPurchaseReturnDataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetPOSPrint.GetSchemaSerializable()
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

			' Token: 0x04000394 RID: 916
			Private columnPID As DataColumn

			' Token: 0x04000395 RID: 917
			Private columnProductName As DataColumn

			' Token: 0x04000396 RID: 918
			Private columnHSNC As DataColumn

			' Token: 0x04000397 RID: 919
			Private columnQty As DataColumn

			' Token: 0x04000398 RID: 920
			Private columnMRP As DataColumn

			' Token: 0x04000399 RID: 921
			Private columnRate As DataColumn

			' Token: 0x0400039A RID: 922
			Private columnDiscPer As DataColumn

			' Token: 0x0400039B RID: 923
			Private columnDisc As DataColumn

			' Token: 0x0400039C RID: 924
			Private columnTaxableAmt As DataColumn

			' Token: 0x0400039D RID: 925
			Private columnCGSTPer As DataColumn

			' Token: 0x0400039E RID: 926
			Private columnCGST As DataColumn

			' Token: 0x0400039F RID: 927
			Private columnSGSTPer As DataColumn

			' Token: 0x040003A0 RID: 928
			Private columnSGST As DataColumn

			' Token: 0x040003A1 RID: 929
			Private columnIGSTPer As DataColumn

			' Token: 0x040003A2 RID: 930
			Private columnIGST As DataColumn

			' Token: 0x040003A3 RID: 931
			Private columnCESSPer As DataColumn

			' Token: 0x040003A4 RID: 932
			Private columnCESS As DataColumn

			' Token: 0x040003A5 RID: 933
			Private columnAmount As DataColumn

			' Token: 0x040003A6 RID: 934
			Private columnBarcode As DataColumn

			' Token: 0x040003A7 RID: 935
			Private columnReturnQty As DataColumn

			' Token: 0x040003A8 RID: 936
			Private columnPurchaseTaxType As DataColumn
		End Class

		' Token: 0x0200003F RID: 63
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x06000AE4 RID: 2788 RVA: 0x0000B794 File Offset: 0x00009994
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, DataSetPOSPrint.DataTable1DataTable)
			End Sub

			' Token: 0x170004CB RID: 1227
			' (get) Token: 0x06000AE5 RID: 2789 RVA: 0x000AAE38 File Offset: 0x000A9038
			' (set) Token: 0x06000AE6 RID: 2790 RVA: 0x0000B7B0 File Offset: 0x000099B0
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

			' Token: 0x170004CC RID: 1228
			' (get) Token: 0x06000AE7 RID: 2791 RVA: 0x000AAE88 File Offset: 0x000A9088
			' (set) Token: 0x06000AE8 RID: 2792 RVA: 0x0000B7C6 File Offset: 0x000099C6
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

			' Token: 0x170004CD RID: 1229
			' (get) Token: 0x06000AE9 RID: 2793 RVA: 0x000AAED8 File Offset: 0x000A90D8
			' (set) Token: 0x06000AEA RID: 2794 RVA: 0x0000B7DC File Offset: 0x000099DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property HSNC As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.HSNCColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'HSNC' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.HSNCColumn) = value
				End Set
			End Property

			' Token: 0x170004CE RID: 1230
			' (get) Token: 0x06000AEB RID: 2795 RVA: 0x000AAF28 File Offset: 0x000A9128
			' (set) Token: 0x06000AEC RID: 2796 RVA: 0x0000B7F2 File Offset: 0x000099F2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MainQty As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.MainQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MainQty' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.MainQtyColumn) = value
				End Set
			End Property

			' Token: 0x170004CF RID: 1231
			' (get) Token: 0x06000AED RID: 2797 RVA: 0x000AAF78 File Offset: 0x000A9178
			' (set) Token: 0x06000AEE RID: 2798 RVA: 0x0000B808 File Offset: 0x00009A08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AltQty As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.AltQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AltQty' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.AltQtyColumn) = value
				End Set
			End Property

			' Token: 0x170004D0 RID: 1232
			' (get) Token: 0x06000AEF RID: 2799 RVA: 0x000AAFC8 File Offset: 0x000A91C8
			' (set) Token: 0x06000AF0 RID: 2800 RVA: 0x0000B81E File Offset: 0x00009A1E
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

			' Token: 0x170004D1 RID: 1233
			' (get) Token: 0x06000AF1 RID: 2801 RVA: 0x000AB018 File Offset: 0x000A9218
			' (set) Token: 0x06000AF2 RID: 2802 RVA: 0x0000B834 File Offset: 0x00009A34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Rate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.RateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Rate' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.RateColumn) = value
				End Set
			End Property

			' Token: 0x170004D2 RID: 1234
			' (get) Token: 0x06000AF3 RID: 2803 RVA: 0x000AB068 File Offset: 0x000A9268
			' (set) Token: 0x06000AF4 RID: 2804 RVA: 0x0000B84A File Offset: 0x00009A4A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Total As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.TotalColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Total' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.TotalColumn) = value
				End Set
			End Property

			' Token: 0x170004D3 RID: 1235
			' (get) Token: 0x06000AF5 RID: 2805 RVA: 0x000AB0B8 File Offset: 0x000A92B8
			' (set) Token: 0x06000AF6 RID: 2806 RVA: 0x0000B860 File Offset: 0x00009A60
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property DiscPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.DiscPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'DiscPer' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.DiscPerColumn) = value
				End Set
			End Property

			' Token: 0x170004D4 RID: 1236
			' (get) Token: 0x06000AF7 RID: 2807 RVA: 0x000AB108 File Offset: 0x000A9308
			' (set) Token: 0x06000AF8 RID: 2808 RVA: 0x0000B876 File Offset: 0x00009A76
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Disc As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.DiscColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Disc' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.DiscColumn) = value
				End Set
			End Property

			' Token: 0x170004D5 RID: 1237
			' (get) Token: 0x06000AF9 RID: 2809 RVA: 0x000AB158 File Offset: 0x000A9358
			' (set) Token: 0x06000AFA RID: 2810 RVA: 0x0000B88C File Offset: 0x00009A8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TaxableAmt As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.TaxableAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TaxableAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.TaxableAmtColumn) = value
				End Set
			End Property

			' Token: 0x170004D6 RID: 1238
			' (get) Token: 0x06000AFB RID: 2811 RVA: 0x000AB1A8 File Offset: 0x000A93A8
			' (set) Token: 0x06000AFC RID: 2812 RVA: 0x0000B8A2 File Offset: 0x00009AA2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGSTPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGSTPer' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x170004D7 RID: 1239
			' (get) Token: 0x06000AFD RID: 2813 RVA: 0x000AB1F8 File Offset: 0x000A93F8
			' (set) Token: 0x06000AFE RID: 2814 RVA: 0x0000B8B8 File Offset: 0x00009AB8
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

			' Token: 0x170004D8 RID: 1240
			' (get) Token: 0x06000AFF RID: 2815 RVA: 0x000AB248 File Offset: 0x000A9448
			' (set) Token: 0x06000B00 RID: 2816 RVA: 0x0000B8CE File Offset: 0x00009ACE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGSTPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.SGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGSTPer' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.SGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x170004D9 RID: 1241
			' (get) Token: 0x06000B01 RID: 2817 RVA: 0x000AB298 File Offset: 0x000A9498
			' (set) Token: 0x06000B02 RID: 2818 RVA: 0x0000B8E4 File Offset: 0x00009AE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.SGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGST' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.SGSTColumn) = value
				End Set
			End Property

			' Token: 0x170004DA RID: 1242
			' (get) Token: 0x06000B03 RID: 2819 RVA: 0x000AB2E8 File Offset: 0x000A94E8
			' (set) Token: 0x06000B04 RID: 2820 RVA: 0x0000B8FA File Offset: 0x00009AFA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGSTPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.IGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGSTPer' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.IGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x170004DB RID: 1243
			' (get) Token: 0x06000B05 RID: 2821 RVA: 0x000AB338 File Offset: 0x000A9538
			' (set) Token: 0x06000B06 RID: 2822 RVA: 0x0000B910 File Offset: 0x00009B10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.IGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGST' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.IGSTColumn) = value
				End Set
			End Property

			' Token: 0x170004DC RID: 1244
			' (get) Token: 0x06000B07 RID: 2823 RVA: 0x000AB388 File Offset: 0x000A9588
			' (set) Token: 0x06000B08 RID: 2824 RVA: 0x0000B926 File Offset: 0x00009B26
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESSPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CESSPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESSPer' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CESSPerColumn) = value
				End Set
			End Property

			' Token: 0x170004DD RID: 1245
			' (get) Token: 0x06000B09 RID: 2825 RVA: 0x000AB3D8 File Offset: 0x000A95D8
			' (set) Token: 0x06000B0A RID: 2826 RVA: 0x0000B93C File Offset: 0x00009B3C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESS As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CESSColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESS' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CESSColumn) = value
				End Set
			End Property

			' Token: 0x170004DE RID: 1246
			' (get) Token: 0x06000B0B RID: 2827 RVA: 0x000AB428 File Offset: 0x000A9628
			' (set) Token: 0x06000B0C RID: 2828 RVA: 0x0000B952 File Offset: 0x00009B52
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Amount As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.AmountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Amount' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.AmountColumn) = value
				End Set
			End Property

			' Token: 0x170004DF RID: 1247
			' (get) Token: 0x06000B0D RID: 2829 RVA: 0x000AB478 File Offset: 0x000A9678
			' (set) Token: 0x06000B0E RID: 2830 RVA: 0x0000B968 File Offset: 0x00009B68
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

			' Token: 0x170004E0 RID: 1248
			' (get) Token: 0x06000B0F RID: 2831 RVA: 0x000AB4C8 File Offset: 0x000A96C8
			' (set) Token: 0x06000B10 RID: 2832 RVA: 0x0000B97E File Offset: 0x00009B7E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PurchaseRate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.PurchaseRateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PurchaseRate' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.PurchaseRateColumn) = value
				End Set
			End Property

			' Token: 0x170004E1 RID: 1249
			' (get) Token: 0x06000B11 RID: 2833 RVA: 0x000AB518 File Offset: 0x000A9718
			' (set) Token: 0x06000B12 RID: 2834 RVA: 0x0000B994 File Offset: 0x00009B94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Margin As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.MarginColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Margin' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.MarginColumn) = value
				End Set
			End Property

			' Token: 0x170004E2 RID: 1250
			' (get) Token: 0x06000B13 RID: 2835 RVA: 0x000AB568 File Offset: 0x000A9768
			' (set) Token: 0x06000B14 RID: 2836 RVA: 0x0000B9AA File Offset: 0x00009BAA
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

			' Token: 0x170004E3 RID: 1251
			' (get) Token: 0x06000B15 RID: 2837 RVA: 0x000AB5B8 File Offset: 0x000A97B8
			' (set) Token: 0x06000B16 RID: 2838 RVA: 0x0000B9C0 File Offset: 0x00009BC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IM1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.IM1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IM1' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.IM1Column) = value
				End Set
			End Property

			' Token: 0x170004E4 RID: 1252
			' (get) Token: 0x06000B17 RID: 2839 RVA: 0x000AB608 File Offset: 0x000A9808
			' (set) Token: 0x06000B18 RID: 2840 RVA: 0x0000B9D6 File Offset: 0x00009BD6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IM2 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.IM2Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IM2' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.IM2Column) = value
				End Set
			End Property

			' Token: 0x170004E5 RID: 1253
			' (get) Token: 0x06000B19 RID: 2841 RVA: 0x000AB658 File Offset: 0x000A9858
			' (set) Token: 0x06000B1A RID: 2842 RVA: 0x0000B9EC File Offset: 0x00009BEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AltUnit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.AltUnitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AltUnit' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.AltUnitColumn) = value
				End Set
			End Property

			' Token: 0x170004E6 RID: 1254
			' (get) Token: 0x06000B1B RID: 2843 RVA: 0x000AB6A8 File Offset: 0x000A98A8
			' (set) Token: 0x06000B1C RID: 2844 RVA: 0x0000BA02 File Offset: 0x00009C02
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MainUnit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.MainUnitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MainUnit' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.MainUnitColumn) = value
				End Set
			End Property

			' Token: 0x170004E7 RID: 1255
			' (get) Token: 0x06000B1D RID: 2845 RVA: 0x000AB6F8 File Offset: 0x000A98F8
			' (set) Token: 0x06000B1E RID: 2846 RVA: 0x0000BA18 File Offset: 0x00009C18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property FreeQty As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.FreeQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'FreeQty' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.FreeQtyColumn) = value
				End Set
			End Property

			' Token: 0x170004E8 RID: 1256
			' (get) Token: 0x06000B1F RID: 2847 RVA: 0x000AB748 File Offset: 0x000A9948
			' (set) Token: 0x06000B20 RID: 2848 RVA: 0x0000BA2E File Offset: 0x00009C2E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Size As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.SizeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Size' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.SizeColumn) = value
				End Set
			End Property

			' Token: 0x170004E9 RID: 1257
			' (get) Token: 0x06000B21 RID: 2849 RVA: 0x000AB798 File Offset: 0x000A9998
			' (set) Token: 0x06000B22 RID: 2850 RVA: 0x0000BA44 File Offset: 0x00009C44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Colour As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.ColourColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Colour' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.ColourColumn) = value
				End Set
			End Property

			' Token: 0x170004EA RID: 1258
			' (get) Token: 0x06000B23 RID: 2851 RVA: 0x000AB7E8 File Offset: 0x000A99E8
			' (set) Token: 0x06000B24 RID: 2852 RVA: 0x0000BA5A File Offset: 0x00009C5A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Batch As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.BatchColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Batch' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.BatchColumn) = value
				End Set
			End Property

			' Token: 0x170004EB RID: 1259
			' (get) Token: 0x06000B25 RID: 2853 RVA: 0x000AB838 File Offset: 0x000A9A38
			' (set) Token: 0x06000B26 RID: 2854 RVA: 0x0000BA70 File Offset: 0x00009C70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Mfg As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.MfgColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Mfg' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.MfgColumn) = value
				End Set
			End Property

			' Token: 0x170004EC RID: 1260
			' (get) Token: 0x06000B27 RID: 2855 RVA: 0x000AB888 File Offset: 0x000A9A88
			' (set) Token: 0x06000B28 RID: 2856 RVA: 0x0000BA86 File Offset: 0x00009C86
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Exp As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.ExpColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Exp' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.ExpColumn) = value
				End Set
			End Property

			' Token: 0x170004ED RID: 1261
			' (get) Token: 0x06000B29 RID: 2857 RVA: 0x000AB8D8 File Offset: 0x000A9AD8
			' (set) Token: 0x06000B2A RID: 2858 RVA: 0x0000BA9C File Offset: 0x00009C9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Info As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.InfoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Info' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.InfoColumn) = value
				End Set
			End Property

			' Token: 0x170004EE RID: 1262
			' (get) Token: 0x06000B2B RID: 2859 RVA: 0x000AB928 File Offset: 0x000A9B28
			' (set) Token: 0x06000B2C RID: 2860 RVA: 0x0000BAB2 File Offset: 0x00009CB2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Info1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.Info1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Info1' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.Info1Column) = value
				End Set
			End Property

			' Token: 0x170004EF RID: 1263
			' (get) Token: 0x06000B2D RID: 2861 RVA: 0x000AB978 File Offset: 0x000A9B78
			' (set) Token: 0x06000B2E RID: 2862 RVA: 0x0000BAC8 File Offset: 0x00009CC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property X As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.XColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'X' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.XColumn) = value
				End Set
			End Property

			' Token: 0x170004F0 RID: 1264
			' (get) Token: 0x06000B2F RID: 2863 RVA: 0x000AB9C8 File Offset: 0x000A9BC8
			' (set) Token: 0x06000B30 RID: 2864 RVA: 0x0000BADE File Offset: 0x00009CDE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Y As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.YColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Y' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.YColumn) = value
				End Set
			End Property

			' Token: 0x170004F1 RID: 1265
			' (get) Token: 0x06000B31 RID: 2865 RVA: 0x000ABA18 File Offset: 0x000A9C18
			' (set) Token: 0x06000B32 RID: 2866 RVA: 0x0000BAF4 File Offset: 0x00009CF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Z As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.ZColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Z' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.ZColumn) = value
				End Set
			End Property

			' Token: 0x170004F2 RID: 1266
			' (get) Token: 0x06000B33 RID: 2867 RVA: 0x000ABA68 File Offset: 0x000A9C68
			' (set) Token: 0x06000B34 RID: 2868 RVA: 0x0000BB0A File Offset: 0x00009D0A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property pic As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable1.picColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Pic' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable1.picColumn) = value
				End Set
			End Property

			' Token: 0x170004F3 RID: 1267
			' (get) Token: 0x06000B35 RID: 2869 RVA: 0x000ABAB8 File Offset: 0x000A9CB8
			' (set) Token: 0x06000B36 RID: 2870 RVA: 0x0000BB20 File Offset: 0x00009D20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TotalLoyalityPoints As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableDataTable1.TotalLoyalityPointsColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TotalLoyalityPoints' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableDataTable1.TotalLoyalityPointsColumn) = value
				End Set
			End Property

			' Token: 0x170004F4 RID: 1268
			' (get) Token: 0x06000B37 RID: 2871 RVA: 0x000ABB08 File Offset: 0x000A9D08
			' (set) Token: 0x06000B38 RID: 2872 RVA: 0x0000BB3B File Offset: 0x00009D3B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property LoyalityReedemPoints As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableDataTable1.LoyalityReedemPointsColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'LoyalityReedemPoints' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableDataTable1.LoyalityReedemPointsColumn) = value
				End Set
			End Property

			' Token: 0x170004F5 RID: 1269
			' (get) Token: 0x06000B39 RID: 2873 RVA: 0x000ABB58 File Offset: 0x000A9D58
			' (set) Token: 0x06000B3A RID: 2874 RVA: 0x0000BB56 File Offset: 0x00009D56
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property LoyalityReedemAmt As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableDataTable1.LoyalityReedemAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'LoyalityReedemAmt' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableDataTable1.LoyalityReedemAmtColumn) = value
				End Set
			End Property

			' Token: 0x170004F6 RID: 1270
			' (get) Token: 0x06000B3B RID: 2875 RVA: 0x000ABBA8 File Offset: 0x000A9DA8
			' (set) Token: 0x06000B3C RID: 2876 RVA: 0x0000BB71 File Offset: 0x00009D71
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property LoyalityBalance As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableDataTable1.LoyalityBalanceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'LoyalityBalance' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableDataTable1.LoyalityBalanceColumn) = value
				End Set
			End Property

			' Token: 0x06000B3D RID: 2877 RVA: 0x000ABBF8 File Offset: 0x000A9DF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPIDNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PIDColumn)
			End Function

			' Token: 0x06000B3E RID: 2878 RVA: 0x0000BB8C File Offset: 0x00009D8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPIDNull()
				MyBase.Item(Me.tableDataTable1.PIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B3F RID: 2879 RVA: 0x000ABC1C File Offset: 0x000A9E1C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ProductNameColumn)
			End Function

			' Token: 0x06000B40 RID: 2880 RVA: 0x0000BBAB File Offset: 0x00009DAB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductNameNull()
				MyBase.Item(Me.tableDataTable1.ProductNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B41 RID: 2881 RVA: 0x000ABC40 File Offset: 0x000A9E40
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.HSNCColumn)
			End Function

			' Token: 0x06000B42 RID: 2882 RVA: 0x0000BBCA File Offset: 0x00009DCA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCNull()
				MyBase.Item(Me.tableDataTable1.HSNCColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B43 RID: 2883 RVA: 0x000ABC64 File Offset: 0x000A9E64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMainQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.MainQtyColumn)
			End Function

			' Token: 0x06000B44 RID: 2884 RVA: 0x0000BBE9 File Offset: 0x00009DE9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMainQtyNull()
				MyBase.Item(Me.tableDataTable1.MainQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B45 RID: 2885 RVA: 0x000ABC88 File Offset: 0x000A9E88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAltQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.AltQtyColumn)
			End Function

			' Token: 0x06000B46 RID: 2886 RVA: 0x0000BC08 File Offset: 0x00009E08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAltQtyNull()
				MyBase.Item(Me.tableDataTable1.AltQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B47 RID: 2887 RVA: 0x000ABCAC File Offset: 0x000A9EAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.MRPColumn)
			End Function

			' Token: 0x06000B48 RID: 2888 RVA: 0x0000BC27 File Offset: 0x00009E27
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMRPNull()
				MyBase.Item(Me.tableDataTable1.MRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B49 RID: 2889 RVA: 0x000ABCD0 File Offset: 0x000A9ED0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.RateColumn)
			End Function

			' Token: 0x06000B4A RID: 2890 RVA: 0x0000BC46 File Offset: 0x00009E46
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRateNull()
				MyBase.Item(Me.tableDataTable1.RateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B4B RID: 2891 RVA: 0x000ABCF4 File Offset: 0x000A9EF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTotalNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.TotalColumn)
			End Function

			' Token: 0x06000B4C RID: 2892 RVA: 0x0000BC65 File Offset: 0x00009E65
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTotalNull()
				MyBase.Item(Me.tableDataTable1.TotalColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B4D RID: 2893 RVA: 0x000ABD18 File Offset: 0x000A9F18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.DiscPerColumn)
			End Function

			' Token: 0x06000B4E RID: 2894 RVA: 0x0000BC84 File Offset: 0x00009E84
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscPerNull()
				MyBase.Item(Me.tableDataTable1.DiscPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B4F RID: 2895 RVA: 0x000ABD3C File Offset: 0x000A9F3C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.DiscColumn)
			End Function

			' Token: 0x06000B50 RID: 2896 RVA: 0x0000BCA3 File Offset: 0x00009EA3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscNull()
				MyBase.Item(Me.tableDataTable1.DiscColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B51 RID: 2897 RVA: 0x000ABD60 File Offset: 0x000A9F60
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTaxableAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.TaxableAmtColumn)
			End Function

			' Token: 0x06000B52 RID: 2898 RVA: 0x0000BCC2 File Offset: 0x00009EC2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTaxableAmtNull()
				MyBase.Item(Me.tableDataTable1.TaxableAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B53 RID: 2899 RVA: 0x000ABD84 File Offset: 0x000A9F84
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CGSTPerColumn)
			End Function

			' Token: 0x06000B54 RID: 2900 RVA: 0x0000BCE1 File Offset: 0x00009EE1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTPerNull()
				MyBase.Item(Me.tableDataTable1.CGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B55 RID: 2901 RVA: 0x000ABDA8 File Offset: 0x000A9FA8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CGSTColumn)
			End Function

			' Token: 0x06000B56 RID: 2902 RVA: 0x0000BD00 File Offset: 0x00009F00
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTNull()
				MyBase.Item(Me.tableDataTable1.CGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B57 RID: 2903 RVA: 0x000ABDCC File Offset: 0x000A9FCC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.SGSTPerColumn)
			End Function

			' Token: 0x06000B58 RID: 2904 RVA: 0x0000BD1F File Offset: 0x00009F1F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTPerNull()
				MyBase.Item(Me.tableDataTable1.SGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B59 RID: 2905 RVA: 0x000ABDF0 File Offset: 0x000A9FF0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.SGSTColumn)
			End Function

			' Token: 0x06000B5A RID: 2906 RVA: 0x0000BD3E File Offset: 0x00009F3E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTNull()
				MyBase.Item(Me.tableDataTable1.SGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B5B RID: 2907 RVA: 0x000ABE14 File Offset: 0x000AA014
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.IGSTPerColumn)
			End Function

			' Token: 0x06000B5C RID: 2908 RVA: 0x0000BD5D File Offset: 0x00009F5D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTPerNull()
				MyBase.Item(Me.tableDataTable1.IGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B5D RID: 2909 RVA: 0x000ABE38 File Offset: 0x000AA038
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.IGSTColumn)
			End Function

			' Token: 0x06000B5E RID: 2910 RVA: 0x0000BD7C File Offset: 0x00009F7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTNull()
				MyBase.Item(Me.tableDataTable1.IGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B5F RID: 2911 RVA: 0x000ABE5C File Offset: 0x000AA05C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CESSPerColumn)
			End Function

			' Token: 0x06000B60 RID: 2912 RVA: 0x0000BD9B File Offset: 0x00009F9B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSPerNull()
				MyBase.Item(Me.tableDataTable1.CESSPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B61 RID: 2913 RVA: 0x000ABE80 File Offset: 0x000AA080
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CESSColumn)
			End Function

			' Token: 0x06000B62 RID: 2914 RVA: 0x0000BDBA File Offset: 0x00009FBA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSNull()
				MyBase.Item(Me.tableDataTable1.CESSColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B63 RID: 2915 RVA: 0x000ABEA4 File Offset: 0x000AA0A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAmountNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.AmountColumn)
			End Function

			' Token: 0x06000B64 RID: 2916 RVA: 0x0000BDD9 File Offset: 0x00009FD9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAmountNull()
				MyBase.Item(Me.tableDataTable1.AmountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B65 RID: 2917 RVA: 0x000ABEC8 File Offset: 0x000AA0C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.BarcodeColumn)
			End Function

			' Token: 0x06000B66 RID: 2918 RVA: 0x0000BDF8 File Offset: 0x00009FF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableDataTable1.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B67 RID: 2919 RVA: 0x000ABEEC File Offset: 0x000AA0EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPurchaseRateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PurchaseRateColumn)
			End Function

			' Token: 0x06000B68 RID: 2920 RVA: 0x0000BE17 File Offset: 0x0000A017
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPurchaseRateNull()
				MyBase.Item(Me.tableDataTable1.PurchaseRateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B69 RID: 2921 RVA: 0x000ABF10 File Offset: 0x000AA110
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMarginNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.MarginColumn)
			End Function

			' Token: 0x06000B6A RID: 2922 RVA: 0x0000BE36 File Offset: 0x0000A036
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMarginNull()
				MyBase.Item(Me.tableDataTable1.MarginColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B6B RID: 2923 RVA: 0x000ABF34 File Offset: 0x000AA134
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDescriptionNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.DescriptionColumn)
			End Function

			' Token: 0x06000B6C RID: 2924 RVA: 0x0000BE55 File Offset: 0x0000A055
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDescriptionNull()
				MyBase.Item(Me.tableDataTable1.DescriptionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B6D RID: 2925 RVA: 0x000ABF58 File Offset: 0x000AA158
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIM1Null() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.IM1Column)
			End Function

			' Token: 0x06000B6E RID: 2926 RVA: 0x0000BE74 File Offset: 0x0000A074
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIM1Null()
				MyBase.Item(Me.tableDataTable1.IM1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B6F RID: 2927 RVA: 0x000ABF7C File Offset: 0x000AA17C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIM2Null() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.IM2Column)
			End Function

			' Token: 0x06000B70 RID: 2928 RVA: 0x0000BE93 File Offset: 0x0000A093
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIM2Null()
				MyBase.Item(Me.tableDataTable1.IM2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B71 RID: 2929 RVA: 0x000ABFA0 File Offset: 0x000AA1A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAltUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.AltUnitColumn)
			End Function

			' Token: 0x06000B72 RID: 2930 RVA: 0x0000BEB2 File Offset: 0x0000A0B2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAltUnitNull()
				MyBase.Item(Me.tableDataTable1.AltUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B73 RID: 2931 RVA: 0x000ABFC4 File Offset: 0x000AA1C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMainUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.MainUnitColumn)
			End Function

			' Token: 0x06000B74 RID: 2932 RVA: 0x0000BED1 File Offset: 0x0000A0D1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMainUnitNull()
				MyBase.Item(Me.tableDataTable1.MainUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B75 RID: 2933 RVA: 0x000ABFE8 File Offset: 0x000AA1E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsFreeQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.FreeQtyColumn)
			End Function

			' Token: 0x06000B76 RID: 2934 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetFreeQtyNull()
				MyBase.Item(Me.tableDataTable1.FreeQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B77 RID: 2935 RVA: 0x000AC00C File Offset: 0x000AA20C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSizeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.SizeColumn)
			End Function

			' Token: 0x06000B78 RID: 2936 RVA: 0x0000BF0F File Offset: 0x0000A10F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSizeNull()
				MyBase.Item(Me.tableDataTable1.SizeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B79 RID: 2937 RVA: 0x000AC030 File Offset: 0x000AA230
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsColourNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ColourColumn)
			End Function

			' Token: 0x06000B7A RID: 2938 RVA: 0x0000BF2E File Offset: 0x0000A12E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetColourNull()
				MyBase.Item(Me.tableDataTable1.ColourColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B7B RID: 2939 RVA: 0x000AC054 File Offset: 0x000AA254
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBatchNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.BatchColumn)
			End Function

			' Token: 0x06000B7C RID: 2940 RVA: 0x0000BF4D File Offset: 0x0000A14D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBatchNull()
				MyBase.Item(Me.tableDataTable1.BatchColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B7D RID: 2941 RVA: 0x000AC078 File Offset: 0x000AA278
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMfgNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.MfgColumn)
			End Function

			' Token: 0x06000B7E RID: 2942 RVA: 0x0000BF6C File Offset: 0x0000A16C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMfgNull()
				MyBase.Item(Me.tableDataTable1.MfgColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B7F RID: 2943 RVA: 0x000AC09C File Offset: 0x000AA29C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsExpNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ExpColumn)
			End Function

			' Token: 0x06000B80 RID: 2944 RVA: 0x0000BF8B File Offset: 0x0000A18B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetExpNull()
				MyBase.Item(Me.tableDataTable1.ExpColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B81 RID: 2945 RVA: 0x000AC0C0 File Offset: 0x000AA2C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsInfoNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.InfoColumn)
			End Function

			' Token: 0x06000B82 RID: 2946 RVA: 0x0000BFAA File Offset: 0x0000A1AA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetInfoNull()
				MyBase.Item(Me.tableDataTable1.InfoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B83 RID: 2947 RVA: 0x000AC0E4 File Offset: 0x000AA2E4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsInfo1Null() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.Info1Column)
			End Function

			' Token: 0x06000B84 RID: 2948 RVA: 0x0000BFC9 File Offset: 0x0000A1C9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetInfo1Null()
				MyBase.Item(Me.tableDataTable1.Info1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B85 RID: 2949 RVA: 0x000AC108 File Offset: 0x000AA308
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsXNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.XColumn)
			End Function

			' Token: 0x06000B86 RID: 2950 RVA: 0x0000BFE8 File Offset: 0x0000A1E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetXNull()
				MyBase.Item(Me.tableDataTable1.XColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B87 RID: 2951 RVA: 0x000AC12C File Offset: 0x000AA32C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsYNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.YColumn)
			End Function

			' Token: 0x06000B88 RID: 2952 RVA: 0x0000C007 File Offset: 0x0000A207
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetYNull()
				MyBase.Item(Me.tableDataTable1.YColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B89 RID: 2953 RVA: 0x000AC150 File Offset: 0x000AA350
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsZNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ZColumn)
			End Function

			' Token: 0x06000B8A RID: 2954 RVA: 0x0000C026 File Offset: 0x0000A226
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetZNull()
				MyBase.Item(Me.tableDataTable1.ZColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B8B RID: 2955 RVA: 0x000AC174 File Offset: 0x000AA374
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IspicNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.picColumn)
			End Function

			' Token: 0x06000B8C RID: 2956 RVA: 0x0000C045 File Offset: 0x0000A245
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetpicNull()
				MyBase.Item(Me.tableDataTable1.picColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B8D RID: 2957 RVA: 0x000AC198 File Offset: 0x000AA398
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTotalLoyalityPointsNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.TotalLoyalityPointsColumn)
			End Function

			' Token: 0x06000B8E RID: 2958 RVA: 0x0000C064 File Offset: 0x0000A264
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTotalLoyalityPointsNull()
				MyBase.Item(Me.tableDataTable1.TotalLoyalityPointsColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B8F RID: 2959 RVA: 0x000AC1BC File Offset: 0x000AA3BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsLoyalityReedemPointsNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.LoyalityReedemPointsColumn)
			End Function

			' Token: 0x06000B90 RID: 2960 RVA: 0x0000C083 File Offset: 0x0000A283
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetLoyalityReedemPointsNull()
				MyBase.Item(Me.tableDataTable1.LoyalityReedemPointsColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B91 RID: 2961 RVA: 0x000AC1E0 File Offset: 0x000AA3E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsLoyalityReedemAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.LoyalityReedemAmtColumn)
			End Function

			' Token: 0x06000B92 RID: 2962 RVA: 0x0000C0A2 File Offset: 0x0000A2A2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetLoyalityReedemAmtNull()
				MyBase.Item(Me.tableDataTable1.LoyalityReedemAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000B93 RID: 2963 RVA: 0x000AC204 File Offset: 0x000AA404
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsLoyalityBalanceNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.LoyalityBalanceColumn)
			End Function

			' Token: 0x06000B94 RID: 2964 RVA: 0x0000C0C1 File Offset: 0x0000A2C1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetLoyalityBalanceNull()
				MyBase.Item(Me.tableDataTable1.LoyalityBalanceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040003AD RID: 941
			Private tableDataTable1 As DataSetPOSPrint.DataTable1DataTable
		End Class

		' Token: 0x02000040 RID: 64
		Public Class DataPurchaseReturnRow
			Inherits DataRow

			' Token: 0x06000B95 RID: 2965 RVA: 0x0000C0E0 File Offset: 0x0000A2E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataPurchaseReturn = CType(MyBase.Table, DataSetPOSPrint.DataPurchaseReturnDataTable)
			End Sub

			' Token: 0x170004F7 RID: 1271
			' (get) Token: 0x06000B96 RID: 2966 RVA: 0x000AC228 File Offset: 0x000AA428
			' (set) Token: 0x06000B97 RID: 2967 RVA: 0x0000C0FC File Offset: 0x0000A2FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.PIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PID' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.PIDColumn) = value
				End Set
			End Property

			' Token: 0x170004F8 RID: 1272
			' (get) Token: 0x06000B98 RID: 2968 RVA: 0x000AC278 File Offset: 0x000AA478
			' (set) Token: 0x06000B99 RID: 2969 RVA: 0x0000C112 File Offset: 0x0000A312
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.ProductNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductName' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.ProductNameColumn) = value
				End Set
			End Property

			' Token: 0x170004F9 RID: 1273
			' (get) Token: 0x06000B9A RID: 2970 RVA: 0x000AC2C8 File Offset: 0x000AA4C8
			' (set) Token: 0x06000B9B RID: 2971 RVA: 0x0000C128 File Offset: 0x0000A328
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property HSNC As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.HSNCColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'HSNC' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.HSNCColumn) = value
				End Set
			End Property

			' Token: 0x170004FA RID: 1274
			' (get) Token: 0x06000B9C RID: 2972 RVA: 0x000AC318 File Offset: 0x000AA518
			' (set) Token: 0x06000B9D RID: 2973 RVA: 0x0000C13E File Offset: 0x0000A33E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Qty As Decimal
				Get
					Dim num As Decimal
					Try
						num = Conversions.ToDecimal(MyBase.Item(Me.tableDataPurchaseReturn.QtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Qty' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Decimal)
					MyBase.Item(Me.tableDataPurchaseReturn.QtyColumn) = value
				End Set
			End Property

			' Token: 0x170004FB RID: 1275
			' (get) Token: 0x06000B9E RID: 2974 RVA: 0x000AC368 File Offset: 0x000AA568
			' (set) Token: 0x06000B9F RID: 2975 RVA: 0x0000C159 File Offset: 0x0000A359
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MRP As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.MRPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MRP' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.MRPColumn) = value
				End Set
			End Property

			' Token: 0x170004FC RID: 1276
			' (get) Token: 0x06000BA0 RID: 2976 RVA: 0x000AC3B8 File Offset: 0x000AA5B8
			' (set) Token: 0x06000BA1 RID: 2977 RVA: 0x0000C16F File Offset: 0x0000A36F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Rate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.RateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Rate' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.RateColumn) = value
				End Set
			End Property

			' Token: 0x170004FD RID: 1277
			' (get) Token: 0x06000BA2 RID: 2978 RVA: 0x000AC408 File Offset: 0x000AA608
			' (set) Token: 0x06000BA3 RID: 2979 RVA: 0x0000C185 File Offset: 0x0000A385
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property DiscPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.DiscPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'DiscPer' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.DiscPerColumn) = value
				End Set
			End Property

			' Token: 0x170004FE RID: 1278
			' (get) Token: 0x06000BA4 RID: 2980 RVA: 0x000AC458 File Offset: 0x000AA658
			' (set) Token: 0x06000BA5 RID: 2981 RVA: 0x0000C19B File Offset: 0x0000A39B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Disc As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.DiscColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Disc' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.DiscColumn) = value
				End Set
			End Property

			' Token: 0x170004FF RID: 1279
			' (get) Token: 0x06000BA6 RID: 2982 RVA: 0x000AC4A8 File Offset: 0x000AA6A8
			' (set) Token: 0x06000BA7 RID: 2983 RVA: 0x0000C1B1 File Offset: 0x0000A3B1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TaxableAmt As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.TaxableAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TaxableAmt' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.TaxableAmtColumn) = value
				End Set
			End Property

			' Token: 0x17000500 RID: 1280
			' (get) Token: 0x06000BA8 RID: 2984 RVA: 0x000AC4F8 File Offset: 0x000AA6F8
			' (set) Token: 0x06000BA9 RID: 2985 RVA: 0x0000C1C7 File Offset: 0x0000A3C7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGSTPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.CGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGSTPer' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.CGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x17000501 RID: 1281
			' (get) Token: 0x06000BAA RID: 2986 RVA: 0x000AC548 File Offset: 0x000AA748
			' (set) Token: 0x06000BAB RID: 2987 RVA: 0x0000C1DD File Offset: 0x0000A3DD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.CGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGST' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.CGSTColumn) = value
				End Set
			End Property

			' Token: 0x17000502 RID: 1282
			' (get) Token: 0x06000BAC RID: 2988 RVA: 0x000AC598 File Offset: 0x000AA798
			' (set) Token: 0x06000BAD RID: 2989 RVA: 0x0000C1F3 File Offset: 0x0000A3F3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGSTPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.SGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGSTPer' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.SGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x17000503 RID: 1283
			' (get) Token: 0x06000BAE RID: 2990 RVA: 0x000AC5E8 File Offset: 0x000AA7E8
			' (set) Token: 0x06000BAF RID: 2991 RVA: 0x0000C209 File Offset: 0x0000A409
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.SGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGST' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.SGSTColumn) = value
				End Set
			End Property

			' Token: 0x17000504 RID: 1284
			' (get) Token: 0x06000BB0 RID: 2992 RVA: 0x000AC638 File Offset: 0x000AA838
			' (set) Token: 0x06000BB1 RID: 2993 RVA: 0x0000C21F File Offset: 0x0000A41F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGSTPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.IGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGSTPer' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.IGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x17000505 RID: 1285
			' (get) Token: 0x06000BB2 RID: 2994 RVA: 0x000AC688 File Offset: 0x000AA888
			' (set) Token: 0x06000BB3 RID: 2995 RVA: 0x0000C235 File Offset: 0x0000A435
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.IGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGST' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.IGSTColumn) = value
				End Set
			End Property

			' Token: 0x17000506 RID: 1286
			' (get) Token: 0x06000BB4 RID: 2996 RVA: 0x000AC6D8 File Offset: 0x000AA8D8
			' (set) Token: 0x06000BB5 RID: 2997 RVA: 0x0000C24B File Offset: 0x0000A44B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESSPer As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.CESSPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESSPer' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.CESSPerColumn) = value
				End Set
			End Property

			' Token: 0x17000507 RID: 1287
			' (get) Token: 0x06000BB6 RID: 2998 RVA: 0x000AC728 File Offset: 0x000AA928
			' (set) Token: 0x06000BB7 RID: 2999 RVA: 0x0000C261 File Offset: 0x0000A461
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESS As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.CESSColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESS' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.CESSColumn) = value
				End Set
			End Property

			' Token: 0x17000508 RID: 1288
			' (get) Token: 0x06000BB8 RID: 3000 RVA: 0x000AC778 File Offset: 0x000AA978
			' (set) Token: 0x06000BB9 RID: 3001 RVA: 0x0000C277 File Offset: 0x0000A477
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Amount As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.AmountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Amount' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.AmountColumn) = value
				End Set
			End Property

			' Token: 0x17000509 RID: 1289
			' (get) Token: 0x06000BBA RID: 3002 RVA: 0x000AC7C8 File Offset: 0x000AA9C8
			' (set) Token: 0x06000BBB RID: 3003 RVA: 0x0000C28D File Offset: 0x0000A48D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Barcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.BarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Barcode' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.BarcodeColumn) = value
				End Set
			End Property

			' Token: 0x1700050A RID: 1290
			' (get) Token: 0x06000BBC RID: 3004 RVA: 0x000AC818 File Offset: 0x000AAA18
			' (set) Token: 0x06000BBD RID: 3005 RVA: 0x0000C2A3 File Offset: 0x0000A4A3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ReturnQty As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.ReturnQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ReturnQty' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.ReturnQtyColumn) = value
				End Set
			End Property

			' Token: 0x1700050B RID: 1291
			' (get) Token: 0x06000BBE RID: 3006 RVA: 0x000AC868 File Offset: 0x000AAA68
			' (set) Token: 0x06000BBF RID: 3007 RVA: 0x0000C2B9 File Offset: 0x0000A4B9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PurchaseTaxType As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataPurchaseReturn.PurchaseTaxTypeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PurchaseTaxType' in table 'DataPurchaseReturn' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataPurchaseReturn.PurchaseTaxTypeColumn) = value
				End Set
			End Property

			' Token: 0x06000BC0 RID: 3008 RVA: 0x000AC8B8 File Offset: 0x000AAAB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPIDNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.PIDColumn)
			End Function

			' Token: 0x06000BC1 RID: 3009 RVA: 0x0000C2CF File Offset: 0x0000A4CF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPIDNull()
				MyBase.Item(Me.tableDataPurchaseReturn.PIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BC2 RID: 3010 RVA: 0x000AC8DC File Offset: 0x000AAADC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.ProductNameColumn)
			End Function

			' Token: 0x06000BC3 RID: 3011 RVA: 0x0000C2EE File Offset: 0x0000A4EE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductNameNull()
				MyBase.Item(Me.tableDataPurchaseReturn.ProductNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BC4 RID: 3012 RVA: 0x000AC900 File Offset: 0x000AAB00
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.HSNCColumn)
			End Function

			' Token: 0x06000BC5 RID: 3013 RVA: 0x0000C30D File Offset: 0x0000A50D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCNull()
				MyBase.Item(Me.tableDataPurchaseReturn.HSNCColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BC6 RID: 3014 RVA: 0x000AC924 File Offset: 0x000AAB24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.QtyColumn)
			End Function

			' Token: 0x06000BC7 RID: 3015 RVA: 0x0000C32C File Offset: 0x0000A52C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQtyNull()
				MyBase.Item(Me.tableDataPurchaseReturn.QtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BC8 RID: 3016 RVA: 0x000AC948 File Offset: 0x000AAB48
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.MRPColumn)
			End Function

			' Token: 0x06000BC9 RID: 3017 RVA: 0x0000C34B File Offset: 0x0000A54B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMRPNull()
				MyBase.Item(Me.tableDataPurchaseReturn.MRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BCA RID: 3018 RVA: 0x000AC96C File Offset: 0x000AAB6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.RateColumn)
			End Function

			' Token: 0x06000BCB RID: 3019 RVA: 0x0000C36A File Offset: 0x0000A56A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRateNull()
				MyBase.Item(Me.tableDataPurchaseReturn.RateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BCC RID: 3020 RVA: 0x000AC990 File Offset: 0x000AAB90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.DiscPerColumn)
			End Function

			' Token: 0x06000BCD RID: 3021 RVA: 0x0000C389 File Offset: 0x0000A589
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscPerNull()
				MyBase.Item(Me.tableDataPurchaseReturn.DiscPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BCE RID: 3022 RVA: 0x000AC9B4 File Offset: 0x000AABB4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.DiscColumn)
			End Function

			' Token: 0x06000BCF RID: 3023 RVA: 0x0000C3A8 File Offset: 0x0000A5A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscNull()
				MyBase.Item(Me.tableDataPurchaseReturn.DiscColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BD0 RID: 3024 RVA: 0x000AC9D8 File Offset: 0x000AABD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTaxableAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.TaxableAmtColumn)
			End Function

			' Token: 0x06000BD1 RID: 3025 RVA: 0x0000C3C7 File Offset: 0x0000A5C7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTaxableAmtNull()
				MyBase.Item(Me.tableDataPurchaseReturn.TaxableAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BD2 RID: 3026 RVA: 0x000AC9FC File Offset: 0x000AABFC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.CGSTPerColumn)
			End Function

			' Token: 0x06000BD3 RID: 3027 RVA: 0x0000C3E6 File Offset: 0x0000A5E6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTPerNull()
				MyBase.Item(Me.tableDataPurchaseReturn.CGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BD4 RID: 3028 RVA: 0x000ACA20 File Offset: 0x000AAC20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.CGSTColumn)
			End Function

			' Token: 0x06000BD5 RID: 3029 RVA: 0x0000C405 File Offset: 0x0000A605
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTNull()
				MyBase.Item(Me.tableDataPurchaseReturn.CGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BD6 RID: 3030 RVA: 0x000ACA44 File Offset: 0x000AAC44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.SGSTPerColumn)
			End Function

			' Token: 0x06000BD7 RID: 3031 RVA: 0x0000C424 File Offset: 0x0000A624
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTPerNull()
				MyBase.Item(Me.tableDataPurchaseReturn.SGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BD8 RID: 3032 RVA: 0x000ACA68 File Offset: 0x000AAC68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.SGSTColumn)
			End Function

			' Token: 0x06000BD9 RID: 3033 RVA: 0x0000C443 File Offset: 0x0000A643
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTNull()
				MyBase.Item(Me.tableDataPurchaseReturn.SGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BDA RID: 3034 RVA: 0x000ACA8C File Offset: 0x000AAC8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.IGSTPerColumn)
			End Function

			' Token: 0x06000BDB RID: 3035 RVA: 0x0000C462 File Offset: 0x0000A662
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTPerNull()
				MyBase.Item(Me.tableDataPurchaseReturn.IGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BDC RID: 3036 RVA: 0x000ACAB0 File Offset: 0x000AACB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.IGSTColumn)
			End Function

			' Token: 0x06000BDD RID: 3037 RVA: 0x0000C481 File Offset: 0x0000A681
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTNull()
				MyBase.Item(Me.tableDataPurchaseReturn.IGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BDE RID: 3038 RVA: 0x000ACAD4 File Offset: 0x000AACD4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.CESSPerColumn)
			End Function

			' Token: 0x06000BDF RID: 3039 RVA: 0x0000C4A0 File Offset: 0x0000A6A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSPerNull()
				MyBase.Item(Me.tableDataPurchaseReturn.CESSPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BE0 RID: 3040 RVA: 0x000ACAF8 File Offset: 0x000AACF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.CESSColumn)
			End Function

			' Token: 0x06000BE1 RID: 3041 RVA: 0x0000C4BF File Offset: 0x0000A6BF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSNull()
				MyBase.Item(Me.tableDataPurchaseReturn.CESSColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BE2 RID: 3042 RVA: 0x000ACB1C File Offset: 0x000AAD1C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAmountNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.AmountColumn)
			End Function

			' Token: 0x06000BE3 RID: 3043 RVA: 0x0000C4DE File Offset: 0x0000A6DE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAmountNull()
				MyBase.Item(Me.tableDataPurchaseReturn.AmountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BE4 RID: 3044 RVA: 0x000ACB40 File Offset: 0x000AAD40
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.BarcodeColumn)
			End Function

			' Token: 0x06000BE5 RID: 3045 RVA: 0x0000C4FD File Offset: 0x0000A6FD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableDataPurchaseReturn.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BE6 RID: 3046 RVA: 0x000ACB64 File Offset: 0x000AAD64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsReturnQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.ReturnQtyColumn)
			End Function

			' Token: 0x06000BE7 RID: 3047 RVA: 0x0000C51C File Offset: 0x0000A71C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetReturnQtyNull()
				MyBase.Item(Me.tableDataPurchaseReturn.ReturnQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x06000BE8 RID: 3048 RVA: 0x000ACB88 File Offset: 0x000AAD88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPurchaseTaxTypeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataPurchaseReturn.PurchaseTaxTypeColumn)
			End Function

			' Token: 0x06000BE9 RID: 3049 RVA: 0x0000C53B File Offset: 0x0000A73B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPurchaseTaxTypeNull()
				MyBase.Item(Me.tableDataPurchaseReturn.PurchaseTaxTypeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040003AE RID: 942
			Private tableDataPurchaseReturn As DataSetPOSPrint.DataPurchaseReturnDataTable
		End Class

		' Token: 0x02000041 RID: 65
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x06000BEA RID: 3050 RVA: 0x0000C55A File Offset: 0x0000A75A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetPOSPrint.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x1700050C RID: 1292
			' (get) Token: 0x06000BEB RID: 3051 RVA: 0x000ACBAC File Offset: 0x000AADAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetPOSPrint.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x1700050D RID: 1293
			' (get) Token: 0x06000BEC RID: 3052 RVA: 0x000ACBC4 File Offset: 0x000AADC4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040003AF RID: 943
			Private eventRow As DataSetPOSPrint.DataTable1Row

			' Token: 0x040003B0 RID: 944
			Private eventAction As DataRowAction
		End Class

		' Token: 0x02000042 RID: 66
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataPurchaseReturnRowChangeEvent
			Inherits EventArgs

			' Token: 0x06000BED RID: 3053 RVA: 0x0000C572 File Offset: 0x0000A772
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetPOSPrint.DataPurchaseReturnRow, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x1700050E RID: 1294
			' (get) Token: 0x06000BEE RID: 3054 RVA: 0x000ACBDC File Offset: 0x000AADDC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetPOSPrint.DataPurchaseReturnRow
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x1700050F RID: 1295
			' (get) Token: 0x06000BEF RID: 3055 RVA: 0x000ACBF4 File Offset: 0x000AADF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040003B1 RID: 945
			Private eventRow As DataSetPOSPrint.DataPurchaseReturnRow

			' Token: 0x040003B2 RID: 946
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
