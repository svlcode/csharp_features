using ConsoleLib;
using CSharpFeatures.Features;

public static class Extensions
{
    public static void AddMenuFeature<T>(this IMenu menu) where T : BaseFeature, new()
    {
        var feature = new T();
        menu.AddMenuItem(feature.Name, () => feature.Run());
    }
}
