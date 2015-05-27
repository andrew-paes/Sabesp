IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('[dbo].[UsuarioEcorrida]') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE [dbo].[UsuarioEcorrida]
GO




CREATE TABLE [dbo].[UsuarioEcorrida] ( 
	[usuarioEcorridaId] bigint identity(1,1)  NOT NULL,
	[nome] nvarchar(256) NOT NULL,
	[email] nvarchar(256) NOT NULL,
	[senha] nvarchar(50) NOT NULL
)
GO


ALTER TABLE [dbo].[UsuarioEcorrida] ADD CONSTRAINT [PK_UsuarioEcorrida] 
	PRIMARY KEY CLUSTERED ([usuarioEcorridaId])
GO


ALTER TABLE [dbo].[UsuarioEcorrida]
	ADD CONSTRAINT [UQ_UsuarioEcorrida_email] UNIQUE ([email])
GO
