using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char start;

            do
            {
                new TicTacToe().Start();
                Console.WriteLine("Reiniciar o jogo? (s/n)");
                start = Console.ReadLine()[0];

            } while (start == 's');
        }
    }
}
