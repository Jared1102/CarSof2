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

        private List<TokensLexico> _listTokens;
        private List<ArbolSintactico> _arbolSintacticos;
        public FrmMain()
        {
            InitializeComponent();
            _manejadorLexico= new ManejadorLexico();
            _manejadorSintactico = new ManejadorSintactico();
            _manejadorSemantico = new ManejadorSemantico();
        }

        private void btnLexico_Click(object sender, EventArgs e)
        {
            try
            {
                _listTokens=_manejadorLexico.HacerLexico(txtCodigo.Text, dtgLexico);
                btnSintactico.Visible= true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSintactico_Click(object sender, EventArgs e)
        {
            _arbolSintacticos=_manejadorSintactico.HacerSintactico(_listTokens, dtgSintactico);
            if (_arbolSintacticos.Count>0)
            {
                btnSemantico.Visible = true;
            }
        }

        private void btnSemantico_Click(object sender, EventArgs e)
        {
            _manejadorSemantico.HacerSemantica(_arbolSintacticos, dtgSemantica);
        }
    }
}
