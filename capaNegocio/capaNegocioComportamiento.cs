﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using capaEntidad;
using capaData;
namespace capaNegocio
{
    public class capaNegocioComportamiento
    {
        capaDataConexionBD cDConexionBd = new capaDataConexionBD();
        /*Metodo para Buscar los datos a la base de datos*/
        public void pruebaMysql()
        {
            cDConexionBd.GetConnection();
        }

        public void CargarGrid(DataGridView grid)
        {

            try
            {

                string query = string.Format("SELECT * from comportamiento ");//creamos la consulta a la base 
                //creamos el cmd para que se lleve el query y cargue la conexion con la DB
                MySqlCommand cmd = new MySqlCommand(query, cDConexionBd.GetConnection());

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grid.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        //Metodo para cargar el DataGridView con el dato a buscar en el total de los Registros de la Tabla de estructterritorial
        public void CargarGridBuscar(DataGridView grid, string txtBuscar)
        {


            try
            {

                string query = string.Format("SELECT * from comportamiento WHERE idFamilia LIKE '%{0}%' ", txtBuscar);//creamos la consulta a la base 
                //creamos el cmd para que se lleve el query y cargue la conexion con la DB
                MySqlCommand cmd = new MySqlCommand(query, cDConexionBd.GetConnection());

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grid.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
    }
}
