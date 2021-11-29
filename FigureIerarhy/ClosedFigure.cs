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

        public double Perimetr()
        {

            return 0;
        }
      
        public double Square()
        {
            return 0;
        }
        public void Draw()
        {


        }
    }
}
