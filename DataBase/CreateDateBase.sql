/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V10.0.2                    */
/* Target DBMS:           MS SQL Server 2016                              */
/* Project file:          ProjectKanBan.dez                               */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Create database script                          */
/* Created on:            2020-04-25 06:33                                */
/* ---------------------------------------------------------------------- */


/* ---------------------------------------------------------------------- */
/* Add table "dbo.Quadro"                                                 */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[Quadro] (
    [QuadroID] INTEGER IDENTITY(1,1) NOT NULL,
    [QuadroDescricao] VARCHAR(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [QuadroDtCriacao] DATETIME NOT NULL,
    [QuadroSituacao] BIT,
    [UsuarioID] INTEGER NOT NULL,
    CONSTRAINT [PK_Quadro] PRIMARY KEY CLUSTERED ([QuadroID])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.Tarefa"                                                 */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[Tarefa] (
    [TarefaID] INTEGER IDENTITY(1,1) NOT NULL,
    [QuadroID] INTEGER NOT NULL,
    [TarefaTitulo] VARCHAR(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [TarefaDescricao] VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [TarefaDtCriacao] DATETIME NOT NULL,
    [SituacaoTarefaID] INTEGER NOT NULL,
    CONSTRAINT [PK_Tarefa] PRIMARY KEY CLUSTERED ([TarefaID])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.SituacaoTarefa"                                         */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[SituacaoTarefa] (
    [SituacaoTarefaID] INTEGER IDENTITY(1,1) NOT NULL,
    [SituacaoTarefaDescricao] VARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CONSTRAINT [PK_SituacaoTarefa] PRIMARY KEY CLUSTERED ([SituacaoTarefaID])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.HistoricoTarefa"                                        */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[HistoricoTarefa] (
    [HistoricoTarefaID] INTEGER IDENTITY(1,1) NOT NULL,
    [HistoricoDtCriacao] DATETIME NOT NULL,
    [TarefaTitulo] VARCHAR(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [TarefaDescricao] VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [SituacaoTarefaID] INTEGER NOT NULL,
    [TarefaID] INTEGER NOT NULL,
    CONSTRAINT [PK_HistoricoTarefa] PRIMARY KEY CLUSTERED ([HistoricoTarefaID])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.Usuario"                                                */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[Usuario] (
    [UsuarioID] INTEGER IDENTITY(1,1) NOT NULL,
    [UsuarioNome] VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [UsuarioEmail] VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [UsuarioSenha] VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [UsuarioDtCadastro] DATETIME NOT NULL,
    [UsuarioDtUltimoAcesso] DATETIME NOT NULL,
    [UsuarioSituacao] BIT NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([UsuarioID])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.Permissao"                                              */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[Permissao] (
    [PermissaoID] INTEGER IDENTITY(1,1) NOT NULL,
    [PermissaoDescricao] VARCHAR(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CONSTRAINT [PK_Permissao] PRIMARY KEY CLUSTERED ([PermissaoID])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "dbo.PermissaoUsuario"                                       */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [dbo].[PermissaoUsuario] (
    [PermissaoUsuarioID] INTEGER IDENTITY(1,1) NOT NULL,
    [UsuarioID] INTEGER NOT NULL,
    [PermissaoID] INTEGER NOT NULL,
    CONSTRAINT [PK_PermissaoUsuario] PRIMARY KEY CLUSTERED ([PermissaoUsuarioID])
)
GO


/* ---------------------------------------------------------------------- */
/* Add foreign key constraints                                            */
/* ---------------------------------------------------------------------- */

GO


ALTER TABLE [dbo].[Quadro] ADD CONSTRAINT [Usuario_Quadro] 
    FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuario] ([UsuarioID])
GO


ALTER TABLE [dbo].[Tarefa] ADD CONSTRAINT [Quadro_Tarefa] 
    FOREIGN KEY ([QuadroID]) REFERENCES [dbo].[Quadro] ([QuadroID])
GO


ALTER TABLE [dbo].[Tarefa] ADD CONSTRAINT [SituacaoTarefa_Tarefa] 
    FOREIGN KEY ([SituacaoTarefaID]) REFERENCES [dbo].[SituacaoTarefa] ([SituacaoTarefaID])
GO


ALTER TABLE [dbo].[HistoricoTarefa] ADD CONSTRAINT [SituacaoTarefa_HistoricoTarefa] 
    FOREIGN KEY ([SituacaoTarefaID]) REFERENCES [dbo].[SituacaoTarefa] ([SituacaoTarefaID])
GO


ALTER TABLE [dbo].[HistoricoTarefa] ADD CONSTRAINT [Tarefa_HistoricoTarefa] 
    FOREIGN KEY ([TarefaID]) REFERENCES [dbo].[Tarefa] ([TarefaID])
GO


ALTER TABLE [dbo].[PermissaoUsuario] ADD CONSTRAINT [Usuario_PermissaoUsuario] 
    FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuario] ([UsuarioID])
GO


ALTER TABLE [dbo].[PermissaoUsuario] ADD CONSTRAINT [Permissao_PermissaoUsuario] 
    FOREIGN KEY ([PermissaoID]) REFERENCES [dbo].[Permissao] ([PermissaoID])
GO

