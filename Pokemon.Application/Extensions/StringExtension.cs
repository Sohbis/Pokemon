using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrZero(this string? str) { 
        if (string.IsNullOrEmpty(str) || str == "0")
            {
                return true;
            }
            return false;

        }
    }
}
