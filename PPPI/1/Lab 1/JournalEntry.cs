using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class JournalEntry
    {
        public string nameCollectionEvent { get; set; }
        public string typeChangeOnCollection { get; set; }
        public Lecturer objLecture { get; set; }

        public JournalEntry()
        {
            nameCollectionEvent = "";
            typeChangeOnCollection = "";
            objLecture = new Lecturer();
        }
        public override string ToString()
        {
            return nameCollectionEvent + " " + typeChangeOnCollection + " " + objLecture;
        }
    }
}
