USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_ExpressEmotion]
	@UserID UNIQUEIDENTIFIER,
	@PostID UNIQUEIDENTIFIER,
	@EmotionStatus TINYINT
AS
BEGIN
	DECLARE @ActionStatus INT = 0

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[User] WITH (NOLOCK)
			WHERE
				ID = @UserID
				AND IsDeleted = 0
			)
			BEGIN
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				IF NOT EXISTS(
					SELECT TOP 1 1
					FROM [dbo].[Post] WITH (NOLOCK)
					WHERE
						ID = @PostID
						AND IsDeleted = 0
					)
					BEGIN
						SET @ActionStatus = -2
					END
				ELSE
					BEGIN
						INSERT INTO [dbo].[Emotion]
						(
							UserID
							, PostID
							, [Status]
						)
						VALUES
						(
							@UserID
							, @PostID
							, @EmotionStatus
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