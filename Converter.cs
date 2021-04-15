using System;

namespace DemoNumberToWords
{

    public enum Language
    {
        English = 0,
        French = 1
    }
    public class Converter
    {

        public static string ConvertNumberToWords(double pValue, Language pLanguage)
        {
            int  WordsSpliLeft  ;
            int WordsSplitRight  ;
            bool    WordsSplit = false;
            string  splitChar = "";
            string  RightW="";


            if (pValue.ToString().Contains(",")|| pValue.ToString().Contains("."))
            {
                WordsSplit = true;

                string[] Words = new string[2];
                Words = pValue.ToString().Split(',');
                WordsSpliLeft     = int.Parse(Words[0]);
                WordsSplitRight   = int.Parse(Words[1]);
                
                if (pLanguage == Language.French)
                {
                    splitChar = "  virgule  ";
                }
                else if (pLanguage == Language.English)
                {
                    splitChar = "  point  ";
                }



               
                
                if (WordsSplitRight < 0)
                    throw new NotSupportedException("negative numbers not supported");
                else if (pValue == 0)
                {
                    RightW = pLanguage == Language.English ? "zero" : "zéro";
                }

                else if (WordsSplitRight < 10)
                {
                    RightW = ConvertDigitToWords(int.Parse(WordsSplitRight.ToString()), pLanguage);
                }


                else if (WordsSplitRight < 20)
                    RightW = ConvertTeensToWords(int.Parse(WordsSplitRight.ToString()), pLanguage);
                else if (WordsSplitRight < 100)
                    RightW = ConvertHighTensToWords(int.Parse(WordsSplitRight.ToString()), pLanguage);
                else if (WordsSplitRight < 1000)
                    RightW = ConvertBigNumberToWords(int.Parse(WordsSplitRight.ToString()), 100, "hundred", pLanguage);
                else if (WordsSplitRight < 1000000)
                    RightW = ConvertBigNumberToWords(int.Parse(WordsSplitRight.ToString()), 1000, "thousand", pLanguage);
                else if (WordsSplitRight < 1000000000)
                    RightW = ConvertBigNumberToWords(int.Parse(WordsSplitRight.ToString()), 1000000, "million", pLanguage);
                else
                    throw new NotSupportedException("Number is too large!!!");

                if (pLanguage == Language.French)
                {
                    if (RightW.EndsWith("quatre-vingt"))
                    {
                        //another French exception
                        RightW += "s";
                    }
                }



                string LeftW;
                if (WordsSpliLeft < 0)
                    throw new NotSupportedException("negative numbers not supported");
                else if (WordsSpliLeft == 0)
                {
                    LeftW = pLanguage == Language.English ? "zero" : "zéro";
                }

                else if (pValue < 10)
                {
                    LeftW = ConvertDigitToWords(int.Parse(WordsSplitRight.ToString()), pLanguage);
                }


                else if (WordsSpliLeft < 20)
                    LeftW = ConvertTeensToWords(int.Parse(WordsSpliLeft.ToString()), pLanguage);
                else if (WordsSpliLeft < 100)
                    LeftW = ConvertHighTensToWords(int.Parse(WordsSpliLeft.ToString()), pLanguage);
                else if (WordsSpliLeft < 1000)
                    LeftW = ConvertBigNumberToWords(int.Parse(WordsSpliLeft.ToString()), 100, "hundred", pLanguage);
                else if (WordsSpliLeft < 1000000)
                    LeftW = ConvertBigNumberToWords(int.Parse(WordsSpliLeft.ToString()), 1000, "thousand", pLanguage);
                else if (WordsSpliLeft < 1000000000)
                    LeftW = ConvertBigNumberToWords(int.Parse(WordsSpliLeft.ToString()), 1000000, "million", pLanguage);
                else
                    throw new NotSupportedException("Number is too large!!!");

                if (pLanguage == Language.French)
                {
                    if (LeftW.EndsWith("quatre-vingt"))
                    {
                        //another French exception
                        LeftW += "s";
                    }
                }

                

                return LeftW + splitChar + RightW;

            }






           



            string strReturn;
            if (pValue < 0)
                throw new NotSupportedException("negative numbers not supported");
            else if (pValue == 0)
            {
                strReturn = pLanguage == Language.English ? "zero" : "zéro";
            }

            else if (pValue < 10)
            {
                strReturn = ConvertDigitToWords(int.Parse(pValue.ToString()), pLanguage)  ;
            }
               

            else if (pValue < 20)
                strReturn = ConvertTeensToWords(int.Parse(pValue.ToString()), pLanguage) ;
            else if (pValue < 100)
                strReturn = ConvertHighTensToWords(int.Parse(pValue.ToString()), pLanguage)  ;
            else if (pValue < 1000)
                strReturn = ConvertBigNumberToWords(int.Parse(pValue.ToString()), 100, "hundred", pLanguage)  ;
            else if (pValue < 1000000)
                strReturn = ConvertBigNumberToWords(int.Parse(pValue.ToString()), 1000, "thousand", pLanguage)  ;
            else if (pValue < 1000000000)
                strReturn = ConvertBigNumberToWords(int.Parse(pValue.ToString()), 1000000, "million", pLanguage) ;
            else
                throw new NotSupportedException("Number is too large!!!");

            if (pLanguage == Language.French)
            {
                if (strReturn.EndsWith("quatre-vingt"))
                {
                    //another French exception
                    strReturn += "s";
                }
            }






            return strReturn;
        }

