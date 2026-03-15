namespace DungeonRPG.Entities;

public class DefensePotion : Potion
{
    public int Defense { get; set; }
    
    public DefensePotion(string name, int heal, int defense) : base(name, heal)
    {
        Defense = defense;
    }
}