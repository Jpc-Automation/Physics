using Jpc.Physics.Value.Common;
using Jpc.Physics.Value.Enums;

namespace Jpc.Physics.Value;
public class ForceValue : ValueBase
{
    public ForceValue(double value, ForceTypes valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public double Value { get; private set; }
    public ForceTypes ValueType { get; private set; }
    public string? Annotation { get; private set; }

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
