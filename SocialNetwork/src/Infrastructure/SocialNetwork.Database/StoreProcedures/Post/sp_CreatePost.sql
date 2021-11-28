USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_CreatePost]
	@Content NVARCHAR(MAX),
	@FeelingStatus TINYINT,
	@PrivacyStatus TINYINT,
	@UserID UNIQUEIDENTIFIER,
	@ActionStatus INT OUTPUT
AS
BEGIN
	SET @ActionStatus = 0;
	DECLARE @PostID UNIQUEIDENTIFIER = NEWID()
	
	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[User] u WITH (NOLOCK)
			WHERE
				u.ID = @UserID
				AND u.IsDeleted = 0
			)
			BEGIN
				-- User id does not exist
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				-- Insert new post to Post table
				INSERT INTO [dbo].[Post]
				(
					ID
					, Content
					, FeelingStatus
					, PrivacyStatus
					, UserID
					, IsDeleted
					, CreatedDate
					, ModifiedDate
				)
				VALUES
				(
					@PostID
					, @Content
					, @FeelingStatus
					, @PrivacyStatus
					, @UserID
					, 0
					, SYSUTCDATETIME()
					, SYSUTCDATETIME()
				)
				-- Return value
				SELECT PostID = @PostID
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO