using Seggu.Data;
using Seggu.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Aceptar(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.UsuarioTextBox.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.");
                return;
            }
            if (string.IsNullOrEmpty(this.ContrasenaTextBox.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.");
                return;
            }

            if (SegguContainer.Instance.Users.Any(u => u.Username == this.UsuarioTextBox.Text.Trim() && u.Password == this.ContrasenaTextBox.Text))
            {
                var user = SegguContainer.Instance.Users.First(u => u.Username == this.UsuarioTextBox.Text.Trim() && u.Password == this.ContrasenaTextBox.Text);
                SegguExecutionContext.Instance.CurrentUser = user;
                MessageBox.Show("Bienvenido a Seggu!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Alguno de los datos ingresados es incorrecto. Verifiquelos y vuelva a hacer clic en ACEPTAR.");
            }
        }

        private void ValidateText(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.UsuarioTextBox.Text.Trim()) && !string.IsNullOrEmpty(this.ContrasenaTextBox.Text))
            {
                if (this.UsuarioTextBox.Text.Trim().Length > 4 && this.ContrasenaTextBox.Text.Length > 4)
                {
                    this.AceptarButton.Enabled = true;
                }
                else
                {
                    this.AceptarButton.Enabled = false;
                }
            }
            else
            {
                this.AceptarButton.Enabled = false;
            }
        }

        private void Cancelar(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?","Salir",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            

        }

        private void ValidateAccept(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Aceptar(null, null);
            }
        }
    }
}
