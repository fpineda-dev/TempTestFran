<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebTest.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
  <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/bootstrap.min.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet"/>
  


<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Prueba Fran</title>  
</head>
<body>
    <header class="header">
        <a href="Inicio.aspx">
            <img class="header__img" src="./assets/FondoLogo.png" alt=""/>
        </a>
   </header>

   <section class="fondo">

         <div class="row justify-content-center" id="tbl">

            <table class="auto-style1">
              <tr>
                <td>&nbsp;</td>                
                <td style="align-items: center;">

                  <br />
                  <br />
                  <br />

                  <label for="Ext" class="cat" >Categoria:</label>

                  <div class="Row">                  
                    
                    <a href="Categoria.aspx">
                      <img src="./assets/agregar.png" class="imgbtn" style="height:35px;"  />
                    </a>
                  
                  <select id="IdCategoria" class="form-control" data-mini="true">
                    <option value="1">--Seleccione--</option>
                    
                  </select>

                  </div>


                  
                  <br />

                  <label for="Ext" class="Pro">Producto:</label>
                  

                   <select multiple id="IdProducto" class="auto-style6" data-mini="true">
                    
                  </select>
                </td>
                <td>&nbsp;</td>               

              </tr>
              <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
              </tr>
            </table>
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
  <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
<script src="js/crud.js"></script>
<script type="text/javascript">

  $(document).ready(function () {

    CargarCategoria();

    $('#IdCategoria').on('change', function () {

      var IdCat = $("#IdCategoria option:selected").val();
      CargarProducto(IdCat);

    });

  });




</script>

</html>
