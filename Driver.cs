using System;

namespace Unit4Assignment
{
    class Driver
    {
        #region Exercise 2.1
        public class RationalNumber
        {
            private int Numerator, Denominator;
            public RationalNumber(int num, int denom) //Assignment equivalent to 'make-rat'
            {
                Numerator = num;
                Denominator = denom;
                CleanInput();
            }

            private void CleanInput() //This method completes the requirements of Exercise 2.1
            {
                if (Denominator == 0)
                {
                    Console.WriteLine("ERROR: Denominator cannot be zero");
                    return;
                }

                if ((Numerator < 0) && (Denominator < 0))
                {
                    Numerator = Math.Abs(Numerator);
                    Denominator = Math.Abs(Denominator);
                    return;
                }

                if ((Numerator > 0) && (Denominator < 0))
                {
                    Numerator = Numerator * -1;
                    Denominator = Math.Abs(Denominator);
                }

            }

            public int GetNumer()
            {
                return Numerator;
            }

            public int GetDenom()
            {
                return Denominator;
            }

            public string DisplayRat()
            {
                return Numerator + "/" + Denominator;
            }
        }

        public static RationalNumber AddRat(RationalNumber x, RationalNumber y)
        {
            int newNumer = ((x.GetNumer() * y.GetDenom()) + (y.GetNumer() * x.GetDenom()));
            int newDenom = x.GetDenom() * y.GetDenom();
            return new RationalNumber(newNumer, newDenom);
        }

        public static RationalNumber SubRat(RationalNumber x, RationalNumber y)
        {
            int newNumer = ((x.GetNumer() * y.GetDenom()) - (y.GetNumer() * x.GetDenom()));
            int newDenom = x.GetDenom() * y.GetDenom();
            return new RationalNumber(newNumer, newDenom);
        }

        public static RationalNumber MultRat(RationalNumber x, RationalNumber y)
        {
            int newNumer = x.GetNumer() * y.GetNumer();
            int newDenom = x.GetDenom() * y.GetDenom();
            return new RationalNumber(newNumer, newDenom);
        }

        public static RationalNumber DivRat(RationalNumber x, RationalNumber y)
        {
            int newNumer = x.GetNumer() * y.GetDenom();
            int newDenom = x.GetDenom() * y.GetNumer();
            return new RationalNumber(newNumer, newDenom);
        }

        public static bool isEqualRat(RationalNumber x, RationalNumber y)
        {
            return ((x.GetNumer() * y.GetDenom()) == (y.GetNumer() * x.GetDenom()));
        }

        #endregion


        #region Exercise 2.2
        public class Point
        {
            private double X, Y;
            public Point(double x, double y) //'make-point'
            {
                X = x;
                Y = y;
            }

            public double GetX() //effectively doing the action of a 'car'
            {
                return X;
            }

            public double GetY() //effectively doing the action of a 'cdr'
            {
                return Y;
            }

            public string Display()
            {
                return "(" + GetX() + "," + GetY() + ")";
            }
        }

        public class Segment
        {
            private Point point1, point2;
            public Segment(Point p1, Point p2)
            {
                point1 = p1;
                point2 = p2;
            }

            public Point GetMidpoint() //'midpoint-segment' method
            {
                double midX = (point1.GetX() + point2.GetX()) / 2;
                double midY = (point1.GetY() + point2.GetY()) / 2;

                return new Point(midX, midY);
            }

            public string Display()
            {
                return "Point 1: " + point1.Display() + "\nPoint 2: " + point2.Display() + "\nMidpoint: " + GetMidpoint().Display();
            }
        }
        #endregion


        #region Exercise 2.3
        //Make rectangles using two different representations

        //Method 1: 2 corner points (different 'x' AND 'y')
        public class RecPoint
        {
            private Point corner1, corner2;
            private double Length, Height;
            public RecPoint(Point p1, Point p2)
            {
                if((p1.GetX() != p2.GetX()) && (p1.GetY() != p2.GetY()))
                {
                    corner1 = p1;
                    corner2 = p2;
                    CalcDifferences();
                }
                else
                {
                    throw new Exception();
                }
            }

