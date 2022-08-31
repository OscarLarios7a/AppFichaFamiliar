using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frmFicha : Form
    {
        //capaEntidadDatosTerritoriales ceDatosTerritorial;
        capaNegocioDatosTerritoriales cNDatosTerritoriales;
        capaNegocioTutora cNTutora;
        capaNegocioCrisInco cNCrisInco;
        capaNegocioDispersion cNDispersion;
        capaNegocioComportamiento cNComportamiento;
        string nombreCompletoTutora = "";
        public frmFicha()
        {
            InitializeComponent();
            
            cNDatosTerritoriales = new capaNegocioDatosTerritoriales();
            cNTutora = new capaNegocioTutora();
            cNCrisInco = new capaNegocioCrisInco();
            cNDispersion = new capaNegocioDispersion();
            cNComportamiento = new capaNegocioComportamiento();
            cNDatosTerritoriales.pruebaMysql();
            cNTutora.pruebaMysql();

        }

        private void pnlDispersionesCentral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmFicha_Load(object sender, EventArgs e)
        {
            diseñoPersonalizado();
            //cNDatosTerritoriales.CargarGrid(dtgvDatosTerritoriales);
            //cNTutora.CargarGrid(dtgvTutora);
            //cNCrisInco.CargarGrid(dtgvCrisInco);
            //cNDispersion.CargarGrid(dtgvDispersion);
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            //cNDatosTerritoriales.CargarGrid(dtgvDatosTerritoriales);
            //cNTutora.CargarGrid(dtgvTutora);

            cajasTextoVacias();
            //SEccion de Datos Territoriales
            if (txtSearch.Text != "")
            {

                cNDatosTerritoriales.CargarGridBuscar(dtgvDatosTerritoriales, txtSearch.Text);
                txtIdRegion.Text = dtgvDatosTerritoriales.CurrentRow.Cells[2].Value.ToString();
                txtRegion.Text = dtgvDatosTerritoriales.CurrentRow.Cells[3].Value.ToString();
                txtInegi.Text = dtgvDatosTerritoriales.CurrentRow.Cells[4].Value.ToString();
                txtCveMun.Text = dtgvDatosTerritoriales.CurrentRow.Cells[5].Value.ToString();
                txtMunicipio.Text = dtgvDatosTerritoriales.CurrentRow.Cells[6].Value.ToString();
                txtCveLoc.Text = dtgvDatosTerritoriales.CurrentRow.Cells[7].Value.ToString();
                txtLocalidad.Text = dtgvDatosTerritoriales.CurrentRow.Cells[8].Value.ToString();

            }
            //Seccion para los Datos de la Tutora

            if (txtSearch.Text != "")
            {
                cNTutora.CargarGridBuscar(dtgvTutora, txtSearch.Text);
                txtIdTutora.Text = dtgvTutora.CurrentRow.Cells[2].Value.ToString();
                nombreCompletoTutora = dtgvTutora.CurrentRow.Cells[4].Value + " " + dtgvTutora.CurrentRow.Cells[5].Value + " " + dtgvTutora.CurrentRow.Cells[6].Value;
                txtNombreCompleto.Text = nombreCompletoTutora.ToString();
                txtEstatus.Text = dtgvTutora.CurrentRow.Cells[7].Value.ToString();
            }
            //Seccion para los Datos si esta con CRIS y Notificacion de Incorporacion
            if (txtSearch.Text != "")
            {
                cNCrisInco.CargarGridBuscar(dtgvCrisInco, txtSearch.Text);
                txtCrisCR2021.Text = dtgvCrisInco.CurrentRow.Cells[4].Value.ToString();
                txtCrisFecha2021.Text= dtgvCrisInco.CurrentRow.Cells[5].Value.ToString();
                txtIncCR2021.Text= dtgvCrisInco.CurrentRow.Cells[6].Value.ToString();
                txtIncFecha2021.Text= dtgvCrisInco.CurrentRow.Cells[7].Value.ToString();
                txtCrisCodRes2020.Text= dtgvCrisInco.CurrentRow.Cells[8].Value.ToString();
                txtCrisFecha2020.Text= dtgvCrisInco.CurrentRow.Cells[9].Value.ToString();
                txtIncCodRes2020.Text= dtgvCrisInco.CurrentRow.Cells[10].Value.ToString();
                txtIncFecha2020.Text= dtgvCrisInco.CurrentRow.Cells[11].Value.ToString();
            }
            //Seccion para los Datos de Dispersion de Recursos a la Tutura
            if (txtSearch.Text != "")
            {
                cNDispersion.CargarGridBuscar(dtgvDispersion, txtSearch.Text);
                //Año 2019
                txtInc19.Text= dtgvDispersion.CurrentRow.Cells[2].Value.ToString();
                txtEneFeb19.Text = dtgvDispersion.CurrentRow.Cells[3].Value.ToString(); 
                txtMarAbr19.Text = dtgvDispersion.CurrentRow.Cells[4].Value.ToString(); 
                txtMayJun19.Text = dtgvDispersion.CurrentRow.Cells[5].Value.ToString(); 
                txtJulAgost19.Text = dtgvDispersion.CurrentRow.Cells[6].Value.ToString(); 
                txtSeptOct19.Text = dtgvDispersion.CurrentRow.Cells[7].Value.ToString(); 
                txtNovDic19.Text = dtgvDispersion.CurrentRow.Cells[8].Value.ToString(); 
                txtRez19.Text = dtgvDispersion.CurrentRow.Cells[9].Value.ToString();
                //Año 2020
                txtInc20.Text = dtgvDispersion.CurrentRow.Cells[10].Value.ToString();
                txtEneFeb20.Text = dtgvDispersion.CurrentRow.Cells[11].Value.ToString();
                txtMarAbr20.Text = dtgvDispersion.CurrentRow.Cells[12].Value.ToString();
                txtMayJun20.Text = dtgvDispersion.CurrentRow.Cells[13].Value.ToString();
                txtJulAgost20.Text = dtgvDispersion.CurrentRow.Cells[14].Value.ToString();
                txtSeptOct20.Text = dtgvDispersion.CurrentRow.Cells[15].Value.ToString();
                txtNovDic20.Text = dtgvDispersion.CurrentRow.Cells[16].Value.ToString();
                txtRez20.Text = dtgvDispersion.CurrentRow.Cells[17].Value.ToString();
                //Año 2021
                txtInc21.Text = dtgvDispersion.CurrentRow.Cells[18].Value.ToString();
                txtEneFeb21.Text = dtgvDispersion.CurrentRow.Cells[19].Value.ToString();
                txtMarAbr21.Text = dtgvDispersion.CurrentRow.Cells[20].Value.ToString();
                txtMayJun21.Text = dtgvDispersion.CurrentRow.Cells[21].Value.ToString();
                txtJulAgost21.Text = dtgvDispersion.CurrentRow.Cells[22].Value.ToString();
                txtSeptOct21.Text = dtgvDispersion.CurrentRow.Cells[23].Value.ToString();
                txtNovDic21.Text = dtgvDispersion.CurrentRow.Cells[24].Value.ToString();
                txtRez21.Text = dtgvDispersion.CurrentRow.Cells[25].Value.ToString();
                //Año 2022
                txtInc22.Text = dtgvDispersion.CurrentRow.Cells[18].Value.ToString();
                txtEneFeb22.Text = dtgvDispersion.CurrentRow.Cells[19].Value.ToString();
                txtMarAbr22.Text = dtgvDispersion.CurrentRow.Cells[20].Value.ToString();
                txtMayJun22.Text = dtgvDispersion.CurrentRow.Cells[21].Value.ToString();
                txtJulAgost22.Text = dtgvDispersion.CurrentRow.Cells[22].Value.ToString();
                txtSeptOct22.Text = dtgvDispersion.CurrentRow.Cells[23].Value.ToString();
                txtNovDic22.Text = dtgvDispersion.CurrentRow.Cells[24].Value.ToString();
                txtRez22.Text = dtgvDispersion.CurrentRow.Cells[25].Value.ToString();
            }
            //Seccion para los Datos de Comportamiento del Instituto Liquidadora para la Tutora
            if (txtSearch.Text != "")
            {
                cNComportamiento.CargarGridBuscar(dtgvComportamiento, txtSearch.Text);
                txtLiqSem1_2022.Text = dtgvComportamiento.CurrentRow.Cells[2].Value.ToString();
                txtLiqSem1_2021.Text = dtgvComportamiento.CurrentRow.Cells[3].Value.ToString();
                txtLiqSem2_2021.Text = dtgvComportamiento.CurrentRow.Cells[4].Value.ToString();


            }

            else
            {
                cajasTextoVacias();
            }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        //Metodo para manetener las cajas vacias
        public void cajasTextoVacias()
        {
            //Datos Territoriales
            txtIdRegion.Text = "";
            txtRegion.Text = "";
            txtInegi.Text = "";
            txtCveMun.Text = "";
            txtMunicipio.Text = "";
            txtCveLoc.Text = "";
            txtLocalidad.Text = "";
            //Tutora
            txtIdTutora.Text = "";
            txtNombreCompleto.Text = "";
            txtEstatus.Text = "";
            //Cris - Incorporacion
            txtCrisCR2021.Text = "";
            txtCrisFecha2021.Text = "";
            txtIncCR2021.Text = "";
            txtIncFecha2021.Text = "";
            txtCrisCodRes2020.Text = "";
            txtCrisFecha2020.Text = "";
            txtIncCodRes2020.Text = "";
            txtIncFecha2020.Text = "";
            /*Dispersion*/
            //Año 2019
            txtInc19.Text = "";
            txtEneFeb19.Text = "";
            txtMarAbr19.Text = "";
            txtMayJun19.Text = "";
            txtJulAgost19.Text = "";
            txtSeptOct19.Text = "";
            txtNovDic19.Text = "";
            txtRez19.Text = "";
            //Año 2020
            txtInc20.Text = "";
            txtEneFeb20.Text = "";
            txtMarAbr20.Text = "";
            txtMayJun20.Text = "";
            txtJulAgost20.Text = "";
            txtSeptOct20.Text = "";
            txtNovDic20.Text = "";
            txtRez20.Text = "";
            //Año 2021
            txtInc21.Text = "";
            txtEneFeb21.Text = "";
            txtMarAbr21.Text = "";
            txtMayJun21.Text = "";
            txtJulAgost21.Text = "";
            txtSeptOct21.Text = "";
            txtNovDic21.Text = "";
            txtRez21.Text = "";
            //Año 2022
            txtInc22.Text = "";
            txtEneFeb22.Text = "";
            txtMarAbr22.Text = "";
            txtMayJun22.Text = "";
            txtJulAgost22.Text = "";
            txtSeptOct22.Text = "";
            txtNovDic22.Text = "";
            txtRez22.Text = "";

            /*Comportamiento*/
            txtLiqSem1_2022.Text = "";
            txtLiqSem1_2021.Text = "";
            txtLiqSem2_2021.Text = "";

        }

        #region PersonalizarMenu
        //Metodo para Personalizar Diseño
        private void diseñoPersonalizado()
        {
            /*pnlSubMenuAdmin.Visible = false;
            pnlSubMenuMetas.Visible = false;*/
            pnlBuscarAvanzada.Visible = false;
        }

        //metodo para Ocultar el Submenu
        private void ocultarSubMenu()
        {
            /*if (pnlSubMenuAdmin.Visible == true)
                pnlSubMenuAdmin.Visible = false;
            if (pnlSubMenuMetas.Visible == true)
                pnlSubMenuMetas.Visible = false;*/
            if (pnlBuscarAvanzada.Visible == true)
                pnlBuscarAvanzada.Visible = false;
        }
        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        #endregion

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlBuscarAvanzada);
        }
    }
}
