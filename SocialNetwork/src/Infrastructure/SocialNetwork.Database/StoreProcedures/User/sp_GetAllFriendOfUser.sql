USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllFriendOfUser]
	@UserID UNIQUEIDENTIFIER,
	@ActionStatus INT OUTPUT
AS
BEGIN
	SET @ActionStatus = 0;
	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[User] WITH (NOLOCK)
			WHERE
				ID = @UserID
				AND IsDeleted = 0
			)
			BEGIN
				-- User does not exist
				SET @ActionStatus = -1
			END
		ELSE
			IF EXISTS(
				SELECT TOP 1 1
				FROM [dbo].[User] WITH (NOLOCK)
				WHERE
					ID = @UserID
					AND IsDeleted = 0
					AND IsPublicAccount = 0
				)
				BEGIN
					-- This account is a private account
					SET @ActionStatus = -2
				END
			ELSE
				BEGIN
					SELECT
						FriendID = uf.FriendID
						, FriendName = u.Username
						, StartDate = uf.CreatedDate
					FROM [dbo].[UserFriend] uf WITH (NOLOCK)
					LEFT JOIN [dbo].[User] u WITH (NOLOCK)
						ON uf.FriendID = u.ID
					WHERE
						uf.UserID = @UserID
						AND uf.IsDeleted = 0
						AND u.IsDeleted = 0
				END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
END