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
	' Token: 0x02000252 RID: 594
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<XmlSchemaProvider("GetTypedDataSetSchema")>
	<XmlRoot("BarcodeDataSet")>
	<HelpKeyword("vs.data.DataSet")>
	<Serializable()>
	Public Class BarcodeDataSet
		Inherits DataSet

		' Token: 0x0600A198 RID: 41368 RVA: 0x006F4BA8 File Offset: 0x006F2DA8
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

		' Token: 0x0600A199 RID: 41369 RVA: 0x006F4C00 File Offset: 0x006F2E00
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
						MyBase.Tables.Add(New BarcodeDataSet.DataTable1DataTable(dataSet.Tables("DataTable1")))
					End If
					Dim flag4 As Boolean = dataSet.Tables("DataTable2") IsNot Nothing
					If flag4 Then
						MyBase.Tables.Add(New BarcodeDataSet.DataTable2DataTable(dataSet.Tables("DataTable2")))
					End If
					Dim flag5 As Boolean = dataSet.Tables("P_Transfer") IsNot Nothing
					If flag5 Then
						MyBase.Tables.Add(New BarcodeDataSet.P_TransferDataTable(dataSet.Tables("P_Transfer")))
					End If
					Dim flag6 As Boolean = dataSet.Tables("DataTable11") IsNot Nothing
					If flag6 Then
						MyBase.Tables.Add(New BarcodeDataSet.DataTable11DataTable(dataSet.Tables("DataTable11")))
					End If
					Dim flag7 As Boolean = dataSet.Tables("SaleD") IsNot Nothing
					If flag7 Then
						MyBase.Tables.Add(New BarcodeDataSet.SaleDDataTable(dataSet.Tables("SaleD")))
					End If
					Dim flag8 As Boolean = dataSet.Tables("DataTable3") IsNot Nothing
					If flag8 Then
						MyBase.Tables.Add(New BarcodeDataSet.DataTable3DataTable(dataSet.Tables("DataTable3")))
					End If
					Dim flag9 As Boolean = dataSet.Tables("DataTable4") IsNot Nothing
					If flag9 Then
						MyBase.Tables.Add(New BarcodeDataSet.DataTable4DataTable(dataSet.Tables("DataTable4")))
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

		' Token: 0x17003EB5 RID: 16053
		' (get) Token: 0x0600A19A RID: 41370 RVA: 0x006F4F08 File Offset: 0x006F3108
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable1 As BarcodeDataSet.DataTable1DataTable
			Get
				Return Me.tableDataTable1
			End Get
		End Property

		' Token: 0x17003EB6 RID: 16054
		' (get) Token: 0x0600A19B RID: 41371 RVA: 0x006F4F20 File Offset: 0x006F3120
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable2 As BarcodeDataSet.DataTable2DataTable
			Get
				Return Me.tableDataTable2
			End Get
		End Property

		' Token: 0x17003EB7 RID: 16055
		' (get) Token: 0x0600A19C RID: 41372 RVA: 0x006F4F38 File Offset: 0x006F3138
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property P_Transfer As BarcodeDataSet.P_TransferDataTable
			Get
				Return Me.tableP_Transfer
			End Get
		End Property

		' Token: 0x17003EB8 RID: 16056
		' (get) Token: 0x0600A19D RID: 41373 RVA: 0x006F4F50 File Offset: 0x006F3150
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable11 As BarcodeDataSet.DataTable11DataTable
			Get
				Return Me.tableDataTable11
			End Get
		End Property

		' Token: 0x17003EB9 RID: 16057
		' (get) Token: 0x0600A19E RID: 41374 RVA: 0x006F4F68 File Offset: 0x006F3168
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property SaleD As BarcodeDataSet.SaleDDataTable
			Get
				Return Me.tableSaleD
			End Get
		End Property

		' Token: 0x17003EBA RID: 16058
		' (get) Token: 0x0600A19F RID: 41375 RVA: 0x006F4F80 File Offset: 0x006F3180
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable3 As BarcodeDataSet.DataTable3DataTable
			Get
				Return Me.tableDataTable3
			End Get
		End Property

		' Token: 0x17003EBB RID: 16059
		' (get) Token: 0x0600A1A0 RID: 41376 RVA: 0x006F4F98 File Offset: 0x006F3198
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property DataTable4 As BarcodeDataSet.DataTable4DataTable
			Get
				Return Me.tableDataTable4
			End Get
		End Property

		' Token: 0x17003EBC RID: 16060
		' (get) Token: 0x0600A1A1 RID: 41377 RVA: 0x006F4FB0 File Offset: 0x006F31B0
		' (set) Token: 0x0600A1A2 RID: 41378 RVA: 0x0004BC61 File Offset: 0x00049E61
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

		' Token: 0x17003EBD RID: 16061
		' (get) Token: 0x0600A1A3 RID: 41379 RVA: 0x000A025C File Offset: 0x0009E45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Tables As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		' Token: 0x17003EBE RID: 16062
		' (get) Token: 0x0600A1A4 RID: 41380 RVA: 0x000A0274 File Offset: 0x0009E474
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
		Public ReadOnly Property Relations As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property

		' Token: 0x0600A1A5 RID: 41381 RVA: 0x0004BC6B File Offset: 0x00049E6B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Sub InitializeDerivedDataSet()
			MyBase.BeginInit()
			Me.InitClass()
			MyBase.EndInit()
		End Sub

		' Token: 0x0600A1A6 RID: 41382 RVA: 0x006F4FC8 File Offset: 0x006F31C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overrides Function Clone() As DataSet
			Dim barcodeDataSet As BarcodeDataSet = CType(MyBase.Clone(), BarcodeDataSet)
			barcodeDataSet.InitVars()
			barcodeDataSet.SchemaSerializationMode = Me.SchemaSerializationMode
			Return barcodeDataSet
		End Function

		' Token: 0x0600A1A7 RID: 41383 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		' Token: 0x0600A1A8 RID: 41384 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		' Token: 0x0600A1A9 RID: 41385 RVA: 0x006F4FFC File Offset: 0x006F31FC
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
					MyBase.Tables.Add(New BarcodeDataSet.DataTable1DataTable(dataSet.Tables("DataTable1")))
				End If
				Dim flag3 As Boolean = dataSet.Tables("DataTable2") IsNot Nothing
				If flag3 Then
					MyBase.Tables.Add(New BarcodeDataSet.DataTable2DataTable(dataSet.Tables("DataTable2")))
				End If
				Dim flag4 As Boolean = dataSet.Tables("P_Transfer") IsNot Nothing
				If flag4 Then
					MyBase.Tables.Add(New BarcodeDataSet.P_TransferDataTable(dataSet.Tables("P_Transfer")))
				End If
				Dim flag5 As Boolean = dataSet.Tables("DataTable11") IsNot Nothing
				If flag5 Then
					MyBase.Tables.Add(New BarcodeDataSet.DataTable11DataTable(dataSet.Tables("DataTable11")))
				End If
				Dim flag6 As Boolean = dataSet.Tables("SaleD") IsNot Nothing
				If flag6 Then
					MyBase.Tables.Add(New BarcodeDataSet.SaleDDataTable(dataSet.Tables("SaleD")))
				End If
				Dim flag7 As Boolean = dataSet.Tables("DataTable3") IsNot Nothing
				If flag7 Then
					MyBase.Tables.Add(New BarcodeDataSet.DataTable3DataTable(dataSet.Tables("DataTable3")))
				End If
				Dim flag8 As Boolean = dataSet.Tables("DataTable4") IsNot Nothing
				If flag8 Then
					MyBase.Tables.Add(New BarcodeDataSet.DataTable4DataTable(dataSet.Tables("DataTable4")))
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

		' Token: 0x0600A1AA RID: 41386 RVA: 0x000A042C File Offset: 0x0009E62C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overrides Function GetSchemaSerializable() As XmlSchema
			Dim memoryStream As MemoryStream = New MemoryStream()
			MyBase.WriteXmlSchema(New XmlTextWriter(memoryStream, Nothing))
			memoryStream.Position = 0L
			Return XmlSchema.Read(New XmlTextReader(memoryStream), Nothing)
		End Function

		' Token: 0x0600A1AB RID: 41387 RVA: 0x0004BC83 File Offset: 0x00049E83
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars()
			Me.InitVars(True)
		End Sub

		' Token: 0x0600A1AC RID: 41388 RVA: 0x006F5244 File Offset: 0x006F3444
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Sub InitVars(initTable As Boolean)
			Me.tableDataTable1 = CType(MyBase.Tables("DataTable1"), BarcodeDataSet.DataTable1DataTable)
			If initTable Then
				Dim flag As Boolean = Me.tableDataTable1 IsNot Nothing
				If flag Then
					Me.tableDataTable1.InitVars()
				End If
			End If
			Me.tableDataTable2 = CType(MyBase.Tables("DataTable2"), BarcodeDataSet.DataTable2DataTable)
			If initTable Then
				Dim flag2 As Boolean = Me.tableDataTable2 IsNot Nothing
				If flag2 Then
					Me.tableDataTable2.InitVars()
				End If
			End If
			Me.tableP_Transfer = CType(MyBase.Tables("P_Transfer"), BarcodeDataSet.P_TransferDataTable)
			If initTable Then
				Dim flag3 As Boolean = Me.tableP_Transfer IsNot Nothing
				If flag3 Then
					Me.tableP_Transfer.InitVars()
				End If
			End If
			Me.tableDataTable11 = CType(MyBase.Tables("DataTable11"), BarcodeDataSet.DataTable11DataTable)
			If initTable Then
				Dim flag4 As Boolean = Me.tableDataTable11 IsNot Nothing
				If flag4 Then
					Me.tableDataTable11.InitVars()
				End If
			End If
			Me.tableSaleD = CType(MyBase.Tables("SaleD"), BarcodeDataSet.SaleDDataTable)
			If initTable Then
				Dim flag5 As Boolean = Me.tableSaleD IsNot Nothing
				If flag5 Then
					Me.tableSaleD.InitVars()
				End If
			End If
			Me.tableDataTable3 = CType(MyBase.Tables("DataTable3"), BarcodeDataSet.DataTable3DataTable)
			If initTable Then
				Dim flag6 As Boolean = Me.tableDataTable3 IsNot Nothing
				If flag6 Then
					Me.tableDataTable3.InitVars()
				End If
			End If
			Me.tableDataTable4 = CType(MyBase.Tables("DataTable4"), BarcodeDataSet.DataTable4DataTable)
			If initTable Then
				Dim flag7 As Boolean = Me.tableDataTable4 IsNot Nothing
				If flag7 Then
					Me.tableDataTable4.InitVars()
				End If
			End If
		End Sub

		' Token: 0x0600A1AD RID: 41389 RVA: 0x006F5414 File Offset: 0x006F3614
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitClass()
			MyBase.DataSetName = "BarcodeDataSet"
			MyBase.Prefix = ""
			MyBase.[Namespace] = "http://tempuri.org/BarcodeDataSet.xsd"
			MyBase.EnforceConstraints = True
			Me.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
			Me.tableDataTable1 = New BarcodeDataSet.DataTable1DataTable()
			MyBase.Tables.Add(Me.tableDataTable1)
			Me.tableDataTable2 = New BarcodeDataSet.DataTable2DataTable()
			MyBase.Tables.Add(Me.tableDataTable2)
			Me.tableP_Transfer = New BarcodeDataSet.P_TransferDataTable()
			MyBase.Tables.Add(Me.tableP_Transfer)
			Me.tableDataTable11 = New BarcodeDataSet.DataTable11DataTable()
			MyBase.Tables.Add(Me.tableDataTable11)
			Me.tableSaleD = New BarcodeDataSet.SaleDDataTable()
			MyBase.Tables.Add(Me.tableSaleD)
			Me.tableDataTable3 = New BarcodeDataSet.DataTable3DataTable()
			MyBase.Tables.Add(Me.tableDataTable3)
			Me.tableDataTable4 = New BarcodeDataSet.DataTable4DataTable()
			MyBase.Tables.Add(Me.tableDataTable4)
		End Sub

		' Token: 0x0600A1AE RID: 41390 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable1() As Boolean
			Return False
		End Function

		' Token: 0x0600A1AF RID: 41391 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable2() As Boolean
			Return False
		End Function

		' Token: 0x0600A1B0 RID: 41392 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeP_Transfer() As Boolean
			Return False
		End Function

		' Token: 0x0600A1B1 RID: 41393 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable11() As Boolean
			Return False
		End Function

		' Token: 0x0600A1B2 RID: 41394 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeSaleD() As Boolean
			Return False
		End Function

		' Token: 0x0600A1B3 RID: 41395 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable3() As Boolean
			Return False
		End Function

		' Token: 0x0600A1B4 RID: 41396 RVA: 0x000A02C0 File Offset: 0x0009E4C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function ShouldSerializeDataTable4() As Boolean
			Return False
		End Function

		' Token: 0x0600A1B5 RID: 41397 RVA: 0x006F5524 File Offset: 0x006F3724
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub SchemaChanged(sender As Object, e As CollectionChangeEventArgs)
			Dim flag As Boolean = e.Action = CollectionChangeAction.Remove
			If flag Then
				Me.InitVars()
			End If
		End Sub

		' Token: 0x0600A1B6 RID: 41398 RVA: 0x006F5548 File Offset: 0x006F3748
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Shared Function GetTypedDataSetSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
			Dim barcodeDataSet As BarcodeDataSet = New BarcodeDataSet()
			Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
			Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
			Dim xmlSchemaAny As XmlSchemaAny = New XmlSchemaAny()
			xmlSchemaAny.[Namespace] = barcodeDataSet.[Namespace]
			xmlSchemaSequence.Items.Add(xmlSchemaAny)
			xmlSchemaComplexType.Particle = xmlSchemaSequence
			Dim schemaSerializable As XmlSchema = barcodeDataSet.GetSchemaSerializable()
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

		' Token: 0x040044E2 RID: 17634
		Private tableDataTable1 As BarcodeDataSet.DataTable1DataTable

		' Token: 0x040044E3 RID: 17635
		Private tableDataTable2 As BarcodeDataSet.DataTable2DataTable

		' Token: 0x040044E4 RID: 17636
		Private tableP_Transfer As BarcodeDataSet.P_TransferDataTable

		' Token: 0x040044E5 RID: 17637
		Private tableDataTable11 As BarcodeDataSet.DataTable11DataTable

		' Token: 0x040044E6 RID: 17638
		Private tableSaleD As BarcodeDataSet.SaleDDataTable

		' Token: 0x040044E7 RID: 17639
		Private tableDataTable3 As BarcodeDataSet.DataTable3DataTable

		' Token: 0x040044E8 RID: 17640
		Private tableDataTable4 As BarcodeDataSet.DataTable4DataTable

		' Token: 0x040044E9 RID: 17641
		Private _schemaSerializationMode As SchemaSerializationMode

		' Token: 0x02000253 RID: 595
		' (Invoke) Token: 0x0600A1BA RID: 41402
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable1RowChangeEventHandler(sender As Object, e As BarcodeDataSet.DataTable1RowChangeEvent)

		' Token: 0x02000254 RID: 596
		' (Invoke) Token: 0x0600A1BE RID: 41406
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable2RowChangeEventHandler(sender As Object, e As BarcodeDataSet.DataTable2RowChangeEvent)

		' Token: 0x02000255 RID: 597
		' (Invoke) Token: 0x0600A1C2 RID: 41410
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub P_TransferRowChangeEventHandler(sender As Object, e As BarcodeDataSet.P_TransferRowChangeEvent)

		' Token: 0x02000256 RID: 598
		' (Invoke) Token: 0x0600A1C6 RID: 41414
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable11RowChangeEventHandler(sender As Object, e As BarcodeDataSet.DataTable11RowChangeEvent)

		' Token: 0x02000257 RID: 599
		' (Invoke) Token: 0x0600A1CA RID: 41418
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub SaleDRowChangeEventHandler(sender As Object, e As BarcodeDataSet.SaleDRowChangeEvent)

		' Token: 0x02000258 RID: 600
		' (Invoke) Token: 0x0600A1CE RID: 41422
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable3RowChangeEventHandler(sender As Object, e As BarcodeDataSet.DataTable3RowChangeEvent)

		' Token: 0x02000259 RID: 601
		' (Invoke) Token: 0x0600A1D2 RID: 41426
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Delegate Sub DataTable4RowChangeEventHandler(sender As Object, e As BarcodeDataSet.DataTable4RowChangeEvent)

		' Token: 0x0200025A RID: 602
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable1DataTable
			Inherits TypedTableBase(Of BarcodeDataSet.DataTable1Row)

			' Token: 0x0600A1D3 RID: 41427 RVA: 0x0004BC8E File Offset: 0x00049E8E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				AddHandler MyBase.ColumnChanging, AddressOf Me.DataTable1DataTable_ColumnChanging
				MyBase.TableName = "DataTable1"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600A1D4 RID: 41428 RVA: 0x006F56DC File Offset: 0x006F38DC
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

			' Token: 0x0600A1D5 RID: 41429 RVA: 0x0004BCCC File Offset: 0x00049ECC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				AddHandler MyBase.ColumnChanging, AddressOf Me.DataTable1DataTable_ColumnChanging
				Me.InitVars()
			End Sub

			' Token: 0x17003EBF RID: 16063
			' (get) Token: 0x0600A1D6 RID: 41430 RVA: 0x006F57B8 File Offset: 0x006F39B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PCodeColumn As DataColumn
				Get
					Return Me.columnPCode
				End Get
			End Property

			' Token: 0x17003EC0 RID: 16064
			' (get) Token: 0x0600A1D7 RID: 41431 RVA: 0x006F57D0 File Offset: 0x006F39D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductNameColumn As DataColumn
				Get
					Return Me.columnProductName
				End Get
			End Property

			' Token: 0x17003EC1 RID: 16065
			' (get) Token: 0x0600A1D8 RID: 41432 RVA: 0x006F57E8 File Offset: 0x006F39E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CategoryColumn As DataColumn
				Get
					Return Me.columnCategory
				End Get
			End Property

			' Token: 0x17003EC2 RID: 16066
			' (get) Token: 0x0600A1D9 RID: 41433 RVA: 0x006F5800 File Offset: 0x006F3A00
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x17003EC3 RID: 16067
			' (get) Token: 0x0600A1DA RID: 41434 RVA: 0x006F5818 File Offset: 0x006F3A18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AvlQtyColumn As DataColumn
				Get
					Return Me.columnAvlQty
				End Get
			End Property

			' Token: 0x17003EC4 RID: 16068
			' (get) Token: 0x0600A1DB RID: 41435 RVA: 0x006F5830 File Offset: 0x006F3A30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property NoCopyColumn As DataColumn
				Get
					Return Me.columnNoCopy
				End Get
			End Property

			' Token: 0x17003EC5 RID: 16069
			' (get) Token: 0x0600A1DC RID: 41436 RVA: 0x006F5848 File Offset: 0x006F3A48
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PartNoColumn As DataColumn
				Get
					Return Me.columnPartNo
				End Get
			End Property

			' Token: 0x17003EC6 RID: 16070
			' (get) Token: 0x0600A1DD RID: 41437 RVA: 0x006F5860 File Offset: 0x006F3A60
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCColumn As DataColumn
				Get
					Return Me.columnHSNC
				End Get
			End Property

			' Token: 0x17003EC7 RID: 16071
			' (get) Token: 0x0600A1DE RID: 41438 RVA: 0x006F5878 File Offset: 0x006F3A78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MRPColumn As DataColumn
				Get
					Return Me.columnMRP
				End Get
			End Property

			' Token: 0x17003EC8 RID: 16072
			' (get) Token: 0x0600A1DF RID: 41439 RVA: 0x006F5890 File Offset: 0x006F3A90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalePriceColumn As DataColumn
				Get
					Return Me.columnSalePrice
				End Get
			End Property

			' Token: 0x17003EC9 RID: 16073
			' (get) Token: 0x0600A1E0 RID: 41440 RVA: 0x006F58A8 File Offset: 0x006F3AA8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property WholesalePriceColumn As DataColumn
				Get
					Return Me.columnWholesalePrice
				End Get
			End Property

			' Token: 0x17003ECA RID: 16074
			' (get) Token: 0x0600A1E1 RID: 41441 RVA: 0x006F58C0 File Offset: 0x006F3AC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BatchColumn As DataColumn
				Get
					Return Me.columnBatch
				End Get
			End Property

			' Token: 0x17003ECB RID: 16075
			' (get) Token: 0x0600A1E2 RID: 41442 RVA: 0x006F58D8 File Offset: 0x006F3AD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MfgColumn As DataColumn
				Get
					Return Me.columnMfg
				End Get
			End Property

			' Token: 0x17003ECC RID: 16076
			' (get) Token: 0x0600A1E3 RID: 41443 RVA: 0x006F58F0 File Offset: 0x006F3AF0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ExpColumn As DataColumn
				Get
					Return Me.columnExp
				End Get
			End Property

			' Token: 0x17003ECD RID: 16077
			' (get) Token: 0x0600A1E4 RID: 41444 RVA: 0x006F5908 File Offset: 0x006F3B08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SizeColumn As DataColumn
				Get
					Return Me.columnSize
				End Get
			End Property

			' Token: 0x17003ECE RID: 16078
			' (get) Token: 0x0600A1E5 RID: 41445 RVA: 0x006F5920 File Offset: 0x006F3B20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ColourColumn As DataColumn
				Get
					Return Me.columnColour
				End Get
			End Property

			' Token: 0x17003ECF RID: 16079
			' (get) Token: 0x0600A1E6 RID: 41446 RVA: 0x006F5938 File Offset: 0x006F3B38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GSTColumn As DataColumn
				Get
					Return Me.columnGST
				End Get
			End Property

			' Token: 0x17003ED0 RID: 16080
			' (get) Token: 0x0600A1E7 RID: 41447 RVA: 0x006F5950 File Offset: 0x006F3B50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PurInvColumn As DataColumn
				Get
					Return Me.columnPurInv
				End Get
			End Property

			' Token: 0x17003ED1 RID: 16081
			' (get) Token: 0x0600A1E8 RID: 41448 RVA: 0x006F5968 File Offset: 0x006F3B68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IMEI1Column As DataColumn
				Get
					Return Me.columnIMEI1
				End Get
			End Property

			' Token: 0x17003ED2 RID: 16082
			' (get) Token: 0x0600A1E9 RID: 41449 RVA: 0x006F5980 File Offset: 0x006F3B80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IMEI2Column As DataColumn
				Get
					Return Me.columnIMEI2
				End Get
			End Property

			' Token: 0x17003ED3 RID: 16083
			' (get) Token: 0x0600A1EA RID: 41450 RVA: 0x006F5998 File Offset: 0x006F3B98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QrBarcodeColumn As DataColumn
				Get
					Return Me.columnQrBarcode
				End Get
			End Property

			' Token: 0x17003ED4 RID: 16084
			' (get) Token: 0x0600A1EB RID: 41451 RVA: 0x006F59B0 File Offset: 0x006F3BB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CBarcodeColumn As DataColumn
				Get
					Return Me.columnCBarcode
				End Get
			End Property

			' Token: 0x17003ED5 RID: 16085
			' (get) Token: 0x0600A1EC RID: 41452 RVA: 0x006F59C8 File Offset: 0x006F3BC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PImageColumn As DataColumn
				Get
					Return Me.columnPImage
				End Get
			End Property

			' Token: 0x17003ED6 RID: 16086
			' (get) Token: 0x0600A1ED RID: 41453 RVA: 0x006F59E0 File Offset: 0x006F3BE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PicColumn As DataColumn
				Get
					Return Me.columnPic
				End Get
			End Property

			' Token: 0x17003ED7 RID: 16087
			' (get) Token: 0x0600A1EE RID: 41454 RVA: 0x006F59F8 File Offset: 0x006F3BF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountColumn As DataColumn
				Get
					Return Me.columnDiscount
				End Get
			End Property

			' Token: 0x17003ED8 RID: 16088
			' (get) Token: 0x0600A1EF RID: 41455 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17003ED9 RID: 16089
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As BarcodeDataSet.DataTable1Row
				Get
					Return CType(MyBase.Rows(index), BarcodeDataSet.DataTable1Row)
				End Get
			End Property

			' Token: 0x14000030 RID: 48
			' (add) Token: 0x0600A1F1 RID: 41457 RVA: 0x006F5A34 File Offset: 0x006F3C34
			' (remove) Token: 0x0600A1F2 RID: 41458 RVA: 0x006F5A6C File Offset: 0x006F3C6C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanging As BarcodeDataSet.DataTable1RowChangeEventHandler

			' Token: 0x14000031 RID: 49
			' (add) Token: 0x0600A1F3 RID: 41459 RVA: 0x006F5AA4 File Offset: 0x006F3CA4
			' (remove) Token: 0x0600A1F4 RID: 41460 RVA: 0x006F5ADC File Offset: 0x006F3CDC
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowChanged As BarcodeDataSet.DataTable1RowChangeEventHandler

			' Token: 0x14000032 RID: 50
			' (add) Token: 0x0600A1F5 RID: 41461 RVA: 0x006F5B14 File Offset: 0x006F3D14
			' (remove) Token: 0x0600A1F6 RID: 41462 RVA: 0x006F5B4C File Offset: 0x006F3D4C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleting As BarcodeDataSet.DataTable1RowChangeEventHandler

			' Token: 0x14000033 RID: 51
			' (add) Token: 0x0600A1F7 RID: 41463 RVA: 0x006F5B84 File Offset: 0x006F3D84
			' (remove) Token: 0x0600A1F8 RID: 41464 RVA: 0x006F5BBC File Offset: 0x006F3DBC
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable1RowDeleted As BarcodeDataSet.DataTable1RowChangeEventHandler

			' Token: 0x0600A1F9 RID: 41465 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable1Row(row As BarcodeDataSet.DataTable1Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600A1FA RID: 41466 RVA: 0x006F5BF4 File Offset: 0x006F3DF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable1Row(PCode As String, ProductName As String, Category As String, Barcode As String, AvlQty As String, NoCopy As String, PartNo As String, HSNC As String, MRP As Double, SalePrice As Double, WholesalePrice As Double, Batch As String, Mfg As String, Exp As String, Size As String, Colour As String, GST As String, PurInv As String, IMEI1 As String, IMEI2 As String, QrBarcode As Byte(), CBarcode As String, PImage As Byte(), Pic As Byte(), Discount As Double) As BarcodeDataSet.DataTable1Row
				Dim dataTable1Row As BarcodeDataSet.DataTable1Row = CType(MyBase.NewRow(), BarcodeDataSet.DataTable1Row)
				Dim array As Object() = New Object() { PCode, ProductName, Category, Barcode, AvlQty, NoCopy, PartNo, HSNC, MRP, SalePrice, WholesalePrice, Batch, Mfg, Exp, Size, Colour, GST, PurInv, IMEI1, IMEI2, QrBarcode, CBarcode, PImage, Pic, Discount }
				dataTable1Row.ItemArray = array
				MyBase.Rows.Add(dataTable1Row)
				Return dataTable1Row
			End Function

			' Token: 0x0600A1FB RID: 41467 RVA: 0x006F5CD0 File Offset: 0x006F3ED0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable1DataTable As BarcodeDataSet.DataTable1DataTable = CType(MyBase.Clone(), BarcodeDataSet.DataTable1DataTable)
				dataTable1DataTable.InitVars()
				Return dataTable1DataTable
			End Function

			' Token: 0x0600A1FC RID: 41468 RVA: 0x006F5CF8 File Offset: 0x006F3EF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New BarcodeDataSet.DataTable1DataTable()
			End Function

			' Token: 0x0600A1FD RID: 41469 RVA: 0x006F5D10 File Offset: 0x006F3F10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnPCode = MyBase.Columns("PCode")
				Me.columnProductName = MyBase.Columns("ProductName")
				Me.columnCategory = MyBase.Columns("Category")
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnAvlQty = MyBase.Columns("AvlQty")
				Me.columnNoCopy = MyBase.Columns("NoCopy")
				Me.columnPartNo = MyBase.Columns("PartNo")
				Me.columnHSNC = MyBase.Columns("HSNC")
				Me.columnMRP = MyBase.Columns("MRP")
				Me.columnSalePrice = MyBase.Columns("SalePrice")
				Me.columnWholesalePrice = MyBase.Columns("WholesalePrice")
				Me.columnBatch = MyBase.Columns("Batch")
				Me.columnMfg = MyBase.Columns("Mfg")
				Me.columnExp = MyBase.Columns("Exp")
				Me.columnSize = MyBase.Columns("Size")
				Me.columnColour = MyBase.Columns("Colour")
				Me.columnGST = MyBase.Columns("GST")
				Me.columnPurInv = MyBase.Columns("PurInv")
				Me.columnIMEI1 = MyBase.Columns("IMEI1")
				Me.columnIMEI2 = MyBase.Columns("IMEI2")
				Me.columnQrBarcode = MyBase.Columns("QrBarcode")
				Me.columnCBarcode = MyBase.Columns("CBarcode")
				Me.columnPImage = MyBase.Columns("PImage")
				Me.columnPic = MyBase.Columns("Pic")
				Me.columnDiscount = MyBase.Columns("Discount")
			End Sub

			' Token: 0x0600A1FE RID: 41470 RVA: 0x006F5F44 File Offset: 0x006F4144
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnPCode = New DataColumn("PCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPCode)
				Me.columnProductName = New DataColumn("ProductName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductName)
				Me.columnCategory = New DataColumn("Category", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCategory)
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnAvlQty = New DataColumn("AvlQty", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAvlQty)
				Me.columnNoCopy = New DataColumn("NoCopy", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnNoCopy)
				Me.columnPartNo = New DataColumn("PartNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPartNo)
				Me.columnHSNC = New DataColumn("HSNC", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnHSNC)
				Me.columnMRP = New DataColumn("MRP", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMRP)
				Me.columnSalePrice = New DataColumn("SalePrice", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSalePrice)
				Me.columnWholesalePrice = New DataColumn("WholesalePrice", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnWholesalePrice)
				Me.columnBatch = New DataColumn("Batch", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBatch)
				Me.columnMfg = New DataColumn("Mfg", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMfg)
				Me.columnExp = New DataColumn("Exp", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnExp)
				Me.columnSize = New DataColumn("Size", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSize)
				Me.columnColour = New DataColumn("Colour", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnColour)
				Me.columnGST = New DataColumn("GST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGST)
				Me.columnPurInv = New DataColumn("PurInv", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPurInv)
				Me.columnIMEI1 = New DataColumn("IMEI1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIMEI1)
				Me.columnIMEI2 = New DataColumn("IMEI2", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIMEI2)
				Me.columnQrBarcode = New DataColumn("QrBarcode", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQrBarcode)
				Me.columnCBarcode = New DataColumn("CBarcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCBarcode)
				Me.columnPImage = New DataColumn("PImage", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPImage)
				Me.columnPic = New DataColumn("Pic", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPic)
				Me.columnDiscount = New DataColumn("Discount", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscount)
			End Sub

			' Token: 0x0600A1FF RID: 41471 RVA: 0x006F63D0 File Offset: 0x006F45D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable1Row() As BarcodeDataSet.DataTable1Row
				Return CType(MyBase.NewRow(), BarcodeDataSet.DataTable1Row)
			End Function

			' Token: 0x0600A200 RID: 41472 RVA: 0x006F63F0 File Offset: 0x006F45F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New BarcodeDataSet.DataTable1Row(builder)
			End Function

			' Token: 0x0600A201 RID: 41473 RVA: 0x006F6408 File Offset: 0x006F4608
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(BarcodeDataSet.DataTable1Row)
			End Function

			' Token: 0x0600A202 RID: 41474 RVA: 0x006F6424 File Offset: 0x006F4624
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable1RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangedEvent As BarcodeDataSet.DataTable1RowChangeEventHandler = Me.DataTable1RowChangedEvent
					If dataTable1RowChangedEvent IsNot Nothing Then
						dataTable1RowChangedEvent(Me, New BarcodeDataSet.DataTable1RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A203 RID: 41475 RVA: 0x006F6474 File Offset: 0x006F4674
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable1RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowChangingEvent As BarcodeDataSet.DataTable1RowChangeEventHandler = Me.DataTable1RowChangingEvent
					If dataTable1RowChangingEvent IsNot Nothing Then
						dataTable1RowChangingEvent(Me, New BarcodeDataSet.DataTable1RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A204 RID: 41476 RVA: 0x006F64C4 File Offset: 0x006F46C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable1RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletedEvent As BarcodeDataSet.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletedEvent
					If dataTable1RowDeletedEvent IsNot Nothing Then
						dataTable1RowDeletedEvent(Me, New BarcodeDataSet.DataTable1RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A205 RID: 41477 RVA: 0x006F6514 File Offset: 0x006F4714
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable1RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable1RowDeletingEvent As BarcodeDataSet.DataTable1RowChangeEventHandler = Me.DataTable1RowDeletingEvent
					If dataTable1RowDeletingEvent IsNot Nothing Then
						dataTable1RowDeletingEvent(Me, New BarcodeDataSet.DataTable1RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable1Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A206 RID: 41478 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable1Row(row As BarcodeDataSet.DataTable1Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600A207 RID: 41479 RVA: 0x006F6564 File Offset: 0x006F4764
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim barcodeDataSet As BarcodeDataSet = New BarcodeDataSet()
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
				xmlSchemaAttribute.FixedValue = barcodeDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable1DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = barcodeDataSet.GetSchemaSerializable()
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

			' Token: 0x0600A208 RID: 41480 RVA: 0x006F67B8 File Offset: 0x006F49B8
			Private Sub DataTable1DataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs)
				Dim flag As Boolean = Operators.CompareString(e.Column.ColumnName, Me.HSNCColumn.ColumnName, False) = 0
				If flag Then
				End If
			End Sub

			' Token: 0x040044EA RID: 17642
			Private columnPCode As DataColumn

			' Token: 0x040044EB RID: 17643
			Private columnProductName As DataColumn

			' Token: 0x040044EC RID: 17644
			Private columnCategory As DataColumn

			' Token: 0x040044ED RID: 17645
			Private columnBarcode As DataColumn

			' Token: 0x040044EE RID: 17646
			Private columnAvlQty As DataColumn

			' Token: 0x040044EF RID: 17647
			Private columnNoCopy As DataColumn

			' Token: 0x040044F0 RID: 17648
			Private columnPartNo As DataColumn

			' Token: 0x040044F1 RID: 17649
			Private columnHSNC As DataColumn

			' Token: 0x040044F2 RID: 17650
			Private columnMRP As DataColumn

			' Token: 0x040044F3 RID: 17651
			Private columnSalePrice As DataColumn

			' Token: 0x040044F4 RID: 17652
			Private columnWholesalePrice As DataColumn

			' Token: 0x040044F5 RID: 17653
			Private columnBatch As DataColumn

			' Token: 0x040044F6 RID: 17654
			Private columnMfg As DataColumn

			' Token: 0x040044F7 RID: 17655
			Private columnExp As DataColumn

			' Token: 0x040044F8 RID: 17656
			Private columnSize As DataColumn

			' Token: 0x040044F9 RID: 17657
			Private columnColour As DataColumn

			' Token: 0x040044FA RID: 17658
			Private columnGST As DataColumn

			' Token: 0x040044FB RID: 17659
			Private columnPurInv As DataColumn

			' Token: 0x040044FC RID: 17660
			Private columnIMEI1 As DataColumn

			' Token: 0x040044FD RID: 17661
			Private columnIMEI2 As DataColumn

			' Token: 0x040044FE RID: 17662
			Private columnQrBarcode As DataColumn

			' Token: 0x040044FF RID: 17663
			Private columnCBarcode As DataColumn

			' Token: 0x04004500 RID: 17664
			Private columnPImage As DataColumn

			' Token: 0x04004501 RID: 17665
			Private columnPic As DataColumn

			' Token: 0x04004502 RID: 17666
			Private columnDiscount As DataColumn
		End Class

		' Token: 0x0200025B RID: 603
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable2DataTable
			Inherits TypedTableBase(Of BarcodeDataSet.DataTable2Row)

			' Token: 0x0600A209 RID: 41481 RVA: 0x0004BCF2 File Offset: 0x00049EF2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable2"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600A20A RID: 41482 RVA: 0x006F67EC File Offset: 0x006F49EC
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

			' Token: 0x0600A20B RID: 41483 RVA: 0x0004BD1D File Offset: 0x00049F1D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17003EDA RID: 16090
			' (get) Token: 0x0600A20C RID: 41484 RVA: 0x006F68B8 File Offset: 0x006F4AB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x17003EDB RID: 16091
			' (get) Token: 0x0600A20D RID: 41485 RVA: 0x006F68D0 File Offset: 0x006F4AD0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QrBarcodeColumn As DataColumn
				Get
					Return Me.columnQrBarcode
				End Get
			End Property

			' Token: 0x17003EDC RID: 16092
			' (get) Token: 0x0600A20E RID: 41486 RVA: 0x006F68E8 File Offset: 0x006F4AE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductCodeColumn As DataColumn
				Get
					Return Me.columnProductCode
				End Get
			End Property

			' Token: 0x17003EDD RID: 16093
			' (get) Token: 0x0600A20F RID: 41487 RVA: 0x006F6900 File Offset: 0x006F4B00
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductNameColumn As DataColumn
				Get
					Return Me.columnProductName
				End Get
			End Property

			' Token: 0x17003EDE RID: 16094
			' (get) Token: 0x0600A210 RID: 41488 RVA: 0x006F6918 File Offset: 0x006F4B18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CategoryColumn As DataColumn
				Get
					Return Me.columnCategory
				End Get
			End Property

			' Token: 0x17003EDF RID: 16095
			' (get) Token: 0x0600A211 RID: 41489 RVA: 0x006F6930 File Offset: 0x006F4B30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QtyColumn As DataColumn
				Get
					Return Me.columnQty
				End Get
			End Property

			' Token: 0x17003EE0 RID: 16096
			' (get) Token: 0x0600A212 RID: 41490 RVA: 0x006F6948 File Offset: 0x006F4B48
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PartNoColumn As DataColumn
				Get
					Return Me.columnPartNo
				End Get
			End Property

			' Token: 0x17003EE1 RID: 16097
			' (get) Token: 0x0600A213 RID: 41491 RVA: 0x006F6960 File Offset: 0x006F4B60
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCodeColumn As DataColumn
				Get
					Return Me.columnHSNCode
				End Get
			End Property

			' Token: 0x17003EE2 RID: 16098
			' (get) Token: 0x0600A214 RID: 41492 RVA: 0x006F6978 File Offset: 0x006F4B78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MRPColumn As DataColumn
				Get
					Return Me.columnMRP
				End Get
			End Property

			' Token: 0x17003EE3 RID: 16099
			' (get) Token: 0x0600A215 RID: 41493 RVA: 0x006F6990 File Offset: 0x006F4B90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SPriceColumn As DataColumn
				Get
					Return Me.columnSPrice
				End Get
			End Property

			' Token: 0x17003EE4 RID: 16100
			' (get) Token: 0x0600A216 RID: 41494 RVA: 0x006F69A8 File Offset: 0x006F4BA8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property WPriceColumn As DataColumn
				Get
					Return Me.columnWPrice
				End Get
			End Property

			' Token: 0x17003EE5 RID: 16101
			' (get) Token: 0x0600A217 RID: 41495 RVA: 0x006F69C0 File Offset: 0x006F4BC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BatchColumn As DataColumn
				Get
					Return Me.columnBatch
				End Get
			End Property

			' Token: 0x17003EE6 RID: 16102
			' (get) Token: 0x0600A218 RID: 41496 RVA: 0x006F69D8 File Offset: 0x006F4BD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MfgdateColumn As DataColumn
				Get
					Return Me.columnMfgdate
				End Get
			End Property

			' Token: 0x17003EE7 RID: 16103
			' (get) Token: 0x0600A219 RID: 41497 RVA: 0x006F69F0 File Offset: 0x006F4BF0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ExpdateColumn As DataColumn
				Get
					Return Me.columnExpdate
				End Get
			End Property

			' Token: 0x17003EE8 RID: 16104
			' (get) Token: 0x0600A21A RID: 41498 RVA: 0x006F6A08 File Offset: 0x006F4C08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SizeColumn As DataColumn
				Get
					Return Me.columnSize
				End Get
			End Property

			' Token: 0x17003EE9 RID: 16105
			' (get) Token: 0x0600A21B RID: 41499 RVA: 0x006F6A20 File Offset: 0x006F4C20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ColourColumn As DataColumn
				Get
					Return Me.columnColour
				End Get
			End Property

			' Token: 0x17003EEA RID: 16106
			' (get) Token: 0x0600A21C RID: 41500 RVA: 0x006F6A38 File Offset: 0x006F4C38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTColumn As DataColumn
				Get
					Return Me.columnCGST
				End Get
			End Property

			' Token: 0x17003EEB RID: 16107
			' (get) Token: 0x0600A21D RID: 41501 RVA: 0x006F6A50 File Offset: 0x006F4C50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTColumn As DataColumn
				Get
					Return Me.columnSGST
				End Get
			End Property

			' Token: 0x17003EEC RID: 16108
			' (get) Token: 0x0600A21E RID: 41502 RVA: 0x006F6A68 File Offset: 0x006F4C68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CBarcodeColumn As DataColumn
				Get
					Return Me.columnCBarcode
				End Get
			End Property

			' Token: 0x17003EED RID: 16109
			' (get) Token: 0x0600A21F RID: 41503 RVA: 0x006F6A80 File Offset: 0x006F4C80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DefaultQtyColumn As DataColumn
				Get
					Return Me.columnDefaultQty
				End Get
			End Property

			' Token: 0x17003EEE RID: 16110
			' (get) Token: 0x0600A220 RID: 41504 RVA: 0x006F6A98 File Offset: 0x006F4C98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QRCBarcodeColumn As DataColumn
				Get
					Return Me.columnQRCBarcode
				End Get
			End Property

			' Token: 0x17003EEF RID: 16111
			' (get) Token: 0x0600A221 RID: 41505 RVA: 0x006F6AB0 File Offset: 0x006F4CB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountColumn As DataColumn
				Get
					Return Me.columnDiscount
				End Get
			End Property

			' Token: 0x17003EF0 RID: 16112
			' (get) Token: 0x0600A222 RID: 41506 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17003EF1 RID: 16113
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As BarcodeDataSet.DataTable2Row
				Get
					Return CType(MyBase.Rows(index), BarcodeDataSet.DataTable2Row)
				End Get
			End Property

			' Token: 0x14000034 RID: 52
			' (add) Token: 0x0600A224 RID: 41508 RVA: 0x006F6AEC File Offset: 0x006F4CEC
			' (remove) Token: 0x0600A225 RID: 41509 RVA: 0x006F6B24 File Offset: 0x006F4D24
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable2RowChanging As BarcodeDataSet.DataTable2RowChangeEventHandler

			' Token: 0x14000035 RID: 53
			' (add) Token: 0x0600A226 RID: 41510 RVA: 0x006F6B5C File Offset: 0x006F4D5C
			' (remove) Token: 0x0600A227 RID: 41511 RVA: 0x006F6B94 File Offset: 0x006F4D94
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable2RowChanged As BarcodeDataSet.DataTable2RowChangeEventHandler

			' Token: 0x14000036 RID: 54
			' (add) Token: 0x0600A228 RID: 41512 RVA: 0x006F6BCC File Offset: 0x006F4DCC
			' (remove) Token: 0x0600A229 RID: 41513 RVA: 0x006F6C04 File Offset: 0x006F4E04
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable2RowDeleting As BarcodeDataSet.DataTable2RowChangeEventHandler

			' Token: 0x14000037 RID: 55
			' (add) Token: 0x0600A22A RID: 41514 RVA: 0x006F6C3C File Offset: 0x006F4E3C
			' (remove) Token: 0x0600A22B RID: 41515 RVA: 0x006F6C74 File Offset: 0x006F4E74
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable2RowDeleted As BarcodeDataSet.DataTable2RowChangeEventHandler

			' Token: 0x0600A22C RID: 41516 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable2Row(row As BarcodeDataSet.DataTable2Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600A22D RID: 41517 RVA: 0x006F6CAC File Offset: 0x006F4EAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable2Row(Barcode As String, QrBarcode As Byte(), ProductCode As String, ProductName As String, Category As String, Qty As String, PartNo As String, HSNCode As String, MRP As Double, SPrice As Double, WPrice As Double, Batch As String, Mfgdate As String, Expdate As String, Size As String, Colour As String, CGST As String, SGST As String, CBarcode As String, DefaultQty As Double, QRCBarcode As Byte(), Discount As Double) As BarcodeDataSet.DataTable2Row
				Dim dataTable2Row As BarcodeDataSet.DataTable2Row = CType(MyBase.NewRow(), BarcodeDataSet.DataTable2Row)
				Dim array As Object() = New Object() { Barcode, QrBarcode, ProductCode, ProductName, Category, Qty, PartNo, HSNCode, MRP, SPrice, WPrice, Batch, Mfgdate, Expdate, Size, Colour, CGST, SGST, CBarcode, DefaultQty, QRCBarcode, Discount }
				dataTable2Row.ItemArray = array
				MyBase.Rows.Add(dataTable2Row)
				Return dataTable2Row
			End Function

			' Token: 0x0600A22E RID: 41518 RVA: 0x006F6D7C File Offset: 0x006F4F7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable2DataTable As BarcodeDataSet.DataTable2DataTable = CType(MyBase.Clone(), BarcodeDataSet.DataTable2DataTable)
				dataTable2DataTable.InitVars()
				Return dataTable2DataTable
			End Function

			' Token: 0x0600A22F RID: 41519 RVA: 0x006F6DA4 File Offset: 0x006F4FA4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New BarcodeDataSet.DataTable2DataTable()
			End Function

			' Token: 0x0600A230 RID: 41520 RVA: 0x006F6DBC File Offset: 0x006F4FBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnQrBarcode = MyBase.Columns("QrBarcode")
				Me.columnProductCode = MyBase.Columns("ProductCode")
				Me.columnProductName = MyBase.Columns("ProductName")
				Me.columnCategory = MyBase.Columns("Category")
				Me.columnQty = MyBase.Columns("Qty")
				Me.columnPartNo = MyBase.Columns("PartNo")
				Me.columnHSNCode = MyBase.Columns("HSNCode")
				Me.columnMRP = MyBase.Columns("MRP")
				Me.columnSPrice = MyBase.Columns("SPrice")
				Me.columnWPrice = MyBase.Columns("WPrice")
				Me.columnBatch = MyBase.Columns("Batch")
				Me.columnMfgdate = MyBase.Columns("Mfgdate")
				Me.columnExpdate = MyBase.Columns("Expdate")
				Me.columnSize = MyBase.Columns("Size")
				Me.columnColour = MyBase.Columns("Colour")
				Me.columnCGST = MyBase.Columns("CGST")
				Me.columnSGST = MyBase.Columns("SGST")
				Me.columnCBarcode = MyBase.Columns("CBarcode")
				Me.columnDefaultQty = MyBase.Columns("DefaultQty")
				Me.columnQRCBarcode = MyBase.Columns("QRCBarcode")
				Me.columnDiscount = MyBase.Columns("Discount")
			End Sub

			' Token: 0x0600A231 RID: 41521 RVA: 0x006F6FB0 File Offset: 0x006F51B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnQrBarcode = New DataColumn("QrBarcode", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQrBarcode)
				Me.columnProductCode = New DataColumn("ProductCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductCode)
				Me.columnProductName = New DataColumn("ProductName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductName)
				Me.columnCategory = New DataColumn("Category", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCategory)
				Me.columnQty = New DataColumn("Qty", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQty)
				Me.columnPartNo = New DataColumn("PartNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPartNo)
				Me.columnHSNCode = New DataColumn("HSNCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnHSNCode)
				Me.columnMRP = New DataColumn("MRP", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMRP)
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
				Me.columnSize = New DataColumn("Size", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSize)
				Me.columnColour = New DataColumn("Colour", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnColour)
				Me.columnCGST = New DataColumn("CGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGST)
				Me.columnSGST = New DataColumn("SGST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGST)
				Me.columnCBarcode = New DataColumn("CBarcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCBarcode)
				Me.columnDefaultQty = New DataColumn("DefaultQty", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDefaultQty)
				Me.columnQRCBarcode = New DataColumn("QRCBarcode", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQRCBarcode)
				Me.columnDiscount = New DataColumn("Discount", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscount)
			End Sub

			' Token: 0x0600A232 RID: 41522 RVA: 0x006F73B4 File Offset: 0x006F55B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable2Row() As BarcodeDataSet.DataTable2Row
				Return CType(MyBase.NewRow(), BarcodeDataSet.DataTable2Row)
			End Function

			' Token: 0x0600A233 RID: 41523 RVA: 0x006F73D4 File Offset: 0x006F55D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New BarcodeDataSet.DataTable2Row(builder)
			End Function

			' Token: 0x0600A234 RID: 41524 RVA: 0x006F73EC File Offset: 0x006F55EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(BarcodeDataSet.DataTable2Row)
			End Function

			' Token: 0x0600A235 RID: 41525 RVA: 0x006F7408 File Offset: 0x006F5608
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable2RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable2RowChangedEvent As BarcodeDataSet.DataTable2RowChangeEventHandler = Me.DataTable2RowChangedEvent
					If dataTable2RowChangedEvent IsNot Nothing Then
						dataTable2RowChangedEvent(Me, New BarcodeDataSet.DataTable2RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable2Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A236 RID: 41526 RVA: 0x006F7458 File Offset: 0x006F5658
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable2RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable2RowChangingEvent As BarcodeDataSet.DataTable2RowChangeEventHandler = Me.DataTable2RowChangingEvent
					If dataTable2RowChangingEvent IsNot Nothing Then
						dataTable2RowChangingEvent(Me, New BarcodeDataSet.DataTable2RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable2Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A237 RID: 41527 RVA: 0x006F74A8 File Offset: 0x006F56A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable2RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable2RowDeletedEvent As BarcodeDataSet.DataTable2RowChangeEventHandler = Me.DataTable2RowDeletedEvent
					If dataTable2RowDeletedEvent IsNot Nothing Then
						dataTable2RowDeletedEvent(Me, New BarcodeDataSet.DataTable2RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable2Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A238 RID: 41528 RVA: 0x006F74F8 File Offset: 0x006F56F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable2RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable2RowDeletingEvent As BarcodeDataSet.DataTable2RowChangeEventHandler = Me.DataTable2RowDeletingEvent
					If dataTable2RowDeletingEvent IsNot Nothing Then
						dataTable2RowDeletingEvent(Me, New BarcodeDataSet.DataTable2RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable2Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A239 RID: 41529 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable2Row(row As BarcodeDataSet.DataTable2Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600A23A RID: 41530 RVA: 0x006F7548 File Offset: 0x006F5748
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim barcodeDataSet As BarcodeDataSet = New BarcodeDataSet()
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
				xmlSchemaAttribute.FixedValue = barcodeDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable2DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = barcodeDataSet.GetSchemaSerializable()
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

			' Token: 0x04004507 RID: 17671
			Private columnBarcode As DataColumn

			' Token: 0x04004508 RID: 17672
			Private columnQrBarcode As DataColumn

			' Token: 0x04004509 RID: 17673
			Private columnProductCode As DataColumn

			' Token: 0x0400450A RID: 17674
			Private columnProductName As DataColumn

			' Token: 0x0400450B RID: 17675
			Private columnCategory As DataColumn

			' Token: 0x0400450C RID: 17676
			Private columnQty As DataColumn

			' Token: 0x0400450D RID: 17677
			Private columnPartNo As DataColumn

			' Token: 0x0400450E RID: 17678
			Private columnHSNCode As DataColumn

			' Token: 0x0400450F RID: 17679
			Private columnMRP As DataColumn

			' Token: 0x04004510 RID: 17680
			Private columnSPrice As DataColumn

			' Token: 0x04004511 RID: 17681
			Private columnWPrice As DataColumn

			' Token: 0x04004512 RID: 17682
			Private columnBatch As DataColumn

			' Token: 0x04004513 RID: 17683
			Private columnMfgdate As DataColumn

			' Token: 0x04004514 RID: 17684
			Private columnExpdate As DataColumn

			' Token: 0x04004515 RID: 17685
			Private columnSize As DataColumn

			' Token: 0x04004516 RID: 17686
			Private columnColour As DataColumn

			' Token: 0x04004517 RID: 17687
			Private columnCGST As DataColumn

			' Token: 0x04004518 RID: 17688
			Private columnSGST As DataColumn

			' Token: 0x04004519 RID: 17689
			Private columnCBarcode As DataColumn

			' Token: 0x0400451A RID: 17690
			Private columnDefaultQty As DataColumn

			' Token: 0x0400451B RID: 17691
			Private columnQRCBarcode As DataColumn

			' Token: 0x0400451C RID: 17692
			Private columnDiscount As DataColumn
		End Class

		' Token: 0x0200025C RID: 604
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class P_TransferDataTable
			Inherits TypedTableBase(Of BarcodeDataSet.P_TransferRow)

			' Token: 0x0600A23B RID: 41531 RVA: 0x0004BD30 File Offset: 0x00049F30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "P_Transfer"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600A23C RID: 41532 RVA: 0x006F779C File Offset: 0x006F599C
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

			' Token: 0x0600A23D RID: 41533 RVA: 0x0004BD5B File Offset: 0x00049F5B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17003EF2 RID: 16114
			' (get) Token: 0x0600A23E RID: 41534 RVA: 0x006F7868 File Offset: 0x006F5A68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IDColumn As DataColumn
				Get
					Return Me.columnID
				End Get
			End Property

			' Token: 0x17003EF3 RID: 16115
			' (get) Token: 0x0600A23F RID: 41535 RVA: 0x006F7880 File Offset: 0x006F5A80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductCodeColumn As DataColumn
				Get
					Return Me.columnProductCode
				End Get
			End Property

			' Token: 0x17003EF4 RID: 16116
			' (get) Token: 0x0600A240 RID: 41536 RVA: 0x006F7898 File Offset: 0x006F5A98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x17003EF5 RID: 16117
			' (get) Token: 0x0600A241 RID: 41537 RVA: 0x006F78B0 File Offset: 0x006F5AB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductnameColumn As DataColumn
				Get
					Return Me.columnProductname
				End Get
			End Property

			' Token: 0x17003EF6 RID: 16118
			' (get) Token: 0x0600A242 RID: 41538 RVA: 0x006F78C8 File Offset: 0x006F5AC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCodeColumn As DataColumn
				Get
					Return Me.columnHSNCode
				End Get
			End Property

			' Token: 0x17003EF7 RID: 16119
			' (get) Token: 0x0600A243 RID: 41539 RVA: 0x006F78E0 File Offset: 0x006F5AE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PartNoColumn As DataColumn
				Get
					Return Me.columnPartNo
				End Get
			End Property

			' Token: 0x17003EF8 RID: 16120
			' (get) Token: 0x0600A244 RID: 41540 RVA: 0x006F78F8 File Offset: 0x006F5AF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DescriptionColumn As DataColumn
				Get
					Return Me.columnDescription
				End Get
			End Property

			' Token: 0x17003EF9 RID: 16121
			' (get) Token: 0x0600A245 RID: 41541 RVA: 0x006F7910 File Offset: 0x006F5B10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CostPriceColumn As DataColumn
				Get
					Return Me.columnCostPrice
				End Get
			End Property

			' Token: 0x17003EFA RID: 16122
			' (get) Token: 0x0600A246 RID: 41542 RVA: 0x006F7928 File Offset: 0x006F5B28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MRPColumn As DataColumn
				Get
					Return Me.columnMRP
				End Get
			End Property

			' Token: 0x17003EFB RID: 16123
			' (get) Token: 0x0600A247 RID: 41543 RVA: 0x006F7940 File Offset: 0x006F5B40
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SellingPriceColumn As DataColumn
				Get
					Return Me.columnSellingPrice
				End Get
			End Property

			' Token: 0x17003EFC RID: 16124
			' (get) Token: 0x0600A248 RID: 41544 RVA: 0x006F7958 File Offset: 0x006F5B58
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ReorderPointColumn As DataColumn
				Get
					Return Me.columnReorderPoint
				End Get
			End Property

			' Token: 0x17003EFD RID: 16125
			' (get) Token: 0x0600A249 RID: 41545 RVA: 0x006F7970 File Offset: 0x006F5B70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountColumn As DataColumn
				Get
					Return Me.columnDiscount
				End Get
			End Property

			' Token: 0x17003EFE RID: 16126
			' (get) Token: 0x0600A24A RID: 41546 RVA: 0x006F7988 File Offset: 0x006F5B88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTColumn As DataColumn
				Get
					Return Me.columnCGST
				End Get
			End Property

			' Token: 0x17003EFF RID: 16127
			' (get) Token: 0x0600A24B RID: 41547 RVA: 0x006F79A0 File Offset: 0x006F5BA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTColumn As DataColumn
				Get
					Return Me.columnSGST
				End Get
			End Property

			' Token: 0x17003F00 RID: 16128
			' (get) Token: 0x0600A24C RID: 41548 RVA: 0x006F79B8 File Offset: 0x006F5BB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSColumn As DataColumn
				Get
					Return Me.columnCESS
				End Get
			End Property

			' Token: 0x17003F01 RID: 16129
			' (get) Token: 0x0600A24D RID: 41549 RVA: 0x006F79D0 File Offset: 0x006F5BD0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PurchaseUnitColumn As DataColumn
				Get
					Return Me.columnPurchaseUnit
				End Get
			End Property

			' Token: 0x17003F02 RID: 16130
			' (get) Token: 0x0600A24E RID: 41550 RVA: 0x006F79E8 File Offset: 0x006F5BE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalesunitColumn As DataColumn
				Get
					Return Me.columnSalesunit
				End Get
			End Property

			' Token: 0x17003F03 RID: 16131
			' (get) Token: 0x0600A24F RID: 41551 RVA: 0x006F7A00 File Offset: 0x006F5C00
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalesAltUnitColumn As DataColumn
				Get
					Return Me.columnSalesAltUnit
				End Get
			End Property

			' Token: 0x17003F04 RID: 16132
			' (get) Token: 0x0600A250 RID: 41552 RVA: 0x006F7A18 File Offset: 0x006F5C18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ConvColumn As DataColumn
				Get
					Return Me.columnConv
				End Get
			End Property

			' Token: 0x17003F05 RID: 16133
			' (get) Token: 0x0600A251 RID: 41553 RVA: 0x006F7A30 File Offset: 0x006F5C30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MinStockColumn As DataColumn
				Get
					Return Me.columnMinStock
				End Get
			End Property

			' Token: 0x17003F06 RID: 16134
			' (get) Token: 0x0600A252 RID: 41554 RVA: 0x006F7A48 File Offset: 0x006F5C48
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GDownColumn As DataColumn
				Get
					Return Me.columnGDown
				End Get
			End Property

			' Token: 0x17003F07 RID: 16135
			' (get) Token: 0x0600A253 RID: 41555 RVA: 0x006F7A60 File Offset: 0x006F5C60
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RackColumn As DataColumn
				Get
					Return Me.columnRack
				End Get
			End Property

			' Token: 0x17003F08 RID: 16136
			' (get) Token: 0x0600A254 RID: 41556 RVA: 0x006F7A78 File Offset: 0x006F5C78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DefQtyColumn As DataColumn
				Get
					Return Me.columnDefQty
				End Get
			End Property

			' Token: 0x17003F09 RID: 16137
			' (get) Token: 0x0600A255 RID: 41557 RVA: 0x006F7A90 File Offset: 0x006F5C90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PPriceColumn As DataColumn
				Get
					Return Me.columnPPrice
				End Get
			End Property

			' Token: 0x17003F0A RID: 16138
			' (get) Token: 0x0600A256 RID: 41558 RVA: 0x006F7AA8 File Offset: 0x006F5CA8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Temp_StockMRPColumn As DataColumn
				Get
					Return Me.columnTemp_StockMRP
				End Get
			End Property

			' Token: 0x17003F0B RID: 16139
			' (get) Token: 0x0600A257 RID: 41559 RVA: 0x006F7AC0 File Offset: 0x006F5CC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SPriceColumn As DataColumn
				Get
					Return Me.columnSPrice
				End Get
			End Property

			' Token: 0x17003F0C RID: 16140
			' (get) Token: 0x0600A258 RID: 41560 RVA: 0x006F7AD8 File Offset: 0x006F5CD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property WPriceColumn As DataColumn
				Get
					Return Me.columnWPrice
				End Get
			End Property

			' Token: 0x17003F0D RID: 16141
			' (get) Token: 0x0600A259 RID: 41561 RVA: 0x006F7AF0 File Offset: 0x006F5CF0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BatchColumn As DataColumn
				Get
					Return Me.columnBatch
				End Get
			End Property

			' Token: 0x17003F0E RID: 16142
			' (get) Token: 0x0600A25A RID: 41562 RVA: 0x006F7B08 File Offset: 0x006F5D08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MfgdateColumn As DataColumn
				Get
					Return Me.columnMfgdate
				End Get
			End Property

			' Token: 0x17003F0F RID: 16143
			' (get) Token: 0x0600A25B RID: 41563 RVA: 0x006F7B20 File Offset: 0x006F5D20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ExpdateColumn As DataColumn
				Get
					Return Me.columnExpdate
				End Get
			End Property

			' Token: 0x17003F10 RID: 16144
			' (get) Token: 0x0600A25C RID: 41564 RVA: 0x006F7B38 File Offset: 0x006F5D38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ColourColumn As DataColumn
				Get
					Return Me.columnColour
				End Get
			End Property

			' Token: 0x17003F11 RID: 16145
			' (get) Token: 0x0600A25D RID: 41565 RVA: 0x006F7B50 File Offset: 0x006F5D50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SizeColumn As DataColumn
				Get
					Return Me.columnSize
				End Get
			End Property

			' Token: 0x17003F12 RID: 16146
			' (get) Token: 0x0600A25E RID: 41566 RVA: 0x006F7B68 File Offset: 0x006F5D68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IMEI1Column As DataColumn
				Get
					Return Me.columnIMEI1
				End Get
			End Property

			' Token: 0x17003F13 RID: 16147
			' (get) Token: 0x0600A25F RID: 41567 RVA: 0x006F7B80 File Offset: 0x006F5D80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IMEI2Column As DataColumn
				Get
					Return Me.columnIMEI2
				End Get
			End Property

			' Token: 0x17003F14 RID: 16148
			' (get) Token: 0x0600A260 RID: 41568 RVA: 0x006F7B98 File Offset: 0x006F5D98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property StatusColumn As DataColumn
				Get
					Return Me.columnStatus
				End Get
			End Property

			' Token: 0x17003F15 RID: 16149
			' (get) Token: 0x0600A261 RID: 41569 RVA: 0x006F7BB0 File Offset: 0x006F5DB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QrBarcodeColumn As DataColumn
				Get
					Return Me.columnQrBarcode
				End Get
			End Property

			' Token: 0x17003F16 RID: 16150
			' (get) Token: 0x0600A262 RID: 41570 RVA: 0x006F7BC8 File Offset: 0x006F5DC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SuplNameColumn As DataColumn
				Get
					Return Me.columnSuplName
				End Get
			End Property

			' Token: 0x17003F17 RID: 16151
			' (get) Token: 0x0600A263 RID: 41571 RVA: 0x006F7BE0 File Offset: 0x006F5DE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TocknNoColumn As DataColumn
				Get
					Return Me.columnTocknNo
				End Get
			End Property

			' Token: 0x17003F18 RID: 16152
			' (get) Token: 0x0600A264 RID: 41572 RVA: 0x006F7BF8 File Offset: 0x006F5DF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PIDColumn As DataColumn
				Get
					Return Me.columnPID
				End Get
			End Property

			' Token: 0x17003F19 RID: 16153
			' (get) Token: 0x0600A265 RID: 41573 RVA: 0x006F7C10 File Offset: 0x006F5E10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PStatusColumn As DataColumn
				Get
					Return Me.columnPStatus
				End Get
			End Property

			' Token: 0x17003F1A RID: 16154
			' (get) Token: 0x0600A266 RID: 41574 RVA: 0x006F7C28 File Offset: 0x006F5E28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property T_QtyColumn As DataColumn
				Get
					Return Me.columnT_Qty
				End Get
			End Property

			' Token: 0x17003F1B RID: 16155
			' (get) Token: 0x0600A267 RID: 41575 RVA: 0x006F7C40 File Offset: 0x006F5E40
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PAdminColumn As DataColumn
				Get
					Return Me.columnPAdmin
				End Get
			End Property

			' Token: 0x17003F1C RID: 16156
			' (get) Token: 0x0600A268 RID: 41576 RVA: 0x006F7C58 File Offset: 0x006F5E58
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PBranchFromColumn As DataColumn
				Get
					Return Me.columnPBranchFrom
				End Get
			End Property

			' Token: 0x17003F1D RID: 16157
			' (get) Token: 0x0600A269 RID: 41577 RVA: 0x006F7C70 File Offset: 0x006F5E70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PBranchToColumn As DataColumn
				Get
					Return Me.columnPBranchTo
				End Get
			End Property

			' Token: 0x17003F1E RID: 16158
			' (get) Token: 0x0600A26A RID: 41578 RVA: 0x006F7C88 File Offset: 0x006F5E88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RemarksColumn As DataColumn
				Get
					Return Me.columnRemarks
				End Get
			End Property

			' Token: 0x17003F1F RID: 16159
			' (get) Token: 0x0600A26B RID: 41579 RVA: 0x006F7CA0 File Offset: 0x006F5EA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PostDateColumn As DataColumn
				Get
					Return Me.columnPostDate
				End Get
			End Property

			' Token: 0x17003F20 RID: 16160
			' (get) Token: 0x0600A26C RID: 41580 RVA: 0x006F7CB8 File Offset: 0x006F5EB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property branchcodeColumn As DataColumn
				Get
					Return Me.columnbranchcode
				End Get
			End Property

			' Token: 0x17003F21 RID: 16161
			' (get) Token: 0x0600A26D RID: 41581 RVA: 0x006F7CD0 File Offset: 0x006F5ED0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CategoryColumn As DataColumn
				Get
					Return Me.columnCategory
				End Get
			End Property

			' Token: 0x17003F22 RID: 16162
			' (get) Token: 0x0600A26E RID: 41582 RVA: 0x006F7CE8 File Offset: 0x006F5EE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SubCategoryNameColumn As DataColumn
				Get
					Return Me.columnSubCategoryName
				End Get
			End Property

			' Token: 0x17003F23 RID: 16163
			' (get) Token: 0x0600A26F RID: 41583 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17003F24 RID: 16164
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As BarcodeDataSet.P_TransferRow
				Get
					Return CType(MyBase.Rows(index), BarcodeDataSet.P_TransferRow)
				End Get
			End Property

			' Token: 0x14000038 RID: 56
			' (add) Token: 0x0600A271 RID: 41585 RVA: 0x006F7D24 File Offset: 0x006F5F24
			' (remove) Token: 0x0600A272 RID: 41586 RVA: 0x006F7D5C File Offset: 0x006F5F5C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event P_TransferRowChanging As BarcodeDataSet.P_TransferRowChangeEventHandler

			' Token: 0x14000039 RID: 57
			' (add) Token: 0x0600A273 RID: 41587 RVA: 0x006F7D94 File Offset: 0x006F5F94
			' (remove) Token: 0x0600A274 RID: 41588 RVA: 0x006F7DCC File Offset: 0x006F5FCC
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event P_TransferRowChanged As BarcodeDataSet.P_TransferRowChangeEventHandler

			' Token: 0x1400003A RID: 58
			' (add) Token: 0x0600A275 RID: 41589 RVA: 0x006F7E04 File Offset: 0x006F6004
			' (remove) Token: 0x0600A276 RID: 41590 RVA: 0x006F7E3C File Offset: 0x006F603C
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event P_TransferRowDeleting As BarcodeDataSet.P_TransferRowChangeEventHandler

			' Token: 0x1400003B RID: 59
			' (add) Token: 0x0600A277 RID: 41591 RVA: 0x006F7E74 File Offset: 0x006F6074
			' (remove) Token: 0x0600A278 RID: 41592 RVA: 0x006F7EAC File Offset: 0x006F60AC
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event P_TransferRowDeleted As BarcodeDataSet.P_TransferRowChangeEventHandler

			' Token: 0x0600A279 RID: 41593 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddP_TransferRow(row As BarcodeDataSet.P_TransferRow)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600A27A RID: 41594 RVA: 0x006F7EE4 File Offset: 0x006F60E4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddP_TransferRow(ID As String, ProductCode As String, Barcode As String, Productname As String, HSNCode As String, PartNo As String, Description As String, CostPrice As Double, MRP As Double, SellingPrice As Double, ReorderPoint As Double, Discount As Double, CGST As Double, SGST As Double, CESS As Double, PurchaseUnit As String, Salesunit As String, SalesAltUnit As String, Conv As String, MinStock As String, GDown As String, Rack As String, DefQty As Double, PPrice As Double, Temp_StockMRP As Double, SPrice As Double, WPrice As Double, Batch As String, Mfgdate As String, Expdate As String, Colour As String, Size As String, IMEI1 As String, IMEI2 As String, Status As String, QrBarcode As String, SuplName As String, TocknNo As String, PID As String, PStatus As String, T_Qty As Double, PAdmin As String, PBranchFrom As String, PBranchTo As String, Remarks As String, PostDate As String, branchcode As String, Category As String, SubCategoryName As String) As BarcodeDataSet.P_TransferRow
				Dim p_TransferRow As BarcodeDataSet.P_TransferRow = CType(MyBase.NewRow(), BarcodeDataSet.P_TransferRow)
				Dim array As Object() = New Object() { ID, ProductCode, Barcode, Productname, HSNCode, PartNo, Description, CostPrice, MRP, SellingPrice, ReorderPoint, Discount, CGST, SGST, CESS, PurchaseUnit, Salesunit, SalesAltUnit, Conv, MinStock, GDown, Rack, DefQty, PPrice, Temp_StockMRP, SPrice, WPrice, Batch, Mfgdate, Expdate, Colour, Size, IMEI1, IMEI2, Status, QrBarcode, SuplName, TocknNo, PID, PStatus, T_Qty, PAdmin, PBranchFrom, PBranchTo, Remarks, PostDate, branchcode, Category, SubCategoryName }
				p_TransferRow.ItemArray = array
				MyBase.Rows.Add(p_TransferRow)
				Return p_TransferRow
			End Function

			' Token: 0x0600A27B RID: 41595 RVA: 0x006F8080 File Offset: 0x006F6280
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim p_TransferDataTable As BarcodeDataSet.P_TransferDataTable = CType(MyBase.Clone(), BarcodeDataSet.P_TransferDataTable)
				p_TransferDataTable.InitVars()
				Return p_TransferDataTable
			End Function

			' Token: 0x0600A27C RID: 41596 RVA: 0x006F80A8 File Offset: 0x006F62A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New BarcodeDataSet.P_TransferDataTable()
			End Function

			' Token: 0x0600A27D RID: 41597 RVA: 0x006F80C0 File Offset: 0x006F62C0
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

			' Token: 0x0600A27E RID: 41598 RVA: 0x006F8504 File Offset: 0x006F6704
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
				Me.columnQrBarcode = New DataColumn("QrBarcode", GetType(String), Nothing, MappingType.Element)
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

			' Token: 0x0600A27F RID: 41599 RVA: 0x006F8DE0 File Offset: 0x006F6FE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewP_TransferRow() As BarcodeDataSet.P_TransferRow
				Return CType(MyBase.NewRow(), BarcodeDataSet.P_TransferRow)
			End Function

			' Token: 0x0600A280 RID: 41600 RVA: 0x006F8E00 File Offset: 0x006F7000
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New BarcodeDataSet.P_TransferRow(builder)
			End Function

			' Token: 0x0600A281 RID: 41601 RVA: 0x006F8E18 File Offset: 0x006F7018
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(BarcodeDataSet.P_TransferRow)
			End Function

			' Token: 0x0600A282 RID: 41602 RVA: 0x006F8E34 File Offset: 0x006F7034
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.P_TransferRowChangedEvent IsNot Nothing
				If flag Then
					Dim p_TransferRowChangedEvent As BarcodeDataSet.P_TransferRowChangeEventHandler = Me.P_TransferRowChangedEvent
					If p_TransferRowChangedEvent IsNot Nothing Then
						p_TransferRowChangedEvent(Me, New BarcodeDataSet.P_TransferRowChangeEvent(CType(e.Row, BarcodeDataSet.P_TransferRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A283 RID: 41603 RVA: 0x006F8E84 File Offset: 0x006F7084
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.P_TransferRowChangingEvent IsNot Nothing
				If flag Then
					Dim p_TransferRowChangingEvent As BarcodeDataSet.P_TransferRowChangeEventHandler = Me.P_TransferRowChangingEvent
					If p_TransferRowChangingEvent IsNot Nothing Then
						p_TransferRowChangingEvent(Me, New BarcodeDataSet.P_TransferRowChangeEvent(CType(e.Row, BarcodeDataSet.P_TransferRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A284 RID: 41604 RVA: 0x006F8ED4 File Offset: 0x006F70D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.P_TransferRowDeletedEvent IsNot Nothing
				If flag Then
					Dim p_TransferRowDeletedEvent As BarcodeDataSet.P_TransferRowChangeEventHandler = Me.P_TransferRowDeletedEvent
					If p_TransferRowDeletedEvent IsNot Nothing Then
						p_TransferRowDeletedEvent(Me, New BarcodeDataSet.P_TransferRowChangeEvent(CType(e.Row, BarcodeDataSet.P_TransferRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A285 RID: 41605 RVA: 0x006F8F24 File Offset: 0x006F7124
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.P_TransferRowDeletingEvent IsNot Nothing
				If flag Then
					Dim p_TransferRowDeletingEvent As BarcodeDataSet.P_TransferRowChangeEventHandler = Me.P_TransferRowDeletingEvent
					If p_TransferRowDeletingEvent IsNot Nothing Then
						p_TransferRowDeletingEvent(Me, New BarcodeDataSet.P_TransferRowChangeEvent(CType(e.Row, BarcodeDataSet.P_TransferRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A286 RID: 41606 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveP_TransferRow(row As BarcodeDataSet.P_TransferRow)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600A287 RID: 41607 RVA: 0x006F8F74 File Offset: 0x006F7174
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim barcodeDataSet As BarcodeDataSet = New BarcodeDataSet()
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
				xmlSchemaAttribute.FixedValue = barcodeDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "P_TransferDataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = barcodeDataSet.GetSchemaSerializable()
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

			' Token: 0x04004521 RID: 17697
			Private columnID As DataColumn

			' Token: 0x04004522 RID: 17698
			Private columnProductCode As DataColumn

			' Token: 0x04004523 RID: 17699
			Private columnBarcode As DataColumn

			' Token: 0x04004524 RID: 17700
			Private columnProductname As DataColumn

			' Token: 0x04004525 RID: 17701
			Private columnHSNCode As DataColumn

			' Token: 0x04004526 RID: 17702
			Private columnPartNo As DataColumn

			' Token: 0x04004527 RID: 17703
			Private columnDescription As DataColumn

			' Token: 0x04004528 RID: 17704
			Private columnCostPrice As DataColumn

			' Token: 0x04004529 RID: 17705
			Private columnMRP As DataColumn

			' Token: 0x0400452A RID: 17706
			Private columnSellingPrice As DataColumn

			' Token: 0x0400452B RID: 17707
			Private columnReorderPoint As DataColumn

			' Token: 0x0400452C RID: 17708
			Private columnDiscount As DataColumn

			' Token: 0x0400452D RID: 17709
			Private columnCGST As DataColumn

			' Token: 0x0400452E RID: 17710
			Private columnSGST As DataColumn

			' Token: 0x0400452F RID: 17711
			Private columnCESS As DataColumn

			' Token: 0x04004530 RID: 17712
			Private columnPurchaseUnit As DataColumn

			' Token: 0x04004531 RID: 17713
			Private columnSalesunit As DataColumn

			' Token: 0x04004532 RID: 17714
			Private columnSalesAltUnit As DataColumn

			' Token: 0x04004533 RID: 17715
			Private columnConv As DataColumn

			' Token: 0x04004534 RID: 17716
			Private columnMinStock As DataColumn

			' Token: 0x04004535 RID: 17717
			Private columnGDown As DataColumn

			' Token: 0x04004536 RID: 17718
			Private columnRack As DataColumn

			' Token: 0x04004537 RID: 17719
			Private columnDefQty As DataColumn

			' Token: 0x04004538 RID: 17720
			Private columnPPrice As DataColumn

			' Token: 0x04004539 RID: 17721
			Private columnTemp_StockMRP As DataColumn

			' Token: 0x0400453A RID: 17722
			Private columnSPrice As DataColumn

			' Token: 0x0400453B RID: 17723
			Private columnWPrice As DataColumn

			' Token: 0x0400453C RID: 17724
			Private columnBatch As DataColumn

			' Token: 0x0400453D RID: 17725
			Private columnMfgdate As DataColumn

			' Token: 0x0400453E RID: 17726
			Private columnExpdate As DataColumn

			' Token: 0x0400453F RID: 17727
			Private columnColour As DataColumn

			' Token: 0x04004540 RID: 17728
			Private columnSize As DataColumn

			' Token: 0x04004541 RID: 17729
			Private columnIMEI1 As DataColumn

			' Token: 0x04004542 RID: 17730
			Private columnIMEI2 As DataColumn

			' Token: 0x04004543 RID: 17731
			Private columnStatus As DataColumn

			' Token: 0x04004544 RID: 17732
			Private columnQrBarcode As DataColumn

			' Token: 0x04004545 RID: 17733
			Private columnSuplName As DataColumn

			' Token: 0x04004546 RID: 17734
			Private columnTocknNo As DataColumn

			' Token: 0x04004547 RID: 17735
			Private columnPID As DataColumn

			' Token: 0x04004548 RID: 17736
			Private columnPStatus As DataColumn

			' Token: 0x04004549 RID: 17737
			Private columnT_Qty As DataColumn

			' Token: 0x0400454A RID: 17738
			Private columnPAdmin As DataColumn

			' Token: 0x0400454B RID: 17739
			Private columnPBranchFrom As DataColumn

			' Token: 0x0400454C RID: 17740
			Private columnPBranchTo As DataColumn

			' Token: 0x0400454D RID: 17741
			Private columnRemarks As DataColumn

			' Token: 0x0400454E RID: 17742
			Private columnPostDate As DataColumn

			' Token: 0x0400454F RID: 17743
			Private columnbranchcode As DataColumn

			' Token: 0x04004550 RID: 17744
			Private columnCategory As DataColumn

			' Token: 0x04004551 RID: 17745
			Private columnSubCategoryName As DataColumn
		End Class

		' Token: 0x0200025D RID: 605
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable11DataTable
			Inherits TypedTableBase(Of BarcodeDataSet.DataTable11Row)

			' Token: 0x0600A288 RID: 41608 RVA: 0x0004BD6E File Offset: 0x00049F6E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable11"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600A289 RID: 41609 RVA: 0x006F91C8 File Offset: 0x006F73C8
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

			' Token: 0x0600A28A RID: 41610 RVA: 0x0004BD99 File Offset: 0x00049F99
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17003F25 RID: 16165
			' (get) Token: 0x0600A28B RID: 41611 RVA: 0x006F9294 File Offset: 0x006F7494
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductIDColumn As DataColumn
				Get
					Return Me.columnProductID
				End Get
			End Property

			' Token: 0x17003F26 RID: 16166
			' (get) Token: 0x0600A28C RID: 41612 RVA: 0x006F92AC File Offset: 0x006F74AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QtyColumn As DataColumn
				Get
					Return Me.columnQty
				End Get
			End Property

			' Token: 0x17003F27 RID: 16167
			' (get) Token: 0x0600A28D RID: 41613 RVA: 0x006F92C4 File Offset: 0x006F74C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MainUnitColumn As DataColumn
				Get
					Return Me.columnMainUnit
				End Get
			End Property

			' Token: 0x17003F28 RID: 16168
			' (get) Token: 0x0600A28E RID: 41614 RVA: 0x006F92DC File Offset: 0x006F74DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalesRateColumn As DataColumn
				Get
					Return Me.columnSalesRate
				End Get
			End Property

			' Token: 0x17003F29 RID: 16169
			' (get) Token: 0x0600A28F RID: 41615 RVA: 0x006F92F4 File Offset: 0x006F74F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountPerColumn As DataColumn
				Get
					Return Me.columnDiscountPer
				End Get
			End Property

			' Token: 0x17003F2A RID: 16170
			' (get) Token: 0x0600A290 RID: 41616 RVA: 0x006F930C File Offset: 0x006F750C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscountColumn As DataColumn
				Get
					Return Me.columnDiscount
				End Get
			End Property

			' Token: 0x17003F2B RID: 16171
			' (get) Token: 0x0600A291 RID: 41617 RVA: 0x006F9324 File Offset: 0x006F7524
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TotalAmountColumn As DataColumn
				Get
					Return Me.columnTotalAmount
				End Get
			End Property

			' Token: 0x17003F2C RID: 16172
			' (get) Token: 0x0600A292 RID: 41618 RVA: 0x006F933C File Offset: 0x006F753C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TotalMRPColumn As DataColumn
				Get
					Return Me.columnTotalMRP
				End Get
			End Property

			' Token: 0x17003F2D RID: 16173
			' (get) Token: 0x0600A293 RID: 41619 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17003F2E RID: 16174
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As BarcodeDataSet.DataTable11Row
				Get
					Return CType(MyBase.Rows(index), BarcodeDataSet.DataTable11Row)
				End Get
			End Property

			' Token: 0x1400003C RID: 60
			' (add) Token: 0x0600A295 RID: 41621 RVA: 0x006F9378 File Offset: 0x006F7578
			' (remove) Token: 0x0600A296 RID: 41622 RVA: 0x006F93B0 File Offset: 0x006F75B0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable11RowChanging As BarcodeDataSet.DataTable11RowChangeEventHandler

			' Token: 0x1400003D RID: 61
			' (add) Token: 0x0600A297 RID: 41623 RVA: 0x006F93E8 File Offset: 0x006F75E8
			' (remove) Token: 0x0600A298 RID: 41624 RVA: 0x006F9420 File Offset: 0x006F7620
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable11RowChanged As BarcodeDataSet.DataTable11RowChangeEventHandler

			' Token: 0x1400003E RID: 62
			' (add) Token: 0x0600A299 RID: 41625 RVA: 0x006F9458 File Offset: 0x006F7658
			' (remove) Token: 0x0600A29A RID: 41626 RVA: 0x006F9490 File Offset: 0x006F7690
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable11RowDeleting As BarcodeDataSet.DataTable11RowChangeEventHandler

			' Token: 0x1400003F RID: 63
			' (add) Token: 0x0600A29B RID: 41627 RVA: 0x006F94C8 File Offset: 0x006F76C8
			' (remove) Token: 0x0600A29C RID: 41628 RVA: 0x006F9500 File Offset: 0x006F7700
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable11RowDeleted As BarcodeDataSet.DataTable11RowChangeEventHandler

			' Token: 0x0600A29D RID: 41629 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable11Row(row As BarcodeDataSet.DataTable11Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600A29E RID: 41630 RVA: 0x006F9538 File Offset: 0x006F7738
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable11Row(ProductID As String, Qty As Double, MainUnit As String, SalesRate As Double, DiscountPer As Double, Discount As Double, TotalAmount As Double, TotalMRP As Double) As BarcodeDataSet.DataTable11Row
				Dim dataTable11Row As BarcodeDataSet.DataTable11Row = CType(MyBase.NewRow(), BarcodeDataSet.DataTable11Row)
				Dim array As Object() = New Object() { ProductID, Qty, MainUnit, SalesRate, DiscountPer, Discount, TotalAmount, TotalMRP }
				dataTable11Row.ItemArray = array
				MyBase.Rows.Add(dataTable11Row)
				Return dataTable11Row
			End Function

			' Token: 0x0600A29F RID: 41631 RVA: 0x006F95B8 File Offset: 0x006F77B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable11DataTable As BarcodeDataSet.DataTable11DataTable = CType(MyBase.Clone(), BarcodeDataSet.DataTable11DataTable)
				dataTable11DataTable.InitVars()
				Return dataTable11DataTable
			End Function

			' Token: 0x0600A2A0 RID: 41632 RVA: 0x006F95E0 File Offset: 0x006F77E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New BarcodeDataSet.DataTable11DataTable()
			End Function

			' Token: 0x0600A2A1 RID: 41633 RVA: 0x006F95F8 File Offset: 0x006F77F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnProductID = MyBase.Columns("ProductID")
				Me.columnQty = MyBase.Columns("Qty")
				Me.columnMainUnit = MyBase.Columns("MainUnit")
				Me.columnSalesRate = MyBase.Columns("SalesRate")
				Me.columnDiscountPer = MyBase.Columns("DiscountPer")
				Me.columnDiscount = MyBase.Columns("Discount")
				Me.columnTotalAmount = MyBase.Columns("TotalAmount")
				Me.columnTotalMRP = MyBase.Columns("TotalMRP")
			End Sub

			' Token: 0x0600A2A2 RID: 41634 RVA: 0x006F96B8 File Offset: 0x006F78B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnProductID = New DataColumn("ProductID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductID)
				Me.columnQty = New DataColumn("Qty", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQty)
				Me.columnMainUnit = New DataColumn("MainUnit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMainUnit)
				Me.columnSalesRate = New DataColumn("SalesRate", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSalesRate)
				Me.columnDiscountPer = New DataColumn("DiscountPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscountPer)
				Me.columnDiscount = New DataColumn("Discount", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscount)
				Me.columnTotalAmount = New DataColumn("TotalAmount", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTotalAmount)
				Me.columnTotalMRP = New DataColumn("TotalMRP", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTotalMRP)
				Me.columnProductID.Caption = "ProductName"
				Me.columnQty.Caption = "SalePrice"
				Me.columnMainUnit.Caption = "GST"
				Me.columnSalesRate.Caption = "PurInv"
				Me.columnDiscountPer.Caption = "IMEI1"
				Me.columnDiscount.Caption = "IMEI2"
				Me.columnTotalAmount.Caption = "QrBarcode"
				Me.columnTotalMRP.Caption = "CBarcode"
			End Sub

			' Token: 0x0600A2A3 RID: 41635 RVA: 0x006F98C0 File Offset: 0x006F7AC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable11Row() As BarcodeDataSet.DataTable11Row
				Return CType(MyBase.NewRow(), BarcodeDataSet.DataTable11Row)
			End Function

			' Token: 0x0600A2A4 RID: 41636 RVA: 0x006F98E0 File Offset: 0x006F7AE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New BarcodeDataSet.DataTable11Row(builder)
			End Function

			' Token: 0x0600A2A5 RID: 41637 RVA: 0x006F98F8 File Offset: 0x006F7AF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(BarcodeDataSet.DataTable11Row)
			End Function

			' Token: 0x0600A2A6 RID: 41638 RVA: 0x006F9914 File Offset: 0x006F7B14
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable11RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable11RowChangedEvent As BarcodeDataSet.DataTable11RowChangeEventHandler = Me.DataTable11RowChangedEvent
					If dataTable11RowChangedEvent IsNot Nothing Then
						dataTable11RowChangedEvent(Me, New BarcodeDataSet.DataTable11RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable11Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A2A7 RID: 41639 RVA: 0x006F9964 File Offset: 0x006F7B64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable11RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable11RowChangingEvent As BarcodeDataSet.DataTable11RowChangeEventHandler = Me.DataTable11RowChangingEvent
					If dataTable11RowChangingEvent IsNot Nothing Then
						dataTable11RowChangingEvent(Me, New BarcodeDataSet.DataTable11RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable11Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A2A8 RID: 41640 RVA: 0x006F99B4 File Offset: 0x006F7BB4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable11RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable11RowDeletedEvent As BarcodeDataSet.DataTable11RowChangeEventHandler = Me.DataTable11RowDeletedEvent
					If dataTable11RowDeletedEvent IsNot Nothing Then
						dataTable11RowDeletedEvent(Me, New BarcodeDataSet.DataTable11RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable11Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A2A9 RID: 41641 RVA: 0x006F9A04 File Offset: 0x006F7C04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable11RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable11RowDeletingEvent As BarcodeDataSet.DataTable11RowChangeEventHandler = Me.DataTable11RowDeletingEvent
					If dataTable11RowDeletingEvent IsNot Nothing Then
						dataTable11RowDeletingEvent(Me, New BarcodeDataSet.DataTable11RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable11Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A2AA RID: 41642 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable11Row(row As BarcodeDataSet.DataTable11Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600A2AB RID: 41643 RVA: 0x006F9A54 File Offset: 0x006F7C54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim barcodeDataSet As BarcodeDataSet = New BarcodeDataSet()
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
				xmlSchemaAttribute.FixedValue = barcodeDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable11DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = barcodeDataSet.GetSchemaSerializable()
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

			' Token: 0x04004556 RID: 17750
			Private columnProductID As DataColumn

			' Token: 0x04004557 RID: 17751
			Private columnQty As DataColumn

			' Token: 0x04004558 RID: 17752
			Private columnMainUnit As DataColumn

			' Token: 0x04004559 RID: 17753
			Private columnSalesRate As DataColumn

			' Token: 0x0400455A RID: 17754
			Private columnDiscountPer As DataColumn

			' Token: 0x0400455B RID: 17755
			Private columnDiscount As DataColumn

			' Token: 0x0400455C RID: 17756
			Private columnTotalAmount As DataColumn

			' Token: 0x0400455D RID: 17757
			Private columnTotalMRP As DataColumn
		End Class

		' Token: 0x0200025E RID: 606
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class SaleDDataTable
			Inherits TypedTableBase(Of BarcodeDataSet.SaleDRow)

			' Token: 0x0600A2AC RID: 41644 RVA: 0x0004BDAC File Offset: 0x00049FAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "SaleD"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600A2AD RID: 41645 RVA: 0x006F9CA8 File Offset: 0x006F7EA8
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

			' Token: 0x0600A2AE RID: 41646 RVA: 0x0004BDD7 File Offset: 0x00049FD7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17003F2F RID: 16175
			' (get) Token: 0x0600A2AF RID: 41647 RVA: 0x006F9D74 File Offset: 0x006F7F74
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PCodeColumn As DataColumn
				Get
					Return Me.columnPCode
				End Get
			End Property

			' Token: 0x17003F30 RID: 16176
			' (get) Token: 0x0600A2B0 RID: 41648 RVA: 0x006F9D8C File Offset: 0x006F7F8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductNameColumn As DataColumn
				Get
					Return Me.columnProductName
				End Get
			End Property

			' Token: 0x17003F31 RID: 16177
			' (get) Token: 0x0600A2B1 RID: 41649 RVA: 0x006F9DA4 File Offset: 0x006F7FA4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CategoryColumn As DataColumn
				Get
					Return Me.columnCategory
				End Get
			End Property

			' Token: 0x17003F32 RID: 16178
			' (get) Token: 0x0600A2B2 RID: 41650 RVA: 0x006F9DBC File Offset: 0x006F7FBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x17003F33 RID: 16179
			' (get) Token: 0x0600A2B3 RID: 41651 RVA: 0x006F9DD4 File Offset: 0x006F7FD4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AvlQtyColumn As DataColumn
				Get
					Return Me.columnAvlQty
				End Get
			End Property

			' Token: 0x17003F34 RID: 16180
			' (get) Token: 0x0600A2B4 RID: 41652 RVA: 0x006F9DEC File Offset: 0x006F7FEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property NoCopyColumn As DataColumn
				Get
					Return Me.columnNoCopy
				End Get
			End Property

			' Token: 0x17003F35 RID: 16181
			' (get) Token: 0x0600A2B5 RID: 41653 RVA: 0x006F9E04 File Offset: 0x006F8004
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PartNoColumn As DataColumn
				Get
					Return Me.columnPartNo
				End Get
			End Property

			' Token: 0x17003F36 RID: 16182
			' (get) Token: 0x0600A2B6 RID: 41654 RVA: 0x006F9E1C File Offset: 0x006F801C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCColumn As DataColumn
				Get
					Return Me.columnHSNC
				End Get
			End Property

			' Token: 0x17003F37 RID: 16183
			' (get) Token: 0x0600A2B7 RID: 41655 RVA: 0x006F9E34 File Offset: 0x006F8034
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MRPColumn As DataColumn
				Get
					Return Me.columnMRP
				End Get
			End Property

			' Token: 0x17003F38 RID: 16184
			' (get) Token: 0x0600A2B8 RID: 41656 RVA: 0x006F9E4C File Offset: 0x006F804C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SalePriceColumn As DataColumn
				Get
					Return Me.columnSalePrice
				End Get
			End Property

			' Token: 0x17003F39 RID: 16185
			' (get) Token: 0x0600A2B9 RID: 41657 RVA: 0x006F9E64 File Offset: 0x006F8064
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property WholesalePriceColumn As DataColumn
				Get
					Return Me.columnWholesalePrice
				End Get
			End Property

			' Token: 0x17003F3A RID: 16186
			' (get) Token: 0x0600A2BA RID: 41658 RVA: 0x006F9E7C File Offset: 0x006F807C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BatchColumn As DataColumn
				Get
					Return Me.columnBatch
				End Get
			End Property

			' Token: 0x17003F3B RID: 16187
			' (get) Token: 0x0600A2BB RID: 41659 RVA: 0x006F9E94 File Offset: 0x006F8094
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MfgColumn As DataColumn
				Get
					Return Me.columnMfg
				End Get
			End Property

			' Token: 0x17003F3C RID: 16188
			' (get) Token: 0x0600A2BC RID: 41660 RVA: 0x006F9EAC File Offset: 0x006F80AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ExpColumn As DataColumn
				Get
					Return Me.columnExp
				End Get
			End Property

			' Token: 0x17003F3D RID: 16189
			' (get) Token: 0x0600A2BD RID: 41661 RVA: 0x006F9EC4 File Offset: 0x006F80C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SizeColumn As DataColumn
				Get
					Return Me.columnSize
				End Get
			End Property

			' Token: 0x17003F3E RID: 16190
			' (get) Token: 0x0600A2BE RID: 41662 RVA: 0x006F9EDC File Offset: 0x006F80DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ColourColumn As DataColumn
				Get
					Return Me.columnColour
				End Get
			End Property

			' Token: 0x17003F3F RID: 16191
			' (get) Token: 0x0600A2BF RID: 41663 RVA: 0x006F9EF4 File Offset: 0x006F80F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property GSTColumn As DataColumn
				Get
					Return Me.columnGST
				End Get
			End Property

			' Token: 0x17003F40 RID: 16192
			' (get) Token: 0x0600A2C0 RID: 41664 RVA: 0x006F9F0C File Offset: 0x006F810C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PurInvColumn As DataColumn
				Get
					Return Me.columnPurInv
				End Get
			End Property

			' Token: 0x17003F41 RID: 16193
			' (get) Token: 0x0600A2C1 RID: 41665 RVA: 0x006F9F24 File Offset: 0x006F8124
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IMEI1Column As DataColumn
				Get
					Return Me.columnIMEI1
				End Get
			End Property

			' Token: 0x17003F42 RID: 16194
			' (get) Token: 0x0600A2C2 RID: 41666 RVA: 0x006F9F3C File Offset: 0x006F813C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IMEI2Column As DataColumn
				Get
					Return Me.columnIMEI2
				End Get
			End Property

			' Token: 0x17003F43 RID: 16195
			' (get) Token: 0x0600A2C3 RID: 41667 RVA: 0x006F9F54 File Offset: 0x006F8154
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property QrBarcodeColumn As DataColumn
				Get
					Return Me.columnQrBarcode
				End Get
			End Property

			' Token: 0x17003F44 RID: 16196
			' (get) Token: 0x0600A2C4 RID: 41668 RVA: 0x006F9F6C File Offset: 0x006F816C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CBarcodeColumn As DataColumn
				Get
					Return Me.columnCBarcode
				End Get
			End Property

			' Token: 0x17003F45 RID: 16197
			' (get) Token: 0x0600A2C5 RID: 41669 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17003F46 RID: 16198
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As BarcodeDataSet.SaleDRow
				Get
					Return CType(MyBase.Rows(index), BarcodeDataSet.SaleDRow)
				End Get
			End Property

			' Token: 0x14000040 RID: 64
			' (add) Token: 0x0600A2C7 RID: 41671 RVA: 0x006F9FA8 File Offset: 0x006F81A8
			' (remove) Token: 0x0600A2C8 RID: 41672 RVA: 0x006F9FE0 File Offset: 0x006F81E0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event SaleDRowChanging As BarcodeDataSet.SaleDRowChangeEventHandler

			' Token: 0x14000041 RID: 65
			' (add) Token: 0x0600A2C9 RID: 41673 RVA: 0x006FA018 File Offset: 0x006F8218
			' (remove) Token: 0x0600A2CA RID: 41674 RVA: 0x006FA050 File Offset: 0x006F8250
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event SaleDRowChanged As BarcodeDataSet.SaleDRowChangeEventHandler

			' Token: 0x14000042 RID: 66
			' (add) Token: 0x0600A2CB RID: 41675 RVA: 0x006FA088 File Offset: 0x006F8288
			' (remove) Token: 0x0600A2CC RID: 41676 RVA: 0x006FA0C0 File Offset: 0x006F82C0
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event SaleDRowDeleting As BarcodeDataSet.SaleDRowChangeEventHandler

			' Token: 0x14000043 RID: 67
			' (add) Token: 0x0600A2CD RID: 41677 RVA: 0x006FA0F8 File Offset: 0x006F82F8
			' (remove) Token: 0x0600A2CE RID: 41678 RVA: 0x006FA130 File Offset: 0x006F8330
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event SaleDRowDeleted As BarcodeDataSet.SaleDRowChangeEventHandler

			' Token: 0x0600A2CF RID: 41679 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddSaleDRow(row As BarcodeDataSet.SaleDRow)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600A2D0 RID: 41680 RVA: 0x006FA168 File Offset: 0x006F8368
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddSaleDRow(PCode As String, ProductName As String, Category As String, Barcode As String, AvlQty As String, NoCopy As String, PartNo As String, HSNC As String, MRP As String, SalePrice As String, WholesalePrice As String, Batch As String, Mfg As String, Exp As String, Size As String, Colour As String, GST As String, PurInv As String, IMEI1 As String, IMEI2 As String, QrBarcode As Byte(), CBarcode As String) As BarcodeDataSet.SaleDRow
				Dim saleDRow As BarcodeDataSet.SaleDRow = CType(MyBase.NewRow(), BarcodeDataSet.SaleDRow)
				Dim array As Object() = New Object() { PCode, ProductName, Category, Barcode, AvlQty, NoCopy, PartNo, HSNC, MRP, SalePrice, WholesalePrice, Batch, Mfg, Exp, Size, Colour, GST, PurInv, IMEI1, IMEI2, QrBarcode, CBarcode }
				saleDRow.ItemArray = array
				MyBase.Rows.Add(saleDRow)
				Return saleDRow
			End Function

			' Token: 0x0600A2D1 RID: 41681 RVA: 0x006FA21C File Offset: 0x006F841C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim saleDDataTable As BarcodeDataSet.SaleDDataTable = CType(MyBase.Clone(), BarcodeDataSet.SaleDDataTable)
				saleDDataTable.InitVars()
				Return saleDDataTable
			End Function

			' Token: 0x0600A2D2 RID: 41682 RVA: 0x006FA244 File Offset: 0x006F8444
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New BarcodeDataSet.SaleDDataTable()
			End Function

			' Token: 0x0600A2D3 RID: 41683 RVA: 0x006FA25C File Offset: 0x006F845C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnPCode = MyBase.Columns("PCode")
				Me.columnProductName = MyBase.Columns("ProductName")
				Me.columnCategory = MyBase.Columns("Category")
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnAvlQty = MyBase.Columns("AvlQty")
				Me.columnNoCopy = MyBase.Columns("NoCopy")
				Me.columnPartNo = MyBase.Columns("PartNo")
				Me.columnHSNC = MyBase.Columns("HSNC")
				Me.columnMRP = MyBase.Columns("MRP")
				Me.columnSalePrice = MyBase.Columns("SalePrice")
				Me.columnWholesalePrice = MyBase.Columns("WholesalePrice")
				Me.columnBatch = MyBase.Columns("Batch")
				Me.columnMfg = MyBase.Columns("Mfg")
				Me.columnExp = MyBase.Columns("Exp")
				Me.columnSize = MyBase.Columns("Size")
				Me.columnColour = MyBase.Columns("Colour")
				Me.columnGST = MyBase.Columns("GST")
				Me.columnPurInv = MyBase.Columns("PurInv")
				Me.columnIMEI1 = MyBase.Columns("IMEI1")
				Me.columnIMEI2 = MyBase.Columns("IMEI2")
				Me.columnQrBarcode = MyBase.Columns("QrBarcode")
				Me.columnCBarcode = MyBase.Columns("CBarcode")
			End Sub

			' Token: 0x0600A2D4 RID: 41684 RVA: 0x006FA450 File Offset: 0x006F8650
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnPCode = New DataColumn("PCode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPCode)
				Me.columnProductName = New DataColumn("ProductName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductName)
				Me.columnCategory = New DataColumn("Category", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCategory)
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnAvlQty = New DataColumn("AvlQty", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAvlQty)
				Me.columnNoCopy = New DataColumn("NoCopy", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnNoCopy)
				Me.columnPartNo = New DataColumn("PartNo", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPartNo)
				Me.columnHSNC = New DataColumn("HSNC", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnHSNC)
				Me.columnMRP = New DataColumn("MRP", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMRP)
				Me.columnSalePrice = New DataColumn("SalePrice", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSalePrice)
				Me.columnWholesalePrice = New DataColumn("WholesalePrice", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnWholesalePrice)
				Me.columnBatch = New DataColumn("Batch", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBatch)
				Me.columnMfg = New DataColumn("Mfg", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMfg)
				Me.columnExp = New DataColumn("Exp", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnExp)
				Me.columnSize = New DataColumn("Size", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSize)
				Me.columnColour = New DataColumn("Colour", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnColour)
				Me.columnGST = New DataColumn("GST", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnGST)
				Me.columnPurInv = New DataColumn("PurInv", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPurInv)
				Me.columnIMEI1 = New DataColumn("IMEI1", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIMEI1)
				Me.columnIMEI2 = New DataColumn("IMEI2", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIMEI2)
				Me.columnQrBarcode = New DataColumn("QrBarcode", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnQrBarcode)
				Me.columnCBarcode = New DataColumn("CBarcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCBarcode)
			End Sub

			' Token: 0x0600A2D5 RID: 41685 RVA: 0x006FA854 File Offset: 0x006F8A54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewSaleDRow() As BarcodeDataSet.SaleDRow
				Return CType(MyBase.NewRow(), BarcodeDataSet.SaleDRow)
			End Function

			' Token: 0x0600A2D6 RID: 41686 RVA: 0x006FA874 File Offset: 0x006F8A74
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New BarcodeDataSet.SaleDRow(builder)
			End Function

			' Token: 0x0600A2D7 RID: 41687 RVA: 0x006FA88C File Offset: 0x006F8A8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(BarcodeDataSet.SaleDRow)
			End Function

			' Token: 0x0600A2D8 RID: 41688 RVA: 0x006FA8A8 File Offset: 0x006F8AA8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.SaleDRowChangedEvent IsNot Nothing
				If flag Then
					Dim saleDRowChangedEvent As BarcodeDataSet.SaleDRowChangeEventHandler = Me.SaleDRowChangedEvent
					If saleDRowChangedEvent IsNot Nothing Then
						saleDRowChangedEvent(Me, New BarcodeDataSet.SaleDRowChangeEvent(CType(e.Row, BarcodeDataSet.SaleDRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A2D9 RID: 41689 RVA: 0x006FA8F8 File Offset: 0x006F8AF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.SaleDRowChangingEvent IsNot Nothing
				If flag Then
					Dim saleDRowChangingEvent As BarcodeDataSet.SaleDRowChangeEventHandler = Me.SaleDRowChangingEvent
					If saleDRowChangingEvent IsNot Nothing Then
						saleDRowChangingEvent(Me, New BarcodeDataSet.SaleDRowChangeEvent(CType(e.Row, BarcodeDataSet.SaleDRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A2DA RID: 41690 RVA: 0x006FA948 File Offset: 0x006F8B48
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.SaleDRowDeletedEvent IsNot Nothing
				If flag Then
					Dim saleDRowDeletedEvent As BarcodeDataSet.SaleDRowChangeEventHandler = Me.SaleDRowDeletedEvent
					If saleDRowDeletedEvent IsNot Nothing Then
						saleDRowDeletedEvent(Me, New BarcodeDataSet.SaleDRowChangeEvent(CType(e.Row, BarcodeDataSet.SaleDRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A2DB RID: 41691 RVA: 0x006FA998 File Offset: 0x006F8B98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.SaleDRowDeletingEvent IsNot Nothing
				If flag Then
					Dim saleDRowDeletingEvent As BarcodeDataSet.SaleDRowChangeEventHandler = Me.SaleDRowDeletingEvent
					If saleDRowDeletingEvent IsNot Nothing Then
						saleDRowDeletingEvent(Me, New BarcodeDataSet.SaleDRowChangeEvent(CType(e.Row, BarcodeDataSet.SaleDRow), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A2DC RID: 41692 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveSaleDRow(row As BarcodeDataSet.SaleDRow)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600A2DD RID: 41693 RVA: 0x006FA9E8 File Offset: 0x006F8BE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim barcodeDataSet As BarcodeDataSet = New BarcodeDataSet()
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
				xmlSchemaAttribute.FixedValue = barcodeDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "SaleDDataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = barcodeDataSet.GetSchemaSerializable()
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

			' Token: 0x04004562 RID: 17762
			Private columnPCode As DataColumn

			' Token: 0x04004563 RID: 17763
			Private columnProductName As DataColumn

			' Token: 0x04004564 RID: 17764
			Private columnCategory As DataColumn

			' Token: 0x04004565 RID: 17765
			Private columnBarcode As DataColumn

			' Token: 0x04004566 RID: 17766
			Private columnAvlQty As DataColumn

			' Token: 0x04004567 RID: 17767
			Private columnNoCopy As DataColumn

			' Token: 0x04004568 RID: 17768
			Private columnPartNo As DataColumn

			' Token: 0x04004569 RID: 17769
			Private columnHSNC As DataColumn

			' Token: 0x0400456A RID: 17770
			Private columnMRP As DataColumn

			' Token: 0x0400456B RID: 17771
			Private columnSalePrice As DataColumn

			' Token: 0x0400456C RID: 17772
			Private columnWholesalePrice As DataColumn

			' Token: 0x0400456D RID: 17773
			Private columnBatch As DataColumn

			' Token: 0x0400456E RID: 17774
			Private columnMfg As DataColumn

			' Token: 0x0400456F RID: 17775
			Private columnExp As DataColumn

			' Token: 0x04004570 RID: 17776
			Private columnSize As DataColumn

			' Token: 0x04004571 RID: 17777
			Private columnColour As DataColumn

			' Token: 0x04004572 RID: 17778
			Private columnGST As DataColumn

			' Token: 0x04004573 RID: 17779
			Private columnPurInv As DataColumn

			' Token: 0x04004574 RID: 17780
			Private columnIMEI1 As DataColumn

			' Token: 0x04004575 RID: 17781
			Private columnIMEI2 As DataColumn

			' Token: 0x04004576 RID: 17782
			Private columnQrBarcode As DataColumn

			' Token: 0x04004577 RID: 17783
			Private columnCBarcode As DataColumn
		End Class

		' Token: 0x0200025F RID: 607
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable3DataTable
			Inherits TypedTableBase(Of BarcodeDataSet.DataTable3Row)

			' Token: 0x0600A2DE RID: 41694 RVA: 0x0004BDEA File Offset: 0x00049FEA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable3"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600A2DF RID: 41695 RVA: 0x006FAC3C File Offset: 0x006F8E3C
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

			' Token: 0x0600A2E0 RID: 41696 RVA: 0x0004BE15 File Offset: 0x0004A015
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17003F47 RID: 16199
			' (get) Token: 0x0600A2E1 RID: 41697 RVA: 0x006FAD08 File Offset: 0x006F8F08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PIDColumn As DataColumn
				Get
					Return Me.columnPID
				End Get
			End Property

			' Token: 0x17003F48 RID: 16200
			' (get) Token: 0x0600A2E2 RID: 41698 RVA: 0x006FAD20 File Offset: 0x006F8F20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property HSNCColumn As DataColumn
				Get
					Return Me.columnHSNC
				End Get
			End Property

			' Token: 0x17003F49 RID: 16201
			' (get) Token: 0x0600A2E3 RID: 41699 RVA: 0x006FAD38 File Offset: 0x006F8F38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ProductNameColumn As DataColumn
				Get
					Return Me.columnProductName
				End Get
			End Property

			' Token: 0x17003F4A RID: 16202
			' (get) Token: 0x0600A2E4 RID: 41700 RVA: 0x006FAD50 File Offset: 0x006F8F50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property BarcodeColumn As DataColumn
				Get
					Return Me.columnBarcode
				End Get
			End Property

			' Token: 0x17003F4B RID: 16203
			' (get) Token: 0x0600A2E5 RID: 41701 RVA: 0x006FAD68 File Offset: 0x006F8F68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MainQtyColumn As DataColumn
				Get
					Return Me.columnMainQty
				End Get
			End Property

			' Token: 0x17003F4C RID: 16204
			' (get) Token: 0x0600A2E6 RID: 41702 RVA: 0x006FAD80 File Offset: 0x006F8F80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property RateColumn As DataColumn
				Get
					Return Me.columnRate
				End Get
			End Property

			' Token: 0x17003F4D RID: 16205
			' (get) Token: 0x0600A2E7 RID: 41703 RVA: 0x006FAD98 File Offset: 0x006F8F98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscPerColumn As DataColumn
				Get
					Return Me.columnDiscPer
				End Get
			End Property

			' Token: 0x17003F4E RID: 16206
			' (get) Token: 0x0600A2E8 RID: 41704 RVA: 0x006FADB0 File Offset: 0x006F8FB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property DiscColumn As DataColumn
				Get
					Return Me.columnDisc
				End Get
			End Property

			' Token: 0x17003F4F RID: 16207
			' (get) Token: 0x0600A2E9 RID: 41705 RVA: 0x006FADC8 File Offset: 0x006F8FC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTPerColumn As DataColumn
				Get
					Return Me.columnCGSTPer
				End Get
			End Property

			' Token: 0x17003F50 RID: 16208
			' (get) Token: 0x0600A2EA RID: 41706 RVA: 0x006FADE0 File Offset: 0x006F8FE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CGSTColumn As DataColumn
				Get
					Return Me.columnCGST
				End Get
			End Property

			' Token: 0x17003F51 RID: 16209
			' (get) Token: 0x0600A2EB RID: 41707 RVA: 0x006FADF8 File Offset: 0x006F8FF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTPerColumn As DataColumn
				Get
					Return Me.columnSGSTPer
				End Get
			End Property

			' Token: 0x17003F52 RID: 16210
			' (get) Token: 0x0600A2EC RID: 41708 RVA: 0x006FAE10 File Offset: 0x006F9010
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property SGSTColumn As DataColumn
				Get
					Return Me.columnSGST
				End Get
			End Property

			' Token: 0x17003F53 RID: 16211
			' (get) Token: 0x0600A2ED RID: 41709 RVA: 0x006FAE28 File Offset: 0x006F9028
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTPerColumn As DataColumn
				Get
					Return Me.columnIGSTPer
				End Get
			End Property

			' Token: 0x17003F54 RID: 16212
			' (get) Token: 0x0600A2EE RID: 41710 RVA: 0x006FAE40 File Offset: 0x006F9040
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property IGSTColumn As DataColumn
				Get
					Return Me.columnIGST
				End Get
			End Property

			' Token: 0x17003F55 RID: 16213
			' (get) Token: 0x0600A2EF RID: 41711 RVA: 0x006FAE58 File Offset: 0x006F9058
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSPerColumn As DataColumn
				Get
					Return Me.columnCESSPer
				End Get
			End Property

			' Token: 0x17003F56 RID: 16214
			' (get) Token: 0x0600A2F0 RID: 41712 RVA: 0x006FAE70 File Offset: 0x006F9070
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property CESSColumn As DataColumn
				Get
					Return Me.columnCESS
				End Get
			End Property

			' Token: 0x17003F57 RID: 16215
			' (get) Token: 0x0600A2F1 RID: 41713 RVA: 0x006FAE88 File Offset: 0x006F9088
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TotalColumn As DataColumn
				Get
					Return Me.columnTotal
				End Get
			End Property

			' Token: 0x17003F58 RID: 16216
			' (get) Token: 0x0600A2F2 RID: 41714 RVA: 0x006FAEA0 File Offset: 0x006F90A0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AltQtyColumn As DataColumn
				Get
					Return Me.columnAltQty
				End Get
			End Property

			' Token: 0x17003F59 RID: 16217
			' (get) Token: 0x0600A2F3 RID: 41715 RVA: 0x006FAEB8 File Offset: 0x006F90B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property AltUnitColumn As DataColumn
				Get
					Return Me.columnAltUnit
				End Get
			End Property

			' Token: 0x17003F5A RID: 16218
			' (get) Token: 0x0600A2F4 RID: 41716 RVA: 0x006FAED0 File Offset: 0x006F90D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TaxableAmtColumn As DataColumn
				Get
					Return Me.columnTaxableAmt
				End Get
			End Property

			' Token: 0x17003F5B RID: 16219
			' (get) Token: 0x0600A2F5 RID: 41717 RVA: 0x006FAEE8 File Offset: 0x006F90E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property MainUnitColumn As DataColumn
				Get
					Return Me.columnMainUnit
				End Get
			End Property

			' Token: 0x17003F5C RID: 16220
			' (get) Token: 0x0600A2F6 RID: 41718 RVA: 0x006FAF00 File Offset: 0x006F9100
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property PImageColumn As DataColumn
				Get
					Return Me.columnPImage
				End Get
			End Property

			' Token: 0x17003F5D RID: 16221
			' (get) Token: 0x0600A2F7 RID: 41719 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17003F5E RID: 16222
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As BarcodeDataSet.DataTable3Row
				Get
					Return CType(MyBase.Rows(index), BarcodeDataSet.DataTable3Row)
				End Get
			End Property

			' Token: 0x14000044 RID: 68
			' (add) Token: 0x0600A2F9 RID: 41721 RVA: 0x006FAF3C File Offset: 0x006F913C
			' (remove) Token: 0x0600A2FA RID: 41722 RVA: 0x006FAF74 File Offset: 0x006F9174
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable3RowChanging As BarcodeDataSet.DataTable3RowChangeEventHandler

			' Token: 0x14000045 RID: 69
			' (add) Token: 0x0600A2FB RID: 41723 RVA: 0x006FAFAC File Offset: 0x006F91AC
			' (remove) Token: 0x0600A2FC RID: 41724 RVA: 0x006FAFE4 File Offset: 0x006F91E4
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable3RowChanged As BarcodeDataSet.DataTable3RowChangeEventHandler

			' Token: 0x14000046 RID: 70
			' (add) Token: 0x0600A2FD RID: 41725 RVA: 0x006FB01C File Offset: 0x006F921C
			' (remove) Token: 0x0600A2FE RID: 41726 RVA: 0x006FB054 File Offset: 0x006F9254
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable3RowDeleting As BarcodeDataSet.DataTable3RowChangeEventHandler

			' Token: 0x14000047 RID: 71
			' (add) Token: 0x0600A2FF RID: 41727 RVA: 0x006FB08C File Offset: 0x006F928C
			' (remove) Token: 0x0600A300 RID: 41728 RVA: 0x006FB0C4 File Offset: 0x006F92C4
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable3RowDeleted As BarcodeDataSet.DataTable3RowChangeEventHandler

			' Token: 0x0600A301 RID: 41729 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable3Row(row As BarcodeDataSet.DataTable3Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600A302 RID: 41730 RVA: 0x006FB0FC File Offset: 0x006F92FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable3Row(PID As String, HSNC As String, ProductName As String, Barcode As String, MainQty As String, Rate As Double, DiscPer As Double, Disc As Double, CGSTPer As Double, CGST As Double, SGSTPer As Double, SGST As Double, IGSTPer As Double, IGST As Double, CESSPer As Double, CESS As Double, Total As String, AltQty As String, AltUnit As String, TaxableAmt As Double, MainUnit As String, PImage As Byte()) As BarcodeDataSet.DataTable3Row
				Dim dataTable3Row As BarcodeDataSet.DataTable3Row = CType(MyBase.NewRow(), BarcodeDataSet.DataTable3Row)
				Dim array As Object() = New Object() { PID, HSNC, ProductName, Barcode, MainQty, Rate, DiscPer, Disc, CGSTPer, CGST, SGSTPer, SGST, IGSTPer, IGST, CESSPer, CESS, Total, AltQty, AltUnit, TaxableAmt, MainUnit, PImage }
				dataTable3Row.ItemArray = array
				MyBase.Rows.Add(dataTable3Row)
				Return dataTable3Row
			End Function

			' Token: 0x0600A303 RID: 41731 RVA: 0x006FB1EC File Offset: 0x006F93EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable3DataTable As BarcodeDataSet.DataTable3DataTable = CType(MyBase.Clone(), BarcodeDataSet.DataTable3DataTable)
				dataTable3DataTable.InitVars()
				Return dataTable3DataTable
			End Function

			' Token: 0x0600A304 RID: 41732 RVA: 0x006FB214 File Offset: 0x006F9414
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New BarcodeDataSet.DataTable3DataTable()
			End Function

			' Token: 0x0600A305 RID: 41733 RVA: 0x006FB22C File Offset: 0x006F942C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnPID = MyBase.Columns("PID")
				Me.columnHSNC = MyBase.Columns("HSNC")
				Me.columnProductName = MyBase.Columns("ProductName")
				Me.columnBarcode = MyBase.Columns("Barcode")
				Me.columnMainQty = MyBase.Columns("MainQty")
				Me.columnRate = MyBase.Columns("Rate")
				Me.columnDiscPer = MyBase.Columns("DiscPer")
				Me.columnDisc = MyBase.Columns("Disc")
				Me.columnCGSTPer = MyBase.Columns("CGSTPer")
				Me.columnCGST = MyBase.Columns("CGST")
				Me.columnSGSTPer = MyBase.Columns("SGSTPer")
				Me.columnSGST = MyBase.Columns("SGST")
				Me.columnIGSTPer = MyBase.Columns("IGSTPer")
				Me.columnIGST = MyBase.Columns("IGST")
				Me.columnCESSPer = MyBase.Columns("CESSPer")
				Me.columnCESS = MyBase.Columns("CESS")
				Me.columnTotal = MyBase.Columns("Total")
				Me.columnAltQty = MyBase.Columns("AltQty")
				Me.columnAltUnit = MyBase.Columns("AltUnit")
				Me.columnTaxableAmt = MyBase.Columns("TaxableAmt")
				Me.columnMainUnit = MyBase.Columns("MainUnit")
				Me.columnPImage = MyBase.Columns("PImage")
			End Sub

			' Token: 0x0600A306 RID: 41734 RVA: 0x006FB420 File Offset: 0x006F9620
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnPID = New DataColumn("PID", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPID)
				Me.columnHSNC = New DataColumn("HSNC", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnHSNC)
				Me.columnProductName = New DataColumn("ProductName", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnProductName)
				Me.columnBarcode = New DataColumn("Barcode", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnBarcode)
				Me.columnMainQty = New DataColumn("MainQty", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMainQty)
				Me.columnRate = New DataColumn("Rate", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnRate)
				Me.columnDiscPer = New DataColumn("DiscPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDiscPer)
				Me.columnDisc = New DataColumn("Disc", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnDisc)
				Me.columnCGSTPer = New DataColumn("CGSTPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGSTPer)
				Me.columnCGST = New DataColumn("CGST", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCGST)
				Me.columnSGSTPer = New DataColumn("SGSTPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGSTPer)
				Me.columnSGST = New DataColumn("SGST", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnSGST)
				Me.columnIGSTPer = New DataColumn("IGSTPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGSTPer)
				Me.columnIGST = New DataColumn("IGST", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnIGST)
				Me.columnCESSPer = New DataColumn("CESSPer", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESSPer)
				Me.columnCESS = New DataColumn("CESS", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnCESS)
				Me.columnTotal = New DataColumn("Total", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTotal)
				Me.columnAltQty = New DataColumn("AltQty", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAltQty)
				Me.columnAltUnit = New DataColumn("AltUnit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnAltUnit)
				Me.columnTaxableAmt = New DataColumn("TaxableAmt", GetType(Double), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnTaxableAmt)
				Me.columnMainUnit = New DataColumn("MainUnit", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnMainUnit)
				Me.columnPImage = New DataColumn("PImage", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnPImage)
			End Sub

			' Token: 0x0600A307 RID: 41735 RVA: 0x006FB824 File Offset: 0x006F9A24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable3Row() As BarcodeDataSet.DataTable3Row
				Return CType(MyBase.NewRow(), BarcodeDataSet.DataTable3Row)
			End Function

			' Token: 0x0600A308 RID: 41736 RVA: 0x006FB844 File Offset: 0x006F9A44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New BarcodeDataSet.DataTable3Row(builder)
			End Function

			' Token: 0x0600A309 RID: 41737 RVA: 0x006FB85C File Offset: 0x006F9A5C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(BarcodeDataSet.DataTable3Row)
			End Function

			' Token: 0x0600A30A RID: 41738 RVA: 0x006FB878 File Offset: 0x006F9A78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable3RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable3RowChangedEvent As BarcodeDataSet.DataTable3RowChangeEventHandler = Me.DataTable3RowChangedEvent
					If dataTable3RowChangedEvent IsNot Nothing Then
						dataTable3RowChangedEvent(Me, New BarcodeDataSet.DataTable3RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable3Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A30B RID: 41739 RVA: 0x006FB8C8 File Offset: 0x006F9AC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable3RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable3RowChangingEvent As BarcodeDataSet.DataTable3RowChangeEventHandler = Me.DataTable3RowChangingEvent
					If dataTable3RowChangingEvent IsNot Nothing Then
						dataTable3RowChangingEvent(Me, New BarcodeDataSet.DataTable3RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable3Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A30C RID: 41740 RVA: 0x006FB918 File Offset: 0x006F9B18
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable3RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable3RowDeletedEvent As BarcodeDataSet.DataTable3RowChangeEventHandler = Me.DataTable3RowDeletedEvent
					If dataTable3RowDeletedEvent IsNot Nothing Then
						dataTable3RowDeletedEvent(Me, New BarcodeDataSet.DataTable3RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable3Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A30D RID: 41741 RVA: 0x006FB968 File Offset: 0x006F9B68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable3RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable3RowDeletingEvent As BarcodeDataSet.DataTable3RowChangeEventHandler = Me.DataTable3RowDeletingEvent
					If dataTable3RowDeletingEvent IsNot Nothing Then
						dataTable3RowDeletingEvent(Me, New BarcodeDataSet.DataTable3RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable3Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A30E RID: 41742 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable3Row(row As BarcodeDataSet.DataTable3Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600A30F RID: 41743 RVA: 0x006FB9B8 File Offset: 0x006F9BB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim barcodeDataSet As BarcodeDataSet = New BarcodeDataSet()
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
				xmlSchemaAttribute.FixedValue = barcodeDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable3DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = barcodeDataSet.GetSchemaSerializable()
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

			' Token: 0x0400457C RID: 17788
			Private columnPID As DataColumn

			' Token: 0x0400457D RID: 17789
			Private columnHSNC As DataColumn

			' Token: 0x0400457E RID: 17790
			Private columnProductName As DataColumn

			' Token: 0x0400457F RID: 17791
			Private columnBarcode As DataColumn

			' Token: 0x04004580 RID: 17792
			Private columnMainQty As DataColumn

			' Token: 0x04004581 RID: 17793
			Private columnRate As DataColumn

			' Token: 0x04004582 RID: 17794
			Private columnDiscPer As DataColumn

			' Token: 0x04004583 RID: 17795
			Private columnDisc As DataColumn

			' Token: 0x04004584 RID: 17796
			Private columnCGSTPer As DataColumn

			' Token: 0x04004585 RID: 17797
			Private columnCGST As DataColumn

			' Token: 0x04004586 RID: 17798
			Private columnSGSTPer As DataColumn

			' Token: 0x04004587 RID: 17799
			Private columnSGST As DataColumn

			' Token: 0x04004588 RID: 17800
			Private columnIGSTPer As DataColumn

			' Token: 0x04004589 RID: 17801
			Private columnIGST As DataColumn

			' Token: 0x0400458A RID: 17802
			Private columnCESSPer As DataColumn

			' Token: 0x0400458B RID: 17803
			Private columnCESS As DataColumn

			' Token: 0x0400458C RID: 17804
			Private columnTotal As DataColumn

			' Token: 0x0400458D RID: 17805
			Private columnAltQty As DataColumn

			' Token: 0x0400458E RID: 17806
			Private columnAltUnit As DataColumn

			' Token: 0x0400458F RID: 17807
			Private columnTaxableAmt As DataColumn

			' Token: 0x04004590 RID: 17808
			Private columnMainUnit As DataColumn

			' Token: 0x04004591 RID: 17809
			Private columnPImage As DataColumn
		End Class

		' Token: 0x02000260 RID: 608
		<XmlSchemaProvider("GetTypedTableSchema")>
		<Serializable()>
		Public Class DataTable4DataTable
			Inherits TypedTableBase(Of BarcodeDataSet.DataTable4Row)

			' Token: 0x0600A310 RID: 41744 RVA: 0x0004BE28 File Offset: 0x0004A028
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New()
				MyBase.TableName = "DataTable4"
				Me.BeginInit()
				Me.InitClass()
				Me.EndInit()
			End Sub

			' Token: 0x0600A311 RID: 41745 RVA: 0x006FBC0C File Offset: 0x006F9E0C
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

			' Token: 0x0600A312 RID: 41746 RVA: 0x0004BE53 File Offset: 0x0004A053
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Sub New(info As SerializationInfo, context As StreamingContext)
				MyBase.New(info, context)
				Me.InitVars()
			End Sub

			' Token: 0x17003F5F RID: 16223
			' (get) Token: 0x0600A313 RID: 41747 RVA: 0x006FBCD8 File Offset: 0x006F9ED8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property TextColumn As DataColumn
				Get
					Return Me.columnText
				End Get
			End Property

			' Token: 0x17003F60 RID: 16224
			' (get) Token: 0x0600A314 RID: 41748 RVA: 0x006FBCF0 File Offset: 0x006F9EF0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property ImageColumn As DataColumn
				Get
					Return Me.columnImage
				End Get
			End Property

			' Token: 0x17003F61 RID: 16225
			' (get) Token: 0x0600A315 RID: 41749 RVA: 0x000A086C File Offset: 0x0009EA6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			<Browsable(False)>
			Public ReadOnly Property Count As Integer
				Get
					Return MyBase.Rows.Count
				End Get
			End Property

			' Token: 0x17003F62 RID: 16226
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Default Property Item(index As Integer) As BarcodeDataSet.DataTable4Row
				Get
					Return CType(MyBase.Rows(index), BarcodeDataSet.DataTable4Row)
				End Get
			End Property

			' Token: 0x14000048 RID: 72
			' (add) Token: 0x0600A317 RID: 41751 RVA: 0x006FBD2C File Offset: 0x006F9F2C
			' (remove) Token: 0x0600A318 RID: 41752 RVA: 0x006FBD64 File Offset: 0x006F9F64
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable4RowChanging As BarcodeDataSet.DataTable4RowChangeEventHandler

			' Token: 0x14000049 RID: 73
			' (add) Token: 0x0600A319 RID: 41753 RVA: 0x006FBD9C File Offset: 0x006F9F9C
			' (remove) Token: 0x0600A31A RID: 41754 RVA: 0x006FBDD4 File Offset: 0x006F9FD4
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable4RowChanged As BarcodeDataSet.DataTable4RowChangeEventHandler

			' Token: 0x1400004A RID: 74
			' (add) Token: 0x0600A31B RID: 41755 RVA: 0x006FBE0C File Offset: 0x006FA00C
			' (remove) Token: 0x0600A31C RID: 41756 RVA: 0x006FBE44 File Offset: 0x006FA044
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable4RowDeleting As BarcodeDataSet.DataTable4RowChangeEventHandler

			' Token: 0x1400004B RID: 75
			' (add) Token: 0x0600A31D RID: 41757 RVA: 0x006FBE7C File Offset: 0x006FA07C
			' (remove) Token: 0x0600A31E RID: 41758 RVA: 0x006FBEB4 File Offset: 0x006FA0B4
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Event DataTable4RowDeleted As BarcodeDataSet.DataTable4RowChangeEventHandler

			' Token: 0x0600A31F RID: 41759 RVA: 0x0000A2DB File Offset: 0x000084DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub AddDataTable4Row(row As BarcodeDataSet.DataTable4Row)
				MyBase.Rows.Add(row)
			End Sub

			' Token: 0x0600A320 RID: 41760 RVA: 0x006FBEEC File Offset: 0x006FA0EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function AddDataTable4Row(Text As String, Image As Byte()) As BarcodeDataSet.DataTable4Row
				Dim dataTable4Row As BarcodeDataSet.DataTable4Row = CType(MyBase.NewRow(), BarcodeDataSet.DataTable4Row)
				Dim array As Object() = New Object() { Text, Image }
				dataTable4Row.ItemArray = array
				MyBase.Rows.Add(dataTable4Row)
				Return dataTable4Row
			End Function

			' Token: 0x0600A321 RID: 41761 RVA: 0x006FBF30 File Offset: 0x006FA130
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Overrides Function Clone() As DataTable
				Dim dataTable4DataTable As BarcodeDataSet.DataTable4DataTable = CType(MyBase.Clone(), BarcodeDataSet.DataTable4DataTable)
				dataTable4DataTable.InitVars()
				Return dataTable4DataTable
			End Function

			' Token: 0x0600A322 RID: 41762 RVA: 0x006FBF58 File Offset: 0x006FA158
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function CreateInstance() As DataTable
				Return New BarcodeDataSet.DataTable4DataTable()
			End Function

			' Token: 0x0600A323 RID: 41763 RVA: 0x0004BE66 File Offset: 0x0004A066
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub InitVars()
				Me.columnText = MyBase.Columns("Text")
				Me.columnImage = MyBase.Columns("Image")
			End Sub

			' Token: 0x0600A324 RID: 41764 RVA: 0x006FBF70 File Offset: 0x006FA170
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Sub InitClass()
				Me.columnText = New DataColumn("Text", GetType(String), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnText)
				Me.columnImage = New DataColumn("Image", GetType(Byte()), Nothing, MappingType.Element)
				MyBase.Columns.Add(Me.columnImage)
			End Sub

			' Token: 0x0600A325 RID: 41765 RVA: 0x006FBFDC File Offset: 0x006FA1DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function NewDataTable4Row() As BarcodeDataSet.DataTable4Row
				Return CType(MyBase.NewRow(), BarcodeDataSet.DataTable4Row)
			End Function

			' Token: 0x0600A326 RID: 41766 RVA: 0x006FBFFC File Offset: 0x006FA1FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
				Return New BarcodeDataSet.DataTable4Row(builder)
			End Function

			' Token: 0x0600A327 RID: 41767 RVA: 0x006FC014 File Offset: 0x006FA214
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Function GetRowType() As Type
				Return GetType(BarcodeDataSet.DataTable4Row)
			End Function

			' Token: 0x0600A328 RID: 41768 RVA: 0x006FC030 File Offset: 0x006FA230
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				Dim flag As Boolean = Me.DataTable4RowChangedEvent IsNot Nothing
				If flag Then
					Dim dataTable4RowChangedEvent As BarcodeDataSet.DataTable4RowChangeEventHandler = Me.DataTable4RowChangedEvent
					If dataTable4RowChangedEvent IsNot Nothing Then
						dataTable4RowChangedEvent(Me, New BarcodeDataSet.DataTable4RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable4Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A329 RID: 41769 RVA: 0x006FC080 File Offset: 0x006FA280
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				Dim flag As Boolean = Me.DataTable4RowChangingEvent IsNot Nothing
				If flag Then
					Dim dataTable4RowChangingEvent As BarcodeDataSet.DataTable4RowChangeEventHandler = Me.DataTable4RowChangingEvent
					If dataTable4RowChangingEvent IsNot Nothing Then
						dataTable4RowChangingEvent(Me, New BarcodeDataSet.DataTable4RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable4Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A32A RID: 41770 RVA: 0x006FC0D0 File Offset: 0x006FA2D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				Dim flag As Boolean = Me.DataTable4RowDeletedEvent IsNot Nothing
				If flag Then
					Dim dataTable4RowDeletedEvent As BarcodeDataSet.DataTable4RowChangeEventHandler = Me.DataTable4RowDeletedEvent
					If dataTable4RowDeletedEvent IsNot Nothing Then
						dataTable4RowDeletedEvent(Me, New BarcodeDataSet.DataTable4RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable4Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A32B RID: 41771 RVA: 0x006FC120 File Offset: 0x006FA320
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				Dim flag As Boolean = Me.DataTable4RowDeletingEvent IsNot Nothing
				If flag Then
					Dim dataTable4RowDeletingEvent As BarcodeDataSet.DataTable4RowChangeEventHandler = Me.DataTable4RowDeletingEvent
					If dataTable4RowDeletingEvent IsNot Nothing Then
						dataTable4RowDeletingEvent(Me, New BarcodeDataSet.DataTable4RowChangeEvent(CType(e.Row, BarcodeDataSet.DataTable4Row), e.Action))
					End If
				End If
			End Sub

			' Token: 0x0600A32C RID: 41772 RVA: 0x0000A335 File Offset: 0x00008535
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub RemoveDataTable4Row(row As BarcodeDataSet.DataTable4Row)
				MyBase.Rows.Remove(row)
			End Sub

			' Token: 0x0600A32D RID: 41773 RVA: 0x006FC170 File Offset: 0x006FA370
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Shared Function GetTypedTableSchema(xs As XmlSchemaSet) As XmlSchemaComplexType
				Dim xmlSchemaComplexType As XmlSchemaComplexType = New XmlSchemaComplexType()
				Dim xmlSchemaSequence As XmlSchemaSequence = New XmlSchemaSequence()
				Dim barcodeDataSet As BarcodeDataSet = New BarcodeDataSet()
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
				xmlSchemaAttribute.FixedValue = barcodeDataSet.[Namespace]
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute)
				Dim xmlSchemaAttribute2 As XmlSchemaAttribute = New XmlSchemaAttribute()
				xmlSchemaAttribute2.Name = "tableTypeName"
				xmlSchemaAttribute2.FixedValue = "DataTable4DataTable"
				xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2)
				xmlSchemaComplexType.Particle = xmlSchemaSequence
				Dim schemaSerializable As XmlSchema = barcodeDataSet.GetSchemaSerializable()
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

			' Token: 0x04004596 RID: 17814
			Private columnText As DataColumn

			' Token: 0x04004597 RID: 17815
			Private columnImage As DataColumn
		End Class

		' Token: 0x02000261 RID: 609
		Public Class DataTable1Row
			Inherits DataRow

			' Token: 0x0600A32E RID: 41774 RVA: 0x0004BE95 File Offset: 0x0004A095
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable1 = CType(MyBase.Table, BarcodeDataSet.DataTable1DataTable)
			End Sub

			' Token: 0x17003F63 RID: 16227
			' (get) Token: 0x0600A32F RID: 41775 RVA: 0x006FC3C4 File Offset: 0x006FA5C4
			' (set) Token: 0x0600A330 RID: 41776 RVA: 0x0004BEB1 File Offset: 0x0004A0B1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.PCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PCode' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.PCodeColumn) = value
				End Set
			End Property

			' Token: 0x17003F64 RID: 16228
			' (get) Token: 0x0600A331 RID: 41777 RVA: 0x006FC414 File Offset: 0x006FA614
			' (set) Token: 0x0600A332 RID: 41778 RVA: 0x0004BEC7 File Offset: 0x0004A0C7
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

			' Token: 0x17003F65 RID: 16229
			' (get) Token: 0x0600A333 RID: 41779 RVA: 0x006FC464 File Offset: 0x006FA664
			' (set) Token: 0x0600A334 RID: 41780 RVA: 0x0004BEDD File Offset: 0x0004A0DD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Category As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.CategoryColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Category' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.CategoryColumn) = value
				End Set
			End Property

			' Token: 0x17003F66 RID: 16230
			' (get) Token: 0x0600A335 RID: 41781 RVA: 0x006FC4B4 File Offset: 0x006FA6B4
			' (set) Token: 0x0600A336 RID: 41782 RVA: 0x0004BEF3 File Offset: 0x0004A0F3
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

			' Token: 0x17003F67 RID: 16231
			' (get) Token: 0x0600A337 RID: 41783 RVA: 0x006FC504 File Offset: 0x006FA704
			' (set) Token: 0x0600A338 RID: 41784 RVA: 0x0004BF09 File Offset: 0x0004A109
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AvlQty As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.AvlQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AvlQty' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.AvlQtyColumn) = value
				End Set
			End Property

			' Token: 0x17003F68 RID: 16232
			' (get) Token: 0x0600A339 RID: 41785 RVA: 0x006FC554 File Offset: 0x006FA754
			' (set) Token: 0x0600A33A RID: 41786 RVA: 0x0004BF1F File Offset: 0x0004A11F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property NoCopy As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.NoCopyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'NoCopy' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.NoCopyColumn) = value
				End Set
			End Property

			' Token: 0x17003F69 RID: 16233
			' (get) Token: 0x0600A33B RID: 41787 RVA: 0x006FC5A4 File Offset: 0x006FA7A4
			' (set) Token: 0x0600A33C RID: 41788 RVA: 0x0004BF35 File Offset: 0x0004A135
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

			' Token: 0x17003F6A RID: 16234
			' (get) Token: 0x0600A33D RID: 41789 RVA: 0x006FC5F4 File Offset: 0x006FA7F4
			' (set) Token: 0x0600A33E RID: 41790 RVA: 0x0004BF4B File Offset: 0x0004A14B
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

			' Token: 0x17003F6B RID: 16235
			' (get) Token: 0x0600A33F RID: 41791 RVA: 0x006FC644 File Offset: 0x006FA844
			' (set) Token: 0x0600A340 RID: 41792 RVA: 0x0004BF61 File Offset: 0x0004A161
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MRP As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable1.MRPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MRP' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable1.MRPColumn) = value
				End Set
			End Property

			' Token: 0x17003F6C RID: 16236
			' (get) Token: 0x0600A341 RID: 41793 RVA: 0x006FC694 File Offset: 0x006FA894
			' (set) Token: 0x0600A342 RID: 41794 RVA: 0x0004BF7C File Offset: 0x0004A17C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SalePrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable1.SalePriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SalePrice' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable1.SalePriceColumn) = value
				End Set
			End Property

			' Token: 0x17003F6D RID: 16237
			' (get) Token: 0x0600A343 RID: 41795 RVA: 0x006FC6E4 File Offset: 0x006FA8E4
			' (set) Token: 0x0600A344 RID: 41796 RVA: 0x0004BF97 File Offset: 0x0004A197
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property WholesalePrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable1.WholesalePriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'WholesalePrice' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable1.WholesalePriceColumn) = value
				End Set
			End Property

			' Token: 0x17003F6E RID: 16238
			' (get) Token: 0x0600A345 RID: 41797 RVA: 0x006FC734 File Offset: 0x006FA934
			' (set) Token: 0x0600A346 RID: 41798 RVA: 0x0004BFB2 File Offset: 0x0004A1B2
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

			' Token: 0x17003F6F RID: 16239
			' (get) Token: 0x0600A347 RID: 41799 RVA: 0x006FC784 File Offset: 0x006FA984
			' (set) Token: 0x0600A348 RID: 41800 RVA: 0x0004BFC8 File Offset: 0x0004A1C8
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

			' Token: 0x17003F70 RID: 16240
			' (get) Token: 0x0600A349 RID: 41801 RVA: 0x006FC7D4 File Offset: 0x006FA9D4
			' (set) Token: 0x0600A34A RID: 41802 RVA: 0x0004BFDE File Offset: 0x0004A1DE
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

			' Token: 0x17003F71 RID: 16241
			' (get) Token: 0x0600A34B RID: 41803 RVA: 0x006FC824 File Offset: 0x006FAA24
			' (set) Token: 0x0600A34C RID: 41804 RVA: 0x0004BFF4 File Offset: 0x0004A1F4
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

			' Token: 0x17003F72 RID: 16242
			' (get) Token: 0x0600A34D RID: 41805 RVA: 0x006FC874 File Offset: 0x006FAA74
			' (set) Token: 0x0600A34E RID: 41806 RVA: 0x0004C00A File Offset: 0x0004A20A
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

			' Token: 0x17003F73 RID: 16243
			' (get) Token: 0x0600A34F RID: 41807 RVA: 0x006FC8C4 File Offset: 0x006FAAC4
			' (set) Token: 0x0600A350 RID: 41808 RVA: 0x0004C020 File Offset: 0x0004A220
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.GSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GST' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.GSTColumn) = value
				End Set
			End Property

			' Token: 0x17003F74 RID: 16244
			' (get) Token: 0x0600A351 RID: 41809 RVA: 0x006FC914 File Offset: 0x006FAB14
			' (set) Token: 0x0600A352 RID: 41810 RVA: 0x0004C036 File Offset: 0x0004A236
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PurInv As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.PurInvColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PurInv' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.PurInvColumn) = value
				End Set
			End Property

			' Token: 0x17003F75 RID: 16245
			' (get) Token: 0x0600A353 RID: 41811 RVA: 0x006FC964 File Offset: 0x006FAB64
			' (set) Token: 0x0600A354 RID: 41812 RVA: 0x0004C04C File Offset: 0x0004A24C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IMEI1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.IMEI1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IMEI1' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.IMEI1Column) = value
				End Set
			End Property

			' Token: 0x17003F76 RID: 16246
			' (get) Token: 0x0600A355 RID: 41813 RVA: 0x006FC9B4 File Offset: 0x006FABB4
			' (set) Token: 0x0600A356 RID: 41814 RVA: 0x0004C062 File Offset: 0x0004A262
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IMEI2 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable1.IMEI2Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IMEI2' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable1.IMEI2Column) = value
				End Set
			End Property

			' Token: 0x17003F77 RID: 16247
			' (get) Token: 0x0600A357 RID: 41815 RVA: 0x006FCA04 File Offset: 0x006FAC04
			' (set) Token: 0x0600A358 RID: 41816 RVA: 0x0004C078 File Offset: 0x0004A278
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property QrBarcode As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable1.QrBarcodeColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'QrBarcode' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable1.QrBarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17003F78 RID: 16248
			' (get) Token: 0x0600A359 RID: 41817 RVA: 0x006FCA54 File Offset: 0x006FAC54
			' (set) Token: 0x0600A35A RID: 41818 RVA: 0x0004C08E File Offset: 0x0004A28E
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

			' Token: 0x17003F79 RID: 16249
			' (get) Token: 0x0600A35B RID: 41819 RVA: 0x006FCAA4 File Offset: 0x006FACA4
			' (set) Token: 0x0600A35C RID: 41820 RVA: 0x0004C0A4 File Offset: 0x0004A2A4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PImage As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable1.PImageColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PImage' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable1.PImageColumn) = value
				End Set
			End Property

			' Token: 0x17003F7A RID: 16250
			' (get) Token: 0x0600A35D RID: 41821 RVA: 0x006FCAF4 File Offset: 0x006FACF4
			' (set) Token: 0x0600A35E RID: 41822 RVA: 0x0004C0BA File Offset: 0x0004A2BA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Pic As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable1.PicColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Pic' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable1.PicColumn) = value
				End Set
			End Property

			' Token: 0x17003F7B RID: 16251
			' (get) Token: 0x0600A35F RID: 41823 RVA: 0x006FCB44 File Offset: 0x006FAD44
			' (set) Token: 0x0600A360 RID: 41824 RVA: 0x0004C0D0 File Offset: 0x0004A2D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Discount As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable1.DiscountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Discount' in table 'DataTable1' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable1.DiscountColumn) = value
				End Set
			End Property

			' Token: 0x0600A361 RID: 41825 RVA: 0x006FCB94 File Offset: 0x006FAD94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PCodeColumn)
			End Function

			' Token: 0x0600A362 RID: 41826 RVA: 0x0004C0EB File Offset: 0x0004A2EB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPCodeNull()
				MyBase.Item(Me.tableDataTable1.PCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A363 RID: 41827 RVA: 0x006FCBB8 File Offset: 0x006FADB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ProductNameColumn)
			End Function

			' Token: 0x0600A364 RID: 41828 RVA: 0x0004C10A File Offset: 0x0004A30A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductNameNull()
				MyBase.Item(Me.tableDataTable1.ProductNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A365 RID: 41829 RVA: 0x006FCBDC File Offset: 0x006FADDC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCategoryNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CategoryColumn)
			End Function

			' Token: 0x0600A366 RID: 41830 RVA: 0x0004C129 File Offset: 0x0004A329
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCategoryNull()
				MyBase.Item(Me.tableDataTable1.CategoryColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A367 RID: 41831 RVA: 0x006FCC00 File Offset: 0x006FAE00
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.BarcodeColumn)
			End Function

			' Token: 0x0600A368 RID: 41832 RVA: 0x0004C148 File Offset: 0x0004A348
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableDataTable1.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A369 RID: 41833 RVA: 0x006FCC24 File Offset: 0x006FAE24
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAvlQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.AvlQtyColumn)
			End Function

			' Token: 0x0600A36A RID: 41834 RVA: 0x0004C167 File Offset: 0x0004A367
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAvlQtyNull()
				MyBase.Item(Me.tableDataTable1.AvlQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A36B RID: 41835 RVA: 0x006FCC48 File Offset: 0x006FAE48
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsNoCopyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.NoCopyColumn)
			End Function

			' Token: 0x0600A36C RID: 41836 RVA: 0x0004C186 File Offset: 0x0004A386
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetNoCopyNull()
				MyBase.Item(Me.tableDataTable1.NoCopyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A36D RID: 41837 RVA: 0x006FCC6C File Offset: 0x006FAE6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPartNoNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PartNoColumn)
			End Function

			' Token: 0x0600A36E RID: 41838 RVA: 0x0004C1A5 File Offset: 0x0004A3A5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPartNoNull()
				MyBase.Item(Me.tableDataTable1.PartNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A36F RID: 41839 RVA: 0x006FCC90 File Offset: 0x006FAE90
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.HSNCColumn)
			End Function

			' Token: 0x0600A370 RID: 41840 RVA: 0x0004C1C4 File Offset: 0x0004A3C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCNull()
				MyBase.Item(Me.tableDataTable1.HSNCColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A371 RID: 41841 RVA: 0x006FCCB4 File Offset: 0x006FAEB4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.MRPColumn)
			End Function

			' Token: 0x0600A372 RID: 41842 RVA: 0x0004C1E3 File Offset: 0x0004A3E3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMRPNull()
				MyBase.Item(Me.tableDataTable1.MRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A373 RID: 41843 RVA: 0x006FCCD8 File Offset: 0x006FAED8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalePriceNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.SalePriceColumn)
			End Function

			' Token: 0x0600A374 RID: 41844 RVA: 0x0004C202 File Offset: 0x0004A402
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalePriceNull()
				MyBase.Item(Me.tableDataTable1.SalePriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A375 RID: 41845 RVA: 0x006FCCFC File Offset: 0x006FAEFC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsWholesalePriceNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.WholesalePriceColumn)
			End Function

			' Token: 0x0600A376 RID: 41846 RVA: 0x0004C221 File Offset: 0x0004A421
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetWholesalePriceNull()
				MyBase.Item(Me.tableDataTable1.WholesalePriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A377 RID: 41847 RVA: 0x006FCD20 File Offset: 0x006FAF20
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBatchNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.BatchColumn)
			End Function

			' Token: 0x0600A378 RID: 41848 RVA: 0x0004C240 File Offset: 0x0004A440
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBatchNull()
				MyBase.Item(Me.tableDataTable1.BatchColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A379 RID: 41849 RVA: 0x006FCD44 File Offset: 0x006FAF44
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMfgNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.MfgColumn)
			End Function

			' Token: 0x0600A37A RID: 41850 RVA: 0x0004C25F File Offset: 0x0004A45F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMfgNull()
				MyBase.Item(Me.tableDataTable1.MfgColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A37B RID: 41851 RVA: 0x006FCD68 File Offset: 0x006FAF68
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsExpNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ExpColumn)
			End Function

			' Token: 0x0600A37C RID: 41852 RVA: 0x0004C27E File Offset: 0x0004A47E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetExpNull()
				MyBase.Item(Me.tableDataTable1.ExpColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A37D RID: 41853 RVA: 0x006FCD8C File Offset: 0x006FAF8C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSizeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.SizeColumn)
			End Function

			' Token: 0x0600A37E RID: 41854 RVA: 0x0004C29D File Offset: 0x0004A49D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSizeNull()
				MyBase.Item(Me.tableDataTable1.SizeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A37F RID: 41855 RVA: 0x006FCDB0 File Offset: 0x006FAFB0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsColourNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.ColourColumn)
			End Function

			' Token: 0x0600A380 RID: 41856 RVA: 0x0004C2BC File Offset: 0x0004A4BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetColourNull()
				MyBase.Item(Me.tableDataTable1.ColourColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A381 RID: 41857 RVA: 0x006FCDD4 File Offset: 0x006FAFD4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.GSTColumn)
			End Function

			' Token: 0x0600A382 RID: 41858 RVA: 0x0004C2DB File Offset: 0x0004A4DB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGSTNull()
				MyBase.Item(Me.tableDataTable1.GSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A383 RID: 41859 RVA: 0x006FCDF8 File Offset: 0x006FAFF8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPurInvNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PurInvColumn)
			End Function

			' Token: 0x0600A384 RID: 41860 RVA: 0x0004C2FA File Offset: 0x0004A4FA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPurInvNull()
				MyBase.Item(Me.tableDataTable1.PurInvColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A385 RID: 41861 RVA: 0x006FCE1C File Offset: 0x006FB01C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIMEI1Null() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.IMEI1Column)
			End Function

			' Token: 0x0600A386 RID: 41862 RVA: 0x0004C319 File Offset: 0x0004A519
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIMEI1Null()
				MyBase.Item(Me.tableDataTable1.IMEI1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A387 RID: 41863 RVA: 0x006FCE40 File Offset: 0x006FB040
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIMEI2Null() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.IMEI2Column)
			End Function

			' Token: 0x0600A388 RID: 41864 RVA: 0x0004C338 File Offset: 0x0004A538
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIMEI2Null()
				MyBase.Item(Me.tableDataTable1.IMEI2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A389 RID: 41865 RVA: 0x006FCE64 File Offset: 0x006FB064
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQrBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.QrBarcodeColumn)
			End Function

			' Token: 0x0600A38A RID: 41866 RVA: 0x0004C357 File Offset: 0x0004A557
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQrBarcodeNull()
				MyBase.Item(Me.tableDataTable1.QrBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A38B RID: 41867 RVA: 0x006FCE88 File Offset: 0x006FB088
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.CBarcodeColumn)
			End Function

			' Token: 0x0600A38C RID: 41868 RVA: 0x0004C376 File Offset: 0x0004A576
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCBarcodeNull()
				MyBase.Item(Me.tableDataTable1.CBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A38D RID: 41869 RVA: 0x006FCEAC File Offset: 0x006FB0AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPImageNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PImageColumn)
			End Function

			' Token: 0x0600A38E RID: 41870 RVA: 0x0004C395 File Offset: 0x0004A595
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPImageNull()
				MyBase.Item(Me.tableDataTable1.PImageColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A38F RID: 41871 RVA: 0x006FCED0 File Offset: 0x006FB0D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPicNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.PicColumn)
			End Function

			' Token: 0x0600A390 RID: 41872 RVA: 0x0004C3B4 File Offset: 0x0004A5B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPicNull()
				MyBase.Item(Me.tableDataTable1.PicColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A391 RID: 41873 RVA: 0x006FCEF4 File Offset: 0x006FB0F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable1.DiscountColumn)
			End Function

			' Token: 0x0600A392 RID: 41874 RVA: 0x0004C3D3 File Offset: 0x0004A5D3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountNull()
				MyBase.Item(Me.tableDataTable1.DiscountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0400459C RID: 17820
			Private tableDataTable1 As BarcodeDataSet.DataTable1DataTable
		End Class

		' Token: 0x02000262 RID: 610
		Public Class DataTable2Row
			Inherits DataRow

			' Token: 0x0600A393 RID: 41875 RVA: 0x0004C3F2 File Offset: 0x0004A5F2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable2 = CType(MyBase.Table, BarcodeDataSet.DataTable2DataTable)
			End Sub

			' Token: 0x17003F7C RID: 16252
			' (get) Token: 0x0600A394 RID: 41876 RVA: 0x006FCF18 File Offset: 0x006FB118
			' (set) Token: 0x0600A395 RID: 41877 RVA: 0x0004C40E File Offset: 0x0004A60E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Barcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.BarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Barcode' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.BarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17003F7D RID: 16253
			' (get) Token: 0x0600A396 RID: 41878 RVA: 0x006FCF68 File Offset: 0x006FB168
			' (set) Token: 0x0600A397 RID: 41879 RVA: 0x0004C424 File Offset: 0x0004A624
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property QrBarcode As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable2.QrBarcodeColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'QrBarcode' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable2.QrBarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17003F7E RID: 16254
			' (get) Token: 0x0600A398 RID: 41880 RVA: 0x006FCFB8 File Offset: 0x006FB1B8
			' (set) Token: 0x0600A399 RID: 41881 RVA: 0x0004C43A File Offset: 0x0004A63A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.ProductCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductCode' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.ProductCodeColumn) = value
				End Set
			End Property

			' Token: 0x17003F7F RID: 16255
			' (get) Token: 0x0600A39A RID: 41882 RVA: 0x006FD008 File Offset: 0x006FB208
			' (set) Token: 0x0600A39B RID: 41883 RVA: 0x0004C450 File Offset: 0x0004A650
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.ProductNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductName' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.ProductNameColumn) = value
				End Set
			End Property

			' Token: 0x17003F80 RID: 16256
			' (get) Token: 0x0600A39C RID: 41884 RVA: 0x006FD058 File Offset: 0x006FB258
			' (set) Token: 0x0600A39D RID: 41885 RVA: 0x0004C466 File Offset: 0x0004A666
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Category As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.CategoryColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Category' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.CategoryColumn) = value
				End Set
			End Property

			' Token: 0x17003F81 RID: 16257
			' (get) Token: 0x0600A39E RID: 41886 RVA: 0x006FD0A8 File Offset: 0x006FB2A8
			' (set) Token: 0x0600A39F RID: 41887 RVA: 0x0004C47C File Offset: 0x0004A67C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Qty As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.QtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Qty' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.QtyColumn) = value
				End Set
			End Property

			' Token: 0x17003F82 RID: 16258
			' (get) Token: 0x0600A3A0 RID: 41888 RVA: 0x006FD0F8 File Offset: 0x006FB2F8
			' (set) Token: 0x0600A3A1 RID: 41889 RVA: 0x0004C492 File Offset: 0x0004A692
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PartNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.PartNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PartNo' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.PartNoColumn) = value
				End Set
			End Property

			' Token: 0x17003F83 RID: 16259
			' (get) Token: 0x0600A3A2 RID: 41890 RVA: 0x006FD148 File Offset: 0x006FB348
			' (set) Token: 0x0600A3A3 RID: 41891 RVA: 0x0004C4A8 File Offset: 0x0004A6A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property HSNCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.HSNCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'HSNCode' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.HSNCodeColumn) = value
				End Set
			End Property

			' Token: 0x17003F84 RID: 16260
			' (get) Token: 0x0600A3A4 RID: 41892 RVA: 0x006FD198 File Offset: 0x006FB398
			' (set) Token: 0x0600A3A5 RID: 41893 RVA: 0x0004C4BE File Offset: 0x0004A6BE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MRP As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable2.MRPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MRP' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable2.MRPColumn) = value
				End Set
			End Property

			' Token: 0x17003F85 RID: 16261
			' (get) Token: 0x0600A3A6 RID: 41894 RVA: 0x006FD1E8 File Offset: 0x006FB3E8
			' (set) Token: 0x0600A3A7 RID: 41895 RVA: 0x0004C4D9 File Offset: 0x0004A6D9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SPrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable2.SPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SPrice' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable2.SPriceColumn) = value
				End Set
			End Property

			' Token: 0x17003F86 RID: 16262
			' (get) Token: 0x0600A3A8 RID: 41896 RVA: 0x006FD238 File Offset: 0x006FB438
			' (set) Token: 0x0600A3A9 RID: 41897 RVA: 0x0004C4F4 File Offset: 0x0004A6F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property WPrice As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable2.WPriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'WPrice' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable2.WPriceColumn) = value
				End Set
			End Property

			' Token: 0x17003F87 RID: 16263
			' (get) Token: 0x0600A3AA RID: 41898 RVA: 0x006FD288 File Offset: 0x006FB488
			' (set) Token: 0x0600A3AB RID: 41899 RVA: 0x0004C50F File Offset: 0x0004A70F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Batch As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.BatchColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Batch' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.BatchColumn) = value
				End Set
			End Property

			' Token: 0x17003F88 RID: 16264
			' (get) Token: 0x0600A3AC RID: 41900 RVA: 0x006FD2D8 File Offset: 0x006FB4D8
			' (set) Token: 0x0600A3AD RID: 41901 RVA: 0x0004C525 File Offset: 0x0004A725
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Mfgdate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.MfgdateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Mfgdate' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.MfgdateColumn) = value
				End Set
			End Property

			' Token: 0x17003F89 RID: 16265
			' (get) Token: 0x0600A3AE RID: 41902 RVA: 0x006FD328 File Offset: 0x006FB528
			' (set) Token: 0x0600A3AF RID: 41903 RVA: 0x0004C53B File Offset: 0x0004A73B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Expdate As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.ExpdateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Expdate' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.ExpdateColumn) = value
				End Set
			End Property

			' Token: 0x17003F8A RID: 16266
			' (get) Token: 0x0600A3B0 RID: 41904 RVA: 0x006FD378 File Offset: 0x006FB578
			' (set) Token: 0x0600A3B1 RID: 41905 RVA: 0x0004C551 File Offset: 0x0004A751
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Size As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.SizeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Size' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.SizeColumn) = value
				End Set
			End Property

			' Token: 0x17003F8B RID: 16267
			' (get) Token: 0x0600A3B2 RID: 41906 RVA: 0x006FD3C8 File Offset: 0x006FB5C8
			' (set) Token: 0x0600A3B3 RID: 41907 RVA: 0x0004C567 File Offset: 0x0004A767
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Colour As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.ColourColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Colour' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.ColourColumn) = value
				End Set
			End Property

			' Token: 0x17003F8C RID: 16268
			' (get) Token: 0x0600A3B4 RID: 41908 RVA: 0x006FD418 File Offset: 0x006FB618
			' (set) Token: 0x0600A3B5 RID: 41909 RVA: 0x0004C57D File Offset: 0x0004A77D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.CGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGST' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.CGSTColumn) = value
				End Set
			End Property

			' Token: 0x17003F8D RID: 16269
			' (get) Token: 0x0600A3B6 RID: 41910 RVA: 0x006FD468 File Offset: 0x006FB668
			' (set) Token: 0x0600A3B7 RID: 41911 RVA: 0x0004C593 File Offset: 0x0004A793
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.SGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGST' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.SGSTColumn) = value
				End Set
			End Property

			' Token: 0x17003F8E RID: 16270
			' (get) Token: 0x0600A3B8 RID: 41912 RVA: 0x006FD4B8 File Offset: 0x006FB6B8
			' (set) Token: 0x0600A3B9 RID: 41913 RVA: 0x0004C5A9 File Offset: 0x0004A7A9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CBarcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable2.CBarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CBarcode' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable2.CBarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17003F8F RID: 16271
			' (get) Token: 0x0600A3BA RID: 41914 RVA: 0x006FD508 File Offset: 0x006FB708
			' (set) Token: 0x0600A3BB RID: 41915 RVA: 0x0004C5BF File Offset: 0x0004A7BF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property DefaultQty As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable2.DefaultQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'DefaultQty' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable2.DefaultQtyColumn) = value
				End Set
			End Property

			' Token: 0x17003F90 RID: 16272
			' (get) Token: 0x0600A3BC RID: 41916 RVA: 0x006FD558 File Offset: 0x006FB758
			' (set) Token: 0x0600A3BD RID: 41917 RVA: 0x0004C5DA File Offset: 0x0004A7DA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property QRCBarcode As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable2.QRCBarcodeColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'QRCBarcode' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable2.QRCBarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17003F91 RID: 16273
			' (get) Token: 0x0600A3BE RID: 41918 RVA: 0x006FD5A8 File Offset: 0x006FB7A8
			' (set) Token: 0x0600A3BF RID: 41919 RVA: 0x0004C5F0 File Offset: 0x0004A7F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Discount As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable2.DiscountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Discount' in table 'DataTable2' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable2.DiscountColumn) = value
				End Set
			End Property

			' Token: 0x0600A3C0 RID: 41920 RVA: 0x006FD5F8 File Offset: 0x006FB7F8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.BarcodeColumn)
			End Function

			' Token: 0x0600A3C1 RID: 41921 RVA: 0x0004C60B File Offset: 0x0004A80B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableDataTable2.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3C2 RID: 41922 RVA: 0x006FD61C File Offset: 0x006FB81C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQrBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.QrBarcodeColumn)
			End Function

			' Token: 0x0600A3C3 RID: 41923 RVA: 0x0004C62A File Offset: 0x0004A82A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQrBarcodeNull()
				MyBase.Item(Me.tableDataTable2.QrBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3C4 RID: 41924 RVA: 0x006FD640 File Offset: 0x006FB840
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.ProductCodeColumn)
			End Function

			' Token: 0x0600A3C5 RID: 41925 RVA: 0x0004C649 File Offset: 0x0004A849
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductCodeNull()
				MyBase.Item(Me.tableDataTable2.ProductCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3C6 RID: 41926 RVA: 0x006FD664 File Offset: 0x006FB864
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.ProductNameColumn)
			End Function

			' Token: 0x0600A3C7 RID: 41927 RVA: 0x0004C668 File Offset: 0x0004A868
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductNameNull()
				MyBase.Item(Me.tableDataTable2.ProductNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3C8 RID: 41928 RVA: 0x006FD688 File Offset: 0x006FB888
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCategoryNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.CategoryColumn)
			End Function

			' Token: 0x0600A3C9 RID: 41929 RVA: 0x0004C687 File Offset: 0x0004A887
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCategoryNull()
				MyBase.Item(Me.tableDataTable2.CategoryColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3CA RID: 41930 RVA: 0x006FD6AC File Offset: 0x006FB8AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.QtyColumn)
			End Function

			' Token: 0x0600A3CB RID: 41931 RVA: 0x0004C6A6 File Offset: 0x0004A8A6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQtyNull()
				MyBase.Item(Me.tableDataTable2.QtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3CC RID: 41932 RVA: 0x006FD6D0 File Offset: 0x006FB8D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPartNoNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.PartNoColumn)
			End Function

			' Token: 0x0600A3CD RID: 41933 RVA: 0x0004C6C5 File Offset: 0x0004A8C5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPartNoNull()
				MyBase.Item(Me.tableDataTable2.PartNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3CE RID: 41934 RVA: 0x006FD6F4 File Offset: 0x006FB8F4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.HSNCodeColumn)
			End Function

			' Token: 0x0600A3CF RID: 41935 RVA: 0x0004C6E4 File Offset: 0x0004A8E4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCodeNull()
				MyBase.Item(Me.tableDataTable2.HSNCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3D0 RID: 41936 RVA: 0x006FD718 File Offset: 0x006FB918
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.MRPColumn)
			End Function

			' Token: 0x0600A3D1 RID: 41937 RVA: 0x0004C703 File Offset: 0x0004A903
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMRPNull()
				MyBase.Item(Me.tableDataTable2.MRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3D2 RID: 41938 RVA: 0x006FD73C File Offset: 0x006FB93C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.SPriceColumn)
			End Function

			' Token: 0x0600A3D3 RID: 41939 RVA: 0x0004C722 File Offset: 0x0004A922
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSPriceNull()
				MyBase.Item(Me.tableDataTable2.SPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3D4 RID: 41940 RVA: 0x006FD760 File Offset: 0x006FB960
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsWPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.WPriceColumn)
			End Function

			' Token: 0x0600A3D5 RID: 41941 RVA: 0x0004C741 File Offset: 0x0004A941
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetWPriceNull()
				MyBase.Item(Me.tableDataTable2.WPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3D6 RID: 41942 RVA: 0x006FD784 File Offset: 0x006FB984
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBatchNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.BatchColumn)
			End Function

			' Token: 0x0600A3D7 RID: 41943 RVA: 0x0004C760 File Offset: 0x0004A960
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBatchNull()
				MyBase.Item(Me.tableDataTable2.BatchColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3D8 RID: 41944 RVA: 0x006FD7A8 File Offset: 0x006FB9A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMfgdateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.MfgdateColumn)
			End Function

			' Token: 0x0600A3D9 RID: 41945 RVA: 0x0004C77F File Offset: 0x0004A97F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMfgdateNull()
				MyBase.Item(Me.tableDataTable2.MfgdateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3DA RID: 41946 RVA: 0x006FD7CC File Offset: 0x006FB9CC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsExpdateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.ExpdateColumn)
			End Function

			' Token: 0x0600A3DB RID: 41947 RVA: 0x0004C79E File Offset: 0x0004A99E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetExpdateNull()
				MyBase.Item(Me.tableDataTable2.ExpdateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3DC RID: 41948 RVA: 0x006FD7F0 File Offset: 0x006FB9F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSizeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.SizeColumn)
			End Function

			' Token: 0x0600A3DD RID: 41949 RVA: 0x0004C7BD File Offset: 0x0004A9BD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSizeNull()
				MyBase.Item(Me.tableDataTable2.SizeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3DE RID: 41950 RVA: 0x006FD814 File Offset: 0x006FBA14
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsColourNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.ColourColumn)
			End Function

			' Token: 0x0600A3DF RID: 41951 RVA: 0x0004C7DC File Offset: 0x0004A9DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetColourNull()
				MyBase.Item(Me.tableDataTable2.ColourColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3E0 RID: 41952 RVA: 0x006FD838 File Offset: 0x006FBA38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.CGSTColumn)
			End Function

			' Token: 0x0600A3E1 RID: 41953 RVA: 0x0004C7FB File Offset: 0x0004A9FB
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTNull()
				MyBase.Item(Me.tableDataTable2.CGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3E2 RID: 41954 RVA: 0x006FD85C File Offset: 0x006FBA5C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.SGSTColumn)
			End Function

			' Token: 0x0600A3E3 RID: 41955 RVA: 0x0004C81A File Offset: 0x0004AA1A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTNull()
				MyBase.Item(Me.tableDataTable2.SGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3E4 RID: 41956 RVA: 0x006FD880 File Offset: 0x006FBA80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.CBarcodeColumn)
			End Function

			' Token: 0x0600A3E5 RID: 41957 RVA: 0x0004C839 File Offset: 0x0004AA39
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCBarcodeNull()
				MyBase.Item(Me.tableDataTable2.CBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3E6 RID: 41958 RVA: 0x006FD8A4 File Offset: 0x006FBAA4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDefaultQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.DefaultQtyColumn)
			End Function

			' Token: 0x0600A3E7 RID: 41959 RVA: 0x0004C858 File Offset: 0x0004AA58
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDefaultQtyNull()
				MyBase.Item(Me.tableDataTable2.DefaultQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3E8 RID: 41960 RVA: 0x006FD8C8 File Offset: 0x006FBAC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQRCBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.QRCBarcodeColumn)
			End Function

			' Token: 0x0600A3E9 RID: 41961 RVA: 0x0004C877 File Offset: 0x0004AA77
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQRCBarcodeNull()
				MyBase.Item(Me.tableDataTable2.QRCBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A3EA RID: 41962 RVA: 0x006FD8EC File Offset: 0x006FBAEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable2.DiscountColumn)
			End Function

			' Token: 0x0600A3EB RID: 41963 RVA: 0x0004C896 File Offset: 0x0004AA96
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountNull()
				MyBase.Item(Me.tableDataTable2.DiscountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0400459D RID: 17821
			Private tableDataTable2 As BarcodeDataSet.DataTable2DataTable
		End Class

		' Token: 0x02000263 RID: 611
		Public Class P_TransferRow
			Inherits DataRow

			' Token: 0x0600A3EC RID: 41964 RVA: 0x0004C8B5 File Offset: 0x0004AAB5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableP_Transfer = CType(MyBase.Table, BarcodeDataSet.P_TransferDataTable)
			End Sub

			' Token: 0x17003F92 RID: 16274
			' (get) Token: 0x0600A3ED RID: 41965 RVA: 0x006FD910 File Offset: 0x006FBB10
			' (set) Token: 0x0600A3EE RID: 41966 RVA: 0x0004C8D1 File Offset: 0x0004AAD1
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

			' Token: 0x17003F93 RID: 16275
			' (get) Token: 0x0600A3EF RID: 41967 RVA: 0x006FD960 File Offset: 0x006FBB60
			' (set) Token: 0x0600A3F0 RID: 41968 RVA: 0x0004C8E7 File Offset: 0x0004AAE7
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

			' Token: 0x17003F94 RID: 16276
			' (get) Token: 0x0600A3F1 RID: 41969 RVA: 0x006FD9B0 File Offset: 0x006FBBB0
			' (set) Token: 0x0600A3F2 RID: 41970 RVA: 0x0004C8FD File Offset: 0x0004AAFD
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

			' Token: 0x17003F95 RID: 16277
			' (get) Token: 0x0600A3F3 RID: 41971 RVA: 0x006FDA00 File Offset: 0x006FBC00
			' (set) Token: 0x0600A3F4 RID: 41972 RVA: 0x0004C913 File Offset: 0x0004AB13
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

			' Token: 0x17003F96 RID: 16278
			' (get) Token: 0x0600A3F5 RID: 41973 RVA: 0x006FDA50 File Offset: 0x006FBC50
			' (set) Token: 0x0600A3F6 RID: 41974 RVA: 0x0004C929 File Offset: 0x0004AB29
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

			' Token: 0x17003F97 RID: 16279
			' (get) Token: 0x0600A3F7 RID: 41975 RVA: 0x006FDAA0 File Offset: 0x006FBCA0
			' (set) Token: 0x0600A3F8 RID: 41976 RVA: 0x0004C93F File Offset: 0x0004AB3F
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

			' Token: 0x17003F98 RID: 16280
			' (get) Token: 0x0600A3F9 RID: 41977 RVA: 0x006FDAF0 File Offset: 0x006FBCF0
			' (set) Token: 0x0600A3FA RID: 41978 RVA: 0x0004C955 File Offset: 0x0004AB55
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

			' Token: 0x17003F99 RID: 16281
			' (get) Token: 0x0600A3FB RID: 41979 RVA: 0x006FDB40 File Offset: 0x006FBD40
			' (set) Token: 0x0600A3FC RID: 41980 RVA: 0x0004C96B File Offset: 0x0004AB6B
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

			' Token: 0x17003F9A RID: 16282
			' (get) Token: 0x0600A3FD RID: 41981 RVA: 0x006FDB90 File Offset: 0x006FBD90
			' (set) Token: 0x0600A3FE RID: 41982 RVA: 0x0004C986 File Offset: 0x0004AB86
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

			' Token: 0x17003F9B RID: 16283
			' (get) Token: 0x0600A3FF RID: 41983 RVA: 0x006FDBE0 File Offset: 0x006FBDE0
			' (set) Token: 0x0600A400 RID: 41984 RVA: 0x0004C9A1 File Offset: 0x0004ABA1
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

			' Token: 0x17003F9C RID: 16284
			' (get) Token: 0x0600A401 RID: 41985 RVA: 0x006FDC30 File Offset: 0x006FBE30
			' (set) Token: 0x0600A402 RID: 41986 RVA: 0x0004C9BC File Offset: 0x0004ABBC
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

			' Token: 0x17003F9D RID: 16285
			' (get) Token: 0x0600A403 RID: 41987 RVA: 0x006FDC80 File Offset: 0x006FBE80
			' (set) Token: 0x0600A404 RID: 41988 RVA: 0x0004C9D7 File Offset: 0x0004ABD7
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

			' Token: 0x17003F9E RID: 16286
			' (get) Token: 0x0600A405 RID: 41989 RVA: 0x006FDCD0 File Offset: 0x006FBED0
			' (set) Token: 0x0600A406 RID: 41990 RVA: 0x0004C9F2 File Offset: 0x0004ABF2
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

			' Token: 0x17003F9F RID: 16287
			' (get) Token: 0x0600A407 RID: 41991 RVA: 0x006FDD20 File Offset: 0x006FBF20
			' (set) Token: 0x0600A408 RID: 41992 RVA: 0x0004CA0D File Offset: 0x0004AC0D
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

			' Token: 0x17003FA0 RID: 16288
			' (get) Token: 0x0600A409 RID: 41993 RVA: 0x006FDD70 File Offset: 0x006FBF70
			' (set) Token: 0x0600A40A RID: 41994 RVA: 0x0004CA28 File Offset: 0x0004AC28
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

			' Token: 0x17003FA1 RID: 16289
			' (get) Token: 0x0600A40B RID: 41995 RVA: 0x006FDDC0 File Offset: 0x006FBFC0
			' (set) Token: 0x0600A40C RID: 41996 RVA: 0x0004CA43 File Offset: 0x0004AC43
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

			' Token: 0x17003FA2 RID: 16290
			' (get) Token: 0x0600A40D RID: 41997 RVA: 0x006FDE10 File Offset: 0x006FC010
			' (set) Token: 0x0600A40E RID: 41998 RVA: 0x0004CA59 File Offset: 0x0004AC59
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

			' Token: 0x17003FA3 RID: 16291
			' (get) Token: 0x0600A40F RID: 41999 RVA: 0x006FDE60 File Offset: 0x006FC060
			' (set) Token: 0x0600A410 RID: 42000 RVA: 0x0004CA6F File Offset: 0x0004AC6F
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

			' Token: 0x17003FA4 RID: 16292
			' (get) Token: 0x0600A411 RID: 42001 RVA: 0x006FDEB0 File Offset: 0x006FC0B0
			' (set) Token: 0x0600A412 RID: 42002 RVA: 0x0004CA85 File Offset: 0x0004AC85
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

			' Token: 0x17003FA5 RID: 16293
			' (get) Token: 0x0600A413 RID: 42003 RVA: 0x006FDF00 File Offset: 0x006FC100
			' (set) Token: 0x0600A414 RID: 42004 RVA: 0x0004CA9B File Offset: 0x0004AC9B
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

			' Token: 0x17003FA6 RID: 16294
			' (get) Token: 0x0600A415 RID: 42005 RVA: 0x006FDF50 File Offset: 0x006FC150
			' (set) Token: 0x0600A416 RID: 42006 RVA: 0x0004CAB1 File Offset: 0x0004ACB1
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

			' Token: 0x17003FA7 RID: 16295
			' (get) Token: 0x0600A417 RID: 42007 RVA: 0x006FDFA0 File Offset: 0x006FC1A0
			' (set) Token: 0x0600A418 RID: 42008 RVA: 0x0004CAC7 File Offset: 0x0004ACC7
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

			' Token: 0x17003FA8 RID: 16296
			' (get) Token: 0x0600A419 RID: 42009 RVA: 0x006FDFF0 File Offset: 0x006FC1F0
			' (set) Token: 0x0600A41A RID: 42010 RVA: 0x0004CADD File Offset: 0x0004ACDD
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

			' Token: 0x17003FA9 RID: 16297
			' (get) Token: 0x0600A41B RID: 42011 RVA: 0x006FE040 File Offset: 0x006FC240
			' (set) Token: 0x0600A41C RID: 42012 RVA: 0x0004CAF8 File Offset: 0x0004ACF8
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

			' Token: 0x17003FAA RID: 16298
			' (get) Token: 0x0600A41D RID: 42013 RVA: 0x006FE090 File Offset: 0x006FC290
			' (set) Token: 0x0600A41E RID: 42014 RVA: 0x0004CB13 File Offset: 0x0004AD13
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

			' Token: 0x17003FAB RID: 16299
			' (get) Token: 0x0600A41F RID: 42015 RVA: 0x006FE0E0 File Offset: 0x006FC2E0
			' (set) Token: 0x0600A420 RID: 42016 RVA: 0x0004CB2E File Offset: 0x0004AD2E
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

			' Token: 0x17003FAC RID: 16300
			' (get) Token: 0x0600A421 RID: 42017 RVA: 0x006FE130 File Offset: 0x006FC330
			' (set) Token: 0x0600A422 RID: 42018 RVA: 0x0004CB49 File Offset: 0x0004AD49
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

			' Token: 0x17003FAD RID: 16301
			' (get) Token: 0x0600A423 RID: 42019 RVA: 0x006FE180 File Offset: 0x006FC380
			' (set) Token: 0x0600A424 RID: 42020 RVA: 0x0004CB64 File Offset: 0x0004AD64
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

			' Token: 0x17003FAE RID: 16302
			' (get) Token: 0x0600A425 RID: 42021 RVA: 0x006FE1D0 File Offset: 0x006FC3D0
			' (set) Token: 0x0600A426 RID: 42022 RVA: 0x0004CB7A File Offset: 0x0004AD7A
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

			' Token: 0x17003FAF RID: 16303
			' (get) Token: 0x0600A427 RID: 42023 RVA: 0x006FE220 File Offset: 0x006FC420
			' (set) Token: 0x0600A428 RID: 42024 RVA: 0x0004CB90 File Offset: 0x0004AD90
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

			' Token: 0x17003FB0 RID: 16304
			' (get) Token: 0x0600A429 RID: 42025 RVA: 0x006FE270 File Offset: 0x006FC470
			' (set) Token: 0x0600A42A RID: 42026 RVA: 0x0004CBA6 File Offset: 0x0004ADA6
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

			' Token: 0x17003FB1 RID: 16305
			' (get) Token: 0x0600A42B RID: 42027 RVA: 0x006FE2C0 File Offset: 0x006FC4C0
			' (set) Token: 0x0600A42C RID: 42028 RVA: 0x0004CBBC File Offset: 0x0004ADBC
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

			' Token: 0x17003FB2 RID: 16306
			' (get) Token: 0x0600A42D RID: 42029 RVA: 0x006FE310 File Offset: 0x006FC510
			' (set) Token: 0x0600A42E RID: 42030 RVA: 0x0004CBD2 File Offset: 0x0004ADD2
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

			' Token: 0x17003FB3 RID: 16307
			' (get) Token: 0x0600A42F RID: 42031 RVA: 0x006FE360 File Offset: 0x006FC560
			' (set) Token: 0x0600A430 RID: 42032 RVA: 0x0004CBE8 File Offset: 0x0004ADE8
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

			' Token: 0x17003FB4 RID: 16308
			' (get) Token: 0x0600A431 RID: 42033 RVA: 0x006FE3B0 File Offset: 0x006FC5B0
			' (set) Token: 0x0600A432 RID: 42034 RVA: 0x0004CBFE File Offset: 0x0004ADFE
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

			' Token: 0x17003FB5 RID: 16309
			' (get) Token: 0x0600A433 RID: 42035 RVA: 0x006FE400 File Offset: 0x006FC600
			' (set) Token: 0x0600A434 RID: 42036 RVA: 0x0004CC14 File Offset: 0x0004AE14
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property QrBarcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableP_Transfer.QrBarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'QrBarcode' in table 'P_Transfer' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableP_Transfer.QrBarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17003FB6 RID: 16310
			' (get) Token: 0x0600A435 RID: 42037 RVA: 0x006FE450 File Offset: 0x006FC650
			' (set) Token: 0x0600A436 RID: 42038 RVA: 0x0004CC2A File Offset: 0x0004AE2A
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

			' Token: 0x17003FB7 RID: 16311
			' (get) Token: 0x0600A437 RID: 42039 RVA: 0x006FE4A0 File Offset: 0x006FC6A0
			' (set) Token: 0x0600A438 RID: 42040 RVA: 0x0004CC40 File Offset: 0x0004AE40
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

			' Token: 0x17003FB8 RID: 16312
			' (get) Token: 0x0600A439 RID: 42041 RVA: 0x006FE4F0 File Offset: 0x006FC6F0
			' (set) Token: 0x0600A43A RID: 42042 RVA: 0x0004CC56 File Offset: 0x0004AE56
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

			' Token: 0x17003FB9 RID: 16313
			' (get) Token: 0x0600A43B RID: 42043 RVA: 0x006FE540 File Offset: 0x006FC740
			' (set) Token: 0x0600A43C RID: 42044 RVA: 0x0004CC6C File Offset: 0x0004AE6C
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

			' Token: 0x17003FBA RID: 16314
			' (get) Token: 0x0600A43D RID: 42045 RVA: 0x006FE590 File Offset: 0x006FC790
			' (set) Token: 0x0600A43E RID: 42046 RVA: 0x0004CC82 File Offset: 0x0004AE82
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

			' Token: 0x17003FBB RID: 16315
			' (get) Token: 0x0600A43F RID: 42047 RVA: 0x006FE5E0 File Offset: 0x006FC7E0
			' (set) Token: 0x0600A440 RID: 42048 RVA: 0x0004CC9D File Offset: 0x0004AE9D
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

			' Token: 0x17003FBC RID: 16316
			' (get) Token: 0x0600A441 RID: 42049 RVA: 0x006FE630 File Offset: 0x006FC830
			' (set) Token: 0x0600A442 RID: 42050 RVA: 0x0004CCB3 File Offset: 0x0004AEB3
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

			' Token: 0x17003FBD RID: 16317
			' (get) Token: 0x0600A443 RID: 42051 RVA: 0x006FE680 File Offset: 0x006FC880
			' (set) Token: 0x0600A444 RID: 42052 RVA: 0x0004CCC9 File Offset: 0x0004AEC9
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

			' Token: 0x17003FBE RID: 16318
			' (get) Token: 0x0600A445 RID: 42053 RVA: 0x006FE6D0 File Offset: 0x006FC8D0
			' (set) Token: 0x0600A446 RID: 42054 RVA: 0x0004CCDF File Offset: 0x0004AEDF
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

			' Token: 0x17003FBF RID: 16319
			' (get) Token: 0x0600A447 RID: 42055 RVA: 0x006FE720 File Offset: 0x006FC920
			' (set) Token: 0x0600A448 RID: 42056 RVA: 0x0004CCF5 File Offset: 0x0004AEF5
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

			' Token: 0x17003FC0 RID: 16320
			' (get) Token: 0x0600A449 RID: 42057 RVA: 0x006FE770 File Offset: 0x006FC970
			' (set) Token: 0x0600A44A RID: 42058 RVA: 0x0004CD0B File Offset: 0x0004AF0B
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

			' Token: 0x17003FC1 RID: 16321
			' (get) Token: 0x0600A44B RID: 42059 RVA: 0x006FE7C0 File Offset: 0x006FC9C0
			' (set) Token: 0x0600A44C RID: 42060 RVA: 0x0004CD21 File Offset: 0x0004AF21
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

			' Token: 0x17003FC2 RID: 16322
			' (get) Token: 0x0600A44D RID: 42061 RVA: 0x006FE810 File Offset: 0x006FCA10
			' (set) Token: 0x0600A44E RID: 42062 RVA: 0x0004CD37 File Offset: 0x0004AF37
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

			' Token: 0x0600A44F RID: 42063 RVA: 0x006FE860 File Offset: 0x006FCA60
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIDNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.IDColumn)
			End Function

			' Token: 0x0600A450 RID: 42064 RVA: 0x0004CD4D File Offset: 0x0004AF4D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIDNull()
				MyBase.Item(Me.tableP_Transfer.IDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A451 RID: 42065 RVA: 0x006FE884 File Offset: 0x006FCA84
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ProductCodeColumn)
			End Function

			' Token: 0x0600A452 RID: 42066 RVA: 0x0004CD6C File Offset: 0x0004AF6C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductCodeNull()
				MyBase.Item(Me.tableP_Transfer.ProductCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A453 RID: 42067 RVA: 0x006FE8A8 File Offset: 0x006FCAA8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.BarcodeColumn)
			End Function

			' Token: 0x0600A454 RID: 42068 RVA: 0x0004CD8B File Offset: 0x0004AF8B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableP_Transfer.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A455 RID: 42069 RVA: 0x006FE8CC File Offset: 0x006FCACC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductnameNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ProductnameColumn)
			End Function

			' Token: 0x0600A456 RID: 42070 RVA: 0x0004CDAA File Offset: 0x0004AFAA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductnameNull()
				MyBase.Item(Me.tableP_Transfer.ProductnameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A457 RID: 42071 RVA: 0x006FE8F0 File Offset: 0x006FCAF0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.HSNCodeColumn)
			End Function

			' Token: 0x0600A458 RID: 42072 RVA: 0x0004CDC9 File Offset: 0x0004AFC9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCodeNull()
				MyBase.Item(Me.tableP_Transfer.HSNCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A459 RID: 42073 RVA: 0x006FE914 File Offset: 0x006FCB14
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPartNoNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PartNoColumn)
			End Function

			' Token: 0x0600A45A RID: 42074 RVA: 0x0004CDE8 File Offset: 0x0004AFE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPartNoNull()
				MyBase.Item(Me.tableP_Transfer.PartNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A45B RID: 42075 RVA: 0x006FE938 File Offset: 0x006FCB38
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDescriptionNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.DescriptionColumn)
			End Function

			' Token: 0x0600A45C RID: 42076 RVA: 0x0004CE07 File Offset: 0x0004B007
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDescriptionNull()
				MyBase.Item(Me.tableP_Transfer.DescriptionColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A45D RID: 42077 RVA: 0x006FE95C File Offset: 0x006FCB5C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCostPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.CostPriceColumn)
			End Function

			' Token: 0x0600A45E RID: 42078 RVA: 0x0004CE26 File Offset: 0x0004B026
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCostPriceNull()
				MyBase.Item(Me.tableP_Transfer.CostPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A45F RID: 42079 RVA: 0x006FE980 File Offset: 0x006FCB80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.MRPColumn)
			End Function

			' Token: 0x0600A460 RID: 42080 RVA: 0x0004CE45 File Offset: 0x0004B045
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMRPNull()
				MyBase.Item(Me.tableP_Transfer.MRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A461 RID: 42081 RVA: 0x006FE9A4 File Offset: 0x006FCBA4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSellingPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SellingPriceColumn)
			End Function

			' Token: 0x0600A462 RID: 42082 RVA: 0x0004CE64 File Offset: 0x0004B064
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSellingPriceNull()
				MyBase.Item(Me.tableP_Transfer.SellingPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A463 RID: 42083 RVA: 0x006FE9C8 File Offset: 0x006FCBC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsReorderPointNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ReorderPointColumn)
			End Function

			' Token: 0x0600A464 RID: 42084 RVA: 0x0004CE83 File Offset: 0x0004B083
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetReorderPointNull()
				MyBase.Item(Me.tableP_Transfer.ReorderPointColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A465 RID: 42085 RVA: 0x006FE9EC File Offset: 0x006FCBEC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.DiscountColumn)
			End Function

			' Token: 0x0600A466 RID: 42086 RVA: 0x0004CEA2 File Offset: 0x0004B0A2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountNull()
				MyBase.Item(Me.tableP_Transfer.DiscountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A467 RID: 42087 RVA: 0x006FEA10 File Offset: 0x006FCC10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.CGSTColumn)
			End Function

			' Token: 0x0600A468 RID: 42088 RVA: 0x0004CEC1 File Offset: 0x0004B0C1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTNull()
				MyBase.Item(Me.tableP_Transfer.CGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A469 RID: 42089 RVA: 0x006FEA34 File Offset: 0x006FCC34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SGSTColumn)
			End Function

			' Token: 0x0600A46A RID: 42090 RVA: 0x0004CEE0 File Offset: 0x0004B0E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTNull()
				MyBase.Item(Me.tableP_Transfer.SGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A46B RID: 42091 RVA: 0x006FEA58 File Offset: 0x006FCC58
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.CESSColumn)
			End Function

			' Token: 0x0600A46C RID: 42092 RVA: 0x0004CEFF File Offset: 0x0004B0FF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSNull()
				MyBase.Item(Me.tableP_Transfer.CESSColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A46D RID: 42093 RVA: 0x006FEA7C File Offset: 0x006FCC7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPurchaseUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PurchaseUnitColumn)
			End Function

			' Token: 0x0600A46E RID: 42094 RVA: 0x0004CF1E File Offset: 0x0004B11E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPurchaseUnitNull()
				MyBase.Item(Me.tableP_Transfer.PurchaseUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A46F RID: 42095 RVA: 0x006FEAA0 File Offset: 0x006FCCA0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalesunitNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SalesunitColumn)
			End Function

			' Token: 0x0600A470 RID: 42096 RVA: 0x0004CF3D File Offset: 0x0004B13D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalesunitNull()
				MyBase.Item(Me.tableP_Transfer.SalesunitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A471 RID: 42097 RVA: 0x006FEAC4 File Offset: 0x006FCCC4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalesAltUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SalesAltUnitColumn)
			End Function

			' Token: 0x0600A472 RID: 42098 RVA: 0x0004CF5C File Offset: 0x0004B15C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalesAltUnitNull()
				MyBase.Item(Me.tableP_Transfer.SalesAltUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A473 RID: 42099 RVA: 0x006FEAE8 File Offset: 0x006FCCE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsConvNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ConvColumn)
			End Function

			' Token: 0x0600A474 RID: 42100 RVA: 0x0004CF7B File Offset: 0x0004B17B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetConvNull()
				MyBase.Item(Me.tableP_Transfer.ConvColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A475 RID: 42101 RVA: 0x006FEB0C File Offset: 0x006FCD0C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMinStockNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.MinStockColumn)
			End Function

			' Token: 0x0600A476 RID: 42102 RVA: 0x0004CF9A File Offset: 0x0004B19A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMinStockNull()
				MyBase.Item(Me.tableP_Transfer.MinStockColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A477 RID: 42103 RVA: 0x006FEB30 File Offset: 0x006FCD30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGDownNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.GDownColumn)
			End Function

			' Token: 0x0600A478 RID: 42104 RVA: 0x0004CFB9 File Offset: 0x0004B1B9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGDownNull()
				MyBase.Item(Me.tableP_Transfer.GDownColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A479 RID: 42105 RVA: 0x006FEB54 File Offset: 0x006FCD54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRackNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.RackColumn)
			End Function

			' Token: 0x0600A47A RID: 42106 RVA: 0x0004CFD8 File Offset: 0x0004B1D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRackNull()
				MyBase.Item(Me.tableP_Transfer.RackColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A47B RID: 42107 RVA: 0x006FEB78 File Offset: 0x006FCD78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDefQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.DefQtyColumn)
			End Function

			' Token: 0x0600A47C RID: 42108 RVA: 0x0004CFF7 File Offset: 0x0004B1F7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDefQtyNull()
				MyBase.Item(Me.tableP_Transfer.DefQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A47D RID: 42109 RVA: 0x006FEB9C File Offset: 0x006FCD9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PPriceColumn)
			End Function

			' Token: 0x0600A47E RID: 42110 RVA: 0x0004D016 File Offset: 0x0004B216
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPPriceNull()
				MyBase.Item(Me.tableP_Transfer.PPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A47F RID: 42111 RVA: 0x006FEBC0 File Offset: 0x006FCDC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTemp_StockMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.Temp_StockMRPColumn)
			End Function

			' Token: 0x0600A480 RID: 42112 RVA: 0x0004D035 File Offset: 0x0004B235
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTemp_StockMRPNull()
				MyBase.Item(Me.tableP_Transfer.Temp_StockMRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A481 RID: 42113 RVA: 0x006FEBE4 File Offset: 0x006FCDE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SPriceColumn)
			End Function

			' Token: 0x0600A482 RID: 42114 RVA: 0x0004D054 File Offset: 0x0004B254
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSPriceNull()
				MyBase.Item(Me.tableP_Transfer.SPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A483 RID: 42115 RVA: 0x006FEC08 File Offset: 0x006FCE08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsWPriceNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.WPriceColumn)
			End Function

			' Token: 0x0600A484 RID: 42116 RVA: 0x0004D073 File Offset: 0x0004B273
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetWPriceNull()
				MyBase.Item(Me.tableP_Transfer.WPriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A485 RID: 42117 RVA: 0x006FEC2C File Offset: 0x006FCE2C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBatchNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.BatchColumn)
			End Function

			' Token: 0x0600A486 RID: 42118 RVA: 0x0004D092 File Offset: 0x0004B292
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBatchNull()
				MyBase.Item(Me.tableP_Transfer.BatchColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A487 RID: 42119 RVA: 0x006FEC50 File Offset: 0x006FCE50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMfgdateNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.MfgdateColumn)
			End Function

			' Token: 0x0600A488 RID: 42120 RVA: 0x0004D0B1 File Offset: 0x0004B2B1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMfgdateNull()
				MyBase.Item(Me.tableP_Transfer.MfgdateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A489 RID: 42121 RVA: 0x006FEC74 File Offset: 0x006FCE74
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsExpdateNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ExpdateColumn)
			End Function

			' Token: 0x0600A48A RID: 42122 RVA: 0x0004D0D0 File Offset: 0x0004B2D0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetExpdateNull()
				MyBase.Item(Me.tableP_Transfer.ExpdateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A48B RID: 42123 RVA: 0x006FEC98 File Offset: 0x006FCE98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsColourNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.ColourColumn)
			End Function

			' Token: 0x0600A48C RID: 42124 RVA: 0x0004D0EF File Offset: 0x0004B2EF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetColourNull()
				MyBase.Item(Me.tableP_Transfer.ColourColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A48D RID: 42125 RVA: 0x006FECBC File Offset: 0x006FCEBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSizeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SizeColumn)
			End Function

			' Token: 0x0600A48E RID: 42126 RVA: 0x0004D10E File Offset: 0x0004B30E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSizeNull()
				MyBase.Item(Me.tableP_Transfer.SizeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A48F RID: 42127 RVA: 0x006FECE0 File Offset: 0x006FCEE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIMEI1Null() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.IMEI1Column)
			End Function

			' Token: 0x0600A490 RID: 42128 RVA: 0x0004D12D File Offset: 0x0004B32D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIMEI1Null()
				MyBase.Item(Me.tableP_Transfer.IMEI1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A491 RID: 42129 RVA: 0x006FED04 File Offset: 0x006FCF04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIMEI2Null() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.IMEI2Column)
			End Function

			' Token: 0x0600A492 RID: 42130 RVA: 0x0004D14C File Offset: 0x0004B34C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIMEI2Null()
				MyBase.Item(Me.tableP_Transfer.IMEI2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A493 RID: 42131 RVA: 0x006FED28 File Offset: 0x006FCF28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsStatusNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.StatusColumn)
			End Function

			' Token: 0x0600A494 RID: 42132 RVA: 0x0004D16B File Offset: 0x0004B36B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetStatusNull()
				MyBase.Item(Me.tableP_Transfer.StatusColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A495 RID: 42133 RVA: 0x006FED4C File Offset: 0x006FCF4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQrBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.QrBarcodeColumn)
			End Function

			' Token: 0x0600A496 RID: 42134 RVA: 0x0004D18A File Offset: 0x0004B38A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQrBarcodeNull()
				MyBase.Item(Me.tableP_Transfer.QrBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A497 RID: 42135 RVA: 0x006FED70 File Offset: 0x006FCF70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSuplNameNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SuplNameColumn)
			End Function

			' Token: 0x0600A498 RID: 42136 RVA: 0x0004D1A9 File Offset: 0x0004B3A9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSuplNameNull()
				MyBase.Item(Me.tableP_Transfer.SuplNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A499 RID: 42137 RVA: 0x006FED94 File Offset: 0x006FCF94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTocknNoNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.TocknNoColumn)
			End Function

			' Token: 0x0600A49A RID: 42138 RVA: 0x0004D1C8 File Offset: 0x0004B3C8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTocknNoNull()
				MyBase.Item(Me.tableP_Transfer.TocknNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A49B RID: 42139 RVA: 0x006FEDB8 File Offset: 0x006FCFB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPIDNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PIDColumn)
			End Function

			' Token: 0x0600A49C RID: 42140 RVA: 0x0004D1E7 File Offset: 0x0004B3E7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPIDNull()
				MyBase.Item(Me.tableP_Transfer.PIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A49D RID: 42141 RVA: 0x006FEDDC File Offset: 0x006FCFDC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPStatusNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PStatusColumn)
			End Function

			' Token: 0x0600A49E RID: 42142 RVA: 0x0004D206 File Offset: 0x0004B406
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPStatusNull()
				MyBase.Item(Me.tableP_Transfer.PStatusColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A49F RID: 42143 RVA: 0x006FEE00 File Offset: 0x006FD000
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsT_QtyNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.T_QtyColumn)
			End Function

			' Token: 0x0600A4A0 RID: 42144 RVA: 0x0004D225 File Offset: 0x0004B425
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetT_QtyNull()
				MyBase.Item(Me.tableP_Transfer.T_QtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4A1 RID: 42145 RVA: 0x006FEE24 File Offset: 0x006FD024
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPAdminNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PAdminColumn)
			End Function

			' Token: 0x0600A4A2 RID: 42146 RVA: 0x0004D244 File Offset: 0x0004B444
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPAdminNull()
				MyBase.Item(Me.tableP_Transfer.PAdminColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4A3 RID: 42147 RVA: 0x006FEE48 File Offset: 0x006FD048
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPBranchFromNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PBranchFromColumn)
			End Function

			' Token: 0x0600A4A4 RID: 42148 RVA: 0x0004D263 File Offset: 0x0004B463
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPBranchFromNull()
				MyBase.Item(Me.tableP_Transfer.PBranchFromColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4A5 RID: 42149 RVA: 0x006FEE6C File Offset: 0x006FD06C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPBranchToNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PBranchToColumn)
			End Function

			' Token: 0x0600A4A6 RID: 42150 RVA: 0x0004D282 File Offset: 0x0004B482
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPBranchToNull()
				MyBase.Item(Me.tableP_Transfer.PBranchToColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4A7 RID: 42151 RVA: 0x006FEE90 File Offset: 0x006FD090
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRemarksNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.RemarksColumn)
			End Function

			' Token: 0x0600A4A8 RID: 42152 RVA: 0x0004D2A1 File Offset: 0x0004B4A1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRemarksNull()
				MyBase.Item(Me.tableP_Transfer.RemarksColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4A9 RID: 42153 RVA: 0x006FEEB4 File Offset: 0x006FD0B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPostDateNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.PostDateColumn)
			End Function

			' Token: 0x0600A4AA RID: 42154 RVA: 0x0004D2C0 File Offset: 0x0004B4C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPostDateNull()
				MyBase.Item(Me.tableP_Transfer.PostDateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4AB RID: 42155 RVA: 0x006FEED8 File Offset: 0x006FD0D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsbranchcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.branchcodeColumn)
			End Function

			' Token: 0x0600A4AC RID: 42156 RVA: 0x0004D2DF File Offset: 0x0004B4DF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetbranchcodeNull()
				MyBase.Item(Me.tableP_Transfer.branchcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4AD RID: 42157 RVA: 0x006FEEFC File Offset: 0x006FD0FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCategoryNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.CategoryColumn)
			End Function

			' Token: 0x0600A4AE RID: 42158 RVA: 0x0004D2FE File Offset: 0x0004B4FE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCategoryNull()
				MyBase.Item(Me.tableP_Transfer.CategoryColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4AF RID: 42159 RVA: 0x006FEF20 File Offset: 0x006FD120
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSubCategoryNameNull() As Boolean
				Return MyBase.IsNull(Me.tableP_Transfer.SubCategoryNameColumn)
			End Function

			' Token: 0x0600A4B0 RID: 42160 RVA: 0x0004D31D File Offset: 0x0004B51D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSubCategoryNameNull()
				MyBase.Item(Me.tableP_Transfer.SubCategoryNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0400459E RID: 17822
			Private tableP_Transfer As BarcodeDataSet.P_TransferDataTable
		End Class

		' Token: 0x02000264 RID: 612
		Public Class DataTable11Row
			Inherits DataRow

			' Token: 0x0600A4B1 RID: 42161 RVA: 0x0004D33C File Offset: 0x0004B53C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable11 = CType(MyBase.Table, BarcodeDataSet.DataTable11DataTable)
			End Sub

			' Token: 0x17003FC3 RID: 16323
			' (get) Token: 0x0600A4B2 RID: 42162 RVA: 0x006FEF44 File Offset: 0x006FD144
			' (set) Token: 0x0600A4B3 RID: 42163 RVA: 0x0004D358 File Offset: 0x0004B558
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable11.ProductIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductID' in table 'DataTable11' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable11.ProductIDColumn) = value
				End Set
			End Property

			' Token: 0x17003FC4 RID: 16324
			' (get) Token: 0x0600A4B4 RID: 42164 RVA: 0x006FEF94 File Offset: 0x006FD194
			' (set) Token: 0x0600A4B5 RID: 42165 RVA: 0x0004D36E File Offset: 0x0004B56E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Qty As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable11.QtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Qty' in table 'DataTable11' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable11.QtyColumn) = value
				End Set
			End Property

			' Token: 0x17003FC5 RID: 16325
			' (get) Token: 0x0600A4B6 RID: 42166 RVA: 0x006FEFE4 File Offset: 0x006FD1E4
			' (set) Token: 0x0600A4B7 RID: 42167 RVA: 0x0004D389 File Offset: 0x0004B589
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MainUnit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable11.MainUnitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MainUnit' in table 'DataTable11' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable11.MainUnitColumn) = value
				End Set
			End Property

			' Token: 0x17003FC6 RID: 16326
			' (get) Token: 0x0600A4B8 RID: 42168 RVA: 0x006FF034 File Offset: 0x006FD234
			' (set) Token: 0x0600A4B9 RID: 42169 RVA: 0x0004D39F File Offset: 0x0004B59F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SalesRate As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable11.SalesRateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SalesRate' in table 'DataTable11' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable11.SalesRateColumn) = value
				End Set
			End Property

			' Token: 0x17003FC7 RID: 16327
			' (get) Token: 0x0600A4BA RID: 42170 RVA: 0x006FF084 File Offset: 0x006FD284
			' (set) Token: 0x0600A4BB RID: 42171 RVA: 0x0004D3BA File Offset: 0x0004B5BA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property DiscountPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable11.DiscountPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'DiscountPer' in table 'DataTable11' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable11.DiscountPerColumn) = value
				End Set
			End Property

			' Token: 0x17003FC8 RID: 16328
			' (get) Token: 0x0600A4BC RID: 42172 RVA: 0x006FF0D4 File Offset: 0x006FD2D4
			' (set) Token: 0x0600A4BD RID: 42173 RVA: 0x0004D3D5 File Offset: 0x0004B5D5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Discount As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable11.DiscountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Discount' in table 'DataTable11' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable11.DiscountColumn) = value
				End Set
			End Property

			' Token: 0x17003FC9 RID: 16329
			' (get) Token: 0x0600A4BE RID: 42174 RVA: 0x006FF124 File Offset: 0x006FD324
			' (set) Token: 0x0600A4BF RID: 42175 RVA: 0x0004D3F0 File Offset: 0x0004B5F0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TotalAmount As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable11.TotalAmountColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TotalAmount' in table 'DataTable11' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable11.TotalAmountColumn) = value
				End Set
			End Property

			' Token: 0x17003FCA RID: 16330
			' (get) Token: 0x0600A4C0 RID: 42176 RVA: 0x006FF174 File Offset: 0x006FD374
			' (set) Token: 0x0600A4C1 RID: 42177 RVA: 0x0004D40B File Offset: 0x0004B60B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TotalMRP As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable11.TotalMRPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TotalMRP' in table 'DataTable11' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable11.TotalMRPColumn) = value
				End Set
			End Property

			' Token: 0x0600A4C2 RID: 42178 RVA: 0x006FF1C4 File Offset: 0x006FD3C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductIDNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable11.ProductIDColumn)
			End Function

			' Token: 0x0600A4C3 RID: 42179 RVA: 0x0004D426 File Offset: 0x0004B626
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductIDNull()
				MyBase.Item(Me.tableDataTable11.ProductIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4C4 RID: 42180 RVA: 0x006FF1E8 File Offset: 0x006FD3E8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable11.QtyColumn)
			End Function

			' Token: 0x0600A4C5 RID: 42181 RVA: 0x0004D445 File Offset: 0x0004B645
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQtyNull()
				MyBase.Item(Me.tableDataTable11.QtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4C6 RID: 42182 RVA: 0x006FF20C File Offset: 0x006FD40C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMainUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable11.MainUnitColumn)
			End Function

			' Token: 0x0600A4C7 RID: 42183 RVA: 0x0004D464 File Offset: 0x0004B664
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMainUnitNull()
				MyBase.Item(Me.tableDataTable11.MainUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4C8 RID: 42184 RVA: 0x006FF230 File Offset: 0x006FD430
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalesRateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable11.SalesRateColumn)
			End Function

			' Token: 0x0600A4C9 RID: 42185 RVA: 0x0004D483 File Offset: 0x0004B683
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalesRateNull()
				MyBase.Item(Me.tableDataTable11.SalesRateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4CA RID: 42186 RVA: 0x006FF254 File Offset: 0x006FD454
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable11.DiscountPerColumn)
			End Function

			' Token: 0x0600A4CB RID: 42187 RVA: 0x0004D4A2 File Offset: 0x0004B6A2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountPerNull()
				MyBase.Item(Me.tableDataTable11.DiscountPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4CC RID: 42188 RVA: 0x006FF278 File Offset: 0x006FD478
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscountNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable11.DiscountColumn)
			End Function

			' Token: 0x0600A4CD RID: 42189 RVA: 0x0004D4C1 File Offset: 0x0004B6C1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscountNull()
				MyBase.Item(Me.tableDataTable11.DiscountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4CE RID: 42190 RVA: 0x006FF29C File Offset: 0x006FD49C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTotalAmountNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable11.TotalAmountColumn)
			End Function

			' Token: 0x0600A4CF RID: 42191 RVA: 0x0004D4E0 File Offset: 0x0004B6E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTotalAmountNull()
				MyBase.Item(Me.tableDataTable11.TotalAmountColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A4D0 RID: 42192 RVA: 0x006FF2C0 File Offset: 0x006FD4C0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTotalMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable11.TotalMRPColumn)
			End Function

			' Token: 0x0600A4D1 RID: 42193 RVA: 0x0004D4FF File Offset: 0x0004B6FF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTotalMRPNull()
				MyBase.Item(Me.tableDataTable11.TotalMRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0400459F RID: 17823
			Private tableDataTable11 As BarcodeDataSet.DataTable11DataTable
		End Class

		' Token: 0x02000265 RID: 613
		Public Class SaleDRow
			Inherits DataRow

			' Token: 0x0600A4D2 RID: 42194 RVA: 0x0004D51E File Offset: 0x0004B71E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableSaleD = CType(MyBase.Table, BarcodeDataSet.SaleDDataTable)
			End Sub

			' Token: 0x17003FCB RID: 16331
			' (get) Token: 0x0600A4D3 RID: 42195 RVA: 0x006FF2E4 File Offset: 0x006FD4E4
			' (set) Token: 0x0600A4D4 RID: 42196 RVA: 0x0004D53A File Offset: 0x0004B73A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PCode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.PCodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PCode' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.PCodeColumn) = value
				End Set
			End Property

			' Token: 0x17003FCC RID: 16332
			' (get) Token: 0x0600A4D5 RID: 42197 RVA: 0x006FF334 File Offset: 0x006FD534
			' (set) Token: 0x0600A4D6 RID: 42198 RVA: 0x0004D550 File Offset: 0x0004B750
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.ProductNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductName' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.ProductNameColumn) = value
				End Set
			End Property

			' Token: 0x17003FCD RID: 16333
			' (get) Token: 0x0600A4D7 RID: 42199 RVA: 0x006FF384 File Offset: 0x006FD584
			' (set) Token: 0x0600A4D8 RID: 42200 RVA: 0x0004D566 File Offset: 0x0004B766
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Category As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.CategoryColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Category' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.CategoryColumn) = value
				End Set
			End Property

			' Token: 0x17003FCE RID: 16334
			' (get) Token: 0x0600A4D9 RID: 42201 RVA: 0x006FF3D4 File Offset: 0x006FD5D4
			' (set) Token: 0x0600A4DA RID: 42202 RVA: 0x0004D57C File Offset: 0x0004B77C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Barcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.BarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Barcode' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.BarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17003FCF RID: 16335
			' (get) Token: 0x0600A4DB RID: 42203 RVA: 0x006FF424 File Offset: 0x006FD624
			' (set) Token: 0x0600A4DC RID: 42204 RVA: 0x0004D592 File Offset: 0x0004B792
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AvlQty As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.AvlQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AvlQty' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.AvlQtyColumn) = value
				End Set
			End Property

			' Token: 0x17003FD0 RID: 16336
			' (get) Token: 0x0600A4DD RID: 42205 RVA: 0x006FF474 File Offset: 0x006FD674
			' (set) Token: 0x0600A4DE RID: 42206 RVA: 0x0004D5A8 File Offset: 0x0004B7A8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property NoCopy As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.NoCopyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'NoCopy' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.NoCopyColumn) = value
				End Set
			End Property

			' Token: 0x17003FD1 RID: 16337
			' (get) Token: 0x0600A4DF RID: 42207 RVA: 0x006FF4C4 File Offset: 0x006FD6C4
			' (set) Token: 0x0600A4E0 RID: 42208 RVA: 0x0004D5BE File Offset: 0x0004B7BE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PartNo As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.PartNoColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PartNo' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.PartNoColumn) = value
				End Set
			End Property

			' Token: 0x17003FD2 RID: 16338
			' (get) Token: 0x0600A4E1 RID: 42209 RVA: 0x006FF514 File Offset: 0x006FD714
			' (set) Token: 0x0600A4E2 RID: 42210 RVA: 0x0004D5D4 File Offset: 0x0004B7D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property HSNC As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.HSNCColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'HSNC' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.HSNCColumn) = value
				End Set
			End Property

			' Token: 0x17003FD3 RID: 16339
			' (get) Token: 0x0600A4E3 RID: 42211 RVA: 0x006FF564 File Offset: 0x006FD764
			' (set) Token: 0x0600A4E4 RID: 42212 RVA: 0x0004D5EA File Offset: 0x0004B7EA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MRP As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.MRPColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MRP' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.MRPColumn) = value
				End Set
			End Property

			' Token: 0x17003FD4 RID: 16340
			' (get) Token: 0x0600A4E5 RID: 42213 RVA: 0x006FF5B4 File Offset: 0x006FD7B4
			' (set) Token: 0x0600A4E6 RID: 42214 RVA: 0x0004D600 File Offset: 0x0004B800
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SalePrice As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.SalePriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SalePrice' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.SalePriceColumn) = value
				End Set
			End Property

			' Token: 0x17003FD5 RID: 16341
			' (get) Token: 0x0600A4E7 RID: 42215 RVA: 0x006FF604 File Offset: 0x006FD804
			' (set) Token: 0x0600A4E8 RID: 42216 RVA: 0x0004D616 File Offset: 0x0004B816
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property WholesalePrice As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.WholesalePriceColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'WholesalePrice' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.WholesalePriceColumn) = value
				End Set
			End Property

			' Token: 0x17003FD6 RID: 16342
			' (get) Token: 0x0600A4E9 RID: 42217 RVA: 0x006FF654 File Offset: 0x006FD854
			' (set) Token: 0x0600A4EA RID: 42218 RVA: 0x0004D62C File Offset: 0x0004B82C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Batch As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.BatchColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Batch' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.BatchColumn) = value
				End Set
			End Property

			' Token: 0x17003FD7 RID: 16343
			' (get) Token: 0x0600A4EB RID: 42219 RVA: 0x006FF6A4 File Offset: 0x006FD8A4
			' (set) Token: 0x0600A4EC RID: 42220 RVA: 0x0004D642 File Offset: 0x0004B842
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Mfg As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.MfgColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Mfg' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.MfgColumn) = value
				End Set
			End Property

			' Token: 0x17003FD8 RID: 16344
			' (get) Token: 0x0600A4ED RID: 42221 RVA: 0x006FF6F4 File Offset: 0x006FD8F4
			' (set) Token: 0x0600A4EE RID: 42222 RVA: 0x0004D658 File Offset: 0x0004B858
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Exp As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.ExpColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Exp' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.ExpColumn) = value
				End Set
			End Property

			' Token: 0x17003FD9 RID: 16345
			' (get) Token: 0x0600A4EF RID: 42223 RVA: 0x006FF744 File Offset: 0x006FD944
			' (set) Token: 0x0600A4F0 RID: 42224 RVA: 0x0004D66E File Offset: 0x0004B86E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Size As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.SizeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Size' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.SizeColumn) = value
				End Set
			End Property

			' Token: 0x17003FDA RID: 16346
			' (get) Token: 0x0600A4F1 RID: 42225 RVA: 0x006FF794 File Offset: 0x006FD994
			' (set) Token: 0x0600A4F2 RID: 42226 RVA: 0x0004D684 File Offset: 0x0004B884
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Colour As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.ColourColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Colour' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.ColourColumn) = value
				End Set
			End Property

			' Token: 0x17003FDB RID: 16347
			' (get) Token: 0x0600A4F3 RID: 42227 RVA: 0x006FF7E4 File Offset: 0x006FD9E4
			' (set) Token: 0x0600A4F4 RID: 42228 RVA: 0x0004D69A File Offset: 0x0004B89A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property GST As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.GSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'GST' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.GSTColumn) = value
				End Set
			End Property

			' Token: 0x17003FDC RID: 16348
			' (get) Token: 0x0600A4F5 RID: 42229 RVA: 0x006FF834 File Offset: 0x006FDA34
			' (set) Token: 0x0600A4F6 RID: 42230 RVA: 0x0004D6B0 File Offset: 0x0004B8B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PurInv As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.PurInvColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PurInv' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.PurInvColumn) = value
				End Set
			End Property

			' Token: 0x17003FDD RID: 16349
			' (get) Token: 0x0600A4F7 RID: 42231 RVA: 0x006FF884 File Offset: 0x006FDA84
			' (set) Token: 0x0600A4F8 RID: 42232 RVA: 0x0004D6C6 File Offset: 0x0004B8C6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IMEI1 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.IMEI1Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IMEI1' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.IMEI1Column) = value
				End Set
			End Property

			' Token: 0x17003FDE RID: 16350
			' (get) Token: 0x0600A4F9 RID: 42233 RVA: 0x006FF8D4 File Offset: 0x006FDAD4
			' (set) Token: 0x0600A4FA RID: 42234 RVA: 0x0004D6DC File Offset: 0x0004B8DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IMEI2 As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.IMEI2Column))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IMEI2' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.IMEI2Column) = value
				End Set
			End Property

			' Token: 0x17003FDF RID: 16351
			' (get) Token: 0x0600A4FB RID: 42235 RVA: 0x006FF924 File Offset: 0x006FDB24
			' (set) Token: 0x0600A4FC RID: 42236 RVA: 0x0004D6F2 File Offset: 0x0004B8F2
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property QrBarcode As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableSaleD.QrBarcodeColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'QrBarcode' in table 'SaleD' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableSaleD.QrBarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17003FE0 RID: 16352
			' (get) Token: 0x0600A4FD RID: 42237 RVA: 0x006FF974 File Offset: 0x006FDB74
			' (set) Token: 0x0600A4FE RID: 42238 RVA: 0x0004D708 File Offset: 0x0004B908
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CBarcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableSaleD.CBarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CBarcode' in table 'SaleD' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableSaleD.CBarcodeColumn) = value
				End Set
			End Property

			' Token: 0x0600A4FF RID: 42239 RVA: 0x006FF9C4 File Offset: 0x006FDBC4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPCodeNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.PCodeColumn)
			End Function

			' Token: 0x0600A500 RID: 42240 RVA: 0x0004D71E File Offset: 0x0004B91E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPCodeNull()
				MyBase.Item(Me.tableSaleD.PCodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A501 RID: 42241 RVA: 0x006FF9E8 File Offset: 0x006FDBE8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductNameNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.ProductNameColumn)
			End Function

			' Token: 0x0600A502 RID: 42242 RVA: 0x0004D73D File Offset: 0x0004B93D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductNameNull()
				MyBase.Item(Me.tableSaleD.ProductNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A503 RID: 42243 RVA: 0x006FFA0C File Offset: 0x006FDC0C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCategoryNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.CategoryColumn)
			End Function

			' Token: 0x0600A504 RID: 42244 RVA: 0x0004D75C File Offset: 0x0004B95C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCategoryNull()
				MyBase.Item(Me.tableSaleD.CategoryColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A505 RID: 42245 RVA: 0x006FFA30 File Offset: 0x006FDC30
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.BarcodeColumn)
			End Function

			' Token: 0x0600A506 RID: 42246 RVA: 0x0004D77B File Offset: 0x0004B97B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableSaleD.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A507 RID: 42247 RVA: 0x006FFA54 File Offset: 0x006FDC54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAvlQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.AvlQtyColumn)
			End Function

			' Token: 0x0600A508 RID: 42248 RVA: 0x0004D79A File Offset: 0x0004B99A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAvlQtyNull()
				MyBase.Item(Me.tableSaleD.AvlQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A509 RID: 42249 RVA: 0x006FFA78 File Offset: 0x006FDC78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsNoCopyNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.NoCopyColumn)
			End Function

			' Token: 0x0600A50A RID: 42250 RVA: 0x0004D7B9 File Offset: 0x0004B9B9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetNoCopyNull()
				MyBase.Item(Me.tableSaleD.NoCopyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A50B RID: 42251 RVA: 0x006FFA9C File Offset: 0x006FDC9C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPartNoNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.PartNoColumn)
			End Function

			' Token: 0x0600A50C RID: 42252 RVA: 0x0004D7D8 File Offset: 0x0004B9D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPartNoNull()
				MyBase.Item(Me.tableSaleD.PartNoColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A50D RID: 42253 RVA: 0x006FFAC0 File Offset: 0x006FDCC0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.HSNCColumn)
			End Function

			' Token: 0x0600A50E RID: 42254 RVA: 0x0004D7F7 File Offset: 0x0004B9F7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCNull()
				MyBase.Item(Me.tableSaleD.HSNCColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A50F RID: 42255 RVA: 0x006FFAE4 File Offset: 0x006FDCE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMRPNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.MRPColumn)
			End Function

			' Token: 0x0600A510 RID: 42256 RVA: 0x0004D816 File Offset: 0x0004BA16
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMRPNull()
				MyBase.Item(Me.tableSaleD.MRPColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A511 RID: 42257 RVA: 0x006FFB08 File Offset: 0x006FDD08
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSalePriceNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.SalePriceColumn)
			End Function

			' Token: 0x0600A512 RID: 42258 RVA: 0x0004D835 File Offset: 0x0004BA35
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSalePriceNull()
				MyBase.Item(Me.tableSaleD.SalePriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A513 RID: 42259 RVA: 0x006FFB2C File Offset: 0x006FDD2C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsWholesalePriceNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.WholesalePriceColumn)
			End Function

			' Token: 0x0600A514 RID: 42260 RVA: 0x0004D854 File Offset: 0x0004BA54
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetWholesalePriceNull()
				MyBase.Item(Me.tableSaleD.WholesalePriceColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A515 RID: 42261 RVA: 0x006FFB50 File Offset: 0x006FDD50
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBatchNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.BatchColumn)
			End Function

			' Token: 0x0600A516 RID: 42262 RVA: 0x0004D873 File Offset: 0x0004BA73
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBatchNull()
				MyBase.Item(Me.tableSaleD.BatchColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A517 RID: 42263 RVA: 0x006FFB74 File Offset: 0x006FDD74
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMfgNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.MfgColumn)
			End Function

			' Token: 0x0600A518 RID: 42264 RVA: 0x0004D892 File Offset: 0x0004BA92
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMfgNull()
				MyBase.Item(Me.tableSaleD.MfgColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A519 RID: 42265 RVA: 0x006FFB98 File Offset: 0x006FDD98
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsExpNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.ExpColumn)
			End Function

			' Token: 0x0600A51A RID: 42266 RVA: 0x0004D8B1 File Offset: 0x0004BAB1
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetExpNull()
				MyBase.Item(Me.tableSaleD.ExpColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A51B RID: 42267 RVA: 0x006FFBBC File Offset: 0x006FDDBC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSizeNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.SizeColumn)
			End Function

			' Token: 0x0600A51C RID: 42268 RVA: 0x0004D8D0 File Offset: 0x0004BAD0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSizeNull()
				MyBase.Item(Me.tableSaleD.SizeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A51D RID: 42269 RVA: 0x006FFBE0 File Offset: 0x006FDDE0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsColourNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.ColourColumn)
			End Function

			' Token: 0x0600A51E RID: 42270 RVA: 0x0004D8EF File Offset: 0x0004BAEF
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetColourNull()
				MyBase.Item(Me.tableSaleD.ColourColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A51F RID: 42271 RVA: 0x006FFC04 File Offset: 0x006FDE04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.GSTColumn)
			End Function

			' Token: 0x0600A520 RID: 42272 RVA: 0x0004D90E File Offset: 0x0004BB0E
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetGSTNull()
				MyBase.Item(Me.tableSaleD.GSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A521 RID: 42273 RVA: 0x006FFC28 File Offset: 0x006FDE28
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPurInvNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.PurInvColumn)
			End Function

			' Token: 0x0600A522 RID: 42274 RVA: 0x0004D92D File Offset: 0x0004BB2D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPurInvNull()
				MyBase.Item(Me.tableSaleD.PurInvColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A523 RID: 42275 RVA: 0x006FFC4C File Offset: 0x006FDE4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIMEI1Null() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.IMEI1Column)
			End Function

			' Token: 0x0600A524 RID: 42276 RVA: 0x0004D94C File Offset: 0x0004BB4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIMEI1Null()
				MyBase.Item(Me.tableSaleD.IMEI1Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A525 RID: 42277 RVA: 0x006FFC70 File Offset: 0x006FDE70
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIMEI2Null() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.IMEI2Column)
			End Function

			' Token: 0x0600A526 RID: 42278 RVA: 0x0004D96B File Offset: 0x0004BB6B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIMEI2Null()
				MyBase.Item(Me.tableSaleD.IMEI2Column) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A527 RID: 42279 RVA: 0x006FFC94 File Offset: 0x006FDE94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsQrBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.QrBarcodeColumn)
			End Function

			' Token: 0x0600A528 RID: 42280 RVA: 0x0004D98A File Offset: 0x0004BB8A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetQrBarcodeNull()
				MyBase.Item(Me.tableSaleD.QrBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A529 RID: 42281 RVA: 0x006FFCB8 File Offset: 0x006FDEB8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableSaleD.CBarcodeColumn)
			End Function

			' Token: 0x0600A52A RID: 42282 RVA: 0x0004D9A9 File Offset: 0x0004BBA9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCBarcodeNull()
				MyBase.Item(Me.tableSaleD.CBarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040045A0 RID: 17824
			Private tableSaleD As BarcodeDataSet.SaleDDataTable
		End Class

		' Token: 0x02000266 RID: 614
		Public Class DataTable3Row
			Inherits DataRow

			' Token: 0x0600A52B RID: 42283 RVA: 0x0004D9C8 File Offset: 0x0004BBC8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable3 = CType(MyBase.Table, BarcodeDataSet.DataTable3DataTable)
			End Sub

			' Token: 0x17003FE1 RID: 16353
			' (get) Token: 0x0600A52C RID: 42284 RVA: 0x006FFCDC File Offset: 0x006FDEDC
			' (set) Token: 0x0600A52D RID: 42285 RVA: 0x0004D9E4 File Offset: 0x0004BBE4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PID As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable3.PIDColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PID' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable3.PIDColumn) = value
				End Set
			End Property

			' Token: 0x17003FE2 RID: 16354
			' (get) Token: 0x0600A52E RID: 42286 RVA: 0x006FFD2C File Offset: 0x006FDF2C
			' (set) Token: 0x0600A52F RID: 42287 RVA: 0x0004D9FA File Offset: 0x0004BBFA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property HSNC As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable3.HSNCColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'HSNC' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable3.HSNCColumn) = value
				End Set
			End Property

			' Token: 0x17003FE3 RID: 16355
			' (get) Token: 0x0600A530 RID: 42288 RVA: 0x006FFD7C File Offset: 0x006FDF7C
			' (set) Token: 0x0600A531 RID: 42289 RVA: 0x0004DA10 File Offset: 0x0004BC10
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property ProductName As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable3.ProductNameColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'ProductName' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable3.ProductNameColumn) = value
				End Set
			End Property

			' Token: 0x17003FE4 RID: 16356
			' (get) Token: 0x0600A532 RID: 42290 RVA: 0x006FFDCC File Offset: 0x006FDFCC
			' (set) Token: 0x0600A533 RID: 42291 RVA: 0x0004DA26 File Offset: 0x0004BC26
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Barcode As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable3.BarcodeColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Barcode' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable3.BarcodeColumn) = value
				End Set
			End Property

			' Token: 0x17003FE5 RID: 16357
			' (get) Token: 0x0600A534 RID: 42292 RVA: 0x006FFE1C File Offset: 0x006FE01C
			' (set) Token: 0x0600A535 RID: 42293 RVA: 0x0004DA3C File Offset: 0x0004BC3C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MainQty As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable3.MainQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MainQty' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable3.MainQtyColumn) = value
				End Set
			End Property

			' Token: 0x17003FE6 RID: 16358
			' (get) Token: 0x0600A536 RID: 42294 RVA: 0x006FFE6C File Offset: 0x006FE06C
			' (set) Token: 0x0600A537 RID: 42295 RVA: 0x0004DA52 File Offset: 0x0004BC52
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Rate As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.RateColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Rate' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.RateColumn) = value
				End Set
			End Property

			' Token: 0x17003FE7 RID: 16359
			' (get) Token: 0x0600A538 RID: 42296 RVA: 0x006FFEBC File Offset: 0x006FE0BC
			' (set) Token: 0x0600A539 RID: 42297 RVA: 0x0004DA6D File Offset: 0x0004BC6D
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property DiscPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.DiscPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'DiscPer' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.DiscPerColumn) = value
				End Set
			End Property

			' Token: 0x17003FE8 RID: 16360
			' (get) Token: 0x0600A53A RID: 42298 RVA: 0x006FFF0C File Offset: 0x006FE10C
			' (set) Token: 0x0600A53B RID: 42299 RVA: 0x0004DA88 File Offset: 0x0004BC88
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Disc As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.DiscColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Disc' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.DiscColumn) = value
				End Set
			End Property

			' Token: 0x17003FE9 RID: 16361
			' (get) Token: 0x0600A53C RID: 42300 RVA: 0x006FFF5C File Offset: 0x006FE15C
			' (set) Token: 0x0600A53D RID: 42301 RVA: 0x0004DAA3 File Offset: 0x0004BCA3
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGSTPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.CGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGSTPer' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.CGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x17003FEA RID: 16362
			' (get) Token: 0x0600A53E RID: 42302 RVA: 0x006FFFAC File Offset: 0x006FE1AC
			' (set) Token: 0x0600A53F RID: 42303 RVA: 0x0004DABE File Offset: 0x0004BCBE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CGST As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.CGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CGST' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.CGSTColumn) = value
				End Set
			End Property

			' Token: 0x17003FEB RID: 16363
			' (get) Token: 0x0600A540 RID: 42304 RVA: 0x006FFFFC File Offset: 0x006FE1FC
			' (set) Token: 0x0600A541 RID: 42305 RVA: 0x0004DAD9 File Offset: 0x0004BCD9
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGSTPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.SGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGSTPer' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.SGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x17003FEC RID: 16364
			' (get) Token: 0x0600A542 RID: 42306 RVA: 0x0070004C File Offset: 0x006FE24C
			' (set) Token: 0x0600A543 RID: 42307 RVA: 0x0004DAF4 File Offset: 0x0004BCF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property SGST As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.SGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'SGST' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.SGSTColumn) = value
				End Set
			End Property

			' Token: 0x17003FED RID: 16365
			' (get) Token: 0x0600A544 RID: 42308 RVA: 0x0070009C File Offset: 0x006FE29C
			' (set) Token: 0x0600A545 RID: 42309 RVA: 0x0004DB0F File Offset: 0x0004BD0F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGSTPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.IGSTPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGSTPer' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.IGSTPerColumn) = value
				End Set
			End Property

			' Token: 0x17003FEE RID: 16366
			' (get) Token: 0x0600A546 RID: 42310 RVA: 0x007000EC File Offset: 0x006FE2EC
			' (set) Token: 0x0600A547 RID: 42311 RVA: 0x0004DB2A File Offset: 0x0004BD2A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property IGST As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.IGSTColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'IGST' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.IGSTColumn) = value
				End Set
			End Property

			' Token: 0x17003FEF RID: 16367
			' (get) Token: 0x0600A548 RID: 42312 RVA: 0x0070013C File Offset: 0x006FE33C
			' (set) Token: 0x0600A549 RID: 42313 RVA: 0x0004DB45 File Offset: 0x0004BD45
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESSPer As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.CESSPerColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESSPer' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.CESSPerColumn) = value
				End Set
			End Property

			' Token: 0x17003FF0 RID: 16368
			' (get) Token: 0x0600A54A RID: 42314 RVA: 0x0070018C File Offset: 0x006FE38C
			' (set) Token: 0x0600A54B RID: 42315 RVA: 0x0004DB60 File Offset: 0x0004BD60
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property CESS As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.CESSColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'CESS' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.CESSColumn) = value
				End Set
			End Property

			' Token: 0x17003FF1 RID: 16369
			' (get) Token: 0x0600A54C RID: 42316 RVA: 0x007001DC File Offset: 0x006FE3DC
			' (set) Token: 0x0600A54D RID: 42317 RVA: 0x0004DB7B File Offset: 0x0004BD7B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Total As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable3.TotalColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Total' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable3.TotalColumn) = value
				End Set
			End Property

			' Token: 0x17003FF2 RID: 16370
			' (get) Token: 0x0600A54E RID: 42318 RVA: 0x0070022C File Offset: 0x006FE42C
			' (set) Token: 0x0600A54F RID: 42319 RVA: 0x0004DB91 File Offset: 0x0004BD91
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AltQty As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable3.AltQtyColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AltQty' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable3.AltQtyColumn) = value
				End Set
			End Property

			' Token: 0x17003FF3 RID: 16371
			' (get) Token: 0x0600A550 RID: 42320 RVA: 0x0070027C File Offset: 0x006FE47C
			' (set) Token: 0x0600A551 RID: 42321 RVA: 0x0004DBA7 File Offset: 0x0004BDA7
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property AltUnit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable3.AltUnitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'AltUnit' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable3.AltUnitColumn) = value
				End Set
			End Property

			' Token: 0x17003FF4 RID: 16372
			' (get) Token: 0x0600A552 RID: 42322 RVA: 0x007002CC File Offset: 0x006FE4CC
			' (set) Token: 0x0600A553 RID: 42323 RVA: 0x0004DBBD File Offset: 0x0004BDBD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property TaxableAmt As Double
				Get
					Dim num As Double
					Try
						num = Conversions.ToDouble(MyBase.Item(Me.tableDataTable3.TaxableAmtColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'TaxableAmt' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return num
				End Get
				Set(value As Double)
					MyBase.Item(Me.tableDataTable3.TaxableAmtColumn) = value
				End Set
			End Property

			' Token: 0x17003FF5 RID: 16373
			' (get) Token: 0x0600A554 RID: 42324 RVA: 0x0070031C File Offset: 0x006FE51C
			' (set) Token: 0x0600A555 RID: 42325 RVA: 0x0004DBD8 File Offset: 0x0004BDD8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property MainUnit As String
				Get
					Dim text As String
					Try
						text = Conversions.ToString(MyBase.Item(Me.tableDataTable3.MainUnitColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'MainUnit' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return text
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable3.MainUnitColumn) = value
				End Set
			End Property

			' Token: 0x17003FF6 RID: 16374
			' (get) Token: 0x0600A556 RID: 42326 RVA: 0x0070036C File Offset: 0x006FE56C
			' (set) Token: 0x0600A557 RID: 42327 RVA: 0x0004DBEE File Offset: 0x0004BDEE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property PImage As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable3.PImageColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'PImage' in table 'DataTable3' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable3.PImageColumn) = value
				End Set
			End Property

			' Token: 0x0600A558 RID: 42328 RVA: 0x007003BC File Offset: 0x006FE5BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPIDNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.PIDColumn)
			End Function

			' Token: 0x0600A559 RID: 42329 RVA: 0x0004DC04 File Offset: 0x0004BE04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPIDNull()
				MyBase.Item(Me.tableDataTable3.PIDColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A55A RID: 42330 RVA: 0x007003E0 File Offset: 0x006FE5E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsHSNCNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.HSNCColumn)
			End Function

			' Token: 0x0600A55B RID: 42331 RVA: 0x0004DC23 File Offset: 0x0004BE23
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetHSNCNull()
				MyBase.Item(Me.tableDataTable3.HSNCColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A55C RID: 42332 RVA: 0x00700404 File Offset: 0x006FE604
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsProductNameNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.ProductNameColumn)
			End Function

			' Token: 0x0600A55D RID: 42333 RVA: 0x0004DC42 File Offset: 0x0004BE42
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetProductNameNull()
				MyBase.Item(Me.tableDataTable3.ProductNameColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A55E RID: 42334 RVA: 0x00700428 File Offset: 0x006FE628
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsBarcodeNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.BarcodeColumn)
			End Function

			' Token: 0x0600A55F RID: 42335 RVA: 0x0004DC61 File Offset: 0x0004BE61
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetBarcodeNull()
				MyBase.Item(Me.tableDataTable3.BarcodeColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A560 RID: 42336 RVA: 0x0070044C File Offset: 0x006FE64C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMainQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.MainQtyColumn)
			End Function

			' Token: 0x0600A561 RID: 42337 RVA: 0x0004DC80 File Offset: 0x0004BE80
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMainQtyNull()
				MyBase.Item(Me.tableDataTable3.MainQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A562 RID: 42338 RVA: 0x00700470 File Offset: 0x006FE670
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsRateNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.RateColumn)
			End Function

			' Token: 0x0600A563 RID: 42339 RVA: 0x0004DC9F File Offset: 0x0004BE9F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetRateNull()
				MyBase.Item(Me.tableDataTable3.RateColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A564 RID: 42340 RVA: 0x00700494 File Offset: 0x006FE694
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.DiscPerColumn)
			End Function

			' Token: 0x0600A565 RID: 42341 RVA: 0x0004DCBE File Offset: 0x0004BEBE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscPerNull()
				MyBase.Item(Me.tableDataTable3.DiscPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A566 RID: 42342 RVA: 0x007004B8 File Offset: 0x006FE6B8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsDiscNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.DiscColumn)
			End Function

			' Token: 0x0600A567 RID: 42343 RVA: 0x0004DCDD File Offset: 0x0004BEDD
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetDiscNull()
				MyBase.Item(Me.tableDataTable3.DiscColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A568 RID: 42344 RVA: 0x007004DC File Offset: 0x006FE6DC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.CGSTPerColumn)
			End Function

			' Token: 0x0600A569 RID: 42345 RVA: 0x0004DCFC File Offset: 0x0004BEFC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTPerNull()
				MyBase.Item(Me.tableDataTable3.CGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A56A RID: 42346 RVA: 0x00700500 File Offset: 0x006FE700
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.CGSTColumn)
			End Function

			' Token: 0x0600A56B RID: 42347 RVA: 0x0004DD1B File Offset: 0x0004BF1B
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCGSTNull()
				MyBase.Item(Me.tableDataTable3.CGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A56C RID: 42348 RVA: 0x00700524 File Offset: 0x006FE724
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.SGSTPerColumn)
			End Function

			' Token: 0x0600A56D RID: 42349 RVA: 0x0004DD3A File Offset: 0x0004BF3A
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTPerNull()
				MyBase.Item(Me.tableDataTable3.SGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A56E RID: 42350 RVA: 0x00700548 File Offset: 0x006FE748
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsSGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.SGSTColumn)
			End Function

			' Token: 0x0600A56F RID: 42351 RVA: 0x0004DD59 File Offset: 0x0004BF59
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetSGSTNull()
				MyBase.Item(Me.tableDataTable3.SGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A570 RID: 42352 RVA: 0x0070056C File Offset: 0x006FE76C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.IGSTPerColumn)
			End Function

			' Token: 0x0600A571 RID: 42353 RVA: 0x0004DD78 File Offset: 0x0004BF78
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTPerNull()
				MyBase.Item(Me.tableDataTable3.IGSTPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A572 RID: 42354 RVA: 0x00700590 File Offset: 0x006FE790
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsIGSTNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.IGSTColumn)
			End Function

			' Token: 0x0600A573 RID: 42355 RVA: 0x0004DD97 File Offset: 0x0004BF97
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetIGSTNull()
				MyBase.Item(Me.tableDataTable3.IGSTColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A574 RID: 42356 RVA: 0x007005B4 File Offset: 0x006FE7B4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSPerNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.CESSPerColumn)
			End Function

			' Token: 0x0600A575 RID: 42357 RVA: 0x0004DDB6 File Offset: 0x0004BFB6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSPerNull()
				MyBase.Item(Me.tableDataTable3.CESSPerColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A576 RID: 42358 RVA: 0x007005D8 File Offset: 0x006FE7D8
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsCESSNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.CESSColumn)
			End Function

			' Token: 0x0600A577 RID: 42359 RVA: 0x0004DDD5 File Offset: 0x0004BFD5
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetCESSNull()
				MyBase.Item(Me.tableDataTable3.CESSColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A578 RID: 42360 RVA: 0x007005FC File Offset: 0x006FE7FC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTotalNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.TotalColumn)
			End Function

			' Token: 0x0600A579 RID: 42361 RVA: 0x0004DDF4 File Offset: 0x0004BFF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTotalNull()
				MyBase.Item(Me.tableDataTable3.TotalColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A57A RID: 42362 RVA: 0x00700620 File Offset: 0x006FE820
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAltQtyNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.AltQtyColumn)
			End Function

			' Token: 0x0600A57B RID: 42363 RVA: 0x0004DE13 File Offset: 0x0004C013
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAltQtyNull()
				MyBase.Item(Me.tableDataTable3.AltQtyColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A57C RID: 42364 RVA: 0x00700644 File Offset: 0x006FE844
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsAltUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.AltUnitColumn)
			End Function

			' Token: 0x0600A57D RID: 42365 RVA: 0x0004DE32 File Offset: 0x0004C032
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetAltUnitNull()
				MyBase.Item(Me.tableDataTable3.AltUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A57E RID: 42366 RVA: 0x00700668 File Offset: 0x006FE868
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTaxableAmtNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.TaxableAmtColumn)
			End Function

			' Token: 0x0600A57F RID: 42367 RVA: 0x0004DE51 File Offset: 0x0004C051
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTaxableAmtNull()
				MyBase.Item(Me.tableDataTable3.TaxableAmtColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A580 RID: 42368 RVA: 0x0070068C File Offset: 0x006FE88C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsMainUnitNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.MainUnitColumn)
			End Function

			' Token: 0x0600A581 RID: 42369 RVA: 0x0004DE70 File Offset: 0x0004C070
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetMainUnitNull()
				MyBase.Item(Me.tableDataTable3.MainUnitColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A582 RID: 42370 RVA: 0x007006B0 File Offset: 0x006FE8B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsPImageNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable3.PImageColumn)
			End Function

			' Token: 0x0600A583 RID: 42371 RVA: 0x0004DE8F File Offset: 0x0004C08F
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetPImageNull()
				MyBase.Item(Me.tableDataTable3.PImageColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040045A1 RID: 17825
			Private tableDataTable3 As BarcodeDataSet.DataTable3DataTable
		End Class

		' Token: 0x02000267 RID: 615
		Public Class DataTable4Row
			Inherits DataRow

			' Token: 0x0600A584 RID: 42372 RVA: 0x0004DEAE File Offset: 0x0004C0AE
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableDataTable4 = CType(MyBase.Table, BarcodeDataSet.DataTable4DataTable)
			End Sub

			' Token: 0x17003FF7 RID: 16375
			' (get) Token: 0x0600A585 RID: 42373 RVA: 0x007006D4 File Offset: 0x006FE8D4
			' (set) Token: 0x0600A586 RID: 42374 RVA: 0x0004DECA File Offset: 0x0004C0CA
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Text As String
				Get
					Dim res As String
					Try
						res = Conversions.ToString(MyBase.Item(Me.tableDataTable4.TextColumn))
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Text' in table 'DataTable4' is DBNull.", ex)
					End Try
					Return res
				End Get
				Set(value As String)
					MyBase.Item(Me.tableDataTable4.TextColumn) = value
				End Set
			End Property

			' Token: 0x17003FF8 RID: 16376
			' (get) Token: 0x0600A587 RID: 42375 RVA: 0x00700724 File Offset: 0x006FE924
			' (set) Token: 0x0600A588 RID: 42376 RVA: 0x0004DEE0 File Offset: 0x0004C0E0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Property Image As Byte()
				Get
					Dim array As Byte()
					Try
						array = CType(MyBase.Item(Me.tableDataTable4.ImageColumn), Byte())
					Catch ex As InvalidCastException
						Throw New StrongTypingException("The value for column 'Image' in table 'DataTable4' is DBNull.", ex)
					End Try
					Return array
				End Get
				Set(value As Byte())
					MyBase.Item(Me.tableDataTable4.ImageColumn) = value
				End Set
			End Property

			' Token: 0x0600A589 RID: 42377 RVA: 0x00700774 File Offset: 0x006FE974
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsTextNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable4.TextColumn)
			End Function

			' Token: 0x0600A58A RID: 42378 RVA: 0x0004DEF6 File Offset: 0x0004C0F6
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetTextNull()
				MyBase.Item(Me.tableDataTable4.TextColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x0600A58B RID: 42379 RVA: 0x00700798 File Offset: 0x006FE998
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function IsImageNull() As Boolean
				Return MyBase.IsNull(Me.tableDataTable4.ImageColumn)
			End Function

			' Token: 0x0600A58C RID: 42380 RVA: 0x0004DF15 File Offset: 0x0004C115
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub SetImageNull()
				MyBase.Item(Me.tableDataTable4.ImageColumn) = RuntimeHelpers.GetObjectValue(Convert.DBNull)
			End Sub

			' Token: 0x040045A2 RID: 17826
			Private tableDataTable4 As BarcodeDataSet.DataTable4DataTable
		End Class

		' Token: 0x02000268 RID: 616
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable1RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600A58D RID: 42381 RVA: 0x0004DF34 File Offset: 0x0004C134
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As BarcodeDataSet.DataTable1Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17003FF9 RID: 16377
			' (get) Token: 0x0600A58E RID: 42382 RVA: 0x007007BC File Offset: 0x006FE9BC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As BarcodeDataSet.DataTable1Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17003FFA RID: 16378
			' (get) Token: 0x0600A58F RID: 42383 RVA: 0x007007D4 File Offset: 0x006FE9D4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040045A3 RID: 17827
			Private eventRow As BarcodeDataSet.DataTable1Row

			' Token: 0x040045A4 RID: 17828
			Private eventAction As DataRowAction
		End Class

		' Token: 0x02000269 RID: 617
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable2RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600A590 RID: 42384 RVA: 0x0004DF4C File Offset: 0x0004C14C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As BarcodeDataSet.DataTable2Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17003FFB RID: 16379
			' (get) Token: 0x0600A591 RID: 42385 RVA: 0x007007EC File Offset: 0x006FE9EC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As BarcodeDataSet.DataTable2Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17003FFC RID: 16380
			' (get) Token: 0x0600A592 RID: 42386 RVA: 0x00700804 File Offset: 0x006FEA04
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040045A5 RID: 17829
			Private eventRow As BarcodeDataSet.DataTable2Row

			' Token: 0x040045A6 RID: 17830
			Private eventAction As DataRowAction
		End Class

		' Token: 0x0200026A RID: 618
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class P_TransferRowChangeEvent
			Inherits EventArgs

			' Token: 0x0600A593 RID: 42387 RVA: 0x0004DF64 File Offset: 0x0004C164
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As BarcodeDataSet.P_TransferRow, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17003FFD RID: 16381
			' (get) Token: 0x0600A594 RID: 42388 RVA: 0x0070081C File Offset: 0x006FEA1C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As BarcodeDataSet.P_TransferRow
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17003FFE RID: 16382
			' (get) Token: 0x0600A595 RID: 42389 RVA: 0x00700834 File Offset: 0x006FEA34
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040045A7 RID: 17831
			Private eventRow As BarcodeDataSet.P_TransferRow

			' Token: 0x040045A8 RID: 17832
			Private eventAction As DataRowAction
		End Class

		' Token: 0x0200026B RID: 619
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable11RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600A596 RID: 42390 RVA: 0x0004DF7C File Offset: 0x0004C17C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As BarcodeDataSet.DataTable11Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17003FFF RID: 16383
			' (get) Token: 0x0600A597 RID: 42391 RVA: 0x0070084C File Offset: 0x006FEA4C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As BarcodeDataSet.DataTable11Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17004000 RID: 16384
			' (get) Token: 0x0600A598 RID: 42392 RVA: 0x00700864 File Offset: 0x006FEA64
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040045A9 RID: 17833
			Private eventRow As BarcodeDataSet.DataTable11Row

			' Token: 0x040045AA RID: 17834
			Private eventAction As DataRowAction
		End Class

		' Token: 0x0200026C RID: 620
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class SaleDRowChangeEvent
			Inherits EventArgs

			' Token: 0x0600A599 RID: 42393 RVA: 0x0004DF94 File Offset: 0x0004C194
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As BarcodeDataSet.SaleDRow, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17004001 RID: 16385
			' (get) Token: 0x0600A59A RID: 42394 RVA: 0x0070087C File Offset: 0x006FEA7C
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As BarcodeDataSet.SaleDRow
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17004002 RID: 16386
			' (get) Token: 0x0600A59B RID: 42395 RVA: 0x00700894 File Offset: 0x006FEA94
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040045AB RID: 17835
			Private eventRow As BarcodeDataSet.SaleDRow

			' Token: 0x040045AC RID: 17836
			Private eventAction As DataRowAction
		End Class

		' Token: 0x0200026D RID: 621
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable3RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600A59C RID: 42396 RVA: 0x0004DFAC File Offset: 0x0004C1AC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As BarcodeDataSet.DataTable3Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17004003 RID: 16387
			' (get) Token: 0x0600A59D RID: 42397 RVA: 0x007008AC File Offset: 0x006FEAAC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As BarcodeDataSet.DataTable3Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17004004 RID: 16388
			' (get) Token: 0x0600A59E RID: 42398 RVA: 0x007008C4 File Offset: 0x006FEAC4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040045AD RID: 17837
			Private eventRow As BarcodeDataSet.DataTable3Row

			' Token: 0x040045AE RID: 17838
			Private eventAction As DataRowAction
		End Class

		' Token: 0x0200026E RID: 622
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Class DataTable4RowChangeEvent
			Inherits EventArgs

			' Token: 0x0600A59F RID: 42399 RVA: 0x0004DFC4 File Offset: 0x0004C1C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Sub New(row As BarcodeDataSet.DataTable4Row, action As DataRowAction)
				Me.eventRow = row
				Me.eventAction = action
			End Sub

			' Token: 0x17004005 RID: 16389
			' (get) Token: 0x0600A5A0 RID: 42400 RVA: 0x007008DC File Offset: 0x006FEADC
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Row As BarcodeDataSet.DataTable4Row
				Get
					Return Me.eventRow
				End Get
			End Property

			' Token: 0x17004006 RID: 16390
			' (get) Token: 0x0600A5A1 RID: 42401 RVA: 0x007008F4 File Offset: 0x006FEAF4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public ReadOnly Property Action As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property

			' Token: 0x040045AF RID: 17839
			Private eventRow As BarcodeDataSet.DataTable4Row

			' Token: 0x040045B0 RID: 17840
			Private eventAction As DataRowAction
		End Class
	End Class
End Namespace
