using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Game_Project
{
    public abstract class Hero
    {
        public string Name;
        private double MaxHealth
        {
            get => Vitality * 10;
        }
        public double _health;
        public double Health
        {
            get { return _health; }
            set
            {
                if (_health >= MaxHealth)
                {
                    _health = MaxHealth;
                }
                if (_health <= 0)
                {
                    _health = 0;
                }
                _health = value;
            }
        }
        private int MaxEnergy
        {
            get => Intelligence * 10;
        }
        public int Energy;
        public int Strength;
        public int Dexterity;
        public int Vitality;
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
        private double _xp;
        public double XP
        {
            get { return _xp; }
            set
            {
                if (_xp >= 100)
                {
                    Console.WriteLine("You Leveled up!");
                    LevelUP();
                }
                _xp = value;
            }
        }
        private int level;

        public virtual void LevelUP()
        {
        }
        public void Attack(Enemy target)
        {
            GameLogic.DamageEnemy(target, Strength);
        }
        public virtual void TakeTurn()
        {

        }
    }
    public class Nightwing : Hero
    {
        public override void LevelUP()
        {
            Random statsIncrease = new Random();
            Strength += statsIncrease.Next(1, 5);
            Vitality += statsIncrease.Next(1, 3);
            Intelligence += statsIncrease.Next(0, 2);
            Dexterity += statsIncrease.Next(0, 3);
            TurnMeter = 0;
        }
        public Nightwing()
        {
            Vitality = 15;
            Intelligence = 5;
            Health = 150;
            Strength = 15;
            Dexterity = 12;
        }
       
    }
    
}
