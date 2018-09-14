using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Food : GameObject
    {
        int width;
        int height;

        Random random = new Random();

        public Food(int width, int height) : base('p', new Vector2(), ConsoleColor.DarkYellow)
        {
            this.width = width;
            this.height = height;
        }

        public void Spawn()
        {
            Position.X = random.Next(2, width - 2);
            Position.Y = random.Next(2, height - 2);
            Draw(drawCharacter, Position, color);
        }


    }
}
