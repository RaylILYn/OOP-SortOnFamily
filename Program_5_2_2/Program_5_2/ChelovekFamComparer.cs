using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_5_2
{
    //компаратор для людей по фамилии
    class ChelovekFamComparer : IComparer<Chelovek>
    {
        public int Compare(Chelovek? c1, Chelovek? c2)
        {
            //просто сравниваем строки
            return c1.GetFam().CompareTo(c2.GetFam());
        }
    }
}
