using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class GameObject
    {
        public Vector2 Position;

        protected char drawCharacter;
        protected ConsoleColor color;

        public GameObject(char draw, Vector2 pos, ConsoleColor color)
        {
            drawCharacter = draw;
            Position = pos;
            this.color = color;
        }
        // 게임오브젝트를 그려주는 메서드
        public virtual void Draw()
        {
            Draw(drawCharacter, Position, color);
        }

        protected void Draw(char draw, Vector2 pos, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(draw);
        }
    }
}
