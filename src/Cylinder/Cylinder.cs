namespace Jpc.Physics;

/// <summary>
/// Default units: mass = kg, density = g/cm3
/// </summary>
public class Cylinder
{
    //public double OuterDiameter { get; init; }
    //public double InnerDiameter { get; init; }
    //public double Width { get; init; }
    //public double Weight { get; init; }
    //public required double Density { get; init; }
    ////
    //public double Radius { get; init; }
    //public double Mass { get; private set; }
    //public double Volume { get; init; }
    //public double MomentOfInertiaXY { get; private set; }
    //public double MomentOfInertiaZ { get; private set; }
    //public double BaseSurfaceArea { get; private set; }
    //public double LateralSurfaceArea { get; private set; }
    //public double TotalSurfaceArea { get; private set; }

    // ToDo: Calculate innerDiameter from outerDiameter and thickness

    /// <summary>
    /// When input is mm the output will be mm to
    /// <para>Formula: <code>((D2 - d2) * π) / (4 * s)</code></para>
    /// </summary>
    /// <param name="outerDiameter">outer diameter (mm)</param>
    /// <param name="innerDiameter">inner diameter (mm)</param>
    /// <param name="stripThickness">strip thickness (mm)</param>
    /// <example><code>var lengthFromDiameter = CoilCalculator.CalculateStripLengthFromDiameter(_outerDiameter, _innerDiameter, _thickness)</code></example>
    /// <returns>The strip Length (m)</returns>
    public static double CalculateStripLengthFromDiameter(double outerDiameter, double innerDiameter, double stripThickness)
    {
        var length = (outerDiameter * outerDiameter - innerDiameter * innerDiameter) * Math.PI / (4 * stripThickness);
        return length;
    }

    /// <summary>
    /// Formula: G / (b * s * g)
    /// </summary>
    /// <param name="weight">weight (kg)</param>
    /// <param name="stripWidth">strip width (mm)</param>
    /// <param name="stripThickness">strip thickness (mm)</param>
    /// <param name="density">density (g/cm3)</param>
    /// <returns>The Strip length (m)</returns>
    public static double CalculateStripLengthFromWeight(double weight, double stripWidth, double stripThickness, double density)
    {
        //var length = weight / (stripWidth * (stripThickness / 1000) * density);
        var length = weight / (stripWidth * (stripThickness / 1000) * density);
        return length;
    }

    /// <summary>
    /// Formula: v = ( v / ( b * s) )
    /// </summary>
    /// <param name="volume">volume (cm3)</param>
    /// <param name="stripThickness">strip thickness (mm)</param>
    /// <param name="stripWidth">strip width (mm)</param>
    /// <returns>The Strip Length (m)</returns>
    public static double CalculateStripLengthFromVolume(double volume, double stripWidth, double stripThickness)
    {
        var length = volume / (stripWidth * stripThickness);
        return length;
    }

    /// <summary>
    /// Formula: √ (((4 * s * l) / π) + (d2)) 
    /// </summary>
    /// <param name="stripLength">strip length (m)</param>
    /// <param name="innerDiameter">inner diameter (mm)</param>
    /// <param name="stripThickness">strip thickness (mm)</param>
    /// <returns>The outer Diameter (mm)</returns>
    public static double CalculateOuterDiameterFromStrip(double innerDiameter, double stripLength, double stripThickness)
    {
        var outerDiameter = Math.Sqrt(4 * stripThickness * stripLength * 1000 / Math.PI + innerDiameter * innerDiameter);
        return outerDiameter;
    }

    /// <summary>
    /// Formula: √ (((4 * G) / (π * b * g)) + (d2)) 
    /// </summary>
    /// <param name="weight">weight (kg)</param>
    /// <param name="innerDiameter">inner diameter (mm)</param>
    /// <param name="stripWidth">strip width (mm)</param>
    /// <param name="density">density (g/cm3)</param>
    /// <returns>The outer Diameter (mm)</returns>
    public static double CalculateOuterDiameterFromWeight(double weight, double innerDiameter, double stripWidth, double density)
    {
        var outerDiameter = Math.Sqrt(4 * weight * 1000 / (Math.PI * stripWidth * (density / 1000)) + innerDiameter * innerDiameter);
        return outerDiameter;
    }

    /// <summary>
    /// Formula: <code>Inner Diameter = √(Outer Diameter² - (4 * Strip Thickness * Strip Length * 1000) / π)</code>
    /// </summary>
    /// <param name="outerDiameter"></param>
    /// <param name="stripLength"></param>
    /// <param name="stripThickness"></param>
    /// <returns>The inner diameter</returns>
    public static double CalculateInnerDiameterFromStrip(double outerDiameter, double stripLength, double stripThickness)
    {
        var innerDiameter = Math.Sqrt(Math.Pow(outerDiameter, 2) - 4 * stripThickness * stripLength * 1000 / Math.PI);
        return innerDiameter;
    }

