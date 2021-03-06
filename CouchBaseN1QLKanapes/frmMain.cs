﻿using Couchbase;
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
using System.Diagnostics;

namespace CouchBaseN1QLKanapes
{
    public partial class frmMain : Form
    {
        Logger l;
        Stopwatch watch = new Stopwatch();
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
            this.watch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                this.l.logOutput(n1qlStr);
                this.l.logResults("", false);
                //this.n1qlRun();
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerSupportsCancellation = true;
                bw.WorkerReportsProgress = true;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.ProgressChanged +=  new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.RunWorkerCompleted +=  new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                if (bw.IsBusy != true)
                {
                    bw.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                this.l.logOutput(ex.Message);
            }
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //string elapsedTime = TimeSpan.FromMilliseconds(elapsedMs).ToString(@"hh\:mm\:ss\.fff") + " ms"; ;
            //this.txt_elapsedTime.Text = elapsedTime;
            //this.l.logOutput(elapsedTime);
            this.Cursor = Cursors.Default;
        }
        public static async Task<Couchbase.N1QL.IQueryResult<dynamic>> asyncQuery(string _value, IBucket _bucket)
        {
            var result = await _bucket.QueryAsync<dynamic>(_value);
            return result;
        }
        private void n1qlRun(BackgroundWorker _bw)
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
            var watch = System.Diagnostics.Stopwatch.StartNew();
            using (var cluster = new Cluster(config))
            {
                IBucket bucket = null;
                try
                {
                   // this.l.logResults("", false);
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
                        _bw.ReportProgress(100, jsonResult);
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

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                }
                else
                {
                    this.n1qlRun(worker);
                }
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
             this.l.logResults(e.UserState.ToString());
             new JSONViewHelper().LoadJsonToTreeView(this.tvw_JSON, e.UserState.ToString());
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.l.logOutput("N1QL Canceled!");
                this.l.logResults("N1QL Canceled!");
            }
            else if (!(e.Error == null))
            {
                this.l.logOutput("N1QL Error: " + e.Error.Message);
                this.l.logResults("N1QL Error: " + e.Error.Message);
            }
            else
            {
              
            }
            l.logWatch(watch, this.txt_elapsedTime);
           
        }
    }
}
