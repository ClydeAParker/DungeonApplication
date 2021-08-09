using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesLibrary;

namespace Dungeon
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Wizardly World of Harry Potter!";
            Console.WriteLine("Now Your Story...begins!");    
            int score = 0;
          
            Weapon wand = new Weapon(1, 8, "Wizards Wand", 10, false);
            Player player = new Player("Young Wizard", 70, 5, 40, 40, Race.Male, wand);      

            bool exit = false;
            do
            {              
                Dementor r1 = new Dementor();
                Dementor r2 = new Dementor("Dementor", 25, 25, 50, 20, 2, 8, "Be careful everyone! We have a Dementor approaching", true);
                Basilisk v1 = new Basilisk("Basilisk", 20, 20, 35, 25, 1, 14, "Everyone eyes up! We have to take on a Basilisk!");                
                Monster[] monsters = { r1, r2, v1 };                           
                Console.WriteLine(GetRoom());               
                Random rand = new Random();
                int randNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randNbr];               
                Console.WriteLine("\nIn this place, awaits a " + monster.Name);
                bool reload = false;
                do
                {                  
                    #region Menu
                    Console.Write("\nMake your choice:\n" +
                        "C) Cast Spell\n" +
                        "A) Apparition\n" +
                        "W) Wizard Info\n" +
                        "M) Monster Info\n" +
                        "E) Exit\n");
                   
                    ConsoleKey userChoice = Console.ReadKey(true).Key;                    
                    Console.Clear();                    
                    switch (userChoice)
                    {
                        case ConsoleKey.C:
                            Console.WriteLine("Cast Spell");
                           
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {                               
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou stupified {0}!\n",
                                    monster.Name);
                                Console.ResetColor();                                
                                reload = true;                                
                                score++;
                            }
                            break;
                        case ConsoleKey.A:
                            Console.WriteLine("Apparition");                           
                            Console.WriteLine($"{monster.Name} tries to kill but you manage to apparition just in time.");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;
                            break;
                        case ConsoleKey.W:
                            Console.WriteLine("Wizard Info");                                                    
                            Console.WriteLine(player);
                            Console.WriteLine("Wizard Info");
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");                      
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("On to wave a wand another day.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("STUPIFY! Yeah you didn't change.");
                            break;
                    }
                    #endregion
               
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("YOU DIED");
                        Console.WriteLine($"You vanquished {score} beasts during your game!");
                        exit = true;
                    }
                } while (!exit && !reload);
            } while (!exit);
            Console.WriteLine("You defeated " + score + " beasts" + (score == 1 ? "." : "s."));
        }
     
        private static string GetRoom()
        {            
            string[] rooms =
            {
                "You make your way into in undiscovered room in the school with your classmates. The mood of the room seems very depressive and offset. You turn a corner to reveal a bigger part of the room then you realise...",
                "You decided to sneek out of class with a friend to explore the school. Your friend hears a voice and beckons you to follow. You both enter a classroom that has never used and freeze in shock...",
                 "It is 2a.m. You hear a strange noise come from somwhere within the school. It was faint, but ominus. You step out of your room, while everyone else is asleep, and start looking up and down the hallways. You then starteled by 2 of your classmates who heard the noise as well and wanted to investigate as you are. " +
                 "All of you head toward where you expect the sound came from. It is near the center of the entire school. As the group approaches you all think you are getting close when you hear the sound again, but this time it is much closer and sends chills down each of your spines and you are filled with fear. But curiosity appears stronger than fear in most cases so you continue until you find a room. It is a cube. Made of black marble. It has one entrance. A Black Door. The door has a lock spell on it. It just so happens you know the spell because you happened to see a professor use the spell once. You cast the spell, the door bolts open extremely fast. It went from completely closed to open within a milisecond. The wind coming off the door makes you close your eyes, but when you open them..."   
            };
            
            Random rand = new Random();           
            int indexNbr = rand.Next(rooms.Length);            
            string room = rooms[indexNbr];           
            return room;
        }
    
    }
}
