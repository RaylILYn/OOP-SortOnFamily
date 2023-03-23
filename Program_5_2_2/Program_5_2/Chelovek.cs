using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_5_2
{
    class Chelovek
    {
        private string fam, status; //фамилия и статус
        private int god;            //год рождения

        public Chelovek(string fam, string status, int god)
        {
            this.fam = fam;
            this.status = status;
            this.god = god;
        }


        public string GetFam()
        {
            return fam;
        }
        public int GetGod()
        {
            return god;
        }
        public string GetStatus()
        {
            return status;
        }

        //метод выводит информацию о человеке
        public void info()
        {
            if (old() < 25)
            {
                //при необходимости меняем цвет вывода на зеленый
                Console.ForegroundColor = ConsoleColor.Green;
            }
            //форматированный вывод под таблицу
            Console.WriteLine("{0, 10}{1, 10}{2, 18}{3, 26}", fam, god, status, Svedenija());
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //метод опредеяет возраст
        public int old()
        {
            return 2023 - god;
        }


        //виртуальный метод для получения сведений о человеке
        virtual public string Svedenija()
        {
            return $"Возраст {Convert.ToString(old())}";

        }
    }

}
