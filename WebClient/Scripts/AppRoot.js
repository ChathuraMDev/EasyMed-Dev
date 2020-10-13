(function () {
    //Module
    app = angular.module('AppRoot', ["ngRoute"]);

    // Root data
    app.run(['$rootScope', function ($rootScope) {

        $rootScope.auth_domain = "https://localhost:44318";
        $rootScope.webapp_domain = "https://localhost:44356";
        $rootScope.client_domain = "https://localhost:44327";

        $rootScope.userName = "";
        $rootScope.userActualName = "";
        $rootScope.loginStatus = false;
        $rootScope.userRole = "";
        
    }])

    // Controllers and routings
    app.config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "/Views/Home/login.html",
                controller: "indexCtrl"
            })
            .when("/Home", {
                templateUrl: "/Views/Dashboard/home.html",
                controller: "homeCtrl"
            })
            .when("/register", {
                templateUrl: "/Views/Register/register.html",
                controller: "registerCtrl"
            })
            .otherwise({ redirectTo: '/' });
    });
            
    

    

})();