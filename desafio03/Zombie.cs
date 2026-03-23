using TheGarden;
using System.Drawing;

public class Zombie
{

    public void Act(Gardenkeeper keeper)
    {
        
        if (keeper.CountNeighborhood("armoredPlayer", 5) > 0)
        {
            keeper.MoveToNext("armoredPlayer", 1, 5, 1);
        }
        else if (keeper.CountNeighborhood("player", 5) > 0)
        {
            keeper.MoveToNext("player", 1, 5, 1);
        }
        else
        {
            keeper.Move(
                Random.Shared.Next(-1, 2),
                Random.Shared.Next(-1, 2)
            );
        }

        if (keeper.CountNeighborhood("player", 1) > 0 || keeper.CountNeighborhood("armoredPlayer", 1) > 0)
        {
            //se for um player normal -> mata
            keeper.KillEntityOnNeighborhood("player", 1);

            //se for um armoredPlayer -> volta a ser player normal
            bool hitArmor = keeper.KillEntityOnNeighborhood("armoredPlayer", 1);
            if(hitArmor)
            {
                keeper.CreateEntityOnNeighborhood("player", 1);
            }

            //zumbi morre ao explodir
            keeper.KillMe();
        }

    }

}