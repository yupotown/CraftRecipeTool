using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CraftRecipeTool
{
    public class RecipesReader
    {
        public RecipesReader(string path)
        {
            doc.Load(path);
            Items = new List<Item>();
            Recipes = new List<Recipe>();
        }

        public RecipesReader(XmlDocument xml)
        {
            doc = xml;
            Items = new List<Item>();
            Recipes = new List<Recipe>();
        }

        /// <summary>
        /// アイテムとレシピをすべて読み込む。
        /// </summary>
        public void ReadAll()
        {
            ReadItems();
            ReadRecipes();
        }

        /// <summary>
        /// アイテムをすべて読み込む。
        /// </summary>
        public void ReadItems()
        {
            foreach (XmlElement itemsNode in doc.DocumentElement.ChildNodes)
            {
                if (itemsNode.Name != "items") continue;
                foreach (XmlElement itemNode in itemsNode.ChildNodes)
                {
                    if (itemNode.Name != "item") continue;
                    var item = readItem(itemNode);
                    if (itemsSet.Contains(item)) continue;
                    Items.Add(item);
                    itemsSet.Add(item);
                }
            }
        }

        /// <summary>
        /// レシピをすべて読み込む。
        /// </summary>
        public void ReadRecipes()
        {
            foreach (XmlElement recipesNode in doc.DocumentElement.ChildNodes)
            {
                if (recipesNode.Name != "recipes") continue;
                foreach (XmlElement recipeNode in recipesNode.ChildNodes)
                {
                    if (recipeNode.Name != "recipe") continue;
                    var recipe = readRecipe(recipeNode);
                    if (recipesSet.Contains(recipe)) continue;
                    Recipes.Add(recipe);
                    recipesSet.Add(recipe);
                }
            }
        }

        /// <summary>
        /// 読み込んだアイテム一覧
        /// </summary>
        public List<Item> Items { get; private set; }

        /// <summary>
        /// 読み込んだレシピ一覧
        /// </summary>
        public List<Recipe> Recipes { get; private set; }

        private HashSet<Item> itemsSet = new HashSet<Item>();

        private HashSet<Recipe> recipesSet = new HashSet<Recipe>();

        private Item readItem(XmlElement item)
        {
            string name = null;

            foreach (XmlElement node in item.ChildNodes)
            {
                switch (node.Name)
                {
                    case "name":
                        name = node.InnerText;
                        break;
                }
            }

            if (name == null)
            {
                throw new Exception("invalid item");
            }

            return new Item(name);
        }

        private Recipe readRecipe(XmlElement recipe)
        {
            Item target = null;
            int count = 0;
            var reqs = new List<RequiredItem>();

            foreach (XmlElement node in recipe.ChildNodes)
            {
                switch (node.Name)
                {
                    case "target":
                        target = new Item(node.InnerText);
                        break;
                    case "count":
                        count = int.Parse(node.InnerText);
                        break;
                    case "requires":
                        foreach (XmlElement req in node.ChildNodes)
                        {
                            if (req.Name != "require") continue;
                            reqs.Add(readRequiredItem(req));
                        }
                        break;
                }
            }

            if (target == null || count <= 0 || reqs.Count == 0)
            {
                throw new Exception("invalid recipe");
            }

            return new Recipe(target, count, reqs);
        }

        private RequiredItem readRequiredItem(XmlElement req)
        {
            Item item = null;
            int count = 0;

            foreach (XmlElement node in req.ChildNodes)
            {
                switch (node.Name)
                {
                    case "item":
                        item = new Item(node.InnerText);
                        break;
                    case "count":
                        count = int.Parse(node.InnerText);
                        break;
                }
            }

            if (item == null || count <= 0)
            {
                throw new Exception("invalid recipe");
            }

            return new RequiredItem(item, count);
        }

        private XmlDocument doc = new XmlDocument();
    }
}
