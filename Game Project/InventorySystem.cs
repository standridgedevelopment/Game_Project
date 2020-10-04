using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Project
{
    public static class InventorySystem
    {
        public static readonly List<InventoryRecord> InventoryRecords = new List<InventoryRecord>();

        public static void AddItem(IItem item)
        {
            if (InventoryRecords.Exists(x => (x.InventoryItem.ID == item.ID)))
            {
                // Get the item we're going to add quantity to
                InventoryRecord inventoryRecord =
                InventoryRecords.First(x => (x.InventoryItem.ID == item.ID));
                inventoryRecord.InventoryItem.Quanity += 1;
            }
            else
            {
                InventoryRecords.Add(new InventoryRecord(item));
                item.Quanity = 1;
            }
        }
        public static void RemoveItem(IItem item)
        {
            if (InventoryRecords.Exists(x => (x.InventoryItem.ID == item.ID)))
            {
                // Get the item we're going to add quantity to
                InventoryRecord inventoryRecord =
                InventoryRecords.First(x => (x.InventoryItem.ID == item.ID));
                InventoryRecords.Remove(inventoryRecord);
            }
        }
    }

        public class InventoryRecord
        {
            public IItem InventoryItem { get; private set; }


            public InventoryRecord(IItem item)
            {
                InventoryItem = item;
            }
        }
}
