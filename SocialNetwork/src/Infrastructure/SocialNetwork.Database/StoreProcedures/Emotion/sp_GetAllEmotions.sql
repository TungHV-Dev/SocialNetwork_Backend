USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllEmotions]
	@PostID UNIQUEIDENTIFIER,
	@TotalItems INT OUTPUT,
	@ActionStatus INT OUTPUT
AS
BEGIN
	SET @TotalItems = 0;
	SET @ActionStatus = 0;

	BEGIN TRY
		BEGIN
			IF NOT EXISTS(
				SELECT TOP 1 1
				FROM [dbo].[Post] WITH (NOLOCK)
				WHERE
					ID = @PostID
					AND IsDeleted = 0
				)
				BEGIN
					-- Post id does not exist
					SET @ActionStatus = -1
				END
			ELSE
				BEGIN
					-- Get number of emotions
					SELECT @TotalItems = COUNT(e.UserID)
					FROM [dbo].[Emotion] e WITH (NOLOCK)
					WHERE
						e.PostID = @PostID
					-- Get response data
					SELECT
						UserID = e.UserID
						, UserName = u.Username
						, [Status] = e.[Status]
					FROM [dbo].[Emotion] e WITH (NOLOCK)
					LEFT JOIN [dbo].[User] u WITH (NOLOCK)
						ON e.UserID = u.ID
					WHERE
						e.PostID = @PostID
						AND u.IsDeleted = 0
				END
		END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO