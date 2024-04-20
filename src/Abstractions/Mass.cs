using Jpc.Physics.Value.Common;
using Jpc.Physics.Value.Enums;

namespace Jpc.Physics.Value;
public class Mass : ValueBase
{
    private double _baseValue_kg => GetBaseValue();

    public Mass(double value, MassTypes valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public double Value { get; private set; }
    public MassTypes ValueType { get; private set; }
    public string? Annotation { get; private set; }

    public static Mass CreateFromMilligrams(double value) => new Mass(value, MassTypes.Milligram, "mg");
    public static Mass CreateFromGrams(double value) => new Mass(value, MassTypes.Gram, "g");
    public static Mass CreateFromKilograms(double value) => new Mass(value, MassTypes.Kilogram, "kg");
    public static Mass CreateFromTons(double value) => new Mass(value, MassTypes.Ton, "t");
    public static Mass CreateFromPounds(double value) => new Mass(value, MassTypes.Pound, "lb");
    public static Mass CreateFromOunces(double value) => new Mass(value, MassTypes.Ounce, "oz");

    public double ToNanometers() => _baseValue_kg / Constants.Kg.MilliGram;
    public double ToGrams() => _baseValue_kg / Constants.Kg.Gram;
    public double ToKilograms() => _baseValue_kg / Constants.Kg.KiloGram;
    public double ToTons() => _baseValue_kg * Constants.Kg.Ton;
    public double ToPounds() => _baseValue_kg * Constants.Kg.Pounds;
    public double ToOunces() => _baseValue_kg * Constants.Kg.Ounces;

    private double GetBaseValue()
    {
        switch (ValueType)
        {
            case MassTypes.Milligram: return Value * Constants.Kg.MilliGram;
            case MassTypes.Gram: return Value * Constants.Kg.Gram;
            case MassTypes.Kilogram: return Value / Constants.Kg.KiloGram;
            case MassTypes.Ton: return Value / Constants.Kg.Ton;
            case MassTypes.Pound: return Value / Constants.Kg.Pounds;
            case MassTypes.Ounce: return Value / Constants.Kg.Ounces;
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
