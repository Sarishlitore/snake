using System;
using System.Threading;

namespace Snake
{
    public static class Game
    {
        // Map width by default
        private static int _mapWidth = 30; 
        // Map height by default
        private static int _mapHeight = 20; 
        // Initial snake x.coordinate by default
        private static int _startX = 15; 
        // Initial snake y.coordinate by default
        private static int _startY = 10; 
        // Initial snake size by default
        private static int startLength = 3; 
        // Initial snake speed by default
        private static int _snakeSpeed = 150;
        // Initial symbol of wall by default
        private static char _symWall = '+';
        // Initial symbol of Snake by default
        private static char _symSnake = '*';
        // Initial symbol of food by default
        private static char _symFood = '$';
        private static Wall _wall = new Wall(_mapWidth, _mapHeight, _symWall);
        private static Snake _snake= new Snake(new Point(_startX, _startY, _symSnake), startLength, Direction.RIGHT);
        private static FoodCreator _foodCreator= new FoodCreator(_mapWidth, _mapHeight, _symFood);
        private static Point _food = _foodCreator.CreateFood();
        public static void ChangeMapSize(int mapWidth, int mapHeight)
        {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
            _startX = mapWidth / 2;
            _startY = mapHeight / 2;
            Init();
        }
        public static void ChangeSnakeSpeed(int snakeSpeed)
        {
            Game._snakeSpeed = snakeSpeed;
        }

        private static void Init()
        {
            _wall = new Wall(_mapWidth, _mapHeight, _symWall);
            _snake= new Snake(new Point(_startX, _startY, _symSnake), startLength, Direction.RIGHT);
            _foodCreator= new FoodCreator(_mapWidth, _mapHeight, _symFood);
            _food = _foodCreator.CreateFood();
        }
        public static void Start()
        {
            _wall.Draw();
            _snake.Draw();
            _food.Draw();
            
            while (true)
            {
                if (_wall.IsHit(_snake) || _snake.IsHitTail())
                {
                    break;
                }
                
                if (_snake.Eat(_food))
                {
                    _food = _foodCreator.CreateFood();
                    _food.Draw();
                } else {
                    _snake.Move();
                }

                Thread.Sleep(_snakeSpeed);

                if (!Console.KeyAvailable) continue;
                
                ConsoleKeyInfo key = Console.ReadKey();
                _snake.HandleKey(key.Key);
            }
        }
    }
}
