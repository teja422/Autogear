(function () {
    "use strict";
    var core = angular.module("Autogear.Core", ["ui-router","ui.bootstrap"]);
    core.config(["$stateProvider", "$urlRouterProvider", "$httpProvider", function ($stateProvider, $urlRouterProvider, $httpProvider) {
        //Routing 
        $stateProvider
            .state("/", {
                url: "/",
                views: {
                    content: { templateUrl: "/Scripts/app/layout/Splash.html", controller: "SplashController" }
                }
            });
        $urlRouterProvider.otherwise("/");
        $httpProvider.interceptors.push("authInterceptorService");
    }]);
});