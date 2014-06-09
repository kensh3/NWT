'use strict';

angular.module('edrvenija.factories', [])

.factory('KomentariFactory', ['$http', function ($http) {

    var url = 'api/KomentariApi/'; //TODO: Prvo namjestiti servise, pa napisati odgovarajuci URL

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

    var url = 'api/KategorijeApi/';

    var KategorijeFactory = {};

    KategorijeFactory.dajSveKategorije = function () { //Moze se koristiti i rest direktiva, koja je bolja, ali je http jednostavnija
        return $http.get(url + 'dajKategorije');
    }

    KategorijeFactory.pretrazikategorije = function (keyword) {
        return $http.get(url + 'pretrazikategorije?keyword=' + keyword);
    }

    return KategorijeFactory;
}])

.factory('OglasiFactory', ['$http', function ($http) {
    var url = 'api/OglasiApi/'

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

    OglasiFactory.pretrazioglase = function (keyword) {
        return $http.get(url + 'pretrazioglase?keyword=' + keyword);
    }

    OglasiFactory.kreirajOglas = function (oglas) {
        return $http.post(url + 'dodajOglas',oglas);
    }
    OglasiFactory.urediOglas = function (oglas) {
        return $http.post(url + 'urediOglas', oglas);
    }
    OglasiFactory.brisiOglas = function (oglas) {
        return $http.post(url + 'brisiOglas', oglas);
    }


    return OglasiFactory;
}])

.factory('PorukeFactory', ['$http', function ($http) {
    var url = 'api/PorukeApi/';

    var PorukeFactory = {};

    PorukeFactory.dajSvePorukeKorisnika = function (id) {
        return $http.get(url + 'dajsveporukekorisnika?korisnikId=' + id);
    }

    PorukeFactory.dajSvePrimljenePoruke = function (id) {
        return $http.get(url + 'dajsveprimljeneporuke?korisnikId=' + id);
    }

    PorukeFactory.dajSvePoslanePoruke = function (id) {
        return $http.get(url + 'dajsveposlaneporuke?korisnikId=' + id);
    }

    PorukeFactory.dajSveSistemskePoruke = function (id) {
        return $http.get(url + 'dajsvesistemskeporuke?korisnikId=' + id);
    }

    PorukeFactory.dajSvaObavjestenja = function (id) {
        return $http.get(url + 'dajsvaobavjestenja');
    }

    PorukeFactory.kreirajPoruku = function (poruka) {
        return $http.post(url + 'postaviporuku', poruka);
    }

    return PorukeFactory;
}])

.factory('UserFactory', ['$http', function ($http) {
    var url = 'api/KorisniciApi/';

    var UserFactory = {};

    UserFactory.dajUseraById = function (id) {
        return $http.get(url + "dajkorisnika/" + id);
    }

    UserFactory.putuser = function (user) {
        return $http.put(url + "putkorisnik", user);
    }

    UserFactory.pretrazikorisnike = function (keyword) {
        return $http.get(url + "pretrazikorisnike?keyword=" + keyword);
    }

    return UserFactory;
}]);
