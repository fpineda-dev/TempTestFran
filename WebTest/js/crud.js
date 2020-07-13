moduloCrud = function () {


  CargarCategoria = function () {

    var opciones = "";
    $.ajax({      
      method: "POST",
      url: 'Inicio.aspx/getCategoria',
      contentType: "application/json; charset=utf-8",
      data: JSON.stringify({ id: 0 }),
      dataType: "json",
      success: function (d) {        

        var _data = "";

        for (i in d) {
          _data = d[i];            
        }


         if (_data !== null) {          
          for (var i = 0; i < _data.length; i++) {
            opciones += "<option value='" + _data[i].IdCategori + "'>" + _data[i].NombCateg + "</option>";
          }
          $("#IdCategoria").html(opciones);
         
        }


         var IdCat = $("#IdCategoria option:selected").val();
         CargarProducto(IdCat);
         

         

      },
      error: function (a, b, c) {        
        swal("Error al cargar los datos.", {
          className: "red-bg",
        });
      }
    });


  }


  CargarProducto = function (IdCategoria) {

    var opciones = "";
    $.ajax({
      method: "POST",
      url: 'Inicio.aspx/GetProductoPorCategoria',
      contentType: "application/json; charset=utf-8",
      data: JSON.stringify({ IdCategoria: IdCategoria }),
      dataType: "json",
      success: function (d) {

        var _data = "";

        for (i in d) {
          _data = d[i];
        }


        if (_data !== null) {
          
          for (var i = 0; i < _data.length; i++) {
            opciones += "<option value='" + _data[i].IdProduct + "'>" + _data[i].NombProdu + "</option>";
          }
          $("#IdProducto").html(opciones);
          
        }

      },
      error: function (a, b, c) {
        //alert('Error');
        swal("Error al cargar las categorias, no existen o estan desactivadas.", {
          className: "red-bg",
        });
      }
    });

  }


  cambio = function () {
    var IdCat = $("#IdCategoria option:selected").val();
    CargarProducto(IdCat);
    
  }




  consultarCategoria = function () {

    $.ajax({      
      method: "POST",
      url: 'Categoria.aspx/getGridCategoria',
      contentType: "application/json; charset=utf-8",
      dataType: "json",     
      success: function (d) {
        //stopLoading();

        var _data = "";

        for (i in d) {
          _data = d[i];
        }

        var lista = _data;

        var poseeElementos = lista.length;
        if (poseeElementos) {
          
          MostrarCategoria(lista);

        }
        else {          
          swal("No se encontraron datos registrados.", {
            className: "red-bg",
          });

        }
      },
      error: function (a, b, c) {        
        swal("Error al obtener los datos.", {
          className: "red-bg",
        });
      }
    });
  }





  MostrarCategoria = function (lista) {

    var divContenedor = $('#divContenedores');
    divContenedor.empty();

    var tabla = '<table id="editabledatatable" class="table table-striped table-hover table-bordered">' +
      '<thead>' +
      '<tr>' +
      '<th class="td_Remove">Acciones</th>' +
      '<th class="td_id">ID</th>' +
      '<th class="td_cat">Nombre Categoria</th>' +
      '<th class="td_estado">Estado</th>' +      
      '</tr>' +
      '</thead>' +
      '<tbody>' +
      '</tbody>' +
      '</table>';

    divContenedor.append(tabla);
    var tBody = divContenedor.children();

    $.each(lista, function (index, item) {
      var fila =
        '<tr>' +

        '</td><td class="td_Removed">'                   
        + '<a href="#" class="btn btn-success" id="edit"  onclick="moduloCrud.CapturarFila(this)" data-toggle="modal" data-target="#Modal">Editar</a>'
        +'&nbsp;&nbsp;'
        + '<button type="button" onclick="moduloCrud.CapturarFila_Borrar(this)" class="btn btn-danger">Borrar</button>'
        + '</td>' +

        '<td>' + item.IdCategori + '</td>' +
        '<td>' + item.NombCateg + '</td>' +
        '<td>' + item.EsActiva + '</td>' +
        


        '</tr>';

      tBody.append(fila);
    });

    var poseeDatos = lista.length > 0;





    if (poseeDatos) {
      
      //$('#editabledatatable').DataTable();
    }
    else {
      tBody.append('<strong>Sin datos para mostrar</strong>');
    }



  }


  CapturarFila = function (row) {

    $("#catId").val($(row).parent().parent().find('td:nth-child(2)').html());
    $("#nomCate").val($(row).parent().parent().find('td:nth-child(3)').html());    

    var idEstado = $(row).parent().parent().find('td')[4].firstElementChild.value;
    $("#catEstado option[value=" + idEstado + "]").attr('selected', 'selected');


  }



  actualizarCategoria = function () {

   var IdC = $("#catId").val();
    var Nombre = $("#nomCate").val();
    var estado = '';

    //Validacion de campo
    if (Nombre == '') {
      swal("all fields are required", {
        className: "red-bg",
      });
      Nombre.focus;
      return false;
    }

    var Cat = $("#catEstado option:selected").text();

    if (Cat == 'Activo')
    {
      estado = 'True';
    }
    else if (Cat == 'Inactivo')
    {
      estado = 'False';
    }


    //playLoading();
    $.ajax({
      type: "POST",
      url: 'Categoria.aspx/ActualizarCategoria',
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify({ IdC: IdC, Nombre: Nombre, estado: estado }),
      success: function (data) {
        //stopLoading();
        location.reload();
        var lista = data;
        var poseeElementos = lista.length;
       
      },
      error: function (a, b, c) {       
        swal("Error al obtener los datos.", {
          className: "red-bg",
        });
      }
    });
  }




  CrearCategoria = function () {

    var IdC = $("#input-year").val();
    var Nombre = $("#nomCateG").val();
    var estado = '';
    const Idval = document.getElementsByClassName("input-year")[0];
    var existe = 0;

    //Validacion de campo
    if (Nombre == '') {
      swal("all fields are required", {
        className: "red-bg",
      });
      Nombre.focus;
      return false;
    }

    //Validar Seleccion
    if (!Idval.checkValidity()) {
      swal("please add Id", {
        className: "red-bg",
      });

      IdC.focus;
      return false;
    }

    var Cat = $("#catEstadoGS option:selected").text();

    if (Cat == 'Activo') {
      estado = 'True';
    }
    else if (Cat == 'Inactivo') {
      estado = 'False';
    }

    //Verifico si existe el id de la Categoria
    $('#editabledatatable tbody tr').each(function () {

      var idct = $(this).find("td").eq(1).html();
      var name = $(this).find("td").eq(2).html();
      console.log(idct)

      if (IdC === idct) {

        existe = 1
      } else if (name == Nombre) {

        existe = 2

      }



    });

    if (existe == 1) {
      swal("this id This id already exists", {
        className: "red-bg",
      });

      $("#nomCateG").val("");

      return false;
    } else if (existe == 2) {

      swal("This Name already exists", {
        className: "red-bg",
      });

      $("#nomCateG").val("");

      return false;

    } else {


      //playLoading();
      $.ajax({
        type: "POST",
        url: 'Categoria.aspx/ActualizarCategoria',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ IdC: IdC, Nombre: Nombre, estado: estado }),
        success: function (data) {
          //stopLoading();
          location.reload();
          var lista = data;
          var poseeElementos = lista.length;
        },
        error: function (a, b, c) {
          swal("Error al obtener los datos", {
            className: "red-bg",
          });
        }
      });


    }

    

    $("#nomCateG").val("");
    Idval.value == 0;
  }


  CapturarFila_Borrar = function (row) {

    var IdC = $(row).parent().parent().find('td:nth-child(2)').html(); 

    BorrarCategoria(IdC)

  }




  BorrarCategoria = function (IdC) {

    
    

    //playLoading();
    $.ajax({
      type: "POST",
      url: 'Categoria.aspx/Borrar',
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify({ IdC: IdC }),
      success: function (data) {
        //stopLoading();
        location.reload();
        var lista = data;
        var poseeElementos = lista.length;        
      },
      error: function (a, b, c) {
        swal("Error al borrar los datos", {
          className: "red-bg",
        });
      }
    });
  }




  return {
    CargarCategoria: CargarCategoria,
    CargarProducto: CargarProducto,
    cambio: cambio,
    consultarCategoria: consultarCategoria,
    MostrarCategoria: MostrarCategoria,
    CapturarFila: CapturarFila,
    actualizarCategoria: actualizarCategoria,
    CrearCategoria: CrearCategoria,
    BorrarCategoria: BorrarCategoria,
    CapturarFila_Borrar: CapturarFila_Borrar
  }
}();