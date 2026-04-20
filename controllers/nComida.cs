using System;
using snake_the_game.models;

namespace snake_the_game.controllers
{
    class nComida
    {
        private Random random = new Random();

        public Comida GenerarComida(Snake snake, int ancho, int alto)
        {
            int x, y;
            bool posicionValida;

            do
            {
                x = random.Next(1, ancho - 1);
                y = random.Next(1, alto - 1);

                posicionValida = true;

                foreach (var parte in snake.Cuerpo)
                {
                    if (parte.x == x && parte.y == y)
                    {
                        posicionValida = false;
                        break;
                    }
                }

            } while (!posicionValida);

            return new Comida(x, y);
        }

        public void DibujarComida(Comida comida)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(comida.x, comida.y);
            Console.Write("●");
            Console.ResetColor();
        }
    }
}