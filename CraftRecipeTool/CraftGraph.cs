using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftRecipeTool
{
    public class CraftGraph
    {
        public CraftGraph(Item rootItem, Rational count)
        {
            Root = new Node(rootItem);
            Root.Count = count;
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
                Count = 0;
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
            public Rational Count { get; set; }
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
            var q = new Queue<Node>();
            q.Enqueue(Root);
            while (q.Count() != 0)
            {
                var t = q.Dequeue();
                if (t.Edges.Count() == 0)
                {
                    res.Add(t);
                }
                else
                {
                    foreach (var s in t.Edges)
                    {
                        q.Enqueue(s.To);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 素材や中間素材の必要数を計算する。
        /// </summary>
        public void UpdateCount()
        {
            var visited = new HashSet<Node>();
            var q = new Queue<Node>();
            q.Enqueue(Root);
            visited.Add(Root);
            while (q.Count() != 0)
            {
                var node = q.Dequeue();
                foreach (var edge in node.Edges)
                {
                    var cnt = node.Count * edge.Count;
                    if (!visited.Contains(edge.To))
                    {
                        edge.To.Count = cnt;
                        q.Enqueue(edge.To);
                        visited.Add(edge.To);
                    }
                    else
                    {
                        edge.To.Count += cnt;
                    }
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
    }
}
