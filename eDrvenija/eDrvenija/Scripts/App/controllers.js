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
    $scope.sviNajnovijiOglasi = [];
    $scope.preporuceniOglasi = [];
    //$scope.test = {};
    var test = OglasiFactory.getIdOglasa();
    $scope.test = test;
    OglasiFactory.dajOglasPoID($routeParams.id)
     .success(function (data) {
       $scope.oglas = data
    });
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

    OglasiFactory.dajSveNajnovijeOglase()
    .success(function (data) {
        $scope.sviNajnovijiOglasi = data;
    })
    .error(function (data, status) {
        alert(status)
    });

    OglasiFactory.dajPreporuceneOglase()
    .success(function (data) {
        $scope.preporuceniOglasi = data;
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

.controller('UrediOglasController', ['$scope', '$routeParams', 'OglasiFactory', function ($scope, $routeParams, OglasiFactory) {
        OglasiFactory.dajOglasPoID($routeParams.id)
         .success(function (data) {
             $scope.oglas = data
         });
   

    $scope.kreirajOglas = function () {
        var oglasnovi = {

            nazivOglasa: $scope.oglasnovi.nazivOglasa,
            opisOglasa: $scope.oglasnovi.opisOglasa,
            cijena: $scope.oglasnovi.cijena,
            idTipaOglasa: $routeParams.id,
            idKategorije: $scope.oglasnovi.idKategorije,
        };
        OglasiFactory.kreirajOglas(oglasnovi)
        .success(function (data) {
            $scope.oglasnovi.nazivOglasa = '';
            $scope.oglasnovi.opisOglasa = '';
            $scope.oglasnovi.cijena = '';
        })
        .error(function (data, status) {

        });
    };
    $scope.urediOglas = function () {
        var oglas = {
            idOglasa: $scope.oglas.idOglasa,
            nazivOglasa: $scope.oglas.nazivOglasa,
            datumObjaveOglasa: $scope.oglas.datumObjaveOglasa,
            opisOglasa: $scope.oglas.opisOglasa,
            cijena: $scope.oglas.cijena,
            brojPregledaOglasa: $scope.oglas.brojPregledaOglasa,
            zavrsenaTransakcija: $scope.oglas.zavrsenaTransakcija,
            aktivan: $scope.oglas.aktivan,
            idTipaOglasa: $scope.oglas.idTipaOglasa,
            idKategorije: $scope.oglas.idKategorije,
            idKorisnika: $scope.oglas.idKorisnika
        };
        OglasiFactory.urediOglas(oglas)
        .success(function (data) {
            $scope.oglas.nazivOglasa = '';
            $scope.oglas.datumObjaveOglasa = '';
            $scope.oglas.opisOglasa = '';
            $scope.oglas.opisOglasa = '';
            $scope.oglas.cijena = '';
            $scope.oglas.brojPregledaOglasa = '';
            $scope.oglas.zavrsenaTransakcija = '';


        })
        .error(function (data, status) {

        });
    };

    $scope.brisiOglas = function () {
        var oglas = {
            idOglasa: $scope.oglas.idOglasa,
            nazivOglasa: $scope.oglas.nazivOglasa,
            datumObjaveOglasa: $scope.oglas.datumObjaveOglasa,
            opisOglasa: $scope.oglas.opisOglasa,
            cijena: $scope.oglas.cijena,
            brojPregledaOglasa: $scope.oglas.brojPregledaOglasa,
            zavrsenaTransakcija: $scope.oglas.zavrsenaTransakcija,
            aktivan: $scope.oglas.aktivan,
            idTipaOglasa: $scope.oglas.idTipaOglasa,
            idKategorije: $scope.oglas.idKategorije,
            idKorisnika: $scope.oglas.idKorisnika
        };
        OglasiFactory.brisiOglas(oglas)
        .success(function (data) {
            $scope.oglas.nazivOglasa = '';
            $scope.oglas.datumObjaveOglasa = '';
            $scope.oglas.opisOglasa = '';
            $scope.oglas.opisOglasa = '';
            $scope.oglas.cijena = '';
            $scope.oglas.brojPregledaOglasa = '';
            $scope.oglas.zavrsenaTransakcija = '';


        })
        .error(function (data, status) {

        });
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

.controller('PorukeController', ['$scope', '$routeParams', 'PorukeFactory', function ($scope, $routeParams, PorukeFactory) {
    $scope.poruke = [];

    PorukeFactory.dajSvePorukeKorisnika(4)

    .success(function (data) {
        $scope.poruke = data;
    });
    
    $scope.dajSvePrimljenePoruke = function () {
        PorukeFactory.dajSvePrimljenePoruke(4)

        .success(function (data) {
            $scope.poruke = data;
        });
    };

    $scope.dajSvePoslanePoruke = function () {
        PorukeFactory.dajSvePoslanePoruke(4)

        .success(function (data) {
            $scope.poruke = data;
        });
    };

    $scope.dajSveSistemskePoruke = function () {
        PorukeFactory.dajSveSistemskePoruke(4)

        .success(function (data) {
            $scope.poruke = data;
        });
    };

    $scope.dajSvaObavjestenja = function () {
        PorukeFactory.dajSvaObavjestenja()

        .success(function (data) {
            $scope.poruke = data;
        });
    };

    $scope.kreirajPoruku = function () {
        var poruka = {
            "NaslovPoruke": $scope.naslovPoruke,
            "TekstPoruke": $scope.tekstPoruke,
            "Aktivan": true, //ovo je potrebno na servisu mozda uraditi?
            "PosiljaocId": 2, //TODO: izvuci iz sesije
            "PrimaocId": $routeParams.id
        };
        PorukeFactory.kreirajPoruku(poruka)

        .success(function () {
            $scope.naslovPoruke = '';
            $scope.tekstPoruke = '';
            alert("Poruka uspjesno poslana.");
            //TODO: mozda neki modal, uspjesno poslana poruka
        });
    };

    $scope.posaljiPorukuSistem = function (naslov, tekst, primaoc) {
        var poruka = {
            "NaslovPoruke": naslov,
            "TekstPoruke": tekst,
            "Aktivan": true, //ovo je potrebno na servisu mozda uraditi?
            "PosiljaocId": null, //null jer je sistem posiljaoc
            "PrimaocId": primaoc
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
}])

.controller('SearchController', ['$scope', '$routeParams', 'UserFactory', 'OglasiFactory', 'KategorijeFactory', '$location', function ($scope, $routeParams, UserFactory, OglasiFactory, KategorijeFactory, $location) {
    $scope.pretrazikorisnike = function () {
        UserFactory.pretrazikorisnike($scope.keyword)
       .success(function (data) {
           alert("OPA GANGAM STYLE")
           $scope.korisnicisearch = data;
           /*$("#korisniciul").show();*/
       });
    };

    $scope.pretrazikategorije = function () {
        KategorijeFactory.pretrazikategorije($scope.keyword)
       .success(function (data) {
           alert("OPA GANGAM STYLE 2")
           $scope.kategorijesearch = data;
           /*$("#kateogrijeul").show();*/
       });
    };

    $scope.pretrazioglase = function () {
        OglasiFactory.pretrazioglase($scope.keyword)
       .success(function (data) {
           alert("OPA GANGAM STYLE 3")
           $scope.oglasisearch = data;
           
           /*$("#oglasiul").show();*/
       });
    };

    $scope.pretrazi = function () {
        
        if ($scope.pretraziPo == 1) {
            $scope.pretrazioglase();
            /*$("#kateogrijeul").hide();
            $("#korisniciul").hide();*/
        }
        else if ($scope.pretraziPo == 2) {
            $scope.pretrazikorisnike();
            /*$("#kateogrijeul").hide();
            $("#oglasiul").hide();*/
        }
        else if ($scope.pretraziPo == 3) {
            $scope.pretrazikategorije();
           /* $("#oglasiul").hide();
            $("#korisniciul").hide();*/
        }

        $location.path('RezultatPretrage');
    };
}]);
