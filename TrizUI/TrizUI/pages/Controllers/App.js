var myApp = angular.module("myApp", ["ui.router", "StoreService", "tm.pagination"]);
myApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.when("", "/ProjectList");
    $stateProvider
        .state("ProjectList", {
            url: "/ProjectList",
            templateUrl: "/pages/List.html",
            module: "tm.pagination",
            controller: 'table-Controller'
        })
       .state("ProjectAdd", {
           url: "/ProjectAdd",
           templateUrl: "/pages/Project/ProjectOperate.html"
       })
       .state("ResolveDetail", {
           url: "/ResolveDetail",
           templateUrl: "/pages/Conflict/ResolveDetail.html"
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
        .state("ConflictList", {
            url: "/ConflictList",
            templateUrl: "/pages/Conflict/ConflictList.html",
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



//服务
var StoreService = angular.module('StoreService', []);
//请求服务
StoreService.factory('requestService', function ($http, $q) {

    var ApiUrl = "http://localhost:2072/api/";
    var request = {
        method: 'POST',
        url: '',
        headers: { 'Content-Type': 'application/json' },
        data: {}
    };
    var postData = {
        lists: function (type) {
            request.method = "get";
            request.url = ApiUrl + "products/" + type + "";
            return requestService($http, $q, request);
        },
        submit_product: function (data) {
            request.method = "post";
            request.url = ApiUrl + "products";
            request.data = data;
            return requestService($http, $q, request);
        }
    };
    return postData;
});

function requestService($http, $q, request) {
    var deferred = $q.defer(); // 声明延后执行，表示要去监控后面的执行  
    $http(request).
    success(function (data, status, headers, config) {
        deferred.resolve(data);  // 声明执行成功，即http请求数据成功，可以返回数据了  
    }).
    error(function (data, status, headers, config) {
        deferred.reject(data);   // 声明执行失败，即服务器返回错误  
    });
    return deferred.promise;   // 返回承诺，这里并不是最终数据，而是访问最终数据的API  
};
