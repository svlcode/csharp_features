namespace CSharpFeatures.Features
{
    internal class IndicesAndRangesFeature : BaseFeature
    {
        public override string Name => "Indices and Ranges";

        public override void Run()
        {
            var indices = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var firstElement = indices[0];
            var lastElement = indices[^1];
            var firstThree = indices[..3]; // elements 0, 1, 2 (3 is exclusive)
            var lastThree = indices[^3..]; // last three elements
            var allElements = indices[..]; // all elements
            var allButFirst = indices[1..]; // all elements except the first one
            var subrangeExceptLast = indices[..^1]; // all elements except the last one
            var allButFirstAndLast = indices[1..^1]; // all elements except the first and the last one

            var subrangeExceptLastTwo = indices[..^2]; // all elements except the last two
            var subrange = indices[3..7]; // elements 3, 4, 5, 6 (7 is exclusive)


            Console.WriteLine($"Last three {lastThree}");

            Console.WriteLine(subrange);
        }
    }
}
