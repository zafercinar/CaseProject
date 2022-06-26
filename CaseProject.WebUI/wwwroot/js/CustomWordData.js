$(document).ready(function () {
    var table = $('#wordDatatable').DataTable(
        {
            language: {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            },
            ajax: {
                url: "Word/GetWordList",
                type: "POST",
            },
            processing: true,
            serverSide: true,
            filter: true,
            columns: [
                { data: "text", name: "text" }
            ],
            aaSorting: [[0, 'desc']]
        }
    );

    setInterval(function () {
        table.ajax.reload();
    }, 3000);
});