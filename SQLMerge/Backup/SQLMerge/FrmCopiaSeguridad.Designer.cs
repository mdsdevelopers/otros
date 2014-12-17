namespace SQLMerge
{
    partial class FrmCopiaSeguridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCopiaSeguridad));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_destino = new System.Windows.Forms.Label();
            this.txt_rutadestino = new System.Windows.Forms.TextBox();
            this.lbl_base_datos = new System.Windows.Forms.Label();
            this.txt_base = new System.Windows.Forms.TextBox();
            this.txt_servidor = new System.Windows.Forms.TextBox();
            this.lbl_servidor = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbl_destino);
            this.groupBox1.Controls.Add(this.txt_rutadestino);
            this.groupBox1.Controls.Add(this.lbl_base_datos);
            this.groupBox1.Controls.Add(this.txt_base);
            this.groupBox1.Controls.Add(this.txt_servidor);
            this.groupBox1.Controls.Add(this.lbl_servidor);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 131);
            this.groupBox1.TabIndex = 116;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de operación";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(278, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 111;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbl_destino
            // 
            this.lbl_destino.AutoSize = true;
            this.lbl_destino.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_destino.ForeColor = System.Drawing.Color.Blue;
            this.lbl_destino.Location = new System.Drawing.Point(20, 102);
            this.lbl_destino.Name = "lbl_destino";
            this.lbl_destino.Size = new System.Drawing.Size(113, 14);
            this.lbl_destino.TabIndex = 110;
            this.lbl_destino.Text = "Origen/destino:";
            // 
            // txt_rutadestino
            // 
            this.txt_rutadestino.Location = new System.Drawing.Point(131, 99);
            this.txt_rutadestino.MaxLength = 100;
            this.txt_rutadestino.Name = "txt_rutadestino";
            this.txt_rutadestino.Size = new System.Drawing.Size(143, 22);
            this.txt_rutadestino.TabIndex = 3;
            // 
            // lbl_base_datos
            // 
            this.lbl_base_datos.AutoSize = true;
            this.lbl_base_datos.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_base_datos.ForeColor = System.Drawing.Color.Blue;
            this.lbl_base_datos.Location = new System.Drawing.Point(20, 68);
            this.lbl_base_datos.Name = "lbl_base_datos";
            this.lbl_base_datos.Size = new System.Drawing.Size(104, 14);
            this.lbl_base_datos.TabIndex = 106;
            this.lbl_base_datos.Text = "Base de datos:";
            // 
            // txt_base
            // 
            this.txt_base.Location = new System.Drawing.Point(132, 65);
            this.txt_base.MaxLength = 30;
            this.txt_base.Name = "txt_base";
            this.txt_base.Size = new System.Drawing.Size(142, 22);
            this.txt_base.TabIndex = 2;
            // 
            // txt_servidor
            // 
            this.txt_servidor.Enabled = false;
            this.txt_servidor.Location = new System.Drawing.Point(131, 31);
            this.txt_servidor.MaxLength = 50;
            this.txt_servidor.Name = "txt_servidor";
            this.txt_servidor.Size = new System.Drawing.Size(143, 22);
            this.txt_servidor.TabIndex = 104;
            // 
            // lbl_servidor
            // 
            this.lbl_servidor.AutoSize = true;
            this.lbl_servidor.ForeColor = System.Drawing.Color.Blue;
            this.lbl_servidor.Location = new System.Drawing.Point(20, 34);
            this.lbl_servidor.Name = "lbl_servidor";
            this.lbl_servidor.Size = new System.Drawing.Size(69, 14);
            this.lbl_servidor.TabIndex = 107;
            this.lbl_servidor.Text = "Servidor:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.restaurarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 73);
            this.menuStrip1.TabIndex = 115;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.icononuevotoolbar1;
            this.nuevoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(62, 69);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.nuevoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.iconoguardartoolbar;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(67, 69);
            this.guardarToolStripMenuItem.Text = "Generar";
            this.guardarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // restaurarToolStripMenuItem
            // 
            this.restaurarToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.restoraurar;
            this.restaurarToolStripMenuItem.Name = "restaurarToolStripMenuItem";
            this.restaurarToolStripMenuItem.Size = new System.Drawing.Size(77, 69);
            this.restaurarToolStripMenuItem.Text = "Restaurar";
            this.restaurarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FrmCopiaSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 230);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCopiaSeguridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copias de seguridad";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_destino;
        private System.Windows.Forms.TextBox txt_rutadestino;
        private System.Windows.Forms.Label lbl_base_datos;
        public System.Windows.Forms.TextBox txt_base;
        public System.Windows.Forms.TextBox txt_servidor;
        private System.Windows.Forms.Label lbl_servidor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurarToolStripMenuItem;
    }
}