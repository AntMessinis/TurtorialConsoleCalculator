using System;
using System.IO;

namespace CalculatorTurtorial
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num2 - num1;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            bool endApp = false;
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\r");

            while (!endApp)
            {
                //Declaring variables
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                //Asking the user to type the first number
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not a valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                //Asking the user to type the second number.
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not a valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                //Asking the user to choose an operator
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option: ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");

                    }
                    else Console.WriteLine($"Your result: {result:0.##}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An exception occurred trying to do the math.\n - Details: {e.Message}");
                }
                Console.WriteLine("------------------------\r");

                //Waiting for the user to respond before closing
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue:");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
                
            }
            return;
        }
    }
}

