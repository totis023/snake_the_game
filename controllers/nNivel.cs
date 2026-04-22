using snake_the_game.models;

namespace snake_the_game.controllers
{
    class nNivel
    {
        public Nivel nivel {get; set;}

        public nNivel()
        {
            nivel = new Nivel();
        }

        public bool RegistrarComida()
        {
            nivel.ComidaConsumida++;

            if(nivel.ComidaConsumida % nivel.ComidasParaSubir == 0)
            {
                nivel.Numero++;
                return true;
            }
            return false;
        }

        public int ObtenerVelocidad()
        {
            return Math.Max(50, 150 - (nivel.Numero * 10));
        }
    }
}