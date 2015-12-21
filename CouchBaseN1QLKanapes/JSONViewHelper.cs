using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CouchBaseN1QLKanapes
{
    class JSONViewHelper
    {
        public void LoadJsonToTreeView(TreeView _treeView, string _json)
        {
            if (string.IsNullOrWhiteSpace(_json))
            {
                return;
            }
            try
            {
                _treeView.Nodes.Clear();
                var @object = JObject.Parse(_json);
                AddObjectNodes(@object, "object", _treeView.Nodes);
            }
            catch (Exception ex)
            {
                try
                {
                    var @object = JArray.Parse(_json);
                    AddObjectNodes(@object, "array", _treeView.Nodes);
                }
                catch (Exception ex1)
                {
                    //logOutput(ex1.Message, true);
                }
            }


        }

        void AddObjectNodes(JArray array, string name, TreeNodeCollection parent)
        {
            var node = new TreeNode(name);
            parent.Add(node);

            for (var i = 0; i < array.Count; i++)
            {
                AddTokenNodes(array[i], string.Format("[{0}]", i), node.Nodes);
            }
        }

        void AddObjectNodes(JObject @object, string name, TreeNodeCollection parent)
        {
            var node = new TreeNode(name);
            parent.Add(node);

            foreach (var property in @object.Properties())
            {
                AddTokenNodes(property.Value, property.Name, node.Nodes);
            }
        }

        void AddArrayNodes(JArray array, string name, TreeNodeCollection parent)
        {
            var node = new TreeNode(name);
            parent.Add(node);

            for (var i = 0; i < array.Count; i++)
            {
                AddTokenNodes(array[i], string.Format("[{0}]", i), node.Nodes);
            }
        }

        void AddTokenNodes(JToken token, string name, TreeNodeCollection parent)
        {
            if (token is JValue)
            {
                parent.Add(new TreeNode(string.Format("{0}: {1}", name, ((JValue)token).Value)));
            }
            else if (token is JArray)
            {
                AddArrayNodes((JArray)token, name, parent);
            }
            else if (token is JObject)
            {
                AddObjectNodes((JObject)token, name, parent);
            }
        }
    }
}
