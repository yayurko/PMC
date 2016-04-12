using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMC;

namespace PMCTests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Construct_DifferentNumberOfPositions()
        {
            Position<decimal> pos2 = new Position<decimal>
                .Construct { new Point1D<decimal>(5) };
            Position<decimal> pos1 = new Position<decimal>
                .Construct { new Point1D<decimal>(5) };
            Matrix<decimal> m1 = new Matrix<decimal>
                .Construct { pos1, pos2 };
            Matrix<decimal> m2 = new Matrix<decimal>
                .Construct { pos1 };
            Container<decimal> c = new Container<decimal>.Construct { m1, m2 };
        }
    }
}
