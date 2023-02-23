namespace ComeAndGoCore
{
    public class Program
    {
        public static void Main()
        {
            var str = "STRINGCOMSOBRAFOUR";

            var output = FactoryKeyByAmountBreaks(str, 5);

            Console.WriteLine($"O resultado de {str} eh: {output}");
        }

        public static string FactoryKeyByAmountBreaks(string key, int amountBreaks)
        {
            var rest = key.Length % amountBreaks;

            return rest == 0 ?
                FactoryKeyWithoutLeftovers(key, amountBreaks) :
                FactoryKeyWithLeftovers(key, amountBreaks, rest);
        }

        private static string FactoryKeyWithoutLeftovers(string key, int amountBreaks)
        {
            var solution = new List<string>();

            var initPosition = 0;

            var keySize = key.Length;

            var blockSize = keySize / amountBreaks;

            while (initPosition < keySize)
            {
                var sub = key.Substring(initPosition, blockSize);

                if (solution.Count == 0 || solution.Count % 2 == 0)
                {
                    solution.Add(sub);
                }
                else
                {
                    string inverter = new(sub.Reverse().ToArray());

                    solution.Add(inverter);
                }

                initPosition += blockSize;
            }

            return string.Join("", solution);
        }

        private static string FactoryKeyWithLeftovers(string key, int amountBreaks, int rest)
        {
            var keyWithoutLeftovers = key[..^rest];

            var firstOutput = FactoryKeyWithoutLeftovers(keyWithoutLeftovers, amountBreaks);

            var leftoverKeyArray = key.Replace(keyWithoutLeftovers, "").ToArray();

            var isInitInsert = true;

            foreach (var letra in leftoverKeyArray)
            {
                firstOutput = isInitInsert ?
                            string.Concat(letra, firstOutput) :
                            string.Concat(firstOutput, letra);

                isInitInsert = !isInitInsert;
            }

            return firstOutput;
        }
    }
}