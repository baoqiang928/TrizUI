var myApp = angular.module("myApp", ["ui.router"]);
myApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.when("", "/PageTab");
    $stateProvider
        .state("PageTab", {
           url: "/PageTab",
           templateUrl: "/pages/List.html",
           controller: 'table-Controller'
        })
       .state("ProjectAdd", {
           url: "/ProjectAdd",
           templateUrl: "/pages/Project/ProjectOperate.html"
       })
       .state("PageTab.Page1", {
           url:"/Page1",
           templateUrl: "/pages/Page1.html"
       })
       .state("PageTab.Page2", {
           url:"/Page2",
           templateUrl: "/pages/Page2.html"
       })
       .state("Page3", {
           url:"/Page3",
           templateUrl: "/pages/Page3.html"
       });
});

