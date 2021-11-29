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
            
            return 0;

        }
        //Calculate the Square
        public override double Square()
        {
            return 0;

        }
        public override void Draw()
        {



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
            Console.WriteLine(myTriangle.Perimetr());
            Console.ReadKey();

        }
    }
}
