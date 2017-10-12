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
       .state("QuestionDescriptionAdd", {
           url: "/QuestionAdd",
           templateUrl: "/pages/QuestionDescription/QuestionDescriptionOperate.html"
       })
        .state("StandardSolutionAdd", {
            url: "/StandardSolutionAdd",
            templateUrl: "/pages/StandardSolution/StandardSolutionOperate.html",
            controller: 'tree-Controller'
        })
       .state("QuestionAnalyseAdd", {
           url: "/AnalyseAdd",
           templateUrl: "/pages/QuestionAnalyse/QuestionAnalyseOperate.html"
       })
       .state("FunctionAnalyseAdd", {
           url: "/FunctionAnalyseAdd",
           templateUrl: "/pages/FunctionAnalyse/FunctionAnalyseOperate.html",
           controller: 'tree-Controller'
       })
       .state("StandardSolutionList", {
           url: "/StandardSolutionList",
           templateUrl: "/pages/StandardSolution/StandardSolutionList.html"
       })
       .state("CauseEffectAdd", {
           url: "/CauseEffectAdd",
           templateUrl: "/pages/CauseEffect/CauseEffectOperate.html"
       })
       .state("PhysicalConflictList", {
           url: "/PhysicalConflictList",
           templateUrl: "/pages/Conflict/PhysicalConflictList.html"
       })
       .state("TechConflictList", {
           url: "/TechConflictList",
           templateUrl: "/pages/Conflict/TechConflictList.html"
       })
       .state("TechConflictResolveList", {
           url: "/TechConflictResolveList",
           templateUrl: "/pages/Conflict/TechConflictResolveList.html",
           controller: 'tree-Controller'
       })
       .state("PhysicalConflictResolveList", {
           url: "/PhysicalConflictResolveList",
           templateUrl: "/pages/Conflict/PhysicalConflictResolveList.html",
           controller: 'tree-Controller'
       })
       .state("EvolveList", {
           url: "/EvolveList",
           templateUrl: "/pages/Evolve/EvolveList.html",
           controller: 'tree-Controller'
       })
       .state("EvolveOperate", {
           url: "/EvolveOperate",
           templateUrl: "/pages/Evolve/EvolveOperate.html",
           controller: 'tree-Controller'
       })
       .state("PageTab.Page1", {
           url: "/Page1",
           templateUrl: "/pages/Page1.html"
       })
       .state("PageTab.Page2", {
           url: "/Page2",
           templateUrl: "/pages/Page2.html"
       })
       .state("Page3", {
           url: "/Page3",
           templateUrl: "/pages/Page3.html"
       });
});

