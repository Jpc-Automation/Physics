using Jpc.Physics.Value.Common;
using Jpc.Physics.Value.Enums;

namespace Jpc.Physics.Value;
public class Temperature : ValueBase
{
    private double _baseValue_C => GetBaseValue();

    public Temperature(double value, TemperatureTypes valueType, string? annotation = null)
    {
        Value = value;
        ValueType = valueType;
        Annotation = annotation;
    }

    public double Value { get; set; }
    public TemperatureTypes ValueType { get; set; }
    public string? Annotation { get; set; }

    public static Temperature CreateKelvin(double value)
    {
        if (value < Constants.Temperature.AbsoluteMinKelvin)
            throw new InvalidOperationException("Kelvin cannot be lower as 0");

        return new Temperature(value, TemperatureTypes.Kelvin, "K");
    }

    public static Temperature CreateCelsius(double value)
    {
        if (value < Constants.Temperature.AbsoluteMinCelsius)
            throw new InvalidOperationException("Celsius cannot be lower as -273.15 °C");

        return new Temperature(value, TemperatureTypes.Kelvin, "°C");
    }

    public static Temperature CreateFahrenheit(double value)
    {
        if (value < Constants.Temperature.AbsoluteFahrenheit)
            throw new InvalidOperationException("Celsius cannot be lower as -273.15 °C");

        return new Temperature(value, TemperatureTypes.Fahrenheit, "°F");
    }

    public double ToKelvin() => _baseValue_C * Constants.Temperature.Kelvin;
    public double ToCelsius() => _baseValue_C * Constants.Temperature.Celsius;
    public double ToFahrenheit() => _baseValue_C * Constants.Temperature.Fahrenheit;

    private double GetBaseValue()
    {
        switch (ValueType)
        {
            case TemperatureTypes.Celsius: return Value / Constants.Temperature.Celsius;
            case TemperatureTypes.Fahrenheit: return Value / Constants.Temperature.Fahrenheit;
            case TemperatureTypes.Kelvin: return Value / Constants.Temperature.Kelvin;
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
