using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GitBusinessLayer;
using Microsoft.Reporting.WinForms;
using System.Configuration;
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
            Login frmLogin = new Login();

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private void LoadReport()
        {
            string strPath = string.Empty;

                ReportViewer rptViewer = new ReportViewer();
                ServerReport serverRptObj = rptViewer.ServerReport;
                serverRptObj.ReportServerUrl = new Uri("http://HNJPFMDSRV01/ReportServer_SSRS");
                rptViewer.ProcessingMode = ProcessingMode.Remote;
                serverRptObj.ReportPath = "\\ReportServer_SSRS\\UserReport";
                rptViewer.ServerReport.Refresh();
                rptViewer.ShowParameterPrompts = false;
                rptViewer.ProcessingMode = ProcessingMode.Remote;
        }


    }
}
