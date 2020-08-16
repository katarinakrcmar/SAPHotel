using SAPHotel.Common;

namespace SAPHotel.RoomBooking
{
    public interface IRoomBookingService
    {
        void Book(
            Hotel hotel,
            int room,
            (int startDate, int endDate) bookingRequest);
    }
}