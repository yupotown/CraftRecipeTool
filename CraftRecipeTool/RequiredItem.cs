using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftRecipeTool
{
    public class RequiredItem
    {
        public RequiredItem(Item item, Rational count)
        {
            Item = item;
            Count = count;
        }

        public Item Item { get; }

        public Rational Count { get; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Item, Count);
        }

        public static bool operator ==(RequiredItem a, RequiredItem b)
        {
            if ((object)a == null || (object)b == null) return false;
            return a.Item == b.Item && a.Count == b.Count;
        }

        public static bool operator !=(RequiredItem a, RequiredItem b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var other = obj as RequiredItem;
            if (other == null) return false;
            return this == other;
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode() ^ Count.GetHashCode();
        }
    }
}
