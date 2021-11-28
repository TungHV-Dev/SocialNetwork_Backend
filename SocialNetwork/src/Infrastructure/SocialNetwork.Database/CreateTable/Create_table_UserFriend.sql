﻿USE [Social_Network_DB]
GO

CREATE TABLE [dbo].[UserFriend]
(
	UserID		UNIQUEIDENTIFIER	NOT NULL,
	FriendID	UNIQUEIDENTIFIER	NOT NULL,
	IsDeleted			BIT			NOT NULL,
	CreatedDate			DATETIME	NOT NULL,
	ModifiedDate		DATETIME	NOT NULL
)