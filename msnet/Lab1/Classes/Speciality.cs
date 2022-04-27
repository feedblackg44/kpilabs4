using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Speciality
    {
        private int _number;
        private string _name;

        public int Number { get => _number; }
        public string Name { get => _name; }
        
        public Speciality(int number, string name)
        {
            _number = number;
            _name = name;
        }
    }
}
