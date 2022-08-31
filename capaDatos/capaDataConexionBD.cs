using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using capaEntidad;
using System.Data;

namespace capaData
{
    public class capaDataConexionBD
    {
        string cad_cnx;
        MySqlConnection mysqlcnn;

        public capaDataConexionBD()
        {
            cad_cnx = "Server=localhost;User=root;Password=oportunidades;Port=3306;database=educacionbasica";
        }
        //Metodo para la conexion a la BD
        public MySqlConnection GetConnection()
        {
            try
            {


                mysqlcnn = new MySqlConnection(cad_cnx);
                mysqlcnn.Open();

                // mysqlcnn.Open();

            }
            catch (MySqlException ex)
            {
                 MessageBox.Show("Error: Al conectarse a la Base de datos." + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Al realizar la conexion la Base de datos." + ex.Message);
            }
           
            return mysqlcnn;
        }

        //Metodo para Ejecucion de Consultas

        public int ExecuteQuery(string SQL)
        {
            int result = 0;
            try
            {

                MySqlCommand MySqlCommand = new MySqlCommand(SQL, GetConnection());

                result = MySqlCommand.ExecuteNonQuery();
                mysqlcnn.Close();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error: Al ejecutar las sentencias SQL." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }


        public MySqlDataReader GetDataReader(string SQL)
        {
            MySqlDataReader MySqlDr = null;
            try
            {
                MySqlCommand MySqlCommand = new MySqlCommand(SQL, GetConnection());
                MySqlDataAdapter MySqlDap = new MySqlDataAdapter(MySqlCommand);
                MySqlDr = MySqlCommand.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error: Al ejecutar las sentencias SQL." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return MySqlDr;
        }


        public DataTable GetDataTabla(string SQL)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            MySqlCommand MySqlCommand = new MySqlCommand(SQL, GetConnection());
            MySqlDataAdapter MySqlDap = new MySqlDataAdapter(MySqlCommand);
            MySqlDap.SelectCommand = MySqlCommand;
            MySqlDap.Fill(ds);
            dt = ds.Tables[0];
            return dt;


        }
    }
}
