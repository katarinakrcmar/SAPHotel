using SAPHotel.Common;

namespace SAPHotel.RoomFinding
{
    public class RoomFindingService : IRoomFindingService
    {
        public BookingResponse TryToFindAvailableRoom(
            Hotel hotel,
            (int startDate, int endDate) bookingRequest)
        {
            for (int room = 0; room < hotel.NumberOfRooms; room++)
            {
                for (int day = bookingRequest.startDate; day <= bookingRequest.endDate; day++)
                {
                    // We continue to the next room as soon as we find out that a room is booked for the requested day
                    if (!hotel.Rooms[room, day])
                    {
                        if (day == bookingRequest.endDate)
                        {
                            return new BookingResponse(room);
                        }
                        continue;
                    }
                    break;
                }
            }

            return new BookingResponse();
        }
    }
}
