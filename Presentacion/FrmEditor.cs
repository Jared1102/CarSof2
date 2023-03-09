using Entidades;
using Manejadores;
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
    public partial class FrmEditor : Form
    {
        private Form activeForm=null;
        
        private List<TokensLexico> _listTokens;
        private List<ArbolSintactico> _arbolSintacticos;
        public static List<string> pines=new List<string>();

        private ManejadorLexico _manejadorLexico;
        private ManejadorSintactico _manejadorSintactico;
        private ManejadorSemantico _manejadorSemantico;
        private ManejadorTraductor _manejadorTraductor;
        public FrmEditor()
        {
            InitializeComponent();
            _manejadorLexico=new ManejadorLexico();
            _manejadorSintactico = new ManejadorSintactico();
            _manejadorSemantico=new ManejadorSemantico();
            _manejadorTraductor=new ManejadorTraductor();
        }

        #region funciones

        private void openChildForm(Form chilForm)
        {
            if (activeForm!=null)
            {
                activeForm.Close();
            }
            activeForm= chilForm;
            chilForm.TopLevel = false;
            chilForm.FormBorderStyle= FormBorderStyle.None;
            chilForm.Dock = DockStyle.Fill;
            pArduino.Controls.Add(chilForm);
            pArduino.Tag= chilForm;
            chilForm.BringToFront();
            chilForm.Show();
        }

        private void limpiarTablas()
        {
            dtgLexico.Columns.Clear();
            dtgErrores.Columns.Clear();
            btnSemantico.Visible= false;
            btnSintactico.Visible= false;
        }

        #endregion

        private void arduinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmArduino());
        }

        private void btnLexico_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarTablas();
                _listTokens = _manejadorLexico.HacerLexico(txtCodigo.Text, dtgLexico);
                btnSintactico.Visible= true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSintactico_Click(object sender, EventArgs e)
        {
            _arbolSintacticos=_manejadorSintactico.HacerSintactico(_listTokens, dtgErrores);
            if (_arbolSintacticos.Count > 0)
            {
                btnSemantico.Visible = true;
            }
        }

        private void btnSemantico_Click(object sender, EventArgs e)
        {
            _manejadorSemantico.HacerSemantica(_arbolSintacticos, dtgErrores, _listTokens);
        }

        private void btnTraducir_Click(object sender, EventArgs e)
        {
            if (pines.Count>0)
            {
                _listTokens = _manejadorLexico.HacerLexico(txtCodigo.Text, dtgLexico);
                txtTraduccion.Text = _manejadorTraductor.Traducir(_listTokens, pines);
            }
            else
            {
                MessageBox.Show("Se requieren seleccionar los pines, por favor utilice la pestaña Configuración y después Arduino");
            }
            

        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            for (int i = 2; i < 9; i++)
            {
                pines.Add(i.ToString());
            }
        }
    }
}
