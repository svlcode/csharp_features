namespace CSharpFeatures.Features;

class RefReturns : BaseFeature
{
    public override string Name => "Ref returns";

    public override void Run()
    {
        int x = 1, y = 10;

        ref int k = ref x;

        k = 69;
        k.IncrementBy(5);

        var result = 15;
        int step = 5;

        ref readonly int temp = ref AppendDoubleReadOnlyValue(step, ref result);

        ref int z = ref OrMaybe(ref x, ref y);

        z = 100;

        Console.WriteLine($"x = {x}, y = {y}, z = {z}");

    }


    /// <summary>
    /// This method receives a readonlyRefValue and outputs its double as an readonly reference appended to an
    /// initial result
    /// </summary>
    /// <param name="readOnlyRefValue"></param>
    /// <param name="initialResult"></param>
    /// <returns></returns>
    ref readonly int AppendDoubleReadOnlyValue(in int readOnlyRefValue, ref int initialResult)
    {
        initialResult += 2 * readOnlyRefValue;

        return ref initialResult;
    }

    ref int OrMaybe(ref int x, ref int y)
    {
        x++;
        y++;
        return ref x;
    }
}

static class RefStructExtensions
{
    public static void IncrementBy(ref this int value, int increment)
    {
        value += increment;
    }
}