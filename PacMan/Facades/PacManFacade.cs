using System;
using PacMan.Domains;

namespace PacMan.Facades
{
    public class PacManFacade
    {
        public PacManFacade(Map map, Player player, Enemy enemy, PointCount pointCount)
        {
            Map = map;
            Player = player;
            Enemy = enemy;
            PointCount = pointCount;
        }

        public Map Map { get; set; }

        public Player Player { get; set; }

        public Enemy Enemy { get; set; }

        public PointCount PointCount { get; set; }
        
        public void TryToChangeEnemyPosition(char[,] map)
        {
            if (map[Enemy.X_Position + Enemy.X_Direction, Enemy.Y_Position + Enemy.Y_Direction] != Map.BroadChar)
            {
                Enemy.Move(map);
            }
            else
            {
                Enemy.Input();
            }
        }

        public void TryToChangePlayerPosition(char[,] map)
        {
            if (Console.KeyAvailable)
                Player.Input();

            if (map[Player.X_Position + Player.X_Direction, Player.Y_Position + Player.Y_Direction] != Map.BroadChar)
            {
                Player.Move(map);
            }
        }

        public void PointCounter(char[,] map)
        {
            if (map[Player.X_Position + Player.X_Direction, Player.Y_Position + Player.Y_Direction] != Map.BroadChar)
            {
                PointCount.CollectPoint(map, Player);
            }
        }

        public void ShowPoints()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"Собрано {PointCount.CollectionPoints}/{PointCount.AllPoints + 2}");
        }

        public void CheckCount(ref bool isPlaying)
        {
            if (PointCount.CollectionPoints == PointCount.AllPoints + 2)
            {
                isPlaying = false;
            }
        }

        public void CheckDie(ref bool isAlive)
        {
            if (Player.X_Position == Enemy.X_Position && Player.Y_Position == Enemy.Y_Position)
            {
                isAlive = false;
            }
        }
    }
}
