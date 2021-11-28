USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [sp_GetAllPostsOfUser]
	@UserID UNIQUEIDENTIFIER,
	@CurrentPage INT,
	@PageSize INT,
	@TotalItems INT OUTPUT
AS
BEGIN
	BEGIN TRY
		-- Count total items in all page
		SELECT @TotalItems = COUNT(p.ID)
		FROM [dbo].[Post] p WITH (NOLOCK)
		WHERE
			p.UserID = @UserID
			AND p.IsDeleted = 0
		-- Get response data in current page
		SELECT
			PostID = p.ID
			, Content = p.Content
			, FeelingStatus = p.FeelingStatus
			, PrivacyStatus = p.PrivacyStatus
			, TotalEmotions = pe.TotalEmotions
			, TotalComments = pc.TotalComments
			, CreatedDate = p.CreatedDate
		FROM [dbo].[Post] p WITH (NOLOCK)
		LEFT JOIN (
			SELECT
				PostID = p.ID 
				, TotalEmotions = COUNT(e.[Status])
			FROM [dbo].[Post] p WITH (NOLOCK)
			LEFT JOIN [dbo].[Emotion] e WITH (NOLOCK)
				ON p.ID = e.PostID
			GROUP BY p.ID
		) AS pe ON p.ID = pe.PostID
		LEFT JOIN (
			SELECT
				PostID = p.ID 
				, TotalComments = COUNT(c.ID)
			FROM [dbo].[Post] p WITH (NOLOCK)
			LEFT JOIN [dbo].[Comment] c WITH (NOLOCK)
				ON p.ID = c.PostID
			GROUP BY p.ID
		) AS pc ON p.ID = pc.PostID
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