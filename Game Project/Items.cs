using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Project
{
    interface IItem
    {
        public string Name { get; set; }
        public int Cost { get; set; } 
        public int Value { get; set; }
        public void Sell();
    }
    interface IConsumable
    {
        public void UseItem();
    }

}
