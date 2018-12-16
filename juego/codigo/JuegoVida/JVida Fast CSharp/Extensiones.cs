using System.Collections.Generic;
using System.Drawing;

namespace JuegoDeLaVida
{
    public static class Extensiones
    {
        public static void Add(this IList<Point> a, int X, int Y)
        {
            a.Add(new Point(X, Y));
        }
    }

}

