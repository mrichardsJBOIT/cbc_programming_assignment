using System;
using System.Collections.Generic;

namespace ProgrammingAssignment.Convert
{
    /// <summary>
    /// Shrink hex string by replacing repeating characters with a custom encoding.
    /// </summary>
    public class ShortHex
    {
        public const string ZeroEndLine = ",";
        public const string FEndLine = "!";
        public const string RepeatLine = ":";
        public static readonly Dictionary<int, char> RepeatSymbol = new()
        {
            { 1, 'G' },
            { 2, 'H' },
            { 3, 'I' },
            { 4, 'J' },
            { 5, 'K' },
            { 6, 'L' },
            { 7, 'M' },
            { 8, 'N' },
            { 9, 'O' },
            { 10, 'P' },
            { 11, 'Q' },
            { 12, 'R' },
            { 13, 'S' },
            { 14, 'T' },
            { 15, 'U' },
            { 16, 'V' },
            { 17, 'W' },
            { 18, 'X' },
            { 19, 'Y' },
            { 20, 'g' }, // now step by 20
            { 40, 'h' },
            { 60, 'i' },
            { 80, 'j' },
            { 100, 'k' },
            { 120, 'l' },
            { 140, 'm' },
            { 160, 'n' },
            { 180, 'o' },
            { 200, 'p' },
            { 220, 'q' },
            { 240, 'r' },
            { 260, 's' },
            { 280, 't' },
            { 300, 'u' },
            { 320, 'v' },
            { 340, 'w' },
            { 360, 'x' },
            { 380, 'y' },
            { 400, 'z' },
        };

        /// <summary>
        /// Converts a single line of hex encoded data to its custom shortened form.
        /// Replace repeated hex characters with the code defined in RepeatSymbol above.
        /// Additionally hex lines ending in "0" should have all ending sequential "0" replaced with a single ",".
        /// Hex lines ending in "F" should have all ending sequential "F"s replaced with a single "!".
        /// </summary>
        /// <param name="hexData">Represents a hex coded row of image data.</param>
        /// <returns>A custom shortened hex encoded row of image data.</returns>
        public static string GetEncodedData(string hexData)
        {
            return EncodeHex(hexData);
        }

        internal static string EncodeHex(string hexData)
        {
            // TODO: implement repeated character replacement
            return hexData;
        }

        internal static string[] DeduplicateLines(string[] lines)
        {
            string[] shortened = lines;

            // TODO: implement deduplication
            string checker = lines[0];
            for (int i = 0; i < lines.Length-1; i++)
            {
           
                if (lines[i+1] == checker)
                {
                    shortened[i + 1] = RepeatLine;
                    continue;
                } else
                {
                    checker = lines[i+1];
                }
            }

            return shortened;
        }
    }
}
