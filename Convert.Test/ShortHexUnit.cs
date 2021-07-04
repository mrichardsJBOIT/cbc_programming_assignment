using ProgrammingAssignment.Convert;
using System.Text;
using Xunit;

namespace Image.Test
{
    public class ShortHexUnit
    {
        [Theory]
        [MemberData(nameof(GetHexes))]
        public void ShrinkHex(string hex, string resultShortHex)
        {           
            Assert.Equal(resultShortHex, ShortHex.EncodeHex(hex));
        }

        /// <summary>
        /// Set of data where hex repeating characters are replaced with an encoding.
        /// </summary>
        /// <returns>A pair of strings: input hex and shrunk expected result.</returns>
        public static TheoryData<string, string> GetHexes()
        {
            return new TheoryData<string, string>
            {
                { "800008", "8J08" },
                { "800004", "8J04" },
                { "800002", "8J02" },
                { "800001", "8J01" },
            };
        }

        [Theory]
        [MemberData(nameof(GetDuplicateLines))]
        public void DeduplicateLines(string[] fullLines, string[] deduplicatedLines)
        {
            Assert.Equal(deduplicatedLines, ShortHex.DeduplicateLines(fullLines));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TheoryData<string[], string[]> GetDuplicateLines()
        {
            string[] twoDuplicates = { "FFF11A", "FFF11A" };
            string[] twoDuplicatesExpectation = { "FFF11A", ":" };
            string[] noDuplicates = { "43A009", "1648DE" };
            string[] mutlipleDuplicates =           { "43A009", "1648DE", "1648DE", "1648DE", "1648DE", "FFF11A", "FFF11A", "FFF11A", "43A009", };
            string[] multipleDuplicatesExpectation = { "43A009","1648DE", ":"    , ":"     , ":"     , "FFF11A", ":"     , ":"     , "43A009", };

            return new TheoryData<string[], string[]>
            {
               
                { mutlipleDuplicates, multipleDuplicatesExpectation },
                { noDuplicates, noDuplicates },
                { twoDuplicates, twoDuplicatesExpectation },
            };
        }

        [Theory]
        [MemberData(nameof(GetDuplicateHexes))]
        public void MultipleDuplicateHex(string hex, string resultDuplicateHex)
        {
            Assert.Equal(resultDuplicateHex, ShortHex.EncodeHex(hex));
        }

        public static TheoryData<string, string> GetDuplicateHexes()
        {
            StringBuilder sbLarge = new StringBuilder("A", 405);
            for (int i = 0; i < 400; i++)
            {
                sbLarge.Append("0");
            }
            sbLarge.Append("B");

                return new TheoryData<string, string>
            {
                { "8000000000000000000008", "8g08" },
                { sbLarge.ToString(), "Az0B" },
                { "800HH004", "8H0HHH04" },
                { "555554444333221", "K5J4I3H21" },
                { "000000", "L," },
                { "0", "," },
                { "FFFFFF", "L!" },
                { "F", "!" },
            };
        }

    }
}
