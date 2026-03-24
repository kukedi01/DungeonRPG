namespace DungeonRPG.Entities;

public abstract class Item // nem leehet pédányosítani 
{
    public string Name { get; set; }
    public string Type { get; set; }
    
    public Item (string name, string type)
    {
        Name = name;
        Type = type;
    }
    public abstract void Use(Hero character);
}