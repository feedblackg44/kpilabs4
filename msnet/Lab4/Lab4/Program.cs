using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Initializer initializer = new Initializer();
            Explorer explorer = new Explorer(initializer.CreateDefaultHierarchy());
            Console.WriteLine("ls\n");
            Console.WriteLine(explorer.Active.Info());
            Console.WriteLine("\nopen Study\nls\n");
            Console.WriteLine(explorer.Open("Study"));
            Console.WriteLine("\nopen StudyMusic");
            Console.WriteLine(explorer.Open("StudyMusic"));
            Console.WriteLine("ls\n");
            Console.WriteLine(explorer.Active.Info());
            explorer.Back();
            Console.WriteLine("\nback\nls\n");
            Console.WriteLine(explorer.Active.Info());
            Console.WriteLine("\nopen Work\nls\n");
            Console.WriteLine(explorer.Open("Work"));
            Console.WriteLine("\ncreateFolder test\nls\n");
            explorer.CreateFolder("test");
            Console.WriteLine(explorer.Active.Info());
            Console.WriteLine("\ncreateFolder test2\nls\n");
            explorer.CreateFolder("test2");
            Console.WriteLine(explorer.Active.Info());
            Console.WriteLine("\nopen test\nls\n");
            Console.WriteLine(explorer.Open("test"));
            Console.WriteLine("\ncreateFile testFile.txt\nls\n");
            explorer.CreateFile("testFile", "txt");
            Console.WriteLine(explorer.Active.Info());
            explorer.Back();
            Console.WriteLine("\nback\nls\n");
            Console.WriteLine(explorer.Active.Info());
            Console.WriteLine("\ndelete test\nls\n");
            explorer.Delete("test");
            Console.WriteLine(explorer.Active.Info());
            explorer.Back();
            Console.WriteLine("\nback\nls\n");
            Console.WriteLine(explorer.Active.Info());
            Console.ReadKey();
        }
    }
}