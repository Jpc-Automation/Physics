namespace Jpc.Physics.Value;
public class ForceValue : ValueBase<double>
{
    public ForceValue(double value, Types valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public Types ValueType { get; private set; }

    public enum Types
    {
        Gram,
        Kilogram,
        Ton,
    }

    public static class Constants
    {
        /// <summary>
        /// (g = 9.80665 m/s²)
        /// </summary>
        public const double Gravity = 9.80665;
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
