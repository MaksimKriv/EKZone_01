using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKZone_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileExistBindingSource.Add(new FileExist(1, "test-1", "c:\\t1\\", "https://dlcdnets.asus.com/pub/ASUS/mb/SocketAM3+/M5A88-M/E6562_M5A88-M.zip"));
            fileExistBindingSource.Add(new FileExist(1, "test-2", "c:\\t1\\", "https://dlcdnets.asus.com/pub/ASUS/mb/SocketAM3+/M5A88-M/E6562_M5A88-M.zip"));
            //fileExistBindingSource.Add(new FileExist() { id = 2, fileName = "test-2", filePath = "c:\\t1\\", linkDownload = "https://dlcdnets.asus.com/pub/ASUS/mb/SocketAM3+/M5A88-M/E6562_M5A88-M.zip", statusFile = "status" });
            //fileExistBindingSource.Add(new FileExist() { id = 3, fileName = "test-3", filePath = "c:\\t1\\", linkDownload = "https://dlcdnets.asus.com/pub/ASUS/mb/SocketAM3+/M5A88-M/E6562_M5A88-M.zip", statusFile = "status" });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FileExist file = (FileExist)this.fileExistBindingSource.Current;
            file.fileExtension = file.linkDownload.Substring(file.linkDownload.LastIndexOf('.')+1);
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show($"Вы хотите удалить файл {dataGridView1.Rows[fileExistBindingSource.Position].Cells[1].Value}?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    file.DeleteFile();
                    fileExistBindingSource.RemoveCurrent();
                }
            } else if (dataGridView1.Columns[e.ColumnIndex].Name == "Download")
            {
                WebClient client = new WebClient();
                client.DownloadFile(file.linkDownload, file.filePath + file.fileName + '.' + file.fileExtension);
                file.Download();
            } 
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*FileExist file = (FileExist)this.fileExistBindingSource.Current;
            if (file!=null)
            {
                string temp = dataGridView1.Rows[fileExistBindingSource.Position].Cells[1].Value.ToString();
                if (temp != file.fileName)
                {
                    MessageBox.Show(dataGridView1.Rows[fileExistBindingSource.Position].Cells[1].Value.ToString() + " != " + file.fileName);
                }
            }*/

        }

        /*private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            FileExist file = (FileExist)this.fileExistBindingSource.Current;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "fileName")
            {
                MessageBox.Show(dataGridView1.Rows[fileExistBindingSource.Position].Cells[1].Value.ToString()+" != "+ file.fileName);
                if (dataGridView1.Rows[fileExistBindingSource.Position].Cells[1].Value.ToString() != file.fileName)
                {

                }
            }
        }*/

        /*private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            FileExist file = (FileExist)this.fileExistBindingSource.Current;
            e.Control.TextChanged += method;
            if (dataGridView1.Columns[e].Name == "fileName")
            {
                MessageBox.Show(dataGridView1.Rows[fileExistBindingSource.Position].Cells[1].Value.ToString() + " != " + file.fileName);
                if (dataGridView1.Rows[fileExistBindingSource.Position].Cells[1].Value.ToString() != file.fileName)
                {

                }
            }
        }

        private void PrintMessage()
        {
            MessageBox.Show("Bla lba");
        }



        static void method(object source, EventArgs arg)
        {
            if (source is FileExist)
            {
                MessageBox.Show(((FileExist)source).fileName);
            } else if (source is DataGridView)
            {
                MessageBox.Show("Bla lba");
            } else
            {
                MessageBox.Show("111");
            }
            
        }*/
    }
}
