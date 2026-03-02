
using DungeonRPG.Entities;

namespace DungeonRPG.Service
{
    public class CombatService
    {
        public void Fight(Hero hero, Monster monster)
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
                Console.WriteLine($" {hero.Name} Won!");
            else
                Console.WriteLine($" {monster.Name} Lost!");
        }

        private static void MonsterTurn(Hero hero, Monster monster) // static nem statik nem teljesen értem !!!
        {
            int dmg = monster.Attack();
            hero.Defend(dmg);
            Console.WriteLine($"{monster.Name} Attack! Damage: {dmg}, {hero.Name} HP: {hero.HP}");
        }

        private static void HeroTurn(Hero hero, Monster monster)
        {
            int dmg = hero.Attack();
            monster.Defend(dmg);
            Console.WriteLine($"{hero.Name} Fight back! Damage: {dmg}, {monster.Name} HP: {monster.HP}");
        }
    }
}