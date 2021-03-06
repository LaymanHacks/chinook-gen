﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
(function () {
    'use strict';

    var serviceId = 'playlistTrackDataService';
    angular.module('app').service(serviceId, ['$http', playlistTrackDataService]);

    function playlistTrackDataService($http) {
        var urlBase = '/api/playlistTracks';

        this.getData = function () {
            return $http.get(urlBase + '/all');
        };

        this.updatePlaylistTrack = function (playlistTrack) {
            return $http.put(urlBase, playlistTrack);
        };

        this.insertPlaylistTrack = function (playlistTrack) {
            return $http.post(urlBase, playlistTrack);
        };

        this.deletePlaylistTrack = function (playlistId, trackId) {
            return $http.Delete(urlBase, playlistId, trackId);
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

        this.getDataByPlaylistIdTrackId = function (playlistId, trackId) {
            return $http.get(urlBase + '/all');
        };

        this.getDataByPlaylistId = function (playlistId) {
            return $http.get('/api/playlists/' + playlistId + '/playlistTracks/all');
        };

        this.getDataByPlaylistIdPageable = function (playlistId, sortExpression, page, pageSize) {
            return $http({
                url: '/api/playlists/' + playlistId + '/playlistTracks',
                method: 'GET',
                params: {
                    playlistId: playlistId || '',
                    sortExpression: sortExpression || '',
                    page: page || '',
                    pageSize: pageSize || ''
                }
            });
        };

        this.getDataByTrackId = function (trackId) {
            return $http.get('/api/tracks/' + trackId + '/playlistTracks/all');
        };

        this.getDataByTrackIdPageable = function (trackId, sortExpression, page, pageSize) {
            return $http({
                url: '/api/tracks/' + trackId + '/playlistTracks',
                method: 'GET',
                params: {
                    trackId: trackId || '',
                    sortExpression: sortExpression || '',
                    page: page || '',
                    pageSize: pageSize || ''
                }
            });
        };


    }
})();
