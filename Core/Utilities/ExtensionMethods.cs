using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Utilities;

public static class ExtensionMethods
{
    public static string SplitPascalCase(this string input)
    {
        var formattedPropertyName = Regex.Replace(input, "(\\B[A-Z])", " $1");

        return formattedPropertyName;        
    }
}
