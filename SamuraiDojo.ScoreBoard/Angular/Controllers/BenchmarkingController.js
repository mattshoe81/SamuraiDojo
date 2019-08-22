// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("SamuraiDojo");
    app.controller("BenchmarkingController", ["RequestService", function (RequestService) {
        var vm = this;

        var request = RequestService.SendRequest("/api/Benchmarking", null, "GET");
        request.Success(function (response) {
            vm.BenchmarkData = response.data;
        });
        request.Error(function (error) {
            vm.BenchmarkData = error.ExceptionMessage;
        });
        

    }]);

})();