using SAPHotel.RoomBooking;
using SAPHotel.RoomFinding;
using SAPHotel.Common;
using SAPHotel.Reservation;

namespace SAPHotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // For a booking request validation (cross-cutting concern) decorator design pattern is used        
            new ReservationServiceDecorator(
                new ReservationService(
                    new Hotel(10), 
                    new RoomFindingService(), 
                    new RoomBookingService()),
                new BookingRequestValidator());
        }
    }
}
