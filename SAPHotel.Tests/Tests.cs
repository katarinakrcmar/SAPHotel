using Xunit;
using SAPHotel.RoomBooking;
using SAPHotel.RoomFinding;
using SAPHotel.Reservation;
using SAPHotel.Common;

namespace SAPHotel.Tests
{
    public class Tests
    {
        [Fact(DisplayName = "Requests outside our planning period are declined")]
        public void RequestsOutsideOurPlanningPeriod()
        {
            // Arrange
            var reservation = GetReservationService(1);
            var requests = TestCases.RequestsOutsideOurPlanningPeriod;

            // Act
            var status0 = reservation.TryToMakeAReservation(requests[0].Request);
            var status1 = reservation.TryToMakeAReservation(requests[1].Request);

            // Assert
            Assert.True(status0 == requests[0].BookingStatus);
            Assert.True(status1 == requests[1].BookingStatus);
        }

        [Fact(DisplayName = "Requests are accepted")]
        public void RequestsAreAccepted()
        {
            // Arrange
            var reservation = GetReservationService(3);
            var requests = TestCases.RequestsAreAccepted;

            // Act
            var status0 = reservation.TryToMakeAReservation(requests[0].Request);
            var status1 = reservation.TryToMakeAReservation(requests[1].Request);
            var status2 = reservation.TryToMakeAReservation(requests[2].Request);
            var status3 = reservation.TryToMakeAReservation(requests[3].Request);
            var status4 = reservation.TryToMakeAReservation(requests[4].Request);
            var status5 = reservation.TryToMakeAReservation(requests[5].Request);

            // Assert
            Assert.True(status0 == requests[0].BookingStatus);
            Assert.True(status1 == requests[1].BookingStatus);
            Assert.True(status2 == requests[2].BookingStatus);
            Assert.True(status3 == requests[3].BookingStatus);
            Assert.True(status4 == requests[4].BookingStatus);
            Assert.True(status5 == requests[5].BookingStatus);
        }

        [Fact(DisplayName = "Requests are declined")]
        public void RequestsAreDeclined()
        {
            // Arrange
            var reservation = GetReservationService(3);
            var requests = TestCases.RequestsAreDeclined;

            // Act
            var status0 = reservation.TryToMakeAReservation(requests[0].Request);
            var status1 = reservation.TryToMakeAReservation(requests[1].Request);
            var status2 = reservation.TryToMakeAReservation(requests[2].Request);
            var status3 = reservation.TryToMakeAReservation(requests[3].Request);

            // Assert
            Assert.True(status0 == requests[0].BookingStatus);
            Assert.True(status1 == requests[1].BookingStatus);
            Assert.True(status2 == requests[2].BookingStatus);
            Assert.True(status3 == requests[3].BookingStatus);
        }

        [Fact(DisplayName = "Requests are accepted after a decline")]
        public void RequestsAcceptedAfterBeingDeclined()
        {
            var reservation = GetReservationService(3);
            var requests = TestCases.RequestsAcceptedAfterBeingDeclined;

            // Act
            var status0 = reservation.TryToMakeAReservation(requests[0].Request);
            var status1 = reservation.TryToMakeAReservation(requests[1].Request);
            var status2 = reservation.TryToMakeAReservation(requests[2].Request);
            var status3 = reservation.TryToMakeAReservation(requests[3].Request);
            var status4 = reservation.TryToMakeAReservation(requests[4].Request);

            // Assert
            Assert.True(status0 == requests[0].BookingStatus);
            Assert.True(status1 == requests[1].BookingStatus);
            Assert.True(status2 == requests[2].BookingStatus);
            Assert.True(status3 == requests[3].BookingStatus);
            Assert.True(status4 == requests[4].BookingStatus);
        }

        [Fact(DisplayName = "Complex requests when we try to book first available room")]
        public void ComplexRequestsWithFirstAvailableRoomApproach()
        {
            var reservation = GetReservationService(2);
            var requests = TestCases.ComplexRequests;

            // Act
            var status0 = reservation.TryToMakeAReservation(requests[0].Request);
            var status1 = reservation.TryToMakeAReservation(requests[1].Request);
            var status2 = reservation.TryToMakeAReservation(requests[2].Request);
            var status3 = reservation.TryToMakeAReservation(requests[3].Request);
            var status4 = reservation.TryToMakeAReservation(requests[4].Request);
            var status5 = reservation.TryToMakeAReservation(requests[5].Request);
            var status6 = reservation.TryToMakeAReservation(requests[6].Request);
            var status7 = reservation.TryToMakeAReservation(requests[7].Request);
            var status8 = reservation.TryToMakeAReservation(requests[8].Request);

            // Assert
            Assert.True(status0 == requests[0].BookingStatus);
            Assert.True(status1 == requests[1].BookingStatus);
            Assert.True(status2 == requests[2].BookingStatus);
            Assert.True(status3 == requests[3].BookingStatus);
            Assert.True(status4 == requests[4].BookingStatus);
            Assert.True(status5 == requests[5].BookingStatus);
            Assert.True(status6 == requests[6].BookingStatus);
            Assert.True(status7 == requests[7].BookingStatus);
            Assert.True(status8 == requests[8].BookingStatus);
        }

        private IReservationService GetReservationService(int size)
        {
            return new ReservationServiceDecorator(
                new ReservationService(
                    new Hotel(size),
                    new RoomFindingService(),
                    new RoomBookingService()),
                new BookingRequestValidator());
        }
    }
}
