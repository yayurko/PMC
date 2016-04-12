using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMC
{
    public class Container<T> : IEnumerable
    {
        Matrix<T>[] matrices;

        /// <summary>
        /// Number of positions in every matrix of a container
        /// </summary>
        public int PositionsCount { get; private set; }
        /// <summary>
        /// Number of matrices in a container
        /// </summary>
        public int Size { get { return matrices == null ? 0 : matrices.Length; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  <\r\n");
            foreach (var e in this)
            {
                if (e == null) sb.Append("-");
                else sb.Append(e);
            }
            sb.Append("  >\r\n");
            return sb.ToString();
        }








        /// <summary>
        /// Initializes an instanse of Container, checking if the parameter satisfies the rules
        /// </summary>
        /// <param name="containers">elements to use for instantiation</param>
        public Container(IEnumerable<Matrix<T>> matrices)
        {
            if (matrices == null) throw new ArgumentNullException("Can't initialize container with null");
            if (matrices.Count() > 0)
            {
                int positionsCount = -1;
                foreach (var matrix in matrices)
                    if (matrix != null)
                    {
                        if (positionsCount < 0) positionsCount = matrices.First().Size;
                        if (matrix.Size != positionsCount)
                            throw new ArgumentException("Container can not contain matrices of different sizes");
                    }
                this.PositionsCount = positionsCount;
            }
            this.matrices = matrices.ToArray();
        }

        public IEnumerator GetEnumerator()
        {
            return matrices.GetEnumerator();
        }

        /// <summary>
        /// Retrieves element
        /// </summary>
        /// <param name="i">Index of desired element</param>
        /// <returns></returns>
        public Matrix<T> this[int i]
        {
            get
            {
                if (i < 0 || i >= matrices.Length)
                    throw new IndexOutOfRangeException();
                return matrices[i];
            }
        }

        /// <summary>
        /// Builder class. Provides collection initializers, Add and Append methods.
        /// Use this way: new Container<>.Construct{o1, o2}.Append(o3, 1000)
        /// </summary>
        public class Construct : IEnumerable
        {
            List<Matrix<T>> matrices = new List<Matrix<T>>();

            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)matrices).GetEnumerator();
            }


            /// <summary>
            /// Appends element to a collection
            /// </summary>
            /// <param name="matrix">element to append</param>
            /// <returns>The updated object</returns>
            public Construct Add(Matrix<T> matrix)
            {
                matrices.Add(matrix);
                return this;
            }
            
            /// <summary>
            /// Appends element to a collection multiple times.
            /// </summary>
            /// <param name="matrix">element to append</param>
            /// <param name="n">amount of times to append element</param>
            /// <returns>The updated object</returns>
            public Construct Add(Matrix<T> matrix, int n)
            {
                for (int i = 0; i < n; i++)
                    matrices.Add(matrix);
                return this;
            }
            
            public static implicit operator Container<T>(Construct construct)
            {
                return new Container<T>(construct.matrices);
            }
        }
    }
}
