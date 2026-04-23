namespace snake_the_game.models
{
    class Nivel
    {
        public int Numero {get; set;}
        public int ComidaConsumida {get; set;}
        public int ComidasParaSubir {get; set;}
        
        public Nivel()
        {
            Numero = 1;
            ComidaConsumida = 0;
            ComidasParaSubir = 10;
        }
    }
}