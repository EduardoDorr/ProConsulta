using System.Text.RegularExpressions;

namespace ProConsulta.Extensions;

public static class StringExtensions
{
    public static string RemoveMask(this string inputValue)
    {
        if (string.IsNullOrWhiteSpace(inputValue))
            return inputValue;

        var pattern = @"[-\.\(\)\s]";

        var result = Regex.Replace(inputValue, pattern, string.Empty);

        return result;
    }
}