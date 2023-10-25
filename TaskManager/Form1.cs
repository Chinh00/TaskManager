using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

        }
        Uri serverUri = new Uri("wss://chat-server-0cw6.onrender.com");// Replace with the appropriate address of your Express.js server
        Process[] processes;
        ClientWebSocket webSocket;
        string diskCurrent = Directory.GetCurrentDirectory().Split('\\')[0];
        string previous = string.Empty;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProcess();
            timer1.Start();
            timer2.Start();
            metroGrid1.Rows.Clear();
            processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                metroGrid1.Rows.Add(process.ProcessName, process.Id, process.WorkingSet64);
            }



            metroLabel7.Text = diskCurrent;

            LoadFile(diskCurrent);


        }

        private void LoadFile(string path)
        {
            try
            {
                if (path == "<-")
                {
                    path = string.Join("\\", previous.Take(0).Skip(previous.Length - 1));
                    string[] sub = Directory.GetDirectories(path + @"\");
                    metroGrid2.Rows.Clear();
                    metroGrid2.Rows.Add("<-");
                    foreach (string subdirectory in sub)
                    {
                        metroGrid2.Rows.Add(subdirectory);
                    }
                }
                else
                {
                    string[] sub = Directory.GetDirectories(path + @"\");
                    metroGrid2.Rows.Clear();
                    metroGrid2.Rows.Add("<-");
                    foreach (string subdirectory in sub)
                    {
                        metroGrid2.Rows.Add(subdirectory);
                    }
                }
                previous = path;
            }
            catch { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {


        }



        private void button1_Click(object sender, EventArgs e)
        {


        }


        public void LoadProcess()
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new Performance()).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

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



        private void timer2_Tick(object sender, EventArgs e)
        {

            // lay lai du lieu process moi
            processes = Process.GetProcesses();
            var list_remove = new List<DataGridViewRow>();
            var list_add = new List<Process>();
            metroLabel6.Text = processes.Length.ToString();
            // lay danh sach pid cu <dong, pid>

            foreach (DataGridViewRow item in metroGrid1.Rows)
            {
                try
                {
                    int processId = Convert.ToInt32(item.Cells[1].Value);
                    Process data = processes.FirstOrDefault(p => p.Id == processId);
                    // cap nhat cai dang co tren datagridview
                    if (data != null)
                    {
                        item.Cells[2].Value = data?.WorkingSet64.ToString();
                        list_add.Add(data);
                    }
                    else
                    {
                        list_remove.Add(item);
                    }

                }
                catch { }

            }
            foreach (var item in list_remove)
            {
                metroGrid1.Rows.Remove(item);
            }
            foreach (var item in processes)
            {
                if (!list_add.Select(t => t.Id).Contains(item.Id))
                {
                    metroGrid1.Rows.Add(item.ProcessName, item.Id, item.WorkingSet64);
                }
            }




        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = metroGrid1.CurrentCell.RowIndex;
                int pId = Convert.ToInt32(metroGrid1.Rows[index].Cells[1].Value);
                Process.GetProcessById(pId).Kill();
                if (Process.GetProcessById(pId) != null)
                {
                    MessageBox.Show("Kill successfully");
                }
            }
            catch { }
        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the value from the clicked cell
                LoadFile(metroGrid2.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void metroGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            (new ShowThreads(Convert.ToInt32(metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells[1].Value.ToString()))).Show();
        }

        private async void metroButton2_Click(object sender, EventArgs e)
        {
            webSocket = new ClientWebSocket();


            await webSocket.ConnectAsync(serverUri, CancellationToken.None);

            MessageBox.Show("Connect successfully ...");

            await Task.Run(ReceiveMessages);
        }
        async Task ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            while (webSocket.State == WebSocketState.Open)
            {
                try
                {
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    this.Invoke(new Action(() =>
                    {
                        metroGrid3.Rows.Add(message);
                    }));
                   
                }
                catch (WebSocketException)
                {
                    // Handle WebSocket connection errors here
                    break;
                }
            }
        }
        async Task SendMessage(ClientWebSocket webSocket, string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);

            await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async void metroButton3_Click(object sender, EventArgs e)
        {
            await SendMessage(webSocket, $"{metroTextBox1.Text}: {metroTextBox2.Text}");
            metroTextBox2.Text = "";
        }
    }
}
