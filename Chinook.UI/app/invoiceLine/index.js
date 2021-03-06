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

    var controllerId = 'invoiceLineIndexCtrl';
    angular.module('app').controller(controllerId, ['common', 'invoiceLineDataService', invoiceLineList]);

    function invoiceLineList(common, invoiceLineDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'InvoiceLine List',
            description: 'InvoiceLine List'
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
                .then(function () { log('Activated InvoiceLine List View'); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return invoiceLineDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pagableResults = results.data;
              });
        }

        function deleteInvoiceLine(invoiceLineId) {
            alert("test worked");
          //  return invoiceLineDataService.deleteInvoiceLine(invoiceLineId);
        };
    }
})();

