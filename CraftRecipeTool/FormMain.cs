using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        /// <summary>
        /// アイテム作成の素材の関係を表すグラフ
        /// </summary>
        private CraftGraph graph;

        private void FormMain_Load(object sender, EventArgs e)
        {
            updateComboBoxToMake();
        }

        /// <summary>
        /// 作れるもの一覧のコンボボックスを更新
        /// </summary>
        private void updateComboBoxToMake()
        {
            comboBoxToMake.Items.Clear();
            comboBoxToMake.Items.AddRange(allItems.Select(kv => kv.Value).ToArray());
        }

        /// <summary>
        /// 素材一覧のリストボックスを更新
        /// </summary>
        private void updateListBoxMaterial()
        {
            listBoxMaterial.Items.Clear();
            if (graph == null) return;
            foreach (var leaf in graph.GetLeaves())
            {
                listBoxMaterial.Items.Add(new RequiredItem(leaf.Item, leaf.Requires));
            }
            listBoxRecipe.Items.Clear();
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
            if (item == null) return;

            // グラフの更新
            graph = new CraftGraph(item, 1);

            updateListBoxMaterial();
            listBoxMaterial.SelectedIndex = 0;
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
            if (ri == null) return;
            if (allRecipes.ContainsKey(ri.Item.Name))
            {
                listBoxRecipe.Items.AddRange(allRecipes[ri.Item.Name].ToArray());
            }
        }

        /// <summary>
        /// レシピ一覧のリストボックスがダブルクリックされた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxRecipe_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = listBoxRecipe.IndexFromPoint(e.Location);
            if (index == -1) return;
            var recipe = (Recipe)listBoxRecipe.Items[index];

            // グラフの更新
            graph.ApplyRecipe(recipe);

            updateListBoxMaterial();
        }

        /// <summary>
        /// アイテム・レシピ読み込みボタンが押された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadRecipe_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "XML ファイル|*.xml|すべてのファイル|*.*",
                FilterIndex = 0,
                Title = "アイテム・レシピ読み込み",
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var reader = new RecipesReader(dialog.FileName);
                reader.ReadAll();
                foreach (var item in reader.Items)
                {
                    if (!allItems.ContainsKey(item.Name))
                    {
                        allItems.Add(item.Name, item);
                    }
                }
                foreach (var recipe in reader.Recipes)
                {
                    if (!allRecipes.ContainsKey(recipe.Target.Name))
                    {
                        allRecipes.Add(recipe.Target.Name, new List<Recipe>());
                    }
                    if (!allRecipes[recipe.Target.Name].Contains(recipe))
                    {
                        allRecipes[recipe.Target.Name].Add(recipe);
                    }
                }
                updateComboBoxToMake();
            }
        }
    }
}
