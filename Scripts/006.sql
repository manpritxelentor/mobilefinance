IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceMaster_tbl_Model]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]'))
ALTER TABLE [dbo].[tbl_FinanceMaster] DROP CONSTRAINT [FK_tbl_FinanceMaster_tbl_Model]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceMaster_tbl_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]'))
ALTER TABLE [dbo].[tbl_FinanceMaster] DROP CONSTRAINT [FK_tbl_FinanceMaster_tbl_Customer]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_FinanceDetails_tbl_FinanceMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_FinanceDetails]'))
ALTER TABLE [dbo].[tbl_FinanceDetails] DROP CONSTRAINT [FK_tbl_FinanceDetails_tbl_FinanceMaster]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Customer_tbl_Picture]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Customer]'))
ALTER TABLE [dbo].[tbl_Customer] DROP CONSTRAINT [FK_tbl_Customer_tbl_Picture]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_CodeMaintain_tbl_Tenant]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_CodeMaintain]'))
ALTER TABLE [dbo].[tbl_CodeMaintain] DROP CONSTRAINT [FK_tbl_CodeMaintain_tbl_Tenant]
GO
/****** Object:  Table [dbo].[tbl_Picture]    Script Date: 12/23/2019 3:38:18 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Picture]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Picture]
GO
/****** Object:  Table [dbo].[tbl_FinanceMaster]    Script Date: 12/23/2019 3:38:18 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_FinanceMaster]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_FinanceMaster]
GO
/****** Object:  Table [dbo].[tbl_FinanceDetails]    Script Date: 12/23/2019 3:38:18 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_FinanceDetails]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_FinanceDetails]
GO
/****** Object:  Table [dbo].[tbl_Customer]    Script Date: 12/23/2019 3:38:18 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Customer]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Customer]
GO
/****** Object:  Table [dbo].[tbl_CodeMaintain]    Script Date: 12/23/2019 3:38:18 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_CodeMaintain]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_CodeMaintain]
GO
/****** Object:  Table [dbo].[tbl_CodeMaintain]    Script Date: 12/23/2019 3:38:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_CodeMaintain]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_CodeMaintain](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Module] [nvarchar](50) NOT NULL,
	[LastNumber] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[Prefix] [nvarchar](50) NULL,
	[Separator] [nvarchar](10) NULL,
	[Padding] [int] NOT NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_tbl_CodeMaintain] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_Customer]    Script Date: 12/23/2019 3:38:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerIdentificationNumber] [nvarchar](128) NOT NULL,
	[PhotoUrl] [nvarchar](max) NULL,
	[FirstName] [nvarchar](200) NULL,
	[FatherName] [nvarchar](max) NULL,
	[Surname] [nvarchar](200) NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[Address3] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Pincode] [nvarchar](max) NULL,
	[Mobile1] [nvarchar](max) NULL,
	[Mobile2] [nvarchar](max) NULL,
	[WhatsappNumber] [nvarchar](max) NULL,
	[PictureId] [int] NULL,
	[AdhaarNumber] [nvarchar](20) NULL,
	[TenantId] [int] NOT NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_tbl_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_FinanceDetails]    Script Date: 12/23/2019 3:38:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_FinanceDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_FinanceDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FinanceMasterId] [int] NOT NULL,
	[ReceivedDate] [date] NOT NULL,
	[ReceivedBy] [nvarchar](128) NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[ReceivedAmount] [decimal](18, 2) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_FinanceDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_FinanceMaster]    Script Date: 12/23/2019 3:38:18 AM ******/
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
	[Duration] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[Guarantor1] [int] NULL,
	[Guarantor2] [int] NULL,
	[StatusId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](128) NULL,
	[IMEI] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_FinanceMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_Picture]    Script Date: 12/23/2019 3:38:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Picture]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Picture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NOT NULL,
	[Extension] [nvarchar](20) NOT NULL,
	[RelativePath] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_Picture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_CodeMaintain_tbl_Tenant]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_CodeMaintain]'))
ALTER TABLE [dbo].[tbl_CodeMaintain]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CodeMaintain_tbl_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[tbl_Tenant] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_CodeMaintain_tbl_Tenant]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_CodeMaintain]'))
ALTER TABLE [dbo].[tbl_CodeMaintain] CHECK CONSTRAINT [FK_tbl_CodeMaintain_tbl_Tenant]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Customer_tbl_Picture]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Customer]'))
ALTER TABLE [dbo].[tbl_Customer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Customer_tbl_Picture] FOREIGN KEY([PictureId])
REFERENCES [dbo].[tbl_Picture] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tbl_Customer_tbl_Picture]') AND parent_object_id = OBJECT_ID(N'[dbo].[tbl_Customer]'))
ALTER TABLE [dbo].[tbl_Customer] CHECK CONSTRAINT [FK_tbl_Customer_tbl_Picture]
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
