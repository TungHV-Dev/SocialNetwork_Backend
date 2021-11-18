﻿USE [Social_Network_DB]
GO

CREATE TABLE [dbo].[Comment]
(
	ID		UNIQUEIDENTIFIER	NOT NULL PRIMARY KEY,
	Content	NVARCHAR(MAX)		NOT NULL,
	UserID	UNIQUEIDENTIFIER	NOT NULL,
	PostID	UNIQUEIDENTIFIER	NOT NULL,
	IsDeleted		BIT			NOT NULL,
	CreatedDate		DATETIME	NOT NULL,
	ModifiedDate	DATETIME	NOT NULL
)