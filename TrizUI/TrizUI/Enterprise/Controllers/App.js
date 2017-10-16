var myApp = angular.module("myApp", ["ui.router"]);
myApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.when("", "/Profile");
    $stateProvider
        .state("Profile", {
            url: "/Profile",
            templateUrl: "/Enterprise/Profile/ProfileList.html",
            controller: 'table-Controller'
        })
       .state("TalentList", {
           url: "/TalentList",
           templateUrl: "/Enterprise/Talent/TalentList.html"
       })
       .state("JobDetail", {
           url: "/JobDetail",
           templateUrl: "/Talent/Personnel/JobRequest/JDDetail.html"
       })
       .state("CompanyDetail", {
           url: "/CompanyDetail",
           templateUrl: "/Talent/Personnel/JobRequest/CompanyDetail.html"
       })
       .state("TechRequestDetail", {
           url: "/TechRequestDetail",
           templateUrl: "/Talent/Personnel/TechRequest/TechRequestDetail.html"
       })
       .state("TechList", {
           url: "/TechList",
           templateUrl: "/Enterprise/Tech/TechList.html"
       })
        .state("Favorite", {
            url: "/Favorite",
            templateUrl: "/Talent/Personnel/Favorite/FavoriteList.html"
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

