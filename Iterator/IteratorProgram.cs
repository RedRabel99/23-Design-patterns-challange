using System;
using System.Collections;

namespace Iterator
{
    public class Item
    {
        private string _name;

        public Item(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }

    public interface IIterator
    {
        Item MoveNext();
        Item First();
        bool HasNext();
    }

    public class ItemIterator : IIterator
    {
        private int _iterator;
        private ItemCollection _items;

        public ItemIterator(ItemCollection items)
        {
            _items = items;
            _iterator = 0;
        }
        
        public Item MoveNext()
        {
            _iterator += 1;
            if (!HasNext())
            {
                return _items[_iterator] as Item;
            }

            return null;    
        }

        public bool HasNext()
        {
            return (_iterator >= _items.Length());
        }

        public Item First()
        {
            _iterator = 0;
            return _items[_iterator] as Item;
        }
    }

    public interface ICollection
    {
        int Length();
        IIterator CreateIterator();
    }

    public class ItemCollection : ICollection
    {
        private ArrayList _items;

        public int Length()
        {
            return _items.Count;
        }

        public ItemCollection()
        {
            _items = new ArrayList();
        }
        public IIterator CreateIterator()
        {
            return new ItemIterator(this);
        }

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }
    class IteratorProgram
    {
        static void Main(string[] args)
        {
            ItemCollection collection = new ItemCollection();
            collection[0] = new Item("Sword");
            collection[1] = new Item("Potion");
            collection[2] = new Item("Shield");
            collection[3] = new Item("Helmet");
            collection[4] = new Item("Plate");

            IIterator iterator = collection.CreateIterator();
            Console.WriteLine("Items in collection:");
            for (Item item = iterator.First(); !iterator.HasNext(); item = iterator.MoveNext())
            {
                Console.WriteLine($"-{item.GetName()}");
            }
        }
    }
}