using System;
using System.Collections.Generic;

namespace Composite
{
    public interface IDog
    {
        public void Bark();
        public string GetName();
    }

    public class Akita : IDog
    {
        private string _name;

        public Akita(string name)
        {
            _name = name;
        }
        
        public string GetName()
        {
            return _name;
        }

        public void Bark()
        {
            Console.WriteLine($"- Akita named {_name}: Woof-Woof");
        }
    }
    
    public class Husky : IDog
    {
        private string _name;

        public Husky(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void Bark()
        {
            Console.WriteLine($"- Husky named {_name}: AAAAUUUUUUUUUUUUUUUUUUUUUU");
        }
    }

    public class DogHotel : IDog
    {
        private List<IDog> _dogs;

        public DogHotel()
        {
            _dogs = new List<IDog>();
        }

        public void AddDog(IDog dog)
        {
            _dogs.Add(dog);
        }

        public void RemoveDog(IDog dog)
        {
            _dogs.Remove(dog);
        }

        public void Bark()
        {
            foreach (var dog in _dogs)
            {
                dog.Bark();
            }
        }

        public string GetName()
        {
            string result = "Dogs:";
            foreach (var dog in _dogs)
            {
                result += $"\n-{dog.GetName()}";
            }

            return result;
        }
    }
    class CompositeProgram
    {
        static void Main(string[] args)
        {
            DogHotel dogHotel = new DogHotel();
            Husky eren = new Husky("Eren");
            Akita zara = new Akita("Zara");
            Akita neli = new Akita("Neli");
            
            dogHotel.AddDog(eren);
            dogHotel.AddDog(neli);
            dogHotel.AddDog(zara);
            
            dogHotel.Bark();
            Console.WriteLine(dogHotel.GetName());
        }
    }
}