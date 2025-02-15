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
            Name = "Bozo";
            Health = CSharpRPGDemo.rng.Next(5, 11);
            Damage = CSharpRPGDemo.rng.Next(5, 11);
            //Race = (Races)CSharpRPGDemo.rng.Next(4);
            Race = (Races)CSharpRPGDemo.rng.Next(Enum.GetValues(typeof(Races)).Length);
        }
        public NPC(String name) : this()
        {
            Name = name;
        }
        public NPC(string name, int health, int damage, Races race)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Race = race;
        }
        public int TakeDamage(int lower)
        {
            Health -= lower;
            return Health;
        }
        public bool Dead()
        {
            if (Health <= 0)
            {
                Health = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return Name + ", your stats:\n\tHealth: " + Health
                + "\n\tDamage: " + Damage;
        }

    }
}
