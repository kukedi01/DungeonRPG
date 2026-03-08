namespace DungeonRPG.Entities;

public abstract class Item // nem leehet pédányosítani 
{
    public string Name { get; set; }
    
    public Item (string name)
    {
        Name = name;
    }
    public abstract void Use(Hero character);
}