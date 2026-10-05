Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001DC RID: 476
	<DesignerGenerated()>
	Public Partial Class frmProductPlus
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007F47 RID: 32583 RVA: 0x0003E89D File Offset: 0x0003CA9D
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002EB5 RID: 11957
		' (get) Token: 0x06007F4A RID: 32586 RVA: 0x0003E8AB File Offset: 0x0003CAAB
		' (set) Token: 0x06007F4B RID: 32587 RVA: 0x0003E8B5 File Offset: 0x0003CAB5
		Friend Overridable Property Label1 As Label

		' Token: 0x17002EB6 RID: 11958
		' (get) Token: 0x06007F4C RID: 32588 RVA: 0x0003E8BE File Offset: 0x0003CABE
		' (set) Token: 0x06007F4D RID: 32589 RVA: 0x0003E8C8 File Offset: 0x0003CAC8
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17002EB7 RID: 11959
		' (get) Token: 0x06007F4E RID: 32590 RVA: 0x0003E8D1 File Offset: 0x0003CAD1
		' (set) Token: 0x06007F4F RID: 32591 RVA: 0x0003E8DB File Offset: 0x0003CADB
		Friend Overridable Property btnShowAll As GelButton

		' Token: 0x17002EB8 RID: 11960
		' (get) Token: 0x06007F50 RID: 32592 RVA: 0x0003E8E4 File Offset: 0x0003CAE4
		' (set) Token: 0x06007F51 RID: 32593 RVA: 0x0003E8EE File Offset: 0x0003CAEE
		Friend Overridable Property btnExportExcel As GelButton

		' Token: 0x17002EB9 RID: 11961
		' (get) Token: 0x06007F52 RID: 32594 RVA: 0x0003E8F7 File Offset: 0x0003CAF7
		' (set) Token: 0x06007F53 RID: 32595 RVA: 0x0003E901 File Offset: 0x0003CB01
		Friend Overridable Property btnReset As GelButton

		' Token: 0x17002EBA RID: 11962
		' (get) Token: 0x06007F54 RID: 32596 RVA: 0x0003E90A File Offset: 0x0003CB0A
		' (set) Token: 0x06007F55 RID: 32597 RVA: 0x0003E914 File Offset: 0x0003CB14
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17002EBB RID: 11963
		' (get) Token: 0x06007F56 RID: 32598 RVA: 0x0003E91D File Offset: 0x0003CB1D
		' (set) Token: 0x06007F57 RID: 32599 RVA: 0x0003E927 File Offset: 0x0003CB27
		Friend Overridable Property Label9 As Label

		' Token: 0x17002EBC RID: 11964
		' (get) Token: 0x06007F58 RID: 32600 RVA: 0x0003E930 File Offset: 0x0003CB30
		' (set) Token: 0x06007F59 RID: 32601 RVA: 0x0003E93A File Offset: 0x0003CB3A
		Friend Overridable Property cmbRack As ComboBox

		' Token: 0x17002EBD RID: 11965
		' (get) Token: 0x06007F5A RID: 32602 RVA: 0x0003E943 File Offset: 0x0003CB43
		' (set) Token: 0x06007F5B RID: 32603 RVA: 0x0003E94D File Offset: 0x0003CB4D
		Friend Overridable Property Label8 As Label

		' Token: 0x17002EBE RID: 11966
		' (get) Token: 0x06007F5C RID: 32604 RVA: 0x0003E956 File Offset: 0x0003CB56
		' (set) Token: 0x06007F5D RID: 32605 RVA: 0x0003E960 File Offset: 0x0003CB60
		Friend Overridable Property cmbGDown As ComboBox

		' Token: 0x17002EBF RID: 11967
		' (get) Token: 0x06007F5E RID: 32606 RVA: 0x0003E969 File Offset: 0x0003CB69
		' (set) Token: 0x06007F5F RID: 32607 RVA: 0x0003E973 File Offset: 0x0003CB73
		Friend Overridable Property Label7 As Label

		' Token: 0x17002EC0 RID: 11968
		' (get) Token: 0x06007F60 RID: 32608 RVA: 0x0003E97C File Offset: 0x0003CB7C
		' (set) Token: 0x06007F61 RID: 32609 RVA: 0x0003E986 File Offset: 0x0003CB86
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17002EC1 RID: 11969
		' (get) Token: 0x06007F62 RID: 32610 RVA: 0x0003E98F File Offset: 0x0003CB8F
		' (set) Token: 0x06007F63 RID: 32611 RVA: 0x0003E999 File Offset: 0x0003CB99
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17002EC2 RID: 11970
		' (get) Token: 0x06007F64 RID: 32612 RVA: 0x0003E9A2 File Offset: 0x0003CBA2
		' (set) Token: 0x06007F65 RID: 32613 RVA: 0x0003E9AC File Offset: 0x0003CBAC
		Friend Overridable Property Label6 As Label

		' Token: 0x17002EC3 RID: 11971
		' (get) Token: 0x06007F66 RID: 32614 RVA: 0x0003E9B5 File Offset: 0x0003CBB5
		' (set) Token: 0x06007F67 RID: 32615 RVA: 0x0003E9BF File Offset: 0x0003CBBF
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17002EC4 RID: 11972
		' (get) Token: 0x06007F68 RID: 32616 RVA: 0x0003E9C8 File Offset: 0x0003CBC8
		' (set) Token: 0x06007F69 RID: 32617 RVA: 0x0003E9D2 File Offset: 0x0003CBD2
		Friend Overridable Property Label5 As Label

		' Token: 0x17002EC5 RID: 11973
		' (get) Token: 0x06007F6A RID: 32618 RVA: 0x0003E9DB File Offset: 0x0003CBDB
		' (set) Token: 0x06007F6B RID: 32619 RVA: 0x0003E9E5 File Offset: 0x0003CBE5
		Friend Overridable Property txtSubCategory As TextBox

		' Token: 0x17002EC6 RID: 11974
		' (get) Token: 0x06007F6C RID: 32620 RVA: 0x0003E9EE File Offset: 0x0003CBEE
		' (set) Token: 0x06007F6D RID: 32621 RVA: 0x0003E9F8 File Offset: 0x0003CBF8
		Friend Overridable Property Label4 As Label

		' Token: 0x17002EC7 RID: 11975
		' (get) Token: 0x06007F6E RID: 32622 RVA: 0x0003EA01 File Offset: 0x0003CC01
		' (set) Token: 0x06007F6F RID: 32623 RVA: 0x0003EA0B File Offset: 0x0003CC0B
		Friend Overridable Property txtCategory As TextBox

		' Token: 0x17002EC8 RID: 11976
		' (get) Token: 0x06007F70 RID: 32624 RVA: 0x0003EA14 File Offset: 0x0003CC14
		' (set) Token: 0x06007F71 RID: 32625 RVA: 0x0003EA1E File Offset: 0x0003CC1E
		Friend Overridable Property Label2 As Label

		' Token: 0x17002EC9 RID: 11977
		' (get) Token: 0x06007F72 RID: 32626 RVA: 0x0003EA27 File Offset: 0x0003CC27
		' (set) Token: 0x06007F73 RID: 32627 RVA: 0x0003EA31 File Offset: 0x0003CC31
		Friend Overridable Property txtProductName As TextBox

		' Token: 0x17002ECA RID: 11978
		' (get) Token: 0x06007F74 RID: 32628 RVA: 0x0003EA3A File Offset: 0x0003CC3A
		' (set) Token: 0x06007F75 RID: 32629 RVA: 0x0003EA44 File Offset: 0x0003CC44
		Friend Overridable Property Label3 As Label

		' Token: 0x17002ECB RID: 11979
		' (get) Token: 0x06007F76 RID: 32630 RVA: 0x0003EA4D File Offset: 0x0003CC4D
		' (set) Token: 0x06007F77 RID: 32631 RVA: 0x0003EA57 File Offset: 0x0003CC57
		Friend Overridable Property dgw As DataGridView

		' Token: 0x17002ECC RID: 11980
		' (get) Token: 0x06007F78 RID: 32632 RVA: 0x0003EA60 File Offset: 0x0003CC60
		' (set) Token: 0x06007F79 RID: 32633 RVA: 0x0003EA6A File Offset: 0x0003CC6A
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17002ECD RID: 11981
		' (get) Token: 0x06007F7A RID: 32634 RVA: 0x0003EA73 File Offset: 0x0003CC73
		' (set) Token: 0x06007F7B RID: 32635 RVA: 0x0003EA7D File Offset: 0x0003CC7D
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17002ECE RID: 11982
		' (get) Token: 0x06007F7C RID: 32636 RVA: 0x0003EA86 File Offset: 0x0003CC86
		' (set) Token: 0x06007F7D RID: 32637 RVA: 0x0003EA90 File Offset: 0x0003CC90
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17002ECF RID: 11983
		' (get) Token: 0x06007F7E RID: 32638 RVA: 0x0003EA99 File Offset: 0x0003CC99
		' (set) Token: 0x06007F7F RID: 32639 RVA: 0x0003EAA3 File Offset: 0x0003CCA3
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17002ED0 RID: 11984
		' (get) Token: 0x06007F80 RID: 32640 RVA: 0x0003EAAC File Offset: 0x0003CCAC
		' (set) Token: 0x06007F81 RID: 32641 RVA: 0x0003EAB6 File Offset: 0x0003CCB6
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17002ED1 RID: 11985
		' (get) Token: 0x06007F82 RID: 32642 RVA: 0x0003EABF File Offset: 0x0003CCBF
		' (set) Token: 0x06007F83 RID: 32643 RVA: 0x0003EAC9 File Offset: 0x0003CCC9
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17002ED2 RID: 11986
		' (get) Token: 0x06007F84 RID: 32644 RVA: 0x0003EAD2 File Offset: 0x0003CCD2
		' (set) Token: 0x06007F85 RID: 32645 RVA: 0x0003EADC File Offset: 0x0003CCDC
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17002ED3 RID: 11987
		' (get) Token: 0x06007F86 RID: 32646 RVA: 0x0003EAE5 File Offset: 0x0003CCE5
		' (set) Token: 0x06007F87 RID: 32647 RVA: 0x0003EAEF File Offset: 0x0003CCEF
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17002ED4 RID: 11988
		' (get) Token: 0x06007F88 RID: 32648 RVA: 0x0003EAF8 File Offset: 0x0003CCF8
		' (set) Token: 0x06007F89 RID: 32649 RVA: 0x0003EB02 File Offset: 0x0003CD02
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17002ED5 RID: 11989
		' (get) Token: 0x06007F8A RID: 32650 RVA: 0x0003EB0B File Offset: 0x0003CD0B
		' (set) Token: 0x06007F8B RID: 32651 RVA: 0x0003EB15 File Offset: 0x0003CD15
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17002ED6 RID: 11990
		' (get) Token: 0x06007F8C RID: 32652 RVA: 0x0003EB1E File Offset: 0x0003CD1E
		' (set) Token: 0x06007F8D RID: 32653 RVA: 0x0003EB28 File Offset: 0x0003CD28
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17002ED7 RID: 11991
		' (get) Token: 0x06007F8E RID: 32654 RVA: 0x0003EB31 File Offset: 0x0003CD31
		' (set) Token: 0x06007F8F RID: 32655 RVA: 0x0003EB3B File Offset: 0x0003CD3B
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17002ED8 RID: 11992
		' (get) Token: 0x06007F90 RID: 32656 RVA: 0x0003EB44 File Offset: 0x0003CD44
		' (set) Token: 0x06007F91 RID: 32657 RVA: 0x0003EB4E File Offset: 0x0003CD4E
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17002ED9 RID: 11993
		' (get) Token: 0x06007F92 RID: 32658 RVA: 0x0003EB57 File Offset: 0x0003CD57
		' (set) Token: 0x06007F93 RID: 32659 RVA: 0x0003EB61 File Offset: 0x0003CD61
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17002EDA RID: 11994
		' (get) Token: 0x06007F94 RID: 32660 RVA: 0x0003EB6A File Offset: 0x0003CD6A
		' (set) Token: 0x06007F95 RID: 32661 RVA: 0x0003EB74 File Offset: 0x0003CD74
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17002EDB RID: 11995
		' (get) Token: 0x06007F96 RID: 32662 RVA: 0x0003EB7D File Offset: 0x0003CD7D
		' (set) Token: 0x06007F97 RID: 32663 RVA: 0x0003EB87 File Offset: 0x0003CD87
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17002EDC RID: 11996
		' (get) Token: 0x06007F98 RID: 32664 RVA: 0x0003EB90 File Offset: 0x0003CD90
		' (set) Token: 0x06007F99 RID: 32665 RVA: 0x0003EB9A File Offset: 0x0003CD9A
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17002EDD RID: 11997
		' (get) Token: 0x06007F9A RID: 32666 RVA: 0x0003EBA3 File Offset: 0x0003CDA3
		' (set) Token: 0x06007F9B RID: 32667 RVA: 0x0003EBAD File Offset: 0x0003CDAD
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17002EDE RID: 11998
		' (get) Token: 0x06007F9C RID: 32668 RVA: 0x0003EBB6 File Offset: 0x0003CDB6
		' (set) Token: 0x06007F9D RID: 32669 RVA: 0x0003EBC0 File Offset: 0x0003CDC0
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17002EDF RID: 11999
		' (get) Token: 0x06007F9E RID: 32670 RVA: 0x0003EBC9 File Offset: 0x0003CDC9
		' (set) Token: 0x06007F9F RID: 32671 RVA: 0x0003EBD3 File Offset: 0x0003CDD3
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17002EE0 RID: 12000
		' (get) Token: 0x06007FA0 RID: 32672 RVA: 0x0003EBDC File Offset: 0x0003CDDC
		' (set) Token: 0x06007FA1 RID: 32673 RVA: 0x0003EBE6 File Offset: 0x0003CDE6
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17002EE1 RID: 12001
		' (get) Token: 0x06007FA2 RID: 32674 RVA: 0x0003EBEF File Offset: 0x0003CDEF
		' (set) Token: 0x06007FA3 RID: 32675 RVA: 0x0003EBF9 File Offset: 0x0003CDF9
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17002EE2 RID: 12002
		' (get) Token: 0x06007FA4 RID: 32676 RVA: 0x0003EC02 File Offset: 0x0003CE02
		' (set) Token: 0x06007FA5 RID: 32677 RVA: 0x0003EC0C File Offset: 0x0003CE0C
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17002EE3 RID: 12003
		' (get) Token: 0x06007FA6 RID: 32678 RVA: 0x0003EC15 File Offset: 0x0003CE15
		' (set) Token: 0x06007FA7 RID: 32679 RVA: 0x0003EC1F File Offset: 0x0003CE1F
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17002EE4 RID: 12004
		' (get) Token: 0x06007FA8 RID: 32680 RVA: 0x0003EC28 File Offset: 0x0003CE28
		' (set) Token: 0x06007FA9 RID: 32681 RVA: 0x0003EC32 File Offset: 0x0003CE32
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17002EE5 RID: 12005
		' (get) Token: 0x06007FAA RID: 32682 RVA: 0x0003EC3B File Offset: 0x0003CE3B
		' (set) Token: 0x06007FAB RID: 32683 RVA: 0x0003EC45 File Offset: 0x0003CE45
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17002EE6 RID: 12006
		' (get) Token: 0x06007FAC RID: 32684 RVA: 0x0003EC4E File Offset: 0x0003CE4E
		' (set) Token: 0x06007FAD RID: 32685 RVA: 0x0003EC58 File Offset: 0x0003CE58
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17002EE7 RID: 12007
		' (get) Token: 0x06007FAE RID: 32686 RVA: 0x0003EC61 File Offset: 0x0003CE61
		' (set) Token: 0x06007FAF RID: 32687 RVA: 0x0003EC6B File Offset: 0x0003CE6B
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17002EE8 RID: 12008
		' (get) Token: 0x06007FB0 RID: 32688 RVA: 0x0003EC74 File Offset: 0x0003CE74
		' (set) Token: 0x06007FB1 RID: 32689 RVA: 0x0003EC7E File Offset: 0x0003CE7E
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17002EE9 RID: 12009
		' (get) Token: 0x06007FB2 RID: 32690 RVA: 0x0003EC87 File Offset: 0x0003CE87
		' (set) Token: 0x06007FB3 RID: 32691 RVA: 0x0003EC91 File Offset: 0x0003CE91
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17002EEA RID: 12010
		' (get) Token: 0x06007FB4 RID: 32692 RVA: 0x0003EC9A File Offset: 0x0003CE9A
		' (set) Token: 0x06007FB5 RID: 32693 RVA: 0x0003ECA4 File Offset: 0x0003CEA4
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17002EEB RID: 12011
		' (get) Token: 0x06007FB6 RID: 32694 RVA: 0x0003ECAD File Offset: 0x0003CEAD
		' (set) Token: 0x06007FB7 RID: 32695 RVA: 0x0003ECB7 File Offset: 0x0003CEB7
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17002EEC RID: 12012
		' (get) Token: 0x06007FB8 RID: 32696 RVA: 0x0003ECC0 File Offset: 0x0003CEC0
		' (set) Token: 0x06007FB9 RID: 32697 RVA: 0x0003ECCA File Offset: 0x0003CECA
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17002EED RID: 12013
		' (get) Token: 0x06007FBA RID: 32698 RVA: 0x0003ECD3 File Offset: 0x0003CED3
		' (set) Token: 0x06007FBB RID: 32699 RVA: 0x0003ECDD File Offset: 0x0003CEDD
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x17002EEE RID: 12014
		' (get) Token: 0x06007FBC RID: 32700 RVA: 0x0003ECE6 File Offset: 0x0003CEE6
		' (set) Token: 0x06007FBD RID: 32701 RVA: 0x0003ECF0 File Offset: 0x0003CEF0
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x17002EEF RID: 12015
		' (get) Token: 0x06007FBE RID: 32702 RVA: 0x0003ECF9 File Offset: 0x0003CEF9
		' (set) Token: 0x06007FBF RID: 32703 RVA: 0x0003ED03 File Offset: 0x0003CF03
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17002EF0 RID: 12016
		' (get) Token: 0x06007FC0 RID: 32704 RVA: 0x0003ED0C File Offset: 0x0003CF0C
		' (set) Token: 0x06007FC1 RID: 32705 RVA: 0x0003ED16 File Offset: 0x0003CF16
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x17002EF1 RID: 12017
		' (get) Token: 0x06007FC2 RID: 32706 RVA: 0x0003ED1F File Offset: 0x0003CF1F
		' (set) Token: 0x06007FC3 RID: 32707 RVA: 0x0003ED29 File Offset: 0x0003CF29
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x17002EF2 RID: 12018
		' (get) Token: 0x06007FC4 RID: 32708 RVA: 0x0003ED32 File Offset: 0x0003CF32
		' (set) Token: 0x06007FC5 RID: 32709 RVA: 0x0003ED3C File Offset: 0x0003CF3C
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x17002EF3 RID: 12019
		' (get) Token: 0x06007FC6 RID: 32710 RVA: 0x0003ED45 File Offset: 0x0003CF45
		' (set) Token: 0x06007FC7 RID: 32711 RVA: 0x0003ED4F File Offset: 0x0003CF4F
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x17002EF4 RID: 12020
		' (get) Token: 0x06007FC8 RID: 32712 RVA: 0x0003ED58 File Offset: 0x0003CF58
		' (set) Token: 0x06007FC9 RID: 32713 RVA: 0x0003ED62 File Offset: 0x0003CF62
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn
	End Class
End Namespace
