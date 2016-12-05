using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLForumV2;

namespace FIISA
{
    public partial class UCRubric : UserControl
    {
        public UCRubric()
        {
            InitializeComponent();
        }

        public UCRubric(Topic topic) : this()
        {
            lblPseudo.Text = topic.ObjUser.LoginUser;
            lblStatus.Text = topic.ObjUser.ObjStatus.NameStatus;
            lblTraining.Text = topic.ObjUser.ObjTraining.NameTraining;
            lblTitre.Text = topic.TitleTopic;
            lblDate.Text = topic.DateTopic.ToString();
            lblDesc.Text = topic.DescTopic;
        }
        
    }
}
