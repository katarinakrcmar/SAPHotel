using SAPHotel.Common;

namespace SAPHotel.Reservation
{
    public class ReservationServiceDecorator : IReservationService
    {
        private readonly IReservationService reservationService;
        private readonly IBookingRequestValidator bookingRequestValidator;

        public ReservationServiceDecorator(
            IReservationService reservation,
            IBookingRequestValidator bookingRequestValidator)
        {
            this.reservationService = reservation;
            this.bookingRequestValidator = bookingRequestValidator;
        }

        public BookingStatus TryToMakeAReservation((int startDate, int endDate) bookingRequest)
        {
            if (!bookingRequestValidator
                .IsValidBookingRequest(bookingRequest))
            {
                return BookingStatus.Decline;
            }

            return reservationService.TryToMakeAReservation(bookingRequest);
        }
    }
}
