'use strict';

angular.module('edrvenija', ['ngRoute', 'edrvenija.controllers', 'edrvenija.filters'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider

        .when('/Pocetna', { templateUrl: 'Home/Pocetna', controller: 'OglasiController' })

        .when('/KomentTemp', { templateUrl: 'Home/KomentTemp', controller: 'KomentarController' })

        .when('/PregledOglasa', { templateUrl: 'Home/PregledOglasa', controller: 'PregledOglasaController' })

        


    //.when('/', { templateUrl: '', controller: '' }) //TODO: podesiti sve rute!!!

    .otherwise({ redirectTo: '/' });
}]);
