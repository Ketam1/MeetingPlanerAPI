UPDATE meeting 
    SET 
        title = @Title
        ,startDate = @StartDate
        ,endDate = @EndDate
        ,responsibleName = @ResponsibleName
        ,coffeeQuantity = @CoffeeQuantity
        ,description = @Description
    WHERE
        meetingId = @MeetingId
