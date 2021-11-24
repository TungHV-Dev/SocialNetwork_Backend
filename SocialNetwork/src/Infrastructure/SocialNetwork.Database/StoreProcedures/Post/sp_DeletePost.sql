USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_DeletePost]
	@PostID UNIQUEIDENTIFIER,
	@UserID UNIQUEIDENTIFIER
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
						AND p.IsDeleted = 0
					)
					BEGIN
						-- Error: Post id does not exist
						SET @ActionStatus = -2
					END
				ELSE
					BEGIN
						UPDATE [dbo].[Post]
						SET
							IsDeleted = 1
							, ModifiedDate = SYSUTCDATETIME()
						WHERE
							ID = @PostID
							AND IsDeleted = 0
					END
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO