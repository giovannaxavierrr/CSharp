using TheGarden;
using System.Drawing;

public class Player
{

    public int Fome { get; set; } = 20; //get set permite ler e alterar o valor, e todo player começa com fome = 20

    public void Act(Gardenkeeper keeper)
    {
        Fome--; //a fome vai diminuindo o valor, aumentando a fome do jogador, fazendo com que ele corra atras de comida para se recuperar

        keeper.Move(
            Random.Shared.Next(-1, 2),
            Random.Shared.Next(-1, 2)
        );

        if(Fome == 0) {
            keeper.KillMe();
            return;
        }

        if (keeper.CountNeighborhood("pig", 1) > 0)
        {
            keeper.MoveToNext("pig", 1, 5, 1); //comportamento de caçador, vai seguir o porco
        } else {
            keeper.Move(
                Random.Shared.Next(-1, 2),
                Random.Shared.Next(-1, 2)
            );
        }

        if (keeper.CountNeighborhood("pig", 5) > 0) //CountNeighborhood Conta quantas entidades do porco estão próximas do player
        {
            bool killed = keeper.KillEntityOnNeighborhood("pig", 1); //KillEntityOnNeighborhood mata o porco próximo ao player
            if (killed)
            {
                Fome = 10;
                if (Fome > 20)
                {
                    Fome = 20;
                }
                keeper.ChangeColor(Color.Purple);
                return; //pra parar de correr o codigo de certeza
            }
        }

        if (keeper.CountNeighborhood("mine", 1) > 0)
        {
            keeper.CreateEntityOnNeighborhood("armoredPlayer", 0, 0); //cria um player com armadura no lugar do player normal
            keeper.KillMe(); //mata o player pra dar lugar ao player com armadura
            return;
        }

        //muda de cor quando sentir fome
        if (Fome < 8) {
            keeper.ChangeColor(Color.Orchid);
        } else {
            keeper.ChangeColor(Color.Purple);
        }
    }

}