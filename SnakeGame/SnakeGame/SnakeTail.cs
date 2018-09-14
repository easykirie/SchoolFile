using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class SnakeTail : GameObject
    {
        public Direction Direction { get; set; }

        public SnakeTail(Vector2 pos, Direction dir = Direction.None) : base('=', pos, ConsoleColor.DarkBlue)
        {
            Direction = dir;
        }
    }
}
