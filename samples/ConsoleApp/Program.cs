﻿using Jpc.Physics;

Console.WriteLine("Hello, World!");

const double _innerDiameter = 650;
const double _outerDiameter = 1200;
const double _thickness = 1;
const double _width = 1000;
const double _weight = 6500;
const double _density = 7.85;
const double _stripLength = 799.14263125690377;

var lengthFromDiameter = Cylinder.CalculateStripLengthFromDiameter(_outerDiameter, _innerDiameter, _thickness);

var lengthFromWeight = Cylinder.CalculateStripLengthFromWeight(_weight, _width, _thickness, _density);

var volumeCm3 = Cylinder.CalculateVolumeFromRadius(_outerDiameter / 2, _innerDiameter / 2, _width);

var lengthFromVolume = Cylinder.CalculateStripLengthFromVolume(volumeCm3, _thickness, _width);

var turnsFromDiameter = Cylinder.CalculateNumberOfTurns(_outerDiameter, _innerDiameter, _thickness);

var outerDiameterFromStrip = Cylinder.CalculateOuterDiameterFromStrip(_stripLength, _innerDiameter, _thickness);

var sheetWeight = Cylinder.CalculateWeightFromStrip(1, 1000, 1, 7.870);

Console.ReadLine();
