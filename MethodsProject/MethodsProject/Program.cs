using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace MethodsProject
{
    class Program
    {
        // Метод возвращает TRUE, если переданное число является полиндромом.
        public static bool isPolindrom(uint number)
        {
            // Коллекция figures содержит все цифры переданного числа.
            List<byte> figures = new List<byte>();

            // Если число состоит из одной цифры, оно не является полиндромом.
            if (number < 10)
                return false;

            // Разбиваю входное число на цифры и заношу их в коллекцию.
            while (number > 9)
            {
                figures.Add((byte)(number % 10));
                number /= 10;
            }
            figures.Add((byte)number);

            // Сравниваю попарно цифры хранящиеся в Коллекции.
            for (int i = 0, j = figures.Count - 1; i < figures.Count / 2; i++, j--)
                if (figures[i] != figures[j])
                    return false;
            return true;// В случае если все цифры попарно равны, число является полиндромом.
        }

        // Метод удаляет все единицы из переданного uint числа.
        public static uint doRemoveNumbOne(uint num)
        {
            uint countDig = 1;// Эта переменная будет содержать текущий порядок полученного числа
            uint outNumber = 0;// Переменная содержащая выходной результат.

            while (num > 0)
            {
                uint tmpInt = num % 10;//получаю очередное число в остатке 
                if (tmpInt != 1) // если оно не равно 1, добавляю к выходному результату, предварительно умножив на порядок числа.
                {
                    outNumber += tmpInt * countDig;
                    countDig *= 10;// Увеличиваю порядок числа.
                }
                num /= 10;
            }
            return (outNumber);
        }

        // Рекурсивный метод, который возвращает TRUE в случае если переданная строка является
        // симметричной.
        public static bool isStringSymmetric(string inString, bool isFirstCycle)
        {
            char[] firstChar = new char[1];
            char[] lastChar = new char[1];

            // Если длинна переданной строки в метод меньше или равно 1, такая строка не является симметричной.
            // isFirstCycle необходима для определения кто передал строку внешний метод или это уже рекурсивный вызов.
            if (inString.Length <= 1 && isFirstCycle)
                return false;

            // Если при очередном рекурсивном вызове длинна строки равна 1 или 0, то строка является симметричной.
            if (inString.Length <= 1)
                return true;

            // Копирую первый и последний символы из исходного массива в соответствующие массивы типа char.
            inString.CopyTo(0, firstChar, 0, 1);
            inString.CopyTo(inString.Length - 1, lastChar, 0, 1);

            // Уменьшаю длинну строки путем обрезания первого и последнего символа.
            //inString = inString.Substring(1, inString.Length - 2);
            inString = inString.Remove(inString.Length - 1, 1).Remove(0, 1);//как вариант верхней строки.

            // Сравниваю полученные первый и последний символы на равенство, 
            // в симметричной строке они должны быть равны.
            // Запускаю рекурсию, и определяю является ли симметричной оставшаяся подстрока.
            // Если да, возвращаю true из метода.
            if (firstChar[0] == lastChar[0] && isStringSymmetric(inString, false))
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            #region Задание №1
            // Задание №1
/*            uint num = 1221;
            Console.Write("Число {0} ", num);
            if (isPolindrom(num))
                
                Console.WriteLine("является полиндромом.");
            else
                Console.WriteLine("не является полиндромом.");
            */
            #endregion

            #region Задание №2
            /*            uint num2 = 121001;
            Console.WriteLine(num2);
           Console.WriteLine(doRemoveNumbOne(num2));
 */
            #endregion

            #region Задание №3
                        string str = "FJб,бJF";

            if (isStringSymmetric(str, true))
                Console.WriteLine("Строка \"{0}\" является симметричной", str);
            else
                Console.WriteLine("Строка \"{0}\" не является симметричной", str);

            #endregion
        }
    }
}
