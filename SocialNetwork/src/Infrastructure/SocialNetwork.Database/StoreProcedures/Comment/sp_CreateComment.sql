USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_CreateComment]
	@PostID UNIQUEIDENTIFIER,
	@UserID UNIQUEIDENTIFIER,
	@Content NVARCHAR(MAX),
	@ActionStatus INT OUTPUT
AS
BEGIN
	SET @ActionStatus = 0;
	DECLARE @CommentID UNIQUEIDENTIFIER = NEWID();

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[Post] WITH (NOLOCK)
			WHERE
				ID = @PostID
				AND IsDeleted = 0
			)
			BEGIN
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				IF NOT EXISTS(
					SELECT TOP 1 1
					FROM [dbo].[User] WITH (NOLOCK)
					WHERE
						ID = @UserID
						AND IsDeleted = 0
					)
					BEGIN
						SET @ActionStatus = -2
					END
				ELSE
					BEGIN
						INSERT INTO [dbo].[Comment]
						(
							ID
							, Content
							, UserID
							, PostID
							, IsDeleted
							, CreatedDate
							, ModifiedDate
						)
						VALUES
						(
							@CommentID
							, @Content
							, @UserID
							, @PostID
							, 0
							, SYSUTCDATETIME()
							, SYSUTCDATETIME()
						)

						SELECT CommentID = @CommentID
					END
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
END