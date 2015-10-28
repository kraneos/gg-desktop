namespace Seggu.Desktop.Forms
{
    partial class CoberturasOnly
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoberturasOnly));
            this.grdCompañias = new System.Windows.Forms.DataGridView();
            this.btnAgregarCobertura = new System.Windows.Forms.Button();
            this.lsbCoberturas = new System.Windows.Forms.ListBox();
            this.lsbRiesgos = new System.Windows.Forms.ListBox();
            this.grbRiesgos = new System.Windows.Forms.GroupBox();
            this.cmbTipoRiesgos = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCoberturas = new System.Windows.Forms.TextBox();
            this.btnQuitarCobertura = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.LblNombre = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompañias)).BeginInit();
            this.grbRiesgos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCompañias
            // 
            this.grdCompañias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCompañias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCompañias.ColumnHeadersVisible = false;
            this.grdCompañias.Location = new System.Drawing.Point(6, 25);
            this.grdCompañias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCompañias.MultiSelect = false;
            this.grdCompañias.Name = "grdCompañias";
            this.grdCompañias.ReadOnly = true;
            this.grdCompañias.RowHeadersVisible = false;
            this.grdCompañias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdCompañias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCompañias.Size = new System.Drawing.Size(188, 548);
            this.grdCompañias.TabIndex = 16;
            this.grdCompañias.TabStop = false;
            this.grdCompañias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompañias_CellContentClick);
            this.grdCompañias.SelectionChanged += new System.EventHandler(this.grdCompañias_SelectionChanged);
            // 
            // btnAgregarCobertura
            // 
            this.btnAgregarCobertura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarCobertura.Location = new System.Drawing.Point(25, 540);
            this.btnAgregarCobertura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarCobertura.Name = "btnAgregarCobertura";
            this.btnAgregarCobertura.Size = new System.Drawing.Size(67, 27);
            this.btnAgregarCobertura.TabIndex = 3;
            this.btnAgregarCobertura.Text = "Nuevo";
            this.btnAgregarCobertura.UseVisualStyleBackColor = true;
            this.btnAgregarCobertura.Visible = false;
            this.btnAgregarCobertura.Click += new System.EventHandler(this.btnAgregarCobertura_Click);
            // 
            // lsbCoberturas
            // 
            this.lsbCoberturas.FormattingEnabled = true;
            this.lsbCoberturas.HorizontalScrollbar = true;
            this.lsbCoberturas.ItemHeight = 17;
            this.lsbCoberturas.Location = new System.Drawing.Point(8, 25);
            this.lsbCoberturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbCoberturas.Name = "lsbCoberturas";
            this.lsbCoberturas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbCoberturas.Size = new System.Drawing.Size(300, 463);
            this.lsbCoberturas.TabIndex = 1;
            this.lsbCoberturas.SelectedValueChanged += new System.EventHandler(this.lsbCoberturas_SelectedValueChanged);
            // 
            // lsbRiesgos
            // 
            this.lsbRiesgos.FormattingEnabled = true;
            this.lsbRiesgos.ItemHeight = 17;
            this.lsbRiesgos.Location = new System.Drawing.Point(6, 59);
            this.lsbRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbRiesgos.Name = "lsbRiesgos";
            this.lsbRiesgos.Size = new System.Drawing.Size(272, 514);
            this.lsbRiesgos.TabIndex = 0;
            this.lsbRiesgos.SelectedValueChanged += new System.EventHandler(this.lsbRiesgos_SelectedValueChanged);
            // 
            // grbRiesgos
            // 
            this.grbRiesgos.Controls.Add(this.lsbRiesgos);
            this.grbRiesgos.Controls.Add(this.cmbTipoRiesgos);
            this.grbRiesgos.Controls.Add(this.label10);
            this.grbRiesgos.Location = new System.Drawing.Point(208, 43);
            this.grbRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbRiesgos.Name = "grbRiesgos";
            this.grbRiesgos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbRiesgos.Size = new System.Drawing.Size(284, 588);
            this.grbRiesgos.TabIndex = 13;
            this.grbRiesgos.TabStop = false;
            this.grbRiesgos.Text = "Riesgos";
            // 
            // cmbTipoRiesgos
            // 
            this.cmbTipoRiesgos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRiesgos.FormattingEnabled = true;
            this.cmbTipoRiesgos.Location = new System.Drawing.Point(80, 30);
            this.cmbTipoRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoRiesgos.Name = "cmbTipoRiesgos";
            this.cmbTipoRiesgos.Size = new System.Drawing.Size(198, 25);
            this.cmbTipoRiesgos.TabIndex = 24;
            this.cmbTipoRiesgos.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoRiesgos_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tipo Riesgo";
            // 
            // txtCoberturas
            // 
            this.txtCoberturas.Location = new System.Drawing.Point(69, 495);
            this.txtCoberturas.Name = "txtCoberturas";
            this.txtCoberturas.ReadOnly = true;
            this.txtCoberturas.Size = new System.Drawing.Size(239, 25);
            this.txtCoberturas.TabIndex = 25;
            this.txtCoberturas.Visible = false;
            this.txtCoberturas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoberturas_KeyPress);
            // 
            // btnQuitarCobertura
            // 
            this.btnQuitarCobertura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarCobertura.Location = new System.Drawing.Point(225, 540);
            this.btnQuitarCobertura.Name = "btnQuitarCobertura";
            this.btnQuitarCobertura.Size = new System.Drawing.Size(67, 27);
            this.btnQuitarCobertura.TabIndex = 19;
            this.btnQuitarCobertura.Text = "Quitar";
            this.btnQuitarCobertura.UseVisualStyleBackColor = true;
            this.btnQuitarCobertura.Visible = false;
            this.btnQuitarCobertura.Click += new System.EventHandler(this.btnQuitarCobertura_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(343, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 30);
            this.label9.TabIndex = 15;
            this.label9.Text = "COBERTURAS";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdCompañias);
            this.groupBox1.Location = new System.Drawing.Point(2, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 588);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compañías";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.LblNombre);
            this.groupBox2.Controls.Add(this.txtCoberturas);
            this.groupBox2.Controls.Add(this.btnAgregarCobertura);
            this.groupBox2.Controls.Add(this.lsbCoberturas);
            this.groupBox2.Controls.Add(this.btnQuitarCobertura);
            this.groupBox2.Location = new System.Drawing.Point(498, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 588);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Coberturas";
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Location = new System.Drawing.Point(225, 540);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(67, 27);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.Location = new System.Drawing.Point(126, 540);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(67, 27);
            this.btnEditar.TabIndex = 28;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Location = new System.Drawing.Point(126, 540);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(67, 27);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(6, 498);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(57, 17);
            this.LblNombre.TabIndex = 26;
            this.LblNombre.Text = "Nombre";
            this.LblNombre.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalir.Location = new System.Drawing.Point(7, 9);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 27);
            this.btnSalir.TabIndex = 30;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // CoberturasOnly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(826, 637);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbRiesgos);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CoberturasOnly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coberturas";
            ((System.ComponentModel.ISupportInitialize)(this.grdCompañias)).EndInit();
            this.grbRiesgos.ResumeLayout(false);
            this.grbRiesgos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCompañias;
        private System.Windows.Forms.Button btnAgregarCobertura;
        private System.Windows.Forms.ListBox lsbCoberturas;
        private System.Windows.Forms.ListBox lsbRiesgos;
        private System.Windows.Forms.GroupBox grbRiesgos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnQuitarCobertura;
        private System.Windows.Forms.TextBox txtCoberturas;
        private System.Windows.Forms.ComboBox cmbTipoRiesgos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
    }
}