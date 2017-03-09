namespace Seggu.Desktop.Forms
{
    partial class RisksOnly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RisksOnly));
            this.grdCompañias = new System.Windows.Forms.DataGridView();
            this.btnAgregarRiesgos = new System.Windows.Forms.Button();
            this.lsbRiesgos = new System.Windows.Forms.ListBox();
            this.lblRiesgos = new System.Windows.Forms.Label();
            this.txtRiesgo = new System.Windows.Forms.TextBox();
            this.btnQuitarRiesgo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTipoRiesgos = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompañias)).BeginInit();
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
            this.grdCompañias.Size = new System.Drawing.Size(188, 498);
            this.grdCompañias.TabIndex = 16;
            this.grdCompañias.TabStop = false;
            this.grdCompañias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompañias_CellContentClick);
            this.grdCompañias.SelectionChanged += new System.EventHandler(this.grdCompañias_SelectionChanged);
            // 
            // btnAgregarRiesgos
            // 
            this.btnAgregarRiesgos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarRiesgos.Location = new System.Drawing.Point(7, 496);
            this.btnAgregarRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarRiesgos.Name = "btnAgregarRiesgos";
            this.btnAgregarRiesgos.Size = new System.Drawing.Size(71, 27);
            this.btnAgregarRiesgos.TabIndex = 2;
            this.btnAgregarRiesgos.Text = "Nuevo";
            this.btnAgregarRiesgos.UseVisualStyleBackColor = true;
            this.btnAgregarRiesgos.Visible = false;
            this.btnAgregarRiesgos.Click += new System.EventHandler(this.btnAgregarRiesgos_Click);
            // 
            // lsbRiesgos
            // 
            this.lsbRiesgos.FormattingEnabled = true;
            this.lsbRiesgos.ItemHeight = 17;
            this.lsbRiesgos.Location = new System.Drawing.Point(7, 68);
            this.lsbRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbRiesgos.Name = "lsbRiesgos";
            this.lsbRiesgos.Size = new System.Drawing.Size(291, 378);
            this.lsbRiesgos.TabIndex = 0;
            this.lsbRiesgos.SelectedValueChanged += new System.EventHandler(this.lsbRiesgos_SelectedValueChanged);
            // 
            // lblRiesgos
            // 
            this.lblRiesgos.AutoSize = true;
            this.lblRiesgos.Location = new System.Drawing.Point(8, 456);
            this.lblRiesgos.Name = "lblRiesgos";
            this.lblRiesgos.Size = new System.Drawing.Size(57, 17);
            this.lblRiesgos.TabIndex = 25;
            this.lblRiesgos.Text = "Nombre";
            this.lblRiesgos.Visible = false;
            // 
            // txtRiesgo
            // 
            this.txtRiesgo.Location = new System.Drawing.Point(75, 453);
            this.txtRiesgo.Name = "txtRiesgo";
            this.txtRiesgo.ReadOnly = true;
            this.txtRiesgo.Size = new System.Drawing.Size(223, 25);
            this.txtRiesgo.TabIndex = 23;
            this.txtRiesgo.Visible = false;
            this.txtRiesgo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRiesgo_KeyPress);
            // 
            // btnQuitarRiesgo
            // 
            this.btnQuitarRiesgo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarRiesgo.Location = new System.Drawing.Point(227, 496);
            this.btnQuitarRiesgo.Name = "btnQuitarRiesgo";
            this.btnQuitarRiesgo.Size = new System.Drawing.Size(71, 27);
            this.btnQuitarRiesgo.TabIndex = 18;
            this.btnQuitarRiesgo.Text = "Quitar";
            this.btnQuitarRiesgo.UseVisualStyleBackColor = true;
            this.btnQuitarRiesgo.Visible = false;
            this.btnQuitarRiesgo.Click += new System.EventHandler(this.btnQuitarRiesgo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(220, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 30);
            this.label9.TabIndex = 15;
            this.label9.Text = "RIESGOS";
            // 
            // cmbTipoRiesgos
            // 
            this.cmbTipoRiesgos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRiesgos.FormattingEnabled = true;
            this.cmbTipoRiesgos.Location = new System.Drawing.Point(84, 35);
            this.cmbTipoRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoRiesgos.Name = "cmbTipoRiesgos";
            this.cmbTipoRiesgos.Size = new System.Drawing.Size(215, 25);
            this.cmbTipoRiesgos.TabIndex = 24;
            this.cmbTipoRiesgos.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoRiesgos_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tipo Riesgo";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdCompañias);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 532);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compañías";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.lsbRiesgos);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnAgregarRiesgos);
            this.groupBox2.Controls.Add(this.btnQuitarRiesgo);
            this.groupBox2.Controls.Add(this.txtRiesgo);
            this.groupBox2.Controls.Add(this.lblRiesgos);
            this.groupBox2.Controls.Add(this.cmbTipoRiesgos);
            this.groupBox2.Location = new System.Drawing.Point(218, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 532);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Administrar Riesgos";
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Location = new System.Drawing.Point(227, 496);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(71, 27);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.Location = new System.Drawing.Point(117, 495);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(71, 27);
            this.btnEditar.TabIndex = 26;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Location = new System.Drawing.Point(117, 496);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(71, 27);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalir.Location = new System.Drawing.Point(12, 9);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 27);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // RisksOnly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(534, 596);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RisksOnly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Riesgos";
            ((System.ComponentModel.ISupportInitialize)(this.grdCompañias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCompañias;
        private System.Windows.Forms.Button btnAgregarRiesgos;
        private System.Windows.Forms.ListBox lsbRiesgos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnQuitarRiesgo;
        private System.Windows.Forms.TextBox txtRiesgo;
        private System.Windows.Forms.ComboBox cmbTipoRiesgos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblRiesgos;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
    }
}