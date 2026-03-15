using DungeonRPG.Entities;
using DungeonRPG.Service;
using Npgsql;

namespace DungeonRPG
{
    class Program
    {
        static async Task Main(string[] args) // task= feladat async await így használom asszinkron feladatokhoz adatbázis,api meghívás 
        {
            var herolist = new List<Hero>() ;
            var monsters = new List<Monster>();
            var connString = "Host=127.0.0.1;Username=postgres;Password=password;Database=adatbazis";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();
            
            await using (var cmd = new NpgsqlCommand("SELECT name, HP, DMG, DEF from hero", conn)) // "sql parancsok"
            await using (var reader = await cmd.ExecuteReaderAsync()) // readasynn 
            {
                while (await reader.ReadAsync())
                {
                    string name = reader.GetString(0);
                    int hp = reader.GetInt32(1);
                    int dmg = reader.GetInt32(2);
                    int def = reader.GetInt32(3);
                    Hero hero = new Hero(name, hp, dmg, def);
                    herolist.Add(hero);
                }
            }
            
            await using (var cmd = new NpgsqlCommand("SELECT name, HP, DMG, DEF from monster", conn)) // "sql parancsok"
            await using (var reader = await cmd.ExecuteReaderAsync()) // readasynn 
            {
                while (await reader.ReadAsync())
                {
                    string name = reader.GetString(0);
                    int hp = reader.GetInt32(1);
                    int dmg = reader.GetInt32(2);
                    int def = reader.GetInt32(3);
                    Monster monster = new Monster(name, hp, dmg, def);
                    monsters.Add(monster);
                }
            }

            int heroindex = Random.Shared.Next(0, herolist.Count);
            
            Hero selectedHero =  herolist[heroindex];
            
            Potion potion = new Potion(name: "Heal Potion", heal: 5);
            Sword sword = new Sword(name: "Excalibur", 5);
            Console.WriteLine("Character stat:");
            Console.WriteLine($"Name: {selectedHero.Name}");
            Console.WriteLine($"HP: {selectedHero.HP}");
            Console.WriteLine($"DMG: {selectedHero.DMG}");
            Console.WriteLine($"DEF: {selectedHero.DEF}");
            selectedHero.Inventory.Add(potion);
            selectedHero.Inventory.Add(sword);

            int monsterindex = Random.Shared.Next(0, monsters.Count);
            
            Monster selectedMonster =  monsters[monsterindex];
            
            Console.WriteLine("Monster stat:");
            Console.WriteLine($"Name: {selectedMonster.Name}");
            Console.WriteLine($"HP: {selectedMonster.HP}");
            Console.WriteLine($"DMG: {selectedMonster.DMG}");
            Console.WriteLine($"DEF: {selectedMonster.DEF}");
            

            CombatService combat = new CombatService();
            combat.Fight(selectedHero, selectedMonster);


            Console.ReadKey();
        }

    }
}
