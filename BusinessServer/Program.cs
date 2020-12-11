using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServer
{
    class Program
    {
        public Random rng = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Starting server");
            // todo: Get players
            Console.WriteLine("Creating game");
            
            BusinessGame game = new BusinessGame(8);
            game.play();

            Console.Read();
        }
    }
}
