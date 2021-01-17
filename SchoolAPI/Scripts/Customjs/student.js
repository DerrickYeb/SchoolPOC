var dataTable;

$(document).ready(function () {
    loadDataTable();
});

const loadDataTable = () => {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            
            "url": "/Student/Index"
        },
        "columns": [
            { "data": "firstname", "width": "15%" },
            { "data": "lastname", "width": "15%" },
            { "data": "class", "width": "15%" },
            { "data": "guidean", "width": "15%" },
            { "data": "guideancontact", "width": "15%" },
            { "data": "academicyear", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                <div class="text-center">
                 <a href="/Student/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                <i class="fas fa-edit"></i>
                  </a>
                <a onclick=Delete("/Student/Delete/${data}") class="btn btn-danger text-white">
                 <i class="fas fa-trash"></i>
             </a>

            </div>
                    `;
                }, "width": "40%"
            }
        ]
    })
}
const Delete = (url) => {
    swal({
        title: "Are you sure want to delete?",
        text: "You will not be able to restore the data",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    });
}
