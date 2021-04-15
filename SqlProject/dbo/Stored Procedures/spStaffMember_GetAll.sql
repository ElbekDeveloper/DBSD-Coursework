CREATE PROCEDURE [dbo].[spStaffMember_GetAll]
AS
BEGIN 
	SELECT [Id] as StaffMemberId, [FirstName], [LastName], [Address], [Email], [RegisterDate], [PhoneNumber] from dbo.StaffMember;
END

