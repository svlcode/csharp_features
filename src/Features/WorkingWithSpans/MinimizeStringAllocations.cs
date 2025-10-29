namespace CSharpFeatures.Features.WorkingWithSpans
{
    internal class MinimizeStringAllocations : BaseFeature
    {
        public override string Name => "Minimize string allocations";
        public override void Run()
        {
            // Using the ParseFast method to create a Point3D from a string with minimal heap allocations
            var p = Point3D.ParseFast("(1.1, 2.2, 3.3)");
        }
    }
}
