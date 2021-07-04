using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class StringExtension
    {
        public static Stream ToStream(this string input, Encoding enc = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new System.ArgumentException($"'{nameof(input)}' cannot be null or empty", nameof(input));
            }

            enc ??= Encoding.UTF8;

            return new MemoryStream(enc.GetBytes(input));
        }
    }
}