            private void CalcDifferences()
            {
                if (corner1.GetX() > 0 && corner2.GetX() > 0)
                    Length = Math.Abs(corner1.GetX() - corner2.GetX());
                else if (corner1.GetX() < 0 && corner2.GetX() > 0)
                    Length = Math.Abs(corner1.GetX()) + corner2.GetX();
                else if (corner1.GetX() > 0 && corner2.GetX() < 0)
                    Length = Math.Abs(corner2.GetX()) + corner1.GetX();
                else
                    Length = Math.Abs(corner1.GetX() - corner2.GetX());


                if (corner1.GetY() > 0 && corner2.GetY() > 0)
                    Height = Math.Abs(corner1.GetY() - corner2.GetY());
                else if (corner1.GetY() < 0 && corner2.GetY() > 0)
                    Height = Math.Abs(corner1.GetY()) + corner2.GetY();
                else if (corner1.GetY() > 0 && corner2.GetY() < 0)
                    Height = Math.Abs(corner2.GetY()) + corner1.GetY();
                else
                    Height = Math.Abs(corner1.GetY() - corner2.GetY());
            }

            public double GetPerimeter()
            {
                return (Length * 2) + (Height * 2);
            }

            public double GetArea()
            {
                return Length * Height;
            }

            public string Display()
            {
                return "Corner 1: " + corner1.Display() +
                    "\nCorner 2: " + corner2.Display() +
                    "\nLength: " + Length +
                    "\nHeight: " + Height +
                    "\nPerimeter: " + GetPerimeter() +
                    "\nArea: " + GetArea();
            }
        }


        //Method 2: Length and Height
        public class RecLH
        {
            private double Length, Height;
            public RecLH(double length, double height)
            {
                Length = length;
                Height = height;
            }

            public double GetPerimeter()
            {
                return (Length * 2) + (Height * 2);
            }

            public double GetArea()
            {
                return Length * Height;
            }

            public string Display()
            {
                return "\nLength: " + Length +
                    "\nHeight: " + Height +
                    "\nPerimeter: " + GetPerimeter() +
                    "\nArea: " + GetArea();
            }
        }
        #endregion


        #region Exercise 2.12
        public class Interval
        {
            private double UpperLimit, LowerLimit;
            public Interval(double a, double b)
            {
                if (a > b)
                {
                    UpperLimit = a;
                    LowerLimit = b;
                }
                else
                {
                    UpperLimit = b;
                    LowerLimit = a;
                }
            }

            public double GetUpper()
            {
                return UpperLimit;
            }

            public double GetLower()
            {
                return LowerLimit;
            }

            public string Display()
            {
                return "Lower Limit: " + GetLower() + "\n" +
                    "Upper Limit: " + GetUpper() + "\n";
            }
        }

        public static Interval make_center_percent(double center, double percentTolerance)
        {
            double intervalSize = (percentTolerance / 100.0) * center;
            return new Interval(center - intervalSize, center + intervalSize);
        }

        #endregion



        public static void Main(string[] args)
        {
            //Exercise 2.1
            RationalNumber oneHalf = new RationalNumber(-1, -2);
            RationalNumber negOneHalf = new RationalNumber(1, -2);
            RationalNumber twoFourths = new RationalNumber(2, 4);
            RationalNumber oneThird = new RationalNumber(1, 3);
            RationalNumber oneFourth = new RationalNumber(1, 4);
            Console.WriteLine(oneHalf.DisplayRat() + " + " + oneFourth.DisplayRat() + " = " + AddRat(oneHalf, oneFourth).DisplayRat());
            Console.WriteLine(oneHalf.DisplayRat() + " - " + oneFourth.DisplayRat() + " = " + SubRat(oneHalf, oneFourth).DisplayRat());
            Console.WriteLine(oneHalf.DisplayRat() + " / " + oneThird.DisplayRat() + " = " + DivRat(oneHalf, oneThird).DisplayRat());
            Console.WriteLine(negOneHalf.DisplayRat() + " * " + twoFourths.DisplayRat() + " = " + MultRat(negOneHalf, twoFourths).DisplayRat());


            //Exercise 2.2
            Point a = new Point(1, 1);
            Point b = new Point(1, 3);
            Segment seg = new Segment(a, b);
            Console.WriteLine("\n\n" + seg.Display());


            //Exercise 2.3
            Point r1 = new Point(-1, -1);
            Point r2 = new Point(3, 5);
            RecPoint rec1 = new RecPoint(r1, r2);
            Console.WriteLine("\n\n" + rec1.Display());

            RecLH rec2 = new RecLH(7, 4);
            Console.WriteLine("\n" + rec2.Display());

            //Exercise 2.12
            Console.WriteLine("\n\n" + make_center_percent(100, 50).Display());
        }
    }
}
