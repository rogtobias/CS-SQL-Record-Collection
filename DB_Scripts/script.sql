USE [record_collection]
GO
/****** Object:  Table [dbo].[records]    Script Date: 6/6/2017 2:06:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[records](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[artist] [varchar](255) NULL
) ON [PRIMARY]

GO
