namespace CSharpFeatures.Features.WorkingWithSpans
{

    public record struct Point3D(double X, double Y, double Z)
    {
        public override string ToString() => $"({X}, {Y}, {Z})";

        public static Point3D Parse(string input)
        {
            try
            {
                var items = input.Replace("(", "").Replace(")", "").Split(",");

                return new Point3D(double.Parse(items[0]), double.Parse(items[1]), double.Parse(items[2]));
            }
            catch (Exception e)
            {
                throw new FormatException("Input in incorrect format", e);
            }
        }

        /// <summary>
        /// Parses a string representation of a 3D point into a new <see cref="Point3D"/> instance using a fast parsing
        /// algorithm with minimal heap allocations.
        /// </summary>
        /// <remarks>This method is optimized for performance and expects the input string to strictly
        /// follow the "(x, y, z)" format, with coordinates separated by commas. Whitespace and other formatting
        /// variations may cause parsing to fail.</remarks>
        /// <param name="input">The input string containing the coordinates of the point in the format "(x, y, z)". Each coordinate should
        /// be a valid double-precision number.</param>
        /// <returns>A <see cref="Point3D"/> object representing the coordinates specified in the input string.</returns>
        /// <exception cref="FormatException">Thrown when <paramref name="input"/> is not in the expected format or contains invalid coordinate values.</exception>
        public static Point3D ParseFast(string input)
        {
            try
            {
                ReadOnlySpan<char> chars = input;
                Span<double> coords = stackalloc double[] { 0.0, 0.0, 0.0 };
                Span<char> number = stackalloc char[chars.Length];

                number.Fill(' ');

                int count = 0;
                int pos = 0;

                foreach (char c in chars)
                {
                    if (c == '(')
                        continue;

                    if (c == ',' || c == ')')
                    {
                        coords[count++] = double.Parse(number);

                        pos = 0;

                        number.Fill(' ');

                        continue;
                    }

                    number[pos++] = c;
                }

                return new Point3D(coords[0], coords[1], coords[2]);
            }
            catch (Exception e)
            {
                throw new FormatException("Input in incorrect format", e);
            }
        }
    }
}
