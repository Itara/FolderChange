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
using ADOX;
namespace FolderChange
{
    public partial class Form1 : Form
    {
        private string path = @"C:\";
        private DirectoryInfo di = null;
        private string currentSourceFolder = string.Empty;
        private string mainPath = @"C:\ERP";
        private Dictionary<string, string> dicSourceFolderERPExcuteParameter = new Dictionary<string, string>();
        AccessDB access = null;
        private string strDBfilePath = Application.StartupPath + $"\\FolderList.accdb";
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(strDBfilePath) == false)
            {
                String strDBCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBfilePath + ";";

                ADOX.Catalog adoxCC = new ADOX.Catalog();
                adoxCC.Create(strDBCon);

                adoxCC.ActiveConnection = null;
                adoxCC = null;

                GC.Collect();
            }
            access = new AccessDB($@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={strDBfilePath}");
            CheckSchema();
            Init();
        }

        private void CheckSchema()
        {
            
            if (access.TableExists("CurrentFolder") == false)
            {
                string query = "Create Table CurrentFolder (Id int identity,FolderName varchar(255),FolderFullPath varchar(255),FolderExcuteParameter varchar(255))";
                access.ExcuteQuery(query);
            }
            if (access.TableExists("FolderList") == false)
            {
                string query = "Create Table FolderList (Id int identity,FolderName varchar(255),FolderFullPath varchar(255),FolderExcuteParameter varchar(255))";
                access.ExcuteQuery(query);
            }
        }




        private void Init()
        {
            di = new DirectoryInfo(path);
            dgvFolderList.Rows.Clear();
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
            DataTable selectDt = access.SelectSql("select FolderName,FolderFullPath,FolderExcuteParameter from CurrentFolder");

            if (selectDt.Rows.Count < 1)
            {
                lblCurrentSouceFolder.Text = "현재 소스 폴더 : 없음";
            }
            else
            {
                lblCurrentSouceFolder.Text = "현재 소스 폴더 : " + selectDt.Rows[0]["FolderName"].ToString();
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
            if (string.IsNullOrEmpty(txtFolderName.Text))
            {
                MessageBox.Show("변경할 폴더명을 입력해주세요");
                return;
            }
            if (Directory.Exists(path + $"{txtFolderName.Text}") == true)
            {
                MessageBox.Show("이미 소스폴더가 존재합니다.");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show($"ERP 폴더를 {txtFolderName.Text}로 변경하겠습니까?", "폴더 변경", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Directory.Move(mainPath, path + $"{currentSourceFolder}");
                currentSourceFolder = string.Empty;
                lblCurrentSouceFolder.Text = $"현재 소스 없음 ";
                string strQuery = "update CurrentFolder set FolderExcuteParameter = '' , FolderName = '' ,FolderFullPath = '' ";
                access.ExcuteQuery(strQuery);
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
            if (DialogResult.Yes == MessageBox.Show($"현재 선택한 {sourcePath}를 ERP폴더로 변경하겠습니까?", "소스폴더 변경", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string strFolderName = dgvFolderList.SelectedRows[0].Cells[0].Value.ToString();
                string strFolderFullPath = dgvFolderList.SelectedRows[0].Cells[1].Value.ToString();
                string strParameter = dgvFolderList.SelectedRows[0].Cells[3].Value.ToString();
                string strQuery = $"update CurrentFolder FolderName = {strFolderName} ,FolderFullPath = {strFolderFullPath} , FolderExcuteParameter = {strParameter} ";
                int i = access.ExcuteQuery(strQuery);
                if (i > 0)
                {
                    currentSourceFolder = sourcePath;
                    lblCurrentSouceFolder.Text = $"현재 소스 폴더 : {currentSourceFolder}";
                    Directory.Move(path + $"{currentSourceFolder}", mainPath);
                }
               
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
                MessageBox.Show("현재 ERP폴더 경로를 이동하여 경로를 변경합니다.");
                currentSourceFolder = NewFolderName;
            }
            Directory.Move(path + $"{sourcePath}", path + $"{NewFolderName}");
            Init();
        }

        private void lblCurrentSouceFolder_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveSource_Click(object sender, EventArgs e)
        {
            currentSourceFolder = string.Empty;
            lblCurrentSouceFolder.Text = $"현재 소스 없음 ";
            string strQuery = "update CurrentFolder set FolderExcuteParameter = '' , FolderName = '' ,FolderFullPath = '' ";
            access.ExcuteQuery(strQuery);
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
                else
                {

                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {

            }
        }
    }
}
