using Jpc.Physics.Value.Common;
using Jpc.Physics.Value.Enums;

namespace Jpc.Physics.Value;
public class Distance : ValueBase
{
    private double _baseValue_MM => GetBaseValue();

    public Distance(double value, DistanceTypes valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public double Value { get; private set; }
    public DistanceTypes ValueType { get; private set; }
    public string? Annotation { get; private set; }

    public static Distance CreateFromNanometers(double value) => new Distance(value, DistanceTypes.Nanometers, "nm");
    public static Distance CreateFromMicrometers(double value) => new Distance(value, DistanceTypes.Micrometers, "µm");
    public static Distance CreateFromMillimeters(double value) => new Distance(value, DistanceTypes.Millimeters, "mm");
    public static Distance CreateFromCentimeters(double value) => new Distance(value, DistanceTypes.Centimeters, "cm");
    public static Distance CreateFromDecimeters(double value) => new Distance(value, DistanceTypes.Decimeters, "dm");
    public static Distance CreateFromMeters(double value) => new Distance(value, DistanceTypes.Meters, "m");
    public static Distance CreateFromHectometers(double value) => new Distance(value, DistanceTypes.Hectometers, "hm");
    public static Distance CreateFromKilometers(double value) => new Distance(value, DistanceTypes.Kilometers, "km");

    public double ToNanometers() => _baseValue_MM * Constants.Mm.Nanometer;
    public double ToMicrometers() => _baseValue_MM * Constants.Mm.Micrometer;
    public double ToMillimeters() => _baseValue_MM / Constants.Mm.Millimeter;
    public double ToCentimeters() => _baseValue_MM / Constants.Mm.Centimeter;
    public double ToDecimeters() => _baseValue_MM / Constants.Mm.Decimeter;
    public double ToMeters() => _baseValue_MM / Constants.Mm.Meter;
    public double ToHectometers() => _baseValue_MM / Constants.Mm.HectoMeter;
    public double ToKilometers() => _baseValue_MM / Constants.Mm.KiloMeter;

    private double GetBaseValue()
    {
        switch (ValueType)
        {
            case DistanceTypes.Nanometers: return Value / Constants.Mm.Nanometer;
            case DistanceTypes.Micrometers: return Value / Constants.Mm.Micrometer;
            case DistanceTypes.Millimeters: return Value * Constants.Mm.Millimeter;
            case DistanceTypes.Centimeters: return Value * Constants.Mm.Centimeter;
            case DistanceTypes.Decimeters: return Value * Constants.Mm.Meter;
            case DistanceTypes.Meters: return Value * Constants.Mm.Meter;
            case DistanceTypes.Hectometers: return Value * Constants.Mm.HectoMeter;
            case DistanceTypes.Kilometers: return Value * Constants.Mm.KiloMeter;
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
