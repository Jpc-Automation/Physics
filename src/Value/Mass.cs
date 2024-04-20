namespace Jpc.Physics.Value;
public class Mass : ValueBase<double>
{
    private double _baseValue_kg => GetBaseValue();

    public Mass(double value, Types valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public Types ValueType { get; private set; }

    public enum Types
    {
        Milligram,
        Gram,
        Kilogram,
        Ton,
        Pound,
        Ounce,
    }

    public static class Constants
    {
        public const double MilliGram = 0.000001;
        public const double Gram = 0.001;
        public const double KiloGram = 1;
        public const double Ton = 1000;
        public const double Pounds = 2.205;
        public const double Ounces = 35.273962;
    }

    public static Mass CreateFromMilligrams(double value) => new Mass(value, Types.Milligram, "mg");
    public static Mass CreateFromGrams(double value) => new Mass(value, Types.Gram, "g");
    public static Mass CreateFromKilograms(double value) => new Mass(value, Types.Kilogram, "kg");
    public static Mass CreateFromTons(double value) => new Mass(value, Types.Ton, "t");
    public static Mass CreateFromPounds(double value) => new Mass(value, Types.Pound, "lb");
    public static Mass CreateFromOunces(double value) => new Mass(value, Types.Ounce, "oz");

    public double ToNanometers() => _baseValue_kg / Constants.MilliGram;
    public double ToGrams() => _baseValue_kg / Constants.Gram;
    public double ToKilograms() => _baseValue_kg / Constants.KiloGram;
    public double ToTons() => _baseValue_kg * Constants.Ton;
    public double ToPounds() => _baseValue_kg * Constants.Pounds;
    public double ToOunces() => _baseValue_kg * Constants.Ounces;

    private double GetBaseValue()
    {
        switch (ValueType)
        {
            case Types.Milligram: return Value * Constants.MilliGram;
            case Types.Gram: return Value * Constants.Gram;
            case Types.Kilogram: return Value / Constants.KiloGram;
            case Types.Ton: return Value / Constants.Ton;
            case Types.Pound: return Value / Constants.Pounds;
            case Types.Ounce: return Value / Constants.Ounces;
            default: return double.NaN;
        }
    }

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
