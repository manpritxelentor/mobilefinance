ALTER TABLE [dbo].[tbl_Model] DROP CONSTRAINT [FK_tbl_Model_tbl_Tenant]
GO

ALTER TABLE [dbo].[tbl_Model] DROP CONSTRAINT [FK_tbl_Model_tbl_Brand]
GO

/****** Object:  Table [dbo].[tbl_Model]    Script Date: 12/14/2019 7:36:14 PM ******/
DROP TABLE [dbo].[tbl_Model]
GO

/****** Object:  Table [dbo].[tbl_Model]    Script Date: 12/14/2019 7:36:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Model](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[BrandId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[TenantId] [int] NOT NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](128) NULL,
 CONSTRAINT [PK_tbl_Model] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbl_Model]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Model_tbl_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[tbl_Brand] ([Id])
GO

ALTER TABLE [dbo].[tbl_Model] CHECK CONSTRAINT [FK_tbl_Model_tbl_Brand]
GO

ALTER TABLE [dbo].[tbl_Model]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Model_tbl_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[tbl_Tenant] ([Id])
GO

ALTER TABLE [dbo].[tbl_Model] CHECK CONSTRAINT [FK_tbl_Model_tbl_Tenant]
GO


