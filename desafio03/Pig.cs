using TheGarden;

public class Pig
{

    public void Act(Gardenkeeper keeper)
    {
        keeper.Move(
            Random.Shared.Next(-1, 2),
            Random.Shared.Next(-1, 2)
        );
    }
}