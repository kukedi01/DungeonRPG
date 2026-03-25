using DungeonRPG.Entities;
using DungeonRPG.Service;
using Npgsql;

namespace DungeonRPG
{
    class Program
    {
        private static string connString = "Host=127.0.0.1;Username=postgres;Password=password;Database=adatbazis"; // osztály szintű
        
        static async Task Main(string[] args) // task= feladat async await így használom asszinkron feladatokhoz adatbázis,api meghívás 
        {
            var herolist = await LoadHeroesAsync() ; //asyncron metódusokat await-el hívom meg (adatbázis lekérdezés,API,fájl olvasás,hálózati művelet)
            var monsters = await LoadMonsterAsync() ; //asyncron műveletek nem blokkolják a programot hagyják futni
            var items = await LoadItemAsync();
            
            
            
            int heroindex = Random.Shared.Next(0, herolist.Count);
            
            Hero selectedHero =  herolist[heroindex];
            
            
            
            Console.WriteLine("Character stat:");
            Console.WriteLine($"Name: {selectedHero.Name}");
            Console.WriteLine($"HP: {selectedHero.HP}");
            Console.WriteLine($"DMG: {selectedHero.DMG}");
            Console.WriteLine($"DEF: {selectedHero.DEF}");
           
            
            // Itt dobjuk a “kockát” és adunk tárgyat
            // Dobókocka - pl. 1–8 érték
            Random rnd = new Random();
            int dice = rnd.Next(1, 10);
            Console.WriteLine($"Dobott érték: {dice}");

            if(items.Count > 0)
            {
                // A dobott érték alapján választjuk ki a tárgyat
                int index = (dice - 1) % items.Count; // biztos, hogy nem lép túl a lista méretén
                Item droppedItem = items[index];
    
                selectedHero.Inventory.Add(droppedItem);
                Console.WriteLine($"A hős kapott egy tárgyat: {droppedItem.Name}");
                
                Console.WriteLine("\nInventory:");

                foreach (var item in selectedHero.Inventory)
                {
                    Console.WriteLine(item.Name);
                }
                
            }
            else
            {
                Console.WriteLine("Nincs elérhető tárgy az inventoryhoz.");
            }
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

        static async Task<List<Hero>> LoadHeroesAsync()
        {
            var herolist = new List<Hero>() ;
            
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
            // ide kell az adatbázist meghivni
            
            
            return herolist;
        }
        
        static async Task<List<Monster>> LoadMonsterAsync()
        {
            var monsters = new List<Monster>();
            
            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();
            
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
            
            return monsters;
        }
            
        static async Task<List<Item>> LoadItemAsync()          
        {
            var items = new List<Item>();
    
            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();
    
            await using var cmd = new NpgsqlCommand(
                "SELECT item.name, item.type, item_property.name, item_property.value " +
                "FROM item " +
                "JOIN item_property ON item.id = item_property.itemid", conn);
    
            await using var reader = await cmd.ExecuteReaderAsync();
            {
                while (await reader.ReadAsync())
                {
                    string name = reader.GetString(0);
                    string type = reader.GetString(1);
                    string property = reader.GetString(2);
                    int value = int.Parse(reader.GetString(3)); 

                    Item item;

                    // Potion létrehozása heal property alapján
                    if (type == "potion" && property == "heal")
                    {
                        item = new Potion(name, value);
                    }
                    // Sword létrehozása damage property alapján
                    else if (type == "sword" && property == "damage")
                    {
                        item = new Sword(name, value);
                    }
                    else
                    {
                        continue; // minden más property-t kihagy
                    }

                    items.Add(item);
                }
            }

            return items;
        }
    }
    }

//2026.03.15
// postgree sql átnézni végig őket (update delete)
//adatbázisba felvenni a potion (különböző mérték) és sword 5 típus (item property name=damege )
//kódban ne legyen adat (excalibur) adatbázisból betöltve
//item lista (sword+potion) betöltöm az itemeket, item type vizsgálni ha típus sword azt rakja be(if else), hibás item típus if else 
// kocka dobás mit kap hero inventory belerakjuk a selected itemet, consolra kiíratni 