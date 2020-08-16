using SAPHotel.Common;
using SAPHotel.RoomFinding;
using Xunit;

namespace SAPHotel.Tests.RoomFinding
{
    public class RoomFindingServiceTests
    {
        private readonly IRoomFindingService roomFindingService;
        private readonly Hotel hotel;

        public RoomFindingServiceTests()
        {
            roomFindingService = new RoomFindingService();
            hotel = new Hotel(2);
        }

        [Fact(DisplayName = "When we do not have available room for requested dates Then BookingStatus is decline")]
        public void Given_Request_When_RoomIsUnavailableForGivenDataRange_Then_BookingStatusIsDecline()
        {
            // Arrange
            hotel.Rooms[0, 0] = true;
            hotel.Rooms[0, 1] = true;
            hotel.Rooms[1, 0] = true;
            hotel.Rooms[1, 1] = true;

            // Act
            var status = roomFindingService.TryToFindAvailableRoom(hotel, (0, 1));

            // Assert
            Assert.True(status.BookingStatus == BookingStatus.Decline);
        }

        [Fact(DisplayName = "Finding a first room that is available for a given data range")]
        public void Given_ValidRequest_When_RoomIsAvailableForRequestedDates_Then_BookingStatusIsAccept()
        {
            // Arrange
            hotel.Rooms[1, 0] = true;
            hotel.Rooms[1, 1] = true;
            hotel.Rooms[1, 2] = true;
            hotel.Rooms[1, 3] = true;

            // Act
            var status = roomFindingService.TryToFindAvailableRoom(hotel, (0, 2));

            // Assert
            Assert.True(status.Room == 0);
        }
    }
}
