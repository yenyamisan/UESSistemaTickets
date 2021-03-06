USE [TicketSystemDB]
GO
/****** Object:  Table [dbo].[ComentariosTicket]    Script Date: 4/11/2018 09:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComentariosTicket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[TicketId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Comentario] [text] NOT NULL,
 CONSTRAINT [PK_ComentariosTicket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 4/11/2018 09:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estatus]    Script Date: 4/11/2018 09:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Estatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EstatusTicketHistory]    Script Date: 4/11/2018 09:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstatusTicketHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TikcetId] [int] NOT NULL,
	[EstatusId] [int] NOT NULL,
	[FechaCambio] [date] NOT NULL,
 CONSTRAINT [PK_EstatusTicketHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prioridad]    Script Date: 4/11/2018 09:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prioridad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Priorida] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 4/11/2018 09:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 4/11/2018 09:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioReporter] [int] NOT NULL,
	[UsuarioAsignado] [int] NULL,
	[PrioridadId] [int] NOT NULL,
	[EstadoActualId] [int] NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[FechaFinalizacion] [date] NULL,
	[Descripcion] [text] NULL,
	[Titulo] [text] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/11/2018 09:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartamentoId] [int] NOT NULL,
	[RolId] [int] NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[Email] [nchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Departamento] ON 

INSERT [dbo].[Departamento] ([Id], [Nombre]) VALUES (1, N'Contabilidad')
INSERT [dbo].[Departamento] ([Id], [Nombre]) VALUES (2, N'Finanzas')
INSERT [dbo].[Departamento] ([Id], [Nombre]) VALUES (3, N'Operaciones')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
SET IDENTITY_INSERT [dbo].[Estatus] ON 

INSERT [dbo].[Estatus] ([Id], [Nombre]) VALUES (1, N'Abierto')
INSERT [dbo].[Estatus] ([Id], [Nombre]) VALUES (2, N'En Progreso')
INSERT [dbo].[Estatus] ([Id], [Nombre]) VALUES (3, N'En Prueba')
INSERT [dbo].[Estatus] ([Id], [Nombre]) VALUES (4, N'Aprobado')
INSERT [dbo].[Estatus] ([Id], [Nombre]) VALUES (5, N'Liberado')
INSERT [dbo].[Estatus] ([Id], [Nombre]) VALUES (6, N'Cerrado')
SET IDENTITY_INSERT [dbo].[Estatus] OFF
SET IDENTITY_INSERT [dbo].[Prioridad] ON 

INSERT [dbo].[Prioridad] ([Id], [Nombre]) VALUES (1, N'Normal')
INSERT [dbo].[Prioridad] ([Id], [Nombre]) VALUES (2, N'Mayor')
INSERT [dbo].[Prioridad] ([Id], [Nombre]) VALUES (3, N'Critico')
INSERT [dbo].[Prioridad] ([Id], [Nombre]) VALUES (4, N'Blocker')
SET IDENTITY_INSERT [dbo].[Prioridad] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (1, N'Admin')
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (2, N'Administrador')
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (3, N'QA Engineer')
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (4, N'Reporter')
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (5, N'Developer')
SET IDENTITY_INSERT [dbo].[Rol] OFF
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([Id], [UsuarioReporter], [UsuarioAsignado], [PrioridadId], [EstadoActualId], [FechaCreacion], [FechaFinalizacion], [Descripcion], [Titulo]) VALUES (1, 1, 2, 2, 1, CAST(N'2018-11-03' AS Date), NULL, N'test t', N'')
INSERT [dbo].[Ticket] ([Id], [UsuarioReporter], [UsuarioAsignado], [PrioridadId], [EstadoActualId], [FechaCreacion], [FechaFinalizacion], [Descripcion], [Titulo]) VALUES (3, 1, 2, 4, 1, CAST(N'2018-11-04' AS Date), NULL, N'test', N'Ticket de prueba')
SET IDENTITY_INSERT [dbo].[Ticket] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [DepartamentoId], [RolId], [Nombres], [Apellidos], [Email], [Alias], [Password], [Active]) VALUES (1, 2, 4, N'Yenn', N'Sandoval', N'yenn.sandoval@gmail.com                           ', N'Yenn', N'MTIzNDU2Nzg=', 0)
INSERT [dbo].[Usuario] ([Id], [DepartamentoId], [RolId], [Nombres], [Apellidos], [Email], [Alias], [Password], [Active]) VALUES (2, 3, 5, N'Arturo', N'salinas', N'arturo.salinas@gmail.com                          ', N'arturo', N'MTIzNDU2Nzg=', 0)
INSERT [dbo].[Usuario] ([Id], [DepartamentoId], [RolId], [Nombres], [Apellidos], [Email], [Alias], [Password], [Active]) VALUES (3, 1, 1, N'Admin', N'Admin', N'admin@gmail.com                                   ', N'admin', N'YWRtaW4=', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[ComentariosTicket]  WITH CHECK ADD  CONSTRAINT [FK_ComentariosTicket_Ticket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([Id])
GO
ALTER TABLE [dbo].[ComentariosTicket] CHECK CONSTRAINT [FK_ComentariosTicket_Ticket]
GO
ALTER TABLE [dbo].[ComentariosTicket]  WITH CHECK ADD  CONSTRAINT [FK_ComentariosTicket_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[ComentariosTicket] CHECK CONSTRAINT [FK_ComentariosTicket_Usuario]
GO
ALTER TABLE [dbo].[EstatusTicketHistory]  WITH CHECK ADD  CONSTRAINT [FK_EstatusTicketHistory_Estatus] FOREIGN KEY([EstatusId])
REFERENCES [dbo].[Estatus] ([Id])
GO
ALTER TABLE [dbo].[EstatusTicketHistory] CHECK CONSTRAINT [FK_EstatusTicketHistory_Estatus]
GO
ALTER TABLE [dbo].[EstatusTicketHistory]  WITH CHECK ADD  CONSTRAINT [FK_EstatusTicketHistory_Ticket] FOREIGN KEY([TikcetId])
REFERENCES [dbo].[Ticket] ([Id])
GO
ALTER TABLE [dbo].[EstatusTicketHistory] CHECK CONSTRAINT [FK_EstatusTicketHistory_Ticket]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Estatus] FOREIGN KEY([EstadoActualId])
REFERENCES [dbo].[Estatus] ([Id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Estatus]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Prioridad] FOREIGN KEY([PrioridadId])
REFERENCES [dbo].[Prioridad] ([Id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Prioridad]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Usuario] FOREIGN KEY([UsuarioReporter])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Usuario]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Usuario1] FOREIGN KEY([UsuarioAsignado])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Usuario1]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Departamento] FOREIGN KEY([DepartamentoId])
REFERENCES [dbo].[Departamento] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Departamento]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([RolId])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
