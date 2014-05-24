'use strict';

angular.module('edrvenija.controllers', ['edrvenija.factories'])

.controller('IndexController', ['$scope','KategorijeFactory', function ($scope, KategorijeFactory, $route, $routeParams, $location) { //Kontroler za pocetnu stranicu
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;

    $scope.kategorije = []; //Iz nekog razloga mi ne pohrani ove dole podatke od dajSveKategorije u ovome; znaci, ovo kategorije ostane prazno nakon poziva dajSveKategorije;

    KategorijeFactory.dajSveKategorije()

    .success(function (data) {
        $scope.kategorije = data;
    })
        .error(function (data, status) {
            alert(status)
        });

}])

.controller('KomentarController', ['$scope', '$rootScope', 'KomentariFactory', function ($scope, $rootScope, KomentariFactory) {
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
            $rootScope.noveNotifikacije = true;
        });

        $scope.tekstKomentara = '';
    };
}])

.controller('OglasiController', ['$scope', 'OglasiFactory', '$routeParams', '$location', function ($scope, OglasiFactory, $routeParams, $location) {
    $scope.topOglasi = [];
    $scope.najnovijiOglasi = [];
    $scope.test = {};

    OglasiFactory.dajTopOglase()
    .success(function (data) {
        $scope.topOglasi = data;
    })
    .error(function (data, status) {
        alert(status)
    });

    OglasiFactory.dajNajnovijeOglase()
    .success(function (data) {
        $scope.najnovijiOglasi = data;
    })
    .error(function (data, status) {
        alert(status)
    });

        $scope.nekaAkcija = function (oglas) {
            alert(oglas.IdOglasa);
        }

        
        $scope.go = function (path, id) {
            OglasiFactory.setIdOglasa(id);
            $scope.test.IdOglasa = id;
            $location.path(path);
            
        };

    
        
}])

.controller('PregledOglasaController', ['$scope', 'OglasiFactory', '$routeParams', '$location', function ($scope, OglasiFactory, $routeParams, $location)  {
    var test = OglasiFactory.getIdOglasa();
    $scope.oglas = {};

    OglasiFactory.dajOglasPoID(test)
     .success(function (data) {
         $scope.oglas = data;
     })
     .error(function (data, status) {
         alert(status)
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
    for (var i = 0; i < 50; i++) {
        $scope.data.push("Item " + i); //TODO: ovdje idu pravi itemi
    }
}])

.controller('NotifikacijeController', ['$rootScope', function ($rootScope) {
    if ($rootScope.noveNotifikacije) {
        setTimeout(function () { $("#notifikacije").hide(); }, 5000);
    }
}])

.controller('UserController', ['$scope', '$routeParams', 'UserFactory', function ($scope, $routeParams, UserFactory) {
    UserFactory.dajUseraById($routeParams.id)
    .success(function (data) {
        $scope.user = data
    });
    
    $scope.editUser = function () {
        var korisnik = {
            Id: $scope.user.Id,
            Ime: $scope.user.Ime,
            Prezime: $scope.user.Prezime,
            EMail: $scope.user.EMail,
            BrojTelefona: $scope.user.BrojTelefona,
            Ocjena: $scope.user.Ocjena,
            KorisnickoIme: $scope.user.KorisnickoIme,
            LozinkaKorisnika: $scope.user.LozinkaKorisnika,
            IdTipKorisnika: $scope.user.IdTipKorisnika
        };

        UserFactory.putuser(korisnik)

        .success(function () {
            $scope.user.Ime = '';
            $scope.user.Prezime = '';
            $scope.user.EMail = '';
            $scope.user.BrojTelefona = '';
            $scope.user.Ocjena = '';
            $scope.user.KorisnickoIme = '';
            $scope.user.IdTipKorisnika = '';
        });


    };
}]);
