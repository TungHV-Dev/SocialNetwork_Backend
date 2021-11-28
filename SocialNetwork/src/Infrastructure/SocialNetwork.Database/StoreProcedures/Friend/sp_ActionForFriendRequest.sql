USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_ActionForFriendRequest]
	@RequestID UNIQUEIDENTIFIER,
	@FriendRequestAction TINYINT
AS
BEGIN
	BEGIN
		DECLARE @ActionStatus INT = 0
		DECLARE @SenderID UNIQUEIDENTIFIER
		DECLARE @ReceiverID UNIQUEIDENTIFIER
	END

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[FriendRequest] fr WITH (NOLOCK)
			WHERE
				fr.ID = @RequestID
				AND fr.IsDeleted = 0
			)
			BEGIN
				-- Friend request does not exist or have been deleted
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				IF EXISTS(
					SELECT TOP 1 1
					FROM [dbo].[FriendRequest] fr WITH (NOLOCK)
					WHERE
						fr.ID = @RequestID
						AND fr.FriendRequestStatus <> 0
						AND fr.IsDeleted = 0
					)
					BEGIN
						-- Friend request is accepted or rejected
						SET @ActionStatus = -2
					END
				ELSE
					BEGIN
						-- Update status in friend request table
						UPDATE [dbo].[FriendRequest]
						SET 
							FriendRequestStatus = @FriendRequestAction
						WHERE
							ID = @RequestID
							AND FriendRequestStatus = 0
							AND IsDeleted = 0
						-- Get sender id and receiver id
						SELECT
							@SenderID = fr.SenderID
							, @ReceiverID = fr.ReceiverID
						FROM [dbo].[FriendRequest] fr WITH (NOLOCK)
						WHERE
							fr.ID = @RequestID
							AND fr.IsDeleted = 0
						-- Insert data into UserFriend table
						INSERT INTO [dbo].[UserFriend]
						(
							UserID
							, FriendID
							, IsDeleted
							, CreatedDate
							, ModifiedDate
						)
						VALUES
						(
							@SenderID
							, @ReceiverID
							, 0
							, SYSUTCDATETIME()
							, SYSUTCDATETIME()
						),
						(
							@ReceiverID
							, @SenderID
							, 0
							, SYSUTCDATETIME()
							, SYSUTCDATETIME()
						)
					END
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
	SELECT @ActionStatus
END