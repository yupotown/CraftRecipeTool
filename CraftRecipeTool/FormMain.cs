using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        /// <summary>
        /// グラフ生成ボタンが押された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMakeGraph_Click(object sender, EventArgs e)
        {
            if (graph == null)
            {
                MessageBox.Show("グラフがありません。作りたいアイテムと使用するレシピを選択してください。");
                return;
            }

            var dialog = new SaveFileDialog()
            {
                FileName = string.Format("{0}.dot", graph.Root.Item),
                Filter = "dot ファイル|*.dot|すべてのファイル|*.*",
                FilterIndex = 0,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                writeGraph(dialog.FileName);

                var path = Path.ChangeExtension(dialog.FileName, null);
                try
                {
                    var p = Process.Start("dot", string.Format("-Tpng {0}.dot -o {0}.png", path));
                    p.WaitForExit();
                }
                catch (Exception)
                {
                    MessageBox.Show("dotファイルは保存されましたが、画像の生成に失敗しました。");
                }
                Process.Start(string.Format("{0}.png", path));
            }
        }

        private void writeGraph(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("digraph {0} {{", graph.Root.Item);

                // グラフ全体
                writer.WriteLine("\tgraph [label=\"Craft Recipe Tool\"];");
                writer.WriteLine();

                // 辺
                var q = new Queue<CraftGraph.Node>();
                var visited = new HashSet<CraftGraph.Node>();
                q.Enqueue(graph.Root);
                visited.Add(graph.Root);
                while (q.Count != 0)
                {
                    var node = q.Dequeue();
                    foreach (var edge in node.Edges)
                    {
                        writer.WriteLine("\t{0} -> {1} [taillabel=\"{2}\", headlabel=\"{3}\", labelfloat=false];",
                            node.Item,
                            edge.To.Item,
                            node.Unit,
                            edge.Count * node.Unit);
                        if (!visited.Contains(edge.To))
                        {
                            visited.Add(edge.To);
                            q.Enqueue(edge.To);
                        }
                    }
                }
                writer.WriteLine();

                // 頂点
                foreach (var node in visited)
                {
                    writer.WriteLine("{0} [fontname=\"MS UI Gothic\", shape={1}, label=\"{2}\"]",
                        node.Item,
                        (node == graph.Root) ? "box" : "ellipse",
                        string.Format("{0} x {1}", node.Item, node.Requires));
                }

                writer.WriteLine("}");
            }
        }
    }
}
