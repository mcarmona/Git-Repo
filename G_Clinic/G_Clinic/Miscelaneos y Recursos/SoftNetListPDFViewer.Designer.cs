namespace G_Clinic.Miscelaneos_y_Recursos
{
    partial class SoftNetListPDFViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftNetListPDFViewer));
            this.softNet_AdobePDFViewer1 = new G_Clinic.Miscelaneos_y_Recursos.SoftNet_AdobePDFViewer_original();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstConsultas = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDetalleAdicional = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tobNuevo = new System.Windows.Forms.ToolStripButton();
            this.tobModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tobGuardar = new System.Windows.Forms.ToolStripButton();
            this.tobCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tobEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // softNet_AdobePDFViewer1
            // 
            this.softNet_AdobePDFViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.softNet_AdobePDFViewer1.BackColor = System.Drawing.Color.Black;
            this.softNet_AdobePDFViewer1.FileLocation = "";
            this.softNet_AdobePDFViewer1.Location = new System.Drawing.Point(338, 7);
            this.softNet_AdobePDFViewer1.Name = "softNet_AdobePDFViewer1";
            this.softNet_AdobePDFViewer1.Size = new System.Drawing.Size(445, 581);
            this.softNet_AdobePDFViewer1.TabIndex = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "id_consulta";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fecha Consulta";
            this.columnHeader1.Width = 319;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "bytes";
            this.columnHeader3.Width = 0;
            // 
            // lstConsultas
            // 
            this.lstConsultas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstConsultas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.lstConsultas.FullRowSelect = true;
            this.lstConsultas.Location = new System.Drawing.Point(6, 7);
            this.lstConsultas.Name = "lstConsultas";
            this.lstConsultas.Size = new System.Drawing.Size(324, 128);
            this.lstConsultas.TabIndex = 1;
            this.lstConsultas.UseCompatibleStateImageBehavior = false;
            this.lstConsultas.View = System.Windows.Forms.View.Details;
            this.lstConsultas.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(89, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Detalle Adicional";
            // 
            // txtDetalleAdicional
            // 
            this.txtDetalleAdicional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetalleAdicional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(241)))), ((int)(((byte)(133)))));
            this.txtDetalleAdicional.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetalleAdicional.Enabled = false;
            this.txtDetalleAdicional.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleAdicional.Location = new System.Drawing.Point(16, 37);
            this.txtDetalleAdicional.MaxLength = 150;
            this.txtDetalleAdicional.Multiline = true;
            this.txtDetalleAdicional.Name = "txtDetalleAdicional";
            this.txtDetalleAdicional.ReadOnly = true;
            this.txtDetalleAdicional.Size = new System.Drawing.Size(313, 373);
            this.txtDetalleAdicional.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.txtDetalleAdicional);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 418);
            this.panel1.TabIndex = 261;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(186, 140);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip3.Size = new System.Drawing.Size(145, 29);
            this.toolStrip3.TabIndex = 263;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tobNuevo
            // 
            this.tobNuevo.Enabled = false;
            this.tobNuevo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tobNuevo.Image")));
            this.tobNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNuevo.Name = "tobNuevo";
            this.tobNuevo.Size = new System.Drawing.Size(26, 26);
            this.tobNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobNuevo.ToolTipText = "Agregar Nuevo (Ctrl + N)";
            this.tobNuevo.Click += new System.EventHandler(this.tobNuevo_Click);
            // 
            // tobModificar
            // 
            this.tobModificar.Enabled = false;
            this.tobModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobModificar.Image = ((System.Drawing.Image)(resources.GetObject("tobModificar.Image")));
            this.tobModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobModificar.Name = "tobModificar";
            this.tobModificar.Size = new System.Drawing.Size(26, 26);
            this.tobModificar.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // tobGuardar
            // 
            this.tobGuardar.Enabled = false;
            this.tobGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tobGuardar.Image")));
            this.tobGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardar.Name = "tobGuardar";
            this.tobGuardar.Size = new System.Drawing.Size(26, 26);
            this.tobGuardar.Click += new System.EventHandler(this.tobGuardar_Click);
            // 
            // tobCancelar
            // 
            this.tobCancelar.Enabled = false;
            this.tobCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tobCancelar.Image")));
            this.tobCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCancelar.Name = "tobCancelar";
            this.tobCancelar.Size = new System.Drawing.Size(26, 26);
            this.tobCancelar.Click += new System.EventHandler(this.tobCancelar_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 29);
            // 
            // tobEliminar
            // 
            this.tobEliminar.Enabled = false;
            this.tobEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tobEliminar.Image")));
            this.tobEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEliminar.Name = "tobEliminar";
            this.tobEliminar.Size = new System.Drawing.Size(26, 26);
            this.tobEliminar.Click += new System.EventHandler(this.tobEliminar_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobNuevo,
            this.tobModificar,
            this.toolStripSeparator6,
            this.tobGuardar,
            this.tobCancelar,
            this.toolStripSeparator7,
            this.tobEliminar});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(183, 139);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(145, 29);
            this.toolStrip2.TabIndex = 262;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(184, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 2);
            this.label12.TabIndex = 264;
            // 
            // SoftNetListPDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.softNet_AdobePDFViewer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstConsultas);
            this.Name = "SoftNetListPDFViewer";
            this.Size = new System.Drawing.Size(789, 596);
            this.Load += new System.EventHandler(this.SoftNetListPDFViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SoftNet_AdobePDFViewer_original softNet_AdobePDFViewer1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lstConsultas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDetalleAdicional;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tobNuevo;
        private System.Windows.Forms.ToolStripButton tobModificar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tobGuardar;
        private System.Windows.Forms.ToolStripButton tobCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tobEliminar;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Label label12;
    }
}
