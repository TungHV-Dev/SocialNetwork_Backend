USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllPostsInTimeline]
	@JsonData NVARCHAR(MAX),
	@CurrentPage INT,
	@PageSize INT,
	@TotalItems INT OUTPUT
AS
BEGIN
	BEGIN TRY
		IF OBJECT_ID('tempdb..#TmpFriendId') IS NOT NULL
			DROP TABLE #TmpFriendId
		CREATE TABLE #TmpFriendId
		(
			FriendID UNIQUEIDENTIFIER NOT NULL
		)
		
		INSERT INTO #TmpFriendId (FriendID)
		SELECT (ID)
		FROM OPENJSON(@JsonData)
		WITH
		(
			ID UNIQUEIDENTIFIER '$'
		)
		-- Count total records in all pages
		SELECT @TotalItems = COUNT(p.ID)
		FROM [dbo].[Post] p WITH (NOLOCK)
		WHERE
			p.UserID IN (SELECT FriendID FROM #TmpFriendId)
			AND p.IsDeleted = 0
		-- Get records in current page
		SELECT
			PostID = p.ID
			, OwnerID = u.ID
			, OwnerName = u.Username
			, Content = p.Content
			, FeelingStatus = p.FeelingStatus
			, PrivacyStatus = p.PrivacyStatus
			, TotalEmotions = pe.TotalEmotion
			, TotalComments = pc.TotalComment
			, CreatedDate = p.CreatedDate
		FROM [dbo].[Post] p WITH (NOLOCK)
		LEFT JOIN [dbo].[User] u WITH (NOLOCK)
			ON p.UserID = u.ID
		LEFT JOIN (
			SELECT
				PostID = p.ID 
				, TotalComment = COUNT(c.ID)
			FROM [dbo].[Post] p WITH (NOLOCK)
			LEFT JOIN [dbo].[Comment] c WITH (NOLOCK)
				ON p.ID = c.PostID
			GROUP BY p.ID
		) AS pc ON p.ID = pc.PostID
		LEFT JOIN (
			SELECT
				PostID = p.ID
				, TotalEmotion = COUNT(e.[Status])
			FROM [dbo].[Post] p WITH (NOLOCK)
			LEFT JOIN [dbo].[Emotion] e WITH (NOLOCK)
				ON p.ID = e.PostID
			GROUP BY p.ID
		) AS pe ON p.ID = pe.PostID
		WHERE
			p.UserID IN (SELECT FriendID FROM #TmpFriendId)
			AND p.IsDeleted = 0
		ORDER BY CreatedDate DESC
		OFFSET (@CurrentPage - 1) * @PageSize ROWS
		FETCH NEXT @PageSize ROWS ONLY

	END TRY

	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END