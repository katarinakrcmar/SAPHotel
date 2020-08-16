using SAPHotel.Common;

namespace SAPHotel.RoomFinding
{
    public interface IRoomFindingService
    {
        BookingResponse TryToFindAvailableRoom(
            Hotel hotel,
            (int startDate, int endDate) bookingRequest);
    }
}