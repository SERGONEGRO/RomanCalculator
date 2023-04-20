using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculator
{
    class Programm
    {
        static void Main()
        {
            Console.WriteLine(RomanNum.ToRoman(789));
            Calculator.Evaluate("MMMDCCXXIV - MMCCXXIX");
        }
      
    }
}
