// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("Services");

    app.factory("RequestService", ["$http", "$q", function ($http, $q) {
        function RequestDispatcher(request, onSuccess, onError) {
            var response = {};
            response.Promise = $http(request);
            response.Success = function (callback) {
                response.successCallback = callback;
            };
            response.Error = function (callback) {
                response.errorCallback = callback;
            };
            response.Failure = function (callback) {
                response.failureCallback = callback;
            };

            response.Promise.then(
                function (data) {
                    if (onSuccess)
                        onSuccess(data);
                    if (response.successCallback)
                            response.successCallback(data);
                },
                function (data, status) {
                    if (onError)
                        onError(data, status);
                    if (response.errorCallback)
                        response.errorCallback(data, status);
                }
            );

            return response;
        }

        var setPayload = function (request, data) {
            if (data) {
                if (request.method.toUpperCase() === "GET")
                    request.params = data;
                else
                    request.data = data;
            }
            
        };

        var buildRequest = function (url, data, method) {
            if (!method)
                method = "POST";

            var request = {
                method: method,
                url: url
            };
            setPayload(request, data);

            return request;
        };

        var sendRequest = function (url, data, method) {
            var request = buildRequest(url, data, method);
            var response = new RequestDispatcher(request);

            return response;
        };

        var resolve = function (promises) {
            var response = {};
            response.Then = function (callback) {
                response.resolved = callback;
            };

            $q.all(promises).then(function () {
                response.resolved();
            });

            return response;
        };

        return {
            SendRequest: sendRequest,
            Resolve: resolve
        };

    }]);

})();