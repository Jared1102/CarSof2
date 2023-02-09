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
        private List<TokensLexico> _listTokens;
        public FrmMain()
        {
            InitializeComponent();
            _manejadorLexico= new ManejadorLexico();
            _manejadorSintactico = new ManejadorSintactico();
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
            _manejadorSintactico.HacerSintactico(_listTokens, dtgSintactico);
        }
    }
}
