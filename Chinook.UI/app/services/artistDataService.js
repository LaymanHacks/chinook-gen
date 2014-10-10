(function () {
    'use strict';

    var serviceId = 'artistDataService';
    angular.module('app').service(serviceId, ['$http', artistDataService]);

    function artistDataService($http) {
        var urlBase = '/api/artists';

        this.getData = function () {
            return $http.get(urlBase + '/all');
        };

        this.updateArtist = function (artist) {
            return $http.put(urlBase, artist);
        };

        this.insertArtist = function (artist) {
            return $http.post(urlBase, artist);
        };

        this.deleteArtist = function (artistId) {
            return $http.Delete(urlBase, artistId);
        };

        this.getDataPageable = function (sortExpression, page, pageSize) {
            return $http({
                url: urlBase,
                method: 'GET',
                params: {
                    sortExpression: sortExpression || '',
                    page: page || '',
                    pageSize: pageSize || ''
                }
            });
        };

        this.getDataByArtistId = function (artistId) {
            return $http.get(urlBase + '/' + artistId);
        };


    }
})();

