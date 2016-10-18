using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftRecipeTool
{
    public class Recipe
    {
        public Recipe(Item target, List<RequiredItem> requires)
        {
            Target = target;
            Requires = requires;
            Count = 1;
        }

        public Recipe(Item target, int count, List<RequiredItem> requires)
        {
            Target = target;
            Requires = requires;
            Count = count;
        }

        public Item Target { get; }

        public List<RequiredItem> Requires { get; }

        public int Count { get; }

        public override string ToString()
        {
            if (Count == 1)
            {
                return string.Format("{0} [ {1} ]",
                    Target, string.Join(", ", Requires));
            }
            else
            {
                return string.Format("{0} x {1} [ {2} ]",
                    Target, Count, string.Join(", ", Requires));
            }
        }

        public static bool operator ==(Recipe a, Recipe b)
        {
            if ((object)a == null || (object)b == null) return false;
            if (a.Target != b.Target) return false;
            if (a.Count != b.Count) return false;
            if (a.Requires.Count != b.Requires.Count) return false;
            for (int i = 0; i < a.Requires.Count; i++)
            {
                if (a.Requires[i] != b.Requires[i]) return false;
            }
            return true;
        }

        public static bool operator !=(Recipe a, Recipe b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Recipe;
            if (other == null) return false;
            return this == other;
        }

        public override int GetHashCode()
        {
            return Target.GetHashCode() ^ Count.GetHashCode() ^ Requires.GetHashCode();
        }
    }
}
