namespace SAPHotel.Reservation
{
    public class BookingRequestValidator : IBookingRequestValidator
    {
        public bool IsValidBookingRequest((int startDate, int endDate) bookingRequest)
        {
            return bookingRequest.startDate <= bookingRequest.endDate 
                && bookingRequest.startDate >= 0 && bookingRequest.endDate < 365;
        }
    }
}
