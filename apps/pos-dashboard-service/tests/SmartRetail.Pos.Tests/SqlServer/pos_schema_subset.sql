-- The POS tables that the SQL Server repositories read, copied unchanged from the POS
-- database script (DBscript.sql). The SQL Server integration tests build a throwaway
-- database from this file. Batches are separated by GO lines.
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryName] [nchar](150) NOT NULL,
	[CPhoto] [image] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE TABLE [dbo].[SubCategory](
	[ID] [int] NOT NULL,
	[SubCategoryName] [nchar](150) NOT NULL,
	[Category] [nchar](150) NOT NULL,
	[SCPhoto] [image] NULL,
	[IsDefault] [varchar](10) NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE TABLE [dbo].[Product](
	[PID] [int] NOT NULL,
	[ProductCode] [nchar](30) NOT NULL,
	[ProductName] [nchar](200) NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[HSNCode] [nchar](30) NULL,
	[PartNo] [nchar](30) NULL,
	[Description] [nvarchar](max) NULL,
	[CostPrice] [decimal](18, 2) NOT NULL,
	[SellingPrice] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[Barcode] [nchar](30) NULL,
	[ReorderPoint] [decimal](18, 2) NULL,
	[OpeningStock] [decimal](18, 3) NULL,
	[PurchaseUnit] [nchar](150) NULL,
	[SalesUnit] [nchar](150) NULL,
	[SalesAltUnit] [nchar](150) NULL,
	[Conv] [nchar](150) NULL,
	[LastPrice] [decimal](18, 2) NULL,
	[MinStock] [decimal](18, 3) NULL,
	[MRP] [decimal](18, 2) NULL,
	[Status] [nchar](10) NULL,
	[STax] [nvarchar](20) NULL,
	[PTax] [nvarchar](20) NULL,
	[GDown] [nvarchar](250) NULL,
	[Rack] [nvarchar](250) NULL,
	[AddDate] [datetime] NULL,
	[DefQty] [nvarchar](20) NULL,
	[Kitchen] [nvarchar](250) NULL,
	[loyality_mode] [nvarchar](250) NULL,
	[loyality_value] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Temp_Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Qty] [decimal](18, 3) NOT NULL,
	[Barcode] [nvarchar](50) NULL,
	[Damage] [decimal](18, 3) NULL,
	[SalePrice] [nvarchar](50) NULL,
	[WSalePrice] [nvarchar](50) NULL,
	[StLimit] [decimal](18, 3) NULL,
	[MRP] [decimal](18, 2) NULL,
	[Batch] [nvarchar](50) NULL,
	[Mfgdate] [nvarchar](20) NULL,
	[Expdate] [nvarchar](20) NULL,
	[Size] [nvarchar](50) NULL,
	[Colour] [nvarchar](50) NULL,
	[SPrice] [decimal](18, 2) NULL,
	[WPrice] [decimal](18, 2) NULL,
	[SuplName] [nvarchar](150) NULL,
	[IMEI1] [nvarchar](150) NULL,
	[IMEI2] [nvarchar](150) NULL,
	[PPrice] [decimal](18, 2) NULL,
	[EPPrice] [decimal](18, 2) NULL,
	[QrBarcode] [image] NULL,
	[SalesManPur] [decimal](18, 2) NULL,
	[Variant_id] [int] NULL,
	[s1] [nchar](10) NULL,
	[Serial_no] [nvarchar](50) NULL,
 CONSTRAINT [PK_Temp_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[CustomerID] [nchar](30) NULL,
	[Name] [nchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nchar](200) NULL,
	[State] [nchar](150) NULL,
	[ZipCode] [nchar](15) NULL,
	[ContactNo] [nchar](150) NULL,
	[EmailID] [nchar](200) NULL,
	[Remarks] [nvarchar](max) NULL,
	[AccountNumber] [nchar](30) NULL,
	[AccountName] [nchar](200) NULL,
	[Bank] [nchar](200) NULL,
	[Branch] [nchar](200) NULL,
	[IFSCCode] [nchar](30) NULL,
	[GSTIN] [nchar](50) NULL,
	[PAN] [nchar](50) NULL,
	[CIN] [nchar](50) NULL,
	[Optype] [nchar](20) NULL,
	[Opbal] [decimal](18, 2) NULL,
	[Photo] [image] NULL,
	[Tcs] [nvarchar](50) NULL,
	[CardNo] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Limit] [decimal](18, 2) NULL,
	[Lstatus] [nchar](10) NULL,
	[Route] [nchar](150) NULL,
	[Taround] [nchar](10) NULL,
	[Lvisitdate] [datetime] NULL,
	[DiscPer] [nvarchar](20) NULL,
	[DiscStatus] [nvarchar](10) NULL,
	[QrCustomer] [image] NULL,
	[OpLoyalitytype] [nchar](20) NULL,
	[OpbalLoyality] [decimal](18, 2) NULL,
	[is_loyalityDisable] [int] NOT NULL,
	[shippingAddress] [nvarchar](200) NULL,
CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE TABLE [dbo].[InvoiceInfo](
	[Inv_ID] [int] NOT NULL,
	[InvoiceNo] [nchar](30) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[TaxType] [nchar](20) NULL,
	[Customer_ID] [int] NOT NULL,
	[SalesmanID] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[FreightCharges] [decimal](18, 2) NULL,
	[OtherCharges] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[RoundOff] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[Eway] [nvarchar](max) NULL,
	[TillID] [nchar](100) NULL,
	[Operator] [nchar](100) NULL,
	[BillSundry] [nvarchar](max) NULL,
	[OfferAmt] [decimal](18, 2) NULL,
	[LoyaAmt] [decimal](18, 2) NULL,
	[BillDiscount] [decimal](18, 2) NULL,
	[AddLpoint] [decimal](18, 2) NULL,
	[Narration] [nvarchar](max) NULL,
	[TCSPer] [decimal](18, 3) NULL,
	[TaxableAmt] [decimal](18, 2) NULL,
	[CType] [nchar](10) NULL,
	[Tender] [decimal](18, 2) NULL,
	[Refund] [decimal](18, 2) NULL,
	[BillCash] [decimal](18, 2) NULL,
	[CouponAmt] [decimal](18, 2) NULL,
	[GiftAmt] [decimal](18, 2) NULL,
	[ByReturn] [decimal](18, 2) NULL,
	[SRNumber] [nchar](30) NULL,
	[TotalLoyalityPoints] [decimal](18, 2) NULL,
	[LoyalityReedemPoints] [decimal](18, 2) NULL,
	[LoyalityReedemAmt] [decimal](18, 2) NULL,
 CONSTRAINT [PK_InvoiceInfo] PRIMARY KEY CLUSTERED 
(
	[Inv_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Invoice_Product](
	[IPo_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Barcode] [nchar](30) NULL,
	[SalesRate] [decimal](18, 2) NOT NULL,
	[Qty] [decimal](18, 3) NOT NULL,
	[DiscountPer] [decimal](18, 4) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[CGSTPer] [decimal](18, 2) NOT NULL,
	[CGSTAmt] [decimal](18, 2) NOT NULL,
	[SGSTPer] [decimal](18, 2) NULL,
	[SGSTAmt] [decimal](18, 2) NULL,
	[IGSTPer] [decimal](18, 2) NULL,
	[IGSTAmt] [decimal](18, 2) NULL,
	[CESSPer] [decimal](18, 2) NULL,
	[CESSAmt] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[PurchaseRate] [decimal](18, 2) NOT NULL,
	[Margin] [decimal](18, 2) NOT NULL,
	[Descr] [nvarchar](max) NULL,
	[IM1] [nvarchar](50) NULL,
	[IM2] [nvarchar](50) NULL,
	[MRP] [decimal](18, 2) NULL,
	[TaxableAmt] [decimal](18, 2) NULL,
	[AltQty] [decimal](18, 3) NULL,
	[AltUnit] [nvarchar](50) NULL,
	[STaxType] [nvarchar](50) NULL,
	[TotalMRP] [decimal](18, 2) NULL,
	[PromoQty] [int] NULL,
	[MainUnit] [nvarchar](50) NULL,
	[Batch] [nvarchar](50) NULL,
	[Mfg] [nvarchar](20) NULL,
	[Exp] [nvarchar](20) NULL,
	[Size] [nvarchar](50) NULL,
	[Colour] [nvarchar](50) NULL,
	[SalesManID] [int] NULL,
	[SalesMan] [varchar](150) NULL,
	[SalesManPur] [decimal](18, 2) NULL,
	[SalesManComm] [decimal](18, 2) NULL,
	[StockID] [char](10) NULL,
	[LoyalityPoints] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Invoice_Product] PRIMARY KEY CLUSTERED 
(
	[IPo_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Invoice_Payment](
	[IP_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[PaymentMode] [nchar](150) NOT NULL,
	[BankAc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Invoice_Payment] PRIMARY KEY CLUSTERED 
(
	[IP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[SalesReturn](
	[SR_ID] [int] NOT NULL,
	[SRNo] [nchar](30) NULL,
	[Date] [datetime] NULL,
	[SalesID] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[FreightCharges] [decimal](18, 2) NULL,
	[OtherCharges] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[RoundOff] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[PaymentMode] [nvarchar](50) NOT NULL,
	[BillSundry] [nvarchar](max) NULL,
	[TotalLoyalityPoints] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SalesReturn] PRIMARY KEY CLUSTERED 
(
	[SR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([CategoryName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[SubCategory] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SubCategory]
GO
ALTER TABLE [dbo].[Temp_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Temp_Stock_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Temp_Stock] CHECK CONSTRAINT [FK_Temp_Stock_Product]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_is_loyalityDisable]  DEFAULT ((0)) FOR [is_loyalityDisable]
GO
ALTER TABLE [dbo].[Invoice_Product]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Product_InvoiceInfo] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice_Product]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Product_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Invoice_Payment]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Payment_InvoiceInfo] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesReturn]  WITH CHECK ADD  CONSTRAINT [FK_SalesReturn_InvoiceInfo] FOREIGN KEY([SalesID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
GO
-- The POS log, where it records when each bill was saved (not in DBscript.sql as it is kept here; scripted
-- from a restored shop database).
CREATE TABLE [dbo].[Logs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nchar](100) NOT NULL,
	[Operation] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
