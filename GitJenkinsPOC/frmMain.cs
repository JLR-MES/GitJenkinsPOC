using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitBusinessLayer;
using System.Data.SqlClient;

    namespace GitJenkinsPOC
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GetUserDetails();
        }
        private void GetUserDetails()
        {
            GitBLogin clsGitBLogin = new GitBLogin();
            frmLogin clsLogin = new frmLogin();

            DataSet dsUser = new DataSet();

            dsUser = clsGitBLogin.GetUserDetails(ControlID.TextData);
            if (dsUser != null)
            {
                if (dsUser.Tables[0].Rows.Count > 0)
                    {
                    DataRow drRow = dsUser.Tables[0].Rows[0];
                    lblUserID.Text = drRow["UserID"].ToString();
                    lblFirstName.Text = drRow["FirstName"].ToString();
                    lblLastName.Text = drRow["LastName"].ToString();
                    lblLoginID.Text = drRow["LoginID"].ToString();
                    lblDOB.Text = drRow["DOB"].ToString();
                    lblDesignation.Text = drRow["Designation"].ToString();
                }
            }
        }

    }
}
