namespace DungeonRPG.Entities;

public class Hero //hős // // public hogy a program.cs elérhesse a classokat 
{
    public string Name { get; set; } // get=olvasás, set=írás 
    public int HP { get; set; }
    public int DMG { get; set; }
    public int DEF { get; set; }
    
    public bool Alive
    {
        get { return HP > 0;  }
    }
    
    public int Attack() 
    {
        return DMG;  
    }

    public void Defend(int incomingDamage) // void nem ad vissza értéket csak változtat 
    {
        int taken =  incomingDamage - DEF;
        if (taken < 0) taken = 0;
        HP = HP - taken;
    }
    //konstruktor (mire jó pontosan ?)
    
    public Hero (string name,  int hp, int dmg, int def)
        {
        Name = name;
        HP = hp;
        DMG = dmg;
        DEF = def;
        }
}

public class Monster 
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int DMG { get; set; }
    
    public int DEF { get; set; }
    
    public bool Alive
    {
        get { return HP > 0;  }
    }
    
    public int Attack() 
    {
        return DMG;  
    }

    public void Defend(int incomingDamage) // void nem ad vissza értéket csak változtat 
    {
        int taken = incomingDamage - DEF;
        if (taken < 0) taken = 0;
        HP = HP - taken;
    }

    public Monster (string name, int hp, int dmg, int def)
        {
        Name = name;
        HP = hp;
        DMG = dmg;
        DEF = def;
       }
}