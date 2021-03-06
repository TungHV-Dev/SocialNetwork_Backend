USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_EditComment]
	@CommentID UNIQUEIDENTIFIER,
	@Content NVARCHAR(MAX)
AS
BEGIN
	DECLARE @ActionStatus INT = 0;

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[Comment] WITH (NOLOCK)
			WHERE
				ID = @CommentID
				AND IsDeleted = 0
			)
			BEGIN
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				UPDATE [dbo].[Comment]
				SET
					Content = @Content
					, ModifiedDate = SYSUTCDATETIME()
				WHERE
					ID = @CommentID
					AND IsDeleted = 0
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH
	SELECT @ActionStatus
END