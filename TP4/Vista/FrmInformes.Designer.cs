
namespace Vista
{
    partial class FrmInformes
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
            this.rtbInforme = new System.Windows.Forms.RichTextBox();
            this.btnGuardarInforme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbInforme
            // 
            this.rtbInforme.Location = new System.Drawing.Point(12, 12);
            this.rtbInforme.Name = "rtbInforme";
            this.rtbInforme.ReadOnly = true;
            this.rtbInforme.Size = new System.Drawing.Size(334, 458);
            this.rtbInforme.TabIndex = 0;
            this.rtbInforme.Text = "";
            // 
            // btnGuardarInforme
            // 
            this.btnGuardarInforme.Location = new System.Drawing.Point(130, 476);
            this.btnGuardarInforme.Name = "btnGuardarInforme";
            this.btnGuardarInforme.Size = new System.Drawing.Size(101, 38);
            this.btnGuardarInforme.TabIndex = 1;
            this.btnGuardarInforme.Text = "Guardar Informe";
            this.btnGuardarInforme.UseVisualStyleBackColor = true;
            this.btnGuardarInforme.Click += new System.EventHandler(this.btnGuardarInforme_Click);
            // 
            // FrmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 526);
            this.Controls.Add(this.btnGuardarInforme);
            this.Controls.Add(this.rtbInforme);
            this.Name = "FrmInformes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInforme;
        private System.Windows.Forms.Button btnGuardarInforme;
    }
}