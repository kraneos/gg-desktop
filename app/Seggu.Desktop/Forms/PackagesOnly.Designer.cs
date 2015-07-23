namespace Seggu.Desktop.Forms
{
    partial class PackagesOnly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackagesOnly));
            this.grdCompañias = new System.Windows.Forms.DataGridView();
            this.btnAgregarPaquete = new System.Windows.Forms.Button();
            this.lsbCoberturas = new System.Windows.Forms.ListBox();
            this.lsbRiesgos = new System.Windows.Forms.ListBox();
            this.grbRiesgos = new System.Windows.Forms.GroupBox();
            this.cmbTipoRiesgos = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCoveragesPack = new System.Windows.Forms.TextBox();
            this.btnQuitarPaquete = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grdCoveragesPack = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.LblNombre = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lsbCoberturasPaquete = new System.Windows.Forms.ListBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompañias)).BeginInit();
            this.grbRiesgos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCoveragesPack)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            // btnAgregarPaquete
            // 
            this.btnAgregarPaquete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarPaquete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarPaquete.Location = new System.Drawing.Point(16, 295);
            this.btnAgregarPaquete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarPaquete.Name = "btnAgregarPaquete";
            this.btnAgregarPaquete.Size = new System.Drawing.Size(67, 27);
            this.btnAgregarPaquete.TabIndex = 3;
            this.btnAgregarPaquete.Text = "Nuevo";
            this.btnAgregarPaquete.UseVisualStyleBackColor = true;
            this.btnAgregarPaquete.Visible = false;
            this.btnAgregarPaquete.Click += new System.EventHandler(this.btnAgregarPaquete_Click);
            // 
            // lsbCoberturas
            // 
            this.lsbCoberturas.FormattingEnabled = true;
            this.lsbCoberturas.HorizontalScrollbar = true;
            this.lsbCoberturas.ItemHeight = 17;
            this.lsbCoberturas.Location = new System.Drawing.Point(6, 25);
            this.lsbCoberturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbCoberturas.Name = "lsbCoberturas";
            this.lsbCoberturas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbCoberturas.Size = new System.Drawing.Size(289, 208);
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
            this.lsbRiesgos.Size = new System.Drawing.Size(286, 174);
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
            this.grbRiesgos.Size = new System.Drawing.Size(299, 243);
            this.grbRiesgos.TabIndex = 13;
            this.grbRiesgos.TabStop = false;
            this.grbRiesgos.Text = "Riesgos";
            // 
            // cmbTipoRiesgos
            // 
            this.cmbTipoRiesgos.FormattingEnabled = true;
            this.cmbTipoRiesgos.Location = new System.Drawing.Point(90, 30);
            this.cmbTipoRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoRiesgos.Name = "cmbTipoRiesgos";
            this.cmbTipoRiesgos.Size = new System.Drawing.Size(202, 25);
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
            // txtCoveragesPack
            // 
            this.txtCoveragesPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCoveragesPack.Location = new System.Drawing.Point(69, 256);
            this.txtCoveragesPack.Name = "txtCoveragesPack";
            this.txtCoveragesPack.ReadOnly = true;
            this.txtCoveragesPack.Size = new System.Drawing.Size(223, 25);
            this.txtCoveragesPack.TabIndex = 25;
            this.txtCoveragesPack.Visible = false;
            this.txtCoveragesPack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoveragesPack_KeyPress);
            // 
            // btnQuitarPaquete
            // 
            this.btnQuitarPaquete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuitarPaquete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarPaquete.Location = new System.Drawing.Point(216, 295);
            this.btnQuitarPaquete.Name = "btnQuitarPaquete";
            this.btnQuitarPaquete.Size = new System.Drawing.Size(67, 27);
            this.btnQuitarPaquete.TabIndex = 19;
            this.btnQuitarPaquete.Text = "Quitar";
            this.btnQuitarPaquete.UseVisualStyleBackColor = true;
            this.btnQuitarPaquete.Visible = false;
            this.btnQuitarPaquete.Click += new System.EventHandler(this.btnQuitarPaquete_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(268, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(291, 30);
            this.label9.TabIndex = 15;
            this.label9.Text = "PAQUETES DE COBERTURAS";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // grdCoveragesPack
            // 
            this.grdCoveragesPack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCoveragesPack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCoveragesPack.ColumnHeadersVisible = false;
            this.grdCoveragesPack.Location = new System.Drawing.Point(6, 20);
            this.grdCoveragesPack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCoveragesPack.MultiSelect = false;
            this.grdCoveragesPack.Name = "grdCoveragesPack";
            this.grdCoveragesPack.ReadOnly = true;
            this.grdCoveragesPack.RowHeadersVisible = false;
            this.grdCoveragesPack.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdCoveragesPack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCoveragesPack.ShowCellToolTips = false;
            this.grdCoveragesPack.Size = new System.Drawing.Size(286, 229);
            this.grdCoveragesPack.TabIndex = 30;
            this.toolTip.SetToolTip(this.grdCoveragesPack, "Doble Click para filtrar");
            this.grdCoveragesPack.SelectionChanged += new System.EventHandler(this.grdCoveragesPack_SelectionChanged);
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
            this.groupBox2.Controls.Add(this.grdCoveragesPack);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.LblNombre);
            this.groupBox2.Controls.Add(this.txtCoveragesPack);
            this.groupBox2.Controls.Add(this.btnAgregarPaquete);
            this.groupBox2.Controls.Add(this.btnQuitarPaquete);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Location = new System.Drawing.Point(208, 294);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 337);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paquetes";
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.Location = new System.Drawing.Point(117, 295);
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
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Location = new System.Drawing.Point(117, 295);
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
            this.LblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(6, 259);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(57, 17);
            this.LblNombre.TabIndex = 26;
            this.LblNombre.Text = "Nombre";
            this.LblNombre.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Location = new System.Drawing.Point(216, 295);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(67, 27);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lsbCoberturas);
            this.groupBox3.Location = new System.Drawing.Point(513, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 243);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Coberturas";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lsbCoberturasPaquete);
            this.groupBox4.Location = new System.Drawing.Point(513, 344);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(301, 281);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Coberturas en Paquete";
            // 
            // lsbCoberturasPaquete
            // 
            this.lsbCoberturasPaquete.FormattingEnabled = true;
            this.lsbCoberturasPaquete.HorizontalScrollbar = true;
            this.lsbCoberturasPaquete.ItemHeight = 17;
            this.lsbCoberturasPaquete.Location = new System.Drawing.Point(6, 22);
            this.lsbCoberturasPaquete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbCoberturasPaquete.Name = "lsbCoberturasPaquete";
            this.lsbCoberturasPaquete.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbCoberturasPaquete.Size = new System.Drawing.Size(289, 242);
            this.lsbCoberturasPaquete.TabIndex = 2;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitar.Location = new System.Drawing.Point(724, 303);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(90, 27);
            this.btnQuitar.TabIndex = 34;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Visible = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregar.Location = new System.Drawing.Point(519, 303);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 27);
            this.btnAgregar.TabIndex = 33;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Visible = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // PackagesOnly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(826, 637);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbRiesgos);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PackagesOnly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coberturas";
            ((System.ComponentModel.ISupportInitialize)(this.grdCompañias)).EndInit();
            this.grbRiesgos.ResumeLayout(false);
            this.grbRiesgos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCoveragesPack)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCompañias;
        private System.Windows.Forms.Button btnAgregarPaquete;
        private System.Windows.Forms.ListBox lsbCoberturas;
        private System.Windows.Forms.ListBox lsbRiesgos;
        private System.Windows.Forms.GroupBox grbRiesgos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnQuitarPaquete;
        private System.Windows.Forms.TextBox txtCoveragesPack;
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
        private System.Windows.Forms.DataGridView grdCoveragesPack;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lsbCoberturasPaquete;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}