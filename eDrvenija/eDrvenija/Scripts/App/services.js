'use strict';

angular.module('edrvenija.services', [])

.service('OglasiPomocniServis', function() {

var idOglasa ="";

return {
    getIdOglasa: function () {
        return idOglasa;
    },
    setIdOglasa: function (id) {
        idOglasa = id;
    }
};
});