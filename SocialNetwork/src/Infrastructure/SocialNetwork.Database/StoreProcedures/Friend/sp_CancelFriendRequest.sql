USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_CancelFriendRequest]
	@RequestID UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @ActionStatus INT = 0
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
				UPDATE [dbo].[FriendRequest]
				SET IsDeleted = 1
				WHERE
					ID = @RequestID
					AND IsDeleted = 0
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
	SELECT @ActionStatus
END