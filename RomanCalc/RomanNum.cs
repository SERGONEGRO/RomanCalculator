namespace RomanCalculator
{
    /// <summary>
    /// Class for convertation Roman numerals to Arabic numerals and vice versa
    /// </summary>
    static class RomanNum
    {
        static Dictionary<int, string> ra = new Dictionary<int, string>
         { { 1000, "M" },  { 900, "CM" },  { 500, "D" },  { 400, "CD" },  { 100, "C" },
                      { 90 , "XC" },  { 50 , "L" },  { 40 , "XL" },  { 10 , "X" },
                      { 9  , "IX" },  { 5  , "V" },  { 4  , "IV" },  { 1  , "I" } };

        /// <summary>
        /// Converts Arabic numerals to Roman
        /// </summary>
        /// <param name="number">Arabic number</param>
        /// <returns>Roman number</returns>
        public static string ToRoman(int number) => ra
            .Where(d => number >= d.Key)
            .Select(d => d.Value + ToRoman(number - d.Key))
            .FirstOrDefault();


        /// <summary>
        /// Converts Roman numerals to Arabic
        /// </summary>
        /// <param name="number">Roman number</param>
        /// <returns>Arabic number</returns>
        public static int ToArabic(string number) => number.Length == 0 ? 0 : ra
            .Where(d => number.StartsWith(d.Value))
            .Select(d => d.Key + ToArabic(number.Substring(d.Value.Length)))
            .First();
    }
}
