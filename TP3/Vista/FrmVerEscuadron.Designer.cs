
namespace Vista
{
    partial class FrmVerEscuadron
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
            this.gpbSoldado = new System.Windows.Forms.GroupBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.btnEchar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.ptbSoldado = new System.Windows.Forms.PictureBox();
            this.rtbDatosSoldado = new System.Windows.Forms.RichTextBox();
            this.lblNombreEscuadron = new System.Windows.Forms.Label();
            this.lblInformes = new System.Windows.Forms.Label();
            this.lblNumeroBajas = new System.Windows.Forms.Label();
            this.lblNumeroCuraciones = new System.Windows.Forms.Label();
            this.lblNumeroArtefactos = new System.Windows.Forms.Label();
            this.lblNumeroAnomalias = new System.Windows.Forms.Label();
            this.lstbMiembros = new System.Windows.Forms.ListBox();
            this.lblNumeroIncursiones = new System.Windows.Forms.Label();
            this.gpbSoldado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSoldado)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbSoldado
            // 
            this.gpbSoldado.Controls.Add(this.lblApellido);
            this.gpbSoldado.Controls.Add(this.btnEchar);
            this.gpbSoldado.Controls.Add(this.lblNombre);
            this.gpbSoldado.Controls.Add(this.ptbSoldado);
            this.gpbSoldado.Controls.Add(this.rtbDatosSoldado);
            this.gpbSoldado.Location = new System.Drawing.Point(310, 124);
            this.gpbSoldado.Name = "gpbSoldado";
            this.gpbSoldado.Size = new System.Drawing.Size(273, 329);
            this.gpbSoldado.TabIndex = 5;
            this.gpbSoldado.TabStop = false;
            this.gpbSoldado.Tag = "gpbSoldado0";
            this.gpbSoldado.Text = "Soldado";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApellido.Location = new System.Drawing.Point(17, 84);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(57, 21);
            this.lblApellido.TabIndex = 4;
            this.lblApellido.Text = "label1";
            // 
            // btnEchar
            // 
            this.btnEchar.Location = new System.Drawing.Point(78, 289);
            this.btnEchar.Name = "btnEchar";
            this.btnEchar.Size = new System.Drawing.Size(135, 32);
            this.btnEchar.TabIndex = 3;
            this.btnEchar.Text = "Echar del escuadrón";
            this.btnEchar.UseVisualStyleBackColor = true;
            this.btnEchar.Click += new System.EventHandler(this.btnEchar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(17, 40);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 21);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "label1";
            // 
            // ptbSoldado
            // 
            this.ptbSoldado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbSoldado.Location = new System.Drawing.Point(153, 20);
            this.ptbSoldado.Name = "ptbSoldado";
            this.ptbSoldado.Size = new System.Drawing.Size(102, 99);
            this.ptbSoldado.TabIndex = 1;
            this.ptbSoldado.TabStop = false;
            // 
            // rtbDatosSoldado
            // 
            this.rtbDatosSoldado.Location = new System.Drawing.Point(57, 125);
            this.rtbDatosSoldado.Name = "rtbDatosSoldado";
            this.rtbDatosSoldado.Size = new System.Drawing.Size(181, 158);
            this.rtbDatosSoldado.TabIndex = 0;
            this.rtbDatosSoldado.Text = "";
            // 
            // lblNombreEscuadron
            // 
            this.lblNombreEscuadron.AutoSize = true;
            this.lblNombreEscuadron.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreEscuadron.Location = new System.Drawing.Point(12, 36);
            this.lblNombreEscuadron.Name = "lblNombreEscuadron";
            this.lblNombreEscuadron.Size = new System.Drawing.Size(0, 28);
            this.lblNombreEscuadron.TabIndex = 6;
            // 
            // lblInformes
            // 
            this.lblInformes.AutoSize = true;
            this.lblInformes.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInformes.Location = new System.Drawing.Point(24, 81);
            this.lblInformes.Name = "lblInformes";
            this.lblInformes.Size = new System.Drawing.Size(204, 25);
            this.lblInformes.TabIndex = 9;
            this.lblInformes.Text = "Estadísticas Históricas:";
            // 
            // lblNumeroBajas
            // 
            this.lblNumeroBajas.AutoSize = true;
            this.lblNumeroBajas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroBajas.Location = new System.Drawing.Point(37, 165);
            this.lblNumeroBajas.Name = "lblNumeroBajas";
            this.lblNumeroBajas.Size = new System.Drawing.Size(50, 20);
            this.lblNumeroBajas.TabIndex = 10;
            this.lblNumeroBajas.Text = "label1";
            // 
            // lblNumeroCuraciones
            // 
            this.lblNumeroCuraciones.AutoSize = true;
            this.lblNumeroCuraciones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroCuraciones.Location = new System.Drawing.Point(37, 208);
            this.lblNumeroCuraciones.Name = "lblNumeroCuraciones";
            this.lblNumeroCuraciones.Size = new System.Drawing.Size(50, 20);
            this.lblNumeroCuraciones.TabIndex = 11;
            this.lblNumeroCuraciones.Text = "label2";
            // 
            // lblNumeroArtefactos
            // 
            this.lblNumeroArtefactos.AutoSize = true;
            this.lblNumeroArtefactos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroArtefactos.Location = new System.Drawing.Point(37, 248);
            this.lblNumeroArtefactos.Name = "lblNumeroArtefactos";
            this.lblNumeroArtefactos.Size = new System.Drawing.Size(50, 20);
            this.lblNumeroArtefactos.TabIndex = 12;
            this.lblNumeroArtefactos.Text = "label3";
            // 
            // lblNumeroAnomalias
            // 
            this.lblNumeroAnomalias.AutoSize = true;
            this.lblNumeroAnomalias.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroAnomalias.Location = new System.Drawing.Point(37, 295);
            this.lblNumeroAnomalias.Name = "lblNumeroAnomalias";
            this.lblNumeroAnomalias.Size = new System.Drawing.Size(50, 20);
            this.lblNumeroAnomalias.TabIndex = 13;
            this.lblNumeroAnomalias.Text = "label4";
            // 
            // lstbMiembros
            // 
            this.lstbMiembros.FormattingEnabled = true;
            this.lstbMiembros.ItemHeight = 15;
            this.lstbMiembros.Location = new System.Drawing.Point(327, 24);
            this.lstbMiembros.Name = "lstbMiembros";
            this.lstbMiembros.Size = new System.Drawing.Size(238, 94);
            this.lstbMiembros.TabIndex = 14;
            this.lstbMiembros.SelectedIndexChanged += new System.EventHandler(this.lstbMiembros_SelectedIndexChanged);
            // 
            // lblNumeroIncursiones
            // 
            this.lblNumeroIncursiones.AutoSize = true;
            this.lblNumeroIncursiones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroIncursiones.Location = new System.Drawing.Point(37, 124);
            this.lblNumeroIncursiones.Name = "lblNumeroIncursiones";
            this.lblNumeroIncursiones.Size = new System.Drawing.Size(50, 20);
            this.lblNumeroIncursiones.TabIndex = 15;
            this.lblNumeroIncursiones.Text = "label4";
            // 
            // FrmVerEscuadron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 482);
            this.Controls.Add(this.lblNumeroIncursiones);
            this.Controls.Add(this.lstbMiembros);
            this.Controls.Add(this.lblNumeroAnomalias);
            this.Controls.Add(this.lblNumeroArtefactos);
            this.Controls.Add(this.lblNumeroCuraciones);
            this.Controls.Add(this.lblNumeroBajas);
            this.Controls.Add(this.lblInformes);
            this.Controls.Add(this.lblNombreEscuadron);
            this.Controls.Add(this.gpbSoldado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVerEscuadron";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Escuadrón";
            this.gpbSoldado.ResumeLayout(false);
            this.gpbSoldado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSoldado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbSoldado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox ptbSoldado;
        private System.Windows.Forms.RichTextBox rtbDatosSoldado;
        private System.Windows.Forms.Label lblNombreEscuadron;
        private System.Windows.Forms.Button btnEchar;
        private System.Windows.Forms.Label lblInformes;
        private System.Windows.Forms.Label lblNumeroBajas;
        private System.Windows.Forms.Label lblNumeroCuraciones;
        private System.Windows.Forms.Label lblNumeroArtefactos;
        private System.Windows.Forms.Label lblNumeroAnomalias;
        private System.Windows.Forms.ListBox lstbMiembros;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNumeroIncursiones;
    }
}