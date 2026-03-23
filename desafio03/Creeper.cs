using TheGarden;
using System.Drawing;

public class Creeper
{

    public int ExplosionTimer {get; set; } = 0;

    public void Act(Gardenkeeper keeper)
    {
        
        //se houver armoredPlayer proximo, prioriza ele
        if (keeper.CountNeighborhood("armoredPlayer", 5) > 0)
        {
            keeper.MoveToNext("armoredPlayer", 1, 5, 1);
        }
        //senão procura um player proximo
        else if (keeper.CountNeighborhood("player", 5) > 0)
        {
            keeper.MoveToNext("player", 1, 5, 1);
        }
        //senão tiver ninguem, fica vagando por ai
        else
        {
            keeper.Move(
                Random.Shared.Next(-1, 2),
                Random.Shared.Next(-1, 2)
            );
        }

        //inicio da explosão
        if (keeper.CountNeighborhood("player", 1) > 0 || keeper.CountNeighborhood("armoredPlayer", 1) > 0)
        {
            //gatilho da explosão
            if (ExplosionTimer == 0)
            {
                ExplosionTimer = 5;
            }
        }

        if (ExplosionTimer > 0)
        {
            ExplosionTimer--;
            keeper.ChangeColor(Color.OrangeRed);
        } 
        else
        {
            keeper.ChangeColor(Color.DarkGreen);
        }

        //Explosão
        if (ExplosionTimer == 0 && (keeper.CountNeighborhood("player", 1) > 0 || keeper.CountNeighborhood("armoredPlayer", 1) > 0))
        {
            //se for um player normal -> mata
            keeper.KillEntityOnNeighborhood("player", 1);

            //se for um armoredPlayer -> volta a ser player normal
            bool hitArmor = keeper.KillEntityOnNeighborhood("armoredPlayer", 1);
            if(hitArmor)
            {
                keeper.CreateEntityOnNeighborhood("player", 1);
            }

            //creeper morre ao explodir
            keeper.KillMe();
        }

    }
}