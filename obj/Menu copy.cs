using System;

namespace snake_the_game;

public class Menu
{
    // Método principal del menú
    // Se encarga de mostrar las opciones y manejar la navegación del usuario
    public static void Show()
    {
        // Opciones del menú principal
        string[] opciones = { "Jugar", "Ver Tabla", "Salir" };

        // Bucle infinito para mantener el menú activo
        while (true)
        {
            // Llama al método que dibuja el menú y devuelve la opción elegida
            int opcion = MenuSeleccionar(opciones, "SNAKE THE GAME");

            // Ejecuta una acción según la opción seleccionada
            switch (opcion)
            {
                case 0:
                    // Opción: Jugar (acá se conectará con el juego)
                    Console.WriteLine("Jugar");
                    Console.ReadKey();
                    break;

                case 1:
                    // Opción: Ver tabla (acá se conectará con la tabla de puntajes)
                    Console.WriteLine("Ver Tabla");
                    Console.ReadKey();
                    break;

                case 2:
                    // Opción: Salir (termina la ejecución del programa)
                    return;
            }
        }
    }

    // Método que muestra el menú en consola y permite seleccionar una opción con el teclado
    public static int MenuSeleccionar(string[] opciones, string titulo)
    {
        // Índice de la opción actualmente seleccionada
        int seleccion = 0;

        // Variable para capturar la tecla presionada
        ConsoleKey tecla;

        // Bucle que se ejecuta hasta que el usuario presione Enter
        do
        {
            // Limpia la pantalla para redibujar el menú
            Console.Clear();

            // Muestra el título del menú
            Console.WriteLine("==== " + titulo + " ====\n");

            // Recorre todas las opciones del menú
            for (int i = 0; i < opciones.Length; i++)
            {
                // Si es la opción actualmente seleccionada, se resalta
                if (i == seleccion)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("> " + opciones[i]);
                }
                else
                {
                    // Opciones no seleccionadas
                    Console.WriteLine("  " + opciones[i]);
                }

                // Restablece los colores de la consola
                Console.ResetColor();
            }

            // Lee la tecla presionada sin mostrarla en pantalla
            tecla = Console.ReadKey(true).Key;

            // Si se presiona la flecha hacia arriba
            if (tecla == ConsoleKey.UpArrow)
                // Si está en la primera opción, va a la última (circular)
                seleccion = (seleccion == 0) ? opciones.Length - 1 : seleccion - 1;

            // Si se presiona la flecha hacia abajo
            if (tecla == ConsoleKey.DownArrow)
                // Si está en la última opción, vuelve a la primera (circular)
                seleccion = (seleccion == opciones.Length - 1) ? 0 : seleccion + 1;

        } while (tecla != ConsoleKey.Enter); // Termina cuando se presiona Enter

        // Devuelve el índice de la opción seleccionada
        return seleccion;
    }
}