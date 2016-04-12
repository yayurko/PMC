using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMC
{
    public class Matrix<T> : IEnumerable
    {
        /// <summary>
        /// Type of all the positions inside a collection
        /// </summary>
        public Type DimensionType { get; private set; }
        Position<T>[] positions;
        /// <summary>
        /// Number of Positions inside
        /// </summary>
        public int Size { get { return positions == null ? 0 : positions.Length; } }
        
        /// <summary>
        /// Initializes an instanse of Matrix object, checking if the parameter satisfies the rules
        /// </summary>
        /// <param name="positions">elements to use for instantiation</param>
        public Matrix(IEnumerable<Position<T>> posititons)
        {
            if (posititons == null) throw new ArgumentNullException("Can't initialize matrix with null");
            if (posititons.Count() > 0)
            {
                Type dimType = null;
                foreach (var position in posititons)
                    if (position != null)
                    {
                        if (dimType == null) dimType = position.DimensionType;
                        if (position.DimensionType != dimType)
                            throw new ArgumentException("Matrix can not contain positions of different types");
                    }
                DimensionType = dimType;
            }
            this.positions = posititons.ToArray();
        }

        /// <summary>
        /// Retrieves element
        /// </summary>
        /// <param name="i">Index of desired element</param>
        /// <returns></returns>
        public Position<T> this[int i]
        {
            get
            {
                if (i < 0 || i >= positions.Length)
                    throw new IndexOutOfRangeException();
                return positions[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return positions.GetEnumerator();
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("    [\r\n");
            foreach (var e in this)
            {
                if (e == null) sb.Append("-");
                else sb.Append(e);
            }
            sb.Append("    ]\r\n");
            return sb.ToString();
        }







        /// <summary>
        /// Builder class. Provides collection initializers, Add and Append methods.
        /// Use this way: new Matrix<>.Construct{o1, o2}.Append(o3, 1000)
        /// </summary>
        public class Construct : IEnumerable
        {
            Type dimensionType;
            List<Position<T>> positions = new List<Position<T>>();

            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)positions).GetEnumerator();
            }

            /// <summary>
            /// Appends element to a collection
            /// </summary>
            /// <param name="position">element to append</param>
            /// <returns></returns>
            public Construct Add(Position<T> position)
            {
                positions.Add(position);
                return this;
            }
            
            /// <summary>
            /// Appends element to a collection multiple times.
            /// </summary>
            /// <param name="position">element to append</param>
            /// <param name="n">amount of times to append element</param>
            /// <returns>The updated object</returns>
            public Construct Add(Position<T> position, int n)
            {
                for (int i = 0; i < n; i++)
                    positions.Add(position);
                return this;
            }
            
            public static implicit operator Matrix<T>(Construct construct)
            {
                return new Matrix<T>(construct.positions);
            }
        }

    }
}
