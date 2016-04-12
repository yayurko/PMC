using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMC;

namespace PMCTests
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Construct_DifferentTypesOfPoints()
        {
            Position<decimal> pos1 = new Position<decimal>
                .Construct { new Point1D<decimal>(5), new Point2D<decimal>(3,2) };
        }

        [TestMethod]
        public void Construct_nullParameter()
        {
            Position<decimal> pos1 = new Position<decimal>
                .Construct { null };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_nullParameter()
        {
            Position<decimal> pos1 = new Position<decimal>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_IndexLessThanZero()
        {
            Position<decimal> pos1 = new Position<decimal>
                .Construct { new Point1D<decimal>(5), new Point1D<decimal>(3) };
            Point<decimal> d = pos1[-1];
        }
    }
}
