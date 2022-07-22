namespace CodingProblems.MathProblems;

// 478. Generate Random Point in a Circle
// Given the radius and the position of the center of a circle, implement the function randPoint which generates a uniform random point inside the circle.
// Implement the Solution class:
// Solution(double radius, double x_center, double y_center) initializes the object with the radius of the circle radius and the position of the center (x_center, y_center).
// randPoint() returns a random point inside the circle. A point on the circumference of the circle is considered to be in the circle. The answer is returned as an array [x, y].
// https://leetcode.com/problems/generate-random-point-in-a-circle/

public class RandomPointInCircleGenerator
{
    private readonly Random _random = new();
    private readonly double _radius;
    private readonly double _centerX;
    private readonly double _centerY;
    private readonly double _minX;
    private readonly double _maxX;
    private readonly double _minY;
    private readonly double _maxY;
    
    public RandomPointInCircleGenerator(double radius, double centerX, double centerY)
    {
        _radius = radius;
        _centerX = centerX;
        _centerY = centerY;
        
        _minX = _centerX - _radius;
        _maxX = _centerX + _radius;
        _minY = _centerY - _radius;
        _maxY = _centerY + _radius;
    }
    
    // A very simple approach - just generate a point in the rect and return it if it's in the circle
    // Other ways to do it, like via polar coordinates, are very complicated
    public double[] RandPoint()
    {
        while (true)
        {
            double x = generateRandomCoord(_minX, _maxX);
            double y = generateRandomCoord(_minY, _maxY);
            
            if (isInCircle(x, y))
                return new []{x, y};
        }
    }
    
    private bool isInCircle(double x, double y) =>
        (x - _centerX) * (x - _centerX) + (y - _centerY) * (y - _centerY) < _radius * _radius;

    private double generateRandomCoord(double min, double max) =>
        _random.NextDouble() * (max - min) + min;
}
