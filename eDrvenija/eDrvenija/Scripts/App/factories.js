'use strict';

angular.module('edrvenija.factories', [])

.factory('KomentariFactory', ['$http', function ($http) {
    var url = 'http://localhost/api/KomentariApi/'; //TODO: Prvo namjestiti servise, pa napisati odgovarajuci URL

    var KomentariFactory = {};

    KomentariFactory.dajSveKomentare = function () { //Moze se koristiti i rest direktiva, koja je bolja, ali je http jednostavnija
        return $http.get(url);
    }

    CommentFactory.kreirajKomentar = function (komentar) {
        return $http.post(url, komentar);
    }
}])

.factory('OglasiFactory', ['$http', function ($http) {
    var url = 'http://localhost/api/OglasiApi/Getoglasis'

    var OglasiFactory = {};

    OglasiFactory.dajSveOglase = function () {
        return $http.get(url);
    }
}])

.factory('PorukeFactory', ['$http', function ($http) {
    var url = 'http://localhost/api/PorukeApi/';

    var PorukeFactory = {};

    PorukeFactory.dajSvePoruke = function () {
        return $http.get(url);
    }

    PorukeFactory.kreirajPoruku = function (poruka) {
        return $http.post(url, poruka);
    }
}]);
