IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_GroupCode_tbl_Tenant]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_GroupCode]'))
ALTER TABLE [dbo].[tbl_GroupCode] DROP CONSTRAINT [FK_tbl_GroupCode_tbl_Tenant]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceMaster_tbl_Model]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]'))
ALTER TABLE [dbo].[tbl_FinanceMaster] DROP CONSTRAINT [FK_tbl_FinanceMaster_tbl_Model]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceMaster_tbl_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]'))
ALTER TABLE [dbo].[tbl_FinanceMaster] DROP CONSTRAINT [FK_tbl_FinanceMaster_tbl_Customer]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceDetails_tbl_FinanceMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceDetails]'))
ALTER TABLE [dbo].[tbl_FinanceDetails] DROP CONSTRAINT [FK_tbl_FinanceDetails_tbl_FinanceMaster]
GO
/****** Object:  Table [dbo].[tbl_GroupCode]    Script Date: 12/15/2019 4:22:23 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_GroupCode]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_GroupCode]
GO
/****** Object:  Table [dbo].[tbl_FinanceMaster]    Script Date: 12/15/2019 4:22:23 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_FinanceMaster]
GO
/****** Object:  Table [dbo].[tbl_FinanceDetails]    Script Date: 12/15/2019 4:22:23 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_FinanceDetails]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_FinanceDetails]
GO
/****** Object:  Table [dbo].[tbl_FinanceDetails]    Script Date: 12/15/2019 4:22:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_FinanceDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_FinanceDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FinanceMasterId] [int] NOT NULL,
	[EmiDate] [date] NOT NULL,
	[ReceivedDate] [date] NULL,
	[DueDate] [date] NOT NULL,
	[ReceivedBy] [int] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_FinanceDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_FinanceMaster]    Script Date: 12/15/2019 4:22:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_FinanceMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[BookNo] [nvarchar](50) NOT NULL,
	[PageNo] [nvarchar](50) NOT NULL,
	[ModelId] [int] NOT NULL,
	[MobilePrice] [decimal](18, 2) NOT NULL,
	[LoanAmount] [decimal](18, 2) NOT NULL,
	[DownPayment] [decimal](18, 2) NOT NULL,
	[EMI] [decimal](18, 2) NOT NULL,
	[InterestRateId] [int] NOT NULL,
	[DurationId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Guarantor1] [int] NULL,
	[Guarantor2] [int] NULL,
	[StatusId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_tbl_FinanceMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_GroupCode]    Script Date: 12/15/2019 4:22:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_GroupCode]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_GroupCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](max) NOT NULL,
	[TenantId] [int] NOT NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_tbl_GroupCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tbl_FinanceMaster] ON 

GO
INSERT [dbo].[tbl_FinanceMaster] ([Id], [CustomerId], [BookNo], [PageNo], [ModelId], [MobilePrice], [LoanAmount], [DownPayment], [EMI], [InterestRateId], [DurationId], [StartDate], [EndDate], [Guarantor1], [Guarantor2], [StatusId], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (1, 2, N'1', N'1', 1, CAST(5000.00 AS Decimal(18, 2)), CAST(4500.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(700.00 AS Decimal(18, 2)), 10, 7, CAST(N'2019-12-15' AS Date), CAST(N'2020-06-15' AS Date), NULL, NULL, 0, 2, N'c8022d34-d7cc-47a6-90e2-2201966d587e', CAST(N'2019-12-15 03:48:12.350' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_FinanceMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_GroupCode] ON 

GO
INSERT [dbo].[tbl_GroupCode] ([Id], [Code], [Name], [DisplayName], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (2, N'FN_AC', N'FinanceStatus', N'Active', 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_GroupCode] ([Id], [Code], [Name], [DisplayName], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (3, N'FN_CS', N'FinanceStatus', N'Closed', 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_GroupCode] ([Id], [Code], [Name], [DisplayName], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (5, N'FN_PD', N'FinanceStatus', N'Paid', 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_GroupCode] ([Id], [Code], [Name], [DisplayName], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (6, N'3', N'Duration', N'3 Months', 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_GroupCode] ([Id], [Code], [Name], [DisplayName], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (7, N'6', N'Duration', N'6 Months', 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_GroupCode] ([Id], [Code], [Name], [DisplayName], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (8, N'12', N'Duration', N'12 Months', 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_GroupCode] ([Id], [Code], [Name], [DisplayName], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (9, N'0', N'Interest', N'0 %', 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_GroupCode] ([Id], [Code], [Name], [DisplayName], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (10, N'5', N'Interest', N'5 %', 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_GroupCode] ([Id], [Code], [Name], [DisplayName], [TenantId], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy]) VALUES (11, N'10', N'Interest', N'10 %', 2, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_GroupCode] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceDetails_tbl_FinanceMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceDetails]'))
ALTER TABLE [dbo].[tbl_FinanceDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_FinanceDetails_tbl_FinanceMaster] FOREIGN KEY([FinanceMasterId])
REFERENCES [dbo].[tbl_FinanceMaster] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceDetails_tbl_FinanceMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceDetails]'))
ALTER TABLE [dbo].[tbl_FinanceDetails] CHECK CONSTRAINT [FK_tbl_FinanceDetails_tbl_FinanceMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceMaster_tbl_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]'))
ALTER TABLE [dbo].[tbl_FinanceMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_FinanceMaster_tbl_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tbl_Customer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceMaster_tbl_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]'))
ALTER TABLE [dbo].[tbl_FinanceMaster] CHECK CONSTRAINT [FK_tbl_FinanceMaster_tbl_Customer]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceMaster_tbl_Model]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]'))
ALTER TABLE [dbo].[tbl_FinanceMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_FinanceMaster_tbl_Model] FOREIGN KEY([ModelId])
REFERENCES [dbo].[tbl_Model] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceMaster_tbl_Model]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]'))
ALTER TABLE [dbo].[tbl_FinanceMaster] CHECK CONSTRAINT [FK_tbl_FinanceMaster_tbl_Model]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_GroupCode_tbl_Tenant]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_GroupCode]'))
ALTER TABLE [dbo].[tbl_GroupCode]  WITH CHECK ADD  CONSTRAINT [FK_tbl_GroupCode_tbl_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[tbl_Tenant] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_GroupCode_tbl_Tenant]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_GroupCode]'))
ALTER TABLE [dbo].[tbl_GroupCode] CHECK CONSTRAINT [FK_tbl_GroupCode_tbl_Tenant]
GO
