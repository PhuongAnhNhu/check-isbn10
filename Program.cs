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
            //string code5 = "3 49913 599 X"; // Prüfziffer richtig
            // string code6 = "1234-56789-0";


            PrintIsbn10Result();

        }

        static void PrintIsbn10Result()

        {

            Console.WriteLine("Geben Sie isbn code ein:");
            string code = Console.ReadLine();
            int lengthCode = CheckIsbn(code);
            if (lengthCode == 10)
            {
                Console.WriteLine("Sie haben isbn10 eingegeben");
                Console.WriteLine(ValidateIsbn10(code) ? "Prüfziffer richtig" : "Prüfziffer falsch");
            }
            else if (lengthCode == 13)
            {
                Console.WriteLine("Sie haben isbn13 eingegeben");
                Console.WriteLine(ValidateIsbn13(code) ? "Prüfziffer richtig" : "Prüfziffer falsch");
            }
            else
            {
                Console.WriteLine("Prüfziffer falsch");
            }
        }

        static char[] CodeArray(string code)
        {
            //Ersetzen '-' mit '', ' ' mit ''
            string normalizedCode = code.Replace("-", "").Replace(" ", "");
            //Convert to char array
            char[] codeArray = normalizedCode.ToCharArray();
            return codeArray;
        }

        //Return Length of codearray
        static int CheckIsbn(string code)
        {
            char[] codeArray = CodeArray(code);
            return codeArray.Length;
        }
        static bool ValidateIsbn10(string code)
        {
            char[] codeArray = CodeArray(code);
            int result = 0;

            //Rechen Ziffer 10
            for (int i = 0; i < 9; i++)
            {
                result += (codeArray[i] - '0') * (i + 1);
            }

            int z10 = result % 11;

            //Ziffer 10 überprüfen
            int checkNumber = 0;

            if (codeArray[9] == 'X' || codeArray[9] == 'x')
            {
                checkNumber = 10;
            }
            else
            {
                checkNumber = codeArray[9] - '0';
            }
            return z10 == checkNumber;
        }

        static bool ValidateIsbn13(string code)
        {
            char[] codeArray = CodeArray(code);
            int temp1 = (codeArray[0] - '0') + (codeArray[2] - '0') + (codeArray[4] - '0') + (codeArray[6] - '0') + (codeArray[8] - '0') + (codeArray[10] - '0');

            int temp2 = ((codeArray[1] - '0') + (codeArray[3] - '0') + (codeArray[5] - '0') + (codeArray[7] - '0') + (codeArray[9] - '0') + (codeArray[11] - '0')) * 3;
            int temp = (temp1 + temp2) % 10;
            int z13 = (10 - temp) % 10;

            if (z13 == (codeArray[12] - '0'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
