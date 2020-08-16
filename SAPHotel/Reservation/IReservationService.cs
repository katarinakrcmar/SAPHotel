using SAPHotel.Common;

namespace SAPHotel.Reservation
{
    public interface IReservationService
    {

        BookingStatus TryToMakeAReservation((int startDate, int endDate) bookingRequest);
    }
}
