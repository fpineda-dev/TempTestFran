using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebTestFran.Models;

namespace Datos
{




    public class N_CategoriaProducto
    {
        
        
        public string cadenaConexion = ConfigurationManager.ConnectionStrings["CONEX"].ConnectionString.ToString();

        public List<Producto> Productos(string IdCategoris)
        {

            DataTable consulta = new DataTable();

            List<Producto> ListProductos = new List<Producto>();

            
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

                        camp.IdProduct = int.Parse(consulta.Rows[i]["ID"].ToString());
                        camp.NombProdu = int.Parse(consulta.Rows[i]["ID"].ToString()) +" , "+ consulta.Rows[i]["nombre"].ToString() + " , " + decimal.Parse(consulta.Rows[i]["precio"].ToString()) + " , " + consulta.Rows[i]["nombre_categoria"].ToString();
                        //camp.PrecioProd = decimal.Parse(consulta.Rows[i]["nPrecioProd"].ToString());
                        //camp.NombCateg = consulta.Rows[i]["cNombCateg"].ToString();



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


        public List<Categoria> Categorias()
        {


            DataTable consulta = new DataTable();

            List<Categoria> ListCategoria = new List<Categoria>();

            
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT * FROM coCategoria where cEsActiva = 1", conexion);
                    comando.CommandType = CommandType.Text;                    
                    SqlDataAdapter da = new SqlDataAdapter(comando);



                    //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SIGF_ArmarExcel(" + IdClasificacion + "," + Prefijo + ")" , conexion);




                    da.Fill(consulta);
                    conexion.Close();


                    for (int i = 0; i < consulta.Rows.Count; i++)
                    {
                        Categoria camp = new Categoria();

                        camp.IdCategori = int.Parse(consulta.Rows[i]["nIdCategori"].ToString());
                        camp.NombCateg = consulta.Rows[i]["cNombCateg"].ToString();
                        //camp.EsActiva = Boolean.Parse(consulta.Rows[i]["cEsActiva"].ToString());
                        



                        ListCategoria.Add(camp);

                    }




                }
                catch (Exception ex)
                {
                    conexion.Close();
                    string error = "No ha sido posible establecer la conexión con la base de datos. Ha ocurrido un error en el proceso: " + ex.Message;
                }
            }

            return ListCategoria;






        }





        public List<CategoriaGrid> GridCategorias()
        {


            DataTable consulta = new DataTable();

            List<CategoriaGrid> ListCategoria = new List<CategoriaGrid>();


            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("select nIdCategori, cNombCateg, case cEsActiva when 'true' then 'Activo' when 'false' then 'Inactivo' end cEsActiva from coCategoria", conexion);
                    comando.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(comando);


                    da.Fill(consulta);
                    conexion.Close();


                    for (int i = 0; i < consulta.Rows.Count; i++)
                    {
                        CategoriaGrid camp = new CategoriaGrid();

                        camp.IdCategori = int.Parse(consulta.Rows[i]["nIdCategori"].ToString());
                        camp.NombCateg = consulta.Rows[i]["cNombCateg"].ToString();
                        camp.EsActiva = consulta.Rows[i]["cEsActiva"].ToString();                      



                        ListCategoria.Add(camp);

                    }


                }
                catch (Exception ex)
                {
                    conexion.Close();
                    string error = "No ha sido posible establecer la conexión con la base de datos. Ha ocurrido un error en el proceso: " + ex.Message;
                }
            }

            return ListCategoria;

        }


        public ProcessResult Actualizar(int IdC, string Nombre, Boolean estado)
        {
            ProcessResult processResult = new ProcessResult();           

            
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {


                    conexion.Open();
                    SqlCommand comando = new SqlCommand("Usp_Ins_Co_Categoria", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdCategori", IdC);
                    comando.Parameters.AddWithValue("@NombCateg", Nombre);
                    comando.Parameters.AddWithValue("@EsActiva", estado);
                    
                   
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    processResult.State = ProcessState.Success;
                    processResult.Details = "Archivo Actualizado Exitosamente";




                }
                catch (Exception ex)
                {
                    conexion.Close();
                    processResult.State = ProcessState.Failed;
                    processResult.Details = "Ha ocurrido un error" + ex.ToString();


                }
            }

            return processResult;
        }



        public ProcessResult Borrar(int IdC)
        {
            ProcessResult processResult = new ProcessResult();


            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {


                    conexion.Open();
                    SqlCommand comando = new SqlCommand("Usp_del_Categoria", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdCategorid", IdC);



                    comando.ExecuteNonQuery();
                    conexion.Close();
                    processResult.State = ProcessState.Success;
                    processResult.Details = "Archivo Borrado Exitosamente";




                }
                catch (Exception ex)
                {
                    conexion.Close();
                    processResult.State = ProcessState.Failed;
                    processResult.Details = "Ha ocurrido un error" + ex.ToString();


                }
            }

            return processResult;
        }


    }


    #region Productos

    public class Producto
    {
        public int IdProduct { get; set; }
        public string NombProdu { get; set; }
        //public decimal PrecioProd { get; set; }
        //public string NombCateg { get; set; }
    }

    #endregion


    #region Categorias    
    public class Categoria
    {
        public int IdCategori { get; set; }
        public string NombCateg { get; set; }
        //public Boolean EsActiva { get; set; }


    }
    #endregion

    #region GridCate

    public class CategoriaGrid
    {
        public int IdCategori { get; set; }
        public string NombCateg { get; set; }
        public string EsActiva { get; set; }
    }

    #endregion   


}
