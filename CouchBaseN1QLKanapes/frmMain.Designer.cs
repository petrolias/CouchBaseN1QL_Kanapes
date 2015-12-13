namespace CouchBaseN1QLKanapes
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Connections");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.spl_workbench = new System.Windows.Forms.SplitContainer();
            this.spl_workbench_inner = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.num_Limit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_n1qlCmd = new System.Windows.Forms.TextBox();
            this.chk_saveScrapbookOnExit = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_memo = new System.Windows.Forms.TextBox();
            this.tab_Results = new System.Windows.Forms.TabControl();
            this.tabPage_results = new System.Windows.Forms.TabPage();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.tabPage_JSON = new System.Windows.Forms.TabPage();
            this.tabPage_output = new System.Windows.Forms.TabPage();
            this.tls_output = new System.Windows.Forms.ToolStrip();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txt_elapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.spl_main = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.trv_connections = new System.Windows.Forms.TreeView();
            this.iml_imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_outputClear = new System.Windows.Forms.ToolStripButton();
            this.btn_run = new System.Windows.Forms.ToolStripButton();
            this.tls_results = new System.Windows.Forms.ToolStrip();
            this.btn_resultsClear = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl_workbench)).BeginInit();
            this.spl_workbench.Panel1.SuspendLayout();
            this.spl_workbench.Panel2.SuspendLayout();
            this.spl_workbench.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl_workbench_inner)).BeginInit();
            this.spl_workbench_inner.Panel1.SuspendLayout();
            this.spl_workbench_inner.Panel2.SuspendLayout();
            this.spl_workbench_inner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Limit)).BeginInit();
            this.tab_Results.SuspendLayout();
            this.tabPage_results.SuspendLayout();
            this.tabPage_output.SuspendLayout();
            this.tls_output.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl_main)).BeginInit();
            this.spl_main.Panel1.SuspendLayout();
            this.spl_main.Panel2.SuspendLayout();
            this.spl_main.SuspendLayout();
            this.tls_results.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_run,
            this.toolStripSeparator1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(706, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel1.Text = "About";
            // 
            // spl_workbench
            // 
            this.spl_workbench.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spl_workbench.Location = new System.Drawing.Point(0, 0);
            this.spl_workbench.Name = "spl_workbench";
            this.spl_workbench.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spl_workbench.Panel1
            // 
            this.spl_workbench.Panel1.Controls.Add(this.spl_workbench_inner);
            this.spl_workbench.Panel1MinSize = 100;
            // 
            // spl_workbench.Panel2
            // 
            this.spl_workbench.Panel2.Controls.Add(this.tab_Results);
            this.spl_workbench.Panel2.Controls.Add(this.statusStrip1);
            this.spl_workbench.Panel2MinSize = 100;
            this.spl_workbench.Size = new System.Drawing.Size(561, 340);
            this.spl_workbench.SplitterDistance = 196;
            this.spl_workbench.TabIndex = 1;
            // 
            // spl_workbench_inner
            // 
            this.spl_workbench_inner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spl_workbench_inner.Location = new System.Drawing.Point(0, 0);
            this.spl_workbench_inner.Name = "spl_workbench_inner";
            // 
            // spl_workbench_inner.Panel1
            // 
            this.spl_workbench_inner.Panel1.Controls.Add(this.label4);
            this.spl_workbench_inner.Panel1.Controls.Add(this.num_Limit);
            this.spl_workbench_inner.Panel1.Controls.Add(this.label1);
            this.spl_workbench_inner.Panel1.Controls.Add(this.txt_n1qlCmd);
            this.spl_workbench_inner.Panel1MinSize = 352;
            // 
            // spl_workbench_inner.Panel2
            // 
            this.spl_workbench_inner.Panel2.Controls.Add(this.chk_saveScrapbookOnExit);
            this.spl_workbench_inner.Panel2.Controls.Add(this.label2);
            this.spl_workbench_inner.Panel2.Controls.Add(this.txt_memo);
            this.spl_workbench_inner.Panel2MinSize = 200;
            this.spl_workbench_inner.Size = new System.Drawing.Size(561, 196);
            this.spl_workbench_inner.SplitterDistance = 352;
            this.spl_workbench_inner.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Limit Results";
            // 
            // num_Limit
            // 
            this.num_Limit.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_Limit.Location = new System.Drawing.Point(293, 4);
            this.num_Limit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Limit.Name = "num_Limit";
            this.num_Limit.Size = new System.Drawing.Size(56, 20);
            this.num_Limit.TabIndex = 3;
            this.num_Limit.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "N1QL Panel";
            // 
            // txt_n1qlCmd
            // 
            this.txt_n1qlCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_n1qlCmd.Location = new System.Drawing.Point(3, 27);
            this.txt_n1qlCmd.MinimumSize = new System.Drawing.Size(346, 230);
            this.txt_n1qlCmd.Multiline = true;
            this.txt_n1qlCmd.Name = "txt_n1qlCmd";
            this.txt_n1qlCmd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_n1qlCmd.Size = new System.Drawing.Size(346, 230);
            this.txt_n1qlCmd.TabIndex = 1;
            // 
            // chk_saveScrapbookOnExit
            // 
            this.chk_saveScrapbookOnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_saveScrapbookOnExit.AutoSize = true;
            this.chk_saveScrapbookOnExit.Checked = true;
            this.chk_saveScrapbookOnExit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_saveScrapbookOnExit.Location = new System.Drawing.Point(119, 7);
            this.chk_saveScrapbookOnExit.Name = "chk_saveScrapbookOnExit";
            this.chk_saveScrapbookOnExit.Size = new System.Drawing.Size(83, 17);
            this.chk_saveScrapbookOnExit.TabIndex = 4;
            this.chk_saveScrapbookOnExit.Text = "save on exit";
            this.chk_saveScrapbookOnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chk_saveScrapbookOnExit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Scrapbook";
            // 
            // txt_memo
            // 
            this.txt_memo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_memo.Location = new System.Drawing.Point(3, 27);
            this.txt_memo.MinimumSize = new System.Drawing.Size(199, 230);
            this.txt_memo.Multiline = true;
            this.txt_memo.Name = "txt_memo";
            this.txt_memo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_memo.Size = new System.Drawing.Size(199, 230);
            this.txt_memo.TabIndex = 2;
            // 
            // tab_Results
            // 
            this.tab_Results.Controls.Add(this.tabPage_results);
            this.tab_Results.Controls.Add(this.tabPage_JSON);
            this.tab_Results.Controls.Add(this.tabPage_output);
            this.tab_Results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Results.Location = new System.Drawing.Point(0, 0);
            this.tab_Results.Name = "tab_Results";
            this.tab_Results.SelectedIndex = 0;
            this.tab_Results.Size = new System.Drawing.Size(561, 118);
            this.tab_Results.TabIndex = 7;
            // 
            // tabPage_results
            // 
            this.tabPage_results.Controls.Add(this.tls_results);
            this.tabPage_results.Controls.Add(this.txt_result);
            this.tabPage_results.Location = new System.Drawing.Point(4, 22);
            this.tabPage_results.Name = "tabPage_results";
            this.tabPage_results.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_results.Size = new System.Drawing.Size(553, 92);
            this.tabPage_results.TabIndex = 0;
            this.tabPage_results.Text = "Results";
            this.tabPage_results.UseVisualStyleBackColor = true;
            // 
            // txt_result
            // 
            this.txt_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_result.Location = new System.Drawing.Point(3, 31);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_result.Size = new System.Drawing.Size(547, 58);
            this.txt_result.TabIndex = 0;
            // 
            // tabPage_JSON
            // 
            this.tabPage_JSON.Location = new System.Drawing.Point(4, 22);
            this.tabPage_JSON.Name = "tabPage_JSON";
            this.tabPage_JSON.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_JSON.Size = new System.Drawing.Size(553, 92);
            this.tabPage_JSON.TabIndex = 1;
            this.tabPage_JSON.Text = "JSON";
            this.tabPage_JSON.UseVisualStyleBackColor = true;
            // 
            // tabPage_output
            // 
            this.tabPage_output.Controls.Add(this.tls_output);
            this.tabPage_output.Controls.Add(this.txt_Output);
            this.tabPage_output.Location = new System.Drawing.Point(4, 22);
            this.tabPage_output.Name = "tabPage_output";
            this.tabPage_output.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_output.Size = new System.Drawing.Size(553, 92);
            this.tabPage_output.TabIndex = 2;
            this.tabPage_output.Text = "Output";
            this.tabPage_output.UseVisualStyleBackColor = true;
            // 
            // tls_output
            // 
            this.tls_output.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tls_output.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_outputClear});
            this.tls_output.Location = new System.Drawing.Point(3, 3);
            this.tls_output.Name = "tls_output";
            this.tls_output.Size = new System.Drawing.Size(547, 25);
            this.tls_output.TabIndex = 2;
            this.tls_output.Text = "toolStrip2";
            this.tls_output.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.txt_Output_ItemClicked);
            // 
            // txt_Output
            // 
            this.txt_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Output.Location = new System.Drawing.Point(3, 31);
            this.txt_Output.Multiline = true;
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Output.Size = new System.Drawing.Size(547, 58);
            this.txt_Output.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txt_elapsedTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 118);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(561, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel1.Text = "Time :";
            // 
            // txt_elapsedTime
            // 
            this.txt_elapsedTime.Name = "txt_elapsedTime";
            this.txt_elapsedTime.Size = new System.Drawing.Size(32, 17);
            this.txt_elapsedTime.Text = "0 ms";
            // 
            // spl_main
            // 
            this.spl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spl_main.Location = new System.Drawing.Point(0, 25);
            this.spl_main.Name = "spl_main";
            // 
            // spl_main.Panel1
            // 
            this.spl_main.Panel1.Controls.Add(this.label3);
            this.spl_main.Panel1.Controls.Add(this.trv_connections);
            this.spl_main.Panel1MinSize = 141;
            // 
            // spl_main.Panel2
            // 
            this.spl_main.Panel2.Controls.Add(this.spl_workbench);
            this.spl_main.Panel2MinSize = 559;
            this.spl_main.Size = new System.Drawing.Size(706, 340);
            this.spl_main.SplitterDistance = 141;
            this.spl_main.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Connections";
            // 
            // trv_connections
            // 
            this.trv_connections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trv_connections.ImageIndex = 0;
            this.trv_connections.ImageList = this.iml_imageList;
            this.trv_connections.Location = new System.Drawing.Point(3, 27);
            this.trv_connections.MinimumSize = new System.Drawing.Size(136, 307);
            this.trv_connections.Name = "trv_connections";
            treeNode1.Name = "nd_connections";
            treeNode1.Text = "Connections";
            this.trv_connections.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trv_connections.SelectedImageIndex = 0;
            this.trv_connections.Size = new System.Drawing.Size(136, 310);
            this.trv_connections.TabIndex = 0;
            // 
            // iml_imageList
            // 
            this.iml_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml_imageList.ImageStream")));
            this.iml_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.iml_imageList.Images.SetKeyName(0, "thunder-48.png");
            // 
            // btn_outputClear
            // 
            this.btn_outputClear.Image = global::CouchBaseN1QLKanapes.Properties.Resources._1449998789_button_cancel;
            this.btn_outputClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_outputClear.Name = "btn_outputClear";
            this.btn_outputClear.Size = new System.Drawing.Size(54, 22);
            this.btn_outputClear.Text = "Clear";
            // 
            // btn_run
            // 
            this.btn_run.Image = global::CouchBaseN1QLKanapes.Properties.Resources._1449993628_play;
            this.btn_run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(71, 22);
            this.btn_run.Text = "Run (F5)";
            this.btn_run.ToolTipText = "F5 Run";
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // tls_results
            // 
            this.tls_results.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tls_results.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_resultsClear});
            this.tls_results.Location = new System.Drawing.Point(3, 3);
            this.tls_results.Name = "tls_results";
            this.tls_results.Size = new System.Drawing.Size(547, 25);
            this.tls_results.TabIndex = 3;
            this.tls_results.Text = "toolStrip3";
            this.tls_results.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tls_results_ItemClicked);
            // 
            // btn_resultsClear
            // 
            this.btn_resultsClear.Image = global::CouchBaseN1QLKanapes.Properties.Resources._1449998789_button_cancel;
            this.btn_resultsClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_resultsClear.Name = "btn_resultsClear";
            this.btn_resultsClear.Size = new System.Drawing.Size(54, 22);
            this.btn_resultsClear.Text = "Clear";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 365);
            this.Controls.Add(this.spl_main);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(722, 404);
            this.Name = "frmMain";
            this.Text = "CouchBaseN1QL Kanapes";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.spl_workbench.Panel1.ResumeLayout(false);
            this.spl_workbench.Panel2.ResumeLayout(false);
            this.spl_workbench.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl_workbench)).EndInit();
            this.spl_workbench.ResumeLayout(false);
            this.spl_workbench_inner.Panel1.ResumeLayout(false);
            this.spl_workbench_inner.Panel1.PerformLayout();
            this.spl_workbench_inner.Panel2.ResumeLayout(false);
            this.spl_workbench_inner.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl_workbench_inner)).EndInit();
            this.spl_workbench_inner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_Limit)).EndInit();
            this.tab_Results.ResumeLayout(false);
            this.tabPage_results.ResumeLayout(false);
            this.tabPage_results.PerformLayout();
            this.tabPage_output.ResumeLayout(false);
            this.tabPage_output.PerformLayout();
            this.tls_output.ResumeLayout(false);
            this.tls_output.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.spl_main.Panel1.ResumeLayout(false);
            this.spl_main.Panel1.PerformLayout();
            this.spl_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spl_main)).EndInit();
            this.spl_main.ResumeLayout(false);
            this.tls_results.ResumeLayout(false);
            this.tls_results.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_run;
        private System.Windows.Forms.SplitContainer spl_workbench;
        private System.Windows.Forms.SplitContainer spl_workbench_inner;
        private System.Windows.Forms.TextBox txt_n1qlCmd;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txt_elapsedTime;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.TextBox txt_memo;
        private System.Windows.Forms.SplitContainer spl_main;
        private System.Windows.Forms.TreeView trv_connections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_saveScrapbookOnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_Limit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList iml_imageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tab_Results;
        private System.Windows.Forms.TabPage tabPage_results;
        private System.Windows.Forms.TabPage tabPage_JSON;
        private System.Windows.Forms.TabPage tabPage_output;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.ToolStrip tls_output;
        private System.Windows.Forms.ToolStripButton btn_outputClear;
        private System.Windows.Forms.ToolStrip tls_results;
        private System.Windows.Forms.ToolStripButton btn_resultsClear;
    }
}

