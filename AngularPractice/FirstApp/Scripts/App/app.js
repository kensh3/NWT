'use strict';

angular.module('firstApp', ['ngRoute', 'firstApp.controllers', 'firstApp.filters'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider

            .when('/Users', { templateUrl: 'Home/Users', controller: 'UserController' })

            .when('/Users/Create', { templateUrl: 'Home/CreateUser', controller: 'UserController' })

            .when('/Cars', { templateUrl: 'Home/Cars', controller: 'CarController' })

            .when('/Cars/Create', { templateUrl: 'Home/CreateCar', controller: 'CarController' })

            .otherwise({ redirectTo: '/' });
    }]);