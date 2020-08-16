namespace SAPHotel.Common
{
    public class BookingResponse
    {
        public BookingResponse(int room)
        {
            Room = room;
            BookingStatus = BookingStatus.Accept;
        }

        public BookingResponse()
        {
            BookingStatus = BookingStatus.Decline;
        }

        public int? Room { get; }
        public BookingStatus BookingStatus { get; }
    }
}
