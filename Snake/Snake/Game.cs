using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Snake
{
    public static class Game
    {
        private static int mapWidth = 30;
        private static int mapHeight = 20;
        private static int startX = 15;
        private static int startY = 10;
        private static int startLength = 3;
        private static char symWall = '+';
        private static char symSnake = '*';
        private static char symFood = '$';
        private static Wall wall = new Wall(mapWidth, mapHeight, symWall);
        private static Snake snake= new Snake(new Point(startX, startY, symSnake), startLength, Direction.RIGHT);
        private static FoodCreator foodCreator= new FoodCreator(mapWidth, mapHeight, symFood);
        private static Point food = foodCreator.CreateFood();
        
        public static void ChangeMapSize(int _mapWidth, int _mapHeight)
        {
            mapWidth = _mapWidth;
            mapHeight = _mapHeight;
            startX = mapWidth / 2;
            startY = mapHeight / 2;
        }
        
        public static void Start()
        {
            wall.Draw();
            snake.Draw();
            food.Draw();

            while (true)
            {
                if (wall.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

            }
        }
    }
}
