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
    public partial class ManagementPermissionUsers : Form
    {
        public ManagementPermissionUsers()
        {
            InitializeComponent();
        }


        private void ManagementPermissionUsers_Load(object sender, EventArgs e)
        {
            ListUsers();
        }

        int numberUsers = 0;
        string[] Users = new string[100];
        string selectedUserID = null;

        // Add shared Files into Listview
        private void ListUsers()
        {
            // Add Columns Header
            listView1.Clear();
            listView1.Columns.Add("ID: ", 130);
            listView1.Columns.Add("UserName: ", 170);
            listView1.Columns.Add("NickName: ", 170);
            listView1.Columns.Add("Group: ", 80);
            String sql = "SELECT * FROM Login";
            xuatdulieu(sql);
        }
            // Add Users
        
        public string tenduocchon;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = listView1.FocusedItem.Index;
            tenduocchon = listView1.Items[index].SubItems[1].Text;
           
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tenduocchon) == false)
            {
                DialogResult dialog = MessageBox.Show("Вы уверены, что хотите удалить?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    MessageBox.Show("Удалено", "Сообщение",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
                    con.Open();
                    String sql;

                    sql = "DELETE FROM Login where username = N'" + tenduocchon + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    listView1.Clear();
                    listView1.Columns.Add("ID: ", 130);
                    listView1.Columns.Add("UserName: ", 170);
                    listView1.Columns.Add("NickName: ", 170);
                    listView1.Columns.Add("Group: ", 80);
                    sql = "SELECT * FROM Login";
                    xuatdulieu(sql);
                    tenduocchon = "";
                }
                else { return; }
            }
            else
            {
                MessageBox.Show("Выбирать", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void xuatdulieu(string sql)
        {

            string[] arr = new string[9];
            ListViewItem item;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
            con.Open();

            //Xuat file da luu ra man hinh
            if (Class.Functions.CheckKey(sql))
            {
                DataTable tbl = Class.Functions.GetDataToTable(sql);
                foreach (DataRow row in tbl.Rows)
                {
                    if (row["username"].ToString() != "ADMIN")
                    {
                        arr[0] = row["Id"].ToString();
                        arr[1] = row["username"].ToString();
                        arr[2] = row["nickname"].ToString();
                        arr[3] = row["role"].ToString();
                        item = new ListViewItem(arr);
                        listView1.Items.Add(item);
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage quayve = new HomePage();
            quayve.Show();
            this.Close();
        }
    }
}

