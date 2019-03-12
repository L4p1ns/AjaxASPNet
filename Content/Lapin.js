//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
});
//Load Data function
function loadData() {
    $.ajax({
        url: "/Lapins/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.nomlapalin + '</td>';
                html += '<td>' + item.age + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.id + ')">Edit</a> | <a href="#" onclick="return Delele(' + item.id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Add Data Function
function Add() {
    
    var lpnsObj = {
        id: $('#id').val(),
        nomlapalin: $('#nomlapalin').val(),
        age: $('#age').val(),
        
    };
    $.ajax({
      
        url: "/Lapins/Add",
        data: JSON.stringify(lpnsObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function getbyID(lpnID) {
   
    $.ajax({
        url: "/Lapins/GetbyID/" + lpnID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            alert(result);
            $('#id').val(result.id);
            $('#nomlapalin').val(result.nomlapalin);
            $('#age').val(result.age);
           
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
//function for updating employee's record
function Update() {

    var lpnObj = {
        id: $('#id').val(),
        nomlapalin: $('#nomlapalin').val(),
        age: $('#age').val(),
      
    };
    $.ajax({
        url: "/Lapins/Update",
        data: JSON.stringify(lpnObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#id').val("");
            $('#nomlapalin').val("");
            $('#age').val("");
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting employee's record
function Delele(id) {
    var ans = confirm("Voulez vous supprimer?");
    if (ans) {
        $.ajax({
            url: "/Lapins/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}