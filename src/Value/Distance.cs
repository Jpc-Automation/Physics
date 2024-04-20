namespace Jpc.Physics.Value;
public class Distance : ValueBase<double>
{
    private double _baseValue_MM => GetBaseValue();

    public Distance(double value, Types valueType, string? annotation = null)
    {
        Value = value;
        Annotation = annotation;
        ValueType = valueType;
    }

    public Types ValueType { get; private set; }

    public enum Types
    {
        Nanometers,
        Micrometers,
        Millimeters,
        Centimeters,
        Decimeters,
        Meters,
        Hectometers,
        Kilometers
    }

    public static class Constants
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

    public static Distance CreateFromNanometers(double value) => new Distance(value, Types.Nanometers, "nm");
    public static Distance CreateFromMicrometers(double value) => new Distance(value, Types.Micrometers, "µm");
    public static Distance CreateFromMillimeters(double value) => new Distance(value, Types.Millimeters, "mm");
    public static Distance CreateFromCentimeters(double value) => new Distance(value, Types.Centimeters, "cm");
    public static Distance CreateFromDecimeters(double value) => new Distance(value, Types.Decimeters, "dm");
    public static Distance CreateFromMeters(double value) => new Distance(value, Types.Meters, "m");
    public static Distance CreateFromHectometers(double value) => new Distance(value, Types.Hectometers, "hm");
    public static Distance CreateFromKilometers(double value) => new Distance(value, Types.Kilometers, "km");

    public double ToNanometers() => _baseValue_MM * Constants.Nanometer;
    public double ToMicrometers() => _baseValue_MM * Constants.Micrometer;
    public double ToMillimeters() => _baseValue_MM / Constants.Millimeter;
    public double ToCentimeters() => _baseValue_MM / Constants.Centimeter;
    public double ToDecimeters() => _baseValue_MM / Constants.Decimeter;
    public double ToMeters() => _baseValue_MM / Constants.Meter;
    public double ToHectometers() => _baseValue_MM / Constants.HectoMeter;
    public double ToKilometers() => _baseValue_MM / Constants.KiloMeter;

    private double GetBaseValue()
    {
        switch (ValueType)
        {
            case Types.Nanometers: return Value / Constants.Nanometer;
            case Types.Micrometers: return Value / Constants.Micrometer;
            case Types.Millimeters: return Value * Constants.Millimeter;
            case Types.Centimeters: return Value * Constants.Centimeter;
            case Types.Decimeters: return Value * Constants.Meter;
            case Types.Meters: return Value * Constants.Meter;
            case Types.Hectometers: return Value * Constants.HectoMeter;
            case Types.Kilometers: return Value * Constants.KiloMeter;
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
