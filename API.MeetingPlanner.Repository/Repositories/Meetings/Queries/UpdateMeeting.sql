UPDATE meeting 
    SET 
        locationId = @LocationId
        ,roomId = @RoomId
        ,startDate = @StartDate
        ,endDate = @EndDate
        ,responsibleName = @ResponsibleName
        ,coffeeQuantity = @CoffeeQuantity
        ,description = @Description
    WHERE
        meetingId = @MeetingId
