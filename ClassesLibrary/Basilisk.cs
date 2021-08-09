using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Basilisk : Monster
    {
        public DateTime HourChangeBack { get; set; }
       
        public Basilisk(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HourChangeBack = DateTime.Now;

            if (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18)
            {
                HitChance += 10;
                Block += 10;
                MinDamage += 1;
                MaxDamage += 2;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}\n{1}", base.ToString(), HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18 ? "It looks likes its under a spell!" : "In the sunshine we should be untouchable!");
        }
    }
}
