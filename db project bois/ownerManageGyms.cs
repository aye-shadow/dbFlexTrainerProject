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
        public int id;
        public ownerManageGyms(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ownerHome ownerHome = new ownerHome(id );
            this.Hide();
            ownerHome.Show();
        }

        private void lname_Click(object sender, EventArgs e)
        {

        }
    }
}
