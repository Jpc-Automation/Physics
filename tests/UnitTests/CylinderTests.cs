﻿using Jpc.Physics;

namespace PhysicsUnitTests;
public class CylinderTests
{
    [Theory]
    [InlineData(1200, 0650, 0001, 799142.631)]
    [InlineData(1.200, 0.650, 0.001, 799.143)]
    //[InlineData(2115, 650, 1.0, 3181.432)]
    private void Cylinder_LengthFromDiameter(double outerDiameter, double innerDiameter, double stripThickness, double expected)
    {
        var result = Cylinder.CalculateStripLengthFromDiameter(outerDiameter, innerDiameter, stripThickness);
        var roundedResult = Math.Round(result, 3);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(6500, 1000, 1, 7.85, 828.025)]
    //[InlineData(6500, 1.0, 0.001, 7.85, 828.025)]
    private void Cylinder_LengthFromWeight(double weight, double stripWidth, double stripThickness, double density, double expected)
    {
        var result = Cylinder.CalculateStripLengthFromWeight(weight, stripWidth, stripThickness, density);
        var roundedResult = Math.Round(result, 3);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(799142.63125690375, 1000, 1, 799.143)]
    //[InlineData(799142.63125690375, 1.000, 0.001, 799.143)]
    private void Cylinder_LengthFromVolume(double volume, double stripWidth, double stripThickness, double expected)
    {
        var result = Cylinder.CalculateStripLengthFromVolume(volume, stripWidth, stripThickness);
        var roundedResult = Math.Round(result, 3);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(650.0, 799.143, 1, 1200)]
    private void Cylinder_DiameterFromStrip(double innerDiameter, double stripLength, double stripThickness, double expected)
    {
        var result = Cylinder.CalculateOuterDiameterFromStrip(innerDiameter, stripLength, stripThickness);
        var roundedResult = Math.Round(result, 1);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(6273, 650.0, 1000, 7.85, 1200)]
    private void Cylinder_DiameterFromWeight(double weight, double innerDiameter, double stripWidth, double density, double expected)
    {
        var result = Cylinder.CalculateOuterDiameterFromWeight(weight, innerDiameter, stripWidth, density);
        var roundedResult = Math.Round(result, 1);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(1200, 799.143, 1, 650)]
    private void Cylinder_InnerDiameterFromStrip(double outerDiameter, double stripLength, double stripThickness, double expected)
    {
        var result = Cylinder.CalculateInnerDiameterFromStrip(outerDiameter, stripLength, stripThickness);
        var roundedResult = Math.Round(result, 1);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(6273, 1200, 1, 7.85, 650)]
    private void Cylinder_InnerDiameterFromWeight(double weight, double outerDiameter, double stripWidth, double density, double expected)
    {
        var result = Cylinder.CalculateInnerDiameterFromWeight(weight, outerDiameter, stripWidth, density);
        var roundedResult = Math.Round(result, 1);

        Assert.Equal(expected, roundedResult);
    }


    [Theory]
    [InlineData(1200, 650, 1000, 7.85, 6273)]
    private void Cylinder_WeightFromDiameter(double outerDiameter, double innerDiameter, double stripWidth, double density, double expected)
    {
        var result = Cylinder.CalculateWeightFromDiameter(outerDiameter, innerDiameter, stripWidth, density);
        var roundedResult = Math.Round(result, 1);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(799.143, 1000, 1, 7.85, 6273)]
    private void Cylinder_WeightFromStrip(double stripLength, double stripWidth, double stripThickness, double density, double expected)
    {
        var result = Cylinder.CalculateWeightFromStrip(stripLength, stripWidth, stripThickness, density);
        var roundedResult = Math.Round(result, 1);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(799142.63125690375, 7.85, 6273.3)]
    private void Cylinder_WeightFromVolume(double volume, double density, double expected)
    {
        var result = Cylinder.CalculateWeightFromVolume(volume, density);
        var roundedResult = Math.Round(result, 1);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(6273, 650, 1000, 1000, 1, 7.85, 1200.4)]
    private void Cylinder_DrumOuterDiameter(double weight, double drumInnerDiameter, double freeWidthInDrum,
        double stripWidth, double gapBetweenWindings, double density, double expected)
    {
        var result = Cylinder.DrumOuterDiameter(weight, drumInnerDiameter, freeWidthInDrum, stripWidth, gapBetweenWindings, density);
        var roundedResult = Math.Round(result, 1);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(1200, 650, 1000, 3196571)]
    private void Cylinder_VolumeFromDiameter(double outerRadius, double innerRadius, double width, double expected)
    {
        var result = Cylinder.CalculateVolumeFromRadius(outerRadius, innerRadius, width);
        var roundedResult = Math.Round(result, 0);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(1200, 650, 1, 550)]
    private void Cylinder_NumberOfTurns(double outerRadius, double innerRadius, double stripThickness, double expected)
    {
        var result = Cylinder.CalculateNumberOfTurns(outerRadius, innerRadius, stripThickness);
        var roundedResult = Math.Round(result, 0);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(6273, 799142, 7.85)]
    private void Cylinder_DensityFromMass(double weight, double volume, double expected)
    {
        var result = Cylinder.CalculateDensity(weight, volume);
        var roundedResult = Math.Round(result, 2);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(6273, 0.6, 0.325, 1, 1460)]
    private void Cylinder_MomentOfInertiaZ(double mass, double outerRadius, double innerRadius, double height, double expected)
    {
        var result = Cylinder.CalculateMomentOfInertiaZ(mass, innerRadius, outerRadius, height);
        var roundedResult = Math.Round(result, 0);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(6273, 0.6, 0.325, 1, 1253)]
    private void Cylinder_MomentOfInertiaXY(double mass, double outerRadius, double innerRadius, double height, double expected)
    {
        var result = Cylinder.CalculateMomentOfInertiaXY(mass, innerRadius, outerRadius, height);
        var roundedResult = Math.Round(result, 0);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(0.6, 2.262)]
    private void Cylinder_CalculateBaseSurfaceArea(double outerRadius, double expected)
    {
        var result = Cylinder.CalculateBaseSurfaceArea(outerRadius);
        var roundedResult = Math.Round(result, 3);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(0.6, 1, 3.77)]
    private void Cylinder_CalculateLateralSurfaceArea(double outerRadius, double height, double expected)
    {
        var result = Cylinder.CalculateLateralSurfaceArea(outerRadius, height);
        var roundedResult = Math.Round(result, 3);

        Assert.Equal(expected, roundedResult);
    }

    [Theory]
    [InlineData(0.6, 1, 6.032)]
    private void Cylinder_CalculateTotalSurfaceArea(double outerRadius, double height, double expected)
    {
        var result = Cylinder.CalculateTotalSurfaceArea(outerRadius, height);
        var roundedResult = Math.Round(result, 3);

        Assert.Equal(expected, roundedResult);
    }
}