        public static string ConvertDigitToWords(int pValue, Language pLanguage)
        {
            switch (pValue)
            {
                case 0: return "";
                case 1: return pLanguage == Language.English ? "one" : "un";
                case 2: return pLanguage == Language.English ? "two" : "deux";
                case 3: return pLanguage == Language.English ? "three" : "trois";
                case 4: return pLanguage == Language.English ? "four" : "quatre";
                case 5: return pLanguage == Language.English ? "five" : "cinq";
                case 6: return "six";
                case 7: return pLanguage == Language.English ? "seven" : "sept";
                case 8: return pLanguage == Language.English ? "eight" : "huit";
                case 9: return pLanguage == Language.English ? "nine" : "neuf";
                default:
                    throw new IndexOutOfRangeException($"{pValue} not a digit");
            }
        }

        //assumes a number between 10 & 19
        public static string ConvertTeensToWords(int pValue, Language pLanguage)
        {
            switch (pValue)
            {
                case 10: return pLanguage == Language.English ? "ten" : "dix";
                case 11: return pLanguage == Language.English ? "eleven" : "onze";
                case 12: return pLanguage == Language.English ? "twelve" : "douze";
                case 13: return pLanguage == Language.English ? "thirteen" : "treize";
                case 14: return pLanguage == Language.English ? "fourteen" : "quatorze";
                case 15: return pLanguage == Language.English ? "fifteen" : "quinze";
                case 16: return pLanguage == Language.English ? "sixteen" : "seize";
                case 17: return pLanguage == Language.English ? "seventeen" : "dix-sept";
                case 18: return pLanguage == Language.English ? "eighteen" : "dix-huit";
                case 19: return pLanguage == Language.English ? "nineteen" : "dix-neuf";
                default:
                    throw new IndexOutOfRangeException($"{pValue} not a teen");
            }
        }

        //assumes a number between 20 and 99
        public static string ConvertHighTensToWords(int pValue, Language pLanguage)
        {
            int tensDigit = (int)(Math.Floor((double)pValue / 10.0));

            string tensStr;
            switch (tensDigit)
            {
                case 2: tensStr = pLanguage == Language.English ? "twenty" : "vingt"; break;
                case 3: tensStr = pLanguage == Language.English ? "thirty" : "trente"; break;
                case 4: tensStr = pLanguage == Language.English ? "forty" : "quarante"; break;
                case 5: tensStr = pLanguage == Language.English ? "fifty" : "cinquante"; break;
                case 6: tensStr = pLanguage == Language.English ? "sixty" : "soixante"; break;
                case 7: tensStr = pLanguage == Language.English ? "seventy" : "soixante-dix"; break;
                case 8: tensStr = pLanguage == Language.English ? "eighty" : "quatre-vingt"; break;
                case 9: tensStr = pLanguage == Language.English ? "ninety" : "quatre-vingt-dix"; break;
                default:
                    throw new IndexOutOfRangeException($"{pValue} not in range 20-99");
            }

            if (pValue % 10 == 0) return tensStr;

            //French sometime has a prefix in front of 1
            string strPrefix = string.Empty;
            if (pLanguage == Language.French && (tensDigit < 8) && (pValue - tensDigit * 10 == 1))
                strPrefix = "-et";

            string onesStr;
            if (pLanguage == Language.French && (tensDigit == 7 || tensDigit == 9))
            {
                tensStr = ConvertHighTensToWords(10 * (tensDigit - 1), pLanguage);
                onesStr = ConvertTeensToWords(10 + pValue - tensDigit * 10, pLanguage);
            }
            else
                onesStr = ConvertDigitToWords(pValue - tensDigit * 10, pLanguage);

            return tensStr + strPrefix + "-" + onesStr;
        }

        // Use this to convert any integer bigger than 99
        public static string ConvertBigNumberToWords(int pValue, int baseNum, string baseNumStr, Language pLanguage)
        {
            // special case: use commas to separate portions of the number, unless we are in the hundreds
            string separator;
            if (pLanguage == Language.French)
                separator = " ";
            else
                separator= (baseNumStr != "hundred") ? ", " : " ";

            // Strategy: translate the first portion of the number, then recursively translate the remaining sections.
            // Step 1: strip off first portion, and convert it to string:
            int bigPart = (int)(Math.Floor((double)pValue / baseNum));
            string bigPartStr;
            if (pLanguage == Language.French)
            {
                string baseNumStrFrench;
                switch (baseNumStr)
                {
                    case "hundred":
                        baseNumStrFrench = "cent";
                        break;
                    case "thousand":
                        baseNumStrFrench = "mille";
                        break;
                    case "million":
                        baseNumStrFrench = "million";
                        break;
                    case "billion":
                        baseNumStrFrench = "milliard";
                        break;
                    default:
                        baseNumStrFrench = "????";
                        break;
                }
                if (bigPart == 1 && pValue < 1000000)
                    bigPartStr = baseNumStrFrench;
                else
                    bigPartStr = ConvertNumberToWords(bigPart, pLanguage) + " " + baseNumStrFrench;
            }
            else
                bigPartStr = ConvertNumberToWords(bigPart, pLanguage) + " " + baseNumStr;

            // Step 2: check to see whether we're done:
            if (pValue % baseNum == 0)
            {
                if (pLanguage == Language.French)
                {
                    if (bigPart > 1)
                    {
                        //in French, a s is required to cent/mille/million/milliard if there is a value in front but nothing after
                        return bigPartStr + "s";
                    }
                    else
                        return bigPartStr;
                }
                else
                    return bigPartStr;
            }

            // Step 3: concatenate 1st part of string with recursively generated remainder:
            int restOfNumber = pValue - bigPart * baseNum;
            return bigPartStr + separator + ConvertNumberToWords(restOfNumber, pLanguage);
        }

    }

}
