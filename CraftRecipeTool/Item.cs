using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftRecipeTool
{
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(Item a, Item b)
        {
            if ((object)a == null || (object)b == null) return false;
            return a.Name == b.Name;
        }

        public static bool operator !=(Item a, Item b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Item;
            if (other == null) return false;
            return this == other;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
