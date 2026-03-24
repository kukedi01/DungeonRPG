namespace DungeonRPG.Entities;

public class Sword : Item
{
    public int Damage { get; set; }

    public Sword(string name, int damage) : base(name,"sword")
    {
        Damage = damage;
    }

    public override void Use(Hero character) // ősosztály, gyermekosztály nem teljesen világos 
    {
        character.DMG += Damage;
        Console.WriteLine(
            $"{character.Name} Get weapon: {Name}, DMG +{Damage}"); // static ha mindennek ugyan az az értéke, instance ha midnnek saját értéke van
    }
    
}