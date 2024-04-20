namespace Jpc.Physics.Value;
public class Pressure : ValueBase<double>
{
    public Pressure(double value, Types valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public Types ValueType { get; private set; }

    public enum Types
    {
        Pascal_Pa,
        Atmosphere_atm,
        Bar,
        Torr,
        PerSquareInch_psi
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
