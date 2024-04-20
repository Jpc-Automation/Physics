using Jpc.Physics.Value;

namespace PhysicsUnitTests.ValueTests;
public class ValueBaseTests
{
    public class TestValueObject : ValueBase<double>
    {
        public TestValueObject(int value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    [Fact]
    public void WithSameValuesHaveSameHashCode()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(1);

        // Act & Assert
        Assert.Equal(valueObject1.GetHashCode(), valueObject2.GetHashCode());
    }

    [Fact]
    public void WithDifferentValuesHashAreNotEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(2);

        // Act & Assert
        Assert.NotEqual(valueObject1.GetHashCode(), valueObject2.GetHashCode());
    }

    [Fact]
    public void WithSameValuesAreEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(1);

        // Act & Assert
        Assert.Equal(valueObject1, valueObject2);
    }

    [Fact]
    public void WithDifferentValuesAreNotEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1);
        var valueObject2 = new TestValueObject(2);

        // Act & Assert
        Assert.NotEqual(valueObject1, valueObject2);
    }
}
