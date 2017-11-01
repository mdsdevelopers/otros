namespace SincronizadorControlDeAsistencia
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDescargar = new System.Windows.Forms.Button();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnDescargar
            // 
            this.btnDescargar.Location = new System.Drawing.Point(12, 42);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(92, 23);
            this.btnDescargar.TabIndex = 0;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(12, 12);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(92, 20);
            this.dtpFechaDesde.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 77);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.btnDescargar);
            this.Name = "Form1";
            this.Text = "Sincronizador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
    }
}

