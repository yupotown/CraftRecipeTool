using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraftRecipeTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// すべてのアイテム一覧
        /// </summary>
        private Dictionary<string, Item> allItems = new Dictionary<string, Item>();

        /// <summary>
        /// すべてのレシピ一覧
        /// </summary>
        private Dictionary<string, List<Recipe>> allRecipes = new Dictionary<string, List<Recipe>>();

        /// <summary>
        /// すべてのアイテム一覧にアイテムを追加する。
        /// </summary>
        /// <param name="item"></param>
        private void addItem(Item item)
        {
            allItems.Add(item.Name, item);
        }

        /// <summary>
        /// すべてのレシピ一覧にレシピを追加する。
        /// </summary>
        /// <param name="recipe"></param>
        private void addRecipe(Recipe recipe)
        {
            if (allRecipes.ContainsKey(recipe.Target.Name))
            {
                allRecipes[recipe.Target.Name].Add(recipe);
            }
            else
            {
                allRecipes.Add(recipe.Target.Name, new List<Recipe> { recipe });
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // debug
            addItem(new Item("原木"));
            addItem(new Item("木材"));
            addItem(new Item("棒"));
            addItem(new Item("石炭"));
            addItem(new Item("松明"));

            addRecipe(new Recipe(allItems["木材"], 4, new List<RequiredItem>
            {
                new RequiredItem(allItems["原木"], 1),
            }));
            addRecipe(new Recipe(allItems["棒"], 4, new List<RequiredItem>
            {
                new RequiredItem(allItems["木材"], 2),
            }));
            addRecipe(new Recipe(allItems["松明"], 4, new List<RequiredItem>
            {
                new RequiredItem(allItems["石炭"], 1),
                new RequiredItem(allItems["棒"], 1),
            }));

            updateListToMake();
        }

        /// <summary>
        /// 作れるもの一覧のコンボボックスを更新
        /// </summary>
        private void updateListToMake()
        {
            comboBoxToMake.Items.Clear();
            comboBoxToMake.Items.AddRange(allItems.Select(kv => kv.Value).ToArray());
        }

        /// <summary>
        /// 作れるもの一覧のコンボボックスの選択が変更された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxToMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Item)comboBoxToMake.SelectedItem;
            listBoxMaterial.Items.Clear();
            listBoxMaterial.Items.Add(new RequiredItem(item, 1));
        }

        /// <summary>
        /// 素材一覧のリストボックスの選択が変更された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ri = (RequiredItem)listBoxMaterial.SelectedItem;
            listBoxRecipe.Items.Clear();
            if (allRecipes.ContainsKey(ri.Item.Name))
            {
                listBoxRecipe.Items.AddRange(allRecipes[ri.Item.Name].ToArray());
            }
        }
    }
}
