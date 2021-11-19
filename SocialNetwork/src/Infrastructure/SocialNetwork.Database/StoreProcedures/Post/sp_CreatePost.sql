CREATE OR ALTER PROCEDURE [dbo].[sp_CreatePost]
	@Content NVARCHAR(MAX),
	@Status TINYINT,
	@UserID UNIQUEIDENTIFIER
AS
BEGIN
	-- Declare variables
	BEGIN
		DECLARE @ActionStatus INT = 0;
	END

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[User] u WITH (NOLOCK)
			WHERE
				u.ID = @UserID
				AND u.IsDeleted = 0
			)
			BEGIN
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				INSERT INTO [dbo].[Post]
				(
					ID
					, Content
					, [Status]
					, UserID
					, IsDeleted
					, CreatedDate
					, ModifiedDate
				)
				VALUES
				(
					NEWID()
					, @Content
					, @Status
					, @UserID
					, 0
					, SYSUTCDATETIME()
					, SYSUTCDATETIME()
				)
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
		PRINT ERROR_MESSAGE()
	END CATCH

	SELECT @ActionStatus
END