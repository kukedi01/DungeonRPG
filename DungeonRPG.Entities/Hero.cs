using System.ComponentModel.Design;

namespace DungeonRPG.Entities;

public class Hero //hős // // public hogy a program.cs elérhesse a classokat 
{
    public string Name { get; set; } // get=olvasás, set=írás 
    public int HP { get; set; }
    public int DMG { get; set; }
    public int DEF { get; set; }
    
    public Sword? EquippedSword { get; set; }
    
    public List<Item> Inventory { get; set; }
    
    public bool Alive // bool érték csak 1 és 0 vehet fel 
    {
        get { return HP > 0;  }
    }
    
    public int Attack()  // metódus 
    {
        int dmg = DMG;  
        foreach (Item item in this.Inventory) // mindegyiket megvizsgálja a listába listázza az elemeket THIS= SAJÁT MAGÁRA MUTAT 
        {
            if (item.GetType() == typeof(Sword)) // item típus lekérdezés 
            {
                Sword sword = item as Sword; // átkasztolás megfeleltetjük a feltételnek 
                dmg += sword.Damage;
                    
            }
            else
            {
                continue;
            }               
        }
        return dmg;  
    }

    public void Defend(int incomingDamage) // void nem ad vissza értéket csak változtat
    {
        int taken = incomingDamage - this.DEF;
        if (taken < 0)
        {
            return;
        }
        else
        {
            HP -= taken;
        }
        // hp kisebb mint 0 vagy negatívba ment megnézni az inventoryt van-r potion és használni is IF !ALIVE
    }
    //konstruktor (mire jó pontosan ?)
    
    public Hero (string name,  int hp, int dmg, int def)
        {
        Name = name;
        HP = hp;
        DMG = dmg;
        DEF = def;
        Inventory = new List<Item>();
        }
    
    public void EquipSword(Sword sword)
    {
        if (!Inventory.Contains(sword))
        {
            Inventory.Add(sword);
        }

        if (EquippedSword == null)
        {
            EquippedSword = sword;
            Console.WriteLine($"{Name} equipped {sword.Name}");
        }
        else if (sword.Damage > EquippedSword.Damage)
        {
            Console.WriteLine(
                $"{Name} replaced {EquippedSword.Name} with {sword.Name}");

            EquippedSword = sword;
        }
        else
        {
            Console.WriteLine(
                $"{sword.Name} is weaker than {EquippedSword.Name}, so it stays in the inventory.");
        }
    }
}