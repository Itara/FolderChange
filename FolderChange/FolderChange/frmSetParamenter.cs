using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderChange
{
    public partial class frmSetParamenter : Form
    {
        public string strParameter { get; set; }
        public string strERPFolder { get; set; }
        public frmSetParamenter(string ERPFolder)
        {
            InitializeComponent();
            strERPFolder = ERPFolder;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            strParameter = txtParameter.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
