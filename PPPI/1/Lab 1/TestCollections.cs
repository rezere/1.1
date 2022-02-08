using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class TestCollections
    {
        public List<Person> listPerson;
        private List<string> listString;
        private Dictionary<Person, Lecturer> dictPerson;
        private Dictionary<string, Lecturer> dictString;

        public TestCollections(int size)
        {
            listPerson = new List<Person>();
            dictPerson = new Dictionary<Person, Lecturer>();
            listString = new List<string>();
            dictString = new System.Collections.Generic.Dictionary<string, Lecturer>();
            for (int i = 0; i < size; i++)
            {
                listPerson.Add(GetLecturer(i).Person);
                listString.Add(GetLecturer(i).ToString());
                dictPerson.Add(GetLecturer(i).Person, GetLecturer(i));
                dictString.Add(GetLecturer(i).Person.ToString(), GetLecturer(i));
            }
        }
        static public Lecturer GetLecturer(int value)
        {
            return new Lecturer(new Person(value.ToString(),value.ToString(), new DateTime(DateTime.Now.Year, 6, 18)),value.ToString(),Post.Assistant,value);
        }
        public void CheckTime(int value)
        {

            var myStopwatch = new System.Diagnostics.Stopwatch();
            value--;
            Lecturer temp = GetLecturer(value);
            myStopwatch.Start();
            if (!listPerson.Contains(temp.Person))
            {
                Console.WriteLine("Данного елемента нет");
            }
            myStopwatch.Stop();
            Console.WriteLine("Время поиска в колекции Person = " + myStopwatch.ElapsedTicks);
            myStopwatch.Reset();
            myStopwatch.Start();
            if (!listString.Contains(temp.ToString()))
            {
                Console.WriteLine("Данного елемента нет");
            }
            myStopwatch.Stop();
            Console.WriteLine("Время поиска в колекции string = " + myStopwatch.ElapsedTicks);

            myStopwatch.Reset();
            myStopwatch.Start();
            if (!dictPerson.ContainsKey(temp.Person))
            {
                Console.WriteLine("Данного елемента нет");
            }
            myStopwatch.Stop();
            Console.WriteLine("Время поиска в колекции Person, Lecturer по ключу = " + myStopwatch.ElapsedTicks);
            myStopwatch.Reset();
            myStopwatch.Start();

            if (!dictString.ContainsKey(temp.Person.ToString()))
            {
                Console.WriteLine("Данного елемента нет");
            }
            myStopwatch.Stop();
            Console.WriteLine("Время поиска в колекции string, Lecturer по ключу = " + myStopwatch.ElapsedTicks);
            myStopwatch.Reset();
            myStopwatch.Start();
            if (!dictString.ContainsValue(temp))
            {
                Console.WriteLine("Данного елемента нет");
            }
            myStopwatch.Stop();
            Console.WriteLine("Время поиска в колекции string, Lecturer по значению = " + myStopwatch.ElapsedTicks);

            myStopwatch.Reset();
            myStopwatch.Start();
            if (!dictPerson.ContainsValue(temp))
            {
                Console.WriteLine("Данного елемента нет");
            }
            myStopwatch.Stop();
            Console.WriteLine("Время поиска в колекции Person, Lecturer по значению = " + myStopwatch.ElapsedTicks);
        }
    }
}
