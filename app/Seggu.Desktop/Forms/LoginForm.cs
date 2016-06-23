using Parse;
using Seggu.Services.Interfaces;
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
            var username = this.txtUsername.Text;
            var password = this.txtPassword.Text;

            try
            {
                var parseUser = await ParseUser.LogInAsync(username, password);
                LoginService.ManageLoginRegisters(parseUser, password);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario y la contrasena son incorrectos.");
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (ParseUser.CurrentUser == null) return;
            LoginService.ManageLoginRegisters(ParseUser.CurrentUser, string.Empty);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
