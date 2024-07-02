USE [UserOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetUserDetails')
DROP PROCEDURE [spGetUserDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUserDetails]
	 @UserId BIGINT = NULL
        AS
        BEGIN

		DECLARE @SqlQuery NVARCHAR(MAX)
		DECLARE @FilterCondition NVARCHAR(100)

		IF(@UserId IS NOT NULL AND @UserId > 0)
		BEGIN
			SET @FilterCondition = ' WHERE U.UserId = ' + CAST(@UserId AS NVARCHAR(20))
		END
		ELSE
		BEGIN
			SET @FilterCondition = ''
		END

		SET @SqlQuery = 'SELECT 
						U.UserId,
						U.Username,
						U.Email,
						U.LastLogin,
						U.CreatedDate,
						U.IsActive,
						U.IsVerified,
						R.RoleId,
						R.RoleName,
						UD.UserDetailId,
						UD.FirstName,
						UD.LastName,
						UD.ProfileImage,
						UD.UserBio,
						UD.Gender,
						C.CountryId,
						C.CountryName Country,
						S.StateId,
						S.StateName State,
						UD.Region,
						UD.FollowersCount,
						U.CreatedBy,
						U.ModifiedBy,
						U.ModifiedDate
						FROM [UserOperational].dbo.Users U
						INNER JOIN [UserOperational].dbo.UserDetails UD ON UD.UserId = U.UserId
						INNER JOIN [UserOperational].dbo.Countries C ON C.CountryId = UD.CountryId
						INNER JOIN [UserOperational].dbo.States S ON S.StateId = UD.StateId AND S.CountryId = UD.CountryId
						INNER JOIN [UserOperational].dbo.Roles R ON R.ROleId = U.RoleId' + @FilterCondition

		EXEC sp_executesql @SqlQuery

        END
GO