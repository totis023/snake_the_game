using System;
using snake_the_game.controllers;

namespace snake_the_game.models
{
    class Menu
    {
        static ResultadoJuego? ultimoResultado = null;
        public static void Show()
        {
            string[] opciones = { "Jugar", "Ver Tabla", "Salir" };

            while (true)
            {
                int opcion = MenuSeleccionar(opciones, "SNAKE THE GAME");

                switch (opcion)
                {
                    case 0:
                        var juego = new nSnake();
                        ultimoResultado = juego.IniciarJuego();
                        break;

                    case 1:
                        Console.Clear();

                        if (ultimoResultado == null)
                        {
                            Console.WriteLine("No hay partidas jugadas todavía...");
                        }
                        else
                        {
                            var controladorTabla = new nTabla();

                            var tabla = controladorTabla.ImprimirPuntajes(
                                ultimoResultado.Puntaje,
                                ultimoResultado.Nivel
                            );

                            controladorTabla.DibujarTabla(tabla);
                        }

                        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                        Console.ReadKey(true);
                        break;

                    case 2:
                        Console.Clear();
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

                //esquinas
                Console.SetCursorPosition(0, 0); Console.Write("╔");
                Console.SetCursorPosition(ancho - 1, 0); Console.Write("╗");
                Console.SetCursorPosition(0, alto - 1); Console.Write("╚");
                Console.SetCursorPosition(ancho - 1, alto - 1); Console.Write("╝");

                //lineas horizontales
                for (int i = 1; i < ancho - 1; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("═");

                    Console.SetCursorPosition(i, alto - 1);
                    Console.Write("═");
                }

                //lineas verticales
                for (int i = 1; i < alto - 1; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("║");

                    Console.SetCursorPosition(ancho - 1, i);
                    Console.Write("║");
                }

                // ===== TÍTULO =====
                Console.SetCursorPosition(0 + (ancho / 2 - titulo.Length / 2), 0 + 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(titulo);
                Console.ResetColor();

                // ===== OPCIONES =====
                for (int i = 0; i < opciones.Length; i++)
                {
                    int y = 3 + i;
                    int x = 3;

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