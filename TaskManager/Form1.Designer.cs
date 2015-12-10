namespace TaskManager
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Processes = new System.Windows.Forms.TabPage();
            this.gridProcesses = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.killProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerTasks = new System.Windows.Forms.Timer(this.components);
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPUTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VirtualMemory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Threads = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.countProsecesses = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.Processes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProcesses)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Processes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // Processes
            // 
            this.Processes.Controls.Add(this.statusStrip1);
            this.Processes.Controls.Add(this.gridProcesses);
            this.Processes.Location = new System.Drawing.Point(4, 22);
            this.Processes.Name = "Processes";
            this.Processes.Padding = new System.Windows.Forms.Padding(3);
            this.Processes.Size = new System.Drawing.Size(559, 424);
            this.Processes.TabIndex = 1;
            this.Processes.Text = "Processes";
            this.Processes.UseVisualStyleBackColor = true;
            // 
            // gridProcesses
            // 
            this.gridProcesses.AllowUserToAddRows = false;
            this.gridProcesses.AllowUserToResizeRows = false;
            this.gridProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProcesses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridProcesses.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridProcesses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.gridProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessName,
            this.ID,
            this.CPUTime,
            this.UserTime,
            this.Memory,
            this.VirtualMemory,
            this.Threads});
            this.gridProcesses.ContextMenuStrip = this.contextMenu;
            this.gridProcesses.Location = new System.Drawing.Point(34, 6);
            this.gridProcesses.Name = "gridProcesses";
            this.gridProcesses.RowHeadersVisible = false;
            this.gridProcesses.Size = new System.Drawing.Size(517, 412);
            this.gridProcesses.TabIndex = 2;
            this.gridProcesses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProcesses_CellClick);
            this.gridProcesses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProcesses_CellDoubleClick);
            this.gridProcesses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridProcesses_MouseDown);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.killProcessToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(134, 48);
            // 
            // killProcessToolStripMenuItem
            // 
            this.killProcessToolStripMenuItem.Name = "killProcessToolStripMenuItem";
            this.killProcessToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.killProcessToolStripMenuItem.Text = "Kill process";
            this.killProcessToolStripMenuItem.Click += new System.EventHandler(this.killProcessToolStripMenuItem_Click);
            // 
            // timerTasks
            // 
            // 
            // ProcessName
            // 
            this.ProcessName.HeaderText = "Process";
            this.ProcessName.Name = "ProcessName";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // CPUTime
            // 
            this.CPUTime.HeaderText = "CPU Time";
            this.CPUTime.Name = "CPUTime";
            this.CPUTime.ReadOnly = true;
            // 
            // UserTime
            // 
            this.UserTime.HeaderText = "User Time";
            this.UserTime.Name = "UserTime";
            this.UserTime.ReadOnly = true;
            // 
            // Memory
            // 
            this.Memory.HeaderText = "Memory";
            this.Memory.Name = "Memory";
            this.Memory.ReadOnly = true;
            // 
            // VirtualMemory
            // 
            this.VirtualMemory.HeaderText = "Virtual Memory";
            this.VirtualMemory.Name = "VirtualMemory";
            this.VirtualMemory.ReadOnly = true;
            // 
            // Threads
            // 
            this.Threads.HeaderText = "Threads";
            this.Threads.Name = "Threads";
            this.Threads.ReadOnly = true;
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countProsecesses});
            this.statusStrip1.Location = new System.Drawing.Point(3, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(553, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // countProsecesses
            // 
            this.countProsecesses.Name = "countProsecesses";
            this.countProsecesses.Size = new System.Drawing.Size(118, 17);
            this.countProsecesses.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Task Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Processes.ResumeLayout(false);
            this.Processes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProcesses)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Processes;
        private System.Windows.Forms.DataGridView gridProcesses;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem killProcessToolStripMenuItem;
        private System.Windows.Forms.Timer timerTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPUTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memory;
        private System.Windows.Forms.DataGridViewTextBoxColumn VirtualMemory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Threads;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel countProsecesses;
    }
}

