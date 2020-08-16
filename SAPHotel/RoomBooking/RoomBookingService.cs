using SAPHotel.Common;

namespace SAPHotel.RoomBooking
{
    public class RoomBookingService : IRoomBookingService
    {
        public void Book(
            Hotel hotel,
            int room,
            (int startDate, int endDate) bookingRequest)
        {
            for (int day = bookingRequest.startDate; day <= bookingRequest.endDate; day++)
            {
                hotel.Rooms[room, day] = true;
            }
        }
    }
}
