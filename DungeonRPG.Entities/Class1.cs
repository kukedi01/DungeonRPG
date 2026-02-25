namespace DungeonRPG.Entities;

class Hero //hős
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int DMG { get; set; }
    public int DEF { get; set; }
    
    //konstruktor (mire jó pontosan ?)
    
    public Hero (string name,  int hp, int dmg, int def)
        {
        Name = name;
        HP = hp;
        DMG = dmg;
        DEF = def;
        }
}

class Monster 
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int DMG { get; set; }
    
    public int DEF { get; set; }
    
    public Monster (string name, int hp, int dmg, int def)
        {
        Name = name;
        HP = hp;
        DMG = dmg;
        DEF = def;
       }
}