namespace Presentacion
{
    partial class FrmArduino
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPlaca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.nUDEnable1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nUDInput1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nUDInput2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nUDInput4 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nUDInput3 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nUDEnable2 = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nUDServo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nUDEnable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInput4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInput3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDEnable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDServo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placa";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbPlaca
            // 
            this.cmbPlaca.FormattingEnabled = true;
            this.cmbPlaca.Location = new System.Drawing.Point(100, 46);
            this.cmbPlaca.Name = "cmbPlaca";
            this.cmbPlaca.Size = new System.Drawing.Size(162, 28);
            this.cmbPlaca.TabIndex = 1;
            this.cmbPlaca.SelectedIndexChanged += new System.EventHandler(this.cmbPlaca_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puerto";
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Location = new System.Drawing.Point(100, 118);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(162, 28);
            this.cmbPuerto.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(80, 499);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 50);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // nUDEnable1
            // 
            this.nUDEnable1.Location = new System.Drawing.Point(207, 166);
            this.nUDEnable1.Name = "nUDEnable1";
            this.nUDEnable1.ReadOnly = true;
            this.nUDEnable1.Size = new System.Drawing.Size(55, 26);
            this.nUDEnable1.TabIndex = 5;
            this.nUDEnable1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Enable 1,2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Input 1";
            // 
            // nUDInput1
            // 
            this.nUDInput1.Location = new System.Drawing.Point(207, 212);
            this.nUDInput1.Name = "nUDInput1";
            this.nUDInput1.ReadOnly = true;
            this.nUDInput1.Size = new System.Drawing.Size(55, 26);
            this.nUDInput1.TabIndex = 7;
            this.nUDInput1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Input 2";
            // 
            // nUDInput2
            // 
            this.nUDInput2.Location = new System.Drawing.Point(207, 259);
            this.nUDInput2.Name = "nUDInput2";
            this.nUDInput2.ReadOnly = true;
            this.nUDInput2.Size = new System.Drawing.Size(55, 26);
            this.nUDInput2.TabIndex = 9;
            this.nUDInput2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Input 4";
            // 
            // nUDInput4
            // 
            this.nUDInput4.Location = new System.Drawing.Point(207, 400);
            this.nUDInput4.Name = "nUDInput4";
            this.nUDInput4.ReadOnly = true;
            this.nUDInput4.Size = new System.Drawing.Size(55, 26);
            this.nUDInput4.TabIndex = 15;
            this.nUDInput4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Input 3";
            // 
            // nUDInput3
            // 
            this.nUDInput3.Location = new System.Drawing.Point(207, 353);
            this.nUDInput3.Name = "nUDInput3";
            this.nUDInput3.ReadOnly = true;
            this.nUDInput3.Size = new System.Drawing.Size(55, 26);
            this.nUDInput3.TabIndex = 13;
            this.nUDInput3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(115, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Enable 3,4";
            // 
            // nUDEnable2
            // 
            this.nUDEnable2.Location = new System.Drawing.Point(207, 307);
            this.nUDEnable2.Name = "nUDEnable2";
            this.nUDEnable2.ReadOnly = true;
            this.nUDEnable2.Size = new System.Drawing.Size(55, 26);
            this.nUDEnable2.TabIndex = 11;
            this.nUDEnable2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(207, 499);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 50);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(137, 450);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Servo";
            // 
            // nUDServo
            // 
            this.nUDServo.Location = new System.Drawing.Point(207, 446);
            this.nUDServo.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.nUDServo.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDServo.Name = "nUDServo";
            this.nUDServo.ReadOnly = true;
            this.nUDServo.Size = new System.Drawing.Size(55, 26);
            this.nUDServo.TabIndex = 18;
            this.nUDServo.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // FrmArduino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 598);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nUDServo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nUDInput4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nUDInput3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nUDEnable2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nUDInput2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nUDInput1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nUDEnable1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbPuerto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPlaca);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmArduino";
            this.Text = "FrmArduino";
            this.Load += new System.EventHandler(this.FrmArduino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDEnable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInput4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInput3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDEnable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDServo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPlaca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.NumericUpDown nUDEnable1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nUDInput1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUDInput2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nUDInput4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nUDInput3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nUDEnable2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nUDServo;
    }
}