// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("SamuraiDojo");
    app.controller("MyProfileController", ["RequestService", function (RequestService) {
        var vm = this;
        vm.CurrentChallenge = "Angler of Time - hardcoded";

        var request = RequestService.SendRequest("/api/Player", null, "GET");
        request.Success(function (response) {
            vm.Player = response.data;
        });
        request.Error(function (error) {
            vm.Player = error.ExceptionMessage;
        });

        var allChallengesRequest = RequestService.SendRequest("/api/Challenge/All", null, "GET");
        allChallengesRequest.Success(function (response) {
            vm.Challenges = response.data;
        });
        allChallengesRequest.Error(function (error) {
            vm.Challenges = error.ExceptionMessage;
        });

        vm.HasParticipated = function () {
            var participated = false;
            if (request && request.Promise && !request.Promise.Resolved) {
                RequestService.Resolve(request).Then(function () {
                    participated = checkForParticipationHistory();
                });
            } else {
                participated = checkForParticipationHistory();
            }

            return participated;
        };

        var checkForParticipationHistory = function () {
            var count = 0;
            for (var i = 0; i < vm.Challenges.length; i++) {
                var challenge = vm.Challenges[i];
                for (var k = 0; k < challenge.Results.length; k++) {
                    var result = challenge.Results[k];
                    var player = result.Player;
                    if (player.Name === vm.Player.Name) {
                        count++;
                        break;
                    }
                }
            }

            return count > 0;
        };

        vm.ParticipatedInChallenge = function (challenge) {
            var result = false;
            if (request.Promise.Resolved) {
                result = participatedInChallenge(challenge);
            } else {
                RequestService.Resolve(request).Then(function () {
                    result = participatedInChallenge(challenge);
                });
            }

            return result;
        };

        var participatedInChallenge = function (challenge) {
            for (var i = 0; i < challenge.Results.length; i++) {
                if (challenge.Results[i].Player.Name === vm.Player.Name)
                    return true;
            }

            return false;
        };

    }]);

})();