﻿'use strict';

angular.module('edrvenija.controllers', ['edrvenija.factories'])

.controller('IndexController', function ($scope, $route, $routeParams, $location) { //Kontroler za pocetnu stranicu
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
})

.controller('KomentarController', ['$scope', 'KomentariFactory', function ($scope, KomentariFactory) {
    $scope.komentari = [];

        KomentariFactory.dajSveKomentare()

    .success(function (data) {
        $scope.komentari = data;
    })
        .error(function (data, status) {
            alert(status)
        });

    $scope.kreirajKomentar = function () {
        var komentar = {
            "TekstKomentara": $scope.tekstKomentara,
            "Aktivan": true, //ovo je potrebno na servisu mozda uraditi?
            "IdKorisnika": 1, //TODO: izvuci iz sesije
            "IdOglasa": 1 //TODO: izvuci iz rute, kada se napravi pregled oglasa
        };
        KomentariFactory.kreirajKomentar(komentar)

        .success(function () {
            $scope.komentari.push(komentar);
        });

        $scope.tekstKomentara = '';
    };
}])

.controller('OglasiController', ['$scope', 'OglasiFactory', function ($scope, OglasiFactory) {
    $scope.oglasi = [];

        OglasiFactory.dajSveOglase()
    .success(function (data) {
        $scope.oglasi = data;
    });
        
}])

.controller('PorukeController', ['$scope', 'PorukeFactory', function ($scope, PorukeFactory) {
    $scope.poruke = [];

        PorukeFactory.dajSvePoruke()

    .success(function (data) {
        $scope.poruke = data;
    });
    

    $scope.kreirajPoruku = function () {
        var poruka = {
            "naslovPoruke": $scope.naslovPoruke,
            "tekstPoruke": $scope.tekstPoruke,
            "aktivan": true, //ovo je potrebno na servisu mozda uraditi?
            "idKorisnikaPosiljaoca": '', //TODO: izvuci iz sesije
            "idKorisnikaPrimaoca": '' //TODO: izvuci iz rute 
        };
        PorukeFactory.kreirajPoruku(poruka)

        .success(function () {
            //TODO: mozda neki modal, uspjesno poslana poruka
        });
    };

    $scope.posaljiPorukuSistem = function (naslov, tekst, primaoc) {
        var poruka = {
            "naslovPoruke": naslov,
            "tekstPoruke": tekst,
            "aktivan": true, //ovo je potrebno na servisu mozda uraditi?
            "idKorisnikaPosiljaoca": null, //null jer je sistem posiljaoc
            "idKorisnikaPrimaoca": primaoc
        };
        PorukeFactory.kreirajPoruku(poruka)

        .success(function () {
            //TODO: ?
        });
    };
}])

.controller('MyCtrl', ['$scope', function ($scope) {
    $scope.currentPage = 0;
    $scope.pageSize = 10;
    $scope.data = [];
    $scope.numberOfPages = function () {
        return Math.ceil($scope.data.length / $scope.pageSize);
    }
    for (var i = 0; i < 45; i++) {
        $scope.data.push("Item " + i); //TODO: ovdje idu pravi itemi
    }
}]);
