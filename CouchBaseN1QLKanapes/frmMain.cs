using Couchbase;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using CouchBaseN1QLKanapes.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CouchBaseN1QLKanapes
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Text += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                this.Run();
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            this.Run();
        }



        private void logResults(string _value, bool _appentText = true)
        {
            if (!_appentText)
            {
                this.txt_result.Text = "";
            }
            this.txt_result.AppendText(_value + Environment.NewLine);
        }

        private void logOutput(string _value, bool _appentText = true)
        {
            if (!_appentText)
            {
                this.txt_Output.Text = "";
            }
            this.txt_Output.AppendText(DateTime.Now.ToString() + " -> " + _value + Environment.NewLine);
        }

        //delegate void SetTextCallback(string _value, bool _appentText = true);

        //private void SetTextlogOutput(string _value, bool _appentText = true)
        //{
        //    if (this.txt_result.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(SetTextlogOutput);
        //        this.Invoke(d, new object[] { _value, _appentText });
        //    }
        //    else
        //    {
        //        this.txt_result.Text = _value;
        //    }
        //}

        private void txt_Output_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.txt_Output.Text = "";
        }

        private void tls_results_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.txt_result.Text = "";
        }

        private void btn_About_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Empty for now...");
        }
        string n1qlStr = "";
        private void Run()
        {
            if (this.txt_n1qlCmd.SelectedText == "" && this.txt_n1qlCmd.Text == "")
            {
                string s = "A big nothing was send to Couchbase...";
                this.logOutput(s);
                return;
            }
            //string n1qlStr = "";

            if (this.txt_n1qlCmd.SelectedText != "")
            {
                n1qlStr = this.txt_n1qlCmd.SelectedText;
            }
            else
            {
                n1qlStr = this.txt_n1qlCmd.Text;
            }

            this.Cursor = Cursors.WaitCursor;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                this.logOutput(n1qlStr);
                this.n1qlRun();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                this.logOutput(ex.Message);
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            string elapsedTime = TimeSpan.FromMilliseconds(elapsedMs).ToString(@"hh\:mm\:ss\.fff") + " ms"; ;
            this.txt_elapsedTime.Text = elapsedTime;
            this.logOutput(elapsedTime);
            this.Cursor = Cursors.Default;
        }
        public static async Task<Couchbase.N1QL.IQueryResult<dynamic>> asyncQuery(string _value, IBucket _bucket)
        {
            var result = await _bucket.QueryAsync<dynamic>(_value);
            return result;
        }
        private void n1qlRun()
        {
            var config = new ClientConfiguration
            {
                Servers = new List<Uri>
                      {
                        //new Uri("http://10.124.10.116:8091/pools"),
                        new Uri("http://192.168.1.3:8091/pools"),
                      }
            };
            //Async
            //var cluster = new Cluster(config);
            //var bucket = cluster.OpenBucket();
            //Task<Couchbase.N1QL.IQueryResult<dynamic>> longRunningTask = asyncQuery(n1qlStr, bucket);
            //Couchbase.N1QL.IQueryResult<dynamic> result = await longRunningTask;

            using (var cluster = new Cluster(config))
            {
                IBucket bucket = null;
                try
                {
                    this.logResults("", false);
                    //use the bucket here
                    using (bucket = cluster.OpenBucket())
                    {
                        n1qlStr = n1qlStr + " LIMIT " + this.num_Limit.Value.ToString();
                        var result = bucket.Query<dynamic>(n1qlStr);
                        if (!result.Success)
                        {
                            throw new Exception(result.Exception.ToString());
                        }
                       
                        //foreach (var row in result.Rows)
                        //{
                        //    this.logResults(row.ToString());
                        //    SetJson2Tree(row.ToString());
                        //}
                        string jsonResult = JsonConvert.SerializeObject(result.Rows, Formatting.Indented);
                        this.logResults(jsonResult);
                        this.SetJson2Tree(jsonResult);
                    }
                }
                finally
                {
                    if (bucket != null)
                    {
                        cluster.CloseBucket(bucket);
                    }
                }
            }

        }

        private void SetJson2Tree(string _s)
        {
            this.tvw_JSON.Nodes.Clear();
            this.LoadJsonToTreeView(this.tvw_JSON, _s);
        }


        void LoadJsonToTreeView(TreeView treeView, string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }
            try {
                var @object = JObject.Parse(json);
                AddObjectNodes(@object, "object", treeView.Nodes);
            }
            catch (Exception ex)
            {
                try
                {
                    var @object = JArray.Parse(json);
                    AddObjectNodes(@object, "array", treeView.Nodes);
                }
                catch (Exception ex1) {
                    logOutput(ex1.Message, true);
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
