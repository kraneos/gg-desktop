namespace Seggu.Desktop.Forms
{
    partial class Cobranza
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cobranza));
            this.btnCobrar = new System.Windows.Forms.Button();
            this.cmbCobrador = new System.Windows.Forms.ComboBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.grdCuotas = new System.Windows.Forms.DataGridView();
            this.dtpFechaCobranza = new System.Windows.Forms.DateTimePicker();
            this.txtNumeroRecibo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbActivos = new System.Windows.Forms.ComboBox();
            this.btnPDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblPolicyNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCobrar
            // 
            this.btnCobrar.AutoSize = true;
            this.btnCobrar.Location = new System.Drawing.Point(725, 395);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(15);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(69, 29);
            this.btnCobrar.TabIndex = 0;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // cmbCobrador
            // 
            this.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCobrador.FormattingEnabled = true;
            this.cmbCobrador.Location = new System.Drawing.Point(550, 16);
            this.cmbCobrador.Name = "cmbCobrador";
            this.cmbCobrador.Size = new System.Drawing.Size(235, 25);
            this.cmbCobrador.TabIndex = 33;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(476, 397);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(108, 25);
            this.txtImporte.TabIndex = 31;
            this.txtImporte.Text = "0";
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // grdCuotas
            // 
            this.grdCuotas.AllowDrop = true;
            this.grdCuotas.AllowUserToAddRows = false;
            this.grdCuotas.AllowUserToDeleteRows = false;
            this.grdCuotas.AllowUserToResizeColumns = false;
            this.grdCuotas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            this.grdCuotas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCuotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCuotas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdCuotas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdCuotas.Location = new System.Drawing.Point(12, 74);
            this.grdCuotas.Margin = new System.Windows.Forms.Padding(15);
            this.grdCuotas.Name = "grdCuotas";
            this.grdCuotas.ReadOnly = true;
            this.grdCuotas.RowHeadersVisible = false;
            this.grdCuotas.RowHeadersWidth = 13;
            this.grdCuotas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdCuotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCuotas.Size = new System.Drawing.Size(782, 290);
            this.grdCuotas.TabIndex = 35;
            this.grdCuotas.TabStop = false;
            this.grdCuotas.SelectionChanged += new System.EventHandler(this.grdCuotas_SelectionChanged);
            // 
            // dtpFechaCobranza
            // 
            this.dtpFechaCobranza.Location = new System.Drawing.Point(153, 14);
            this.dtpFechaCobranza.Name = "dtpFechaCobranza";
            this.dtpFechaCobranza.Size = new System.Drawing.Size(264, 25);
            this.dtpFechaCobranza.TabIndex = 24;
            // 
            // txtNumeroRecibo
            // 
            this.txtNumeroRecibo.Location = new System.Drawing.Point(302, 397);
            this.txtNumeroRecibo.Name = "txtNumeroRecibo";
            this.txtNumeroRecibo.Size = new System.Drawing.Size(108, 25);
            this.txtNumeroRecibo.TabIndex = 27;
            this.txtNumeroRecibo.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(416, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 34;
            this.label8.Text = "Importe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(479, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 19);
            this.label7.TabIndex = 32;
            this.label7.Text = "Cobrador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "N° Recibo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 30);
            this.label4.TabIndex = 38;
            this.label4.Text = "Cobranza";
            // 
            // cmbActivos
            // 
            this.cmbActivos.FormattingEnabled = true;
            this.cmbActivos.Location = new System.Drawing.Point(12, 397);
            this.cmbActivos.Margin = new System.Windows.Forms.Padding(10);
            this.cmbActivos.Name = "cmbActivos";
            this.cmbActivos.Size = new System.Drawing.Size(204, 25);
            this.cmbActivos.TabIndex = 39;
            this.cmbActivos.Text = "Activos";
            // 
            // btnPDF
            // 
            this.btnPDF.AutoSize = true;
            this.btnPDF.Location = new System.Drawing.Point(602, 395);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(15);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(112, 29);
            this.btnPDF.TabIndex = 40;
            this.btnPDF.Text = "Imprimir recibo";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 41;
            this.label1.Text = "Asegurado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "Nº Póliza:";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(103, 49);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(0, 21);
            this.lblClient.TabIndex = 43;
            // 
            // lblPolicyNumber
            // 
            this.lblPolicyNumber.AutoSize = true;
            this.lblPolicyNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPolicyNumber.Location = new System.Drawing.Point(454, 49);
            this.lblPolicyNumber.Name = "lblPolicyNumber";
            this.lblPolicyNumber.Size = new System.Drawing.Size(0, 21);
            this.lblPolicyNumber.TabIndex = 44;
            // 
            // Cobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(813, 467);
            this.Controls.Add(this.lblPolicyNumber);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.cmbActivos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCobrador);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.grdCuotas);
            this.Controls.Add(this.dtpFechaCobranza);
            this.Controls.Add(this.txtNumeroRecibo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCobrar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Cobranza";
            this.Text = "Cobranza";
            this.Load += new System.EventHandler(this.Cobranza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.ComboBox cmbCobrador;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.DataGridView grdCuotas;
        private System.Windows.Forms.DateTimePicker dtpFechaCobranza;
        private System.Windows.Forms.TextBox txtNumeroRecibo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbActivos;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblPolicyNumber;
    }
}