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

    class Program
    {
        public static void Main(string[] args)
        {

            LecturerCollection lc = new LecturerCollection();
            lc.AddDefaults();
            Console.WriteLine(lc.ToShortString());
            lc.SortToName();
            Console.WriteLine("Сортировка по фамилии \n" + lc.ToShortString());
            lc.SortToDate();
            Console.WriteLine("Сортировка по дате \n" + lc.ToShortString());
            lc.SortToRate();
            Console.WriteLine("Сортировка по рейтингу \n" + lc.ToShortString());

        }
    }
}
