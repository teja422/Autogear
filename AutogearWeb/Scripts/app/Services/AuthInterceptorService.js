(function () {
    "use strict";
    angular.module("Autogear.Services").
        factory("authInterceptorService", ["$q", "$injector", "localStorageService", function ($q, $injector, localStorageService) {

            var request = function (config) {

                config.headers = config.headers || {};

                var authData = localStorageService.get("authorizationData");
                if (authData) {
                    config.headers.Authorization = "Bearer " + authData.token;
                }

                return config;
            }

            var responseError = function (rejection) {
                if (rejection.status === 401) {
                    var stateService = $injector.get("$state");
                    stateService.go("Login");
                }
                return $q.reject(rejection);
            }
            var authInterceptorServiceFactory = {
                request: request,
                responseError: responseError
            };

            return authInterceptorServiceFactory;
        }]);
})();