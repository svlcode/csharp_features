class SwitchPatterns : BaseFeature
{
  public override string Name => "Switch patterns";

  public override void Run()
  {
    var shape = GetShape("t");
    PrintShape(shape);
  }

  Shape? GetShape(string type)
  {
    Shape? shape;
    switch (type)
    {
      case "t":
        shape = new Triangle();
        break;
      case "c":
        shape = new Circle();
        break;
      case "r":
        shape = new Rectangle();
        break;
      default:
        shape = null;
        break;
    }
    return shape;
  }

  void PrintShape(Shape? shape)
  {
    switch (shape)
    {
      case Rectangle square when square.Width == square.Height:
        Console.WriteLine($"Square with Width = {square.Width} and Area: {square.GetArea()}");
        break;
      case Rectangle r:
        r.Width = 7;
        r.Height = 3;
        Console.WriteLine($"Rectangle with Width = {r.Width} and Height {r.Height} and Area: {r.GetArea()}");
        break;
      case Circle c:
        c.Radius = 4;
        Console.WriteLine($"Circle with radius {c.Radius} and area: {c.GetArea()}");
        break;
      case null:
        throw new ArgumentNullException(nameof(shape));
      default:
        Console.WriteLine("This is an unknown shape");
        break;
    }
  }
}
