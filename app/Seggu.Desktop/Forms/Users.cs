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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Buscar(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.UsernameTextBox.Text))
            {
                this.UsersDataGridView.DataSource = SegguContainer.Instance.Users.ToList();
            }
            else
            {
                var filter = this.UsernameTextBox.Text;
                this.UsersDataGridView.DataSource = SegguContainer.Instance.Users.Where(x => x.Username.Contains(filter)).ToList();
            }

            this.UsersDataGridView.Columns["Id"].Visible = false;
            this.UsersDataGridView.Columns["Password"].Visible = false;

            this.NuevoButton.Enabled = true;
            this.EliminarButton.Enabled = true;
            this.EditarButton.Enabled = true;
        }

        private void Nuevo(object sender, EventArgs e)
        {
            var userForm = new User();
            userForm.ShowDialog();
            this.Buscar(null, null);
        }

        private void Editar(object sender, EventArgs e)
        {
            var userForm = new User((Data.User)this.UsersDataGridView.SelectedRows[0].DataBoundItem);
            userForm.ShowDialog();
            this.Buscar(null, null);
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Esta seguro que desea eliminar este usuario?",
                "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                SegguContainer.Instance.Users.Remove((Data.User)this.UsersDataGridView.SelectedRows[0].DataBoundItem);
                SegguContainer.Instance.SaveChanges();
                this.Buscar(null, null);
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
