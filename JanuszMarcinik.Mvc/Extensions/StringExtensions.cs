using System;

namespace JanuszMarcinik.Mvc
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrEmpty(this string text)
        {
            return !String.IsNullOrEmpty(text);
        }
    }
}