using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_tasks
{
    class Program
    {
        #region Methods
        public static void SortArray(ref int[] array)//task 1
        {
            //Готовое решение сортировки
            //Array.Sort(array);

            //Cортировка пузырьком
            int temp = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static bool FindElementByArray(int[] array, int value)//task 2
        {
            //array.Where(x => x == value);
            bool temp = false;
            foreach(int i in array)
            {
                if (i == value) {
                    temp = true;
                    break;
                }
            }
            return temp;
        }

        public static void FindDistinctStrings(string str)//task 3
        {
            string[] substr = str.ToLower().Split(' ');
            int n = 1;
            for (int i = 0; i < substr.Length; i++)
            {
                substr[i] = substr[i].Trim('.', ',');
            }
            var val = substr.Where(x => substr.Count(z => z == x) == n);
            Console.WriteLine(string.Join(" ", val));
        }

        public static int Factorial(int value)//task 4
        {
            if (value == 1) return 1;
            return value * Factorial(value - 1);
        }

        public static void Stack(string str)//task 5
        {
            Stack stack = new Stack();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '{' || str[i] == '[')
                {
                    stack.Push(str[i]);
                }
                else
                {
                    if ((str[i] == ')' && stack.Count != 0 && stack.Peek().ToString() == "(") ||
                        (str[i] == '}' && stack.Count != 0 && stack.Peek().ToString() == "{") ||
                        (str[i] == ']' && stack.Count != 0 && stack.Peek().ToString() == "["))
                    {
                        stack.Pop();
                    }
                    else if ((str[i] == ')' || str[i] == '}' || str[i] == ']') && stack.Count == 0)
                    {//строка начинается с закрывающейся скобки или в конце стоит закрывающая
                        stack.Push(i);
                        break;
                    }
                }
                
            }
            if (stack.Count == 0)
                Console.WriteLine("Правильная скобочная последовательность");
            else
                Console.WriteLine("Неправильная скобочная последовательность");
        }
        #endregion

        static void Main(string[] args){

            #region task1
            const int maxSize = 100;//макс-й размер массива
            int size = 0;//размер массива
            do
            {
                Console.Write("\n1. Введите размерность массива n (1-" + maxSize + "):  ");
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { }
            }
            while (size < 1 || size > maxSize);
            int[] array = new int[size];
            const int k = 100;// граница диапозона [-100,100]
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-k, k + 1); //генерируем массив случайных чисел в  диапазоне [-k..k]
            }
            Console.WriteLine("Сгенерированный массив с размерностью " + size);
            foreach (int i in array) Console.Write(i + " ");
            SortArray(ref array);
            Console.WriteLine("\nОтсортированный массив с размерностью " + size);
            foreach (int i in array) Console.Write(i + " ");
            #endregion

            #region task2
            int value = 0;//искомое значение в массиве
            do
            {
                Console.Write("\n\n2. Найти элемент в массиве: ");
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { }
            }
            while (value < Int32.MinValue || value > Int32.MaxValue);
            string message = FindElementByArray(array, value) ? "Элемент найден" : "Элемент не найден";
            Console.WriteLine(message);
            #endregion

            #region task3
            string str;
            do
            {
                Console.Write("\n3. Введите строку: ");
                str = Console.ReadLine();
            }
            while (str == null);
            FindDistinctStrings(str);
            #endregion

            #region task4
            int valueFactorial = 1;//искомое значение в массиве
            do
            {
                Console.Write("\n4. Найти факториал числа (1-31): ");
                try
                {
                    valueFactorial = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { }
            }
            while (valueFactorial < 1 || valueFactorial > Int32.MaxValue);
            Console.WriteLine("Факториал " + valueFactorial + " = " + Factorial(valueFactorial));
            #endregion

            #region task5
            string strOfBrackets;//введённая строка
            bool correctInput = true;//проверка ввода
            do
            {
                correctInput = true;
                Console.Write("\n5. Введите строку, содержащую только скобки (){}[]: ");
                strOfBrackets = Console.ReadLine();
                for (int i = 0; i < strOfBrackets.Length; i++)
                {
                    if (strOfBrackets[i] != '(' &&
                        strOfBrackets[i] != ')' &&
                        strOfBrackets[i] != '{' &&
                        strOfBrackets[i] != '}' &&
                        strOfBrackets[i] != '[' &&
                        strOfBrackets[i] != ']')
                    {
                        correctInput = false;
                    }
                }
            }
            while (correctInput == false);
            Stack(strOfBrackets);
            #endregion

            Console.ReadKey();
        }
    }
}
