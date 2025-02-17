using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRPGDemo
{
    internal class NPC : Player
    {
        public enum Races { orc, elf, dwarf, human }
        public Races Race { set; get; } // needed to make this public when I wrote data to file

        // Notice that the properties are not included in the child class.
        // This is because they are inherited from the parent class.
        // Equipment could also be used in this class.
        // The equipment could also be used.  (And probably should be.)
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
        // TakeDamaage() and Dead() are inherited from Player
        // so they are not necessary in this child class.

        //public int TakeDamage(int lower)
        //{
        //    Health -= lower;
        //    return Health;
        //}
        //public bool Dead()
        //{
        //    if (Health <= 0)
        //    {
        //        Health = 0;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public override string ToString()
        {
            return Name + ", your stats:\n\tHealth: " + Health
                + "\n\tDamage: " + Damage;
        }

    }
}
