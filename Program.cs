using System;

namespace inbs10
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintIsbnResult();

        }

        static void PrintIsbnResult()
        {
            bool shouldContinue = true;

            while (shouldContinue == true)
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
                Console.WriteLine("Nochmal? [ja]: ");
                if (Console.ReadLine().ToLower() == "nein")
                {
                    shouldContinue = false;
                }
                else
                {
                    shouldContinue = true;
                }
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

            //Rechnen Ziffer 10
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
                checkNumber = codeArray[9] - '0'; // https://stackoverflow.com/a/239107/12432221
            }
            return z10 == checkNumber;
        }

        static bool ValidateIsbn13(string code)
        {
            char[] codeArray = CodeArray(code);

            int temp1 = 0;
            int temp2 = 0;

            for (int i = 0; i < 12; i++)
            {
                if ((i % 2) == 0)
                {
                    temp1 += (codeArray[i] - '0');
                }
                else
                {
                    temp2 += (codeArray[i] - '0') * 3;
                }
            }
            int z13 = (10 - ((temp1 + temp2) % 10)) % 10;

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
