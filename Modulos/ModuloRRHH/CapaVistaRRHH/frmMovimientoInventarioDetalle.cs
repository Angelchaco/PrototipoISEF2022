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
    public partial class frmMovimientoInventarioDetalle : Form
    {
        public frmMovimientoInventarioDetalle()
        {
            InitializeComponent();

            TextBox[] alias = navegador1.ClasificaTextboxsegunParent(this);
            navegador1.ObtenerCamposdeTabla(alias, "movinvetario_detalle", "hotelSanCarlos");
            navegador1.MetodoSalirVista(this);
            navegador1.LlenarCombobox(cbxMovenc, "movinvetario_encabezado", "Pkid", "nombreMov", "estado");
            navegador1.LlenarCombobox(cbxProducto, "productos", "pkid", "nombre", "estado");

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

        private void cbxMovenc_SelectedIndexChanged(object sender, EventArgs e)
        {
            navegador1.EnviarDatoComboaTextbox(cbxMovenc, txtMovE);
        }

        private void txtMovE_TextChanged(object sender, EventArgs e)
        {
            navegador1.SeleccionarElementosenCombo(cbxMovenc, txtMovE);
        }

        private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            navegador1.EnviarDatoComboaTextbox(cbxProducto, txtIdProd);
        }

        private void txtIdProd_TextChanged(object sender, EventArgs e)
        {
            navegador1.SeleccionarElementosenCombo(cbxProducto, txtIdProd);
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
    }
}
