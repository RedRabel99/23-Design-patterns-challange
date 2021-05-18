using System;

namespace Prototype
{
    public abstract class Weapon
    {
        public abstract Weapon Clone();
    }

    public class Bow : Weapon
    {
        private int _damage;
        private double _attackSpeed;

        public Bow(int damage, double attackSpeed)
        {
            _damage = damage;
            _attackSpeed = attackSpeed;
        }

        public override Weapon Clone()
        {
            return (Bow) this.MemberwiseClone();
        }

        public int GetDamage()
        {
            return _damage;
        }

        public double GetAttackSpeed()
        {
            return _attackSpeed;
        }

    }
    class PrototypeProgram
    {
        static void Main(string[] args)
        {
            Weapon bow = new Bow(50, 1.5);
            Weapon clone = bow.Clone();

            if (bow is Bow firstBow)
            {
                Console.WriteLine($"First bow damage: {firstBow.GetDamage()}, AS: {firstBow.GetAttackSpeed()}");
            }

            if (clone is Bow cloneBow)
            {
                Console.WriteLine($"Cloned bow damage: {cloneBow.GetDamage()}, AS: {cloneBow.GetAttackSpeed()}");
            }
        }
    }
}