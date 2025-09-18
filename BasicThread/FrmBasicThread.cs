using System;
using System.Threading;
using System.Windows.Forms;

namespace BasicThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("-Before starting Thread -");
            label1.Text = "-The thread is Running-";

            Thread threadA = new Thread(new ThreadStart(StartThreadA));
            Thread threadB = new Thread(new ThreadStart(StartThreadB));

            threadA.Name = "Thread A";
            threadB.Name = "Thread B";

            threadA.Start();
            threadB.Start();
        }

        private void StartThreadA()
        {
            MyThreadClass.Thread1(listBox1);
            SetEndText();
        }

        private void StartThreadB()
        {
            MyThreadClass.Thread1(listBox1);
            listBox1.Items.Add("-End of thread-");
        }

        private void SetEndText()
        {
            if (label1.InvokeRequired)
            {
                label1.Invoke(new MethodInvoker(SetEndText));
            }
            else
            {
                label1.Text = "-End Of Thread-"; 
            }
        }
    }
}//Michael G.