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
            uint seconds = 0;
            uint minutes = 0;
            uint hours = 0;
            int min = 0;
            int max = 0;


            //start of sum
            Console.WriteLine("please input 3 whole numbers that you wish to get the sum of. hit enter after each number");

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    sum += Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: that was not a whole number. Please input a whole number");
                    i--;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: Number outside the storable range. Please input a different number");
                    i--;
                }
            }

            Console.WriteLine(sum);

            //start of polynomial solver
            Console.WriteLine("please input a whole number for x in the equation 4x^3 + 5x – 3");
            while (!answered)
            {
                answered = CalcPoly(Console.ReadLine(), out answer);
            }

            Console.WriteLine(answer);

            //start of time calculator
            Console.WriteLine("please input a a time in seconds to have it converted to a hh:mm:ss format");
            answered = false;
            while (!answered)
            {
                answered = TimeCalc(Console.ReadLine(), out seconds, out minutes, out hours);
            }
            Console.WriteLine($"{hours} hours, {minutes} minutes, {seconds} seconds");

            //start of max and min
            Console.WriteLine("please input a sequence of whole numbers, hitting enter after each one to find the maxium and minimum value. once you have entered all the values type \"end\"");
            answered = false;
            while (!answered)
            {
                answered = MinMax(out min, out max);
            }

            Console.WriteLine($"min :{min}, Max:{max}");

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
                Console.WriteLine("Error: that was not a whole number. Please input a whole number");
                result = 0;
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Number outside the storable range. Please input a different number");
                result = 0;
                return false;
            }

            result = (((4 * MathF.Pow(x, 3)) + (5 * x)) - 3);
            return true;
        }

        static bool TimeCalc(string input, out uint seconds, out uint minutes, out uint hours)
        {
            seconds = 0;
            minutes = 0;
            hours = 0;

            try
            {
                seconds = UInt32.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: that was not a time in seconds. Please input a whole number");
                seconds = 0;
                minutes = 0;
                hours = 0;
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: to large of a time. Please input a smaller number");
                seconds = 0;
                minutes = 0;
                hours = 0;
                return false;
            }


            if (seconds > 60)
            {
                minutes = seconds / 60;
                seconds -= minutes * 60;
            }

            if (minutes > 60)
            {
                hours = minutes / 60;
                minutes -= hours * 60;
            }

            return true;
        }

        static bool MinMax(out int min, out int max)
        {
            string input = "";
            int[] numbers = new int[1];
            int numberIndex = 0;

            while (input != "end")
            {
                input = Console.ReadLine();

                if (numbers.Length - 1 == numberIndex)
                {
                    Array.Resize(ref numbers, numbers.Length * 2);
                }
                if (input != "end")
                {
                    try
                    {
                        numbers[numberIndex] = Int32.Parse(input);
                        numberIndex++;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: this was not a valid number, please input a whole number");
                        min = 0;
                        max = 0;
                        return false;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Error: this number was too big, please input a smaller number");
                        min = 0;
                        max = 0;
                        return false;
                    }
                }
            }
            min = numbers[0];
            max = numbers[0];

            for (int i = 0; i < numberIndex; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];
                }

                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }
            return true;

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
    }
}
