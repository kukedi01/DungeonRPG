namespace DungeonRPG.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Hero elf = new Hero("Elf", 100, 30, 20);
        Console.WriteLine("Character stat:");
        Console.WriteLine($"Name: {elf.Name}");
        Console.WriteLine($"HP: {elf.HP}");
        Console.WriteLine($"DMG: {elf.DMG}");
        Console.WriteLine($"DEF: {elf.DEF}");
        
        Monster goblin = new Monster("Goblin", 80, 10, 30);
        Console.WriteLine("Monster stat:");
        Console.WriteLine($"Name: {goblin.Name}");
        Console.WriteLine($"HP: {goblin.HP}");
        Console.WriteLine($"DMG: {goblin.DMG}");
        Console.WriteLine($"DEF: {goblin.DEF}");
        
        Console.ReadKey();
    }
}