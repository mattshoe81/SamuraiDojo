// Use IIFE as recommended by AngularJS to remove all functions and variables from the global scope
(function () {
    'use strict';

    var app = angular.module("Directives");

    app.directive("dojoCodeBox", function () {
        return {
            restrict: "E",
            templateUrl: "/Angular/Directives/CodeBox.html",
            replace: true,
            scope: {
                source: "="
            },
            link: function (scope) {
                scope.resizeIframe = function (obj) {
                    obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px';
                };
            }
        };
    });

})();