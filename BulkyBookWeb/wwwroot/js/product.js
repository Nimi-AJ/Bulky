﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "covertype.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `

                   <div class="w-85 btn-group" role="group">
                       <a class="btn btn-primary mx-2" href="/Admin/Product/Upsert?id=${data}"><i class="bi bi-pencil-square"></i>Edit</a>
                   </div>


                   <div class="w-85 btn-group " role="group">
                       <a class="btn btn-danger mx-2" href="/Admin/Product/Delete?id=${data}" ><i class="bi bi-trash3-fill"></i>Delete</a>
                   </div>
 
                          
                        `
                    
                },
            }
        ]
    });
}