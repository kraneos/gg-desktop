namespace Seggu.Desktop.UserControls
{
    partial class IntegralPolicyUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbCubre = new System.Windows.Forms.ComboBox();
            this.label99 = new System.Windows.Forms.Label();
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.cmbLocality = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCoverages = new System.Windows.Forms.ComboBox();
            this.lblcoberturas = new System.Windows.Forms.Label();
            this.btnAddCoverage = new System.Windows.Forms.Button();
            this.btnRemoveCoverage = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtHomeStreet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHomeAppart = new System.Windows.Forms.TextBox();
            this.txtHomeNumber = new System.Windows.Forms.TextBox();
            this.txtHomePostal = new System.Windows.Forms.TextBox();
            this.txtHomeFloor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grdCoverages = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCoverages)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCubre
            // 
            this.cmbCubre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCubre.FormattingEnabled = true;
            this.cmbCubre.Location = new System.Drawing.Point(164, 13);
            this.cmbCubre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCubre.Name = "cmbCubre";
            this.cmbCubre.Size = new System.Drawing.Size(250, 25);
            this.cmbCubre.TabIndex = 0;
            this.cmbCubre.SelectionChangeCommitted += new System.EventHandler(this.cmbCubre_SelectionChangeCommitted);
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(85, 16);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(43, 17);
            this.label99.TabIndex = 101;
            this.label99.Text = "Cubre";
            // 
            // cmbProvince
            // 
            this.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Items.AddRange(new object[] {
            "elija"});
            this.cmbProvince.Location = new System.Drawing.Point(345, 91);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(222, 25);
            this.cmbProvince.TabIndex = 7;
            this.cmbProvince.SelectionChangeCommitted += new System.EventHandler(this.cmbProvince_SelectionChangeCommitted);
            this.cmbProvince.Validating += new System.ComponentModel.CancelEventHandler(this.cmbProvince_Validating);
            // 
            // cmbLocality
            // 
            this.cmbLocality.DisplayMember = "Name";
            this.cmbLocality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocality.FormattingEnabled = true;
            this.cmbLocality.Location = new System.Drawing.Point(345, 179);
            this.cmbLocality.Name = "cmbLocality";
            this.cmbLocality.Size = new System.Drawing.Size(222, 25);
            this.cmbLocality.TabIndex = 9;
            this.cmbLocality.ValueMember = "Id";
            this.cmbLocality.Validating += new System.ComponentModel.CancelEventHandler(this.cmbLocality_Validating);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(271, 139);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 17);
            this.label17.TabIndex = 123;
            this.label17.Text = "Distrito";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 118;
            this.label5.Text = "Localidad";
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.DisplayMember = "Name";
            this.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(345, 136);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(222, 25);
            this.cmbDistrict.TabIndex = 8;
            this.cmbDistrict.ValueMember = "Id";
            this.cmbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cmbDistrict_SelectionChangeCommitted);
            this.cmbDistrict.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDistrict_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 121;
            this.label9.Text = "Provincia";
            // 
            // cmbCoverages
            // 
            this.cmbCoverages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoverages.FormattingEnabled = true;
            this.cmbCoverages.Location = new System.Drawing.Point(164, 44);
            this.cmbCoverages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCoverages.Name = "cmbCoverages";
            this.cmbCoverages.Size = new System.Drawing.Size(250, 25);
            this.cmbCoverages.TabIndex = 1;
            // 
            // lblcoberturas
            // 
            this.lblcoberturas.AutoSize = true;
            this.lblcoberturas.Location = new System.Drawing.Point(85, 47);
            this.lblcoberturas.Name = "lblcoberturas";
            this.lblcoberturas.Size = new System.Drawing.Size(73, 17);
            this.lblcoberturas.TabIndex = 128;
            this.lblcoberturas.Text = "Coberturas";
            // 
            // btnAddCoverage
            // 
            this.btnAddCoverage.Location = new System.Drawing.Point(420, 44);
            this.btnAddCoverage.Name = "btnAddCoverage";
            this.btnAddCoverage.Size = new System.Drawing.Size(24, 25);
            this.btnAddCoverage.TabIndex = 89;
            this.btnAddCoverage.TabStop = false;
            this.btnAddCoverage.Text = "+";
            this.btnAddCoverage.UseVisualStyleBackColor = true;
            this.btnAddCoverage.Click += new System.EventHandler(this.btnAddCoverage_Click);
            // 
            // btnRemoveCoverage
            // 
            this.btnRemoveCoverage.Location = new System.Drawing.Point(450, 44);
            this.btnRemoveCoverage.Name = "btnRemoveCoverage";
            this.btnRemoveCoverage.Size = new System.Drawing.Size(24, 25);
            this.btnRemoveCoverage.TabIndex = 131;
            this.btnRemoveCoverage.TabStop = false;
            this.btnRemoveCoverage.Text = "-";
            this.btnRemoveCoverage.UseVisualStyleBackColor = true;
            this.btnRemoveCoverage.Click += new System.EventHandler(this.btnRemoveCoverage_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 137;
            this.label2.Text = "Calle";
            // 
            // txtHomeStreet
            // 
            this.txtHomeStreet.Location = new System.Drawing.Point(63, 91);
            this.txtHomeStreet.Name = "txtHomeStreet";
            this.txtHomeStreet.Size = new System.Drawing.Size(178, 25);
            this.txtHomeStreet.TabIndex = 2;
            this.txtHomeStreet.Validating += new System.ComponentModel.CancelEventHandler(this.txtHomeStreet_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 138;
            this.label3.Text = "Piso";
            // 
            // txtHomeAppart
            // 
            this.txtHomeAppart.Location = new System.Drawing.Point(63, 179);
            this.txtHomeAppart.Name = "txtHomeAppart";
            this.txtHomeAppart.Size = new System.Drawing.Size(65, 25);
            this.txtHomeAppart.TabIndex = 5;
            // 
            // txtHomeNumber
            // 
            this.txtHomeNumber.Location = new System.Drawing.Point(63, 134);
            this.txtHomeNumber.Name = "txtHomeNumber";
            this.txtHomeNumber.Size = new System.Drawing.Size(65, 25);
            this.txtHomeNumber.TabIndex = 3;
            this.txtHomeNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarNumeros);
            this.txtHomeNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtHomeNumber_Validating);
            // 
            // txtHomePostal
            // 
            this.txtHomePostal.Location = new System.Drawing.Point(192, 179);
            this.txtHomePostal.Name = "txtHomePostal";
            this.txtHomePostal.Size = new System.Drawing.Size(49, 25);
            this.txtHomePostal.TabIndex = 6;
            this.txtHomePostal.Validating += new System.ComponentModel.CancelEventHandler(this.txtHomePostal_Validating);
            // 
            // txtHomeFloor
            // 
            this.txtHomeFloor.Location = new System.Drawing.Point(192, 134);
            this.txtHomeFloor.Name = "txtHomeFloor";
            this.txtHomeFloor.Size = new System.Drawing.Size(49, 25);
            this.txtHomeFloor.TabIndex = 4;
            this.txtHomeFloor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarNumeros);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 139;
            this.label4.Text = "C.P.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 17);
            this.label7.TabIndex = 140;
            this.label7.Text = "Nº";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 141;
            this.label8.Text = "Depto.";
            // 
            // grdCoverages
            // 
            this.grdCoverages.AllowUserToAddRows = false;
            this.grdCoverages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCoverages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdCoverages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCoverages.ColumnHeadersVisible = false;
            this.grdCoverages.Location = new System.Drawing.Point(585, 6);
            this.grdCoverages.Margin = new System.Windows.Forms.Padding(15);
            this.grdCoverages.Name = "grdCoverages";
            this.grdCoverages.ReadOnly = true;
            this.grdCoverages.RowHeadersVisible = false;
            this.grdCoverages.RowHeadersWidth = 14;
            this.grdCoverages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCoverages.Size = new System.Drawing.Size(386, 202);
            this.grdCoverages.TabIndex = 142;
            this.grdCoverages.TabStop = false;
            this.grdCoverages.Validating += new System.ComponentModel.CancelEventHandler(this.grdCoverages_Validating);
            // 
            // IntegralPolicyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdCoverages);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHomeStreet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHomeAppart);
            this.Controls.Add(this.txtHomeNumber);
            this.Controls.Add(this.txtHomePostal);
            this.Controls.Add(this.txtHomeFloor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRemoveCoverage);
            this.Controls.Add(this.btnAddCoverage);
            this.Controls.Add(this.cmbCoverages);
            this.Controls.Add(this.lblcoberturas);
            this.Controls.Add(this.cmbProvince);
            this.Controls.Add(this.cmbLocality);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDistrict);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbCubre);
            this.Controls.Add(this.label99);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IntegralPolicyUserControl";
            this.Size = new System.Drawing.Size(993, 223);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCoverages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCubre;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.ComboBox cmbLocality;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCoverages;
        private System.Windows.Forms.Label lblcoberturas;
        private System.Windows.Forms.Button btnAddCoverage;
        private System.Windows.Forms.Button btnRemoveCoverage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView grdCoverages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHomeStreet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHomeAppart;
        private System.Windows.Forms.TextBox txtHomeNumber;
        private System.Windows.Forms.TextBox txtHomePostal;
        private System.Windows.Forms.TextBox txtHomeFloor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;

    }
}
