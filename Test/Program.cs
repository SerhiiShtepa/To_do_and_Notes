#nullable enable

class Program
{
    static void Main()
    {
        string? nullableString = null;

        if (nullableString != null)
        {
            int length = nullableString.Length; // No warning, inside null check
            Console.WriteLine($"Length: {length}");
        }

        int nonNullableLength = nullableString.Length; // Warning: Possible null reference

        Console.WriteLine($"Non-nullable Length: {nonNullableLength}");
    }
}
