﻿// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("SamuraiDojo");
    app.controller("HomePageController", ["RequestService",  function (RequestService) {
        var vm = this;
        vm.CurrentChallenge = {};

        var playerRequest = RequestService.SendRequest("/api/Player", null, "GET");
        playerRequest.Success(function (response) {
            vm.Player = response.data;
        });
        playerRequest.Error(function (error) {
            vm.Player = error.ExceptionMessage;
        });

        var allPlayersRequest = RequestService.SendRequest("/api/Player/All", null, "GET");
        allPlayersRequest.Success(function (response) {
            vm.AllPlayers = response.data;
        });
        allPlayersRequest.Error(function (error) {
            vm.AllPlayers = error.ExceptionMessage;
        });

        var currentChallengeRequest = RequestService.SendRequest("/api/Challenge", null, "GET");
        currentChallengeRequest.Success(function (response) {
            vm.CurrentChallenge = response.data;
        });
        currentChallengeRequest.Error(function (error) {
            vm.CurrentChallenge = error.ExceptionMessage;
        });

    }]);

})();