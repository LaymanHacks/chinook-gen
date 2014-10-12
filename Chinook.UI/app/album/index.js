(function () {
    'use strict';
    var controllerId = 'albumIndexCtrl';
    angular.module('app').controller(controllerId, ['common', 'albumDataService', albumList]);

    function albumList(common, albumDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'album List',
            description: 'album List'
        };
       
        vm.pagableResults = [];
        vm.title = 'albumList';
        vm.sortExpression = 'Title';
        vm.currentPage = 1;
        vm.pageSize = 20;
        vm.deletealbum = deleteAlbum;

        activate();

        vm.pageChanged = function () {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated album List View'); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return albumDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pagableResults = results.data;
              });
        }

        function deleteAlbum(albumId) {
            alert("test worked");
          //  return albumDataService.deletealbum(albumId);
        };
    }
})();

