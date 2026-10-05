Imports System
Imports System.CodeDom.Compiler
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace BillPoint.Inventory_DBDataSetTableAdapters
	' Token: 0x02000472 RID: 1138
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapterManager")>
	Public Class TableAdapterManager
		Inherits Component

		' Token: 0x170058D5 RID: 22741
		' (get) Token: 0x0600E7AD RID: 59309 RVA: 0x008C6B18 File Offset: 0x008C4D18
		' (set) Token: 0x0600E7AE RID: 59310 RVA: 0x00065FB5 File Offset: 0x000641B5
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Property UpdateOrder As TableAdapterManager.UpdateOrderOption
			Get
				Return Me._updateOrder
			End Get
			Set(value As TableAdapterManager.UpdateOrderOption)
				Me._updateOrder = value
			End Set
		End Property

		' Token: 0x170058D6 RID: 22742
		' (get) Token: 0x0600E7AF RID: 59311 RVA: 0x008C6B30 File Offset: 0x008C4D30
		' (set) Token: 0x0600E7B0 RID: 59312 RVA: 0x00065FBF File Offset: 0x000641BF
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property ActivationTableAdapter As ActivationTableAdapter
			Get
				Return Me._activationTableAdapter
			End Get
			Set(value As ActivationTableAdapter)
				Me._activationTableAdapter = value
			End Set
		End Property

		' Token: 0x170058D7 RID: 22743
		' (get) Token: 0x0600E7B1 RID: 59313 RVA: 0x008C6B48 File Offset: 0x008C4D48
		' (set) Token: 0x0600E7B2 RID: 59314 RVA: 0x00065FC9 File Offset: 0x000641C9
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property BankTableAdapter As BankTableAdapter
			Get
				Return Me._bankTableAdapter
			End Get
			Set(value As BankTableAdapter)
				Me._bankTableAdapter = value
			End Set
		End Property

		' Token: 0x170058D8 RID: 22744
		' (get) Token: 0x0600E7B3 RID: 59315 RVA: 0x008C6B60 File Offset: 0x008C4D60
		' (set) Token: 0x0600E7B4 RID: 59316 RVA: 0x00065FD3 File Offset: 0x000641D3
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property BankAccountLedgerTableAdapter As BankAccountLedgerTableAdapter
			Get
				Return Me._bankAccountLedgerTableAdapter
			End Get
			Set(value As BankAccountLedgerTableAdapter)
				Me._bankAccountLedgerTableAdapter = value
			End Set
		End Property

		' Token: 0x170058D9 RID: 22745
		' (get) Token: 0x0600E7B5 RID: 59317 RVA: 0x008C6B78 File Offset: 0x008C4D78
		' (set) Token: 0x0600E7B6 RID: 59318 RVA: 0x00065FDD File Offset: 0x000641DD
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property BankAccountRegistrationTableAdapter As BankAccountRegistrationTableAdapter
			Get
				Return Me._bankAccountRegistrationTableAdapter
			End Get
			Set(value As BankAccountRegistrationTableAdapter)
				Me._bankAccountRegistrationTableAdapter = value
			End Set
		End Property

		' Token: 0x170058DA RID: 22746
		' (get) Token: 0x0600E7B7 RID: 59319 RVA: 0x008C6B90 File Offset: 0x008C4D90
		' (set) Token: 0x0600E7B8 RID: 59320 RVA: 0x00065FE7 File Offset: 0x000641E7
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property BankBranchTableAdapter As BankBranchTableAdapter
			Get
				Return Me._bankBranchTableAdapter
			End Get
			Set(value As BankBranchTableAdapter)
				Me._bankBranchTableAdapter = value
			End Set
		End Property

		' Token: 0x170058DB RID: 22747
		' (get) Token: 0x0600E7B9 RID: 59321 RVA: 0x008C6BA8 File Offset: 0x008C4DA8
		' (set) Token: 0x0600E7BA RID: 59322 RVA: 0x00065FF1 File Offset: 0x000641F1
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property CategoryTableAdapter As CategoryTableAdapter
			Get
				Return Me._categoryTableAdapter
			End Get
			Set(value As CategoryTableAdapter)
				Me._categoryTableAdapter = value
			End Set
		End Property

		' Token: 0x170058DC RID: 22748
		' (get) Token: 0x0600E7BB RID: 59323 RVA: 0x008C6BC0 File Offset: 0x008C4DC0
		' (set) Token: 0x0600E7BC RID: 59324 RVA: 0x00065FFB File Offset: 0x000641FB
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property CompanyTableAdapter As CompanyTableAdapter
			Get
				Return Me._companyTableAdapter
			End Get
			Set(value As CompanyTableAdapter)
				Me._companyTableAdapter = value
			End Set
		End Property

		' Token: 0x170058DD RID: 22749
		' (get) Token: 0x0600E7BD RID: 59325 RVA: 0x008C6BD8 File Offset: 0x008C4DD8
		' (set) Token: 0x0600E7BE RID: 59326 RVA: 0x00066005 File Offset: 0x00064205
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Company_ContactsTableAdapter As Company_ContactsTableAdapter
			Get
				Return Me._company_ContactsTableAdapter
			End Get
			Set(value As Company_ContactsTableAdapter)
				Me._company_ContactsTableAdapter = value
			End Set
		End Property

		' Token: 0x170058DE RID: 22750
		' (get) Token: 0x0600E7BF RID: 59327 RVA: 0x008C6BF0 File Offset: 0x008C4DF0
		' (set) Token: 0x0600E7C0 RID: 59328 RVA: 0x0006600F File Offset: 0x0006420F
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property CreditCustomerPaymentTableAdapter As CreditCustomerPaymentTableAdapter
			Get
				Return Me._creditCustomerPaymentTableAdapter
			End Get
			Set(value As CreditCustomerPaymentTableAdapter)
				Me._creditCustomerPaymentTableAdapter = value
			End Set
		End Property

		' Token: 0x170058DF RID: 22751
		' (get) Token: 0x0600E7C1 RID: 59329 RVA: 0x008C6C08 File Offset: 0x008C4E08
		' (set) Token: 0x0600E7C2 RID: 59330 RVA: 0x00066019 File Offset: 0x00064219
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property CustomerTableAdapter As CustomerTableAdapter
			Get
				Return Me._customerTableAdapter
			End Get
			Set(value As CustomerTableAdapter)
				Me._customerTableAdapter = value
			End Set
		End Property

		' Token: 0x170058E0 RID: 22752
		' (get) Token: 0x0600E7C3 RID: 59331 RVA: 0x008C6C20 File Offset: 0x008C4E20
		' (set) Token: 0x0600E7C4 RID: 59332 RVA: 0x00066023 File Offset: 0x00064223
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property CustomerLedgerBookTableAdapter As CustomerLedgerBookTableAdapter
			Get
				Return Me._customerLedgerBookTableAdapter
			End Get
			Set(value As CustomerLedgerBookTableAdapter)
				Me._customerLedgerBookTableAdapter = value
			End Set
		End Property

		' Token: 0x170058E1 RID: 22753
		' (get) Token: 0x0600E7C5 RID: 59333 RVA: 0x008C6C38 File Offset: 0x008C4E38
		' (set) Token: 0x0600E7C6 RID: 59334 RVA: 0x0006602D File Offset: 0x0006422D
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property EmailSettingTableAdapter As EmailSettingTableAdapter
			Get
				Return Me._emailSettingTableAdapter
			End Get
			Set(value As EmailSettingTableAdapter)
				Me._emailSettingTableAdapter = value
			End Set
		End Property

		' Token: 0x170058E2 RID: 22754
		' (get) Token: 0x0600E7C7 RID: 59335 RVA: 0x008C6C50 File Offset: 0x008C4E50
		' (set) Token: 0x0600E7C8 RID: 59336 RVA: 0x00066037 File Offset: 0x00064237
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property FundDepositTableAdapter As FundDepositTableAdapter
			Get
				Return Me._fundDepositTableAdapter
			End Get
			Set(value As FundDepositTableAdapter)
				Me._fundDepositTableAdapter = value
			End Set
		End Property

		' Token: 0x170058E3 RID: 22755
		' (get) Token: 0x0600E7C9 RID: 59337 RVA: 0x008C6C68 File Offset: 0x008C4E68
		' (set) Token: 0x0600E7CA RID: 59338 RVA: 0x00066041 File Offset: 0x00064241
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property FundTransferTableAdapter As FundTransferTableAdapter
			Get
				Return Me._fundTransferTableAdapter
			End Get
			Set(value As FundTransferTableAdapter)
				Me._fundTransferTableAdapter = value
			End Set
		End Property

		' Token: 0x170058E4 RID: 22756
		' (get) Token: 0x0600E7CB RID: 59339 RVA: 0x008C6C80 File Offset: 0x008C4E80
		' (set) Token: 0x0600E7CC RID: 59340 RVA: 0x0006604B File Offset: 0x0006424B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Invoice_PaymentTableAdapter As Invoice_PaymentTableAdapter
			Get
				Return Me._invoice_PaymentTableAdapter
			End Get
			Set(value As Invoice_PaymentTableAdapter)
				Me._invoice_PaymentTableAdapter = value
			End Set
		End Property

		' Token: 0x170058E5 RID: 22757
		' (get) Token: 0x0600E7CD RID: 59341 RVA: 0x008C6C98 File Offset: 0x008C4E98
		' (set) Token: 0x0600E7CE RID: 59342 RVA: 0x00066055 File Offset: 0x00064255
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Invoice_ProductTableAdapter As Invoice_ProductTableAdapter
			Get
				Return Me._invoice_ProductTableAdapter
			End Get
			Set(value As Invoice_ProductTableAdapter)
				Me._invoice_ProductTableAdapter = value
			End Set
		End Property

		' Token: 0x170058E6 RID: 22758
		' (get) Token: 0x0600E7CF RID: 59343 RVA: 0x008C6CB0 File Offset: 0x008C4EB0
		' (set) Token: 0x0600E7D0 RID: 59344 RVA: 0x0006605F File Offset: 0x0006425F
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property InvoiceInfoTableAdapter As InvoiceInfoTableAdapter
			Get
				Return Me._invoiceInfoTableAdapter
			End Get
			Set(value As InvoiceInfoTableAdapter)
				Me._invoiceInfoTableAdapter = value
			End Set
		End Property

		' Token: 0x170058E7 RID: 22759
		' (get) Token: 0x0600E7D1 RID: 59345 RVA: 0x008C6CC8 File Offset: 0x008C4EC8
		' (set) Token: 0x0600E7D2 RID: 59346 RVA: 0x00066069 File Offset: 0x00064269
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property InvoiceInfo1TableAdapter As InvoiceInfo1TableAdapter
			Get
				Return Me._invoiceInfo1TableAdapter
			End Get
			Set(value As InvoiceInfo1TableAdapter)
				Me._invoiceInfo1TableAdapter = value
			End Set
		End Property

		' Token: 0x170058E8 RID: 22760
		' (get) Token: 0x0600E7D3 RID: 59347 RVA: 0x008C6CE0 File Offset: 0x008C4EE0
		' (set) Token: 0x0600E7D4 RID: 59348 RVA: 0x00066073 File Offset: 0x00064273
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property LedgerBookTableAdapter As LedgerBookTableAdapter
			Get
				Return Me._ledgerBookTableAdapter
			End Get
			Set(value As LedgerBookTableAdapter)
				Me._ledgerBookTableAdapter = value
			End Set
		End Property

		' Token: 0x170058E9 RID: 22761
		' (get) Token: 0x0600E7D5 RID: 59349 RVA: 0x008C6CF8 File Offset: 0x008C4EF8
		' (set) Token: 0x0600E7D6 RID: 59350 RVA: 0x0006607D File Offset: 0x0006427D
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property LogsTableAdapter As LogsTableAdapter
			Get
				Return Me._logsTableAdapter
			End Get
			Set(value As LogsTableAdapter)
				Me._logsTableAdapter = value
			End Set
		End Property

		' Token: 0x170058EA RID: 22762
		' (get) Token: 0x0600E7D7 RID: 59351 RVA: 0x008C6D10 File Offset: 0x008C4F10
		' (set) Token: 0x0600E7D8 RID: 59352 RVA: 0x00066087 File Offset: 0x00064287
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property PaymentTableAdapter As PaymentTableAdapter
			Get
				Return Me._paymentTableAdapter
			End Get
			Set(value As PaymentTableAdapter)
				Me._paymentTableAdapter = value
			End Set
		End Property

		' Token: 0x170058EB RID: 22763
		' (get) Token: 0x0600E7D9 RID: 59353 RVA: 0x008C6D28 File Offset: 0x008C4F28
		' (set) Token: 0x0600E7DA RID: 59354 RVA: 0x00066091 File Offset: 0x00064291
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Payment_WithdrawTableAdapter As Payment_WithdrawTableAdapter
			Get
				Return Me._payment_WithdrawTableAdapter
			End Get
			Set(value As Payment_WithdrawTableAdapter)
				Me._payment_WithdrawTableAdapter = value
			End Set
		End Property

		' Token: 0x170058EC RID: 22764
		' (get) Token: 0x0600E7DB RID: 59355 RVA: 0x008C6D40 File Offset: 0x008C4F40
		' (set) Token: 0x0600E7DC RID: 59356 RVA: 0x0006609B File Offset: 0x0006429B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property ProductTableAdapter As ProductTableAdapter
			Get
				Return Me._productTableAdapter
			End Get
			Set(value As ProductTableAdapter)
				Me._productTableAdapter = value
			End Set
		End Property

		' Token: 0x170058ED RID: 22765
		' (get) Token: 0x0600E7DD RID: 59357 RVA: 0x008C6D58 File Offset: 0x008C4F58
		' (set) Token: 0x0600E7DE RID: 59358 RVA: 0x000660A5 File Offset: 0x000642A5
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Product_JoinTableAdapter As Product_JoinTableAdapter
			Get
				Return Me._product_JoinTableAdapter
			End Get
			Set(value As Product_JoinTableAdapter)
				Me._product_JoinTableAdapter = value
			End Set
		End Property

		' Token: 0x170058EE RID: 22766
		' (get) Token: 0x0600E7DF RID: 59359 RVA: 0x008C6D70 File Offset: 0x008C4F70
		' (set) Token: 0x0600E7E0 RID: 59360 RVA: 0x000660AF File Offset: 0x000642AF
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property PurchaseOrderTableAdapter As PurchaseOrderTableAdapter
			Get
				Return Me._purchaseOrderTableAdapter
			End Get
			Set(value As PurchaseOrderTableAdapter)
				Me._purchaseOrderTableAdapter = value
			End Set
		End Property

		' Token: 0x170058EF RID: 22767
		' (get) Token: 0x0600E7E1 RID: 59361 RVA: 0x008C6D88 File Offset: 0x008C4F88
		' (set) Token: 0x0600E7E2 RID: 59362 RVA: 0x000660B9 File Offset: 0x000642B9
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property PurchaseOrder_JoinTableAdapter As PurchaseOrder_JoinTableAdapter
			Get
				Return Me._purchaseOrder_JoinTableAdapter
			End Get
			Set(value As PurchaseOrder_JoinTableAdapter)
				Me._purchaseOrder_JoinTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F0 RID: 22768
		' (get) Token: 0x0600E7E3 RID: 59363 RVA: 0x008C6DA0 File Offset: 0x008C4FA0
		' (set) Token: 0x0600E7E4 RID: 59364 RVA: 0x000660C3 File Offset: 0x000642C3
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property PurchaseReturnTableAdapter As PurchaseReturnTableAdapter
			Get
				Return Me._purchaseReturnTableAdapter
			End Get
			Set(value As PurchaseReturnTableAdapter)
				Me._purchaseReturnTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F1 RID: 22769
		' (get) Token: 0x0600E7E5 RID: 59365 RVA: 0x008C6DB8 File Offset: 0x008C4FB8
		' (set) Token: 0x0600E7E6 RID: 59366 RVA: 0x000660CD File Offset: 0x000642CD
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property PurchaseReturn_JoinTableAdapter As PurchaseReturn_JoinTableAdapter
			Get
				Return Me._purchaseReturn_JoinTableAdapter
			End Get
			Set(value As PurchaseReturn_JoinTableAdapter)
				Me._purchaseReturn_JoinTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F2 RID: 22770
		' (get) Token: 0x0600E7E7 RID: 59367 RVA: 0x008C6DD0 File Offset: 0x008C4FD0
		' (set) Token: 0x0600E7E8 RID: 59368 RVA: 0x000660D7 File Offset: 0x000642D7
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property QuotationTableAdapter As QuotationTableAdapter
			Get
				Return Me._quotationTableAdapter
			End Get
			Set(value As QuotationTableAdapter)
				Me._quotationTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F3 RID: 22771
		' (get) Token: 0x0600E7E9 RID: 59369 RVA: 0x008C6DE8 File Offset: 0x008C4FE8
		' (set) Token: 0x0600E7EA RID: 59370 RVA: 0x000660E1 File Offset: 0x000642E1
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Quotation_JoinTableAdapter As Quotation_JoinTableAdapter
			Get
				Return Me._quotation_JoinTableAdapter
			End Get
			Set(value As Quotation_JoinTableAdapter)
				Me._quotation_JoinTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F4 RID: 22772
		' (get) Token: 0x0600E7EB RID: 59371 RVA: 0x008C6E00 File Offset: 0x008C5000
		' (set) Token: 0x0600E7EC RID: 59372 RVA: 0x000660EB File Offset: 0x000642EB
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property RegistrationTableAdapter As RegistrationTableAdapter
			Get
				Return Me._registrationTableAdapter
			End Get
			Set(value As RegistrationTableAdapter)
				Me._registrationTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F5 RID: 22773
		' (get) Token: 0x0600E7ED RID: 59373 RVA: 0x008C6E18 File Offset: 0x008C5018
		' (set) Token: 0x0600E7EE RID: 59374 RVA: 0x000660F5 File Offset: 0x000642F5
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property SalesManTableAdapter As SalesManTableAdapter
			Get
				Return Me._salesManTableAdapter
			End Get
			Set(value As SalesManTableAdapter)
				Me._salesManTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F6 RID: 22774
		' (get) Token: 0x0600E7EF RID: 59375 RVA: 0x008C6E30 File Offset: 0x008C5030
		' (set) Token: 0x0600E7F0 RID: 59376 RVA: 0x000660FF File Offset: 0x000642FF
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Salesman_CommissionTableAdapter As Salesman_CommissionTableAdapter
			Get
				Return Me._salesman_CommissionTableAdapter
			End Get
			Set(value As Salesman_CommissionTableAdapter)
				Me._salesman_CommissionTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F7 RID: 22775
		' (get) Token: 0x0600E7F1 RID: 59377 RVA: 0x008C6E48 File Offset: 0x008C5048
		' (set) Token: 0x0600E7F2 RID: 59378 RVA: 0x00066109 File Offset: 0x00064309
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property SalesReturnTableAdapter As SalesReturnTableAdapter
			Get
				Return Me._salesReturnTableAdapter
			End Get
			Set(value As SalesReturnTableAdapter)
				Me._salesReturnTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F8 RID: 22776
		' (get) Token: 0x0600E7F3 RID: 59379 RVA: 0x008C6E60 File Offset: 0x008C5060
		' (set) Token: 0x0600E7F4 RID: 59380 RVA: 0x00066113 File Offset: 0x00064313
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property SalesReturn_JoinTableAdapter As SalesReturn_JoinTableAdapter
			Get
				Return Me._salesReturn_JoinTableAdapter
			End Get
			Set(value As SalesReturn_JoinTableAdapter)
				Me._salesReturn_JoinTableAdapter = value
			End Set
		End Property

		' Token: 0x170058F9 RID: 22777
		' (get) Token: 0x0600E7F5 RID: 59381 RVA: 0x008C6E78 File Offset: 0x008C5078
		' (set) Token: 0x0600E7F6 RID: 59382 RVA: 0x0006611D File Offset: 0x0006431D
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property ServiceTableAdapter As ServiceTableAdapter
			Get
				Return Me._serviceTableAdapter
			End Get
			Set(value As ServiceTableAdapter)
				Me._serviceTableAdapter = value
			End Set
		End Property

		' Token: 0x170058FA RID: 22778
		' (get) Token: 0x0600E7F7 RID: 59383 RVA: 0x008C6E90 File Offset: 0x008C5090
		' (set) Token: 0x0600E7F8 RID: 59384 RVA: 0x00066127 File Offset: 0x00064327
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property SettingTableAdapter As SettingTableAdapter
			Get
				Return Me._settingTableAdapter
			End Get
			Set(value As SettingTableAdapter)
				Me._settingTableAdapter = value
			End Set
		End Property

		' Token: 0x170058FB RID: 22779
		' (get) Token: 0x0600E7F9 RID: 59385 RVA: 0x008C6EA8 File Offset: 0x008C50A8
		' (set) Token: 0x0600E7FA RID: 59386 RVA: 0x00066131 File Offset: 0x00064331
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property SMSTableAdapter As SMSTableAdapter
			Get
				Return Me._sMSTableAdapter
			End Get
			Set(value As SMSTableAdapter)
				Me._sMSTableAdapter = value
			End Set
		End Property

		' Token: 0x170058FC RID: 22780
		' (get) Token: 0x0600E7FB RID: 59387 RVA: 0x008C6EC0 File Offset: 0x008C50C0
		' (set) Token: 0x0600E7FC RID: 59388 RVA: 0x0006613B File Offset: 0x0006433B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property SMSSettingTableAdapter As SMSSettingTableAdapter
			Get
				Return Me._sMSSettingTableAdapter
			End Get
			Set(value As SMSSettingTableAdapter)
				Me._sMSSettingTableAdapter = value
			End Set
		End Property

		' Token: 0x170058FD RID: 22781
		' (get) Token: 0x0600E7FD RID: 59389 RVA: 0x008C6ED8 File Offset: 0x008C50D8
		' (set) Token: 0x0600E7FE RID: 59390 RVA: 0x00066145 File Offset: 0x00064345
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property StockTableAdapter As StockTableAdapter
			Get
				Return Me._stockTableAdapter
			End Get
			Set(value As StockTableAdapter)
				Me._stockTableAdapter = value
			End Set
		End Property

		' Token: 0x170058FE RID: 22782
		' (get) Token: 0x0600E7FF RID: 59391 RVA: 0x008C6EF0 File Offset: 0x008C50F0
		' (set) Token: 0x0600E800 RID: 59392 RVA: 0x0006614F File Offset: 0x0006434F
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Stock_ProductTableAdapter As Stock_ProductTableAdapter
			Get
				Return Me._stock_ProductTableAdapter
			End Get
			Set(value As Stock_ProductTableAdapter)
				Me._stock_ProductTableAdapter = value
			End Set
		End Property

		' Token: 0x170058FF RID: 22783
		' (get) Token: 0x0600E801 RID: 59393 RVA: 0x008C6F08 File Offset: 0x008C5108
		' (set) Token: 0x0600E802 RID: 59394 RVA: 0x00066159 File Offset: 0x00064359
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property StockAdjustmentTableAdapter As StockAdjustmentTableAdapter
			Get
				Return Me._stockAdjustmentTableAdapter
			End Get
			Set(value As StockAdjustmentTableAdapter)
				Me._stockAdjustmentTableAdapter = value
			End Set
		End Property

		' Token: 0x17005900 RID: 22784
		' (get) Token: 0x0600E803 RID: 59395 RVA: 0x008C6F20 File Offset: 0x008C5120
		' (set) Token: 0x0600E804 RID: 59396 RVA: 0x00066163 File Offset: 0x00064363
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property SubCategoryTableAdapter As SubCategoryTableAdapter
			Get
				Return Me._subCategoryTableAdapter
			End Get
			Set(value As SubCategoryTableAdapter)
				Me._subCategoryTableAdapter = value
			End Set
		End Property

		' Token: 0x17005901 RID: 22785
		' (get) Token: 0x0600E805 RID: 59397 RVA: 0x008C6F38 File Offset: 0x008C5138
		' (set) Token: 0x0600E806 RID: 59398 RVA: 0x0006616D File Offset: 0x0006436D
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property SupplierTableAdapter As SupplierTableAdapter
			Get
				Return Me._supplierTableAdapter
			End Get
			Set(value As SupplierTableAdapter)
				Me._supplierTableAdapter = value
			End Set
		End Property

		' Token: 0x17005902 RID: 22786
		' (get) Token: 0x0600E807 RID: 59399 RVA: 0x008C6F50 File Offset: 0x008C5150
		' (set) Token: 0x0600E808 RID: 59400 RVA: 0x00066177 File Offset: 0x00064377
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property SupplierLedgerBookTableAdapter As SupplierLedgerBookTableAdapter
			Get
				Return Me._supplierLedgerBookTableAdapter
			End Get
			Set(value As SupplierLedgerBookTableAdapter)
				Me._supplierLedgerBookTableAdapter = value
			End Set
		End Property

		' Token: 0x17005903 RID: 22787
		' (get) Token: 0x0600E809 RID: 59401 RVA: 0x008C6F68 File Offset: 0x008C5168
		' (set) Token: 0x0600E80A RID: 59402 RVA: 0x00066181 File Offset: 0x00064381
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Temp_StockTableAdapter As Temp_StockTableAdapter
			Get
				Return Me._temp_StockTableAdapter
			End Get
			Set(value As Temp_StockTableAdapter)
				Me._temp_StockTableAdapter = value
			End Set
		End Property

		' Token: 0x17005904 RID: 22788
		' (get) Token: 0x0600E80B RID: 59403 RVA: 0x008C6F80 File Offset: 0x008C5180
		' (set) Token: 0x0600E80C RID: 59404 RVA: 0x0006618B File Offset: 0x0006438B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property UnitMasterTableAdapter As UnitMasterTableAdapter
			Get
				Return Me._unitMasterTableAdapter
			End Get
			Set(value As UnitMasterTableAdapter)
				Me._unitMasterTableAdapter = value
			End Set
		End Property

		' Token: 0x17005905 RID: 22789
		' (get) Token: 0x0600E80D RID: 59405 RVA: 0x008C6F98 File Offset: 0x008C5198
		' (set) Token: 0x0600E80E RID: 59406 RVA: 0x00066195 File Offset: 0x00064395
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property VoucherTableAdapter As VoucherTableAdapter
			Get
				Return Me._voucherTableAdapter
			End Get
			Set(value As VoucherTableAdapter)
				Me._voucherTableAdapter = value
			End Set
		End Property

		' Token: 0x17005906 RID: 22790
		' (get) Token: 0x0600E80F RID: 59407 RVA: 0x008C6FB0 File Offset: 0x008C51B0
		' (set) Token: 0x0600E810 RID: 59408 RVA: 0x0006619F File Offset: 0x0006439F
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")>
		Public Property Voucher_OtherDetailsTableAdapter As Voucher_OtherDetailsTableAdapter
			Get
				Return Me._voucher_OtherDetailsTableAdapter
			End Get
			Set(value As Voucher_OtherDetailsTableAdapter)
				Me._voucher_OtherDetailsTableAdapter = value
			End Set
		End Property

		' Token: 0x17005907 RID: 22791
		' (get) Token: 0x0600E811 RID: 59409 RVA: 0x008C6FC8 File Offset: 0x008C51C8
		' (set) Token: 0x0600E812 RID: 59410 RVA: 0x000661A9 File Offset: 0x000643A9
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Property BackupDataSetBeforeUpdate As Boolean
			Get
				Return Me._backupDataSetBeforeUpdate
			End Get
			Set(value As Boolean)
				Me._backupDataSetBeforeUpdate = value
			End Set
		End Property

		' Token: 0x17005908 RID: 22792
		' (get) Token: 0x0600E813 RID: 59411 RVA: 0x008C6FE0 File Offset: 0x008C51E0
		' (set) Token: 0x0600E814 RID: 59412 RVA: 0x000661B3 File Offset: 0x000643B3
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		Public Property Connection As IDbConnection
			Get
				Dim flag As Boolean = Me._connection IsNot Nothing
				Dim dbConnection As IDbConnection
				If flag Then
					dbConnection = Me._connection
				Else
					Dim flag2 As Boolean = Me._activationTableAdapter IsNot Nothing AndAlso Me._activationTableAdapter.Connection IsNot Nothing
					If flag2 Then
						dbConnection = Me._activationTableAdapter.Connection
					Else
						Dim flag3 As Boolean = Me._bankTableAdapter IsNot Nothing AndAlso Me._bankTableAdapter.Connection IsNot Nothing
						If flag3 Then
							dbConnection = Me._bankTableAdapter.Connection
						Else
							Dim flag4 As Boolean = Me._bankAccountLedgerTableAdapter IsNot Nothing AndAlso Me._bankAccountLedgerTableAdapter.Connection IsNot Nothing
							If flag4 Then
								dbConnection = Me._bankAccountLedgerTableAdapter.Connection
							Else
								Dim flag5 As Boolean = Me._bankAccountRegistrationTableAdapter IsNot Nothing AndAlso Me._bankAccountRegistrationTableAdapter.Connection IsNot Nothing
								If flag5 Then
									dbConnection = Me._bankAccountRegistrationTableAdapter.Connection
								Else
									Dim flag6 As Boolean = Me._bankBranchTableAdapter IsNot Nothing AndAlso Me._bankBranchTableAdapter.Connection IsNot Nothing
									If flag6 Then
										dbConnection = Me._bankBranchTableAdapter.Connection
									Else
										Dim flag7 As Boolean = Me._categoryTableAdapter IsNot Nothing AndAlso Me._categoryTableAdapter.Connection IsNot Nothing
										If flag7 Then
											dbConnection = Me._categoryTableAdapter.Connection
										Else
											Dim flag8 As Boolean = Me._companyTableAdapter IsNot Nothing AndAlso Me._companyTableAdapter.Connection IsNot Nothing
											If flag8 Then
												dbConnection = Me._companyTableAdapter.Connection
											Else
												Dim flag9 As Boolean = Me._company_ContactsTableAdapter IsNot Nothing AndAlso Me._company_ContactsTableAdapter.Connection IsNot Nothing
												If flag9 Then
													dbConnection = Me._company_ContactsTableAdapter.Connection
												Else
													Dim flag10 As Boolean = Me._creditCustomerPaymentTableAdapter IsNot Nothing AndAlso Me._creditCustomerPaymentTableAdapter.Connection IsNot Nothing
													If flag10 Then
														dbConnection = Me._creditCustomerPaymentTableAdapter.Connection
													Else
														Dim flag11 As Boolean = Me._customerTableAdapter IsNot Nothing AndAlso Me._customerTableAdapter.Connection IsNot Nothing
														If flag11 Then
															dbConnection = Me._customerTableAdapter.Connection
														Else
															Dim flag12 As Boolean = Me._customerLedgerBookTableAdapter IsNot Nothing AndAlso Me._customerLedgerBookTableAdapter.Connection IsNot Nothing
															If flag12 Then
																dbConnection = Me._customerLedgerBookTableAdapter.Connection
															Else
																Dim flag13 As Boolean = Me._emailSettingTableAdapter IsNot Nothing AndAlso Me._emailSettingTableAdapter.Connection IsNot Nothing
																If flag13 Then
																	dbConnection = Me._emailSettingTableAdapter.Connection
																Else
																	Dim flag14 As Boolean = Me._fundDepositTableAdapter IsNot Nothing AndAlso Me._fundDepositTableAdapter.Connection IsNot Nothing
																	If flag14 Then
																		dbConnection = Me._fundDepositTableAdapter.Connection
																	Else
																		Dim flag15 As Boolean = Me._fundTransferTableAdapter IsNot Nothing AndAlso Me._fundTransferTableAdapter.Connection IsNot Nothing
																		If flag15 Then
																			dbConnection = Me._fundTransferTableAdapter.Connection
																		Else
																			Dim flag16 As Boolean = Me._invoice_PaymentTableAdapter IsNot Nothing AndAlso Me._invoice_PaymentTableAdapter.Connection IsNot Nothing
																			If flag16 Then
																				dbConnection = Me._invoice_PaymentTableAdapter.Connection
																			Else
																				Dim flag17 As Boolean = Me._invoice_ProductTableAdapter IsNot Nothing AndAlso Me._invoice_ProductTableAdapter.Connection IsNot Nothing
																				If flag17 Then
																					dbConnection = Me._invoice_ProductTableAdapter.Connection
																				Else
																					Dim flag18 As Boolean = Me._invoiceInfoTableAdapter IsNot Nothing AndAlso Me._invoiceInfoTableAdapter.Connection IsNot Nothing
																					If flag18 Then
																						dbConnection = Me._invoiceInfoTableAdapter.Connection
																					Else
																						Dim flag19 As Boolean = Me._invoiceInfo1TableAdapter IsNot Nothing AndAlso Me._invoiceInfo1TableAdapter.Connection IsNot Nothing
																						If flag19 Then
																							dbConnection = Me._invoiceInfo1TableAdapter.Connection
																						Else
																							Dim flag20 As Boolean = Me._ledgerBookTableAdapter IsNot Nothing AndAlso Me._ledgerBookTableAdapter.Connection IsNot Nothing
																							If flag20 Then
																								dbConnection = Me._ledgerBookTableAdapter.Connection
																							Else
																								Dim flag21 As Boolean = Me._logsTableAdapter IsNot Nothing AndAlso Me._logsTableAdapter.Connection IsNot Nothing
																								If flag21 Then
																									dbConnection = Me._logsTableAdapter.Connection
																								Else
																									Dim flag22 As Boolean = Me._paymentTableAdapter IsNot Nothing AndAlso Me._paymentTableAdapter.Connection IsNot Nothing
																									If flag22 Then
																										dbConnection = Me._paymentTableAdapter.Connection
																									Else
																										Dim flag23 As Boolean = Me._payment_WithdrawTableAdapter IsNot Nothing AndAlso Me._payment_WithdrawTableAdapter.Connection IsNot Nothing
																										If flag23 Then
																											dbConnection = Me._payment_WithdrawTableAdapter.Connection
																										Else
																											Dim flag24 As Boolean = Me._productTableAdapter IsNot Nothing AndAlso Me._productTableAdapter.Connection IsNot Nothing
																											If flag24 Then
																												dbConnection = Me._productTableAdapter.Connection
																											Else
																												Dim flag25 As Boolean = Me._product_JoinTableAdapter IsNot Nothing AndAlso Me._product_JoinTableAdapter.Connection IsNot Nothing
																												If flag25 Then
																													dbConnection = Me._product_JoinTableAdapter.Connection
																												Else
																													Dim flag26 As Boolean = Me._purchaseOrderTableAdapter IsNot Nothing AndAlso Me._purchaseOrderTableAdapter.Connection IsNot Nothing
																													If flag26 Then
																														dbConnection = Me._purchaseOrderTableAdapter.Connection
																													Else
																														Dim flag27 As Boolean = Me._purchaseOrder_JoinTableAdapter IsNot Nothing AndAlso Me._purchaseOrder_JoinTableAdapter.Connection IsNot Nothing
																														If flag27 Then
																															dbConnection = Me._purchaseOrder_JoinTableAdapter.Connection
																														Else
																															Dim flag28 As Boolean = Me._purchaseReturnTableAdapter IsNot Nothing AndAlso Me._purchaseReturnTableAdapter.Connection IsNot Nothing
																															If flag28 Then
																																dbConnection = Me._purchaseReturnTableAdapter.Connection
																															Else
																																Dim flag29 As Boolean = Me._purchaseReturn_JoinTableAdapter IsNot Nothing AndAlso Me._purchaseReturn_JoinTableAdapter.Connection IsNot Nothing
																																If flag29 Then
																																	dbConnection = Me._purchaseReturn_JoinTableAdapter.Connection
																																Else
																																	Dim flag30 As Boolean = Me._quotationTableAdapter IsNot Nothing AndAlso Me._quotationTableAdapter.Connection IsNot Nothing
																																	If flag30 Then
																																		dbConnection = Me._quotationTableAdapter.Connection
																																	Else
																																		Dim flag31 As Boolean = Me._quotation_JoinTableAdapter IsNot Nothing AndAlso Me._quotation_JoinTableAdapter.Connection IsNot Nothing
																																		If flag31 Then
																																			dbConnection = Me._quotation_JoinTableAdapter.Connection
																																		Else
																																			Dim flag32 As Boolean = Me._registrationTableAdapter IsNot Nothing AndAlso Me._registrationTableAdapter.Connection IsNot Nothing
																																			If flag32 Then
																																				dbConnection = Me._registrationTableAdapter.Connection
																																			Else
																																				Dim flag33 As Boolean = Me._salesManTableAdapter IsNot Nothing AndAlso Me._salesManTableAdapter.Connection IsNot Nothing
																																				If flag33 Then
																																					dbConnection = Me._salesManTableAdapter.Connection
																																				Else
																																					Dim flag34 As Boolean = Me._salesman_CommissionTableAdapter IsNot Nothing AndAlso Me._salesman_CommissionTableAdapter.Connection IsNot Nothing
																																					If flag34 Then
																																						dbConnection = Me._salesman_CommissionTableAdapter.Connection
																																					Else
																																						Dim flag35 As Boolean = Me._salesReturnTableAdapter IsNot Nothing AndAlso Me._salesReturnTableAdapter.Connection IsNot Nothing
																																						If flag35 Then
																																							dbConnection = Me._salesReturnTableAdapter.Connection
																																						Else
																																							Dim flag36 As Boolean = Me._salesReturn_JoinTableAdapter IsNot Nothing AndAlso Me._salesReturn_JoinTableAdapter.Connection IsNot Nothing
																																							If flag36 Then
																																								dbConnection = Me._salesReturn_JoinTableAdapter.Connection
																																							Else
																																								Dim flag37 As Boolean = Me._serviceTableAdapter IsNot Nothing AndAlso Me._serviceTableAdapter.Connection IsNot Nothing
																																								If flag37 Then
																																									dbConnection = Me._serviceTableAdapter.Connection
																																								Else
																																									Dim flag38 As Boolean = Me._settingTableAdapter IsNot Nothing AndAlso Me._settingTableAdapter.Connection IsNot Nothing
																																									If flag38 Then
																																										dbConnection = Me._settingTableAdapter.Connection
																																									Else
																																										Dim flag39 As Boolean = Me._sMSTableAdapter IsNot Nothing AndAlso Me._sMSTableAdapter.Connection IsNot Nothing
																																										If flag39 Then
																																											dbConnection = Me._sMSTableAdapter.Connection
																																										Else
																																											Dim flag40 As Boolean = Me._sMSSettingTableAdapter IsNot Nothing AndAlso Me._sMSSettingTableAdapter.Connection IsNot Nothing
																																											If flag40 Then
																																												dbConnection = Me._sMSSettingTableAdapter.Connection
																																											Else
																																												Dim flag41 As Boolean = Me._stockTableAdapter IsNot Nothing AndAlso Me._stockTableAdapter.Connection IsNot Nothing
																																												If flag41 Then
																																													dbConnection = Me._stockTableAdapter.Connection
																																												Else
																																													Dim flag42 As Boolean = Me._stock_ProductTableAdapter IsNot Nothing AndAlso Me._stock_ProductTableAdapter.Connection IsNot Nothing
																																													If flag42 Then
																																														dbConnection = Me._stock_ProductTableAdapter.Connection
																																													Else
																																														Dim flag43 As Boolean = Me._stockAdjustmentTableAdapter IsNot Nothing AndAlso Me._stockAdjustmentTableAdapter.Connection IsNot Nothing
																																														If flag43 Then
																																															dbConnection = Me._stockAdjustmentTableAdapter.Connection
																																														Else
																																															Dim flag44 As Boolean = Me._subCategoryTableAdapter IsNot Nothing AndAlso Me._subCategoryTableAdapter.Connection IsNot Nothing
																																															If flag44 Then
																																																dbConnection = Me._subCategoryTableAdapter.Connection
																																															Else
																																																Dim flag45 As Boolean = Me._supplierTableAdapter IsNot Nothing AndAlso Me._supplierTableAdapter.Connection IsNot Nothing
																																																If flag45 Then
																																																	dbConnection = Me._supplierTableAdapter.Connection
																																																Else
																																																	Dim flag46 As Boolean = Me._supplierLedgerBookTableAdapter IsNot Nothing AndAlso Me._supplierLedgerBookTableAdapter.Connection IsNot Nothing
																																																	If flag46 Then
																																																		dbConnection = Me._supplierLedgerBookTableAdapter.Connection
																																																	Else
																																																		Dim flag47 As Boolean = Me._temp_StockTableAdapter IsNot Nothing AndAlso Me._temp_StockTableAdapter.Connection IsNot Nothing
																																																		If flag47 Then
																																																			dbConnection = Me._temp_StockTableAdapter.Connection
																																																		Else
																																																			Dim flag48 As Boolean = Me._unitMasterTableAdapter IsNot Nothing AndAlso Me._unitMasterTableAdapter.Connection IsNot Nothing
																																																			If flag48 Then
																																																				dbConnection = Me._unitMasterTableAdapter.Connection
																																																			Else
																																																				Dim flag49 As Boolean = Me._voucherTableAdapter IsNot Nothing AndAlso Me._voucherTableAdapter.Connection IsNot Nothing
																																																				If flag49 Then
																																																					dbConnection = Me._voucherTableAdapter.Connection
																																																				Else
																																																					Dim flag50 As Boolean = Me._voucher_OtherDetailsTableAdapter IsNot Nothing AndAlso Me._voucher_OtherDetailsTableAdapter.Connection IsNot Nothing
																																																					If flag50 Then
																																																						dbConnection = Me._voucher_OtherDetailsTableAdapter.Connection
																																																					Else
																																																						dbConnection = Nothing
																																																					End If
																																																				End If
																																																			End If
																																																		End If
																																																	End If
																																																End If
																																															End If
																																														End If
																																													End If
																																												End If
																																											End If
																																										End If
																																									End If
																																								End If
																																							End If
																																						End If
																																					End If
																																				End If
																																			End If
																																		End If
																																	End If
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
				Return dbConnection
			End Get
			Set(value As IDbConnection)
				Me._connection = value
			End Set
		End Property

		' Token: 0x17005909 RID: 22793
		' (get) Token: 0x0600E815 RID: 59413 RVA: 0x008C7964 File Offset: 0x008C5B64
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<Browsable(False)>
		Public ReadOnly Property TableAdapterInstanceCount As Integer
			Get
				Dim num As Integer = 0
				Dim flag As Boolean = Me._activationTableAdapter IsNot Nothing
				If flag Then
					num += 1
				End If
				Dim flag2 As Boolean = Me._bankTableAdapter IsNot Nothing
				If flag2 Then
					num += 1
				End If
				Dim flag3 As Boolean = Me._bankAccountLedgerTableAdapter IsNot Nothing
				If flag3 Then
					num += 1
				End If
				Dim flag4 As Boolean = Me._bankAccountRegistrationTableAdapter IsNot Nothing
				If flag4 Then
					num += 1
				End If
				Dim flag5 As Boolean = Me._bankBranchTableAdapter IsNot Nothing
				If flag5 Then
					num += 1
				End If
				Dim flag6 As Boolean = Me._categoryTableAdapter IsNot Nothing
				If flag6 Then
					num += 1
				End If
				Dim flag7 As Boolean = Me._companyTableAdapter IsNot Nothing
				If flag7 Then
					num += 1
				End If
				Dim flag8 As Boolean = Me._company_ContactsTableAdapter IsNot Nothing
				If flag8 Then
					num += 1
				End If
				Dim flag9 As Boolean = Me._creditCustomerPaymentTableAdapter IsNot Nothing
				If flag9 Then
					num += 1
				End If
				Dim flag10 As Boolean = Me._customerTableAdapter IsNot Nothing
				If flag10 Then
					num += 1
				End If
				Dim flag11 As Boolean = Me._customerLedgerBookTableAdapter IsNot Nothing
				If flag11 Then
					num += 1
				End If
				Dim flag12 As Boolean = Me._emailSettingTableAdapter IsNot Nothing
				If flag12 Then
					num += 1
				End If
				Dim flag13 As Boolean = Me._fundDepositTableAdapter IsNot Nothing
				If flag13 Then
					num += 1
				End If
				Dim flag14 As Boolean = Me._fundTransferTableAdapter IsNot Nothing
				If flag14 Then
					num += 1
				End If
				Dim flag15 As Boolean = Me._invoice_PaymentTableAdapter IsNot Nothing
				If flag15 Then
					num += 1
				End If
				Dim flag16 As Boolean = Me._invoice_ProductTableAdapter IsNot Nothing
				If flag16 Then
					num += 1
				End If
				Dim flag17 As Boolean = Me._invoiceInfoTableAdapter IsNot Nothing
				If flag17 Then
					num += 1
				End If
				Dim flag18 As Boolean = Me._invoiceInfo1TableAdapter IsNot Nothing
				If flag18 Then
					num += 1
				End If
				Dim flag19 As Boolean = Me._ledgerBookTableAdapter IsNot Nothing
				If flag19 Then
					num += 1
				End If
				Dim flag20 As Boolean = Me._logsTableAdapter IsNot Nothing
				If flag20 Then
					num += 1
				End If
				Dim flag21 As Boolean = Me._paymentTableAdapter IsNot Nothing
				If flag21 Then
					num += 1
				End If
				Dim flag22 As Boolean = Me._payment_WithdrawTableAdapter IsNot Nothing
				If flag22 Then
					num += 1
				End If
				Dim flag23 As Boolean = Me._productTableAdapter IsNot Nothing
				If flag23 Then
					num += 1
				End If
				Dim flag24 As Boolean = Me._product_JoinTableAdapter IsNot Nothing
				If flag24 Then
					num += 1
				End If
				Dim flag25 As Boolean = Me._purchaseOrderTableAdapter IsNot Nothing
				If flag25 Then
					num += 1
				End If
				Dim flag26 As Boolean = Me._purchaseOrder_JoinTableAdapter IsNot Nothing
				If flag26 Then
					num += 1
				End If
				Dim flag27 As Boolean = Me._purchaseReturnTableAdapter IsNot Nothing
				If flag27 Then
					num += 1
				End If
				Dim flag28 As Boolean = Me._purchaseReturn_JoinTableAdapter IsNot Nothing
				If flag28 Then
					num += 1
				End If
				Dim flag29 As Boolean = Me._quotationTableAdapter IsNot Nothing
				If flag29 Then
					num += 1
				End If
				Dim flag30 As Boolean = Me._quotation_JoinTableAdapter IsNot Nothing
				If flag30 Then
					num += 1
				End If
				Dim flag31 As Boolean = Me._registrationTableAdapter IsNot Nothing
				If flag31 Then
					num += 1
				End If
				Dim flag32 As Boolean = Me._salesManTableAdapter IsNot Nothing
				If flag32 Then
					num += 1
				End If
				Dim flag33 As Boolean = Me._salesman_CommissionTableAdapter IsNot Nothing
				If flag33 Then
					num += 1
				End If
				Dim flag34 As Boolean = Me._salesReturnTableAdapter IsNot Nothing
				If flag34 Then
					num += 1
				End If
				Dim flag35 As Boolean = Me._salesReturn_JoinTableAdapter IsNot Nothing
				If flag35 Then
					num += 1
				End If
				Dim flag36 As Boolean = Me._serviceTableAdapter IsNot Nothing
				If flag36 Then
					num += 1
				End If
				Dim flag37 As Boolean = Me._settingTableAdapter IsNot Nothing
				If flag37 Then
					num += 1
				End If
				Dim flag38 As Boolean = Me._sMSTableAdapter IsNot Nothing
				If flag38 Then
					num += 1
				End If
				Dim flag39 As Boolean = Me._sMSSettingTableAdapter IsNot Nothing
				If flag39 Then
					num += 1
				End If
				Dim flag40 As Boolean = Me._stockTableAdapter IsNot Nothing
				If flag40 Then
					num += 1
				End If
				Dim flag41 As Boolean = Me._stock_ProductTableAdapter IsNot Nothing
				If flag41 Then
					num += 1
				End If
				Dim flag42 As Boolean = Me._stockAdjustmentTableAdapter IsNot Nothing
				If flag42 Then
					num += 1
				End If
				Dim flag43 As Boolean = Me._subCategoryTableAdapter IsNot Nothing
				If flag43 Then
					num += 1
				End If
				Dim flag44 As Boolean = Me._supplierTableAdapter IsNot Nothing
				If flag44 Then
					num += 1
				End If
				Dim flag45 As Boolean = Me._supplierLedgerBookTableAdapter IsNot Nothing
				If flag45 Then
					num += 1
				End If
				Dim flag46 As Boolean = Me._temp_StockTableAdapter IsNot Nothing
				If flag46 Then
					num += 1
				End If
				Dim flag47 As Boolean = Me._unitMasterTableAdapter IsNot Nothing
				If flag47 Then
					num += 1
				End If
				Dim flag48 As Boolean = Me._voucherTableAdapter IsNot Nothing
				If flag48 Then
					num += 1
				End If
				Dim flag49 As Boolean = Me._voucher_OtherDetailsTableAdapter IsNot Nothing
				If flag49 Then
					num += 1
				End If
				Return num
			End Get
		End Property

		' Token: 0x0600E816 RID: 59414 RVA: 0x008C7D7C File Offset: 0x008C5F7C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function UpdateUpdatedRows(dataSet As Inventory_DBDataSet, allChangedRows As List(Of DataRow), allAddedRows As List(Of DataRow)) As Integer
			Dim num As Integer = 0
			Dim flag As Boolean = Me._bankTableAdapter IsNot Nothing
			If flag Then
				Dim array As DataRow() = dataSet.Bank.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array = Me.GetRealUpdatedRows(array, allAddedRows)
				Dim flag2 As Boolean = array IsNot Nothing AndAlso 0 < array.Length
				If flag2 Then
					num += Me._bankTableAdapter.Update(array)
					allChangedRows.AddRange(array)
				End If
			End If
			Dim flag3 As Boolean = Me._categoryTableAdapter IsNot Nothing
			If flag3 Then
				Dim array2 As DataRow() = dataSet.Category.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array2 = Me.GetRealUpdatedRows(array2, allAddedRows)
				Dim flag4 As Boolean = array2 IsNot Nothing AndAlso 0 < array2.Length
				If flag4 Then
					num += Me._categoryTableAdapter.Update(array2)
					allChangedRows.AddRange(array2)
				End If
			End If
			Dim flag5 As Boolean = Me._supplierTableAdapter IsNot Nothing
			If flag5 Then
				Dim array3 As DataRow() = dataSet.Supplier.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array3 = Me.GetRealUpdatedRows(array3, allAddedRows)
				Dim flag6 As Boolean = array3 IsNot Nothing AndAlso 0 < array3.Length
				If flag6 Then
					num += Me._supplierTableAdapter.Update(array3)
					allChangedRows.AddRange(array3)
				End If
			End If
			Dim flag7 As Boolean = Me._customerTableAdapter IsNot Nothing
			If flag7 Then
				Dim array4 As DataRow() = dataSet.Customer.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array4 = Me.GetRealUpdatedRows(array4, allAddedRows)
				Dim flag8 As Boolean = array4 IsNot Nothing AndAlso 0 < array4.Length
				If flag8 Then
					num += Me._customerTableAdapter.Update(array4)
					allChangedRows.AddRange(array4)
				End If
			End If
			Dim flag9 As Boolean = Me._bankBranchTableAdapter IsNot Nothing
			If flag9 Then
				Dim array5 As DataRow() = dataSet.BankBranch.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array5 = Me.GetRealUpdatedRows(array5, allAddedRows)
				Dim flag10 As Boolean = array5 IsNot Nothing AndAlso 0 < array5.Length
				If flag10 Then
					num += Me._bankBranchTableAdapter.Update(array5)
					allChangedRows.AddRange(array5)
				End If
			End If
			Dim flag11 As Boolean = Me._subCategoryTableAdapter IsNot Nothing
			If flag11 Then
				Dim array6 As DataRow() = dataSet.SubCategory.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array6 = Me.GetRealUpdatedRows(array6, allAddedRows)
				Dim flag12 As Boolean = array6 IsNot Nothing AndAlso 0 < array6.Length
				If flag12 Then
					num += Me._subCategoryTableAdapter.Update(array6)
					allChangedRows.AddRange(array6)
				End If
			End If
			Dim flag13 As Boolean = Me._stockTableAdapter IsNot Nothing
			If flag13 Then
				Dim array7 As DataRow() = dataSet.Stock.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array7 = Me.GetRealUpdatedRows(array7, allAddedRows)
				Dim flag14 As Boolean = array7 IsNot Nothing AndAlso 0 < array7.Length
				If flag14 Then
					num += Me._stockTableAdapter.Update(array7)
					allChangedRows.AddRange(array7)
				End If
			End If
			Dim flag15 As Boolean = Me._invoiceInfoTableAdapter IsNot Nothing
			If flag15 Then
				Dim array8 As DataRow() = dataSet.InvoiceInfo.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array8 = Me.GetRealUpdatedRows(array8, allAddedRows)
				Dim flag16 As Boolean = array8 IsNot Nothing AndAlso 0 < array8.Length
				If flag16 Then
					num += Me._invoiceInfoTableAdapter.Update(array8)
					allChangedRows.AddRange(array8)
				End If
			End If
			Dim flag17 As Boolean = Me._purchaseOrderTableAdapter IsNot Nothing
			If flag17 Then
				Dim array9 As DataRow() = dataSet.PurchaseOrder.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array9 = Me.GetRealUpdatedRows(array9, allAddedRows)
				Dim flag18 As Boolean = array9 IsNot Nothing AndAlso 0 < array9.Length
				If flag18 Then
					num += Me._purchaseOrderTableAdapter.Update(array9)
					allChangedRows.AddRange(array9)
				End If
			End If
			Dim flag19 As Boolean = Me._purchaseReturnTableAdapter IsNot Nothing
			If flag19 Then
				Dim array10 As DataRow() = dataSet.PurchaseReturn.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array10 = Me.GetRealUpdatedRows(array10, allAddedRows)
				Dim flag20 As Boolean = array10 IsNot Nothing AndAlso 0 < array10.Length
				If flag20 Then
					num += Me._purchaseReturnTableAdapter.Update(array10)
					allChangedRows.AddRange(array10)
				End If
			End If
			Dim flag21 As Boolean = Me._registrationTableAdapter IsNot Nothing
			If flag21 Then
				Dim array11 As DataRow() = dataSet.Registration.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array11 = Me.GetRealUpdatedRows(array11, allAddedRows)
				Dim flag22 As Boolean = array11 IsNot Nothing AndAlso 0 < array11.Length
				If flag22 Then
					num += Me._registrationTableAdapter.Update(array11)
					allChangedRows.AddRange(array11)
				End If
			End If
			Dim flag23 As Boolean = Me._voucherTableAdapter IsNot Nothing
			If flag23 Then
				Dim array12 As DataRow() = dataSet.Voucher.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array12 = Me.GetRealUpdatedRows(array12, allAddedRows)
				Dim flag24 As Boolean = array12 IsNot Nothing AndAlso 0 < array12.Length
				If flag24 Then
					num += Me._voucherTableAdapter.Update(array12)
					allChangedRows.AddRange(array12)
				End If
			End If
			Dim flag25 As Boolean = Me._productTableAdapter IsNot Nothing
			If flag25 Then
				Dim array13 As DataRow() = dataSet.Product.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array13 = Me.GetRealUpdatedRows(array13, allAddedRows)
				Dim flag26 As Boolean = array13 IsNot Nothing AndAlso 0 < array13.Length
				If flag26 Then
					num += Me._productTableAdapter.Update(array13)
					allChangedRows.AddRange(array13)
				End If
			End If
			Dim flag27 As Boolean = Me._salesReturnTableAdapter IsNot Nothing
			If flag27 Then
				Dim array14 As DataRow() = dataSet.SalesReturn.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array14 = Me.GetRealUpdatedRows(array14, allAddedRows)
				Dim flag28 As Boolean = array14 IsNot Nothing AndAlso 0 < array14.Length
				If flag28 Then
					num += Me._salesReturnTableAdapter.Update(array14)
					allChangedRows.AddRange(array14)
				End If
			End If
			Dim flag29 As Boolean = Me._serviceTableAdapter IsNot Nothing
			If flag29 Then
				Dim array15 As DataRow() = dataSet.Service.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array15 = Me.GetRealUpdatedRows(array15, allAddedRows)
				Dim flag30 As Boolean = array15 IsNot Nothing AndAlso 0 < array15.Length
				If flag30 Then
					num += Me._serviceTableAdapter.Update(array15)
					allChangedRows.AddRange(array15)
				End If
			End If
			Dim flag31 As Boolean = Me._quotationTableAdapter IsNot Nothing
			If flag31 Then
				Dim array16 As DataRow() = dataSet.Quotation.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array16 = Me.GetRealUpdatedRows(array16, allAddedRows)
				Dim flag32 As Boolean = array16 IsNot Nothing AndAlso 0 < array16.Length
				If flag32 Then
					num += Me._quotationTableAdapter.Update(array16)
					allChangedRows.AddRange(array16)
				End If
			End If
			Dim flag33 As Boolean = Me._bankAccountRegistrationTableAdapter IsNot Nothing
			If flag33 Then
				Dim array17 As DataRow() = dataSet.BankAccountRegistration.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array17 = Me.GetRealUpdatedRows(array17, allAddedRows)
				Dim flag34 As Boolean = array17 IsNot Nothing AndAlso 0 < array17.Length
				If flag34 Then
					num += Me._bankAccountRegistrationTableAdapter.Update(array17)
					allChangedRows.AddRange(array17)
				End If
			End If
			Dim flag35 As Boolean = Me._quotation_JoinTableAdapter IsNot Nothing
			If flag35 Then
				Dim array18 As DataRow() = dataSet.Quotation_Join.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array18 = Me.GetRealUpdatedRows(array18, allAddedRows)
				Dim flag36 As Boolean = array18 IsNot Nothing AndAlso 0 < array18.Length
				If flag36 Then
					num += Me._quotation_JoinTableAdapter.Update(array18)
					allChangedRows.AddRange(array18)
				End If
			End If
			Dim flag37 As Boolean = Me._settingTableAdapter IsNot Nothing
			If flag37 Then
				Dim array19 As DataRow() = dataSet.Setting.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array19 = Me.GetRealUpdatedRows(array19, allAddedRows)
				Dim flag38 As Boolean = array19 IsNot Nothing AndAlso 0 < array19.Length
				If flag38 Then
					num += Me._settingTableAdapter.Update(array19)
					allChangedRows.AddRange(array19)
				End If
			End If
			Dim flag39 As Boolean = Me._stock_ProductTableAdapter IsNot Nothing
			If flag39 Then
				Dim array20 As DataRow() = dataSet.Stock_Product.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array20 = Me.GetRealUpdatedRows(array20, allAddedRows)
				Dim flag40 As Boolean = array20 IsNot Nothing AndAlso 0 < array20.Length
				If flag40 Then
					num += Me._stock_ProductTableAdapter.Update(array20)
					allChangedRows.AddRange(array20)
				End If
			End If
			Dim flag41 As Boolean = Me._salesReturn_JoinTableAdapter IsNot Nothing
			If flag41 Then
				Dim array21 As DataRow() = dataSet.SalesReturn_Join.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array21 = Me.GetRealUpdatedRows(array21, allAddedRows)
				Dim flag42 As Boolean = array21 IsNot Nothing AndAlso 0 < array21.Length
				If flag42 Then
					num += Me._salesReturn_JoinTableAdapter.Update(array21)
					allChangedRows.AddRange(array21)
				End If
			End If
			Dim flag43 As Boolean = Me._stockAdjustmentTableAdapter IsNot Nothing
			If flag43 Then
				Dim array22 As DataRow() = dataSet.StockAdjustment.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array22 = Me.GetRealUpdatedRows(array22, allAddedRows)
				Dim flag44 As Boolean = array22 IsNot Nothing AndAlso 0 < array22.Length
				If flag44 Then
					num += Me._stockAdjustmentTableAdapter.Update(array22)
					allChangedRows.AddRange(array22)
				End If
			End If
			Dim flag45 As Boolean = Me._salesman_CommissionTableAdapter IsNot Nothing
			If flag45 Then
				Dim array23 As DataRow() = dataSet.Salesman_Commission.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array23 = Me.GetRealUpdatedRows(array23, allAddedRows)
				Dim flag46 As Boolean = array23 IsNot Nothing AndAlso 0 < array23.Length
				If flag46 Then
					num += Me._salesman_CommissionTableAdapter.Update(array23)
					allChangedRows.AddRange(array23)
				End If
			End If
			Dim flag47 As Boolean = Me._supplierLedgerBookTableAdapter IsNot Nothing
			If flag47 Then
				Dim array24 As DataRow() = dataSet.SupplierLedgerBook.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array24 = Me.GetRealUpdatedRows(array24, allAddedRows)
				Dim flag48 As Boolean = array24 IsNot Nothing AndAlso 0 < array24.Length
				If flag48 Then
					num += Me._supplierLedgerBookTableAdapter.Update(array24)
					allChangedRows.AddRange(array24)
				End If
			End If
			Dim flag49 As Boolean = Me._salesManTableAdapter IsNot Nothing
			If flag49 Then
				Dim array25 As DataRow() = dataSet.SalesMan.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array25 = Me.GetRealUpdatedRows(array25, allAddedRows)
				Dim flag50 As Boolean = array25 IsNot Nothing AndAlso 0 < array25.Length
				If flag50 Then
					num += Me._salesManTableAdapter.Update(array25)
					allChangedRows.AddRange(array25)
				End If
			End If
			Dim flag51 As Boolean = Me._temp_StockTableAdapter IsNot Nothing
			If flag51 Then
				Dim array26 As DataRow() = dataSet.Temp_Stock.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array26 = Me.GetRealUpdatedRows(array26, allAddedRows)
				Dim flag52 As Boolean = array26 IsNot Nothing AndAlso 0 < array26.Length
				If flag52 Then
					num += Me._temp_StockTableAdapter.Update(array26)
					allChangedRows.AddRange(array26)
				End If
			End If
			Dim flag53 As Boolean = Me._unitMasterTableAdapter IsNot Nothing
			If flag53 Then
				Dim array27 As DataRow() = dataSet.UnitMaster.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array27 = Me.GetRealUpdatedRows(array27, allAddedRows)
				Dim flag54 As Boolean = array27 IsNot Nothing AndAlso 0 < array27.Length
				If flag54 Then
					num += Me._unitMasterTableAdapter.Update(array27)
					allChangedRows.AddRange(array27)
				End If
			End If
			Dim flag55 As Boolean = Me._sMSTableAdapter IsNot Nothing
			If flag55 Then
				Dim array28 As DataRow() = dataSet.SMS.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array28 = Me.GetRealUpdatedRows(array28, allAddedRows)
				Dim flag56 As Boolean = array28 IsNot Nothing AndAlso 0 < array28.Length
				If flag56 Then
					num += Me._sMSTableAdapter.Update(array28)
					allChangedRows.AddRange(array28)
				End If
			End If
			Dim flag57 As Boolean = Me._sMSSettingTableAdapter IsNot Nothing
			If flag57 Then
				Dim array29 As DataRow() = dataSet.SMSSetting.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array29 = Me.GetRealUpdatedRows(array29, allAddedRows)
				Dim flag58 As Boolean = array29 IsNot Nothing AndAlso 0 < array29.Length
				If flag58 Then
					num += Me._sMSSettingTableAdapter.Update(array29)
					allChangedRows.AddRange(array29)
				End If
			End If
			Dim flag59 As Boolean = Me._activationTableAdapter IsNot Nothing
			If flag59 Then
				Dim array30 As DataRow() = dataSet.Activation.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array30 = Me.GetRealUpdatedRows(array30, allAddedRows)
				Dim flag60 As Boolean = array30 IsNot Nothing AndAlso 0 < array30.Length
				If flag60 Then
					num += Me._activationTableAdapter.Update(array30)
					allChangedRows.AddRange(array30)
				End If
			End If
			Dim flag61 As Boolean = Me._purchaseOrder_JoinTableAdapter IsNot Nothing
			If flag61 Then
				Dim array31 As DataRow() = dataSet.PurchaseOrder_Join.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array31 = Me.GetRealUpdatedRows(array31, allAddedRows)
				Dim flag62 As Boolean = array31 IsNot Nothing AndAlso 0 < array31.Length
				If flag62 Then
					num += Me._purchaseOrder_JoinTableAdapter.Update(array31)
					allChangedRows.AddRange(array31)
				End If
			End If
			Dim flag63 As Boolean = Me._bankAccountLedgerTableAdapter IsNot Nothing
			If flag63 Then
				Dim array32 As DataRow() = dataSet.BankAccountLedger.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array32 = Me.GetRealUpdatedRows(array32, allAddedRows)
				Dim flag64 As Boolean = array32 IsNot Nothing AndAlso 0 < array32.Length
				If flag64 Then
					num += Me._bankAccountLedgerTableAdapter.Update(array32)
					allChangedRows.AddRange(array32)
				End If
			End If
			Dim flag65 As Boolean = Me._companyTableAdapter IsNot Nothing
			If flag65 Then
				Dim array33 As DataRow() = dataSet.Company.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array33 = Me.GetRealUpdatedRows(array33, allAddedRows)
				Dim flag66 As Boolean = array33 IsNot Nothing AndAlso 0 < array33.Length
				If flag66 Then
					num += Me._companyTableAdapter.Update(array33)
					allChangedRows.AddRange(array33)
				End If
			End If
			Dim flag67 As Boolean = Me._company_ContactsTableAdapter IsNot Nothing
			If flag67 Then
				Dim array34 As DataRow() = dataSet.Company_Contacts.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array34 = Me.GetRealUpdatedRows(array34, allAddedRows)
				Dim flag68 As Boolean = array34 IsNot Nothing AndAlso 0 < array34.Length
				If flag68 Then
					num += Me._company_ContactsTableAdapter.Update(array34)
					allChangedRows.AddRange(array34)
				End If
			End If
			Dim flag69 As Boolean = Me._creditCustomerPaymentTableAdapter IsNot Nothing
			If flag69 Then
				Dim array35 As DataRow() = dataSet.CreditCustomerPayment.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array35 = Me.GetRealUpdatedRows(array35, allAddedRows)
				Dim flag70 As Boolean = array35 IsNot Nothing AndAlso 0 < array35.Length
				If flag70 Then
					num += Me._creditCustomerPaymentTableAdapter.Update(array35)
					allChangedRows.AddRange(array35)
				End If
			End If
			Dim flag71 As Boolean = Me._customerLedgerBookTableAdapter IsNot Nothing
			If flag71 Then
				Dim array36 As DataRow() = dataSet.CustomerLedgerBook.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array36 = Me.GetRealUpdatedRows(array36, allAddedRows)
				Dim flag72 As Boolean = array36 IsNot Nothing AndAlso 0 < array36.Length
				If flag72 Then
					num += Me._customerLedgerBookTableAdapter.Update(array36)
					allChangedRows.AddRange(array36)
				End If
			End If
			Dim flag73 As Boolean = Me._emailSettingTableAdapter IsNot Nothing
			If flag73 Then
				Dim array37 As DataRow() = dataSet.EmailSetting.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array37 = Me.GetRealUpdatedRows(array37, allAddedRows)
				Dim flag74 As Boolean = array37 IsNot Nothing AndAlso 0 < array37.Length
				If flag74 Then
					num += Me._emailSettingTableAdapter.Update(array37)
					allChangedRows.AddRange(array37)
				End If
			End If
			Dim flag75 As Boolean = Me._fundDepositTableAdapter IsNot Nothing
			If flag75 Then
				Dim array38 As DataRow() = dataSet.FundDeposit.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array38 = Me.GetRealUpdatedRows(array38, allAddedRows)
				Dim flag76 As Boolean = array38 IsNot Nothing AndAlso 0 < array38.Length
				If flag76 Then
					num += Me._fundDepositTableAdapter.Update(array38)
					allChangedRows.AddRange(array38)
				End If
			End If
			Dim flag77 As Boolean = Me._purchaseReturn_JoinTableAdapter IsNot Nothing
			If flag77 Then
				Dim array39 As DataRow() = dataSet.PurchaseReturn_Join.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array39 = Me.GetRealUpdatedRows(array39, allAddedRows)
				Dim flag78 As Boolean = array39 IsNot Nothing AndAlso 0 < array39.Length
				If flag78 Then
					num += Me._purchaseReturn_JoinTableAdapter.Update(array39)
					allChangedRows.AddRange(array39)
				End If
			End If
			Dim flag79 As Boolean = Me._fundTransferTableAdapter IsNot Nothing
			If flag79 Then
				Dim array40 As DataRow() = dataSet.FundTransfer.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array40 = Me.GetRealUpdatedRows(array40, allAddedRows)
				Dim flag80 As Boolean = array40 IsNot Nothing AndAlso 0 < array40.Length
				If flag80 Then
					num += Me._fundTransferTableAdapter.Update(array40)
					allChangedRows.AddRange(array40)
				End If
			End If
			Dim flag81 As Boolean = Me._invoice_ProductTableAdapter IsNot Nothing
			If flag81 Then
				Dim array41 As DataRow() = dataSet.Invoice_Product.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array41 = Me.GetRealUpdatedRows(array41, allAddedRows)
				Dim flag82 As Boolean = array41 IsNot Nothing AndAlso 0 < array41.Length
				If flag82 Then
					num += Me._invoice_ProductTableAdapter.Update(array41)
					allChangedRows.AddRange(array41)
				End If
			End If
			Dim flag83 As Boolean = Me._invoiceInfo1TableAdapter IsNot Nothing
			If flag83 Then
				Dim array42 As DataRow() = dataSet.InvoiceInfo1.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array42 = Me.GetRealUpdatedRows(array42, allAddedRows)
				Dim flag84 As Boolean = array42 IsNot Nothing AndAlso 0 < array42.Length
				If flag84 Then
					num += Me._invoiceInfo1TableAdapter.Update(array42)
					allChangedRows.AddRange(array42)
				End If
			End If
			Dim flag85 As Boolean = Me._ledgerBookTableAdapter IsNot Nothing
			If flag85 Then
				Dim array43 As DataRow() = dataSet.LedgerBook.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array43 = Me.GetRealUpdatedRows(array43, allAddedRows)
				Dim flag86 As Boolean = array43 IsNot Nothing AndAlso 0 < array43.Length
				If flag86 Then
					num += Me._ledgerBookTableAdapter.Update(array43)
					allChangedRows.AddRange(array43)
				End If
			End If
			Dim flag87 As Boolean = Me._logsTableAdapter IsNot Nothing
			If flag87 Then
				Dim array44 As DataRow() = dataSet.Logs.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array44 = Me.GetRealUpdatedRows(array44, allAddedRows)
				Dim flag88 As Boolean = array44 IsNot Nothing AndAlso 0 < array44.Length
				If flag88 Then
					num += Me._logsTableAdapter.Update(array44)
					allChangedRows.AddRange(array44)
				End If
			End If
			Dim flag89 As Boolean = Me._paymentTableAdapter IsNot Nothing
			If flag89 Then
				Dim array45 As DataRow() = dataSet.Payment.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array45 = Me.GetRealUpdatedRows(array45, allAddedRows)
				Dim flag90 As Boolean = array45 IsNot Nothing AndAlso 0 < array45.Length
				If flag90 Then
					num += Me._paymentTableAdapter.Update(array45)
					allChangedRows.AddRange(array45)
				End If
			End If
			Dim flag91 As Boolean = Me._payment_WithdrawTableAdapter IsNot Nothing
			If flag91 Then
				Dim array46 As DataRow() = dataSet.Payment_Withdraw.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array46 = Me.GetRealUpdatedRows(array46, allAddedRows)
				Dim flag92 As Boolean = array46 IsNot Nothing AndAlso 0 < array46.Length
				If flag92 Then
					num += Me._payment_WithdrawTableAdapter.Update(array46)
					allChangedRows.AddRange(array46)
				End If
			End If
			Dim flag93 As Boolean = Me._product_JoinTableAdapter IsNot Nothing
			If flag93 Then
				Dim array47 As DataRow() = dataSet.Product_Join.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array47 = Me.GetRealUpdatedRows(array47, allAddedRows)
				Dim flag94 As Boolean = array47 IsNot Nothing AndAlso 0 < array47.Length
				If flag94 Then
					num += Me._product_JoinTableAdapter.Update(array47)
					allChangedRows.AddRange(array47)
				End If
			End If
			Dim flag95 As Boolean = Me._invoice_PaymentTableAdapter IsNot Nothing
			If flag95 Then
				Dim array48 As DataRow() = dataSet.Invoice_Payment.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array48 = Me.GetRealUpdatedRows(array48, allAddedRows)
				Dim flag96 As Boolean = array48 IsNot Nothing AndAlso 0 < array48.Length
				If flag96 Then
					num += Me._invoice_PaymentTableAdapter.Update(array48)
					allChangedRows.AddRange(array48)
				End If
			End If
			Dim flag97 As Boolean = Me._voucher_OtherDetailsTableAdapter IsNot Nothing
			If flag97 Then
				Dim array49 As DataRow() = dataSet.Voucher_OtherDetails.[Select](Nothing, Nothing, DataViewRowState.ModifiedCurrent)
				array49 = Me.GetRealUpdatedRows(array49, allAddedRows)
				Dim flag98 As Boolean = array49 IsNot Nothing AndAlso 0 < array49.Length
				If flag98 Then
					num += Me._voucher_OtherDetailsTableAdapter.Update(array49)
					allChangedRows.AddRange(array49)
				End If
			End If
			Return num
		End Function

		' Token: 0x0600E817 RID: 59415 RVA: 0x008C8F24 File Offset: 0x008C7124
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function UpdateInsertedRows(dataSet As Inventory_DBDataSet, allAddedRows As List(Of DataRow)) As Integer
			Dim num As Integer = 0
			Dim flag As Boolean = Me._bankTableAdapter IsNot Nothing
			If flag Then
				Dim array As DataRow() = dataSet.Bank.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag2 As Boolean = array IsNot Nothing AndAlso 0 < array.Length
				If flag2 Then
					num += Me._bankTableAdapter.Update(array)
					allAddedRows.AddRange(array)
				End If
			End If
			Dim flag3 As Boolean = Me._categoryTableAdapter IsNot Nothing
			If flag3 Then
				Dim array2 As DataRow() = dataSet.Category.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag4 As Boolean = array2 IsNot Nothing AndAlso 0 < array2.Length
				If flag4 Then
					num += Me._categoryTableAdapter.Update(array2)
					allAddedRows.AddRange(array2)
				End If
			End If
			Dim flag5 As Boolean = Me._supplierTableAdapter IsNot Nothing
			If flag5 Then
				Dim array3 As DataRow() = dataSet.Supplier.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag6 As Boolean = array3 IsNot Nothing AndAlso 0 < array3.Length
				If flag6 Then
					num += Me._supplierTableAdapter.Update(array3)
					allAddedRows.AddRange(array3)
				End If
			End If
			Dim flag7 As Boolean = Me._customerTableAdapter IsNot Nothing
			If flag7 Then
				Dim array4 As DataRow() = dataSet.Customer.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag8 As Boolean = array4 IsNot Nothing AndAlso 0 < array4.Length
				If flag8 Then
					num += Me._customerTableAdapter.Update(array4)
					allAddedRows.AddRange(array4)
				End If
			End If
			Dim flag9 As Boolean = Me._bankBranchTableAdapter IsNot Nothing
			If flag9 Then
				Dim array5 As DataRow() = dataSet.BankBranch.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag10 As Boolean = array5 IsNot Nothing AndAlso 0 < array5.Length
				If flag10 Then
					num += Me._bankBranchTableAdapter.Update(array5)
					allAddedRows.AddRange(array5)
				End If
			End If
			Dim flag11 As Boolean = Me._subCategoryTableAdapter IsNot Nothing
			If flag11 Then
				Dim array6 As DataRow() = dataSet.SubCategory.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag12 As Boolean = array6 IsNot Nothing AndAlso 0 < array6.Length
				If flag12 Then
					num += Me._subCategoryTableAdapter.Update(array6)
					allAddedRows.AddRange(array6)
				End If
			End If
			Dim flag13 As Boolean = Me._stockTableAdapter IsNot Nothing
			If flag13 Then
				Dim array7 As DataRow() = dataSet.Stock.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag14 As Boolean = array7 IsNot Nothing AndAlso 0 < array7.Length
				If flag14 Then
					num += Me._stockTableAdapter.Update(array7)
					allAddedRows.AddRange(array7)
				End If
			End If
			Dim flag15 As Boolean = Me._invoiceInfoTableAdapter IsNot Nothing
			If flag15 Then
				Dim array8 As DataRow() = dataSet.InvoiceInfo.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag16 As Boolean = array8 IsNot Nothing AndAlso 0 < array8.Length
				If flag16 Then
					num += Me._invoiceInfoTableAdapter.Update(array8)
					allAddedRows.AddRange(array8)
				End If
			End If
			Dim flag17 As Boolean = Me._purchaseOrderTableAdapter IsNot Nothing
			If flag17 Then
				Dim array9 As DataRow() = dataSet.PurchaseOrder.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag18 As Boolean = array9 IsNot Nothing AndAlso 0 < array9.Length
				If flag18 Then
					num += Me._purchaseOrderTableAdapter.Update(array9)
					allAddedRows.AddRange(array9)
				End If
			End If
			Dim flag19 As Boolean = Me._purchaseReturnTableAdapter IsNot Nothing
			If flag19 Then
				Dim array10 As DataRow() = dataSet.PurchaseReturn.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag20 As Boolean = array10 IsNot Nothing AndAlso 0 < array10.Length
				If flag20 Then
					num += Me._purchaseReturnTableAdapter.Update(array10)
					allAddedRows.AddRange(array10)
				End If
			End If
			Dim flag21 As Boolean = Me._registrationTableAdapter IsNot Nothing
			If flag21 Then
				Dim array11 As DataRow() = dataSet.Registration.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag22 As Boolean = array11 IsNot Nothing AndAlso 0 < array11.Length
				If flag22 Then
					num += Me._registrationTableAdapter.Update(array11)
					allAddedRows.AddRange(array11)
				End If
			End If
			Dim flag23 As Boolean = Me._voucherTableAdapter IsNot Nothing
			If flag23 Then
				Dim array12 As DataRow() = dataSet.Voucher.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag24 As Boolean = array12 IsNot Nothing AndAlso 0 < array12.Length
				If flag24 Then
					num += Me._voucherTableAdapter.Update(array12)
					allAddedRows.AddRange(array12)
				End If
			End If
			Dim flag25 As Boolean = Me._productTableAdapter IsNot Nothing
			If flag25 Then
				Dim array13 As DataRow() = dataSet.Product.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag26 As Boolean = array13 IsNot Nothing AndAlso 0 < array13.Length
				If flag26 Then
					num += Me._productTableAdapter.Update(array13)
					allAddedRows.AddRange(array13)
				End If
			End If
			Dim flag27 As Boolean = Me._salesReturnTableAdapter IsNot Nothing
			If flag27 Then
				Dim array14 As DataRow() = dataSet.SalesReturn.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag28 As Boolean = array14 IsNot Nothing AndAlso 0 < array14.Length
				If flag28 Then
					num += Me._salesReturnTableAdapter.Update(array14)
					allAddedRows.AddRange(array14)
				End If
			End If
			Dim flag29 As Boolean = Me._serviceTableAdapter IsNot Nothing
			If flag29 Then
				Dim array15 As DataRow() = dataSet.Service.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag30 As Boolean = array15 IsNot Nothing AndAlso 0 < array15.Length
				If flag30 Then
					num += Me._serviceTableAdapter.Update(array15)
					allAddedRows.AddRange(array15)
				End If
			End If
			Dim flag31 As Boolean = Me._quotationTableAdapter IsNot Nothing
			If flag31 Then
				Dim array16 As DataRow() = dataSet.Quotation.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag32 As Boolean = array16 IsNot Nothing AndAlso 0 < array16.Length
				If flag32 Then
					num += Me._quotationTableAdapter.Update(array16)
					allAddedRows.AddRange(array16)
				End If
			End If
			Dim flag33 As Boolean = Me._bankAccountRegistrationTableAdapter IsNot Nothing
			If flag33 Then
				Dim array17 As DataRow() = dataSet.BankAccountRegistration.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag34 As Boolean = array17 IsNot Nothing AndAlso 0 < array17.Length
				If flag34 Then
					num += Me._bankAccountRegistrationTableAdapter.Update(array17)
					allAddedRows.AddRange(array17)
				End If
			End If
			Dim flag35 As Boolean = Me._quotation_JoinTableAdapter IsNot Nothing
			If flag35 Then
				Dim array18 As DataRow() = dataSet.Quotation_Join.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag36 As Boolean = array18 IsNot Nothing AndAlso 0 < array18.Length
				If flag36 Then
					num += Me._quotation_JoinTableAdapter.Update(array18)
					allAddedRows.AddRange(array18)
				End If
			End If
			Dim flag37 As Boolean = Me._settingTableAdapter IsNot Nothing
			If flag37 Then
				Dim array19 As DataRow() = dataSet.Setting.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag38 As Boolean = array19 IsNot Nothing AndAlso 0 < array19.Length
				If flag38 Then
					num += Me._settingTableAdapter.Update(array19)
					allAddedRows.AddRange(array19)
				End If
			End If
			Dim flag39 As Boolean = Me._stock_ProductTableAdapter IsNot Nothing
			If flag39 Then
				Dim array20 As DataRow() = dataSet.Stock_Product.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag40 As Boolean = array20 IsNot Nothing AndAlso 0 < array20.Length
				If flag40 Then
					num += Me._stock_ProductTableAdapter.Update(array20)
					allAddedRows.AddRange(array20)
				End If
			End If
			Dim flag41 As Boolean = Me._salesReturn_JoinTableAdapter IsNot Nothing
			If flag41 Then
				Dim array21 As DataRow() = dataSet.SalesReturn_Join.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag42 As Boolean = array21 IsNot Nothing AndAlso 0 < array21.Length
				If flag42 Then
					num += Me._salesReturn_JoinTableAdapter.Update(array21)
					allAddedRows.AddRange(array21)
				End If
			End If
			Dim flag43 As Boolean = Me._stockAdjustmentTableAdapter IsNot Nothing
			If flag43 Then
				Dim array22 As DataRow() = dataSet.StockAdjustment.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag44 As Boolean = array22 IsNot Nothing AndAlso 0 < array22.Length
				If flag44 Then
					num += Me._stockAdjustmentTableAdapter.Update(array22)
					allAddedRows.AddRange(array22)
				End If
			End If
			Dim flag45 As Boolean = Me._salesman_CommissionTableAdapter IsNot Nothing
			If flag45 Then
				Dim array23 As DataRow() = dataSet.Salesman_Commission.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag46 As Boolean = array23 IsNot Nothing AndAlso 0 < array23.Length
				If flag46 Then
					num += Me._salesman_CommissionTableAdapter.Update(array23)
					allAddedRows.AddRange(array23)
				End If
			End If
			Dim flag47 As Boolean = Me._supplierLedgerBookTableAdapter IsNot Nothing
			If flag47 Then
				Dim array24 As DataRow() = dataSet.SupplierLedgerBook.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag48 As Boolean = array24 IsNot Nothing AndAlso 0 < array24.Length
				If flag48 Then
					num += Me._supplierLedgerBookTableAdapter.Update(array24)
					allAddedRows.AddRange(array24)
				End If
			End If
			Dim flag49 As Boolean = Me._salesManTableAdapter IsNot Nothing
			If flag49 Then
				Dim array25 As DataRow() = dataSet.SalesMan.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag50 As Boolean = array25 IsNot Nothing AndAlso 0 < array25.Length
				If flag50 Then
					num += Me._salesManTableAdapter.Update(array25)
					allAddedRows.AddRange(array25)
				End If
			End If
			Dim flag51 As Boolean = Me._temp_StockTableAdapter IsNot Nothing
			If flag51 Then
				Dim array26 As DataRow() = dataSet.Temp_Stock.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag52 As Boolean = array26 IsNot Nothing AndAlso 0 < array26.Length
				If flag52 Then
					num += Me._temp_StockTableAdapter.Update(array26)
					allAddedRows.AddRange(array26)
				End If
			End If
			Dim flag53 As Boolean = Me._unitMasterTableAdapter IsNot Nothing
			If flag53 Then
				Dim array27 As DataRow() = dataSet.UnitMaster.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag54 As Boolean = array27 IsNot Nothing AndAlso 0 < array27.Length
				If flag54 Then
					num += Me._unitMasterTableAdapter.Update(array27)
					allAddedRows.AddRange(array27)
				End If
			End If
			Dim flag55 As Boolean = Me._sMSTableAdapter IsNot Nothing
			If flag55 Then
				Dim array28 As DataRow() = dataSet.SMS.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag56 As Boolean = array28 IsNot Nothing AndAlso 0 < array28.Length
				If flag56 Then
					num += Me._sMSTableAdapter.Update(array28)
					allAddedRows.AddRange(array28)
				End If
			End If
			Dim flag57 As Boolean = Me._sMSSettingTableAdapter IsNot Nothing
			If flag57 Then
				Dim array29 As DataRow() = dataSet.SMSSetting.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag58 As Boolean = array29 IsNot Nothing AndAlso 0 < array29.Length
				If flag58 Then
					num += Me._sMSSettingTableAdapter.Update(array29)
					allAddedRows.AddRange(array29)
				End If
			End If
			Dim flag59 As Boolean = Me._activationTableAdapter IsNot Nothing
			If flag59 Then
				Dim array30 As DataRow() = dataSet.Activation.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag60 As Boolean = array30 IsNot Nothing AndAlso 0 < array30.Length
				If flag60 Then
					num += Me._activationTableAdapter.Update(array30)
					allAddedRows.AddRange(array30)
				End If
			End If
			Dim flag61 As Boolean = Me._purchaseOrder_JoinTableAdapter IsNot Nothing
			If flag61 Then
				Dim array31 As DataRow() = dataSet.PurchaseOrder_Join.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag62 As Boolean = array31 IsNot Nothing AndAlso 0 < array31.Length
				If flag62 Then
					num += Me._purchaseOrder_JoinTableAdapter.Update(array31)
					allAddedRows.AddRange(array31)
				End If
			End If
			Dim flag63 As Boolean = Me._bankAccountLedgerTableAdapter IsNot Nothing
			If flag63 Then
				Dim array32 As DataRow() = dataSet.BankAccountLedger.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag64 As Boolean = array32 IsNot Nothing AndAlso 0 < array32.Length
				If flag64 Then
					num += Me._bankAccountLedgerTableAdapter.Update(array32)
					allAddedRows.AddRange(array32)
				End If
			End If
			Dim flag65 As Boolean = Me._companyTableAdapter IsNot Nothing
			If flag65 Then
				Dim array33 As DataRow() = dataSet.Company.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag66 As Boolean = array33 IsNot Nothing AndAlso 0 < array33.Length
				If flag66 Then
					num += Me._companyTableAdapter.Update(array33)
					allAddedRows.AddRange(array33)
				End If
			End If
			Dim flag67 As Boolean = Me._company_ContactsTableAdapter IsNot Nothing
			If flag67 Then
				Dim array34 As DataRow() = dataSet.Company_Contacts.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag68 As Boolean = array34 IsNot Nothing AndAlso 0 < array34.Length
				If flag68 Then
					num += Me._company_ContactsTableAdapter.Update(array34)
					allAddedRows.AddRange(array34)
				End If
			End If
			Dim flag69 As Boolean = Me._creditCustomerPaymentTableAdapter IsNot Nothing
			If flag69 Then
				Dim array35 As DataRow() = dataSet.CreditCustomerPayment.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag70 As Boolean = array35 IsNot Nothing AndAlso 0 < array35.Length
				If flag70 Then
					num += Me._creditCustomerPaymentTableAdapter.Update(array35)
					allAddedRows.AddRange(array35)
				End If
			End If
			Dim flag71 As Boolean = Me._customerLedgerBookTableAdapter IsNot Nothing
			If flag71 Then
				Dim array36 As DataRow() = dataSet.CustomerLedgerBook.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag72 As Boolean = array36 IsNot Nothing AndAlso 0 < array36.Length
				If flag72 Then
					num += Me._customerLedgerBookTableAdapter.Update(array36)
					allAddedRows.AddRange(array36)
				End If
			End If
			Dim flag73 As Boolean = Me._emailSettingTableAdapter IsNot Nothing
			If flag73 Then
				Dim array37 As DataRow() = dataSet.EmailSetting.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag74 As Boolean = array37 IsNot Nothing AndAlso 0 < array37.Length
				If flag74 Then
					num += Me._emailSettingTableAdapter.Update(array37)
					allAddedRows.AddRange(array37)
				End If
			End If
			Dim flag75 As Boolean = Me._fundDepositTableAdapter IsNot Nothing
			If flag75 Then
				Dim array38 As DataRow() = dataSet.FundDeposit.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag76 As Boolean = array38 IsNot Nothing AndAlso 0 < array38.Length
				If flag76 Then
					num += Me._fundDepositTableAdapter.Update(array38)
					allAddedRows.AddRange(array38)
				End If
			End If
			Dim flag77 As Boolean = Me._purchaseReturn_JoinTableAdapter IsNot Nothing
			If flag77 Then
				Dim array39 As DataRow() = dataSet.PurchaseReturn_Join.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag78 As Boolean = array39 IsNot Nothing AndAlso 0 < array39.Length
				If flag78 Then
					num += Me._purchaseReturn_JoinTableAdapter.Update(array39)
					allAddedRows.AddRange(array39)
				End If
			End If
			Dim flag79 As Boolean = Me._fundTransferTableAdapter IsNot Nothing
			If flag79 Then
				Dim array40 As DataRow() = dataSet.FundTransfer.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag80 As Boolean = array40 IsNot Nothing AndAlso 0 < array40.Length
				If flag80 Then
					num += Me._fundTransferTableAdapter.Update(array40)
					allAddedRows.AddRange(array40)
				End If
			End If
			Dim flag81 As Boolean = Me._invoice_ProductTableAdapter IsNot Nothing
			If flag81 Then
				Dim array41 As DataRow() = dataSet.Invoice_Product.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag82 As Boolean = array41 IsNot Nothing AndAlso 0 < array41.Length
				If flag82 Then
					num += Me._invoice_ProductTableAdapter.Update(array41)
					allAddedRows.AddRange(array41)
				End If
			End If
			Dim flag83 As Boolean = Me._invoiceInfo1TableAdapter IsNot Nothing
			If flag83 Then
				Dim array42 As DataRow() = dataSet.InvoiceInfo1.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag84 As Boolean = array42 IsNot Nothing AndAlso 0 < array42.Length
				If flag84 Then
					num += Me._invoiceInfo1TableAdapter.Update(array42)
					allAddedRows.AddRange(array42)
				End If
			End If
			Dim flag85 As Boolean = Me._ledgerBookTableAdapter IsNot Nothing
			If flag85 Then
				Dim array43 As DataRow() = dataSet.LedgerBook.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag86 As Boolean = array43 IsNot Nothing AndAlso 0 < array43.Length
				If flag86 Then
					num += Me._ledgerBookTableAdapter.Update(array43)
					allAddedRows.AddRange(array43)
				End If
			End If
			Dim flag87 As Boolean = Me._logsTableAdapter IsNot Nothing
			If flag87 Then
				Dim array44 As DataRow() = dataSet.Logs.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag88 As Boolean = array44 IsNot Nothing AndAlso 0 < array44.Length
				If flag88 Then
					num += Me._logsTableAdapter.Update(array44)
					allAddedRows.AddRange(array44)
				End If
			End If
			Dim flag89 As Boolean = Me._paymentTableAdapter IsNot Nothing
			If flag89 Then
				Dim array45 As DataRow() = dataSet.Payment.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag90 As Boolean = array45 IsNot Nothing AndAlso 0 < array45.Length
				If flag90 Then
					num += Me._paymentTableAdapter.Update(array45)
					allAddedRows.AddRange(array45)
				End If
			End If
			Dim flag91 As Boolean = Me._payment_WithdrawTableAdapter IsNot Nothing
			If flag91 Then
				Dim array46 As DataRow() = dataSet.Payment_Withdraw.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag92 As Boolean = array46 IsNot Nothing AndAlso 0 < array46.Length
				If flag92 Then
					num += Me._payment_WithdrawTableAdapter.Update(array46)
					allAddedRows.AddRange(array46)
				End If
			End If
			Dim flag93 As Boolean = Me._product_JoinTableAdapter IsNot Nothing
			If flag93 Then
				Dim array47 As DataRow() = dataSet.Product_Join.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag94 As Boolean = array47 IsNot Nothing AndAlso 0 < array47.Length
				If flag94 Then
					num += Me._product_JoinTableAdapter.Update(array47)
					allAddedRows.AddRange(array47)
				End If
			End If
			Dim flag95 As Boolean = Me._invoice_PaymentTableAdapter IsNot Nothing
			If flag95 Then
				Dim array48 As DataRow() = dataSet.Invoice_Payment.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag96 As Boolean = array48 IsNot Nothing AndAlso 0 < array48.Length
				If flag96 Then
					num += Me._invoice_PaymentTableAdapter.Update(array48)
					allAddedRows.AddRange(array48)
				End If
			End If
			Dim flag97 As Boolean = Me._voucher_OtherDetailsTableAdapter IsNot Nothing
			If flag97 Then
				Dim array49 As DataRow() = dataSet.Voucher_OtherDetails.[Select](Nothing, Nothing, DataViewRowState.Added)
				Dim flag98 As Boolean = array49 IsNot Nothing AndAlso 0 < array49.Length
				If flag98 Then
					num += Me._voucher_OtherDetailsTableAdapter.Update(array49)
					allAddedRows.AddRange(array49)
				End If
			End If
			Return num
		End Function

		' Token: 0x0600E818 RID: 59416 RVA: 0x008C9E84 File Offset: 0x008C8084
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function UpdateDeletedRows(dataSet As Inventory_DBDataSet, allChangedRows As List(Of DataRow)) As Integer
			Dim num As Integer = 0
			Dim flag As Boolean = Me._voucher_OtherDetailsTableAdapter IsNot Nothing
			If flag Then
				Dim array As DataRow() = dataSet.Voucher_OtherDetails.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag2 As Boolean = array IsNot Nothing AndAlso 0 < array.Length
				If flag2 Then
					num += Me._voucher_OtherDetailsTableAdapter.Update(array)
					allChangedRows.AddRange(array)
				End If
			End If
			Dim flag3 As Boolean = Me._invoice_PaymentTableAdapter IsNot Nothing
			If flag3 Then
				Dim array2 As DataRow() = dataSet.Invoice_Payment.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag4 As Boolean = array2 IsNot Nothing AndAlso 0 < array2.Length
				If flag4 Then
					num += Me._invoice_PaymentTableAdapter.Update(array2)
					allChangedRows.AddRange(array2)
				End If
			End If
			Dim flag5 As Boolean = Me._product_JoinTableAdapter IsNot Nothing
			If flag5 Then
				Dim array3 As DataRow() = dataSet.Product_Join.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag6 As Boolean = array3 IsNot Nothing AndAlso 0 < array3.Length
				If flag6 Then
					num += Me._product_JoinTableAdapter.Update(array3)
					allChangedRows.AddRange(array3)
				End If
			End If
			Dim flag7 As Boolean = Me._payment_WithdrawTableAdapter IsNot Nothing
			If flag7 Then
				Dim array4 As DataRow() = dataSet.Payment_Withdraw.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag8 As Boolean = array4 IsNot Nothing AndAlso 0 < array4.Length
				If flag8 Then
					num += Me._payment_WithdrawTableAdapter.Update(array4)
					allChangedRows.AddRange(array4)
				End If
			End If
			Dim flag9 As Boolean = Me._paymentTableAdapter IsNot Nothing
			If flag9 Then
				Dim array5 As DataRow() = dataSet.Payment.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag10 As Boolean = array5 IsNot Nothing AndAlso 0 < array5.Length
				If flag10 Then
					num += Me._paymentTableAdapter.Update(array5)
					allChangedRows.AddRange(array5)
				End If
			End If
			Dim flag11 As Boolean = Me._logsTableAdapter IsNot Nothing
			If flag11 Then
				Dim array6 As DataRow() = dataSet.Logs.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag12 As Boolean = array6 IsNot Nothing AndAlso 0 < array6.Length
				If flag12 Then
					num += Me._logsTableAdapter.Update(array6)
					allChangedRows.AddRange(array6)
				End If
			End If
			Dim flag13 As Boolean = Me._ledgerBookTableAdapter IsNot Nothing
			If flag13 Then
				Dim array7 As DataRow() = dataSet.LedgerBook.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag14 As Boolean = array7 IsNot Nothing AndAlso 0 < array7.Length
				If flag14 Then
					num += Me._ledgerBookTableAdapter.Update(array7)
					allChangedRows.AddRange(array7)
				End If
			End If
			Dim flag15 As Boolean = Me._invoiceInfo1TableAdapter IsNot Nothing
			If flag15 Then
				Dim array8 As DataRow() = dataSet.InvoiceInfo1.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag16 As Boolean = array8 IsNot Nothing AndAlso 0 < array8.Length
				If flag16 Then
					num += Me._invoiceInfo1TableAdapter.Update(array8)
					allChangedRows.AddRange(array8)
				End If
			End If
			Dim flag17 As Boolean = Me._invoice_ProductTableAdapter IsNot Nothing
			If flag17 Then
				Dim array9 As DataRow() = dataSet.Invoice_Product.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag18 As Boolean = array9 IsNot Nothing AndAlso 0 < array9.Length
				If flag18 Then
					num += Me._invoice_ProductTableAdapter.Update(array9)
					allChangedRows.AddRange(array9)
				End If
			End If
			Dim flag19 As Boolean = Me._fundTransferTableAdapter IsNot Nothing
			If flag19 Then
				Dim array10 As DataRow() = dataSet.FundTransfer.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag20 As Boolean = array10 IsNot Nothing AndAlso 0 < array10.Length
				If flag20 Then
					num += Me._fundTransferTableAdapter.Update(array10)
					allChangedRows.AddRange(array10)
				End If
			End If
			Dim flag21 As Boolean = Me._purchaseReturn_JoinTableAdapter IsNot Nothing
			If flag21 Then
				Dim array11 As DataRow() = dataSet.PurchaseReturn_Join.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag22 As Boolean = array11 IsNot Nothing AndAlso 0 < array11.Length
				If flag22 Then
					num += Me._purchaseReturn_JoinTableAdapter.Update(array11)
					allChangedRows.AddRange(array11)
				End If
			End If
			Dim flag23 As Boolean = Me._fundDepositTableAdapter IsNot Nothing
			If flag23 Then
				Dim array12 As DataRow() = dataSet.FundDeposit.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag24 As Boolean = array12 IsNot Nothing AndAlso 0 < array12.Length
				If flag24 Then
					num += Me._fundDepositTableAdapter.Update(array12)
					allChangedRows.AddRange(array12)
				End If
			End If
			Dim flag25 As Boolean = Me._emailSettingTableAdapter IsNot Nothing
			If flag25 Then
				Dim array13 As DataRow() = dataSet.EmailSetting.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag26 As Boolean = array13 IsNot Nothing AndAlso 0 < array13.Length
				If flag26 Then
					num += Me._emailSettingTableAdapter.Update(array13)
					allChangedRows.AddRange(array13)
				End If
			End If
			Dim flag27 As Boolean = Me._customerLedgerBookTableAdapter IsNot Nothing
			If flag27 Then
				Dim array14 As DataRow() = dataSet.CustomerLedgerBook.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag28 As Boolean = array14 IsNot Nothing AndAlso 0 < array14.Length
				If flag28 Then
					num += Me._customerLedgerBookTableAdapter.Update(array14)
					allChangedRows.AddRange(array14)
				End If
			End If
			Dim flag29 As Boolean = Me._creditCustomerPaymentTableAdapter IsNot Nothing
			If flag29 Then
				Dim array15 As DataRow() = dataSet.CreditCustomerPayment.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag30 As Boolean = array15 IsNot Nothing AndAlso 0 < array15.Length
				If flag30 Then
					num += Me._creditCustomerPaymentTableAdapter.Update(array15)
					allChangedRows.AddRange(array15)
				End If
			End If
			Dim flag31 As Boolean = Me._company_ContactsTableAdapter IsNot Nothing
			If flag31 Then
				Dim array16 As DataRow() = dataSet.Company_Contacts.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag32 As Boolean = array16 IsNot Nothing AndAlso 0 < array16.Length
				If flag32 Then
					num += Me._company_ContactsTableAdapter.Update(array16)
					allChangedRows.AddRange(array16)
				End If
			End If
			Dim flag33 As Boolean = Me._companyTableAdapter IsNot Nothing
			If flag33 Then
				Dim array17 As DataRow() = dataSet.Company.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag34 As Boolean = array17 IsNot Nothing AndAlso 0 < array17.Length
				If flag34 Then
					num += Me._companyTableAdapter.Update(array17)
					allChangedRows.AddRange(array17)
				End If
			End If
			Dim flag35 As Boolean = Me._bankAccountLedgerTableAdapter IsNot Nothing
			If flag35 Then
				Dim array18 As DataRow() = dataSet.BankAccountLedger.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag36 As Boolean = array18 IsNot Nothing AndAlso 0 < array18.Length
				If flag36 Then
					num += Me._bankAccountLedgerTableAdapter.Update(array18)
					allChangedRows.AddRange(array18)
				End If
			End If
			Dim flag37 As Boolean = Me._purchaseOrder_JoinTableAdapter IsNot Nothing
			If flag37 Then
				Dim array19 As DataRow() = dataSet.PurchaseOrder_Join.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag38 As Boolean = array19 IsNot Nothing AndAlso 0 < array19.Length
				If flag38 Then
					num += Me._purchaseOrder_JoinTableAdapter.Update(array19)
					allChangedRows.AddRange(array19)
				End If
			End If
			Dim flag39 As Boolean = Me._activationTableAdapter IsNot Nothing
			If flag39 Then
				Dim array20 As DataRow() = dataSet.Activation.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag40 As Boolean = array20 IsNot Nothing AndAlso 0 < array20.Length
				If flag40 Then
					num += Me._activationTableAdapter.Update(array20)
					allChangedRows.AddRange(array20)
				End If
			End If
			Dim flag41 As Boolean = Me._sMSSettingTableAdapter IsNot Nothing
			If flag41 Then
				Dim array21 As DataRow() = dataSet.SMSSetting.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag42 As Boolean = array21 IsNot Nothing AndAlso 0 < array21.Length
				If flag42 Then
					num += Me._sMSSettingTableAdapter.Update(array21)
					allChangedRows.AddRange(array21)
				End If
			End If
			Dim flag43 As Boolean = Me._sMSTableAdapter IsNot Nothing
			If flag43 Then
				Dim array22 As DataRow() = dataSet.SMS.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag44 As Boolean = array22 IsNot Nothing AndAlso 0 < array22.Length
				If flag44 Then
					num += Me._sMSTableAdapter.Update(array22)
					allChangedRows.AddRange(array22)
				End If
			End If
			Dim flag45 As Boolean = Me._unitMasterTableAdapter IsNot Nothing
			If flag45 Then
				Dim array23 As DataRow() = dataSet.UnitMaster.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag46 As Boolean = array23 IsNot Nothing AndAlso 0 < array23.Length
				If flag46 Then
					num += Me._unitMasterTableAdapter.Update(array23)
					allChangedRows.AddRange(array23)
				End If
			End If
			Dim flag47 As Boolean = Me._temp_StockTableAdapter IsNot Nothing
			If flag47 Then
				Dim array24 As DataRow() = dataSet.Temp_Stock.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag48 As Boolean = array24 IsNot Nothing AndAlso 0 < array24.Length
				If flag48 Then
					num += Me._temp_StockTableAdapter.Update(array24)
					allChangedRows.AddRange(array24)
				End If
			End If
			Dim flag49 As Boolean = Me._salesManTableAdapter IsNot Nothing
			If flag49 Then
				Dim array25 As DataRow() = dataSet.SalesMan.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag50 As Boolean = array25 IsNot Nothing AndAlso 0 < array25.Length
				If flag50 Then
					num += Me._salesManTableAdapter.Update(array25)
					allChangedRows.AddRange(array25)
				End If
			End If
			Dim flag51 As Boolean = Me._supplierLedgerBookTableAdapter IsNot Nothing
			If flag51 Then
				Dim array26 As DataRow() = dataSet.SupplierLedgerBook.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag52 As Boolean = array26 IsNot Nothing AndAlso 0 < array26.Length
				If flag52 Then
					num += Me._supplierLedgerBookTableAdapter.Update(array26)
					allChangedRows.AddRange(array26)
				End If
			End If
			Dim flag53 As Boolean = Me._salesman_CommissionTableAdapter IsNot Nothing
			If flag53 Then
				Dim array27 As DataRow() = dataSet.Salesman_Commission.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag54 As Boolean = array27 IsNot Nothing AndAlso 0 < array27.Length
				If flag54 Then
					num += Me._salesman_CommissionTableAdapter.Update(array27)
					allChangedRows.AddRange(array27)
				End If
			End If
			Dim flag55 As Boolean = Me._stockAdjustmentTableAdapter IsNot Nothing
			If flag55 Then
				Dim array28 As DataRow() = dataSet.StockAdjustment.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag56 As Boolean = array28 IsNot Nothing AndAlso 0 < array28.Length
				If flag56 Then
					num += Me._stockAdjustmentTableAdapter.Update(array28)
					allChangedRows.AddRange(array28)
				End If
			End If
			Dim flag57 As Boolean = Me._salesReturn_JoinTableAdapter IsNot Nothing
			If flag57 Then
				Dim array29 As DataRow() = dataSet.SalesReturn_Join.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag58 As Boolean = array29 IsNot Nothing AndAlso 0 < array29.Length
				If flag58 Then
					num += Me._salesReturn_JoinTableAdapter.Update(array29)
					allChangedRows.AddRange(array29)
				End If
			End If
			Dim flag59 As Boolean = Me._stock_ProductTableAdapter IsNot Nothing
			If flag59 Then
				Dim array30 As DataRow() = dataSet.Stock_Product.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag60 As Boolean = array30 IsNot Nothing AndAlso 0 < array30.Length
				If flag60 Then
					num += Me._stock_ProductTableAdapter.Update(array30)
					allChangedRows.AddRange(array30)
				End If
			End If
			Dim flag61 As Boolean = Me._settingTableAdapter IsNot Nothing
			If flag61 Then
				Dim array31 As DataRow() = dataSet.Setting.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag62 As Boolean = array31 IsNot Nothing AndAlso 0 < array31.Length
				If flag62 Then
					num += Me._settingTableAdapter.Update(array31)
					allChangedRows.AddRange(array31)
				End If
			End If
			Dim flag63 As Boolean = Me._quotation_JoinTableAdapter IsNot Nothing
			If flag63 Then
				Dim array32 As DataRow() = dataSet.Quotation_Join.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag64 As Boolean = array32 IsNot Nothing AndAlso 0 < array32.Length
				If flag64 Then
					num += Me._quotation_JoinTableAdapter.Update(array32)
					allChangedRows.AddRange(array32)
				End If
			End If
			Dim flag65 As Boolean = Me._bankAccountRegistrationTableAdapter IsNot Nothing
			If flag65 Then
				Dim array33 As DataRow() = dataSet.BankAccountRegistration.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag66 As Boolean = array33 IsNot Nothing AndAlso 0 < array33.Length
				If flag66 Then
					num += Me._bankAccountRegistrationTableAdapter.Update(array33)
					allChangedRows.AddRange(array33)
				End If
			End If
			Dim flag67 As Boolean = Me._quotationTableAdapter IsNot Nothing
			If flag67 Then
				Dim array34 As DataRow() = dataSet.Quotation.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag68 As Boolean = array34 IsNot Nothing AndAlso 0 < array34.Length
				If flag68 Then
					num += Me._quotationTableAdapter.Update(array34)
					allChangedRows.AddRange(array34)
				End If
			End If
			Dim flag69 As Boolean = Me._serviceTableAdapter IsNot Nothing
			If flag69 Then
				Dim array35 As DataRow() = dataSet.Service.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag70 As Boolean = array35 IsNot Nothing AndAlso 0 < array35.Length
				If flag70 Then
					num += Me._serviceTableAdapter.Update(array35)
					allChangedRows.AddRange(array35)
				End If
			End If
			Dim flag71 As Boolean = Me._salesReturnTableAdapter IsNot Nothing
			If flag71 Then
				Dim array36 As DataRow() = dataSet.SalesReturn.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag72 As Boolean = array36 IsNot Nothing AndAlso 0 < array36.Length
				If flag72 Then
					num += Me._salesReturnTableAdapter.Update(array36)
					allChangedRows.AddRange(array36)
				End If
			End If
			Dim flag73 As Boolean = Me._productTableAdapter IsNot Nothing
			If flag73 Then
				Dim array37 As DataRow() = dataSet.Product.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag74 As Boolean = array37 IsNot Nothing AndAlso 0 < array37.Length
				If flag74 Then
					num += Me._productTableAdapter.Update(array37)
					allChangedRows.AddRange(array37)
				End If
			End If
			Dim flag75 As Boolean = Me._voucherTableAdapter IsNot Nothing
			If flag75 Then
				Dim array38 As DataRow() = dataSet.Voucher.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag76 As Boolean = array38 IsNot Nothing AndAlso 0 < array38.Length
				If flag76 Then
					num += Me._voucherTableAdapter.Update(array38)
					allChangedRows.AddRange(array38)
				End If
			End If
			Dim flag77 As Boolean = Me._registrationTableAdapter IsNot Nothing
			If flag77 Then
				Dim array39 As DataRow() = dataSet.Registration.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag78 As Boolean = array39 IsNot Nothing AndAlso 0 < array39.Length
				If flag78 Then
					num += Me._registrationTableAdapter.Update(array39)
					allChangedRows.AddRange(array39)
				End If
			End If
			Dim flag79 As Boolean = Me._purchaseReturnTableAdapter IsNot Nothing
			If flag79 Then
				Dim array40 As DataRow() = dataSet.PurchaseReturn.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag80 As Boolean = array40 IsNot Nothing AndAlso 0 < array40.Length
				If flag80 Then
					num += Me._purchaseReturnTableAdapter.Update(array40)
					allChangedRows.AddRange(array40)
				End If
			End If
			Dim flag81 As Boolean = Me._purchaseOrderTableAdapter IsNot Nothing
			If flag81 Then
				Dim array41 As DataRow() = dataSet.PurchaseOrder.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag82 As Boolean = array41 IsNot Nothing AndAlso 0 < array41.Length
				If flag82 Then
					num += Me._purchaseOrderTableAdapter.Update(array41)
					allChangedRows.AddRange(array41)
				End If
			End If
			Dim flag83 As Boolean = Me._invoiceInfoTableAdapter IsNot Nothing
			If flag83 Then
				Dim array42 As DataRow() = dataSet.InvoiceInfo.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag84 As Boolean = array42 IsNot Nothing AndAlso 0 < array42.Length
				If flag84 Then
					num += Me._invoiceInfoTableAdapter.Update(array42)
					allChangedRows.AddRange(array42)
				End If
			End If
			Dim flag85 As Boolean = Me._stockTableAdapter IsNot Nothing
			If flag85 Then
				Dim array43 As DataRow() = dataSet.Stock.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag86 As Boolean = array43 IsNot Nothing AndAlso 0 < array43.Length
				If flag86 Then
					num += Me._stockTableAdapter.Update(array43)
					allChangedRows.AddRange(array43)
				End If
			End If
			Dim flag87 As Boolean = Me._subCategoryTableAdapter IsNot Nothing
			If flag87 Then
				Dim array44 As DataRow() = dataSet.SubCategory.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag88 As Boolean = array44 IsNot Nothing AndAlso 0 < array44.Length
				If flag88 Then
					num += Me._subCategoryTableAdapter.Update(array44)
					allChangedRows.AddRange(array44)
				End If
			End If
			Dim flag89 As Boolean = Me._bankBranchTableAdapter IsNot Nothing
			If flag89 Then
				Dim array45 As DataRow() = dataSet.BankBranch.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag90 As Boolean = array45 IsNot Nothing AndAlso 0 < array45.Length
				If flag90 Then
					num += Me._bankBranchTableAdapter.Update(array45)
					allChangedRows.AddRange(array45)
				End If
			End If
			Dim flag91 As Boolean = Me._customerTableAdapter IsNot Nothing
			If flag91 Then
				Dim array46 As DataRow() = dataSet.Customer.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag92 As Boolean = array46 IsNot Nothing AndAlso 0 < array46.Length
				If flag92 Then
					num += Me._customerTableAdapter.Update(array46)
					allChangedRows.AddRange(array46)
				End If
			End If
			Dim flag93 As Boolean = Me._supplierTableAdapter IsNot Nothing
			If flag93 Then
				Dim array47 As DataRow() = dataSet.Supplier.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag94 As Boolean = array47 IsNot Nothing AndAlso 0 < array47.Length
				If flag94 Then
					num += Me._supplierTableAdapter.Update(array47)
					allChangedRows.AddRange(array47)
				End If
			End If
			Dim flag95 As Boolean = Me._categoryTableAdapter IsNot Nothing
			If flag95 Then
				Dim array48 As DataRow() = dataSet.Category.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag96 As Boolean = array48 IsNot Nothing AndAlso 0 < array48.Length
				If flag96 Then
					num += Me._categoryTableAdapter.Update(array48)
					allChangedRows.AddRange(array48)
				End If
			End If
			Dim flag97 As Boolean = Me._bankTableAdapter IsNot Nothing
			If flag97 Then
				Dim array49 As DataRow() = dataSet.Bank.[Select](Nothing, Nothing, DataViewRowState.Deleted)
				Dim flag98 As Boolean = array49 IsNot Nothing AndAlso 0 < array49.Length
				If flag98 Then
					num += Me._bankTableAdapter.Update(array49)
					allChangedRows.AddRange(array49)
				End If
			End If
			Return num
		End Function

		' Token: 0x0600E819 RID: 59417 RVA: 0x008CADE4 File Offset: 0x008C8FE4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Function GetRealUpdatedRows(updatedRows As DataRow(), allAddedRows As List(Of DataRow)) As DataRow()
			Dim flag As Boolean = updatedRows Is Nothing OrElse updatedRows.Length < 1
			Dim array As DataRow()
			If flag Then
				array = updatedRows
			Else
				Dim flag2 As Boolean = allAddedRows Is Nothing OrElse allAddedRows.Count < 1
				If flag2 Then
					array = updatedRows
				Else
					Dim list As List(Of DataRow) = New List(Of DataRow)()
					For Each dataRow As DataRow In updatedRows
						Dim flag3 As Boolean = Not allAddedRows.Contains(dataRow)
						If flag3 Then
							list.Add(dataRow)
						End If
					Next
					array = list.ToArray()
				End If
			End If
			Return array
		End Function

		' Token: 0x0600E81A RID: 59418 RVA: 0x008CAE68 File Offset: 0x008C9068
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Overridable Function UpdateAll(dataSet As Inventory_DBDataSet) As Integer
			Dim flag As Boolean = dataSet Is Nothing
			If flag Then
				Throw New ArgumentNullException("dataSet")
			End If
			Dim flag2 As Boolean = Not dataSet.HasChanges()
			Dim num As Integer
			If flag2 Then
				num = 0
			Else
				Dim flag3 As Boolean = Me._activationTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._activationTableAdapter.Connection)
				If flag3 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag4 As Boolean = Me._bankTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._bankTableAdapter.Connection)
				If flag4 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag5 As Boolean = Me._bankAccountLedgerTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._bankAccountLedgerTableAdapter.Connection)
				If flag5 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag6 As Boolean = Me._bankAccountRegistrationTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._bankAccountRegistrationTableAdapter.Connection)
				If flag6 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag7 As Boolean = Me._bankBranchTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._bankBranchTableAdapter.Connection)
				If flag7 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag8 As Boolean = Me._categoryTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._categoryTableAdapter.Connection)
				If flag8 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag9 As Boolean = Me._companyTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._companyTableAdapter.Connection)
				If flag9 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag10 As Boolean = Me._company_ContactsTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._company_ContactsTableAdapter.Connection)
				If flag10 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag11 As Boolean = Me._creditCustomerPaymentTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._creditCustomerPaymentTableAdapter.Connection)
				If flag11 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag12 As Boolean = Me._customerTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._customerTableAdapter.Connection)
				If flag12 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag13 As Boolean = Me._customerLedgerBookTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._customerLedgerBookTableAdapter.Connection)
				If flag13 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag14 As Boolean = Me._emailSettingTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._emailSettingTableAdapter.Connection)
				If flag14 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag15 As Boolean = Me._fundDepositTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._fundDepositTableAdapter.Connection)
				If flag15 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag16 As Boolean = Me._fundTransferTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._fundTransferTableAdapter.Connection)
				If flag16 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag17 As Boolean = Me._invoice_PaymentTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._invoice_PaymentTableAdapter.Connection)
				If flag17 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag18 As Boolean = Me._invoice_ProductTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._invoice_ProductTableAdapter.Connection)
				If flag18 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag19 As Boolean = Me._invoiceInfoTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._invoiceInfoTableAdapter.Connection)
				If flag19 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag20 As Boolean = Me._invoiceInfo1TableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._invoiceInfo1TableAdapter.Connection)
				If flag20 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag21 As Boolean = Me._ledgerBookTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._ledgerBookTableAdapter.Connection)
				If flag21 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag22 As Boolean = Me._logsTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._logsTableAdapter.Connection)
				If flag22 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag23 As Boolean = Me._paymentTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._paymentTableAdapter.Connection)
				If flag23 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag24 As Boolean = Me._payment_WithdrawTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._payment_WithdrawTableAdapter.Connection)
				If flag24 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag25 As Boolean = Me._productTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._productTableAdapter.Connection)
				If flag25 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag26 As Boolean = Me._product_JoinTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._product_JoinTableAdapter.Connection)
				If flag26 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag27 As Boolean = Me._purchaseOrderTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._purchaseOrderTableAdapter.Connection)
				If flag27 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag28 As Boolean = Me._purchaseOrder_JoinTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._purchaseOrder_JoinTableAdapter.Connection)
				If flag28 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag29 As Boolean = Me._purchaseReturnTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._purchaseReturnTableAdapter.Connection)
				If flag29 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag30 As Boolean = Me._purchaseReturn_JoinTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._purchaseReturn_JoinTableAdapter.Connection)
				If flag30 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag31 As Boolean = Me._quotationTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._quotationTableAdapter.Connection)
				If flag31 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag32 As Boolean = Me._quotation_JoinTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._quotation_JoinTableAdapter.Connection)
				If flag32 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag33 As Boolean = Me._registrationTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._registrationTableAdapter.Connection)
				If flag33 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag34 As Boolean = Me._salesManTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._salesManTableAdapter.Connection)
				If flag34 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag35 As Boolean = Me._salesman_CommissionTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._salesman_CommissionTableAdapter.Connection)
				If flag35 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag36 As Boolean = Me._salesReturnTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._salesReturnTableAdapter.Connection)
				If flag36 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag37 As Boolean = Me._salesReturn_JoinTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._salesReturn_JoinTableAdapter.Connection)
				If flag37 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag38 As Boolean = Me._serviceTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._serviceTableAdapter.Connection)
				If flag38 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag39 As Boolean = Me._settingTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._settingTableAdapter.Connection)
				If flag39 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag40 As Boolean = Me._sMSTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._sMSTableAdapter.Connection)
				If flag40 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag41 As Boolean = Me._sMSSettingTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._sMSSettingTableAdapter.Connection)
				If flag41 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag42 As Boolean = Me._stockTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._stockTableAdapter.Connection)
				If flag42 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag43 As Boolean = Me._stock_ProductTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._stock_ProductTableAdapter.Connection)
				If flag43 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag44 As Boolean = Me._stockAdjustmentTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._stockAdjustmentTableAdapter.Connection)
				If flag44 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag45 As Boolean = Me._subCategoryTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._subCategoryTableAdapter.Connection)
				If flag45 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag46 As Boolean = Me._supplierTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._supplierTableAdapter.Connection)
				If flag46 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag47 As Boolean = Me._supplierLedgerBookTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._supplierLedgerBookTableAdapter.Connection)
				If flag47 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag48 As Boolean = Me._temp_StockTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._temp_StockTableAdapter.Connection)
				If flag48 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag49 As Boolean = Me._unitMasterTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._unitMasterTableAdapter.Connection)
				If flag49 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag50 As Boolean = Me._voucherTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._voucherTableAdapter.Connection)
				If flag50 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim flag51 As Boolean = Me._voucher_OtherDetailsTableAdapter IsNot Nothing AndAlso Not Me.MatchTableAdapterConnection(Me._voucher_OtherDetailsTableAdapter.Connection)
				If flag51 Then
					Throw New ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.")
				End If
				Dim connection As IDbConnection = Me.Connection
				Dim flag52 As Boolean = connection Is Nothing
				If flag52 Then
					Throw New ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterManager TableAdapter property to a valid TableAdapter instance.")
				End If
				Dim flag53 As Boolean = False
				Dim flag54 As Boolean = (connection.State And ConnectionState.Broken) = ConnectionState.Broken
				If flag54 Then
					connection.Close()
				End If
				Dim flag55 As Boolean = connection.State = ConnectionState.Closed
				If flag55 Then
					connection.Open()
					flag53 = True
				End If
				Dim dbTransaction As IDbTransaction = connection.BeginTransaction()
				Dim flag56 As Boolean = dbTransaction Is Nothing
				If flag56 Then
					Throw New ApplicationException("The transaction cannot begin. The current data connection does not support transactions or the current state is not allowing the transaction to begin.")
				End If
				Dim list As List(Of DataRow) = New List(Of DataRow)()
				Dim list2 As List(Of DataRow) = New List(Of DataRow)()
				Dim list3 As List(Of DataAdapter) = New List(Of DataAdapter)()
				Dim dictionary As Dictionary(Of Object, IDbConnection) = New Dictionary(Of Object, IDbConnection)()
				Dim num2 As Integer = 0
				Dim dataSet2 As DataSet = Nothing
				Dim backupDataSetBeforeUpdate As Boolean = Me.BackupDataSetBeforeUpdate
				If backupDataSetBeforeUpdate Then
					dataSet2 = New DataSet()
					dataSet2.Merge(dataSet)
				End If
				Try
					Dim flag57 As Boolean = Me._activationTableAdapter IsNot Nothing
					If flag57 Then
						dictionary.Add(Me._activationTableAdapter, Me._activationTableAdapter.Connection)
						Me._activationTableAdapter.Connection = CType(connection, SqlConnection)
						Me._activationTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate As Boolean = Me._activationTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate Then
							Me._activationTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._activationTableAdapter.Adapter)
						End If
					End If
					Dim flag58 As Boolean = Me._bankTableAdapter IsNot Nothing
					If flag58 Then
						dictionary.Add(Me._bankTableAdapter, Me._bankTableAdapter.Connection)
						Me._bankTableAdapter.Connection = CType(connection, SqlConnection)
						Me._bankTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate2 As Boolean = Me._bankTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate2 Then
							Me._bankTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._bankTableAdapter.Adapter)
						End If
					End If
					Dim flag59 As Boolean = Me._bankAccountLedgerTableAdapter IsNot Nothing
					If flag59 Then
						dictionary.Add(Me._bankAccountLedgerTableAdapter, Me._bankAccountLedgerTableAdapter.Connection)
						Me._bankAccountLedgerTableAdapter.Connection = CType(connection, SqlConnection)
						Me._bankAccountLedgerTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate3 As Boolean = Me._bankAccountLedgerTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate3 Then
							Me._bankAccountLedgerTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._bankAccountLedgerTableAdapter.Adapter)
						End If
					End If
					Dim flag60 As Boolean = Me._bankAccountRegistrationTableAdapter IsNot Nothing
					If flag60 Then
						dictionary.Add(Me._bankAccountRegistrationTableAdapter, Me._bankAccountRegistrationTableAdapter.Connection)
						Me._bankAccountRegistrationTableAdapter.Connection = CType(connection, SqlConnection)
						Me._bankAccountRegistrationTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate4 As Boolean = Me._bankAccountRegistrationTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate4 Then
							Me._bankAccountRegistrationTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._bankAccountRegistrationTableAdapter.Adapter)
						End If
					End If
					Dim flag61 As Boolean = Me._bankBranchTableAdapter IsNot Nothing
					If flag61 Then
						dictionary.Add(Me._bankBranchTableAdapter, Me._bankBranchTableAdapter.Connection)
						Me._bankBranchTableAdapter.Connection = CType(connection, SqlConnection)
						Me._bankBranchTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate5 As Boolean = Me._bankBranchTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate5 Then
							Me._bankBranchTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._bankBranchTableAdapter.Adapter)
						End If
					End If
					Dim flag62 As Boolean = Me._categoryTableAdapter IsNot Nothing
					If flag62 Then
						dictionary.Add(Me._categoryTableAdapter, Me._categoryTableAdapter.Connection)
						Me._categoryTableAdapter.Connection = CType(connection, SqlConnection)
						Me._categoryTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate6 As Boolean = Me._categoryTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate6 Then
							Me._categoryTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._categoryTableAdapter.Adapter)
						End If
					End If
					Dim flag63 As Boolean = Me._companyTableAdapter IsNot Nothing
					If flag63 Then
						dictionary.Add(Me._companyTableAdapter, Me._companyTableAdapter.Connection)
						Me._companyTableAdapter.Connection = CType(connection, SqlConnection)
						Me._companyTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate7 As Boolean = Me._companyTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate7 Then
							Me._companyTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._companyTableAdapter.Adapter)
						End If
					End If
					Dim flag64 As Boolean = Me._company_ContactsTableAdapter IsNot Nothing
					If flag64 Then
						dictionary.Add(Me._company_ContactsTableAdapter, Me._company_ContactsTableAdapter.Connection)
						Me._company_ContactsTableAdapter.Connection = CType(connection, SqlConnection)
						Me._company_ContactsTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate8 As Boolean = Me._company_ContactsTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate8 Then
							Me._company_ContactsTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._company_ContactsTableAdapter.Adapter)
						End If
					End If
					Dim flag65 As Boolean = Me._creditCustomerPaymentTableAdapter IsNot Nothing
					If flag65 Then
						dictionary.Add(Me._creditCustomerPaymentTableAdapter, Me._creditCustomerPaymentTableAdapter.Connection)
						Me._creditCustomerPaymentTableAdapter.Connection = CType(connection, SqlConnection)
						Me._creditCustomerPaymentTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate9 As Boolean = Me._creditCustomerPaymentTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate9 Then
							Me._creditCustomerPaymentTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._creditCustomerPaymentTableAdapter.Adapter)
						End If
					End If
					Dim flag66 As Boolean = Me._customerTableAdapter IsNot Nothing
					If flag66 Then
						dictionary.Add(Me._customerTableAdapter, Me._customerTableAdapter.Connection)
						Me._customerTableAdapter.Connection = CType(connection, SqlConnection)
						Me._customerTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate10 As Boolean = Me._customerTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate10 Then
							Me._customerTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._customerTableAdapter.Adapter)
						End If
					End If
					Dim flag67 As Boolean = Me._customerLedgerBookTableAdapter IsNot Nothing
					If flag67 Then
						dictionary.Add(Me._customerLedgerBookTableAdapter, Me._customerLedgerBookTableAdapter.Connection)
						Me._customerLedgerBookTableAdapter.Connection = CType(connection, SqlConnection)
						Me._customerLedgerBookTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate11 As Boolean = Me._customerLedgerBookTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate11 Then
							Me._customerLedgerBookTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._customerLedgerBookTableAdapter.Adapter)
						End If
					End If
					Dim flag68 As Boolean = Me._emailSettingTableAdapter IsNot Nothing
					If flag68 Then
						dictionary.Add(Me._emailSettingTableAdapter, Me._emailSettingTableAdapter.Connection)
						Me._emailSettingTableAdapter.Connection = CType(connection, SqlConnection)
						Me._emailSettingTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate12 As Boolean = Me._emailSettingTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate12 Then
							Me._emailSettingTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._emailSettingTableAdapter.Adapter)
						End If
					End If
					Dim flag69 As Boolean = Me._fundDepositTableAdapter IsNot Nothing
					If flag69 Then
						dictionary.Add(Me._fundDepositTableAdapter, Me._fundDepositTableAdapter.Connection)
						Me._fundDepositTableAdapter.Connection = CType(connection, SqlConnection)
						Me._fundDepositTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate13 As Boolean = Me._fundDepositTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate13 Then
							Me._fundDepositTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._fundDepositTableAdapter.Adapter)
						End If
					End If
					Dim flag70 As Boolean = Me._fundTransferTableAdapter IsNot Nothing
					If flag70 Then
						dictionary.Add(Me._fundTransferTableAdapter, Me._fundTransferTableAdapter.Connection)
						Me._fundTransferTableAdapter.Connection = CType(connection, SqlConnection)
						Me._fundTransferTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate14 As Boolean = Me._fundTransferTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate14 Then
							Me._fundTransferTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._fundTransferTableAdapter.Adapter)
						End If
					End If
					Dim flag71 As Boolean = Me._invoice_PaymentTableAdapter IsNot Nothing
					If flag71 Then
						dictionary.Add(Me._invoice_PaymentTableAdapter, Me._invoice_PaymentTableAdapter.Connection)
						Me._invoice_PaymentTableAdapter.Connection = CType(connection, SqlConnection)
						Me._invoice_PaymentTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate15 As Boolean = Me._invoice_PaymentTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate15 Then
							Me._invoice_PaymentTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._invoice_PaymentTableAdapter.Adapter)
						End If
					End If
					Dim flag72 As Boolean = Me._invoice_ProductTableAdapter IsNot Nothing
					If flag72 Then
						dictionary.Add(Me._invoice_ProductTableAdapter, Me._invoice_ProductTableAdapter.Connection)
						Me._invoice_ProductTableAdapter.Connection = CType(connection, SqlConnection)
						Me._invoice_ProductTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate16 As Boolean = Me._invoice_ProductTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate16 Then
							Me._invoice_ProductTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._invoice_ProductTableAdapter.Adapter)
						End If
					End If
					Dim flag73 As Boolean = Me._invoiceInfoTableAdapter IsNot Nothing
					If flag73 Then
						dictionary.Add(Me._invoiceInfoTableAdapter, Me._invoiceInfoTableAdapter.Connection)
						Me._invoiceInfoTableAdapter.Connection = CType(connection, SqlConnection)
						Me._invoiceInfoTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate17 As Boolean = Me._invoiceInfoTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate17 Then
							Me._invoiceInfoTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._invoiceInfoTableAdapter.Adapter)
						End If
					End If
					Dim flag74 As Boolean = Me._invoiceInfo1TableAdapter IsNot Nothing
					If flag74 Then
						dictionary.Add(Me._invoiceInfo1TableAdapter, Me._invoiceInfo1TableAdapter.Connection)
						Me._invoiceInfo1TableAdapter.Connection = CType(connection, SqlConnection)
						Me._invoiceInfo1TableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate18 As Boolean = Me._invoiceInfo1TableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate18 Then
							Me._invoiceInfo1TableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._invoiceInfo1TableAdapter.Adapter)
						End If
					End If
					Dim flag75 As Boolean = Me._ledgerBookTableAdapter IsNot Nothing
					If flag75 Then
						dictionary.Add(Me._ledgerBookTableAdapter, Me._ledgerBookTableAdapter.Connection)
						Me._ledgerBookTableAdapter.Connection = CType(connection, SqlConnection)
						Me._ledgerBookTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate19 As Boolean = Me._ledgerBookTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate19 Then
							Me._ledgerBookTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._ledgerBookTableAdapter.Adapter)
						End If
					End If
					Dim flag76 As Boolean = Me._logsTableAdapter IsNot Nothing
					If flag76 Then
						dictionary.Add(Me._logsTableAdapter, Me._logsTableAdapter.Connection)
						Me._logsTableAdapter.Connection = CType(connection, SqlConnection)
						Me._logsTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate20 As Boolean = Me._logsTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate20 Then
							Me._logsTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._logsTableAdapter.Adapter)
						End If
					End If
					Dim flag77 As Boolean = Me._paymentTableAdapter IsNot Nothing
					If flag77 Then
						dictionary.Add(Me._paymentTableAdapter, Me._paymentTableAdapter.Connection)
						Me._paymentTableAdapter.Connection = CType(connection, SqlConnection)
						Me._paymentTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate21 As Boolean = Me._paymentTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate21 Then
							Me._paymentTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._paymentTableAdapter.Adapter)
						End If
					End If
					Dim flag78 As Boolean = Me._payment_WithdrawTableAdapter IsNot Nothing
					If flag78 Then
						dictionary.Add(Me._payment_WithdrawTableAdapter, Me._payment_WithdrawTableAdapter.Connection)
						Me._payment_WithdrawTableAdapter.Connection = CType(connection, SqlConnection)
						Me._payment_WithdrawTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate22 As Boolean = Me._payment_WithdrawTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate22 Then
							Me._payment_WithdrawTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._payment_WithdrawTableAdapter.Adapter)
						End If
					End If
					Dim flag79 As Boolean = Me._productTableAdapter IsNot Nothing
					If flag79 Then
						dictionary.Add(Me._productTableAdapter, Me._productTableAdapter.Connection)
						Me._productTableAdapter.Connection = CType(connection, SqlConnection)
						Me._productTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate23 As Boolean = Me._productTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate23 Then
							Me._productTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._productTableAdapter.Adapter)
						End If
					End If
					Dim flag80 As Boolean = Me._product_JoinTableAdapter IsNot Nothing
					If flag80 Then
						dictionary.Add(Me._product_JoinTableAdapter, Me._product_JoinTableAdapter.Connection)
						Me._product_JoinTableAdapter.Connection = CType(connection, SqlConnection)
						Me._product_JoinTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate24 As Boolean = Me._product_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate24 Then
							Me._product_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._product_JoinTableAdapter.Adapter)
						End If
					End If
					Dim flag81 As Boolean = Me._purchaseOrderTableAdapter IsNot Nothing
					If flag81 Then
						dictionary.Add(Me._purchaseOrderTableAdapter, Me._purchaseOrderTableAdapter.Connection)
						Me._purchaseOrderTableAdapter.Connection = CType(connection, SqlConnection)
						Me._purchaseOrderTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate25 As Boolean = Me._purchaseOrderTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate25 Then
							Me._purchaseOrderTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._purchaseOrderTableAdapter.Adapter)
						End If
					End If
					Dim flag82 As Boolean = Me._purchaseOrder_JoinTableAdapter IsNot Nothing
					If flag82 Then
						dictionary.Add(Me._purchaseOrder_JoinTableAdapter, Me._purchaseOrder_JoinTableAdapter.Connection)
						Me._purchaseOrder_JoinTableAdapter.Connection = CType(connection, SqlConnection)
						Me._purchaseOrder_JoinTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate26 As Boolean = Me._purchaseOrder_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate26 Then
							Me._purchaseOrder_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._purchaseOrder_JoinTableAdapter.Adapter)
						End If
					End If
					Dim flag83 As Boolean = Me._purchaseReturnTableAdapter IsNot Nothing
					If flag83 Then
						dictionary.Add(Me._purchaseReturnTableAdapter, Me._purchaseReturnTableAdapter.Connection)
						Me._purchaseReturnTableAdapter.Connection = CType(connection, SqlConnection)
						Me._purchaseReturnTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate27 As Boolean = Me._purchaseReturnTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate27 Then
							Me._purchaseReturnTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._purchaseReturnTableAdapter.Adapter)
						End If
					End If
					Dim flag84 As Boolean = Me._purchaseReturn_JoinTableAdapter IsNot Nothing
					If flag84 Then
						dictionary.Add(Me._purchaseReturn_JoinTableAdapter, Me._purchaseReturn_JoinTableAdapter.Connection)
						Me._purchaseReturn_JoinTableAdapter.Connection = CType(connection, SqlConnection)
						Me._purchaseReturn_JoinTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate28 As Boolean = Me._purchaseReturn_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate28 Then
							Me._purchaseReturn_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._purchaseReturn_JoinTableAdapter.Adapter)
						End If
					End If
					Dim flag85 As Boolean = Me._quotationTableAdapter IsNot Nothing
					If flag85 Then
						dictionary.Add(Me._quotationTableAdapter, Me._quotationTableAdapter.Connection)
						Me._quotationTableAdapter.Connection = CType(connection, SqlConnection)
						Me._quotationTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate29 As Boolean = Me._quotationTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate29 Then
							Me._quotationTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._quotationTableAdapter.Adapter)
						End If
					End If
					Dim flag86 As Boolean = Me._quotation_JoinTableAdapter IsNot Nothing
					If flag86 Then
						dictionary.Add(Me._quotation_JoinTableAdapter, Me._quotation_JoinTableAdapter.Connection)
						Me._quotation_JoinTableAdapter.Connection = CType(connection, SqlConnection)
						Me._quotation_JoinTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate30 As Boolean = Me._quotation_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate30 Then
							Me._quotation_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._quotation_JoinTableAdapter.Adapter)
						End If
					End If
					Dim flag87 As Boolean = Me._registrationTableAdapter IsNot Nothing
					If flag87 Then
						dictionary.Add(Me._registrationTableAdapter, Me._registrationTableAdapter.Connection)
						Me._registrationTableAdapter.Connection = CType(connection, SqlConnection)
						Me._registrationTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate31 As Boolean = Me._registrationTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate31 Then
							Me._registrationTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._registrationTableAdapter.Adapter)
						End If
					End If
					Dim flag88 As Boolean = Me._salesManTableAdapter IsNot Nothing
					If flag88 Then
						dictionary.Add(Me._salesManTableAdapter, Me._salesManTableAdapter.Connection)
						Me._salesManTableAdapter.Connection = CType(connection, SqlConnection)
						Me._salesManTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate32 As Boolean = Me._salesManTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate32 Then
							Me._salesManTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._salesManTableAdapter.Adapter)
						End If
					End If
					Dim flag89 As Boolean = Me._salesman_CommissionTableAdapter IsNot Nothing
					If flag89 Then
						dictionary.Add(Me._salesman_CommissionTableAdapter, Me._salesman_CommissionTableAdapter.Connection)
						Me._salesman_CommissionTableAdapter.Connection = CType(connection, SqlConnection)
						Me._salesman_CommissionTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate33 As Boolean = Me._salesman_CommissionTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate33 Then
							Me._salesman_CommissionTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._salesman_CommissionTableAdapter.Adapter)
						End If
					End If
					Dim flag90 As Boolean = Me._salesReturnTableAdapter IsNot Nothing
					If flag90 Then
						dictionary.Add(Me._salesReturnTableAdapter, Me._salesReturnTableAdapter.Connection)
						Me._salesReturnTableAdapter.Connection = CType(connection, SqlConnection)
						Me._salesReturnTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate34 As Boolean = Me._salesReturnTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate34 Then
							Me._salesReturnTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._salesReturnTableAdapter.Adapter)
						End If
					End If
					Dim flag91 As Boolean = Me._salesReturn_JoinTableAdapter IsNot Nothing
					If flag91 Then
						dictionary.Add(Me._salesReturn_JoinTableAdapter, Me._salesReturn_JoinTableAdapter.Connection)
						Me._salesReturn_JoinTableAdapter.Connection = CType(connection, SqlConnection)
						Me._salesReturn_JoinTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate35 As Boolean = Me._salesReturn_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate35 Then
							Me._salesReturn_JoinTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._salesReturn_JoinTableAdapter.Adapter)
						End If
					End If
					Dim flag92 As Boolean = Me._serviceTableAdapter IsNot Nothing
					If flag92 Then
						dictionary.Add(Me._serviceTableAdapter, Me._serviceTableAdapter.Connection)
						Me._serviceTableAdapter.Connection = CType(connection, SqlConnection)
						Me._serviceTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate36 As Boolean = Me._serviceTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate36 Then
							Me._serviceTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._serviceTableAdapter.Adapter)
						End If
					End If
					Dim flag93 As Boolean = Me._settingTableAdapter IsNot Nothing
					If flag93 Then
						dictionary.Add(Me._settingTableAdapter, Me._settingTableAdapter.Connection)
						Me._settingTableAdapter.Connection = CType(connection, SqlConnection)
						Me._settingTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate37 As Boolean = Me._settingTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate37 Then
							Me._settingTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._settingTableAdapter.Adapter)
						End If
					End If
					Dim flag94 As Boolean = Me._sMSTableAdapter IsNot Nothing
					If flag94 Then
						dictionary.Add(Me._sMSTableAdapter, Me._sMSTableAdapter.Connection)
						Me._sMSTableAdapter.Connection = CType(connection, SqlConnection)
						Me._sMSTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate38 As Boolean = Me._sMSTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate38 Then
							Me._sMSTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._sMSTableAdapter.Adapter)
						End If
					End If
					Dim flag95 As Boolean = Me._sMSSettingTableAdapter IsNot Nothing
					If flag95 Then
						dictionary.Add(Me._sMSSettingTableAdapter, Me._sMSSettingTableAdapter.Connection)
						Me._sMSSettingTableAdapter.Connection = CType(connection, SqlConnection)
						Me._sMSSettingTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate39 As Boolean = Me._sMSSettingTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate39 Then
							Me._sMSSettingTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._sMSSettingTableAdapter.Adapter)
						End If
					End If
					Dim flag96 As Boolean = Me._stockTableAdapter IsNot Nothing
					If flag96 Then
						dictionary.Add(Me._stockTableAdapter, Me._stockTableAdapter.Connection)
						Me._stockTableAdapter.Connection = CType(connection, SqlConnection)
						Me._stockTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate40 As Boolean = Me._stockTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate40 Then
							Me._stockTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._stockTableAdapter.Adapter)
						End If
					End If
					Dim flag97 As Boolean = Me._stock_ProductTableAdapter IsNot Nothing
					If flag97 Then
						dictionary.Add(Me._stock_ProductTableAdapter, Me._stock_ProductTableAdapter.Connection)
						Me._stock_ProductTableAdapter.Connection = CType(connection, SqlConnection)
						Me._stock_ProductTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate41 As Boolean = Me._stock_ProductTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate41 Then
							Me._stock_ProductTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._stock_ProductTableAdapter.Adapter)
						End If
					End If
					Dim flag98 As Boolean = Me._stockAdjustmentTableAdapter IsNot Nothing
					If flag98 Then
						dictionary.Add(Me._stockAdjustmentTableAdapter, Me._stockAdjustmentTableAdapter.Connection)
						Me._stockAdjustmentTableAdapter.Connection = CType(connection, SqlConnection)
						Me._stockAdjustmentTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate42 As Boolean = Me._stockAdjustmentTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate42 Then
							Me._stockAdjustmentTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._stockAdjustmentTableAdapter.Adapter)
						End If
					End If
					Dim flag99 As Boolean = Me._subCategoryTableAdapter IsNot Nothing
					If flag99 Then
						dictionary.Add(Me._subCategoryTableAdapter, Me._subCategoryTableAdapter.Connection)
						Me._subCategoryTableAdapter.Connection = CType(connection, SqlConnection)
						Me._subCategoryTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate43 As Boolean = Me._subCategoryTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate43 Then
							Me._subCategoryTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._subCategoryTableAdapter.Adapter)
						End If
					End If
					Dim flag100 As Boolean = Me._supplierTableAdapter IsNot Nothing
					If flag100 Then
						dictionary.Add(Me._supplierTableAdapter, Me._supplierTableAdapter.Connection)
						Me._supplierTableAdapter.Connection = CType(connection, SqlConnection)
						Me._supplierTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate44 As Boolean = Me._supplierTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate44 Then
							Me._supplierTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._supplierTableAdapter.Adapter)
						End If
					End If
					Dim flag101 As Boolean = Me._supplierLedgerBookTableAdapter IsNot Nothing
					If flag101 Then
						dictionary.Add(Me._supplierLedgerBookTableAdapter, Me._supplierLedgerBookTableAdapter.Connection)
						Me._supplierLedgerBookTableAdapter.Connection = CType(connection, SqlConnection)
						Me._supplierLedgerBookTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate45 As Boolean = Me._supplierLedgerBookTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate45 Then
							Me._supplierLedgerBookTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._supplierLedgerBookTableAdapter.Adapter)
						End If
					End If
					Dim flag102 As Boolean = Me._temp_StockTableAdapter IsNot Nothing
					If flag102 Then
						dictionary.Add(Me._temp_StockTableAdapter, Me._temp_StockTableAdapter.Connection)
						Me._temp_StockTableAdapter.Connection = CType(connection, SqlConnection)
						Me._temp_StockTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate46 As Boolean = Me._temp_StockTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate46 Then
							Me._temp_StockTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._temp_StockTableAdapter.Adapter)
						End If
					End If
					Dim flag103 As Boolean = Me._unitMasterTableAdapter IsNot Nothing
					If flag103 Then
						dictionary.Add(Me._unitMasterTableAdapter, Me._unitMasterTableAdapter.Connection)
						Me._unitMasterTableAdapter.Connection = CType(connection, SqlConnection)
						Me._unitMasterTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate47 As Boolean = Me._unitMasterTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate47 Then
							Me._unitMasterTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._unitMasterTableAdapter.Adapter)
						End If
					End If
					Dim flag104 As Boolean = Me._voucherTableAdapter IsNot Nothing
					If flag104 Then
						dictionary.Add(Me._voucherTableAdapter, Me._voucherTableAdapter.Connection)
						Me._voucherTableAdapter.Connection = CType(connection, SqlConnection)
						Me._voucherTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate48 As Boolean = Me._voucherTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate48 Then
							Me._voucherTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._voucherTableAdapter.Adapter)
						End If
					End If
					Dim flag105 As Boolean = Me._voucher_OtherDetailsTableAdapter IsNot Nothing
					If flag105 Then
						dictionary.Add(Me._voucher_OtherDetailsTableAdapter, Me._voucher_OtherDetailsTableAdapter.Connection)
						Me._voucher_OtherDetailsTableAdapter.Connection = CType(connection, SqlConnection)
						Me._voucher_OtherDetailsTableAdapter.Transaction = CType(dbTransaction, SqlTransaction)
						Dim acceptChangesDuringUpdate49 As Boolean = Me._voucher_OtherDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate
						If acceptChangesDuringUpdate49 Then
							Me._voucher_OtherDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate = False
							list3.Add(Me._voucher_OtherDetailsTableAdapter.Adapter)
						End If
					End If
					Dim flag106 As Boolean = Me.UpdateOrder = TableAdapterManager.UpdateOrderOption.UpdateInsertDelete
					If flag106 Then
						num2 += Me.UpdateUpdatedRows(dataSet, list, list2)
						num2 += Me.UpdateInsertedRows(dataSet, list2)
					Else
						num2 += Me.UpdateInsertedRows(dataSet, list2)
						num2 += Me.UpdateUpdatedRows(dataSet, list, list2)
					End If
					num2 += Me.UpdateDeletedRows(dataSet, list)
					dbTransaction.Commit()
					Dim flag107 As Boolean = 0 < list2.Count
					If flag107 Then
						Dim array As DataRow() = New DataRow(list2.Count - 1 + 1 - 1) {}
						list2.CopyTo(array)
						For Each dataRow As DataRow In array
							dataRow.AcceptChanges()
						Next
					End If
					Dim flag108 As Boolean = 0 < list.Count
					If flag108 Then
						Dim array2 As DataRow() = New DataRow(list.Count - 1 + 1 - 1) {}
						list.CopyTo(array2)
						For Each dataRow2 As DataRow In array2
							dataRow2.AcceptChanges()
						Next
					End If
				Catch ex As Exception
					dbTransaction.Rollback()
					Dim backupDataSetBeforeUpdate2 As Boolean = Me.BackupDataSetBeforeUpdate
					If backupDataSetBeforeUpdate2 Then
						Debug.Assert(dataSet2 IsNot Nothing)
						dataSet.Clear()
						dataSet.Merge(dataSet2)
					Else
						Dim flag109 As Boolean = 0 < list2.Count
						If flag109 Then
							Dim array3 As DataRow() = New DataRow(list2.Count - 1 + 1 - 1) {}
							list2.CopyTo(array3)
							For Each dataRow3 As DataRow In array3
								dataRow3.AcceptChanges()
								dataRow3.SetAdded()
							Next
						End If
					End If
					Throw ex
				Finally
					Dim flag110 As Boolean = flag53
					If flag110 Then
						connection.Close()
					End If
					Dim flag111 As Boolean = Me._activationTableAdapter IsNot Nothing
					If flag111 Then
						Me._activationTableAdapter.Connection = CType(dictionary(Me._activationTableAdapter), SqlConnection)
						Me._activationTableAdapter.Transaction = Nothing
					End If
					Dim flag112 As Boolean = Me._bankTableAdapter IsNot Nothing
					If flag112 Then
						Me._bankTableAdapter.Connection = CType(dictionary(Me._bankTableAdapter), SqlConnection)
						Me._bankTableAdapter.Transaction = Nothing
					End If
					Dim flag113 As Boolean = Me._bankAccountLedgerTableAdapter IsNot Nothing
					If flag113 Then
						Me._bankAccountLedgerTableAdapter.Connection = CType(dictionary(Me._bankAccountLedgerTableAdapter), SqlConnection)
						Me._bankAccountLedgerTableAdapter.Transaction = Nothing
					End If
					Dim flag114 As Boolean = Me._bankAccountRegistrationTableAdapter IsNot Nothing
					If flag114 Then
						Me._bankAccountRegistrationTableAdapter.Connection = CType(dictionary(Me._bankAccountRegistrationTableAdapter), SqlConnection)
						Me._bankAccountRegistrationTableAdapter.Transaction = Nothing
					End If
					Dim flag115 As Boolean = Me._bankBranchTableAdapter IsNot Nothing
					If flag115 Then
						Me._bankBranchTableAdapter.Connection = CType(dictionary(Me._bankBranchTableAdapter), SqlConnection)
						Me._bankBranchTableAdapter.Transaction = Nothing
					End If
					Dim flag116 As Boolean = Me._categoryTableAdapter IsNot Nothing
					If flag116 Then
						Me._categoryTableAdapter.Connection = CType(dictionary(Me._categoryTableAdapter), SqlConnection)
						Me._categoryTableAdapter.Transaction = Nothing
					End If
					Dim flag117 As Boolean = Me._companyTableAdapter IsNot Nothing
					If flag117 Then
						Me._companyTableAdapter.Connection = CType(dictionary(Me._companyTableAdapter), SqlConnection)
						Me._companyTableAdapter.Transaction = Nothing
					End If
					Dim flag118 As Boolean = Me._company_ContactsTableAdapter IsNot Nothing
					If flag118 Then
						Me._company_ContactsTableAdapter.Connection = CType(dictionary(Me._company_ContactsTableAdapter), SqlConnection)
						Me._company_ContactsTableAdapter.Transaction = Nothing
					End If
					Dim flag119 As Boolean = Me._creditCustomerPaymentTableAdapter IsNot Nothing
					If flag119 Then
						Me._creditCustomerPaymentTableAdapter.Connection = CType(dictionary(Me._creditCustomerPaymentTableAdapter), SqlConnection)
						Me._creditCustomerPaymentTableAdapter.Transaction = Nothing
					End If
					Dim flag120 As Boolean = Me._customerTableAdapter IsNot Nothing
					If flag120 Then
						Me._customerTableAdapter.Connection = CType(dictionary(Me._customerTableAdapter), SqlConnection)
						Me._customerTableAdapter.Transaction = Nothing
					End If
					Dim flag121 As Boolean = Me._customerLedgerBookTableAdapter IsNot Nothing
					If flag121 Then
						Me._customerLedgerBookTableAdapter.Connection = CType(dictionary(Me._customerLedgerBookTableAdapter), SqlConnection)
						Me._customerLedgerBookTableAdapter.Transaction = Nothing
					End If
					Dim flag122 As Boolean = Me._emailSettingTableAdapter IsNot Nothing
					If flag122 Then
						Me._emailSettingTableAdapter.Connection = CType(dictionary(Me._emailSettingTableAdapter), SqlConnection)
						Me._emailSettingTableAdapter.Transaction = Nothing
					End If
					Dim flag123 As Boolean = Me._fundDepositTableAdapter IsNot Nothing
					If flag123 Then
						Me._fundDepositTableAdapter.Connection = CType(dictionary(Me._fundDepositTableAdapter), SqlConnection)
						Me._fundDepositTableAdapter.Transaction = Nothing
					End If
					Dim flag124 As Boolean = Me._fundTransferTableAdapter IsNot Nothing
					If flag124 Then
						Me._fundTransferTableAdapter.Connection = CType(dictionary(Me._fundTransferTableAdapter), SqlConnection)
						Me._fundTransferTableAdapter.Transaction = Nothing
					End If
					Dim flag125 As Boolean = Me._invoice_PaymentTableAdapter IsNot Nothing
					If flag125 Then
						Me._invoice_PaymentTableAdapter.Connection = CType(dictionary(Me._invoice_PaymentTableAdapter), SqlConnection)
						Me._invoice_PaymentTableAdapter.Transaction = Nothing
					End If
					Dim flag126 As Boolean = Me._invoice_ProductTableAdapter IsNot Nothing
					If flag126 Then
						Me._invoice_ProductTableAdapter.Connection = CType(dictionary(Me._invoice_ProductTableAdapter), SqlConnection)
						Me._invoice_ProductTableAdapter.Transaction = Nothing
					End If
					Dim flag127 As Boolean = Me._invoiceInfoTableAdapter IsNot Nothing
					If flag127 Then
						Me._invoiceInfoTableAdapter.Connection = CType(dictionary(Me._invoiceInfoTableAdapter), SqlConnection)
						Me._invoiceInfoTableAdapter.Transaction = Nothing
					End If
					Dim flag128 As Boolean = Me._invoiceInfo1TableAdapter IsNot Nothing
					If flag128 Then
						Me._invoiceInfo1TableAdapter.Connection = CType(dictionary(Me._invoiceInfo1TableAdapter), SqlConnection)
						Me._invoiceInfo1TableAdapter.Transaction = Nothing
					End If
					Dim flag129 As Boolean = Me._ledgerBookTableAdapter IsNot Nothing
					If flag129 Then
						Me._ledgerBookTableAdapter.Connection = CType(dictionary(Me._ledgerBookTableAdapter), SqlConnection)
						Me._ledgerBookTableAdapter.Transaction = Nothing
					End If
					Dim flag130 As Boolean = Me._logsTableAdapter IsNot Nothing
					If flag130 Then
						Me._logsTableAdapter.Connection = CType(dictionary(Me._logsTableAdapter), SqlConnection)
						Me._logsTableAdapter.Transaction = Nothing
					End If
					Dim flag131 As Boolean = Me._paymentTableAdapter IsNot Nothing
					If flag131 Then
						Me._paymentTableAdapter.Connection = CType(dictionary(Me._paymentTableAdapter), SqlConnection)
						Me._paymentTableAdapter.Transaction = Nothing
					End If
					Dim flag132 As Boolean = Me._payment_WithdrawTableAdapter IsNot Nothing
					If flag132 Then
						Me._payment_WithdrawTableAdapter.Connection = CType(dictionary(Me._payment_WithdrawTableAdapter), SqlConnection)
						Me._payment_WithdrawTableAdapter.Transaction = Nothing
					End If
					Dim flag133 As Boolean = Me._productTableAdapter IsNot Nothing
					If flag133 Then
						Me._productTableAdapter.Connection = CType(dictionary(Me._productTableAdapter), SqlConnection)
						Me._productTableAdapter.Transaction = Nothing
					End If
					Dim flag134 As Boolean = Me._product_JoinTableAdapter IsNot Nothing
					If flag134 Then
						Me._product_JoinTableAdapter.Connection = CType(dictionary(Me._product_JoinTableAdapter), SqlConnection)
						Me._product_JoinTableAdapter.Transaction = Nothing
					End If
					Dim flag135 As Boolean = Me._purchaseOrderTableAdapter IsNot Nothing
					If flag135 Then
						Me._purchaseOrderTableAdapter.Connection = CType(dictionary(Me._purchaseOrderTableAdapter), SqlConnection)
						Me._purchaseOrderTableAdapter.Transaction = Nothing
					End If
					Dim flag136 As Boolean = Me._purchaseOrder_JoinTableAdapter IsNot Nothing
					If flag136 Then
						Me._purchaseOrder_JoinTableAdapter.Connection = CType(dictionary(Me._purchaseOrder_JoinTableAdapter), SqlConnection)
						Me._purchaseOrder_JoinTableAdapter.Transaction = Nothing
					End If
					Dim flag137 As Boolean = Me._purchaseReturnTableAdapter IsNot Nothing
					If flag137 Then
						Me._purchaseReturnTableAdapter.Connection = CType(dictionary(Me._purchaseReturnTableAdapter), SqlConnection)
						Me._purchaseReturnTableAdapter.Transaction = Nothing
					End If
					Dim flag138 As Boolean = Me._purchaseReturn_JoinTableAdapter IsNot Nothing
					If flag138 Then
						Me._purchaseReturn_JoinTableAdapter.Connection = CType(dictionary(Me._purchaseReturn_JoinTableAdapter), SqlConnection)
						Me._purchaseReturn_JoinTableAdapter.Transaction = Nothing
					End If
					Dim flag139 As Boolean = Me._quotationTableAdapter IsNot Nothing
					If flag139 Then
						Me._quotationTableAdapter.Connection = CType(dictionary(Me._quotationTableAdapter), SqlConnection)
						Me._quotationTableAdapter.Transaction = Nothing
					End If
					Dim flag140 As Boolean = Me._quotation_JoinTableAdapter IsNot Nothing
					If flag140 Then
						Me._quotation_JoinTableAdapter.Connection = CType(dictionary(Me._quotation_JoinTableAdapter), SqlConnection)
						Me._quotation_JoinTableAdapter.Transaction = Nothing
					End If
					Dim flag141 As Boolean = Me._registrationTableAdapter IsNot Nothing
					If flag141 Then
						Me._registrationTableAdapter.Connection = CType(dictionary(Me._registrationTableAdapter), SqlConnection)
						Me._registrationTableAdapter.Transaction = Nothing
					End If
					Dim flag142 As Boolean = Me._salesManTableAdapter IsNot Nothing
					If flag142 Then
						Me._salesManTableAdapter.Connection = CType(dictionary(Me._salesManTableAdapter), SqlConnection)
						Me._salesManTableAdapter.Transaction = Nothing
					End If
					Dim flag143 As Boolean = Me._salesman_CommissionTableAdapter IsNot Nothing
					If flag143 Then
						Me._salesman_CommissionTableAdapter.Connection = CType(dictionary(Me._salesman_CommissionTableAdapter), SqlConnection)
						Me._salesman_CommissionTableAdapter.Transaction = Nothing
					End If
					Dim flag144 As Boolean = Me._salesReturnTableAdapter IsNot Nothing
					If flag144 Then
						Me._salesReturnTableAdapter.Connection = CType(dictionary(Me._salesReturnTableAdapter), SqlConnection)
						Me._salesReturnTableAdapter.Transaction = Nothing
					End If
					Dim flag145 As Boolean = Me._salesReturn_JoinTableAdapter IsNot Nothing
					If flag145 Then
						Me._salesReturn_JoinTableAdapter.Connection = CType(dictionary(Me._salesReturn_JoinTableAdapter), SqlConnection)
						Me._salesReturn_JoinTableAdapter.Transaction = Nothing
					End If
					Dim flag146 As Boolean = Me._serviceTableAdapter IsNot Nothing
					If flag146 Then
						Me._serviceTableAdapter.Connection = CType(dictionary(Me._serviceTableAdapter), SqlConnection)
						Me._serviceTableAdapter.Transaction = Nothing
					End If
					Dim flag147 As Boolean = Me._settingTableAdapter IsNot Nothing
					If flag147 Then
						Me._settingTableAdapter.Connection = CType(dictionary(Me._settingTableAdapter), SqlConnection)
						Me._settingTableAdapter.Transaction = Nothing
					End If
					Dim flag148 As Boolean = Me._sMSTableAdapter IsNot Nothing
					If flag148 Then
						Me._sMSTableAdapter.Connection = CType(dictionary(Me._sMSTableAdapter), SqlConnection)
						Me._sMSTableAdapter.Transaction = Nothing
					End If
					Dim flag149 As Boolean = Me._sMSSettingTableAdapter IsNot Nothing
					If flag149 Then
						Me._sMSSettingTableAdapter.Connection = CType(dictionary(Me._sMSSettingTableAdapter), SqlConnection)
						Me._sMSSettingTableAdapter.Transaction = Nothing
					End If
					Dim flag150 As Boolean = Me._stockTableAdapter IsNot Nothing
					If flag150 Then
						Me._stockTableAdapter.Connection = CType(dictionary(Me._stockTableAdapter), SqlConnection)
						Me._stockTableAdapter.Transaction = Nothing
					End If
					Dim flag151 As Boolean = Me._stock_ProductTableAdapter IsNot Nothing
					If flag151 Then
						Me._stock_ProductTableAdapter.Connection = CType(dictionary(Me._stock_ProductTableAdapter), SqlConnection)
						Me._stock_ProductTableAdapter.Transaction = Nothing
					End If
					Dim flag152 As Boolean = Me._stockAdjustmentTableAdapter IsNot Nothing
					If flag152 Then
						Me._stockAdjustmentTableAdapter.Connection = CType(dictionary(Me._stockAdjustmentTableAdapter), SqlConnection)
						Me._stockAdjustmentTableAdapter.Transaction = Nothing
					End If
					Dim flag153 As Boolean = Me._subCategoryTableAdapter IsNot Nothing
					If flag153 Then
						Me._subCategoryTableAdapter.Connection = CType(dictionary(Me._subCategoryTableAdapter), SqlConnection)
						Me._subCategoryTableAdapter.Transaction = Nothing
					End If
					Dim flag154 As Boolean = Me._supplierTableAdapter IsNot Nothing
					If flag154 Then
						Me._supplierTableAdapter.Connection = CType(dictionary(Me._supplierTableAdapter), SqlConnection)
						Me._supplierTableAdapter.Transaction = Nothing
					End If
					Dim flag155 As Boolean = Me._supplierLedgerBookTableAdapter IsNot Nothing
					If flag155 Then
						Me._supplierLedgerBookTableAdapter.Connection = CType(dictionary(Me._supplierLedgerBookTableAdapter), SqlConnection)
						Me._supplierLedgerBookTableAdapter.Transaction = Nothing
					End If
					Dim flag156 As Boolean = Me._temp_StockTableAdapter IsNot Nothing
					If flag156 Then
						Me._temp_StockTableAdapter.Connection = CType(dictionary(Me._temp_StockTableAdapter), SqlConnection)
						Me._temp_StockTableAdapter.Transaction = Nothing
					End If
					Dim flag157 As Boolean = Me._unitMasterTableAdapter IsNot Nothing
					If flag157 Then
						Me._unitMasterTableAdapter.Connection = CType(dictionary(Me._unitMasterTableAdapter), SqlConnection)
						Me._unitMasterTableAdapter.Transaction = Nothing
					End If
					Dim flag158 As Boolean = Me._voucherTableAdapter IsNot Nothing
					If flag158 Then
						Me._voucherTableAdapter.Connection = CType(dictionary(Me._voucherTableAdapter), SqlConnection)
						Me._voucherTableAdapter.Transaction = Nothing
					End If
					Dim flag159 As Boolean = Me._voucher_OtherDetailsTableAdapter IsNot Nothing
					If flag159 Then
						Me._voucher_OtherDetailsTableAdapter.Connection = CType(dictionary(Me._voucher_OtherDetailsTableAdapter), SqlConnection)
						Me._voucher_OtherDetailsTableAdapter.Transaction = Nothing
					End If
					Dim flag160 As Boolean = 0 < list3.Count
					If flag160 Then
						Dim array4 As DataAdapter() = New DataAdapter(list3.Count - 1 + 1 - 1) {}
						list3.CopyTo(array4)
						For Each dataAdapter As DataAdapter In array4
							dataAdapter.AcceptChangesDuringUpdate = True
						Next
					End If
				End Try
				num = num2
			End If
			Return num
		End Function

		' Token: 0x0600E81B RID: 59419 RVA: 0x000661BD File Offset: 0x000643BD
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overridable Sub SortSelfReferenceRows(rows As DataRow(), relation As DataRelation, childFirst As Boolean)
			Array.Sort(Of DataRow)(rows, New TableAdapterManager.SelfReferenceComparer(relation, childFirst))
		End Sub

		' Token: 0x0600E81C RID: 59420 RVA: 0x008CE130 File Offset: 0x008CC330
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Overridable Function MatchTableAdapterConnection(inputConnection As IDbConnection) As Boolean
			Dim flag As Boolean = Me._connection IsNot Nothing
			Dim flag2 As Boolean
			If flag Then
				flag2 = True
			Else
				Dim flag3 As Boolean = Me.Connection Is Nothing OrElse inputConnection Is Nothing
				If flag3 Then
					flag2 = True
				Else
					Dim flag4 As Boolean = String.Equals(Me.Connection.ConnectionString, inputConnection.ConnectionString, StringComparison.Ordinal)
					flag2 = flag4
				End If
			End If
			Return flag2
		End Function

		' Token: 0x04005906 RID: 22790
		Private _updateOrder As TableAdapterManager.UpdateOrderOption

		' Token: 0x04005907 RID: 22791
		Private _activationTableAdapter As ActivationTableAdapter

		' Token: 0x04005908 RID: 22792
		Private _bankTableAdapter As BankTableAdapter

		' Token: 0x04005909 RID: 22793
		Private _bankAccountLedgerTableAdapter As BankAccountLedgerTableAdapter

		' Token: 0x0400590A RID: 22794
		Private _bankAccountRegistrationTableAdapter As BankAccountRegistrationTableAdapter

		' Token: 0x0400590B RID: 22795
		Private _bankBranchTableAdapter As BankBranchTableAdapter

		' Token: 0x0400590C RID: 22796
		Private _categoryTableAdapter As CategoryTableAdapter

		' Token: 0x0400590D RID: 22797
		Private _companyTableAdapter As CompanyTableAdapter

		' Token: 0x0400590E RID: 22798
		Private _company_ContactsTableAdapter As Company_ContactsTableAdapter

		' Token: 0x0400590F RID: 22799
		Private _creditCustomerPaymentTableAdapter As CreditCustomerPaymentTableAdapter

		' Token: 0x04005910 RID: 22800
		Private _customerTableAdapter As CustomerTableAdapter

		' Token: 0x04005911 RID: 22801
		Private _customerLedgerBookTableAdapter As CustomerLedgerBookTableAdapter

		' Token: 0x04005912 RID: 22802
		Private _emailSettingTableAdapter As EmailSettingTableAdapter

		' Token: 0x04005913 RID: 22803
		Private _fundDepositTableAdapter As FundDepositTableAdapter

		' Token: 0x04005914 RID: 22804
		Private _fundTransferTableAdapter As FundTransferTableAdapter

		' Token: 0x04005915 RID: 22805
		Private _invoice_PaymentTableAdapter As Invoice_PaymentTableAdapter

		' Token: 0x04005916 RID: 22806
		Private _invoice_ProductTableAdapter As Invoice_ProductTableAdapter

		' Token: 0x04005917 RID: 22807
		Private _invoiceInfoTableAdapter As InvoiceInfoTableAdapter

		' Token: 0x04005918 RID: 22808
		Private _invoiceInfo1TableAdapter As InvoiceInfo1TableAdapter

		' Token: 0x04005919 RID: 22809
		Private _ledgerBookTableAdapter As LedgerBookTableAdapter

		' Token: 0x0400591A RID: 22810
		Private _logsTableAdapter As LogsTableAdapter

		' Token: 0x0400591B RID: 22811
		Private _paymentTableAdapter As PaymentTableAdapter

		' Token: 0x0400591C RID: 22812
		Private _payment_WithdrawTableAdapter As Payment_WithdrawTableAdapter

		' Token: 0x0400591D RID: 22813
		Private _productTableAdapter As ProductTableAdapter

		' Token: 0x0400591E RID: 22814
		Private _product_JoinTableAdapter As Product_JoinTableAdapter

		' Token: 0x0400591F RID: 22815
		Private _purchaseOrderTableAdapter As PurchaseOrderTableAdapter

		' Token: 0x04005920 RID: 22816
		Private _purchaseOrder_JoinTableAdapter As PurchaseOrder_JoinTableAdapter

		' Token: 0x04005921 RID: 22817
		Private _purchaseReturnTableAdapter As PurchaseReturnTableAdapter

		' Token: 0x04005922 RID: 22818
		Private _purchaseReturn_JoinTableAdapter As PurchaseReturn_JoinTableAdapter

		' Token: 0x04005923 RID: 22819
		Private _quotationTableAdapter As QuotationTableAdapter

		' Token: 0x04005924 RID: 22820
		Private _quotation_JoinTableAdapter As Quotation_JoinTableAdapter

		' Token: 0x04005925 RID: 22821
		Private _registrationTableAdapter As RegistrationTableAdapter

		' Token: 0x04005926 RID: 22822
		Private _salesManTableAdapter As SalesManTableAdapter

		' Token: 0x04005927 RID: 22823
		Private _salesman_CommissionTableAdapter As Salesman_CommissionTableAdapter

		' Token: 0x04005928 RID: 22824
		Private _salesReturnTableAdapter As SalesReturnTableAdapter

		' Token: 0x04005929 RID: 22825
		Private _salesReturn_JoinTableAdapter As SalesReturn_JoinTableAdapter

		' Token: 0x0400592A RID: 22826
		Private _serviceTableAdapter As ServiceTableAdapter

		' Token: 0x0400592B RID: 22827
		Private _settingTableAdapter As SettingTableAdapter

		' Token: 0x0400592C RID: 22828
		Private _sMSTableAdapter As SMSTableAdapter

		' Token: 0x0400592D RID: 22829
		Private _sMSSettingTableAdapter As SMSSettingTableAdapter

		' Token: 0x0400592E RID: 22830
		Private _stockTableAdapter As StockTableAdapter

		' Token: 0x0400592F RID: 22831
		Private _stock_ProductTableAdapter As Stock_ProductTableAdapter

		' Token: 0x04005930 RID: 22832
		Private _stockAdjustmentTableAdapter As StockAdjustmentTableAdapter

		' Token: 0x04005931 RID: 22833
		Private _subCategoryTableAdapter As SubCategoryTableAdapter

		' Token: 0x04005932 RID: 22834
		Private _supplierTableAdapter As SupplierTableAdapter

		' Token: 0x04005933 RID: 22835
		Private _supplierLedgerBookTableAdapter As SupplierLedgerBookTableAdapter

		' Token: 0x04005934 RID: 22836
		Private _temp_StockTableAdapter As Temp_StockTableAdapter

		' Token: 0x04005935 RID: 22837
		Private _unitMasterTableAdapter As UnitMasterTableAdapter

		' Token: 0x04005936 RID: 22838
		Private _voucherTableAdapter As VoucherTableAdapter

		' Token: 0x04005937 RID: 22839
		Private _voucher_OtherDetailsTableAdapter As Voucher_OtherDetailsTableAdapter

		' Token: 0x04005938 RID: 22840
		Private _backupDataSetBeforeUpdate As Boolean

		' Token: 0x04005939 RID: 22841
		Private _connection As IDbConnection

		' Token: 0x02000473 RID: 1139
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Enum UpdateOrderOption
			' Token: 0x0400593B RID: 22843
			InsertUpdateDelete
			' Token: 0x0400593C RID: 22844
			UpdateInsertDelete
		End Enum

		' Token: 0x02000474 RID: 1140
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Class SelfReferenceComparer
			Implements IComparer(Of DataRow)

			' Token: 0x0600E81D RID: 59421 RVA: 0x008CE190 File Offset: 0x008CC390
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Friend Sub New(relation As DataRelation, childFirst As Boolean)
				Me._relation = relation
				If childFirst Then
					Me._childFirst = -1
				Else
					Me._childFirst = 1
				End If
			End Sub

			' Token: 0x0600E81E RID: 59422 RVA: 0x008CE1C4 File Offset: 0x008CC3C4
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Private Function GetRoot(row As DataRow, ByRef distance As Integer) As DataRow
				Debug.Assert(row IsNot Nothing)
				Dim dataRow As DataRow = row
				distance = 0
				Dim dictionary As IDictionary(Of DataRow, DataRow) = New Dictionary(Of DataRow, DataRow)()
				dictionary(row) = row
				Dim dataRow2 As DataRow = row.GetParentRow(Me._relation, DataRowVersion.[Default])
				While dataRow2 IsNot Nothing AndAlso Not dictionary.ContainsKey(dataRow2)
					distance += 1
					dataRow = dataRow2
					dictionary(dataRow2) = dataRow2
					dataRow2 = dataRow2.GetParentRow(Me._relation, DataRowVersion.[Default])
				End While
				Dim flag As Boolean = distance = 0
				If flag Then
					dictionary.Clear()
					dictionary(row) = row
					dataRow2 = row.GetParentRow(Me._relation, DataRowVersion.Original)
					While dataRow2 IsNot Nothing AndAlso Not dictionary.ContainsKey(dataRow2)
						distance += 1
						dataRow = dataRow2
						dictionary(dataRow2) = dataRow2
						dataRow2 = dataRow2.GetParentRow(Me._relation, DataRowVersion.Original)
					End While
				End If
				Return dataRow
			End Function

			' Token: 0x0600E81F RID: 59423 RVA: 0x008CE2B0 File Offset: 0x008CC4B0
			<DebuggerNonUserCode()>
			<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
			Public Function Compare(row1 As DataRow, row2 As DataRow) As Integer Implements System.Collections.Generic.IComparer(Of System.Data.DataRow).Compare
				Dim flag As Boolean = Object.ReferenceEquals(row1, row2)
				Dim num As Integer
				If flag Then
					num = 0
				Else
					Dim flag2 As Boolean = row1 Is Nothing
					If flag2 Then
						num = -1
					Else
						Dim flag3 As Boolean = row2 Is Nothing
						If flag3 Then
							num = 1
						Else
							Dim num2 As Integer = 0
							Dim root As DataRow = Me.GetRoot(row1, num2)
							Dim num3 As Integer = 0
							Dim root2 As DataRow = Me.GetRoot(row2, num3)
							Dim flag4 As Boolean = Object.ReferenceEquals(root, root2)
							If flag4 Then
								' The following expression was wrapped in a checked-expression
								num = Me._childFirst * num2.CompareTo(num3)
							Else
								Debug.Assert(root.Table IsNot Nothing AndAlso root2.Table IsNot Nothing)
								Dim flag5 As Boolean = root.Table.Rows.IndexOf(root) < root2.Table.Rows.IndexOf(root2)
								If flag5 Then
									num = -1
								Else
									num = 1
								End If
							End If
						End If
					End If
				End If
				Return num
			End Function

			' Token: 0x0400593D RID: 22845
			Private _relation As DataRelation

			' Token: 0x0400593E RID: 22846
			Private _childFirst As Integer
		End Class
	End Class
End Namespace
