using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;
using Entidades;

namespace Presentacion
{
    public partial class FrmMain : Form
    {
        private ManejadorLexico _manejadorLexico;
        private ManejadorSintactico _manejadorSintactico;
        private ManejadorSemantico _manejadorSemantico;
        private ManejadorTraductor _manejadorTraductor;

        private List<TokensLexico> _listTokens;
        private List<ArbolSintactico> _arbolSintacticos;
        public FrmMain()
        {
            InitializeComponent();
            _manejadorLexico= new ManejadorLexico();
            _manejadorSintactico = new ManejadorSintactico();
            _manejadorSemantico = new ManejadorSemantico();
            _manejadorTraductor = new ManejadorTraductor();
        }

        #region Funciones

        private void limpiarTablas()
        {
            /*
            dtgLexico.Columns.Clear();
            dtgErrores.Columns.Clear();
            btnSemantico.Visible= false;
            btnSintactico.Visible= false;*/
        }

        #endregion

        private void btnLexico_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarTablas();
                _listTokens=_manejadorLexico.HacerLexico(txtCodigo.Text, dtgLexico);
                //btnSintactico.Visible= true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSintactico_Click(object sender, EventArgs e)
        {
            //_arbolSintacticos=_manejadorSintactico.HacerSintactico(_listTokens, dtgErrores);
            if (_arbolSintacticos.Count>0)
            {
                //btnSemantico.Visible = true;
            }
        }

        private void btnSemantico_Click(object sender, EventArgs e)
        {
            //_manejadorSemantico.HacerSemantica(_arbolSintacticos, dtgErrores, _listTokens);
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            limpiarTablas();
            _listTokens = _manejadorLexico.HacerLexico(txtCodigo.Text, dtgLexico);
            //_arbolSintacticos = _manejadorSintactico.HacerSintactico(_listTokens, dtgErrores);
            if (_arbolSintacticos.Count > 0)
            {
               // _manejadorSemantico.HacerSemantica(_arbolSintacticos, dtgErrores, _listTokens);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            limpiarTablas();
        }

        private void btnTraducir_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (cmbPlaca.SelectedIndex != -1 && cmbPuerto.SelectedIndex!=-1)
                {
                    _manejadorTraductor.Traducir(txtCodigo.Text, cmbPlaca.SelectedIndex, cmbPuerto.Text);
                }
                else
                {
                    MessageBox.Show("Seleccione una placa o un puerto");
                }
             */   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnLexico_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSintactico_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSemantico_Click_1(object sender, EventArgs e)
        {

        }
    }
}
