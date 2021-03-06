USE [DB_RRHH]
GO
/****** Object:  StoredProcedure [dbo].[MODI_Agregar_Imagen_A_Un_Folio_De_Un_Legajo]    Script Date: 12/15/2014 21:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BUCO_BuscarPostulacionesPorDocumento]
	@documento int
AS

BEGIN
	SELECT [Nro Doc]
      ,[Tipo Doc]
      ,[Apellido]
      ,[Nombre]
      ,[Puesto]
      ,[Estado]
      ,[Observacion]
      ,[NombrePDF]
      ,[Cod_perfil]
      ,[Acta]
      ,[Anexo]
  FROM [DB_RRHH].[dbo].[BUCO_Postulaciones]
  WHERE [Nro Doc] =  @documento
END


