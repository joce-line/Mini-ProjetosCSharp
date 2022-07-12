using System;

namespace TicTacToe
{
    public class TicTacToe
    {
        private bool endGame;
        private char[] position;
        private char turn;
        private int markedQuantity;

        public TicTacToe()
        {
            endGame = false;
            position = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            turn = 'X';
            markedQuantity = 0;
        }

        public void Start()
        {
            while (!endGame)
            {
                RenderTable();
                ReadUserChoice();
                RenderTable();
                VerifyEndGame();
                ChangeTurn();
            }
        }

        private void ChangeTurn()
        {
            turn = turn == 'X' ? 'O' : 'X';
        }

        private void VerifyEndGame()
        {
            if (markedQuantity < 5)
                return;

            if (checkHorizontalWin() || checkVerticalWin() || checkDiagonalWin())
            {
                endGame = true;
                Console.WriteLine($"FIM DE JOGO! {turn} é o vencedor!");
                return;
            }

            if (markedQuantity is 9)
            {
                endGame = true;
                Console.WriteLine($"FIM DE JOGO! Deu empate!");
            }

        }

        private bool checkDiagonalWin()
        {
            bool victoryLine1 = position[0] == position[4] && position[0] == position[8];
            bool victoryLine2 = position[2] == position[4] && position[2] == position[6];

            return victoryLine1 || victoryLine2;
        }

        private bool checkVerticalWin()
        {
            bool victoryLine1 = position[0] == position[3] && position[0] == position[6];
            bool victoryLine2 = position[1] == position[4] && position[1] == position[7];
            bool victoryLine3 = position[2] == position[5] && position[2] == position[8];

            return victoryLine1 || victoryLine2 || victoryLine3;
        }

        private bool checkHorizontalWin()
        {
            bool victoryLine1 = position[0] == position[1] && position[0] == position[2];
            bool victoryLine2 = position[3] == position[4] && position[3] == position[5];
            bool victoryLine3 = position[6] == position[7] && position[6] == position[8];

            return victoryLine1 || victoryLine2 || victoryLine3;
        }

        private void ReadUserChoice()
        {
            Console.WriteLine($"Agora é a vez de {turn}, escolha uma posição disponível.");

            bool conversion = int.TryParse(Console.ReadLine(), out int chosenPosition);

            while (!conversion || !ValidateUserChoice(chosenPosition))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 e 9 que esteja disponível na tabela.");
                conversion = int.TryParse(Console.ReadLine(), out chosenPosition);
            }

            MarkChoice(chosenPosition);

        }

        private void MarkChoice(int chosenPosition)
        {
            int index = chosenPosition - 1;

            position[index] = turn;
            markedQuantity++;
        }

        private bool ValidateUserChoice(int chosenPosition)
        {
            int index = chosenPosition - 1;
            return position[index] != 'O' && position[index] != 'X';

        }

        private void RenderTable()
        {
            Console.Clear();
            Console.WriteLine(GetTable());
        }

        private string GetTable()
        {
            return $"__{position[0]}__|__{position[1]}__|__{position[2]}__\n" +
                   $"__{position[3]}__|__{position[4]}__|__{position[5]}__\n" +
                   $"  {position[6]}  |  {position[7]}  |  {position[8]}  \n\n";
        }
    }
}