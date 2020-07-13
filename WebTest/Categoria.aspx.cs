using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTest
{
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object getGridCategoria()
        {
            N_CategoriaProducto Datos = new N_CategoriaProducto();

            var obj = Datos.GridCategorias();

            object json = obj; //new { data = obj };

            return json;

        }

        [WebMethod]
        public static object ActualizarCategoria(int IdC, string Nombre, Boolean estado)
        {
            N_CategoriaProducto Datos = new N_CategoriaProducto();

            var obj = Datos.Actualizar(IdC, Nombre, estado);

            object json = obj; //new { data = obj };

            return json;
        }


        [WebMethod]
        public static object Borrar(int IdC)
        {
            N_CategoriaProducto Datos = new N_CategoriaProducto();

            var obj = Datos.Borrar(IdC);

            object json = obj;

            return json;
        }

    }
}