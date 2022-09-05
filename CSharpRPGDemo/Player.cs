using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRPGDemo
{
    internal class Player
    {
        public enum Equipment { none, pencil, laptop, matches}
        public String Name { set; get; }
        public int Health { set; get; }
        public int Damage { set; get; }
        public Equipment E { set; get; }
        public Player()
        {
            Random rng = new Random();
            Name = "None";
            Health = rng.Next(5, 11);
            Damage = rng.Next(5, 11);
            E = Equipment.none;
        }
        public Player(string name, int health, int damage, Equipment e)
        {
            Name = name;
            Health = health;
            Damage = damage;
            E = e;
        }

        public bool Dead()
        {
            if (Health <= 0)
            {
                Health = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ShowStats()
        {
            Console.WriteLine(Name + ", your stats:\n\tHealth: " + Health
                + "\n\tDamage: " + Damage + "\n\tEquipment: " + E);
        }
        public override string ToString()
        {
            return Name + ", your stats:\n\tHealth: " + Health
                + "\n\tDamage: " + Damage + "\n\tEquipment: " + E;
        }
    }
}
