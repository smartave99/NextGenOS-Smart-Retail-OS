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
	' Token: 0x0200049E RID: 1182
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("DataSetTurnAround")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class DataSetTurnAround
		Inherits DataSet

		' Token: 0x0600EB21 RID: 60193 RVA: 0x008DD020 File Offset: 0x008DB220
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

		' Token: 0x0600EB22 RID: 60194 RVA: 0x008DD078 File Offset: 0x008DB278
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
						MyBase.Tables.Add(New DataSetTurnAround.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x17005A46 RID: 23110
		' (get) Token: 0x0600EB23 RID: 60195 RVA: 0x008DD20C File Offset: 0x008DB40C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As DataSetTurnAround.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x17005A47 RID: 23111
		' (get) Token: 0x0600EB24 RID: 60196 RVA: 0x008DD224 File Offset: 0x008DB424
		' (set) Token: 0x0600EB25 RID: 60197 RVA: 0x0006701E File Offset: 0x0006521E
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

		' Token: 0x17005A48 RID: 23112
		' (get) Token: 0x0600EB26 RID: 60198 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x17005A49 RID: 23113
		' (get) Token: 0x0600EB27 RID: 60199 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x0600EB28 RID: 60200 RVA: 0x00067028 File Offset: 0x00065228
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x0600EB29 RID: 60201 RVA: 0x008DD23C File Offset: 0x008DB43C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim dataSetTurnAround As DataSetTurnAround = CType(MyBase.Clone(), DataSetTurnAround)
			dataSetTurnAround.InitVars()
			dataSetTurnAround.SchemaSerializationMode = Me.SchemaSerializationMode
			Return dataSetTurnAround
		End Function

		' Token: 0x0600EB2A RID: 60202 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x0600EB2B RID: 60203 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x0600EB2C RID: 60204 RVA: 0x008DD270 File Offset: 0x008DB470
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
					MyBase.Tables.Add(New DataSetTurnAround.DataTable1DataTable(dataSet.Tables("DataTable1")))
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

		' Token: 0x0600EB2D RID: 60205 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x0600EB2E RID: 60206 RVA: 0x00067040 File Offset: 0x00065240
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x0600EB2F RID: 60207 RVA: 0x008DD354 File Offset: 0x008DB554
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), DataSetTurnAround.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
		End Sub

		' Token: 0x0600EB30 RID: 60208 RVA: 0x008DD3A0 File Offset: 0x008DB5A0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "DataSetTurnAround"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/DataSetTurnAround.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New DataSetTurnAround.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
		End Sub

		' Token: 0x0600EB31 RID: 60209 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x0600EB32 RID: 60210 RVA: 0x008DD400 File Offset: 0x008DB600
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x0600EB33 RID: 60211 RVA: 0x008DD424 File Offset: 0x008DB624
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim dataSetTurnAround As DataSetTurnAround = New DataSetTurnAround()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = dataSetTurnAround.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = dataSetTurnAround.GetSchemaSerializable()
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

		' Token: 0x040059DD RID: 23005
		Private tableDataTable1 As DataSetTurnAround.DataTable1DataTable

		' Token: 0x040059DE RID: 23006
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x0200049F RID: 1183
		' (Invoke) Token: 0x0600EB37 RID: 60215
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As DataSetTurnAround.DataTable1RowChangeEvent)

		' Token: 0x020004A0 RID: 1184
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of DataSetTurnAround.DataTable1Row)

			' Token: 0x0600EB38 RID: 60216 RVA: 0x0006704B File Offset: 0x0006524B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600EB39 RID: 60217 RVA: 0x008DD5B8 File Offset: 0x008DB7B8
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

			' Token: 0x0600EB3A RID: 60218 RVA: 0x00067076 File Offset: 0x00065276
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17005A4A RID: 23114
			' (get) Token: 0x0600EB3B RID: 60219 RVA: 0x008DD684 File Offset: 0x008DB884
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property aColumn As DataColumn
				Get
					Return Me.columna
				End Get
			End Property

			' Token: 0x17005A4B RID: 23115
			' (get) Token: 0x0600EB3C RID: 60220 RVA: 0x008DD69C File Offset: 0x008DB89C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property bColumn As DataColumn
				Get
					Return Me.columnb
				End Get
			End Property

			' Token: 0x17005A4C RID: 23116
			' (get) Token: 0x0600EB3D RID: 60221 RVA: 0x008DD6B4 File Offset: 0x008DB8B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property cColumn As DataColumn
				Get
					Return Me.columnc
				End Get
			End Property

			' Token: 0x17005A4D RID: 23117
			' (get) Token: 0x0600EB3E RID: 60222 RVA: 0x008DD6CC File Offset: 0x008DB8CC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property dColumn As DataColumn
				Get
					Return Me.columnd
				End Get
			End Property

			' Token: 0x17005A4E RID: 23118
			' (get) Token: 0x0600EB3F RID: 60223 RVA: 0x008DD6E4 File Offset: 0x008DB8E4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property eColumn As DataColumn
				Get
					Return Me.columne
				End Get
			End Property

			' Token: 0x17005A4F RID: 23119
			' (get) Token: 0x0600EB40 RID: 60224 RVA: 0x008DD6FC File Offset: 0x008DB8FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property fColumn As DataColumn
				Get
					Return Me.columnf
				End Get
			End Property

			' Token: 0x17005A50 RID: 23120
			' (get) Token: 0x0600EB41 RID: 60225 RVA: 0x008DD714 File Offset: 0x008DB914
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property gColumn As DataColumn
				Get
					Return Me.columng
				End Get
			End Property

			' Token: 0x17005A51 RID: 23121
			' (get) Token: 0x0600EB42 RID: 60226 RVA: 0x008DD72C File Offset: 0x008DB92C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property hColumn As DataColumn
				Get
					Return Me.columnh
				End Get
			End Property

			' Token: 0x17005A52 RID: 23122
			' (get) Token: 0x0600EB43 RID: 60227 RVA: 0x008DD744 File Offset: 0x008DB944
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property iColumn As DataColumn
				Get
					Return Me.columni
				End Get
			End Property

			' Token: 0x17005A53 RID: 23123
			' (get) Token: 0x0600EB44 RID: 60228 RVA: 0x008DD75C File Offset: 0x008DB95C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property jColumn As DataColumn
				Get
					Return Me.columnj
				End Get
			End Property

			' Token: 0x17005A54 RID: 23124
			' (get) Token: 0x0600EB45 RID: 60229 RVA: 0x008DD774 File Offset: 0x008DB974
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property kColumn As DataColumn
				Get
					Return Me.columnk
				End Get
			End Property

			' Token: 0x17005A55 RID: 23125
			' (get) Token: 0x0600EB46 RID: 60230 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17005A56 RID: 23126
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As DataSetTurnAround.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), DataSetTurnAround.DataTable1Row)
				End Get
			End Property

			' Token: 0x14000124 RID: 292
			' (add) Token: 0x0600EB48 RID: 60232 RVA: 0x008DD7B0 File Offset: 0x008DB9B0
			' (remove) Token: 0x0600EB49 RID: 60233 RVA: 0x008DD7E8 File Offset: 0x008DB9E8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As DataSetTurnAround.DataTable1RowChangeEventHandler

			' Token: 0x14000125 RID: 293
			' (add) Token: 0x0600EB4A RID: 60234 RVA: 0x008DD820 File Offset: 0x008DBA20
			' (remove) Token: 0x0600EB4B RID: 60235 RVA: 0x008DD858 File Offset: 0x008DBA58
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As DataSetTurnAround.DataTable1RowChangeEventHandler

			' Token: 0x14000126 RID: 294
			' (add) Token: 0x0600EB4C RID: 60236 RVA: 0x008DD890 File Offset: 0x008DBA90
			' (remove) Token: 0x0600EB4D RID: 60237 RVA: 0x008DD8C8 File Offset: 0x008DBAC8
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As DataSetTurnAround.DataTable1RowChangeEventHandler

			' Token: 0x14000127 RID: 295
			' (add) Token: 0x0600EB4E RID: 60238 RVA: 0x008DD900 File Offset: 0x008DBB00
			' (remove) Token: 0x0600EB4F RID: 60239 RVA: 0x008DD938 File Offset: 0x008DBB38
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As DataSetTurnAround.DataTable1RowChangeEventHandler

			' Token: 0x0600EB50 RID: 60240 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As DataSetTurnAround.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600EB51 RID: 60241 RVA: 0x008DD970 File Offset: 0x008DBB70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(a As String, b As String, c As String, d As String, e As String, f As String, g As String, h As String, i As String, j As String, k As String) As DataSetTurnAround.DataTable1Row
				Dim dataTable1Row As DataSetTurnAround.DataTable1Row = CType(MyBase.NewRow(), DataSetTurnAround.DataTable1Row)
				Dim array As Object() = New Object() { a, b, c, d, e, f, g, h, i, j, k }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x0600EB52 RID: 60242 RVA: 0x008DD9E4 File Offset: 0x008DBBE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As DataSetTurnAround.DataTable1DataTable = CType(MyBase.Clone(), DataSetTurnAround.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x0600EB53 RID: 60243 RVA: 0x008DDA0C File Offset: 0x008DBC0C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New DataSetTurnAround.DataTable1DataTable()
			End Function

			' Token: 0x0600EB54 RID: 60244 RVA: 0x008DDA24 File Offset: 0x008DBC24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columna = MyBase.Columns("a")
				Me.columnb = MyBase.Columns("b")
				Me.columnc = MyBase.Columns("c")
				Me.columnd = MyBase.Columns("d")
				Me.columne = MyBase.Columns("e")
				Me.columnf = MyBase.Columns("f")
				Me.columng = MyBase.Columns("g")
				Me.columnh = MyBase.Columns("h")
				Me.columni = MyBase.Columns("i")
				Me.columnj = MyBase.Columns("j")
				Me.columnk = MyBase.Columns("k")
			End Sub

			' Token: 0x0600EB55 RID: 60245 RVA: 0x008DDB24 File Offset: 0x008DBD24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columna = New DataColumn("a", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columna)
				Me.columnb = New DataColumn("b", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnb)
				Me.columnc = New DataColumn("c", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnc)
				Me.columnd = New DataColumn("d", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnd)
				Me.columne = New DataColumn("e", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columne)
				Me.columnf = New DataColumn("f", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnf)
				Me.columng = New DataColumn("g", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columng)
				Me.columnh = New DataColumn("h", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnh)
				Me.columni = New DataColumn("i", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columni)
				Me.columnj = New DataColumn("j", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnj)
				Me.columnk = New DataColumn("k", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnk)
			End Sub

			' Token: 0x0600EB56 RID: 60246 RVA: 0x008DDD2C File Offset: 0x008DBF2C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As DataSetTurnAround.DataTable1Row
				Return CType(MyBase.NewRow(), DataSetTurnAround.DataTable1Row)
			End Function

			' Token: 0x0600EB57 RID: 60247 RVA: 0x008DDD4C File Offset: 0x008DBF4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New DataSetTurnAround.DataTable1Row(builder)
			End Function

			' Token: 0x0600EB58 RID: 60248 RVA: 0x008DDD64 File Offset: 0x008DBF64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(DataSetTurnAround.DataTable1Row)
			End Function

			' Token: 0x0600EB59 RID: 60249 RVA: 0x008DDD80 File Offset: 0x008DBF80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As DataSetTurnAround.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New DataSetTurnAround.DataTable1RowChangeEvent(CType(e.Row, DataSetTurnAround.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EB5A RID: 60250 RVA: 0x008DDDD0 File Offset: 0x008DBFD0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As DataSetTurnAround.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New DataSetTurnAround.DataTable1RowChangeEvent(CType(e.Row, DataSetTurnAround.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EB5B RID: 60251 RVA: 0x008DDE20 File Offset: 0x008DC020
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As DataSetTurnAround.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New DataSetTurnAround.DataTable1RowChangeEvent(CType(e.Row, DataSetTurnAround.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EB5C RID: 60252 RVA: 0x008DDE70 File Offset: 0x008DC070
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As DataSetTurnAround.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New DataSetTurnAround.DataTable1RowChangeEvent(CType(e.Row, DataSetTurnAround.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600EB5D RID: 60253 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As DataSetTurnAround.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600EB5E RID: 60254 RVA: 0x008DDEC0 File Offset: 0x008DC0C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim dataSetTurnAround As DataSetTurnAround = New DataSetTurnAround()
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
				xmlSchemaAttribute.FixedValue = dataSetTurnAround.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = dataSetTurnAround.GetSchemaSerializable()
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

			' Token: 0x040059DF RID: 23007
			Private columna As DataColumn

			' Token: 0x040059E0 RID: 23008
			Private columnb As DataColumn

			' Token: 0x040059E1 RID: 23009
			Private columnc As DataColumn

			' Token: 0x040059E2 RID: 23010
			Private columnd As DataColumn

			' Token: 0x040059E3 RID: 23011
			Private columne As DataColumn

			' Token: 0x040059E4 RID: 23012
			Private columnf As DataColumn

			' Token: 0x040059E5 RID: 23013
			Private columng As DataColumn

			' Token: 0x040059E6 RID: 23014
			Private columnh As DataColumn

			' Token: 0x040059E7 RID: 23015
			Private columni As DataColumn

			' Token: 0x040059E8 RID: 23016
			Private columnj As DataColumn

			' Token: 0x040059E9 RID: 23017
			Private columnk As DataColumn
		End Class

		' Token: 0x020004A1 RID: 1185
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x0600EB5F RID: 60255 RVA: 0x00067089 File Offset: 0x00065289
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, DataSetTurnAround.DataTable1DataTable)
			End Sub

			' Token: 0x17005A57 RID: 23127
			' (get) Token: 0x0600EB60 RID: 60256 RVA: 0x008DE114 File Offset: 0x008DC314
			' (set) Token: 0x0600EB61 RID: 60257 RVA: 0x000670A5 File Offset: 0x000652A5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property a As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.aColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'a' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.aColumn) = value
				End Set
			End Property

			' Token: 0x17005A58 RID: 23128
			' (get) Token: 0x0600EB62 RID: 60258 RVA: 0x008DE164 File Offset: 0x008DC364
			' (set) Token: 0x0600EB63 RID: 60259 RVA: 0x000670BB File Offset: 0x000652BB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property b As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.bColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'b' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.bColumn) = value
				End Set
			End Property

			' Token: 0x17005A59 RID: 23129
			' (get) Token: 0x0600EB64 RID: 60260 RVA: 0x008DE1B4 File Offset: 0x008DC3B4
			' (set) Token: 0x0600EB65 RID: 60261 RVA: 0x000670D1 File Offset: 0x000652D1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property c As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.cColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'c' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.cColumn) = value
				End Set
			End Property

			' Token: 0x17005A5A RID: 23130
			' (get) Token: 0x0600EB66 RID: 60262 RVA: 0x008DE204 File Offset: 0x008DC404
			' (set) Token: 0x0600EB67 RID: 60263 RVA: 0x000670E7 File Offset: 0x000652E7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property d As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.dColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'd' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.dColumn) = value
				End Set
			End Property

			' Token: 0x17005A5B RID: 23131
			' (get) Token: 0x0600EB68 RID: 60264 RVA: 0x008DE254 File Offset: 0x008DC454
			' (set) Token: 0x0600EB69 RID: 60265 RVA: 0x000670FD File Offset: 0x000652FD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property e As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.eColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'e' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.eColumn) = value
				End Set
			End Property

			' Token: 0x17005A5C RID: 23132
			' (get) Token: 0x0600EB6A RID: 60266 RVA: 0x008DE2A4 File Offset: 0x008DC4A4
			' (set) Token: 0x0600EB6B RID: 60267 RVA: 0x00067113 File Offset: 0x00065313
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property f As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.fColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'f' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.fColumn) = value
				End Set
			End Property

			' Token: 0x17005A5D RID: 23133
			' (get) Token: 0x0600EB6C RID: 60268 RVA: 0x008DE2F4 File Offset: 0x008DC4F4
			' (set) Token: 0x0600EB6D RID: 60269 RVA: 0x00067129 File Offset: 0x00065329
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property g As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.gColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'g' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.gColumn) = value
				End Set
			End Property

			' Token: 0x17005A5E RID: 23134
			' (get) Token: 0x0600EB6E RID: 60270 RVA: 0x008DE344 File Offset: 0x008DC544
			' (set) Token: 0x0600EB6F RID: 60271 RVA: 0x0006713F File Offset: 0x0006533F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property h As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.hColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'h' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.hColumn) = value
				End Set
			End Property

			' Token: 0x17005A5F RID: 23135
			' (get) Token: 0x0600EB70 RID: 60272 RVA: 0x008DE394 File Offset: 0x008DC594
			' (set) Token: 0x0600EB71 RID: 60273 RVA: 0x00067155 File Offset: 0x00065355
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property i As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.iColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'i' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.iColumn) = value
				End Set
			End Property

			' Token: 0x17005A60 RID: 23136
			' (get) Token: 0x0600EB72 RID: 60274 RVA: 0x008DE3E4 File Offset: 0x008DC5E4
			' (set) Token: 0x0600EB73 RID: 60275 RVA: 0x0006716B File Offset: 0x0006536B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property j As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.jColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'j' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.jColumn) = value
				End Set
			End Property

			' Token: 0x17005A61 RID: 23137
			' (get) Token: 0x0600EB74 RID: 60276 RVA: 0x008DE434 File Offset: 0x008DC634
			' (set) Token: 0x0600EB75 RID: 60277 RVA: 0x00067181 File Offset: 0x00065381
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property k As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.kColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'k' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.kColumn) = value
				End Set
			End Property

			' Token: 0x0600EB76 RID: 60278 RVA: 0x008DE484 File Offset: 0x008DC684
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsaNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.aColumn)
			End Function

			' Token: 0x0600EB77 RID: 60279 RVA: 0x00067197 File Offset: 0x00065397
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetaNull()
				MyBase.Item(Me.tableDataTable1.aColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB78 RID: 60280 RVA: 0x008DE4A8 File Offset: 0x008DC6A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsbNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.bColumn)
			End Function

			' Token: 0x0600EB79 RID: 60281 RVA: 0x000671B6 File Offset: 0x000653B6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetbNull()
				MyBase.Item(Me.tableDataTable1.bColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB7A RID: 60282 RVA: 0x008DE4CC File Offset: 0x008DC6CC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IscNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.cColumn)
			End Function

			' Token: 0x0600EB7B RID: 60283 RVA: 0x000671D5 File Offset: 0x000653D5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetcNull()
				MyBase.Item(Me.tableDataTable1.cColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB7C RID: 60284 RVA: 0x008DE4F0 File Offset: 0x008DC6F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsdNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.dColumn)
			End Function

			' Token: 0x0600EB7D RID: 60285 RVA: 0x000671F4 File Offset: 0x000653F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetdNull()
				MyBase.Item(Me.tableDataTable1.dColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB7E RID: 60286 RVA: 0x008DE514 File Offset: 0x008DC714
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IseNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.eColumn)
			End Function

			' Token: 0x0600EB7F RID: 60287 RVA: 0x00067213 File Offset: 0x00065413
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SeteNull()
				MyBase.Item(Me.tableDataTable1.eColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB80 RID: 60288 RVA: 0x008DE538 File Offset: 0x008DC738
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsfNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.fColumn)
			End Function

			' Token: 0x0600EB81 RID: 60289 RVA: 0x00067232 File Offset: 0x00065432
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetfNull()
				MyBase.Item(Me.tableDataTable1.fColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB82 RID: 60290 RVA: 0x008DE55C File Offset: 0x008DC75C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsgNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.gColumn)
			End Function

			' Token: 0x0600EB83 RID: 60291 RVA: 0x00067251 File Offset: 0x00065451
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetgNull()
				MyBase.Item(Me.tableDataTable1.gColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB84 RID: 60292 RVA: 0x008DE580 File Offset: 0x008DC780
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IshNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.hColumn)
			End Function

			' Token: 0x0600EB85 RID: 60293 RVA: 0x00067270 File Offset: 0x00065470
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SethNull()
				MyBase.Item(Me.tableDataTable1.hColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB86 RID: 60294 RVA: 0x008DE5A4 File Offset: 0x008DC7A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsiNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.iColumn)
			End Function

			' Token: 0x0600EB87 RID: 60295 RVA: 0x0006728F File Offset: 0x0006548F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetiNull()
				MyBase.Item(Me.tableDataTable1.iColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB88 RID: 60296 RVA: 0x008DE5C8 File Offset: 0x008DC7C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsjNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.jColumn)
			End Function

			' Token: 0x0600EB89 RID: 60297 RVA: 0x000672AE File Offset: 0x000654AE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetjNull()
				MyBase.Item(Me.tableDataTable1.jColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600EB8A RID: 60298 RVA: 0x008DE5EC File Offset: 0x008DC7EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IskNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.kColumn)
			End Function

			' Token: 0x0600EB8B RID: 60299 RVA: 0x000672CD File Offset: 0x000654CD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetkNull()
				MyBase.Item(Me.tableDataTable1.kColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040059EE RID: 23022
			Private tableDataTable1 As DataSetTurnAround.DataTable1DataTable
		End Class

		' Token: 0x020004A2 RID: 1186
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600EB8C RID: 60300 RVA: 0x000672EC File Offset: 0x000654EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As DataSetTurnAround.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17005A62 RID: 23138
			' (get) Token: 0x0600EB8D RID: 60301 RVA: 0x008DE610 File Offset: 0x008DC810
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As DataSetTurnAround.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17005A63 RID: 23139
			' (get) Token: 0x0600EB8E RID: 60302 RVA: 0x008DE628 File Offset: 0x008DC828
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040059EF RID: 23023
			Private eventRow As DataSetTurnAround.DataTable1Row

			' Token: 0x040059F0 RID: 23024
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
