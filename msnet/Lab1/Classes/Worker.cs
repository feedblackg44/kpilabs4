using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public enum EduLevel 
    { 
        None = 0,
        Middle = 1,
        High = 2
    }
    public class Worker
    {
        private string _name;
        private string _surname;
        private string _patronymic;
        private DateTime _birthdate;
        private static uint idCounter = 0;
        private uint _personnelId;
        private uint _cardnum;
        private EduLevel _education;
        private string _speciality;
        private DateTime _workStartDate;

        public string Name { get => _name; }
        public string Surname { get => _surname; }
        public string Patronymic { get => _patronymic; }
        public DateTime Birthdate { get => _birthdate; }
        public uint PersonnelId { get => _personnelId; }
        public uint Cardnum { get => _cardnum; }
        public EduLevel Education { get => _education; }
        public string Speciality { get => _speciality; }
        public DateTime WorkStartDate { get => _workStartDate; }
        
        public Worker(string name, string surname, string patronymic, DateTime birthdate, uint cardnum, EduLevel education, string speciality, DateTime workStartDate) 
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _birthdate = birthdate;
            _cardnum = cardnum;
            idCounter++;
            _personnelId = idCounter;
            _education = education;
            _speciality = speciality;
            _workStartDate = workStartDate;
        }
    }
}
