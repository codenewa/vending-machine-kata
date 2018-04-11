using System;

namespace Core
{
    public class Coin
    {
        public double Diameter { get; private set; }
        public double Width { get; private set; }
        public double Weight { get; private set; }


        public Coin(double diameter, double width, double weight)
        {
            Diameter = diameter;
            Width = width;
            Weight = weight;
        }
    }
}
