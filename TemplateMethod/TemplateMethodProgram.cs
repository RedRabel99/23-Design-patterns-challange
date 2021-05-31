using System;

namespace TemplateMethod
{
    class TemplateMethodProgram
    {
        public abstract class Game
        {
            protected abstract void LaunchGame();
            protected abstract void StarPlaying();

            public void Play()
            {
                this.LaunchGame();
                this.StarPlaying();
            }
        }
        
        public class Witcher3 : Game 
        {
            protected override void LaunchGame()
            {
                Console.WriteLine("Starting Witcher 3: The Wild Hunt...\n" +
                                  "The game has started");
            }

            protected override void StarPlaying()
            {
                Console.WriteLine("*Lelele playing in the background*");
            }
        }
        
        public class Cyberpunk2077 : Game
        {
            protected override void LaunchGame()
            {
                Console.WriteLine("Starting Cyberpunk 2077...\n" +
                                  "The game has started");
            }

            protected override void StarPlaying()
            {
                Console.WriteLine("cyberpunk.exe has stopped working");
            }
        }
        
        static void Main(string[] args)
        {
            Game witcher = new Witcher3();
            witcher.Play();

            Game cyberpunk = new Cyberpunk2077();
            cyberpunk.Play();
        }
    }
}