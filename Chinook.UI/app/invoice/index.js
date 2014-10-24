(function () {
    'use strict';
    var controllerId = 'invoiceIndexCtrl';
    angular.module('app').controller(controllerId, ['common', 'invoiceDataService', invoiceList]);

    function invoiceList(common, invoiceDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Invoice List',
            description: 'Invoice List'
        };
       
        vm.pagableResults = [];
        vm.title = 'InvoiceList';
        vm.sortExpression = 'Name';
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteInvoice = deleteInvoice;

        activate();

        vm.pageChanged = function () {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Invoice List View'); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return invoiceDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pagableResults = results.data;
              });
        }

        function deleteInvoice(invoiceId) {
            alert("test worked");
          //  return invoiceDataService.deleteInvoice(invoiceId);
        };
    }
})();

