SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE uspGetPersonsByOrderDate
	@orderDate DATETIME
AS
BEGIN

	SET NOCOUNT ON;
	
	select p.PersonId, p.NameFirst, p.NameLast
	from dbo.Person p
		inner join dbo.[Order] o on p.PersonId = o.PersonId
	where o.OrderDateTime = @orderDate

END
GO