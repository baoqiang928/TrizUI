angular.module("myApp")
    .controller('tree-Controller', function ($scope) {
        
        $('.dd').nestable();

        $('.dd-handle a').on('mousedown', function (e) {
            e.stopPropagation();
        });

        $('[data-rel="tooltip"]').tooltip();

    });