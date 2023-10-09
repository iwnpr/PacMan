using System;
using PacMan.Domains;
using PacMan.Facades;

namespace PacManConsole
{
    class Program
    {
        static void EndGame(bool isPlaying, bool isAlive)
        {
            if (isPlaying == false)
            {
                Console.WriteLine("\nПобеда! \tВсе очки собраны!");
            }
            if (isAlive == false)
            {
                Console.WriteLine("\nПоражение! \tВас убили!");
            }
        }

        static void Main(string[] args)
        {
            const char _PLAYER = 'O';
            const char _ENEMY = '%';
            const string _MAP_1_NAME = "map1";
            const char _BROAD_CHAR = '\\';
            const char _COLLECTION_CHAR = '.';

            bool isPlaying = true;
            bool isAlive = true;

            Player player = new Player(_PLAYER);
            Enemy enemy = new Enemy(_ENEMY);
            PointCount pointCount = new PointCount(_COLLECTION_CHAR);
            Map map = new Map(_MAP_1_NAME, _BROAD_CHAR, pointCount, player, enemy);
            PacManFacade facade = new PacManFacade(map, player, enemy, pointCount);

            char[,] currentMap = map.ReadMap();
            map.DrawMap(currentMap);

            while (isPlaying && isAlive)
            {
                facade.TryToChangePlayerPosition(currentMap);
                facade.TryToChangeEnemyPosition(currentMap);
                facade.PointCounter(currentMap);

                System.Threading.Thread.Sleep(200);

                facade.ShowPoints();
                facade.CheckCount(ref isPlaying);
                facade.CheckDie(ref isAlive);
            }

            EndGame(isPlaying, isAlive);

            Console.ReadKey();
        }
    }
}
