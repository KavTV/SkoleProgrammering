using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    class Hero
    {
        private string heroName;
        private int hitpoints;
        private int attackRangeMin;
        private int attackRangeMax;
        private int defenceRangeMin;
        private int defenceRangeMax;

        public string HeroName { get{ return heroName; } set { heroName = value; } }
        public int Hitpoints { get { return hitpoints; } set { hitpoints = value; } }
        public int AttackRangeMin { get { return attackRangeMin; } set { attackRangeMin = value; } }
        public int AttackRangeMax { get { return attackRangeMax; } set { attackRangeMax = value; } }
        public int DefenceRangeMin { get { return defenceRangeMin; } set { defenceRangeMin = value; } }
        public int DefenceRangeMax { get { return defenceRangeMax; } set { defenceRangeMax = value; } }




        public Hero(string name, int hitpoints, int attackRangeMin, int attackRangeMax, int defenceRangeMin, int defenceRangeMax) // create the hero
        {
            heroName = name;
            this.hitpoints = hitpoints;
            this.attackRangeMin = attackRangeMin;
            this.attackRangeMax = attackRangeMax;
            this.defenceRangeMin = defenceRangeMin;
            this.defenceRangeMax = defenceRangeMax;


        }

        public Hero() { } // default constructor




    }
}
