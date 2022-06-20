using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Enums;

namespace Lab3
{
    public class Bus : Car
    {
        public decimal Money { get; set; } = 0;
        public IReadOnlyDictionary<BenefitType, decimal> Prices { get; } = new Dictionary<BenefitType, decimal>() {
            { BenefitType.None, 10.0m },
            { BenefitType.Special, 5.0m },
            { BenefitType.Child, 2.0m }
        };
    }
}
