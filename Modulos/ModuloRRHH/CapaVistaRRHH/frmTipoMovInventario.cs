using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaRRHH
{
    public partial class frmTipoMovInventario : Form
    {
        public frmTipoMovInventario()
        {
            InitializeComponent();

            TextBox[] alias = navegador1.ClasificaTextboxsegunParent(this);
            navegador1.ObtenerCamposdeTabla(alias, "tipomovimientoinventario", "hotelSanCarlos");
            navegador1.MetodoSalirVista(this);
            navegador1.LlenarCombobox(cbxMotivo, "movimientomotivo", "Pkid", "Movimiento", "Estado");

            //inicio de elementos para dar de baja
            navegador1.campoEstado = "estado";
            //fin de elementos para dar de baja

            /* Inicio ID Aplicacion usada para reportes y ayudas */
            navegador1.idAplicacion = "0009";
            navegador1.idmodulo = "2";
            /* Inicio ID Aplicacion usada para reportes y ayudas */

            //inicio de elementos para ejecutar la ayuda
            navegador1.tablaAyuda = "Aplicacion";
            navegador1.campoAyuda = "pkId";
            //fin de elementos para ejecutar la ayuda


            // Inicio datos para ejecurar reportes
            navegador1.LlamarRutaReporte("ruta", "idAplicacion", "Reporte");
            // Final datos para ejecutar reportes

            navegador1.ObtenerNombreDGV(this.dgvVistaPrevia);
            navegador1.LlenarTabla();
            navegador1.ObtenerReferenciaFormActual(this);

        }

        private void dgvVistaPrevia_SelectionChanged(object sender, EventArgs e)
        {
            navegador1.SelecciondeFilaDGV(dgvVistaPrevia);
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbnEstatusamodulo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbnEstatusimodulo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            navegador1.EnviarDatoComboaTextbox(cbxMotivo, txtIdMovMotivo);
        }

        private void txtIdMovMotivo_TextChanged(object sender, EventArgs e)
        {
            navegador1.SeleccionarElementosenCombo(cbxMotivo, txtIdMovMotivo);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                navegador1.CambiarFormatoFecha(dtpFechaMov, txtFechaMov);
                navegador1.SeleccionarFechaDTP(dtpFechaMov, txtFechaMov);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void txtFechaMov_TextChanged(object sender, EventArgs e)
        {
            try
            {
                navegador1.SeleccionarFechaDTP(dtpFechaMov, txtFechaMov);
                navegador1.CambiarFormatoFecha(dtpFechaMov, txtFechaMov);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void dgvVistaPrevia_SelectionChanged_1(object sender, EventArgs e)
        {
            navegador1.SelecciondeFilaDGV(dgvVistaPrevia);
        }

        private void rbnEstatusamodulo_CheckedChanged_1(object sender, EventArgs e)
        {
            navegador1.CambioEstadoTextbox(txtEstado, rbnEstatusamodulo, "1");
        }

        private void rbnEstatusimodulo_CheckedChanged_1(object sender, EventArgs e)
        {
            navegador1.CambioEstadoTextbox(txtEstado, rbnEstatusimodulo, "0");
        }

        private void txtEstado_TextChanged_1(object sender, EventArgs e)
        {
            navegador1.ActivaRadiobtn(rbnEstatusamodulo, rbnEstatusimodulo, txtEstado);
        }
    }
}
