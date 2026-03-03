namespace DungeonRPG.Entities;

public class Hero //hős // // public hogy a program.cs elérhesse a classokat 
{
    public string Name { get; set; } // get=olvasás, set=írás 
    public int HP { get; set; }
    public int DMG { get; set; }
    public int DEF { get; set; }
    
    public bool Alive // bool érték csak 1 és 0 vehet fel 
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

public abstract class item 
{
    public string Name { get; set; }
    
    public item (string name)
    {
        Name = name;
    }
    public abstract void Use();
}

public abstract class sword : item
{
    public int Damage { get; set; }
    public sword(string name, int damage) : base(name)
    {
        Damage = damage;
    }

    public void Use(Hero character)
    {
        character.DMG += Damage;
        Console.WriteLine ($"{Hero.Name} Get weapon: {Name}, DMG +{Damage}");
    }
}