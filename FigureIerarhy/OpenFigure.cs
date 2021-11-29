using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureIerarhy
{
    class OpenFigure
    {
        public string Name { get; init; }
        public Point[] Points { get; init; }
       
        public OpenFigure(string name, Point[] points )
          => (Name, Points) = (name, points);

       
        public double Length()
        {

            return 0;
        }
       
        public void Draw()
        {


        }
    }
}
