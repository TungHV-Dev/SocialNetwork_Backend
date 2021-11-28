USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetUserById]
	@UserID UNIQUEIDENTIFIER,
	@ActionStatus INT OUTPUT
AS
BEGIN
	SET @ActionStatus = 0
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
				SELECT
					UserName = u.Username
					, Email = u.Email
					, [Role] = u.[Role]
					, CreatedDate = u.CreatedDate
				FROM [dbo].[User] u WITH (NOLOCK)
				WHERE
					u.ID = @UserID
					AND u.IsDeleted = 0
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
END