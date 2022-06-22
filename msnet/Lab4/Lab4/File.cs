using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class File : Component
    {
        public string Extension { get; set; } = "txt";
        public override int Size { get; } = 1024;
        public override string Name { get; set; } = "New File";
        public override string Info(int spaces = 0)
        {
            return string.Format("Файл \"{0}.{1}\" размером {2} байт.",
                                 Name, Extension, Size);
        }
    }
}
