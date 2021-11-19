CREATE OR ALTER PROCEDURE [dbo].[sp_RegisterNewUser]
	@FirstName NVARCHAR(255),
	@LastName NVARCHAR(255),
	@UserName NVARCHAR(255),
	@UserEmail NVARCHAR(255),
	@PasswordHash NVARCHAR(MAX),
	@IsPublicAccount BIT,
	@Role NVARCHAR(10)
AS
BEGIN
	-- Declare variables
	BEGIN
		DECLARE @ActionStatus INT = 0;
	END

	BEGIN TRY
		IF EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[User] u WITH (NOLOCK)
			WHERE
				u.Username = @UserName
				AND u.IsDeleted = 0
			)
			BEGIN
				-- Error: User name has already existed
				SET @ActionStatus = -1;
			END
		ELSE
			IF EXISTS(
				SELECT TOP 1 1
				FROM [dbo].[User] u WITH (NOLOCK)
				WHERE
					u.Email = @UserEmail
					AND u.IsDeleted = 0
				)
				BEGIN
					SET @ActionStatus = -2;
				END
			ELSE
				BEGIN
					INSERT INTO [dbo].[User]
					(
						ID
						, FirstName
						, LastName
						, Username
						, PasswordHash
						, Email
						, IsPublicAccount
						, [Role]
						, IsDeleted
						, CreatedDate
						, ModifiedDate
					)
					VALUES
					(
						NEWID()
						, @FirstName
						, @LastName
						, @UserName
						, @PasswordHash
						, @UserEmail
						, @IsPublicAccount
						, @Role
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