USE [UsersStoriesDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Color] [nvarchar](max) NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contexts]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contexts](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_Contexts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stories]    Script Date: 28/09/2022 07:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stories](
	[Id] [nvarchar](450) NOT NULL,
	[ActorId] [nvarchar](450) NULL,
	[What] [nvarchar](max) NOT NULL,
	[Why] [nvarchar](max) NOT NULL,
	[Order] [int] NOT NULL,
	[Validated] [bit] NOT NULL,
	[SysDate] [datetime2](7) NOT NULL,
	[ContextId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Stories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220202212009_Mg_001', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220202225451_Mg_002', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220202231725_Mg_002_001', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220203032346_Mg_002_002', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220204065323_Mg_002_003', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220204083041_Mg_003', N'5.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220204094747_Mg_003_001', N'5.0.13')
GO
INSERT [dbo].[Actors] ([Id], [Name], [Color]) VALUES (N'29acc724-b9bc-4b96-bf1a-4af7daa8d4b6', N'Praticien', N'info')
GO
INSERT [dbo].[Actors] ([Id], [Name], [Color]) VALUES (N'30f0c851-e685-40ee-bf8c-748ef24b994f', N'Système', N'primary')
GO
INSERT [dbo].[Actors] ([Id], [Name], [Color]) VALUES (N'6b01af33-24fe-4682-8363-dde9438b23d4', N'Administrateur', N'success')
GO
INSERT [dbo].[Actors] ([Id], [Name], [Color]) VALUES (N'6bad77e7-3554-45ad-bcfe-85061bb1bd27', N'Comptable', N'dark')
GO
INSERT [dbo].[Actors] ([Id], [Name], [Color]) VALUES (N'a8de7c07-6f89-41d7-a154-337098e53a86', N'Chef de service Hôpital', N'warning')
GO
INSERT [dbo].[Actors] ([Id], [Name], [Color]) VALUES (N'bc26bafb-3a4b-49c6-93a7-8e8efe3e7e75', N'Testeur', N'dark')
GO
INSERT [dbo].[Actors] ([Id], [Name], [Color]) VALUES (N'E81F4CFB-0AF1-47A3-9785-D18BF013A0D6', N'VB', N'eee')
GO
INSERT [dbo].[Actors] ([Id], [Name], [Color]) VALUES (N'E81F4CFB-0AF1-47A3-9785-D18BF013A0D7', N'VB', N'eee')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'c19517ff-5dc2-4fe8-969e-60d49b752517', N'LastName', N'Ghassan')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c19517ff-5dc2-4fe8-969e-60d49b752517', N'ghassannet@gmail.com', N'GHASSANNET@GMAIL.COM', N'ghassannet@gmail.com', N'GHASSANNET@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEO98PPC7D686/oFBwtGrryEGYFaqNrTHL4Q06TDlliS+TRFhGuyPKzI9XzDULYQSZw==', N'TPZ6ID7GK2HW5EGDHSZ5HMHNUMFAZ7UJ', N'106846c4-ac25-4568-9bcd-80948c6e7b57', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[Contexts] ([Id], [Name], [Order]) VALUES (N'2e387377-79f7-4360-972c-a87b5d5a6cd6', N'Création de compte', 1)
GO
INSERT [dbo].[Contexts] ([Id], [Name], [Order]) VALUES (N'76961126-552d-425a-a9c4-fb0392fa1b3b', N'Connexion', 2)
GO
INSERT [dbo].[Contexts] ([Id], [Name], [Order]) VALUES (N'8c695bd5-cc2c-48fc-a3af-d7a0fa8a072f', N'Tableau de bord', 3)
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'099ffe0b-0621-49af-867d-c8d3cdff5bfb', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'gh', N'hgg', 5, 0, CAST(N'2022-02-04T13:21:40.7670862' AS DateTime2), N'76961126-552d-425a-a9c4-fb0392fa1b3b')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'0f2297a4-e874-4bd2-9dab-902d83fc2f9e', N'a8de7c07-6f89-41d7-a154-337098e53a86', N'gh', N'gh', 10, 0, CAST(N'2022-02-04T13:35:01.5675231' AS DateTime2), N'2e387377-79f7-4360-972c-a87b5d5a6cd6')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'15fefe69-6244-4b34-b2d6-57a3387ebf97', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', 2, 0, CAST(N'2022-02-03T18:42:31.5453823' AS DateTime2), N'76961126-552d-425a-a9c4-fb0392fa1b3b')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'33abd9a1-7ba3-4da7-b16c-4c8ad38a7830', N'6bad77e7-3554-45ad-bcfe-85061bb1bd27', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', 11, 0, CAST(N'2022-09-14T10:57:18.2134007' AS DateTime2), N'76961126-552d-425a-a9c4-fb0392fa1b3b')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'5d9d9316-2ea1-4204-8ccd-a9770accc6b9', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'gh', N'hgg', 4, 0, CAST(N'2022-02-04T13:21:37.1478801' AS DateTime2), N'76961126-552d-425a-a9c4-fb0392fa1b3b')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'6164eb18-1a57-4938-bf65-31e87dea82a7', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', 8, 0, CAST(N'2022-02-04T13:21:45.2486609' AS DateTime2), N'76961126-552d-425a-a9c4-fb0392fa1b3b')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'8ba7bfa3-a457-46df-88fd-721a1de6c1db', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'cliquer sur le lien Renvoyer l''email de confirmation ', N'de recevoir un nouveau email de confirmation', 1, 0, CAST(N'2022-02-03T18:42:16.3742981' AS DateTime2), N'2e387377-79f7-4360-972c-a87b5d5a6cd6')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'9dac0ff8-4d4a-48d7-a3af-0fe7b51721c3', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'gh', N'gh', 3, 0, CAST(N'2022-02-04T13:21:15.6419690' AS DateTime2), N'2e387377-79f7-4360-972c-a87b5d5a6cd6')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'abe7494d-177c-46e4-a492-ae06a357d321', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', 7, 0, CAST(N'2022-02-04T13:21:44.2369191' AS DateTime2), N'76961126-552d-425a-a9c4-fb0392fa1b3b')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'ba4d75d2-8829-430b-a00f-d6646fedc034', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', 9, 0, CAST(N'2022-02-04T13:21:45.7937359' AS DateTime2), N'76961126-552d-425a-a9c4-fb0392fa1b3b')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'dfa63375-2161-42cf-bf1b-ecf0bc1d056b', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', 12, 0, CAST(N'2022-09-14T11:31:54.2779140' AS DateTime2), N'2e387377-79f7-4360-972c-a87b5d5a6cd6')
GO
INSERT [dbo].[Stories] ([Id], [ActorId], [What], [Why], [Order], [Validated], [SysDate], [ContextId]) VALUES (N'f5b9a34d-fdf0-4bf7-8504-f3768d52d5ab', N'6b01af33-24fe-4682-8363-dde9438b23d4', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', N'afin de recevoir un nouveau email de confirmationafin de recevoir un nouveau email de confirmation', 6, 0, CAST(N'2022-02-04T13:21:42.7158325' AS DateTime2), N'76961126-552d-425a-a9c4-fb0392fa1b3b')
GO
ALTER TABLE [dbo].[Contexts] ADD  DEFAULT ((0)) FOR [Order]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Stories]  WITH CHECK ADD  CONSTRAINT [FK_Stories_Actors_ActorId] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stories] CHECK CONSTRAINT [FK_Stories_Actors_ActorId]
GO
ALTER TABLE [dbo].[Stories]  WITH CHECK ADD  CONSTRAINT [FK_Stories_Contexts_ContextId] FOREIGN KEY([ContextId])
REFERENCES [dbo].[Contexts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stories] CHECK CONSTRAINT [FK_Stories_Contexts_ContextId]
GO
