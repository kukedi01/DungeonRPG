namespace DungeonRPG.Entities;

public  class Potion : Item
{
    public int Heal { get; set; }
    public Potion (string name, int heal) : base(name,"potion")
    {
        Heal = heal;
    }

    public override void Use(Hero character) // ősosztály, gyermekosztály nem teljesen világos 
    {
        character.HP += Heal;
        Console.WriteLine ($"{character.Name} Get weapon: {Name}, HP +{Heal}"); // static ha mindennek ugyan az az értéke, instance ha midnnek saját értéke van
    }
}