using Xunit;
using SAPHotel.RoomBooking;
using SAPHotel.RoomFinding;
using SAPHotel.Common;
using SAPHotel.Reservation;
using NSubstitute;

namespace SAPHotel.Tests.Reservation
{
    public class ReservationTests
    {
        private readonly IReservationService reservation;
        private readonly IRoomBookingService roomBooking;
        private readonly IRoomFindingService roomFinding;

        private Hotel Hotel => new Hotel(1);

        public ReservationTests()
        {
            roomFinding = Substitute.For<IRoomFindingService>();
            roomBooking = Substitute.For<IRoomBookingService>();

            reservation = new ReservationService(
                Hotel,
                roomFinding,
                roomBooking);
        }

        [Fact(DisplayName = "When BookingStatus is accept Then Book() method is called")]
        public void Given_BookingStatus_When_AvailableRoomIsFound_Then_BookMethodIsCalled()
        {
            // Arrange
            roomFinding.TryToFindAvailableRoom(Arg.Any<Hotel>(), Arg.Any<(int, int)>()).Returns(new BookingResponse(0));

            // Act
            reservation.TryToMakeAReservation((0, 4));

            // Assert
            roomBooking.Received(1).Book(Arg.Any<Hotel>(), Arg.Any<int>(), Arg.Any<(int, int)>());
        }

        [Fact(DisplayName = "When rooms are booked for requested dates Then Book() method is not called")]
        public void Given_BookingStatus_When_ThereIsNoAvailableRoom_Then_BookMethodIsNotCalled()
        {
            roomFinding.TryToFindAvailableRoom(Arg.Any<Hotel>(), Arg.Any<(int, int)>()).Returns(
                new BookingResponse(0), 
                new BookingResponse());

            // Act
            reservation.TryToMakeAReservation((0, 4));
            reservation.TryToMakeAReservation((0, 4));

            // Assert
            roomBooking.Received(1).Book(Arg.Any<Hotel>(), Arg.Any<int>(), Arg.Any<(int, int)>());
        }
    }
}
