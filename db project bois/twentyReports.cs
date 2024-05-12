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
    public partial class twentyReports : Form
    {
        private string memberType;
        private int memberID;
        private Dictionary<int, string> itemsWithIDs = new Dictionary<int, string>();
        public twentyReports(string memberType, int memberID = 1)
        {
            InitializeComponent();
            initialiseComboBox();
            this.memberID = memberID;
            this.memberType = memberType;
        }

        private void initialiseComboBox()
        {
            itemsWithIDs.Add(1, "Members getting training from TrainerX in GymY");
            itemsWithIDs.Add(2, "Members following Diet PlanY");
            itemsWithIDs.Add(3, "Members getting training from TrainerY and following Diet PlanZ");
            itemsWithIDs.Add(4, "Total members using MachineX on DayY");
            itemsWithIDs.Add(5, "Diet Plans with < 500 calorie breakfasts");
            itemsWithIDs.Add(6, "Diet Plans having carbs < 500");
            itemsWithIDs.Add(7, "Workout Plans that don't require a machine");
            itemsWithIDs.Add(8, "Diet Plans that don't contain peanut allergen");
            itemsWithIDs.Add(9, "New Members in past 3 months");
            itemsWithIDs.Add(10, "Comparison of new memberships of all gyms in past 6 months");
            itemsWithIDs.Add(11, "Trainers who have been in GymX since DayY");
            itemsWithIDs.Add(12, "Members who have not attended any training sessions in past month");
            itemsWithIDs.Add(13, "Gyms in LocationX");
            itemsWithIDs.Add(14, "Gyms with no active trainers");
            itemsWithIDs.Add(15, "Trainers with an average rating of < 3 stars");
            itemsWithIDs.Add(16, "Approved Trainers in each gym with > 1 year tenure");
            itemsWithIDs.Add(17, "Members with training sessions with multiple Trainers");
            itemsWithIDs.Add(18, "Members with > 1 training session with same Trainer");
            itemsWithIDs.Add(19, "Members following 'bulking' Diet Plan and '' Workout Plan");
            itemsWithIDs.Add(20, "Comparison of total equipment amount across all gyms");

            foreach (var item in itemsWithIDs.Values)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (memberType == "admin")
            {
                admin_home admin_Home = new admin_home(memberID);
                this.Hide();
                admin_Home.Show();
            }
        }

        private int GetSelectedID(string selectedItem)
        {
            foreach (var pair in itemsWithIDs)
            {
                if (pair.Value == selectedItem)
                {
                    return pair.Key;
                }
            }

            return -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedID = GetSelectedID(comboBox1.SelectedItem.ToString());
            MessageBox.Show("Selected Item ID: " + selectedID);
        }
    }
}
