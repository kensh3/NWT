'use strict';

angular.module('firstApp.factories', [])

    .factory('UsersFactory', ['$http', function ($http) {
        var url = 'http://localhost/RestApi/api/User/';

        var UsersFactory = {};

        UsersFactory.getAllUsers = function () {
            return $http.get(url);
        }

        UsersFactory.getUserById = function (id) {
            return $http.get(url + id);
        }

        UsersFactory.createUser = function (user) {
            return $http.post(url, user);
        }

        UsersFactory.deleteUser = function (id) {
            return $http.delete(url + id);
        }

        return UsersFactory;
    }])

    .factory('CarsFactory', ['$http', function ($http) {
        var url = 'http://localhost/RestApi/api/Car/';

        var CarsFactory = {}

        CarsFactory.getAllCars = function() {
            return $http.get(url);
        }

        CarsFactory.getCarById = function (id) {
            return $http.get(url + id);
        }

        CarsFactory.createCar = function (car) {
            return $http.post(url, car);
        }

        CarsFactory.deleteCar = function (id) {
            return $http.delete(url + id);
        }

        return CarsFactory;
    }]);