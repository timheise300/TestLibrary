using TestLibrary;

namespace TestLibraryTest
{
    [TestClass]
    public class PrintNumbersTest
    {
        [TestMethod]
        public void GetRangeStringsTest()
        {
            int count = 100;
            KeyValuePair<int, int> intPairs = new(5, 3);
            Dictionary<string, string> stringPairs = new()
            {
                { "Timothy", "Heise" }
            };

            List<string> rangeStrings = PrintNumbers.GetRangeStrings(count, intPairs, stringPairs);

            //Test of initially requested functionality
            Assert.AreEqual("Timothy Heise", rangeStrings[15]);
        }

        [TestMethod]
        public void GetRangeStringsCorrectCountTest()
        {
            int count = 100;
            KeyValuePair<int, int> intPairs = new(5, 3);
            Dictionary<string, string> stringPairs = new()
            {
                { "Timothy", "Heise" },
                { "Drizzt", "Do'Urden" },
                { "Artemis", "Entreri" }
            };

            List<string> rangeStrings = PrintNumbers.GetRangeStrings(count, intPairs, stringPairs);

            Assert.AreEqual(count * stringPairs.Count, rangeStrings.Count);
        }

        [TestMethod]
        public void GetRangeStringsAlternativeIntPairTest()
        {
            int count = 100; ;
            KeyValuePair<int, int> intPairs = new(6, 4);
            Dictionary<string, string> stringPairs = new()
            {
                { "Timothy", "Heise" }
            };

            List<string> rangeStrings = PrintNumbers.GetRangeStrings(count, intPairs, stringPairs);


            Assert.AreEqual("Timothy Heise", rangeStrings[12]);
        }

        [TestMethod]
        public void GetRangeStringsMultipleStringPairsTest() 
        {
            int count = 100;
            KeyValuePair<int, int> intPairs = new(5, 3);
            Dictionary<string, string> stringPairs = new()
            {
                { "Timothy", "Heise" },
                { "Artemis", "Entreri" }
            };

            List<string> rangeStrings = PrintNumbers.GetRangeStrings(count, intPairs, stringPairs);

            Assert.AreEqual("Timothy Heise", rangeStrings[15]);
            Assert.AreEqual("Artemis Entreri", rangeStrings[115]);
        }
    }
}