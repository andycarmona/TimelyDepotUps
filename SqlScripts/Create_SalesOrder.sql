USE [timessence]
GO

/****** Object:  Table [dbo].[SalesOrder]    Script Date: 22/06/2013 5:32:29 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SalesOrder](
	[SalesOrderId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[SalesOrderNo] [nvarchar](MAX) NULL,
	[SODate] [DateTime] NULL,
	[ShipVia] [nvarchar](MAX) NULL,
	[ShipDate] [DateTime] NULL,
	[TradeId] [int] NULL,
	[CustomerId] [int] NULL,
	[CustomerShiptoId] [int] NULL,
	[CustomerShipLocation] [nvarchar](MAX) NULL,
	[VendorId] [int] NULL,
	[BussinesType] [nvarchar](MAX) NULL,
	[VendorAddress] [nvarchar](MAX) NULL,
	[PurchaseOrderNo] [nvarchar](MAX) NULL,
	[PaymentTerms] [nvarchar](MAX) NULL,
	[PaymentDate] [DateTime] NULL,
	[PaymentAmount] [money] NULL,
	[ShippingHandling] [money] NULL,
	[CreaditCardNo] [nvarchar](MAX) NULL,
	[Note] [nvarchar](MAX) NULL,
	[IsBlindShip] [bit] NULL DEFAULT 0,
) 

GO

SET ANSI_PADDING OFF
GO


