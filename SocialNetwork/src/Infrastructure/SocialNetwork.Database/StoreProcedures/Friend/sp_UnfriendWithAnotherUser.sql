USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_UnfriendWithAnotherUser]
	@UserID UNIQUEIDENTIFIER,
	@FriendID UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @ActionStatus INT = 0
	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[User] u WITH (NOLOCK)
			WHERE
				u.ID = @FriendID
				AND u.IsDeleted = 0
			)
			BEGIN
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				IF NOT EXISTS(
					SELECT TOP 1 1
					FROM [dbo].[UserFriend] uf WITH (NOLOCK)
					WHERE
						uf.UserID = @UserID
						AND uf.FriendID = @FriendID
						AND uf.IsDeleted = 0
					)
					BEGIN
						SET @ActionStatus = -2
					END
				ELSE
					BEGIN
						UPDATE [dbo].[UserFriend]
						SET
							IsDeleted = 1
							, ModifiedDate = SYSUTCDATETIME()
						WHERE
							UserID = @UserID
							AND FriendID = @FriendID
						
						UPDATE [dbo].[UserFriend]
						SET
							IsDeleted = 1
							, ModifiedDate = SYSUTCDATETIME()
						WHERE
							UserID = @FriendID
							AND FriendID = @UserID
					END
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
	SELECT @ActionStatus
END