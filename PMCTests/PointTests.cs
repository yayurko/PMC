using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMC;

namespace PMCTests
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTests()
        {
            Point<bool> p = new Point1D<bool>(true);
        }
    }
}
