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
        public void LecturersCountChanged(object source, LecturerListHandlerEventArgs args)
        {
            journal.Add(new JournalEntry(args.collectionName, args.changeType, args.objLecturer));
        }

        public void LecturersReferenceChanged(object source, LecturerListHandlerEventArgs args)
        {
            journal.Add(new JournalEntry(args.collectionName, args.changeType, args.objLecturer));
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
    class JournalEntry
    {
        public string nameCollectionEvent { get; set; }
        public string typeChangeOnCollection { get; set; }
        public Lecturer objLecture { get; set; }

        public JournalEntry(string name, string type, Lecturer lc)
        {
            nameCollectionEvent = name;
            typeChangeOnCollection = type;
            objLecture = lc;
        }
        public override string ToString()
        {
            return nameCollectionEvent + " " + typeChangeOnCollection + " " + objLecture;
        }
    }
}
