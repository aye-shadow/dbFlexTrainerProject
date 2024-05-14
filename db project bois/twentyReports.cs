using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
            string q = "";
            if (selectedID == 0) 
            { q = "SELECT m.ID, m.FirstName, m.LastName, m.Email, m.Contact" +
                    "   FROM Member$ m" +
                    "   JOIN Member_Gym$ mg ON m.ID = mg.MemberID" +
                    "   JOIN Training_Session$ ts ON m.ID = ts.MemberID" 
                    //+"   WHERE mg.GymID = 1  AND ts.TrainerID = 1"
                    ; 
            }
            if (selectedID ==1)
            { q = "SELECT m.ID, m.FirstName, m.LastName, m.Email, m.Contact" +
                    "   FROM Member$ m" +
                    "   JOIN Member_Gym$ mg ON m.ID = mg.MemberID" +
                    "   JOIN Diet_Plan_Followers$ dpf ON m.ID = dpf.MemberID"
                    //+"   WHERE mg.GymID = 1 AND dpf.DietPlanID = 1 "
                    ;
            }
            if (selectedID ==2)
            { q = "  SELECT DISTINCT m.ID, m.FirstName, m.LastName, m.Email, m.Contact" +
                    "   FROM Member$ m" +
                    "   JOIN Training_Session$ ts ON m.ID = ts.MemberID" +
                    "   JOIN Diet_Plan_Followers$ dpf ON m.ID = dpf.MemberID"
            //+        "   WHERE ts.TrainerID = 1 AND dpf.DietPlanID = 1"
                ;  
            }
            if (selectedID ==3)
            { 
                //q = "SELECT COUNT(DISTINCT m.ID) AS NumberOfMembers" +
                //    "   FROM Member$ m" +
                //    "   JOIN Member_Gym$ mg ON m.ID = mg.MemberID" +
                //    "   JOIN Training_Session$ ts ON m.ID = ts.MemberID" +
                //    "   JOIN Appointments$ a ON ts.ID = a.TrainingSessionID" +
                //    "   WHERE mg.GymID = 1 AND a.AppointmentDate = getdate() " +
                //    "   AND EXISTS (     " +
                //    "       SELECT 1 FROM Workout_Exercise$ we      " +
                //    "       JOIN Exercise$ e ON we.ExerciseID = e.ID     " +
                //    "       WHERE e.EquipmentID = 1  AND we.ExerciseID = ts.ExerciseID   " +
                //    ")"; 
            }
            if (selectedID == 4)
            { q = "SELECT DISTINCT dp.ID, dp.Purpose, dp.Type FROM DietPlan$ dp" +
                    "   JOIN DitPlan_meals$ dpm ON dp.ID = dpm.DietPlanID" +
                    "   JOIN Meal$ m ON dpm.MealID = m.ID" +
                    "   WHERE m.Calories < 500 AND m.Type = 'Breakfast'"; }
            if(selectedID == 5)
            { q = " SELECT dp.ID, dp.Purpose, dp.Type" +
                    "   FROM DietPlan$ dp" +
                    "   JOIN DitPlan_meals$ dpm ON dp.ID = dpm.DietPlanID" +
                    "   JOIN Meal$ m ON dpm.MealID = m.ID" +
                    "   GROUP BY dp.ID, dp.Purpose, dp.Type" +
                    "   HAVING SUM(m.Carbs) < 300";  }
            if (selectedID == 6)
            {
                q = " SELECT DISTINCT wp.ID, wp.ExperienceLevel, wp.Goal" +
                    "   FROM Workout_Plan$ wp" +
                    "   WHERE NOT EXISTS (" +
                    "       SELECT 1 FROM Workout_Exercise$ we" +
                    "       JOIN Exercise$ e ON we.ExerciseID = e.ID" +
                    "       WHERE e.EquipmentID = 1 AND we.WorkoutID = wp.ID" +
                    "   ) ";
            }
            if (selectedID == 7)
            { q = " SELECT DISTINCT dp.ID, dp.Purpose, dp.Type" +
                    "   FROM DietPlan$ dp" +
                    "   WHERE NOT EXISTS (" +
                    "       SELECT 1 FROM DitPlan_Meals$ dpm" +
                    "       JOIN Meal_Allergy$ ma ON dpm.MealID = ma.MealID" +
                    "       JOIN Allergens$ a ON ma.AllergyID = a.ID" +
                    "       WHERE a.Name = 'Peanuts' AND dpm.DietPlanID = dp.ID" +
                    "   ) ";  }
            if(selectedID == 8)
            {
                q = "SELECT mg.GymID, COUNT(mg.MemberID) AS NewMembers FROM Member_Gym$ mg WHERE mg.JoinDate >= DATEADD(MONTH, -3, GETDATE()) GROUP BY mg.GymID;";
            }
            if(selectedID==9)
            {
                q = " SELECT mg.GymID, COUNT(DISTINCT mg.MemberID) AS TotalMembers FROM Member_Gym$ mg WHERE mg.JoinDate >= DATEADD(MONTH, -6, GETDATE()) GROUP BY mg.GymID;";
            }
            if(selectedID == 10 )
            {
                q = " SELECT t.ID, t.FirstName, t.LastName, t.Email, t.Contact, tg.GymID    " +
                    "FROM Trainer$ t   " +
                    "JOIN Trainer_Gym$ tg ON t.ID = tg.TrainerID    " +
                    "WHERE tg.RegistrationDate <= getdate() AND tg.ApprovalStatus = 'Approved' ";
            }
            if(selectedID == 11 )
            {
                q = " SELECT m.ID, m.FirstName, m.LastName, m.Email " +
                    "FROM Member$ m " +
                    "WHERE NOT EXISTS (" +
                    "    SELECT 1 FROM Training_Session$ ts" +
                    "    WHERE ts.MemberID = m.ID AND ts.RequestDate >= DATEADD(MONTH, -1, GETDATE())" +
                    ")  "; 
            }
            if(selectedID == 12 )
            {
                q = " SELECT t.ID, t.FirstName, t.LastName, COUNT(dp.ID) AS NumberOfDietPlans" +
                    "   FROM Trainer$ t" +
                    "   JOIN DietPlan$ dp ON dp.CreatorID = t.ID AND dp.CreatorType = 'Trainer'" +
                    "   WHERE dp.ShareStatus = 'Active'" +
                    "   GROUP BY t.ID,t.FirstName, t.LastName  ";
            }
            if(selectedID == 13 )
            {
                q = " SELECT g.GymID, g.GymName" +
                    "   FROM Gym$ g" +
                    "   WHERE NOT EXISTS (" +
                    "       SELECT 1 FROM Trainer_Gym$ tg" +
                    "       WHERE tg.GymID = g.GymID AND tg.ApprovalStatus = 'Approved'" +
                    "   ) "; 
            }
            if (selectedID ==14)
            {
                q = "   SELECT t.ID, t.FirstName, t.LastName, COUNT(f.ID) AS LowRatingsCount" +
                    "   FROM Trainer$ t" +
                    "   JOIN Feedback$ f ON t.ID = f.TrainerID" +
                    "   WHERE f.Stars < 3" +
                    "   GROUP BY t.ID,t.FirstName, t.LastName";
            }
            if (selectedID == 15 )
            {
                q = "  SELECT m.ID, m.FirstName, m.LastName" +
                    "   FROM Member$ m" +
                    "   JOIN Diet_Plan_Followers$ dpf ON m.ID = dpf.MemberID" +
                    "   JOIN Workout_Followers$ wf ON m.ID = wf.MemberID " +
                    "JOIN DietPlan$ dp ON dpf.DietPlanID = dp.ID AND dp.Purpose = 'Weight Loss'" +
                    "   JOIN Workout_Plan$ wp ON wf.WorkoutID = wp.ID AND wp.Goal = 'Weight Loss'";
            }
            if ( selectedID == 16 )
            {
                //q = "  SELECT t.ID, t.FirstName, t.LastName, COUNT(DISTINCT ts.Specialties) AS SpecialtyCount " +
                //    "FROM Trainer$ t " +
                //    "JOIN Trainer_Specialties ts ON t.ID = ts.TrainerID " +
                //    "WHERE t.JoinDate >= DATEADD(YEAR, -1, GETDATE()) " +
                //    "GROUP BY t.ID, t.FirstName, t.LastName " +
                //    "ORDER BY SpecialtyCount DESC;";
            }
            if (selectedID == 17 )
            {
                //q = " SELECT t.ID, t.FirstName, t.LastName, AVG(ts.TrainingDuration) AS AverageDuration " +
                //    "FROM Trainer$ t JOIN Training_Session$ ts ON t.ID = ts.TrainerID " +
                //    "WHERE ts.RequestDate >= DATEADD(MONTH, -1, GETDATE()) " +
                //    "GROUP BY t.ID, t.FirstName, t.LastName;                "; 
            }
            if(selectedID == 18 )
            {
                //q = " SELECT m.ID, m.FirstName, m.LastName, COUNT(*) AS EquipmentUsageCount " +
                //    "FROM Member$ m " +
                //    "JOIN Training_Session$ ts ON m.ID = ts.MemberID " +
                //    "JOIN Workout_Exercise$ we ON ts.WorkoutID = we.WorkoutID " +
                //    "JOIN Exercise e ON we.ExerciseID = e.ID " +
                //    "WHERE e.EquipmentID = 1 AND ts.RequestDate >= DATEADD(YEAR, -1, GETDATE()) " +
                //    "GROUP BY m.ID, m.FirstName, m.LastName " +
                //    "ORDER BY EquipmentUsageCount DESC;                "; 
            }
            if(selectedID == 19 )
            {
                q = "  SELECT g.GymID, g.GymName, SUM(ge.Amount) AS TotalEquipment" +
                    "    FROM Gym$ g" +
                    "    JOIN Gym_Equipment$ ge ON g.GymID = ge.GymID" +
                    "    GROUP BY g.GymID, g.GymName   ";
            }
            if (selectedID == 20)
            {

            }
          
          if (q != "")
            {
                string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(q, connection))
                    {
                        connection.Open();

                        DataTable dataTable = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
