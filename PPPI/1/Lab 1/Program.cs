using System;
using System.Diagnostics;
using System.Threading;
namespace Lab_2
{
    enum Post
    {
        Assistant,
        AssociateProfessor,
        Professor
    }
    class Theme
    {
        public string thesis { get; set; }
        public bool select { get; set; }
        public Theme() { thesis = "Game"; select = true; }
        public Theme(string thesis, bool select) { this.thesis = thesis; this.select = select; }
        public override string ToString()
        {
            return thesis + " " + select;
        }
        public virtual object DeepCopy()
        {
            Theme th = new Theme(thesis, select);
            return th;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {

            LecturerCollection firstLc = new LecturerCollection("First Lecturer");

            LecturerCollection secondLc = new LecturerCollection("Second Lecturer");

            Journal firstJl = new Journal();

            firstLc.LecturersCountChanged += firstJl.LecturersCountChanged;
            firstLc.LecturersReferenceChanged += firstJl.LecturersReferenceChanged;

            Journal secondJl = new Journal();



            firstLc.LecturersReferenceChanged += secondJl.LecturersReferenceChanged;
            secondLc.LecturersReferenceChanged += secondJl.LecturersReferenceChanged;

            firstLc.AddDefaults();
            firstLc.AddLecturers(new Lecturer());
            firstLc.Remove(0);
            firstLc[0] = new Lecturer(new Person("Pavel", "Ivanov", new DateTime(2000, 06, 5)), "FPM", Post.Assistant, 8);

            secondLc.AddDefaults();
            secondLc.AddLecturers(new Lecturer());
            secondLc.Remove(0);
            //secondLc[0] = new Lecturer(new Person("Pavel", "Ivanov", new DateTime(2000, 06, 5)), "FPM", Post.Assistant, 8);

            Console.WriteLine("First Journal: \n" + firstJl.ToString() + "\n");

            Console.WriteLine("Second journal: \n" + secondJl.ToString() + "\n");

            Console.ReadLine();

        }
    }
}
