using System.Collections.Generic;
using System.Drawing;

namespace JuegoDeLaVida
{
    public struct Celda
    {
        #region Properties
        public Point Ubicacion { get; set; }
        public List<Point> Vecinos { get; set; }
        public byte Cantidad { get; set; }
        public bool Viva { get; set; }
        public int Edad { get; set; } 
        #endregion

        #region Constructor
        public Celda(int X, int Y)
            : this()
        {
            this.Ubicacion = new Point(X, Y);
            this.Cantidad = 0;
            this.Vecinos = new List<Point>(8);
            this.Edad = 0;
            this.Viva = false;
        } 
        #endregion
    }
}
