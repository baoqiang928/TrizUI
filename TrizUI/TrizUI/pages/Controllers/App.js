﻿var myApp = angular.module("myApp", ["ui.router", "StoreService", "tm.pagination", "ui.tree", "ui.bootstrap", "ng.ueditor"]);
myApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.when("", "/ProjectList");
    $stateProvider
        .state("ProjectList", {
            url: "/ProjectList",
            templateUrl: "/pages/List.html",
            module: "tm.pagination",
            controller: "datepicker-Controller"
        })
       .state("ProjectAdd", {
           params: { "ID": null },
           url: "/ProjectAdd",
           templateUrl: "/pages/Project/ProjectOperate.html"
       })
        .state("UserList", {
            url: "/UserList",
            templateUrl: "/pages/User/UserList.html",
            module: "tm.pagination"
        })
       .state("UserAdd", {
           params: { "ID": null },
           url: "/UserAdd",
           templateUrl: "/pages/User/UserOperate.html"
       })
       .state("ResolveDetail", {
           url: "/ResolveDetail",
           templateUrl: "/pages/Conflict/ResolveDetail.html"
       })
       .state("QuestionDescriptionAdd", {
           url: "/QuestionAdd",
           templateUrl: "/pages/QuestionDescription/QuestionDescriptionOperate.html"
       })
        .state("AnalysisProcedureAdd", {
            params: { "ProcedureID": null },
            url: "/AnalysisProcedureAdd",
            templateUrl: "/pages/AnalysisProcedure/AnalysisProcedureOperate.html",
            controller: 'tree-Controller'
        })
       .state("AnalysisProcedureList", {
           url: "/AnalysisProcedureList",
           templateUrl: "/pages/AnalysisProcedure/AnalysisProcedureList.html"
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
       .state("ConflictResolveList", {
           url: "/ConflictResolveList",
           templateUrl: "/pages/ConflictResolve/ConflictResolveList.html",
           controller: 'tree-Controller'
       })
       .state("EvolveOperate", {
           url: "/EvolveOperate",
           templateUrl: "/pages/Evolve/EvolveOperate.html",
           controller: 'tree-Controller'
       })
        .state("StandardSolutionAndExamplesList", {
            url: "/StandardSolutionAndExamplesList",
            templateUrl: "/pages/StandardSolution/StandardSolutionAndExamplesList.html",
            controller: 'tree-Controller'
        })
        .state("TechConflictResolveDictionaryTree", {
            params: { "TreeTypeID": "1", "Title": "技术冲突解决方案维护" },
            url: "/TechConflictResolveDictionaryTree",
            templateUrl: "/pages/DictionaryTree/DictionaryTreeOpe.html"
        })
        .state("PhyConflictResolveDictionaryTree", {
            params: { "TreeTypeID": "2", "Title": "物理冲突解决方案维护" },
            url: "/PhyConflictResolveDictionaryTree",
            templateUrl: "/pages/DictionaryTree/DictionaryTreeOpe.html"
        })
        .state("Solution", {
            url: "/Solution",
            templateUrl: "/pages/Solution/StandardSolutionList.html"
        })
        .state("SolutionADD", {
            params: { "ID": null },
            url: "/SolutionADD",
            templateUrl: "/pages/Solution/StandardSolutionOperate.html"
        })
        .state("TechConflictResolveOpe", {
            params: { "ConflictID": null, "ConflictType": "技术", "TreeTypeID": "1" },
            url: "/ConflictResolveOpe",
            templateUrl: "/pages/ConflictResolve/ConflictResolveOpe.html"
        })
        .state("PhyConflictResolveOpe", {
            params: { "ConflictID": null, "ConflictType": "物理", "TreeTypeID": "2" },
            url: "/ConflictResolveOpe",
            templateUrl: "/pages/ConflictResolve/ConflictResolveOpe.html"
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
    //var ApiUrl = "http://101.201.67.155:81/api/";
    var request = {
        method: 'POST',
        url: '',
        headers: { 'Content-Type': 'application/json;charset=utf-8' },
        data: {}
    };
    var postData = {
        lists: function (resource, params) {
            request.method = "get";
            request.params = params;
            request.data = {};
            request.url = ApiUrl + resource;
            return requestService($http, $q, request);
        },
        add: function (resource, data) {
            request.method = "post";
            request.url = ApiUrl + resource;
            request.params = {};
            request.data = data;
            return requestService($http, $q, request);
        },
        update: function (resource, data) {
            request.method = "put";
            request.url = ApiUrl + resource;
            request.params = {};
            request.data = data;
            return requestService($http, $q, request);
        },
        updateMutiple: function (resource, param) {
            request.method = "put";
            request.url = ApiUrl + resource + "/?" + param;
            request.params = {};
            request.data = {};
            return requestService($http, $q, request);
        },
        delete: function (resource, id) {
            request.method = "delete";
            request.url = ApiUrl + resource + "/" + id;
            request.params = {};
            request.data = {};
            return requestService($http, $q, request);
        },
        batchdelete: function (resource, ids) {
            request.method = "delete";
            request.url = ApiUrl + resource + "/?ids=" + ids;
            request.params = {};
            request.data = {};
            return requestService($http, $q, request);
        },
        getobj: function (resource, id) {
            request.method = "get";
            request.url = ApiUrl + resource + "/" + id;
            request.params = {};
            request.data = {};
            return requestService($http, $q, request);
        },

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


//=========本地存储数据服务============
myApp.factory('locals', ['$window', function ($window) {
    return {        //存储单个属性
        set: function (key, value) {
            $window.localStorage[key] = value;
        },        //读取单个属性
        get: function (key, defaultValue) {
            return $window.localStorage[key] || defaultValue;
        },        //存储对象，以JSON格式存储
        setObject: function (key, value) {
            $window.localStorage[key] = JSON.stringify(value);//将对象以字符串保存
        },        //读取对象
        getObject: function (key) {
            return JSON.parse($window.localStorage[key] || '{}');//获取字符串并解析成对象
        }

    }
}]);