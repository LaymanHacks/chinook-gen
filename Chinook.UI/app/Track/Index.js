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

    var controllerId = 'trackIndexCtrl';
    angular.module('app').controller(controllerId, ['common', 'trackDataService', trackList]);

    function trackList(common, trackDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Track List',
            description: 'Track List'
        };
       
        vm.pagableResults = [];
        vm.title = 'TrackList';
        vm.sortExpression = 'TrackId';
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteTrack = deleteTrack;

        activate();

        vm.pageChanged = function () {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Track List View'); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return trackDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pagableResults = results.data;
              });
        }

        function deleteTrack(trackId) {
            alert("test worked");
          //  return trackDataService.deleteTrack(trackId);
        };
    }
})();

