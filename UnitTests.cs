using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoNumberToWords
{
    [TestClass]
    public class UnitTests
    {

        [TestMethod]
        public void TestLotsOfNumbers()
        {
            int i = 0;
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 17, 19, 21, 32, 54, 76, 98,
                                100, 101, 211, 825, 999, 1100, 5101, 23211, 785825,
                                1000000, 2010203, 20102030, 34567890, 999999999, (int)2e9+3 };
            string[] expectedResult = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
                                        "ten", "eleven", "twelve", "thirteen", "seventeen", "nineteen",
                                        "twenty-one", "thirty-two", "fifty-four", "seventy-six", "ninety-eight",
                                        "one hundred", "one hundred one", "two hundred eleven", "eight hundred twenty-five",
                                        "nine hundred ninety-nine", "one thousand, one hundred", "five thousand, one hundred one",
                                        "twenty-three thousand, two hundred eleven",
                                        "seven hundred eighty-five thousand, eight hundred twenty-five",
                                        "one million", "two million, ten thousand, two hundred three",
                                        "twenty million, one hundred two thousand, thirty",
                                        "thirty-four million, five hundred sixty-seven thousand, eight hundred ninety",
                                        "nine hundred ninety-nine million, nine hundred ninety-nine thousand, nine hundred ninety-nine",
                                        "two billion, three"};
            string[] expectedResultFrench = { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf",
                                        "dix", "onze", "douze", "treize", "dix-sept", "dix-neuf",
                                        "vingt-et-un", "trente-deux", "cinquante-quatre", "soixante-seize", "quatre-vingt-dix-huit",
                                        "cent", "cent un", "deux cent onze", "huit cent vingt-cinq",
                                        "neuf cent quatre-vingt-dix-neuf", "mille cent", "cinq mille cent un",
                                        "vingt-trois mille deux cent onze",
                                        "sept cent quatre-vingt-cinq mille huit cent vingt-cinq",
                                        "un million", "deux million dix mille deux cent trois",
                                        "vingt million cent deux mille trente",
                                        "trente-quatre million cinq cent soixante-sept mille huit cent quatre-vingt-dix",
                                        "neuf cent quatre-vingt-dix-neuf million neuf cent quatre-vingt-dix-neuf mille neuf cent quatre-vingt-dix-neuf",
                                        "deux milliard trois"};
            foreach (int n in numbers)
            {
                string sEnglish = Converter.ConvertNumberToWords(n, Language.English);
                Assert.AreEqual(expectedResult[i], sEnglish);
                string sFrench = Converter.ConvertNumberToWords(n, Language.French);
                Assert.AreEqual(expectedResultFrench[i], sFrench);
                i++;
            }
        }

        [TestMethod]
        public void TestDigits()
        {
            int i = 0;
            int[] digits = Enumerable.Range(0, 9).ToArray();
            string[] expectedResult = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] expectedResultFrench = { "", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf" };
            foreach (int d in digits)
            {
                string sEnglish = Converter.ConvertDigitToWords(d, Language.English);
                Assert.AreEqual(expectedResult[i], sEnglish);
                string sFrench = Converter.ConvertDigitToWords(d, Language.French);
                Assert.AreEqual(expectedResultFrench[i], sFrench);
                i++;
            }
        }

        [TestMethod]
        public void TestTeens()
        {
            int i = 0;
            int[] teens = Enumerable.Range(10, 9).ToArray();
            string[] expectedResult = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] expectedResultFrench = { "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf" };
            foreach (int n in teens)
            {
                string sEnglish = Converter.ConvertTeensToWords(n, Language.English);
                Assert.AreEqual(expectedResult[i], sEnglish);
                string sFrench = Converter.ConvertTeensToWords(n, Language.French);
                Assert.AreEqual(expectedResultFrench[i], sFrench);
                i++;
            }
        }

        [TestMethod]
        public void TestHighTens()
        {
            int i = 0;
            int[] tens = { 21, 22, 32, 54, 71, 76, 81, 91, 98 };
            string[] expectedResult = { "twenty-one", "twenty-two", "thirty-two", "fifty-four", "seventy-one", "seventy-six", "eighty-one", "ninety-one", "ninety-eight" };
            string[] expectedResultFrench = { "vingt-et-un", "vingt-deux", "trente-deux", "cinquante-quatre", "soixante-et-onze", "soixante-seize", "quatre-vingt-un", "quatre-vingt-onze", "quatre-vingt-dix-huit" };
            foreach (int n in tens)
            {
                string sEnglish = Converter.ConvertHighTensToWords(n, Language.English);
                Assert.AreEqual(expectedResult[i], sEnglish);
                string sFrench = Converter.ConvertHighTensToWords(n, Language.French);
                Assert.AreEqual(expectedResultFrench[i], sFrench);
                i++;
            }
        }

        [TestMethod]
        public void TestHundreds()
        {
            int i = 0;
            int[] values = { 100, 121, 122, 132, 154, 171, 176, 181, 191, 198, 200, 201, 311 };
            string[] expectedResult = { "one hundred", "one hundred twenty-one", "one hundred twenty-two", "one hundred thirty-two", "one hundred fifty-four", "one hundred seventy-one", "one hundred seventy-six", "one hundred eighty-one", "one hundred ninety-one", "one hundred ninety-eight", "two hundred", "two hundred one", "three hundred eleven" };
            string[] expectedResultFrench = { "cent", "cent vingt-et-un", "cent vingt-deux", "cent trente-deux", "cent cinquante-quatre", "cent soixante-et-onze", "cent soixante-seize", "cent quatre-vingt-un", "cent quatre-vingt-onze", "cent quatre-vingt-dix-huit", "deux cents", "deux cent un", "trois cent onze" };
            foreach (int v in values)
            {
                string sEnglish = Converter.ConvertBigNumberToWords(v, (int)1e2, "hundred", Language.English);
                Assert.AreEqual(expectedResult[i], sEnglish);
                string sFrench = Converter.ConvertBigNumberToWords(v, (int)1e2, "hundred", Language.French);
                Assert.AreEqual(expectedResultFrench[i], sFrench);
                i++;
            }
        }

        [TestMethod]
        public void TestOther()
        {
            int i = 0;
            int[] values = {80, 81,300, 301, 1080,1082 };
            string[] expectedResult = { "eighty", "eighty-one", "three hundred", "three hundred one", "one thousand, eighty", "one thousand, eighty-two" };
            string[] expectedResultFrench = { "quatre-vingts", "quatre-vingt-un", "trois cents", "trois cent un", "mille quatre-vingts", "mille quatre-vingt-deux"};
            foreach (int v in values)
            {
                string sEnglish = Converter.ConvertNumberToWords(v, Language.English);
                Assert.AreEqual(expectedResult[i], sEnglish);
                string sFrench = Converter.ConvertNumberToWords(v, Language.French);
                Assert.AreEqual(expectedResultFrench[i], sFrench);
                i++;
            }
        }

    }
}
