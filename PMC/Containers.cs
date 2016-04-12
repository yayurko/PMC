using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMC
{
    public class Containers<T> : IEnumerable
    {
        Container<T>[] containers;

        /// <summary>
        /// Number of matrices in every container
        /// </summary>
        public int MatricesCount { get; private set; }

        /// <summary>
        /// Number of positions in every matrix inside of every collection
        /// </summary>
        public int PositionsCount { get; private set; }
        
        /// <summary>
        /// Initializes an instanse of Containers object, checking if the parameter satisfies the rules
        /// </summary>
        /// <param name="containers">elements to use for instantiation</param>
        public Containers(IEnumerable<Container<T>> containers)
        {
            if (containers == null) throw new ArgumentNullException("Can't initialize containers with null");
            if (containers.Count() > 0)
            {
                int matricesCount = -1;
                int positionsCount = -1;
                foreach (var container in containers)
                {
                    if (container != null)
                    { 
                        if (matricesCount < 0) matricesCount = containers.First().Size;
                        if (positionsCount < 0) positionsCount = containers.First().PositionsCount;
                        if (container.Size != matricesCount)
                            throw new ArgumentException("Containers inside a collection can not contain different number of matrices");
                        if (container.PositionsCount != positionsCount)
                            throw new ArgumentException("Container can not contain matrices of different sizes");
                    }
                }
                MatricesCount = matricesCount;
                PositionsCount = positionsCount;


                //checking cross-container type of matrices with same index
                List<Type> types = null;
                foreach (var container in containers)
                {
                    if (container != null)
                    {
                        if (types == null)
                        {
                            types = new List<Type>();
                            foreach (Matrix<T> matrix in container)
                            {
                                types.Add(matrix.DimensionType);
                            }
                        }
                        else
                        {
                            var enumerator = types.GetEnumerator();
                            enumerator.MoveNext();
                            foreach (Matrix<T> matrix in container)
                            {
                                if (matrix.DimensionType != enumerator.Current)
                                    throw new ArgumentException("Matrices types should be the same across the containers"); ;
                                enumerator.MoveNext();
                            }
                        }
                    }
                }
            }
            this.containers = containers.ToArray();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)containers).GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("|_\r\n");
            foreach (var e in this)
            {
                if (e == null) sb.Append("-");
                else sb.Append(e);
            }
            sb.Append("_|\r\n");
            return sb.ToString();
        }






        /// <summary>
        /// Retrieves element
        /// </summary>
        /// <param name="i">Index of desired element</param>
        /// <returns></returns>
        public Container<T> this[int i]
        {
            get
            {
                if (i < 0 || i >= containers.Length)
                    throw new IndexOutOfRangeException();
                return containers[i];
            }
        }

        /// <summary>
        /// Builder class. Provides collection initializers, Add and Append methods.
        /// Use this way: new Containers<>.Construct{o1, o2}.Append(o3, 1000)
        /// </summary>
        public class Construct : IEnumerable
        {
            List<Container<T>> containers = new List<Container<T>>();

            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)containers).GetEnumerator();
            }
            
            /// <summary>
            /// Appends element to a collection
            /// </summary>
            /// <param name="container">element to append</param>
            /// <returns>The updated object</returns>
            public Construct Add(Container<T> container)
            {
                containers.Add(container);
                return this;
            }
            
            /// <summary>
            /// Appends element to a collection multiple times.
            /// </summary>
            /// <param name="container">element to append</param>
            /// <param name="n">amount of times to append element</param>
            /// <returns>The updated object</returns>
            public Construct Add(Container<T> container, int n)
            {
                for (int i = 0; i < n; i++)
                    containers.Add(container);
                return this;
            }

            public static implicit operator Containers<T>(Construct construct)
            {
                return new Containers<T>(construct.containers);
            }
        }
    }
}
