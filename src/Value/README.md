
[![NuGet](https://img.shields.io/nuget/v/Jpc.Physics.Value.svg)](https://www.nuget.org/packages/Jpc.Physics.Value)[![NuGet](https://img.shields.io/nuget/dt/Jpc.Physics.Value.svg)](https://www.nuget.org/packages/Jpc.Physics.Value)

## Documentation

ValueTypes with conversions

- Acceleration
- Angular
- Density
- Energy
- Mass
- Pressure
- Temperature
- Velocity


## Usage Distance
```C#
// Conversion
var valueMillimeter = new Distance(1265, Distance.Types.Millimeters);
var valueMeter = valueMillimeter.ToMeters();
var valueCentimeter = valueMillimeter.ToCentimeters();

// Compare equal
var valueEqualA = new Distance(1265, Distance.Types.Millimeters);
var valueEqualB = new Distance(1265, Distance.Types.Millimeters);
var isEqual = valueEqualA = valueEqualB;

// Compare not equal
var valueNotEqualA = new Distance(1211, Distance.Types.Millimeters);
var valueNotEqualB = new Distance(1265, Distance.Types.Millimeters);
var isNotEqual = valueNotEqualA = valueNotEqualB;
```