namespace Seggu.Desktop.Forms
{
    partial class RcrViewForm
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
            this.DTGRcr.Location = new System.Drawing.Point(12, 12);
            this.DTGRcr.Name = "DTGRcr";
            this.DTGRcr.Size = new System.Drawing.Size(984, 550);
            this.DTGRcr.TabIndex = 0;
            this.DTGRcr.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGRcr_CellContentClick);
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Location = new System.Drawing.Point(671, 600);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(75, 23);
            this.BtnEnviar.TabIndex = 1;
            this.BtnEnviar.Text = "Enviar XML";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(813, 600);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // RcrViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 650);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.DTGRcr);
            this.Name = "RcrViewForm";
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