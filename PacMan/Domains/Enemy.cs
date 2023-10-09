using System;

namespace PacMan.Domains
{
    public class Enemy : AbstractElement
    {
        public Enemy(char symbol)
        {
            Symbol = symbol;
            X_Direction = 0;
            Y_Direction = -1;
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

            Y_Position += Y_Direction;

            Console.SetCursorPosition(Y_Position, X_Position);
            Console.Write(Symbol);
        }

        public override void Input() => Y_Direction *= -1;
    }
}
