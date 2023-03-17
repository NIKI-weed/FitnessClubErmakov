USE [FitnessClub]
GO

/****** Object:  Table [dbo].[Schedule]    Script Date: 17.03.2023 7:10:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Schedule](
	[IdClient] [int] NOT NULL,
	[IdEmploye] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO

ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Client]
GO

ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Employe] FOREIGN KEY([IdEmploye])
REFERENCES [dbo].[Employe] ([IdEmploye])
GO

ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Employe]
GO


