USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [sp_ChangePassword]
	@UserName NVARCHAR(255),
	@NewPasswordHash NVARCHAR(MAX)
AS
BEGIN
	DECLARE @ActionStatus INT = 0;

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[User] u WITH (NOLOCK)
			WHERE
				u.Username = @UserName
				AND u.IsDeleted = 0
			)
			BEGIN
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				UPDATE [dbo].[User]
				SET
					PasswordHash = @NewPasswordHash
					, ModifiedDate = SYSUTCDATETIME()
				WHERE
					Username = @UserName
					AND IsDeleted = 0
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH

	SELECT @ActionStatus
END