using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLib
{
    public abstract class BaseCircle : ICircle
    {
        public double Radius { get; set; }
        public Point Center { get; set; }
        public BaseCircle()
        {
            Center = new Point();
        }
        public BaseCircle(Point center, double r)
        {
            Radius = r;
            Center = center;
        }
        public abstract bool PointInCircle(Point p);
        public void SetRadius(double r)
        {
            Radius = r;
        }
        public void SetCenter(Point p)
        {
            Center = p;
        }
    }
}
