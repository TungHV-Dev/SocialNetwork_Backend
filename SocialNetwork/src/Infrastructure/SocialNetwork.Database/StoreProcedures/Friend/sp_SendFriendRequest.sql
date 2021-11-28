USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [sp_SendFriendRequest]
	@SenderID UNIQUEIDENTIFIER,
	@ReceiverID UNIQUEIDENTIFIER,
	@FriendRequestStatus TINYINT,
	@ActionStatus INT OUTPUT
AS
BEGIN
	SET @ActionStatus = 0;
	DECLARE @RequestID UNIQUEIDENTIFIER = NEWID();

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[User] u WITH (NOLOCK)
			WHERE
				u.ID = @ReceiverID
				AND u.IsDeleted = 0
			)
			BEGIN
				-- Receiver id does not exist
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				IF EXISTS(
					SELECT TOP 1 1
					FROM [dbo].[FriendRequest] fr WITH (NOLOCK)
					WHERE
						fr.SenderID = @SenderID
						AND fr.ReceiverID = @ReceiverID
						AND fr.FriendRequestStatus <> 2
						AND fr.IsDeleted = 0
					)
					BEGIN
						-- Your request is pending or you and receiver have been friends
						SET @ActionStatus = -2
					END
				ELSE
					BEGIN
						-- Insert request information into table
						INSERT INTO [dbo].[FriendRequest]
						(
							ID
							, SenderID
							, ReceiverID
							, FriendRequestStatus
							, IsDeleted
							, CreatedDate
							, ModifiedDate
						)
						VALUES
						(
							@RequestID
							, @SenderID
							, @ReceiverID
							, @FriendRequestStatus
							, 0
							, SYSUTCDATETIME()
							, SYSUTCDATETIME()
						)
						-- Return data
						SELECT RequestID = @RequestID
					END
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
END