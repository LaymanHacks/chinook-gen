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
        vm.sortExpression = 'Name';
        vm.currentPage = 1;
        vm.pageSize = 20;

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
    }
})();

angular.module('app').filter('range', function () {
    return function (val, range) {
        range = parseInt(range);
        for (var i = 0; i < range; i++)
            val.push(i);
        return val;
    };
});