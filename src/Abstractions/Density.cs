namespace Jpc.Physics.Value;
public class Density : ValueBase<double>
{
    public Density(double value, Types valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public Types ValueType { get; private set; }

    public enum Types
    {
        kg_m3,
        g_cm3
    }

    /// <summary>
    /// Density of the most common metals in g/m³
    /// </summary>
    public static class MetalDensities
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

    public double ToKgCm3() => 0;

    public override string ToString()
    {
        return Value.ToString() + ' ' + Annotation;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return ValueType;
    }
}
