﻿USE [Social_Network_DB]
GO

CREATE TABLE [dbo].[User]
(
	ID				UNIQUEIDENTIFIER	NOT NULL PRIMARY KEY,
	FirstName		NVARCHAR(255)		NOT NULL,
	LastName		NVARCHAR(255)		NOT NULL,
	Username		NVARCHAR(255)		NOT NULL,
	PasswordHash	NVARCHAR(MAX)		NOT NULL,
	Email			NVARCHAR(255)		NOT NULL,
	IsPublicAccount	BIT					NOT NULL,
	[Role]			NVARCHAR(255)		NOT NULL,
	IsDeleted		BIT					NOT NULL,
	CreatedDate		DATETIME			NOT NULL,
	ModifiedDate	DATETIME			NOT NULL
)