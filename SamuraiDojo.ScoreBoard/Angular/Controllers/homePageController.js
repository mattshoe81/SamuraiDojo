// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("SamuraiDojo");
    app.controller("HomePageController", ["RequestService",  function (RequestService) {
        var vm = this;
        vm.CurrentBattle = {};
        vm.Battles = [];

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

        var currentBattleRequest = RequestService.SendRequest("/api/Battle", null, "GET");
        currentBattleRequest.Success(function (response) {
            vm.CurrentBattle = response.data;
        });
        currentBattleRequest.Error(function (error) {
            vm.CurrentBattle = error.ExceptionMessage;
        });
        
        var allBattlesRequest = RequestService.SendRequest("/api/Battle/All", null, "GET");
        allBattlesRequest.Success(function (response) {
            vm.Battles = response.data;
        });
        allBattlesRequest.Error(function (error) {
            vm.Battles = error.ExceptionMessage;
        });


        vm.GetRank = function (player) {
            if (player) {
                for (var i = 0; i < vm.AllPlayers.length; i++) {
                    if (vm.AllPlayers[i].Name === player.Name)
                        return vm.AllPlayers[i].Rank;
                }
            }

            return 0;
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

        vm.PrintAwards = function (player) {
            var result = "";
            if (player && player.Awards && player.Awards.length > 0) {
                for (var i = 0; i < player.Awards.length; i++) {
                    result += "'" + player.Awards[i].Name + "'";
                    if (i < player.Awards.length - 1)
                        result += ", ";
                }
            }

            return result;
        };


    }]);

})();