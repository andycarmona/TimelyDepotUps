USE [timessence]
GO

/****** Object:  Table [dbo].[VendorsBillingDept]    Script Date: 22/06/2013 5:32:29 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VendorsBillingDept](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[VendorId] [int] NULL,
	[Beneficiary] [nvarchar](MAX) NULL,
	[BeneficiaryAccountNo] [nvarchar](MAX) NULL,
	[SWIFT] [nvarchar](MAX) NULL,
	[BankName] [nvarchar](MAX) NULL,
	[BankAddress] [nvarchar](MAX) NULL,
) 

GO

SET ANSI_PADDING OFF
GO


