var _customerId = "";
var urlAction = window.location.protocol + "//" + window.location.host+"/Orders/" ;
$(document).ready(function () {
    $("button").on("click", function (event) {
        Actions(this);
    });
    $("form").keypress(function (e) {
        if (e.which == 13) {
            return false;
        }
    });
    $("form").on("submit", function (e) {
        //Se serializa el formulario y se envia a un methodo por post utilizando ajax
        e.preventDefault();
        var valForm = $("#" + this.id).serialize();
        SaveDataOrder(valForm);
    });
    InitControls();
});

function InitControls() {
    var date = FormatDateToString(Date.now().toString(), true);
    $("#OrderDate").val(date);
    $("#RequiredDate").val(date);
}


function Actions(objt) {
    switch (objt.title) {
        case 'Nueva Orden':
            SaveOrder();
            break;
        case 'Eliminar Selección':
            SelectedOrders();
            break;
        case 'Editar Order':
            EditOrder(objt.id);
            break;
        //case 'Guardar Orden':
        //    SaveDataOrder();
        //    break;
        default:
            break;
    }
}
function ExecuteActionLink(objt) {
    Actions(objt);
}
function SelectedValue(ddlfObject) {
    var selectedValue = ddlfObject.value;
    var selectedText = ddlfObject.options[ddlfObject.selectedIndex].innerHTML;
    getCompanies(selectedValue);
}

function getCompanies(_country) {
    clearTableOrders();
    $.ajax({
        type: "GET",
        url: urlAction +'GetCompanies',
        data: { country: _country },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (resp) {
            if (resp.ExistError == false) {
                var strghtml = '';
                $.each(resp.Companies, function (index, value) {
                    strghtml += '<tr class="selectrow trboder" id="' + value.Id + '" onclick="SelectedValCompany(this.id)" title="Consulta ordenes dando clic sobre el cliente">';
                    strghtml += '<td>' + value.CompanyName + '</td>';
                    strghtml += '<td>' + value.ContactName + '</td>';
                    strghtml += '</tr>';
                });
                $("#tbodyClients").html(strghtml);

            } else {
                alert(resp.Error);
            }
        },
        error: function () {
            alert("Error");
        }
    });
}

function selectedClient() {
    $("#tbodyClients tr").removeClass("active-client");
    $("#" + _customerId).addClass("active-client");
}

function SelectedValCompany(id) {
    _customerId = id;
    selectedClient();
    $.ajax({
        type: "GET",
        url: urlAction + 'GetOrders',
        data: { customer: _customerId },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (resp) {
            if (resp.ExistError == false) {
                var strghtml = '';
                var sumSubtotal = 0;
                $.each(resp.Orders, function (index, value) {
                    strghtml += '<tr id="tra' + value.Id + '" class="trboder selectorder">';
                    strghtml += '<td><input type="checkbox" id="ch' + value.Id + '" value=""></td>';
                    strghtml += '<td>' + value.Id + '</td>';
                    strghtml += '<td>' + value.CustomerID + '</td>';
                    strghtml += '<td>' + value.FirstName + '</td>';
                    strghtml += '<td>' + FormatDateToString(value.OrderDate); + '</td>';
                    strghtml += '<td>' + FormatDateToString(value.RequiredDate);  + '</td>';
                    strghtml += '<td>' + value.ShipCity + '</td>';
                    strghtml += '<td>' + value.Freight + '</td>';
                    strghtml += '<td><a id="a' + value.Id + '" href="javascript: void(0)" onclick="ExecuteActionLink(this)" title="Editar Order">Editar</a></td>';
                    strghtml += '</tr>';
                    sumSubtotal = sumSubtotal + value.Freight;
                });
                if (resp.Orders.length > 0) {
                    strghtml += '<tr>';
                    strghtml += '<td></td>';
                    strghtml += '<td></td>';
                    strghtml += '<td></td>';
                    strghtml += '<td></td>';
                    strghtml += '<td></td>';
                    strghtml += '<td></td>';
                    strghtml += '<td class="thboder-total">Total</td>';
                    strghtml += '<td class="thboder-total">$' + sumSubtotal.toFixed(2) + '</td>';
                    strghtml += '<td></td>';
                    strghtml += '</tr>';
                }
                $("#tbodyOrders").html(strghtml);

            } else {
                alert(resp.Error);
            }
        },
        error: function () {
            alert("Error get data");
        }
    });
}


