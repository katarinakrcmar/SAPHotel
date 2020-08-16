using SAPHotel.Common;

namespace SAPHotel.Tests
{
    public class TestCase
    {
        public TestCase(
            (int, int) request,
            BookingStatus bookingStatus)
        {
            Request = request;
            BookingStatus = bookingStatus;
        }

        public (int, int) Request { get; }
        public BookingStatus BookingStatus { get; }
    }
}
