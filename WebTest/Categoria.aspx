<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="WebTest.Categoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/bootstrap.min.css" rel="stylesheet" />
  <link rel="stylesheet" href="css/categoria.css">


  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>Categoria</title>

</head>

<body>
  <header class="header">
    <a href="Inicio.aspx">
      <img class="header__img" src="./assets/FondoLogo.png" alt="">
    </a>
  </header>
  <section class="fondo">
    <div class="widget-main">
      <div class="row">
        <div class="col-xs-12 col-md-12">
          <div class="widget">
            <div class="widget-header">
            </div>
            <div class="widget-body">

              <br />
              <div class="row">                
                <a href="#" class="btn btn-primary" id="Guardar"
                  data-toggle="modal" data-target="#ModalGuardar">+</a>

              </div>
              <br />

              <div class="table-responsive">
                <div class="col-lg-12 col-sm-12 col-xs-12">
                  <div id="divContenedores">
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>



    <div class="modal fade" id="Modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

      <div class="body-content" id="Body">



        <div class="modal-dialog modal-lg" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
              <h4 class="modal-title" id="myModal">EDITAR CATEGORIAS</h4>
            </div>


            <div class="form-group">
              <label for="categoriaId">ID:</label>
              <input class="form-control text-box single-line" data-val="true" maxlength="100" id="catId"
                placeholder="ID" type="text" value="" readonly="true" />
            </div>

            <div class="form-group">
              <label for="ncategoria">Nombre Categoria:</label>
              <input id="nomCate" type="text" class="form-control" maxlength="100" placeholder="NOMBRE CATEGORIA" />
            </div>

            <div class="form-group">
              <label for="estado">Estado:</label>
              <select id="catEstado" type="text" class="form-control">
                <option value="1">Activo</option>
                <option value="2">Inactivo</option>
              </select>

            </div>





            <div class="modal-footer">
              <input type="button" id="GuardarCate" onclick="moduloCrud.actualizarCategoria()" class="btn btn-success"
                value="Guardar" />


              <button type="button" id="Cerrar" class="btn btn-default" data-dismiss="modal">
                Close
              </button>

              <br />
            </div>

          </div>          

        </div>
        <!-- /.modal-content -->
        <!-- <%--</div>--%> -->
        <!-- /.modal-dialog -->

      </div>
      <!--fin del Modal-->

    </div>


    <!--INICIA EL MODAL DE GUARDAR-->

    <div class="modal fade" id="ModalGuardar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
      aria-hidden="true">

      <div class="body-content" id="BodyG">



        <div class="modal-dialog modal-lg" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
              <h4 class="modal-title" id="myModalGuardar">GUARDAR CATEGORIAS</h4>
            </div>


            <div class="form-group">
              <label for="categoriaId">ID:</label>
              <input class="input-year form-control text-box single-line" id="input-year" type="number" value="0" min="1" require />
            </div>

            <div class="form-group">
              <label for="ncategoria">Nombre Categoria:</label>
              <input id="nomCateG" type="text" class="form-control" maxlength="100" placeholder="NOMBRE CATEGORIA" />
            </div>

            <div class="form-group">
              <label for="estado">Estado:</label>            

              <select id="catEstadoGS" type="text" class="form-control">
                <option value="1">Activo</option>
                <option value="2">Inactivo</option>
              </select>

            </div>
           

            <div class="modal-footer">
              <input type="button" id="GuardarCateG" onclick="moduloCrud.CrearCategoria()" class="btn btn-success"
                value="Guardar" />


              <button type="button" id="CerrarG" class="btn btn-default" data-dismiss="modal">
                Close
              </button>

              <br />
            </div>

          </div>


        </div>
        <!-- /.modal-content -->
        <!-- <%--</div>--%> -->
        <!-- /.modal-dialog -->

      </div>
      <!--fin del Modal-->

    </div>
   

  </section>
  <footer class="footer">
    <div class="footer__init">
      <a href="#">Lucida</a>
      <a>&nbsp;|&nbsp;</a>
      <a href="#">2020</a>
    </div>


    <div class="footer__menu">
      <a href="">About Us</a>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
      <a href="#" target="_blank">Contact</a>
    </div>
  </footer>

</body>

<script src="js/jquery-1.10.2.js"></script>
<script src="js/jquery.dataTables.js"></script>
<script src="js/bootstrap.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
<script src="js/crud.js"></script>
<script type="text/javascript">

  $(document).ready(function () {

    consultarCategoria();

  });

</script>

</html>
