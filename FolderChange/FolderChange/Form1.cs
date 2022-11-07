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

namespace FolderChange
{
    public partial class Form1 : Form
    {
        private string path = @"C:\";
        private DirectoryInfo di = null;
        private string currentSourceFolder = string.Empty;
        private string mainPath = @"C:\ERP";
        private Dictionary<string, string> dicSourceFolderERPExcuteParameter = new Dictionary<string, string>();
        private DataTable FolderDt = new DataTable();

        public Form1()
        {
            InitializeComponent();
            Init();
            SetFolderDt();
        }

        private void SetFolderDt()
        {
            FolderDt.Columns.Clear();
            FolderDt.Columns.Add("FolderName", typeof(string));
            FolderDt.Columns.Add("FolderPath", typeof(string));
            FolderDt.Columns.Add("FolderParameter", typeof(string));
        }

        private void Init()
        {
            di = new DirectoryInfo(path);
            currentSourceFolder = Properties.Settings.Default.SourceFolder;
            dgvFolderList.Rows.Clear();
            FolderDt.Rows.Clear();
            string tmp = Properties.Settings.Default.SourceFolderExcuteParameter;
            string[] strArrParameter = tmp.Split(',');
            if(strArrParameter.Length>0 &&string.IsNullOrEmpty(strArrParameter[0]) == false)
            {
                foreach (string strParameter in strArrParameter)
                {
                    string[] list = strParameter.Split('=');
                    if (dicSourceFolderERPExcuteParameter.ContainsKey(list[0]) == false)
                    {
                        dicSourceFolderERPExcuteParameter.Add(list[0], list[1]);
                    }
                }
            }
           
            foreach (var item in di.GetDirectories())
            {
                if (item.Name.ToUpper().Contains("ERP"))
                {
                    string tmpParameter = string.Empty;
                    if (dicSourceFolderERPExcuteParameter.ContainsKey(item.Name))
                    {
                        tmpParameter = dicSourceFolderERPExcuteParameter[item.Name];
                    }
                    int i = dgvFolderList.Rows.Add(item.Name, item.FullName, "ERP실행", tmpParameter, "파라미터 변경");
                }
            }
            if (string.IsNullOrEmpty(currentSourceFolder))
            {
                lblCurrentSouceFolder.Text = "현재 소스 폴더 : 없음";
            }
            else
            {
                lblCurrentSouceFolder.Text = "현재 소스 폴더 : " + currentSourceFolder;
            }

           
        }


        private void chbTopMost_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTopMost.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void btnMainFolerChange_Click(object sender, EventArgs e)
        {
            if (dgvFolderList.SelectedRows.Count < 1)
            {
                MessageBox.Show("변경할 폴더를 선택하세요.");
                return;
            }
            if (string.IsNullOrEmpty(currentSourceFolder))
            {
                MessageBox.Show("소스폴더가 설정되지 않았습니다.");
                return;
            }
            if (Directory.Exists(path + $"{currentSourceFolder}") == true)
            {
                MessageBox.Show("이미 소스폴더가 존재합니다.");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show($"ERP 폴더를 {currentSourceFolder}로 변경하겠습니까?", "폴더 변경", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Directory.Move(mainPath, path + $"{currentSourceFolder}");
                currentSourceFolder = string.Empty;
                Properties.Settings.Default.SourceFolder = string.Empty;
                Properties.Settings.Default.Save();
                lblCurrentSouceFolder.Text = $"현재 소스 없음 ";
            }
            Init();


        }

        private void btnSettingSourceFolder_Click(object sender, EventArgs e)
        {
            if (dgvFolderList.SelectedRows.Count < 1)
            {
                MessageBox.Show("소스폴더를 선택하세요.");
                return;
            }
            string sourcePath = dgvFolderList.SelectedRows[0].Cells[0].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show($"현재 선택한 {sourcePath}를 메인폴더로 변경하겠습니까?", "소스폴더 변경", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Properties.Settings.Default.SourceFolder = sourcePath;
                Properties.Settings.Default.Save();
                currentSourceFolder = sourcePath;
                lblCurrentSouceFolder.Text = $"현재 소스 폴더 : {currentSourceFolder}";
                Directory.Move(path + $"{currentSourceFolder}", mainPath);
            }
            Init();
        }

        private void btnFolderChange_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(mainPath) == true)
            {
                string sourcePath = string.Empty;
                if (string.IsNullOrEmpty(currentSourceFolder))
                {
                    MessageBox.Show($"현재 소스폴더를 확인할수없습니다. 기존 ERP 폴더를 ERPTMP로 변경합니다 ");
                    Directory.Move(mainPath, path + $"ERPTMP");
                    currentSourceFolder = $"ERPTMP";
                }
                else
                {
                    MessageBox.Show($"현재 메인폴더를 {currentSourceFolder}로 변경후 메인폴더로 변경합니다.");
                    Directory.Move(mainPath, path + $"{currentSourceFolder}");
                    sourcePath = dgvFolderList.SelectedRows[0].Cells[0].Value.ToString();
                    Properties.Settings.Default.SourceFolder = sourcePath;
                    Properties.Settings.Default.Save();
                    currentSourceFolder = sourcePath;
                    lblCurrentSouceFolder.Text = $"현재 소스 폴더 : {currentSourceFolder}";
                }
                Directory.Move(path + $"{currentSourceFolder}",mainPath);
            }
            else
            {
                string sourcePath = dgvFolderList.SelectedRows[0].Cells[0].Value.ToString();
                Properties.Settings.Default.SourceFolder = sourcePath;
                Properties.Settings.Default.Save();
                currentSourceFolder = sourcePath;
                lblCurrentSouceFolder.Text = $"현재 소스 폴더 : {currentSourceFolder}";
                Directory.Move(path + $"{currentSourceFolder}", mainPath);
            }
            Init();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void btnChangeFolderName_Click(object sender, EventArgs e)
        {
            string sourcePath = dgvFolderList.SelectedRows[0].Cells[0].Value.ToString();
            string NewFolderName = txtFolderName.Text;
            if (sourcePath.Equals(mainPath))
            {
                MessageBox.Show("현재 메인폴더 경로를 이동하여 경로를 변경합니다.");
                currentSourceFolder = NewFolderName;
                Properties.Settings.Default.SourceFolder = NewFolderName;
                Properties.Settings.Default.Save();
            }
            Directory.Move(path + $"{sourcePath}", path + $"{NewFolderName}");
            Init();
        }

        private void lblCurrentSouceFolder_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveSource_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SourceFolder = "";
            Properties.Settings.Default.Save();
            Init();
        }

        private void dgvFolderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                if (dgvFolderList.Rows[e.RowIndex].Cells[3].Value == null || string.IsNullOrEmpty(dgvFolderList.Rows[e.RowIndex].Cells[3].Value.ToString()))
                {
                    MessageBox.Show("실행 인자가 없습니다..");
                    frmSetParamenter form = new frmSetParamenter(dgvFolderList.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if(form.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {

            }
        }
    }
}
