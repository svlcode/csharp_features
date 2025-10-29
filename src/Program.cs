using ConsoleLib;
using ConsoleLib.Factory;
using Features;

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
    // var features = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(BaseFeature))).ToList();
    // Activator.CreateInstance(features[0]);

    Console.Clear();

    IMenu menu = ConsoleMenuFactory.CreateMenu();
    menu.AddMenuItem("Local functions", () =>
    {
        var feature = new LocalFunctions();
        feature.Run();
    });
    menu.AddMenuItem("Switch patterns", () =>
    {
        var feature = new SwitchPatterns();
        feature.Run();
    });
    menu.AddMenuItem("Ref returns", () =>
    {
        var feature = new RefReturns();
        feature.Run();
    });
    menu.Show();
}

BaseFeature? GetFeature(string featureType)
{
    BaseFeature? feature = featureType switch
    {
        "lf" => new LocalFunctions(),
        "sp" => new SwitchPatterns(),
        "rr" => new RefReturns(),
        "tp" => new ThreadPoolFeature(),
        _ => null,
    };
    return feature;
}

