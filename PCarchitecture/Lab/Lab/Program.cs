using System;
using System.IO;

namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line;
            DateTime dateCreate = new DateTime(2010, 3, 16);
            DateTime dateLastWrite = new DateTime(2010, 3, 16);
            met:
            Console.WriteLine(" Vvedite put");
            line = Console.ReadLine(); //E:\1.1\test\2.txt
            string[] subs = line.Split(';');
            if (subs[0] == "/help")
            {
                Console.WriteLine("path;.type file; attributes");
                Console.WriteLine("E:/1.1/test/;.exe; h");
                goto met;
            }
            string[] dirs = Directory.GetFiles(subs[0]);
            string extension;
            foreach (string dir in dirs)
            {
                if(subs.Length>1)
                {
                    extension = Path.GetExtension(dir);
                    if (subs[1][0] == '.')
                    {
                        if (subs.Length == 2)
                        {
                            if (extension == subs[1])
                            {
                                Console.WriteLine("txt");
                                System.IO.File.SetCreationTime(dir, dateCreate);
                                System.IO.File.SetLastWriteTime(dir, dateLastWrite);
                            }
                        }
                        if (subs.Length == 3)
                        {
                            FileAttributes attributes = File.GetAttributes(dir);
                            for (int i = 0; i < subs[2].Length; i++)
                            {
                                if (subs[2][i] == 'a')
                                {
                                    if ((attributes & FileAttributes.Archive) == FileAttributes.Archive)
                                    {
                                        System.IO.File.SetCreationTime(dir, dateCreate);
                                        System.IO.File.SetLastWriteTime(dir, dateCreate);
                                    }
                                }
                                if (subs[2][i] == 'h')
                                {
                                    if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                                    {
                                        Console.WriteLine("attributes and format");
                                        System.IO.File.SetCreationTime(dir, dateCreate);
                                        System.IO.File.SetLastWriteTime(dir, dateCreate);
                                    }
                                }
                                if (subs[2][i] == 'r')
                                {
                                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                    {
                                        System.IO.File.SetCreationTime(dir, dateCreate);
                                        System.IO.File.SetLastWriteTime(dir, dateCreate);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("attributes");
                        FileAttributes attributes = File.GetAttributes(dir);
                        for (int i = 0; i < subs[1].Length; i++)
                        {
                            if (subs[1][i] == 'a')
                            {
                                if ((attributes & FileAttributes.Archive) == FileAttributes.Archive)
                                {
                                    System.IO.File.SetCreationTime(dir, dateCreate);
                                    System.IO.File.SetLastWriteTime(dir, dateCreate);
                                }
                            }
                            if (subs[1][i] == 'h')
                            {
                                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                                {
                                    Console.WriteLine("attributes and format");
                                    System.IO.File.SetCreationTime(dir, dateCreate);
                                    System.IO.File.SetLastWriteTime(dir, dateCreate);
                                }
                            }
                            if (subs[1][i] == 'r')
                            {
                                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                {
                                    System.IO.File.SetCreationTime(dir, dateCreate);
                                    System.IO.File.SetLastWriteTime(dir, dateCreate);
                                }
                            }
                        }
                    }
                }
                else 
                {
                    Console.WriteLine("all");
                    System.IO.File.SetCreationTime(dir, dateCreate);
                    System.IO.File.SetLastWriteTime(dir, dateCreate);
                }
            }
        }
    }
}