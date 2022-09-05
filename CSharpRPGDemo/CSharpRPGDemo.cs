/*  Name:       Miyoshi
 *  Problem:    RPG
 *  Pseudocode: -- GS 01-04 --
 *              Output introduction to the screen
 *              -- GS 03-01 --
 *              Create Variables for health, damage, name
 *              Max and min for each
 *              Address user by name
 *  Notes:      The different parts of the RPG will be 
 *              in different branches on GitHub
 *  Maintenance Log:
 *      Date:       Done:
 *      09/05/2022  Introduction done
 *      09/05/2022  Variables
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

            Console.WriteLine(name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Damage: " + damage);
        }
    }
}