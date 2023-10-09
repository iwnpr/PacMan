namespace PacMan.Domains
{
    public abstract class AbstractElement
    {
        public abstract char Symbol { get; set; }

        public abstract int X_Position { get; set; }

        public abstract int Y_Position { get; set; }

        public abstract int X_Direction { get; set; }

        public abstract int Y_Direction { get; set; }

        public abstract void Move(char[,] map);

        public abstract void Input();
    }
}
