using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class WorkerSpecLink
    {
        private int _cardnum;
        private int _specnum;

        public int Cardnum { get => _cardnum; }
        public int Specnum { get => _specnum; }
        public WorkerSpecLink(int cardnum, int specnum)
        {
            _cardnum = cardnum;
            _specnum = specnum;
        }
    }
}
