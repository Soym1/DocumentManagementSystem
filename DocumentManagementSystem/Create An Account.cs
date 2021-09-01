using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DocumentManagementSystem
{
    public partial class Create_An_Account : Form
    {
        public Create_An_Account()
        {
            InitializeComponent();
        }

        // bt create an account
        private void btCreate_Click(object sender, EventArgs e)
        {
            if (textBoxUserName.Text.Trim() == "")
            {
                MessageBox.Show("Введите имя пользователя");
                textBoxUserName.Focus();
                return;
            }
            if (textBoxPassword.Text.Trim() == txtBoxConfirm.Text.Trim())
            {
                //khoi tao database

                SqlConnection Con = new SqlConnection();
                Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
                Con.Open();

                SqlCommand cmd = Con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT username FROM Login where username ='" + textBoxUserName.Text.Trim() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                //tach so trong sau
                Regex reg = new Regex(@"\d");
                Match result = reg.Match(comboBoxGroup.Text);
                string resultS = Convert.ToString(result);

                // Conver du lieu
                int i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    string password = Class.HashPassword.Hambam(textBoxPassword.Text.Trim());
                    SqlCommand cmd1 = new SqlCommand("Insert into Login(username,password,nickname,role) values (N'" + textBoxUserName.Text.Trim() + "',N'" + password
                        + "',N'" + textBoxNickName.Text.Trim() + "',N'" + resultS + "')", Con);

                    int j = cmd1.ExecuteNonQuery();

                    Con.Close();
                    if (j != 0)
                    {
                        MessageBox.Show("Saved", "", MessageBoxButtons.OK);
                    }
                    Login login = new Login();
                    this.Close();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Username already exists.Try with another username.!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Password and confirm are not correct. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Clear();
                txtBoxConfirm.Clear();
                textBoxPassword.Focus();
            }
 
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void Create_An_Account_Load(object sender, EventArgs e)
        {

        }
    }
}
