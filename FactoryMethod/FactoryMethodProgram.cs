using System;
using System.Collections.Generic;
using System.Transactions;

namespace Factory
{
    public class Player
    {
        private List<Item> _inventory;

        public Player()
        {
            _inventory = new List<Item>();
        }

        public void RequestItem(ICraftsman craftsman, string name, double weight, int value)
        {
            _inventory.Add(craftsman.CraftItem(name, weight, value));
        }

        public void PrintItems()
        {
            foreach (var item in _inventory)
            {
                Console.Write($"Name: {item.GetName()}, weight: {item.GetWeight()}");
                if (item is Sword sword)
                {
                    Console.WriteLine($" Type: Sword, damage: {sword.GetDamage()}");
                } else if (item is Armor armor)
                {
                    Console.WriteLine($" Type: Armor, protection: {armor.GetProtection()}");
                }
            }
        }
    }
    
    public interface ICraftsman
    {
        public Item CraftItem(string name, double weight, int value);
    }

    public class Armorer : ICraftsman
    {
        public Item CraftItem(string name, double weight, int protection)
        {
            return new Armor(name, weight, protection);
        }
    }

    public class Blacksmith : ICraftsman
    {
        public Item CraftItem(string name, double weight, int damage)
        {
            return new Sword(name, weight, damage);
        }
    }

    public class Item
    {
        private string _name;
        private double _weight;

        public Item(string name, double weight)
        {
            _name = name;
            _weight = weight;
        }

        public string GetName()
        {
            return _name;
        }

        public double GetWeight()
        {
            return _weight;
        }
    }

    public class Armor : Item
    {
        private int _protection;

        public Armor(string name, double weight, int protection) : base(name, weight)
        {
            _protection = protection;
        }

        public int GetProtection()
        {
            return _protection;
        }
    }

    public class Sword : Item
    {
        private int _damage;
        public Sword(string name, double weight, int damage) : base(name, weight)
        {
            _damage = damage;
        }

        public int GetDamage()
        {
            return _damage;
        }
    }
    class FactoryMethodProgram
    {
        static void Main(string[] args)
        {
            ICraftsman blacksmith = new Blacksmith();
            ICraftsman armorer = new Armorer();
            Player player = new Player();
            player.RequestItem(blacksmith, "Silver Fang", 2.2, 60);
            player.RequestItem(armorer, "Paladium plate", 11.25, 120);
            player.PrintItems();
        }
    }
}