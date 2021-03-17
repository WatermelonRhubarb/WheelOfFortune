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

        static Dictionary<ErrorTypes, string> ErrorMessages = new Dictionary<ErrorTypes, string>()
        {
            {ErrorTypes.EmptyInput, "Invalid input: input cannot be blank - please enter a valid input." },
            {ErrorTypes.ReceivedStringExpectedChar, "Invalid input: input should be a single letter - please enter a valid input." },
            {ErrorTypes.InvalidInputYOrN, "Invalid input: input should be 'y' or 'n' - please enter a valid input." },
            {ErrorTypes.InvalidInput1Or2, "Invalid input: input should be '1' or '2' - please enter a valid input." }
        };

    }
}
