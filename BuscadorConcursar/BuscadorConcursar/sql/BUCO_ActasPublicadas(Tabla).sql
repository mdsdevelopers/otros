SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BUCO_ActasPublicadas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comite] [int] NOT NULL,
	[Perfil] [int] NOT NULL,
	[Acta] [int] NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Link] [nvarchar](255) NOT NULL,
) ON [PRIMARY]

GO


