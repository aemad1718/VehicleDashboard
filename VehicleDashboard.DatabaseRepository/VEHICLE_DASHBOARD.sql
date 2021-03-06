CREATE DATABASE [VehicleDashboard];
GO
USE [VehicleDashboard];
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/30/2019 7:57:22 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[Customer]
(
    [Id] [INT] IDENTITY(1, 1) NOT NULL,
    [FullName] [VARCHAR](150) NOT NULL,
    CONSTRAINT [PK_Customer]
        PRIMARY KEY CLUSTERED ([Id] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
              ALLOW_PAGE_LOCKS = ON
             ) ON [PRIMARY]
) ON [PRIMARY];

GO
/****** Object:  Table [dbo].[CustomerAddress]    Script Date: 10/30/2019 7:57:22 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[CustomerAddress]
(
    [Id] [INT] IDENTITY(1, 1) NOT NULL,
    [CustomerId] [INT] NOT NULL,
    [Address] [VARCHAR](150) NOT NULL,
    CONSTRAINT [PK_CustomerAddress]
        PRIMARY KEY CLUSTERED ([Id] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
              ALLOW_PAGE_LOCKS = ON
             ) ON [PRIMARY]
) ON [PRIMARY];

GO
/****** Object:  Table [dbo].[CustomerVehicle]    Script Date: 10/30/2019 7:57:22 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[CustomerVehicle]
(
    [Id] [INT] IDENTITY(1, 1) NOT NULL,
    [CustomerId] [INT] NOT NULL,
    [VehicleId] [INT] NOT NULL,
    CONSTRAINT [PK_CustomerVehicle]
        PRIMARY KEY CLUSTERED ([Id] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
              ALLOW_PAGE_LOCKS = ON
             ) ON [PRIMARY]
) ON [PRIMARY];

GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 10/30/2019 7:57:22 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[Vehicle]
(
    [Id] [INT] IDENTITY(1, 1) NOT NULL,
    [VIN] [VARCHAR](20) NOT NULL,
    [RegNr] [VARCHAR](6) NOT NULL,
    [IsConnected] [BIT] NOT NULL,
    CONSTRAINT [PK_Vehicle]
        PRIMARY KEY CLUSTERED ([Id] ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
              ALLOW_PAGE_LOCKS = ON
             ) ON [PRIMARY]
) ON [PRIMARY];

GO
SET IDENTITY_INSERT [dbo].[Customer] ON;

INSERT [dbo].[Customer]
(
    [Id],
    [FullName]
)
VALUES
(1, N'Kalles Grustransporter');
INSERT [dbo].[Customer]
(
    [Id],
    [FullName]
)
VALUES
(2, N'Johans Bulk');
INSERT [dbo].[Customer]
(
    [Id],
    [FullName]
)
VALUES
(3, N'Haralds Värdetransporter');
SET IDENTITY_INSERT [dbo].[Customer] OFF;
SET IDENTITY_INSERT [dbo].[CustomerAddress] ON;

INSERT [dbo].[CustomerAddress]
(
    [Id],
    [CustomerId],
    [Address]
)
VALUES
(1, 1, N'Cementvägen 8, 111 11 Södertälje');
INSERT [dbo].[CustomerAddress]
(
    [Id],
    [CustomerId],
    [Address]
)
VALUES
(2, 2, N'Balkvägen 12, 222 22 Stockholm');
INSERT [dbo].[CustomerAddress]
(
    [Id],
    [CustomerId],
    [Address]
)
VALUES
(4, 3, N'Budgetvägen 1, 333 33 Uppsala');
SET IDENTITY_INSERT [dbo].[CustomerAddress] OFF;
SET IDENTITY_INSERT [dbo].[CustomerVehicle] ON;

INSERT [dbo].[CustomerVehicle]
(
    [Id],
    [CustomerId],
    [VehicleId]
)
VALUES
(1, 1, 6);
INSERT [dbo].[CustomerVehicle]
(
    [Id],
    [CustomerId],
    [VehicleId]
)
VALUES
(2, 1, 2);
INSERT [dbo].[CustomerVehicle]
(
    [Id],
    [CustomerId],
    [VehicleId]
)
VALUES
(4, 1, 7);
INSERT [dbo].[CustomerVehicle]
(
    [Id],
    [CustomerId],
    [VehicleId]
)
VALUES
(5, 2, 4);
INSERT [dbo].[CustomerVehicle]
(
    [Id],
    [CustomerId],
    [VehicleId]
)
VALUES
(6, 2, 5);
INSERT [dbo].[CustomerVehicle]
(
    [Id],
    [CustomerId],
    [VehicleId]
)
VALUES
(7, 3, 1);
INSERT [dbo].[CustomerVehicle]
(
    [Id],
    [CustomerId],
    [VehicleId]
)
VALUES
(8, 3, 3);
SET IDENTITY_INSERT [dbo].[CustomerVehicle] OFF;
SET IDENTITY_INSERT [dbo].[Vehicle] ON;

INSERT [dbo].[Vehicle]
(
    [Id],
    [VIN],
    [RegNr],
    [IsConnected]
)
VALUES
(1, N'VLUR4X20009048066', N'STU901', 0);
INSERT [dbo].[Vehicle]
(
    [Id],
    [VIN],
    [RegNr],
    [IsConnected]
)
VALUES
(2, N'VLUR4X20009093588', N'DEF456', 0);
INSERT [dbo].[Vehicle]
(
    [Id],
    [VIN],
    [RegNr],
    [IsConnected]
)
VALUES
(3, N'YS2R4X20005387055', N'STU901', 0);
INSERT [dbo].[Vehicle]
(
    [Id],
    [VIN],
    [RegNr],
    [IsConnected]
)
VALUES
(4, N'YS2R4X20005387949', N'MNO345', 0);
INSERT [dbo].[Vehicle]
(
    [Id],
    [VIN],
    [RegNr],
    [IsConnected]
)
VALUES
(5, N'YS2R4X20005388011', N'JKL012', 0);
INSERT [dbo].[Vehicle]
(
    [Id],
    [VIN],
    [RegNr],
    [IsConnected]
)
VALUES
(6, N'YS2R4X20005399401', N'ABC123', 1);
INSERT [dbo].[Vehicle]
(
    [Id],
    [VIN],
    [RegNr],
    [IsConnected]
)
VALUES
(7, N'VLUR4X20009048066', N'GHI789', 0);
SET IDENTITY_INSERT [dbo].[Vehicle] OFF;
ALTER TABLE [dbo].[Vehicle]
ADD CONSTRAINT [DF_Vehicle_IsConnected]
    DEFAULT ((0)) FOR [IsConnected];
GO
ALTER TABLE [dbo].[CustomerAddress] WITH CHECK
ADD CONSTRAINT [FK_CustomerAddress_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer] ([Id]);
GO
ALTER TABLE [dbo].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress_Customer];
GO
ALTER TABLE [dbo].[CustomerVehicle] WITH CHECK
ADD CONSTRAINT [FK_CustomerVehicle_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer] ([Id]);
GO
ALTER TABLE [dbo].[CustomerVehicle] CHECK CONSTRAINT [FK_CustomerVehicle_Customer];
GO
ALTER TABLE [dbo].[CustomerVehicle] WITH CHECK
ADD CONSTRAINT [FK_CustomerVehicle_Vehicle]
    FOREIGN KEY ([VehicleId])
    REFERENCES [dbo].[Vehicle] ([Id]);
GO
ALTER TABLE [dbo].[CustomerVehicle] CHECK CONSTRAINT [FK_CustomerVehicle_Vehicle];
GO
