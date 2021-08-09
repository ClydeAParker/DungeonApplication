using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Dementor : Monster
    {
        public bool IsFluffy { get; set; }
        public Dementor(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isFluffy) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsFluffy = isFluffy;
        }        
        public Dementor()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Dark Dementor";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "You! Keep up your offence, but stay on defense.";
            IsFluffy = false;
        }
       
        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "Dark" : "But not to dark...");
        }
       
        public override int CalcBlock()
        {            
            int calculatedBlock = Block;
            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;                
            }
            return calculatedBlock;
        }
    }
}
