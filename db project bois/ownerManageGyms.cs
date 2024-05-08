using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_project_bois
{
    public partial class ownerManageGyms : Form
    {
        public ownerManageGyms()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ownerHome ownerHome = new ownerHome();
            this.Hide();
            ownerHome.Show();
        }
    }
}
