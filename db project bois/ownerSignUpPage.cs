﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace db_project_bois
{
    public partial class ownerSignUpPage : Form
    {
        public ownerSignUpPage()
        {
            InitializeComponent();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            signUpPage signUpPage = new signUpPage();
            this.Hide();
            signUpPage.Show();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            string m = emailTextBox.Text;
            string f = fnameTextBox.Text;
            string l = lnameTextBox.Text;
            string c = contactTextBox.Text;
            string p1 = passwordTextBox.Text;
            string p2 = confirmPasswordTextBox.Text;
            string g = gymNameTextBox.Text;
            string gl = gymLocationTextBox.Text;
            if (string.IsNullOrEmpty(m) || string.IsNullOrEmpty(f) || string.IsNullOrEmpty(l) || string.IsNullOrEmpty(c) || string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2) || string.IsNullOrEmpty(g) || string.IsNullOrEmpty(gl))
            {
                MessageBox.Show("Enter all inputs.");
                return;
            }
            if (p1 != p2)
            {
                MessageBox.Show("Password does not match, Enter again.");
                return;
            }
            conn.Open();
            SqlCommand command;

            string query = "INSERT INTO Gym_owner$ (FirstName, LastName, Email, Contact, Password, Status, RegistrationDate) " +
               "VALUES (@fname, @lname, @email, @contactnum, @password, 'Active', GETDATE());";
            int rowsAffected;
            using (command = new SqlCommand(query, conn))
            {            
                command.Parameters.AddWithValue("@fname", f);
                command.Parameters.AddWithValue("@lname", l);
                command.Parameters.AddWithValue("@email", m);
                command.Parameters.AddWithValue("@contactnum", c);
                command.Parameters.AddWithValue("@password", p1);

                // Execute the query and handle the result as needed
                rowsAffected = command.ExecuteNonQuery();
            }
            if (rowsAffected == 1)
            {
                MessageBox.Show("OWNER registered successfully!");
            }
            else
            {
                MessageBox.Show("Failed to register OWNER.");
            }
            string query4 = "SELECT max(ID) FROM gym_owner$ ";
            object r;
            command = new SqlCommand(query4, conn);
            r = command.ExecuteScalar();
            int goID = Convert.ToInt32(r);
            string query2 = "SELECT top 1 GymID FROM Gym$ WHERE GymName = @gym";
            object result;
            using (command = new SqlCommand(query2, conn))
            {
                command.Parameters.AddWithValue("@gym", g);
                result = command.ExecuteScalar();
            }
            if (result == null) 
            {
                MessageBox.Show("gym already registered");
                return;
            }
            string queryk = "SELECT max(ID) FROM gym$ ";
            command = new SqlCommand(queryk, conn);
            result = command.ExecuteScalar();
            
            int gID = Convert.ToInt32(result);
            int gymID = Convert.ToInt32(result);
            gymID += 1;
            string query3 = "INSERT INTO Gym$ (GymID,GymOwnerID, GymName, Location, Status) " +
                 "VALUES (@id, @gymOwnerID, @gymName, @location, 'Active')";

            using (command = new SqlCommand(query3, conn))
            {
                command.Parameters.AddWithValue("@id", gID);
                command.Parameters.AddWithValue("@gymOwnerID", goID);
                command.Parameters.AddWithValue("@gymName", g);
                command.Parameters.AddWithValue("@location", gl);
                rowsAffected = command.ExecuteNonQuery();
            }
            if (rowsAffected > 0)
            {
                MessageBox.Show("Gym registered successfully!");
            }
            else
            {
                MessageBox.Show("Failed to register Gym.");
            }
            conn.Close();
        }

        private void gymNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
