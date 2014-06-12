'use strict';

angular.module('edrvenija', ['ngRoute', 'edrvenija.controllers', 'edrvenija.filters'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider

        .when('/Pocetna', { templateUrl: 'Home/Pocetna', controller: 'OglasiController' })

        .when('/KomentTemp', { templateUrl: 'Home/KomentTemp', controller: 'KomentarController' })

        .when('/PregledOglasa', { templateUrl: 'Home/PregledOglasa', controller: 'PregledOglasaController' })

        .when('/NajnovijiOglasi', { templateUrl: 'Home/NajnovijiOglasi', controller: 'OglasiController' })

        .when('/PreporuceniOglasi', { templateUrl: 'Home/PreporuceniOglasi', controller: 'OglasiController' })

        .when('/PregledOglasaPoKategoriji', { templateUrl: 'Home/PregledOglasaPoKategoriji', controller: 'PregledOglasaPoKategoriji' })

        .when('/PaginationTemp', { templateUrl: 'Home/PaginationTemp', controller: 'MyCtrl' })

        .when('/UrediProfil/:id', { templateUrl: 'Home/UrediProfil', controller: 'UserController' })

        .when('/SlanjePorukeTemp/:id', { templateUrl: 'Home/SlanjePorukeTemp', controller: 'PorukeController' })

        .when('/PregledPoruka', { templateUrl: 'Home/PregledPoruka', controller: 'PorukeController' })

        .when('/RezultatPretrage', { templateUrl: 'Home/RezultatPretrage', controller: 'SearchController' })

        .when('/UrediOglas/:id', { templateUrl: 'Home/UrediOglas', controller: 'UrediOglasController' })

        .when('/DodajOglas/:id',{ templateUrl: 'Home/DodajOglas', controller: 'UrediOglasController' })


    //.when('/', { templateUrl: '', controller: '' }) //TODO: podesiti sve rute!!!

    .otherwise({ redirectTo: '/' });
}]);
