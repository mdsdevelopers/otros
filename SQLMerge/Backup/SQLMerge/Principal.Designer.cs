namespace SQLMerge
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComparacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComparacionSimpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distintoServidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripLblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLblServidor = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLblNombreServidor = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLblBase = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLblNombreBase = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(60, 60);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.operacionsToolStripMenuItem,
            this.salirToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 84);
            this.menuStrip1.TabIndex = 115;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.login1;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(72, 80);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.loginToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // operacionsToolStripMenuItem
            // 
            this.operacionsToolStripMenuItem.Checked = true;
            this.operacionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.operacionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComparacionToolStripMenuItem,
            this.backupToolStripMenuItem});
            this.operacionsToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operacionsToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.backup2;
            this.operacionsToolStripMenuItem.Name = "operacionsToolStripMenuItem";
            this.operacionsToolStripMenuItem.Size = new System.Drawing.Size(111, 80);
            this.operacionsToolStripMenuItem.Text = "Operaciones";
            this.operacionsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.operacionsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ComparacionToolStripMenuItem
            // 
            this.ComparacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComparacionSimpleToolStripMenuItem,
            this.distintoServidorToolStripMenuItem});
            this.ComparacionToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ComparacionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ComparacionToolStripMenuItem.Name = "ComparacionToolStripMenuItem";
            this.ComparacionToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.ComparacionToolStripMenuItem.Text = "Comparación de bases";
            // 
            // ComparacionSimpleToolStripMenuItem
            // 
            this.ComparacionSimpleToolStripMenuItem.Name = "ComparacionSimpleToolStripMenuItem";
            this.ComparacionSimpleToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ComparacionSimpleToolStripMenuItem.Text = "Igual servidor";
            this.ComparacionSimpleToolStripMenuItem.Click += new System.EventHandler(this.ComparacionSimpleToolStripMenuItem_Click);
            // 
            // distintoServidorToolStripMenuItem
            // 
            this.distintoServidorToolStripMenuItem.Name = "distintoServidorToolStripMenuItem";
            this.distintoServidorToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.distintoServidorToolStripMenuItem.Text = "Distinto servidor";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.salir1;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(72, 80);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.salirToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ayudaToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ayudaToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.ayuda1;
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(72, 80);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ayudaToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.ToolStripLblUsuario,
            this.toolStripLblServidor,
            this.toolStripLblNombreServidor,
            this.toolStripLblBase,
            this.toolStripLblNombreBase});
            this.statusStrip1.Location = new System.Drawing.Point(0, 825);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(872, 22);
            this.statusStrip1.TabIndex = 116;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Usuario:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = ".";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolStripLblUsuario
            // 
            this.ToolStripLblUsuario.Name = "ToolStripLblUsuario";
            this.ToolStripLblUsuario.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripLblServidor
            // 
            this.toolStripLblServidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLblServidor.Name = "toolStripLblServidor";
            this.toolStripLblServidor.Size = new System.Drawing.Size(58, 17);
            this.toolStripLblServidor.Text = "Servidor:";
            // 
            // toolStripLblNombreServidor
            // 
            this.toolStripLblNombreServidor.Name = "toolStripLblNombreServidor";
            this.toolStripLblNombreServidor.Size = new System.Drawing.Size(10, 17);
            this.toolStripLblNombreServidor.Text = ".";
            // 
            // toolStripLblBase
            // 
            this.toolStripLblBase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLblBase.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripLblBase.Name = "toolStripLblBase";
            this.toolStripLblBase.Size = new System.Drawing.Size(86, 17);
            this.toolStripLblBase.Text = "Base de datos:";
            this.toolStripLblBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripLblNombreBase
            // 
            this.toolStripLblNombreBase.Name = "toolStripLblNombreBase";
            this.toolStripLblNombreBase.Size = new System.Drawing.Size(10, 17);
            this.toolStripLblNombreBase.Text = ".";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 847);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Merge ";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem operacionsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ComparacionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ComparacionSimpleToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripLblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLblServidor;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLblNombreServidor;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLblBase;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLblNombreBase;
        private System.Windows.Forms.ToolStripMenuItem distintoServidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
    }
}

