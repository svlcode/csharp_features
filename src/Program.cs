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
    Console.Clear();

    IMenu menu = ConsoleMenuFactory.CreateMenu();
    menu.AddMenuFeature<ThreadPoolFeature>();
    menu.AddMenuFeature<LocalFunctions>();
    menu.AddMenuFeature<SwitchPatterns>();
    menu.AddMenuFeature<RefReturns>();
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

