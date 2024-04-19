namespace Jpc.Physics.Abstractions;
public class PhysicsValue : ValueBase
{
    private double _baseValue_MM => GetBaseValue();

    public PhysicsValue(double value, ValueTypes valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public double Value { get; set; }
    public ValueTypes ValueType { get; set; }
    public string? Annotation { get; set; }

    public static PhysicsValue CreateFromNanometers(double value) => new PhysicsValue(value, ValueTypes.Nanometers, "nm");
    public static PhysicsValue CreateFromMicrometers(double value) => new PhysicsValue(value, ValueTypes.Micrometers, "µm");
    public static PhysicsValue CreateFromMillimeters(double value) => new PhysicsValue(value, ValueTypes.Millimeters, "mm");
    public static PhysicsValue CreateFromCentimeters(double value) => new PhysicsValue(value, ValueTypes.Centimeters, "cm");
    public static PhysicsValue CreateFromDecimeters(double value) => new PhysicsValue(value, ValueTypes.Decimeters, "dm");
    public static PhysicsValue CreateFromMeters(double value) => new PhysicsValue(value, ValueTypes.Meters, "m");
    public static PhysicsValue CreateFromHectometers(double value) => new PhysicsValue(value, ValueTypes.Hectometers, "hm");
    public static PhysicsValue CreateFromKilometers(double value) => new PhysicsValue(value, ValueTypes.Kilometers, "km");

    public double ToNanometers() => _baseValue_MM * Constants.Mm.Nanometer;
    public double ToMicrometers() => _baseValue_MM * Constants.Mm.Micrometer;
    public double ToMillimeters() => _baseValue_MM / Constants.Mm.Millimeter;
    public double ToCentimeters() => _baseValue_MM / Constants.Mm.Centimeter;
    public double ToDecimeters() => _baseValue_MM / Constants.Mm.Decimeter;
    public double ToMeters() => _baseValue_MM / Constants.Mm.Meter;
    public double ToHectometers() => _baseValue_MM / Constants.Mm.HectoMeter;
    public double ToKilometers() => _baseValue_MM / Constants.Mm.KiloMeter;

    public override string ToString()
    {
        return Value.ToString() + ' ' + ValueType.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return ValueType;
    }

    private double GetBaseValue()
    {
        switch (ValueType)
        {
            case ValueTypes.Nanometers: return Value / Constants.Mm.Nanometer;
            case ValueTypes.Micrometers: return Value / Constants.Mm.Micrometer;
            case ValueTypes.Millimeters: return Value * Constants.Mm.Millimeter;
            case ValueTypes.Centimeters: return Value * Constants.Mm.Centimeter;
            case ValueTypes.Decimeters: return Value * Constants.Mm.Meter;
            case ValueTypes.Meters: return Value * Constants.Mm.Meter;
            case ValueTypes.Hectometers: return Value * Constants.Mm.HectoMeter;
            case ValueTypes.Kilometers: return Value * Constants.Mm.KiloMeter;
            default: return double.NaN;
        }
    }
}
