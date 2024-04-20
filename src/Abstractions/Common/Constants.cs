namespace Jpc.Physics.Value.Common;

public static class Constants
{
    /// <summary>
    /// (g = 9.80665 m/s²)
    /// </summary>
    public const double Gravity = 9.80665;

    public static class Angular
    {
        public const double Degrees = 1;
        public const double Radians = 0.0174532925;
    }

    public static class Mm
    {
        public const double Nanometer = 1000 * Micrometer;
        public const double Micrometer = 1000;
        public const double Millimeter = 1;
        public const double Centimeter = 10;
        public const double Decimeter = 100;
        public const double Meter = 1000;
        public const double HectoMeter = 100 * Meter;
        public const double KiloMeter = 1000 * Meter;
    }

    public static class Kg
    {
        public const double MilliGram = 0.000001;
        public const double Gram = 0.001;
        public const double KiloGram = 1;
        public const double Ton = 1000;
        public const double Pounds = 2.205;
        public const double Ounces = 35.273962;
    }

    public static class Temperature
    {
        public const double AbsoluteMinKelvin = 0;
        public const double AbsoluteMinCelsius = -273.15;
        public const double AbsoluteFahrenheit = -460;

        public const double Celsius = 1;
        public const double Kelvin = 274.15;
        public const double Fahrenheit = -33.8;
    }

    /// <summary>
    /// Density of the most common metals in g/m³
    /// </summary>
    public static class MetalDensity
    {
        public const double Aluminum = 2.7;
        public const double ZincTitanium = 7.2;
        public const double Zinc = 7.1;
        public const double Tin = 7.28;
        public const double StainlessSteel = 7.80;
        public const double Steel = 7.85;
        public const double MildSteel = 7.9;
        public const double Bronze = 8.15;
        public const double BerylliumCopper = 8.17;
        public const double AluminumBronze = 8.2;
        public const double PhosphorousBronze = 8.85;
        public const double Nickel = 8.8;
        public const double Copper = 8.93;
        public const double Brass = 9.07;
        public const double LeadBronze = 9.15;
        public const double Silver = 10.49;
        public const double Lead = 11.4;
        public const double Gold = 19.3;
        public const double Platinum = 21.37;
    }

}

