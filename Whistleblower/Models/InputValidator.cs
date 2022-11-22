using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Whistleblower.Models
{
    /// <summary>
    /// This class contains helper methods for validating user input.
    /// </summary>
    public class InputValidator
    {
        /// <summary>
        /// Validates if the input provided by the user is a non-empty string.
        /// </summary>
        /// <param name="input">The input provided by the user.</param>
        /// <returns><see langword="true"/> if the input is a non-empty string, otherwise <see langword="false"/>.</returns>
        public static bool ValidateInputIsString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Validates if the input provided by the user is an int.
        /// </summary>
        /// <param name="input">The input provided by the user.</param>
        /// <returns><see langword="true"/> if the input is an int, otherwise <see langword="false"/>.</returns>
        public static bool ValidateInputIsInt(string input)
        {
            return int.TryParse(input, out int _);
        }

        /// <summary>
        /// Validates if the input provided by the user is an int within the range of <paramref name="minValue"/> and <paramref name="maxValue"/>.
        /// </summary>
        /// <param name="input">The input provided by the user.</param>
        /// <returns><see langword="true"/> if the input is an int within the given range, otherwise <see langword="false"/>.</returns>
        public static bool ValidateInputIsInt(string input, int minValue, int maxValue)
        {
            if (int.TryParse(input, out int result))
                if (result >= minValue && result <= maxValue)
                    return true;

            return false;
        }
    }
}
