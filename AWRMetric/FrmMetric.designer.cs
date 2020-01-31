namespace AWRMetric
{
    partial class FrmMetric
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode121 = new System.Windows.Forms.TreeNode("Average Active Session");
            System.Windows.Forms.TreeNode treeNode122 = new System.Windows.Forms.TreeNode("CPU usage and database time");
            System.Windows.Forms.TreeNode treeNode123 = new System.Windows.Forms.TreeNode("Physical reads and writes IOPS");
            System.Windows.Forms.TreeNode treeNode124 = new System.Windows.Forms.TreeNode("Physical reads and writes throughput");
            System.Windows.Forms.TreeNode treeNode125 = new System.Windows.Forms.TreeNode("System Metrics", new System.Windows.Forms.TreeNode[] {
            treeNode121,
            treeNode122,
            treeNode123,
            treeNode124});
            System.Windows.Forms.TreeNode treeNode126 = new System.Windows.Forms.TreeNode("Physical read and write IOPS");
            System.Windows.Forms.TreeNode treeNode127 = new System.Windows.Forms.TreeNode("Physical read and write throughput");
            System.Windows.Forms.TreeNode treeNode128 = new System.Windows.Forms.TreeNode("CPU and wait time");
            System.Windows.Forms.TreeNode treeNode129 = new System.Windows.Forms.TreeNode("CPU used per instance");
            System.Windows.Forms.TreeNode treeNode130 = new System.Windows.Forms.TreeNode("System Statistics", new System.Windows.Forms.TreeNode[] {
            treeNode126,
            treeNode127,
            treeNode128,
            treeNode129});
            System.Windows.Forms.TreeNode treeNode131 = new System.Windows.Forms.TreeNode("Database file sequential read");
            System.Windows.Forms.TreeNode treeNode132 = new System.Windows.Forms.TreeNode("Database file scattered read");
            System.Windows.Forms.TreeNode treeNode133 = new System.Windows.Forms.TreeNode("Log file sync");
            System.Windows.Forms.TreeNode treeNode134 = new System.Windows.Forms.TreeNode("Wait Events", new System.Windows.Forms.TreeNode[] {
            treeNode131,
            treeNode132,
            treeNode133});
            System.Windows.Forms.TreeNode treeNode135 = new System.Windows.Forms.TreeNode("Wait Events per Class");
            System.Windows.Forms.TreeNode treeNode136 = new System.Windows.Forms.TreeNode("Small read IOPS");
            System.Windows.Forms.TreeNode treeNode137 = new System.Windows.Forms.TreeNode("Large read throughput");
            System.Windows.Forms.TreeNode treeNode138 = new System.Windows.Forms.TreeNode("Small write IOPS");
            System.Windows.Forms.TreeNode treeNode139 = new System.Windows.Forms.TreeNode("Large write throughput");
            System.Windows.Forms.TreeNode treeNode140 = new System.Windows.Forms.TreeNode("I/O Stats Details", new System.Windows.Forms.TreeNode[] {
            treeNode136,
            treeNode137,
            treeNode138,
            treeNode139});
            System.Windows.Forms.TreeNode treeNode141 = new System.Windows.Forms.TreeNode("Number of wait events [dbfile]");
            System.Windows.Forms.TreeNode treeNode142 = new System.Windows.Forms.TreeNode("Time waited [dbfile]");
            System.Windows.Forms.TreeNode treeNode143 = new System.Windows.Forms.TreeNode("Number of wait events [logfile]");
            System.Windows.Forms.TreeNode treeNode144 = new System.Windows.Forms.TreeNode("Time waited [logfile]");
            System.Windows.Forms.TreeNode treeNode145 = new System.Windows.Forms.TreeNode("I/O Waits Latency", new System.Windows.Forms.TreeNode[] {
            treeNode141,
            treeNode142,
            treeNode143,
            treeNode144});
            System.Windows.Forms.TreeNode treeNode146 = new System.Windows.Forms.TreeNode("DB time");
            System.Windows.Forms.TreeNode treeNode147 = new System.Windows.Forms.TreeNode("CPU time");
            System.Windows.Forms.TreeNode treeNode148 = new System.Windows.Forms.TreeNode("User I/O wait time");
            System.Windows.Forms.TreeNode treeNode149 = new System.Windows.Forms.TreeNode("Stats per Service", new System.Windows.Forms.TreeNode[] {
            treeNode146,
            treeNode147,
            treeNode148});
            System.Windows.Forms.TreeNode treeNode150 = new System.Windows.Forms.TreeNode("Top 5 Wait Events");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bttnCompare = new System.Windows.Forms.Button();
            this.bttnGetSnap = new System.Windows.Forms.Button();
            this.bttnSavePoint = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.bttnBasePoint = new System.Windows.Forms.Button();
            this.dtsnapto = new System.Windows.Forms.DateTimePicker();
            this.txthost = new System.Windows.Forms.TextBox();
            this.dtsnap = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtport = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtservice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.dgsavept = new System.Windows.Forms.DataGridView();
            this.SNAP_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAVEPOINT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tv = new System.Windows.Forms.TreeView();
            this.dg = new System.Windows.Forms.DataGridView();
            this.SNAP_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BEGIN_INTERVAL_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_INTERVAL_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsavept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Lavender;
            this.splitContainer1.Panel1.Controls.Add(this.bttnCompare);
            this.splitContainer1.Panel1.Controls.Add(this.bttnGetSnap);
            this.splitContainer1.Panel1.Controls.Add(this.bttnSavePoint);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txtpwd);
            this.splitContainer1.Panel1.Controls.Add(this.bttnBasePoint);
            this.splitContainer1.Panel1.Controls.Add(this.dtsnapto);
            this.splitContainer1.Panel1.Controls.Add(this.txthost);
            this.splitContainer1.Panel1.Controls.Add(this.dtsnap);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtuser);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtport);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtservice);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.dgsavept);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.tv);
            this.splitContainer1.Panel2.Controls.Add(this.dg);
            this.splitContainer1.Size = new System.Drawing.Size(1099, 597);
            this.splitContainer1.SplitterDistance = 121;
            this.splitContainer1.TabIndex = 22;
            // 
            // bttnCompare
            // 
            this.bttnCompare.BackColor = System.Drawing.Color.MediumBlue;
            this.bttnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttnCompare.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnCompare.ForeColor = System.Drawing.Color.White;
            this.bttnCompare.Location = new System.Drawing.Point(4, 458);
            this.bttnCompare.Name = "bttnCompare";
            this.bttnCompare.Size = new System.Drawing.Size(104, 53);
            this.bttnCompare.TabIndex = 35;
            this.bttnCompare.Text = "Compare Save point with Base point";
            this.bttnCompare.UseVisualStyleBackColor = false;
            this.bttnCompare.Click += new System.EventHandler(this.bttnCompare_Click);
            // 
            // bttnGetSnap
            // 
            this.bttnGetSnap.BackColor = System.Drawing.Color.Purple;
            this.bttnGetSnap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttnGetSnap.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnGetSnap.ForeColor = System.Drawing.Color.White;
            this.bttnGetSnap.Location = new System.Drawing.Point(6, 305);
            this.bttnGetSnap.Name = "bttnGetSnap";
            this.bttnGetSnap.Size = new System.Drawing.Size(102, 29);
            this.bttnGetSnap.TabIndex = 32;
            this.bttnGetSnap.Text = "Get Snaps";
            this.bttnGetSnap.UseVisualStyleBackColor = false;
            this.bttnGetSnap.Click += new System.EventHandler(this.bttnGetSnap_Click);
            // 
            // bttnSavePoint
            // 
            this.bttnSavePoint.BackColor = System.Drawing.Color.DimGray;
            this.bttnSavePoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttnSavePoint.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnSavePoint.ForeColor = System.Drawing.Color.White;
            this.bttnSavePoint.Location = new System.Drawing.Point(8, 399);
            this.bttnSavePoint.Name = "bttnSavePoint";
            this.bttnSavePoint.Size = new System.Drawing.Size(100, 53);
            this.bttnSavePoint.TabIndex = 36;
            this.bttnSavePoint.Text = "Create Save point of Performance";
            this.bttnSavePoint.UseVisualStyleBackColor = false;
            this.bttnSavePoint.Click += new System.EventHandler(this.bttnSavePoint_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "Snap To";
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(12, 193);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Size = new System.Drawing.Size(96, 20);
            this.txtpwd.TabIndex = 31;
            this.txtpwd.Text = "dbsnmp";
            this.txtpwd.UseSystemPasswordChar = true;
            // 
            // bttnBasePoint
            // 
            this.bttnBasePoint.BackColor = System.Drawing.Color.Indigo;
            this.bttnBasePoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttnBasePoint.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnBasePoint.ForeColor = System.Drawing.Color.White;
            this.bttnBasePoint.Location = new System.Drawing.Point(6, 340);
            this.bttnBasePoint.Name = "bttnBasePoint";
            this.bttnBasePoint.Size = new System.Drawing.Size(102, 53);
            this.bttnBasePoint.TabIndex = 35;
            this.bttnBasePoint.Text = "Create Base point of Performance";
            this.bttnBasePoint.UseVisualStyleBackColor = false;
            this.bttnBasePoint.Click += new System.EventHandler(this.bttnBasePoint_Click);
            // 
            // dtsnapto
            // 
            this.dtsnapto.CustomFormat = "dd/MM/yyyy";
            this.dtsnapto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtsnapto.Location = new System.Drawing.Point(12, 279);
            this.dtsnapto.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtsnapto.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtsnapto.Name = "dtsnapto";
            this.dtsnapto.Size = new System.Drawing.Size(96, 20);
            this.dtsnapto.TabIndex = 25;
            // 
            // txthost
            // 
            this.txthost.Location = new System.Drawing.Point(12, 29);
            this.txthost.Name = "txthost";
            this.txthost.Size = new System.Drawing.Size(96, 20);
            this.txthost.TabIndex = 23;
            this.txthost.Text = "ol7.localdomain";
            // 
            // dtsnap
            // 
            this.dtsnap.CustomFormat = "dd/MM/yyyy";
            this.dtsnap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtsnap.Location = new System.Drawing.Point(12, 234);
            this.dtsnap.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtsnap.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtsnap.Name = "dtsnap";
            this.dtsnap.Size = new System.Drawing.Size(96, 20);
            this.dtsnap.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Snap From";
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(12, 152);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(96, 20);
            this.txtuser.TabIndex = 30;
            this.txtuser.Text = "dbsnmp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 27;
            this.label5.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Host Name / IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "User";
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(12, 111);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(96, 20);
            this.txtport.TabIndex = 29;
            this.txtport.Text = "1521";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Service Name";
            // 
            // txtservice
            // 
            this.txtservice.Location = new System.Drawing.Point(12, 70);
            this.txtservice.Name = "txtservice";
            this.txtservice.Size = new System.Drawing.Size(96, 20);
            this.txtservice.TabIndex = 28;
            this.txtservice.Text = "orcl.locaaldomain";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Port";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(247, 199);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(723, 395);
            this.tabControl1.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(715, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "System Metrics";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(715, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "System Statistics";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(715, 369);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Wait Events";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(715, 369);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Wait Events (Class)";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(715, 369);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "I/O Stats Details";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(715, 369);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "I/O Waits Latency";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(715, 369);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Stats per Service";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(715, 369);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Top Wait Events";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // dgsavept
            // 
            this.dgsavept.AllowUserToAddRows = false;
            this.dgsavept.AllowUserToDeleteRows = false;
            this.dgsavept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsavept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNAP_TIME,
            this.SAVEPOINT_TIME});
            this.dgsavept.Location = new System.Drawing.Point(659, 29);
            this.dgsavept.Name = "dgsavept";
            this.dgsavept.ReadOnly = true;
            this.dgsavept.Size = new System.Drawing.Size(303, 162);
            this.dgsavept.TabIndex = 42;
            this.dgsavept.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgsavept_CellMouseDoubleClick);
            // 
            // SNAP_TIME
            // 
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SNAP_TIME.DefaultCellStyle = dataGridViewCellStyle21;
            this.SNAP_TIME.HeaderText = "SNAP_TIME";
            this.SNAP_TIME.Name = "SNAP_TIME";
            this.SNAP_TIME.ReadOnly = true;
            this.SNAP_TIME.Width = 130;
            // 
            // SAVEPOINT_TIME
            // 
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SAVEPOINT_TIME.DefaultCellStyle = dataGridViewCellStyle22;
            this.SAVEPOINT_TIME.HeaderText = "SAVEPOINT_TIME";
            this.SAVEPOINT_TIME.Name = "SAVEPOINT_TIME";
            this.SAVEPOINT_TIME.ReadOnly = true;
            this.SAVEPOINT_TIME.Width = 120;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label10.Location = new System.Drawing.Point(661, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 20);
            this.label10.TabIndex = 40;
            this.label10.Text = "Select Savepoint";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "2. Select Metrics";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label8.Location = new System.Drawing.Point(243, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "1. Select Snaps";
            // 
            // tv
            // 
            this.tv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv.CheckBoxes = true;
            this.tv.Location = new System.Drawing.Point(0, 29);
            this.tv.Name = "tv";
            treeNode121.Name = "Node8";
            treeNode121.Text = "Average Active Session";
            treeNode122.Name = "Node9";
            treeNode122.Text = "CPU usage and database time";
            treeNode123.Name = "Node10";
            treeNode123.Text = "Physical reads and writes IOPS";
            treeNode124.Name = "Node11";
            treeNode124.Text = "Physical reads and writes throughput";
            treeNode125.ImageIndex = 0;
            treeNode125.Name = "Node0";
            treeNode125.Text = "System Metrics";
            treeNode125.ToolTipText = "dba_hist_sysmetric_summary";
            treeNode126.Name = "Node12";
            treeNode126.Text = "Physical read and write IOPS";
            treeNode127.Name = "Node13";
            treeNode127.Text = "Physical read and write throughput";
            treeNode128.Name = "Node14";
            treeNode128.Text = "CPU and wait time";
            treeNode129.Name = "Node15";
            treeNode129.Text = "CPU used per instance";
            treeNode130.Name = "Node1";
            treeNode130.Text = "System Statistics";
            treeNode130.ToolTipText = "dba_hist_sysstat";
            treeNode131.Name = "Node16";
            treeNode131.Text = "Database file sequential read";
            treeNode131.ToolTipText = "db file sequential read - wait event for single block reads";
            treeNode132.Name = "Node17";
            treeNode132.Text = "Database file scattered read";
            treeNode132.ToolTipText = "db file scattered read - wait event for multiblock reads into the buffer cache";
            treeNode133.Name = "Node18";
            treeNode133.Text = "Log file sync";
            treeNode133.ToolTipText = "log file sync - wait event for commit time";
            treeNode134.Name = "Node2";
            treeNode134.Text = "Wait Events";
            treeNode134.ToolTipText = "dba_hist_system_event";
            treeNode135.Name = "Node3";
            treeNode135.Text = "Wait Events per Class";
            treeNode135.ToolTipText = "dba_hist_system_event";
            treeNode136.Name = "Node24";
            treeNode136.Text = "Small read IOPS";
            treeNode137.Name = "Node25";
            treeNode137.Text = "Large read throughput";
            treeNode138.Name = "Node26";
            treeNode138.Text = "Small write IOPS";
            treeNode139.Name = "Node27";
            treeNode139.Text = "Large write throughput";
            treeNode140.Name = "Node4";
            treeNode140.Text = "I/O Stats Details";
            treeNode140.ToolTipText = "dba_hist_iostat_details";
            treeNode141.Name = "Node28";
            treeNode141.Text = "Number of wait events [dbfile]";
            treeNode141.ToolTipText = "db file sequential read latency histogram";
            treeNode142.Name = "Node29";
            treeNode142.Text = "Time waited [dbfile]";
            treeNode142.ToolTipText = "db file sequential read latency histogram";
            treeNode143.Name = "Node30";
            treeNode143.Text = "Number of wait events [logfile]";
            treeNode143.ToolTipText = "log file sync latency histogram";
            treeNode144.Name = "Node31";
            treeNode144.Text = "Time waited [logfile]";
            treeNode144.ToolTipText = "log file sync latency histogram";
            treeNode145.Name = "Node5";
            treeNode145.Text = "I/O Waits Latency";
            treeNode145.ToolTipText = "dba_hist_event_histogram";
            treeNode146.Name = "Node32";
            treeNode146.Text = "DB time";
            treeNode147.Name = "Node33";
            treeNode147.Text = "CPU time";
            treeNode148.Name = "Node34";
            treeNode148.Text = "User I/O wait time";
            treeNode149.Name = "Node6";
            treeNode149.Text = "Stats per Service";
            treeNode149.ToolTipText = "dba_hist_service_stat";
            treeNode150.Name = "Node7";
            treeNode150.Text = "Top 5 Wait Events";
            treeNode150.ToolTipText = "dba_hist_system_event";
            this.tv.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode125,
            treeNode130,
            treeNode134,
            treeNode135,
            treeNode140,
            treeNode145,
            treeNode149,
            treeNode150});
            this.tv.Size = new System.Drawing.Size(241, 568);
            this.tv.TabIndex = 28;
            this.tv.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterCheck);
            this.tv.Click += new System.EventHandler(this.tv_Click);
            // 
            // dg
            // 
            this.dg.AllowUserToDeleteRows = false;
            this.dg.AllowUserToOrderColumns = true;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNAP_ID,
            this.BEGIN_INTERVAL_TIME,
            this.END_INTERVAL_TIME,
            this.Selection});
            this.dg.Location = new System.Drawing.Point(247, 29);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(406, 162);
            this.dg.TabIndex = 17;
            this.dg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellContentClick);
            // 
            // SNAP_ID
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            this.SNAP_ID.DefaultCellStyle = dataGridViewCellStyle23;
            this.SNAP_ID.HeaderText = "SNAP_ID";
            this.SNAP_ID.Name = "SNAP_ID";
            this.SNAP_ID.Width = 65;
            // 
            // BEGIN_INTERVAL_TIME
            // 
            dataGridViewCellStyle24.Format = "G";
            dataGridViewCellStyle24.NullValue = null;
            this.BEGIN_INTERVAL_TIME.DefaultCellStyle = dataGridViewCellStyle24;
            this.BEGIN_INTERVAL_TIME.HeaderText = "BEGIN";
            this.BEGIN_INTERVAL_TIME.Name = "BEGIN_INTERVAL_TIME";
            this.BEGIN_INTERVAL_TIME.Width = 130;
            // 
            // END_INTERVAL_TIME
            // 
            dataGridViewCellStyle25.Format = "G";
            dataGridViewCellStyle25.NullValue = null;
            this.END_INTERVAL_TIME.DefaultCellStyle = dataGridViewCellStyle25;
            this.END_INTERVAL_TIME.HeaderText = "END";
            this.END_INTERVAL_TIME.Name = "END_INTERVAL_TIME";
            this.END_INTERVAL_TIME.Width = 130;
            // 
            // Selection
            // 
            this.Selection.FalseValue = "0";
            this.Selection.HeaderText = "";
            this.Selection.Name = "Selection";
            this.Selection.TrueValue = "1";
            this.Selection.Width = 20;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AWRMetric.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(709, 363);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmMetric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 597);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMetric";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMetric";
            this.Load += new System.EventHandler(this.FrmMetric_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsavept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.TextBox txthost;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtservice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtsnapto;
        private System.Windows.Forms.DateTimePicker dtsnap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bttnGetSnap;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Button bttnCompare;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNAP_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BEGIN_INTERVAL_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_INTERVAL_TIME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selection;
        private System.Windows.Forms.Button bttnSavePoint;
        private System.Windows.Forms.Button bttnBasePoint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgsavept;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNAP_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAVEPOINT_TIME;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}