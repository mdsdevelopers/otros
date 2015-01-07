namespace SQLMerge
{
    partial class FrmScriptGenerado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScriptGenerado));
            this.textBox_script_generado = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_script_generado
            // 
            this.textBox_script_generado.BackColor = System.Drawing.Color.White;
            this.textBox_script_generado.Location = new System.Drawing.Point(13, 29);
            this.textBox_script_generado.MaxLength = 50000;
            this.textBox_script_generado.Multiline = true;
            this.textBox_script_generado.Name = "textBox_script_generado";
            this.textBox_script_generado.ReadOnly = true;
            this.textBox_script_generado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_script_generado.Size = new System.Drawing.Size(504, 523);
            this.textBox_script_generado.TabIndex = 0;
            this.textBox_script_generado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_script_generado_KeyDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(442, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Copiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmScriptGenerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 564);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_script_generado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmScriptGenerado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scripts";
            this.Load += new System.EventHandler(this.FrmScriptGenerado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_script_generado;
        private System.Windows.Forms.Button button1;
    }
}