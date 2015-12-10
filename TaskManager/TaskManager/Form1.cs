using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        int indexSelectedRow;
        int countRows = 0;

        public int IndexSelectedRow
        {
            get { return indexSelectedRow; }
            set { indexSelectedRow = value; }
        }

        public int CountProcesses
        {
            get { return countRows; }
            set { countRows = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridProcesses.MultiSelect = false;
            gridProcesses.Columns["ProcessName"].ReadOnly =
                gridProcesses.Columns["ID"].ReadOnly = true;

            UpdateProcesses();
            gridProcesses.Rows[0].Cells[0].Selected = false;
        }


        private void UpdateProcesses()
        {
            int count = 0;
            foreach (var process in Process.GetProcesses())
            {
                gridProcesses.Rows.Add(process.ProcessName,
                                       process.Id,
                                       "", "",
                                       // process.PrivilegedProcessorTime,
                                       // process.UserProcessorTime,
                                       process.WorkingSet64 / 1024 + " Kb",
                                       process.PagedMemorySize64 / 1024 + " Kb",
                                       process.Threads.Count
                                       );
                count++;
            }
            CountProcesses = count;
            countProsecesses.Text = "# processes: " + CountProcesses.ToString();
        }

        private void gridProcesses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IndexSelectedRow = gridProcesses.CurrentCell.RowIndex;
            gridProcesses.Rows[IndexSelectedRow].Selected = true;
        }


        private void gridProcesses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IndexSelectedRow = gridProcesses.CurrentCell.RowIndex;
            gridProcesses.Rows[IndexSelectedRow].Selected = true;
        }

        private void killProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var processName = gridProcesses.Rows[IndexSelectedRow].Cells["ProcessName"].Value;
            if (MessageBox.Show("Do you really want to kill process " + processName + "?", "Killing process", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Process[] processes = Process.GetProcesses();
                var targetProc = processes.First(p => p.ProcessName.Contains(processName.ToString()));
                targetProc.Kill();
            }
        }

        private void gridProcesses_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var h = gridProcesses.HitTest(e.X, e.Y);
                if (h.Type == DataGridViewHitTestType.Cell)
                {
                    IndexSelectedRow = h.RowIndex;
                    gridProcesses.Rows[h.RowIndex].Selected = true;
                }
            }
        }

        private void ClearGrid()
        {
            for (int i = 0; i < gridProcesses.Rows.Count; i++)
            {
                gridProcesses.Rows.RemoveAt(i);
            }
            CountProcesses = 0;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGrid();
            UpdateProcesses();
        }
    }
}
