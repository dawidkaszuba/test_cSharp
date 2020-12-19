using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zad1("Dawid");
            //Zad2(6);
            //Zad3();
            Console.WriteLine(Zad4());
        }
        //--------------------ZADANIE 1---------------------
        static void Zad1(string tekst)
        {

            string toUpperCaseTekst = tekst.ToUpper();
            for (int i = 0; i < tekst.Length; i++)
            {
                if (toUpperCaseTekst[i] == 'A' || toUpperCaseTekst[i] == 'E' || toUpperCaseTekst[i] == 'I'
                    || toUpperCaseTekst[i] == 'O' || toUpperCaseTekst[i] == 'U' || toUpperCaseTekst[i] == 'Y')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(toUpperCaseTekst[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(toUpperCaseTekst[i]);
                }
            }
        }
        //--------------------------ZADANIE 2----------------------------------
        public static void  Zad2(int value)
        {
            for (int i = 0; i < value; i++) 
            {
                Console.WriteLine(new string('*', value-i) + new string('O',i));
            }
        }
        //-------------------ZADANIE 3---------------------------------------

        public static void Zad3() 
        {
            Random random = new Random();
            int value = random.Next(5, 16);
            int[,] array = GetArrayFilledWithRandomNumbers(value, random);
            ushort x;
            bool logiczna;
            do
            {
                Console.WriteLine("Podaj dodatnią liczbe całkowitą: ");
                logiczna = ushort.TryParse(Console.ReadLine(), out x);

            } while (!logiczna);

            DisplayArray(ChangeToStringArray(array, x));   
        }

        static string[,] ChangeToStringArray(int[,] intArray, int x)
        {

            string[,] stringArray = new string[intArray.GetLength(0), intArray.GetLength(1)];

            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                for (int j = 0; j < intArray.GetLength(1); j++)
                {
                    if (intArray[i, j] > x)
                    {
                        stringArray[i, j] = String.Format("{0,3}", intArray[i, j].ToString());
                    }
                    else
                    {
                        stringArray[i, j] = String.Format("{0,3}", "*");
                    }
                }
            }

            return stringArray;
        }

        static int[,] GetArrayFilledWithRandomNumbers(int value, Random random)
        {
            int[,] array = new int[value,value];

            for (int k = 0; k < array.GetLength(0); k++)
            {
                for (int l = 0; l < array.GetLength(1); l++)
                {
                    array[k, l] = random.Next(1, 201);
                }
            }
            return array;
        }

        static void DisplayArray(string[,] stringArray)
        {
            for (int i = 0; i < stringArray.GetLength(0); i++)
            {
                for (int j = 0; j < stringArray.GetLength(1); j++)
                {
                    Console.Write(stringArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        //--------------------------ZADANIE 4-------------------------------

        static string Zad4()
        {
            Random random = new Random();
            string pass = "";
            int counter = 0;
            while (!IfContainsSigns(pass))
            {
                pass = "";
                for (int i = 0; i < 10; i++) 
                {
                    int x = random.Next(30, 123);
                    char y = (Char)x;
                    pass += y;
                }
                counter++;
            }
            Console.WriteLine("Ilość prób generowania hasła: " + counter);
            return pass;
            }

        static bool IfContainsSigns(string pass)
        {
            return (pass.Contains('#') && pass.Contains('Y') && pass.Contains('a'));
        }
    }
    }

