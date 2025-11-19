
abstract record Shape
{
    public abstract double GetArea();
}

record Triangle(double Base, double Height) : Shape
{
    public override double GetArea() => 0.5 * Base * Height;
}

record Rectangle : Shape
{
    public required Point Origin { get; init; }
    public required double Width { get; init; }
    public required double Height { get; init; }

    public void Deconstruct(out Point origin, out double width, out double height)
    {
        origin = Origin;
        width = Width;
        height = Height;
    }

    public override double GetArea() => Width * Height;
}

record Circle : Shape
{
    public required Point Origin { get; init; }
    public required double Radius { get; init; }

    public void Deconstruct(out Point origin, out double radius)
    {
        origin = Origin;
        radius = Radius;
    }
    public override double GetArea() => Math.PI * Radius * Radius;
}

record Point(double X, double Y)
{
    public static implicit operator Point((double X, double Y) tuple) => new Point(tuple.X, tuple.Y);
}