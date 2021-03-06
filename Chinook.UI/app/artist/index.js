//------------------------------------------------------------------------------
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

    var controllerId = 'artistIndexCtrl';
    angular.module('app').controller(controllerId, ['common', 'artistDataService', artistList]);

    function artistList(common, artistDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Artist List',
            description: 'Artist List'
        };
       
        vm.pagableResults = [];
        vm.title = 'ArtistList';
        vm.sortExpression = 'ArtistId';
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteArtist = deleteArtist;

        activate();

        vm.pageChanged = function () {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Artist List View'); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return artistDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pagableResults = results.data;
              });
        }

        function deleteArtist(artistId) {
            alert("test worked");
          //  return artistDataService.deleteArtist(artistId);
        };
    }
})();

