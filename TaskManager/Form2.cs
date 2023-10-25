using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Performance : MetroFramework.Forms.MetroForm
    {
        public Performance()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float fcpu = pCpu.NextValue();
            float fram = pRam.NextValue();
            metroProgressBarRam.Value = (int)fram;
            metroProgressBarCpu.Value = (int)fcpu;
            metroLabel2.Text = string.Format("{0:.0%}", fcpu);
            metroLabel4.Text = string.Format("{0:.0%}", fram);
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);
        }
    }
}
