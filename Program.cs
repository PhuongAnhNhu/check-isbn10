using System;

namespace inbs10
{
    class Program
    {
        static void Main(string[] args)
        {

            // string code1 = "3-499-13599-X"; // Prüfziffer richtig
            // string code2 = "3-44619313-8";   // Prüfziffer richtig
            // string code3 = "0-7475-5100-6";  // Prüfziffer richtig
            // string code4 = "1-57231-4222";  // Prüfziffer richtig
            string code5 = "3 49913 599 X"; // Prüfziffer richtig
            // string code6 = "1234-56789-0";

            Console.WriteLine(ValidateIsbn10(code5));

        }

        static bool ValidateIsbn10(string code)
        {

            string normalizedCode = code.Replace("-", "").Replace(" ", "");
            if (normalizedCode.Length != 10)
            {
                return false;
            }
            char[] codeArray = normalizedCode.ToCharArray();

            int result = 0;

            for (int i = 0; i < 9; i++)
            {
                result += (codeArray[i] - '0')*(i+1);
            }

            int z10 = result%11;

            int checkNumber = 0;

            if (codeArray[9] == 'X') {
                checkNumber = 10;
            } else {
                checkNumber = codeArray[9] - '0';
            }

            return z10 == checkNumber;
        }
    }
}
