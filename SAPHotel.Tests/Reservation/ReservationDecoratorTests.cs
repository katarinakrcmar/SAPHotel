using NSubstitute;
using Xunit;
using SAPHotel.Reservation;
using SAPHotel.Common;

namespace SAPHotel.Tests.Reservation
{
    public class ReservationDecoratorTests
    {
        private readonly IReservationService reservation;
        private readonly IReservationService reservationDecorator;
        private readonly IBookingRequestValidator bookingRequestValidator;

        public ReservationDecoratorTests()
        {
            reservation = Substitute.For<IReservationService>();
            bookingRequestValidator = Substitute.For<IBookingRequestValidator>();

            reservationDecorator = new ReservationServiceDecorator(
                reservation,
                bookingRequestValidator);
        }

        [Fact(DisplayName = "When BookingRequest is valid Then Reservation's TryToMakeAReservation() method is called")]
        public void Given_ValidRequest_When_ReservationDecoratorIsCalled_Then_ReservationIsCalledAsWell()
        {
            // Arrange
            bookingRequestValidator.IsValidBookingRequest(Arg.Any<(int, int)>()).Returns(true);

            // Act
            reservationDecorator.TryToMakeAReservation((1, 2));

            // Assert
            reservation.Received(1).TryToMakeAReservation(Arg.Any<(int, int)>());
        }

        [Fact(DisplayName = "When BookingRequest is not valid Then BookingStatus is decline")]
        public void Given_InvalidRequest_When_ReservationDecoratorIsCalled_Then_BookingStatusIsDecline()
        {
            // Arrange
            bookingRequestValidator.IsValidBookingRequest(Arg.Any<(int, int)>()).Returns(false);

            // Act
            var status = reservationDecorator.TryToMakeAReservation((1, 2));

            // Assert
            Assert.True(status == BookingStatus.Decline);
        }

        [Fact(DisplayName = "When BookingRequest is not valid Then Reservation's TryMakeReservation is not called")]
        public void Given_InvalidRequest_When_ReservationDecoratorIsCalled_Then_ReservationIsNotCalled()
        {
            // Arrange
            bookingRequestValidator.IsValidBookingRequest(Arg.Any<(int, int)>()).Returns(false);

            // Act
            reservationDecorator.TryToMakeAReservation((1, 2));

            // Assert
            reservation.DidNotReceive().TryToMakeAReservation(Arg.Any<(int, int)>());
        }
    }
}
