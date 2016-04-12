using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMC
{
    /// <summary>
    /// Collection of points of same type: Point1D, Point2D or Point3D
    /// </summary>
    /// <typeparam name="T">Base type for points inside the collection</typeparam>
    public class Position<T> :IEnumerable
    {
        /// <summary>
        /// Type of points inside collection
        /// </summary>
        public Type DimensionType { get; private set; }
        Point<T>[] points;
        /// <summary>
        /// Number of points inside
        /// </summary>
        public int Size { get { return points == null ? 0 : points.Length; } }


        /// <summary>
        /// Initializes an instanse of Position object, checking if the parameter satisfies the rules
        /// </summary>
        /// <param name="points">elements to use for instantiation</param>
        public Position(IEnumerable<Point<T>> points)
        {
            if (points == null) throw new ArgumentNullException("Can't initialize position with null");
            if (points.Count() > 0)
            {
                Type dimType = null;
                foreach (var point in points)
                {
                    if (point != null)
                    {
                        if (dimType == null) dimType = point.DimensionType;
                        if (point.DimensionType != dimType)
                            throw new ArgumentException("Position can not contain points of different types");
                    }
                }
                DimensionType = dimType;
            }
            this.points = points.ToArray();
        }
        
        /// <summary>
        /// Retrieves element
        /// </summary>
        /// <param name="i">Index of desired element</param>
        /// <returns></returns>
        public Point<T> this[int i]
        {
            get
            {
                if (i < 0 || i >= points.Length)
                    throw new IndexOutOfRangeException();
                return points[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)points).GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("      |\r\n");
            foreach (var e in this)
            {
                if (e == null) sb.Append("-");
                else sb.Append(e);
            }
            sb.Append("      |\r\n");
            return sb.ToString();
        }




        /// <summary>
        /// Builder class. Provides collection initializers, Add and Append methods.
        /// Use this way: new Position<>.Construct{o1, o2}.Append(o3, 1000)
        /// </summary>
        public class Construct : IEnumerable
        {
            List<Point<T>> points = new List<Point<T>>();

            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)points).GetEnumerator();
            }

            /// <summary>
            /// Appends element to a collection
            /// </summary>
            /// <param name="point">element to append</param>
            /// <returns>The updated object</returns>
            public Construct Add(Point<T> point)
            {
                points.Add(point);
                return this;
            }
            
            /// <summary>
            /// Appends element to a collection multiple times.
            /// </summary>
            /// <param name="point">element to append</param>
            /// <param name="n">amount of times to append element</param>
            /// <returns>The updated object</returns>
            public Construct Add(Point<T> point, int n)
            {
                for (int i = 0; i < n; i++)
                    points.Add(point);
                return this;
            }

            public static implicit operator Position<T>(Construct construct)
            {
                return new Position<T>(construct.points);
            }
        }
    }
}
