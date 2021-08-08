window.$ = window.jQuery = require('jquery');
require('datatables.net-bs4')(window, $);

import "./../../styles/pages/users.scss";

document.addEventListener("DOMContentLoaded", function () {
  const STATUS_COLUMN = 4;
  const GROUP_COLUMN = 5;
  const ACTIONS_COLUMN = 7;

  $("#users-table-multi").DataTable({
    responsive: true,
    select: {
      style: "multi"
    },
    order: [STATUS_COLUMN, "asc"],
    columnDefs: [
      {
        targets: ACTIONS_COLUMN,
        orderable: false
      }
    ],
    initComplete: function () {
      this.api().columns([STATUS_COLUMN, GROUP_COLUMN]).every(function () {
        var column = this;
        var select = $('<select><option value=""></option></select>')
            .appendTo($(column.header()).empty())
            .on('change', function () {
              var val = $.fn.dataTable.util.escapeRegex(
                  $(this).val()
              );

              column
                  .search(val ? '^' + val + '$' : '', true, false)
                  .draw();
            });

        column.data().unique().sort().each(function (d, j) {
          select.append('<option value="' + d + '">' + d + '</option>')
        });
      });
    }
  });
});
