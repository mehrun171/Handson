using NUnit.Framework;
using Railway_Reservation_System;

namespace Railway_Reservation_System.Tests
{
    [TestFixture]
    public class BerthAllocationTests
    { 
        [Test]
        public void GenerateBerth_ShouldProduceDifferentValues()
        {
            var manager = new ReservationManager();
            var berth1 = manager.GenerateBerth();
            var berth2 = manager.GenerateBerth();

            Assert.That(berth1, Is.Not.EqualTo(berth2));
        }
    }
}
