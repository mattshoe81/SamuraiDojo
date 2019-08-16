// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("SamuraiDojo");
    app.controller("MyProfileController", ["RequestService", function (RequestService) {
        var vm = this;
        vm.CurrentBattle = "Angler of Time - hardcoded";

        var request = RequestService.SendRequest("/api/Player", null, "GET");
        request.Success(function (response) {
            vm.Player = response.data;
        });
        request.Error(function (error) {
            vm.Player = error.ExceptionMessage;
        });

        var allBattlesRequest = RequestService.SendRequest("/api/Battle/All", null, "GET");
        allBattlesRequest.Success(function (response) {
            vm.Battles = response.data;
        });
        allBattlesRequest.Error(function (error) {
            vm.Battles = error.ExceptionMessage;
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

        vm.GetSenseiCount = function (player, battles) {
            var count = 0;
            if (battles) {
                for (var i = 0; i < battles.length; i++) {
                    if (battles[i].Sensei.Name.toUpperCase() === player.Name.toUpperCase())
                        count++;
                }
            }

            return count;
        };

        vm.IsSensei = function (battle, player) {
            if (battle && player) {
                var sensei = battle.Sensei.Name.toUpperCase();
                var playerName = player.Name.toUpperCase();

                return sensei === playerName;
            }

            return false;
        };

        var checkForParticipationHistory = function () {
            var count = 0;
            for (var i = 0; i < vm.Battles.length; i++) {
                var battle = vm.Battles[i];
                for (var k = 0; k < battle.Results.length; k++) {
                    var result = battle.Results[k];
                    var player = result.Player;
                    if (player.Name === vm.Player.Name) {
                        count++;
                        break;
                    }
                }
            }

            return count > 0;
        };

        vm.GetPointsFromBattle = function (battle, player) {
            var points = 0;
            if (player) 
                points = getPointsFromBattle(battle);

            return points;
        };

        var getPointsFromBattle = function (battle) {
            var points = 0;
            for (var i = 0; i < battle.Results.length; i++) {
                var player = battle.Results[i].Player;
                if (player.Name === vm.Player.Name)
                    points = battle.Results[i].Points;
            }

            return points;
        }

        vm.ParticipatedInBattle = function (battle) {
            var result = false;
            if (request.Promise.Resolved) {
                result = participatedInBattle(battle);
            } else {
                RequestService.Resolve(request).Then(function () {
                    result = participatedInBattle(battle);
                });
            }

            return result;
        };

        var participatedInBattle = function (battle) {
            for (var i = 0; i < battle.Results.length; i++) {
                if (battle.Results[i].Player.Name === vm.Player.Name)
                    return true;
            }

            return false;
        };

    }]);

})();