    /// <summary>
    /// Formula: <code>Inner Diameter = √(Outer Diameter² - (4 * Weight) / (π * Strip Width * (Density / 1000)))</code>
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="outerDiameter"></param>
    /// <param name="stripWidth"></param>
    /// <param name="density"></param>
    /// <returns>The inner diameter</returns>
    public static double CalculateInnerDiameterFromWeight(double weight, double outerDiameter, double stripWidth, double density)
    {
        var innerDiameter = Math.Sqrt(Math.Pow(outerDiameter, 2) - 4 * weight / (Math.PI * stripWidth * (density / 1000)));
        return innerDiameter;
    }

    /// <summary>
    /// Formula: ((D2 - d2) * π * b * g) / 4
    /// </summary>
    /// <param name="outerDiameter">outer diameter (mm)</param>
    /// <param name="innerDiameter">inner diameter (mm)</param>
    /// <param name="stripWidth">strip width (mm)</param>
    /// <param name="density">density in (g/cm3)</param>
    /// <returns>The Weight (kg)</returns>
    public static double CalculateWeightFromDiameter(double outerDiameter, double innerDiameter, double stripWidth, double density)
    {
        var length = Math.Round((outerDiameter * outerDiameter - innerDiameter * innerDiameter) * Math.PI * stripWidth * (density / 1000) / 4 / 1000);
        return length;
    }

    /// <summary>
    /// Formula: g * l * b * s
    /// </summary>
    /// <param name="stripLength">strip length (m)</param>
    /// <param name="stripWidth">strip width (mm)</param>
    /// <param name="stripThickness">strip thickness (mm)</param>
    /// <param name="density">density in (g/cm3)</param>
    /// <returns>The Weight (kg)</returns>
    public static double CalculateWeightFromStrip(double stripLength, double stripWidth, double stripThickness, double density)
    {
        var length = Math.Round(density * stripLength * stripWidth * stripThickness / 1000);
        return length;
    }

    /// <summary>
    /// Formula: <code>Weight = Volume * Density / 1000</code>
    /// </summary>
    /// <param name="volume">volume (cm3)</param>
    /// <param name="density">density in (g/cm3)</param>
    /// <returns>The weight in Kg</returns>
    public static double CalculateWeightFromVolume(double volume, double density)
    {
        var weightCalc = volume * density / 1000;
        var mass = Math.Round(weightCalc, 2);
        return mass;
    }

    /// <summary>
    /// Formula: √ (((4 * G) / (π * b2 * G)) + (d2))
    ///                 b2 = ((B* b) / (b + S))
    /// </summary>
    /// <param name="weight">weight (kg)</param>
    /// <param name="drumInnerDiameter">drum inner diameter (mm)</param>
    /// <param name="freeWidthInDrum">free width inside the drum (mm)</param>
    /// <param name="stripWidth">strip width (mm)</param>
    /// <param name="gapBetweenWindings">gap between the windings</param>
    /// <param name="density">density in (g/cm3)</param>
    /// <returns>The drum Outer Diameter (mm)</returns>
    public static double DrumOuterDiameter(double weight, double drumInnerDiameter, double freeWidthInDrum,
        double stripWidth, double gapBetweenWindings, double density)
    {
        var diaExt = Math.Sqrt(4 * weight * 1000 / (Math.PI * (freeWidthInDrum * stripWidth / (stripWidth + gapBetweenWindings)) * (density / 1000)) + drumInnerDiameter * drumInnerDiameter);

        return diaExt;
    }

    /// <summary>
    /// Formula: <code>Volume = ((Outer Radius² - Inner Radius²) * π * Width) / 1000</code>
    /// </summary>
    /// <param name="outerRadius">outer radius (mm)</param>
    /// <param name="innerRadius">inner radius (mm)</param>
    /// <param name="width">width (mm)</param>
    /// <returns>The Volume in cubic centimeters cm3</returns>
    public static double CalculateVolumeFromRadius(double outerRadius, double innerRadius, double width)
    {
        var volume = (outerRadius * outerRadius * Math.PI - innerRadius * innerRadius * Math.PI) * width / 1000;
        return volume;
    }

    /// <summary>
    /// Calculates the number of turns
    /// </summary>
    /// <param name="outerRadius">outer radius (mm)</param>
    /// <param name="innerRadius">inner radius (mm)</param>
    /// <param name="stripThickness">thickness (mm)</param>
    /// <returns>The total number of turns</returns>
    public static double CalculateNumberOfTurns(double outerRadius, double innerRadius, double stripThickness)
    {
        var numberOfTurns = (outerRadius - innerRadius) / stripThickness;
        return numberOfTurns;
    }

