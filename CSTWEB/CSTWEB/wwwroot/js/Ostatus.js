var dtble;
$(document).ready(function () {
    loaddata();
}); 
function   () {
    dtble = $("#mytable").DataTable({
        "ajax": {
            "url": "/Admin/Ostatus/GetData"
 
        },
        "columns": [
            { "data": "name" },
            { "data": "id" }

        ]
    });
}