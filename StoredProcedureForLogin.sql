
CREATE PROCEDURE [dbo].[sp_UserLogin]
	@Username AS NVARCHAR(50)

as
begin
	SELECT UserID, PasswordHash 
	From dbo.Pass
	WHERE Username=@Username
END;

