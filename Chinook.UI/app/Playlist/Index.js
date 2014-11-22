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

    var controllerId = 'playlistIndexCtrl';
    angular.module('app').controller(controllerId, ['common', 'playlistDataService', playlistList]);

    function playlistList(common, playlistDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Playlist List',
            description: 'Playlist List'
        };
       
        vm.pagableResults = [];
        vm.title = 'PlaylistList';
        vm.sortExpression = 'PlaylistId';
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deletePlaylist = deletePlaylist;

        activate();

        vm.pageChanged = function () {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Playlist List View'); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return playlistDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pagableResults = results.data;
              });
        }

        function deletePlaylist(playlistId) {
            alert("test worked");
          //  return playlistDataService.deletePlaylist(playlistId);
        };
    }
})();

