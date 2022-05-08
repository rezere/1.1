using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class LecturerCollection
    {
        public delegate void LecturertListHandler(object source, LecturerListHandlerEventArgs args);
        
        public  LecturertListHandler LecturersCountChanged;
        public event LecturertListHandler LecturersReferenceChanged;

        private List<Lecturer> lecturers;
        public string nameCollection { get; set; }

        public LecturerCollection(string name) 
        { 
            lecturers = new List<Lecturer>();
            nameCollection = name;
        }
        public Lecturer this[int index]
        {
            get => lecturers[index];
            set
            {
                lecturers[index] = value;
                LecturersReferenceChanged?.Invoke(this, new LecturerListHandlerEventArgs(nameCollection, " ", lecturers[index]));
            }
        }

        public void AddDefaults()
        {
            for (int i = 0; i < 3; i++)
            {
                lecturers.Add(new Lecturer(new Person("Andrey", "Petrov", new DateTime(2000, 06, 08)), "FPM", Post.Assistant, 8));
                LecturersCountChanged?.Invoke(this, new LecturerListHandlerEventArgs(nameCollection, "Added item of collection! AddDefaults()", lecturers[i]));
            }
        }
        public void AddLecturers(params Lecturer[] parameters)
        {
            lecturers.AddRange(parameters);
            LecturersCountChanged?.Invoke(this, new LecturerListHandlerEventArgs(nameCollection, "Added item of collection! AddLecturers()", lecturers[lecturers.Count-1]));
        }
        public bool Remove(int j)
        {
            if(j >= 0 && j < lecturers.Count)
            {
                LecturersCountChanged?.Invoke(this, new LecturerListHandlerEventArgs(nameCollection, "Successful delete item of collection!", lecturers[j]));
                lecturers.RemoveAt(j);
                return true;
            }
            LecturersCountChanged?.Invoke(this, new LecturerListHandlerEventArgs(nameCollection, "Unsuccessful delete item of collection!", lecturers[lecturers.Count-1]));
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
