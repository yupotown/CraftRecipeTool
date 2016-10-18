using CraftRecipeTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace RecipeEditor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private Dictionary<string, Item> allItems = new Dictionary<string, Item>();

        private Dictionary<string, List<Recipe>> allRecipes = new Dictionary<string, List<Recipe>>();

        private List<ComboBox> comboBoxRecipes = new List<ComboBox>();
        private List<NumericUpDown> upDownRecipes = new List<NumericUpDown>();

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxRecipes = new List<ComboBox>
            {
                comboBoxRecipe1, comboBoxRecipe2, comboBoxRecipe3,
                comboBoxRecipe4, comboBoxRecipe5, comboBoxRecipe6,
                comboBoxRecipe7, comboBoxRecipe8, comboBoxRecipe9,
            };
            upDownRecipes = new List<NumericUpDown>
            {
                upDownRecipe1, upDownRecipe2, upDownRecipe3,
                upDownRecipe4, upDownRecipe5, upDownRecipe6,
                upDownRecipe7, upDownRecipe8, upDownRecipe9,
            };
        }

        private void load(string path)
        {
            var reader = new RecipesReader(path);
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
        }

        private void save(string path)
        {
            var writer = new RecipesWriter(path);
            writer.Items = allItems.Select(kv => kv.Value).ToList();
            writer.Recipes = allRecipes.SelectMany(kv => kv.Value).ToList();
            writer.Write();
        }

        private void update()
        {
            var selItem = (Item)listBoxItem.SelectedItem;
            var selItemsRecipe = Enumerable.Range(0, 9).Select(i => (Item)comboBoxRecipes[i].SelectedItem).ToList();
            var selRecipe = (Recipe)listBoxRecipe.SelectedItem;
            listBoxItem.Items.Clear();
            for (int i = 0; i < 9; i++)
            {
                comboBoxRecipes[i].Items.Clear();
            }
            foreach (var kv in allItems)
            {
                listBoxItem.Items.Add(kv.Value);
                if (kv.Value == selItem)
                {
                    listBoxItem.SelectedIndex = listBoxItem.Items.Count - 1;
                }
                for (int i = 0; i < 9; i++)
                {
                    comboBoxRecipes[i].Items.Add(kv.Value);
                    if (kv.Value == selItemsRecipe[i])
                    {
                        comboBoxRecipes[i].SelectedIndex = comboBoxRecipes[i].Items.Count - 1;
                    }
                }
            }
            listBoxRecipe.Items.Clear();
            foreach (var recipe in allRecipes.SelectMany(kv => kv.Value))
            {
                if (!checkBoxSelectedOnly.Checked || recipe.Target == selItem)
                {
                    listBoxRecipe.Items.Add(recipe);
                    if (recipe == selRecipe)
                    {
                        listBoxRecipe.SelectedIndex = listBoxRecipe.Items.Count - 1;
                    }
                }
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            allItems = new Dictionary<string, Item>();
            allRecipes = new Dictionary<string, List<Recipe>>();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "XML ファイル|*.xml|すべてのファイル|*.*",
                FilterIndex = 0,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                load(dialog.FileName);
                update();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog()
            {
                Filter = "XML ファイル|*.xml|すべてのファイル|*.*",
                FilterIndex = 0,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                save(dialog.FileName);
                update();
            }
        }

        private void checkBoxSelectedOnly_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void buttonItemAdd_Click(object sender, EventArgs e)
        {
            addItem();
        }

        private void buttonItemDel_Click(object sender, EventArgs e)
        {
            removeItem();
        }

        private void addItem()
        {
            var name = textBoxItemName.Text;
            if (name == "")
            {
                MessageBox.Show("アイテム名を入力してください。");
                return;
            }
            if (allItems.ContainsKey(name))
            {
                MessageBox.Show("そのアイテムは既に存在しています。");
                return;
            }
            allItems.Add(name, new Item(name));
            update();
            textBoxItemName.Clear();
            textBoxItemName.Focus();
        }

        private void removeItem()
        {
            var item = (Item)listBoxItem.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("アイテムを選択してください。");
                return;
            }
            if (allRecipes.SelectMany(kv => kv.Value)
                .Any(recipe => recipe.Target == item || recipe.Requires.Any(req => req.Item == item)))
            {
                var res = MessageBox.Show("関連するレシピも削除されます。よろしいですか？", "", MessageBoxButtons.YesNo);
                if (res != DialogResult.Yes)
                {
                    return;
                }
            }
            allRecipes.Remove(item.Name);
            foreach (var kv in allRecipes)
            {
                kv.Value.RemoveAll(recipe => recipe.Requires.Any(req => req.Item == item));
            }
            allItems.Remove(item.Name);
            update();
        }

        private void textBoxItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addItem();
            }
        }

        private void buttonRecipeAdd_Click(object sender, EventArgs e)
        {
            var target = (Item)listBoxItem.SelectedItem;
            if (target == null)
            {
                MessageBox.Show("作成対象のアイテムを選択してください。");
                return;
            }
            var count = (int)upDownRecipeCount.Value;
            var reqs = new List<RequiredItem>();
            for (int i = 0; i < 9; i++)
            {
                var reqItem = (Item)comboBoxRecipes[i].SelectedItem;
                var reqCount = (int)upDownRecipes[i].Value;
                if (reqItem == null || reqCount == 0) continue;
                reqs.Add(new RequiredItem(reqItem, reqCount));
            }
            if (reqs.Count == 0)
            {
                MessageBox.Show("素材と個数を入力してください。");
                return;
            }
            if (!allRecipes.ContainsKey(target.Name))
            {
                allRecipes.Add(target.Name, new List<Recipe>());
            }
            allRecipes[target.Name].Add(new Recipe(target, count, reqs));
            update();
        }

        private void buttonRecipeDel_Click(object sender, EventArgs e)
        {
            var recipe = (Recipe)listBoxRecipe.SelectedItem;
            if (recipe == null)
            {
                MessageBox.Show("レシピを選択してください。");
                return;
            }
            allRecipes[recipe.Target.Name].Remove(recipe);
            update();
        }
    }
}
