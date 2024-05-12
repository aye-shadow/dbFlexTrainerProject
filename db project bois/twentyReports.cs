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
            string q;
            if (selectedID == 0) 
            { q = "SELECT m.ID, m.FirstName, m.LastName, m.Email, m.Contact\r\n   FROM Member$ m\r\n   JOIN Member_Gym$ mg ON m.ID = mg.MemberID\r\n   JOIN Training_Session$ ts ON m.ID = ts.MemberID\r\n   WHERE mg.GymID = 1  AND ts.TrainerID = 1;\r\n"; }
            if (selectedID ==1)
            { q = "SELECT m.ID, m.FirstName, m.LastName, m.Email, m.Contact\r\n   FROM Member$ m\r\n   JOIN Member_Gym$ mg ON m.ID = mg.MemberID\r\n   JOIN DietPlan_Followers$ dpf ON m.ID = dpf.MemberID\r\n   WHERE mg.GymID = 1 AND dpf.DietPlanID = 1 "; }
            if (selectedID ==2)
            { q = "  SELECT DISTINCT m.ID, m.FirstName, m.LastName, m.Email, m.Contact\r\n   FROM Member$ m\r\n   JOIN Training_Session$ ts ON m.ID = ts.MemberID\r\n   JOIN DietPlan_Followers dpf ON m.ID = dpf.MemberID\r\n   WHERE ts.TrainerID = 1 AND dpf.DietPlanID = 1";  }
            if (selectedID ==3)
            { q = "SELECT COUNT(DISTINCT m.ID) AS NumberOfMembers\r\n   FROM Member$ m\r\n   JOIN Member_Gym$ mg ON m.ID = mg.MemberID\r\n   JOIN Training_Session$ ts ON m.ID = ts.MemberID\r\n   JOIN Appointments$ a ON ts.ID = a.TrainingSessionID\r\n   WHERE mg.GymID = 1 AND a.AppointmentDate = getdate() \r\n   AND EXISTS (     SELECT 1 FROM Workout_Exercise$ we      JOIN Exercise$ e ON we.ExerciseID = e.ID     WHERE e.EquipmentID = 1  AND we.WorkoutID = ts.WorkoutID\r\n   )"; }
            if (selectedID == 4)
            { q = "SELECT DISTINCT dp.ID, dp.Purpose, dp.Type FROM DietPlan$ dp\r\n   JOIN DietPlan_Meals$ dpm ON dp.ID = dpm.DietPlanID\r\n   JOIN Meal$ m ON dpm.MealID = m.ID\r\n   WHERE m.Calories < 500 AND m.Type = 'Breakfast'"; }
            if(selectedID == 5)
            { q = " SELECT dp.ID, dp.Purpose, dp.Type\r\n   FROM DietPlan$ dp\r\n   JOIN DietPlan_Meals$ dpm ON dp.ID = dpm.DietPlanID\r\n   JOIN Meal$ m ON dpm.MealID = m.ID\r\n   GROUP BY dp.ID\r\n   HAVING SUM(m.Carbs) < 300";  }
            if (selectedID == 6)
            {
                q = " SELECT DISTINCT wp.ID, wp.ExperienceLevel, wp.Goal\r\n   FROM Workout_Plan$ wp\r\n   WHERE NOT EXISTS (\r\n       SELECT 1 FROM Workout_Exercise$ we\r\n       JOIN Exercise$ e ON we.ExerciseID = e.ID\r\n       WHERE e.EquipmentID = 1 AND we.WorkoutID = wp.ID\r\n   ) ";
            }
            if (selectedID == 7)
            { q = " SELECT DISTINCT dp.ID, dp.Purpose, dp.Type\r\n   FROM DietPlan$ dp\r\n   WHERE NOT EXISTS (\r\n       SELECT 1 FROM DietPlan_Meal$s dpm\r\n       JOIN Meal_Allergy$ ma ON dpm.MealID = ma.MealID\r\n       JOIN Allergens$ a ON ma.AllergyID = a.ID\r\n       WHERE a.Name = 'Peanuts' AND dpm.DietPlanID = dp.ID\r\n   ) ";  }
          if(selectedID == 8)
            {
                q = " SELECT mg.GymID, COUNT(mg.MemberID) AS NewMembers\r\n   FROM Member_Gym$ mg\r\n   WHERE mg.JoinDate >= DATE_SUB(CURDATE(), INTERVAL 3 MONTH)\r\n   GROUP BY mg.GymID;\r\n ";
            }
          if(selectedID==9)
            {
                q = " SELECT mg.GymID, COUNT(DISTINCT mg.MemberID) AS TotalMembers\r\n    FROM Member_Gym$ mg\r\n    WHERE mg.JoinDate >= DATE_SUB(CURDATE(), INTERVAL 6 MONTH)\r\n    GROUP BY mg.GymID ";
            }
          if(selectedID == 10 )
            {
                q = " SELECT t.ID, t.FirstName, t.LastName, t.Email, t.Contact, tg.GymID    FROM Trainer$ t   JOIN Trainer_Gym$ tg ON t.ID = tg.TrainerID    WHERE tg.RegistrationDate <= getdate() AND tg.ApprovalStatus = 'Approved' ";
            }
          if(selectedID == 11 )
            {
                q = " SELECT m.ID, m.FirstName, m.LastName, m.Email\r\n   FROM Member$ m\r\n   WHERE NOT EXISTS (\r\n       SELECT 1 FROM Training_Session$ ts\r\n       WHERE ts.MemberID = m.ID AND ts.RequestDate >= DATE_SUB(CURDATE(), INTERVAL 1 MONTH)   )  "; 
            }
          if(selectedID == 12 )
            {
                q = " SELECT t.ID, t.FirstName, t.LastName, COUNT(dp.ID) AS NumberOfDietPlans\r\n   FROM Trainer$ t\r\n   JOIN DietPlan$ dp ON dp.CreatorID = t.ID AND dp.CreatorType = 'Trainer'\r\n   WHERE dp.ShareStatus = 'Active'\r\n   GROUP BY t.ID  ";
            }
          if(selectedID == 13 )
            {
                q = " SELECT g.GymID, g.GymName\r\n   FROM Gym$ g\r\n   WHERE NOT EXISTS (\r\n       SELECT 1 FROM Trainer_Gym$ tg\r\n       WHERE tg.GymID = g.GymID AND tg.ApprovalStatus = 'Approved'\r\n   ) "; 
            }
          if (selectedID ==14)
            {
                q = "   SELECT t.ID, t.FirstName, t.LastName, COUNT(f.ID) AS LowRatingsCount\r\n   FROM Trainer$ t\r\n   JOIN Feedback$ f ON t.ID = f.TrainerID\r\n   WHERE f.Stars < 3\r\n   GROUP BY t.ID";
            }
          if (selectedID == 15 )
            {
                q = "  SELECT m.ID, m.FirstName, m.LastName\r\n   FROM Member$ m\r\n   JOIN DietPlan_Followers$ dpf ON m.ID = dpf.MemberID\r\n   JOIN Workout_Followers$ wf ON m.ID = wf.MemberID JOIN DietPlan$ dp ON dpf.DietPlanID = dp.ID AND dp.Purpose = 'Weight Loss'\r\n   JOIN Workout_Plan$ wp ON wf.WorkoutID = wp.ID AND wp.Goal = 'Weight Loss'";
            }
          if ( selectedID == 16 )
            {
                q = "  SELECT t.ID, t.FirstName, t.LastName, COUNT(DISTINCT ts.Specialties) AS SpecialtyCount\r\n   FROM Trainer$ t\r\n   JOIN Trainer_Specialties ts ON t.ID = ts.TrainerID\r\n   WHERE t.JoinDate >= DATE_SUB(CURDATE(), INTERVAL 1 YEAR)\r\n   GROUP BY t.ID\r\n   ORDER BY SpecialtyCount DESC  ";
            }
          if (selectedID == 17 )
            {
                q = " SELECT t.ID, t.FirstName, t.LastName, AVG(ts.TrainingDuration) AS AverageDuration\r\n   FROM Trainer$ t\r\n   JOIN Training_Session$ ts ON t.ID = ts.TrainerID\r\n   WHERE ts.RequestDate >= DATE_SUB(CURDATE(), INTERVAL 1 MONTH)\r\n   GROUP BY t.ID  "; 
            }
          if(selectedID == 18 )
            {
                q = " SELECT m.ID, m.FirstName, m.LastName, COUNT(*) AS EquipmentUsageCount\r\n   FROM Member$ m\r\n   JOIN Training_Session$ ts ON m.ID = ts.MemberID\r\n   JOIN Workout_Exercise$ we ON ts.WorkoutID = we.WorkoutID\r\n   JOIN Exercise e ON we.ExerciseID = e.ID\r\n   WHERE e.EquipmentID = 1 AND ts.RequestDate >= DATE_SUB(CURDATE(), INTERVAL 1 YEAR)\r\n   GROUP BY m.ID\r\n   ORDER BY EquipmentUsageCount DESC   "; 
            }
          if(selectedID == 19 )
            {
                q = "  SELECT g.GymID, g.GymName, SUM(ge.Amount) AS TotalEquipment\r\n    FROM Gym$ g\r\n    JOIN Gym_Equipment$ ge ON g.GymID = ge.GymID\r\n    GROUP BY g.GymID   ";
            }
            MessageBox.Show("Selected Item ID: " + selectedID);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
