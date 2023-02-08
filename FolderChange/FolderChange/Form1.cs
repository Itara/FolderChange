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
using System.Diagnostics;
using System.Threading;

namespace FolderChange
{
    public partial class Form1 : Form
    {
        private string path = @"C:\";
        private DirectoryInfo di = null;
        private string currentSourceFolder = string.Empty;
        private string mainPath = @"C:\ERP";
        AccessDB access = null;
        private string strDBfilePath = Application.StartupPath + $"\\FolderList.accdb";
        private DataTable FolderListDataTable = new DataTable();
        private DataTable CurrentFolderDataTable = new DataTable();
        private const string ProcessName = "ifrun60.EXE";
        private const string ProcessPath = @"C:\orant\BIN\";
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
            GetFolderList();
            Init();
        }

        private void GetFolderList()
        {
            string strQuery = $"select Id,FolderName,FolderFullPath,FolderExcuteParameter from FolderList";
            FolderListDataTable = access.SelectSql(strQuery);

            strQuery = "select Id,FolderName,FolderFullPath,FolderExcuteParameter from CurrentFolder";
            CurrentFolderDataTable = access.SelectSql(strQuery);
        }

        private void CheckSchema()
        {
            if (access.TableExists("CurrentFolder") == false)
            {
                string query = "Create Table CurrentFolder (Id int identity,FolderName varchar(255),FolderFullPath varchar(255),FolderExcuteParameter varchar(255))";
                access.ExcuteQuery(query);
                query = "insert into CurrentFolder (FolderName,FolderFullPath,FolderExcuteParameter) values('','','')";
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
                    DataRow dr = null;
                    if (item.Name.ToUpper().Equals("ERP"))
                    {
                        dr = CurrentFolderDataTable.AsEnumerable().FirstOrDefault();
                    }
                    else
                    {
                        dr = FolderListDataTable.Select($"FolderName like '{item.Name}'").FirstOrDefault();
                    }
                    string strParameter = string.Empty;
                    if (dr!= null)
                    {
                        strParameter = dr["FolderExcuteParameter"].ToString();
                    }

                    int i = dgvFolderList.Rows.Add(item.Name, item.FullName, "ERP실행", strParameter, "파라미터 변경");
                    InsertFolderList(item.Name, item.FullName);
                }
            }
            
            if (CurrentFolderDataTable.Rows.Count < 1)
            {
                lblCurrentSouceFolder.Text = "현재 소스 폴더 : 없음";
            }
            else
            {
                lblCurrentSouceFolder.Text = "현재 소스 폴더 : " + CurrentFolderDataTable.Rows[0]["FolderName"].ToString();
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
                MessageBox.Show("이미 해당폴더가 존재합니다.");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show($"ERP 폴더를 {txtFolderName.Text}로 변경하겠습니까?", "폴더 변경", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Directory.Move(mainPath, path + $"{txtFolderName.Text}");
                lblCurrentSouceFolder.Text = $"현재 소스 없음 ";
                string strQuery = "update CurrentFolder set FolderExcuteParameter = '' , FolderName = '' ,FolderFullPath = '' ";
                access.ExcuteQuery(strQuery);
                GetFolderList();
                Init();
            }
            


        }

