using Jpc.Physics.Value.Common;

namespace Jpc.Physics.Value;
public class Density : ValueBase
{
    public Density(double value, Types valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public double Value { get; private set; }
    public Types ValueType { get; private set; }
    public string? Annotation { get; private set; }

    public enum Types
    {
        kg_m3,
        g_cm3
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
