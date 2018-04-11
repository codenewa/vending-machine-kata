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

        public CoinValue Value
        {
            get
            {
                if (this.Diameter == 24.16 && this.Width == 1.75 && this.Weight == 5.67)
                    return CoinValue.Quarter;
                else
                    return CoinValue.Invalid;
            }
        }
    }
}
