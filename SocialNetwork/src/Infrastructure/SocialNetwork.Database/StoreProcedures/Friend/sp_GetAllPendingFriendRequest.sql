USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllPendingFriendRequest]
	@UserID UNIQUEIDENTIFIER,
	@TotalItems INT OUTPUT
AS
BEGIN
	BEGIN TRY
		-- Get total items to response
		SELECT @TotalItems = COUNT(fr.ID)
		FROM [dbo].[FriendRequest] fr WITH (NOLOCK)
		WHERE
			fr.ReceiverID = @UserID
			AND fr.FriendRequestStatus = 0
			AND fr.IsDeleted = 0
		-- Get pending requests detail
		SELECT
			RequestID = fr.ID
			, SenderID = u.ID
			, SenderName = u.Username
			, SentDate = fr.CreatedDate
		FROM [dbo].[FriendRequest] fr WITH (NOLOCK)
		LEFT JOIN [dbo].[User] u WITH (NOLOCK)
			ON fr.SenderID = u.ID
		WHERE
			fr.ReceiverID = @UserID
			AND fr.FriendRequestStatus = 0
			AND fr.IsDeleted = 0
			AND u.IsDeleted = 0
	END TRY

	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END