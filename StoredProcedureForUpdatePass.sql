CREATE PROCEDURE [dbo].[sp_updateLogin]
	@Username AS NVARCHAR(50),
	@PasswordHash AS NVARCHAR(100)
as
begin
	UPDATE dbo.Pass
	SET Username = @Username, PasswordHash = @PasswordHash
end;