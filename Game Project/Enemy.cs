using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Project
{

     public abstract class Enemy
    {
       public Random randomStats = new Random();
       public string Name;
       public double Health;
       public int Strength;
       public int Armor;
       public int Intelligence;
       public int Level;
        public int _turnMeter;
       public int TurnMeter
        {
            get { return _turnMeter; }
            set
            {
                if (_turnMeter >= 100)
                {
                    _turnMeter = 100;
                }
                _turnMeter = value;
            }
        }
        public int Dexterity;
      
        public void Attack(Hero target)
        {
            GameLogic.DamageHero(target, Strength);
        }

    }
    public class PenguinThug : Enemy 
    {

        public PenguinThug(int level)
        {
            Name = "Penguin Thug";
            Health = randomStats.Next(30,40) + (randomStats.Next(0,5)*level);
            TurnMeter = 0;
            Dexterity = randomStats.Next(6,10);
            Strength = randomStats.Next(4,7);
            Level = level;
        }
    }
    public class EmperorPenguinThug : Enemy
    {
        public EmperorPenguinThug(int level)
        {
            Health = 50;
            TurnMeter = 0;
            Dexterity = 6;
            Strength = 8;
            Level = level;
        }
    }
}
