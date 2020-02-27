using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;

namespace Mathtest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BasicRooterTest()
        {
            Rooter rooter = new Rooter();

            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;

            double actualResult = rooter.squareroot(input);

            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }

        [TestMethod]
        public void RooterValueRange()
        {
            Rooter rooter = new Rooter();

            for (double expected = 1e-8; expected < 1e+8; expected*=3.2)
            {
                RooterOneValue(rooter, expected);
            }
        }

        private void RooterOneValue(Rooter rooter, double expected)
        {
            double input = expected * expected;
            double actualResult = rooter.squareroot(input);

            Assert.AreEqual(expected, actualResult, delta: expected / 1000);
        }

        [TestMethod]
        public void RooterTestNegativeInputX()
        {
            Rooter rooter = new Rooter();

            try
            {
                rooter.squareroot(-10);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
    }

}
