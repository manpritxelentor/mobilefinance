USE [MovileErpNew]
GO

/****** Object:  Table [dbo].[tbl_Guarantor]    Script Date: 15-12-2019 04:20:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Guarantor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Identification] [nvarchar](max) NULL,
	[Address1] [nvarchar](max) NOT NULL,
	[Address2] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Pincode] [nvarchar](max) NULL,
	[Mobile1] [nvarchar](max) NULL,
	[Mobile2] [nvarchar](max) NULL,
	[WhatsappNumber] [nvarchar](max) NULL,
	[Aadhar] [nvarchar](max) NULL,
	[PAN] [nvarchar](max) NULL,
	[TenantId] [int] NOT NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_tbl_Guarantor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


