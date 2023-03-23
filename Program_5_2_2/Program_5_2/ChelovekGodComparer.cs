using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_5_2
{
    //компаратор для людей по году рождения
    class ChelovekGodComparer : IComparer<Chelovek>
    {
        public int Compare(Chelovek? c1, Chelovek? c2) 
        {
            //по убыванию
            return c2.GetGod() - c1.GetGod();
        }
    }
}
