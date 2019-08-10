// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("SamuraiDojo");
    app.controller("HomePageController", ["RequestService", function (RequestService) {
        var vm = this;
        vm.CurrentChallenge = "Angler of Time - hardcoded";

        var request = RequestService.SendRequest("/api/MyProfile", null, "GET");
        request.Success(function (response) {
            vm.Player = response.data;
        });
        request.Error(function (error) {
            vm.Player = error.ExceptionMessage;
        });

    }]);

})();