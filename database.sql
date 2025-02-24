USE [PRN231_Group10_SE1701]
GO
ALTER TABLE [dbo].[Table_Food] DROP CONSTRAINT [FK_Table_Food_Table]
GO
ALTER TABLE [dbo].[Table_Food] DROP CONSTRAINT [FK_Table_Food_Food]
GO
ALTER TABLE [dbo].[Table_Food] DROP CONSTRAINT [FK_Table_Food_Booking]
GO
ALTER TABLE [dbo].[Table_Booking] DROP CONSTRAINT [FK_Table_Booking_Table]
GO
ALTER TABLE [dbo].[Table_Booking] DROP CONSTRAINT [FK_Table_Booking_Booking]
GO
ALTER TABLE [dbo].[Table] DROP CONSTRAINT [FK_Table_User1]
GO
ALTER TABLE [dbo].[Table] DROP CONSTRAINT [FK_Table_User]
GO
ALTER TABLE [dbo].[Food] DROP CONSTRAINT [FK_Food_User1]
GO
ALTER TABLE [dbo].[Food] DROP CONSTRAINT [FK_Food_User]
GO
ALTER TABLE [dbo].[Food] DROP CONSTRAINT [FK_Food_Category]
GO
ALTER TABLE [dbo].[Category] DROP CONSTRAINT [FK_Category_User1]
GO
ALTER TABLE [dbo].[Category] DROP CONSTRAINT [FK_Category_User]
GO
ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK_Booking_User2]
GO
ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK_Booking_User1]
GO
ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK_Booking_User]
GO
ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK_Bill_User2]
GO
ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK_Bill_User1]
GO
ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK_Bill_User]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/1/2024 4:30:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Table_Food]    Script Date: 7/1/2024 4:30:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_Food]') AND type in (N'U'))
DROP TABLE [dbo].[Table_Food]
GO
/****** Object:  Table [dbo].[Table_Booking]    Script Date: 7/1/2024 4:30:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_Booking]') AND type in (N'U'))
DROP TABLE [dbo].[Table_Booking]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 7/1/2024 4:30:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table]') AND type in (N'U'))
DROP TABLE [dbo].[Table]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 7/1/2024 4:30:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Food]') AND type in (N'U'))
DROP TABLE [dbo].[Food]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/1/2024 4:30:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 7/1/2024 4:30:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Booking]') AND type in (N'U'))
DROP TABLE [dbo].[Booking]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 7/1/2024 4:30:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bill]') AND type in (N'U'))
DROP TABLE [dbo].[Bill]
GO
USE [master]
GO
/****** Object:  Database [PRN231_Group10_SE1701]    Script Date: 7/1/2024 4:30:58 PM ******/
DROP DATABASE [PRN231_Group10_SE1701]
GO
/****** Object:  Database [PRN231_Group10_SE1701]    Script Date: 7/1/2024 4:30:58 PM ******/
CREATE DATABASE [PRN231_Group10_SE1701]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN231_Group10_SE1701', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PRN231_Group10_SE1701.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN231_Group10_SE1701_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PRN231_Group10_SE1701_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN231_Group10_SE1701].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET RECOVERY FULL 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET  MULTI_USER 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRN231_Group10_SE1701', N'ON'
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET QUERY_STORE = ON
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PRN231_Group10_SE1701]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 7/1/2024 4:30:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[booked_user_id] [int] NULL,
	[total_price] [float] NULL,
	[booked_time] [datetime] NULL,
	[created_staff_id] [int] NULL,
	[paid_time] [datetime] NULL,
	[updated_staff_id] [int] NULL,
	[status] [tinyint] NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 7/1/2024 4:30:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[booked_user_id] [int] NULL,
	[eating_time] [datetime] NULL,
	[total_number_of_people] [int] NULL,
	[total_number_of_table] [int] NULL,
	[created_time] [datetime] NULL,
	[created_user_id] [int] NULL,
	[updated_time] [datetime] NULL,
	[updated_user_id] [int] NULL,
	[status] [tinyint] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/1/2024 4:30:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[description] [nvarchar](500) NULL,
	[created_time] [datetime] NULL,
	[created_user_id] [int] NULL,
	[updated_time] [datetime] NULL,
	[updated_user_id] [int] NULL,
	[status] [tinyint] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 7/1/2024 4:30:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[description] [nvarchar](500) NULL,
	[price] [float] NULL,
	[category_id] [int] NULL,
	[created_time] [datetime] NULL,
	[created_user_id] [int] NULL,
	[updated_time] [datetime] NULL,
	[updated_user_id] [int] NULL,
	[status] [tinyint] NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 7/1/2024 4:30:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[number] [int] NULL,
	[description] [nvarchar](500) NULL,
	[created_time] [datetime] NULL,
	[created_user_id] [int] NULL,
	[updated_time] [datetime] NULL,
	[updated_user_id] [int] NULL,
	[status] [tinyint] NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Booking]    Script Date: 7/1/2024 4:30:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Booking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[table_id] [int] NULL,
	[booking_id] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_Table_Booking] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Food]    Script Date: 7/1/2024 4:30:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[table_id] [int] NULL,
	[food_id] [int] NULL,
	[booking_id] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_Table_Food] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/1/2024 4:30:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](200) NULL,
	[phone] [nvarchar](50) NULL,
	[gmail] [nvarchar](200) NULL,
	[password] [nvarchar](50) NULL,
	[address] [nvarchar](200) NULL,
	[role] [int] NULL,
	[created_time] [datetime] NULL,
	[updated_time] [datetime] NULL,
	[status] [tinyint] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [booked_user_id], [total_price], [booked_time], [created_staff_id], [paid_time], [updated_staff_id], [status]) VALUES (1, 11, 1750, CAST(N'2024-06-30T23:28:36.823' AS DateTime), 2, CAST(N'2024-07-01T08:37:08.463' AS DateTime), 2, 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([id], [booked_user_id], [eating_time], [total_number_of_people], [total_number_of_table], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (4, 10, CAST(N'2024-07-30T08:49:58.797' AS DateTime), 12, 2, CAST(N'2024-06-30T15:50:54.523' AS DateTime), 2, NULL, NULL, 0)
INSERT [dbo].[Booking] ([id], [booked_user_id], [eating_time], [total_number_of_people], [total_number_of_table], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (5, 11, CAST(N'2024-07-20T09:44:17.283' AS DateTime), 8, 2, CAST(N'2024-06-30T15:55:35.770' AS DateTime), 2, CAST(N'2024-06-30T16:45:56.660' AS DateTime), 2, 1)
INSERT [dbo].[Booking] ([id], [booked_user_id], [eating_time], [total_number_of_people], [total_number_of_table], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (6, 12, CAST(N'2024-07-18T11:08:53.567' AS DateTime), 2, 1, CAST(N'2024-06-30T18:09:51.040' AS DateTime), 2, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (1, N'Món khai vị', N'Món khai vị là những món ăn nhẹ được dùng để mở đầu bữa ăn chính, thường có tính tinh tế và hấp dẫn về hương vị. Chúng thường được chế biến từ những nguyên liệu đơn giản như rau củ, hải sản nhỏ, hoặc các món nhẹ như pate, xúc xích. Món khai vị không chỉ làm tăng sự hấp dẫn của bữa ăn mà còn giúp tiếp thêm năng lượng cho cơ thể trước khi vào bữa chính.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (2, N'Món súp', N'Món súp là một món ăn nóng hoặc lạnh, thường được chế biến từ nước dùng cùng các loại thực phẩm như thịt, cá, rau củ, và gia vị. Súp thường được dùng như một món khai vị hoặc món chính, mang đến cảm giác ấm áp và bổ dưỡng. Với đa dạng về hương vị và thành phần, súp là một phần không thể thiếu trong ẩm thực của nhiều nền văn hóa trên thế giới.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (3, N'Món xa-lát', N'Món xa lát là một món ăn thường được chế biến từ các loại rau củ tươi, hoặc cả thịt và phô mai, được cắt mỏng và xếp lớp lên nhau. Món này thường được phục vụ như một món khai vị nhẹ hoặc một phần trong bữa ăn chính. Xa lát có thể được trang trí mỹ quan và thường có hương vị phong phú, làm hài lòng cả về thị giác và vị giác.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (4, N'Món Âu', N'Món Âu là thuật ngữ chỉ đến các món ăn có nguồn gốc từ châu Âu, với đặc trưng là sự kết hợp tinh tế giữa các nguyên liệu phổ biến như thịt, cá, rau củ và sữa. Các món ăn Âu thường có phong cách chế biến phức tạp và được chế biến theo nhiều cách khác nhau, từ nấu, xào, nướng đến chiên và hấp. Âu chủ yếu mang đậm nét bền vững và hương vị truyền thống, với nhiều món ăn nổi tiếng như pizza, pasta, steak, và đồ ăn tráng miệng như bánh tart và pudding.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (5, N'Bánh pizza / Mỳ Ý', N'Bánh pizza: Món bánh nướng có nguồn gốc từ Ý, với đế bánh mỏng, sốt cà chua và phô mai, thường được trang trí với các loại nhân như thịt, rau củ và gia vị. Mỳ Ý: Mỳ là món ăn được làm từ bột mỳ và nước, có nhiều hình dạng như spaghetti, penne, và được kết hợp với nhiều loại sốt và nguyên liệu như thịt, hải sản và rau củ.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (6, N'Món chính', N'"Món chính" là món ăn quan trọng trong bữa ăn chính của một bữa tiệc hoặc bữa ăn hằng ngày. Thường có thể là thịt, cá, gia cầm hoặc một món chay chủ yếu, thường được kèm theo các món phụ như cơm, mỳ, hoặc khoai tây. Món chính thường mang tính năng cơ bản của bữa ăn và thường được chuẩn bị với các phương pháp nấu như nướng, xào, hầm, hoặc chiên.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (7, N'Món nướng', N'"Món nướng" là các món ăn được chế biến bằng phương pháp nướng, thường là trên lửa than, lò nướng hoặc grill. Các nguyên liệu như thịt, cá, gia cầm, rau củ hoặc đồ biển được nướng với các gia vị và dầu mỡ để tăng hương vị và độ giòn. Món nướng thường mang đậm hương vị đặc trưng của phương pháp chế biến này và thường được phục vụ nóng hổi, là một món ăn phổ biến trong nhiều nền văn hóa ẩm thực trên thế giới.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (8, N'Món Á', N'"Món Á" là các món ăn có nguồn gốc từ châu Á, bao gồm đa dạng các món ăn từ các quốc gia như Trung Quốc, Nhật Bản, Hàn Quốc, Thái Lan, Ấn Độ và nhiều quốc gia khác trong khu vực này. Món Á thường có sự đa dạng về hương vị, từ món ăn nóng đến món ăn lạnh, từ các món canh, món nước cho đến các món xào, hầm, nướng. Các nguyên liệu chính thường là gạo, đậu, thịt, cá, rau củ và gia vị đặc trưng như đậu phụng, gia vị nghiền và dầu ăn.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (9, N'Món địa phương', N'"Món địa phương Việt Nam" là các món ăn mang đậm bản sắc văn hóa và ẩm thực của từng vùng miền trong nước. Với sự đa dạng địa lý và khí hậu, mỗi vùng miền Việt Nam có những món ăn đặc trưng riêng, từ món mặn đến món ngọt, từ món chính đến món khai vị.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (10, N'Món tráng miệng', N'"Món tráng miệng" là các món ăn nhẹ thường được dùng sau bữa chính để làm dịu đi vị ngọt trong miệng hoặc để làm kết thúc bữa ăn một cách ngọt ngào. Những món này thường có tính chất trang trí cao và thường được làm từ các thành phần như trái cây, socola, kem, bánh ngọt, pudding, hoặc các loại bánh nhỏ như tart, bánh quy. Món tráng miệng còn được xem là một phần không thể thiếu của các bữa tiệc và thường mang đến cảm giác ngon lành và thỏa mãn cho người thưởng thức.', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (11, N'Món test', NULL, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 0)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (12, N'string', N'string', CAST(N'2024-06-28T11:16:12.983' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (13, N'eee', N'eee', CAST(N'2024-06-28T11:20:23.183' AS DateTime), 1, CAST(N'2024-07-01T09:41:29.603' AS DateTime), 1, 0)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (14, N'qqqq', N'qqqq', CAST(N'2024-06-28T11:21:58.457' AS DateTime), 1, CAST(N'2024-06-28T11:22:50.977' AS DateTime), 1, 0)
INSERT [dbo].[Category] ([id], [name], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (16, N'aaa', N'cccc', CAST(N'2024-07-01T09:34:54.460' AS DateTime), 1, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (1, N'Xa-lát cà chua bi Đà Lạt', N'"Xà lách cà chua bi Đà Lạt" là một món salad phổ biến tại Việt Nam, thường được làm từ rau xà lách tươi, cà chua bi (hay còn gọi là cà chua dẹt), và các loại rau củ khác như dưa leo, cà rốt. Món này thường được trang trí bằng hạt điều rang và được kèm theo sốt mayonnaise nhẹ nhàng. Xà lách cà chua bi Đà Lạt mang đến hương vị tươi mới, giòn rụm và thường được dùng như một món khai vị hoặc món ăn nhẹ trước bữa chính.', 210, 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (2, N'Xa-lát đậu gà', N'Xà lách đậu gà là món salad từ rau xà lách và đậu gà, thường được trang trí với rau củ và hạt rang, kèm sốt vinaigrette hoặc mayonnaise nhẹ nhàng. Món này mang đến hương vị giòn rụm và thích hợp làm món khai vị hoặc nhẹ trước bữa chính.', 195, 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (3, N'Nem cuốn tôm', N'Nem cuốn tôm là món ăn truyền thống Việt Nam, được làm từ tôm tươi, rau sống và bún (hoặc bánh tráng) được cuốn trong lá rau thơm như rau sống và lá chua. Món này thường được ăn kèm với nước chấm ngọt chua hoặc nước mắm pha. Nem cuốn tôm thường mang đến hương vị tươi mát và là món ăn nhẹ phổ biến trong ẩm thực Việt Nam.', 190, 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (4, N'Súp nấm', N'Súp nấm là một món súp được chế biến từ nấm và các nguyên liệu khác như hành tây, thịt gà hoặc nấm. Món súp này thường có hương vị thơm ngon và bổ dưỡng, phù hợp để làm món khai vị hoặc món ăn nhẹ trong bữa ăn.





', 180, 2, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (5, N'Xa-lát đu đủ', N'Xà lách đu đủ là một món salad được làm từ xà lách và đu đủ. Món này thường được trang trí với các loại rau củ khác như cà rốt, dưa chuột và có thể được kèm sốt vinaigrette hoặc các loại sốt khác như mayonnaise. Xà lách đu đủ mang đến hương vị giòn ngon và phong phú, thường được dùng làm món khai vị hoặc món ăn nhẹ.', 190, 3, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (6, N'Xa-lát Caesar Kiểu Truyền Thống', N'Xà lách Caesar kiểu truyền thống là một món salad nổi tiếng có nguồn gốc từ khách sạn Caesar ở thành phố Tijuana, Mexico. Món này bao gồm xà lách Romaine, sốt Caesar (gồm trứng, dầu olive, tỏi, phô mai Parmesan, nước cốt chanh và gia vị), bánh mì nướng thành vòng cắt nhỏ (crouton), và thường được thêm vào thịt gà nướng hoặc tôm. Salad được trang trí với phô mai Parmesan và tiêu.', 210, 3, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (7, N'Xa-lát Tổng Hợp', N'Xà lách tổng hợp là một món salad phổ biến được làm từ sự kết hợp của nhiều loại xà lách và các nguyên liệu khác như rau củ, hạt điều, trái cây, phô mai, thịt hoặc hải sản. Món này thường được trang trí với các loại sốt như vinaigrette, mayonnaise hoặc sốt hoa quả để tạo nên hương vị đa dạng và hấp dẫn. Xà lách tổng hợp là lựa chọn phổ biến cho bữa ăn nhẹ hoặc món khai vị trong các bữa tiệc và nhà hàng.





', 230, 3, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (8, N'Bánh Kẹp Gà Chiên Giòn hoặc Bít Tết', N'Bánh kẹp gà chiên giòn: Miếng gà chiên giòn giữa hai lát bánh mì, thường kèm rau xà lách và sốt. Bít tết: Miếng thăn bò nướng nóng, thường đi kèm với khoai tây chiên và rau xà lách.', 320, 4, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (9, N'Bánh Kẹp Club Truyền Thống', N'Bánh kẹp Club truyền thống là một loại sandwich có ba tầng bánh mì, nằm giữa là lớp thịt gà hoặc thịt lợn nướng, cùng với rau xà lách, cà chua, bơ xịn, và thường được phục vụ với thêm sốt mayonnaise.





', 290, 4, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (10, N'Bánh Burger Phô Mai Truyền Thống', N'Bánh burger phô mai truyền thống là một loại bánh burger gồm bánh mì brioche hoặc bánh mì hamburger, thịt bò viên nướng hoặc thịt bò xay, phô mai, rau xà lách, cà chua, hành tây và sốt mayonnaise hoặc sốt hành tây.', 390, 4, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (11, N'Bò Wagyu Hầm Mỳ Pappardelle', N'Bò Wagyu hầm mỳ Pappardelle là một món ăn sang trọng và ngon miệng, thường được làm từ thịt bò Wagyu ủ hầm cùng với mỳ Pappardelle, một loại mỳ Ý rộng và dày. Món này thường được chế biến với sốt hầm nấm, rau thơm và phô mai Parmesan để tăng thêm hương vị.', 310, 5, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (12, N'Mì Sợi Dẹt Sốt Kem', N'Mì sợi dẹt sốt kem là một món ăn có nguồn gốc từ Ý, gồm mỳ sợi dẹt (như fettuccine) được kết hợp với sốt kem. Sốt kem thường được làm từ sữa, bơ và phô mai Parmesan, tạo nên hương vị béo ngậy và mịn màng. Món này thường được ăn kèm với các loại thực phẩm như thịt gà, tôm hoặc nấm để tăng thêm độ phong phú và bổ dưỡng.





', 260, 5, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (13, N'Mỳ Ống Rigatoni với Nấm và Rau Chân Vịt', N'Mỳ ống Rigatoni với nấm và rau chân vịt là một món ăn Ý truyền thống, sử dụng mỳ Rigatoni (mỳ ống ngắn và rộng) kết hợp với nấm và rau chân vịt. Món này thường được nấu cùng với sốt cà chua hoặc sốt kem, có thể được gia vị bằng tỏi, hành tây và phô mai Parmesan để tăng thêm hương vị.', 280, 5, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (14, N'Bánh Pizza Chorizo', N'Bánh pizza chorizo là một loại pizza có nguồn gốc từ Tây Ban Nha, nổi tiếng với sự kết hợp của chorizo - loại xúc xích Tây Ban Nha có vị cay nồng đặc trưng, với sốt cà chua, phô mai và các loại rau khác như cà chua, hành tây, và húng quế. Món này mang đến hương vị đậm đà và thường được nướng trên lò nhiệt cao để tạo ra lớp vỏ giòn và nền pizza thơm ngon.', 260, 5, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (15, N'Bánh Pizza Hải Sản', N'Bánh pizza hải sản là một loại pizza được làm từ vỏ bánh pizza được phết sốt cà chua, sau đó được trang trí với các loại hải sản như tôm, mực, sò điệp, và các loại cá như tôm hùm, cá hồi hoặc cá ngừ. Thường thêm vào là rau thơm như rau thơm, tỏi, hành tây và phô mai.', 260, 5, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (16, N'Bánh Pizza 4 Loại Phô Mai', N'Bánh pizza 4 loại phô mai là một phiên bản đặc biệt của pizza được phủ đầy với bốn loại phô mai khác nhau. Thông thường, bánh pizza này sẽ có sự kết hợp của phô mai như Mozzarella, Parmesan, Cheddar, và Provolone. Mỗi loại phô mai mang đến một hương vị đặc trưng và cộng thêm lớp phủ này thường làm cho bánh pizza rất béo và thơm ngon.', 260, 5, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (17, N'Tôm Nha Trang Áp Chảo', N'Tôm Nha Trang áp chảo là một món ăn phổ biến và ngon miệng, với tôm tươi từ vùng biển Nha Trang được chế biến bằng cách áp chảo nhanh với dầu và gia vị nhẹ nhàng như tỏi, ớt và muối. Món này thường được dùng như một món khai vị hoặc món chính trong các bữa ăn gia đình hoặc nhà hàng.





', 390, 6, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (18, N'Bít Tết Cừu Úc Nướng', N'Bít tết cừu Úc nướng là món ăn sang trọng và ngon miệng, được làm từ thịt cừu Úc nướng nóng. Thịt cừu Úc thường có vị thơm đặc trưng và thịt mềm mại. Món bít tết này thường được phục vụ với rau xà lách, cà chua, khoai tây nướng và sốt nấm hoặc sốt tiêu đen để tăng thêm hương vị.', 490, 6, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (19, N'Gà Thả Vườn Chiên Bơ Sữa', N'Gà thả vườn chiên bơ sữa là một món ăn ngon và phổ biến, thường được chế biến từ miếng thịt gà thả vườn. Thịt gà sau khi được chiên giòn với bột chiên bột nghiền và phủ bơ sữa lên trên. Món này thường được phục vụ với rau xà lách, cà chua, hoặc khoai tây nướng, tạo nên hương vị thơm ngon và bổ dưỡng.', 280, 6, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (20, N'Phi Lê Cá Hồi Sapa Nướng', N'Phi lê cá hồi Sapa nướng là một món ăn đặc biệt, được chế biến từ phi lê cá hồi tươi từ vùng Sapa. Cá hồi thường được nướng trên lò than hoặc lò nướng với gia vị nhẹ nhàng như muối, tiêu và dầu olive để giữ được hương vị tự nhiên của cá. Món này thường được dùng kèm với rau xà lách, cà chua và sốt chanh để tăng thêm hương vị và phong phú cho bữa ăn.', 430, 7, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (21, N'Sườn Bò Úc Cao Cấp', N'Sườn bò Úc cao cấp là một món ăn thịt nổi tiếng, được làm từ sườn bò nhập khẩu từ Úc, thường là loại thịt có chất lượng cao và mềm mại. Sườn bò Úc thường được nướng hoặc chiên trên lò than, để giữ được hương vị tự nhiên và độ mềm của thịt. Món này thường được phục vụ với các món phụ như khoai tây nướng, rau xà lách và sốt tiêu đen hoặc sốt nấm để làm tăng thêm hương vị và trải nghiệm ẩm thực.





', 920, 7, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (22, N'Sườn Nướng L.A', N'Sườn nướng L.A là một món ăn phổ biến trong ẩm thực, thường là sườn heo hoặc sườn bò được nướng trên lò than hoặc lò nướng với các gia vị như tỏi, tiêu và gia vị đặc trưng. Món này thường có hương vị đậm đà và thường được dùng kèm với các loại sốt như sốt BBQ hoặc sốt tiêu đen, cùng với rau xà lách, khoai tây nướng và các loại rau khác.





', 420, 8, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (23, N'Cơm Trộn Hàn Quốc', N'Cơm trộn Hàn Quốc được gọi là "Bibimbap", là một món ăn truyền thống của Hàn Quốc. Món này bao gồm cơm trắng nóng phủ lên trên các loại rau xà lách, rau cải, rau muống, cà rốt, dưa chuột, rau húng và ớt chuông, thường có trứng chiên (hoặc trứng sống), thịt bò hoặc thịt heo nướng và sốt gochujang (một loại tương ớt Hàn Quốc). Món này thường được trộn đều trước khi ăn, tạo nên hương vị cân bằng giữa các nguyên liệu tươi ngon và gia vị đậm đà.', 280, 8, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (24, N'Cà Ri Chay Ấn Độ', N'Cà ri chay Ấn Độ là một món ăn chay phổ biến trong ẩm thực Ấn Độ. Món này được làm từ rau củ như khoai tây, cà rốt, cà chua và đậu hũ, nấu trong nước dừa và gia vị như hạt tiêu, ớt và gia vị cà ri. Món ăn này thường được dùng kèm với cơm hoặc bánh mì để tận hưởng hương vị thơm ngon và bổ dưỡng của các loại rau và gia vị.', 220, 8, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (25, N'Palak Paneer Truyền Thống', N'Palak Paneer là một món ăn truyền thống của Ấn Độ, được làm từ sự kết hợp giữa rau cải xanh (spinach) và paneer (loại phô mai Ấn Độ), nấu với các gia vị như tỏi, gừng, hạt mùi, ớt và cà ri. Món này có hương vị đậm đà, bổ dưỡng và thường được dùng kèm với cơm hoặc bánh mì naan. Palak Paneer là một lựa chọn phổ biến trong ẩm thực chay và có thể đi kèm với các món khác như dal (món súp đậu) và raita (món salad chua ngọt).





', 260, 8, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (26, N'Cà Ri Đậu Ấn Độ', N'Cà ri đậu là một món ăn Ấn Độ phổ biến và thường được làm từ đậu (thường là đậu hũ) và nấu với nước dừa và các gia vị như hạt tiêu, ớt và gia vị cà ri. Món ăn này có hương vị đậm đà và thường được dùng kèm với cơm hoặc bánh mì để tận hưởng hương vị thơm ngon và bổ dưỡng của đậu và các gia vị.





', 260, 8, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (27, N'Phở Cuốn', N'Phở cuốn là một món ăn Việt Nam ngon và phổ biến, gồm những lớp bánh phở mỏng được cuốn với thịt bò tái, rau sống như rau thơm, ngò và giá, cùng với bún, ngó sen, tôm và thịt luộc. Món ăn này thường được ngâm trong nước mắm chua ngọt và được dùng kèm với nước chấm pha chế từ nước mắm, đường, chanh, tỏi và ớt.', 190, 9, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (28, N'Nem Rán', N'Nem rán là một món ăn phổ biến trong ẩm thực Việt Nam, gồm những lớp bánh mỏng cuốn với thịt bò tái, rau sống như rau thơm





', 190, 9, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (29, N'Phở Bò', N'Phở bò là một món ăn truyền thống của Việt Nam, là sự kết hợp hài hòa giữa sợi phở (một loại mỳ dai và mỏng), nước dùng làm từ xương bò và các gia vị như hành, gừng, hạt điều, đinh hương, quế, hạt nêm, và nước mắm, thịt bò.





', 240, 9, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (30, N'Bún Chả', N'Bún chả là một món ăn truyền thống của Việt Nam, bao gồm những miếng thịt nướng (thường là thịt lợn) và nem nướng, được đặt trên một đĩa có chứa nước mắm pha chế từ nước mắm, đường, chanh, tỏi và ớt, thường được dùng kèm với bún (mỳ sợi), rau sống như rau thơm, xà lách, rau sống, rau thơm và giá.', 320, 9, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (31, N'Phở Xào', N'Phở xào là một món ăn phổ biến trong ẩm thực Việt Nam, thường được làm từ sợi phở xào chung với thịt bò hoặc thịt gà, rau củ như cà rốt, cải thảo, hành tây và gia vị như tỏi, ớt và sốt xì dầu. Món này thường có hương vị đậm đà và được dùng kèm với rau thơm và gia vị như tiêu, chanh và ớt.', 190, 9, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (32, N'Bánh Tart Sô-cô-la Thăng Long', N'Bánh tart sô-cô-la là một loại bánh có vỏ bánh thường là bột mì và bơ, được nhồi với nhân sô-cô-la béo ngậy và sau đó nướng chín. Bánh tart sô-cô-la thường có vị ngọt, béo và thơm ngon từ sô-cô-la, và thường được ăn như một món tráng miệng hoặc trong các buổi tiệc.





', 200, 10, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (33, N'Bánh Phô Mai Chanh Leo', N'Bánh phô mai chanh leo là một món tráng miệng ngọt ngào và sảng khoái. Bánh thường gồm lớp vỏ bánh sủi bọt phủ đầy vị chanh leo tươi mát, được kết hợp với lớp nhân phô mai béo ngậy. Món này thường có hương vị cân bằng giữa chua ngọt và thường được thưởng thức trong những dịp đặc biệt hoặc làm món tráng miệng sau bữa ăn.', 200, 10, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (34, N'Hoa Quả Theo Mùa', N'Hoa quả theo mùa là những loại trái cây được thu hoạch và bán vào thời điểm mùa vụ chính của chúng. Ví dụ, ở Bắc Bán cảnh, quả Mít và Dâu tây thường được thu hoạch vào mùa xuân và mùa hè, trong khi quả Thanh long và Chôm chôm thường được thu hoạch vào mùa hè và mùa thu', 240, 10, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 1)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (35, N'Test', NULL, 500, 2, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, 0)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (37, N'test', N'string', 0, 1, CAST(N'2024-06-28T17:00:31.060' AS DateTime), 1, NULL, NULL, 0)
INSERT [dbo].[Food] ([id], [name], [description], [price], [category_id], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (38, N'ttt', N'tttt', 111, 13, CAST(N'2024-07-01T09:57:24.967' AS DateTime), 1, CAST(N'2024-07-01T10:04:36.710' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (1, 1, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (2, 2, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (3, 3, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (4, 4, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (5, 5, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (6, 6, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (7, 7, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (8, 8, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (9, 9, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (10, 10, N'Bàn 6 người lớn ngồi', CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Table] ([id], [number], [description], [created_time], [created_user_id], [updated_time], [updated_user_id], [status]) VALUES (11, 11, N'string', CAST(N'2024-07-01T15:53:39.443' AS DateTime), 1, CAST(N'2024-07-01T16:02:07.620' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_Booking] ON 

INSERT [dbo].[Table_Booking] ([id], [table_id], [booking_id], [status]) VALUES (7, 4, 5, 2)
INSERT [dbo].[Table_Booking] ([id], [table_id], [booking_id], [status]) VALUES (8, 8, 5, 1)
INSERT [dbo].[Table_Booking] ([id], [table_id], [booking_id], [status]) VALUES (9, 2, 6, 1)
SET IDENTITY_INSERT [dbo].[Table_Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_Food] ON 

INSERT [dbo].[Table_Food] ([id], [table_id], [food_id], [booking_id], [status]) VALUES (1, 8, 1, 5, 1)
INSERT [dbo].[Table_Food] ([id], [table_id], [food_id], [booking_id], [status]) VALUES (2, 8, 5, 5, 1)
INSERT [dbo].[Table_Food] ([id], [table_id], [food_id], [booking_id], [status]) VALUES (3, 8, 9, 5, 0)
INSERT [dbo].[Table_Food] ([id], [table_id], [food_id], [booking_id], [status]) VALUES (4, 8, 15, 5, 1)
INSERT [dbo].[Table_Food] ([id], [table_id], [food_id], [booking_id], [status]) VALUES (5, 8, 18, 5, 1)
INSERT [dbo].[Table_Food] ([id], [table_id], [food_id], [booking_id], [status]) VALUES (6, 8, 11, 5, 1)
SET IDENTITY_INSERT [dbo].[Table_Food] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [fullname], [phone], [gmail], [password], [address], [role], [created_time], [updated_time], [status]) VALUES (1, N'Admin', N'0123456789', N'admin@gmail.com', N'123', N'Hà Nội', 1, CAST(N'2024-06-10T08:19:46.900' AS DateTime), CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1)
INSERT [dbo].[User] ([id], [fullname], [phone], [gmail], [password], [address], [role], [created_time], [updated_time], [status]) VALUES (2, N'Trang', N'0123456777', N'trang@gmail.com', N'123', N'Hà Nội', 0, CAST(N'2024-06-10T08:19:46.900' AS DateTime), CAST(N'2024-07-01T09:26:59.590' AS DateTime), 1)
INSERT [dbo].[User] ([id], [fullname], [phone], [gmail], [password], [address], [role], [created_time], [updated_time], [status]) VALUES (3, N'Minh Hoàng', N'0123456777', N'minhhoang@gmail.com', N'123', N'Thái Nguyên', 0, CAST(N'2024-06-10T08:19:46.900' AS DateTime), CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1)
INSERT [dbo].[User] ([id], [fullname], [phone], [gmail], [password], [address], [role], [created_time], [updated_time], [status]) VALUES (4, N'Nguyễn Hoàng', N'0123456678', N'nguyenhoang@gmail.com', N'123', N'Hưng Yên', 0, CAST(N'2024-06-10T08:19:46.900' AS DateTime), CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1)
INSERT [dbo].[User] ([id], [fullname], [phone], [gmail], [password], [address], [role], [created_time], [updated_time], [status]) VALUES (5, N'Đức Long', N'0123554678', N'duclong@gmail.com', N'123', N'Hà Nam', 0, CAST(N'2024-06-10T08:19:46.900' AS DateTime), CAST(N'2024-06-10T08:19:46.900' AS DateTime), 1)
INSERT [dbo].[User] ([id], [fullname], [phone], [gmail], [password], [address], [role], [created_time], [updated_time], [status]) VALUES (6, N'Trang Quỳnh', N'0123654421', N'trangquynh@gmail.com', N'123', N'Quảng Ninh', 0, CAST(N'2024-06-10T08:19:46.900' AS DateTime), CAST(N'2024-06-10T08:19:46.900' AS DateTime), 0)
INSERT [dbo].[User] ([id], [fullname], [phone], [gmail], [password], [address], [role], [created_time], [updated_time], [status]) VALUES (10, N'lê thị an', N'0555555555', NULL, NULL, NULL, 2, CAST(N'2024-06-30T15:50:54.277' AS DateTime), NULL, 1)
INSERT [dbo].[User] ([id], [fullname], [phone], [gmail], [password], [address], [role], [created_time], [updated_time], [status]) VALUES (11, N'nguyễn hoài thu', N'0444444444', NULL, NULL, NULL, 2, CAST(N'2024-06-30T15:55:35.570' AS DateTime), NULL, 1)
INSERT [dbo].[User] ([id], [fullname], [phone], [gmail], [password], [address], [role], [created_time], [updated_time], [status]) VALUES (12, N'diệp ngọc hân', N'0333666888', N'han@gmail.com', NULL, N'string', 0, CAST(N'2024-06-30T18:09:50.920' AS DateTime), CAST(N'2024-07-01T16:22:38.900' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_User] FOREIGN KEY([booked_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_User]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_User1] FOREIGN KEY([created_staff_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_User1]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_User2] FOREIGN KEY([updated_staff_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_User2]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_User] FOREIGN KEY([booked_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_User]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_User1] FOREIGN KEY([created_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_User1]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_User2] FOREIGN KEY([updated_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_User2]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_User] FOREIGN KEY([created_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_User]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_User1] FOREIGN KEY([updated_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_User1]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food_Category]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food_User] FOREIGN KEY([created_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food_User]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food_User1] FOREIGN KEY([updated_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food_User1]
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [FK_Table_User] FOREIGN KEY([created_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK_Table_User]
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [FK_Table_User1] FOREIGN KEY([updated_user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK_Table_User1]
GO
ALTER TABLE [dbo].[Table_Booking]  WITH CHECK ADD  CONSTRAINT [FK_Table_Booking_Booking] FOREIGN KEY([booking_id])
REFERENCES [dbo].[Booking] ([id])
GO
ALTER TABLE [dbo].[Table_Booking] CHECK CONSTRAINT [FK_Table_Booking_Booking]
GO
ALTER TABLE [dbo].[Table_Booking]  WITH CHECK ADD  CONSTRAINT [FK_Table_Booking_Table] FOREIGN KEY([table_id])
REFERENCES [dbo].[Table] ([id])
GO
ALTER TABLE [dbo].[Table_Booking] CHECK CONSTRAINT [FK_Table_Booking_Table]
GO
ALTER TABLE [dbo].[Table_Food]  WITH CHECK ADD  CONSTRAINT [FK_Table_Food_Booking] FOREIGN KEY([booking_id])
REFERENCES [dbo].[Booking] ([id])
GO
ALTER TABLE [dbo].[Table_Food] CHECK CONSTRAINT [FK_Table_Food_Booking]
GO
ALTER TABLE [dbo].[Table_Food]  WITH CHECK ADD  CONSTRAINT [FK_Table_Food_Food] FOREIGN KEY([food_id])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[Table_Food] CHECK CONSTRAINT [FK_Table_Food_Food]
GO
ALTER TABLE [dbo].[Table_Food]  WITH CHECK ADD  CONSTRAINT [FK_Table_Food_Table] FOREIGN KEY([table_id])
REFERENCES [dbo].[Table] ([id])
GO
ALTER TABLE [dbo].[Table_Food] CHECK CONSTRAINT [FK_Table_Food_Table]
GO
USE [master]
GO
ALTER DATABASE [PRN231_Group10_SE1701] SET  READ_WRITE 
GO
