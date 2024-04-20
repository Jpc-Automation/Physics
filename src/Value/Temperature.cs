namespace Jpc.Physics.Value;
public class Temperature : ValueBase<double>
{
    private double _baseValue_C => GetBaseValue();

    public Temperature(double value, Types valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public Types ValueType { get; set; }

    public enum Types
    {
        Kelvin,
        Celsius,
        Fahrenheit,
    }

    public static class Constants
    {
        public const double AbsoluteMinKelvin = 0;
        public const double AbsoluteMinCelsius = -273.15;
        public const double AbsoluteFahrenheit = -460;

        public const double Celsius = 1;
        public const double Kelvin = 274.15;
        public const double Fahrenheit = -33.8;
    }

    public static Temperature CreateKelvin(double value)
    {
        if (value < Constants.AbsoluteMinKelvin)
            throw new InvalidOperationException("Kelvin cannot be lower as 0");

        return new Temperature(value, Types.Kelvin, "K");
    }

    public static Temperature CreateCelsius(double value)
    {
        if (value < Constants.AbsoluteMinCelsius)
            throw new InvalidOperationException("Celsius cannot be lower as -273.15 °C");

        return new Temperature(value, Types.Kelvin, "°C");
    }

    public static Temperature CreateFahrenheit(double value)
    {
        if (value < Constants.AbsoluteFahrenheit)
            throw new InvalidOperationException("Celsius cannot be lower as -273.15 °C");

        return new Temperature(value, Types.Fahrenheit, "°F");
    }

    public double ToKelvin() => _baseValue_C * Constants.Kelvin;
    public double ToCelsius() => _baseValue_C * Constants.Celsius;
    public double ToFahrenheit() => _baseValue_C * Constants.Fahrenheit;

    private double GetBaseValue()
    {
        switch (ValueType)
        {
            case Types.Celsius: return Value / Constants.Celsius;
            case Types.Fahrenheit: return Value / Constants.Fahrenheit;
            case Types.Kelvin: return Value / Constants.Kelvin;
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
