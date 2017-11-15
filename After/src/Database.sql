CREATE DATABASE [OnlineTheater]
GO
USE [OnlineTheater]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/15/2017 4:11:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Status] [int] NOT NULL,
	[StatusExpirationDate] [datetime] NULL,
	[MoneySpent] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movie]    Script Date: 11/15/2017 4:11:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LicensingModel] [int] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchasedMovie]    Script Date: 11/15/2017 4:11:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchasedMovie](
	[PurchasedMovieID] [bigint] IDENTITY(1,1) NOT NULL,
	[MovieID] [bigint] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NULL,
 CONSTRAINT [PK_PurchasedMovie] PRIMARY KEY CLUSTERED 
(
	[PurchasedMovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([CustomerID], [Name], [Email], [Status], [StatusExpirationDate], [MoneySpent]) VALUES (1, N'James Peterson', N'james.peterson@gmail.com', 1, NULL, CAST(16.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Customer] ([CustomerID], [Name], [Email], [Status], [StatusExpirationDate], [MoneySpent]) VALUES (2, N'Michal Samson', N'm.samson@yahoo.com', 2, CAST(N'2018-10-14 01:37:27.000' AS DateTime), CAST(9.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Customer] ([CustomerID], [Name], [Email], [Status], [StatusExpirationDate], [MoneySpent]) VALUES (4, N'Alan Turing 2', N'the.alan@gmail.com', 1, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Customer] ([CustomerID], [Name], [Email], [Status], [StatusExpirationDate], [MoneySpent]) VALUES (5, N'Alan Turing', N'the.alan2@gmail.com', 1, NULL, CAST(1004.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Customer] ([CustomerID], [Name], [Email], [Status], [StatusExpirationDate], [MoneySpent]) VALUES (6, N'Alan Turing', N'the.alan3@gmail.com', 1, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

GO
INSERT [dbo].[Movie] ([MovieID], [Name], [LicensingModel]) VALUES (1, N'The Great Gatsby', 1)
GO
INSERT [dbo].[Movie] ([MovieID], [Name], [LicensingModel]) VALUES (2, N'The Secret Life of Pets', 2)
GO
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchasedMovie] ON 

GO
INSERT [dbo].[PurchasedMovie] ([PurchasedMovieID], [MovieID], [CustomerID], [Price], [PurchaseDate], [ExpirationDate]) VALUES (1, 1, 2, CAST(5.00 AS Decimal(18, 2)), CAST(N'2017-09-16 16:30:05.773' AS DateTime), CAST(N'2017-09-18 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PurchasedMovie] ([PurchasedMovieID], [MovieID], [CustomerID], [Price], [PurchaseDate], [ExpirationDate]) VALUES (2, 2, 2, CAST(4.00 AS Decimal(18, 2)), CAST(N'2017-09-15 15:30:05.773' AS DateTime), NULL)
GO
INSERT [dbo].[PurchasedMovie] ([PurchasedMovieID], [MovieID], [CustomerID], [Price], [PurchaseDate], [ExpirationDate]) VALUES (3, 1, 5, CAST(4.00 AS Decimal(18, 2)), CAST(N'2017-10-07 23:54:22.000' AS DateTime), CAST(N'2017-10-09 23:54:22.000' AS DateTime))
GO
INSERT [dbo].[PurchasedMovie] ([PurchasedMovieID], [MovieID], [CustomerID], [Price], [PurchaseDate], [ExpirationDate]) VALUES (6, 1, 1, CAST(4.00 AS Decimal(18, 2)), CAST(N'2017-10-15 13:26:19.000' AS DateTime), CAST(N'2017-10-17 13:26:19.000' AS DateTime))
GO
INSERT [dbo].[PurchasedMovie] ([PurchasedMovieID], [MovieID], [CustomerID], [Price], [PurchaseDate], [ExpirationDate]) VALUES (7, 1, 1, CAST(4.00 AS Decimal(18, 2)), CAST(N'2017-10-22 16:06:51.000' AS DateTime), CAST(N'2017-10-24 16:06:51.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[PurchasedMovie] OFF
GO
ALTER TABLE [dbo].[PurchasedMovie]  WITH CHECK ADD  CONSTRAINT [FK_PurchasedMovie_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[PurchasedMovie] CHECK CONSTRAINT [FK_PurchasedMovie_Customer]
GO
ALTER TABLE [dbo].[PurchasedMovie]  WITH CHECK ADD  CONSTRAINT [FK_PurchasedMovie_Movie] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movie] ([MovieID])
GO
ALTER TABLE [dbo].[PurchasedMovie] CHECK CONSTRAINT [FK_PurchasedMovie_Movie]
GO
