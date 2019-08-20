// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("SamuraiDojo");
    app.controller("AwardsController", ["RequestService", function (RequestService) {
        var vm = this;

        vm.Awards = [];

        var awardsRequest = RequestService.SendRequest("/api/Awards", null, "GET");
        awardsRequest.Success(function (response) {
            vm.Awards = response.data;
        });

    }]);

})();