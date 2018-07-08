namespace G_Clinic.Miscelaneos_y_Recursos
{
    partial class AutoCompletePatientSearch
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lstPacientesDisponibles = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Num_Expediente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cedula = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(1, 0);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(424, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            this.txtNombre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNombre_MouseDown);
            // 
            // lstPacientesDisponibles
            // 
            this.lstPacientesDisponibles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPacientesDisponibles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Num_Expediente,
            this.Nombre,
            this.Cedula});
            this.lstPacientesDisponibles.FullRowSelect = true;
            this.lstPacientesDisponibles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstPacientesDisponibles.Location = new System.Drawing.Point(1, 20);
            this.lstPacientesDisponibles.Name = "lstPacientesDisponibles";
            this.lstPacientesDisponibles.Size = new System.Drawing.Size(424, 228);
            this.lstPacientesDisponibles.TabIndex = 1;
            this.lstPacientesDisponibles.UseCompatibleStateImageBehavior = false;
            this.lstPacientesDisponibles.View = System.Windows.Forms.View.Details;
            this.lstPacientesDisponibles.DoubleClick += new System.EventHandler(this.lstPacientesDisponibles_DoubleClick);
            this.lstPacientesDisponibles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstPacientesDisponibles_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstPacientesDisponibles);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 249);
            this.panel1.TabIndex = 2;
            // 
            // Num_Expediente
            // 
            this.Num_Expediente.Text = "Expediente";
            this.Num_Expediente.Width = 65;
            // 
            // Nombre
            // 
            this.Nombre.Text = "Nombre";
            this.Nombre.Width = 256;
            // 
            // Cedula
            // 
            this.Cedula.Text = "Cédula";
            this.Cedula.Width = 166;
            // 
            // AutoCompletePatientSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AutoCompletePatientSearch";
            this.Size = new System.Drawing.Size(426, 249);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ListView lstPacientesDisponibles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader Num_Expediente;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Cedula;
    }
}
