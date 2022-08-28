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

namespace capaPresentacion
{
    public partial class frmPrincipal : Form
    {
        int m, mx, my; //Variables Globales para la manipulacion de las ventana
        private Form activoFormulario = null; // para activacion de los formularios

        public frmPrincipal()
        {
            InitializeComponent();
            diseñoPersonalizado();
        }
        #region Seccion de Botones de la Barra de Titulo del Formulario (Close,Max,Min)
        private void bnfFBntClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bnfFBntMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }
        private void bnfFBntMin_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region PersonalizarMenu
        //Metodo para Personalizar Diseño
        private void diseñoPersonalizado()
        {
            /*pnlSubMenuAdmin.Visible = false;
            pnlSubMenuMetas.Visible = false;*/
            pnlSubmenuFichaFamilia.Visible = false;
        }

        //metodo para Ocultar el Submenu
        private void ocultarSubMenu()
        {
            /*if (pnlSubMenuAdmin.Visible == true)
                pnlSubMenuAdmin.Visible = false;
            if (pnlSubMenuMetas.Visible == true)
                pnlSubMenuMetas.Visible = false;*/
            if (pnlSubmenuFichaFamilia.Visible == true)
                pnlSubmenuFichaFamilia.Visible = false;
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

        #region Menu 
        //Mostrar los SubMenus de los Botos del Menu Principal
         private void bnfBtnFicha_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlSubmenuFichaFamilia);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmFicha());
            ocultarSubMenu();
        }

        #endregion

        #region AbrirFormulario
        //Metodo para Abrir Formularios hijo en el formulario Padre
        private void abrirFormularioHijo(Form formHijo)
        {
            if (activoFormulario != null)
                activoFormulario.Close();

            activoFormulario = formHijo;
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(formHijo);
            pnlMenu.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }
        #endregion
    }
}
