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
            this.dtgSintactico = new System.Windows.Forms.DataGridView();
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
            this.panel11 = new System.Windows.Forms.Panel();
            this.dtgSemantica = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSintactico)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLexico)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSemantica)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(600, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 600);
            this.panel2.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dtgSintactico);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 200);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(600, 200);
            this.panel9.TabIndex = 2;
            // 
            // dtgSintactico
            // 
            this.dtgSintactico.AllowUserToAddRows = false;
            this.dtgSintactico.AllowUserToDeleteRows = false;
            this.dtgSintactico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSintactico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSintactico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSintactico.Location = new System.Drawing.Point(0, 0);
            this.dtgSintactico.Name = "dtgSintactico";
            this.dtgSintactico.ReadOnly = true;
            this.dtgSintactico.RowHeadersVisible = false;
            this.dtgSintactico.Size = new System.Drawing.Size(600, 200);
            this.dtgSintactico.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dtgLexico);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(600, 200);
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
            this.dtgLexico.Size = new System.Drawing.Size(600, 200);
            this.dtgLexico.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtCodigo);
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(600, 500);
            this.panel4.TabIndex = 3;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigo.Location = new System.Drawing.Point(0, 0);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(600, 500);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Text = "Off();\r\n*int x=10;\r\nwait(500);\r\nOn();\r\nRun.Up(500,\"front\");\r\nRun.Up(500,\"back\");\r" +
    "\nRun.Stop();\r\nRun.Turn(A);\r\n";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 100);
            this.panel3.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnLexico);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(300, 100);
            this.panel6.TabIndex = 0;
            // 
            // btnLexico
            // 
            this.btnLexico.Location = new System.Drawing.Point(95, 20);
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
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(900, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(300, 100);
            this.panel7.TabIndex = 1;
            // 
            // btnTodo
            // 
            this.btnTodo.Location = new System.Drawing.Point(95, 20);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(110, 60);
            this.btnTodo.TabIndex = 0;
            this.btnTodo.Text = "Compilar Todo";
            this.btnTodo.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnSintactico);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(300, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(300, 100);
            this.panel8.TabIndex = 2;
            // 
            // btnSintactico
            // 
            this.btnSintactico.Location = new System.Drawing.Point(95, 20);
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
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(600, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(300, 100);
            this.panel10.TabIndex = 3;
            // 
            // btnSemantico
            // 
            this.btnSemantico.Location = new System.Drawing.Point(95, 20);
            this.btnSemantico.Name = "btnSemantico";
            this.btnSemantico.Size = new System.Drawing.Size(110, 60);
            this.btnSemantico.TabIndex = 1;
            this.btnSemantico.Text = "Compilar Semántico";
            this.btnSemantico.UseVisualStyleBackColor = true;
            this.btnSemantico.Visible = false;
            this.btnSemantico.Click += new System.EventHandler(this.btnSemantico_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.dtgSemantica);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 400);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(600, 200);
            this.panel11.TabIndex = 3;
            // 
            // dtgSemantica
            // 
            this.dtgSemantica.AllowUserToAddRows = false;
            this.dtgSemantica.AllowUserToDeleteRows = false;
            this.dtgSemantica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSemantica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSemantica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSemantica.Location = new System.Drawing.Point(0, 0);
            this.dtgSemantica.Name = "dtgSemantica";
            this.dtgSemantica.ReadOnly = true;
            this.dtgSemantica.RowHeadersVisible = false;
            this.dtgSemantica.Size = new System.Drawing.Size(600, 200);
            this.dtgSemantica.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgSintactico)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLexico)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSemantica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dtgLexico;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dtgSintactico;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnLexico;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnTodo;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnSintactico;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.DataGridView dtgSemantica;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnSemantico;
    }
}

