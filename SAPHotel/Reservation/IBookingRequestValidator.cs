namespace SAPHotel.Reservation
{
    public interface IBookingRequestValidator
    {
        bool IsValidBookingRequest((int startDate, int endDate) bookingRequest);
    }
}
