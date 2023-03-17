USE [FitnessClub]
GO

/****** Object:  Table [dbo].[Employe]    Script Date: 17.03.2023 7:09:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employe](
	[IdEmploye] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SecondName] [nvarchar](50) NOT NULL,
	[Patronimic] [nvarchar](50) NULL,
	[Phone] [char](11) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[IdRole] [int] NULL,
	[GenderCode] [nchar](1) NULL,
	[PhotoPath] [nvarchar](max) NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IdUser] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IdEmploye] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employe] ADD  CONSTRAINT [DF_Employe_IdRole]  DEFAULT ((1)) FOR [IdRole]
GO

ALTER TABLE [dbo].[Employe]  WITH CHECK ADD  CONSTRAINT [FK_Employe_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[UserAuth] ([IdUser])
GO

ALTER TABLE [dbo].[Employe] CHECK CONSTRAINT [FK_Employe_User]
GO


