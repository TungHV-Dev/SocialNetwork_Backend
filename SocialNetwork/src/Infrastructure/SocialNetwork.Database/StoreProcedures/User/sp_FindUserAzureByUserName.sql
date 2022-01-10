USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_FindUserAzureByUserName]
	@UserName NVARCHAR(255),
	@ActionStatus INT OUTPUT
AS
BEGIN
	-- Set the default value for action status variable
	BEGIN
		SET @ActionStatus = 0
	END

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[UserAzureAD] u WITH (NOLOCK)
			WHERE
				u.UserName = @UserName
				AND u.IsDeleted = 0
			)
			BEGIN
				-- Error: User name does not exist
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				SELECT
					UserID = u.ID
					, UserName = u.Username
					, Email = u.Email
					, [Role] = u.[Role]
				FROM [dbo].[UserAzureAD] u WITH (NOLOCK)
				WHERE
					u.UserName = @UserName
					AND u.IsDeleted = 0
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
END