USE [PollOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spDeletePoll')
DROP PROCEDURE [spDeletePoll]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeletePoll]
	 @PollId BIGINT,
	 @IsDeletePoll BIT
        AS
        BEGIN
		SET NOCOUNT ON;
		BEGIN TRY
        BEGIN TRANSACTION;
			
			DELETE FROM [PollOperational].dbo.PollOptions WHERE PollId = @PollId;

			IF(@IsDeletePoll = 1)
			BEGIN
				DELETE FROM [PollOperational].dbo.Polls WHERE PollId = @PollId;
			END

		COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH
        END
GO