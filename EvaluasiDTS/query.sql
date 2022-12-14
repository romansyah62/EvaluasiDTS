USE [TUGAS_DATA_KANTOR]
GO
/****** Object:  User [mccdts1]    Script Date: 21/09/2022 10:24:17 ******/
CREATE USER [mccdts1] FOR LOGIN [mccdts1] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [mccdts1]
GO
/****** Object:  Table [dbo].[Absensi]    Script Date: 21/09/2022 10:24:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absensi](
	[Id] [int] NOT NULL,
	[Waktu] [datetime] NOT NULL,
	[Id_Karyawan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataKaryawan]    Script Date: 21/09/2022 10:24:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DataKaryawan](
	[Id] [int] NOT NULL,
	[Nama] [varchar](60) NOT NULL,
	[Email] [varchar](60) NULL,
	[JenisKelamin] [varchar](20) NOT NULL,
	[NomorTelepon] [varchar](15) NOT NULL,
	[Agama] [varchar](15) NOT NULL,
	[Alamat] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 21/09/2022 10:24:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[Id_Login] [int] NOT NULL,
	[KataSandi] [varchar](25) NOT NULL,
	[Id_Karyawan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Absensi] ([Id], [Waktu], [Id_Karyawan]) VALUES (1, CAST(N'2022-09-13 08:00:00.000' AS DateTime), 1)
INSERT [dbo].[Absensi] ([Id], [Waktu], [Id_Karyawan]) VALUES (2, CAST(N'2022-09-13 07:45:00.000' AS DateTime), 2)
INSERT [dbo].[Absensi] ([Id], [Waktu], [Id_Karyawan]) VALUES (3, CAST(N'2022-09-13 08:00:00.000' AS DateTime), 3)
INSERT [dbo].[DataKaryawan] ([Id], [Nama], [Email], [JenisKelamin], [NomorTelepon], [Agama], [Alamat]) VALUES (1, N'Agung', N'agung@gmail.com', N'Pria', N'082131233213', N'Islam', N'Jalan Mawar')
INSERT [dbo].[DataKaryawan] ([Id], [Nama], [Email], [JenisKelamin], [NomorTelepon], [Agama], [Alamat]) VALUES (2, N'Banu', N'banu@gmail.com', N'Pria', N'0834623642443', N'Islam', N'Jalan Merak no 5')
INSERT [dbo].[DataKaryawan] ([Id], [Nama], [Email], [JenisKelamin], [NomorTelepon], [Agama], [Alamat]) VALUES (3, N'Cindy', N'cindy@yahoo.com', N'Wanita', N'02832143443', N'Kristen', N'Jalan Kondangan no 1')
INSERT [dbo].[DataKaryawan] ([Id], [Nama], [Email], [JenisKelamin], [NomorTelepon], [Agama], [Alamat]) VALUES (4, N'Dinda', N'dinda@gmail.com', N'Perempuan', N'3218371283', N'Hindu', N'Jalan Kicau')
INSERT [dbo].[Login] ([Id_Login], [KataSandi], [Id_Karyawan]) VALUES (1, N'Sandi1', 1)
INSERT [dbo].[Login] ([Id_Login], [KataSandi], [Id_Karyawan]) VALUES (2, N'SANDIBARU2', 2)
INSERT [dbo].[Login] ([Id_Login], [KataSandi], [Id_Karyawan]) VALUES (3, N'Sandi3', 3)
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__DataKary__A9D1053470FB4F35]    Script Date: 21/09/2022 10:24:18 ******/
ALTER TABLE [dbo].[DataKaryawan] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Absensi]  WITH CHECK ADD FOREIGN KEY([Id_Karyawan])
REFERENCES [dbo].[DataKaryawan] ([Id])
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD FOREIGN KEY([Id_Karyawan])
REFERENCES [dbo].[DataKaryawan] ([Id])
GO
