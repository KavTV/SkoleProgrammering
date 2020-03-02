using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FightArena
{
    class Arena
    {
        //Hero hero1;
        //Hero hero2;
        int kattenTiger = 9;

        //public Arena(Hero hero1, Hero hero2)
        //{
        //    this.hero1 = hero1;
        //    this.hero2 = hero2;
            
        //}

        public Arena() { } // default Arena constructor
        public Hero StartFight(Hero hero1, Hero hero2) // starts a fight between the 2 heroes and returns the winner
        {
            int hero1hitpoints = hero1.Hitpoints; // saves the hitpoins, to reset when player won.
            int hero2hitpoints = hero2.Hitpoints; 
            while (hero1.Hitpoints > 0 && hero2.Hitpoints > 0) // will run while both heroes still have health
            {
                Attack(hero1, hero2); // calls attack method
                Attack(hero2, hero1);
            }
            if (hero1.Hitpoints > 0)
            {
                Console.WriteLine("{0} vandt kampen!", hero1.HeroName);
                hero1.Hitpoints = hero1hitpoints; // reset hitpoints
                return hero1; // return the winning hero
            }
            else
            {
                Console.WriteLine("{0} vandt kampen!", hero2.HeroName);
                hero2.Hitpoints = hero2hitpoints; // reset hitpoints
                return hero2; // return the winning hero
            }

        }

        void Attack(Hero hero1, Hero hero2) // hero1 attacks hero2
        {
            Random defenceRange = new Random();
            Random attackRange = new Random();
            int defence = defenceRange.Next(hero2.DefenceRangeMin, hero2.DefenceRangeMax); // determins the defence from the range
            int attack = attackRange.Next(hero1.AttackRangeMin, hero1.AttackRangeMax); // determins the attack from the range
            int damage = defence - attack; // calculates the damage to give
            if (damage < 0) // If damage is below 0, make sure it does not give the player health points
            {
                damage = 0;
            }

            hero2.Hitpoints = hero2.Hitpoints - damage; // give the damage to opponent

            if (kattenTiger > 0 && hero1.HeroName == "Katten Tiger") // If Katten Tiger still has extra health left plus HP with 3
            {
                kattenTiger--;
                hero1.Hitpoints = hero1.Hitpoints + 3;
            }
            else if (kattenTiger > 0 && hero2.HeroName == "Katten Tiger")// If Katten Tiger still has extra health left plus HP with 3
            {
                kattenTiger--;
                hero2.Hitpoints = hero2.Hitpoints + 3;
            }
            Console.WriteLine("{0} har {1} liv tilbage!", hero2.HeroName, hero2.Hitpoints);
            Thread.Sleep(100);
        }


    }
}
