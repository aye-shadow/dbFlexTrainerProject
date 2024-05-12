using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_project_bois
{
    public partial class ownerAddNewGym : Form
    {
        int id;
        public ownerAddNewGym(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ownerAndHisGyms ownerAndHisGyms = new ownerAndHisGyms(id);
            this.Hide();
            ownerAndHisGyms.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fnameTextBox.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // insert into database with status = "pending"
                string g = fnameTextBox.Text;
                string gl = textBox1.Text;
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                SqlCommand command;
                conn.Open();
                string query2 = "SELECt status FROM Gym$ WHERE GymName = @gym";
                object result;
                using (command = new SqlCommand(query2, conn))
                {
                    command.Parameters.AddWithValue("@gym", g);
                    result = command.ExecuteScalar();
                }
                if (result != null)
                {
                    if ((string)result == "Active")
                    { MessageBox.Show("gym is already registered. Enter another Gym name.");
                        return;
                    }
                    if ((string)result == "Banned")
                    {
                        MessageBox.Show("This gym is Banned, Create new with different name.");
                        return;
                    }

                    query2 = "Update gym$ set status = 'Active', Approval = 'Pending' , Location = @gl, Gymownerid = @id where gymname = @gym";
                    using (command = new SqlCommand(query2, conn))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@gl", gl);
                        command.Parameters.AddWithValue("@gym", g);
                        result = command.ExecuteNonQuery();
                        if ( (int)result >= 1)
                        {
                            MessageBox.Show("Gym registration to an existing gym!");
                            ownerAndHisGyms ownerAndHisGyms = new ownerAndHisGyms(id);
                            this.Hide();
                            ownerAndHisGyms.Show();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Failed to register gym.");
                            return;
                        }
                    }
                }
                string queryk = "SELECT max(GymID) FROM gym$ ";
                command = new SqlCommand(queryk, conn);
                result = command.ExecuteScalar();
                int rowsAffected;

                int gID = Convert.ToInt32(result);
                gID += 1;
                string query3 = "INSERT INTO Gym$ (GymID,GymOwnerID, GymName, Location, Status, Approval) " +
                     "VALUES (@id, @gymOwnerID, @gymName, @location, 'Active', 'Pending' )";

                using (command = new SqlCommand(query3, conn))
                {
                    command.Parameters.AddWithValue("@id", gID);
                    command.Parameters.AddWithValue("@gymOwnerID", id);
                    command.Parameters.AddWithValue("@gymName", g);
                    command.Parameters.AddWithValue("@location", gl);
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected >= 1)
                {
                    MessageBox.Show("Gym registration succesfull!");
                    ownerAndHisGyms ownerAndHisGyms = new ownerAndHisGyms(id);
                    this.Hide();
                    ownerAndHisGyms.Show();
                }
                else
                {
                    MessageBox.Show("Failed to register gym.");
                } 

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void fnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
