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
 *              -- GS 07-06 --
 *              enum and classes added
 *              Non-Player Character (NPC) class added.
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
            //String equipmentName = "";

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
                    //equipmentName = SetEquipmentName(equipment);
                    Console.WriteLine("A " + (Player.Equipment)equipment + " is a great choice");
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

            Player P = new Player(name, health, damage, (Player.Equipment) equipment);
            P.ShowStats();

            bool exit = false;
            int location = 0;
            int timesThrough = 0;

            do
            {
                //char choice;
                if (location == 0)
                {
                    location = Room0(location, ref P);
                    if (P.Dead())
                    {
                        exit = true;
                    } 
                }
                else if (location == 1)
                {
                    location = Room1(location, ref P, ref timesThrough);

                }
                else if (location == 2)
                {
                    Console.WriteLine("This is room " + location);
                    P = Room2(P);
                    Console.WriteLine(P.Dead() + "Equip: " + P.E);
                    if (!P.Dead() && P.E != Player.Equipment.pencil)
                    {
                        Console.WriteLine("You must go back to the first room to study harder.");
                        location = 0;
                    }
                    else
                    {
                        exit = true;
                    }
                }
                Console.WriteLine(P);
            } while (!exit);
            Console.WriteLine("Final Stats:\n");
            Console.WriteLine(P);
            if (!P.Dead())
            {
                Console.WriteLine("Way to go!  You passed all the competency tests!");
            }
            else
            {
                Console.WriteLine("You need to study more.  Better luck next time.");
            }
        }
 
        static int Room0(int location, ref Player P)
        {
            char choice;
            Console.WriteLine("This is room " + location);
            NPC npc = new NPC();
            Console.WriteLine("You met " + npc.Name);
            Console.WriteLine("You must defeat " + npc.Name + " to continue.");
            bool win = false;
            do
            {
                win = Conflict(ref P, ref npc);
                Console.WriteLine(P);
                Console.WriteLine(npc);
            } while (!win && !npc.Dead());
            if (P.Dead())
            {
                return location;
            }
            Console.Write("Would you like to go to the second room? (Y/N) >> ");
            choice = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
            if (choice == 'Y')
            {
                location = 1;
            }
            else if (P.Health < 10)
            {
                P.Health++;
                Console.WriteLine("You increased your health.");
            }
            return location;
        }

        static int Room1(int location, ref Player P, ref int timesThrough)
        {
            char choice;
            Console.WriteLine("This is room " + location);
            if (P.E != Player.Equipment.pencil)
            {
                Console.WriteLine("You found a pencil.");
                Console.Write("Would you like to trade your " + P.E
                    + " for a pencil? (Y/N) >> ");
                choice = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
                if (choice == 'Y')
                {
                    P.E = Player.Equipment.pencil;
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

        static Player Room2(Player P)
        {
            Console.WriteLine("I see that you brought a " + P.E 
                + " to take your final competency test.");
            if (P.E == Player.Equipment.pencil)
            {
                Console.WriteLine("Very good.  You will need it to complete your task.");
            }
            else
            {
                Console.WriteLine("Too bad.  You will need a pencil to complete your task.");
                P.TakeDamage(3);
            }
            return P;
        }

        static bool Conflict(ref Player P, ref NPC npc)
        {
            Random rng = new Random();
            P.TakeDamage(rng.Next(3));
            npc.TakeDamage(rng.Next(1, 4));

            if(P.Dead() || npc.Dead())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}