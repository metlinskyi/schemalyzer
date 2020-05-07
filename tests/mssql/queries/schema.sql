DROP DATABASE IF EXISTS [A]
CREATE DATABASE [A]
GO

USE [A]
GO

CREATE SCHEMA [Dictionary]
GO
CREATE SCHEMA [Data] 
GO
CREATE SCHEMA [Entity] 
GO

CREATE TABLE [Dictionary].[GenderType](
	[Key] TINYINT NOT NULL,
	[Value] NVARCHAR(20),
    [Active] BIT NOT NULL DEFAULT 1,
	CONSTRAINT PK_Dictionary_Gender
		PRIMARY KEY CLUSTERED ([Key]) 
		ON [PRIMARY],
)

CREATE TABLE [Dictionary].[ContactType](
	[Key] TINYINT NOT NULL,
	[Value] NVARCHAR(20),
    [Active] BIT NOT NULL DEFAULT 1,
	CONSTRAINT PK_Dictionary_ContactType
		PRIMARY KEY CLUSTERED ([Key]) 
		ON [PRIMARY],
)

CREATE TABLE [Data].[Profile](
	[Id] UNIQUEIDENTIFIER DEFAULT NEWID(),
	[FirstName] NVARCHAR(50),
    [LastName] NVARCHAR(50),
	[DateOfBirth] DATE,
	[Gender] TINYINT,
    [Active] BIT NOT NULL DEFAULT 1,
	CONSTRAINT PK_Data_Profile
		PRIMARY KEY CLUSTERED ([Id]) 
		ON [PRIMARY],
)

CREATE TABLE [Data].[Contact](
	[Id] UNIQUEIDENTIFIER DEFAULT NEWID(),
	[Type] TINYINT NOT NULL,
	[Value] NVARCHAR(1000) NOT NULL,
	[Active] BIT NOT NULL DEFAULT 1,
	CONSTRAINT PK_Data_Contact
		PRIMARY KEY CLUSTERED ([Id]) 
		ON [PRIMARY],
)

CREATE TABLE [Entity].[User](
	[Id] UNIQUEIDENTIFIER DEFAULT NEWID(),
	[ProfileId] UNIQUEIDENTIFIER,
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[Active] BIT NOT NULL DEFAULT 1, 
	CONSTRAINT PK_Entity_User
		PRIMARY KEY CLUSTERED ([Id]) 
		ON [PRIMARY],
)

CREATE TABLE [Entity].[UserContact](
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[ContactId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[Active] BIT NOT NULL DEFAULT 1, 
	CONSTRAINT PK_Entity_UserContact
		PRIMARY KEY CLUSTERED ([Id]) 
		ON [PRIMARY],
)
GO

CREATE VIEW [Entity].[Customers]
AS  
SELECT u.[Id], p.[FirstName], p.[LastName], p.[DateOfBirth], p.[Gender]
FROM [Entity].[User] AS u 
LEFT JOIN [Data].[Profile] p ON p.[Id] = u.[ProfileId] AND p.[Active] = 1 
WHERE u.[Active] = 1 
GO

CREATE VIEW [Entity].[CustomerContacts] 
AS  
SELECT uc.[Id], u.[Id] [CustomerId], c.[Type], c.[Value]
FROM [Entity].[UserContact] AS uc 
JOIN [Entity].[User] u ON u.[Id] = uc.[UserId] AND u.[Active] = 1 
JOIN [Data].[Contact] c ON c.[Id] = uc.[ContactId] AND c.[Active] = 1 
WHERE uc.[Active] = 1 
GO

CREATE PROCEDURE [Entity].[CustomerContactsInsert]
	@CustomerId UNIQUEIDENTIFIER,
    @Type TINYINT,   
    @Value NVARCHAR(1000)
AS   
	DECLARE @Id UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Data].[Contact] ([Id], [Type], [Value])
	VALUES(@Id, @Type, @Value)

	INSERT INTO [Entity].[UserContact]([UserId],[ContactId])
	SELECT u.[Id], @Id  
	FROM [Entity].[User] AS u
	WHERE u.[Active] = 1 AND u.Id = @CustomerId 
GO 

DROP DATABASE IF EXISTS [DEBUG]
CREATE DATABASE [DEBUG]
GO

CREATE TABLE [FK_TABLE](
	[FK_COLUMN] INT NOT NULL,
)

CREATE TABLE [PK_TABLE](
	[PK_COLUMN] INT NOT NULL,
)

