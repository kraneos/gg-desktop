namespace Seggu.Desktop.UserControls
{
    partial class VehiculePolicyUserControl
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbBodyworks = new System.Windows.Forms.ComboBox();
            this.label75 = new System.Windows.Forms.Label();
            this.txtChasis = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.cmbOrigen = new System.Windows.Forms.ComboBox();
            this.label81 = new System.Windows.Forms.Label();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.label82 = new System.Windows.Forms.Label();
            this.cmbUses = new System.Windows.Forms.ComboBox();
            this.txtMotor = new System.Windows.Forms.TextBox();
            this.cmbModelos = new System.Windows.Forms.ComboBox();
            this.label83 = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.cmbMarcas = new System.Windows.Forms.ComboBox();
            this.label88 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbCoberturas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.grdVehicles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBodyworks
            // 
            this.cmbBodyworks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBodyworks.FormattingEnabled = true;
            this.cmbBodyworks.Location = new System.Drawing.Point(393, 120);
            this.cmbBodyworks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBodyworks.Name = "cmbBodyworks";
            this.cmbBodyworks.Size = new System.Drawing.Size(165, 25);
            this.cmbBodyworks.TabIndex = 151;
            this.cmbBodyworks.SelectionChangeCommitted += new System.EventHandler(this.cmbBodyworks_SelectionChangeCommitted);
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(312, 123);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(69, 17);
            this.label75.TabIndex = 167;
            this.label75.Text = "Carroceria";
            // 
            // txtChasis
            // 
            this.txtChasis.Location = new System.Drawing.Point(393, 86);
            this.txtChasis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChasis.Name = "txtChasis";
            this.txtChasis.Size = new System.Drawing.Size(165, 25);
            this.txtChasis.TabIndex = 145;
            this.txtChasis.ModifiedChanged += new System.EventHandler(this.txtChasis_ModifiedChanged);
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(312, 89);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(45, 17);
            this.label79.TabIndex = 163;
            this.label79.Text = "Chasis";
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(633, 121);
            this.txtPatente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(69, 25);
            this.txtPatente.TabIndex = 143;
            this.txtPatente.ModifiedChanged += new System.EventHandler(this.txtPatente_ModifiedChanged);
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(733, 10);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(36, 17);
            this.label80.TabIndex = 162;
            this.label80.Text = "Flota";
            // 
            // cmbOrigen
            // 
            this.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigen.FormattingEnabled = true;
            this.cmbOrigen.Location = new System.Drawing.Point(393, 154);
            this.cmbOrigen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbOrigen.Name = "cmbOrigen";
            this.cmbOrigen.Size = new System.Drawing.Size(165, 25);
            this.cmbOrigen.TabIndex = 142;
            this.cmbOrigen.SelectionChangeCommitted += new System.EventHandler(this.cmbOrigen_SelectionChangeCommitted);
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(312, 157);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(48, 17);
            this.label81.TabIndex = 161;
            this.label81.Text = "Origen";
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(112, 120);
            this.cmbTipoVehiculo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(165, 25);
            this.cmbTipoVehiculo.TabIndex = 141;
            this.cmbTipoVehiculo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVehiculo_SelectedIndexChanged);
            this.cmbTipoVehiculo.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoVehiculo_SelectionChangeCommitted);
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(6, 124);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(85, 17);
            this.label82.TabIndex = 160;
            this.label82.Text = "Tipo vehiculo";
            // 
            // cmbUses
            // 
            this.cmbUses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUses.FormattingEnabled = true;
            this.cmbUses.Location = new System.Drawing.Point(112, 154);
            this.cmbUses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbUses.Name = "cmbUses";
            this.cmbUses.Size = new System.Drawing.Size(165, 25);
            this.cmbUses.TabIndex = 147;
            this.cmbUses.SelectionChangeCommitted += new System.EventHandler(this.cmbUses_SelectionChangeCommitted);
            // 
            // txtMotor
            // 
            this.txtMotor.Location = new System.Drawing.Point(112, 86);
            this.txtMotor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMotor.Name = "txtMotor";
            this.txtMotor.Size = new System.Drawing.Size(165, 25);
            this.txtMotor.TabIndex = 144;
            this.txtMotor.ModifiedChanged += new System.EventHandler(this.txtMotor_ModifiedChanged);
            // 
            // cmbModelos
            // 
            this.cmbModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelos.FormattingEnabled = true;
            this.cmbModelos.Location = new System.Drawing.Point(393, 49);
            this.cmbModelos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbModelos.Name = "cmbModelos";
            this.cmbModelos.Size = new System.Drawing.Size(309, 25);
            this.cmbModelos.TabIndex = 138;
            this.cmbModelos.SelectedIndexChanged += new System.EventHandler(this.cmbModelos_SelectedIndexChanged);
            this.cmbModelos.SelectionChangeCommitted += new System.EventHandler(this.cmbModelos_SelectionChangeCommitted);
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(312, 52);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(54, 17);
            this.label83.TabIndex = 159;
            this.label83.Text = "Modelo";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(633, 87);
            this.txtAnio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(69, 25);
            this.txtAnio.TabIndex = 139;
            this.txtAnio.ModifiedChanged += new System.EventHandler(this.txtAnio_ModifiedChanged);
            this.txtAnio.Leave += new System.EventHandler(this.txtAnio_Leave);
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(6, 158);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(31, 17);
            this.label85.TabIndex = 157;
            this.label85.Text = "Uso";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(6, 87);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(45, 17);
            this.label86.TabIndex = 156;
            this.label86.Text = "Motor";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(584, 90);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(31, 17);
            this.label87.TabIndex = 155;
            this.label87.Text = "Año";
            // 
            // cmbMarcas
            // 
            this.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarcas.FormattingEnabled = true;
            this.cmbMarcas.Location = new System.Drawing.Point(112, 49);
            this.cmbMarcas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMarcas.Name = "cmbMarcas";
            this.cmbMarcas.Size = new System.Drawing.Size(165, 25);
            this.cmbMarcas.TabIndex = 137;
            this.cmbMarcas.SelectionChangeCommitted += new System.EventHandler(this.cmbMarca_SelectionChangeCommitted);
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(6, 53);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(45, 17);
            this.label88.TabIndex = 154;
            this.label88.Text = "Marca";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmbCoberturas
            // 
            this.cmbCoberturas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoberturas.FormattingEnabled = true;
            this.cmbCoberturas.Location = new System.Drawing.Point(112, 10);
            this.cmbCoberturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCoberturas.Name = "cmbCoberturas";
            this.cmbCoberturas.Size = new System.Drawing.Size(269, 25);
            this.cmbCoberturas.TabIndex = 175;
            this.cmbCoberturas.SelectionChangeCommitted += new System.EventHandler(this.cmbCoberturas_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 176;
            this.label2.Text = "Cobertura";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(990, 220);
            this.tabControl1.TabIndex = 177;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnQuitar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnAgregar);
            this.tabPage1.Controls.Add(this.btnClean);
            this.tabPage1.Controls.Add(this.grdVehicles);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbCoberturas);
            this.tabPage1.Controls.Add(this.label88);
            this.tabPage1.Controls.Add(this.cmbMarcas);
            this.tabPage1.Controls.Add(this.label87);
            this.tabPage1.Controls.Add(this.label86);
            this.tabPage1.Controls.Add(this.cmbBodyworks);
            this.tabPage1.Controls.Add(this.label85);
            this.tabPage1.Controls.Add(this.label75);
            this.tabPage1.Controls.Add(this.txtAnio);
            this.tabPage1.Controls.Add(this.txtChasis);
            this.tabPage1.Controls.Add(this.label83);
            this.tabPage1.Controls.Add(this.label79);
            this.tabPage1.Controls.Add(this.cmbModelos);
            this.tabPage1.Controls.Add(this.txtPatente);
            this.tabPage1.Controls.Add(this.txtMotor);
            this.tabPage1.Controls.Add(this.label80);
            this.tabPage1.Controls.Add(this.cmbUses);
            this.tabPage1.Controls.Add(this.cmbOrigen);
            this.tabPage1.Controls.Add(this.label82);
            this.tabPage1.Controls.Add(this.label81);
            this.tabPage1.Controls.Add(this.cmbTipoVehiculo);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(982, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vehículo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            this.btnQuitar.AutoSize = true;
            this.btnQuitar.Location = new System.Drawing.Point(599, 8);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(103, 27);
            this.btnQuitar.TabIndex = 181;
            this.btnQuitar.Text = "Quitar de flota";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(575, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 180;
            this.label1.Text = "Patente";
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = true;
            this.btnAgregar.Location = new System.Drawing.Point(474, 8);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(119, 27);
            this.btnAgregar.TabIndex = 179;
            this.btnAgregar.Text = "Guardar cambios";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnClean
            // 
            this.btnClean.AutoSize = true;
            this.btnClean.Location = new System.Drawing.Point(393, 8);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 27);
            this.btnClean.TabIndex = 178;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // grdVehicles
            // 
            this.grdVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVehicles.ColumnHeadersVisible = false;
            this.grdVehicles.Location = new System.Drawing.Point(736, 30);
            this.grdVehicles.MultiSelect = false;
            this.grdVehicles.Name = "grdVehicles";
            this.grdVehicles.RowHeadersVisible = false;
            this.grdVehicles.Size = new System.Drawing.Size(120, 150);
            this.grdVehicles.TabIndex = 177;
            this.grdVehicles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVehicles_CellClick);
            // 
            // VehiculePolicyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VehiculePolicyUserControl";
            this.Size = new System.Drawing.Size(993, 223);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBodyworks;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.TextBox txtChasis;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.ComboBox cmbUses;
        private System.Windows.Forms.TextBox txtMotor;
        private System.Windows.Forms.ComboBox cmbModelos;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.ComboBox cmbMarcas;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmbCoberturas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grdVehicles;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuitar;
    }
}
