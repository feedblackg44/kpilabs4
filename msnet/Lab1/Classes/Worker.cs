using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Worker
    {   
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string FullName
        {
            get => Name + " " +
                   Surname + " " +
                   Patronymic;
        }
        public DateTime Birthdate { get; set; }
        public Guid PersonnelId { get; set; } = Guid.NewGuid();
        public int Cardnum { get; set; }
        public EduLevel Education { get; set; } = EduLevel.None;
        public DateTime WorkStartDate { get; set; }

        public override string ToString()
        {
            string curEdu = Tools.ruEduLevel[this.Education];
            string toPrint = string.Format(
                "- Работник c номером карты {0} -" +
                "\n  ФИО: {1} {2} {3}." +
                "\n  Дата рождения: {4}." +
                "\n  Образование: {5}." +
                "\n  Работает с: {6}." +
                "\n  Уникальный ID: {7}.",
                this.Cardnum, this.Surname, this.Name, 
                this.Patronymic, this.Birthdate.ToShortDateString(), 
                curEdu, this.WorkStartDate.ToShortDateString(), 
                PersonnelId.ToString());
            return toPrint;
        }
    }
}
