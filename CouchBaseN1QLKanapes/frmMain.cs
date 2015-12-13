﻿using CouchBaseN1QLKanapes.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void Run() {
            if (this.txt_n1qlCmd.SelectedText == "" && this.txt_n1qlCmd.Text == "")
            {
                string s = "A big nothing was send to Couchbase...";
                this.logOutput(s);
                return;
            }
            string n1qlStr = "";

            if (this.txt_n1qlCmd.SelectedText != "")
            {
                n1qlStr = this.txt_n1qlCmd.SelectedText;
            }
            else {
                n1qlStr = this.txt_n1qlCmd.Text;
            }

            this.Cursor = Cursors.WaitCursor;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            try {
            //ADD N1QL Command Logic Here

            }catch (Exception ex){
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

        private void logResults(string _value, bool _appentText = true) {
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

    }
}
