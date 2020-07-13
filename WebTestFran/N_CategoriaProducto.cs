using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class N_CategoriaProducto
    {
        public List<Producto> Productos(string IdCategoris)
        {
            DataTable consulta = new DataTable();

            List<Producto> ListProductos = new List<Producto>();

            string cadenaConexion = string.Empty;
            cadenaConexion = ConfigurationManager.ConnectionStrings["CONEX"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("Usp_Sel_Co_Productos", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@IdCategoris", IdCategoris));                    
                    SqlDataAdapter da = new SqlDataAdapter(comando);



                    //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SIGF_ArmarExcel(" + IdClasificacion + "," + Prefijo + ")" , conexion);




                    da.Fill(consulta);
                    conexion.Close();


                    for (int i = 0; i < consulta.Rows.Count; i++)
                    {
                        Producto camp = new Producto();

                        camp.IdProduct = int.Parse(consulta.Rows[i]["nIdProduct"].ToString());
                        camp.NombProdu = consulta.Rows[i]["cNombProdu"].ToString();                        
                        camp.PrecioProd = decimal.Parse(consulta.Rows[i]["nPrecioProd"].ToString());
                        camp.NombCateg = consulta.Rows[i]["cNombCateg"].ToString();
                        


                        ListProductos.Add(camp);

                    }




                }
                catch (Exception ex)
                {
                    conexion.Close();
                    string error = "No ha sido posible establecer la conexión con la base de datos. Ha ocurrido un error en el proceso: " + ex.Message;
                }
            }

            return ListProductos;
        }


    }


        #region Productos

      public class Producto
        {
            public int IdProduct { get; set; }
            public string NombProdu { get; set; }
            public decimal PrecioProd { get; set; }
            public string NombCateg { get; set; }
        }

        #endregion


    
}
