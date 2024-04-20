namespace Jpc.Physics.Value;
public class AngularValue : ValueBase<double>
{
    private double _baseValue_Degrees => GetBaseValue();

    public AngularValue(double value, Types valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public Types ValueType { get; private set; }

    public enum Types
    {
        Degrees,
        Radians
    }

    public static class Constants
    {
        public const double Degrees = 1;
        public const double Radians = 0.0174532925;
    }

    public static AngularValue CreateFromDegrees(double value) => new AngularValue(value, Types.Degrees, "°");
    public static AngularValue CreateFromRadians(double value) => new AngularValue(value, Types.Radians, "rad");

    public double ToDegrees() => _baseValue_Degrees;
    public double ToRadians() => _baseValue_Degrees * Constants.Radians;

    private double GetBaseValue()
    {
        switch (ValueType)
        {
            case Types.Degrees: return Value / Constants.Degrees;
            case Types.Radians: return Value / Constants.Radians;
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