    /// <summary>
    /// Calculates the density
    /// </summary>
    /// <param name="weight">weight (kg)</param>
    /// <param name="volume">volume (cm3)</param>
    /// <returns>The Density (g/cm³)</returns>
    public static double CalculateDensity(double weight, double volume)
    {
        // Calculate the density to Kg/cm³
        var Density = weight / volume;

        // Convert to g/cm³
        return Density * 1000;
    }

    /// <summary>
    /// Formula: <code>Moment of Inertia (Z-axis) = 0.5 * Mass * (Outer Radius² + Inner Radius²)</code>
    /// </summary>
    /// <param name="mass"></param>
    /// <param name="innerRadius"></param>
    /// <param name="outerRadius"></param>
    /// <param name="height"></param>
    /// <returns>The moment of inertia Z (kg*m^2)</returns>
    public static double CalculateMomentOfInertiaZ(double mass, double outerRadius, double innerRadius, double height)
    {
        var momentOfInertia = 1.0 / 2.0 * mass * (Math.Pow(outerRadius, 2) + Math.Pow(innerRadius, 2));
        return momentOfInertia;
    }

    /// <summary>
    /// Calculate the moment of inertia in the x and y directions
    /// Formula: <code>Moment of Inertia (XY-plane) = 1/12 * Mass * (3 * (Inner Radius² + Outer Radius²) + Height²)</code>
    /// </summary>
    /// <param name="mass"></param>
    /// <param name="innerRadius"></param>
    /// <param name="outerRadius"></param>
    /// <param name="height"></param>
    /// <returns>The moment of inertia XY (kg*m^2)</returns>
    public static double CalculateMomentOfInertiaXY(double mass, double outerRadius, double innerRadius, double height)
    {
        var momentOfInertiaXY = 1.0 / 12.0 * mass * (3 * (innerRadius * innerRadius + outerRadius * outerRadius) + height * height);
        return momentOfInertiaXY;
    }

    /// <summary>
    /// Calculate the surface area of the cylinder base
    /// </summary>
    /// <param name="radius"></param>
    /// <returns>m2</returns>
    public static double CalculateBaseSurfaceArea(double radius)
    {
        var baseSurfaceArea = Math.PI * radius * radius;
        return baseSurfaceArea * 2;
    }

    /// <summary>
    /// Calculate the lateral surface area of the cylinder
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="width"></param>
    /// <returns>The Surface area</returns>
    public static double CalculateLateralSurfaceArea(double radius, double width)
    {
        var lateralSurfaceArea = 2 * Math.PI * radius * width;
        return lateralSurfaceArea;
    }

    /// <summary>
    /// Calculate the total surface area of the cylinder
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static double CalculateTotalSurfaceArea(double radius, double height)
    {
        var totalSurfaceArea = 2 * Math.PI * radius * (radius + height);
        return totalSurfaceArea;
    }


    //public static double CalculateTurns(double outerDiameter, double innerDiameter, double thickness)
    //{
    //    if (outerDiameter <= 0 || innerDiameter <= 0 || thickness <= 0)
    //    {
    //        throw new ArgumentException("All dimensions must be positive.");
    //    }
    //    if (outerDiameter < innerDiameter)
    //    {
    //        throw new ArgumentException("Outer diameter must be greater than inner diameter.");
    //    }

    //    double coilWidth = (outerDiameter - innerDiameter) / 2;
    //    double coilCircumference = Math.PI * (outerDiameter + innerDiameter);
    //    double totalThickness = thickness * coilWidth;

    //    double turns = totalThickness / coilCircumference;

    //    double test = coilWidth / thickness;

    //    return turns;
    //}

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="outerDiameter">outer diameter (m)</param>
    ///// <param name="innerDiameter"></param>
    ///// <param name="thickness"></param>
    ///// <param name="width"></param>
    ///// <param name="density"></param>
    ///// <returns>The strip length in meters</returns>
    //public static double CalculateStripLength2(double outerDiameter, double innerDiameter, double thickness, double width, double density)
    //{
    //    var volume = ((outerDiameter / 2) * (outerDiameter / 2) * (Math.PI) - (innerDiameter / 2) * (innerDiameter / 2) * Math.PI) * width / 1000;
    //    var weightcalc = (volume * density / 1000);
    //    var length = (volume / (width * thickness));

    //    var mass = Math.Round(weightcalc, 2);
    //    return length;
    //}
}
