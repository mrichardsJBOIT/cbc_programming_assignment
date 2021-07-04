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
            Console.WriteLine(hexData);

            //var v = CountDuplicatedCharacters(hexData.ToCharArray());


            // TODO: implement repeated character replacement
            string distinctHex = new string(hexData.ToArray().Distinct().ToArray());
            Console.WriteLine(distinctHex);

            //Stack<char> outHex = new();

            //for (int i = distinctHex.Length - 1; i > 0 ; i--)
            //{
            //    int key =0; //will 0 be present in dictionary?

            //    if(Int32.TryParse(distinctHex, out key))
            //    {
            //        char sym;
            //        if (RepeatSymbol.TryGetValue(key, out sym))
            //        {
            //            // Found the hex string in the dictionary
            //            // We'll assume that the last charactar in the hex is the repeated chaaracter
            //            // Un clear what the translation rules are.
            //            // The test data indicates that:
            //            // 1. The repeated character appears in the translated hex
            //            // 2. The symbol found for the non repeating and existing characters
            //            //    appears between the first and last 'reduced' characters. 
            //            //    Assume it's before the last character so it indicates which one is repeating
            //            //string reverseTranslatedHex = 
            //            //    (string)distinctHex.Insert(distinctHex.Length - 1, sym.ToString()).Reverse();


            //            string insertString = sym.ToString();
            //            string transHex = distinctHex.Insert(distinctHex.Length - 1, insertString);
            //            char[] tempArr = transHex.ToCharArray();
            //            Array.Reverse(tempArr);
            //            string reverseTranslatedHex = new string(tempArr);

            //            // reverse it so we can push it on to the stack
            //            foreach (var item in reverseTranslatedHex)
            //            {
            //                outHex.Push(item);
            //            }
            //            // At this point we've considered the whole string, based on the assumed logic
            //            // As such we'll break out of the for loop
            //            break;
            //        }
            //        else
            //        {
            //            string v = distinctHex.Substring(i, 1);
            //            char toRemove = v.ToCharArray()[0];
            //            outHex.Push(toRemove);
            //            distinctHex = distinctHex.Remove(i, 1);
            //        }
            //    } 
            //    else
            //    {
            //        string v = distinctHex.Substring(i, 1);
            //        char toRemove = v.ToCharArray()[0];
            //        outHex.Push(toRemove);
            //        distinctHex = distinctHex.Remove(i, 1);

            //    }
            //}


            //return String.Join("",outHex);
            return CountDuplicatedCharacters(hexData.ToCharArray()); 
        }

        internal static string[] DeduplicateLines(string[] lines)
        {
            string[] shortened = lines;

            // First attempt will use niave for loop
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

        internal static string CountDuplicatedCharacters(char[] characters)
        {
            char c = ' ';
            var reducedCharsArrayTemplate =  new[] { new { ch = c, repeats = 0 } };
            var reducedCharsList = reducedCharsArrayTemplate.ToList();

            // First attempt will use naive for loop
          
            char checker = characters[0];
            int repeated = 1;
            for (int i = 0; i <= characters.Length - 1; i++)
            {
                if ((i < characters.Length -1 ) && (characters[i + 1] == checker))
                {
                    repeated++;
                    continue;
                }
                else
                {                    
                    reducedCharsList.Add(new { ch = checker, repeats = repeated });
                    if (i < characters.Length - 1) {
                        checker = characters[i + 1];
                    }              
                    repeated = 1;
                }
            }
            StringBuilder sb = new StringBuilder("", reducedCharsList.Count());

            foreach (var item in reducedCharsList)
            {
                if (item.repeats == 0) //probably best to remove the first item from the list
                {
                    continue;
                }
                if (item.repeats>1)
                {
                    RepeatSymbol.TryGetValue(item.repeats, out char sym);
                    sb.Append(sym.ToString());
                }

                sb.Append(item.ch);                
            }

            return sb.ToString();
        }
    }
}
