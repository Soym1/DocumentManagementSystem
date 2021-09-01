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
using System.Diagnostics;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DocumentManagementSystem
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // Constans
        const string pathResourseDocument = @"F:\DATA";
        const string FolderFileCmt = @"F:\DATA";

        // Open a new window for user
        string ID;
        string leveluser;
        string Nickname;
        string Role;
        int numbersharedDocument;
        string[] sharedDocumentsLineInfor = new string[100];
        string sql;
        int index;
        string linktailieu;
        string linkanh;
        string linktep;
        string tenluu;
        string duonglink;

        public HomePage(string ID_, string level_, string Nickname_) : this()
        {
            ID = ID_;
            Role = level_;
            Nickname = Nickname_; 
        }
        private void HomePage_Load(object sender, EventArgs e)
        {

            AddSharedFiles();
            if (leveluser == "9")
                managerToolStripMenuItem.Visible = true;
            label13.Text = ID;
            //textBox1.Enabled = false;
        }

        private void createANewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelSearch.Hide();
            txtBoxSearch.Hide();
            btCheck.Hide();
            btnCreatAnewFile.Hide();
            txtBoxSearch.Text = "";
            { groupBoxUpload.Visible = true; comboBoxGroup.SelectedIndex = 3; }
        }

        // Check file if is shared with me
        private string isSharedWithMe(string documentID)
        {
            using (StreamReader sr = new StreamReader("ListDocuments.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (leveluser == "9" && getInforDocument(line)[0].ToString() == documentID)
                        return line;
                    else
                    {
                        string levelDocument = getInforDocument(line)[1].ToString();
                        if ((getInforDocument(line)[0].ToString() == documentID && (Convert.ToInt32(leveluser) + 1) / 2 == Convert.ToInt32(levelDocument))) // || (ID == getInforDocument(line)[2].ToString())
                        {
                            return line;
                        }
                    }
                    
                }

            }
            return "Is not shared";
        }

        /// Get information of Document form file ListDocuments.txt
        /// index - attribute: 0 - documentID
        ///                    1 - levelDocument
        ///                    2 - ID of Author
        ///                    3 - name of file
        ///                    4 - file comments
        private object[] getInforDocument(string line_)
        {
            object[] infor = new object[4];
            int index = 0;
            int start = 0;
            for (int i = 0; i < 4; i++)
            {
                while (line_[index] != ' ') index++;
                infor[i] = line_.Substring(start, index - start);
                start = ++index;
            }
            return infor;
        }

        // Create list shared documents
        private void CreateListDocuments()
        {
            numbersharedDocument = 0;
            // Open folder
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = pathResourseDocument;
            var files = Directory.GetFiles(fbd.SelectedPath);

            // Find shared files
            foreach (string file in files)
            {

                string inforOpenedFile = isSharedWithMe(Path.GetFileNameWithoutExtension(file));
               
                
                if (inforOpenedFile != "Is not shared")
                {
                    sharedDocumentsLineInfor[numbersharedDocument++] = inforOpenedFile;
                }
                else
                {
                    inforOpenedFile = isOwner(Path.GetFileNameWithoutExtension(file));
                    if (inforOpenedFile != "Is not owner")
                    {
                        sharedDocumentsLineInfor[numbersharedDocument++] = inforOpenedFile;
                    }
                }
            }
        }

        // Add shared Files into Listview
        private void AddSharedFiles()
        {
            CreateListDocuments();
            String sql;
            sql = "SELECT * FROM LINK ";
            xuatdulieu(sql);
        }

        //// Get Author of file
        //private string authorOf(string lineInforDocument_)
        //{
        //    using (StreamReader sr = new StreamReader("ListAccount.txt"))
        //    {
        //        string line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            if (inforUser(line)[0].ToString() == getInforDocument(lineInforDocument_)[2].ToString())
        //            {
        //                return inforUser(line)[3].ToString();
        //            }

        //        }
        //    }
        //    return null;
        //}

        /// Get infor of user
        /// inforAccount (index - attribute): 0 - ID,
        ///                                   1 - PW, 
        ///                                   2 - level, 
        private object[] inforUser(string line_)
        {
            object[] infor = new object[4];
            int start = 0;
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                while (line_[index] != ' ') index++;
                infor[i] = line_.Substring(start, index - start);
                start = ++index;
            }
            return infor;
        }

        private void btCmt_Click(object sender, EventArgs e)
        {
            if (textBoxCmt.Text != "")
            {
                textBoxListCmt.Text += "\r\n" + Nickname + ": " + textBoxCmt.Text;
                saveCmt(selectedFileName);
                textBoxCmt.Clear();
            }
            
        }
        
        // get selected File
        string selectedFileName;
        public static string tenduocchon;
        public static string Roleduocchon;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listView1.FocusedItem.Index;
            tenduocchon = listView1.Items[index].SubItems[0].Text;
            Roleduocchon = listView1.Items[index].SubItems[6].Text;
            selectedFileName = getDocumentID(listView1.Items[index].SubItems[8].Text);

      
        }

        // Get ID from FileName
        private string getDocumentID(string fileName_)
        {
            using (StreamReader sr = new StreamReader("ListDocuments.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (fileName_ == getInforDocument(line)[3].ToString())
                    {
                        return getInforDocument(line)[0].ToString() + Path.GetExtension(getInforDocument(line)[3].ToString());
                    }
                }
            }
            return null;
        }

        // Open File (button)
        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (selectedFileName == "")
            {
                MessageBox.Show("Choose your File");
                return;
            }
            labelSearch.Hide();
            txtBoxSearch.Clear();
            txtBoxSearch.Hide();
            btnCreatAnewFile.Hide();
            //if (Role !=  Roleduocchon) { btnDetail.Enabled = false; };
            //MessageBox.Show(Path.GetExtension(selectedFileName));

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
            //con.Open();

            //string sql1 = "SELECT DuongLink FROM link where id = N'" + tenduocchon + "'";
            //if (Class.Functions.CheckKey(sql1))
            //{
            //    DataTable tbl = Class.Functions.GetDataToTable(sql1);
            //    foreach (DataRow row in tbl.Rows)
            //    {
            //        duonglink = row["DuongLink"].ToString();
            //    }
            //}
            //string pathResourseDocument = Path.GetDirectoryName(duonglink);
            //MessageBox.Show("DuongLink:" + pathResourseDocument);

            switch (Path.GetExtension(selectedFileName))
            {
                case ".pdf":
                    {
                        // Open screen to display file
                        { axAcroPDF1.Visible = true; btDownload.Visible = true; btClose.Visible = true; btReload.Visible = true; btnDetail.Visible = true; }
                        { textBoxCmt.Visible = true; textBoxListCmt.Visible = true; btCmt.Visible = true;}
                        axAcroPDF1.src = pathResourseDocument + @"\" + selectedFileName;
                        // Display comments
                        displayComments(selectedFileName);
                        break;
                    }
                case ".docx":
                    {
                        // Open screen to display file
                        { axAcroPDF1.Visible = true; btDownload.Visible = true; btClose.Visible = true;  btReload.Visible = true; btnDetail.Visible = true; }
                        { textBoxCmt.Visible = true; textBoxListCmt.Visible = true; btCmt.Visible = true; }
                        // Create a new file PDF (convert from Word
                        ConvertWordToPDF(selectedFileName);
                        // Open file Word as PDF
                        axAcroPDF1.src = pathResourseDocument + @"\" + Path.GetFileNameWithoutExtension(selectedFileName) + ".pdf";
                        File.Delete(pathResourseDocument + @"\" + Path.GetFileNameWithoutExtension(selectedFileName) + ".pdf");
                        // Display comments
                        displayComments(selectedFileName);
                        break;
                    }
                case ".xlsx":
                    {
                        // Hien thi hop thoai mo tep tin
                        { axAcroPDF1.Visible = true; btClose.Visible = true; btDownload.Visible = true;  btReload.Visible = true; btnDetail.Visible = true; }
                        { textBoxCmt.Visible = true; textBoxListCmt.Visible = true; btCmt.Visible = true; }
                        // Create a new file PDF (convert from word)
                        ConvertExcelToPDF(selectedFileName);
                        // Open file Word as PDF
                        axAcroPDF1.src = pathResourseDocument + @"\" + Path.GetFileNameWithoutExtension(selectedFileName) + ".pdf";
                        File.Delete( pathResourseDocument + @"\" + Path.GetFileNameWithoutExtension(selectedFileName) + ".pdf");
                        // Display comments
                        displayComments(selectedFileName);
                        break;
                    }
                case ".jpg": case ".png":
                    {
                        // Hien thi hop thoai mo tep tin
                        { pictureBox1.Visible = true; btClose.Visible = true; btDownload.Visible = true; btReload.Visible = true; btnDetail.Visible = true; }
                        { textBoxCmt.Visible = true; textBoxListCmt.Visible = true; btCmt.Visible = true; }
                        pictureBox1.Image = System.Drawing.Image.FromFile( pathResourseDocument + @"\" + selectedFileName);
                        // Display comments
                        displayComments(selectedFileName);
                        break;
                    }
                //case ".txt":
                //    {
                //        // Hien thi hop thoai mo tep tin
                //        { axAcroPDF1.Visible = true; btClose.Visible = true; btDownload.Visible = true; btEdit.Visible = true; btReload.Visible = true; btnDetail.Visible = true; }
                //        { textBoxCmt.Visible = true; textBoxListCmt.Visible = true; btCmt.Visible = true; }
                //        // Create a new file PDF (convert from word)
                //        string filePath = @"\" + Path.GetFileNameWithoutExtension(selectedFileName) + ".txt";
                //        List<string> lines = new List<string>();
                //        lines = File.ReadAllLines(filePath).ToList();
                //        foreach (String line in lines)
                //        {
                //            MessageBox.Show(line);
                //        }
                //        // Open file Word as PDF
                //        axAcroPDF1.src = pathResourseDocument + @"\" + Path.GetFileNameWithoutExtension(selectedFileName) + ".txt";
                //        File.Delete(pathResourseDocument + @"\" + Path.GetFileNameWithoutExtension(selectedFileName) + ".txt");
                //        // Display comments
                //        displayComments(selectedFileName);
                //        break;
                //    }
                default:
                    break;
            }
        }

        // Convert to PDF from Word
        private void ConvertWordToPDF(string fileName_)
        {
            object inputFilePathWord = pathResourseDocument + @"\" + fileName_;
            object outputFilePathPDF = pathResourseDocument + @"\" + Path.GetFileNameWithoutExtension(fileName_) + ".pdf";

            Word.Application wordApp = new Word.Application();
            object oMissing = System.Reflection.Missing.Value;
            object fileFormat = Word.WdSaveFormat.wdFormatPDF;

            Word.Document doc = wordApp.Documents.Open(ref inputFilePathWord, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            doc.Activate();
            doc.SaveAs2(ref outputFilePathPDF,
                            ref fileFormat, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
            if (doc != null)
                ((Word._Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);
            wordApp.Quit(ref saveChanges, ref oMissing, ref oMissing);
        }
        

        private void btClose_Click_1(object sender, EventArgs e)
        {
            axAcroPDF1.Visible = false;
            pictureBox1.Visible = false;
            
            btDownload.Visible = false;
            btClose.Visible = false;
            btReload.Visible = false;
            btnDetail.Visible = false;
            textBoxListCmt.Clear();
            { textBoxCmt.Visible = false; textBoxListCmt.Visible = false; btCmt.Visible = false; }
            labelSearch.Show();
            txtBoxSearch.Show();
            btnCreatAnewFile.Show();
        }

        // Convert to PDF from Excel
        private void ConvertExcelToPDF(string fileName_)
        {
            string inputFilePathExcel = pathResourseDocument + @"\" + fileName_;
            string outputFilePathPDF = pathResourseDocument + @"\" + Path.GetFileNameWithoutExtension(fileName_) + ".pdf";
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook wb = excelApp.Workbooks.Open(inputFilePathExcel);
            wb.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, outputFilePathPDF);
            wb.Close();
            excelApp.Quit();
        }

        // Download File
        private void btDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog fsave = new SaveFileDialog();
            fsave.InitialDirectory = @"D:\Download Sourse";
            fsave.DefaultExt = Path.GetExtension(selectedFileName);
            fsave.ShowDialog();
            if (fsave.FileName != "")
                File.Copy(pathResourseDocument + @"\" + selectedFileName, fsave.FileName);
        }

        // Button edit document
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (enableEditingDoc(selectedFileName))
                System.Diagnostics.Process.Start(pathResourseDocument + @"\" + selectedFileName);
            else
                MessageBox.Show("You can not edit file!");
        }

        // Check if enable editing
        private bool enableEditingDoc(string selectedFileName_)
        {
            string levelDocument_ = null;
            using (StreamReader sr = new StreamReader("ListDocuments.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    if (getInforDocument(line)[0].ToString() == Path.GetFileNameWithoutExtension(selectedFileName_))
                    {
                        levelDocument_ = getInforDocument(line)[1].ToString();
                        break;
                    }
                }
            }

            if (Convert.ToInt32(levelDocument_) * 2 == Convert.ToInt32(leveluser) || isOwner(Path.GetFileNameWithoutExtension(selectedFileName_)) != "Is not owner")
                return true;
            else return false;
        }


        // Check if you are owner of file
        private string isOwner(string FileNameWithoutExtension_)
        {
            using (StreamReader sr = new StreamReader("ListDocuments.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (getInforDocument(line)[0].ToString() == FileNameWithoutExtension_)
                        if (getInforDocument(line)[2].ToString() == ID)
                        {
                            return line;
                        }
                }
            }
            return "Is not owner";
        }

        // Upload file
        private void buttonBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.ShowDialog();
            linktailieu = textBoxPath.Text = fopen.FileName;
            linktep = Path.GetDirectoryName(fopen.FileName);
            tenluu = Path.GetFileNameWithoutExtension(fopen.FileName);
            textBoxFileName.Text = Path.GetFileName(fopen.FileName);
        }

        // Display cmts
        private void displayComments(string fileName_)
        {
            using (StreamReader sr = new StreamReader(FolderFileCmt + Path.GetFileNameWithoutExtension(selectedFileName) + ".txt"))
            {
                string line;
                string text = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    text += "\r\n" + line;
                }
                textBoxListCmt.Text = text;
            }
        }

        // Save comment
        private void saveCmt(string fileName_)
        {
            string text = null;
            using (StreamReader sr = new StreamReader(FolderFileCmt + Path.GetFileNameWithoutExtension(selectedFileName) + ".txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    text += line + "\r\n";
                }
            }
            text += Nickname + ":" + textBoxCmt.Text;
            string path_ = FolderFileCmt + Path.GetFileNameWithoutExtension(selectedFileName) + ".txt";
            File.WriteAllText(path_, text);
        }

        // Upload file
        private void btUpload_Click(object sender, EventArgs e)
        {
            if (Path.GetFileNameWithoutExtension(textBoxFileName.Text) != "" && textBoxPath.Text != "")
            {
                if (string.IsNullOrEmpty(txtTema.Text.Trim()) == true)
                {
                    txtTema.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtBoxNumber.Text.Trim()) == true)
                {
                    txtBoxNumber.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtBoxName.Text.Trim()) == true)
                {
                    txtBoxName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtBoxPlace.Text.Trim()) == true)
                {
                    txtBoxPlace.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(comboBox1.Text.Trim()) == true)
                {
                    comboBox1.Focus();
                    return;
                }

                int dem = 0;
                SqlConnection Con = new SqlConnection();
                Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
                Con.Open();

                SqlCommand CMD = Con.CreateCommand();
                CMD.CommandType = CommandType.Text;

                CMD.CommandText = "SELECT Id FROM Link where Id ='" + txtBoxNumber.Text.Trim() + "'";
                CMD.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(CMD);
                da.Fill(dt);
                dem = Convert.ToInt32(dt.Rows.Count.ToString());
                if (dem != 0)
                {
                    MessageBox.Show("Регистрационный номер уже существует.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBoxNumber.Focus();
                    return;
                }

                // Create random ID document
                string newIDdocument;
                do
                {
                    newIDdocument = randomIDdocument();
                } while (isExistIDdocument(newIDdocument));
                // Add file to Listdocument.txt
                string lineInfor_ = newIDdocument;
                string levelDoc;
                switch (comboBoxGroup.Text)
                {
                    ///  not share
                    case "group 1":
                        levelDoc = "1";
                        break;
                    case "group 2":
                        levelDoc = "2";
                        break;
                    case "group 3":
                        levelDoc = "3";
                        break;
                    default:
                        levelDoc = "9";
                        break;
                }

                lineInfor_ += " " + levelDoc + " " + ID + " " + textBoxFileName.Text;
                // Update vao database
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
                con.Open();
                String sql;

                DateTime now = DateTime.Now;
                String Date = Convert.ToString(now.ToShortDateString());
                String Time = Convert.ToString(now.ToShortTimeString());
                sql = "INSERT INTO Link(id,username,Tema,Author,NgayNhap,Tip,Mecto,NgayXuat,NameFile,Document,GhiChu,ShareVoi,NgayHientai,Role,Chuky,DuongLink) VALUES (";
                sql += "N'" + txtBoxNumber.Text.Trim() + "',N'" + ID + "',N'" + txtTema.Text.Trim() + "',N'" + txtBoxName.Text.Trim() + "',N'" + dateTimePicker1.Value.ToShortDateString() + "',N'"
                    + comboBox1.Text.Trim() + "',N'" + txtBoxPlace.Text.Trim() + "',N'" + dateTimePicker2.Value.ToShortDateString()
                    + "',N'" + textBoxFileName.Text.Trim() + "',N'" +comboBox2.Text.Trim() + "',N'" + richTextBox1.Text.Trim() + "',N'" + comboBoxGroup.Text.Trim() + "',N'" + Date + " " + Time 
                    + "',N'" + Role + "',N'" + textBox1.Text.Trim() + "',N'" + textBoxPath.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                //////
                using (StreamWriter sw = new StreamWriter("ListDocuments.txt", true))
                {
                    sw.Write("\r\n" + lineInfor_ + " ");
                }
                // Create file comments
                using (File.Create(FolderFileCmt + newIDdocument + ".txt")) ;
                File.Copy(textBoxPath.Text, pathResourseDocument + "\\" + newIDdocument + Path.GetExtension(textBoxPath.Text));
                txtBoxNumber.Text = txtTema.Text = txtBoxName.Text = comboBox1.Text = txtBoxPlace.Text = textBoxFileName.Text = richTextBox1.Text = "";

                MessageBox.Show("Complete upload");
                
                // Close windows UploadFile
                { textBoxPath.Clear(); textBoxFileName.Clear(); }
                groupBoxUpload.Visible = false;
                // Refresh listView1
                AddSharedFiles();
                labelSearch.Show();
                txtBoxSearch.Show();
                btnCreatAnewFile.Show();
            }
            else
            {
                MessageBox.Show("Please fill out all information!");
                if (Path.GetFileNameWithoutExtension(textBoxFileName.Text) == "") textBoxFileName.Focus();
                if (textBoxPath.Text == "") textBoxPath.Focus();
               
            }
        }

        // Create radom ID document
        private string randomIDdocument()
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 78)));
            sb.Append(c);
            for (int i = 0; i < 5; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(48, 57)));
                sb.Append(c);
            }
            return sb.ToString();
        }

        // Check if ID document exist
        private bool isExistIDdocument(string IDdocument_)
        {
            using (StreamReader sr = new StreamReader("ListDocuments.txt"))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string existID = getInforDocument(line)[0].ToString();
                    if (IDdocument_ == existID)
                        return true;
                }
            }
            return false;
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
           
        }

        // Change permission (Buttons)
        private void forGroup3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePermissionFileTo("3");
        }
        private void forGroup2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePermissionFileTo("2");
        }
        private void forGroup1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePermissionFileTo("1");
        }
        private void privateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePermissionFileTo("9");
        }

        // change current permission of file to 1 (2, 3, private)
        private void changePermissionFileTo(string group)
        {
            string content;
            string oldLine = null, line;
            using (StreamReader sr = new StreamReader("ListDocuments.txt"))
            {
                content = sr.ReadToEnd();
            }
            using (StreamReader sr = new StreamReader("ListDocuments.txt"))
            {
                //string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (Path.GetFileNameWithoutExtension(selectedFileName) == getInforDocument(line)[0].ToString())
                        oldLine = line;
                }
            }

            string newLine = oldLine.Replace(" " + getInforDocument(oldLine)[1].ToString() + " ", " " + group + " ");
            content = content.Replace(oldLine, newLine);

            using (StreamWriter sw = new StreamWriter("ListDocuments.txt"))
            {
                sw.Write(content);
                MessageBox.Show("Changed permission!", "Completed");
            }
        }

        // Refresh list Document in listView
        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateListDocuments();
            AddSharedFiles();
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tenduocchon) == false)
            {
                //delete(selectedFileName);
                if ((Role == Roleduocchon) || (Role == "ADMIN"))
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Document\Lab4-master\lab4\DocumentManagementSystem\DocumentManagementSystem\Database.mdf;Integrated Security=True";
                    con.Open();
                    sql = "DELETE FROM link where id = N'" + tenduocchon + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    listView1.Clear();
                    sql = "SELECT * FROM link";
                    xuatdulieu(sql);
                    tenduocchon = "";
                    CreateListDocuments();
                    AddSharedFiles();
                }
                else
                {
                    MessageBox.Show("Нет разрешения на удаление.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
            }
            else
            {
                MessageBox.Show("Выберите файл", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
        }

        // Function Delete a File
        //private void delete(string fileName_)
        //{
        //    // Delete in file ListDocuments
        //    string oldLine = null;
        //    string content;
        //    using (StreamReader sr = new StreamReader("ListDocuments.txt"))
        //    {
        //        content = sr.ReadToEnd();
        //    }
        //    using (StreamReader sr = new StreamReader("ListDocuments.txt"))
        //    {
        //        string line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            if (Path.GetFileNameWithoutExtension(fileName_) == getInforDocument(line)[0].ToString())
        //                oldLine = line;
        //        }
        //    }
        //    content = content.Replace("\r\n" + oldLine, null);

        //    using (StreamWriter sw = new StreamWriter("ListDocuments.txt"))
        //    {
        //        sw.Write(content);
        //    }

        //    // Delete file Commnent
        //    File.Delete(FolderFileCmt + Path.GetFileNameWithoutExtension(fileName_) + ".txt");

        //    // Delete file
        //    File.Delete(pathResourseDocument + "\\" + fileName_);
        //}

        private void changePermissionOfUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login dangnhap = new Login();
            dangnhap.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            labelSearch.Show();
            txtBoxSearch.Show();
            btCheck.Hide();
            btnCreatAnewFile.Show();
            groupBoxUpload.Visible = false; 
        }

        private void btnCreatAnewFile_Click(object sender, EventArgs e)
        {
            labelSearch.Hide();
            txtBoxSearch.Clear();
            txtBoxSearch.Hide();
            btCheck.Hide();
            btnCreatAnewFile.Hide();
            { groupBoxUpload.Visible = true; comboBoxGroup.SelectedIndex = 3; }
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtBoxSearch.Text.Trim()) == false)
            {
                listView1.Clear();
                sql = "SELECT * FROM LINK WHERE Tema like '%" + txtBoxSearch.Text.Trim() + "%'";
                xuatdulieu(sql);
                //sql = "SELECT * FROM LINK WHERE Author like '%" + txtBoxSearch.Text.Trim() + "%'";
                //xuatdulieu(sql);
            }
            else
            {
                listView1.Clear();
                sql = "SELECT * FROM LINK";
                xuatdulieu(sql);
              
            }
        }

        private void xuatdulieu(string sql)
        {
            CreateListDocuments();
            // Add Columns Header
            listView1.Clear();
            listView1.Columns.Add("Номер регистрации ", 118);
            listView1.Columns.Add("Назавыние ", 300);
            listView1.Columns.Add("Тип документ ", 115);
            listView1.Columns.Add("Место выдычи ", 120);
            listView1.Columns.Add("Дата регистрации", 120);
            listView1.Columns.Add("Дата получения", 150);
            listView1.Columns.Add("Группа ", 50);
            listView1.Columns.Add("Автор ", 100);
            listView1.Columns.Add("Имя файла ", 100);
            // Add list files
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
                    Regex reg = new Regex(@"\d");
                    Match result = reg.Match(row["ShareVoi"].ToString());
                    string resultS = Convert.ToString(result);

                    if (Role == "ADMIN")
                    {
                        arr[0] = row["Id"].ToString();
                        arr[1] = row["Tema"].ToString();
                        arr[2] = row["Tip"].ToString();
                        arr[3] = row["Mecto"].ToString();
                        arr[4] = row["NgayNhap"].ToString();
                        arr[5] = row["NgayXuat"].ToString();
                        arr[6] = row["Role"].ToString();
                        arr[7] = row["Author"].ToString();
                        arr[8] = row["NameFile"].ToString();
                        item = new ListViewItem(arr);
                        listView1.Items.Add(item);
                    }
                    else if (Role == row["Role"].ToString() || (row["ShareVoi"].ToString() == "All") || (Role == resultS))
                    {
                        arr[0] = row["Id"].ToString();
                        arr[1] = row["Tema"].ToString();
                        arr[2] = row["Tip"].ToString();
                        arr[3] = row["Mecto"].ToString();
                        arr[4] = row["NgayNhap"].ToString();
                        arr[5] = row["NgayXuat"].ToString();
                        arr[6] = row["Role"].ToString();
                        arr[7] = row["Author"].ToString();
                        arr[8] = row["NameFile"].ToString();
                        item = new ListViewItem(arr);
                        listView1.Items.Add(item);
                    }
                    
                }

            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Detail detail = new Detail();
            detail.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changePermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Role == "ADMIN")
            {
                ManagementPermissionUsers trangmoi = new ManagementPermissionUsers();
                trangmoi.Show();
            }
            else
            {
                MessageBox.Show("Только администратор может просматривать.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) == true)
            {
                MessageBox.Show("Введите имя", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text.Trim()) == true)
            {
                MessageBox.Show("Выбрать ссылку", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }

            Program.chuky(linktailieu, linkanh,linktep,tenluu);
            textBoxPath.Clear();
            textBoxFileName.Clear();
            textBoxPath.Text = linktep + @"\" + tenluu + "_signed.pdf";
            duonglink = tenluu + "_signed.pdf";
            textBoxFileName.Text = Path.GetFileName(duonglink);
            MessageBox.Show("Link:"+ textBoxPath.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.ShowDialog();
            linkanh = fopen.FileName;
            textBox2.Text = Path.GetFileName(fopen.FileName);
        }

    }
}
