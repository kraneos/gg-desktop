using Seggu.Data;
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
    public partial class User : Form
    {
        public Data.User UserObj { get; set; }
        private bool isNew;

        public User()
        {
            InitializeComponent();
            this.UserObj = new Data.User();
            this.isNew = true;
            this.InitializeCombobox();
        }

        private void InitializeCombobox()
        {
            this.RolComboBox.DataSource = new List<object>()
            {
                new { Key = 0, Value = "Administrador"},
                new { Key = 1, Value = "Asesor"},
                new { Key = 2, Value = "Cajero"},
            };
            this.RolComboBox.ValueMember = "Key";
            this.RolComboBox.DisplayMember = "Value";
        }

        public User(Data.User user)
        {
            InitializeComponent();
            this.UserObj = user;
            this.isNew = false;
            this.InitializeCombobox();
            this.ContrasenaTextBox.Text = user.Password;
            this.UsernameTextBox.Text = user.Username;
            this.RolComboBox.SelectedValue = (int)user.Role;
        }

        private void Guardar(object sender, EventArgs e)
        {
            try
            {
                this.UserObj.Password = this.ContrasenaTextBox.Text;
                this.UserObj.Username = this.UsernameTextBox.Text;
                this.UserObj.Role = (Data.Role)((int)this.RolComboBox.SelectedValue);

                if (this.isNew)
                {
                    this.UserObj.Id = Guid.NewGuid();
                    SegguContainer.Instance.Users.Add(this.UserObj);
                }

                SegguContainer.Instance.SaveChanges();

                if (this.isNew)
                {
                    MessageBox.Show("El usuario fue creado con exito.");
                }
                else
                {
                    MessageBox.Show("El usuario fue actualizado con exito.");
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidateText(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.UsernameTextBox.Text) && !string.IsNullOrEmpty(this.ContrasenaTextBox.Text))
            {
                if (this.UsernameTextBox.Text.Length > 4 && this.ContrasenaTextBox.Text.Length > 4)
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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
