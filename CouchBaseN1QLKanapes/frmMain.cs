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
                        new Uri("http://192.168.1.4:8091/pools"),
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
            JArray array = JArray.Parse(_s);
            foreach (JObject row in array)
            {
                TreeNode parent = Json2Tree(row);
                //parent.Text = "Root Object";
                this.tvw_JSON.Nodes.Add(parent);
            }
        }

        private TreeNode Json2Tree(JObject obj)
        {
            //create the parent node
            TreeNode parent = new TreeNode();
            //loop through the obj. all token should be pair<key, value>
            foreach (var token in obj)
            {
                //change the display Content of the parent
                parent.Text = token.Key.ToString();
                //create the child node
                TreeNode child = new TreeNode();
                child.Text = token.Key.ToString();
                //check if the value is of type obj recall the method
                if (token.Value.Type.ToString() == "Object")
                {
                    // child.Text = token.Key.ToString();
                    //create a new JObject using the the Token.value
                    JObject o = (JObject)token.Value;
                    //recall the method
                    child = Json2Tree(o);
                    //add the child to the parentNode
                    parent.Nodes.Add(child);
                }
                //if type is of array
                else if (token.Value.Type.ToString() == "Array")
                {
                    int ix = -1;
                    //  child.Text = token.Key.ToString();
                    //loop though the array
                    foreach (var itm in token.Value)
                    {
                        //check if value is an Array of objects
                        if (itm.Type.ToString() == "Object")
                        {
                            TreeNode objTN = new TreeNode();
                            //child.Text = token.Key.ToString();
                            //call back the method
                            ix++;

                            JObject o = (JObject)itm;
                            objTN = Json2Tree(o);
                            objTN.Text = token.Key.ToString() + "[" + ix + "]";
                            child.Nodes.Add(objTN);
                            //parent.Nodes.Add(child);
                        }
                        //regular array string, int, etc
                        else if (itm.Type.ToString() == "Array")
                        {
                            ix++;
                            TreeNode dataArray = new TreeNode();
                            foreach (var data in itm)
                            {
                                dataArray.Text = token.Key.ToString() + "[" + ix + "]";
                                dataArray.Nodes.Add(data.ToString());
                            }
                            child.Nodes.Add(dataArray);
                        }

                        else
                        {
                            child.Nodes.Add(itm.ToString());
                        }
                    }
                    parent.Nodes.Add(child);
                }
                else
                {
                    //if token.Value is not nested
                    // child.Text = token.Key.ToString();
                    //change the value into N/A if value == null or an empty string 
                    if (token.Value.ToString() == "")
                        child.Nodes.Add("N/A");
                    else
                        child.Nodes.Add(token.Value.ToString());
                    parent.Nodes.Add(child);
                }
            }
            return parent;

        }
    }
}
