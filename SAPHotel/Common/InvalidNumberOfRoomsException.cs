using System;

namespace SAPHotel.Common
{
    internal class InvalidNumberOfRoomsException : Exception
    {
        public InvalidNumberOfRoomsException(string message) : base(message)
        {
        }
    }
}