using Seggu.Data;
using Seggu.Domain;
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
    public partial class GestionarCarrocerias : Form
    {
        private VehicleType vehicleType;
        public GestionarCarrocerias(VehicleType vehicleType)
        {
            InitializeComponent();

            this.vehicleType = vehicleType;
            this.UseLabel.Text += vehicleType.Name;
            this.UsoDeTipoVehiculo.DataSource = vehicleType.Bodyworks.ToList();
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            var allUses = SegguContainer.Instance.Bodyworks.OrderBy(x=>x.Name).ToList();
            this.UsosExistentes.DataSource = allUses.Except(vehicleType.Bodyworks).OrderBy(x => x.Name).ToList();
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void PonerButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Bodywork)this.UsosExistentes.SelectedItem;
            var existing = (List<Bodywork>)this.UsoDeTipoVehiculo.DataSource;
            existing.Add(selectedItem);
            var all = (List<Bodywork>)this.UsosExistentes.DataSource;
            all.Remove(selectedItem);
            this.UsoDeTipoVehiculo.DataSource = null;
            this.UsosExistentes.DataSource = null;
            this.UsoDeTipoVehiculo.DataSource = existing.OrderBy(x => x.Name).ToList();
            this.UsosExistentes.DataSource = all.OrderBy(x=>x.Name).ToList();
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void SacarButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (Bodywork)this.UsoDeTipoVehiculo.SelectedItem;
            var all = (List<Bodywork>)this.UsosExistentes.DataSource;
            all.Add(selectedItem);
            var existing = (List<Bodywork>)this.UsoDeTipoVehiculo.DataSource;
            existing.Remove(selectedItem);
            this.UsoDeTipoVehiculo.DataSource = null;
            this.UsosExistentes.DataSource = null;
            this.UsoDeTipoVehiculo.DataSource = existing.OrderBy(x => x.Name).ToList();
            this.UsosExistentes.DataSource = all.OrderBy(x => x.Name).ToList();
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            var existing = (List<Bodywork>)this.UsoDeTipoVehiculo.DataSource;
            foreach (var obj in existing)
            {
                if (!this.vehicleType.Bodyworks.Contains(obj))
                {
                    this.vehicleType.Bodyworks.Add(obj);
                }
            }

            var nonExisting = this.vehicleType.Bodyworks.Except(existing);
            while (nonExisting.Any())
            {
                this.vehicleType.Bodyworks.Remove(nonExisting.First());
            }

            SegguContainer.Instance.SaveChanges();
            this.Close();
        }

        
    }
}
