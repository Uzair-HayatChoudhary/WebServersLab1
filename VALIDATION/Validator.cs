using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Lab1_ASPNetConnectedMode.VALIDATION
{
    public static class Validator
    {
        public static bool idValidId(string input)
        {
            if (!(Regex.IsMatch(input, "^d{4}$")))
            {
                return false;
            }
            return true;
        }

        public static bool idValidId(string input, int size)
        {
            if (!(Regex.IsMatch(input, "^d{" + size + "}$")))
            {
                return false;
            }
            return true;
        }

        public static bool isValidName(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for(int i= 0; i < input.Length; i++)
            {
                if (!(char.IsLetter(input[i])) && !(char.IsWhiteSpace(input[i])))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool isValidJob(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!(char.IsLetter(input[i])))
                {
                    return false;
                }
            }

            return true;
        }

    }
}