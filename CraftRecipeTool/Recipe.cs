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
    }
}
