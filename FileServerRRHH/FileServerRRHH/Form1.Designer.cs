﻿namespace FileServerRRHH
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.btnBorrarCache = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(710, 392);
            this.txtLog.TabIndex = 0;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Location = new System.Drawing.Point(26, 415);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(77, 17);
            this.chkAutoScroll.TabIndex = 1;
            this.chkAutoScroll.Text = "Auto Scroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // btnBorrarCache
            // 
            this.btnBorrarCache.Location = new System.Drawing.Point(619, 411);
            this.btnBorrarCache.Name = "btnBorrarCache";
            this.btnBorrarCache.Size = new System.Drawing.Size(103, 23);
            this.btnBorrarCache.TabIndex = 2;
            this.btnBorrarCache.Text = "Borrar Cache";
            this.btnBorrarCache.UseVisualStyleBackColor = true;
            this.btnBorrarCache.Click += new System.EventHandler(this.btnBorrarCache_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 444);
            this.Controls.Add(this.btnBorrarCache);
            this.Controls.Add(this.chkAutoScroll);
            this.Controls.Add(this.txtLog);
            this.Name = "Form1";
            this.Text = "File Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.Button btnBorrarCache;
    }
}

