namespace RomanCalculator
{
    class Programm
    {
        static void Main()
        {
            Console.WriteLine("Enter the expression:");

            string expression = "(MMMDCCXXIV - MMCCXXIX) * II";
            //string expression = Console.ReadLine();
            Console.WriteLine("Calculating an expression: " + expression);

            Console.WriteLine("Answer: " + Calculator.Evaluate(expression));
        }
      
    }
}
