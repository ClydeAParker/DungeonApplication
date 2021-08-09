using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Combat
    {        
        public static void DoAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(500);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {            
                int damageDealt = attacker.CalcDamage();
                
                defender.Life -= damageDealt;
               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} casts an attack at the {1} for {2} spell damage!",
                    attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{attacker.Name} just happened to miss, stay on your guard!");
            }
        }

        public static void DoBattle(Player player, Monster monster)
        {
            
            DoAttack(player, monster);

            
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
