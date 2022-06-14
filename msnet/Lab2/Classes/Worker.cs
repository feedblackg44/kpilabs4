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
    }
}
