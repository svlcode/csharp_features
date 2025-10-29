using ConsoleLib;
using ConsoleLib.Factory;
using CSharpFeatures.Features;
using CSharpFeatures.Features.WorkingWithSpans;


public class WorkingWithSpans : BaseFeature
{
    public override string Name => "Working with Spans";
    public override void Run()
    {
        IMenu menu = ConsoleMenuFactory.CreateMenu();
        menu.AddMenuFeature<MinimizeStringAllocations>();
        menu.Show();

    }
}
