using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculator
{
    static class RomanNumEx
    {
        static int o = 1;
        static string w = "IVXLCDM";
        static Dictionary<char, int> ra = w.ToDictionary(ch => ch, ch => (o = ("" + o)[0] == '1' ? o * 2 : o * 5) / 2);

        public static int ToArabic(string num) => num
            .Select((c, i) => ++i < num.Length && ra[c] < ra[num[i]] ? -ra[c] : ra[c]).Sum();

        static string W(int k, int l = 1) => w.Substring(k, l);
        static string R(char m, int k) => m == '9' ? W(k - 2) + W(k) : m == '5' ? W(k - 1) : m == '4' ? W(k - 2, 2) : W(k - 2);

        public static string ToRoman(int num) => num < 1 ? "" :
            (from z in "000100101".Split('1') from m in "9541" select m + z)
            .Where(z => num >= (o = int.Parse(z)))
            .Select(z => R(z[0], z.Length * 2)).First() + ToRoman(num - o);
    }
}
