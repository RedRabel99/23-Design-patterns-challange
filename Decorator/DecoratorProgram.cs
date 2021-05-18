using System;

namespace Decorator
{
    public interface ISword
    {
        public double GetDamage();
        public string GetDetails();
    }

    public class Sword : ISword
    {
        private double _damage;
        private string _details;

        public Sword(double damage, string details)
        {
            _damage = damage;
            _details = details;
        }

        public double GetDamage()
        {
            return _damage;
        }

        public string GetDetails()
        {
            return _details;
        }
    }

    public abstract class SwordDecorator : ISword
    {
        private ISword _sword;

        public SwordDecorator(ISword sword)
        {
            _sword = sword;
        }

        public virtual double GetDamage()
        {
            return _sword.GetDamage();
        }

        public virtual string GetDetails()
        {
            return _sword.GetDetails();
        }
    }

    public class SwordSharpener : SwordDecorator
    {
        public SwordSharpener(ISword sword) : base(sword){}

        public override double GetDamage()
        {
            return base.GetDamage() + base.GetDamage() * 0.30;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + ", sharpened";
        }
    }
    
    public class SwordOil : SwordDecorator
    {
        public SwordOil(ISword sword) : base(sword){}

        public override double GetDamage()
        {
            return base.GetDamage() + 5.00;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + ", oiled";
        }
    }

    class DecoratorProgram
    {
        static void Main(string[] args)
        {
            Sword sword = new Sword(55.00, "Steel");
            SwordDecorator upgraded = new SwordSharpener(sword);
            upgraded = new SwordOil(upgraded);
            
            Console.WriteLine($"This is: {sword.GetDetails()} sword with {sword.GetDamage()} damage");
            Console.WriteLine($"This is: {upgraded.GetDetails()} sword with {upgraded.GetDamage()} damage");
        }
    }
}