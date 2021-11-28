USE [Social_Network_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllUser]
AS
BEGIN
	BEGIN TRY
		SELECT
			ID = u.ID
			, FirstName = u.FirstName
			, LastName = u.LastName
			, UserName = u.UserName
			, Email = u.Email
			, [Role] = u.[Role]
			, TotalPosts = COUNT(p.ID)
		FROM [dbo].[User] u WITH (NOLOCK)
		LEFT JOIN [dbo].[Post] p WITH (NOLOCK)
			ON u.ID = p.UserID
		WHERE
			u.IsDeleted = 0
		GROUP BY u.ID, u.FirstName, u.LastName, u.UserName, u.Email, u.[Role]
	END TRY

	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END