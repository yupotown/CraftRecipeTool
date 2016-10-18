using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftRecipeTool
{
    public class CraftGraph
    {
        public CraftGraph(Item rootItem, int count)
        {
            Root = new Node(rootItem);
            Root.Requires = count;
            dicNodes.Add(rootItem, Root);
        }

        /// <summary>
        /// グラフの頂点
        /// </summary>
        public class Node
        {
            public Node(Item item)
            {
                Item = item;
                Edges = new List<Edge>();
                Requires = 0;
                Unit = 1;
            }

            /// <summary>
            /// 頂点から出る辺
            /// </summary>
            public struct Edge
            {
                public Node To;
                public Rational Count;
            }

            /// <summary>
            /// この頂点に対応するアイテム
            /// </summary>
            public Item Item { get; set; }

            /// <summary>
            /// この頂点から出る辺
            /// </summary>
            public List<Edge> Edges { get; set; }

            /// <summary>
            /// この頂点に対応するアイテムの必要数
            /// </summary>
            public int Requires { get; set; }

            /// <summary>
            /// この頂点に対応するアイテムを作成するレシピで一度に作られる個数
            /// </summary>
            public int Unit { get; set; }
        }

        /// <summary>
        /// 最終的に作りたいアイテムに対応する頂点
        /// </summary>
        public Node Root { get; }

        /// <summary>
        /// 素材を作るためのレシピを設定する。
        /// </summary>
        /// <param name="recipe"></param>
        public void ApplyRecipe(Recipe recipe)
        {
            if (!dicNodes.ContainsKey(recipe.Target))
            {
                throw new InvalidOperationException();
            }
            var node = dicNodes[recipe.Target];
            if (node.Edges.Count() != 0)
            {
                throw new InvalidOperationException();
            }
            node.Unit = recipe.Count;
            foreach (var req in recipe.Requires)
            {
                Node to;
                if (dicNodes.ContainsKey(req.Item))
                {
                    to = dicNodes[req.Item];
                }
                else
                {
                    to = new Node(req.Item);
                    dicNodes.Add(req.Item, to);
                }
                node.Edges.Add(new Node.Edge
                {
                    To = to,
                    Count = (Rational)req.Count / recipe.Count,
                });
            }
            UpdateCount();
        }

        /// <summary>
        /// 必要な素材一覧を取得する。
        /// </summary>
        /// <returns></returns>
        public List<Node> GetLeaves()
        {
            var res = new List<Node>();
            tsort(Root);
            return tsortRes.Where(node => node.Edges.Count == 0).ToList();
        }

        /// <summary>
        /// 素材や中間素材の必要数を計算する。
        /// </summary>
        public void UpdateCount()
        {
            tsort(Root);
            var tempCnt = new Dictionary<Node, Rational>();
            foreach (var node in tsortRes)
            {
                tempCnt.Add(node, 0);
            }
            tempCnt[Root] = Root.Requires;
            foreach (var node in tsortRes)
            {
                node.Requires = (tempCnt[node] / node.Unit).RoundUp() * node.Unit;
                foreach (var edge in node.Edges)
                {
                    tempCnt[edge.To] += node.Requires * edge.Count;
                }
            }
        }

        /// <summary>
        /// 指定したアイテムがグラフに含まれているか否かを取得する。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(Item item)
        {
            return dicNodes.ContainsKey(item);
        }

        private Dictionary<Item, Node> dicNodes = new Dictionary<Item, Node>();

        /// <summary>
        /// トポロジカルソート
        /// </summary>
        /// <returns></returns>
        private void tsort(Node node)
        {
            if (node == Root)
            {
                tsortRes = new LinkedList<Node>();
                tsortVisited = new HashSet<Node>();
            }
            if (tsortVisited.Contains(node))
            {
                return;
            }
            tsortVisited.Add(node);
            foreach (var edge in node.Edges)
            {
                tsort(edge.To);
            }
            tsortRes.AddFirst(node);
        }

        private LinkedList<Node> tsortRes;
        private HashSet<Node> tsortVisited;
    }
}
