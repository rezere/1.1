using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class rateLecturer : IComparer<Lecturer>
    {
        public int Compare(Lecturer x, Lecturer y)
        {
            if (x.rateLecture < y.rateLecture)
                return 1;
            else if (x.rateLecture > y.rateLecture)
                return -1;
            else
                return 0;
        }

    }
}
