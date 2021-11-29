using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureIerarhy
{
    class ClosedFigure
    {
        public string Name { get; init; }
        public Point[] Points { get; init; }
       
        public ClosedFigure(string name, Point[] points)
          => (Name, Points ) = (name, points) ;
        public void AddPoint(int index, string name, int x, int y)
        {
            Points[index] = new Point (name,x,y);
        }

        virtual public double Perimetr()
        {

            return 0;
        }
      
        virtual public double Square()
        {
            return 0;
        }
        virtual public void Draw()
        {


        }
    }
}
