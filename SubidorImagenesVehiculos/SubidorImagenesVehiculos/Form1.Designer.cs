namespace SubidorImagenesVehiculos
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.optAgregar = new System.Windows.Forms.RadioButton();
            this.optReemplazar = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "subir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(11, 10);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(312, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.Text = "C:\\ImagenesVehiculos";
            // 
            // optAgregar
            // 
            this.optAgregar.AutoSize = true;
            this.optAgregar.Checked = true;
            this.optAgregar.Location = new System.Drawing.Point(11, 42);
            this.optAgregar.Name = "optAgregar";
            this.optAgregar.Size = new System.Drawing.Size(62, 17);
            this.optAgregar.TabIndex = 2;
            this.optAgregar.TabStop = true;
            this.optAgregar.Text = "Agregar";
            this.optAgregar.UseVisualStyleBackColor = true;
            // 
            // optReemplazar
            // 
            this.optReemplazar.AutoSize = true;
            this.optReemplazar.Location = new System.Drawing.Point(79, 42);
            this.optReemplazar.Name = "optReemplazar";
            this.optReemplazar.Size = new System.Drawing.Size(81, 17);
            this.optReemplazar.TabIndex = 3;
            this.optReemplazar.Text = "Reemplazar";
            this.optReemplazar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 71);
            this.Controls.Add(this.optReemplazar);
            this.Controls.Add(this.optAgregar);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Subidor Imágenes Vehículos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.RadioButton optAgregar;
        private System.Windows.Forms.RadioButton optReemplazar;
    }
}

