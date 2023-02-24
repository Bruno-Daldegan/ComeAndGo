using ComeAndGoCore;
using Xunit;

namespace ComeAndGo.Tests
{
    public class ComeAndGoTest
    {
        [Theory]
        [InlineData("DSF", 2, "FDS")]
        [InlineData("DSF", 3, "DSF")]
        [InlineData("BSF", 3, "BSF")]
        [InlineData("STRINGCOMSOBRAFOUR", 5, "ROSTRGNICOMBOSRAFU")]
        public void ShouldGenerateInvertedKeyByAmountBreaks(string key, int amountBreaks, string expected)
        {
            var output = Program.FactoryKeyByAmountBreaks(key, amountBreaks);

            Assert.Equal(expected, output);
        }
    }
}