function EditOrder(idOrder) {
    var objtr = $("#tr" + idOrder);
    var freight, customerId;
    $(objtr).children("td").each(function (cont) {
        switch (cont) {
            case 2:
                var objeto = $(this);
                var objtd = objeto[0];
                customerId = objtd.innerText;
                break;
            case 7:
                var objeto = $(this);
                var objtd = objeto[0];
                freight = objtd.innerText;
                break;
        }
    });
    $("#inputFreightE").val(freight);
    $("#inputOrderId").val(idOrder.replace("a", ""));
    $("#inputCustomerId").val(customerId);
    $('#editFreightModal').modal('show');
}

function UpdateFreight() {
    //Codigo para Actualizar el dato de Freight
}

function SaveOrder() {    
    if (_customerId == "") {
        alert("Por favor seleccione un cliente");
        return;
    }
    $('#newOrderModal').modal('show');
}

function SelectedOrders() {
    var listIdOrders = new Array();
    $("#tOrders tbody tr").each(function (index) {
        $(this).children("td").each(function (cont) {
            switch (cont) {
                case 0:
                    var objeto = $(this);
                    for (var i = 0; i < objeto.length; i++) {
                        var node = objeto[i].children;
                        for (var z = 0; z < node.length; z++) {
                            var obt = node[z];
                            if (obt.nodeName == "INPUT") {
                                if (obt.checked) {
                                    listIdOrders.push(obt.id.replace("ch", ""));
                                    obt.checked = false;
                                }
                            }
                        }
                    }
                    break;
            }
        });
    });

}

function DeleteOrders(listIdOrders) {
    //Utilizar un metodo el cual reciba los datos de Id de Ordenes
    //Se puede utilizar con ajax
    console.log(listIdOrders);
}

function SaveDataOrder(valForm) {
    $.ajax({
        type: "POST",
        url: urlAction + 'SaveOrder',
        data: { Order : valForm } ,
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (resp) {
            if (resp.ExistError == false) {

            } else {
                alert(resp.Error);
            }
        },
        error: function () {
            alert("Error save data");
        }
    });
}


function filterFloat(evt, input) {
    var key = window.Event ? evt.which : evt.keyCode;
    var chark = String.fromCharCode(key);
    var tempValue = input.value + chark;
    if (key >= 48 && key <= 57) {
        if (filter(tempValue) === false) {
            return false;
        } else {
            return true;
        }
    } else {
        if (key == 8 || key == 13 || key == 0) {
            return true;
        } else if (key == 46) {
            if (filter(tempValue) === false) {
                return false;
            } else {
                return true;
            }
        } else {
            return false;
        }
    }
}
function filter(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,2})$/;
    if (preg.test(__val__) === true) {
        return true;
    } else {
        return false;
    }

}

function clearTableOrders() {
    var strghtml = '<tr>';
    strghtml += '<td></td>';
    strghtml += '<td></td>';
    strghtml += '<td></td>';
    strghtml += '<td></td>';
    strghtml += '<td></td>';
    strghtml += '<td></td>';
    strghtml += '<td class="thboder-total">Total</td>';
    strghtml += '<td class="thboder-total">$</td>';
    strghtml += '<td></td>';
    strghtml += '</tr>';
    $("#tbodyOrders").html(strghtml);
}

function FormatDateToString(_date, byInput=false) {
    var dateToString;     
    let strDate = _date.replace(/\D/g, "");
    let d = new Date(parseInt(strDate)).toISOString().slice(0, 10);
    var listDate = d.split("-");
    if (byInput == true) {
        if (listDate.length == 3) {
            dateToString = d;
        }
    } else {
        if (listDate.length == 3) {
            dateToString = listDate[2] + "/" + listDate[1] + "/" + listDate[0];
        }
    }
    return dateToString;
}
