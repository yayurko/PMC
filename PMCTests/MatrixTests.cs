using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMC;

namespace PMCTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Construct_DifferentTypesOfPositions()
        {
            Position<decimal> pos2 = new Position<decimal>
                .Construct { new Point1D<decimal>(5) };
            Position<decimal> pos1 = new Position<decimal>
                .Construct { new Point2D<decimal>(5, 3) };
            Matrix<decimal> m1 = new Matrix<decimal>
                .Construct { pos1, pos2 };
        }
    }
}
