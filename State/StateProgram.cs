using System;
using System.Resources;

namespace State
{
    public interface IState
    {
        public void GetHit(ZombiePigmen pigmen);
        public void ForgetPlayer(ZombiePigmen pigmen);
    }

    public class ZombiePigmen
    {
        private IState _state;

        public ZombiePigmen()
        {
            _state = new Neutral();
        }
        public void GetHit()
        {
            _state.GetHit(this);
        }

        public void ForgetPlayer()
        {
            _state.ForgetPlayer(this);
        }

        public void SetState(IState state)
        {
            _state = state;
        }
    }

    public class Hostile : IState
    {
        public void GetHit(ZombiePigmen pigmen)
        {
            Console.WriteLine("Zombie Pigmen was already angry at player. He will still attack him");
        }

        public void ForgetPlayer(ZombiePigmen pigmen)
        {
            Console.WriteLine("Zombie pigmen has forgot the player. It won't attack him for now.");
            pigmen.SetState(new Neutral());
        }
    }
    
    public class Neutral : IState
    {
        public void GetHit(ZombiePigmen pigmen)
        {
            Console.WriteLine("Zombie pigment got angry at player. He will attack him from now on");
            pigmen.SetState(new Hostile());
        }

        public void ForgetPlayer(ZombiePigmen pigmen)
        {
            Console.WriteLine("Zombie pigmen didn't remember the player before anyway");
        }
    }
    
    class StateProgram
    {
        static void Main(string[] args)
        {
            ZombiePigmen pigmen = new ZombiePigmen();
            pigmen.GetHit();
            pigmen.ForgetPlayer();
            pigmen.ForgetPlayer();
            pigmen.GetHit();
            pigmen.GetHit();
        }
    }
}