using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMC;

namespace PMCTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example1
            Position<decimal> p11 = new Position<decimal>.Construct { }
                            .Add(new Point2D<decimal>(3, 2), 50);
            Position<decimal> p12 = new Position<decimal>.Construct { }
                            .Add(new Point2D<decimal>(5, 6), 200);
            Matrix<decimal> m11 = new Matrix<decimal>.Construct { p11, p12 }
                                    .Add(null, 98);

            Matrix<decimal> m12 = new Matrix<decimal>.Construct {
                                    new Position<decimal>.Construct { }
                                        .Add(new Point1D<decimal>(1)),
                                    new Position<decimal>.Construct { }
                                        .Add(new Point1D<decimal>(2))
                                    }.Add(null, 98);
            Container<decimal> c11 = new Container<decimal>.Construct { m11, m12 };
            Containers<decimal> containers1 = new Containers<decimal>.Construct { }.Add(c11, 3);

            //Containers<decimal> containers1_ = new Containers<decimal>.Construct {
            //    new Container<decimal>.Construct {
            //        new Matrix<decimal>.Construct {
            //            new Position<decimal>.Construct { }
            //                .Append(new Point2D<decimal>(3, 2), 50),
            //            new Position<decimal>.Construct { }
            //                .Append(new Point2D<decimal>(5, 6), 200)
            //        }.Append(null, 98),
            //        new Matrix<decimal>.Construct {
            //            new Position<decimal>.Construct { }
            //                .Append(new Point1D<decimal>(1)),
            //            new Position<decimal>.Construct { }
            //                .Append(new Point1D<decimal>(2))
            //        }.Append(null, 98),
            //        },
            //    new Container<decimal>.Construct {
            //        new Matrix<decimal>.Construct {
            //            new Position<decimal>.Construct { }
            //                .Append(new Point2D<decimal>(3, 2), 50),
            //            new Position<decimal>.Construct { }
            //                .Append(new Point2D<decimal>(5, 6), 200)
            //        }.Append(null, 98),
            //        new Matrix<decimal>.Construct {
            //            new Position<decimal>.Construct { }
            //                .Append(new Point1D<decimal>(1)),
            //            new Position<decimal>.Construct { }
            //                .Append(new Point1D<decimal>(2))
            //        }.Append(null, 98),
            //        },
            //    new Container<decimal>.Construct {
            //        new Matrix<decimal>.Construct {
            //            new Position<decimal>.Construct { }
            //                .Append(new Point2D<decimal>(3, 2), 50),
            //            new Position<decimal>.Construct { }
            //                .Append(new Point2D<decimal>(5, 6), 200)
            //        }.Append(null, 98),
            //        new Matrix<decimal>.Construct {
            //            new Position<decimal>.Construct { }
            //                .Append(new Point1D<decimal>(1)),
            //            new Position<decimal>.Construct { }
            //                .Append(new Point1D<decimal>(2))
            //        }.Append(null, 98),
            //        }
            //};


            //Example2
            Matrix<double> m21 = new Matrix<double>.Construct { }
                                    .Add(new Position<double>.Construct
                                                { new Point2D<double>(11, 12) });
            Matrix<double> m22 = new Matrix<double>.Construct { }
                                    .Add(new Position<double>.Construct
                                                { new Point1D<double>(33) });
            Container<double> c21 = new Container<double>.Construct { }
                                    .Add(m21, 5).Add(m22, 5);
            Containers<double> containers2 = new Containers<double>.Construct { }
                                                .Add(c21, 10);

            Console.WriteLine(containers1.ToString());
            Console.ReadKey();
            Console.WriteLine(containers2.ToString());
            Console.ReadKey();
        }
    }
}
