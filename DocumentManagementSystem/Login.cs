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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        int i;
        public static string ID;
        public static string PW;
        public static string NickName;
        public static string leverUser;
        String test_password;
        String sql;
        DataTable tbl;

        private void btLogin_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"\d");
            Match ketqua = reg.Match("Chau chi co 1");
            string ketqua1 = Convert.ToString(ketqua);
          
            if (textBoxID.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your username!","Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBoxID.Focus();
                return;
            }
            if (textBoxPW.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPW.Focus();
                return;
            }

            //Check info
            i = 0;
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
            Con.Open();

            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string password = Class.HashPassword.Hambam(textBoxPW.Text.Trim());

            cmd.CommandText = "SELECT username,password FROM Login where username ='" + textBoxID.Text.Trim() + "' and password = '" + password + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("UserName or Password is not correct.Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxID.Focus();
            }
            else
            {
                ID = textBoxID.Text.Trim();
                PW = textBoxPW.Text.Trim();
                sql = "SELECT nickname, role FROM Login WHERE username ='" + ID + "'";
                tbl = Class.Functions.GetDataToTable(sql);
                DataRow dr = tbl.Rows[0];
                NickName = Convert.ToString(dr["nickname"]);
                leverUser = Convert.ToString(dr["role"]);
                HomePage page = new HomePage(ID,leverUser,NickName);
                page.Show();
                this.Hide();
                lbWrongAccount.Visible = false;
            }
        }
        private void btnCreat_Click(object sender, EventArgs e)
        {
            Create_An_Account account = new Create_An_Account();
            account.Show();
            this.Hide();
        }

    
    }
}
