namespace SubidorImagenesPersonas
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
            this.optReemplazar = new System.Windows.Forms.RadioButton();
            this.optAgregar = new System.Windows.Forms.RadioButton();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // optReemplazar
            // 
            this.optReemplazar.AutoSize = true;
            this.optReemplazar.Location = new System.Drawing.Point(80, 44);
            this.optReemplazar.Name = "optReemplazar";
            this.optReemplazar.Size = new System.Drawing.Size(81, 17);
            this.optReemplazar.TabIndex = 7;
            this.optReemplazar.Text = "Reemplazar";
            this.optReemplazar.UseVisualStyleBackColor = true;
            // 
            // optAgregar
            // 
            this.optAgregar.AutoSize = true;
            this.optAgregar.Checked = true;
            this.optAgregar.Location = new System.Drawing.Point(12, 44);
            this.optAgregar.Name = "optAgregar";
            this.optAgregar.Size = new System.Drawing.Size(62, 17);
            this.optAgregar.TabIndex = 6;
            this.optAgregar.TabStop = true;
            this.optAgregar.Text = "Agregar";
            this.optAgregar.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(312, 20);
            this.txtPath.TabIndex = 5;
            this.txtPath.Text = "C:\\imagenes";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "subir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 74);
            this.Controls.Add(this.optReemplazar);
            this.Controls.Add(this.optAgregar);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Subir Imagenes de Personas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optReemplazar;
        private System.Windows.Forms.RadioButton optAgregar;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button button1;
    }
}

