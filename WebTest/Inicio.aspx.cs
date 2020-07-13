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
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object getCategoria()
        {
            N_CategoriaProducto Datos = new N_CategoriaProducto();

            var obj = Datos.Categorias();

            object json = obj; //new { data = obj };

            return json;

        }


        [WebMethod]
        public static object GetProductoPorCategoria(string IdCategoria)
        {
            N_CategoriaProducto Datos = new N_CategoriaProducto();

            var objP = Datos.Productos(IdCategoria);

            object json = objP;

            return json;

        }
    }
}