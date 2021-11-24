USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_EditPost]
	@UserID UNIQUEIDENTIFIER,
	@PostID UNIQUEIDENTIFIER,
	@Content NVARCHAR(MAX),
	@Status TINYINT
AS
BEGIN
	DECLARE @ActionStatus INT = 0;

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[User] u WITH (NOLOCK)
			WHERE
				u.ID = @UserID
				AND u.IsDeleted = 0
			)
			BEGIN
				-- Error: User id does not exist
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				IF NOT EXISTS(
					SELECT TOP 1 1
					FROM [dbo].[Post] p WITH (NOLOCK)
					WHERE
						p.ID = @PostID
						AND p.UserID = @UserID
						AND p.IsDeleted = 0
					)
					BEGIN
						-- Post id does not exist
						SET @ActionStatus = -2
					END
				ELSE
					BEGIN
						UPDATE [dbo].[Post]
						SET
							Content = @Content
							, [Status] = @Status
							, ModifiedDate = SYSUTCDATETIME()
						WHERE
							ID = @PostID
							AND UserID = @UserID
							AND IsDeleted = 0
					END
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH

	SELECT @ActionStatus
END