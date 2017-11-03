angular.module("myApp")
    .controller('table-Controller', function ($scope) {
        alert(3);
        var oTable1 = $('#sample-table-2').dataTable({
            "aoColumns": [
              { "bSortable": false },
              { "bSortable": false }, { "bSortable": false }, { "bSortable": false }, { "bSortable": false }, { "bSortable": false },
              { "bSortable": false }
            ]
        });


        $('table th input:checkbox').on('click', function () {
            var that = this;
            $(this).closest('table').find('tr > td:first-child input:checkbox')
            .each(function () {
                this.checked = that.checked;
                $(this).closest('tr').toggleClass('selected');
            });

        });


        $('[data-rel="tooltip"]').tooltip({ placement: tooltip_placement });
        function tooltip_placement(context, source) {
            var $source = $(source);
            var $parent = $source.closest('table')
            var off1 = $parent.offset();
            var w1 = $parent.width();

            var off2 = $source.offset();
            var w2 = $source.width();

            if (parseint(off2.left) < parseint(off1.left) + parseint(w1 / 2)) return 'right';
            return 'left';
        }



    });