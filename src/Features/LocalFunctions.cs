namespace Features;

class LocalFunctions : BaseFeature
{
    public override string Name => "Local functions";

    public override void Run()
    {
        var fib = Fibonacci(4);
        Console.WriteLine(fib);
    }

    int Fibonacci(int x)
    {
        if (x < 0) throw new ArgumentException("Less negativity please!", nameof(x));
        return Fib(x).current;

        (int current, int previous) Fib(int i)
        {
            if (i == 0) return (1, 0);
            var (p, pp) = Fib(i - 1);
            return (p + pp, p);
        }
    }
}

