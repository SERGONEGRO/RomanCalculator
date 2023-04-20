using RomanCalculator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculator
{
    public class Calculator
    {
        public static bool isOperation(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public static string Evaluate(string inp)
        {
            inp = inp.Replace(" ", ""); // Удаляем все пробелы

            /* Проверка на пустой ввод */
            if(inp=="")
                {
                    throw new Exception("Ошибка ввода! Пустая входная строка.");
                }

            /* Ищем знак операции и отталкиваясь от него определяем левое и правое число */
            List<String> inputs = new List<string>();
                for(int i = 0; i<inp.Length; i++){
                    if(isOperation(inp[i]) ){ // Ищем знак операции и делим строку на 3 элемента
                        inputs.Add(inp.Substring(0,i));   // Левое число
                        inputs.Add(inp.Substring(i, 1)); // Знак операции
                        inputs.Add(inp.Substring(i+1));   // Правое число
                        break;
                    }
                }
            /* Проверка некоректный ввод */
            if (inputs.Count == 0)
            {
                throw new Exception("Ошибка ввода! Не найдена допустимая операция.");
            }
            else if (inputs.Count == 1)
            {
                throw new Exception("Ошибка ввода! Отсутствуют значения.");
            }
            else if (inputs.Count == 2)
            {
                throw new Exception("Ошибка ввода! Одно из значений отсутствует.");
            }

            int left, right;  // Переменные для записи чисел после парсинга

            /* Парсинг чисел */
            try
            {
                // Пробуем получить обычное число
                left = RomanNum.ToArabic(inputs[0]);
                try
                {
                    // Если сработало, пробуем получить второе число
                    right = RomanNum.ToArabic(inputs[2]);
                    }
                catch (Exception)
                {
                    throw new Exception("Ошибка ввода! Неожиданное значение '" + inputs[2] + "'.");
                }
            }
            catch (Exception)
            {
                throw new Exception("Ошибка ввода! Неожиданное значение '" + inputs[0] + "'.");
            }

            int result;
            /* Определяем нужную операцию */
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
                    throw new Exception("Ошибка ввода! Неожиданный оператор '" + inputs[1] + "'.");
            
           
            }
            return RomanNum.ToRoman(result);
        }
    }
}
