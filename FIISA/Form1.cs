using DLLForumV2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIISA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Forum f = new Forum();
            dataGridView1.DataSource = await f.GetListRubrics();
            dataGridView2.DataSource = await f.GetListTopics();
        }
    }
}
