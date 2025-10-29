using CSharpFeatures.Features;
using CSharpFeatures.Features.WorkingWithSpans;


public class WorkingWithSpans : BaseFeature
{
    public override string Name => "Working with Spans";
    public override void Run()
    {
        // Using the ParseFast method to create a Point3D from a string with minimal heap allocations
        var p = Point3D.ParseFast("(1.1, 2.2, 3.3)");
    }
}
