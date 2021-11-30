using System;

namespace FigureIerarhy
{
    class Triangle : ClosedFigure
    {
       

        public Triangle(string name, Point [] points) : base(name, points)
        {
          
        }
        // Calculate the perimeter
        public override double Perimetr()
        {
            return Math.Sqrt(Math.Pow(Points[0].X - Points[1].X, 2) + Math.Pow(Points[0].Y - Points[1].Y, 2)) +
            Math.Sqrt(Math.Pow(Points[1].X - Points[2].X, 2) + Math.Pow(Points[1].Y - Points[2].Y, 2)) +
            Math.Sqrt(Math.Pow(Points[0].X - Points[2].X, 2) + Math.Pow(Points[0].Y - Points[2].Y, 2));

        }
        //Calculate the Square
        public override double Square()
        {
            double P2 = this.Perimetr() / 2;
            double S = Math.Sqrt((P2*(P2- Math.Sqrt(Math.Pow(Points[0].X - Points[1].X, 2) + Math.Pow(Points[0].Y - Points[1].Y, 2))) 
                * (P2- Math.Sqrt(Math.Pow(Points[1].X - Points[2].X, 2) + Math.Pow(Points[1].Y - Points[2].Y, 2))) 
                *(P2- Math.Sqrt(Math.Pow(Points[0].X - Points[2].X, 2) + Math.Pow(Points[0].Y - Points[2].Y, 2))))) ;


            return S;

        }
        public override void Draw()
        {
            int i = 1;
            while (i <= 5)
            {
                int k = 5;
                int h = 1;

                Console.WriteLine("");
                while (k > i)
                {
                    Console.Write(" ");
                    k--;
                }
                while (h <= i)
                {
                    Console.Write("**");
                    h++;
                }
                i++;
            }


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point[] dotinfo = new Point[3];
            Triangle myTriangle = new Triangle("Triangle", dotinfo);
            myTriangle.AddPoint(0, "A", 10, 10);
            myTriangle.AddPoint(1, "B", 20, 20);
            myTriangle.AddPoint(2, "C", 30, 10);
            myTriangle.Draw();
            Console.ReadKey();

        }
    }
}
