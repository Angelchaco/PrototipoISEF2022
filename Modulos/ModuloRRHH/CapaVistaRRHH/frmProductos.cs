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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();

            TextBox[] alias = navegador1.ClasificaTextboxsegunParent(this);
            navegador1.ObtenerCamposdeTabla(alias, "productos", "hotelSanCarlos");
            navegador1.MetodoSalirVista(this);
            navegador1.LlenarCombobox(cbxLinea, "linea", "idLinea", "nombre", "estado");
            navegador1.LlenarCombobox(cbxProv, "proveedores", "idProveedor", "nombre", "estado");

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

        private void dtpFechaExpiracion_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                navegador1.CambiarFormatoFecha(dtpFechaExpiracion, txtFechaExpiracion);
                navegador1.SeleccionarFechaDTP(dtpFechaExpiracion, txtFechaExpiracion);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void txtFechaExpiracion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                navegador1.SeleccionarFechaDTP(dtpFechaExpiracion, txtFechaExpiracion);
                navegador1.CambiarFormatoFecha(dtpFechaExpiracion, txtFechaExpiracion);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void txtIdLinea_TextChanged(object sender, EventArgs e)
        {
            navegador1.SeleccionarElementosenCombo(cbxLinea, txtIdLinea);
        }

        private void cbxLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            navegador1.EnviarDatoComboaTextbox(cbxLinea, txtIdLinea);
        }

        private void txtIdProv_TextChanged(object sender, EventArgs e)
        {
            navegador1.SeleccionarElementosenCombo(cbxProv, txtIdProv);
        }

        private void cbxProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            navegador1.EnviarDatoComboaTextbox(cbxProv, txtIdProv);
        }

        private void rbnEstatusamodulo_CheckedChanged(object sender, EventArgs e)
        {
            navegador1.CambioEstadoTextbox(txtEstado, rbnEstatusamodulo, "1");
        }

        private void rbnEstatusimodulo_CheckedChanged(object sender, EventArgs e)
        {
            navegador1.CambioEstadoTextbox(txtEstado, rbnEstatusimodulo, "0");
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            navegador1.ActivaRadiobtn(rbnEstatusamodulo, rbnEstatusimodulo, txtEstado);
        }

        private void dgvVistaPrevia_SelectionChanged(object sender, EventArgs e)
        {
            navegador1.SelecciondeFilaDGV(dgvVistaPrevia);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
