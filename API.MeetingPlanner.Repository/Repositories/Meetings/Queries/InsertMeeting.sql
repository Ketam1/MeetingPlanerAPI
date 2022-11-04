INSERT INTO meeting (
	locationId,
	roomId,
	startDate,
	endDate,
	responsibleName,
	coffeeQuantity,
	description
)
VALUES (
    @LocationId
    ,@RoomId
    ,@StartDate
    ,@EndDate
    ,@ResponsibleName
    ,@CoffeeQuantity
	,@Description
)