using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNotepad
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            //richTextBox1.Height = tableLayoutPanel1.Height - statusStrip1.Height;
            //Button bt1 = new Button();
            //bt1.Parent = this;
            //this.Controls.Add(bt1);
            //bt1.Location = new Point(100, 100);
            //bt1.Show();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //tableLayoutPanel1.SuspendLayout();

            //Point temp = button1.Location;
            //button1.Location = button2.Location;
            //button2.Location = temp;
            //button1.Visible=!button1.Visible;
            //tableLayoutPanel1.SetRowSpan(button2, 2);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = !statusStrip1.Visible;
            //tableLayoutPanel1.SetRowSpan(richTextBox1, 2);
        }

        private void TestForm_SizeChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(statusStrip1.Height);
            //tableLayoutPanel1.SetRowSpan(richTextBox1, 2);
            //richTextBox1.Height = tableLayoutPanel1.Height-statusStrip1.Height;
        }
    }
}