        private void btnSettingSourceFolder_Click(object sender, EventArgs e)
        {
            if (dgvFolderList.SelectedRows.Count < 1)
            {
                MessageBox.Show("소스폴더를 선택하세요.");
                return;
            }
            if (dgvFolderList.SelectedRows[0].Cells[0].Value.ToString().Equals("ERP"))
            {
                MessageBox.Show("ERP 폴더를 선택했습니다.");
                return;
            }
            string sourcePath = dgvFolderList.SelectedRows[0].Cells[0].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show($"현재 선택한 {sourcePath}를 ERP폴더로 변경하겠습니까?", "소스폴더 변경", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string strFolderName = string.Empty;
                string strFolderFullPath = string.Empty;
                string strParameter = string.Empty;
                if (CurrentFolderDataTable.Rows.Count > 0  && string.IsNullOrEmpty(CurrentFolderDataTable.Rows[0]["FolderName"].ToString()) == false) //이미 등록된 ERP폴더 존재할때
                {
                    strFolderName = CurrentFolderDataTable.Rows[0]["FolderName"].ToString();
                    Directory.Move(mainPath, path + $"{strFolderName}");
                }
                strFolderName = dgvFolderList.SelectedRows[0].Cells[0].Value.ToString();
                strFolderFullPath = dgvFolderList.SelectedRows[0].Cells[1].Value.ToString();
                strParameter = dgvFolderList.SelectedRows[0].Cells[3].Value.ToString();
                string strQuery = $"update CurrentFolder set FolderName = '{strFolderName}' ,FolderFullPath = '{strFolderFullPath}' , FolderExcuteParameter = '{strParameter}' ";
                int i = access.ExcuteQuery(strQuery);
                if (i > 0)
                {
                    lblCurrentSouceFolder.Text = $"현재 소스 폴더 : {strFolderName}";
                    Directory.Move(path + $"{strFolderName}", mainPath);
                    GetFolderList();
                }
            }
            Init();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            Init();
            GetFolderList();
        }

        private void btnChangeFolderName_Click(object sender, EventArgs e)
        {
            string sourcePath = dgvFolderList.SelectedRows[0].Cells[0].Value.ToString();

            string NewFolderName = txtFolderName.Text;
            string strQuery = "";
            if (sourcePath.Equals(mainPath))
            {
                MessageBox.Show("현재 ERP폴더 경로를 이동하여 경로를 변경합니다.");
                string strFolderName = dgvFolderList.SelectedRows[0].Cells[0].Value.ToString();
                string strFolderFullPath = dgvFolderList.SelectedRows[0].Cells[1].Value.ToString();
                string strParameter = dgvFolderList.SelectedRows[0].Cells[3].Value.ToString();
                strQuery = $"update CurrentFolder set FolderName = '' ,FolderFullPath = '' , FolderExcuteParameter = '' ";
                int i = access.ExcuteQuery(strQuery);
            }
            InsertFolderList(NewFolderName, path + $"{NewFolderName}");
            Directory.Move(path + $"{sourcePath}", path + $"{NewFolderName}");
            GetFolderList();
            Init();
        }


        private void InsertFolderList(string FolderName,string FolderFullPath)
        {
            if (FolderName.Equals("ERP"))
            {
                return;
            }
            string strQuery = $"select Count(*) from FolderList where FolderName like '{FolderName}'";
            DataTable selectDt = access.SelectSql(strQuery);
            int count = (int)selectDt.Rows[0][0];
            if (count < 1)
            {
                strQuery = $"insert into FolderList(FolderName,FolderFullPath,FolderExcuteParameter) values('{FolderName}','{path}{FolderFullPath}','')";
                int i = access.ExcuteQuery(strQuery);
            }
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
            GetFolderList();
        }

