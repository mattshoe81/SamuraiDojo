// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("Services");

    app.factory("DataService", ["$window", function ($window) {
        var persistent = {};

        persistent.get = function (key) {
            var value = null;
            try {
                value = $window.localStorage[key];
            }
            catch (exception) {
                value = null;
            }

            return value;
        };
        persistent.save = function (key, value) {
            var success = true;
            try {
                $window.localStorage[key] = value;
            }
            catch (exception) {
                success = false;
            }

            return success;
        };
        persistent.remove = function (key) {
            var success = true;
            try {
                $window.localStorage.removeItem(key);
            }
            catch (exception) {
                success = false;
            }

            return success;
        };

        var session = {};
        session.get = function (key) {
            var value = null;
            try {
                value = $window.sessionStorage.getItem(key);
            }
            catch (exception) {
                value = null;
            }

            return value;
        };
        session.save = function (key, value) {
            var success = true;
            try {
                $window.sessionStorage.setItem(key, value);
            }
            catch (exception) {
                success = false;
            }

            return success;
        };
        session.remove = function (key) {
            var success = true;
            try {
                $window.sessionStorage.removeItem(key);
            }
            catch (exception) {
                success = false;
            }

            return success;
        };

        return {
            Persistent: {
                Get: persistent.get,
                Save: persistent.save,
                Remove: persistent.remove
            },
            Session: {
                Get: session.get,
                Save: session.save,
                Remove: session.remove
            }
        };
    }]);

})();