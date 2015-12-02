namespace Seggu.Desktop.Forms
{
    partial class ModelosVehiculos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelosVehiculos));
            this.btnModelo = new System.Windows.Forms.Button();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.txtMarcas = new System.Windows.Forms.TextBox();
            this.lstModelos = new System.Windows.Forms.ListBox();
            this.cmbOrigen = new System.Windows.Forms.ComboBox();
            this.cmbMarcas = new System.Windows.Forms.ComboBox();
            this.lstBodyworks = new System.Windows.Forms.ListBox();
            this.lstUses = new System.Windows.Forms.ListBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemoveModel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBodyworks = new System.Windows.Forms.Button();
            this.btnUses = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModelo
            // 
            this.btnModelo.Location = new System.Drawing.Point(342, 107);
            this.btnModelo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModelo.Name = "btnModelo";
            this.btnModelo.Size = new System.Drawing.Size(37, 27);
            this.btnModelo.TabIndex = 8;
            this.btnModelo.Text = "+";
            this.btnModelo.UseVisualStyleBackColor = true;
            this.btnModelo.Visible = false;
            this.btnModelo.Click += new System.EventHandler(this.btnModelo_Click);
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(22, 109);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(314, 25);
            this.txtModelo.TabIndex = 7;
            this.txtModelo.Text = "Nuevo Modelo";
            this.txtModelo.Visible = false;
            this.txtModelo.Click += new System.EventHandler(this.txtModelo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.Location = new System.Drawing.Point(342, 24);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(66, 27);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 30);
            this.label1.TabIndex = 32;
            this.label1.Text = "MARCAS y MODELOS";
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoVehiculo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoVehiculo.DisplayMember = "Name";
            this.cmbTipoVehiculo.Enabled = false;
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(450, 109);
            this.cmbTipoVehiculo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(219, 25);
            this.cmbTipoVehiculo.Sorted = true;
            this.cmbTipoVehiculo.TabIndex = 3;
            this.cmbTipoVehiculo.Text = "Tipo Vehículo";
            this.cmbTipoVehiculo.ValueMember = "Id";
            this.cmbTipoVehiculo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVehiculo_SelectedIndexChanged);
            // 
            // btnMarcas
            // 
            this.btnMarcas.AutoSize = true;
            this.btnMarcas.Location = new System.Drawing.Point(385, 70);
            this.btnMarcas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new System.Drawing.Size(37, 27);
            this.btnMarcas.TabIndex = 2;
            this.btnMarcas.Text = "+";
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Visible = false;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // txtMarcas
            // 
            this.txtMarcas.Location = new System.Drawing.Point(247, 72);
            this.txtMarcas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMarcas.Name = "txtMarcas";
            this.txtMarcas.Size = new System.Drawing.Size(132, 25);
            this.txtMarcas.TabIndex = 1;
            this.txtMarcas.Tag = "new";
            this.txtMarcas.Text = "Nueva marca";
            this.txtMarcas.Visible = false;
            this.txtMarcas.Click += new System.EventHandler(this.txtMarcas_Click);
            // 
            // lstModelos
            // 
            this.lstModelos.DisplayMember = "Name";
            this.lstModelos.FormattingEnabled = true;
            this.lstModelos.ItemHeight = 17;
            this.lstModelos.Location = new System.Drawing.Point(22, 139);
            this.lstModelos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstModelos.Name = "lstModelos";
            this.lstModelos.Size = new System.Drawing.Size(400, 259);
            this.lstModelos.TabIndex = 14;
            this.lstModelos.ValueMember = "Id";
            this.lstModelos.SelectedIndexChanged += new System.EventHandler(this.lstModelos_SelectedIndexChanged);
            // 
            // cmbOrigen
            // 
            this.cmbOrigen.DisplayMember = "Name";
            this.cmbOrigen.Enabled = false;
            this.cmbOrigen.FormattingEnabled = true;
            this.cmbOrigen.Location = new System.Drawing.Point(450, 76);
            this.cmbOrigen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbOrigen.Name = "cmbOrigen";
            this.cmbOrigen.Size = new System.Drawing.Size(219, 25);
            this.cmbOrigen.Sorted = true;
            this.cmbOrigen.TabIndex = 6;
            this.cmbOrigen.Text = "Origen";
            this.cmbOrigen.ValueMember = "Id";
            // 
            // cmbMarcas
            // 
            this.cmbMarcas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMarcas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMarcas.DisplayMember = "Name";
            this.cmbMarcas.FormattingEnabled = true;
            this.cmbMarcas.Location = new System.Drawing.Point(22, 72);
            this.cmbMarcas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMarcas.Name = "cmbMarcas";
            this.cmbMarcas.Size = new System.Drawing.Size(219, 25);
            this.cmbMarcas.Sorted = true;
            this.cmbMarcas.TabIndex = 0;
            this.cmbMarcas.Text = "Marcas";
            this.cmbMarcas.ValueMember = "Id";
            this.cmbMarcas.SelectionChangeCommitted += new System.EventHandler(this.cmbMarcas_SelectionChangeCommitted);
            this.cmbMarcas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMarcas_KeyDown);
            // 
            // lstBodyworks
            // 
            this.lstBodyworks.DisplayMember = "Name";
            this.lstBodyworks.FormattingEnabled = true;
            this.lstBodyworks.ItemHeight = 17;
            this.lstBodyworks.Location = new System.Drawing.Point(450, 177);
            this.lstBodyworks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstBodyworks.Name = "lstBodyworks";
            this.lstBodyworks.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstBodyworks.Size = new System.Drawing.Size(219, 89);
            this.lstBodyworks.TabIndex = 15;
            this.lstBodyworks.ValueMember = "Id";
            // 
            // lstUses
            // 
            this.lstUses.DisplayMember = "Name";
            this.lstUses.FormattingEnabled = true;
            this.lstUses.ItemHeight = 17;
            this.lstUses.Location = new System.Drawing.Point(450, 309);
            this.lstUses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstUses.Name = "lstUses";
            this.lstUses.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstUses.Size = new System.Drawing.Size(219, 89);
            this.lstUses.TabIndex = 16;
            this.lstUses.ValueMember = "Id";
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = true;
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.Location = new System.Drawing.Point(254, 24);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(52, 27);
            this.btnEditar.TabIndex = 38;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(458, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Carrocerías";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "Modelos";
            // 
            // btnRemoveModel
            // 
            this.btnRemoveModel.Location = new System.Drawing.Point(385, 107);
            this.btnRemoveModel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveModel.Name = "btnRemoveModel";
            this.btnRemoveModel.Size = new System.Drawing.Size(37, 27);
            this.btnRemoveModel.TabIndex = 9;
            this.btnRemoveModel.Text = "-";
            this.btnRemoveModel.UseVisualStyleBackColor = true;
            this.btnRemoveModel.Visible = false;
            this.btnRemoveModel.Click += new System.EventHandler(this.btnRemoveModel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(458, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "Usos";
            // 
            // btnBodyworks
            // 
            this.btnBodyworks.AutoSize = true;
            this.btnBodyworks.Location = new System.Drawing.Point(450, 143);
            this.btnBodyworks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBodyworks.Name = "btnBodyworks";
            this.btnBodyworks.Size = new System.Drawing.Size(88, 27);
            this.btnBodyworks.TabIndex = 43;
            this.btnBodyworks.Text = "Carrocerías:";
            this.btnBodyworks.UseVisualStyleBackColor = true;
            this.btnBodyworks.Visible = false;
            this.btnBodyworks.Click += new System.EventHandler(this.btnBodyworks_Click);
            // 
            // btnUses
            // 
            this.btnUses.AutoSize = true;
            this.btnUses.Location = new System.Drawing.Point(450, 274);
            this.btnUses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUses.Name = "btnUses";
            this.btnUses.Size = new System.Drawing.Size(88, 27);
            this.btnUses.TabIndex = 44;
            this.btnUses.Text = "Usos:";
            this.btnUses.UseVisualStyleBackColor = true;
            this.btnUses.Visible = false;
            this.btnUses.Click += new System.EventHandler(this.btnUses_Click);
            // 
            // ModelosVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 417);
            this.Controls.Add(this.btnUses);
            this.Controls.Add(this.btnBodyworks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemoveModel);
            this.Controls.Add(this.btnModelo);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lstUses);
            this.Controls.Add(this.lstBodyworks);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoVehiculo);
            this.Controls.Add(this.btnMarcas);
            this.Controls.Add(this.txtMarcas);
            this.Controls.Add(this.lstModelos);
            this.Controls.Add(this.cmbOrigen);
            this.Controls.Add(this.cmbMarcas);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ModelosVehiculos";
            this.Text = "Modelos Vehiculos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.TextBox txtMarcas;
        private System.Windows.Forms.ListBox lstModelos;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.ComboBox cmbMarcas;
        private System.Windows.Forms.ListBox lstBodyworks;
        private System.Windows.Forms.ListBox lstUses;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemoveModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBodyworks;
        private System.Windows.Forms.Button btnUses;
    }
}