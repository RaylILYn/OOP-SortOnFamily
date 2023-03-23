using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Program_5_2
{
    class Program
    {
        //метод для ввода числа типа float
        static float ScanFloat(string name)
        {
            Console.WriteLine("Введите " + name);
            return Convert.ToSingle(Console.ReadLine());
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



        static void Main(string[] args)
        {
            List<Chelovek> ludi = new List<Chelovek>();

            StreamReader reader = new StreamReader("info.txt");

            while (reader.Peek() > -1) {
                string[] name = reader.ReadLine().Split(' ');
                if (name[1] == "студент")
                {
                    ludi.Add(new Student(
                        name[0], 
                        name[1], 
                        Convert.ToInt32(name[2]), 
                        new Marr(name, 3)));

                } else if (name[1] == "преподаватель")
                {
                    ludi.Add(new Lecturer(
                        name[0],
                        name[1],
                        Convert.ToInt32(name[2]),
                        new Marr(name, 3)));
                } else
                {
                    ludi.Add(new Chelovek(
                        name[0],
                        name[1],
                        Convert.ToInt32(name[2])));
                }
            }

            Chelovek[] ludiArr = ludi.ToArray();

            Console.WriteLine("{0, 10}{1, 10}{2, 18}{3, 26}", "Фамилия", "Статус", "Год рождения", "Дополнительные сведения");
            foreach(Chelovek chelovek in ludiArr) {
                chelovek.info();
            }
            Console.WriteLine("\nСортировка по фамилиям...\n");

            Array.Sort(ludiArr, new ChelovekFamComparer());
            Console.WriteLine("{0, 10}{1, 10}{2, 18}{3, 26}", "Фамилия", "Статус", "Год рождения", "Дополнительные сведения");
            foreach (Chelovek chelovek in ludiArr)
            {
                chelovek.info();
            }

            double avarage = 0;
            int cnt = 0;
            foreach (Chelovek chelovek in ludiArr)
            {
                if (chelovek.GetStatus() == "преподаватель")
                {
                    avarage += ((Lecturer)chelovek).GetLoad().Get(1);
                    ++cnt;
                }
            }
            Console.WriteLine($"\nСредняя нагрузка преподавателей по КИТ: {avarage / cnt}");

            //сортируем по году рождения
            Array.Sort(ludiArr, new ChelovekGodComparer());
            Console.WriteLine("\nСписок должников:");
            Console.WriteLine("{0, 10}{1, 10}{2, 18}{3, 26}", "Фамилия", "Статус", "Год рождения", "Дополнительные сведения");
            foreach (Chelovek chelovek in ludiArr)
            {
                if (chelovek.GetStatus() == "студент")
                {
                    Marr grade = ((Student)chelovek).GetGrade();
                    if (grade.Get(grade.GetMinInd(false)) < 3)
                    {
                        chelovek.info();
                    }
                }
            }

            Console.ReadKey();
        }
    }
}