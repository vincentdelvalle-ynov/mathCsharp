using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;

namespace MathLibTest
{
    [TestClass]
    public class UlamSpiralTest
    {
        [TestMethod]
        public void TestUlamSpiralGetCenterLocation()
        {
            UlamSpiral spiral = null;
            int[] location = null;

            spiral = new UlamSpiral(9);
            location = spiral.GetCenterLocation();

            Assert.AreEqual(location[0], 1); // x
            Assert.AreEqual(location[1], 1); // y
        }

        [TestMethod]
        public void TestUlamSpiralGetStartLocationOK()
        {
            UlamSpiral spiral = null;
            int[] location = null;


            spiral = new UlamSpiral(81);
            int[] centerLocation = spiral.GetCenterLocation();


            location = spiral.GetStartLocation(0);

            Assert.AreEqual(location[0], centerLocation[0]); // x
            Assert.AreEqual(location[1], centerLocation[1]); // y

            location = spiral.GetStartLocation(1);

            Assert.AreEqual(location[0], centerLocation[0] + 1); // x
            Assert.AreEqual(location[1], centerLocation[1]);     // y

            location = spiral.GetStartLocation(2);

            Assert.AreEqual(location[0], centerLocation[0] + 2); // x
            Assert.AreEqual(location[1], centerLocation[0] + 1); // y
        }

        [TestMethod]
        public void TestUlamSpiralGetSpiralSizeOK()
        {
            UlamSpiral spiral = new UlamSpiral(0);

            Assert.AreEqual(1, spiral.GetSpiralSize(0));
            Assert.AreEqual(3, spiral.GetSpiralSize(1));
            Assert.AreEqual(5, spiral.GetSpiralSize(2));
            Assert.AreEqual(7, spiral.GetSpiralSize(3));
        }

        [TestMethod]
        public void TestUlamSpiralGetMaxValueOK()
        {
            UlamSpiral spiral = new UlamSpiral(0);

            Assert.AreEqual(1, spiral.GetMaxValue(0));
            Assert.AreEqual(9, spiral.GetMaxValue(1));
            Assert.AreEqual(25, spiral.GetMaxValue(2));
            Assert.AreEqual(49, spiral.GetMaxValue(3));
        }

        [TestMethod]
        public void TestUlamSpiralGetCycleNumberFromValueOK()
        {
            UlamSpiral spiral = new UlamSpiral(0);

            Assert.AreEqual(0, spiral.GetCycleNumberFromValue(0));
            Assert.AreEqual(0, spiral.GetCycleNumberFromValue(1));
            Assert.AreEqual(1, spiral.GetCycleNumberFromValue(2));
            Assert.AreEqual(1, spiral.GetCycleNumberFromValue(3));
            Assert.AreEqual(1, spiral.GetCycleNumberFromValue(9));
            Assert.AreEqual(2, spiral.GetCycleNumberFromValue(10));
        }

        [TestMethod]
        public void TestUlamSpiralCycleOK()
        {
            UlamSpiral spiral = null;
            int[] loc = null;
            int cycleNumber = 0;

            spiral = new UlamSpiral(25);
            cycleNumber = 1;
            spiral.Cycle(cycleNumber);
            loc = spiral.GetStartLocation(cycleNumber);
            Assert.AreEqual(2, spiral.Matrix[loc[1], loc[0]]);

            spiral = new UlamSpiral(25);
            cycleNumber = 2;
            spiral.Cycle(cycleNumber);
            loc = spiral.GetStartLocation(cycleNumber);
            Assert.AreEqual(10, spiral.Matrix[loc[1], loc[0]]);

            spiral = new UlamSpiral(49);
            cycleNumber = 3;
            spiral.Cycle(cycleNumber);
            loc = spiral.GetStartLocation(cycleNumber);
            Assert.AreEqual(26, spiral.Matrix[loc[1], loc[0]]);
        }


    }
}
