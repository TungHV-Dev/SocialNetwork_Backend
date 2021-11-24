USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_CreatePost]
	@Content NVARCHAR(MAX),
	@Status TINYINT,
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
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				-- Insert new post to Post table
				INSERT INTO [dbo].[Post]
				(
					ID
					, Content
					, [Status]
					, UserID
					, IsDeleted
					, CreatedDate
					, ModifiedDate
				)
				VALUES
				(
					@PostID
					, @Content
					, @Status
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