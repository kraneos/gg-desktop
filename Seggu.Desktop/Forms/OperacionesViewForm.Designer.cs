namespace Seggu.Desktop.Forms
{
    partial class OperacionesViewForm
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
            this.DTGRcr = new System.Windows.Forms.DataGridView();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DTGRcr)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGRcr
            // 
            this.DTGRcr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGRcr.Location = new System.Drawing.Point(18, 18);
            this.DTGRcr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DTGRcr.Name = "DTGRcr";
            this.DTGRcr.Size = new System.Drawing.Size(1476, 846);
            this.DTGRcr.TabIndex = 0;
            this.DTGRcr.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGRcr_CellContentClick);
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Location = new System.Drawing.Point(1006, 923);
            this.BtnEnviar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(160, 35);
            this.BtnEnviar.TabIndex = 1;
            this.BtnEnviar.Text = "Generar XML";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(1218, 923);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 35);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // OperacionesViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 1000);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.DTGRcr);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OperacionesViewForm";
            this.ShowIcon = false;
            this.Text = "Ros Detalle";
            this.Load += new System.EventHandler(this.RcrViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGRcr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGRcr;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.Button BtnCancel;
    }
}