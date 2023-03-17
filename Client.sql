USE [FitnessClub]
GO

/****** Object:  Table [dbo].[Client]    Script Date: 17.03.2023 7:07:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SecondName] [nvarchar](50) NOT NULL,
	[Patronimic] [nvarchar](50) NULL,
	[Phone] [char](11) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[IdRole] [int] NOT NULL,
	[IdTag] [int] NULL,
	[GenderCode] [nchar](1) NOT NULL,
	[PhotoPath] [varbinary](max) NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IdUser] [int] NULL,
	[BirthdayDate] [date] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Client] ADD  CONSTRAINT [DF_Client_IdRole]  DEFAULT ((1)) FOR [IdRole]
GO

ALTER TABLE [dbo].[Client] ADD  CONSTRAINT [DF_Client_IdTag]  DEFAULT ((1)) FOR [IdTag]
GO

ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_GenderCode] FOREIGN KEY([GenderCode])
REFERENCES [dbo].[GenderCode] ([GenderCode])
GO

ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_GenderCode]
GO

ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO

ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Role]
GO

ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_TagOfClient] FOREIGN KEY([IdTag])
REFERENCES [dbo].[TagOfClient] ([IdTag])
GO

ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_TagOfClient]
GO

ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[UserAuth] ([IdUser])
GO

ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO


