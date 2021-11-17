﻿USE [Social_Network_DB]
GO

CREATE TABLE [dbo].[Like]
(
	UserID	UNIQUEIDENTIFIER	NOT NULL,
	PostID	UNIQUEIDENTIFIER	NOT NULL,
	CONSTRAINT FK_UserLike FOREIGN KEY (UserID) REFERENCES [dbo].[User](ID),
	CONSTRAINT FK_PostLike FOREIGN KEY (PostID) REFERENCES [dbo].[Post](ID)
)