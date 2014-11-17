(function () {
    'use strict';
    var controllerId = 'invoiceLineIndexCtrl';
    angular.module('app').controller(controllerId, ['common', 'invoiceLineDataService', invoiceLineList]);

    function invoiceLineList(common, invoiceLineDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Invoice Line List',
            description: 'Invoice Line List'
        };
       
        vm.pagableResults = [];
        vm.title = 'InvoiceLineList';
        vm.sortExpression = 'InvoiceLineId';
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteInvoiceLine = deleteInvoiceLine;

        activate();

        vm.pageChanged = function () {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Invoice Line List View'); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return invoiceLineDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pagableResults = results.data;
              });
        }

        function deleteInvoiceLine(invoiceLineId) {
            alert("test worked");
          //  return invoiceDataService.deleteInvoiceLine(invoiceLineId);
        };
    }
})();

