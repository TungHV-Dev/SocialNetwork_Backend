USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllPosts]
	@UserID UNIQUEIDENTIFIER,
	@CurrentPage INT,
	@PageSize INT,
	@TotalItems INT OUTPUT
AS
BEGIN
	BEGIN TRY
		-- Count total records in all pages
		SELECT @TotalItems = COUNT(p.ID)
		FROM [dbo].[Post] p WITH (NOLOCK)
		WHERE
			p.UserID = @UserID
			AND p.IsDeleted = 0
		-- Get records in current page
		SELECT
			PostID = p.ID
			, Content = p.Content
			, [Status] = p.[Status]
			, CreatedDate = p.CreatedDate
		FROM [dbo].[Post] p WITH (NOLOCK)
		WHERE
			p.UserID = @UserID
			AND p.IsDeleted = 0
		ORDER BY CreatedDate DESC
		OFFSET (@CurrentPage - 1) * @PageSize ROWS
		FETCH NEXT @PageSize ROWS ONLY

	END TRY

	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END