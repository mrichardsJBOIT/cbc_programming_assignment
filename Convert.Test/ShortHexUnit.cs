using ProgrammingAssignment.Convert;
using Xunit;
using Xunit.Abstractions;

namespace Image.Test
{
    public class ShortHexUnit
    {
        ITestOutputHelper _testOutputHelper;
        [Theory]
        [MemberData(nameof(GetHexes))]
        public void ShrinkHex(string hex, string resultShortHex)
        {
         //   _testOutputHelper.WriteLine("hex" + hex + " resultShortHex" + resultShortHex);
           
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

    }
}
