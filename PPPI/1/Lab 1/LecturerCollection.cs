using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class LecturerCollection
    {
        private List<Lecturer> lecturers;
        public string nameCollection { get; set; }
        delegate void LecturertListHandler(object source, LecturerListHandlerEventArgs args);
        public LecturerCollection() { lecturers = new List<Lecturer>(); }

        public void AddDefaults()
        {
            lecturers.Add(new Lecturer(new Person("Andrey", "Petrov", new DateTime(2000, 06, 10)), "FPM", Post.Assistant, 8));
            lecturers.Add(new Lecturer(new Person("Ivan", "Romanov", new DateTime(2001, 01, 20)), "FPM", Post.Professor, 5));
            lecturers.Add(new Lecturer(new Person("Petro", "Ivanov", new DateTime(1999, 11, 11)), "FPM", Post.AssociateProfessor, 1));
        }
        public void AddLecturers(params Lecturer[] parameters)
        {
            lecturers.AddRange(parameters);

        }
        public bool Remove(int j)
        {
            if(j >= 0 && j < lecturers.Count)
            {
                lecturers.RemoveAt(j);
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            string strLecturer = "";
            for (int i = 0, size = lecturers.Count(); i < size; i++)
            {
                strLecturer += lecturers[i].ToString() + "\n";
            }
            return strLecturer;
        }
        public string ToShortString()
        {
            string strLecturer = "";
            for (int i = 0, size = lecturers.Count(); i < size; i++)
            {
                strLecturer += lecturers[i].ToShortString() + "\n";
            }
            return strLecturer;
        }

        public void SortToName()
        {
            lecturers.Sort();
        }

        public void SortToDate()
        {
            Person pr = new Person();
            lecturers.Sort(pr);
        }

        public void SortToRate()
        {
            lecturers.Sort(new rateLecturer());
        }
    }
}
