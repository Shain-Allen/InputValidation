using System;

namespace InputValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            Console.WriteLine("please input 3 whole numbers that you wish to get the sum of. hit enter after each number");

            for (int i = 0; i < 3; i++)
            {
                sum += Int32.Parse(Console.ReadLine());
            }
        }

        char GradeConverter(int numberGrade)
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
