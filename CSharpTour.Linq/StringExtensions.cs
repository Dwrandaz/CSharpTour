using System.Text.RegularExpressions;

namespace CSharpTour.Linq
{
    public static class StringExtensions
    {
        private static Regex _regex = new Regex(@"^[^@]+@[^\.]+\.[a-z]+$", RegexOptions.IgnoreCase);

        // Notice the `this` keyword and the class is `static`
        public static bool IsEmail(this string text)
        {
            return _regex.IsMatch(text);
        }
    }
}
