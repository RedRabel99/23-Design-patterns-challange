using System;

namespace AbstractFactory
{
    public interface IForge
    {
        public IWeapon CraftWeapon();
        public IArmor CraftArmor();
    }

    public class ElvenForge : IForge
    {
        public ElvenForge()
        {
            Console.WriteLine("Building Elven Forge");
        }

        public IWeapon CraftWeapon()
        {
            Console.WriteLine("Crafting Elven Sword..");
            return new ElvenSword();
        }

        public IArmor CraftArmor()
        {
            Console.WriteLine("Crafting Elven Armor");
            return new ElvenArmor();
        }
    }

    public class DwarvenForge : IForge
    {
        public DwarvenForge()
        {
            Console.WriteLine("Building Dwarven Forge");
        }

        public IWeapon CraftWeapon()
        {
            Console.WriteLine("Crafting Dwarven Axe...");
            return new DwarvenAxe();
        }

        public IArmor CraftArmor()
        {
            Console.WriteLine("Crafting Dwarven Armor..");
            return new DwarvenArmor();
        }
    }

    public interface IWeapon
    {
        public void Equip();
    }

    public interface IArmor
    {
        public void Equip();
    }

    public class ElvenSword : IWeapon
    {
        public ElvenSword()
        {
            Console.WriteLine("Elven Sword has been crafted");
        }

        public void Equip()
        {
            Console.WriteLine("Elven Sword has been equipped");
        }
    }
    
    public class DwarvenAxe : IWeapon
    {
        public DwarvenAxe()
        {
            Console.WriteLine("Dwarven Axe has been crafted");
        }

        public void Equip()
        {
            Console.WriteLine("Dwarven Axe has been equipped");
        }
    }
    
    public class ElvenArmor : IArmor
    {
        public ElvenArmor()
        {
            Console.WriteLine("Elven Armor has been crafted");
        }

        public void Equip()
        {
            Console.WriteLine("Elven Armor has been equipped");
        }
    }
    
    public class DwarvenArmor : IArmor
    {
        public DwarvenArmor()
        {
            Console.WriteLine("Dwarven Armor has been crafted");
        }

        public void Equip()
        {
            Console.WriteLine("Dwarven Armor has been equipped");
        }
    }
    
    class AbstractFactoryProgram
    {
        static void Main(string[] args)
        {
            IForge elvenForge = new ElvenForge();
            IWeapon elvenSword = elvenForge.CraftWeapon();
            IArmor elvenArmor = elvenForge.CraftArmor();

            IForge dwarvenForge = new DwarvenForge();
            IWeapon dwarvenAxe = dwarvenForge.CraftWeapon();
            IArmor dwarvenArmor = dwarvenForge.CraftArmor();
            
            dwarvenArmor.Equip();
            elvenSword.Equip();

        }
    }
}