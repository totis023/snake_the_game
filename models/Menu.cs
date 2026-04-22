using System;

namespace snake_the_game.models {
    class Menu
    {
        public static void Show()
        {
            string[] opciones = { "Jugar", "Ver Tabla", "Salir" };

            while (true)
            {
                int opcion = MenuSeleccionar(opciones, "SNAKE THE GAME");

                switch (opcion)
                {
                    case 0:
                        var juego = new snake_the_game.controllers.nSnake();
                        juego.IniciarJuego();
                        break;

                    case 1:
                        Console.WriteLine("Ver Tabla");
                        Console.ReadKey();
                        break;

                    case 2:
                        return;
                }
            }
        }

        public static int MenuSeleccionar(string[] opciones, string titulo)
{
    int seleccion = 0;
    ConsoleKey tecla;

    int ancho = 40;
    int alto = opciones.Length + 6;

    do
    {
        Console.Clear();
        Console.CursorVisible = false;

        int left = (Console.WindowWidth - ancho) / 2;
        int top = (Console.WindowHeight - alto) / 2;

        // ===== BORDES (MISMO ESTILO QUE EL JUEGO) =====

        // Esquinas
        Console.SetCursorPosition(left, top); Console.Write("╔");
        Console.SetCursorPosition(left + ancho - 1, top); Console.Write("╗");
        Console.SetCursorPosition(left, top + alto - 1); Console.Write("╚");
        Console.SetCursorPosition(left + ancho - 1, top + alto - 1); Console.Write("╝");

        // Líneas horizontales
        for (int i = 1; i < ancho - 1; i++)
        {
            Console.SetCursorPosition(left + i, top);
            Console.Write("═");

            Console.SetCursorPosition(left + i, top + alto - 1);
            Console.Write("═");
        }

        // Líneas verticales
        for (int i = 1; i < alto - 1; i++)
        {
            Console.SetCursorPosition(left, top + i);
            Console.Write("║");

            Console.SetCursorPosition(left + ancho - 1, top + i);
            Console.Write("║");
        }

        // ===== TÍTULO =====
        Console.SetCursorPosition(left + (ancho / 2 - titulo.Length / 2), top + 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(titulo);
        Console.ResetColor();

        // ===== OPCIONES =====
        for (int i = 0; i < opciones.Length; i++)
        {
            int y = top + 3 + i;
            int x = left + 3;

            Console.SetCursorPosition(x, y);

            if (i == seleccion)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("► " + opciones[i]);
                Console.ResetColor();
            }
            else
            {
                Console.Write("  " + opciones[i]);
            }
        }

        // Leer tecla
        tecla = Console.ReadKey(true).Key;

        if (tecla == ConsoleKey.UpArrow)
            seleccion = (seleccion == 0) ? opciones.Length - 1 : seleccion - 1;

        if (tecla == ConsoleKey.DownArrow)
            seleccion = (seleccion == opciones.Length - 1) ? 0 : seleccion + 1;

    } while (tecla != ConsoleKey.Enter);

    return seleccion;
}
    }
}