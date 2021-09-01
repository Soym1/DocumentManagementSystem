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

namespace DocumentManagementSystem
{
    public partial class Detail : Form
    {
        public Detail()
        {
            InitializeComponent();
        }
        string[] arr = new string[8];
        private void Detail_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
            con.Open();

           
            ListViewItem item;
            //Xuat file da luu ra man hinh
            String sql;
            sql = "SELECT * FROM LINK WHERE Id = N'" + HomePage.tenduocchon + "'";
            DataTable tbl = Class.Functions.GetDataToTable(sql);
            foreach (DataRow row in tbl.Rows)
            {
                textBox2.Text = row["Id"].ToString();
                textBox2.Enabled = false;
                comboBox2.Text = row["Document"].ToString();
                comboBox1.Text = row["Tip"].ToString();
                textBox3.Text = row["Author"].ToString();
                textBox4.Text = row["Author"].ToString();
                textBox4.Enabled = false;
                richTextBox1.Text = row["GhiChu"].ToString();
                textBox5.Text = row["Mecto"].ToString();
                maskedTextBox1.Text = row["NgayNhap"].ToString();
                textBox7.Text = row["Chuky"].ToString();
                textBox7.Enabled = false;
                textBox8.Text = row["NgayHientai"].ToString();
                textBox8.Enabled = false;
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskFull)
            {
                try
                {
                    DateTime.ParseExact(maskedTextBox1.Text, "M/d/yyyy", null);
                }
                catch
                {
                    MessageBox.Show("Дата введена как «М / д / гггг»", "СООБЩЕНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox1.ResetText();
                    maskedTextBox1.Focus();
                    return;
                }
            }
                SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
            con.Open();

            ListViewItem item;
            //Xuat file da luu ra man hinh
            String sql;
            sql = "UPDATE LINK SET Document = N'" + comboBox2.Text + "', Tip = N'" + comboBox1.Text +"'"  + ",GhiChu = N'" +richTextBox1.Text.Trim() +"'"
                + ",Mecto = N'" + textBox5.Text.Trim() + "'" + ",NgayNhap = N'" + maskedTextBox1.Text.Trim() + "'" + " WHERE Id = N'" + HomePage.tenduocchon + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("СОХРАНЕНО", "СООБЩЕНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

    }
}
