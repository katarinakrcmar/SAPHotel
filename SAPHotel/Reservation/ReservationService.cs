using SAPHotel.RoomBooking;
using SAPHotel.RoomFinding;
using SAPHotel.Common;

namespace SAPHotel.Reservation
{
    public class ReservationService : IReservationService
    {
        private readonly IRoomFindingService roomFinding;
        private readonly IRoomBookingService roomBooking;
        private readonly Hotel hotel;

        public ReservationService(
            Hotel hotel,
            IRoomFindingService roomFinding,
            IRoomBookingService roomBooking)
        {
            this.hotel = hotel;
            this.roomBooking = roomBooking;
            this.roomFinding = roomFinding;
        }

        public BookingStatus TryToMakeAReservation((int startDate, int endDate) bookingRequest)
        {
            var bookingResponse = roomFinding.TryToFindAvailableRoom(hotel, bookingRequest);

            if (bookingResponse.BookingStatus == BookingStatus.Accept)
            {
                roomBooking.Book(hotel, bookingResponse.Room.Value, bookingRequest);
            }

            return bookingResponse.BookingStatus;
        }
    }
}
