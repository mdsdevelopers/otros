USE [DB_RRHH]
GO
/****** Object:  StoredProcedure [dbo].[BUCO_BuscarPostulacionesPorDocumento]    Script Date: 04/09/2015 21:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUCO_BuscarActasPublicadas]
AS

BEGIN
	SELECT [Comite],
		   [Perfil],
		   [Acta] ,
		   [Descripcion],
		   [Fecha],
		   [Link] 	
  FROM [DB_RRHH].[dbo].[BUCO_ActasPublicadas]
END


