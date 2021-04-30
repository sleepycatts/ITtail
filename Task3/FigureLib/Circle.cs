using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLib
{
    public class Circle : BaseCircle
    {
        public Circle() : base()
        {
        }
        public Circle(Point center, double r) : base(center, r)
        {
        }

        public override bool PointInCircle(Point p)
        {
            return Center.Distance(p) <= Radius;
        }
    }
}
