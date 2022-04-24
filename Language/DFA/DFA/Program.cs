using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFA
{
    class Program
    {
        static string[] alphabet;
        static int start;
        static int[] ends;
        static int[][] moving;

        static void Main(string[] args)
        {
            string parsFile = "E:/1.1/Language/values.csv";
            ParsFile(parsFile);
            int currentState = start;
            Console.WriteLine( "Start " + start);
            for (int i = 0; i < ends.Length; i++)
            {
                Console.WriteLine("Finish " + ends[i]);
            }
            Console.WriteLine("Alphabet ");
            for (int i = 0; i < alphabet.Length; i++)
            {
                Console.WriteLine(alphabet[i]);
            }
            while (true)
            {
                currentState = start;
                Console.Write("Input the string: ");
                string str = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < str.Length; i++)
                {
                    int symbol = Convert.ToInt32(str[i].ToString());
                    currentState = moving[currentState][symbol];
                }
                bool result = false;
                for (int i = 0; i < ends.Length; i++)
                {
                    if (ends[i] == currentState) result = true;
                }
                if (result) Console.WriteLine("Accept");
                else Console.WriteLine("Reject");
                Console.WriteLine();
                Console.ReadKey(true);
            }
        }

        static void ParsFile(string file)
        {
            int lineCounter = 0;
            using (StreamReader streamReader = new StreamReader(file, Encoding.Default))
            {
                string line;
                while (true)
                {
                    line = streamReader.ReadLine();
                    if(line!=null) lineCounter++;
                    else break;
                }
            }
            moving = new int[lineCounter - 3][];
            using (StreamReader streamReader = new StreamReader(file, Encoding.Default))
            {
                string line;
                int row = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (row == 0) alphabet = line.Split(',');
                    else if (row == 1) start = Int32.Parse(line);
                    else if (row == 2)
                    {
                        string[] endsInFile = line.Split(',');
                        ends = new int[endsInFile.Length];
                        for (int i = 0; i < ends.Length; i++)
                        {
                            ends[i] = Int32.Parse(endsInFile[i]);
                        }
                    }
                    else
                    {
                        string[] movings = line.Split(',');
                        moving[Convert.ToInt32(movings[0])] = new int[alphabet.Length];
                        for (int i = 0; i <= alphabet.Length - 1; i++)
                        {
                            moving[Convert.ToInt32(movings[0])][i] = Convert.ToInt32(movings[i+1]);
                        }
                    }
                    row++;
                }
            }
        }
    }
}
