namespace TestLibray
{
    public static class PrintNumbers
    {
        /// <summary>
        /// Takes in a list of string pairs and a list of int pairs and returns a combined list based on 
        /// all string pairs replacing all divisible members with their related string pairs.
        /// </summary>
        /// <param name="count">Total amount of strings to return</param>
        /// <param name="intPairs">Dictionary of integer pairs for checking divisibility</param>
        /// <param name="stringPairs">Dictionary of string pairs for replacing with one or both strings depending on divisibility</param>
        /// <returns>List of integer strings with specified divisible members replaced by the specified string or string pairs</returns>
        public static List<string> GetRangeStrings(int count, KeyValuePair<int, int> intPair, Dictionary<string, string> stringPairs)
        {
            List<string> rangeStrings = [];

            foreach (KeyValuePair<string, string> stringPair in stringPairs)
            {
                GetRangeStringsRecursive(count, intPair, stringPair, rangeStrings, 0);
            }

            return rangeStrings;
        }

        //Recursive function to avoid nested loops
        private static List<string> GetRangeStringsRecursive(int count, KeyValuePair<int, int> intPair, KeyValuePair<string, string> stringPair, List<string> rangeStrings, int i)
        {
            if (i >= count)
            {
                return rangeStrings;
            }

            rangeStrings.Add(i switch
            {
                var x when (x % intPair.Key == 0 && x % intPair.Value == 0) => $"{stringPair.Key} {stringPair.Value}",
                var x when (x % intPair.Key == 0) => stringPair.Value,
                var x when (x % intPair.Value == 0) => stringPair.Key,
                _ => i.ToString()
            });

            return GetRangeStringsRecursive(count, intPair, stringPair, rangeStrings, i + 1);
        }
    }
}
