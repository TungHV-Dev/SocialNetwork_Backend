﻿USE [Social_Network_DB]
GO

CREATE TABLE [dbo].[Emotion]
(
	UserID		UNIQUEIDENTIFIER	NOT NULL,
	PostID		UNIQUEIDENTIFIER	NOT NULL,
	[Status]	TINYINT				NOT NULL,
)