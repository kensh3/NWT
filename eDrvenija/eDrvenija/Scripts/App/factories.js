'use strict';

angular.module('edrvenija.factories', [])

.factory('KomentariFactory', ['$http', function ($http) {
    
    var url = 'http://localhost:3611/api/KomentariApi/'; //TODO: Prvo namjestiti servise, pa napisati odgovarajuci URL

    var KomentariFactory = {};

    KomentariFactory.dajSveKomentare = function () { //Moze se koristiti i rest direktiva, koja je bolja, ali je http jednostavnija
        return $http.get(url + 'dajkomentare');
    }

    KomentariFactory.kreirajKomentar = function (komentar) {
        return $http.post(url + 'Postavikomentar', komentar);
    }

    return KomentariFactory;
}])

.factory('KategorijeFactory', ['$http', function ($http) {

    var url = 'http://localhost:3611/api/KategorijeApi/';

    var KategorijeFactory = {};

    KategorijeFactory.dajSveKategorije = function () { //Moze se koristiti i rest direktiva, koja je bolja, ali je http jednostavnija
        return $http.get(url + 'dajKategorije');
    }

    return KategorijeFactory;
}])

.factory('OglasiFactory', ['$http', function ($http) {
    var url = 'http://localhost:3611/api/OglasiApi/'

    var OglasiFactory = {};

    /*
    Ovo se mozda moze drugacije uraditi zasad je tako
    */
    var idOglasa = "";
    OglasiFactory.getIdOglasa = function () {
        return idOglasa;
    }
    OglasiFactory.setIdOglasa = function (id) {
        idOglasa = id;
    }
    //kraj tog dijela

    OglasiFactory.dajOglasPoID = function (id) {
        return $http.get(url + 'Getoglasi/' + id);
    }

    OglasiFactory.dajTopOglase = function () {
        return $http.get(url + 'DajTopCetiriPregledanaOglasa');
    }

    OglasiFactory.dajNajnovijeOglase = function () {
        return $http.get(url + 'DajCetiriNajnovijaOglasa');
    }

    return OglasiFactory;
}])

.factory('PorukeFactory', ['$http', function ($http) {
    var url = 'http://localhost:3611/api/PorukeApi/';

    var PorukeFactory = {};

    PorukeFactory.dajSvePoruke = function () {
        return $http.get(url);
    }

    PorukeFactory.kreirajPoruku = function (poruka) {
        return $http.post(url, poruka);
    }

    return PorukeFactory;
}]);
