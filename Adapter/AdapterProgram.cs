using System;

namespace Adapter
{
    public interface AndroidPhone
    {
        public void PlayGame();
    }

    public class GameBoy
    {
        public void PlayPokemonFireRed()
        {
            Console.WriteLine("Starting Pokémon FireRed...");
            Console.WriteLine("Hello there! Welcome to the world of Pokémon! " +
                              "My name is Oak! People call me the Pokémon Prof!\n" +
                              "This world is inhabited by creatures called Pokémon!" +
                              " For some people, Pokémon are pets. Other use them for fights.");
        }
    }

    public class Emulator : AndroidPhone
    {
        private GameBoy _gameBoy;

        public Emulator(GameBoy gameBoy)
        {
            _gameBoy = gameBoy;
        }

        public void PlayGame()
        {
            _gameBoy.PlayPokemonFireRed();
        }
    }
    class AdapterProgram
    {
        static void Main(string[] args)
        {
            GameBoy gameBoy = new GameBoy();
            Emulator emulator = new Emulator(gameBoy);
            
            emulator.PlayGame();
        }
    }
}