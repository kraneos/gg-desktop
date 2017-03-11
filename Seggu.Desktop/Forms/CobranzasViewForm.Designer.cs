namespace Seggu.Desktop.Forms
{
    partial class CobranzasViewForm
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
            this.DtgRos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRos)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgRos
            // 
            this.DtgRos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgRos.Location = new System.Drawing.Point(34, 42);
            this.DtgRos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DtgRos.Name = "DtgRos";
            this.DtgRos.Size = new System.Drawing.Size(1267, 677);
            this.DtgRos.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(965, 727);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generar XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1137, 727);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(164, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CobranzasViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 836);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DtgRos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CobranzasViewForm";
            this.ShowIcon = false;
            this.Text = "Rcr Detalle";
            this.Load += new System.EventHandler(this.RosViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgRos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgRos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelar;
    }
}