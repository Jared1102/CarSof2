namespace Presentacion
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtgErrores = new System.Windows.Forms.DataGridView();
            this.dtgLexico = new System.Windows.Forms.DataGridView();
            this.pArduino = new System.Windows.Forms.Panel();
            this.txtTraduccion = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnLexico = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnSintactico = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnSemantico = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnTraducir = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnSubir = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnTodo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLexico)).BeginInit();
            this.pArduino.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.pArduino);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 700);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.Controls.Add(this.dtgErrores);
            this.panel5.Controls.Add(this.dtgLexico);
            this.panel5.Location = new System.Drawing.Point(400, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(400, 600);
            this.panel5.TabIndex = 3;
            // 
            // dtgErrores
            // 
            this.dtgErrores.AllowUserToAddRows = false;
            this.dtgErrores.AllowUserToDeleteRows = false;
            this.dtgErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgErrores.Location = new System.Drawing.Point(0, 300);
            this.dtgErrores.Name = "dtgErrores";
            this.dtgErrores.ReadOnly = true;
            this.dtgErrores.Size = new System.Drawing.Size(400, 300);
            this.dtgErrores.TabIndex = 1;
            // 
            // dtgLexico
            // 
            this.dtgLexico.AllowUserToAddRows = false;
            this.dtgLexico.AllowUserToDeleteRows = false;
            this.dtgLexico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLexico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLexico.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgLexico.Location = new System.Drawing.Point(0, 0);
            this.dtgLexico.Name = "dtgLexico";
            this.dtgLexico.ReadOnly = true;
            this.dtgLexico.Size = new System.Drawing.Size(400, 300);
            this.dtgLexico.TabIndex = 0;
            // 
            // pArduino
            // 
            this.pArduino.Controls.Add(this.txtTraduccion);
            this.pArduino.Dock = System.Windows.Forms.DockStyle.Right;
            this.pArduino.Location = new System.Drawing.Point(800, 0);
            this.pArduino.Name = "pArduino";
            this.pArduino.Size = new System.Drawing.Size(400, 600);
            this.pArduino.TabIndex = 2;
            // 
            // txtTraduccion
            // 
            this.txtTraduccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTraduccion.Location = new System.Drawing.Point(0, 0);
            this.txtTraduccion.Multiline = true;
            this.txtTraduccion.Name = "txtTraduccion";
            this.txtTraduccion.Size = new System.Drawing.Size(400, 600);
            this.txtTraduccion.TabIndex = 2;
            this.txtTraduccion.Text = "*int x=1;\r\nRun.Up(1,\"front\");";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtCodigo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 600);
            this.panel3.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigo.Location = new System.Drawing.Point(0, 0);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(400, 600);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "*int x=1;\r\nRun.Up(1,\"front\");";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 600);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 100);
            this.panel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnLexico);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 100);
            this.panel6.TabIndex = 0;
            // 
            // btnLexico
            // 
            this.btnLexico.Location = new System.Drawing.Point(40, 20);
            this.btnLexico.Name = "btnLexico";
            this.btnLexico.Size = new System.Drawing.Size(120, 60);
            this.btnLexico.TabIndex = 0;
            this.btnLexico.Text = "Analizar Léxico";
            this.btnLexico.UseVisualStyleBackColor = true;
            this.btnLexico.Click += new System.EventHandler(this.btnLexico_Click_1);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnSintactico);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(200, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 100);
            this.panel7.TabIndex = 1;
            // 
            // btnSintactico
            // 
            this.btnSintactico.Location = new System.Drawing.Point(40, 20);
            this.btnSintactico.Name = "btnSintactico";
            this.btnSintactico.Size = new System.Drawing.Size(120, 60);
            this.btnSintactico.TabIndex = 0;
            this.btnSintactico.Text = "Analizar Sintáctico";
            this.btnSintactico.UseVisualStyleBackColor = true;
            this.btnSintactico.Visible = false;
            this.btnSintactico.Click += new System.EventHandler(this.btnSintactico_Click_1);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnSemantico);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(400, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 100);
            this.panel8.TabIndex = 2;
            // 
            // btnSemantico
            // 
            this.btnSemantico.Location = new System.Drawing.Point(40, 20);
            this.btnSemantico.Name = "btnSemantico";
            this.btnSemantico.Size = new System.Drawing.Size(120, 60);
            this.btnSemantico.TabIndex = 0;
            this.btnSemantico.Text = "Analizar Semántico";
            this.btnSemantico.UseVisualStyleBackColor = true;
            this.btnSemantico.Visible = false;
            this.btnSemantico.Click += new System.EventHandler(this.btnSemantico_Click_1);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnTraducir);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(600, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(200, 100);
            this.panel9.TabIndex = 3;
            // 
            // btnTraducir
            // 
            this.btnTraducir.Location = new System.Drawing.Point(40, 20);
            this.btnTraducir.Name = "btnTraducir";
            this.btnTraducir.Size = new System.Drawing.Size(120, 60);
            this.btnTraducir.TabIndex = 0;
            this.btnTraducir.Text = "Traducir";
            this.btnTraducir.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnSubir);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(800, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(200, 100);
            this.panel10.TabIndex = 4;
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(40, 20);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(120, 60);
            this.btnSubir.TabIndex = 0;
            this.btnSubir.Text = "Subir";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Visible = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnTodo);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(1000, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 100);
            this.panel11.TabIndex = 5;
            // 
            // btnTodo
            // 
            this.btnTodo.Location = new System.Drawing.Point(40, 20);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(120, 60);
            this.btnTodo.TabIndex = 0;
            this.btnTodo.Text = "Compilar y subir";
            this.btnTodo.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarSof";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLexico)).EndInit();
            this.pArduino.ResumeLayout(false);
            this.pArduino.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pArduino;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView dtgErrores;
        private System.Windows.Forms.DataGridView dtgLexico;
        private System.Windows.Forms.TextBox txtTraduccion;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnTodo;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnTraducir;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnSemantico;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnSintactico;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnLexico;
    }
}

