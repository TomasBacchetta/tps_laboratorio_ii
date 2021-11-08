
namespace Vista
{
    partial class FrmArmeria
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
            this.ptbArma = new System.Windows.Forms.PictureBox();
            this.imglCarabinas = new System.Windows.Forms.ImageList(this.components);
            this.imglSubfusiles = new System.Windows.Forms.ImageList(this.components);
            this.imglRifles = new System.Windows.Forms.ImageList(this.components);
            this.imglPistolas = new System.Windows.Forms.ImageList(this.components);
            this.rtbDatosArma = new System.Windows.Forms.RichTextBox();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblNombreArma = new System.Windows.Forms.Label();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbArma)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbArma
            // 
            this.ptbArma.Location = new System.Drawing.Point(36, 79);
            this.ptbArma.Name = "ptbArma";
            this.ptbArma.Size = new System.Drawing.Size(259, 117);
            this.ptbArma.TabIndex = 0;
            this.ptbArma.TabStop = false;
            // 
            // imglCarabinas
            // 
            this.imglCarabinas.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglCarabinas.ImageSize = new System.Drawing.Size(16, 16);
            this.imglCarabinas.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imglSubfusiles
            // 
            this.imglSubfusiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglSubfusiles.ImageSize = new System.Drawing.Size(16, 16);
            this.imglSubfusiles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imglRifles
            // 
            this.imglRifles.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglRifles.ImageSize = new System.Drawing.Size(16, 16);
            this.imglRifles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imglPistolas
            // 
            this.imglPistolas.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglPistolas.ImageSize = new System.Drawing.Size(16, 16);
            this.imglPistolas.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // rtbDatosArma
            // 
            this.rtbDatosArma.Location = new System.Drawing.Point(314, 79);
            this.rtbDatosArma.Name = "rtbDatosArma";
            this.rtbDatosArma.ReadOnly = true;
            this.rtbDatosArma.Size = new System.Drawing.Size(442, 209);
            this.rtbDatosArma.TabIndex = 1;
            this.rtbDatosArma.Text = "";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(219, 317);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(95, 31);
            this.btnAnterior.TabIndex = 2;
            this.btnAnterior.Text = "<- Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(460, 317);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(93, 31);
            this.btnSiguiente.TabIndex = 3;
            this.btnSiguiente.Text = "Siguiente ->";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblNombreArma
            // 
            this.lblNombreArma.AutoSize = true;
            this.lblNombreArma.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreArma.Location = new System.Drawing.Point(36, 42);
            this.lblNombreArma.Name = "lblNombreArma";
            this.lblNombreArma.Size = new System.Drawing.Size(65, 25);
            this.lblNombreArma.TabIndex = 4;
            this.lblNombreArma.Text = "label1";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSeleccionar.Location = new System.Drawing.Point(343, 317);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(90, 31);
            this.btnSeleccionar.TabIndex = 5;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // FrmArmeria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 386);
            this.ControlBox = false;
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.lblNombreArma);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.rtbDatosArma);
            this.Controls.Add(this.ptbArma);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArmeria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Armeria";
            ((System.ComponentModel.ISupportInitialize)(this.ptbArma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbArma;
        private System.Windows.Forms.ImageList imglCarabinas;
        private System.Windows.Forms.ImageList imglSubfusiles;
        private System.Windows.Forms.ImageList imglRifles;
        private System.Windows.Forms.ImageList imglPistolas;
        private System.Windows.Forms.RichTextBox rtbDatosArma;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblNombreArma;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}