        private void StartProcess()
        {
            try
            {
                string strFolder = CurrentFolderDataTable.Rows[0]["FolderName"].ToString();
                string strParameter = CurrentFolderDataTable.Rows[0]["FolderExcuteParameter"].ToString();
                string strFolderFullPath = CurrentFolderDataTable.Rows[0]["FolderFullPath"].ToString();
                Directory.Move(path + $"{strFolder}", path + $"ERP");
                string StartPath = @"c:\erp\comm";
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.Arguments = strParameter;
                process.StartInfo.FileName = $"{ProcessPath}{ProcessName}";
                process.StartInfo.WorkingDirectory = StartPath;
                process.Start();
                GetFolderList();
                Init();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("프로그램 실행 실패...ㅜ", "실행오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void KillProcess(string strFolderName)
        {
            Process[] processes = Process.GetProcessesByName(ProcessName.Replace(".EXE",""));
            if (processes != null && processes.Length > 0)
            {
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
            if(Directory.Exists(path + $"{strFolderName}") == false)
            {
                Thread.Sleep(100);
                Directory.Move(path + $"ERP", path + $"{strFolderName}");
            }
        }

        private void dgvFolderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                string strParameter = dgvFolderList.Rows[e.RowIndex].Cells[3].Value.ToString();
                string strFolder = dgvFolderList.Rows[e.RowIndex].Cells[0].Value.ToString();
                string strFolderFullPath = dgvFolderList.Rows[e.RowIndex].Cells[1].Value.ToString();
                //현재 돌고있는 프로세스 죽임
                KillProcess(CurrentFolderDataTable.Rows[0]["FolderName"].ToString());
                if (strFolder.Equals("ERP"))
                {
                    strFolder = CurrentFolderDataTable.Rows[0]["FolderName"].ToString();
                    strParameter = CurrentFolderDataTable.Rows[0]["FolderExcuteParameter"].ToString();
                    strFolderFullPath = CurrentFolderDataTable.Rows[0]["FolderFullPath"].ToString();
                }
                if (string.IsNullOrEmpty(strParameter))
                {
                    MessageBox.Show("실행 인자가 없습니다..");
                    frmSetParamenter form = new frmSetParamenter(strFolder);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        strParameter = form.strParameter;
                        string strQuery = $"update FolderList set FolderExcuteParameter = '{strParameter}' where FolderName like '{strFolder}'";
                        int i = access.ExcuteQuery(strQuery);
                        if (i > 0)
                        {
                            dgvFolderList.Rows[e.RowIndex].Cells[3].Value = strParameter;
                            //현재 ERP폴더 변경후
                            strQuery = $"update CurrentFolder set FolderExcuteParameter = '{strParameter}' , FolderName = '{strFolder}' ,FolderFullPath = '{strFolderFullPath}'";
                            i = access.ExcuteQuery(strQuery);
                            CurrentFolderDataTable.Rows[0]["FolderExcuteParameter"] = strParameter;
                            CurrentFolderDataTable.Rows[0]["FolderName"] = strFolder;
                            CurrentFolderDataTable.Rows[0]["FolderFullPath"] = strFolderFullPath;
                            //프로세스 시작
                            StartProcess();
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    //현재 돌고있는 프로세스 죽임
                    //KillProcess(CurrentFolderDataTable.Rows[0]["FolderName"].ToString());
                    //현재 ERP폴더 변경후
                    string strQuery = $"update CurrentFolder set FolderExcuteParameter = '{strParameter}' , FolderName = '{strFolder}' ,FolderFullPath = '{strFolderFullPath}'";
                    int i = access.ExcuteQuery(strQuery); 
                    CurrentFolderDataTable.Rows[0]["FolderExcuteParameter"] = strParameter;
                    CurrentFolderDataTable.Rows[0]["FolderName"] = strFolder;
                    CurrentFolderDataTable.Rows[0]["FolderFullPath"] = strFolderFullPath;

                    StartProcess();
                }


            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                string strFolder = dgvFolderList.Rows[e.RowIndex].Cells[0].Value.ToString();
                string strQuery = $"select * from FolderList where FolderName like '{strFolder}' ";
                frmSetParamenter form = new frmSetParamenter(strFolder);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string strParameter = form.strParameter;
                    if (strFolder.Equals("ERP"))
                    {
                        strFolder = form.strERPFolder = CurrentFolderDataTable.Rows[0]["FolderName"].ToString();
                        strQuery = $"update CurrentFolder set FolderExcuteParameter = '{strParameter}'";
                        access.ExcuteQuery(strQuery);
                        CurrentFolderDataTable.Rows[0]["FolderExcuteParameter"] = strParameter;
                    }
                    strQuery = $"select * from FolderList where FolderName like '{strFolder}' ";
                    DataTable NewFolderExcuteDt = access.SelectSql(strQuery);
                    if (NewFolderExcuteDt.Rows.Count > 0)
                    {
                        strQuery = $"update FolderList set FolderExcuteParameter = '{strParameter}' where FolderName like '{strFolder}'";
                        int i = access.ExcuteQuery(strQuery);
                        if (i > 0)
                        {
                            dgvFolderList.Rows[e.RowIndex].Cells[3].Value = strParameter;
                        }
                    }
                    else
                    {
                        MessageBox.Show("폴더 파라미터 검색 실패...");
                        return;
                    }
                }
            }
        }

        private void btnKillERP_Click(object sender, EventArgs e)
        {
            string strFolderName = CurrentFolderDataTable.Rows[0]["FolderName"].ToString();
            KillProcess(strFolderName);
        }
    }
}
