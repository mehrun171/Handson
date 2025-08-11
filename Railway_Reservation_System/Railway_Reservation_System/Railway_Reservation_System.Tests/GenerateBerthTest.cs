using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Railway_Reservation_System;
using System;
using System.Text.RegularExpressions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Railway_Reservation_System.Tests
{
    [TestFixture]

    public class BerthAllocationTests
    {
        [Test]
        public void GenerateBerth_ShouldReturnValidFormats()
        {
            var manager = new ReservationManager();
            string berth = manager.GenerateBerth();
            StringAssert.StartsWith("Berth->", berth, "Berth string should start with 'Berth->'");

            string numberPart = berth.Replace("Berth->", "");
            bool isNumber = int.TryParse(numberPart, out int berthNumber);

            Assert.IsTrue(isNumber, "Berth number should be a valid integer.");
            Assert.IsTrue(berthNumber >= 1 && berthNumber < 150, "Berth number should be between 1 and 149.");
        }

        [Test]
        public void GenerateBerth_ShouldProduceDifferentValues()
        {
            var manager = new ReservationManager();
            var berth1 = manager.GenerateBerth();
            var berth2 = manager.GenerateBerth();
            Assert.AreNotEqual(berth1, berth2, "Berth allocation should vary between calls.");
        }
        
    }
}
