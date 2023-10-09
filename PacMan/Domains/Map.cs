using System.IO;
using System;

namespace PacMan.Domains
{
    public class Map
    {
        public Map(string name, char broadChar, PointCount pointCount, Player player, Enemy enemy)
        {
            MapName = name;
            BroadChar = broadChar;
            PointCount = pointCount;
            Player = player;
            Enemy = enemy;
        }

        public string MapName { get; set; }

        public char BroadChar { get; set; }

        public Player Player { get; set; }

        public Enemy Enemy { get; set; }

        public PointCount PointCount { get; set; }

        public char[,] ReadMap()
        {
            Player.X_Position = 0;
            Player.Y_Position = 0;

            Enemy.X_Position = 0;
            Enemy.Y_Position = 0;

            PointCount.AllPoints = 0;
            PointCount.CollectionPoints = 0;

            string[] newFile = File.ReadAllLines($"Maps/{MapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == Player.Symbol)
                    {
                        Player.X_Position = i;
                        Player.Y_Position = j;
                        map[i, j] = PointCount.CollectionChar;
                    }
                    if (map[i, j] == Enemy.Symbol)
                    {
                        Enemy.X_Position = i;
                        Enemy.Y_Position = j;
                        map[i, j] = PointCount.CollectionChar;
                    }
                    if (map[i, j] == ' ')
                    {
                        map[i, j] = PointCount.CollectionChar;
                        PointCount.AllPoints++;
                    }
                }
            }

            return map;
        }

        public void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}
