(function () {
    'use strict';
    var controllerId = 'genreIndexCtrl';
    angular.module('app').controller(controllerId, ['common', 'genreDataService', genreList]);

    function genreList(common, genreDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'genre List',
            description: 'genre List'
        };
       
        vm.pagableResults = [];
        vm.title = 'genreList';
        vm.sortExpression = 'Name';
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteGenre = deleteGenre;

        activate();

        vm.pageChanged = function () {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated genre List View'); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return genreDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pagableResults = results.data;
              });
        }

        function deleteGenre(genreId) {
            alert("test worked");
          //  return genreDataService.deletegenre(genreId);
        };
    }
})();

