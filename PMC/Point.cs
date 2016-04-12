using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC
{
    /// <summary>
    /// Abstract class for all kinds of points
    /// </summary>
    /// <typeparam name="T">Base type for parts of a point. Can be numerical type only</typeparam>
    public abstract class Point<T>
    {
        protected Point()
        {
            if (!Numeric.Is(typeof(T)))
                throw new ArgumentException("Only numeric type can be passed");
        }

        /// <summary>
        /// Retrieves the type of a point
        /// </summary>
        public abstract Type DimensionType { get; }
    }

    /// <summary>
    /// One Dimensional point
    /// </summary>
    /// <typeparam name="T">Base type of a point. Can be numerical type only</typeparam>
    public class Point1D<T> : Point<T>
    {
        /// <summary>
        /// Base value
        /// </summary>
        public T X { get; private set; }
        /// <summary>
        /// Dimension of a point
        /// </summary>
        public override Type DimensionType { get { return typeof(Point1D<T>); } }
        /// <summary>
        /// Initializes a new instance of Point1D with default value of base type
        /// </summary>
        public Point1D() { X = default(T); }
        /// <summary>
        /// Initializes a new instance of Point1D
        /// </summary>
        /// <param name="x">Base type value</param>
        public Point1D(T x) { X = x; }

        public override string ToString()
        {
            return String.Format("        ({0})\r\n", X);
        }
    }

    /// <summary>
    /// Two Dimesional point
    /// </summary>
    /// <typeparam name="T">Base type for parts of a point. Can be numerical type only</typeparam>
    public class Point2D<T> : Point<T>
    {
        public T X { get; private set; }
        public T Y { get; private set; }
        /// <summary>
        /// Dimension of a point
        /// </summary>
        public override Type DimensionType { get { return typeof(Point2D<T>); } }
        public Point2D() {X = default(T); Y = default(T); }
        public Point2D(T x, T y) { X = x; Y = y; }
        public override string ToString()
        {
            return String.Format("        ({0}, {1})\r\n", X, Y);
        }
    }

    /// <summary>
    /// Three Dimensional point
    /// </summary>
    /// <typeparam name="T">Base type for parts of a point. Can be numerical type only</typeparam>
    public class Point3D<T> : Point<T>
    {
        public T X { get; private set; }
        public T Y { get; private set; }
        public T Z { get; private set; }
        /// <summary>
        /// Dimension of a point
        /// </summary>
        public override Type DimensionType { get { return typeof(Point3D<T>); } }
        public Point3D() { X = default(T); Y = default(T); Z = default(T); }
        public Point3D(T x, T y, T z) { X = x; Y = y; Z = z; }
        public override string ToString()
        {
            return String.Format("        ({0}, {1}, {2})\r\n", X, Y, Z);
        }
    }
}
