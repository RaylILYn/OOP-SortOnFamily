using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Program_5_2
{
    //класс массива вещественных чисел
    class Marr
    {
        private float[] data; //сам массив

        public Marr(int len)
        {
            data = new float[len];
        }

        //конструктор по массиву строк, начиная с pos'й позиции
        public Marr(string[] strings, int pos)
        {
            data = new float[strings.Length - pos];
            for (int i = pos; i < strings.Length; ++i)
            {
                data[i - pos] = Convert.ToSingle(strings[i]);
            }
        }

        //метод для ввода числа типа string
        static string ScanStr(string name)
        {
            Console.Write("Введите " + name + ": ");
            return Console.ReadLine();
        }

        //метод для ввода числа типа int
        static int ScanInt(string name)
        {
            Console.Write("Введите " + name + ": ");
            return Convert.ToInt32(Console.ReadLine());
        }

        //метод для ввода числа типа float
        static float ScanFloat(string name)
        {
            Console.Write("Введите " + name + ": ");
            return Convert.ToSingle(Console.ReadLine());
        }

        //метод для установления значения i-ого элемента
        public void Set(int i, float d)
        {
            data[i] = d;
        }

        //метод для ввода информации о поезде
        public void Scan()
        {
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = ScanFloat($"{i + 1}'й элемент");
            }
        }

        public int GetLength()
        {
            return data.Length;
        }

        public float Get(int i)
        {
            return data[i];
        }

        //метод который находит минимальный элемент, первый или последний
        public int GetMinInd(bool last)
        {
            int mnInd = 0;
            for (int i = 0; i < data.Length; ++i)
            {
                if ((last && data[mnInd] >= data[i]) || (!last && data[mnInd] > data[i]))
                {
                    mnInd = i;
                }
            }
            return mnInd;
        }

        //метод с переменным кол-во параметров
        public float GetSum(params int[] indArr)
        {
            float sum = 0;
            foreach (int ind in indArr)
            {
                if (ind <= data.Length)
                {
                    sum += data[ind - 1];
                }
            }

            if (indArr.Length == 0)
            {
                for (int i = 0; i < data.Length; ++i)
                {
                    sum += data[i];
                }
            }

            return sum;
        }

        //перегрузка оператора сложения
        public static Marr operator +(Marr arr1, Marr arr2)
        {
            Marr res = new Marr(arr1.GetLength() + arr2.GetLength());
            int ind = 0;
            for (int i = 0; i < arr1.GetLength(); ++i)
            {
                res.Set(ind++, arr1.Get(i));
            }

            for (int i = 0; i < arr2.GetLength(); ++i)
            {
                res.Set(ind++, arr2.Get(i));
            }

            return res;
        }


        //перегрузка операторов true/false
        public static bool operator true(Marr arr)
        {
            for (int i = 0; i < arr.GetLength(); ++i)
            {
                if (arr.data[i] == 0)
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator false(Marr arr)
        {
            for (int i = 0; i < arr.GetLength(); ++i)
            {
                if (arr.data[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        //метод вычисляет сумму половины элементов (c четными номерами, или нечетными)
        public float GetSumHalf(bool even)
        {
            float sum = 0;
            for (int i = (even ? 1 : 0); i < data.Length; i += 2)
            {
                sum += data[i];
            }
            return sum;
        }

        //метод заменяет нули на переданные значения
        public void SetZeros(float newValue)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                if (data[i] == 0) { data[i] = newValue; }
            }
        }

        //метод для вывода информации о поезде с учетом вагона
        public void Print()
        {
            for (int i = 0; i < data.Length; ++i)
            {
                Console.Write($"{data[i]} ");
            }
            Console.WriteLine();
        }
    }
}
