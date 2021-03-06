USE [B2B.bak]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/28/2017 4:19:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Article]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](180) NOT NULL,
	[ImageArticle] [nvarchar](256) NULL,
	[Link] [nvarchar](256) NULL,
	[Content] [nvarchar](1024) NOT NULL,
	[AddDate] [datetime] NULL,
	[ViewCount] [int] NULL,
	[StatusArticle] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/28/2017 4:19:00 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](128) NOT NULL,
	[ImageCate] [nvarchar](256) NULL,
	[ParentId] [int] NULL,
	[StatusCate] [nvarchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactPerson]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactPerson](
	[ContactPersonId] [int] IDENTITY(1,1) NOT NULL,
	[WholesalerId] [char](6) NOT NULL,
	[Fullname] [nvarchar](64) NOT NULL,
	[Email] [nvarchar](128) NOT NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[StatusCP] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactPersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [nvarchar](100) NOT NULL,
	[CommonName] [nvarchar](128) NOT NULL,
	[StatusCountry] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](64) NOT NULL,
	[Email] [nvarchar](128) NOT NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[AddressEmp] [nvarchar](255) NULL,
	[StatusEmp] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectFB] [nvarchar](500) NULL,
	[WholesalerId] [char](6) NOT NULL,
	[SupplierId] [char](6) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[ReceivedDate] [datetime] NULL,
	[ReplyId] [int] NULL,
 CONSTRAINT [PK__Feedback__3214EC278D57B198] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [char](6) NOT NULL,
	[PurchaseOrderId] [char](6) NOT NULL,
	[PaypalId] [varchar](100) NULL,
	[SupplierId] [char](6) NOT NULL,
	[WholesalerId] [char](6) NOT NULL,
	[EmloyeeID] [int] NOT NULL,
	[InvoiceDate] [datetime] NULL,
	[PaymentMethodId] [int] NOT NULL,
	[CreditCardNumber] [int] NULL,
	[CardType] [nvarchar](150) NULL,
	[ExpDate] [datetime] NULL,
	[FromBankNo] [int] NULL,
	[ToBankNo] [int] NULL,
	[InitialPayment] [float] NULL,
	[Note] [nvarchar](max) NULL,
	[ShipmentMethod] [nvarchar](255) NULL,
	[ShipAddress] [nvarchar](max) NULL,
	[ShipFee] [float] NULL,
	[Status] [nvarchar](50) NULL,
	[Total] [float] NULL,
 CONSTRAINT [PK__Invoice__D796AAB59AB820F0] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](256) NOT NULL,
	[DescriptionItem] [nvarchar](max) NULL,
	[Unitprice] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
	[MinQuantity] [int] NOT NULL,
	[Discount] [float] NULL,
	[ImageItem] [nvarchar](max) NULL,
	[MoreImage] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[SupplierId] [char](6) NOT NULL,
	[ParentItem] [int] NULL,
	[AddedDate] [datetime] NOT NULL,
	[Warranty] [nvarchar](50) NOT NULL,
	[UnitId] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[ShippingFee] [nvarchar](255) NULL,
	[FAQ] [nvarchar](max) NULL,
	[StatusItem] [nvarchar](32) NULL,
 CONSTRAINT [PK__Item__727E838B330FE6BB] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[PaymentMethodId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[PurchaseOrderId] [char](6) NOT NULL,
	[PurchaseOrderDate] [datetime] NULL,
	[InquiriedData] [datetime] NULL,
	[ReceivedDate] [datetime] NULL,
	[SupplierId] [char](6) NULL,
	[WholesalerId] [char](6) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[StatusPurchase] [nvarchar](32) NOT NULL,
	[ReplyId] [char](6) NULL,
	[StatusInquiry] [nvarchar](50) NULL,
 CONSTRAINT [PK__Purchase__036BACA4EBA67AA7] PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseOrderDetails]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseOrderDetails](
	[PurchaseOrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderId] [char](6) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Discount] [float] NULL,
	[Tax] [float] NULL,
	[LineTotal] [float] NULL,
	[UnitId] [int] NOT NULL,
 CONSTRAINT [PK__Purchase__5026B698554880E6] PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[SliderId] [int] IDENTITY(1,1) NOT NULL,
	[ImageSlider] [nvarchar](256) NULL,
	[URL] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SliderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [char](6) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[CompanyName] [nvarchar](64) NULL,
	[Avatar] [varchar](50) NULL,
	[Email] [nvarchar](128) NULL,
	[Phone] [nvarchar](12) NULL,
	[Address] [nvarchar](255) NULL,
	[Province] [nvarchar](50) NULL,
	[MainProduct] [nvarchar](255) NULL,
	[CategoryId] [int] NULL,
	[Website] [nvarchar](100) NULL,
	[Zipcode] [int] NULL,
	[Country] [nvarchar](50) NULL,
	[CountryId] [int] NULL,
	[Status] [nvarchar](32) NULL,
	[BussinessType] [nvarchar](150) NULL,
	[YearEstablished] [datetime] NULL,
	[TotalEmployees] [nvarchar](50) NULL,
 CONSTRAINT [PK__Supplier__4BE666B43B64766C] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitId] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](50) NOT NULL,
	[UnitStatus] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wholesaler]    Script Date: 7/28/2017 4:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Wholesaler](
	[WholesalerId] [char](6) NOT NULL,
	[Avatar] [varchar](50) NULL,
	[Fullname] [nvarchar](64) NOT NULL,
	[Email] [nvarchar](128) NULL,
	[Phone] [nvarchar](12) NULL,
	[AddressWS] [nvarchar](255) NULL,
	[CountryId] [int] NOT NULL,
	[Website] [nvarchar](100) NULL,
	[Amount] [float] NULL,
	[StatusWS] [nvarchar](15) NULL,
 CONSTRAINT [PK__Wholesal__0334287456AD093B] PRIMARY KEY CLUSTERED 
(
	[WholesalerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'1.0.1')
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([ArticleId], [Title], [ImageArticle], [Link], [Content], [AddDate], [ViewCount], [StatusArticle]) VALUES (1, N'About us', N'about.jpg', NULL, N'abc', CAST(0x0000A79000000000 AS DateTime), 0, N'Enable')
SET IDENTITY_INSERT [dbo].[Article] OFF
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'5a4cc528-dbf7-48c8-8804-e2a76b0b9abc', N'9b72d4ba-8586-4f21-97e4-5327bb530d34', N'wholesaler', N'WHOLESALER')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'5ebcc511-4eed-460a-b907-a31387b03f90', N'ccf79411-da23-4a36-a38c-b1ee70c8be89', N'admin', N'ADMIN')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'9b38554f-eeda-4674-9390-712010523f17', N'798631fd-f61f-4b6d-a6c7-e8df8fed4b8e', N'supplier', N'SUPPLIER')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'ed2848a7-4e29-4ddb-b392-25339a0a062e', N'dc3f541e-39ba-4f9a-946c-fcf46a6cef43', N'guest', N'GUEST')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0c7c076f-cf6a-425e-9b76-fd65519adb11', N'5a4cc528-dbf7-48c8-8804-e2a76b0b9abc')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2b66b127-c71d-4133-aacd-65bd642c0610', N'5a4cc528-dbf7-48c8-8804-e2a76b0b9abc')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4579948a-95b3-4c48-a087-8129d31b6406', N'5a4cc528-dbf7-48c8-8804-e2a76b0b9abc')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4579948a-95b3-4c48-a087-8129d31b6406', N'9b38554f-eeda-4674-9390-712010523f17')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'58f1f911-bc20-41a1-885f-75429a1c0ae4', N'5ebcc511-4eed-460a-b907-a31387b03f90')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5ad6bfe5-3e7e-480e-ae6c-7af9f4417184', N'5a4cc528-dbf7-48c8-8804-e2a76b0b9abc')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6f595792-ff5c-44ed-8323-70ad1d151ebd', N'9b38554f-eeda-4674-9390-712010523f17')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'854b2afc-2274-4e59-85d6-423f51c5a3e5', N'9b38554f-eeda-4674-9390-712010523f17')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8eda25a4-e819-4181-8991-d59431a559a0', N'5a4cc528-dbf7-48c8-8804-e2a76b0b9abc')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8eda25a4-e819-4181-8991-d59431a559a0', N'9b38554f-eeda-4674-9390-712010523f17')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'be643a9e-c6a4-4bd3-bb6e-09b127e21acc', N'9b38554f-eeda-4674-9390-712010523f17')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'db4f3bdd-81e5-4008-a39c-0b119be9932c', N'5a4cc528-dbf7-48c8-8804-e2a76b0b9abc')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'db4f3bdd-81e5-4008-a39c-0b119be9932c', N'9b38554f-eeda-4674-9390-712010523f17')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f7d4108d-615b-4850-ad13-04ad58d28fbd', N'5a4cc528-dbf7-48c8-8804-e2a76b0b9abc')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f7d4108d-615b-4850-ad13-04ad58d28fbd', N'9b38554f-eeda-4674-9390-712010523f17')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'0c7c076f-cf6a-425e-9b76-fd65519adb11', 0, N'dcadb8de-dcdd-46e1-99a5-88cf0b691bce', N'vuminhtri6@gmail.com', 0, 1, NULL, N'VUMINHTRI6@GMAIL.COM', N'VUMINHTRI6@GMAIL.COM', N'AQAAAAEAACcQAAAAEHz/+W90KVqO8auJEx47niXG5mlE7Zwg368MGOuRNIpzS2qZL+xJwEpurQHhO75Jsg==', NULL, 0, N'41fb3674-0239-4278-ac7b-be2860164820', 0, N'vuminhtri6@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'2b66b127-c71d-4133-aacd-65bd642c0610', 0, N'1b9b6452-c850-49eb-97e3-40a016630139', N'wholesaler@gmail.com', 0, 1, NULL, N'WHOLESALER@GMAIL.COM', N'WHOLESALER@GMAIL.COM', N'AQAAAAEAACcQAAAAEEMfhZ6n3QlcZ1nJSQQd31LtArNFH3wh0hklPrxG/6abrrRgLgGJI0M8qGs6pZMo2g==', NULL, 0, N'18568fb9-9f2f-4c77-b44d-1b01e4959360', 0, N'wholesaler@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'4579948a-95b3-4c48-a087-8129d31b6406', 0, N'e7bea09b-bd2a-44a0-ae62-ed873b986caa', N'Thucbede@gmail.com', 0, 1, NULL, N'THUCBEDE@GMAIL.COM', N'THUCBEDE@GMAIL.COM', N'AQAAAAEAACcQAAAAEG9RTvEYhD1xd7oOXbeAy7np2Tt2Gh3SecKhviTcPnsWFoCAe+LsfpwshtsesW3BAg==', NULL, 0, N'9d2e32ac-5725-4637-b1f5-d9a2f3ed3973', 0, N'Thucbede@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'58f1f911-bc20-41a1-885f-75429a1c0ae4', 0, N'd072a4f8-6c3a-41c9-8944-272ab1dd02fc', N'khanh.ngoba@gmail.com', 0, 1, NULL, N'KHANH.NGOBA@GMAIL.COM', N'KHANH.NGOBA@GMAIL.COM', N'AQAAAAEAACcQAAAAENMZVax0TDxjL2bQXeWfrUbd7w25IVZ+D0fPIymY2acEtlRgghG6+I0XV+gVyeR3jQ==', NULL, 0, N'0a491224-7615-4881-b232-02e230b2b153', 0, N'khanh.ngoba@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'5ad6bfe5-3e7e-480e-ae6c-7af9f4417184', 0, N'4e6c2e68-8f80-447e-9e05-f5bb8432ded1', N'buyer@gmail.com', 0, 1, NULL, N'BUYER@GMAIL.COM', N'BUYER@GMAIL.COM', N'AQAAAAEAACcQAAAAELDCWfVOyh8ait2zCi6GMmIQ7du3iHwy9elunQwAzv3WcxWDDyu9Hf4oW8I9CuOHEg==', NULL, 0, N'4c9b3143-24b1-4cb7-8f2d-676b45723552', 0, N'buyer@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'6f595792-ff5c-44ed-8323-70ad1d151ebd', 0, N'bc81b2df-2e41-454d-bb53-7447917a381d', N'a@gmail.com', 0, 1, NULL, N'A@GMAIL.COM', N'A@GMAIL.COM', N'AQAAAAEAACcQAAAAEA411fAbKKrd4GTMA3qxTgsOa/6ozLQVs+vRKWiiQSgwtevdp69N18T8XyVWXpwA8w==', NULL, 0, N'3fe696b7-a7d9-458f-a0aa-5862933a1b17', 0, N'a@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'854b2afc-2274-4e59-85d6-423f51c5a3e5', 0, N'eeb5a2bc-91a0-4fa8-a6aa-5aa67ae3ffc1', N'supplier@gmail.com', 0, 1, NULL, N'SUPPLIER@GMAIL.COM', N'SUPPLIER@GMAIL.COM', N'AQAAAAEAACcQAAAAEPdaKcqr364AR6hHyjkJDmXgSyNclt/SSwhqBVt6m5DRVDV5xJnQqgZSJudDQZf7jg==', NULL, 0, N'e57d162c-3889-40cc-b403-47bbd30257f7', 0, N'supplier@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'8eda25a4-e819-4181-8991-d59431a559a0', 0, N'70dd90fb-5b0a-4be6-8bd9-2fd7f30bb512', N'b@gmail.com', 0, 1, NULL, N'B@GMAIL.COM', N'B@GMAIL.COM', N'AQAAAAEAACcQAAAAEKLXLCl79ZoBXWxsZ9GJyVb2fIGXMqLhSNqCSBazBYn1s3PLFdhVuEuS/2TzosIgtw==', NULL, 0, N'5f8e1cd9-351d-428d-9138-9989cf198003', 0, N'b@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'be643a9e-c6a4-4bd3-bb6e-09b127e21acc', 0, N'782551ec-6a33-4c7e-ada0-cbc1c46201d2', N'lamquechi@gmail.com', 0, 1, NULL, N'LAMQUECHI@GMAIL.COM', N'LAMQUECHI@GMAIL.COM', N'AQAAAAEAACcQAAAAECST/FdHgtYDGe7KrXW99Tf6RjJ8w3au9Y1pR+lnQGLfJEcKDZU+9Bt20Q48Rx1fwA==', NULL, 0, N'42cc203f-1631-4095-a4db-23eb7fea0193', 0, N'lamquechi@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'db4f3bdd-81e5-4008-a39c-0b119be9932c', 0, N'41542837-d3cc-4015-a0c0-bfb0931f7820', N'chinh106x@gmail.com', 0, 1, NULL, N'CHINH106X@GMAIL.COM', N'CHINH106X@GMAIL.COM', N'AQAAAAEAACcQAAAAEF6CHSPR1PB9i+FpZsKdwGJbsSvJ+Njsbo/9MyiC8WrR1G9U+1SAtZmBt7O9g1ewZQ==', NULL, 0, N'fe47142e-8080-4b48-aeb6-57f01a7fff9c', 0, N'chinh106x@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'f7d4108d-615b-4850-ad13-04ad58d28fbd', 0, N'151f170e-bbe0-44e3-bcc0-4b30927fc50a', N'NarHuynh@gmail.com', 0, 1, NULL, N'NARHUYNH@GMAIL.COM', N'NARHUYNH@GMAIL.COM', N'AQAAAAEAACcQAAAAEDk+xd2CmzHMPWvSpGQjyfbXYbMQktEBK4AjSfvjzsTv46LZgxu6W47dRndZYUUHrg==', NULL, 0, N'6365efed-eae4-4dcb-a053-fcea6820b5c8', 0, N'NarHuynh@gmail.com')
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (1, N'Mainboard - Bo Mạch Chủ', N'4161_pentium-4thh.jpg', NULL, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (2, N'CPU - Bộ Vi Xử Lý', N'cpu.jpg', NULL, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (3, N'RAM - Bộ Nhớ', N'ram.jpg', NULL, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (4, N'AsRock', N'asrock.jpg', 1, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (5, N'Asus', N'asus.jpg', 1, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (6, N'Foxconn', N'foxconn.jpg', 1, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (7, N'CPU-AMD', N'cpuamd.jpg', 2, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (8, N'Socket-AM3+', N'socketam3.jpg', 7, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (9, N'CPU-INTEL', N'cpuintel.jpg', 7, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (10, N'Bộ vi xử lý thế hệ 3', N'th3.jpg', 9, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (11, N'Bộ vi xử lý thế hệ 4', N'th4.jpg', 9, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (12, N'Ram Corsair', N'rcorsair.jpg', 3, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (13, N'Ram G.Skill', N'rgskill.jpg', 3, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (14, N'Ram Geil', N'rgeil.jpg', 3, N'Enable')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ImageCate], [ParentId], [StatusCate]) VALUES (16, N'Keyboard', N'11310_ram-cs-denn.jpg', NULL, N'Enable')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[ContactPerson] ON 

INSERT [dbo].[ContactPerson] ([ContactPersonId], [WholesalerId], [Fullname], [Email], [Phone], [StatusCP]) VALUES (1, N'VN0001', N'Nguyễn Văn Toàn', N'vantoan@gmail.com', N'0986568547', N'Enable')
SET IDENTITY_INSERT [dbo].[ContactPerson] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (1, N'AU', N'Australia', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (2, N'CN', N'China', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (3, N'FR', N'France', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (4, N'GB', N'United Kingdom', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (5, N'HK', N'Hong Kong', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (6, N'IN', N'India', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (7, N'ID', N'Indonesia', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (8, N'SG', N'Singapore', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (9, N'KR', N'Korea (South Korea)', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (10, N'MY', N'Malaysia', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (11, N'PH', N'Philippines', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (12, N'TH', N'ThaiLand', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (13, N'US', N'United States', N'Enable')
INSERT [dbo].[Country] ([CountryId], [CountryCode], [CommonName], [StatusCountry]) VALUES (14, N'VN', N'Việt Nam', N'Enable')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [Fullname], [Email], [Phone], [AddressEmp], [StatusEmp]) VALUES (1, N'Nguyễn Văn Hải', N'trivu1996@gmail.com', N'098 856 7812', N'56 Lý Thường Kiệt, Phường 10, Quận 11, Tp HCM', N'Enable')
INSERT [dbo].[Employee] ([EmployeeId], [Fullname], [Email], [Phone], [AddressEmp], [StatusEmp]) VALUES (2, N'Hoàng Đình Trung', N'trung123@gmail.com', N'098 632 4516', N'14 Hoàng Hoa Thám, Phường 5, Quận Tân Bình, Tp HCM', N'Enable')
INSERT [dbo].[Employee] ([EmployeeId], [Fullname], [Email], [Phone], [AddressEmp], [StatusEmp]) VALUES (3, N'Vũ Huy Thái', N'thaivu@gmail.com', N'098 765 4254', N'45 Hồ Bá Kiện, Phường 4, Quận 10, Tp HCM', N'Enable')
INSERT [dbo].[Employee] ([EmployeeId], [Fullname], [Email], [Phone], [AddressEmp], [StatusEmp]) VALUES (4, N'khanh', N'a@gmail.com', N'098 876 7654', N'abc', N'enable')
INSERT [dbo].[Employee] ([EmployeeId], [Fullname], [Email], [Phone], [AddressEmp], [StatusEmp]) VALUES (5, N'Chinh Ngo', N'ngo.chinh106@gmail.com', N'098 765 4332', N'123 Nguyen Van Troi', N'Enable')
SET IDENTITY_INSERT [dbo].[Employee] OFF
INSERT [dbo].[Invoice] ([InvoiceId], [PurchaseOrderId], [PaypalId], [SupplierId], [WholesalerId], [EmloyeeID], [InvoiceDate], [PaymentMethodId], [CreditCardNumber], [CardType], [ExpDate], [FromBankNo], [ToBankNo], [InitialPayment], [Note], [ShipmentMethod], [ShipAddress], [ShipFee], [Status], [Total]) VALUES (N'ID0001', N'ID0001', N'PAY-7R5628205N644645NLF4BF7I', N'HK0007', N'ID0005', 1, CAST(0x0000A7B300F36F1C AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, N'Giao trước ngày 18/7/2017', N'Airplane Express', N'Indonesia', 630, N'paid', 4830)
INSERT [dbo].[Invoice] ([InvoiceId], [PurchaseOrderId], [PaypalId], [SupplierId], [WholesalerId], [EmloyeeID], [InvoiceDate], [PaymentMethodId], [CreditCardNumber], [CardType], [ExpDate], [FromBankNo], [ToBankNo], [InitialPayment], [Note], [ShipmentMethod], [ShipAddress], [ShipFee], [Status], [Total]) VALUES (N'ID0002', N'ID0003', N'PAY-9436718585362783XLF3X5DI', N'HK0007', N'ID0005', 1, CAST(0x0000A7B3017763CD AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, N'Giao truoc thang 9', N'Sea Express', N'Hong Kong', 104.94, N'paid', 1154.3400000000002)
INSERT [dbo].[Invoice] ([InvoiceId], [PurchaseOrderId], [PaypalId], [SupplierId], [WholesalerId], [EmloyeeID], [InvoiceDate], [PaymentMethodId], [CreditCardNumber], [CardType], [ExpDate], [FromBankNo], [ToBankNo], [InitialPayment], [Note], [ShipmentMethod], [ShipAddress], [ShipFee], [Status], [Total]) VALUES (N'ID0003', N'ID0005', N'PAY-8US67393KU6181835LFYYJYA', N'HK0007', N'ID0005', 1, CAST(0x0000A7B50178F523 AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, N'vui long gọi trước khi giao hàng', N'Airplane Express', N' Banyuwangi Regency, Java, Indonesia', 150, N'paid', 1150)
INSERT [dbo].[Invoice] ([InvoiceId], [PurchaseOrderId], [PaypalId], [SupplierId], [WholesalerId], [EmloyeeID], [InvoiceDate], [PaymentMethodId], [CreditCardNumber], [CardType], [ExpDate], [FromBankNo], [ToBankNo], [InitialPayment], [Note], [ShipmentMethod], [ShipAddress], [ShipFee], [Status], [Total]) VALUES (N'ID0005', N'ID0009', N'PAY-643591661B4766213LF5DNZA', N'HK0007', N'ID0005', 1, CAST(0x0000A7BE001E59A7 AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, N'giao trước ngày 31/8/2017', N'Airplane Express', N' Banyuwangi Regency, Java, Indonesia', 78.75, N'paid', 603.75)
INSERT [dbo].[Invoice] ([InvoiceId], [PurchaseOrderId], [PaypalId], [SupplierId], [WholesalerId], [EmloyeeID], [InvoiceDate], [PaymentMethodId], [CreditCardNumber], [CardType], [ExpDate], [FromBankNo], [ToBankNo], [InitialPayment], [Note], [ShipmentMethod], [ShipAddress], [ShipFee], [Status], [Total]) VALUES (N'MY0004', N'MY0007', N'PAY-4805533917178484CLF3XTXQ', N'IN0010', N'MY0007', 1, CAST(0x0000A7BB0153A676 AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, N'Giao hang truoc ngay 25/8', N'Sea Express', N'Jalan Perwira', 210, N'paid', 2310)
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ItemId], [ItemName], [DescriptionItem], [Unitprice], [Price], [Quantity], [MinQuantity], [Discount], [ImageItem], [MoreImage], [CategoryId], [SupplierId], [ParentItem], [AddedDate], [Warranty], [UnitId], [Note], [ShippingFee], [FAQ], [StatusItem]) VALUES (1, N'Bo mạch chính/ Mainboard Asrock H81M-VG4', N'<p><br></p><p>Hãng sản xuất</p><p>MSI</p><p>Chủng loại</p><p>Z270 GAMING M7</p><p>CPU hỗ trợ</p><p>Supports 7th/6th Gen Intel®&nbsp;Core™ i3/i5/i7 processors, and Intel®&nbsp;Pentium®and Celeron®&nbsp;processors for Socket LGA1151</p><p>Chipset</p><p>•&nbsp;Intel®&nbsp;Z270 Chipset</p><p>Bộ nhớ trong</p><p>4 x DDR4 memory slots, support up to 64GB<br>- 7th Gen processors support DDR4 4000(OC)/ 3800(OC)/ 3600(OC)/ 3200(OC)/ 3000(OC)/ 2800(OC)/ 2600(OC)/ 2400/ 2133 MHz*<br>- 6th Gen processors support DDR4 3600(OC)/ 3200(OC)/ 3000(OC)/ 2800(OC)/ 2600(OC)/ 2400(OC)/ 2133 MHz*<br>• Dual channel memory architecture<br>• Supports Intel®; Extreme Memory Profile (XMP)</p><p>VGA onboard</p><p>• 1 x HDMI™ port, supports a maximum resolution of 4096x2160@30Hz(7th Gen CPU), 4096x2160@24Hz(6th Gen CPU), 2560x1600@60Hz<br>• 1 x DisplayPort, supports a maximum resolution of 4096x2304@24Hz, 2560x1600@60Hz, 3840x2160@60Hz, 1920x1200@60Hz<br><br></p><p>Âm thanh</p><p>• Dual Realtek®&nbsp;ALC1220 Codec<br>- 7.1-Channel High Definition Audio</p><p>Khe mở rộng</p><p>• 3 x PCIe 3.0 x16 slots (support x16/x0/x0, x8/x8/x0, x8/x4/x4 modes)<br>• 3 x PCIe 3.0 x1 slots</p><p>Chuẩn lưu trữ</p><p><br>•&nbsp;<strong>Intel®&nbsp;Z270 Chipset</strong><br>• 6x SATA 6Gb/s ports*/ **<br>• 1x U.2 port **<br>- Supports up to PCIe 3.0 x4 NVMe U.2 SSD<br>• 3x M.2 slots (Key M)*<br>- M2_1 slot supports up to PCIe 3.0x4 and SATA 6Gb/s standards, 2242/ 2260 /2280/ 22110 storage devices<br>- M2_2 slot supports up to PCIe 3.0x4 standard, 2242/ 2260 /2280 storage devices<br>- M2_3 slot supports up to PCIe 3.0x4 and SATA 6Gb/s ** standards, 2242/ 2260 /2280 storage devices<br>- Intel®&nbsp;Optane™ Memory Ready for all M.2 slots***<br>• Supports Intel®&nbsp;Smart Response Technology for Intel Core™ processors</p><p>Cổng giao tiếp trước và sau</p><p><br>- 1 x PS/2 mouse &amp; keyboard combo port<br>- 3 x USB 2.0 Type-A ports<br>- 1 x Clear CMOS button<br>- 1 x DisplayPort<br>- 1 x HDMI™ port<br>- 1 x LAN (RJ45) port<br>- 2 x USB 3.1 Gen1 Type-A ports<br>- 1 x USB 3.1 Gen2 Type-A port<br>- 1 x USB 3.1 Gen2 Type-C port<br>- 1 x Optical S/PDIF OUT connector<br>- 5 x OFC audio jacks<br><br></p><p>Công nghệ tích hợp</p><p><br></p><p><br>&nbsp;&nbsp;</p><p>Kích thước</p><p>12.0 in. x 9.6 in. (30.5 cm x 24.4 cm)<br>• ATX Form Factor</p><p>Phụ kiện đi kèm</p><p>Hộp , sách , đĩa cài , chặn main</p>', NULL, N'30 - 50', 100, 10, 5, N'mainboard-asus-h110m-d-d3.jpg', N'mainboard-asus-h110m-d-d3.jpg,mainboard-asus-sabertooth-z170-s(1).jpg,', 1, N'HK0007', NULL, CAST(0x0000A7B900000000 AS DateTime), N'12 tháng', 1, NULL, NULL, N'<p>1. L&agrave;m thế n&agrave;o để mua sản phẩm?</p>', N'Enable')
INSERT [dbo].[Item] ([ItemId], [ItemName], [DescriptionItem], [Unitprice], [Price], [Quantity], [MinQuantity], [Discount], [ImageItem], [MoreImage], [CategoryId], [SupplierId], [ParentItem], [AddedDate], [Warranty], [UnitId], [Note], [ShippingFee], [FAQ], [StatusItem]) VALUES (2, N'Bo mạch chính/ Mainboard Asrock H110M-DVS', N'<p><br></p><p><strong>Thông tin sản phẩm:</strong></p><ul><li>sk LGA 1151, S/p 6th Intel Core i7/i5/i3/Pentium/Celeron</li><li>S/p: 2x DDR4 2133 (Non ECC) max 32GB, Turbo Boost 2.0 Technology, Digi Power Design, 5x Power Phase Disign</li><li>1x PCIe 3.0 x16, 2x PCIe 2.0 x1, 1x DVI-D, 1x D-Sub, Lan 1G, 4x USB 2.0, 2x USB 3.0, 1x PS/2, 7.1 CH HD Audio</li></ul><p><br></p><p><br></p><p><br></p><p><br></p><p><br></p>', NULL, N'50 - 70', 100, 10, 5, N'mainboard-asus-h110m-d-d3.jpg', N'mainboard-asus-h110m-d-d3.jpg,mainboard-asus-h110m-d-d3(1).jpg,mainboard-asus-h110m-d-d3(6).jpg,mainboard-msi-b150m-pro-vdh-d3(1).jpg,', 1, N'HK0007', NULL, CAST(0x0000A7B900000000 AS DateTime), N'12 tháng', 1, NULL, NULL, NULL, N'Enable')
INSERT [dbo].[Item] ([ItemId], [ItemName], [DescriptionItem], [Unitprice], [Price], [Quantity], [MinQuantity], [Discount], [ImageItem], [MoreImage], [CategoryId], [SupplierId], [ParentItem], [AddedDate], [Warranty], [UnitId], [Note], [ShippingFee], [FAQ], [StatusItem]) VALUES (3, N'Bo mạch chính/ Mainboard Asrock H110M-HDS', N'<table style="color: rgb(34, 34, 34); font-family: &quot;Roboto Condensed&quot;; font-size: 15px;"><tbody><tr><td style="vertical-align: top; padding-top: 3px; padding-bottom: 3px; line-height: 18px;"><div id="summary_detail" style="line-height: 25px;"><b style="color: rgb(0, 0, 0);">Mô tả sản phẩm:&nbsp;</b><br>* CPU	- Supports 6th Generation Intel® Core™ i7/i5/i3/Pentium®/Celeron® Processors (Socket 1151)<br>- Supports Intel® Turbo Boost 2.0 Technology&nbsp;<br>* Chipset	- Intel® H110&nbsp;<br>* Memory	- Dual Channel DDR4 Memory Technology&nbsp;<br>- 2 x DDR4 DIMM Slots&nbsp;<br>- Supports DDR4 2133 non-ECC, un-buffered memory&nbsp;<br>- Supports ECC UDIMM memory modules (operate in non-ECC mode)&nbsp;<br>- Max. capacity of system memory: 32GB*&nbsp;<br>- Supports Intel® Extreme Memory Profile (XMP) 2.0<br></div></td></tr><tr><td style="vertical-align: top; padding-top: 3px; padding-bottom: 3px; line-height: 18px;"><br></td></tr></tbody></table><p><br></p>', NULL, N'40 - 60', 100, 10, 5, N'mainboard-asus-h110m-d-d3.jpg', N'mainboard-asus-h110m-d-d3.jpg,mainboard-asus-sabertooth-z170-s(1).jpg,mainboard-asus-sabertooth-z170-s(8).jpg,', 1, N'HK0007', NULL, CAST(0x0000A79E00000000 AS DateTime), N'12 tháng', 1, NULL, NULL, NULL, N'Enable')
INSERT [dbo].[Item] ([ItemId], [ItemName], [DescriptionItem], [Unitprice], [Price], [Quantity], [MinQuantity], [Discount], [ImageItem], [MoreImage], [CategoryId], [SupplierId], [ParentItem], [AddedDate], [Warranty], [UnitId], [Note], [ShippingFee], [FAQ], [StatusItem]) VALUES (4, N'Bộ vi xử lí thế hệ 3', N'<ul style="margin: 20px 10px 0px 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial; font-family: Tahoma, Arial; font-size: 12px; width: 340px; height: auto; list-style: none; color: rgb(0, 0, 0);"><span style="margin: 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; font-weight: bold; clear: both !important;">Tính năng nổi bật:</span><div class="thongtinsp" style="margin: 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; background: transparent;"><p style="margin-bottom: 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; background: transparent;">Socket 1151 - 3MB Cache - 2 Cores - 4 Threads - Intel HD 630</p><p style="margin-bottom: 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; background: transparent;">Chỉ chạy được với Windows 10(Kèm Fan)</p><p style="margin-bottom: 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; background: transparent;"><br></p><p style="margin-bottom: 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; background: transparent;"><br></p></div></ul><img src="https://p.fast.ulmart.ru/p/mid/92/9204/920428.jpg" style="width: 380px;"><ul style="margin: 20px 10px 0px 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial; font-family: Tahoma, Arial; font-size: 12px; width: 340px; height: auto; list-style: none; color: rgb(0, 0, 0);"><div class="thongtinsp" style="margin: 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; background: transparent;"><p style="margin-bottom: 0px; padding: 0px; border: 0px; outline-style: initial; outline-width: 0px; vertical-align: baseline; background: transparent;"><br></p></div></ul>', NULL, N'30 - 60', 100, 13, 4, N'mainboard-asus-h110m-d-d3.jpg', N'mainboard-asus-h110m-d-d3.jpg,mainboard-asus-h110m-d-d3(1).jpg,mainboard-asus-h110m-d-d3(6).jpg,', 1, N'HK0007', NULL, CAST(0x0000A79D00000000 AS DateTime), N'12 thang', 3, NULL, NULL, NULL, N'Enable')
INSERT [dbo].[Item] ([ItemId], [ItemName], [DescriptionItem], [Unitprice], [Price], [Quantity], [MinQuantity], [Discount], [ImageItem], [MoreImage], [CategoryId], [SupplierId], [ParentItem], [AddedDate], [Warranty], [UnitId], [Note], [ShippingFee], [FAQ], [StatusItem]) VALUES (9, N'Main giga b85 gaming 3 socket 1150 - gaming3', N'<p>Manufacture (Hãng sản xuất)GIGABYTESocketIntel Socket 1150Form FactorMicroATX (uATX)ChipsetIntel B85 ExpressCPU onboardKhông cóCPU Support (Loại CPU hỗ trợ) (1)• Intel Core i7<br>CPU Support (Loại CPU hỗ trợ) (2)• Intel Core i5<br>• Intel Core i3<br>Front Side Bus (FSB)• -<br>Memory Slot (Số khe cắm ram)2Max Memory Support (Gb)16Memory Type (Loại Ram sử dụng)DDR3Memory Bus• 1333Mhz<br>• 1600MHz<br>Internal I/O Connectors (Các kết nối bên trong)• USB 2.0 connectors<br>• 24-pin ATX Power connector<br>• 8-pin ATX 12V Power connector<br>• SATA 6Gb/s connectors<br>Back Panel I/O Ports (Cổng kết nối phía sau)• LAN (RJ45) port<br>• USB 2.0/1.1 ports<br>• PS/2 port<br>• VGA onboard (D-sub)<br>• HDMI<br>• USB 3.0/2.0 ports<br>Cổng USB và SATA• USB 2.0 x 6<br>• USB 3.0 x 4<br>• USB 3.1 x 2<br>• SATA II 3Gb/s x 2<br>• SATA III 6Gb/s x 4<br>Expansion Slot (Khe mở rộng)• PCI Express x1<br>• PCI Express x16 (x1)</p>', NULL, N'50 - 60', 100, 15, 0, N'mainboard-asus-h110m-d-d3.jpg', N'mainboard-asus-h110m-d-d3.jpg,mainboard-asus-h110m-d-d3(1).jpg,mainboard-asus-h110m-d-d3(6).jpg,', 1, N'HK0007', NULL, CAST(0x0000A7A600000000 AS DateTime), N'12 tháng', 2, NULL, NULL, NULL, N'Enable')
INSERT [dbo].[Item] ([ItemId], [ItemName], [DescriptionItem], [Unitprice], [Price], [Quantity], [MinQuantity], [Discount], [ImageItem], [MoreImage], [CategoryId], [SupplierId], [ParentItem], [AddedDate], [Warranty], [UnitId], [Note], [ShippingFee], [FAQ], [StatusItem]) VALUES (10, N'Bộ vi xử lý/ CPU AMD Ryzen R7 1700X (3.4/3.8GHz)', N'<ul><li>Hãng sản xuất:<p>AMD</p></li><li>Chủng loại:<p>Ryzen R7</p></li><li>Socket:<p>AM4</p></li><li>Tốc độ:<p>3.4GHz ( Tăng tốc 3.8GHz)</p></li><li>Bus Ram hỗ trợ:<p>DDR4</p></li><li>Nhân CPU:<p>8 Nhân 16 luồng</p></li><li>Bộ nhớ đệm:<p>4MB cache L2 / 16MB cache L3</p></li><li>Card đồ họa:<p>Không GPU</p></li><li>Tản nhiệt kèm theo:<p>Không có</p></li></ul>', NULL, N'100 - 200', NULL, 10, 0, N'2284_core-i5-6thh.jpg', N'2284_core-i5-6thh.jpg,10832_core-i5-6thh.jpg,12557_i55.jpg,', 2, N'IN0010', NULL, CAST(0x0000A7BA00000000 AS DateTime), N'12 tháng', 1, NULL, NULL, NULL, N'Enable')
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[PaymentMethod] ON 

INSERT [dbo].[PaymentMethod] ([PaymentMethodId], [Name]) VALUES (1, N'Paypal')
INSERT [dbo].[PaymentMethod] ([PaymentMethodId], [Name]) VALUES (2, N'Credit card')
INSERT [dbo].[PaymentMethod] ([PaymentMethodId], [Name]) VALUES (3, N'Internet Banking')
SET IDENTITY_INSERT [dbo].[PaymentMethod] OFF
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'ID0001', CAST(0x0000A7B300F094A1 AS DateTime), CAST(0x0000A7B300F094A5 AS DateTime), CAST(0x0000A7B300F094A5 AS DateTime), N'HK0007', N'ID0005', N'<p>abc</p>', N'Being prepared', NULL, NULL)
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'ID0002', CAST(0x0000A7B300F1833A AS DateTime), CAST(0x0000A7B300F094A5 AS DateTime), CAST(0x0000A7C100000000 AS DateTime), N'HK0007', N'ID0005', N'<p>tks</p>', N'confirmed', N'ID0001', N'Readed')
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'ID0003', CAST(0x0000A7B301766A58 AS DateTime), CAST(0x0000A7B301766A5B AS DateTime), CAST(0x0000A7B301766A5B AS DateTime), N'HK0007', N'ID0005', N'<p>Dear U,</p><p>T&ocirc;i muốn mua sp của bạn, vui long gửi bảng b&aacute;o gi&aacute; cho t&ocirc;i</p><p>tks</p>', N'Being prepared', NULL, N'Readed')
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'ID0004', CAST(0x0000A7B30176EB77 AS DateTime), CAST(0x0000A7B301766A5B AS DateTime), CAST(0x0000A7C100000000 AS DateTime), N'HK0007', N'ID0005', N'<p>Cảm ơn bạn đ&atilde; quan t&acirc;m đến sản phẩm của ch&uacute;ng t&ocirc;i</p>', N'confirmed', N'ID0003', N'Readed')
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'ID0005', CAST(0x0000A7B400AC0323 AS DateTime), CAST(0x0000A7B400AC0326 AS DateTime), CAST(0x0000A7B400AC0326 AS DateTime), N'HK0007', N'ID0005', N'<p>Toi muon mua san pham cua ban</p><p>Vui long gui bang bao gia cho toi</p>', N'Being prepared', NULL, N'Readed')
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'ID0006', CAST(0x0000A7B50178AAE6 AS DateTime), CAST(0x0000A7B400AC0326 AS DateTime), CAST(0x0000A7C100000000 AS DateTime), N'HK0007', N'ID0005', N'<p>Cảm ơn bạn đ&atilde; mua sản phẩm của ch&uacute;ng t&ocirc;i</p>', N'confirmed', N'ID0005', N'Readed')
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'ID0009', CAST(0x0000A7BE001A9776 AS DateTime), CAST(0x0000A7BE001A977A AS DateTime), CAST(0x0000A7BE001A977A AS DateTime), N'HK0007', N'ID0005', N'<p>Toi muon mua san pham cua ban</p>', N'Being prepared', NULL, NULL)
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'ID0010', CAST(0x0000A7BE001CB257 AS DateTime), CAST(0x0000A7BE001A977A AS DateTime), CAST(0x0000A7E000000000 AS DateTime), N'HK0007', N'ID0005', N'<p>Cam on ban da quan tam san pham cua chung toi</p>', N'confirmed', N'ID0009', N'Readed')
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'MY0007', CAST(0x0000A7BB0003E097 AS DateTime), CAST(0x0000A7BB0003E09B AS DateTime), CAST(0x0000A7BB0003E09B AS DateTime), N'IN0010', N'MY0007', N'<p>T&ocirc;i muốn mua sản phẩm n&agrave;y.</p><p>Vui l&ograve;ng b&aacute;o gi&aacute; cho t&ocirc;i.</p><p>&nbsp;</p>', N'Being prepared', NULL, NULL)
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderId], [PurchaseOrderDate], [InquiriedData], [ReceivedDate], [SupplierId], [WholesalerId], [Comment], [StatusPurchase], [ReplyId], [StatusInquiry]) VALUES (N'MY0008', CAST(0x0000A7BB0006AC19 AS DateTime), CAST(0x0000A7BB0003E09B AS DateTime), CAST(0x0000A7C100000000 AS DateTime), N'IN0010', N'MY0007', N'<p>Cảm ơn bạn đ&atilde; mua sản phẩm của ch&uacute;ng th&ocirc;i</p>', N'confirmed', N'MY0007', N'Readed')
SET IDENTITY_INSERT [dbo].[PurchaseOrderDetails] ON 

INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderDetailId], [PurchaseOrderId], [ItemId], [Quantity], [Price], [Discount], [Tax], [LineTotal], [UnitId]) VALUES (1016, N'ID0001', 3, 100, 40, 5, 10, 4200, 1)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderDetailId], [PurchaseOrderId], [ItemId], [Quantity], [Price], [Discount], [Tax], [LineTotal], [UnitId]) VALUES (1017, N'ID0003', 4, 30, 30, 4, 10, 954, 3)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderDetailId], [PurchaseOrderId], [ItemId], [Quantity], [Price], [Discount], [Tax], [LineTotal], [UnitId]) VALUES (1018, N'ID0005', 3, 100, 10, 5, 5, 1000, 1)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderDetailId], [PurchaseOrderId], [ItemId], [Quantity], [Price], [Discount], [Tax], [LineTotal], [UnitId]) VALUES (2016, N'MY0007', 10, 20, 100, 10, 15, 2100, 1)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderDetailId], [PurchaseOrderId], [ItemId], [Quantity], [Price], [Discount], [Tax], [LineTotal], [UnitId]) VALUES (3016, N'ID0009', 3, 10, 50, 5, 10, 525, 1)
SET IDENTITY_INSERT [dbo].[PurchaseOrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([SliderId], [ImageSlider], [URL], [IsActive]) VALUES (1, N'main-slider1.jpg', NULL, 1)
INSERT [dbo].[Slider] ([SliderId], [ImageSlider], [URL], [IsActive]) VALUES (2, N'main-slider2.jpg', NULL, 1)
INSERT [dbo].[Slider] ([SliderId], [ImageSlider], [URL], [IsActive]) VALUES (3, N'main-slider3.jpg', NULL, 1)
INSERT [dbo].[Slider] ([SliderId], [ImageSlider], [URL], [IsActive]) VALUES (4, N'1920x1080.jpg', NULL, 1)
INSERT [dbo].[Slider] ([SliderId], [ImageSlider], [URL], [IsActive]) VALUES (5, N'maxresdefault (1).jpg', NULL, 1)
INSERT [dbo].[Slider] ([SliderId], [ImageSlider], [URL], [IsActive]) VALUES (6, N'maxresdefault.jpg', NULL, 1)
INSERT [dbo].[Slider] ([SliderId], [ImageSlider], [URL], [IsActive]) VALUES (7, N'MSI-Z77-MPower-Motherboard1.jpg', NULL, 1)
SET IDENTITY_INSERT [dbo].[Slider] OFF
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'AU0009', N'Thuc be de', N'', N'Tap doan be de', N'avatar4.jpg', N'Thucbede@gmail.com', N'098 765 4332', N'', N'', N'', 1, N'', 0, N'Australia', 1, N'Disable', N'', CAST(0x0000A7BA0142554D AS DateTime), N'0')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'AU0012', N'Chinh Ngo', N'', N'Chinh Ngo', N'avatar5.jpg', N'a@gmail.com', N'098 765 4332', N'', N'', N'', 1, N'', 0, N'Australia', 1, N'Disable', N'', CAST(0x0000A7BC00DDBAF5 AS DateTime), N'0')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'CN0002', N'Ms. Dara Zhang', N'Sales Director', N'Shenzhen Xinwanggu Technology Limited', N'no_avatar.png', N'ShenzhenTechnology@gmail.com', N'867 552 8111', N'Longhua', N'Guangdong', N'Cpu,ram,mainboard', 2, N'http://ShenzhenTechnology.com', 518000, N'China', 2, N'Enable', N'Manufacturer', CAST(0x00009FFF00000000 AS DateTime), N'100')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'FR0011', N'Lam Que Chi', N'', N'CNC Group', N'avatar2.jpg', N'lamquechi@gmail.com', N'084-890-0987', N'', N'', N'', 1, N'', 0, N'France', 3, N'Enable', N'', CAST(0x0000A7BC00D956AA AS DateTime), N'0')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'HK0007', N'Mr. Rooney', N'Manager', N'Cangnan Fugang Printing Co., Ltd.', N'avatar2.jpg', N'supplier@gmail.com', N'090 325 0867', N'No.4 Building ,No.1 Guihua First Road, Chengdong Industrial Park , Longgang Town,Zhejiang Province,China', N'Zhejiang', N'cpu', 2, N'http://CangnanCompany.com', 325802, NULL, 5, N'Enable', N'Manufacturer, Trading Company', CAST(0x0000A7B500000000 AS DateTime), N'50 - 100')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'IN0010', N'Mr. Chinh', N'Manager', N'S3 Solution', N'avatar6.jpg', N'chinh106x@gmail.com', N'098 765 4332', N'123 Nguyen Van Troi', N'abc', N'Main', 1, N'http://abc.com', 345345, NULL, 6, N'Enable', N'Manufacturer, Trading Company', CAST(0x0000950E00000000 AS DateTime), N'100 - 150')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'MY0003', N'Ms. Cherry', N'Sales Director', N'KONG SING TRADING', N'no_avatar.png', N'Kongsing@gmail.com', N'089 765 4321', N'Unit A7-G-9 & 10, Block 7, Ground Floor, Jalan Mewah 4, Pandan Mewah', N'Selangor', N'RDS 9,RDS 5,Li-Gate,Nuova Luce,Barrier Gate', 1, N'http://www.kongsing.com.my', 680000, N'Malaysia', 10, N'Enable', N'Manufacturer, Trading Company, Distributor/Wholesaler', CAST(0x000088B200000000 AS DateTime), N'10')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'TH0008', N'Mr. John Terry', N'Director', N'Fahasha', N'no_avatar.png', N'NarHuynh@gmail.com', N'098 765 4332', N' ', N' ', N' ', 1, N'  ', 0, N'ThaiLand', 12, N'Disable', N'  ', CAST(0x000088B200000000 AS DateTime), N'0')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'TH0013', N'Nguyen van A', N'', N'Chinh Ngo', N'no_avatar.png', N'b@gmail.com', N'090 325 0809', N'', N'', N'', 1, N'', 0, N'ThaiLand', 12, N'Disable', N'', CAST(0x0000A7BC00F29DBF AS DateTime), N'0')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Title], [CompanyName], [Avatar], [Email], [Phone], [Address], [Province], [MainProduct], [CategoryId], [Website], [Zipcode], [Country], [CountryId], [Status], [BussinessType], [YearEstablished], [TotalEmployees]) VALUES (N'VN0001', N'Ms. Tri', N'Security', N'Hoàng Long', N'no_avatar.png', N'hoanglong@gmail.com', N'545 435 4354', N'876 Nguyễn Thị Minh Khai, Quận 1, TP HCM', N'Hồ Chí Minh', N'Mainboard', 1, N'http://HoangLongElectronic.com', 700000, N'Việt Nam', 14, N'Enable', N'Cung cấp số lượng lớn', CAST(0x000007D000000000 AS DateTime), N'50')
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([UnitId], [UnitName], [UnitStatus]) VALUES (1, N'Piece', N'Enable')
INSERT [dbo].[Unit] ([UnitId], [UnitName], [UnitStatus]) VALUES (2, N'Thanh', N'Enable')
INSERT [dbo].[Unit] ([UnitId], [UnitName], [UnitStatus]) VALUES (3, N'Thùng', N'Enable')
INSERT [dbo].[Unit] ([UnitId], [UnitName], [UnitStatus]) VALUES (4, N'Container', N'Enable')
SET IDENTITY_INSERT [dbo].[Unit] OFF
INSERT [dbo].[Wholesaler] ([WholesalerId], [Avatar], [Fullname], [Email], [Phone], [AddressWS], [CountryId], [Website], [Amount], [StatusWS]) VALUES (N'ID0005', N'no_avatar.png', N'Wholesaler', N'wholesaler@gmail.com', N'083 789 9876', N' Banyuwangi Regency, Java, Indonesia', 7, NULL, 10000, N'Enable')
INSERT [dbo].[Wholesaler] ([WholesalerId], [Avatar], [Fullname], [Email], [Phone], [AddressWS], [CountryId], [Website], [Amount], [StatusWS]) VALUES (N'MY0007', N'no_avatar.png', N'Vu Minh Tri', N'vuminhtri6@gmail.com', N'083 789 7659', N'Jalan Perwira', 10, NULL, 10000, N'Enable')
INSERT [dbo].[Wholesaler] ([WholesalerId], [Avatar], [Fullname], [Email], [Phone], [AddressWS], [CountryId], [Website], [Amount], [StatusWS]) VALUES (N'TH0006', N'no_avatar.png', N'Nar Huynh', N'NarHuynh@gmail.com', N'098 765 4332', N'Msgr. F. Noronha Road, Shivaji Nagar, Bengaluru, Karnataka 560051, India', 12, NULL, 10000, N'Enable')
INSERT [dbo].[Wholesaler] ([WholesalerId], [Avatar], [Fullname], [Email], [Phone], [AddressWS], [CountryId], [Website], [Amount], [StatusWS]) VALUES (N'TH0008', N'no_avatar.png', N'Anonymous', N'buyer@gmail.com', N'098 876 0987', N'Ground Floor, Fifth Avenue Mall, Brigade Rd, Shanthala Nagar, Ashok Nagar, Bengaluru, Karnataka 560001, India', 12, NULL, 10000, N'Enable')
INSERT [dbo].[Wholesaler] ([WholesalerId], [Avatar], [Fullname], [Email], [Phone], [AddressWS], [CountryId], [Website], [Amount], [StatusWS]) VALUES (N'VN0001', N'no_avatar.png', N'Hưng Thịnh', N'hungthinh@gmail.com', N'083 856 9214', N'319 Lý thường kiệt, Phường 5, Quận 10, Tp. HCM', 14, N'http://abc.com', 10000, N'Enable')
ALTER TABLE [dbo].[Article] ADD  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Article] ADD  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT ('Enable') FOR [StatusCate]
GO
ALTER TABLE [dbo].[Country] ADD  DEFAULT ('Enable') FOR [StatusCountry]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF__Feedback__Receiv__44FF419A]  DEFAULT (getdate()) FOR [ReceivedDate]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__Invoice__398D8EEE]  DEFAULT (getdate()) FOR [InvoiceDate]
GO
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF__Item__AddedDate__267ABA7A]  DEFAULT (getdate()) FOR [AddedDate]
GO
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF__Item__StatusItem__276EDEB3]  DEFAULT ('Enable') FOR [StatusItem]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF__PurchaseO__Purch__300424B4]  DEFAULT (getdate()) FOR [PurchaseOrderDate]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF__Supplier__Status__1ED998B2]  DEFAULT ('Enable') FOR [Status]
GO
ALTER TABLE [dbo].[Unit] ADD  DEFAULT ('Enable') FOR [UnitStatus]
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
ALTER TABLE [dbo].[Category]  WITH CHECK ADD FOREIGN KEY([ParentId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[ContactPerson]  WITH CHECK ADD  CONSTRAINT [FK__ContactPe__Whole__182C9B23] FOREIGN KEY([WholesalerId])
REFERENCES [dbo].[Wholesaler] ([WholesalerId])
GO
ALTER TABLE [dbo].[ContactPerson] CHECK CONSTRAINT [FK__ContactPe__Whole__182C9B23]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__ItemId__47DBAE45] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__ItemId__47DBAE45]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__ReplyI__48CFD27E] FOREIGN KEY([ReplyId])
REFERENCES [dbo].[Feedback] ([ID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__ReplyI__48CFD27E]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__Suppli__46E78A0C] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__Suppli__46E78A0C]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__Wholes__45F365D3] FOREIGN KEY([WholesalerId])
REFERENCES [dbo].[Wholesaler] ([WholesalerId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__Wholes__45F365D3]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK__Invoice__Emloyee__3C69FB99] FOREIGN KEY([EmloyeeID])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK__Invoice__Emloyee__3C69FB99]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK__Invoice__Payment__3B75D760] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethod] ([PaymentMethodId])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK__Invoice__Payment__3B75D760]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK__Invoice__Purchas__3A81B327] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK__Invoice__Purchas__3A81B327]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Supplier]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Wholesaler] FOREIGN KEY([WholesalerId])
REFERENCES [dbo].[Wholesaler] ([WholesalerId])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Wholesaler]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK__Item__CategoryId__286302EC] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK__Item__CategoryId__286302EC]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK__Item__ParentItem__2A4B4B5E] FOREIGN KEY([ParentItem])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK__Item__ParentItem__2A4B4B5E]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK__Item__SupplierId__29572725] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK__Item__SupplierId__29572725]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK__Item__UnitId__2B3F6F97] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([UnitId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK__Item__UnitId__2B3F6F97]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseO__Whole__31EC6D26] FOREIGN KEY([WholesalerId])
REFERENCES [dbo].[Wholesaler] ([WholesalerId])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK__PurchaseO__Whole__31EC6D26]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Supplier]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseO__ItemI__35BCFE0A] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK__PurchaseO__ItemI__35BCFE0A]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseO__Purch__34C8D9D1] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK__PurchaseO__Purch__34C8D9D1]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseO__UnitI__36B12243] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([UnitId])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK__PurchaseO__UnitI__36B12243]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK__Supplier__Countr__20C1E124] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK__Supplier__Countr__20C1E124]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK__Supplier__TotalE__1FCDBCEB] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK__Supplier__TotalE__1FCDBCEB]
GO
ALTER TABLE [dbo].[Wholesaler]  WITH CHECK ADD  CONSTRAINT [FK__Wholesale__Count__15502E78] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Wholesaler] CHECK CONSTRAINT [FK__Wholesale__Count__15502E78]
GO
