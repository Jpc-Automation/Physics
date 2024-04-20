using Jpc.Physics.Abstractions;

namespace PhysicsUnitTests;
public class PhysicsValueTests
{
    [Fact]
    private void PhysicsValue_Equality_Equal()
    {
        var physicsValueA = new PhysicsValue(33, ValueTypes.Millimeters);
        var physicsValueB = new PhysicsValue(33, ValueTypes.Millimeters);

        Assert.Equal(physicsValueA, physicsValueB);
    }

    [Fact]
    private void PhysicsValue_Equality_NotEqual()
    {
        var physicsValueA = new PhysicsValue(33, ValueTypes.Millimeters);
        var physicsValueB = new PhysicsValue(33, ValueTypes.Meters);

        Assert.NotEqual(physicsValueA, physicsValueB);
    }

    [Theory]
    [InlineData(1.269, 1269)]
    [InlineData(342.89, 342890)]
    private void PhysicsValue_FromMeter_ToMillimeter(double value, double expected)
    {
        var physicsValue = new PhysicsValue(value, ValueTypes.Meters);

        Assert.Equal(expected, physicsValue.ToMillimeters());
    }

    [Theory]
    [InlineData(1269, 1.269)]
    private void PhysicsValue_FromMillimeter_ToMeter(double value, double expected)
    {
        var physicsValue = new PhysicsValue(value, ValueTypes.Millimeters);

        Assert.Equal(expected, physicsValue.ToMeters());
    }

    [Theory]
    [InlineData(12.69, 12690)]
    private void PhysicsValue_FromKilometer_ToMeter(double value, double expected)
    {
        var physicsValue = new PhysicsValue(value, ValueTypes.Kilometers);

        Assert.Equal(expected, physicsValue.ToMeters());
    }
}
