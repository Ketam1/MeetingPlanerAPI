﻿
namespace API.MeetingPlanner.Frontier.Entities
{
    public class RoomEntity
    {
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public IEnumerable<MeetingEntity> Meetings { get; set; }
    }
}
