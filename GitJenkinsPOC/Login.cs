using System;
using System.Windows.Forms;
using GitBusinessLayer;

namespace GitJenkinsPOC
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUserID.Text == string.Empty)
                {
                    MessageBox.Show("User ID is blank!!");
                }
                else if (txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Password  is blank!!");
                }
                else
                {
                    GitBLogin clsGitBLogin = new GitBLogin();

                    int result = clsGitBLogin.IsValidUser(txtUserID.Text, txtPassword.Text);
                    if (result > 0)
                    {
                        ControlID.TextData = txtUserID.Text;
                        frmMain frmMainForm = new frmMain();
                        frmMainForm.Show();
                        Login frmLogin = new Login();
                        frmLogin.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User");
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserID.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }
    }
}
