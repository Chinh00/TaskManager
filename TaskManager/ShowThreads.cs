using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class ShowThreads : MetroFramework.Forms.MetroForm
    {
        private ProcessThreadCollection _processThreadCollection;
        private int prId;

        public ShowThreads(int prId)
        {
            InitializeComponent();
            _processThreadCollection = Process.GetProcessById(prId).Threads;
            this.prId = prId;
        }

        
        private async void ShowThreads_Load(object sender, EventArgs e)
        {
            label7.Text = Process.GetProcessById(prId).ProcessName;
            label9.Text = Process.GetProcessById(prId).Id.ToString();
            label10.Text = _processThreadCollection.Count.ToString();
            try
            {
                label2.Text = Process.GetProcessById(prId).StartTime.ToString();
            }
            catch { }
            if (_processThreadCollection.Count > 0)
            {
                foreach (ProcessThread thread in _processThreadCollection)
                {
                    dataGridView1.Rows.Add(thread.Id.ToString(), thread.BasePriority);
                }
            }

        }
    }
}
