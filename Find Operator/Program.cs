using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Operator
{
    internal class Program
    {
        static string[,] cityPhoneCodes =
            {
                {"Berde","2020"},
                {"AZERCELL (SIM)","50"},
                {"AZERCELL (SIM)","51"},
                {"BAKCELL (CIN)","55"},
                {"BAKCELL (CIN)","99"},
                {"NAR (Nar)","70"},
                {"NAR (Nar)","77"},
                {"NAXTELL (Naxtel)","60"},
                {"Baki","12"},
                {"Sumqayit","18"},
                {"Ucar","2021"},
                {"Agsu","2022"},
                {"Agdas","2023"},
                {"Qobustan","2024"},
                {"Kurdemir","2025"},
                {"Samaxi","2026"},
                {"Goycay","2027"},
                {"Ismayilli","2028"},
                {"Zerdab","2029"},
                {"Haciqabul","2120"},
                {"Sirvan","2121"},
                {"Beyleqan","2122"},
                {"Sabirabad","2123"},
                {"Imisli","2124"},
                {"Salyan","2125"},
                {"Neftcala","2126"},
                {"Agcabedi","2127"},
                {"Saatli","2128"},
                {"Goygol","2220"},
                {"Daskesen","2221"},
                {"Agstafa","2222"},
                {"Gence","2225"},
                {"Terter","2223"},
                {"Goranboy","2224"},
                {"Samux","2227"},
                {"Qazax","2229"},
                {"Semkir","2230"},
                {"Tovuz","2231"},
                {"Gedebey","2232"},
                {"Yevlax","2233"},
                {"Naftalan","2235"},
                {"Siyezen","2330"},
                {"Xizi","2331"},
                {"Xacmaz","2332"},
                {"Quba","2333"},
                {"Sabran","2335"},
                {"Qusar","2338"},
                {"Qebele","2420"},
                {"Oguz","2421"},
                {"Zaqatala","2422"},
                {"Seki","2424"},
                {"Qax","2425"},
                {"Mingecevir","2427"},
                {"Balaken","2429"},
                {"Yardimli","2520"},
                {"Xocali","2620"},
                {"Qubadli","2623"},
                {"Susa","2626"},
                {"Fuzuli","2631"},
                {"Babek","36541"},
                {"Culfa","36546"},
                {"Ordubad","36547"},
                {"Sahbuz","36543"}
            };
        static void Main(string[] args)
        {
            Heading();
            while (true)
            {
                Console.Write("Nomrenizi daxil edin : ");
                string number = Console.ReadLine();
                if (number == String.Empty)
                {
                    break;
                }
                number = ReplaceNumber(number);
                Console.WriteLine("Nomreniz : " + number);
                int justNumber = JustNumber(number);
                MajorAlgorithmForFindOperators(number, justNumber);
            }
            Console.ReadKey();
        }
        #region Methods
        static void MajorAlgorithmForFindOperators(string number, int justNumber)
        {
            bool checkCode = false;
            if ((number.Length == 13 && justNumber == 12) || (number.Length == 14 && justNumber == 14) || (number.Length == 10 && justNumber == 10) || (number.Length == 9 && justNumber == 9))
            {
                if (number.StartsWith("+994"))
                {
                    checkCode = FindNumberCode1(number, checkCode);
                }
                else if (number.StartsWith("00994"))
                {
                    checkCode = FindNumberCode2(number, checkCode);
                }
                else if (number.StartsWith("0") && number[1] != '0')
                {
                    checkCode = For10LengthNumber(number, checkCode);
                }
                checkCode = For9LengthNumber(number, checkCode);
            }
            else
            {
                Console.WriteLine("Zehmet olmasa nomreni duzgun daxil edin .");
                Console.WriteLine();
            }
        }
        static bool For10LengthNumber(string number, bool checkCode)
        {
            bool flag = false;
            for (int i = 0; i < cityPhoneCodes.GetLength(0); i++)
            {
                for (int j = 0; j < cityPhoneCodes.GetLength(1); j++)
                {
                    if (cityPhoneCodes[i, 1] == number.Substring(1, 2) || cityPhoneCodes[i, 1] == number.Substring(1, 4) || cityPhoneCodes[i, 1] == number.Substring(1, 5))
                    {
                        checkCode = true;
                        flag = true;
                    }
                }

                if (flag)
                {
                    Console.WriteLine("Sizin nomreniz : " + cityPhoneCodes[i, 0] + " seherine aiddir .");
                    Console.WriteLine();
                }

                flag = false;
                if (i == cityPhoneCodes.GetLength(0) - 1 && checkCode == false)
                {
                    Console.WriteLine("Daxil etdiyiniz nomre hec bir operatora uygun deyil.Zehmet olmasa duzgun daxil edin .");
                    Console.WriteLine();
                }
            }

            return checkCode;
        }
        static bool For9LengthNumber(string number, bool checkCode)
        {
            bool flag = false;
            for (int i = 0; i < cityPhoneCodes.GetLength(0); i++)
            {
                for (int j = 0; j < cityPhoneCodes.GetLength(1); j++)
                {
                    if (number.Length == 9 && (cityPhoneCodes[i, 1] == number.Substring(0, 2) || cityPhoneCodes[i, 1] == number.Substring(0, 4) || cityPhoneCodes[i, 1] == number.Substring(0, 5)))
                    {
                        checkCode = true;
                        flag = true;
                    }
                }

                if (flag)
                {
                    Console.WriteLine("Sizin nomreniz : " + cityPhoneCodes[i, 0] + " seherine aiddir .");
                    Console.WriteLine();
                }

                flag = false;
                if (i == cityPhoneCodes.GetLength(0) - 1 && checkCode == false)
                {
                    Console.WriteLine("Daxil etdiyiniz nomre hec bir operatora uygun deyil.Zehmet olmasa duzgun daxil edin .");
                    Console.WriteLine();
                }
            }

            return checkCode;
        }
        static void Heading()
        {
            Console.WriteLine("\t\t\t\t\t*FIND PHONE NUMBER OF CITY*");
            Console.WriteLine("\t\t\t\t\t* * * * * * * * * * * * * *");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**Bu program daxil etdiyiniz nomrenin Azerbaycanin hansi seherinden ve ya operatorundan oldugunu tapir**");
            Console.WriteLine();
            Console.WriteLine("(Programdan cixmaq ucun \"ENTER\" duymesine 2 defe vurun .)");
            Console.WriteLine();
        }
        static string ReplaceNumber(string number)
        {
            number = number.Replace(" ", "");
            number = number.Replace("-", "");
            number = number.Replace("(", "");
            number = number.Replace(")", "");
            number = number.Replace(".", "");
            return number;
        }
        static int JustNumber(string number)
        {
            int justNumber = 0;
            char[] numArr = new char[number.Length];
            for (int i = 0; i < number.Length; i++)
            {
                numArr[i] = number[i];
            }

            for (int i = 0; i < number.Length; i++)
            {
                if (numArr[i] >= 48 && numArr[i] <= 57)
                {
                    justNumber++;
                }
            }
            return justNumber;
        }
        static bool FindNumberCode2(string number, bool checkCode)
        {
            bool flag = false;
            for (int i = 0; i < cityPhoneCodes.GetLength(0); i++)
            {
                for (int j = 0; j < cityPhoneCodes.GetLength(1); j++)
                {
                    if (cityPhoneCodes[i, 1] == number.Substring(5, 2) || cityPhoneCodes[i, 1] == number.Substring(5, 4) || cityPhoneCodes[i, 1] == number.Substring(5, 5))
                    {
                        checkCode = true;
                        flag = true;
                    }
                }

                if (flag)
                {
                    Console.WriteLine("Sizin nomreniz : " + cityPhoneCodes[i, 0] + " seherine aiddir .");
                    Console.WriteLine();
                }

                flag = false;
                if (i == cityPhoneCodes.GetLength(0) - 1 && checkCode == false)
                {
                    Console.WriteLine("Daxil etdiyiniz nomre hec bir operatora uygun deyil.Zehmet olmasa duzgun daxil edin .");
                    Console.WriteLine();
                }
            }

            return checkCode;
        }
        static bool FindNumberCode1(string number, bool checkCode)
        {
            bool flag = false;
            for (int i = 0; i < cityPhoneCodes.GetLength(0); i++)
            {
                for (int j = 0; j < cityPhoneCodes.GetLength(1); j++)
                {
                    if (cityPhoneCodes[i, 1] == number.Substring(4, 2) || cityPhoneCodes[i, 1] == number.Substring(4, 4) || cityPhoneCodes[i, 1] == number.Substring(4, 5))
                    {
                        checkCode = true;
                        flag = true;
                    }
                }

                if (flag)
                {
                    Console.WriteLine("Sizin nomreniz  " + cityPhoneCodes[i, 0] + " operatoruna aiddir .");
                    Console.WriteLine();
                }

                flag = false;
                if (i == cityPhoneCodes.GetLength(0) - 1 && checkCode == false)
                {
                    Console.WriteLine("Daxil etdiyiniz nomre hec bir operatora uygun deyil.Zehmet olmasa duzgun daxil edin .");
                    Console.WriteLine();
                }
            }

            return checkCode;
        }
        #endregion
    }
}
