using M326_Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter Name:");
                input = Console.ReadLine();


            } while (String.IsNullOrWhiteSpace(input));

            var player1 = new User(input);
            var player2 = new Bot();
            var game = new Game(player1, player2);
            game.Start();
            Console.ReadLine();
        }
    }
}
