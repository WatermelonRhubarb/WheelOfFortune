using System.Collections.Generic;

namespace WheelOfFortune
{
    /// <summary>
    /// Class representing validation errors for player inputs
    /// </summary>
    public class InvalidInputError
    {
        /// <summary>
        /// Enumeration for different types of validation errors
        /// </summary>
        public enum ErrorTypes
        {
            /// <summary>Input was an empty string or null</summary>
            EmptyInput,
            /// <summary>Input was a string when a char was expected</summary>
            ReceivedStringExpectedChar,
            /// <summary>Input was not 'y' or 'n' (not case sensitive)</summary>
            InvalidInputYOrN,
            /// <summary>Input was not '1' or '2'</summary>
            InvalidInput1Or2,
        }

    }
}
