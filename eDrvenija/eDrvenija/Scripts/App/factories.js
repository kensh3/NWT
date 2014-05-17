'use strict';

angular.module('edrvenija.factories', [])

.factory('KomentariFactory', ['$http', function ($http) {
    
    var url = 'http://edrvenija.somee.com/api/KomentariApi/'; //TODO: Prvo namjestiti servise, pa napisati odgovarajuci URL

    var KomentariFactory = {};

    KomentariFactory.dajSveKomentare = function () { //Moze se koristiti i rest direktiva, koja je bolja, ali je http jednostavnija
        return $http.get(url + 'dajkomentare');
    }

    KomentariFactory.kreirajKomentar = function (komentar) {
        return $http.post(url + 'Postavikomentar', komentar);
    }

    return KomentariFactory;
}])

.factory('OglasiFactory', ['$http', function ($http) {
    var url = 'http://edrvenija.somee.com/api/OglasiApi/Getoglasis'

    var OglasiFactory = {};

    OglasiFactory.dajSveOglase = function () {
        return $http.get(url);
    }

    return OglasiFactory;
}])

.factory('PorukeFactory', ['$http', function ($http) {
    var url = 'http://edrvenija.somee.com/api/PorukeApi/';

    var PorukeFactory = {};

    PorukeFactory.dajSvePoruke = function () {
        return $http.get(url);
    }

    PorukeFactory.kreirajPoruku = function (poruka) {
        return $http.post(url, poruka);
    }

    return PorukeFactory;
}]);
