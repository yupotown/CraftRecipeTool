using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftRecipeTool
{
    public class RequiredItem
    {
        public RequiredItem(Item item, int count)
        {
            Item = item;
            Count = count;
        }

        public Item Item { get; }

        public int Count { get; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Item, Count);
        }
    }
}
