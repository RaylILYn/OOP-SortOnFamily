using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_5_2
{
    class Lecturer : Chelovek
    {
        private Marr load; //массив загрузки по предметам

        public Lecturer(string fam, string status, int god, Marr load) :
    base(fam, status, god)
        {
            this.load = load;
        }

        public Marr GetLoad()
        {
            return load;
        }

        //сведения для преподавателя это общая нагрузка
        public override string Svedenija()
        {
            return $"нагрузка (в часах): {load.GetSum()}";
        }
    }
}
