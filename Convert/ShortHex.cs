using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            //TODO: Refactor to an inner class
            char c = ' ';
            var reducedCharsArrayTemplate = new[] { new { ch = c, repeats = 0 } };
            var reducedCharsList = reducedCharsArrayTemplate.ToList();

            // First attempt will use naive for loop
            //This is very ugly
            //TODO: REFACTOR...

            char checker = hexData[0];
            int repeated = 1;
            for (int i = 0; i <= hexData.Length - 1; i++)
            {
                if ((i < hexData.Length - 1) && (hexData[i + 1] == checker))
                {
                    repeated++;
                    continue;
                }
                else
                {
                    reducedCharsList.Add(new { ch = checker, repeats = repeated });
                    if (i < hexData.Length - 1)
                    {
                        checker = hexData[i + 1];
                    }
                    repeated = 1;
                }
            }
            StringBuilder sb = new StringBuilder("", reducedCharsList.Count());

            //TODO: Refactor into own function
            foreach (var item in reducedCharsList)
            {
                if (item.repeats == 0) //probably best to remove the first item from the list
                {
                    continue;
                }
                if (item.repeats > 1)
                {
                    RepeatSymbol.TryGetValue(item.repeats, out char sym);
                    sb.Append(sym);
                }

                sb.Append(item.ch);
            }

            //Hex lines ending in "0" or "F"
            //should have all ending sequential "0"s or "F"s
            //replaced with a single "," or "!" respectively.

            string encodedHex = sb.ToString();
            if (encodedHex.EndsWith("0"))
            {
      
                encodedHex = String.Concat(encodedHex.Substring(0, encodedHex.LastIndexOf("0")),
                                           ZeroEndLine);
            }
            if (encodedHex.EndsWith("F"))
            {

                encodedHex = String.Concat(encodedHex.Substring(0, encodedHex.LastIndexOf("F")),
                                           FEndLine);
            }
            return encodedHex;
        }

        internal static string[] DeduplicateLines(string[] lines)
        {
            string[] shortened = lines;

            // First attempt will use naive for loop
            // TODO: Refactor to use a map function  
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
