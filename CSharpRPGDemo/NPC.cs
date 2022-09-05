using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRPGDemo
{
    internal class NPC
    {
        public enum Races { orc, elf, dwarf, human }
        public String Name { set; get; }
        public int Health { set; get; }
        public int Damage { set; get; }
        Races Race { set; get; }
        public NPC()
        {
            Random rng = new Random();
            Name = "";
            Health = rng.Next(5, 11);
            Damage = rng.Next(5, 11);
            Race = (Races)rng.Next(4);
        }
        public NPC(string name, int health, int damage, Races race)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Race = race;
        }
    }
}
