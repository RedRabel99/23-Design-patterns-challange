using System;
using System.Collections.Generic;
using System.Linq;

namespace Observer
{
    public class YouTuber
    {
        private List<IObserver> _observers;
        private string _name;

        public YouTuber(string name)
        {
            _observers = new List<IObserver>();
            _name = name;
        }

        public void Add(IObserver observer)
        {
            _observers.Add(observer);
            if (observer is Subscriber subscriber)
            {
                Console.WriteLine($"{subscriber.GetName()} subscribed {_name}");
            }
        }

        public void Upload(string movieName)
        {
            _observers.ToList().ForEach(x =>
            {
                x.Update(this, movieName);
            });
        }

        public string GetName()
        {
            return _name;
        }
    }
    
    
    public interface IObserver
    {
        void Update(YouTuber youTuber, string movieName);
    }

    public class Subscriber : IObserver
    {
        private string _name;

        public Subscriber(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void Update(YouTuber youTuber, string movieName)
        {
            Console.WriteLine($"User {_name} got a notification that {youTuber.GetName()} uploaded movie named {movieName}");
        }
    }
    
    class ObserverProgram
    {
        static void Main(string[] args)
        {
            YouTuber klocuch = new YouTuber("Klocuch");
            Subscriber subscriber1 = new Subscriber("John21");
            Subscriber subscriber2 = new Subscriber("Paul37");
            klocuch.Add(subscriber1);
            klocuch.Add(subscriber2);
            
            klocuch.Upload("AEZAKMI");
            klocuch.Upload("Cyberpunk - wideorecenzja");
        }
    }
}