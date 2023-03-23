// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    DoDataTable();
});

//function DoDataTable(tableClass, fileName, pageSize) {
//    var table = $(tableClass).DataTable({
//        dom: 'lBfrtip',
//        buttons: [
//            {
//                extend: 'excel',
//                title: fileName,
//                exportOptions: {
//                    columns: "th:not(:first-child)" // Excluir la primera columna
//                }
//            },
//            {
//                extend: 'pdf',
//                title: fileName,
//                exportOptions: {
//                    columns: "th:not(:first-child)" // Excluir la primera columna
//                }
//            }
//        ],
//        initComplete: function () {
//            // Estilo de los botones
//            $('.dt-buttons').css('float', 'right');
//            $('.dt-buttons').css('clear', 'none');

//            $('.buttons-excel').addClass('btn btn-default m-l-10');
//            $('.buttons-excel').removeClass('dt-button');
//            $('.buttons-excel').html('<i class="fas fa-file-excel"></i> Excel');

//            $('.buttons-pdf').addClass('btn btn-default m-l-5');
//            $('.buttons-pdf').removeClass('dt-button');
//            $('.buttons-pdf').html('<i class="fas fa-file-pdf"></i> PDF');

//            $('.dataTables_length').css('float', 'left');
//        },
//        "lengthChange": true,
//        "aaSorting": [], // Sin orden
//        "aLengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
//        "pageLength": pageSize,
//        "language": {
//            "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
//        }
//    });

//    return table;
//}

function DoDataTable() {
    var table = $('.dataTable').DataTable({
        dom: 'lBfrtip',
        buttons: [
            'excelHtml5'  
        ],
        initComplete: function () {
            // Estilo de los botones
            $('.dt-buttons').css('float', 'right');
            $('.dt-buttons').css('clear', 'none');

            $('.buttons-excel').addClass('btn btn-default m-l-10');
            $('.buttons-excel').removeClass('dt-button');
            $('.buttons-excel').html('<i class="fas fa-file-excel"></i> Excel');

            $('.buttons-pdf').addClass('btn btn-default m-l-5');
            $('.buttons-pdf').removeClass('dt-button');
            $('.buttons-pdf').html('<i class="fas fa-file-pdf"></i> PDF');

            $('.dataTables_length').css('float', 'left');
        },
        "lengthChange": true,
        "aaSorting": [], // Sin orden
        "aLengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        "pageLength": 10,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
        }
    });
}

function DoAceCodeEditor() {
    if ($(".AceCodeEditor ").length === 0) {
        return false;
    }

    AUI().ready('aui-ace-editor', function (A) {
        var codeEditors = document.querySelectorAll(".AceCodeEditor");
        for (i = 0; i < codeEditors.length; i++) {
            let id = codeEditors[i].id;

            let editor = new A.AceEditor({
                boundingBox: '#' + id,
                // highlightActiveLine: false,
                readOnly: $('#' + id).attr("data-readonly") === 'true',
                // tabSize: 8,
                // useSoftTabs: true,
                // useWrapMode: true,
                // showPrintMargin: false,
                mode: $('#' + id).attr("data-type"),
                value: $('#' + id).attr("data-for")
            }).render();

            //editor.getEditor().setTheme('ace/theme/cobalt');

             editor.set('mode', 'javascript');
            // editor.set('mode', 'json');
            // editor.set('mode', 'xml');

            let input = $('input[id*="' + id + '"]');
            input.val(editor.getSession().getValue());

            editor.getSession().on('change', function () {
                input.val(editor.getSession().getValue());
            });
        }
    });
}


function DoAceEditor() {
    "use strict";

    var codeEditors = document.querySelectorAll(".ace-editor");
    
    for (let i = 0; i < codeEditors.length; i++) {
        let id = codeEditors[i].id;

        var editor = ace.edit(id);
        editor.setTheme("ace/theme/sqlserver");
        //editor.getSession().setMode("ace/mode/xml");
    }
}


