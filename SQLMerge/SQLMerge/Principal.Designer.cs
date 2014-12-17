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
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compSimpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cDobleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(60, 60);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem,
            this.compSimpleToolStripMenuItem,
            this.cDobleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(1028, 62);
            this.menuStrip1.TabIndex = 115;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.salirToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.salir1___copia;
            this.salirToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.salirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(54, 60);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.salirToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // compSimpleToolStripMenuItem
            // 
            this.compSimpleToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.compsimple;
            this.compSimpleToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.compSimpleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.compSimpleToolStripMenuItem.Name = "compSimpleToolStripMenuItem";
            this.compSimpleToolStripMenuItem.Size = new System.Drawing.Size(70, 60);
            this.compSimpleToolStripMenuItem.Text = "C. Simple";
            this.compSimpleToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.compSimpleToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.compSimpleToolStripMenuItem.Click += new System.EventHandler(this.compSimpleToolStripMenuItem_Click);
            // 
            // cDobleToolStripMenuItem
            // 
            this.cDobleToolStripMenuItem.Image = global::SQLMerge.Properties.Resources.compdoble;
            this.cDobleToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cDobleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cDobleToolStripMenuItem.Name = "cDobleToolStripMenuItem";
            this.cDobleToolStripMenuItem.Size = new System.Drawing.Size(65, 60);
            this.cDobleToolStripMenuItem.Text = "C. Doble";
            this.cDobleToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cDobleToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cDobleToolStripMenuItem.Click += new System.EventHandler(this.cDobleToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 689);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Merge -AZA";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compSimpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cDobleToolStripMenuItem;
    }
}

