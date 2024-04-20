using Jpc.Physics.Value.Common;
using Jpc.Physics.Value.Enums;

namespace Jpc.Physics.Value;
public class AngularValue : ValueBase
{
    private double _baseValue_Degrees => GetBaseValue();

    public AngularValue(double value, AngularTypes valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public double Value { get; private set; }
    public AngularTypes ValueType { get; private set; }
    public string? Annotation { get; private set; }

    public static AngularValue CreateFromDegrees(double value) => new AngularValue(value, AngularTypes.Degrees, "°");
    public static AngularValue CreateFromRadians(double value) => new AngularValue(value, AngularTypes.Radians, "rad");

    public double ToDegrees() => _baseValue_Degrees;
    public double ToRadians() => _baseValue_Degrees * Constants.Angular.Radians;

    private double GetBaseValue()
    {
        switch (ValueType)
        {
            case AngularTypes.Degrees: return Value / Constants.Angular.Degrees;
            case AngularTypes.Radians: return Value / Constants.Angular.Radians;
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
