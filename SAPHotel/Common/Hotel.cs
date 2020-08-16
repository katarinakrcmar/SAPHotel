namespace SAPHotel.Common
{
    public class Hotel
    {
        public Hotel(int numberOfRooms)
        {
            if (!IsValidNumberOfRooms(numberOfRooms))
            {
                throw new InvalidNumberOfRoomsException("Number of rooms should be >0 and <= to 1000");
            }

            Rooms = new bool[numberOfRooms, 365];
            NumberOfRooms = numberOfRooms;
        }

        public bool[,] Rooms { get; set; }

        public int NumberOfRooms { get; }

        private bool IsValidNumberOfRooms(int numberOfRooms)
        {
            return (numberOfRooms > 0 && numberOfRooms <= 1000);
        }
    }
}
