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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtgErrores = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtgLexico = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnLexico = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnTodo = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnSintactico = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnSemantico = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnTraducir = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPlaca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgErrores)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLexico)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 600);
            this.panel2.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dtgErrores);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 200);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1200, 200);
            this.panel9.TabIndex = 2;
            // 
            // dtgErrores
            // 
            this.dtgErrores.AllowUserToAddRows = false;
            this.dtgErrores.AllowUserToDeleteRows = false;
            this.dtgErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgErrores.Location = new System.Drawing.Point(0, 0);
            this.dtgErrores.Name = "dtgErrores";
            this.dtgErrores.ReadOnly = true;
            this.dtgErrores.RowHeadersVisible = false;
            this.dtgErrores.Size = new System.Drawing.Size(1200, 200);
            this.dtgErrores.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dtgLexico);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1200, 200);
            this.panel5.TabIndex = 1;
            // 
            // dtgLexico
            // 
            this.dtgLexico.AllowUserToAddRows = false;
            this.dtgLexico.AllowUserToDeleteRows = false;
            this.dtgLexico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLexico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLexico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgLexico.Location = new System.Drawing.Point(0, 0);
            this.dtgLexico.Name = "dtgLexico";
            this.dtgLexico.ReadOnly = true;
            this.dtgLexico.RowHeadersVisible = false;
            this.dtgLexico.Size = new System.Drawing.Size(1200, 200);
            this.dtgLexico.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtCodigo);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(405, 600);
            this.panel4.TabIndex = 3;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigo.Location = new System.Drawing.Point(0, 100);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(405, 500);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Text = "*int x=1;\r\nRun.Up(1,\"front\");";
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(405, 100);
            this.panel3.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnLexico);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(243, 100);
            this.panel6.TabIndex = 0;
            // 
            // btnLexico
            // 
            this.btnLexico.Location = new System.Drawing.Point(66, 20);
            this.btnLexico.Name = "btnLexico";
            this.btnLexico.Size = new System.Drawing.Size(110, 60);
            this.btnLexico.TabIndex = 0;
            this.btnLexico.Text = "Compilar Léxico";
            this.btnLexico.UseVisualStyleBackColor = true;
            this.btnLexico.Click += new System.EventHandler(this.btnLexico_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnTodo);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(243, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(243, 100);
            this.panel7.TabIndex = 1;
            // 
            // btnTodo
            // 
            this.btnTodo.Location = new System.Drawing.Point(75, 20);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(110, 60);
            this.btnTodo.TabIndex = 0;
            this.btnTodo.Text = "Compilar Todo";
            this.btnTodo.UseVisualStyleBackColor = true;
            this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnSintactico);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(486, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(243, 100);
            this.panel8.TabIndex = 2;
            // 
            // btnSintactico
            // 
            this.btnSintactico.Location = new System.Drawing.Point(72, 20);
            this.btnSintactico.Name = "btnSintactico";
            this.btnSintactico.Size = new System.Drawing.Size(110, 60);
            this.btnSintactico.TabIndex = 0;
            this.btnSintactico.Text = "Compilar Sintáctico";
            this.btnSintactico.UseVisualStyleBackColor = true;
            this.btnSintactico.Visible = false;
            this.btnSintactico.Click += new System.EventHandler(this.btnSintactico_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 600);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnSemantico);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(729, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(243, 100);
            this.panel10.TabIndex = 3;
            // 
            // btnSemantico
            // 
            this.btnSemantico.Location = new System.Drawing.Point(71, 20);
            this.btnSemantico.Name = "btnSemantico";
            this.btnSemantico.Size = new System.Drawing.Size(110, 60);
            this.btnSemantico.TabIndex = 1;
            this.btnSemantico.Text = "Compilar Semántico";
            this.btnSemantico.UseVisualStyleBackColor = true;
            this.btnSemantico.Visible = false;
            this.btnSemantico.Click += new System.EventHandler(this.btnSemantico_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnTraducir);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(957, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(243, 100);
            this.panel12.TabIndex = 4;
            // 
            // btnTraducir
            // 
            this.btnTraducir.Location = new System.Drawing.Point(67, 20);
            this.btnTraducir.Name = "btnTraducir";
            this.btnTraducir.Size = new System.Drawing.Size(110, 60);
            this.btnTraducir.TabIndex = 0;
            this.btnTraducir.Text = "Traducir";
            this.btnTraducir.UseVisualStyleBackColor = true;
            this.btnTraducir.Click += new System.EventHandler(this.btnTraducir_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.cmbPlaca);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.cmbPuerto);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(939, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(261, 600);
            this.panel11.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Placa";
            // 
            // cmbPlaca
            // 
            this.cmbPlaca.FormattingEnabled = true;
            this.cmbPlaca.Items.AddRange(new object[] {
            "Arduino UNO",
            "Arduino Nano",
            "Arduino Mega",
            "Arduino Leonardo"});
            this.cmbPlaca.Location = new System.Drawing.Point(46, 143);
            this.cmbPlaca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPlaca.Name = "cmbPlaca";
            this.cmbPlaca.Size = new System.Drawing.Size(180, 28);
            this.cmbPlaca.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Puerto";
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3"});
            this.cmbPuerto.Location = new System.Drawing.Point(46, 58);
            this.cmbPuerto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(180, 28);
            this.cmbPuerto.TabIndex = 6;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarSof";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgErrores)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLexico)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dtgLexico;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dtgErrores;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnLexico;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnTodo;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnSintactico;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnSemantico;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnTraducir;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPlaca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPuerto;
    }
}

