using System;

namespace Core
{
    public class Coin
    {

        public const double QuarterDiameter = 24.16d;
        public const double QuarterWidth = 1.75d;
        public const double QuarterWeight = 5.67d;

        public const double NickelDiameter = 21.21d;
        public const double NickelWidth = 1.95d;
        public const double NickelWeight = 5d;

        public const double DimeDiameter = 17.91d;
        public const double DimeWidth = 1.35d;
        public const double DimeWeight = 2.268d;

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
                if (this.Diameter == QuarterDiameter && this.Width == QuarterWidth && this.Weight == QuarterWeight)
                    return CoinValue.Quarter;
                else if (this.Diameter == NickelDiameter && this.Width == NickelWidth && this.Weight == NickelWeight)
                    return CoinValue.Nickel;
                else if (this.Diameter == DimeDiameter && this.Width == DimeWidth && this.Weight == DimeWeight)
                    return CoinValue.Dime;
                else
                    return CoinValue.Invalid;
            }
        }
    }
}
