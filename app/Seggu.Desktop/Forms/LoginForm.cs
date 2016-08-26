using Parse;
using Seggu.Services.Interfaces;
using Seggu.Helpers.Exceptions;
using System;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class LoginForm : Form
    {
        private ILoginService LoginService;

        public LoginForm(ILoginService LoginService)
        {
            this.LoginService = LoginService;

            InitializeComponent();
            DialogResult = DialogResult.No;

        }

        private async void Login(object sender, EventArgs e)
        {
            if(ParseUser.CurrentUser != null)
                ParseUser.LogOut();

            var username = this.txtUsername.Text;
            var password = this.txtPassword.Text;

            try
            {
                await LoginService.Login(username, password);
                await LoginService.ManageLoginRegisters(password);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ParseLoginException ex)
            {
                MessageBox.Show(ex.Message);
                ParseUser.LogOut();
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario y la contraseña son incorrectos.");
                ParseUser.LogOut();
            }
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            if (ParseUser.CurrentUser == null || !LoginService.HasValidSetting()) return;

            try
            {
                await LoginService.ManageLoginRegisters(string.Empty);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ParseLoginException ex)
            {
                MessageBox.Show(ex.Message);
                ParseUser.LogOut();
            }
        }
    }
}
