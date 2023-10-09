using System;

namespace PacMan.Domains
{
    public class Player : AbstractElement
    {
        public Player(char symbol)
        {
            Symbol = symbol;
            X_Direction = 0;
            Y_Direction = 1;

        }

        public override char Symbol { get; set; }

        public override int X_Position { get; set; }

        public override int Y_Position { get; set; }

        public override int X_Direction { get; set; }

        public override int Y_Direction { get; set; }

        public override void Move(char[,] map)
        {
            Console.SetCursorPosition(Y_Position, X_Position);
            Console.Write(map[X_Position, Y_Position]);

            X_Position += X_Direction;
            Y_Position += Y_Direction;

            Console.SetCursorPosition(Y_Position, X_Position);
            Console.Write(Symbol);
        }

        public override void Input()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    X_Direction = 0; Y_Direction = -1;
                    break;

                case ConsoleKey.RightArrow:
                    X_Direction = 0; Y_Direction = 1;
                    break;

                case ConsoleKey.UpArrow:

                    X_Direction = -1; Y_Direction = 0;
                    break;

                case ConsoleKey.DownArrow:
                    X_Direction = 1; Y_Direction = 0;
                    break;
            }

        }
    }
}
