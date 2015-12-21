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
        Logger l; 
        public frmMain()
        {
            InitializeComponent();
            this.Text += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.l = new Logger(this.txt_result, this.txt_Output);
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
                this.l.logOutput(s);
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
                this.l.logOutput(n1qlStr);
                this.n1qlRun();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                this.l.logOutput(ex.Message);
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            string elapsedTime = TimeSpan.FromMilliseconds(elapsedMs).ToString(@"hh\:mm\:ss\.fff") + " ms"; ;
            this.txt_elapsedTime.Text = elapsedTime;
            this.l.logOutput(elapsedTime);
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
                    this.l.logResults("", false);
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
                        this.l.logResults(jsonResult);
                        new JSONViewHelper().LoadJsonToTreeView(this.tvw_JSON, jsonResult);
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
    }
}
