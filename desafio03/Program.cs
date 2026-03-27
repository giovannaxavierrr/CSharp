using System.Drawing;
using TheGarden;
var garden = new Garden();
garden.ChangeColor(Color.ForestGreen); //o fundo vai ser verde (jardim)

garden.Add("pig", Color.Pink); //criar a entidade porco
garden.Add("player", Color.Purple); //como os arquivos estão no mesmo projeto, "player" ja vai ser reconhecido como a classe "Player.cs", 
                                    //e os outros também, com case insensitive
garden.Add("mine", Color.Gray);
garden.Add("armoredPlayer", Color.LightBlue);
garden.Add("creeper", Color.DarkGreen);
garden.Add("zombie", Color.DarkBlue);
garden.AddRandom("pig", Color.Pink, 40); // vai colocar 40 pigs num lugar aleatorio do mapa
garden.AddRandom("player", Color.Purple, 10);
garden.AddRandom("mine", Color.DarkGray, 10);
garden.AddRandom("creeper", Color.DarkGreen, 20);
garden.AddRandom("zombie", Color.DarkBlue, 20);
garden.Run();
 /*
public class Minecraft
{

    public void Act(Gardenkeeper keeper) 
    {

    }




}*/

