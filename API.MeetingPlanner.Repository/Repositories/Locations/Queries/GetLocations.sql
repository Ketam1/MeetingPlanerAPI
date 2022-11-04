SELECT 
	me.locationId AS LocationId,
    lo.locationName AS LocationName,
    me.roomId AS RoomId,
    ro.roomName AS RoomName,
    me.meetingID AS MeetingId,
    me.startDate AS StartDate,
    me.endDate as EndDate,
    me.responsibleName as ResponsibleName,
    me.coffeeQuantity as CoffeeQuantity
FROM location AS lo
JOIN room AS ro
	ON ro.locationId = lo.locationId
JOIN meeting AS me
	ON me.roomId = ro.roomId AND me.locationId = lo.locationId