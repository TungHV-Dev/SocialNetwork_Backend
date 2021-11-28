USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllComment]
	@PostID UNIQUEIDENTIFIER,
	@CurrentPage INT,
	@PageSize INT,
	@Search NVARCHAR(MAX),
	@Sort NVARCHAR(MAX),
	@TotalItems INT OUTPUT,
	@ActionStatus INT OUTPUT
AS
BEGIN
	-- Set default value for output variables
	BEGIN
		SET @ActionStatus = 0;
		SET @TotalItems = 0;
	END
	-- Declare local variables
	BEGIN
		DECLARE @QueryBuilder NVARCHAR(MAX)
		DECLARE @SortBuilder NVARCHAR(MAX)
	END

	BEGIN TRY
		IF NOT EXISTS(
			SELECT TOP 1 1
			FROM [dbo].[Post] WITH (NOLOCK)
			WHERE
				ID = @PostID
				AND IsDeleted = 0
			)
			BEGIN
				SET @ActionStatus = -1
			END
		ELSE
			BEGIN
				-- Get total items
				SELECT
					@TotalItems = COUNT(c.ID)
				FROM [dbo].[Comment] c WITH (NOLOCK)
				LEFT JOIN [dbo].[User] u WITH (NOLOCK)
					ON c.UserID = u.ID
				WHERE
					c.IsDeleted = 0
					AND u.IsDeleted = 0
				-- Get response data
				SELECT
					CommentID = c.ID
					, UserID = u.ID
					, UserName = u.Username
					, Content = c.Content
					, LastModified = c.ModifiedDate
				FROM [dbo].[Comment] c WITH (NOLOCK)
				LEFT JOIN [dbo].[User] u WITH (NOLOCK)
					ON c.UserID = u.ID
				WHERE
					c.IsDeleted = 0
					AND u.IsDeleted = 0
					AND c.Content LIKE (
						CASE
							WHEN @Search IS NULL THEN '%%'
							ELSE '%' + @Search + '%'
						END
					)
				ORDER BY
				(
					CASE
						WHEN @Sort IS NULL OR @Sort = '' THEN c.CreatedDate
						ELSE @Sort
					END
				)
				OFFSET (@CurrentPage - 1) * @PageSize ROWS
				FETCH NEXT @PageSize ROWS ONLY
			END
	END TRY

	BEGIN CATCH
		SET @ActionStatus = @@ERROR
	END CATCH
END