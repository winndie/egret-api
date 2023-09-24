USE [DEV_DB]
GO

/****** Object:  Table [dbo].[ColdCallingControlledZone]    Script Date: 21/09/2023 15:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColdCallingControlledZone]') AND type in (N'U'))
DROP TABLE [dbo].[ColdCallingControlledZone]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColdCallingControlledZoneGeometry]') AND type in (N'U'))
DROP TABLE [dbo].[ColdCallingControlledZoneGeometry]
GO

/****** Object:  Table [dbo].[ColdCallingControlledZone]    Script Date: 21/09/2023 15:26:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ColdCallingControlledZone](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ObjectID] [int] NOT NULL,
	[Zones] [nvarchar](100) NOT NULL,
	[Ward] [nvarchar](100) NOT NULL	
	CONSTRAINT PK_ColdCallingControlledZone PRIMARY KEY (ID)
)
GO

CREATE TABLE [dbo].[ColdCallingControlledZoneGeometry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColdCallingControlledZoneID] [int] NOT NULL,
	[GeometryType] [int] NOT NULL,
	[Coordinates] [nvarchar](max) NOT NULL,
	CONSTRAINT PK_ColdCallingControlledZoneGeometry PRIMARY KEY (ID),
	CONSTRAINT FK_ColdCallingControlledZoneGeometry FOREIGN KEY (ColdCallingControlledZoneID) REFERENCES ColdCallingControlledZone(ID)
	ON DELETE CASCADE
)
GO

