using System;

namespace Prototype
{
    public abstract class Protype
    {
        public abstract Protype Clone();
    }

    public class Bow : Protype
    {
        private int _damage;
        private double _attackSpeed;

        public Bow(int damage, double attackSpeed)
        {
            _damage = damage;
            _attackSpeed = attackSpeed;
        }

        public override Protype Clone()
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
            Protype bow = new Bow(50, 1.5);
            Protype clone = bow.Clone();

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