using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Journal
    {
        private List<JournalEntry> journal;
        public Journal()
        {
            journal = new List<JournalEntry>();
        }
        public override string ToString()
        {
            int i = 0;
            string rb = "";
            foreach(JournalEntry p in journal)
            {
                rb += journal[i].ToString() + "\n";
                i++;
            }
            return rb;
        }
    }
}
