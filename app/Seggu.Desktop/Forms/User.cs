using Seggu.Data;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
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
        public UserDto UserObj { get; set; }
        private bool isNew;
        private IUserService userService;

        public User(IUserService userService)
        {
            InitializeComponent();
            this.UserObj = new UserDto();
            this.isNew = true;
            this.InitializeCombobox();
            this.userService = userService;
        }

        private void InitializeCombobox()
        {
            this.RolComboBox.DataSource = new List<object>()
            {
                new { Key = (short)0, Value = "Administrador"},
                new { Key = (short)1, Value = "Asesor"},
                new { Key = (short)2, Value = "Cajero"},
            };
            this.RolComboBox.ValueMember = "Key";
            this.RolComboBox.DisplayMember = "Value";
        }

        public void Initialize(UserDto user)
        {
            this.UserObj = user;
            this.isNew = false;
            this.InitializeCombobox();
            this.ContrasenaTextBox.Text = user.Password;
            this.UsernameTextBox.Text = user.Username;
            this.RolComboBox.SelectedValue = (short)user.Role;
        }

        private void Guardar(object sender, EventArgs e)
        {
            try
            {
                this.UserObj.Password = this.ContrasenaTextBox.Text;
                this.UserObj.Username = this.UsernameTextBox.Text;
                this.UserObj.Role = (short)this.RolComboBox.SelectedValue;

                if (this.isNew)
                {
                    this.userService.Create(this.UserObj);
                }
                else
                {
                    this.userService.Update(this.UserObj);
                }

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
