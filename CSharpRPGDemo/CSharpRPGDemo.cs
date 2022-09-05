/*  Name:       Miyoshi
 *  Problem:    RPG
 *  Pseudocode: -- GS 01-04 --
 *              Output introduction to the screen
 *              -- GS 03-01 --
 *              Create Variables for health, damage, name
 *              Max and min for each
 *              Address user by name
 *              -- GS 04-06 --
 *              Create equipment loop
 *              Create game loop
 *              -- GS 06-06 --
 *              Create functions for movement, rooms, fighting, etc.
 *              (Only really for the rooms, intro, checking health.)
 *  Notes:      The different parts of the RPG will be 
 *              in different branches on GitHub
 *  Maintenance Log:
 *      Date:       Done:
 *      09/05/2022  Introduction done
 *      09/05/2022  Variables
 *      09/05/2022  Equipment loop and game loop added
 *                  Both loops and all the branching have error checking
 */
using System;
namespace CSharpRPGDemo
{
    internal class CSharpRPGDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the RPG demo solution!");
            Console.WriteLine("You will eventually wander around a 25 room maze");
            Console.WriteLine("interacting with Non-Player Characters (NPCs).");
            Console.WriteLine("\n\nHave fun!");

            Random rng = new Random();
            int minStart = 5;
            int maxStart = 10;
            int health = minStart + rng.Next(maxStart + 1);
            int damage = rng.Next(minStart, maxStart + 1);
            Console.Write("What is your name? >> ");
            String name = Console.ReadLine();
            bool ready = false;
            int equipment = 0;
            String equipmentName = "";

            // equip loop
            do
            {
                Console.WriteLine(name + ", you may choose one item.");
                Console.WriteLine("\tA. Pencil");
                Console.WriteLine("\tB. Laptop computer");
                Console.WriteLine("\tC. Book of matches");
                Console.Write("\t>> ");
                char choice = Convert.ToChar(Console.ReadLine());
                ready = true;

                switch(choice)
                {
                    case 'A':
                    case 'a':
                        equipment = 1;
                        break;
                    case 'B':
                    case 'b':
                        equipment = 2;
                        break;
                    case 'C':
                    case 'c':
                        equipment = 3;
                        break;
                    default:
                        Console.WriteLine("You must choose something.");
                        ready = false;
                        break;
                }

                if(equipment != 0)
                {
                    equipmentName = SetEquipmentName(equipment);
                    Console.WriteLine("A " + equipmentName + " is a great choice");
                }
                if (!ready) { continue; }

                Console.Write("\n\nAre you ready to play the game? (Y/N) >> ");
                choice = Convert.ToChar(Console.ReadLine());
                choice = Char.ToUpper(choice);
                if(choice == 'N')
                {
                    ready = false;
                    Console.WriteLine("Okay.  You may choose again.");
                }
            } while (!ready);

            ShowStats(name, health, damage, equipmentName);

            bool exit = false;
            int location = 0;
            int timesThrough = 0;

            do
            {
                //char choice;
                if (location == 0)
                {
                    location = Room0(location, ref health);
                }
                if (location == 1)
                {
                    location = Room1(location, ref equipment, equipmentName, ref timesThrough);
                    equipmentName = SetEquipmentName(equipment);
                }
                else if (location == 2)
                {
                    Console.WriteLine("This is room " + location);
                    health = Room2(health, equipment, equipmentName);
                    if (TestHealth(ref health) && equipment != 1)
                    {
                        Console.WriteLine("You must go back to the first room to study harder.");
                        location = 0;
                    }
                    else
                    {
                        exit = true;
                    }
                }
                ShowStats(name, health, damage, equipmentName);
            } while (!exit);
            Console.WriteLine("Final Stats:\n");
            ShowStats(name, health, damage, equipmentName);
            if (TestHealth(ref health))
            {
                Console.WriteLine("Way to go!  You passed all the competency tests!");
            }
            else
            {
                Console.WriteLine("Better luck next time.");
            }
        }
        
        static void ShowStats(String name, int health, int damage, String equipmentName)
        {
            Console.WriteLine("Your stats so far:");
            Console.WriteLine(name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Damage: " + damage);
        }

        static String SetEquipmentName(int equipment)
        {
            switch (equipment)
            {
                case 1:
                    return "pencil";
                    break;
                case 2:
                    return "laptop computer";
                    break;
                case 3:
                    return "book of matches";
                    break;
            }
            return "";
        }

        static bool TestHealth(ref int health)
        {
            if (health <= 0)
            {
                Console.WriteLine("You lose!");
                health = 0;
                return false;
            }
            else
            {
                return true;
            }
        }

        static int Room0(int location, ref int health)
        {
            char choice;
            Console.WriteLine("This is room " + location);
            Console.Write("Would you like to go to the second room? (Y/N) >> ");
            choice = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
            if (choice == 'Y')
            {
                location = 1;
            }
            else if (health < 10)
            {
                health++;
                Console.WriteLine("You increased your health.");
            }
            return location;
        }

        static int Room1(int location, ref int equipment, String equipmentName, ref int timesThrough)
        {
            char choice;
            Console.WriteLine("This is room " + location);
            if (equipment != 1)
            {
                Console.WriteLine("You found a pencil.");
                Console.Write("Would you like to trade your " + equipmentName
                    + " for a pencil? (Y/N) >> ");
                choice = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
                if (choice == 'Y')
                {
                    equipment = 1;
                }
                else
                {
                    if (1 <= timesThrough)
                    {
                        Console.Write("Are you sure you do not want the pencil? (Y/N) >> ");
                        choice = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
                        if (choice == 'N') 
                        {
                            return location;
                        }
                    }
                }
            }

            Console.Write("Would you like to go to the third room? (Y/N) >> ");
            choice = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
            if (choice == 'Y')
            {
                location = 2;
            }
            timesThrough++;
            return location;
        }

        static int Room2(int health, int equipment, String equipmentName)
        {
            Console.WriteLine("I see that you brought a " + equipmentName 
                + " to take your final competency test.");
            if (equipment == 1)
            {
                Console.WriteLine("Very good.  You will need it to complete your task.");
            }
            else
            {
                Console.WriteLine("Too bad.  You will need a pencil to complete your task.");
                health -= 3;
            }
            return health;
        }
    }
}