using DungeonRPG.Entities;
using DungeonRPG.Service;

namespace DungeonRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero("Elf", 100, 40, 10);
            Potion potion = new Potion(name: "Heal Potion", heal: 5);
            Sword sword = new Sword(name: "Excalibur", 5);
            Console.WriteLine("Character stat:");
            Console.WriteLine($"Name: {elf.Name}");
            Console.WriteLine($"HP: {elf.HP}");
            Console.WriteLine($"DMG: {elf.DMG}");
            Console.WriteLine($"DEF: {elf.DEF}");
            elf.Inventory.Add(potion);
            elf.Inventory.Add(sword);

            Monster goblin = new Monster("Goblin", 80, 10, 5);
            Console.WriteLine("Monster stat:");
            Console.WriteLine($"Name: {goblin.Name}");
            Console.WriteLine($"HP: {goblin.HP}");
            Console.WriteLine($"DMG: {goblin.DMG}");
            Console.WriteLine($"DEF: {goblin.DEF}");
            

            CombatService combat = new CombatService();
            combat.Fight(elf, goblin);


            Console.ReadKey();
        }

    }
}