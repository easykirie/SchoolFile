using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GameObject> walls = CreatWalls(50, 25);

            foreach(GameObject wall in walls)
            {
                wall.Draw();
            }

            Snake snake = new Snake(2);
            snake.Position = new Vector2(5, 5);
            snake.Draw();

            Food food = new Food(50, 25);
            food.Spawn();

            while(true)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    //ESC를 누르면 플레이 종료
                    if(info.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    snake.Input(info.Key);
                }

                snake.Move();

                if(CheckHitOnWalls(walls, snake.Position) || snake.IsHitTail())
                {
                    break;
                }
                else if(food.Position.X == snake.Position.X && food.Position.Y == snake.Position.Y)
                {
                    snake.Eat(food);
                }

                Thread.Sleep(200);
            }

            Console.SetCursorPosition(55, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Game Over");
            Console.Read();
        }


        static List<GameObject> CreatWalls(int width, int height)
        {
            List<GameObject> walls = new List<GameObject>();

            for (int i = 0; i < width; i++)
            {
                //상단벽
                walls.Add(new GameObject('-', new Vector2(i, 0), ConsoleColor.White));
                //하단벽
                walls.Add(new GameObject('-', new Vector2(i, height - 1), ConsoleColor.White));
            }
            for (int i = 0; i < height; i++)
            {
                //좌측벽
                walls.Add(new GameObject('+', new Vector2(0, i), ConsoleColor.White));
                //우측벽
                walls.Add(new GameObject('+', new Vector2(width - 1, i), ConsoleColor.White));
            }

            return walls;
        }

        static bool CheckHitOnWalls(List<GameObject> walls, Vector2 pos)
        {
            foreach(GameObject wall in walls)
            {
                if(wall.Position.X == pos.X && wall.Position.Y == pos.Y)
                {
                    return true;
                }                
            }
            return false;
        }
    }

    
}
