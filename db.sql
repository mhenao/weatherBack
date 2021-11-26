USE [dataQuerys]
GO
/****** Object:  Table [dbo].[cityInfo]    Script Date: 26/11/2021 6:14:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cityInfo](
	[id_city] [int] IDENTITY(1,1) NOT NULL,
	[city_name] [varchar](50) NULL,
	[city_info] [varchar](50) NULL,
	[created_at] [date] NULL,
 CONSTRAINT [PK_cityInfo] PRIMARY KEY CLUSTERED 
(
	[id_city] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cityInfo] ON 
GO
INSERT [dbo].[cityInfo] ([id_city], [city_name], [city_info], [created_at]) VALUES (1112, N'New york', N'Bogota', CAST(N'2021-10-10' AS Date))
GO
INSERT [dbo].[cityInfo] ([id_city], [city_name], [city_info], [created_at]) VALUES (1113, N'ABU DHABI', N'Bogota', CAST(N'2021-10-10' AS Date))
GO
INSERT [dbo].[cityInfo] ([id_city], [city_name], [city_info], [created_at]) VALUES (1114, N'ADELAIDA', N'Bogota', CAST(N'2021-10-10' AS Date))
GO
INSERT [dbo].[cityInfo] ([id_city], [city_name], [city_info], [created_at]) VALUES (1115, N'New york', N'Bogota', CAST(N'2021-10-10' AS Date))
GO
INSERT [dbo].[cityInfo] ([id_city], [city_name], [city_info], [created_at]) VALUES (1116, N'ABU DHABI', N'Bogota', CAST(N'2021-10-10' AS Date))
GO
SET IDENTITY_INSERT [dbo].[cityInfo] OFF
GO
/****** Object:  StoredProcedure [dbo].[CityList]    Script Date: 26/11/2021 6:14:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CityList]
as
begin
SELECT * FROM cityInfo
end
GO
/****** Object:  StoredProcedure [dbo].[Queryi_add]    Script Date: 26/11/2021 6:14:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Queryi_add]
(
		   @city_name varchar(50),
           @city_info varchar(50),
           @created_at date
)
as
begin
 INSERT INTO [dbo].[cityInfo]
(
		    [city_name],
            [city_info],
            [created_at]
)
     VALUES
(
		   @city_name,
           @city_info,
           @created_at 
)
end


GO
