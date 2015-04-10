namespace SQLMerge
{
    partial class FrmComparacionDeElementos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComparacionDeElementos));
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_longitud_elemento_1 = new System.Windows.Forms.Label();
            this.lbl_longitud_elemento_2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(7, 505);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 123;
            this.label6.Text = "Longitud:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(492, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 124;
            this.label1.Text = "Longitud:";
            // 
            // lbl_longitud_elemento_1
            // 
            this.lbl_longitud_elemento_1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_longitud_elemento_1.ForeColor = System.Drawing.Color.Blue;
            this.lbl_longitud_elemento_1.Location = new System.Drawing.Point(74, 505);
            this.lbl_longitud_elemento_1.Name = "lbl_longitud_elemento_1";
            this.lbl_longitud_elemento_1.Size = new System.Drawing.Size(76, 16);
            this.lbl_longitud_elemento_1.TabIndex = 125;
            this.lbl_longitud_elemento_1.Text = "0";
            // 
            // lbl_longitud_elemento_2
            // 
            this.lbl_longitud_elemento_2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_longitud_elemento_2.ForeColor = System.Drawing.Color.Blue;
            this.lbl_longitud_elemento_2.Location = new System.Drawing.Point(559, 505);
            this.lbl_longitud_elemento_2.Name = "lbl_longitud_elemento_2";
            this.lbl_longitud_elemento_2.Size = new System.Drawing.Size(76, 16);
            this.lbl_longitud_elemento_2.TabIndex = 126;
            this.lbl_longitud_elemento_2.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(474, 463);
            this.textBox1.TabIndex = 127;
            this.textBox1.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(495, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(474, 463);
            this.textBox2.TabIndex = 128;
            this.textBox2.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 129;
            this.label2.Text = "Ctrl+A: Selec. todo";
            // 
            // FrmComparacionDeElementos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 537);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_longitud_elemento_2);
            this.Controls.Add(this.lbl_longitud_elemento_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmComparacionDeElementos";
            this.Text = "Comparación de elementos";
            this.Load += new System.EventHandler(this.FrmComparacionDeElementos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_longitud_elemento_1;
        private System.Windows.Forms.Label lbl_longitud_elemento_2;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.RichTextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}