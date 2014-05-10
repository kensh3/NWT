'use strict';

angular.module('edrvenija', ['ngRoute', 'edrvenija.controllers', 'edrvenija.filters'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider

    .when('/', { templateUrl: '', controller: '' }) //TODO: podesiti sve rute!!!

    .otherwise({ redirectTo: '/' });
}]);
