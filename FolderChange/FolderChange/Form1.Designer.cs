
namespace FolderChange
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.chbTopMost = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentSouceFolder = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnKillERP = new System.Windows.Forms.Button();
            this.btnRemoveSource = new System.Windows.Forms.Button();
            this.btnChangeFolderName = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSettingSourceFolder = new System.Windows.Forms.Button();
            this.btnMainFolerChange = new System.Windows.Forms.Button();
            this.dgvFolderList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolderList)).BeginInit();
            this.SuspendLayout();
            // 
            // chbTopMost
            // 
            this.chbTopMost.AutoSize = true;
            this.chbTopMost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbTopMost.Location = new System.Drawing.Point(3, 3);
            this.chbTopMost.Name = "chbTopMost";
            this.chbTopMost.Size = new System.Drawing.Size(70, 36);
            this.chbTopMost.TabIndex = 0;
            this.chbTopMost.Text = "창고정";
            this.chbTopMost.UseVisualStyleBackColor = true;
            this.chbTopMost.CheckedChanged += new System.EventHandler(this.chbTopMost_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.18325F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.81676F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 321);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.08458F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.chbTopMost, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtFolderName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCurrentSouceFolder, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(456, 42);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // txtFolderName
            // 
            this.txtFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderName.Location = new System.Drawing.Point(344, 10);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(109, 21);
            this.txtFolderName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(230, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "폴더 변경 이름:";
            // 
            // lblCurrentSouceFolder
            // 
            this.lblCurrentSouceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentSouceFolder.AutoSize = true;
            this.lblCurrentSouceFolder.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrentSouceFolder.Location = new System.Drawing.Point(79, 15);
            this.lblCurrentSouceFolder.Name = "lblCurrentSouceFolder";
            this.lblCurrentSouceFolder.Size = new System.Drawing.Size(145, 12);
            this.lblCurrentSouceFolder.TabIndex = 1;
            this.lblCurrentSouceFolder.Text = "현재소스 :";
            this.lblCurrentSouceFolder.Click += new System.EventHandler(this.lblCurrentSouceFolder_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.69584F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.30416F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgvFolderList, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(456, 267);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btnKillERP, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnRemoveSource, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.btnChangeFolderName, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnSettingSourceFolder, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnMainFolerChange, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66736F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66736F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66736F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66736F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66736F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.6632F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(115, 261);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // btnKillERP
            // 
            this.btnKillERP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKillERP.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKillERP.Location = new System.Drawing.Point(3, 132);
            this.btnKillERP.Name = "btnKillERP";
            this.btnKillERP.Size = new System.Drawing.Size(109, 37);
            this.btnKillERP.TabIndex = 6;
            this.btnKillERP.Text = "ERP프로그램 종료";
            this.btnKillERP.UseVisualStyleBackColor = true;
            this.btnKillERP.Click += new System.EventHandler(this.btnKillERP_Click);
            // 
            // btnRemoveSource
            // 
            this.btnRemoveSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveSource.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRemoveSource.Location = new System.Drawing.Point(3, 218);
            this.btnRemoveSource.Name = "btnRemoveSource";
            this.btnRemoveSource.Size = new System.Drawing.Size(109, 40);
            this.btnRemoveSource.TabIndex = 5;
            this.btnRemoveSource.Text = "소스삭제";
            this.btnRemoveSource.UseVisualStyleBackColor = true;
            this.btnRemoveSource.Click += new System.EventHandler(this.btnRemoveSource_Click);
            // 
            // btnChangeFolderName
            // 
            this.btnChangeFolderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeFolderName.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChangeFolderName.Location = new System.Drawing.Point(3, 175);
            this.btnChangeFolderName.Name = "btnChangeFolderName";
            this.btnChangeFolderName.Size = new System.Drawing.Size(109, 37);
            this.btnChangeFolderName.TabIndex = 4;
            this.btnChangeFolderName.Text = "선택폴더\r\n이름변경";
            this.btnChangeFolderName.UseVisualStyleBackColor = true;
            this.btnChangeFolderName.Click += new System.EventHandler(this.btnChangeFolderName_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(3, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 37);
            this.button3.TabIndex = 3;
            this.button3.Text = "새로고침";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSettingSourceFolder
            // 
            this.btnSettingSourceFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettingSourceFolder.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSettingSourceFolder.Location = new System.Drawing.Point(3, 89);
            this.btnSettingSourceFolder.Name = "btnSettingSourceFolder";
            this.btnSettingSourceFolder.Size = new System.Drawing.Size(109, 37);
            this.btnSettingSourceFolder.TabIndex = 2;
            this.btnSettingSourceFolder.Text = "ERP폴더\r\n설정";
            this.btnSettingSourceFolder.UseVisualStyleBackColor = true;
            this.btnSettingSourceFolder.Click += new System.EventHandler(this.btnSettingSourceFolder_Click);
            // 
            // btnMainFolerChange
            // 
            this.btnMainFolerChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMainFolerChange.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMainFolerChange.Location = new System.Drawing.Point(3, 3);
            this.btnMainFolerChange.Name = "btnMainFolerChange";
            this.btnMainFolerChange.Size = new System.Drawing.Size(109, 37);
            this.btnMainFolerChange.TabIndex = 0;
            this.btnMainFolerChange.Text = "현재 ERP폴더\r\n명 변경";
            this.btnMainFolerChange.UseVisualStyleBackColor = true;
            this.btnMainFolerChange.Click += new System.EventHandler(this.btnMainFolerChange_Click);
            // 
            // dgvFolderList
            // 
            this.dgvFolderList.AllowUserToAddRows = false;
            this.dgvFolderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFolderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvFolderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFolderList.Location = new System.Drawing.Point(124, 3);
            this.dgvFolderList.MultiSelect = false;
            this.dgvFolderList.Name = "dgvFolderList";
            this.dgvFolderList.ReadOnly = true;
            this.dgvFolderList.RowTemplate.Height = 23;
            this.dgvFolderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFolderList.Size = new System.Drawing.Size(329, 261);
            this.dgvFolderList.TabIndex = 2;
            this.dgvFolderList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFolderList_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "폴더명";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "경로";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ERP실행";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Text = "ERP실행";
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "실행파라미터";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "파라미터값 변경";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 120;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolderList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbTopMost;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSettingSourceFolder;
        private System.Windows.Forms.Button btnMainFolerChange;
        private System.Windows.Forms.DataGridView dgvFolderList;
        private System.Windows.Forms.Label lblCurrentSouceFolder;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Button btnChangeFolderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.Button btnKillERP;
    }
}

