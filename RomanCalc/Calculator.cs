using System.Text.RegularExpressions;

namespace RomanCalculator
{
    /// <summary>
    /// Class for calculating expressions consisting of Roman numerals
    /// </summary>
    public class Calculator
    {
        #region METHODS

        /// <summary>
        /// checking the operation sign
        /// </summary>
        /// <param name="c">sign of operation</param>
        /// <returns>true if operation is valid</returns>
        public static bool isOperation(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        /// <summary>
        /// The main method. Accepts a string, performs checks, returns the result
        /// </summary>
        /// <param name="inp">Input string</param>
        /// <returns>answer</returns>
        /// <exception cref="Exception"></exception>
        public static string Evaluate(string inp)
        {
            // Remove blank.
            inp = inp.Replace(" ", "");

            if (inp == "")
            {
                throw new Exception("Input error! Empty input string.");
            }

            //look for brackets and solve the equations in them
            Regex regEx = new Regex(@"([a-z]*)\(([^\(\)]+)\)(\^|!?)", RegexOptions.IgnoreCase);
            Match m = regEx.Match(inp);
            while (m.Success)
            {
                if (m.Groups[3].Value.Length > 0) inp = inp.Replace(m.Value, m.Groups[1].Value + Solve(m.Groups[2].Value) + m.Groups[3].Value);
                else inp = inp.Replace(m.Value, m.Groups[1].Value + Solve(m.Groups[2].Value));
                m = regEx.Match(inp);
            }

            //there are no more brackets left. solve the equation
            return Solve(inp);

        }

        /// <summary>
        /// Performs the solution of a simple expression consisting of two arguments and an operation sign
        /// </summary>
        /// <param name="inp">Input string</param>
        /// <returns>result</returns>
        /// <exception cref="Exception"></exception>
        public static string Solve(string inp)
        {
            /* looking for the sign of the operation and determine the left and right numbers */
            List<String> inputs = new List<string>();
            for (int i = 0; i < inp.Length; i++)
            {
                if (isOperation(inp[i]))
                { //looking for the operation sign and divide the string into 3 elements
                    inputs.Add(inp.Substring(0, i));   // left number
                    inputs.Add(inp.Substring(i, 1)); // operation sign
                    inputs.Add(inp.Substring(i + 1));   // right number
                    break;
                }
            }
            /* Check if incorrect input */
            if (inputs.Count == 0)
            {
                throw new Exception("Input error! A valid operation was not found.");
            }
            else if (inputs.Count == 1)
            {
                throw new Exception("Input error! Missing values.");
            }
            else if (inputs.Count == 2)
            {
                throw new Exception("Input error! One of the values is missing.");
            }

            int left, right;  // Variables for writing numbers after parsing

            /* Parsing numbers */
            try
            {
                // Trying to get the left number
                left = RomanNum.ToArabic(inputs[0]);
                try
                {
                    // If it worked, we try to get the right number
                    right = RomanNum.ToArabic(inputs[2]);
                }
                catch (Exception)
                {
                    throw new Exception("Input error! Unexpected value '" + inputs[2] + "'.");
                }
            }
            catch (Exception)
            {
                throw new Exception("Input error! Unexpected value '" + inputs[0] + "'.");
            }

            int result;
            /* define the necessary operation */
            switch (inputs[1].ToCharArray()[0])
            {
                case '+':
                    result = left + right;
                    break;
                case '-':
                    result = left - right;
                    break;
                case '*':
                    result = left * right;
                    break;
                case '/':
                    result = left / right;
                    break;
                default:
                    throw new Exception("Input error! Unexpected operator" + inputs[1] + "'.");

            }
            return RomanNum.ToRoman(result);
        }
        #endregion
    }
}
