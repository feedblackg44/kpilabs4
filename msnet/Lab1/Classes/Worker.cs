using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Worker
    {
        private string _name;
        private string _surname;
        private string _patronymic;
        private DateTime _birthdate;
        private static int idCounter = 0;
        private int _personnelId;
        private int _cardnum;
        private EduLevel _education;
        private DateTime _workStartDate;

        public string Name { get => _name; }
        public string Surname { get => _surname; }
        public string Patronymic { get => _patronymic; }
        public string FullName 
        {
            get => _surname + " " +
                   _name + " " +
                   _patronymic;
        }
        public DateTime Birthdate { get => _birthdate; }
        public int PersonnelId { get => _personnelId; }
        public int Cardnum { get => _cardnum; }
        public EduLevel Education { get => _education; }
        public DateTime WorkStartDate { get => _workStartDate; }
        
        public Worker(string name, string surname, string patronymic, 
                      DateTime birthdate, int cardnum, 
                      EduLevel education, DateTime workStartDate) 
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _birthdate = birthdate;
            _cardnum = cardnum;
            idCounter++;
            _personnelId = idCounter;
            _education = education;
            _workStartDate = workStartDate;
        }
        public override string ToString()
        {
            int multiplier = 10;
            string curEdu = Tools.ruEduLevel(this._education);
            string toPrint = string.Format(
                new String('-', multiplier) +
                " Работник номер {0} " +
                new String('-', multiplier) +
                "\nФИО: {1} {2} {3}." +
                "\nДата рождения: {4}." +
                "\nОбразование: {5}." +
                "\nРаботает с: {6}.",
                this._personnelId, this._surname, this._name, 
                this._patronymic, this._birthdate.ToShortDateString(), 
                curEdu, this._workStartDate.ToShortDateString());
            return toPrint;
        }
    }
}
