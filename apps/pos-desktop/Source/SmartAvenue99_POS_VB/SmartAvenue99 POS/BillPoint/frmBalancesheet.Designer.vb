Namespace BillPoint
	' Token: 0x020004AB RID: 1195
		Public Partial Class frmBalancesheet
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600ED48 RID: 60744 RVA: 0x008ECED0 File Offset: 0x008EB0D0
		<Global.System.Diagnostics.DebuggerNonUserCode()>
		Protected Overrides Sub Dispose(disposing As Boolean)
			Try
				Dim flag As Boolean = disposing AndAlso Me.components IsNot Nothing
				If flag Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		' Token: 0x0600ED49 RID: 60745 RVA: 0x008ECF20 File Offset: 0x008EB120
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBalancesheet))
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.DateTimePicker2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.TextBox7 = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.TextBox8 = New Global.System.Windows.Forms.TextBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.TextBox11 = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.TextBox12 = New Global.System.Windows.Forms.TextBox()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.TextBox13 = New Global.System.Windows.Forms.TextBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.TextBox14 = New Global.System.Windows.Forms.TextBox()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.TextBox15 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox16 = New Global.System.Windows.Forms.TextBox()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.TextBox17 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox18 = New Global.System.Windows.Forms.TextBox()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.TextBox19 = New Global.System.Windows.Forms.TextBox()
			Me.Label22 = New Global.System.Windows.Forms.Label()
			Me.TextBox20 = New Global.System.Windows.Forms.TextBox()
			Me.Label23 = New Global.System.Windows.Forms.Label()
			Me.TextBox21 = New Global.System.Windows.Forms.TextBox()
			Me.Label24 = New Global.System.Windows.Forms.Label()
			Me.TextBox22 = New Global.System.Windows.Forms.TextBox()
			Me.Label25 = New Global.System.Windows.Forms.Label()
			Me.TextBox23 = New Global.System.Windows.Forms.TextBox()
			Me.Label26 = New Global.System.Windows.Forms.Label()
			Me.Label27 = New Global.System.Windows.Forms.Label()
			Me.TextBox24 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox25 = New Global.System.Windows.Forms.TextBox()
			Me.Label28 = New Global.System.Windows.Forms.Label()
			Me.Label29 = New Global.System.Windows.Forms.Label()
			Me.TextBox26 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox27 = New Global.System.Windows.Forms.TextBox()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label39 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label40 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.TextBox82 = New Global.System.Windows.Forms.TextBox()
			Me.Label41 = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.TextBox83 = New Global.System.Windows.Forms.TextBox()
			Me.Label42 = New Global.System.Windows.Forms.Label()
			Me.Label30 = New Global.System.Windows.Forms.Label()
			Me.TextBox28 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox29 = New Global.System.Windows.Forms.TextBox()
			Me.Label31 = New Global.System.Windows.Forms.Label()
			Me.TextBox30 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox31 = New Global.System.Windows.Forms.TextBox()
			Me.Label32 = New Global.System.Windows.Forms.Label()
			Me.Label33 = New Global.System.Windows.Forms.Label()
			Me.Label34 = New Global.System.Windows.Forms.Label()
			Me.TextBox32 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox33 = New Global.System.Windows.Forms.TextBox()
			Me.Label35 = New Global.System.Windows.Forms.Label()
			Me.TextBox34 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox35 = New Global.System.Windows.Forms.TextBox()
			Me.Label36 = New Global.System.Windows.Forms.Label()
			Me.Label37 = New Global.System.Windows.Forms.Label()
			Me.Label38 = New Global.System.Windows.Forms.Label()
			Me.TextBox36 = New Global.System.Windows.Forms.TextBox()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.TextBox38 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox56 = New Global.System.Windows.Forms.TextBox()
			Me.Label43 = New Global.System.Windows.Forms.Label()
			Me.Label44 = New Global.System.Windows.Forms.Label()
			Me.TextBox37 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox39 = New Global.System.Windows.Forms.TextBox()
			Me.Label46 = New Global.System.Windows.Forms.Label()
			Me.Label48 = New Global.System.Windows.Forms.Label()
			Me.TextBox42 = New Global.System.Windows.Forms.TextBox()
			Me.Label50 = New Global.System.Windows.Forms.Label()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.Label103 = New Global.System.Windows.Forms.Label()
			Me.TextBox103 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox90 = New Global.System.Windows.Forms.TextBox()
			Me.Label69 = New Global.System.Windows.Forms.Label()
			Me.TextBox45 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox47 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox63 = New Global.System.Windows.Forms.TextBox()
			Me.Label95 = New Global.System.Windows.Forms.Label()
			Me.TextBox84 = New Global.System.Windows.Forms.TextBox()
			Me.Label84 = New Global.System.Windows.Forms.Label()
			Me.TextBox72 = New Global.System.Windows.Forms.TextBox()
			Me.Label70 = New Global.System.Windows.Forms.Label()
			Me.Label57 = New Global.System.Windows.Forms.Label()
			Me.Label56 = New Global.System.Windows.Forms.Label()
			Me.TextBox46 = New Global.System.Windows.Forms.TextBox()
			Me.Label55 = New Global.System.Windows.Forms.Label()
			Me.Label52 = New Global.System.Windows.Forms.Label()
			Me.TextBox44 = New Global.System.Windows.Forms.TextBox()
			Me.Label53 = New Global.System.Windows.Forms.Label()
			Me.Label54 = New Global.System.Windows.Forms.Label()
			Me.TextBox41 = New Global.System.Windows.Forms.TextBox()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.Label104 = New Global.System.Windows.Forms.Label()
			Me.TextBox102 = New Global.System.Windows.Forms.TextBox()
			Me.Label68 = New Global.System.Windows.Forms.Label()
			Me.TextBox89 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox88 = New Global.System.Windows.Forms.TextBox()
			Me.Label67 = New Global.System.Windows.Forms.Label()
			Me.TextBox48 = New Global.System.Windows.Forms.TextBox()
			Me.Label96 = New Global.System.Windows.Forms.Label()
			Me.TextBox85 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox51 = New Global.System.Windows.Forms.TextBox()
			Me.Label61 = New Global.System.Windows.Forms.Label()
			Me.Label60 = New Global.System.Windows.Forms.Label()
			Me.TextBox50 = New Global.System.Windows.Forms.TextBox()
			Me.Label58 = New Global.System.Windows.Forms.Label()
			Me.Label45 = New Global.System.Windows.Forms.Label()
			Me.Label47 = New Global.System.Windows.Forms.Label()
			Me.TextBox40 = New Global.System.Windows.Forms.TextBox()
			Me.Panel8 = New Global.System.Windows.Forms.Panel()
			Me.Label105 = New Global.System.Windows.Forms.Label()
			Me.TextBox101 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox94 = New Global.System.Windows.Forms.TextBox()
			Me.Label51 = New Global.System.Windows.Forms.Label()
			Me.TextBox65 = New Global.System.Windows.Forms.TextBox()
			Me.Label81 = New Global.System.Windows.Forms.Label()
			Me.Label71 = New Global.System.Windows.Forms.Label()
			Me.TextBox91 = New Global.System.Windows.Forms.TextBox()
			Me.Label72 = New Global.System.Windows.Forms.Label()
			Me.Label73 = New Global.System.Windows.Forms.Label()
			Me.TextBox92 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox93 = New Global.System.Windows.Forms.TextBox()
			Me.Label89 = New Global.System.Windows.Forms.Label()
			Me.TextBox77 = New Global.System.Windows.Forms.TextBox()
			Me.Label88 = New Global.System.Windows.Forms.Label()
			Me.Label87 = New Global.System.Windows.Forms.Label()
			Me.TextBox76 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox75 = New Global.System.Windows.Forms.TextBox()
			Me.Label49 = New Global.System.Windows.Forms.Label()
			Me.TextBox87 = New Global.System.Windows.Forms.TextBox()
			Me.Label102 = New Global.System.Windows.Forms.Label()
			Me.TextBox86 = New Global.System.Windows.Forms.TextBox()
			Me.Label101 = New Global.System.Windows.Forms.Label()
			Me.Label92 = New Global.System.Windows.Forms.Label()
			Me.Label91 = New Global.System.Windows.Forms.Label()
			Me.Label90 = New Global.System.Windows.Forms.Label()
			Me.TextBox80 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox79 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox78 = New Global.System.Windows.Forms.TextBox()
			Me.Panel9 = New Global.System.Windows.Forms.Panel()
			Me.Label75 = New Global.System.Windows.Forms.Label()
			Me.TextBox74 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox67 = New Global.System.Windows.Forms.TextBox()
			Me.Label85 = New Global.System.Windows.Forms.Label()
			Me.TextBox71 = New Global.System.Windows.Forms.TextBox()
			Me.Label79 = New Global.System.Windows.Forms.Label()
			Me.TextBox49 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox70 = New Global.System.Windows.Forms.TextBox()
			Me.Label74 = New Global.System.Windows.Forms.Label()
			Me.TextBox81 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox66 = New Global.System.Windows.Forms.TextBox()
			Me.Label94 = New Global.System.Windows.Forms.Label()
			Me.Label82 = New Global.System.Windows.Forms.Label()
			Me.TextBox53 = New Global.System.Windows.Forms.TextBox()
			Me.Label76 = New Global.System.Windows.Forms.Label()
			Me.Label80 = New Global.System.Windows.Forms.Label()
			Me.TextBox68 = New Global.System.Windows.Forms.TextBox()
			Me.Label59 = New Global.System.Windows.Forms.Label()
			Me.Label77 = New Global.System.Windows.Forms.Label()
			Me.TextBox64 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox69 = New Global.System.Windows.Forms.TextBox()
			Me.Label63 = New Global.System.Windows.Forms.Label()
			Me.Label64 = New Global.System.Windows.Forms.Label()
			Me.TextBox54 = New Global.System.Windows.Forms.TextBox()
			Me.Label65 = New Global.System.Windows.Forms.Label()
			Me.Label66 = New Global.System.Windows.Forms.Label()
			Me.TextBox55 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox52 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox57 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox58 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox59 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox60 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox61 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox62 = New Global.System.Windows.Forms.TextBox()
			Me.Panel10 = New Global.System.Windows.Forms.Panel()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.Button7 = New Global.System.Windows.Forms.Button()
			Me.Button6 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Panel12 = New Global.System.Windows.Forms.Panel()
			Me.TextBox73 = New Global.System.Windows.Forms.TextBox()
			Me.Label83 = New Global.System.Windows.Forms.Label()
			Me.Label86 = New Global.System.Windows.Forms.Label()
			Me.Panel11 = New Global.System.Windows.Forms.Panel()
			Me.Label106 = New Global.System.Windows.Forms.Label()
			Me.TextBox100 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox99 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox98 = New Global.System.Windows.Forms.TextBox()
			Me.Label99 = New Global.System.Windows.Forms.Label()
			Me.Label100 = New Global.System.Windows.Forms.Label()
			Me.TextBox95 = New Global.System.Windows.Forms.TextBox()
			Me.Label62 = New Global.System.Windows.Forms.Label()
			Me.Label97 = New Global.System.Windows.Forms.Label()
			Me.Label98 = New Global.System.Windows.Forms.Label()
			Me.TextBox96 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox97 = New Global.System.Windows.Forms.TextBox()
			Me.Label78 = New Global.System.Windows.Forms.Label()
			Me.Label93 = New Global.System.Windows.Forms.Label()
			Me.Panel13 = New Global.System.Windows.Forms.Panel()
			Me.ToolTip1 = New Global.System.Windows.Forms.ToolTip(Me.components)
			Me.GroupBox2.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.Panel3.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.Panel7.SuspendLayout()
			Me.Panel8.SuspendLayout()
			Me.Panel9.SuspendLayout()
			Me.Panel10.SuspendLayout()
			Me.Panel12.SuspendLayout()
			Me.Panel11.SuspendLayout()
			Me.Panel13.SuspendLayout()
			MyBase.SuspendLayout()
			Me.TextBox1.BackColor = Global.System.Drawing.Color.White
			Me.TextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox1.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox1.Location = New Global.System.Drawing.Point(108, 23)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox1.TabIndex = 0
			Me.TextBox1.TabStop = False
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox2.BackColor = Global.System.Drawing.Color.White
			Me.TextBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox2.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox2.Location = New Global.System.Drawing.Point(108, 50)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox2.TabIndex = 1
			Me.TextBox2.TabStop = False
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label1.Location = New Global.System.Drawing.Point(3, 239)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(98, 13)
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "Grand Total Sales :"
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label2.Location = New Global.System.Drawing.Point(3, 46)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(77, 13)
			Me.Label2.TabIndex = 3
			Me.Label2.Text = "Output CGST :"
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox2.Controls.Add(Me.GelButton1)
			Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
			Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.ForeColor = Global.System.Drawing.Color.Black
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, -1)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(521, 59)
			Me.GroupBox2.TabIndex = 51
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search by Date"
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(293, 15)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 37)
			Me.GelButton1.TabIndex = 537
			Me.GelButton1.Text = "&Generate"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker2.Location = New Global.System.Drawing.Point(154, 29)
			Me.DateTimePicker2.Name = "DateTimePicker2"
			Me.DateTimePicker2.Size = New Global.System.Drawing.Size(125, 20)
			Me.DateTimePicker2.TabIndex = 1
			Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(11, 29)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(125, 20)
			Me.DateTimePicker1.TabIndex = 0
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(151, 16)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label3.TabIndex = 13
			Me.Label3.Text = "To :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(9, 16)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "From :"
			Me.Label5.AutoSize = True
			Me.Label5.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label5.Location = New Global.System.Drawing.Point(3, 105)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label5.TabIndex = 55
			Me.Label5.Text = "Output IGST :"
			Me.Label6.AutoSize = True
			Me.Label6.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label6.Location = New Global.System.Drawing.Point(3, 77)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(103, 13)
			Me.Label6.TabIndex = 54
			Me.Label6.Text = "Output (S/UT)GST :"
			Me.TextBox3.BackColor = Global.System.Drawing.Color.White
			Me.TextBox3.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox3.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox3.Location = New Global.System.Drawing.Point(108, 77)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox3.TabIndex = 53
			Me.TextBox3.TabStop = False
			Me.TextBox3.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox4.BackColor = Global.System.Drawing.Color.White
			Me.TextBox4.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox4.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox4.Location = New Global.System.Drawing.Point(108, 104)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.[ReadOnly] = True
			Me.TextBox4.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox4.TabIndex = 52
			Me.TextBox4.TabStop = False
			Me.TextBox4.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label7.AutoSize = True
			Me.Label7.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label7.Location = New Global.System.Drawing.Point(3, 133)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label7.TabIndex = 57
			Me.Label7.Text = "CESS :"
			Me.TextBox5.BackColor = Global.System.Drawing.Color.White
			Me.TextBox5.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox5.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox5.Location = New Global.System.Drawing.Point(108, 131)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.[ReadOnly] = True
			Me.TextBox5.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox5.TabIndex = 56
			Me.TextBox5.TabStop = False
			Me.TextBox5.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label8.AutoSize = True
			Me.Label8.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label8.Location = New Global.System.Drawing.Point(3, 159)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label8.TabIndex = 59
			Me.Label8.Text = "Bill Sundry :"
			Me.TextBox6.BackColor = Global.System.Drawing.Color.White
			Me.TextBox6.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox6.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox6.Location = New Global.System.Drawing.Point(108, 158)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.[ReadOnly] = True
			Me.TextBox6.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox6.TabIndex = 58
			Me.TextBox6.TabStop = False
			Me.TextBox6.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label9.AutoSize = True
			Me.Label9.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label9.Location = New Global.System.Drawing.Point(3, 185)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(74, 13)
			Me.Label9.TabIndex = 61
			Me.Label9.Text = "Bill Discount  :"
			Me.TextBox7.BackColor = Global.System.Drawing.Color.White
			Me.TextBox7.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox7.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox7.Location = New Global.System.Drawing.Point(108, 185)
			Me.TextBox7.Name = "TextBox7"
			Me.TextBox7.[ReadOnly] = True
			Me.TextBox7.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox7.TabIndex = 60
			Me.TextBox7.TabStop = False
			Me.TextBox7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label10.AutoSize = True
			Me.Label10.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label10.Location = New Global.System.Drawing.Point(3, 211)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(57, 13)
			Me.Label10.TabIndex = 63
			Me.Label10.Text = "Roundoff :"
			Me.TextBox8.BackColor = Global.System.Drawing.Color.White
			Me.TextBox8.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox8.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox8.Location = New Global.System.Drawing.Point(108, 212)
			Me.TextBox8.Name = "TextBox8"
			Me.TextBox8.[ReadOnly] = True
			Me.TextBox8.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox8.TabIndex = 62
			Me.TextBox8.TabStop = False
			Me.TextBox8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label11.AutoSize = True
			Me.Label11.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label11.Location = New Global.System.Drawing.Point(3, 20)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(66, 13)
			Me.Label11.TabIndex = 65
			Me.Label11.Text = "Total Sales :"
			Me.TextBox9.BackColor = Global.System.Drawing.Color.Green
			Me.TextBox9.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox9.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox9.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox9.Location = New Global.System.Drawing.Point(108, 240)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.[ReadOnly] = True
			Me.TextBox9.Size = New Global.System.Drawing.Size(107, 15)
			Me.TextBox9.TabIndex = 64
			Me.TextBox9.TabStop = False
			Me.TextBox9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label12.AutoSize = True
			Me.Label12.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label12.Location = New Global.System.Drawing.Point(-2, 20)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(90, 13)
			Me.Label12.TabIndex = 83
			Me.Label12.Text = "Total Purchases :"
			Me.TextBox10.BackColor = Global.System.Drawing.Color.Red
			Me.TextBox10.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox10.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox10.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox10.Location = New Global.System.Drawing.Point(108, 240)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.[ReadOnly] = True
			Me.TextBox10.Size = New Global.System.Drawing.Size(107, 15)
			Me.TextBox10.TabIndex = 82
			Me.TextBox10.TabStop = False
			Me.TextBox10.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label13.AutoSize = True
			Me.Label13.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label13.Location = New Global.System.Drawing.Point(-2, 211)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(57, 13)
			Me.Label13.TabIndex = 81
			Me.Label13.Text = "Roundoff :"
			Me.TextBox11.BackColor = Global.System.Drawing.Color.White
			Me.TextBox11.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox11.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox11.Location = New Global.System.Drawing.Point(108, 213)
			Me.TextBox11.Name = "TextBox11"
			Me.TextBox11.[ReadOnly] = True
			Me.TextBox11.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox11.TabIndex = 80
			Me.TextBox11.TabStop = False
			Me.TextBox11.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label14.AutoSize = True
			Me.Label14.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label14.Location = New Global.System.Drawing.Point(-2, 185)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(74, 13)
			Me.Label14.TabIndex = 79
			Me.Label14.Text = "Bill Discount  :"
			Me.TextBox12.BackColor = Global.System.Drawing.Color.White
			Me.TextBox12.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox12.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox12.Location = New Global.System.Drawing.Point(108, 186)
			Me.TextBox12.Name = "TextBox12"
			Me.TextBox12.[ReadOnly] = True
			Me.TextBox12.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox12.TabIndex = 78
			Me.TextBox12.TabStop = False
			Me.TextBox12.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label15.AutoSize = True
			Me.Label15.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label15.Location = New Global.System.Drawing.Point(-2, 159)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label15.TabIndex = 77
			Me.Label15.Text = "Bill Sundry :"
			Me.TextBox13.BackColor = Global.System.Drawing.Color.White
			Me.TextBox13.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox13.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox13.Location = New Global.System.Drawing.Point(108, 159)
			Me.TextBox13.Name = "TextBox13"
			Me.TextBox13.[ReadOnly] = True
			Me.TextBox13.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox13.TabIndex = 76
			Me.TextBox13.TabStop = False
			Me.TextBox13.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label16.AutoSize = True
			Me.Label16.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label16.Location = New Global.System.Drawing.Point(-2, 133)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label16.TabIndex = 75
			Me.Label16.Text = "CESS :"
			Me.TextBox14.BackColor = Global.System.Drawing.Color.White
			Me.TextBox14.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox14.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox14.Location = New Global.System.Drawing.Point(108, 132)
			Me.TextBox14.Name = "TextBox14"
			Me.TextBox14.[ReadOnly] = True
			Me.TextBox14.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox14.TabIndex = 74
			Me.TextBox14.TabStop = False
			Me.TextBox14.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label17.AutoSize = True
			Me.Label17.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label17.Location = New Global.System.Drawing.Point(-2, 105)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(65, 13)
			Me.Label17.TabIndex = 73
			Me.Label17.Text = "Input IGST :"
			Me.Label18.AutoSize = True
			Me.Label18.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label18.Location = New Global.System.Drawing.Point(-2, 77)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(95, 13)
			Me.Label18.TabIndex = 72
			Me.Label18.Text = "Input (S/UT)GST :"
			Me.TextBox15.BackColor = Global.System.Drawing.Color.White
			Me.TextBox15.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox15.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox15.Location = New Global.System.Drawing.Point(108, 105)
			Me.TextBox15.Name = "TextBox15"
			Me.TextBox15.[ReadOnly] = True
			Me.TextBox15.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox15.TabIndex = 71
			Me.TextBox15.TabStop = False
			Me.TextBox15.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox16.BackColor = Global.System.Drawing.Color.White
			Me.TextBox16.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox16.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox16.Location = New Global.System.Drawing.Point(108, 78)
			Me.TextBox16.Name = "TextBox16"
			Me.TextBox16.[ReadOnly] = True
			Me.TextBox16.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox16.TabIndex = 70
			Me.TextBox16.TabStop = False
			Me.TextBox16.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label19.AutoSize = True
			Me.Label19.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label19.Location = New Global.System.Drawing.Point(-2, 46)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label19.TabIndex = 69
			Me.Label19.Text = "Input CGST :"
			Me.Label20.AutoSize = True
			Me.Label20.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label20.Location = New Global.System.Drawing.Point(-2, 239)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(100, 13)
			Me.Label20.TabIndex = 68
			Me.Label20.Text = "Grand Total Purch :"
			Me.TextBox17.BackColor = Global.System.Drawing.Color.White
			Me.TextBox17.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox17.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox17.Location = New Global.System.Drawing.Point(108, 51)
			Me.TextBox17.Name = "TextBox17"
			Me.TextBox17.[ReadOnly] = True
			Me.TextBox17.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox17.TabIndex = 67
			Me.TextBox17.TabStop = False
			Me.TextBox17.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox18.BackColor = Global.System.Drawing.Color.White
			Me.TextBox18.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox18.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox18.Location = New Global.System.Drawing.Point(108, 24)
			Me.TextBox18.Name = "TextBox18"
			Me.TextBox18.[ReadOnly] = True
			Me.TextBox18.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox18.TabIndex = 66
			Me.TextBox18.TabStop = False
			Me.TextBox18.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label21.AutoSize = True
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label21.Location = New Global.System.Drawing.Point(-1, 20)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(96, 13)
			Me.Label21.TabIndex = 101
			Me.Label21.Text = "Total Sale Return :"
			Me.TextBox19.BackColor = Global.System.Drawing.Color.Red
			Me.TextBox19.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox19.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox19.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox19.Location = New Global.System.Drawing.Point(108, 240)
			Me.TextBox19.Name = "TextBox19"
			Me.TextBox19.[ReadOnly] = True
			Me.TextBox19.Size = New Global.System.Drawing.Size(107, 15)
			Me.TextBox19.TabIndex = 100
			Me.TextBox19.TabStop = False
			Me.TextBox19.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label22.AutoSize = True
			Me.Label22.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label22.Location = New Global.System.Drawing.Point(-1, 211)
			Me.Label22.Name = "Label22"
			Me.Label22.Size = New Global.System.Drawing.Size(57, 13)
			Me.Label22.TabIndex = 99
			Me.Label22.Text = "Roundoff :"
			Me.TextBox20.BackColor = Global.System.Drawing.Color.White
			Me.TextBox20.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox20.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox20.Location = New Global.System.Drawing.Point(108, 213)
			Me.TextBox20.Name = "TextBox20"
			Me.TextBox20.[ReadOnly] = True
			Me.TextBox20.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox20.TabIndex = 98
			Me.TextBox20.TabStop = False
			Me.TextBox20.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label23.AutoSize = True
			Me.Label23.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label23.Location = New Global.System.Drawing.Point(-1, 185)
			Me.Label23.Name = "Label23"
			Me.Label23.Size = New Global.System.Drawing.Size(74, 13)
			Me.Label23.TabIndex = 97
			Me.Label23.Text = "Bill Discount  :"
			Me.TextBox21.BackColor = Global.System.Drawing.Color.White
			Me.TextBox21.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox21.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox21.Location = New Global.System.Drawing.Point(108, 186)
			Me.TextBox21.Name = "TextBox21"
			Me.TextBox21.[ReadOnly] = True
			Me.TextBox21.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox21.TabIndex = 96
			Me.TextBox21.TabStop = False
			Me.TextBox21.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label24.AutoSize = True
			Me.Label24.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label24.Location = New Global.System.Drawing.Point(-1, 159)
			Me.Label24.Name = "Label24"
			Me.Label24.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label24.TabIndex = 95
			Me.Label24.Text = "Bill Sundry :"
			Me.TextBox22.BackColor = Global.System.Drawing.Color.White
			Me.TextBox22.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox22.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox22.Location = New Global.System.Drawing.Point(108, 159)
			Me.TextBox22.Name = "TextBox22"
			Me.TextBox22.[ReadOnly] = True
			Me.TextBox22.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox22.TabIndex = 94
			Me.TextBox22.TabStop = False
			Me.TextBox22.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label25.AutoSize = True
			Me.Label25.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label25.Location = New Global.System.Drawing.Point(-1, 133)
			Me.Label25.Name = "Label25"
			Me.Label25.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label25.TabIndex = 93
			Me.Label25.Text = "CESS :"
			Me.TextBox23.BackColor = Global.System.Drawing.Color.White
			Me.TextBox23.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox23.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox23.Location = New Global.System.Drawing.Point(108, 132)
			Me.TextBox23.Name = "TextBox23"
			Me.TextBox23.[ReadOnly] = True
			Me.TextBox23.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox23.TabIndex = 92
			Me.TextBox23.TabStop = False
			Me.TextBox23.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label26.AutoSize = True
			Me.Label26.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label26.Location = New Global.System.Drawing.Point(-1, 105)
			Me.Label26.Name = "Label26"
			Me.Label26.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label26.TabIndex = 91
			Me.Label26.Text = "IGST :"
			Me.Label27.AutoSize = True
			Me.Label27.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label27.Location = New Global.System.Drawing.Point(-1, 77)
			Me.Label27.Name = "Label27"
			Me.Label27.Size = New Global.System.Drawing.Size(68, 13)
			Me.Label27.TabIndex = 90
			Me.Label27.Text = "(S/UT)GST :"
			Me.TextBox24.BackColor = Global.System.Drawing.Color.White
			Me.TextBox24.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox24.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox24.Location = New Global.System.Drawing.Point(108, 105)
			Me.TextBox24.Name = "TextBox24"
			Me.TextBox24.[ReadOnly] = True
			Me.TextBox24.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox24.TabIndex = 89
			Me.TextBox24.TabStop = False
			Me.TextBox24.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox25.BackColor = Global.System.Drawing.Color.White
			Me.TextBox25.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox25.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox25.Location = New Global.System.Drawing.Point(108, 78)
			Me.TextBox25.Name = "TextBox25"
			Me.TextBox25.[ReadOnly] = True
			Me.TextBox25.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox25.TabIndex = 88
			Me.TextBox25.TabStop = False
			Me.TextBox25.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label28.AutoSize = True
			Me.Label28.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label28.Location = New Global.System.Drawing.Point(-1, 46)
			Me.Label28.Name = "Label28"
			Me.Label28.Size = New Global.System.Drawing.Size(42, 13)
			Me.Label28.TabIndex = 87
			Me.Label28.Text = "CGST :"
			Me.Label29.AutoSize = True
			Me.Label29.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label29.Location = New Global.System.Drawing.Point(-1, 240)
			Me.Label29.Name = "Label29"
			Me.Label29.Size = New Global.System.Drawing.Size(114, 13)
			Me.Label29.TabIndex = 86
			Me.Label29.Text = "Grand Total S.Return :"
			Me.TextBox26.BackColor = Global.System.Drawing.Color.White
			Me.TextBox26.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox26.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox26.Location = New Global.System.Drawing.Point(108, 51)
			Me.TextBox26.Name = "TextBox26"
			Me.TextBox26.[ReadOnly] = True
			Me.TextBox26.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox26.TabIndex = 85
			Me.TextBox26.TabStop = False
			Me.TextBox26.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox27.BackColor = Global.System.Drawing.Color.White
			Me.TextBox27.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox27.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox27.Location = New Global.System.Drawing.Point(108, 24)
			Me.TextBox27.Name = "TextBox27"
			Me.TextBox27.[ReadOnly] = True
			Me.TextBox27.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox27.TabIndex = 84
			Me.TextBox27.TabStop = False
			Me.TextBox27.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label39)
			Me.Panel1.Controls.Add(Me.TextBox5)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.TextBox4)
			Me.Panel1.Controls.Add(Me.TextBox3)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.Label7)
			Me.Panel1.Controls.Add(Me.TextBox6)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Controls.Add(Me.TextBox7)
			Me.Panel1.Controls.Add(Me.Label9)
			Me.Panel1.Controls.Add(Me.TextBox8)
			Me.Panel1.Controls.Add(Me.Label10)
			Me.Panel1.Controls.Add(Me.TextBox9)
			Me.Panel1.Controls.Add(Me.Label11)
			Me.Panel1.Location = New Global.System.Drawing.Point(5, 60)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(222, 261)
			Me.Panel1.TabIndex = 102
			Me.Label39.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label39.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label39.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label39.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label39.ForeColor = Global.System.Drawing.Color.White
			Me.Label39.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label39.Name = "Label39"
			Me.Label39.Size = New Global.System.Drawing.Size(220, 17)
			Me.Label39.TabIndex = 106
			Me.Label39.Text = "Sale"
			Me.Label39.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel2.BackColor = Global.System.Drawing.Color.White
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.Label40)
			Me.Panel2.Controls.Add(Me.TextBox10)
			Me.Panel2.Controls.Add(Me.TextBox11)
			Me.Panel2.Controls.Add(Me.TextBox18)
			Me.Panel2.Controls.Add(Me.TextBox17)
			Me.Panel2.Controls.Add(Me.Label20)
			Me.Panel2.Controls.Add(Me.Label19)
			Me.Panel2.Controls.Add(Me.TextBox16)
			Me.Panel2.Controls.Add(Me.TextBox15)
			Me.Panel2.Controls.Add(Me.Label18)
			Me.Panel2.Controls.Add(Me.Label17)
			Me.Panel2.Controls.Add(Me.TextBox14)
			Me.Panel2.Controls.Add(Me.Label16)
			Me.Panel2.Controls.Add(Me.TextBox13)
			Me.Panel2.Controls.Add(Me.Label15)
			Me.Panel2.Controls.Add(Me.TextBox12)
			Me.Panel2.Controls.Add(Me.Label14)
			Me.Panel2.Controls.Add(Me.Label13)
			Me.Panel2.Controls.Add(Me.Label12)
			Me.Panel2.Location = New Global.System.Drawing.Point(226, 60)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(222, 261)
			Me.Panel2.TabIndex = 103
			Me.Label40.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label40.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label40.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label40.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label40.ForeColor = Global.System.Drawing.Color.White
			Me.Label40.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label40.Name = "Label40"
			Me.Label40.Size = New Global.System.Drawing.Size(220, 17)
			Me.Label40.TabIndex = 107
			Me.Label40.Text = "Purchase"
			Me.Label40.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel3.BackColor = Global.System.Drawing.Color.White
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.TextBox82)
			Me.Panel3.Controls.Add(Me.Label41)
			Me.Panel3.Controls.Add(Me.Label21)
			Me.Panel3.Controls.Add(Me.TextBox19)
			Me.Panel3.Controls.Add(Me.TextBox27)
			Me.Panel3.Controls.Add(Me.Label22)
			Me.Panel3.Controls.Add(Me.TextBox26)
			Me.Panel3.Controls.Add(Me.TextBox20)
			Me.Panel3.Controls.Add(Me.Label29)
			Me.Panel3.Controls.Add(Me.Label23)
			Me.Panel3.Controls.Add(Me.Label28)
			Me.Panel3.Controls.Add(Me.TextBox21)
			Me.Panel3.Controls.Add(Me.TextBox25)
			Me.Panel3.Controls.Add(Me.Label24)
			Me.Panel3.Controls.Add(Me.TextBox24)
			Me.Panel3.Controls.Add(Me.TextBox22)
			Me.Panel3.Controls.Add(Me.Label27)
			Me.Panel3.Controls.Add(Me.Label25)
			Me.Panel3.Controls.Add(Me.Label26)
			Me.Panel3.Controls.Add(Me.TextBox23)
			Me.Panel3.Location = New Global.System.Drawing.Point(447, 60)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(222, 261)
			Me.Panel3.TabIndex = 104
			Me.TextBox82.Location = New Global.System.Drawing.Point(73, 89)
			Me.TextBox82.Name = "TextBox82"
			Me.TextBox82.[ReadOnly] = True
			Me.TextBox82.Size = New Global.System.Drawing.Size(15, 20)
			Me.TextBox82.TabIndex = 109
			Me.TextBox82.TabStop = False
			Me.TextBox82.Visible = False
			Me.Label41.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label41.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label41.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label41.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label41.ForeColor = Global.System.Drawing.Color.White
			Me.Label41.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label41.Name = "Label41"
			Me.Label41.Size = New Global.System.Drawing.Size(220, 17)
			Me.Label41.TabIndex = 107
			Me.Label41.Text = "Sale Return"
			Me.Label41.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel4.BackColor = Global.System.Drawing.Color.White
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.TextBox83)
			Me.Panel4.Controls.Add(Me.Label42)
			Me.Panel4.Controls.Add(Me.Label30)
			Me.Panel4.Controls.Add(Me.TextBox28)
			Me.Panel4.Controls.Add(Me.TextBox29)
			Me.Panel4.Controls.Add(Me.Label31)
			Me.Panel4.Controls.Add(Me.TextBox30)
			Me.Panel4.Controls.Add(Me.TextBox31)
			Me.Panel4.Controls.Add(Me.Label32)
			Me.Panel4.Controls.Add(Me.Label33)
			Me.Panel4.Controls.Add(Me.Label34)
			Me.Panel4.Controls.Add(Me.TextBox32)
			Me.Panel4.Controls.Add(Me.TextBox33)
			Me.Panel4.Controls.Add(Me.Label35)
			Me.Panel4.Controls.Add(Me.TextBox34)
			Me.Panel4.Controls.Add(Me.TextBox35)
			Me.Panel4.Controls.Add(Me.Label36)
			Me.Panel4.Controls.Add(Me.Label37)
			Me.Panel4.Controls.Add(Me.Label38)
			Me.Panel4.Controls.Add(Me.TextBox36)
			Me.Panel4.Location = New Global.System.Drawing.Point(668, 60)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(222, 261)
			Me.Panel4.TabIndex = 105
			Me.TextBox83.Location = New Global.System.Drawing.Point(69, 105)
			Me.TextBox83.Name = "TextBox83"
			Me.TextBox83.[ReadOnly] = True
			Me.TextBox83.Size = New Global.System.Drawing.Size(27, 20)
			Me.TextBox83.TabIndex = 110
			Me.TextBox83.TabStop = False
			Me.TextBox83.Visible = False
			Me.Label42.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label42.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label42.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label42.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label42.ForeColor = Global.System.Drawing.Color.White
			Me.Label42.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label42.Name = "Label42"
			Me.Label42.Size = New Global.System.Drawing.Size(220, 17)
			Me.Label42.TabIndex = 107
			Me.Label42.Text = "Purchase Return"
			Me.Label42.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label30.AutoSize = True
			Me.Label30.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label30.Location = New Global.System.Drawing.Point(-1, 20)
			Me.Label30.Name = "Label30"
			Me.Label30.Size = New Global.System.Drawing.Size(97, 13)
			Me.Label30.TabIndex = 101
			Me.Label30.Text = "Total Purc Return :"
			Me.TextBox28.BackColor = Global.System.Drawing.Color.Green
			Me.TextBox28.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox28.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox28.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox28.Location = New Global.System.Drawing.Point(108, 240)
			Me.TextBox28.Name = "TextBox28"
			Me.TextBox28.[ReadOnly] = True
			Me.TextBox28.Size = New Global.System.Drawing.Size(107, 15)
			Me.TextBox28.TabIndex = 100
			Me.TextBox28.TabStop = False
			Me.TextBox28.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox29.BackColor = Global.System.Drawing.Color.White
			Me.TextBox29.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox29.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox29.Location = New Global.System.Drawing.Point(108, 24)
			Me.TextBox29.Name = "TextBox29"
			Me.TextBox29.[ReadOnly] = True
			Me.TextBox29.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox29.TabIndex = 84
			Me.TextBox29.TabStop = False
			Me.TextBox29.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label31.AutoSize = True
			Me.Label31.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label31.Location = New Global.System.Drawing.Point(-1, 211)
			Me.Label31.Name = "Label31"
			Me.Label31.Size = New Global.System.Drawing.Size(57, 13)
			Me.Label31.TabIndex = 99
			Me.Label31.Text = "Roundoff :"
			Me.TextBox30.BackColor = Global.System.Drawing.Color.White
			Me.TextBox30.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox30.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox30.Location = New Global.System.Drawing.Point(108, 51)
			Me.TextBox30.Name = "TextBox30"
			Me.TextBox30.[ReadOnly] = True
			Me.TextBox30.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox30.TabIndex = 85
			Me.TextBox30.TabStop = False
			Me.TextBox30.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox31.BackColor = Global.System.Drawing.Color.White
			Me.TextBox31.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox31.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox31.Location = New Global.System.Drawing.Point(108, 213)
			Me.TextBox31.Name = "TextBox31"
			Me.TextBox31.[ReadOnly] = True
			Me.TextBox31.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox31.TabIndex = 98
			Me.TextBox31.TabStop = False
			Me.TextBox31.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label32.AutoSize = True
			Me.Label32.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label32.Location = New Global.System.Drawing.Point(-1, 240)
			Me.Label32.Name = "Label32"
			Me.Label32.Size = New Global.System.Drawing.Size(114, 13)
			Me.Label32.TabIndex = 86
			Me.Label32.Text = "Grand Total P.Return :"
			Me.Label33.AutoSize = True
			Me.Label33.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label33.Location = New Global.System.Drawing.Point(-1, 185)
			Me.Label33.Name = "Label33"
			Me.Label33.Size = New Global.System.Drawing.Size(71, 13)
			Me.Label33.TabIndex = 97
			Me.Label33.Text = "Bill Discount :"
			Me.Label34.AutoSize = True
			Me.Label34.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label34.Location = New Global.System.Drawing.Point(-1, 46)
			Me.Label34.Name = "Label34"
			Me.Label34.Size = New Global.System.Drawing.Size(42, 13)
			Me.Label34.TabIndex = 87
			Me.Label34.Text = "CGST :"
			Me.TextBox32.BackColor = Global.System.Drawing.Color.White
			Me.TextBox32.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox32.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox32.Location = New Global.System.Drawing.Point(108, 186)
			Me.TextBox32.Name = "TextBox32"
			Me.TextBox32.[ReadOnly] = True
			Me.TextBox32.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox32.TabIndex = 96
			Me.TextBox32.TabStop = False
			Me.TextBox32.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox33.BackColor = Global.System.Drawing.Color.White
			Me.TextBox33.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox33.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox33.Location = New Global.System.Drawing.Point(108, 78)
			Me.TextBox33.Name = "TextBox33"
			Me.TextBox33.[ReadOnly] = True
			Me.TextBox33.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox33.TabIndex = 88
			Me.TextBox33.TabStop = False
			Me.TextBox33.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label35.AutoSize = True
			Me.Label35.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label35.Location = New Global.System.Drawing.Point(-1, 159)
			Me.Label35.Name = "Label35"
			Me.Label35.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label35.TabIndex = 95
			Me.Label35.Text = "Bill Sundry :"
			Me.TextBox34.BackColor = Global.System.Drawing.Color.White
			Me.TextBox34.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox34.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox34.Location = New Global.System.Drawing.Point(108, 105)
			Me.TextBox34.Name = "TextBox34"
			Me.TextBox34.[ReadOnly] = True
			Me.TextBox34.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox34.TabIndex = 89
			Me.TextBox34.TabStop = False
			Me.TextBox34.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox35.BackColor = Global.System.Drawing.Color.White
			Me.TextBox35.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox35.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox35.Location = New Global.System.Drawing.Point(108, 159)
			Me.TextBox35.Name = "TextBox35"
			Me.TextBox35.[ReadOnly] = True
			Me.TextBox35.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox35.TabIndex = 94
			Me.TextBox35.TabStop = False
			Me.TextBox35.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label36.AutoSize = True
			Me.Label36.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label36.Location = New Global.System.Drawing.Point(-1, 77)
			Me.Label36.Name = "Label36"
			Me.Label36.Size = New Global.System.Drawing.Size(68, 13)
			Me.Label36.TabIndex = 90
			Me.Label36.Text = "(S/UT)GST :"
			Me.Label37.AutoSize = True
			Me.Label37.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label37.Location = New Global.System.Drawing.Point(-1, 133)
			Me.Label37.Name = "Label37"
			Me.Label37.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label37.TabIndex = 93
			Me.Label37.Text = "CESS :"
			Me.Label38.AutoSize = True
			Me.Label38.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label38.Location = New Global.System.Drawing.Point(-1, 105)
			Me.Label38.Name = "Label38"
			Me.Label38.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label38.TabIndex = 91
			Me.Label38.Text = "IGST :"
			Me.TextBox36.BackColor = Global.System.Drawing.Color.White
			Me.TextBox36.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox36.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox36.Location = New Global.System.Drawing.Point(108, 132)
			Me.TextBox36.Name = "TextBox36"
			Me.TextBox36.[ReadOnly] = True
			Me.TextBox36.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox36.TabIndex = 92
			Me.TextBox36.TabStop = False
			Me.TextBox36.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Panel5.BackColor = Global.System.Drawing.Color.White
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.TextBox38)
			Me.Panel5.Controls.Add(Me.TextBox56)
			Me.Panel5.Controls.Add(Me.Label43)
			Me.Panel5.Controls.Add(Me.Label44)
			Me.Panel5.Controls.Add(Me.TextBox37)
			Me.Panel5.Controls.Add(Me.TextBox39)
			Me.Panel5.Controls.Add(Me.Label46)
			Me.Panel5.Controls.Add(Me.Label48)
			Me.Panel5.Controls.Add(Me.TextBox42)
			Me.Panel5.Controls.Add(Me.Label50)
			Me.Panel5.Location = New Global.System.Drawing.Point(889, 60)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(222, 261)
			Me.Panel5.TabIndex = 108
			Me.TextBox38.BackColor = Global.System.Drawing.Color.White
			Me.TextBox38.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox38.Location = New Global.System.Drawing.Point(109, 24)
			Me.TextBox38.Name = "TextBox38"
			Me.TextBox38.[ReadOnly] = True
			Me.TextBox38.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox38.TabIndex = 84
			Me.TextBox38.TabStop = False
			Me.TextBox38.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox56.BackColor = Global.System.Drawing.Color.Green
			Me.TextBox56.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox56.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox56.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox56.Location = New Global.System.Drawing.Point(109, 240)
			Me.TextBox56.Name = "TextBox56"
			Me.TextBox56.[ReadOnly] = True
			Me.TextBox56.Size = New Global.System.Drawing.Size(107, 15)
			Me.TextBox56.TabIndex = 108
			Me.TextBox56.TabStop = False
			Me.TextBox56.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label43.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label43.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label43.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label43.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label43.ForeColor = Global.System.Drawing.Color.White
			Me.Label43.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label43.Name = "Label43"
			Me.Label43.Size = New Global.System.Drawing.Size(220, 17)
			Me.Label43.TabIndex = 107
			Me.Label43.Text = "Service"
			Me.Label43.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label44.AutoSize = True
			Me.Label44.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label44.Location = New Global.System.Drawing.Point(-1, 20)
			Me.Label44.Name = "Label44"
			Me.Label44.Size = New Global.System.Drawing.Size(113, 13)
			Me.Label44.TabIndex = 101
			Me.Label44.Text = "Total Service Charge :"
			Me.TextBox37.BackColor = Global.System.Drawing.Color.FromArgb(224, 224, 224)
			Me.TextBox37.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox37.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox37.Location = New Global.System.Drawing.Point(5, 131)
			Me.TextBox37.Name = "TextBox37"
			Me.TextBox37.[ReadOnly] = True
			Me.TextBox37.Size = New Global.System.Drawing.Size(13, 20)
			Me.TextBox37.TabIndex = 100
			Me.TextBox37.TabStop = False
			Me.TextBox37.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox37.Visible = False
			Me.TextBox39.BackColor = Global.System.Drawing.Color.White
			Me.TextBox39.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox39.Location = New Global.System.Drawing.Point(109, 51)
			Me.TextBox39.Name = "TextBox39"
			Me.TextBox39.[ReadOnly] = True
			Me.TextBox39.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox39.TabIndex = 85
			Me.TextBox39.TabStop = False
			Me.TextBox39.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label46.AutoSize = True
			Me.Label46.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label46.Location = New Global.System.Drawing.Point(-1, 240)
			Me.Label46.Name = "Label46"
			Me.Label46.Size = New Global.System.Drawing.Size(108, 13)
			Me.Label46.TabIndex = 86
			Me.Label46.Text = "Grand Total Service :"
			Me.Label48.AutoSize = True
			Me.Label48.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label48.Location = New Global.System.Drawing.Point(-1, 46)
			Me.Label48.Name = "Label48"
			Me.Label48.Size = New Global.System.Drawing.Size(72, 13)
			Me.Label48.TabIndex = 87
			Me.Label48.Text = "Upfront Paid :"
			Me.TextBox42.BackColor = Global.System.Drawing.Color.White
			Me.TextBox42.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox42.Location = New Global.System.Drawing.Point(109, 78)
			Me.TextBox42.Name = "TextBox42"
			Me.TextBox42.[ReadOnly] = True
			Me.TextBox42.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox42.TabIndex = 88
			Me.TextBox42.TabStop = False
			Me.TextBox42.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label50.AutoSize = True
			Me.Label50.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label50.Location = New Global.System.Drawing.Point(-1, 77)
			Me.Label50.Name = "Label50"
			Me.Label50.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label50.TabIndex = 90
			Me.Label50.Text = "Service Tax :"
			Me.Panel6.BackColor = Global.System.Drawing.Color.White
			Me.Panel6.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel6.Controls.Add(Me.Label103)
			Me.Panel6.Controls.Add(Me.TextBox103)
			Me.Panel6.Controls.Add(Me.TextBox90)
			Me.Panel6.Controls.Add(Me.Label69)
			Me.Panel6.Controls.Add(Me.TextBox45)
			Me.Panel6.Controls.Add(Me.TextBox47)
			Me.Panel6.Controls.Add(Me.TextBox63)
			Me.Panel6.Controls.Add(Me.Label95)
			Me.Panel6.Controls.Add(Me.TextBox84)
			Me.Panel6.Controls.Add(Me.Label84)
			Me.Panel6.Controls.Add(Me.TextBox72)
			Me.Panel6.Controls.Add(Me.Label70)
			Me.Panel6.Controls.Add(Me.Label57)
			Me.Panel6.Controls.Add(Me.Label56)
			Me.Panel6.Controls.Add(Me.TextBox46)
			Me.Panel6.Controls.Add(Me.Label55)
			Me.Panel6.Controls.Add(Me.Label52)
			Me.Panel6.Controls.Add(Me.TextBox44)
			Me.Panel6.Controls.Add(Me.Label53)
			Me.Panel6.Controls.Add(Me.Label54)
			Me.Panel6.Controls.Add(Me.TextBox41)
			Me.Panel6.Location = New Global.System.Drawing.Point(5, 320)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(222, 261)
			Me.Panel6.TabIndex = 109
			Me.Label103.AutoSize = True
			Me.Label103.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label103.Location = New Global.System.Drawing.Point(0, 241)
			Me.Label103.Name = "Label103"
			Me.Label103.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label103.TabIndex = 150
			Me.Label103.Text = "Grand Total :"
			Me.TextBox103.BackColor = Global.System.Drawing.Color.Blue
			Me.TextBox103.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox103.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold)
			Me.TextBox103.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox103.Location = New Global.System.Drawing.Point(108, 241)
			Me.TextBox103.Name = "TextBox103"
			Me.TextBox103.[ReadOnly] = True
			Me.TextBox103.Size = New Global.System.Drawing.Size(107, 15)
			Me.TextBox103.TabIndex = 149
			Me.TextBox103.TabStop = False
			Me.TextBox103.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox90.BackColor = Global.System.Drawing.Color.White
			Me.TextBox90.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox90.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox90.Location = New Global.System.Drawing.Point(110, 194)
			Me.TextBox90.Name = "TextBox90"
			Me.TextBox90.[ReadOnly] = True
			Me.TextBox90.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox90.TabIndex = 123
			Me.TextBox90.TabStop = False
			Me.TextBox90.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label69.AutoSize = True
			Me.Label69.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label69.Location = New Global.System.Drawing.Point(0, 192)
			Me.Label69.Name = "Label69"
			Me.Label69.Size = New Global.System.Drawing.Size(111, 13)
			Me.Label69.TabIndex = 122
			Me.Label69.Text = "Total Receipt (Bank) :"
			Me.TextBox45.BackColor = Global.System.Drawing.Color.White
			Me.TextBox45.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox45.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox45.Location = New Global.System.Drawing.Point(114, 66)
			Me.TextBox45.Name = "TextBox45"
			Me.TextBox45.[ReadOnly] = True
			Me.TextBox45.Size = New Global.System.Drawing.Size(103, 13)
			Me.TextBox45.TabIndex = 110
			Me.TextBox45.TabStop = False
			Me.TextBox45.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox47.BackColor = Global.System.Drawing.Color.White
			Me.TextBox47.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox47.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox47.Location = New Global.System.Drawing.Point(110, 88)
			Me.TextBox47.Name = "TextBox47"
			Me.TextBox47.[ReadOnly] = True
			Me.TextBox47.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox47.TabIndex = 114
			Me.TextBox47.TabStop = False
			Me.TextBox47.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox63.BackColor = Global.System.Drawing.Color.White
			Me.TextBox63.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox63.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox63.Location = New Global.System.Drawing.Point(110, 44)
			Me.TextBox63.Name = "TextBox63"
			Me.TextBox63.[ReadOnly] = True
			Me.TextBox63.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox63.TabIndex = 116
			Me.TextBox63.TabStop = False
			Me.TextBox63.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label95.AutoSize = True
			Me.Label95.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label95.Location = New Global.System.Drawing.Point(-1, 129)
			Me.Label95.Name = "Label95"
			Me.Label95.Size = New Global.System.Drawing.Size(99, 13)
			Me.Label95.TabIndex = 121
			Me.Label95.Text = "Receipt (By Bank) :"
			Me.TextBox84.BackColor = Global.System.Drawing.Color.White
			Me.TextBox84.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox84.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox84.Location = New Global.System.Drawing.Point(110, 132)
			Me.TextBox84.Name = "TextBox84"
			Me.TextBox84.[ReadOnly] = True
			Me.TextBox84.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox84.TabIndex = 120
			Me.TextBox84.TabStop = False
			Me.TextBox84.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label84.AutoSize = True
			Me.Label84.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label84.Location = New Global.System.Drawing.Point(0, 151)
			Me.Label84.Name = "Label84"
			Me.Label84.Size = New Global.System.Drawing.Size(83, 13)
			Me.Label84.TabIndex = 119
			Me.Label84.Text = "Sale (By Bank) :"
			Me.TextBox72.BackColor = Global.System.Drawing.Color.White
			Me.TextBox72.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox72.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox72.Location = New Global.System.Drawing.Point(110, 154)
			Me.TextBox72.Name = "TextBox72"
			Me.TextBox72.[ReadOnly] = True
			Me.TextBox72.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox72.TabIndex = 118
			Me.TextBox72.TabStop = False
			Me.TextBox72.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label70.AutoSize = True
			Me.Label70.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label70.Location = New Global.System.Drawing.Point(0, 41)
			Me.Label70.Name = "Label70"
			Me.Label70.Size = New Global.System.Drawing.Size(112, 13)
			Me.Label70.TabIndex = 117
			Me.Label70.Text = "PurcReturn(By Cash) :"
			Me.Label57.AutoSize = True
			Me.Label57.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label57.Location = New Global.System.Drawing.Point(0, 85)
			Me.Label57.Name = "Label57"
			Me.Label57.Size = New Global.System.Drawing.Size(113, 13)
			Me.Label57.TabIndex = 115
			Me.Label57.Text = "Service Bill (By Cash) :"
			Me.Label56.AutoSize = True
			Me.Label56.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label56.Location = New Global.System.Drawing.Point(0, 211)
			Me.Label56.Name = "Label56"
			Me.Label56.Size = New Global.System.Drawing.Size(110, 13)
			Me.Label56.TabIndex = 113
			Me.Label56.Text = "Total Receipt (Cash) :"
			Me.TextBox46.BackColor = Global.System.Drawing.Color.White
			Me.TextBox46.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox46.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox46.Location = New Global.System.Drawing.Point(110, 213)
			Me.TextBox46.Name = "TextBox46"
			Me.TextBox46.[ReadOnly] = True
			Me.TextBox46.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox46.TabIndex = 112
			Me.TextBox46.TabStop = False
			Me.TextBox46.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label55.AutoSize = True
			Me.Label55.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label55.Location = New Global.System.Drawing.Point(0, 63)
			Me.Label55.Name = "Label55"
			Me.Label55.Size = New Global.System.Drawing.Size(116, 13)
			Me.Label55.TabIndex = 111
			Me.Label55.Text = "Serv upfront(By Cash) :"
			Me.Label52.AutoSize = True
			Me.Label52.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label52.Location = New Global.System.Drawing.Point(0, 19)
			Me.Label52.Name = "Label52"
			Me.Label52.Size = New Global.System.Drawing.Size(82, 13)
			Me.Label52.TabIndex = 109
			Me.Label52.Text = "Sale (By Cash) :"
			Me.TextBox44.BackColor = Global.System.Drawing.Color.White
			Me.TextBox44.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox44.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox44.Location = New Global.System.Drawing.Point(110, 22)
			Me.TextBox44.Name = "TextBox44"
			Me.TextBox44.[ReadOnly] = True
			Me.TextBox44.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox44.TabIndex = 108
			Me.TextBox44.TabStop = False
			Me.TextBox44.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label53.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label53.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label53.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label53.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label53.ForeColor = Global.System.Drawing.Color.White
			Me.Label53.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label53.Name = "Label53"
			Me.Label53.Size = New Global.System.Drawing.Size(220, 17)
			Me.Label53.TabIndex = 107
			Me.Label53.Text = "Receipt"
			Me.Label53.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label54.AutoSize = True
			Me.Label54.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label54.Location = New Global.System.Drawing.Point(-1, 107)
			Me.Label54.Name = "Label54"
			Me.Label54.Size = New Global.System.Drawing.Size(98, 13)
			Me.Label54.TabIndex = 101
			Me.Label54.Text = "Receipt (By Cash) :"
			Me.TextBox41.BackColor = Global.System.Drawing.Color.White
			Me.TextBox41.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox41.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox41.Location = New Global.System.Drawing.Point(110, 110)
			Me.TextBox41.Name = "TextBox41"
			Me.TextBox41.[ReadOnly] = True
			Me.TextBox41.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox41.TabIndex = 84
			Me.TextBox41.TabStop = False
			Me.TextBox41.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Panel7.BackColor = Global.System.Drawing.Color.White
			Me.Panel7.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel7.Controls.Add(Me.Label104)
			Me.Panel7.Controls.Add(Me.TextBox102)
			Me.Panel7.Controls.Add(Me.Label68)
			Me.Panel7.Controls.Add(Me.TextBox89)
			Me.Panel7.Controls.Add(Me.TextBox88)
			Me.Panel7.Controls.Add(Me.Label67)
			Me.Panel7.Controls.Add(Me.TextBox48)
			Me.Panel7.Controls.Add(Me.Label96)
			Me.Panel7.Controls.Add(Me.TextBox85)
			Me.Panel7.Controls.Add(Me.TextBox51)
			Me.Panel7.Controls.Add(Me.Label61)
			Me.Panel7.Controls.Add(Me.Label60)
			Me.Panel7.Controls.Add(Me.TextBox50)
			Me.Panel7.Controls.Add(Me.Label58)
			Me.Panel7.Controls.Add(Me.Label45)
			Me.Panel7.Controls.Add(Me.Label47)
			Me.Panel7.Controls.Add(Me.TextBox40)
			Me.Panel7.Location = New Global.System.Drawing.Point(226, 320)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(222, 261)
			Me.Panel7.TabIndex = 110
			Me.Label104.AutoSize = True
			Me.Label104.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label104.Location = New Global.System.Drawing.Point(0, 240)
			Me.Label104.Name = "Label104"
			Me.Label104.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label104.TabIndex = 151
			Me.Label104.Text = "Grand Total :"
			Me.TextBox102.BackColor = Global.System.Drawing.Color.Red
			Me.TextBox102.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox102.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold)
			Me.TextBox102.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox102.Location = New Global.System.Drawing.Point(108, 241)
			Me.TextBox102.Name = "TextBox102"
			Me.TextBox102.[ReadOnly] = True
			Me.TextBox102.Size = New Global.System.Drawing.Size(107, 15)
			Me.TextBox102.TabIndex = 149
			Me.TextBox102.TabStop = False
			Me.TextBox102.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label68.AutoSize = True
			Me.Label68.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label68.Location = New Global.System.Drawing.Point(-1, 191)
			Me.Label68.Name = "Label68"
			Me.Label68.Size = New Global.System.Drawing.Size(115, 13)
			Me.Label68.TabIndex = 121
			Me.Label68.Text = "Total Payment (Bank) :"
			Me.TextBox89.BackColor = Global.System.Drawing.Color.White
			Me.TextBox89.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox89.ForeColor = Global.System.Drawing.Color.Red
			Me.TextBox89.Location = New Global.System.Drawing.Point(109, 193)
			Me.TextBox89.Name = "TextBox89"
			Me.TextBox89.[ReadOnly] = True
			Me.TextBox89.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox89.TabIndex = 120
			Me.TextBox89.TabStop = False
			Me.TextBox89.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox88.BackColor = Global.System.Drawing.Color.White
			Me.TextBox88.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox88.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox88.Location = New Global.System.Drawing.Point(109, 44)
			Me.TextBox88.Name = "TextBox88"
			Me.TextBox88.[ReadOnly] = True
			Me.TextBox88.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox88.TabIndex = 119
			Me.TextBox88.TabStop = False
			Me.TextBox88.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label67.AutoSize = True
			Me.Label67.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label67.Location = New Global.System.Drawing.Point(0, 41)
			Me.Label67.Name = "Label67"
			Me.Label67.Size = New Global.System.Drawing.Size(107, 13)
			Me.Label67.TabIndex = 118
			Me.Label67.Text = "Purchase (By Bank) :"
			Me.TextBox48.BackColor = Global.System.Drawing.Color.White
			Me.TextBox48.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox48.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox48.Location = New Global.System.Drawing.Point(109, 66)
			Me.TextBox48.Name = "TextBox48"
			Me.TextBox48.[ReadOnly] = True
			Me.TextBox48.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox48.TabIndex = 108
			Me.TextBox48.TabStop = False
			Me.TextBox48.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label96.AutoSize = True
			Me.Label96.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label96.Location = New Global.System.Drawing.Point(0, 107)
			Me.Label96.Name = "Label96"
			Me.Label96.Size = New Global.System.Drawing.Size(103, 13)
			Me.Label96.TabIndex = 117
			Me.Label96.Text = "Payment (By Bank) :"
			Me.TextBox85.BackColor = Global.System.Drawing.Color.White
			Me.TextBox85.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox85.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox85.Location = New Global.System.Drawing.Point(109, 110)
			Me.TextBox85.Name = "TextBox85"
			Me.TextBox85.[ReadOnly] = True
			Me.TextBox85.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox85.TabIndex = 116
			Me.TextBox85.TabStop = False
			Me.TextBox85.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox51.BackColor = Global.System.Drawing.Color.White
			Me.TextBox51.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox51.ForeColor = Global.System.Drawing.Color.Red
			Me.TextBox51.Location = New Global.System.Drawing.Point(109, 212)
			Me.TextBox51.Name = "TextBox51"
			Me.TextBox51.[ReadOnly] = True
			Me.TextBox51.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox51.TabIndex = 114
			Me.TextBox51.TabStop = False
			Me.TextBox51.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label61.AutoSize = True
			Me.Label61.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label61.Location = New Global.System.Drawing.Point(0, 211)
			Me.Label61.Name = "Label61"
			Me.Label61.Size = New Global.System.Drawing.Size(114, 13)
			Me.Label61.TabIndex = 115
			Me.Label61.Text = "Total Payment (Cash) :"
			Me.Label60.AutoSize = True
			Me.Label60.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label60.Location = New Global.System.Drawing.Point(0, 85)
			Me.Label60.Name = "Label60"
			Me.Label60.Size = New Global.System.Drawing.Size(102, 13)
			Me.Label60.TabIndex = 113
			Me.Label60.Text = "Payment (By Cash) :"
			Me.TextBox50.BackColor = Global.System.Drawing.Color.White
			Me.TextBox50.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox50.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox50.Location = New Global.System.Drawing.Point(109, 88)
			Me.TextBox50.Name = "TextBox50"
			Me.TextBox50.[ReadOnly] = True
			Me.TextBox50.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox50.TabIndex = 112
			Me.TextBox50.TabStop = False
			Me.TextBox50.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label58.AutoSize = True
			Me.Label58.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label58.Location = New Global.System.Drawing.Point(0, 63)
			Me.Label58.Name = "Label58"
			Me.Label58.Size = New Global.System.Drawing.Size(114, 13)
			Me.Label58.TabIndex = 109
			Me.Label58.Text = "Sale Return(By Cash) :"
			Me.Label45.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label45.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label45.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label45.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label45.ForeColor = Global.System.Drawing.Color.White
			Me.Label45.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label45.Name = "Label45"
			Me.Label45.Size = New Global.System.Drawing.Size(220, 17)
			Me.Label45.TabIndex = 107
			Me.Label45.Text = "Payment"
			Me.Label45.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label47.AutoSize = True
			Me.Label47.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label47.Location = New Global.System.Drawing.Point(0, 19)
			Me.Label47.Name = "Label47"
			Me.Label47.Size = New Global.System.Drawing.Size(106, 13)
			Me.Label47.TabIndex = 101
			Me.Label47.Text = "Purchase (By Cash) :"
			Me.TextBox40.BackColor = Global.System.Drawing.Color.White
			Me.TextBox40.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox40.ForeColor = Global.System.Drawing.Color.Black
			Me.TextBox40.Location = New Global.System.Drawing.Point(109, 22)
			Me.TextBox40.Name = "TextBox40"
			Me.TextBox40.[ReadOnly] = True
			Me.TextBox40.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox40.TabIndex = 84
			Me.TextBox40.TabStop = False
			Me.TextBox40.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Panel8.BackColor = Global.System.Drawing.Color.White
			Me.Panel8.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel8.Controls.Add(Me.Label105)
			Me.Panel8.Controls.Add(Me.TextBox101)
			Me.Panel8.Controls.Add(Me.TextBox94)
			Me.Panel8.Controls.Add(Me.Label51)
			Me.Panel8.Controls.Add(Me.TextBox65)
			Me.Panel8.Controls.Add(Me.Label81)
			Me.Panel8.Controls.Add(Me.Label71)
			Me.Panel8.Controls.Add(Me.TextBox91)
			Me.Panel8.Controls.Add(Me.Label72)
			Me.Panel8.Controls.Add(Me.Label73)
			Me.Panel8.Controls.Add(Me.TextBox92)
			Me.Panel8.Controls.Add(Me.TextBox93)
			Me.Panel8.Controls.Add(Me.Label89)
			Me.Panel8.Controls.Add(Me.TextBox77)
			Me.Panel8.Controls.Add(Me.Label88)
			Me.Panel8.Controls.Add(Me.Label87)
			Me.Panel8.Controls.Add(Me.TextBox76)
			Me.Panel8.Controls.Add(Me.TextBox75)
			Me.Panel8.Controls.Add(Me.Label49)
			Me.Panel8.Location = New Global.System.Drawing.Point(447, 320)
			Me.Panel8.Name = "Panel8"
			Me.Panel8.Size = New Global.System.Drawing.Size(222, 261)
			Me.Panel8.TabIndex = 111
			Me.Label105.AutoSize = True
			Me.Label105.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label105.Location = New Global.System.Drawing.Point(0, 240)
			Me.Label105.Name = "Label105"
			Me.Label105.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label105.TabIndex = 152
			Me.Label105.Text = "Grand Total :"
			Me.TextBox101.BackColor = Global.System.Drawing.Color.Green
			Me.TextBox101.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox101.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold)
			Me.TextBox101.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox101.Location = New Global.System.Drawing.Point(108, 241)
			Me.TextBox101.Name = "TextBox101"
			Me.TextBox101.[ReadOnly] = True
			Me.TextBox101.Size = New Global.System.Drawing.Size(107, 15)
			Me.TextBox101.TabIndex = 151
			Me.TextBox101.TabStop = False
			Me.TextBox101.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox94.BackColor = Global.System.Drawing.Color.White
			Me.TextBox94.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox94.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.TextBox94.Location = New Global.System.Drawing.Point(108, 195)
			Me.TextBox94.Name = "TextBox94"
			Me.TextBox94.[ReadOnly] = True
			Me.TextBox94.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox94.TabIndex = 148
			Me.TextBox94.TabStop = False
			Me.TextBox94.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label51.AutoSize = True
			Me.Label51.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label51.Location = New Global.System.Drawing.Point(-1, 192)
			Me.Label51.Name = "Label51"
			Me.Label51.Size = New Global.System.Drawing.Size(109, 13)
			Me.Label51.TabIndex = 147
			Me.Label51.Text = "Total Income (Bank) :"
			Me.TextBox65.BackColor = Global.System.Drawing.Color.White
			Me.TextBox65.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox65.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.TextBox65.Location = New Global.System.Drawing.Point(108, 213)
			Me.TextBox65.Name = "TextBox65"
			Me.TextBox65.[ReadOnly] = True
			Me.TextBox65.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox65.TabIndex = 108
			Me.TextBox65.TabStop = False
			Me.TextBox65.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label81.AutoSize = True
			Me.Label81.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label81.Location = New Global.System.Drawing.Point(-1, 211)
			Me.Label81.Name = "Label81"
			Me.Label81.Size = New Global.System.Drawing.Size(108, 13)
			Me.Label81.TabIndex = 146
			Me.Label81.Text = "Total Income (Cash) :"
			Me.Label71.AutoSize = True
			Me.Label71.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label71.Location = New Global.System.Drawing.Point(-1, 107)
			Me.Label71.Name = "Label71"
			Me.Label71.Size = New Global.System.Drawing.Size(97, 13)
			Me.Label71.TabIndex = 145
			Me.Label71.Text = "Income (By Bank) :"
			Me.TextBox91.BackColor = Global.System.Drawing.Color.White
			Me.TextBox91.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox91.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.TextBox91.Location = New Global.System.Drawing.Point(108, 108)
			Me.TextBox91.Name = "TextBox91"
			Me.TextBox91.[ReadOnly] = True
			Me.TextBox91.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox91.TabIndex = 144
			Me.TextBox91.TabStop = False
			Me.TextBox91.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label72.AutoSize = True
			Me.Label72.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label72.Location = New Global.System.Drawing.Point(-1, 91)
			Me.Label72.Name = "Label72"
			Me.Label72.Size = New Global.System.Drawing.Size(117, 13)
			Me.Label72.TabIndex = 143
			Me.Label72.Text = "Loan Libility (By Bank) :"
			Me.Label73.AutoSize = True
			Me.Label73.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label73.Location = New Global.System.Drawing.Point(-1, 72)
			Me.Label73.Name = "Label73"
			Me.Label73.Size = New Global.System.Drawing.Size(115, 13)
			Me.Label73.TabIndex = 142
			Me.Label73.Text = "Capital A/c (By Bank) :"
			Me.TextBox92.BackColor = Global.System.Drawing.Color.White
			Me.TextBox92.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox92.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.TextBox92.Location = New Global.System.Drawing.Point(108, 74)
			Me.TextBox92.Name = "TextBox92"
			Me.TextBox92.[ReadOnly] = True
			Me.TextBox92.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox92.TabIndex = 141
			Me.TextBox92.TabStop = False
			Me.TextBox92.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox93.BackColor = Global.System.Drawing.Color.White
			Me.TextBox93.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox93.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.TextBox93.Location = New Global.System.Drawing.Point(108, 91)
			Me.TextBox93.Name = "TextBox93"
			Me.TextBox93.[ReadOnly] = True
			Me.TextBox93.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox93.TabIndex = 140
			Me.TextBox93.TabStop = False
			Me.TextBox93.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label89.AutoSize = True
			Me.Label89.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label89.Location = New Global.System.Drawing.Point(-1, 54)
			Me.Label89.Name = "Label89"
			Me.Label89.Size = New Global.System.Drawing.Size(96, 13)
			Me.Label89.TabIndex = 121
			Me.Label89.Text = "Income (By Cash) :"
			Me.TextBox77.BackColor = Global.System.Drawing.Color.White
			Me.TextBox77.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox77.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.TextBox77.Location = New Global.System.Drawing.Point(108, 55)
			Me.TextBox77.Name = "TextBox77"
			Me.TextBox77.[ReadOnly] = True
			Me.TextBox77.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox77.TabIndex = 120
			Me.TextBox77.TabStop = False
			Me.TextBox77.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label88.AutoSize = True
			Me.Label88.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label88.Location = New Global.System.Drawing.Point(-1, 38)
			Me.Label88.Name = "Label88"
			Me.Label88.Size = New Global.System.Drawing.Size(116, 13)
			Me.Label88.TabIndex = 119
			Me.Label88.Text = "Loan Libility (By Cash) :"
			Me.Label87.AutoSize = True
			Me.Label87.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label87.Location = New Global.System.Drawing.Point(-1, 19)
			Me.Label87.Name = "Label87"
			Me.Label87.Size = New Global.System.Drawing.Size(114, 13)
			Me.Label87.TabIndex = 118
			Me.Label87.Text = "Capital A/c (By Cash) :"
			Me.TextBox76.BackColor = Global.System.Drawing.Color.White
			Me.TextBox76.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox76.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.TextBox76.Location = New Global.System.Drawing.Point(108, 21)
			Me.TextBox76.Name = "TextBox76"
			Me.TextBox76.[ReadOnly] = True
			Me.TextBox76.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox76.TabIndex = 117
			Me.TextBox76.TabStop = False
			Me.TextBox76.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox75.BackColor = Global.System.Drawing.Color.White
			Me.TextBox75.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox75.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.TextBox75.Location = New Global.System.Drawing.Point(108, 38)
			Me.TextBox75.Name = "TextBox75"
			Me.TextBox75.[ReadOnly] = True
			Me.TextBox75.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox75.TabIndex = 116
			Me.TextBox75.TabStop = False
			Me.TextBox75.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label49.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label49.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label49.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label49.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label49.ForeColor = Global.System.Drawing.Color.White
			Me.Label49.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label49.Name = "Label49"
			Me.Label49.Size = New Global.System.Drawing.Size(220, 17)
			Me.Label49.TabIndex = 107
			Me.Label49.Text = "Income"
			Me.Label49.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.TextBox87.BackColor = Global.System.Drawing.Color.White
			Me.TextBox87.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox87.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox87.Location = New Global.System.Drawing.Point(110, 150)
			Me.TextBox87.Name = "TextBox87"
			Me.TextBox87.[ReadOnly] = True
			Me.TextBox87.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox87.TabIndex = 139
			Me.TextBox87.TabStop = False
			Me.TextBox87.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label102.AutoSize = True
			Me.Label102.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label102.Location = New Global.System.Drawing.Point(0, 148)
			Me.Label102.Name = "Label102"
			Me.Label102.Size = New Global.System.Drawing.Size(93, 13)
			Me.Label102.TabIndex = 138
			Me.Label102.Text = "Payroll (By Bank) :"
			Me.TextBox86.BackColor = Global.System.Drawing.Color.White
			Me.TextBox86.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox86.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox86.Location = New Global.System.Drawing.Point(110, 132)
			Me.TextBox86.Name = "TextBox86"
			Me.TextBox86.[ReadOnly] = True
			Me.TextBox86.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox86.TabIndex = 137
			Me.TextBox86.TabStop = False
			Me.TextBox86.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label101.AutoSize = True
			Me.Label101.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label101.Location = New Global.System.Drawing.Point(0, 130)
			Me.Label101.Name = "Label101"
			Me.Label101.Size = New Global.System.Drawing.Size(92, 13)
			Me.Label101.TabIndex = 136
			Me.Label101.Text = "Payroll (By Cash) :"
			Me.Label92.AutoSize = True
			Me.Label92.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label92.Location = New Global.System.Drawing.Point(-1, 53)
			Me.Label92.Name = "Label92"
			Me.Label92.Size = New Global.System.Drawing.Size(107, 13)
			Me.Label92.TabIndex = 135
			Me.Label92.Text = "Expenses (By Cash) :"
			Me.Label91.AutoSize = True
			Me.Label91.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label91.Location = New Global.System.Drawing.Point(-1, 36)
			Me.Label91.Name = "Label91"
			Me.Label91.Size = New Global.System.Drawing.Size(125, 13)
			Me.Label91.TabIndex = 134
			Me.Label91.Text = "Loan (Assets) (By Cash) :"
			Me.Label90.AutoSize = True
			Me.Label90.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label90.Location = New Global.System.Drawing.Point(-1, 19)
			Me.Label90.Name = "Label90"
			Me.Label90.Size = New Global.System.Drawing.Size(120, 13)
			Me.Label90.TabIndex = 133
			Me.Label90.Text = "Fixed Assets (By Cash) :"
			Me.TextBox80.BackColor = Global.System.Drawing.Color.White
			Me.TextBox80.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox80.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox80.Location = New Global.System.Drawing.Point(110, 55)
			Me.TextBox80.Name = "TextBox80"
			Me.TextBox80.[ReadOnly] = True
			Me.TextBox80.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox80.TabIndex = 124
			Me.TextBox80.TabStop = False
			Me.TextBox80.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox79.BackColor = Global.System.Drawing.Color.White
			Me.TextBox79.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox79.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox79.Location = New Global.System.Drawing.Point(110, 37)
			Me.TextBox79.Name = "TextBox79"
			Me.TextBox79.[ReadOnly] = True
			Me.TextBox79.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox79.TabIndex = 123
			Me.TextBox79.TabStop = False
			Me.TextBox79.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox78.BackColor = Global.System.Drawing.Color.White
			Me.TextBox78.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox78.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox78.Location = New Global.System.Drawing.Point(110, 19)
			Me.TextBox78.Name = "TextBox78"
			Me.TextBox78.[ReadOnly] = True
			Me.TextBox78.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox78.TabIndex = 122
			Me.TextBox78.TabStop = False
			Me.TextBox78.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Panel9.BackColor = Global.System.Drawing.Color.White
			Me.Panel9.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel9.Controls.Add(Me.Label75)
			Me.Panel9.Controls.Add(Me.TextBox74)
			Me.Panel9.Controls.Add(Me.TextBox67)
			Me.Panel9.Controls.Add(Me.Label85)
			Me.Panel9.Controls.Add(Me.TextBox71)
			Me.Panel9.Controls.Add(Me.Label79)
			Me.Panel9.Controls.Add(Me.TextBox49)
			Me.Panel9.Controls.Add(Me.TextBox70)
			Me.Panel9.Controls.Add(Me.Label74)
			Me.Panel9.Controls.Add(Me.TextBox81)
			Me.Panel9.Controls.Add(Me.TextBox66)
			Me.Panel9.Controls.Add(Me.Label94)
			Me.Panel9.Controls.Add(Me.Label82)
			Me.Panel9.Controls.Add(Me.TextBox53)
			Me.Panel9.Controls.Add(Me.Label76)
			Me.Panel9.Controls.Add(Me.Label80)
			Me.Panel9.Controls.Add(Me.TextBox68)
			Me.Panel9.Controls.Add(Me.Label59)
			Me.Panel9.Controls.Add(Me.Label77)
			Me.Panel9.Controls.Add(Me.TextBox64)
			Me.Panel9.Controls.Add(Me.TextBox69)
			Me.Panel9.Controls.Add(Me.Label63)
			Me.Panel9.Controls.Add(Me.Label64)
			Me.Panel9.Controls.Add(Me.TextBox54)
			Me.Panel9.Controls.Add(Me.Label65)
			Me.Panel9.Controls.Add(Me.Label66)
			Me.Panel9.Controls.Add(Me.TextBox55)
			Me.Panel9.Location = New Global.System.Drawing.Point(889, 320)
			Me.Panel9.Name = "Panel9"
			Me.Panel9.Size = New Global.System.Drawing.Size(221, 261)
			Me.Panel9.TabIndex = 112
			Me.Label75.AutoSize = True
			Me.Label75.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label75.Location = New Global.System.Drawing.Point(0, 223)
			Me.Label75.Name = "Label75"
			Me.Label75.Size = New Global.System.Drawing.Size(97, 13)
			Me.Label75.TabIndex = 113
			Me.Label75.Text = "Input Service Tax :"
			Me.TextBox74.BackColor = Global.System.Drawing.Color.White
			Me.TextBox74.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox74.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox74.Location = New Global.System.Drawing.Point(108, 191)
			Me.TextBox74.Name = "TextBox74"
			Me.TextBox74.[ReadOnly] = True
			Me.TextBox74.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox74.TabIndex = 116
			Me.TextBox74.TabStop = False
			Me.TextBox74.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox67.BackColor = Global.System.Drawing.Color.White
			Me.TextBox67.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox67.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox67.Location = New Global.System.Drawing.Point(109, 225)
			Me.TextBox67.Name = "TextBox67"
			Me.TextBox67.[ReadOnly] = True
			Me.TextBox67.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox67.TabIndex = 112
			Me.TextBox67.TabStop = False
			Me.TextBox67.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label85.AutoSize = True
			Me.Label85.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label85.Location = New Global.System.Drawing.Point(0, 189)
			Me.Label85.Name = "Label85"
			Me.Label85.Size = New Global.System.Drawing.Size(111, 13)
			Me.Label85.TabIndex = 131
			Me.Label85.Text = "I/P CESS (Pur RCM) :"
			Me.TextBox71.BackColor = Global.System.Drawing.Color.White
			Me.TextBox71.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox71.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox71.Location = New Global.System.Drawing.Point(109, 81)
			Me.TextBox71.Name = "TextBox71"
			Me.TextBox71.[ReadOnly] = True
			Me.TextBox71.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox71.TabIndex = 116
			Me.TextBox71.TabStop = False
			Me.TextBox71.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label79.AutoSize = True
			Me.Label79.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label79.Location = New Global.System.Drawing.Point(0, 206)
			Me.Label79.Name = "Label79"
			Me.Label79.Size = New Global.System.Drawing.Size(107, 13)
			Me.Label79.TabIndex = 101
			Me.Label79.Text = "CESS (Purc Return) :"
			Me.TextBox49.BackColor = Global.System.Drawing.Color.White
			Me.TextBox49.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox49.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox49.Location = New Global.System.Drawing.Point(109, 62)
			Me.TextBox49.Name = "TextBox49"
			Me.TextBox49.[ReadOnly] = True
			Me.TextBox49.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox49.TabIndex = 114
			Me.TextBox49.TabStop = False
			Me.TextBox49.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox70.BackColor = Global.System.Drawing.Color.White
			Me.TextBox70.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox70.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox70.Location = New Global.System.Drawing.Point(108, 209)
			Me.TextBox70.Name = "TextBox70"
			Me.TextBox70.[ReadOnly] = True
			Me.TextBox70.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox70.TabIndex = 84
			Me.TextBox70.TabStop = False
			Me.TextBox70.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label74.AutoSize = True
			Me.Label74.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label74.Location = New Global.System.Drawing.Point(-1, 170)
			Me.Label74.Name = "Label74"
			Me.Label74.Size = New Global.System.Drawing.Size(99, 13)
			Me.Label74.TabIndex = 115
			Me.Label74.Text = "Input CESS (Purc) :"
			Me.TextBox81.BackColor = Global.System.Drawing.Color.White
			Me.TextBox81.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox81.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox81.Location = New Global.System.Drawing.Point(109, 117)
			Me.TextBox81.Name = "TextBox81"
			Me.TextBox81.[ReadOnly] = True
			Me.TextBox81.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox81.TabIndex = 131
			Me.TextBox81.TabStop = False
			Me.TextBox81.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox66.BackColor = Global.System.Drawing.Color.White
			Me.TextBox66.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox66.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox66.Location = New Global.System.Drawing.Point(108, 172)
			Me.TextBox66.Name = "TextBox66"
			Me.TextBox66.[ReadOnly] = True
			Me.TextBox66.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox66.TabIndex = 114
			Me.TextBox66.TabStop = False
			Me.TextBox66.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label94.AutoSize = True
			Me.Label94.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label94.Location = New Global.System.Drawing.Point(0, 117)
			Me.Label94.Name = "Label94"
			Me.Label94.Size = New Global.System.Drawing.Size(113, 13)
			Me.Label94.TabIndex = 132
			Me.Label94.Text = "GST Purc Retn RCM :"
			Me.Label82.AutoSize = True
			Me.Label82.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label82.Location = New Global.System.Drawing.Point(0, 79)
			Me.Label82.Name = "Label82"
			Me.Label82.Size = New Global.System.Drawing.Size(114, 13)
			Me.Label82.TabIndex = 130
			Me.Label82.Text = "Input GST (Pur RCM) :"
			Me.TextBox53.BackColor = Global.System.Drawing.Color.White
			Me.TextBox53.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox53.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox53.Location = New Global.System.Drawing.Point(109, 43)
			Me.TextBox53.Name = "TextBox53"
			Me.TextBox53.[ReadOnly] = True
			Me.TextBox53.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox53.TabIndex = 110
			Me.TextBox53.TabStop = False
			Me.TextBox53.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label76.AutoSize = True
			Me.Label76.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label76.Location = New Global.System.Drawing.Point(-1, 154)
			Me.Label76.Name = "Label76"
			Me.Label76.Size = New Global.System.Drawing.Size(106, 13)
			Me.Label76.TabIndex = 111
			Me.Label76.Text = "CESS (Sale Return) :"
			Me.Label80.AutoSize = True
			Me.Label80.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label80.Location = New Global.System.Drawing.Point(0, 241)
			Me.Label80.Name = "Label80"
			Me.Label80.Size = New Global.System.Drawing.Size(100, 13)
			Me.Label80.TabIndex = 129
			Me.Label80.Text = "GST Paid to Govt. :"
			Me.TextBox68.BackColor = Global.System.Drawing.Color.White
			Me.TextBox68.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox68.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox68.Location = New Global.System.Drawing.Point(108, 153)
			Me.TextBox68.Name = "TextBox68"
			Me.TextBox68.[ReadOnly] = True
			Me.TextBox68.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox68.TabIndex = 110
			Me.TextBox68.TabStop = False
			Me.TextBox68.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label59.AutoSize = True
			Me.Label59.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label59.Location = New Global.System.Drawing.Point(0, 60)
			Me.Label59.Name = "Label59"
			Me.Label59.Size = New Global.System.Drawing.Size(93, 13)
			Me.Label59.TabIndex = 115
			Me.Label59.Text = "Input GST (Purc) :"
			Me.Label77.AutoSize = True
			Me.Label77.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label77.Location = New Global.System.Drawing.Point(0, 135)
			Me.Label77.Name = "Label77"
			Me.Label77.Size = New Global.System.Drawing.Size(106, 13)
			Me.Label77.TabIndex = 109
			Me.Label77.Text = "Output CESS (Sale) :"
			Me.TextBox64.BackColor = Global.System.Drawing.Color.White
			Me.TextBox64.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox64.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox64.Location = New Global.System.Drawing.Point(109, 243)
			Me.TextBox64.Name = "TextBox64"
			Me.TextBox64.[ReadOnly] = True
			Me.TextBox64.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox64.TabIndex = 128
			Me.TextBox64.TabStop = False
			Me.TextBox64.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox69.BackColor = Global.System.Drawing.Color.White
			Me.TextBox69.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox69.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox69.Location = New Global.System.Drawing.Point(108, 136)
			Me.TextBox69.Name = "TextBox69"
			Me.TextBox69.[ReadOnly] = True
			Me.TextBox69.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox69.TabIndex = 108
			Me.TextBox69.TabStop = False
			Me.TextBox69.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label63.AutoSize = True
			Me.Label63.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label63.Location = New Global.System.Drawing.Point(0, 41)
			Me.Label63.Name = "Label63"
			Me.Label63.Size = New Global.System.Drawing.Size(100, 13)
			Me.Label63.TabIndex = 111
			Me.Label63.Text = "GST (Sale Return) :"
			Me.Label64.AutoSize = True
			Me.Label64.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label64.Location = New Global.System.Drawing.Point(0, 21)
			Me.Label64.Name = "Label64"
			Me.Label64.Size = New Global.System.Drawing.Size(100, 13)
			Me.Label64.TabIndex = 109
			Me.Label64.Text = "Output GST (Sale) :"
			Me.TextBox54.BackColor = Global.System.Drawing.Color.White
			Me.TextBox54.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox54.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox54.Location = New Global.System.Drawing.Point(109, 23)
			Me.TextBox54.Name = "TextBox54"
			Me.TextBox54.[ReadOnly] = True
			Me.TextBox54.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox54.TabIndex = 108
			Me.TextBox54.TabStop = False
			Me.TextBox54.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label65.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label65.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label65.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label65.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label65.ForeColor = Global.System.Drawing.Color.White
			Me.Label65.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label65.Name = "Label65"
			Me.Label65.Size = New Global.System.Drawing.Size(219, 17)
			Me.Label65.TabIndex = 107
			Me.Label65.Text = "Tax Summary"
			Me.Label65.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label66.AutoSize = True
			Me.Label66.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label66.Location = New Global.System.Drawing.Point(0, 98)
			Me.Label66.Name = "Label66"
			Me.Label66.Size = New Global.System.Drawing.Size(101, 13)
			Me.Label66.TabIndex = 101
			Me.Label66.Text = "GST (Purc Return) :"
			Me.TextBox55.BackColor = Global.System.Drawing.Color.White
			Me.TextBox55.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox55.ForeColor = Global.System.Drawing.Color.Purple
			Me.TextBox55.Location = New Global.System.Drawing.Point(109, 100)
			Me.TextBox55.Name = "TextBox55"
			Me.TextBox55.[ReadOnly] = True
			Me.TextBox55.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox55.TabIndex = 84
			Me.TextBox55.TabStop = False
			Me.TextBox55.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox52.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.TextBox52.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox52.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox52.Location = New Global.System.Drawing.Point(112, 5)
			Me.TextBox52.Name = "TextBox52"
			Me.TextBox52.[ReadOnly] = True
			Me.TextBox52.Size = New Global.System.Drawing.Size(39, 20)
			Me.TextBox52.TabIndex = 112
			Me.TextBox52.TabStop = False
			Me.TextBox52.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox52.Visible = False
			Me.TextBox57.Location = New Global.System.Drawing.Point(633, 25)
			Me.TextBox57.Name = "TextBox57"
			Me.TextBox57.[ReadOnly] = True
			Me.TextBox57.Size = New Global.System.Drawing.Size(48, 20)
			Me.TextBox57.TabIndex = 116
			Me.TextBox57.TabStop = False
			Me.TextBox57.Visible = False
			Me.TextBox58.Location = New Global.System.Drawing.Point(692, 25)
			Me.TextBox58.Name = "TextBox58"
			Me.TextBox58.[ReadOnly] = True
			Me.TextBox58.Size = New Global.System.Drawing.Size(48, 20)
			Me.TextBox58.TabIndex = 117
			Me.TextBox58.TabStop = False
			Me.TextBox58.Visible = False
			Me.TextBox59.Location = New Global.System.Drawing.Point(770, 25)
			Me.TextBox59.Name = "TextBox59"
			Me.TextBox59.[ReadOnly] = True
			Me.TextBox59.Size = New Global.System.Drawing.Size(48, 20)
			Me.TextBox59.TabIndex = 118
			Me.TextBox59.TabStop = False
			Me.TextBox59.Visible = False
			Me.TextBox60.Location = New Global.System.Drawing.Point(824, 25)
			Me.TextBox60.Name = "TextBox60"
			Me.TextBox60.[ReadOnly] = True
			Me.TextBox60.Size = New Global.System.Drawing.Size(48, 20)
			Me.TextBox60.TabIndex = 119
			Me.TextBox60.TabStop = False
			Me.TextBox60.Visible = False
			Me.TextBox61.Location = New Global.System.Drawing.Point(898, 25)
			Me.TextBox61.Name = "TextBox61"
			Me.TextBox61.[ReadOnly] = True
			Me.TextBox61.Size = New Global.System.Drawing.Size(48, 20)
			Me.TextBox61.TabIndex = 120
			Me.TextBox61.TabStop = False
			Me.TextBox61.Visible = False
			Me.TextBox62.Location = New Global.System.Drawing.Point(965, 25)
			Me.TextBox62.Name = "TextBox62"
			Me.TextBox62.[ReadOnly] = True
			Me.TextBox62.Size = New Global.System.Drawing.Size(48, 20)
			Me.TextBox62.TabIndex = 121
			Me.TextBox62.TabStop = False
			Me.TextBox62.Visible = False
			Me.Panel10.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Panel10.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel10.Controls.Add(Me.GelButton3)
			Me.Panel10.Controls.Add(Me.Button7)
			Me.Panel10.Controls.Add(Me.Button6)
			Me.Panel10.Controls.Add(Me.Button3)
			Me.Panel10.Controls.Add(Me.Button5)
			Me.Panel10.Controls.Add(Me.Button4)
			Me.Panel10.Controls.Add(Me.Panel7)
			Me.Panel10.Controls.Add(Me.Panel12)
			Me.Panel10.Controls.Add(Me.Panel11)
			Me.Panel10.Controls.Add(Me.Panel9)
			Me.Panel10.Controls.Add(Me.Panel8)
			Me.Panel10.Controls.Add(Me.GroupBox2)
			Me.Panel10.Controls.Add(Me.Label93)
			Me.Panel10.Controls.Add(Me.TextBox62)
			Me.Panel10.Controls.Add(Me.Panel1)
			Me.Panel10.Controls.Add(Me.TextBox61)
			Me.Panel10.Controls.Add(Me.Panel3)
			Me.Panel10.Controls.Add(Me.TextBox60)
			Me.Panel10.Controls.Add(Me.Panel2)
			Me.Panel10.Controls.Add(Me.TextBox59)
			Me.Panel10.Controls.Add(Me.TextBox58)
			Me.Panel10.Controls.Add(Me.Panel4)
			Me.Panel10.Controls.Add(Me.TextBox57)
			Me.Panel10.Controls.Add(Me.Panel5)
			Me.Panel10.Controls.Add(Me.Panel6)
			Me.Panel10.Location = New Global.System.Drawing.Point(8, 10)
			Me.Panel10.Name = "Panel10"
			Me.Panel10.Size = New Global.System.Drawing.Size(1118, 589)
			Me.Panel10.TabIndex = 122
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(404, 14)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 538
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.Button7.BackgroundImage = CType(componentResourceManager.GetObject("Button7.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button7.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button7.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button7.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button7.ForeColor = Global.System.Drawing.Color.White
			Me.Button7.Location = New Global.System.Drawing.Point(767, 3)
			Me.Button7.Name = "Button7"
			Me.Button7.Size = New Global.System.Drawing.Size(55, 55)
			Me.Button7.TabIndex = 140
			Me.Button7.TabStop = False
			Me.Button7.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button7.UseVisualStyleBackColor = True
			Me.Button6.BackgroundImage = CType(componentResourceManager.GetObject("Button6.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button6.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button6.ForeColor = Global.System.Drawing.Color.White
			Me.Button6.Location = New Global.System.Drawing.Point(708, 3)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(55, 55)
			Me.Button6.TabIndex = 139
			Me.Button6.TabStop = False
			Me.Button6.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button6.UseVisualStyleBackColor = True
			Me.Button3.BackgroundImage = CType(componentResourceManager.GetObject("Button3.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Location = New Global.System.Drawing.Point(649, 3)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(55, 55)
			Me.Button3.TabIndex = 138
			Me.Button3.TabStop = False
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button3.UseVisualStyleBackColor = True
			Me.Button5.BackgroundImage = CType(componentResourceManager.GetObject("Button5.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button5.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button5.ForeColor = Global.System.Drawing.Color.White
			Me.Button5.Location = New Global.System.Drawing.Point(590, 3)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(55, 55)
			Me.Button5.TabIndex = 137
			Me.Button5.TabStop = False
			Me.Button5.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button5.UseVisualStyleBackColor = True
			Me.Button4.BackgroundImage = CType(componentResourceManager.GetObject("Button4.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.Location = New Global.System.Drawing.Point(531, 3)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(55, 55)
			Me.Button4.TabIndex = 136
			Me.Button4.TabStop = False
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button4.UseVisualStyleBackColor = True
			Me.Panel12.Controls.Add(Me.TextBox73)
			Me.Panel12.Controls.Add(Me.TextBox52)
			Me.Panel12.Controls.Add(Me.Label83)
			Me.Panel12.Controls.Add(Me.Label86)
			Me.Panel12.Location = New Global.System.Drawing.Point(229, 522)
			Me.Panel12.Name = "Panel12"
			Me.Panel12.Size = New Global.System.Drawing.Size(174, 68)
			Me.Panel12.TabIndex = 132
			Me.TextBox73.Location = New Global.System.Drawing.Point(3, 4)
			Me.TextBox73.Name = "TextBox73"
			Me.TextBox73.[ReadOnly] = True
			Me.TextBox73.Size = New Global.System.Drawing.Size(36, 20)
			Me.TextBox73.TabIndex = 130
			Me.TextBox73.TabStop = False
			Me.TextBox73.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox73.Visible = False
			Me.Label83.AutoSize = True
			Me.Label83.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label83.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label83.Location = New Global.System.Drawing.Point(4, 40)
			Me.Label83.Name = "Label83"
			Me.Label83.Size = New Global.System.Drawing.Size(73, 20)
			Me.Label83.TabIndex = 128
			Me.Label83.Text = "Label83"
			Me.Label86.AutoSize = True
			Me.Label86.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label86.ForeColor = Global.System.Drawing.Color.FromArgb(0, 64, 0)
			Me.Label86.Location = New Global.System.Drawing.Point(83, 40)
			Me.Label86.Name = "Label86"
			Me.Label86.Size = New Global.System.Drawing.Size(73, 20)
			Me.Label86.TabIndex = 131
			Me.Label86.Text = "Label86"
			Me.Panel11.BackColor = Global.System.Drawing.Color.White
			Me.Panel11.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel11.Controls.Add(Me.Label106)
			Me.Panel11.Controls.Add(Me.TextBox100)
			Me.Panel11.Controls.Add(Me.TextBox99)
			Me.Panel11.Controls.Add(Me.TextBox98)
			Me.Panel11.Controls.Add(Me.Label99)
			Me.Panel11.Controls.Add(Me.Label100)
			Me.Panel11.Controls.Add(Me.TextBox95)
			Me.Panel11.Controls.Add(Me.Label62)
			Me.Panel11.Controls.Add(Me.Label97)
			Me.Panel11.Controls.Add(Me.Label98)
			Me.Panel11.Controls.Add(Me.TextBox96)
			Me.Panel11.Controls.Add(Me.TextBox97)
			Me.Panel11.Controls.Add(Me.Label78)
			Me.Panel11.Controls.Add(Me.TextBox80)
			Me.Panel11.Controls.Add(Me.Label90)
			Me.Panel11.Controls.Add(Me.Label91)
			Me.Panel11.Controls.Add(Me.TextBox87)
			Me.Panel11.Controls.Add(Me.Label92)
			Me.Panel11.Controls.Add(Me.Label102)
			Me.Panel11.Controls.Add(Me.Label101)
			Me.Panel11.Controls.Add(Me.TextBox86)
			Me.Panel11.Controls.Add(Me.TextBox78)
			Me.Panel11.Controls.Add(Me.TextBox79)
			Me.Panel11.Location = New Global.System.Drawing.Point(667, 320)
			Me.Panel11.Name = "Panel11"
			Me.Panel11.Size = New Global.System.Drawing.Size(223, 261)
			Me.Panel11.TabIndex = 127
			Me.Label106.AutoSize = True
			Me.Label106.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label106.Location = New Global.System.Drawing.Point(-1, 241)
			Me.Label106.Name = "Label106"
			Me.Label106.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label106.TabIndex = 151
			Me.Label106.Text = "Grand Total :"
			Me.TextBox100.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox100.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox100.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold)
			Me.TextBox100.ForeColor = Global.System.Drawing.Color.White
			Me.TextBox100.Location = New Global.System.Drawing.Point(111, 241)
			Me.TextBox100.Name = "TextBox100"
			Me.TextBox100.[ReadOnly] = True
			Me.TextBox100.Size = New Global.System.Drawing.Size(107, 15)
			Me.TextBox100.TabIndex = 150
			Me.TextBox100.TabStop = False
			Me.TextBox100.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox99.BackColor = Global.System.Drawing.Color.White
			Me.TextBox99.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox99.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox99.Location = New Global.System.Drawing.Point(110, 213)
			Me.TextBox99.Name = "TextBox99"
			Me.TextBox99.[ReadOnly] = True
			Me.TextBox99.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox99.TabIndex = 149
			Me.TextBox99.TabStop = False
			Me.TextBox99.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox98.BackColor = Global.System.Drawing.Color.White
			Me.TextBox98.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox98.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox98.Location = New Global.System.Drawing.Point(110, 194)
			Me.TextBox98.Name = "TextBox98"
			Me.TextBox98.[ReadOnly] = True
			Me.TextBox98.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox98.TabIndex = 148
			Me.TextBox98.TabStop = False
			Me.TextBox98.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label99.AutoSize = True
			Me.Label99.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label99.Location = New Global.System.Drawing.Point(-1, 211)
			Me.Label99.Name = "Label99"
			Me.Label99.Size = New Global.System.Drawing.Size(107, 13)
			Me.Label99.TabIndex = 147
			Me.Label99.Text = "Total Exp (By Bank) :"
			Me.Label100.AutoSize = True
			Me.Label100.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label100.Location = New Global.System.Drawing.Point(-1, 193)
			Me.Label100.Name = "Label100"
			Me.Label100.Size = New Global.System.Drawing.Size(106, 13)
			Me.Label100.TabIndex = 146
			Me.Label100.Text = "Total Exp (By Cash) :"
			Me.TextBox95.BackColor = Global.System.Drawing.Color.White
			Me.TextBox95.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox95.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox95.Location = New Global.System.Drawing.Point(110, 106)
			Me.TextBox95.Name = "TextBox95"
			Me.TextBox95.[ReadOnly] = True
			Me.TextBox95.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox95.TabIndex = 142
			Me.TextBox95.TabStop = False
			Me.TextBox95.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label62.AutoSize = True
			Me.Label62.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label62.Location = New Global.System.Drawing.Point(-1, 70)
			Me.Label62.Name = "Label62"
			Me.Label62.Size = New Global.System.Drawing.Size(121, 13)
			Me.Label62.TabIndex = 143
			Me.Label62.Text = "Fixed Assets (By Bank) :"
			Me.Label97.AutoSize = True
			Me.Label97.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label97.Location = New Global.System.Drawing.Point(-1, 87)
			Me.Label97.Name = "Label97"
			Me.Label97.Size = New Global.System.Drawing.Size(126, 13)
			Me.Label97.TabIndex = 144
			Me.Label97.Text = "Loan (Assets) (By Bank) :"
			Me.Label98.AutoSize = True
			Me.Label98.ForeColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label98.Location = New Global.System.Drawing.Point(-1, 104)
			Me.Label98.Name = "Label98"
			Me.Label98.Size = New Global.System.Drawing.Size(108, 13)
			Me.Label98.TabIndex = 145
			Me.Label98.Text = "Expenses (By Bank) :"
			Me.TextBox96.BackColor = Global.System.Drawing.Color.White
			Me.TextBox96.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox96.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox96.Location = New Global.System.Drawing.Point(110, 70)
			Me.TextBox96.Name = "TextBox96"
			Me.TextBox96.[ReadOnly] = True
			Me.TextBox96.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox96.TabIndex = 140
			Me.TextBox96.TabStop = False
			Me.TextBox96.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox97.BackColor = Global.System.Drawing.Color.White
			Me.TextBox97.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox97.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.TextBox97.Location = New Global.System.Drawing.Point(110, 88)
			Me.TextBox97.Name = "TextBox97"
			Me.TextBox97.[ReadOnly] = True
			Me.TextBox97.Size = New Global.System.Drawing.Size(107, 13)
			Me.TextBox97.TabIndex = 141
			Me.TextBox97.TabStop = False
			Me.TextBox97.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label78.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label78.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label78.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label78.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label78.ForeColor = Global.System.Drawing.Color.White
			Me.Label78.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label78.Name = "Label78"
			Me.Label78.Size = New Global.System.Drawing.Size(221, 17)
			Me.Label78.TabIndex = 107
			Me.Label78.Text = "Expenses"
			Me.Label78.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label93.BackColor = Global.System.Drawing.Color.White
			Me.Label93.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 36F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label93.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label93.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label93.Location = New Global.System.Drawing.Point(-1, -1)
			Me.Label93.Name = "Label93"
			Me.Label93.Size = New Global.System.Drawing.Size(1118, 62)
			Me.Label93.TabIndex = 133
			Me.Label93.Text = "Dash Board"
			Me.Label93.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Panel13.BackColor = Global.System.Drawing.Color.White
			Me.Panel13.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel13.Controls.Add(Me.Panel10)
			Me.Panel13.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel13.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel13.Name = "Panel13"
			Me.Panel13.Size = New Global.System.Drawing.Size(1152, 623)
			Me.Panel13.TabIndex = 123
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1152, 623)
			MyBase.Controls.Add(Me.Panel13)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmBalancesheet"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel5.PerformLayout()
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			Me.Panel7.ResumeLayout(False)
			Me.Panel7.PerformLayout()
			Me.Panel8.ResumeLayout(False)
			Me.Panel8.PerformLayout()
			Me.Panel9.ResumeLayout(False)
			Me.Panel9.PerformLayout()
			Me.Panel10.ResumeLayout(False)
			Me.Panel10.PerformLayout()
			Me.Panel12.ResumeLayout(False)
			Me.Panel12.PerformLayout()
			Me.Panel11.ResumeLayout(False)
			Me.Panel11.PerformLayout()
			Me.Panel13.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005A93 RID: 23187
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
