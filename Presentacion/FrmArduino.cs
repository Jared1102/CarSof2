using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmArduino : Form
    {
        private bool guardar=true;
        public static List<string> backUpPines = new List<string>();
        public FrmArduino()
        {
            InitializeComponent();
        }

        #region Funciones

        private void VerificarPin(NumericUpDown numericUpDown)
        {
            if (!FrmEditor.pines.Contains(numericUpDown.Value.ToString()) && guardar)
            {
                FrmEditor.pines.Add(numericUpDown.Value.ToString());
            }
            else if(guardar)
            {
                MessageBox.Show(string.Format("El pin {0} ya esta en uso, seleccione otro", numericUpDown.Value.ToString()));
                guardar= false;
            }
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmArduino_Load(object sender, EventArgs e)
        {
            backUpPines.Clear();
            backUpPines=FrmEditor.pines.ToList();

            if (FrmEditor.pines.Count>0)
            {
                nUDEnable1.Value = int.Parse(FrmEditor.pines[0]);
                nUDEnable2.Value = int.Parse(FrmEditor.pines[1]);
                nUDInput1.Value = int.Parse(FrmEditor.pines[2]);
                nUDInput2.Value = int.Parse((FrmEditor.pines[3]));
                nUDInput3.Value = int.Parse((FrmEditor.pines[4]));
                nUDInput4.Value = int.Parse(FrmEditor.pines[5]);
                nUDServo.Value = int.Parse(FrmEditor.pines[6]);
            }
        }

        private void cmbPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmEditor.pines = backUpPines;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FrmEditor.pines.Clear();
            VerificarPin(nUDEnable1);
            VerificarPin(nUDEnable2);
            VerificarPin(nUDInput1);
            VerificarPin(nUDInput2);
            VerificarPin(nUDInput3);
            VerificarPin(nUDInput4);
            VerificarPin(nUDServo);
            if (guardar)
            {
                this.Close();
                
            }
            else
            {
                FrmEditor.pines = backUpPines.ToList();
                guardar = true;
            }
        }
    }
}
