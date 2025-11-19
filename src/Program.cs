using ConsoleLib;
using ConsoleLib.Factory;
using CSharpFeatures.Features;

if (args?.Length > 0)
{
    Console.WriteLine($"Argument passed: {args[0]}");

    var feature = GetFeature(args[0]);
    if (feature is not null)
    {
        Console.WriteLine($"---Executing feature: {feature.Name}---");
        feature.Run();
    }
    else
    {
        Console.WriteLine($"Invalid feature");
    }

    Console.WriteLine("\r\nPress any key to exit");
    Console.ReadKey(true);
}
else
{
    Console.Clear();

    IMenu menu = ConsoleMenuFactory.CreateMenu();
    menu.AddMenuFeature<ThreadPoolFeature>();
    menu.AddMenuFeature<LocalFunctions>();
    menu.AddMenuFeature<RefReturns>();
    menu.AddMenuFeature<WorkingWithSpans>();
    menu.AddMenuFeature<PatternMatchingFeature>();
    menu.Show();
}

BaseFeature? GetFeature(string featureType)
{
    BaseFeature? feature = featureType switch
    {
        "lf" => new LocalFunctions(),
        "rr" => new RefReturns(),
        "tp" => new ThreadPoolFeature(),
        "pm" => new PatternMatchingFeature(),
        _ => null,
    };
    return feature;
}

