namespace PacMan.Domains
{
    public class PointCount
    {
        public PointCount(char collectionChar)
        {
            CollectionChar = collectionChar;
        }

        public char CollectionChar { get; set; }

        public int AllPoints { get; set; }

        public int CollectionPoints { get; set; }

        public void CollectPoint(char[,] map, Player player)
        {
            if (map[player.X_Position, player.Y_Position] == CollectionChar)
            {
                CollectionPoints++;
                map[player.X_Position, player.Y_Position] = ' ';
            }
        }
    }
}
