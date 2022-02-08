using System;
using Lab_2;
using System.Collections.Generic;
using System.Collections;

namespace Lab_2
{
    class Lecturer:Person, IDateAndCopy, IComparable<Lecturer>
    {
        private string department;
        private Post pos;
        private int rating;
        private List<Subject> sb;
        private List<Theme> themes;
        public int allHours {  get {
                if (sb.Count > 0)
                {
                    int temp = 0;
                    foreach (Subject p in sb)
                    {
                        temp += p.hours;
                    }
                    return  temp;
                }
                else return -1;
            }

        }
        public int allThemes
        {
            get
            {
                if (themes.Count > 0)
                {
                    int temp = 0;
                    foreach (Theme p in themes)
                    {
                        temp ++;
                    }
                    return temp;
                }
                else return -1;
            }

        }
        public int rateLecture
        {
            get { return rating; }
            set
            {
                if (value <= 0 || value > 500)
                    throw new Exception("Рейтинг должен быть меньше 500 и не меньше или равен 0");
            }
        }
        public string GetDepartment { get { return department; } set { department = value; } }
        public Post GetPos { get { return pos; } set { pos = value; } }
        public int GetRating { get { return rating; } set { rating = value; } }
        public string GetSubject
        {
            get
            {
                string rb = "";
                int i = 0;
                foreach (Subject p in sb)
                {
                    rb += sb[i].ToString() + "\n";
                    i++;
                }
                return rb;
            }
            set { sb[0].subjectName = value;}

        }
        public string GetTheme
        {
            get
            {
                string rb = "";
                int i = 0;
                foreach (Theme p in themes)
                {
                    rb += themes[i].ToString() + "\n";
                    i++;
                }
                return rb;
            }
            set { themes.Add(new Theme()); }

        }
        public Person Person
        {
            get { return (Person)this; }
            set
            {
                firstName = value.GetFirstName;
                secondName = value.GetSecondName;
                dateOfBirth = value.GetDateOfBirth;
            }
        }
        public Lecturer()
        { 
            department = "FPM";
            pos = Post.Assistant;
            rating = 1;
            sb = new List<Subject>(1);
            sb.Add(new Subject());
            themes = new List<Theme>(1);
            themes.Add(new Theme());
        }
        public Lecturer(Person fullName, string department, Post pos, int ranting):base(fullName.GetFirstName, fullName.GetSecondName, fullName.GetDateOfBirth)
        {
            this.department = department;
            this.pos = pos;
            this.rating = ranting;
            sb = new List<Subject>(1);
            sb.Add(new Subject());
            themes = new List<Theme>(1);
            themes.Add(new Theme());
        }
        public override string ToShortString() { return base.ToString() + "\n Кафедра: " + department + "\n Должность: " + pos + "\n Рейтинг: " + rating + "\n Всего часов: " + allHours + "\n Всего тем: " + allThemes; }
        public override string ToString() { return base.ToString() + "\n Кафедра: " + department + "\n Должность: " + pos + "\n Рейтинг: " + rating + "\n Всего часов: " + allHours + "\n Предметы: " + GetSubject + "\n Темы ДП: " + GetTheme; }
        public void AddSubjects (params Subject[] sub)
        {
            sb.AddRange(sub);   
        }
        public override object DeepCopy()
        {
            Lecturer lc= new Lecturer((Person)this,department, pos, rating);
            for (int i = 0; i < sb.Count; i++)
            {
                lc.sb[i] = (Subject)sb[i].DeepCopy();
            }
            for (int i = 0; i < themes.Count; i++)
            {
                lc.themes[i] = (Theme)themes[i];
            }
            return lc;
        }
        DateTime IDateAndCopy.Date { get; set; }
        public IEnumerable<object> SubandTheme()
        {
            foreach (var v in sb) { yield return v; }
            foreach (var v in themes) { yield return v; }
        }
        public IEnumerable<Subject> GetHours(int max)
        {
            for (int i = 0; i < sb.Count; i++)
            {
                if (sb[i].hours<max)
                {
                    yield return sb[i];
                }
            }
        }
        public int CompareTo(Lecturer other)
        {
            return string.Compare(this.secondName, other.secondName);
        }

    }
}

