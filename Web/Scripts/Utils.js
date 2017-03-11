function nSuccess(msj, type) {
    swal("Exito!", msj, "success");
}
function nError(msj, type) {
    swal("Error", msj, "error");
}
$('.swal-delete').click(function (e) {
    var href = $(this).attr('href');
    e.preventDefault();
    swal({
        title: "¿Está Seguro?",
        text: "",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si",
        cancelButtonText: "No",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function (isConfirm) {
        if (isConfirm) {
            window.location = href;
        } else {
            swal("Cancelado", "Su registro no fue eliminado", "error");
        }
    });
});

function AllowOnlyAmountAndDot(txt) {
    if (event.keyCode > 47 && event.keyCode < 58 || event.keyCode == 46) {
        var txtbx = document.getElementById(txt);
        var amount = document.getElementById(txt).value;
        var present = 0;
        var count = 0;

        do {
            present = amount.indexOf(",", present);
            if (present != -1) {
                count++;
                present++;
            }
        }
        while (present != -1);
        if (present == -1 && amount.length == 0 && event.keyCode == 46) {
            event.keyCode = 0;
            //alert("Wrong position of decimal point not  allowed !!");
            return false;
        }

        if (count >= 1 && event.keyCode == 46) {

            event.keyCode = 0;
            //alert("Only one decimal point is allowed !!");
            return false;
        }
        if (count == 1) {
            var lastdigits = amount.substring(amount.indexOf(",") + 1, amount.length);
            if (lastdigits.length >= 2) {
                //alert("Two decimal places only allowed");
                event.keyCode = 0;
                return false;
            }
        }
        return true;
    }
    else {
        event.keyCode = 0;
        //alert("Only Numbers with dot allowed !!");
        return false;
    }
}

function EnableDisableInput(chkbx) {
    var input = chkbx.closest('tr').find('td input[type=text]');
    if (chkbx.is(':checked')) {
        //console.log("if");
        input.attr('disabled', false);
    } else {
        //console.log("else");
        input.attr('disabled', true);
    }
}

/****           FUNCION QUE TRAE LA FECHA ACTUAL                       ****/
function getFechaActual() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    today = dd + '/' + mm + '/' + yyyy;
    return today
}

$(function () {
    $(".autocomplete-search").each(function () {
        var url = $(this).attr('data-url');
     
        var selectorId = $(this).attr('data-id-selector');
       
        if (selectorId == "#articuloId") {
            var key = "personaId";
            $(this).autocomplete({
                search: function (event, ui) {
                },
                autoFocus: true,
                delay: 300,
                source: function (request, response) {
                    var vista = $("#ViewBag").val()
                    if (vista == "Create Compra") {
                        var listaPrecioId = 0
                    }
                    else {
                        var listaPrecioId = $("#ListaP").val()
                    }

                    $.ajax({
                        url: url,
                        type: "POST",
                        dataType: "json",
                        data: { query: request.term, listaPrecioId: listaPrecioId, vista: vista },
                        success: function (data) {
                            
                            var mappedData = $.map(data,
                                                 function (item) {
                                                    
                                                     var arreglo=[]
                                                     //$.each(item, function (key, value) {
                                                     //    if (!$.inArray(item.nombre,arreglo)) {
                                                     //        arreglo.push(item.nombre)
                                                             return {
                                                                 label: item.nombre,
                                                                 value: item.nombre,
                                                                 id: item.id
                                                             };
                                                         }
                                                        
                                                 //    })
                                                   
                                                 //}
                                                 );
                            response(mappedData);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            nError("No se pudo encontrar el artículo, asegúrese de haber agregado cliente", "error");
                        }
                    })
                },
                minLength: 2,
                select: function (event, ui) {
                    $(selectorId).val(ui.item.id);
                    $(selectorId).change();

                }
            });

        }
        if (selectorId == '#proveedorId') {
                      
            var key = "personaId";
            $(this).autocomplete({
                search: function (event, ui) {
                },
                autoFocus: true,
                delay: 300,
                source: function (request, response) {
                 
                    $.ajax({
                        url: url,
                        type: "POST",
                        dataType: "json",
                        data: { query: request.term, proveedorFilter : true},
                        success: function (data) {

                            var mappedData = $.map(data,
                                                 function (item) {

                                                     var arreglo = []
                                                     //$.each(item, function (key, value) {
                                                     //    if (!$.inArray(item.nombre,arreglo)) {
                                                     //        arreglo.push(item.nombre)
                                                     return {
                                                         label: item.nombre,
                                                         value: item.nombre,
                                                         id: item.id
                                                     };
                                                 }

                                                 //    })

                                                 //}
                                                 );
                            response(mappedData);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            nError("No se pudo encontrar el proveedor, asegúrese de haberlo agregado", "error");
                        }
                    })
                },
                minLength: 2,
                select: function (event, ui) {
                  
                    $(selectorId).val(ui.item.id);
                    $(selectorId).change();

                }
            });
        }
        if (selectorId == '#cobradorId') {
                    var key = "personaId";
            $(this).autocomplete({
                search: function (event, ui) {
                },
                autoFocus: true,
                delay: 300,
                source: function (request, response) {

                    $.ajax({
                        url: url,
                        type: "POST",
                        dataType: "json",
                        data: { query: request.term, cobradorFilter: true },
                        success: function (data) {

                            var mappedData = $.map(data,
                                                 function (item) {

                                                     var arreglo = []
                                                     //$.each(item, function (key, value) {
                                                     //    if (!$.inArray(item.nombre,arreglo)) {
                                                     //        arreglo.push(item.nombre)
                                                     return {
                                                         label: item.nombre,
                                                         value: item.nombre,
                                                         id: item.id
                                                     };
                                                 }

                                                 //    })

                                                 //}
                                                 );
                            response(mappedData);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            nError("No se pudo encontrar el cobrador, asegúrese de haberlo agregado", "error");
                        }
                    })
                },
                minLength: 2,
                select: function (event, ui) {

                    $(selectorId).val(ui.item.id);
                    $(selectorId).change();

                }
            });
        }
        if (selectorId == '#clienteId') {
            
            var key = "personaId";
            $(this).autocomplete({
                search: function (event, ui) {
                },
                autoFocus: true,
                delay: 300,
                source: function (request, response) {
                    $.ajax({
                        url: url,
                        type: "POST",
                        dataType: "json",
                        data: { query: request.term },
                        success: function (data) {
                            var mappedData = $.map(data,
                              function (item) {
                                  return {
                                      label: item.nombre,
                                      value: item.nombre,
                                      id: item.id
                                  };
                              });
                            response(mappedData);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            //alert(textStatus);
                            //alert(errorThrown);
                        }
                    })
                },
                minLength: 2,
                select: function (event, ui) {
                    $(selectorId).val(ui.item.id);
                    $(selectorId).change();

                }
            });

        }


    });
});

//-------------------------------------------------------------------------

//En el controller, se debe devolver un json del tipo  return Json(new { text = string }, JsonRequestBehavior.AllowGet);

function ajaxExecute(url, parameter, action) {

    $.ajax({
        async: true,
        cache: false,
        type: 'POST',
        url: url + '/' + parameter,
        success: action
    });

}

function ajaxExecuteSincrona(url, parameter, action) {

    $.ajax({
        async: false,
        cache: false,
        type: 'POST',
        url: url + '/' + parameter,
        success: action
    });

}

function ajaxExecuteSincronaGet(url, parameter, action) {

    $.ajax({
        async: false,
        cache: false,
        type: 'GET',
        url: url + '/' + parameter,
        success: action
    });

}
//--------------------