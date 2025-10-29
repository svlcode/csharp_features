
abstract class Shape
{
    public abstract double GetArea();
}

class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }
    public override double GetArea() => 0.5 * Base * Height;
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override double GetArea() => Width * Height;
}

class Circle : Shape
{
    public double Radius { get; set; }
    public override double GetArea() => Math.PI * Radius * Radius;
}