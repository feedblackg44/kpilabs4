using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Enums;

namespace Lab3
{
    public class Passenger : Person
    {
        public BenefitType Benefit { get; set; }
        public override string ToString()
        {
            return string.Format("Имя: {0}. Фамилия: {1}. Возраст: {2}. Тип льготы: {3}", Name, Surname, Age, Benefit);
        }
    }
}
