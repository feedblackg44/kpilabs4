using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
    public enum EduLevel
    {
        None = 0,
        Middle = 1,
        High = 2
    }
    public static class Tools
    {
        public static Dictionary<EduLevel, String> ruEduLevel = new Dictionary<EduLevel, string>()
        {
            { EduLevel.High, "Высшее" },
            { EduLevel.Middle, "Среднее" },
            { EduLevel.None, "Без образования" }
        };
        public static EduLevel EduParse(string str)
        {
            Enum.TryParse<EduLevel>(str, out EduLevel key);
            return key;
        }
    }
}
