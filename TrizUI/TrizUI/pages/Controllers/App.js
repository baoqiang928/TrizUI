var myApp = angular.module("myApp", ["ui.router"]);
myApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.when("", "/ProjectList");
    $stateProvider
        .state("ProjectList", {
            url: "/ProjectList",
           templateUrl: "/pages/List.html",
           controller: 'table-Controller'
        })
       .state("ProjectAdd", {
           url: "/ProjectAdd",
           templateUrl: "/pages/Project/ProjectOperate.html"
       })
       .state("QuestionAdd", {
           url: "/QuestionAdd",
           templateUrl: "/pages/Question/QuestionOperate.html"
       })
       .state("AnalyseAdd", {
           url: "/AnalyseAdd",
           templateUrl: "/pages/Analyse/AnalyseOperate.html"
       })
       .state("CauseEffectAdd", {
           url: "/CauseEffectAdd",
           templateUrl: "/pages/CauseEffect/CauseEffectOperate.html"
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

