namespace JobHunt.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static bool IsNotNullOrEmpty(this string str) => !string.IsNullOrEmpty(str);

        public static bool ContainsIgnoreCase(this string source, string toCheck) => source.ToLower().Contains(toCheck.ToLower());
    }
}
