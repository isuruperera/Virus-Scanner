using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Virus_Scanner
{
    public partial class Form1 : Form
    {
        string username;
        string password;
        MySqlConnectionStringBuilder connectionStr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] promptValue = Prompt.ShowDialog("Enter MySql Username and Password", "MySql Credentials");         
            if (promptValue != null)
            {
                username = promptValue[0];
                password = promptValue[1];
                string sqlConnectionString = "";

                connectionStr = new MySqlConnectionStringBuilder();
                connectionStr.UserID = username;
                connectionStr.Password = password;
                connectionStr.Server = "localhost";
                sqlConnectionString = connectionStr.GetConnectionString(true);
                using (MySqlConnection connDatabase = new MySqlConnection(sqlConnectionString))
                {
                    try {
                        connDatabase.Open();
                        string query = "SHOW DATABASES";
                        MySqlCommand script = new MySqlCommand(query, connDatabase);
                        MySqlDataReader rdr = script.ExecuteReader();
                        Boolean flag = false;
                        while (rdr.Read())
                        {

                            if (rdr.GetString(0).Equals("virus_scanner"))
                            {
                                log_list.Items.Add(String.Format("{0:T}", DateTime.Now) + ": Database Loaded");
                                flag = true;
                            }

                        }
                        if (!flag)
                        {
                            log_list.Items.Add(String.Format("{0:T}", DateTime.Now) + ": Database Sync Started. Please Wait. This may take 2 minutes.");
                            button1.Enabled = false;
                            databaseStatus.Text = "Database Status: Sync in progress. Please Wait.";
                            sqlScript.RunWorkerAsync();
                        }
                        else {
                            databaseStatus.Text = "Database Status: Sync Complete";

                        }
                        connDatabase.Close();
                    }catch(Exception ex){
                        MessageBox.Show("In order to run this program, MySql Server must be installed in this PC");
                    }

                    
                }





            }
            else {
                MessageBox.Show("MySql credentials are required to run this program");
                this.Dispose();
            }
            




        }

        private void sqlScript_DoWork(object sender, DoWorkEventArgs e)
        {
            
            string sqlConnectionString = "";
            connectionStr = new MySqlConnectionStringBuilder();
            connectionStr.UserID = username;
            connectionStr.Password = password;
            connectionStr.Server = "localhost";
            sqlConnectionString = connectionStr.GetConnectionString(true);
            using (MySqlConnection connDatabase = new MySqlConnection(sqlConnectionString))
            {
                connDatabase.Open();
                string query = File.ReadAllText("vx.sql");
                MySqlScript script = new MySqlScript(connDatabase, query);
                script.Delimiter = ";";
                script.Execute();
                connDatabase.Close();
            }
        }

        private void sqlScript_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void sqlScript_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
            log_list.Items.Add(String.Format("{0:T}", DateTime.Now) + ": Database Sync Finished");
            databaseStatus.Text = "Database Status: Sync Complete";
            button1.Enabled = true;
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            byte[] fileMD5Hash;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (var md5 = MD5.Create())
                {
                    log_list.Items.Add(String.Format("{0:T}", DateTime.Now) + ": File: "+openFileDialog1.FileName+" opened");
                    using (var stream = File.OpenRead(openFileDialog1.FileName))
                    {

                        fileMD5Hash = md5.ComputeHash(stream);

                    }
                }
                StringConverter convert = new StringConverter();
                log_list.Items.Add(String.Format("{0:T}", DateTime.Now) + ": File MD5 Hash: " + convert.ToHex(fileMD5Hash, false));
                searchDatabase(convert.ToHex(fileMD5Hash, false));           
            }




        }

        public string[] searchDatabase(string queryMD5)
        {
            string sqlConnectionString = "";
            sqlConnectionString = connectionStr.GetConnectionString(true);

            using (MySqlConnection connDatabase = new MySqlConnection(sqlConnectionString))
            {
                connDatabase.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM virus_scanner.vx where vxMD5 = @md5");
                command.Connection = connDatabase;
                command.Parameters.AddWithValue("@md5",queryMD5);
                
                MySqlDataReader rdr = command.ExecuteReader();
                Boolean flag = false;
                while (rdr.Read())
                {
                    flag = true;
                    log_list.Items.Add("================================================================");
                    log_list.Items.Add(String.Format("{0:T}", DateTime.Now) + ": File identified as a malicious file ");
                    log_list.Items.Add(String.Format("{0:T}", DateTime.Now) + ": Name: " + rdr.GetString(3));
                    log_list.Items.Add(String.Format("{0:T}", DateTime.Now) + ": Type: " + rdr.GetString(10));
                    log_list.Items.Add("================================================================");


                }
                if (!flag) {
                    log_list.Items.Add(String.Format("{0:T}", DateTime.Now) + ": Opened file not identified as a malicious file ");
                    log_list.Items.Add("================================================================");
                }
                
                connDatabase.Close();
            }


            return new string[] { };

        }


    }

    
    

}
