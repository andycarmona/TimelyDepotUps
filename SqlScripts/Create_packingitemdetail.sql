USE [asidata2013]
GO

/****** Object:  Table [dbo].[packingitemdetail]    Script Date: 21/06/2013 11:13:34 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[packingitemdetail](
	[PackId] [varchar](100) NULL,
	[itemId] [varchar](50) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


