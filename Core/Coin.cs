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
                else if (this.Diameter == 21.21 && this.Width == 1.95 && this.Weight == 5)
                    return CoinValue.Nickel;
                else if (this.Diameter == 17.91 && this.Width == 1.35 && this.Weight == 2.268)
                    return CoinValue.Dime;
                else
                    return CoinValue.Invalid;
            }
        }
    }
}
