using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CraftRecipeTool
{
    public class RecipesWriter
    {
        public RecipesWriter(string path)
        {
            Path = path;
        }

        public List<Item> Items { get; set; }

        public List<Recipe> Recipes { get; set; }

        public void Write()
        {
            var doc = new XmlDocument();

            var items = doc.CreateElement("items");
            foreach (var item in Items)
            {
                items.AppendChild(makeItemNode(doc, item));
            }

            var recipes = doc.CreateElement("recipes");
            foreach (var recipe in Recipes)
            {
                recipes.AppendChild(makeRecipeNode(doc, recipe));
            }

            var root = doc.CreateElement("creaft_recipe");
            root.AppendChild(items);
            root.AppendChild(recipes);
            doc.AppendChild(root);

            doc.Save(Path);
        }

        public string Path { get; private set; }

        private XmlElement makeItemNode(XmlDocument doc, Item item)
        {
            var res = doc.CreateElement("item");
            var name = doc.CreateElement("name");
            name.InnerText = item.Name;
            res.AppendChild(name);
            return res;
        }

        private XmlElement makeRecipeNode(XmlDocument doc, Recipe recipe)
        {
            var res = doc.CreateElement("recipe");
            var target = doc.CreateElement("target");
            target.InnerText = recipe.Target.Name;
            var count = doc.CreateElement("count");
            count.InnerText = recipe.Count.ToString();
            var requires = doc.CreateElement("requires");
            foreach (var req in recipe.Requires)
            {
                var require = doc.CreateElement("require");
                var reqItem = doc.CreateElement("item");
                reqItem.InnerText = req.Item.Name;
                var reqCount = doc.CreateElement("count");
                reqCount.InnerText = req.Count.ToString();
                require.AppendChild(reqItem);
                require.AppendChild(reqCount);
                requires.AppendChild(require);
            }
            res.AppendChild(target);
            res.AppendChild(count);
            res.AppendChild(requires);
            return res;
        }
    }
}
