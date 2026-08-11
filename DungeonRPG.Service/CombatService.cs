
using DungeonRPG.Entities;

namespace DungeonRPG.Service
{
    public class CombatService
    {
        public void Fight(Hero hero, Monster monster, List<Item> items)
        {
            Console.WriteLine($"The fight begins : {hero.Name} vs {monster.Name}\n");

            while (hero.Alive && monster.Alive)
            {
                // Szörny támad először
                MonsterTurn(hero, monster);
                if (!hero.Alive) break;

                HeroTurn(hero, monster);
                Console.WriteLine();
                Thread.Sleep(700); // megáll 700ms-re
            }

            if (hero.Alive)
            {    
                Console.WriteLine($" {hero.Name} Won!");
            
                DropItem(hero, items);
            
            }
            else
                Console.WriteLine($" {monster.Name} Won!");
        }

        private static void MonsterTurn(Hero hero, Monster monster) // static nem statik nem teljesen értem !!!
        {
            int dmg = monster.Attack();
            hero.Defend(dmg);
            Console.WriteLine($"{monster.Name} Attack! Damage: {dmg}, {hero.Name} HP: {hero.HP}");
        }

        private static void HeroTurn(Hero hero, Monster monster)// lila típus fehér változó
        {
            Potion usedPotion = null;

            foreach (var item in hero.Inventory)
            {
                if (item is Potion potion)
                {
                    hero.HP += potion.Heal;
                    Console.WriteLine($"{hero.Name} used {potion.Name} and healed {potion.Heal} HP");
                    usedPotion = potion;
                    break;
                }
            }

            if (usedPotion != null)
                hero.Inventory.Remove(usedPotion);

            
            int dmg = hero.Attack();
            if (hero.EquippedSword != null)
            {
                dmg += hero.EquippedSword.Damage;

                Console.WriteLine(
                    $"{hero.Name} uses {hero.EquippedSword.Name}! Bonus damage: {hero.EquippedSword.Damage}");
            }
            
            monster.Defend(dmg);
            Console.WriteLine($"{hero.Name} Fight back! Damage: {dmg}, {monster.Name} HP: {monster.HP}");
        }
        
        private static void DropItem(Hero hero, List<Item> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items available.");
                return;
            }

            int index = Random.Shared.Next(0, items.Count);
            Item droppedItem = items[index];

            hero.Inventory.Add(droppedItem);

            Console.WriteLine($"{droppedItem.Name} dropped!");
            
            if (droppedItem is Sword sword)
            {
                hero.EquipSword(sword);
            }
            
        }
    }
    
    
}