angular.module("myApp")
    .controller('datepicker-Controller', function ($scope) {


        $('.date-picker').datepicker({ autoclose: true }).next().on(ace.click_event, function () {
            $(this).prev().focus();
        });

    });