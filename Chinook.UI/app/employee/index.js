(function () {
    'use strict';
    var controllerId = 'employeeIndexCtrl';
    angular.module('app').controller(controllerId, ['common', 'employeeDataService', employeeList]);

    function employeeList(common, employeeDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'employee List',
            description: 'employee List'
        };
       
        vm.pagableResults = [];
        vm.title = 'employeeList';
        vm.sortExpression = 'Title';
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteEmployee = deleteEmployee;

        activate();

        vm.pageChanged = function () {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated employee List View'); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return employeeDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pagableResults = results.data;
              });
        }

        function deleteEmployee(employeeId) {
            alert("test worked");
          //  return employeeDataService.deleteemployee(employeeId);
        };
    }
})();

