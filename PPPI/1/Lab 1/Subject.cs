using System;


namespace Lab_2
{
    class Subject
    {
        public string subjectName { get; set; }
        public string cipher { get; set;}
        public int hours { get; set; }
        public Subject() { subjectName = "KPZ"; cipher = "000"; hours = -1;  }
        public Subject(string subj, string cph, int hour) { subjectName = subj; cipher = cph; hours = hour; }
        public override string ToString()
        {
            return subjectName + " "+ cipher + " "+ hours;
        }
        public virtual object DeepCopy()
        {
            Subject sb = new Subject(subjectName, cipher, hours);
            return sb;
        }
    }
}
