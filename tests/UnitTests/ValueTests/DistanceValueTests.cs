using Jpc.Physics.Value;

namespace PhysicsUnitTests.ValueTests;
public class DistanceValueTests
{
    [Fact]
    private void Value_Equality_Equal()
    {
        var physicsValueA = new Distance(33, Distance.Types.Millimeters);
        var physicsValueB = new Distance(33, Distance.Types.Millimeters);

        Assert.Equal(physicsValueA, physicsValueB);
    }

    [Fact]
    private void Value_Equality_NotEqual()
    {
        var physicsValueA = new Distance(33, Distance.Types.Millimeters);
        var physicsValueB = new Distance(33, Distance.Types.Meters);

        Assert.NotEqual(physicsValueA, physicsValueB);
    }

    [Theory]
    [InlineData(1.269, 1269)]
    [InlineData(342.89, 342890)]
    private void Value_FromMeter_ToMillimeter(double value, double expected)
    {
        var physicsValue = new Distance(value, Distance.Types.Meters);

        Assert.Equal(expected, physicsValue.ToMillimeters());
    }

    [Theory]
    [InlineData(1269, 1.269)]
    private void Value_FromMillimeter_ToMeter(double value, double expected)
    {
        var physicsValue = new Distance(value, Distance.Types.Millimeters);

        Assert.Equal(expected, physicsValue.ToMeters());
    }

    [Theory]
    [InlineData(12.69, 12690)]
    private void Value_FromKilometer_ToMeter(double value, double expected)
    {
        var physicsValue = new Distance(value, Distance.Types.Kilometers);

        Assert.Equal(expected, physicsValue.ToMeters());
    }
}
