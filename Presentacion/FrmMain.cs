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

namespace Presentacion
{
    public partial class FrmMain : Form
    {
        private ManejadorLexico _manejadorLexico;
        public FrmMain()
        {
            InitializeComponent();
            _manejadorLexico= new ManejadorLexico();
        }

        private void btnLexico_Click(object sender, EventArgs e)
        {
            try
            {
                _manejadorLexico.HacerLexico(txtCodigo.Text, dtgLexico);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
