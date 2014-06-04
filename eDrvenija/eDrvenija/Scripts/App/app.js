'use strict';

angular.module('edrvenija', ['ngRoute', 'edrvenija.controllers', 'edrvenija.filters'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider

        .when('/Pocetna', { templateUrl: 'Home/Pocetna', controller: 'OglasiController' })

        .when('/KomentTemp', { templateUrl: 'Home/KomentTemp', controller: 'KomentarController' })

        .when('/PregledOglasa', { templateUrl: 'Home/PregledOglasa', controller: 'PregledOglasaController' })

        .when('/PaginationTemp', { templateUrl: 'Home/PaginationTemp', controller: 'MyCtrl' })

        .when('/UrediProfil/:id', { templateUrl: 'Home/UrediProfil', controller: 'UserController' })

        .when('/SlanjePorukeTemp/:id', { templateUrl: 'Home/SlanjePorukeTemp', controller: 'PorukeController' })

        .when('/PregledPoruka', { templateUrl: 'Home/PregledPoruka', controller: 'PorukeController' })


    //.when('/', { templateUrl: '', controller: '' }) //TODO: podesiti sve rute!!!

    .otherwise({ redirectTo: '/' });
}]);
