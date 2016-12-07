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
    public partial class frmFIISA : Form
    {
        public Forum forum = null;
        public frmFIISA()
        {
            InitializeComponent();
            forum = new Forum();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /*Forum f = new Forum();
            //dataGridView1.DataSource = await f.GetListRubrics();
            //dataGridView2.DataSource = await f.GetListTopics();
            Rubric r = new Rubric();
            r.IdRubric = 2;
            //dtgRubric.DataSource = await r.GetListTopicsByRubric(r.IdRubric);
            Topic t = new Topic();
            t.IdTopic = 1;
            dataGridView2.DataSource = await t.GetListMessagesByTopic(t.IdTopic);
            //Registered reg = new Registered();
            //dataGridView1.DataSource = await reg.GetListUsers();*/
            //UCRubric uc = new UCRubric();
            List<Topic> lst;
            lst = await forum.GetListTopics();

            foreach (Topic item in lst)
            {
                
                tableLayoutPanel1.Controls.Add(new UCRubric(item));
                tableLayoutPanel1.RowStyles.Add(new RowStyle());

            }
        }

        private void frmFIISA_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
