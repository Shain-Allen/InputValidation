using System;

namespace InputValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            float answer = 0;
            bool answered = false;


            Console.WriteLine("please input 3 whole numbers that you wish to get the sum of. hit enter after each number");

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    sum += Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("that was not a whole number. Please input a whole number");
                    i--;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number outside the storable range. Please input a different number");
                    i--;
                }
            }

            Console.WriteLine(sum);

            Console.WriteLine("please input a whole number for x in the equation 4x^3 + 5x – 3");
            while (!answered)
            {
                answered = CalcPoly(Console.ReadLine(), out answer);
            }

            Console.WriteLine(answer);
        }

        static char GradeConverter(int numberGrade)
        {
            switch (numberGrade)
            {
                case 100:
                case 91:
                    return 'A';
                case 90:
                case 81:
                    return 'B';
                case 80:
                case 71:
                    return 'C';
                case 70:
                case 61:
                    return 'D';
                default:
                    return 'F';
            }
        }

        static bool CalcPoly(string input, out float result)
        {
            //4x^3 + 5x – 3
            int x;

            try
            {
                x = Int32.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("that was not a whole number. Please input a whole number");
                result = 0;
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number outside the storable range. Please input a different number");
                result = 0;
                return false;
            }

            result = (((4 * MathF.Pow(x, 3)) + (5 * x)) - 3);
            return true;
        }
    }
}
