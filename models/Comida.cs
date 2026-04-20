using System;

namespace snake_the_game.models
{
    class Comida
    {
        public int x {get; set;}
        public int y {get; set;}

        public Comida(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}