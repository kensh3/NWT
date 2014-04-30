'use strict';

angular.module('firstApp.controllers', ['firstApp.factories'])

    .controller('MainController', function ($scope, $route, $routeParams, $location) {
        $scope.$route = $route;
        $scope.$location = $location;
        $scope.$routeParams = $routeParams;
    })

    .controller('UserController', ['$scope', 'UsersFactory', 'CarsFactory', '$location', '$route', function ($scope, UsersFactory, CarsFactory, $location, $route) { 
        $scope.users = [];

        UsersFactory.getAllUsers()

            .success(function (data, status) {
                $scope.users = data;
                $scope.status = status;
             });

        CarsFactory.getAllCars()

            .success(function (data, success) {
                $scope.cars = data;
                $scope.status = status;
            });

        $scope.createUser = function () {
            var user = {
                "FirstName": $scope.firstName,
                "LastName": $scope.lastName,
                "CarId": $scope.carId
            };
            var newId = UsersFactory.createUser(user)
                .success(function () {
                    $route.reload();
                });
            $scope.firstName = '';
            $scope.lastName = '';
            $scope.carId = '';
            $location.path('/Users');
            
        };

        $scope.deleteUser = function () {
            UsersFactory.deleteUser($scope.userIdDelete)
                .success(function () {
                    $route.reload();
                });
            $scope.userIdDelete = '';
        };
    }])

    .controller('CarController', ['$scope', 'CarsFactory', '$location', '$timeout', '$route', function ($scope, CarsFactory, $location, $timeout, $route) {
        $scope.cars = [];

        CarsFactory.getAllCars()

            .success(function (data, success) {
                $scope.cars = data;
                $scope.status = status;
            });

        $scope.createCar = function () {
            var car = {
                "Name": $scope.name,
                "Type": $scope.type,
                "Year": $scope.year
            };
            var newId = CarsFactory.createCar(car)
                .success(function () {
                    $route.reload();
                });
            $scope.name = '';
            $scope.type = '';
            $scope.year = '';
            $location.path('/Cars');
        };

        $scope.deleteCar = function () {
            CarsFactory.deleteCar($scope.carIdDelete)
                .success(function () {
                    $route.reload();
                });
            $scope.carIdDelete = '';
        };

        $scope.getNumber = function () {
            var yearArray = new Array();
            for (var i = 1980; i < 2015; i++) {
                yearArray.push(i);
            }
            return yearArray;
        };
    }]);
    