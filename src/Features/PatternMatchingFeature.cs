namespace CSharpFeatures.Features;

public class PatternMatchingFeature : BaseFeature
{
    public PatternMatchingFeature()
    {
    }

    public override string Name => "Pattern Matching";

    public override void Run()
    {
        object obj = new PhoneNumber { Code = 1, Number = 1234567890 };
        if (obj is PhoneNumber { Code: 1 } phoneNumber)
        {
            Console.WriteLine($"Phone number with code 1: {phoneNumber.Number}");

            var origin = phoneNumber switch
            {
                { Number: 112 } => "Emergency",
                { Number: 911 } => "USAEmergency",
                { Code: 1 } => "USA",
                { Code: 44 } => "UK",
                { } => "Unknown", // this matches any PhoneNumber
                _ => "missing" // this matches null
            };

        }

        var contact = new Contact
        {
            Name = "John Doe",
            PhoneNumber = new PhoneNumber { Code = 1, Number = 1234567890 }
        };
        if (contact is { PhoneNumber: { Code: 1 } })
        {
            Console.WriteLine($"{contact.Name} is from USA.");
        }


        var error = contact switch
        {
            null => "Contact is null",
            { PhoneNumber: null } => "Missing phone number",
            { PhoneNumber: { Number: 0 } } => "actual number is missing",
            { PhoneNumber: { Code: var code } } when code == 0 => "missing country code",
            { PhoneNumber: { Code: var code } } when code < 0 => "invalid country code",
            { PhoneNumber: { Code: var code, Number: var number } } => $"Contact number is +{code} {number}",
        };

        var shape = GetRandomShape();


        // this example shows more advanced pattern matching with positional and property patterns
        // this is possible due to the Deconstruct methods defined in the shape records
        string shapeType = shape switch
        {
            Circle((0, 0), var radius) => $"Circle at origin with radius {radius}",
            Rectangle(_, var width, var height) when width == height => $"Square with side {width}",
            Rectangle((var x, var y), var width, var height) => $"Rectangle at ({x}, {y}) with width {width} and height {height}",
            Triangle { Base: var b, Height: var h } when b == h => $"Equilateral Triangle with side {b}",
            Triangle(var @base, var height) => $"Triangle with base {@base} and height {height}",
            null => "No shape",
            _ => "Unknown"
        };

        Console.WriteLine($"Shape type is {shapeType}");
    }


    private Shape? GetRandomShape()
    {
        var rand = new Random();

        return rand.Next(3) switch
        {
            0 => new Circle { Origin = (0, 0), Radius = 5 },
            1 => new Rectangle { Origin = (1, 1), Width = 4, Height = 6 },
            2 => new Triangle(Base: 3, Height: 4),
            _ => null
        };
    }


    public class Contact
    {
        public string Name { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
    }

    public class PhoneNumber
    {
        public int Code { get; set; }

        public int Number { get; set; }
    }
}