using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureIerarhy
{
    class CircleFigure
    {
        public string Name { get; init; }
        public Point[] Points { get; init; }
        public double BigRadius { get; set; }
        public double SmallRadius { get; set; }
        public CircleFigure(string name, Point[] points, double bigradius, double smallradius)
          => (Name, Points, BigRadius, SmallRadius) = (name, points, bigradius, smallradius);

        public double Diametr()
        {

            return 0;
        }
        public double CircleLength()
        {

            return Math.PI * (this.BigRadius + this.SmallRadius);
        }
        public double Square()
        {
            return 2 * Math.PI * this.BigRadius * this.SmallRadius;
        }
        public void Draw()
        {


        }
    }
}
