namespace Seggu.Desktop.UserControls
{
    partial class VidaPolicyUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdEmployees = new System.Windows.Forms.DataGridView();
            this.cmbCoberturas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEmployees
            // 
            this.grdEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEmployees.Location = new System.Drawing.Point(5, 41);
            this.grdEmployees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEmployees.Name = "grdEmployees";
            this.grdEmployees.RowHeadersWidth = 14;
            this.grdEmployees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdEmployees.Size = new System.Drawing.Size(985, 178);
            this.grdEmployees.TabIndex = 95;
            this.grdEmployees.TabStop = false;
            // 
            // cmbCoberturas
            // 
            this.cmbCoberturas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoberturas.FormattingEnabled = true;
            this.cmbCoberturas.Location = new System.Drawing.Point(116, 8);
            this.cmbCoberturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCoberturas.Name = "cmbCoberturas";
            this.cmbCoberturas.Size = new System.Drawing.Size(263, 25);
            this.cmbCoberturas.TabIndex = 177;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 178;
            this.label4.Text = "Cobertura";
            // 
            // VidaPolicyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbCoberturas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grdEmployees);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VidaPolicyUserControl";
            this.Size = new System.Drawing.Size(993, 223);
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEmployees;
        private System.Windows.Forms.ComboBox cmbCoberturas;
        private System.Windows.Forms.Label label4;

    }
}
