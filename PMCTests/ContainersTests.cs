using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMC;

namespace PMCTests
{
    [TestClass]
    public class ContainersTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Construct_DifferentNumberOfPositions()
        {
            Position<decimal> pos2 = new Position<decimal>
                .Construct { new Point2D<decimal>(3, 2) };
            Position<decimal> pos1 = new Position<decimal>
                .Construct { new Point2D<decimal>(5, 3) };
            Matrix<decimal> m1 = new Matrix<decimal>
                .Construct { pos1, pos2 };
            Matrix<decimal> m2 = new Matrix<decimal>
                .Construct { pos1 };
            Container<decimal> c1 = new Container<decimal>.Construct { m1 };
            Container<decimal> c2 = new Container<decimal>.Construct { m2 };
            Containers<decimal> cont = new Containers<decimal>.Construct { c1, c2 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Construct_DifferentNumberOfMatrices()
        {
            Position<decimal> pos2 = new Position<decimal>
                .Construct { new Point2D<decimal>(3, 2) };
            Position<decimal> pos1 = new Position<decimal>
                .Construct { new Point2D<decimal>(5, 3) };
            Matrix<decimal> m1 = new Matrix<decimal>
                .Construct { pos2 };
            Matrix<decimal> m2 = new Matrix<decimal>
                .Construct { pos1 };
            Container<decimal> c1 = new Container<decimal>.Construct { m1 };
            Container<decimal> c2 = new Container<decimal>.Construct { m1, m2 };
            Containers<decimal> cont = new Containers<decimal>.Construct { c1, c2 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Construct_DifferentTypesAcrossContainers()
        {
            Position<decimal> pos2 = new Position<decimal>
                .Construct { new Point1D<decimal>(3) };
            Position<decimal> pos1 = new Position<decimal>
                .Construct { new Point2D<decimal>(5, 3) };
            Matrix<decimal> m1 = new Matrix<decimal>
                .Construct { pos2 };
            Matrix<decimal> m2 = new Matrix<decimal>
                .Construct { pos1 };
            Container<decimal> c1 = new Container<decimal>.Construct { m1 };
            Container<decimal> c2 = new Container<decimal>.Construct { m2 };
            Containers<decimal> cont = new Containers<decimal>.Construct { c1, c2 };
        }
    }
}
