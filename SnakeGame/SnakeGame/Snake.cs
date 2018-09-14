using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down,
    }

    class Snake : GameObject
    {
        public Direction Direction { get; set; }

        LinkedList<SnakeTail> tails = new LinkedList<SnakeTail>();

        public Snake(int tailNum = 0, Direction dir = Direction.None) : base('@', new Vector2(), ConsoleColor.DarkRed)
        {
            Direction = dir;

            for(int i = 0; i<tailNum; i++)
            {
                tails.AddLast(new SnakeTail(Position, Direction));
            }
        }

        public void AddTail()
        {
            SnakeTail tail = new SnakeTail(tails.Last.Value.Position);
            tails.AddLast(tail);
        }

        public void Eat(Food food)
        {
            food.Spawn();
            AddTail();
        }

        public bool IsHitTail()
        {
            if(Direction == Direction.None)
            {
                return false;
            }

            foreach(SnakeTail tail in tails)
            {
                if(tail.Position.X == Position.X && tail.Position.Y == Position.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public override void Draw()
        {
            if(Direction != Direction.None)
            {
                foreach(GameObject tail in tails)
                {
                    tail.Draw();
                }
            }

            base.Draw();
        }

        public void Input(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.LeftArrow:
                    Direction = Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                    Direction = Direction.Right;
                    break;

                case ConsoleKey.UpArrow:
                    Direction = Direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                    Direction = Direction.Down;
                    break;
            }
        }

        public void Move()
        {
            if(Direction != Direction.None)
            {
                Draw(' ', Position, ConsoleColor.White);
            }

            switch (Direction)
            {
                case Direction.None:
                    foreach(GameObject tail in tails)
                    {
                        tail.Position = Position;
                    }
                    break;
                case Direction.Left:
                    Position.X--;
                    break;
                case Direction.Right:
                    Position.X++;
                    break;
                case Direction.Up:
                    Position.Y--;
                    break;
                case Direction.Down:
                    Position.Y++;
                    break;
                default:
                    break;
            }

            MoveTails();

            Draw();
        }

        void MoveTails()
        {
            LinkedListNode<SnakeTail> tailNode = tails.Last;

            for(int i = 0; i<tails.Count; i++)
            {
                Draw(' ', tailNode.Value.Position, ConsoleColor.White);

                switch(tailNode.Value.Direction)
                {
                    case Direction.None:
                        break;
                    case Direction.Left:
                        tailNode.Value.Position.X--;
                        break;
                    case Direction.Right:
                        tailNode.Value.Position.X++;
                        break;
                    case Direction.Up:
                        tailNode.Value.Position.Y--;
                        break;
                    case Direction.Down:
                        tailNode.Value.Position.Y++;
                        break;
                    default:
                        break;
                }

                if(tailNode == tails.First)
                {
                    tailNode.Value.Direction = Direction;
                    break;
                }

                tailNode.Value.Direction = tailNode.Previous.Value.Direction;
                tailNode = tailNode.Previous;
            }
        }
    }
}
