﻿//------------------------------------------------------------------------------
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

    var serviceId = 'invoiceDataService';
    angular.module('app').service(serviceId, ['$http', invoiceDataService]);

    function invoiceDataService($http) {
        var urlBase = '/api/invoices';

        this.getData = function () {
            return $http.get(urlBase + '/all');
        };

        this.updateInvoice = function (invoice) {
            return $http.put(urlBase, invoice);
        };

        this.insertInvoice = function (invoice) {
            return $http.post(urlBase, invoice);
        };

        this.deleteInvoice = function (invoiceId) {
            return $http.Delete(urlBase, invoiceId);
        };

        this.getDataPageable = function (sortExpression, page, pageSize) {
            return $http({
                url: urlBase,
                method: 'GET',
                params: {
                    sortExpression: sortExpression || '',
                    page: page || '',
                    pageSize: pageSize || ''
                }
            });
        };

        this.getDataByInvoiceId = function (invoiceId) {
            return $http.get(urlBase + '/' + invoiceId);
        };

        this.getDataByCustomerId = function (customerId) {
            return $http.get('/api/customers/' + customerId + '/invoices/all');
        };

        this.getDataByCustomerIdPageable = function (customerId, sortExpression, page, pageSize) {
            return $http({
                url: '/api/customers/' + customerId + '/invoices',
                method: 'GET',
                params: {
                    customerId: customerId || '',
                    sortExpression: sortExpression || '',
                    page: page || '',
                    pageSize: pageSize || ''
                }
            });
        };


    }
})();
