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
    public partial class GestionarUsos : Form
    {
        private VehicleType vehicleType;
        public GestionarUsos(VehicleType vehicleType)
        {
            InitializeComponent();

            this.vehicleType = vehicleType;
            this.UseLabel.Text += vehicleType.Name;
            this.UsoDeTipoVehiculo.DataSource = vehicleType.Uses.ToList();
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            var allUses = SegguContainer.Instance.Uses.ToList();
            this.UsosExistentes.DataSource = allUses.Except(vehicleType.Uses).ToList();
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void PonerButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Use)this.UsosExistentes.SelectedItem;
            var existing = (List<Use>)this.UsoDeTipoVehiculo.DataSource;
            existing.Add(selectedItem);
            var all = (List<Use>)this.UsosExistentes.DataSource;
            all.Remove(selectedItem);
            this.UsoDeTipoVehiculo.DataSource = null;
            this.UsosExistentes.DataSource = null;
            this.UsoDeTipoVehiculo.DataSource = existing;
            this.UsosExistentes.DataSource = all;
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void SacarButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Use)this.UsoDeTipoVehiculo.SelectedItem;
            var all = (List<Use>)this.UsosExistentes.DataSource;
            all.Add(selectedItem);
            var existing = (List<Use>)this.UsoDeTipoVehiculo.DataSource;
            existing.Remove(selectedItem);
            this.UsoDeTipoVehiculo.DataSource = null;
            this.UsosExistentes.DataSource = null;
            this.UsoDeTipoVehiculo.DataSource = existing;
            this.UsosExistentes.DataSource = all;
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            var existing = (List<Use>)this.UsoDeTipoVehiculo.DataSource;
            foreach (var obj in existing)
            {
                if (!this.vehicleType.Uses.Contains(obj))
                {
                    this.vehicleType.Uses.Add(obj);
                }
            }

            var nonExisting = this.vehicleType.Uses.Except(existing);
            while (nonExisting.Any())
            {
                this.vehicleType.Uses.Remove(nonExisting.First());
            }

            SegguContainer.Instance.SaveChanges();
            this.Close();
        }

        
    }
}
