using Parse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.No;
        }

        private async void Login(object sender, EventArgs e)
        {
            var username = this.txtUsername.Text;
            var password = this.txtPassword.Text;

            try
            {
                await ParseUser.LogInAsync(username, password);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario y la contrasena son incorrectos.");
            }
        }
    }
}
