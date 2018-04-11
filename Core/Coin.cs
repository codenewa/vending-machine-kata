using System;

namespace Core
{
    public class Coin
    {

        #region Constants
        public const double QuarterDiameter = 24.16d;
        public const double QuarterWidth = 1.75d;
        public const double QuarterWeight = 5.67d;
        public const double QuarterValue = 0.25d;

        public static Coin Quarter => new Coin(QuarterDiameter, QuarterWidth, QuarterWeight);

        public const double NickelDiameter = 21.21d;
        public const double NickelWidth = 1.95d;
        public const double NickelWeight = 5d;
        public const double NickelValue = 0.05d;
        public static Coin Nickel => new Coin(NickelDiameter, NickelWidth, NickelWeight);

        public const double DimeDiameter = 17.91d;
        public const double DimeWidth = 1.35d;
        public const double DimeWeight = 2.268d;
        public const double DimeValue = 0.1d;

        public static Coin Dime => new Coin(DimeDiameter, DimeWidth, DimeWeight);

        public double Diameter { get; private set; }
        public double Width { get; private set; }
        public double Weight { get; private set; }

        public const double InvalidValue = 0d;
        #endregion

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

        public double MonetaryValue
        {
            get
            {
                switch (this.Value)
                {
                    case CoinValue.Quarter: return Coin.QuarterValue;
                    case CoinValue.Dime: return Coin.DimeValue;
                    case CoinValue.Nickel: return Coin.NickelValue;
                    default: return 0;
                }
            }
        }
    }
}
