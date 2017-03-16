namespace Seggu.Desktop.UserControls
{
    partial class CuotasVencidasUserControl
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tctrlAseguradosControl = new System.Windows.Forms.TabControl();
            this.tabPageListado = new System.Windows.Forms.TabPage();
            this.clientGrid = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tctrlAseguradosControl.SuspendLayout();
            this.tabPageListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tctrlAseguradosControl
            // 
            this.tctrlAseguradosControl.Controls.Add(this.tabPageListado);
            this.tctrlAseguradosControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tctrlAseguradosControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tctrlAseguradosControl.Location = new System.Drawing.Point(0, 0);
            this.tctrlAseguradosControl.Multiline = true;
            this.tctrlAseguradosControl.Name = "tctrlAseguradosControl";
            this.tctrlAseguradosControl.SelectedIndex = 0;
            this.tctrlAseguradosControl.Size = new System.Drawing.Size(1000, 620);
            this.tctrlAseguradosControl.TabIndex = 0;
            // 
            // tabPageListado
            // 
            this.tabPageListado.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPageListado.Controls.Add(this.clientGrid);
            this.tabPageListado.Location = new System.Drawing.Point(4, 26);
            this.tabPageListado.Name = "tabPageListado";
            this.tabPageListado.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListado.Size = new System.Drawing.Size(992, 590);
            this.tabPageListado.TabIndex = 0;
            this.tabPageListado.Text = "Cuotas A Vencer";
            // 
            // clientGrid
            // 
            this.clientGrid.AllowDrop = true;
            this.clientGrid.AllowUserToAddRows = false;
            this.clientGrid.AllowUserToDeleteRows = false;
            this.clientGrid.AllowUserToOrderColumns = true;
            this.clientGrid.AllowUserToResizeColumns = false;
            this.clientGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            this.clientGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.clientGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.clientGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientGrid.Location = new System.Drawing.Point(3, 3);
            this.clientGrid.Name = "clientGrid";
            this.clientGrid.ReadOnly = true;
            this.clientGrid.RowHeadersVisible = false;
            this.clientGrid.RowHeadersWidth = 13;
            this.clientGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            this.clientGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.clientGrid.RowTemplate.Height = 21;
            this.clientGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientGrid.Size = new System.Drawing.Size(986, 584);
            this.clientGrid.TabIndex = 1;
            this.clientGrid.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CuotasVencidasUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.tctrlAseguradosControl);
            this.Name = "CuotasVencidasUserControl";
            this.Size = new System.Drawing.Size(1000, 620);
            this.Load += new System.EventHandler(this.AseguradosUserControl_Load);
            this.tctrlAseguradosControl.ResumeLayout(false);
            this.tabPageListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tctrlAseguradosControl;
        private System.Windows.Forms.TabPage tabPageListado;
        private System.Windows.Forms.DataGridView clientGrid;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}