using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLib
{
    interface ICircle
    {
        bool PointInCircle(Point p);
        void SetRadius(double r);
        void SetCenter(Point p);
    }
}
