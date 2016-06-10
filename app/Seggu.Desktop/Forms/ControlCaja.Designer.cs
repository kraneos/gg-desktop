namespace Seggu.Desktop.Forms
{
    partial class ControlCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCaja));
            this.grdControlCaja = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbCuentasContables = new System.Windows.Forms.ComboBox();
            this.cmbAccion = new System.Windows.Forms.ComboBox();
            this.dtpFechaTransaccion = new System.Windows.Forms.DateTimePicker();
            this.cmbActivos = new System.Windows.Forms.ComboBox();
            this.txtCuentas = new System.Windows.Forms.TextBox();
            this.btnCuentas = new System.Windows.Forms.Button();
            this.btnActivos = new System.Windows.Forms.Button();
            this.txtActivos = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.cmbCobrador = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.grbTransfer = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.btnSaveTransfer = new System.Windows.Forms.Button();
            this.txtTransferValue = new System.Windows.Forms.TextBox();
            this.cmbDestinyAsset = new System.Windows.Forms.ComboBox();
            this.cmbOriginAsset = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOriginBalance = new System.Windows.Forms.Label();
            this.lblDestinyBalance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grbTransfer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdControlCaja
            // 
            this.grdControlCaja.AllowUserToAddRows = false;
            this.grdControlCaja.AllowUserToDeleteRows = false;
            this.grdControlCaja.AllowUserToResizeRows = false;
            this.grdControlCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdControlCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdControlCaja.Location = new System.Drawing.Point(12, 51);
            this.grdControlCaja.Margin = new System.Windows.Forms.Padding(15);
            this.grdControlCaja.MultiSelect = false;
            this.grdControlCaja.Name = "grdControlCaja";
            this.grdControlCaja.RowHeadersVisible = false;
            this.grdControlCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdControlCaja.Size = new System.Drawing.Size(1018, 569);
            this.grdControlCaja.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 37);
            this.label1.TabIndex = 17;
            this.label1.Text = "CONTROL DE CAJA";
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Location = new System.Drawing.Point(1249, 342);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 33);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(1060, 344);
            this.txtValor.Margin = new System.Windows.Forms.Padding(10);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(135, 29);
            this.txtValor.TabIndex = 15;
            this.txtValor.Text = "Valor";
            this.txtValor.Click += new System.EventHandler(this.txtValor_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(1060, 303);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(10);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(271, 29);
            this.txtDescripcion.TabIndex = 4;
            this.txtDescripcion.Text = "Descripción";
            this.txtDescripcion.Click += new System.EventHandler(this.txtDescripcion_Click);
            // 
            // cmbCuentasContables
            // 
            this.cmbCuentasContables.FormattingEnabled = true;
            this.cmbCuentasContables.Location = new System.Drawing.Point(1060, 253);
            this.cmbCuentasContables.Margin = new System.Windows.Forms.Padding(10);
            this.cmbCuentasContables.Name = "cmbCuentasContables";
            this.cmbCuentasContables.Size = new System.Drawing.Size(271, 29);
            this.cmbCuentasContables.TabIndex = 13;
            this.cmbCuentasContables.Text = "Cuentas Contables";
            // 
            // cmbAccion
            // 
            this.cmbAccion.FormattingEnabled = true;
            this.cmbAccion.Items.AddRange(new object[] {
            "Pago",
            "Depósito",
            "Ajuste",
            "Transferencia"});
            this.cmbAccion.Location = new System.Drawing.Point(1060, 142);
            this.cmbAccion.Margin = new System.Windows.Forms.Padding(10);
            this.cmbAccion.Name = "cmbAccion";
            this.cmbAccion.Size = new System.Drawing.Size(271, 29);
            this.cmbAccion.TabIndex = 12;
            this.cmbAccion.Text = "Acción";
            this.cmbAccion.SelectedIndexChanged += new System.EventHandler(this.cmbAccion_SelectedIndexChanged);
            // 
            // dtpFechaTransaccion
            // 
            this.dtpFechaTransaccion.Location = new System.Drawing.Point(1060, 93);
            this.dtpFechaTransaccion.Margin = new System.Windows.Forms.Padding(10);
            this.dtpFechaTransaccion.Name = "dtpFechaTransaccion";
            this.dtpFechaTransaccion.Size = new System.Drawing.Size(271, 29);
            this.dtpFechaTransaccion.TabIndex = 1;
            // 
            // cmbActivos
            // 
            this.cmbActivos.FormattingEnabled = true;
            this.cmbActivos.Location = new System.Drawing.Point(1060, 191);
            this.cmbActivos.Margin = new System.Windows.Forms.Padding(10);
            this.cmbActivos.Name = "cmbActivos";
            this.cmbActivos.Size = new System.Drawing.Size(271, 29);
            this.cmbActivos.TabIndex = 10;
            this.cmbActivos.Text = "Activoso";
            this.cmbActivos.SelectionChangeCommitted += new System.EventHandler(this.cmbActivos_SelectionChangeCommitted);
            // 
            // txtCuentas
            // 
            this.txtCuentas.Location = new System.Drawing.Point(1060, 253);
            this.txtCuentas.Margin = new System.Windows.Forms.Padding(10);
            this.txtCuentas.Name = "txtCuentas";
            this.txtCuentas.Size = new System.Drawing.Size(238, 29);
            this.txtCuentas.TabIndex = 3;
            this.txtCuentas.Text = "Nueva Cuenta Contable";
            this.txtCuentas.Visible = false;
            this.txtCuentas.Click += new System.EventHandler(this.txtCuentas_Click);
            // 
            // btnCuentas
            // 
            this.btnCuentas.AutoSize = true;
            this.btnCuentas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCuentas.Location = new System.Drawing.Point(1304, 252);
            this.btnCuentas.Margin = new System.Windows.Forms.Padding(10);
            this.btnCuentas.Name = "btnCuentas";
            this.btnCuentas.Size = new System.Drawing.Size(32, 33);
            this.btnCuentas.TabIndex = 20;
            this.btnCuentas.Text = "+";
            this.btnCuentas.UseVisualStyleBackColor = true;
            this.btnCuentas.Visible = false;
            this.btnCuentas.Click += new System.EventHandler(this.btnCuentas_Click);
            // 
            // btnActivos
            // 
            this.btnActivos.AutoSize = true;
            this.btnActivos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActivos.Location = new System.Drawing.Point(1304, 190);
            this.btnActivos.Margin = new System.Windows.Forms.Padding(10);
            this.btnActivos.Name = "btnActivos";
            this.btnActivos.Size = new System.Drawing.Size(32, 33);
            this.btnActivos.TabIndex = 22;
            this.btnActivos.Text = "+";
            this.btnActivos.UseVisualStyleBackColor = true;
            this.btnActivos.Visible = false;
            this.btnActivos.Click += new System.EventHandler(this.btnActivos_Click);
            // 
            // txtActivos
            // 
            this.txtActivos.Location = new System.Drawing.Point(1060, 191);
            this.txtActivos.Margin = new System.Windows.Forms.Padding(10);
            this.txtActivos.Name = "txtActivos";
            this.txtActivos.Size = new System.Drawing.Size(238, 29);
            this.txtActivos.TabIndex = 2;
            this.txtActivos.Text = "Nuevo Activo";
            this.txtActivos.Visible = false;
            this.txtActivos.Click += new System.EventHandler(this.txtActivos_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = true;
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.Location = new System.Drawing.Point(1279, 11);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(10);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(64, 33);
            this.btnEditar.TabIndex = 23;
            this.btnEditar.Text = "editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cmbCobrador
            // 
            this.cmbCobrador.FormattingEnabled = true;
            this.cmbCobrador.Location = new System.Drawing.Point(1060, 51);
            this.cmbCobrador.Name = "cmbCobrador";
            this.cmbCobrador.Size = new System.Drawing.Size(271, 29);
            this.cmbCobrador.TabIndex = 0;
            this.cmbCobrador.Text = "Cobrador";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1069, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "Saldo:  $";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(1147, 226);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(0, 23);
            this.lblBalance.TabIndex = 27;
            // 
            // grbTransfer
            // 
            this.grbTransfer.Controls.Add(this.lblDestinyBalance);
            this.grbTransfer.Controls.Add(this.lblOriginBalance);
            this.grbTransfer.Controls.Add(this.label4);
            this.grbTransfer.Controls.Add(this.label3);
            this.grbTransfer.Controls.Add(this.label);
            this.grbTransfer.Controls.Add(this.btnSaveTransfer);
            this.grbTransfer.Controls.Add(this.txtTransferValue);
            this.grbTransfer.Controls.Add(this.cmbDestinyAsset);
            this.grbTransfer.Controls.Add(this.cmbOriginAsset);
            this.grbTransfer.Location = new System.Drawing.Point(1049, 184);
            this.grbTransfer.Name = "grbTransfer";
            this.grbTransfer.Size = new System.Drawing.Size(287, 222);
            this.grbTransfer.TabIndex = 28;
            this.grbTransfer.TabStop = false;
            this.grbTransfer.Text = "Transferencia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 23);
            this.label3.TabIndex = 29;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(20, 60);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(132, 23);
            this.label.TabIndex = 28;
            this.label.Text = "Origen Saldo:  $";
            // 
            // btnSaveTransfer
            // 
            this.btnSaveTransfer.AutoSize = true;
            this.btnSaveTransfer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveTransfer.Location = new System.Drawing.Point(189, 171);
            this.btnSaveTransfer.Margin = new System.Windows.Forms.Padding(10);
            this.btnSaveTransfer.Name = "btnSaveTransfer";
            this.btnSaveTransfer.Size = new System.Drawing.Size(82, 33);
            this.btnSaveTransfer.TabIndex = 18;
            this.btnSaveTransfer.Text = "Guardar";
            this.btnSaveTransfer.UseVisualStyleBackColor = true;
            // 
            // txtTransferValue
            // 
            this.txtTransferValue.Location = new System.Drawing.Point(14, 174);
            this.txtTransferValue.Margin = new System.Windows.Forms.Padding(10);
            this.txtTransferValue.Name = "txtTransferValue";
            this.txtTransferValue.Size = new System.Drawing.Size(135, 29);
            this.txtTransferValue.TabIndex = 17;
            this.txtTransferValue.Text = "Valor";
            // 
            // cmbDestinyAsset
            // 
            this.cmbDestinyAsset.FormattingEnabled = true;
            this.cmbDestinyAsset.Location = new System.Drawing.Point(13, 99);
            this.cmbDestinyAsset.Name = "cmbDestinyAsset";
            this.cmbDestinyAsset.Size = new System.Drawing.Size(258, 29);
            this.cmbDestinyAsset.TabIndex = 1;
            // 
            // cmbOriginAsset
            // 
            this.cmbOriginAsset.FormattingEnabled = true;
            this.cmbOriginAsset.Location = new System.Drawing.Point(14, 28);
            this.cmbOriginAsset.Name = "cmbOriginAsset";
            this.cmbOriginAsset.Size = new System.Drawing.Size(257, 29);
            this.cmbOriginAsset.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 23);
            this.label4.TabIndex = 30;
            this.label4.Text = "Destino Saldo:  $";
            // 
            // lblOriginBalance
            // 
            this.lblOriginBalance.AutoSize = true;
            this.lblOriginBalance.Location = new System.Drawing.Point(158, 60);
            this.lblOriginBalance.Name = "lblOriginBalance";
            this.lblOriginBalance.Size = new System.Drawing.Size(0, 23);
            this.lblOriginBalance.TabIndex = 31;
            // 
            // lblDestinyBalance
            // 
            this.lblDestinyBalance.AutoSize = true;
            this.lblDestinyBalance.Location = new System.Drawing.Point(164, 138);
            this.lblDestinyBalance.Name = "lblDestinyBalance";
            this.lblDestinyBalance.Size = new System.Drawing.Size(0, 23);
            this.lblDestinyBalance.TabIndex = 32;
            // 
            // ControlCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1372, 633);
            this.Controls.Add(this.grbTransfer);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCobrador);
            this.Controls.Add(this.dtpFechaTransaccion);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnActivos);
            this.Controls.Add(this.grdControlCaja);
            this.Controls.Add(this.cmbAccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActivos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnCuentas);
            this.Controls.Add(this.txtCuentas);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cmbActivos);
            this.Controls.Add(this.cmbCuentasContables);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ControlCaja";
            this.Text = "ControlCaja";
            this.Load += new System.EventHandler(this.ControlCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdControlCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grbTransfer.ResumeLayout(false);
            this.grbTransfer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdControlCaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbCuentasContables;
        private System.Windows.Forms.ComboBox cmbAccion;
        private System.Windows.Forms.DateTimePicker dtpFechaTransaccion;
        private System.Windows.Forms.ComboBox cmbActivos;
        private System.Windows.Forms.TextBox txtCuentas;
        private System.Windows.Forms.Button btnCuentas;
        private System.Windows.Forms.Button btnActivos;
        private System.Windows.Forms.TextBox txtActivos;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ComboBox cmbCobrador;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbTransfer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnSaveTransfer;
        private System.Windows.Forms.TextBox txtTransferValue;
        private System.Windows.Forms.ComboBox cmbDestinyAsset;
        private System.Windows.Forms.ComboBox cmbOriginAsset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDestinyBalance;
        private System.Windows.Forms.Label lblOriginBalance;
    }
}