using SAPHotel.Common;

namespace SAPHotel.Tests
{ 
    public static class TestCases
    {
        public static TestCase[] RequestsAcceptedAfterBeingDeclined =>
            new TestCase[]
            {
                new TestCase((1, 3), BookingStatus.Accept),
                new TestCase((0, 15), BookingStatus.Accept),
                new TestCase((1, 9), BookingStatus.Accept),
                new TestCase((2, 5), BookingStatus.Decline),
                new TestCase((4, 9), BookingStatus.Accept)
            };

        public static TestCase[] RequestsOutsideOurPlanningPeriod =>
            new TestCase[]
            {
                new TestCase((-4, 2), BookingStatus.Decline),
                new TestCase((200, 400), BookingStatus.Decline)
            };

        public static TestCase[] RequestsAreAccepted =>
            new TestCase[]
            {
                new TestCase((0, 5), BookingStatus.Accept),
                new TestCase((7, 13), BookingStatus.Accept),
                new TestCase((3, 9), BookingStatus.Accept),
                new TestCase((5, 7), BookingStatus.Accept),
                new TestCase((6, 6), BookingStatus.Accept),
                new TestCase((0, 4), BookingStatus.Accept)
            };

        public static TestCase[] RequestsAreDeclined =>
           new TestCase[]
           {
                new TestCase((1, 3), BookingStatus.Accept),
                new TestCase((2, 5), BookingStatus.Accept),
                new TestCase((1, 9), BookingStatus.Accept),
                new TestCase((0, 15), BookingStatus.Decline),
           };

        public static TestCase[] ComplexRequests =>
            new TestCase[]
            {
                new TestCase((1, 3), BookingStatus.Accept),
                new TestCase((0, 4), BookingStatus.Accept),
                new TestCase((2, 3), BookingStatus.Decline),
                new TestCase((5, 5), BookingStatus.Accept),
                new TestCase((4, 10), BookingStatus.Decline),
                new TestCase((10, 10), BookingStatus.Accept),
                new TestCase((6, 7), BookingStatus.Accept),
                new TestCase((8, 10), BookingStatus.Accept),
                new TestCase((8, 9), BookingStatus.Accept)
            };
    }
}
