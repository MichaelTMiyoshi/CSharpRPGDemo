/*  Name:       Miyoshi
 *  Problem:    RPG
 *  Pseudocode: Output introduction to the screen
 *              Create Variables for health, damage, name
 *              Max and min for each
 *              Address user by name
 *              Create equipment loop
 *              Create game loop
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
            int minStart = 10;
            int maxStart = 20;
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
                        equipmentName = "pencil";
                        break;
                    case 'B':
                    case 'b':
                        equipment = 2;
                        equipmentName = "laptop computer";
                        break;
                    case 'C':
                    case 'c':
                        equipment = 3;
                        equipmentName = "book of matches";
                        break;
                    default:
                        Console.WriteLine("You must choose something.");
                        ready = false;
                        break;
                }

                if(equipment != 0)
                {
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

            Console.WriteLine("Your stats so far:");
            Console.WriteLine(name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Damage: " + damage);

            bool exit = false;
            int location = 0;
            int timesThrough = 0;

            do
            {
                char choice;
                if (location == 0)
                {
                    Console.WriteLine("This is room " + location);
                    Console.Write("Would you like to go to the second room? (Y/N) >> ");
                    choice = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
                    if(choice == 'Y')
                    {
                        location = 1;
                    }
                }
                if (location == 1)
                {
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
                                if (choice == 'N') { continue; }
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
                }
                else if (location == 2)
                {
                    Console.WriteLine("This is room " + location);
                    if (equipment != 1)
                    {
                        Console.WriteLine("You do not have a pencil.  You must go back to the first room.");
                        location = 0;
                    }
                    else
                    {
                        exit = true;
                    }
                }
            } while (!exit);
            Console.WriteLine("Way to go!  You passed all the competency tests!");
       }
    }
}